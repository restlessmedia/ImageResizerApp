using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ImageResizerApp
{
  internal class FolderWatcher : IDisposable
  {
    public FolderWatcher(string directoryPath, WatermarkImage watermarkImage, ILog log)
    {
      if (string.IsNullOrWhiteSpace(directoryPath))
      {
        throw new ArgumentNullException(nameof(directoryPath));
      }

      if (!Directory.Exists(directoryPath))
      {
        throw new DirectoryNotFoundException($"{directoryPath} is not a valid directory");
      }

      string completedFolder = Path.Combine(directoryPath, "completed");
      string failedFolder = Path.Combine(directoryPath, "failed");

      _completeDirectory = Directory.CreateDirectory(completedFolder);
      _failedDirectory = Directory.CreateDirectory(failedFolder);
      _watcher = new FileSystemWatcher(directoryPath)
      {
        NotifyFilter = NotifyFilters.FileName | NotifyFilters.CreationTime | NotifyFilters.LastWrite,
        Filter = "**"
      };
      _watcher.Changed += OnChanged;
      _watermarkImage = watermarkImage;
      _log = log;
    }

    public void Enable(bool enable = true)
    {
      _watcher.EnableRaisingEvents = enable;
    }

    public void Dispose()
    {
      _watcher.Dispose();
    }

    private async void OnChanged(object sender, FileSystemEventArgs e)
    {
      if (e.ChangeType == WatcherChangeTypes.Created || e.ChangeType == WatcherChangeTypes.Changed)
      {
        string extension = Path.GetExtension(e.FullPath);

        if (!new[] { ".jpg", ".jpeg", ".png" }.Any(allowed => string.Equals(extension, allowed, StringComparison.OrdinalIgnoreCase)))
        {
          MoveToFailedDirectory(e.FullPath);
          return;
        }

        await Retry(() =>
        {
          try
          {
            _watermarkImage.ApplyTo(e.FullPath, _completeDirectory.FullName);
            MoveToCompleteDirectory(e.FullPath);
            return true;
          }
          catch
          {
            return false;
          }
        }, () => MoveToFailedDirectory(e.FullPath));
      }
    }

    private void MoveToCompleteDirectory(string path)
    {
      TryMoveFile(path, _completeDirectory);
    }

    private void MoveToFailedDirectory(string path)
    {
      TryMoveFile(path, _failedDirectory);
    }

    private async void TryMoveFile(string sourcePath, DirectoryInfo targetDirectory)
    {
      string destinationPath = Path.Combine(targetDirectory.FullName, Path.GetFileName(sourcePath));

      await Retry(() =>
      {
        File.Move(sourcePath, destinationPath);
        return File.Exists(destinationPath);
      });
    }

    private static async Task Retry(Func<bool> fn, Action onFailed = null, double tryFor = 50)
    {
      long stopWhen = DateTime.Now.AddSeconds(tryFor).Ticks;

      while (DateTime.Now.Ticks < stopWhen)
      {
        try
        {
          if (fn())
          {
            return;
          }
        }
        catch
        {
          await Task.Delay(1000);
        }
      }

      onFailed?.Invoke();
    }

    private readonly WatermarkImage _watermarkImage;

    private readonly DirectoryInfo _completeDirectory;

    private readonly DirectoryInfo _failedDirectory;

    private readonly FileSystemWatcher _watcher;

    private readonly ILog _log;
  }
}
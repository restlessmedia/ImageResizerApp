using System;
using System.CodeDom;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageResizerApp
{
  public partial class Form1 : Form
  {
    public Form1(ILog log)
    {
      _log = log ?? throw new ArgumentNullException(nameof(log));

      InitializeComponent();
      _watermarkImage = new WatermarkImage();

      pictureBox1.Image = _watermarkImage.GetImage();

      try
      {
        _settings = Settings.Load();
      }
      catch (Exception e)
      {
        _settings = new Settings();
        log.Exception("Settings failed to load", e);
      }

      FormClosed += OnClosed;
      DragEnter += (sender, args) => args.Effect = DragDropEffects.Copy;
      DragDrop += HandleDrop;

      label1.Text = _settings.SaveDirectory ?? "(No directory)";
    }

    private void button1_Click(object sender, EventArgs e)
    {
      if (openFileDialog1.ShowDialog() == DialogResult.OK)
      {
        AddFile(openFileDialog1.FileName);
      }
    }

    private void button2_Click(object sender, EventArgs e)
    {
      folderBrowserDialog1.SelectedPath = _settings.SaveDirectory;

      if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
      {
        label1.Text = _settings.SaveDirectory = folderBrowserDialog1.SelectedPath;
      }
    }

    private async void button3_Click(object sender, EventArgs e)
    {
      await ProcessAsync();
      MessageBox.Show("All files processed");
      OpenFolder(_settings.SaveDirectory);
    }

    private void OnClosed(object sender, EventArgs args)
    {
      if (_folderWatcher != null)
      {
        _folderWatcher.Dispose();
      }

      _settings.Save();
    }

    private void HandleDrop(object sender, DragEventArgs e)
    {
      string[] dropped = (string[])e.Data.GetData(DataFormats.FileDrop);

      if (!dropped.Any())
      {
        return;
      }

      foreach (string path in dropped)
      {
        AddFile(path);
      }
    }

    private void AddFile(string path)
    {
      if (listBox1.Items.Cast<string>().Any(item => string.Equals(item, path)))
      {
        return;
      }

      listBox1.Items.Add(path);
    }

    private Task ProcessAsync()
    {
      return Task.Run(() =>
      {
        foreach (string path in listBox1.Items)
        {
          string savePath = Path.Combine(_settings.SaveDirectory, Path.GetFileName(path));

          try
          {
            _watermarkImage.ApplyTo(path, savePath);
          }
          catch (Exception e)
          {
            _log.Exception("Watermark failed", e);
          }
        }
      });
    }

    private void checkBox1_CheckedChanged(object sender, EventArgs e)
    {
      if (checkBox1.Checked)
      {
        if (_folderWatcher == null)
        {
          _folderWatcher = new FolderWatcher(@"C:\Users\phill\Desktop\New folder (2)", _watermarkImage, _log);
        }
        _folderWatcher.Enable(true);
      }
      else if (_folderWatcher != null)
      {
        _folderWatcher.Enable(false);
      }
    }

    private static void OpenFolder(string folderPath)
    {
      ProcessStartInfo startInfo = new ProcessStartInfo
      {
        Arguments = folderPath,
        FileName = "explorer.exe"
      };

      Process.Start(startInfo);
    }

    private readonly WatermarkImage _watermarkImage;

    private readonly Settings _settings;

    private readonly ILog _log;

    private FolderWatcher _folderWatcher;
  }
}
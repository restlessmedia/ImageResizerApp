using System;
using System.Globalization;
using System.IO;
using System.Reflection;

namespace ImageResizerApp
{
  internal class FileLog : ILog
  {
    public FileLog()
    {
      _writer = GetWriter();
    }

    public void Error(string message)
    {
      WriteLine("ERROR", message);
    }

    public void Info(string message)
    {
      WriteLine("INFO", message);
    }

    public void Warning(string message)
    {
      WriteLine("WARN", message);
    }

    public void Dispose()
    {
      _writer.Flush();
      _writer.Dispose();
    }

    private static StreamWriter GetWriter()
    {
      DateTime now = DateTime.Now;
      string directory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase).Replace("file:\\", "");
      string fileName = $"watermark-{now.Year}-{now.Month}.log";
      string path = Path.Combine(directory, fileName);
      FileMode fileMode = File.Exists(path) ? FileMode.Append : FileMode.OpenOrCreate;
      FileStream fileStream = new FileStream(path, fileMode, FileAccess.Write, FileShare.Read);
      return new StreamWriter(fileStream);
    }

    private void WriteLine(string type, string text)
    {
      string stamp = DateTime.Now.ToString("s", DateTimeFormatInfo.InvariantInfo);
      _writer.WriteLine($"{type} {stamp} - {text}");
    }

    private readonly StreamWriter _writer;
  }
}
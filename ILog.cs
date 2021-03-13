using System;

namespace ImageResizerApp
{
  public interface ILog : IDisposable
  {
    void Info(string message);

    void Warning(string message);

    void Error(string message);
  }
}
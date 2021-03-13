using System;

namespace ImageResizerApp
{
  public static class ILogExtensions
  {
    public static void Exception(this ILog log, string message, Exception e)
    {
      log.Error(string.Concat(message, ": ", e.ToString()));
    }
  }
}
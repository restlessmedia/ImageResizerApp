namespace ImageResizerApp
{
  internal class DualLog : ILog
  {
    public DualLog(ILog log1, ILog log2)
    {
      _log1 = log1;
      _log2 = log2;
    }

    public void Info(string message)
    {
      _log1.Info(message);
      _log2.Info(message);
    }

    public void Warning(string message)
    {
      _log1.Warning(message);
      _log2.Warning(message);
    }

    public void Error(string message)
    {
      _log1.Error(message);
      _log2.Error(message);
    }

    public void Dispose()
    {
      _log1.Dispose();
      _log2.Dispose();
    }

    private readonly ILog _log1;

    private readonly ILog _log2;
  }
}
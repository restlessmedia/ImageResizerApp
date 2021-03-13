using System.Windows.Forms;

namespace ImageResizerApp
{
  internal class UILog : ILog
  {
    public void Dispose() { }

    public void Error(string message)
    {
      MessageBox.Show(message);
    }

    public void Info(string message)
    {
      MessageBox.Show(message);
    }

    public void Warning(string message)
    {
      MessageBox.Show(message);
    }
  }
}
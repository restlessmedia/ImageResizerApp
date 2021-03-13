using System;
using System.Windows.Forms;

namespace ImageResizerApp
{
  static class Program
  {
    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
      ILog fileLog = new FileLog();
      ILog uiLog = new UILog();
      using (ILog log = new DualLog(fileLog, uiLog))
      {
        fileLog.Info("Application started");

        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        Application.Run(new Form1(log));
      }
    }
  }
}

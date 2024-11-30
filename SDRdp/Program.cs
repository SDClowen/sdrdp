using System;
using System.Windows.Forms;

namespace SDRdp;

public static class Program
{
    [STAThread]
    private static void Main(params string[] args)
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(true);
        Application.SetHighDpiMode(HighDpiMode.PerMonitor | HighDpiMode.PerMonitorV2);
        Application.Run(new MainWindow());
    }
}
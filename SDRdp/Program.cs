using System;
using System.Management.Automation.Runspaces;
using System.Management.Automation;
using System.Security;
using System.Windows.Forms;
using System.Collections.ObjectModel;

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
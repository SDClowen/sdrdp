using SDUI.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SDRdp
{
    public partial class AboutForm : UIWindow
    {
        public AboutForm()
        {
            InitializeComponent();
        }

        private void buttonGithub_Click(object sender, EventArgs e)
        {
            Process.Start(
            new ProcessStartInfo { FileName = "https://github.com/sponsors/SDClowen", UseShellExecute = true });
        }

        private void buttonBuymeacoffee_Click(object sender, EventArgs e)
        {
            Process.Start(new ProcessStartInfo { FileName = "https://buymeacoffee.com/sdclowen", UseShellExecute = true });
        }

        private void buttonPatreon_Click(object sender, EventArgs e)
        {
            Process.Start(new ProcessStartInfo { FileName = "https://www.patreon.com/sdclowen", UseShellExecute = true });
        }
    }
}

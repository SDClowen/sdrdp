using SDRdp.Core.Configuration;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace SDRdp
{
    internal class ConnectionItem : SDUI.Controls.GroupBox
    {
        public event EventHandler ConnectSavedEventHandler;
        public event EventHandler RemoveConnectionEventHandler;

        SDUI.Controls.Button buttonConnect;
        SDUI.Controls.Button buttonRemove;
        internal SDUI.Controls.Label labelName;

        internal ConnectionItem(string title, FreeRdpConfiguration config)
            : base()
        {
            labelName = new SDUI.Controls.Label();
            buttonConnect = new SDUI.Controls.Button();
            buttonRemove = new SDUI.Controls.Button();

            this.BackColor = Color.Transparent;
            this.Controls.Add(labelName);
            this.Controls.Add(buttonConnect);
            this.Controls.Add(buttonRemove);
            this.Font = new Font("Segoe UI", 9, FontStyle.Regular, GraphicsUnit.Point, 162);
            this.Location = new Point(15, 15);
            this.Padding = new Padding(6, 8, 6, 6);
            this.Radius = 25;
            this.ShadowDepth = 4;
            this.Size = new Size(281, 181);
            this.Tag = config;
            this.TabStop = false;
            this.Text = title;

            labelName.ApplyGradient = false;
            labelName.Dock = DockStyle.Bottom;
            labelName.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Regular, GraphicsUnit.Point, 162);
            labelName.Gradient = [Color.Gray, Color.Black];
            labelName.GradientAnimation = false;
            labelName.Location = new Point(6, 147);
            labelName.Name = "labelName";
            labelName.Size = new Size(269, 28);
            labelName.TabIndex = 0;
            labelName.Text = config.Title ?? "RDP Connection";
            labelName.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // buttonConnect
            // 
            buttonConnect.Color = Color.Black;
            buttonConnect.Font = new Font("Segoe UI", 28.2F, FontStyle.Regular, GraphicsUnit.Point, 162);
            buttonConnect.ForeColor = Color.White;
            buttonConnect.Location = new Point(104, 52);
            buttonConnect.Name = "buttonConnect";
            buttonConnect.Radius = 48;
            buttonConnect.ShadowDepth = 6F;
            buttonConnect.Tag = config;
            buttonConnect.Size = new Size(64, 64);
            buttonConnect.TabIndex = 4;
            buttonConnect.Text = "▶";
            buttonConnect.UseVisualStyleBackColor = true;
            buttonConnect.Click += (sender, e) => ConnectSavedEventHandler?.Invoke(sender, e);

            buttonRemove.Color = Color.Red;
            buttonRemove.Font = new Font("Segoe UI", 9, FontStyle.Regular, GraphicsUnit.Point, 162);
            buttonRemove.ForeColor = Color.White;

            var measure = TextRenderer.MeasureText("✕", buttonRemove.Font);

            buttonRemove.Location = new Point(this.Size.Width - measure.Width - (Padding.Right / 2), measure.Height / 2 - (Padding.Top / 2));
            buttonRemove.Radius = 16;
            buttonRemove.ShadowDepth = 0F;
            buttonRemove.Tag = config;
            buttonRemove.Size = new Size(measure.Width, measure.Height);
            buttonRemove.Text = "✕";
            buttonRemove.UseVisualStyleBackColor = true;
            buttonRemove.Click += (sender, e) => RemoveConnectionEventHandler?.Invoke(sender, e);
        }
    }
}

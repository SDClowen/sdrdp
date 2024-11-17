using SDRdp.Core.Configuration;
using SDUI;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace SDRdp
{
    public partial class ConnectionHistory : UserControl
    {
        private readonly Color[] _gradient = new[] { Color.Gray, Color.Black };
        private readonly Font _font = new Font("Segoe UI", 32, FontStyle.Regular);
        private readonly StringFormat _format = new StringFormat() { LineAlignment = StringAlignment.Center, Alignment = StringAlignment.Center };

        public ConnectionHistory()
        {
            InitializeComponent();
        }

        public void Add(FreeRdpConfiguration config, EventHandler eventHandler)
        {
            var title = $"{config.Server}@{config.Username}";
            SDUI.Controls.Button buttonConnect;
            SDUI.Controls.Label labelName;
            SDUI.Controls.GroupBox connectInfo;

            connectInfo = new SDUI.Controls.GroupBox();
            labelName = new SDUI.Controls.Label();
            buttonConnect = new SDUI.Controls.Button();

            connectInfo.BackColor = System.Drawing.Color.Transparent;
            connectInfo.Controls.Add(labelName);
            connectInfo.Controls.Add(buttonConnect);
            connectInfo.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 162);
            connectInfo.Location = new System.Drawing.Point(15, 15);
            connectInfo.Name = "connectInfo";
            connectInfo.Padding = new System.Windows.Forms.Padding(6, 8, 6, 6);
            connectInfo.Radius = 20;
            connectInfo.ShadowDepth = 4;
            connectInfo.Size = new System.Drawing.Size(281, 181);
            connectInfo.TabIndex = 9;
            connectInfo.TabStop = false;
            connectInfo.Text = title;

            labelName.ApplyGradient = false;
            labelName.Dock = System.Windows.Forms.DockStyle.Bottom;
            labelName.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 162);
            labelName.Gradient = new System.Drawing.Color[]
    {
    System.Drawing.Color.Gray,
    System.Drawing.Color.Black
    };
            labelName.GradientAnimation = false;
            labelName.Location = new System.Drawing.Point(6, 147);
            labelName.Name = "labelName";
            labelName.Size = new System.Drawing.Size(269, 28);
            labelName.TabIndex = 0;
            labelName.Text = config.Title ?? "RDP Connection";
            labelName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonConnect
            // 
            buttonConnect.Color = System.Drawing.Color.Transparent;
            buttonConnect.Font = new System.Drawing.Font("Segoe UI", 28.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 162);
            buttonConnect.ForeColor = System.Drawing.Color.White;
            buttonConnect.Location = new System.Drawing.Point(104, 52);
            buttonConnect.Name = "buttonConnect";
            buttonConnect.Radius = 64;
            buttonConnect.ShadowDepth = 0F;
            buttonConnect.Tag = config;
            buttonConnect.Size = new System.Drawing.Size(72, 72);
            buttonConnect.TabIndex = 4;
            buttonConnect.Text = "▶";
            buttonConnect.UseVisualStyleBackColor = true;
            buttonConnect.Click += eventHandler;

            flowLayoutPanel.Controls.Add(connectInfo);
        }

        private void flowLayoutPanel_Paint(object sender, PaintEventArgs e)
        {
            if (flowLayoutPanel.Controls.Count == 0)
            {
                using var brush = new LinearGradientBrush(ClientRectangle, _gradient[0], _gradient[1], 45/*LinearGradientMode.Horizontal */);

                e.Graphics.DrawString("Waiting any connection...", _font, brush, ClientRectangle, _format);
            }
        }
    }
}

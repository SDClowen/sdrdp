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
        public event EventHandler ConnectEventHandler;
        public event EventHandler ConnectSavedEventHandler;

        private readonly Color[] _gradient = [Color.Gray, Color.Black];
        private readonly Font _font = new("Segoe UI", 32, FontStyle.Regular);
        private readonly StringFormat _format = new() { LineAlignment = StringAlignment.Center, Alignment = StringAlignment.Center };

        public ConnectionHistory()
        {
            InitializeComponent();
        }

        public void Add(FreeRdpConfiguration config, EventHandler removeEventHandler)
        {
            var title = $"{config.Server}@{config.Username}";
            SDUI.Controls.Button buttonConnect;
            SDUI.Controls.Button buttonRemove;
            SDUI.Controls.Label labelName;
            SDUI.Controls.GroupBox connectInfo;

            connectInfo = new SDUI.Controls.GroupBox();
            labelName = new SDUI.Controls.Label();
            buttonConnect = new SDUI.Controls.Button();
            buttonRemove = new SDUI.Controls.Button();

            connectInfo.BackColor = System.Drawing.Color.Transparent;
            connectInfo.Controls.Add(labelName);
            connectInfo.Controls.Add(buttonConnect);
            connectInfo.Controls.Add(buttonRemove);
            connectInfo.Font = new System.Drawing.Font("Segoe UI", 9, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 162);
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
            labelName.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 162);
            labelName.Gradient = [Color.Gray, Color.Black];
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
            buttonConnect.Click += ConnectSavedEventHandler;

            buttonRemove.Color = System.Drawing.Color.Red;
            buttonRemove.Font = new System.Drawing.Font("Segoe UI", 9, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 162);
            buttonRemove.ForeColor = System.Drawing.Color.White;
            buttonRemove.Location = new System.Drawing.Point(connectInfo.Size.Width - 28, 2);
            buttonRemove.Radius = 24;
            buttonRemove.ShadowDepth = 0F;
            buttonRemove.Tag = config;
            buttonRemove.Size = new System.Drawing.Size(24, 24);
            buttonRemove.TabIndex = 4;
            buttonRemove.Text = "✕";
            buttonRemove.UseVisualStyleBackColor = true;
            buttonRemove.Click += removeEventHandler;
            buttonRemove.Click += (sender, e) =>
            {
                flowLayoutPanel.Controls.Remove(connectInfo);
            };

            if (!flowLayoutPanel.Visible)
                flowLayoutPanel.Visible = true;

            flowLayoutPanel.Controls.Add(connectInfo);
            flowLayoutPanel.Controls.SetChildIndex(panel, flowLayoutPanel.Controls.Count - 1);
        }

        private void ConnectionHistory_Load(object sender, EventArgs e)
        {
            flowLayoutPanel.Visible = false;

            SDUI.Controls.Button buttonConnect = new();
            buttonConnect.Color = System.Drawing.Color.Transparent;
            buttonConnect.Font = new System.Drawing.Font("Segoe UI", 13, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 162);
            buttonConnect.ForeColor = System.Drawing.Color.White;
            buttonConnect.Location = new System.Drawing.Point(Width / 2 - 128, Height / 2 - 32);
            buttonConnect.Name = "buttonConnect";
            buttonConnect.Radius = 64;
            buttonConnect.ShadowDepth = 0F;
            buttonConnect.Size = new System.Drawing.Size(256, 64);
            buttonConnect.Text = " Connect to server";
            buttonConnect.UseVisualStyleBackColor = true;
            buttonConnect.Click += ConnectEventHandler;

            Controls.Add(buttonConnect);
        }

        private void buttonNewConnect_Click(object sender, EventArgs e)
        {
            ConnectEventHandler?.Invoke(this, EventArgs.Empty);
        }
    }
}

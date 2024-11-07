namespace SDRdp
{
    partial class MainWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            MenuStrip = new SDUI.Controls.ContextMenuStrip();
            ConnectMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            DisconnectMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            Separator2 = new System.Windows.Forms.ToolStripSeparator();
            ZoomInMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ZoomOutMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ResetZoomMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            fullScreenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            Separator1 = new System.Windows.Forms.ToolStripSeparator();
            SettingsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            savedConnections = new System.Windows.Forms.ToolStripMenuItem();
            aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ConnectionMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            pageController = new SDUI.Controls.WindowPageControl();
            labelStarting = new SDUI.Controls.Label();
            panelFullScreen = new SDUI.Controls.Panel();
            buttonExitFullScreen = new SDUI.Controls.Button();
            label1 = new System.Windows.Forms.Label();
            MenuStrip.SuspendLayout();
            panelFullScreen.SuspendLayout();
            SuspendLayout();
            // 
            // MenuStrip
            // 
            MenuStrip.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            MenuStrip.ImageScalingSize = new System.Drawing.Size(32, 32);
            MenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { ConnectMenuItem, DisconnectMenuItem, Separator2, ZoomInMenuItem, ZoomOutMenuItem, ResetZoomMenuItem, fullScreenToolStripMenuItem, Separator1, SettingsMenuItem, toolStripSeparator1, savedConnections, aboutToolStripMenuItem, exitToolStripMenuItem });
            MenuStrip.Name = "MenuStrip";
            MenuStrip.Size = new System.Drawing.Size(211, 262);
            MenuStrip.Text = "menuStrip1";
            // 
            // ConnectMenuItem
            // 
            ConnectMenuItem.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            ConnectMenuItem.Name = "ConnectMenuItem";
            ConnectMenuItem.Size = new System.Drawing.Size(210, 24);
            ConnectMenuItem.Text = "C&onnect";
            ConnectMenuItem.Click += ConnectMenuItem_Click;
            // 
            // DisconnectMenuItem
            // 
            DisconnectMenuItem.Enabled = false;
            DisconnectMenuItem.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            DisconnectMenuItem.Name = "DisconnectMenuItem";
            DisconnectMenuItem.Size = new System.Drawing.Size(210, 24);
            DisconnectMenuItem.Text = "&Disconnect";
            DisconnectMenuItem.Click += DisconnectMenuItem_Click;
            // 
            // Separator2
            // 
            Separator2.Name = "Separator2";
            Separator2.Size = new System.Drawing.Size(207, 6);
            // 
            // ZoomInMenuItem
            // 
            ZoomInMenuItem.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            ZoomInMenuItem.Name = "ZoomInMenuItem";
            ZoomInMenuItem.Size = new System.Drawing.Size(210, 24);
            ZoomInMenuItem.Text = "Zoom &In";
            ZoomInMenuItem.Click += ZoomInMenuItem_Click;
            // 
            // ZoomOutMenuItem
            // 
            ZoomOutMenuItem.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            ZoomOutMenuItem.Name = "ZoomOutMenuItem";
            ZoomOutMenuItem.Size = new System.Drawing.Size(210, 24);
            ZoomOutMenuItem.Text = "Zoom O&ut";
            ZoomOutMenuItem.Click += ZoomOutMenuItem_Click;
            // 
            // ResetZoomMenuItem
            // 
            ResetZoomMenuItem.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            ResetZoomMenuItem.Name = "ResetZoomMenuItem";
            ResetZoomMenuItem.Size = new System.Drawing.Size(210, 24);
            ResetZoomMenuItem.Text = "&Reset Zoom (100%)";
            ResetZoomMenuItem.Click += ResetZoomMenuItem_Click;
            // 
            // fullScreenToolStripMenuItem
            // 
            fullScreenToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            fullScreenToolStripMenuItem.Name = "fullScreenToolStripMenuItem";
            fullScreenToolStripMenuItem.Size = new System.Drawing.Size(210, 24);
            fullScreenToolStripMenuItem.Text = "Full Screen";
            fullScreenToolStripMenuItem.Click += buttonFullScreen_Click;
            // 
            // Separator1
            // 
            Separator1.Name = "Separator1";
            Separator1.Size = new System.Drawing.Size(207, 6);
            // 
            // SettingsMenuItem
            // 
            SettingsMenuItem.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            SettingsMenuItem.Name = "SettingsMenuItem";
            SettingsMenuItem.Size = new System.Drawing.Size(210, 24);
            SettingsMenuItem.Text = "Connection Settings...";
            SettingsMenuItem.Click += SettingsMenuItem_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new System.Drawing.Size(207, 6);
            // 
            // savedConnections
            // 
            savedConnections.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            savedConnections.Name = "savedConnections";
            savedConnections.Size = new System.Drawing.Size(210, 24);
            savedConnections.Text = "Saved Connections";
            // 
            // aboutToolStripMenuItem
            // 
            aboutToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            aboutToolStripMenuItem.Size = new System.Drawing.Size(210, 24);
            aboutToolStripMenuItem.Text = "About";
            aboutToolStripMenuItem.Click += aboutToolStripMenuItem_Click;
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new System.Drawing.Size(210, 24);
            exitToolStripMenuItem.Text = "Exit";
            exitToolStripMenuItem.Click += ExitMenuItem_Click;
            // 
            // ConnectionMenuItem
            // 
            ConnectionMenuItem.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            ConnectionMenuItem.Name = "ConnectionMenuItem";
            ConnectionMenuItem.Size = new System.Drawing.Size(154, 24);
            ConnectionMenuItem.Text = "&Connection";
            // 
            // pageController
            // 
            pageController.Dock = System.Windows.Forms.DockStyle.Fill;
            pageController.Location = new System.Drawing.Point(1, 38);
            pageController.Margin = new System.Windows.Forms.Padding(2);
            pageController.Name = "pageController";
            pageController.SelectedIndex = -1;
            pageController.Size = new System.Drawing.Size(1136, 643);
            pageController.TabIndex = 1;
            pageController.SelectedIndexChanged += windowPageControl1_SelectedIndexChanged;
            // 
            // labelStarting
            // 
            labelStarting.ApplyGradient = true;
            labelStarting.Dock = System.Windows.Forms.DockStyle.Fill;
            labelStarting.Font = new System.Drawing.Font("Segoe UI", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 162);
            labelStarting.Gradient = new System.Drawing.Color[]
    {
    System.Drawing.Color.Gray,
    System.Drawing.Color.Black
    };
            labelStarting.GradientAnimation = false;
            labelStarting.Location = new System.Drawing.Point(1, 38);
            labelStarting.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            labelStarting.Name = "labelStarting";
            labelStarting.Size = new System.Drawing.Size(1136, 643);
            labelStarting.TabIndex = 2;
            labelStarting.Text = "Waiting any connection...";
            labelStarting.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelFullScreen
            // 
            panelFullScreen.BackColor = System.Drawing.Color.FromArgb(200, 0, 0, 0);
            panelFullScreen.Border = new System.Windows.Forms.Padding(2);
            panelFullScreen.BorderColor = System.Drawing.Color.RosyBrown;
            panelFullScreen.Controls.Add(label1);
            panelFullScreen.Controls.Add(buttonExitFullScreen);
            panelFullScreen.Location = new System.Drawing.Point(420, 5);
            panelFullScreen.Name = "panelFullScreen";
            panelFullScreen.Padding = new System.Windows.Forms.Padding(3);
            panelFullScreen.Radius = 10;
            panelFullScreen.ShadowDepth = 4F;
            panelFullScreen.Size = new System.Drawing.Size(285, 30);
            panelFullScreen.TabIndex = 3;
            panelFullScreen.Visible = false;
            // 
            // buttonExitFullScreen
            // 
            buttonExitFullScreen.Color = System.Drawing.Color.Firebrick;
            buttonExitFullScreen.Dock = System.Windows.Forms.DockStyle.Right;
            buttonExitFullScreen.ForeColor = System.Drawing.Color.White;
            buttonExitFullScreen.Location = new System.Drawing.Point(247, 3);
            buttonExitFullScreen.Name = "buttonExitFullScreen";
            buttonExitFullScreen.Radius = 6;
            buttonExitFullScreen.ShadowDepth = 4F;
            buttonExitFullScreen.Size = new System.Drawing.Size(35, 24);
            buttonExitFullScreen.TabIndex = 0;
            buttonExitFullScreen.Text = "X";
            buttonExitFullScreen.UseVisualStyleBackColor = true;
            buttonExitFullScreen.Click += buttonFullScreen_Click;
            // 
            // label1
            // 
            label1.BackColor = System.Drawing.Color.Transparent;
            label1.Dock = System.Windows.Forms.DockStyle.Left;
            label1.ForeColor = System.Drawing.Color.White;
            label1.Location = new System.Drawing.Point(3, 3);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(128, 24);
            label1.TabIndex = 1;
            label1.Text = "Exit from full screen";
            label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MainWindow
            // 
            AllowAddControlOnTitle = true;
            AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            ClientSize = new System.Drawing.Size(1138, 682);
            Controls.Add(panelFullScreen);
            Controls.Add(labelStarting);
            Controls.Add(pageController);
            ExtendBox = true;
            ExtendMenu = MenuStrip;
            Font = new System.Drawing.Font("Segoe UI", 10.2F);
            FullDrawHatch = true;
            Gradient = new System.Drawing.Color[]
    {
    System.Drawing.Color.RoyalBlue,
    System.Drawing.Color.MidnightBlue
    };
            Hatch = System.Drawing.Drawing2D.HatchStyle.Percent90;
            IconWidth = 48F;
            Location = new System.Drawing.Point(0, 0);
            Margin = new System.Windows.Forms.Padding(2);
            Name = "MainWindow";
            Padding = new System.Windows.Forms.Padding(1, 38, 1, 1);
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "SDRdp - Not Connected";
            TitleColor = System.Drawing.Color.Transparent;
            TitleHeight = 38F;
            WindowPageControl = pageController;
            FormClosing += FreeRdpForm_FormClosing;
            Load += MainWindow_Load;
            MenuStrip.ResumeLayout(false);
            panelFullScreen.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private SDUI.Controls.ContextMenuStrip MenuStrip;
        private System.Windows.Forms.ToolStripMenuItem ConnectionMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ConnectMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DisconnectMenuItem;
        private System.Windows.Forms.ToolStripSeparator Separator1;
        private System.Windows.Forms.ToolStripMenuItem SettingsMenuItem;
        private System.Windows.Forms.ToolStripSeparator Separator2;
        private System.Windows.Forms.ToolStripMenuItem ZoomInMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ZoomOutMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ResetZoomMenuItem;
        private SDUI.Controls.WindowPageControl pageController;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fullScreenToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem savedConnections;
        private SDUI.Controls.Label labelStarting;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private SDUI.Controls.Panel panelFullScreen;
        private System.Windows.Forms.Label label1;
        private SDUI.Controls.Button buttonExitFullScreen;
    }
}
﻿namespace SDRdp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            MenuStrip = new SDUI.Controls.ContextMenuStrip();
            ZoomInMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ZoomOutMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ResetZoomMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            fullScreenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            Separator1 = new System.Windows.Forms.ToolStripSeparator();
            SettingsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ConnectionMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            pageController = new SDUI.Controls.WindowPageControl();
            panelFullScreen = new System.Windows.Forms.Panel();
            label1 = new System.Windows.Forms.Label();
            buttonExitFullScreen = new SDUI.Controls.Button();
            formMenuStrip = new SDUI.Controls.ContextMenuStrip();
            connections = new Connections();
            MenuStrip.SuspendLayout();
            panelFullScreen.SuspendLayout();
            SuspendLayout();
            // 
            // MenuStrip
            // 
            MenuStrip.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            MenuStrip.ImageScalingSize = new System.Drawing.Size(32, 32);
            MenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { ZoomInMenuItem, ZoomOutMenuItem, ResetZoomMenuItem, fullScreenToolStripMenuItem, Separator1, SettingsMenuItem, toolStripSeparator1, aboutToolStripMenuItem, exitToolStripMenuItem });
            MenuStrip.Name = "MenuStrip";
            MenuStrip.Size = new System.Drawing.Size(247, 212);
            MenuStrip.Text = "menuStrip1";
            // 
            // ZoomInMenuItem
            // 
            ZoomInMenuItem.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            ZoomInMenuItem.Name = "ZoomInMenuItem";
            ZoomInMenuItem.Size = new System.Drawing.Size(246, 28);
            ZoomInMenuItem.Text = "Zoom &In";
            ZoomInMenuItem.Click += ZoomInMenuItem_Click;
            // 
            // ZoomOutMenuItem
            // 
            ZoomOutMenuItem.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            ZoomOutMenuItem.Name = "ZoomOutMenuItem";
            ZoomOutMenuItem.Size = new System.Drawing.Size(246, 28);
            ZoomOutMenuItem.Text = "Zoom O&ut";
            ZoomOutMenuItem.Click += ZoomOutMenuItem_Click;
            // 
            // ResetZoomMenuItem
            // 
            ResetZoomMenuItem.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            ResetZoomMenuItem.Name = "ResetZoomMenuItem";
            ResetZoomMenuItem.Size = new System.Drawing.Size(246, 28);
            ResetZoomMenuItem.Text = "&Reset Zoom (100%)";
            ResetZoomMenuItem.Click += ResetZoomMenuItem_Click;
            // 
            // fullScreenToolStripMenuItem
            // 
            fullScreenToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            fullScreenToolStripMenuItem.Name = "fullScreenToolStripMenuItem";
            fullScreenToolStripMenuItem.Size = new System.Drawing.Size(246, 28);
            fullScreenToolStripMenuItem.Text = "Full Screen";
            fullScreenToolStripMenuItem.Click += buttonFullScreen_Click;
            // 
            // Separator1
            // 
            Separator1.Name = "Separator1";
            Separator1.Size = new System.Drawing.Size(243, 6);
            // 
            // SettingsMenuItem
            // 
            SettingsMenuItem.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            SettingsMenuItem.Name = "SettingsMenuItem";
            SettingsMenuItem.Size = new System.Drawing.Size(246, 28);
            SettingsMenuItem.Text = "Connection Settings...";
            SettingsMenuItem.Click += SettingsMenuItem_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new System.Drawing.Size(243, 6);
            // 
            // aboutToolStripMenuItem
            // 
            aboutToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            aboutToolStripMenuItem.Size = new System.Drawing.Size(246, 28);
            aboutToolStripMenuItem.Text = "About";
            aboutToolStripMenuItem.Click += aboutToolStripMenuItem_Click;
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new System.Drawing.Size(246, 28);
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
            pageController.AutoScroll = true;
            pageController.Dock = System.Windows.Forms.DockStyle.Fill;
            pageController.Location = new System.Drawing.Point(0, 47);
            pageController.Margin = new System.Windows.Forms.Padding(0);
            pageController.Name = "pageController";
            pageController.SelectedIndex = -1;
            pageController.Size = new System.Drawing.Size(1288, 634);
            pageController.TabIndex = 1;
            pageController.SelectedIndexChanged += windowPageControl1_SelectedIndexChanged;
            // 
            // panelFullScreen
            // 
            panelFullScreen.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            panelFullScreen.BackColor = System.Drawing.Color.FromArgb(200, 0, 0, 0);
            panelFullScreen.Controls.Add(label1);
            panelFullScreen.Controls.Add(buttonExitFullScreen);
            panelFullScreen.Location = new System.Drawing.Point(505, 41);
            panelFullScreen.Name = "panelFullScreen";
            panelFullScreen.Padding = new System.Windows.Forms.Padding(3);
            panelFullScreen.Size = new System.Drawing.Size(255, 33);
            panelFullScreen.TabIndex = 3;
            panelFullScreen.Visible = false;
            panelFullScreen.MouseHover += panelFullScreen_MouseHover;
            // 
            // label1
            // 
            label1.BackColor = System.Drawing.Color.Transparent;
            label1.Dock = System.Windows.Forms.DockStyle.Fill;
            label1.ForeColor = System.Drawing.Color.White;
            label1.Location = new System.Drawing.Point(3, 3);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(220, 27);
            label1.TabIndex = 1;
            label1.Text = "Exit from full screen";
            label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // buttonExitFullScreen
            // 
            buttonExitFullScreen.Color = System.Drawing.Color.Firebrick;
            buttonExitFullScreen.Dock = System.Windows.Forms.DockStyle.Right;
            buttonExitFullScreen.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 162);
            buttonExitFullScreen.ForeColor = System.Drawing.Color.White;
            buttonExitFullScreen.Location = new System.Drawing.Point(223, 3);
            buttonExitFullScreen.Name = "buttonExitFullScreen";
            buttonExitFullScreen.Radius = 6;
            buttonExitFullScreen.ShadowDepth = 4F;
            buttonExitFullScreen.Size = new System.Drawing.Size(29, 27);
            buttonExitFullScreen.TabIndex = 0;
            buttonExitFullScreen.Text = "✕";
            buttonExitFullScreen.UseVisualStyleBackColor = true;
            buttonExitFullScreen.Click += buttonFullScreen_Click;
            // 
            // formMenuStrip
            // 
            formMenuStrip.DropShadowEnabled = false;
            formMenuStrip.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 162);
            formMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            formMenuStrip.Name = "formMenuStrip";
            formMenuStrip.Size = new System.Drawing.Size(61, 4);
            // 
            // connections
            // 
            connections.Dock = System.Windows.Forms.DockStyle.Fill;
            connections.Location = new System.Drawing.Point(0, 47);
            connections.Margin = new System.Windows.Forms.Padding(0);
            connections.Name = "connections";
            connections.PrivateKey = "123456";
            connections.Size = new System.Drawing.Size(1288, 634);
            connections.TabIndex = 4;
            connections.ConnectEventHandler += ConnectMenuItem_Click;
            connections.ConnectSavedEventHandler += SavedConnections_ConnectMenuItem_Click;
            connections.RemoveConnectionEventHandler += removeConnection_Click;
            // 
            // MainWindow
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            ClientSize = new System.Drawing.Size(1288, 682);
            Controls.Add(panelFullScreen);
            Controls.Add(connections);
            Controls.Add(pageController);
            DrawTabIcons = true;
            DrawTitleBorder = false;
            DwmMargin = 0;
            ExtendBox = true;
            ExtendMenu = MenuStrip;
            Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 162);
            FormMenu = formMenuStrip;
            Hatch = System.Drawing.Drawing2D.HatchStyle.Percent90;
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            IconWidth = 48F;
            Margin = new System.Windows.Forms.Padding(2);
            Name = "MainWindow";
            NewTabButton = true;
            Padding = new System.Windows.Forms.Padding(0, 47, 0, 1);
            ShowMenuInsteadOfIcon = true;
            TabCloseButton = true;
            Text = "SDRdp - Not Connected";
            TitleHeight = 38F;
            TitleTabDesingMode = TabDesingMode.Chromed;
            WindowPageControl = pageController;
            OnCloseTabBoxClick += MainWindow_OnCloseTabBoxClick;
            OnNewTabBoxClick += ConnectMenuItem_Click;
            MenuStrip.ResumeLayout(false);
            panelFullScreen.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private SDUI.Controls.ContextMenuStrip MenuStrip;
        private System.Windows.Forms.ToolStripMenuItem ConnectionMenuItem;
        private System.Windows.Forms.ToolStripSeparator Separator1;
        private System.Windows.Forms.ToolStripMenuItem SettingsMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ZoomInMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ZoomOutMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ResetZoomMenuItem;
        private SDUI.Controls.WindowPageControl pageController;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fullScreenToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.Panel panelFullScreen;
        private System.Windows.Forms.Label label1;
        private SDUI.Controls.Button buttonExitFullScreen;
        private SDUI.Controls.ContextMenuStrip formMenuStrip;
        private Connections connections;
    }
}
namespace SDRdp
{
    partial class Connections
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            flowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            buttonNewConnect = new SDUI.Controls.Button();
            panel1 = new System.Windows.Forms.Panel();
            separator1 = new SDUI.Controls.Separator();
            label1 = new SDUI.Controls.Label();
            buttonExport = new SDUI.Controls.Button();
            buttonImport = new SDUI.Controls.Button();
            splitContainer = new System.Windows.Forms.SplitContainer();
            flowLayoutPanelFavorited = new System.Windows.Forms.FlowLayoutPanel();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer).BeginInit();
            splitContainer.Panel1.SuspendLayout();
            splitContainer.Panel2.SuspendLayout();
            splitContainer.SuspendLayout();
            SuspendLayout();
            // 
            // flowLayoutPanel
            // 
            flowLayoutPanel.AutoScroll = true;
            flowLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            flowLayoutPanel.Location = new System.Drawing.Point(0, 0);
            flowLayoutPanel.Name = "flowLayoutPanel";
            flowLayoutPanel.Padding = new System.Windows.Forms.Padding(11, 12, 11, 12);
            flowLayoutPanel.Size = new System.Drawing.Size(1109, 596);
            flowLayoutPanel.TabIndex = 0;
            // 
            // buttonNewConnect
            // 
            buttonNewConnect.Color = System.Drawing.Color.DodgerBlue;
            buttonNewConnect.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 162);
            buttonNewConnect.ForeColor = System.Drawing.Color.White;
            buttonNewConnect.Location = new System.Drawing.Point(14, 4);
            buttonNewConnect.Name = "buttonNewConnect";
            buttonNewConnect.Radius = 8;
            buttonNewConnect.ShadowDepth = 8F;
            buttonNewConnect.Size = new System.Drawing.Size(120, 42);
            buttonNewConnect.TabIndex = 0;
            buttonNewConnect.Text = " Connect";
            buttonNewConnect.UseVisualStyleBackColor = true;
            buttonNewConnect.Click += buttonNewConnect_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(buttonNewConnect);
            panel1.Controls.Add(separator1);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(buttonExport);
            panel1.Controls.Add(buttonImport);
            panel1.Dock = System.Windows.Forms.DockStyle.Top;
            panel1.Location = new System.Drawing.Point(0, 0);
            panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(1109, 96);
            panel1.TabIndex = 1;
            // 
            // separator1
            // 
            separator1.Dock = System.Windows.Forms.DockStyle.Bottom;
            separator1.IsVertical = false;
            separator1.Location = new System.Drawing.Point(0, 88);
            separator1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            separator1.Name = "separator1";
            separator1.Size = new System.Drawing.Size(1109, 8);
            separator1.TabIndex = 2;
            // 
            // label1
            // 
            label1.ApplyGradient = false;
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 162);
            label1.Gradient = new System.Drawing.Color[]
    {
    System.Drawing.Color.Gray,
    System.Drawing.Color.Black
    };
            label1.GradientAnimation = false;
            label1.Location = new System.Drawing.Point(18, 51);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(147, 32);
            label1.TabIndex = 1;
            label1.Text = "Connections";
            // 
            // buttonExport
            // 
            buttonExport.Color = System.Drawing.Color.Transparent;
            buttonExport.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 162);
            buttonExport.Location = new System.Drawing.Point(294, 4);
            buttonExport.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            buttonExport.Name = "buttonExport";
            buttonExport.Radius = 8;
            buttonExport.ShadowDepth = 8F;
            buttonExport.Size = new System.Drawing.Size(147, 42);
            buttonExport.TabIndex = 0;
            buttonExport.Text = "Export Settings";
            buttonExport.UseVisualStyleBackColor = true;
            buttonExport.Click += buttonExport_Click;
            // 
            // buttonImport
            // 
            buttonImport.Color = System.Drawing.Color.Transparent;
            buttonImport.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 162);
            buttonImport.Location = new System.Drawing.Point(140, 4);
            buttonImport.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            buttonImport.Name = "buttonImport";
            buttonImport.Radius = 8;
            buttonImport.ShadowDepth = 8F;
            buttonImport.Size = new System.Drawing.Size(147, 42);
            buttonImport.TabIndex = 0;
            buttonImport.Text = "Import Settings";
            buttonImport.UseVisualStyleBackColor = true;
            buttonImport.Click += buttonImport_Click;
            // 
            // splitContainer
            // 
            splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            splitContainer.Location = new System.Drawing.Point(0, 96);
            splitContainer.Name = "splitContainer";
            splitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer.Panel1
            // 
            splitContainer.Panel1.Controls.Add(flowLayoutPanelFavorited);
            splitContainer.Panel1Collapsed = true;
            splitContainer.Panel1MinSize = 0;
            // 
            // splitContainer.Panel2
            // 
            splitContainer.Panel2.Controls.Add(flowLayoutPanel);
            splitContainer.Size = new System.Drawing.Size(1109, 596);
            splitContainer.SplitterDistance = 185;
            splitContainer.SplitterWidth = 2;
            splitContainer.TabIndex = 2;
            // 
            // flowLayoutPanelFavorited
            // 
            flowLayoutPanelFavorited.AutoScroll = true;
            flowLayoutPanelFavorited.Dock = System.Windows.Forms.DockStyle.Fill;
            flowLayoutPanelFavorited.Location = new System.Drawing.Point(0, 0);
            flowLayoutPanelFavorited.Name = "flowLayoutPanelFavorited";
            flowLayoutPanelFavorited.Size = new System.Drawing.Size(1109, 185);
            flowLayoutPanelFavorited.TabIndex = 0;
            // 
            // Connections
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(splitContainer);
            Controls.Add(panel1);
            Name = "Connections";
            Size = new System.Drawing.Size(1109, 692);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            splitContainer.Panel1.ResumeLayout(false);
            splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer).EndInit();
            splitContainer.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel;
        private SDUI.Controls.Button buttonNewConnect;
        private System.Windows.Forms.Panel panel1;
        private SDUI.Controls.Button buttonImport;
        private SDUI.Controls.Button buttonExport;
        private SDUI.Controls.Separator separator1;
        private SDUI.Controls.Label label1;
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelFavorited;
    }
}

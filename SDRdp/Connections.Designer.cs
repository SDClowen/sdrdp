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
            buttonNewConnect = new SDUI.Controls.Button();
            panel1 = new System.Windows.Forms.Panel();
            separator1 = new SDUI.Controls.Separator();
            buttonExport = new SDUI.Controls.Button();
            buttonImport = new SDUI.Controls.Button();
            groups = new ConnectionGroups();
            contextMenuConnectionItem = new SDUI.Controls.ContextMenuStrip();
            moveToGroupMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            panel2 = new System.Windows.Forms.Panel();
            panel1.SuspendLayout();
            contextMenuConnectionItem.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // buttonNewConnect
            // 
            buttonNewConnect.Color = System.Drawing.Color.DodgerBlue;
            buttonNewConnect.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 162);
            buttonNewConnect.ForeColor = System.Drawing.Color.White;
            buttonNewConnect.Location = new System.Drawing.Point(12, 3);
            buttonNewConnect.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            buttonNewConnect.Name = "buttonNewConnect";
            buttonNewConnect.Radius = 8;
            buttonNewConnect.ShadowDepth = 8F;
            buttonNewConnect.Size = new System.Drawing.Size(105, 32);
            buttonNewConnect.TabIndex = 0;
            buttonNewConnect.Text = " Connect";
            buttonNewConnect.UseVisualStyleBackColor = true;
            buttonNewConnect.Click += buttonNewConnect_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(separator1);
            panel1.Controls.Add(buttonNewConnect);
            panel1.Controls.Add(buttonExport);
            panel1.Controls.Add(buttonImport);
            panel1.Dock = System.Windows.Forms.DockStyle.Top;
            panel1.Location = new System.Drawing.Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(970, 40);
            panel1.TabIndex = 1;
            // 
            // separator1
            // 
            separator1.Dock = System.Windows.Forms.DockStyle.Bottom;
            separator1.IsVertical = false;
            separator1.Location = new System.Drawing.Point(0, 34);
            separator1.Name = "separator1";
            separator1.Size = new System.Drawing.Size(970, 6);
            separator1.TabIndex = 1;
            // 
            // buttonExport
            // 
            buttonExport.Color = System.Drawing.Color.Transparent;
            buttonExport.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 162);
            buttonExport.Location = new System.Drawing.Point(257, 3);
            buttonExport.Name = "buttonExport";
            buttonExport.Radius = 8;
            buttonExport.ShadowDepth = 8F;
            buttonExport.Size = new System.Drawing.Size(129, 32);
            buttonExport.TabIndex = 0;
            buttonExport.Text = "Export Settings";
            buttonExport.UseVisualStyleBackColor = true;
            buttonExport.Click += buttonExport_Click;
            // 
            // buttonImport
            // 
            buttonImport.Color = System.Drawing.Color.Transparent;
            buttonImport.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 162);
            buttonImport.Location = new System.Drawing.Point(122, 3);
            buttonImport.Name = "buttonImport";
            buttonImport.Radius = 8;
            buttonImport.ShadowDepth = 8F;
            buttonImport.Size = new System.Drawing.Size(129, 32);
            buttonImport.TabIndex = 0;
            buttonImport.Text = "Import Settings";
            buttonImport.UseVisualStyleBackColor = true;
            buttonImport.Click += buttonImport_Click;
            // 
            // groups
            // 
            groups.Dock = System.Windows.Forms.DockStyle.Fill;
            groups.Location = new System.Drawing.Point(10, 10);
            groups.Name = "groups";
            groups.Padding = new System.Windows.Forms.Padding(0, 30, 0, 0);
            groups.RenderNewPageButton = true;
            groups.RenderPageClose = true;
            groups.RenderPageIcon = true;
            groups.SelectedIndex = -1;
            groups.Size = new System.Drawing.Size(950, 459);
            groups.TabIndex = 2;
            groups.NewPageButtonClicked += groups_NewPageButtonClicked;
            groups.ClosePageButtonClicked += groups_ClosePageButtonClicked;
            // 
            // contextMenuConnectionItem
            // 
            contextMenuConnectionItem.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 162);
            contextMenuConnectionItem.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { moveToGroupMenuItem });
            contextMenuConnectionItem.Name = "contextMenuConnectionItem";
            contextMenuConnectionItem.Size = new System.Drawing.Size(169, 26);
            // 
            // moveToGroupMenuItem
            // 
            moveToGroupMenuItem.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            moveToGroupMenuItem.Name = "moveToGroupMenuItem";
            moveToGroupMenuItem.Size = new System.Drawing.Size(168, 22);
            moveToGroupMenuItem.Text = "Move To Group";
            // 
            // panel2
            // 
            panel2.Controls.Add(groups);
            panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            panel2.Location = new System.Drawing.Point(0, 40);
            panel2.Name = "panel2";
            panel2.Padding = new System.Windows.Forms.Padding(10);
            panel2.Size = new System.Drawing.Size(970, 479);
            panel2.TabIndex = 3;
            // 
            // Connections
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(panel2);
            Controls.Add(panel1);
            Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            Name = "Connections";
            Size = new System.Drawing.Size(970, 519);
            panel1.ResumeLayout(false);
            contextMenuConnectionItem.ResumeLayout(false);
            panel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private SDUI.Controls.Button buttonNewConnect;
        private System.Windows.Forms.Panel panel1;
        private SDUI.Controls.Button buttonImport;
        private SDUI.Controls.Button buttonExport;
        private ConnectionGroups groups;
        private SDUI.Controls.ContextMenuStrip contextMenuConnectionItem;
        private System.Windows.Forms.ToolStripMenuItem moveToGroupMenuItem;
        private SDUI.Controls.Separator separator1;
        private System.Windows.Forms.Panel panel2;
    }
}

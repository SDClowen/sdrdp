namespace SDRdp
{
    partial class ConnectionHistory
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
            panel = new System.Windows.Forms.Panel();
            buttonNewConnect = new SDUI.Controls.Button();
            flowLayoutPanel.SuspendLayout();
            panel.SuspendLayout();
            SuspendLayout();
            // 
            // flowLayoutPanel
            // 
            flowLayoutPanel.Controls.Add(panel);
            flowLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            flowLayoutPanel.Location = new System.Drawing.Point(0, 0);
            flowLayoutPanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            flowLayoutPanel.Name = "flowLayoutPanel";
            flowLayoutPanel.Padding = new System.Windows.Forms.Padding(10, 9, 10, 9);
            flowLayoutPanel.Size = new System.Drawing.Size(970, 519);
            flowLayoutPanel.TabIndex = 0;
            // 
            // panel
            // 
            panel.Controls.Add(buttonNewConnect);
            flowLayoutPanel.SetFlowBreak(panel, true);
            panel.Location = new System.Drawing.Point(13, 11);
            panel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            panel.Name = "panel";
            panel.Size = new System.Drawing.Size(84, 181);
            panel.TabIndex = 0;
            // 
            // buttonNewConnect
            // 
            buttonNewConnect.Color = System.Drawing.Color.DodgerBlue;
            buttonNewConnect.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 162);
            buttonNewConnect.ForeColor = System.Drawing.Color.White;
            buttonNewConnect.Location = new System.Drawing.Point(3, 63);
            buttonNewConnect.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            buttonNewConnect.Name = "buttonNewConnect";
            buttonNewConnect.Radius = 32;
            buttonNewConnect.ShadowDepth = 4F;
            buttonNewConnect.Size = new System.Drawing.Size(77, 54);
            buttonNewConnect.TabIndex = 0;
            buttonNewConnect.Text = "";
            buttonNewConnect.UseVisualStyleBackColor = true;
            buttonNewConnect.Click += buttonNewConnect_Click;
            // 
            // ConnectionHistory
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(flowLayoutPanel);
            Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            Name = "ConnectionHistory";
            Size = new System.Drawing.Size(970, 519);
            Load += ConnectionHistory_Load;
            flowLayoutPanel.ResumeLayout(false);
            panel.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel;
        private System.Windows.Forms.Panel panel;
        private SDUI.Controls.Button buttonNewConnect;
    }
}

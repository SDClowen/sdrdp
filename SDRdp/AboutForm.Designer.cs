namespace SDRdp
{
    partial class AboutForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutForm));
            label1 = new SDUI.Controls.Label();
            label2 = new SDUI.Controls.Label();
            label3 = new SDUI.Controls.Label();
            panel1 = new SDUI.Controls.Panel();
            richTextBox1 = new System.Windows.Forms.RichTextBox();
            buttonGithub = new SDUI.Controls.Button();
            buttonBuymeacoffee = new SDUI.Controls.Button();
            buttonPatreon = new SDUI.Controls.Button();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.ApplyGradient = true;
            label1.AutoSize = true;
            label1.BackColor = System.Drawing.Color.Transparent;
            label1.Font = new System.Drawing.Font("Segoe UI Black", 80.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 162);
            label1.Gradient = new System.Drawing.Color[]
    {
    System.Drawing.Color.FromArgb(0, 192, 192),
    System.Drawing.Color.MidnightBlue
    };
            label1.GradientAnimation = false;
            label1.Location = new System.Drawing.Point(109, 32);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(413, 142);
            label1.TabIndex = 0;
            label1.Text = "SDRdp";
            // 
            // label2
            // 
            label2.ApplyGradient = true;
            label2.AutoSize = true;
            label2.BackColor = System.Drawing.Color.Transparent;
            label2.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 162);
            label2.Gradient = new System.Drawing.Color[]
    {
    System.Drawing.Color.Gray,
    System.Drawing.Color.DarkGray
    };
            label2.GradientAnimation = false;
            label2.Location = new System.Drawing.Point(130, 174);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(278, 20);
            label2.TabIndex = 1;
            label2.Text = "Easy-to-use remote connection manager";
            // 
            // label3
            // 
            label3.ApplyGradient = false;
            label3.AutoSize = true;
            label3.BackColor = System.Drawing.Color.Transparent;
            label3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 162);
            label3.Gradient = new System.Drawing.Color[]
    {
    System.Drawing.Color.Gray,
    System.Drawing.Color.Black
    };
            label3.GradientAnimation = false;
            label3.Location = new System.Drawing.Point(481, 32);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(41, 17);
            label3.TabIndex = 2;
            label3.Text = "v1.0.0";
            // 
            // panel1
            // 
            panel1.BackColor = System.Drawing.Color.Transparent;
            panel1.Border = new System.Windows.Forms.Padding(0, 0, 0, 0);
            panel1.BorderColor = System.Drawing.Color.Transparent;
            panel1.Controls.Add(richTextBox1);
            panel1.Location = new System.Drawing.Point(90, 197);
            panel1.Name = "panel1";
            panel1.Padding = new System.Windows.Forms.Padding(5);
            panel1.Radius = 14;
            panel1.ShadowDepth = 12F;
            panel1.Size = new System.Drawing.Size(456, 164);
            panel1.TabIndex = 3;
            // 
            // richTextBox1
            // 
            richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            richTextBox1.Location = new System.Drawing.Point(5, 5);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new System.Drawing.Size(446, 154);
            richTextBox1.TabIndex = 4;
            richTextBox1.Text = resources.GetString("richTextBox1.Text");
            // 
            // buttonGithub
            // 
            buttonGithub.Color = System.Drawing.Color.Black;
            buttonGithub.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 162);
            buttonGithub.ForeColor = System.Drawing.Color.White;
            buttonGithub.Location = new System.Drawing.Point(90, 367);
            buttonGithub.Name = "buttonGithub";
            buttonGithub.Radius = 6;
            buttonGithub.ShadowDepth = 4F;
            buttonGithub.Size = new System.Drawing.Size(132, 36);
            buttonGithub.TabIndex = 4;
            buttonGithub.Text = "Github Sponsor";
            buttonGithub.UseVisualStyleBackColor = true;
            buttonGithub.Click += buttonGithub_Click;
            // 
            // buttonBuymeacoffee
            // 
            buttonBuymeacoffee.Color = System.Drawing.Color.Yellow;
            buttonBuymeacoffee.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 162);
            buttonBuymeacoffee.Location = new System.Drawing.Point(228, 367);
            buttonBuymeacoffee.Name = "buttonBuymeacoffee";
            buttonBuymeacoffee.Radius = 6;
            buttonBuymeacoffee.ShadowDepth = 4F;
            buttonBuymeacoffee.Size = new System.Drawing.Size(180, 36);
            buttonBuymeacoffee.TabIndex = 4;
            buttonBuymeacoffee.Text = "Buymeacoffee";
            buttonBuymeacoffee.UseVisualStyleBackColor = true;
            buttonBuymeacoffee.Click += buttonBuymeacoffee_Click;
            // 
            // buttonPatreon
            // 
            buttonPatreon.Color = System.Drawing.Color.IndianRed;
            buttonPatreon.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 162);
            buttonPatreon.ForeColor = System.Drawing.Color.White;
            buttonPatreon.Location = new System.Drawing.Point(414, 367);
            buttonPatreon.Name = "buttonPatreon";
            buttonPatreon.Radius = 6;
            buttonPatreon.ShadowDepth = 4F;
            buttonPatreon.Size = new System.Drawing.Size(132, 36);
            buttonPatreon.TabIndex = 4;
            buttonPatreon.Text = "Patreon";
            buttonPatreon.UseVisualStyleBackColor = true;
            buttonPatreon.Click += buttonPatreon_Click;
            // 
            // AboutForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            ClientSize = new System.Drawing.Size(631, 418);
            Controls.Add(buttonPatreon);
            Controls.Add(buttonBuymeacoffee);
            Controls.Add(buttonGithub);
            Controls.Add(panel1);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            DrawTitleBorder = false;
            Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 162);
            Hatch = System.Drawing.Drawing2D.HatchStyle.Horizontal;
            Location = new System.Drawing.Point(0, 0);
            MaximizeBox = false;
            MinimizeBox = false;
            Movable = false;
            Name = "AboutForm";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            panel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private SDUI.Controls.Label label1;
        private SDUI.Controls.Label label2;
        private SDUI.Controls.Label label3;
        private SDUI.Controls.Panel panel1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private SDUI.Controls.Button buttonGithub;
        private SDUI.Controls.Button buttonBuymeacoffee;
        private SDUI.Controls.Button buttonPatreon;
    }
}
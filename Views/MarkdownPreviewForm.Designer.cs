namespace Lab_6
{
    partial class MarkdownPreviewForm
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
            this.HeaderPanel = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.FileNameLabel = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.CloseWindowButton = new System.Windows.Forms.Button();
            this.markdownPreviewBrowser = new System.Windows.Forms.WebBrowser();
            this.HeaderPanel.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // HeaderPanel
            // 
            this.HeaderPanel.Controls.Add(this.panel4);
            this.HeaderPanel.Controls.Add(this.panel2);
            this.HeaderPanel.Controls.Add(this.CloseWindowButton);
            this.HeaderPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.HeaderPanel.Location = new System.Drawing.Point(4, 0);
            this.HeaderPanel.Margin = new System.Windows.Forms.Padding(0);
            this.HeaderPanel.Name = "HeaderPanel";
            this.HeaderPanel.Size = new System.Drawing.Size(883, 30);
            this.HeaderPanel.TabIndex = 1;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.FileNameLabel);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(853, 30);
            this.panel4.TabIndex = 4;
            // 
            // FileNameLabel
            // 
            this.FileNameLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FileNameLabel.Font = new System.Drawing.Font("Microsoft JhengHei UI Light", 10F);
            this.FileNameLabel.Location = new System.Drawing.Point(0, 0);
            this.FileNameLabel.Margin = new System.Windows.Forms.Padding(0);
            this.FileNameLabel.Name = "FileNameLabel";
            this.FileNameLabel.Size = new System.Drawing.Size(853, 30);
            this.FileNameLabel.TabIndex = 3;
            this.FileNameLabel.Text = "Markdown Preview";
            this.FileNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.FileNameLabel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.WindowDrag);
            // 
            // panel2
            // 
            this.panel2.AutoSize = true;
            this.panel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(0, 30);
            this.panel2.TabIndex = 7;
            // 
            // CloseWindowButton
            // 
            this.CloseWindowButton.BackColor = System.Drawing.Color.Transparent;
            this.CloseWindowButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.CloseWindowButton.FlatAppearance.BorderSize = 0;
            this.CloseWindowButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(112)))), ((int)(((byte)(122)))));
            this.CloseWindowButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(17)))), ((int)(((byte)(35)))));
            this.CloseWindowButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CloseWindowButton.Font = new System.Drawing.Font("Microsoft JhengHei UI Light", 12F);
            this.CloseWindowButton.Location = new System.Drawing.Point(853, 0);
            this.CloseWindowButton.Margin = new System.Windows.Forms.Padding(0);
            this.CloseWindowButton.Name = "CloseWindowButton";
            this.CloseWindowButton.Size = new System.Drawing.Size(30, 30);
            this.CloseWindowButton.TabIndex = 0;
            this.CloseWindowButton.Text = "X";
            this.CloseWindowButton.UseVisualStyleBackColor = false;
            this.CloseWindowButton.Click += new System.EventHandler(this.CloseWindowButton_Click);
            // 
            // markdownPreviewBrowser
            // 
            this.markdownPreviewBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.markdownPreviewBrowser.Location = new System.Drawing.Point(4, 30);
            this.markdownPreviewBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.markdownPreviewBrowser.Name = "markdownPreviewBrowser";
            this.markdownPreviewBrowser.Size = new System.Drawing.Size(883, 475);
            this.markdownPreviewBrowser.TabIndex = 2;
            // 
            // MarkdownPreviewForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(203)))));
            this.ClientSize = new System.Drawing.Size(891, 509);
            this.Controls.Add(this.markdownPreviewBrowser);
            this.Controls.Add(this.HeaderPanel);
            this.Font = new System.Drawing.Font("Microsoft JhengHei UI Light", 10F);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(600, 500);
            this.Name = "MarkdownPreviewForm";
            this.Padding = new System.Windows.Forms.Padding(4, 0, 4, 4);
            this.HeaderPanel.ResumeLayout(false);
            this.HeaderPanel.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel HeaderPanel;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label FileNameLabel;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button CloseWindowButton;
        private System.Windows.Forms.WebBrowser markdownPreviewBrowser;
    }
}
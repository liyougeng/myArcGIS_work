namespace Task1ForBasicLoad
{
    partial class welcome
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(welcome));
            this.StateProgressBar = new System.Windows.Forms.ProgressBar();
            this.MyTimer = new System.Windows.Forms.Timer(this.components);
            this.Marquen = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // StateProgressBar
            // 
            this.StateProgressBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.StateProgressBar.Location = new System.Drawing.Point(0, 560);
            this.StateProgressBar.Name = "StateProgressBar";
            this.StateProgressBar.Size = new System.Drawing.Size(976, 23);
            this.StateProgressBar.TabIndex = 0;
            // 
            // MyTimer
            // 
            this.MyTimer.Tick += new System.EventHandler(this.MyTimer_Tick);
            // 
            // Marquen
            // 
            this.Marquen.AutoSize = true;
            this.Marquen.Location = new System.Drawing.Point(729, 556);
            this.Marquen.Name = "Marquen";
            this.Marquen.Size = new System.Drawing.Size(77, 12);
            this.Marquen.TabIndex = 1;
            this.Marquen.Text = "Powerd by Cz";
            // 
            // welcome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(976, 583);
            this.Controls.Add(this.Marquen);
            this.Controls.Add(this.StateProgressBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "welcome";
            this.Opacity = 0.5D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "welcome";
            this.TopMost = true;
            this.TransparencyKey = System.Drawing.Color.Green;
            this.Load += new System.EventHandler(this.welcome_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar StateProgressBar;
        private System.Windows.Forms.Timer MyTimer;
        private System.Windows.Forms.Label Marquen;
    }
}
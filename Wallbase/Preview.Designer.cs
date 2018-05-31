namespace Wallbase
{
    partial class Preview
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
            this.wallpaper = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.wallpaper)).BeginInit();
            this.SuspendLayout();
            // 
            // wallpaper
            // 
            this.wallpaper.BackColor = System.Drawing.Color.Black;
            this.wallpaper.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wallpaper.Location = new System.Drawing.Point(0, 0);
            this.wallpaper.Name = "wallpaper";
            this.wallpaper.Size = new System.Drawing.Size(650, 436);
            this.wallpaper.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.wallpaper.TabIndex = 0;
            this.wallpaper.TabStop = false;
            this.wallpaper.LoadCompleted += new System.ComponentModel.AsyncCompletedEventHandler(this.wallpaper_LoadCompleted);
            // 
            // Preview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(650, 436);
            this.Controls.Add(this.wallpaper);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MinimizeBox = false;
            this.Name = "Preview";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Preview";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.wallpaper)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.PictureBox wallpaper;

    }
}
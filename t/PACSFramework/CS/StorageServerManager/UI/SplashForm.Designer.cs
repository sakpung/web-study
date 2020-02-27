namespace Leadtools.Demos.StorageServer
{
   partial class SplashForm
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
         this.progressBar = new System.Windows.Forms.ProgressBar();
         this.pictureBoxBitmap = new System.Windows.Forms.PictureBox();
         ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBitmap)).BeginInit();
         this.SuspendLayout();
         // 
         // progressBar
         // 
         this.progressBar.Dock = System.Windows.Forms.DockStyle.Bottom;
         this.progressBar.Location = new System.Drawing.Point(0, 358);
         this.progressBar.Name = "progressBar";
         this.progressBar.Size = new System.Drawing.Size(532, 23);
         this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
         this.progressBar.TabIndex = 0;
         // 
         // pictureBoxBitmap
         // 
         this.pictureBoxBitmap.Dock = System.Windows.Forms.DockStyle.Fill;
         this.pictureBoxBitmap.Image = global::Leadtools.Demos.StorageServer.Properties.Resources.splash_screen;
         this.pictureBoxBitmap.Location = new System.Drawing.Point(0, 0);
         this.pictureBoxBitmap.Name = "pictureBoxBitmap";
         this.pictureBoxBitmap.Size = new System.Drawing.Size(532, 358);
         this.pictureBoxBitmap.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
         this.pictureBoxBitmap.TabIndex = 1;
         this.pictureBoxBitmap.TabStop = false;
         // 
         // SplashForm
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(532, 381);
         this.Controls.Add(this.pictureBoxBitmap);
         this.Controls.Add(this.progressBar);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
         this.Name = "SplashForm";
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
         this.Text = "SplashForm";
         this.Shown += new System.EventHandler(this.SplashForm_Shown);
         ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBitmap)).EndInit();
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.ProgressBar progressBar;
      private System.Windows.Forms.PictureBox pictureBoxBitmap;
   }
}
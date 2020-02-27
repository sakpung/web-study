namespace SharePointDemo
{
   partial class SharePointDownloadUploadDialog
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
         if(disposing && (components != null))
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
         this._busyProgressBar = new System.Windows.Forms.ProgressBar();
         this._messageLabel = new System.Windows.Forms.Label();
         this.SuspendLayout();
         // 
         // _busyProgressBar
         // 
         this._busyProgressBar.Location = new System.Drawing.Point(14, 59);
         this._busyProgressBar.MarqueeAnimationSpeed = 0;
         this._busyProgressBar.Name = "_busyProgressBar";
         this._busyProgressBar.Size = new System.Drawing.Size(401, 23);
         this._busyProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
         this._busyProgressBar.TabIndex = 4;
         // 
         // _messageLabel
         // 
         this._messageLabel.Location = new System.Drawing.Point(12, 22);
         this._messageLabel.Name = "_messageLabel";
         this._messageLabel.Size = new System.Drawing.Size(401, 23);
         this._messageLabel.TabIndex = 3;
         this._messageLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
         // 
         // SharePointDownloadUploadDialog
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(429, 98);
         this.ControlBox = false;
         this.Controls.Add(this._busyProgressBar);
         this.Controls.Add(this._messageLabel);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "SharePointDownloadUploadDialog";
         this.ShowInTaskbar = false;
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "SharePoint Demo";
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.ProgressBar _busyProgressBar;
      private System.Windows.Forms.Label _messageLabel;
   }
}
namespace SharePointDemo
{
   partial class SharePointConnectDialog
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
         this._cancelButton = new System.Windows.Forms.Button();
         this._messageLabel = new System.Windows.Forms.Label();
         this._busyProgressBar = new System.Windows.Forms.ProgressBar();
         this.SuspendLayout();
         // 
         // _cancelButton
         // 
         this._cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this._cancelButton.Location = new System.Drawing.Point(177, 102);
         this._cancelButton.Name = "_cancelButton";
         this._cancelButton.Size = new System.Drawing.Size(75, 23);
         this._cancelButton.TabIndex = 2;
         this._cancelButton.Text = "Cancel";
         this._cancelButton.UseVisualStyleBackColor = true;
         this._cancelButton.Click += new System.EventHandler(this._cancelButton_Click);
         // 
         // _messageLabel
         // 
         this._messageLabel.Location = new System.Drawing.Point(14, 25);
         this._messageLabel.Name = "_messageLabel";
         this._messageLabel.Size = new System.Drawing.Size(401, 23);
         this._messageLabel.TabIndex = 0;
         this._messageLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
         // 
         // _busyProgressBar
         // 
         this._busyProgressBar.Location = new System.Drawing.Point(14, 62);
         this._busyProgressBar.MarqueeAnimationSpeed = 0;
         this._busyProgressBar.Name = "_busyProgressBar";
         this._busyProgressBar.Size = new System.Drawing.Size(401, 23);
         this._busyProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
         this._busyProgressBar.TabIndex = 1;
         // 
         // SharePointConnectDialog
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.CancelButton = this._cancelButton;
         this.ClientSize = new System.Drawing.Size(429, 140);
         this.Controls.Add(this._busyProgressBar);
         this.Controls.Add(this._messageLabel);
         this.Controls.Add(this._cancelButton);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "SharePointConnectDialog";
         this.ShowInTaskbar = false;
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "SharePoint Demo";
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.Button _cancelButton;
      private System.Windows.Forms.Label _messageLabel;
      private System.Windows.Forms.ProgressBar _busyProgressBar;
   }
}
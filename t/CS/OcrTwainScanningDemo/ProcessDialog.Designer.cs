namespace OcrTwainScanningDemo
{
   partial class ProcessDialog
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
         this._btnCancel = new System.Windows.Forms.Button();
         this._lblProcessing = new System.Windows.Forms.Label();
         this._pbProgress = new System.Windows.Forms.ProgressBar();
         this.SuspendLayout();
         // 
         // _btnCancel
         // 
         this._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this._btnCancel.Location = new System.Drawing.Point(185, 97);
         this._btnCancel.Name = "_btnCancel";
         this._btnCancel.Size = new System.Drawing.Size(75, 23);
         this._btnCancel.TabIndex = 0;
         this._btnCancel.Text = "Cancel";
         this._btnCancel.UseVisualStyleBackColor = true;
         this._btnCancel.Click += new System.EventHandler(this._btnCancel_Click);
         // 
         // _lblProcessing
         // 
         this._lblProcessing.Location = new System.Drawing.Point(13, 13);
         this._lblProcessing.Name = "_lblProcessing";
         this._lblProcessing.Size = new System.Drawing.Size(419, 23);
         this._lblProcessing.TabIndex = 1;
         this._lblProcessing.Text = "label1";
         this._lblProcessing.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
         // 
         // _pbProgress
         // 
         this._pbProgress.Location = new System.Drawing.Point(14, 55);
         this._pbProgress.Name = "_pbProgress";
         this._pbProgress.Size = new System.Drawing.Size(416, 23);
         this._pbProgress.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
         this._pbProgress.TabIndex = 2;
         // 
         // ProcessDialog
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.CancelButton = this._btnCancel;
         this.ClientSize = new System.Drawing.Size(444, 130);
         this.Controls.Add(this._pbProgress);
         this.Controls.Add(this._lblProcessing);
         this.Controls.Add(this._btnCancel);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "ProcessDialog";
         this.ShowInTaskbar = false;
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "Processing";
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.Button _btnCancel;
      private System.Windows.Forms.Label _lblProcessing;
      private System.Windows.Forms.ProgressBar _pbProgress;
   }
}
using System;
namespace JobProcessorAdministratorDemo
{
   partial class TroubleshootingDlg
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TroubleshootingDlg));
         this._btnOK = new System.Windows.Forms.Button();
         this._chkDoNotShowAgain = new System.Windows.Forms.CheckBox();
         this._lblNotes = new System.Windows.Forms.Label();
         this.SuspendLayout();
         // 
         // _btnOK
         // 
         this._btnOK.Location = new System.Drawing.Point(323, 261);
         this._btnOK.Name = "_btnOK";
         this._btnOK.Size = new System.Drawing.Size(128, 40);
         this._btnOK.TabIndex = 0;
         this._btnOK.Text = "OK";
         this._btnOK.UseVisualStyleBackColor = true;
         this._btnOK.Click += new System.EventHandler(this._btnOK_Click);
         // 
         // _chkDoNotShowAgain
         // 
         this._chkDoNotShowAgain.AutoSize = true;
         this._chkDoNotShowAgain.Location = new System.Drawing.Point(32, 274);
         this._chkDoNotShowAgain.Name = "_chkDoNotShowAgain";
         this._chkDoNotShowAgain.Size = new System.Drawing.Size(179, 17);
         this._chkDoNotShowAgain.TabIndex = 1;
         this._chkDoNotShowAgain.Text = "Do not show this message again";
         this._chkDoNotShowAgain.UseVisualStyleBackColor = true;
         // 
         // _lblNotes
         // 
         this._lblNotes.Location = new System.Drawing.Point(29, 24);
         this._lblNotes.Name = "_lblNotes";
         this._lblNotes.Size = new System.Drawing.Size(700, 224);
         this._lblNotes.TabIndex = 2;
         this._lblNotes.Text = resources.GetString("_lblNotes.Text");
         // 
         // TroubleshootingDlg
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(760, 305);
         this.Controls.Add(this._lblNotes);
         this.Controls.Add(this._chkDoNotShowAgain);
         this.Controls.Add(this._btnOK);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
         this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
         this.MaximizeBox = false;
         this.Name = "TroubleshootingDlg";
         this.Text = "Troubleshooting";
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.Button _btnOK;
      private System.Windows.Forms.CheckBox _chkDoNotShowAgain;
      private System.Windows.Forms.Label _lblNotes;
   }
}
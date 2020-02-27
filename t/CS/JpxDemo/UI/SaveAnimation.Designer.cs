namespace JPXDemo
{
   partial class SaveAnimation
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SaveAnimation));
         this._btnSave = new System.Windows.Forms.Button();
         this._grpFile = new System.Windows.Forms.GroupBox();
         this._btnBrowse = new System.Windows.Forms.Button();
         this._txtFileName = new System.Windows.Forms.TextBox();
         this._lblFileName = new System.Windows.Forms.Label();
         this._grpFile.SuspendLayout();
         this.SuspendLayout();
         // 
         // _btnSave
         // 
         this._btnSave.Location = new System.Drawing.Point(166, 80);
         this._btnSave.Name = "_btnSave";
         this._btnSave.Size = new System.Drawing.Size(75, 23);
         this._btnSave.TabIndex = 0;
         this._btnSave.Text = "&Save";
         this._btnSave.UseVisualStyleBackColor = true;
         this._btnSave.Click += new System.EventHandler(this._btnSave_Click);
         // 
         // _grpFile
         // 
         this._grpFile.Controls.Add(this._btnBrowse);
         this._grpFile.Controls.Add(this._txtFileName);
         this._grpFile.Controls.Add(this._lblFileName);
         this._grpFile.Location = new System.Drawing.Point(4, 5);
         this._grpFile.Name = "_grpFile";
         this._grpFile.Size = new System.Drawing.Size(399, 69);
         this._grpFile.TabIndex = 2;
         this._grpFile.TabStop = false;
         this._grpFile.Text = "File";
         // 
         // _btnBrowse
         // 
         this._btnBrowse.Location = new System.Drawing.Point(318, 35);
         this._btnBrowse.Name = "_btnBrowse";
         this._btnBrowse.Size = new System.Drawing.Size(75, 23);
         this._btnBrowse.TabIndex = 2;
         this._btnBrowse.Text = "&Browse";
         this._btnBrowse.UseVisualStyleBackColor = true;
         this._btnBrowse.Click += new System.EventHandler(this._btnBrowse_Click);
         // 
         // _txtFileName
         // 
         this._txtFileName.Location = new System.Drawing.Point(6, 37);
         this._txtFileName.Name = "_txtFileName";
         this._txtFileName.Size = new System.Drawing.Size(306, 20);
         this._txtFileName.TabIndex = 1;
         // 
         // _lblFileName
         // 
         this._lblFileName.AutoSize = true;
         this._lblFileName.Location = new System.Drawing.Point(8, 16);
         this._lblFileName.Name = "_lblFileName";
         this._lblFileName.Size = new System.Drawing.Size(116, 13);
         this._lblFileName.TabIndex = 0;
         this._lblFileName.Text = "Select JPEG 2000 File:";
         // 
         // SaveAnimation
         // 
         this.AcceptButton = this._btnSave;
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(407, 106);
         this.Controls.Add(this._grpFile);
         this.Controls.Add(this._btnSave);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "SaveAnimation";
         this.ShowInTaskbar = false;
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "Save Animation";
         this._grpFile.ResumeLayout(false);
         this._grpFile.PerformLayout();
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.Button _btnSave;
      private System.Windows.Forms.GroupBox _grpFile;
      private System.Windows.Forms.Button _btnBrowse;
      private System.Windows.Forms.TextBox _txtFileName;
      private System.Windows.Forms.Label _lblFileName;
   }
}
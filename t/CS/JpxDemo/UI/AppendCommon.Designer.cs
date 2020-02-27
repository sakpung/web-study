namespace JPXDemo
{
   partial class AppendCommon
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AppendCommon));
         this._grpFile = new System.Windows.Forms.GroupBox();
         this._lblJPEG2000 = new System.Windows.Forms.Label();
         this._txtJPEG2000 = new System.Windows.Forms.TextBox();
         this._btnJPEG2000Browse = new System.Windows.Forms.Button();
         this._grpData = new System.Windows.Forms.GroupBox();
         this._lblFilterType = new System.Windows.Forms.Label();
         this._cbFilterType = new System.Windows.Forms.ComboBox();
         this._lblSecond = new System.Windows.Forms.Label();
         this._txtSecond = new System.Windows.Forms.TextBox();
         this._btnSecondBrowse = new System.Windows.Forms.Button();
         this._btnOk = new System.Windows.Forms.Button();
         this._btnCancel = new System.Windows.Forms.Button();
         this._grpFile.SuspendLayout();
         this._grpData.SuspendLayout();
         this.SuspendLayout();
         // 
         // _grpFile
         // 
         this._grpFile.Controls.Add(this._lblJPEG2000);
         this._grpFile.Controls.Add(this._txtJPEG2000);
         this._grpFile.Controls.Add(this._btnJPEG2000Browse);
         this._grpFile.Location = new System.Drawing.Point(5, 2);
         this._grpFile.Name = "_grpFile";
         this._grpFile.Size = new System.Drawing.Size(386, 72);
         this._grpFile.TabIndex = 0;
         this._grpFile.TabStop = false;
         this._grpFile.Text = "File";
         // 
         // _lblJPEG2000
         // 
         this._lblJPEG2000.AutoSize = true;
         this._lblJPEG2000.Location = new System.Drawing.Point(10, 21);
         this._lblJPEG2000.Name = "_lblJPEG2000";
         this._lblJPEG2000.Size = new System.Drawing.Size(104, 13);
         this._lblJPEG2000.TabIndex = 0;
         this._lblJPEG2000.Text = "Select JP2/JPX File:";
         // 
         // _txtJPEG2000
         // 
         this._txtJPEG2000.Location = new System.Drawing.Point(13, 39);
         this._txtJPEG2000.Name = "_txtJPEG2000";
         this._txtJPEG2000.Size = new System.Drawing.Size(282, 20);
         this._txtJPEG2000.TabIndex = 1;
         // 
         // _btnJPEG2000Browse
         // 
         this._btnJPEG2000Browse.Location = new System.Drawing.Point(301, 38);
         this._btnJPEG2000Browse.Name = "_btnJPEG2000Browse";
         this._btnJPEG2000Browse.Size = new System.Drawing.Size(75, 23);
         this._btnJPEG2000Browse.TabIndex = 2;
         this._btnJPEG2000Browse.Text = "Browse";
         this._btnJPEG2000Browse.UseVisualStyleBackColor = true;
         this._btnJPEG2000Browse.Click += new System.EventHandler(this._btnFirstBrowse_Click);
         // 
         // _grpData
         // 
         this._grpData.Controls.Add(this._lblFilterType);
         this._grpData.Controls.Add(this._cbFilterType);
         this._grpData.Controls.Add(this._lblSecond);
         this._grpData.Controls.Add(this._txtSecond);
         this._grpData.Controls.Add(this._btnSecondBrowse);
         this._grpData.Location = new System.Drawing.Point(5, 80);
         this._grpData.Name = "_grpData";
         this._grpData.Size = new System.Drawing.Size(386, 99);
         this._grpData.TabIndex = 1;
         this._grpData.TabStop = false;
         this._grpData.Text = "Data";
         // 
         // _lblFilterType
         // 
         this._lblFilterType.AutoSize = true;
         this._lblFilterType.Location = new System.Drawing.Point(10, 22);
         this._lblFilterType.Name = "_lblFilterType";
         this._lblFilterType.Size = new System.Drawing.Size(56, 13);
         this._lblFilterType.TabIndex = 0;
         this._lblFilterType.Text = "Filter Type";
         // 
         // _cbFilterType
         // 
         this._cbFilterType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this._cbFilterType.FormattingEnabled = true;
         this._cbFilterType.Location = new System.Drawing.Point(72, 19);
         this._cbFilterType.Name = "_cbFilterType";
         this._cbFilterType.Size = new System.Drawing.Size(164, 21);
         this._cbFilterType.TabIndex = 1;
         // 
         // _lblSecond
         // 
         this._lblSecond.AutoSize = true;
         this._lblSecond.Location = new System.Drawing.Point(10, 49);
         this._lblSecond.Name = "_lblSecond";
         this._lblSecond.Size = new System.Drawing.Size(35, 13);
         this._lblSecond.TabIndex = 2;
         this._lblSecond.Text = "label1";
         // 
         // _txtSecond
         // 
         this._txtSecond.Location = new System.Drawing.Point(13, 67);
         this._txtSecond.Name = "_txtSecond";
         this._txtSecond.Size = new System.Drawing.Size(282, 20);
         this._txtSecond.TabIndex = 3;
         // 
         // _btnSecondBrowse
         // 
         this._btnSecondBrowse.Location = new System.Drawing.Point(301, 66);
         this._btnSecondBrowse.Name = "_btnSecondBrowse";
         this._btnSecondBrowse.Size = new System.Drawing.Size(75, 23);
         this._btnSecondBrowse.TabIndex = 4;
         this._btnSecondBrowse.Text = "Browse";
         this._btnSecondBrowse.UseVisualStyleBackColor = true;
         this._btnSecondBrowse.Click += new System.EventHandler(this._btnSecondBrowse_Click);
         // 
         // _btnOk
         // 
         this._btnOk.Location = new System.Drawing.Point(122, 185);
         this._btnOk.Name = "_btnOk";
         this._btnOk.Size = new System.Drawing.Size(75, 23);
         this._btnOk.TabIndex = 2;
         this._btnOk.Text = "Ok";
         this._btnOk.UseVisualStyleBackColor = true;
         this._btnOk.Click += new System.EventHandler(this._btnOk_Click);
         // 
         // _btnCancel
         // 
         this._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this._btnCancel.Location = new System.Drawing.Point(203, 185);
         this._btnCancel.Name = "_btnCancel";
         this._btnCancel.Size = new System.Drawing.Size(75, 23);
         this._btnCancel.TabIndex = 3;
         this._btnCancel.Text = "Cancel";
         this._btnCancel.UseVisualStyleBackColor = true;
         // 
         // AppendCommon
         // 
         this.AcceptButton = this._btnOk;
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.CancelButton = this._btnCancel;
         this.ClientSize = new System.Drawing.Size(400, 213);
         this.Controls.Add(this._btnCancel);
         this.Controls.Add(this._btnOk);
         this.Controls.Add(this._grpData);
         this.Controls.Add(this._grpFile);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "AppendCommon";
         this.ShowInTaskbar = false;
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "AppendCommon";
         this._grpFile.ResumeLayout(false);
         this._grpFile.PerformLayout();
         this._grpData.ResumeLayout(false);
         this._grpData.PerformLayout();
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.GroupBox _grpFile;
      private System.Windows.Forms.Label _lblJPEG2000;
      private System.Windows.Forms.TextBox _txtJPEG2000;
      private System.Windows.Forms.Button _btnJPEG2000Browse;
      private System.Windows.Forms.GroupBox _grpData;
      private System.Windows.Forms.Label _lblSecond;
      private System.Windows.Forms.TextBox _txtSecond;
      private System.Windows.Forms.Button _btnSecondBrowse;
      private System.Windows.Forms.Button _btnOk;
      private System.Windows.Forms.Button _btnCancel;
      private System.Windows.Forms.Label _lblFilterType;
      private System.Windows.Forms.ComboBox _cbFilterType;
   }
}
namespace JPXDemo
{
   partial class ReadDigitalSignature
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReadDigitalSignature));
         this._nudBoxIndex = new System.Windows.Forms.NumericUpDown();
         this._grpBoxIndex = new System.Windows.Forms.GroupBox();
         this._btnJPEG2000Browse = new System.Windows.Forms.Button();
         this._grpType = new System.Windows.Forms.GroupBox();
         this._lblLength = new System.Windows.Forms.Label();
         this._txtLength = new System.Windows.Forms.TextBox();
         this._lblPointerType = new System.Windows.Forms.Label();
         this._txtPointerType = new System.Windows.Forms.TextBox();
         this._lblOffset = new System.Windows.Forms.Label();
         this._txtOffset = new System.Windows.Forms.TextBox();
         this._lblSignatureType = new System.Windows.Forms.Label();
         this._txtSignatureType = new System.Windows.Forms.TextBox();
         this._btnRead = new System.Windows.Forms.Button();
         this._txtJPEG2000 = new System.Windows.Forms.TextBox();
         this._txtDataFile = new System.Windows.Forms.TextBox();
         this._lblDataFile = new System.Windows.Forms.Label();
         this._grpData = new System.Windows.Forms.GroupBox();
         this._btnDataFileBrowse = new System.Windows.Forms.Button();
         this._lblJPEG2000 = new System.Windows.Forms.Label();
         this._grpFile = new System.Windows.Forms.GroupBox();
         ((System.ComponentModel.ISupportInitialize)(this._nudBoxIndex)).BeginInit();
         this._grpBoxIndex.SuspendLayout();
         this._grpType.SuspendLayout();
         this._grpData.SuspendLayout();
         this._grpFile.SuspendLayout();
         this.SuspendLayout();
         // 
         // _nudBoxIndex
         // 
         this._nudBoxIndex.Location = new System.Drawing.Point(62, 30);
         this._nudBoxIndex.Name = "_nudBoxIndex";
         this._nudBoxIndex.Size = new System.Drawing.Size(117, 20);
         this._nudBoxIndex.TabIndex = 0;
         // 
         // _grpBoxIndex
         // 
         this._grpBoxIndex.Controls.Add(this._nudBoxIndex);
         this._grpBoxIndex.Location = new System.Drawing.Point(5, 247);
         this._grpBoxIndex.Name = "_grpBoxIndex";
         this._grpBoxIndex.Size = new System.Drawing.Size(241, 67);
         this._grpBoxIndex.TabIndex = 8;
         this._grpBoxIndex.TabStop = false;
         this._grpBoxIndex.Text = "Box Index - 0 based";
         // 
         // _btnJPEG2000Browse
         // 
         this._btnJPEG2000Browse.Location = new System.Drawing.Point(251, 37);
         this._btnJPEG2000Browse.Name = "_btnJPEG2000Browse";
         this._btnJPEG2000Browse.Size = new System.Drawing.Size(75, 23);
         this._btnJPEG2000Browse.TabIndex = 2;
         this._btnJPEG2000Browse.Text = "Browse";
         this._btnJPEG2000Browse.UseVisualStyleBackColor = true;
         this._btnJPEG2000Browse.Click += new System.EventHandler(this._btnJPEG2000Browse_Click);
         // 
         // _grpType
         // 
         this._grpType.Controls.Add(this._lblLength);
         this._grpType.Controls.Add(this._txtLength);
         this._grpType.Controls.Add(this._lblPointerType);
         this._grpType.Controls.Add(this._txtPointerType);
         this._grpType.Controls.Add(this._lblOffset);
         this._grpType.Controls.Add(this._txtOffset);
         this._grpType.Controls.Add(this._lblSignatureType);
         this._grpType.Controls.Add(this._txtSignatureType);
         this._grpType.Location = new System.Drawing.Point(5, 153);
         this._grpType.Name = "_grpType";
         this._grpType.Size = new System.Drawing.Size(330, 88);
         this._grpType.TabIndex = 7;
         this._grpType.TabStop = false;
         this._grpType.Text = "Type";
         // 
         // _lblLength
         // 
         this._lblLength.AutoSize = true;
         this._lblLength.Location = new System.Drawing.Point(180, 58);
         this._lblLength.Name = "_lblLength";
         this._lblLength.Size = new System.Drawing.Size(43, 13);
         this._lblLength.TabIndex = 7;
         this._lblLength.Text = "Length:";
         // 
         // _txtLength
         // 
         this._txtLength.Location = new System.Drawing.Point(251, 58);
         this._txtLength.Name = "_txtLength";
         this._txtLength.ReadOnly = true;
         this._txtLength.Size = new System.Drawing.Size(71, 20);
         this._txtLength.TabIndex = 6;
         // 
         // _lblPointerType
         // 
         this._lblPointerType.AutoSize = true;
         this._lblPointerType.Location = new System.Drawing.Point(180, 22);
         this._lblPointerType.Name = "_lblPointerType";
         this._lblPointerType.Size = new System.Drawing.Size(70, 13);
         this._lblPointerType.TabIndex = 5;
         this._lblPointerType.Text = "Pointer Type:";
         // 
         // _txtPointerType
         // 
         this._txtPointerType.Location = new System.Drawing.Point(251, 19);
         this._txtPointerType.Name = "_txtPointerType";
         this._txtPointerType.ReadOnly = true;
         this._txtPointerType.Size = new System.Drawing.Size(71, 20);
         this._txtPointerType.TabIndex = 4;
         // 
         // _lblOffset
         // 
         this._lblOffset.AutoSize = true;
         this._lblOffset.Location = new System.Drawing.Point(10, 58);
         this._lblOffset.Name = "_lblOffset";
         this._lblOffset.Size = new System.Drawing.Size(38, 13);
         this._lblOffset.TabIndex = 3;
         this._lblOffset.Text = "Offset:";
         // 
         // _txtOffset
         // 
         this._txtOffset.Location = new System.Drawing.Point(95, 55);
         this._txtOffset.Name = "_txtOffset";
         this._txtOffset.ReadOnly = true;
         this._txtOffset.Size = new System.Drawing.Size(71, 20);
         this._txtOffset.TabIndex = 2;
         // 
         // _lblSignatureType
         // 
         this._lblSignatureType.AutoSize = true;
         this._lblSignatureType.Location = new System.Drawing.Point(10, 22);
         this._lblSignatureType.Name = "_lblSignatureType";
         this._lblSignatureType.Size = new System.Drawing.Size(82, 13);
         this._lblSignatureType.TabIndex = 1;
         this._lblSignatureType.Text = "Signature Type:";
         // 
         // _txtSignatureType
         // 
         this._txtSignatureType.Location = new System.Drawing.Point(95, 19);
         this._txtSignatureType.Name = "_txtSignatureType";
         this._txtSignatureType.ReadOnly = true;
         this._txtSignatureType.Size = new System.Drawing.Size(71, 20);
         this._txtSignatureType.TabIndex = 0;
         // 
         // _btnRead
         // 
         this._btnRead.Location = new System.Drawing.Point(256, 277);
         this._btnRead.Name = "_btnRead";
         this._btnRead.Size = new System.Drawing.Size(75, 23);
         this._btnRead.TabIndex = 9;
         this._btnRead.Text = "&Read";
         this._btnRead.UseVisualStyleBackColor = true;
         this._btnRead.Click += new System.EventHandler(this._btnRead_Click);
         // 
         // _txtJPEG2000
         // 
         this._txtJPEG2000.Location = new System.Drawing.Point(13, 39);
         this._txtJPEG2000.Name = "_txtJPEG2000";
         this._txtJPEG2000.Size = new System.Drawing.Size(232, 20);
         this._txtJPEG2000.TabIndex = 1;
         // 
         // _txtDataFile
         // 
         this._txtDataFile.Location = new System.Drawing.Point(9, 36);
         this._txtDataFile.Name = "_txtDataFile";
         this._txtDataFile.Size = new System.Drawing.Size(232, 20);
         this._txtDataFile.TabIndex = 1;
         // 
         // _lblDataFile
         // 
         this._lblDataFile.AutoSize = true;
         this._lblDataFile.Location = new System.Drawing.Point(6, 18);
         this._lblDataFile.Name = "_lblDataFile";
         this._lblDataFile.Size = new System.Drawing.Size(132, 13);
         this._lblDataFile.TabIndex = 0;
         this._lblDataFile.Text = "Digital Signature Data File:";
         // 
         // _grpData
         // 
         this._grpData.Controls.Add(this._lblDataFile);
         this._grpData.Controls.Add(this._txtDataFile);
         this._grpData.Controls.Add(this._btnDataFileBrowse);
         this._grpData.Location = new System.Drawing.Point(5, 82);
         this._grpData.Name = "_grpData";
         this._grpData.Size = new System.Drawing.Size(330, 67);
         this._grpData.TabIndex = 6;
         this._grpData.TabStop = false;
         this._grpData.Text = "Data";
         // 
         // _btnDataFileBrowse
         // 
         this._btnDataFileBrowse.Location = new System.Drawing.Point(251, 34);
         this._btnDataFileBrowse.Name = "_btnDataFileBrowse";
         this._btnDataFileBrowse.Size = new System.Drawing.Size(75, 23);
         this._btnDataFileBrowse.TabIndex = 2;
         this._btnDataFileBrowse.Text = "Browse";
         this._btnDataFileBrowse.UseVisualStyleBackColor = true;
         this._btnDataFileBrowse.Click += new System.EventHandler(this._btnDataFileBrowse_Click);
         // 
         // _lblJPEG2000
         // 
         this._lblJPEG2000.AutoSize = true;
         this._lblJPEG2000.Location = new System.Drawing.Point(6, 21);
         this._lblJPEG2000.Name = "_lblJPEG2000";
         this._lblJPEG2000.Size = new System.Drawing.Size(116, 13);
         this._lblJPEG2000.TabIndex = 0;
         this._lblJPEG2000.Text = "Select JPEG 2000 File:";
         // 
         // _grpFile
         // 
         this._grpFile.Controls.Add(this._lblJPEG2000);
         this._grpFile.Controls.Add(this._txtJPEG2000);
         this._grpFile.Controls.Add(this._btnJPEG2000Browse);
         this._grpFile.Location = new System.Drawing.Point(5, 4);
         this._grpFile.Name = "_grpFile";
         this._grpFile.Size = new System.Drawing.Size(330, 72);
         this._grpFile.TabIndex = 5;
         this._grpFile.TabStop = false;
         this._grpFile.Text = "File";
         // 
         // ReadDigitalSignature
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(341, 320);
         this.Controls.Add(this._grpBoxIndex);
         this.Controls.Add(this._grpType);
         this.Controls.Add(this._btnRead);
         this.Controls.Add(this._grpData);
         this.Controls.Add(this._grpFile);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
         this.Name = "ReadDigitalSignature";
         this.Text = "Read Digital Signature Box";
         ((System.ComponentModel.ISupportInitialize)(this._nudBoxIndex)).EndInit();
         this._grpBoxIndex.ResumeLayout(false);
         this._grpType.ResumeLayout(false);
         this._grpType.PerformLayout();
         this._grpData.ResumeLayout(false);
         this._grpData.PerformLayout();
         this._grpFile.ResumeLayout(false);
         this._grpFile.PerformLayout();
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.NumericUpDown _nudBoxIndex;
      private System.Windows.Forms.GroupBox _grpBoxIndex;
      private System.Windows.Forms.Button _btnJPEG2000Browse;
      private System.Windows.Forms.GroupBox _grpType;
      private System.Windows.Forms.Label _lblLength;
      private System.Windows.Forms.TextBox _txtLength;
      private System.Windows.Forms.Label _lblPointerType;
      private System.Windows.Forms.TextBox _txtPointerType;
      private System.Windows.Forms.Label _lblOffset;
      private System.Windows.Forms.TextBox _txtOffset;
      private System.Windows.Forms.Label _lblSignatureType;
      private System.Windows.Forms.TextBox _txtSignatureType;
      private System.Windows.Forms.Button _btnRead;
      private System.Windows.Forms.TextBox _txtJPEG2000;
      private System.Windows.Forms.TextBox _txtDataFile;
      private System.Windows.Forms.Label _lblDataFile;
      private System.Windows.Forms.GroupBox _grpData;
      private System.Windows.Forms.Button _btnDataFileBrowse;
      private System.Windows.Forms.Label _lblJPEG2000;
      private System.Windows.Forms.GroupBox _grpFile;
   }
}
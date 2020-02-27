namespace JPXDemo
{
   partial class AppendDigitalSignature
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AppendDigitalSignature));
         this._lblSignatureDataFile = new System.Windows.Forms.Label();
         this._txtSignatureDataFile = new System.Windows.Forms.TextBox();
         this._btnSignatureData = new System.Windows.Forms.Button();
         this._btnCancel = new System.Windows.Forms.Button();
         this._btnOk = new System.Windows.Forms.Button();
         this._lblFirst = new System.Windows.Forms.Label();
         this._txtJPEG2000File = new System.Windows.Forms.TextBox();
         this._grpFile = new System.Windows.Forms.GroupBox();
         this._btnJPEGBrowse = new System.Windows.Forms.Button();
         this._grpData = new System.Windows.Forms.GroupBox();
         this._grpType = new System.Windows.Forms.GroupBox();
         this._cbSignatureType = new System.Windows.Forms.ComboBox();
         this._cbPointerType = new System.Windows.Forms.ComboBox();
         this._lblPointerType = new System.Windows.Forms.Label();
         this._lblSignatureType = new System.Windows.Forms.Label();
         this._grpPointerData = new System.Windows.Forms.GroupBox();
         this._nudLength = new System.Windows.Forms.NumericUpDown();
         this._nudOffset = new System.Windows.Forms.NumericUpDown();
         this._lblLength = new System.Windows.Forms.Label();
         this._lblOffset = new System.Windows.Forms.Label();
         this._grpFile.SuspendLayout();
         this._grpData.SuspendLayout();
         this._grpType.SuspendLayout();
         this._grpPointerData.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this._nudLength)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this._nudOffset)).BeginInit();
         this.SuspendLayout();
         // 
         // _lblSignatureDataFile
         // 
         this._lblSignatureDataFile.AutoSize = true;
         this._lblSignatureDataFile.Location = new System.Drawing.Point(10, 21);
         this._lblSignatureDataFile.Name = "_lblSignatureDataFile";
         this._lblSignatureDataFile.Size = new System.Drawing.Size(97, 13);
         this._lblSignatureDataFile.TabIndex = 2;
         this._lblSignatureDataFile.Text = "Signature Data File";
         // 
         // _txtSignatureDataFile
         // 
         this._txtSignatureDataFile.Location = new System.Drawing.Point(13, 39);
         this._txtSignatureDataFile.Name = "_txtSignatureDataFile";
         this._txtSignatureDataFile.Size = new System.Drawing.Size(237, 20);
         this._txtSignatureDataFile.TabIndex = 1;
         // 
         // _btnSignatureData
         // 
         this._btnSignatureData.Location = new System.Drawing.Point(256, 38);
         this._btnSignatureData.Name = "_btnSignatureData";
         this._btnSignatureData.Size = new System.Drawing.Size(75, 23);
         this._btnSignatureData.TabIndex = 0;
         this._btnSignatureData.Text = "Browse";
         this._btnSignatureData.UseVisualStyleBackColor = true;
         this._btnSignatureData.Click += new System.EventHandler(this._btnSignatureData_Click);
         // 
         // _btnCancel
         // 
         this._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this._btnCancel.Location = new System.Drawing.Point(183, 268);
         this._btnCancel.Name = "_btnCancel";
         this._btnCancel.Size = new System.Drawing.Size(75, 23);
         this._btnCancel.TabIndex = 9;
         this._btnCancel.Text = "Cancel";
         this._btnCancel.UseVisualStyleBackColor = true;
         // 
         // _btnOk
         // 
         this._btnOk.Location = new System.Drawing.Point(102, 268);
         this._btnOk.Name = "_btnOk";
         this._btnOk.Size = new System.Drawing.Size(75, 23);
         this._btnOk.TabIndex = 8;
         this._btnOk.Text = "Ok";
         this._btnOk.UseVisualStyleBackColor = true;
         this._btnOk.Click += new System.EventHandler(this._btnOk_Click);
         // 
         // _lblFirst
         // 
         this._lblFirst.AutoSize = true;
         this._lblFirst.Location = new System.Drawing.Point(10, 21);
         this._lblFirst.Name = "_lblFirst";
         this._lblFirst.Size = new System.Drawing.Size(78, 13);
         this._lblFirst.TabIndex = 2;
         this._lblFirst.Text = "Select JPX File";
         // 
         // _txtJPEG2000File
         // 
         this._txtJPEG2000File.Location = new System.Drawing.Point(13, 39);
         this._txtJPEG2000File.Name = "_txtJPEG2000File";
         this._txtJPEG2000File.Size = new System.Drawing.Size(237, 20);
         this._txtJPEG2000File.TabIndex = 1;
         // 
         // _grpFile
         // 
         this._grpFile.Controls.Add(this._lblFirst);
         this._grpFile.Controls.Add(this._txtJPEG2000File);
         this._grpFile.Controls.Add(this._btnJPEGBrowse);
         this._grpFile.Location = new System.Drawing.Point(8, 2);
         this._grpFile.Name = "_grpFile";
         this._grpFile.Size = new System.Drawing.Size(342, 72);
         this._grpFile.TabIndex = 6;
         this._grpFile.TabStop = false;
         this._grpFile.Text = "File";
         // 
         // _btnJPEGBrowse
         // 
         this._btnJPEGBrowse.Location = new System.Drawing.Point(256, 37);
         this._btnJPEGBrowse.Name = "_btnJPEGBrowse";
         this._btnJPEGBrowse.Size = new System.Drawing.Size(75, 23);
         this._btnJPEGBrowse.TabIndex = 0;
         this._btnJPEGBrowse.Text = "Browse";
         this._btnJPEGBrowse.UseVisualStyleBackColor = true;
         this._btnJPEGBrowse.Click += new System.EventHandler(this._btnJPEGBrowse_Click);
         // 
         // _grpData
         // 
         this._grpData.Controls.Add(this._lblSignatureDataFile);
         this._grpData.Controls.Add(this._txtSignatureDataFile);
         this._grpData.Controls.Add(this._btnSignatureData);
         this._grpData.Location = new System.Drawing.Point(8, 190);
         this._grpData.Name = "_grpData";
         this._grpData.Size = new System.Drawing.Size(342, 72);
         this._grpData.TabIndex = 7;
         this._grpData.TabStop = false;
         this._grpData.Text = "Data";
         // 
         // _grpType
         // 
         this._grpType.Controls.Add(this._cbSignatureType);
         this._grpType.Controls.Add(this._cbPointerType);
         this._grpType.Controls.Add(this._lblPointerType);
         this._grpType.Controls.Add(this._lblSignatureType);
         this._grpType.Location = new System.Drawing.Point(8, 80);
         this._grpType.Name = "_grpType";
         this._grpType.Size = new System.Drawing.Size(342, 50);
         this._grpType.TabIndex = 10;
         this._grpType.TabStop = false;
         this._grpType.Text = "Type";
         // 
         // _cbSignatureType
         // 
         this._cbSignatureType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this._cbSignatureType.FormattingEnabled = true;
         this._cbSignatureType.Location = new System.Drawing.Point(94, 17);
         this._cbSignatureType.Name = "_cbSignatureType";
         this._cbSignatureType.Size = new System.Drawing.Size(75, 21);
         this._cbSignatureType.TabIndex = 4;
         // 
         // _cbPointerType
         // 
         this._cbPointerType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this._cbPointerType.FormattingEnabled = true;
         this._cbPointerType.Location = new System.Drawing.Point(256, 18);
         this._cbPointerType.Name = "_cbPointerType";
         this._cbPointerType.Size = new System.Drawing.Size(75, 21);
         this._cbPointerType.TabIndex = 3;
         this._cbPointerType.SelectedIndexChanged += new System.EventHandler(this._cbPointerType_SelectedIndexChanged);
         // 
         // _lblPointerType
         // 
         this._lblPointerType.AutoSize = true;
         this._lblPointerType.Location = new System.Drawing.Point(186, 20);
         this._lblPointerType.Name = "_lblPointerType";
         this._lblPointerType.Size = new System.Drawing.Size(67, 13);
         this._lblPointerType.TabIndex = 1;
         this._lblPointerType.Text = "Pointer Type";
         // 
         // _lblSignatureType
         // 
         this._lblSignatureType.AutoSize = true;
         this._lblSignatureType.Location = new System.Drawing.Point(10, 20);
         this._lblSignatureType.Name = "_lblSignatureType";
         this._lblSignatureType.Size = new System.Drawing.Size(79, 13);
         this._lblSignatureType.TabIndex = 0;
         this._lblSignatureType.Text = "Signature Type";
         // 
         // _grpPointerData
         // 
         this._grpPointerData.Controls.Add(this._nudLength);
         this._grpPointerData.Controls.Add(this._nudOffset);
         this._grpPointerData.Controls.Add(this._lblLength);
         this._grpPointerData.Controls.Add(this._lblOffset);
         this._grpPointerData.Location = new System.Drawing.Point(8, 136);
         this._grpPointerData.Name = "_grpPointerData";
         this._grpPointerData.Size = new System.Drawing.Size(342, 48);
         this._grpPointerData.TabIndex = 11;
         this._grpPointerData.TabStop = false;
         this._grpPointerData.Text = "Pointer Data";
         // 
         // _nudLength
         // 
         this._nudLength.Location = new System.Drawing.Point(256, 18);
         this._nudLength.Name = "_nudLength";
         this._nudLength.Size = new System.Drawing.Size(75, 20);
         this._nudLength.TabIndex = 3;
         // 
         // _nudOffset
         // 
         this._nudOffset.Location = new System.Drawing.Point(95, 18);
         this._nudOffset.Name = "_nudOffset";
         this._nudOffset.Size = new System.Drawing.Size(75, 20);
         this._nudOffset.TabIndex = 2;
         // 
         // _lblLength
         // 
         this._lblLength.AutoSize = true;
         this._lblLength.Location = new System.Drawing.Point(186, 18);
         this._lblLength.Name = "_lblLength";
         this._lblLength.Size = new System.Drawing.Size(40, 13);
         this._lblLength.TabIndex = 1;
         this._lblLength.Text = "Length";
         // 
         // _lblOffset
         // 
         this._lblOffset.AutoSize = true;
         this._lblOffset.Location = new System.Drawing.Point(10, 18);
         this._lblOffset.Name = "_lblOffset";
         this._lblOffset.Size = new System.Drawing.Size(35, 13);
         this._lblOffset.TabIndex = 0;
         this._lblOffset.Text = "Offset";
         // 
         // AppendDigitalSignature
         // 
         this.AcceptButton = this._btnOk;
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.CancelButton = this._btnCancel;
         this.ClientSize = new System.Drawing.Size(358, 297);
         this.Controls.Add(this._grpPointerData);
         this.Controls.Add(this._grpType);
         this.Controls.Add(this._btnCancel);
         this.Controls.Add(this._btnOk);
         this.Controls.Add(this._grpFile);
         this.Controls.Add(this._grpData);
         this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "AppendDigitalSignature";
         this.ShowInTaskbar = false;
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "Digital Signature";
         this._grpFile.ResumeLayout(false);
         this._grpFile.PerformLayout();
         this._grpData.ResumeLayout(false);
         this._grpData.PerformLayout();
         this._grpType.ResumeLayout(false);
         this._grpType.PerformLayout();
         this._grpPointerData.ResumeLayout(false);
         this._grpPointerData.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this._nudLength)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this._nudOffset)).EndInit();
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.Label _lblSignatureDataFile;
      private System.Windows.Forms.TextBox _txtSignatureDataFile;
      private System.Windows.Forms.Button _btnSignatureData;
      private System.Windows.Forms.Button _btnCancel;
      private System.Windows.Forms.Button _btnOk;
      private System.Windows.Forms.Label _lblFirst;
      private System.Windows.Forms.TextBox _txtJPEG2000File;
      private System.Windows.Forms.GroupBox _grpFile;
      private System.Windows.Forms.Button _btnJPEGBrowse;
      private System.Windows.Forms.GroupBox _grpData;
      private System.Windows.Forms.GroupBox _grpType;
      private System.Windows.Forms.ComboBox _cbPointerType;
      private System.Windows.Forms.Label _lblPointerType;
      private System.Windows.Forms.Label _lblSignatureType;
      private System.Windows.Forms.GroupBox _grpPointerData;
      private System.Windows.Forms.NumericUpDown _nudLength;
      private System.Windows.Forms.NumericUpDown _nudOffset;
      private System.Windows.Forms.Label _lblLength;
      private System.Windows.Forms.Label _lblOffset;
      private System.Windows.Forms.ComboBox _cbSignatureType;
   }
}
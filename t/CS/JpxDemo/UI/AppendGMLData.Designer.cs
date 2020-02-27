namespace JPXDemo
{
   partial class AppendGMLData
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AppendGMLData));
         this._grpFile = new System.Windows.Forms.GroupBox();
         this._lblJPEG2000 = new System.Windows.Forms.Label();
         this._txtJPEG2000FileName = new System.Windows.Forms.TextBox();
         this._btnJPEG2000Browse = new System.Windows.Forms.Button();
         this._grpGMLFile = new System.Windows.Forms.GroupBox();
         this._lblXMLDataFile = new System.Windows.Forms.Label();
         this._txtXMLDataFile = new System.Windows.Forms.TextBox();
         this._lblLabel = new System.Windows.Forms.Label();
         this._txtLabel = new System.Windows.Forms.TextBox();
         this._btnXMLBrowse = new System.Windows.Forms.Button();
         this._grpGMLInformation = new System.Windows.Forms.GroupBox();
         this._btnDelete = new System.Windows.Forms.Button();
         this._btnDown = new System.Windows.Forms.Button();
         this._btnUp = new System.Windows.Forms.Button();
         this._lblGMLInformationXMLDataFile = new System.Windows.Forms.Label();
         this._lstXmlDataFile = new System.Windows.Forms.ListBox();
         this._lblGMLInformationLabel = new System.Windows.Forms.Label();
         this._lstLabel = new System.Windows.Forms.ListBox();
         this._btnOk = new System.Windows.Forms.Button();
         this._btnCancel = new System.Windows.Forms.Button();
         this._btnAdd = new System.Windows.Forms.Button();
         this._grpFile.SuspendLayout();
         this._grpGMLFile.SuspendLayout();
         this._grpGMLInformation.SuspendLayout();
         this.SuspendLayout();
         // 
         // _grpFile
         // 
         this._grpFile.Controls.Add(this._lblJPEG2000);
         this._grpFile.Controls.Add(this._txtJPEG2000FileName);
         this._grpFile.Controls.Add(this._btnJPEG2000Browse);
         this._grpFile.Location = new System.Drawing.Point(4, 5);
         this._grpFile.Name = "_grpFile";
         this._grpFile.Size = new System.Drawing.Size(393, 72);
         this._grpFile.TabIndex = 0;
         this._grpFile.TabStop = false;
         this._grpFile.Text = "File";
         // 
         // _lblJPEG2000
         // 
         this._lblJPEG2000.AutoSize = true;
         this._lblJPEG2000.Location = new System.Drawing.Point(11, 21);
         this._lblJPEG2000.Name = "_lblJPEG2000";
         this._lblJPEG2000.Size = new System.Drawing.Size(81, 13);
         this._lblJPEG2000.TabIndex = 0;
         this._lblJPEG2000.Text = "Select JPX File:";
         // 
         // _txtJPEG2000FileName
         // 
         this._txtJPEG2000FileName.Location = new System.Drawing.Point(14, 39);
         this._txtJPEG2000FileName.Name = "_txtJPEG2000FileName";
         this._txtJPEG2000FileName.Size = new System.Drawing.Size(289, 20);
         this._txtJPEG2000FileName.TabIndex = 1;
         // 
         // _btnJPEG2000Browse
         // 
         this._btnJPEG2000Browse.Location = new System.Drawing.Point(309, 37);
         this._btnJPEG2000Browse.Name = "_btnJPEG2000Browse";
         this._btnJPEG2000Browse.Size = new System.Drawing.Size(75, 23);
         this._btnJPEG2000Browse.TabIndex = 2;
         this._btnJPEG2000Browse.Text = "Browse";
         this._btnJPEG2000Browse.UseVisualStyleBackColor = true;
         this._btnJPEG2000Browse.Click += new System.EventHandler(this._btnJPEG2000Browse_Click);
         // 
         // _grpGMLFile
         // 
         this._grpGMLFile.Controls.Add(this._lblXMLDataFile);
         this._grpGMLFile.Controls.Add(this._txtXMLDataFile);
         this._grpGMLFile.Controls.Add(this._lblLabel);
         this._grpGMLFile.Controls.Add(this._txtLabel);
         this._grpGMLFile.Controls.Add(this._btnXMLBrowse);
         this._grpGMLFile.Location = new System.Drawing.Point(4, 83);
         this._grpGMLFile.Name = "_grpGMLFile";
         this._grpGMLFile.Size = new System.Drawing.Size(393, 125);
         this._grpGMLFile.TabIndex = 1;
         this._grpGMLFile.TabStop = false;
         this._grpGMLFile.Text = "GML";
         // 
         // _lblXMLDataFile
         // 
         this._lblXMLDataFile.AutoSize = true;
         this._lblXMLDataFile.Location = new System.Drawing.Point(11, 66);
         this._lblXMLDataFile.Name = "_lblXMLDataFile";
         this._lblXMLDataFile.Size = new System.Drawing.Size(77, 13);
         this._lblXMLDataFile.TabIndex = 2;
         this._lblXMLDataFile.Text = "XML Data File:";
         // 
         // _txtXMLDataFile
         // 
         this._txtXMLDataFile.Location = new System.Drawing.Point(14, 84);
         this._txtXMLDataFile.Name = "_txtXMLDataFile";
         this._txtXMLDataFile.Size = new System.Drawing.Size(289, 20);
         this._txtXMLDataFile.TabIndex = 3;
         // 
         // _lblLabel
         // 
         this._lblLabel.AutoSize = true;
         this._lblLabel.Location = new System.Drawing.Point(11, 16);
         this._lblLabel.Name = "_lblLabel";
         this._lblLabel.Size = new System.Drawing.Size(36, 13);
         this._lblLabel.TabIndex = 0;
         this._lblLabel.Text = "Label:";
         // 
         // _txtLabel
         // 
         this._txtLabel.Location = new System.Drawing.Point(14, 34);
         this._txtLabel.Name = "_txtLabel";
         this._txtLabel.Size = new System.Drawing.Size(370, 20);
         this._txtLabel.TabIndex = 1;
         // 
         // _btnXMLBrowse
         // 
         this._btnXMLBrowse.Location = new System.Drawing.Point(309, 81);
         this._btnXMLBrowse.Name = "_btnXMLBrowse";
         this._btnXMLBrowse.Size = new System.Drawing.Size(75, 23);
         this._btnXMLBrowse.TabIndex = 4;
         this._btnXMLBrowse.Text = "Browse";
         this._btnXMLBrowse.UseVisualStyleBackColor = true;
         this._btnXMLBrowse.Click += new System.EventHandler(this._btnXMLBrowse_Click);
         // 
         // _grpGMLInformation
         // 
         this._grpGMLInformation.Controls.Add(this._btnDelete);
         this._grpGMLInformation.Controls.Add(this._btnDown);
         this._grpGMLInformation.Controls.Add(this._btnUp);
         this._grpGMLInformation.Controls.Add(this._lblGMLInformationXMLDataFile);
         this._grpGMLInformation.Controls.Add(this._lstXmlDataFile);
         this._grpGMLInformation.Controls.Add(this._lblGMLInformationLabel);
         this._grpGMLInformation.Controls.Add(this._lstLabel);
         this._grpGMLInformation.Location = new System.Drawing.Point(4, 224);
         this._grpGMLInformation.Name = "_grpGMLInformation";
         this._grpGMLInformation.Size = new System.Drawing.Size(393, 196);
         this._grpGMLInformation.TabIndex = 2;
         this._grpGMLInformation.TabStop = false;
         this._grpGMLInformation.Text = "GML Information";
         // 
         // _btnDelete
         // 
         this._btnDelete.Location = new System.Drawing.Point(316, 162);
         this._btnDelete.Name = "_btnDelete";
         this._btnDelete.Size = new System.Drawing.Size(68, 23);
         this._btnDelete.TabIndex = 6;
         this._btnDelete.Text = "D&elete";
         this._btnDelete.UseVisualStyleBackColor = true;
         this._btnDelete.Click += new System.EventHandler(this._btnDelete_Click);
         // 
         // _btnDown
         // 
         this._btnDown.Image = ((System.Drawing.Image)(resources.GetObject("_btnDown.Image")));
         this._btnDown.Location = new System.Drawing.Point(325, 67);
         this._btnDown.Name = "_btnDown";
         this._btnDown.Size = new System.Drawing.Size(49, 23);
         this._btnDown.TabIndex = 5;
         this._btnDown.UseVisualStyleBackColor = true;
         this._btnDown.Click += new System.EventHandler(this._btnDown_Click);
         // 
         // _btnUp
         // 
         this._btnUp.Image = ((System.Drawing.Image)(resources.GetObject("_btnUp.Image")));
         this._btnUp.Location = new System.Drawing.Point(325, 38);
         this._btnUp.Name = "_btnUp";
         this._btnUp.Size = new System.Drawing.Size(49, 23);
         this._btnUp.TabIndex = 4;
         this._btnUp.UseVisualStyleBackColor = true;
         this._btnUp.Click += new System.EventHandler(this._btnUp_Click);
         // 
         // _lblGMLInformationXMLDataFile
         // 
         this._lblGMLInformationXMLDataFile.AutoSize = true;
         this._lblGMLInformationXMLDataFile.Location = new System.Drawing.Point(161, 20);
         this._lblGMLInformationXMLDataFile.Name = "_lblGMLInformationXMLDataFile";
         this._lblGMLInformationXMLDataFile.Size = new System.Drawing.Size(74, 13);
         this._lblGMLInformationXMLDataFile.TabIndex = 2;
         this._lblGMLInformationXMLDataFile.Text = "XML Data File";
         // 
         // _lstXmlDataFile
         // 
         this._lstXmlDataFile.FormattingEnabled = true;
         this._lstXmlDataFile.Location = new System.Drawing.Point(160, 38);
         this._lstXmlDataFile.Name = "_lstXmlDataFile";
         this._lstXmlDataFile.Size = new System.Drawing.Size(149, 147);
         this._lstXmlDataFile.TabIndex = 3;
         this._lstXmlDataFile.SelectedIndexChanged += new System.EventHandler(this._lst_SelectedIndexChanged);
         // 
         // _lblGMLInformationLabel
         // 
         this._lblGMLInformationLabel.AutoSize = true;
         this._lblGMLInformationLabel.Location = new System.Drawing.Point(15, 20);
         this._lblGMLInformationLabel.Name = "_lblGMLInformationLabel";
         this._lblGMLInformationLabel.Size = new System.Drawing.Size(68, 13);
         this._lblGMLInformationLabel.TabIndex = 0;
         this._lblGMLInformationLabel.Text = "Color Images";
         // 
         // _lstLabel
         // 
         this._lstLabel.FormattingEnabled = true;
         this._lstLabel.Location = new System.Drawing.Point(11, 38);
         this._lstLabel.Name = "_lstLabel";
         this._lstLabel.Size = new System.Drawing.Size(149, 147);
         this._lstLabel.TabIndex = 1;
         this._lstLabel.SelectedIndexChanged += new System.EventHandler(this._lst_SelectedIndexChanged);
         // 
         // _btnOk
         // 
         this._btnOk.Location = new System.Drawing.Point(119, 426);
         this._btnOk.Name = "_btnOk";
         this._btnOk.Size = new System.Drawing.Size(75, 23);
         this._btnOk.TabIndex = 3;
         this._btnOk.Text = "Ok";
         this._btnOk.UseVisualStyleBackColor = true;
         this._btnOk.Click += new System.EventHandler(this._btnOk_Click);
         // 
         // _btnCancel
         // 
         this._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this._btnCancel.Location = new System.Drawing.Point(209, 426);
         this._btnCancel.Name = "_btnCancel";
         this._btnCancel.Size = new System.Drawing.Size(75, 23);
         this._btnCancel.TabIndex = 4;
         this._btnCancel.Text = "Cancel";
         this._btnCancel.UseVisualStyleBackColor = true;
         // 
         // _btnAdd
         // 
         this._btnAdd.Location = new System.Drawing.Point(313, 195);
         this._btnAdd.Name = "_btnAdd";
         this._btnAdd.Size = new System.Drawing.Size(75, 23);
         this._btnAdd.TabIndex = 5;
         this._btnAdd.Text = "&Add";
         this._btnAdd.UseVisualStyleBackColor = true;
         this._btnAdd.Click += new System.EventHandler(this._btnAdd_Click);
         // 
         // AppendGMLData
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.CancelButton = this._btnCancel;
         this.ClientSize = new System.Drawing.Size(403, 453);
         this.Controls.Add(this._btnAdd);
         this.Controls.Add(this._btnCancel);
         this.Controls.Add(this._btnOk);
         this.Controls.Add(this._grpGMLInformation);
         this.Controls.Add(this._grpGMLFile);
         this.Controls.Add(this._grpFile);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "AppendGMLData";
         this.ShowInTaskbar = false;
         this.Text = "Append GML Data";
         this._grpFile.ResumeLayout(false);
         this._grpFile.PerformLayout();
         this._grpGMLFile.ResumeLayout(false);
         this._grpGMLFile.PerformLayout();
         this._grpGMLInformation.ResumeLayout(false);
         this._grpGMLInformation.PerformLayout();
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.GroupBox _grpFile;
      private System.Windows.Forms.Label _lblJPEG2000;
      private System.Windows.Forms.TextBox _txtJPEG2000FileName;
      private System.Windows.Forms.Button _btnJPEG2000Browse;
      private System.Windows.Forms.GroupBox _grpGMLFile;
      private System.Windows.Forms.Label _lblXMLDataFile;
      private System.Windows.Forms.TextBox _txtXMLDataFile;
      private System.Windows.Forms.Label _lblLabel;
      private System.Windows.Forms.TextBox _txtLabel;
      private System.Windows.Forms.Button _btnXMLBrowse;
      private System.Windows.Forms.GroupBox _grpGMLInformation;
      private System.Windows.Forms.Button _btnDown;
      private System.Windows.Forms.Button _btnUp;
      private System.Windows.Forms.Label _lblGMLInformationXMLDataFile;
      private System.Windows.Forms.ListBox _lstXmlDataFile;
      private System.Windows.Forms.Label _lblGMLInformationLabel;
      private System.Windows.Forms.ListBox _lstLabel;
      private System.Windows.Forms.Button _btnDelete;
      private System.Windows.Forms.Button _btnOk;
      private System.Windows.Forms.Button _btnCancel;
      private System.Windows.Forms.Button _btnAdd;
   }
}
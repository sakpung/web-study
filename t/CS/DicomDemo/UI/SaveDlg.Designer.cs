namespace DicomDemo.UI
{
   partial class SaveDlg
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
         this.buttonOK = new System.Windows.Forms.Button();
         this.buttonCancel = new System.Windows.Forms.Button();
         this.textBoxDescription = new System.Windows.Forms.TextBox();
         this.radioButtonInlineBinary = new System.Windows.Forms.RadioButton();
         this.radioButtonBulkDataUri = new System.Windows.Forms.RadioButton();
         this.radioButtonBulkDataUuid = new System.Windows.Forms.RadioButton();
         this.checkBoxTrimWhiteSpace = new System.Windows.Forms.CheckBox();
         this.groupBoxDataOptions = new System.Windows.Forms.GroupBox();
         this.radioButtonIncludeAllData = new System.Windows.Forms.RadioButton();
         this.radioButtonIgnoreAllData = new System.Windows.Forms.RadioButton();
         this.radioButtonIgnoreBinaryData = new System.Windows.Forms.RadioButton();
         this.radioButtonIgnorePixelData = new System.Windows.Forms.RadioButton();
         this.groupBoxBinaryDataOptions = new System.Windows.Forms.GroupBox();
         this.labelInlineBinary = new System.Windows.Forms.Label();
         this.buttonSave = new System.Windows.Forms.Button();
         this.groupBoxMiscOptions = new System.Windows.Forms.GroupBox();
         this.checkBoxWriteKeyword = new System.Windows.Forms.CheckBox();
         this.checkBoxFullEndStatement = new System.Windows.Forms.CheckBox();
         this.checkBoxMinify = new System.Windows.Forms.CheckBox();
         this.groupBoxDataOptions.SuspendLayout();
         this.groupBoxBinaryDataOptions.SuspendLayout();
         this.groupBoxMiscOptions.SuspendLayout();
         this.SuspendLayout();
         // 
         // buttonOK
         // 
         this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
         this.buttonOK.Location = new System.Drawing.Point(348, 267);
         this.buttonOK.Name = "buttonOK";
         this.buttonOK.Size = new System.Drawing.Size(75, 23);
         this.buttonOK.TabIndex = 9;
         this.buttonOK.Text = "&OK";
         // 
         // buttonCancel
         // 
         this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this.buttonCancel.Location = new System.Drawing.Point(428, 267);
         this.buttonCancel.Name = "buttonCancel";
         this.buttonCancel.Size = new System.Drawing.Size(75, 23);
         this.buttonCancel.TabIndex = 8;
         this.buttonCancel.Text = "&Cancel";
         // 
         // textBoxDescription
         // 
         this.textBoxDescription.BorderStyle = System.Windows.Forms.BorderStyle.None;
         this.textBoxDescription.Location = new System.Drawing.Point(11, 17);
         this.textBoxDescription.Multiline = true;
         this.textBoxDescription.Name = "textBoxDescription";
         this.textBoxDescription.ReadOnly = true;
         this.textBoxDescription.Size = new System.Drawing.Size(479, 35);
         this.textBoxDescription.TabIndex = 10;
         // 
         // radioButtonInlineBinary
         // 
         this.radioButtonInlineBinary.AutoSize = true;
         this.radioButtonInlineBinary.Location = new System.Drawing.Point(6, 19);
         this.radioButtonInlineBinary.Name = "radioButtonInlineBinary";
         this.radioButtonInlineBinary.Size = new System.Drawing.Size(82, 17);
         this.radioButtonInlineBinary.TabIndex = 11;
         this.radioButtonInlineBinary.TabStop = true;
         this.radioButtonInlineBinary.Text = "Inline Binary";
         this.radioButtonInlineBinary.UseVisualStyleBackColor = true;
         // 
         // radioButtonBulkDataUri
         // 
         this.radioButtonBulkDataUri.AutoSize = true;
         this.radioButtonBulkDataUri.Location = new System.Drawing.Point(6, 43);
         this.radioButtonBulkDataUri.Name = "radioButtonBulkDataUri";
         this.radioButtonBulkDataUri.Size = new System.Drawing.Size(82, 17);
         this.radioButtonBulkDataUri.TabIndex = 12;
         this.radioButtonBulkDataUri.TabStop = true;
         this.radioButtonBulkDataUri.Text = "BulkDataUri";
         this.radioButtonBulkDataUri.UseVisualStyleBackColor = true;
         // 
         // radioButtonBulkDataUuid
         // 
         this.radioButtonBulkDataUuid.AutoSize = true;
         this.radioButtonBulkDataUuid.Location = new System.Drawing.Point(6, 67);
         this.radioButtonBulkDataUuid.Name = "radioButtonBulkDataUuid";
         this.radioButtonBulkDataUuid.Size = new System.Drawing.Size(91, 17);
         this.radioButtonBulkDataUuid.TabIndex = 13;
         this.radioButtonBulkDataUuid.TabStop = true;
         this.radioButtonBulkDataUuid.Text = "BulkDataUuid";
         this.radioButtonBulkDataUuid.UseVisualStyleBackColor = true;
         // 
         // checkBoxTrimWhiteSpace
         // 
         this.checkBoxTrimWhiteSpace.AutoSize = true;
         this.checkBoxTrimWhiteSpace.Location = new System.Drawing.Point(7, 19);
         this.checkBoxTrimWhiteSpace.Name = "checkBoxTrimWhiteSpace";
         this.checkBoxTrimWhiteSpace.Size = new System.Drawing.Size(111, 17);
         this.checkBoxTrimWhiteSpace.TabIndex = 15;
         this.checkBoxTrimWhiteSpace.Text = "Trim White Space";
         this.checkBoxTrimWhiteSpace.UseVisualStyleBackColor = true;
         // 
         // groupBoxDataOptions
         // 
         this.groupBoxDataOptions.Controls.Add(this.radioButtonIncludeAllData);
         this.groupBoxDataOptions.Controls.Add(this.radioButtonIgnoreAllData);
         this.groupBoxDataOptions.Controls.Add(this.radioButtonIgnoreBinaryData);
         this.groupBoxDataOptions.Controls.Add(this.radioButtonIgnorePixelData);
         this.groupBoxDataOptions.Location = new System.Drawing.Point(348, 57);
         this.groupBoxDataOptions.Name = "groupBoxDataOptions";
         this.groupBoxDataOptions.Size = new System.Drawing.Size(155, 123);
         this.groupBoxDataOptions.TabIndex = 16;
         this.groupBoxDataOptions.TabStop = false;
         this.groupBoxDataOptions.Text = "Data Options";
         // 
         // radioButtonIncludeAllData
         // 
         this.radioButtonIncludeAllData.AutoSize = true;
         this.radioButtonIncludeAllData.Location = new System.Drawing.Point(7, 19);
         this.radioButtonIncludeAllData.Name = "radioButtonIncludeAllData";
         this.radioButtonIncludeAllData.Size = new System.Drawing.Size(100, 17);
         this.radioButtonIncludeAllData.TabIndex = 3;
         this.radioButtonIncludeAllData.TabStop = true;
         this.radioButtonIncludeAllData.Text = "Include All Data";
         this.radioButtonIncludeAllData.UseVisualStyleBackColor = true;
         // 
         // radioButtonIgnoreAllData
         // 
         this.radioButtonIgnoreAllData.AutoSize = true;
         this.radioButtonIgnoreAllData.Location = new System.Drawing.Point(7, 90);
         this.radioButtonIgnoreAllData.Name = "radioButtonIgnoreAllData";
         this.radioButtonIgnoreAllData.Size = new System.Drawing.Size(95, 17);
         this.radioButtonIgnoreAllData.TabIndex = 2;
         this.radioButtonIgnoreAllData.TabStop = true;
         this.radioButtonIgnoreAllData.Text = "Ignore All Data";
         this.radioButtonIgnoreAllData.UseVisualStyleBackColor = true;
         // 
         // radioButtonIgnoreBinaryData
         // 
         this.radioButtonIgnoreBinaryData.AutoSize = true;
         this.radioButtonIgnoreBinaryData.Location = new System.Drawing.Point(7, 66);
         this.radioButtonIgnoreBinaryData.Name = "radioButtonIgnoreBinaryData";
         this.radioButtonIgnoreBinaryData.Size = new System.Drawing.Size(113, 17);
         this.radioButtonIgnoreBinaryData.TabIndex = 1;
         this.radioButtonIgnoreBinaryData.TabStop = true;
         this.radioButtonIgnoreBinaryData.Text = "Ignore Binary Data";
         this.radioButtonIgnoreBinaryData.UseVisualStyleBackColor = true;
         // 
         // radioButtonIgnorePixelData
         // 
         this.radioButtonIgnorePixelData.AutoSize = true;
         this.radioButtonIgnorePixelData.Location = new System.Drawing.Point(7, 42);
         this.radioButtonIgnorePixelData.Name = "radioButtonIgnorePixelData";
         this.radioButtonIgnorePixelData.Size = new System.Drawing.Size(103, 17);
         this.radioButtonIgnorePixelData.TabIndex = 0;
         this.radioButtonIgnorePixelData.TabStop = true;
         this.radioButtonIgnorePixelData.Text = "Ignore PixelData";
         this.radioButtonIgnorePixelData.UseVisualStyleBackColor = true;
         // 
         // groupBoxBinaryDataOptions
         // 
         this.groupBoxBinaryDataOptions.Controls.Add(this.labelInlineBinary);
         this.groupBoxBinaryDataOptions.Controls.Add(this.radioButtonInlineBinary);
         this.groupBoxBinaryDataOptions.Controls.Add(this.radioButtonBulkDataUri);
         this.groupBoxBinaryDataOptions.Controls.Add(this.radioButtonBulkDataUuid);
         this.groupBoxBinaryDataOptions.Location = new System.Drawing.Point(12, 57);
         this.groupBoxBinaryDataOptions.Name = "groupBoxBinaryDataOptions";
         this.groupBoxBinaryDataOptions.Size = new System.Drawing.Size(330, 123);
         this.groupBoxBinaryDataOptions.TabIndex = 17;
         this.groupBoxBinaryDataOptions.TabStop = false;
         this.groupBoxBinaryDataOptions.Text = "Binary Data Options";
         // 
         // labelInlineBinary
         // 
         this.labelInlineBinary.AutoSize = true;
         this.labelInlineBinary.ForeColor = System.Drawing.Color.Red;
         this.labelInlineBinary.Location = new System.Drawing.Point(94, 21);
         this.labelInlineBinary.Name = "labelInlineBinary";
         this.labelInlineBinary.Size = new System.Drawing.Size(203, 13);
         this.labelInlineBinary.TabIndex = 14;
         this.labelInlineBinary.Text = "saves only 1st frame of multiframe dataset";
         // 
         // buttonSave
         // 
         this.buttonSave.Location = new System.Drawing.Point(12, 267);
         this.buttonSave.Name = "buttonSave";
         this.buttonSave.Size = new System.Drawing.Size(78, 23);
         this.buttonSave.TabIndex = 18;
         this.buttonSave.Text = "Save File...";
         this.buttonSave.UseVisualStyleBackColor = true;
         this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
         // 
         // groupBoxMiscOptions
         // 
         this.groupBoxMiscOptions.Controls.Add(this.checkBoxMinify);
         this.groupBoxMiscOptions.Controls.Add(this.checkBoxWriteKeyword);
         this.groupBoxMiscOptions.Controls.Add(this.checkBoxFullEndStatement);
         this.groupBoxMiscOptions.Controls.Add(this.checkBoxTrimWhiteSpace);
         this.groupBoxMiscOptions.Location = new System.Drawing.Point(12, 188);
         this.groupBoxMiscOptions.Name = "groupBoxMiscOptions";
         this.groupBoxMiscOptions.Size = new System.Drawing.Size(330, 67);
         this.groupBoxMiscOptions.TabIndex = 19;
         this.groupBoxMiscOptions.TabStop = false;
         this.groupBoxMiscOptions.Text = "Miscellaneous Options";
         // 
         // checkBoxWriteKeyword
         // 
         this.checkBoxWriteKeyword.AutoSize = true;
         this.checkBoxWriteKeyword.Location = new System.Drawing.Point(182, 19);
         this.checkBoxWriteKeyword.Name = "checkBoxWriteKeyword";
         this.checkBoxWriteKeyword.Size = new System.Drawing.Size(95, 17);
         this.checkBoxWriteKeyword.TabIndex = 17;
         this.checkBoxWriteKeyword.Text = "Write Keyword";
         this.checkBoxWriteKeyword.UseVisualStyleBackColor = true;
         // 
         // checkBoxFullEndStatement
         // 
         this.checkBoxFullEndStatement.AutoSize = true;
         this.checkBoxFullEndStatement.Location = new System.Drawing.Point(7, 43);
         this.checkBoxFullEndStatement.Name = "checkBoxFullEndStatement";
         this.checkBoxFullEndStatement.Size = new System.Drawing.Size(143, 17);
         this.checkBoxFullEndStatement.TabIndex = 16;
         this.checkBoxFullEndStatement.Text = "Write Full End Statement";
         this.checkBoxFullEndStatement.UseVisualStyleBackColor = true;
         // 
         // checkBoxMinify
         // 
         this.checkBoxMinify.AutoSize = true;
         this.checkBoxMinify.Location = new System.Drawing.Point(182, 43);
         this.checkBoxMinify.Name = "checkBoxMinify";
         this.checkBoxMinify.Size = new System.Drawing.Size(53, 17);
         this.checkBoxMinify.TabIndex = 18;
         this.checkBoxMinify.Text = "Minify";
         this.checkBoxMinify.UseVisualStyleBackColor = true;
         // 
         // SaveDlg
         // 
         this.AcceptButton = this.buttonOK;
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
         this.CancelButton = this.buttonCancel;
         this.ClientSize = new System.Drawing.Size(515, 305);
         this.Controls.Add(this.groupBoxMiscOptions);
         this.Controls.Add(this.buttonSave);
         this.Controls.Add(this.groupBoxBinaryDataOptions);
         this.Controls.Add(this.groupBoxDataOptions);
         this.Controls.Add(this.textBoxDescription);
         this.Controls.Add(this.buttonOK);
         this.Controls.Add(this.buttonCancel);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "SaveDlg";
         this.ShowInTaskbar = false;
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "Save";
         this.Load += new System.EventHandler(this.SaveDlg_Load);
         this.groupBoxDataOptions.ResumeLayout(false);
         this.groupBoxDataOptions.PerformLayout();
         this.groupBoxBinaryDataOptions.ResumeLayout(false);
         this.groupBoxBinaryDataOptions.PerformLayout();
         this.groupBoxMiscOptions.ResumeLayout(false);
         this.groupBoxMiscOptions.PerformLayout();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.Button buttonOK;
      private System.Windows.Forms.Button buttonCancel;
      private System.Windows.Forms.TextBox textBoxDescription;
      private System.Windows.Forms.RadioButton radioButtonInlineBinary;
      private System.Windows.Forms.RadioButton radioButtonBulkDataUri;
      private System.Windows.Forms.RadioButton radioButtonBulkDataUuid;
      private System.Windows.Forms.CheckBox checkBoxTrimWhiteSpace;
      private System.Windows.Forms.GroupBox groupBoxDataOptions;
      private System.Windows.Forms.RadioButton radioButtonIgnoreAllData;
      private System.Windows.Forms.RadioButton radioButtonIgnoreBinaryData;
      private System.Windows.Forms.RadioButton radioButtonIgnorePixelData;
      private System.Windows.Forms.GroupBox groupBoxBinaryDataOptions;
      private System.Windows.Forms.Button buttonSave;
      private System.Windows.Forms.GroupBox groupBoxMiscOptions;
      private System.Windows.Forms.CheckBox checkBoxFullEndStatement;
      private System.Windows.Forms.RadioButton radioButtonIncludeAllData;
      private System.Windows.Forms.Label labelInlineBinary;
      private System.Windows.Forms.CheckBox checkBoxWriteKeyword;
      private System.Windows.Forms.CheckBox checkBoxMinify;
   }
}
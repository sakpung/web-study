namespace Leadtools.Medical.Winforms.DatabaseManager
{
   partial class ExportDicomDialog
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
         this.checkBoxOverwrite = new System.Windows.Forms.CheckBox();
         this.checkBoxCreateDicomDir = new System.Windows.Forms.CheckBox();
         this.checkBoxAnonymize = new System.Windows.Forms.CheckBox();
         this.groupBoxExportOptions = new System.Windows.Forms.GroupBox();
         this.buttonAnonymizeOptions = new System.Windows.Forms.Button();
         this.comboBoxAnonymizeScripts = new System.Windows.Forms.ComboBox();
         this.buttonOk = new System.Windows.Forms.Button();
         this.buttonCancel = new System.Windows.Forms.Button();
         this.groupBoxExportFolderLocation = new System.Windows.Forms.GroupBox();
         this.pictureBoxWarning = new System.Windows.Forms.PictureBox();
         this.labelWarnings = new System.Windows.Forms.Label();
         this.buttonBrowse = new System.Windows.Forms.Button();
         this.textBoxExportFolder = new System.Windows.Forms.TextBox();
         this.labelFolder = new System.Windows.Forms.Label();
         this.labelMessage = new System.Windows.Forms.Label();
         this._pictureBoxIcon = new System.Windows.Forms.PictureBox();
         this.groupBoxExportOptions.SuspendLayout();
         this.groupBoxExportFolderLocation.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.pictureBoxWarning)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this._pictureBoxIcon)).BeginInit();
         this.SuspendLayout();
         // 
         // checkBoxOverwrite
         // 
         this.checkBoxOverwrite.AutoSize = true;
         this.checkBoxOverwrite.Location = new System.Drawing.Point(6, 19);
         this.checkBoxOverwrite.Name = "checkBoxOverwrite";
         this.checkBoxOverwrite.Size = new System.Drawing.Size(172, 17);
         this.checkBoxOverwrite.TabIndex = 0;
         this.checkBoxOverwrite.Text = "Overwrite Existing DICOM Files";
         this.checkBoxOverwrite.UseVisualStyleBackColor = true;
         // 
         // checkBoxCreateDicomDir
         // 
         this.checkBoxCreateDicomDir.AutoSize = true;
         this.checkBoxCreateDicomDir.Location = new System.Drawing.Point(6, 42);
         this.checkBoxCreateDicomDir.Name = "checkBoxCreateDicomDir";
         this.checkBoxCreateDicomDir.Size = new System.Drawing.Size(114, 17);
         this.checkBoxCreateDicomDir.TabIndex = 1;
         this.checkBoxCreateDicomDir.Text = "Create DICOMDIR";
         this.checkBoxCreateDicomDir.UseVisualStyleBackColor = true;
         // 
         // checkBoxAnonymize
         // 
         this.checkBoxAnonymize.AutoSize = true;
         this.checkBoxAnonymize.Location = new System.Drawing.Point(6, 65);
         this.checkBoxAnonymize.Name = "checkBoxAnonymize";
         this.checkBoxAnonymize.Size = new System.Drawing.Size(77, 17);
         this.checkBoxAnonymize.TabIndex = 2;
         this.checkBoxAnonymize.Text = "Anonymize";
         this.checkBoxAnonymize.UseVisualStyleBackColor = true;
         this.checkBoxAnonymize.CheckedChanged += new System.EventHandler(this.checkBoxAnonymize_CheckedChanged);
         // 
         // groupBoxExportOptions
         // 
         this.groupBoxExportOptions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.groupBoxExportOptions.Controls.Add(this.buttonAnonymizeOptions);
         this.groupBoxExportOptions.Controls.Add(this.comboBoxAnonymizeScripts);
         this.groupBoxExportOptions.Controls.Add(this.checkBoxOverwrite);
         this.groupBoxExportOptions.Controls.Add(this.checkBoxAnonymize);
         this.groupBoxExportOptions.Controls.Add(this.checkBoxCreateDicomDir);
         this.groupBoxExportOptions.Location = new System.Drawing.Point(12, 175);
         this.groupBoxExportOptions.Name = "groupBoxExportOptions";
         this.groupBoxExportOptions.Size = new System.Drawing.Size(462, 127);
         this.groupBoxExportOptions.TabIndex = 2;
         this.groupBoxExportOptions.TabStop = false;
         this.groupBoxExportOptions.Text = "Export Options";
         // 
         // buttonAnonymizeOptions
         // 
         this.buttonAnonymizeOptions.Location = new System.Drawing.Point(211, 89);
         this.buttonAnonymizeOptions.Name = "buttonAnonymizeOptions";
         this.buttonAnonymizeOptions.Size = new System.Drawing.Size(144, 23);
         this.buttonAnonymizeOptions.TabIndex = 4;
         this.buttonAnonymizeOptions.Text = "Anonymize Options...";
         this.buttonAnonymizeOptions.UseVisualStyleBackColor = true;
         this.buttonAnonymizeOptions.Click += new System.EventHandler(this.buttonAnonymizeOptions_Click);
         // 
         // comboBoxAnonymizeScripts
         // 
         this.comboBoxAnonymizeScripts.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.comboBoxAnonymizeScripts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.comboBoxAnonymizeScripts.FormattingEnabled = true;
         this.comboBoxAnonymizeScripts.Location = new System.Drawing.Point(211, 61);
         this.comboBoxAnonymizeScripts.Name = "comboBoxAnonymizeScripts";
         this.comboBoxAnonymizeScripts.Size = new System.Drawing.Size(244, 21);
         this.comboBoxAnonymizeScripts.TabIndex = 3;
         // 
         // buttonOk
         // 
         this.buttonOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
         this.buttonOk.DialogResult = System.Windows.Forms.DialogResult.OK;
         this.buttonOk.Location = new System.Drawing.Point(318, 311);
         this.buttonOk.Name = "buttonOk";
         this.buttonOk.Size = new System.Drawing.Size(75, 23);
         this.buttonOk.TabIndex = 3;
         this.buttonOk.Text = "&OK";
         this.buttonOk.UseVisualStyleBackColor = true;
         // 
         // buttonCancel
         // 
         this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
         this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this.buttonCancel.Location = new System.Drawing.Point(399, 311);
         this.buttonCancel.Name = "buttonCancel";
         this.buttonCancel.Size = new System.Drawing.Size(75, 23);
         this.buttonCancel.TabIndex = 4;
         this.buttonCancel.Text = "&Cancel";
         this.buttonCancel.UseVisualStyleBackColor = true;
         // 
         // groupBoxExportFolderLocation
         // 
         this.groupBoxExportFolderLocation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.groupBoxExportFolderLocation.Controls.Add(this.pictureBoxWarning);
         this.groupBoxExportFolderLocation.Controls.Add(this.labelWarnings);
         this.groupBoxExportFolderLocation.Controls.Add(this.buttonBrowse);
         this.groupBoxExportFolderLocation.Controls.Add(this.textBoxExportFolder);
         this.groupBoxExportFolderLocation.Controls.Add(this.labelFolder);
         this.groupBoxExportFolderLocation.Location = new System.Drawing.Point(12, 82);
         this.groupBoxExportFolderLocation.Name = "groupBoxExportFolderLocation";
         this.groupBoxExportFolderLocation.Size = new System.Drawing.Size(461, 78);
         this.groupBoxExportFolderLocation.TabIndex = 1;
         this.groupBoxExportFolderLocation.TabStop = false;
         this.groupBoxExportFolderLocation.Text = "Export Folder Location";
         // 
         // pictureBoxWarning
         // 
         this.pictureBoxWarning.Location = new System.Drawing.Point(53, 41);
         this.pictureBoxWarning.Name = "pictureBoxWarning";
         this.pictureBoxWarning.Size = new System.Drawing.Size(20, 20);
         this.pictureBoxWarning.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
         this.pictureBoxWarning.TabIndex = 10;
         this.pictureBoxWarning.TabStop = false;
         // 
         // labelWarnings
         // 
         this.labelWarnings.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.labelWarnings.ForeColor = System.Drawing.Color.Red;
         this.labelWarnings.Location = new System.Drawing.Point(79, 45);
         this.labelWarnings.Name = "labelWarnings";
         this.labelWarnings.Size = new System.Drawing.Size(376, 16);
         this.labelWarnings.TabIndex = 9;
         this.labelWarnings.Text = "labelWarnings";
         // 
         // buttonBrowse
         // 
         this.buttonBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
         this.buttonBrowse.Location = new System.Drawing.Point(380, 19);
         this.buttonBrowse.Name = "buttonBrowse";
         this.buttonBrowse.Size = new System.Drawing.Size(75, 23);
         this.buttonBrowse.TabIndex = 2;
         this.buttonBrowse.Text = "Browse...";
         this.buttonBrowse.UseVisualStyleBackColor = true;
         this.buttonBrowse.Click += new System.EventHandler(this.buttonBrowse_Click);
         // 
         // textBoxExportFolder
         // 
         this.textBoxExportFolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.textBoxExportFolder.Location = new System.Drawing.Point(53, 20);
         this.textBoxExportFolder.Name = "textBoxExportFolder";
         this.textBoxExportFolder.Size = new System.Drawing.Size(321, 20);
         this.textBoxExportFolder.TabIndex = 1;
         this.textBoxExportFolder.TextChanged += new System.EventHandler(this.textBoxExportFolder_TextChanged);
         // 
         // labelFolder
         // 
         this.labelFolder.AutoSize = true;
         this.labelFolder.Location = new System.Drawing.Point(7, 20);
         this.labelFolder.Name = "labelFolder";
         this.labelFolder.Size = new System.Drawing.Size(39, 13);
         this.labelFolder.TabIndex = 0;
         this.labelFolder.Text = "Folder:";
         // 
         // labelMessage
         // 
         this.labelMessage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.labelMessage.Location = new System.Drawing.Point(63, 12);
         this.labelMessage.Name = "labelMessage";
         this.labelMessage.Size = new System.Drawing.Size(411, 57);
         this.labelMessage.TabIndex = 0;
         this.labelMessage.Text = "Message";
         // 
         // _pictureBoxIcon
         // 
         this._pictureBoxIcon.Location = new System.Drawing.Point(12, 12);
         this._pictureBoxIcon.Name = "_pictureBoxIcon";
         this._pictureBoxIcon.Size = new System.Drawing.Size(47, 47);
         this._pictureBoxIcon.TabIndex = 8;
         this._pictureBoxIcon.TabStop = false;
         // 
         // ExportDicomDialog
         // 
         this.AcceptButton = this.buttonOk;
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.CancelButton = this.buttonCancel;
         this.ClientSize = new System.Drawing.Size(486, 343);
         this.Controls.Add(this._pictureBoxIcon);
         this.Controls.Add(this.labelMessage);
         this.Controls.Add(this.groupBoxExportFolderLocation);
         this.Controls.Add(this.buttonCancel);
         this.Controls.Add(this.buttonOk);
         this.Controls.Add(this.groupBoxExportOptions);
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.MinimumSize = new System.Drawing.Size(502, 381);
         this.Name = "ExportDicomDialog";
         this.ShowIcon = false;
         this.ShowInTaskbar = false;
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "Export Selected";
         this.Load += new System.EventHandler(this.ExportDicomDialog_Load);
         this.groupBoxExportOptions.ResumeLayout(false);
         this.groupBoxExportOptions.PerformLayout();
         this.groupBoxExportFolderLocation.ResumeLayout(false);
         this.groupBoxExportFolderLocation.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this.pictureBoxWarning)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this._pictureBoxIcon)).EndInit();
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.CheckBox checkBoxOverwrite;
      private System.Windows.Forms.CheckBox checkBoxCreateDicomDir;
      private System.Windows.Forms.CheckBox checkBoxAnonymize;
      private System.Windows.Forms.GroupBox groupBoxExportOptions;
      private System.Windows.Forms.Button buttonOk;
      private System.Windows.Forms.Button buttonCancel;
      private System.Windows.Forms.GroupBox groupBoxExportFolderLocation;
      private System.Windows.Forms.Button buttonBrowse;
      private System.Windows.Forms.TextBox textBoxExportFolder;
      private System.Windows.Forms.Label labelFolder;
      private System.Windows.Forms.Label labelMessage;
      private System.Windows.Forms.PictureBox _pictureBoxIcon;
      private System.Windows.Forms.Label labelWarnings;
      private System.Windows.Forms.PictureBox pictureBoxWarning;
      private System.Windows.Forms.ComboBox comboBoxAnonymizeScripts;
      private System.Windows.Forms.Button buttonAnonymizeOptions;
   }
}
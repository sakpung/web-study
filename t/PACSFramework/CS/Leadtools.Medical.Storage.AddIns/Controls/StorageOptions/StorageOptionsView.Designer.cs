namespace Leadtools.Medical.Storage.AddIns
{
   partial class StorageOptionsView
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

      #region Component Designer generated code

      /// <summary> 
      /// Required method for Designer support - do not modify 
      /// the contents of this method with the code editor.
      /// </summary>
      private void InitializeComponent()
      {
         this.components = new System.ComponentModel.Container();
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StorageOptionsView));
         this.tabControlStorageOptions = new System.Windows.Forms.TabControl();
         this.tabPageFiles = new System.Windows.Forms.TabPage();
         this.StoreFileSettingsGoupBox = new System.Windows.Forms.GroupBox();
         this.BrowseHangingProtocolLocationButton = new System.Windows.Forms.Button();
         this.HangingProtocolLocationTextBox = new System.Windows.Forms.TextBox();
         this.HangingProtocolLocationLabel = new System.Windows.Forms.Label();
         this.FileExtTextBox = new System.Windows.Forms.TextBox();
         this.DICOMFileExtLabel = new System.Windows.Forms.Label();
         this.BrowseStorageLocationButton = new System.Windows.Forms.Button();
         this.StorageLocationTextBox = new System.Windows.Forms.TextBox();
         this.StorageLocationLabel = new System.Windows.Forms.Label();
         this.OverwriteSettingsGroupBox = new System.Windows.Forms.GroupBox();
         this.BrowseBackupLocationButton = new System.Windows.Forms.Button();
         this.OverwriteBackupLocationTextBox = new System.Windows.Forms.TextBox();
         this.BackupLocationLabel = new System.Windows.Forms.Label();
         this.CreateBackupCheckBox = new System.Windows.Forms.CheckBox();
         this.StoreFailureGroupBox = new System.Windows.Forms.GroupBox();
         this.StoreFailureLabel = new System.Windows.Forms.Label();
         this.SaveCStoreFailuresCheckBox = new System.Windows.Forms.CheckBox();
         this.BrowseCStoreFailuresButton = new System.Windows.Forms.Button();
         this.CStoreFailuresTextBox = new System.Windows.Forms.TextBox();
         this.groupBoxDeleteSettings = new System.Windows.Forms.GroupBox();
         this.DeleteBackupLocationLabel = new System.Windows.Forms.Label();
         this.BackupFilesOnDeleteCheckBox = new System.Windows.Forms.CheckBox();
         this.BrowseDeleteFileBackupLocationButton = new System.Windows.Forms.Button();
         this.DeleteBackupLocationTextBox = new System.Windows.Forms.TextBox();
         this.DeleteFilesCheckBox = new System.Windows.Forms.CheckBox();
         this.tabPageDirectoryStructure = new System.Windows.Forms.TabPage();
         this.SplitPatientIdCheckBox = new System.Windows.Forms.CheckBox();
         this.UsePatientNameRadioButton = new System.Windows.Forms.RadioButton();
         this.UsePatientIdRadioButton = new System.Windows.Forms.RadioButton();
         this.CreateSeriesFolderCheckBox = new System.Windows.Forms.CheckBox();
         this.CreateStudyFolderCheckBox = new System.Windows.Forms.CheckBox();
         this.CreatepatientFolderCheckBox = new System.Windows.Forms.CheckBox();
         this.tabPageImages = new System.Windows.Forms.TabPage();
         this.groupBox1 = new System.Windows.Forms.GroupBox();
         this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
         this.generateImagesListView = new System.Windows.Forms.ListView();
         this.ImageWidth = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
         this.ImageHeight = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
         this.QualityFactor = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
         this.ImageFormat = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
         this.toolStrip1 = new System.Windows.Forms.ToolStrip();
         this.AddImageToolStripButton = new System.Windows.Forms.ToolStripButton();
         this.EditToolStripButton = new System.Windows.Forms.ToolStripButton();
         this.DeleteToolStripButton = new System.Windows.Forms.ToolStripButton();
         this.CreateThumbCheckBox = new System.Windows.Forms.CheckBox();
         this.CreateThumbGroupBox = new System.Windows.Forms.GroupBox();
         this.ThumbQFactorNumeric = new System.Windows.Forms.NumericUpDown();
         this.ThumbHeightNumeric = new System.Windows.Forms.NumericUpDown();
         this.ThumbWidthNumeric = new System.Windows.Forms.NumericUpDown();
         this.ThumbImageWidthLabel = new System.Windows.Forms.Label();
         this.ImageFormatTabel = new System.Windows.Forms.Label();
         this.ThumbFormatComboBox = new System.Windows.Forms.ComboBox();
         this.label3 = new System.Windows.Forms.Label();
         this.ThumbImageHeightLabel = new System.Windows.Forms.Label();
         this.tabPageOptions = new System.Windows.Forms.TabPage();
         this.UseMessageQueueCheckBox = new System.Windows.Forms.CheckBox();
         this.AutoTruncateDataCheckBox = new System.Windows.Forms.CheckBox();
         this.DeleteAnnotationCheckBox = new System.Windows.Forms.CheckBox();
         this.DatabaseOptionsGroupBox = new System.Windows.Forms.GroupBox();
         this.UpdateInstanceCheckBox = new System.Windows.Forms.CheckBox();
         this.UpdateSeriesCheckBox = new System.Windows.Forms.CheckBox();
         this.UpdateStudyCheckBox = new System.Windows.Forms.CheckBox();
         this.UpdatePatientCheckBox = new System.Windows.Forms.CheckBox();
         this.PreventDuplicateSOPCheckBox = new System.Windows.Forms.CheckBox();
         this.tabPageMetadata = new System.Windows.Forms.TabPage();
         this.labelStatus = new System.Windows.Forms.Label();
         this.groupBoxXmlMetadataOptions = new System.Windows.Forms.GroupBox();
         this.buttonXmlGenerateMissing = new System.Windows.Forms.Button();
         this.buttonXmlStopGenerate = new System.Windows.Forms.Button();
         this.buttonXmlGenerateAll = new System.Windows.Forms.Button();
         this.buttonXmlDeleteAll = new System.Windows.Forms.Button();
         this.checkBoxXmlIgnoreBinaryData = new System.Windows.Forms.CheckBox();
         this.checkBoxXmlFullEndStatement = new System.Windows.Forms.CheckBox();
         this.checkBoxXmlTrimWhiteSpace = new System.Windows.Forms.CheckBox();
         this.checkBoxXmlStore = new System.Windows.Forms.CheckBox();
         this.groupBoxJsonMetadataOptions = new System.Windows.Forms.GroupBox();
         this.buttonJsonGenerateMissing = new System.Windows.Forms.Button();
         this.buttonJsonStopGenerate = new System.Windows.Forms.Button();
         this.buttonJsonGenerateAll = new System.Windows.Forms.Button();
         this.buttonJsonDeleteAll = new System.Windows.Forms.Button();
         this.checkBoxJsonIgnoreBinaryData = new System.Windows.Forms.CheckBox();
         this.checkBoxJsonMinify = new System.Windows.Forms.CheckBox();
         this.checkBoxJsonWriteKeyword = new System.Windows.Forms.CheckBox();
         this.checkBoxJsonTrimWhiteSpace = new System.Windows.Forms.CheckBox();
         this.checkBoxJsonStore = new System.Windows.Forms.CheckBox();
         this.StorageLocationBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
         this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
         this.tabControlStorageOptions.SuspendLayout();
         this.tabPageFiles.SuspendLayout();
         this.StoreFileSettingsGoupBox.SuspendLayout();
         this.OverwriteSettingsGroupBox.SuspendLayout();
         this.StoreFailureGroupBox.SuspendLayout();
         this.groupBoxDeleteSettings.SuspendLayout();
         this.tabPageDirectoryStructure.SuspendLayout();
         this.tabPageImages.SuspendLayout();
         this.groupBox1.SuspendLayout();
         this.toolStripContainer1.ContentPanel.SuspendLayout();
         this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
         this.toolStripContainer1.SuspendLayout();
         this.toolStrip1.SuspendLayout();
         this.CreateThumbGroupBox.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.ThumbQFactorNumeric)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.ThumbHeightNumeric)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.ThumbWidthNumeric)).BeginInit();
         this.tabPageOptions.SuspendLayout();
         this.DatabaseOptionsGroupBox.SuspendLayout();
         this.tabPageMetadata.SuspendLayout();
         this.groupBoxXmlMetadataOptions.SuspendLayout();
         this.groupBoxJsonMetadataOptions.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
         this.SuspendLayout();
         // 
         // tabControlStorageOptions
         // 
         this.tabControlStorageOptions.Controls.Add(this.tabPageFiles);
         this.tabControlStorageOptions.Controls.Add(this.tabPageDirectoryStructure);
         this.tabControlStorageOptions.Controls.Add(this.tabPageImages);
         this.tabControlStorageOptions.Controls.Add(this.tabPageOptions);
         this.tabControlStorageOptions.Controls.Add(this.tabPageMetadata);
         this.tabControlStorageOptions.Dock = System.Windows.Forms.DockStyle.Fill;
         this.tabControlStorageOptions.Location = new System.Drawing.Point(0, 0);
         this.tabControlStorageOptions.Name = "tabControlStorageOptions";
         this.tabControlStorageOptions.SelectedIndex = 0;
         this.tabControlStorageOptions.Size = new System.Drawing.Size(660, 450);
         this.tabControlStorageOptions.TabIndex = 0;
         // 
         // tabPageFiles
         // 
         this.tabPageFiles.Controls.Add(this.StoreFileSettingsGoupBox);
         this.tabPageFiles.Controls.Add(this.OverwriteSettingsGroupBox);
         this.tabPageFiles.Controls.Add(this.StoreFailureGroupBox);
         this.tabPageFiles.Controls.Add(this.groupBoxDeleteSettings);
         this.tabPageFiles.Location = new System.Drawing.Point(4, 22);
         this.tabPageFiles.Name = "tabPageFiles";
         this.tabPageFiles.Padding = new System.Windows.Forms.Padding(3);
         this.tabPageFiles.Size = new System.Drawing.Size(652, 424);
         this.tabPageFiles.TabIndex = 0;
         this.tabPageFiles.Text = "Files";
         this.tabPageFiles.UseVisualStyleBackColor = true;
         // 
         // StoreFileSettingsGoupBox
         // 
         this.StoreFileSettingsGoupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.StoreFileSettingsGoupBox.Controls.Add(this.BrowseHangingProtocolLocationButton);
         this.StoreFileSettingsGoupBox.Controls.Add(this.HangingProtocolLocationTextBox);
         this.StoreFileSettingsGoupBox.Controls.Add(this.HangingProtocolLocationLabel);
         this.StoreFileSettingsGoupBox.Controls.Add(this.FileExtTextBox);
         this.StoreFileSettingsGoupBox.Controls.Add(this.DICOMFileExtLabel);
         this.StoreFileSettingsGoupBox.Controls.Add(this.BrowseStorageLocationButton);
         this.StoreFileSettingsGoupBox.Controls.Add(this.StorageLocationTextBox);
         this.StoreFileSettingsGoupBox.Controls.Add(this.StorageLocationLabel);
         this.StoreFileSettingsGoupBox.Location = new System.Drawing.Point(18, 12);
         this.StoreFileSettingsGoupBox.Name = "StoreFileSettingsGoupBox";
         this.StoreFileSettingsGoupBox.Size = new System.Drawing.Size(621, 104);
         this.StoreFileSettingsGoupBox.TabIndex = 0;
         this.StoreFileSettingsGoupBox.TabStop = false;
         this.StoreFileSettingsGoupBox.Text = "Store File Settings";
         // 
         // BrowseHangingProtocolLocationButton
         // 
         this.BrowseHangingProtocolLocationButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
         this.BrowseHangingProtocolLocationButton.Location = new System.Drawing.Point(538, 42);
         this.BrowseHangingProtocolLocationButton.Name = "BrowseHangingProtocolLocationButton";
         this.BrowseHangingProtocolLocationButton.Size = new System.Drawing.Size(75, 23);
         this.BrowseHangingProtocolLocationButton.TabIndex = 5;
         this.BrowseHangingProtocolLocationButton.Text = "Browse...";
         this.BrowseHangingProtocolLocationButton.UseVisualStyleBackColor = true;
         // 
         // HangingProtocolLocationTextBox
         // 
         this.HangingProtocolLocationTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.HangingProtocolLocationTextBox.Location = new System.Drawing.Point(106, 43);
         this.HangingProtocolLocationTextBox.Name = "HangingProtocolLocationTextBox";
         this.HangingProtocolLocationTextBox.Size = new System.Drawing.Size(424, 20);
         this.HangingProtocolLocationTextBox.TabIndex = 4;
         // 
         // HangingProtocolLocationLabel
         // 
         this.HangingProtocolLocationLabel.AutoSize = true;
         this.HangingProtocolLocationLabel.Location = new System.Drawing.Point(13, 47);
         this.HangingProtocolLocationLabel.Name = "HangingProtocolLocationLabel";
         this.HangingProtocolLocationLabel.Size = new System.Drawing.Size(92, 13);
         this.HangingProtocolLocationLabel.TabIndex = 3;
         this.HangingProtocolLocationLabel.Text = "Hanging Protocol:";
         // 
         // FileExtTextBox
         // 
         this.FileExtTextBox.Location = new System.Drawing.Point(106, 69);
         this.FileExtTextBox.Name = "FileExtTextBox";
         this.FileExtTextBox.Size = new System.Drawing.Size(71, 20);
         this.FileExtTextBox.TabIndex = 7;
         // 
         // DICOMFileExtLabel
         // 
         this.DICOMFileExtLabel.AutoSize = true;
         this.DICOMFileExtLabel.Location = new System.Drawing.Point(12, 73);
         this.DICOMFileExtLabel.Name = "DICOMFileExtLabel";
         this.DICOMFileExtLabel.Size = new System.Drawing.Size(56, 13);
         this.DICOMFileExtLabel.TabIndex = 6;
         this.DICOMFileExtLabel.Text = "Extension:";
         // 
         // BrowseStorageLocationButton
         // 
         this.BrowseStorageLocationButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
         this.BrowseStorageLocationButton.Location = new System.Drawing.Point(537, 16);
         this.BrowseStorageLocationButton.Name = "BrowseStorageLocationButton";
         this.BrowseStorageLocationButton.Size = new System.Drawing.Size(75, 23);
         this.BrowseStorageLocationButton.TabIndex = 2;
         this.BrowseStorageLocationButton.Text = "Browse...";
         this.BrowseStorageLocationButton.UseVisualStyleBackColor = true;
         // 
         // StorageLocationTextBox
         // 
         this.StorageLocationTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.StorageLocationTextBox.Location = new System.Drawing.Point(106, 17);
         this.StorageLocationTextBox.Name = "StorageLocationTextBox";
         this.StorageLocationTextBox.Size = new System.Drawing.Size(423, 20);
         this.StorageLocationTextBox.TabIndex = 1;
         // 
         // StorageLocationLabel
         // 
         this.StorageLocationLabel.AutoSize = true;
         this.StorageLocationLabel.Location = new System.Drawing.Point(12, 21);
         this.StorageLocationLabel.Name = "StorageLocationLabel";
         this.StorageLocationLabel.Size = new System.Drawing.Size(39, 13);
         this.StorageLocationLabel.TabIndex = 0;
         this.StorageLocationLabel.Text = "Folder:";
         // 
         // OverwriteSettingsGroupBox
         // 
         this.OverwriteSettingsGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.OverwriteSettingsGroupBox.Controls.Add(this.BrowseBackupLocationButton);
         this.OverwriteSettingsGroupBox.Controls.Add(this.OverwriteBackupLocationTextBox);
         this.OverwriteSettingsGroupBox.Controls.Add(this.BackupLocationLabel);
         this.OverwriteSettingsGroupBox.Controls.Add(this.CreateBackupCheckBox);
         this.OverwriteSettingsGroupBox.Location = new System.Drawing.Point(18, 122);
         this.OverwriteSettingsGroupBox.Name = "OverwriteSettingsGroupBox";
         this.OverwriteSettingsGroupBox.Size = new System.Drawing.Size(621, 81);
         this.OverwriteSettingsGroupBox.TabIndex = 1;
         this.OverwriteSettingsGroupBox.TabStop = false;
         this.OverwriteSettingsGroupBox.Text = "Overwrite Settings";
         // 
         // BrowseBackupLocationButton
         // 
         this.BrowseBackupLocationButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
         this.BrowseBackupLocationButton.Location = new System.Drawing.Point(537, 40);
         this.BrowseBackupLocationButton.Name = "BrowseBackupLocationButton";
         this.BrowseBackupLocationButton.Size = new System.Drawing.Size(75, 23);
         this.BrowseBackupLocationButton.TabIndex = 3;
         this.BrowseBackupLocationButton.Text = "Browse...";
         this.BrowseBackupLocationButton.UseVisualStyleBackColor = true;
         // 
         // OverwriteBackupLocationTextBox
         // 
         this.OverwriteBackupLocationTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.OverwriteBackupLocationTextBox.Location = new System.Drawing.Point(106, 41);
         this.OverwriteBackupLocationTextBox.Name = "OverwriteBackupLocationTextBox";
         this.OverwriteBackupLocationTextBox.Size = new System.Drawing.Size(423, 20);
         this.OverwriteBackupLocationTextBox.TabIndex = 2;
         // 
         // BackupLocationLabel
         // 
         this.BackupLocationLabel.AutoSize = true;
         this.BackupLocationLabel.Location = new System.Drawing.Point(12, 45);
         this.BackupLocationLabel.Name = "BackupLocationLabel";
         this.BackupLocationLabel.Size = new System.Drawing.Size(39, 13);
         this.BackupLocationLabel.TabIndex = 1;
         this.BackupLocationLabel.Text = "Folder:";
         // 
         // CreateBackupCheckBox
         // 
         this.CreateBackupCheckBox.AutoSize = true;
         this.CreateBackupCheckBox.Location = new System.Drawing.Point(14, 20);
         this.CreateBackupCheckBox.Name = "CreateBackupCheckBox";
         this.CreateBackupCheckBox.Size = new System.Drawing.Size(198, 17);
         this.CreateBackupCheckBox.TabIndex = 0;
         this.CreateBackupCheckBox.Text = "Create File Backup Before Overwrite";
         this.CreateBackupCheckBox.UseVisualStyleBackColor = true;
         // 
         // StoreFailureGroupBox
         // 
         this.StoreFailureGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.StoreFailureGroupBox.Controls.Add(this.StoreFailureLabel);
         this.StoreFailureGroupBox.Controls.Add(this.SaveCStoreFailuresCheckBox);
         this.StoreFailureGroupBox.Controls.Add(this.BrowseCStoreFailuresButton);
         this.StoreFailureGroupBox.Controls.Add(this.CStoreFailuresTextBox);
         this.StoreFailureGroupBox.Location = new System.Drawing.Point(18, 331);
         this.StoreFailureGroupBox.Name = "StoreFailureGroupBox";
         this.StoreFailureGroupBox.Size = new System.Drawing.Size(621, 83);
         this.StoreFailureGroupBox.TabIndex = 3;
         this.StoreFailureGroupBox.TabStop = false;
         this.StoreFailureGroupBox.Text = "Store Failure Settings";
         // 
         // StoreFailureLabel
         // 
         this.StoreFailureLabel.AutoSize = true;
         this.StoreFailureLabel.Location = new System.Drawing.Point(12, 47);
         this.StoreFailureLabel.Name = "StoreFailureLabel";
         this.StoreFailureLabel.Size = new System.Drawing.Size(39, 13);
         this.StoreFailureLabel.TabIndex = 1;
         this.StoreFailureLabel.Text = "Folder:";
         // 
         // SaveCStoreFailuresCheckBox
         // 
         this.SaveCStoreFailuresCheckBox.AutoSize = true;
         this.SaveCStoreFailuresCheckBox.Location = new System.Drawing.Point(13, 21);
         this.SaveCStoreFailuresCheckBox.Name = "SaveCStoreFailuresCheckBox";
         this.SaveCStoreFailuresCheckBox.Size = new System.Drawing.Size(193, 17);
         this.SaveCStoreFailuresCheckBox.TabIndex = 0;
         this.SaveCStoreFailuresCheckBox.Text = "Save C-STORE and Import Failures";
         this.SaveCStoreFailuresCheckBox.UseVisualStyleBackColor = true;
         // 
         // BrowseCStoreFailuresButton
         // 
         this.BrowseCStoreFailuresButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
         this.BrowseCStoreFailuresButton.Location = new System.Drawing.Point(537, 42);
         this.BrowseCStoreFailuresButton.Name = "BrowseCStoreFailuresButton";
         this.BrowseCStoreFailuresButton.Size = new System.Drawing.Size(75, 23);
         this.BrowseCStoreFailuresButton.TabIndex = 3;
         this.BrowseCStoreFailuresButton.Text = "Browse...";
         this.BrowseCStoreFailuresButton.UseVisualStyleBackColor = true;
         // 
         // CStoreFailuresTextBox
         // 
         this.CStoreFailuresTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.CStoreFailuresTextBox.Location = new System.Drawing.Point(106, 43);
         this.CStoreFailuresTextBox.Name = "CStoreFailuresTextBox";
         this.CStoreFailuresTextBox.Size = new System.Drawing.Size(423, 20);
         this.CStoreFailuresTextBox.TabIndex = 2;
         // 
         // groupBoxDeleteSettings
         // 
         this.groupBoxDeleteSettings.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.groupBoxDeleteSettings.Controls.Add(this.DeleteBackupLocationLabel);
         this.groupBoxDeleteSettings.Controls.Add(this.BackupFilesOnDeleteCheckBox);
         this.groupBoxDeleteSettings.Controls.Add(this.BrowseDeleteFileBackupLocationButton);
         this.groupBoxDeleteSettings.Controls.Add(this.DeleteBackupLocationTextBox);
         this.groupBoxDeleteSettings.Controls.Add(this.DeleteFilesCheckBox);
         this.groupBoxDeleteSettings.Location = new System.Drawing.Point(18, 210);
         this.groupBoxDeleteSettings.Name = "groupBoxDeleteSettings";
         this.groupBoxDeleteSettings.Size = new System.Drawing.Size(621, 114);
         this.groupBoxDeleteSettings.TabIndex = 2;
         this.groupBoxDeleteSettings.TabStop = false;
         this.groupBoxDeleteSettings.Text = "Delete Settings";
         // 
         // DeleteBackupLocationLabel
         // 
         this.DeleteBackupLocationLabel.AutoSize = true;
         this.DeleteBackupLocationLabel.Location = new System.Drawing.Point(12, 78);
         this.DeleteBackupLocationLabel.Name = "DeleteBackupLocationLabel";
         this.DeleteBackupLocationLabel.Size = new System.Drawing.Size(39, 13);
         this.DeleteBackupLocationLabel.TabIndex = 2;
         this.DeleteBackupLocationLabel.Text = "Folder:";
         // 
         // BackupFilesOnDeleteCheckBox
         // 
         this.BackupFilesOnDeleteCheckBox.AutoSize = true;
         this.BackupFilesOnDeleteCheckBox.Location = new System.Drawing.Point(14, 51);
         this.BackupFilesOnDeleteCheckBox.Name = "BackupFilesOnDeleteCheckBox";
         this.BackupFilesOnDeleteCheckBox.Size = new System.Drawing.Size(250, 17);
         this.BackupFilesOnDeleteCheckBox.TabIndex = 1;
         this.BackupFilesOnDeleteCheckBox.Text = "Automatically backup DICOM dataset on delete";
         this.BackupFilesOnDeleteCheckBox.UseVisualStyleBackColor = true;
         // 
         // BrowseDeleteFileBackupLocationButton
         // 
         this.BrowseDeleteFileBackupLocationButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
         this.BrowseDeleteFileBackupLocationButton.Location = new System.Drawing.Point(537, 73);
         this.BrowseDeleteFileBackupLocationButton.Name = "BrowseDeleteFileBackupLocationButton";
         this.BrowseDeleteFileBackupLocationButton.Size = new System.Drawing.Size(75, 23);
         this.BrowseDeleteFileBackupLocationButton.TabIndex = 4;
         this.BrowseDeleteFileBackupLocationButton.Text = "Browse...";
         this.BrowseDeleteFileBackupLocationButton.UseVisualStyleBackColor = true;
         // 
         // DeleteBackupLocationTextBox
         // 
         this.DeleteBackupLocationTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.DeleteBackupLocationTextBox.Location = new System.Drawing.Point(106, 74);
         this.DeleteBackupLocationTextBox.Name = "DeleteBackupLocationTextBox";
         this.DeleteBackupLocationTextBox.Size = new System.Drawing.Size(423, 20);
         this.DeleteBackupLocationTextBox.TabIndex = 3;
         // 
         // DeleteFilesCheckBox
         // 
         this.DeleteFilesCheckBox.AutoSize = true;
         this.DeleteFilesCheckBox.Location = new System.Drawing.Point(14, 23);
         this.DeleteFilesCheckBox.Name = "DeleteFilesCheckBox";
         this.DeleteFilesCheckBox.Size = new System.Drawing.Size(232, 17);
         this.DeleteFilesCheckBox.TabIndex = 0;
         this.DeleteFilesCheckBox.Text = "Delete DICOM files when deleting database";
         this.DeleteFilesCheckBox.UseVisualStyleBackColor = true;
         // 
         // tabPageDirectoryStructure
         // 
         this.tabPageDirectoryStructure.Controls.Add(this.SplitPatientIdCheckBox);
         this.tabPageDirectoryStructure.Controls.Add(this.UsePatientNameRadioButton);
         this.tabPageDirectoryStructure.Controls.Add(this.UsePatientIdRadioButton);
         this.tabPageDirectoryStructure.Controls.Add(this.CreateSeriesFolderCheckBox);
         this.tabPageDirectoryStructure.Controls.Add(this.CreateStudyFolderCheckBox);
         this.tabPageDirectoryStructure.Controls.Add(this.CreatepatientFolderCheckBox);
         this.tabPageDirectoryStructure.Location = new System.Drawing.Point(4, 22);
         this.tabPageDirectoryStructure.Name = "tabPageDirectoryStructure";
         this.tabPageDirectoryStructure.Padding = new System.Windows.Forms.Padding(3);
         this.tabPageDirectoryStructure.Size = new System.Drawing.Size(652, 424);
         this.tabPageDirectoryStructure.TabIndex = 3;
         this.tabPageDirectoryStructure.Text = "Directory Structure";
         this.tabPageDirectoryStructure.UseVisualStyleBackColor = true;
         // 
         // SplitPatientIdCheckBox
         // 
         this.SplitPatientIdCheckBox.AutoSize = true;
         this.SplitPatientIdCheckBox.Location = new System.Drawing.Point(60, 60);
         this.SplitPatientIdCheckBox.Name = "SplitPatientIdCheckBox";
         this.SplitPatientIdCheckBox.Size = new System.Drawing.Size(192, 17);
         this.SplitPatientIdCheckBox.TabIndex = 13;
         this.SplitPatientIdCheckBox.Text = "Split Patient ID into Multiple Folders";
         this.SplitPatientIdCheckBox.UseVisualStyleBackColor = true;
         // 
         // UsePatientNameRadioButton
         // 
         this.UsePatientNameRadioButton.AutoSize = true;
         this.UsePatientNameRadioButton.Location = new System.Drawing.Point(39, 84);
         this.UsePatientNameRadioButton.Name = "UsePatientNameRadioButton";
         this.UsePatientNameRadioButton.Size = new System.Drawing.Size(111, 17);
         this.UsePatientNameRadioButton.TabIndex = 12;
         this.UsePatientNameRadioButton.TabStop = true;
         this.UsePatientNameRadioButton.Text = "Use Patient Name";
         this.UsePatientNameRadioButton.UseVisualStyleBackColor = true;
         // 
         // UsePatientIdRadioButton
         // 
         this.UsePatientIdRadioButton.AutoSize = true;
         this.UsePatientIdRadioButton.Location = new System.Drawing.Point(39, 36);
         this.UsePatientIdRadioButton.Name = "UsePatientIdRadioButton";
         this.UsePatientIdRadioButton.Size = new System.Drawing.Size(94, 17);
         this.UsePatientIdRadioButton.TabIndex = 11;
         this.UsePatientIdRadioButton.TabStop = true;
         this.UsePatientIdRadioButton.Text = "Use Patient ID";
         this.UsePatientIdRadioButton.UseVisualStyleBackColor = true;
         // 
         // CreateSeriesFolderCheckBox
         // 
         this.CreateSeriesFolderCheckBox.AutoSize = true;
         this.CreateSeriesFolderCheckBox.Location = new System.Drawing.Point(18, 132);
         this.CreateSeriesFolderCheckBox.Name = "CreateSeriesFolderCheckBox";
         this.CreateSeriesFolderCheckBox.Size = new System.Drawing.Size(121, 17);
         this.CreateSeriesFolderCheckBox.TabIndex = 10;
         this.CreateSeriesFolderCheckBox.Text = "Create Series Folder";
         this.CreateSeriesFolderCheckBox.UseVisualStyleBackColor = true;
         // 
         // CreateStudyFolderCheckBox
         // 
         this.CreateStudyFolderCheckBox.AutoSize = true;
         this.CreateStudyFolderCheckBox.Location = new System.Drawing.Point(18, 108);
         this.CreateStudyFolderCheckBox.Name = "CreateStudyFolderCheckBox";
         this.CreateStudyFolderCheckBox.Size = new System.Drawing.Size(119, 17);
         this.CreateStudyFolderCheckBox.TabIndex = 9;
         this.CreateStudyFolderCheckBox.Text = "Create Study Folder";
         this.CreateStudyFolderCheckBox.UseVisualStyleBackColor = true;
         // 
         // CreatepatientFolderCheckBox
         // 
         this.CreatepatientFolderCheckBox.AutoSize = true;
         this.CreatepatientFolderCheckBox.Location = new System.Drawing.Point(18, 12);
         this.CreatepatientFolderCheckBox.Name = "CreatepatientFolderCheckBox";
         this.CreatepatientFolderCheckBox.Size = new System.Drawing.Size(125, 17);
         this.CreatepatientFolderCheckBox.TabIndex = 8;
         this.CreatepatientFolderCheckBox.Text = "Create Patient Folder";
         this.CreatepatientFolderCheckBox.UseVisualStyleBackColor = true;
         // 
         // tabPageImages
         // 
         this.tabPageImages.Controls.Add(this.groupBox1);
         this.tabPageImages.Controls.Add(this.CreateThumbCheckBox);
         this.tabPageImages.Controls.Add(this.CreateThumbGroupBox);
         this.tabPageImages.Location = new System.Drawing.Point(4, 22);
         this.tabPageImages.Name = "tabPageImages";
         this.tabPageImages.Padding = new System.Windows.Forms.Padding(3);
         this.tabPageImages.Size = new System.Drawing.Size(652, 424);
         this.tabPageImages.TabIndex = 1;
         this.tabPageImages.Text = "Images";
         this.tabPageImages.UseVisualStyleBackColor = true;
         // 
         // groupBox1
         // 
         this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
         this.groupBox1.Controls.Add(this.toolStripContainer1);
         this.groupBox1.Location = new System.Drawing.Point(9, 145);
         this.groupBox1.Name = "groupBox1";
         this.groupBox1.Size = new System.Drawing.Size(456, 273);
         this.groupBox1.TabIndex = 2;
         this.groupBox1.TabStop = false;
         this.groupBox1.Text = "Generate Images:";
         // 
         // toolStripContainer1
         // 
         // 
         // toolStripContainer1.ContentPanel
         // 
         this.toolStripContainer1.ContentPanel.Controls.Add(this.generateImagesListView);
         this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(450, 229);
         this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
         this.toolStripContainer1.Location = new System.Drawing.Point(3, 16);
         this.toolStripContainer1.Name = "toolStripContainer1";
         this.toolStripContainer1.Size = new System.Drawing.Size(450, 254);
         this.toolStripContainer1.TabIndex = 20;
         this.toolStripContainer1.Text = "toolStripContainer1";
         // 
         // toolStripContainer1.TopToolStripPanel
         // 
         this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.toolStrip1);
         // 
         // generateImagesListView
         // 
         this.generateImagesListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ImageWidth,
            this.ImageHeight,
            this.QualityFactor,
            this.ImageFormat});
         this.generateImagesListView.Dock = System.Windows.Forms.DockStyle.Fill;
         this.generateImagesListView.FullRowSelect = true;
         this.generateImagesListView.GridLines = true;
         this.generateImagesListView.Location = new System.Drawing.Point(0, 0);
         this.generateImagesListView.Name = "generateImagesListView";
         this.generateImagesListView.Size = new System.Drawing.Size(450, 229);
         this.generateImagesListView.TabIndex = 0;
         this.generateImagesListView.UseCompatibleStateImageBehavior = false;
         this.generateImagesListView.View = System.Windows.Forms.View.Details;
         // 
         // ImageWidth
         // 
         this.ImageWidth.Text = "Width";
         // 
         // ImageHeight
         // 
         this.ImageHeight.Text = "Height";
         // 
         // QualityFactor
         // 
         this.QualityFactor.Text = "Quality Factor";
         this.QualityFactor.Width = 82;
         // 
         // ImageFormat
         // 
         this.ImageFormat.Text = "Format";
         this.ImageFormat.Width = 105;
         // 
         // toolStrip1
         // 
         this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
         this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
         this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddImageToolStripButton,
            this.EditToolStripButton,
            this.DeleteToolStripButton});
         this.toolStrip1.Location = new System.Drawing.Point(0, 0);
         this.toolStrip1.Name = "toolStrip1";
         this.toolStrip1.Size = new System.Drawing.Size(450, 25);
         this.toolStrip1.Stretch = true;
         this.toolStrip1.TabIndex = 0;
         // 
         // AddImageToolStripButton
         // 
         this.AddImageToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
         this.AddImageToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("AddImageToolStripButton.Image")));
         this.AddImageToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
         this.AddImageToolStripButton.Name = "AddImageToolStripButton";
         this.AddImageToolStripButton.Size = new System.Drawing.Size(33, 22);
         this.AddImageToolStripButton.Text = "Add";
         // 
         // EditToolStripButton
         // 
         this.EditToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
         this.EditToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("EditToolStripButton.Image")));
         this.EditToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
         this.EditToolStripButton.Name = "EditToolStripButton";
         this.EditToolStripButton.Size = new System.Drawing.Size(31, 22);
         this.EditToolStripButton.Text = "Edit";
         // 
         // DeleteToolStripButton
         // 
         this.DeleteToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
         this.DeleteToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("DeleteToolStripButton.Image")));
         this.DeleteToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
         this.DeleteToolStripButton.Name = "DeleteToolStripButton";
         this.DeleteToolStripButton.Size = new System.Drawing.Size(44, 22);
         this.DeleteToolStripButton.Text = "Delete";
         // 
         // CreateThumbCheckBox
         // 
         this.CreateThumbCheckBox.AutoSize = true;
         this.CreateThumbCheckBox.Location = new System.Drawing.Point(18, 12);
         this.CreateThumbCheckBox.Name = "CreateThumbCheckBox";
         this.CreateThumbCheckBox.Size = new System.Drawing.Size(141, 17);
         this.CreateThumbCheckBox.TabIndex = 1;
         this.CreateThumbCheckBox.Text = "Create Thumbnail Image";
         this.CreateThumbCheckBox.UseVisualStyleBackColor = true;
         // 
         // CreateThumbGroupBox
         // 
         this.CreateThumbGroupBox.Controls.Add(this.ThumbQFactorNumeric);
         this.CreateThumbGroupBox.Controls.Add(this.ThumbHeightNumeric);
         this.CreateThumbGroupBox.Controls.Add(this.ThumbWidthNumeric);
         this.CreateThumbGroupBox.Controls.Add(this.ThumbImageWidthLabel);
         this.CreateThumbGroupBox.Controls.Add(this.ImageFormatTabel);
         this.CreateThumbGroupBox.Controls.Add(this.ThumbFormatComboBox);
         this.CreateThumbGroupBox.Controls.Add(this.label3);
         this.CreateThumbGroupBox.Controls.Add(this.ThumbImageHeightLabel);
         this.CreateThumbGroupBox.Location = new System.Drawing.Point(12, 14);
         this.CreateThumbGroupBox.Name = "CreateThumbGroupBox";
         this.CreateThumbGroupBox.Size = new System.Drawing.Size(450, 104);
         this.CreateThumbGroupBox.TabIndex = 0;
         this.CreateThumbGroupBox.TabStop = false;
         // 
         // ThumbQFactorNumeric
         // 
         this.ThumbQFactorNumeric.Location = new System.Drawing.Point(228, 23);
         this.ThumbQFactorNumeric.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
         this.ThumbQFactorNumeric.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
         this.ThumbQFactorNumeric.Name = "ThumbQFactorNumeric";
         this.ThumbQFactorNumeric.Size = new System.Drawing.Size(80, 20);
         this.ThumbQFactorNumeric.TabIndex = 5;
         this.ThumbQFactorNumeric.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
         // 
         // ThumbHeightNumeric
         // 
         this.ThumbHeightNumeric.Location = new System.Drawing.Point(67, 55);
         this.ThumbHeightNumeric.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
         this.ThumbHeightNumeric.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
         this.ThumbHeightNumeric.Name = "ThumbHeightNumeric";
         this.ThumbHeightNumeric.Size = new System.Drawing.Size(58, 20);
         this.ThumbHeightNumeric.TabIndex = 3;
         this.ThumbHeightNumeric.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
         // 
         // ThumbWidthNumeric
         // 
         this.ThumbWidthNumeric.Location = new System.Drawing.Point(67, 23);
         this.ThumbWidthNumeric.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
         this.ThumbWidthNumeric.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
         this.ThumbWidthNumeric.Name = "ThumbWidthNumeric";
         this.ThumbWidthNumeric.Size = new System.Drawing.Size(58, 20);
         this.ThumbWidthNumeric.TabIndex = 1;
         this.ThumbWidthNumeric.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
         // 
         // ThumbImageWidthLabel
         // 
         this.ThumbImageWidthLabel.AutoSize = true;
         this.ThumbImageWidthLabel.Location = new System.Drawing.Point(24, 27);
         this.ThumbImageWidthLabel.Name = "ThumbImageWidthLabel";
         this.ThumbImageWidthLabel.Size = new System.Drawing.Size(38, 13);
         this.ThumbImageWidthLabel.TabIndex = 0;
         this.ThumbImageWidthLabel.Text = "Width:";
         // 
         // ImageFormatTabel
         // 
         this.ImageFormatTabel.AutoSize = true;
         this.ImageFormatTabel.Location = new System.Drawing.Point(181, 59);
         this.ImageFormatTabel.Name = "ImageFormatTabel";
         this.ImageFormatTabel.Size = new System.Drawing.Size(42, 13);
         this.ImageFormatTabel.TabIndex = 6;
         this.ImageFormatTabel.Text = "Format:";
         // 
         // ThumbFormatComboBox
         // 
         this.ThumbFormatComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.ThumbFormatComboBox.FormattingEnabled = true;
         this.ThumbFormatComboBox.Location = new System.Drawing.Point(228, 55);
         this.ThumbFormatComboBox.Name = "ThumbFormatComboBox";
         this.ThumbFormatComboBox.Size = new System.Drawing.Size(80, 21);
         this.ThumbFormatComboBox.TabIndex = 7;
         // 
         // label3
         // 
         this.label3.AutoSize = true;
         this.label3.Location = new System.Drawing.Point(148, 27);
         this.label3.Name = "label3";
         this.label3.Size = new System.Drawing.Size(75, 13);
         this.label3.TabIndex = 4;
         this.label3.Text = "Quality Factor:";
         // 
         // ThumbImageHeightLabel
         // 
         this.ThumbImageHeightLabel.AutoSize = true;
         this.ThumbImageHeightLabel.Location = new System.Drawing.Point(21, 59);
         this.ThumbImageHeightLabel.Name = "ThumbImageHeightLabel";
         this.ThumbImageHeightLabel.Size = new System.Drawing.Size(41, 13);
         this.ThumbImageHeightLabel.TabIndex = 2;
         this.ThumbImageHeightLabel.Text = "Height:";
         // 
         // tabPageOptions
         // 
         this.tabPageOptions.Controls.Add(this.UseMessageQueueCheckBox);
         this.tabPageOptions.Controls.Add(this.AutoTruncateDataCheckBox);
         this.tabPageOptions.Controls.Add(this.DeleteAnnotationCheckBox);
         this.tabPageOptions.Controls.Add(this.DatabaseOptionsGroupBox);
         this.tabPageOptions.Controls.Add(this.PreventDuplicateSOPCheckBox);
         this.tabPageOptions.Location = new System.Drawing.Point(4, 22);
         this.tabPageOptions.Name = "tabPageOptions";
         this.tabPageOptions.Padding = new System.Windows.Forms.Padding(3);
         this.tabPageOptions.Size = new System.Drawing.Size(652, 424);
         this.tabPageOptions.TabIndex = 2;
         this.tabPageOptions.Text = "Options";
         this.tabPageOptions.UseVisualStyleBackColor = true;
         // 
         // UseMessageQueueCheckBox
         // 
         this.UseMessageQueueCheckBox.AutoSize = true;
         this.UseMessageQueueCheckBox.Location = new System.Drawing.Point(18, 234);
         this.UseMessageQueueCheckBox.Name = "UseMessageQueueCheckBox";
         this.UseMessageQueueCheckBox.Size = new System.Drawing.Size(126, 17);
         this.UseMessageQueueCheckBox.TabIndex = 4;
         this.UseMessageQueueCheckBox.Text = "Use Message Queue";
         this.UseMessageQueueCheckBox.UseVisualStyleBackColor = true;
         // 
         // AutoTruncateDataCheckBox
         // 
         this.AutoTruncateDataCheckBox.AutoSize = true;
         this.AutoTruncateDataCheckBox.Location = new System.Drawing.Point(18, 203);
         this.AutoTruncateDataCheckBox.Name = "AutoTruncateDataCheckBox";
         this.AutoTruncateDataCheckBox.Size = new System.Drawing.Size(120, 17);
         this.AutoTruncateDataCheckBox.TabIndex = 2;
         this.AutoTruncateDataCheckBox.Text = "Auto Truncate Data";
         this.AutoTruncateDataCheckBox.UseVisualStyleBackColor = true;
         // 
         // DeleteAnnotationCheckBox
         // 
         this.DeleteAnnotationCheckBox.AutoSize = true;
         this.DeleteAnnotationCheckBox.Location = new System.Drawing.Point(18, 265);
         this.DeleteAnnotationCheckBox.Name = "DeleteAnnotationCheckBox";
         this.DeleteAnnotationCheckBox.Size = new System.Drawing.Size(144, 17);
         this.DeleteAnnotationCheckBox.TabIndex = 3;
         this.DeleteAnnotationCheckBox.Text = "Allow Delete Annotations";
         this.DeleteAnnotationCheckBox.UseVisualStyleBackColor = true;
         // 
         // DatabaseOptionsGroupBox
         // 
         this.DatabaseOptionsGroupBox.Controls.Add(this.UpdateInstanceCheckBox);
         this.DatabaseOptionsGroupBox.Controls.Add(this.UpdateSeriesCheckBox);
         this.DatabaseOptionsGroupBox.Controls.Add(this.UpdateStudyCheckBox);
         this.DatabaseOptionsGroupBox.Controls.Add(this.UpdatePatientCheckBox);
         this.DatabaseOptionsGroupBox.Location = new System.Drawing.Point(8, 50);
         this.DatabaseOptionsGroupBox.Name = "DatabaseOptionsGroupBox";
         this.DatabaseOptionsGroupBox.Size = new System.Drawing.Size(237, 136);
         this.DatabaseOptionsGroupBox.TabIndex = 1;
         this.DatabaseOptionsGroupBox.TabStop = false;
         this.DatabaseOptionsGroupBox.Text = "Update Options";
         // 
         // UpdateInstanceCheckBox
         // 
         this.UpdateInstanceCheckBox.AutoSize = true;
         this.UpdateInstanceCheckBox.Location = new System.Drawing.Point(10, 107);
         this.UpdateInstanceCheckBox.Name = "UpdateInstanceCheckBox";
         this.UpdateInstanceCheckBox.Size = new System.Drawing.Size(144, 17);
         this.UpdateInstanceCheckBox.TabIndex = 3;
         this.UpdateInstanceCheckBox.Text = "Update Existing Instance";
         this.UpdateInstanceCheckBox.UseVisualStyleBackColor = true;
         // 
         // UpdateSeriesCheckBox
         // 
         this.UpdateSeriesCheckBox.AutoSize = true;
         this.UpdateSeriesCheckBox.Location = new System.Drawing.Point(10, 79);
         this.UpdateSeriesCheckBox.Name = "UpdateSeriesCheckBox";
         this.UpdateSeriesCheckBox.Size = new System.Drawing.Size(132, 17);
         this.UpdateSeriesCheckBox.TabIndex = 2;
         this.UpdateSeriesCheckBox.Text = "Update Existing Series";
         this.UpdateSeriesCheckBox.UseVisualStyleBackColor = true;
         // 
         // UpdateStudyCheckBox
         // 
         this.UpdateStudyCheckBox.AutoSize = true;
         this.UpdateStudyCheckBox.Location = new System.Drawing.Point(10, 51);
         this.UpdateStudyCheckBox.Name = "UpdateStudyCheckBox";
         this.UpdateStudyCheckBox.Size = new System.Drawing.Size(130, 17);
         this.UpdateStudyCheckBox.TabIndex = 1;
         this.UpdateStudyCheckBox.Text = "Update Existing Study";
         this.UpdateStudyCheckBox.UseVisualStyleBackColor = true;
         // 
         // UpdatePatientCheckBox
         // 
         this.UpdatePatientCheckBox.AutoSize = true;
         this.UpdatePatientCheckBox.Location = new System.Drawing.Point(10, 23);
         this.UpdatePatientCheckBox.Name = "UpdatePatientCheckBox";
         this.UpdatePatientCheckBox.Size = new System.Drawing.Size(136, 17);
         this.UpdatePatientCheckBox.TabIndex = 0;
         this.UpdatePatientCheckBox.Text = "Update Existing Patient";
         this.UpdatePatientCheckBox.UseVisualStyleBackColor = true;
         // 
         // PreventDuplicateSOPCheckBox
         // 
         this.PreventDuplicateSOPCheckBox.AutoSize = true;
         this.PreventDuplicateSOPCheckBox.Location = new System.Drawing.Point(18, 12);
         this.PreventDuplicateSOPCheckBox.Name = "PreventDuplicateSOPCheckBox";
         this.PreventDuplicateSOPCheckBox.Size = new System.Drawing.Size(216, 17);
         this.PreventDuplicateSOPCheckBox.TabIndex = 0;
         this.PreventDuplicateSOPCheckBox.Text = "Prevent Storing Duplicate SOP Instance";
         this.PreventDuplicateSOPCheckBox.UseVisualStyleBackColor = true;
         // 
         // tabPageMetadata
         // 
         this.tabPageMetadata.Controls.Add(this.labelStatus);
         this.tabPageMetadata.Controls.Add(this.groupBoxXmlMetadataOptions);
         this.tabPageMetadata.Controls.Add(this.groupBoxJsonMetadataOptions);
         this.tabPageMetadata.Location = new System.Drawing.Point(4, 22);
         this.tabPageMetadata.Name = "tabPageMetadata";
         this.tabPageMetadata.Size = new System.Drawing.Size(652, 424);
         this.tabPageMetadata.TabIndex = 4;
         this.tabPageMetadata.Text = "Metadata";
         this.tabPageMetadata.UseVisualStyleBackColor = true;
         // 
         // labelStatus
         // 
         this.labelStatus.AutoSize = true;
         this.labelStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
         this.labelStatus.Location = new System.Drawing.Point(21, 308);
         this.labelStatus.Name = "labelStatus";
         this.labelStatus.Size = new System.Drawing.Size(59, 13);
         this.labelStatus.TabIndex = 2;
         this.labelStatus.Text = "labelStatus";
         // 
         // groupBoxXmlMetadataOptions
         // 
         this.groupBoxXmlMetadataOptions.Controls.Add(this.buttonXmlGenerateMissing);
         this.groupBoxXmlMetadataOptions.Controls.Add(this.buttonXmlStopGenerate);
         this.groupBoxXmlMetadataOptions.Controls.Add(this.buttonXmlGenerateAll);
         this.groupBoxXmlMetadataOptions.Controls.Add(this.buttonXmlDeleteAll);
         this.groupBoxXmlMetadataOptions.Controls.Add(this.checkBoxXmlIgnoreBinaryData);
         this.groupBoxXmlMetadataOptions.Controls.Add(this.checkBoxXmlFullEndStatement);
         this.groupBoxXmlMetadataOptions.Controls.Add(this.checkBoxXmlTrimWhiteSpace);
         this.groupBoxXmlMetadataOptions.Controls.Add(this.checkBoxXmlStore);
         this.groupBoxXmlMetadataOptions.Location = new System.Drawing.Point(288, 12);
         this.groupBoxXmlMetadataOptions.Name = "groupBoxXmlMetadataOptions";
         this.groupBoxXmlMetadataOptions.Size = new System.Drawing.Size(250, 275);
         this.groupBoxXmlMetadataOptions.TabIndex = 1;
         this.groupBoxXmlMetadataOptions.TabStop = false;
         this.groupBoxXmlMetadataOptions.Text = "XML (Native DICOM Model) Metadata Options";
         // 
         // buttonXmlGenerateMissing
         // 
         this.buttonXmlGenerateMissing.Location = new System.Drawing.Point(6, 182);
         this.buttonXmlGenerateMissing.Name = "buttonXmlGenerateMissing";
         this.buttonXmlGenerateMissing.Size = new System.Drawing.Size(206, 23);
         this.buttonXmlGenerateMissing.TabIndex = 5;
         this.buttonXmlGenerateMissing.Text = "Generate Missing XML Metadata...";
         this.buttonXmlGenerateMissing.UseVisualStyleBackColor = true;
         // 
         // buttonXmlStopGenerate
         // 
         this.buttonXmlStopGenerate.Location = new System.Drawing.Point(6, 244);
         this.buttonXmlStopGenerate.Name = "buttonXmlStopGenerate";
         this.buttonXmlStopGenerate.Size = new System.Drawing.Size(206, 23);
         this.buttonXmlStopGenerate.TabIndex = 7;
         this.buttonXmlStopGenerate.Text = "Stop Generate XML Metadata...";
         this.buttonXmlStopGenerate.UseVisualStyleBackColor = true;
         // 
         // buttonXmlGenerateAll
         // 
         this.buttonXmlGenerateAll.Location = new System.Drawing.Point(6, 213);
         this.buttonXmlGenerateAll.Name = "buttonXmlGenerateAll";
         this.buttonXmlGenerateAll.Size = new System.Drawing.Size(206, 23);
         this.buttonXmlGenerateAll.TabIndex = 6;
         this.buttonXmlGenerateAll.Text = "Generate All XML Metadata...";
         this.buttonXmlGenerateAll.UseVisualStyleBackColor = true;
         // 
         // buttonXmlDeleteAll
         // 
         this.buttonXmlDeleteAll.Location = new System.Drawing.Point(6, 151);
         this.buttonXmlDeleteAll.Name = "buttonXmlDeleteAll";
         this.buttonXmlDeleteAll.Size = new System.Drawing.Size(206, 23);
         this.buttonXmlDeleteAll.TabIndex = 4;
         this.buttonXmlDeleteAll.Text = "Delete XML Metadata...";
         this.buttonXmlDeleteAll.UseVisualStyleBackColor = true;
         // 
         // checkBoxXmlIgnoreBinaryData
         // 
         this.checkBoxXmlIgnoreBinaryData.AutoSize = true;
         this.checkBoxXmlIgnoreBinaryData.Location = new System.Drawing.Point(28, 95);
         this.checkBoxXmlIgnoreBinaryData.Name = "checkBoxXmlIgnoreBinaryData";
         this.checkBoxXmlIgnoreBinaryData.Size = new System.Drawing.Size(114, 17);
         this.checkBoxXmlIgnoreBinaryData.TabIndex = 3;
         this.checkBoxXmlIgnoreBinaryData.Text = "Ignore Binary Data";
         this.checkBoxXmlIgnoreBinaryData.UseVisualStyleBackColor = true;
         this.checkBoxXmlIgnoreBinaryData.Visible = false;
         // 
         // checkBoxXmlFullEndStatement
         // 
         this.checkBoxXmlFullEndStatement.AutoSize = true;
         this.checkBoxXmlFullEndStatement.Location = new System.Drawing.Point(28, 71);
         this.checkBoxXmlFullEndStatement.Name = "checkBoxXmlFullEndStatement";
         this.checkBoxXmlFullEndStatement.Size = new System.Drawing.Size(143, 17);
         this.checkBoxXmlFullEndStatement.TabIndex = 2;
         this.checkBoxXmlFullEndStatement.Text = "Write Full End Statement";
         this.checkBoxXmlFullEndStatement.UseVisualStyleBackColor = true;
         // 
         // checkBoxXmlTrimWhiteSpace
         // 
         this.checkBoxXmlTrimWhiteSpace.AutoSize = true;
         this.checkBoxXmlTrimWhiteSpace.Location = new System.Drawing.Point(28, 47);
         this.checkBoxXmlTrimWhiteSpace.Name = "checkBoxXmlTrimWhiteSpace";
         this.checkBoxXmlTrimWhiteSpace.Size = new System.Drawing.Size(111, 17);
         this.checkBoxXmlTrimWhiteSpace.TabIndex = 1;
         this.checkBoxXmlTrimWhiteSpace.Text = "Trim White Space";
         this.checkBoxXmlTrimWhiteSpace.UseVisualStyleBackColor = true;
         // 
         // checkBoxXmlStore
         // 
         this.checkBoxXmlStore.AutoSize = true;
         this.checkBoxXmlStore.Location = new System.Drawing.Point(6, 23);
         this.checkBoxXmlStore.Name = "checkBoxXmlStore";
         this.checkBoxXmlStore.Size = new System.Drawing.Size(76, 17);
         this.checkBoxXmlStore.TabIndex = 0;
         this.checkBoxXmlStore.Text = "Store XML";
         this.checkBoxXmlStore.UseVisualStyleBackColor = true;
         // 
         // groupBoxJsonMetadataOptions
         // 
         this.groupBoxJsonMetadataOptions.Controls.Add(this.buttonJsonGenerateMissing);
         this.groupBoxJsonMetadataOptions.Controls.Add(this.buttonJsonStopGenerate);
         this.groupBoxJsonMetadataOptions.Controls.Add(this.buttonJsonGenerateAll);
         this.groupBoxJsonMetadataOptions.Controls.Add(this.buttonJsonDeleteAll);
         this.groupBoxJsonMetadataOptions.Controls.Add(this.checkBoxJsonIgnoreBinaryData);
         this.groupBoxJsonMetadataOptions.Controls.Add(this.checkBoxJsonMinify);
         this.groupBoxJsonMetadataOptions.Controls.Add(this.checkBoxJsonWriteKeyword);
         this.groupBoxJsonMetadataOptions.Controls.Add(this.checkBoxJsonTrimWhiteSpace);
         this.groupBoxJsonMetadataOptions.Controls.Add(this.checkBoxJsonStore);
         this.groupBoxJsonMetadataOptions.Location = new System.Drawing.Point(18, 12);
         this.groupBoxJsonMetadataOptions.Name = "groupBoxJsonMetadataOptions";
         this.groupBoxJsonMetadataOptions.Size = new System.Drawing.Size(250, 275);
         this.groupBoxJsonMetadataOptions.TabIndex = 0;
         this.groupBoxJsonMetadataOptions.TabStop = false;
         this.groupBoxJsonMetadataOptions.Text = "JSON (DICOM JSON Model) Metadata Options";
         // 
         // buttonJsonGenerateMissing
         // 
         this.buttonJsonGenerateMissing.Location = new System.Drawing.Point(6, 182);
         this.buttonJsonGenerateMissing.Name = "buttonJsonGenerateMissing";
         this.buttonJsonGenerateMissing.Size = new System.Drawing.Size(206, 23);
         this.buttonJsonGenerateMissing.TabIndex = 6;
         this.buttonJsonGenerateMissing.Text = "Generate Missing JSON Metadata...";
         this.buttonJsonGenerateMissing.UseVisualStyleBackColor = true;
         // 
         // buttonJsonStopGenerate
         // 
         this.buttonJsonStopGenerate.Location = new System.Drawing.Point(6, 244);
         this.buttonJsonStopGenerate.Name = "buttonJsonStopGenerate";
         this.buttonJsonStopGenerate.Size = new System.Drawing.Size(206, 23);
         this.buttonJsonStopGenerate.TabIndex = 8;
         this.buttonJsonStopGenerate.Text = "Stop Generate JSON Metadata...";
         this.buttonJsonStopGenerate.UseVisualStyleBackColor = true;
         // 
         // buttonJsonGenerateAll
         // 
         this.buttonJsonGenerateAll.Location = new System.Drawing.Point(6, 213);
         this.buttonJsonGenerateAll.Name = "buttonJsonGenerateAll";
         this.buttonJsonGenerateAll.Size = new System.Drawing.Size(206, 23);
         this.buttonJsonGenerateAll.TabIndex = 7;
         this.buttonJsonGenerateAll.Text = "Generate All JSON Metadata...";
         this.buttonJsonGenerateAll.UseVisualStyleBackColor = true;
         // 
         // buttonJsonDeleteAll
         // 
         this.buttonJsonDeleteAll.Location = new System.Drawing.Point(6, 151);
         this.buttonJsonDeleteAll.Name = "buttonJsonDeleteAll";
         this.buttonJsonDeleteAll.Size = new System.Drawing.Size(206, 23);
         this.buttonJsonDeleteAll.TabIndex = 5;
         this.buttonJsonDeleteAll.Text = "Delete JSON Metadata...";
         this.buttonJsonDeleteAll.UseVisualStyleBackColor = true;
         // 
         // checkBoxJsonIgnoreBinaryData
         // 
         this.checkBoxJsonIgnoreBinaryData.AutoSize = true;
         this.checkBoxJsonIgnoreBinaryData.Location = new System.Drawing.Point(27, 119);
         this.checkBoxJsonIgnoreBinaryData.Name = "checkBoxJsonIgnoreBinaryData";
         this.checkBoxJsonIgnoreBinaryData.Size = new System.Drawing.Size(114, 17);
         this.checkBoxJsonIgnoreBinaryData.TabIndex = 4;
         this.checkBoxJsonIgnoreBinaryData.Text = "Ignore Binary Data";
         this.checkBoxJsonIgnoreBinaryData.UseVisualStyleBackColor = true;
         this.checkBoxJsonIgnoreBinaryData.Visible = false;
         // 
         // checkBoxJsonMinify
         // 
         this.checkBoxJsonMinify.AutoSize = true;
         this.checkBoxJsonMinify.Location = new System.Drawing.Point(27, 95);
         this.checkBoxJsonMinify.Name = "checkBoxJsonMinify";
         this.checkBoxJsonMinify.Size = new System.Drawing.Size(53, 17);
         this.checkBoxJsonMinify.TabIndex = 3;
         this.checkBoxJsonMinify.Text = "Minify";
         this.checkBoxJsonMinify.UseVisualStyleBackColor = true;
         // 
         // checkBoxJsonWriteKeyword
         // 
         this.checkBoxJsonWriteKeyword.AutoSize = true;
         this.checkBoxJsonWriteKeyword.Location = new System.Drawing.Point(27, 71);
         this.checkBoxJsonWriteKeyword.Name = "checkBoxJsonWriteKeyword";
         this.checkBoxJsonWriteKeyword.Size = new System.Drawing.Size(95, 17);
         this.checkBoxJsonWriteKeyword.TabIndex = 2;
         this.checkBoxJsonWriteKeyword.Text = "Write Keyword";
         this.checkBoxJsonWriteKeyword.UseVisualStyleBackColor = true;
         // 
         // checkBoxJsonTrimWhiteSpace
         // 
         this.checkBoxJsonTrimWhiteSpace.AutoSize = true;
         this.checkBoxJsonTrimWhiteSpace.Location = new System.Drawing.Point(27, 47);
         this.checkBoxJsonTrimWhiteSpace.Name = "checkBoxJsonTrimWhiteSpace";
         this.checkBoxJsonTrimWhiteSpace.Size = new System.Drawing.Size(111, 17);
         this.checkBoxJsonTrimWhiteSpace.TabIndex = 1;
         this.checkBoxJsonTrimWhiteSpace.Text = "Trim White Space";
         this.checkBoxJsonTrimWhiteSpace.UseVisualStyleBackColor = true;
         // 
         // checkBoxJsonStore
         // 
         this.checkBoxJsonStore.AutoSize = true;
         this.checkBoxJsonStore.Location = new System.Drawing.Point(6, 23);
         this.checkBoxJsonStore.Name = "checkBoxJsonStore";
         this.checkBoxJsonStore.Size = new System.Drawing.Size(82, 17);
         this.checkBoxJsonStore.TabIndex = 0;
         this.checkBoxJsonStore.Text = "Store JSON";
         this.checkBoxJsonStore.UseVisualStyleBackColor = true;
         // 
         // errorProvider
         // 
         this.errorProvider.ContainerControl = this;
         // 
         // StorageOptionsView
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.Controls.Add(this.tabControlStorageOptions);
         this.Name = "StorageOptionsView";
         this.Size = new System.Drawing.Size(660, 450);
         this.tabControlStorageOptions.ResumeLayout(false);
         this.tabPageFiles.ResumeLayout(false);
         this.StoreFileSettingsGoupBox.ResumeLayout(false);
         this.StoreFileSettingsGoupBox.PerformLayout();
         this.OverwriteSettingsGroupBox.ResumeLayout(false);
         this.OverwriteSettingsGroupBox.PerformLayout();
         this.StoreFailureGroupBox.ResumeLayout(false);
         this.StoreFailureGroupBox.PerformLayout();
         this.groupBoxDeleteSettings.ResumeLayout(false);
         this.groupBoxDeleteSettings.PerformLayout();
         this.tabPageDirectoryStructure.ResumeLayout(false);
         this.tabPageDirectoryStructure.PerformLayout();
         this.tabPageImages.ResumeLayout(false);
         this.tabPageImages.PerformLayout();
         this.groupBox1.ResumeLayout(false);
         this.toolStripContainer1.ContentPanel.ResumeLayout(false);
         this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
         this.toolStripContainer1.TopToolStripPanel.PerformLayout();
         this.toolStripContainer1.ResumeLayout(false);
         this.toolStripContainer1.PerformLayout();
         this.toolStrip1.ResumeLayout(false);
         this.toolStrip1.PerformLayout();
         this.CreateThumbGroupBox.ResumeLayout(false);
         this.CreateThumbGroupBox.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this.ThumbQFactorNumeric)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.ThumbHeightNumeric)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.ThumbWidthNumeric)).EndInit();
         this.tabPageOptions.ResumeLayout(false);
         this.tabPageOptions.PerformLayout();
         this.DatabaseOptionsGroupBox.ResumeLayout(false);
         this.DatabaseOptionsGroupBox.PerformLayout();
         this.tabPageMetadata.ResumeLayout(false);
         this.tabPageMetadata.PerformLayout();
         this.groupBoxXmlMetadataOptions.ResumeLayout(false);
         this.groupBoxXmlMetadataOptions.PerformLayout();
         this.groupBoxJsonMetadataOptions.ResumeLayout(false);
         this.groupBoxJsonMetadataOptions.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.TabControl tabControlStorageOptions;
      private System.Windows.Forms.TabPage tabPageFiles;
      private System.Windows.Forms.TabPage tabPageImages;
      private System.Windows.Forms.GroupBox groupBoxDeleteSettings;
      private System.Windows.Forms.Button BrowseDeleteFileBackupLocationButton;
      private System.Windows.Forms.TextBox DeleteBackupLocationTextBox;
      private System.Windows.Forms.CheckBox DeleteFilesCheckBox;
      private System.Windows.Forms.GroupBox StoreFailureGroupBox;
      private System.Windows.Forms.Button BrowseCStoreFailuresButton;
      private System.Windows.Forms.TextBox CStoreFailuresTextBox;
      private System.Windows.Forms.GroupBox OverwriteSettingsGroupBox;
      private System.Windows.Forms.Button BrowseBackupLocationButton;
      private System.Windows.Forms.TextBox OverwriteBackupLocationTextBox;
      private System.Windows.Forms.Label BackupLocationLabel;
      private System.Windows.Forms.CheckBox CreateBackupCheckBox;
      private System.Windows.Forms.CheckBox SaveCStoreFailuresCheckBox;
      private System.Windows.Forms.GroupBox StoreFileSettingsGoupBox;
      private System.Windows.Forms.TextBox FileExtTextBox;
      private System.Windows.Forms.Label DICOMFileExtLabel;
      private System.Windows.Forms.Button BrowseStorageLocationButton;
      private System.Windows.Forms.TextBox StorageLocationTextBox;
      private System.Windows.Forms.Label StorageLocationLabel;
      private System.Windows.Forms.CheckBox CreateThumbCheckBox;
      private System.Windows.Forms.GroupBox CreateThumbGroupBox;
      private System.Windows.Forms.NumericUpDown ThumbQFactorNumeric;
      private System.Windows.Forms.NumericUpDown ThumbHeightNumeric;
      private System.Windows.Forms.NumericUpDown ThumbWidthNumeric;
      private System.Windows.Forms.Label ThumbImageWidthLabel;
      private System.Windows.Forms.Label ImageFormatTabel;
      private System.Windows.Forms.ComboBox ThumbFormatComboBox;
      private System.Windows.Forms.Label label3;
      private System.Windows.Forms.Label ThumbImageHeightLabel;
      private System.Windows.Forms.GroupBox groupBox1;
      private System.Windows.Forms.ToolStripContainer toolStripContainer1;
      private System.Windows.Forms.ListView generateImagesListView;
      private System.Windows.Forms.ColumnHeader ImageWidth;
      private System.Windows.Forms.ColumnHeader ImageHeight;
      private System.Windows.Forms.ColumnHeader QualityFactor;
      private System.Windows.Forms.ColumnHeader ImageFormat;
      private System.Windows.Forms.ToolStrip toolStrip1;
      private System.Windows.Forms.ToolStripButton AddImageToolStripButton;
      private System.Windows.Forms.ToolStripButton EditToolStripButton;
      private System.Windows.Forms.ToolStripButton DeleteToolStripButton;
      private System.Windows.Forms.TabPage tabPageOptions;
      private System.Windows.Forms.CheckBox PreventDuplicateSOPCheckBox;
      private System.Windows.Forms.GroupBox DatabaseOptionsGroupBox;
      private System.Windows.Forms.CheckBox UpdateInstanceCheckBox;
      private System.Windows.Forms.CheckBox UpdateSeriesCheckBox;
      private System.Windows.Forms.CheckBox UpdateStudyCheckBox;
      private System.Windows.Forms.CheckBox UpdatePatientCheckBox;
      private System.Windows.Forms.CheckBox AutoTruncateDataCheckBox;
      private System.Windows.Forms.CheckBox DeleteAnnotationCheckBox;
      private System.Windows.Forms.Label StoreFailureLabel;
      private System.Windows.Forms.TabPage tabPageDirectoryStructure;
      private System.Windows.Forms.FolderBrowserDialog StorageLocationBrowserDialog;
      private System.Windows.Forms.CheckBox BackupFilesOnDeleteCheckBox;
      private System.Windows.Forms.Label DeleteBackupLocationLabel;
      private System.Windows.Forms.ErrorProvider errorProvider;
      private System.Windows.Forms.CheckBox SplitPatientIdCheckBox;
      private System.Windows.Forms.RadioButton UsePatientNameRadioButton;
      private System.Windows.Forms.RadioButton UsePatientIdRadioButton;
      private System.Windows.Forms.CheckBox CreateSeriesFolderCheckBox;
      private System.Windows.Forms.CheckBox CreateStudyFolderCheckBox;
      private System.Windows.Forms.CheckBox CreatepatientFolderCheckBox;
      private System.Windows.Forms.CheckBox UseMessageQueueCheckBox;
      private System.Windows.Forms.Button BrowseHangingProtocolLocationButton;
      private System.Windows.Forms.TextBox HangingProtocolLocationTextBox;
      private System.Windows.Forms.Label HangingProtocolLocationLabel;
      private System.Windows.Forms.TabPage tabPageMetadata;
      private System.Windows.Forms.GroupBox groupBoxXmlMetadataOptions;
      private System.Windows.Forms.Button buttonXmlGenerateAll;
      private System.Windows.Forms.Button buttonXmlDeleteAll;
      private System.Windows.Forms.CheckBox checkBoxXmlIgnoreBinaryData;
      private System.Windows.Forms.CheckBox checkBoxXmlFullEndStatement;
      private System.Windows.Forms.CheckBox checkBoxXmlTrimWhiteSpace;
      private System.Windows.Forms.CheckBox checkBoxXmlStore;
      private System.Windows.Forms.GroupBox groupBoxJsonMetadataOptions;
      private System.Windows.Forms.Button buttonJsonGenerateAll;
      private System.Windows.Forms.Button buttonJsonDeleteAll;
      private System.Windows.Forms.CheckBox checkBoxJsonIgnoreBinaryData;
      private System.Windows.Forms.CheckBox checkBoxJsonMinify;
      private System.Windows.Forms.CheckBox checkBoxJsonWriteKeyword;
      private System.Windows.Forms.CheckBox checkBoxJsonTrimWhiteSpace;
      private System.Windows.Forms.CheckBox checkBoxJsonStore;
      private System.Windows.Forms.Button buttonXmlStopGenerate;
      private System.Windows.Forms.Button buttonJsonStopGenerate;
      private System.Windows.Forms.Label labelStatus;
      private System.Windows.Forms.Button buttonJsonGenerateMissing;
      private System.Windows.Forms.Button buttonXmlGenerateMissing;
   }
}

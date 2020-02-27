namespace Leadtools.Medical.Storage.AddIns
{
   partial class AddInsConfiguration
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddInsConfiguration));
         this.iodOpenFileDialog = new System.Windows.Forms.OpenFileDialog();
         this.StorageLocationBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
         this.toolStrip1 = new System.Windows.Forms.ToolStrip();
         this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
         this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
         this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
#if (LEADTOOLS_V19_OR_LATER)
         this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
         this.toolStripButton5 = new System.Windows.Forms.ToolStripButton();
#endif // #if (LEADTOOLS_V19_OR_LATER)
         this.panel1 = new System.Windows.Forms.Panel();
         this.storageClassesTabControl1 = new Leadtools.Medical.Winforms.StorageClassesTabControl();
         this.queryOptionsView1 = new Leadtools.Medical.Storage.AddIns.QueryOptionsView();
         this.storageOptionsView1 = new Leadtools.Medical.Storage.AddIns.StorageOptionsView();
#if (LEADTOOLS_V19_OR_LATER)
         this.databaseManagerOptionsView1 = new Leadtools.Medical.Winforms.DatabaseManager.DatabaseManagerOptionsView();
         this.anonymizeOptionsView1 = new Leadtools.Medical.Winforms.Anonymize.AnonymizeOptionsView();
#endif
         this.toolStrip1.SuspendLayout();
         this.panel1.SuspendLayout();
         this.SuspendLayout();
         // 
         // iodOpenFileDialog
         // 
         this.iodOpenFileDialog.FileName = "IOD XML File";
         this.iodOpenFileDialog.Filter = "XML files|*.xml";
         // 
         // toolStrip1
         // 
         this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
         this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripButton2,
            this.toolStripButton3
#if (LEADTOOLS_V19_OR_LATER)
           ,this.toolStripButton4,
            this.toolStripButton5
#endif
            });
         this.toolStrip1.Location = new System.Drawing.Point(0, 0);
         this.toolStrip1.Name = "toolStrip1";
         this.toolStrip1.Size = new System.Drawing.Size(707, 25);
         this.toolStrip1.TabIndex = 4;
         this.toolStrip1.Text = "toolStrip1";
         // 
         // toolStripButton1
         // 
         this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
         this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
         this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
         this.toolStripButton1.Name = "toolStripButton1";
         this.toolStripButton1.Size = new System.Drawing.Size(81, 22);
         this.toolStripButton1.Text = "CStore AddIn";
         this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
         // 
         // toolStripButton2
         // 
         this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
         this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
         this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
         this.toolStripButton2.Name = "toolStripButton2";
         this.toolStripButton2.Size = new System.Drawing.Size(112, 22);
         this.toolStripButton2.Text = "CFind Query AddIn";
         this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
         // 
         // toolStripButton3
         // 
         this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
         this.toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3.Image")));
         this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
         this.toolStripButton3.Name = "toolStripButton3";
         this.toolStripButton3.Size = new System.Drawing.Size(72, 22);
         this.toolStripButton3.Text = "IOD Classes";
         this.toolStripButton3.Click += new System.EventHandler(this.toolStripButton3_Click);

#if (LEADTOOLS_V19_OR_LATER)
         // 
         // toolStripButton4
         // 
         this.toolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
         this.toolStripButton4.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton4.Image")));
         this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
         this.toolStripButton4.Name = "toolStripButton4";
         this.toolStripButton4.Size = new System.Drawing.Size(109, 22);
         this.toolStripButton4.Text = "Database Manager";
         this.toolStripButton4.Click += new System.EventHandler(this.toolStripButton4_Click);
         // 
         // toolStripButton5
         // 
         this.toolStripButton5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
         this.toolStripButton5.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton5.Image")));
         this.toolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta;
         this.toolStripButton5.Name = "toolStripButton5";
         this.toolStripButton5.Size = new System.Drawing.Size(71, 22);
         this.toolStripButton5.Text = "Anonymize";
         this.toolStripButton5.Click += new System.EventHandler(this.toolStripButton5_Click);
#endif // #if (LEADTOOLS_V19_OR_LATER)

         // 
         // panel1
         // 
         this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
#if (LEADTOOLS_V19_OR_LATER)
         this.panel1.Controls.Add(this.anonymizeOptionsView1);
         this.panel1.Controls.Add(this.databaseManagerOptionsView1);
#endif
         this.panel1.Controls.Add(this.storageClassesTabControl1);
         this.panel1.Controls.Add(this.queryOptionsView1);
         this.panel1.Controls.Add(this.storageOptionsView1);
         this.panel1.Location = new System.Drawing.Point(0, 29);
         this.panel1.Name = "panel1";
         this.panel1.Size = new System.Drawing.Size(707, 552);
         this.panel1.TabIndex = 5;
         // 
         // storageClassesTabControl1
         // 
         this.storageClassesTabControl1.Location = new System.Drawing.Point(361, 250);
         this.storageClassesTabControl1.Name = "storageClassesTabControl1";
         this.storageClassesTabControl1.PresentationContextList = null;
         this.storageClassesTabControl1.Size = new System.Drawing.Size(343, 299);
         this.storageClassesTabControl1.TabIndex = 6;
         // 
         // queryOptionsView1
         // 
         this.queryOptionsView1.AddInsSettings = null;
         this.queryOptionsView1.AllowExtraItems = false;
         this.queryOptionsView1.AllowMultipleItems = false;
         this.queryOptionsView1.AllowPrivateItems = false;
         this.queryOptionsView1.AllowZeroItems = false;
         this.queryOptionsView1.ComboBoxStatusEnable = true;
         this.queryOptionsView1.IodXmlPath = "";
         this.queryOptionsView1.LimitCFindRsp = false;
         this.queryOptionsView1.Location = new System.Drawing.Point(325, 20);
         this.queryOptionsView1.MaximumCountCFindRsp = 1;
         this.queryOptionsView1.Name = "queryOptionsView1";
         this.queryOptionsView1.PatientRelatedInstances = false;
         this.queryOptionsView1.PatientRelatedSeries = false;
         this.queryOptionsView1.PatientRelatedStudies = false;
         this.queryOptionsView1.SeriesRelatedInstances = false;
         this.queryOptionsView1.Size = new System.Drawing.Size(368, 203);
         this.queryOptionsView1.StudyRelatedInstances = false;
         this.queryOptionsView1.StudyRelatedSeries = false;
         this.queryOptionsView1.TabIndex = 5;
         // 
         // storageOptionsView1
         // 
         this.storageOptionsView1.AddInsSettings = null;
         this.storageOptionsView1.AllowedFormats = ((System.Collections.Generic.List<string>)(resources.GetObject("storageOptionsView1.AllowedFormats")));
         this.storageOptionsView1.AutoTruncateData = false;
         this.storageOptionsView1.BackupFilesOnDelete = false;
         this.storageOptionsView1.BackupLocation = "";
         this.storageOptionsView1.CreateBackupBeforeOverwrite = false;
         this.storageOptionsView1.CreatePatientFolder = false;
         this.storageOptionsView1.CreateSeriesFolder = false;
         this.storageOptionsView1.CreateStudyFolder = false;
         this.storageOptionsView1.CreateThumbnailImage = false;
         this.storageOptionsView1.DeleteAnnotations = false;
         this.storageOptionsView1.DeleteDicomFiles = false;
         this.storageOptionsView1.FileExtension = "";
         this.storageOptionsView1.Location = new System.Drawing.Point(21, 77);
         this.storageOptionsView1.Name = "storageOptionsView1";
         this.storageOptionsView1.OverwriteBackupLocation = "";
         this.storageOptionsView1.PreventStoringDuplicates = false;
         this.storageOptionsView1.SaveCStoreFailures = false;
         this.storageOptionsView1.SaveCStoreLocation = "";
         this.storageOptionsView1.ShowDeleteAnnotationOption = false;
         this.storageOptionsView1.Size = new System.Drawing.Size(255, 437);
         this.storageOptionsView1.SplitPatientIdIntoFolders = false;
         this.storageOptionsView1.StorageLocation = "";
         this.storageOptionsView1.TabIndex = 4;
         this.storageOptionsView1.ThumbnailHeight = 1;
         this.storageOptionsView1.ThumbnailQualityFactor = 2;
         this.storageOptionsView1.ThumbnailWidth = 1;
         this.storageOptionsView1.UpdateExistingInstance = false;
         this.storageOptionsView1.UpdateExistingPatient = false;
         this.storageOptionsView1.UpdateExistingSeries = false;
         this.storageOptionsView1.UpdateExistingStudy = false;
         this.storageOptionsView1.UsePatientId = false;

#if (LEADTOOLS_V19_OR_LATER)
         // 
         // databaseManagerOptionsView1
         // 
         this.databaseManagerOptionsView1.Location = new System.Drawing.Point(13, 343);
         this.databaseManagerOptionsView1.Name = "databaseManagerOptionsView1";
         this.databaseManagerOptionsView1.Options = null;
         this.databaseManagerOptionsView1.Size = new System.Drawing.Size(342, 197);
         this.databaseManagerOptionsView1.TabIndex = 7;

         // 
         // anonymizeOptionsView1
         // 
         this.anonymizeOptionsView1.AnonymizeScripts = null;
         this.anonymizeOptionsView1.Location = new System.Drawing.Point(28, 20);
         this.anonymizeOptionsView1.Name = "anonymizeOptionsView1";
         this.anonymizeOptionsView1.SaveButtonVisible = false;
         this.anonymizeOptionsView1.Size = new System.Drawing.Size(277, 298);
         this.anonymizeOptionsView1.TabIndex = 8;
#endif // #if (LEADTOOLS_V19_OR_LATER)

         // 
         // AddInsConfiguration
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.Controls.Add(this.panel1);
         this.Controls.Add(this.toolStrip1);
         this.Name = "AddInsConfiguration";
         this.Size = new System.Drawing.Size(707, 581);
         this.Load += new System.EventHandler(this.AddInsConfiguration_Load);
         this.VisibleChanged += new System.EventHandler(this.AddInsConfiguration_VisibleChanged);
         this.toolStrip1.ResumeLayout(false);
         this.toolStrip1.PerformLayout();
         this.panel1.ResumeLayout(false);
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.OpenFileDialog iodOpenFileDialog;
      private System.Windows.Forms.FolderBrowserDialog StorageLocationBrowserDialog;
      private System.Windows.Forms.ToolStrip toolStrip1;
      private System.Windows.Forms.ToolStripButton toolStripButton1;
      private System.Windows.Forms.ToolStripButton toolStripButton2;
      private System.Windows.Forms.ToolStripButton toolStripButton3;
      private System.Windows.Forms.Panel panel1;
      private Leadtools.Medical.Winforms.StorageClassesTabControl storageClassesTabControl1;
      private QueryOptionsView queryOptionsView1;
      private StorageOptionsView storageOptionsView1;
#if (LEADTOOLS_V19_OR_LATER)
      private System.Windows.Forms.ToolStripButton toolStripButton4;
      private System.Windows.Forms.ToolStripButton toolStripButton5;
      private Winforms.Anonymize.AnonymizeOptionsView anonymizeOptionsView1;
      private Winforms.DatabaseManager.DatabaseManagerOptionsView databaseManagerOptionsView1;
#endif
   }
}

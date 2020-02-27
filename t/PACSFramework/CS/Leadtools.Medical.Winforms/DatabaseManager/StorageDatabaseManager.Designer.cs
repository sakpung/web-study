namespace Leadtools.Medical.Winforms
{
   public partial class StorageDatabaseManager
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
         
         // Leadtools.Dicom.DicomEngine.Shutdown ( ) ;

         UnRegisterEvents();
         
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
         System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
         System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
         System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
         System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StorageDatabaseManager));
         this.pnlStatus = new System.Windows.Forms.Panel();
         this.paginationControl1 = new Leadtools.Medical.Winforms.PaginationControl();
         this.progressBar1 = new System.Windows.Forms.ProgressBar();
         this.toolStrip1 = new System.Windows.Forms.ToolStrip();
         this.tsbAddDicom = new System.Windows.Forms.ToolStripButton();
         this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
         this.tsbAddDicomDir = new System.Windows.Forms.ToolStripButton();
         this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
         this.tsbExportSelected = new System.Windows.Forms.ToolStripButton();
         this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
         this.tsbDelete = new System.Windows.Forms.ToolStripButton();
         this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
         this.tsbEmpyDatabase = new System.Windows.Forms.ToolStripButton();
         this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
         this.tsbGenerateMetadata = new System.Windows.Forms.ToolStripButton();
         this.tsbCancel = new System.Windows.Forms.ToolStripButton();
         this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
         this.tsbShowReport = new System.Windows.Forms.ToolStripButton();
         this.RecordsCountToolStripLabel = new System.Windows.Forms.ToolStripLabel();
         this.tscDisplayLevel = new System.Windows.Forms.ToolStripComboBox();
         this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
         this.pnlContainer = new System.Windows.Forms.Panel();
         this.dgvStudies = new System.Windows.Forms.DataGridView();
         this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
         this.exportSelectedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.deleteSelectedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.emptyDatabaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.generateMetadataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
         this.cancelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.dicomQuery1 = new Leadtools.Medical.Winforms.DicomQuery();
         this.addDicomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.statusReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.pnlStatus.SuspendLayout();
         this.toolStrip1.SuspendLayout();
         this.pnlContainer.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.dgvStudies)).BeginInit();
         this.contextMenuStrip1.SuspendLayout();
         this.SuspendLayout();
         // 
         // pnlStatus
         // 
         this.pnlStatus.Controls.Add(this.paginationControl1);
         this.pnlStatus.Controls.Add(this.progressBar1);
         this.pnlStatus.Dock = System.Windows.Forms.DockStyle.Bottom;
         this.pnlStatus.Location = new System.Drawing.Point(0, 479);
         this.pnlStatus.Name = "pnlStatus";
         this.pnlStatus.Size = new System.Drawing.Size(1100, 35);
         this.pnlStatus.TabIndex = 2;
         this.pnlStatus.Visible = false;
         // 
         // paginationControl1
         // 
         this.paginationControl1.Dock = System.Windows.Forms.DockStyle.Fill;
         this.paginationControl1.Location = new System.Drawing.Point(0, 0);
         this.paginationControl1.MaxPageNumber = 100;
         this.paginationControl1.MinPageNumber = 1;
         this.paginationControl1.Name = "paginationControl1";
         this.paginationControl1.PageNumber = 1;
         this.paginationControl1.PageNumberIncrement = new decimal(new int[] {
            10,
            0,
            0,
            0});
         this.paginationControl1.PageSize = 5;
         this.paginationControl1.PageSizeLabel = "Page Size:";
         this.paginationControl1.Size = new System.Drawing.Size(1100, 35);
         this.paginationControl1.Status = "0 / 0";
         this.paginationControl1.TabIndex = 2;
         // 
         // progressBar1
         // 
         this.progressBar1.Dock = System.Windows.Forms.DockStyle.Fill;
         this.progressBar1.Location = new System.Drawing.Point(0, 0);
         this.progressBar1.Name = "progressBar1";
         this.progressBar1.Size = new System.Drawing.Size(1100, 35);
         this.progressBar1.TabIndex = 1;
         // 
         // toolStrip1
         // 
         this.toolStrip1.Font = new System.Drawing.Font("Arial", 8.400001F);
         this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbAddDicom,
            this.toolStripSeparator1,
            this.tsbAddDicomDir,
            this.toolStripSeparator2,
            this.tsbExportSelected,
            this.toolStripSeparator5,
            this.tsbDelete,
            this.toolStripSeparator3,
            this.tsbEmpyDatabase,
            this.toolStripSeparator4,
            this.tsbGenerateMetadata,
            this.tsbCancel,
            this.toolStripSeparator6,
            this.tsbShowReport,
            this.RecordsCountToolStripLabel,
            this.tscDisplayLevel,
            this.toolStripLabel2});
         this.toolStrip1.Location = new System.Drawing.Point(0, 0);
         this.toolStrip1.Name = "toolStrip1";
         this.toolStrip1.Size = new System.Drawing.Size(1100, 71);
         this.toolStrip1.TabIndex = 3;
         this.toolStrip1.Text = "toolStrip1";
         // 
         // tsbAddDicom
         // 
         this.tsbAddDicom.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this.tsbAddDicom.Font = new System.Drawing.Font("Arial", 8.400001F, System.Drawing.FontStyle.Bold);
         this.tsbAddDicom.ForeColor = System.Drawing.Color.SteelBlue;
         this.tsbAddDicom.Image = global::Leadtools.Medical.Winforms.Properties.Resources.dicom_add;
         this.tsbAddDicom.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
         this.tsbAddDicom.ImageTransparentColor = System.Drawing.Color.Magenta;
         this.tsbAddDicom.Name = "tsbAddDicom";
         this.tsbAddDicom.Size = new System.Drawing.Size(68, 68);
         this.tsbAddDicom.Text = "Add DICOM";
         // 
         // toolStripSeparator1
         // 
         this.toolStripSeparator1.Name = "toolStripSeparator1";
         this.toolStripSeparator1.Size = new System.Drawing.Size(6, 71);
         // 
         // tsbAddDicomDir
         // 
         this.tsbAddDicomDir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this.tsbAddDicomDir.Font = new System.Drawing.Font("Arial", 8.400001F, System.Drawing.FontStyle.Bold);
         this.tsbAddDicomDir.ForeColor = System.Drawing.Color.SteelBlue;
         this.tsbAddDicomDir.Image = global::Leadtools.Medical.Winforms.Properties.Resources.dicom_add_all;
         this.tsbAddDicomDir.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
         this.tsbAddDicomDir.ImageTransparentColor = System.Drawing.Color.Magenta;
         this.tsbAddDicomDir.Name = "tsbAddDicomDir";
         this.tsbAddDicomDir.Size = new System.Drawing.Size(68, 68);
         this.tsbAddDicomDir.Text = "Add DICOMDIR";
         // 
         // toolStripSeparator2
         // 
         this.toolStripSeparator2.Name = "toolStripSeparator2";
         this.toolStripSeparator2.Size = new System.Drawing.Size(6, 71);
         // 
         // tsbExportSelected
         // 
         this.tsbExportSelected.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this.tsbExportSelected.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.tsbExportSelected.Image = global::Leadtools.Medical.Winforms.Properties.Resources.dicom_export;
         this.tsbExportSelected.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
         this.tsbExportSelected.ImageTransparentColor = System.Drawing.Color.Magenta;
         this.tsbExportSelected.Name = "tsbExportSelected";
         this.tsbExportSelected.Size = new System.Drawing.Size(68, 68);
         this.tsbExportSelected.Text = "Export Selected";
         // 
         // toolStripSeparator5
         // 
         this.toolStripSeparator5.Name = "toolStripSeparator5";
         this.toolStripSeparator5.Size = new System.Drawing.Size(6, 71);
         // 
         // tsbDelete
         // 
         this.tsbDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this.tsbDelete.Font = new System.Drawing.Font("Arial", 8.400001F, System.Drawing.FontStyle.Bold);
         this.tsbDelete.ForeColor = System.Drawing.Color.SteelBlue;
         this.tsbDelete.Image = global::Leadtools.Medical.Winforms.Properties.Resources.dicom_delete_selected;
         this.tsbDelete.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
         this.tsbDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
         this.tsbDelete.Name = "tsbDelete";
         this.tsbDelete.Size = new System.Drawing.Size(68, 68);
         this.tsbDelete.Text = "Delete Selected";
         // 
         // toolStripSeparator3
         // 
         this.toolStripSeparator3.Name = "toolStripSeparator3";
         this.toolStripSeparator3.Size = new System.Drawing.Size(6, 71);
         // 
         // tsbEmpyDatabase
         // 
         this.tsbEmpyDatabase.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this.tsbEmpyDatabase.Font = new System.Drawing.Font("Arial", 8.400001F, System.Drawing.FontStyle.Bold);
         this.tsbEmpyDatabase.ForeColor = System.Drawing.Color.SteelBlue;
         this.tsbEmpyDatabase.Image = global::Leadtools.Medical.Winforms.Properties.Resources.dicom_delete_all;
         this.tsbEmpyDatabase.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
         this.tsbEmpyDatabase.ImageTransparentColor = System.Drawing.Color.Magenta;
         this.tsbEmpyDatabase.Name = "tsbEmpyDatabase";
         this.tsbEmpyDatabase.Size = new System.Drawing.Size(68, 68);
         this.tsbEmpyDatabase.Text = "Empty Database";
         // 
         // toolStripSeparator4
         // 
         this.toolStripSeparator4.Name = "toolStripSeparator4";
         this.toolStripSeparator4.Size = new System.Drawing.Size(6, 71);
         // 
         // tsbGenerateMetadata
         // 
         this.tsbGenerateMetadata.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this.tsbGenerateMetadata.Image = global::Leadtools.Medical.Winforms.Properties.Resources.dicom_generate_metadata;
         this.tsbGenerateMetadata.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
         this.tsbGenerateMetadata.ImageTransparentColor = System.Drawing.Color.Magenta;
         this.tsbGenerateMetadata.Name = "tsbGenerateMetadata";
         this.tsbGenerateMetadata.Size = new System.Drawing.Size(70, 68);
         this.tsbGenerateMetadata.Text = "Generate Metadata";
         // 
         // tsbCancel
         // 
         this.tsbCancel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this.tsbCancel.Font = new System.Drawing.Font("Arial", 8.400001F, System.Drawing.FontStyle.Bold);
         this.tsbCancel.ForeColor = System.Drawing.Color.SteelBlue;
         this.tsbCancel.Image = global::Leadtools.Medical.Winforms.Properties.Resources.dicom_stop;
         this.tsbCancel.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
         this.tsbCancel.ImageTransparentColor = System.Drawing.Color.Magenta;
         this.tsbCancel.Name = "tsbCancel";
         this.tsbCancel.Size = new System.Drawing.Size(68, 68);
         this.tsbCancel.Text = "Cancel";
         // 
         // toolStripSeparator6
         // 
         this.toolStripSeparator6.Name = "toolStripSeparator6";
         this.toolStripSeparator6.Size = new System.Drawing.Size(6, 71);
         // 
         // tsbShowReport
         // 
         this.tsbShowReport.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this.tsbShowReport.Font = new System.Drawing.Font("Arial", 8.400001F, System.Drawing.FontStyle.Bold);
         this.tsbShowReport.ForeColor = System.Drawing.Color.SteelBlue;
         this.tsbShowReport.Image = global::Leadtools.Medical.Winforms.Properties.Resources.status_report;
         this.tsbShowReport.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
         this.tsbShowReport.ImageTransparentColor = System.Drawing.Color.Magenta;
         this.tsbShowReport.Name = "tsbShowReport";
         this.tsbShowReport.Size = new System.Drawing.Size(68, 68);
         this.tsbShowReport.Text = "Status Report";
         // 
         // RecordsCountToolStripLabel
         // 
         this.RecordsCountToolStripLabel.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
         this.RecordsCountToolStripLabel.ForeColor = System.Drawing.Color.SteelBlue;
         this.RecordsCountToolStripLabel.Name = "RecordsCountToolStripLabel";
         this.RecordsCountToolStripLabel.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
         this.RecordsCountToolStripLabel.Size = new System.Drawing.Size(10, 68);
         this.RecordsCountToolStripLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
         // 
         // tscDisplayLevel
         // 
         this.tscDisplayLevel.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
         this.tscDisplayLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.tscDisplayLevel.Name = "tscDisplayLevel";
         this.tscDisplayLevel.Size = new System.Drawing.Size(121, 71);
         // 
         // toolStripLabel2
         // 
         this.toolStripLabel2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
         this.toolStripLabel2.ForeColor = System.Drawing.Color.SteelBlue;
         this.toolStripLabel2.Name = "toolStripLabel2";
         this.toolStripLabel2.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
         this.toolStripLabel2.Size = new System.Drawing.Size(61, 68);
         this.toolStripLabel2.Text = "Display:";
         this.toolStripLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
         // 
         // pnlContainer
         // 
         this.pnlContainer.Controls.Add(this.dgvStudies);
         this.pnlContainer.Controls.Add(this.toolStrip1);
         this.pnlContainer.Controls.Add(this.pnlStatus);
         this.pnlContainer.Dock = System.Windows.Forms.DockStyle.Fill;
         this.pnlContainer.Location = new System.Drawing.Point(0, 0);
         this.pnlContainer.Name = "pnlContainer";
         this.pnlContainer.Size = new System.Drawing.Size(1100, 514);
         this.pnlContainer.TabIndex = 1;
         // 
         // dgvStudies
         // 
         this.dgvStudies.AllowUserToAddRows = false;
         this.dgvStudies.AllowUserToDeleteRows = false;
         this.dgvStudies.AllowUserToOrderColumns = true;
         this.dgvStudies.AllowUserToResizeRows = false;
         dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
         this.dgvStudies.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
         this.dgvStudies.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
         this.dgvStudies.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(75)))), ((int)(((byte)(75)))));
         dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
         dataGridViewCellStyle2.BackColor = System.Drawing.Color.Silver;
         dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 8F);
         dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
         dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.LightGray;
         dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
         dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
         this.dgvStudies.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
         this.dgvStudies.ContextMenuStrip = this.contextMenuStrip1;
         this.dgvStudies.DataMember = "Studies";
         this.dgvStudies.Dock = System.Windows.Forms.DockStyle.Fill;
         this.dgvStudies.EnableHeadersVisualStyles = false;
         this.dgvStudies.Location = new System.Drawing.Point(0, 71);
         this.dgvStudies.Name = "dgvStudies";
         this.dgvStudies.ReadOnly = true;
         dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
         dataGridViewCellStyle3.BackColor = System.Drawing.Color.Silver;
         dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial", 8F);
         dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
         dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.LightGray;
         dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
         dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
         this.dgvStudies.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
         dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
         dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
         dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.LightSteelBlue;
         dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
         this.dgvStudies.RowsDefaultCellStyle = dataGridViewCellStyle4;
         this.dgvStudies.RowTemplate.Height = 26;
         this.dgvStudies.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
         this.dgvStudies.Size = new System.Drawing.Size(1100, 408);
         this.dgvStudies.TabIndex = 1;
         this.dgvStudies.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvStudies_CellContentClick);
         this.dgvStudies.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvStudies_CellDoubleClick);
         // 
         // contextMenuStrip1
         // 
         this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addDicomToolStripMenuItem,
            this.exportSelectedToolStripMenuItem,
            this.deleteSelectedToolStripMenuItem,
            this.emptyDatabaseToolStripMenuItem,
            this.generateMetadataToolStripMenuItem,
            this.statusReportToolStripMenuItem,
            this.toolStripSeparator7,
            this.cancelToolStripMenuItem});
         this.contextMenuStrip1.Name = "contextMenuStrip1";
         this.contextMenuStrip1.Size = new System.Drawing.Size(249, 186);
         // 
         // exportSelectedToolStripMenuItem
         // 
         this.exportSelectedToolStripMenuItem.Name = "exportSelectedToolStripMenuItem";
         this.exportSelectedToolStripMenuItem.Size = new System.Drawing.Size(248, 22);
         this.exportSelectedToolStripMenuItem.Text = "Export Selected...";
         // 
         // deleteSelectedToolStripMenuItem
         // 
         this.deleteSelectedToolStripMenuItem.Name = "deleteSelectedToolStripMenuItem";
         this.deleteSelectedToolStripMenuItem.Size = new System.Drawing.Size(248, 22);
         this.deleteSelectedToolStripMenuItem.Text = "Delete Selected...";
         // 
         // emptyDatabaseToolStripMenuItem
         // 
         this.emptyDatabaseToolStripMenuItem.Name = "emptyDatabaseToolStripMenuItem";
         this.emptyDatabaseToolStripMenuItem.Size = new System.Drawing.Size(248, 22);
         this.emptyDatabaseToolStripMenuItem.Text = "Empty Database...";
         // 
         // generateMetadataToolStripMenuItem
         // 
         this.generateMetadataToolStripMenuItem.Name = "generateMetadataToolStripMenuItem";
         this.generateMetadataToolStripMenuItem.Size = new System.Drawing.Size(248, 22);
         this.generateMetadataToolStripMenuItem.Text = "Generate Metadata for Selected...";
         // 
         // toolStripSeparator7
         // 
         this.toolStripSeparator7.Name = "toolStripSeparator7";
         this.toolStripSeparator7.Size = new System.Drawing.Size(245, 6);
         // 
         // cancelToolStripMenuItem
         // 
         this.cancelToolStripMenuItem.Name = "cancelToolStripMenuItem";
         this.cancelToolStripMenuItem.Size = new System.Drawing.Size(248, 22);
         this.cancelToolStripMenuItem.Text = "Cancel";
         // 
         // dicomQuery1
         // 
         this.dicomQuery1.AutoHide = false;
         this.dicomQuery1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
         this.dicomQuery1.Dock = System.Windows.Forms.DockStyle.Bottom;
         this.dicomQuery1.EnableResizing = false;
         this.dicomQuery1.ForeColor = System.Drawing.Color.White;
         this.dicomQuery1.Location = new System.Drawing.Point(0, 514);
         this.dicomQuery1.Name = "dicomQuery1";
         this.dicomQuery1.Size = new System.Drawing.Size(1100, 243);
         this.dicomQuery1.State = Leadtools.Medical.Workstation.UI.AutoHidePanelState.Expanded;
         this.dicomQuery1.StickPinAttached = ((System.Drawing.Bitmap)(resources.GetObject("dicomQuery1.StickPinAttached")));
         this.dicomQuery1.StickPinUnattached = ((System.Drawing.Bitmap)(resources.GetObject("dicomQuery1.StickPinUnattached")));
         this.dicomQuery1.TabIndex = 0;
         this.dicomQuery1.TopLevel = false;
         // 
         // addDicomToolStripMenuItem
         // 
         this.addDicomToolStripMenuItem.Name = "addDicomToolStripMenuItem";
         this.addDicomToolStripMenuItem.Size = new System.Drawing.Size(248, 22);
         this.addDicomToolStripMenuItem.Text = "Add DICOM...";
         // 
         // statusReportToolStripMenuItem
         // 
         this.statusReportToolStripMenuItem.Name = "statusReportToolStripMenuItem";
         this.statusReportToolStripMenuItem.Size = new System.Drawing.Size(248, 22);
         this.statusReportToolStripMenuItem.Text = "Status Report";
         // 
         // StorageDatabaseManager
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.Controls.Add(this.pnlContainer);
         this.Controls.Add(this.dicomQuery1);
         this.Font = new System.Drawing.Font("Arial", 8F);
         this.Name = "StorageDatabaseManager";
         this.Size = new System.Drawing.Size(1100, 757);
         this.pnlStatus.ResumeLayout(false);
         this.toolStrip1.ResumeLayout(false);
         this.toolStrip1.PerformLayout();
         this.pnlContainer.ResumeLayout(false);
         this.pnlContainer.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this.dgvStudies)).EndInit();
         this.contextMenuStrip1.ResumeLayout(false);
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.Panel pnlStatus;
      private System.Windows.Forms.ToolStrip toolStrip1;
      private System.Windows.Forms.ToolStripButton tsbAddDicom;
      private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
      private System.Windows.Forms.ToolStripButton tsbAddDicomDir;
      private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
      private System.Windows.Forms.ToolStripButton tsbDelete;
      private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
      private System.Windows.Forms.ToolStripButton tsbEmpyDatabase;
      private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
      private System.Windows.Forms.ToolStripButton tsbCancel;
      private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
      private System.Windows.Forms.ToolStripButton tsbShowReport;
      private System.Windows.Forms.ToolStripLabel RecordsCountToolStripLabel;
      private System.Windows.Forms.ToolStripComboBox tscDisplayLevel;
      private System.Windows.Forms.ToolStripLabel toolStripLabel2;
      private System.Windows.Forms.Panel pnlContainer;
      private DicomQuery dicomQuery1 = new DicomQuery();
      private PaginationControl paginationControl1;
      private System.Windows.Forms.ProgressBar progressBar1;
      private System.Windows.Forms.DataGridView dgvStudies;
      private System.Windows.Forms.ToolStripButton tsbExportSelected;
      private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
      private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
      private System.Windows.Forms.ToolStripMenuItem generateMetadataToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem exportSelectedToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem deleteSelectedToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem emptyDatabaseToolStripMenuItem;
      private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
      private System.Windows.Forms.ToolStripMenuItem cancelToolStripMenuItem;
      private System.Windows.Forms.ToolStripButton tsbGenerateMetadata;
      private System.Windows.Forms.ToolStripMenuItem addDicomToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem statusReportToolStripMenuItem;
   }
}

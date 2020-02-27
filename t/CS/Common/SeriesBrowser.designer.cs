namespace Leadtools.Demos
{
   partial class SeriesBrowser
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SeriesBrowser));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.studiesDataGridView = new System.Windows.Forms.DataGridView();
            this.PatientNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PatientIDColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.studyDescriptionColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AccessionNumberColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.studyDateColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.referDrNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.studyInstanceUidColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DICOMDIRfileNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StudyIdentifier = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.seriesDataGridView = new System.Windows.Forms.DataGridView();
            this.modalityColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.seriesStudyInstanceUidColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.seriesInstanceUidColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Organ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SeriesDescColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.seriesNumberColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SeriesID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StudyID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FrameCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Thumbnail = new System.Windows.Forms.DataGridViewImageColumn();
            this.StudyIdent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this._checkLoadAs3D = new System.Windows.Forms.CheckBox();
            this.btnAddDICOMDIR = new System.Windows.Forms.Button();
            this.buttonCancelProgress = new System.Windows.Forms.Button();
            this.labelCounter = new System.Windows.Forms.Label();
            this.progressCounter = new System.Windows.Forms.ProgressBar();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnLoad = new System.Windows.Forms.Button();
            this.studyBrowserDataSet = new Leadtools.Demos.StudyBrowserDataSet();
            this.seriesTableBindingSource = new System.Windows.Forms.BindingSource(this.components);
            //((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.studiesDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.seriesDataGridView)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.studyBrowserDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.seriesTableBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            resources.ApplyResources(this.splitContainer1, "splitContainer1");
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.studiesDataGridView);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.seriesDataGridView);
            // 
            // studiesDataGridView
            // 
            this.studiesDataGridView.AllowUserToAddRows = false;
            this.studiesDataGridView.AllowUserToDeleteRows = false;
            this.studiesDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.studiesDataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.studiesDataGridView.BackgroundColor = System.Drawing.SystemColors.Info;
            this.studiesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.studiesDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PatientNameColumn,
            this.PatientIDColumn,
            this.studyDescriptionColumn,
            this.AccessionNumberColumn,
            this.studyDateColumn,
            this.referDrNameColumn,
            this.studyInstanceUidColumn,
            this.DICOMDIRfileNameColumn,
            this.StudyIdentifier});
            resources.ApplyResources(this.studiesDataGridView, "studiesDataGridView");
            this.studiesDataGridView.MultiSelect = false;
            this.studiesDataGridView.Name = "studiesDataGridView";
            this.studiesDataGridView.ReadOnly = true;
            this.studiesDataGridView.RowHeadersVisible = false;
            this.studiesDataGridView.RowTemplate.Height = 26;
            this.studiesDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.studiesDataGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.studiesDataGridView_CellDoubleClick);
            this.studiesDataGridView.SelectionChanged += new System.EventHandler(this.studiesDataGridView_SelectionChanged);
            // 
            // PatientNameColumn
            // 
            this.PatientNameColumn.DataPropertyName = "PatientName";
            resources.ApplyResources(this.PatientNameColumn, "PatientNameColumn");
            this.PatientNameColumn.Name = "PatientNameColumn";
            this.PatientNameColumn.ReadOnly = true;
            // 
            // PatientIDColumn
            // 
            this.PatientIDColumn.DataPropertyName = "PatientID";
            resources.ApplyResources(this.PatientIDColumn, "PatientIDColumn");
            this.PatientIDColumn.Name = "PatientIDColumn";
            this.PatientIDColumn.ReadOnly = true;
            // 
            // studyDescriptionColumn
            // 
            this.studyDescriptionColumn.DataPropertyName = "StudyDesc";
            resources.ApplyResources(this.studyDescriptionColumn, "studyDescriptionColumn");
            this.studyDescriptionColumn.Name = "studyDescriptionColumn";
            this.studyDescriptionColumn.ReadOnly = true;
            // 
            // AccessionNumberColumn
            // 
            this.AccessionNumberColumn.DataPropertyName = "AccessionNumber";
            resources.ApplyResources(this.AccessionNumberColumn, "AccessionNumberColumn");
            this.AccessionNumberColumn.Name = "AccessionNumberColumn";
            this.AccessionNumberColumn.ReadOnly = true;
            // 
            // studyDateColumn
            // 
            this.studyDateColumn.DataPropertyName = "StudyDate";
            dataGridViewCellStyle1.Format = "d";
            dataGridViewCellStyle1.NullValue = null;
            this.studyDateColumn.DefaultCellStyle = dataGridViewCellStyle1;
            resources.ApplyResources(this.studyDateColumn, "studyDateColumn");
            this.studyDateColumn.Name = "studyDateColumn";
            this.studyDateColumn.ReadOnly = true;
            // 
            // referDrNameColumn
            // 
            this.referDrNameColumn.DataPropertyName = "ReferDrName";
            resources.ApplyResources(this.referDrNameColumn, "referDrNameColumn");
            this.referDrNameColumn.Name = "referDrNameColumn";
            this.referDrNameColumn.ReadOnly = true;
            // 
            // studyInstanceUidColumn
            // 
            this.studyInstanceUidColumn.DataPropertyName = "StudyInstanceUID";
            resources.ApplyResources(this.studyInstanceUidColumn, "studyInstanceUidColumn");
            this.studyInstanceUidColumn.Name = "studyInstanceUidColumn";
            this.studyInstanceUidColumn.ReadOnly = true;
            // 
            // DICOMDIRfileNameColumn
            // 
            resources.ApplyResources(this.DICOMDIRfileNameColumn, "DICOMDIRfileNameColumn");
            this.DICOMDIRfileNameColumn.Name = "DICOMDIRfileNameColumn";
            this.DICOMDIRfileNameColumn.ReadOnly = true;
            // 
            // StudyIdentifier
            // 
            resources.ApplyResources(this.StudyIdentifier, "StudyIdentifier");
            this.StudyIdentifier.Name = "StudyIdentifier";
            this.StudyIdentifier.ReadOnly = true;
            // 
            // seriesDataGridView
            // 
            this.seriesDataGridView.AllowUserToAddRows = false;
            this.seriesDataGridView.AllowUserToDeleteRows = false;
            this.seriesDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.seriesDataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.seriesDataGridView.BackgroundColor = System.Drawing.SystemColors.Info;
            this.seriesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.seriesDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.modalityColumn,
            this.seriesStudyInstanceUidColumn,
            this.seriesInstanceUidColumn,
            this.Organ,
            this.SeriesDescColumn,
            this.seriesNumberColumn,
            this.SeriesID,
            this.StudyID,
            this.FrameCount,
            this.Thumbnail,
            this.StudyIdent});
            resources.ApplyResources(this.seriesDataGridView, "seriesDataGridView");
            this.seriesDataGridView.MultiSelect = false;
            this.seriesDataGridView.Name = "seriesDataGridView";
            this.seriesDataGridView.ReadOnly = true;
            this.seriesDataGridView.RowHeadersVisible = false;
            this.seriesDataGridView.RowTemplate.Height = 64;
            this.seriesDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.seriesDataGridView.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.seriesDataGridView_CellMouseDoubleClick);
            // 
            // modalityColumn
            // 
            this.modalityColumn.DataPropertyName = "Modality";
            this.modalityColumn.FillWeight = 67.90726F;
            resources.ApplyResources(this.modalityColumn, "modalityColumn");
            this.modalityColumn.Name = "modalityColumn";
            this.modalityColumn.ReadOnly = true;
            // 
            // seriesStudyInstanceUidColumn
            // 
            this.seriesStudyInstanceUidColumn.DataPropertyName = "Series Date";
            this.seriesStudyInstanceUidColumn.FillWeight = 97.32079F;
            resources.ApplyResources(this.seriesStudyInstanceUidColumn, "seriesStudyInstanceUidColumn");
            this.seriesStudyInstanceUidColumn.Name = "seriesStudyInstanceUidColumn";
            this.seriesStudyInstanceUidColumn.ReadOnly = true;
            // 
            // seriesInstanceUidColumn
            // 
            this.seriesInstanceUidColumn.DataPropertyName = "SeriesNumber";
            this.seriesInstanceUidColumn.FillWeight = 104.5675F;
            resources.ApplyResources(this.seriesInstanceUidColumn, "seriesInstanceUidColumn");
            this.seriesInstanceUidColumn.Name = "seriesInstanceUidColumn";
            this.seriesInstanceUidColumn.ReadOnly = true;
            // 
            // Organ
            // 
            this.Organ.DataPropertyName = "Organ";
            this.Organ.FillWeight = 83.68578F;
            resources.ApplyResources(this.Organ, "Organ");
            this.Organ.Name = "Organ";
            this.Organ.ReadOnly = true;
            // 
            // SeriesDescColumn
            // 
            this.SeriesDescColumn.DataPropertyName = "Series Description";
            this.SeriesDescColumn.FillWeight = 117.7059F;
            resources.ApplyResources(this.SeriesDescColumn, "SeriesDescColumn");
            this.SeriesDescColumn.Name = "SeriesDescColumn";
            this.SeriesDescColumn.ReadOnly = true;
            // 
            // seriesNumberColumn
            // 
            this.seriesNumberColumn.DataPropertyName = "Number of Instances";
            this.seriesNumberColumn.FillWeight = 117.7059F;
            resources.ApplyResources(this.seriesNumberColumn, "seriesNumberColumn");
            this.seriesNumberColumn.Name = "seriesNumberColumn";
            this.seriesNumberColumn.ReadOnly = true;
            // 
            // SeriesID
            // 
            this.SeriesID.DataPropertyName = "SeriesInstanceUID";
            resources.ApplyResources(this.SeriesID, "SeriesID");
            this.SeriesID.Name = "SeriesID";
            this.SeriesID.ReadOnly = true;
            // 
            // StudyID
            // 
            this.StudyID.DataPropertyName = "StudyInstanceUID";
            resources.ApplyResources(this.StudyID, "StudyID");
            this.StudyID.Name = "StudyID";
            this.StudyID.ReadOnly = true;
            // 
            // FrameCount
            // 
            this.FrameCount.DataPropertyName = "FrameCount";
            this.FrameCount.FillWeight = 93.40102F;
            resources.ApplyResources(this.FrameCount, "FrameCount");
            this.FrameCount.Name = "FrameCount";
            this.FrameCount.ReadOnly = true;
            // 
            // Thumbnail
            // 
            this.Thumbnail.DataPropertyName = "Thumbnail";
            this.Thumbnail.FillWeight = 117.7059F;
            resources.ApplyResources(this.Thumbnail, "Thumbnail");
            this.Thumbnail.Name = "Thumbnail";
            this.Thumbnail.ReadOnly = true;
            this.Thumbnail.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Thumbnail.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // StudyIdent
            // 
            this.StudyIdent.DataPropertyName = "StudyID";
            resources.ApplyResources(this.StudyIdent, "StudyIdent");
            this.StudyIdent.Name = "StudyIdent";
            this.StudyIdent.ReadOnly = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this._checkLoadAs3D);
            this.panel1.Controls.Add(this.btnAddDICOMDIR);
            this.panel1.Controls.Add(this.buttonCancelProgress);
            this.panel1.Controls.Add(this.labelCounter);
            this.panel1.Controls.Add(this.progressCounter);
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Controls.Add(this.btnClear);
            this.panel1.Controls.Add(this.btnLoad);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // _checkLoadAs3D
            // 
            resources.ApplyResources(this._checkLoadAs3D, "_checkLoadAs3D");
            this._checkLoadAs3D.Name = "_checkLoadAs3D";
            this._checkLoadAs3D.UseVisualStyleBackColor = true;
            // 
            // btnAddDICOMDIR
            // 
            resources.ApplyResources(this.btnAddDICOMDIR, "btnAddDICOMDIR");
            this.btnAddDICOMDIR.Name = "btnAddDICOMDIR";
            this.btnAddDICOMDIR.UseVisualStyleBackColor = true;
            this.btnAddDICOMDIR.Click += new System.EventHandler(this.btnAddDICOMDIR_Click);
            // 
            // buttonCancelProgress
            // 
            resources.ApplyResources(this.buttonCancelProgress, "buttonCancelProgress");
            this.buttonCancelProgress.Name = "buttonCancelProgress";
            this.buttonCancelProgress.UseVisualStyleBackColor = true;
            this.buttonCancelProgress.Click += new System.EventHandler(this.buttonCancelProgress_Click);
            // 
            // labelCounter
            // 
            resources.ApplyResources(this.labelCounter, "labelCounter");
            this.labelCounter.Name = "labelCounter";
            // 
            // progressCounter
            // 
            resources.ApplyResources(this.progressCounter, "progressCounter");
            this.progressCounter.Name = "progressCounter";
            // 
            // btnClose
            // 
            resources.ApplyResources(this.btnClose, "btnClose");
            this.btnClose.Name = "btnClose";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnClear
            // 
            resources.ApplyResources(this.btnClear, "btnClear");
            this.btnClear.Name = "btnClear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnLoad
            // 
            resources.ApplyResources(this.btnLoad, "btnLoad");
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // studyBrowserDataSet
            // 
            this.studyBrowserDataSet.DataSetName = "StudyBrowserDataSet";
            this.studyBrowserDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // seriesTableBindingSource
            // 
            this.seriesTableBindingSource.DataMember = "SeriesTable";
            this.seriesTableBindingSource.DataSource = this.studyBrowserDataSet;
            // 
            // SeriesBrowser
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ControlBox = false;
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "SeriesBrowser";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            //((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.studiesDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.seriesDataGridView)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.studyBrowserDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.seriesTableBindingSource)).EndInit();
            this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.SplitContainer splitContainer1;
      private System.Windows.Forms.DataGridView studiesDataGridView;
      private System.Windows.Forms.DataGridView seriesDataGridView;
      private System.Windows.Forms.Panel panel1;
      private System.Windows.Forms.Button btnLoad;
      private System.Windows.Forms.Button btnClear;
      private System.Windows.Forms.Button btnAddDICOMDIR;
      private System.Windows.Forms.Button btnClose;
      private System.Windows.Forms.BindingSource seriesTableBindingSource;
      private StudyBrowserDataSet studyBrowserDataSet;
      private System.Windows.Forms.Label labelCounter;
      private System.Windows.Forms.ProgressBar progressCounter;
      private System.Windows.Forms.Button buttonCancelProgress;
      private System.Windows.Forms.CheckBox _checkLoadAs3D;
      private System.Windows.Forms.DataGridViewTextBoxColumn PatientNameColumn;
      private System.Windows.Forms.DataGridViewTextBoxColumn PatientIDColumn;
      private System.Windows.Forms.DataGridViewTextBoxColumn studyDescriptionColumn;
      private System.Windows.Forms.DataGridViewTextBoxColumn AccessionNumberColumn;
      private System.Windows.Forms.DataGridViewTextBoxColumn studyDateColumn;
      private System.Windows.Forms.DataGridViewTextBoxColumn referDrNameColumn;
      private System.Windows.Forms.DataGridViewTextBoxColumn studyInstanceUidColumn;
      private System.Windows.Forms.DataGridViewTextBoxColumn DICOMDIRfileNameColumn;
      private System.Windows.Forms.DataGridViewTextBoxColumn StudyIdentifier;
      private System.Windows.Forms.DataGridViewTextBoxColumn modalityColumn;
      private System.Windows.Forms.DataGridViewTextBoxColumn seriesStudyInstanceUidColumn;
      private System.Windows.Forms.DataGridViewTextBoxColumn seriesInstanceUidColumn;
      private System.Windows.Forms.DataGridViewTextBoxColumn Organ;
      private System.Windows.Forms.DataGridViewTextBoxColumn SeriesDescColumn;
      private System.Windows.Forms.DataGridViewTextBoxColumn seriesNumberColumn;
      private System.Windows.Forms.DataGridViewTextBoxColumn SeriesID;
      private System.Windows.Forms.DataGridViewTextBoxColumn StudyID;
      private System.Windows.Forms.DataGridViewTextBoxColumn FrameCount;
      private System.Windows.Forms.DataGridViewImageColumn Thumbnail;
      private System.Windows.Forms.DataGridViewTextBoxColumn StudyIdent;
   }
}
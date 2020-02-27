
Partial Class SeriesBrowser
   ''' <summary>
   ''' Required designer variable.
   ''' </summary>
   Private components As System.ComponentModel.IContainer = Nothing

   ''' <summary>
   ''' Clean up any resources being used.
   ''' </summary>
   ''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
   Protected Overrides Sub Dispose(disposing As Boolean)
      If disposing AndAlso (components IsNot Nothing) Then
         components.Dispose()
      End If
      MyBase.Dispose(disposing)
   End Sub

#Region "Windows Form Designer generated code"

   ''' <summary>
   ''' Required method for Designer support - do not modify
   ''' the contents of this method with the code editor.
   ''' </summary>
   Private Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SeriesBrowser))
      Dim dataGridViewCellStyle1 As New System.Windows.Forms.DataGridViewCellStyle()
      Me.splitContainer1 = New System.Windows.Forms.SplitContainer()
      Me.studiesDataGridView = New System.Windows.Forms.DataGridView()
      Me.PatientNameColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.PatientIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.studyDescriptionColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.AccessionNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.studyDateColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.referDrNameColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.studyInstanceUidColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.DICOMDIRfileNameColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.StudyIdentifier = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.seriesDataGridView = New System.Windows.Forms.DataGridView()
      Me.modalityColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.seriesStudyInstanceUidColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.seriesInstanceUidColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.Organ = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.SeriesDescColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.seriesNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.SeriesID = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.StudyID = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.FrameCount = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.Thumbnail = New System.Windows.Forms.DataGridViewImageColumn()
      Me.StudyIdent = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.panel1 = New System.Windows.Forms.Panel()
      Me._checkLoadAs3D = New System.Windows.Forms.CheckBox()
      Me.btnAddDICOMDIR = New System.Windows.Forms.Button()
      Me.buttonCancelProgress = New System.Windows.Forms.Button()
      Me.labelCounter = New System.Windows.Forms.Label()
      Me.progressCounter = New System.Windows.Forms.ProgressBar()
      Me.btnClose = New System.Windows.Forms.Button()
      Me.btnClear = New System.Windows.Forms.Button()
      Me.btnLoad = New System.Windows.Forms.Button()
      Me.studyBrowserDataSet = New StudyBrowserDataSet()
      Me.seriesTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
      '((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
      Me.splitContainer1.Panel1.SuspendLayout()
      Me.splitContainer1.Panel2.SuspendLayout()
      Me.splitContainer1.SuspendLayout()
      CType(Me.studiesDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.seriesDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.panel1.SuspendLayout()
      CType(Me.studyBrowserDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.seriesTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      ' 
      ' splitContainer1
      ' 
      resources.ApplyResources(Me.splitContainer1, "splitContainer1")
      Me.splitContainer1.Name = "splitContainer1"
      ' 
      ' splitContainer1.Panel1
      ' 
      Me.splitContainer1.Panel1.Controls.Add(Me.studiesDataGridView)
      ' 
      ' splitContainer1.Panel2
      ' 
      Me.splitContainer1.Panel2.Controls.Add(Me.seriesDataGridView)
      ' 
      ' studiesDataGridView
      ' 
      Me.studiesDataGridView.AllowUserToAddRows = False
      Me.studiesDataGridView.AllowUserToDeleteRows = False
      Me.studiesDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
      Me.studiesDataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
      Me.studiesDataGridView.BackgroundColor = System.Drawing.SystemColors.Info
      Me.studiesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
      Me.studiesDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.PatientNameColumn, Me.PatientIDColumn, Me.studyDescriptionColumn, Me.AccessionNumberColumn, Me.studyDateColumn, Me.referDrNameColumn, _
       Me.studyInstanceUidColumn, Me.DICOMDIRfileNameColumn, Me.StudyIdentifier})
      resources.ApplyResources(Me.studiesDataGridView, "studiesDataGridView")
      Me.studiesDataGridView.MultiSelect = False
      Me.studiesDataGridView.Name = "studiesDataGridView"
      Me.studiesDataGridView.[ReadOnly] = True
      Me.studiesDataGridView.RowHeadersVisible = False
      Me.studiesDataGridView.RowTemplate.Height = 26
      Me.studiesDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
      ' 
      ' PatientNameColumn
      ' 
      Me.PatientNameColumn.DataPropertyName = "PatientName"
      resources.ApplyResources(Me.PatientNameColumn, "PatientNameColumn")
      Me.PatientNameColumn.Name = "PatientNameColumn"
      Me.PatientNameColumn.[ReadOnly] = True
      ' 
      ' PatientIDColumn
      ' 
      Me.PatientIDColumn.DataPropertyName = "PatientID"
      resources.ApplyResources(Me.PatientIDColumn, "PatientIDColumn")
      Me.PatientIDColumn.Name = "PatientIDColumn"
      Me.PatientIDColumn.[ReadOnly] = True
      ' 
      ' studyDescriptionColumn
      ' 
      Me.studyDescriptionColumn.DataPropertyName = "StudyDesc"
      resources.ApplyResources(Me.studyDescriptionColumn, "studyDescriptionColumn")
      Me.studyDescriptionColumn.Name = "studyDescriptionColumn"
      Me.studyDescriptionColumn.[ReadOnly] = True
      ' 
      ' AccessionNumberColumn
      ' 
      Me.AccessionNumberColumn.DataPropertyName = "AccessionNumber"
      resources.ApplyResources(Me.AccessionNumberColumn, "AccessionNumberColumn")
      Me.AccessionNumberColumn.Name = "AccessionNumberColumn"
      Me.AccessionNumberColumn.[ReadOnly] = True
      ' 
      ' studyDateColumn
      ' 
      Me.studyDateColumn.DataPropertyName = "StudyDate"
      dataGridViewCellStyle1.Format = "d"
      dataGridViewCellStyle1.NullValue = Nothing
      Me.studyDateColumn.DefaultCellStyle = dataGridViewCellStyle1
      resources.ApplyResources(Me.studyDateColumn, "studyDateColumn")
      Me.studyDateColumn.Name = "studyDateColumn"
      Me.studyDateColumn.[ReadOnly] = True
      ' 
      ' referDrNameColumn
      ' 
      Me.referDrNameColumn.DataPropertyName = "ReferDrName"
      resources.ApplyResources(Me.referDrNameColumn, "referDrNameColumn")
      Me.referDrNameColumn.Name = "referDrNameColumn"
      Me.referDrNameColumn.[ReadOnly] = True
      ' 
      ' studyInstanceUidColumn
      ' 
      Me.studyInstanceUidColumn.DataPropertyName = "StudyInstanceUID"
      resources.ApplyResources(Me.studyInstanceUidColumn, "studyInstanceUidColumn")
      Me.studyInstanceUidColumn.Name = "studyInstanceUidColumn"
      Me.studyInstanceUidColumn.[ReadOnly] = True
      ' 
      ' DICOMDIRfileNameColumn
      ' 
      resources.ApplyResources(Me.DICOMDIRfileNameColumn, "DICOMDIRfileNameColumn")
      Me.DICOMDIRfileNameColumn.Name = "DICOMDIRfileNameColumn"
      Me.DICOMDIRfileNameColumn.[ReadOnly] = True
      ' 
      ' StudyIdentifier
      ' 
      resources.ApplyResources(Me.StudyIdentifier, "StudyIdentifier")
      Me.StudyIdentifier.Name = "StudyIdentifier"
      Me.StudyIdentifier.[ReadOnly] = True
      ' 
      ' seriesDataGridView
      ' 
      Me.seriesDataGridView.AllowUserToAddRows = False
      Me.seriesDataGridView.AllowUserToDeleteRows = False
      Me.seriesDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
      Me.seriesDataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells
      Me.seriesDataGridView.BackgroundColor = System.Drawing.SystemColors.Info
      Me.seriesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
      Me.seriesDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.modalityColumn, Me.seriesStudyInstanceUidColumn, Me.seriesInstanceUidColumn, Me.Organ, Me.SeriesDescColumn, Me.seriesNumberColumn, _
       Me.SeriesID, Me.StudyID, Me.FrameCount, Me.Thumbnail, Me.StudyIdent})
      resources.ApplyResources(Me.seriesDataGridView, "seriesDataGridView")
      Me.seriesDataGridView.MultiSelect = False
      Me.seriesDataGridView.Name = "seriesDataGridView"
      Me.seriesDataGridView.[ReadOnly] = True
      Me.seriesDataGridView.RowHeadersVisible = False
      Me.seriesDataGridView.RowTemplate.Height = 64
      Me.seriesDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
      ' 
      ' modalityColumn
      ' 
      Me.modalityColumn.DataPropertyName = "Modality"
      Me.modalityColumn.FillWeight = 67.90726F
      resources.ApplyResources(Me.modalityColumn, "modalityColumn")
      Me.modalityColumn.Name = "modalityColumn"
      Me.modalityColumn.[ReadOnly] = True
      ' 
      ' seriesStudyInstanceUidColumn
      ' 
      Me.seriesStudyInstanceUidColumn.DataPropertyName = "Series Date"
      Me.seriesStudyInstanceUidColumn.FillWeight = 97.32079F
      resources.ApplyResources(Me.seriesStudyInstanceUidColumn, "seriesStudyInstanceUidColumn")
      Me.seriesStudyInstanceUidColumn.Name = "seriesStudyInstanceUidColumn"
      Me.seriesStudyInstanceUidColumn.[ReadOnly] = True
      ' 
      ' seriesInstanceUidColumn
      ' 
      Me.seriesInstanceUidColumn.DataPropertyName = "SeriesNumber"
      Me.seriesInstanceUidColumn.FillWeight = 104.5675F
      resources.ApplyResources(Me.seriesInstanceUidColumn, "seriesInstanceUidColumn")
      Me.seriesInstanceUidColumn.Name = "seriesInstanceUidColumn"
      Me.seriesInstanceUidColumn.[ReadOnly] = True
      ' 
      ' Organ
      ' 
      Me.Organ.DataPropertyName = "Organ"
      Me.Organ.FillWeight = 83.68578F
      resources.ApplyResources(Me.Organ, "Organ")
      Me.Organ.Name = "Organ"
      Me.Organ.[ReadOnly] = True
      ' 
      ' SeriesDescColumn
      ' 
      Me.SeriesDescColumn.DataPropertyName = "Series Description"
      Me.SeriesDescColumn.FillWeight = 117.7059F
      resources.ApplyResources(Me.SeriesDescColumn, "SeriesDescColumn")
      Me.SeriesDescColumn.Name = "SeriesDescColumn"
      Me.SeriesDescColumn.[ReadOnly] = True
      ' 
      ' seriesNumberColumn
      ' 
      Me.seriesNumberColumn.DataPropertyName = "Number of Instances"
      Me.seriesNumberColumn.FillWeight = 117.7059F
      resources.ApplyResources(Me.seriesNumberColumn, "seriesNumberColumn")
      Me.seriesNumberColumn.Name = "seriesNumberColumn"
      Me.seriesNumberColumn.[ReadOnly] = True
      ' 
      ' SeriesID
      ' 
      Me.SeriesID.DataPropertyName = "SeriesInstanceUID"
      resources.ApplyResources(Me.SeriesID, "SeriesID")
      Me.SeriesID.Name = "SeriesID"
      Me.SeriesID.[ReadOnly] = True
      ' 
      ' StudyID
      ' 
      Me.StudyID.DataPropertyName = "StudyInstanceUID"
      resources.ApplyResources(Me.StudyID, "StudyID")
      Me.StudyID.Name = "StudyID"
      Me.StudyID.[ReadOnly] = True
      ' 
      ' FrameCount
      ' 
      Me.FrameCount.DataPropertyName = "FrameCount"
      Me.FrameCount.FillWeight = 93.40102F
      resources.ApplyResources(Me.FrameCount, "FrameCount")
      Me.FrameCount.Name = "FrameCount"
      Me.FrameCount.[ReadOnly] = True
      ' 
      ' Thumbnail
      ' 
      Me.Thumbnail.DataPropertyName = "Thumbnail"
      Me.Thumbnail.FillWeight = 117.7059F
      resources.ApplyResources(Me.Thumbnail, "Thumbnail")
      Me.Thumbnail.Name = "Thumbnail"
      Me.Thumbnail.[ReadOnly] = True
      Me.Thumbnail.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
      Me.Thumbnail.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
      ' 
      ' StudyIdent
      ' 
      Me.StudyIdent.DataPropertyName = "StudyID"
      resources.ApplyResources(Me.StudyIdent, "StudyIdent")
      Me.StudyIdent.Name = "StudyIdent"
      Me.StudyIdent.[ReadOnly] = True
      ' 
      ' panel1
      ' 
      Me.panel1.Controls.Add(Me._checkLoadAs3D)
      Me.panel1.Controls.Add(Me.btnAddDICOMDIR)
      Me.panel1.Controls.Add(Me.buttonCancelProgress)
      Me.panel1.Controls.Add(Me.labelCounter)
      Me.panel1.Controls.Add(Me.progressCounter)
      Me.panel1.Controls.Add(Me.btnClose)
      Me.panel1.Controls.Add(Me.btnClear)
      Me.panel1.Controls.Add(Me.btnLoad)
      resources.ApplyResources(Me.panel1, "panel1")
      Me.panel1.Name = "panel1"
      ' 
      ' _checkLoadAs3D
      ' 
      resources.ApplyResources(Me._checkLoadAs3D, "_checkLoadAs3D")
      Me._checkLoadAs3D.Name = "_checkLoadAs3D"
      Me._checkLoadAs3D.UseVisualStyleBackColor = True
      ' 
      ' btnAddDICOMDIR
      ' 
      resources.ApplyResources(Me.btnAddDICOMDIR, "btnAddDICOMDIR")
      Me.btnAddDICOMDIR.Name = "btnAddDICOMDIR"
      Me.btnAddDICOMDIR.UseVisualStyleBackColor = True
      ' 
      ' buttonCancelProgress
      ' 
      resources.ApplyResources(Me.buttonCancelProgress, "buttonCancelProgress")
      Me.buttonCancelProgress.Name = "buttonCancelProgress"
      Me.buttonCancelProgress.UseVisualStyleBackColor = True
      ' 
      ' labelCounter
      ' 
      resources.ApplyResources(Me.labelCounter, "labelCounter")
      Me.labelCounter.Name = "labelCounter"
      ' 
      ' progressCounter
      ' 
      resources.ApplyResources(Me.progressCounter, "progressCounter")
      Me.progressCounter.Name = "progressCounter"
      ' 
      ' btnClose
      ' 
      resources.ApplyResources(Me.btnClose, "btnClose")
      Me.btnClose.Name = "btnClose"
      Me.btnClose.UseVisualStyleBackColor = True
      ' 
      ' btnClear
      ' 
      resources.ApplyResources(Me.btnClear, "btnClear")
      Me.btnClear.Name = "btnClear"
      Me.btnClear.UseVisualStyleBackColor = True
      ' 
      ' btnLoad
      ' 
      resources.ApplyResources(Me.btnLoad, "btnLoad")
      Me.btnLoad.Name = "btnLoad"
      Me.btnLoad.UseVisualStyleBackColor = True
      ' 
      ' studyBrowserDataSet
      ' 
      Me.studyBrowserDataSet.DataSetName = "StudyBrowserDataSet"
      Me.studyBrowserDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
      ' 
      ' seriesTableBindingSource
      ' 
      Me.seriesTableBindingSource.DataMember = "SeriesTable"
      Me.seriesTableBindingSource.DataSource = Me.studyBrowserDataSet
      ' 
      ' SeriesBrowser
      ' 
      resources.ApplyResources(Me, "$this")
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ControlBox = False
      Me.Controls.Add(Me.splitContainer1)
      Me.Controls.Add(Me.panel1)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
      Me.Name = "SeriesBrowser"
      Me.ShowIcon = False
      Me.ShowInTaskbar = False
      Me.splitContainer1.Panel1.ResumeLayout(False)
      Me.splitContainer1.Panel2.ResumeLayout(False)
      '((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
      Me.splitContainer1.ResumeLayout(False)
      CType(Me.studiesDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.seriesDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
      Me.panel1.ResumeLayout(False)
      Me.panel1.PerformLayout()
      CType(Me.studyBrowserDataSet, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.seriesTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)

   End Sub

#End Region

   Private splitContainer1 As System.Windows.Forms.SplitContainer
   Private WithEvents studiesDataGridView As System.Windows.Forms.DataGridView
   Private WithEvents seriesDataGridView As System.Windows.Forms.DataGridView
   Private panel1 As System.Windows.Forms.Panel
   Private WithEvents btnLoad As System.Windows.Forms.Button
   Private WithEvents btnClear As System.Windows.Forms.Button
   Private WithEvents btnAddDICOMDIR As System.Windows.Forms.Button
   Private WithEvents btnClose As System.Windows.Forms.Button
   Private seriesTableBindingSource As System.Windows.Forms.BindingSource
   Private studyBrowserDataSet As StudyBrowserDataSet
   Private labelCounter As System.Windows.Forms.Label
   Private progressCounter As System.Windows.Forms.ProgressBar
   Private WithEvents buttonCancelProgress As System.Windows.Forms.Button
   Private _checkLoadAs3D As System.Windows.Forms.CheckBox
   Private PatientNameColumn As System.Windows.Forms.DataGridViewTextBoxColumn
   Private PatientIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
   Private studyDescriptionColumn As System.Windows.Forms.DataGridViewTextBoxColumn
   Private AccessionNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
   Private studyDateColumn As System.Windows.Forms.DataGridViewTextBoxColumn
   Private referDrNameColumn As System.Windows.Forms.DataGridViewTextBoxColumn
   Private studyInstanceUidColumn As System.Windows.Forms.DataGridViewTextBoxColumn
   Private DICOMDIRfileNameColumn As System.Windows.Forms.DataGridViewTextBoxColumn
   Private StudyIdentifier As System.Windows.Forms.DataGridViewTextBoxColumn
   Private modalityColumn As System.Windows.Forms.DataGridViewTextBoxColumn
   Private seriesStudyInstanceUidColumn As System.Windows.Forms.DataGridViewTextBoxColumn
   Private seriesInstanceUidColumn As System.Windows.Forms.DataGridViewTextBoxColumn
   Private Organ As System.Windows.Forms.DataGridViewTextBoxColumn
   Private SeriesDescColumn As System.Windows.Forms.DataGridViewTextBoxColumn
   Private seriesNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
   Private SeriesID As System.Windows.Forms.DataGridViewTextBoxColumn
   Private StudyID As System.Windows.Forms.DataGridViewTextBoxColumn
   Private FrameCount As System.Windows.Forms.DataGridViewTextBoxColumn
   Private Thumbnail As System.Windows.Forms.DataGridViewImageColumn
   Private StudyIdent As System.Windows.Forms.DataGridViewTextBoxColumn
End Class

Imports Microsoft.VisualBasic
Imports System
Namespace Leadtools.Demos.Workstation
   Partial Public Class SearchStudies
	  ''' <summary> 
	  ''' Required designer variable.
	  ''' </summary>
	  Private components As System.ComponentModel.IContainer = Nothing

	  ''' <summary> 
	  ''' Clean up any resources being used.
	  ''' </summary>
	  ''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
	  Protected Overrides Sub Dispose(ByVal disposing As Boolean)
		 If disposing AndAlso (components IsNot Nothing) Then
			components.Dispose()
		 End If
		 MyBase.Dispose(disposing)
	  End Sub

	  #Region "Component Designer generated code"

	  ''' <summary> 
	  ''' Required method for Designer support - do not modify 
	  ''' the contents of this method with the code editor.
	  ''' </summary>
	  Private Sub InitializeComponent()
		 Me.components = New System.ComponentModel.Container()
		 Dim dataGridViewCellStyle7 As New System.Windows.Forms.DataGridViewCellStyle()
		 Dim dataGridViewCellStyle8 As New System.Windows.Forms.DataGridViewCellStyle()
		 Dim dataGridViewCellStyle9 As New System.Windows.Forms.DataGridViewCellStyle()
		 Dim dataGridViewCellStyle10 As New System.Windows.Forms.DataGridViewCellStyle()
		 Dim dataGridViewCellStyle11 As New System.Windows.Forms.DataGridViewCellStyle()
		 Dim dataGridViewCellStyle12 As New System.Windows.Forms.DataGridViewCellStyle()
		 Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SearchStudies))
		 Me.StudiesGroupBox = New System.Windows.Forms.GroupBox()
		 Me.StudiesDataGridView = New System.Windows.Forms.DataGridView()
		 Me.patientIDDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
		 Me.PatientNameDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
		 Me.patientBirthDateDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
		 Me.PatientSexDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
		 Me.StudyDescriptionDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
		 Me.StudyDateDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
		 Me.AccessionNumberDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
		 Me.ReferDrNameDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
		 Me.StudyInstanceUIDDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
		 Me.clientQueryDataSetBindingSource = New System.Windows.Forms.BindingSource(Me.components)
		 Me.StudiesContextMenuStrip = New System.Windows.Forms.ContextMenuStrip(Me.components)
		 Me.AddStudyToViewerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
		 Me.OpenStudyInViewerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
		 Me.StudiesSeriesSplitter = New System.Windows.Forms.Splitter()
		 Me.SeriesGroupBox = New System.Windows.Forms.GroupBox()
		 Me.SeriesDataGridView = New System.Windows.Forms.DataGridView()
		 Me.SeriesNumberDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
		 Me.SeriesDescriptionDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
		 Me.ModalityDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
		 Me.SeriesDateDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
		 Me.SeriesTimeDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
		 Me.FrameCountDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
		 Me.SerStudyInstanceUIDDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
		 Me.SeriesInstanceUIDDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
		 Me.VolumeReadyColumn = New System.Windows.Forms.DataGridViewImageColumn()
		 Me.SeriesContextMenuStrip = New System.Windows.Forms.ContextMenuStrip(Me.components)
		 Me.ViewSeriesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
		 Me.OpenInViewerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
		 Me.seriesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
		 Me.ServerStudiesContextMenuStrip = New System.Windows.Forms.ContextMenuStrip(Me.components)
		 Me.AddStudiesToQueuetoolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
		 Me.ServerSeriesContextMenuStrip = New System.Windows.Forms.ContextMenuStrip(Me.components)
		 Me.AddSeriesToQueuetoolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
		 Me.ServersStudyStoreContextMenuStrip = New System.Windows.Forms.ContextMenuStrip(Me.components)
		 Me.toolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
		 Me.StoreStudyToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
		 Me.StoreStudyToServersToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
		 Me.QueryToolTip = New System.Windows.Forms.ToolTip(Me.components)
		 Me.SearchButton = New System.Windows.Forms.Button()
		 Me.CancelSearchButton = New System.Windows.Forms.Button()
		 Me.ClearSearchButton = New System.Windows.Forms.Button()
		 Me.SearchFieldsAutoHidePanel = New Leadtools.Medical.Workstation.UI.AutoHidePanel()
		 Me.StudiesQueryGroupBox = New System.Windows.Forms.GroupBox()
		 Me.StudyToDateTimePicker = New System.Windows.Forms.DateTimePicker()
		 Me.StudyFromDateTimePicker = New System.Windows.Forms.DateTimePicker()
		 Me.StudyToLabel = New System.Windows.Forms.Label()
		 Me.StudyFromLabel = New System.Windows.Forms.Label()
		 Me.StudyDateLabel = New System.Windows.Forms.Label()
		 Me.RefDrGivenNameTextBox = New System.Windows.Forms.TextBox()
		 Me.RefDrGivenNameLabel = New System.Windows.Forms.Label()
		 Me.RefDrLastNameTextBox = New System.Windows.Forms.TextBox()
		 Me.RefDrLastNameLabel = New System.Windows.Forms.Label()
		 Me.AccessionNumberTextBox = New System.Windows.Forms.TextBox()
		 Me.AccessionNumLabel = New System.Windows.Forms.Label()
		 Me.StudiesIDTextBox = New System.Windows.Forms.TextBox()
		 Me.StudiesIDLabel = New System.Windows.Forms.Label()
		 Me.PatientGroupBox = New System.Windows.Forms.GroupBox()
		 Me.PatientGivenNameTextBox = New System.Windows.Forms.TextBox()
		 Me.PatientGivenNameLabel = New System.Windows.Forms.Label()
		 Me.PatientIDTextBox = New System.Windows.Forms.TextBox()
		 Me.PatientLastNameTextBox = New System.Windows.Forms.TextBox()
		 Me.PatientIDLabel = New System.Windows.Forms.Label()
		 Me.PatientLastNameLabel = New System.Windows.Forms.Label()
		 Me.ModalitiesGroupBox = New System.Windows.Forms.GroupBox()
		 Me.ModalitiesSelectAllCheckBox = New System.Windows.Forms.CheckBox()
		 Me.SearchSourceGroupBox = New System.Windows.Forms.GroupBox()
		 Me.PacsServersComboBox = New System.Windows.Forms.ComboBox()
		 Me.PacsServerRadioButton = New System.Windows.Forms.RadioButton()
		 Me.LocalDatabaseRadioButton = New System.Windows.Forms.RadioButton()
		 Me.ModalitiesCheckedComboBox = New Leadtools.Medical.Winforms.Control.CheckedComboBox()
		 Me.AddToMediaBurningManagerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
		 Me.toolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
		 Me.StudiesGroupBox.SuspendLayout()
		 CType(Me.StudiesDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
		 CType(Me.clientQueryDataSetBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
		 Me.StudiesContextMenuStrip.SuspendLayout()
		 Me.SeriesGroupBox.SuspendLayout()
		 CType(Me.SeriesDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
		 Me.SeriesContextMenuStrip.SuspendLayout()
		 CType(Me.seriesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
		 Me.ServerStudiesContextMenuStrip.SuspendLayout()
		 Me.ServerSeriesContextMenuStrip.SuspendLayout()
		 Me.ServersStudyStoreContextMenuStrip.SuspendLayout()
		 Me.SearchFieldsAutoHidePanel.SuspendLayout()
		 Me.StudiesQueryGroupBox.SuspendLayout()
		 Me.PatientGroupBox.SuspendLayout()
		 Me.ModalitiesGroupBox.SuspendLayout()
		 Me.SearchSourceGroupBox.SuspendLayout()
		 Me.SuspendLayout()
		 ' 
		 ' StudiesGroupBox
		 ' 
		 Me.StudiesGroupBox.Controls.Add(Me.StudiesDataGridView)
		 Me.StudiesGroupBox.Dock = System.Windows.Forms.DockStyle.Top
		 Me.StudiesGroupBox.ForeColor = System.Drawing.Color.White
		 Me.StudiesGroupBox.Location = New System.Drawing.Point(0, 205)
		 Me.StudiesGroupBox.Name = "StudiesGroupBox"
		 Me.StudiesGroupBox.Size = New System.Drawing.Size(1168, 217)
		 Me.StudiesGroupBox.TabIndex = 0
		 Me.StudiesGroupBox.TabStop = False
		 Me.StudiesGroupBox.Text = "Studies"
		 ' 
		 ' StudiesDataGridView
		 ' 
		 Me.StudiesDataGridView.AllowUserToAddRows = False
		 Me.StudiesDataGridView.AllowUserToDeleteRows = False
		 Me.StudiesDataGridView.AllowUserToOrderColumns = True
		 dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb((CInt(Fix((CByte(224))))), (CInt(Fix((CByte(224))))), (CInt(Fix((CByte(224))))))
		 Me.StudiesDataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle7
		 Me.StudiesDataGridView.AutoGenerateColumns = False
		 Me.StudiesDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
		 Me.StudiesDataGridView.BackgroundColor = System.Drawing.Color.FromArgb((CInt(Fix((CByte(75))))), (CInt(Fix((CByte(75))))), (CInt(Fix((CByte(75))))))
		 dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
		 dataGridViewCellStyle8.BackColor = System.Drawing.Color.WhiteSmoke
		 dataGridViewCellStyle8.Font = New System.Drawing.Font("Arial", 8F)
		 dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText
		 dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.LightGray
		 dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText
		 dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True
		 Me.StudiesDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle8
		 Me.StudiesDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() { Me.patientIDDataGridViewTextBoxColumn, Me.PatientNameDataGridViewTextBoxColumn, Me.patientBirthDateDataGridViewTextBoxColumn, Me.PatientSexDataGridViewTextBoxColumn, Me.StudyDescriptionDataGridViewTextBoxColumn, Me.StudyDateDataGridViewTextBoxColumn, Me.AccessionNumberDataGridViewTextBoxColumn, Me.ReferDrNameDataGridViewTextBoxColumn, Me.StudyInstanceUIDDataGridViewTextBoxColumn})
		 Me.StudiesDataGridView.DataMember = "Studies"
		 Me.StudiesDataGridView.DataSource = Me.clientQueryDataSetBindingSource
		 Me.StudiesDataGridView.Dock = System.Windows.Forms.DockStyle.Fill
		 Me.StudiesDataGridView.EnableHeadersVisualStyles = False
		 Me.StudiesDataGridView.Location = New System.Drawing.Point(3, 16)
		 Me.StudiesDataGridView.MultiSelect = False
		 Me.StudiesDataGridView.Name = "StudiesDataGridView"
		 Me.StudiesDataGridView.ReadOnly = True
		 Me.StudiesDataGridView.RowHeadersVisible = False
		 dataGridViewCellStyle9.BackColor = System.Drawing.Color.White
		 dataGridViewCellStyle9.ForeColor = System.Drawing.Color.Black
		 dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.LightSteelBlue
		 dataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.Black
		 Me.StudiesDataGridView.RowsDefaultCellStyle = dataGridViewCellStyle9
		 Me.StudiesDataGridView.RowTemplate.Height = 26
		 Me.StudiesDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
		 Me.StudiesDataGridView.Size = New System.Drawing.Size(1162, 198)
		 Me.StudiesDataGridView.TabIndex = 0
		 ' 
		 ' patientIDDataGridViewTextBoxColumn
		 ' 
		 Me.patientIDDataGridViewTextBoxColumn.DataPropertyName = "PatientID"
		 Me.patientIDDataGridViewTextBoxColumn.HeaderText = "Patient ID"
		 Me.patientIDDataGridViewTextBoxColumn.Name = "patientIDDataGridViewTextBoxColumn"
		 Me.patientIDDataGridViewTextBoxColumn.ReadOnly = True
		 ' 
		 ' PatientNameDataGridViewTextBoxColumn
		 ' 
		 Me.PatientNameDataGridViewTextBoxColumn.DataPropertyName = "PatientName"
		 Me.PatientNameDataGridViewTextBoxColumn.HeaderText = "Patient Name"
		 Me.PatientNameDataGridViewTextBoxColumn.Name = "PatientNameDataGridViewTextBoxColumn"
		 Me.PatientNameDataGridViewTextBoxColumn.ReadOnly = True
		 ' 
		 ' patientBirthDateDataGridViewTextBoxColumn
		 ' 
		 Me.patientBirthDateDataGridViewTextBoxColumn.DataPropertyName = "PatientBirthDate"
		 Me.patientBirthDateDataGridViewTextBoxColumn.HeaderText = "Birth Date"
		 Me.patientBirthDateDataGridViewTextBoxColumn.Name = "patientBirthDateDataGridViewTextBoxColumn"
		 Me.patientBirthDateDataGridViewTextBoxColumn.ReadOnly = True
		 ' 
		 ' PatientSexDataGridViewTextBoxColumn
		 ' 
		 Me.PatientSexDataGridViewTextBoxColumn.DataPropertyName = "PatientSex"
		 Me.PatientSexDataGridViewTextBoxColumn.HeaderText = "Patient Sex"
		 Me.PatientSexDataGridViewTextBoxColumn.Name = "PatientSexDataGridViewTextBoxColumn"
		 Me.PatientSexDataGridViewTextBoxColumn.ReadOnly = True
		 ' 
		 ' StudyDescriptionDataGridViewTextBoxColumn
		 ' 
		 Me.StudyDescriptionDataGridViewTextBoxColumn.DataPropertyName = "StudyDescription"
		 Me.StudyDescriptionDataGridViewTextBoxColumn.HeaderText = "Description"
		 Me.StudyDescriptionDataGridViewTextBoxColumn.Name = "StudyDescriptionDataGridViewTextBoxColumn"
		 Me.StudyDescriptionDataGridViewTextBoxColumn.ReadOnly = True
		 ' 
		 ' StudyDateDataGridViewTextBoxColumn
		 ' 
		 Me.StudyDateDataGridViewTextBoxColumn.DataPropertyName = "StudyDate"
		 Me.StudyDateDataGridViewTextBoxColumn.HeaderText = "Study Date"
		 Me.StudyDateDataGridViewTextBoxColumn.Name = "StudyDateDataGridViewTextBoxColumn"
		 Me.StudyDateDataGridViewTextBoxColumn.ReadOnly = True
		 ' 
		 ' AccessionNumberDataGridViewTextBoxColumn
		 ' 
		 Me.AccessionNumberDataGridViewTextBoxColumn.DataPropertyName = "AccessionNumber"
		 Me.AccessionNumberDataGridViewTextBoxColumn.HeaderText = "Accession Number"
		 Me.AccessionNumberDataGridViewTextBoxColumn.Name = "AccessionNumberDataGridViewTextBoxColumn"
		 Me.AccessionNumberDataGridViewTextBoxColumn.ReadOnly = True
		 ' 
		 ' ReferDrNameDataGridViewTextBoxColumn
		 ' 
		 Me.ReferDrNameDataGridViewTextBoxColumn.DataPropertyName = "ReferDrName"
		 Me.ReferDrNameDataGridViewTextBoxColumn.HeaderText = "Refer Dr."
		 Me.ReferDrNameDataGridViewTextBoxColumn.Name = "ReferDrNameDataGridViewTextBoxColumn"
		 Me.ReferDrNameDataGridViewTextBoxColumn.ReadOnly = True
		 ' 
		 ' StudyInstanceUIDDataGridViewTextBoxColumn
		 ' 
		 Me.StudyInstanceUIDDataGridViewTextBoxColumn.DataPropertyName = "StudyInstanceUID"
		 Me.StudyInstanceUIDDataGridViewTextBoxColumn.HeaderText = "StudyInstanceUID"
		 Me.StudyInstanceUIDDataGridViewTextBoxColumn.Name = "StudyInstanceUIDDataGridViewTextBoxColumn"
		 Me.StudyInstanceUIDDataGridViewTextBoxColumn.ReadOnly = True
		 Me.StudyInstanceUIDDataGridViewTextBoxColumn.Visible = False
		 ' 
		 ' clientQueryDataSetBindingSource
		 ' 
		 Me.clientQueryDataSetBindingSource.DataSource = GetType(Leadtools.Demos.Workstation.ClientQueryDataSet)
		 Me.clientQueryDataSetBindingSource.Position = 0
		 ' 
		 ' StudiesContextMenuStrip
		 ' 
		 Me.StudiesContextMenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() { Me.AddStudyToViewerToolStripMenuItem, Me.OpenStudyInViewerToolStripMenuItem})
		 Me.StudiesContextMenuStrip.Name = "cmnuStudies"
		 Me.StudiesContextMenuStrip.Size = New System.Drawing.Size(182, 48)
		 ' 
		 ' AddStudyToViewerToolStripMenuItem
		 ' 
		 Me.AddStudyToViewerToolStripMenuItem.Name = "AddStudyToViewerToolStripMenuItem"
		 Me.AddStudyToViewerToolStripMenuItem.Size = New System.Drawing.Size(181, 22)
		 Me.AddStudyToViewerToolStripMenuItem.Text = "Add Study to Viewer"
		 ' 
		 ' OpenStudyInViewerToolStripMenuItem
		 ' 
		 Me.OpenStudyInViewerToolStripMenuItem.Name = "OpenStudyInViewerToolStripMenuItem"
		 Me.OpenStudyInViewerToolStripMenuItem.Size = New System.Drawing.Size(181, 22)
		 Me.OpenStudyInViewerToolStripMenuItem.Text = "Open in Viewer"
		 ' 
		 ' StudiesSeriesSplitter
		 ' 
		 Me.StudiesSeriesSplitter.Dock = System.Windows.Forms.DockStyle.Top
		 Me.StudiesSeriesSplitter.Location = New System.Drawing.Point(0, 422)
		 Me.StudiesSeriesSplitter.Name = "StudiesSeriesSplitter"
		 Me.StudiesSeriesSplitter.Size = New System.Drawing.Size(1168, 10)
		 Me.StudiesSeriesSplitter.TabIndex = 1
		 Me.StudiesSeriesSplitter.TabStop = False
		 ' 
		 ' SeriesGroupBox
		 ' 
		 Me.SeriesGroupBox.Controls.Add(Me.SeriesDataGridView)
		 Me.SeriesGroupBox.Dock = System.Windows.Forms.DockStyle.Fill
		 Me.SeriesGroupBox.ForeColor = System.Drawing.Color.White
		 Me.SeriesGroupBox.Location = New System.Drawing.Point(0, 432)
		 Me.SeriesGroupBox.Name = "SeriesGroupBox"
		 Me.SeriesGroupBox.Size = New System.Drawing.Size(1168, 281)
		 Me.SeriesGroupBox.TabIndex = 2
		 Me.SeriesGroupBox.TabStop = False
		 Me.SeriesGroupBox.Text = "Series"
		 ' 
		 ' SeriesDataGridView
		 ' 
		 Me.SeriesDataGridView.AllowUserToAddRows = False
		 Me.SeriesDataGridView.AllowUserToDeleteRows = False
		 Me.SeriesDataGridView.AllowUserToOrderColumns = True
		 dataGridViewCellStyle10.BackColor = System.Drawing.Color.FromArgb((CInt(Fix((CByte(224))))), (CInt(Fix((CByte(224))))), (CInt(Fix((CByte(224))))))
		 Me.SeriesDataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle10
		 Me.SeriesDataGridView.AutoGenerateColumns = False
		 Me.SeriesDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
		 Me.SeriesDataGridView.BackgroundColor = System.Drawing.Color.FromArgb((CInt(Fix((CByte(75))))), (CInt(Fix((CByte(75))))), (CInt(Fix((CByte(75))))))
		 dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
		 dataGridViewCellStyle11.BackColor = System.Drawing.Color.WhiteSmoke
		 dataGridViewCellStyle11.Font = New System.Drawing.Font("Arial", 8F)
		 dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.WindowText
		 dataGridViewCellStyle11.SelectionBackColor = System.Drawing.Color.LightGray
		 dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText
		 dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.True
		 Me.SeriesDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle11
		 Me.SeriesDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() { Me.SeriesNumberDataGridViewTextBoxColumn, Me.SeriesDescriptionDataGridViewTextBoxColumn, Me.ModalityDataGridViewTextBoxColumn, Me.SeriesDateDataGridViewTextBoxColumn, Me.SeriesTimeDataGridViewTextBoxColumn, Me.FrameCountDataGridViewTextBoxColumn, Me.SerStudyInstanceUIDDataGridViewTextBoxColumn, Me.SeriesInstanceUIDDataGridViewTextBoxColumn, Me.VolumeReadyColumn})
		 Me.SeriesDataGridView.DataMember = "Series"
		 Me.SeriesDataGridView.DataSource = Me.clientQueryDataSetBindingSource
		 Me.SeriesDataGridView.Dock = System.Windows.Forms.DockStyle.Fill
		 Me.SeriesDataGridView.EnableHeadersVisualStyles = False
		 Me.SeriesDataGridView.Location = New System.Drawing.Point(3, 16)
		 Me.SeriesDataGridView.Name = "SeriesDataGridView"
		 Me.SeriesDataGridView.ReadOnly = True
		 Me.SeriesDataGridView.RowHeadersVisible = False
		 dataGridViewCellStyle12.BackColor = System.Drawing.Color.White
		 dataGridViewCellStyle12.ForeColor = System.Drawing.Color.Black
		 dataGridViewCellStyle12.SelectionBackColor = System.Drawing.Color.LightSteelBlue
		 dataGridViewCellStyle12.SelectionForeColor = System.Drawing.Color.Black
		 Me.SeriesDataGridView.RowsDefaultCellStyle = dataGridViewCellStyle12
		 Me.SeriesDataGridView.RowTemplate.Height = 26
		 Me.SeriesDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
		 Me.SeriesDataGridView.Size = New System.Drawing.Size(1162, 262)
		 Me.SeriesDataGridView.TabIndex = 0
		 ' 
		 ' SeriesNumberDataGridViewTextBoxColumn
		 ' 
		 Me.SeriesNumberDataGridViewTextBoxColumn.DataPropertyName = "SeriesNumber"
		 Me.SeriesNumberDataGridViewTextBoxColumn.FillWeight = 107.1912F
		 Me.SeriesNumberDataGridViewTextBoxColumn.HeaderText = "Series Number"
		 Me.SeriesNumberDataGridViewTextBoxColumn.Name = "SeriesNumberDataGridViewTextBoxColumn"
		 Me.SeriesNumberDataGridViewTextBoxColumn.ReadOnly = True
		 ' 
		 ' SeriesDescriptionDataGridViewTextBoxColumn
		 ' 
		 Me.SeriesDescriptionDataGridViewTextBoxColumn.DataPropertyName = "SeriesDescription"
		 Me.SeriesDescriptionDataGridViewTextBoxColumn.FillWeight = 107.1912F
		 Me.SeriesDescriptionDataGridViewTextBoxColumn.HeaderText = "Description"
		 Me.SeriesDescriptionDataGridViewTextBoxColumn.Name = "SeriesDescriptionDataGridViewTextBoxColumn"
		 Me.SeriesDescriptionDataGridViewTextBoxColumn.ReadOnly = True
		 ' 
		 ' ModalityDataGridViewTextBoxColumn
		 ' 
		 Me.ModalityDataGridViewTextBoxColumn.DataPropertyName = "Modality"
		 Me.ModalityDataGridViewTextBoxColumn.FillWeight = 107.1912F
		 Me.ModalityDataGridViewTextBoxColumn.HeaderText = "Modality"
		 Me.ModalityDataGridViewTextBoxColumn.Name = "ModalityDataGridViewTextBoxColumn"
		 Me.ModalityDataGridViewTextBoxColumn.ReadOnly = True
		 ' 
		 ' SeriesDateDataGridViewTextBoxColumn
		 ' 
		 Me.SeriesDateDataGridViewTextBoxColumn.DataPropertyName = "SeriesDate"
		 Me.SeriesDateDataGridViewTextBoxColumn.FillWeight = 107.1912F
		 Me.SeriesDateDataGridViewTextBoxColumn.HeaderText = "Date"
		 Me.SeriesDateDataGridViewTextBoxColumn.Name = "SeriesDateDataGridViewTextBoxColumn"
		 Me.SeriesDateDataGridViewTextBoxColumn.ReadOnly = True
		 ' 
		 ' SeriesTimeDataGridViewTextBoxColumn
		 ' 
		 Me.SeriesTimeDataGridViewTextBoxColumn.DataPropertyName = "SeriesTime"
		 Me.SeriesTimeDataGridViewTextBoxColumn.FillWeight = 107.1912F
		 Me.SeriesTimeDataGridViewTextBoxColumn.HeaderText = "Time"
		 Me.SeriesTimeDataGridViewTextBoxColumn.Name = "SeriesTimeDataGridViewTextBoxColumn"
		 Me.SeriesTimeDataGridViewTextBoxColumn.ReadOnly = True
		 ' 
		 ' FrameCountDataGridViewTextBoxColumn
		 ' 
		 Me.FrameCountDataGridViewTextBoxColumn.DataPropertyName = "FrameCount"
		 Me.FrameCountDataGridViewTextBoxColumn.FillWeight = 107.1912F
		 Me.FrameCountDataGridViewTextBoxColumn.HeaderText = "Instances"
		 Me.FrameCountDataGridViewTextBoxColumn.Name = "FrameCountDataGridViewTextBoxColumn"
		 Me.FrameCountDataGridViewTextBoxColumn.ReadOnly = True
		 ' 
		 ' SerStudyInstanceUIDDataGridViewTextBoxColumn
		 ' 
		 Me.SerStudyInstanceUIDDataGridViewTextBoxColumn.DataPropertyName = "StudyInstanceUID"
		 Me.SerStudyInstanceUIDDataGridViewTextBoxColumn.HeaderText = "StudyInstanceUID"
		 Me.SerStudyInstanceUIDDataGridViewTextBoxColumn.Name = "SerStudyInstanceUIDDataGridViewTextBoxColumn"
		 Me.SerStudyInstanceUIDDataGridViewTextBoxColumn.ReadOnly = True
		 Me.SerStudyInstanceUIDDataGridViewTextBoxColumn.Visible = False
		 ' 
		 ' SeriesInstanceUIDDataGridViewTextBoxColumn
		 ' 
		 Me.SeriesInstanceUIDDataGridViewTextBoxColumn.DataPropertyName = "SeriesInstanceUID"
		 Me.SeriesInstanceUIDDataGridViewTextBoxColumn.HeaderText = "SeriesInstanceUID"
		 Me.SeriesInstanceUIDDataGridViewTextBoxColumn.Name = "SeriesInstanceUIDDataGridViewTextBoxColumn"
		 Me.SeriesInstanceUIDDataGridViewTextBoxColumn.ReadOnly = True
		 Me.SeriesInstanceUIDDataGridViewTextBoxColumn.Visible = False
		 ' 
		 ' VolumeReadyColumn
		 ' 
		 Me.VolumeReadyColumn.FillWeight = 56.85279F
		 Me.VolumeReadyColumn.HeaderText = "3D Available"
       Me.VolumeReadyColumn.Image = (CType(resources.GetObject("VolumeReadyColumn.Image"), System.Drawing.Image))
       Me.VolumeReadyColumn.Name = "VolumeReadyColumn"
       Me.VolumeReadyColumn.ReadOnly = True
       Me.VolumeReadyColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True
       Me.VolumeReadyColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
       ' 
       ' SeriesContextMenuStrip
       ' 
       Me.SeriesContextMenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ViewSeriesToolStripMenuItem, Me.OpenInViewerToolStripMenuItem})
       Me.SeriesContextMenuStrip.Name = "cmnuSeries"
       Me.SeriesContextMenuStrip.Size = New System.Drawing.Size(182, 48)
       ' 
       ' ViewSeriesToolStripMenuItem
       ' 
       Me.ViewSeriesToolStripMenuItem.Name = "ViewSeriesToolStripMenuItem"
       Me.ViewSeriesToolStripMenuItem.Size = New System.Drawing.Size(181, 22)
       Me.ViewSeriesToolStripMenuItem.Text = "Add Series to Viewer"
       ' 
       ' OpenInViewerToolStripMenuItem
       ' 
       Me.OpenInViewerToolStripMenuItem.Name = "OpenInViewerToolStripMenuItem"
       Me.OpenInViewerToolStripMenuItem.Size = New System.Drawing.Size(181, 22)
       Me.OpenInViewerToolStripMenuItem.Text = "Open in Viewer"
       ' 
       ' seriesBindingSource
       ' 
       Me.seriesBindingSource.DataMember = "Series"
       Me.seriesBindingSource.DataSource = Me.clientQueryDataSetBindingSource
       ' 
       ' ServerStudiesContextMenuStrip
       ' 
       Me.ServerStudiesContextMenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AddStudiesToQueuetoolStripMenuItem})
       Me.ServerStudiesContextMenuStrip.Name = "cmnuStudies"
       Me.ServerStudiesContextMenuStrip.Size = New System.Drawing.Size(246, 26)
       ' 
       ' AddStudiesToQueuetoolStripMenuItem
       ' 
       Me.AddStudiesToQueuetoolStripMenuItem.Name = "AddStudiesToQueuetoolStripMenuItem"
       Me.AddStudiesToQueuetoolStripMenuItem.Size = New System.Drawing.Size(245, 22)
       Me.AddStudiesToQueuetoolStripMenuItem.Text = "Add all series to Queue Manager"
       ' 
       ' ServerSeriesContextMenuStrip
       ' 
       Me.ServerSeriesContextMenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AddSeriesToQueuetoolStripMenuItem})
       Me.ServerSeriesContextMenuStrip.Name = "cmnuStudies"
       Me.ServerSeriesContextMenuStrip.Size = New System.Drawing.Size(231, 26)
       ' 
       ' AddSeriesToQueuetoolStripMenuItem
       ' 
       Me.AddSeriesToQueuetoolStripMenuItem.Name = "AddSeriesToQueuetoolStripMenuItem"
       Me.AddSeriesToQueuetoolStripMenuItem.Size = New System.Drawing.Size(230, 22)
       Me.AddSeriesToQueuetoolStripMenuItem.Text = "Add series to Queue Manager"
       ' 
       ' ServersStudyStoreContextMenuStrip
       ' 
       Me.ServersStudyStoreContextMenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolStripSeparator2, Me.AddToMediaBurningManagerToolStripMenuItem, Me.toolStripSeparator1, Me.StoreStudyToolStripMenuItem, Me.StoreStudyToServersToolStripMenuItem})
       Me.ServersStudyStoreContextMenuStrip.Name = "cmnuServersStudyStore"
       Me.ServersStudyStoreContextMenuStrip.Size = New System.Drawing.Size(242, 104)
       ' 
       ' toolStripSeparator1
       ' 
       Me.toolStripSeparator1.Name = "toolStripSeparator1"
       Me.toolStripSeparator1.Size = New System.Drawing.Size(238, 6)
       ' 
       ' StoreStudyToolStripMenuItem
       ' 
       Me.StoreStudyToolStripMenuItem.Name = "StoreStudyToolStripMenuItem"
       Me.StoreStudyToolStripMenuItem.Size = New System.Drawing.Size(241, 22)
       Me.StoreStudyToolStripMenuItem.Text = "Store Study"
       ' 
       ' StoreStudyToServersToolStripMenuItem
       ' 
       Me.StoreStudyToServersToolStripMenuItem.Name = "StoreStudyToServersToolStripMenuItem"
       Me.StoreStudyToServersToolStripMenuItem.Size = New System.Drawing.Size(241, 22)
       Me.StoreStudyToServersToolStripMenuItem.Text = "Store"
       ' 
       ' SearchButton
       ' 
       Me.SearchButton.Anchor = (CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
       Me.SearchButton.BackColor = System.Drawing.Color.FromArgb((CInt(Fix((CByte(75))))), (CInt(Fix((CByte(75))))), (CInt(Fix((CByte(75))))))
       Me.SearchButton.Font = New System.Drawing.Font("Arial", 8.0F, System.Drawing.FontStyle.Bold)
       Me.SearchButton.ForeColor = System.Drawing.Color.White
       Me.SearchButton.Image = (CType(resources.GetObject("SearchButton.Image"), System.Drawing.Image))
       Me.SearchButton.Location = New System.Drawing.Point(946, 130)
       Me.SearchButton.Name = "SearchButton"
       Me.SearchButton.Size = New System.Drawing.Size(65, 65)
       Me.SearchButton.TabIndex = 4
       Me.QueryToolTip.SetToolTip(Me.SearchButton, "Search")
       Me.SearchButton.UseVisualStyleBackColor = False
       ' 
       ' CancelSearchButton
       ' 
       Me.CancelSearchButton.Anchor = (CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
       Me.CancelSearchButton.BackColor = System.Drawing.Color.FromArgb((CInt(Fix((CByte(75))))), (CInt(Fix((CByte(75))))), (CInt(Fix((CByte(75))))))
       Me.CancelSearchButton.Font = New System.Drawing.Font("Arial", 8.0F, System.Drawing.FontStyle.Bold)
       Me.CancelSearchButton.ForeColor = System.Drawing.Color.White
       Me.CancelSearchButton.Image = (CType(resources.GetObject("CancelSearchButton.Image"), System.Drawing.Image))
       Me.CancelSearchButton.Location = New System.Drawing.Point(1017, 130)
       Me.CancelSearchButton.Name = "CancelSearchButton"
       Me.CancelSearchButton.Size = New System.Drawing.Size(65, 65)
       Me.CancelSearchButton.TabIndex = 5
       Me.QueryToolTip.SetToolTip(Me.CancelSearchButton, "Cancel")
       Me.CancelSearchButton.UseVisualStyleBackColor = False
       ' 
       ' ClearSearchButton
       ' 
       Me.ClearSearchButton.Anchor = (CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
       Me.ClearSearchButton.BackColor = System.Drawing.Color.FromArgb((CInt(Fix((CByte(75))))), (CInt(Fix((CByte(75))))), (CInt(Fix((CByte(75))))))
       Me.ClearSearchButton.Font = New System.Drawing.Font("Arial", 8.0F, System.Drawing.FontStyle.Bold)
       Me.ClearSearchButton.ForeColor = System.Drawing.Color.White
       Me.ClearSearchButton.Image = (CType(resources.GetObject("ClearSearchButton.Image"), System.Drawing.Image))
       Me.ClearSearchButton.Location = New System.Drawing.Point(1088, 130)
       Me.ClearSearchButton.Name = "ClearSearchButton"
       Me.ClearSearchButton.Size = New System.Drawing.Size(65, 65)
       Me.ClearSearchButton.TabIndex = 6
       Me.QueryToolTip.SetToolTip(Me.ClearSearchButton, "Clear Filters")
       Me.ClearSearchButton.UseVisualStyleBackColor = False
       ' 
       ' SearchFieldsAutoHidePanel
       ' 
       Me.SearchFieldsAutoHidePanel.AutoHide = False
       Me.SearchFieldsAutoHidePanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
       Me.SearchFieldsAutoHidePanel.Controls.Add(Me.StudiesQueryGroupBox)
       Me.SearchFieldsAutoHidePanel.Controls.Add(Me.PatientGroupBox)
       Me.SearchFieldsAutoHidePanel.Controls.Add(Me.ModalitiesGroupBox)
       Me.SearchFieldsAutoHidePanel.Controls.Add(Me.SearchButton)
       Me.SearchFieldsAutoHidePanel.Controls.Add(Me.CancelSearchButton)
       Me.SearchFieldsAutoHidePanel.Controls.Add(Me.ClearSearchButton)
       Me.SearchFieldsAutoHidePanel.Controls.Add(Me.SearchSourceGroupBox)
       Me.SearchFieldsAutoHidePanel.Dock = System.Windows.Forms.DockStyle.Top
       Me.SearchFieldsAutoHidePanel.EnableResizing = False
       Me.SearchFieldsAutoHidePanel.Location = New System.Drawing.Point(0, 0)
       Me.SearchFieldsAutoHidePanel.Name = "SearchFieldsAutoHidePanel"
       Me.SearchFieldsAutoHidePanel.Size = New System.Drawing.Size(1168, 205)
       Me.SearchFieldsAutoHidePanel.State = Leadtools.Medical.Workstation.UI.AutoHidePanelState.Expanded
       Me.SearchFieldsAutoHidePanel.StickPinAttached = (CType(resources.GetObject("SearchFieldsAutoHidePanel.StickPinAttached"), System.Drawing.Bitmap))
       Me.SearchFieldsAutoHidePanel.StickPinUnattached = (CType(resources.GetObject("SearchFieldsAutoHidePanel.StickPinUnattached"), System.Drawing.Bitmap))
		 Me.SearchFieldsAutoHidePanel.TabIndex = 12
		 Me.SearchFieldsAutoHidePanel.TopLevel = False
		 ' 
		 ' StudiesQueryGroupBox
		 ' 
		 Me.StudiesQueryGroupBox.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
		 Me.StudiesQueryGroupBox.Controls.Add(Me.StudyToDateTimePicker)
		 Me.StudiesQueryGroupBox.Controls.Add(Me.StudyFromDateTimePicker)
		 Me.StudiesQueryGroupBox.Controls.Add(Me.StudyToLabel)
		 Me.StudiesQueryGroupBox.Controls.Add(Me.StudyFromLabel)
		 Me.StudiesQueryGroupBox.Controls.Add(Me.StudyDateLabel)
		 Me.StudiesQueryGroupBox.Controls.Add(Me.RefDrGivenNameTextBox)
		 Me.StudiesQueryGroupBox.Controls.Add(Me.RefDrGivenNameLabel)
		 Me.StudiesQueryGroupBox.Controls.Add(Me.RefDrLastNameTextBox)
		 Me.StudiesQueryGroupBox.Controls.Add(Me.RefDrLastNameLabel)
		 Me.StudiesQueryGroupBox.Controls.Add(Me.AccessionNumberTextBox)
		 Me.StudiesQueryGroupBox.Controls.Add(Me.AccessionNumLabel)
		 Me.StudiesQueryGroupBox.Controls.Add(Me.StudiesIDTextBox)
		 Me.StudiesQueryGroupBox.Controls.Add(Me.StudiesIDLabel)
		 Me.StudiesQueryGroupBox.ForeColor = System.Drawing.Color.White
		 Me.StudiesQueryGroupBox.Location = New System.Drawing.Point(364, -1)
		 Me.StudiesQueryGroupBox.Name = "StudiesQueryGroupBox"
		 Me.StudiesQueryGroupBox.Size = New System.Drawing.Size(574, 196)
		 Me.StudiesQueryGroupBox.TabIndex = 2
		 Me.StudiesQueryGroupBox.TabStop = False
		 Me.StudiesQueryGroupBox.Text = "Studies"
		 ' 
		 ' StudyToDateTimePicker
		 ' 
		 Me.StudyToDateTimePicker.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
		 Me.StudyToDateTimePicker.CustomFormat = "MM/dd/yyyy HH:mm:ss"
		 Me.StudyToDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom
		 Me.StudyToDateTimePicker.Location = New System.Drawing.Point(178, 165)
		 Me.StudyToDateTimePicker.Name = "StudyToDateTimePicker"
		 Me.StudyToDateTimePicker.ShowCheckBox = True
		 Me.StudyToDateTimePicker.Size = New System.Drawing.Size(390, 20)
		 Me.StudyToDateTimePicker.TabIndex = 12
		 ' 
		 ' StudyFromDateTimePicker
		 ' 
		 Me.StudyFromDateTimePicker.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
		 Me.StudyFromDateTimePicker.CustomFormat = "MM/dd/yyyy HH:mm:ss"
		 Me.StudyFromDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom
		 Me.StudyFromDateTimePicker.Location = New System.Drawing.Point(178, 140)
		 Me.StudyFromDateTimePicker.Name = "StudyFromDateTimePicker"
		 Me.StudyFromDateTimePicker.ShowCheckBox = True
		 Me.StudyFromDateTimePicker.Size = New System.Drawing.Size(390, 20)
		 Me.StudyFromDateTimePicker.TabIndex = 10
		 ' 
		 ' StudyToLabel
		 ' 
		 Me.StudyToLabel.AutoSize = True
		 Me.StudyToLabel.Location = New System.Drawing.Point(127, 168)
		 Me.StudyToLabel.Name = "StudyToLabel"
		 Me.StudyToLabel.Size = New System.Drawing.Size(22, 14)
		 Me.StudyToLabel.TabIndex = 11
		 Me.StudyToLabel.Text = "To:"
		 ' 
		 ' StudyFromLabel
		 ' 
		 Me.StudyFromLabel.AutoSize = True
		 Me.StudyFromLabel.Location = New System.Drawing.Point(127, 143)
		 Me.StudyFromLabel.Name = "StudyFromLabel"
		 Me.StudyFromLabel.Size = New System.Drawing.Size(34, 14)
		 Me.StudyFromLabel.TabIndex = 9
		 Me.StudyFromLabel.Text = "From:"
		 ' 
		 ' StudyDateLabel
		 ' 
		 Me.StudyDateLabel.AutoSize = True
		 Me.StudyDateLabel.Location = New System.Drawing.Point(7, 143)
		 Me.StudyDateLabel.Name = "StudyDateLabel"
		 Me.StudyDateLabel.Size = New System.Drawing.Size(63, 14)
		 Me.StudyDateLabel.TabIndex = 8
		 Me.StudyDateLabel.Text = "Study Date:"
		 ' 
		 ' RefDrGivenNameTextBox
		 ' 
		 Me.RefDrGivenNameTextBox.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
		 Me.RefDrGivenNameTextBox.BackColor = System.Drawing.SystemColors.Window
		 Me.RefDrGivenNameTextBox.Location = New System.Drawing.Point(130, 110)
		 Me.RefDrGivenNameTextBox.Name = "RefDrGivenNameTextBox"
		 Me.RefDrGivenNameTextBox.Size = New System.Drawing.Size(438, 20)
		 Me.RefDrGivenNameTextBox.TabIndex = 7
		 ' 
		 ' RefDrGivenNameLabel
		 ' 
		 Me.RefDrGivenNameLabel.AutoSize = True
		 Me.RefDrGivenNameLabel.Location = New System.Drawing.Point(5, 110)
		 Me.RefDrGivenNameLabel.Name = "RefDrGivenNameLabel"
		 Me.RefDrGivenNameLabel.Size = New System.Drawing.Size(98, 14)
		 Me.RefDrGivenNameLabel.TabIndex = 6
		 Me.RefDrGivenNameLabel.Text = "Phys. Given Name:"
		 ' 
		 ' RefDrLastNameTextBox
		 ' 
		 Me.RefDrLastNameTextBox.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
		 Me.RefDrLastNameTextBox.BackColor = System.Drawing.SystemColors.Window
		 Me.RefDrLastNameTextBox.Location = New System.Drawing.Point(130, 81)
		 Me.RefDrLastNameTextBox.Name = "RefDrLastNameTextBox"
		 Me.RefDrLastNameTextBox.Size = New System.Drawing.Size(438, 20)
		 Me.RefDrLastNameTextBox.TabIndex = 5
		 ' 
		 ' RefDrLastNameLabel
		 ' 
		 Me.RefDrLastNameLabel.AutoSize = True
		 Me.RefDrLastNameLabel.Location = New System.Drawing.Point(5, 81)
		 Me.RefDrLastNameLabel.Name = "RefDrLastNameLabel"
		 Me.RefDrLastNameLabel.Size = New System.Drawing.Size(91, 14)
		 Me.RefDrLastNameLabel.TabIndex = 4
		 Me.RefDrLastNameLabel.Text = "Phys. Last Name:"
		 ' 
		 ' AccessionNumberTextBox
		 ' 
		 Me.AccessionNumberTextBox.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
		 Me.AccessionNumberTextBox.BackColor = System.Drawing.SystemColors.Window
		 Me.AccessionNumberTextBox.Location = New System.Drawing.Point(130, 52)
		 Me.AccessionNumberTextBox.Name = "AccessionNumberTextBox"
		 Me.AccessionNumberTextBox.Size = New System.Drawing.Size(438, 20)
		 Me.AccessionNumberTextBox.TabIndex = 3
		 ' 
		 ' AccessionNumLabel
		 ' 
		 Me.AccessionNumLabel.AutoSize = True
		 Me.AccessionNumLabel.Location = New System.Drawing.Point(5, 52)
		 Me.AccessionNumLabel.Name = "AccessionNumLabel"
		 Me.AccessionNumLabel.Size = New System.Drawing.Size(68, 14)
		 Me.AccessionNumLabel.TabIndex = 2
		 Me.AccessionNumLabel.Text = "Accession#:"
		 ' 
		 ' StudiesIDTextBox
		 ' 
		 Me.StudiesIDTextBox.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
		 Me.StudiesIDTextBox.BackColor = System.Drawing.SystemColors.Window
		 Me.StudiesIDTextBox.Location = New System.Drawing.Point(130, 23)
		 Me.StudiesIDTextBox.Name = "StudiesIDTextBox"
		 Me.StudiesIDTextBox.Size = New System.Drawing.Size(438, 20)
		 Me.StudiesIDTextBox.TabIndex = 1
		 ' 
		 ' StudiesIDLabel
		 ' 
		 Me.StudiesIDLabel.AutoSize = True
		 Me.StudiesIDLabel.Location = New System.Drawing.Point(5, 23)
		 Me.StudiesIDLabel.Name = "StudiesIDLabel"
		 Me.StudiesIDLabel.Size = New System.Drawing.Size(50, 14)
		 Me.StudiesIDLabel.TabIndex = 0
		 Me.StudiesIDLabel.Text = "Study ID:"
		 ' 
		 ' PatientGroupBox
		 ' 
		 Me.PatientGroupBox.Controls.Add(Me.PatientGivenNameTextBox)
		 Me.PatientGroupBox.Controls.Add(Me.PatientGivenNameLabel)
		 Me.PatientGroupBox.Controls.Add(Me.PatientIDTextBox)
		 Me.PatientGroupBox.Controls.Add(Me.PatientLastNameTextBox)
		 Me.PatientGroupBox.Controls.Add(Me.PatientIDLabel)
		 Me.PatientGroupBox.Controls.Add(Me.PatientLastNameLabel)
		 Me.PatientGroupBox.ForeColor = System.Drawing.Color.White
		 Me.PatientGroupBox.Location = New System.Drawing.Point(3, -1)
		 Me.PatientGroupBox.Name = "PatientGroupBox"
		 Me.PatientGroupBox.Size = New System.Drawing.Size(355, 110)
		 Me.PatientGroupBox.TabIndex = 0
		 Me.PatientGroupBox.TabStop = False
		 Me.PatientGroupBox.Text = "Patient"
		 ' 
		 ' PatientGivenNameTextBox
		 ' 
		 Me.PatientGivenNameTextBox.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
		 Me.PatientGivenNameTextBox.BackColor = System.Drawing.SystemColors.Window
		 Me.PatientGivenNameTextBox.Location = New System.Drawing.Point(102, 52)
		 Me.PatientGivenNameTextBox.Name = "PatientGivenNameTextBox"
		 Me.PatientGivenNameTextBox.Size = New System.Drawing.Size(243, 20)
		 Me.PatientGivenNameTextBox.TabIndex = 3
		 ' 
		 ' PatientGivenNameLabel
		 ' 
		 Me.PatientGivenNameLabel.AutoSize = True
		 Me.PatientGivenNameLabel.Location = New System.Drawing.Point(3, 52)
		 Me.PatientGivenNameLabel.Name = "PatientGivenNameLabel"
		 Me.PatientGivenNameLabel.Size = New System.Drawing.Size(68, 14)
		 Me.PatientGivenNameLabel.TabIndex = 2
		 Me.PatientGivenNameLabel.Text = "Given Name:"
		 ' 
		 ' PatientIDTextBox
		 ' 
		 Me.PatientIDTextBox.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
		 Me.PatientIDTextBox.BackColor = System.Drawing.SystemColors.Window
		 Me.PatientIDTextBox.Location = New System.Drawing.Point(102, 81)
		 Me.PatientIDTextBox.Name = "PatientIDTextBox"
		 Me.PatientIDTextBox.Size = New System.Drawing.Size(243, 20)
		 Me.PatientIDTextBox.TabIndex = 5
		 ' 
		 ' PatientLastNameTextBox
		 ' 
		 Me.PatientLastNameTextBox.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
		 Me.PatientLastNameTextBox.BackColor = System.Drawing.SystemColors.Window
		 Me.PatientLastNameTextBox.Location = New System.Drawing.Point(102, 23)
		 Me.PatientLastNameTextBox.Name = "PatientLastNameTextBox"
		 Me.PatientLastNameTextBox.Size = New System.Drawing.Size(243, 20)
		 Me.PatientLastNameTextBox.TabIndex = 1
		 ' 
		 ' PatientIDLabel
		 ' 
		 Me.PatientIDLabel.AutoSize = True
		 Me.PatientIDLabel.Location = New System.Drawing.Point(3, 81)
		 Me.PatientIDLabel.Name = "PatientIDLabel"
		 Me.PatientIDLabel.Size = New System.Drawing.Size(54, 14)
		 Me.PatientIDLabel.TabIndex = 4
		 Me.PatientIDLabel.Text = "Patient ID:"
		 ' 
		 ' PatientLastNameLabel
		 ' 
		 Me.PatientLastNameLabel.AutoSize = True
		 Me.PatientLastNameLabel.Location = New System.Drawing.Point(3, 23)
		 Me.PatientLastNameLabel.Name = "PatientLastNameLabel"
		 Me.PatientLastNameLabel.Size = New System.Drawing.Size(61, 14)
		 Me.PatientLastNameLabel.TabIndex = 0
		 Me.PatientLastNameLabel.Text = "Last Name:"
		 ' 
		 ' ModalitiesGroupBox
		 ' 
		 Me.ModalitiesGroupBox.Controls.Add(Me.ModalitiesSelectAllCheckBox)
		 Me.ModalitiesGroupBox.Controls.Add(Me.ModalitiesCheckedComboBox)
		 Me.ModalitiesGroupBox.ForeColor = System.Drawing.Color.White
		 Me.ModalitiesGroupBox.Location = New System.Drawing.Point(5, 111)
		 Me.ModalitiesGroupBox.Name = "ModalitiesGroupBox"
		 Me.ModalitiesGroupBox.Size = New System.Drawing.Size(355, 84)
		 Me.ModalitiesGroupBox.TabIndex = 1
		 Me.ModalitiesGroupBox.TabStop = False
		 Me.ModalitiesGroupBox.Text = "Modalities"
		 ' 
		 ' ModalitiesSelectAllCheckBox
		 ' 
		 Me.ModalitiesSelectAllCheckBox.AutoSize = True
		 Me.ModalitiesSelectAllCheckBox.Location = New System.Drawing.Point(6, 45)
		 Me.ModalitiesSelectAllCheckBox.Name = "ModalitiesSelectAllCheckBox"
		 Me.ModalitiesSelectAllCheckBox.Size = New System.Drawing.Size(71, 18)
		 Me.ModalitiesSelectAllCheckBox.TabIndex = 1
		 Me.ModalitiesSelectAllCheckBox.Text = "Select All"
		 Me.ModalitiesSelectAllCheckBox.UseVisualStyleBackColor = True
		 ' 
		 ' SearchSourceGroupBox
		 ' 
		 Me.SearchSourceGroupBox.Anchor = (CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
		 Me.SearchSourceGroupBox.Controls.Add(Me.PacsServersComboBox)
		 Me.SearchSourceGroupBox.Controls.Add(Me.PacsServerRadioButton)
		 Me.SearchSourceGroupBox.Controls.Add(Me.LocalDatabaseRadioButton)
		 Me.SearchSourceGroupBox.ForeColor = System.Drawing.Color.White
		 Me.SearchSourceGroupBox.Location = New System.Drawing.Point(944, -2)
		 Me.SearchSourceGroupBox.Name = "SearchSourceGroupBox"
		 Me.SearchSourceGroupBox.Size = New System.Drawing.Size(209, 125)
		 Me.SearchSourceGroupBox.TabIndex = 3
		 Me.SearchSourceGroupBox.TabStop = False
		 Me.SearchSourceGroupBox.Text = "Source:"
		 ' 
		 ' PacsServersComboBox
		 ' 
		 Me.PacsServersComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		 Me.PacsServersComboBox.FormattingEnabled = True
		 Me.PacsServersComboBox.Location = New System.Drawing.Point(25, 79)
		 Me.PacsServersComboBox.Name = "PacsServersComboBox"
		 Me.PacsServersComboBox.Size = New System.Drawing.Size(178, 22)
		 Me.PacsServersComboBox.TabIndex = 2
		 ' 
		 ' PacsServerRadioButton
		 ' 
		 Me.PacsServerRadioButton.AutoSize = True
		 Me.PacsServerRadioButton.Location = New System.Drawing.Point(6, 53)
		 Me.PacsServerRadioButton.Name = "PacsServerRadioButton"
		 Me.PacsServerRadioButton.Size = New System.Drawing.Size(89, 18)
		 Me.PacsServerRadioButton.TabIndex = 1
		 Me.PacsServerRadioButton.TabStop = True
		 Me.PacsServerRadioButton.Text = "PACS Server"
		 Me.PacsServerRadioButton.UseVisualStyleBackColor = True
		 ' 
		 ' LocalDatabaseRadioButton
		 ' 
		 Me.LocalDatabaseRadioButton.AutoSize = True
		 Me.LocalDatabaseRadioButton.Checked = True
		 Me.LocalDatabaseRadioButton.Location = New System.Drawing.Point(6, 22)
		 Me.LocalDatabaseRadioButton.Name = "LocalDatabaseRadioButton"
		 Me.LocalDatabaseRadioButton.Size = New System.Drawing.Size(100, 18)
		 Me.LocalDatabaseRadioButton.TabIndex = 0
		 Me.LocalDatabaseRadioButton.TabStop = True
		 Me.LocalDatabaseRadioButton.Text = "Local Database"
		 Me.LocalDatabaseRadioButton.UseVisualStyleBackColor = True
		 ' 
		 ' ModalitiesCheckedComboBox
		 ' 
		 Me.ModalitiesCheckedComboBox.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
		 Me.ModalitiesCheckedComboBox.ColumnDelimeter = ControlChars.NullChar
		 Me.ModalitiesCheckedComboBox.DisplayView = Leadtools.Medical.Winforms.Control.CheckedComboBox.View.Columns
		 Me.ModalitiesCheckedComboBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable
		 Me.ModalitiesCheckedComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		 Me.ModalitiesCheckedComboBox.Location = New System.Drawing.Point(6, 19)
		 Me.ModalitiesCheckedComboBox.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
		 Me.ModalitiesCheckedComboBox.Name = "ModalitiesCheckedComboBox"
		 Me.ModalitiesCheckedComboBox.Size = New System.Drawing.Size(339, 21)
		 Me.ModalitiesCheckedComboBox.TabIndex = 0
		 ' 
		 ' AddToMediaBurningManagerToolStripMenuItem
		 ' 
		 Me.AddToMediaBurningManagerToolStripMenuItem.Name = "AddToMediaBurningManagerToolStripMenuItem"
		 Me.AddToMediaBurningManagerToolStripMenuItem.Size = New System.Drawing.Size(241, 22)
		 Me.AddToMediaBurningManagerToolStripMenuItem.Text = "Add to Media Burning Manager"
		 ' 
		 ' toolStripSeparator2
		 ' 
		 Me.toolStripSeparator2.Name = "toolStripSeparator2"
		 Me.toolStripSeparator2.Size = New System.Drawing.Size(238, 6)
		 ' 
		 ' SearchStudies
		 ' 
		 Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 14F)
		 Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		 Me.AutoScroll = True
		 Me.BackColor = System.Drawing.Color.FromArgb((CInt(Fix((CByte(75))))), (CInt(Fix((CByte(75))))), (CInt(Fix((CByte(75))))))
		 Me.Controls.Add(Me.SeriesGroupBox)
		 Me.Controls.Add(Me.StudiesSeriesSplitter)
		 Me.Controls.Add(Me.StudiesGroupBox)
		 Me.Controls.Add(Me.SearchFieldsAutoHidePanel)
		 Me.Font = New System.Drawing.Font("Arial", 8F)
		 Me.ForeColor = System.Drawing.Color.White
		 Me.Name = "SearchStudies"
		 Me.Size = New System.Drawing.Size(1168, 713)
		 Me.StudiesGroupBox.ResumeLayout(False)
		 CType(Me.StudiesDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
		 CType(Me.clientQueryDataSetBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
		 Me.StudiesContextMenuStrip.ResumeLayout(False)
		 Me.SeriesGroupBox.ResumeLayout(False)
		 CType(Me.SeriesDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
		 Me.SeriesContextMenuStrip.ResumeLayout(False)
		 CType(Me.seriesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
		 Me.ServerStudiesContextMenuStrip.ResumeLayout(False)
		 Me.ServerSeriesContextMenuStrip.ResumeLayout(False)
		 Me.ServersStudyStoreContextMenuStrip.ResumeLayout(False)
		 Me.SearchFieldsAutoHidePanel.ResumeLayout(False)
		 Me.StudiesQueryGroupBox.ResumeLayout(False)
		 Me.StudiesQueryGroupBox.PerformLayout()
		 Me.PatientGroupBox.ResumeLayout(False)
		 Me.PatientGroupBox.PerformLayout()
		 Me.ModalitiesGroupBox.ResumeLayout(False)
		 Me.ModalitiesGroupBox.PerformLayout()
		 Me.SearchSourceGroupBox.ResumeLayout(False)
		 Me.SearchSourceGroupBox.PerformLayout()
		 Me.ResumeLayout(False)

	  End Sub

	  #End Region

	  Private clientQueryDataSetBindingSource As System.Windows.Forms.BindingSource
	  Private seriesBindingSource As System.Windows.Forms.BindingSource
	  Protected SearchFieldsAutoHidePanel As Leadtools.Medical.Workstation.UI.AutoHidePanel
	  Protected StudiesQueryGroupBox As System.Windows.Forms.GroupBox
	  Protected SearchSourceGroupBox As System.Windows.Forms.GroupBox
	  Protected CancelSearchButton As System.Windows.Forms.Button
	  Protected ClearSearchButton As System.Windows.Forms.Button
	  Protected SearchButton As System.Windows.Forms.Button
	  Protected StudyDateLabel As System.Windows.Forms.Label
	  Protected StudyFromDateTimePicker As System.Windows.Forms.DateTimePicker
	  Protected StudyToDateTimePicker As System.Windows.Forms.DateTimePicker
	  Protected PatientLastNameTextBox As System.Windows.Forms.TextBox
	  Protected RefDrLastNameLabel As System.Windows.Forms.Label
	  Protected PatientIDTextBox As System.Windows.Forms.TextBox
	  Protected AccessionNumLabel As System.Windows.Forms.Label
	  Protected StudiesIDTextBox As System.Windows.Forms.TextBox
	  Protected StudiesIDLabel As System.Windows.Forms.Label
	  Protected PatientGroupBox As System.Windows.Forms.GroupBox
	  Protected AccessionNumberTextBox As System.Windows.Forms.TextBox
	  Protected RefDrLastNameTextBox As System.Windows.Forms.TextBox
	  Protected PatientIDLabel As System.Windows.Forms.Label
	  Protected PatientLastNameLabel As System.Windows.Forms.Label
	  Protected StudiesGroupBox As System.Windows.Forms.GroupBox
	  Protected StudiesSeriesSplitter As System.Windows.Forms.Splitter
	  Protected StudiesDataGridView As System.Windows.Forms.DataGridView
	  Protected SeriesGroupBox As System.Windows.Forms.GroupBox
	  Protected SeriesDataGridView As System.Windows.Forms.DataGridView
	  Protected SeriesContextMenuStrip As System.Windows.Forms.ContextMenuStrip
	  Protected ViewSeriesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
	  Protected ModalitiesCheckedComboBox As Leadtools.Medical.Winforms.Control.CheckedComboBox
	  Protected OpenInViewerToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
	  Protected StudiesContextMenuStrip As System.Windows.Forms.ContextMenuStrip
	  Protected AddStudyToViewerToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
	  Protected OpenStudyInViewerToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
	  Protected ModalitiesSelectAllCheckBox As System.Windows.Forms.CheckBox
	  Protected LocalDatabaseRadioButton As System.Windows.Forms.RadioButton
	  Protected PacsServerRadioButton As System.Windows.Forms.RadioButton
	  Protected patientIDDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
	  Protected PatientNameDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
	  Protected patientBirthDateDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
	  Protected PatientSexDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
	  Protected StudyDescriptionDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
	  Protected StudyDateDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
	  Protected AccessionNumberDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
	  Protected ReferDrNameDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
	  Protected StudyInstanceUIDDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
	  Protected PacsServersComboBox As System.Windows.Forms.ComboBox
	  Protected ServerStudiesContextMenuStrip As System.Windows.Forms.ContextMenuStrip
	  Protected AddStudiesToQueuetoolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
	  Protected ServerSeriesContextMenuStrip As System.Windows.Forms.ContextMenuStrip
	  Protected AddSeriesToQueuetoolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
	  Protected ServersStudyStoreContextMenuStrip As System.Windows.Forms.ContextMenuStrip
	  Protected toolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
	  Protected StoreStudyToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
	  Protected StoreStudyToServersToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
	  Protected QueryToolTip As System.Windows.Forms.ToolTip
	  Protected PatientGivenNameTextBox As System.Windows.Forms.TextBox
	  Protected PatientGivenNameLabel As System.Windows.Forms.Label
	  Protected ModalitiesGroupBox As System.Windows.Forms.GroupBox
	  Protected RefDrGivenNameTextBox As System.Windows.Forms.TextBox
	  Protected RefDrGivenNameLabel As System.Windows.Forms.Label
	  Protected StudyToLabel As System.Windows.Forms.Label
	  Protected StudyFromLabel As System.Windows.Forms.Label
	  Private SeriesNumberDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
	  Private SeriesDescriptionDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
	  Private ModalityDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
	  Private SeriesDateDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
	  Private SeriesTimeDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
	  Private FrameCountDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
	  Private SerStudyInstanceUIDDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
	  Private SeriesInstanceUIDDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
	  Private VolumeReadyColumn As System.Windows.Forms.DataGridViewImageColumn
	  Private AddToMediaBurningManagerToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
	  Private toolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
   End Class
End Namespace

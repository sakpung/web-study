Imports Microsoft.VisualBasic
Imports System
Imports Leadtools.Controls
Imports Leadtools.Annotations.WinForms
Namespace FormsDemo
   Partial Public Class RecognitionResult
      ''' <summary>
      ''' Required designer variable.
      ''' </summary>
      Private components As System.ComponentModel.IContainer = Nothing

      ''' <summary>
      ''' Clean up any resources being used.
      ''' </summary>
      ''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
      Protected Overrides Sub Dispose(ByVal disposing As Boolean)
         If disposing AndAlso (Not components Is Nothing) Then
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
         Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(RecognitionResult))
         Dim dataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
         Me._splitContainer1 = New System.Windows.Forms.SplitContainer()
         Me._splitContainer2 = New System.Windows.Forms.SplitContainer()
         Me._txtPageConfidence = New System.Windows.Forms.TextBox()
         Me.label5 = New System.Windows.Forms.Label()
         Me._txtFormConficence = New System.Windows.Forms.TextBox()
         Me.label4 = New System.Windows.Forms.Label()
         Me._txtMasterForm = New System.Windows.Forms.TextBox()
         Me._cmbSelectedPage = New System.Windows.Forms.ComboBox()
         Me._cmbSelectedForm = New System.Windows.Forms.ComboBox()
         Me.label3 = New System.Windows.Forms.Label()
         Me.label2 = New System.Windows.Forms.Label()
         Me.label1 = New System.Windows.Forms.Label()
         Me._splitContainer3 = New System.Windows.Forms.SplitContainer()
         Me._tableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
         Me._fieldViewer = New ImageViewer()
         Me._fieldViewerToobar = New System.Windows.Forms.ToolStrip()
         Me._btnFieldPan = New System.Windows.Forms.ToolStripButton()
         Me._btnFieldZoomRect = New System.Windows.Forms.ToolStripButton()
         Me._btnFieldZoomNormal = New System.Windows.Forms.ToolStripButton()
         Me._btnFieldZoomIn = New System.Windows.Forms.ToolStripButton()
         Me._btnFieldZoomOut = New System.Windows.Forms.ToolStripButton()
         Me._btnFieldFit = New System.Windows.Forms.ToolStripButton()
         Me._btnFieldFitWidth = New System.Windows.Forms.ToolStripButton()
         Me._fieldResults = New System.Windows.Forms.DataGridView()
         Me._tableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
         Me._filledFormViewer = New AutomationImageViewer()
         Me._filledFormViewerToolbar = New System.Windows.Forms.ToolStrip()
         Me._btnFormPan = New System.Windows.Forms.ToolStripButton()
         Me._btnFormZoomRect = New System.Windows.Forms.ToolStripButton()
         Me._btnFormZoomNormal = New System.Windows.Forms.ToolStripButton()
         Me._btnFormZoomIn = New System.Windows.Forms.ToolStripButton()
         Me._btnFormZoomOut = New System.Windows.Forms.ToolStripButton()
         Me._btnFormFit = New System.Windows.Forms.ToolStripButton()
         Me._btnFormFitWidth = New System.Windows.Forms.ToolStripButton()
         Me._tablePanel2 = New System.Windows.Forms.TableLayoutPanel()
         Me._toolBar = New System.Windows.Forms.ToolStrip()
         Me._btnPanTool = New System.Windows.Forms.ToolStripButton()
         Me._btnZoomDrawTool = New System.Windows.Forms.ToolStripButton()
         Me._btnZoomNormal = New System.Windows.Forms.ToolStripButton()
         Me._btnZoomIn = New System.Windows.Forms.ToolStripButton()
         Me._btnZoomOut = New System.Windows.Forms.ToolStripButton()
         Me._btnFit = New System.Windows.Forms.ToolStripButton()
         Me._subSplitContainer = New System.Windows.Forms.SplitContainer()
         Me._viewer = New ImageViewer()
         Me._txtFieldInfo = New System.Windows.Forms.TextBox()
         Me._fieldName = New System.Windows.Forms.DataGridViewTextBoxColumn()
         Me._fieldType = New System.Windows.Forms.DataGridViewTextBoxColumn()
         Me._fieldResult = New System.Windows.Forms.DataGridViewTextBoxColumn()
         Me._confidence = New System.Windows.Forms.DataGridViewTextBoxColumn()
         Me._boundingRect = New System.Windows.Forms.DataGridViewTextBoxColumn()
         Me._splitContainer1.Panel1.SuspendLayout()
         Me._splitContainer1.Panel2.SuspendLayout()
         Me._splitContainer1.SuspendLayout()
         Me._splitContainer2.Panel1.SuspendLayout()
         Me._splitContainer2.Panel2.SuspendLayout()
         Me._splitContainer2.SuspendLayout()
         Me._splitContainer3.Panel1.SuspendLayout()
         Me._splitContainer3.Panel2.SuspendLayout()
         Me._splitContainer3.SuspendLayout()
         Me._tableLayoutPanel1.SuspendLayout()
         Me._fieldViewerToobar.SuspendLayout()
         CType(Me._fieldResults, System.ComponentModel.ISupportInitialize).BeginInit()
         Me._tableLayoutPanel2.SuspendLayout()
         Me._filledFormViewerToolbar.SuspendLayout()
         Me._tablePanel2.SuspendLayout()
         Me._toolBar.SuspendLayout()
         Me._subSplitContainer.Panel1.SuspendLayout()
         Me._subSplitContainer.Panel2.SuspendLayout()
         Me._subSplitContainer.SuspendLayout()
         Me.SuspendLayout()
         ' 
         ' _splitContainer1
         ' 
         Me._splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
         Me._splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
         Me._splitContainer1.Location = New System.Drawing.Point(0, 0)
         Me._splitContainer1.Name = "_splitContainer1"
         ' 
         ' _splitContainer1.Panel1
         ' 
         Me._splitContainer1.Panel1.Controls.Add(Me._splitContainer2)
         ' 
         ' _splitContainer1.Panel2
         ' 
         Me._splitContainer1.Panel2.Controls.Add(Me._tableLayoutPanel2)
         Me._splitContainer1.Size = New System.Drawing.Size(641, 447)
         Me._splitContainer1.SplitterDistance = 321
         Me._splitContainer1.TabIndex = 0
         ' 
         ' _splitContainer2
         ' 
         Me._splitContainer2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
         Me._splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill
         Me._splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
         Me._splitContainer2.IsSplitterFixed = True
         Me._splitContainer2.Location = New System.Drawing.Point(0, 0)
         Me._splitContainer2.Name = "_splitContainer2"
         Me._splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal
         ' 
         ' _splitContainer2.Panel1
         ' 
         Me._splitContainer2.Panel1.Controls.Add(Me._txtPageConfidence)
         Me._splitContainer2.Panel1.Controls.Add(Me.label5)
         Me._splitContainer2.Panel1.Controls.Add(Me._txtFormConficence)
         Me._splitContainer2.Panel1.Controls.Add(Me.label4)
         Me._splitContainer2.Panel1.Controls.Add(Me._txtMasterForm)
         Me._splitContainer2.Panel1.Controls.Add(Me._cmbSelectedPage)
         Me._splitContainer2.Panel1.Controls.Add(Me._cmbSelectedForm)
         Me._splitContainer2.Panel1.Controls.Add(Me.label3)
         Me._splitContainer2.Panel1.Controls.Add(Me.label2)
         Me._splitContainer2.Panel1.Controls.Add(Me.label1)
         ' 
         ' _splitContainer2.Panel2
         ' 
         Me._splitContainer2.Panel2.Controls.Add(Me._splitContainer3)
         Me._splitContainer2.Size = New System.Drawing.Size(321, 447)
         Me._splitContainer2.SplitterDistance = 142
         Me._splitContainer2.TabIndex = 0
         ' 
         ' _txtPageConfidence
         ' 
         Me._txtPageConfidence.Location = New System.Drawing.Point(120, 112)
         Me._txtPageConfidence.Name = "_txtPageConfidence"
         Me._txtPageConfidence.ReadOnly = True
         Me._txtPageConfidence.Size = New System.Drawing.Size(65, 20)
         Me._txtPageConfidence.TabIndex = 9
         ' 
         ' label5
         ' 
         Me.label5.AutoSize = True
         Me.label5.Location = New System.Drawing.Point(12, 115)
         Me.label5.Name = "label5"
         Me.label5.Size = New System.Drawing.Size(89, 13)
         Me.label5.TabIndex = 8
         Me.label5.Text = "Page Confidence"
         ' 
         ' _txtFormConficence
         ' 
         Me._txtFormConficence.Location = New System.Drawing.Point(120, 60)
         Me._txtFormConficence.Name = "_txtFormConficence"
         Me._txtFormConficence.ReadOnly = True
         Me._txtFormConficence.Size = New System.Drawing.Size(65, 20)
         Me._txtFormConficence.TabIndex = 7
         ' 
         ' label4
         ' 
         Me.label4.AutoSize = True
         Me.label4.Location = New System.Drawing.Point(12, 63)
         Me.label4.Name = "label4"
         Me.label4.Size = New System.Drawing.Size(87, 13)
         Me.label4.TabIndex = 6
         Me.label4.Text = "Form Confidence"
         ' 
         ' _txtMasterForm
         ' 
         Me._txtMasterForm.Location = New System.Drawing.Point(120, 34)
         Me._txtMasterForm.Name = "_txtMasterForm"
         Me._txtMasterForm.ReadOnly = True
         Me._txtMasterForm.Size = New System.Drawing.Size(194, 20)
         Me._txtMasterForm.TabIndex = 5
         ' 
         ' _cmbSelectedPage
         ' 
         Me._cmbSelectedPage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
         Me._cmbSelectedPage.FormattingEnabled = True
         Me._cmbSelectedPage.Location = New System.Drawing.Point(120, 86)
         Me._cmbSelectedPage.Name = "_cmbSelectedPage"
         Me._cmbSelectedPage.Size = New System.Drawing.Size(65, 21)
         Me._cmbSelectedPage.TabIndex = 4
         '		  Me._cmbSelectedPage.SelectedIndexChanged += New System.EventHandler(Me._cmbSelectedPage_SelectedIndexChanged);
         ' 
         ' _cmbSelectedForm
         ' 
         Me._cmbSelectedForm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
         Me._cmbSelectedForm.FormattingEnabled = True
         Me._cmbSelectedForm.Location = New System.Drawing.Point(120, 7)
         Me._cmbSelectedForm.Name = "_cmbSelectedForm"
         Me._cmbSelectedForm.Size = New System.Drawing.Size(194, 21)
         Me._cmbSelectedForm.TabIndex = 3
         '		  Me._cmbSelectedForm.SelectedIndexChanged += New System.EventHandler(Me._cmbSelectedForm_SelectedIndexChanged);
         ' 
         ' label3
         ' 
         Me.label3.AutoSize = True
         Me.label3.Location = New System.Drawing.Point(12, 37)
         Me.label3.Name = "label3"
         Me.label3.Size = New System.Drawing.Size(65, 13)
         Me.label3.TabIndex = 2
         Me.label3.Text = "Master Form"
         ' 
         ' label2
         ' 
         Me.label2.AutoSize = True
         Me.label2.Location = New System.Drawing.Point(12, 89)
         Me.label2.Name = "label2"
         Me.label2.Size = New System.Drawing.Size(77, 13)
         Me.label2.TabIndex = 1
         Me.label2.Text = "Selected Page"
         ' 
         ' label1
         ' 
         Me.label1.AutoSize = True
         Me.label1.Location = New System.Drawing.Point(12, 10)
         Me.label1.Name = "label1"
         Me.label1.Size = New System.Drawing.Size(102, 13)
         Me.label1.TabIndex = 0
         Me.label1.Text = "Selected Filled Form"
         ' 
         ' _splitContainer3
         ' 
         Me._splitContainer3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
         Me._splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill
         Me._splitContainer3.Location = New System.Drawing.Point(0, 0)
         Me._splitContainer3.Name = "_splitContainer3"
         Me._splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal
         ' 
         ' _splitContainer3.Panel1
         ' 
         Me._splitContainer3.Panel1.Controls.Add(Me._tableLayoutPanel1)
         ' 
         ' _splitContainer3.Panel2
         ' 
         Me._splitContainer3.Panel2.Controls.Add(Me._fieldResults)
         Me._splitContainer3.Size = New System.Drawing.Size(321, 301)
         Me._splitContainer3.SplitterDistance = 142
         Me._splitContainer3.TabIndex = 0
         ' 
         ' _tableLayoutPanel1
         ' 
         Me._tableLayoutPanel1.ColumnCount = 1
         Me._tableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0F))
         Me._tableLayoutPanel1.Controls.Add(Me._fieldViewer, 0, 1)
         Me._tableLayoutPanel1.Controls.Add(Me._fieldViewerToobar, 0, 0)
         Me._tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
         Me._tableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
         Me._tableLayoutPanel1.Name = "_tableLayoutPanel1"
         Me._tableLayoutPanel1.RowCount = 2
         Me._tableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26.0F))
         Me._tableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0F))
         Me._tableLayoutPanel1.Size = New System.Drawing.Size(317, 138)
         Me._tableLayoutPanel1.TabIndex = 0
         ' 
         ' _fieldViewer
         ' 
         Me._fieldViewer.ImageRegionRenderMode = ControlRegionRenderMode.Animated
         Me._fieldViewer.AutoDisposeImages = True
         Me._fieldViewer.AutoScroll = True
         Me._fieldViewer.BackColor = System.Drawing.SystemColors.AppWorkspace
         Me._fieldViewer.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
         Me._fieldViewer.Cursor = System.Windows.Forms.Cursors.Hand
         Me._fieldViewer.Dock = System.Windows.Forms.DockStyle.Fill
         Me._fieldViewer.ViewHorizontalAlignment = ControlAlignment.Near
         Me._fieldViewer.Image = Nothing
         Me._fieldViewer.Location = New System.Drawing.Point(3, 29)
         Me._fieldViewer.Name = "_fieldViewer"
         Me._fieldViewer.Size = New System.Drawing.Size(311, 106)
         Me._fieldViewer.Zoom(ControlSizeMode.ActualSize, 1, Me._fieldViewer.DefaultZoomOrigin)
         Me._fieldViewer.TabIndex = 2
         Me._fieldViewer.Text = "rasterImageViewer1"
         Me._fieldViewer.UseDpi = False
         Me._fieldViewer.ViewVerticalAlignment = ControlAlignment.Near
         ' 
         ' _fieldViewerToobar
         ' 
         Me._fieldViewerToobar.BackColor = System.Drawing.SystemColors.MenuBar
         Me._fieldViewerToobar.Dock = System.Windows.Forms.DockStyle.Fill
         Me._fieldViewerToobar.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
         Me._fieldViewerToobar.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me._btnFieldPan, Me._btnFieldZoomRect, Me._btnFieldZoomNormal, Me._btnFieldZoomIn, Me._btnFieldZoomOut, Me._btnFieldFit, Me._btnFieldFitWidth})
         Me._fieldViewerToobar.Location = New System.Drawing.Point(0, 0)
         Me._fieldViewerToobar.Name = "_fieldViewerToobar"
         Me._fieldViewerToobar.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
         Me._fieldViewerToobar.Size = New System.Drawing.Size(317, 26)
         Me._fieldViewerToobar.TabIndex = 1
         Me._fieldViewerToobar.Text = "toolStrip1"
         ' 
         ' _btnFieldPan
         ' 
         Me._btnFieldPan.Checked = True
         Me._btnFieldPan.CheckOnClick = True
         Me._btnFieldPan.CheckState = System.Windows.Forms.CheckState.Checked
         Me._btnFieldPan.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
         Me._btnFieldPan.Image = (CType(resources.GetObject("_btnFieldPan.Image"), System.Drawing.Image))
         Me._btnFieldPan.ImageTransparentColor = System.Drawing.Color.Magenta
         Me._btnFieldPan.Name = "_btnFieldPan"
         Me._btnFieldPan.Size = New System.Drawing.Size(23, 23)
         Me._btnFieldPan.Text = "Pan"
         '		  Me._btnFieldPan.Click += New System.EventHandler(Me._btnFieldPan_Click);
         ' 
         ' _btnFieldZoomRect
         ' 
         Me._btnFieldZoomRect.CheckOnClick = True
         Me._btnFieldZoomRect.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
         Me._btnFieldZoomRect.Image = (CType(resources.GetObject("_btnFieldZoomRect.Image"), System.Drawing.Image))
         Me._btnFieldZoomRect.ImageTransparentColor = System.Drawing.Color.Magenta
         Me._btnFieldZoomRect.Name = "_btnFieldZoomRect"
         Me._btnFieldZoomRect.Size = New System.Drawing.Size(23, 23)
         Me._btnFieldZoomRect.Text = "Zoom To Selection"
         '		  Me._btnFieldZoomRect.Click += New System.EventHandler(Me._btnFieldZoomRect_Click);
         ' 
         ' _btnFieldZoomNormal
         ' 
         Me._btnFieldZoomNormal.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
         Me._btnFieldZoomNormal.Image = (CType(resources.GetObject("_btnFieldZoomNormal.Image"), System.Drawing.Image))
         Me._btnFieldZoomNormal.ImageTransparentColor = System.Drawing.Color.Magenta
         Me._btnFieldZoomNormal.Name = "_btnFieldZoomNormal"
         Me._btnFieldZoomNormal.Size = New System.Drawing.Size(23, 23)
         Me._btnFieldZoomNormal.Text = "Normal"
         '		  Me._btnFieldZoomNormal.Click += New System.EventHandler(Me._btnFieldZoomNormal_Click);
         ' 
         ' _btnFieldZoomIn
         ' 
         Me._btnFieldZoomIn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
         Me._btnFieldZoomIn.Image = (CType(resources.GetObject("_btnFieldZoomIn.Image"), System.Drawing.Image))
         Me._btnFieldZoomIn.ImageTransparentColor = System.Drawing.Color.Magenta
         Me._btnFieldZoomIn.Name = "_btnFieldZoomIn"
         Me._btnFieldZoomIn.Size = New System.Drawing.Size(23, 23)
         Me._btnFieldZoomIn.Text = "Zoom In"
         '		  Me._btnFieldZoomIn.Click += New System.EventHandler(Me._btnFieldZoomIn_Click);
         ' 
         ' _btnFieldZoomOut
         ' 
         Me._btnFieldZoomOut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
         Me._btnFieldZoomOut.Image = (CType(resources.GetObject("_btnFieldZoomOut.Image"), System.Drawing.Image))
         Me._btnFieldZoomOut.ImageTransparentColor = System.Drawing.Color.Magenta
         Me._btnFieldZoomOut.Name = "_btnFieldZoomOut"
         Me._btnFieldZoomOut.Size = New System.Drawing.Size(23, 23)
         Me._btnFieldZoomOut.Text = "Zoom Out"
         '		  Me._btnFieldZoomOut.Click += New System.EventHandler(Me._btnFieldZoomOut_Click);
         ' 
         ' _btnFieldFit
         ' 
         Me._btnFieldFit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
         Me._btnFieldFit.Image = (CType(resources.GetObject("_btnFieldFit.Image"), System.Drawing.Image))
         Me._btnFieldFit.ImageTransparentColor = System.Drawing.Color.Magenta
         Me._btnFieldFit.Name = "_btnFieldFit"
         Me._btnFieldFit.Size = New System.Drawing.Size(23, 23)
         Me._btnFieldFit.Text = "Fit To Window"
         '		  Me._btnFieldFit.Click += New System.EventHandler(Me._btnFieldFit_Click);
         ' 
         ' _btnFieldFitWidth
         ' 
         Me._btnFieldFitWidth.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
         Me._btnFieldFitWidth.Image = (CType(resources.GetObject("_btnFieldFitWidth.Image"), System.Drawing.Image))
         Me._btnFieldFitWidth.ImageTransparentColor = System.Drawing.Color.Magenta
         Me._btnFieldFitWidth.Name = "_btnFieldFitWidth"
         Me._btnFieldFitWidth.Size = New System.Drawing.Size(23, 23)
         Me._btnFieldFitWidth.Text = "Fit To Image Width"
         '		  Me._btnFieldFitWidth.Click += New System.EventHandler(Me._btnFieldFitWidth_Click);
         ' 
         ' _fieldResults
         ' 
         Me._fieldResults.AllowUserToAddRows = False
         Me._fieldResults.AllowUserToDeleteRows = False
         Me._fieldResults.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
         Me._fieldResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
         Me._fieldResults.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me._fieldName, Me._fieldType, Me._fieldResult, Me._confidence, Me._boundingRect})
         Me._fieldResults.Dock = System.Windows.Forms.DockStyle.Fill
         Me._fieldResults.Location = New System.Drawing.Point(0, 0)
         Me._fieldResults.MultiSelect = False
         Me._fieldResults.Name = "_fieldResults"
         Me._fieldResults.ReadOnly = True
         Me._fieldResults.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
         Me._fieldResults.Size = New System.Drawing.Size(317, 151)
         Me._fieldResults.TabIndex = 0
         '		  Me._fieldResults.MouseDoubleClick += New System.Windows.Forms.MouseEventHandler(Me._fieldResults_MouseDoubleClick);
         '		  Me._fieldResults.SelectionChanged += New System.EventHandler(Me._fieldResults_SelectionChanged);
         ' 
         ' _tableLayoutPanel2
         ' 
         Me._tableLayoutPanel2.ColumnCount = 1
         Me._tableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0F))
         Me._tableLayoutPanel2.Controls.Add(Me._filledFormViewer, 0, 1)
         Me._tableLayoutPanel2.Controls.Add(Me._filledFormViewerToolbar, 0, 0)
         Me._tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
         Me._tableLayoutPanel2.Location = New System.Drawing.Point(0, 0)
         Me._tableLayoutPanel2.Name = "_tableLayoutPanel2"
         Me._tableLayoutPanel2.RowCount = 2
         Me._tableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26.0F))
         Me._tableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0F))
         Me._tableLayoutPanel2.Size = New System.Drawing.Size(312, 443)
         Me._tableLayoutPanel2.TabIndex = 0
         ' 
         ' _filledFormViewer
         ' 
         Me._filledFormViewer.BackColor = System.Drawing.SystemColors.AppWorkspace
         Me._filledFormViewer.Cursor = System.Windows.Forms.Cursors.Hand
         Me._filledFormViewer.Dock = System.Windows.Forms.DockStyle.Fill
         Me._filledFormViewer.ScrollMode = ControlScrollMode.Auto
         Me._filledFormViewer.HorizontalScroll.Enabled = True
         Me._filledFormViewer.VerticalScroll.Enabled = True
         Me._filledFormViewer.Location = New System.Drawing.Point(3, 29)
         Me._filledFormViewer.Name = "_filledFormViewer"
         Me._filledFormViewer.Size = New System.Drawing.Size(306, 411)
         Me._filledFormViewer.TabIndex = 3
         Me._filledFormViewer.Text = "rasterImageViewer1"
         ' 
         ' _filledFormViewerToolbar
         ' 
         Me._filledFormViewerToolbar.BackColor = System.Drawing.SystemColors.MenuBar
         Me._filledFormViewerToolbar.Dock = System.Windows.Forms.DockStyle.Fill
         Me._filledFormViewerToolbar.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
         Me._filledFormViewerToolbar.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me._btnFormPan, Me._btnFormZoomRect, Me._btnFormZoomNormal, Me._btnFormZoomIn, Me._btnFormZoomOut, Me._btnFormFit, Me._btnFormFitWidth})
         Me._filledFormViewerToolbar.Location = New System.Drawing.Point(0, 0)
         Me._filledFormViewerToolbar.Name = "_filledFormViewerToolbar"
         Me._filledFormViewerToolbar.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
         Me._filledFormViewerToolbar.Size = New System.Drawing.Size(312, 26)
         Me._filledFormViewerToolbar.TabIndex = 2
         Me._filledFormViewerToolbar.Text = "toolStrip1"
         ' 
         ' _btnFormPan
         ' 
         Me._btnFormPan.Checked = True
         Me._btnFormPan.CheckOnClick = True
         Me._btnFormPan.CheckState = System.Windows.Forms.CheckState.Checked
         Me._btnFormPan.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
         Me._btnFormPan.Image = (CType(resources.GetObject("_btnFormPan.Image"), System.Drawing.Image))
         Me._btnFormPan.ImageTransparentColor = System.Drawing.Color.Magenta
         Me._btnFormPan.Name = "_btnFormPan"
         Me._btnFormPan.Size = New System.Drawing.Size(23, 23)
         Me._btnFormPan.Text = "Pan"
         '		  Me._btnFormPan.Click += New System.EventHandler(Me._btnFormPan_Click);
         ' 
         ' _btnFormZoomRect
         ' 
         Me._btnFormZoomRect.CheckOnClick = True
         Me._btnFormZoomRect.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
         Me._btnFormZoomRect.Image = (CType(resources.GetObject("_btnFormZoomRect.Image"), System.Drawing.Image))
         Me._btnFormZoomRect.ImageTransparentColor = System.Drawing.Color.Magenta
         Me._btnFormZoomRect.Name = "_btnFormZoomRect"
         Me._btnFormZoomRect.Size = New System.Drawing.Size(23, 23)
         Me._btnFormZoomRect.Text = "Zoom To Selection"
         '		  Me._btnFormZoomRect.Click += New System.EventHandler(Me._btnFormZoomRect_Click);
         ' 
         ' _btnFormZoomNormal
         ' 
         Me._btnFormZoomNormal.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
         Me._btnFormZoomNormal.Image = (CType(resources.GetObject("_btnFormZoomNormal.Image"), System.Drawing.Image))
         Me._btnFormZoomNormal.ImageTransparentColor = System.Drawing.Color.Magenta
         Me._btnFormZoomNormal.Name = "_btnFormZoomNormal"
         Me._btnFormZoomNormal.Size = New System.Drawing.Size(23, 23)
         Me._btnFormZoomNormal.Text = "Normal"
         '		  Me._btnFormZoomNormal.Click += New System.EventHandler(Me._btnFormZoomNormal_Click);
         ' 
         ' _btnFormZoomIn
         ' 
         Me._btnFormZoomIn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
         Me._btnFormZoomIn.Image = (CType(resources.GetObject("_btnFormZoomIn.Image"), System.Drawing.Image))
         Me._btnFormZoomIn.ImageTransparentColor = System.Drawing.Color.Magenta
         Me._btnFormZoomIn.Name = "_btnFormZoomIn"
         Me._btnFormZoomIn.Size = New System.Drawing.Size(23, 23)
         Me._btnFormZoomIn.Text = "Zoom In"
         '		  Me._btnFormZoomIn.Click += New System.EventHandler(Me._btnFormZoomIn_Click);
         ' 
         ' _btnFormZoomOut
         ' 
         Me._btnFormZoomOut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
         Me._btnFormZoomOut.Image = (CType(resources.GetObject("_btnFormZoomOut.Image"), System.Drawing.Image))
         Me._btnFormZoomOut.ImageTransparentColor = System.Drawing.Color.Magenta
         Me._btnFormZoomOut.Name = "_btnFormZoomOut"
         Me._btnFormZoomOut.Size = New System.Drawing.Size(23, 23)
         Me._btnFormZoomOut.Text = "Zoom Out"
         '		  Me._btnFormZoomOut.Click += New System.EventHandler(Me._btnFormZoomOut_Click);
         ' 
         ' _btnFormFit
         ' 
         Me._btnFormFit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
         Me._btnFormFit.Image = (CType(resources.GetObject("_btnFormFit.Image"), System.Drawing.Image))
         Me._btnFormFit.ImageTransparentColor = System.Drawing.Color.Magenta
         Me._btnFormFit.Name = "_btnFormFit"
         Me._btnFormFit.Size = New System.Drawing.Size(23, 23)
         Me._btnFormFit.Text = "Fit To Window"
         '		  Me._btnFormFit.Click += New System.EventHandler(Me._btnFormFit_Click);
         ' 
         ' _btnFormFitWidth
         ' 
         Me._btnFormFitWidth.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
         Me._btnFormFitWidth.Image = (CType(resources.GetObject("_btnFormFitWidth.Image"), System.Drawing.Image))
         Me._btnFormFitWidth.ImageTransparentColor = System.Drawing.Color.Magenta
         Me._btnFormFitWidth.Name = "_btnFormFitWidth"
         Me._btnFormFitWidth.Size = New System.Drawing.Size(23, 23)
         Me._btnFormFitWidth.Text = "Fit To Image Width"
         '		  Me._btnFormFitWidth.Click += New System.EventHandler(Me._btnFormFitWidth_Click);
         ' 
         ' _tablePanel2
         ' 
         Me._tablePanel2.ColumnCount = 1
         Me._tablePanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0F))
         Me._tablePanel2.Controls.Add(Me._toolBar, 0, 0)
         Me._tablePanel2.Dock = System.Windows.Forms.DockStyle.Fill
         Me._tablePanel2.Location = New System.Drawing.Point(0, 0)
         Me._tablePanel2.Name = "_tablePanel2"
         Me._tablePanel2.RowCount = 2
         Me._tablePanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0F))
         Me._tablePanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0F))
         Me._tablePanel2.Size = New System.Drawing.Size(200, 100)
         Me._tablePanel2.TabIndex = 0
         ' 
         ' _toolBar
         ' 
         Me._toolBar.BackColor = System.Drawing.SystemColors.MenuBar
         Me._toolBar.Dock = System.Windows.Forms.DockStyle.None
         Me._toolBar.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
         Me._toolBar.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me._btnPanTool, Me._btnZoomDrawTool, Me._btnZoomNormal, Me._btnZoomIn, Me._btnZoomOut, Me._btnFit})
         Me._toolBar.Location = New System.Drawing.Point(0, 0)
         Me._toolBar.Name = "_toolBar"
         Me._toolBar.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
         Me._toolBar.Size = New System.Drawing.Size(141, 20)
         Me._toolBar.TabIndex = 0
         Me._toolBar.Text = "toolStrip1"
         ' 
         ' _btnPanTool
         ' 
         Me._btnPanTool.Checked = True
         Me._btnPanTool.CheckOnClick = True
         Me._btnPanTool.CheckState = System.Windows.Forms.CheckState.Checked
         Me._btnPanTool.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
         Me._btnPanTool.Image = (CType(resources.GetObject("_btnPanTool.Image"), System.Drawing.Image))
         Me._btnPanTool.ImageTransparentColor = System.Drawing.Color.Magenta
         Me._btnPanTool.Name = "_btnPanTool"
         Me._btnPanTool.Size = New System.Drawing.Size(23, 17)
         Me._btnPanTool.Text = "Pan"
         ' 
         ' _btnZoomDrawTool
         ' 
         Me._btnZoomDrawTool.CheckOnClick = True
         Me._btnZoomDrawTool.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
         Me._btnZoomDrawTool.Image = (CType(resources.GetObject("_btnZoomDrawTool.Image"), System.Drawing.Image))
         Me._btnZoomDrawTool.ImageTransparentColor = System.Drawing.Color.Magenta
         Me._btnZoomDrawTool.Name = "_btnZoomDrawTool"
         Me._btnZoomDrawTool.Size = New System.Drawing.Size(23, 17)
         Me._btnZoomDrawTool.Text = "Zoom To Selection"
         ' 
         ' _btnZoomNormal
         ' 
         Me._btnZoomNormal.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
         Me._btnZoomNormal.Image = (CType(resources.GetObject("_btnZoomNormal.Image"), System.Drawing.Image))
         Me._btnZoomNormal.ImageTransparentColor = System.Drawing.Color.Magenta
         Me._btnZoomNormal.Name = "_btnZoomNormal"
         Me._btnZoomNormal.Size = New System.Drawing.Size(23, 17)
         Me._btnZoomNormal.Text = "Normal"
         ' 
         ' _btnZoomIn
         ' 
         Me._btnZoomIn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
         Me._btnZoomIn.Image = (CType(resources.GetObject("_btnZoomIn.Image"), System.Drawing.Image))
         Me._btnZoomIn.ImageTransparentColor = System.Drawing.Color.Magenta
         Me._btnZoomIn.Name = "_btnZoomIn"
         Me._btnZoomIn.Size = New System.Drawing.Size(23, 17)
         Me._btnZoomIn.Text = "Zoom In"
         ' 
         ' _btnZoomOut
         ' 
         Me._btnZoomOut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
         Me._btnZoomOut.Image = (CType(resources.GetObject("_btnZoomOut.Image"), System.Drawing.Image))
         Me._btnZoomOut.ImageTransparentColor = System.Drawing.Color.Magenta
         Me._btnZoomOut.Name = "_btnZoomOut"
         Me._btnZoomOut.Size = New System.Drawing.Size(23, 17)
         Me._btnZoomOut.Text = "Zoom Out"
         ' 
         ' _btnFit
         ' 
         Me._btnFit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
         Me._btnFit.Image = (CType(resources.GetObject("_btnFit.Image"), System.Drawing.Image))
         Me._btnFit.ImageTransparentColor = System.Drawing.Color.Magenta
         Me._btnFit.Name = "_btnFit"
         Me._btnFit.Size = New System.Drawing.Size(23, 17)
         Me._btnFit.Text = "Fit To Window"
         ' 
         ' _subSplitContainer
         ' 
         Me._subSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill
         Me._subSplitContainer.Location = New System.Drawing.Point(3, 28)
         Me._subSplitContainer.Name = "_subSplitContainer"
         Me._subSplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal
         ' 
         ' _subSplitContainer.Panel1
         ' 
         Me._subSplitContainer.Panel1.Controls.Add(Me._viewer)
         ' 
         ' _subSplitContainer.Panel2
         ' 
         Me._subSplitContainer.Panel2.Controls.Add(Me._txtFieldInfo)
         Me._subSplitContainer.Size = New System.Drawing.Size(315, 129)
         Me._subSplitContainer.SplitterDistance = 56
         Me._subSplitContainer.TabIndex = 1
         ' 
         ' _viewer
         ' 
         Me._viewer.ImageRegionRenderMode = ControlRegionRenderMode.Animated
         Me._viewer.BackColor = System.Drawing.SystemColors.AppWorkspace
         Me._viewer.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
         Me._viewer.Cursor = System.Windows.Forms.Cursors.Hand
         Me._viewer.ViewHorizontalAlignment = ControlAlignment.Near
         Me._viewer.Image = Nothing
         Me._viewer.Location = New System.Drawing.Point(0, 0)
         Me._viewer.Name = "_viewer"
         Me._viewer.Size = New System.Drawing.Size(427, 124)
         Me._viewer.Zoom(ControlSizeMode.ActualSize, 1, Me._viewer.DefaultZoomOrigin)
         Me._viewer.TabIndex = 0
         Me._viewer.Text = "rasterImageViewer1"
         Me._viewer.UseDpi = False
         Me._viewer.ViewVerticalAlignment = ControlAlignment.Near
         ' 
         ' _txtFieldInfo
         ' 
         Me._txtFieldInfo.BackColor = System.Drawing.Color.White
         Me._txtFieldInfo.Dock = System.Windows.Forms.DockStyle.Fill
         Me._txtFieldInfo.Location = New System.Drawing.Point(0, 0)
         Me._txtFieldInfo.Multiline = True
         Me._txtFieldInfo.Name = "_txtFieldInfo"
         Me._txtFieldInfo.ReadOnly = True
         Me._txtFieldInfo.ScrollBars = System.Windows.Forms.ScrollBars.Both
         Me._txtFieldInfo.Size = New System.Drawing.Size(315, 69)
         Me._txtFieldInfo.TabIndex = 2
         Me._txtFieldInfo.WordWrap = False
         ' 
         ' _fieldName
         ' 
         Me._fieldName.HeaderText = "Field"
         Me._fieldName.Name = "_fieldName"
         Me._fieldName.ReadOnly = True
         Me._fieldName.Resizable = System.Windows.Forms.DataGridViewTriState.True
         Me._fieldName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
         Me._fieldName.Width = 35
         ' 
         ' _fieldType
         ' 
         Me._fieldType.HeaderText = "Type"
         Me._fieldType.Name = "_fieldType"
         Me._fieldType.ReadOnly = True
         Me._fieldType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
         Me._fieldType.Width = 37
         ' 
         ' _fieldResult
         ' 
         dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True
         Me._fieldResult.DefaultCellStyle = dataGridViewCellStyle1
         Me._fieldResult.HeaderText = "Result"
         Me._fieldResult.Name = "_fieldResult"
         Me._fieldResult.ReadOnly = True
         Me._fieldResult.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
         Me._fieldResult.Width = 43
         ' 
         ' _confidence
         ' 
         Me._confidence.HeaderText = "Confidence"
         Me._confidence.Name = "_confidence"
         Me._confidence.ReadOnly = True
         Me._confidence.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
         Me._confidence.Width = 67
         ' 
         ' _boundingRect
         ' 
         Me._boundingRect.HeaderText = "Bounding Rectangle"
         Me._boundingRect.Name = "_boundingRect"
         Me._boundingRect.ReadOnly = True
         Me._boundingRect.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
         Me._boundingRect.Width = 99
         ' 
         ' RecognitionResult
         ' 
         Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
         Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
         Me.ClientSize = New System.Drawing.Size(641, 447)
         Me.Controls.Add(Me._splitContainer1)
         Me.Icon = (CType(resources.GetObject("$this.Icon"), System.Drawing.Icon))
         Me.Name = "RecognitionResult"
         Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
         Me.Text = "Results"
         '		  Me.Load += New System.EventHandler(Me.RecognitionResult_Load);
         Me._splitContainer1.Panel1.ResumeLayout(False)
         Me._splitContainer1.Panel2.ResumeLayout(False)
         Me._splitContainer1.ResumeLayout(False)
         Me._splitContainer2.Panel1.ResumeLayout(False)
         Me._splitContainer2.Panel1.PerformLayout()
         Me._splitContainer2.Panel2.ResumeLayout(False)
         Me._splitContainer2.ResumeLayout(False)
         Me._splitContainer3.Panel1.ResumeLayout(False)
         Me._splitContainer3.Panel2.ResumeLayout(False)
         Me._splitContainer3.ResumeLayout(False)
         Me._tableLayoutPanel1.ResumeLayout(False)
         Me._tableLayoutPanel1.PerformLayout()
         Me._fieldViewerToobar.ResumeLayout(False)
         Me._fieldViewerToobar.PerformLayout()
         CType(Me._fieldResults, System.ComponentModel.ISupportInitialize).EndInit()
         Me._tableLayoutPanel2.ResumeLayout(False)
         Me._tableLayoutPanel2.PerformLayout()
         Me._filledFormViewerToolbar.ResumeLayout(False)
         Me._filledFormViewerToolbar.PerformLayout()
         Me._tablePanel2.ResumeLayout(False)
         Me._tablePanel2.PerformLayout()
         Me._toolBar.ResumeLayout(False)
         Me._toolBar.PerformLayout()
         Me._subSplitContainer.Panel1.ResumeLayout(False)
         Me._subSplitContainer.Panel2.ResumeLayout(False)
         Me._subSplitContainer.Panel2.PerformLayout()
         Me._subSplitContainer.ResumeLayout(False)
         Me.ResumeLayout(False)

      End Sub

#End Region

      Private _splitContainer1 As System.Windows.Forms.SplitContainer
      Private _splitContainer2 As System.Windows.Forms.SplitContainer
      Private _splitContainer3 As System.Windows.Forms.SplitContainer
      Private _tablePanel2 As System.Windows.Forms.TableLayoutPanel
      Private _toolBar As System.Windows.Forms.ToolStrip
      Private _btnPanTool As System.Windows.Forms.ToolStripButton
      Private _btnZoomDrawTool As System.Windows.Forms.ToolStripButton
      Private _btnZoomNormal As System.Windows.Forms.ToolStripButton
      Private _btnZoomIn As System.Windows.Forms.ToolStripButton
      Private _btnZoomOut As System.Windows.Forms.ToolStripButton
      Private _btnFit As System.Windows.Forms.ToolStripButton
      Private _subSplitContainer As System.Windows.Forms.SplitContainer
      Private _viewer As ImageViewer
      Private _txtFieldInfo As System.Windows.Forms.TextBox
      Private _tableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
      Private _fieldViewerToobar As System.Windows.Forms.ToolStrip
      Private WithEvents _btnFieldPan As System.Windows.Forms.ToolStripButton
      Private WithEvents _btnFieldZoomRect As System.Windows.Forms.ToolStripButton
      Private WithEvents _btnFieldZoomNormal As System.Windows.Forms.ToolStripButton
      Private WithEvents _btnFieldZoomIn As System.Windows.Forms.ToolStripButton
      Private WithEvents _btnFieldZoomOut As System.Windows.Forms.ToolStripButton
      Private WithEvents _btnFieldFit As System.Windows.Forms.ToolStripButton
      Private _fieldViewer As ImageViewer
      Private _tableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
      Private _filledFormViewer As AutomationImageViewer
      Private _filledFormViewerToolbar As System.Windows.Forms.ToolStrip
      Private WithEvents _btnFormPan As System.Windows.Forms.ToolStripButton
      Private WithEvents _btnFormZoomRect As System.Windows.Forms.ToolStripButton
      Private WithEvents _btnFormZoomNormal As System.Windows.Forms.ToolStripButton
      Private WithEvents _btnFormZoomIn As System.Windows.Forms.ToolStripButton
      Private WithEvents _btnFormZoomOut As System.Windows.Forms.ToolStripButton
      Private WithEvents _btnFormFit As System.Windows.Forms.ToolStripButton
      Private WithEvents _fieldResults As System.Windows.Forms.DataGridView
      Private label2 As System.Windows.Forms.Label
      Private label1 As System.Windows.Forms.Label
      Private label3 As System.Windows.Forms.Label
      Private WithEvents _cmbSelectedPage As System.Windows.Forms.ComboBox
      Private WithEvents _cmbSelectedForm As System.Windows.Forms.ComboBox
      Private _txtMasterForm As System.Windows.Forms.TextBox
      Private WithEvents _btnFormFitWidth As System.Windows.Forms.ToolStripButton
      Private WithEvents _btnFieldFitWidth As System.Windows.Forms.ToolStripButton
      Private _txtFormConficence As System.Windows.Forms.TextBox
      Private label4 As System.Windows.Forms.Label
      Private _txtPageConfidence As System.Windows.Forms.TextBox
      Private label5 As System.Windows.Forms.Label
      Private _fieldName As System.Windows.Forms.DataGridViewTextBoxColumn
      Private _fieldType As System.Windows.Forms.DataGridViewTextBoxColumn
      Private _fieldResult As System.Windows.Forms.DataGridViewTextBoxColumn
      Private _confidence As System.Windows.Forms.DataGridViewTextBoxColumn
      Private _boundingRect As System.Windows.Forms.DataGridViewTextBoxColumn

   End Class
End Namespace
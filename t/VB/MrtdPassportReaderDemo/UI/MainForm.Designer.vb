Imports Leadtools.Controls

Namespace MrtdPassportReaderDemo
   Partial Class MainForm
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
         Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainForm))
         Me._splMain = New System.Windows.Forms.SplitContainer()
         Me.splitContainer1 = New System.Windows.Forms.SplitContainer()
         Me.dGV_Results = New System.Windows.Forms.DataGridView()
         Me.dGV_Errors = New System.Windows.Forms.DataGridView()
         Me.dataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
         Me._splViewerList = New System.Windows.Forms.SplitContainer()
         Me.rasterImageViewer1 = New ImageViewer()
         Me._tsViewer = New System.Windows.Forms.ToolStrip()
         Me._btnPanTool = New System.Windows.Forms.ToolStripButton()
         Me.toolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator()
         Me._btnZoomNormal = New System.Windows.Forms.ToolStripButton()
         Me._btnFit = New System.Windows.Forms.ToolStripButton()
         Me._btnFitWidth = New System.Windows.Forms.ToolStripButton()
         Me._btnRetry = New System.Windows.Forms.ToolStripButton()
         Me._btnRotateLeft = New System.Windows.Forms.ToolStripButton()
         Me._btnRotateRight = New System.Windows.Forms.ToolStripButton()
         Me._btnZoomIn = New System.Windows.Forms.ToolStripButton()
         Me._btnZoomOut = New System.Windows.Forms.ToolStripButton()
         Me._btnZoomDrawTool = New System.Windows.Forms.ToolStripButton()
         Me._btnUseDpi = New System.Windows.Forms.ToolStripButton()
         Me.toolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
         Me.panel1 = New System.Windows.Forms.Panel()
         Me._tB_readonlyMRZCode = New System.Windows.Forms.TextBox()
         Me._tB_MRZCode = New System.Windows.Forms.TextBox()
         Me._btn_Edit = New System.Windows.Forms.Button()
         Me.label1 = New System.Windows.Forms.Label()
         Me.menuStrip1 = New System.Windows.Forms.MenuStrip()
         Me.fileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me.openToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me.scanImageToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me.closeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me.exitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me.optionsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me.enableImprovingResultsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me.helpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me.aboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me.informationToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemHowTo = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemAbout = New System.Windows.Forms.ToolStripMenuItem()
         Me._dataElement = New System.Windows.Forms.DataGridViewTextBoxColumn()
         Me._value = New System.Windows.Forms.DataGridViewTextBoxColumn()
         Me._code = New System.Windows.Forms.DataGridViewTextBoxColumn()
         '((System.ComponentModel.ISupportInitialize)(this._splMain)).BeginInit();
         Me._splMain.Panel1.SuspendLayout()
         Me._splMain.Panel2.SuspendLayout()
         Me._splMain.SuspendLayout()
         '((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
         Me.splitContainer1.Panel1.SuspendLayout()
         Me.splitContainer1.Panel2.SuspendLayout()
         Me.splitContainer1.SuspendLayout()
         CType(Me.dGV_Results, System.ComponentModel.ISupportInitialize).BeginInit()
         CType(Me.dGV_Errors, System.ComponentModel.ISupportInitialize).BeginInit()
         '((System.ComponentModel.ISupportInitialize)(this._splViewerList)).BeginInit();
         Me._splViewerList.Panel1.SuspendLayout()
         Me._splViewerList.Panel2.SuspendLayout()
         Me._splViewerList.SuspendLayout()
         Me._tsViewer.SuspendLayout()
         Me.panel1.SuspendLayout()
         Me.menuStrip1.SuspendLayout()
         Me.SuspendLayout()
         ' 
         ' _splMain
         ' 
         Me._splMain.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
         Me._splMain.Dock = System.Windows.Forms.DockStyle.Fill
         Me._splMain.Location = New System.Drawing.Point(0, 24)
         Me._splMain.Name = "_splMain"
         ' 
         ' _splMain.Panel1
         ' 
         Me._splMain.Panel1.Controls.Add(Me.splitContainer1)
         Me._splMain.Panel1MinSize = 484
         ' 
         ' _splMain.Panel2
         ' 
         Me._splMain.Panel2.Controls.Add(Me._splViewerList)
         Me._splMain.Size = New System.Drawing.Size(1197, 721)
         Me._splMain.SplitterDistance = 644
         Me._splMain.TabIndex = 3
         ' 
         ' splitContainer1
         ' 
         Me.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
         Me.splitContainer1.Location = New System.Drawing.Point(0, 0)
         Me.splitContainer1.Name = "splitContainer1"
         Me.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
         ' 
         ' splitContainer1.Panel1
         ' 
         Me.splitContainer1.Panel1.Controls.Add(Me.dGV_Results)
         ' 
         ' splitContainer1.Panel2
         ' 
         Me.splitContainer1.Panel2.Controls.Add(Me.dGV_Errors)
         Me.splitContainer1.Size = New System.Drawing.Size(640, 717)
         Me.splitContainer1.SplitterDistance = 358
         Me.splitContainer1.TabIndex = 1
         ' 
         ' dGV_Results
         ' 
         Me.dGV_Results.AllowUserToAddRows = False
         Me.dGV_Results.AllowUserToDeleteRows = False
         Me.dGV_Results.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
         Me.dGV_Results.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me._dataElement, Me._value, Me._code})
         Me.dGV_Results.Dock = System.Windows.Forms.DockStyle.Fill
         Me.dGV_Results.Location = New System.Drawing.Point(0, 0)
         Me.dGV_Results.MultiSelect = False
         Me.dGV_Results.Name = "dGV_Results"
         Me.dGV_Results.ReadOnly = True
         Me.dGV_Results.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
         Me.dGV_Results.Size = New System.Drawing.Size(640, 358)
         Me.dGV_Results.TabIndex = 0
         ' 
         ' dGV_Errors
         ' 
         Me.dGV_Errors.AllowUserToAddRows = False
         Me.dGV_Errors.AllowUserToDeleteRows = False
         Me.dGV_Errors.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
         Me.dGV_Errors.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dataGridViewTextBoxColumn1})
         Me.dGV_Errors.Dock = System.Windows.Forms.DockStyle.Fill
         Me.dGV_Errors.Location = New System.Drawing.Point(0, 0)
         Me.dGV_Errors.Name = "dGV_Errors"
         Me.dGV_Errors.ReadOnly = True
         Me.dGV_Errors.Size = New System.Drawing.Size(640, 355)
         Me.dGV_Errors.TabIndex = 1
         ' 
         ' dataGridViewTextBoxColumn1
         ' 
         Me.dataGridViewTextBoxColumn1.Frozen = True
         Me.dataGridViewTextBoxColumn1.HeaderText = "Errors"
         Me.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1"
         Me.dataGridViewTextBoxColumn1.ReadOnly = True
         Me.dataGridViewTextBoxColumn1.Width = 400
         ' 
         ' _splViewerList
         ' 
         Me._splViewerList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
         Me._splViewerList.Dock = System.Windows.Forms.DockStyle.Fill
         Me._splViewerList.Location = New System.Drawing.Point(0, 0)
         Me._splViewerList.Name = "_splViewerList"
         Me._splViewerList.Orientation = System.Windows.Forms.Orientation.Horizontal
         ' 
         ' _splViewerList.Panel1
         ' 
         Me._splViewerList.Panel1.Controls.Add(Me.rasterImageViewer1)
         Me._splViewerList.Panel1.Controls.Add(Me._tsViewer)
         ' 
         ' _splViewerList.Panel2
         ' 
         Me._splViewerList.Panel2.Controls.Add(Me.panel1)
         Me._splViewerList.Panel2.Controls.Add(Me._btn_Edit)
         Me._splViewerList.Panel2.Controls.Add(Me.label1)
         Me._splViewerList.Size = New System.Drawing.Size(549, 721)
         Me._splViewerList.SplitterDistance = 464
         Me._splViewerList.TabIndex = 0
         ' 
         ' rasterImageViewer1
         ' 
         Me.rasterImageViewer1.Dock = System.Windows.Forms.DockStyle.Fill
         Me.rasterImageViewer1.ImageBackgroundColor = System.Drawing.Color.FromArgb((CInt((CByte(0)))), (CInt((CByte(255)))), (CInt((CByte(255)))), (CInt((CByte(255)))))
         Me.rasterImageViewer1.ImageHorizontalAlignment = ControlAlignment.Near
         Me.rasterImageViewer1.ImageVerticalAlignment = ControlAlignment.Near
         Me.rasterImageViewer1.ImeMode = System.Windows.Forms.ImeMode.NoControl
         Me.rasterImageViewer1.ItemSizeMode = ControlSizeMode.Fit
         Me.rasterImageViewer1.Location = New System.Drawing.Point(0, 53)
         Me.rasterImageViewer1.Name = "rasterImageViewer1"
         Me.rasterImageViewer1.Size = New System.Drawing.Size(545, 407)
         Me.rasterImageViewer1.TabIndex = 5
         Me.rasterImageViewer1.UseDpi = True
         ' 
         ' _tsViewer
         ' 
         Me._tsViewer.ImageScalingSize = New System.Drawing.Size(20, 20)
         Me._tsViewer.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me._btnPanTool, Me.toolStripSeparator7, Me._btnZoomNormal, Me._btnFit, Me._btnFitWidth, Me._btnRetry, Me._btnRotateLeft, Me._btnRotateRight, Me._btnZoomIn, Me._btnZoomOut, Me._btnZoomDrawTool, Me._btnUseDpi, Me.toolStripSeparator2})
         Me._tsViewer.Location = New System.Drawing.Point(0, 0)
         Me._tsViewer.Name = "_tsViewer"
         Me._tsViewer.RightToLeft = System.Windows.Forms.RightToLeft.No
         Me._tsViewer.Size = New System.Drawing.Size(545, 53)
         Me._tsViewer.TabIndex = 4
         Me._tsViewer.Text = "toolStrip2"
         ' 
         ' _btnPanTool
         ' 
         Me._btnPanTool.AutoSize = False
         Me._btnPanTool.CheckOnClick = True
         Me._btnPanTool.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
         Me._btnPanTool.Image = (CType(resources.GetObject("_btnPanTool.Image"), System.Drawing.Image))
         Me._btnPanTool.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
         Me._btnPanTool.ImageTransparentColor = System.Drawing.Color.Magenta
         Me._btnPanTool.Name = "_btnPanTool"
         Me._btnPanTool.Size = New System.Drawing.Size(50, 50)
         Me._btnPanTool.Text = "Pan"
         ' 
         ' toolStripSeparator7
         ' 
         Me.toolStripSeparator7.Name = "toolStripSeparator7"
         Me.toolStripSeparator7.Size = New System.Drawing.Size(6, 53)
         ' 
         ' _btnZoomNormal
         ' 
         Me._btnZoomNormal.AutoSize = False
         Me._btnZoomNormal.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
         Me._btnZoomNormal.Image = (CType(resources.GetObject("_btnZoomNormal.Image"), System.Drawing.Image))
         Me._btnZoomNormal.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
         Me._btnZoomNormal.ImageTransparentColor = System.Drawing.Color.Magenta
         Me._btnZoomNormal.Name = "_btnZoomNormal"
         Me._btnZoomNormal.Size = New System.Drawing.Size(50, 50)
         Me._btnZoomNormal.Text = "Normal"
         ' 
         ' _btnFit
         ' 
         Me._btnFit.AutoSize = False
         Me._btnFit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
         Me._btnFit.Image = (CType(resources.GetObject("_btnFit.Image"), System.Drawing.Image))
         Me._btnFit.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
         Me._btnFit.ImageTransparentColor = System.Drawing.Color.Magenta
         Me._btnFit.Name = "_btnFit"
         Me._btnFit.Size = New System.Drawing.Size(50, 50)
         Me._btnFit.Text = "Fit To Window"
         ' 
         ' _btnFitWidth
         ' 
         Me._btnFitWidth.AutoSize = False
         Me._btnFitWidth.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
         Me._btnFitWidth.Image = (CType(resources.GetObject("_btnFitWidth.Image"), System.Drawing.Image))
         Me._btnFitWidth.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
         Me._btnFitWidth.ImageTransparentColor = System.Drawing.Color.Magenta
         Me._btnFitWidth.Name = "_btnFitWidth"
         Me._btnFitWidth.Size = New System.Drawing.Size(50, 50)
         Me._btnFitWidth.Text = "Fit To Image Width"
         ' 
         ' _btnRetry
         ' 
         Me._btnRetry.AutoSize = False
         Me._btnRetry.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
         Me._btnRetry.Image = (CType(resources.GetObject("_btnRetry.Image"), System.Drawing.Image))
         Me._btnRetry.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
         Me._btnRetry.ImageTransparentColor = System.Drawing.Color.Magenta
         Me._btnRetry.Name = "_btnRetry"
         Me._btnRetry.Size = New System.Drawing.Size(50, 50)
         Me._btnRetry.Text = "Retry"
         ' 
         ' _btnRotateLeft
         ' 
         Me._btnRotateLeft.AutoSize = False
         Me._btnRotateLeft.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
         Me._btnRotateLeft.Image = (CType(resources.GetObject("_btnRotateLeft.Image"), System.Drawing.Image))
         Me._btnRotateLeft.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
         Me._btnRotateLeft.ImageTransparentColor = System.Drawing.Color.Magenta
         Me._btnRotateLeft.Name = "_btnRotateLeft"
         Me._btnRotateLeft.Size = New System.Drawing.Size(50, 50)
         Me._btnRotateLeft.Text = "Rotate Left"
         ' 
         ' _btnRotateRight
         ' 
         Me._btnRotateRight.AutoSize = False
         Me._btnRotateRight.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
         Me._btnRotateRight.Image = (CType(resources.GetObject("_btnRotateRight.Image"), System.Drawing.Image))
         Me._btnRotateRight.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
         Me._btnRotateRight.ImageTransparentColor = System.Drawing.Color.Magenta
         Me._btnRotateRight.Name = "_btnRotateRight"
         Me._btnRotateRight.Size = New System.Drawing.Size(50, 50)
         Me._btnRotateRight.Text = "Rotate Right"
         ' 
         ' _btnZoomIn
         ' 
         Me._btnZoomIn.AutoSize = False
         Me._btnZoomIn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
         Me._btnZoomIn.Image = (CType(resources.GetObject("_btnZoomIn.Image"), System.Drawing.Image))
         Me._btnZoomIn.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
         Me._btnZoomIn.ImageTransparentColor = System.Drawing.Color.Magenta
         Me._btnZoomIn.Name = "_btnZoomIn"
         Me._btnZoomIn.Size = New System.Drawing.Size(50, 50)
         Me._btnZoomIn.Text = "Zoom In"
         ' 
         ' _btnZoomOut
         ' 
         Me._btnZoomOut.AutoSize = False
         Me._btnZoomOut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
         Me._btnZoomOut.Image = (CType(resources.GetObject("_btnZoomOut.Image"), System.Drawing.Image))
         Me._btnZoomOut.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
         Me._btnZoomOut.ImageTransparentColor = System.Drawing.Color.Magenta
         Me._btnZoomOut.Name = "_btnZoomOut"
         Me._btnZoomOut.Size = New System.Drawing.Size(50, 50)
         Me._btnZoomOut.Text = "Zoom Out"
         ' 
         ' _btnZoomDrawTool
         ' 
         Me._btnZoomDrawTool.AutoSize = False
         Me._btnZoomDrawTool.CheckOnClick = True
         Me._btnZoomDrawTool.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
         Me._btnZoomDrawTool.Image = (CType(resources.GetObject("_btnZoomDrawTool.Image"), System.Drawing.Image))
         Me._btnZoomDrawTool.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
         Me._btnZoomDrawTool.ImageTransparentColor = System.Drawing.Color.Magenta
         Me._btnZoomDrawTool.Name = "_btnZoomDrawTool"
         Me._btnZoomDrawTool.Size = New System.Drawing.Size(50, 50)
         Me._btnZoomDrawTool.Text = "Zoom To Selection"
         ' 
         ' _btnUseDpi
         ' 
         Me._btnUseDpi.AutoSize = False
         Me._btnUseDpi.Checked = True
         Me._btnUseDpi.CheckOnClick = True
         Me._btnUseDpi.CheckState = System.Windows.Forms.CheckState.Checked
         Me._btnUseDpi.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
         Me._btnUseDpi.Image = (CType(resources.GetObject("_btnUseDpi.Image"), System.Drawing.Image))
         Me._btnUseDpi.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
         Me._btnUseDpi.ImageTransparentColor = System.Drawing.Color.Black
         Me._btnUseDpi.Margin = New System.Windows.Forms.Padding(0)
         Me._btnUseDpi.Name = "_btnUseDpi"
         Me._btnUseDpi.Size = New System.Drawing.Size(50, 50)
         Me._btnUseDpi.Text = "toolStripButton1"
         Me._btnUseDpi.ToolTipText = "Ignore Image DPI When Viewing"
         ' 
         ' toolStripSeparator2
         ' 
         Me.toolStripSeparator2.Name = "toolStripSeparator2"
         Me.toolStripSeparator2.Size = New System.Drawing.Size(6, 53)
         ' 
         ' panel1
         ' 
         Me.panel1.Anchor = (CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
         Me.panel1.Controls.Add(Me._tB_readonlyMRZCode)
         Me.panel1.Controls.Add(Me._tB_MRZCode)
         Me.panel1.Location = New System.Drawing.Point(4, 84)
         Me.panel1.Name = "panel1"
         Me.panel1.Size = New System.Drawing.Size(543, 167)
         Me.panel1.TabIndex = 4
         ' 
         ' _tB_readonlyMRZCode
         ' 
         Me._tB_readonlyMRZCode.Anchor = (CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
         Me._tB_readonlyMRZCode.BackColor = System.Drawing.SystemColors.InactiveCaption
         Me._tB_readonlyMRZCode.Font = New System.Drawing.Font("Courier New", 12.0F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (CByte(0)))
         Me._tB_readonlyMRZCode.ForeColor = System.Drawing.Color.DarkRed
         Me._tB_readonlyMRZCode.Location = New System.Drawing.Point(372, 73)
         Me._tB_readonlyMRZCode.Multiline = True
         Me._tB_readonlyMRZCode.Name = "_tB_readonlyMRZCode"
         Me._tB_readonlyMRZCode.ReadOnly = True
         Me._tB_readonlyMRZCode.Size = New System.Drawing.Size(0, 10)
         Me._tB_readonlyMRZCode.TabIndex = 2
         Me._tB_readonlyMRZCode.Visible = False
         ' 
         ' _tB_MRZCode
         ' 
         Me._tB_MRZCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
         Me._tB_MRZCode.Dock = System.Windows.Forms.DockStyle.Fill
         Me._tB_MRZCode.Font = New System.Drawing.Font("Consolas", 12.0F)
         Me._tB_MRZCode.Location = New System.Drawing.Point(0, 0)
         Me._tB_MRZCode.Multiline = True
         Me._tB_MRZCode.Name = "_tB_MRZCode"
         Me._tB_MRZCode.Size = New System.Drawing.Size(543, 167)
         Me._tB_MRZCode.TabIndex = 1
         Me._tB_MRZCode.Visible = False
         ' 
         ' _btn_Edit
         ' 
         Me._btn_Edit.Anchor = (CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
         Me._btn_Edit.Location = New System.Drawing.Point(419, 21)
         Me._btn_Edit.Name = "_btn_Edit"
         Me._btn_Edit.Size = New System.Drawing.Size(116, 39)
         Me._btn_Edit.TabIndex = 2
         Me._btn_Edit.Text = "Edit"
         Me._btn_Edit.UseVisualStyleBackColor = True
         ' 
         ' label1
         ' 
         Me.label1.AutoSize = True
         Me.label1.Font = New System.Drawing.Font("Tahoma", 26.0F)
         Me.label1.Location = New System.Drawing.Point(100, 21)
         Me.label1.Name = "label1"
         Me.label1.Size = New System.Drawing.Size(263, 42)
         Me.label1.TabIndex = 0
         Me.label1.Text = "MRZ Characters"
         ' 
         ' menuStrip1
         ' 
         Me.menuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.fileToolStripMenuItem, Me.optionsToolStripMenuItem, Me.helpToolStripMenuItem})
         Me.menuStrip1.Location = New System.Drawing.Point(0, 0)
         Me.menuStrip1.Name = "menuStrip1"
         Me.menuStrip1.Size = New System.Drawing.Size(1197, 24)
         Me.menuStrip1.TabIndex = 4
         Me.menuStrip1.Text = "menuStrip1"
         ' 
         ' fileToolStripMenuItem
         ' 
         Me.fileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.openToolStripMenuItem, Me.scanImageToolStripMenuItem, Me.closeToolStripMenuItem, Me.exitToolStripMenuItem})
         Me.fileToolStripMenuItem.Name = "fileToolStripMenuItem"
         Me.fileToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
         Me.fileToolStripMenuItem.Text = "File"
         ' 
         ' openToolStripMenuItem
         ' 
         Me.openToolStripMenuItem.Name = "openToolStripMenuItem"
         Me.openToolStripMenuItem.Size = New System.Drawing.Size(128, 22)
         Me.openToolStripMenuItem.Text = "Open"
         ' 
         ' scanImageToolStripMenuItem
         ' 
         Me.scanImageToolStripMenuItem.Name = "scanImageToolStripMenuItem"
         Me.scanImageToolStripMenuItem.Size = New System.Drawing.Size(128, 22)
         Me.scanImageToolStripMenuItem.Text = "Scan Page"
         ' 
         ' closeToolStripMenuItem
         ' 
         Me.closeToolStripMenuItem.Name = "closeToolStripMenuItem"
         Me.closeToolStripMenuItem.Size = New System.Drawing.Size(128, 22)
         Me.closeToolStripMenuItem.Text = "Close"
         ' 
         ' exitToolStripMenuItem
         ' 
         Me.exitToolStripMenuItem.Name = "exitToolStripMenuItem"
         Me.exitToolStripMenuItem.Size = New System.Drawing.Size(128, 22)
         Me.exitToolStripMenuItem.Text = "Exit"
         ' 
         ' optionsToolStripMenuItem
         ' 
         Me.optionsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.enableImprovingResultsToolStripMenuItem})
         Me.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem"
         Me.optionsToolStripMenuItem.Size = New System.Drawing.Size(61, 20)
         Me.optionsToolStripMenuItem.Text = "Options"
         ' 
         ' enableImprovingResultsToolStripMenuItem
         ' 
         Me.enableImprovingResultsToolStripMenuItem.Name = "enableImprovingResultsToolStripMenuItem"
         Me.enableImprovingResultsToolStripMenuItem.Size = New System.Drawing.Size(207, 22)
         Me.enableImprovingResultsToolStripMenuItem.Text = "Enable Improving Results"
         ' 
         ' helpToolStripMenuItem
         ' 
         Me.helpToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.aboutToolStripMenuItem, Me.informationToolStripMenuItem})
         Me.helpToolStripMenuItem.Name = "helpToolStripMenuItem"
         Me.helpToolStripMenuItem.Size = New System.Drawing.Size(44, 20)
         Me.helpToolStripMenuItem.Text = "Help"
         ' 
         ' aboutToolStripMenuItem
         ' 
         Me.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem"
         Me.aboutToolStripMenuItem.Size = New System.Drawing.Size(138, 22)
         Me.aboutToolStripMenuItem.Text = "About"
         ' 
         ' informationToolStripMenuItem
         ' 
         Me.informationToolStripMenuItem.Name = "informationToolStripMenuItem"
         Me.informationToolStripMenuItem.Size = New System.Drawing.Size(138, 22)
         Me.informationToolStripMenuItem.Text = "How To Use"
         ' 
         ' _menuItemHowTo
         ' 
         Me._menuItemHowTo.Name = "_menuItemHowTo"
         Me._menuItemHowTo.Size = New System.Drawing.Size(32, 19)
         ' 
         ' _menuItemAbout
         ' 
         Me._menuItemAbout.Name = "_menuItemAbout"
         Me._menuItemAbout.Size = New System.Drawing.Size(32, 19)
         ' 
         ' _dataElement
         ' 
         Me._dataElement.FillWeight = 70.0F
         Me._dataElement.Frozen = True
         Me._dataElement.HeaderText = "Data Element"
         Me._dataElement.Name = "_dataElement"
         Me._dataElement.ReadOnly = True
         Me._dataElement.Width = 200
         ' 
         ' _value
         ' 
         Me._value.FillWeight = 70.0F
         Me._value.Frozen = True
         Me._value.HeaderText = "Value"
         Me._value.Name = "_value"
         Me._value.ReadOnly = True
         Me._value.Width = 200
         ' 
         ' _code
         ' 
         Me._code.FillWeight = 70.0F
         Me._code.HeaderText = "Code"
         Me._code.Name = "_code"
         Me._code.ReadOnly = True
         Me._code.Width = 300
         ' 
         ' MainForm
         ' 
         Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
         Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
         Me.ClientSize = New System.Drawing.Size(1197, 745)
         Me.Controls.Add(Me._splMain)
         Me.Controls.Add(Me.menuStrip1)
         Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
         Me.Icon = (CType(resources.GetObject("$this.Icon"), System.Drawing.Icon))
         Me.MainMenuStrip = Me.menuStrip1
         Me.Name = "MainForm"
         Me.Text = "LEADTOOLS MRTD Reader Demo"
         Me._splMain.Panel1.ResumeLayout(False)
         Me._splMain.Panel2.ResumeLayout(False)
         '((System.ComponentModel.ISupportInitialize)(this._splMain)).EndInit();
         Me._splMain.ResumeLayout(False)
         Me.splitContainer1.Panel1.ResumeLayout(False)
         Me.splitContainer1.Panel2.ResumeLayout(False)
         '((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
         Me.splitContainer1.ResumeLayout(False)
         CType(Me.dGV_Results, System.ComponentModel.ISupportInitialize).EndInit()
         CType(Me.dGV_Errors, System.ComponentModel.ISupportInitialize).EndInit()
         Me._splViewerList.Panel1.ResumeLayout(False)
         Me._splViewerList.Panel1.PerformLayout()
         Me._splViewerList.Panel2.ResumeLayout(False)
         Me._splViewerList.Panel2.PerformLayout()
         '((System.ComponentModel.ISupportInitialize)(this._splViewerList)).EndInit();
         Me._splViewerList.ResumeLayout(False)
         Me._tsViewer.ResumeLayout(False)
         Me._tsViewer.PerformLayout()
         Me.panel1.ResumeLayout(False)
         Me.panel1.PerformLayout()
         Me.menuStrip1.ResumeLayout(False)
         Me.menuStrip1.PerformLayout()
         Me.ResumeLayout(False)
         Me.PerformLayout()

      End Sub

#End Region

      Private _splMain As System.Windows.Forms.SplitContainer
      Private _splViewerList As System.Windows.Forms.SplitContainer
      Private menuStrip1 As System.Windows.Forms.MenuStrip
      Private _menuItemHowTo As System.Windows.Forms.ToolStripMenuItem
      Private _menuItemAbout As System.Windows.Forms.ToolStripMenuItem
      Private fileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents openToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents dGV_Results As System.Windows.Forms.DataGridView
      Private _tsViewer As System.Windows.Forms.ToolStrip
      Private WithEvents _btnZoomNormal As System.Windows.Forms.ToolStripButton
      Private WithEvents _btnFit As System.Windows.Forms.ToolStripButton
      Private WithEvents _btnFitWidth As System.Windows.Forms.ToolStripButton
      Private WithEvents _btnZoomIn As System.Windows.Forms.ToolStripButton
      Private WithEvents _btnZoomOut As System.Windows.Forms.ToolStripButton
      Private WithEvents _btnZoomDrawTool As System.Windows.Forms.ToolStripButton
      Private WithEvents _btnUseDpi As System.Windows.Forms.ToolStripButton
      Private toolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
      Private WithEvents _btnPanTool As System.Windows.Forms.ToolStripButton
      Private toolStripSeparator7 As System.Windows.Forms.ToolStripSeparator
      Private rasterImageViewer1 As ImageViewer
      Private WithEvents closeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents exitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private helpToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents aboutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _btn_Edit As System.Windows.Forms.Button
      Private _tB_MRZCode As System.Windows.Forms.TextBox
      Private label1 As System.Windows.Forms.Label
      Private panel1 As System.Windows.Forms.Panel
      Private WithEvents _tB_readonlyMRZCode As System.Windows.Forms.TextBox
      Private WithEvents informationToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private splitContainer1 As System.Windows.Forms.SplitContainer
      Private dGV_Errors As System.Windows.Forms.DataGridView
      Private dataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
      Private optionsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents enableImprovingResultsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents scanImageToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _btnRetry As System.Windows.Forms.ToolStripButton
      Private WithEvents _btnRotateRight As System.Windows.Forms.ToolStripButton
      Private WithEvents _btnRotateLeft As System.Windows.Forms.ToolStripButton
      Private _dataElement As System.Windows.Forms.DataGridViewTextBoxColumn
      Private _value As System.Windows.Forms.DataGridViewTextBoxColumn
      Private _code As System.Windows.Forms.DataGridViewTextBoxColumn
   End Class
End Namespace


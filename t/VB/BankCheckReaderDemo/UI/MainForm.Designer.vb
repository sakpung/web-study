Imports Leadtools.Controls

Partial Class MainForm
   ''' <summary>
   ''' Required designer variable.
   ''' </summary>
   Private components As System.ComponentModel.IContainer = Nothing

   ''' <summary>
   ''' Clean up any resources being used.
   ''' </summary>
   ''' <param name="disposing">true if managed resources should be disposed otherwise, false.</param>
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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainForm))
      Me._splMain = New System.Windows.Forms.SplitContainer()
      Me.dataGridView1 = New System.Windows.Forms.DataGridView()
      Me._splViewerList = New System.Windows.Forms.SplitContainer()
      Me.rasterImageViewer1 = New ImageViewer()
      Me._tsViewer = New System.Windows.Forms.ToolStrip()
      Me._btnPanTool = New System.Windows.Forms.ToolStripButton()
      Me.toolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator()
      Me._btnZoomNormal = New System.Windows.Forms.ToolStripButton()
      Me._btnFit = New System.Windows.Forms.ToolStripButton()
      Me._btnFitWidth = New System.Windows.Forms.ToolStripButton()
      Me._btnZoomIn = New System.Windows.Forms.ToolStripButton()
      Me._btnZoomOut = New System.Windows.Forms.ToolStripButton()
      Me._btnZoomDrawTool = New System.Windows.Forms.ToolStripButton()
      Me._btnUseDpi = New System.Windows.Forms.ToolStripButton()
      Me.toolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
      Me.imageViewerField = New ImageViewer()
      Me.menuStrip1 = New System.Windows.Forms.MenuStrip()
      Me.fileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
      Me.openToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
      Me.closeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
      Me.exitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
      Me._menuItemEngine = New System.Windows.Forms.ToolStripMenuItem()
      Me._menuItemLanguages = New System.Windows.Forms.ToolStripMenuItem()
      Me._menuItemComponents = New System.Windows.Forms.ToolStripMenuItem()
      Me.micrFontToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
      Me._miFontUnknown = New System.Windows.Forms.ToolStripMenuItem()
      Me._miFontE13B = New System.Windows.Forms.ToolStripMenuItem()
      Me._miFontCMC7 = New System.Windows.Forms.ToolStripMenuItem()
      Me.helpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
      Me.aboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
      Me._menuItemHowTo = New System.Windows.Forms.ToolStripMenuItem()
      Me._menuItemAbout = New System.Windows.Forms.ToolStripMenuItem()
      Me._fieldName = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me._value = New System.Windows.Forms.DataGridViewTextBoxColumn()
      CType(Me._splMain, System.ComponentModel.ISupportInitialize).BeginInit()
      Me._splMain.Panel1.SuspendLayout()
      Me._splMain.Panel2.SuspendLayout()
      Me._splMain.SuspendLayout()
      CType(Me.dataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me._splViewerList, System.ComponentModel.ISupportInitialize).BeginInit()
      Me._splViewerList.Panel1.SuspendLayout()
      Me._splViewerList.Panel2.SuspendLayout()
      Me._splViewerList.SuspendLayout()
      Me._tsViewer.SuspendLayout()
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
      Me._splMain.Panel1.Controls.Add(Me.dataGridView1)
      Me._splMain.Panel1MinSize = 484
      ' 
      ' _splMain.Panel2
      ' 
      Me._splMain.Panel2.Controls.Add(Me._splViewerList)
      Me._splMain.Size = New System.Drawing.Size(1197, 721)
      Me._splMain.SplitterDistance = 484
      Me._splMain.TabIndex = 3
      ' 
      ' dataGridView1
      ' 
      Me.dataGridView1.AllowUserToAddRows = False
      Me.dataGridView1.AllowUserToDeleteRows = False
      Me.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
      Me.dataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me._fieldName, Me._value})
      Me.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
      Me.dataGridView1.Location = New System.Drawing.Point(0, 0)
      Me.dataGridView1.Name = "dataGridView1"
      Me.dataGridView1.Size = New System.Drawing.Size(480, 717)
      Me.dataGridView1.TabIndex = 0
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
      Me._splViewerList.Panel2.Controls.Add(Me.imageViewerField)
      Me._splViewerList.Size = New System.Drawing.Size(709, 721)
      Me._splViewerList.SplitterDistance = 464
      Me._splViewerList.TabIndex = 0
      ' 
      ' rasterImageViewer1
      ' 
      Me.rasterImageViewer1.Dock = System.Windows.Forms.DockStyle.Fill
      Me.rasterImageViewer1.ImageHorizontalAlignment = ControlAlignment.Near
      Me.rasterImageViewer1.ImageVerticalAlignment = ControlAlignment.Near
      Me.rasterImageViewer1.ImeMode = System.Windows.Forms.ImeMode.NoControl
      Me.rasterImageViewer1.IsSyncSource = True
      Me.rasterImageViewer1.IsSyncTarget = True
      Me.rasterImageViewer1.ItemPadding = New System.Windows.Forms.Padding(1)
      Me.rasterImageViewer1.Location = New System.Drawing.Point(0, 53)
      Me.rasterImageViewer1.Name = "rasterImageViewer1"
      Me.rasterImageViewer1.Size = New System.Drawing.Size(705, 407)
      Me.rasterImageViewer1.TabIndex = 5
      Me.rasterImageViewer1.UseDpi = True
      ' 
      ' _tsViewer
      ' 
      Me._tsViewer.ImageScalingSize = New System.Drawing.Size(20, 20)
      Me._tsViewer.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me._btnPanTool, Me.toolStripSeparator7, Me._btnZoomNormal, Me._btnFit, Me._btnFitWidth, Me._btnZoomIn, _
       Me._btnZoomOut, Me._btnZoomDrawTool, Me._btnUseDpi, Me.toolStripSeparator2})
      Me._tsViewer.Location = New System.Drawing.Point(0, 0)
      Me._tsViewer.Name = "_tsViewer"
      Me._tsViewer.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me._tsViewer.Size = New System.Drawing.Size(705, 53)
      Me._tsViewer.TabIndex = 4
      Me._tsViewer.Text = "toolStrip2"
      ' 
      ' _btnPanTool
      ' 
      Me._btnPanTool.AutoSize = False
      Me._btnPanTool.CheckOnClick = True
      Me._btnPanTool.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
      Me._btnPanTool.Image = CType(resources.GetObject("_btnPanTool.Image"), System.Drawing.Image)
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
      Me._btnZoomNormal.Image = CType(resources.GetObject("_btnZoomNormal.Image"), System.Drawing.Image)
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
      Me._btnFit.Image = CType(resources.GetObject("_btnFit.Image"), System.Drawing.Image)
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
      Me._btnFitWidth.Image = CType(resources.GetObject("_btnFitWidth.Image"), System.Drawing.Image)
      Me._btnFitWidth.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
      Me._btnFitWidth.ImageTransparentColor = System.Drawing.Color.Magenta
      Me._btnFitWidth.Name = "_btnFitWidth"
      Me._btnFitWidth.Size = New System.Drawing.Size(50, 50)
      Me._btnFitWidth.Text = "Fit To Image Width"
      ' 
      ' _btnZoomIn
      ' 
      Me._btnZoomIn.AutoSize = False
      Me._btnZoomIn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
      Me._btnZoomIn.Image = CType(resources.GetObject("_btnZoomIn.Image"), System.Drawing.Image)
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
      Me._btnZoomOut.Image = CType(resources.GetObject("_btnZoomOut.Image"), System.Drawing.Image)
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
      Me._btnZoomDrawTool.Image = CType(resources.GetObject("_btnZoomDrawTool.Image"), System.Drawing.Image)
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
      Me._btnUseDpi.Image = CType(resources.GetObject("_btnUseDpi.Image"), System.Drawing.Image)
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
      ' imageViewerField
      ' 
      Me.imageViewerField.Dock = System.Windows.Forms.DockStyle.Fill
      Me.imageViewerField.IsSyncSource = True
      Me.imageViewerField.IsSyncTarget = True
      Me.imageViewerField.ItemHorizontalAlignment = ControlAlignment.Near
      Me.imageViewerField.ItemPadding = New System.Windows.Forms.Padding(1)
      Me.imageViewerField.ItemVerticalAlignment = ControlAlignment.Near
      Me.imageViewerField.Location = New System.Drawing.Point(0, 0)
      Me.imageViewerField.Name = "imageViewerField"
      Me.imageViewerField.Size = New System.Drawing.Size(705, 249)
      Me.imageViewerField.TabIndex = 4
      Me.imageViewerField.UseDpi = True
      ' 
      ' menuStrip1
      ' 
      Me.menuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.fileToolStripMenuItem, Me._menuItemEngine, Me.helpToolStripMenuItem})
      Me.menuStrip1.Location = New System.Drawing.Point(0, 0)
      Me.menuStrip1.Name = "menuStrip1"
      Me.menuStrip1.Size = New System.Drawing.Size(1197, 24)
      Me.menuStrip1.TabIndex = 4
      Me.menuStrip1.Text = "menuStrip1"
      ' 
      ' fileToolStripMenuItem
      ' 
      Me.fileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.openToolStripMenuItem, Me.closeToolStripMenuItem, Me.exitToolStripMenuItem})
      Me.fileToolStripMenuItem.Name = "fileToolStripMenuItem"
      Me.fileToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
      Me.fileToolStripMenuItem.Text = "File"
      ' 
      ' openToolStripMenuItem
      ' 
      Me.openToolStripMenuItem.Name = "openToolStripMenuItem"
      Me.openToolStripMenuItem.Size = New System.Drawing.Size(103, 22)
      Me.openToolStripMenuItem.Text = "Open"
      ' 
      ' closeToolStripMenuItem
      ' 
      Me.closeToolStripMenuItem.Name = "closeToolStripMenuItem"
      Me.closeToolStripMenuItem.Size = New System.Drawing.Size(103, 22)
      Me.closeToolStripMenuItem.Text = "Close"
      ' 
      ' exitToolStripMenuItem
      ' 
      Me.exitToolStripMenuItem.Name = "exitToolStripMenuItem"
      Me.exitToolStripMenuItem.Size = New System.Drawing.Size(103, 22)
      Me.exitToolStripMenuItem.Text = "Exit"
      ' 
      ' _menuItemEngine
      ' 
      Me._menuItemEngine.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._menuItemLanguages, Me._menuItemComponents, Me.micrFontToolStripMenuItem})
      Me._menuItemEngine.Name = "_menuItemEngine"
      Me._menuItemEngine.Size = New System.Drawing.Size(55, 20)
      Me._menuItemEngine.Text = "Engine"
      ' 
      ' _menuItemLanguages
      ' 
      Me._menuItemLanguages.Name = "_menuItemLanguages"
      Me._menuItemLanguages.Size = New System.Drawing.Size(152, 22)
      Me._menuItemLanguages.Text = "Languages"
      ' 
      ' _menuItemComponents
      ' 
      Me._menuItemComponents.Name = "_menuItemComponents"
      Me._menuItemComponents.Size = New System.Drawing.Size(152, 22)
      Me._menuItemComponents.Text = "Components"
      ' 
      ' micrFontToolStripMenuItem
      ' 
      Me.micrFontToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {
            Me._miFontUnknown,
            Me._miFontE13B,
            Me._miFontCMC7})
      Me.micrFontToolStripMenuItem.Name = "micrFontToolStripMenuItem"
      Me.micrFontToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
      Me.micrFontToolStripMenuItem.Text = "Micr Font"
      ' 
      ' _miFontUnknown
      ' 
      Me._miFontUnknown.Checked = True
      Me._miFontUnknown.CheckOnClick = True
      Me._miFontUnknown.CheckState = System.Windows.Forms.CheckState.Checked
      Me._miFontUnknown.Name = "_miFontUnknown"
      Me._miFontUnknown.Size = New System.Drawing.Size(152, 22)
      Me._miFontUnknown.Text = "Unknown"
      ' 
      ' _miFontE13B
      ' 
      Me._miFontE13B.CheckOnClick = True
      Me._miFontE13B.Name = "_miFontE13B"
      Me._miFontE13B.Size = New System.Drawing.Size(152, 22)
      Me._miFontE13B.Text = "E13B"
      ' 
      ' _miFontCMC7
      ' 
      Me._miFontCMC7.CheckOnClick = True
      Me._miFontCMC7.Name = "_miFontCMC7"
      Me._miFontCMC7.Size = New System.Drawing.Size(152, 22)
      Me._miFontCMC7.Text = "CMC7"
      ' 
      ' helpToolStripMenuItem
      ' 
      Me.helpToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.aboutToolStripMenuItem})
      Me.helpToolStripMenuItem.Name = "helpToolStripMenuItem"
      Me.helpToolStripMenuItem.Size = New System.Drawing.Size(44, 20)
      Me.helpToolStripMenuItem.Text = "Help"
      ' 
      ' aboutToolStripMenuItem
      ' 
      Me.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem"
      Me.aboutToolStripMenuItem.Size = New System.Drawing.Size(107, 22)
      Me.aboutToolStripMenuItem.Text = "About"
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
      ' _fieldName
      ' 
      Me._fieldName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
      Me._fieldName.Frozen = True
      Me._fieldName.HeaderText = "Field Name"
      Me._fieldName.Name = "_fieldName"
      Me._fieldName.[ReadOnly] = True
      Me._fieldName.Width = 85
      ' 
      ' _value
      ' 
      Me._value.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
      Me._value.Frozen = True
      Me._value.HeaderText = "Value"
      Me._value.Name = "_value"
      Me._value.[ReadOnly] = True
      Me._value.Width = 59
      ' 
      ' MainForm
      ' 
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(1197, 745)
      Me.Controls.Add(Me._splMain)
      Me.Controls.Add(Me.menuStrip1)
      Me.Icon = CType(resources.GetObject("$me.Icon"), System.Drawing.Icon)
      Me.MainMenuStrip = Me.menuStrip1
      Me.Name = "MainForm"
      Me.Text = "LEADTOOLS Bank Check Reader"
      Me._splMain.Panel1.ResumeLayout(False)
      Me._splMain.Panel2.ResumeLayout(False)
      CType(Me._splMain, System.ComponentModel.ISupportInitialize).EndInit()
      Me._splMain.ResumeLayout(False)
      CType(Me.dataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
      Me._splViewerList.Panel1.ResumeLayout(False)
      Me._splViewerList.Panel1.PerformLayout()
      Me._splViewerList.Panel2.ResumeLayout(False)
      CType(Me._splViewerList, System.ComponentModel.ISupportInitialize).EndInit()
      Me._splViewerList.ResumeLayout(False)
      Me._tsViewer.ResumeLayout(False)
      Me._tsViewer.PerformLayout()
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
   Private WithEvents _menuItemLanguages As System.Windows.Forms.ToolStripMenuItem
   Private WithEvents _menuItemComponents As System.Windows.Forms.ToolStripMenuItem
   Private _menuItemEngine As System.Windows.Forms.ToolStripMenuItem
   Private fileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Private WithEvents openToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Private WithEvents dataGridView1 As System.Windows.Forms.DataGridView
   Private imageViewerField As ImageViewer
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
   Private _fieldName As System.Windows.Forms.DataGridViewTextBoxColumn
   Private _value As System.Windows.Forms.DataGridViewTextBoxColumn
   Private micrFontToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Private WithEvents _miFontUnknown As System.Windows.Forms.ToolStripMenuItem
   Private WithEvents _miFontE13B As System.Windows.Forms.ToolStripMenuItem
   Private WithEvents _miFontCMC7 As System.Windows.Forms.ToolStripMenuItem
End Class

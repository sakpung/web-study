Imports Leadtools.Annotations.WinForms
Imports Leadtools.Controls

Partial Class ViewerControl
   Private components As System.ComponentModel.IContainer = Nothing

   Protected Overrides Sub Dispose(ByVal disposing As Boolean)
      If disposing AndAlso (components IsNot Nothing) Then
         components.Dispose()
      End If

      MyBase.Dispose(disposing)
   End Sub

   Private Sub InitializeComponent()
      Dim myresources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ViewerControl))
      Me._titleLabel = New System.Windows.Forms.Label()
      Me._toolStrip = New System.Windows.Forms.ToolStrip()
      Me._pageToolStripTextBox = New System.Windows.Forms.ToolStripTextBox()
      Me._pageToolStripLabel = New System.Windows.Forms.ToolStripLabel()
      Me._toolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
      Me._zoomToolStripComboBox = New System.Windows.Forms.ToolStripComboBox()
      Me._toolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
      Me._toolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
      Me.toolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
      Me._rasterImageViewer = New AutomationImageViewer()
      Me._splitContainer = New System.Windows.Forms.SplitContainer()
      Me._mousePositionLabel = New System.Windows.Forms.Label()
      Me.menuStrip1 = New System.Windows.Forms.MenuStrip()
      Me.fileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
      Me.newToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
      Me.openToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
      Me.saveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
      Me.saveasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
      Me.toolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
      Me.closeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
      Me.exitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
      Me.editToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
      Me.editNodeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
      Me.toolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
      Me.addPageToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
      Me.deletePageToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
      Me.toolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
      Me.movePageUpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
      Me.movePageDownToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
      Me.toolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
      Me.rotateToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
      Me.by90DegreesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
      Me.by180DegreesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
      Me.by270DegreesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
      Me.flipToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
      Me.horizontallyToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
      Me.verticallyToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
      Me.deskewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
      Me.settingsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
      Me.optionsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
      Me.tsToggleSubzones = New System.Windows.Forms.ToolStripMenuItem()
      Me.helpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
      Me.spltViewer = New System.Windows.Forms.SplitContainer()
      Me.trvForm = New System.Windows.Forms.TreeView()
      Me._previousPageToolStripButton = New System.Windows.Forms.ToolStripButton()
      Me._nextPageToolStripButton = New System.Windows.Forms.ToolStripButton()
      Me._zoomOutToolStripButton = New System.Windows.Forms.ToolStripButton()
      Me._zoomInToolStripButton = New System.Windows.Forms.ToolStripButton()
      Me._fitPageWidthToolStripButton = New System.Windows.Forms.ToolStripButton()
      Me._fitPageToolStripButton = New System.Windows.Forms.ToolStripButton()
      Me._zoomToSelectionModeToolStripButton = New System.Windows.Forms.ToolStripButton()
      Me.tssShowPanWindow = New System.Windows.Forms.ToolStripButton()
      Me.tsZOMRRegion = New System.Windows.Forms.ToolStripButton()
      Me.tszBarcode = New System.Windows.Forms.ToolStripButton()
      Me.tsZOCR = New System.Windows.Forms.ToolStripButton()
      Me.tszImage = New System.Windows.Forms.ToolStripButton()
      Me._showZonesToolStripButton = New System.Windows.Forms.ToolStripButton()
      Me.aboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
      Me.informationToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
      Me.toolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
      Me._toolStrip.SuspendLayout()
      CType(Me._splitContainer, System.ComponentModel.ISupportInitialize).BeginInit()
      Me._splitContainer.Panel1.SuspendLayout()
      Me._splitContainer.SuspendLayout()
      Me.menuStrip1.SuspendLayout()
      CType(Me.spltViewer, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.spltViewer.Panel1.SuspendLayout()
      Me.spltViewer.Panel2.SuspendLayout()
      Me.spltViewer.SuspendLayout()
      Me.SuspendLayout()
      Me._titleLabel.Dock = System.Windows.Forms.DockStyle.Top
      Me._titleLabel.Location = New System.Drawing.Point(0, 49)
      Me._titleLabel.Name = "_titleLabel"
      Me._titleLabel.Size = New System.Drawing.Size(770, 13)
      Me._titleLabel.TabIndex = 0
      Me._titleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me._toolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me._previousPageToolStripButton, Me._nextPageToolStripButton, Me._pageToolStripTextBox, Me._pageToolStripLabel, Me._toolStripSeparator1, Me._zoomOutToolStripButton, Me._zoomInToolStripButton, Me._zoomToolStripComboBox, Me._fitPageWidthToolStripButton, Me._fitPageToolStripButton, Me._toolStripSeparator2, Me._zoomToSelectionModeToolStripButton, Me.tssShowPanWindow, Me._toolStripSeparator3, Me.tsZOMRRegion, Me.tszBarcode, Me.tsZOCR, Me.tszImage, Me.toolStripSeparator2, Me._showZonesToolStripButton})
      Me._toolStrip.Location = New System.Drawing.Point(0, 24)
      Me._toolStrip.Name = "_toolStrip"
      Me._toolStrip.Size = New System.Drawing.Size(770, 25)
      Me._toolStrip.TabIndex = 1
      Me._pageToolStripTextBox.Name = "_pageToolStripTextBox"
      Me._pageToolStripTextBox.Size = New System.Drawing.Size(40, 25)
      Me._pageToolStripTextBox.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Center
      Me._pageToolStripTextBox.ToolTipText = "Current page number in the document"
      AddHandler Me._pageToolStripTextBox.KeyPress, AddressOf Me._pageToolStripTextBox_KeyPress
      Me._pageToolStripLabel.Name = "_pageToolStripLabel"
      Me._pageToolStripLabel.Size = New System.Drawing.Size(21, 22)
      Me._pageToolStripLabel.Text = "/ 0"
      Me._toolStripSeparator1.Name = "_toolStripSeparator1"
      Me._toolStripSeparator1.Size = New System.Drawing.Size(6, 25)
      Me._zoomToolStripComboBox.DropDownWidth = 80
      Me._zoomToolStripComboBox.Items.AddRange(New Object() {"10%", "25%", "50%", "75%", "100%", "125%", "200%", "400%", "800%", "1600%", "2400%", "3200%", "6400%", "Actual Size", "Fit Page", "Fit Width"})
      Me._zoomToolStripComboBox.Name = "_zoomToolStripComboBox"
      Me._zoomToolStripComboBox.Size = New System.Drawing.Size(80, 25)
      AddHandler Me._zoomToolStripComboBox.SelectedIndexChanged, AddressOf Me._zoomToolStripComboBox_SelectedIndexChanged
      AddHandler Me._zoomToolStripComboBox.KeyPress, AddressOf Me._zoomToolStripComboBox_KeyPress
      Me._toolStripSeparator2.Name = "_toolStripSeparator2"
      Me._toolStripSeparator2.Size = New System.Drawing.Size(6, 25)
      Me._toolStripSeparator3.Name = "_toolStripSeparator3"
      Me._toolStripSeparator3.Size = New System.Drawing.Size(6, 25)
      Me.toolStripSeparator2.Name = "toolStripSeparator2"
      Me.toolStripSeparator2.Size = New System.Drawing.Size(6, 25)
      Me._rasterImageViewer.AutomationAntiAlias = False
      Me._rasterImageViewer.AutomationContainerIndex = -1
      Me._rasterImageViewer.AutomationDataProvider = Nothing
      Me._rasterImageViewer.AutomationGetContainersCallback = Nothing
      Me._rasterImageViewer.AutomationObject = Nothing
      Me._rasterImageViewer.BackColor = System.Drawing.SystemColors.AppWorkspace
      Me._rasterImageViewer.Dock = System.Windows.Forms.DockStyle.Fill
      Me._rasterImageViewer.ImageBackgroundColor = System.Drawing.Color.White
      Me._rasterImageViewer.IsAutomationEventsHooked = False
      Me._rasterImageViewer.IsSyncSource = True
      Me._rasterImageViewer.IsSyncTarget = True
      Me._rasterImageViewer.ItemPadding = New System.Windows.Forms.Padding(1)
      Me._rasterImageViewer.Location = New System.Drawing.Point(0, 0)
      Me._rasterImageViewer.Name = "_rasterImageViewer"
      Me._rasterImageViewer.RenderingEngine = Nothing
      Me._rasterImageViewer.Size = New System.Drawing.Size(567, 343)
      Me._rasterImageViewer.TabIndex = 0
      Me._rasterImageViewer.UseDpi = True
      Me._rasterImageViewer.ViewHorizontalAlignment = ControlAlignment.Center
      Me._rasterImageViewer.ViewVerticalAlignment = ControlAlignment.Center
      AddHandler Me._rasterImageViewer.TransformChanged, AddressOf Me._rasterImageViewer_TransformChanged
      AddHandler Me._rasterImageViewer.Leave, AddressOf Me._rasterImageViewer_Leave
      AddHandler Me._rasterImageViewer.MouseDoubleClick, AddressOf Me._rasterImageViewer_MouseDoubleClick
      AddHandler Me._rasterImageViewer.MouseHover, AddressOf Me._rasterImageViewer_MouseHover
      AddHandler Me._rasterImageViewer.MouseMove, AddressOf Me._rasterImageViewer_MouseMove
      Me._splitContainer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me._splitContainer.Dock = System.Windows.Forms.DockStyle.Bottom
      Me._splitContainer.IsSplitterFixed = True
      Me._splitContainer.Location = New System.Drawing.Point(0, 405)
      Me._splitContainer.Name = "_splitContainer"
      Me._splitContainer.Panel1.Controls.Add(Me._mousePositionLabel)
      Me._splitContainer.Size = New System.Drawing.Size(770, 16)
      Me._splitContainer.SplitterDistance = 255
      Me._splitContainer.SplitterWidth = 1
      Me._splitContainer.TabIndex = 4
      Me._mousePositionLabel.Dock = System.Windows.Forms.DockStyle.Bottom
      Me._mousePositionLabel.Location = New System.Drawing.Point(0, 1)
      Me._mousePositionLabel.Name = "_mousePositionLabel"
      Me._mousePositionLabel.Size = New System.Drawing.Size(253, 13)
      Me._mousePositionLabel.TabIndex = 6
      Me._mousePositionLabel.Text = "_mousePositionLabel"
      Me._mousePositionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.menuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.fileToolStripMenuItem, Me.editToolStripMenuItem, Me.settingsToolStripMenuItem, Me.helpToolStripMenuItem})
      Me.menuStrip1.Location = New System.Drawing.Point(0, 0)
      Me.menuStrip1.Name = "menuStrip1"
      Me.menuStrip1.Size = New System.Drawing.Size(770, 24)
      Me.menuStrip1.TabIndex = 5
      Me.menuStrip1.Text = "menuStrip1"
      Me.fileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.newToolStripMenuItem, Me.openToolStripMenuItem, Me.saveToolStripMenuItem, Me.saveasToolStripMenuItem, Me.toolStripSeparator1, Me.closeToolStripMenuItem, Me.exitToolStripMenuItem})
      Me.fileToolStripMenuItem.Name = "fileToolStripMenuItem"
      Me.fileToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
      Me.fileToolStripMenuItem.Text = "&File"
      Me.newToolStripMenuItem.Name = "newToolStripMenuItem"
      Me.newToolStripMenuItem.Size = New System.Drawing.Size(123, 22)
      Me.newToolStripMenuItem.Text = "&New..."
      AddHandler Me.newToolStripMenuItem.Click, AddressOf Me.newToolStripMenuItem_Click
      Me.openToolStripMenuItem.Name = "openToolStripMenuItem"
      Me.openToolStripMenuItem.Size = New System.Drawing.Size(123, 22)
      Me.openToolStripMenuItem.Text = "&Open..."
      AddHandler Me.openToolStripMenuItem.Click, AddressOf Me.openToolStripMenuItem_Click
      Me.saveToolStripMenuItem.Enabled = False
      Me.saveToolStripMenuItem.Name = "saveToolStripMenuItem"
      Me.saveToolStripMenuItem.Size = New System.Drawing.Size(123, 22)
      Me.saveToolStripMenuItem.Text = "&Save"
      AddHandler Me.saveToolStripMenuItem.Click, AddressOf Me.saveToolStripMenuItem_Click
      Me.saveasToolStripMenuItem.Enabled = False
      Me.saveasToolStripMenuItem.Name = "saveasToolStripMenuItem"
      Me.saveasToolStripMenuItem.Size = New System.Drawing.Size(123, 22)
      Me.saveasToolStripMenuItem.Text = "Save &As..."
      AddHandler Me.saveasToolStripMenuItem.Click, AddressOf Me.saveasToolStripMenuItem_Click
      Me.toolStripSeparator1.Name = "toolStripSeparator1"
      Me.toolStripSeparator1.Size = New System.Drawing.Size(120, 6)
      Me.closeToolStripMenuItem.Enabled = False
      Me.closeToolStripMenuItem.Name = "closeToolStripMenuItem"
      Me.closeToolStripMenuItem.Size = New System.Drawing.Size(123, 22)
      Me.closeToolStripMenuItem.Text = "&Close"
      AddHandler Me.closeToolStripMenuItem.Click, AddressOf Me.closeToolStripMenuItem_Click
      Me.exitToolStripMenuItem.Name = "exitToolStripMenuItem"
      Me.exitToolStripMenuItem.Size = New System.Drawing.Size(123, 22)
      Me.exitToolStripMenuItem.Text = "E&xit"
      AddHandler Me.exitToolStripMenuItem.Click, AddressOf Me.exitToolStripMenuItem_Click
      Me.editToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.editNodeToolStripMenuItem, Me.toolStripSeparator5, Me.addPageToolStripMenuItem, Me.deletePageToolStripMenuItem, Me.toolStripSeparator3, Me.movePageUpToolStripMenuItem, Me.movePageDownToolStripMenuItem, Me.toolStripSeparator4, Me.rotateToolStripMenuItem, Me.flipToolStripMenuItem, Me.deskewToolStripMenuItem})
      Me.editToolStripMenuItem.Enabled = False
      Me.editToolStripMenuItem.Name = "editToolStripMenuItem"
      Me.editToolStripMenuItem.Size = New System.Drawing.Size(39, 20)
      Me.editToolStripMenuItem.Text = "&Edit"
      AddHandler Me.editToolStripMenuItem.Click, AddressOf Me.editToolStripMenuItem_Click
      Me.editNodeToolStripMenuItem.Name = "editNodeToolStripMenuItem"
      Me.editNodeToolStripMenuItem.ShortcutKeys = (CType(((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.E)), System.Windows.Forms.Keys))
      Me.editNodeToolStripMenuItem.Size = New System.Drawing.Size(175, 22)
      Me.editNodeToolStripMenuItem.Text = "Ed&it Node..."
      AddHandler Me.editNodeToolStripMenuItem.Click, AddressOf Me.editNodeToolStripMenuItem_Click
      Me.toolStripSeparator5.Name = "toolStripSeparator5"
      Me.toolStripSeparator5.Size = New System.Drawing.Size(172, 6)
      Me.addPageToolStripMenuItem.Name = "addPageToolStripMenuItem"
      Me.addPageToolStripMenuItem.Size = New System.Drawing.Size(175, 22)
      Me.addPageToolStripMenuItem.Text = "&Add Page..."
      AddHandler Me.addPageToolStripMenuItem.Click, AddressOf Me.addPageToolStripMenuItem_Click
      Me.deletePageToolStripMenuItem.Name = "deletePageToolStripMenuItem"
      Me.deletePageToolStripMenuItem.Size = New System.Drawing.Size(175, 22)
      Me.deletePageToolStripMenuItem.Text = "&Delete Page"
      AddHandler Me.deletePageToolStripMenuItem.Click, AddressOf Me.deletePageToolStripMenuItem_Click
      Me.toolStripSeparator3.Name = "toolStripSeparator3"
      Me.toolStripSeparator3.Size = New System.Drawing.Size(172, 6)
      Me.movePageUpToolStripMenuItem.Name = "movePageUpToolStripMenuItem"
      Me.movePageUpToolStripMenuItem.Size = New System.Drawing.Size(175, 22)
      Me.movePageUpToolStripMenuItem.Text = "Move Page &Up"
      AddHandler Me.movePageUpToolStripMenuItem.Click, AddressOf Me.movePageUpToolStripMenuItem_Click
      Me.movePageDownToolStripMenuItem.Name = "movePageDownToolStripMenuItem"
      Me.movePageDownToolStripMenuItem.Size = New System.Drawing.Size(175, 22)
      Me.movePageDownToolStripMenuItem.Text = "Move Page &Down"
      AddHandler Me.movePageDownToolStripMenuItem.Click, AddressOf Me.movePageDownToolStripMenuItem_Click
      Me.toolStripSeparator4.Name = "toolStripSeparator4"
      Me.toolStripSeparator4.Size = New System.Drawing.Size(172, 6)
      Me.toolStripSeparator4.Visible = False
      Me.rotateToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.by90DegreesToolStripMenuItem, Me.by180DegreesToolStripMenuItem, Me.by270DegreesToolStripMenuItem})
      Me.rotateToolStripMenuItem.Name = "rotateToolStripMenuItem"
      Me.rotateToolStripMenuItem.Size = New System.Drawing.Size(175, 22)
      Me.rotateToolStripMenuItem.Text = "&Rotate"
      Me.rotateToolStripMenuItem.Visible = False
      Me.by90DegreesToolStripMenuItem.Name = "by90DegreesToolStripMenuItem"
      Me.by90DegreesToolStripMenuItem.Size = New System.Drawing.Size(153, 22)
      Me.by90DegreesToolStripMenuItem.Text = "By 90 Degrees"
      AddHandler Me.by90DegreesToolStripMenuItem.Click, AddressOf Me.by90DegreesToolStripMenuItem_Click
      Me.by180DegreesToolStripMenuItem.Name = "by180DegreesToolStripMenuItem"
      Me.by180DegreesToolStripMenuItem.Size = New System.Drawing.Size(153, 22)
      Me.by180DegreesToolStripMenuItem.Text = "By 180 Degrees"
      AddHandler Me.by180DegreesToolStripMenuItem.Click, AddressOf Me.by180DegreesToolStripMenuItem_Click
      Me.by270DegreesToolStripMenuItem.Name = "by270DegreesToolStripMenuItem"
      Me.by270DegreesToolStripMenuItem.Size = New System.Drawing.Size(153, 22)
      Me.by270DegreesToolStripMenuItem.Text = "By 270 Degrees"
      AddHandler Me.by270DegreesToolStripMenuItem.Click, AddressOf Me.by270DegreesToolStripMenuItem_Click
      Me.flipToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.horizontallyToolStripMenuItem, Me.verticallyToolStripMenuItem})
      Me.flipToolStripMenuItem.Name = "flipToolStripMenuItem"
      Me.flipToolStripMenuItem.Size = New System.Drawing.Size(175, 22)
      Me.flipToolStripMenuItem.Text = "&Flip"
      Me.flipToolStripMenuItem.Visible = False
      Me.horizontallyToolStripMenuItem.Name = "horizontallyToolStripMenuItem"
      Me.horizontallyToolStripMenuItem.Size = New System.Drawing.Size(138, 22)
      Me.horizontallyToolStripMenuItem.Text = "&Horizontally"
      AddHandler Me.horizontallyToolStripMenuItem.Click, AddressOf Me.horizontallyToolStripMenuItem_Click
      Me.verticallyToolStripMenuItem.Name = "verticallyToolStripMenuItem"
      Me.verticallyToolStripMenuItem.Size = New System.Drawing.Size(138, 22)
      Me.verticallyToolStripMenuItem.Text = "&Vertically"
      AddHandler Me.verticallyToolStripMenuItem.Click, AddressOf Me.verticallyToolStripMenuItem_Click
      Me.deskewToolStripMenuItem.Name = "deskewToolStripMenuItem"
      Me.deskewToolStripMenuItem.Size = New System.Drawing.Size(175, 22)
      Me.deskewToolStripMenuItem.Text = "Deske&w"
      Me.deskewToolStripMenuItem.Visible = False
      AddHandler Me.deskewToolStripMenuItem.Click, AddressOf Me.deskewToolStripMenuItem_Click
      Me.settingsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.optionsToolStripMenuItem, Me.tsToggleSubzones})
      Me.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem"
      Me.settingsToolStripMenuItem.Size = New System.Drawing.Size(61, 20)
      Me.settingsToolStripMenuItem.Text = "&Settings"
      Me.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem"
      Me.optionsToolStripMenuItem.Size = New System.Drawing.Size(156, 22)
      Me.optionsToolStripMenuItem.Text = "&Options..."
      AddHandler Me.optionsToolStripMenuItem.Click, AddressOf Me.optionsToolStripMenuItem_Click
      Me.tsToggleSubzones.CheckOnClick = True
      Me.tsToggleSubzones.Name = "tsToggleSubzones"
      Me.tsToggleSubzones.Size = New System.Drawing.Size(156, 22)
      Me.tsToggleSubzones.Text = "&Show Subzones"
      AddHandler Me.tsToggleSubzones.CheckedChanged, AddressOf Me.tsToggleSubzones_Click
      Me.helpToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.informationToolStripMenuItem, Me.toolStripSeparator6, Me.aboutToolStripMenuItem})
      Me.helpToolStripMenuItem.Name = "helpToolStripMenuItem"
      Me.helpToolStripMenuItem.Size = New System.Drawing.Size(44, 20)
      Me.helpToolStripMenuItem.Text = "&Help"
      Me.spltViewer.Dock = System.Windows.Forms.DockStyle.Fill
      Me.spltViewer.Location = New System.Drawing.Point(0, 62)
      Me.spltViewer.Name = "spltViewer"
      Me.spltViewer.Panel1.Controls.Add(Me.trvForm)
      Me.spltViewer.Panel2.Controls.Add(Me._rasterImageViewer)
      Me.spltViewer.Size = New System.Drawing.Size(770, 343)
      Me.spltViewer.SplitterDistance = 199
      Me.spltViewer.TabIndex = 0
      Me.trvForm.Dock = System.Windows.Forms.DockStyle.Fill
      Me.trvForm.Location = New System.Drawing.Point(0, 0)
      Me.trvForm.Name = "trvForm"
      Me.trvForm.Size = New System.Drawing.Size(199, 343)
      Me.trvForm.TabIndex = 0
      AddHandler Me.trvForm.BeforeCollapse, AddressOf Me.trvForm_BeforeCollapse
      AddHandler Me.trvForm.BeforeExpand, AddressOf Me.trvForm_BeforeExpand
      AddHandler Me.trvForm.AfterSelect, AddressOf Me.trvForm_AfterSelect
      AddHandler Me.trvForm.NodeMouseClick, AddressOf Me.trvForm_NodeMouseClick
      AddHandler Me.trvForm.NodeMouseDoubleClick, AddressOf Me.trvForm_NodeMouseDoubleClick
      AddHandler Me.trvForm.KeyUp, AddressOf Me.trvForm_KeyUp
      AddHandler Me.trvForm.MouseDown, AddressOf Me.trvForm_MouseDown
      AddHandler Me.trvForm.MouseLeave, AddressOf Me.trvForm_MouseLeave
      AddHandler Me.trvForm.MouseMove, AddressOf Me.trvForm_MouseMove
      Me._previousPageToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
      Me._previousPageToolStripButton.Image = Resources.PreviousPage
      Me._previousPageToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
      Me._previousPageToolStripButton.Name = "_previousPageToolStripButton"
      Me._previousPageToolStripButton.Size = New System.Drawing.Size(23, 22)
      Me._previousPageToolStripButton.Text = "Previous"
      Me._previousPageToolStripButton.ToolTipText = "Go to previous page in the document"
      AddHandler Me._previousPageToolStripButton.Click, AddressOf Me._previousPageToolStripButton_Click
      Me._nextPageToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
      Me._nextPageToolStripButton.Image = Resources.NextPage
      Me._nextPageToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
      Me._nextPageToolStripButton.Name = "_nextPageToolStripButton"
      Me._nextPageToolStripButton.Size = New System.Drawing.Size(23, 22)
      Me._nextPageToolStripButton.Text = "Next"
      Me._nextPageToolStripButton.ToolTipText = "Go to next page in the document"
      AddHandler Me._nextPageToolStripButton.Click, AddressOf Me._nextPageToolStripButton_Click
      Me._zoomOutToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
      Me._zoomOutToolStripButton.Image = Resources.zoom_out
      Me._zoomOutToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
      Me._zoomOutToolStripButton.Name = "_zoomOutToolStripButton"
      Me._zoomOutToolStripButton.Size = New System.Drawing.Size(23, 22)
      Me._zoomOutToolStripButton.Text = "Zoom Out"
      Me._zoomOutToolStripButton.ToolTipText = "Zoom out"
      AddHandler Me._zoomOutToolStripButton.Click, AddressOf Me._zoomOutToolStripButton_Click
      Me._zoomInToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
      Me._zoomInToolStripButton.Image = Resources.zoom
      Me._zoomInToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
      Me._zoomInToolStripButton.Name = "_zoomInToolStripButton"
      Me._zoomInToolStripButton.Size = New System.Drawing.Size(23, 22)
      Me._zoomInToolStripButton.Text = "Zoom In"
      Me._zoomInToolStripButton.ToolTipText = "Zoom In"
      AddHandler Me._zoomInToolStripButton.Click, AddressOf Me._zoomInToolStripButton_Click
      Me._fitPageWidthToolStripButton.CheckOnClick = True
      Me._fitPageWidthToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
      Me._fitPageWidthToolStripButton.Image = Resources.pan
      Me._fitPageWidthToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
      Me._fitPageWidthToolStripButton.Name = "_fitPageWidthToolStripButton"
      Me._fitPageWidthToolStripButton.Size = New System.Drawing.Size(23, 22)
      Me._fitPageWidthToolStripButton.Text = "FitWidth"
      Me._fitPageWidthToolStripButton.ToolTipText = "Fit page width in window"
      AddHandler Me._fitPageWidthToolStripButton.Click, AddressOf Me._fitPageWidthToolStripButton_Click
      Me._fitPageToolStripButton.CheckOnClick = True
      Me._fitPageToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
      Me._fitPageToolStripButton.Image = Resources.FitPageToWindow
      Me._fitPageToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
      Me._fitPageToolStripButton.Name = "_fitPageToolStripButton"
      Me._fitPageToolStripButton.Size = New System.Drawing.Size(23, 22)
      Me._fitPageToolStripButton.Text = "FitPage"
      Me._fitPageToolStripButton.ToolTipText = "Fit entire page in window"
      AddHandler Me._fitPageToolStripButton.Click, AddressOf Me._fitPageToolStripButton_Click
      Me._zoomToSelectionModeToolStripButton.CheckOnClick = True
      Me._zoomToSelectionModeToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
      Me._zoomToSelectionModeToolStripButton.Image = Resources.zoom_select
      Me._zoomToSelectionModeToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
      Me._zoomToSelectionModeToolStripButton.Name = "_zoomToSelectionModeToolStripButton"
      Me._zoomToSelectionModeToolStripButton.Size = New System.Drawing.Size(23, 22)
      Me._zoomToSelectionModeToolStripButton.Text = "ZoomTo"
      Me._zoomToSelectionModeToolStripButton.ToolTipText = "Zoom to selection mode"
      AddHandler Me._zoomToSelectionModeToolStripButton.Click, AddressOf Me._zoomToSelectionModeToolStripButton_Click
      Me.tssShowPanWindow.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
      Me.tssShowPanWindow.Image = Resources.show_pan
      Me.tssShowPanWindow.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.tssShowPanWindow.Name = "tssShowPanWindow"
      Me.tssShowPanWindow.Size = New System.Drawing.Size(23, 22)
      Me.tssShowPanWindow.Text = "Show Pan Window"
      AddHandler Me.tssShowPanWindow.Click, AddressOf Me.tssShowPanWindow_Click
      Me.tsZOMRRegion.CheckOnClick = True
      Me.tsZOMRRegion.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
      Me.tsZOMRRegion.Image = (CType((myresources.GetObject("tsZOMRRegion.Image")), System.Drawing.Image))
      Me.tsZOMRRegion.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.tsZOMRRegion.Name = "tsZOMRRegion"
      Me.tsZOMRRegion.Size = New System.Drawing.Size(23, 22)
      Me.tsZOMRRegion.Text = "OMR Region"
      AddHandler Me.tsZOMRRegion.Click, AddressOf Me.tzOMRREgion_Click
      Me.tszBarcode.CheckOnClick = True
      Me.tszBarcode.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
      Me.tszBarcode.Image = (CType((myresources.GetObject("tszBarcode.Image")), System.Drawing.Image))
      Me.tszBarcode.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.tszBarcode.Name = "tszBarcode"
      Me.tszBarcode.Size = New System.Drawing.Size(23, 22)
      Me.tszBarcode.Text = "Barcode"
      AddHandler Me.tszBarcode.Click, AddressOf Me.tzBarcode_Click
      Me.tsZOCR.CheckOnClick = True
      Me.tsZOCR.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
      Me.tsZOCR.Image = Resources.green_note
      Me.tsZOCR.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.tsZOCR.Name = "tsZOCR"
      Me.tsZOCR.Size = New System.Drawing.Size(23, 22)
      Me.tsZOCR.Text = "OCR"
      AddHandler Me.tsZOCR.Click, AddressOf Me.tzOCR_Click
      Me.tszImage.CheckOnClick = True
      Me.tszImage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
      Me.tszImage.Image = Resources.picture
      Me.tszImage.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.tszImage.Name = "tszImage"
      Me.tszImage.Size = New System.Drawing.Size(23, 22)
      Me.tszImage.Text = "Image"
      AddHandler Me.tszImage.Click, AddressOf Me.tszImage_Click
      Me._showZonesToolStripButton.Checked = True
      Me._showZonesToolStripButton.CheckOnClick = True
      Me._showZonesToolStripButton.CheckState = System.Windows.Forms.CheckState.Checked
      Me._showZonesToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
      Me._showZonesToolStripButton.Image = Resources.note_2
      Me._showZonesToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
      Me._showZonesToolStripButton.Name = "_showZonesToolStripButton"
      Me._showZonesToolStripButton.Size = New System.Drawing.Size(23, 22)
      Me._showZonesToolStripButton.Text = "ShowZones"
      Me._showZonesToolStripButton.ToolTipText = "Show/hide zones"
      AddHandler Me._showZonesToolStripButton.Click, AddressOf Me._showZonesToolStripButton_Click
      Me.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem"
      Me.aboutToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
      Me.aboutToolStripMenuItem.Text = "&About"
      AddHandler Me.aboutToolStripMenuItem.Click, AddressOf Me.aboutToolStripMenuItem_Click
      Me.informationToolStripMenuItem.Name = "informationToolStripMenuItem"
      Me.informationToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
      Me.informationToolStripMenuItem.Text = "&Information"
      AddHandler Me.informationToolStripMenuItem.Click, AddressOf Me.informationToolStripMenuItem_Click
      Me.toolStripSeparator6.Name = "toolStripSeparator6"
      Me.toolStripSeparator6.Size = New System.Drawing.Size(149, 6)
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.Controls.Add(Me.spltViewer)
      Me.Controls.Add(Me._splitContainer)
      Me.Controls.Add(Me._titleLabel)
      Me.Controls.Add(Me._toolStrip)
      Me.Controls.Add(Me.menuStrip1)
      Me.Name = "ViewerControl"
      Me.Size = New System.Drawing.Size(770, 421)
      Me._toolStrip.ResumeLayout(False)
      Me._toolStrip.PerformLayout()
      Me._splitContainer.Panel1.ResumeLayout(False)
      CType(Me._splitContainer, System.ComponentModel.ISupportInitialize).EndInit()
      Me._splitContainer.ResumeLayout(False)
      Me.menuStrip1.ResumeLayout(False)
      Me.menuStrip1.PerformLayout()
      Me.spltViewer.Panel1.ResumeLayout(False)
      Me.spltViewer.Panel2.ResumeLayout(False)
      CType(Me.spltViewer, System.ComponentModel.ISupportInitialize).EndInit()
      Me.spltViewer.ResumeLayout(False)
      Me.ResumeLayout(False)
      Me.PerformLayout()
   End Sub

   Private _titleLabel As System.Windows.Forms.Label
   Public _toolStrip As System.Windows.Forms.ToolStrip
   Private _rasterImageViewer As AutomationImageViewer
   Private _previousPageToolStripButton As System.Windows.Forms.ToolStripButton
   Private _nextPageToolStripButton As System.Windows.Forms.ToolStripButton
   Private _pageToolStripTextBox As System.Windows.Forms.ToolStripTextBox
   Private _pageToolStripLabel As System.Windows.Forms.ToolStripLabel
   Private _toolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
   Private _zoomOutToolStripButton As System.Windows.Forms.ToolStripButton
   Private _zoomInToolStripButton As System.Windows.Forms.ToolStripButton
   Private _zoomToolStripComboBox As System.Windows.Forms.ToolStripComboBox
   Private _fitPageWidthToolStripButton As System.Windows.Forms.ToolStripButton
   Private _fitPageToolStripButton As System.Windows.Forms.ToolStripButton
   Private _toolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
   Private _zoomToSelectionModeToolStripButton As System.Windows.Forms.ToolStripButton
   Private _toolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
   Private _showZonesToolStripButton As System.Windows.Forms.ToolStripButton
   Private _splitContainer As System.Windows.Forms.SplitContainer
   Private _mousePositionLabel As System.Windows.Forms.Label
   Private menuStrip1 As System.Windows.Forms.MenuStrip
   Private fileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Private newToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Private openToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Private saveToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Private saveasToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Private toolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
   Private exitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Private spltViewer As System.Windows.Forms.SplitContainer
   Private trvForm As System.Windows.Forms.TreeView
   Private tsZOMRRegion As System.Windows.Forms.ToolStripButton
   Private tszBarcode As System.Windows.Forms.ToolStripButton
   Private tsZOCR As System.Windows.Forms.ToolStripButton
   Private toolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
   Private settingsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Private optionsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Private tsToggleSubzones As System.Windows.Forms.ToolStripMenuItem
   Private editToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Private addPageToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Private deletePageToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Private movePageUpToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Private movePageDownToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Private toolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
   Private toolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
   Private rotateToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Private by90DegreesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Private by180DegreesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Private by270DegreesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Private flipToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Private horizontallyToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Private verticallyToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Private deskewToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Private tszImage As System.Windows.Forms.ToolStripButton
   Private tssShowPanWindow As System.Windows.Forms.ToolStripButton
   Private helpToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Private closeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Private editNodeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Private toolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
   Private aboutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Private informationToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Private toolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
End Class

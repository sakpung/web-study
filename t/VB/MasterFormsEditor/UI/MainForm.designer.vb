
Partial Class MainForm
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
      Dim resources As New System.ComponentModel.ComponentResourceManager(GetType(MainForm))
      Me._splMain = New System.Windows.Forms.SplitContainer()
      Me._splFormsViewer = New System.Windows.Forms.SplitContainer()
      Me._tvMasterForms = New System.Windows.Forms.TreeView()
      Me._tsForms = New System.Windows.Forms.ToolStrip()
      Me._btnLoadFormSet = New System.Windows.Forms.ToolStripButton()
      Me.toolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
      Me._btnAddMasterMenu = New System.Windows.Forms.ToolStripDropDownButton()
      Me._menuItemAddMasterSet = New System.Windows.Forms.ToolStripMenuItem()
      Me._menuItemAddChildCategory = New System.Windows.Forms.ToolStripMenuItem()
      Me._menuItemAddMaster = New System.Windows.Forms.ToolStripMenuItem()
      Me._menuItemAddMasterPage = New System.Windows.Forms.ToolStripMenuItem()
      Me._menuItemAddMasterPageDisk = New System.Windows.Forms.ToolStripMenuItem()
      Me._menuItemAddMasterPageScanner = New System.Windows.Forms.ToolStripMenuItem()
      Me._btnDeleteMasterMenu = New System.Windows.Forms.ToolStripDropDownButton()
      Me._menuItemDeleteChildCategory = New System.Windows.Forms.ToolStripMenuItem()
      Me._menuItemDeleteMaster = New System.Windows.Forms.ToolStripMenuItem()
      Me._menuItemDeleteMasterPage = New System.Windows.Forms.ToolStripMenuItem()
      Me._btnSaveMasterFormsAs = New System.Windows.Forms.ToolStripButton()
      Me._btnMasterFormProps = New System.Windows.Forms.ToolStripButton()
      Me.toolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
      Me._useFullTextSearchButton = New System.Windows.Forms.ToolStripButton()
      Me._tsFields = New System.Windows.Forms.ToolStrip()
      Me._btnCutField = New System.Windows.Forms.ToolStripButton()
      Me._btnCopyField = New System.Windows.Forms.ToolStripButton()
      Me._btnPasteField = New System.Windows.Forms.ToolStripButton()
      Me._btnDeleteField = New System.Windows.Forms.ToolStripButton()
      Me._lblMasterFormFields = New System.Windows.Forms.Label()
      Me._btnApply = New System.Windows.Forms.Button()
      Me._tcFieldProps = New System.Windows.Forms.TabControl()
      Me._tpFieldInfo = New System.Windows.Forms.TabPage()
      Me._cmbFieldType = New System.Windows.Forms.ComboBox()
      Me._lblFieldType = New System.Windows.Forms.Label()
      Me._txtFieldName = New System.Windows.Forms.TextBox()
      Me._gbBounds = New System.Windows.Forms.GroupBox()
      Me._txtFieldHeight = New System.Windows.Forms.TextBox()
      Me._txtFieldWidth = New System.Windows.Forms.TextBox()
      Me._lblFieldHeight = New System.Windows.Forms.Label()
      Me._txtFieldTop = New System.Windows.Forms.TextBox()
      Me._lblFieldWidth = New System.Windows.Forms.Label()
      Me._txtFieldLeft = New System.Windows.Forms.TextBox()
      Me._lblFieldTop = New System.Windows.Forms.Label()
      Me._lblFieldLeft = New System.Windows.Forms.Label()
      Me._lblFieldName = New System.Windows.Forms.Label()
      Me._tpOCR = New System.Windows.Forms.TabPage()
      Me._gbDropoutOptions = New System.Windows.Forms.GroupBox()
      Me._chkDropoutCells = New System.Windows.Forms.CheckBox()
      Me._chkDropoutWords = New System.Windows.Forms.CheckBox()
      Me._gbFieldMethod = New System.Windows.Forms.GroupBox()
      Me._chkEnableIcr = New System.Windows.Forms.CheckBox()
      Me._chkEnableOcr = New System.Windows.Forms.CheckBox()
      Me._gbFieldTextType = New System.Windows.Forms.GroupBox()
      Me._rbtextTypeData = New System.Windows.Forms.RadioButton()
      Me._rbtextTypeNum = New System.Windows.Forms.RadioButton()
      Me._rbTextTypeChar = New System.Windows.Forms.RadioButton()
      Me._tpOMR = New System.Windows.Forms.TabPage()
      Me._gbOMRFrame = New System.Windows.Forms.GroupBox()
      Me._rbOMRWithoutFrame = New System.Windows.Forms.RadioButton()
      Me._rbOMRWithFrame = New System.Windows.Forms.RadioButton()
      Me._rbOMRAutoFrame = New System.Windows.Forms.RadioButton()
      Me._gbOMRSensitivity = New System.Windows.Forms.GroupBox()
      Me._rbOMRSensitivityHighest = New System.Windows.Forms.RadioButton()
      Me._rbOMRSensitivityHigh = New System.Windows.Forms.RadioButton()
      Me._rbOMRSensitivityLowest = New System.Windows.Forms.RadioButton()
      Me._rbOMRSensitivityLow = New System.Windows.Forms.RadioButton()
      Me._tpTable = New System.Windows.Forms.TabPage()
      Me._btn_Rules = New System.Windows.Forms.Button()
      Me._btn_ColumnOptions = New System.Windows.Forms.Button()
      Me._gb_ColumnOcr = New System.Windows.Forms.GroupBox()
      Me._rB_ColumnOmr = New System.Windows.Forms.RadioButton()
      Me._rB_ColumnOcr = New System.Windows.Forms.RadioButton()
      Me._btn_RemoveColumn = New System.Windows.Forms.Button()
      Me._btn_AddColumn = New System.Windows.Forms.Button()
      Me._lbColumns = New System.Windows.Forms.ListBox()
      Me._tpSelection = New System.Windows.Forms.TabPage()
      Me._btnRemoveSelection = New System.Windows.Forms.Button()
      Me._cbHideSelectionAnn = New System.Windows.Forms.CheckBox()
      Me.groupBox1 = New System.Windows.Forms.GroupBox()
      Me._tbSelectionHeight = New System.Windows.Forms.TextBox()
      Me._tbSelectionWidth = New System.Windows.Forms.TextBox()
      Me.label1 = New System.Windows.Forms.Label()
      Me._tbSelectionTop = New System.Windows.Forms.TextBox()
      Me.label2 = New System.Windows.Forms.Label()
      Me._tbSelectionLeft = New System.Windows.Forms.TextBox()
      Me.label3 = New System.Windows.Forms.Label()
      Me.label4 = New System.Windows.Forms.Label()
      Me._btnEditSelection = New System.Windows.Forms.Button()
      Me._lbSelection = New System.Windows.Forms.ListBox()
      Me._tpBubble = New System.Windows.Forms.TabPage()
      Me.groupBox2 = New System.Windows.Forms.GroupBox()
      Me._tbBubbleHeight = New System.Windows.Forms.TextBox()
      Me._tbBubbleWidth = New System.Windows.Forms.TextBox()
      Me.label5 = New System.Windows.Forms.Label()
      Me._tbBubbleTop = New System.Windows.Forms.TextBox()
      Me.label6 = New System.Windows.Forms.Label()
      Me._tbBubbleLeft = New System.Windows.Forms.TextBox()
      Me.label7 = New System.Windows.Forms.Label()
      Me.label8 = New System.Windows.Forms.Label()
      Me._btnRemoveBubble = New System.Windows.Forms.Button()
      Me._cbHideBubbleAnn = New System.Windows.Forms.CheckBox()
      Me._btnEditBubble = New System.Windows.Forms.Button()
      Me._lbBubble = New System.Windows.Forms.ListBox()
      Me._tpAnswerArea = New System.Windows.Forms.TabPage()
      Me._lbAnswerArea = New System.Windows.Forms.ListBox()
      Me._btnRemoveAnswerArea = New System.Windows.Forms.Button()
      Me._cbHideAnswerAnn = New System.Windows.Forms.CheckBox()
      Me.groupBox3 = New System.Windows.Forms.GroupBox()
      Me._tbAnswerAreaHeight = New System.Windows.Forms.TextBox()
      Me._tbAnswerAreaWidth = New System.Windows.Forms.TextBox()
      Me.label9 = New System.Windows.Forms.Label()
      Me._tbAnswerAreaTop = New System.Windows.Forms.TextBox()
      Me.label10 = New System.Windows.Forms.Label()
      Me._tbAnswerAreaLeft = New System.Windows.Forms.TextBox()
      Me.label11 = New System.Windows.Forms.Label()
      Me.label12 = New System.Windows.Forms.Label()
      Me._btnEditAnswerArea = New System.Windows.Forms.Button()
      Me._tpOmrDate = New System.Windows.Forms.TabPage()
      Me._lbOmrDate = New System.Windows.Forms.ListBox()
      Me._btnRemoveOmrDate = New System.Windows.Forms.Button()
      Me._cbHideOmrDateAnn = New System.Windows.Forms.CheckBox()
      Me.groupBox4 = New System.Windows.Forms.GroupBox()
      Me._tbOmrDateHeight = New System.Windows.Forms.TextBox()
      Me._tbOmrDateWidth = New System.Windows.Forms.TextBox()
      Me.label13 = New System.Windows.Forms.Label()
      Me._tbOmrDateTop = New System.Windows.Forms.TextBox()
      Me.label14 = New System.Windows.Forms.Label()
      Me._tbOmrDateLeft = New System.Windows.Forms.TextBox()
      Me.label15 = New System.Windows.Forms.Label()
      Me.label16 = New System.Windows.Forms.Label()
      Me._btnEditOmrDate = New System.Windows.Forms.Button()
      Me._lbFields = New System.Windows.Forms.ListBox()
      Me._splViewerList = New System.Windows.Forms.SplitContainer()
      Me._tsViewer = New System.Windows.Forms.ToolStrip()
      Me._btnPointerTool = New System.Windows.Forms.ToolStripButton()
      Me._btnPanTool = New System.Windows.Forms.ToolStripButton()
      Me.toolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator()
      Me._btnTableTool = New System.Windows.Forms.ToolStripButton()
      Me._btnOcrTool = New System.Windows.Forms.ToolStripButton()
      Me._btnUNOcrTool = New System.Windows.Forms.ToolStripButton()
      Me._btnOmrTool = New System.Windows.Forms.ToolStripButton()
      Me._btnOmrHighLevelObjects = New System.Windows.Forms.ToolStripButton()
      Me._btnBarcodeTool = New System.Windows.Forms.ToolStripButton()
      Me._btnImageTool = New System.Windows.Forms.ToolStripButton()
      Me._btnSelectRegion = New System.Windows.Forms.ToolStripButton()
      Me.toolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
      Me._btnShowFields = New System.Windows.Forms.ToolStripButton()
      Me.toolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
      Me._btnZoomNormal = New System.Windows.Forms.ToolStripButton()
      Me._btnFit = New System.Windows.Forms.ToolStripButton()
      Me._btnFitWidth = New System.Windows.Forms.ToolStripButton()
      Me._btnZoomIn = New System.Windows.Forms.ToolStripButton()
      Me._btnZoomOut = New System.Windows.Forms.ToolStripButton()
      Me._btnZoomDrawTool = New System.Windows.Forms.ToolStripButton()
      Me._btnUseDpi = New System.Windows.Forms.ToolStripButton()
      Me.toolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
      Me.menuStrip1 = New System.Windows.Forms.MenuStrip()
      Me._menuItemFile = New System.Windows.Forms.ToolStripMenuItem()
      Me._menuItemFormSets = New System.Windows.Forms.ToolStripMenuItem()
      Me._menuItemLoadFormSet = New System.Windows.Forms.ToolStripMenuItem()
      Me._menuItemAddMasterSetMain = New System.Windows.Forms.ToolStripMenuItem()
      Me._menuItemSaveFormSetAs = New System.Windows.Forms.ToolStripMenuItem()
      Me._menuItemMasterForms = New System.Windows.Forms.ToolStripMenuItem()
      Me._menuItemAddMasterMain = New System.Windows.Forms.ToolStripMenuItem()
      Me._menuItemDeleteMasterMain = New System.Windows.Forms.ToolStripMenuItem()
      Me._menuItemAddMasterPageMain = New System.Windows.Forms.ToolStripMenuItem()
      Me._menuItemAddMasterPageDiskMain = New System.Windows.Forms.ToolStripMenuItem()
      Me._menuItemAddMasterPageScannerMain = New System.Windows.Forms.ToolStripMenuItem()
      Me._menuItemDeleteMasterPageMain = New System.Windows.Forms.ToolStripMenuItem()
      Me._menuItemAddChildCategoryMain = New System.Windows.Forms.ToolStripMenuItem()
      Me._menuItemDeleteChildCategoryMain = New System.Windows.Forms.ToolStripMenuItem()
      Me._menuItemMasterFormPropsMain = New System.Windows.Forms.ToolStripMenuItem()
      Me._menuItemSaveChanges = New System.Windows.Forms.ToolStripMenuItem()
      Me._menuItemUpdateMasterFormsData = New System.Windows.Forms.ToolStripMenuItem()
      Me.toolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
      Me._menuItemLaunchFormsDemo = New System.Windows.Forms.ToolStripMenuItem()
      Me.toolStripMenuItem2 = New System.Windows.Forms.ToolStripSeparator()
      Me._menuItemExit = New System.Windows.Forms.ToolStripMenuItem()
      Me._menuItemOptions = New System.Windows.Forms.ToolStripMenuItem()
      Me._menuItemObjectManagers = New System.Windows.Forms.ToolStripMenuItem()
      Me._menuItemOCRManager = New System.Windows.Forms.ToolStripMenuItem()
      Me._menuItemBarcodeManager = New System.Windows.Forms.ToolStripMenuItem()
      Me._menuItemDefaultManager = New System.Windows.Forms.ToolStripMenuItem()
      Me._menuItemIncludeExcludeRegions = New System.Windows.Forms.ToolStripMenuItem()
      Me.pageTypeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
      Me.normalItem = New System.Windows.Forms.ToolStripMenuItem()
      Me.cardItem = New System.Windows.Forms.ToolStripMenuItem()
      Me.omrItem = New System.Windows.Forms.ToolStripMenuItem()
      Me.omrToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
      Me._miDetectOmrFields = New System.Windows.Forms.ToolStripMenuItem()
      Me._miDeleteOmrFields = New System.Windows.Forms.ToolStripMenuItem()
      Me._miRenameOmr = New System.Windows.Forms.ToolStripMenuItem()
      Me._miSetOmrSensitivity = New System.Windows.Forms.ToolStripMenuItem()
      Me._menuItemEngine = New System.Windows.Forms.ToolStripMenuItem()
      Me._menuItemLanguages = New System.Windows.Forms.ToolStripMenuItem()
      Me._menuItemComponents = New System.Windows.Forms.ToolStripMenuItem()
      Me._menuItemHelp = New System.Windows.Forms.ToolStripMenuItem()
      Me._menuItemInformation = New System.Windows.Forms.ToolStripMenuItem()
      Me._menuItemHowTo = New System.Windows.Forms.ToolStripMenuItem()
      Me._menuItemAbout = New System.Windows.Forms.ToolStripMenuItem()
      Me.test1ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
      Me.test2ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
      Me._cmHighLevelObjects = New System.Windows.Forms.ContextMenuStrip(Me.components)
      Me._miSingleSelectionField = New System.Windows.Forms.ToolStripMenuItem()
      Me._miBubbleWordField = New System.Windows.Forms.ToolStripMenuItem()
      Me._miAnswerAreaField = New System.Windows.Forms.ToolStripMenuItem()
      Me._miOmrDateField = New System.Windows.Forms.ToolStripMenuItem()
      CType(Me._splMain, System.ComponentModel.ISupportInitialize).BeginInit()
      Me._splMain.Panel1.SuspendLayout()
      Me._splMain.Panel2.SuspendLayout()
      Me._splMain.SuspendLayout()
      CType(Me._splFormsViewer, System.ComponentModel.ISupportInitialize).BeginInit()
      Me._splFormsViewer.Panel1.SuspendLayout()
      Me._splFormsViewer.Panel2.SuspendLayout()
      Me._splFormsViewer.SuspendLayout()
      Me._tsForms.SuspendLayout()
      Me._tsFields.SuspendLayout()
      Me._tcFieldProps.SuspendLayout()
      Me._tpFieldInfo.SuspendLayout()
      Me._gbBounds.SuspendLayout()
      Me._tpOCR.SuspendLayout()
      Me._gbDropoutOptions.SuspendLayout()
      Me._gbFieldMethod.SuspendLayout()
      Me._gbFieldTextType.SuspendLayout()
      Me._tpOMR.SuspendLayout()
      Me._gbOMRFrame.SuspendLayout()
      Me._gbOMRSensitivity.SuspendLayout()
      Me._tpTable.SuspendLayout()
      Me._gb_ColumnOcr.SuspendLayout()
      Me._tpSelection.SuspendLayout()
      Me.groupBox1.SuspendLayout()
      Me._tpBubble.SuspendLayout()
      Me.groupBox2.SuspendLayout()
      Me._tpAnswerArea.SuspendLayout()
      Me.groupBox3.SuspendLayout()
      Me._tpOmrDate.SuspendLayout()
      Me.groupBox4.SuspendLayout()
      CType(Me._splViewerList, System.ComponentModel.ISupportInitialize).BeginInit()
      Me._splViewerList.Panel1.SuspendLayout()
      Me._splViewerList.SuspendLayout()
      Me._tsViewer.SuspendLayout()
      Me.menuStrip1.SuspendLayout()
      Me._cmHighLevelObjects.SuspendLayout()
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
      Me._splMain.Panel1.Controls.Add(Me._splFormsViewer)
      Me._splMain.Panel1MinSize = 484
      ' 
      ' _splMain.Panel2
      ' 
      Me._splMain.Panel2.Controls.Add(Me._splViewerList)
      Me._splMain.Size = New System.Drawing.Size(1197, 780)
      Me._splMain.SplitterDistance = 484
      Me._splMain.TabIndex = 3
      ' 
      ' _splFormsViewer
      ' 
      Me._splFormsViewer.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
      Me._splFormsViewer.Dock = System.Windows.Forms.DockStyle.Fill
      Me._splFormsViewer.Location = New System.Drawing.Point(0, 0)
      Me._splFormsViewer.Name = "_splFormsViewer"
      Me._splFormsViewer.Orientation = System.Windows.Forms.Orientation.Horizontal
      ' 
      ' _splFormsViewer.Panel1
      ' 
      Me._splFormsViewer.Panel1.Controls.Add(Me._tvMasterForms)
      Me._splFormsViewer.Panel1.Controls.Add(Me._tsForms)
      ' 
      ' _splFormsViewer.Panel2
      ' 
      Me._splFormsViewer.Panel2.Controls.Add(Me._tsFields)
      Me._splFormsViewer.Panel2.Controls.Add(Me._lblMasterFormFields)
      Me._splFormsViewer.Panel2.Controls.Add(Me._btnApply)
      Me._splFormsViewer.Panel2.Controls.Add(Me._tcFieldProps)
      Me._splFormsViewer.Panel2.Controls.Add(Me._lbFields)
      Me._splFormsViewer.Size = New System.Drawing.Size(484, 780)
      Me._splFormsViewer.SplitterDistance = 471
      Me._splFormsViewer.TabIndex = 0
      ' 
      ' _tvMasterForms
      ' 
      Me._tvMasterForms.Dock = System.Windows.Forms.DockStyle.Fill
      Me._tvMasterForms.Location = New System.Drawing.Point(0, 33)
      Me._tvMasterForms.Name = "_tvMasterForms"
      Me._tvMasterForms.Size = New System.Drawing.Size(480, 434)
      Me._tvMasterForms.TabIndex = 2
      ' 
      ' _tsForms
      ' 
      Me._tsForms.ImageScalingSize = New System.Drawing.Size(20, 20)
      Me._tsForms.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me._btnLoadFormSet, Me.toolStripSeparator1, Me._btnAddMasterMenu, Me._btnDeleteMasterMenu, Me._btnSaveMasterFormsAs, Me._btnMasterFormProps, Me.toolStripSeparator5, Me._useFullTextSearchButton})
      Me._tsForms.Location = New System.Drawing.Point(0, 0)
      Me._tsForms.Name = "_tsForms"
      Me._tsForms.Size = New System.Drawing.Size(480, 33)
      Me._tsForms.TabIndex = 1
      Me._tsForms.Text = "toolStrip1"
      ' 
      ' _btnLoadFormSet
      ' 
      Me._btnLoadFormSet.AutoSize = False
      Me._btnLoadFormSet.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
      Me._btnLoadFormSet.Image = CType(resources.GetObject("_btnLoadFormSet.Image"), System.Drawing.Image)
      Me._btnLoadFormSet.ImageTransparentColor = System.Drawing.Color.Magenta
      Me._btnLoadFormSet.Name = "_btnLoadFormSet"
      Me._btnLoadFormSet.Size = New System.Drawing.Size(40, 30)
      Me._btnLoadFormSet.Text = "Load Master Forms"
      ' 
      ' toolStripSeparator1
      ' 
      Me.toolStripSeparator1.Name = "toolStripSeparator1"
      Me.toolStripSeparator1.Size = New System.Drawing.Size(6, 33)
      ' 
      ' _btnAddMasterMenu
      ' 
      Me._btnAddMasterMenu.AutoSize = False
      Me._btnAddMasterMenu.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
      Me._btnAddMasterMenu.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._menuItemAddMasterSet, Me._menuItemAddChildCategory, Me._menuItemAddMaster, Me._menuItemAddMasterPage})
      Me._btnAddMasterMenu.Image = CType(resources.GetObject("_btnAddMasterMenu.Image"), System.Drawing.Image)
      Me._btnAddMasterMenu.ImageTransparentColor = System.Drawing.Color.Magenta
      Me._btnAddMasterMenu.Name = "_btnAddMasterMenu"
      Me._btnAddMasterMenu.Size = New System.Drawing.Size(40, 30)
      Me._btnAddMasterMenu.Text = "Add Master Form"
      ' 
      ' _menuItemAddMasterSet
      ' 
      Me._menuItemAddMasterSet.Name = "_menuItemAddMasterSet"
      Me._menuItemAddMasterSet.Size = New System.Drawing.Size(195, 22)
      Me._menuItemAddMasterSet.Text = "Add Master Form Set"
      ' 
      ' _menuItemAddChildCategory
      ' 
      Me._menuItemAddChildCategory.Name = "_menuItemAddChildCategory"
      Me._menuItemAddChildCategory.Size = New System.Drawing.Size(195, 22)
      Me._menuItemAddChildCategory.Text = "Add Child Category"
      ' 
      ' _menuItemAddMaster
      ' 
      Me._menuItemAddMaster.Name = "_menuItemAddMaster"
      Me._menuItemAddMaster.Size = New System.Drawing.Size(195, 22)
      Me._menuItemAddMaster.Text = "Add Master Form"
      ' 
      ' _menuItemAddMasterPage
      ' 
      Me._menuItemAddMasterPage.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._menuItemAddMasterPageDisk, Me._menuItemAddMasterPageScanner})
      Me._menuItemAddMasterPage.Name = "_menuItemAddMasterPage"
      Me._menuItemAddMasterPage.Size = New System.Drawing.Size(195, 22)
      Me._menuItemAddMasterPage.Text = "Add Master Form Page"
      ' 
      ' _menuItemAddMasterPageDisk
      ' 
      Me._menuItemAddMasterPageDisk.Name = "_menuItemAddMasterPageDisk"
      Me._menuItemAddMasterPageDisk.Size = New System.Drawing.Size(147, 22)
      Me._menuItemAddMasterPageDisk.Text = "From Disk"
      ' 
      ' _menuItemAddMasterPageScanner
      ' 
      Me._menuItemAddMasterPageScanner.Name = "_menuItemAddMasterPageScanner"
      Me._menuItemAddMasterPageScanner.Size = New System.Drawing.Size(147, 22)
      Me._menuItemAddMasterPageScanner.Text = "From Scanner"
      ' 
      ' _btnDeleteMasterMenu
      ' 
      Me._btnDeleteMasterMenu.AutoSize = False
      Me._btnDeleteMasterMenu.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
      Me._btnDeleteMasterMenu.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._menuItemDeleteChildCategory, Me._menuItemDeleteMaster, Me._menuItemDeleteMasterPage})
      Me._btnDeleteMasterMenu.Image = CType(resources.GetObject("_btnDeleteMasterMenu.Image"), System.Drawing.Image)
      Me._btnDeleteMasterMenu.ImageTransparentColor = System.Drawing.Color.Magenta
      Me._btnDeleteMasterMenu.Name = "_btnDeleteMasterMenu"
      Me._btnDeleteMasterMenu.Size = New System.Drawing.Size(40, 30)
      Me._btnDeleteMasterMenu.Text = "Delete Selected Master Form"
      ' 
      ' _menuItemDeleteChildCategory
      ' 
      Me._menuItemDeleteChildCategory.Name = "_menuItemDeleteChildCategory"
      Me._menuItemDeleteChildCategory.Size = New System.Drawing.Size(206, 22)
      Me._menuItemDeleteChildCategory.Text = "Delete Child Category"
      ' 
      ' _menuItemDeleteMaster
      ' 
      Me._menuItemDeleteMaster.Name = "_menuItemDeleteMaster"
      Me._menuItemDeleteMaster.Size = New System.Drawing.Size(206, 22)
      Me._menuItemDeleteMaster.Text = "Delete Master Form"
      ' 
      ' _menuItemDeleteMasterPage
      ' 
      Me._menuItemDeleteMasterPage.Name = "_menuItemDeleteMasterPage"
      Me._menuItemDeleteMasterPage.Size = New System.Drawing.Size(206, 22)
      Me._menuItemDeleteMasterPage.Text = "Delete Master Form Page"
      ' 
      ' _btnSaveMasterFormsAs
      ' 
      Me._btnSaveMasterFormsAs.AutoSize = False
      Me._btnSaveMasterFormsAs.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
      Me._btnSaveMasterFormsAs.Image = CType(resources.GetObject("_btnSaveMasterFormsAs.Image"), System.Drawing.Image)
      Me._btnSaveMasterFormsAs.ImageTransparentColor = System.Drawing.Color.Black
      Me._btnSaveMasterFormsAs.Name = "_btnSaveMasterFormsAs"
      Me._btnSaveMasterFormsAs.Size = New System.Drawing.Size(40, 30)
      Me._btnSaveMasterFormsAs.Text = "Save Master Forms To New Folder"
      ' 
      ' _btnMasterFormProps
      ' 
      Me._btnMasterFormProps.AutoSize = False
      Me._btnMasterFormProps.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
      Me._btnMasterFormProps.Image = CType(resources.GetObject("_btnMasterFormProps.Image"), System.Drawing.Image)
      Me._btnMasterFormProps.ImageTransparentColor = System.Drawing.Color.Magenta
      Me._btnMasterFormProps.Name = "_btnMasterFormProps"
      Me._btnMasterFormProps.Size = New System.Drawing.Size(40, 30)
      Me._btnMasterFormProps.Text = "Selected Master Form Properties"
      ' 
      ' toolStripSeparator5
      ' 
      Me.toolStripSeparator5.Name = "toolStripSeparator5"
      Me.toolStripSeparator5.Size = New System.Drawing.Size(6, 33)
      ' 
      ' _useFullTextSearchButton
      ' 
      Me._useFullTextSearchButton.Checked = True
      Me._useFullTextSearchButton.CheckOnClick = True
      Me._useFullTextSearchButton.CheckState = System.Windows.Forms.CheckState.Checked
      Me._useFullTextSearchButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
      Me._useFullTextSearchButton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
      Me._useFullTextSearchButton.Image = CType(resources.GetObject("_useFullTextSearchButton_checked.Image"), System.Drawing.Image)
      Me._useFullTextSearchButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
      Me._useFullTextSearchButton.Name = "_useFullTextSearchButton"
      Me._useFullTextSearchButton.Size = New System.Drawing.Size(133, 39)
      Me._useFullTextSearchButton.Text = "Use Full Text Search"
      'Me._useFullTextSearchButton.Click += New System.EventHandler(Me._useFullTextSearchButton_Click)
      ' 
      ' _tsFields
      ' 
      Me._tsFields.ImageScalingSize = New System.Drawing.Size(20, 20)
      Me._tsFields.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me._btnCutField, Me._btnCopyField, Me._btnPasteField, Me._btnDeleteField})
      Me._tsFields.Location = New System.Drawing.Point(0, 0)
      Me._tsFields.Name = "_tsFields"
      Me._tsFields.Size = New System.Drawing.Size(480, 33)
      Me._tsFields.TabIndex = 24
      Me._tsFields.Text = "toolStrip1"
      ' 
      ' _btnCutField
      ' 
      Me._btnCutField.AutoSize = False
      Me._btnCutField.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
      Me._btnCutField.Image = CType(resources.GetObject("_btnCutField.Image"), System.Drawing.Image)
      Me._btnCutField.ImageTransparentColor = System.Drawing.Color.Magenta
      Me._btnCutField.Name = "_btnCutField"
      Me._btnCutField.Size = New System.Drawing.Size(40, 30)
      Me._btnCutField.Text = "Cut Field"
      ' 
      ' _btnCopyField
      ' 
      Me._btnCopyField.AutoSize = False
      Me._btnCopyField.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
      Me._btnCopyField.Image = CType(resources.GetObject("_btnCopyField.Image"), System.Drawing.Image)
      Me._btnCopyField.ImageTransparentColor = System.Drawing.Color.Magenta
      Me._btnCopyField.Name = "_btnCopyField"
      Me._btnCopyField.Size = New System.Drawing.Size(40, 30)
      Me._btnCopyField.Text = "Copy Field"
      ' 
      ' _btnPasteField
      ' 
      Me._btnPasteField.AutoSize = False
      Me._btnPasteField.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
      Me._btnPasteField.Image = CType(resources.GetObject("_btnPasteField.Image"), System.Drawing.Image)
      Me._btnPasteField.ImageTransparentColor = System.Drawing.Color.Magenta
      Me._btnPasteField.Name = "_btnPasteField"
      Me._btnPasteField.Size = New System.Drawing.Size(40, 30)
      Me._btnPasteField.Text = "Paste Field"
      ' 
      ' _btnDeleteField
      ' 
      Me._btnDeleteField.AutoSize = False
      Me._btnDeleteField.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
      Me._btnDeleteField.Image = CType(resources.GetObject("_btnDeleteField.Image"), System.Drawing.Image)
      Me._btnDeleteField.ImageTransparentColor = System.Drawing.Color.Magenta
      Me._btnDeleteField.Name = "_btnDeleteField"
      Me._btnDeleteField.Size = New System.Drawing.Size(40, 30)
      Me._btnDeleteField.Text = "Delete Selected Field"
      ' 
      ' _lblMasterFormFields
      ' 
      Me._lblMasterFormFields.AutoSize = True
      Me._lblMasterFormFields.Location = New System.Drawing.Point(7, 52)
      Me._lblMasterFormFields.Name = "_lblMasterFormFields"
      Me._lblMasterFormFields.Size = New System.Drawing.Size(95, 13)
      Me._lblMasterFormFields.TabIndex = 23
      Me._lblMasterFormFields.Text = "Master Form Fields"
      ' 
      ' _btnApply
      ' 
      Me._btnApply.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me._btnApply.Location = New System.Drawing.Point(185, 259)
      Me._btnApply.Name = "_btnApply"
      Me._btnApply.Size = New System.Drawing.Size(278, 27)
      Me._btnApply.TabIndex = 22
      Me._btnApply.Text = "Apply Field Changes"
      Me._btnApply.UseVisualStyleBackColor = True
      ' 
      ' _tcFieldProps
      ' 
      Me._tcFieldProps.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me._tcFieldProps.Controls.Add(Me._tpFieldInfo)
      Me._tcFieldProps.Controls.Add(Me._tpOCR)
      Me._tcFieldProps.Controls.Add(Me._tpOMR)
      Me._tcFieldProps.Controls.Add(Me._tpTable)
      Me._tcFieldProps.Controls.Add(Me._tpSelection)
      Me._tcFieldProps.Controls.Add(Me._tpBubble)
      Me._tcFieldProps.Controls.Add(Me._tpAnswerArea)
      Me._tcFieldProps.Controls.Add(Me._tpOmrDate)
      Me._tcFieldProps.Location = New System.Drawing.Point(185, 50)
      Me._tcFieldProps.Name = "_tcFieldProps"
      Me._tcFieldProps.SelectedIndex = 0
      Me._tcFieldProps.Size = New System.Drawing.Size(282, 203)
      Me._tcFieldProps.TabIndex = 21
      ' 
      ' _tpFieldInfo
      ' 
      Me._tpFieldInfo.Controls.Add(Me._cmbFieldType)
      Me._tpFieldInfo.Controls.Add(Me._lblFieldType)
      Me._tpFieldInfo.Controls.Add(Me._txtFieldName)
      Me._tpFieldInfo.Controls.Add(Me._gbBounds)
      Me._tpFieldInfo.Controls.Add(Me._lblFieldName)
      Me._tpFieldInfo.Location = New System.Drawing.Point(4, 22)
      Me._tpFieldInfo.Name = "_tpFieldInfo"
      Me._tpFieldInfo.Padding = New System.Windows.Forms.Padding(3)
      Me._tpFieldInfo.Size = New System.Drawing.Size(274, 177)
      Me._tpFieldInfo.TabIndex = 0
      Me._tpFieldInfo.Text = "Field Info"
      Me._tpFieldInfo.UseVisualStyleBackColor = True
      ' 
      ' _cmbFieldType
      ' 
      Me._cmbFieldType.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me._cmbFieldType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me._cmbFieldType.FormattingEnabled = True
      Me._cmbFieldType.Items.AddRange(New Object() {"Text", "Omr", "Barcode", "Image", "Table", "UnStructured Text"})
      Me._cmbFieldType.Location = New System.Drawing.Point(55, 39)
      Me._cmbFieldType.Name = "_cmbFieldType"
      Me._cmbFieldType.Size = New System.Drawing.Size(199, 21)
      Me._cmbFieldType.TabIndex = 18
      ' 
      ' _lblFieldType
      ' 
      Me._lblFieldType.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me._lblFieldType.AutoSize = True
      Me._lblFieldType.Location = New System.Drawing.Point(14, 42)
      Me._lblFieldType.Name = "_lblFieldType"
      Me._lblFieldType.Size = New System.Drawing.Size(31, 13)
      Me._lblFieldType.TabIndex = 20
      Me._lblFieldType.Text = "Type"
      ' 
      ' _txtFieldName
      ' 
      Me._txtFieldName.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me._txtFieldName.Location = New System.Drawing.Point(55, 13)
      Me._txtFieldName.Name = "_txtFieldName"
      Me._txtFieldName.Size = New System.Drawing.Size(199, 20)
      Me._txtFieldName.TabIndex = 17
      ' 
      ' _gbBounds
      ' 
      Me._gbBounds.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me._gbBounds.Controls.Add(Me._txtFieldHeight)
      Me._gbBounds.Controls.Add(Me._txtFieldWidth)
      Me._gbBounds.Controls.Add(Me._lblFieldHeight)
      Me._gbBounds.Controls.Add(Me._txtFieldTop)
      Me._gbBounds.Controls.Add(Me._lblFieldWidth)
      Me._gbBounds.Controls.Add(Me._txtFieldLeft)
      Me._gbBounds.Controls.Add(Me._lblFieldTop)
      Me._gbBounds.Controls.Add(Me._lblFieldLeft)
      Me._gbBounds.Location = New System.Drawing.Point(17, 73)
      Me._gbBounds.Name = "_gbBounds"
      Me._gbBounds.Size = New System.Drawing.Size(237, 66)
      Me._gbBounds.TabIndex = 17
      Me._gbBounds.TabStop = False
      Me._gbBounds.Text = "Bounds"
      ' 
      ' _txtFieldHeight
      ' 
      Me._txtFieldHeight.Location = New System.Drawing.Point(170, 38)
      Me._txtFieldHeight.Name = "_txtFieldHeight"
      Me._txtFieldHeight.[ReadOnly] = True
      Me._txtFieldHeight.Size = New System.Drawing.Size(53, 20)
      Me._txtFieldHeight.TabIndex = 5
      ' 
      ' _txtFieldWidth
      ' 
      Me._txtFieldWidth.Location = New System.Drawing.Point(170, 13)
      Me._txtFieldWidth.Name = "_txtFieldWidth"
      Me._txtFieldWidth.[ReadOnly] = True
      Me._txtFieldWidth.Size = New System.Drawing.Size(53, 20)
      Me._txtFieldWidth.TabIndex = 3
      ' 
      ' _lblFieldHeight
      ' 
      Me._lblFieldHeight.AutoSize = True
      Me._lblFieldHeight.Location = New System.Drawing.Point(129, 41)
      Me._lblFieldHeight.Name = "_lblFieldHeight"
      Me._lblFieldHeight.Size = New System.Drawing.Size(38, 13)
      Me._lblFieldHeight.TabIndex = 12
      Me._lblFieldHeight.Text = "Height"
      ' 
      ' _txtFieldTop
      ' 
      Me._txtFieldTop.Location = New System.Drawing.Point(48, 38)
      Me._txtFieldTop.Name = "_txtFieldTop"
      Me._txtFieldTop.[ReadOnly] = True
      Me._txtFieldTop.Size = New System.Drawing.Size(53, 20)
      Me._txtFieldTop.TabIndex = 4
      ' 
      ' _lblFieldWidth
      ' 
      Me._lblFieldWidth.AutoSize = True
      Me._lblFieldWidth.Location = New System.Drawing.Point(129, 16)
      Me._lblFieldWidth.Name = "_lblFieldWidth"
      Me._lblFieldWidth.Size = New System.Drawing.Size(35, 13)
      Me._lblFieldWidth.TabIndex = 10
      Me._lblFieldWidth.Text = "Width"
      ' 
      ' _txtFieldLeft
      ' 
      Me._txtFieldLeft.Location = New System.Drawing.Point(48, 13)
      Me._txtFieldLeft.Name = "_txtFieldLeft"
      Me._txtFieldLeft.[ReadOnly] = True
      Me._txtFieldLeft.Size = New System.Drawing.Size(53, 20)
      Me._txtFieldLeft.TabIndex = 2
      ' 
      ' _lblFieldTop
      ' 
      Me._lblFieldTop.AutoSize = True
      Me._lblFieldTop.Location = New System.Drawing.Point(7, 41)
      Me._lblFieldTop.Name = "_lblFieldTop"
      Me._lblFieldTop.Size = New System.Drawing.Size(26, 13)
      Me._lblFieldTop.TabIndex = 8
      Me._lblFieldTop.Text = "Top"
      ' 
      ' _lblFieldLeft
      ' 
      Me._lblFieldLeft.AutoSize = True
      Me._lblFieldLeft.Location = New System.Drawing.Point(7, 16)
      Me._lblFieldLeft.Name = "_lblFieldLeft"
      Me._lblFieldLeft.Size = New System.Drawing.Size(25, 13)
      Me._lblFieldLeft.TabIndex = 7
      Me._lblFieldLeft.Text = "Left"
      ' 
      ' _lblFieldName
      ' 
      Me._lblFieldName.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me._lblFieldName.AutoSize = True
      Me._lblFieldName.Location = New System.Drawing.Point(14, 16)
      Me._lblFieldName.Name = "_lblFieldName"
      Me._lblFieldName.Size = New System.Drawing.Size(35, 13)
      Me._lblFieldName.TabIndex = 19
      Me._lblFieldName.Text = "Name"
      ' 
      ' _tpOCR
      ' 
      Me._tpOCR.Controls.Add(Me._gbDropoutOptions)
      Me._tpOCR.Controls.Add(Me._gbFieldMethod)
      Me._tpOCR.Controls.Add(Me._gbFieldTextType)
      Me._tpOCR.Location = New System.Drawing.Point(4, 22)
      Me._tpOCR.Name = "_tpOCR"
      Me._tpOCR.Padding = New System.Windows.Forms.Padding(3)
      Me._tpOCR.Size = New System.Drawing.Size(274, 177)
      Me._tpOCR.TabIndex = 1
      Me._tpOCR.Text = "OCR"
      Me._tpOCR.UseVisualStyleBackColor = True
      ' 
      ' _gbDropoutOptions
      ' 
      Me._gbDropoutOptions.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me._gbDropoutOptions.Controls.Add(Me._chkDropoutCells)
      Me._gbDropoutOptions.Controls.Add(Me._chkDropoutWords)
      Me._gbDropoutOptions.Location = New System.Drawing.Point(8, 120)
      Me._gbDropoutOptions.Name = "_gbDropoutOptions"
      Me._gbDropoutOptions.Size = New System.Drawing.Size(260, 51)
      Me._gbDropoutOptions.TabIndex = 26
      Me._gbDropoutOptions.TabStop = False
      Me._gbDropoutOptions.Text = "Dropout"
      ' 
      ' _chkDropoutCells
      ' 
      Me._chkDropoutCells.AutoSize = True
      Me._chkDropoutCells.Location = New System.Drawing.Point(102, 19)
      Me._chkDropoutCells.Name = "_chkDropoutCells"
      Me._chkDropoutCells.Size = New System.Drawing.Size(87, 17)
      Me._chkDropoutCells.TabIndex = 8
      Me._chkDropoutCells.Text = "Cells Borders"
      Me._chkDropoutCells.UseVisualStyleBackColor = True
      ' 
      ' _chkDropoutWords
      ' 
      Me._chkDropoutWords.AutoSize = True
      Me._chkDropoutWords.Location = New System.Drawing.Point(10, 19)
      Me._chkDropoutWords.Name = "_chkDropoutWords"
      Me._chkDropoutWords.Size = New System.Drawing.Size(57, 17)
      Me._chkDropoutWords.TabIndex = 7
      Me._chkDropoutWords.Text = "Words"
      Me._chkDropoutWords.UseVisualStyleBackColor = True
      ' 
      ' _gbFieldMethod
      ' 
      Me._gbFieldMethod.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me._gbFieldMethod.Controls.Add(Me._chkEnableIcr)
      Me._gbFieldMethod.Controls.Add(Me._chkEnableOcr)
      Me._gbFieldMethod.Location = New System.Drawing.Point(154, 12)
      Me._gbFieldMethod.Name = "_gbFieldMethod"
      Me._gbFieldMethod.Size = New System.Drawing.Size(101, 74)
      Me._gbFieldMethod.TabIndex = 13
      Me._gbFieldMethod.TabStop = False
      Me._gbFieldMethod.Text = "Method"
      ' 
      ' _chkEnableIcr
      ' 
      Me._chkEnableIcr.AutoSize = True
      Me._chkEnableIcr.Location = New System.Drawing.Point(10, 42)
      Me._chkEnableIcr.Name = "_chkEnableIcr"
      Me._chkEnableIcr.Size = New System.Drawing.Size(80, 17)
      Me._chkEnableIcr.TabIndex = 7
      Me._chkEnableIcr.Text = "Enable ICR"
      Me._chkEnableIcr.TextAlign = System.Drawing.ContentAlignment.TopLeft
      Me._chkEnableIcr.UseVisualStyleBackColor = True
      ' 
      ' _chkEnableOcr
      ' 
      Me._chkEnableOcr.AutoSize = True
      Me._chkEnableOcr.Location = New System.Drawing.Point(10, 19)
      Me._chkEnableOcr.Name = "_chkEnableOcr"
      Me._chkEnableOcr.Size = New System.Drawing.Size(85, 17)
      Me._chkEnableOcr.TabIndex = 6
      Me._chkEnableOcr.Text = "Enable OCR"
      Me._chkEnableOcr.UseVisualStyleBackColor = True
      ' 
      ' _gbFieldTextType
      ' 
      Me._gbFieldTextType.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me._gbFieldTextType.Controls.Add(Me._rbtextTypeData)
      Me._gbFieldTextType.Controls.Add(Me._rbtextTypeNum)
      Me._gbFieldTextType.Controls.Add(Me._rbTextTypeChar)
      Me._gbFieldTextType.Location = New System.Drawing.Point(12, 11)
      Me._gbFieldTextType.Name = "_gbFieldTextType"
      Me._gbFieldTextType.Size = New System.Drawing.Size(101, 103)
      Me._gbFieldTextType.TabIndex = 14
      Me._gbFieldTextType.TabStop = False
      Me._gbFieldTextType.Text = "Text Type"
      ' 
      ' _rbtextTypeData
      ' 
      Me._rbtextTypeData.AutoSize = True
      Me._rbtextTypeData.Location = New System.Drawing.Point(10, 71)
      Me._rbtextTypeData.Name = "_rbtextTypeData"
      Me._rbtextTypeData.Size = New System.Drawing.Size(48, 17)
      Me._rbtextTypeData.TabIndex = 10
      Me._rbtextTypeData.Text = "Data"
      Me._rbtextTypeData.UseVisualStyleBackColor = True
      ' 
      ' _rbtextTypeNum
      ' 
      Me._rbtextTypeNum.AutoSize = True
      Me._rbtextTypeNum.Location = New System.Drawing.Point(10, 45)
      Me._rbtextTypeNum.Name = "_rbtextTypeNum"
      Me._rbtextTypeNum.Size = New System.Drawing.Size(72, 17)
      Me._rbtextTypeNum.TabIndex = 9
      Me._rbtextTypeNum.Text = "Numerical"
      Me._rbtextTypeNum.UseVisualStyleBackColor = True
      ' 
      ' _rbTextTypeChar
      ' 
      Me._rbTextTypeChar.AutoSize = True
      Me._rbTextTypeChar.Location = New System.Drawing.Point(10, 19)
      Me._rbTextTypeChar.Name = "_rbTextTypeChar"
      Me._rbTextTypeChar.Size = New System.Drawing.Size(71, 17)
      Me._rbTextTypeChar.TabIndex = 8
      Me._rbTextTypeChar.Text = "Character"
      Me._rbTextTypeChar.UseVisualStyleBackColor = True
      ' 
      ' _tpOMR
      ' 
      Me._tpOMR.Controls.Add(Me._gbOMRFrame)
      Me._tpOMR.Controls.Add(Me._gbOMRSensitivity)
      Me._tpOMR.Location = New System.Drawing.Point(4, 22)
      Me._tpOMR.Name = "_tpOMR"
      Me._tpOMR.Padding = New System.Windows.Forms.Padding(3)
      Me._tpOMR.Size = New System.Drawing.Size(274, 177)
      Me._tpOMR.TabIndex = 2
      Me._tpOMR.Text = "OMR"
      Me._tpOMR.UseVisualStyleBackColor = True
      ' 
      ' _gbOMRFrame
      ' 
      Me._gbOMRFrame.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me._gbOMRFrame.Controls.Add(Me._rbOMRWithoutFrame)
      Me._gbOMRFrame.Controls.Add(Me._rbOMRWithFrame)
      Me._gbOMRFrame.Controls.Add(Me._rbOMRAutoFrame)
      Me._gbOMRFrame.Location = New System.Drawing.Point(145, 13)
      Me._gbOMRFrame.Name = "_gbOMRFrame"
      Me._gbOMRFrame.Size = New System.Drawing.Size(113, 94)
      Me._gbOMRFrame.TabIndex = 15
      Me._gbOMRFrame.TabStop = False
      Me._gbOMRFrame.Text = "Frame"
      ' 
      ' _rbOMRWithoutFrame
      ' 
      Me._rbOMRWithoutFrame.AutoSize = True
      Me._rbOMRWithoutFrame.Location = New System.Drawing.Point(10, 71)
      Me._rbOMRWithoutFrame.Name = "_rbOMRWithoutFrame"
      Me._rbOMRWithoutFrame.Size = New System.Drawing.Size(94, 17)
      Me._rbOMRWithoutFrame.TabIndex = 13
      Me._rbOMRWithoutFrame.TabStop = True
      Me._rbOMRWithoutFrame.Text = "Without Frame"
      Me._rbOMRWithoutFrame.UseVisualStyleBackColor = True
      ' 
      ' _rbOMRWithFrame
      ' 
      Me._rbOMRWithFrame.AutoSize = True
      Me._rbOMRWithFrame.Location = New System.Drawing.Point(10, 45)
      Me._rbOMRWithFrame.Name = "_rbOMRWithFrame"
      Me._rbOMRWithFrame.Size = New System.Drawing.Size(79, 17)
      Me._rbOMRWithFrame.TabIndex = 12
      Me._rbOMRWithFrame.TabStop = True
      Me._rbOMRWithFrame.Text = "With Frame"
      Me._rbOMRWithFrame.UseVisualStyleBackColor = True
      ' 
      ' _rbOMRAutoFrame
      ' 
      Me._rbOMRAutoFrame.AutoSize = True
      Me._rbOMRAutoFrame.Location = New System.Drawing.Point(10, 19)
      Me._rbOMRAutoFrame.Name = "_rbOMRAutoFrame"
      Me._rbOMRAutoFrame.Size = New System.Drawing.Size(47, 17)
      Me._rbOMRAutoFrame.TabIndex = 11
      Me._rbOMRAutoFrame.TabStop = True
      Me._rbOMRAutoFrame.Text = "Auto"
      Me._rbOMRAutoFrame.UseVisualStyleBackColor = True
      ' 
      ' _gbOMRSensitivity
      ' 
      Me._gbOMRSensitivity.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me._gbOMRSensitivity.Controls.Add(Me._rbOMRSensitivityHighest)
      Me._gbOMRSensitivity.Controls.Add(Me._rbOMRSensitivityHigh)
      Me._gbOMRSensitivity.Controls.Add(Me._rbOMRSensitivityLowest)
      Me._gbOMRSensitivity.Controls.Add(Me._rbOMRSensitivityLow)
      Me._gbOMRSensitivity.Location = New System.Drawing.Point(15, 13)
      Me._gbOMRSensitivity.Name = "_gbOMRSensitivity"
      Me._gbOMRSensitivity.Size = New System.Drawing.Size(101, 121)
      Me._gbOMRSensitivity.TabIndex = 16
      Me._gbOMRSensitivity.TabStop = False
      Me._gbOMRSensitivity.Text = "Sensitivity"
      ' 
      ' _rbOMRSensitivityHighest
      ' 
      Me._rbOMRSensitivityHighest.AutoSize = True
      Me._rbOMRSensitivityHighest.Location = New System.Drawing.Point(10, 99)
      Me._rbOMRSensitivityHighest.Name = "_rbOMRSensitivityHighest"
      Me._rbOMRSensitivityHighest.Size = New System.Drawing.Size(61, 17)
      Me._rbOMRSensitivityHighest.TabIndex = 11
      Me._rbOMRSensitivityHighest.TabStop = True
      Me._rbOMRSensitivityHighest.Text = "Highest"
      Me._rbOMRSensitivityHighest.UseVisualStyleBackColor = True
      ' 
      ' _rbOMRSensitivityHigh
      ' 
      Me._rbOMRSensitivityHigh.AutoSize = True
      Me._rbOMRSensitivityHigh.Location = New System.Drawing.Point(10, 71)
      Me._rbOMRSensitivityHigh.Name = "_rbOMRSensitivityHigh"
      Me._rbOMRSensitivityHigh.Size = New System.Drawing.Size(47, 17)
      Me._rbOMRSensitivityHigh.TabIndex = 10
      Me._rbOMRSensitivityHigh.TabStop = True
      Me._rbOMRSensitivityHigh.Text = "High"
      Me._rbOMRSensitivityHigh.UseVisualStyleBackColor = True
      ' 
      ' _rbOMRSensitivityLowest
      ' 
      Me._rbOMRSensitivityLowest.AutoSize = True
      Me._rbOMRSensitivityLowest.Location = New System.Drawing.Point(10, 19)
      Me._rbOMRSensitivityLowest.Name = "_rbOMRSensitivityLowest"
      Me._rbOMRSensitivityLowest.Size = New System.Drawing.Size(59, 17)
      Me._rbOMRSensitivityLowest.TabIndex = 9
      Me._rbOMRSensitivityLowest.TabStop = True
      Me._rbOMRSensitivityLowest.Text = "Lowest"
      Me._rbOMRSensitivityLowest.UseVisualStyleBackColor = True
      ' 
      ' _rbOMRSensitivityLow
      ' 
      Me._rbOMRSensitivityLow.AutoSize = True
      Me._rbOMRSensitivityLow.Location = New System.Drawing.Point(10, 45)
      Me._rbOMRSensitivityLow.Name = "_rbOMRSensitivityLow"
      Me._rbOMRSensitivityLow.Size = New System.Drawing.Size(45, 17)
      Me._rbOMRSensitivityLow.TabIndex = 8
      Me._rbOMRSensitivityLow.TabStop = True
      Me._rbOMRSensitivityLow.Text = "Low"
      Me._rbOMRSensitivityLow.UseVisualStyleBackColor = True
      ' 
      ' _tpTable
      ' 
      Me._tpTable.Controls.Add(Me._btn_Rules)
      Me._tpTable.Controls.Add(Me._btn_ColumnOptions)
      Me._tpTable.Controls.Add(Me._gb_ColumnOcr)
      Me._tpTable.Controls.Add(Me._btn_RemoveColumn)
      Me._tpTable.Controls.Add(Me._btn_AddColumn)
      Me._tpTable.Controls.Add(Me._lbColumns)
      Me._tpTable.Location = New System.Drawing.Point(4, 22)
      Me._tpTable.Name = "_tpTable"
      Me._tpTable.Padding = New System.Windows.Forms.Padding(3)
      Me._tpTable.Size = New System.Drawing.Size(274, 177)
      Me._tpTable.TabIndex = 3
      Me._tpTable.Text = "Table"
      Me._tpTable.UseVisualStyleBackColor = True
      ' 
      ' _btn_Rules
      ' 
      Me._btn_Rules.Location = New System.Drawing.Point(131, 116)
      Me._btn_Rules.Name = "_btn_Rules"
      Me._btn_Rules.Size = New System.Drawing.Size(122, 23)
      Me._btn_Rules.TabIndex = 10
      Me._btn_Rules.Text = "Rules"
      Me._btn_Rules.UseVisualStyleBackColor = True
      ' 
      ' _btn_ColumnOptions
      ' 
      Me._btn_ColumnOptions.Location = New System.Drawing.Point(131, 87)
      Me._btn_ColumnOptions.Name = "_btn_ColumnOptions"
      Me._btn_ColumnOptions.Size = New System.Drawing.Size(122, 23)
      Me._btn_ColumnOptions.TabIndex = 9
      Me._btn_ColumnOptions.Text = "Options"
      Me._btn_ColumnOptions.UseVisualStyleBackColor = True
      ' 
      ' _gb_ColumnOcr
      ' 
      Me._gb_ColumnOcr.Controls.Add(Me._rB_ColumnOmr)
      Me._gb_ColumnOcr.Controls.Add(Me._rB_ColumnOcr)
      Me._gb_ColumnOcr.Location = New System.Drawing.Point(129, 6)
      Me._gb_ColumnOcr.Name = "_gb_ColumnOcr"
      Me._gb_ColumnOcr.Size = New System.Drawing.Size(134, 47)
      Me._gb_ColumnOcr.TabIndex = 6
      Me._gb_ColumnOcr.TabStop = False
      Me._gb_ColumnOcr.Text = "Field Type"
      ' 
      ' _rB_ColumnOmr
      ' 
      Me._rB_ColumnOmr.AutoSize = True
      Me._rB_ColumnOmr.Location = New System.Drawing.Point(55, 20)
      Me._rB_ColumnOmr.Name = "_rB_ColumnOmr"
      Me._rB_ColumnOmr.Size = New System.Drawing.Size(44, 17)
      Me._rB_ColumnOmr.TabIndex = 1
      Me._rB_ColumnOmr.Text = "Omr"
      Me._rB_ColumnOmr.UseVisualStyleBackColor = True
      ' 
      ' _rB_ColumnOcr
      ' 
      Me._rB_ColumnOcr.AutoSize = True
      Me._rB_ColumnOcr.Checked = True
      Me._rB_ColumnOcr.Location = New System.Drawing.Point(7, 20)
      Me._rB_ColumnOcr.Name = "_rB_ColumnOcr"
      Me._rB_ColumnOcr.Size = New System.Drawing.Size(42, 17)
      Me._rB_ColumnOcr.TabIndex = 0
      Me._rB_ColumnOcr.TabStop = True
      Me._rB_ColumnOcr.Text = "Ocr"
      Me._rB_ColumnOcr.UseVisualStyleBackColor = True
      ' 
      ' _btn_RemoveColumn
      ' 
      Me._btn_RemoveColumn.Location = New System.Drawing.Point(195, 58)
      Me._btn_RemoveColumn.Name = "_btn_RemoveColumn"
      Me._btn_RemoveColumn.Size = New System.Drawing.Size(58, 23)
      Me._btn_RemoveColumn.TabIndex = 5
      Me._btn_RemoveColumn.Text = "Remove"
      Me._btn_RemoveColumn.UseVisualStyleBackColor = True
      ' 
      ' _btn_AddColumn
      ' 
      Me._btn_AddColumn.Location = New System.Drawing.Point(131, 58)
      Me._btn_AddColumn.Name = "_btn_AddColumn"
      Me._btn_AddColumn.Size = New System.Drawing.Size(58, 23)
      Me._btn_AddColumn.TabIndex = 4
      Me._btn_AddColumn.Text = "Add"
      Me._btn_AddColumn.UseVisualStyleBackColor = True
      ' 
      ' _lbColumns
      ' 
      Me._lbColumns.FormattingEnabled = True
      Me._lbColumns.Location = New System.Drawing.Point(3, 6)
      Me._lbColumns.Name = "_lbColumns"
      Me._lbColumns.Size = New System.Drawing.Size(120, 134)
      Me._lbColumns.TabIndex = 3
      ' 
      ' _tpSelection
      ' 
      Me._tpSelection.Controls.Add(Me._btnRemoveSelection)
      Me._tpSelection.Controls.Add(Me._cbHideSelectionAnn)
      Me._tpSelection.Controls.Add(Me.groupBox1)
      Me._tpSelection.Controls.Add(Me._btnEditSelection)
      Me._tpSelection.Controls.Add(Me._lbSelection)
      Me._tpSelection.Location = New System.Drawing.Point(4, 22)
      Me._tpSelection.Name = "_tpSelection"
      Me._tpSelection.Size = New System.Drawing.Size(274, 177)
      Me._tpSelection.TabIndex = 4
      Me._tpSelection.Text = "Single Selection"
      Me._tpSelection.UseVisualStyleBackColor = True
      ' 
      ' _btnRemoveSelection
      ' 
      Me._btnRemoveSelection.Location = New System.Drawing.Point(159, 35)
      Me._btnRemoveSelection.Name = "_btnRemoveSelection"
      Me._btnRemoveSelection.Size = New System.Drawing.Size(97, 25)
      Me._btnRemoveSelection.TabIndex = 20
      Me._btnRemoveSelection.Text = "Remove"
      Me._btnRemoveSelection.UseVisualStyleBackColor = True
      ' 
      ' _cbHideSelectionAnn
      ' 
      Me._cbHideSelectionAnn.Appearance = System.Windows.Forms.Appearance.Button
      Me._cbHideSelectionAnn.AutoSize = True
      Me._cbHideSelectionAnn.Location = New System.Drawing.Point(159, 86)
      Me._cbHideSelectionAnn.Name = "_cbHideSelectionAnn"
      Me._cbHideSelectionAnn.Size = New System.Drawing.Size(98, 23)
      Me._cbHideSelectionAnn.TabIndex = 19
      Me._cbHideSelectionAnn.Text = "Hide Annotations"
      Me._cbHideSelectionAnn.UseVisualStyleBackColor = True
      ' 
      ' groupBox1
      ' 
      Me.groupBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.groupBox1.Controls.Add(Me._tbSelectionHeight)
      Me.groupBox1.Controls.Add(Me._tbSelectionWidth)
      Me.groupBox1.Controls.Add(Me.label1)
      Me.groupBox1.Controls.Add(Me._tbSelectionTop)
      Me.groupBox1.Controls.Add(Me.label2)
      Me.groupBox1.Controls.Add(Me._tbSelectionLeft)
      Me.groupBox1.Controls.Add(Me.label3)
      Me.groupBox1.Controls.Add(Me.label4)
      Me.groupBox1.Location = New System.Drawing.Point(20, 115)
      Me.groupBox1.Name = "groupBox1"
      Me.groupBox1.Size = New System.Drawing.Size(237, 66)
      Me.groupBox1.TabIndex = 18
      Me.groupBox1.TabStop = False
      Me.groupBox1.Text = "Bounds"
      ' 
      ' _tbSelectionHeight
      ' 
      Me._tbSelectionHeight.Location = New System.Drawing.Point(170, 38)
      Me._tbSelectionHeight.Name = "_tbSelectionHeight"
      Me._tbSelectionHeight.[ReadOnly] = True
      Me._tbSelectionHeight.Size = New System.Drawing.Size(53, 20)
      Me._tbSelectionHeight.TabIndex = 5
      ' 
      ' _tbSelectionWidth
      ' 
      Me._tbSelectionWidth.Location = New System.Drawing.Point(170, 13)
      Me._tbSelectionWidth.Name = "_tbSelectionWidth"
      Me._tbSelectionWidth.[ReadOnly] = True
      Me._tbSelectionWidth.Size = New System.Drawing.Size(53, 20)
      Me._tbSelectionWidth.TabIndex = 3
      ' 
      ' label1
      ' 
      Me.label1.AutoSize = True
      Me.label1.Location = New System.Drawing.Point(129, 41)
      Me.label1.Name = "label1"
      Me.label1.Size = New System.Drawing.Size(38, 13)
      Me.label1.TabIndex = 12
      Me.label1.Text = "Height"
      ' 
      ' _tbSelectionTop
      ' 
      Me._tbSelectionTop.Location = New System.Drawing.Point(48, 38)
      Me._tbSelectionTop.Name = "_tbSelectionTop"
      Me._tbSelectionTop.[ReadOnly] = True
      Me._tbSelectionTop.Size = New System.Drawing.Size(53, 20)
      Me._tbSelectionTop.TabIndex = 4
      ' 
      ' label2
      ' 
      Me.label2.AutoSize = True
      Me.label2.Location = New System.Drawing.Point(129, 16)
      Me.label2.Name = "label2"
      Me.label2.Size = New System.Drawing.Size(35, 13)
      Me.label2.TabIndex = 10
      Me.label2.Text = "Width"
      ' 
      ' _tbSelectionLeft
      ' 
      Me._tbSelectionLeft.Location = New System.Drawing.Point(48, 13)
      Me._tbSelectionLeft.Name = "_tbSelectionLeft"
      Me._tbSelectionLeft.[ReadOnly] = True
      Me._tbSelectionLeft.Size = New System.Drawing.Size(53, 20)
      Me._tbSelectionLeft.TabIndex = 2
      ' 
      ' label3
      ' 
      Me.label3.AutoSize = True
      Me.label3.Location = New System.Drawing.Point(7, 41)
      Me.label3.Name = "label3"
      Me.label3.Size = New System.Drawing.Size(26, 13)
      Me.label3.TabIndex = 8
      Me.label3.Text = "Top"
      ' 
      ' label4
      ' 
      Me.label4.AutoSize = True
      Me.label4.Location = New System.Drawing.Point(7, 16)
      Me.label4.Name = "label4"
      Me.label4.Size = New System.Drawing.Size(25, 13)
      Me.label4.TabIndex = 7
      Me.label4.Text = "Left"
      ' 
      ' _btnEditSelection
      ' 
      Me._btnEditSelection.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
      Me._btnEditSelection.Location = New System.Drawing.Point(159, 6)
      Me._btnEditSelection.Name = "_btnEditSelection"
      Me._btnEditSelection.Size = New System.Drawing.Size(98, 23)
      Me._btnEditSelection.TabIndex = 5
      Me._btnEditSelection.Text = "Edit"
      Me._btnEditSelection.UseVisualStyleBackColor = True
      ' 
      ' _lbSelection
      ' 
      Me._lbSelection.FormattingEnabled = True
      Me._lbSelection.Location = New System.Drawing.Point(3, 6)
      Me._lbSelection.Name = "_lbSelection"
      Me._lbSelection.Size = New System.Drawing.Size(120, 108)
      Me._lbSelection.TabIndex = 4
      ' 
      ' _tpBubble
      ' 
      Me._tpBubble.Controls.Add(Me.groupBox2)
      Me._tpBubble.Controls.Add(Me._btnRemoveBubble)
      Me._tpBubble.Controls.Add(Me._cbHideBubbleAnn)
      Me._tpBubble.Controls.Add(Me._btnEditBubble)
      Me._tpBubble.Controls.Add(Me._lbBubble)
      Me._tpBubble.Location = New System.Drawing.Point(4, 22)
      Me._tpBubble.Name = "_tpBubble"
      Me._tpBubble.Size = New System.Drawing.Size(274, 177)
      Me._tpBubble.TabIndex = 5
      Me._tpBubble.Text = "Bubble Word"
      Me._tpBubble.UseVisualStyleBackColor = True
      ' 
      ' groupBox2
      ' 
      Me.groupBox2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.groupBox2.Controls.Add(Me._tbBubbleHeight)
      Me.groupBox2.Controls.Add(Me._tbBubbleWidth)
      Me.groupBox2.Controls.Add(Me.label5)
      Me.groupBox2.Controls.Add(Me._tbBubbleTop)
      Me.groupBox2.Controls.Add(Me.label6)
      Me.groupBox2.Controls.Add(Me._tbBubbleLeft)
      Me.groupBox2.Controls.Add(Me.label7)
      Me.groupBox2.Controls.Add(Me.label8)
      Me.groupBox2.Location = New System.Drawing.Point(20, 115)
      Me.groupBox2.Name = "groupBox2"
      Me.groupBox2.Size = New System.Drawing.Size(237, 66)
      Me.groupBox2.TabIndex = 25
      Me.groupBox2.TabStop = False
      Me.groupBox2.Text = "Bounds"
      ' 
      ' _tbBubbleHeight
      ' 
      Me._tbBubbleHeight.Location = New System.Drawing.Point(170, 38)
      Me._tbBubbleHeight.Name = "_tbBubbleHeight"
      Me._tbBubbleHeight.[ReadOnly] = True
      Me._tbBubbleHeight.Size = New System.Drawing.Size(53, 20)
      Me._tbBubbleHeight.TabIndex = 5
      ' 
      ' _tbBubbleWidth
      ' 
      Me._tbBubbleWidth.Location = New System.Drawing.Point(170, 13)
      Me._tbBubbleWidth.Name = "_tbBubbleWidth"
      Me._tbBubbleWidth.[ReadOnly] = True
      Me._tbBubbleWidth.Size = New System.Drawing.Size(53, 20)
      Me._tbBubbleWidth.TabIndex = 3
      ' 
      ' label5
      ' 
      Me.label5.AutoSize = True
      Me.label5.Location = New System.Drawing.Point(129, 41)
      Me.label5.Name = "label5"
      Me.label5.Size = New System.Drawing.Size(38, 13)
      Me.label5.TabIndex = 12
      Me.label5.Text = "Height"
      ' 
      ' _tbBubbleTop
      ' 
      Me._tbBubbleTop.Location = New System.Drawing.Point(48, 38)
      Me._tbBubbleTop.Name = "_tbBubbleTop"
      Me._tbBubbleTop.[ReadOnly] = True
      Me._tbBubbleTop.Size = New System.Drawing.Size(53, 20)
      Me._tbBubbleTop.TabIndex = 4
      ' 
      ' label6
      ' 
      Me.label6.AutoSize = True
      Me.label6.Location = New System.Drawing.Point(129, 16)
      Me.label6.Name = "label6"
      Me.label6.Size = New System.Drawing.Size(35, 13)
      Me.label6.TabIndex = 10
      Me.label6.Text = "Width"
      ' 
      ' _tbBubbleLeft
      ' 
      Me._tbBubbleLeft.Location = New System.Drawing.Point(48, 13)
      Me._tbBubbleLeft.Name = "_tbBubbleLeft"
      Me._tbBubbleLeft.[ReadOnly] = True
      Me._tbBubbleLeft.Size = New System.Drawing.Size(53, 20)
      Me._tbBubbleLeft.TabIndex = 2
      ' 
      ' label7
      ' 
      Me.label7.AutoSize = True
      Me.label7.Location = New System.Drawing.Point(7, 41)
      Me.label7.Name = "label7"
      Me.label7.Size = New System.Drawing.Size(26, 13)
      Me.label7.TabIndex = 8
      Me.label7.Text = "Top"
      ' 
      ' label8
      ' 
      Me.label8.AutoSize = True
      Me.label8.Location = New System.Drawing.Point(7, 16)
      Me.label8.Name = "label8"
      Me.label8.Size = New System.Drawing.Size(25, 13)
      Me.label8.TabIndex = 7
      Me.label8.Text = "Left"
      ' 
      ' _btnRemoveBubble
      ' 
      Me._btnRemoveBubble.Location = New System.Drawing.Point(159, 35)
      Me._btnRemoveBubble.Name = "_btnRemoveBubble"
      Me._btnRemoveBubble.Size = New System.Drawing.Size(97, 25)
      Me._btnRemoveBubble.TabIndex = 24
      Me._btnRemoveBubble.Text = "Remove"
      Me._btnRemoveBubble.UseVisualStyleBackColor = True
      ' 
      ' _cbHideBubbleAnn
      ' 
      Me._cbHideBubbleAnn.Appearance = System.Windows.Forms.Appearance.Button
      Me._cbHideBubbleAnn.AutoSize = True
      Me._cbHideBubbleAnn.Location = New System.Drawing.Point(159, 86)
      Me._cbHideBubbleAnn.Name = "_cbHideBubbleAnn"
      Me._cbHideBubbleAnn.Size = New System.Drawing.Size(98, 23)
      Me._cbHideBubbleAnn.TabIndex = 23
      Me._cbHideBubbleAnn.Text = "Hide Annotations"
      Me._cbHideBubbleAnn.UseVisualStyleBackColor = True
      ' 
      ' _btnEditBubble
      ' 
      Me._btnEditBubble.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
      Me._btnEditBubble.Location = New System.Drawing.Point(159, 6)
      Me._btnEditBubble.Name = "_btnEditBubble"
      Me._btnEditBubble.Size = New System.Drawing.Size(98, 23)
      Me._btnEditBubble.TabIndex = 22
      Me._btnEditBubble.Text = "Edit"
      Me._btnEditBubble.UseVisualStyleBackColor = True
      ' 
      ' _lbBubble
      ' 
      Me._lbBubble.FormattingEnabled = True
      Me._lbBubble.Location = New System.Drawing.Point(3, 6)
      Me._lbBubble.Name = "_lbBubble"
      Me._lbBubble.Size = New System.Drawing.Size(120, 108)
      Me._lbBubble.TabIndex = 21
      ' 
      ' _tpAnswerArea
      ' 
      Me._tpAnswerArea.Controls.Add(Me._lbAnswerArea)
      Me._tpAnswerArea.Controls.Add(Me._btnRemoveAnswerArea)
      Me._tpAnswerArea.Controls.Add(Me._cbHideAnswerAnn)
      Me._tpAnswerArea.Controls.Add(Me.groupBox3)
      Me._tpAnswerArea.Controls.Add(Me._btnEditAnswerArea)
      Me._tpAnswerArea.Location = New System.Drawing.Point(4, 22)
      Me._tpAnswerArea.Name = "_tpAnswerArea"
      Me._tpAnswerArea.Size = New System.Drawing.Size(274, 177)
      Me._tpAnswerArea.TabIndex = 6
      Me._tpAnswerArea.Text = "Answer Area"
      Me._tpAnswerArea.UseVisualStyleBackColor = True
      ' 
      ' _lbAnswerArea
      ' 
      Me._lbAnswerArea.FormattingEnabled = True
      Me._lbAnswerArea.Location = New System.Drawing.Point(3, 6)
      Me._lbAnswerArea.Name = "_lbAnswerArea"
      Me._lbAnswerArea.Size = New System.Drawing.Size(120, 108)
      Me._lbAnswerArea.TabIndex = 26
      ' 
      ' _btnRemoveAnswerArea
      ' 
      Me._btnRemoveAnswerArea.Location = New System.Drawing.Point(159, 35)
      Me._btnRemoveAnswerArea.Name = "_btnRemoveAnswerArea"
      Me._btnRemoveAnswerArea.Size = New System.Drawing.Size(97, 25)
      Me._btnRemoveAnswerArea.TabIndex = 29
      Me._btnRemoveAnswerArea.Text = "Remove"
      Me._btnRemoveAnswerArea.UseVisualStyleBackColor = True
      ' 
      ' _cbHideAnswerAnn
      ' 
      Me._cbHideAnswerAnn.Appearance = System.Windows.Forms.Appearance.Button
      Me._cbHideAnswerAnn.AutoSize = True
      Me._cbHideAnswerAnn.Location = New System.Drawing.Point(159, 86)
      Me._cbHideAnswerAnn.Name = "_cbHideAnswerAnn"
      Me._cbHideAnswerAnn.Size = New System.Drawing.Size(98, 23)
      Me._cbHideAnswerAnn.TabIndex = 28
      Me._cbHideAnswerAnn.Text = "Hide Annotations"
      Me._cbHideAnswerAnn.UseVisualStyleBackColor = True
      ' 
      ' groupBox3
      ' 
      Me.groupBox3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.groupBox3.Controls.Add(Me._tbAnswerAreaHeight)
      Me.groupBox3.Controls.Add(Me._tbAnswerAreaWidth)
      Me.groupBox3.Controls.Add(Me.label9)
      Me.groupBox3.Controls.Add(Me._tbAnswerAreaTop)
      Me.groupBox3.Controls.Add(Me.label10)
      Me.groupBox3.Controls.Add(Me._tbAnswerAreaLeft)
      Me.groupBox3.Controls.Add(Me.label11)
      Me.groupBox3.Controls.Add(Me.label12)
      Me.groupBox3.Location = New System.Drawing.Point(20, 115)
      Me.groupBox3.Name = "groupBox3"
      Me.groupBox3.Size = New System.Drawing.Size(237, 66)
      Me.groupBox3.TabIndex = 30
      Me.groupBox3.TabStop = False
      Me.groupBox3.Text = "Bounds"

      ' 
      ' _tbAnswerAreaHeight
      ' 
      Me._tbAnswerAreaHeight.Location = New System.Drawing.Point(170, 38)
      Me._tbAnswerAreaHeight.Name = "_tbAnswerAreaHeight"
      Me._tbAnswerAreaHeight.[ReadOnly] = True
      Me._tbAnswerAreaHeight.Size = New System.Drawing.Size(53, 20)
      Me._tbAnswerAreaHeight.TabIndex = 5
      ' 
      ' _tbAnswerAreaWidth
      ' 
      Me._tbAnswerAreaWidth.Location = New System.Drawing.Point(170, 13)
      Me._tbAnswerAreaWidth.Name = "_tbAnswerAreaWidth"
      Me._tbAnswerAreaWidth.[ReadOnly] = True
      Me._tbAnswerAreaWidth.Size = New System.Drawing.Size(53, 20)
      Me._tbAnswerAreaWidth.TabIndex = 3
      ' 
      ' label9
      ' 
      Me.label9.AutoSize = True
      Me.label9.Location = New System.Drawing.Point(129, 41)
      Me.label9.Name = "label9"
      Me.label9.Size = New System.Drawing.Size(38, 13)
      Me.label9.TabIndex = 12
      Me.label9.Text = "Height"
      ' 
      ' _tbAnswerAreaTop
      ' 
      Me._tbAnswerAreaTop.Location = New System.Drawing.Point(48, 38)
      Me._tbAnswerAreaTop.Name = "_tbAnswerAreaTop"
      Me._tbAnswerAreaTop.[ReadOnly] = True
      Me._tbAnswerAreaTop.Size = New System.Drawing.Size(53, 20)
      Me._tbAnswerAreaTop.TabIndex = 4
      ' 
      ' label10
      ' 
      Me.label10.AutoSize = True
      Me.label10.Location = New System.Drawing.Point(129, 16)
      Me.label10.Name = "label10"
      Me.label10.Size = New System.Drawing.Size(35, 13)
      Me.label10.TabIndex = 10
      Me.label10.Text = "Width"
      ' 
      ' _tbAnswerAreaLeft
      ' 
      Me._tbAnswerAreaLeft.Location = New System.Drawing.Point(48, 13)
      Me._tbAnswerAreaLeft.Name = "_tbAnswerAreaLeft"
      Me._tbAnswerAreaLeft.[ReadOnly] = True
      Me._tbAnswerAreaLeft.Size = New System.Drawing.Size(53, 20)
      Me._tbAnswerAreaLeft.TabIndex = 2
      ' 
      ' label11
      ' 
      Me.label11.AutoSize = True
      Me.label11.Location = New System.Drawing.Point(7, 41)
      Me.label11.Name = "label11"
      Me.label11.Size = New System.Drawing.Size(26, 13)
      Me.label11.TabIndex = 8
      Me.label11.Text = "Top"
      ' 
      ' label12
      ' 
      Me.label12.AutoSize = True
      Me.label12.Location = New System.Drawing.Point(7, 16)
      Me.label12.Name = "label12"
      Me.label12.Size = New System.Drawing.Size(25, 13)
      Me.label12.TabIndex = 7
      Me.label12.Text = "Left"
      ' 
      ' _btnEditAnswerArea
      ' 
      Me._btnEditAnswerArea.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
      Me._btnEditAnswerArea.Location = New System.Drawing.Point(159, 6)
      Me._btnEditAnswerArea.Name = "_btnEditAnswerArea"
      Me._btnEditAnswerArea.Size = New System.Drawing.Size(98, 23)
      Me._btnEditAnswerArea.TabIndex = 27
      Me._btnEditAnswerArea.Text = "Edit"
      Me._btnEditAnswerArea.UseVisualStyleBackColor = True
      ' 
      ' _tpOmrDate
      ' 
      Me._tpOmrDate.Controls.Add(Me._lbOmrDate)
      Me._tpOmrDate.Controls.Add(Me._btnRemoveOmrDate)
      Me._tpOmrDate.Controls.Add(Me._cbHideOmrDateAnn)
      Me._tpOmrDate.Controls.Add(Me.groupBox4)
      Me._tpOmrDate.Controls.Add(Me._btnEditOmrDate)
      Me._tpOmrDate.Location = New System.Drawing.Point(4, 22)
      Me._tpOmrDate.Name = "_tpOmrDate"
      Me._tpOmrDate.Padding = New System.Windows.Forms.Padding(3)
      Me._tpOmrDate.Size = New System.Drawing.Size(274, 177)
      Me._tpOmrDate.TabIndex = 7
      Me._tpOmrDate.Text = "Omr Date"
      Me._tpOmrDate.UseVisualStyleBackColor = True
      ' 
      ' _lbOmrDate
      ' 
      Me._lbOmrDate.FormattingEnabled = True
      Me._lbOmrDate.Location = New System.Drawing.Point(3, 6)
      Me._lbOmrDate.Name = "_lbOmrDate"
      Me._lbOmrDate.Size = New System.Drawing.Size(120, 108)
      Me._lbOmrDate.TabIndex = 31
      ' 
      ' _btnRemoveOmrDate
      ' 
      Me._btnRemoveOmrDate.Location = New System.Drawing.Point(159, 35)
      Me._btnRemoveOmrDate.Name = "_btnRemoveOmrDate"
      Me._btnRemoveOmrDate.Size = New System.Drawing.Size(97, 25)
      Me._btnRemoveOmrDate.TabIndex = 34
      Me._btnRemoveOmrDate.Text = "Remove"
      Me._btnRemoveOmrDate.UseVisualStyleBackColor = True
      ' 
      ' _cbHideOmrDateAnn
      ' 
      Me._cbHideOmrDateAnn.Appearance = System.Windows.Forms.Appearance.Button
      Me._cbHideOmrDateAnn.AutoSize = True
      Me._cbHideOmrDateAnn.Location = New System.Drawing.Point(159, 86)
      Me._cbHideOmrDateAnn.Name = "_cbHideOmrDateAnn"
      Me._cbHideOmrDateAnn.Size = New System.Drawing.Size(98, 23)
      Me._cbHideOmrDateAnn.TabIndex = 33
      Me._cbHideOmrDateAnn.Text = "Hide Annotations"
      Me._cbHideOmrDateAnn.UseVisualStyleBackColor = True
      ' 
      ' groupBox4
      ' 
      Me.groupBox4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.groupBox4.Controls.Add(Me._tbOmrDateHeight)
      Me.groupBox4.Controls.Add(Me._tbOmrDateWidth)
      Me.groupBox4.Controls.Add(Me.label13)
      Me.groupBox4.Controls.Add(Me._tbOmrDateTop)
      Me.groupBox4.Controls.Add(Me.label14)
      Me.groupBox4.Controls.Add(Me._tbOmrDateLeft)
      Me.groupBox4.Controls.Add(Me.label15)
      Me.groupBox4.Controls.Add(Me.label16)
      Me.groupBox4.Location = New System.Drawing.Point(20, 115)
      Me.groupBox4.Name = "groupBox4"
      Me.groupBox4.Size = New System.Drawing.Size(237, 66)
      Me.groupBox4.TabIndex = 35
      Me.groupBox4.TabStop = False
      Me.groupBox4.Text = "Bounds"
      ' 
      ' _tbOmrDateHeight
      ' 
      Me._tbOmrDateHeight.Location = New System.Drawing.Point(170, 38)
      Me._tbOmrDateHeight.Name = "_tbOmrDateHeight"
      Me._tbOmrDateHeight.[ReadOnly] = True
      Me._tbOmrDateHeight.Size = New System.Drawing.Size(53, 20)
      Me._tbOmrDateHeight.TabIndex = 5
      ' 
      ' _tbOmrDateWidth
      ' 
      Me._tbOmrDateWidth.Location = New System.Drawing.Point(170, 13)
      Me._tbOmrDateWidth.Name = "_tbOmrDateWidth"
      Me._tbOmrDateWidth.[ReadOnly] = True
      Me._tbOmrDateWidth.Size = New System.Drawing.Size(53, 20)
      Me._tbOmrDateWidth.TabIndex = 3
      ' 
      ' label13
      ' 
      Me.label13.AutoSize = True
      Me.label13.Location = New System.Drawing.Point(129, 41)
      Me.label13.Name = "label13"
      Me.label13.Size = New System.Drawing.Size(38, 13)
      Me.label13.TabIndex = 12
      Me.label13.Text = "Height"
      ' 
      ' _tbOmrDateTop
      ' 
      Me._tbOmrDateTop.Location = New System.Drawing.Point(48, 38)
      Me._tbOmrDateTop.Name = "_tbOmrDateTop"
      Me._tbOmrDateTop.[ReadOnly] = True
      Me._tbOmrDateTop.Size = New System.Drawing.Size(53, 20)
      Me._tbOmrDateTop.TabIndex = 4
      ' 
      ' label14
      ' 
      Me.label14.AutoSize = True
      Me.label14.Location = New System.Drawing.Point(129, 16)
      Me.label14.Name = "label14"
      Me.label14.Size = New System.Drawing.Size(35, 13)
      Me.label14.TabIndex = 10
      Me.label14.Text = "Width"
      ' 
      ' _tbOmrDateLeft
      ' 
      Me._tbOmrDateLeft.Location = New System.Drawing.Point(48, 13)
      Me._tbOmrDateLeft.Name = "_tbOmrDateLeft"
      Me._tbOmrDateLeft.[ReadOnly] = True
      Me._tbOmrDateLeft.Size = New System.Drawing.Size(53, 20)
      Me._tbOmrDateLeft.TabIndex = 2
      ' 
      ' label15
      ' 
      Me.label15.AutoSize = True
      Me.label15.Location = New System.Drawing.Point(7, 41)
      Me.label15.Name = "label15"
      Me.label15.Size = New System.Drawing.Size(26, 13)
      Me.label15.TabIndex = 8
      Me.label15.Text = "Top"
      ' 
      ' label16
      ' 
      Me.label16.AutoSize = True
      Me.label16.Location = New System.Drawing.Point(7, 16)
      Me.label16.Name = "label16"
      Me.label16.Size = New System.Drawing.Size(25, 13)
      Me.label16.TabIndex = 7
      Me.label16.Text = "Left"
      ' 
      ' _btnEditOmrDate
      ' 
      Me._btnEditOmrDate.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
      Me._btnEditOmrDate.Location = New System.Drawing.Point(159, 6)
      Me._btnEditOmrDate.Name = "_btnEditOmrDate"
      Me._btnEditOmrDate.Size = New System.Drawing.Size(98, 23)
      Me._btnEditOmrDate.TabIndex = 32
      Me._btnEditOmrDate.Text = "Edit"
      Me._btnEditOmrDate.UseVisualStyleBackColor = True
      ' 
      ' _lbFields
      ' 
      Me._lbFields.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me._lbFields.FormattingEnabled = True
      Me._lbFields.HorizontalScrollbar = True
      Me._lbFields.Location = New System.Drawing.Point(10, 76)
      Me._lbFields.Name = "_lbFields"
      Me._lbFields.Size = New System.Drawing.Size(139, 199)
      Me._lbFields.Sorted = True
      Me._lbFields.TabIndex = 18
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
      Me._splViewerList.Panel1.Controls.Add(Me._tsViewer)
      Me._splViewerList.Size = New System.Drawing.Size(709, 780)
      Me._splViewerList.SplitterDistance = 589
      Me._splViewerList.TabIndex = 0
      ' 
      ' _tsViewer
      ' 
      Me._tsViewer.ImageScalingSize = New System.Drawing.Size(20, 20)
      Me._tsViewer.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me._btnPointerTool, Me._btnPanTool, Me.toolStripSeparator7, Me._btnTableTool, Me._btnOcrTool, Me._btnUNOcrTool, _
       Me._btnOmrTool, Me._btnOmrHighLevelObjects, Me._btnBarcodeTool, Me._btnImageTool, Me._btnSelectRegion, Me.toolStripSeparator3, _
       Me._btnShowFields, Me.toolStripSeparator4, Me._btnZoomNormal, Me._btnFit, Me._btnFitWidth, Me._btnZoomIn, _
       Me._btnZoomOut, Me._btnZoomDrawTool, Me._btnUseDpi, Me.toolStripSeparator2})
      Me._tsViewer.Location = New System.Drawing.Point(0, 0)
      Me._tsViewer.Name = "_tsViewer"
      Me._tsViewer.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me._tsViewer.Size = New System.Drawing.Size(705, 53)
      Me._tsViewer.TabIndex = 2
      Me._tsViewer.Text = "toolStrip2"
      ' 
      ' _btnPointerTool
      ' 
      Me._btnPointerTool.AutoSize = False
      Me._btnPointerTool.Checked = True
      Me._btnPointerTool.CheckOnClick = True
      Me._btnPointerTool.CheckState = System.Windows.Forms.CheckState.Checked
      Me._btnPointerTool.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
      Me._btnPointerTool.Image = CType(resources.GetObject("_btnPointerTool.Image"), System.Drawing.Image)
      Me._btnPointerTool.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
      Me._btnPointerTool.ImageTransparentColor = System.Drawing.Color.Magenta
      Me._btnPointerTool.Name = "_btnPointerTool"
      Me._btnPointerTool.Size = New System.Drawing.Size(50, 50)
      Me._btnPointerTool.Text = "Pointer"
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
      ' _btnTableTool
      ' 
      Me._btnTableTool.AutoSize = False
      Me._btnTableTool.BackColor = System.Drawing.SystemColors.Control
      Me._btnTableTool.CheckOnClick = True
      Me._btnTableTool.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
      Me._btnTableTool.Image = CType(resources.GetObject("_btnTableTool.Image"), System.Drawing.Image)
      Me._btnTableTool.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
      Me._btnTableTool.ImageTransparentColor = System.Drawing.Color.Magenta
      Me._btnTableTool.Name = "_btnTableTool"
      Me._btnTableTool.Size = New System.Drawing.Size(50, 50)
      Me._btnTableTool.Text = "Table Field"
      ' 
      ' _btnOcrTool
      ' 
      Me._btnOcrTool.AutoSize = False
      Me._btnOcrTool.CheckOnClick = True
      Me._btnOcrTool.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
      Me._btnOcrTool.Image = CType(resources.GetObject("_btnOcrTool.Image"), System.Drawing.Image)
      Me._btnOcrTool.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
      Me._btnOcrTool.ImageTransparentColor = System.Drawing.Color.Magenta
      Me._btnOcrTool.Name = "_btnOcrTool"
      Me._btnOcrTool.Size = New System.Drawing.Size(50, 50)
      Me._btnOcrTool.Text = "Text Field"
      ' 
      ' _btnUNOcrTool
      ' 
      Me._btnUNOcrTool.AutoSize = False
      Me._btnUNOcrTool.CheckOnClick = True
      Me._btnUNOcrTool.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
      Me._btnUNOcrTool.Image = CType(resources.GetObject("_btnUNOcrTool.Image"), System.Drawing.Image)
      Me._btnUNOcrTool.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
      Me._btnUNOcrTool.ImageTransparentColor = System.Drawing.Color.Magenta
      Me._btnUNOcrTool.Name = "_btnUNOcrTool"
      Me._btnUNOcrTool.Size = New System.Drawing.Size(50, 50)
      Me._btnUNOcrTool.Text = "Unstructured Text Field"
      ' 
      ' _btnOmrTool
      ' 
      Me._btnOmrTool.AutoSize = False
      Me._btnOmrTool.CheckOnClick = True
      Me._btnOmrTool.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
      Me._btnOmrTool.Image = CType(resources.GetObject("_btnOmrTool.Image"), System.Drawing.Image)
      Me._btnOmrTool.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
      Me._btnOmrTool.ImageTransparentColor = System.Drawing.Color.Magenta
      Me._btnOmrTool.Name = "_btnOmrTool"
      Me._btnOmrTool.Size = New System.Drawing.Size(50, 50)
      Me._btnOmrTool.Text = "OMR Field"
      ' 
      ' _btnOmrHighLevelObjects
      ' 
      Me._btnOmrHighLevelObjects.AutoSize = False
      Me._btnOmrHighLevelObjects.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
      Me._btnOmrHighLevelObjects.Image = CType(resources.GetObject("_btnOmrHighLevelObjects.Image"), System.Drawing.Image)
      Me._btnOmrHighLevelObjects.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
      Me._btnOmrHighLevelObjects.ImageTransparentColor = System.Drawing.Color.Magenta
      Me._btnOmrHighLevelObjects.Name = "_btnOmrHighLevelObjects"
      Me._btnOmrHighLevelObjects.Size = New System.Drawing.Size(50, 50)
      Me._btnOmrHighLevelObjects.Text = "Omr High Level Objects"
      ' 
      ' _btnBarcodeTool
      ' 
      Me._btnBarcodeTool.AutoSize = False
      Me._btnBarcodeTool.CheckOnClick = True
      Me._btnBarcodeTool.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
      Me._btnBarcodeTool.Image = CType(resources.GetObject("_btnBarcodeTool.Image"), System.Drawing.Image)
      Me._btnBarcodeTool.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
      Me._btnBarcodeTool.ImageTransparentColor = System.Drawing.Color.Magenta
      Me._btnBarcodeTool.Name = "_btnBarcodeTool"
      Me._btnBarcodeTool.Size = New System.Drawing.Size(50, 50)
      Me._btnBarcodeTool.Text = "Barcode Field"
      ' 
      ' _btnImageTool
      ' 
      Me._btnImageTool.AutoSize = False
      Me._btnImageTool.CheckOnClick = True
      Me._btnImageTool.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
      Me._btnImageTool.Image = CType(resources.GetObject("_btnImageTool.Image"), System.Drawing.Image)
      Me._btnImageTool.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
      Me._btnImageTool.ImageTransparentColor = System.Drawing.Color.Magenta
      Me._btnImageTool.Name = "_btnImageTool"
      Me._btnImageTool.Size = New System.Drawing.Size(50, 50)
      Me._btnImageTool.Text = "Image Field"
      ' 
      ' _btnSelectRegion
      ' 
      Me._btnSelectRegion.AutoSize = False
      Me._btnSelectRegion.CheckOnClick = True
      Me._btnSelectRegion.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
      Me._btnSelectRegion.Image = CType(resources.GetObject("_btnSelectRegion.Image"), System.Drawing.Image)
      Me._btnSelectRegion.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
      Me._btnSelectRegion.ImageTransparentColor = System.Drawing.Color.Magenta
      Me._btnSelectRegion.Name = "_btnSelectRegion"
      Me._btnSelectRegion.Size = New System.Drawing.Size(50, 50)
      Me._btnSelectRegion.Text = "Select Region"
      ' 
      ' toolStripSeparator3
      ' 
      Me.toolStripSeparator3.Name = "toolStripSeparator3"
      Me.toolStripSeparator3.Size = New System.Drawing.Size(6, 53)
      ' 
      ' _btnShowFields
      ' 
      Me._btnShowFields.AutoSize = False
      Me._btnShowFields.Checked = True
      Me._btnShowFields.CheckOnClick = True
      Me._btnShowFields.CheckState = System.Windows.Forms.CheckState.Checked
      Me._btnShowFields.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
      Me._btnShowFields.Image = CType(resources.GetObject("_btnShowFields.Image"), System.Drawing.Image)
      Me._btnShowFields.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
      Me._btnShowFields.ImageTransparentColor = System.Drawing.Color.Magenta
      Me._btnShowFields.Name = "_btnShowFields"
      Me._btnShowFields.Size = New System.Drawing.Size(50, 50)
      Me._btnShowFields.Text = "Show/Hide Fields"
      ' 
      ' toolStripSeparator4
      ' 
      Me.toolStripSeparator4.Name = "toolStripSeparator4"
      Me.toolStripSeparator4.Size = New System.Drawing.Size(6, 53)
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
      Me.toolStripSeparator2.Size = New System.Drawing.Size(6, 50)
      ' 
      ' menuStrip1
      ' 
      Me.menuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me._menuItemFile, Me._menuItemOptions, Me._menuItemEngine, Me._menuItemHelp})
      Me.menuStrip1.Location = New System.Drawing.Point(0, 0)
      Me.menuStrip1.Name = "menuStrip1"
      Me.menuStrip1.Size = New System.Drawing.Size(1197, 24)
      Me.menuStrip1.TabIndex = 4
      Me.menuStrip1.Text = "menuStrip1"
      ' 
      ' _menuItemFile
      ' 
      Me._menuItemFile.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._menuItemFormSets, Me._menuItemMasterForms, Me._menuItemSaveChanges, Me._menuItemUpdateMasterFormsData, Me.toolStripMenuItem1, Me._menuItemLaunchFormsDemo, _
       Me.toolStripMenuItem2, Me._menuItemExit})
      Me._menuItemFile.Name = "_menuItemFile"
      Me._menuItemFile.Size = New System.Drawing.Size(37, 20)
      Me._menuItemFile.Text = "File"
      ' 
      ' _menuItemFormSets
      ' 
      Me._menuItemFormSets.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._menuItemLoadFormSet, Me._menuItemAddMasterSetMain, Me._menuItemSaveFormSetAs})
      Me._menuItemFormSets.Name = "_menuItemFormSets"
      Me._menuItemFormSets.Size = New System.Drawing.Size(334, 22)
      Me._menuItemFormSets.Text = "Form Sets"
      ' 
      ' _menuItemLoadFormSet
      ' 
      Me._menuItemLoadFormSet.Name = "_menuItemLoadFormSet"
      Me._menuItemLoadFormSet.Size = New System.Drawing.Size(170, 22)
      Me._menuItemLoadFormSet.Text = "Load Form Set"
      ' 
      ' _menuItemAddMasterSetMain
      ' 
      Me._menuItemAddMasterSetMain.Name = "_menuItemAddMasterSetMain"
      Me._menuItemAddMasterSetMain.Size = New System.Drawing.Size(170, 22)
      Me._menuItemAddMasterSetMain.Text = "Add Form Set"
      ' 
      ' _menuItemSaveFormSetAs
      ' 
      Me._menuItemSaveFormSetAs.Name = "_menuItemSaveFormSetAs"
      Me._menuItemSaveFormSetAs.Size = New System.Drawing.Size(170, 22)
      Me._menuItemSaveFormSetAs.Text = "Save Form Set As.."
      ' 
      ' _menuItemMasterForms
      ' 
      Me._menuItemMasterForms.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._menuItemAddMasterMain, Me._menuItemDeleteMasterMain, Me._menuItemAddMasterPageMain, Me._menuItemDeleteMasterPageMain, Me._menuItemAddChildCategoryMain, Me._menuItemDeleteChildCategoryMain, _
       Me._menuItemMasterFormPropsMain})
      Me._menuItemMasterForms.Name = "_menuItemMasterForms"
      Me._menuItemMasterForms.Size = New System.Drawing.Size(334, 22)
      Me._menuItemMasterForms.Text = "Master Forms"
      ' 
      ' _menuItemAddMasterMain
      ' 
      Me._menuItemAddMasterMain.Name = "_menuItemAddMasterMain"
      Me._menuItemAddMasterMain.Size = New System.Drawing.Size(228, 22)
      Me._menuItemAddMasterMain.Text = "Add Master Form"
      ' 
      ' _menuItemDeleteMasterMain
      ' 
      Me._menuItemDeleteMasterMain.Name = "_menuItemDeleteMasterMain"
      Me._menuItemDeleteMasterMain.Size = New System.Drawing.Size(228, 22)
      Me._menuItemDeleteMasterMain.Text = "Delete Master Form"
      ' 
      ' _menuItemAddMasterPageMain
      ' 
      Me._menuItemAddMasterPageMain.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._menuItemAddMasterPageDiskMain, Me._menuItemAddMasterPageScannerMain})
      Me._menuItemAddMasterPageMain.Name = "_menuItemAddMasterPageMain"
      Me._menuItemAddMasterPageMain.Size = New System.Drawing.Size(228, 22)
      Me._menuItemAddMasterPageMain.Text = "Add Master Form Page"
      ' 
      ' _menuItemAddMasterPageDiskMain
      ' 
      Me._menuItemAddMasterPageDiskMain.Name = "_menuItemAddMasterPageDiskMain"
      Me._menuItemAddMasterPageDiskMain.Size = New System.Drawing.Size(147, 22)
      Me._menuItemAddMasterPageDiskMain.Text = "From Disk"
      ' 
      ' _menuItemAddMasterPageScannerMain
      ' 
      Me._menuItemAddMasterPageScannerMain.Name = "_menuItemAddMasterPageScannerMain"
      Me._menuItemAddMasterPageScannerMain.Size = New System.Drawing.Size(147, 22)
      Me._menuItemAddMasterPageScannerMain.Text = "From Scanner"
      ' 
      ' _menuItemDeleteMasterPageMain
      ' 
      Me._menuItemDeleteMasterPageMain.Name = "_menuItemDeleteMasterPageMain"
      Me._menuItemDeleteMasterPageMain.Size = New System.Drawing.Size(228, 22)
      Me._menuItemDeleteMasterPageMain.Text = "Delete MasterForm Page"
      ' 
      ' _menuItemAddChildCategoryMain
      ' 
      Me._menuItemAddChildCategoryMain.Name = "_menuItemAddChildCategoryMain"
      Me._menuItemAddChildCategoryMain.Size = New System.Drawing.Size(228, 22)
      Me._menuItemAddChildCategoryMain.Text = "Add Master Form Category"
      ' 
      ' _menuItemDeleteChildCategoryMain
      ' 
      Me._menuItemDeleteChildCategoryMain.Name = "_menuItemDeleteChildCategoryMain"
      Me._menuItemDeleteChildCategoryMain.Size = New System.Drawing.Size(228, 22)
      Me._menuItemDeleteChildCategoryMain.Text = "Delete Master Form Category"
      ' 
      ' _menuItemMasterFormPropsMain
      ' 
      Me._menuItemMasterFormPropsMain.Name = "_menuItemMasterFormPropsMain"
      Me._menuItemMasterFormPropsMain.Size = New System.Drawing.Size(228, 22)
      Me._menuItemMasterFormPropsMain.Text = "Master Form Properties"
      ' 
      ' _menuItemSaveChanges
      ' 
      Me._menuItemSaveChanges.Name = "_menuItemSaveChanges"
      Me._menuItemSaveChanges.Size = New System.Drawing.Size(334, 22)
      Me._menuItemSaveChanges.Text = "Save Changes"
      ' 
      ' _menuItemUpdateMasterFormsData
      ' 
      Me._menuItemUpdateMasterFormsData.Name = "_menuItemUpdateMasterFormsData"
      Me._menuItemUpdateMasterFormsData.Size = New System.Drawing.Size(334, 22)
      Me._menuItemUpdateMasterFormsData.Text = "&Update Master Forms Data"
      ' 
      ' toolStripMenuItem1
      ' 
      Me.toolStripMenuItem1.Name = "toolStripMenuItem1"
      Me.toolStripMenuItem1.Size = New System.Drawing.Size(331, 6)
      ' 
      ' _menuItemLaunchFormsDemo
      ' 
      Me._menuItemLaunchFormsDemo.Name = "_menuItemLaunchFormsDemo"
      Me._menuItemLaunchFormsDemo.Size = New System.Drawing.Size(334, 22)
      Me._menuItemLaunchFormsDemo.Text = "Launch Forms Recognition and Processing Demo"
      ' 
      ' toolStripMenuItem2
      ' 
      Me.toolStripMenuItem2.Name = "toolStripMenuItem2"
      Me.toolStripMenuItem2.Size = New System.Drawing.Size(331, 6)
      ' 
      ' _menuItemExit
      ' 
      Me._menuItemExit.Name = "_menuItemExit"
      Me._menuItemExit.Size = New System.Drawing.Size(334, 22)
      Me._menuItemExit.Text = "Exit"
      ' 
      ' _menuItemOptions
      ' 
      Me._menuItemOptions.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._menuItemObjectManagers, Me._menuItemIncludeExcludeRegions, Me.pageTypeToolStripMenuItem, Me.omrToolStripMenuItem})
      Me._menuItemOptions.Name = "_menuItemOptions"
      Me._menuItemOptions.Size = New System.Drawing.Size(61, 20)
      Me._menuItemOptions.Text = "Options"
      ' 
      ' _menuItemObjectManagers
      ' 
      Me._menuItemObjectManagers.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._menuItemOCRManager, Me._menuItemBarcodeManager, Me._menuItemDefaultManager})
      Me._menuItemObjectManagers.Name = "_menuItemObjectManagers"
      Me._menuItemObjectManagers.Size = New System.Drawing.Size(308, 22)
      Me._menuItemObjectManagers.Text = "Object Managers"
      ' 
      ' _menuItemOCRManager
      ' 
      Me._menuItemOCRManager.Checked = True
      Me._menuItemOCRManager.CheckOnClick = True
      Me._menuItemOCRManager.CheckState = System.Windows.Forms.CheckState.Checked
      Me._menuItemOCRManager.Name = "_menuItemOCRManager"
      Me._menuItemOCRManager.Size = New System.Drawing.Size(162, 22)
      Me._menuItemOCRManager.Text = "OCR Manager"
      ' 
      ' _menuItemBarcodeManager
      ' 
      Me._menuItemBarcodeManager.CheckOnClick = True
      Me._menuItemBarcodeManager.Name = "_menuItemBarcodeManager"
      Me._menuItemBarcodeManager.Size = New System.Drawing.Size(162, 22)
      Me._menuItemBarcodeManager.Text = "Barcode Manger"
      ' 
      ' _menuItemDefaultManager
      ' 
      Me._menuItemDefaultManager.CheckOnClick = True
      Me._menuItemDefaultManager.Name = "_menuItemDefaultManager"
      Me._menuItemDefaultManager.Size = New System.Drawing.Size(162, 22)
      Me._menuItemDefaultManager.Text = "Default Manager"
      ' 
      ' _menuItemIncludeExcludeRegions
      ' 
      Me._menuItemIncludeExcludeRegions.Name = "_menuItemIncludeExcludeRegions"
      Me._menuItemIncludeExcludeRegions.Size = New System.Drawing.Size(308, 22)
      Me._menuItemIncludeExcludeRegions.Text = "Select Interest, Include, And Exclude Regions"
      ' 
      ' pageTypeToolStripMenuItem
      ' 
      Me.pageTypeToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.normalItem, Me.cardItem, Me.omrItem})
      Me.pageTypeToolStripMenuItem.Name = "pageTypeToolStripMenuItem"
      Me.pageTypeToolStripMenuItem.Size = New System.Drawing.Size(308, 22)
      Me.pageTypeToolStripMenuItem.Text = "Page Type"
      ' 
      ' normalItem
      ' 
      Me.normalItem.Name = "normalItem"
      Me.normalItem.Size = New System.Drawing.Size(114, 22)
      Me.normalItem.Text = "Normal"
      ' 
      ' cardItem
      ' 
      Me.cardItem.Name = "cardItem"
      Me.cardItem.Size = New System.Drawing.Size(114, 22)
      Me.cardItem.Text = "Card"
      ' 
      ' omrItem
      ' 
      Me.omrItem.Name = "omrItem"
      Me.omrItem.Size = New System.Drawing.Size(114, 22)
      Me.omrItem.Text = "Omr"
      ' 
      ' omrToolStripMenuItem
      ' 
      Me.omrToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._miDetectOmrFields, Me._miDeleteOmrFields, Me._miRenameOmr, Me._miSetOmrSensitivity})
      Me.omrToolStripMenuItem.Name = "omrToolStripMenuItem"
      Me.omrToolStripMenuItem.Size = New System.Drawing.Size(308, 22)
      Me.omrToolStripMenuItem.Text = "Omr"
      ' 
      ' _miDetectOmrFields
      ' 
      Me._miDetectOmrFields.Name = "_miDetectOmrFields"
      Me._miDetectOmrFields.Size = New System.Drawing.Size(233, 22)
      Me._miDetectOmrFields.Text = "Auto Detect Omr Fields..."
      ' 
      ' _miDeleteOmrFields
      ' 
      Me._miDeleteOmrFields.Name = "_miDeleteOmrFields"
      Me._miDeleteOmrFields.Size = New System.Drawing.Size(233, 22)
      Me._miDeleteOmrFields.Text = "Delete Multiple Omr Fields"
      ' 
      ' _miRenameOmr
      ' 
      Me._miRenameOmr.Name = "_miRenameOmr"
      Me._miRenameOmr.Size = New System.Drawing.Size(233, 22)
      Me._miRenameOmr.Text = "Rename Multiple Omr Fields..."
      ' 
      ' _miSetOmrSensitivity
      ' 
      Me._miSetOmrSensitivity.Name = "_miSetOmrSensitivity"
      Me._miSetOmrSensitivity.Size = New System.Drawing.Size(233, 22)
      Me._miSetOmrSensitivity.Text = "Set Omr Fields Sensitivity..."
      ' 
      ' _menuItemEngine
      ' 
      Me._menuItemEngine.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._menuItemLanguages, Me._menuItemComponents})
      Me._menuItemEngine.Name = "_menuItemEngine"
      Me._menuItemEngine.Size = New System.Drawing.Size(55, 20)
      Me._menuItemEngine.Text = "Engine"
      ' 
      ' _menuItemLanguages
      ' 
      Me._menuItemLanguages.Name = "_menuItemLanguages"
      Me._menuItemLanguages.Size = New System.Drawing.Size(143, 22)
      Me._menuItemLanguages.Text = "Languages"
      ' 
      ' _menuItemComponents
      ' 
      Me._menuItemComponents.Name = "_menuItemComponents"
      Me._menuItemComponents.Size = New System.Drawing.Size(143, 22)
      Me._menuItemComponents.Text = "Components"
      ' 
      ' _menuItemHelp
      ' 
      Me._menuItemHelp.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._menuItemInformation, Me._menuItemHowTo, Me._menuItemAbout})
      Me._menuItemHelp.Name = "_menuItemHelp"
      Me._menuItemHelp.Size = New System.Drawing.Size(44, 20)
      Me._menuItemHelp.Text = "Help"
      ' 
      ' _menuItemInformation
      ' 
      Me._menuItemInformation.Name = "_menuItemInformation"
      Me._menuItemInformation.Size = New System.Drawing.Size(205, 22)
      Me._menuItemInformation.Text = "&Update Data Information"
      ' 
      ' _menuItemHowTo
      ' 
      Me._menuItemHowTo.Name = "_menuItemHowTo"
      Me._menuItemHowTo.Size = New System.Drawing.Size(205, 22)
      Me._menuItemHowTo.Text = "How To"
      ' 
      ' _menuItemAbout
      ' 
      Me._menuItemAbout.Name = "_menuItemAbout"
      Me._menuItemAbout.Size = New System.Drawing.Size(205, 22)
      Me._menuItemAbout.Text = "About"
      ' 
      ' test1ToolStripMenuItem
      ' 
      Me.test1ToolStripMenuItem.Name = "test1ToolStripMenuItem"
      Me.test1ToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
      Me.test1ToolStripMenuItem.Text = "test1"
      ' 
      ' test2ToolStripMenuItem
      ' 
      Me.test2ToolStripMenuItem.Name = "test2ToolStripMenuItem"
      Me.test2ToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
      Me.test2ToolStripMenuItem.Text = "test2"
      ' 
      ' _cmHighLevelObjects
      ' 
      Me._cmHighLevelObjects.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me._miSingleSelectionField, Me._miBubbleWordField, Me._miAnswerAreaField, Me._miOmrDateField})
      Me._cmHighLevelObjects.Name = "_cmHighLevelObjects"
      Me._cmHighLevelObjects.Size = New System.Drawing.Size(186, 92)
      ' 
      ' _miSingleSelectionField
      ' 
      Me._miSingleSelectionField.Name = "_miSingleSelectionField"
      Me._miSingleSelectionField.Size = New System.Drawing.Size(185, 22)
      Me._miSingleSelectionField.Text = "&Single Selection Field"
      ' 
      ' _miBubbleWordField
      ' 
      Me._miBubbleWordField.Name = "_miBubbleWordField"
      Me._miBubbleWordField.Size = New System.Drawing.Size(185, 22)
      Me._miBubbleWordField.Text = "&Bubble Word Field"
      ' 
      ' _miAnswerAreaField
      ' 
      Me._miAnswerAreaField.Name = "_miAnswerAreaField"
      Me._miAnswerAreaField.Size = New System.Drawing.Size(185, 22)
      Me._miAnswerAreaField.Text = "&Answer Area Field"
      ' 
      ' _miOmrDateField
      ' 
      Me._miOmrDateField.Name = "_miOmrDateField"
      Me._miOmrDateField.Size = New System.Drawing.Size(185, 22)
      Me._miOmrDateField.Text = "Omr &Date Field"
      ' 
      ' MainForm
      ' 
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(1197, 804)
      Me.Controls.Add(Me._splMain)
      Me.Controls.Add(Me.menuStrip1)
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.MainMenuStrip = Me.menuStrip1
      Me.Name = "MainForm"
      Me.Text = "LEADTOOLS Master Form Editor"
      Me._splMain.Panel1.ResumeLayout(False)
      Me._splMain.Panel2.ResumeLayout(False)
      CType(Me._splMain, System.ComponentModel.ISupportInitialize).EndInit()
      Me._splMain.ResumeLayout(False)
      Me._splFormsViewer.Panel1.ResumeLayout(False)
      Me._splFormsViewer.Panel1.PerformLayout()
      Me._splFormsViewer.Panel2.ResumeLayout(False)
      Me._splFormsViewer.Panel2.PerformLayout()
      CType(Me._splFormsViewer, System.ComponentModel.ISupportInitialize).EndInit()
      Me._splFormsViewer.ResumeLayout(False)
      Me._tsForms.ResumeLayout(False)
      Me._tsForms.PerformLayout()
      Me._tsFields.ResumeLayout(False)
      Me._tsFields.PerformLayout()
      Me._tcFieldProps.ResumeLayout(False)
      Me._tpFieldInfo.ResumeLayout(False)
      Me._tpFieldInfo.PerformLayout()
      Me._gbBounds.ResumeLayout(False)
      Me._gbBounds.PerformLayout()
      Me._tpOCR.ResumeLayout(False)
      Me._gbDropoutOptions.ResumeLayout(False)
      Me._gbDropoutOptions.PerformLayout()
      Me._gbFieldMethod.ResumeLayout(False)
      Me._gbFieldMethod.PerformLayout()
      Me._gbFieldTextType.ResumeLayout(False)
      Me._gbFieldTextType.PerformLayout()
      Me._tpOMR.ResumeLayout(False)
      Me._gbOMRFrame.ResumeLayout(False)
      Me._gbOMRFrame.PerformLayout()
      Me._gbOMRSensitivity.ResumeLayout(False)
      Me._gbOMRSensitivity.PerformLayout()
      Me._tpTable.ResumeLayout(False)
      Me._gb_ColumnOcr.ResumeLayout(False)
      Me._gb_ColumnOcr.PerformLayout()
      Me._tpSelection.ResumeLayout(False)
      Me._tpSelection.PerformLayout()
      Me.groupBox1.ResumeLayout(False)
      Me.groupBox1.PerformLayout()
      Me._tpBubble.ResumeLayout(False)
      Me._tpBubble.PerformLayout()
      Me.groupBox2.ResumeLayout(False)
      Me.groupBox2.PerformLayout()
      Me._tpAnswerArea.ResumeLayout(False)
      Me._tpAnswerArea.PerformLayout()

      Me.groupBox3.ResumeLayout(False)
      Me.groupBox3.PerformLayout()
      Me._tpOmrDate.ResumeLayout(False)
      Me._tpOmrDate.PerformLayout()
      Me.groupBox4.ResumeLayout(False)
      Me.groupBox4.PerformLayout()
      Me._splViewerList.Panel1.ResumeLayout(False)
      Me._splViewerList.Panel1.PerformLayout()
      CType(Me._splViewerList, System.ComponentModel.ISupportInitialize).EndInit()
      Me._splViewerList.ResumeLayout(False)
      Me._tsViewer.ResumeLayout(False)
      Me._tsViewer.PerformLayout()
      Me.menuStrip1.ResumeLayout(False)
      Me.menuStrip1.PerformLayout()
      Me._cmHighLevelObjects.ResumeLayout(False)
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub

#End Region

   Private _splMain As System.Windows.Forms.SplitContainer
   Private _splFormsViewer As System.Windows.Forms.SplitContainer
   Private _splViewerList As System.Windows.Forms.SplitContainer
   Private _tsForms As System.Windows.Forms.ToolStrip
   Private WithEvents _tvMasterForms As System.Windows.Forms.TreeView
   Private _tsViewer As System.Windows.Forms.ToolStrip
   Private _gbBounds As System.Windows.Forms.GroupBox
   Private _txtFieldHeight As System.Windows.Forms.TextBox
   Private _txtFieldWidth As System.Windows.Forms.TextBox
   Private _lblFieldHeight As System.Windows.Forms.Label
   Private _txtFieldTop As System.Windows.Forms.TextBox
   Private _lblFieldWidth As System.Windows.Forms.Label
   Private _txtFieldLeft As System.Windows.Forms.TextBox
   Private _lblFieldTop As System.Windows.Forms.Label
   Private _lblFieldLeft As System.Windows.Forms.Label
   Private _gbFieldTextType As System.Windows.Forms.GroupBox
   Private WithEvents _rbtextTypeNum As System.Windows.Forms.RadioButton
   Private WithEvents _rbTextTypeChar As System.Windows.Forms.RadioButton
   Private _gbFieldMethod As System.Windows.Forms.GroupBox
   Private WithEvents _chkEnableIcr As System.Windows.Forms.CheckBox
   Private WithEvents _chkEnableOcr As System.Windows.Forms.CheckBox
   Private WithEvents _lbFields As System.Windows.Forms.ListBox
   Private WithEvents _btnLoadFormSet As System.Windows.Forms.ToolStripButton
   Private WithEvents _btnSaveMasterFormsAs As System.Windows.Forms.ToolStripButton
   Private _btnAddMasterMenu As System.Windows.Forms.ToolStripDropDownButton
   Private _btnDeleteMasterMenu As System.Windows.Forms.ToolStripDropDownButton
   Private WithEvents _btnPointerTool As System.Windows.Forms.ToolStripButton
   Private WithEvents _btnPanTool As System.Windows.Forms.ToolStripButton
   Private toolStripSeparator7 As System.Windows.Forms.ToolStripSeparator
   Private WithEvents _btnOcrTool As System.Windows.Forms.ToolStripButton
   Private WithEvents _btnUNOcrTool As System.Windows.Forms.ToolStripButton
   Private WithEvents _btnOmrTool As System.Windows.Forms.ToolStripButton
   Private WithEvents _btnBarcodeTool As System.Windows.Forms.ToolStripButton
   Private WithEvents _btnImageTool As System.Windows.Forms.ToolStripButton
   Private toolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
   Private WithEvents _btnShowFields As System.Windows.Forms.ToolStripButton
   Private toolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
   Private WithEvents _btnZoomNormal As System.Windows.Forms.ToolStripButton
   Private WithEvents _btnFit As System.Windows.Forms.ToolStripButton
   Private WithEvents _btnFitWidth As System.Windows.Forms.ToolStripButton
   Private WithEvents _btnZoomIn As System.Windows.Forms.ToolStripButton
   Private WithEvents _btnZoomOut As System.Windows.Forms.ToolStripButton
   Private WithEvents _btnZoomDrawTool As System.Windows.Forms.ToolStripButton
   Private WithEvents _btnUseDpi As System.Windows.Forms.ToolStripButton
   Private menuStrip1 As System.Windows.Forms.MenuStrip
   Private WithEvents _btnCutField As System.Windows.Forms.ToolStripButton
   Private WithEvents _btnCopyField As System.Windows.Forms.ToolStripButton
   Private WithEvents _btnPasteField As System.Windows.Forms.ToolStripButton
   Private WithEvents _btnDeleteField As System.Windows.Forms.ToolStripButton
   Private _tcFieldProps As System.Windows.Forms.TabControl
   Private _tpFieldInfo As System.Windows.Forms.TabPage
   Private _tpOCR As System.Windows.Forms.TabPage
   Private WithEvents _cmbFieldType As System.Windows.Forms.ComboBox
   Private _lblFieldType As System.Windows.Forms.Label
   Private WithEvents _txtFieldName As System.Windows.Forms.TextBox
   Private _lblFieldName As System.Windows.Forms.Label
   Private _tpOMR As System.Windows.Forms.TabPage
   Private _gbOMRFrame As System.Windows.Forms.GroupBox
   Private _gbOMRSensitivity As System.Windows.Forms.GroupBox
   Private WithEvents _rbOMRSensitivityLowest As System.Windows.Forms.RadioButton
   Private WithEvents _rbOMRSensitivityLow As System.Windows.Forms.RadioButton
   Private WithEvents _btnApply As System.Windows.Forms.Button
   Private _menuItemFile As System.Windows.Forms.ToolStripMenuItem
   Private _menuItemFormSets As System.Windows.Forms.ToolStripMenuItem
   Private WithEvents _menuItemLoadFormSet As System.Windows.Forms.ToolStripMenuItem
   Private WithEvents _menuItemAddMasterSetMain As System.Windows.Forms.ToolStripMenuItem
   Private _menuItemMasterForms As System.Windows.Forms.ToolStripMenuItem
   Private WithEvents _menuItemDeleteMasterMain As System.Windows.Forms.ToolStripMenuItem
   Private toolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
   Private WithEvents _menuItemSaveFormSetAs As System.Windows.Forms.ToolStripMenuItem
   Private _menuItemOptions As System.Windows.Forms.ToolStripMenuItem
   Private _menuItemHelp As System.Windows.Forms.ToolStripMenuItem
   Private WithEvents _menuItemHowTo As System.Windows.Forms.ToolStripMenuItem
   Private WithEvents _menuItemAbout As System.Windows.Forms.ToolStripMenuItem
   Private WithEvents _rbOMRSensitivityHigh As System.Windows.Forms.RadioButton
   Private _lblMasterFormFields As System.Windows.Forms.Label
   Private test1ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Private test2ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Private WithEvents _menuItemAddMasterMain As System.Windows.Forms.ToolStripMenuItem
   Private _menuItemAddMasterPageMain As System.Windows.Forms.ToolStripMenuItem
   Private WithEvents _menuItemDeleteMasterPageMain As System.Windows.Forms.ToolStripMenuItem
   Private WithEvents _menuItemAddMaster As System.Windows.Forms.ToolStripMenuItem
   Private WithEvents _menuItemDeleteMaster As System.Windows.Forms.ToolStripMenuItem
   Private _menuItemAddMasterPage As System.Windows.Forms.ToolStripMenuItem
   Private WithEvents _menuItemDeleteMasterPage As System.Windows.Forms.ToolStripMenuItem
   Private WithEvents _menuItemAddChildCategory As System.Windows.Forms.ToolStripMenuItem
   Private WithEvents _menuItemDeleteChildCategory As System.Windows.Forms.ToolStripMenuItem
   Private WithEvents _menuItemAddMasterSet As System.Windows.Forms.ToolStripMenuItem
   Private WithEvents _menuItemAddChildCategoryMain As System.Windows.Forms.ToolStripMenuItem
   Private WithEvents _menuItemDeleteChildCategoryMain As System.Windows.Forms.ToolStripMenuItem
   Private WithEvents _menuItemAddMasterPageDisk As System.Windows.Forms.ToolStripMenuItem
   Private WithEvents _menuItemAddMasterPageScanner As System.Windows.Forms.ToolStripMenuItem
   Private WithEvents _menuItemAddMasterPageDiskMain As System.Windows.Forms.ToolStripMenuItem
   Private WithEvents _menuItemAddMasterPageScannerMain As System.Windows.Forms.ToolStripMenuItem
   Private WithEvents _menuItemExit As System.Windows.Forms.ToolStripMenuItem
   Private _menuItemObjectManagers As System.Windows.Forms.ToolStripMenuItem
   Private WithEvents _menuItemDefaultManager As System.Windows.Forms.ToolStripMenuItem
   Private WithEvents _menuItemOCRManager As System.Windows.Forms.ToolStripMenuItem
   Private WithEvents _menuItemBarcodeManager As System.Windows.Forms.ToolStripMenuItem
   Private WithEvents _menuItemIncludeExcludeRegions As System.Windows.Forms.ToolStripMenuItem
   Private WithEvents _rbOMRWithoutFrame As System.Windows.Forms.RadioButton
   Private WithEvents _rbOMRWithFrame As System.Windows.Forms.RadioButton
   Private WithEvents _rbOMRAutoFrame As System.Windows.Forms.RadioButton
   Private WithEvents _rbOMRSensitivityHighest As System.Windows.Forms.RadioButton
   Private toolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
   Private WithEvents _btnSelectRegion As System.Windows.Forms.ToolStripButton
   Private _tsFields As System.Windows.Forms.ToolStrip
   Private WithEvents _btnMasterFormProps As System.Windows.Forms.ToolStripButton
   Private WithEvents _menuItemMasterFormPropsMain As System.Windows.Forms.ToolStripMenuItem
   Private WithEvents _menuItemLaunchFormsDemo As System.Windows.Forms.ToolStripMenuItem
   Private WithEvents _menuItemLanguages As System.Windows.Forms.ToolStripMenuItem
   Private WithEvents _menuItemComponents As System.Windows.Forms.ToolStripMenuItem
   Private _menuItemEngine As System.Windows.Forms.ToolStripMenuItem
   Private WithEvents _btnTableTool As System.Windows.Forms.ToolStripButton
   Private _tpTable As System.Windows.Forms.TabPage
   Private _gb_ColumnOcr As System.Windows.Forms.GroupBox
   Private WithEvents _btn_RemoveColumn As System.Windows.Forms.Button
   Private WithEvents _btn_AddColumn As System.Windows.Forms.Button
   Private WithEvents _lbColumns As System.Windows.Forms.ListBox
   Private WithEvents _rB_ColumnOmr As System.Windows.Forms.RadioButton
   Private WithEvents _rB_ColumnOcr As System.Windows.Forms.RadioButton
   Private WithEvents _btn_ColumnOptions As System.Windows.Forms.Button
   Private _gbDropoutOptions As System.Windows.Forms.GroupBox
   Private _chkDropoutCells As System.Windows.Forms.CheckBox
   Private _chkDropoutWords As System.Windows.Forms.CheckBox
   Private WithEvents _btn_Rules As System.Windows.Forms.Button
   Private pageTypeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Private WithEvents normalItem As System.Windows.Forms.ToolStripMenuItem
   Private WithEvents cardItem As System.Windows.Forms.ToolStripMenuItem
   Private WithEvents _menuItemSaveChanges As System.Windows.Forms.ToolStripMenuItem
   Private toolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
   Private WithEvents _menuItemUpdateMasterFormsData As System.Windows.Forms.ToolStripMenuItem
   Private toolStripMenuItem2 As System.Windows.Forms.ToolStripSeparator
   Private WithEvents _menuItemInformation As System.Windows.Forms.ToolStripMenuItem
   Private WithEvents _rbtextTypeData As System.Windows.Forms.RadioButton
   Private WithEvents omrItem As System.Windows.Forms.ToolStripMenuItem
   Private _tpSelection As System.Windows.Forms.TabPage
   Private WithEvents _lbSelection As System.Windows.Forms.ListBox
   Private WithEvents _btnRemoveSelection As System.Windows.Forms.Button
   Private WithEvents _cbHideSelectionAnn As System.Windows.Forms.CheckBox
   Private groupBox1 As System.Windows.Forms.GroupBox
   Private _tbSelectionHeight As System.Windows.Forms.TextBox
   Private _tbSelectionWidth As System.Windows.Forms.TextBox
   Private label1 As System.Windows.Forms.Label
   Private _tbSelectionTop As System.Windows.Forms.TextBox
   Private label2 As System.Windows.Forms.Label
   Private _tbSelectionLeft As System.Windows.Forms.TextBox
   Private label3 As System.Windows.Forms.Label
   Private label4 As System.Windows.Forms.Label
   Private WithEvents _btnEditSelection As System.Windows.Forms.Button
   Private WithEvents _btnOmrHighLevelObjects As System.Windows.Forms.ToolStripButton
   Private _tpBubble As System.Windows.Forms.TabPage
   Private groupBox2 As System.Windows.Forms.GroupBox
   Private _tbBubbleHeight As System.Windows.Forms.TextBox
   Private _tbBubbleWidth As System.Windows.Forms.TextBox
   Private label5 As System.Windows.Forms.Label
   Private _tbBubbleTop As System.Windows.Forms.TextBox
   Private label6 As System.Windows.Forms.Label
   Private _tbBubbleLeft As System.Windows.Forms.TextBox
   Private label7 As System.Windows.Forms.Label
   Private label8 As System.Windows.Forms.Label
   Private WithEvents _btnRemoveBubble As System.Windows.Forms.Button
   Private WithEvents _cbHideBubbleAnn As System.Windows.Forms.CheckBox
   Private WithEvents _btnEditBubble As System.Windows.Forms.Button
   Private WithEvents _lbBubble As System.Windows.Forms.ListBox
   Private _tpAnswerArea As System.Windows.Forms.TabPage
   Private WithEvents _lbAnswerArea As System.Windows.Forms.ListBox
   Private WithEvents _btnRemoveAnswerArea As System.Windows.Forms.Button
   Private WithEvents _cbHideAnswerAnn As System.Windows.Forms.CheckBox
   Private groupBox3 As System.Windows.Forms.GroupBox
   Private _tbAnswerAreaHeight As System.Windows.Forms.TextBox
   Private _tbAnswerAreaWidth As System.Windows.Forms.TextBox
   Private label9 As System.Windows.Forms.Label
   Private _tbAnswerAreaTop As System.Windows.Forms.TextBox
   Private label10 As System.Windows.Forms.Label
   Private _tbAnswerAreaLeft As System.Windows.Forms.TextBox
   Private label11 As System.Windows.Forms.Label
   Private label12 As System.Windows.Forms.Label
   Private WithEvents _btnEditAnswerArea As System.Windows.Forms.Button
   Private _tpOmrDate As System.Windows.Forms.TabPage
   Private WithEvents _lbOmrDate As System.Windows.Forms.ListBox
   Private WithEvents _btnRemoveOmrDate As System.Windows.Forms.Button
   Private WithEvents _cbHideOmrDateAnn As System.Windows.Forms.CheckBox
   Private groupBox4 As System.Windows.Forms.GroupBox
   Private _tbOmrDateHeight As System.Windows.Forms.TextBox
   Private _tbOmrDateWidth As System.Windows.Forms.TextBox
   Private label13 As System.Windows.Forms.Label
   Private _tbOmrDateTop As System.Windows.Forms.TextBox
   Private label14 As System.Windows.Forms.Label
   Private _tbOmrDateLeft As System.Windows.Forms.TextBox
   Private label15 As System.Windows.Forms.Label
   Private label16 As System.Windows.Forms.Label
   Private WithEvents _btnEditOmrDate As System.Windows.Forms.Button
   Private omrToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Private WithEvents _miDetectOmrFields As System.Windows.Forms.ToolStripMenuItem
   Private WithEvents _miDeleteOmrFields As System.Windows.Forms.ToolStripMenuItem
   Private WithEvents _miRenameOmr As System.Windows.Forms.ToolStripMenuItem
   Private WithEvents _miSetOmrSensitivity As System.Windows.Forms.ToolStripMenuItem
   Private WithEvents toolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
   Private WithEvents _useFullTextSearchButton As System.Windows.Forms.ToolStripButton
   Private _cmHighLevelObjects As System.Windows.Forms.ContextMenuStrip
   Private WithEvents _miSingleSelectionField As System.Windows.Forms.ToolStripMenuItem
   Private WithEvents _miBubbleWordField As System.Windows.Forms.ToolStripMenuItem
   Private WithEvents _miAnswerAreaField As System.Windows.Forms.ToolStripMenuItem
   Private WithEvents _miOmrDateField As System.Windows.Forms.ToolStripMenuItem

End Class
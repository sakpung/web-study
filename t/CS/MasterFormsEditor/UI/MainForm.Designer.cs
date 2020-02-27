namespace CSMasterFormsEditor
{
   partial class MainForm
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
         this._splMain = new System.Windows.Forms.SplitContainer();
         this._splFormsViewer = new System.Windows.Forms.SplitContainer();
         this._tvMasterForms = new System.Windows.Forms.TreeView();
         this._tsForms = new System.Windows.Forms.ToolStrip();
         this._btnLoadFormSet = new System.Windows.Forms.ToolStripButton();
         this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
         this._btnAddMasterMenu = new System.Windows.Forms.ToolStripDropDownButton();
         this._menuItemAddMasterSet = new System.Windows.Forms.ToolStripMenuItem();
         this._menuItemAddChildCategory = new System.Windows.Forms.ToolStripMenuItem();
         this._menuItemAddMaster = new System.Windows.Forms.ToolStripMenuItem();
         this._menuItemAddMasterPage = new System.Windows.Forms.ToolStripMenuItem();
         this._menuItemAddMasterPageDisk = new System.Windows.Forms.ToolStripMenuItem();
         this._menuItemAddMasterPageScanner = new System.Windows.Forms.ToolStripMenuItem();
         this._btnDeleteMasterMenu = new System.Windows.Forms.ToolStripDropDownButton();
         this._menuItemDeleteChildCategory = new System.Windows.Forms.ToolStripMenuItem();
         this._menuItemDeleteMaster = new System.Windows.Forms.ToolStripMenuItem();
         this._menuItemDeleteMasterPage = new System.Windows.Forms.ToolStripMenuItem();
         this._btnSaveMasterFormsAs = new System.Windows.Forms.ToolStripButton();
         this._btnMasterFormProps = new System.Windows.Forms.ToolStripButton();
         this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
         this._useFullTextSearchButton = new System.Windows.Forms.ToolStripButton();
         this._tsFields = new System.Windows.Forms.ToolStrip();
         this._btnCutField = new System.Windows.Forms.ToolStripButton();
         this._btnCopyField = new System.Windows.Forms.ToolStripButton();
         this._btnPasteField = new System.Windows.Forms.ToolStripButton();
         this._btnDeleteField = new System.Windows.Forms.ToolStripButton();
         this._lblMasterFormFields = new System.Windows.Forms.Label();
         this._btnApply = new System.Windows.Forms.Button();
         this._tcFieldProps = new System.Windows.Forms.TabControl();
         this._tpFieldInfo = new System.Windows.Forms.TabPage();
         this._cmbFieldType = new System.Windows.Forms.ComboBox();
         this._lblFieldType = new System.Windows.Forms.Label();
         this._txtFieldName = new System.Windows.Forms.TextBox();
         this._gbBounds = new System.Windows.Forms.GroupBox();
         this._txtFieldHeight = new System.Windows.Forms.TextBox();
         this._txtFieldWidth = new System.Windows.Forms.TextBox();
         this._lblFieldHeight = new System.Windows.Forms.Label();
         this._txtFieldTop = new System.Windows.Forms.TextBox();
         this._lblFieldWidth = new System.Windows.Forms.Label();
         this._txtFieldLeft = new System.Windows.Forms.TextBox();
         this._lblFieldTop = new System.Windows.Forms.Label();
         this._lblFieldLeft = new System.Windows.Forms.Label();
         this._lblFieldName = new System.Windows.Forms.Label();
         this._tpOCR = new System.Windows.Forms.TabPage();
         this._gbDropoutOptions = new System.Windows.Forms.GroupBox();
         this._chkDropoutCells = new System.Windows.Forms.CheckBox();
         this._chkDropoutWords = new System.Windows.Forms.CheckBox();
         this._gbFieldMethod = new System.Windows.Forms.GroupBox();
         this._chkEnableIcr = new System.Windows.Forms.CheckBox();
         this._chkEnableOcr = new System.Windows.Forms.CheckBox();
         this._gbFieldTextType = new System.Windows.Forms.GroupBox();
         this._rbtextTypeData = new System.Windows.Forms.RadioButton();
         this._rbtextTypeNum = new System.Windows.Forms.RadioButton();
         this._rbTextTypeChar = new System.Windows.Forms.RadioButton();
         this._tpOMR = new System.Windows.Forms.TabPage();
         this._gbOMRFrame = new System.Windows.Forms.GroupBox();
         this._rbOMRWithoutFrame = new System.Windows.Forms.RadioButton();
         this._rbOMRWithFrame = new System.Windows.Forms.RadioButton();
         this._rbOMRAutoFrame = new System.Windows.Forms.RadioButton();
         this._gbOMRSensitivity = new System.Windows.Forms.GroupBox();
         this._rbOMRSensitivityHighest = new System.Windows.Forms.RadioButton();
         this._rbOMRSensitivityHigh = new System.Windows.Forms.RadioButton();
         this._rbOMRSensitivityLowest = new System.Windows.Forms.RadioButton();
         this._rbOMRSensitivityLow = new System.Windows.Forms.RadioButton();
         this._tpTable = new System.Windows.Forms.TabPage();
         this._btn_Rules = new System.Windows.Forms.Button();
         this._btn_ColumnOptions = new System.Windows.Forms.Button();
         this._gb_ColumnOcr = new System.Windows.Forms.GroupBox();
         this._rB_ColumnOmr = new System.Windows.Forms.RadioButton();
         this._rB_ColumnOcr = new System.Windows.Forms.RadioButton();
         this._btn_RemoveColumn = new System.Windows.Forms.Button();
         this._btn_AddColumn = new System.Windows.Forms.Button();
         this._lbColumns = new System.Windows.Forms.ListBox();
         this._tpSelection = new System.Windows.Forms.TabPage();
         this._btnRemoveSelection = new System.Windows.Forms.Button();
         this._cbHideSelectionAnn = new System.Windows.Forms.CheckBox();
         this.groupBox1 = new System.Windows.Forms.GroupBox();
         this._tbSelectionHeight = new System.Windows.Forms.TextBox();
         this._tbSelectionWidth = new System.Windows.Forms.TextBox();
         this.label1 = new System.Windows.Forms.Label();
         this._tbSelectionTop = new System.Windows.Forms.TextBox();
         this.label2 = new System.Windows.Forms.Label();
         this._tbSelectionLeft = new System.Windows.Forms.TextBox();
         this.label3 = new System.Windows.Forms.Label();
         this.label4 = new System.Windows.Forms.Label();
         this._btnEditSelection = new System.Windows.Forms.Button();
         this._lbSelection = new System.Windows.Forms.ListBox();
         this._tpBubble = new System.Windows.Forms.TabPage();
         this.groupBox2 = new System.Windows.Forms.GroupBox();
         this._tbBubbleHeight = new System.Windows.Forms.TextBox();
         this._tbBubbleWidth = new System.Windows.Forms.TextBox();
         this.label5 = new System.Windows.Forms.Label();
         this._tbBubbleTop = new System.Windows.Forms.TextBox();
         this.label6 = new System.Windows.Forms.Label();
         this._tbBubbleLeft = new System.Windows.Forms.TextBox();
         this.label7 = new System.Windows.Forms.Label();
         this.label8 = new System.Windows.Forms.Label();
         this._btnRemoveBubble = new System.Windows.Forms.Button();
         this._cbHideBubbleAnn = new System.Windows.Forms.CheckBox();
         this._btnEditBubble = new System.Windows.Forms.Button();
         this._lbBubble = new System.Windows.Forms.ListBox();
         this._tpAnswerArea = new System.Windows.Forms.TabPage();
         this._lbAnswerArea = new System.Windows.Forms.ListBox();
         this._btnRemoveAnswerArea = new System.Windows.Forms.Button();
         this._cbHideAnswerAnn = new System.Windows.Forms.CheckBox();
         this.groupBox3 = new System.Windows.Forms.GroupBox();
         this._tbAnswerAreaHeight = new System.Windows.Forms.TextBox();
         this._tbAnswerAreaWidth = new System.Windows.Forms.TextBox();
         this.label9 = new System.Windows.Forms.Label();
         this._tbAnswerAreaTop = new System.Windows.Forms.TextBox();
         this.label10 = new System.Windows.Forms.Label();
         this._tbAnswerAreaLeft = new System.Windows.Forms.TextBox();
         this.label11 = new System.Windows.Forms.Label();
         this.label12 = new System.Windows.Forms.Label();
         this._btnEditAnswerArea = new System.Windows.Forms.Button();
         this._tpOmrDate = new System.Windows.Forms.TabPage();
         this._lbOmrDate = new System.Windows.Forms.ListBox();
         this._btnRemoveOmrDate = new System.Windows.Forms.Button();
         this._cbHideOmrDateAnn = new System.Windows.Forms.CheckBox();
         this.groupBox4 = new System.Windows.Forms.GroupBox();
         this._tbOmrDateHeight = new System.Windows.Forms.TextBox();
         this._tbOmrDateWidth = new System.Windows.Forms.TextBox();
         this.label13 = new System.Windows.Forms.Label();
         this._tbOmrDateTop = new System.Windows.Forms.TextBox();
         this.label14 = new System.Windows.Forms.Label();
         this._tbOmrDateLeft = new System.Windows.Forms.TextBox();
         this.label15 = new System.Windows.Forms.Label();
         this.label16 = new System.Windows.Forms.Label();
         this._btnEditOmrDate = new System.Windows.Forms.Button();
         this._lbFields = new System.Windows.Forms.ListBox();
         this._splViewerList = new System.Windows.Forms.SplitContainer();
         this._tsViewer = new System.Windows.Forms.ToolStrip();
         this._btnPointerTool = new System.Windows.Forms.ToolStripButton();
         this._btnPanTool = new System.Windows.Forms.ToolStripButton();
         this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
         this._btnTableTool = new System.Windows.Forms.ToolStripButton();
         this._btnOcrTool = new System.Windows.Forms.ToolStripButton();
         this._btnUNOcrTool = new System.Windows.Forms.ToolStripButton();
         this._btnOmrTool = new System.Windows.Forms.ToolStripButton();
         this._btnOmrHighLevelObjects = new System.Windows.Forms.ToolStripButton();
         this._btnBarcodeTool = new System.Windows.Forms.ToolStripButton();
         this._btnImageTool = new System.Windows.Forms.ToolStripButton();
         this._btnSelectRegion = new System.Windows.Forms.ToolStripButton();
         this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
         this._btnShowFields = new System.Windows.Forms.ToolStripButton();
         this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
         this._btnZoomNormal = new System.Windows.Forms.ToolStripButton();
         this._btnFit = new System.Windows.Forms.ToolStripButton();
         this._btnFitWidth = new System.Windows.Forms.ToolStripButton();
         this._btnZoomIn = new System.Windows.Forms.ToolStripButton();
         this._btnZoomOut = new System.Windows.Forms.ToolStripButton();
         this._btnZoomDrawTool = new System.Windows.Forms.ToolStripButton();
         this._btnUseDpi = new System.Windows.Forms.ToolStripButton();
         this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
         this.menuStrip1 = new System.Windows.Forms.MenuStrip();
         this._menuItemFile = new System.Windows.Forms.ToolStripMenuItem();
         this._menuItemFormSets = new System.Windows.Forms.ToolStripMenuItem();
         this._menuItemLoadFormSet = new System.Windows.Forms.ToolStripMenuItem();
         this._menuItemAddMasterSetMain = new System.Windows.Forms.ToolStripMenuItem();
         this._menuItemSaveFormSetAs = new System.Windows.Forms.ToolStripMenuItem();
         this._menuItemMasterForms = new System.Windows.Forms.ToolStripMenuItem();
         this._menuItemAddMasterMain = new System.Windows.Forms.ToolStripMenuItem();
         this._menuItemDeleteMasterMain = new System.Windows.Forms.ToolStripMenuItem();
         this._menuItemAddMasterPageMain = new System.Windows.Forms.ToolStripMenuItem();
         this._menuItemAddMasterPageDiskMain = new System.Windows.Forms.ToolStripMenuItem();
         this._menuItemAddMasterPageScannerMain = new System.Windows.Forms.ToolStripMenuItem();
         this._menuItemDeleteMasterPageMain = new System.Windows.Forms.ToolStripMenuItem();
         this._menuItemAddChildCategoryMain = new System.Windows.Forms.ToolStripMenuItem();
         this._menuItemDeleteChildCategoryMain = new System.Windows.Forms.ToolStripMenuItem();
         this._menuItemMasterFormPropsMain = new System.Windows.Forms.ToolStripMenuItem();
         this._menuItemSaveChanges = new System.Windows.Forms.ToolStripMenuItem();
         this._menuItemUpdateMasterFormsData = new System.Windows.Forms.ToolStripMenuItem();
         this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
         this._menuItemLaunchFormsDemo = new System.Windows.Forms.ToolStripMenuItem();
         this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
         this._menuItemExit = new System.Windows.Forms.ToolStripMenuItem();
         this._menuItemOptions = new System.Windows.Forms.ToolStripMenuItem();
         this._menuItemObjectManagers = new System.Windows.Forms.ToolStripMenuItem();
         this._menuItemOCRManager = new System.Windows.Forms.ToolStripMenuItem();
         this._menuItemBarcodeManager = new System.Windows.Forms.ToolStripMenuItem();
         this._menuItemDefaultManager = new System.Windows.Forms.ToolStripMenuItem();
         this._menuItemIncludeExcludeRegions = new System.Windows.Forms.ToolStripMenuItem();
         this.pageTypeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.normalItem = new System.Windows.Forms.ToolStripMenuItem();
         this.cardItem = new System.Windows.Forms.ToolStripMenuItem();
         this.omrItem = new System.Windows.Forms.ToolStripMenuItem();
         this.omrToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._miDetectOmrFields = new System.Windows.Forms.ToolStripMenuItem();
         this._miDeleteOmrFields = new System.Windows.Forms.ToolStripMenuItem();
         this._miRenameOmr = new System.Windows.Forms.ToolStripMenuItem();
         this._miSetOmrSensitivity = new System.Windows.Forms.ToolStripMenuItem();
         this._menuItemEngine = new System.Windows.Forms.ToolStripMenuItem();
         this._menuItemLanguages = new System.Windows.Forms.ToolStripMenuItem();
         this._menuItemComponents = new System.Windows.Forms.ToolStripMenuItem();
         this._menuItemHelp = new System.Windows.Forms.ToolStripMenuItem();
         this._menuItemInformation = new System.Windows.Forms.ToolStripMenuItem();
         this._menuItemHowTo = new System.Windows.Forms.ToolStripMenuItem();
         this._menuItemAbout = new System.Windows.Forms.ToolStripMenuItem();
         this.test1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.test2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._cmHighLevelObjects = new System.Windows.Forms.ContextMenuStrip(this.components);
         this._miSingleSelectionField = new System.Windows.Forms.ToolStripMenuItem();
         this._miBubbleWordField = new System.Windows.Forms.ToolStripMenuItem();
         this._miAnswerAreaField = new System.Windows.Forms.ToolStripMenuItem();
         this._miOmrDateField = new System.Windows.Forms.ToolStripMenuItem();
         ((System.ComponentModel.ISupportInitialize)(this._splMain)).BeginInit();
         this._splMain.Panel1.SuspendLayout();
         this._splMain.Panel2.SuspendLayout();
         this._splMain.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this._splFormsViewer)).BeginInit();
         this._splFormsViewer.Panel1.SuspendLayout();
         this._splFormsViewer.Panel2.SuspendLayout();
         this._splFormsViewer.SuspendLayout();
         this._tsForms.SuspendLayout();
         this._tsFields.SuspendLayout();
         this._tcFieldProps.SuspendLayout();
         this._tpFieldInfo.SuspendLayout();
         this._gbBounds.SuspendLayout();
         this._tpOCR.SuspendLayout();
         this._gbDropoutOptions.SuspendLayout();
         this._gbFieldMethod.SuspendLayout();
         this._gbFieldTextType.SuspendLayout();
         this._tpOMR.SuspendLayout();
         this._gbOMRFrame.SuspendLayout();
         this._gbOMRSensitivity.SuspendLayout();
         this._tpTable.SuspendLayout();
         this._gb_ColumnOcr.SuspendLayout();
         this._tpSelection.SuspendLayout();
         this.groupBox1.SuspendLayout();
         this._tpBubble.SuspendLayout();
         this.groupBox2.SuspendLayout();
         this._tpAnswerArea.SuspendLayout();
         this.groupBox3.SuspendLayout();
         this._tpOmrDate.SuspendLayout();
         this.groupBox4.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this._splViewerList)).BeginInit();
         this._splViewerList.Panel1.SuspendLayout();
         this._splViewerList.SuspendLayout();
         this._tsViewer.SuspendLayout();
         this.menuStrip1.SuspendLayout();
         this._cmHighLevelObjects.SuspendLayout();
         this.SuspendLayout();
         // 
         // _splMain
         // 
         this._splMain.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
         this._splMain.Dock = System.Windows.Forms.DockStyle.Fill;
         this._splMain.Location = new System.Drawing.Point(0, 24);
         this._splMain.Name = "_splMain";
         // 
         // _splMain.Panel1
         // 
         this._splMain.Panel1.Controls.Add(this._splFormsViewer);
         this._splMain.Panel1MinSize = 484;
         // 
         // _splMain.Panel2
         // 
         this._splMain.Panel2.Controls.Add(this._splViewerList);
         this._splMain.Size = new System.Drawing.Size(1197, 780);
         this._splMain.SplitterDistance = 484;
         this._splMain.TabIndex = 3;
         // 
         // _splFormsViewer
         // 
         this._splFormsViewer.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
         this._splFormsViewer.Dock = System.Windows.Forms.DockStyle.Fill;
         this._splFormsViewer.Location = new System.Drawing.Point(0, 0);
         this._splFormsViewer.Name = "_splFormsViewer";
         this._splFormsViewer.Orientation = System.Windows.Forms.Orientation.Horizontal;
         // 
         // _splFormsViewer.Panel1
         // 
         this._splFormsViewer.Panel1.Controls.Add(this._tvMasterForms);
         this._splFormsViewer.Panel1.Controls.Add(this._tsForms);
         // 
         // _splFormsViewer.Panel2
         // 
         this._splFormsViewer.Panel2.Controls.Add(this._tsFields);
         this._splFormsViewer.Panel2.Controls.Add(this._lblMasterFormFields);
         this._splFormsViewer.Panel2.Controls.Add(this._btnApply);
         this._splFormsViewer.Panel2.Controls.Add(this._tcFieldProps);
         this._splFormsViewer.Panel2.Controls.Add(this._lbFields);
         this._splFormsViewer.Size = new System.Drawing.Size(484, 780);
         this._splFormsViewer.SplitterDistance = 471;
         this._splFormsViewer.TabIndex = 0;
         // 
         // _tvMasterForms
         // 
         this._tvMasterForms.Dock = System.Windows.Forms.DockStyle.Fill;
         this._tvMasterForms.Location = new System.Drawing.Point(0, 33);
         this._tvMasterForms.Name = "_tvMasterForms";
         this._tvMasterForms.Size = new System.Drawing.Size(480, 434);
         this._tvMasterForms.TabIndex = 2;
         this._tvMasterForms.BeforeSelect += new System.Windows.Forms.TreeViewCancelEventHandler(this._tvMasterForms_BeforeSelect);
         this._tvMasterForms.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this._tvMasterForms_AfterSelect);
         // 
         // _tsForms
         // 
         this._tsForms.ImageScalingSize = new System.Drawing.Size(20, 20);
         this._tsForms.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._btnLoadFormSet,
            this.toolStripSeparator1,
            this._btnAddMasterMenu,
            this._btnDeleteMasterMenu,
            this._btnSaveMasterFormsAs,
            this._btnMasterFormProps,
            this.toolStripSeparator5,
            this._useFullTextSearchButton});
         this._tsForms.Location = new System.Drawing.Point(0, 0);
         this._tsForms.Name = "_tsForms";
         this._tsForms.Size = new System.Drawing.Size(480, 33);
         this._tsForms.TabIndex = 1;
         this._tsForms.Text = "toolStrip1";
         // 
         // _btnLoadFormSet
         // 
         this._btnLoadFormSet.AutoSize = false;
         this._btnLoadFormSet.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this._btnLoadFormSet.Image = ((System.Drawing.Image)(resources.GetObject("_btnLoadFormSet.Image")));
         this._btnLoadFormSet.ImageTransparentColor = System.Drawing.Color.Magenta;
         this._btnLoadFormSet.Name = "_btnLoadFormSet";
         this._btnLoadFormSet.Size = new System.Drawing.Size(40, 30);
         this._btnLoadFormSet.Text = "Load Master Forms";
         this._btnLoadFormSet.Click += new System.EventHandler(this.LoadFormSet_Click);
         // 
         // toolStripSeparator1
         // 
         this.toolStripSeparator1.Name = "toolStripSeparator1";
         this.toolStripSeparator1.Size = new System.Drawing.Size(6, 33);
         // 
         // _btnAddMasterMenu
         // 
         this._btnAddMasterMenu.AutoSize = false;
         this._btnAddMasterMenu.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this._btnAddMasterMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._menuItemAddMasterSet,
            this._menuItemAddChildCategory,
            this._menuItemAddMaster,
            this._menuItemAddMasterPage});
         this._btnAddMasterMenu.Image = ((System.Drawing.Image)(resources.GetObject("_btnAddMasterMenu.Image")));
         this._btnAddMasterMenu.ImageTransparentColor = System.Drawing.Color.Magenta;
         this._btnAddMasterMenu.Name = "_btnAddMasterMenu";
         this._btnAddMasterMenu.Size = new System.Drawing.Size(40, 30);
         this._btnAddMasterMenu.Text = "Add Master Form";
         // 
         // _menuItemAddMasterSet
         // 
         this._menuItemAddMasterSet.Name = "_menuItemAddMasterSet";
         this._menuItemAddMasterSet.Size = new System.Drawing.Size(195, 22);
         this._menuItemAddMasterSet.Text = "Add Master Form Set";
         this._menuItemAddMasterSet.Click += new System.EventHandler(this._menuItemAddMasterSetMain_Click);
         // 
         // _menuItemAddChildCategory
         // 
         this._menuItemAddChildCategory.Name = "_menuItemAddChildCategory";
         this._menuItemAddChildCategory.Size = new System.Drawing.Size(195, 22);
         this._menuItemAddChildCategory.Text = "Add Child Category";
         this._menuItemAddChildCategory.Click += new System.EventHandler(this._menuItemAddChildCategoryMain_Click);
         // 
         // _menuItemAddMaster
         // 
         this._menuItemAddMaster.Name = "_menuItemAddMaster";
         this._menuItemAddMaster.Size = new System.Drawing.Size(195, 22);
         this._menuItemAddMaster.Text = "Add Master Form";
         this._menuItemAddMaster.Click += new System.EventHandler(this._menuItemAddMasterMain_Click);
         // 
         // _menuItemAddMasterPage
         // 
         this._menuItemAddMasterPage.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._menuItemAddMasterPageDisk,
            this._menuItemAddMasterPageScanner});
         this._menuItemAddMasterPage.Name = "_menuItemAddMasterPage";
         this._menuItemAddMasterPage.Size = new System.Drawing.Size(195, 22);
         this._menuItemAddMasterPage.Text = "Add Master Form Page";
         // 
         // _menuItemAddMasterPageDisk
         // 
         this._menuItemAddMasterPageDisk.Name = "_menuItemAddMasterPageDisk";
         this._menuItemAddMasterPageDisk.Size = new System.Drawing.Size(147, 22);
         this._menuItemAddMasterPageDisk.Text = "From Disk";
         this._menuItemAddMasterPageDisk.Click += new System.EventHandler(this._menuItemAddMasterPageDiskMain_Click);
         // 
         // _menuItemAddMasterPageScanner
         // 
         this._menuItemAddMasterPageScanner.Name = "_menuItemAddMasterPageScanner";
         this._menuItemAddMasterPageScanner.Size = new System.Drawing.Size(147, 22);
         this._menuItemAddMasterPageScanner.Text = "From Scanner";
         this._menuItemAddMasterPageScanner.Click += new System.EventHandler(this._menuItemAddMasterPageScannerMain_Click);
         // 
         // _btnDeleteMasterMenu
         // 
         this._btnDeleteMasterMenu.AutoSize = false;
         this._btnDeleteMasterMenu.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this._btnDeleteMasterMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._menuItemDeleteChildCategory,
            this._menuItemDeleteMaster,
            this._menuItemDeleteMasterPage});
         this._btnDeleteMasterMenu.Image = ((System.Drawing.Image)(resources.GetObject("_btnDeleteMasterMenu.Image")));
         this._btnDeleteMasterMenu.ImageTransparentColor = System.Drawing.Color.Magenta;
         this._btnDeleteMasterMenu.Name = "_btnDeleteMasterMenu";
         this._btnDeleteMasterMenu.Size = new System.Drawing.Size(40, 30);
         this._btnDeleteMasterMenu.Text = "Delete Selected Master Form";
         // 
         // _menuItemDeleteChildCategory
         // 
         this._menuItemDeleteChildCategory.Name = "_menuItemDeleteChildCategory";
         this._menuItemDeleteChildCategory.Size = new System.Drawing.Size(206, 22);
         this._menuItemDeleteChildCategory.Text = "Delete Child Category";
         this._menuItemDeleteChildCategory.Click += new System.EventHandler(this._menuItemDeleteChildCategoryMain_Click);
         // 
         // _menuItemDeleteMaster
         // 
         this._menuItemDeleteMaster.Name = "_menuItemDeleteMaster";
         this._menuItemDeleteMaster.Size = new System.Drawing.Size(206, 22);
         this._menuItemDeleteMaster.Text = "Delete Master Form";
         this._menuItemDeleteMaster.Click += new System.EventHandler(this._menuItemDeleteMasterMain_Click);
         // 
         // _menuItemDeleteMasterPage
         // 
         this._menuItemDeleteMasterPage.Name = "_menuItemDeleteMasterPage";
         this._menuItemDeleteMasterPage.Size = new System.Drawing.Size(206, 22);
         this._menuItemDeleteMasterPage.Text = "Delete Master Form Page";
         this._menuItemDeleteMasterPage.Click += new System.EventHandler(this._menuItemDeleteMasterPageMain_Click);
         // 
         // _btnSaveMasterFormsAs
         // 
         this._btnSaveMasterFormsAs.AutoSize = false;
         this._btnSaveMasterFormsAs.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this._btnSaveMasterFormsAs.Image = ((System.Drawing.Image)(resources.GetObject("_btnSaveMasterFormsAs.Image")));
         this._btnSaveMasterFormsAs.ImageTransparentColor = System.Drawing.Color.Black;
         this._btnSaveMasterFormsAs.Name = "_btnSaveMasterFormsAs";
         this._btnSaveMasterFormsAs.Size = new System.Drawing.Size(40, 30);
         this._btnSaveMasterFormsAs.Text = "Save Master Forms To New Folder";
         this._btnSaveMasterFormsAs.Click += new System.EventHandler(this._menuItemSaveFormSetAs_Click);
         // 
         // _btnMasterFormProps
         // 
         this._btnMasterFormProps.AutoSize = false;
         this._btnMasterFormProps.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this._btnMasterFormProps.Image = ((System.Drawing.Image)(resources.GetObject("_btnMasterFormProps.Image")));
         this._btnMasterFormProps.ImageTransparentColor = System.Drawing.Color.Magenta;
         this._btnMasterFormProps.Name = "_btnMasterFormProps";
         this._btnMasterFormProps.Size = new System.Drawing.Size(40, 30);
         this._btnMasterFormProps.Text = "Selected Master Form Properties";
         this._btnMasterFormProps.Click += new System.EventHandler(this._menuItemMasterFormPropsMain_Click);
         // 
         // toolStripSeparator5
         // 
         this.toolStripSeparator5.Name = "toolStripSeparator5";
         this.toolStripSeparator5.Size = new System.Drawing.Size(6, 33);
         // 
         // _useFullTextSearchButton
         // 
         this._useFullTextSearchButton.Checked = true;
         this._useFullTextSearchButton.CheckOnClick = true;
         this._useFullTextSearchButton.CheckState = System.Windows.Forms.CheckState.Checked;
         this._useFullTextSearchButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this._useFullTextSearchButton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
         this._useFullTextSearchButton.Image = ((System.Drawing.Image)(resources.GetObject("_useFullTextSearchButton_checked.Image")));
         this._useFullTextSearchButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
         this._useFullTextSearchButton.Name = "_useFullTextSearchButton";
         this._useFullTextSearchButton.Size = new System.Drawing.Size(133, 39);
         this._useFullTextSearchButton.Text = "Use Full Text Search";
         this._useFullTextSearchButton.Click += new System.EventHandler(this._useFullTextSearchButton_Click);
         // 
         // _tsFields
         // 
         this._tsFields.ImageScalingSize = new System.Drawing.Size(20, 20);
         this._tsFields.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._btnCutField,
            this._btnCopyField,
            this._btnPasteField,
            this._btnDeleteField});
         this._tsFields.Location = new System.Drawing.Point(0, 0);
         this._tsFields.Name = "_tsFields";
         this._tsFields.Size = new System.Drawing.Size(480, 33);
         this._tsFields.TabIndex = 24;
         this._tsFields.Text = "toolStrip1";
         // 
         // _btnCutField
         // 
         this._btnCutField.AutoSize = false;
         this._btnCutField.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this._btnCutField.Image = ((System.Drawing.Image)(resources.GetObject("_btnCutField.Image")));
         this._btnCutField.ImageTransparentColor = System.Drawing.Color.Magenta;
         this._btnCutField.Name = "_btnCutField";
         this._btnCutField.Size = new System.Drawing.Size(40, 30);
         this._btnCutField.Text = "Cut Field";
         this._btnCutField.Click += new System.EventHandler(this._btnCutField_Click);
         // 
         // _btnCopyField
         // 
         this._btnCopyField.AutoSize = false;
         this._btnCopyField.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this._btnCopyField.Image = ((System.Drawing.Image)(resources.GetObject("_btnCopyField.Image")));
         this._btnCopyField.ImageTransparentColor = System.Drawing.Color.Magenta;
         this._btnCopyField.Name = "_btnCopyField";
         this._btnCopyField.Size = new System.Drawing.Size(40, 30);
         this._btnCopyField.Text = "Copy Field";
         this._btnCopyField.Click += new System.EventHandler(this._btnCopyField_Click);
         // 
         // _btnPasteField
         // 
         this._btnPasteField.AutoSize = false;
         this._btnPasteField.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this._btnPasteField.Image = ((System.Drawing.Image)(resources.GetObject("_btnPasteField.Image")));
         this._btnPasteField.ImageTransparentColor = System.Drawing.Color.Magenta;
         this._btnPasteField.Name = "_btnPasteField";
         this._btnPasteField.Size = new System.Drawing.Size(40, 30);
         this._btnPasteField.Text = "Paste Field";
         this._btnPasteField.Click += new System.EventHandler(this._btnPasteField_Click);
         // 
         // _btnDeleteField
         // 
         this._btnDeleteField.AutoSize = false;
         this._btnDeleteField.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this._btnDeleteField.Image = ((System.Drawing.Image)(resources.GetObject("_btnDeleteField.Image")));
         this._btnDeleteField.ImageTransparentColor = System.Drawing.Color.Magenta;
         this._btnDeleteField.Name = "_btnDeleteField";
         this._btnDeleteField.Size = new System.Drawing.Size(40, 30);
         this._btnDeleteField.Text = "Delete Selected Field";
         this._btnDeleteField.Click += new System.EventHandler(this._btnDeleteField_Click);
         // 
         // _lblMasterFormFields
         // 
         this._lblMasterFormFields.AutoSize = true;
         this._lblMasterFormFields.Location = new System.Drawing.Point(7, 52);
         this._lblMasterFormFields.Name = "_lblMasterFormFields";
         this._lblMasterFormFields.Size = new System.Drawing.Size(95, 13);
         this._lblMasterFormFields.TabIndex = 23;
         this._lblMasterFormFields.Text = "Master Form Fields";
         // 
         // _btnApply
         // 
         this._btnApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
         this._btnApply.Location = new System.Drawing.Point(185, 259);
         this._btnApply.Name = "_btnApply";
         this._btnApply.Size = new System.Drawing.Size(278, 27);
         this._btnApply.TabIndex = 22;
         this._btnApply.Text = "Apply Field Changes";
         this._btnApply.UseVisualStyleBackColor = true;
         this._btnApply.Click += new System.EventHandler(this._btnApply_Click);
         // 
         // _tcFieldProps
         // 
         this._tcFieldProps.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this._tcFieldProps.Controls.Add(this._tpFieldInfo);
         this._tcFieldProps.Controls.Add(this._tpOCR);
         this._tcFieldProps.Controls.Add(this._tpOMR);
         this._tcFieldProps.Controls.Add(this._tpTable);
         this._tcFieldProps.Controls.Add(this._tpSelection);
         this._tcFieldProps.Controls.Add(this._tpBubble);
         this._tcFieldProps.Controls.Add(this._tpAnswerArea);
         this._tcFieldProps.Controls.Add(this._tpOmrDate);
         this._tcFieldProps.Location = new System.Drawing.Point(185, 50);
         this._tcFieldProps.Name = "_tcFieldProps";
         this._tcFieldProps.SelectedIndex = 0;
         this._tcFieldProps.Size = new System.Drawing.Size(282, 203);
         this._tcFieldProps.TabIndex = 21;
         // 
         // _tpFieldInfo
         // 
         this._tpFieldInfo.Controls.Add(this._cmbFieldType);
         this._tpFieldInfo.Controls.Add(this._lblFieldType);
         this._tpFieldInfo.Controls.Add(this._txtFieldName);
         this._tpFieldInfo.Controls.Add(this._gbBounds);
         this._tpFieldInfo.Controls.Add(this._lblFieldName);
         this._tpFieldInfo.Location = new System.Drawing.Point(4, 22);
         this._tpFieldInfo.Name = "_tpFieldInfo";
         this._tpFieldInfo.Padding = new System.Windows.Forms.Padding(3);
         this._tpFieldInfo.Size = new System.Drawing.Size(274, 177);
         this._tpFieldInfo.TabIndex = 0;
         this._tpFieldInfo.Text = "Field Info";
         this._tpFieldInfo.UseVisualStyleBackColor = true;
         // 
         // _cmbFieldType
         // 
         this._cmbFieldType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
         this._cmbFieldType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this._cmbFieldType.FormattingEnabled = true;
         this._cmbFieldType.Items.AddRange(new object[] {
            "Text",
            "Omr",
            "Barcode",
            "Image",
            "Table",
            "UnStructured Text"});
         this._cmbFieldType.Location = new System.Drawing.Point(55, 39);
         this._cmbFieldType.Name = "_cmbFieldType";
         this._cmbFieldType.Size = new System.Drawing.Size(199, 21);
         this._cmbFieldType.TabIndex = 18;
         this._cmbFieldType.SelectedIndexChanged += new System.EventHandler(this._cmbFieldType_SelectedIndexChanged);
         // 
         // _lblFieldType
         // 
         this._lblFieldType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
         this._lblFieldType.AutoSize = true;
         this._lblFieldType.Location = new System.Drawing.Point(14, 42);
         this._lblFieldType.Name = "_lblFieldType";
         this._lblFieldType.Size = new System.Drawing.Size(31, 13);
         this._lblFieldType.TabIndex = 20;
         this._lblFieldType.Text = "Type";
         // 
         // _txtFieldName
         // 
         this._txtFieldName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
         this._txtFieldName.Location = new System.Drawing.Point(55, 13);
         this._txtFieldName.Name = "_txtFieldName";
         this._txtFieldName.Size = new System.Drawing.Size(199, 20);
         this._txtFieldName.TabIndex = 17;
         this._txtFieldName.TextChanged += new System.EventHandler(this._txtFieldName_TextChanged);
         // 
         // _gbBounds
         // 
         this._gbBounds.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
         this._gbBounds.Controls.Add(this._txtFieldHeight);
         this._gbBounds.Controls.Add(this._txtFieldWidth);
         this._gbBounds.Controls.Add(this._lblFieldHeight);
         this._gbBounds.Controls.Add(this._txtFieldTop);
         this._gbBounds.Controls.Add(this._lblFieldWidth);
         this._gbBounds.Controls.Add(this._txtFieldLeft);
         this._gbBounds.Controls.Add(this._lblFieldTop);
         this._gbBounds.Controls.Add(this._lblFieldLeft);
         this._gbBounds.Location = new System.Drawing.Point(17, 73);
         this._gbBounds.Name = "_gbBounds";
         this._gbBounds.Size = new System.Drawing.Size(237, 66);
         this._gbBounds.TabIndex = 17;
         this._gbBounds.TabStop = false;
         this._gbBounds.Text = "Bounds";
         // 
         // _txtFieldHeight
         // 
         this._txtFieldHeight.Location = new System.Drawing.Point(170, 38);
         this._txtFieldHeight.Name = "_txtFieldHeight";
         this._txtFieldHeight.ReadOnly = true;
         this._txtFieldHeight.Size = new System.Drawing.Size(53, 20);
         this._txtFieldHeight.TabIndex = 5;
         // 
         // _txtFieldWidth
         // 
         this._txtFieldWidth.Location = new System.Drawing.Point(170, 13);
         this._txtFieldWidth.Name = "_txtFieldWidth";
         this._txtFieldWidth.ReadOnly = true;
         this._txtFieldWidth.Size = new System.Drawing.Size(53, 20);
         this._txtFieldWidth.TabIndex = 3;
         // 
         // _lblFieldHeight
         // 
         this._lblFieldHeight.AutoSize = true;
         this._lblFieldHeight.Location = new System.Drawing.Point(129, 41);
         this._lblFieldHeight.Name = "_lblFieldHeight";
         this._lblFieldHeight.Size = new System.Drawing.Size(38, 13);
         this._lblFieldHeight.TabIndex = 12;
         this._lblFieldHeight.Text = "Height";
         // 
         // _txtFieldTop
         // 
         this._txtFieldTop.Location = new System.Drawing.Point(48, 38);
         this._txtFieldTop.Name = "_txtFieldTop";
         this._txtFieldTop.ReadOnly = true;
         this._txtFieldTop.Size = new System.Drawing.Size(53, 20);
         this._txtFieldTop.TabIndex = 4;
         // 
         // _lblFieldWidth
         // 
         this._lblFieldWidth.AutoSize = true;
         this._lblFieldWidth.Location = new System.Drawing.Point(129, 16);
         this._lblFieldWidth.Name = "_lblFieldWidth";
         this._lblFieldWidth.Size = new System.Drawing.Size(35, 13);
         this._lblFieldWidth.TabIndex = 10;
         this._lblFieldWidth.Text = "Width";
         // 
         // _txtFieldLeft
         // 
         this._txtFieldLeft.Location = new System.Drawing.Point(48, 13);
         this._txtFieldLeft.Name = "_txtFieldLeft";
         this._txtFieldLeft.ReadOnly = true;
         this._txtFieldLeft.Size = new System.Drawing.Size(53, 20);
         this._txtFieldLeft.TabIndex = 2;
         // 
         // _lblFieldTop
         // 
         this._lblFieldTop.AutoSize = true;
         this._lblFieldTop.Location = new System.Drawing.Point(7, 41);
         this._lblFieldTop.Name = "_lblFieldTop";
         this._lblFieldTop.Size = new System.Drawing.Size(26, 13);
         this._lblFieldTop.TabIndex = 8;
         this._lblFieldTop.Text = "Top";
         // 
         // _lblFieldLeft
         // 
         this._lblFieldLeft.AutoSize = true;
         this._lblFieldLeft.Location = new System.Drawing.Point(7, 16);
         this._lblFieldLeft.Name = "_lblFieldLeft";
         this._lblFieldLeft.Size = new System.Drawing.Size(25, 13);
         this._lblFieldLeft.TabIndex = 7;
         this._lblFieldLeft.Text = "Left";
         // 
         // _lblFieldName
         // 
         this._lblFieldName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
         this._lblFieldName.AutoSize = true;
         this._lblFieldName.Location = new System.Drawing.Point(14, 16);
         this._lblFieldName.Name = "_lblFieldName";
         this._lblFieldName.Size = new System.Drawing.Size(35, 13);
         this._lblFieldName.TabIndex = 19;
         this._lblFieldName.Text = "Name";
         // 
         // _tpOCR
         // 
         this._tpOCR.Controls.Add(this._gbDropoutOptions);
         this._tpOCR.Controls.Add(this._gbFieldMethod);
         this._tpOCR.Controls.Add(this._gbFieldTextType);
         this._tpOCR.Location = new System.Drawing.Point(4, 22);
         this._tpOCR.Name = "_tpOCR";
         this._tpOCR.Padding = new System.Windows.Forms.Padding(3);
         this._tpOCR.Size = new System.Drawing.Size(274, 177);
         this._tpOCR.TabIndex = 1;
         this._tpOCR.Text = "OCR";
         this._tpOCR.UseVisualStyleBackColor = true;
         // 
         // _gbDropoutOptions
         // 
         this._gbDropoutOptions.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
         this._gbDropoutOptions.Controls.Add(this._chkDropoutCells);
         this._gbDropoutOptions.Controls.Add(this._chkDropoutWords);
         this._gbDropoutOptions.Location = new System.Drawing.Point(8, 120);
         this._gbDropoutOptions.Name = "_gbDropoutOptions";
         this._gbDropoutOptions.Size = new System.Drawing.Size(260, 51);
         this._gbDropoutOptions.TabIndex = 26;
         this._gbDropoutOptions.TabStop = false;
         this._gbDropoutOptions.Text = "Dropout";
         // 
         // _chkDropoutCells
         // 
         this._chkDropoutCells.AutoSize = true;
         this._chkDropoutCells.Location = new System.Drawing.Point(102, 19);
         this._chkDropoutCells.Name = "_chkDropoutCells";
         this._chkDropoutCells.Size = new System.Drawing.Size(87, 17);
         this._chkDropoutCells.TabIndex = 8;
         this._chkDropoutCells.Text = "Cells Borders";
         this._chkDropoutCells.UseVisualStyleBackColor = true;
         // 
         // _chkDropoutWords
         // 
         this._chkDropoutWords.AutoSize = true;
         this._chkDropoutWords.Location = new System.Drawing.Point(10, 19);
         this._chkDropoutWords.Name = "_chkDropoutWords";
         this._chkDropoutWords.Size = new System.Drawing.Size(57, 17);
         this._chkDropoutWords.TabIndex = 7;
         this._chkDropoutWords.Text = "Words";
         this._chkDropoutWords.UseVisualStyleBackColor = true;
         // 
         // _gbFieldMethod
         // 
         this._gbFieldMethod.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
         this._gbFieldMethod.Controls.Add(this._chkEnableIcr);
         this._gbFieldMethod.Controls.Add(this._chkEnableOcr);
         this._gbFieldMethod.Location = new System.Drawing.Point(154, 12);
         this._gbFieldMethod.Name = "_gbFieldMethod";
         this._gbFieldMethod.Size = new System.Drawing.Size(101, 74);
         this._gbFieldMethod.TabIndex = 13;
         this._gbFieldMethod.TabStop = false;
         this._gbFieldMethod.Text = "Method";
         // 
         // _chkEnableIcr
         // 
         this._chkEnableIcr.AutoSize = true;
         this._chkEnableIcr.Location = new System.Drawing.Point(10, 42);
         this._chkEnableIcr.Name = "_chkEnableIcr";
         this._chkEnableIcr.Size = new System.Drawing.Size(80, 17);
         this._chkEnableIcr.TabIndex = 7;
         this._chkEnableIcr.Text = "Enable ICR";
         this._chkEnableIcr.TextAlign = System.Drawing.ContentAlignment.TopLeft;
         this._chkEnableIcr.UseVisualStyleBackColor = true;
         this._chkEnableIcr.CheckedChanged += new System.EventHandler(this._chkOCRMethod_CheckedChanged);
         // 
         // _chkEnableOcr
         // 
         this._chkEnableOcr.AutoSize = true;
         this._chkEnableOcr.Location = new System.Drawing.Point(10, 19);
         this._chkEnableOcr.Name = "_chkEnableOcr";
         this._chkEnableOcr.Size = new System.Drawing.Size(85, 17);
         this._chkEnableOcr.TabIndex = 6;
         this._chkEnableOcr.Text = "Enable OCR";
         this._chkEnableOcr.UseVisualStyleBackColor = true;
         this._chkEnableOcr.CheckedChanged += new System.EventHandler(this._chkOCRMethod_CheckedChanged);
         // 
         // _gbFieldTextType
         // 
         this._gbFieldTextType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
         this._gbFieldTextType.Controls.Add(this._rbtextTypeData);
         this._gbFieldTextType.Controls.Add(this._rbtextTypeNum);
         this._gbFieldTextType.Controls.Add(this._rbTextTypeChar);
         this._gbFieldTextType.Location = new System.Drawing.Point(12, 11);
         this._gbFieldTextType.Name = "_gbFieldTextType";
         this._gbFieldTextType.Size = new System.Drawing.Size(101, 103);
         this._gbFieldTextType.TabIndex = 14;
         this._gbFieldTextType.TabStop = false;
         this._gbFieldTextType.Text = "Text Type";
         // 
         // _rbtextTypeData
         // 
         this._rbtextTypeData.AutoSize = true;
         this._rbtextTypeData.Location = new System.Drawing.Point(10, 71);
         this._rbtextTypeData.Name = "_rbtextTypeData";
         this._rbtextTypeData.Size = new System.Drawing.Size(48, 17);
         this._rbtextTypeData.TabIndex = 10;
         this._rbtextTypeData.Text = "Data";
         this._rbtextTypeData.UseVisualStyleBackColor = true;
         this._rbtextTypeData.CheckedChanged += new System.EventHandler(this._rbTextType_CheckedChanged);
         // 
         // _rbtextTypeNum
         // 
         this._rbtextTypeNum.AutoSize = true;
         this._rbtextTypeNum.Location = new System.Drawing.Point(10, 45);
         this._rbtextTypeNum.Name = "_rbtextTypeNum";
         this._rbtextTypeNum.Size = new System.Drawing.Size(72, 17);
         this._rbtextTypeNum.TabIndex = 9;
         this._rbtextTypeNum.Text = "Numerical";
         this._rbtextTypeNum.UseVisualStyleBackColor = true;
         this._rbtextTypeNum.CheckedChanged += new System.EventHandler(this._rbTextType_CheckedChanged);
         // 
         // _rbTextTypeChar
         // 
         this._rbTextTypeChar.AutoSize = true;
         this._rbTextTypeChar.Location = new System.Drawing.Point(10, 19);
         this._rbTextTypeChar.Name = "_rbTextTypeChar";
         this._rbTextTypeChar.Size = new System.Drawing.Size(71, 17);
         this._rbTextTypeChar.TabIndex = 8;
         this._rbTextTypeChar.Text = "Character";
         this._rbTextTypeChar.UseVisualStyleBackColor = true;
         this._rbTextTypeChar.CheckedChanged += new System.EventHandler(this._rbTextType_CheckedChanged);
         // 
         // _tpOMR
         // 
         this._tpOMR.Controls.Add(this._gbOMRFrame);
         this._tpOMR.Controls.Add(this._gbOMRSensitivity);
         this._tpOMR.Location = new System.Drawing.Point(4, 22);
         this._tpOMR.Name = "_tpOMR";
         this._tpOMR.Padding = new System.Windows.Forms.Padding(3);
         this._tpOMR.Size = new System.Drawing.Size(274, 177);
         this._tpOMR.TabIndex = 2;
         this._tpOMR.Text = "OMR";
         this._tpOMR.UseVisualStyleBackColor = true;
         // 
         // _gbOMRFrame
         // 
         this._gbOMRFrame.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
         this._gbOMRFrame.Controls.Add(this._rbOMRWithoutFrame);
         this._gbOMRFrame.Controls.Add(this._rbOMRWithFrame);
         this._gbOMRFrame.Controls.Add(this._rbOMRAutoFrame);
         this._gbOMRFrame.Location = new System.Drawing.Point(145, 13);
         this._gbOMRFrame.Name = "_gbOMRFrame";
         this._gbOMRFrame.Size = new System.Drawing.Size(113, 94);
         this._gbOMRFrame.TabIndex = 15;
         this._gbOMRFrame.TabStop = false;
         this._gbOMRFrame.Text = "Frame";
         // 
         // _rbOMRWithoutFrame
         // 
         this._rbOMRWithoutFrame.AutoSize = true;
         this._rbOMRWithoutFrame.Location = new System.Drawing.Point(10, 71);
         this._rbOMRWithoutFrame.Name = "_rbOMRWithoutFrame";
         this._rbOMRWithoutFrame.Size = new System.Drawing.Size(94, 17);
         this._rbOMRWithoutFrame.TabIndex = 13;
         this._rbOMRWithoutFrame.TabStop = true;
         this._rbOMRWithoutFrame.Text = "Without Frame";
         this._rbOMRWithoutFrame.UseVisualStyleBackColor = true;
         this._rbOMRWithoutFrame.CheckedChanged += new System.EventHandler(this._rbOMRFrame_CheckedChanged);
         // 
         // _rbOMRWithFrame
         // 
         this._rbOMRWithFrame.AutoSize = true;
         this._rbOMRWithFrame.Location = new System.Drawing.Point(10, 45);
         this._rbOMRWithFrame.Name = "_rbOMRWithFrame";
         this._rbOMRWithFrame.Size = new System.Drawing.Size(79, 17);
         this._rbOMRWithFrame.TabIndex = 12;
         this._rbOMRWithFrame.TabStop = true;
         this._rbOMRWithFrame.Text = "With Frame";
         this._rbOMRWithFrame.UseVisualStyleBackColor = true;
         this._rbOMRWithFrame.CheckedChanged += new System.EventHandler(this._rbOMRFrame_CheckedChanged);
         // 
         // _rbOMRAutoFrame
         // 
         this._rbOMRAutoFrame.AutoSize = true;
         this._rbOMRAutoFrame.Location = new System.Drawing.Point(10, 19);
         this._rbOMRAutoFrame.Name = "_rbOMRAutoFrame";
         this._rbOMRAutoFrame.Size = new System.Drawing.Size(47, 17);
         this._rbOMRAutoFrame.TabIndex = 11;
         this._rbOMRAutoFrame.TabStop = true;
         this._rbOMRAutoFrame.Text = "Auto";
         this._rbOMRAutoFrame.UseVisualStyleBackColor = true;
         this._rbOMRAutoFrame.CheckedChanged += new System.EventHandler(this._rbOMRFrame_CheckedChanged);
         // 
         // _gbOMRSensitivity
         // 
         this._gbOMRSensitivity.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
         this._gbOMRSensitivity.Controls.Add(this._rbOMRSensitivityHighest);
         this._gbOMRSensitivity.Controls.Add(this._rbOMRSensitivityHigh);
         this._gbOMRSensitivity.Controls.Add(this._rbOMRSensitivityLowest);
         this._gbOMRSensitivity.Controls.Add(this._rbOMRSensitivityLow);
         this._gbOMRSensitivity.Location = new System.Drawing.Point(15, 13);
         this._gbOMRSensitivity.Name = "_gbOMRSensitivity";
         this._gbOMRSensitivity.Size = new System.Drawing.Size(101, 121);
         this._gbOMRSensitivity.TabIndex = 16;
         this._gbOMRSensitivity.TabStop = false;
         this._gbOMRSensitivity.Text = "Sensitivity";
         // 
         // _rbOMRSensitivityHighest
         // 
         this._rbOMRSensitivityHighest.AutoSize = true;
         this._rbOMRSensitivityHighest.Location = new System.Drawing.Point(10, 99);
         this._rbOMRSensitivityHighest.Name = "_rbOMRSensitivityHighest";
         this._rbOMRSensitivityHighest.Size = new System.Drawing.Size(61, 17);
         this._rbOMRSensitivityHighest.TabIndex = 11;
         this._rbOMRSensitivityHighest.TabStop = true;
         this._rbOMRSensitivityHighest.Text = "Highest";
         this._rbOMRSensitivityHighest.UseVisualStyleBackColor = true;
         this._rbOMRSensitivityHighest.CheckedChanged += new System.EventHandler(this._rbOMRSensitivity_CheckedChanged);
         // 
         // _rbOMRSensitivityHigh
         // 
         this._rbOMRSensitivityHigh.AutoSize = true;
         this._rbOMRSensitivityHigh.Location = new System.Drawing.Point(10, 71);
         this._rbOMRSensitivityHigh.Name = "_rbOMRSensitivityHigh";
         this._rbOMRSensitivityHigh.Size = new System.Drawing.Size(47, 17);
         this._rbOMRSensitivityHigh.TabIndex = 10;
         this._rbOMRSensitivityHigh.TabStop = true;
         this._rbOMRSensitivityHigh.Text = "High";
         this._rbOMRSensitivityHigh.UseVisualStyleBackColor = true;
         this._rbOMRSensitivityHigh.CheckedChanged += new System.EventHandler(this._rbOMRSensitivity_CheckedChanged);
         // 
         // _rbOMRSensitivityLowest
         // 
         this._rbOMRSensitivityLowest.AutoSize = true;
         this._rbOMRSensitivityLowest.Location = new System.Drawing.Point(10, 19);
         this._rbOMRSensitivityLowest.Name = "_rbOMRSensitivityLowest";
         this._rbOMRSensitivityLowest.Size = new System.Drawing.Size(59, 17);
         this._rbOMRSensitivityLowest.TabIndex = 9;
         this._rbOMRSensitivityLowest.TabStop = true;
         this._rbOMRSensitivityLowest.Text = "Lowest";
         this._rbOMRSensitivityLowest.UseVisualStyleBackColor = true;
         this._rbOMRSensitivityLowest.CheckedChanged += new System.EventHandler(this._rbOMRSensitivity_CheckedChanged);
         // 
         // _rbOMRSensitivityLow
         // 
         this._rbOMRSensitivityLow.AutoSize = true;
         this._rbOMRSensitivityLow.Location = new System.Drawing.Point(10, 45);
         this._rbOMRSensitivityLow.Name = "_rbOMRSensitivityLow";
         this._rbOMRSensitivityLow.Size = new System.Drawing.Size(45, 17);
         this._rbOMRSensitivityLow.TabIndex = 8;
         this._rbOMRSensitivityLow.TabStop = true;
         this._rbOMRSensitivityLow.Text = "Low";
         this._rbOMRSensitivityLow.UseVisualStyleBackColor = true;
         this._rbOMRSensitivityLow.CheckedChanged += new System.EventHandler(this._rbOMRSensitivity_CheckedChanged);
         // 
         // _tpTable
         // 
         this._tpTable.Controls.Add(this._btn_Rules);
         this._tpTable.Controls.Add(this._btn_ColumnOptions);
         this._tpTable.Controls.Add(this._gb_ColumnOcr);
         this._tpTable.Controls.Add(this._btn_RemoveColumn);
         this._tpTable.Controls.Add(this._btn_AddColumn);
         this._tpTable.Controls.Add(this._lbColumns);
         this._tpTable.Location = new System.Drawing.Point(4, 22);
         this._tpTable.Name = "_tpTable";
         this._tpTable.Padding = new System.Windows.Forms.Padding(3);
         this._tpTable.Size = new System.Drawing.Size(274, 177);
         this._tpTable.TabIndex = 3;
         this._tpTable.Text = "Table";
         this._tpTable.UseVisualStyleBackColor = true;
         // 
         // _btn_Rules
         // 
         this._btn_Rules.Location = new System.Drawing.Point(131, 116);
         this._btn_Rules.Name = "_btn_Rules";
         this._btn_Rules.Size = new System.Drawing.Size(122, 23);
         this._btn_Rules.TabIndex = 10;
         this._btn_Rules.Text = "Rules";
         this._btn_Rules.UseVisualStyleBackColor = true;
         this._btn_Rules.Click += new System.EventHandler(this._btn_Rules_Click);
         // 
         // _btn_ColumnOptions
         // 
         this._btn_ColumnOptions.Location = new System.Drawing.Point(131, 87);
         this._btn_ColumnOptions.Name = "_btn_ColumnOptions";
         this._btn_ColumnOptions.Size = new System.Drawing.Size(122, 23);
         this._btn_ColumnOptions.TabIndex = 9;
         this._btn_ColumnOptions.Text = "Options";
         this._btn_ColumnOptions.UseVisualStyleBackColor = true;
         this._btn_ColumnOptions.Click += new System.EventHandler(this._btn_ColumnOptions_Click);
         // 
         // _gb_ColumnOcr
         // 
         this._gb_ColumnOcr.Controls.Add(this._rB_ColumnOmr);
         this._gb_ColumnOcr.Controls.Add(this._rB_ColumnOcr);
         this._gb_ColumnOcr.Location = new System.Drawing.Point(129, 6);
         this._gb_ColumnOcr.Name = "_gb_ColumnOcr";
         this._gb_ColumnOcr.Size = new System.Drawing.Size(134, 47);
         this._gb_ColumnOcr.TabIndex = 6;
         this._gb_ColumnOcr.TabStop = false;
         this._gb_ColumnOcr.Text = "Field Type";
         // 
         // _rB_ColumnOmr
         // 
         this._rB_ColumnOmr.AutoSize = true;
         this._rB_ColumnOmr.Location = new System.Drawing.Point(55, 20);
         this._rB_ColumnOmr.Name = "_rB_ColumnOmr";
         this._rB_ColumnOmr.Size = new System.Drawing.Size(44, 17);
         this._rB_ColumnOmr.TabIndex = 1;
         this._rB_ColumnOmr.Text = "Omr";
         this._rB_ColumnOmr.UseVisualStyleBackColor = true;
         this._rB_ColumnOmr.CheckedChanged += new System.EventHandler(this._rB_Column_CheckedChanged);
         // 
         // _rB_ColumnOcr
         // 
         this._rB_ColumnOcr.AutoSize = true;
         this._rB_ColumnOcr.Checked = true;
         this._rB_ColumnOcr.Location = new System.Drawing.Point(7, 20);
         this._rB_ColumnOcr.Name = "_rB_ColumnOcr";
         this._rB_ColumnOcr.Size = new System.Drawing.Size(42, 17);
         this._rB_ColumnOcr.TabIndex = 0;
         this._rB_ColumnOcr.TabStop = true;
         this._rB_ColumnOcr.Text = "Ocr";
         this._rB_ColumnOcr.UseVisualStyleBackColor = true;
         this._rB_ColumnOcr.CheckedChanged += new System.EventHandler(this._rB_Column_CheckedChanged);
         // 
         // _btn_RemoveColumn
         // 
         this._btn_RemoveColumn.Location = new System.Drawing.Point(195, 58);
         this._btn_RemoveColumn.Name = "_btn_RemoveColumn";
         this._btn_RemoveColumn.Size = new System.Drawing.Size(58, 23);
         this._btn_RemoveColumn.TabIndex = 5;
         this._btn_RemoveColumn.Text = "Remove";
         this._btn_RemoveColumn.UseVisualStyleBackColor = true;
         this._btn_RemoveColumn.Click += new System.EventHandler(this._btn_RemoveColumn_Click);
         // 
         // _btn_AddColumn
         // 
         this._btn_AddColumn.Location = new System.Drawing.Point(131, 58);
         this._btn_AddColumn.Name = "_btn_AddColumn";
         this._btn_AddColumn.Size = new System.Drawing.Size(58, 23);
         this._btn_AddColumn.TabIndex = 4;
         this._btn_AddColumn.Text = "Add";
         this._btn_AddColumn.UseVisualStyleBackColor = true;
         this._btn_AddColumn.Click += new System.EventHandler(this._btn_AddColumn_Click);
         // 
         // _lbColumns
         // 
         this._lbColumns.FormattingEnabled = true;
         this._lbColumns.Location = new System.Drawing.Point(3, 6);
         this._lbColumns.Name = "_lbColumns";
         this._lbColumns.Size = new System.Drawing.Size(120, 134);
         this._lbColumns.TabIndex = 3;
         this._lbColumns.SelectedIndexChanged += new System.EventHandler(this._lbColumns_SelectedIndexChanged);
         // 
         // _tpSelection
         // 
         this._tpSelection.Controls.Add(this._btnRemoveSelection);
         this._tpSelection.Controls.Add(this._cbHideSelectionAnn);
         this._tpSelection.Controls.Add(this.groupBox1);
         this._tpSelection.Controls.Add(this._btnEditSelection);
         this._tpSelection.Controls.Add(this._lbSelection);
         this._tpSelection.Location = new System.Drawing.Point(4, 22);
         this._tpSelection.Name = "_tpSelection";
         this._tpSelection.Size = new System.Drawing.Size(274, 177);
         this._tpSelection.TabIndex = 4;
         this._tpSelection.Text = "Single Selection";
         this._tpSelection.UseVisualStyleBackColor = true;
         // 
         // _btnRemoveSelection
         // 
         this._btnRemoveSelection.Location = new System.Drawing.Point(159, 35);
         this._btnRemoveSelection.Name = "_btnRemoveSelection";
         this._btnRemoveSelection.Size = new System.Drawing.Size(97, 25);
         this._btnRemoveSelection.TabIndex = 20;
         this._btnRemoveSelection.Text = "Remove";
         this._btnRemoveSelection.UseVisualStyleBackColor = true;
         this._btnRemoveSelection.Click += new System.EventHandler(this._btnRemoveSelection_Click);
         // 
         // _cbHideSelectionAnn
         // 
         this._cbHideSelectionAnn.Appearance = System.Windows.Forms.Appearance.Button;
         this._cbHideSelectionAnn.AutoSize = true;
         this._cbHideSelectionAnn.Location = new System.Drawing.Point(159, 86);
         this._cbHideSelectionAnn.Name = "_cbHideSelectionAnn";
         this._cbHideSelectionAnn.Size = new System.Drawing.Size(98, 23);
         this._cbHideSelectionAnn.TabIndex = 19;
         this._cbHideSelectionAnn.Text = "Hide Annotations";
         this._cbHideSelectionAnn.UseVisualStyleBackColor = true;
         this._cbHideSelectionAnn.CheckedChanged += new System.EventHandler(this._cbHideSelection_CheckedChanged);
         // 
         // groupBox1
         // 
         this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
         this.groupBox1.Controls.Add(this._tbSelectionHeight);
         this.groupBox1.Controls.Add(this._tbSelectionWidth);
         this.groupBox1.Controls.Add(this.label1);
         this.groupBox1.Controls.Add(this._tbSelectionTop);
         this.groupBox1.Controls.Add(this.label2);
         this.groupBox1.Controls.Add(this._tbSelectionLeft);
         this.groupBox1.Controls.Add(this.label3);
         this.groupBox1.Controls.Add(this.label4);
         this.groupBox1.Location = new System.Drawing.Point(20, 115);
         this.groupBox1.Name = "groupBox1";
         this.groupBox1.Size = new System.Drawing.Size(237, 66);
         this.groupBox1.TabIndex = 18;
         this.groupBox1.TabStop = false;
         this.groupBox1.Text = "Bounds";
         // 
         // _tbSelectionHeight
         // 
         this._tbSelectionHeight.Location = new System.Drawing.Point(170, 38);
         this._tbSelectionHeight.Name = "_tbSelectionHeight";
         this._tbSelectionHeight.ReadOnly = true;
         this._tbSelectionHeight.Size = new System.Drawing.Size(53, 20);
         this._tbSelectionHeight.TabIndex = 5;
         // 
         // _tbSelectionWidth
         // 
         this._tbSelectionWidth.Location = new System.Drawing.Point(170, 13);
         this._tbSelectionWidth.Name = "_tbSelectionWidth";
         this._tbSelectionWidth.ReadOnly = true;
         this._tbSelectionWidth.Size = new System.Drawing.Size(53, 20);
         this._tbSelectionWidth.TabIndex = 3;
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Location = new System.Drawing.Point(129, 41);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(38, 13);
         this.label1.TabIndex = 12;
         this.label1.Text = "Height";
         // 
         // _tbSelectionTop
         // 
         this._tbSelectionTop.Location = new System.Drawing.Point(48, 38);
         this._tbSelectionTop.Name = "_tbSelectionTop";
         this._tbSelectionTop.ReadOnly = true;
         this._tbSelectionTop.Size = new System.Drawing.Size(53, 20);
         this._tbSelectionTop.TabIndex = 4;
         // 
         // label2
         // 
         this.label2.AutoSize = true;
         this.label2.Location = new System.Drawing.Point(129, 16);
         this.label2.Name = "label2";
         this.label2.Size = new System.Drawing.Size(35, 13);
         this.label2.TabIndex = 10;
         this.label2.Text = "Width";
         // 
         // _tbSelectionLeft
         // 
         this._tbSelectionLeft.Location = new System.Drawing.Point(48, 13);
         this._tbSelectionLeft.Name = "_tbSelectionLeft";
         this._tbSelectionLeft.ReadOnly = true;
         this._tbSelectionLeft.Size = new System.Drawing.Size(53, 20);
         this._tbSelectionLeft.TabIndex = 2;
         // 
         // label3
         // 
         this.label3.AutoSize = true;
         this.label3.Location = new System.Drawing.Point(7, 41);
         this.label3.Name = "label3";
         this.label3.Size = new System.Drawing.Size(26, 13);
         this.label3.TabIndex = 8;
         this.label3.Text = "Top";
         // 
         // label4
         // 
         this.label4.AutoSize = true;
         this.label4.Location = new System.Drawing.Point(7, 16);
         this.label4.Name = "label4";
         this.label4.Size = new System.Drawing.Size(25, 13);
         this.label4.TabIndex = 7;
         this.label4.Text = "Left";
         // 
         // _btnEditSelection
         // 
         this._btnEditSelection.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
         this._btnEditSelection.Location = new System.Drawing.Point(159, 6);
         this._btnEditSelection.Name = "_btnEditSelection";
         this._btnEditSelection.Size = new System.Drawing.Size(98, 23);
         this._btnEditSelection.TabIndex = 5;
         this._btnEditSelection.Text = "Edit";
         this._btnEditSelection.UseVisualStyleBackColor = true;
         this._btnEditSelection.Click += new System.EventHandler(this._btnEditSelection_Click);
         // 
         // _lbSelection
         // 
         this._lbSelection.FormattingEnabled = true;
         this._lbSelection.Location = new System.Drawing.Point(3, 6);
         this._lbSelection.Name = "_lbSelection";
         this._lbSelection.Size = new System.Drawing.Size(120, 108);
         this._lbSelection.TabIndex = 4;
         this._lbSelection.SelectedIndexChanged += new System.EventHandler(this._lbSelection_SelectedIndexChanged);
         // 
         // _tpBubble
         // 
         this._tpBubble.Controls.Add(this.groupBox2);
         this._tpBubble.Controls.Add(this._btnRemoveBubble);
         this._tpBubble.Controls.Add(this._cbHideBubbleAnn);
         this._tpBubble.Controls.Add(this._btnEditBubble);
         this._tpBubble.Controls.Add(this._lbBubble);
         this._tpBubble.Location = new System.Drawing.Point(4, 22);
         this._tpBubble.Name = "_tpBubble";
         this._tpBubble.Size = new System.Drawing.Size(274, 177);
         this._tpBubble.TabIndex = 5;
         this._tpBubble.Text = "Bubble Word";
         this._tpBubble.UseVisualStyleBackColor = true;
         // 
         // groupBox2
         // 
         this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
         this.groupBox2.Controls.Add(this._tbBubbleHeight);
         this.groupBox2.Controls.Add(this._tbBubbleWidth);
         this.groupBox2.Controls.Add(this.label5);
         this.groupBox2.Controls.Add(this._tbBubbleTop);
         this.groupBox2.Controls.Add(this.label6);
         this.groupBox2.Controls.Add(this._tbBubbleLeft);
         this.groupBox2.Controls.Add(this.label7);
         this.groupBox2.Controls.Add(this.label8);
         this.groupBox2.Location = new System.Drawing.Point(20, 115);
         this.groupBox2.Name = "groupBox2";
         this.groupBox2.Size = new System.Drawing.Size(237, 66);
         this.groupBox2.TabIndex = 25;
         this.groupBox2.TabStop = false;
         this.groupBox2.Text = "Bounds";
         // 
         // _tbBubbleHeight
         // 
         this._tbBubbleHeight.Location = new System.Drawing.Point(170, 38);
         this._tbBubbleHeight.Name = "_tbBubbleHeight";
         this._tbBubbleHeight.ReadOnly = true;
         this._tbBubbleHeight.Size = new System.Drawing.Size(53, 20);
         this._tbBubbleHeight.TabIndex = 5;
         // 
         // _tbBubbleWidth
         // 
         this._tbBubbleWidth.Location = new System.Drawing.Point(170, 13);
         this._tbBubbleWidth.Name = "_tbBubbleWidth";
         this._tbBubbleWidth.ReadOnly = true;
         this._tbBubbleWidth.Size = new System.Drawing.Size(53, 20);
         this._tbBubbleWidth.TabIndex = 3;
         // 
         // label5
         // 
         this.label5.AutoSize = true;
         this.label5.Location = new System.Drawing.Point(129, 41);
         this.label5.Name = "label5";
         this.label5.Size = new System.Drawing.Size(38, 13);
         this.label5.TabIndex = 12;
         this.label5.Text = "Height";
         // 
         // _tbBubbleTop
         // 
         this._tbBubbleTop.Location = new System.Drawing.Point(48, 38);
         this._tbBubbleTop.Name = "_tbBubbleTop";
         this._tbBubbleTop.ReadOnly = true;
         this._tbBubbleTop.Size = new System.Drawing.Size(53, 20);
         this._tbBubbleTop.TabIndex = 4;
         // 
         // label6
         // 
         this.label6.AutoSize = true;
         this.label6.Location = new System.Drawing.Point(129, 16);
         this.label6.Name = "label6";
         this.label6.Size = new System.Drawing.Size(35, 13);
         this.label6.TabIndex = 10;
         this.label6.Text = "Width";
         // 
         // _tbBubbleLeft
         // 
         this._tbBubbleLeft.Location = new System.Drawing.Point(48, 13);
         this._tbBubbleLeft.Name = "_tbBubbleLeft";
         this._tbBubbleLeft.ReadOnly = true;
         this._tbBubbleLeft.Size = new System.Drawing.Size(53, 20);
         this._tbBubbleLeft.TabIndex = 2;
         // 
         // label7
         // 
         this.label7.AutoSize = true;
         this.label7.Location = new System.Drawing.Point(7, 41);
         this.label7.Name = "label7";
         this.label7.Size = new System.Drawing.Size(26, 13);
         this.label7.TabIndex = 8;
         this.label7.Text = "Top";
         // 
         // label8
         // 
         this.label8.AutoSize = true;
         this.label8.Location = new System.Drawing.Point(7, 16);
         this.label8.Name = "label8";
         this.label8.Size = new System.Drawing.Size(25, 13);
         this.label8.TabIndex = 7;
         this.label8.Text = "Left";
         // 
         // _btnRemoveBubble
         // 
         this._btnRemoveBubble.Location = new System.Drawing.Point(159, 35);
         this._btnRemoveBubble.Name = "_btnRemoveBubble";
         this._btnRemoveBubble.Size = new System.Drawing.Size(97, 25);
         this._btnRemoveBubble.TabIndex = 24;
         this._btnRemoveBubble.Text = "Remove";
         this._btnRemoveBubble.UseVisualStyleBackColor = true;
         this._btnRemoveBubble.Click += new System.EventHandler(this._btnRemoveBubble_Click);
         // 
         // _cbHideBubbleAnn
         // 
         this._cbHideBubbleAnn.Appearance = System.Windows.Forms.Appearance.Button;
         this._cbHideBubbleAnn.AutoSize = true;
         this._cbHideBubbleAnn.Location = new System.Drawing.Point(159, 86);
         this._cbHideBubbleAnn.Name = "_cbHideBubbleAnn";
         this._cbHideBubbleAnn.Size = new System.Drawing.Size(98, 23);
         this._cbHideBubbleAnn.TabIndex = 23;
         this._cbHideBubbleAnn.Text = "Hide Annotations";
         this._cbHideBubbleAnn.UseVisualStyleBackColor = true;
         this._cbHideBubbleAnn.CheckedChanged += new System.EventHandler(this._cbHideBubbleAnn_CheckedChanged);
         // 
         // _btnEditBubble
         // 
         this._btnEditBubble.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
         this._btnEditBubble.Location = new System.Drawing.Point(159, 6);
         this._btnEditBubble.Name = "_btnEditBubble";
         this._btnEditBubble.Size = new System.Drawing.Size(98, 23);
         this._btnEditBubble.TabIndex = 22;
         this._btnEditBubble.Text = "Edit";
         this._btnEditBubble.UseVisualStyleBackColor = true;
         this._btnEditBubble.Click += new System.EventHandler(this._btnEditBubble_Click);
         // 
         // _lbBubble
         // 
         this._lbBubble.FormattingEnabled = true;
         this._lbBubble.Location = new System.Drawing.Point(3, 6);
         this._lbBubble.Name = "_lbBubble";
         this._lbBubble.Size = new System.Drawing.Size(120, 108);
         this._lbBubble.TabIndex = 21;
         this._lbBubble.SelectedIndexChanged += new System.EventHandler(this._lbBubble_SelectedIndexChanged);
         // 
         // _tpAnswerArea
         // 
         this._tpAnswerArea.Controls.Add(this._lbAnswerArea);
         this._tpAnswerArea.Controls.Add(this._btnRemoveAnswerArea);
         this._tpAnswerArea.Controls.Add(this._cbHideAnswerAnn);
         this._tpAnswerArea.Controls.Add(this.groupBox3);
         this._tpAnswerArea.Controls.Add(this._btnEditAnswerArea);
         this._tpAnswerArea.Location = new System.Drawing.Point(4, 22);
         this._tpAnswerArea.Name = "_tpAnswerArea";
         this._tpAnswerArea.Size = new System.Drawing.Size(274, 177);
         this._tpAnswerArea.TabIndex = 6;
         this._tpAnswerArea.Text = "Answer Area";
         this._tpAnswerArea.UseVisualStyleBackColor = true;
         // 
         // _lbAnswerArea
         // 
         this._lbAnswerArea.FormattingEnabled = true;
         this._lbAnswerArea.Location = new System.Drawing.Point(3, 6);
         this._lbAnswerArea.Name = "_lbAnswerArea";
         this._lbAnswerArea.Size = new System.Drawing.Size(120, 108);
         this._lbAnswerArea.TabIndex = 26;
         this._lbAnswerArea.SelectedIndexChanged += new System.EventHandler(this._lbAnswerArea_SelectedIndexChanged);
         // 
         // _btnRemoveAnswerArea
         // 
         this._btnRemoveAnswerArea.Location = new System.Drawing.Point(159, 35);
         this._btnRemoveAnswerArea.Name = "_btnRemoveAnswerArea";
         this._btnRemoveAnswerArea.Size = new System.Drawing.Size(97, 25);
         this._btnRemoveAnswerArea.TabIndex = 29;
         this._btnRemoveAnswerArea.Text = "Remove";
         this._btnRemoveAnswerArea.UseVisualStyleBackColor = true;
         this._btnRemoveAnswerArea.Click += new System.EventHandler(this._btnRemoveAnswerArea_Click);
         // 
         // _cbHideAnswerAnn
         // 
         this._cbHideAnswerAnn.Appearance = System.Windows.Forms.Appearance.Button;
         this._cbHideAnswerAnn.AutoSize = true;
         this._cbHideAnswerAnn.Location = new System.Drawing.Point(159, 86);
         this._cbHideAnswerAnn.Name = "_cbHideAnswerAnn";
         this._cbHideAnswerAnn.Size = new System.Drawing.Size(98, 23);
         this._cbHideAnswerAnn.TabIndex = 28;
         this._cbHideAnswerAnn.Text = "Hide Annotations";
         this._cbHideAnswerAnn.UseVisualStyleBackColor = true;
         this._cbHideAnswerAnn.CheckedChanged += new System.EventHandler(this._cbHideAnswerAnn_CheckedChanged);
         // 
         // groupBox3
         // 
         this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
         this.groupBox3.Controls.Add(this._tbAnswerAreaHeight);
         this.groupBox3.Controls.Add(this._tbAnswerAreaWidth);
         this.groupBox3.Controls.Add(this.label9);
         this.groupBox3.Controls.Add(this._tbAnswerAreaTop);
         this.groupBox3.Controls.Add(this.label10);
         this.groupBox3.Controls.Add(this._tbAnswerAreaLeft);
         this.groupBox3.Controls.Add(this.label11);
         this.groupBox3.Controls.Add(this.label12);
         this.groupBox3.Location = new System.Drawing.Point(20, 115);
         this.groupBox3.Name = "groupBox3";
         this.groupBox3.Size = new System.Drawing.Size(237, 66);
         this.groupBox3.TabIndex = 30;
         this.groupBox3.TabStop = false;
         this.groupBox3.Text = "Bounds";
         // 
         // _tbAnswerAreaHeight
         // 
         this._tbAnswerAreaHeight.Location = new System.Drawing.Point(170, 38);
         this._tbAnswerAreaHeight.Name = "_tbAnswerAreaHeight";
         this._tbAnswerAreaHeight.ReadOnly = true;
         this._tbAnswerAreaHeight.Size = new System.Drawing.Size(53, 20);
         this._tbAnswerAreaHeight.TabIndex = 5;
         // 
         // _tbAnswerAreaWidth
         // 
         this._tbAnswerAreaWidth.Location = new System.Drawing.Point(170, 13);
         this._tbAnswerAreaWidth.Name = "_tbAnswerAreaWidth";
         this._tbAnswerAreaWidth.ReadOnly = true;
         this._tbAnswerAreaWidth.Size = new System.Drawing.Size(53, 20);
         this._tbAnswerAreaWidth.TabIndex = 3;
         // 
         // label9
         // 
         this.label9.AutoSize = true;
         this.label9.Location = new System.Drawing.Point(129, 41);
         this.label9.Name = "label9";
         this.label9.Size = new System.Drawing.Size(38, 13);
         this.label9.TabIndex = 12;
         this.label9.Text = "Height";
         // 
         // _tbAnswerAreaTop
         // 
         this._tbAnswerAreaTop.Location = new System.Drawing.Point(48, 38);
         this._tbAnswerAreaTop.Name = "_tbAnswerAreaTop";
         this._tbAnswerAreaTop.ReadOnly = true;
         this._tbAnswerAreaTop.Size = new System.Drawing.Size(53, 20);
         this._tbAnswerAreaTop.TabIndex = 4;
         // 
         // label10
         // 
         this.label10.AutoSize = true;
         this.label10.Location = new System.Drawing.Point(129, 16);
         this.label10.Name = "label10";
         this.label10.Size = new System.Drawing.Size(35, 13);
         this.label10.TabIndex = 10;
         this.label10.Text = "Width";
         // 
         // _tbAnswerAreaLeft
         // 
         this._tbAnswerAreaLeft.Location = new System.Drawing.Point(48, 13);
         this._tbAnswerAreaLeft.Name = "_tbAnswerAreaLeft";
         this._tbAnswerAreaLeft.ReadOnly = true;
         this._tbAnswerAreaLeft.Size = new System.Drawing.Size(53, 20);
         this._tbAnswerAreaLeft.TabIndex = 2;
         // 
         // label11
         // 
         this.label11.AutoSize = true;
         this.label11.Location = new System.Drawing.Point(7, 41);
         this.label11.Name = "label11";
         this.label11.Size = new System.Drawing.Size(26, 13);
         this.label11.TabIndex = 8;
         this.label11.Text = "Top";
         // 
         // label12
         // 
         this.label12.AutoSize = true;
         this.label12.Location = new System.Drawing.Point(7, 16);
         this.label12.Name = "label12";
         this.label12.Size = new System.Drawing.Size(25, 13);
         this.label12.TabIndex = 7;
         this.label12.Text = "Left";
         // 
         // _btnEditAnswerArea
         // 
         this._btnEditAnswerArea.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
         this._btnEditAnswerArea.Location = new System.Drawing.Point(159, 6);
         this._btnEditAnswerArea.Name = "_btnEditAnswerArea";
         this._btnEditAnswerArea.Size = new System.Drawing.Size(98, 23);
         this._btnEditAnswerArea.TabIndex = 27;
         this._btnEditAnswerArea.Text = "Edit";
         this._btnEditAnswerArea.UseVisualStyleBackColor = true;
         this._btnEditAnswerArea.Click += new System.EventHandler(this._btnEditAnswerArea_Click);
         // 
         // _tpOmrDate
         // 
         this._tpOmrDate.Controls.Add(this._lbOmrDate);
         this._tpOmrDate.Controls.Add(this._btnRemoveOmrDate);
         this._tpOmrDate.Controls.Add(this._cbHideOmrDateAnn);
         this._tpOmrDate.Controls.Add(this.groupBox4);
         this._tpOmrDate.Controls.Add(this._btnEditOmrDate);
         this._tpOmrDate.Location = new System.Drawing.Point(4, 22);
         this._tpOmrDate.Name = "_tpOmrDate";
         this._tpOmrDate.Padding = new System.Windows.Forms.Padding(3);
         this._tpOmrDate.Size = new System.Drawing.Size(274, 177);
         this._tpOmrDate.TabIndex = 7;
         this._tpOmrDate.Text = "Omr Date";
         this._tpOmrDate.UseVisualStyleBackColor = true;
         // 
         // _lbOmrDate
         // 
         this._lbOmrDate.FormattingEnabled = true;
         this._lbOmrDate.Location = new System.Drawing.Point(3, 6);
         this._lbOmrDate.Name = "_lbOmrDate";
         this._lbOmrDate.Size = new System.Drawing.Size(120, 108);
         this._lbOmrDate.TabIndex = 31;
         this._lbOmrDate.SelectedIndexChanged += new System.EventHandler(this._lbOmrDate_SelectedIndexChanged);
         // 
         // _btnRemoveOmrDate
         // 
         this._btnRemoveOmrDate.Location = new System.Drawing.Point(159, 35);
         this._btnRemoveOmrDate.Name = "_btnRemoveOmrDate";
         this._btnRemoveOmrDate.Size = new System.Drawing.Size(97, 25);
         this._btnRemoveOmrDate.TabIndex = 34;
         this._btnRemoveOmrDate.Text = "Remove";
         this._btnRemoveOmrDate.UseVisualStyleBackColor = true;
         this._btnRemoveOmrDate.Click += new System.EventHandler(this._btnRemoveOmrDate_Click);
         // 
         // _cbHideOmrDateAnn
         // 
         this._cbHideOmrDateAnn.Appearance = System.Windows.Forms.Appearance.Button;
         this._cbHideOmrDateAnn.AutoSize = true;
         this._cbHideOmrDateAnn.Location = new System.Drawing.Point(159, 86);
         this._cbHideOmrDateAnn.Name = "_cbHideOmrDateAnn";
         this._cbHideOmrDateAnn.Size = new System.Drawing.Size(98, 23);
         this._cbHideOmrDateAnn.TabIndex = 33;
         this._cbHideOmrDateAnn.Text = "Hide Annotations";
         this._cbHideOmrDateAnn.UseVisualStyleBackColor = true;
         this._cbHideOmrDateAnn.CheckedChanged += new System.EventHandler(this._cbHideOmrDateAnn_CheckedChanged);
         // 
         // groupBox4
         // 
         this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
         this.groupBox4.Controls.Add(this._tbOmrDateHeight);
         this.groupBox4.Controls.Add(this._tbOmrDateWidth);
         this.groupBox4.Controls.Add(this.label13);
         this.groupBox4.Controls.Add(this._tbOmrDateTop);
         this.groupBox4.Controls.Add(this.label14);
         this.groupBox4.Controls.Add(this._tbOmrDateLeft);
         this.groupBox4.Controls.Add(this.label15);
         this.groupBox4.Controls.Add(this.label16);
         this.groupBox4.Location = new System.Drawing.Point(20, 115);
         this.groupBox4.Name = "groupBox4";
         this.groupBox4.Size = new System.Drawing.Size(237, 66);
         this.groupBox4.TabIndex = 35;
         this.groupBox4.TabStop = false;
         this.groupBox4.Text = "Bounds";
         // 
         // _tbOmrDateHeight
         // 
         this._tbOmrDateHeight.Location = new System.Drawing.Point(170, 38);
         this._tbOmrDateHeight.Name = "_tbOmrDateHeight";
         this._tbOmrDateHeight.ReadOnly = true;
         this._tbOmrDateHeight.Size = new System.Drawing.Size(53, 20);
         this._tbOmrDateHeight.TabIndex = 5;
         // 
         // _tbOmrDateWidth
         // 
         this._tbOmrDateWidth.Location = new System.Drawing.Point(170, 13);
         this._tbOmrDateWidth.Name = "_tbOmrDateWidth";
         this._tbOmrDateWidth.ReadOnly = true;
         this._tbOmrDateWidth.Size = new System.Drawing.Size(53, 20);
         this._tbOmrDateWidth.TabIndex = 3;
         // 
         // label13
         // 
         this.label13.AutoSize = true;
         this.label13.Location = new System.Drawing.Point(129, 41);
         this.label13.Name = "label13";
         this.label13.Size = new System.Drawing.Size(38, 13);
         this.label13.TabIndex = 12;
         this.label13.Text = "Height";
         // 
         // _tbOmrDateTop
         // 
         this._tbOmrDateTop.Location = new System.Drawing.Point(48, 38);
         this._tbOmrDateTop.Name = "_tbOmrDateTop";
         this._tbOmrDateTop.ReadOnly = true;
         this._tbOmrDateTop.Size = new System.Drawing.Size(53, 20);
         this._tbOmrDateTop.TabIndex = 4;
         // 
         // label14
         // 
         this.label14.AutoSize = true;
         this.label14.Location = new System.Drawing.Point(129, 16);
         this.label14.Name = "label14";
         this.label14.Size = new System.Drawing.Size(35, 13);
         this.label14.TabIndex = 10;
         this.label14.Text = "Width";
         // 
         // _tbOmrDateLeft
         // 
         this._tbOmrDateLeft.Location = new System.Drawing.Point(48, 13);
         this._tbOmrDateLeft.Name = "_tbOmrDateLeft";
         this._tbOmrDateLeft.ReadOnly = true;
         this._tbOmrDateLeft.Size = new System.Drawing.Size(53, 20);
         this._tbOmrDateLeft.TabIndex = 2;
         // 
         // label15
         // 
         this.label15.AutoSize = true;
         this.label15.Location = new System.Drawing.Point(7, 41);
         this.label15.Name = "label15";
         this.label15.Size = new System.Drawing.Size(26, 13);
         this.label15.TabIndex = 8;
         this.label15.Text = "Top";
         // 
         // label16
         // 
         this.label16.AutoSize = true;
         this.label16.Location = new System.Drawing.Point(7, 16);
         this.label16.Name = "label16";
         this.label16.Size = new System.Drawing.Size(25, 13);
         this.label16.TabIndex = 7;
         this.label16.Text = "Left";
         // 
         // _btnEditOmrDate
         // 
         this._btnEditOmrDate.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
         this._btnEditOmrDate.Location = new System.Drawing.Point(159, 6);
         this._btnEditOmrDate.Name = "_btnEditOmrDate";
         this._btnEditOmrDate.Size = new System.Drawing.Size(98, 23);
         this._btnEditOmrDate.TabIndex = 32;
         this._btnEditOmrDate.Text = "Edit";
         this._btnEditOmrDate.UseVisualStyleBackColor = true;
         this._btnEditOmrDate.Click += new System.EventHandler(this._btnEditOmrDate_Click);
         // 
         // _lbFields
         // 
         this._lbFields.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this._lbFields.FormattingEnabled = true;
         this._lbFields.HorizontalScrollbar = true;
         this._lbFields.Location = new System.Drawing.Point(10, 76);
         this._lbFields.Name = "_lbFields";
         this._lbFields.Size = new System.Drawing.Size(139, 199);
         this._lbFields.Sorted = true;
         this._lbFields.TabIndex = 18;
         this._lbFields.SelectedIndexChanged += new System.EventHandler(this._lbFields_SelectedIndexChanged);
         // 
         // _splViewerList
         // 
         this._splViewerList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
         this._splViewerList.Dock = System.Windows.Forms.DockStyle.Fill;
         this._splViewerList.Location = new System.Drawing.Point(0, 0);
         this._splViewerList.Name = "_splViewerList";
         this._splViewerList.Orientation = System.Windows.Forms.Orientation.Horizontal;
         // 
         // _splViewerList.Panel1
         // 
         this._splViewerList.Panel1.Controls.Add(this._tsViewer);
         this._splViewerList.Size = new System.Drawing.Size(709, 780);
         this._splViewerList.SplitterDistance = 589;
         this._splViewerList.TabIndex = 0;
         // 
         // _tsViewer
         // 
         this._tsViewer.ImageScalingSize = new System.Drawing.Size(20, 20);
         this._tsViewer.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._btnPointerTool,
            this._btnPanTool,
            this.toolStripSeparator7,
            this._btnTableTool,
            this._btnOcrTool,
            this._btnUNOcrTool,
            this._btnOmrTool,
            this._btnOmrHighLevelObjects,
            this._btnBarcodeTool,
            this._btnImageTool,
            this._btnSelectRegion,
            this.toolStripSeparator3,
            this._btnShowFields,
            this.toolStripSeparator4,
            this._btnZoomNormal,
            this._btnFit,
            this._btnFitWidth,
            this._btnZoomIn,
            this._btnZoomOut,
            this._btnZoomDrawTool,
            this._btnUseDpi,
            this.toolStripSeparator2});
         this._tsViewer.Location = new System.Drawing.Point(0, 0);
         this._tsViewer.Name = "_tsViewer";
         this._tsViewer.RightToLeft = System.Windows.Forms.RightToLeft.No;
         this._tsViewer.Size = new System.Drawing.Size(705, 53);
         this._tsViewer.TabIndex = 2;
         this._tsViewer.Text = "toolStrip2";
         // 
         // _btnPointerTool
         // 
         this._btnPointerTool.AutoSize = false;
         this._btnPointerTool.Checked = true;
         this._btnPointerTool.CheckOnClick = true;
         this._btnPointerTool.CheckState = System.Windows.Forms.CheckState.Checked;
         this._btnPointerTool.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this._btnPointerTool.Image = ((System.Drawing.Image)(resources.GetObject("_btnPointerTool.Image")));
         this._btnPointerTool.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
         this._btnPointerTool.ImageTransparentColor = System.Drawing.Color.Magenta;
         this._btnPointerTool.Name = "_btnPointerTool";
         this._btnPointerTool.Size = new System.Drawing.Size(50, 50);
         this._btnPointerTool.Text = "Pointer";
         this._btnPointerTool.Click += new System.EventHandler(this._btnPointerTool_Click);
         // 
         // _btnPanTool
         // 
         this._btnPanTool.AutoSize = false;
         this._btnPanTool.CheckOnClick = true;
         this._btnPanTool.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this._btnPanTool.Image = ((System.Drawing.Image)(resources.GetObject("_btnPanTool.Image")));
         this._btnPanTool.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
         this._btnPanTool.ImageTransparentColor = System.Drawing.Color.Magenta;
         this._btnPanTool.Name = "_btnPanTool";
         this._btnPanTool.Size = new System.Drawing.Size(50, 50);
         this._btnPanTool.Text = "Pan";
         this._btnPanTool.Click += new System.EventHandler(this._btnPanTool_Click);
         // 
         // toolStripSeparator7
         // 
         this.toolStripSeparator7.Name = "toolStripSeparator7";
         this.toolStripSeparator7.Size = new System.Drawing.Size(6, 53);
         // 
         // _btnTableTool
         // 
         this._btnTableTool.AutoSize = false;
         this._btnTableTool.BackColor = System.Drawing.SystemColors.Control;
         this._btnTableTool.CheckOnClick = true;
         this._btnTableTool.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this._btnTableTool.Image = ((System.Drawing.Image)(resources.GetObject("_btnTableTool.Image")));
         this._btnTableTool.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
         this._btnTableTool.ImageTransparentColor = System.Drawing.Color.Magenta;
         this._btnTableTool.Name = "_btnTableTool";
         this._btnTableTool.Size = new System.Drawing.Size(50, 50);
         this._btnTableTool.Text = "Table Field";
         this._btnTableTool.Click += new System.EventHandler(this._btnTableTool_Click);
         // 
         // _btnOcrTool
         // 
         this._btnOcrTool.AutoSize = false;
         this._btnOcrTool.CheckOnClick = true;
         this._btnOcrTool.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this._btnOcrTool.Image = ((System.Drawing.Image)(resources.GetObject("_btnOcrTool.Image")));
         this._btnOcrTool.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
         this._btnOcrTool.ImageTransparentColor = System.Drawing.Color.Magenta;
         this._btnOcrTool.Name = "_btnOcrTool";
         this._btnOcrTool.Size = new System.Drawing.Size(50, 50);
         this._btnOcrTool.Text = "Text Field";
         this._btnOcrTool.Click += new System.EventHandler(this._btnOcrTool_Click);
         // 
         // _btnUNOcrTool
         // 
         this._btnUNOcrTool.AutoSize = false;
         this._btnUNOcrTool.CheckOnClick = true;
         this._btnUNOcrTool.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this._btnUNOcrTool.Image = ((System.Drawing.Image)(resources.GetObject("_btnUNOcrTool.Image")));
         this._btnUNOcrTool.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
         this._btnUNOcrTool.ImageTransparentColor = System.Drawing.Color.Magenta;
         this._btnUNOcrTool.Name = "_btnUNOcrTool";
         this._btnUNOcrTool.Size = new System.Drawing.Size(50, 50);
         this._btnUNOcrTool.Text = "Unstructured Text Field";
         this._btnUNOcrTool.Click += new System.EventHandler(this._btnUNOcrTool_Click);
         // 
         // _btnOmrTool
         // 
         this._btnOmrTool.AutoSize = false;
         this._btnOmrTool.CheckOnClick = true;
         this._btnOmrTool.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this._btnOmrTool.Image = ((System.Drawing.Image)(resources.GetObject("_btnOmrTool.Image")));
         this._btnOmrTool.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
         this._btnOmrTool.ImageTransparentColor = System.Drawing.Color.Magenta;
         this._btnOmrTool.Name = "_btnOmrTool";
         this._btnOmrTool.Size = new System.Drawing.Size(50, 50);
         this._btnOmrTool.Text = "OMR Field";
         this._btnOmrTool.Click += new System.EventHandler(this._btnOmrTool_Click);
         // 
         // _btnOmrHighLevelObjects
         // 
         this._btnOmrHighLevelObjects.AutoSize = false;
         this._btnOmrHighLevelObjects.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this._btnOmrHighLevelObjects.Image = ((System.Drawing.Image)(resources.GetObject("_btnOmrHighLevelObjects.Image")));
         this._btnOmrHighLevelObjects.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
         this._btnOmrHighLevelObjects.ImageTransparentColor = System.Drawing.Color.Magenta;
         this._btnOmrHighLevelObjects.Name = "_btnOmrHighLevelObjects";
         this._btnOmrHighLevelObjects.Size = new System.Drawing.Size(50, 50);
         this._btnOmrHighLevelObjects.Text = "Omr High Level Objects";
         this._btnOmrHighLevelObjects.Click += new System.EventHandler(this._btnOmrHighLevelObjects_Click);
         // 
         // _btnBarcodeTool
         // 
         this._btnBarcodeTool.AutoSize = false;
         this._btnBarcodeTool.CheckOnClick = true;
         this._btnBarcodeTool.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this._btnBarcodeTool.Image = ((System.Drawing.Image)(resources.GetObject("_btnBarcodeTool.Image")));
         this._btnBarcodeTool.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
         this._btnBarcodeTool.ImageTransparentColor = System.Drawing.Color.Magenta;
         this._btnBarcodeTool.Name = "_btnBarcodeTool";
         this._btnBarcodeTool.Size = new System.Drawing.Size(50, 50);
         this._btnBarcodeTool.Text = "Barcode Field";
         this._btnBarcodeTool.Click += new System.EventHandler(this._btnBarcodeTool_Click);
         // 
         // _btnImageTool
         // 
         this._btnImageTool.AutoSize = false;
         this._btnImageTool.CheckOnClick = true;
         this._btnImageTool.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this._btnImageTool.Image = ((System.Drawing.Image)(resources.GetObject("_btnImageTool.Image")));
         this._btnImageTool.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
         this._btnImageTool.ImageTransparentColor = System.Drawing.Color.Magenta;
         this._btnImageTool.Name = "_btnImageTool";
         this._btnImageTool.Size = new System.Drawing.Size(50, 50);
         this._btnImageTool.Text = "Image Field";
         this._btnImageTool.Click += new System.EventHandler(this._btnImageTool_Click);
         // 
         // _btnSelectRegion
         // 
         this._btnSelectRegion.AutoSize = false;
         this._btnSelectRegion.CheckOnClick = true;
         this._btnSelectRegion.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this._btnSelectRegion.Image = ((System.Drawing.Image)(resources.GetObject("_btnSelectRegion.Image")));
         this._btnSelectRegion.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
         this._btnSelectRegion.ImageTransparentColor = System.Drawing.Color.Magenta;
         this._btnSelectRegion.Name = "_btnSelectRegion";
         this._btnSelectRegion.Size = new System.Drawing.Size(50, 50);
         this._btnSelectRegion.Text = "Select Region";
         this._btnSelectRegion.Click += new System.EventHandler(this._btnSelectRegion_Click);
         // 
         // toolStripSeparator3
         // 
         this.toolStripSeparator3.Name = "toolStripSeparator3";
         this.toolStripSeparator3.Size = new System.Drawing.Size(6, 53);
         // 
         // _btnShowFields
         // 
         this._btnShowFields.AutoSize = false;
         this._btnShowFields.Checked = true;
         this._btnShowFields.CheckOnClick = true;
         this._btnShowFields.CheckState = System.Windows.Forms.CheckState.Checked;
         this._btnShowFields.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this._btnShowFields.Image = ((System.Drawing.Image)(resources.GetObject("_btnShowFields.Image")));
         this._btnShowFields.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
         this._btnShowFields.ImageTransparentColor = System.Drawing.Color.Magenta;
         this._btnShowFields.Name = "_btnShowFields";
         this._btnShowFields.Size = new System.Drawing.Size(50, 50);
         this._btnShowFields.Text = "Show/Hide Fields";
         this._btnShowFields.Click += new System.EventHandler(this._btnShowFields_Click);
         // 
         // toolStripSeparator4
         // 
         this.toolStripSeparator4.Name = "toolStripSeparator4";
         this.toolStripSeparator4.Size = new System.Drawing.Size(6, 53);
         // 
         // _btnZoomNormal
         // 
         this._btnZoomNormal.AutoSize = false;
         this._btnZoomNormal.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this._btnZoomNormal.Image = ((System.Drawing.Image)(resources.GetObject("_btnZoomNormal.Image")));
         this._btnZoomNormal.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
         this._btnZoomNormal.ImageTransparentColor = System.Drawing.Color.Magenta;
         this._btnZoomNormal.Name = "_btnZoomNormal";
         this._btnZoomNormal.Size = new System.Drawing.Size(50, 50);
         this._btnZoomNormal.Text = "Normal";
         this._btnZoomNormal.Click += new System.EventHandler(this._btnZoomNormal_Click);
         // 
         // _btnFit
         // 
         this._btnFit.AutoSize = false;
         this._btnFit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this._btnFit.Image = ((System.Drawing.Image)(resources.GetObject("_btnFit.Image")));
         this._btnFit.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
         this._btnFit.ImageTransparentColor = System.Drawing.Color.Magenta;
         this._btnFit.Name = "_btnFit";
         this._btnFit.Size = new System.Drawing.Size(50, 50);
         this._btnFit.Text = "Fit To Window";
         this._btnFit.Click += new System.EventHandler(this._btnFit_Click);
         // 
         // _btnFitWidth
         // 
         this._btnFitWidth.AutoSize = false;
         this._btnFitWidth.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this._btnFitWidth.Image = ((System.Drawing.Image)(resources.GetObject("_btnFitWidth.Image")));
         this._btnFitWidth.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
         this._btnFitWidth.ImageTransparentColor = System.Drawing.Color.Magenta;
         this._btnFitWidth.Name = "_btnFitWidth";
         this._btnFitWidth.Size = new System.Drawing.Size(50, 50);
         this._btnFitWidth.Text = "Fit To Image Width";
         this._btnFitWidth.Click += new System.EventHandler(this._btnFitWidth_Click);
         // 
         // _btnZoomIn
         // 
         this._btnZoomIn.AutoSize = false;
         this._btnZoomIn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this._btnZoomIn.Image = ((System.Drawing.Image)(resources.GetObject("_btnZoomIn.Image")));
         this._btnZoomIn.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
         this._btnZoomIn.ImageTransparentColor = System.Drawing.Color.Magenta;
         this._btnZoomIn.Name = "_btnZoomIn";
         this._btnZoomIn.Size = new System.Drawing.Size(50, 50);
         this._btnZoomIn.Text = "Zoom In";
         this._btnZoomIn.Click += new System.EventHandler(this._btnZoomIn_Click);
         // 
         // _btnZoomOut
         // 
         this._btnZoomOut.AutoSize = false;
         this._btnZoomOut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this._btnZoomOut.Image = ((System.Drawing.Image)(resources.GetObject("_btnZoomOut.Image")));
         this._btnZoomOut.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
         this._btnZoomOut.ImageTransparentColor = System.Drawing.Color.Magenta;
         this._btnZoomOut.Name = "_btnZoomOut";
         this._btnZoomOut.Size = new System.Drawing.Size(50, 50);
         this._btnZoomOut.Text = "Zoom Out";
         this._btnZoomOut.Click += new System.EventHandler(this._btnZoomOut_Click);
         // 
         // _btnZoomDrawTool
         // 
         this._btnZoomDrawTool.AutoSize = false;
         this._btnZoomDrawTool.CheckOnClick = true;
         this._btnZoomDrawTool.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this._btnZoomDrawTool.Image = ((System.Drawing.Image)(resources.GetObject("_btnZoomDrawTool.Image")));
         this._btnZoomDrawTool.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
         this._btnZoomDrawTool.ImageTransparentColor = System.Drawing.Color.Magenta;
         this._btnZoomDrawTool.Name = "_btnZoomDrawTool";
         this._btnZoomDrawTool.Size = new System.Drawing.Size(50, 50);
         this._btnZoomDrawTool.Text = "Zoom To Selection";
         this._btnZoomDrawTool.Click += new System.EventHandler(this._btnZoomDrawTool_Click);
         // 
         // _btnUseDpi
         // 
         this._btnUseDpi.AutoSize = false;
         this._btnUseDpi.Checked = true;
         this._btnUseDpi.CheckOnClick = true;
         this._btnUseDpi.CheckState = System.Windows.Forms.CheckState.Checked;
         this._btnUseDpi.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this._btnUseDpi.Image = ((System.Drawing.Image)(resources.GetObject("_btnUseDpi.Image")));
         this._btnUseDpi.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
         this._btnUseDpi.ImageTransparentColor = System.Drawing.Color.Black;
         this._btnUseDpi.Margin = new System.Windows.Forms.Padding(0);
         this._btnUseDpi.Name = "_btnUseDpi";
         this._btnUseDpi.Size = new System.Drawing.Size(50, 50);
         this._btnUseDpi.Text = "toolStripButton1";
         this._btnUseDpi.ToolTipText = "Ignore Image DPI When Viewing";
         this._btnUseDpi.Click += new System.EventHandler(this._btnUseDpi_Click);
         // 
         // toolStripSeparator2
         // 
         this.toolStripSeparator2.Name = "toolStripSeparator2";
         this.toolStripSeparator2.Size = new System.Drawing.Size(6, 50);
         // 
         // menuStrip1
         // 
         this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._menuItemFile,
            this._menuItemOptions,
            this._menuItemEngine,
            this._menuItemHelp});
         this.menuStrip1.Location = new System.Drawing.Point(0, 0);
         this.menuStrip1.Name = "menuStrip1";
         this.menuStrip1.Size = new System.Drawing.Size(1197, 24);
         this.menuStrip1.TabIndex = 4;
         this.menuStrip1.Text = "menuStrip1";
         // 
         // _menuItemFile
         // 
         this._menuItemFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._menuItemFormSets,
            this._menuItemMasterForms,
            this._menuItemSaveChanges,
            this._menuItemUpdateMasterFormsData,
            this.toolStripMenuItem1,
            this._menuItemLaunchFormsDemo,
            this.toolStripMenuItem2,
            this._menuItemExit});
         this._menuItemFile.Name = "_menuItemFile";
         this._menuItemFile.Size = new System.Drawing.Size(37, 20);
         this._menuItemFile.Text = "File";
         // 
         // _menuItemFormSets
         // 
         this._menuItemFormSets.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._menuItemLoadFormSet,
            this._menuItemAddMasterSetMain,
            this._menuItemSaveFormSetAs});
         this._menuItemFormSets.Name = "_menuItemFormSets";
         this._menuItemFormSets.Size = new System.Drawing.Size(334, 22);
         this._menuItemFormSets.Text = "Form Sets";
         // 
         // _menuItemLoadFormSet
         // 
         this._menuItemLoadFormSet.Name = "_menuItemLoadFormSet";
         this._menuItemLoadFormSet.Size = new System.Drawing.Size(170, 22);
         this._menuItemLoadFormSet.Text = "Load Form Set";
         this._menuItemLoadFormSet.Click += new System.EventHandler(this.LoadFormSet_Click);
         // 
         // _menuItemAddMasterSetMain
         // 
         this._menuItemAddMasterSetMain.Name = "_menuItemAddMasterSetMain";
         this._menuItemAddMasterSetMain.Size = new System.Drawing.Size(170, 22);
         this._menuItemAddMasterSetMain.Text = "Add Form Set";
         this._menuItemAddMasterSetMain.Click += new System.EventHandler(this._menuItemAddMasterSetMain_Click);
         // 
         // _menuItemSaveFormSetAs
         // 
         this._menuItemSaveFormSetAs.Name = "_menuItemSaveFormSetAs";
         this._menuItemSaveFormSetAs.Size = new System.Drawing.Size(170, 22);
         this._menuItemSaveFormSetAs.Text = "Save Form Set As..";
         this._menuItemSaveFormSetAs.Click += new System.EventHandler(this._menuItemSaveFormSetAs_Click);
         // 
         // _menuItemMasterForms
         // 
         this._menuItemMasterForms.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._menuItemAddMasterMain,
            this._menuItemDeleteMasterMain,
            this._menuItemAddMasterPageMain,
            this._menuItemDeleteMasterPageMain,
            this._menuItemAddChildCategoryMain,
            this._menuItemDeleteChildCategoryMain,
            this._menuItemMasterFormPropsMain});
         this._menuItemMasterForms.Name = "_menuItemMasterForms";
         this._menuItemMasterForms.Size = new System.Drawing.Size(334, 22);
         this._menuItemMasterForms.Text = "Master Forms";
         // 
         // _menuItemAddMasterMain
         // 
         this._menuItemAddMasterMain.Name = "_menuItemAddMasterMain";
         this._menuItemAddMasterMain.Size = new System.Drawing.Size(228, 22);
         this._menuItemAddMasterMain.Text = "Add Master Form";
         this._menuItemAddMasterMain.Click += new System.EventHandler(this._menuItemAddMasterMain_Click);
         // 
         // _menuItemDeleteMasterMain
         // 
         this._menuItemDeleteMasterMain.Name = "_menuItemDeleteMasterMain";
         this._menuItemDeleteMasterMain.Size = new System.Drawing.Size(228, 22);
         this._menuItemDeleteMasterMain.Text = "Delete Master Form";
         this._menuItemDeleteMasterMain.Click += new System.EventHandler(this._menuItemDeleteMasterMain_Click);
         // 
         // _menuItemAddMasterPageMain
         // 
         this._menuItemAddMasterPageMain.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._menuItemAddMasterPageDiskMain,
            this._menuItemAddMasterPageScannerMain});
         this._menuItemAddMasterPageMain.Name = "_menuItemAddMasterPageMain";
         this._menuItemAddMasterPageMain.Size = new System.Drawing.Size(228, 22);
         this._menuItemAddMasterPageMain.Text = "Add Master Form Page";
         // 
         // _menuItemAddMasterPageDiskMain
         // 
         this._menuItemAddMasterPageDiskMain.Name = "_menuItemAddMasterPageDiskMain";
         this._menuItemAddMasterPageDiskMain.Size = new System.Drawing.Size(147, 22);
         this._menuItemAddMasterPageDiskMain.Text = "From Disk";
         this._menuItemAddMasterPageDiskMain.Click += new System.EventHandler(this._menuItemAddMasterPageDiskMain_Click);
         // 
         // _menuItemAddMasterPageScannerMain
         // 
         this._menuItemAddMasterPageScannerMain.Name = "_menuItemAddMasterPageScannerMain";
         this._menuItemAddMasterPageScannerMain.Size = new System.Drawing.Size(147, 22);
         this._menuItemAddMasterPageScannerMain.Text = "From Scanner";
         this._menuItemAddMasterPageScannerMain.Click += new System.EventHandler(this._menuItemAddMasterPageScannerMain_Click);
         // 
         // _menuItemDeleteMasterPageMain
         // 
         this._menuItemDeleteMasterPageMain.Name = "_menuItemDeleteMasterPageMain";
         this._menuItemDeleteMasterPageMain.Size = new System.Drawing.Size(228, 22);
         this._menuItemDeleteMasterPageMain.Text = "Delete MasterForm Page";
         this._menuItemDeleteMasterPageMain.Click += new System.EventHandler(this._menuItemDeleteMasterPageMain_Click);
         // 
         // _menuItemAddChildCategoryMain
         // 
         this._menuItemAddChildCategoryMain.Name = "_menuItemAddChildCategoryMain";
         this._menuItemAddChildCategoryMain.Size = new System.Drawing.Size(228, 22);
         this._menuItemAddChildCategoryMain.Text = "Add Master Form Category";
         this._menuItemAddChildCategoryMain.Click += new System.EventHandler(this._menuItemAddChildCategoryMain_Click);
         // 
         // _menuItemDeleteChildCategoryMain
         // 
         this._menuItemDeleteChildCategoryMain.Name = "_menuItemDeleteChildCategoryMain";
         this._menuItemDeleteChildCategoryMain.Size = new System.Drawing.Size(228, 22);
         this._menuItemDeleteChildCategoryMain.Text = "Delete Master Form Category";
         this._menuItemDeleteChildCategoryMain.Click += new System.EventHandler(this._menuItemDeleteChildCategoryMain_Click);
         // 
         // _menuItemMasterFormPropsMain
         // 
         this._menuItemMasterFormPropsMain.Name = "_menuItemMasterFormPropsMain";
         this._menuItemMasterFormPropsMain.Size = new System.Drawing.Size(228, 22);
         this._menuItemMasterFormPropsMain.Text = "Master Form Properties";
         this._menuItemMasterFormPropsMain.Click += new System.EventHandler(this._menuItemMasterFormPropsMain_Click);
         // 
         // _menuItemSaveChanges
         // 
         this._menuItemSaveChanges.Name = "_menuItemSaveChanges";
         this._menuItemSaveChanges.Size = new System.Drawing.Size(334, 22);
         this._menuItemSaveChanges.Text = "Save Changes";
         this._menuItemSaveChanges.Click += new System.EventHandler(this._menuItemSaveChanges_Click);
         // 
         // _menuItemUpdateMasterFormsData
         // 
         this._menuItemUpdateMasterFormsData.Name = "_menuItemUpdateMasterFormsData";
         this._menuItemUpdateMasterFormsData.Size = new System.Drawing.Size(334, 22);
         this._menuItemUpdateMasterFormsData.Text = "&Update Master Forms Data";
         this._menuItemUpdateMasterFormsData.Click += new System.EventHandler(this._menuItemUpdateMasterFormsData_Click);
         // 
         // toolStripMenuItem1
         // 
         this.toolStripMenuItem1.Name = "toolStripMenuItem1";
         this.toolStripMenuItem1.Size = new System.Drawing.Size(331, 6);
         // 
         // _menuItemLaunchFormsDemo
         // 
         this._menuItemLaunchFormsDemo.Name = "_menuItemLaunchFormsDemo";
         this._menuItemLaunchFormsDemo.Size = new System.Drawing.Size(334, 22);
         this._menuItemLaunchFormsDemo.Text = "Launch Forms Recognition and Processing Demo";
         this._menuItemLaunchFormsDemo.Click += new System.EventHandler(this._menuItemLaunchFormsDemo_Click);
         // 
         // toolStripMenuItem2
         // 
         this.toolStripMenuItem2.Name = "toolStripMenuItem2";
         this.toolStripMenuItem2.Size = new System.Drawing.Size(331, 6);
         // 
         // _menuItemExit
         // 
         this._menuItemExit.Name = "_menuItemExit";
         this._menuItemExit.Size = new System.Drawing.Size(334, 22);
         this._menuItemExit.Text = "Exit";
         this._menuItemExit.Click += new System.EventHandler(this._menuItemExit_Click);
         // 
         // _menuItemOptions
         // 
         this._menuItemOptions.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._menuItemObjectManagers,
            this._menuItemIncludeExcludeRegions,
            this.pageTypeToolStripMenuItem,
            this.omrToolStripMenuItem});
         this._menuItemOptions.Name = "_menuItemOptions";
         this._menuItemOptions.Size = new System.Drawing.Size(61, 20);
         this._menuItemOptions.Text = "Options";
         // 
         // _menuItemObjectManagers
         // 
         this._menuItemObjectManagers.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._menuItemOCRManager,
            this._menuItemBarcodeManager,
            this._menuItemDefaultManager});
         this._menuItemObjectManagers.Name = "_menuItemObjectManagers";
         this._menuItemObjectManagers.Size = new System.Drawing.Size(308, 22);
         this._menuItemObjectManagers.Text = "Object Managers";
         // 
         // _menuItemOCRManager
         // 
         this._menuItemOCRManager.Checked = true;
         this._menuItemOCRManager.CheckOnClick = true;
         this._menuItemOCRManager.CheckState = System.Windows.Forms.CheckState.Checked;
         this._menuItemOCRManager.Name = "_menuItemOCRManager";
         this._menuItemOCRManager.Size = new System.Drawing.Size(162, 22);
         this._menuItemOCRManager.Text = "OCR Manager";
         this._menuItemOCRManager.Click += new System.EventHandler(this.RecognitionOptionsChanged);
         // 
         // _menuItemBarcodeManager
         // 
         this._menuItemBarcodeManager.CheckOnClick = true;
         this._menuItemBarcodeManager.Name = "_menuItemBarcodeManager";
         this._menuItemBarcodeManager.Size = new System.Drawing.Size(162, 22);
         this._menuItemBarcodeManager.Text = "Barcode Manger";
         this._menuItemBarcodeManager.Click += new System.EventHandler(this.RecognitionOptionsChanged);
         // 
         // _menuItemDefaultManager
         // 
         this._menuItemDefaultManager.CheckOnClick = true;
         this._menuItemDefaultManager.Name = "_menuItemDefaultManager";
         this._menuItemDefaultManager.Size = new System.Drawing.Size(162, 22);
         this._menuItemDefaultManager.Text = "Default Manager";
         this._menuItemDefaultManager.Click += new System.EventHandler(this.RecognitionOptionsChanged);
         // 
         // _menuItemIncludeExcludeRegions
         // 
         this._menuItemIncludeExcludeRegions.Name = "_menuItemIncludeExcludeRegions";
         this._menuItemIncludeExcludeRegions.Size = new System.Drawing.Size(308, 22);
         this._menuItemIncludeExcludeRegions.Text = "Select Interest, Include, And Exclude Regions";
         this._menuItemIncludeExcludeRegions.Click += new System.EventHandler(this.SelectRegions_Click);
         // 
         // pageTypeToolStripMenuItem
         // 
         this.pageTypeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.normalItem,
            this.cardItem,
            this.omrItem});
         this.pageTypeToolStripMenuItem.Name = "pageTypeToolStripMenuItem";
         this.pageTypeToolStripMenuItem.Size = new System.Drawing.Size(308, 22);
         this.pageTypeToolStripMenuItem.Text = "Page Type";
         // 
         // normalItem
         // 
         this.normalItem.Name = "normalItem";
         this.normalItem.Size = new System.Drawing.Size(114, 22);
         this.normalItem.Text = "Normal";
         this.normalItem.Click += new System.EventHandler(this.PageTypeToolStripMenuItem_Click);
         // 
         // cardItem
         // 
         this.cardItem.Name = "cardItem";
         this.cardItem.Size = new System.Drawing.Size(114, 22);
         this.cardItem.Text = "Card";
         this.cardItem.Click += new System.EventHandler(this.PageTypeToolStripMenuItem_Click);
         // 
         // omrItem
         // 
         this.omrItem.Name = "omrItem";
         this.omrItem.Size = new System.Drawing.Size(114, 22);
         this.omrItem.Text = "Omr";
         this.omrItem.Click += new System.EventHandler(this.PageTypeToolStripMenuItem_Click);
         // 
         // omrToolStripMenuItem
         // 
         this.omrToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._miDetectOmrFields,
            this._miDeleteOmrFields,
            this._miRenameOmr,
            this._miSetOmrSensitivity});
         this.omrToolStripMenuItem.Name = "omrToolStripMenuItem";
         this.omrToolStripMenuItem.Size = new System.Drawing.Size(308, 22);
         this.omrToolStripMenuItem.Text = "Omr";
         // 
         // _miDetectOmrFields
         // 
         this._miDetectOmrFields.Name = "_miDetectOmrFields";
         this._miDetectOmrFields.Size = new System.Drawing.Size(233, 22);
         this._miDetectOmrFields.Text = "Auto Detect Omr Fields...";
         this._miDetectOmrFields.Click += new System.EventHandler(this._miDetectOmrFields_Click);
         // 
         // _miDeleteOmrFields
         // 
         this._miDeleteOmrFields.Name = "_miDeleteOmrFields";
         this._miDeleteOmrFields.Size = new System.Drawing.Size(233, 22);
         this._miDeleteOmrFields.Text = "Delete Multiple Omr Fields";
         this._miDeleteOmrFields.Click += new System.EventHandler(this._miDeleteOmrFields_Click);
         // 
         // _miRenameOmr
         // 
         this._miRenameOmr.Name = "_miRenameOmr";
         this._miRenameOmr.Size = new System.Drawing.Size(233, 22);
         this._miRenameOmr.Text = "Rename Multiple Omr Fields...";
         this._miRenameOmr.Click += new System.EventHandler(this._miRenameOmrFields_Click);
         // 
         // _miSetOmrSensitivity
         // 
         this._miSetOmrSensitivity.Name = "_miSetOmrSensitivity";
         this._miSetOmrSensitivity.Size = new System.Drawing.Size(233, 22);
         this._miSetOmrSensitivity.Text = "Set Omr Fields Sensitivity...";
         this._miSetOmrSensitivity.Click += new System.EventHandler(this._miSetOmrSensitivity_Click);
         // 
         // _menuItemEngine
         // 
         this._menuItemEngine.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._menuItemLanguages,
            this._menuItemComponents});
         this._menuItemEngine.Name = "_menuItemEngine";
         this._menuItemEngine.Size = new System.Drawing.Size(55, 20);
         this._menuItemEngine.Text = "Engine";
         // 
         // _menuItemLanguages
         // 
         this._menuItemLanguages.Name = "_menuItemLanguages";
         this._menuItemLanguages.Size = new System.Drawing.Size(143, 22);
         this._menuItemLanguages.Text = "Languages";
         this._menuItemLanguages.Click += new System.EventHandler(this._menuItemLanguages_Click);
         // 
         // _menuItemComponents
         // 
         this._menuItemComponents.Name = "_menuItemComponents";
         this._menuItemComponents.Size = new System.Drawing.Size(143, 22);
         this._menuItemComponents.Text = "Components";
         this._menuItemComponents.Click += new System.EventHandler(this._menuItemComponents_Click);
         // 
         // _menuItemHelp
         // 
         this._menuItemHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._menuItemInformation,
            this._menuItemHowTo,
            this._menuItemAbout});
         this._menuItemHelp.Name = "_menuItemHelp";
         this._menuItemHelp.Size = new System.Drawing.Size(44, 20);
         this._menuItemHelp.Text = "Help";
         // 
         // _menuItemInformation
         // 
         this._menuItemInformation.Name = "_menuItemInformation";
         this._menuItemInformation.Size = new System.Drawing.Size(205, 22);
         this._menuItemInformation.Text = "&Update Data Information";
         this._menuItemInformation.Click += new System.EventHandler(this._menuItemInformation_Click);
         // 
         // _menuItemHowTo
         // 
         this._menuItemHowTo.Name = "_menuItemHowTo";
         this._menuItemHowTo.Size = new System.Drawing.Size(205, 22);
         this._menuItemHowTo.Text = "How To";
         this._menuItemHowTo.Click += new System.EventHandler(this._menuItemHowTo_Click);
         // 
         // _menuItemAbout
         // 
         this._menuItemAbout.Name = "_menuItemAbout";
         this._menuItemAbout.Size = new System.Drawing.Size(205, 22);
         this._menuItemAbout.Text = "About";
         this._menuItemAbout.Click += new System.EventHandler(this._menuItemAbout_Click);
         // 
         // test1ToolStripMenuItem
         // 
         this.test1ToolStripMenuItem.Name = "test1ToolStripMenuItem";
         this.test1ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
         this.test1ToolStripMenuItem.Text = "test1";
         // 
         // test2ToolStripMenuItem
         // 
         this.test2ToolStripMenuItem.Name = "test2ToolStripMenuItem";
         this.test2ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
         this.test2ToolStripMenuItem.Text = "test2";
         // 
         // _cmHighLevelObjects
         // 
         this._cmHighLevelObjects.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._miSingleSelectionField,
            this._miBubbleWordField,
            this._miAnswerAreaField,
            this._miOmrDateField});
         this._cmHighLevelObjects.Name = "_cmHighLevelObjects";
         this._cmHighLevelObjects.Size = new System.Drawing.Size(186, 92);
         // 
         // _miSingleSelectionField
         // 
         this._miSingleSelectionField.Name = "_miSingleSelectionField";
         this._miSingleSelectionField.Size = new System.Drawing.Size(185, 22);
         this._miSingleSelectionField.Text = "&Single Selection Field";
         this._miSingleSelectionField.Click += new System.EventHandler(this._miSingleSelectionField_Click);
         // 
         // _miBubbleWordField
         // 
         this._miBubbleWordField.Name = "_miBubbleWordField";
         this._miBubbleWordField.Size = new System.Drawing.Size(185, 22);
         this._miBubbleWordField.Text = "&Bubble Word Field";
         this._miBubbleWordField.Click += new System.EventHandler(this._miBubbleWordField_Click);
         // 
         // _miAnswerAreaField
         // 
         this._miAnswerAreaField.Name = "_miAnswerAreaField";
         this._miAnswerAreaField.Size = new System.Drawing.Size(185, 22);
         this._miAnswerAreaField.Text = "&Answer Area Field";
         this._miAnswerAreaField.Click += new System.EventHandler(this._miAnswerAreaField_Click);
         // 
         // _miOmrDateField
         // 
         this._miOmrDateField.Name = "_miOmrDateField";
         this._miOmrDateField.Size = new System.Drawing.Size(185, 22);
         this._miOmrDateField.Text = "Omr &Date Field";
         this._miOmrDateField.Click += new System.EventHandler(this._miOmrDateField_Click);
         // 
         // MainForm
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(1197, 804);
         this.Controls.Add(this._splMain);
         this.Controls.Add(this.menuStrip1);
         this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
         this.MainMenuStrip = this.menuStrip1;
         this.Name = "MainForm";
         this.Text = "LEADTOOLS Master Form Editor";
         this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
         this._splMain.Panel1.ResumeLayout(false);
         this._splMain.Panel2.ResumeLayout(false);
         ((System.ComponentModel.ISupportInitialize)(this._splMain)).EndInit();
         this._splMain.ResumeLayout(false);
         this._splFormsViewer.Panel1.ResumeLayout(false);
         this._splFormsViewer.Panel1.PerformLayout();
         this._splFormsViewer.Panel2.ResumeLayout(false);
         this._splFormsViewer.Panel2.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this._splFormsViewer)).EndInit();
         this._splFormsViewer.ResumeLayout(false);
         this._tsForms.ResumeLayout(false);
         this._tsForms.PerformLayout();
         this._tsFields.ResumeLayout(false);
         this._tsFields.PerformLayout();
         this._tcFieldProps.ResumeLayout(false);
         this._tpFieldInfo.ResumeLayout(false);
         this._tpFieldInfo.PerformLayout();
         this._gbBounds.ResumeLayout(false);
         this._gbBounds.PerformLayout();
         this._tpOCR.ResumeLayout(false);
         this._gbDropoutOptions.ResumeLayout(false);
         this._gbDropoutOptions.PerformLayout();
         this._gbFieldMethod.ResumeLayout(false);
         this._gbFieldMethod.PerformLayout();
         this._gbFieldTextType.ResumeLayout(false);
         this._gbFieldTextType.PerformLayout();
         this._tpOMR.ResumeLayout(false);
         this._gbOMRFrame.ResumeLayout(false);
         this._gbOMRFrame.PerformLayout();
         this._gbOMRSensitivity.ResumeLayout(false);
         this._gbOMRSensitivity.PerformLayout();
         this._tpTable.ResumeLayout(false);
         this._gb_ColumnOcr.ResumeLayout(false);
         this._gb_ColumnOcr.PerformLayout();
         this._tpSelection.ResumeLayout(false);
         this._tpSelection.PerformLayout();
         this.groupBox1.ResumeLayout(false);
         this.groupBox1.PerformLayout();
         this._tpBubble.ResumeLayout(false);
         this._tpBubble.PerformLayout();
         this.groupBox2.ResumeLayout(false);
         this.groupBox2.PerformLayout();
         this._tpAnswerArea.ResumeLayout(false);
         this._tpAnswerArea.PerformLayout();
         this.groupBox3.ResumeLayout(false);
         this.groupBox3.PerformLayout();
         this._tpOmrDate.ResumeLayout(false);
         this._tpOmrDate.PerformLayout();
         this.groupBox4.ResumeLayout(false);
         this.groupBox4.PerformLayout();
         this._splViewerList.Panel1.ResumeLayout(false);
         this._splViewerList.Panel1.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this._splViewerList)).EndInit();
         this._splViewerList.ResumeLayout(false);
         this._tsViewer.ResumeLayout(false);
         this._tsViewer.PerformLayout();
         this.menuStrip1.ResumeLayout(false);
         this.menuStrip1.PerformLayout();
         this._cmHighLevelObjects.ResumeLayout(false);
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.SplitContainer _splMain;
      private System.Windows.Forms.SplitContainer _splFormsViewer;
      private System.Windows.Forms.SplitContainer _splViewerList;
      private System.Windows.Forms.ToolStrip _tsForms;
      private System.Windows.Forms.TreeView _tvMasterForms;
      private System.Windows.Forms.ToolStrip _tsViewer;
      private System.Windows.Forms.GroupBox _gbBounds;
      private System.Windows.Forms.TextBox _txtFieldHeight;
      private System.Windows.Forms.TextBox _txtFieldWidth;
      private System.Windows.Forms.Label _lblFieldHeight;
      private System.Windows.Forms.TextBox _txtFieldTop;
      private System.Windows.Forms.Label _lblFieldWidth;
      private System.Windows.Forms.TextBox _txtFieldLeft;
      private System.Windows.Forms.Label _lblFieldTop;
      private System.Windows.Forms.Label _lblFieldLeft;
      private System.Windows.Forms.GroupBox _gbFieldTextType;
      private System.Windows.Forms.RadioButton _rbtextTypeNum;
      private System.Windows.Forms.RadioButton _rbTextTypeChar;
      private System.Windows.Forms.GroupBox _gbFieldMethod;
      private System.Windows.Forms.CheckBox _chkEnableIcr;
      private System.Windows.Forms.CheckBox _chkEnableOcr;
      private System.Windows.Forms.ListBox _lbFields;
      private System.Windows.Forms.ToolStripButton _btnLoadFormSet;
      private System.Windows.Forms.ToolStripButton _btnSaveMasterFormsAs;
      private System.Windows.Forms.ToolStripDropDownButton _btnAddMasterMenu;
      private System.Windows.Forms.ToolStripDropDownButton _btnDeleteMasterMenu;
      private System.Windows.Forms.ToolStripButton _btnPointerTool;
      private System.Windows.Forms.ToolStripButton _btnPanTool;
      private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
      private System.Windows.Forms.ToolStripButton _btnOcrTool;
      private System.Windows.Forms.ToolStripButton _btnUNOcrTool;
      private System.Windows.Forms.ToolStripButton _btnOmrTool;
      private System.Windows.Forms.ToolStripButton _btnBarcodeTool;
      private System.Windows.Forms.ToolStripButton _btnImageTool;
      private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
      private System.Windows.Forms.ToolStripButton _btnShowFields;
      private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
      private System.Windows.Forms.ToolStripButton _btnZoomNormal;
      private System.Windows.Forms.ToolStripButton _btnFit;
      private System.Windows.Forms.ToolStripButton _btnFitWidth;
      private System.Windows.Forms.ToolStripButton _btnZoomIn;
      private System.Windows.Forms.ToolStripButton _btnZoomOut;
      private System.Windows.Forms.ToolStripButton _btnZoomDrawTool;
      private System.Windows.Forms.ToolStripButton _btnUseDpi;
      private System.Windows.Forms.MenuStrip menuStrip1;
      private System.Windows.Forms.ToolStripButton _btnCutField;
      private System.Windows.Forms.ToolStripButton _btnCopyField;
      private System.Windows.Forms.ToolStripButton _btnPasteField;
      private System.Windows.Forms.ToolStripButton _btnDeleteField;
      private System.Windows.Forms.TabControl _tcFieldProps;
      private System.Windows.Forms.TabPage _tpFieldInfo;
      private System.Windows.Forms.TabPage _tpOCR;
      private System.Windows.Forms.ComboBox _cmbFieldType;
      private System.Windows.Forms.Label _lblFieldType;
      private System.Windows.Forms.TextBox _txtFieldName;
      private System.Windows.Forms.Label _lblFieldName;
      private System.Windows.Forms.TabPage _tpOMR;
      private System.Windows.Forms.GroupBox _gbOMRFrame;
      private System.Windows.Forms.GroupBox _gbOMRSensitivity;
      private System.Windows.Forms.RadioButton _rbOMRSensitivityLowest;
      private System.Windows.Forms.RadioButton _rbOMRSensitivityLow;
      private System.Windows.Forms.Button _btnApply;
      private System.Windows.Forms.ToolStripMenuItem _menuItemFile;
      private System.Windows.Forms.ToolStripMenuItem _menuItemFormSets;
      private System.Windows.Forms.ToolStripMenuItem _menuItemLoadFormSet;
      private System.Windows.Forms.ToolStripMenuItem _menuItemAddMasterSetMain;
      private System.Windows.Forms.ToolStripMenuItem _menuItemMasterForms;
      private System.Windows.Forms.ToolStripMenuItem _menuItemDeleteMasterMain;
      private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
      private System.Windows.Forms.ToolStripMenuItem _menuItemSaveFormSetAs;
      private System.Windows.Forms.ToolStripMenuItem _menuItemOptions;
      private System.Windows.Forms.ToolStripMenuItem _menuItemHelp;
      private System.Windows.Forms.ToolStripMenuItem _menuItemHowTo;
      private System.Windows.Forms.ToolStripMenuItem _menuItemAbout;
      private System.Windows.Forms.RadioButton _rbOMRSensitivityHigh;
      private System.Windows.Forms.Label _lblMasterFormFields;
      private System.Windows.Forms.ToolStripMenuItem test1ToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem test2ToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _menuItemAddMasterMain;
      private System.Windows.Forms.ToolStripMenuItem _menuItemAddMasterPageMain;
      private System.Windows.Forms.ToolStripMenuItem _menuItemDeleteMasterPageMain;
      private System.Windows.Forms.ToolStripMenuItem _menuItemAddMaster;
      private System.Windows.Forms.ToolStripMenuItem _menuItemDeleteMaster;
      private System.Windows.Forms.ToolStripMenuItem _menuItemAddMasterPage;
      private System.Windows.Forms.ToolStripMenuItem _menuItemDeleteMasterPage;
      private System.Windows.Forms.ToolStripMenuItem _menuItemAddChildCategory;
      private System.Windows.Forms.ToolStripMenuItem _menuItemDeleteChildCategory;
      private System.Windows.Forms.ToolStripMenuItem _menuItemAddMasterSet;
      private System.Windows.Forms.ToolStripMenuItem _menuItemAddChildCategoryMain;
      private System.Windows.Forms.ToolStripMenuItem _menuItemDeleteChildCategoryMain;
      private System.Windows.Forms.ToolStripMenuItem _menuItemAddMasterPageDisk;
      private System.Windows.Forms.ToolStripMenuItem _menuItemAddMasterPageScanner;
      private System.Windows.Forms.ToolStripMenuItem _menuItemAddMasterPageDiskMain;
      private System.Windows.Forms.ToolStripMenuItem _menuItemAddMasterPageScannerMain;
      private System.Windows.Forms.ToolStripMenuItem _menuItemExit;
      private System.Windows.Forms.ToolStripMenuItem _menuItemObjectManagers;
      private System.Windows.Forms.ToolStripMenuItem _menuItemDefaultManager;
      private System.Windows.Forms.ToolStripMenuItem _menuItemOCRManager;
      private System.Windows.Forms.ToolStripMenuItem _menuItemBarcodeManager;
      private System.Windows.Forms.ToolStripMenuItem _menuItemIncludeExcludeRegions;
      private System.Windows.Forms.RadioButton _rbOMRWithoutFrame;
      private System.Windows.Forms.RadioButton _rbOMRWithFrame;
      private System.Windows.Forms.RadioButton _rbOMRAutoFrame;
      private System.Windows.Forms.RadioButton _rbOMRSensitivityHighest;
      private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
      private System.Windows.Forms.ToolStripButton _btnSelectRegion;
      private System.Windows.Forms.ToolStrip _tsFields;
      private System.Windows.Forms.ToolStripButton _btnMasterFormProps;
      private System.Windows.Forms.ToolStripMenuItem _menuItemMasterFormPropsMain;
      private System.Windows.Forms.ToolStripMenuItem _menuItemLaunchFormsDemo;
      private System.Windows.Forms.ToolStripMenuItem _menuItemLanguages;
      private System.Windows.Forms.ToolStripMenuItem _menuItemComponents;
      private System.Windows.Forms.ToolStripMenuItem _menuItemEngine;
      private System.Windows.Forms.ToolStripButton _btnTableTool;
      private System.Windows.Forms.TabPage _tpTable;
      private System.Windows.Forms.GroupBox _gb_ColumnOcr;
      private System.Windows.Forms.Button _btn_RemoveColumn;
      private System.Windows.Forms.Button _btn_AddColumn;
      private System.Windows.Forms.ListBox _lbColumns;
      private System.Windows.Forms.RadioButton _rB_ColumnOmr;
      private System.Windows.Forms.RadioButton _rB_ColumnOcr;
      private System.Windows.Forms.Button _btn_ColumnOptions;
      private System.Windows.Forms.GroupBox _gbDropoutOptions;
      private System.Windows.Forms.CheckBox _chkDropoutCells;
      private System.Windows.Forms.CheckBox _chkDropoutWords;
      private System.Windows.Forms.Button _btn_Rules;
      private System.Windows.Forms.ToolStripMenuItem pageTypeToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem normalItem;
      private System.Windows.Forms.ToolStripMenuItem cardItem;
      private System.Windows.Forms.ToolStripMenuItem _menuItemSaveChanges;
      private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
      private System.Windows.Forms.ToolStripMenuItem _menuItemUpdateMasterFormsData;
      private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
      private System.Windows.Forms.ToolStripMenuItem _menuItemInformation;
      private System.Windows.Forms.RadioButton _rbtextTypeData;
      private System.Windows.Forms.ToolStripMenuItem omrItem;
      private System.Windows.Forms.TabPage _tpSelection;
      private System.Windows.Forms.ListBox _lbSelection;
      private System.Windows.Forms.Button _btnRemoveSelection;
      private System.Windows.Forms.CheckBox _cbHideSelectionAnn;
      private System.Windows.Forms.GroupBox groupBox1;
      private System.Windows.Forms.TextBox _tbSelectionHeight;
      private System.Windows.Forms.TextBox _tbSelectionWidth;
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.TextBox _tbSelectionTop;
      private System.Windows.Forms.Label label2;
      private System.Windows.Forms.TextBox _tbSelectionLeft;
      private System.Windows.Forms.Label label3;
      private System.Windows.Forms.Label label4;
      private System.Windows.Forms.Button _btnEditSelection;
      private System.Windows.Forms.ToolStripButton _btnOmrHighLevelObjects;
      private System.Windows.Forms.TabPage _tpBubble;
      private System.Windows.Forms.GroupBox groupBox2;
      private System.Windows.Forms.TextBox _tbBubbleHeight;
      private System.Windows.Forms.TextBox _tbBubbleWidth;
      private System.Windows.Forms.Label label5;
      private System.Windows.Forms.TextBox _tbBubbleTop;
      private System.Windows.Forms.Label label6;
      private System.Windows.Forms.TextBox _tbBubbleLeft;
      private System.Windows.Forms.Label label7;
      private System.Windows.Forms.Label label8;
      private System.Windows.Forms.Button _btnRemoveBubble;
      private System.Windows.Forms.CheckBox _cbHideBubbleAnn;
      private System.Windows.Forms.Button _btnEditBubble;
      private System.Windows.Forms.ListBox _lbBubble;
#if LEADTOOLS_V20_OR_LATER
      private System.Windows.Forms.TabPage _tpAnswerArea;
      private System.Windows.Forms.ListBox _lbAnswerArea;
      private System.Windows.Forms.Button _btnRemoveAnswerArea;
      private System.Windows.Forms.CheckBox _cbHideAnswerAnn;
      private System.Windows.Forms.GroupBox groupBox3;
      private System.Windows.Forms.TextBox _tbAnswerAreaHeight;
      private System.Windows.Forms.TextBox _tbAnswerAreaWidth;
      private System.Windows.Forms.Label label9;
      private System.Windows.Forms.TextBox _tbAnswerAreaTop;
      private System.Windows.Forms.Label label10;
      private System.Windows.Forms.TextBox _tbAnswerAreaLeft;
      private System.Windows.Forms.Label label11;
      private System.Windows.Forms.Label label12;
      private System.Windows.Forms.Button _btnEditAnswerArea;
      private System.Windows.Forms.TabPage _tpOmrDate;
      private System.Windows.Forms.ListBox _lbOmrDate;
      private System.Windows.Forms.Button _btnRemoveOmrDate;
      private System.Windows.Forms.CheckBox _cbHideOmrDateAnn;
      private System.Windows.Forms.GroupBox groupBox4;
      private System.Windows.Forms.TextBox _tbOmrDateHeight;
      private System.Windows.Forms.TextBox _tbOmrDateWidth;
      private System.Windows.Forms.Label label13;
      private System.Windows.Forms.TextBox _tbOmrDateTop;
      private System.Windows.Forms.Label label14;
      private System.Windows.Forms.TextBox _tbOmrDateLeft;
      private System.Windows.Forms.Label label15;
      private System.Windows.Forms.Label label16;
      private System.Windows.Forms.Button _btnEditOmrDate;
#endif //#if LEADTOOLS_V20_OR_LATER
      private System.Windows.Forms.ToolStripMenuItem omrToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _miDetectOmrFields;
      private System.Windows.Forms.ToolStripMenuItem _miDeleteOmrFields;
      private System.Windows.Forms.ToolStripMenuItem _miRenameOmr;
      private System.Windows.Forms.ToolStripMenuItem _miSetOmrSensitivity;
      private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
      private System.Windows.Forms.ToolStripButton _useFullTextSearchButton;
      private System.Windows.Forms.ContextMenuStrip _cmHighLevelObjects;
      private System.Windows.Forms.ToolStripMenuItem _miSingleSelectionField;
      private System.Windows.Forms.ToolStripMenuItem _miBubbleWordField;
#if LEADTOOLS_V20_OR_LATER
      private System.Windows.Forms.ToolStripMenuItem _miAnswerAreaField;
      private System.Windows.Forms.ToolStripMenuItem _miOmrDateField;
#endif //#if LEADTOOLS_V20_OR_LATER
   }
}


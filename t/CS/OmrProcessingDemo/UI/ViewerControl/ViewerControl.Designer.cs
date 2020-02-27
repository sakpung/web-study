namespace OmrProcessingDemo.ViewerControl
{
   partial class ViewerControl
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
         if(disposing && (components != null))
         {
            components.Dispose();
         }
         base.Dispose(disposing);
      }

      #region Component Designer generated code

      /// <summary> 
      /// Required method for Designer support - do not modify 
      /// the contents of this method with the code editor.
      /// </summary>
      private void InitializeComponent()
      {
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ViewerControl));
         this._titleLabel = new System.Windows.Forms.Label();
         this._toolStrip = new System.Windows.Forms.ToolStrip();
         this._pageToolStripTextBox = new System.Windows.Forms.ToolStripTextBox();
         this._pageToolStripLabel = new System.Windows.Forms.ToolStripLabel();
         this._toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
         this._zoomToolStripComboBox = new System.Windows.Forms.ToolStripComboBox();
         this._toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
         this._toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
         this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
         this._rasterImageViewer = new Leadtools.Annotations.WinForms.AutomationImageViewer();
         this._splitContainer = new System.Windows.Forms.SplitContainer();
         this._mousePositionLabel = new System.Windows.Forms.Label();
         this.menuStrip1 = new System.Windows.Forms.MenuStrip();
         this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.saveasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
         this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.editNodeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
         this.addPageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.deletePageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
         this.movePageUpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.movePageDownToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
         this.rotateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.by90DegreesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.by180DegreesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.by270DegreesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.flipToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.horizontallyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.verticallyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.deskewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.tsToggleSubzones = new System.Windows.Forms.ToolStripMenuItem();
         this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.spltViewer = new System.Windows.Forms.SplitContainer();
         this.trvForm = new System.Windows.Forms.TreeView();
         this._previousPageToolStripButton = new System.Windows.Forms.ToolStripButton();
         this._nextPageToolStripButton = new System.Windows.Forms.ToolStripButton();
         this._zoomOutToolStripButton = new System.Windows.Forms.ToolStripButton();
         this._zoomInToolStripButton = new System.Windows.Forms.ToolStripButton();
         this._fitPageWidthToolStripButton = new System.Windows.Forms.ToolStripButton();
         this._fitPageToolStripButton = new System.Windows.Forms.ToolStripButton();
         this._zoomToSelectionModeToolStripButton = new System.Windows.Forms.ToolStripButton();
         this.tssShowPanWindow = new System.Windows.Forms.ToolStripButton();
         this.tsZOMRRegion = new System.Windows.Forms.ToolStripButton();
         this.tszBarcode = new System.Windows.Forms.ToolStripButton();
         this.tsZOCR = new System.Windows.Forms.ToolStripButton();
         this.tszImage = new System.Windows.Forms.ToolStripButton();
         this._showZonesToolStripButton = new System.Windows.Forms.ToolStripButton();
         this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.informationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
         this._toolStrip.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this._splitContainer)).BeginInit();
         this._splitContainer.Panel1.SuspendLayout();
         this._splitContainer.SuspendLayout();
         this.menuStrip1.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.spltViewer)).BeginInit();
         this.spltViewer.Panel1.SuspendLayout();
         this.spltViewer.Panel2.SuspendLayout();
         this.spltViewer.SuspendLayout();
         this.SuspendLayout();
         // 
         // _titleLabel
         // 
         this._titleLabel.Dock = System.Windows.Forms.DockStyle.Top;
         this._titleLabel.Location = new System.Drawing.Point(0, 49);
         this._titleLabel.Name = "_titleLabel";
         this._titleLabel.Size = new System.Drawing.Size(770, 13);
         this._titleLabel.TabIndex = 0;
         this._titleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
         // 
         // _toolStrip
         // 
         this._toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._previousPageToolStripButton,
            this._nextPageToolStripButton,
            this._pageToolStripTextBox,
            this._pageToolStripLabel,
            this._toolStripSeparator1,
            this._zoomOutToolStripButton,
            this._zoomInToolStripButton,
            this._zoomToolStripComboBox,
            this._fitPageWidthToolStripButton,
            this._fitPageToolStripButton,
            this._toolStripSeparator2,
            this._zoomToSelectionModeToolStripButton,
            this.tssShowPanWindow,
            this._toolStripSeparator3,
            this.tsZOMRRegion,
            this.tszBarcode,
            this.tsZOCR,
            this.tszImage,
            this.toolStripSeparator2,
            this._showZonesToolStripButton});
         this._toolStrip.Location = new System.Drawing.Point(0, 24);
         this._toolStrip.Name = "_toolStrip";
         this._toolStrip.Size = new System.Drawing.Size(770, 25);
         this._toolStrip.TabIndex = 1;
         // 
         // _pageToolStripTextBox
         // 
         this._pageToolStripTextBox.Name = "_pageToolStripTextBox";
         this._pageToolStripTextBox.Size = new System.Drawing.Size(40, 25);
         this._pageToolStripTextBox.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
         this._pageToolStripTextBox.ToolTipText = "Current page number in the document";
         this._pageToolStripTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this._pageToolStripTextBox_KeyPress);
         // 
         // _pageToolStripLabel
         // 
         this._pageToolStripLabel.Name = "_pageToolStripLabel";
         this._pageToolStripLabel.Size = new System.Drawing.Size(21, 22);
         this._pageToolStripLabel.Text = "/ 0";
         // 
         // _toolStripSeparator1
         // 
         this._toolStripSeparator1.Name = "_toolStripSeparator1";
         this._toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
         // 
         // _zoomToolStripComboBox
         // 
         this._zoomToolStripComboBox.DropDownWidth = 80;
         this._zoomToolStripComboBox.Items.AddRange(new object[] {
            "10%",
            "25%",
            "50%",
            "75%",
            "100%",
            "125%",
            "200%",
            "400%",
            "800%",
            "1600%",
            "2400%",
            "3200%",
            "6400%",
            "Actual Size",
            "Fit Page",
            "Fit Width"});
         this._zoomToolStripComboBox.Name = "_zoomToolStripComboBox";
         this._zoomToolStripComboBox.Size = new System.Drawing.Size(80, 25);
         this._zoomToolStripComboBox.SelectedIndexChanged += new System.EventHandler(this._zoomToolStripComboBox_SelectedIndexChanged);
         this._zoomToolStripComboBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this._zoomToolStripComboBox_KeyPress);
         // 
         // _toolStripSeparator2
         // 
         this._toolStripSeparator2.Name = "_toolStripSeparator2";
         this._toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
         // 
         // _toolStripSeparator3
         // 
         this._toolStripSeparator3.Name = "_toolStripSeparator3";
         this._toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
         // 
         // toolStripSeparator2
         // 
         this.toolStripSeparator2.Name = "toolStripSeparator2";
         this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
         // 
         // _rasterImageViewer
         // 
         this._rasterImageViewer.AutomationAntiAlias = false;
         this._rasterImageViewer.AutomationContainerIndex = -1;
         this._rasterImageViewer.AutomationDataProvider = null;
         this._rasterImageViewer.AutomationGetContainersCallback = null;
         this._rasterImageViewer.AutomationObject = null;
         this._rasterImageViewer.BackColor = System.Drawing.SystemColors.AppWorkspace;
         this._rasterImageViewer.Dock = System.Windows.Forms.DockStyle.Fill;
         this._rasterImageViewer.ImageBackgroundColor = System.Drawing.Color.White;
         this._rasterImageViewer.IsAutomationEventsHooked = false;
         this._rasterImageViewer.IsSyncSource = true;
         this._rasterImageViewer.IsSyncTarget = true;
         this._rasterImageViewer.ItemPadding = new System.Windows.Forms.Padding(1);
         this._rasterImageViewer.Location = new System.Drawing.Point(0, 0);
         this._rasterImageViewer.Name = "_rasterImageViewer";
         this._rasterImageViewer.RenderingEngine = null;
         this._rasterImageViewer.Size = new System.Drawing.Size(567, 343);
         this._rasterImageViewer.TabIndex = 0;
         this._rasterImageViewer.UseDpi = true;
         this._rasterImageViewer.ViewHorizontalAlignment = Leadtools.Controls.ControlAlignment.Center;
         this._rasterImageViewer.ViewVerticalAlignment = Leadtools.Controls.ControlAlignment.Center;
         this._rasterImageViewer.TransformChanged += new System.EventHandler(this._rasterImageViewer_TransformChanged);
         this._rasterImageViewer.Leave += new System.EventHandler(this._rasterImageViewer_Leave);
         this._rasterImageViewer.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this._rasterImageViewer_MouseDoubleClick);
         this._rasterImageViewer.MouseHover += new System.EventHandler(this._rasterImageViewer_MouseHover);
         this._rasterImageViewer.MouseMove += new System.Windows.Forms.MouseEventHandler(this._rasterImageViewer_MouseMove);
         // 
         // _splitContainer
         // 
         this._splitContainer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
         this._splitContainer.Dock = System.Windows.Forms.DockStyle.Bottom;
         this._splitContainer.IsSplitterFixed = true;
         this._splitContainer.Location = new System.Drawing.Point(0, 405);
         this._splitContainer.Name = "_splitContainer";
         // 
         // _splitContainer.Panel1
         // 
         this._splitContainer.Panel1.Controls.Add(this._mousePositionLabel);
         this._splitContainer.Size = new System.Drawing.Size(770, 16);
         this._splitContainer.SplitterDistance = 255;
         this._splitContainer.SplitterWidth = 1;
         this._splitContainer.TabIndex = 4;
         // 
         // _mousePositionLabel
         // 
         this._mousePositionLabel.Dock = System.Windows.Forms.DockStyle.Bottom;
         this._mousePositionLabel.Location = new System.Drawing.Point(0, 1);
         this._mousePositionLabel.Name = "_mousePositionLabel";
         this._mousePositionLabel.Size = new System.Drawing.Size(253, 13);
         this._mousePositionLabel.TabIndex = 6;
         this._mousePositionLabel.Text = "_mousePositionLabel";
         this._mousePositionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
         // 
         // menuStrip1
         // 
         this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.settingsToolStripMenuItem,
            this.helpToolStripMenuItem});
         this.menuStrip1.Location = new System.Drawing.Point(0, 0);
         this.menuStrip1.Name = "menuStrip1";
         this.menuStrip1.Size = new System.Drawing.Size(770, 24);
         this.menuStrip1.TabIndex = 5;
         this.menuStrip1.Text = "menuStrip1";
         // 
         // fileToolStripMenuItem
         // 
         this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.saveasToolStripMenuItem,
            this.toolStripSeparator1,
            this.closeToolStripMenuItem,
            this.exitToolStripMenuItem});
         this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
         this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
         this.fileToolStripMenuItem.Text = "&File";
         // 
         // newToolStripMenuItem
         // 
         this.newToolStripMenuItem.Name = "newToolStripMenuItem";
         this.newToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
         this.newToolStripMenuItem.Text = "&New...";
         this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
         // 
         // openToolStripMenuItem
         // 
         this.openToolStripMenuItem.Name = "openToolStripMenuItem";
         this.openToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
         this.openToolStripMenuItem.Text = "&Open...";
         this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
         // 
         // saveToolStripMenuItem
         // 
         this.saveToolStripMenuItem.Enabled = false;
         this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
         this.saveToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
         this.saveToolStripMenuItem.Text = "&Save";
         this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
         // 
         // saveasToolStripMenuItem
         // 
         this.saveasToolStripMenuItem.Enabled = false;
         this.saveasToolStripMenuItem.Name = "saveasToolStripMenuItem";
         this.saveasToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
         this.saveasToolStripMenuItem.Text = "Save &As...";
         this.saveasToolStripMenuItem.Click += new System.EventHandler(this.saveasToolStripMenuItem_Click);
         // 
         // toolStripSeparator1
         // 
         this.toolStripSeparator1.Name = "toolStripSeparator1";
         this.toolStripSeparator1.Size = new System.Drawing.Size(120, 6);
         // 
         // closeToolStripMenuItem
         // 
         this.closeToolStripMenuItem.Enabled = false;
         this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
         this.closeToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
         this.closeToolStripMenuItem.Text = "&Close";
         this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
         // 
         // exitToolStripMenuItem
         // 
         this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
         this.exitToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
         this.exitToolStripMenuItem.Text = "E&xit";
         this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
         // 
         // editToolStripMenuItem
         // 
         this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editNodeToolStripMenuItem,
            this.toolStripSeparator5,
            this.addPageToolStripMenuItem,
            this.deletePageToolStripMenuItem,
            this.toolStripSeparator3,
            this.movePageUpToolStripMenuItem,
            this.movePageDownToolStripMenuItem,
            this.toolStripSeparator4,
            this.rotateToolStripMenuItem,
            this.flipToolStripMenuItem,
            this.deskewToolStripMenuItem});
         this.editToolStripMenuItem.Enabled = false;
         this.editToolStripMenuItem.Name = "editToolStripMenuItem";
         this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
         this.editToolStripMenuItem.Text = "&Edit";
         this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
         // 
         // editNodeToolStripMenuItem
         // 
         this.editNodeToolStripMenuItem.Name = "editNodeToolStripMenuItem";
         this.editNodeToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E)));
         this.editNodeToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
         this.editNodeToolStripMenuItem.Text = "Ed&it Node...";
         this.editNodeToolStripMenuItem.Click += new System.EventHandler(this.editNodeToolStripMenuItem_Click);
         // 
         // toolStripSeparator5
         // 
         this.toolStripSeparator5.Name = "toolStripSeparator5";
         this.toolStripSeparator5.Size = new System.Drawing.Size(172, 6);
         // 
         // addPageToolStripMenuItem
         // 
         this.addPageToolStripMenuItem.Name = "addPageToolStripMenuItem";
         this.addPageToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
         this.addPageToolStripMenuItem.Text = "&Add Page...";
         this.addPageToolStripMenuItem.Click += new System.EventHandler(this.addPageToolStripMenuItem_Click);
         // 
         // deletePageToolStripMenuItem
         // 
         this.deletePageToolStripMenuItem.Name = "deletePageToolStripMenuItem";
         this.deletePageToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
         this.deletePageToolStripMenuItem.Text = "&Delete Page";
         this.deletePageToolStripMenuItem.Click += new System.EventHandler(this.deletePageToolStripMenuItem_Click);
         // 
         // toolStripSeparator3
         // 
         this.toolStripSeparator3.Name = "toolStripSeparator3";
         this.toolStripSeparator3.Size = new System.Drawing.Size(172, 6);
         // 
         // movePageUpToolStripMenuItem
         // 
         this.movePageUpToolStripMenuItem.Name = "movePageUpToolStripMenuItem";
         this.movePageUpToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
         this.movePageUpToolStripMenuItem.Text = "Move Page &Up";
         this.movePageUpToolStripMenuItem.Click += new System.EventHandler(this.movePageUpToolStripMenuItem_Click);
         // 
         // movePageDownToolStripMenuItem
         // 
         this.movePageDownToolStripMenuItem.Name = "movePageDownToolStripMenuItem";
         this.movePageDownToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
         this.movePageDownToolStripMenuItem.Text = "Move Page &Down";
         this.movePageDownToolStripMenuItem.Click += new System.EventHandler(this.movePageDownToolStripMenuItem_Click);
         // 
         // toolStripSeparator4
         // 
         this.toolStripSeparator4.Name = "toolStripSeparator4";
         this.toolStripSeparator4.Size = new System.Drawing.Size(172, 6);
         this.toolStripSeparator4.Visible = false;
         // 
         // rotateToolStripMenuItem
         // 
         this.rotateToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.by90DegreesToolStripMenuItem,
            this.by180DegreesToolStripMenuItem,
            this.by270DegreesToolStripMenuItem});
         this.rotateToolStripMenuItem.Name = "rotateToolStripMenuItem";
         this.rotateToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
         this.rotateToolStripMenuItem.Text = "&Rotate";
         this.rotateToolStripMenuItem.Visible = false;
         // 
         // by90DegreesToolStripMenuItem
         // 
         this.by90DegreesToolStripMenuItem.Name = "by90DegreesToolStripMenuItem";
         this.by90DegreesToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
         this.by90DegreesToolStripMenuItem.Text = "By 90 Degrees";
         this.by90DegreesToolStripMenuItem.Click += new System.EventHandler(this.by90DegreesToolStripMenuItem_Click);
         // 
         // by180DegreesToolStripMenuItem
         // 
         this.by180DegreesToolStripMenuItem.Name = "by180DegreesToolStripMenuItem";
         this.by180DegreesToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
         this.by180DegreesToolStripMenuItem.Text = "By 180 Degrees";
         this.by180DegreesToolStripMenuItem.Click += new System.EventHandler(this.by180DegreesToolStripMenuItem_Click);
         // 
         // by270DegreesToolStripMenuItem
         // 
         this.by270DegreesToolStripMenuItem.Name = "by270DegreesToolStripMenuItem";
         this.by270DegreesToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
         this.by270DegreesToolStripMenuItem.Text = "By 270 Degrees";
         this.by270DegreesToolStripMenuItem.Click += new System.EventHandler(this.by270DegreesToolStripMenuItem_Click);
         // 
         // flipToolStripMenuItem
         // 
         this.flipToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.horizontallyToolStripMenuItem,
            this.verticallyToolStripMenuItem});
         this.flipToolStripMenuItem.Name = "flipToolStripMenuItem";
         this.flipToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
         this.flipToolStripMenuItem.Text = "&Flip";
         this.flipToolStripMenuItem.Visible = false;
         // 
         // horizontallyToolStripMenuItem
         // 
         this.horizontallyToolStripMenuItem.Name = "horizontallyToolStripMenuItem";
         this.horizontallyToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
         this.horizontallyToolStripMenuItem.Text = "&Horizontally";
         this.horizontallyToolStripMenuItem.Click += new System.EventHandler(this.horizontallyToolStripMenuItem_Click);
         // 
         // verticallyToolStripMenuItem
         // 
         this.verticallyToolStripMenuItem.Name = "verticallyToolStripMenuItem";
         this.verticallyToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
         this.verticallyToolStripMenuItem.Text = "&Vertically";
         this.verticallyToolStripMenuItem.Click += new System.EventHandler(this.verticallyToolStripMenuItem_Click);
         // 
         // deskewToolStripMenuItem
         // 
         this.deskewToolStripMenuItem.Name = "deskewToolStripMenuItem";
         this.deskewToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
         this.deskewToolStripMenuItem.Text = "Deske&w";
         this.deskewToolStripMenuItem.Visible = false;
         this.deskewToolStripMenuItem.Click += new System.EventHandler(this.deskewToolStripMenuItem_Click);
         // 
         // settingsToolStripMenuItem
         // 
         this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.optionsToolStripMenuItem,
            this.tsToggleSubzones});
         this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
         this.settingsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
         this.settingsToolStripMenuItem.Text = "&Settings";
         // 
         // optionsToolStripMenuItem
         // 
         this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
         this.optionsToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
         this.optionsToolStripMenuItem.Text = "&Options...";
         this.optionsToolStripMenuItem.Click += new System.EventHandler(this.optionsToolStripMenuItem_Click);
         // 
         // tsToggleSubzones
         // 
         this.tsToggleSubzones.CheckOnClick = true;
         this.tsToggleSubzones.Name = "tsToggleSubzones";
         this.tsToggleSubzones.Size = new System.Drawing.Size(156, 22);
         this.tsToggleSubzones.Text = "&Show Subzones";
         this.tsToggleSubzones.CheckedChanged += new System.EventHandler(this.tsToggleSubzones_Click);
         // 
         // helpToolStripMenuItem
         // 
         this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.informationToolStripMenuItem,
            this.toolStripSeparator6,
            this.aboutToolStripMenuItem});
         this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
         this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
         this.helpToolStripMenuItem.Text = "&Help";
         // 
         // spltViewer
         // 
         this.spltViewer.Dock = System.Windows.Forms.DockStyle.Fill;
         this.spltViewer.Location = new System.Drawing.Point(0, 62);
         this.spltViewer.Name = "spltViewer";
         // 
         // spltViewer.Panel1
         // 
         this.spltViewer.Panel1.Controls.Add(this.trvForm);
         // 
         // spltViewer.Panel2
         // 
         this.spltViewer.Panel2.Controls.Add(this._rasterImageViewer);
         this.spltViewer.Size = new System.Drawing.Size(770, 343);
         this.spltViewer.SplitterDistance = 199;
         this.spltViewer.TabIndex = 0;
         // 
         // trvForm
         // 
         this.trvForm.Dock = System.Windows.Forms.DockStyle.Fill;
         this.trvForm.Location = new System.Drawing.Point(0, 0);
         this.trvForm.Name = "trvForm";
         this.trvForm.Size = new System.Drawing.Size(199, 343);
         this.trvForm.TabIndex = 0;
         this.trvForm.BeforeCollapse += new System.Windows.Forms.TreeViewCancelEventHandler(this.trvForm_BeforeCollapse);
         this.trvForm.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.trvForm_BeforeExpand);
         this.trvForm.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.trvForm_AfterSelect);
         this.trvForm.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.trvForm_NodeMouseClick);
         this.trvForm.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.trvForm_NodeMouseDoubleClick);
         this.trvForm.KeyUp += new System.Windows.Forms.KeyEventHandler(this.trvForm_KeyUp);
         this.trvForm.MouseDown += new System.Windows.Forms.MouseEventHandler(this.trvForm_MouseDown);
         this.trvForm.MouseLeave += new System.EventHandler(this.trvForm_MouseLeave);
         this.trvForm.MouseMove += new System.Windows.Forms.MouseEventHandler(this.trvForm_MouseMove);
         // 
         // _previousPageToolStripButton
         // 
         this._previousPageToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this._previousPageToolStripButton.Image = global::OmrProcessingDemo.Properties.Resources.PreviousPage;
         this._previousPageToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
         this._previousPageToolStripButton.Name = "_previousPageToolStripButton";
         this._previousPageToolStripButton.Size = new System.Drawing.Size(23, 22);
         this._previousPageToolStripButton.Text = "Previous";
         this._previousPageToolStripButton.ToolTipText = "Go to previous page in the document";
         this._previousPageToolStripButton.Click += new System.EventHandler(this._previousPageToolStripButton_Click);
         // 
         // _nextPageToolStripButton
         // 
         this._nextPageToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this._nextPageToolStripButton.Image = global::OmrProcessingDemo.Properties.Resources.NextPage;
         this._nextPageToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
         this._nextPageToolStripButton.Name = "_nextPageToolStripButton";
         this._nextPageToolStripButton.Size = new System.Drawing.Size(23, 22);
         this._nextPageToolStripButton.Text = "Next";
         this._nextPageToolStripButton.ToolTipText = "Go to next page in the document";
         this._nextPageToolStripButton.Click += new System.EventHandler(this._nextPageToolStripButton_Click);
         // 
         // _zoomOutToolStripButton
         // 
         this._zoomOutToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this._zoomOutToolStripButton.Image = global::OmrProcessingDemo.Properties.Resources.zoom_out;
         this._zoomOutToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
         this._zoomOutToolStripButton.Name = "_zoomOutToolStripButton";
         this._zoomOutToolStripButton.Size = new System.Drawing.Size(23, 22);
         this._zoomOutToolStripButton.Text = "Zoom Out";
         this._zoomOutToolStripButton.ToolTipText = "Zoom out";
         this._zoomOutToolStripButton.Click += new System.EventHandler(this._zoomOutToolStripButton_Click);
         // 
         // _zoomInToolStripButton
         // 
         this._zoomInToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this._zoomInToolStripButton.Image = global::OmrProcessingDemo.Properties.Resources.zoom;
         this._zoomInToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
         this._zoomInToolStripButton.Name = "_zoomInToolStripButton";
         this._zoomInToolStripButton.Size = new System.Drawing.Size(23, 22);
         this._zoomInToolStripButton.Text = "Zoom In";
         this._zoomInToolStripButton.ToolTipText = "Zoom In";
         this._zoomInToolStripButton.Click += new System.EventHandler(this._zoomInToolStripButton_Click);
         // 
         // _fitPageWidthToolStripButton
         // 
         this._fitPageWidthToolStripButton.CheckOnClick = true;
         this._fitPageWidthToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this._fitPageWidthToolStripButton.Image = global::OmrProcessingDemo.Properties.Resources.pan;
         this._fitPageWidthToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
         this._fitPageWidthToolStripButton.Name = "_fitPageWidthToolStripButton";
         this._fitPageWidthToolStripButton.Size = new System.Drawing.Size(23, 22);
         this._fitPageWidthToolStripButton.Text = "FitWidth";
         this._fitPageWidthToolStripButton.ToolTipText = "Fit page width in window";
         this._fitPageWidthToolStripButton.Click += new System.EventHandler(this._fitPageWidthToolStripButton_Click);
         // 
         // _fitPageToolStripButton
         // 
         this._fitPageToolStripButton.CheckOnClick = true;
         this._fitPageToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this._fitPageToolStripButton.Image = global::OmrProcessingDemo.Properties.Resources.FitPageToWindow;
         this._fitPageToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
         this._fitPageToolStripButton.Name = "_fitPageToolStripButton";
         this._fitPageToolStripButton.Size = new System.Drawing.Size(23, 22);
         this._fitPageToolStripButton.Text = "FitPage";
         this._fitPageToolStripButton.ToolTipText = "Fit entire page in window";
         this._fitPageToolStripButton.Click += new System.EventHandler(this._fitPageToolStripButton_Click);
         // 
         // _zoomToSelectionModeToolStripButton
         // 
         this._zoomToSelectionModeToolStripButton.CheckOnClick = true;
         this._zoomToSelectionModeToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this._zoomToSelectionModeToolStripButton.Image = global::OmrProcessingDemo.Properties.Resources.zoom_select;
         this._zoomToSelectionModeToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
         this._zoomToSelectionModeToolStripButton.Name = "_zoomToSelectionModeToolStripButton";
         this._zoomToSelectionModeToolStripButton.Size = new System.Drawing.Size(23, 22);
         this._zoomToSelectionModeToolStripButton.Text = "ZoomTo";
         this._zoomToSelectionModeToolStripButton.ToolTipText = "Zoom to selection mode";
         this._zoomToSelectionModeToolStripButton.Click += new System.EventHandler(this._zoomToSelectionModeToolStripButton_Click);
         // 
         // tssShowPanWindow
         // 
         this.tssShowPanWindow.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this.tssShowPanWindow.Image = global::OmrProcessingDemo.Properties.Resources.show_pan;
         this.tssShowPanWindow.ImageTransparentColor = System.Drawing.Color.Magenta;
         this.tssShowPanWindow.Name = "tssShowPanWindow";
         this.tssShowPanWindow.Size = new System.Drawing.Size(23, 22);
         this.tssShowPanWindow.Text = "Show Pan Window";
         this.tssShowPanWindow.Click += new System.EventHandler(this.tssShowPanWindow_Click);
         // 
         // tsZOMRRegion
         // 
         this.tsZOMRRegion.CheckOnClick = true;
         this.tsZOMRRegion.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this.tsZOMRRegion.Image = ((System.Drawing.Image)(resources.GetObject("tsZOMRRegion.Image")));
         this.tsZOMRRegion.ImageTransparentColor = System.Drawing.Color.Magenta;
         this.tsZOMRRegion.Name = "tsZOMRRegion";
         this.tsZOMRRegion.Size = new System.Drawing.Size(23, 22);
         this.tsZOMRRegion.Text = "OMR Region";
         this.tsZOMRRegion.Click += new System.EventHandler(this.tzOMRREgion_Click);
         // 
         // tszBarcode
         // 
         this.tszBarcode.CheckOnClick = true;
         this.tszBarcode.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this.tszBarcode.Image = ((System.Drawing.Image)(resources.GetObject("tszBarcode.Image")));
         this.tszBarcode.ImageTransparentColor = System.Drawing.Color.Magenta;
         this.tszBarcode.Name = "tszBarcode";
         this.tszBarcode.Size = new System.Drawing.Size(23, 22);
         this.tszBarcode.Text = "Barcode";
         this.tszBarcode.Click += new System.EventHandler(this.tzBarcode_Click);
         // 
         // tsZOCR
         // 
         this.tsZOCR.CheckOnClick = true;
         this.tsZOCR.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this.tsZOCR.Image = global::OmrProcessingDemo.Properties.Resources.green_note;
         this.tsZOCR.ImageTransparentColor = System.Drawing.Color.Magenta;
         this.tsZOCR.Name = "tsZOCR";
         this.tsZOCR.Size = new System.Drawing.Size(23, 22);
         this.tsZOCR.Text = "OCR";
         this.tsZOCR.Click += new System.EventHandler(this.tzOCR_Click);
         // 
         // tszImage
         // 
         this.tszImage.CheckOnClick = true;
         this.tszImage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this.tszImage.Image = global::OmrProcessingDemo.Properties.Resources.picture;
         this.tszImage.ImageTransparentColor = System.Drawing.Color.Magenta;
         this.tszImage.Name = "tszImage";
         this.tszImage.Size = new System.Drawing.Size(23, 22);
         this.tszImage.Text = "Image";
         this.tszImage.Click += new System.EventHandler(this.tszImage_Click);
         // 
         // _showZonesToolStripButton
         // 
         this._showZonesToolStripButton.Checked = true;
         this._showZonesToolStripButton.CheckOnClick = true;
         this._showZonesToolStripButton.CheckState = System.Windows.Forms.CheckState.Checked;
         this._showZonesToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this._showZonesToolStripButton.Image = global::OmrProcessingDemo.Properties.Resources.note_2;
         this._showZonesToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
         this._showZonesToolStripButton.Name = "_showZonesToolStripButton";
         this._showZonesToolStripButton.Size = new System.Drawing.Size(23, 22);
         this._showZonesToolStripButton.Text = "ShowZones";
         this._showZonesToolStripButton.ToolTipText = "Show/hide zones";
         this._showZonesToolStripButton.Click += new System.EventHandler(this._showZonesToolStripButton_Click);
         // 
         // aboutToolStripMenuItem
         // 
         this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
         this.aboutToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
         this.aboutToolStripMenuItem.Text = "&About";
         this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
         // 
         // informationToolStripMenuItem
         // 
         this.informationToolStripMenuItem.Name = "informationToolStripMenuItem";
         this.informationToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
         this.informationToolStripMenuItem.Text = "&Information";
         this.informationToolStripMenuItem.Click += new System.EventHandler(this.informationToolStripMenuItem_Click);
         // 
         // toolStripSeparator6
         // 
         this.toolStripSeparator6.Name = "toolStripSeparator6";
         this.toolStripSeparator6.Size = new System.Drawing.Size(149, 6);
         // 
         // ViewerControl
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.Controls.Add(this.spltViewer);
         this.Controls.Add(this._splitContainer);
         this.Controls.Add(this._titleLabel);
         this.Controls.Add(this._toolStrip);
         this.Controls.Add(this.menuStrip1);
         this.Name = "ViewerControl";
         this.Size = new System.Drawing.Size(770, 421);
         this._toolStrip.ResumeLayout(false);
         this._toolStrip.PerformLayout();
         this._splitContainer.Panel1.ResumeLayout(false);
         ((System.ComponentModel.ISupportInitialize)(this._splitContainer)).EndInit();
         this._splitContainer.ResumeLayout(false);
         this.menuStrip1.ResumeLayout(false);
         this.menuStrip1.PerformLayout();
         this.spltViewer.Panel1.ResumeLayout(false);
         this.spltViewer.Panel2.ResumeLayout(false);
         ((System.ComponentModel.ISupportInitialize)(this.spltViewer)).EndInit();
         this.spltViewer.ResumeLayout(false);
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.Label _titleLabel;
      public System.Windows.Forms.ToolStrip _toolStrip;
      //private Leadtools.Annotations.WinForms.AutomationImageViewer _rasterImageViewer;
      private Leadtools.Annotations.WinForms.AutomationImageViewer _rasterImageViewer;
      private System.Windows.Forms.ToolStripButton _previousPageToolStripButton;
      private System.Windows.Forms.ToolStripButton _nextPageToolStripButton;
      private System.Windows.Forms.ToolStripTextBox _pageToolStripTextBox;
      private System.Windows.Forms.ToolStripLabel _pageToolStripLabel;
      private System.Windows.Forms.ToolStripSeparator _toolStripSeparator1;
      private System.Windows.Forms.ToolStripButton _zoomOutToolStripButton;
      private System.Windows.Forms.ToolStripButton _zoomInToolStripButton;
      private System.Windows.Forms.ToolStripComboBox _zoomToolStripComboBox;
      private System.Windows.Forms.ToolStripButton _fitPageWidthToolStripButton;
      private System.Windows.Forms.ToolStripButton _fitPageToolStripButton;
      private System.Windows.Forms.ToolStripSeparator _toolStripSeparator2;
      private System.Windows.Forms.ToolStripButton _zoomToSelectionModeToolStripButton;
      private System.Windows.Forms.ToolStripSeparator _toolStripSeparator3;
      private System.Windows.Forms.ToolStripButton _showZonesToolStripButton;
      private System.Windows.Forms.SplitContainer _splitContainer;
      private System.Windows.Forms.Label _mousePositionLabel;
      private System.Windows.Forms.MenuStrip menuStrip1;
      private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem saveasToolStripMenuItem;
      private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
      private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
      private System.Windows.Forms.SplitContainer spltViewer;
      private System.Windows.Forms.TreeView trvForm;
      private System.Windows.Forms.ToolStripButton tsZOMRRegion;
      private System.Windows.Forms.ToolStripButton tszBarcode;
      private System.Windows.Forms.ToolStripButton tsZOCR;
      private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
      private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem tsToggleSubzones;
      private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem addPageToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem deletePageToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem movePageUpToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem movePageDownToolStripMenuItem;
      private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
      private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
      private System.Windows.Forms.ToolStripMenuItem rotateToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem by90DegreesToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem by180DegreesToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem by270DegreesToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem flipToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem horizontallyToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem verticallyToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem deskewToolStripMenuItem;
      private System.Windows.Forms.ToolStripButton tszImage;
      private System.Windows.Forms.ToolStripButton tssShowPanWindow;
      private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem editNodeToolStripMenuItem;
      private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
      private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem informationToolStripMenuItem;
      private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
   }
}

namespace DicomDemo
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
         this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.searchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
         this.clearLogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
         this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.showHelpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._menuStrip = new System.Windows.Forms.MenuStrip();
         this._splitContainer1 = new System.Windows.Forms.SplitContainer();
         this._splitContainer2 = new System.Windows.Forms.SplitContainer();
         this._propertyGrid = new System.Windows.Forms.PropertyGrid();
         this._label1 = new System.Windows.Forms.Label();
         this._groupBoxServer = new System.Windows.Forms.GroupBox();
         this._labelServerPort = new System.Windows.Forms.Label();
         this._labelServerIp = new System.Windows.Forms.Label();
         this._labelServerAeTitle = new System.Windows.Forms.Label();
         this._textBoxServerPort = new System.Windows.Forms.TextBox();
         this._textBoxServerIp = new System.Windows.Forms.TextBox();
         this._comboBoxService = new System.Windows.Forms.ComboBox();
         this._buttonCancel = new System.Windows.Forms.Button();
         this._buttonSearch = new System.Windows.Forms.Button();
         this._buttonOptions = new System.Windows.Forms.Button();
         this._splitContainer3 = new System.Windows.Forms.SplitContainer();
         this._listViewStudies = new System.Windows.Forms.ListView();
         this._columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
         this._columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
         this._columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
         this._columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
         this._columnHeaderStudyTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
         this._columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
         this._columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
         this._label2 = new System.Windows.Forms.Label();
         this._splitContainer4 = new System.Windows.Forms.SplitContainer();
         this.buttonCGetStorageClasses = new System.Windows.Forms.Button();
         this._radioButtonCGet = new System.Windows.Forms.RadioButton();
         this._radioButtonCMove = new System.Windows.Forms.RadioButton();
         this._listViewSeries = new System.Windows.Forms.ListView();
         this._columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
         this._columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
         this._columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
         this._columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
         this._columnHeader11 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
         this._label3 = new System.Windows.Forms.Label();
         this._splitContainer5 = new System.Windows.Forms.SplitContainer();
         this._toolStripCancel = new System.Windows.Forms.ToolStrip();
         this._toolStripButtonCancel = new System.Windows.Forms.ToolStripButton();
         this._label4 = new System.Windows.Forms.Label();
         this._labelStatus = new System.Windows.Forms.Label();
         this._richTextBoxLog = new System.Windows.Forms.RichTextBox();
         this._contextMenuStripLog = new System.Windows.Forms.ContextMenuStrip(this.components);
         this._toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
         this._label5 = new System.Windows.Forms.Label();
         this._menuStrip.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this._splitContainer1)).BeginInit();
         this._splitContainer1.Panel1.SuspendLayout();
         this._splitContainer1.Panel2.SuspendLayout();
         this._splitContainer1.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this._splitContainer2)).BeginInit();
         this._splitContainer2.Panel1.SuspendLayout();
         this._splitContainer2.Panel2.SuspendLayout();
         this._splitContainer2.SuspendLayout();
         this._groupBoxServer.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this._splitContainer3)).BeginInit();
         this._splitContainer3.Panel1.SuspendLayout();
         this._splitContainer3.Panel2.SuspendLayout();
         this._splitContainer3.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this._splitContainer4)).BeginInit();
         this._splitContainer4.Panel1.SuspendLayout();
         this._splitContainer4.Panel2.SuspendLayout();
         this._splitContainer4.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this._splitContainer5)).BeginInit();
         this._splitContainer5.Panel1.SuspendLayout();
         this._splitContainer5.Panel2.SuspendLayout();
         this._splitContainer5.SuspendLayout();
         this._toolStripCancel.SuspendLayout();
         this._contextMenuStripLog.SuspendLayout();
         this.SuspendLayout();
         // 
         // fileToolStripMenuItem
         // 
         this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.optionsToolStripMenuItem,
            this.searchToolStripMenuItem,
            this.toolStripSeparator1,
            this.clearLogToolStripMenuItem,
            this.toolStripSeparator2,
            this.exitToolStripMenuItem});
         this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
         this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
         this.fileToolStripMenuItem.Text = "&File";
         // 
         // optionsToolStripMenuItem
         // 
         this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
         this.optionsToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
         this.optionsToolStripMenuItem.Text = "&Options...";
         this.optionsToolStripMenuItem.Click += new System.EventHandler(this.optionsToolStripMenuItem_Click);
         // 
         // searchToolStripMenuItem
         // 
         this.searchToolStripMenuItem.Name = "searchToolStripMenuItem";
         this.searchToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
         this.searchToolStripMenuItem.Text = "&Search";
         this.searchToolStripMenuItem.Click += new System.EventHandler(this.searchToolStripMenuItem_Click);
         // 
         // toolStripSeparator1
         // 
         this.toolStripSeparator1.Name = "toolStripSeparator1";
         this.toolStripSeparator1.Size = new System.Drawing.Size(122, 6);
         // 
         // clearLogToolStripMenuItem
         // 
         this.clearLogToolStripMenuItem.Name = "clearLogToolStripMenuItem";
         this.clearLogToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
         this.clearLogToolStripMenuItem.Text = "&Clear Log";
         this.clearLogToolStripMenuItem.Click += new System.EventHandler(this.clearLogToolStripMenuItem_Click);
         // 
         // toolStripSeparator2
         // 
         this.toolStripSeparator2.Name = "toolStripSeparator2";
         this.toolStripSeparator2.Size = new System.Drawing.Size(122, 6);
         // 
         // exitToolStripMenuItem
         // 
         this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
         this.exitToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
         this.exitToolStripMenuItem.Text = "&Exit";
         this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
         // 
         // helpToolStripMenuItem
         // 
         this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showHelpToolStripMenuItem,
            this.aboutToolStripMenuItem});
         this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
         this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
         this.helpToolStripMenuItem.Text = "&Help";
         // 
         // showHelpToolStripMenuItem
         // 
         this.showHelpToolStripMenuItem.Name = "showHelpToolStripMenuItem";
         this.showHelpToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
         this.showHelpToolStripMenuItem.Text = "Show &Help...";
         this.showHelpToolStripMenuItem.Click += new System.EventHandler(this.showHelpToolStripMenuItem_Click);
         // 
         // aboutToolStripMenuItem
         // 
         this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
         this.aboutToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
         this.aboutToolStripMenuItem.Text = "&About...";
         this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
         // 
         // _menuStrip
         // 
         this._menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
         this._menuStrip.Location = new System.Drawing.Point(0, 0);
         this._menuStrip.Name = "_menuStrip";
         this._menuStrip.Size = new System.Drawing.Size(888, 24);
         this._menuStrip.TabIndex = 0;
         this._menuStrip.Text = "menuStrip1";
         // 
         // _splitContainer1
         // 
         this._splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
         this._splitContainer1.Location = new System.Drawing.Point(0, 24);
         this._splitContainer1.Name = "_splitContainer1";
         // 
         // _splitContainer1.Panel1
         // 
         this._splitContainer1.Panel1.Controls.Add(this._splitContainer2);
         // 
         // _splitContainer1.Panel2
         // 
         this._splitContainer1.Panel2.Controls.Add(this._splitContainer3);
         this._splitContainer1.Size = new System.Drawing.Size(888, 710);
         this._splitContainer1.SplitterDistance = 248;
         this._splitContainer1.TabIndex = 1;
         // 
         // _splitContainer2
         // 
         this._splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
         this._splitContainer2.Location = new System.Drawing.Point(0, 0);
         this._splitContainer2.Name = "_splitContainer2";
         this._splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
         // 
         // _splitContainer2.Panel1
         // 
         this._splitContainer2.Panel1.Controls.Add(this._propertyGrid);
         this._splitContainer2.Panel1.Controls.Add(this._label1);
         // 
         // _splitContainer2.Panel2
         // 
         this._splitContainer2.Panel2.Controls.Add(this._groupBoxServer);
         this._splitContainer2.Panel2.Controls.Add(this._buttonCancel);
         this._splitContainer2.Panel2.Controls.Add(this._buttonSearch);
         this._splitContainer2.Panel2.Controls.Add(this._buttonOptions);
         this._splitContainer2.Panel2.Resize += new System.EventHandler(this._splitContainer2_Panel2_Resize);
         this._splitContainer2.Size = new System.Drawing.Size(248, 710);
         this._splitContainer2.SplitterDistance = 571;
         this._splitContainer2.TabIndex = 0;
         // 
         // _propertyGrid
         // 
         this._propertyGrid.Cursor = System.Windows.Forms.Cursors.HSplit;
         this._propertyGrid.Dock = System.Windows.Forms.DockStyle.Fill;
         this._propertyGrid.HelpVisible = false;
         this._propertyGrid.Location = new System.Drawing.Point(0, 23);
         this._propertyGrid.Name = "_propertyGrid";
         this._propertyGrid.PropertySort = System.Windows.Forms.PropertySort.Categorized;
         this._propertyGrid.Size = new System.Drawing.Size(248, 548);
         this._propertyGrid.TabIndex = 1;
         // 
         // _label1
         // 
         this._label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
         this._label1.Dock = System.Windows.Forms.DockStyle.Top;
         this._label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this._label1.Location = new System.Drawing.Point(0, 0);
         this._label1.Name = "_label1";
         this._label1.Size = new System.Drawing.Size(248, 23);
         this._label1.TabIndex = 0;
         this._label1.Text = "Search Params:";
         // 
         // _groupBoxServer
         // 
         this._groupBoxServer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this._groupBoxServer.Controls.Add(this._labelServerPort);
         this._groupBoxServer.Controls.Add(this._labelServerIp);
         this._groupBoxServer.Controls.Add(this._labelServerAeTitle);
         this._groupBoxServer.Controls.Add(this._textBoxServerPort);
         this._groupBoxServer.Controls.Add(this._textBoxServerIp);
         this._groupBoxServer.Controls.Add(this._comboBoxService);
         this._groupBoxServer.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this._groupBoxServer.Location = new System.Drawing.Point(8, 8);
         this._groupBoxServer.Name = "_groupBoxServer";
         this._groupBoxServer.Size = new System.Drawing.Size(232, 100);
         this._groupBoxServer.TabIndex = 9;
         this._groupBoxServer.TabStop = false;
         this._groupBoxServer.Text = "Server";
         // 
         // _labelServerPort
         // 
         this._labelServerPort.AutoSize = true;
         this._labelServerPort.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this._labelServerPort.Location = new System.Drawing.Point(8, 67);
         this._labelServerPort.Name = "_labelServerPort";
         this._labelServerPort.Size = new System.Drawing.Size(29, 13);
         this._labelServerPort.TabIndex = 14;
         this._labelServerPort.Text = "Port:";
         this._labelServerPort.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
         // 
         // _labelServerIp
         // 
         this._labelServerIp.AutoSize = true;
         this._labelServerIp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this._labelServerIp.Location = new System.Drawing.Point(8, 44);
         this._labelServerIp.Name = "_labelServerIp";
         this._labelServerIp.Size = new System.Drawing.Size(20, 13);
         this._labelServerIp.TabIndex = 13;
         this._labelServerIp.Text = "IP:";
         this._labelServerIp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
         // 
         // _labelServerAeTitle
         // 
         this._labelServerAeTitle.AutoSize = true;
         this._labelServerAeTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this._labelServerAeTitle.Location = new System.Drawing.Point(8, 20);
         this._labelServerAeTitle.Name = "_labelServerAeTitle";
         this._labelServerAeTitle.Size = new System.Drawing.Size(24, 13);
         this._labelServerAeTitle.TabIndex = 12;
         this._labelServerAeTitle.Text = "AE:";
         this._labelServerAeTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
         // 
         // _textBoxServerPort
         // 
         this._textBoxServerPort.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this._textBoxServerPort.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this._textBoxServerPort.Location = new System.Drawing.Point(48, 63);
         this._textBoxServerPort.Name = "_textBoxServerPort";
         this._textBoxServerPort.ReadOnly = true;
         this._textBoxServerPort.Size = new System.Drawing.Size(184, 20);
         this._textBoxServerPort.TabIndex = 11;
         // 
         // _textBoxServerIp
         // 
         this._textBoxServerIp.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this._textBoxServerIp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this._textBoxServerIp.Location = new System.Drawing.Point(48, 40);
         this._textBoxServerIp.Name = "_textBoxServerIp";
         this._textBoxServerIp.ReadOnly = true;
         this._textBoxServerIp.Size = new System.Drawing.Size(184, 20);
         this._textBoxServerIp.TabIndex = 10;
         // 
         // _comboBoxService
         // 
         this._comboBoxService.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this._comboBoxService.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this._comboBoxService.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this._comboBoxService.FormattingEnabled = true;
         this._comboBoxService.Location = new System.Drawing.Point(48, 16);
         this._comboBoxService.Name = "_comboBoxService";
         this._comboBoxService.Size = new System.Drawing.Size(184, 21);
         this._comboBoxService.TabIndex = 9;
         this._comboBoxService.SelectionChangeCommitted += new System.EventHandler(this._comboBoxService_SelectionChangeCommitted);
         // 
         // _buttonCancel
         // 
         this._buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
         this._buttonCancel.Location = new System.Drawing.Point(171, 112);
         this._buttonCancel.Name = "_buttonCancel";
         this._buttonCancel.Size = new System.Drawing.Size(75, 23);
         this._buttonCancel.TabIndex = 2;
         this._buttonCancel.Text = "&Cancel";
         this._buttonCancel.UseVisualStyleBackColor = true;
         this._buttonCancel.Click += new System.EventHandler(this._buttonCancel_Click);
         // 
         // _buttonSearch
         // 
         this._buttonSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
         this._buttonSearch.Location = new System.Drawing.Point(87, 112);
         this._buttonSearch.Name = "_buttonSearch";
         this._buttonSearch.Size = new System.Drawing.Size(75, 23);
         this._buttonSearch.TabIndex = 1;
         this._buttonSearch.Text = "&Search";
         this._buttonSearch.UseVisualStyleBackColor = true;
         this._buttonSearch.Click += new System.EventHandler(this._buttonSearch_Click);
         // 
         // _buttonOptions
         // 
         this._buttonOptions.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
         this._buttonOptions.Location = new System.Drawing.Point(3, 112);
         this._buttonOptions.Name = "_buttonOptions";
         this._buttonOptions.Size = new System.Drawing.Size(75, 23);
         this._buttonOptions.TabIndex = 0;
         this._buttonOptions.Text = "&Options...";
         this._buttonOptions.UseVisualStyleBackColor = true;
         this._buttonOptions.Click += new System.EventHandler(this.Options_Click);
         // 
         // _splitContainer3
         // 
         this._splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
         this._splitContainer3.Location = new System.Drawing.Point(0, 0);
         this._splitContainer3.Name = "_splitContainer3";
         this._splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
         // 
         // _splitContainer3.Panel1
         // 
         this._splitContainer3.Panel1.Controls.Add(this._listViewStudies);
         this._splitContainer3.Panel1.Controls.Add(this._label2);
         // 
         // _splitContainer3.Panel2
         // 
         this._splitContainer3.Panel2.Controls.Add(this._splitContainer4);
         this._splitContainer3.Size = new System.Drawing.Size(636, 710);
         this._splitContainer3.SplitterDistance = 135;
         this._splitContainer3.TabIndex = 0;
         // 
         // _listViewStudies
         // 
         this._listViewStudies.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this._columnHeader1,
            this._columnHeader2,
            this._columnHeader3,
            this._columnHeader4,
            this._columnHeaderStudyTime,
            this._columnHeader5,
            this._columnHeader6});
         this._listViewStudies.Dock = System.Windows.Forms.DockStyle.Fill;
         this._listViewStudies.FullRowSelect = true;
         this._listViewStudies.GridLines = true;
         this._listViewStudies.HideSelection = false;
         this._listViewStudies.Location = new System.Drawing.Point(0, 23);
         this._listViewStudies.MultiSelect = false;
         this._listViewStudies.Name = "_listViewStudies";
         this._listViewStudies.Size = new System.Drawing.Size(636, 112);
         this._listViewStudies.TabIndex = 1;
         this._listViewStudies.UseCompatibleStateImageBehavior = false;
         this._listViewStudies.View = System.Windows.Forms.View.Details;
         this._listViewStudies.SelectedIndexChanged += new System.EventHandler(this._listViewStudies_SelectedIndexChanged);
         this._listViewStudies.Resize += new System.EventHandler(this._listViewStudies_Resize);
         // 
         // _columnHeader1
         // 
         this._columnHeader1.Text = "Patient Name";
         // 
         // _columnHeader2
         // 
         this._columnHeader2.Text = "Patient ID";
         // 
         // _columnHeader3
         // 
         this._columnHeader3.Text = "Accession Number";
         // 
         // _columnHeader4
         // 
         this._columnHeader4.Text = "Study Date";
         // 
         // _columnHeaderStudyTime
         // 
         this._columnHeaderStudyTime.Text = "Study Time";
         // 
         // _columnHeader5
         // 
         this._columnHeader5.Text = "Referring Physicians Name";
         // 
         // _columnHeader6
         // 
         this._columnHeader6.Text = "Description";
         // 
         // _label2
         // 
         this._label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
         this._label2.Dock = System.Windows.Forms.DockStyle.Top;
         this._label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this._label2.Location = new System.Drawing.Point(0, 0);
         this._label2.Name = "_label2";
         this._label2.Size = new System.Drawing.Size(636, 23);
         this._label2.TabIndex = 0;
         this._label2.Text = "Studies Found: (Select item to retrieve series)";
         // 
         // _splitContainer4
         // 
         this._splitContainer4.Dock = System.Windows.Forms.DockStyle.Fill;
         this._splitContainer4.Location = new System.Drawing.Point(0, 0);
         this._splitContainer4.Name = "_splitContainer4";
         this._splitContainer4.Orientation = System.Windows.Forms.Orientation.Horizontal;
         // 
         // _splitContainer4.Panel1
         // 
         this._splitContainer4.Panel1.Controls.Add(this.buttonCGetStorageClasses);
         this._splitContainer4.Panel1.Controls.Add(this._radioButtonCGet);
         this._splitContainer4.Panel1.Controls.Add(this._radioButtonCMove);
         this._splitContainer4.Panel1.Controls.Add(this._listViewSeries);
         this._splitContainer4.Panel1.Controls.Add(this._label3);
         // 
         // _splitContainer4.Panel2
         // 
         this._splitContainer4.Panel2.Controls.Add(this._splitContainer5);
         this._splitContainer4.Size = new System.Drawing.Size(636, 571);
         this._splitContainer4.SplitterDistance = 133;
         this._splitContainer4.TabIndex = 0;
         // 
         // buttonCGetStorageClasses
         // 
         this.buttonCGetStorageClasses.Location = new System.Drawing.Point(415, 0);
         this.buttonCGetStorageClasses.Name = "buttonCGetStorageClasses";
         this.buttonCGetStorageClasses.Size = new System.Drawing.Size(146, 23);
         this.buttonCGetStorageClasses.TabIndex = 5;
         this.buttonCGetStorageClasses.Text = "C-GET Storage Classes...";
         this.buttonCGetStorageClasses.UseVisualStyleBackColor = true;
         this.buttonCGetStorageClasses.Click += new System.EventHandler(this.buttonCGetStorageClasses_Click);
         // 
         // _radioButtonCGet
         // 
         this._radioButtonCGet.AutoSize = true;
         this._radioButtonCGet.Location = new System.Drawing.Point(355, 2);
         this._radioButtonCGet.Name = "_radioButtonCGet";
         this._radioButtonCGet.Size = new System.Drawing.Size(57, 17);
         this._radioButtonCGet.TabIndex = 4;
         this._radioButtonCGet.TabStop = true;
         this._radioButtonCGet.Text = "C-GET";
         this._radioButtonCGet.UseVisualStyleBackColor = true;
         this._radioButtonCGet.CheckedChanged += new System.EventHandler(this._radioButtonCGet_CheckedChanged);
         // 
         // _radioButtonCMove
         // 
         this._radioButtonCMove.AutoSize = true;
         this._radioButtonCMove.Location = new System.Drawing.Point(279, 2);
         this._radioButtonCMove.Name = "_radioButtonCMove";
         this._radioButtonCMove.Size = new System.Drawing.Size(66, 17);
         this._radioButtonCMove.TabIndex = 3;
         this._radioButtonCMove.TabStop = true;
         this._radioButtonCMove.Text = "C-MOVE";
         this._radioButtonCMove.UseVisualStyleBackColor = true;
         this._radioButtonCMove.CheckedChanged += new System.EventHandler(this._radioButtonCMove_CheckedChanged);
         // 
         // _listViewSeries
         // 
         this._listViewSeries.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this._columnHeader7,
            this._columnHeader8,
            this._columnHeader9,
            this._columnHeader10,
            this._columnHeader11});
         this._listViewSeries.Dock = System.Windows.Forms.DockStyle.Fill;
         this._listViewSeries.FullRowSelect = true;
         this._listViewSeries.GridLines = true;
         this._listViewSeries.HideSelection = false;
         this._listViewSeries.Location = new System.Drawing.Point(0, 23);
         this._listViewSeries.MultiSelect = false;
         this._listViewSeries.Name = "_listViewSeries";
         this._listViewSeries.Size = new System.Drawing.Size(636, 110);
         this._listViewSeries.TabIndex = 1;
         this._listViewSeries.UseCompatibleStateImageBehavior = false;
         this._listViewSeries.View = System.Windows.Forms.View.Details;
         this._listViewSeries.SelectedIndexChanged += new System.EventHandler(this._listViewSeries_SelectedIndexChanged);
         this._listViewSeries.DoubleClick += new System.EventHandler(this._listViewSeries_DoubleClick);
         this._listViewSeries.Resize += new System.EventHandler(this._listViewSeries_Resize);
         // 
         // _columnHeader7
         // 
         this._columnHeader7.Text = "Series Date";
         // 
         // _columnHeader8
         // 
         this._columnHeader8.Text = "Series Number";
         // 
         // _columnHeader9
         // 
         this._columnHeader9.Text = "Series Description";
         // 
         // _columnHeader10
         // 
         this._columnHeader10.Text = "Modality";
         // 
         // _columnHeader11
         // 
         this._columnHeader11.Text = "Number of Instances";
         // 
         // _label3
         // 
         this._label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
         this._label3.Dock = System.Windows.Forms.DockStyle.Top;
         this._label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this._label3.Location = new System.Drawing.Point(0, 0);
         this._label3.Name = "_label3";
         this._label3.Size = new System.Drawing.Size(636, 23);
         this._label3.TabIndex = 0;
         this._label3.Text = "Series Found: (Double-click to retrieve images)";
         // 
         // _splitContainer5
         // 
         this._splitContainer5.Dock = System.Windows.Forms.DockStyle.Fill;
         this._splitContainer5.Location = new System.Drawing.Point(0, 0);
         this._splitContainer5.Name = "_splitContainer5";
         this._splitContainer5.Orientation = System.Windows.Forms.Orientation.Horizontal;
         // 
         // _splitContainer5.Panel1
         // 
         this._splitContainer5.Panel1.Controls.Add(this._toolStripCancel);
         this._splitContainer5.Panel1.Controls.Add(this._label4);
         // 
         // _splitContainer5.Panel2
         // 
         this._splitContainer5.Panel2.Controls.Add(this._labelStatus);
         this._splitContainer5.Panel2.Controls.Add(this._richTextBoxLog);
         this._splitContainer5.Panel2.Controls.Add(this._label5);
         this._splitContainer5.Size = new System.Drawing.Size(636, 434);
         this._splitContainer5.SplitterDistance = 267;
         this._splitContainer5.TabIndex = 0;
         // 
         // _toolStripCancel
         // 
         this._toolStripCancel.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._toolStripButtonCancel});
         this._toolStripCancel.Location = new System.Drawing.Point(0, 23);
         this._toolStripCancel.Name = "_toolStripCancel";
         this._toolStripCancel.Size = new System.Drawing.Size(636, 25);
         this._toolStripCancel.TabIndex = 2;
         this._toolStripCancel.Text = "_toolStripCancel";
         this._toolStripCancel.Visible = false;
         // 
         // _toolStripButtonCancel
         // 
         this._toolStripButtonCancel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this._toolStripButtonCancel.Image = ((System.Drawing.Image)(resources.GetObject("_toolStripButtonCancel.Image")));
         this._toolStripButtonCancel.ImageTransparentColor = System.Drawing.Color.Magenta;
         this._toolStripButtonCancel.Name = "_toolStripButtonCancel";
         this._toolStripButtonCancel.Size = new System.Drawing.Size(23, 22);
         this._toolStripButtonCancel.Text = "_toolStripButtonCancel";
         // 
         // _label4
         // 
         this._label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
         this._label4.Dock = System.Windows.Forms.DockStyle.Top;
         this._label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this._label4.Location = new System.Drawing.Point(0, 0);
         this._label4.Name = "_label4";
         this._label4.Size = new System.Drawing.Size(636, 23);
         this._label4.TabIndex = 0;
         this._label4.Text = "Images: (Left Double-click thumbnail to view image, Right to window level, Wheel " +
    "to change frame)";
         // 
         // _labelStatus
         // 
         this._labelStatus.AutoSize = true;
         this._labelStatus.ForeColor = System.Drawing.Color.Blue;
         this._labelStatus.Location = new System.Drawing.Point(193, 1);
         this._labelStatus.Name = "_labelStatus";
         this._labelStatus.Size = new System.Drawing.Size(35, 13);
         this._labelStatus.TabIndex = 2;
         this._labelStatus.Text = "status";
         // 
         // _richTextBoxLog
         // 
         this._richTextBoxLog.ContextMenuStrip = this._contextMenuStripLog;
         this._richTextBoxLog.Dock = System.Windows.Forms.DockStyle.Fill;
         this._richTextBoxLog.Location = new System.Drawing.Point(0, 23);
         this._richTextBoxLog.Name = "_richTextBoxLog";
         this._richTextBoxLog.ReadOnly = true;
         this._richTextBoxLog.Size = new System.Drawing.Size(636, 140);
         this._richTextBoxLog.TabIndex = 1;
         this._richTextBoxLog.Text = "";
         this._richTextBoxLog.WordWrap = false;
         // 
         // _contextMenuStripLog
         // 
         this._contextMenuStripLog.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._toolStripMenuItem1});
         this._contextMenuStripLog.Name = "_contextMenuStripLog";
         this._contextMenuStripLog.Size = new System.Drawing.Size(125, 26);
         // 
         // _toolStripMenuItem1
         // 
         this._toolStripMenuItem1.Name = "_toolStripMenuItem1";
         this._toolStripMenuItem1.Size = new System.Drawing.Size(124, 22);
         this._toolStripMenuItem1.Text = "&Clear Log";
         this._toolStripMenuItem1.Click += new System.EventHandler(this._toolStripMenuItem1_Click);
         // 
         // _label5
         // 
         this._label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
         this._label5.Dock = System.Windows.Forms.DockStyle.Top;
         this._label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this._label5.Location = new System.Drawing.Point(0, 0);
         this._label5.Name = "_label5";
         this._label5.Size = new System.Drawing.Size(636, 23);
         this._label5.TabIndex = 0;
         this._label5.Text = "Log: (Right-click to clear)";
         // 
         // MainForm
         // 
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
         this.ClientSize = new System.Drawing.Size(888, 734);
         this.Controls.Add(this._splitContainer1);
         this.Controls.Add(this._menuStrip);
         this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
         this.MainMenuStrip = this._menuStrip;
         this.MinimumSize = new System.Drawing.Size(640, 480);
         this.Name = "MainForm";
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
         this.Text = "LEADTOOLS High Level DICOM Client Demo - C#";
         this.Activated += new System.EventHandler(this.MainForm_Activated);
         this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
         this.Load += new System.EventHandler(this.MainForm_Load);
         this._menuStrip.ResumeLayout(false);
         this._menuStrip.PerformLayout();
         this._splitContainer1.Panel1.ResumeLayout(false);
         this._splitContainer1.Panel2.ResumeLayout(false);
         ((System.ComponentModel.ISupportInitialize)(this._splitContainer1)).EndInit();
         this._splitContainer1.ResumeLayout(false);
         this._splitContainer2.Panel1.ResumeLayout(false);
         this._splitContainer2.Panel2.ResumeLayout(false);
         ((System.ComponentModel.ISupportInitialize)(this._splitContainer2)).EndInit();
         this._splitContainer2.ResumeLayout(false);
         this._groupBoxServer.ResumeLayout(false);
         this._groupBoxServer.PerformLayout();
         this._splitContainer3.Panel1.ResumeLayout(false);
         this._splitContainer3.Panel2.ResumeLayout(false);
         ((System.ComponentModel.ISupportInitialize)(this._splitContainer3)).EndInit();
         this._splitContainer3.ResumeLayout(false);
         this._splitContainer4.Panel1.ResumeLayout(false);
         this._splitContainer4.Panel1.PerformLayout();
         this._splitContainer4.Panel2.ResumeLayout(false);
         ((System.ComponentModel.ISupportInitialize)(this._splitContainer4)).EndInit();
         this._splitContainer4.ResumeLayout(false);
         this._splitContainer5.Panel1.ResumeLayout(false);
         this._splitContainer5.Panel1.PerformLayout();
         this._splitContainer5.Panel2.ResumeLayout(false);
         this._splitContainer5.Panel2.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this._splitContainer5)).EndInit();
         this._splitContainer5.ResumeLayout(false);
         this._toolStripCancel.ResumeLayout(false);
         this._toolStripCancel.PerformLayout();
         this._contextMenuStripLog.ResumeLayout(false);
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem clearLogToolStripMenuItem;
      private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
      private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
      private System.Windows.Forms.MenuStrip _menuStrip;
      private System.Windows.Forms.SplitContainer _splitContainer1;
      private System.Windows.Forms.SplitContainer _splitContainer2;
      private System.Windows.Forms.Label _label1;
      private System.Windows.Forms.Button _buttonOptions;
      private System.Windows.Forms.SplitContainer _splitContainer3;
      private System.Windows.Forms.Label _label2;
      private System.Windows.Forms.SplitContainer _splitContainer4;
      private System.Windows.Forms.Label _label3;
      private System.Windows.Forms.SplitContainer _splitContainer5;
      private System.Windows.Forms.Label _label4;
      private System.Windows.Forms.Button _buttonSearch;
      private System.Windows.Forms.PropertyGrid _propertyGrid;
      private System.Windows.Forms.ListView _listViewStudies;
      private System.Windows.Forms.ListView _listViewSeries;
      private System.Windows.Forms.ColumnHeader _columnHeader1;
      private System.Windows.Forms.ColumnHeader _columnHeader2;
      private System.Windows.Forms.ColumnHeader _columnHeader3;
      private System.Windows.Forms.ColumnHeader _columnHeader4;
      private System.Windows.Forms.ColumnHeader _columnHeader5;
      private System.Windows.Forms.ColumnHeader _columnHeader6;
      private System.Windows.Forms.ColumnHeader _columnHeader7;
      private System.Windows.Forms.ColumnHeader _columnHeader8;
      private System.Windows.Forms.ColumnHeader _columnHeader9;
      private System.Windows.Forms.ColumnHeader _columnHeader10;
      private System.Windows.Forms.ColumnHeader _columnHeader11;
      private System.Windows.Forms.ToolStrip _toolStripCancel;
      private System.Windows.Forms.ToolStripButton _toolStripButtonCancel;
      private System.Windows.Forms.ContextMenuStrip _contextMenuStripLog;
      private System.Windows.Forms.ToolStripMenuItem _toolStripMenuItem1;
      private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem searchToolStripMenuItem;
      private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
      private System.Windows.Forms.Button _buttonCancel;
      private System.Windows.Forms.Label _labelStatus;
      private System.Windows.Forms.ToolStripMenuItem showHelpToolStripMenuItem;
      private System.Windows.Forms.RichTextBox _richTextBoxLog;
      private System.Windows.Forms.Label _label5;
      private System.Windows.Forms.GroupBox _groupBoxServer;
      private System.Windows.Forms.Label _labelServerPort;
      private System.Windows.Forms.Label _labelServerIp;
      private System.Windows.Forms.Label _labelServerAeTitle;
      private System.Windows.Forms.TextBox _textBoxServerPort;
      private System.Windows.Forms.TextBox _textBoxServerIp;
      private System.Windows.Forms.ComboBox _comboBoxService;
      private System.Windows.Forms.ColumnHeader _columnHeaderStudyTime;
      private System.Windows.Forms.Button buttonCGetStorageClasses;
      private System.Windows.Forms.RadioButton _radioButtonCGet;
      private System.Windows.Forms.RadioButton _radioButtonCMove;
   }
}


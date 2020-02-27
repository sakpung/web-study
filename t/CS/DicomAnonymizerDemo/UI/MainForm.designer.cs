using DicomAnonymizer.UI.Controls;
namespace DicomAnonymizer
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
           System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
           this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
           this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
           this.statusStrip1 = new System.Windows.Forms.StatusStrip();
           this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
           this.toolStripProgressBar = new System.Windows.Forms.ToolStripProgressBar();
           this.splitContainerMain = new System.Windows.Forms.SplitContainer();
           this.treeGridViewTags = new DicomAnonymizer.UI.Controls.TreeGridView();
           this.columnTag = new DicomAnonymizer.UI.Controls.TreeGridColumn();
           this.columnName = new System.Windows.Forms.DataGridViewTextBoxColumn();
           this.columnValue = new System.Windows.Forms.DataGridViewComboBoxColumn();
           this.label3 = new System.Windows.Forms.Label();
           this.treeGridViewDifference = new DicomAnonymizer.UI.Controls.TreeGridView();
           this.tagColumn = new DicomAnonymizer.UI.Controls.TreeGridColumn();
           this.nameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
           this.vrColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
           this.data1Value = new System.Windows.Forms.DataGridViewTextBoxColumn();
           this.data2Column = new System.Windows.Forms.DataGridViewTextBoxColumn();
           this.diffColumn = new DicomAnonymizer.UI.Controls.DataGridViewDisableButtonColumn();
           this.toolStrip2 = new System.Windows.Forms.ToolStrip();
           this.toolStripButtonAnonymize = new System.Windows.Forms.ToolStripButton();
           this.toolStripButtonRefresh = new System.Windows.Forms.ToolStripButton();
           this.toolStripButtonRedact = new System.Windows.Forms.ToolStripButton();
           this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
           this.toolStripButtonSaveDataset = new System.Windows.Forms.ToolStripButton();
           this.toolStripButtonView = new System.Windows.Forms.ToolStripButton();
           this.menuStrip1 = new System.Windows.Forms.MenuStrip();
           this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
           this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
           this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
           this.defaultToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
           this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
           this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
           this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
           this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
           this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
           this.tagToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
           this.insertToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
           this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
           this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
           this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
           this.toolStrip1 = new System.Windows.Forms.ToolStrip();
           this.toolStripButtonNew = new System.Windows.Forms.ToolStripButton();
           this.toolStripButtonOpen = new System.Windows.Forms.ToolStripButton();
           this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
           this.toolStripButtonSave = new System.Windows.Forms.ToolStripButton();
           this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
           this.toolStripButtonInsertTag = new System.Windows.Forms.ToolStripButton();
           this.toolStripButtonDeleteTag = new System.Windows.Forms.ToolStripButton();
           this.anonymizeopenFileDialog = new System.Windows.Forms.OpenFileDialog();
           this.toolStripContainer1.BottomToolStripPanel.SuspendLayout();
           this.toolStripContainer1.ContentPanel.SuspendLayout();
           this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
           this.toolStripContainer1.SuspendLayout();
           this.statusStrip1.SuspendLayout();
           this.splitContainerMain.Panel1.SuspendLayout();
           this.splitContainerMain.Panel2.SuspendLayout();
           this.splitContainerMain.SuspendLayout();
           ((System.ComponentModel.ISupportInitialize)(this.treeGridViewTags)).BeginInit();
           ((System.ComponentModel.ISupportInitialize)(this.treeGridViewDifference)).BeginInit();
           this.toolStrip2.SuspendLayout();
           this.menuStrip1.SuspendLayout();
           this.toolStrip1.SuspendLayout();
           this.SuspendLayout();
           // 
           // openFileDialog
           // 
           this.openFileDialog.Filter = "DICOM Files|*.dcm;*.dic; *.pre|All files|*.* ";
           // 
           // toolStripContainer1
           // 
           // 
           // toolStripContainer1.BottomToolStripPanel
           // 
           this.toolStripContainer1.BottomToolStripPanel.Controls.Add(this.statusStrip1);
           // 
           // toolStripContainer1.ContentPanel
           // 
           this.toolStripContainer1.ContentPanel.Controls.Add(this.splitContainerMain);
           this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(1079, 594);
           this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
           this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
           this.toolStripContainer1.Name = "toolStripContainer1";
           this.toolStripContainer1.Size = new System.Drawing.Size(1079, 665);
           this.toolStripContainer1.TabIndex = 2;
           this.toolStripContainer1.Text = "toolStripContainer1";
           // 
           // toolStripContainer1.TopToolStripPanel
           // 
           this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.menuStrip1);
           this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.toolStrip1);
           // 
           // statusStrip1
           // 
           this.statusStrip1.Dock = System.Windows.Forms.DockStyle.None;
           this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel,
            this.toolStripProgressBar});
           this.statusStrip1.Location = new System.Drawing.Point(0, 0);
           this.statusStrip1.Name = "statusStrip1";
           this.statusStrip1.Size = new System.Drawing.Size(1079, 22);
           this.statusStrip1.TabIndex = 0;
           // 
           // toolStripStatusLabel
           // 
           this.toolStripStatusLabel.Name = "toolStripStatusLabel";
           this.toolStripStatusLabel.Size = new System.Drawing.Size(87, 17);
           this.toolStripStatusLabel.Text = "Anonymizing...";
           this.toolStripStatusLabel.Visible = false;
           // 
           // toolStripProgressBar
           // 
           this.toolStripProgressBar.Name = "toolStripProgressBar";
           this.toolStripProgressBar.Size = new System.Drawing.Size(100, 16);
           this.toolStripProgressBar.ToolTipText = "Anonymizing Dataset";
           this.toolStripProgressBar.Visible = false;
           // 
           // splitContainerMain
           // 
           this.splitContainerMain.Dock = System.Windows.Forms.DockStyle.Fill;
           this.splitContainerMain.Location = new System.Drawing.Point(0, 0);
           this.splitContainerMain.Name = "splitContainerMain";
           this.splitContainerMain.Orientation = System.Windows.Forms.Orientation.Horizontal;
           // 
           // splitContainerMain.Panel1
           // 
           this.splitContainerMain.Panel1.Controls.Add(this.treeGridViewTags);
           this.splitContainerMain.Panel1.Controls.Add(this.label3);
           // 
           // splitContainerMain.Panel2
           // 
           this.splitContainerMain.Panel2.Controls.Add(this.treeGridViewDifference);
           this.splitContainerMain.Panel2.Controls.Add(this.toolStrip2);
           this.splitContainerMain.Size = new System.Drawing.Size(1079, 594);
           this.splitContainerMain.SplitterDistance = 296;
           this.splitContainerMain.TabIndex = 1;
           // 
           // treeGridViewTags
           // 
           this.treeGridViewTags.AllowDrop = true;
           this.treeGridViewTags.AllowUserToAddRows = false;
           this.treeGridViewTags.AllowUserToDeleteRows = false;
           this.treeGridViewTags.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.columnTag,
            this.columnName,
            this.columnValue});
           this.treeGridViewTags.DividerColor = System.Drawing.Color.Red;
           this.treeGridViewTags.Dock = System.Windows.Forms.DockStyle.Fill;
           this.treeGridViewTags.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
           this.treeGridViewTags.ImageList = null;
           this.treeGridViewTags.Location = new System.Drawing.Point(0, 13);
           this.treeGridViewTags.Name = "treeGridViewTags";
           this.treeGridViewTags.SelectionColor = System.Drawing.Color.Blue;
           this.treeGridViewTags.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
           this.treeGridViewTags.Size = new System.Drawing.Size(1079, 283);
           this.treeGridViewTags.TabIndex = 0;
           this.treeGridViewTags.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.treeGridViewTags_CellBeginEdit);
           this.treeGridViewTags.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.treeGridViewTags_CellFormatting);
           // 
           // columnTag
           // 
           this.columnTag.DefaultNodeImage = null;
           this.columnTag.HeaderText = "Tag";
           this.columnTag.Name = "columnTag";
           this.columnTag.Resizable = System.Windows.Forms.DataGridViewTriState.True;
           this.columnTag.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
           this.columnTag.Width = 32;
           // 
           // columnName
           // 
           this.columnName.HeaderText = "Name";
           this.columnName.Name = "columnName";
           this.columnName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
           this.columnName.Width = 66;
           // 
           // columnValue
           // 
           this.columnValue.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
           this.columnValue.HeaderText = "Value";
           this.columnValue.Name = "columnValue";
           this.columnValue.Resizable = System.Windows.Forms.DataGridViewTriState.True;
           // 
           // label3
           // 
           this.label3.AutoSize = true;
           this.label3.Dock = System.Windows.Forms.DockStyle.Top;
           this.label3.Location = new System.Drawing.Point(0, 0);
           this.label3.Name = "label3";
           this.label3.Size = new System.Drawing.Size(108, 13);
           this.label3.TabIndex = 1;
           this.label3.Text = "Anonymization Script:";
           // 
           // treeGridViewDifference
           // 
           this.treeGridViewDifference.AllowDrop = true;
           this.treeGridViewDifference.AllowUserToAddRows = false;
           this.treeGridViewDifference.AllowUserToDeleteRows = false;
           this.treeGridViewDifference.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
           this.treeGridViewDifference.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.tagColumn,
            this.nameColumn,
            this.vrColumn,
            this.data1Value,
            this.data2Column,
            this.diffColumn});
           this.treeGridViewDifference.DividerColor = System.Drawing.Color.Red;
           this.treeGridViewDifference.Dock = System.Windows.Forms.DockStyle.Fill;
           this.treeGridViewDifference.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
           this.treeGridViewDifference.ImageList = null;
           this.treeGridViewDifference.Location = new System.Drawing.Point(0, 25);
           this.treeGridViewDifference.MultiSelect = false;
           this.treeGridViewDifference.Name = "treeGridViewDifference";
           this.treeGridViewDifference.ReadOnly = true;
           this.treeGridViewDifference.RowHeadersVisible = false;
           this.treeGridViewDifference.SelectionColor = System.Drawing.Color.Blue;
           this.treeGridViewDifference.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
           this.treeGridViewDifference.Size = new System.Drawing.Size(1079, 269);
           this.treeGridViewDifference.TabIndex = 1;
           // 
           // tagColumn
           // 
           this.tagColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
           this.tagColumn.DefaultNodeImage = null;
           this.tagColumn.FillWeight = 10F;
           this.tagColumn.HeaderText = "Tag";
           this.tagColumn.Name = "tagColumn";
           this.tagColumn.ReadOnly = true;
           this.tagColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
           // 
           // nameColumn
           // 
           this.nameColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
           this.nameColumn.FillWeight = 10F;
           this.nameColumn.HeaderText = "Name";
           this.nameColumn.Name = "nameColumn";
           this.nameColumn.ReadOnly = true;
           this.nameColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
           // 
           // vrColumn
           // 
           this.vrColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
           this.vrColumn.FillWeight = 5F;
           this.vrColumn.HeaderText = "VR";
           this.vrColumn.Name = "vrColumn";
           this.vrColumn.ReadOnly = true;
           this.vrColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
           // 
           // data1Value
           // 
           this.data1Value.FillWeight = 25F;
           this.data1Value.HeaderText = "Original Value";
           this.data1Value.Name = "data1Value";
           this.data1Value.ReadOnly = true;
           this.data1Value.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
           // 
           // data2Column
           // 
           this.data2Column.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
           this.data2Column.FillWeight = 25F;
           this.data2Column.HeaderText = "Anonymized Value";
           this.data2Column.Name = "data2Column";
           this.data2Column.ReadOnly = true;
           this.data2Column.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
           // 
           // diffColumn
           // 
           this.diffColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
           this.diffColumn.FillWeight = 10F;
           this.diffColumn.HeaderText = "Difference";
           this.diffColumn.Name = "diffColumn";
           this.diffColumn.ReadOnly = true;
           this.diffColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
           this.diffColumn.Text = "Diff";
           // 
           // toolStrip2
           // 
           this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonAnonymize,
            this.toolStripButtonRefresh,
            this.toolStripButtonRedact,
            this.toolStripSeparator2,
            this.toolStripButtonSaveDataset,
            this.toolStripButtonView});
           this.toolStrip2.Location = new System.Drawing.Point(0, 0);
           this.toolStrip2.Name = "toolStrip2";
           this.toolStrip2.Size = new System.Drawing.Size(1079, 25);
           this.toolStrip2.TabIndex = 3;
           this.toolStrip2.Text = "toolStrip2";
           // 
           // toolStripButtonAnonymize
           // 
           this.toolStripButtonAnonymize.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
           this.toolStripButtonAnonymize.Image = global::DicomAnonymizer.Properties.Resources.Anonymou;
           this.toolStripButtonAnonymize.ImageTransparentColor = System.Drawing.Color.Magenta;
           this.toolStripButtonAnonymize.Name = "toolStripButtonAnonymize";
           this.toolStripButtonAnonymize.Size = new System.Drawing.Size(23, 22);
           this.toolStripButtonAnonymize.Text = "toolStripButtonAnonymize";
           this.toolStripButtonAnonymize.ToolTipText = "Anonymize Dicom File";
           this.toolStripButtonAnonymize.Click += new System.EventHandler(this.anonymizefileToolStripMenuItem_Click);
           // 
           // toolStripButtonRefresh
           // 
           this.toolStripButtonRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
           this.toolStripButtonRefresh.Image = global::DicomAnonymizer.Properties.Resources.AnonymousRefresh_16x16;
           this.toolStripButtonRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
           this.toolStripButtonRefresh.Name = "toolStripButtonRefresh";
           this.toolStripButtonRefresh.Size = new System.Drawing.Size(23, 22);
           this.toolStripButtonRefresh.Text = "toolStripButtonRefresh";
           this.toolStripButtonRefresh.ToolTipText = "Refresh Anonymization";
           this.toolStripButtonRefresh.Click += new System.EventHandler(this.toolStripButtonRefresh_Click);
           // 
           // toolStripButtonRedact
           // 
           this.toolStripButtonRedact.CheckOnClick = true;
           this.toolStripButtonRedact.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
           this.toolStripButtonRedact.Image = global::DicomAnonymizer.Properties.Resources.Redact_16x16;
           this.toolStripButtonRedact.ImageTransparentColor = System.Drawing.Color.Magenta;
           this.toolStripButtonRedact.Name = "toolStripButtonRedact";
           this.toolStripButtonRedact.Size = new System.Drawing.Size(23, 22);
           this.toolStripButtonRedact.Text = "toolStripButton1";
           this.toolStripButtonRedact.ToolTipText = "Enable redact rectangle selection";
           // 
           // toolStripSeparator2
           // 
           this.toolStripSeparator2.Name = "toolStripSeparator2";
           this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
           // 
           // toolStripButtonSaveDataset
           // 
           this.toolStripButtonSaveDataset.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
           this.toolStripButtonSaveDataset.Image = global::DicomAnonymizer.Properties.Resources.SaveDataset_16x16;
           this.toolStripButtonSaveDataset.ImageTransparentColor = System.Drawing.Color.Magenta;
           this.toolStripButtonSaveDataset.Name = "toolStripButtonSaveDataset";
           this.toolStripButtonSaveDataset.Size = new System.Drawing.Size(23, 22);
           this.toolStripButtonSaveDataset.Text = "Save Anonymized Dataset";
           this.toolStripButtonSaveDataset.Click += new System.EventHandler(this.toolStripButtonSaveDataset_Click);
           // 
           // toolStripButtonView
           // 
           this.toolStripButtonView.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
           this.toolStripButtonView.Image = global::DicomAnonymizer.Properties.Resources.ViewImage_16x16;
           this.toolStripButtonView.ImageTransparentColor = System.Drawing.Color.Magenta;
           this.toolStripButtonView.Name = "toolStripButtonView";
           this.toolStripButtonView.Size = new System.Drawing.Size(23, 22);
           this.toolStripButtonView.Text = "View Anonymized Image";
           this.toolStripButtonView.Click += new System.EventHandler(this.toolStripButtonView_Click);
           // 
           // menuStrip1
           // 
           this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
           this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.tagToolStripMenuItem,
            this.helpToolStripMenuItem});
           this.menuStrip1.Location = new System.Drawing.Point(0, 0);
           this.menuStrip1.Name = "menuStrip1";
           this.menuStrip1.Size = new System.Drawing.Size(1079, 24);
           this.menuStrip1.TabIndex = 1;
           this.menuStrip1.Text = "menuStrip1";
           // 
           // fileToolStripMenuItem
           // 
           this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.defaultToolStripMenuItem,
            this.toolStripSeparator,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
           this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
           this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
           this.fileToolStripMenuItem.Text = "&File";
           this.fileToolStripMenuItem.DropDownOpening += new System.EventHandler(this.fileToolStripMenuItem_DropDownOpening);
           // 
           // newToolStripMenuItem
           // 
           this.newToolStripMenuItem.Image = global::DicomAnonymizer.Properties.Resources.NewScript_16x16;
           this.newToolStripMenuItem.Name = "newToolStripMenuItem";
           this.newToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
           this.newToolStripMenuItem.Size = new System.Drawing.Size(219, 22);
           this.newToolStripMenuItem.Text = "&New Script...";
           this.newToolStripMenuItem.ToolTipText = "New script";
           this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
           // 
           // openToolStripMenuItem
           // 
           this.openToolStripMenuItem.Image = global::DicomAnonymizer.Properties.Resources.OpenScript_16x16;
           this.openToolStripMenuItem.Name = "openToolStripMenuItem";
           this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
           this.openToolStripMenuItem.Size = new System.Drawing.Size(219, 22);
           this.openToolStripMenuItem.Text = "&Open Script...";
           this.openToolStripMenuItem.ToolTipText = "Open existing script";
           this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
           // 
           // defaultToolStripMenuItem
           // 
           this.defaultToolStripMenuItem.Name = "defaultToolStripMenuItem";
           this.defaultToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D)));
           this.defaultToolStripMenuItem.Size = new System.Drawing.Size(219, 22);
           this.defaultToolStripMenuItem.Text = "Open &Default Script";
           this.defaultToolStripMenuItem.ToolTipText = "Open Default Script";
           this.defaultToolStripMenuItem.Click += new System.EventHandler(this.defaultToolStripMenuItem_Click);
           // 
           // toolStripSeparator
           // 
           this.toolStripSeparator.Name = "toolStripSeparator";
           this.toolStripSeparator.Size = new System.Drawing.Size(216, 6);
           // 
           // saveToolStripMenuItem
           // 
           this.saveToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("saveToolStripMenuItem.Image")));
           this.saveToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
           this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
           this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
           this.saveToolStripMenuItem.Size = new System.Drawing.Size(219, 22);
           this.saveToolStripMenuItem.Text = "&Save Script";
           this.saveToolStripMenuItem.ToolTipText = "Save script";
           this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
           // 
           // saveAsToolStripMenuItem
           // 
           this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
           this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(219, 22);
           this.saveAsToolStripMenuItem.Text = "Save Script &As...";
           this.saveAsToolStripMenuItem.ToolTipText = "Save script as new file";
           this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
           // 
           // toolStripSeparator1
           // 
           this.toolStripSeparator1.Name = "toolStripSeparator1";
           this.toolStripSeparator1.Size = new System.Drawing.Size(216, 6);
           // 
           // exitToolStripMenuItem
           // 
           this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
           this.exitToolStripMenuItem.Size = new System.Drawing.Size(219, 22);
           this.exitToolStripMenuItem.Text = "E&xit";
           this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
           // 
           // tagToolStripMenuItem
           // 
           this.tagToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.insertToolStripMenuItem,
            this.deleteToolStripMenuItem});
           this.tagToolStripMenuItem.Name = "tagToolStripMenuItem";
           this.tagToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
           this.tagToolStripMenuItem.Text = "&Tag";
           this.tagToolStripMenuItem.DropDownOpening += new System.EventHandler(this.tagToolStripMenuItem_DropDownOpening);
           // 
           // insertToolStripMenuItem
           // 
           this.insertToolStripMenuItem.Name = "insertToolStripMenuItem";
           this.insertToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.I)));
           this.insertToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
           this.insertToolStripMenuItem.Text = "&Insert...";
           this.insertToolStripMenuItem.Click += new System.EventHandler(this.insertToolStripMenuItem_Click);
           // 
           // deleteToolStripMenuItem
           // 
           this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
           this.deleteToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Delete;
           this.deleteToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
           this.deleteToolStripMenuItem.Text = "&Delete";
           this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
           // 
           // helpToolStripMenuItem
           // 
           this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
           this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
           this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
           this.helpToolStripMenuItem.Text = "&Help";
           // 
           // aboutToolStripMenuItem
           // 
           this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
           this.aboutToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
           this.aboutToolStripMenuItem.Text = "&About";
           this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
           // 
           // toolStrip1
           // 
           this.toolStrip1.AutoSize = false;
           this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
           this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonNew,
            this.toolStripButtonOpen,
            this.toolStripSeparator5,
            this.toolStripButtonSave,
            this.toolStripSeparator3,
            this.toolStripButtonInsertTag,
            this.toolStripButtonDeleteTag});
           this.toolStrip1.Location = new System.Drawing.Point(0, 24);
           this.toolStrip1.Name = "toolStrip1";
           this.toolStrip1.Size = new System.Drawing.Size(1079, 25);
           this.toolStrip1.Stretch = true;
           this.toolStrip1.TabIndex = 2;
           // 
           // toolStripButtonNew
           // 
           this.toolStripButtonNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
           this.toolStripButtonNew.Image = global::DicomAnonymizer.Properties.Resources.NewScript_16x16;
           this.toolStripButtonNew.ImageTransparentColor = System.Drawing.Color.Magenta;
           this.toolStripButtonNew.Name = "toolStripButtonNew";
           this.toolStripButtonNew.Size = new System.Drawing.Size(23, 22);
           this.toolStripButtonNew.Text = "New Anonymization Script";
           this.toolStripButtonNew.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
           // 
           // toolStripButtonOpen
           // 
           this.toolStripButtonOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
           this.toolStripButtonOpen.Image = global::DicomAnonymizer.Properties.Resources.OpenScript_16x16;
           this.toolStripButtonOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
           this.toolStripButtonOpen.Name = "toolStripButtonOpen";
           this.toolStripButtonOpen.Size = new System.Drawing.Size(23, 22);
           this.toolStripButtonOpen.Text = "Open Anonymization Script";
           this.toolStripButtonOpen.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
           // 
           // toolStripSeparator5
           // 
           this.toolStripSeparator5.Name = "toolStripSeparator5";
           this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
           // 
           // toolStripButtonSave
           // 
           this.toolStripButtonSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
           this.toolStripButtonSave.Image = global::DicomAnonymizer.Properties.Resources.SaveDataset_16x16;
           this.toolStripButtonSave.ImageTransparentColor = System.Drawing.Color.Magenta;
           this.toolStripButtonSave.Name = "toolStripButtonSave";
           this.toolStripButtonSave.Size = new System.Drawing.Size(23, 22);
           this.toolStripButtonSave.Text = "Save Anonymization Script";
           this.toolStripButtonSave.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
           // 
           // toolStripSeparator3
           // 
           this.toolStripSeparator3.Name = "toolStripSeparator3";
           this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
           // 
           // toolStripButtonInsertTag
           // 
           this.toolStripButtonInsertTag.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
           this.toolStripButtonInsertTag.Image = global::DicomAnonymizer.Properties.Resources.InsertTag_24x24;
           this.toolStripButtonInsertTag.ImageTransparentColor = System.Drawing.Color.Magenta;
           this.toolStripButtonInsertTag.Name = "toolStripButtonInsertTag";
           this.toolStripButtonInsertTag.Size = new System.Drawing.Size(23, 22);
           this.toolStripButtonInsertTag.Text = "toolStripButton1";
           this.toolStripButtonInsertTag.ToolTipText = "Insert Tag";
           this.toolStripButtonInsertTag.Click += new System.EventHandler(this.insertToolStripMenuItem_Click);
           // 
           // toolStripButtonDeleteTag
           // 
           this.toolStripButtonDeleteTag.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
           this.toolStripButtonDeleteTag.Image = global::DicomAnonymizer.Properties.Resources.DeleteTag_24x24;
           this.toolStripButtonDeleteTag.ImageTransparentColor = System.Drawing.Color.Magenta;
           this.toolStripButtonDeleteTag.Name = "toolStripButtonDeleteTag";
           this.toolStripButtonDeleteTag.Size = new System.Drawing.Size(23, 22);
           this.toolStripButtonDeleteTag.Text = "toolStripButton2";
           this.toolStripButtonDeleteTag.ToolTipText = "Delete Tag";
           this.toolStripButtonDeleteTag.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
           // 
           // anonymizeopenFileDialog
           // 
           this.anonymizeopenFileDialog.AddExtension = false;
           this.anonymizeopenFileDialog.Filter = "DICOM Files|*.dcm;*.dic;*.pre|All files|*.* ";
           this.anonymizeopenFileDialog.FilterIndex = 0;
           this.anonymizeopenFileDialog.Multiselect = true;
           this.anonymizeopenFileDialog.Title = "Anonymize File";
           // 
           // MainForm
           // 
           this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
           this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
           this.ClientSize = new System.Drawing.Size(1079, 665);
           this.Controls.Add(this.toolStripContainer1);
           this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
           this.Name = "MainForm";
           this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
           this.Text = "DICOM Anonymization Demor";
           this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
           this.Load += new System.EventHandler(this.MainForm_Load);
           this.toolStripContainer1.BottomToolStripPanel.ResumeLayout(false);
           this.toolStripContainer1.BottomToolStripPanel.PerformLayout();
           this.toolStripContainer1.ContentPanel.ResumeLayout(false);
           this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
           this.toolStripContainer1.TopToolStripPanel.PerformLayout();
           this.toolStripContainer1.ResumeLayout(false);
           this.toolStripContainer1.PerformLayout();
           this.statusStrip1.ResumeLayout(false);
           this.statusStrip1.PerformLayout();
           this.splitContainerMain.Panel1.ResumeLayout(false);
           this.splitContainerMain.Panel1.PerformLayout();
           this.splitContainerMain.Panel2.ResumeLayout(false);
           this.splitContainerMain.Panel2.PerformLayout();
           this.splitContainerMain.ResumeLayout(false);
           ((System.ComponentModel.ISupportInitialize)(this.treeGridViewTags)).EndInit();
           ((System.ComponentModel.ISupportInitialize)(this.treeGridViewDifference)).EndInit();
           this.toolStrip2.ResumeLayout(false);
           this.toolStrip2.PerformLayout();
           this.menuStrip1.ResumeLayout(false);
           this.menuStrip1.PerformLayout();
           this.toolStrip1.ResumeLayout(false);
           this.toolStrip1.PerformLayout();
           this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private TreeGridView treeGridViewTags;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog anonymizeopenFileDialog;
        private System.Windows.Forms.SplitContainer splitContainerMain;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tagToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem insertToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private TreeGridView treeGridViewDifference;
        private TreeGridColumn tagColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn vrColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn data1Value;
        private System.Windows.Forms.DataGridViewTextBoxColumn data2Column;
        private DataGridViewDisableButtonColumn diffColumn;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton toolStripButtonSaveDataset;
        private System.Windows.Forms.ToolStripButton toolStripButtonView;
        private System.Windows.Forms.ToolStripButton toolStripButtonNew;
        private System.Windows.Forms.ToolStripButton toolStripButtonOpen;
        private System.Windows.Forms.ToolStripButton toolStripButtonSave;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar;
        private TreeGridColumn columnTag;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnName;
        private System.Windows.Forms.DataGridViewComboBoxColumn columnValue;
        private System.Windows.Forms.ToolStripMenuItem defaultToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton toolStripButtonInsertTag;
        private System.Windows.Forms.ToolStripButton toolStripButtonDeleteTag;
        private System.Windows.Forms.ToolStripButton toolStripButtonAnonymize;
        private System.Windows.Forms.ToolStripButton toolStripButtonRefresh;
        private System.Windows.Forms.ToolStripButton toolStripButtonRedact;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
    }
}


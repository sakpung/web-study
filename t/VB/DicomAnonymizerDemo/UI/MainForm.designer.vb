Imports Microsoft.VisualBasic
Imports System
Imports DicomAnonymizer.UI.Controls
Namespace DicomAnonymizer
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
         Me.openFileDialog = New System.Windows.Forms.OpenFileDialog()
         Me.toolStripContainer1 = New System.Windows.Forms.ToolStripContainer()
         Me.statusStrip1 = New System.Windows.Forms.StatusStrip()
         Me.toolStripStatusLabel = New System.Windows.Forms.ToolStripStatusLabel()
         Me.toolStripProgressBar = New System.Windows.Forms.ToolStripProgressBar()
         Me.splitContainerMain = New System.Windows.Forms.SplitContainer()
         Me.treeGridViewTags = New DicomAnonymizer.UI.Controls.TreeGridView()
         Me.columnTag = New DicomAnonymizer.UI.Controls.TreeGridColumn()
         Me.columnName = New System.Windows.Forms.DataGridViewTextBoxColumn()
         Me.columnValue = New System.Windows.Forms.DataGridViewComboBoxColumn()
         Me.label3 = New System.Windows.Forms.Label()
         Me.treeGridViewDifference = New DicomAnonymizer.UI.Controls.TreeGridView()
         Me.tagColumn = New DicomAnonymizer.UI.Controls.TreeGridColumn()
         Me.nameColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
         Me.vrColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
         Me.data1Value = New System.Windows.Forms.DataGridViewTextBoxColumn()
         Me.data2Column = New System.Windows.Forms.DataGridViewTextBoxColumn()
         Me.diffColumn = New DicomAnonymizer.UI.Controls.DataGridViewDisableButtonColumn()
         Me.toolStrip2 = New System.Windows.Forms.ToolStrip()
         Me.toolStripButtonAnonymize = New System.Windows.Forms.ToolStripButton()
         Me.toolStripButtonRefresh = New System.Windows.Forms.ToolStripButton()
         Me.toolStripButtonRedact = New System.Windows.Forms.ToolStripButton()
         Me.toolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
         Me.toolStripButtonSaveDataset = New System.Windows.Forms.ToolStripButton()
         Me.toolStripButtonView = New System.Windows.Forms.ToolStripButton()
         Me.menuStrip1 = New System.Windows.Forms.MenuStrip()
         Me.fileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me.newToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me.openToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me.defaultToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me.toolStripSeparator = New System.Windows.Forms.ToolStripSeparator()
         Me.saveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me.saveAsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me.toolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
         Me.exitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me.tagToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me.insertToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me.deleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me.helpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me.aboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me.toolStrip1 = New System.Windows.Forms.ToolStrip()
         Me.toolStripButtonNew = New System.Windows.Forms.ToolStripButton()
         Me.toolStripButtonOpen = New System.Windows.Forms.ToolStripButton()
         Me.toolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
         Me.toolStripButtonSave = New System.Windows.Forms.ToolStripButton()
         Me.toolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
         Me.toolStripButtonInsertTag = New System.Windows.Forms.ToolStripButton()
         Me.toolStripButtonDeleteTag = New System.Windows.Forms.ToolStripButton()
         Me.DicomEditableObject = New Leadtools.Dicom.Common.Editing.DicomEditableObject()
         Me.anonymizeopenFileDialog = New System.Windows.Forms.OpenFileDialog()
         Me.toolStripContainer1.BottomToolStripPanel.SuspendLayout()
         Me.toolStripContainer1.ContentPanel.SuspendLayout()
         Me.toolStripContainer1.TopToolStripPanel.SuspendLayout()
         Me.toolStripContainer1.SuspendLayout()
         Me.statusStrip1.SuspendLayout()
         Me.splitContainerMain.Panel1.SuspendLayout()
         Me.splitContainerMain.Panel2.SuspendLayout()
         Me.splitContainerMain.SuspendLayout()
         CType(Me.treeGridViewTags, System.ComponentModel.ISupportInitialize).BeginInit()
         CType(Me.treeGridViewDifference, System.ComponentModel.ISupportInitialize).BeginInit()
         Me.toolStrip2.SuspendLayout()
         Me.menuStrip1.SuspendLayout()
         Me.toolStrip1.SuspendLayout()
         Me.SuspendLayout()
         ' 
         ' openFileDialog
         ' 
         Me.openFileDialog.Filter = "DICOM Files|*.dcm;*.dic; *.pre|All files|*.* "
         ' 
         ' toolStripContainer1
         ' 
         ' 
         ' toolStripContainer1.BottomToolStripPanel
         ' 
         Me.toolStripContainer1.BottomToolStripPanel.Controls.Add(Me.statusStrip1)
         ' 
         ' toolStripContainer1.ContentPanel
         ' 
         Me.toolStripContainer1.ContentPanel.Controls.Add(Me.splitContainerMain)
         Me.toolStripContainer1.ContentPanel.Size = New System.Drawing.Size(1079, 594)
         Me.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill
         Me.toolStripContainer1.Location = New System.Drawing.Point(0, 0)
         Me.toolStripContainer1.Name = "toolStripContainer1"
         Me.toolStripContainer1.Size = New System.Drawing.Size(1079, 665)
         Me.toolStripContainer1.TabIndex = 2
         Me.toolStripContainer1.Text = "toolStripContainer1"
         ' 
         ' toolStripContainer1.TopToolStripPanel
         ' 
         Me.toolStripContainer1.TopToolStripPanel.Controls.Add(Me.menuStrip1)
         Me.toolStripContainer1.TopToolStripPanel.Controls.Add(Me.toolStrip1)
         ' 
         ' statusStrip1
         ' 
         Me.statusStrip1.Dock = System.Windows.Forms.DockStyle.None
         Me.statusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolStripStatusLabel, Me.toolStripProgressBar})
         Me.statusStrip1.Location = New System.Drawing.Point(0, 0)
         Me.statusStrip1.Name = "statusStrip1"
         Me.statusStrip1.Size = New System.Drawing.Size(1079, 22)
         Me.statusStrip1.TabIndex = 0
         ' 
         ' toolStripStatusLabel
         ' 
         Me.toolStripStatusLabel.Name = "toolStripStatusLabel"
         Me.toolStripStatusLabel.Size = New System.Drawing.Size(87, 17)
         Me.toolStripStatusLabel.Text = "Anonymizing..."
         Me.toolStripStatusLabel.Visible = False
         ' 
         ' toolStripProgressBar
         ' 
         Me.toolStripProgressBar.Name = "toolStripProgressBar"
         Me.toolStripProgressBar.Size = New System.Drawing.Size(100, 16)
         Me.toolStripProgressBar.ToolTipText = "Anonymizing Dataset"
         Me.toolStripProgressBar.Visible = False
         ' 
         ' splitContainerMain
         ' 
         Me.splitContainerMain.Dock = System.Windows.Forms.DockStyle.Fill
         Me.splitContainerMain.Location = New System.Drawing.Point(0, 0)
         Me.splitContainerMain.Name = "splitContainerMain"
         Me.splitContainerMain.Orientation = System.Windows.Forms.Orientation.Horizontal
         ' 
         ' splitContainerMain.Panel1
         ' 
         Me.splitContainerMain.Panel1.Controls.Add(Me.treeGridViewTags)
         Me.splitContainerMain.Panel1.Controls.Add(Me.label3)
         ' 
         ' splitContainerMain.Panel2
         ' 
         Me.splitContainerMain.Panel2.Controls.Add(Me.treeGridViewDifference)
         Me.splitContainerMain.Panel2.Controls.Add(Me.toolStrip2)
         Me.splitContainerMain.Size = New System.Drawing.Size(1079, 594)
         Me.splitContainerMain.SplitterDistance = 296
         Me.splitContainerMain.TabIndex = 1
         ' 
         ' treeGridViewTags
         ' 
         Me.treeGridViewTags.AllowDrop = True
         Me.treeGridViewTags.AllowUserToAddRows = False
         Me.treeGridViewTags.AllowUserToDeleteRows = False
         Me.treeGridViewTags.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.columnTag, Me.columnName, Me.columnValue})
         Me.treeGridViewTags.DividerColor = System.Drawing.Color.Red
         Me.treeGridViewTags.Dock = System.Windows.Forms.DockStyle.Fill
         Me.treeGridViewTags.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
         Me.treeGridViewTags.ImageList = Nothing
         Me.treeGridViewTags.Location = New System.Drawing.Point(0, 13)
         Me.treeGridViewTags.Name = "treeGridViewTags"
         Me.treeGridViewTags.SelectionColor = System.Drawing.Color.Blue
         Me.treeGridViewTags.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
         Me.treeGridViewTags.Size = New System.Drawing.Size(1079, 283)
         Me.treeGridViewTags.TabIndex = 0
         ' 
         ' columnTag
         ' 
         Me.columnTag.DefaultNodeImage = Nothing
         Me.columnTag.HeaderText = "Tag"
         Me.columnTag.Name = "columnTag"
         Me.columnTag.Resizable = System.Windows.Forms.DataGridViewTriState.True
         Me.columnTag.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
         Me.columnTag.Width = 32
         ' 
         ' columnName
         ' 
         Me.columnName.HeaderText = "Name"
         Me.columnName.Name = "columnName"
         Me.columnName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
         Me.columnName.Width = 66
         ' 
         ' columnValue
         ' 
         Me.columnValue.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
         Me.columnValue.HeaderText = "Value"
         Me.columnValue.Name = "columnValue"
         Me.columnValue.Resizable = System.Windows.Forms.DataGridViewTriState.True
         ' 
         ' label3
         ' 
         Me.label3.AutoSize = True
         Me.label3.Dock = System.Windows.Forms.DockStyle.Top
         Me.label3.Location = New System.Drawing.Point(0, 0)
         Me.label3.Name = "label3"
         Me.label3.Size = New System.Drawing.Size(108, 13)
         Me.label3.TabIndex = 1
         Me.label3.Text = "Anonymization Script:"
         ' 
         ' treeGridViewDifference
         ' 
         Me.treeGridViewDifference.AllowDrop = True
         Me.treeGridViewDifference.AllowUserToAddRows = False
         Me.treeGridViewDifference.AllowUserToDeleteRows = False
         Me.treeGridViewDifference.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
         Me.treeGridViewDifference.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.tagColumn, Me.nameColumn, Me.vrColumn, Me.data1Value, Me.data2Column, Me.diffColumn})
         Me.treeGridViewDifference.DividerColor = System.Drawing.Color.Red
         Me.treeGridViewDifference.Dock = System.Windows.Forms.DockStyle.Fill
         Me.treeGridViewDifference.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
         Me.treeGridViewDifference.ImageList = Nothing
         Me.treeGridViewDifference.Location = New System.Drawing.Point(0, 25)
         Me.treeGridViewDifference.MultiSelect = False
         Me.treeGridViewDifference.Name = "treeGridViewDifference"
         Me.treeGridViewDifference.ReadOnly = True
         Me.treeGridViewDifference.RowHeadersVisible = False
         Me.treeGridViewDifference.SelectionColor = System.Drawing.Color.Blue
         Me.treeGridViewDifference.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
         Me.treeGridViewDifference.Size = New System.Drawing.Size(1079, 269)
         Me.treeGridViewDifference.TabIndex = 1
         ' 
         ' tagColumn
         ' 
         Me.tagColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
         Me.tagColumn.DefaultNodeImage = Nothing
         Me.tagColumn.FillWeight = 10.0F
         Me.tagColumn.HeaderText = "Tag"
         Me.tagColumn.Name = "tagColumn"
         Me.tagColumn.ReadOnly = True
         Me.tagColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
         ' 
         ' nameColumn
         ' 
         Me.nameColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
         Me.nameColumn.FillWeight = 10.0F
         Me.nameColumn.HeaderText = "Name"
         Me.nameColumn.Name = "nameColumn"
         Me.nameColumn.ReadOnly = True
         Me.nameColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
         ' 
         ' vrColumn
         ' 
         Me.vrColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
         Me.vrColumn.FillWeight = 5.0F
         Me.vrColumn.HeaderText = "VR"
         Me.vrColumn.Name = "vrColumn"
         Me.vrColumn.ReadOnly = True
         Me.vrColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
         ' 
         ' data1Value
         ' 
         Me.data1Value.FillWeight = 25.0F
         Me.data1Value.HeaderText = "Original Value"
         Me.data1Value.Name = "data1Value"
         Me.data1Value.ReadOnly = True
         Me.data1Value.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
         ' 
         ' data2Column
         ' 
         Me.data2Column.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
         Me.data2Column.FillWeight = 25.0F
         Me.data2Column.HeaderText = "Anonymized Value"
         Me.data2Column.Name = "data2Column"
         Me.data2Column.ReadOnly = True
         Me.data2Column.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
         ' 
         ' diffColumn
         ' 
         Me.diffColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
         Me.diffColumn.FillWeight = 10.0F
         Me.diffColumn.HeaderText = "Difference"
         Me.diffColumn.Name = "diffColumn"
         Me.diffColumn.ReadOnly = True
         Me.diffColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True
         Me.diffColumn.Text = "Diff"
         ' 
         ' toolStrip2
         ' 
         Me.toolStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolStripButtonAnonymize, Me.toolStripButtonRefresh, Me.toolStripButtonRedact, Me.toolStripSeparator2, Me.toolStripButtonSaveDataset, Me.toolStripButtonView})
         Me.toolStrip2.Location = New System.Drawing.Point(0, 0)
         Me.toolStrip2.Name = "toolStrip2"
         Me.toolStrip2.Size = New System.Drawing.Size(1079, 25)
         Me.toolStrip2.TabIndex = 3
         Me.toolStrip2.Text = "toolStrip2"
         ' 
         ' toolStripButtonAnonymize
         ' 
         Me.toolStripButtonAnonymize.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
         Me.toolStripButtonAnonymize.Image = Global.Resources.Anonymou
         Me.toolStripButtonAnonymize.ImageTransparentColor = System.Drawing.Color.Magenta
         Me.toolStripButtonAnonymize.Name = "toolStripButtonAnonymize"
         Me.toolStripButtonAnonymize.Size = New System.Drawing.Size(23, 22)
         Me.toolStripButtonAnonymize.Text = "toolStripButtonAnonymize"
         Me.toolStripButtonAnonymize.ToolTipText = "Anonymize Dicom File"
         ' 
         ' toolStripButtonRefresh
         ' 
         Me.toolStripButtonRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
         Me.toolStripButtonRefresh.Image = Global.Resources.AnonymousRefresh_16x16
         Me.toolStripButtonRefresh.ImageTransparentColor = System.Drawing.Color.Magenta
         Me.toolStripButtonRefresh.Name = "toolStripButtonRefresh"
         Me.toolStripButtonRefresh.Size = New System.Drawing.Size(23, 22)
         Me.toolStripButtonRefresh.Text = "toolStripButtonRefresh"
         Me.toolStripButtonRefresh.ToolTipText = "Refresh Anonymization"
         ' 
         ' toolStripButtonRedact
         ' 
         Me.toolStripButtonRedact.CheckOnClick = True
         Me.toolStripButtonRedact.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
         Me.toolStripButtonRedact.Image = Global.Resources.Redact_16x16
         Me.toolStripButtonRedact.ImageTransparentColor = System.Drawing.Color.Magenta
         Me.toolStripButtonRedact.Name = "toolStripButtonRedact"
         Me.toolStripButtonRedact.Size = New System.Drawing.Size(23, 22)
         Me.toolStripButtonRedact.Text = "toolStripButton1"
         Me.toolStripButtonRedact.ToolTipText = "Enable redact rectangle selection"
         ' 
         ' toolStripSeparator2
         ' 
         Me.toolStripSeparator2.Name = "toolStripSeparator2"
         Me.toolStripSeparator2.Size = New System.Drawing.Size(6, 25)
         ' 
         ' toolStripButtonSaveDataset
         ' 
         Me.toolStripButtonSaveDataset.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
         Me.toolStripButtonSaveDataset.Image = Global.Resources.SaveDataset_16x16
         Me.toolStripButtonSaveDataset.ImageTransparentColor = System.Drawing.Color.Magenta
         Me.toolStripButtonSaveDataset.Name = "toolStripButtonSaveDataset"
         Me.toolStripButtonSaveDataset.Size = New System.Drawing.Size(23, 22)
         Me.toolStripButtonSaveDataset.Text = "Save Anonymized Dataset"
         ' 
         ' toolStripButtonView
         ' 
         Me.toolStripButtonView.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
         Me.toolStripButtonView.Image = Global.Resources.ViewImage_16x16
         Me.toolStripButtonView.ImageTransparentColor = System.Drawing.Color.Magenta
         Me.toolStripButtonView.Name = "toolStripButtonView"
         Me.toolStripButtonView.Size = New System.Drawing.Size(23, 22)
         Me.toolStripButtonView.Text = "View Anonymized Image"
         ' 
         ' menuStrip1
         ' 
         Me.menuStrip1.Dock = System.Windows.Forms.DockStyle.None
         Me.menuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.fileToolStripMenuItem, Me.tagToolStripMenuItem, Me.helpToolStripMenuItem})
         Me.menuStrip1.Location = New System.Drawing.Point(0, 0)
         Me.menuStrip1.Name = "menuStrip1"
         Me.menuStrip1.Size = New System.Drawing.Size(1079, 24)
         Me.menuStrip1.TabIndex = 1
         Me.menuStrip1.Text = "menuStrip1"
         ' 
         ' fileToolStripMenuItem
         ' 
         Me.fileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.newToolStripMenuItem, Me.openToolStripMenuItem, Me.defaultToolStripMenuItem, Me.toolStripSeparator, Me.saveToolStripMenuItem, Me.saveAsToolStripMenuItem, Me.toolStripSeparator1, Me.exitToolStripMenuItem})
         Me.fileToolStripMenuItem.Name = "fileToolStripMenuItem"
         Me.fileToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
         Me.fileToolStripMenuItem.Text = "&File"
         ' 
         ' newToolStripMenuItem
         ' 
         Me.newToolStripMenuItem.Image = Global.Resources.NewScript_16x16
         Me.newToolStripMenuItem.Name = "newToolStripMenuItem"
         Me.newToolStripMenuItem.ShortcutKeys = (CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.N), System.Windows.Forms.Keys))
         Me.newToolStripMenuItem.Size = New System.Drawing.Size(219, 22)
         Me.newToolStripMenuItem.Text = "&New Script..."
         Me.newToolStripMenuItem.ToolTipText = "New script"
         ' 
         ' openToolStripMenuItem
         ' 
         Me.openToolStripMenuItem.Image = Global.Resources.OpenScript_16x16
         Me.openToolStripMenuItem.Name = "openToolStripMenuItem"
         Me.openToolStripMenuItem.ShortcutKeys = (CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.O), System.Windows.Forms.Keys))
         Me.openToolStripMenuItem.Size = New System.Drawing.Size(219, 22)
         Me.openToolStripMenuItem.Text = "&Open Script..."
         Me.openToolStripMenuItem.ToolTipText = "Open existing script"
         ' 
         ' defaultToolStripMenuItem
         ' 
         Me.defaultToolStripMenuItem.Name = "defaultToolStripMenuItem"
         Me.defaultToolStripMenuItem.ShortcutKeys = (CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.D), System.Windows.Forms.Keys))
         Me.defaultToolStripMenuItem.Size = New System.Drawing.Size(219, 22)
         Me.defaultToolStripMenuItem.Text = "Open &Default Script"
         Me.defaultToolStripMenuItem.ToolTipText = "Open Default Script"
         ' 
         ' toolStripSeparator
         ' 
         Me.toolStripSeparator.Name = "toolStripSeparator"
         Me.toolStripSeparator.Size = New System.Drawing.Size(216, 6)
         ' 
         ' saveToolStripMenuItem
         ' 
         Me.saveToolStripMenuItem.Image = (CType(resources.GetObject("saveToolStripMenuItem.Image"), System.Drawing.Image))
         Me.saveToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta
         Me.saveToolStripMenuItem.Name = "saveToolStripMenuItem"
         Me.saveToolStripMenuItem.ShortcutKeys = (CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.S), System.Windows.Forms.Keys))
         Me.saveToolStripMenuItem.Size = New System.Drawing.Size(219, 22)
         Me.saveToolStripMenuItem.Text = "&Save Script"
         Me.saveToolStripMenuItem.ToolTipText = "Save script"
         ' 
         ' saveAsToolStripMenuItem
         ' 
         Me.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem"
         Me.saveAsToolStripMenuItem.Size = New System.Drawing.Size(219, 22)
         Me.saveAsToolStripMenuItem.Text = "Save Script &As..."
         Me.saveAsToolStripMenuItem.ToolTipText = "Save script as new file"
         ' 
         ' toolStripSeparator1
         ' 
         Me.toolStripSeparator1.Name = "toolStripSeparator1"
         Me.toolStripSeparator1.Size = New System.Drawing.Size(216, 6)
         ' 
         ' exitToolStripMenuItem
         ' 
         Me.exitToolStripMenuItem.Name = "exitToolStripMenuItem"
         Me.exitToolStripMenuItem.Size = New System.Drawing.Size(219, 22)
         Me.exitToolStripMenuItem.Text = "E&xit"
         ' 
         ' tagToolStripMenuItem
         ' 
         Me.tagToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.insertToolStripMenuItem, Me.deleteToolStripMenuItem})
         Me.tagToolStripMenuItem.Name = "tagToolStripMenuItem"
         Me.tagToolStripMenuItem.Size = New System.Drawing.Size(39, 20)
         Me.tagToolStripMenuItem.Text = "&Tag"
         ' 
         ' insertToolStripMenuItem
         ' 
         Me.insertToolStripMenuItem.Name = "insertToolStripMenuItem"
         Me.insertToolStripMenuItem.ShortcutKeys = (CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.I), System.Windows.Forms.Keys))
         Me.insertToolStripMenuItem.Size = New System.Drawing.Size(149, 22)
         Me.insertToolStripMenuItem.Text = "&Insert..."
         ' 
         ' deleteToolStripMenuItem
         ' 
         Me.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem"
         Me.deleteToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Delete
         Me.deleteToolStripMenuItem.Size = New System.Drawing.Size(149, 22)
         Me.deleteToolStripMenuItem.Text = "&Delete"
         ' 
         ' helpToolStripMenuItem
         ' 
         Me.helpToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.aboutToolStripMenuItem})
         Me.helpToolStripMenuItem.Name = "helpToolStripMenuItem"
         Me.helpToolStripMenuItem.Size = New System.Drawing.Size(44, 20)
         Me.helpToolStripMenuItem.Text = "&Help"
         ' 
         ' aboutToolStripMenuItem
         ' 
         Me.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem"
         Me.aboutToolStripMenuItem.Size = New System.Drawing.Size(107, 22)
         Me.aboutToolStripMenuItem.Text = "&About"
         ' 
         ' toolStrip1
         ' 
         Me.toolStrip1.AutoSize = False
         Me.toolStrip1.Dock = System.Windows.Forms.DockStyle.None
         Me.toolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolStripButtonNew, Me.toolStripButtonOpen, Me.toolStripSeparator5, Me.toolStripButtonSave, Me.toolStripSeparator3, Me.toolStripButtonInsertTag, Me.toolStripButtonDeleteTag})
         Me.toolStrip1.Location = New System.Drawing.Point(0, 24)
         Me.toolStrip1.Name = "toolStrip1"
         Me.toolStrip1.Size = New System.Drawing.Size(1079, 25)
         Me.toolStrip1.Stretch = True
         Me.toolStrip1.TabIndex = 2
         ' 
         ' toolStripButtonNew
         ' 
         Me.toolStripButtonNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
         Me.toolStripButtonNew.Image = Global.Resources.NewScript_16x16
         Me.toolStripButtonNew.ImageTransparentColor = System.Drawing.Color.Magenta
         Me.toolStripButtonNew.Name = "toolStripButtonNew"
         Me.toolStripButtonNew.Size = New System.Drawing.Size(23, 22)
         Me.toolStripButtonNew.Text = "New Anonymization Script"
         ' 
         ' toolStripButtonOpen
         ' 
         Me.toolStripButtonOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
         Me.toolStripButtonOpen.Image = Global.Resources.OpenScript_16x16
         Me.toolStripButtonOpen.ImageTransparentColor = System.Drawing.Color.Magenta
         Me.toolStripButtonOpen.Name = "toolStripButtonOpen"
         Me.toolStripButtonOpen.Size = New System.Drawing.Size(23, 22)
         Me.toolStripButtonOpen.Text = "Open Anonymization Script"
         ' 
         ' toolStripSeparator5
         ' 
         Me.toolStripSeparator5.Name = "toolStripSeparator5"
         Me.toolStripSeparator5.Size = New System.Drawing.Size(6, 25)
         ' 
         ' toolStripButtonSave
         ' 
         Me.toolStripButtonSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
         Me.toolStripButtonSave.Image = Global.Resources.SaveDataset_16x16
         Me.toolStripButtonSave.ImageTransparentColor = System.Drawing.Color.Magenta
         Me.toolStripButtonSave.Name = "toolStripButtonSave"
         Me.toolStripButtonSave.Size = New System.Drawing.Size(23, 22)
         Me.toolStripButtonSave.Text = "Save Anonymization Script"
         ' 
         ' toolStripSeparator3
         ' 
         Me.toolStripSeparator3.Name = "toolStripSeparator3"
         Me.toolStripSeparator3.Size = New System.Drawing.Size(6, 25)
         ' 
         ' toolStripButtonInsertTag
         ' 
         Me.toolStripButtonInsertTag.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
         Me.toolStripButtonInsertTag.Image = Global.Resources.InsertTag_24x24
         Me.toolStripButtonInsertTag.ImageTransparentColor = System.Drawing.Color.Magenta
         Me.toolStripButtonInsertTag.Name = "toolStripButtonInsertTag"
         Me.toolStripButtonInsertTag.Size = New System.Drawing.Size(23, 22)
         Me.toolStripButtonInsertTag.Text = "toolStripButton1"
         Me.toolStripButtonInsertTag.ToolTipText = "Insert Tag"
         ' 
         ' toolStripButtonDeleteTag
         ' 
         Me.toolStripButtonDeleteTag.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
         Me.toolStripButtonDeleteTag.Image = Global.Resources.DeleteTag_24x24
         Me.toolStripButtonDeleteTag.ImageTransparentColor = System.Drawing.Color.Magenta
         Me.toolStripButtonDeleteTag.Name = "toolStripButtonDeleteTag"
         Me.toolStripButtonDeleteTag.Size = New System.Drawing.Size(23, 22)
         Me.toolStripButtonDeleteTag.Text = "toolStripButton2"
         Me.toolStripButtonDeleteTag.ToolTipText = "Delete Tag"
         ' 
         ' anonymizeopenFileDialog
         ' 
         Me.anonymizeopenFileDialog.AddExtension = False
         Me.anonymizeopenFileDialog.Filter = "DICOM Files|*.dcm;*.dic;*.pre|All files|*.* "
         Me.anonymizeopenFileDialog.FilterIndex = 0
         Me.anonymizeopenFileDialog.Multiselect = True
         Me.anonymizeopenFileDialog.Title = "Anonymize File"
         ' 
         ' MainForm
         ' 
         Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
         Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
         Me.ClientSize = New System.Drawing.Size(1079, 665)
         Me.Controls.Add(Me.toolStripContainer1)
         Me.Icon = (CType(resources.GetObject("$this.Icon"), System.Drawing.Icon))
         Me.Name = "MainForm"
         Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
         Me.Text = "DICOM Anonymization Demor"
         Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
         Me.toolStripContainer1.BottomToolStripPanel.ResumeLayout(False)
         Me.toolStripContainer1.BottomToolStripPanel.PerformLayout()
         Me.toolStripContainer1.ContentPanel.ResumeLayout(False)
         Me.toolStripContainer1.TopToolStripPanel.ResumeLayout(False)
         Me.toolStripContainer1.TopToolStripPanel.PerformLayout()
         Me.toolStripContainer1.ResumeLayout(False)
         Me.toolStripContainer1.PerformLayout()
         Me.statusStrip1.ResumeLayout(False)
         Me.statusStrip1.PerformLayout()
         Me.splitContainerMain.Panel1.ResumeLayout(False)
         Me.splitContainerMain.Panel1.PerformLayout()
         Me.splitContainerMain.Panel2.ResumeLayout(False)
         Me.splitContainerMain.Panel2.PerformLayout()
         Me.splitContainerMain.ResumeLayout(False)
         CType(Me.treeGridViewTags, System.ComponentModel.ISupportInitialize).EndInit()
         CType(Me.treeGridViewDifference, System.ComponentModel.ISupportInitialize).EndInit()
         Me.toolStrip2.ResumeLayout(False)
         Me.toolStrip2.PerformLayout()
         Me.menuStrip1.ResumeLayout(False)
         Me.menuStrip1.PerformLayout()
         Me.toolStrip1.ResumeLayout(False)
         Me.toolStrip1.PerformLayout()
         Me.ResumeLayout(False)
      End Sub
#End Region

      Private openFileDialog As System.Windows.Forms.OpenFileDialog
      Private toolStripContainer1 As System.Windows.Forms.ToolStripContainer
      Private DicomEditableObject As Leadtools.Dicom.Common.Editing.DicomEditableObject
      Private statusStrip1 As System.Windows.Forms.StatusStrip
      Private WithEvents treeGridViewTags As TreeGridView
      Private menuStrip1 As System.Windows.Forms.MenuStrip
      Private WithEvents fileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents newToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private toolStripSeparator As System.Windows.Forms.ToolStripSeparator
      Private WithEvents saveToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents saveAsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private toolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
      Private WithEvents exitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private anonymizeopenFileDialog As System.Windows.Forms.OpenFileDialog
      Private splitContainerMain As System.Windows.Forms.SplitContainer
      Private label3 As System.Windows.Forms.Label
      Private WithEvents openToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents tagToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents insertToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents deleteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private treeGridViewDifference As TreeGridView
      Private tagColumn As TreeGridColumn
      Private nameColumn As System.Windows.Forms.DataGridViewTextBoxColumn
      Private vrColumn As System.Windows.Forms.DataGridViewTextBoxColumn
      Private data1Value As System.Windows.Forms.DataGridViewTextBoxColumn
      Private data2Column As System.Windows.Forms.DataGridViewTextBoxColumn
      Private diffColumn As DataGridViewDisableButtonColumn
      Private toolStrip1 As System.Windows.Forms.ToolStrip
      Private helpToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents aboutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private toolStrip2 As System.Windows.Forms.ToolStrip
      Private WithEvents toolStripButtonSaveDataset As System.Windows.Forms.ToolStripButton
      Private WithEvents toolStripButtonView As System.Windows.Forms.ToolStripButton
      Private WithEvents toolStripButtonNew As System.Windows.Forms.ToolStripButton
      Private WithEvents toolStripButtonOpen As System.Windows.Forms.ToolStripButton
      Private WithEvents toolStripButtonSave As System.Windows.Forms.ToolStripButton
      Private toolStripStatusLabel As System.Windows.Forms.ToolStripStatusLabel
      Private toolStripProgressBar As System.Windows.Forms.ToolStripProgressBar
      Private columnTag As TreeGridColumn
      Private columnName As System.Windows.Forms.DataGridViewTextBoxColumn
      Private columnValue As System.Windows.Forms.DataGridViewComboBoxColumn
      Private WithEvents defaultToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private toolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
      Private WithEvents toolStripButtonInsertTag As System.Windows.Forms.ToolStripButton
      Private WithEvents toolStripButtonDeleteTag As System.Windows.Forms.ToolStripButton
      Private WithEvents toolStripButtonAnonymize As System.Windows.Forms.ToolStripButton
      Private WithEvents toolStripButtonRefresh As System.Windows.Forms.ToolStripButton
      Private toolStripButtonRedact As System.Windows.Forms.ToolStripButton
      Private toolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
      Private toolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
   End Class
End Namespace


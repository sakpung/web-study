Imports Microsoft.VisualBasic
Imports System
Namespace DicomDemo
   Partial Public Class MainForm
        ''' <summary>
        ''' Required designer variable.
        ''' </summary>
        Private components As System.ComponentModel.IContainer = Nothing

        ''' <summary>
        ''' Clean up any resources being used.
        ''' </summary>
      ''' <param name="disposing">true if managed resources should be disposed otherwise, false.</param>
        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
         If disposing AndAlso (Not components Is Nothing) Then
                components.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

#Region "Windows Form Designer generated code"

      ''' <summary>
      ''' Required method for Designer support - do not modify
      ''' the contents of Me method with the code editor.
      ''' </summary>
      Private Sub InitializeComponent()
         Me.components = New System.ComponentModel.Container()
         Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainForm))
         Me.fileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me.optionsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me.searchToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me.toolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
         Me.clearLogToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me.toolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
         Me.exitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me.helpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me.showHelpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me.aboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuStrip = New System.Windows.Forms.MenuStrip()
         Me._splitContainer1 = New System.Windows.Forms.SplitContainer()
         Me._splitContainer2 = New System.Windows.Forms.SplitContainer()
         Me._propertyGrid = New System.Windows.Forms.PropertyGrid()
         Me._label1 = New System.Windows.Forms.Label()
         Me._groupBoxServer = New System.Windows.Forms.GroupBox()
         Me._labelServerPort = New System.Windows.Forms.Label()
         Me._labelServerIp = New System.Windows.Forms.Label()
         Me._labelServerAeTitle = New System.Windows.Forms.Label()
         Me._textBoxServerPort = New System.Windows.Forms.TextBox()
         Me._textBoxServerIp = New System.Windows.Forms.TextBox()
         Me._comboBoxService = New System.Windows.Forms.ComboBox()
         Me._buttonCancel = New System.Windows.Forms.Button()
         Me._buttonSearch = New System.Windows.Forms.Button()
         Me._buttonOptions = New System.Windows.Forms.Button()
         Me._splitContainer3 = New System.Windows.Forms.SplitContainer()
         Me._listViewStudies = New System.Windows.Forms.ListView()
         Me._columnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
         Me._columnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
         Me._columnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
         Me._columnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
         Me._columnHeaderStudyTime = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
         Me._columnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
         Me._columnHeader6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
         Me._label2 = New System.Windows.Forms.Label()
         Me._splitContainer4 = New System.Windows.Forms.SplitContainer()
         Me.buttonCGetStorageClasses = New System.Windows.Forms.Button()
         Me._listViewSeries = New System.Windows.Forms.ListView()
         Me._columnHeader7 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
         Me._columnHeader8 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
         Me._columnHeader9 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
         Me._columnHeader10 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
         Me._columnHeader11 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
         Me._radioButtonCGet = New System.Windows.Forms.RadioButton()
         Me._radioButtonCMove = New System.Windows.Forms.RadioButton()
         Me._label3 = New System.Windows.Forms.Label()
         Me._splitContainer5 = New System.Windows.Forms.SplitContainer()
         Me._toolStripCancel = New System.Windows.Forms.ToolStrip()
         Me._toolStripButtonCancel = New System.Windows.Forms.ToolStripButton()
         Me._label4 = New System.Windows.Forms.Label()
         Me._labelStatus = New System.Windows.Forms.Label()
         Me._richTextBoxLog = New System.Windows.Forms.RichTextBox()
         Me._contextMenuStripLog = New System.Windows.Forms.ContextMenuStrip(Me.components)
         Me._toolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
         Me._label5 = New System.Windows.Forms.Label()
         Me._menuStrip.SuspendLayout()
         CType(Me._splitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
         Me._splitContainer1.Panel1.SuspendLayout()
         Me._splitContainer1.Panel2.SuspendLayout()
         Me._splitContainer1.SuspendLayout()
         CType(Me._splitContainer2, System.ComponentModel.ISupportInitialize).BeginInit()
         Me._splitContainer2.Panel1.SuspendLayout()
         Me._splitContainer2.Panel2.SuspendLayout()
         Me._splitContainer2.SuspendLayout()
         Me._groupBoxServer.SuspendLayout()
         CType(Me._splitContainer3, System.ComponentModel.ISupportInitialize).BeginInit()
         Me._splitContainer3.Panel1.SuspendLayout()
         Me._splitContainer3.Panel2.SuspendLayout()
         Me._splitContainer3.SuspendLayout()
         CType(Me._splitContainer4, System.ComponentModel.ISupportInitialize).BeginInit()
         Me._splitContainer4.Panel1.SuspendLayout()
         Me._splitContainer4.Panel2.SuspendLayout()
         Me._splitContainer4.SuspendLayout()
         CType(Me._splitContainer5, System.ComponentModel.ISupportInitialize).BeginInit()
         Me._splitContainer5.Panel1.SuspendLayout()
         Me._splitContainer5.Panel2.SuspendLayout()
         Me._splitContainer5.SuspendLayout()
         Me._toolStripCancel.SuspendLayout()
         Me._contextMenuStripLog.SuspendLayout()
         Me.SuspendLayout()
         '
         'fileToolStripMenuItem
         '
         Me.fileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.optionsToolStripMenuItem, Me.searchToolStripMenuItem, Me.toolStripSeparator1, Me.clearLogToolStripMenuItem, Me.toolStripSeparator2, Me.exitToolStripMenuItem})
         Me.fileToolStripMenuItem.Name = "fileToolStripMenuItem"
         Me.fileToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
         Me.fileToolStripMenuItem.Text = "&File"
         '
         'optionsToolStripMenuItem
         '
         Me.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem"
         Me.optionsToolStripMenuItem.Size = New System.Drawing.Size(125, 22)
         Me.optionsToolStripMenuItem.Text = "&Options..."
         '
         'searchToolStripMenuItem
         '
         Me.searchToolStripMenuItem.Name = "searchToolStripMenuItem"
         Me.searchToolStripMenuItem.Size = New System.Drawing.Size(125, 22)
         Me.searchToolStripMenuItem.Text = "&Search"
         '
         'toolStripSeparator1
         '
         Me.toolStripSeparator1.Name = "toolStripSeparator1"
         Me.toolStripSeparator1.Size = New System.Drawing.Size(122, 6)
         '
         'clearLogToolStripMenuItem
         '
         Me.clearLogToolStripMenuItem.Name = "clearLogToolStripMenuItem"
         Me.clearLogToolStripMenuItem.Size = New System.Drawing.Size(125, 22)
         Me.clearLogToolStripMenuItem.Text = "&Clear Log"
         '
         'toolStripSeparator2
         '
         Me.toolStripSeparator2.Name = "toolStripSeparator2"
         Me.toolStripSeparator2.Size = New System.Drawing.Size(122, 6)
         '
         'exitToolStripMenuItem
         '
         Me.exitToolStripMenuItem.Name = "exitToolStripMenuItem"
         Me.exitToolStripMenuItem.Size = New System.Drawing.Size(125, 22)
         Me.exitToolStripMenuItem.Text = "&Exit"
         '
         'helpToolStripMenuItem
         '
         Me.helpToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.showHelpToolStripMenuItem, Me.aboutToolStripMenuItem})
         Me.helpToolStripMenuItem.Name = "helpToolStripMenuItem"
         Me.helpToolStripMenuItem.Size = New System.Drawing.Size(44, 20)
         Me.helpToolStripMenuItem.Text = "&Help"
         '
         'showHelpToolStripMenuItem
         '
         Me.showHelpToolStripMenuItem.Name = "showHelpToolStripMenuItem"
         Me.showHelpToolStripMenuItem.Size = New System.Drawing.Size(140, 22)
         Me.showHelpToolStripMenuItem.Text = "Show &Help..."
         '
         'aboutToolStripMenuItem
         '
         Me.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem"
         Me.aboutToolStripMenuItem.Size = New System.Drawing.Size(140, 22)
         Me.aboutToolStripMenuItem.Text = "&About..."
         '
         '_menuStrip
         '
         Me._menuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.fileToolStripMenuItem, Me.helpToolStripMenuItem})
         Me._menuStrip.Location = New System.Drawing.Point(0, 0)
         Me._menuStrip.Name = "_menuStrip"
         Me._menuStrip.Size = New System.Drawing.Size(888, 24)
         Me._menuStrip.TabIndex = 0
         Me._menuStrip.Text = "menuStrip1"
         '
         '_splitContainer1
         '
         Me._splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
         Me._splitContainer1.Location = New System.Drawing.Point(0, 24)
         Me._splitContainer1.Name = "_splitContainer1"
         '
         '_splitContainer1.Panel1
         '
         Me._splitContainer1.Panel1.Controls.Add(Me._splitContainer2)
         '
         '_splitContainer1.Panel2
         '
         Me._splitContainer1.Panel2.Controls.Add(Me._splitContainer3)
         Me._splitContainer1.Size = New System.Drawing.Size(888, 710)
         Me._splitContainer1.SplitterDistance = 248
         Me._splitContainer1.TabIndex = 1
         '
         '_splitContainer2
         '
         Me._splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill
         Me._splitContainer2.Location = New System.Drawing.Point(0, 0)
         Me._splitContainer2.Name = "_splitContainer2"
         Me._splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal
         '
         '_splitContainer2.Panel1
         '
         Me._splitContainer2.Panel1.Controls.Add(Me._propertyGrid)
         Me._splitContainer2.Panel1.Controls.Add(Me._label1)
         '
         '_splitContainer2.Panel2
         '
         Me._splitContainer2.Panel2.Controls.Add(Me._groupBoxServer)
         Me._splitContainer2.Panel2.Controls.Add(Me._buttonCancel)
         Me._splitContainer2.Panel2.Controls.Add(Me._buttonSearch)
         Me._splitContainer2.Panel2.Controls.Add(Me._buttonOptions)
         Me._splitContainer2.Size = New System.Drawing.Size(248, 710)
         Me._splitContainer2.SplitterDistance = 571
         Me._splitContainer2.TabIndex = 0
         '
         '_propertyGrid
         '
         Me._propertyGrid.Cursor = System.Windows.Forms.Cursors.HSplit
         Me._propertyGrid.Dock = System.Windows.Forms.DockStyle.Fill
         Me._propertyGrid.HelpVisible = False
         Me._propertyGrid.Location = New System.Drawing.Point(0, 23)
         Me._propertyGrid.Name = "_propertyGrid"
         Me._propertyGrid.PropertySort = System.Windows.Forms.PropertySort.Categorized
         Me._propertyGrid.Size = New System.Drawing.Size(248, 548)
         Me._propertyGrid.TabIndex = 1
         '
         '_label1
         '
         Me._label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
         Me._label1.Dock = System.Windows.Forms.DockStyle.Top
         Me._label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
         Me._label1.Location = New System.Drawing.Point(0, 0)
         Me._label1.Name = "_label1"
         Me._label1.Size = New System.Drawing.Size(248, 23)
         Me._label1.TabIndex = 0
         Me._label1.Text = "Search Params:"
         '
         '_groupBoxServer
         '
         Me._groupBoxServer.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
               Or System.Windows.Forms.AnchorStyles.Left) _
               Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
         Me._groupBoxServer.Controls.Add(Me._labelServerPort)
         Me._groupBoxServer.Controls.Add(Me._labelServerIp)
         Me._groupBoxServer.Controls.Add(Me._labelServerAeTitle)
         Me._groupBoxServer.Controls.Add(Me._textBoxServerPort)
         Me._groupBoxServer.Controls.Add(Me._textBoxServerIp)
         Me._groupBoxServer.Controls.Add(Me._comboBoxService)
         Me._groupBoxServer.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
         Me._groupBoxServer.Location = New System.Drawing.Point(8, 8)
         Me._groupBoxServer.Name = "_groupBoxServer"
         Me._groupBoxServer.Size = New System.Drawing.Size(232, 100)
         Me._groupBoxServer.TabIndex = 10
         Me._groupBoxServer.TabStop = False
         Me._groupBoxServer.Text = "Server"
         '
         '_labelServerPort
         '
         Me._labelServerPort.AutoSize = True
         Me._labelServerPort.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
         Me._labelServerPort.Location = New System.Drawing.Point(8, 67)
         Me._labelServerPort.Name = "_labelServerPort"
         Me._labelServerPort.Size = New System.Drawing.Size(29, 13)
         Me._labelServerPort.TabIndex = 14
         Me._labelServerPort.Text = "Port:"
         Me._labelServerPort.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
         '
         '_labelServerIp
         '
         Me._labelServerIp.AutoSize = True
         Me._labelServerIp.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
         Me._labelServerIp.Location = New System.Drawing.Point(8, 44)
         Me._labelServerIp.Name = "_labelServerIp"
         Me._labelServerIp.Size = New System.Drawing.Size(20, 13)
         Me._labelServerIp.TabIndex = 13
         Me._labelServerIp.Text = "IP:"
         Me._labelServerIp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
         '
         '_labelServerAeTitle
         '
         Me._labelServerAeTitle.AutoSize = True
         Me._labelServerAeTitle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
         Me._labelServerAeTitle.Location = New System.Drawing.Point(8, 20)
         Me._labelServerAeTitle.Name = "_labelServerAeTitle"
         Me._labelServerAeTitle.Size = New System.Drawing.Size(24, 13)
         Me._labelServerAeTitle.TabIndex = 12
         Me._labelServerAeTitle.Text = "AE:"
         Me._labelServerAeTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
         '
         '_textBoxServerPort
         '
         Me._textBoxServerPort.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
               Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
         Me._textBoxServerPort.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
         Me._textBoxServerPort.Location = New System.Drawing.Point(48, 63)
         Me._textBoxServerPort.Name = "_textBoxServerPort"
         Me._textBoxServerPort.ReadOnly = True
         Me._textBoxServerPort.Size = New System.Drawing.Size(184, 20)
         Me._textBoxServerPort.TabIndex = 11
         '
         '_textBoxServerIp
         '
         Me._textBoxServerIp.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
               Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
         Me._textBoxServerIp.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
         Me._textBoxServerIp.Location = New System.Drawing.Point(48, 40)
         Me._textBoxServerIp.Name = "_textBoxServerIp"
         Me._textBoxServerIp.ReadOnly = True
         Me._textBoxServerIp.Size = New System.Drawing.Size(184, 20)
         Me._textBoxServerIp.TabIndex = 10
         '
         '_comboBoxService
         '
         Me._comboBoxService.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
               Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
         Me._comboBoxService.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
         Me._comboBoxService.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
         Me._comboBoxService.FormattingEnabled = True
         Me._comboBoxService.Location = New System.Drawing.Point(48, 16)
         Me._comboBoxService.Name = "_comboBoxService"
         Me._comboBoxService.Size = New System.Drawing.Size(184, 21)
         Me._comboBoxService.TabIndex = 9
         '
         '_buttonCancel
         '
         Me._buttonCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
         Me._buttonCancel.Location = New System.Drawing.Point(171, 112)
         Me._buttonCancel.Name = "_buttonCancel"
         Me._buttonCancel.Size = New System.Drawing.Size(75, 23)
         Me._buttonCancel.TabIndex = 2
         Me._buttonCancel.Text = "&Cancel"
         Me._buttonCancel.UseVisualStyleBackColor = True
         '
         '_buttonSearch
         '
         Me._buttonSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
         Me._buttonSearch.Location = New System.Drawing.Point(87, 112)
         Me._buttonSearch.Name = "_buttonSearch"
         Me._buttonSearch.Size = New System.Drawing.Size(75, 23)
         Me._buttonSearch.TabIndex = 1
         Me._buttonSearch.Text = "&Search"
         Me._buttonSearch.UseVisualStyleBackColor = True
         '
         '_buttonOptions
         '
         Me._buttonOptions.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
         Me._buttonOptions.Location = New System.Drawing.Point(3, 112)
         Me._buttonOptions.Name = "_buttonOptions"
         Me._buttonOptions.Size = New System.Drawing.Size(75, 23)
         Me._buttonOptions.TabIndex = 0
         Me._buttonOptions.Text = "&Options..."
         Me._buttonOptions.UseVisualStyleBackColor = True
         '
         '_splitContainer3
         '
         Me._splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill
         Me._splitContainer3.Location = New System.Drawing.Point(0, 0)
         Me._splitContainer3.Name = "_splitContainer3"
         Me._splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal
         '
         '_splitContainer3.Panel1
         '
         Me._splitContainer3.Panel1.Controls.Add(Me._listViewStudies)
         Me._splitContainer3.Panel1.Controls.Add(Me._label2)
         '
         '_splitContainer3.Panel2
         '
         Me._splitContainer3.Panel2.Controls.Add(Me._splitContainer4)
         Me._splitContainer3.Size = New System.Drawing.Size(636, 710)
         Me._splitContainer3.SplitterDistance = 137
         Me._splitContainer3.TabIndex = 0
         '
         '_listViewStudies
         '
         Me._listViewStudies.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me._columnHeader1, Me._columnHeader2, Me._columnHeader3, Me._columnHeader4, Me._columnHeaderStudyTime, Me._columnHeader5, Me._columnHeader6})
         Me._listViewStudies.Dock = System.Windows.Forms.DockStyle.Fill
         Me._listViewStudies.FullRowSelect = True
         Me._listViewStudies.GridLines = True
         Me._listViewStudies.HideSelection = False
         Me._listViewStudies.Location = New System.Drawing.Point(0, 23)
         Me._listViewStudies.MultiSelect = False
         Me._listViewStudies.Name = "_listViewStudies"
         Me._listViewStudies.Size = New System.Drawing.Size(636, 114)
         Me._listViewStudies.TabIndex = 1
         Me._listViewStudies.UseCompatibleStateImageBehavior = False
         Me._listViewStudies.View = System.Windows.Forms.View.Details
         '
         '_columnHeader1
         '
         Me._columnHeader1.Text = "Patient Name"
         '
         '_columnHeader2
         '
         Me._columnHeader2.Text = "Patient ID"
         '
         '_columnHeader3
         '
         Me._columnHeader3.Text = "Accession Number"
         '
         '_columnHeader4
         '
         Me._columnHeader4.Text = "Study Date"
         '
         '_columnHeaderStudyTime
         '
         Me._columnHeaderStudyTime.Text = "Study Time"
         '
         '_columnHeader5
         '
         Me._columnHeader5.Text = "Referring Physicians Name"
         '
         '_columnHeader6
         '
         Me._columnHeader6.Text = "Description"
         '
         '_label2
         '
         Me._label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
         Me._label2.Dock = System.Windows.Forms.DockStyle.Top
         Me._label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
         Me._label2.Location = New System.Drawing.Point(0, 0)
         Me._label2.Name = "_label2"
         Me._label2.Size = New System.Drawing.Size(636, 23)
         Me._label2.TabIndex = 0
         Me._label2.Text = "Studies Found: (Select item to retrieve series)"
         '
         '_splitContainer4
         '
         Me._splitContainer4.Dock = System.Windows.Forms.DockStyle.Fill
         Me._splitContainer4.Location = New System.Drawing.Point(0, 0)
         Me._splitContainer4.Name = "_splitContainer4"
         Me._splitContainer4.Orientation = System.Windows.Forms.Orientation.Horizontal
         '
         '_splitContainer4.Panel1
         '
         Me._splitContainer4.Panel1.Controls.Add(Me.buttonCGetStorageClasses)
         Me._splitContainer4.Panel1.Controls.Add(Me._listViewSeries)
         Me._splitContainer4.Panel1.Controls.Add(Me._radioButtonCGet)
         Me._splitContainer4.Panel1.Controls.Add(Me._radioButtonCMove)
         Me._splitContainer4.Panel1.Controls.Add(Me._label3)
         '
         '_splitContainer4.Panel2
         '
         Me._splitContainer4.Panel2.Controls.Add(Me._splitContainer5)
         Me._splitContainer4.Size = New System.Drawing.Size(636, 569)
         Me._splitContainer4.SplitterDistance = 133
         Me._splitContainer4.TabIndex = 0
         '
         'buttonCGetStorageClasses
         '
         Me.buttonCGetStorageClasses.Location = New System.Drawing.Point(413, 1)
         Me.buttonCGetStorageClasses.Name = "buttonCGetStorageClasses"
         Me.buttonCGetStorageClasses.Size = New System.Drawing.Size(146, 23)
         Me.buttonCGetStorageClasses.TabIndex = 8
         Me.buttonCGetStorageClasses.Text = "C-GET Storage Classes..."
         Me.buttonCGetStorageClasses.UseVisualStyleBackColor = True
         '
         '_listViewSeries
         '
         Me._listViewSeries.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me._columnHeader7, Me._columnHeader8, Me._columnHeader9, Me._columnHeader10, Me._columnHeader11})
         Me._listViewSeries.Dock = System.Windows.Forms.DockStyle.Fill
         Me._listViewSeries.FullRowSelect = True
         Me._listViewSeries.GridLines = True
         Me._listViewSeries.HideSelection = False
         Me._listViewSeries.Location = New System.Drawing.Point(0, 23)
         Me._listViewSeries.MultiSelect = False
         Me._listViewSeries.Name = "_listViewSeries"
         Me._listViewSeries.Size = New System.Drawing.Size(636, 110)
         Me._listViewSeries.TabIndex = 1
         Me._listViewSeries.UseCompatibleStateImageBehavior = False
         Me._listViewSeries.View = System.Windows.Forms.View.Details
         '
         '_columnHeader7
         '
         Me._columnHeader7.Text = "Series Date"
         '
         '_columnHeader8
         '
         Me._columnHeader8.Text = "Series Number"
         '
         '_columnHeader9
         '
         Me._columnHeader9.Text = "Description"
         '
         '_columnHeader10
         '
         Me._columnHeader10.Text = "Modality"
         '
         '_columnHeader11
         '
         Me._columnHeader11.Text = "Number of Instances"
         '
         '_radioButtonCGet
         '
         Me._radioButtonCGet.AutoSize = True
         Me._radioButtonCGet.Location = New System.Drawing.Point(353, 3)
         Me._radioButtonCGet.Name = "_radioButtonCGet"
         Me._radioButtonCGet.Size = New System.Drawing.Size(57, 17)
         Me._radioButtonCGet.TabIndex = 7
         Me._radioButtonCGet.TabStop = True
         Me._radioButtonCGet.Text = "C-GET"
         Me._radioButtonCGet.UseVisualStyleBackColor = True
         '
         '_radioButtonCMove
         '
         Me._radioButtonCMove.AutoSize = True
         Me._radioButtonCMove.Location = New System.Drawing.Point(277, 3)
         Me._radioButtonCMove.Name = "_radioButtonCMove"
         Me._radioButtonCMove.Size = New System.Drawing.Size(66, 17)
         Me._radioButtonCMove.TabIndex = 6
         Me._radioButtonCMove.TabStop = True
         Me._radioButtonCMove.Text = "C-MOVE"
         Me._radioButtonCMove.UseVisualStyleBackColor = True
         '
         '_label3
         '
         Me._label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
         Me._label3.Dock = System.Windows.Forms.DockStyle.Top
         Me._label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
         Me._label3.Location = New System.Drawing.Point(0, 0)
         Me._label3.Name = "_label3"
         Me._label3.Size = New System.Drawing.Size(636, 23)
         Me._label3.TabIndex = 0
         Me._label3.Text = "Series Found: (Double-click to retrieve images)"
         '
         '_splitContainer5
         '
         Me._splitContainer5.Dock = System.Windows.Forms.DockStyle.Fill
         Me._splitContainer5.Location = New System.Drawing.Point(0, 0)
         Me._splitContainer5.Name = "_splitContainer5"
         Me._splitContainer5.Orientation = System.Windows.Forms.Orientation.Horizontal
         '
         '_splitContainer5.Panel1
         '
         Me._splitContainer5.Panel1.Controls.Add(Me._toolStripCancel)
         Me._splitContainer5.Panel1.Controls.Add(Me._label4)
         '
         '_splitContainer5.Panel2
         '
         Me._splitContainer5.Panel2.Controls.Add(Me._labelStatus)
         Me._splitContainer5.Panel2.Controls.Add(Me._richTextBoxLog)
         Me._splitContainer5.Panel2.Controls.Add(Me._label5)
         Me._splitContainer5.Size = New System.Drawing.Size(636, 432)
         Me._splitContainer5.SplitterDistance = 266
         Me._splitContainer5.TabIndex = 0
         '
         '_toolStripCancel
         '
         Me._toolStripCancel.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me._toolStripButtonCancel})
         Me._toolStripCancel.Location = New System.Drawing.Point(0, 23)
         Me._toolStripCancel.Name = "_toolStripCancel"
         Me._toolStripCancel.Size = New System.Drawing.Size(636, 25)
         Me._toolStripCancel.TabIndex = 2
         Me._toolStripCancel.Text = "_toolStripCancel"
         Me._toolStripCancel.Visible = False
         '
         '_toolStripButtonCancel
         '
         Me._toolStripButtonCancel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
         Me._toolStripButtonCancel.Image = CType(resources.GetObject("_toolStripButtonCancel.Image"), System.Drawing.Image)
         Me._toolStripButtonCancel.ImageTransparentColor = System.Drawing.Color.Magenta
         Me._toolStripButtonCancel.Name = "_toolStripButtonCancel"
         Me._toolStripButtonCancel.Size = New System.Drawing.Size(23, 22)
         Me._toolStripButtonCancel.Text = "_toolStripButtonCancel"
         '
         '_label4
         '
         Me._label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
         Me._label4.Dock = System.Windows.Forms.DockStyle.Top
         Me._label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
         Me._label4.Location = New System.Drawing.Point(0, 0)
         Me._label4.Name = "_label4"
         Me._label4.Size = New System.Drawing.Size(636, 23)
         Me._label4.TabIndex = 0
         Me._label4.Text = "Images: (Left Double-click thumbnail to view image, Right to window level, Wheel " & _
       "to change frame)"
         '
         '_labelStatus
         '
         Me._labelStatus.AutoSize = True
         Me._labelStatus.ForeColor = System.Drawing.Color.Blue
         Me._labelStatus.Location = New System.Drawing.Point(193, 1)
         Me._labelStatus.Name = "_labelStatus"
         Me._labelStatus.Size = New System.Drawing.Size(35, 13)
         Me._labelStatus.TabIndex = 2
         Me._labelStatus.Text = "status"
         '
         '_richTextBoxLog
         '
         Me._richTextBoxLog.ContextMenuStrip = Me._contextMenuStripLog
         Me._richTextBoxLog.Dock = System.Windows.Forms.DockStyle.Fill
         Me._richTextBoxLog.Location = New System.Drawing.Point(0, 23)
         Me._richTextBoxLog.Name = "_richTextBoxLog"
         Me._richTextBoxLog.ReadOnly = True
         Me._richTextBoxLog.Size = New System.Drawing.Size(636, 139)
         Me._richTextBoxLog.TabIndex = 1
         Me._richTextBoxLog.Text = ""
         Me._richTextBoxLog.WordWrap = False
         '
         '_contextMenuStripLog
         '
         Me._contextMenuStripLog.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me._toolStripMenuItem1})
         Me._contextMenuStripLog.Name = "_contextMenuStripLog"
         Me._contextMenuStripLog.Size = New System.Drawing.Size(125, 26)
         '
         '_toolStripMenuItem1
         '
         Me._toolStripMenuItem1.Name = "_toolStripMenuItem1"
         Me._toolStripMenuItem1.Size = New System.Drawing.Size(124, 22)
         Me._toolStripMenuItem1.Text = "&Clear Log"
         '
         '_label5
         '
         Me._label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
         Me._label5.Dock = System.Windows.Forms.DockStyle.Top
         Me._label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
         Me._label5.Location = New System.Drawing.Point(0, 0)
         Me._label5.Name = "_label5"
         Me._label5.Size = New System.Drawing.Size(636, 23)
         Me._label5.TabIndex = 0
         Me._label5.Text = "Log: (Right-click to clear)"
         '
         'MainForm
         '
         Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit
         Me.ClientSize = New System.Drawing.Size(888, 734)
         Me.Controls.Add(Me._splitContainer1)
         Me.Controls.Add(Me._menuStrip)
         Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
         Me.MainMenuStrip = Me._menuStrip
         Me.MinimumSize = New System.Drawing.Size(640, 480)
         Me.Name = "MainForm"
         Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
         Me.Text = "LEADTOOLS High Level DICOM Client Demo - VB.Net"
         Me._menuStrip.ResumeLayout(False)
         Me._menuStrip.PerformLayout()
         Me._splitContainer1.Panel1.ResumeLayout(False)
         Me._splitContainer1.Panel2.ResumeLayout(False)
         CType(Me._splitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
         Me._splitContainer1.ResumeLayout(False)
         Me._splitContainer2.Panel1.ResumeLayout(False)
         Me._splitContainer2.Panel2.ResumeLayout(False)
         CType(Me._splitContainer2, System.ComponentModel.ISupportInitialize).EndInit()
         Me._splitContainer2.ResumeLayout(False)
         Me._groupBoxServer.ResumeLayout(False)
         Me._groupBoxServer.PerformLayout()
         Me._splitContainer3.Panel1.ResumeLayout(False)
         Me._splitContainer3.Panel2.ResumeLayout(False)
         CType(Me._splitContainer3, System.ComponentModel.ISupportInitialize).EndInit()
         Me._splitContainer3.ResumeLayout(False)
         Me._splitContainer4.Panel1.ResumeLayout(False)
         Me._splitContainer4.Panel1.PerformLayout()
         Me._splitContainer4.Panel2.ResumeLayout(False)
         CType(Me._splitContainer4, System.ComponentModel.ISupportInitialize).EndInit()
         Me._splitContainer4.ResumeLayout(False)
         Me._splitContainer5.Panel1.ResumeLayout(False)
         Me._splitContainer5.Panel1.PerformLayout()
         Me._splitContainer5.Panel2.ResumeLayout(False)
         Me._splitContainer5.Panel2.PerformLayout()
         CType(Me._splitContainer5, System.ComponentModel.ISupportInitialize).EndInit()
         Me._splitContainer5.ResumeLayout(False)
         Me._toolStripCancel.ResumeLayout(False)
         Me._toolStripCancel.PerformLayout()
         Me._contextMenuStripLog.ResumeLayout(False)
         Me.ResumeLayout(False)
         Me.PerformLayout()

      End Sub

#End Region

      Private fileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents clearLogToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private toolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
      Private WithEvents exitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private helpToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents aboutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private _menuStrip As System.Windows.Forms.MenuStrip
      Private _splitContainer1 As System.Windows.Forms.SplitContainer
      Private WithEvents _splitContainer2 As System.Windows.Forms.SplitContainer
      Private _label1 As System.Windows.Forms.Label
      Private WithEvents _buttonOptions As System.Windows.Forms.Button
      Private _splitContainer3 As System.Windows.Forms.SplitContainer
      Private _label2 As System.Windows.Forms.Label
      Private _splitContainer4 As System.Windows.Forms.SplitContainer
      Private _label3 As System.Windows.Forms.Label
      Private _splitContainer5 As System.Windows.Forms.SplitContainer
      Private _label4 As System.Windows.Forms.Label
      Private WithEvents _buttonSearch As System.Windows.Forms.Button
      Private _propertyGrid As System.Windows.Forms.PropertyGrid
      Private WithEvents _listViewStudies As System.Windows.Forms.ListView
      Private WithEvents _listViewSeries As System.Windows.Forms.ListView
      Private _columnHeader1 As System.Windows.Forms.ColumnHeader
      Private _columnHeader2 As System.Windows.Forms.ColumnHeader
      Private _columnHeader3 As System.Windows.Forms.ColumnHeader
      Private _columnHeader4 As System.Windows.Forms.ColumnHeader
      Private _columnHeader5 As System.Windows.Forms.ColumnHeader
      Private _columnHeader6 As System.Windows.Forms.ColumnHeader
      Private _columnHeader7 As System.Windows.Forms.ColumnHeader
      Private _columnHeader8 As System.Windows.Forms.ColumnHeader
      Private _columnHeader9 As System.Windows.Forms.ColumnHeader
      Private _columnHeader10 As System.Windows.Forms.ColumnHeader
      Private _columnHeader11 As System.Windows.Forms.ColumnHeader
      Private _toolStripCancel As System.Windows.Forms.ToolStrip
      Private _toolStripButtonCancel As System.Windows.Forms.ToolStripButton
      Private _contextMenuStripLog As System.Windows.Forms.ContextMenuStrip
      Private WithEvents _toolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents optionsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents searchToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private toolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
      Private WithEvents _buttonCancel As System.Windows.Forms.Button
      Private _labelStatus As System.Windows.Forms.Label
      Private WithEvents showHelpToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private _richTextBoxLog As System.Windows.Forms.RichTextBox
      Private _label5 As System.Windows.Forms.Label
      Private WithEvents _groupBoxServer As System.Windows.Forms.GroupBox
      Private WithEvents _labelServerPort As System.Windows.Forms.Label
      Private WithEvents _labelServerIp As System.Windows.Forms.Label
      Private WithEvents _labelServerAeTitle As System.Windows.Forms.Label
      Private WithEvents _textBoxServerPort As System.Windows.Forms.TextBox
      Private WithEvents _textBoxServerIp As System.Windows.Forms.TextBox
      Private WithEvents _comboBoxService As System.Windows.Forms.ComboBox
      Friend WithEvents _columnHeaderStudyTime As System.Windows.Forms.ColumnHeader
      Private WithEvents buttonCGetStorageClasses As System.Windows.Forms.Button
      Private WithEvents _radioButtonCGet As System.Windows.Forms.RadioButton
      Private WithEvents _radioButtonCMove As System.Windows.Forms.RadioButton

    End Class
End Namespace
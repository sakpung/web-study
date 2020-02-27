Imports Microsoft.VisualBasic
Imports System
Namespace VBDicomDirLinqDemo.UI
	Partial Public Class MainForm
		''' <summary>
		''' Required designer variable.
		''' </summary>
		Private components As System.ComponentModel.IContainer = Nothing

		''' <summary>
		''' Clean up any resources being used.
		''' </summary>
		''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		Protected Overrides Sub Dispose(ByVal disposing As Boolean)
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
            Me.components = New System.ComponentModel.Container
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainForm))
            Me.toolStripContainer1 = New System.Windows.Forms.ToolStripContainer
            Me.statusStrip1 = New System.Windows.Forms.StatusStrip
            Me.splitContainerLeft = New System.Windows.Forms.SplitContainer
            Me.treeViewDicomDir = New System.Windows.Forms.TreeView
            Me.label1 = New System.Windows.Forms.Label
            Me.panel1 = New System.Windows.Forms.Panel
            Me.txtElementValue = New System.Windows.Forms.TextBox
            Me.label3 = New System.Windows.Forms.Label
            Me.splitContainer1 = New System.Windows.Forms.SplitContainer
            Me.richTextBoxLinqInfo = New System.Windows.Forms.RichTextBox
            Me.label4 = New System.Windows.Forms.Label
            Me.splitter1 = New System.Windows.Forms.Splitter
            Me.tabControl = New System.Windows.Forms.TabControl
            Me.tabPageQuery = New System.Windows.Forms.TabPage
            Me.richTextBoxScript = New System.Windows.Forms.RichTextBox
            Me.tabPageResults = New System.Windows.Forms.TabPage
            Me.webBrowserResults = New System.Windows.Forms.WebBrowser
            Me.tabPageViewer = New System.Windows.Forms.TabPage
            Me.imageList = New System.Windows.Forms.ImageList(Me.components)
            Me.queryPanel = New System.Windows.Forms.FlowLayoutPanel
            Me.label2 = New System.Windows.Forms.Label
            Me.menuStrip1 = New System.Windows.Forms.MenuStrip
            Me.toolStripMenuItemFile = New System.Windows.Forms.ToolStripMenuItem
            Me.toolStripMenuItemOpen = New System.Windows.Forms.ToolStripMenuItem
            Me.toolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator
            Me.exitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
            Me.helpToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
            Me.aboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
            Me.toolStrip1 = New System.Windows.Forms.ToolStrip
            Me.toolStripButtonOpen = New System.Windows.Forms.ToolStripButton
            Me.toolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
            Me.toolStripButtonExecute = New System.Windows.Forms.ToolStripButton
            Me.toolStripButtonThumbnails = New System.Windows.Forms.ToolStripButton
            Me.toolStripStatusLabel = New System.Windows.Forms.ToolStripStatusLabel
            Me.toolStripProgressBar = New System.Windows.Forms.ToolStripProgressBar
            Me.toolStripMenuItem2 = New System.Windows.Forms.ToolStripSeparator
            Me.helpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
            Me.toolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
            Me.openFileDialog = New System.Windows.Forms.OpenFileDialog
            Me.toolTip = New System.Windows.Forms.ToolTip(Me.components)
            Me.LinkLabelDownloadSampleDicomDir = New System.Windows.Forms.LinkLabel
            Me.DownloadSampleDICOMDIRToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
            Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator
            Me.toolStripContainer1.BottomToolStripPanel.SuspendLayout()
            Me.toolStripContainer1.ContentPanel.SuspendLayout()
            Me.toolStripContainer1.TopToolStripPanel.SuspendLayout()
            Me.toolStripContainer1.SuspendLayout()
            Me.splitContainerLeft.Panel1.SuspendLayout()
            Me.splitContainerLeft.Panel2.SuspendLayout()
            Me.splitContainerLeft.SuspendLayout()
            Me.panel1.SuspendLayout()
            Me.splitContainer1.Panel1.SuspendLayout()
            Me.splitContainer1.Panel2.SuspendLayout()
            Me.splitContainer1.SuspendLayout()
            Me.tabControl.SuspendLayout()
            Me.tabPageQuery.SuspendLayout()
            Me.tabPageResults.SuspendLayout()
            Me.menuStrip1.SuspendLayout()
            Me.toolStrip1.SuspendLayout()
            Me.SuspendLayout()
            '
            'toolStripContainer1
            '
            '
            'toolStripContainer1.BottomToolStripPanel
            '
            Me.toolStripContainer1.BottomToolStripPanel.Controls.Add(Me.statusStrip1)
            '
            'toolStripContainer1.ContentPanel
            '
            Me.toolStripContainer1.ContentPanel.Controls.Add(Me.splitContainerLeft)
            Me.toolStripContainer1.ContentPanel.Size = New System.Drawing.Size(1032, 599)
            Me.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.toolStripContainer1.Location = New System.Drawing.Point(0, 0)
            Me.toolStripContainer1.Name = "toolStripContainer1"
            Me.toolStripContainer1.Size = New System.Drawing.Size(1032, 670)
            Me.toolStripContainer1.TabIndex = 0
            Me.toolStripContainer1.Text = "toolStripContainer1"
            '
            'toolStripContainer1.TopToolStripPanel
            '
            Me.toolStripContainer1.TopToolStripPanel.Controls.Add(Me.menuStrip1)
            Me.toolStripContainer1.TopToolStripPanel.Controls.Add(Me.toolStrip1)
            '
            'statusStrip1
            '
            Me.statusStrip1.Dock = System.Windows.Forms.DockStyle.None
            Me.statusStrip1.Location = New System.Drawing.Point(0, 0)
            Me.statusStrip1.Name = "statusStrip1"
            Me.statusStrip1.Size = New System.Drawing.Size(1032, 22)
            Me.statusStrip1.TabIndex = 0
            Me.statusStrip1.Text = "statusStrip1"
            '
            'splitContainerLeft
            '
            Me.splitContainerLeft.AllowDrop = True
            Me.splitContainerLeft.Dock = System.Windows.Forms.DockStyle.Fill
            Me.splitContainerLeft.Location = New System.Drawing.Point(0, 0)
            Me.splitContainerLeft.Name = "splitContainerLeft"
            '
            'splitContainerLeft.Panel1
            '
            Me.splitContainerLeft.Panel1.AllowDrop = True
            Me.splitContainerLeft.Panel1.Controls.Add(Me.treeViewDicomDir)
            Me.splitContainerLeft.Panel1.Controls.Add(Me.label1)
            Me.splitContainerLeft.Panel1.Controls.Add(Me.panel1)
            '
            'splitContainerLeft.Panel2
            '
            Me.splitContainerLeft.Panel2.Controls.Add(Me.splitContainer1)
            Me.splitContainerLeft.Size = New System.Drawing.Size(1032, 599)
            Me.splitContainerLeft.SplitterDistance = 304
            Me.splitContainerLeft.TabIndex = 1
            '
            'treeViewDicomDir
            '
            Me.treeViewDicomDir.AllowDrop = True
            Me.treeViewDicomDir.Dock = System.Windows.Forms.DockStyle.Fill
            Me.treeViewDicomDir.FullRowSelect = True
            Me.treeViewDicomDir.Location = New System.Drawing.Point(0, 13)
            Me.treeViewDicomDir.Name = "treeViewDicomDir"
            Me.treeViewDicomDir.Size = New System.Drawing.Size(304, 493)
            Me.treeViewDicomDir.TabIndex = 1
'		   Me.treeViewDicomDir.DragDrop += New System.Windows.Forms.DragEventHandler(Me.treeViewDicomDir_DragDrop);
'		   Me.treeViewDicomDir.AfterSelect += New System.Windows.Forms.TreeViewEventHandler(Me.treeViewDicomDir_AfterSelect);
'		   Me.treeViewDicomDir.DragEnter += New System.Windows.Forms.DragEventHandler(Me.treeViewDicomDir_DragEnter);
            '
            'label1
            '
            Me.label1.AutoSize = True
            Me.label1.Dock = System.Windows.Forms.DockStyle.Top
            Me.label1.Location = New System.Drawing.Point(0, 0)
            Me.label1.Name = "label1"
            Me.label1.Size = New System.Drawing.Size(64, 13)
            Me.label1.TabIndex = 0
            Me.label1.Text = "DICOMDIR:"
            '
            'panel1
            '
            Me.panel1.Controls.Add(Me.txtElementValue)
            Me.panel1.Controls.Add(Me.label3)
            Me.panel1.Dock = System.Windows.Forms.DockStyle.Bottom
            Me.panel1.Location = New System.Drawing.Point(0, 506)
            Me.panel1.Name = "panel1"
            Me.panel1.Size = New System.Drawing.Size(304, 93)
            Me.panel1.TabIndex = 4
            '
            'txtElementValue
            '
            Me.txtElementValue.Dock = System.Windows.Forms.DockStyle.Fill
            Me.txtElementValue.Location = New System.Drawing.Point(0, 13)
            Me.txtElementValue.Multiline = True
            Me.txtElementValue.Name = "txtElementValue"
            Me.txtElementValue.ReadOnly = True
            Me.txtElementValue.Size = New System.Drawing.Size(304, 80)
            Me.txtElementValue.TabIndex = 1
            '
            'label3
            '
            Me.label3.AutoSize = True
            Me.label3.Dock = System.Windows.Forms.DockStyle.Top
            Me.label3.Location = New System.Drawing.Point(0, 0)
            Me.label3.Name = "label3"
            Me.label3.Size = New System.Drawing.Size(78, 13)
            Me.label3.TabIndex = 0
            Me.label3.Text = "Element Value:"
            '
            'splitContainer1
            '
            Me.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2
            Me.splitContainer1.Location = New System.Drawing.Point(0, 0)
            Me.splitContainer1.Name = "splitContainer1"
            '
            'splitContainer1.Panel1
            '
            Me.splitContainer1.Panel1.Controls.Add(Me.richTextBoxLinqInfo)
            Me.splitContainer1.Panel1.Controls.Add(Me.label4)
            Me.splitContainer1.Panel1.Controls.Add(Me.splitter1)
            Me.splitContainer1.Panel1.Controls.Add(Me.tabControl)
            '
            'splitContainer1.Panel2
            '
            Me.splitContainer1.Panel2.Controls.Add(Me.LinkLabelDownloadSampleDicomDir)
            Me.splitContainer1.Panel2.Controls.Add(Me.queryPanel)
            Me.splitContainer1.Panel2.Controls.Add(Me.label2)
            Me.splitContainer1.Size = New System.Drawing.Size(724, 599)
            Me.splitContainer1.SplitterDistance = 559
            Me.splitContainer1.TabIndex = 1
            '
            'richTextBoxLinqInfo
            '
            Me.richTextBoxLinqInfo.Dock = System.Windows.Forms.DockStyle.Fill
            Me.richTextBoxLinqInfo.Location = New System.Drawing.Point(0, 423)
            Me.richTextBoxLinqInfo.Name = "richTextBoxLinqInfo"
            Me.richTextBoxLinqInfo.ReadOnly = True
            Me.richTextBoxLinqInfo.Size = New System.Drawing.Size(559, 176)
            Me.richTextBoxLinqInfo.TabIndex = 2
            Me.richTextBoxLinqInfo.Text = ""
            '
            'label4
            '
            Me.label4.AutoSize = True
            Me.label4.Dock = System.Windows.Forms.DockStyle.Top
            Me.label4.Location = New System.Drawing.Point(0, 410)
            Me.label4.Name = "label4"
            Me.label4.Size = New System.Drawing.Size(85, 13)
            Me.label4.TabIndex = 3
            Me.label4.Text = "Linq Information:"
            '
            'splitter1
            '
            Me.splitter1.Dock = System.Windows.Forms.DockStyle.Top
            Me.splitter1.Location = New System.Drawing.Point(0, 407)
            Me.splitter1.Name = "splitter1"
            Me.splitter1.Size = New System.Drawing.Size(559, 3)
            Me.splitter1.TabIndex = 1
            Me.splitter1.TabStop = False
            '
            'tabControl
            '
            Me.tabControl.Controls.Add(Me.tabPageQuery)
            Me.tabControl.Controls.Add(Me.tabPageResults)
            Me.tabControl.Controls.Add(Me.tabPageViewer)
            Me.tabControl.Dock = System.Windows.Forms.DockStyle.Top
            Me.tabControl.ImageList = Me.imageList
            Me.tabControl.Location = New System.Drawing.Point(0, 0)
            Me.tabControl.Name = "tabControl"
            Me.tabControl.SelectedIndex = 0
            Me.tabControl.Size = New System.Drawing.Size(559, 407)
            Me.tabControl.TabIndex = 0
            '
            'tabPageQuery
            '
            Me.tabPageQuery.Controls.Add(Me.richTextBoxScript)
            Me.tabPageQuery.ImageIndex = 0
            Me.tabPageQuery.Location = New System.Drawing.Point(4, 23)
            Me.tabPageQuery.Name = "tabPageQuery"
            Me.tabPageQuery.Padding = New System.Windows.Forms.Padding(3)
            Me.tabPageQuery.Size = New System.Drawing.Size(551, 380)
            Me.tabPageQuery.TabIndex = 0
            Me.tabPageQuery.Text = "Linq Query"
            Me.tabPageQuery.UseVisualStyleBackColor = True
            '
            'richTextBoxScript
            '
            Me.richTextBoxScript.CausesValidation = False
            Me.richTextBoxScript.DetectUrls = False
            Me.richTextBoxScript.Dock = System.Windows.Forms.DockStyle.Fill
            Me.richTextBoxScript.Font = New System.Drawing.Font("Courier New", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.richTextBoxScript.Location = New System.Drawing.Point(3, 3)
            Me.richTextBoxScript.Name = "richTextBoxScript"
            Me.richTextBoxScript.Size = New System.Drawing.Size(545, 374)
            Me.richTextBoxScript.TabIndex = 1
            Me.richTextBoxScript.Text = ""
            Me.richTextBoxScript.WordWrap = False
            '
            'tabPageResults
            '
            Me.tabPageResults.Controls.Add(Me.webBrowserResults)
            Me.tabPageResults.ImageIndex = 1
            Me.tabPageResults.Location = New System.Drawing.Point(4, 23)
            Me.tabPageResults.Name = "tabPageResults"
            Me.tabPageResults.Padding = New System.Windows.Forms.Padding(3)
            Me.tabPageResults.Size = New System.Drawing.Size(551, 380)
            Me.tabPageResults.TabIndex = 1
            Me.tabPageResults.Text = "Results"
            Me.tabPageResults.UseVisualStyleBackColor = True
            '
            'webBrowserResults
            '
            Me.webBrowserResults.Dock = System.Windows.Forms.DockStyle.Fill
            Me.webBrowserResults.Location = New System.Drawing.Point(3, 3)
            Me.webBrowserResults.MinimumSize = New System.Drawing.Size(20, 20)
            Me.webBrowserResults.Name = "webBrowserResults"
            Me.webBrowserResults.Size = New System.Drawing.Size(545, 374)
            Me.webBrowserResults.TabIndex = 0
'		   Me.webBrowserResults.Navigating += New System.Windows.Forms.WebBrowserNavigatingEventHandler(Me.webBrowserResults_Navigating);
            '
            'tabPageViewer
            '
            Me.tabPageViewer.ImageIndex = 2
            Me.tabPageViewer.Location = New System.Drawing.Point(4, 23)
            Me.tabPageViewer.Name = "tabPageViewer"
            Me.tabPageViewer.Padding = New System.Windows.Forms.Padding(3)
            Me.tabPageViewer.Size = New System.Drawing.Size(551, 380)
            Me.tabPageViewer.TabIndex = 2
            Me.tabPageViewer.Text = "Viewer"
            Me.tabPageViewer.UseVisualStyleBackColor = True
            '
            'imageList
            '
            Me.imageList.ImageStream = CType(resources.GetObject("imageList.ImageStream"), System.Windows.Forms.ImageListStreamer)
            Me.imageList.TransparentColor = System.Drawing.Color.Transparent
            Me.imageList.Images.SetKeyName(0, "lightning.png")
            Me.imageList.Images.SetKeyName(1, "application_view_detail.png")
            Me.imageList.Images.SetKeyName(2, "image.png")
            '
            'queryPanel
            '
            Me.queryPanel.AutoScroll = True
            Me.queryPanel.Dock = System.Windows.Forms.DockStyle.Top
            Me.queryPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown
            Me.queryPanel.Location = New System.Drawing.Point(0, 85)
            Me.queryPanel.Name = "queryPanel"
            Me.queryPanel.Size = New System.Drawing.Size(161, 323)
            Me.queryPanel.TabIndex = 0
            Me.queryPanel.WrapContents = False
            '
            'label2
            '
            Me.label2.Dock = System.Windows.Forms.DockStyle.Top
            Me.label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.label2.Location = New System.Drawing.Point(0, 0)
            Me.label2.Margin = New System.Windows.Forms.Padding(3, 0, 3, 15)
            Me.label2.Name = "label2"
            Me.label2.Size = New System.Drawing.Size(161, 85)
            Me.label2.TabIndex = 0
		   Me.label2.Text = "Click one of the sample queries below to add to the query editor.  Click the exec" & "ute icon to execute the query using the loaded DICOMDIR."
            '
            'menuStrip1
            '
            Me.menuStrip1.Dock = System.Windows.Forms.DockStyle.None
            Me.menuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolStripMenuItemFile, Me.helpToolStripMenuItem1})
            Me.menuStrip1.Location = New System.Drawing.Point(0, 0)
            Me.menuStrip1.Name = "menuStrip1"
            Me.menuStrip1.Size = New System.Drawing.Size(1032, 24)
            Me.menuStrip1.TabIndex = 0
            Me.menuStrip1.Text = "menuStrip1"
            '
            'toolStripMenuItemFile
            '
            Me.toolStripMenuItemFile.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolStripMenuItemOpen, Me.toolStripMenuItem1, Me.DownloadSampleDICOMDIRToolStripMenuItem, Me.ToolStripSeparator3, Me.exitToolStripMenuItem})
            Me.toolStripMenuItemFile.Name = "toolStripMenuItemFile"
            Me.toolStripMenuItemFile.Size = New System.Drawing.Size(37, 20)
            Me.toolStripMenuItemFile.Text = "&File"
            '
            'toolStripMenuItemOpen
            '
            Me.toolStripMenuItemOpen.Name = "toolStripMenuItemOpen"
            Me.toolStripMenuItemOpen.Size = New System.Drawing.Size(112, 22)
            Me.toolStripMenuItemOpen.Text = "&Open..."
'		   Me.toolStripMenuItemOpen.Click += New System.EventHandler(Me.openToolStripMenuItem_Click);
            '
            'toolStripMenuItem1
            '
            Me.toolStripMenuItem1.Name = "toolStripMenuItem1"
            Me.toolStripMenuItem1.Size = New System.Drawing.Size(109, 6)
            '
            'exitToolStripMenuItem
            '
            Me.exitToolStripMenuItem.Name = "exitToolStripMenuItem"
            Me.exitToolStripMenuItem.Size = New System.Drawing.Size(112, 22)
            Me.exitToolStripMenuItem.Text = "&Exit"
'		   Me.exitToolStripMenuItem.Click += New System.EventHandler(Me.exitToolStripMenuItem_Click);
            '
            'helpToolStripMenuItem1
            '
            Me.helpToolStripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.aboutToolStripMenuItem})
            Me.helpToolStripMenuItem1.Name = "helpToolStripMenuItem1"
            Me.helpToolStripMenuItem1.Size = New System.Drawing.Size(44, 20)
            Me.helpToolStripMenuItem1.Text = "&Help"
            '
            'aboutToolStripMenuItem
            '
            Me.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem"
            Me.aboutToolStripMenuItem.Size = New System.Drawing.Size(116, 22)
            Me.aboutToolStripMenuItem.Text = "&About..."
'		   Me.aboutToolStripMenuItem.Click += New System.EventHandler(Me.aboutToolStripMenuItem_Click);
            '
            'toolStrip1
            '
            Me.toolStrip1.Dock = System.Windows.Forms.DockStyle.None
            Me.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
            Me.toolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolStripButtonOpen, Me.toolStripSeparator2, Me.toolStripButtonExecute, Me.toolStripButtonThumbnails})
            Me.toolStrip1.Location = New System.Drawing.Point(3, 24)
            Me.toolStrip1.Name = "toolStrip1"
            Me.toolStrip1.Size = New System.Drawing.Size(78, 25)
            Me.toolStrip1.TabIndex = 1
            '
            'toolStripButtonOpen
            '
            Me.toolStripButtonOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
		   Me.toolStripButtonOpen.Image = My.Resources.Folder_Open
            Me.toolStripButtonOpen.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
            Me.toolStripButtonOpen.ImageTransparentColor = System.Drawing.Color.Magenta
            Me.toolStripButtonOpen.Name = "toolStripButtonOpen"
            Me.toolStripButtonOpen.Size = New System.Drawing.Size(23, 22)
            Me.toolStripButtonOpen.ToolTipText = "Open DICOMDIR"
'		   Me.toolStripButtonOpen.Click += New System.EventHandler(Me.openToolStripMenuItem_Click);
            '
            'toolStripSeparator2
            '
            Me.toolStripSeparator2.Name = "toolStripSeparator2"
            Me.toolStripSeparator2.Size = New System.Drawing.Size(6, 25)
            '
            'toolStripButtonExecute
            '
            Me.toolStripButtonExecute.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
		   Me.toolStripButtonExecute.Image = My.Resources.Autoplay
            Me.toolStripButtonExecute.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
            Me.toolStripButtonExecute.ImageTransparentColor = System.Drawing.Color.Magenta
            Me.toolStripButtonExecute.Name = "toolStripButtonExecute"
            Me.toolStripButtonExecute.Size = New System.Drawing.Size(23, 22)
            Me.toolStripButtonExecute.ToolTipText = "Execute script"
'		   Me.toolStripButtonExecute.Click += New System.EventHandler(Me.toolStripButtonExecute_Click);
            '
            'toolStripButtonThumbnails
            '
            Me.toolStripButtonThumbnails.Checked = True
            Me.toolStripButtonThumbnails.CheckOnClick = True
            Me.toolStripButtonThumbnails.CheckState = System.Windows.Forms.CheckState.Checked
            Me.toolStripButtonThumbnails.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
		   Me.toolStripButtonThumbnails.Image = My.Resources.generic_picture
            Me.toolStripButtonThumbnails.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
            Me.toolStripButtonThumbnails.ImageTransparentColor = System.Drawing.Color.Magenta
            Me.toolStripButtonThumbnails.Name = "toolStripButtonThumbnails"
            Me.toolStripButtonThumbnails.Size = New System.Drawing.Size(23, 22)
            Me.toolStripButtonThumbnails.Text = "toolStripButtonThumbnails"
            Me.toolStripButtonThumbnails.ToolTipText = "View Thumbnails"
            '
            'toolStripStatusLabel
            '
            Me.toolStripStatusLabel.Name = "toolStripStatusLabel"
            Me.toolStripStatusLabel.Size = New System.Drawing.Size(1017, 17)
            Me.toolStripStatusLabel.Spring = True
            '
            'toolStripProgressBar
            '
            Me.toolStripProgressBar.MarqueeAnimationSpeed = 0
            Me.toolStripProgressBar.Name = "toolStripProgressBar"
            Me.toolStripProgressBar.Size = New System.Drawing.Size(100, 16)
            Me.toolStripProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee
            Me.toolStripProgressBar.Visible = False
            '
            'toolStripMenuItem2
            '
            Me.toolStripMenuItem2.Name = "toolStripMenuItem2"
            Me.toolStripMenuItem2.Size = New System.Drawing.Size(6, 6)
            '
            'helpToolStripMenuItem
            '
            Me.helpToolStripMenuItem.Name = "helpToolStripMenuItem"
            Me.helpToolStripMenuItem.Size = New System.Drawing.Size(32, 19)
            '
            'toolStripSeparator1
            '
            Me.toolStripSeparator1.Name = "toolStripSeparator1"
            Me.toolStripSeparator1.Size = New System.Drawing.Size(6, 6)
            '
            'openFileDialog
            '
            Me.openFileDialog.Filter = "DICOM Basic Directory|DICOMDIR|All Files|*.*"
            Me.openFileDialog.Title = "Load DICOM Basic Directory"
            '
            'toolTip
            '
            Me.toolTip.ToolTipTitle = "Query"
            '
            'LinkLabelDownloadSampleDicomDir
            '
            Me.LinkLabelDownloadSampleDicomDir.AutoSize = True
            Me.LinkLabelDownloadSampleDicomDir.Location = New System.Drawing.Point(8, 472)
            Me.LinkLabelDownloadSampleDicomDir.Name = "LinkLabelDownloadSampleDicomDir"
            Me.LinkLabelDownloadSampleDicomDir.Size = New System.Drawing.Size(150, 13)
            Me.LinkLabelDownloadSampleDicomDir.TabIndex = 1
            Me.LinkLabelDownloadSampleDicomDir.TabStop = True
            Me.LinkLabelDownloadSampleDicomDir.Text = "Download Sample DICOMDIR"
            '
            'DownloadSampleDICOMDIRToolStripMenuItem
            '
            Me.DownloadSampleDICOMDIRToolStripMenuItem.Name = "DownloadSampleDICOMDIRToolStripMenuItem"
            Me.DownloadSampleDICOMDIRToolStripMenuItem.Size = New System.Drawing.Size(239, 22)
            Me.DownloadSampleDICOMDIRToolStripMenuItem.Text = "Download Sample DICOMDIR..."
            '
            'ToolStripSeparator3
            '
            Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
            Me.ToolStripSeparator3.Size = New System.Drawing.Size(236, 6)
            '
            'MainForm
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(1032, 670)
            Me.Controls.Add(Me.toolStripContainer1)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.MainMenuStrip = Me.menuStrip1
            Me.Name = "MainForm"
            Me.Text = "MainForm"
            Me.toolStripContainer1.BottomToolStripPanel.ResumeLayout(False)
            Me.toolStripContainer1.BottomToolStripPanel.PerformLayout()
            Me.toolStripContainer1.ContentPanel.ResumeLayout(False)
            Me.toolStripContainer1.TopToolStripPanel.ResumeLayout(False)
            Me.toolStripContainer1.TopToolStripPanel.PerformLayout()
            Me.toolStripContainer1.ResumeLayout(False)
            Me.toolStripContainer1.PerformLayout()
            Me.splitContainerLeft.Panel1.ResumeLayout(False)
            Me.splitContainerLeft.Panel1.PerformLayout()
            Me.splitContainerLeft.Panel2.ResumeLayout(False)
            Me.splitContainerLeft.ResumeLayout(False)
            Me.panel1.ResumeLayout(False)
            Me.panel1.PerformLayout()
            Me.splitContainer1.Panel1.ResumeLayout(False)
            Me.splitContainer1.Panel1.PerformLayout()
            Me.splitContainer1.Panel2.ResumeLayout(False)
            Me.splitContainer1.Panel2.PerformLayout()
            Me.splitContainer1.ResumeLayout(False)
            Me.tabControl.ResumeLayout(False)
            Me.tabPageQuery.ResumeLayout(False)
            Me.tabPageResults.ResumeLayout(False)
            Me.menuStrip1.ResumeLayout(False)
            Me.menuStrip1.PerformLayout()
            Me.toolStrip1.ResumeLayout(False)
            Me.toolStrip1.PerformLayout()
            Me.ResumeLayout(False)

        End Sub

		#End Region        

		Private toolStripContainer1 As System.Windows.Forms.ToolStripContainer
		Private splitContainerLeft As System.Windows.Forms.SplitContainer
		Private label1 As System.Windows.Forms.Label
		Private statusStrip1 As System.Windows.Forms.StatusStrip
		Private WithEvents treeViewDicomDir As System.Windows.Forms.TreeView
		Private richTextBoxScript As System.Windows.Forms.RichTextBox
		Private openFileDialog As System.Windows.Forms.OpenFileDialog
		Private toolStripMenuItem2 As System.Windows.Forms.ToolStripSeparator
		Private panel1 As System.Windows.Forms.Panel
		Private txtElementValue As System.Windows.Forms.TextBox
		Private label3 As System.Windows.Forms.Label
		Private tabControl As System.Windows.Forms.TabControl
		Private tabPageQuery As System.Windows.Forms.TabPage
		Private tabPageResults As System.Windows.Forms.TabPage
		Private WithEvents webBrowserResults As System.Windows.Forms.WebBrowser
		Private imageList As System.Windows.Forms.ImageList
		Private tabPageViewer As System.Windows.Forms.TabPage
		Private toolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
		Private toolStripStatusLabel As System.Windows.Forms.ToolStripStatusLabel
		Private toolStripProgressBar As System.Windows.Forms.ToolStripProgressBar
		Private helpToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
		Private splitContainer1 As System.Windows.Forms.SplitContainer
		Private queryPanel As System.Windows.Forms.FlowLayoutPanel
		Private label2 As System.Windows.Forms.Label
		Private toolTip As System.Windows.Forms.ToolTip
		Private menuStrip1 As System.Windows.Forms.MenuStrip
		Private toolStripMenuItemFile As System.Windows.Forms.ToolStripMenuItem
		Private WithEvents toolStripMenuItemOpen As System.Windows.Forms.ToolStripMenuItem
		Private toolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
		Private WithEvents exitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
		Private helpToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
		Private WithEvents aboutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
		Private toolStrip1 As System.Windows.Forms.ToolStrip
		Private WithEvents toolStripButtonExecute As System.Windows.Forms.ToolStripButton
      Private WithEvents toolStripButtonThumbnails As System.Windows.Forms.ToolStripButton
		Private splitter1 As System.Windows.Forms.Splitter
		Private richTextBoxLinqInfo As System.Windows.Forms.RichTextBox
		Private label4 As System.Windows.Forms.Label
		Private WithEvents toolStripButtonOpen As System.Windows.Forms.ToolStripButton
		Private toolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
  Friend WithEvents LinkLabelDownloadSampleDicomDir As System.Windows.Forms.LinkLabel
  Friend WithEvents DownloadSampleDICOMDIRToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
	End Class
End Namespace
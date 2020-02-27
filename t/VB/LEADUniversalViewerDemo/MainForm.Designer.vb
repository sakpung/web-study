Imports Leadtools.Controls
Imports System
Imports System.Drawing
Imports System.Windows.Forms
Imports Leadtools

Namespace VBLEADUniversalViewer
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
         Me.components = New System.ComponentModel.Container()
         Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainForm))
         Me.ControlsPanel = New System.Windows.Forms.Panel()
         Me.tableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel()
         Me.btnStop = New System.Windows.Forms.Button()
         Me.btnPause = New System.Windows.Forms.Button()
         Me.numericUpDown1 = New System.Windows.Forms.NumericUpDown()
         Me.btnPlay = New System.Windows.Forms.Button()
         Me.btnNext = New System.Windows.Forms.Button()
         Me.btnFwd = New System.Windows.Forms.Button()
         Me.btnRew = New System.Windows.Forms.Button()
         Me.btnPrev = New System.Windows.Forms.Button()
         Me.btnFullScreen = New System.Windows.Forms.Button()
         Me.tableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
         Me.lbltrkPosition = New System.Windows.Forms.Label()
         Me.trkPosition = New System.Windows.Forms.TrackBar()
         Me.imageViewer1 = New ImageViewer()
         Me.fileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me.playMoreFilesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me.toolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
         Me.exitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me.menuStrip1 = New System.Windows.Forms.MenuStrip()
         Me.recentToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me.optionsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me.loadAllPagesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me.supportLoadingTEXTFilesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me.toolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
         Me.playbackMediaFilesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me.toolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
         Me.changeloadingOrRasterizingResolutionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me.helpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me.aboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me.listBox1 = New System.Windows.Forms.ListBox()
         Me.tableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
         Me.PlayerPanel = New System.Windows.Forms.Panel()
         Me.toolTip1 = New System.Windows.Forms.ToolTip(Me.components)
         Me.ControlsPanel.SuspendLayout()
         Me.tableLayoutPanel3.SuspendLayout()
         CType(Me.numericUpDown1, System.ComponentModel.ISupportInitialize).BeginInit()
         Me.tableLayoutPanel2.SuspendLayout()
         CType(Me.trkPosition, System.ComponentModel.ISupportInitialize).BeginInit()
         Me.menuStrip1.SuspendLayout()
         Me.tableLayoutPanel1.SuspendLayout()
         Me.SuspendLayout()
         ' 
         ' ControlsPanel
         ' 
         Me.ControlsPanel.AutoScroll = True
         Me.ControlsPanel.AutoSize = True
         Me.ControlsPanel.BackColor = System.Drawing.Color.White
         Me.ControlsPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
         Me.ControlsPanel.Controls.Add(Me.tableLayoutPanel3)
         Me.ControlsPanel.Controls.Add(Me.tableLayoutPanel2)
         Me.ControlsPanel.Dock = System.Windows.Forms.DockStyle.Fill
         Me.ControlsPanel.Font = New System.Drawing.Font("Bookman Old Style", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (CByte(0)))
         Me.ControlsPanel.Location = New System.Drawing.Point(178, 850)
         Me.ControlsPanel.Name = "ControlsPanel"
         Me.ControlsPanel.Size = New System.Drawing.Size(1176, 68)
         Me.ControlsPanel.TabIndex = 1
         ' 
         ' tableLayoutPanel3
         ' 
         Me.tableLayoutPanel3.ColumnCount = 9
         Me.tableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111F))
         Me.tableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111F))
         Me.tableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111F))
         Me.tableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111F))
         Me.tableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111F))
         Me.tableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111F))
         Me.tableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111F))
         Me.tableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111F))
         Me.tableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111F))
         Me.tableLayoutPanel3.Controls.Add(Me.btnStop, 0, 0)
         Me.tableLayoutPanel3.Controls.Add(Me.btnPause, 1, 0)
         Me.tableLayoutPanel3.Controls.Add(Me.numericUpDown1, 6, 0)
         Me.tableLayoutPanel3.Controls.Add(Me.btnPlay, 2, 0)
         Me.tableLayoutPanel3.Controls.Add(Me.btnNext, 8, 0)
         Me.tableLayoutPanel3.Controls.Add(Me.btnFwd, 7, 0)
         Me.tableLayoutPanel3.Controls.Add(Me.btnRew, 5, 0)
         Me.tableLayoutPanel3.Controls.Add(Me.btnPrev, 4, 0)
         Me.tableLayoutPanel3.Controls.Add(Me.btnFullScreen, 3, 0)
         Me.tableLayoutPanel3.Font = New System.Drawing.Font("Bookman Old Style", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (CByte(0)))
         Me.tableLayoutPanel3.Location = New System.Drawing.Point(465, 26)
         Me.tableLayoutPanel3.Name = "tableLayoutPanel3"
         Me.tableLayoutPanel3.RowCount = 1
         Me.tableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0F))
         Me.tableLayoutPanel3.Size = New System.Drawing.Size(434, 36)
         Me.tableLayoutPanel3.TabIndex = 11
         ' 
         ' btnStop
         ' 
         Me.btnStop.BackgroundImage = Global.VBLEADUniversalViewer.My.Resources._Stop
         Me.btnStop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
         Me.btnStop.Dock = System.Windows.Forms.DockStyle.Fill
         Me.btnStop.FlatStyle = System.Windows.Forms.FlatStyle.Flat
         Me.btnStop.Location = New System.Drawing.Point(3, 3)
         Me.btnStop.Name = "btnStop"
         Me.btnStop.Size = New System.Drawing.Size(42, 30)
         Me.btnStop.TabIndex = 4
         Me.toolTip1.SetToolTip(Me.btnStop, "Stop")
         Me.btnStop.UseVisualStyleBackColor = True
         ' 
         ' btnPause
         ' 
         Me.btnPause.BackgroundImage = Global.VBLEADUniversalViewer.My.Resources.Pause
         Me.btnPause.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
         Me.btnPause.Dock = System.Windows.Forms.DockStyle.Fill
         Me.btnPause.FlatStyle = System.Windows.Forms.FlatStyle.Flat
         Me.btnPause.Location = New System.Drawing.Point(51, 3)
         Me.btnPause.Name = "btnPause"
         Me.btnPause.Size = New System.Drawing.Size(42, 30)
         Me.btnPause.TabIndex = 3
         Me.toolTip1.SetToolTip(Me.btnPause, "Pause")
         Me.btnPause.UseVisualStyleBackColor = True
         ' 
         ' numericUpDown1
         ' 
         Me.numericUpDown1.Dock = System.Windows.Forms.DockStyle.Bottom
         Me.numericUpDown1.Font = New System.Drawing.Font("Bookman Old Style", 12.0F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (CByte(0)))
         Me.numericUpDown1.ForeColor = System.Drawing.Color.RoyalBlue
         Me.numericUpDown1.Location = New System.Drawing.Point(290, 8)
         Me.numericUpDown1.Margin = New System.Windows.Forms.Padding(2)
         Me.numericUpDown1.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
         Me.numericUpDown1.Name = "numericUpDown1"
         Me.numericUpDown1.Size = New System.Drawing.Size(44, 26)
         Me.numericUpDown1.TabIndex = 7
         Me.toolTip1.SetToolTip(Me.numericUpDown1, "Current page number")
         Me.numericUpDown1.Value = New Decimal(New Integer() {1, 0, 0, 0})
         Me.numericUpDown1.Visible = False
         ' 
         ' btnPlay
         ' 
         Me.btnPlay.BackgroundImage = Global.VBLEADUniversalViewer.My.Resources.Play
         Me.btnPlay.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
         Me.btnPlay.Dock = System.Windows.Forms.DockStyle.Fill
         Me.btnPlay.FlatStyle = System.Windows.Forms.FlatStyle.Flat
         Me.btnPlay.Location = New System.Drawing.Point(99, 3)
         Me.btnPlay.Name = "btnPlay"
         Me.btnPlay.Size = New System.Drawing.Size(42, 30)
         Me.btnPlay.TabIndex = 2
         Me.toolTip1.SetToolTip(Me.btnPlay, "Play")
         Me.btnPlay.UseVisualStyleBackColor = True
         ' 
         ' btnNext
         ' 
         Me.btnNext.BackgroundImage = Global.VBLEADUniversalViewer.My.Resources._Next
         Me.btnNext.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
         Me.btnNext.Dock = System.Windows.Forms.DockStyle.Fill
         Me.btnNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat
         Me.btnNext.Location = New System.Drawing.Point(387, 3)
         Me.btnNext.Name = "btnNext"
         Me.btnNext.Size = New System.Drawing.Size(44, 30)
         Me.btnNext.TabIndex = 6
         Me.toolTip1.SetToolTip(Me.btnNext, "Next file in the list")
         Me.btnNext.UseVisualStyleBackColor = True
         ' 
         ' btnFwd
         ' 
         Me.btnFwd.BackColor = System.Drawing.Color.White
         Me.btnFwd.BackgroundImage = Global.VBLEADUniversalViewer.My.Resources.Fwd
         Me.btnFwd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
         Me.btnFwd.Dock = System.Windows.Forms.DockStyle.Fill
         Me.btnFwd.FlatStyle = System.Windows.Forms.FlatStyle.Flat
         Me.btnFwd.ForeColor = System.Drawing.Color.White
         Me.btnFwd.ImageIndex = 8
         Me.btnFwd.Location = New System.Drawing.Point(339, 3)
         Me.btnFwd.Name = "btnFwd"
         Me.btnFwd.Size = New System.Drawing.Size(42, 30)
         Me.btnFwd.TabIndex = 5
         Me.toolTip1.SetToolTip(Me.btnFwd, "Next")
         Me.btnFwd.UseVisualStyleBackColor = False
         ' 
         ' btnRew
         ' 
         Me.btnRew.BackgroundImage = Global.VBLEADUniversalViewer.My.Resources.Rew
         Me.btnRew.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
         Me.btnRew.Dock = System.Windows.Forms.DockStyle.Fill
         Me.btnRew.FlatStyle = System.Windows.Forms.FlatStyle.Flat
         Me.btnRew.Location = New System.Drawing.Point(243, 3)
         Me.btnRew.Name = "btnRew"
         Me.btnRew.Size = New System.Drawing.Size(42, 30)
         Me.btnRew.TabIndex = 1
         Me.toolTip1.SetToolTip(Me.btnRew, "Prev")
         Me.btnRew.UseVisualStyleBackColor = True
         ' 
         ' btnPrev
         ' 
         Me.btnPrev.BackgroundImage = Global.VBLEADUniversalViewer.My.Resources.Prev
         Me.btnPrev.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
         Me.btnPrev.Dock = System.Windows.Forms.DockStyle.Fill
         Me.btnPrev.FlatStyle = System.Windows.Forms.FlatStyle.Flat
         Me.btnPrev.Location = New System.Drawing.Point(195, 3)
         Me.btnPrev.Name = "btnPrev"
         Me.btnPrev.Size = New System.Drawing.Size(42, 30)
         Me.btnPrev.TabIndex = 0
         Me.toolTip1.SetToolTip(Me.btnPrev, "Prev file in the list")
         Me.btnPrev.UseVisualStyleBackColor = True
         ' 
         ' btnFullScreen
         ' 
         Me.btnFullScreen.BackgroundImage = Global.VBLEADUniversalViewer.My.Resources.Fullscreen64
         Me.btnFullScreen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
         Me.btnFullScreen.Dock = System.Windows.Forms.DockStyle.Fill
         Me.btnFullScreen.FlatStyle = System.Windows.Forms.FlatStyle.Flat
         Me.btnFullScreen.Location = New System.Drawing.Point(147, 3)
         Me.btnFullScreen.Name = "btnFullScreen"
         Me.btnFullScreen.Size = New System.Drawing.Size(42, 30)
         Me.btnFullScreen.TabIndex = 8
         Me.toolTip1.SetToolTip(Me.btnFullScreen, "Full Screen")
         Me.btnFullScreen.UseVisualStyleBackColor = True
         ' 
         ' tableLayoutPanel2
         ' 
         Me.tableLayoutPanel2.ColumnCount = 2
         Me.tableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60.0F))
         Me.tableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40.0F))
         Me.tableLayoutPanel2.Controls.Add(Me.lbltrkPosition, 1, 0)
         Me.tableLayoutPanel2.Controls.Add(Me.trkPosition, 0, 0)
         Me.tableLayoutPanel2.Font = New System.Drawing.Font("Bookman Old Style", 12.0F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (CByte(0)))
         Me.tableLayoutPanel2.Location = New System.Drawing.Point(464, 0)
         Me.tableLayoutPanel2.Margin = New System.Windows.Forms.Padding(2)
         Me.tableLayoutPanel2.Name = "tableLayoutPanel2"
         Me.tableLayoutPanel2.RowCount = 1
         Me.tableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0F))
         Me.tableLayoutPanel2.Size = New System.Drawing.Size(701, 22)
         Me.tableLayoutPanel2.TabIndex = 10
         ' 
         ' lbltrkPosition
         ' 
         Me.lbltrkPosition.AutoSize = True
         Me.lbltrkPosition.Dock = System.Windows.Forms.DockStyle.Bottom
         Me.lbltrkPosition.Font = New System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (CByte(0)))
         Me.lbltrkPosition.ForeColor = System.Drawing.Color.RoyalBlue
         Me.lbltrkPosition.Location = New System.Drawing.Point(422, 5)
         Me.lbltrkPosition.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
         Me.lbltrkPosition.Name = "lbltrkPosition"
         Me.lbltrkPosition.Size = New System.Drawing.Size(277, 17)
         Me.lbltrkPosition.TabIndex = 8
         Me.lbltrkPosition.Text = "----"
         ' 
         ' trkPosition
         ' 
         Me.trkPosition.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
         Me.trkPosition.AutoSize = False
         Me.trkPosition.BackColor = System.Drawing.SystemColors.Control
         Me.trkPosition.LargeChange = 500
         Me.trkPosition.Location = New System.Drawing.Point(2, 2)
         Me.trkPosition.Margin = New System.Windows.Forms.Padding(2)
         Me.trkPosition.Maximum = 10000
         Me.trkPosition.Name = "trkPosition"
         Me.trkPosition.Size = New System.Drawing.Size(416, 15)
         Me.trkPosition.TabIndex = 5
         Me.trkPosition.TickFrequency = 400
         Me.trkPosition.TickStyle = System.Windows.Forms.TickStyle.None
         ' 
         ' imageViewer1
         ' 
         Me.imageViewer1.BackColor = System.Drawing.Color.White
         Me.imageViewer1.Dock = System.Windows.Forms.DockStyle.Fill
         Me.imageViewer1.ItemSize = (CType(resources.GetObject("imageViewer1.ItemSize"), LeadSize))
         Me.imageViewer1.ItemSpacing = (CType(resources.GetObject("imageViewer1.ItemSpacing"), LeadSize))
         Me.imageViewer1.Location = New System.Drawing.Point(0, 0)
         Me.imageViewer1.Name = "imageViewer1"
         Me.imageViewer1.Size = New System.Drawing.Size(1046, 713)
         Me.imageViewer1.TabIndex = 0
         Me.imageViewer1.ViewHorizontalAlignment = ControlAlignment.Center
         Me.imageViewer1.ViewVerticalAlignment = ControlAlignment.Center
         ' 
         ' fileToolStripMenuItem
         ' 
         Me.fileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.playMoreFilesToolStripMenuItem, Me.toolStripSeparator2, Me.exitToolStripMenuItem})
         Me.fileToolStripMenuItem.Font = New System.Drawing.Font("Segoe UI", 9.0F)
         Me.fileToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlText
         Me.fileToolStripMenuItem.Name = "fileToolStripMenuItem"
         Me.fileToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
         Me.fileToolStripMenuItem.Text = "&File"
         ' 
         ' playMoreFilesToolStripMenuItem
         ' 
         Me.playMoreFilesToolStripMenuItem.Name = "playMoreFilesToolStripMenuItem"
         Me.playMoreFilesToolStripMenuItem.Size = New System.Drawing.Size(247, 22)
         Me.playMoreFilesToolStripMenuItem.Text = "&Browse Images and Media Files..."
         ' 
         ' toolStripSeparator2
         ' 
         Me.toolStripSeparator2.Name = "toolStripSeparator2"
         Me.toolStripSeparator2.Size = New System.Drawing.Size(244, 6)
         ' 
         ' exitToolStripMenuItem
         ' 
         Me.exitToolStripMenuItem.Name = "exitToolStripMenuItem"
         Me.exitToolStripMenuItem.Size = New System.Drawing.Size(247, 22)
         Me.exitToolStripMenuItem.Text = "E&xit"
         ' 
         ' menuStrip1
         ' 
         Me.menuStrip1.BackColor = System.Drawing.SystemColors.Menu
         Me.menuStrip1.Font = New System.Drawing.Font("Segoe UI", 9.0F)
         Me.menuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.fileToolStripMenuItem, Me.recentToolStripMenuItem, Me.optionsToolStripMenuItem, Me.helpToolStripMenuItem})
         Me.menuStrip1.Location = New System.Drawing.Point(0, 0)
         Me.menuStrip1.Name = "menuStrip1"
         Me.menuStrip1.Padding = New System.Windows.Forms.Padding(7, 2, 0, 2)
         Me.menuStrip1.Size = New System.Drawing.Size(1357, 24)
         Me.menuStrip1.TabIndex = 0
         Me.menuStrip1.Text = "menuStrip1"
         ' 
         ' recentToolStripMenuItem
         ' 
         Me.recentToolStripMenuItem.BackColor = System.Drawing.SystemColors.Control
         Me.recentToolStripMenuItem.ForeColor = System.Drawing.Color.Black
         Me.recentToolStripMenuItem.Name = "recentToolStripMenuItem"
         Me.recentToolStripMenuItem.Size = New System.Drawing.Size(91, 20)
         Me.recentToolStripMenuItem.Text = "Recent Places"
         ' 
         ' optionsToolStripMenuItem
         ' 
         Me.optionsToolStripMenuItem.BackColor = System.Drawing.SystemColors.Control
         Me.optionsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.loadAllPagesToolStripMenuItem, Me.supportLoadingTEXTFilesToolStripMenuItem, Me.toolStripSeparator1, Me.playbackMediaFilesToolStripMenuItem, Me.toolStripSeparator3, Me.changeloadingOrRasterizingResolutionToolStripMenuItem})
         Me.optionsToolStripMenuItem.ForeColor = System.Drawing.Color.Black
         Me.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem"
         Me.optionsToolStripMenuItem.Size = New System.Drawing.Size(61, 20)
         Me.optionsToolStripMenuItem.Text = "&Options"
         ' 
         ' loadAllPagesToolStripMenuItem
         ' 
         Me.loadAllPagesToolStripMenuItem.Name = "loadAllPagesToolStripMenuItem"
         Me.loadAllPagesToolStripMenuItem.Size = New System.Drawing.Size(229, 22)
         Me.loadAllPagesToolStripMenuItem.Text = "Support Loading &All Pages"
         ' 
         ' supportLoadingTEXTFilesToolStripMenuItem
         ' 
         Me.supportLoadingTEXTFilesToolStripMenuItem.Name = "supportLoadingTEXTFilesToolStripMenuItem"
         Me.supportLoadingTEXTFilesToolStripMenuItem.Size = New System.Drawing.Size(229, 22)
         Me.supportLoadingTEXTFilesToolStripMenuItem.Text = "Support Loading &TEXT files"
         ' 
         ' toolStripSeparator1
         ' 
         Me.toolStripSeparator1.Name = "toolStripSeparator1"
         Me.toolStripSeparator1.Size = New System.Drawing.Size(226, 6)
         ' 
         ' playbackMediaFilesToolStripMenuItem
         ' 
         Me.playbackMediaFilesToolStripMenuItem.Checked = True
         Me.playbackMediaFilesToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked
         Me.playbackMediaFilesToolStripMenuItem.Name = "playbackMediaFilesToolStripMenuItem"
         Me.playbackMediaFilesToolStripMenuItem.Size = New System.Drawing.Size(229, 22)
         Me.playbackMediaFilesToolStripMenuItem.Text = "Auto &Play Media Files"
         ' 
         ' toolStripSeparator3
         ' 
         Me.toolStripSeparator3.Name = "toolStripSeparator3"
         Me.toolStripSeparator3.Size = New System.Drawing.Size(226, 6)
         ' 
         ' changeloadingOrRasterizingResolutionToolStripMenuItem
         ' 
         Me.changeloadingOrRasterizingResolutionToolStripMenuItem.Name = "changeloadingOrRasterizingResolutionToolStripMenuItem"
         Me.changeloadingOrRasterizingResolutionToolStripMenuItem.Size = New System.Drawing.Size(229, 22)
         Me.changeloadingOrRasterizingResolutionToolStripMenuItem.Text = "Change &Loading Resolution..."
         ' 
         ' helpToolStripMenuItem
         ' 
         Me.helpToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.aboutToolStripMenuItem})
         Me.helpToolStripMenuItem.ForeColor = System.Drawing.Color.Black
         Me.helpToolStripMenuItem.Name = "helpToolStripMenuItem"
         Me.helpToolStripMenuItem.Size = New System.Drawing.Size(44, 20)
         Me.helpToolStripMenuItem.Text = "Help"
         ' 
         ' aboutToolStripMenuItem
         ' 
         Me.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem"
         Me.aboutToolStripMenuItem.Size = New System.Drawing.Size(116, 22)
         Me.aboutToolStripMenuItem.Text = "&About..."
         ' 
         ' listBox1
         ' 
         Me.listBox1.BorderStyle = System.Windows.Forms.BorderStyle.None
         Me.listBox1.Dock = System.Windows.Forms.DockStyle.Fill
         Me.listBox1.Font = New System.Drawing.Font("Segoe UI", 9.0F)
         Me.listBox1.FormattingEnabled = True
         Me.listBox1.HorizontalScrollbar = True
         Me.listBox1.ItemHeight = 15
         Me.listBox1.Location = New System.Drawing.Point(2, 2)
         Me.listBox1.Margin = New System.Windows.Forms.Padding(2, 2, 2, 0)
         Me.listBox1.Name = "listBox1"
         Me.listBox1.ScrollAlwaysVisible = True
         Me.listBox1.Size = New System.Drawing.Size(171, 845)
         Me.listBox1.TabIndex = 0
         ' 
         ' tableLayoutPanel1
         ' 
         Me.tableLayoutPanel1.ColumnCount = 2
         Me.tableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 175.0F))
         Me.tableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0F))
         Me.tableLayoutPanel1.Controls.Add(Me.listBox1, 0, 0)
         Me.tableLayoutPanel1.Controls.Add(Me.ControlsPanel, 1, 1)
         Me.tableLayoutPanel1.Controls.Add(Me.PlayerPanel, 1, 0)
         Me.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
         Me.tableLayoutPanel1.Location = New System.Drawing.Point(0, 24)
         Me.tableLayoutPanel1.Margin = New System.Windows.Forms.Padding(2)
         Me.tableLayoutPanel1.Name = "tableLayoutPanel1"
         Me.tableLayoutPanel1.RowCount = 2
         Me.tableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 92.0F))
         Me.tableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.0F))
         Me.tableLayoutPanel1.Size = New System.Drawing.Size(1357, 921)
         Me.tableLayoutPanel1.TabIndex = 4
         ' 
         ' PlayerPanel
         ' 
         Me.PlayerPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
         Me.PlayerPanel.BackColor = System.Drawing.Color.Black
         Me.PlayerPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
         Me.PlayerPanel.Dock = System.Windows.Forms.DockStyle.Fill
         Me.PlayerPanel.Location = New System.Drawing.Point(178, 3)
         Me.PlayerPanel.Name = "PlayerPanel"
         Me.PlayerPanel.Size = New System.Drawing.Size(1176, 841)
         Me.PlayerPanel.TabIndex = 2
         ' 
         ' MainForm
         ' 
         Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0F, 15.0F)
         Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
         Me.BackColor = System.Drawing.Color.White
         Me.ClientSize = New System.Drawing.Size(1357, 945)
         Me.Controls.Add(Me.tableLayoutPanel1)
         Me.Controls.Add(Me.menuStrip1)
         Me.Font = New System.Drawing.Font("Segoe UI", 9.0F)
         Me.ForeColor = System.Drawing.Color.White
         Me.Icon = (CType(resources.GetObject("$this.Icon"), System.Drawing.Icon))
         Me.MainMenuStrip = Me.menuStrip1
         Me.Name = "MainForm"
         Me.Text = "LEADTOOLS VB Universal Viewer Demo"
         Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
         Me.ControlsPanel.ResumeLayout(False)
         Me.tableLayoutPanel3.ResumeLayout(False)
         CType(Me.numericUpDown1, System.ComponentModel.ISupportInitialize).EndInit()
         Me.tableLayoutPanel2.ResumeLayout(False)
         Me.tableLayoutPanel2.PerformLayout()
         CType(Me.trkPosition, System.ComponentModel.ISupportInitialize).EndInit()
         Me.menuStrip1.ResumeLayout(False)
         Me.menuStrip1.PerformLayout()
         Me.tableLayoutPanel1.ResumeLayout(False)
         Me.tableLayoutPanel1.PerformLayout()
         Me.ResumeLayout(False)
         Me.PerformLayout()

      End Sub

#End Region

      Private ControlsPanel As System.Windows.Forms.Panel
      Private WithEvents btnStop As System.Windows.Forms.Button
      Private WithEvents btnPause As System.Windows.Forms.Button
      Private WithEvents btnPlay As System.Windows.Forms.Button
      Private WithEvents btnRew As System.Windows.Forms.Button
      Private WithEvents btnPrev As System.Windows.Forms.Button
      Private WithEvents btnNext As System.Windows.Forms.Button
      Private WithEvents btnFwd As System.Windows.Forms.Button
      Private fileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents playMoreFilesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private menuStrip1 As System.Windows.Forms.MenuStrip
      Private WithEvents imageViewer1 As ImageViewer
      Private WithEvents numericUpDown1 As NumericUpDown
      Private WithEvents listBox1 As ListBox
      Private tableLayoutPanel1 As TableLayoutPanel
      Private PlayerPanel As Panel
      Private toolTip1 As ToolTip
      Private optionsToolStripMenuItem As ToolStripMenuItem
      Private WithEvents loadAllPagesToolStripMenuItem As ToolStripMenuItem
      Private WithEvents playbackMediaFilesToolStripMenuItem As ToolStripMenuItem
      Private WithEvents trkPosition As TrackBar
      Private lbltrkPosition As Label
      Private tableLayoutPanel2 As TableLayoutPanel
      Private recentToolStripMenuItem As ToolStripMenuItem
      Private toolStripSeparator2 As ToolStripSeparator
      Private WithEvents exitToolStripMenuItem As ToolStripMenuItem
      Private toolStripSeparator1 As ToolStripSeparator
      Private tableLayoutPanel3 As TableLayoutPanel
      Private toolStripSeparator3 As ToolStripSeparator
      Private WithEvents changeloadingOrRasterizingResolutionToolStripMenuItem As ToolStripMenuItem
      Private helpToolStripMenuItem As ToolStripMenuItem
      Private WithEvents aboutToolStripMenuItem As ToolStripMenuItem
      Private WithEvents btnFullScreen As Button
      Private WithEvents supportLoadingTEXTFilesToolStripMenuItem As ToolStripMenuItem
   End Class
End Namespace

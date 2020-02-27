Partial Class ResultsPanel
   Private components As System.ComponentModel.IContainer = Nothing

   Protected Overrides Sub Dispose(ByVal disposing As Boolean)
      If disposing AndAlso (components IsNot Nothing) Then
         components.Dispose()
      End If

      MyBase.Dispose(disposing)
   End Sub

   Private Sub InitializeComponent()
      Me.BottomToolStripPanel = New System.Windows.Forms.ToolStripPanel()
      Me.TopToolStripPanel = New System.Windows.Forms.ToolStripPanel()
      Me.miniToolStrip = New System.Windows.Forms.ToolStrip()
      Me.menuStrip2 = New System.Windows.Forms.MenuStrip()
      Me.fileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
      Me.saveWorkspaceToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
      Me.saveWorkspaceAsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
      Me.openToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
      Me.toolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
      Me.exportCSVToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
      Me.exportStatsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
      Me.toolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
      Me.closeWorkspaceToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
      Me.exitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
      Me.viewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
      Me.searchToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
      Me.colorsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
      Me.changeActiveFiltersToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
      Me.toolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
      Me.showResultPanelToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
      Me.showStatisticsPanelToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
      Me.swapStatisticsRowsAndColumnsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
      Me.gradingToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
      Me.processReportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
      Me.gradeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
      Me.toolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
      Me.verifyAnswersToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
      Me.reviewWorksheetsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
      Me.changeIdentifierToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
      Me.helpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
      Me.aboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
      Me.RightToolStripPanel = New System.Windows.Forms.ToolStripPanel()
      Me.LeftToolStripPanel = New System.Windows.Forms.ToolStripPanel()
      Me.ContentPanel = New System.Windows.Forms.ToolStripContentPanel()
      Me.spltResults = New System.Windows.Forms.SplitContainer()
      Me.dgvResults = New DataGridViewDoubleBuffered()
      Me.dgvStats = New DataGridViewDoubleBuffered()
      Me.lblStats = New System.Windows.Forms.Label()
      Me.toolStripContainer1 = New System.Windows.Forms.ToolStripContainer()
      Me.tsButtonBar = New System.Windows.Forms.ToolStrip()
      Me.tssUpdateItems = New System.Windows.Forms.ToolStripButton()
      Me.lockToolStripMenuItem = New System.Windows.Forms.ToolStripButton()
      Me.toolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
      Me.tssToggleColorLegend = New System.Windows.Forms.ToolStripButton()
      Me.toolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
      Me.tssSearch = New System.Windows.Forms.ToolStripButton()
      Me.menuStrip2.SuspendLayout()
      CType(Me.spltResults, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.spltResults.Panel1.SuspendLayout()
      Me.spltResults.Panel2.SuspendLayout()
      Me.spltResults.SuspendLayout()
      CType(Me.dgvResults, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.dgvStats, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.toolStripContainer1.ContentPanel.SuspendLayout()
      Me.toolStripContainer1.TopToolStripPanel.SuspendLayout()
      Me.toolStripContainer1.SuspendLayout()
      Me.tsButtonBar.SuspendLayout()
      Me.SuspendLayout()
      Me.BottomToolStripPanel.Location = New System.Drawing.Point(0, 0)
      Me.BottomToolStripPanel.Name = "BottomToolStripPanel"
      Me.BottomToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal
      Me.BottomToolStripPanel.RowMargin = New System.Windows.Forms.Padding(3, 0, 0, 0)
      Me.BottomToolStripPanel.Size = New System.Drawing.Size(0, 0)
      Me.TopToolStripPanel.Location = New System.Drawing.Point(0, 0)
      Me.TopToolStripPanel.Name = "TopToolStripPanel"
      Me.TopToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal
      Me.TopToolStripPanel.RowMargin = New System.Windows.Forms.Padding(3, 0, 0, 0)
      Me.TopToolStripPanel.Size = New System.Drawing.Size(0, 0)
      Me.miniToolStrip.AccessibleName = "New item selection"
      Me.miniToolStrip.AccessibleRole = System.Windows.Forms.AccessibleRole.ButtonDropDown
      Me.miniToolStrip.AutoSize = False
      Me.miniToolStrip.CanOverflow = False
      Me.miniToolStrip.Dock = System.Windows.Forms.DockStyle.None
      Me.miniToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
      Me.miniToolStrip.Location = New System.Drawing.Point(9, 3)
      Me.miniToolStrip.Name = "miniToolStrip"
      Me.miniToolStrip.Size = New System.Drawing.Size(111, 25)
      Me.miniToolStrip.TabIndex = 4
      Me.menuStrip2.Dock = System.Windows.Forms.DockStyle.None
      Me.menuStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.fileToolStripMenuItem, Me.viewToolStripMenuItem, Me.gradingToolStripMenuItem, Me.helpToolStripMenuItem})
      Me.menuStrip2.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow
      Me.menuStrip2.Location = New System.Drawing.Point(3, 27)
      Me.menuStrip2.Name = "menuStrip2"
      Me.menuStrip2.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
      Me.menuStrip2.Size = New System.Drawing.Size(309, 24)
      Me.menuStrip2.Stretch = False
      Me.menuStrip2.TabIndex = 1
      Me.menuStrip2.Text = "menuStrip2"
      Me.fileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.saveWorkspaceToolStripMenuItem, Me.saveWorkspaceAsToolStripMenuItem, Me.openToolStripMenuItem, Me.toolStripSeparator1, Me.exportCSVToolStripMenuItem, Me.exportStatsToolStripMenuItem, Me.toolStripSeparator4, Me.closeWorkspaceToolStripMenuItem, Me.exitToolStripMenuItem})
      Me.fileToolStripMenuItem.Name = "fileToolStripMenuItem"
      Me.fileToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
      Me.fileToolStripMenuItem.Text = "&File"
      Me.saveWorkspaceToolStripMenuItem.Enabled = False
      Me.saveWorkspaceToolStripMenuItem.Name = "saveWorkspaceToolStripMenuItem"
      Me.saveWorkspaceToolStripMenuItem.Size = New System.Drawing.Size(184, 22)
      Me.saveWorkspaceToolStripMenuItem.Text = "&Save Workspace..."
      AddHandler Me.saveWorkspaceToolStripMenuItem.Click, AddressOf Me.saveWorkspaceToolStripMenuItem_Click
      Me.saveWorkspaceAsToolStripMenuItem.Enabled = False
      Me.saveWorkspaceAsToolStripMenuItem.Name = "saveWorkspaceAsToolStripMenuItem"
      Me.saveWorkspaceAsToolStripMenuItem.Size = New System.Drawing.Size(184, 22)
      Me.saveWorkspaceAsToolStripMenuItem.Text = "Save Workspace &As..."
      AddHandler Me.saveWorkspaceAsToolStripMenuItem.Click, AddressOf Me.saveWorkspaceAsToolStripMenuItem_Click
      Me.openToolStripMenuItem.Name = "openToolStripMenuItem"
      Me.openToolStripMenuItem.Size = New System.Drawing.Size(184, 22)
      Me.openToolStripMenuItem.Text = "&Open Workspace..."
      AddHandler Me.openToolStripMenuItem.Click, AddressOf Me.openToolStripMenuItem_Click
      Me.toolStripSeparator1.Name = "toolStripSeparator1"
      Me.toolStripSeparator1.Size = New System.Drawing.Size(181, 6)
      Me.exportCSVToolStripMenuItem.Enabled = False
      Me.exportCSVToolStripMenuItem.Name = "exportCSVToolStripMenuItem"
      Me.exportCSVToolStripMenuItem.Size = New System.Drawing.Size(184, 22)
      Me.exportCSVToolStripMenuItem.Text = "&Export Results..."
      AddHandler Me.exportCSVToolStripMenuItem.Click, AddressOf Me.exportResultsToolStripMenuItem_Click
      Me.exportStatsToolStripMenuItem.Enabled = False
      Me.exportStatsToolStripMenuItem.Name = "exportStatsToolStripMenuItem"
      Me.exportStatsToolStripMenuItem.Size = New System.Drawing.Size(184, 22)
      Me.exportStatsToolStripMenuItem.Text = "Export Statistics..."
      AddHandler Me.exportStatsToolStripMenuItem.Click, AddressOf Me.exportStatsToolStripMenuItem_Click
      Me.toolStripSeparator4.Name = "toolStripSeparator4"
      Me.toolStripSeparator4.Size = New System.Drawing.Size(181, 6)
      Me.closeWorkspaceToolStripMenuItem.Enabled = False
      Me.closeWorkspaceToolStripMenuItem.Name = "closeWorkspaceToolStripMenuItem"
      Me.closeWorkspaceToolStripMenuItem.Size = New System.Drawing.Size(184, 22)
      Me.closeWorkspaceToolStripMenuItem.Text = "&Close Workspace"
      AddHandler Me.closeWorkspaceToolStripMenuItem.Click, AddressOf Me.closeWorkspaceToolStripMenuItem_Click
      Me.exitToolStripMenuItem.Name = "exitToolStripMenuItem"
      Me.exitToolStripMenuItem.Size = New System.Drawing.Size(184, 22)
      Me.exitToolStripMenuItem.Text = "E&xit"
      AddHandler Me.exitToolStripMenuItem.Click, AddressOf Me.exitToolStripMenuItem_Click
      Me.viewToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.searchToolStripMenuItem, Me.colorsToolStripMenuItem, Me.changeActiveFiltersToolStripMenuItem, Me.toolStripSeparator3, Me.showResultPanelToolStripMenuItem, Me.showStatisticsPanelToolStripMenuItem, Me.swapStatisticsRowsAndColumnsToolStripMenuItem})
      Me.viewToolStripMenuItem.Name = "viewToolStripMenuItem"
      Me.viewToolStripMenuItem.Size = New System.Drawing.Size(44, 20)
      Me.viewToolStripMenuItem.Text = "&View"
      Me.searchToolStripMenuItem.Enabled = False
      Me.searchToolStripMenuItem.Image = Resources.search
      Me.searchToolStripMenuItem.Name = "searchToolStripMenuItem"
      Me.searchToolStripMenuItem.ShortcutKeys = (CType(((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.F)), System.Windows.Forms.Keys))
      Me.searchToolStripMenuItem.Size = New System.Drawing.Size(256, 22)
      Me.searchToolStripMenuItem.Text = "&Search..."
      AddHandler Me.searchToolStripMenuItem.Click, AddressOf Me.searchToolStripMenuItem_Click
      Me.colorsToolStripMenuItem.Enabled = False
      Me.colorsToolStripMenuItem.Image = Resources.colors
      Me.colorsToolStripMenuItem.Name = "colorsToolStripMenuItem"
      Me.colorsToolStripMenuItem.Size = New System.Drawing.Size(256, 22)
      Me.colorsToolStripMenuItem.Text = "&Color Code..."
      AddHandler Me.colorsToolStripMenuItem.Click, AddressOf Me.colorsToolStripMenuItem_Click
      Me.changeActiveFiltersToolStripMenuItem.Enabled = False
      Me.changeActiveFiltersToolStripMenuItem.Name = "changeActiveFiltersToolStripMenuItem"
      Me.changeActiveFiltersToolStripMenuItem.Size = New System.Drawing.Size(256, 22)
      Me.changeActiveFiltersToolStripMenuItem.Text = "S&et ""Needs Review"" Criteria..."
      AddHandler Me.changeActiveFiltersToolStripMenuItem.Click, AddressOf Me.changeActiveFiltersToolStripMenuItem_Click
      Me.toolStripSeparator3.Name = "toolStripSeparator3"
      Me.toolStripSeparator3.Size = New System.Drawing.Size(253, 6)
      Me.showResultPanelToolStripMenuItem.Checked = True
      Me.showResultPanelToolStripMenuItem.CheckOnClick = True
      Me.showResultPanelToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked
      Me.showResultPanelToolStripMenuItem.Name = "showResultPanelToolStripMenuItem"
      Me.showResultPanelToolStripMenuItem.ShortcutKeys = (CType(((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.R)), System.Windows.Forms.Keys))
      Me.showResultPanelToolStripMenuItem.Size = New System.Drawing.Size(256, 22)
      Me.showResultPanelToolStripMenuItem.Text = "Show &Result Panel"
      AddHandler Me.showResultPanelToolStripMenuItem.Click, AddressOf Me.showResultPanelToolStripMenuItem_Click
      Me.showStatisticsPanelToolStripMenuItem.Checked = True
      Me.showStatisticsPanelToolStripMenuItem.CheckOnClick = True
      Me.showStatisticsPanelToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked
      Me.showStatisticsPanelToolStripMenuItem.Name = "showStatisticsPanelToolStripMenuItem"
      Me.showStatisticsPanelToolStripMenuItem.ShortcutKeys = (CType(((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.T)), System.Windows.Forms.Keys))
      Me.showStatisticsPanelToolStripMenuItem.Size = New System.Drawing.Size(256, 22)
      Me.showStatisticsPanelToolStripMenuItem.Text = "Show S&tatistics Panel"
      AddHandler Me.showStatisticsPanelToolStripMenuItem.Click, AddressOf Me.showStatisticsPanelToolStripMenuItem_Click
      Me.swapStatisticsRowsAndColumnsToolStripMenuItem.CheckOnClick = True
      Me.swapStatisticsRowsAndColumnsToolStripMenuItem.Enabled = False
      Me.swapStatisticsRowsAndColumnsToolStripMenuItem.Name = "swapStatisticsRowsAndColumnsToolStripMenuItem"
      Me.swapStatisticsRowsAndColumnsToolStripMenuItem.Size = New System.Drawing.Size(256, 22)
      Me.swapStatisticsRowsAndColumnsToolStripMenuItem.Text = "S&wap Statistics Rows and Columns"
      AddHandler Me.swapStatisticsRowsAndColumnsToolStripMenuItem.Click, AddressOf Me.swapStatisticsRowsAndColumnsToolStripMenuItem_Click
      Me.gradingToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.processReportToolStripMenuItem, Me.gradeToolStripMenuItem, Me.toolStripSeparator2, Me.verifyAnswersToolStripMenuItem, Me.reviewWorksheetsToolStripMenuItem, Me.changeIdentifierToolStripMenuItem})
      Me.gradingToolStripMenuItem.Enabled = False
      Me.gradingToolStripMenuItem.Name = "gradingToolStripMenuItem"
      Me.gradingToolStripMenuItem.Size = New System.Drawing.Size(56, 20)
      Me.gradingToolStripMenuItem.Text = "&Review"
      Me.processReportToolStripMenuItem.Name = "processReportToolStripMenuItem"
      Me.processReportToolStripMenuItem.Size = New System.Drawing.Size(184, 22)
      Me.processReportToolStripMenuItem.Text = "&Process Report..."
      AddHandler Me.processReportToolStripMenuItem.Click, AddressOf Me.processReportToolStripMenuItem_Click
      Me.gradeToolStripMenuItem.Name = "gradeToolStripMenuItem"
      Me.gradeToolStripMenuItem.Size = New System.Drawing.Size(184, 22)
      Me.gradeToolStripMenuItem.Text = "&Change Answer Key"
      AddHandler Me.gradeToolStripMenuItem.Click, AddressOf Me.changeKeyToolStripMenuItem_Click
      Me.toolStripSeparator2.Name = "toolStripSeparator2"
      Me.toolStripSeparator2.Size = New System.Drawing.Size(181, 6)
      Me.verifyAnswersToolStripMenuItem.Name = "verifyAnswersToolStripMenuItem"
      Me.verifyAnswersToolStripMenuItem.Size = New System.Drawing.Size(184, 22)
      Me.verifyAnswersToolStripMenuItem.Text = "Review &Answer Key..."
      AddHandler Me.verifyAnswersToolStripMenuItem.Click, AddressOf Me.verifyAnswersToolStripMenuItem_Click
      Me.reviewWorksheetsToolStripMenuItem.Name = "reviewWorksheetsToolStripMenuItem"
      Me.reviewWorksheetsToolStripMenuItem.Size = New System.Drawing.Size(184, 22)
      Me.reviewWorksheetsToolStripMenuItem.Text = "&Review Worksheets..."
      AddHandler Me.reviewWorksheetsToolStripMenuItem.Click, AddressOf Me.reviewWorksheetsToolStripMenuItem_Click
      Me.changeIdentifierToolStripMenuItem.Name = "changeIdentifierToolStripMenuItem"
      Me.changeIdentifierToolStripMenuItem.Size = New System.Drawing.Size(184, 22)
      Me.changeIdentifierToolStripMenuItem.Text = "Change &Identifier..."
      AddHandler Me.changeIdentifierToolStripMenuItem.Click, AddressOf Me.changeIdentifierToolStripMenuItem_Click
      Me.helpToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.aboutToolStripMenuItem})
      Me.helpToolStripMenuItem.Name = "helpToolStripMenuItem"
      Me.helpToolStripMenuItem.Size = New System.Drawing.Size(44, 20)
      Me.helpToolStripMenuItem.Text = "&Help"
      Me.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem"
      Me.aboutToolStripMenuItem.Size = New System.Drawing.Size(107, 22)
      Me.aboutToolStripMenuItem.Text = "&About"
      AddHandler Me.aboutToolStripMenuItem.Click, AddressOf Me.aboutToolStripMenuItem_Click
      Me.RightToolStripPanel.Location = New System.Drawing.Point(0, 0)
      Me.RightToolStripPanel.Name = "RightToolStripPanel"
      Me.RightToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal
      Me.RightToolStripPanel.RowMargin = New System.Windows.Forms.Padding(3, 0, 0, 0)
      Me.RightToolStripPanel.Size = New System.Drawing.Size(0, 0)
      Me.LeftToolStripPanel.Location = New System.Drawing.Point(0, 0)
      Me.LeftToolStripPanel.Name = "LeftToolStripPanel"
      Me.LeftToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal
      Me.LeftToolStripPanel.RowMargin = New System.Windows.Forms.Padding(3, 0, 0, 0)
      Me.LeftToolStripPanel.Size = New System.Drawing.Size(0, 0)
      Me.ContentPanel.AutoScroll = True
      Me.ContentPanel.Size = New System.Drawing.Size(371, 195)
      Me.spltResults.Dock = System.Windows.Forms.DockStyle.Fill
      Me.spltResults.Location = New System.Drawing.Point(0, 0)
      Me.spltResults.Name = "spltResults"
      Me.spltResults.Orientation = System.Windows.Forms.Orientation.Horizontal
      Me.spltResults.Panel1.Controls.Add(Me.dgvResults)
      Me.spltResults.Panel2.Controls.Add(Me.dgvStats)
      Me.spltResults.Panel2.Controls.Add(Me.lblStats)
      Me.spltResults.Size = New System.Drawing.Size(753, 221)
      Me.spltResults.SplitterDistance = 89
      Me.spltResults.TabIndex = 3
      Me.dgvResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
      Me.dgvResults.Dock = System.Windows.Forms.DockStyle.Fill
      Me.dgvResults.Location = New System.Drawing.Point(0, 0)
      Me.dgvResults.Name = "dgvResults"
      Me.dgvResults.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders
      Me.dgvResults.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
      Me.dgvResults.Size = New System.Drawing.Size(753, 89)
      Me.dgvResults.TabIndex = 2
      AddHandler Me.dgvResults.CellPainting, AddressOf Me.dgvResults_CellPainting
      AddHandler Me.dgvResults.MouseDown, AddressOf Me.dgv_MouseDown
      Me.dgvStats.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
      Me.dgvStats.Dock = System.Windows.Forms.DockStyle.Fill
      Me.dgvStats.Location = New System.Drawing.Point(0, 13)
      Me.dgvStats.Name = "dgvStats"
      Me.dgvStats.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders
      Me.dgvStats.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
      Me.dgvStats.Size = New System.Drawing.Size(753, 115)
      Me.dgvStats.TabIndex = 0
      AddHandler Me.dgvStats.MouseDown, AddressOf Me.dgv_MouseDown
      Me.lblStats.Dock = System.Windows.Forms.DockStyle.Top
      Me.lblStats.Location = New System.Drawing.Point(0, 0)
      Me.lblStats.Name = "lblStats"
      Me.lblStats.Size = New System.Drawing.Size(753, 13)
      Me.lblStats.TabIndex = 1
      Me.lblStats.Text = "Statistics"
      Me.toolStripContainer1.ContentPanel.Controls.Add(Me.spltResults)
      Me.toolStripContainer1.ContentPanel.Size = New System.Drawing.Size(753, 221)
      Me.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill
      Me.toolStripContainer1.Location = New System.Drawing.Point(0, 0)
      Me.toolStripContainer1.Name = "toolStripContainer1"
      Me.toolStripContainer1.Size = New System.Drawing.Size(753, 272)
      Me.toolStripContainer1.TabIndex = 4
      Me.toolStripContainer1.Text = "toolStripContainer1"
      Me.toolStripContainer1.TopToolStripPanel.Controls.Add(Me.tsButtonBar)
      Me.toolStripContainer1.TopToolStripPanel.Controls.Add(Me.menuStrip2)
      Me.tsButtonBar.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)), System.Windows.Forms.AnchorStyles))
      Me.tsButtonBar.Dock = System.Windows.Forms.DockStyle.None
      Me.tsButtonBar.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
      Me.tsButtonBar.ImageScalingSize = New System.Drawing.Size(97, 22)
      Me.tsButtonBar.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tssUpdateItems, Me.lockToolStripMenuItem, Me.toolStripSeparator5, Me.tssToggleColorLegend, Me.toolStripSeparator6, Me.tssSearch})
      Me.tsButtonBar.Location = New System.Drawing.Point(3, 0)
      Me.tsButtonBar.Name = "tsButtonBar"
      Me.tsButtonBar.Size = New System.Drawing.Size(160, 27)
      Me.tsButtonBar.TabIndex = 4
      Me.tssUpdateItems.Enabled = False
      Me.tssUpdateItems.Image = Resources.note
      Me.tssUpdateItems.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
      Me.tssUpdateItems.Name = "tssUpdateItems"
      Me.tssUpdateItems.Size = New System.Drawing.Size(24, 24)
      Me.tssUpdateItems.ToolTipText = "Update"
      Me.tssUpdateItems.Visible = False
      AddHandler Me.tssUpdateItems.Click, AddressOf Me.tssUpdateItems_Click
      Me.lockToolStripMenuItem.AutoSize = False
      Me.lockToolStripMenuItem.CheckOnClick = True
      Me.lockToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
      Me.lockToolStripMenuItem.Enabled = False
      Me.lockToolStripMenuItem.Image = Resources.locked
      Me.lockToolStripMenuItem.Name = "lockToolStripMenuItem"
      Me.lockToolStripMenuItem.Size = New System.Drawing.Size(97, 20)
      Me.lockToolStripMenuItem.Text = "View Mode"
      AddHandler Me.lockToolStripMenuItem.CheckedChanged, AddressOf Me.lockToolStripMenuItem_CheckedChanged
      Me.toolStripSeparator5.Name = "toolStripSeparator5"
      Me.toolStripSeparator5.Size = New System.Drawing.Size(6, 27)
      Me.tssToggleColorLegend.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
      Me.tssToggleColorLegend.Enabled = False
      Me.tssToggleColorLegend.Image = Resources.colors
      Me.tssToggleColorLegend.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
      Me.tssToggleColorLegend.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.tssToggleColorLegend.Name = "tssToggleColorLegend"
      Me.tssToggleColorLegend.Size = New System.Drawing.Size(24, 24)
      Me.tssToggleColorLegend.Text = "Toggle Color Legend"
      AddHandler Me.tssToggleColorLegend.Click, AddressOf Me.tssToggleColorLegend_Click
      Me.toolStripSeparator6.Name = "toolStripSeparator6"
      Me.toolStripSeparator6.Size = New System.Drawing.Size(6, 27)
      Me.tssSearch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
      Me.tssSearch.Enabled = False
      Me.tssSearch.Image = Resources.search
      Me.tssSearch.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
      Me.tssSearch.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.tssSearch.Name = "tssSearch"
      Me.tssSearch.Size = New System.Drawing.Size(24, 24)
      Me.tssSearch.Text = "Search"
      AddHandler Me.tssSearch.Click, AddressOf Me.searchToolStripMenuItem_Click
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.Controls.Add(Me.toolStripContainer1)
      Me.Name = "ResultsPanel"
      Me.Size = New System.Drawing.Size(753, 272)
      AddHandler Me.Load, AddressOf Me.ResultsPanel_Load
      Me.menuStrip2.ResumeLayout(False)
      Me.menuStrip2.PerformLayout()
      Me.spltResults.Panel1.ResumeLayout(False)
      Me.spltResults.Panel2.ResumeLayout(False)
      CType(Me.spltResults, System.ComponentModel.ISupportInitialize).EndInit()
      Me.spltResults.ResumeLayout(False)
      CType(Me.dgvResults, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.dgvStats, System.ComponentModel.ISupportInitialize).EndInit()
      Me.toolStripContainer1.ContentPanel.ResumeLayout(False)
      Me.toolStripContainer1.TopToolStripPanel.ResumeLayout(False)
      Me.toolStripContainer1.TopToolStripPanel.PerformLayout()
      Me.toolStripContainer1.ResumeLayout(False)
      Me.toolStripContainer1.PerformLayout()
      Me.tsButtonBar.ResumeLayout(False)
      Me.tsButtonBar.PerformLayout()
      Me.ResumeLayout(False)
   End Sub

   Private miniToolStrip As System.Windows.Forms.ToolStrip
   Private menuStrip2 As System.Windows.Forms.MenuStrip
   Private fileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Private saveWorkspaceToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Private openToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Private exportCSVToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Private exportStatsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Private viewToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Private searchToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Private colorsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Private changeActiveFiltersToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Private toolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
   Private showResultPanelToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Private showStatisticsPanelToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Private gradingToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Private processReportToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Private gradeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Private toolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
   Private verifyAnswersToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Private reviewWorksheetsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Private helpToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Private aboutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Private spltResults As System.Windows.Forms.SplitContainer
   Private lblStats As System.Windows.Forms.Label
   Private toolStripContainer1 As System.Windows.Forms.ToolStripContainer
   Private BottomToolStripPanel As System.Windows.Forms.ToolStripPanel
   Private TopToolStripPanel As System.Windows.Forms.ToolStripPanel
   Private RightToolStripPanel As System.Windows.Forms.ToolStripPanel
   Private LeftToolStripPanel As System.Windows.Forms.ToolStripPanel
   Private ContentPanel As System.Windows.Forms.ToolStripContentPanel
   Private tsButtonBar As System.Windows.Forms.ToolStrip
   Private tssUpdateItems As System.Windows.Forms.ToolStripButton
   Private lockToolStripMenuItem As System.Windows.Forms.ToolStripButton
   Private tssToggleColorLegend As System.Windows.Forms.ToolStripButton
   Private tssSearch As System.Windows.Forms.ToolStripButton
   Private closeWorkspaceToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Private dgvResults As DataGridViewDoubleBuffered
   Private dgvStats As DataGridViewDoubleBuffered
   Private toolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
   Private toolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
   Private swapStatisticsRowsAndColumnsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Private exitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Private saveWorkspaceAsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Private changeIdentifierToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Private toolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
   Private toolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
End Class

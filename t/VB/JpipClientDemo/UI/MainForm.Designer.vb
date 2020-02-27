Imports Microsoft.VisualBasic
Imports System

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
      Me.statusStrip1 = New System.Windows.Forms.StatusStrip
      Me.ImageSize = New System.Windows.Forms.ToolStripStatusLabel
      Me.CurrentSize = New System.Windows.Forms.ToolStripStatusLabel
      Me.CompIndex = New System.Windows.Forms.ToolStripStatusLabel
      Me.ByteCount = New System.Windows.Forms.ToolStripStatusLabel
      Me.progressStatusLabel = New System.Windows.Forms.ToolStripStatusLabel
      Me.CodeStreamCount = New System.Windows.Forms.ToolStripStatusLabel
      Me.menuStrip1 = New System.Windows.Forms.MenuStrip
      Me.fileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
      Me.openImageToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
      Me.connectionToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
      Me.toolStripSeparator8 = New System.Windows.Forms.ToolStripSeparator
      Me.cleanCacheToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
      Me.toolStripSeparator9 = New System.Windows.Forms.ToolStripSeparator
      Me.closeToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
      Me.toolStripSeparator10 = New System.Windows.Forms.ToolStripSeparator
      Me.exitToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
      Me.viewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
      Me.zoomIntoolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
      Me.zoomOuttoolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
      Me.toolStripSeparator12 = New System.Windows.Forms.ToolStripSeparator
      Me.nextComponentToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
      Me.showAllComponenetsToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
      Me.modeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
      Me.panToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
      Me.zoomToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
      Me.helpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
      Me.aboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
      Me.howToToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
      Me.toolStrip1 = New System.Windows.Forms.ToolStrip
      Me.openFiletoolStripButton = New System.Windows.Forms.ToolStripButton
      Me.toolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator
      Me.CloseStripButton = New System.Windows.Forms.ToolStripButton
      Me.toolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
      Me.zoomIntoolStripButton = New System.Windows.Forms.ToolStripButton
      Me.toolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
      Me.zoomOuttoolStripButton = New System.Windows.Forms.ToolStripButton
      Me.toolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator
      Me.nextComptoolStripButton = New System.Windows.Forms.ToolStripButton
      Me.toolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator
      Me.showAllComptoolStripButton = New System.Windows.Forms.ToolStripButton
      Me.toolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator
      Me.resolutionsToolStripDropDownButton = New System.Windows.Forms.ToolStripDropDownButton
      Me.previousCodeStreamToolStripButton = New System.Windows.Forms.ToolStripButton
      Me.nextCodeStreamToolStripButton = New System.Windows.Forms.ToolStripButton
      Me.statusStrip1.SuspendLayout()
      Me.menuStrip1.SuspendLayout()
      Me.toolStrip1.SuspendLayout()
      Me.SuspendLayout()
      '
      'statusStrip1
      '
      Me.statusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ImageSize, Me.CurrentSize, Me.CompIndex, Me.ByteCount, Me.progressStatusLabel, Me.CodeStreamCount})
      Me.statusStrip1.Location = New System.Drawing.Point(0, 442)
      Me.statusStrip1.Name = "statusStrip1"
      Me.statusStrip1.Size = New System.Drawing.Size(795, 22)
      Me.statusStrip1.TabIndex = 2
      Me.statusStrip1.Text = "statusStrip1"
      '
      'ImageSize
      '
      Me.ImageSize.Name = "ImageSize"
      Me.ImageSize.Size = New System.Drawing.Size(0, 17)
      '
      'CurrentSize
      '
      Me.CurrentSize.Name = "CurrentSize"
      Me.CurrentSize.Size = New System.Drawing.Size(0, 17)
      '
      'CompIndex
      '
      Me.CompIndex.Name = "CompIndex"
      Me.CompIndex.Size = New System.Drawing.Size(0, 17)
      '
      'ByteCount
      '
      Me.ByteCount.Name = "ByteCount"
      Me.ByteCount.Size = New System.Drawing.Size(0, 17)
      '
      'progressStatusLabel
      '
      Me.progressStatusLabel.Name = "progressStatusLabel"
      Me.progressStatusLabel.Size = New System.Drawing.Size(0, 17)
      '
      'CodeStreamCount
      '
      Me.CodeStreamCount.Name = "CodeStreamCount"
      Me.CodeStreamCount.Size = New System.Drawing.Size(0, 17)
      '
      'menuStrip1
      '
      Me.menuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.fileToolStripMenuItem, Me.viewToolStripMenuItem, Me.modeToolStripMenuItem, Me.helpToolStripMenuItem})
      Me.menuStrip1.Location = New System.Drawing.Point(0, 0)
      Me.menuStrip1.Name = "menuStrip1"
      Me.menuStrip1.Padding = New System.Windows.Forms.Padding(5, 2, 0, 2)
      Me.menuStrip1.Size = New System.Drawing.Size(795, 24)
      Me.menuStrip1.TabIndex = 3
      Me.menuStrip1.Text = "menuStrip1"
      '
      'fileToolStripMenuItem
      '
      Me.fileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.openImageToolStripMenuItem, Me.connectionToolStripMenuItem1, Me.toolStripSeparator8, Me.cleanCacheToolStripMenuItem, Me.toolStripSeparator9, Me.closeToolStripMenuItem1, Me.toolStripSeparator10, Me.exitToolStripMenuItem1})
      Me.fileToolStripMenuItem.Name = "fileToolStripMenuItem"
      Me.fileToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
      Me.fileToolStripMenuItem.Text = "&File"
      '
      'openImageToolStripMenuItem
      '
      Me.openImageToolStripMenuItem.Name = "openImageToolStripMenuItem"
      Me.openImageToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.O), System.Windows.Forms.Keys)
      Me.openImageToolStripMenuItem.Size = New System.Drawing.Size(176, 22)
      Me.openImageToolStripMenuItem.Text = "&Open File..."
      '
      'connectionToolStripMenuItem1
      '
      Me.connectionToolStripMenuItem1.Name = "connectionToolStripMenuItem1"
      Me.connectionToolStripMenuItem1.Size = New System.Drawing.Size(176, 22)
      Me.connectionToolStripMenuItem1.Text = "Co&nfiguration..."
      '
      'toolStripSeparator8
      '
      Me.toolStripSeparator8.Name = "toolStripSeparator8"
      Me.toolStripSeparator8.Size = New System.Drawing.Size(173, 6)
      '
      'cleanCacheToolStripMenuItem
      '
      Me.cleanCacheToolStripMenuItem.Name = "cleanCacheToolStripMenuItem"
      Me.cleanCacheToolStripMenuItem.Size = New System.Drawing.Size(176, 22)
      Me.cleanCacheToolStripMenuItem.Text = "C&lean Cache"
      '
      'toolStripSeparator9
      '
      Me.toolStripSeparator9.Name = "toolStripSeparator9"
      Me.toolStripSeparator9.Size = New System.Drawing.Size(173, 6)
      '
      'closeToolStripMenuItem1
      '
      Me.closeToolStripMenuItem1.Name = "closeToolStripMenuItem1"
      Me.closeToolStripMenuItem1.Size = New System.Drawing.Size(176, 22)
      Me.closeToolStripMenuItem1.Text = "&Close"
      '
      'toolStripSeparator10
      '
      Me.toolStripSeparator10.Name = "toolStripSeparator10"
      Me.toolStripSeparator10.Size = New System.Drawing.Size(173, 6)
      '
      'exitToolStripMenuItem1
      '
      Me.exitToolStripMenuItem1.Name = "exitToolStripMenuItem1"
      Me.exitToolStripMenuItem1.Size = New System.Drawing.Size(176, 22)
      Me.exitToolStripMenuItem1.Text = "Exit"
      '
      'viewToolStripMenuItem
      '
      Me.viewToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.zoomIntoolStripMenuItem, Me.zoomOuttoolStripMenuItem, Me.toolStripSeparator12, Me.nextComponentToolStripMenuItem, Me.showAllComponenetsToolStripMenuItem1})
      Me.viewToolStripMenuItem.Name = "viewToolStripMenuItem"
      Me.viewToolStripMenuItem.Size = New System.Drawing.Size(44, 20)
      Me.viewToolStripMenuItem.Text = "&View"
      '
      'zoomIntoolStripMenuItem
      '
      Me.zoomIntoolStripMenuItem.Name = "zoomIntoolStripMenuItem"
      Me.zoomIntoolStripMenuItem.Size = New System.Drawing.Size(192, 22)
      Me.zoomIntoolStripMenuItem.Text = "Zoom &In"
      '
      'zoomOuttoolStripMenuItem
      '
      Me.zoomOuttoolStripMenuItem.Name = "zoomOuttoolStripMenuItem"
      Me.zoomOuttoolStripMenuItem.Size = New System.Drawing.Size(192, 22)
      Me.zoomOuttoolStripMenuItem.Text = "Zoom &Out"
      '
      'toolStripSeparator12
      '
      Me.toolStripSeparator12.Name = "toolStripSeparator12"
      Me.toolStripSeparator12.Size = New System.Drawing.Size(189, 6)
      '
      'nextComponentToolStripMenuItem
      '
      Me.nextComponentToolStripMenuItem.Name = "nextComponentToolStripMenuItem"
      Me.nextComponentToolStripMenuItem.Size = New System.Drawing.Size(192, 22)
      Me.nextComponentToolStripMenuItem.Text = "&Next Component"
      '
      'showAllComponenetsToolStripMenuItem1
      '
      Me.showAllComponenetsToolStripMenuItem1.Name = "showAllComponenetsToolStripMenuItem1"
      Me.showAllComponenetsToolStripMenuItem1.Size = New System.Drawing.Size(192, 22)
      Me.showAllComponenetsToolStripMenuItem1.Text = "&Show All Components"
      '
      'modeToolStripMenuItem
      '
      Me.modeToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.panToolStripMenuItem, Me.zoomToolStripMenuItem})
      Me.modeToolStripMenuItem.Name = "modeToolStripMenuItem"
      Me.modeToolStripMenuItem.Size = New System.Drawing.Size(50, 20)
      Me.modeToolStripMenuItem.Text = "&Mode"
      '
      'panToolStripMenuItem
      '
      Me.panToolStripMenuItem.Name = "panToolStripMenuItem"
      Me.panToolStripMenuItem.Size = New System.Drawing.Size(106, 22)
      Me.panToolStripMenuItem.Text = "&Pan"
      '
      'zoomToolStripMenuItem
      '
      Me.zoomToolStripMenuItem.Checked = True
      Me.zoomToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked
      Me.zoomToolStripMenuItem.Name = "zoomToolStripMenuItem"
      Me.zoomToolStripMenuItem.Size = New System.Drawing.Size(106, 22)
      Me.zoomToolStripMenuItem.Text = "&Zoom"
      '
      'helpToolStripMenuItem
      '
      Me.helpToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.aboutToolStripMenuItem, Me.howToToolStripMenuItem})
      Me.helpToolStripMenuItem.Name = "helpToolStripMenuItem"
      Me.helpToolStripMenuItem.Size = New System.Drawing.Size(44, 20)
      Me.helpToolStripMenuItem.Text = "&Help"
      '
      'aboutToolStripMenuItem
      '
      Me.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem"
      Me.aboutToolStripMenuItem.Size = New System.Drawing.Size(116, 22)
      Me.aboutToolStripMenuItem.Text = "About"
      '
      'howToToolStripMenuItem
      '
      Me.howToToolStripMenuItem.Name = "howToToolStripMenuItem"
      Me.howToToolStripMenuItem.Size = New System.Drawing.Size(116, 22)
      Me.howToToolStripMenuItem.Text = "How To"
      '
      'toolStrip1
      '
      Me.toolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.openFiletoolStripButton, Me.toolStripSeparator5, Me.CloseStripButton, Me.toolStripSeparator2, Me.zoomIntoolStripButton, Me.toolStripSeparator1, Me.zoomOuttoolStripButton, Me.toolStripSeparator3, Me.nextComptoolStripButton, Me.toolStripSeparator4, Me.showAllComptoolStripButton, Me.toolStripSeparator6, Me.resolutionsToolStripDropDownButton, Me.previousCodeStreamToolStripButton, Me.nextCodeStreamToolStripButton})
      Me.toolStrip1.Location = New System.Drawing.Point(0, 24)
      Me.toolStrip1.Name = "toolStrip1"
      Me.toolStrip1.Size = New System.Drawing.Size(795, 25)
      Me.toolStrip1.TabIndex = 4
      Me.toolStrip1.Text = "toolStrip1"
      '
      'openFiletoolStripButton
      '
      Me.openFiletoolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
      Me.openFiletoolStripButton.Image = CType(resources.GetObject("openFiletoolStripButton.Image"), System.Drawing.Image)
      Me.openFiletoolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.openFiletoolStripButton.Name = "openFiletoolStripButton"
      Me.openFiletoolStripButton.Size = New System.Drawing.Size(49, 22)
      Me.openFiletoolStripButton.Text = "Open..."
      '
      'toolStripSeparator5
      '
      Me.toolStripSeparator5.Name = "toolStripSeparator5"
      Me.toolStripSeparator5.Size = New System.Drawing.Size(6, 25)
      '
      'CloseStripButton
      '
      Me.CloseStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
      Me.CloseStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.CloseStripButton.Name = "CloseStripButton"
      Me.CloseStripButton.Size = New System.Drawing.Size(40, 22)
      Me.CloseStripButton.Text = "Close"
      '
      'toolStripSeparator2
      '
      Me.toolStripSeparator2.Name = "toolStripSeparator2"
      Me.toolStripSeparator2.Size = New System.Drawing.Size(6, 25)
      '
      'zoomIntoolStripButton
      '
      Me.zoomIntoolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
      Me.zoomIntoolStripButton.Image = CType(resources.GetObject("zoomIntoolStripButton.Image"), System.Drawing.Image)
      Me.zoomIntoolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.zoomIntoolStripButton.Name = "zoomIntoolStripButton"
      Me.zoomIntoolStripButton.Size = New System.Drawing.Size(56, 22)
      Me.zoomIntoolStripButton.Text = "Zoom In"
      '
      'toolStripSeparator1
      '
      Me.toolStripSeparator1.Name = "toolStripSeparator1"
      Me.toolStripSeparator1.Size = New System.Drawing.Size(6, 25)
      '
      'zoomOuttoolStripButton
      '
      Me.zoomOuttoolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
      Me.zoomOuttoolStripButton.Image = CType(resources.GetObject("zoomOuttoolStripButton.Image"), System.Drawing.Image)
      Me.zoomOuttoolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.zoomOuttoolStripButton.Name = "zoomOuttoolStripButton"
      Me.zoomOuttoolStripButton.Size = New System.Drawing.Size(66, 22)
      Me.zoomOuttoolStripButton.Text = "Zoom Out"
      '
      'toolStripSeparator3
      '
      Me.toolStripSeparator3.Name = "toolStripSeparator3"
      Me.toolStripSeparator3.Size = New System.Drawing.Size(6, 25)
      '
      'nextComptoolStripButton
      '
      Me.nextComptoolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
      Me.nextComptoolStripButton.Image = CType(resources.GetObject("nextComptoolStripButton.Image"), System.Drawing.Image)
      Me.nextComptoolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.nextComptoolStripButton.Name = "nextComptoolStripButton"
      Me.nextComptoolStripButton.Size = New System.Drawing.Size(102, 22)
      Me.nextComptoolStripButton.Text = "Next Component"
      '
      'toolStripSeparator4
      '
      Me.toolStripSeparator4.Name = "toolStripSeparator4"
      Me.toolStripSeparator4.Size = New System.Drawing.Size(6, 25)
      '
      'showAllComptoolStripButton
      '
      Me.showAllComptoolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
      Me.showAllComptoolStripButton.Image = CType(resources.GetObject("showAllComptoolStripButton.Image"), System.Drawing.Image)
      Me.showAllComptoolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.showAllComptoolStripButton.Name = "showAllComptoolStripButton"
      Me.showAllComptoolStripButton.Size = New System.Drawing.Size(129, 22)
      Me.showAllComptoolStripButton.Text = "Show All Components"
      '
      'toolStripSeparator6
      '
      Me.toolStripSeparator6.Name = "toolStripSeparator6"
      Me.toolStripSeparator6.Size = New System.Drawing.Size(6, 25)
      '
      'resolutionsToolStripDropDownButton
      '
      Me.resolutionsToolStripDropDownButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
      Me.resolutionsToolStripDropDownButton.Image = CType(resources.GetObject("resolutionsToolStripDropDownButton.Image"), System.Drawing.Image)
      Me.resolutionsToolStripDropDownButton.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.resolutionsToolStripDropDownButton.Name = "resolutionsToolStripDropDownButton"
      Me.resolutionsToolStripDropDownButton.Size = New System.Drawing.Size(81, 22)
      Me.resolutionsToolStripDropDownButton.Text = "Resolutions"
      '
      'previousCodeStreamToolStripButton
      '
      Me.previousCodeStreamToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
      Me.previousCodeStreamToolStripButton.Image = CType(resources.GetObject("previousCodeStreamToolStripButton.Image"), System.Drawing.Image)
      Me.previousCodeStreamToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.previousCodeStreamToolStripButton.Name = "previousCodeStreamToolStripButton"
      Me.previousCodeStreamToolStripButton.Size = New System.Drawing.Size(92, 22)
      Me.previousCodeStreamToolStripButton.Text = "Previous Frame"
      '
      'nextCodeStreamToolStripButton
      '
      Me.nextCodeStreamToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
      Me.nextCodeStreamToolStripButton.Image = CType(resources.GetObject("nextCodeStreamToolStripButton.Image"), System.Drawing.Image)
      Me.nextCodeStreamToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.nextCodeStreamToolStripButton.Name = "nextCodeStreamToolStripButton"
      Me.nextCodeStreamToolStripButton.Size = New System.Drawing.Size(71, 22)
      Me.nextCodeStreamToolStripButton.Text = "Next Frame"
      '
      'MainForm
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(795, 464)
      Me.Controls.Add(Me.toolStrip1)
      Me.Controls.Add(Me.statusStrip1)
      Me.Controls.Add(Me.menuStrip1)
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.MainMenuStrip = Me.menuStrip1
      Me.Name = "MainForm"
      Me.Text = "Form1"
      Me.statusStrip1.ResumeLayout(False)
      Me.statusStrip1.PerformLayout()
      Me.menuStrip1.ResumeLayout(False)
      Me.menuStrip1.PerformLayout()
      Me.toolStrip1.ResumeLayout(False)
      Me.toolStrip1.PerformLayout()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub

#End Region

      Private statusStrip1 As System.Windows.Forms.StatusStrip
      Private ImageSize As System.Windows.Forms.ToolStripStatusLabel
      Private CurrentSize As System.Windows.Forms.ToolStripStatusLabel
      Private CompIndex As System.Windows.Forms.ToolStripStatusLabel
      Private ByteCount As System.Windows.Forms.ToolStripStatusLabel
      Private menuStrip1 As System.Windows.Forms.MenuStrip
      Private fileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents openImageToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents connectionToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
      Private toolStripSeparator8 As System.Windows.Forms.ToolStripSeparator
      Private WithEvents cleanCacheToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private toolStripSeparator9 As System.Windows.Forms.ToolStripSeparator
      Private WithEvents closeToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
      Private toolStripSeparator10 As System.Windows.Forms.ToolStripSeparator
      Private WithEvents exitToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
      Private viewToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents zoomIntoolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents zoomOuttoolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private toolStripSeparator12 As System.Windows.Forms.ToolStripSeparator
      Private WithEvents nextComponentToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents showAllComponenetsToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
      Private modeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents panToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents zoomToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private toolStrip1 As System.Windows.Forms.ToolStrip
      Private WithEvents zoomIntoolStripButton As System.Windows.Forms.ToolStripButton
      Private WithEvents openFiletoolStripButton As System.Windows.Forms.ToolStripButton
      Private toolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
      Private toolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
      Private WithEvents zoomOuttoolStripButton As System.Windows.Forms.ToolStripButton
      Private toolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
      Private WithEvents nextComptoolStripButton As System.Windows.Forms.ToolStripButton
      Private toolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
      Private WithEvents showAllComptoolStripButton As System.Windows.Forms.ToolStripButton
      Private WithEvents CloseStripButton As System.Windows.Forms.ToolStripButton
      Private toolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
      Private WithEvents resolutionsToolStripDropDownButton As System.Windows.Forms.ToolStripDropDownButton
      Private toolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
      Private helpToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents aboutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Private progressStatusLabel As System.Windows.Forms.ToolStripStatusLabel
   Friend WithEvents howToToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents previousCodeStreamToolStripButton As System.Windows.Forms.ToolStripButton
   Friend WithEvents nextCodeStreamToolStripButton As System.Windows.Forms.ToolStripButton
   Friend WithEvents CodeStreamCount As System.Windows.Forms.ToolStripStatusLabel
   End Class



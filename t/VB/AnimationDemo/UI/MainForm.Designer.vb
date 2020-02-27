
Namespace AnimationDemo
   Partial Class MainForm
      ''' <summary>
      ''' Required designer variable.
      ''' </summary>
      Private components As System.ComponentModel.IContainer = Nothing

      ''' <summary>
      ''' Clean up any resources being used.
      ''' </summary>
      ''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
      Protected Overrides Sub Dispose(disposing As Boolean)
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
         Dim resources As New System.ComponentModel.ComponentResourceManager(GetType(MainForm))
         Me._mainMenu = New System.Windows.Forms.MenuStrip()
         Me._menuItemFile = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemFileOpen = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemFileSave = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemFileSep5 = New System.Windows.Forms.ToolStripSeparator()
         Me._menuItemFileExit = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemEdit = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemEditCopy = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemEditPaste = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemAnimation = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemAnimationCreate = New System.Windows.Forms.ToolStripMenuItem()
         Me.toolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
         Me._menuItemAnimationFrameSettings = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemBackground = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemAnimationOptimizeColors = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemAnimationLoop = New System.Windows.Forms.ToolStripMenuItem()
         Me.toolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
         Me._menuItemAnimationPlay = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemAnimationPause = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemPage = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemPageFirst = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemPagePrevious = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemPageNext = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemPageLast = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemPageSep1 = New System.Windows.Forms.ToolStripSeparator()
         Me._menuItemPageAdd = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemPageDeleteCurrentPage = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemView = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemViewSizeMode = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemViewSizeModeNormal = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemViewSizeModeStretch = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemViewSizeModeCenter = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemViewSizeModeZoom = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemViewSizeModeAuto = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemPreferences = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemPreferencesPaintProperties = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemPreferencesUseDpi = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemWindow = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemWindowCascade = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemWindowTileHorizontally = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemWindowTileVertically = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemWindowArrangeIcons = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemWindowCloseAll = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemHelp = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemHelpAbout = New System.Windows.Forms.ToolStripMenuItem()
         Me._mainMenu.SuspendLayout()
         Me.SuspendLayout()
         ' 
         ' _mainMenu
         ' 
         Me._mainMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me._menuItemFile, Me._menuItemEdit, Me._menuItemAnimation, Me._menuItemPage, Me._menuItemView, Me._menuItemPreferences, _
          Me._menuItemWindow, Me._menuItemHelp})
         Me._mainMenu.Location = New System.Drawing.Point(0, 0)
         Me._mainMenu.Name = "_mainMenu"
         Me._mainMenu.Padding = New System.Windows.Forms.Padding(2, 2, 0, 2)
         Me._mainMenu.Size = New System.Drawing.Size(749, 23)
         Me._mainMenu.Stretch = False
         Me._mainMenu.TabIndex = 1
         Me._mainMenu.Text = "menuStrip1"
         ' 
         ' _menuItemFile
         ' 
         Me._menuItemFile.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._menuItemFileOpen, Me._menuItemFileSave, Me._menuItemFileSep5, Me._menuItemFileExit})
         Me._menuItemFile.Name = "_menuItemFile"
         Me._menuItemFile.Size = New System.Drawing.Size(35, 17)
         Me._menuItemFile.Text = "&File"
         ' 
         ' _menuItemFileOpen
         ' 
         Me._menuItemFileOpen.Name = "_menuItemFileOpen"
         Me._menuItemFileOpen.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.O), System.Windows.Forms.Keys)
         Me._menuItemFileOpen.Size = New System.Drawing.Size(152, 22)
         Me._menuItemFileOpen.Text = "&Open..."
         ' 
         ' _menuItemFileSave
         ' 
         Me._menuItemFileSave.Name = "_menuItemFileSave"
         Me._menuItemFileSave.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.S), System.Windows.Forms.Keys)
         Me._menuItemFileSave.Size = New System.Drawing.Size(152, 22)
         Me._menuItemFileSave.Text = "&Save..."
         ' 
         ' _menuItemFileSep5
         ' 
         Me._menuItemFileSep5.Name = "_menuItemFileSep5"
         Me._menuItemFileSep5.Size = New System.Drawing.Size(149, 6)
         ' 
         ' _menuItemFileExit
         ' 
         Me._menuItemFileExit.Name = "_menuItemFileExit"
         Me._menuItemFileExit.Size = New System.Drawing.Size(152, 22)
         Me._menuItemFileExit.Text = "E&xit"
         ' 
         ' _menuItemEdit
         ' 
         Me._menuItemEdit.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._menuItemEditCopy, Me._menuItemEditPaste})
         Me._menuItemEdit.Name = "_menuItemEdit"
         Me._menuItemEdit.Size = New System.Drawing.Size(37, 17)
         Me._menuItemEdit.Text = "&Edit"
         ' 
         ' _menuItemEditCopy
         ' 
         Me._menuItemEditCopy.Name = "_menuItemEditCopy"
         Me._menuItemEditCopy.Size = New System.Drawing.Size(101, 22)
         Me._menuItemEditCopy.Text = "&Copy"
         ' 
         ' _menuItemEditPaste
         ' 
         Me._menuItemEditPaste.Name = "_menuItemEditPaste"
         Me._menuItemEditPaste.Size = New System.Drawing.Size(101, 22)
         Me._menuItemEditPaste.Text = "&Paste"
         ' 
         ' _menuItemAnimation
         ' 
         Me._menuItemAnimation.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._menuItemAnimationCreate, Me.toolStripSeparator2, Me._menuItemAnimationFrameSettings, Me._menuItemBackground, Me._menuItemAnimationOptimizeColors, Me._menuItemAnimationLoop, _
          Me.toolStripSeparator1, Me._menuItemAnimationPlay, Me._menuItemAnimationPause})
         Me._menuItemAnimation.Name = "_menuItemAnimation"
         Me._menuItemAnimation.Size = New System.Drawing.Size(66, 17)
         Me._menuItemAnimation.Text = "&Animation"
         ' 
         ' _menuItemAnimationCreate
         ' 
         Me._menuItemAnimationCreate.Name = "_menuItemAnimationCreate"
         Me._menuItemAnimationCreate.Size = New System.Drawing.Size(160, 22)
         Me._menuItemAnimationCreate.Text = "Create"
         ' 
         ' toolStripSeparator2
         ' 
         Me.toolStripSeparator2.Name = "toolStripSeparator2"
         Me.toolStripSeparator2.Size = New System.Drawing.Size(157, 6)
         ' 
         ' _menuItemAnimationFrameSettings
         ' 
         Me._menuItemAnimationFrameSettings.Name = "_menuItemAnimationFrameSettings"
         Me._menuItemAnimationFrameSettings.Size = New System.Drawing.Size(160, 22)
         Me._menuItemAnimationFrameSettings.Text = "&Frame Settings..."
         ' 
         ' _menuItemBackground
         ' 
         Me._menuItemBackground.Name = "_menuItemBackground"
         Me._menuItemBackground.Size = New System.Drawing.Size(160, 22)
         Me._menuItemBackground.Text = "&Background..."
         ' 
         ' _menuItemAnimationOptimizeColors
         ' 
         Me._menuItemAnimationOptimizeColors.Name = "_menuItemAnimationOptimizeColors"
         Me._menuItemAnimationOptimizeColors.Size = New System.Drawing.Size(160, 22)
         Me._menuItemAnimationOptimizeColors.Text = "&Optimize Colors..."
         ' 
         ' _menuItemAnimationLoop
         ' 
         Me._menuItemAnimationLoop.Checked = True
         Me._menuItemAnimationLoop.CheckState = System.Windows.Forms.CheckState.Checked
         Me._menuItemAnimationLoop.Name = "_menuItemAnimationLoop"
         Me._menuItemAnimationLoop.Size = New System.Drawing.Size(160, 22)
         Me._menuItemAnimationLoop.Text = "&Loop"
         ' 
         ' toolStripSeparator1
         ' 
         Me.toolStripSeparator1.Name = "toolStripSeparator1"
         Me.toolStripSeparator1.Size = New System.Drawing.Size(157, 6)
         ' 
         ' _menuItemAnimationPlay
         ' 
         Me._menuItemAnimationPlay.Name = "_menuItemAnimationPlay"
         Me._menuItemAnimationPlay.Size = New System.Drawing.Size(160, 22)
         Me._menuItemAnimationPlay.Text = "Pl&ay"
         ' 
         ' _menuItemAnimationPause
         ' 
         Me._menuItemAnimationPause.Name = "_menuItemAnimationPause"
         Me._menuItemAnimationPause.Size = New System.Drawing.Size(160, 22)
         Me._menuItemAnimationPause.Text = "&Pause"
         ' 
         ' _menuItemPage
         ' 
         Me._menuItemPage.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._menuItemPageFirst, Me._menuItemPagePrevious, Me._menuItemPageNext, Me._menuItemPageLast, Me._menuItemPageSep1, Me._menuItemPageAdd, _
          Me._menuItemPageDeleteCurrentPage})
         Me._menuItemPage.Name = "_menuItemPage"
         Me._menuItemPage.Size = New System.Drawing.Size(69, 17)
         Me._menuItemPage.Text = "&Multi-Page"
         ' 
         ' _menuItemPageFirst
         ' 
         Me._menuItemPageFirst.Name = "_menuItemPageFirst"
         Me._menuItemPageFirst.Size = New System.Drawing.Size(172, 22)
         Me._menuItemPageFirst.Text = "&First"
         ' 
         ' _menuItemPagePrevious
         ' 
         Me._menuItemPagePrevious.Name = "_menuItemPagePrevious"
         Me._menuItemPagePrevious.Size = New System.Drawing.Size(172, 22)
         Me._menuItemPagePrevious.Text = "&Previous"
         ' 
         ' _menuItemPageNext
         ' 
         Me._menuItemPageNext.Name = "_menuItemPageNext"
         Me._menuItemPageNext.Size = New System.Drawing.Size(172, 22)
         Me._menuItemPageNext.Text = "&Next"
         ' 
         ' _menuItemPageLast
         ' 
         Me._menuItemPageLast.Name = "_menuItemPageLast"
         Me._menuItemPageLast.Size = New System.Drawing.Size(172, 22)
         Me._menuItemPageLast.Text = "&Last"
         ' 
         ' _menuItemPageSep1
         ' 
         Me._menuItemPageSep1.Name = "_menuItemPageSep1"
         Me._menuItemPageSep1.Size = New System.Drawing.Size(169, 6)
         ' 
         ' _menuItemPageAdd
         ' 
         Me._menuItemPageAdd.Name = "_menuItemPageAdd"
         Me._menuItemPageAdd.Size = New System.Drawing.Size(172, 22)
         Me._menuItemPageAdd.Text = "&Add..."
         ' 
         ' _menuItemPageDeleteCurrentPage
         ' 
         Me._menuItemPageDeleteCurrentPage.Name = "_menuItemPageDeleteCurrentPage"
         Me._menuItemPageDeleteCurrentPage.Size = New System.Drawing.Size(172, 22)
         Me._menuItemPageDeleteCurrentPage.Text = "&Delete Current Page"
         ' 
         ' _menuItemView
         ' 
         Me._menuItemView.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._menuItemViewSizeMode})
         Me._menuItemView.Name = "_menuItemView"
         Me._menuItemView.Size = New System.Drawing.Size(41, 17)
         Me._menuItemView.Text = "&View"
         ' 
         ' _menuItemViewSizeMode
         ' 
         Me._menuItemViewSizeMode.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._menuItemViewSizeModeNormal, Me._menuItemViewSizeModeStretch, Me._menuItemViewSizeModeCenter, Me._menuItemViewSizeModeZoom, Me._menuItemViewSizeModeAuto})
         Me._menuItemViewSizeMode.Name = "_menuItemViewSizeMode"
         Me._menuItemViewSizeMode.Size = New System.Drawing.Size(152, 22)
         Me._menuItemViewSizeMode.Text = "&Size Mode"
         ' 
         ' _menuItemViewSizeModeNormal
         ' 
         Me._menuItemViewSizeModeNormal.Name = "_menuItemViewSizeModeNormal"
         Me._menuItemViewSizeModeNormal.Size = New System.Drawing.Size(152, 22)
         Me._menuItemViewSizeModeNormal.Text = "&Normal"
         ' 
         ' _menuItemViewSizeModeStretch
         ' 
         Me._menuItemViewSizeModeStretch.Name = "_menuItemViewSizeModeStretch"
         Me._menuItemViewSizeModeStretch.Size = New System.Drawing.Size(152, 22)
         Me._menuItemViewSizeModeStretch.Text = "&Stretch"
         ' 
         ' _menuItemViewSizeModeCenter
         ' 
         Me._menuItemViewSizeModeCenter.Name = "_menuItemViewSizeModeCenter"
         Me._menuItemViewSizeModeCenter.Size = New System.Drawing.Size(152, 22)
         Me._menuItemViewSizeModeCenter.Text = "&Center"
         ' 
         ' _menuItemViewSizeModeZoom
         ' 
         Me._menuItemViewSizeModeZoom.Name = "_menuItemViewSizeModeZoom"
         Me._menuItemViewSizeModeZoom.Size = New System.Drawing.Size(152, 22)
         Me._menuItemViewSizeModeZoom.Text = "&Fit"
         ' 
         ' _menuItemViewSizeModeAuto
         ' 
         Me._menuItemViewSizeModeAuto.Name = "_menuItemViewSizeModeAuto"
         Me._menuItemViewSizeModeAuto.Size = New System.Drawing.Size(152, 22)
         Me._menuItemViewSizeModeAuto.Text = "&Auto"
         ' 
         ' _menuItemPreferences
         ' 
         Me._menuItemPreferences.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._menuItemPreferencesPaintProperties, Me._menuItemPreferencesUseDpi})
         Me._menuItemPreferences.Name = "_menuItemPreferences"
         Me._menuItemPreferences.Size = New System.Drawing.Size(77, 17)
         Me._menuItemPreferences.Text = "P&references"
         ' 
         ' _menuItemPreferencesPaintProperties
         ' 
         Me._menuItemPreferencesPaintProperties.Name = "_menuItemPreferencesPaintProperties"
         Me._menuItemPreferencesPaintProperties.Size = New System.Drawing.Size(162, 22)
         Me._menuItemPreferencesPaintProperties.Text = "Pa&int Properties..."
         ' 
         ' _menuItemPreferencesUseDpi
         ' 
         Me._menuItemPreferencesUseDpi.Checked = True
         Me._menuItemPreferencesUseDpi.CheckState = System.Windows.Forms.CheckState.Checked
         Me._menuItemPreferencesUseDpi.Name = "_menuItemPreferencesUseDpi"
         Me._menuItemPreferencesUseDpi.Size = New System.Drawing.Size(162, 22)
         Me._menuItemPreferencesUseDpi.Text = "&Use Dpi"
         ' 
         ' _menuItemWindow
         ' 
         Me._menuItemWindow.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._menuItemWindowCascade, Me._menuItemWindowTileHorizontally, Me._menuItemWindowTileVertically, Me._menuItemWindowArrangeIcons, Me._menuItemWindowCloseAll})
         Me._menuItemWindow.Name = "_menuItemWindow"
         Me._menuItemWindow.Size = New System.Drawing.Size(57, 17)
         Me._menuItemWindow.Text = "&Window"
         ' 
         ' _menuItemWindowCascade
         ' 
         Me._menuItemWindowCascade.Name = "_menuItemWindowCascade"
         Me._menuItemWindowCascade.Size = New System.Drawing.Size(149, 22)
         Me._menuItemWindowCascade.Text = "&Cascade"
         ' 
         ' _menuItemWindowTileHorizontally
         ' 
         Me._menuItemWindowTileHorizontally.Name = "_menuItemWindowTileHorizontally"
         Me._menuItemWindowTileHorizontally.Size = New System.Drawing.Size(149, 22)
         Me._menuItemWindowTileHorizontally.Text = "Tile &Horizontally"
         ' 
         ' _menuItemWindowTileVertically
         ' 
         Me._menuItemWindowTileVertically.Name = "_menuItemWindowTileVertically"
         Me._menuItemWindowTileVertically.Size = New System.Drawing.Size(149, 22)
         Me._menuItemWindowTileVertically.Text = "Tile &Vertically"
         ' 
         ' _menuItemWindowArrangeIcons
         ' 
         Me._menuItemWindowArrangeIcons.Name = "_menuItemWindowArrangeIcons"
         Me._menuItemWindowArrangeIcons.Size = New System.Drawing.Size(149, 22)
         Me._menuItemWindowArrangeIcons.Text = "Arrange &Icons"
         ' 
         ' _menuItemWindowCloseAll
         ' 
         Me._menuItemWindowCloseAll.Name = "_menuItemWindowCloseAll"
         Me._menuItemWindowCloseAll.Size = New System.Drawing.Size(149, 22)
         Me._menuItemWindowCloseAll.Text = "Close &All"
         ' 
         ' _menuItemHelp
         ' 
         Me._menuItemHelp.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._menuItemHelpAbout})
         Me._menuItemHelp.Name = "_menuItemHelp"
         Me._menuItemHelp.Size = New System.Drawing.Size(40, 17)
         Me._menuItemHelp.Text = "&Help"
         ' 
         ' _menuItemHelpAbout
         ' 
         Me._menuItemHelpAbout.Name = "_menuItemHelpAbout"
         Me._menuItemHelpAbout.Size = New System.Drawing.Size(115, 22)
         Me._menuItemHelpAbout.Text = "&About..."
         ' 
         ' MainForm
         ' 
         Me.AllowDrop = True
         Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
         Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
         Me.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange
         Me.ClientSize = New System.Drawing.Size(749, 454)
         Me.Controls.Add(Me._mainMenu)
         Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
         Me.IsMdiContainer = True
         Me.MainMenuStrip = Me._mainMenu
         Me.Margin = New System.Windows.Forms.Padding(2)
         Me.Name = "MainForm"
         Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
         Me.Text = "MainForm"
         Me._mainMenu.ResumeLayout(False)
         Me._mainMenu.PerformLayout()
         Me.ResumeLayout(False)
         Me.PerformLayout()

      End Sub
#End Region

      Private _mainMenu As System.Windows.Forms.MenuStrip
      Private _menuItemFile As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuItemEdit As System.Windows.Forms.ToolStripMenuItem
      Private _menuItemPage As System.Windows.Forms.ToolStripMenuItem
      Private _menuItemView As System.Windows.Forms.ToolStripMenuItem
      Private _menuItemPreferences As System.Windows.Forms.ToolStripMenuItem
      Private _menuItemWindow As System.Windows.Forms.ToolStripMenuItem
      Private _menuItemHelp As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuItemFileOpen As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuItemFileSave As System.Windows.Forms.ToolStripMenuItem
      Private _menuItemFileSep5 As System.Windows.Forms.ToolStripSeparator
      Private WithEvents _menuItemFileExit As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuItemEditCopy As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuItemEditPaste As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuItemPageFirst As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuItemPagePrevious As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuItemPageNext As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuItemPageLast As System.Windows.Forms.ToolStripMenuItem
      Private _menuItemPageSep1 As System.Windows.Forms.ToolStripSeparator
      Private WithEvents _menuItemPageAdd As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuItemPageDeleteCurrentPage As System.Windows.Forms.ToolStripMenuItem
      Private _menuItemViewSizeMode As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuItemViewSizeModeStretch As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuItemViewSizeModeCenter As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuItemViewSizeModeZoom As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuItemViewSizeModeAuto As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuItemWindowCascade As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuItemWindowTileHorizontally As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuItemWindowTileVertically As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuItemWindowArrangeIcons As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuItemWindowCloseAll As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuItemHelpAbout As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuItemPreferencesPaintProperties As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuItemPreferencesUseDpi As System.Windows.Forms.ToolStripMenuItem
      Private _menuItemAnimation As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuItemAnimationFrameSettings As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuItemAnimationOptimizeColors As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuItemAnimationLoop As System.Windows.Forms.ToolStripMenuItem
      Private toolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
      Private WithEvents _menuItemAnimationPause As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuItemAnimationPlay As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuItemAnimationCreate As System.Windows.Forms.ToolStripMenuItem
      Private toolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
      Private WithEvents _menuItemViewSizeModeNormal As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuItemBackground As System.Windows.Forms.ToolStripMenuItem

   End Class
End Namespace
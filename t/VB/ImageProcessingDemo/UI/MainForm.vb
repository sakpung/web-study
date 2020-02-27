' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports Microsoft.VisualBasic
Imports System
Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Data
Imports System.Text

Imports Leadtools
Imports Leadtools.ImageProcessing
Imports Leadtools.ImageProcessing.Color
Imports Leadtools.ImageProcessing.SpecialEffects
Imports Leadtools.Codecs
Imports Leadtools.ImageProcessing.Core
Imports Leadtools.ImageProcessing.Effects
Imports Leadtools.WinForms.CommonDialogs.Color
Imports Leadtools.Controls
Imports System.Drawing.Drawing2D
Imports Leadtools.Demos.Dialogs

Imports Leadtools.Drawing

#If Not LEADTOOLS_V20_OR_LATER Then
Imports VignetteCommand = Leadtools.ImageProcessing.SpecialEffects.VignnetCommand
Imports VignetteCommandFlags = Leadtools.ImageProcessing.SpecialEffects.VignnetCommandFlags
#End If


Namespace ImageProcessingDemo
   ''' <summary>
   ''' Summary description for MainForm.
   ''' </summary>
   Public Class MainForm : Inherits System.Windows.Forms.Form
      Private _mainMenu As System.Windows.Forms.MainMenu
      Private _menuItemFile As System.Windows.Forms.MenuItem
      Private WithEvents _menuItemFileExit As System.Windows.Forms.MenuItem
      Private _menuItemHelp As System.Windows.Forms.MenuItem
      Private WithEvents _menuItemHelpAbout As System.Windows.Forms.MenuItem
      Private _progressBar As System.Windows.Forms.ProgressBar
      Private WithEvents _buttonCancel As System.Windows.Forms.Button
      Private _panelControls As System.Windows.Forms.Panel
      Private _panelBefore As System.Windows.Forms.Panel
      Private _panelAfter As System.Windows.Forms.Panel
      Private WithEvents _checkBoxProgress As System.Windows.Forms.CheckBox
      Private WithEvents _checkBoxUseRegion As System.Windows.Forms.CheckBox
      Private _panelProgress As System.Windows.Forms.Panel
      Private WithEvents _listBoxCommands As System.Windows.Forms.ListBox
      Private WithEvents _buttonRun As System.Windows.Forms.Button
      Private WithEvents _buttonPrevious As System.Windows.Forms.Button
      Private WithEvents _buttonNext As System.Windows.Forms.Button
      Private _panelBeforeControls As System.Windows.Forms.Panel
      Private _labelBefore As System.Windows.Forms.Label
      Private WithEvents _buttonBeforePageLast As System.Windows.Forms.Button
      Private WithEvents _buttonBeforePageNext As System.Windows.Forms.Button
      Private _labelBeforePage As System.Windows.Forms.Label
      Private WithEvents _buttonBeforePagePrevious As System.Windows.Forms.Button
      Private WithEvents _buttonBeforePageFirst As System.Windows.Forms.Button
      Private _panelAfterControls As System.Windows.Forms.Panel
      Private WithEvents _buttonAfterPageLast As System.Windows.Forms.Button
      Private WithEvents _buttonAfterPageNext As System.Windows.Forms.Button
      Private _labelAfterPage As System.Windows.Forms.Label
      Private WithEvents _buttonAfterPagePrevious As System.Windows.Forms.Button
      Private WithEvents _buttonAfterPageFirst As System.Windows.Forms.Button
      Private _labelAfter As System.Windows.Forms.Label
      Private WithEvents _comboBoxSizeMode As System.Windows.Forms.ComboBox
      Private WithEvents _buttonZoomIn As System.Windows.Forms.Button
      Private WithEvents _buttonZoomNone As System.Windows.Forms.Button
      Private WithEvents _buttonZoomOut As System.Windows.Forms.Button
      Private _labelBeforeInfo As System.Windows.Forms.Label
      Private _labelAfterInfo As System.Windows.Forms.Label
      Private WithEvents _comboBoxNamespace As System.Windows.Forms.ComboBox
      Private _groupBoxRegion As GroupBox
      Private WithEvents _radioButtonRectangle As RadioButton
      Private WithEvents _radioButtonMagicWand As RadioButton
      Private WithEvents _radioButtonFreeHand As RadioButton
      Private WithEvents _radioButtonEllipse As RadioButton
      Private _groupBoxRegionMode As GroupBox
      Private WithEvents _radioButtonInvert As RadioButton
      Private WithEvents _radioButtonIntersect As RadioButton
      Private WithEvents _radioButtonMulti As RadioButton
      Private WithEvents _radioButtonSingle As RadioButton
      Private WithEvents _radioButtonOldXORNew As RadioButton
      Private WithEvents _radioButtonNewandNotOld As RadioButton
      Private WithEvents _radioButtonOldandNotNew As RadioButton
      Private components As IContainer
      Private RegionCombineMode As RasterRegionCombineMode
      Private _checkBoxOptionsDialog As CheckBox
      Private AddMagicWand As Boolean
      Private FreeHandRgn As Boolean
      Private _panZoomInteractiveMode As ImageViewerPanZoomInteractiveMode
      Private _noneInteractiveMode As ImageViewerNoneInteractiveMode
      Private _magnifyGlassInteractiveMode As ImageViewerMagnifyGlassInteractiveMode
      Private _noneInteractiveModeViewerAfter As ImageViewerNoneInteractiveMode
      Private _magnifyGlassInteractiveModeViewerAfter As ImageViewerMagnifyGlassInteractiveMode
      Private WithEvents _menuItemImage As System.Windows.Forms.MenuItem
      Private WithEvents _menuItemHistogram As System.Windows.Forms.MenuItem
      Private _addRegion As ImageViewerAddRegionInteractiveMode
      Private _xLastPos, _yLastPos, _windowLevelWidth, _windowLevelCenter As Integer
      Private _buttonPressed As MouseButton
      Private _currentPalette As RasterColor() = Nothing
      Private _toolTip As ToolTip
      Private _flags As RasterPaletteWindowLevelFlags
      Private _isWLImage, _isMagGlass As Boolean
      Private _isViewerBefore As Boolean
      Private _LUTSize As Integer, _scale As Integer = 1, _maxWidth As Integer, _minWidth As Integer, _maxLevel As Integer, _minLevel As Integer, _minValue As Integer, _maxValue As Integer, _highBit As Integer
      Private WithEvents _menuItemView As System.Windows.Forms.MenuItem
      Private WithEvents _menuItemMagGlass As System.Windows.Forms.MenuItem
      Private WithEvents _menuItemMagGlassStart As System.Windows.Forms.MenuItem
      Private WithEvents _menuItemMagGlassStop As System.Windows.Forms.MenuItem

      Public Enum MouseButton
         None = 0
         Rigth = 1
         Left = 2
      End Enum

      Public Sub New()
         '
         ' Required for Windows Form Designer support
         '
         InitializeComponent()

         '
         ' TODO: Add any constructor code after InitializeComponent call
         '
         InitClass()
      End Sub

      ''' <summary>
      ''' Clean up any resources being used.
      ''' </summary>
      Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
         If disposing Then
            CleanUp()

            If Not components Is Nothing Then
               components.Dispose()
            End If
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
         Me._mainMenu = New System.Windows.Forms.MainMenu(Me.components)
         Me._menuItemFile = New System.Windows.Forms.MenuItem()
         Me._menuItemFileExit = New System.Windows.Forms.MenuItem()
         Me._menuItemView = New System.Windows.Forms.MenuItem()
         Me._menuItemMagGlass = New System.Windows.Forms.MenuItem()
         Me._menuItemMagGlassStart = New System.Windows.Forms.MenuItem()
         Me._menuItemMagGlassStop = New System.Windows.Forms.MenuItem()
         Me._menuItemImage = New System.Windows.Forms.MenuItem()
         Me._menuItemHistogram = New System.Windows.Forms.MenuItem()
         Me._menuItemHelp = New System.Windows.Forms.MenuItem()
         Me._menuItemHelpAbout = New System.Windows.Forms.MenuItem()
         Me._panelProgress = New System.Windows.Forms.Panel()
         Me._progressBar = New System.Windows.Forms.ProgressBar()
         Me._buttonCancel = New System.Windows.Forms.Button()
         Me._panelControls = New System.Windows.Forms.Panel()
         Me._checkBoxOptionsDialog = New System.Windows.Forms.CheckBox()
         Me._groupBoxRegionMode = New System.Windows.Forms.GroupBox()
         Me._radioButtonOldXORNew = New System.Windows.Forms.RadioButton()
         Me._radioButtonNewandNotOld = New System.Windows.Forms.RadioButton()
         Me._radioButtonOldandNotNew = New System.Windows.Forms.RadioButton()
         Me._radioButtonInvert = New System.Windows.Forms.RadioButton()
         Me._radioButtonIntersect = New System.Windows.Forms.RadioButton()
         Me._radioButtonMulti = New System.Windows.Forms.RadioButton()
         Me._radioButtonSingle = New System.Windows.Forms.RadioButton()
         Me._groupBoxRegion = New System.Windows.Forms.GroupBox()
         Me._radioButtonMagicWand = New System.Windows.Forms.RadioButton()
         Me._radioButtonFreeHand = New System.Windows.Forms.RadioButton()
         Me._radioButtonEllipse = New System.Windows.Forms.RadioButton()
         Me._radioButtonRectangle = New System.Windows.Forms.RadioButton()
         Me._comboBoxNamespace = New System.Windows.Forms.ComboBox()
         Me._buttonZoomOut = New System.Windows.Forms.Button()
         Me._buttonZoomIn = New System.Windows.Forms.Button()
         Me._buttonZoomNone = New System.Windows.Forms.Button()
         Me._comboBoxSizeMode = New System.Windows.Forms.ComboBox()
         Me._buttonNext = New System.Windows.Forms.Button()
         Me._buttonPrevious = New System.Windows.Forms.Button()
         Me._buttonRun = New System.Windows.Forms.Button()
         Me._listBoxCommands = New System.Windows.Forms.ListBox()
         Me._checkBoxUseRegion = New System.Windows.Forms.CheckBox()
         Me._checkBoxProgress = New System.Windows.Forms.CheckBox()
         Me._panelBefore = New System.Windows.Forms.Panel()
         Me._labelBeforeInfo = New System.Windows.Forms.Label()
         Me._panelBeforeControls = New System.Windows.Forms.Panel()
         Me._buttonBeforePageLast = New System.Windows.Forms.Button()
         Me._buttonBeforePageNext = New System.Windows.Forms.Button()
         Me._labelBeforePage = New System.Windows.Forms.Label()
         Me._buttonBeforePagePrevious = New System.Windows.Forms.Button()
         Me._buttonBeforePageFirst = New System.Windows.Forms.Button()
         Me._labelBefore = New System.Windows.Forms.Label()
         Me._panelAfter = New System.Windows.Forms.Panel()
         Me._labelAfterInfo = New System.Windows.Forms.Label()
         Me._panelAfterControls = New System.Windows.Forms.Panel()
         Me._buttonAfterPageLast = New System.Windows.Forms.Button()
         Me._buttonAfterPageNext = New System.Windows.Forms.Button()
         Me._labelAfterPage = New System.Windows.Forms.Label()
         Me._buttonAfterPagePrevious = New System.Windows.Forms.Button()
         Me._buttonAfterPageFirst = New System.Windows.Forms.Button()
         Me._labelAfter = New System.Windows.Forms.Label()
         Me._panelProgress.SuspendLayout()
         Me._panelControls.SuspendLayout()
         Me._groupBoxRegionMode.SuspendLayout()
         Me._groupBoxRegion.SuspendLayout()
         Me._panelBefore.SuspendLayout()
         Me._panelBeforeControls.SuspendLayout()
         Me._panelAfter.SuspendLayout()
         Me._panelAfterControls.SuspendLayout()
         Me.SuspendLayout()
         '
         '_mainMenu
         '
         Me._mainMenu.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me._menuItemFile, Me._menuItemView, Me._menuItemImage, Me._menuItemHelp})
         '
         '_menuItemFile
         '
         Me._menuItemFile.Index = 0
         Me._menuItemFile.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me._menuItemFileExit})
         Me._menuItemFile.Text = "&File"
         '
         '_menuItemFileExit
         '
         Me._menuItemFileExit.Index = 0
         Me._menuItemFileExit.Text = "E&xit"
         '
         '_menuItemView
         '
         Me._menuItemView.Index = 1
         Me._menuItemView.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me._menuItemMagGlass})
         Me._menuItemView.Text = "&View"
         '
         '_menuItemMagGlass
         '
         Me._menuItemMagGlass.Index = 0
         Me._menuItemMagGlass.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me._menuItemMagGlassStart, Me._menuItemMagGlassStop})
         Me._menuItemMagGlass.Text = "&Magnify Glass"
         '
         '_menuItemMagGlassStart
         '
         Me._menuItemMagGlassStart.Index = 0
         Me._menuItemMagGlassStart.Text = "&Start"
         '
         '_menuItemMagGlassStop
         '
         Me._menuItemMagGlassStop.Index = 1
         Me._menuItemMagGlassStop.Text = "S&top"
         '
         '_menuItemImage
         '
         Me._menuItemImage.Index = 2
         Me._menuItemImage.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me._menuItemHistogram})
         Me._menuItemImage.Text = "&Image"
         '
         '_menuItemHistogram
         '
         Me._menuItemHistogram.Index = 0
         Me._menuItemHistogram.Text = "&Histogram..."
         '
         '_menuItemHelp
         '
         Me._menuItemHelp.Index = 3
         Me._menuItemHelp.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me._menuItemHelpAbout})
         Me._menuItemHelp.Text = "&Help"
         '
         '_menuItemHelpAbout
         '
         Me._menuItemHelpAbout.Index = 0
         Me._menuItemHelpAbout.Text = "&About..."
         '
         '_panelProgress
         '
         Me._panelProgress.Controls.Add(Me._progressBar)
         Me._panelProgress.Controls.Add(Me._buttonCancel)
         Me._panelProgress.Dock = System.Windows.Forms.DockStyle.Bottom
         Me._panelProgress.Location = New System.Drawing.Point(0, 460)
         Me._panelProgress.Name = "_panelProgress"
         Me._panelProgress.Size = New System.Drawing.Size(1028, 24)
         Me._panelProgress.TabIndex = 0
         '
         '_progressBar
         '
         Me._progressBar.Dock = System.Windows.Forms.DockStyle.Fill
         Me._progressBar.Location = New System.Drawing.Point(0, 0)
         Me._progressBar.Name = "_progressBar"
         Me._progressBar.Size = New System.Drawing.Size(953, 24)
         Me._progressBar.TabIndex = 0
         '
         '_buttonCancel
         '
         Me._buttonCancel.Dock = System.Windows.Forms.DockStyle.Right
         Me._buttonCancel.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me._buttonCancel.Location = New System.Drawing.Point(953, 0)
         Me._buttonCancel.Name = "_buttonCancel"
         Me._buttonCancel.Size = New System.Drawing.Size(75, 24)
         Me._buttonCancel.TabIndex = 1
         Me._buttonCancel.Text = "Cancel"
         '
         '_panelControls
         '
         Me._panelControls.Controls.Add(Me._checkBoxOptionsDialog)
         Me._panelControls.Controls.Add(Me._groupBoxRegionMode)
         Me._panelControls.Controls.Add(Me._groupBoxRegion)
         Me._panelControls.Controls.Add(Me._comboBoxNamespace)
         Me._panelControls.Controls.Add(Me._buttonZoomOut)
         Me._panelControls.Controls.Add(Me._buttonZoomIn)
         Me._panelControls.Controls.Add(Me._buttonZoomNone)
         Me._panelControls.Controls.Add(Me._comboBoxSizeMode)
         Me._panelControls.Controls.Add(Me._buttonNext)
         Me._panelControls.Controls.Add(Me._buttonPrevious)
         Me._panelControls.Controls.Add(Me._buttonRun)
         Me._panelControls.Controls.Add(Me._listBoxCommands)
         Me._panelControls.Controls.Add(Me._checkBoxUseRegion)
         Me._panelControls.Controls.Add(Me._checkBoxProgress)
         Me._panelControls.Dock = System.Windows.Forms.DockStyle.Bottom
         Me._panelControls.Location = New System.Drawing.Point(0, 309)
         Me._panelControls.Name = "_panelControls"
         Me._panelControls.Size = New System.Drawing.Size(1028, 151)
         Me._panelControls.TabIndex = 0
         '
         '_checkBoxOptionsDialog
         '
         Me._checkBoxOptionsDialog.Anchor = System.Windows.Forms.AnchorStyles.Top
         Me._checkBoxOptionsDialog.Enabled = False
         Me._checkBoxOptionsDialog.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me._checkBoxOptionsDialog.Location = New System.Drawing.Point(785, 123)
         Me._checkBoxOptionsDialog.Name = "_checkBoxOptionsDialog"
         Me._checkBoxOptionsDialog.Size = New System.Drawing.Size(214, 17)
         Me._checkBoxOptionsDialog.TabIndex = 13
         Me._checkBoxOptionsDialog.Text = "Show options dialog"
         Me._checkBoxOptionsDialog.UseVisualStyleBackColor = True
         '
         '_groupBoxRegionMode
         '
         Me._groupBoxRegionMode.Controls.Add(Me._radioButtonOldXORNew)
         Me._groupBoxRegionMode.Controls.Add(Me._radioButtonNewandNotOld)
         Me._groupBoxRegionMode.Controls.Add(Me._radioButtonOldandNotNew)
         Me._groupBoxRegionMode.Controls.Add(Me._radioButtonInvert)
         Me._groupBoxRegionMode.Controls.Add(Me._radioButtonIntersect)
         Me._groupBoxRegionMode.Controls.Add(Me._radioButtonMulti)
         Me._groupBoxRegionMode.Controls.Add(Me._radioButtonSingle)
         Me._groupBoxRegionMode.Enabled = False
         Me._groupBoxRegionMode.Location = New System.Drawing.Point(149, 10)
         Me._groupBoxRegionMode.Name = "_groupBoxRegionMode"
         Me._groupBoxRegionMode.Size = New System.Drawing.Size(121, 136)
         Me._groupBoxRegionMode.TabIndex = 12
         Me._groupBoxRegionMode.TabStop = False
         Me._groupBoxRegionMode.Text = "Region Mode"
         '
         '_radioButtonOldXORNew
         '
         Me._radioButtonOldXORNew.AutoSize = True
         Me._radioButtonOldXORNew.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me._radioButtonOldXORNew.Location = New System.Drawing.Point(3, 111)
         Me._radioButtonOldXORNew.Name = "_radioButtonOldXORNew"
         Me._radioButtonOldXORNew.Size = New System.Drawing.Size(98, 18)
         Me._radioButtonOldXORNew.TabIndex = 6
         Me._radioButtonOldXORNew.TabStop = True
         Me._radioButtonOldXORNew.Text = "Old XOR New"
         Me._radioButtonOldXORNew.UseVisualStyleBackColor = True
         '
         '_radioButtonNewandNotOld
         '
         Me._radioButtonNewandNotOld.AutoSize = True
         Me._radioButtonNewandNotOld.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me._radioButtonNewandNotOld.Location = New System.Drawing.Point(3, 94)
         Me._radioButtonNewandNotOld.Name = "_radioButtonNewandNotOld"
         Me._radioButtonNewandNotOld.Size = New System.Drawing.Size(113, 18)
         Me._radioButtonNewandNotOld.TabIndex = 5
         Me._radioButtonNewandNotOld.TabStop = True
         Me._radioButtonNewandNotOld.Text = "New and Not Old"
         Me._radioButtonNewandNotOld.UseVisualStyleBackColor = True
         '
         '_radioButtonOldandNotNew
         '
         Me._radioButtonOldandNotNew.AutoSize = True
         Me._radioButtonOldandNotNew.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me._radioButtonOldandNotNew.Location = New System.Drawing.Point(3, 79)
         Me._radioButtonOldandNotNew.Name = "_radioButtonOldandNotNew"
         Me._radioButtonOldandNotNew.Size = New System.Drawing.Size(113, 18)
         Me._radioButtonOldandNotNew.TabIndex = 4
         Me._radioButtonOldandNotNew.TabStop = True
         Me._radioButtonOldandNotNew.Text = "Old and Not New"
         Me._radioButtonOldandNotNew.UseVisualStyleBackColor = True
         '
         '_radioButtonInvert
         '
         Me._radioButtonInvert.AutoSize = True
         Me._radioButtonInvert.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me._radioButtonInvert.Location = New System.Drawing.Point(3, 62)
         Me._radioButtonInvert.Name = "_radioButtonInvert"
         Me._radioButtonInvert.Size = New System.Drawing.Size(58, 18)
         Me._radioButtonInvert.TabIndex = 3
         Me._radioButtonInvert.TabStop = True
         Me._radioButtonInvert.Text = "Invert"
         Me._radioButtonInvert.UseVisualStyleBackColor = True
         '
         '_radioButtonIntersect
         '
         Me._radioButtonIntersect.AutoSize = True
         Me._radioButtonIntersect.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me._radioButtonIntersect.Location = New System.Drawing.Point(3, 47)
         Me._radioButtonIntersect.Name = "_radioButtonIntersect"
         Me._radioButtonIntersect.Size = New System.Drawing.Size(72, 18)
         Me._radioButtonIntersect.TabIndex = 2
         Me._radioButtonIntersect.TabStop = True
         Me._radioButtonIntersect.Text = "Intersect"
         Me._radioButtonIntersect.UseVisualStyleBackColor = True
         '
         '_radioButtonMulti
         '
         Me._radioButtonMulti.AutoSize = True
         Me._radioButtonMulti.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me._radioButtonMulti.Location = New System.Drawing.Point(3, 30)
         Me._radioButtonMulti.Name = "_radioButtonMulti"
         Me._radioButtonMulti.Size = New System.Drawing.Size(53, 18)
         Me._radioButtonMulti.TabIndex = 1
         Me._radioButtonMulti.TabStop = True
         Me._radioButtonMulti.Text = "Multi"
         Me._radioButtonMulti.UseVisualStyleBackColor = True
         '
         '_radioButtonSingle
         '
         Me._radioButtonSingle.AutoSize = True
         Me._radioButtonSingle.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me._radioButtonSingle.Location = New System.Drawing.Point(3, 15)
         Me._radioButtonSingle.Name = "_radioButtonSingle"
         Me._radioButtonSingle.Size = New System.Drawing.Size(60, 18)
         Me._radioButtonSingle.TabIndex = 0
         Me._radioButtonSingle.TabStop = True
         Me._radioButtonSingle.Text = "Single"
         Me._radioButtonSingle.UseVisualStyleBackColor = True
         '
         '_groupBoxRegion
         '
         Me._groupBoxRegion.Controls.Add(Me._radioButtonMagicWand)
         Me._groupBoxRegion.Controls.Add(Me._radioButtonFreeHand)
         Me._groupBoxRegion.Controls.Add(Me._radioButtonEllipse)
         Me._groupBoxRegion.Controls.Add(Me._radioButtonRectangle)
         Me._groupBoxRegion.Enabled = False
         Me._groupBoxRegion.Location = New System.Drawing.Point(19, 29)
         Me._groupBoxRegion.Name = "_groupBoxRegion"
         Me._groupBoxRegion.Size = New System.Drawing.Size(126, 117)
         Me._groupBoxRegion.TabIndex = 11
         Me._groupBoxRegion.TabStop = False
         Me._groupBoxRegion.Text = "Region Type"
         '
         '_radioButtonMagicWand
         '
         Me._radioButtonMagicWand.AutoSize = True
         Me._radioButtonMagicWand.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me._radioButtonMagicWand.Location = New System.Drawing.Point(4, 94)
         Me._radioButtonMagicWand.Name = "_radioButtonMagicWand"
         Me._radioButtonMagicWand.Size = New System.Drawing.Size(92, 18)
         Me._radioButtonMagicWand.TabIndex = 12
         Me._radioButtonMagicWand.TabStop = True
         Me._radioButtonMagicWand.Text = "Magic Wand"
         Me._radioButtonMagicWand.UseVisualStyleBackColor = True
         '
         '_radioButtonFreeHand
         '
         Me._radioButtonFreeHand.AutoSize = True
         Me._radioButtonFreeHand.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me._radioButtonFreeHand.Location = New System.Drawing.Point(4, 70)
         Me._radioButtonFreeHand.Name = "_radioButtonFreeHand"
         Me._radioButtonFreeHand.Size = New System.Drawing.Size(81, 18)
         Me._radioButtonFreeHand.TabIndex = 12
         Me._radioButtonFreeHand.TabStop = True
         Me._radioButtonFreeHand.Text = "Free Hand"
         Me._radioButtonFreeHand.UseVisualStyleBackColor = True
         '
         '_radioButtonEllipse
         '
         Me._radioButtonEllipse.AutoSize = True
         Me._radioButtonEllipse.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me._radioButtonEllipse.Location = New System.Drawing.Point(4, 43)
         Me._radioButtonEllipse.Name = "_radioButtonEllipse"
         Me._radioButtonEllipse.Size = New System.Drawing.Size(61, 18)
         Me._radioButtonEllipse.TabIndex = 12
         Me._radioButtonEllipse.TabStop = True
         Me._radioButtonEllipse.Text = "Ellipse"
         Me._radioButtonEllipse.UseVisualStyleBackColor = True
         '
         '_radioButtonRectangle
         '
         Me._radioButtonRectangle.AutoSize = True
         Me._radioButtonRectangle.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me._radioButtonRectangle.Location = New System.Drawing.Point(4, 17)
         Me._radioButtonRectangle.Name = "_radioButtonRectangle"
         Me._radioButtonRectangle.Size = New System.Drawing.Size(80, 18)
         Me._radioButtonRectangle.TabIndex = 12
         Me._radioButtonRectangle.TabStop = True
         Me._radioButtonRectangle.Text = "Rectangle"
         Me._radioButtonRectangle.UseVisualStyleBackColor = True
         '
         '_comboBoxNamespace
         '
         Me._comboBoxNamespace.Anchor = System.Windows.Forms.AnchorStyles.Top
         Me._comboBoxNamespace.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
         Me._comboBoxNamespace.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me._comboBoxNamespace.Location = New System.Drawing.Point(505, 4)
         Me._comboBoxNamespace.Name = "_comboBoxNamespace"
         Me._comboBoxNamespace.Size = New System.Drawing.Size(263, 21)
         Me._comboBoxNamespace.TabIndex = 10
         '
         '_buttonZoomOut
         '
         Me._buttonZoomOut.Anchor = System.Windows.Forms.AnchorStyles.Top
         Me._buttonZoomOut.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me._buttonZoomOut.Location = New System.Drawing.Point(467, 68)
         Me._buttonZoomOut.Name = "_buttonZoomOut"
         Me._buttonZoomOut.Size = New System.Drawing.Size(31, 24)
         Me._buttonZoomOut.TabIndex = 9
         Me._buttonZoomOut.Text = "-"
         '
         '_buttonZoomIn
         '
         Me._buttonZoomIn.Anchor = System.Windows.Forms.AnchorStyles.Top
         Me._buttonZoomIn.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me._buttonZoomIn.Location = New System.Drawing.Point(434, 68)
         Me._buttonZoomIn.Name = "_buttonZoomIn"
         Me._buttonZoomIn.Size = New System.Drawing.Size(33, 24)
         Me._buttonZoomIn.TabIndex = 8
         Me._buttonZoomIn.Text = "+"
         '
         '_buttonZoomNone
         '
         Me._buttonZoomNone.Anchor = System.Windows.Forms.AnchorStyles.Top
         Me._buttonZoomNone.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me._buttonZoomNone.Location = New System.Drawing.Point(403, 68)
         Me._buttonZoomNone.Name = "_buttonZoomNone"
         Me._buttonZoomNone.Size = New System.Drawing.Size(31, 24)
         Me._buttonZoomNone.TabIndex = 7
         Me._buttonZoomNone.Text = "1:1"
         '
         '_comboBoxSizeMode
         '
         Me._comboBoxSizeMode.Anchor = System.Windows.Forms.AnchorStyles.Top
         Me._comboBoxSizeMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
         Me._comboBoxSizeMode.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me._comboBoxSizeMode.Location = New System.Drawing.Point(403, 36)
         Me._comboBoxSizeMode.Name = "_comboBoxSizeMode"
         Me._comboBoxSizeMode.Size = New System.Drawing.Size(95, 21)
         Me._comboBoxSizeMode.TabIndex = 6
         '
         '_buttonNext
         '
         Me._buttonNext.Anchor = System.Windows.Forms.AnchorStyles.Top
         Me._buttonNext.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me._buttonNext.Location = New System.Drawing.Point(785, 36)
         Me._buttonNext.Name = "_buttonNext"
         Me._buttonNext.Size = New System.Drawing.Size(75, 24)
         Me._buttonNext.TabIndex = 1
         Me._buttonNext.Text = "Next"
         '
         '_buttonPrevious
         '
         Me._buttonPrevious.Anchor = System.Windows.Forms.AnchorStyles.Top
         Me._buttonPrevious.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me._buttonPrevious.Location = New System.Drawing.Point(785, 67)
         Me._buttonPrevious.Name = "_buttonPrevious"
         Me._buttonPrevious.Size = New System.Drawing.Size(75, 23)
         Me._buttonPrevious.TabIndex = 2
         Me._buttonPrevious.Text = "Previous"
         '
         '_buttonRun
         '
         Me._buttonRun.Anchor = System.Windows.Forms.AnchorStyles.Top
         Me._buttonRun.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me._buttonRun.Location = New System.Drawing.Point(785, 4)
         Me._buttonRun.Name = "_buttonRun"
         Me._buttonRun.Size = New System.Drawing.Size(75, 25)
         Me._buttonRun.TabIndex = 0
         Me._buttonRun.Text = "Run"
         '
         '_listBoxCommands
         '
         Me._listBoxCommands.Anchor = System.Windows.Forms.AnchorStyles.Top
         Me._listBoxCommands.Location = New System.Drawing.Point(505, 36)
         Me._listBoxCommands.Name = "_listBoxCommands"
         Me._listBoxCommands.ScrollAlwaysVisible = True
         Me._listBoxCommands.Size = New System.Drawing.Size(263, 69)
         Me._listBoxCommands.Sorted = True
         Me._listBoxCommands.TabIndex = 5
         '
         '_checkBoxUseRegion
         '
         Me._checkBoxUseRegion.Anchor = System.Windows.Forms.AnchorStyles.Left
         Me._checkBoxUseRegion.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me._checkBoxUseRegion.Location = New System.Drawing.Point(19, 10)
         Me._checkBoxUseRegion.Name = "_checkBoxUseRegion"
         Me._checkBoxUseRegion.Size = New System.Drawing.Size(104, 14)
         Me._checkBoxUseRegion.TabIndex = 4
         Me._checkBoxUseRegion.Text = "Use Region"
         '
         '_checkBoxProgress
         '
         Me._checkBoxProgress.Anchor = System.Windows.Forms.AnchorStyles.Top
         Me._checkBoxProgress.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me._checkBoxProgress.Location = New System.Drawing.Point(785, 94)
         Me._checkBoxProgress.Name = "_checkBoxProgress"
         Me._checkBoxProgress.Size = New System.Drawing.Size(199, 25)
         Me._checkBoxProgress.TabIndex = 3
         Me._checkBoxProgress.Text = "Use Progress Bar"
         '
         '_panelBefore
         '
         Me._panelBefore.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
         Me._panelBefore.Controls.Add(Me._labelBeforeInfo)
         Me._panelBefore.Controls.Add(Me._panelBeforeControls)
         Me._panelBefore.Dock = System.Windows.Forms.DockStyle.Left
         Me._panelBefore.Location = New System.Drawing.Point(0, 0)
         Me._panelBefore.Name = "_panelBefore"
         Me._panelBefore.Size = New System.Drawing.Size(336, 309)
         Me._panelBefore.TabIndex = 2
         '
         '_labelBeforeInfo
         '
         Me._labelBeforeInfo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
         Me._labelBeforeInfo.Dock = System.Windows.Forms.DockStyle.Bottom
         Me._labelBeforeInfo.Location = New System.Drawing.Point(0, 241)
         Me._labelBeforeInfo.Name = "_labelBeforeInfo"
         Me._labelBeforeInfo.Size = New System.Drawing.Size(332, 64)
         Me._labelBeforeInfo.TabIndex = 1
         Me._labelBeforeInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
         '
         '_panelBeforeControls
         '
         Me._panelBeforeControls.Controls.Add(Me._buttonBeforePageLast)
         Me._panelBeforeControls.Controls.Add(Me._buttonBeforePageNext)
         Me._panelBeforeControls.Controls.Add(Me._labelBeforePage)
         Me._panelBeforeControls.Controls.Add(Me._buttonBeforePagePrevious)
         Me._panelBeforeControls.Controls.Add(Me._buttonBeforePageFirst)
         Me._panelBeforeControls.Controls.Add(Me._labelBefore)
         Me._panelBeforeControls.Dock = System.Windows.Forms.DockStyle.Top
         Me._panelBeforeControls.Location = New System.Drawing.Point(0, 0)
         Me._panelBeforeControls.Name = "_panelBeforeControls"
         Me._panelBeforeControls.Size = New System.Drawing.Size(332, 40)
         Me._panelBeforeControls.TabIndex = 0
         '
         '_buttonBeforePageLast
         '
         Me._buttonBeforePageLast.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me._buttonBeforePageLast.Location = New System.Drawing.Point(287, 8)
         Me._buttonBeforePageLast.Name = "_buttonBeforePageLast"
         Me._buttonBeforePageLast.Size = New System.Drawing.Size(33, 23)
         Me._buttonBeforePageLast.TabIndex = 9
         Me._buttonBeforePageLast.Text = ">|"
         '
         '_buttonBeforePageNext
         '
         Me._buttonBeforePageNext.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me._buttonBeforePageNext.Location = New System.Drawing.Point(256, 8)
         Me._buttonBeforePageNext.Name = "_buttonBeforePageNext"
         Me._buttonBeforePageNext.Size = New System.Drawing.Size(31, 23)
         Me._buttonBeforePageNext.TabIndex = 8
         Me._buttonBeforePageNext.Text = ">"
         '
         '_labelBeforePage
         '
         Me._labelBeforePage.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
         Me._labelBeforePage.Location = New System.Drawing.Point(160, 8)
         Me._labelBeforePage.Name = "_labelBeforePage"
         Me._labelBeforePage.Size = New System.Drawing.Size(96, 23)
         Me._labelBeforePage.TabIndex = 7
         Me._labelBeforePage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
         '
         '_buttonBeforePagePrevious
         '
         Me._buttonBeforePagePrevious.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me._buttonBeforePagePrevious.Location = New System.Drawing.Point(127, 8)
         Me._buttonBeforePagePrevious.Name = "_buttonBeforePagePrevious"
         Me._buttonBeforePagePrevious.Size = New System.Drawing.Size(33, 23)
         Me._buttonBeforePagePrevious.TabIndex = 6
         Me._buttonBeforePagePrevious.Text = "<"
         '
         '_buttonBeforePageFirst
         '
         Me._buttonBeforePageFirst.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me._buttonBeforePageFirst.Location = New System.Drawing.Point(96, 8)
         Me._buttonBeforePageFirst.Name = "_buttonBeforePageFirst"
         Me._buttonBeforePageFirst.Size = New System.Drawing.Size(31, 23)
         Me._buttonBeforePageFirst.TabIndex = 5
         Me._buttonBeforePageFirst.Text = "|<"
         '
         '_labelBefore
         '
         Me._labelBefore.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
         Me._labelBefore.Location = New System.Drawing.Point(7, 8)
         Me._labelBefore.Name = "_labelBefore"
         Me._labelBefore.Size = New System.Drawing.Size(80, 24)
         Me._labelBefore.TabIndex = 0
         Me._labelBefore.Text = "Before Image"
         Me._labelBefore.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
         '
         '_panelAfter
         '
         Me._panelAfter.AccessibleRole = System.Windows.Forms.AccessibleRole.None
         Me._panelAfter.Controls.Add(Me._labelAfterInfo)
         Me._panelAfter.Controls.Add(Me._panelAfterControls)
         Me._panelAfter.Dock = System.Windows.Forms.DockStyle.Fill
         Me._panelAfter.Location = New System.Drawing.Point(336, 0)
         Me._panelAfter.Name = "_panelAfter"
         Me._panelAfter.Size = New System.Drawing.Size(692, 309)
         Me._panelAfter.TabIndex = 3
         '
         '_labelAfterInfo
         '
         Me._labelAfterInfo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
         Me._labelAfterInfo.Dock = System.Windows.Forms.DockStyle.Bottom
         Me._labelAfterInfo.Location = New System.Drawing.Point(0, 244)
         Me._labelAfterInfo.Name = "_labelAfterInfo"
         Me._labelAfterInfo.Size = New System.Drawing.Size(692, 65)
         Me._labelAfterInfo.TabIndex = 2
         Me._labelAfterInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
         '
         '_panelAfterControls
         '
         Me._panelAfterControls.Controls.Add(Me._buttonAfterPageLast)
         Me._panelAfterControls.Controls.Add(Me._buttonAfterPageNext)
         Me._panelAfterControls.Controls.Add(Me._labelAfterPage)
         Me._panelAfterControls.Controls.Add(Me._buttonAfterPagePrevious)
         Me._panelAfterControls.Controls.Add(Me._buttonAfterPageFirst)
         Me._panelAfterControls.Controls.Add(Me._labelAfter)
         Me._panelAfterControls.Dock = System.Windows.Forms.DockStyle.Top
         Me._panelAfterControls.Location = New System.Drawing.Point(0, 0)
         Me._panelAfterControls.Name = "_panelAfterControls"
         Me._panelAfterControls.Size = New System.Drawing.Size(692, 40)
         Me._panelAfterControls.TabIndex = 1
         '
         '_buttonAfterPageLast
         '
         Me._buttonAfterPageLast.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me._buttonAfterPageLast.Location = New System.Drawing.Point(287, 8)
         Me._buttonAfterPageLast.Name = "_buttonAfterPageLast"
         Me._buttonAfterPageLast.Size = New System.Drawing.Size(33, 23)
         Me._buttonAfterPageLast.TabIndex = 9
         Me._buttonAfterPageLast.Text = ">|"
         '
         '_buttonAfterPageNext
         '
         Me._buttonAfterPageNext.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me._buttonAfterPageNext.Location = New System.Drawing.Point(256, 8)
         Me._buttonAfterPageNext.Name = "_buttonAfterPageNext"
         Me._buttonAfterPageNext.Size = New System.Drawing.Size(31, 23)
         Me._buttonAfterPageNext.TabIndex = 8
         Me._buttonAfterPageNext.Text = ">"
         '
         '_labelAfterPage
         '
         Me._labelAfterPage.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
         Me._labelAfterPage.Location = New System.Drawing.Point(160, 8)
         Me._labelAfterPage.Name = "_labelAfterPage"
         Me._labelAfterPage.Size = New System.Drawing.Size(96, 23)
         Me._labelAfterPage.TabIndex = 7
         Me._labelAfterPage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
         '
         '_buttonAfterPagePrevious
         '
         Me._buttonAfterPagePrevious.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me._buttonAfterPagePrevious.Location = New System.Drawing.Point(127, 8)
         Me._buttonAfterPagePrevious.Name = "_buttonAfterPagePrevious"
         Me._buttonAfterPagePrevious.Size = New System.Drawing.Size(33, 23)
         Me._buttonAfterPagePrevious.TabIndex = 6
         Me._buttonAfterPagePrevious.Text = "<"
         '
         '_buttonAfterPageFirst
         '
         Me._buttonAfterPageFirst.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me._buttonAfterPageFirst.Location = New System.Drawing.Point(96, 8)
         Me._buttonAfterPageFirst.Name = "_buttonAfterPageFirst"
         Me._buttonAfterPageFirst.Size = New System.Drawing.Size(31, 23)
         Me._buttonAfterPageFirst.TabIndex = 5
         Me._buttonAfterPageFirst.Text = "|<"
         '
         '_labelAfter
         '
         Me._labelAfter.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
         Me._labelAfter.Location = New System.Drawing.Point(7, 8)
         Me._labelAfter.Name = "_labelAfter"
         Me._labelAfter.Size = New System.Drawing.Size(80, 24)
         Me._labelAfter.TabIndex = 0
         Me._labelAfter.Text = "After Image"
         Me._labelAfter.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
         '
         'MainForm
         '
         Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
         Me.ClientSize = New System.Drawing.Size(1028, 484)
         Me.Controls.Add(Me._panelAfter)
         Me.Controls.Add(Me._panelBefore)
         Me.Controls.Add(Me._panelControls)
         Me.Controls.Add(Me._panelProgress)
         Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
         Me.Menu = Me._mainMenu
         Me.Name = "MainForm"
         Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
         Me.Text = "MainForm"
         Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
         Me._panelProgress.ResumeLayout(False)
         Me._panelControls.ResumeLayout(False)
         Me._groupBoxRegionMode.ResumeLayout(False)
         Me._groupBoxRegionMode.PerformLayout()
         Me._groupBoxRegion.ResumeLayout(False)
         Me._groupBoxRegion.PerformLayout()
         Me._panelBefore.ResumeLayout(False)
         Me._panelBeforeControls.ResumeLayout(False)
         Me._panelAfter.ResumeLayout(False)
         Me._panelAfterControls.ResumeLayout(False)
         Me.ResumeLayout(False)

      End Sub
#End Region

      ''' <summary>
      ''' The main entry point for the application.
      ''' </summary>
      <STAThread()> _
      Shared Sub Main()
         

         If Not Support.SetLicense() Then
            Return
         End If

         Dim bDocLocked As Boolean = RasterSupport.IsLocked(RasterSupportType.Document)
         If bDocLocked Then
            MessageBox.Show("Document support must be unlocked for this demo!", "Support Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
         End If

         Dim bLocked As Boolean = RasterSupport.IsLocked(RasterSupportType.Medical)
         If bLocked Then
            MessageBox.Show("Medical support must be unlocked for this demo!", "Support Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
         End If

         If bLocked Or bDocLocked Then
            Return
         End If

         Application.EnableVisualStyles()
         Application.DoEvents()

         Application.Run(New MainForm())
      End Sub

      Private _viewerBefore As ImageViewer
      Private _viewerAfter As ImageViewer
      Private _codecs As RasterCodecs
      Private _lastProps As CommandProperties
      Private _runAlready As Boolean
      Private _canClose As Boolean
      Private _canceled As Boolean
      Private _activeControl As Control
      Private _allowEventDuringProcess As Boolean

      'The SizeModeItem structure is used to determine 
      'how to fit the image in the viewer
      Private Structure SizeModeItem
         Private _sizeMode As ControlSizeMode
         Private _name As String

         Public Sub New(ByVal sizeMode_Renamed As ControlSizeMode, ByVal name As String)
            _sizeMode = sizeMode_Renamed
            _name = name
         End Sub

         Public ReadOnly Property SizeMode() As ControlSizeMode
            Get
               Return _sizeMode
            End Get
         End Property

         Public Overrides Function ToString() As String
            Return _name
         End Function
      End Structure

      Private _addMagicWand As ImageViewerAddMagicWandInteractivMode

      Public Property AddMagicWandMode As ImageViewerAddMagicWandInteractivMode
         Get
            Return _addMagicWand
         End Get
         Set(value As ImageViewerAddMagicWandInteractivMode)
            _addMagicWand = value
         End Set
      End Property

      'Use this function to check if the value is 
      'between minimum and maximum
      Public Shared Function IsValidNumber(ByVal OrgStr As String, ByVal minVal As Single, ByVal maxVal As Single) As String
         Dim str As String = ""

         For Each c1 As Char In OrgStr
            If Char.IsNumber(c1) Then
               str &= c1.ToString()
            End If
         Next c1

         If str <> "" Then
            If Single.Parse(str) < minVal Then
               str = minVal.ToString()
            End If

            If Single.Parse(str) > maxVal Then
               str = maxVal.ToString()
            End If
         End If

         If str = "" Then
            str = minVal.ToString()
         End If

         Return str
      End Function

      'Create the Before and After viewers, fill the lists 
      'and set the default values
      Private Sub InitClass()
         _canClose = True

         Messager.Caption = "LEADTOOLS for .NET VB Image Processing Demo"
         Text = Messager.Caption

         _codecs = New RasterCodecs()

         _viewerBefore = New ImageViewer()
         _viewerBefore.BackColor = Color.DarkCyan
         _viewerBefore.Dock = DockStyle.Fill
         _viewerBefore.ViewHorizontalAlignment = ControlAlignment.Center
         _viewerBefore.ViewVerticalAlignment = ControlAlignment.Center
         _panelBefore.Controls.Add(_viewerBefore)
         _viewerBefore.BringToFront()
         AddHandler _viewerBefore.MouseMove, AddressOf _viewer_MouseMove
         AddHandler _viewerBefore.MouseDown, AddressOf _viewer_MouseDown
         AddHandler _viewerBefore.MouseUp, AddressOf _viewer_MouseUp

         _addRegion = New ImageViewerAddRegionInteractiveMode()
         _addRegion.AutoRegionToFloater = False
         AddHandler _addRegion.WorkCompleted, AddressOf viewerBefore_InteractiveModeEnded
         _magnifyGlassInteractiveMode = New ImageViewerMagnifyGlassInteractiveMode()

         _noneInteractiveMode = New ImageViewerNoneInteractiveMode()

         _panZoomInteractiveMode = New ImageViewerPanZoomInteractiveMode()
         _panZoomInteractiveMode.MouseButtons = Windows.Forms.MouseButtons.Left

         AddMagicWandMode = New ImageViewerAddMagicWandInteractivMode()
         AddMagicWandMode.Threshold = 50
         AddMagicWandMode.AutoItemMode = ImageViewerAutoItemMode.AutoSetActive
         AddMagicWandMode.WorkOnBounds = True
         AddMagicWandMode.MagicWandRegionCombineMode = RegionCombineMode
         AddHandler AddMagicWandMode.WorkCompleted, AddressOf _addMagicWand_WorkCompleted

         _magnifyGlassInteractiveModeViewerAfter = New ImageViewerMagnifyGlassInteractiveMode()
         _noneInteractiveModeViewerAfter = New ImageViewerNoneInteractiveMode()

         _viewerBefore.InteractiveModes.BeginUpdate()
         _viewerBefore.InteractiveModes.Add(_addRegion)
         _viewerBefore.InteractiveModes.Add(AddMagicWandMode)
         _viewerBefore.InteractiveModes.Add(_magnifyGlassInteractiveMode)
         _viewerBefore.InteractiveModes.Add(_noneInteractiveMode)
         _viewerBefore.InteractiveModes.Add(_panZoomInteractiveMode)
         _viewerBefore.InteractiveModes.EndUpdate()

         _viewerAfter = New ImageViewer()
         _viewerAfter.BackColor = _viewerBefore.BackColor
         _viewerAfter.Dock = _viewerBefore.Dock
         _viewerAfter.InteractiveModes.Clear()
         _viewerAfter.ViewHorizontalAlignment = _viewerBefore.ViewHorizontalAlignment
         _viewerAfter.ViewVerticalAlignment = _viewerBefore.ViewVerticalAlignment
         AddHandler _viewerAfter.MouseDown, AddressOf _viewer_MouseDown
         AddHandler _viewerAfter.MouseMove, AddressOf _viewer_MouseMove
         AddHandler _viewerAfter.MouseUp, AddressOf _viewer_MouseUp

         _viewerAfter.InteractiveModes.BeginUpdate()
         _viewerAfter.InteractiveModes.Add(_magnifyGlassInteractiveModeViewerAfter)
         _viewerAfter.InteractiveModes.Add(_noneInteractiveModeViewerAfter)
         _viewerAfter.InteractiveModes.EndUpdate()

         _panelAfter.Controls.Add(_viewerAfter)
         _viewerAfter.BringToFront()

         _toolTip = New ToolTip()

         _flags = RasterPaletteWindowLevelFlags.Logarithmic Or RasterPaletteWindowLevelFlags.DicomStyle Or RasterPaletteWindowLevelFlags.Outside

         DisableInteractiveMode(True)
         _viewerBefore.InteractiveModes.EnableById(_noneInteractiveMode.Id)
         _viewerAfter.InteractiveModes.EnableById(_noneInteractiveModeViewerAfter.Id)

         _viewerBefore.Zoom(ControlSizeMode.ActualSize, 1, _viewerBefore.DefaultZoomOrigin)

         Dim items As SizeModeItem() = {New SizeModeItem(ControlSizeMode.ActualSize, "ActualSize"), New SizeModeItem(ControlSizeMode.Fit, "Fit"), New SizeModeItem(ControlSizeMode.FitWidth, "Fit Width"), New SizeModeItem(ControlSizeMode.Stretch, "Stretch")}

         For Each i As SizeModeItem In items
            _comboBoxSizeMode.Items.Add(i)
            If i.SizeMode = _viewerBefore.SizeMode Then
               _comboBoxSizeMode.SelectedItem = i
            End If
         Next i

         For Each i As CommandNamespace In CommandNamespace.Namespaces
            _comboBoxNamespace.Items.Add(i)
         Next i

         _checkBoxProgress.Checked = True

         DoResize()

         _lastProps = CommandProperties.Empty
         _runAlready = False

         _isMagGlass = False

         _menuItemMagGlassStart.Checked = False
         _menuItemMagGlassStop.Checked = True

         _comboBoxNamespace.SelectedIndex = 0
         RegionCombineMode = RasterRegionCombineMode.Set

         AddMagicWand = False
         FreeHandRgn = False
      End Sub

      Private Sub _addMagicWand_WorkCompleted(sender As Object, e As EventArgs)

         If (_viewerBefore.Image.HasRegion And Not (_viewerAfter.Image Is Nothing)) Then
            Dim RegionData As Byte() = RasterRegionConverter.GetGdiRegionData(_viewerBefore.Image, Nothing)
            RasterRegionConverter.AddGdiDataToRegion(_viewerAfter.Image, Nothing, RegionData, 0, RasterRegionCombineMode.Set)
            AddMagicWand = _radioButtonMagicWand.Checked
         End If

      End Sub

      Private Sub DisableInteractiveMode(viewer As Boolean)
         For Each mode As ImageViewerInteractiveMode In _viewerBefore.InteractiveModes
            mode.IsEnabled = False
         Next mode
         If (viewer) Then
            For Each mode As ImageViewerInteractiveMode In _viewerAfter.InteractiveModes
               mode.IsEnabled = False
            Next mode
         End If
      End Sub

      'Cleanup the images
      Private Sub CleanUp()
         If Not _viewerBefore.Image Is Nothing Then
            _viewerBefore.Image = Nothing
         End If

         If Not _viewerAfter.Image Is Nothing Then
            _viewerAfter.Image = Nothing
         End If
      End Sub

      'Terminate the application
      Private Sub _menuItemFileExit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _menuItemFileExit.Click
         Close()
      End Sub

      Private Sub _menuItemHelpAbout_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _menuItemHelpAbout.Click
         Using aboutDialog As New AboutDialog("Image Processing", ProgrammingInterface.VB)
            aboutDialog.ShowDialog(Me)
         End Using
      End Sub

      Private Sub MainForm_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Resize
         DoResize()
      End Sub

      Private Sub DoResize()
         _panelBefore.Width = CType(ClientSize.Width / 2, Integer)
      End Sub

      Private Sub _checkBoxProgress_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _checkBoxProgress.CheckedChanged
         _panelProgress.Visible = _checkBoxProgress.Checked
      End Sub

      Private Sub _listBoxCommands_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _listBoxCommands.SelectedIndexChanged
         _isViewerBefore = True
         UpdateImageValues()
         If (Not _checkBoxUseRegion.Checked) Then
            If Not _viewerBefore.Image Is Nothing AndAlso _viewerBefore.Image.HasRegion Then
               _viewerBefore.Image.MakeRegionEmpty()
            End If

            If Not _viewerAfter.Image Is Nothing AndAlso _viewerAfter.Image.HasRegion Then
               _viewerAfter.Image.MakeRegionEmpty()
            End If
         End If

         PrepareCommand()

         _isWLImage = False

         Try
            If _viewerBefore.Image.GrayscaleMode <> RasterGrayscaleMode.None Then
               Select Case _viewerBefore.Image.BitsPerPixel
                  Case 8
                     _currentPalette = _viewerBefore.Image.GetPalette()
                     _LUTSize = 256
                     _minValue = 0
                     _maxValue = 255
                     _isWLImage = True
                  Case 12, 16
                     _viewerBefore.Image.UseLookupTable = True
                     _currentPalette = _viewerBefore.Image.GetLookupTable()
                     _highBit = _viewerBefore.Image.HighBit
                     If _highBit = -1 Then
                        _highBit = _viewerBefore.Image.BitsPerPixel - 1
                     End If
                     If _currentPalette Is Nothing Then
                        _LUTSize = CInt(Math.Pow(2, _highBit + 1))
                        If (_viewerBefore.Image.Signed) Then
                           _maxValue = CInt(_LUTSize / 2 - 1)
                        Else
                           _maxValue = _LUTSize - 1
                        End If
                        If (_viewerBefore.Image.Signed) Then
                           _minValue = CInt(-_LUTSize / 2)
                        Else
                           _minValue = 0
                        End If
                     Else
                        _LUTSize = _currentPalette.Length
                        Dim minMaxValueCmd As MinMaxValuesCommand = New MinMaxValuesCommand()
                        minMaxValueCmd.Run(_viewerBefore.Image)
                        _maxValue = minMaxValueCmd.MaximumValue
                        _minValue = minMaxValueCmd.MinimumValue
                     End If
                     _isWLImage = True
               End Select
               If ((_maxValue - _minValue) / 1000 > 0) Then
                  _scale = CInt((_maxValue - _minValue) / 1000)
               Else
                  _scale = 1
               End If
               _maxWidth = CInt(Math.Pow(2, _viewerBefore.Image.BitsPerPixel))
               _minWidth = 1
               _maxLevel = CInt(Math.Pow(2, _viewerBefore.Image.BitsPerPixel) - 1)
               _minLevel = CInt(Math.Pow(2, _viewerBefore.Image.BitsPerPixel)) * -1 + 1
               _windowLevelCenter = CInt((_maxValue - _minValue) / 2)
               _windowLevelWidth = _maxValue - _minValue
               If _viewerBefore.Image.Signed Then
                  _flags = _flags Or RasterPaletteWindowLevelFlags.Signed
               End If
            End If
         Catch ex As Exception

         End Try
      End Sub

      Private Sub _listBoxCommands_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles _listBoxCommands.DoubleClick
         If Not _listBoxCommands.SelectedItem Is Nothing Then
            Run()
         End If
      End Sub

      'Load the Before and After images and set the default region
      'on the viewers
      Private Sub PrepareCommand()
         Dim r As RasterRegion = Nothing
         Try
            Dim props As CommandProperties = CType(_listBoxCommands.SelectedItem, CommandProperties)
            Dim loadBeforeImage As Boolean = True 'false
            Dim loadAfterImage As Boolean = True 'false
            Dim cloneAfterImage As Boolean = False
            Dim Regiondata As Byte() = Nothing

            If props.BeforeImage <> _lastProps.BeforeImage Then
               loadBeforeImage = True
            End If
            If _runAlready OrElse loadBeforeImage OrElse _lastProps.AfterImage <> props.AfterImage Then
               If props.BeforeImage <> props.AfterImage Then
                  loadAfterImage = True
               Else
                  cloneAfterImage = True
               End If
            End If

            If Not _viewerBefore.Image Is Nothing Then
               If _viewerBefore.Image.HasRegion Then
                  Regiondata = RasterRegionConverter.GetGdiRegionData(_viewerBefore.Image, Nothing)

               End If
            End If

            If loadBeforeImage Then
               Using wait As WaitCursor = New WaitCursor()
                  'Get the image file name for this command
                  Dim imageFileName As String = CommandProperties.GetImageNameFileName(props.BeforeImage)
                  'Load the Before image
                  Dim BeforeImageW As Integer = 0
                  Dim BeforeImageH As Integer = 0

                  If Not _viewerBefore.Image Is Nothing Then
                     BeforeImageW = _viewerBefore.Image.Width
                     BeforeImageH = _viewerBefore.Image.Height
                  End If

                  If Not (_viewerBefore.Image Is Nothing) Then
                     If _viewerBefore.Image.HasRegion Then
                        r = _viewerBefore.Image.GetRegion(Nothing)
                     End If

                     _viewerBefore.Image.Dispose()
                  End If


                  _viewerBefore.Image = _codecs.Load(imageFileName, 0, CodecsLoadByteOrder.BgrOrGray, 1, -1)

                  If _isWLImage Then
                     _isViewerBefore = True
                     ChangeThePalette()
                  End If

                  If (Not Regiondata Is Nothing) Then
                     If (_viewerBefore.Image.Width < BeforeImageW) OrElse (_viewerBefore.Image.Height < BeforeImageH) Then
                        _checkBoxUseRegion.Checked = False
                        _checkBoxUseRegion.Checked = True

                     Else
                        RasterRegionConverter.AddGdiDataToRegion(_viewerBefore.Image, Nothing, Regiondata, 0, RasterRegionCombineMode.Set)
                     End If
                  End If
               End Using
            End If

            If loadAfterImage Then
               Using wait As WaitCursor = New WaitCursor()
                  If props.AfterImage <> CommandImage.None Then
                     'Get the image file name for this command
                     Dim imageFileName As String = CommandProperties.GetImageNameFileName(props.AfterImage)
                     'Load the After image
                     Dim BeforeImageW As Integer = 0
                     Dim BeforeImageH As Integer = 0

                     If Not _viewerAfter.Image Is Nothing Then
                        BeforeImageW = _viewerAfter.Image.Width
                        BeforeImageH = _viewerAfter.Image.Height
                     End If

                     If Not (_viewerAfter.Image Is Nothing) Then
                        _viewerAfter.Image.Dispose()
                     End If


                     _viewerAfter.Image = _codecs.Load(imageFileName)

                     If _isWLImage Then
                        _isViewerBefore = False
                        ChangeThePalette()
                     End If

                  Else
                     _viewerAfter.Image = Nothing
                  End If
               End Using
            End If

            If cloneAfterImage Then
               _viewerAfter.Image = _viewerBefore.Image.Clone()
            End If

            If loadBeforeImage Then
               If _checkBoxUseRegion.Checked Then

                  If Not (r Is Nothing) Then
                     If (_viewerBefore.Image Is Nothing) Then
                        _viewerBefore.Image.SetRegion(Nothing, r, RasterRegionCombineMode.Set)
                     End If

                     If (_viewerAfter.Image Is Nothing) Then
                        _viewerAfter.Image.SetRegion(Nothing, r, RasterRegionCombineMode.Set)
                     End If

                  End If
               End If
            End If


            _lastProps = props

            UpdatePages(_viewerBefore.Image, _buttonBeforePageFirst, _buttonBeforePagePrevious, _buttonBeforePageNext, _buttonBeforePageLast, _labelBeforePage)
            UpdatePages(_viewerAfter.Image, _buttonAfterPageFirst, _buttonAfterPagePrevious, _buttonAfterPageNext, _buttonAfterPageLast, _labelAfterPage)

            _checkBoxOptionsDialog.Enabled = props.HasDialog
            '}
         Catch ex As Exception
            Messager.ShowError(Me, ex)
         Finally
            _runAlready = False
            UpdateImageInformation()
            If _isWLImage Then
               UpdateImageValues()
               Try
                  If _viewerBefore.Image.GrayscaleMode <> RasterGrayscaleMode.None Then
                     Select Case _viewerBefore.Image.BitsPerPixel
                        Case 8
                           _currentPalette = _viewerBefore.Image.GetPalette()
                           _LUTSize = 256
                           _minValue = 0
                           _maxValue = 255
                           _isWLImage = True
                           Exit Select
                        Case 12, 16
                           _viewerBefore.Image.UseLookupTable = True
                           _currentPalette = _viewerBefore.Image.GetLookupTable()
                           _highBit = _viewerBefore.Image.HighBit
                           If _highBit = -1 Then
                              _highBit = _viewerBefore.Image.BitsPerPixel - 1
                           End If
                           If _currentPalette Is Nothing Then
                              _LUTSize = CInt(Math.Pow(2, _highBit + 1))
                              _maxValue = CInt(If((_viewerBefore.Image.Signed), _LUTSize / 2 - 1, _LUTSize - 1))
                              _minValue = CInt(If((_viewerBefore.Image.Signed), -_LUTSize / 2, 0))
                           Else
                              _LUTSize = _currentPalette.Length
                              Dim minMaxValueCmd As New MinMaxValuesCommand()
                              minMaxValueCmd.Run(_viewerBefore.Image)
                              _maxValue = minMaxValueCmd.MaximumValue
                              _minValue = minMaxValueCmd.MinimumValue
                           End If
                           _isWLImage = True
                           Exit Select
                     End Select
                     _scale = CInt(If(((_maxValue - _minValue) / 1000 > 0), (_maxValue - _minValue) / 1000, 1))
                     _maxWidth = CInt(Math.Pow(2, _viewerBefore.Image.BitsPerPixel))
                     _minWidth = 1
                     _maxLevel = CInt(Math.Pow(2, _viewerBefore.Image.BitsPerPixel)) - 1
                     _minLevel = CInt(Math.Pow(2, _viewerBefore.Image.BitsPerPixel)) * -1 + 1
                     _windowLevelCenter = CInt((_maxValue - _minValue) / 2)
                     _windowLevelWidth = _maxValue - _minValue
                     If _viewerBefore.Image.Signed Then
                        _flags = _flags Or RasterPaletteWindowLevelFlags.Signed
                     End If
                  End If

                  _isViewerBefore = True
                  ChangeThePalette()
                  _isViewerBefore = False
                  ChangeThePalette()
               Catch ex As Exception
               End Try
            End If
         End Try
      End Sub

      Private Sub UpdateImageInformation()
         SetInformation(_labelBeforeInfo, _viewerBefore.Image)
         SetInformation(_labelAfterInfo, _viewerAfter.Image)
      End Sub
      'Set and display the image information
      Private Sub SetInformation(ByVal label As Label, ByVal image As RasterImage)
         If Not image Is Nothing Then
            Dim sb As StringBuilder = New StringBuilder()
            sb.Append(String.Format("Size: {0} by {1} pixels{2}", image.Width, image.Height, Environment.NewLine))
            sb.Append(String.Format("Bits/Pixel: {0}{1}", image.BitsPerPixel, Environment.NewLine))
            sb.Append(String.Format("ViewPerspective: {0}", image.ViewPerspective))
            label.Text = sb.ToString()
         Else
            label.Text = String.Empty
         End If
      End Sub

      Private Sub UpdatePages(ByVal image As RasterImage, ByVal buttonFirst As Button, ByVal buttonPrevious As Button, ByVal buttonNext As Button, ByVal buttonLast As Button, ByVal labelPage As Label)
         buttonFirst.Visible = Not image Is Nothing AndAlso image.PageCount > 1
         buttonFirst.Enabled = Not image Is Nothing AndAlso image.Page > 1
         buttonPrevious.Visible = Not image Is Nothing AndAlso image.PageCount > 1
         buttonPrevious.Enabled = Not image Is Nothing AndAlso image.Page > 1
         buttonNext.Visible = Not image Is Nothing AndAlso image.PageCount > 1
         buttonNext.Enabled = Not image Is Nothing AndAlso image.Page < image.PageCount
         buttonLast.Visible = Not image Is Nothing AndAlso image.PageCount > 1
         buttonLast.Enabled = Not image Is Nothing AndAlso image.Page < image.PageCount
         labelPage.Visible = Not image Is Nothing AndAlso image.PageCount > 1
         If Not image Is Nothing Then
            labelPage.Text = String.Format("Page {0}:{1}", image.Page, image.PageCount)
         Else
            labelPage.Text = String.Empty
         End If
      End Sub
      'Enable and Disable regions options
      Private Sub _checkBoxUseRegion_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _checkBoxUseRegion.CheckedChanged
         If _checkBoxUseRegion.Checked Then
            _groupBoxRegion.Enabled = True
            _groupBoxRegionMode.Enabled = True
            _radioButtonRectangle.Checked = True
            _radioButtonSingle.Checked = True


            If Not (_viewerBefore.Image Is Nothing) Then
               _viewerBefore.Image.MakeRegionEmpty()
               _viewerBefore.Image.AddRectangleToRegion(Nothing, New LeadRect(_viewerBefore.Image.Width \ 4, _viewerBefore.Image.Height \ 4, _viewerBefore.Image.Width \ 2, _viewerBefore.Image.Height \ 2), RasterRegionCombineMode.Set)
            End If

            If Not (_viewerAfter.Image Is Nothing) Then
               _viewerAfter.Image.AddRectangleToRegion(Nothing, New LeadRect(_viewerAfter.Image.Width \ 4, _viewerAfter.Image.Height \ 4, _viewerAfter.Image.Width \ 2, _viewerAfter.Image.Height \ 2), RasterRegionCombineMode.Set)
            End If

            PrepareCommand()
         Else
            _viewerBefore.Image.MakeRegionEmpty()
            _radioButtonRectangle.Checked = True
            _radioButtonSingle.Checked = True
            _groupBoxRegion.Enabled = False
            _groupBoxRegionMode.Enabled = False
            DisableInteractiveMode(False)
            _viewerBefore.InteractiveModes.EnableById(_noneInteractiveMode.Id)
            If Not _viewerAfter.Image Is Nothing Then
               _viewerAfter.Image.MakeRegionEmpty()
            End If
         End If
      End Sub

      Private Sub viewerBefore_InteractiveModeEnded(ByVal sender As Object, ByVal e As EventArgs)
         Dim Rect As Rectangle = Leadtools.Demos.Converters.ConvertRect(_viewerBefore.Image.GetRegionBounds(Nothing))

         If _viewerBefore.Image.HasRegion Then
            Dim RegionData As Byte() = RasterRegionConverter.GetGdiRegionData(_viewerBefore.Image, Nothing)
            If Not _viewerAfter.Image Is Nothing Then
               RasterRegionConverter.AddGdiDataToRegion(_viewerAfter.Image, Nothing, RegionData, 0, RasterRegionCombineMode.Set)
            End If
         End If
      End Sub


      Private Sub _comboBoxNamespace_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _comboBoxNamespace.SelectedIndexChanged
         _listBoxCommands.Items.Clear()

         Dim Temp As CommandProperties = New CommandProperties(GetType(ClearCommand), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image1_jpg, False)
         Dim ns As CommandNamespace = CType(_comboBoxNamespace.SelectedItem, CommandNamespace)

         For Each i As CommandProperties In ns.Properties
            _listBoxCommands.Items.Add(i)
         Next i
         If ns.Properties(1).Type Is Temp.Type Then
            Dim str As String = "Add Border"
            _listBoxCommands.Items.Add(New CommandProperties(str.GetType(), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image1_jpg, False))
         End If
         _runAlready = True
         _listBoxCommands.SelectedIndex = 0
      End Sub

      Private Sub _comboBoxSizeMode_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _comboBoxSizeMode.SelectedIndexChanged
         Dim item As SizeModeItem = CType(_comboBoxSizeMode.SelectedItem, SizeModeItem)
         If _viewerBefore.SizeMode <> item.SizeMode Then
            _viewerBefore.Zoom(item.SizeMode, 1, _viewerBefore.DefaultZoomOrigin)
         End If
      End Sub

      Private Sub _buttonZoom_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _buttonZoomOut.Click, _buttonZoomIn.Click, _buttonZoomNone.Click
         If sender Is _buttonZoomNone Then
            _viewerBefore.Zoom(_viewerBefore.SizeMode, 1, _viewerBefore.DefaultZoomOrigin)
         ElseIf sender Is _buttonZoomIn Then
            Dim scaleFactor As Double = _viewerBefore.ScaleFactor
            scaleFactor *= 2
            ' making sure not to enlarge its size more than 32 times.
            If scaleFactor > 32 Then
               scaleFactor = 32
            End If
            _viewerBefore.Zoom(ControlSizeMode.None, scaleFactor, _viewerBefore.DefaultZoomOrigin)
         ElseIf sender Is _buttonZoomOut Then
            Dim scaleFactor As Double = _viewerBefore.ScaleFactor
            scaleFactor /= 2
            ' making sure that the image doesn't become too small.
            If scaleFactor < 0.001 Then
               scaleFactor = 0.001F
            End If
            _viewerBefore.Zoom(ControlSizeMode.None, scaleFactor, _viewerBefore.DefaultZoomOrigin)

         End If
      End Sub

      Private Sub _buttonRun_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _buttonRun.Click
         _isViewerBefore = True
         UpdateImageValues()
         Run()
      End Sub

      Private Sub _buttonNext_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _buttonNext.Click
         Dim MyRegion As Byte() = Nothing
         If (Not _checkBoxUseRegion.Checked) Then
            If Not _viewerBefore.Image Is Nothing AndAlso _viewerBefore.Image.HasRegion Then
               _viewerBefore.Image.MakeRegionEmpty()
            End If

            If Not _viewerAfter.Image Is Nothing AndAlso _viewerAfter.Image.HasRegion Then
               _viewerAfter.Image.MakeRegionEmpty()
            End If
         Else
            MyRegion = RasterRegionConverter.GetGdiRegionData(_viewerBefore.Image, Nothing)
            If Not _viewerBefore.Image Is Nothing AndAlso _viewerBefore.Image.HasRegion Then
               _viewerBefore.Image.MakeRegionEmpty()
            End If
            RasterRegionConverter.AddGdiDataToRegion(_viewerBefore.Image, Nothing, MyRegion, 0, RasterRegionCombineMode.Set)

            If Not _viewerAfter.Image Is Nothing AndAlso _viewerAfter.Image.HasRegion Then
               _viewerAfter.Image.MakeRegionEmpty()
            End If

            If Not _viewerAfter.Image Is Nothing Then
               RasterRegionConverter.AddGdiDataToRegion(_viewerAfter.Image, Nothing, MyRegion, 0, RasterRegionCombineMode.Set)
            End If
         End If
         If _listBoxCommands.SelectedIndex < (_listBoxCommands.Items.Count - 1) Then
            _listBoxCommands.SelectedIndex += 1
         Else
            _listBoxCommands.SelectedIndex = 0
         End If

         Run()
      End Sub

      Private Sub _buttonPrevious_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _buttonPrevious.Click
         If _listBoxCommands.SelectedIndex > 0 Then
            _listBoxCommands.SelectedIndex -= 1
         Else
            _listBoxCommands.SelectedIndex = _listBoxCommands.Items.Count - 1
         End If

         Run()
      End Sub

      Private Sub _buttonBeforePage_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _buttonBeforePageLast.Click, _buttonBeforePageNext.Click, _buttonBeforePagePrevious.Click, _buttonBeforePageFirst.Click
         Try
            If sender Is _buttonBeforePageFirst Then
               _viewerBefore.Image.Page = 1
            ElseIf sender Is _buttonBeforePagePrevious Then
               _viewerBefore.Image.Page -= 1
            ElseIf sender Is _buttonBeforePageNext Then
               _viewerBefore.Image.Page += 1
            ElseIf sender Is _buttonBeforePageLast Then
               _viewerBefore.Image.Page = _viewerBefore.Image.PageCount
            End If
         Catch ex As Exception
            Messager.ShowError(Me, ex)
         Finally
            UpdatePages(_viewerBefore.Image, _buttonBeforePageFirst, _buttonBeforePagePrevious, _buttonBeforePageNext, _buttonBeforePageLast, _labelBeforePage)
         End Try
      End Sub

      Private Sub _buttonAfterPage_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _buttonAfterPageLast.Click, _buttonAfterPageNext.Click, _buttonAfterPagePrevious.Click, _buttonAfterPageFirst.Click
         Try
            If sender Is _buttonAfterPageFirst Then
               _viewerAfter.Image.Page = 1
            ElseIf sender Is _buttonAfterPagePrevious Then
               _viewerAfter.Image.Page -= 1
            ElseIf sender Is _buttonAfterPageNext Then
               _viewerAfter.Image.Page += 1
            ElseIf sender Is _buttonAfterPageLast Then
               _viewerAfter.Image.Page = _viewerAfter.Image.PageCount
            End If
         Catch ex As Exception
            Messager.ShowError(Me, ex)
         Finally
            UpdatePages(_viewerAfter.Image, _buttonAfterPageFirst, _buttonAfterPagePrevious, _buttonAfterPageNext, _buttonAfterPageLast, _labelAfterPage)
         End Try
      End Sub

      Private Function Increment(ByVal x As Integer, ByVal lutLen As Integer) As Integer
         Return ((x + 1) Mod lutLen)
      End Function

      Private Function Decrement(ByVal x As Integer, ByVal lutLen As Integer) As Integer
         Return ((x + (lutLen - 1)) Mod lutLen)
      End Function

      Private Function Add(ByVal x As Integer, ByVal y As Integer, ByVal lutLen As Integer) As Integer
         Return ((x + y) Mod lutLen)
      End Function

      Private Sub Run()
         PrepareCommand()

         If _checkBoxProgress.Checked Then
            Progress(False)
         End If

         Try
            Dim UseRegionChecked As Boolean = _checkBoxUseRegion.Checked

            _allowEventDuringProcess = True
            Dim props As CommandProperties = CType(_listBoxCommands.SelectedItem, CommandProperties)

            If props.Type.Name = "String" Then 'Add Border
               Dim SrcImage, backImage As RasterImage
               Dim _codecs As RasterCodecs

               _codecs = New RasterCodecs()

               SrcImage = _viewerBefore.Image.Clone()

               backImage = New RasterImage(RasterMemoryFlags.Conventional, SrcImage.Width + 50, SrcImage.Height + 50, 24, RasterByteOrder.Bgr, RasterViewPerspective.TopLeft, Nothing, IntPtr.Zero, 0)

               Dim Fill As FillCommand = New FillCommand()
               Fill.Color = Leadtools.Demos.Converters.FromGdiPlusColor(Color.Black)
               Fill.Run(backImage)

               Dim Combine As CombineCommand = New CombineCommand()
               Combine.DestinationRectangle = Leadtools.Demos.Converters.ConvertRect(New Rectangle(25, 25, SrcImage.Width, SrcImage.Height))
               Combine.SourcePoint = Leadtools.Demos.Converters.ConvertPoint(New Point(0, 0))
               Combine.SourceImage = SrcImage
               Combine.Run(backImage)

               _viewerAfter.Image = backImage.Clone()

               Return
            Else


               Dim command As RasterCommand = TryCast(Activator.CreateInstance(props.Type), RasterCommand)
               Dim runAfterImage As Boolean = True


               If TypeOf command Is ChangeViewPerspectiveCommand Then
                  Dim cmd As ChangeViewPerspectiveCommand = TryCast(command, ChangeViewPerspectiveCommand)
                  Dim Regiondata As Byte() = Nothing
                  Regiondata = RasterRegionConverter.GetGdiRegionData(_viewerBefore.Image, Nothing)
                  If _checkBoxOptionsDialog.Checked Then
                     Dim ChangeViewPerspectiveDlg As ChangeViewPerspectiveDialog = New ChangeViewPerspectiveDialog()
                     If ChangeViewPerspectiveDlg.ShowDialog(Me) = DialogResult.OK Then
                        cmd.InPlace = True
                        cmd.ViewPerspective = ChangeViewPerspectiveDlg.ChangeViewPerspectivecommand.ViewPerspective
                        cmd.Run(_viewerAfter.Image)
                        RasterRegionConverter.AddGdiDataToRegion(_viewerAfter.Image, Nothing, Regiondata, 0, RasterRegionCombineMode.Set)
                        Return
                     Else
                        Return
                     End If
                  Else
                     cmd.InPlace = True
                     If _viewerBefore.Image.ViewPerspective = RasterViewPerspective.TopLeft Then
                        cmd.ViewPerspective = RasterViewPerspective.BottomLeft
                     Else
                        cmd.ViewPerspective = RasterViewPerspective.TopLeft
                     End If

                     cmd.Run(_viewerAfter.Image)
                     RasterRegionConverter.AddGdiDataToRegion(_viewerAfter.Image, Nothing, Regiondata, 0, RasterRegionCombineMode.Set)
                     Return
                  End If

               ElseIf TypeOf command Is ShearCommand Then
                  _viewerAfter.Image.Dispose()
                  _viewerAfter.Image = _viewerBefore.Image.Clone()
                  _viewerAfter.Image.MakeRegionEmpty()
               ElseIf TypeOf command Is CloneCommand Then
                  Dim cmd As CloneCommand = TryCast(command, CloneCommand)
                  runAfterImage = False
               ElseIf TypeOf command Is RotateCommand Then
                  Dim cmd As RotateCommand = TryCast(command, RotateCommand)

                  If _checkBoxOptionsDialog.Checked Then
                     Dim dlg As RotateDialog = New RotateDialog()

                     If dlg.ShowDialog(Me) = DialogResult.OK Then
                        cmd.Angle = dlg.Angle
                        cmd.Flags = dlg.Flags
                        cmd.FillColor = dlg.FillColor
                     Else
                        Return
                     End If
                  Else
                     cmd.Angle = 45 * 100
                     cmd.FillColor = New RasterColor(255, 255, 255)
                     cmd.Flags = RotateCommandFlags.Bicubic
                  End If
               ElseIf TypeOf command Is ColorResolutionCommand Then
                  Dim cmd As ColorResolutionCommand = TryCast(command, ColorResolutionCommand)

                  If _checkBoxOptionsDialog.Checked Then
                     Dim dlg As ColorResolutionDialog = New ColorResolutionDialog(New ColorResolutionCommand(), _viewerBefore.Image.BitsPerPixel)
                     If dlg.ShowDialog() = DialogResult.OK Then
                        cmd.Mode = dlg.ColorResolutionCommand.Mode
                        cmd.BitsPerPixel = dlg.ColorResolutionCommand.BitsPerPixel
                        cmd.Order = dlg.ColorResolutionCommand.Order
                        cmd.DitheringMethod = dlg.ColorResolutionCommand.DitheringMethod
                        cmd.PaletteFlags = dlg.ColorResolutionCommand.PaletteFlags
                     Else
                        Return
                     End If
                  Else
                     If _viewerBefore.Image.BitsPerPixel = 8 Then
                        cmd.BitsPerPixel = 24
                     Else
                        cmd.BitsPerPixel = 8
                     End If
                  End If
               ElseIf TypeOf command Is CombineFastCommand Then
                  Dim cmd As CombineFastCommand = TryCast(command, CombineFastCommand)
                  cmd.DestinationRectangle = Leadtools.Demos.Converters.ConvertRect(New Rectangle(0, 0, _viewerBefore.Image.Width, _viewerBefore.Image.Height))
                  cmd.SourcePoint = Leadtools.Demos.Converters.ConvertPoint(Point.Empty)
                  cmd.Flags = CombineFastCommandFlags.OperationAverage
                  cmd.DestinationImage = _viewerAfter.Image
                  runAfterImage = False
               ElseIf TypeOf command Is CombineWarpCommand Then
                  Dim cmd As CombineWarpCommand = TryCast(command, CombineWarpCommand)
                  Dim eighth As Integer = CType(_viewerAfter.Image.Width / 8, Integer)
                  Dim pts As LeadPoint() = New LeadPoint() {New LeadPoint(eighth * 2, eighth), New LeadPoint(_viewerAfter.Image.Width - eighth, eighth * 2), New LeadPoint(_viewerAfter.Image.Width - eighth * 2, _viewerAfter.Image.Height - eighth * 2), New LeadPoint(eighth, _viewerAfter.Image.Height - eighth)}
                  cmd.SetDestinationPoints(pts)

                  cmd.SourceRectangle = Leadtools.Demos.Converters.ConvertRect(New Rectangle(0, 0, _viewerBefore.Image.Width, _viewerBefore.Image.Height))
                  cmd.Flags = CombineWarpCommandFlags.Bilinear
                  cmd.DestinationImage = _viewerAfter.Image
                  runAfterImage = False
               ElseIf TypeOf command Is FillCommand Then
                  Dim cmd As FillCommand = TryCast(command, FillCommand)

                  If _checkBoxOptionsDialog.Checked Then
                     Dim dlg As ColorDialog = New ColorDialog()
                     If dlg.ShowDialog() = DialogResult.OK Then
                        cmd.Color = Leadtools.Demos.Converters.FromGdiPlusColor(dlg.Color)
                     Else
                        Return
                     End If
                  Else
                     cmd.Color = Leadtools.Demos.Converters.FromGdiPlusColor(Color.Red)
                  End If
               ElseIf TypeOf command Is CopyDataCommand Then
                  Dim cmd As CopyDataCommand = TryCast(command, CopyDataCommand)
                  cmd.DestinationImage = _viewerAfter.Image
                  runAfterImage = False
               ElseIf TypeOf command Is CopyRectangleCommand Then
                  Dim cmd As CopyRectangleCommand = TryCast(command, CopyRectangleCommand)
                  Dim eighth As Integer = CType(_viewerBefore.Image.Width / 8, Integer)
                  cmd.Rectangle = Leadtools.Demos.Converters.ConvertRect(New Rectangle(eighth, eighth, _viewerBefore.Image.Width - eighth * 2, _viewerBefore.Image.Height - eighth * 2))
                  runAfterImage = False
               ElseIf TypeOf command Is CropCommand Then
                  Dim cmd As CropCommand = TryCast(command, CropCommand)
                  Dim CropDlg As CropDialog = New CropDialog(New CropCommand(), _viewerBefore.Image)
                  If _checkBoxOptionsDialog.Checked Then
                     If CropDlg.ShowDialog(Me) = DialogResult.OK Then
                        cmd.Rectangle = CropDlg.Cropcommand.Rectangle
                     Else
                        Return
                     End If
                  Else
                     Dim eighth As Integer = CType(_viewerBefore.Image.Width / 8, Integer)
                     cmd.Rectangle = Leadtools.Demos.Converters.ConvertRect(New Rectangle(eighth, eighth, _viewerBefore.Image.Width - eighth * 2, _viewerBefore.Image.Height - eighth * 2))
                  End If
               ElseIf TypeOf command Is ResizeCommand Then
                  Dim cmd As ResizeCommand = TryCast(command, ResizeCommand)
                  If _checkBoxOptionsDialog.Checked Then
                     Dim ResizeCommandDlg As ResizeCommandDialog = New ResizeCommandDialog(_viewerBefore.Image)
                     If ResizeCommandDlg.ShowDialog(Me) = DialogResult.OK Then
                        Dim destImage As RasterImage = New RasterImage(RasterMemoryFlags.Conventional, ResizeCommandDlg.ImageWidth, ResizeCommandDlg.ImageHeight, _viewerBefore.Image.BitsPerPixel, _viewerBefore.Image.Order, _viewerBefore.Image.ViewPerspective, _viewerBefore.Image.GetPalette(), IntPtr.Zero, 0)
                        cmd.Flags = ResizeCommandDlg.ResizeCommand.Flags
                        cmd.DestinationImage = destImage

                        AddHandler cmd.Progress, AddressOf command_Progress

                        If _checkBoxProgress.Checked Then
                           AddHandler cmd.Progress, AddressOf command_Progress
                        End If
                        cmd.Run(_viewerBefore.Image)

                        _viewerAfter.Image = destImage.Clone()

                        destImage.Dispose()
                        destImage = Nothing

                        Return
                     Else
                        Return
                     End If
                  Else
                     cmd.DestinationImage = _viewerAfter.Image
                     runAfterImage = False
                  End If
               ElseIf TypeOf command Is SizeCommand Then
                  Dim cmd As SizeCommand = TryCast(command, SizeCommand)
                  If _checkBoxOptionsDialog.Checked Then
                     Dim dlg As ResizeDialog = New ResizeDialog(_viewerBefore.Image.Width, _viewerBefore.Image.Height)
                     If dlg.ShowDialog(Me) = DialogResult.OK Then
                        cmd.Width = dlg.ImageWidth
                        cmd.Height = dlg.ImageHeight
                        cmd.Flags = dlg.Flags
                     Else
                        Return
                     End If
                  Else
                     cmd.Width = CType(_viewerAfter.Image.Width / 2, Integer)
                     cmd.Height = CType(_viewerAfter.Image.Height / 2, Integer)
                  End If
               ElseIf TypeOf command Is AddWeightedCommand Then
                  Dim cmd As AddWeightedCommand = TryCast(command, AddWeightedCommand)
                  cmd.Factor = New Integer(9) {}
                  cmd.Type = AddWeightedCommandType.Average
                  runAfterImage = False
               ElseIf TypeOf command Is AddCommand Then
                  runAfterImage = False
               ElseIf TypeOf command Is AddNoiseCommand Then
                  Dim cmd As AddNoiseCommand = TryCast(command, AddNoiseCommand)
                  If _checkBoxOptionsDialog.Checked Then
                     Dim AddNoiseDlg As AddNoiseDialog = New AddNoiseDialog()

                     If AddNoiseDlg.ShowDialog(Me) = DialogResult.OK Then
                        cmd.Channel = AddNoiseDlg.AddNoisecommand.Channel
                        cmd.Range = AddNoiseDlg.AddNoisecommand.Range
                     Else
                        Return
                     End If

                  Else
                     cmd.Range = 100
                     cmd.Channel = RasterColorChannel.Green
                  End If
               ElseIf TypeOf command Is AverageCommand Then
                  Dim cmd As AverageCommand = TryCast(command, AverageCommand)
                  If _checkBoxOptionsDialog.Checked Then
                     Dim AverageDlg As AverageDialog = New AverageDialog()
                     If AverageDlg.ShowDialog(Me) = DialogResult.OK Then
                        cmd.Dimension = AverageDlg.Dimension
                     Else
                        Return
                     End If

                  Else
                     cmd.Dimension = 3
                  End If
               ElseIf TypeOf command Is MeanShiftCommand Then
                  Dim cmd As MeanShiftCommand = TryCast(command, MeanShiftCommand)
                  cmd.Radius = 5
                  cmd.ColorDistance = 10

               ElseIf TypeOf command Is SigmaCommand Then
                  Dim cmd As SigmaCommand = TryCast(command, SigmaCommand)
                  cmd.Dimension = 10
                  cmd.Sigma = 2
                  cmd.Threshold = 0.2F
                  cmd.Outline = False

               ElseIf TypeOf command Is AnisotropicDiffusionCommand Then
                  Dim cmd As AnisotropicDiffusionCommand = TryCast(command, AnisotropicDiffusionCommand)
                  cmd.Iterations = 20
                  cmd.Smoothing = 1
                  cmd.TimeStep = 200
                  cmd.MinVariation = 0.5F
                  cmd.MaxVariation = 0.8F
                  cmd.EdgeHeight = 4.0F
                  cmd.Update = 10

               ElseIf TypeOf command Is TissueEqualizeCommand Then
                  Dim cmd As TissueEqualizeCommand = TryCast(command, TissueEqualizeCommand)
                  cmd.Flags = TissueEqualizeCommandFlags.UseIntensifyOption
               ElseIf TypeOf command Is AutoSegmentCommand Then

                  Dim cmd As AutoSegmentCommand = TryCast(command, AutoSegmentCommand)
                  Dim rect As Rectangle = New Rectangle(194, 161, 111, 153)
                  cmd.SegmentationRectangle = Leadtools.Demos.Converters.ConvertRect(rect)

               ElseIf TypeOf command Is RakeRemoveCommand Then
                  Dim cmd As RakeRemoveCommand = TryCast(command, RakeRemoveCommand)
                  cmd.MinLength = 50
                  cmd.MinWallHeight = 10
                  cmd.MaxWidth = 3
                  cmd.MaxWallPercent = 25
                  cmd.MaxSideteethLength = 60
                  cmd.MaxMidteethLength = 50
                  cmd.Gaps = 1
                  cmd.Variance = 1
                  cmd.TeethSpacing = 5
                  cmd.AutoFilter = True

                  If _checkBoxProgress.Checked Then
                     AddHandler cmd.Progress, AddressOf command_Progress
                  End If
                  cmd.Run(_viewerAfter.Image)
                  Return
               ElseIf TypeOf command Is ObjectCounterCommand Then
                  Dim cmd As ObjectCounterCommand = TryCast(command, ObjectCounterCommand)


                  If _checkBoxProgress.Checked Then
                     AddHandler cmd.Progress, AddressOf command_Progress
                  End If
                  cmd.Run(_viewerAfter.Image)
                  Messager.ShowInformation(Me, cmd.Count.ToString())
                  Return
               ElseIf TypeOf command Is SliceCommand Then
                  Dim cmd As SliceCommand = TryCast(command, SliceCommand)
                  AddHandler cmd.Slice, AddressOf cmd_Slice
                  cmd.MaximumDeskewAngle = 40
                  cmd.Flags = SliceCommandFlags.WithoutCut Or SliceCommandFlags.Bicubic Or SliceCommandFlags.DeskewImage
                  cmd.FillColor = Leadtools.Demos.Converters.FromGdiPlusColor(Color.Black)
               ElseIf TypeOf command Is EmbossCommand Then
                  Dim cmd As EmbossCommand = TryCast(command, EmbossCommand)
                  Dim EmbossDlg As EmbossDialog = New EmbossDialog()
                  If _checkBoxOptionsDialog.Checked Then
                     If EmbossDlg.ShowDialog(Me) = DialogResult.OK Then
                        cmd.Depth = EmbossDlg.Embosscommand.Depth
                        cmd.Direction = EmbossDlg.Embosscommand.Direction
                     Else
                        Return
                     End If

                  Else
                     cmd.Depth = 0
                     cmd.Direction = EmbossCommandDirection.North
                  End If
               ElseIf TypeOf command Is MedianCommand Then
                  Dim cmd As MedianCommand = TryCast(command, MedianCommand)
                  Dim MedianDlg As MedianDialog = New MedianDialog()
                  If _checkBoxOptionsDialog.Checked Then
                     If MedianDlg.ShowDialog(Me) = DialogResult.OK Then
                        cmd.Dimension = MedianDlg.Mediancommand.Dimension
                     Else
                        Return
                     End If
                  Else

                     cmd.Dimension = 3
                  End If
               ElseIf TypeOf command Is MosaicCommand Then
                  Dim cmd As MosaicCommand = TryCast(command, MosaicCommand)
                  Dim MosaicDlg As MedianDialog = New MedianDialog()
                  MosaicDlg.Text = "Mosaic"
                  If _checkBoxOptionsDialog.Checked Then
                     If MosaicDlg.ShowDialog(Me) = DialogResult.OK Then
                        cmd.Dimension = MosaicDlg.Mediancommand.Dimension
                     Else
                        Return
                     End If
                  Else
                     cmd.Dimension = 2
                  End If
               ElseIf TypeOf command Is SharpenCommand Then
                  Dim cmd As SharpenCommand = TryCast(command, SharpenCommand)
                  Dim SharpenDlg As SharpenDialog = New SharpenDialog()
                  If _checkBoxOptionsDialog.Checked Then
                     If SharpenDlg.ShowDialog(Me) = DialogResult.OK Then
                        cmd.Sharpness = SharpenDlg.Sharpencommand.Sharpness
                     Else
                        Return
                     End If
                  Else
                     cmd.Sharpness = 100
                  End If


               ElseIf TypeOf command Is AutoCropRectangleCommand Then
                  Dim cmd As AutoCropRectangleCommand = TryCast(command, AutoCropRectangleCommand)
                  cmd.Threshold = 0
               ElseIf TypeOf command Is OilifyCommand Then
                  Dim cmd As OilifyCommand = TryCast(command, OilifyCommand)
                  Dim OilifyDlg As OilifyDialog = New OilifyDialog()
                  If _checkBoxOptionsDialog.Checked Then
                     If OilifyDlg.ShowDialog(Me) = DialogResult.OK Then
                        cmd.Dimension = OilifyDlg.Oilifycommand.Dimension
                     Else
                        Return
                     End If
                  Else
                     cmd.Dimension = 1
                  End If
               ElseIf TypeOf command Is MinimumCommand Then
                  Dim cmd As MinimumCommand = TryCast(command, MinimumCommand)
                  If _checkBoxOptionsDialog.Checked Then
                     Dim MinimumDlg As MinimumDialog = New MinimumDialog()
                     If MinimumDlg.ShowDialog(Me) = DialogResult.OK Then
                        cmd.Dimension = MinimumDlg.Dimension
                     Else
                        Return
                     End If
                  Else
                     cmd.Dimension = 1
                  End If
               ElseIf TypeOf command Is MaximumCommand Then
                  Dim cmd As MaximumCommand = TryCast(command, MaximumCommand)
                  If _checkBoxOptionsDialog.Checked Then
                     Dim MinimumDlg As MinimumDialog = New MinimumDialog()
                     MinimumDlg.Text = "Maximum"
                     If MinimumDlg.ShowDialog(Me) = DialogResult.OK Then
                        cmd.Dimension = MinimumDlg.Dimension
                     Else
                        Return
                     End If
                  Else
                     cmd.Dimension = 1
                  End If
               ElseIf TypeOf command Is PicturizeSingleCommand Then
                  Dim cmd As PicturizeSingleCommand = TryCast(command, PicturizeSingleCommand)
                  cmd.CellHeight = 10
                  cmd.CellWidth = 10
                  cmd.LightnessFactor = 0
                  cmd.ThumbImage = _viewerBefore.Image
               ElseIf TypeOf command Is PicturizeListCommand Then
                  Dim cmd As PicturizeListCommand = TryCast(command, PicturizeListCommand)
                  cmd.CellHeight = 20
                  cmd.CellWidth = 20
                  cmd.LightnessFactor = 0
               ElseIf TypeOf command Is ContourFilterCommand Then

                  Dim cmd As ContourFilterCommand = TryCast(command, ContourFilterCommand)
                  If _checkBoxOptionsDialog.Checked Then
                     Dim ContourFilterDlg As ContourFilterDialog = New ContourFilterDialog()
                     If ContourFilterDlg.ShowDialog(Me) = DialogResult.OK Then
                        cmd.Type = ContourFilterDlg.ContourFilterCommand.Type
                        cmd.DeltaDirection = ContourFilterDlg.ContourFilterCommand.DeltaDirection
                        cmd.Threshold = ContourFilterDlg.ContourFilterCommand.Threshold
                        cmd.MaximumError = ContourFilterDlg.ContourFilterCommand.MaximumError
                     Else
                        Return
                     End If
                  Else
                     cmd.Type = ContourFilterCommandType.Thin
                     cmd.Threshold = 5
                     cmd.MaximumError = 20
                     cmd.DeltaDirection = 35

                  End If

                  _viewerAfter.Image.Dispose()
                  _viewerAfter.Image = _viewerBefore.Image.Clone()

                  If _checkBoxProgress.Checked Then
                     AddHandler cmd.Progress, AddressOf command_Progress
                  End If
                  cmd.Run(_viewerAfter.Image)

                  Return
               ElseIf TypeOf command Is SegmentCommand Then
                  Dim cmd As SegmentCommand = TryCast(command, SegmentCommand)
                  cmd.Flags = SegmentCommandFlags.Rgb
                  cmd.Threshold = 25
               ElseIf TypeOf command Is WindCommand Then
                  Dim cmd As WindCommand = TryCast(command, WindCommand)
                  cmd.Dimension = 5
                  cmd.Angle = 0
                  cmd.Opacity = 0
               ElseIf TypeOf command Is RadialWaveCommand Then
                  Dim cmd As RadialWaveCommand = TryCast(command, RadialWaveCommand)
                  cmd.Amplitude = 5
                  cmd.Flags = RadialWaveCommandFlags.Repeat Or RadialWaveCommandFlags.Frequency
                  cmd.Phase = 0
                  cmd.WaveLength = 25
                  If _viewerBefore.Image.HasRegion Then
                     Dim Rect As LeadRect = _viewerBefore.Image.GetRegionBounds(Nothing)
                     cmd.CenterPoint = New LeadPoint(CType((Rect.Right + Rect.Left) / 2, Integer), CType((Rect.Bottom + Rect.Top) / 2, Integer))
                  Else
                     cmd.CenterPoint = New LeadPoint(CType(_viewerBefore.Image.Width / 2, Integer), CType(_viewerBefore.Image.Height / 2, Integer))
                  End If
               ElseIf TypeOf command Is FreeHandShearCommand Then
                  Dim cmd As FreeHandShearCommand = TryCast(command, FreeHandShearCommand)
                  Dim points As LeadPoint() = {New LeadPoint(0, 0), New LeadPoint(3, 10), New LeadPoint(9, -10), New LeadPoint(12, 0)}

                  cmd.Amplitudes = New Integer(12) {}
                  EffectsUtilities.GetCurvePoints(cmd.Amplitudes, points, CurvePointsType.Linear)

                  Dim max As Integer = 0
                  For i As Integer = 0 To 12
                     If max < cmd.Amplitudes(i) Then
                        max = cmd.Amplitudes(i)
                     End If
                  Next i

                  If max <> 0 Then
                     For i As Integer = 0 To 12
                        cmd.Amplitudes(i) = CType((1000 * cmd.Amplitudes(i) / Math.Abs(max)), Integer)
                     Next i
                  End If

                  cmd.Flags = FreeHandShearCommandFlags.Repeat Or FreeHandShearCommandFlags.Horizontal
                  cmd.Scale = 50
                  cmd.FillColor = New RasterColor(0, 0, 0)
               ElseIf TypeOf command Is FreeHandWaveCommand Then
                  Dim cmd As FreeHandWaveCommand = TryCast(command, FreeHandWaveCommand)
                  Dim points As LeadPoint() = {New LeadPoint(0, 0), New LeadPoint(3, 10), New LeadPoint(9, -10), New LeadPoint(12, 0)}

                  cmd.Angle = 4500
                  cmd.Amplitudes = New Integer(12) {}
                  EffectsUtilities.GetCurvePoints(cmd.Amplitudes, points, CurvePointsType.Linear)

                  Dim max As Integer = 0
                  For i As Integer = 0 To 12
                     If max < cmd.Amplitudes(i) Then
                        max = cmd.Amplitudes(i)
                     End If
                  Next i

                  If max <> 0 Then
                     For i As Integer = 0 To 12
                        cmd.Amplitudes(i) = CType((1000 * cmd.Amplitudes(i) / Math.Abs(max)), Integer)
                     Next i
                  End If

                  cmd.Flags = FreeHandWaveCommandFlags.Repeat Or FreeHandWaveCommandFlags.Frequency
                  cmd.Scale = 100
                  cmd.WaveLength = 25
                  cmd.FillColor = New RasterColor(0, 0, 0)
               ElseIf TypeOf command Is ImpressionistCommand Then
                  Dim cmd As ImpressionistCommand = TryCast(command, ImpressionistCommand)
                  If _checkBoxOptionsDialog.Checked Then
                     Dim ImpressionistDlg As ImpressionistDialog = New ImpressionistDialog(_viewerBefore.Image.Clone())
                     If ImpressionistDlg.ShowDialog(Me) = DialogResult.OK Then
                        cmd.HorizontalDimension = ImpressionistDlg.HorizontalSize
                        cmd.VerticalDimension = ImpressionistDlg.VerticalSize
                     Else
                        Return
                     End If
                  Else
                     cmd.HorizontalDimension = CType((_viewerBefore.Image.Width * 4) / 100, Integer)
                     cmd.VerticalDimension = CType((_viewerBefore.Image.Height * 4) / 100, Integer)
                  End If
               ElseIf TypeOf command Is SphereCommand Then
                  Dim cmd As SphereCommand = TryCast(command, SphereCommand)
                  If _viewerBefore.Image.HasRegion Then
                     Dim Rect As LeadRect = _viewerBefore.Image.GetRegionBounds(Nothing)
                     cmd.CenterPoint = New LeadPoint(CType((Rect.Right + Rect.Left) / 2, Integer), CType((Rect.Bottom + Rect.Top) / 2, Integer))
                  Else
                     cmd.CenterPoint = New LeadPoint(CType(_viewerBefore.Image.Width / 2, Integer), CType(_viewerBefore.Image.Height / 2, Integer))
                  End If
                  cmd.FillColor = New RasterColor(0, 0, 0)
                  cmd.Flags = SphereCommandFlags.Color Or SphereCommandFlags.WithoutRotate
                  cmd.Value = 50
               ElseIf TypeOf command Is CylinderCommand Then
                  Dim cmd As CylinderCommand = TryCast(command, CylinderCommand)
                  cmd.Type = CylinderCommandType.Horizontal
                  cmd.Value = 50
               ElseIf TypeOf command Is BendCommand Then
                  Dim cmd As BendCommand = TryCast(command, BendCommand)

                  If _viewerBefore.Image.HasRegion Then
                     Dim Rect As LeadRect = _viewerBefore.Image.GetRegionBounds(Nothing)
                     cmd.CenterPoint = New LeadPoint(CType((Rect.Right + Rect.Left) / 2, Integer), CType((Rect.Bottom + Rect.Top) / 2, Integer))
                  Else
                     cmd.CenterPoint = New LeadPoint(CType(_viewerBefore.Image.Width / 2, Integer), CType(_viewerBefore.Image.Height / 2, Integer))
                  End If
                  cmd.FillColor = New RasterColor(0, 0, 0)
                  cmd.Flags = BendCommandFlags.Color Or BendCommandFlags.WithoutRotate Or BendCommandFlags.NoChange
                  cmd.Value = 50
               ElseIf TypeOf command Is PunchCommand Then
                  Dim cmd As PunchCommand = TryCast(command, PunchCommand)
                  If _viewerBefore.Image.HasRegion Then
                     Dim Rect As LeadRect = _viewerBefore.Image.GetRegionBounds(Nothing)
                     cmd.CenterPoint = New LeadPoint(CType((Rect.Right + Rect.Left) / 2, Integer), CType((Rect.Bottom + Rect.Top) / 2, Integer))
                  Else
                     cmd.CenterPoint = New LeadPoint(CType(_viewerBefore.Image.Width / 2, Integer), CType(_viewerBefore.Image.Height / 2, Integer))
                  End If
                  cmd.FillColor = New RasterColor(0, 0, 0)
                  cmd.Flags = PunchCommandFlags.NoChange Or PunchCommandFlags.WithoutRotate
                  cmd.Value = -50
                  cmd.Stress = 1
               ElseIf TypeOf command Is PolarCommand Then
                  Dim cmd As PolarCommand = TryCast(command, PolarCommand)
                  cmd.FillColor = New RasterColor(0, 0, 0)
                  cmd.Flags = PolarCommandFlags.CartToPolar Or PolarCommandFlags.Color
               ElseIf TypeOf command Is PixelateCommand Then
                  Dim cmd As PixelateCommand = TryCast(command, PixelateCommand)
                  cmd.CellHeight = 10
                  cmd.CellWidth = 10
                  If _viewerBefore.Image.HasRegion Then
                     Dim Rect As LeadRect = _viewerBefore.Image.GetRegionBounds(Nothing)
                     cmd.CenterPoint = New LeadPoint(CType((Rect.Right + Rect.Left) / 2, Integer), CType((Rect.Bottom + Rect.Top) / 2, Integer))
                  Else
                     cmd.CenterPoint = New LeadPoint(CType(_viewerBefore.Image.Width / 2, Integer), CType(_viewerBefore.Image.Height / 2, Integer))
                  End If
                  cmd.Flags = PixelateCommandFlags.Average Or PixelateCommandFlags.Radial Or PixelateCommandFlags.WidthPeriod Or PixelateCommandFlags.HeightPeriod
                  cmd.Opacity = 100
               ElseIf TypeOf command Is RadialBlurCommand Then
                  Dim cmd As RadialBlurCommand = TryCast(command, RadialBlurCommand)
                  If _viewerBefore.Image.HasRegion Then
                     Dim Rect As LeadRect = _viewerBefore.Image.GetRegionBounds(Nothing)
                     cmd.CenterPoint = New LeadPoint(CType((Rect.Right + Rect.Left) / 2, Integer), CType((Rect.Bottom + Rect.Top) / 2, Integer))
                  Else
                     cmd.CenterPoint = New LeadPoint(CType(_viewerBefore.Image.Width / 2, Integer), CType(_viewerBefore.Image.Height / 2, Integer))
                  End If
                  cmd.Dimension = 25
                  cmd.Stress = 1
               ElseIf TypeOf command Is RippleCommand Then
                  Dim cmd As RippleCommand = TryCast(command, RippleCommand)
                  cmd.Amplitude = 30
                  cmd.Attenuation = 0
                  cmd.CenterPoint = New LeadPoint(CType(_viewerBefore.Image.Width / 2, Integer), CType(_viewerBefore.Image.Height / 2, Integer))
                  cmd.FillColor = New RasterColor(0, 0, 0)
                  cmd.Phase = 0
                  cmd.Type = RippleCommandType.NoChange
                  cmd.Frequency = 6
               ElseIf TypeOf command Is SwirlCommand Then
                  Dim cmd As SwirlCommand = TryCast(command, SwirlCommand)
                  cmd.Angle = 50
                  If _viewerBefore.Image.HasRegion Then
                     Dim Rect As LeadRect = _viewerBefore.Image.GetRegionBounds(Nothing)
                     cmd.CenterPoint = New LeadPoint(CType((Rect.Right + Rect.Left) / 2, Integer), CType((Rect.Bottom + Rect.Top) / 2, Integer))
                  Else
                     cmd.CenterPoint = New LeadPoint(CType(_viewerBefore.Image.Width / 2, Integer), CType(_viewerBefore.Image.Height / 2, Integer))
                  End If
               ElseIf TypeOf command Is ZoomBlurCommand Then
                  Dim cmd As ZoomBlurCommand = TryCast(command, ZoomBlurCommand)
                  If _viewerBefore.Image.HasRegion Then
                     Dim Rect As LeadRect = _viewerBefore.Image.GetRegionBounds(Nothing)
                     cmd.CenterPoint = New LeadPoint(CType((Rect.Right + Rect.Left) / 2, Integer), CType((Rect.Bottom + Rect.Top) / 2, Integer))
                  Else
                     cmd.CenterPoint = New LeadPoint(CType(_viewerBefore.Image.Width / 2, Integer), CType(_viewerBefore.Image.Height / 2, Integer))
                  End If
                  cmd.Dimension = 30
                  cmd.Stress = 1
               ElseIf TypeOf command Is DeinterlaceCommand Then
                  Dim cmd As DeinterlaceCommand = TryCast(command, DeinterlaceCommand)
                  If _checkBoxOptionsDialog.Checked Then
                     Dim DeinterlaceDlg As DeinterlaceDialog = New DeinterlaceDialog()
                     If DeinterlaceDlg.ShowDialog(Me) = DialogResult.OK Then
                        cmd.Flags = DeinterlaceDlg.DeinterlaceCommand.Flags
                     Else
                        Return
                     End If
                  Else
                     cmd.Flags = DeinterlaceCommandFlags.Smooth Or DeinterlaceCommandFlags.Odd
                  End If
               ElseIf TypeOf command Is SampleTargetCommand Then
                  Dim cmd As SampleTargetCommand = TryCast(command, SampleTargetCommand)
                  cmd.Flags = SampleTargetCommandFlags.Rgb Or SampleTargetCommandFlags.Mid
                  cmd.SampleColor = New RasterColor(50, 50, 50)
                  cmd.TargetColor = New RasterColor(100, 100, 100)
               ElseIf TypeOf command Is RegionHolesRemovalCommand Then
                  Dim cmd As RegionHolesRemovalCommand = TryCast(command, RegionHolesRemovalCommand)
                  Dim rc As LeadRect = New LeadRect(CType(_viewerBefore.Image.Width / 8, Integer), CType(_viewerBefore.Image.Height / 8, Integer), CType(_viewerBefore.Image.Width / 2, Integer) + CType(_viewerBefore.Image.Width / 8, Integer), CType(_viewerBefore.Image.Height / 2, Integer) + CType(_viewerBefore.Image.Height / 8, Integer))
                  _viewerBefore.Image.AddEllipseToRegion(Nothing, rc, RasterRegionCombineMode.SetNot)
                  _viewerAfter.Image.AddEllipseToRegion(Nothing, rc, RasterRegionCombineMode.SetNot)
               ElseIf TypeOf command Is CubismCommand Then
                  Dim cmd As CubismCommand = TryCast(command, CubismCommand)
                  cmd.Angle = 0
                  cmd.Brightness = 0
                  cmd.FillColor = New RasterColor(0, 0, 0)
                  cmd.Flags = CubismCommandFlags.Background Or CubismCommandFlags.Random Or CubismCommandFlags.Square
                  cmd.Length = 200
                  cmd.Space = 90
               ElseIf TypeOf command Is GlassEffectCommand Then
                  Dim cmd As GlassEffectCommand = TryCast(command, GlassEffectCommand)
                  cmd.CellHeight = 20
                  cmd.CellWidth = 20
                  cmd.Flags = GlassEffectCommandFlags.WidthFrequency Or GlassEffectCommandFlags.HeightFrequency
               ElseIf TypeOf command Is LensFlareCommand Then
                  Dim cmd As LensFlareCommand = TryCast(command, LensFlareCommand)
                  cmd.Brightness = 100
                  If _viewerBefore.Image.HasRegion Then
                     Dim Rect As LeadRect = _viewerBefore.Image.GetRegionBounds(Nothing)
                     cmd.CenterPoint = New LeadPoint(CType((Rect.Right + Rect.Left) / 2, Integer), CType((Rect.Bottom + Rect.Top) / 2, Integer))
                  Else
                     cmd.CenterPoint = New LeadPoint(CType(_viewerBefore.Image.Width / 4, Integer), CType(_viewerBefore.Image.Height / 4, Integer))
                  End If
                  cmd.Color = New RasterColor(0, 0, 0)
                  cmd.Type = LensFlareCommandType.Type1
               ElseIf TypeOf command Is ColorSeparateCommand Then
                  runAfterImage = False

               ElseIf TypeOf command Is ResizeRegionCommand Then 'Update
                  Dim rc As LeadRect = New LeadRect(CType(_viewerBefore.Image.Width / 2, Integer) - CType(_viewerBefore.Image.Width / 8, Integer), CType(_viewerBefore.Image.Height / 2, Integer) - CType(_viewerBefore.Image.Height / 8, Integer), CType(_viewerBefore.Image.Width / 4, Integer), CType(_viewerBefore.Image.Height / 4, Integer))

                  If Not _viewerBefore.Image.HasRegion Then
                     _viewerBefore.Image.AddRectangleToRegion(Nothing, rc, RasterRegionCombineMode.Set)
                     _viewerAfter.Image.AddRectangleToRegion(Nothing, rc, RasterRegionCombineMode.Set)
                  End If

                  Dim cmd As ResizeRegionCommand = TryCast(command, ResizeRegionCommand)
                  If _checkBoxOptionsDialog.Checked Then
                     Dim ResizeRegionDlg As ResizeRegionDialog = New ResizeRegionDialog()
                     If ResizeRegionDlg.ShowDialog(Me) = DialogResult.OK Then
                        cmd.AsFrame = ResizeRegionDlg.ResizeRegionCommand.AsFrame
                        cmd.Dimension = ResizeRegionDlg.ResizeRegionCommand.Dimension
                        cmd.Type = ResizeRegionDlg.ResizeRegionCommand.Type
                        cmd.Run(_viewerAfter.Image)
                        Return
                     Else
                        Return
                     End If
                  Else
                     cmd.AsFrame = True
                     cmd.Dimension = 60
                     cmd.Type = ResizeRegionCommandType.ExpandRegion
                     cmd.Run(_viewerAfter.Image)
                     Return
                  End If
               ElseIf TypeOf command Is ConvertUnsignedToSignedCommand Then 'Update
                  Dim cmd As ConvertUnsignedToSignedCommand = TryCast(command, ConvertUnsignedToSignedCommand)
                  If _checkBoxProgress.Checked Then
                     AddHandler cmd.Progress, AddressOf command_Progress
                  End If
                  Dim ConvertUnsignedToSignedDlg As ConvertUnsignedToSignedDialog = New ConvertUnsignedToSignedDialog()
                  If _checkBoxOptionsDialog.Checked Then
                     If ConvertUnsignedToSignedDlg.ShowDialog(Me) = DialogResult.OK Then
                        cmd.Type = ConvertUnsignedToSignedDlg.ConvertUnsignedToSignedCommand.Type
                        cmd.Run(_viewerAfter.Image)
                        Messager.ShowInformation(Me, "Signed Image")
                        Dim command1 As ConvertSignedToUnsignedCommand = New ConvertSignedToUnsignedCommand()
                        If _checkBoxProgress.Checked Then
                           AddHandler command1.Progress, AddressOf command_Progress
                        End If
                        command1.Run(_viewerAfter.Image)
                        Messager.ShowInformation(Me, "Unsigned Image")
                        Return
                     Else
                        Return
                     End If
                  Else
                     If _checkBoxProgress.Checked Then
                        AddHandler cmd.Progress, AddressOf command_Progress
                     End If
                     cmd.Run(_viewerAfter.Image)
                     'Messager.ShowInformation(this, "Signed Image");
                     Dim command1 As ConvertSignedToUnsignedCommand = New ConvertSignedToUnsignedCommand()
                     If _checkBoxProgress.Checked Then
                        AddHandler command1.Progress, AddressOf command_Progress
                     End If
                     command1.Run(_viewerAfter.Image)
                     Messager.ShowInformation(Me, "Unsigned Image")
                     Return


                  End If
               ElseIf TypeOf command Is BumpMapCommand Then
                  Dim cmd As BumpMapCommand = TryCast(command, BumpMapCommand)
                  cmd.Azimuth = 50
                  cmd.Brightness = 50
                  cmd.BumpImage = _codecs.Load(CommandProperties.GetImageNameFileName(CommandImage.ImageProcessingDemo__Ulay3_Bmp))
                  cmd.BumpPoint = New LeadPoint(0, 0)
                  cmd.Depth = 1
                  cmd.DestinationPoint = New LeadPoint(0, 0)
                  cmd.Elevation = 5
                  cmd.Intensity = 0
                  cmd.LookupTable = Nothing
                  cmd.Tile = True
               ElseIf TypeOf command Is GlowCommand Then
                  Dim cmd As GlowCommand = TryCast(command, GlowCommand)
                  cmd.Brightness = 7
                  cmd.Dimension = 3
                  cmd.Threshold = 0
               ElseIf TypeOf command Is EdgeDetectStatisticalCommand Then
                  Dim cmd As EdgeDetectStatisticalCommand = TryCast(command, EdgeDetectStatisticalCommand)
                  If _checkBoxOptionsDialog.Checked Then
                     Dim EdgeDetectStatisticalDlg As EdgeDetectStatisticalDialog = New EdgeDetectStatisticalDialog()
                     If EdgeDetectStatisticalDlg.ShowDialog(Me) = DialogResult.OK Then
                        cmd.BackGroundColor = EdgeDetectStatisticalDlg.EdgeDetectStatisticalCommand.BackGroundColor
                        cmd.Dimension = EdgeDetectStatisticalDlg.EdgeDetectStatisticalCommand.Dimension
                        cmd.EdgeColor = EdgeDetectStatisticalDlg.EdgeDetectStatisticalCommand.EdgeColor
                        cmd.Threshold = EdgeDetectStatisticalDlg.EdgeDetectStatisticalCommand.Threshold
                     Else
                        Return
                     End If
                  Else
                     cmd.BackGroundColor = New RasterColor(0, 0, 0)
                     cmd.Dimension = 3
                     cmd.EdgeColor = New RasterColor(255, 255, 255)
                     cmd.Threshold = 35
                  End If
               ElseIf TypeOf command Is SmoothEdgesCommand Then
                  Dim cmd As SmoothEdgesCommand = TryCast(command, SmoothEdgesCommand)

                  If _checkBoxOptionsDialog.Checked Then
                     Dim SmoothEdgesDlg As SmoothEdgesDialog = New SmoothEdgesDialog()
                     If SmoothEdgesDlg.ShowDialog(Me) = DialogResult.OK Then
                        cmd.Amount = SmoothEdgesDlg.SmoothEdgesCommand.Amount
                        cmd.Threshold = SmoothEdgesDlg.SmoothEdgesCommand.Threshold
                     Else
                        Return
                     End If
                  Else
                     cmd.Amount = 100
                     cmd.Threshold = 0
                  End If
               ElseIf TypeOf command Is PlaneCommand Then
                  Dim cmd As PlaneCommand = TryCast(command, PlaneCommand)
                  cmd.BrightColor = New RasterColor(255, 255, 255)
                  cmd.BrightLength = 25
                  cmd.CenterPoint = New LeadPoint(CType(_viewerBefore.Image.Width / 2, Integer), CType(_viewerBefore.Image.Height / 2, Integer))
                  cmd.Distance = CType(_viewerBefore.Image.Height / 2, Integer)
                  cmd.EndBright = 100
                  cmd.FillColor = New RasterColor(255, 255, 255)
                  cmd.Flags = PlaneCommandFlags.Color Or PlaneCommandFlags.Down Or PlaneCommandFlags.Up Or PlaneCommandFlags.Left Or PlaneCommandFlags.Right
                  cmd.PlaneOffset = CType(_viewerBefore.Image.Height / 2, Integer)
                  cmd.PyramidAngle = 0
                  cmd.Repeat = -1
                  cmd.StartBright = 0
                  cmd.Stretch = 100
                  cmd.ZValue = 0
               ElseIf TypeOf command Is PlaneBendCommand Then
                  Dim cmd As PlaneBendCommand = TryCast(command, PlaneBendCommand)
                  cmd.BrightColor = New RasterColor(255, 255, 255)
                  cmd.BrightLength = 50
                  cmd.CenterPoint = New LeadPoint(CType(_viewerBefore.Image.Width * 2 / 3, Integer), CType(_viewerBefore.Image.Height / 2, Integer))
                  cmd.Distance = CType(_viewerBefore.Image.Height / 2, Integer)
                  cmd.EndBright = 0
                  cmd.FillColor = New RasterColor(0, 0, 0)
                  cmd.Flags = PlaneCommandFlags.Color Or PlaneCommandFlags.Down
                  cmd.PlaneOffset = CType(_viewerBefore.Image.Height / 2, Integer)
                  cmd.PyramidAngle = 0
                  cmd.Repeat = -1
                  cmd.StartBright = 0
                  cmd.Stretch = 75
                  cmd.ZValue = 0
                  cmd.BendFactor = 300
               ElseIf TypeOf command Is ColorIntensityBalanceCommand Then
                  Dim cmd As ColorIntensityBalanceCommand = TryCast(command, ColorIntensityBalanceCommand)
                  cmd.HighLight = New ColorIntensityBalanceCommandData(70, 0, 0)
                  cmd.Shadows = New ColorIntensityBalanceCommandData(60, 0, 0)
                  cmd.MidTone = New ColorIntensityBalanceCommandData(40, 0, 0)
                  cmd.Luminance = False
               ElseIf TypeOf command Is TunnelCommand Then
                  Dim cmd As TunnelCommand = TryCast(command, TunnelCommand)
                  cmd.BrightColor = New RasterColor(255, 255, 255)
                  cmd.BrightLength = 50
                  cmd.CenterPoint = New LeadPoint(CType(_viewerBefore.Image.Width * 2 / 3, Integer), CType(_viewerBefore.Image.Height / 2, Integer))
                  cmd.Distance = CType(_viewerBefore.Image.Height / 2, Integer)
                  cmd.EndBright = 0
                  cmd.FillColor = New RasterColor(255, 255, 255)
                  cmd.Flags = TunnelCommandFlags.Color Or TunnelCommandFlags.WidthAxis
                  cmd.Repeat = -1
                  cmd.StartBright = 0
                  cmd.Stretch = 75
                  cmd.ZValue = 0
                  cmd.Radius = CType(_viewerBefore.Image.Height / 2, Integer)
                  cmd.RotationOffset = 0
               ElseIf TypeOf command Is FreeRadialBendCommand Then
                  Dim Points() As LeadPoint = _
                  { _
                  New LeadPoint(0, 0), _
                  New LeadPoint(3, 1), _
                  New LeadPoint(9, -1), _
                  New LeadPoint(12, 0) _
                  }

                  Dim cmd As FreeRadialBendCommand = TryCast(command, FreeRadialBendCommand)
                  If _viewerBefore.Image.HasRegion Then
                     Dim Rect As LeadRect = _viewerBefore.Image.GetRegionBounds(Nothing)
                     cmd.CenterPoint = New LeadPoint(CType((Rect.Right + Rect.Left) / 2, Integer), CType((Rect.Bottom + Rect.Top) / 2, Integer))
                  Else
                     cmd.CenterPoint = New LeadPoint(CType(_viewerBefore.Image.Width / 2, Integer), CType(_viewerBefore.Image.Height / 2, Integer))
                  End If
                  cmd.Curve = New Integer(12) {}
                  EffectsUtilities.GetCurvePoints(cmd.Curve, Points, CurvePointsType.Linear)
                  Dim i As Integer = 0
                  Do While i < cmd.Curve.Length
                     cmd.Curve(i) = CType(cmd.Curve(i) / 2, Integer)
                     i += 1
                  Loop

                  cmd.FillColor = New RasterColor(0, 0, 0)
                  cmd.Flags = FreeRadialBendCommandFlags.Color Or FreeRadialBendCommandFlags.WithoutRotate
                  cmd.Scale = 50
               ElseIf TypeOf command Is AutoCropCommand Then
                  Dim cmd As AutoCropCommand = TryCast(command, AutoCropCommand)
                  If _checkBoxOptionsDialog.Checked Then
                     Dim AutoCropDlg As AutoCropDialog = New AutoCropDialog()
                     If AutoCropDlg.ShowDialog(Me) = DialogResult.OK Then
                        cmd.Threshold = AutoCropDlg.Threshold
                     Else
                        Return
                     End If
                  Else
                     cmd.Threshold = 128
                  End If
               ElseIf TypeOf command Is FreePlaneBendCommand Then
                  Dim Points As LeadPoint() = {New LeadPoint(0, 0), New LeadPoint(3, 1), New LeadPoint(5, -1), New LeadPoint(7, 0)}

                  Dim cmd As FreePlaneBendCommand = TryCast(command, FreePlaneBendCommand)
                  cmd.Curve = New Integer(12) {}
                  EffectsUtilities.GetCurvePoints(cmd.Curve, Points, CurvePointsType.Linear)
                  Dim i As Integer = 0
                  Do While i < cmd.Curve.Length
                     cmd.Curve(i) = CType(cmd.Curve(i) / 2, Integer)
                     i += 1
                  Loop

                  cmd.FillColor = New RasterColor(0, 0, 0)
                  cmd.Flags = FreePlaneBendCommandFlags.Color Or FreePlaneBendCommandFlags.HorizontalVertical
                  cmd.Scale = 50
               ElseIf TypeOf command Is OceanCommand Then
                  Dim cmd As OceanCommand = TryCast(command, OceanCommand)
                  cmd.Amplitude = 25
                  cmd.Frequency = 20
                  cmd.LowerTransparency = False
               ElseIf TypeOf command Is LightCommand Then
                  Dim cmd As LightCommand = TryCast(command, LightCommand)
                  cmd.Ambient = 100
                  cmd.AmbientColor = New RasterColor(255, 255, 255)
                  cmd.Bright = 100
                  cmd.Data = New LightCommandData(0) {}
                  cmd.Data(0).Angle = 4500
                  cmd.Data(0).Brightness = 100
                  If _viewerBefore.Image.HasRegion Then
                     Dim Rect As LeadRect = _viewerBefore.Image.GetRegionBounds(Nothing)
                     cmd.Data(0).CenterPoint = New LeadPoint(CType((Rect.Right + Rect.Left) / 2, Integer), CType((Rect.Bottom + Rect.Top) / 2, Integer))
                  Else

                     cmd.Data(0).CenterPoint = New LeadPoint(CType(_viewerBefore.Image.Width / 2, Integer), CType(_viewerBefore.Image.Height / 2, Integer))
                  End If
                  cmd.Data(0).Edge = 100
                  cmd.Data(0).FillColor = New RasterColor(255, 255, 255)
                  cmd.Data(0).Height = CType(_viewerBefore.Image.Width / 10, Integer)
                  cmd.Data(0).Opacity = 100
                  cmd.Data(0).Type = LightCommandType.Spot
                  cmd.Data(0).Width = CType(_viewerBefore.Image.Width / 5, Integer)
               ElseIf TypeOf command Is DryCommand Then
                  Dim cmd As DryCommand = TryCast(command, DryCommand)
                  cmd.Dimension = 9
               ElseIf TypeOf command Is DrawStarCommand Then
                  Dim cmd As DrawStarCommand = TryCast(command, DrawStarCommand)
                  cmd.Angle = 4500
                  cmd.AngleOpacity = 100
                  cmd.BorderOpacity = 100
                  If _viewerBefore.Image.HasRegion Then
                     Dim Rect As LeadRect = _viewerBefore.Image.GetRegionBounds(Nothing)
                     cmd.CenterPoint = New LeadPoint(CType((Rect.Right + Rect.Left) / 2, Integer), CType((Rect.Bottom + Rect.Top) / 2, Integer))
                  Else
                     cmd.CenterPoint = New LeadPoint(CType(_viewerBefore.Image.Width / 2, Integer), CType(_viewerBefore.Image.Height / 2, Integer))
                  End If
                  cmd.DistanceOpacity = 0
                  cmd.Flags = DrawStarCommandFlags.Outside Or DrawStarCommandFlags.Inner
                  cmd.HoleSize = 50
                  cmd.LowerColorFill = New RasterColor(255, 0, 0)
                  cmd.Opacity = 100
                  cmd.Phase = 0
                  cmd.Spoke = 8
                  cmd.SpokeDivision = 0
                  cmd.StarHeight = CType(_viewerBefore.Image.Height / 2, Integer)
                  cmd.StarWidth = CType(_viewerBefore.Image.Width * 3 / 4, Integer)
                  cmd.UpperColorFill = New RasterColor(0, 255, 0)
               ElseIf TypeOf command Is FunctionalLightCommand Then
                  Dim cmd As FunctionalLightCommand = TryCast(command, FunctionalLightCommand)
                  cmd.Angle = 0
                  cmd.BlueAmplitude = 50
                  cmd.Buffer = Nothing
                  cmd.Flags = FunctionalLightCommandFlags.Trigonometry Or FunctionalLightCommandFlags.Addition Or FunctionalLightCommandFlags.Circles
                  cmd.Frequency = 1500
                  cmd.GreenAmplitude = 50
                  cmd.Origin = New LeadPoint(CType(_viewerBefore.Image.Width / 2, Integer), CType(_viewerBefore.Image.Height / 2, Integer))

                  cmd.PhaseShift = 0
                  cmd.RedAmplitude = 50
               ElseIf TypeOf command Is DiceEffectCommand Then
                  Dim cmd As DiceEffectCommand = TryCast(command, DiceEffectCommand)
                  cmd.BorderColor = New RasterColor(0, 0, 0)
                  cmd.Flags = DiceEffectCommandFlags.Border Or DiceEffectCommandFlags.ResizeImage Or DiceEffectCommandFlags.Size
                  cmd.Randomize = 0
                  cmd.XBlock = 16
                  cmd.YBlock = 16
               ElseIf TypeOf command Is PuzzleEffectCommand Then
                  Dim cmd As PuzzleEffectCommand = TryCast(command, PuzzleEffectCommand)
                  cmd.BorderColor = New RasterColor(255, 255, 255)
                  cmd.Flags = PuzzleEffectCommandFlags.Border Or PuzzleEffectCommandFlags.Resize Or PuzzleEffectCommandFlags.Shuffle Or PuzzleEffectCommandFlags.Count
                  cmd.Randomize = 0
                  cmd.XBlock = 16
                  cmd.YBlock = 16
               ElseIf TypeOf command Is RingEffectCommand Then
                  Dim cmd As RingEffectCommand = TryCast(command, RingEffectCommand)
                  cmd.Angle = 250
                  cmd.Color = New RasterColor(0, 0, 0)
                  cmd.Flags = RingEffectCommandFlags.Color Or RingEffectCommandFlags.Radius Or RingEffectCommandFlags.FixedAngle
                  cmd.Origin = New LeadPoint(CType(_viewerBefore.Image.Width / 2, Integer), CType(_viewerBefore.Image.Height / 2, Integer))

                  cmd.Radius = 2
                  cmd.Randomize = 0
                  cmd.RingCount = 50
               ElseIf TypeOf command Is ShiftDataCommand Then
                  Dim cmd As ShiftDataCommand = TryCast(command, ShiftDataCommand)
                  cmd.DestinationBitsPerPixel = 8
                  cmd.DestinationLowBit = 5
                  cmd.SourceLowBit = 2
                  cmd.SourceHighBit = 7
                  runAfterImage = False

               ElseIf TypeOf command Is SelectDataCommand Then
                  Dim cmd As SelectDataCommand = TryCast(command, SelectDataCommand)
                  cmd.SourceHighBit = _viewerBefore.Image.BitsPerPixel - 1
                  cmd.SourceLowBit = 4
                  cmd.Combine = True
                  cmd.Color = New RasterColor(0, 0, 255)
                  cmd.Threshold = 4
                  runAfterImage = False
               ElseIf TypeOf command Is AddMessageCommand Then
                  Dim cmd As AddMessageCommand = TryCast(command, AddMessageCommand)
                  cmd.Message = "LEAD Technologies, Inc."
               ElseIf TypeOf command Is ExtractMessageCommand Then
                  Dim addCommand As AddMessageCommand = New AddMessageCommand()
                  addCommand.Message = "LEAD Technologies, Inc."
                  If _checkBoxProgress.Checked Then
                     AddHandler addCommand.Progress, AddressOf command_Progress
                  End If

                  addCommand.Run(_viewerBefore.Image)
                  Dim cmd As ExtractMessageCommand = TryCast(command, ExtractMessageCommand)
                  If _checkBoxProgress.Checked Then
                     AddHandler cmd.Progress, AddressOf command_Progress
                  End If
                  cmd.Run(_viewerBefore.Image)
                  Messager.ShowInformation(Me, String.Format("Message = {0}", cmd.Message))
                  Return
               ElseIf TypeOf command Is WaveCommand Then
                  Dim cmd As WaveCommand = TryCast(command, WaveCommand)
                  cmd.Amplitude = CType(_viewerBefore.Image.Width * 4 / 100, Integer)
                  cmd.Angle = 4500
                  cmd.FillColor = New RasterColor(0, 0, 0)
                  cmd.Flags = WaveCommandFlags.Repeat Or WaveCommandFlags.Repeat Or WaveCommandFlags.Frequency Or WaveCommandFlags.SinWave
                  cmd.HorizontalFactor = 100
                  cmd.VerticalFactor = 100
                  cmd.WaveLength = 15
               ElseIf TypeOf command Is ZoomWaveCommand Then
                  Dim cmd As ZoomWaveCommand = TryCast(command, ZoomWaveCommand)
                  cmd.Amplitude = 1
                  If _viewerBefore.Image.HasRegion Then
                     Dim Rect As LeadRect = _viewerBefore.Image.GetRegionBounds(Nothing)
                     cmd.CenterPoint = New LeadPoint(CType((Rect.Right + Rect.Left) / 2, Integer), CType((Rect.Bottom + Rect.Top) / 2, Integer))
                  Else
                     cmd.CenterPoint = New LeadPoint(CType(_viewerBefore.Image.Width / 2, Integer), CType(_viewerBefore.Image.Height / 2, Integer))
                  End If
                  cmd.FillColor = New RasterColor(0, 0, 0)
                  cmd.Frequency = 25
                  cmd.Phase = 0
                  cmd.Type = ZoomWaveCommandType.Repeat
                  cmd.ZoomFactor = 0
               ElseIf TypeOf command Is EdgeDetectEffectCommand Then
                  Dim cmd As EdgeDetectEffectCommand = TryCast(command, EdgeDetectEffectCommand)
                  If _checkBoxOptionsDialog.Checked Then
                     Dim EdgeDetectEffectDlg As EdgeDetectEffectDialog = New EdgeDetectEffectDialog()
                     If EdgeDetectEffectDlg.ShowDialog(Me) = DialogResult.OK Then
                        cmd.Level = EdgeDetectEffectDlg.EdgeDetectEffectCommand.Level
                        cmd.Threshold = EdgeDetectEffectDlg.EdgeDetectEffectCommand.Threshold
                        cmd.Type = EdgeDetectEffectDlg.EdgeDetectEffectCommand.Type
                     Else
                        Return
                     End If
                  Else
                     cmd.Level = 50
                     cmd.Threshold = 0
                     cmd.Type = EdgeDetectEffectCommandType.Smooth
                  End If
               ElseIf TypeOf command Is GaussianCommand Then
                  Dim cmd As GaussianCommand = TryCast(command, GaussianCommand)
                  If _checkBoxOptionsDialog.Checked Then
                     Dim GaussianDlg As GaussianDialog = New GaussianDialog()
                     If GaussianDlg.ShowDialog(Me) = DialogResult.OK Then
                        cmd.Radius = GaussianDlg.Radius
                     Else
                        Return
                     End If
                  Else
                     cmd.Radius = 5
                  End If
               ElseIf TypeOf command Is UnsharpMaskCommand Then
                  Dim cmd As UnsharpMaskCommand = TryCast(command, UnsharpMaskCommand)
                  If _checkBoxOptionsDialog.Checked Then
                     Dim UnsharpMaskDlg As UnsharpMaskDialog = New UnsharpMaskDialog()
                     If UnsharpMaskDlg.ShowDialog(Me) = DialogResult.OK Then
                        cmd.Amount = UnsharpMaskDlg.UnsharpMaskCommand.Amount
                        cmd.ColorType = UnsharpMaskDlg.UnsharpMaskCommand.ColorType
                        cmd.Radius = UnsharpMaskDlg.UnsharpMaskCommand.Radius
                        cmd.Threshold = UnsharpMaskDlg.UnsharpMaskCommand.Threshold
                     Else
                        Return
                     End If
                  Else
                     cmd.Amount = 100
                     cmd.ColorType = UnsharpMaskCommandColorType.Rgb
                     cmd.Radius = 20
                     cmd.Threshold = 0
                  End If
               ElseIf TypeOf command Is FeatherAlphaBlendCommand Then
                  Dim cmd As FeatherAlphaBlendCommand = TryCast(command, FeatherAlphaBlendCommand)
                  Dim MaskImage As RasterImage = _codecs.Load(CommandProperties.GetImageNameFileName(CommandImage.ImageProcessingDemo__FadeMask_bmp))

                  If _checkBoxOptionsDialog.Checked Then
                     Dim FeatherAlphaBlendDlg As FeatherAlphaBlendDialog = New FeatherAlphaBlendDialog(_viewerAfter.Image, MaskImage)
                     If FeatherAlphaBlendDlg.ShowDialog(Me) = DialogResult.OK Then
                        cmd.DestinationRectangle = FeatherAlphaBlendDlg.FeatherAlphaBlendCommand.DestinationRectangle
                        cmd.SourcePoint = FeatherAlphaBlendDlg.FeatherAlphaBlendCommand.SourcePoint
                        cmd.MaskSourcePoint = FeatherAlphaBlendDlg.FeatherAlphaBlendCommand.MaskSourcePoint
                        cmd.MaskImage = MaskImage
                        cmd.SourceImage = _viewerAfter.Image
                     Else
                        Return
                     End If
                  Else
                     cmd.DestinationRectangle = New LeadRect(0, 0, CType(_viewerAfter.Image.Width / 2, Integer), CType(_viewerAfter.Image.Height / 2, Integer))
                     cmd.MaskImage = MaskImage
                     cmd.SourceImage = _viewerAfter.Image
                     cmd.SourcePoint = New LeadPoint(CType(_viewerBefore.Image.Width / 2, Integer), CType(_viewerBefore.Image.Height / 2, Integer))
                  End If
               ElseIf TypeOf command Is AlphaBlendCommand Then
                  Dim cmd As AlphaBlendCommand = TryCast(command, AlphaBlendCommand)
                  If _checkBoxOptionsDialog.Checked Then
                     Dim AlphaBlendDlg As AlphaBlendDialog = New AlphaBlendDialog(_viewerBefore.Image)
                     If AlphaBlendDlg.ShowDialog(Me) = DialogResult.OK Then
                        cmd.DestinationRectangle = AlphaBlendDlg.AlphaBlendCommand.DestinationRectangle
                        cmd.Opacity = AlphaBlendDlg.AlphaBlendCommand.Opacity
                        cmd.SourceImage = _viewerBefore.Image
                        cmd.SourcePoint = AlphaBlendDlg.AlphaBlendCommand.SourcePoint
                     Else
                        Return
                     End If
                  Else
                     cmd.DestinationRectangle = New LeadRect(CType(_viewerAfter.Image.Width / 2, Integer) - CType(_viewerBefore.Image.Width / 2, Integer), CType(_viewerAfter.Image.Height / 2, Integer) - CType(_viewerBefore.Image.Height / 2, Integer), CType(_viewerAfter.Image.Width / 2, Integer) + CType(_viewerBefore.Image.Width / 8, Integer), CType(_viewerAfter.Image.Height / 2, Integer) + CType(_viewerBefore.Image.Height / 8, Integer))
                     cmd.Opacity = 128
                     cmd.SourceImage = _viewerBefore.Image
                     cmd.SourcePoint = New LeadPoint(0, 0)
                  End If
               ElseIf TypeOf command Is CombineCommand Then
                  Dim cmd As CombineCommand = TryCast(command, CombineCommand)
                  If _checkBoxOptionsDialog.Checked Then
                     Dim CombineDlg As CombineDialog = New CombineDialog(_viewerAfter.Image)
                     If CombineDlg.ShowDialog(Me) = DialogResult.OK Then
                        cmd.SourceImage = _viewerAfter.Image
                        cmd.DestinationRectangle = CombineDlg.CombineCommand.DestinationRectangle
                        cmd.SourcePoint = CombineDlg.CombineCommand.SourcePoint
                        cmd.Flags = CombineDlg.CombineCommand.Flags
                     Else
                        Return
                     End If
                  Else
                     cmd.SourceImage = _viewerAfter.Image
                     cmd.DestinationRectangle = New LeadRect(CType(_viewerAfter.Image.Width / 8, Integer), CType(_viewerAfter.Image.Height / 8, Integer), _viewerAfter.Image.Width - CType(_viewerAfter.Image.Width / 8, Integer), _viewerAfter.Image.Height - CType(_viewerAfter.Image.Height / 8, Integer))
                     cmd.SourcePoint = New LeadPoint(0, 0)
                     cmd.Flags = CombineCommandFlags.OperationAdd Or CombineCommandFlags.Destination0 Or CombineCommandFlags.SourceRed Or CombineCommandFlags.DestinationGreen Or CombineCommandFlags.ResultBlue
                  End If
               ElseIf TypeOf command Is AntiAliasingCommand Then
                  Dim cmd As AntiAliasingCommand = TryCast(command, AntiAliasingCommand)
                  Dim AntiAliasingDlg As AntiAliasingDialog = New AntiAliasingDialog()
                  If _checkBoxOptionsDialog.Checked Then
                     If AntiAliasingDlg.ShowDialog(Me) = DialogResult.OK Then
                        cmd.Dimension = AntiAliasingDlg.AntiAliasingCommand.Dimension
                        cmd.Filter = AntiAliasingDlg.AntiAliasingCommand.Filter
                        cmd.Threshold = AntiAliasingDlg.AntiAliasingCommand.Threshold
                     Else
                        Return
                     End If
                  Else
                     cmd.Dimension = 9
                     cmd.Filter = AntiAliasingCommandType.Type1
                     cmd.Threshold = 0
                  End If
               ElseIf TypeOf command Is BalanceColorsCommand Then
                  Dim cmd As BalanceColorsCommand = TryCast(command, BalanceColorsCommand)
                  cmd.BlueFactor = New BalanceColorCommandFactor(1.0, 0.5, 0.7)
                  cmd.GreenFactor = New BalanceColorCommandFactor(0.8, 0.3, 0.7)
                  cmd.RedFactor = New BalanceColorCommandFactor(0.5, 0.4, 0.7)
               ElseIf TypeOf command Is EdgeDetectorCommand Then
                  Dim cmd As EdgeDetectorCommand = TryCast(command, EdgeDetectorCommand)
                  Dim EdgeDetectorDlg As EdgeDetectorDialog = New EdgeDetectorDialog()

                  If _checkBoxOptionsDialog.Checked Then
                     If EdgeDetectorDlg.ShowDialog(Me) = DialogResult.OK Then
                        cmd.Filter = EdgeDetectorDlg.EdgeDetectorCommand.Filter
                        cmd.Threshold = EdgeDetectorDlg.EdgeDetectorCommand.Threshold
                     Else
                        Return
                     End If
                  Else
                     cmd.Filter = EdgeDetectorCommandType.SobelHorizontal
                     cmd.Threshold = 60
                  End If
               ElseIf TypeOf command Is MotionBlurCommand Then
                  Dim cmd As MotionBlurCommand = TryCast(command, MotionBlurCommand)
                  cmd.Angle = 4500
                  cmd.Dimension = 50
                  cmd.UniDirection = True
               ElseIf TypeOf command Is HalfToneCommand Then
                  Dim cmd As HalfToneCommand = TryCast(command, HalfToneCommand)
                  If _checkBoxOptionsDialog.Checked Then
                     Dim HalfToneDlg As HalfToneDialog = New HalfToneDialog()
                     Dim images As RasterImage() = New RasterImage(1) {}
                     If HalfToneDlg.ShowDialog(Me) = DialogResult.OK Then
                        cmd.Type = HalfToneDlg.HalfToneCommand.Type
                        cmd.Angle = HalfToneDlg.HalfToneCommand.Angle
                        cmd.Dimension = HalfToneDlg.HalfToneCommand.Dimension
                        If HalfToneDlg.UserDefined Then
                           images(0) = _codecs.Load(CommandProperties.GetImageNameFileName(CommandImage.ImageProcessingDemo__Image1_jpg))
                           images(1) = images(0)
                           images(0).AddPage(images(1))
                           cmd.UserDefinedImage = images(0)
                        End If
                     Else
                        Return
                     End If
                  Else
                     cmd.Type = HalfToneCommandType.Print
                     cmd.Angle = 0
                     cmd.Dimension = 0
                  End If
               ElseIf TypeOf command Is TextureAlphaBlendCommand Then
                  Dim cmd As TextureAlphaBlendCommand = TryCast(command, TextureAlphaBlendCommand)
                  cmd.MaskImage = _codecs.Load(CommandProperties.GetImageNameFileName(CommandImage.ImageProcessingDemo__FadeMask_bmp))
                  cmd.DestinationRectangle = New LeadRect(CType(_viewerAfter.Image.Width / 2, Integer) - CType(cmd.MaskImage.Width / 2, Integer), CType(_viewerAfter.Image.Height / 2, Integer) - CType(cmd.MaskImage.Height / 2, Integer), cmd.MaskImage.Width, cmd.MaskImage.Height)
                  cmd.Opacity = 128
                  cmd.SourceImage = _codecs.Load(CommandProperties.GetImageNameFileName(CommandImage.ImageProcessingDemo__Image1_jpg))
                  cmd.SourcePoint = New LeadPoint(0, 0)
                  cmd.UnderlayImage = _viewerAfter.Image
                  cmd.UnderlayOffset = New LeadPoint(0, 0)
               ElseIf TypeOf command Is AddWeightedCommand Then
                  Dim cmd As AddWeightedCommand = TryCast(command, AddWeightedCommand)
                  cmd.Type = AddWeightedCommandType.Average
                  cmd.Factor = New Integer(3) {}
                  cmd.Factor(0) = 50
                  cmd.Factor(1) = 70
                  cmd.Factor(2) = 80
                  cmd.Factor(3) = 90
               ElseIf TypeOf command Is FastFourierTransformCommand Then
                  If TypeOf command Is FrequencyFilterMask Then
                     ' Resize the image to make sure the image's dimensions are power of two.
                     Dim sizecommand As SizeCommand = New SizeCommand(256, 256, RasterSizeFlags.Bicubic)
                     sizecommand.Run(_viewerAfter.Image)

                     Dim ftArray As FourierTransformInformation = New FourierTransformInformation(_viewerAfter.Image)
                     ' Apply FFT.
                     Dim ftCommand As FastFourierTransformCommand = New FastFourierTransformCommand(ftArray, FastFourierTransformCommandFlags.FastFourierTransform Or FastFourierTransformCommandFlags.Gray)
                     If _checkBoxProgress.Checked Then
                        AddHandler ftCommand.Progress, AddressOf command_Progress
                     End If
                     ftCommand.Run(_viewerAfter.Image)

                     Dim freqCommand As FrequencyFilterMaskCommand = New FrequencyFilterMaskCommand(_codecs.Load(CommandProperties.GetImageNameFileName(CommandImage.ImageProcessingDemo__FreqFilterMask_jpg)), ftArray, False)
                     freqCommand.Run()

                     ftCommand.Flags = FastFourierTransformCommandFlags.InverseFastFourierTransform Or FastFourierTransformCommandFlags.Gray Or FastFourierTransformCommandFlags.Scale Or FastFourierTransformCommandFlags.Both
                     ftCommand.Run(_viewerAfter.Image)
                     Return
                  Else
                     ' Resize the image to make sure the image's dimensions are power of two.
                     Dim sizecommand As SizeCommand = New SizeCommand(256, 256, RasterSizeFlags.Bicubic)
                     sizecommand.Run(_viewerAfter.Image)

                     Dim ftArray As FourierTransformInformation = New FourierTransformInformation(_viewerAfter.Image)
                     ' Apply FFT.
                     Dim ftCommand As FastFourierTransformCommand

                     If _checkBoxOptionsDialog.Checked Then
                        Dim Dlg As FastFourierTransformDialog = New FastFourierTransformDialog()
                        If Dlg.ShowDialog(Me) = DialogResult.OK Then
                           ftCommand = New FastFourierTransformCommand(ftArray, Dlg.FastFourierTransformCommand.Flags)
                           If _checkBoxProgress.Checked Then
                              AddHandler ftCommand.Progress, AddressOf command_Progress
                           End If
                           ftCommand.Run(_viewerAfter.Image)

                           Dim rc As LeadRect = New LeadRect(0, 0, CType(_viewerAfter.Image.Width / 2, Integer), CType(_viewerAfter.Image.Height / 2, Integer))
                           Dim freqCommand As FrequencyFilterCommand = New FrequencyFilterCommand(ftArray, rc, Dlg.FrequencyFilterCommand.Flags)
                           freqCommand.Run()

                           ftCommand.Flags = FastFourierTransformCommandFlags.InverseFastFourierTransform Or FastFourierTransformCommandFlags.Gray Or FastFourierTransformCommandFlags.Scale Or FastFourierTransformCommandFlags.Both
                           ftCommand.Run(_viewerAfter.Image)
                        Else
                           Return
                        End If
                     Else
                        ftCommand = New FastFourierTransformCommand(ftArray, FastFourierTransformCommandFlags.FastFourierTransform Or FastFourierTransformCommandFlags.Gray)
                        If _checkBoxProgress.Checked Then
                           AddHandler ftCommand.Progress, AddressOf command_Progress
                        End If

                        ftCommand.Run(_viewerAfter.Image)

                        Dim rc As LeadRect = New LeadRect(0, 0, CType(_viewerAfter.Image.Width / 2, Integer), CType(_viewerAfter.Image.Height / 2, Integer))
                        Dim freqCommand As FrequencyFilterCommand = New FrequencyFilterCommand(ftArray, rc, FrequencyFilterCommandFlags.OutsideX Or FrequencyFilterCommandFlags.OutsideY)
                        freqCommand.Run()

                        ftCommand.Flags = FastFourierTransformCommandFlags.InverseFastFourierTransform Or FastFourierTransformCommandFlags.Gray Or FastFourierTransformCommandFlags.Scale Or FastFourierTransformCommandFlags.Both
                        ftCommand.Run(_viewerAfter.Image)
                     End If
                     Return
                  End If
               ElseIf TypeOf command Is DiscreteFourierTransformCommand Then
                  Dim cmd As DiscreteFourierTransformCommand = TryCast(command, DiscreteFourierTransformCommand)
                  Dim ft As FourierTransformInformation = New FourierTransformInformation(_viewerAfter.Image)
                  If _checkBoxOptionsDialog.Checked Then
                     Dim Dlg As DiscreteFourierTransformDialog = New DiscreteFourierTransformDialog(_viewerAfter.Image)
                     If Dlg.ShowDialog(Me) = DialogResult.OK Then
                        cmd.FourierTransformInformation = ft
                        cmd.Range = Dlg.DiscreteFourierTransformCommand.Range
                        cmd.Flags = Dlg.DiscreteFourierTransformCommand.Flags

                        If _checkBoxProgress.Checked Then
                           AddHandler cmd.Progress, AddressOf command_Progress
                        End If
                        cmd.Run(_viewerAfter.Image)

                        Dim disCommand As FourierTransformDisplayCommand = New FourierTransformDisplayCommand()
                        disCommand.Flags = Dlg.FourierTransformDisplayCommand.Flags
                        disCommand.FourierTransformInformation = cmd.FourierTransformInformation
                        ' plot frequency magnitude
                        If _checkBoxProgress.Checked Then
                           AddHandler disCommand.Progress, AddressOf command_Progress
                        End If
                        disCommand.Run(_viewerAfter.Image)
                        Return
                     Else
                        Return
                     End If
                  Else
                     cmd.FourierTransformInformation = ft
                     Dim rect As LeadRect = New LeadRect(0, 0, _viewerAfter.Image.Width - 1, _viewerAfter.Image.Height - 1)
                     cmd.Range = rect
                     cmd.Flags = DiscreteFourierTransformCommandFlags.DiscreteFourierTransform Or DiscreteFourierTransformCommandFlags.Gray Or DiscreteFourierTransformCommandFlags.Range Or DiscreteFourierTransformCommandFlags.InsideX Or DiscreteFourierTransformCommandFlags.InsideY

                     If _checkBoxProgress.Checked Then
                        AddHandler cmd.Progress, AddressOf command_Progress
                     End If
                     cmd.Run(_viewerAfter.Image)

                     Dim disCommand As FourierTransformDisplayCommand = New FourierTransformDisplayCommand()
                     disCommand.Flags = FourierTransformDisplayCommandFlags.Log Or FourierTransformDisplayCommandFlags.Magnitude
                     disCommand.FourierTransformInformation = cmd.FourierTransformInformation
                     ' plot frequency magnitude
                     If _checkBoxProgress.Checked Then
                        AddHandler disCommand.Progress, AddressOf command_Progress
                     End If
                     disCommand.Run(_viewerAfter.Image)
                  End If

               ElseIf TypeOf command Is FrequencyFilterMaskCommand Then
                  ' Resize the image to make sure the image's dimensions are power of two.
                  Dim sizecommand As SizeCommand = New SizeCommand(256, 256, RasterSizeFlags.Bicubic)
                  sizecommand.Run(_viewerBefore.Image)

                  Dim ftArray As FourierTransformInformation = New FourierTransformInformation(_viewerBefore.Image)
                  ' Apply FFT.
                  Dim ftCommand As FastFourierTransformCommand = New FastFourierTransformCommand(ftArray, FastFourierTransformCommandFlags.FastFourierTransform Or FastFourierTransformCommandFlags.Gray)
                  If _checkBoxProgress.Checked Then
                     AddHandler ftCommand.Progress, AddressOf command_Progress
                  End If

                  ftCommand.Run(_viewerBefore.Image)

                  Dim rc As LeadRect = New LeadRect(0, 0, CType(_viewerBefore.Image.Width / 2, Integer), CType(_viewerBefore.Image.Height / 2, Integer))
                  Dim freqCommand As FrequencyFilterMaskCommand = New FrequencyFilterMaskCommand(_viewerBefore.Image, ftArray, False)
                  freqCommand.Run()

                  ftCommand.Flags = FastFourierTransformCommandFlags.InverseFastFourierTransform Or FastFourierTransformCommandFlags.Gray Or FastFourierTransformCommandFlags.Scale Or FastFourierTransformCommandFlags.Both
                  ftCommand.Run(_viewerBefore.Image)
                  Return

               ElseIf TypeOf command Is SkeletonCommand Then
                  Dim cmd As SkeletonCommand = TryCast(command, SkeletonCommand)
                  cmd.Threshold = 128
               ElseIf TypeOf command Is CorrelationListCommand Then
                  If _viewerAfter.Image.HasRegion Then
                     _viewerAfter.Image.MakeRegionEmpty()
                  End If

                  Dim cmd As CorrelationListCommand = TryCast(command, CorrelationListCommand)
                  Dim copyRectangle As CopyRectangleCommand = New CopyRectangleCommand()

                  Dim rc_cor As LeadRect = New LeadRect(327, 378, 22, 28)
                  copyRectangle.Rectangle = rc_cor
                  copyRectangle.Run(_viewerBefore.Image)
                  cmd.CorrelationImage = copyRectangle.DestinationImage.Clone()

                  rc_cor = New LeadRect(283, 378, 22, 28)
                  copyRectangle.Rectangle = rc_cor
                  copyRectangle.Run(_viewerBefore.Image)
                  cmd.CorrelationImage.AddPage(copyRectangle.DestinationImage.Clone())

                  cmd.Points = New LeadPoint(29) {}
                  cmd.ListIndex = New Integer(29) {}
                  cmd.Threshold = 90
                  cmd.XStep = 1
                  cmd.YStep = 1
                  runAfterImage = False
                  cmd.Run(_viewerAfter.Image)

                  Dim i_cor As Integer = 0
                  Do While i_cor < cmd.NumberOfPoints
                     rc_cor = New LeadRect(cmd.Points(i_cor).X, cmd.Points(i_cor).Y, 22, 28)
                     If i_cor = 0 Then
                        _viewerAfter.Image.AddRectangleToRegion(Nothing, rc_cor, RasterRegionCombineMode.Set)
                     Else
                        _viewerAfter.Image.AddRectangleToRegion(Nothing, rc_cor, RasterRegionCombineMode.Or)
                     End If
                     i_cor += 1
                  Loop

                  Return
               ElseIf TypeOf command Is CorrelationCommand Then
                  If _viewerAfter.Image.HasRegion Then
                     _viewerAfter.Image.MakeRegionEmpty()
                  End If

                  Dim rc_cor As LeadRect = New LeadRect(327, 378, 22, 28)
                  Dim cmd As CorrelationCommand = TryCast(command, CorrelationCommand)
                  cmd.CorrelationImage = _viewerBefore.Image.Clone()
                  cmd.CorrelationImage.AddRectangleToRegion(Nothing, rc_cor, RasterRegionCombineMode.Set)
                  cmd.Points = New LeadPoint(9) {}
                  cmd.Threshold = 80
                  cmd.XStep = 2
                  cmd.YStep = 2
                  runAfterImage = False
                  cmd.Run(_viewerAfter.Image)
                  Dim i_cor As Integer = 0
                  Do While i_cor < cmd.NumberOfPoints
                     rc_cor = New LeadRect(cmd.Points(i_cor).X, cmd.Points(i_cor).Y, 22, 28)
                     If i_cor = 0 Then
                        _viewerAfter.Image.AddRectangleToRegion(Nothing, rc_cor, RasterRegionCombineMode.Set)
                     Else
                        _viewerAfter.Image.AddRectangleToRegion(Nothing, rc_cor, RasterRegionCombineMode.Or)
                     End If
                     i_cor += 1
                  Loop
                  Return
               ElseIf TypeOf command Is ObjectInformationCommand Then
                  Dim cmd As ObjectInformationCommand = TryCast(command, ObjectInformationCommand)
                  cmd.Weighted = False
                  runAfterImage = False
               ElseIf TypeOf command Is UserFilterCommand Then
                  Dim cmd As UserFilterCommand = TryCast(command, UserFilterCommand)
                  cmd.CenterPoint = New LeadPoint(1, 1)
                  cmd.Divisor = 1
                  cmd.FilterHeight = 3
                  cmd.FilterWidth = 3
                  cmd.Matrix = New Integer() {0, -1, 0, -1, 5, -1, 0, -1, 0}
                  cmd.Offset = 0
                  cmd.Type = UserFilterCommandType.Sum
               ElseIf TypeOf command Is DirectionEdgeStatisticalCommand Then
                  Dim cmd As DirectionEdgeStatisticalCommand = TryCast(command, DirectionEdgeStatisticalCommand)
                  cmd.Angle = 4500
                  cmd.BackGroundColor = New RasterColor(0, 0, 0)
                  cmd.Dimension = 3
                  cmd.EdgeColor = New RasterColor(255, 255, 255)
                  cmd.Threshold = 35
               ElseIf TypeOf command Is RevEffectCommand Then
                  Dim cmd As RevEffectCommand = TryCast(command, RevEffectCommand)
                  cmd.LineSpace = 3
                  cmd.MaximumHeight = 37
               ElseIf TypeOf command Is ShadowCommand Then
                  Dim cmd As ShadowCommand = TryCast(command, ShadowCommand)
                  cmd.Angle = ShadowCommandAngle.NorthWest
                  cmd.Threshold = 0
                  cmd.Type = ShadowCommandType.GrayShadow
               ElseIf TypeOf command Is SubtractBackgroundCommand Then
                  Dim cmd As SubtractBackgroundCommand = TryCast(command, SubtractBackgroundCommand)
                  cmd.BrightnessFactor = 150
                  cmd.Flags = SubtractBackgroundCommandFlags.BackgroundIsDarker Or SubtractBackgroundCommandFlags.SubtractedImage
                  cmd.RollingBall = 100
                  cmd.ShrinkingSize = SubtractBackgroundCommandType.DependOnRollingBallSize

                  cmd.Run(_viewerAfter.Image)
                  Return

               ElseIf TypeOf command Is AgingCommand Then
                  If TypeOf command Is PerimeterLength Then
                     If _viewerBefore.Image.HasRegion Then
                        Messager.ShowInformation(Me, String.Format("Perimeter Length = {0}", EffectsUtilities.GetRegionPerimeterLength(_viewerBefore.Image, Nothing)))
                     Else
                        Messager.ShowInformation(Me, "The image must have a region")
                     End If
                     Return
                  ElseIf TypeOf command Is IsRegistrationMark Then
                     Messager.ShowInformation(Me, String.Format("Is Registration Mark = {0}", CoreUtilities.IsRegistrationMark(_viewerBefore.Image, RegistrationMarkCommandType.TShape, 90, 110, 31, 29)))
                     Return
                  End If

                  Dim cmd As AgingCommand = TryCast(command, AgingCommand)
                  cmd.DustColor = New RasterColor(0, 0, 0)
                  cmd.DustDensity = 10
                  cmd.Flags = AgingCommandFlags.AddDust Or AgingCommandFlags.ScratchColor Or AgingCommandFlags.DustColor Or AgingCommandFlags.PitsInverse
                  cmd.HorizontalScratchCount = 10
                  cmd.MaximumPitSize = 15
                  cmd.MaximumScratchLength = CType(_viewerBefore.Image.Width / 3, Integer)
                  cmd.PitsColor = New RasterColor(0, 0, 0)
                  cmd.PitsDensity = 10
                  cmd.ScratchColor = New RasterColor(255, 255, 255)
                  cmd.VerticalScratchCount = 15
               ElseIf TypeOf command Is AdaptiveContrastCommand Then
                  Dim cmd As AdaptiveContrastCommand = TryCast(command, AdaptiveContrastCommand)
                  cmd.Amount = 255
                  cmd.Dimension = 9
                  cmd.Type = AdaptiveContrastCommandType.Linear
               ElseIf TypeOf command Is ChangeIntensityCommand Then
                  Dim cmd As ChangeIntensityCommand = TryCast(command, ChangeIntensityCommand)
                  Dim dlg As ChangeIntensityDialog = New ChangeIntensityDialog()
                  If _checkBoxOptionsDialog.Checked Then
                     dlg.Value = 250
                     dlg.Text = "Change Intensity"
                     dlg._lblBrightness.Text = "Brightness"
                     dlg._tbBrightness.Minimum = -1000
                     dlg._tbBrightness.Maximum = 1000

                     If dlg.ShowDialog(Me) = DialogResult.OK Then
                        cmd.Brightness = dlg.Value
                     Else
                        Return
                     End If
                  Else
                     cmd.Brightness = 250
                  End If

               ElseIf TypeOf command Is ChangeContrastCommand Then
                  Dim cmd As ChangeContrastCommand = TryCast(command, ChangeContrastCommand)
                  Dim dlg As ChangeIntensityDialog = New ChangeIntensityDialog()
                  If _checkBoxOptionsDialog.Checked Then
                     dlg.Value = 250
                     dlg.Text = "Change Contrast"
                     dlg._lblBrightness.Text = "Contrast"
                     dlg._tbBrightness.Minimum = -1000
                     dlg._tbBrightness.Maximum = 1000


                     If dlg.ShowDialog(Me) = DialogResult.OK Then
                        cmd.Contrast = dlg.Value
                     Else
                        Return
                     End If
                  Else
                     cmd.Contrast = 250
                  End If
               ElseIf TypeOf command Is ChangeHueCommand Then
                  Dim cmd As ChangeHueCommand = TryCast(command, ChangeHueCommand)
                  Dim dlg As ChangeIntensityDialog = New ChangeIntensityDialog()
                  If _checkBoxOptionsDialog.Checked Then
                     dlg.Value = 180
                     dlg.Text = "Change Hue"
                     dlg._lblBrightness.Text = "Angle"
                     dlg._tbBrightness.Minimum = -360
                     dlg._tbBrightness.Maximum = 360

                     If dlg.ShowDialog(Me) = DialogResult.OK Then
                        cmd.Angle = dlg.Value
                     Else
                        Return
                     End If
                  Else
                     cmd.Angle = 180
                  End If
               ElseIf TypeOf command Is SmoothCommand Then
                  _allowEventDuringProcess = False
                  Dim cmd As SmoothCommand = TryCast(command, SmoothCommand)
                  cmd.Flags = 0
                  cmd.Length = 10
                  If _checkBoxProgress.Checked Then
                     AddHandler cmd.Progress, AddressOf command_Progress
                  End If

                  cmd.Run(_viewerAfter.Image)
                  Return
               ElseIf TypeOf command Is LineRemoveCommand Then
                  _allowEventDuringProcess = False
                  Dim cmd As LineRemoveCommand = TryCast(command, LineRemoveCommand)
                  cmd.Type = LineRemoveCommandType.Horizontal
                  cmd.Flags = LineRemoveCommandFlags.UseGap
                  cmd.GapLength = 2
                  cmd.MaximumLineWidth = 5
                  cmd.MinimumLineLength = 200
                  cmd.MaximumWallPercent = 10
                  cmd.Wall = 7
                  If _checkBoxProgress.Checked Then
                     AddHandler cmd.Progress, AddressOf command_Progress
                  End If
                  cmd.Run(_viewerAfter.Image)
                  Return
               ElseIf TypeOf command Is BorderRemoveCommand Then
                  _allowEventDuringProcess = False
                  Dim cmd As BorderRemoveCommand = TryCast(command, BorderRemoveCommand)
                  cmd.Border = BorderRemoveBorderFlags.All
                  cmd.Flags = BorderRemoveCommandFlags.UseVariance
                  cmd.Percent = 20
                  cmd.Variance = 2
                  cmd.WhiteNoiseLength = 5
                  If _checkBoxProgress.Checked Then
                     AddHandler cmd.Progress, AddressOf command_Progress
                  End If
                  cmd.Run(_viewerAfter.Image)
                  Return
               ElseIf TypeOf command Is InvertedTextCommand Then
                  _allowEventDuringProcess = False
                  Dim cmd As InvertedTextCommand = TryCast(command, InvertedTextCommand)
                  cmd.Flags = 0
                  cmd.MaximumBlackPercent = 95
                  cmd.MinimumBlackPercent = 75
                  cmd.MinimumInvertHeight = 65
                  cmd.MinimumInvertWidth = 900
                  If _checkBoxProgress.Checked Then
                     AddHandler cmd.Progress, AddressOf command_Progress
                  End If
                  cmd.Run(_viewerAfter.Image)
                  Return
               ElseIf TypeOf command Is DotRemoveCommand Then
                  _allowEventDuringProcess = False
                  Dim cmd As DotRemoveCommand = TryCast(command, DotRemoveCommand)
                  cmd.Flags = DotRemoveCommandFlags.UseSize
                  cmd.MaximumDotHeight = 8
                  cmd.MaximumDotWidth = 8
                  cmd.MinimumDotHeight = 6
                  cmd.MinimumDotWidth = 6
                  If _checkBoxProgress.Checked Then
                     AddHandler cmd.Progress, AddressOf command_Progress
                  End If
                  cmd.Run(_viewerAfter.Image)
                  Return
               ElseIf TypeOf command Is HolePunchRemoveCommand Then
                  _allowEventDuringProcess = False
                  Dim cmd As HolePunchRemoveCommand = TryCast(command, HolePunchRemoveCommand)
                  cmd.Flags = HolePunchRemoveCommandFlags.UseLocation
                  cmd.Location = HolePunchRemoveCommandLocation.Left
                  cmd.MaximumHoleCount = 4
                  cmd.MinimumHoleCount = 2
                  cmd.MaximumHoleWidth = 1500
                  cmd.MaximumHoleHeight = 1500
                  cmd.MinimumHoleHeight = 100
                  cmd.MinimumHoleWidth = 100
                  If _checkBoxProgress.Checked Then
                     AddHandler cmd.Progress, AddressOf command_Progress
                  End If

                  cmd.Run(_viewerAfter.Image)
                  Return
               ElseIf TypeOf command Is ChangeSaturationCommand Then
                  Dim cmd As ChangeSaturationCommand = TryCast(command, ChangeSaturationCommand)
                  Dim dlg As ChangeIntensityDialog = New ChangeIntensityDialog()
                  If _checkBoxOptionsDialog.Checked Then
                     dlg.Value = 250
                     dlg.Text = "Change Saturation"
                     dlg._lblBrightness.Text = "Change"
                     dlg._tbBrightness.Minimum = -1000
                     dlg._tbBrightness.Maximum = 1000

                     If dlg.ShowDialog(Me) = DialogResult.OK Then
                        cmd.Change = dlg.Value
                     Else
                        Return
                     End If
                  Else
                     cmd.Change = 250
                  End If
               ElseIf TypeOf command Is GammaCorrectCommand Then
                  Dim cmd As GammaCorrectCommand = TryCast(command, GammaCorrectCommand)
                  If _checkBoxOptionsDialog.Checked Then
                     Dim GammaCorrectDlg As GammaCorrectDialog = New GammaCorrectDialog()
                     If GammaCorrectDlg.ShowDialog(Me) = DialogResult.OK Then
                        cmd.Gamma = GammaCorrectDlg.GammaCorrectCommand.Gamma
                     Else
                        Return
                     End If
                  Else
                     cmd.Gamma = 250
                  End If
               ElseIf TypeOf command Is HistogramContrastCommand Then
                  Dim cmd As HistogramContrastCommand = TryCast(command, HistogramContrastCommand)
                  Dim dlg As ChangeIntensityDialog = New ChangeIntensityDialog()
                  If _checkBoxOptionsDialog.Checked Then
                     dlg.Value = 750
                     dlg.Text = "Histogram Contrast"
                     dlg._lblBrightness.Text = "Contrast"
                     dlg._tbBrightness.Minimum = -1000
                     dlg._tbBrightness.Maximum = 1000

                     If dlg.ShowDialog(Me) = DialogResult.OK Then
                        cmd.Contrast = dlg.Value
                     Else
                        Return
                     End If
                  Else
                     cmd.Contrast = 750
                  End If
               ElseIf TypeOf command Is HistogramEqualizeCommand Then
                  Dim cmd As HistogramEqualizeCommand = TryCast(command, HistogramEqualizeCommand)
                  If _checkBoxOptionsDialog.Checked Then
                     Dim HistogramEqualizeDlg As HistogramEqualizeDialog = New HistogramEqualizeDialog()
                     If HistogramEqualizeDlg.ShowDialog(Me) = DialogResult.OK Then
                        cmd.Type = HistogramEqualizeDlg.HistogramEqualizeCommand.Type
                     Else
                        Return
                     End If
                  Else
                     cmd.Type = HistogramEqualizeType.Yuv
                  End If
               ElseIf TypeOf command Is IntensityDetectCommand Then
                  Dim cmd As IntensityDetectCommand = TryCast(command, IntensityDetectCommand)
                  If _checkBoxOptionsDialog.Checked Then
                     Dim IntensityDetectdlg As IntensityDetectDialog = New IntensityDetectDialog()
                     If IntensityDetectdlg.ShowDialog(Me) = DialogResult.OK Then
                        cmd.Channel = IntensityDetectdlg.Channel
                        cmd.HighThreshold = IntensityDetectdlg.High
                        cmd.InColor = IntensityDetectdlg.InColor
                        cmd.LowThreshold = IntensityDetectdlg.Low
                        cmd.OutColor = IntensityDetectdlg.OutColor
                     Else
                        Return
                     End If
                  Else
                     cmd.Channel = IntensityDetectCommandFlags.Master
                     cmd.HighThreshold = 255
                     cmd.InColor = New RasterColor(255, 255, 255)
                     cmd.LowThreshold = 128
                     cmd.OutColor = New RasterColor(0, 0, 0)
                  End If
               ElseIf TypeOf command Is PosterizeCommand Then
                  Dim cmd As PosterizeCommand = TryCast(command, PosterizeCommand)
                  cmd.Levels = 6
               ElseIf TypeOf command Is RemapIntensityCommand Then
                  Dim cmd As RemapIntensityCommand = TryCast(command, RemapIntensityCommand)
                  If _checkBoxOptionsDialog.Checked Then
                     Dim Dlg As RemapIntensityDialog
                     Dlg = New RemapIntensityDialog()
                     If Dlg.ShowDialog(Me) = DialogResult.OK Then
                        cmd.Flags = Dlg.RemapIntensityCommand.Flags
                        cmd.LookupTable = Dlg.RemapIntensityCommand.LookupTable
                     Else
                        Return
                     End If
                  Else
                     Dim lut As Integer() = New Integer(255) {}
                     lut(0) = 255
                     lut(255) = 0
                     EffectsUtilities.GetFunctionalLookupTable(lut, 0, 255, 0, FunctionalLookupTableFlags.Linear)

                     cmd.Flags = RemapIntensityCommandFlags.Master
                     cmd.LookupTable = lut
                  End If
               ElseIf TypeOf command Is MinMaxBitsCommand Then
                  Dim cmd As MinMaxBitsCommand = TryCast(command, MinMaxBitsCommand)
                  If _checkBoxProgress.Checked Then
                     AddHandler cmd.Progress, AddressOf command_Progress
                  End If
                  cmd.Run(_viewerBefore.Image)
                  Messager.ShowInformation(Me, String.Format("Minimum Bit = {0}{1}Maximum Bit = {2}", cmd.MinimumBit, Environment.NewLine, cmd.MaximumBit))
                  Return
               ElseIf TypeOf command Is MinMaxValuesCommand Then
                  Dim cmd As MinMaxValuesCommand = TryCast(command, MinMaxValuesCommand)
                  If _checkBoxProgress.Checked Then
                     AddHandler cmd.Progress, AddressOf command_Progress
                  End If
                  cmd.Run(_viewerBefore.Image)
                  Messager.ShowInformation(Me, String.Format("Minimum Value = {0}{1}Maximum Value = {2}", cmd.MinimumValue, Environment.NewLine, cmd.MaximumValue))
                  Return
               ElseIf TypeOf command Is ApplyTransformationParametersCommand Then
                  _viewerAfter.Image = _viewerBefore.Image.Clone()
                  If _viewerAfter.Image.HasRegion Then
                     _viewerAfter.Image.MakeRegionEmpty()
                  End If
                  If _viewerBefore.Image.HasRegion Then
                     _viewerBefore.Image.MakeRegionEmpty()
                  End If
                  Dim rmData As SearchRegistrationMarksCommandData() = New SearchRegistrationMarksCommandData(2) {}

                  'Mark1
                  rmData(0) = New SearchRegistrationMarksCommandData()
                  rmData(0).Rectangle = New LeadRect(680, 20, 941 - 680, 218 - 20)
                  rmData(0).MarkDetectedPoints = New LeadPoint(0) {}
                  rmData(0).Width = 31
                  rmData(0).Height = 29
                  rmData(0).Type = RegistrationMarkCommandType.TShape
                  rmData(0).MinimumScale = 90
                  rmData(0).MaximumScale = 110
                  rmData(0).SearchMarkCount = 1

                  'Mark2
                  rmData(1) = New SearchRegistrationMarksCommandData()
                  rmData(1).Rectangle = New LeadRect(665, 790, 899 - 665, 961 - 790)
                  rmData(1).MarkDetectedPoints = New LeadPoint(0) {}
                  rmData(1).Width = 31
                  rmData(1).Height = 29
                  rmData(1).Type = RegistrationMarkCommandType.TShape
                  rmData(1).MinimumScale = 90
                  rmData(1).MaximumScale = 110
                  rmData(1).SearchMarkCount = 1

                  'Mark3
                  rmData(2) = New SearchRegistrationMarksCommandData()
                  rmData(2).Rectangle = New LeadRect(7, 1073, 298 - 7, 1246 - 1073)
                  rmData(2).MarkDetectedPoints = New LeadPoint(0) {}
                  rmData(2).Width = 31
                  rmData(2).Height = 29
                  rmData(2).Type = RegistrationMarkCommandType.TShape
                  rmData(2).MinimumScale = 90
                  rmData(2).MaximumScale = 110
                  rmData(2).SearchMarkCount = 1
                  Dim command1 As SearchRegistrationMarksCommand = New SearchRegistrationMarksCommand(rmData)
                  command1.Run(_viewerBefore.Image)
                  If (rmData(2).MarkDetectedCount <> 1) OrElse (rmData(1).MarkDetectedCount <> 1) OrElse (rmData(0).MarkDetectedCount <> 1) Then
                     Return
                  End If

                  Dim original As LeadPoint() = {New LeadPoint(81400, 11300), New LeadPoint(78600, 87400), New LeadPoint(14300, 115400)}

                  Dim detected As LeadPoint() = {rmData(0).MarkDetectedPoints(0), rmData(1).MarkDetectedPoints(0), rmData(2).MarkDetectedPoints(0)}

                  'Find center of mass for detected registration marks in the transformed image
                  Dim transformed As LeadPoint() = CoreUtilities.GetRegistrationMarksCenterMass(_viewerBefore.Image, detected)
                  'Find transformation parameters
                  Dim parameters As TransformationParameters = CoreUtilities.GetTransformationParameters(_viewerBefore.Image, original, transformed)
                  'Apply transformatin parameters to correct the image
                  Dim applyCommand As ApplyTransformationParametersCommand = New ApplyTransformationParametersCommand(parameters.XTranslation, parameters.YTranslation, parameters.Angle, parameters.XScale, parameters.YScale, ApplyTransformationParametersCommandFlags.Normal)
                  If _checkBoxProgress.Checked Then
                     AddHandler applyCommand.Progress, AddressOf command_Progress
                  End If
                  applyCommand.Run(_viewerAfter.Image)
                  Return
               ElseIf TypeOf command Is SolarizeCommand Then
                  Dim cmd As SolarizeCommand = TryCast(command, SolarizeCommand)
                  cmd.Threshold = 90
               ElseIf TypeOf command Is GrayscaleCommand Then
                  Dim cmd As GrayscaleCommand = TryCast(command, GrayscaleCommand)
                  Dim GrayScaleDlg As GrayScaleDialog = New GrayScaleDialog()

                  If _checkBoxOptionsDialog.Checked Then
                     If GrayScaleDlg.ShowDialog(Me) = DialogResult.OK Then
                        cmd.BitsPerPixel = GrayScaleDlg.Grayscalecommand.BitsPerPixel
                     Else
                        Return
                     End If
                  Else
                     cmd.BitsPerPixel = 8
                  End If
               ElseIf TypeOf command Is WindowLevelCommand Then
                  _viewerAfter.Image.Dispose()
                  _viewerAfter.Image = _viewerBefore.Image.Clone()
                  Dim cmd As WindowLevelCommand = TryCast(command, WindowLevelCommand)
                  Dim lookupSize As Integer
                  Dim lookupTable As RasterColor()

                  ' Change the bitmap to 16-bit grayscale
                  Dim graycommand As GrayscaleCommand = New GrayscaleCommand(16)
                  graycommand.Run(_viewerBefore.Image)

                  Dim minMaxBits As MinMaxBitsCommand = New MinMaxBitsCommand()
                  Dim minMaxValues As MinMaxValuesCommand = New MinMaxValuesCommand()

                  minMaxBits.Run(_viewerBefore.Image)
                  minMaxValues.Run(_viewerBefore.Image)

                  lookupSize = (1 << (minMaxBits.MaximumBit - minMaxBits.MinimumBit + 1))
                  lookupTable = New RasterColor(lookupSize - 1) {}

                  If _viewerAfter.Image.HasRegion Then
                     MessageBox.Show("This function doesn't support regions. Please uncheck the use region option", "Info")
                     Return
                  Else
                     If _checkBoxOptionsDialog.Checked Then
                        Dim windowLevelDlg As RasterWindowLevelDialog = New RasterWindowLevelDialog()
                        windowLevelDlg.Image = _viewerBefore.Image
                        windowLevelDlg.ShowPreview = True
                        windowLevelDlg.ShowRange = True
                        windowLevelDlg.ShowZoomLevel = True
                        windowLevelDlg.ZoomToFit = False
                        windowLevelDlg.LowBit = minMaxBits.MinimumBit
                        windowLevelDlg.HighBit = minMaxBits.MaximumBit
                        windowLevelDlg.Low = minMaxValues.MinimumValue
                        windowLevelDlg.High = minMaxValues.MaximumValue
                        windowLevelDlg.WindowLevelFlags = RasterPaletteWindowLevelFlags.Inside Or RasterPaletteWindowLevelFlags.Linear
                        windowLevelDlg.LookupTable = lookupTable
                        windowLevelDlg.StartColor = New RasterColor(0, 0, 0)
                        windowLevelDlg.EndColor = New RasterColor(255, 255, 255)

                        If windowLevelDlg.ShowDialog(Owner) = DialogResult.OK Then
                           If windowLevelDlg.Signed Then
                              RasterPalette.WindowLevelFillLookupTable(lookupTable, windowLevelDlg.StartColor, windowLevelDlg.EndColor, windowLevelDlg.Low, windowLevelDlg.High, windowLevelDlg.LowBit, windowLevelDlg.HighBit, minMaxValues.MinimumValue, minMaxValues.MaximumValue, windowLevelDlg.Factor, windowLevelDlg.WindowLevelFlags Or CType(0, RasterPaletteWindowLevelFlags))
                           Else
                              RasterPalette.WindowLevelFillLookupTable(lookupTable, windowLevelDlg.StartColor, windowLevelDlg.EndColor, windowLevelDlg.Low, windowLevelDlg.High, windowLevelDlg.LowBit, windowLevelDlg.HighBit, minMaxValues.MinimumValue, minMaxValues.MaximumValue, windowLevelDlg.Factor, windowLevelDlg.WindowLevelFlags Or (RasterPaletteWindowLevelFlags.None))
                           End If

                           cmd.LowBit = minMaxBits.MinimumBit
                           cmd.HighBit = minMaxBits.MaximumBit
                           cmd.LookupTable = lookupTable
                           cmd.Order = RasterByteOrder.Bgr
                        Else
                           Return
                        End If

                     Else
                        Dim size As Integer = (1 << (minMaxBits.MaximumBit - minMaxBits.MinimumBit + 1))
                        Dim lut As RasterColor() = New RasterColor(size - 1) {}

                        Dim x As Integer = 0

                        For x = 0 To CType((size / 2) - 1, Integer)
                           lut(x) = New RasterColor(255, 0, 0)
                        Next

                        For x = CType(size / 2, Integer) To (size - 1)
                           Dim y As Byte = CType((x) * 255 / (size), Byte)
                           lut(x) = New RasterColor(y, y, y)
                        Next

                        cmd.LowBit = minMaxBits.MinimumBit
                        cmd.HighBit = minMaxBits.MaximumBit
                        cmd.LookupTable = lut
                        cmd.Order = RasterByteOrder.Bgr
                     End If
                  End If
               ElseIf TypeOf command Is LightControlCommand Then
                  Dim cmd As LightControlCommand = TryCast(command, LightControlCommand)
                  cmd.Average = New Integer() {150, 140, 128}
                  cmd.Type = LightControlCommandType.Yuv
                  cmd.LowerAverage = New Integer() {100, 120, 80}
                  cmd.UpperAverage = New Integer() {190, 200, 220}
               ElseIf TypeOf command Is SpatialFilterCommand Then
                  command = New SpatialFilterCommand(SpatialFilterCommandPredefined.EmbossEast)
               ElseIf TypeOf command Is BinaryFilterCommand Then
                  command = New BinaryFilterCommand(BinaryFilterCommandPredefined.DilationOmniDirectional)
               ElseIf TypeOf command Is ChannelMixerCommand Then
                  Dim cmd As ChannelMixerCommand = TryCast(command, ChannelMixerCommand)
                  cmd.RedFactor = New ChannelMixerCommandFactor(150, 0, 0, 0)
                  cmd.GreenFactor = New ChannelMixerCommandFactor(0, 100, 0, 0)
                  cmd.BlueFactor = New ChannelMixerCommandFactor(0, 0, 100, 0)
               ElseIf TypeOf command Is MultiscaleEnhancementCommand Then
                  Dim cmd As MultiscaleEnhancementCommand = TryCast(command, MultiscaleEnhancementCommand)
                  cmd.Contrast = 1500
                  cmd.EdgeCoefficient = -1
                  cmd.EdgeLevels = -1
                  cmd.Flags = MultiscaleEnhancementCommandFlags.EdgeEnhancement
                  cmd.LatitudeCoefficient = -1
                  cmd.LatitudeLevels = -1
                  cmd.Type = MultiscaleEnhancementCommandType.Gaussian
               ElseIf TypeOf command Is ColorizeGrayCommand Then
                  Dim cmd As ColorizeGrayCommand = TryCast(command, ColorizeGrayCommand)
                  Dim grayColors As ColorizeGrayCommandData() = New ColorizeGrayCommandData(5) {}
                  For i As Integer = 0 To 5
                     grayColors(i) = New ColorizeGrayCommandData()
                  Next i

                  grayColors(0).Threshold = 9999
                  grayColors(1).Threshold = 19999
                  grayColors(2).Threshold = 29999
                  grayColors(3).Threshold = 39999
                  grayColors(4).Threshold = 49999
                  grayColors(5).Threshold = 59999 ' This value will be ignored

                  grayColors(0).Color = New RasterColor(255, 0, 0)
                  grayColors(1).Color = New RasterColor(0, 255, 0)
                  grayColors(2).Color = New RasterColor(0, 0, 255)
                  grayColors(3).Color = New RasterColor(0, 255, 255)
                  grayColors(4).Color = New RasterColor(255, 0, 255)
                  grayColors(5).Color = New RasterColor(255, 255, 0)

                  cmd.GrayColors = grayColors
                  runAfterImage = False
               ElseIf TypeOf command Is StatisticsInformationCommand Then
                  Dim cmd As StatisticsInformationCommand = TryCast(command, StatisticsInformationCommand)
                  cmd.Channel = RasterColorChannel.Master
                  cmd.Start = 0
                  cmd.End = 255
               ElseIf TypeOf command Is DigitalSubtractCommand Then
                  Dim cmd As DigitalSubtractCommand = TryCast(command, DigitalSubtractCommand)
                  cmd.MaskImage = _viewerBefore.Image
                  cmd.Flags = DigitalSubtractCommandFlags.ContrastEnhancement Or DigitalSubtractCommandFlags.OptimizeRange
               ElseIf TypeOf command Is ContrastBrightnessIntensityCommand Then
                  Dim cmd As ContrastBrightnessIntensityCommand = TryCast(command, ContrastBrightnessIntensityCommand)
                  cmd.Contrast = -146
                  cmd.Brightness = 385
                  cmd.Intensity = 240
               ElseIf TypeOf command Is ApplyMathematicalLogicCommand Then
                  Dim cmd As ApplyMathematicalLogicCommand = TryCast(command, ApplyMathematicalLogicCommand)
                  cmd.Factor = 151
                  cmd.Flags = ApplyMathematicalLogicCommandFlags.OperationMultiply Or ApplyMathematicalLogicCommandFlags.Master Or ApplyMathematicalLogicCommandFlags.ValueDoNothing Or ApplyMathematicalLogicCommandFlags.ResultDoNothing
               ElseIf TypeOf command Is LocalHistogramEqualizeCommand Then
                  Dim cmd As LocalHistogramEqualizeCommand = TryCast(command, LocalHistogramEqualizeCommand)
                  If _checkBoxOptionsDialog.Checked Then
                     Dim LocalHistogramEqualizeDlg As LocalHistogramEqualizeDialog = New LocalHistogramEqualizeDialog(_viewerAfter.Image)
                     If LocalHistogramEqualizeDlg.ShowDialog(Me) = DialogResult.OK Then
                        cmd.Height = LocalHistogramEqualizeDlg.LocalHistogramEqualizeCommand.Height
                        cmd.HeightExtension = LocalHistogramEqualizeDlg.LocalHistogramEqualizeCommand.HeightExtension
                        cmd.Smooth = LocalHistogramEqualizeDlg.LocalHistogramEqualizeCommand.Smooth
                        cmd.Type = LocalHistogramEqualizeDlg.LocalHistogramEqualizeCommand.Type
                        cmd.Width = LocalHistogramEqualizeDlg.LocalHistogramEqualizeCommand.Width
                        cmd.WidthExtension = LocalHistogramEqualizeDlg.LocalHistogramEqualizeCommand.WidthExtension

                     Else
                        Return
                     End If
                  Else
                     cmd.Height = 15
                     cmd.HeightExtension = 100
                     cmd.Smooth = 0
                     cmd.Type = HistogramEqualizeType.Yuv
                     cmd.Width = 15
                     cmd.WidthExtension = 100
                  End If
               ElseIf TypeOf command Is DynamicBinaryCommand Then
                  Dim cmd As DynamicBinaryCommand = TryCast(command, DynamicBinaryCommand)
                  cmd.Dimension = 8
                  cmd.LocalContrast = 16
               ElseIf TypeOf command Is RemapHueCommand Then
                  Dim cmd As RemapHueCommand = TryCast(command, RemapHueCommand)

                  Dim length As Integer

                  If _viewerBefore.Image.BitsPerPixel >= 48 Then
                     length = &H10000
                  ElseIf Not (_viewerBefore.Image.BitsPerPixel = 16 OrElse _viewerBefore.Image.BitsPerPixel = 12) Then
                     length = 256
                  ElseIf Not _viewerBefore.Image.GetLookupTable() Is Nothing AndAlso _viewerBefore.Image.UseLookupTable Then
                     length = 256
                  Else
                     length = (1 << _viewerBefore.Image.BitsPerPixel)
                  End If

                  'Allocate tables
                  Dim maskTable As Integer() = New Integer(length - 1) {}
                  Dim hueTable As Integer() = New Integer(length - 1) {}

                  'Initialize tables
                  Dim i As Integer = 0
                  Do While i < length / 3
                     hueTable(i) = 0
                     i += 1
                  Loop

                  i = CType(length / 3, Integer)
                  Do While i < length * 2 / 3
                     hueTable(i) = 255
                     maskTable(i) = 1
                     i += 1
                  Loop

                  i = CType(length * 2 / 3, Integer)
                  Do While i < length / 3
                     hueTable(i) = 0
                     i += 1
                  Loop

                  'Get the hue for green
                  Dim hsvRef As RasterHsvColor = RasterHsvColor.FromRasterColor(New RasterColor(0, 255, 0))

                  Dim hueGreen As Integer = hsvRef.H

                  'Obtain new hue  
                  hsvRef = RasterHsvColor.FromRasterColor(New RasterColor(255, 128, 0))
                  Dim hueChange As Integer = CInt(hsvRef.H) - CInt(hueGreen)
                  If (hueChange > 0) Then
                     hueChange = CInt(hueChange)
                  Else
                     hueChange = CInt(hueChange + length - 1)
                  End If
                  hueGreen = CType(hueGreen * (length - 1) / 255, Integer)
                  hueChange = CType(hueChange * (length - 1) / 255, Integer)

                  'Set values in hueTable, maskTable 
                  hueTable(hueGreen) = (hueTable(hueGreen) + hueChange)
                  maskTable(hueGreen) = 1

                  'set the hues near green (+/- 15)
                  Dim count As Integer = CType((15 * (length - 1)) / 255, Integer)
                  i = Increment(hueGreen, length)
                  Do While count > 0
                     hueTable(i) = Add(hueTable(i), hueChange, length)
                     maskTable(i) = 1
                     i = Increment(i, length)
                     count -= 1
                  Loop

                  count = CType((15 * (length - 1)) / 255, Integer)
                  i = Decrement(hueGreen, length)
                  Do While count > 0
                     hueTable(i) = Add(hueTable(i), hueChange, length)
                     maskTable(i) = 1
                     i = Decrement(i, length)
                     count -= 1
                  Loop

                  cmd.HueTable = hueTable
                  cmd.LookUpTableLength = length
                  cmd.Mask = maskTable
               ElseIf TypeOf command Is GrayScaleExtendedCommand Then
                  Dim cmd As GrayScaleExtendedCommand = TryCast(command, GrayScaleExtendedCommand)
                  If _checkBoxOptionsDialog.Checked Then
                     Dim GrayScaleExtendedDlg As GrayScaleExtendedDialog = New GrayScaleExtendedDialog()
                     If GrayScaleExtendedDlg.ShowDialog(Me) = DialogResult.OK Then
                        cmd.RedFactor = GrayScaleExtendedDlg.GrayScaleExtendedCommand.RedFactor
                        cmd.GreenFactor = GrayScaleExtendedDlg.GrayScaleExtendedCommand.GreenFactor
                        cmd.BlueFactor = GrayScaleExtendedDlg.GrayScaleExtendedCommand.BlueFactor
                     Else
                        Return
                     End If
                  Else
                     cmd.RedFactor = 300
                     cmd.GreenFactor = 590
                     cmd.BlueFactor = 110
                  End If
               ElseIf TypeOf command Is SwapColorsCommand Then
                  Dim cmd As SwapColorsCommand = TryCast(command, SwapColorsCommand)
                  cmd.Type = SwapColorsCommandType.RedGreen
               ElseIf TypeOf command Is ConvertToColoredGrayCommand Then
                  Dim cmd As ConvertToColoredGrayCommand = TryCast(command, ConvertToColoredGrayCommand)
                  cmd.RedFactor = 250
                  cmd.GreenFactor = 625
                  cmd.BlueFactor = 125
                  cmd.RedGrayFactor = 300
                  cmd.GreenGrayFactor = 200
                  cmd.BlueGrayFactor = 100
               ElseIf TypeOf command Is RemoveRedEyeCommand Then
                  Dim cmd As RemoveRedEyeCommand = TryCast(command, RemoveRedEyeCommand)
                  If _checkBoxOptionsDialog.Checked Then
                     Dim RemoveRedEyeDlg As RemoveRedEyeDialog = New RemoveRedEyeDialog()
                     If RemoveRedEyeDlg.ShowDialog(Me) = DialogResult.OK Then
                        cmd.Lightness = RemoveRedEyeDlg.RemoveRedEyeCommand.Lightness
                        cmd.NewColor = RemoveRedEyeDlg.RemoveRedEyeCommand.NewColor
                        cmd.Threshold = RemoveRedEyeDlg.RemoveRedEyeCommand.Threshold
                     Else
                        Return
                     End If
                  Else
                     cmd.Lightness = 100
                     cmd.NewColor = New RasterColor(128, 128, 128)
                     cmd.Threshold = 0
                  End If
               ElseIf TypeOf command Is MultiplyCommand Then
                  Dim cmd As MultiplyCommand = TryCast(command, MultiplyCommand)
                  If _checkBoxOptionsDialog.Checked Then
                     Dim MultiplyDlg As MultiplyDialog = New MultiplyDialog()

                     If MultiplyDlg.ShowDialog(Me) = DialogResult.OK Then
                        cmd.Factor = MultiplyDlg.MultiplyCommand.Factor
                     Else
                        Return
                     End If
                  Else
                     cmd.Factor = 151
                  End If
               ElseIf TypeOf command Is GrayScaleToDuotoneCommand Then
                  Dim graycommand As GrayscaleCommand = New GrayscaleCommand(8)
                  graycommand.Run(_viewerAfter.Image)
                  Dim cmd As GrayScaleToDuotoneCommand = TryCast(command, GrayScaleToDuotoneCommand)
                  If _checkBoxOptionsDialog.Checked Then
                     Dim GrayScaleToDuotoneDlg As GrayScaleToDuotoneDialog = New GrayScaleToDuotoneDialog()
                     If GrayScaleToDuotoneDlg.ShowDialog(Me) = DialogResult.OK Then
                        cmd.Color = GrayScaleToDuotoneDlg.GrayScaleToDuotoneCommand.Color
                        cmd.NewColor = Nothing
                        cmd.Type = GrayScaleToDuotoneDlg.GrayScaleToDuotoneCommand.Type
                     Else
                        Return
                     End If
                  Else
                     cmd.Color = New RasterColor(255, 0, 0)
                     cmd.NewColor = Nothing
                     cmd.Type = GrayScaleToDuotoneCommandMixingType.ReplaceOldWithNew
                  End If
               ElseIf TypeOf command Is GrayScaleToMultitoneCommand Then
                  Dim graycommand As GrayscaleCommand = New GrayscaleCommand(8)
                  graycommand.Run(_viewerAfter.Image)
                  Dim cmd As GrayScaleToMultitoneCommand = TryCast(command, GrayScaleToMultitoneCommand)
                  If _checkBoxOptionsDialog.Checked Then
                     Dim GrayScaleToMultitoneDlg As GrayScaleToMultitoneDialog = New GrayScaleToMultitoneDialog()
                     If GrayScaleToMultitoneDlg.ShowDialog(Me) = DialogResult.OK Then
                        cmd.Colors = GrayScaleToMultitoneDlg.GrayScaleToMultitoneCommand.Colors
                        cmd.Distribution = GrayScaleToMultitoneCommandDistributionType.Linear
                        cmd.Gradient = Nothing
                        cmd.Tone = GrayScaleToMultitoneDlg.GrayScaleToMultitoneCommand.Tone
                        cmd.Type = GrayScaleToMultitoneDlg.GrayScaleToMultitoneCommand.Type

                        If _checkBoxProgress.Checked Then
                           AddHandler cmd.Progress, AddressOf command_Progress
                        End If
                        cmd.Run(_viewerAfter.Image)
                        Return
                     Else
                        Return
                     End If
                  Else
                     cmd.Colors = New RasterColor(1) {}
                     cmd.Colors(0) = New RasterColor(255, 255, 0)
                     cmd.Colors(1) = New RasterColor(255, 0, 0)
                     cmd.Distribution = GrayScaleToMultitoneCommandDistributionType.Linear
                     cmd.Gradient = Nothing
                     cmd.Tone = GrayScaleToMultitoneCommandToneType.Duotone
                     cmd.Type = GrayScaleToDuotoneCommandMixingType.MixWithOldValue
                  End If
               ElseIf TypeOf command Is ColorLevelCommand Then
                  Dim cmd As ColorLevelCommand = TryCast(command, ColorLevelCommand)
                  cmd.Master = New ColorLevelCommandData(20, 200, 0, 255, 100)
                  cmd.Blue = New ColorLevelCommandData(0, 255, 255, 0, 100)
                  cmd.Flags = ColorLevelCommandFlags.Blue Or ColorLevelCommandFlags.Master
               ElseIf TypeOf command Is AutoColorLevelCommand Then
                  Dim cmd As AutoColorLevelCommand = TryCast(command, AutoColorLevelCommand)
                  If _checkBoxOptionsDialog.Checked Then
                     Dim AutoColorLevelDlg As AutoColorLevelDialog = New AutoColorLevelDialog()
                     If AutoColorLevelDlg.ShowDialog(Me) = DialogResult.OK Then
                        cmd.BlackClip = AutoColorLevelDlg.AutoColorLevelCommand.BlackClip
                        cmd.WhiteClip = AutoColorLevelDlg.AutoColorLevelCommand.WhiteClip
                        cmd.Flag = AutoColorLevelDlg.AutoColorLevelCommand.Flag
                        cmd.Type = AutoColorLevelDlg.AutoColorLevelCommand.Type
                     Else
                        Return
                     End If
                  Else
                     cmd.BlackClip = 50
                     cmd.WhiteClip = 50
                     cmd.Flag = AutoColorLevelCommandFlags.None
                     cmd.Type = AutoColorLevelCommandType.Level
                  End If
               ElseIf TypeOf command Is SelectiveColorCommand Then
                  Dim cmd As SelectiveColorCommand = TryCast(command, SelectiveColorCommand)
                  Dim selColors As SelectiveColorCommandData() = New SelectiveColorCommandData(8) {}

                  For i As Integer = 0 To 8
                     selColors(i) = New SelectiveColorCommandData()
                  Next i
                  selColors(CInt(SelectiveCommandColorTypes.Red)).Cyan = -100
                  selColors(CInt(SelectiveCommandColorTypes.Yellow)).Cyan = 34
                  selColors(CInt(SelectiveCommandColorTypes.Yellow)).Magenta = 100
                  selColors(CInt(SelectiveCommandColorTypes.Yellow)).Yellow = 40
                  selColors(CInt(SelectiveCommandColorTypes.Green)).Black = 100
                  selColors(CInt(SelectiveCommandColorTypes.Neutral)).Cyan = -65
                  selColors(CInt(SelectiveCommandColorTypes.Neutral)).Magenta = -39
                  selColors(CInt(SelectiveCommandColorTypes.Neutral)).Yellow = 63
                  cmd.ColorsData = selColors
               ElseIf TypeOf command Is ColorReplaceCommand Then
                  Dim cmd As ColorReplaceCommand = TryCast(command, ColorReplaceCommand)
                  Dim colors As ColorReplaceCommandColor() = New ColorReplaceCommandColor(0) {}
                  colors(0) = New ColorReplaceCommandColor(New RasterColor(200, 0, 35), 100)
                  cmd.Hue = 9000
                  cmd.Saturation = 0
                  cmd.Brightness = 0
               ElseIf TypeOf command Is ChangeHueSaturationIntensityCommand Then
                  Dim cmd As ChangeHueSaturationIntensityCommand = TryCast(command, ChangeHueSaturationIntensityCommand)
                  If _checkBoxOptionsDialog.Checked Then
                     Dim Dlg As ChangeHueSaturationIntensityDialog = New ChangeHueSaturationIntensityDialog()
                     If Dlg.ShowDialog(Me) = DialogResult.OK Then
                        cmd.Hue = Dlg.ChangeHueSaturationIntensityCommand.Hue
                        cmd.Intensity = Dlg.ChangeHueSaturationIntensityCommand.Intensity
                        cmd.Saturation = Dlg.ChangeHueSaturationIntensityCommand.Saturation
                        cmd.Data = Dlg.ChangeHueSaturationIntensityCommand.Data
                     Else
                        Return
                     End If
                  Else
                     Dim data As ChangeHueSaturationIntensityCommandData() = New ChangeHueSaturationIntensityCommandData(0) {}
                     data(0) = New ChangeHueSaturationIntensityCommandData(18000, 0, 50, 115, 45, 145, 15)
                     cmd.Hue = 0
                     cmd.Intensity = 0
                     cmd.Saturation = 0
                  End If
               ElseIf TypeOf command Is MathematicalFunctionCommand Then
                  Dim cmd As MathematicalFunctionCommand = TryCast(command, MathematicalFunctionCommand)
                  cmd.Factor = 100
                  cmd.Type = MathematicalFunctionCommandType.Logarithm
               ElseIf TypeOf command Is ColorMergeCommand Then
                  Dim MyRegion As Byte() = Nothing
                  Dim RegionChecked As Boolean = _checkBoxUseRegion.Checked
                  If _viewerBefore.Image.HasRegion Then
                     MyRegion = RasterRegionConverter.GetGdiRegionData(_viewerBefore.Image, Nothing)
                  End If

                  Dim cmd As ColorMergeCommand = TryCast(command, ColorMergeCommand)
                  cmd.Type = ColorMergeCommandType.Rgb
                  If _checkBoxProgress.Checked Then
                     AddHandler cmd.Progress, AddressOf command_Progress
                  End If
                  cmd.Run(_viewerBefore.Image)
                  _viewerAfter.Image = cmd.DestinationImage.Clone()
                  Dim ChangeViewPerspective As ChangeViewPerspectiveCommand = New ChangeViewPerspectiveCommand(True, _viewerBefore.Image.ViewPerspective)
                  ChangeViewPerspective.Run(_viewerAfter.Image)

                  If RegionChecked Then
                     RasterRegionConverter.AddGdiDataToRegion(_viewerBefore.Image, Nothing, MyRegion, 0, RasterRegionCombineMode.Set)
                     RasterRegionConverter.AddGdiDataToRegion(_viewerAfter.Image, Nothing, MyRegion, 0, RasterRegionCombineMode.Set)
                  End If

                  Return
               ElseIf TypeOf command Is ColorThresholdCommand Then
                  Dim Components As ColorThresholdCommandComponent() = New ColorThresholdCommandComponent(2) {}
                  For i As Integer = 0 To 2
                     Components(i) = New ColorThresholdCommandComponent()
                  Next i

                  Components(0).MinimumRange = 0
                  Components(0).MaximumRange = 360
                  Components(0).Flags = ColorThresholdCommandFlags.EffectAll
                  Components(1).MinimumRange = 24
                  Components(1).MaximumRange = 100
                  Components(1).Flags = ColorThresholdCommandFlags.EffectAll
                  Components(2).MinimumRange = 230
                  Components(2).MaximumRange = 255
                  Components(2).Flags = ColorThresholdCommandFlags.EffectAll
                  Dim cmd As ColorThresholdCommand = TryCast(command, ColorThresholdCommand)
                  cmd.ColorSpace = ColorThresholdCommandType.Hsv
                  cmd.Components = Components
               ElseIf TypeOf command Is OffsetCommand Then
                  Dim cmd As OffsetCommand = TryCast(command, OffsetCommand)
                  cmd.HorizontalShift = CType(_viewerBefore.Image.Width / 2, Integer)
                  cmd.VerticalShift = CType(_viewerBefore.Image.Height / 2, Integer)
                  cmd.BackColor = New RasterColor(255, 0, 0)
                  cmd.Type = OffsetCommandType.WrapAround
               ElseIf TypeOf command Is BricksTextureCommand Then
                  Dim cmd As BricksTextureCommand = TryCast(command, BricksTextureCommand)
                  cmd.BricksHeight = 20
                  cmd.BricksWidth = 60
                  cmd.EdgeWidth = 4
                  cmd.MortarWidth = 3
                  cmd.RowDifference = 35
                  cmd.ShadeAngle = 315
                  cmd.Flags = BricksTextureCommandFlags.ColoredMortar Or BricksTextureCommandFlags.SmoothedOutEdges
                  cmd.MortarColor = New RasterColor(128, 128, 128)
                  cmd.MortarRoughness = 50
                  cmd.MortarRoughnessEvenness = 0
                  cmd.BricksRoughness = 100
                  cmd.BricksRoughnessEvenness = 1
               ElseIf TypeOf command Is CanvasCommand Then
                  Dim cmd As CanvasCommand = TryCast(command, CanvasCommand)
                  cmd.CanvasImage = _codecs.Load(CommandProperties.GetImageNameFileName(CommandImage.ImageProcessingDemo__Ulay3_Bmp))
                  cmd.XOffset = 0
                  cmd.YOffset = 0
                  cmd.Transparency = 100
                  cmd.Emboss = 100
                  cmd.Flags = CanvasCommandFlags.TileShift
               ElseIf TypeOf command Is CloudsCommand Then
                  Dim cmd As CloudsCommand = TryCast(command, CloudsCommand)
                  cmd.Type = CloudsCommandType.Opacity
                  cmd.Seed = 0
                  cmd.Opacity = 70
                  cmd.Frequency = 8
                  cmd.Density = 4
                  cmd.BackColor = New RasterColor(0, 0, 0)
                  cmd.CloudsColor = New RasterColor(255, 255, 255)
               ElseIf TypeOf command Is RomanMosaicCommand Then
                  Dim cmd As RomanMosaicCommand = TryCast(command, RomanMosaicCommand)
                  cmd.Border = 3
                  cmd.Color = New RasterColor(0, 0, 0)
                  cmd.Flags = RomanMosaicCommandFlags.GrayShadow Or RomanMosaicCommandFlags.Both
                  cmd.TileWidth = 15
                  cmd.TileHeight = 15
                  cmd.ShadowThresh = 0
                  cmd.ShadowAngle = ShadowCommandAngle.SouthEast
               ElseIf TypeOf command Is MosaicTilesCommand Then
                  Dim cmd As MosaicTilesCommand = TryCast(command, MosaicTilesCommand)
                  cmd.BorderColor = New RasterColor(0, 0, 0)
                  cmd.Flags = MosaicTilesCommandFlags.ShadowGray Or MosaicTilesCommandFlags.Cartesian
                  cmd.Opacity = 50
                  cmd.TileWidth = 40
                  cmd.TileHeight = 40
                  cmd.TilesColor = New RasterColor(128, 128, 128)
                  cmd.ShadowThreshold = 0
                  cmd.ShadowAngle = ShadowCommandAngle.SouthEast
                  cmd.PenWidth = 3
               ElseIf TypeOf command Is VignetteCommand Then
                  Dim cmd As VignetteCommand = TryCast(command, VignetteCommand)
                  cmd.Width = CType(_viewerAfter.Image.Width / 2, Integer)
                  cmd.Height = CType(_viewerAfter.Image.Height / 2, Integer)

                  If _viewerAfter.Image.HasRegion Then
                     Dim Rect As LeadRect = _viewerAfter.Image.GetRegionBounds(Nothing)
                     cmd.Origin = New LeadPoint(CType((Rect.Width) / 2, Integer), CType((Rect.Height) / 2, Integer))
                     cmd.Width = CType(Rect.Width / 2, Integer)
                     cmd.Height = CType(Rect.Height / 2, Integer)
                  Else
                     cmd.Origin = New LeadPoint(CType(_viewerAfter.Image.Width / 2, Integer), CType(_viewerAfter.Image.Height / 2, Integer))
                  End If
                  cmd.Fading = 40
                  cmd.FadingRate = 20
                  cmd.Flags = VignetteCommandFlags.Ellipse Or VignetteCommandFlags.FillOut
                  cmd.VignetteColor = New RasterColor(255, 255, 255)
                  If _checkBoxProgress.Checked Then
                     AddHandler cmd.Progress, AddressOf command_Progress
                  End If
                  cmd.Run(_viewerAfter.Image)
                  Return
               ElseIf TypeOf command Is FragmentCommand Then
                  Dim cmd As FragmentCommand = TryCast(command, FragmentCommand)
                  cmd.Offset = 4
                  cmd.Opacity = 100
               ElseIf TypeOf command Is GammaCorrectExtendedCommand Then
                  Dim cmd As GammaCorrectExtendedCommand = TryCast(command, GammaCorrectExtendedCommand)
                  If _checkBoxOptionsDialog.Checked Then
                     Dim GammaCorrectExtendedDlg As GammaCorrectExtendedDialog = New GammaCorrectExtendedDialog()
                     If GammaCorrectExtendedDlg.ShowDialog(Me) = DialogResult.OK Then
                        cmd.Type = GammaCorrectExtendedDlg.GammaCorrectExtendedCommand.Type
                        cmd.Gamma = GammaCorrectExtendedDlg.GammaCorrectExtendedCommand.Gamma
                     Else
                        Return
                     End If
                  Else
                     cmd.Type = GammaCorrectExtendedCommandType.YuvSpace
                     cmd.Gamma = 200
                  End If
               ElseIf TypeOf command Is PlasmaCommand Then
                  Dim cmd As PlasmaCommand = TryCast(command, PlasmaCommand)
                  cmd.Shift = 0
                  cmd.Size = 200
                  cmd.Opacity = 50
                  cmd.RedFrequency = 200
                  cmd.GreenFrequency = 0
                  cmd.BlueFrequency = 100
                  cmd.Flags = PlasmaCommandFlags.Cross Or PlasmaCommandFlags.CustomColor
                  'cmd.Flags = PlasmaCommandFlags.Random1;
               ElseIf TypeOf command Is PerspectiveCommand Then
                  Dim pt As LeadPoint() = New LeadPoint(3) {}
                  Dim cmd As PerspectiveCommand = TryCast(command, PerspectiveCommand)
                  If _viewerAfter.Image.HasRegion Then
                     MessageBox.Show("This function doesn't support regions. Please uncheck the use region option", "Info")
                     Return
                  Else
                     pt(0).X = 10
                     pt(0).Y = 10
                     pt(1).X = _viewerAfter.Image.Width - 10
                     pt(1).Y = 20
                     pt(2).X = 40
                     pt(2).Y = _viewerAfter.Image.Height - 20
                     pt(3).X = _viewerAfter.Image.Width - 10
                     pt(3).Y = _viewerAfter.Image.Height - 10
                     cmd.CornerPoints = pt
                     cmd.Type = PerspectiveCommandType.Color
                     cmd.FillColor = New RasterColor(0, 0, 0)
                     If _checkBoxProgress.Checked Then
                        AddHandler cmd.Progress, AddressOf command_Progress
                     End If
                     cmd.Run(_viewerAfter.Image)
                     Return
                  End If
               ElseIf TypeOf command Is ColoredBallsCommand Then
                  Dim cmd As ColoredBallsCommand = TryCast(command, ColoredBallsCommand)
                  cmd.Ripple = 1000
                  cmd.ShadingColor = New RasterColor(0, 0, 0)
                  cmd.BackGroundColor = New RasterColor(255, 255, 0)
                  cmd.BallColorOpacity = 10
                  cmd.BallColorOpacityVariation = 0
                  cmd.Flags = ColoredBallsCommandFlags.BackGroundColor Or ColoredBallsCommandFlags.ShadingCircular Or ColoredBallsCommandFlags.Sticker Or ColoredBallsCommandFlags.BallsColorOpacity
                  cmd.HighLightAngle = 0
                  cmd.HighLightColor = New RasterColor(255, 255, 255)
                  cmd.NumberOfBalls = 1000
                  cmd.Size = 10
                  cmd.SizeVariation = 0
                  cmd.BallColors = New RasterColor(0) {}
                  cmd.BallColors(0) = New RasterColor(255, 0, 0)

                  cmd.Run(_viewerAfter.Image)
                  Return
               ElseIf TypeOf command Is PointillistCommand Then
                  Dim cmd As PointillistCommand = TryCast(command, PointillistCommand)
                  cmd.FillColor = New RasterColor(0, 0, 0)
                  cmd.Flags = PointillistCommandFlags.BackGroundColor Or PointillistCommandFlags.Sticker
                  cmd.Size = 5

                  cmd.Run(_viewerAfter.Image)
                  Return

               ElseIf TypeOf command Is HalfTonePatternCommand Then
                  Dim cmd As HalfTonePatternCommand = TryCast(command, HalfTonePatternCommand)
                  cmd.Type = HalfTonePatternCommandType.Dot
                  cmd.Ripple = 1000
                  cmd.ForeGroundColor = New RasterColor(0, 0, 0)
                  cmd.BackGroundColor = New RasterColor(255, 255, 255)
                  cmd.Contrast = 100

                  cmd.Run(_viewerAfter.Image)
                  Return
               ElseIf TypeOf command Is ColorHalftoneCommand Then
                  Dim cmd As ColorHalftoneCommand = TryCast(command, ColorHalftoneCommand)
                  If _checkBoxOptionsDialog.Checked Then
                     Dim ColorHalftoneDlg As ColorHalftoneDialog = New ColorHalftoneDialog()
                     If ColorHalftoneDlg.ShowDialog(Me) = DialogResult.OK Then
                        cmd.BlackAngle = ColorHalftoneDlg.ColorHalftoneCommand.BlackAngle
                        cmd.CyanAngle = ColorHalftoneDlg.ColorHalftoneCommand.CyanAngle
                        cmd.MagentaAngle = ColorHalftoneDlg.ColorHalftoneCommand.MagentaAngle
                        cmd.YellowAngle = ColorHalftoneDlg.ColorHalftoneCommand.YellowAngle
                        cmd.MaximumRadius = ColorHalftoneDlg.ColorHalftoneCommand.MaximumRadius
                     Else
                        Return
                     End If
                  Else
                     cmd.BlackAngle = 0
                     cmd.CyanAngle = 10
                     cmd.MagentaAngle = 40
                     cmd.YellowAngle = 10
                     cmd.MaximumRadius = 40
                  End If
               ElseIf TypeOf command Is ZigZagCommand Then
                  Dim cmd As ZigZagCommand = TryCast(command, ZigZagCommand)
                  cmd.Amplitude = 30
                  cmd.Attenuation = 10
                  If _viewerBefore.Image.HasRegion Then
                     Dim Rect As LeadRect = _viewerBefore.Image.GetRegionBounds(Nothing)
                     cmd.CenterPoint = New LeadPoint(CType((Rect.Right + Rect.Left) / 2, Integer), CType((Rect.Bottom + Rect.Top) / 2, Integer))
                  Else
                     cmd.CenterPoint = New LeadPoint(CType(_viewerAfter.Image.Width / 2, Integer), CType(_viewerAfter.Image.Height / 2, Integer))
                  End If
                  cmd.FillColor = New RasterColor(0, 0, 0)
                  cmd.Frequency = 20
                  cmd.Flags = ZigZagCommandFlags.PondRippleWave
                  cmd.Phase = 0
               ElseIf TypeOf command Is HighPassCommand Then
                  Dim cmd As HighPassCommand = TryCast(command, HighPassCommand)
                  cmd.Opacity = 50
                  cmd.Radius = 10
               ElseIf TypeOf command Is ResizeInterpolateCommand Then
                  Dim cmd As ResizeInterpolateCommand = TryCast(command, ResizeInterpolateCommand)
                  If _checkBoxOptionsDialog.Checked Then
                     Dim ResizeInterpolateDlg As ResizeInterpolateDialog = New ResizeInterpolateDialog(_viewerBefore.Image.Clone())
                     If ResizeInterpolateDlg.ShowDialog(Me) = DialogResult.OK Then
                        cmd.Width = ResizeInterpolateDlg.ResizeInterpolatecommand.Width
                        cmd.Height = ResizeInterpolateDlg.ResizeInterpolatecommand.Height
                        cmd.ResizeType = ResizeInterpolateDlg.ResizeInterpolatecommand.ResizeType
                     Else
                        Return
                     End If
                  Else
                     cmd.Width = CType(_viewerBefore.Image.Width / 2, Integer)
                     cmd.Height = CType(_viewerBefore.Image.Height / 2, Integer)
                     cmd.ResizeType = ResizeInterpolateCommandType.Lanczos
                  End If
               ElseIf TypeOf command Is DiffuseGlowCommand Then
                  Dim cmd As DiffuseGlowCommand = TryCast(command, DiffuseGlowCommand)
                  cmd.ClearAmount = 80
                  cmd.GlowAmount = 10
                  cmd.GlowColor = New RasterColor(255, 255, 255)
                  cmd.SpreadAmount = 80
                  cmd.WhiteNoiseRange = 0
               ElseIf TypeOf command Is DisplacementCommand Then
                  Dim cmd As DisplacementCommand = TryCast(command, DisplacementCommand)
                  cmd.DisplacementMapImage = _codecs.Load(CommandProperties.GetImageNameFileName(CommandImage.ImageProcessingDemo__Ulay3_Bmp))
                  cmd.Flags = DisplacementCommandFlags.Repeat Or DisplacementCommandFlags.Tile
                  cmd.HorizontalFactor = 100
                  cmd.VerticalFactor = 100
               ElseIf TypeOf command Is DeskewCommand Then
                  Dim cmd As DeskewCommand = TryCast(command, DeskewCommand)
                  If _checkBoxOptionsDialog.Checked Then
                     Dim DeskewDlg As DeskewDialog = New DeskewDialog(cmd)
                     If DeskewDlg.ShowDialog(Me) = DialogResult.OK Then
                        cmd.Flags = DeskewDlg.DeskewCommand.Flags
                        cmd.FillColor = DeskewDlg.DeskewCommand.FillColor
                     Else
                        Return
                     End If
                  Else
                     cmd.Flags = DeskewCommandFlags.DeskewImage Or DeskewCommandFlags.DoNotFillExposedArea
                     cmd.FillColor = New RasterColor(255, 255, 255)
                  End If

                  cmd.Run(_viewerAfter.Image)
                  Return
               ElseIf TypeOf command Is BlankPageDetectorCommand Then
                  Dim cmd As BlankPageDetectorCommand = TryCast(command, BlankPageDetectorCommand)
                  If _checkBoxOptionsDialog.Checked Then
                     Dim BlankPageDetectorDlg As BlankPageDetectorDialog = New BlankPageDetectorDialog(_viewerBefore.Image.Clone())
                     If BlankPageDetectorDlg.ShowDialog(Me) = DialogResult.OK Then
                        cmd.Flags = BlankPageDetectorDlg.BlankPageDetectorcommand.Flags
                        cmd.LeftMargin = BlankPageDetectorDlg.BlankPageDetectorcommand.LeftMargin
                        cmd.TopMargin = BlankPageDetectorDlg.BlankPageDetectorcommand.TopMargin
                        cmd.RightMargin = BlankPageDetectorDlg.BlankPageDetectorcommand.RightMargin
                        cmd.BottomMargin = BlankPageDetectorDlg.BlankPageDetectorcommand.BottomMargin
                     Else
                        Return
                     End If
                  Else
                     cmd.Flags = BlankPageDetectorCommandFlags.DetectNoisyPage
                  End If

                  If _checkBoxProgress.Checked Then
                     AddHandler cmd.Progress, AddressOf command_Progress
                  End If
                  cmd.Run(_viewerBefore.Image)
                  MessageBox.Show(" Is Blank   : " & cmd.IsBlank.ToString() + Constants.vbLf & " Accuracy : " & (cmd.Accuracy * 1.0 / 100) & "%", "Blank Page Detection Results")
                  Return
               ElseIf TypeOf command Is AdjustTintCommand Then
                  Dim cmd As AdjustTintCommand = TryCast(command, AdjustTintCommand)
                  cmd.AngleA = 315
                  cmd.AngleB = 45
               ElseIf TypeOf command Is PerlinCommand Then
                  Dim cmd As PerlinCommand = TryCast(command, PerlinCommand)
                  cmd.Backcolor = New RasterColor(255, 0, 0)
                  cmd.PerlinColor = New RasterColor(255, 255, 0)
                  cmd.PerlinFlags = NoiseLayoutType.PF_Pure Or NoiseLayoutType.PF_Random
                  cmd.Seed = 0
                  cmd.Opacity = 40
               ElseIf TypeOf command Is ColoredPencilCommand Then
                  Dim cmd As ColoredPencilCommand = TryCast(command, ColoredPencilCommand)
                  cmd.Dimension = 20
                  cmd.Ratio = 50
               ElseIf TypeOf command Is MaskConvolutionCommand Then
                  Dim cmd As MaskConvolutionCommand = TryCast(command, MaskConvolutionCommand)
                  cmd.Angle = 315
                  cmd.Depth = 5
                  cmd.Height = 10
                  cmd.Type = MaskConvolutionCommandType.EmbossSplotch
               ElseIf TypeOf command Is KaufmannRegionCommand Then
                  Dim cmd As KaufmannRegionCommand = TryCast(command, KaufmannRegionCommand)
                  Dim GrayCommand As GrayscaleCommand = New GrayscaleCommand(8)
                  GrayCommand.Run(_viewerAfter.Image)
                  cmd.RegionStart = New LeadPoint(258, 254)
                  cmd.RegionThreshold = 127
                  cmd.Radius = 12
                  cmd.RemoveHoles = True
                  cmd.MaximumInput = 255
                  cmd.MinimumInput = 73
                  cmd.CombineMode = RasterRegionCombineMode.Set
               ElseIf TypeOf command Is FadedMaskCommand Then
                  If (Not UseRegionChecked) Then
                     _checkBoxUseRegion.Checked = True
                  End If

                  Dim cmd As FadedMaskCommand = TryCast(command, FadedMaskCommand)
                  cmd.Length = 60
                  cmd.FadeRate = 20
                  cmd.StepSize = 3
                  cmd.Inflate = 0
                  cmd.Flags = FadedMaskCommandFlags.DumpColorStart Or FadedMaskCommandFlags.NoTransparencyFill
                  cmd.MaximumGray = 255
                  cmd.Transparent = New RasterColor(0, 0, 255)
                  runAfterImage = True
                  Return


               End If
               Using wait As WaitCursor = New WaitCursor()
                  If Not command Is Nothing Then
                     Dim image As RasterImage
                     If runAfterImage Then
                        image = _viewerAfter.Image
                     Else
                        image = _viewerBefore.Image
                     End If

                     If _checkBoxProgress.Checked Then
                        AddHandler command.Progress, AddressOf command_Progress
                     End If

                     Dim a As RasterImageChangedFlags = command.Run(image)
                  End If

                  If TypeOf command Is CloneCommand Then
                     Dim cmd As CloneCommand = TryCast(command, CloneCommand)
                     _viewerAfter.Image = cmd.DestinationImage
                  ElseIf TypeOf command Is CopyRectangleCommand Then
                     Dim cmd As CopyRectangleCommand = TryCast(command, CopyRectangleCommand)
                     _viewerAfter.Image = cmd.DestinationImage
                  ElseIf TypeOf command Is FadedMaskCommand Then

                     If UseRegionChecked Then
                        _checkBoxUseRegion.Checked = True
                     Else
                        _checkBoxUseRegion.Checked = False
                     End If

                     Dim cmd As FadedMaskCommand = TryCast(command, FadedMaskCommand)
                     _viewerAfter.Image = cmd.MaskImage
                  ElseIf TypeOf command Is AddWeightedCommand Then
                     Dim cmd As AddWeightedCommand = TryCast(command, AddWeightedCommand)
                     cmd.Factor = New Integer(9) {}
                     cmd.Type = AddWeightedCommandType.Average
                     _viewerAfter.Image = cmd.DestinationImage
                  ElseIf TypeOf command Is ShiftDataCommand Then
                        Dim cmd As ShiftDataCommand = TryCast(command, ShiftDataCommand)
                        _viewerAfter.Image = cmd.DestinationImage
                  ElseIf TypeOf command Is SelectDataCommand Then
                        Dim cmd As SelectDataCommand = TryCast(command, SelectDataCommand)
                        _viewerAfter.Image = cmd.DestinationImage
                        'else if (command is FadedMaskCommand)
                        '{
                        '_viewerAfter.Image = ((FadedMaskCommand)command).MaskImage;
                        '}
                  ElseIf TypeOf command Is ColorizeGrayCommand Then
                        Dim cmd As ColorizeGrayCommand = TryCast(command, ColorizeGrayCommand)
                        _viewerAfter.Image = cmd.DestinationImage
                  ElseIf TypeOf command Is StatisticsInformationCommand Then
                        Dim cmd As StatisticsInformationCommand = TryCast(command, StatisticsInformationCommand)
                        Dim sb As StringBuilder = New StringBuilder()
                        sb.Append("Maximum = ")
                        sb.Append(cmd.Maximum)
                        sb.Append(Environment.NewLine)
                        sb.Append("Mean = ")
                        sb.Append(cmd.Mean)
                        sb.Append(Environment.NewLine)
                        sb.Append("Median = ")
                        sb.Append(cmd.Median)
                        sb.Append(Environment.NewLine)
                        sb.Append("Minimum = ")
                        sb.Append(cmd.Minimum)
                        sb.Append(Environment.NewLine)
                        sb.Append("Percent = ")
                        sb.Append(cmd.Percent)
                        sb.Append(Environment.NewLine)
                        sb.Append("PixelCount = ")
                        sb.Append(cmd.PixelCount)
                        sb.Append(Environment.NewLine)
                        sb.Append("StandardDeviation = ")
                        sb.Append(cmd.StandardDeviation)
                        sb.Append(Environment.NewLine)
                        sb.Append("TotalPixelCount = ")
                        sb.Append(cmd.TotalPixelCount)
                        Messager.ShowInformation(Me, sb.ToString())
                  ElseIf TypeOf command Is AddCommand Then
                        Dim cmd As AddCommand = TryCast(command, AddCommand)
                        _viewerAfter.Image = cmd.DestinationImage
                  ElseIf TypeOf command Is AutoCropRectangleCommand Then
                        Dim cmd As AutoCropRectangleCommand = TryCast(command, AutoCropRectangleCommand)
                        Messager.ShowInformation(Me, String.Format("Rectangle = {0}", cmd.Rectangle))
                  ElseIf TypeOf command Is ColorCountCommand Then
                        Dim cmd As ColorCountCommand = TryCast(command, ColorCountCommand)
                        Messager.ShowInformation(Me, String.Format("Color Count = {0}", cmd.ColorCount))
                  ElseIf TypeOf command Is ObjectInformationCommand Then
                        Dim cmd As ObjectInformationCommand = TryCast(command, ObjectInformationCommand)
                        cmd.Weighted = False
                        Messager.ShowInformation(Me, String.Format("Angle = {1}{0}Roundness = {2}{0}Point of center mass = {3}{0}", Environment.NewLine, cmd.Angle, cmd.Roundness, cmd.CenterOfMass))
                  ElseIf TypeOf command Is ColorSeparateCommand Then
                        Dim cmd As ColorSeparateCommand = TryCast(command, ColorSeparateCommand)
                        cmd.Type = ColorSeparateCommandType.Rgb
                        _viewerAfter.Image = cmd.DestinationImage
                  ElseIf TypeOf command Is KaufmannRegionCommand Then
                        Dim cmd As KaufmannRegionCommand = TryCast(command, KaufmannRegionCommand)
                        Dim innerPixelCount As Integer = cmd.PixelsCount
                        cmd.RegionStart = New LeadPoint(228, 305)
                        cmd.RegionThreshold = 29
                        cmd.Radius = 12
                        cmd.RemoveHoles = True
                        cmd.MaximumInput = 255
                        cmd.MinimumInput = 40
                        cmd.CombineMode = RasterRegionCombineMode.Xor
                        If _checkBoxProgress.Checked Then
                           AddHandler cmd.Progress, AddressOf command_Progress
                        End If
                        cmd.Run(_viewerAfter.Image)
                        Dim outerPixelCount As Integer = cmd.PixelsCount
                        Dim ratio As Integer = CInt((CSng(innerPixelCount) / outerPixelCount) * 10000)
                        Messager.ShowInformation(Me, String.Format("Area Ratio(In/Out) = {0}%", CSng(ratio) / 100))
                     End If
               End Using
            End If

         Catch ex As Exception
            Messager.ShowError(Me, ex)
         Finally
            _runAlready = True
            UpdateImageInformation()
            UpdatePages(_viewerBefore.Image, _buttonBeforePageFirst, _buttonBeforePagePrevious, _buttonBeforePageNext, _buttonBeforePageLast, _labelBeforePage)
            UpdatePages(_viewerAfter.Image, _buttonAfterPageFirst, _buttonAfterPagePrevious, _buttonAfterPageNext, _buttonAfterPageLast, _labelAfterPage)

            If _checkBoxProgress.Checked Then
               Progress(True)
            End If
            _isViewerBefore = False
            UpdateImageValues()
            ' making sure that the resulted image has been displayed correctly
            _viewerAfter.Invalidate()
         End Try
      End Sub

      Private Sub command_Progress(ByVal sender As Object, ByVal e As RasterCommandProgressEventArgs)
         _progressBar.Value = e.Percent
         If _allowEventDuringProcess Then
            Application.DoEvents()
         End If

         If _canceled Then
            e.Cancel = True
         End If
      End Sub

      Private Sub Progress(ByVal enable As Boolean)
         If (Not enable) Then
            _activeControl = ActiveControl
         End If

         _canceled = False

         _canClose = enable
         _panelControls.Enabled = enable
         _panelBefore.Enabled = enable
         _panelAfter.Enabled = enable

         For Each i As MenuItem In _mainMenu.MenuItems
            EnableMenus(i, enable)
         Next i

         If enable Then
            _progressBar.Value = 0
            If Not _activeControl Is Nothing Then
               _activeControl.Focus()
            End If
         End If
      End Sub

      Private Sub EnableMenus(ByVal menu As MenuItem, ByVal enable As Boolean)
         menu.Enabled = enable
         For Each i As MenuItem In menu.MenuItems
            EnableMenus(i, enable)
         Next i
      End Sub

      Private Sub MainForm_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
         If (Not _canClose) Then
            e.Cancel = True
         End If
      End Sub

      Private Sub _buttonCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _buttonCancel.Click
         _canceled = True
      End Sub

      Private Sub cmd_Slice(ByVal sender As Object, ByVal e As SliceCommandEventArgs)
         If _viewerAfter.Image.HasRegion Then
            _viewerAfter.Image.AddRectangleToRegion(Nothing, e.SliceRectangle, RasterRegionCombineMode.Xor)
         Else
            _viewerAfter.Image.AddRectangleToRegion(Nothing, e.SliceRectangle, RasterRegionCombineMode.Set)
         End If
      End Sub

      Private Sub _radioButtonRectangle_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _radioButtonRectangle.CheckedChanged
         DisableInteractiveMode(False)
         _addRegion.Shape = ImageViewerRubberBandShape.Rectangle
         _viewerBefore.InteractiveModes.EnableById(_addRegion.Id)
         _addRegion.CombineMode = RegionCombineMode

      End Sub

      Private Sub _radioButtonEllipse_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _radioButtonEllipse.CheckedChanged
         DisableInteractiveMode(False)
         _addRegion.Shape = ImageViewerRubberBandShape.Ellipse
         _viewerBefore.InteractiveModes.EnableById(_addRegion.Id)
         _addRegion.CombineMode = RegionCombineMode

      End Sub

      Private Sub _radioButtonFreeHand_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _radioButtonFreeHand.CheckedChanged
         DisableInteractiveMode(False)
         FreeHandRgn = _radioButtonFreeHand.Checked
         _addRegion.Shape = ImageViewerRubberBandShape.Freehand
         _viewerBefore.InteractiveModes.EnableById(_addRegion.Id)
         _addRegion.CombineMode = RegionCombineMode
         FreeHandRgn = _radioButtonFreeHand.Checked
      End Sub

      Private Sub _radioButtonMagicWand_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _radioButtonMagicWand.CheckedChanged
         DisableInteractiveMode(False)
         AddMagicWand = _radioButtonMagicWand.Checked
         _viewerBefore.InteractiveModes.BeginUpdate()
         AddMagicWandMode.MagicWandRegionCombineMode = RegionCombineMode
         AddMagicWandMode.IsEnabled = True
         _viewerBefore.InteractiveModes.EndUpdate()
      End Sub

      Private Sub _radioButtonSingle_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _radioButtonSingle.CheckedChanged
         RegionCombineMode = RasterRegionCombineMode.Set
         _addRegion.CombineMode = RegionCombineMode

      End Sub

      Private Sub _radioButtonMulti_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _radioButtonMulti.CheckedChanged
         RegionCombineMode = RasterRegionCombineMode.Or
         _addRegion.CombineMode = RegionCombineMode

      End Sub

      Private Sub _radioButtonInvert_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _radioButtonInvert.CheckedChanged
         RegionCombineMode = RasterRegionCombineMode.SetNot
         _addRegion.CombineMode = RegionCombineMode

      End Sub

      Private Sub _radioButtonIntersect_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _radioButtonIntersect.CheckedChanged
         RegionCombineMode = RasterRegionCombineMode.And
         _addRegion.CombineMode = RegionCombineMode

      End Sub

      Private Sub _radioButtonOldandNotNew_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _radioButtonOldandNotNew.CheckedChanged
         RegionCombineMode = RasterRegionCombineMode.AndNotRegion
         _addRegion.CombineMode = RegionCombineMode
      End Sub

      Private Sub _radioButtonNewandNotOld_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _radioButtonNewandNotOld.CheckedChanged
         RegionCombineMode = RasterRegionCombineMode.AndNotImage
         _addRegion.CombineMode = RegionCombineMode
      End Sub

      Private Sub _radioButtonOldXORNew_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _radioButtonOldXORNew.CheckedChanged
         RegionCombineMode = RasterRegionCombineMode.Xor
         _addRegion.CombineMode = RegionCombineMode

      End Sub

      Private Sub _radioButtonNone_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs)
         _viewerBefore.Image.MakeRegionEmpty()
         DisableInteractiveMode((_viewerAfter.Image Is Nothing))
         _viewerBefore.InteractiveModes.EnableById(_noneInteractiveMode.Id)
         If Not _viewerAfter.Image Is Nothing Then
            _viewerAfter.Image.MakeRegionEmpty()
            _viewerAfter.InteractiveModes.EnableById(_noneInteractiveModeViewerAfter.Id)
         End If
      End Sub

      Private Sub _viewer_MouseUp(ByVal sender As Object, ByVal e As MouseEventArgs)
         If (Not AddMagicWand) Then
            _isViewerBefore = sender Is _viewerBefore
            _buttonPressed = MouseButton.None
            If (_isViewerBefore) Then
               _toolTip.Hide(_viewerBefore)
            Else
               _toolTip.Hide(_viewerAfter)
            End If
         End If
      End Sub

      Private Sub _viewer_MouseMove(ByVal sender As Object, ByVal e As MouseEventArgs)
         If (Not AddMagicWand) Then
            Dim Viewer As ImageViewer
            If (_isViewerBefore) Then
               Viewer = _viewerBefore
            Else
               Viewer = _viewerAfter
            End If
            Dim x, y As Integer
            Dim pt As LeadPointD = Viewer.ConvertPoint(Nothing, ImageViewerCoordinateType.Control, ImageViewerCoordinateType.Image, New LeadPointD(e.X, e.Y))
            x = Convert.ToInt32(pt.X)
            y = Convert.ToInt32(pt.Y)

            If _buttonPressed = MouseButton.Rigth AndAlso _isWLImage Then

               UpdateImageValues()
               If _xLastPos < x Then
                  _windowLevelWidth = _windowLevelWidth + (x - _xLastPos) * _scale
               ElseIf _xLastPos > x Then
                  _windowLevelWidth = _windowLevelWidth - (_xLastPos - x) * _scale
               End If

               _xLastPos = x

               CheckValue(_windowLevelWidth, _maxWidth, _minWidth)

               If _yLastPos < y Then
                  _windowLevelCenter = _windowLevelCenter + (y - _yLastPos) * _scale
               ElseIf _yLastPos > y Then
                  _windowLevelCenter = _windowLevelCenter - (_yLastPos - y) * _scale
               End If

               _yLastPos = y

               CheckValue(_windowLevelCenter, _maxLevel, _minLevel)

               ChangeThePalette()
            ElseIf _buttonPressed = MouseButton.Left Then
               If Not (_xLastPos = x AndAlso _yLastPos = y) Then
                  GetCursorData(x, y, e.X, e.Y)
                  _xLastPos = x
                  _yLastPos = y
               End If
            End If
         End If
      End Sub
      Private Sub _viewer_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs)
         Try
            If (Not AddMagicWand) Then
               If FreeHandRgn Then
                  Dim Regiondata As Byte() = Nothing
                  If Not (_viewerBefore.Image Is Nothing) AndAlso (_checkBoxUseRegion.Checked) Then
                     Dim addRegion As ImageViewerAddRegionInteractiveMode = New ImageViewerAddRegionInteractiveMode()

                     For Each oMode As ImageViewerInteractiveMode In _viewerBefore.InteractiveModes
                        If oMode.IsEnabled Then
                           addRegion = TryCast(oMode, ImageViewerAddRegionInteractiveMode)
                        End If
                     Next oMode

                     If (Not addRegion Is Nothing) Then
                        Regiondata = RasterRegionConverter.GetGdiRegionData(_viewerBefore.Image, Nothing)
                        If (Regiondata Is Nothing) AndAlso (RegionCombineMode = RasterRegionCombineMode.And) Then
                           addRegion.CombineMode = RasterRegionCombineMode.Set
                        Else
                           If Not Regiondata Is Nothing Then
                              If (Regiondata.Length = 32) AndAlso (RegionCombineMode = RasterRegionCombineMode.And) Then
                                 addRegion.CombineMode = RasterRegionCombineMode.Set
                              Else
                                 addRegion.CombineMode = RegionCombineMode
                              End If
                           End If
                        End If
                     End If
                  End If
               End If

               _isViewerBefore = sender Is _viewerBefore
               Dim Viewer As ImageViewer
               If (_isViewerBefore) Then
                  Viewer = _viewerBefore
               Else
                  Viewer = _viewerAfter
               End If

               If (Not _isMagGlass) Then
                  Dim x, y As Integer
                  Dim pt As LeadPointD = Viewer.ConvertPoint(Nothing, ImageViewerCoordinateType.Control, ImageViewerCoordinateType.Image, New LeadPointD(e.X, e.Y))
                  x = Convert.ToInt32(pt.X)
                  y = Convert.ToInt32(pt.Y)

                  Select Case e.Button
                     Case MouseButtons.Right
                        _buttonPressed = MouseButton.Rigth
                        _xLastPos = x
                        _yLastPos = y

                     Case MouseButtons.Left
                        _buttonPressed = MouseButton.Left
                        GetCursorData(x, y, e.X, e.Y)
                     Case Else
                        _buttonPressed = MouseButton.None
                  End Select
               End If
            End If
         Catch ex As Exception
            MessageBox.Show(ex.ToString())
         End Try
      End Sub

      Private Sub _menuItemHistogram_Click(sender As System.Object, e As System.EventArgs) Handles _menuItemHistogram.Click
         Dim dlg As HistogramDlg = New HistogramDlg(_viewerBefore.Image, _isWLImage)
         dlg.ShowDialog()
      End Sub

      Private Sub _menuItemMagGlassStart_Click(sender As System.Object, e As System.EventArgs) Handles _menuItemMagGlassStart.Click
         DisableInteractiveMode(True)
         _viewerAfter.InteractiveModes.EnableById(_magnifyGlassInteractiveModeViewerAfter.Id)
         _viewerBefore.InteractiveModes.EnableById(_magnifyGlassInteractiveMode.Id)

         _isMagGlass = True
         _menuItemMagGlassStart.Checked = True
         _menuItemMagGlassStop.Checked = False
      End Sub

      Private Sub _menuItemMagGlassStop_Click(sender As System.Object, e As System.EventArgs) Handles _menuItemMagGlassStop.Click
         DisableInteractiveMode(True)
         _viewerAfter.InteractiveModes.EnableById(_noneInteractiveModeViewerAfter.Id)
         _viewerBefore.InteractiveModes.EnableById(_noneInteractiveMode.Id)

         _isMagGlass = False
         _menuItemMagGlassStart.Checked = False
         _menuItemMagGlassStop.Checked = True
      End Sub
      Private Sub CheckValue(ByRef value As Integer, ByVal max As Integer, ByVal min As Integer)
         If value > max Then
            value = max
         End If
         If value < min Then
            value = min
         End If
      End Sub

      Private Sub GetCursorData(ByVal x As Integer, ByVal y As Integer, ByVal CurX As Integer, ByVal CurY As Integer)
         Try
            Dim paletteValue, RGB As String
            Dim Viewer As ImageViewer
            If (_isViewerBefore) Then
               Viewer = _viewerBefore
            Else
               Viewer = _viewerAfter
            End If
            If x < Viewer.Image.Width AndAlso y < Viewer.Image.Height AndAlso x >= 0 AndAlso y >= 0 AndAlso Viewer.Image.GrayscaleMode <> RasterGrayscaleMode.None AndAlso Viewer.Image.BitsPerPixel <> 1 Then
               Dim Data As Byte()
               Dim originalValue As Integer = 0, originalValueT As Integer = 0
               Viewer.Image.Access()
               Data = Viewer.Image.GetPixelData(y, x)
               Viewer.Image.Release()
               Select Case Viewer.Image.BitsPerPixel
                  Case 16, 12
                     Dim high As Integer
                     If (Viewer.Image.HighBit <> -1) Then
                        high = Viewer.Image.HighBit
                     Else
                        high = Viewer.Image.BitsPerPixel
                     End If
                     Dim signedBit As Integer = Viewer.Image.HighBit
                     Dim tmpVal As Integer = CInt(Math.Pow(2, signedBit))
                     originalValue = Data(1) * 256 + Data(0)
                     If originalValue >= tmpVal AndAlso Viewer.Image.Signed Then
                        originalValue = Data(1) * 256 + Data(0)
                        originalValueT = -1 * (((Convert.ToInt32(Math.Pow(2, signedBit - 7) - 1) - Data(1)) * 256 + 255 - Data(0)) + 1)
                     Else
                        originalValueT = Data(1) * 256 + Data(0)
                        originalValue = Data(1) * 256 + Data(0)
                     End If
                  Case 8
                     originalValueT = Data(0)
                     originalValue = Data(0)
               End Select

               paletteValue = "Palette map value = " & _currentPalette(originalValue).B
               RGB = "RGB in the original image = " & originalValueT
            Else
               Dim tmpColor As RasterColor = Viewer.Image.GetPixelColor(y, x)
               RGB = String.Format("RGB = ({0},{1},{2})", tmpColor.R, tmpColor.G, tmpColor.B)
               paletteValue = "Palette map value = " & " 0"
            End If

            If _buttonPressed = MouseButton.Left AndAlso (Not Viewer.InteractiveModes.Contains(New ImageViewerAddRegionInteractiveMode())) Then
               Dim tipMessage As String = String.Format("X = {1} , Y = {2} {0}{3} {0}{4}", Environment.NewLine, x, y, paletteValue, RGB)
               _toolTip.Show(tipMessage, Viewer, CurX + 25, CurY + 25)
            End If
         Catch ex As Exception
         End Try
      End Sub

      Private Sub getWindowLevelForUnSigned(ByVal palette As RasterColor())
         Dim Viewer As ImageViewer
         If (_isViewerBefore) Then
            Viewer = _viewerBefore
         Else
            Viewer = _viewerAfter
         End If
         If Viewer.Image.BitsPerPixel = 1 Then
            Return
         End If
         Try
            Dim lowValue As Integer = 0, highValue As Integer = 0
            Dim max As Integer = _maxValue
            Dim min As Integer = _minValue
            Dim i As Integer = min
            Select Case palette(0).R
               Case 0
                  Do While palette(i).R = 0
                     If i < _maxValue Then
                        i += 1
                     Else
                        Exit Do
                     End If
                  Loop

                  If i = _maxValue Then
                     lowValue = _maxValue
                     highValue = lowValue + 2
                  Else
                     lowValue = i
                     Do While palette(i).R <> 255
                        If i < _maxValue Then
                           i += 1
                        Else
                           Exit Do
                        End If
                     Loop

                     If i = _maxValue Then
                        max = _maxValue
                        highValue = CInt(max + (max - lowValue) * (255.0 - palette(max).R) / palette(max).R)
                     End If
                     If i < _maxValue Then
                        highValue = i
                     End If
                  End If
                  Exit Select
               Case 255
                  i = 0
                  Do While palette(i).R = 255
                     If i < _maxValue Then
                        i += 1
                     Else
                        Exit Do
                     End If
                  Loop

                  If i = _maxValue Then
                     lowValue = -2
                     highValue = 0
                  Else
                     lowValue = i
                     Do While palette(i).R <> 0
                        If i < _maxValue Then
                           i += 1
                        Else
                           highValue = CInt(max + (max - lowValue) * palette(max).R / (255.0 - palette(max).R))
                           Exit Do
                        End If
                     Loop
                     If i < _maxValue Then
                        highValue = i
                     End If
                  End If
                  Exit Select
               Case Else
                  i = 0
                  Do While palette(i).R <> 0 AndAlso palette(i).R <> 255
                     If i < _maxValue Then
                        i += 1
                     Else
                        Exit Do
                     End If
                  Loop

                  If i = _maxValue Then
                     highValue = CInt(max * (255.0 - palette(max).R) / (palette(max).R - palette(min).R) + max)
                     lowValue = min - CInt((max - min) * palette(min).R / (palette(max).R - palette(min).R))
                  Else

                     highValue = i
                     lowValue = min - CInt((((highValue - min) * palette(min).R) / (255.0 - palette(min).R)))

                  End If
                  Exit Select
            End Select

            _windowLevelWidth = highValue - lowValue + 1
            _windowLevelCenter = CInt((highValue + lowValue) / 2)
            CheckValue(_windowLevelWidth, CInt(Math.Pow(2, Viewer.Image.BitsPerPixel)), 1)
            CheckValue(_windowLevelCenter, CInt(Math.Pow(2, Viewer.Image.BitsPerPixel) - 1), CInt(Math.Pow(2, Viewer.Image.BitsPerPixel)) * -1 + 1)
            ChangeThePalette()
         Catch e1 As Exception
         End Try
      End Sub

      Private Sub getWindowLevelForSigned(ByVal palette As RasterColor())
         Dim i As Integer = 0
         Dim lowValue As Integer = 0, highValue As Integer = 0
         Dim Viewer As ImageViewer
         If (_isViewerBefore) Then
            Viewer = _viewerBefore
         Else
            Viewer = _viewerAfter
         End If
         Try
            Select Case palette(0).R
               Case 0
                  Do While palette(i).R = 0 OrElse palette(i).R = 255
                     If i < palette.Length - 1 Then
                        If (i = _maxValue) Then
                           i = _minValue + palette.Length
                        Else
                           i += 1
                        End If
                     Else
                        Exit Do
                     End If
                  Loop

                  If i = palette.Length - 1 Then
                     lowValue = _maxValue + 2
                     highValue = lowValue + 2
                  Else
                     If (i > _maxValue) Then
                        lowValue = i - palette.Length
                     Else
                        lowValue = i
                     End If
                     If lowValue > 0 Then
                        Do While palette(i).R <> 255
                           If i < _maxValue Then
                              i += 1
                           Else
                              Dim max As Integer = _maxValue
                              Dim low As Integer = lowValue
                              highValue = CInt(_maxValue + ((max - low) * (255.0 - palette(max).R)) / palette(max).R)
                              Exit Do
                           End If
                        Loop
                        If i < _maxValue Then
                           highValue = i
                        End If
                     Else
                        Do While palette(i).R <> 0
                           If i < palette.Length - 1 Then
                              i += 1
                           End If
                        Loop

                        highValue = i - palette.Length

                        lowValue = lowValue - CInt(((highValue - lowValue) * (255.0 - palette(lowValue + palette.Length).R)) / (palette(lowValue + palette.Length).R))
                     End If
                  End If
                  Exit Select
               Case 255
                  i = 0
                  Do While palette(i).R = 255 OrElse palette(i).R = 0
                     If i < palette.Length - 1 Then
                        If (i = _maxValue) Then
                           i = _minValue + palette.Length
                        Else
                           i += 1
                        End If
                     Else
                        Exit Do
                     End If
                  Loop

                  If i = palette.Length - 1 Then
                     lowValue = _minValue - 2
                     highValue = lowValue + 2
                  Else
                     If (i > _maxValue) Then
                        lowValue = i - palette.Length
                     Else
                        lowValue = i
                     End If
                     If lowValue > 0 Then
                        Do While palette(i).R <> 0
                           If i < _maxValue Then
                              i += 1
                           Else
                              Dim max As Integer = _maxValue
                              Dim low As Integer = lowValue
                              highValue = CInt(_maxValue + ((max - low) * palette(max).R) / (255.0 - palette(max).R))
                              Exit Do
                           End If
                        Loop
                        If i < _maxValue Then
                           highValue = i
                        End If
                     Else
                        Do While palette(i).R <> 255
                           If i < palette.Length - 1 Then
                              i += 1
                           End If
                        Loop

                        highValue = i - palette.Length

                        lowValue = lowValue - CInt(((highValue - lowValue) * palette(lowValue + palette.Length).R) / (255.0 - palette(lowValue + palette.Length).R))
                     End If
                  End If
                  Exit Select
               Case Else
                  i = 0
                  Do While palette(i).R <> 0 AndAlso palette(i).R <> 255
                     If i < _maxValue Then
                        i += 1
                     Else
                        Exit Do
                     End If
                  Loop

                  If i = _maxValue Then
                     i = palette.Length - Math.Abs(_minValue)
                     Do While palette(i).R = 0 OrElse palette(i).R = 255
                        If i < palette.Length - 1 Then
                           i += 1
                        Else
                           Exit Do
                        End If
                     Loop

                     If i = palette.Length - Math.Abs(_minValue) Then
                        Dim max As Integer = _maxValue
                        Dim min As Integer = _minValue

                        If palette(min + palette.Length).R > palette(max).R Then
                           lowValue = CInt((max - min) * (255.0 - palette(max).R) / (palette(max).R - palette(min + palette.Length).R) + max)
                           highValue = CInt(min - (max - min) * palette(min + palette.Length).R / (palette(max).R - palette(min + palette.Length).R))
                        Else
                           highValue = CInt((max - min) * (255.0 - palette(max).R) / (palette(max).R - palette(min + palette.Length).R) + max)
                           lowValue = CInt(min - (max - min) * palette(min + palette.Length).R / (palette(max).R - palette(min + palette.Length).R))
                        End If
                     Else
                        Dim max As Integer = _maxValue
                        Dim min As Integer = _minValue
                        lowValue = i - palette.Length

                        If palette(i).R > palette(_maxValue).R Then
                           highValue = CInt(max + ((max - lowValue) * palette(max).R) / (255.0 - palette(max).R))
                        Else
                           highValue = CInt(max + ((max - lowValue) * (255.0 - palette(max).R)) / palette(max).R)
                        End If
                     End If
                  Else
                     highValue = i

                     Do While palette(i).R = 0 OrElse palette(i).R = 255
                        If i < palette.Length - 1 Then
                           i += 1
                        Else
                           Exit Do
                        End If
                     Loop

                     If i < palette.Length - 1 Then
                        lowValue = i - palette.Length
                     End If

                     If lowValue < _minValue Then
                        lowValue = _minValue
                        lowValue = lowValue - CInt(((highValue - lowValue) * palette(i).R) / (255.0 - palette(i).R))
                     End If
                  End If
                  Exit Select
            End Select

            _windowLevelWidth = highValue - lowValue + 1
            _windowLevelCenter = CInt((highValue + lowValue) / 2)
            CheckValue(_windowLevelWidth, CInt(Math.Pow(2, Viewer.Image.BitsPerPixel)), 1)
            CheckValue(_windowLevelCenter, CInt(Math.Pow(2, Viewer.Image.BitsPerPixel) - 1), CInt(Math.Pow(2, Viewer.Image.BitsPerPixel)) * -1 + 1)
            ChangeThePalette()
         Catch e1 As Exception
         End Try
      End Sub

      Private Sub ChangeThePalette()
         Dim Viewer As ImageViewer
         If (_isViewerBefore) Then
            Viewer = _viewerBefore
         Else
            Viewer = _viewerAfter
         End If
         If Viewer.Image.BitsPerPixel = 1 Then
            Return
         End If
         Try
            Dim low As Integer = CInt(_windowLevelCenter - _windowLevelWidth / 2.0)
            Dim high As Integer = CInt(_windowLevelCenter + _windowLevelWidth / 2.0)

            _currentPalette = New RasterColor(_LUTSize - 1) {}

            RasterPalette.WindowLevelFillLookupTable(_currentPalette, New RasterColor(0, 0, 0), New RasterColor(255, 255, 255), low, high, Viewer.Image.LowBit, _highBit, _minValue, _maxValue, 0, _flags)

            If Viewer.Image.BitsPerPixel = 8 Then
               Viewer.Image.SetPalette(_currentPalette, 0, _currentPalette.Length)
            Else
               Viewer.Image.WindowLevel(_viewerBefore.Image.LowBit, _highBit, _currentPalette, RasterWindowLevelMode.PaintAndProcessing)
            End If
         Catch e1 As Exception
         End Try
      End Sub

      Public Sub UpdateImageValues()
         Try
            Dim Viewer As ImageViewer
            If (_isViewerBefore) Then
               Viewer = _viewerBefore
            Else
               Viewer = _viewerAfter
            End If
            If Viewer.Image.GrayscaleMode <> RasterGrayscaleMode.None Then
               Select Case Viewer.Image.BitsPerPixel
                  Case 1
                     _isWLImage = False
                  Case 8
                     _currentPalette = Viewer.Image.GetPalette()
                     _LUTSize = 256
                     _minValue = 0
                     _maxValue = 255
                     _isWLImage = True
                  Case 12, 16
                     _currentPalette = Viewer.Image.GetLookupTable()
                     If _currentPalette Is Nothing Then
                        _highBit = Viewer.Image.HighBit
                        If _highBit = -1 Then
                           _highBit = Viewer.Image.BitsPerPixel - 1
                        End If

                        _LUTSize = CInt(Math.Pow(2, _highBit + 1))
                        If (Viewer.Image.Signed) Then
                           _maxValue = CInt(_LUTSize / 2 - 1)
                        Else
                           _maxValue = _LUTSize - 1
                        End If
                        If (Viewer.Image.Signed) Then
                           _minValue = CInt(-_LUTSize / 2)
                        Else
                           _minValue = 0
                        End If

                        _flags = RasterPaletteWindowLevelFlags.None
                        _flags = RasterPaletteWindowLevelFlags.Logarithmic Or RasterPaletteWindowLevelFlags.DicomStyle Or RasterPaletteWindowLevelFlags.Outside
                        If Viewer.Image.Signed Then
                           _flags = _flags Or RasterPaletteWindowLevelFlags.Signed
                        End If
                        createPalette()
                     Else
                        _LUTSize = _currentPalette.Length
                        Dim minMaxValueCmd As MinMaxValuesCommand = New MinMaxValuesCommand()
                        minMaxValueCmd.Run(Viewer.Image)
                        _maxValue = minMaxValueCmd.MaximumValue
                        _minValue = minMaxValueCmd.MinimumValue
                     End If
                     _isWLImage = True
               End Select

               If ((_maxValue - _minValue) / 1000 > 0) Then
                  _scale = CInt((_maxValue - _minValue) / 1000)
               Else
                  _scale = 1
               End If
               _maxWidth = CInt(Math.Pow(2, Viewer.Image.BitsPerPixel))
               _minWidth = 1
               _maxLevel = CInt(Math.Pow(2, Viewer.Image.BitsPerPixel) - 1)
               _minLevel = CInt(Math.Pow(2, Viewer.Image.BitsPerPixel)) * -1 + 1

               If Viewer.Image.Signed Then
                  getWindowLevelForSigned(_currentPalette)
               Else
                  getWindowLevelForUnSigned(_currentPalette)
               End If
            Else
               _isWLImage = False
            End If
         Catch e1 As Exception
         End Try
      End Sub

      Private Sub createPalette()
         Dim Viewer As ImageViewer
         If (_isViewerBefore) Then
            Viewer = _viewerBefore
         Else
            Viewer = _viewerAfter
         End If
         If Viewer.Image.BitsPerPixel = 1 Then
            Return
         End If
         _currentPalette = New RasterColor(_LUTSize - 1) {}
         _windowLevelWidth = _maxValue - _minValue
         _windowLevelCenter = CInt((_maxValue + _minValue) / 2)

         If Viewer.Image.BitsPerPixel = 8 Then
            Viewer.Image.SetPalette(_currentPalette, 0, _currentPalette.Length)
         Else
            Viewer.Image.SetLookupTable(_currentPalette)
         End If

         ChangeThePalette()
      End Sub
   End Class
End Namespace



Imports System.Windows.Forms
Namespace FusionDemo

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
         Me._menuFile = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemFileLoadDICOM = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemFileLoadDICOMDIR = New System.Windows.Forms.ToolStripMenuItem()
         Me.toolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
         Me._menuFile_exit = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuEdit = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuAddFusion = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuAdjustFusion = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuFuseTwoCells = New System.Windows.Forms.ToolStripMenuItem()
         Me.toolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
         Me._menuDeleteAll = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuView = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuProperties = New System.Windows.Forms.ToolStripMenuItem()
         Me._actionsMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuActionWindowLevel = New System.Windows.Forms.ToolStripMenuItem()
         Me._manualWLToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me._linearToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me._exponentialToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me._logarithmicToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me._sigmoidToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuActionAlpha = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuActionScale = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuActionMagnify = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuActionPan = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuActionTranslucensy = New System.Windows.Forms.ToolStripMenuItem()
         Me._helpMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuAbout = New System.Windows.Forms.ToolStripMenuItem()
         Me._printCellMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me.nudgeToolToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me.setToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me.customizeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me.shrinkToolToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me.setToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
         Me.customizeToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
         Me._miEffectInvert = New System.Windows.Forms.ToolStripMenuItem()
         Me._mainPanel = New System.Windows.Forms.Panel()
         Me._displayPanel = New System.Windows.Forms.Panel()
         Me.BottomToolStripPanel = New System.Windows.Forms.ToolStripPanel()
         Me.TopToolStripPanel = New System.Windows.Forms.ToolStripPanel()
         Me.RightToolStripPanel = New System.Windows.Forms.ToolStripPanel()
         Me.LeftToolStripPanel = New System.Windows.Forms.ToolStripPanel()
         Me.ContentPanel = New System.Windows.Forms.ToolStripContentPanel()
         Me._mainMenu.SuspendLayout()
         Me._mainPanel.SuspendLayout()
         Me.SuspendLayout()
         ' 
         ' _mainMenu
         ' 
         Me._mainMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me._menuFile, Me._menuEdit, Me._menuView, Me._actionsMenuItem, Me._helpMenuItem})
         Me._mainMenu.Location = New System.Drawing.Point(0, 0)
         Me._mainMenu.Name = "_mainMenu"
         Me._mainMenu.Size = New System.Drawing.Size(1284, 24)
         Me._mainMenu.TabIndex = 1
         Me._mainMenu.Text = "_mainMenu"
         ' 
         ' _menuFile
         ' 
         Me._menuFile.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._menuItemFileLoadDICOM, Me._menuItemFileLoadDICOMDIR, Me.toolStripSeparator3, Me._menuFile_exit})
         Me._menuFile.Name = "_menuFile"
         Me._menuFile.Size = New System.Drawing.Size(37, 20)
         Me._menuFile.Text = "&File"
         ' 
         ' _menuItemFileLoadDICOM
         ' 
         Me._menuItemFileLoadDICOM.Name = "_menuItemFileLoadDICOM"
         Me._menuItemFileLoadDICOM.Size = New System.Drawing.Size(169, 22)
         Me._menuItemFileLoadDICOM.Text = "&Load DICOM..."
         ' 
         ' _menuItemFileLoadDICOMDIR
         ' 
         Me._menuItemFileLoadDICOMDIR.Name = "_menuItemFileLoadDICOMDIR"
         Me._menuItemFileLoadDICOMDIR.Size = New System.Drawing.Size(169, 22)
         Me._menuItemFileLoadDICOMDIR.Text = "Load &DICOMDIR..."
         ' 
         ' toolStripSeparator3
         ' 
         Me.toolStripSeparator3.Name = "toolStripSeparator3"
         Me.toolStripSeparator3.Size = New System.Drawing.Size(166, 6)
         ' 
         ' _menuFile_exit
         ' 
         Me._menuFile_exit.Name = "_menuFile_exit"
         Me._menuFile_exit.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.E), System.Windows.Forms.Keys)
         Me._menuFile_exit.Size = New System.Drawing.Size(169, 22)
         Me._menuFile_exit.Text = "&Exit"
         ' 
         ' _menuEdit
         ' 
         Me._menuEdit.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._menuAddFusion, Me._menuAdjustFusion, Me._menuFuseTwoCells, Me.toolStripSeparator1, Me._menuDeleteAll})
         Me._menuEdit.Name = "_menuEdit"
         Me._menuEdit.Size = New System.Drawing.Size(39, 20)
         Me._menuEdit.Text = "&Edit"
         ' 
         ' _menuAddFusion
         ' 
         Me._menuAddFusion.Name = "_menuAddFusion"
         Me._menuAddFusion.Size = New System.Drawing.Size(197, 22)
         Me._menuAddFusion.Text = "&Add / Remove Fusion..."
         ' 
         ' _menuAdjustFusion
         ' 
         Me._menuAdjustFusion.Name = "_menuAdjustFusion"
         Me._menuAdjustFusion.Size = New System.Drawing.Size(197, 22)
         Me._menuAdjustFusion.Text = "&Adjust Fused Images..."
         ' 
         ' _menuFuseTwoCells
         ' 
         Me._menuFuseTwoCells.Name = "_menuFuseTwoCells"
         Me._menuFuseTwoCells.Size = New System.Drawing.Size(197, 22)
         Me._menuFuseTwoCells.Text = "Fuse Two Cells"
         ' 
         ' toolStripSeparator1
         ' 
         Me.toolStripSeparator1.Name = "toolStripSeparator1"
         Me.toolStripSeparator1.Size = New System.Drawing.Size(194, 6)
         ' 
         ' _menuDeleteAll
         ' 
         Me._menuDeleteAll.Name = "_menuDeleteAll"
         Me._menuDeleteAll.Size = New System.Drawing.Size(197, 22)
         Me._menuDeleteAll.Text = "&Delete All"
         ' 
         ' _menuView
         ' 
         Me._menuView.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._menuProperties})
         Me._menuView.Name = "_menuView"
         Me._menuView.Size = New System.Drawing.Size(44, 20)
         Me._menuView.Text = "&View"
         ' 
         ' _menuProperties
         ' 
         Me._menuProperties.Name = "_menuProperties"
         Me._menuProperties.Size = New System.Drawing.Size(136, 22)
         Me._menuProperties.Text = "&Properties..."
         ' 
         ' _actionsMenuItem
         ' 
         Me._actionsMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._menuActionWindowLevel, Me._menuActionAlpha, Me._menuActionScale, Me._menuActionMagnify, Me._menuActionPan, Me._menuActionTranslucensy})
         Me._actionsMenuItem.Name = "_actionsMenuItem"
         Me._actionsMenuItem.Size = New System.Drawing.Size(59, 20)
         Me._actionsMenuItem.Text = "&Actions"
         ' 
         ' _menuActionWindowLevel
         ' 
         Me._menuActionWindowLevel.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._manualWLToolStripMenuItem, Me._linearToolStripMenuItem, Me._exponentialToolStripMenuItem, Me._logarithmicToolStripMenuItem, Me._sigmoidToolStripMenuItem})
         Me._menuActionWindowLevel.Name = "_menuActionWindowLevel"
         Me._menuActionWindowLevel.Size = New System.Drawing.Size(152, 22)
         Me._menuActionWindowLevel.Text = "&Window Level"
         ' 
         ' _manualWLToolStripMenuItem
         ' 
         Me._manualWLToolStripMenuItem.Name = "_manualWLToolStripMenuItem"
         Me._manualWLToolStripMenuItem.Size = New System.Drawing.Size(167, 22)
         Me._manualWLToolStripMenuItem.Text = "Set W/L Manually"
         ' 
         ' _linearToolStripMenuItem
         ' 
         Me._linearToolStripMenuItem.Name = "_linearToolStripMenuItem"
         Me._linearToolStripMenuItem.Size = New System.Drawing.Size(167, 22)
         Me._linearToolStripMenuItem.Text = "Linear"
         ' 
         ' _exponentialToolStripMenuItem
         ' 
         Me._exponentialToolStripMenuItem.Name = "_exponentialToolStripMenuItem"
         Me._exponentialToolStripMenuItem.Size = New System.Drawing.Size(167, 22)
         Me._exponentialToolStripMenuItem.Text = "Exponential"
         ' 
         ' _logarithmicToolStripMenuItem
         ' 
         Me._logarithmicToolStripMenuItem.Name = "_logarithmicToolStripMenuItem"
         Me._logarithmicToolStripMenuItem.Size = New System.Drawing.Size(167, 22)
         Me._logarithmicToolStripMenuItem.Text = "Logarithmic"
         ' 
         ' _sigmoidToolStripMenuItem
         ' 
         Me._sigmoidToolStripMenuItem.Name = "_sigmoidToolStripMenuItem"
         Me._sigmoidToolStripMenuItem.Size = New System.Drawing.Size(167, 22)
         Me._sigmoidToolStripMenuItem.Text = "Sigmoid"
         ' 
         ' _menuActionAlpha
         ' 
         Me._menuActionAlpha.Name = "_menuActionAlpha"
         Me._menuActionAlpha.Size = New System.Drawing.Size(152, 22)
         Me._menuActionAlpha.Text = "&Alpha"
         ' 
         ' _menuActionScale
         ' 
         Me._menuActionScale.Name = "_menuActionScale"
         Me._menuActionScale.Size = New System.Drawing.Size(152, 22)
         Me._menuActionScale.Text = "&Scale"
         ' 
         ' _menuActionMagnify
         ' 
         Me._menuActionMagnify.Name = "_menuActionMagnify"
         Me._menuActionMagnify.Size = New System.Drawing.Size(152, 22)
         Me._menuActionMagnify.Text = "&Magnify"
         ' 
         ' _menuActionPan
         ' 
         Me._menuActionPan.Name = "_menuActionPan"
         Me._menuActionPan.Size = New System.Drawing.Size(152, 22)
         Me._menuActionPan.Text = "&Pan"
         ' 
         ' _menuActionTranslucensy
         ' 
         Me._menuActionTranslucensy.Name = "_menuActionTranslucensy"
         Me._menuActionTranslucensy.Size = New System.Drawing.Size(152, 22)
         Me._menuActionTranslucensy.Text = "&Translucency"
         ' 
         ' _helpMenuItem
         ' 
         Me._helpMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._menuAbout})
         Me._helpMenuItem.Name = "_helpMenuItem"
         Me._helpMenuItem.Size = New System.Drawing.Size(44, 20)
         Me._helpMenuItem.Text = "&Help"
         ' 
         ' _menuAbout
         ' 
         Me._menuAbout.Name = "_menuAbout"
         Me._menuAbout.Size = New System.Drawing.Size(116, 22)
         Me._menuAbout.Text = "&About..."
         ' 
         ' _printCellMenuItem
         ' 
         Me._printCellMenuItem.Name = "_printCellMenuItem"
         Me._printCellMenuItem.Size = New System.Drawing.Size(175, 22)
         Me._printCellMenuItem.Text = "&Print Cell..."
         ' 
         ' nudgeToolToolStripMenuItem
         ' 
         Me.nudgeToolToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.setToolStripMenuItem, Me.customizeToolStripMenuItem})
         Me.nudgeToolToolStripMenuItem.Name = "nudgeToolToolStripMenuItem"
         Me.nudgeToolToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
         Me.nudgeToolToolStripMenuItem.Text = "&Nudge tool"
         ' 
         ' setToolStripMenuItem
         ' 
         Me.setToolStripMenuItem.Name = "setToolStripMenuItem"
         Me.setToolStripMenuItem.Size = New System.Drawing.Size(130, 22)
         Me.setToolStripMenuItem.Text = "&Set.."
         ' 
         ' customizeToolStripMenuItem
         ' 
         Me.customizeToolStripMenuItem.Name = "customizeToolStripMenuItem"
         Me.customizeToolStripMenuItem.Size = New System.Drawing.Size(130, 22)
         Me.customizeToolStripMenuItem.Text = "&Customize"
         ' 
         ' shrinkToolToolStripMenuItem
         ' 
         Me.shrinkToolToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.setToolStripMenuItem1, Me.customizeToolStripMenuItem1})
         Me.shrinkToolToolStripMenuItem.Name = "shrinkToolToolStripMenuItem"
         Me.shrinkToolToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
         Me.shrinkToolToolStripMenuItem.Text = "&Shrink tool"
         ' 
         ' setToolStripMenuItem1
         ' 
         Me.setToolStripMenuItem1.Name = "setToolStripMenuItem1"
         Me.setToolStripMenuItem1.Size = New System.Drawing.Size(139, 22)
         Me.setToolStripMenuItem1.Text = "&Set..."
         ' 
         ' customizeToolStripMenuItem1
         ' 
         Me.customizeToolStripMenuItem1.Name = "customizeToolStripMenuItem1"
         Me.customizeToolStripMenuItem1.Size = New System.Drawing.Size(139, 22)
         Me.customizeToolStripMenuItem1.Text = "&Customize..."
         ' 
         ' _miEffectInvert
         ' 
         Me._miEffectInvert.Name = "_miEffectInvert"
         Me._miEffectInvert.Size = New System.Drawing.Size(152, 22)
         Me._miEffectInvert.Text = "&Invert"
         ' 
         ' _mainPanel
         ' 
         Me._mainPanel.Controls.Add(Me._displayPanel)
         Me._mainPanel.Dock = System.Windows.Forms.DockStyle.Fill
         Me._mainPanel.Location = New System.Drawing.Point(0, 24)
         Me._mainPanel.Name = "_mainPanel"
         Me._mainPanel.Size = New System.Drawing.Size(1284, 705)
         Me._mainPanel.TabIndex = 2
         ' 
         ' _displayPanel
         ' 
         Me._displayPanel.BackColor = System.Drawing.SystemColors.ActiveBorder
         Me._displayPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
         Me._displayPanel.Location = New System.Drawing.Point(3, 3)
         Me._displayPanel.Name = "_displayPanel"
         Me._displayPanel.Size = New System.Drawing.Size(1278, 699)
         Me._displayPanel.TabIndex = 13
         ' 
         ' BottomToolStripPanel
         ' 
         Me.BottomToolStripPanel.Location = New System.Drawing.Point(0, 0)
         Me.BottomToolStripPanel.Name = "BottomToolStripPanel"
         Me.BottomToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal
         Me.BottomToolStripPanel.RowMargin = New System.Windows.Forms.Padding(3, 0, 0, 0)
         Me.BottomToolStripPanel.Size = New System.Drawing.Size(0, 0)
         ' 
         ' TopToolStripPanel
         ' 
         Me.TopToolStripPanel.Location = New System.Drawing.Point(0, 0)
         Me.TopToolStripPanel.Name = "TopToolStripPanel"
         Me.TopToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal
         Me.TopToolStripPanel.RowMargin = New System.Windows.Forms.Padding(3, 0, 0, 0)
         Me.TopToolStripPanel.Size = New System.Drawing.Size(0, 0)
         ' 
         ' RightToolStripPanel
         ' 
         Me.RightToolStripPanel.Location = New System.Drawing.Point(0, 0)
         Me.RightToolStripPanel.Name = "RightToolStripPanel"
         Me.RightToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal
         Me.RightToolStripPanel.RowMargin = New System.Windows.Forms.Padding(3, 0, 0, 0)
         Me.RightToolStripPanel.Size = New System.Drawing.Size(0, 0)
         ' 
         ' LeftToolStripPanel
         ' 
         Me.LeftToolStripPanel.Location = New System.Drawing.Point(0, 0)
         Me.LeftToolStripPanel.Name = "LeftToolStripPanel"
         Me.LeftToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal
         Me.LeftToolStripPanel.RowMargin = New System.Windows.Forms.Padding(3, 0, 0, 0)
         Me.LeftToolStripPanel.Size = New System.Drawing.Size(0, 0)
         ' 
         ' ContentPanel
         ' 
         Me.ContentPanel.Size = New System.Drawing.Size(339, 243)
         ' 
         ' MainForm
         ' 
         Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
         Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
         Me.ClientSize = New System.Drawing.Size(1284, 729)
         Me.Controls.Add(Me._mainPanel)
         Me.Controls.Add(Me._mainMenu)
         Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
         Me.MainMenuStrip = Me._mainMenu
         Me.Name = "MainForm"
         Me.Text = "Fusion Demo"
         Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
         Me._mainMenu.ResumeLayout(False)
         Me._mainMenu.PerformLayout()
         Me._mainPanel.ResumeLayout(False)
         Me.ResumeLayout(False)
         Me.PerformLayout()

      End Sub


#End Region

      Private _mainMenu As System.Windows.Forms.MenuStrip
      Private _menuFile As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuEdit As System.Windows.Forms.ToolStripMenuItem
      Private _helpMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuFile_exit As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _mainPanel As System.Windows.Forms.Panel
      Private _miEffectInvert As System.Windows.Forms.ToolStripMenuItem
      Private _printCellMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private nudgeToolToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private setToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private customizeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private shrinkToolToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private setToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
      Private customizeToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuItemFileLoadDICOM As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuItemFileLoadDICOMDIR As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuAbout As System.Windows.Forms.ToolStripMenuItem
      Private _displayPanel As System.Windows.Forms.Panel
      Private BottomToolStripPanel As System.Windows.Forms.ToolStripPanel
      Private TopToolStripPanel As System.Windows.Forms.ToolStripPanel
      Private RightToolStripPanel As System.Windows.Forms.ToolStripPanel
      Private LeftToolStripPanel As System.Windows.Forms.ToolStripPanel
      Private ContentPanel As System.Windows.Forms.ToolStripContentPanel
      Private WithEvents _actionsMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuActionWindowLevel As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuActionAlpha As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuActionScale As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuActionMagnify As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuActionPan As System.Windows.Forms.ToolStripMenuItem
      Private toolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
      Private _menuView As ToolStripMenuItem
      Private WithEvents _menuDeleteAll As ToolStripMenuItem
      Private WithEvents _menuAddFusion As ToolStripMenuItem
      Private WithEvents _menuAdjustFusion As ToolStripMenuItem
      Private toolStripSeparator1 As ToolStripSeparator
      Private WithEvents _menuProperties As ToolStripMenuItem
      Private WithEvents _menuFuseTwoCells As ToolStripMenuItem
      Private WithEvents _menuActionTranslucensy As ToolStripMenuItem
      Private WithEvents _manualWLToolStripMenuItem As ToolStripMenuItem
      Private WithEvents _linearToolStripMenuItem As ToolStripMenuItem
      Private WithEvents _exponentialToolStripMenuItem As ToolStripMenuItem
      Private WithEvents _logarithmicToolStripMenuItem As ToolStripMenuItem
      Private WithEvents _sigmoidToolStripMenuItem As ToolStripMenuItem
   End Class
End Namespace
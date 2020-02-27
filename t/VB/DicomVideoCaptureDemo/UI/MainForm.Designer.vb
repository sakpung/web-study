Namespace DicomVideoCaptureDemo
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
         Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainForm))
         Me._menu_main = New System.Windows.Forms.MenuStrip()
         Me.fileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me._mi_NewFile = New System.Windows.Forms.ToolStripMenuItem()
         Me._mi_OpenFile = New System.Windows.Forms.ToolStripMenuItem()
         Me._mi_CloseFile = New System.Windows.Forms.ToolStripMenuItem()
         Me.toolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
         Me._mi_SaveFile = New System.Windows.Forms.ToolStripMenuItem()
         Me.toolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
         Me._mi_Exit = New System.Windows.Forms.ToolStripMenuItem()
         Me._mi_View = New System.Windows.Forms.ToolStripMenuItem()
         Me._mi_Toolbar = New System.Windows.Forms.ToolStripMenuItem()
         Me.optionsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me._mi_VideoDevice = New System.Windows.Forms.ToolStripMenuItem()
         Me._mi_AudioDevice = New System.Windows.Forms.ToolStripMenuItem()
         Me._mi_captureProperties = New System.Windows.Forms.ToolStripMenuItem()
         Me._mi_compressionSettings = New System.Windows.Forms.ToolStripMenuItem()
         Me.captureToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me._mi_StartCaptureIntoDicomFile = New System.Windows.Forms.ToolStripMenuItem()
         Me._mi_StopCapture = New System.Windows.Forms.ToolStripMenuItem()
         Me.helpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me._mi_About = New System.Windows.Forms.ToolStripMenuItem()
         Me._toolbar_Main = New System.Windows.Forms.ToolStrip()
         Me._tS_New = New System.Windows.Forms.ToolStripButton()
         Me._tS_Open = New System.Windows.Forms.ToolStripButton()
         Me._tS_Save = New System.Windows.Forms.ToolStripButton()
         Me.toolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
         Me._tS_Help = New System.Windows.Forms.ToolStripButton()
         Me.toolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
         Me._tS_ProgressBar = New System.Windows.Forms.ToolStripProgressBar()
         Me.splitContainer1 = New System.Windows.Forms.SplitContainer()
         Me._panel_FileTree = New System.Windows.Forms.Panel()
         Me._treeView = New System.Windows.Forms.TreeView()
         Me._panel_CapturePanel = New System.Windows.Forms.Panel()
         Me._menu_main.SuspendLayout()
         Me._toolbar_Main.SuspendLayout()
         Me.splitContainer1.Panel1.SuspendLayout()
         Me.splitContainer1.Panel2.SuspendLayout()
         Me.splitContainer1.SuspendLayout()
         Me._panel_FileTree.SuspendLayout()
         Me.SuspendLayout()
         ' 
         ' _menu_main
         ' 
         Me._menu_main.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.fileToolStripMenuItem, Me._mi_View, Me.optionsToolStripMenuItem, Me.captureToolStripMenuItem, Me.helpToolStripMenuItem})
         Me._menu_main.Location = New System.Drawing.Point(0, 0)
         Me._menu_main.Name = "_menu_main"
         Me._menu_main.Size = New System.Drawing.Size(1037, 24)
         Me._menu_main.TabIndex = 0
         Me._menu_main.Text = "menuStrip1"
         ' 
         ' fileToolStripMenuItem
         ' 
         Me.fileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._mi_NewFile, Me._mi_OpenFile, Me._mi_CloseFile, Me.toolStripSeparator1, Me._mi_SaveFile, Me.toolStripSeparator2, Me._mi_Exit})
         Me.fileToolStripMenuItem.Name = "fileToolStripMenuItem"
         Me.fileToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
         Me.fileToolStripMenuItem.Text = "&File"
         ' 
         ' _mi_NewFile
         ' 
         Me._mi_NewFile.Name = "_mi_NewFile"
         Me._mi_NewFile.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.N), System.Windows.Forms.Keys)
         Me._mi_NewFile.Size = New System.Drawing.Size(218, 22)
         Me._mi_NewFile.Text = "&New DICOM File..."
         ' 
         ' _mi_OpenFile
         ' 
         Me._mi_OpenFile.Name = "_mi_OpenFile"
         Me._mi_OpenFile.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.O), System.Windows.Forms.Keys)
         Me._mi_OpenFile.Size = New System.Drawing.Size(218, 22)
         Me._mi_OpenFile.Text = "&Open DICOM File..."
         ' 
         ' _mi_CloseFile
         ' 
         Me._mi_CloseFile.Name = "_mi_CloseFile"
         Me._mi_CloseFile.Size = New System.Drawing.Size(218, 22)
         Me._mi_CloseFile.Text = "&Close DICOM File"
         ' 
         ' toolStripSeparator1
         ' 
         Me.toolStripSeparator1.Name = "toolStripSeparator1"
         Me.toolStripSeparator1.Size = New System.Drawing.Size(215, 6)
         ' 
         ' _mi_SaveFile
         ' 
         Me._mi_SaveFile.Name = "_mi_SaveFile"
         Me._mi_SaveFile.Size = New System.Drawing.Size(218, 22)
         Me._mi_SaveFile.Text = "Save DICOM File &As..."
         ' 
         ' toolStripSeparator2
         ' 
         Me.toolStripSeparator2.Name = "toolStripSeparator2"
         Me.toolStripSeparator2.Size = New System.Drawing.Size(215, 6)
         ' 
         ' _mi_Exit
         ' 
         Me._mi_Exit.Name = "_mi_Exit"
         Me._mi_Exit.Size = New System.Drawing.Size(218, 22)
         Me._mi_Exit.Text = "E&xit"
         ' 
         ' _mi_View
         ' 
         Me._mi_View.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._mi_Toolbar})
         Me._mi_View.Name = "_mi_View"
         Me._mi_View.Size = New System.Drawing.Size(44, 20)
         Me._mi_View.Text = "&View"
         ' 
         ' _mi_Toolbar
         ' 
         Me._mi_Toolbar.Name = "_mi_Toolbar"
         Me._mi_Toolbar.Size = New System.Drawing.Size(152, 22)
         Me._mi_Toolbar.Text = "&Toolbar"
         ' 
         ' optionsToolStripMenuItem
         ' 
         Me.optionsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._mi_VideoDevice, Me._mi_AudioDevice, Me._mi_captureProperties, Me._mi_compressionSettings})
         Me.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem"
         Me.optionsToolStripMenuItem.Size = New System.Drawing.Size(61, 20)
         Me.optionsToolStripMenuItem.Text = "&Options"
         ' 
         ' _mi_VideoDevice
         ' 
         Me._mi_VideoDevice.Name = "_mi_VideoDevice"
         Me._mi_VideoDevice.Size = New System.Drawing.Size(198, 22)
         Me._mi_VideoDevice.Text = "&Video Device"
         ' 
         ' _mi_AudioDevice
         ' 
         Me._mi_AudioDevice.Name = "_mi_AudioDevice"
         Me._mi_AudioDevice.Size = New System.Drawing.Size(198, 22)
         Me._mi_AudioDevice.Text = "&Audio Device"
         ' 
         ' _mi_captureProperties
         ' 
         Me._mi_captureProperties.Name = "_mi_captureProperties"
         Me._mi_captureProperties.Size = New System.Drawing.Size(198, 22)
         Me._mi_captureProperties.Text = "&Capture Properties..."
         ' 
         ' _mi_compressionSettings
         ' 
         Me._mi_compressionSettings.Name = "_mi_compressionSettings"
         Me._mi_compressionSettings.Size = New System.Drawing.Size(198, 22)
         Me._mi_compressionSettings.Text = "C&ompression Settings..."
         ' 
         ' captureToolStripMenuItem
         ' 
         Me.captureToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._mi_StartCaptureIntoDicomFile, Me._mi_StopCapture})
         Me.captureToolStripMenuItem.Name = "captureToolStripMenuItem"
         Me.captureToolStripMenuItem.Size = New System.Drawing.Size(61, 20)
         Me.captureToolStripMenuItem.Text = "&Capture"
         ' 
         ' _mi_StartCaptureIntoDicomFile
         ' 
         Me._mi_StartCaptureIntoDicomFile.Name = "_mi_StartCaptureIntoDicomFile"
         Me._mi_StartCaptureIntoDicomFile.Size = New System.Drawing.Size(230, 22)
         Me._mi_StartCaptureIntoDicomFile.Text = "&Start Capture Into DICOM File"
         ' 
         ' _mi_StopCapture
         ' 
         Me._mi_StopCapture.Name = "_mi_StopCapture"
         Me._mi_StopCapture.Size = New System.Drawing.Size(230, 22)
         Me._mi_StopCapture.Text = "Stop &Capture"
         ' 
         ' helpToolStripMenuItem
         ' 
         Me.helpToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._mi_About})
         Me.helpToolStripMenuItem.Name = "helpToolStripMenuItem"
         Me.helpToolStripMenuItem.Size = New System.Drawing.Size(44, 20)
         Me.helpToolStripMenuItem.Text = "&Help"
         ' 
         ' _mi_About
         ' 
         Me._mi_About.Name = "_mi_About"
         Me._mi_About.Size = New System.Drawing.Size(152, 22)
         Me._mi_About.Text = "&About..."
         ' 
         ' _toolbar_Main
         ' 
         Me._toolbar_Main.BackColor = System.Drawing.SystemColors.Control
         Me._toolbar_Main.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me._tS_New, Me._tS_Open, Me._tS_Save, Me.toolStripSeparator3, Me._tS_Help, Me.toolStripSeparator4, Me._tS_ProgressBar})
         Me._toolbar_Main.Location = New System.Drawing.Point(0, 24)
         Me._toolbar_Main.Name = "_toolbar_Main"
         Me._toolbar_Main.Size = New System.Drawing.Size(1037, 25)
         Me._toolbar_Main.TabIndex = 2
         Me._toolbar_Main.Text = "toolStrip1"
         ' 
         ' _tS_New
         ' 
         Me._tS_New.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
         Me._tS_New.Image = CType(resources.GetObject("_tS_New.Image"), System.Drawing.Image)
         Me._tS_New.ImageTransparentColor = System.Drawing.Color.Magenta
         Me._tS_New.Name = "_tS_New"
         Me._tS_New.Size = New System.Drawing.Size(23, 22)
         Me._tS_New.Text = "New Dicom File"
         ' 
         ' _tS_Open
         ' 
         Me._tS_Open.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
         Me._tS_Open.Image = CType(resources.GetObject("_tS_Open.Image"), System.Drawing.Image)
         Me._tS_Open.ImageTransparentColor = System.Drawing.Color.Magenta
         Me._tS_Open.Name = "_tS_Open"
         Me._tS_Open.Size = New System.Drawing.Size(23, 22)
         Me._tS_Open.Text = "Open Dicom File"
         ' 
         ' _tS_Save
         ' 
         Me._tS_Save.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
         Me._tS_Save.Image = CType(resources.GetObject("_tS_Save.Image"), System.Drawing.Image)
         Me._tS_Save.ImageTransparentColor = System.Drawing.Color.Magenta
         Me._tS_Save.Name = "_tS_Save"
         Me._tS_Save.Size = New System.Drawing.Size(23, 22)
         Me._tS_Save.Text = "Save Dicom File"
         ' 
         ' toolStripSeparator3
         ' 
         Me.toolStripSeparator3.Name = "toolStripSeparator3"
         Me.toolStripSeparator3.Size = New System.Drawing.Size(6, 25)
         ' 
         ' _tS_Help
         ' 
         Me._tS_Help.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
         Me._tS_Help.Image = CType(resources.GetObject("_tS_Help.Image"), System.Drawing.Image)
         Me._tS_Help.ImageTransparentColor = System.Drawing.Color.Magenta
         Me._tS_Help.Name = "_tS_Help"
         Me._tS_Help.Size = New System.Drawing.Size(23, 22)
         Me._tS_Help.Text = "Help"
         ' 
         ' toolStripSeparator4
         ' 
         Me.toolStripSeparator4.Name = "toolStripSeparator4"
         Me.toolStripSeparator4.Size = New System.Drawing.Size(6, 25)
         ' 
         ' _tS_ProgressBar
         ' 
         Me._tS_ProgressBar.Name = "_tS_ProgressBar"
         Me._tS_ProgressBar.Size = New System.Drawing.Size(100, 22)
         ' 
         ' splitContainer1
         ' 
         Me.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
         Me.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
         Me.splitContainer1.ImeMode = System.Windows.Forms.ImeMode.NoControl
         Me.splitContainer1.Location = New System.Drawing.Point(0, 49)
         Me.splitContainer1.Name = "splitContainer1"
         ' 
         ' splitContainer1.Panel1
         ' 
         Me.splitContainer1.Panel1.Controls.Add(Me._panel_FileTree)
         ' 
         ' splitContainer1.Panel2
         ' 
         Me.splitContainer1.Panel2.Controls.Add(Me._panel_CapturePanel)
         Me.splitContainer1.Size = New System.Drawing.Size(1037, 754)
         Me.splitContainer1.SplitterDistance = 302
         Me.splitContainer1.TabIndex = 3
         ' 
         ' _panel_FileTree
         ' 
         Me._panel_FileTree.BackColor = System.Drawing.SystemColors.Window
         Me._panel_FileTree.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
         Me._panel_FileTree.Controls.Add(Me._treeView)
         Me._panel_FileTree.Dock = System.Windows.Forms.DockStyle.Fill
         Me._panel_FileTree.Location = New System.Drawing.Point(0, 0)
         Me._panel_FileTree.Name = "_panel_FileTree"
         Me._panel_FileTree.Size = New System.Drawing.Size(298, 750)
         Me._panel_FileTree.TabIndex = 0
         ' 
         ' _treeView
         ' 
         Me._treeView.Dock = System.Windows.Forms.DockStyle.Fill
         Me._treeView.Location = New System.Drawing.Point(0, 0)
         Me._treeView.Name = "_treeView"
         Me._treeView.Size = New System.Drawing.Size(294, 746)
         Me._treeView.TabIndex = 0
         ' 
         ' _panel_CapturePanel
         ' 
         Me._panel_CapturePanel.BackColor = System.Drawing.SystemColors.Window
         Me._panel_CapturePanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
         Me._panel_CapturePanel.Dock = System.Windows.Forms.DockStyle.Fill
         Me._panel_CapturePanel.Location = New System.Drawing.Point(0, 0)
         Me._panel_CapturePanel.Name = "_panel_CapturePanel"
         Me._panel_CapturePanel.Size = New System.Drawing.Size(727, 750)
         Me._panel_CapturePanel.TabIndex = 1
         ' 
         ' MainForm
         ' 
         Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
         Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
         Me.ClientSize = New System.Drawing.Size(1037, 803)
         Me.Controls.Add(Me.splitContainer1)
         Me.Controls.Add(Me._toolbar_Main)
         Me.Controls.Add(Me._menu_main)
         Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
         Me.MainMenuStrip = Me._menu_main
         Me.Name = "MainForm"
         Me.Text = "C# DICOM Video Capture Demo"
         Me._menu_main.ResumeLayout(False)
         Me._menu_main.PerformLayout()
         Me._toolbar_Main.ResumeLayout(False)
         Me._toolbar_Main.PerformLayout()
         Me.splitContainer1.Panel1.ResumeLayout(False)
         Me.splitContainer1.Panel2.ResumeLayout(False)
         Me.splitContainer1.ResumeLayout(False)
         Me._panel_FileTree.ResumeLayout(False)
         Me.ResumeLayout(False)
         Me.PerformLayout()

      End Sub

#End Region

      Private _menu_main As System.Windows.Forms.MenuStrip
      Private fileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _mi_NewFile As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _mi_OpenFile As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _mi_CloseFile As System.Windows.Forms.ToolStripMenuItem
      Private toolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
      Private WithEvents _mi_SaveFile As System.Windows.Forms.ToolStripMenuItem
      Private toolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
      Private WithEvents _mi_Exit As System.Windows.Forms.ToolStripMenuItem
      Private _mi_View As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _mi_Toolbar As System.Windows.Forms.ToolStripMenuItem
      Private optionsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private _mi_VideoDevice As System.Windows.Forms.ToolStripMenuItem
      Private _mi_AudioDevice As System.Windows.Forms.ToolStripMenuItem
      Private captureToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private helpToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _mi_captureProperties As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _mi_compressionSettings As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _mi_StartCaptureIntoDicomFile As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _mi_StopCapture As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _mi_About As System.Windows.Forms.ToolStripMenuItem
      Private _toolbar_Main As System.Windows.Forms.ToolStrip
      Private splitContainer1 As System.Windows.Forms.SplitContainer
      Private WithEvents _tS_New As System.Windows.Forms.ToolStripButton
      Private WithEvents _tS_Open As System.Windows.Forms.ToolStripButton
      Private WithEvents _tS_Save As System.Windows.Forms.ToolStripButton
      Private toolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
      Private WithEvents _tS_Help As System.Windows.Forms.ToolStripButton
      Private _panel_FileTree As System.Windows.Forms.Panel
      Private WithEvents _panel_CapturePanel As System.Windows.Forms.Panel
      Private WithEvents _treeView As System.Windows.Forms.TreeView
      Private _tS_ProgressBar As System.Windows.Forms.ToolStripProgressBar
      Private toolStripSeparator4 As System.Windows.Forms.ToolStripSeparator

   End Class
End Namespace

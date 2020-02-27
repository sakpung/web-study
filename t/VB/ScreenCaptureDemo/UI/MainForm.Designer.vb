Imports System
Imports System.Drawing
Imports System.Windows.Forms
Imports Leadtools.Codecs
Namespace ScreenCaptureDemo
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
         Me._sbMain = New System.Windows.Forms.StatusStrip()
         Me._sbiText = New System.Windows.Forms.ToolStripStatusLabel()
         Me._mmMain = New System.Windows.Forms.MenuStrip()
         Me._miFile = New System.Windows.Forms.ToolStripMenuItem()
         Me._miFileSaveAs = New System.Windows.Forms.ToolStripMenuItem()
         Me._miFileExit = New System.Windows.Forms.ToolStripMenuItem()
         Me._miEdit = New System.Windows.Forms.ToolStripMenuItem()
         Me._miEditCut = New System.Windows.Forms.ToolStripMenuItem()
         Me._miEditCopy = New System.Windows.Forms.ToolStripMenuItem()
         Me._miCapture = New System.Windows.Forms.ToolStripMenuItem()
         Me._miCaptureActiveWindow = New System.Windows.Forms.ToolStripMenuItem()
         Me._miCaptureActiveClient = New System.Windows.Forms.ToolStripMenuItem()
         Me._miCaptureFullScreen = New System.Windows.Forms.ToolStripMenuItem()
         Me._miCaptureSelectedObject = New System.Windows.Forms.ToolStripMenuItem()
         Me._miCaptureMenuUnderCursor = New System.Windows.Forms.ToolStripMenuItem()
         Me._miCaptureSelectedArea = New System.Windows.Forms.ToolStripMenuItem()
         Me._miCaptureWallpaper = New System.Windows.Forms.ToolStripMenuItem()
         Me._miCaptureMouseCursor = New System.Windows.Forms.ToolStripMenuItem()
         Me._miCaptureWindowUnderCursor = New System.Windows.Forms.ToolStripMenuItem()
         Me.toolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
         Me._miCaptureStopCapture = New System.Windows.Forms.ToolStripMenuItem()
         Me.toolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
         Me._miCaptureFromExeDialogTree = New System.Windows.Forms.ToolStripMenuItem()
         Me._miCaptureFromExeDialogTabbedView = New System.Windows.Forms.ToolStripMenuItem()
         Me._miOptions = New System.Windows.Forms.ToolStripMenuItem()
         Me._miOptionsCaptureOptions = New System.Windows.Forms.ToolStripMenuItem()
         Me._miOptionsCaptureAreaOptions = New System.Windows.Forms.ToolStripMenuItem()
         Me._miOptionsCaptureObjectOptions = New System.Windows.Forms.ToolStripMenuItem()
         Me.toolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
         Me._miOptionsMinimizeApplicationOnCapture = New System.Windows.Forms.ToolStripMenuItem()
         Me._miOptionsActivateApplicationAfterCapture = New System.Windows.Forms.ToolStripMenuItem()
         Me.toolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
         Me._miOptionsBeepOnCapture = New System.Windows.Forms.ToolStripMenuItem()
         Me._miView = New System.Windows.Forms.ToolStripMenuItem()
         Me._miViewStatusBar = New System.Windows.Forms.ToolStripMenuItem()
         Me._miHelp = New System.Windows.Forms.ToolStripMenuItem()
         Me._miHelpAbout = New System.Windows.Forms.ToolStripMenuItem()
         Me._sbMain.SuspendLayout()
         Me._mmMain.SuspendLayout()
         Me.SuspendLayout()
         ' 
         ' _sbMain
         ' 
         Me._sbMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me._sbiText})
         resources.ApplyResources(Me._sbMain, "_sbMain")
         Me._sbMain.Name = "_sbMain"
         ' 
         ' _sbiText
         ' 
         Me._sbiText.Name = "_sbiText"
         resources.ApplyResources(Me._sbiText, "_sbiText")
         ' 
         ' _mmMain
         ' 
         Me._mmMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me._miFile, Me._miEdit, Me._miCapture, Me._miOptions, Me._miView, Me._miHelp})
         resources.ApplyResources(Me._mmMain, "_mmMain")
         Me._mmMain.Name = "_mmMain"
         ' 
         ' _miFile
         ' 
         Me._miFile.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._miFileSaveAs, Me._miFileExit})
         Me._miFile.Name = "_miFile"
         resources.ApplyResources(Me._miFile, "_miFile")
         ' 
         ' _miFileSaveAs
         ' 
         resources.ApplyResources(Me._miFileSaveAs, "_miFileSaveAs")
         Me._miFileSaveAs.Name = "_miFileSaveAs"
         ' 
         ' _miFileExit
         ' 
         Me._miFileExit.Name = "_miFileExit"
         resources.ApplyResources(Me._miFileExit, "_miFileExit")
         ' 
         ' _miEdit
         ' 
         Me._miEdit.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._miEditCut, Me._miEditCopy})
         Me._miEdit.Name = "_miEdit"
         resources.ApplyResources(Me._miEdit, "_miEdit")
         ' 
         ' _miEditCut
         ' 
         resources.ApplyResources(Me._miEditCut, "_miEditCut")
         Me._miEditCut.Name = "_miEditCut"
         ' 
         ' _miEditCopy
         ' 
         resources.ApplyResources(Me._miEditCopy, "_miEditCopy")
         Me._miEditCopy.Name = "_miEditCopy"
         ' 
         ' _miCapture
         ' 
         Me._miCapture.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._miCaptureActiveWindow, Me._miCaptureActiveClient, Me._miCaptureFullScreen, Me._miCaptureSelectedObject, Me._miCaptureMenuUnderCursor, Me._miCaptureSelectedArea, Me._miCaptureWallpaper, Me._miCaptureMouseCursor, Me._miCaptureWindowUnderCursor, Me.toolStripSeparator1, Me._miCaptureStopCapture, Me.toolStripSeparator2, Me._miCaptureFromExeDialogTree, Me._miCaptureFromExeDialogTabbedView})
         Me._miCapture.Name = "_miCapture"
         resources.ApplyResources(Me._miCapture, "_miCapture")
         ' 
         ' _miCaptureActiveWindow
         ' 
         Me._miCaptureActiveWindow.Name = "_miCaptureActiveWindow"
         resources.ApplyResources(Me._miCaptureActiveWindow, "_miCaptureActiveWindow")
         ' 
         ' _miCaptureActiveClient
         ' 
         Me._miCaptureActiveClient.Name = "_miCaptureActiveClient"
         resources.ApplyResources(Me._miCaptureActiveClient, "_miCaptureActiveClient")
         ' 
         ' _miCaptureFullScreen
         ' 
         Me._miCaptureFullScreen.Name = "_miCaptureFullScreen"
         resources.ApplyResources(Me._miCaptureFullScreen, "_miCaptureFullScreen")
         ' 
         ' _miCaptureSelectedObject
         ' 
         Me._miCaptureSelectedObject.Name = "_miCaptureSelectedObject"
         resources.ApplyResources(Me._miCaptureSelectedObject, "_miCaptureSelectedObject")
         ' 
         ' _miCaptureMenuUnderCursor
         ' 
         Me._miCaptureMenuUnderCursor.Name = "_miCaptureMenuUnderCursor"
         resources.ApplyResources(Me._miCaptureMenuUnderCursor, "_miCaptureMenuUnderCursor")
         ' 
         ' _miCaptureSelectedArea
         ' 
         Me._miCaptureSelectedArea.Name = "_miCaptureSelectedArea"
         resources.ApplyResources(Me._miCaptureSelectedArea, "_miCaptureSelectedArea")
         ' 
         ' _miCaptureWallpaper
         ' 
         Me._miCaptureWallpaper.Name = "_miCaptureWallpaper"
         resources.ApplyResources(Me._miCaptureWallpaper, "_miCaptureWallpaper")
         ' 
         ' _miCaptureMouseCursor
         ' 
         Me._miCaptureMouseCursor.Name = "_miCaptureMouseCursor"
         resources.ApplyResources(Me._miCaptureMouseCursor, "_miCaptureMouseCursor")
         ' 
         ' _miCaptureWindowUnderCursor
         ' 
         Me._miCaptureWindowUnderCursor.Name = "_miCaptureWindowUnderCursor"
         resources.ApplyResources(Me._miCaptureWindowUnderCursor, "_miCaptureWindowUnderCursor")
         ' 
         ' toolStripSeparator1
         ' 
         Me.toolStripSeparator1.Name = "toolStripSeparator1"
         resources.ApplyResources(Me.toolStripSeparator1, "toolStripSeparator1")
         ' 
         ' _miCaptureStopCapture
         ' 
         resources.ApplyResources(Me._miCaptureStopCapture, "_miCaptureStopCapture")
         Me._miCaptureStopCapture.Name = "_miCaptureStopCapture"
         ' 
         ' toolStripSeparator2
         ' 
         Me.toolStripSeparator2.Name = "toolStripSeparator2"
         resources.ApplyResources(Me.toolStripSeparator2, "toolStripSeparator2")
         ' 
         ' _miCaptureFromExeDialogTree
         ' 
         Me._miCaptureFromExeDialogTree.Name = "_miCaptureFromExeDialogTree"
         resources.ApplyResources(Me._miCaptureFromExeDialogTree, "_miCaptureFromExeDialogTree")
         ' 
         ' _miCaptureFromExeDialogTabbedView
         ' 
         Me._miCaptureFromExeDialogTabbedView.Name = "_miCaptureFromExeDialogTabbedView"
         resources.ApplyResources(Me._miCaptureFromExeDialogTabbedView, "_miCaptureFromExeDialogTabbedView")
         ' 
         ' _miOptions
         ' 
         Me._miOptions.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._miOptionsCaptureOptions, Me._miOptionsCaptureAreaOptions, Me._miOptionsCaptureObjectOptions, Me.toolStripSeparator3, Me._miOptionsMinimizeApplicationOnCapture, Me._miOptionsActivateApplicationAfterCapture, Me.toolStripSeparator4, Me._miOptionsBeepOnCapture})
         Me._miOptions.Name = "_miOptions"
         resources.ApplyResources(Me._miOptions, "_miOptions")
         ' 
         ' _miOptionsCaptureOptions
         ' 
         Me._miOptionsCaptureOptions.Name = "_miOptionsCaptureOptions"
         resources.ApplyResources(Me._miOptionsCaptureOptions, "_miOptionsCaptureOptions")
         ' 
         ' _miOptionsCaptureAreaOptions
         ' 
         Me._miOptionsCaptureAreaOptions.Name = "_miOptionsCaptureAreaOptions"
         resources.ApplyResources(Me._miOptionsCaptureAreaOptions, "_miOptionsCaptureAreaOptions")
         ' 
         ' _miOptionsCaptureObjectOptions
         ' 
         Me._miOptionsCaptureObjectOptions.Name = "_miOptionsCaptureObjectOptions"
         resources.ApplyResources(Me._miOptionsCaptureObjectOptions, "_miOptionsCaptureObjectOptions")
         ' 
         ' toolStripSeparator3
         ' 
         Me.toolStripSeparator3.Name = "toolStripSeparator3"
         resources.ApplyResources(Me.toolStripSeparator3, "toolStripSeparator3")
         ' 
         ' _miOptionsMinimizeApplicationOnCapture
         ' 
         Me._miOptionsMinimizeApplicationOnCapture.Checked = True
         Me._miOptionsMinimizeApplicationOnCapture.CheckState = System.Windows.Forms.CheckState.Checked
         Me._miOptionsMinimizeApplicationOnCapture.Name = "_miOptionsMinimizeApplicationOnCapture"
         resources.ApplyResources(Me._miOptionsMinimizeApplicationOnCapture, "_miOptionsMinimizeApplicationOnCapture")
         ' 
         ' _miOptionsActivateApplicationAfterCapture
         ' 
         Me._miOptionsActivateApplicationAfterCapture.Checked = True
         Me._miOptionsActivateApplicationAfterCapture.CheckState = System.Windows.Forms.CheckState.Checked
         Me._miOptionsActivateApplicationAfterCapture.Name = "_miOptionsActivateApplicationAfterCapture"
         resources.ApplyResources(Me._miOptionsActivateApplicationAfterCapture, "_miOptionsActivateApplicationAfterCapture")
         ' 
         ' toolStripSeparator4
         ' 
         Me.toolStripSeparator4.Name = "toolStripSeparator4"
         resources.ApplyResources(Me.toolStripSeparator4, "toolStripSeparator4")
         ' 
         ' _miOptionsBeepOnCapture
         ' 
         Me._miOptionsBeepOnCapture.Name = "_miOptionsBeepOnCapture"
         resources.ApplyResources(Me._miOptionsBeepOnCapture, "_miOptionsBeepOnCapture")
         ' 
         ' _miView
         ' 
         Me._miView.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._miViewStatusBar})
         Me._miView.Name = "_miView"
         resources.ApplyResources(Me._miView, "_miView")
         ' 
         ' _miViewStatusBar
         ' 
         Me._miViewStatusBar.Name = "_miViewStatusBar"
         resources.ApplyResources(Me._miViewStatusBar, "_miViewStatusBar")
         ' 
         ' _miHelp
         ' 
         Me._miHelp.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._miHelpAbout})
         Me._miHelp.Name = "_miHelp"
         resources.ApplyResources(Me._miHelp, "_miHelp")
         ' 
         ' _miHelpAbout
         ' 
         Me._miHelpAbout.Name = "_miHelpAbout"
         resources.ApplyResources(Me._miHelpAbout, "_miHelpAbout")
         ' 
         ' MainForm
         ' 
         resources.ApplyResources(Me, "$this")
         Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
         Me.Controls.Add(Me._sbMain)
         Me.Controls.Add(Me._mmMain)
         Me.IsMdiContainer = True
         Me.Name = "MainForm"
         Me._sbMain.ResumeLayout(False)
         Me._sbMain.PerformLayout()
         Me._mmMain.ResumeLayout(False)
         Me._mmMain.PerformLayout()
         Me.ResumeLayout(False)
         Me.PerformLayout()

      End Sub

#End Region

      Private _sbMain As StatusStrip
      Private _mmMain As MenuStrip
      Private _miFile As ToolStripMenuItem
      Private WithEvents _miFileSaveAs As ToolStripMenuItem
      Private WithEvents _miFileExit As ToolStripMenuItem
      Private _miEdit As ToolStripMenuItem
      Private WithEvents _miEditCopy As ToolStripMenuItem
      Private WithEvents _miEditCut As ToolStripMenuItem
      Private _miCapture As ToolStripMenuItem
      Private WithEvents _miCaptureActiveWindow As ToolStripMenuItem
      Private WithEvents _miCaptureActiveClient As ToolStripMenuItem
      Private WithEvents _miCaptureFullScreen As ToolStripMenuItem
      Private WithEvents _miCaptureSelectedObject As ToolStripMenuItem
      Private WithEvents _miCaptureMenuUnderCursor As ToolStripMenuItem
      Private WithEvents _miCaptureSelectedArea As ToolStripMenuItem
      Private WithEvents _miCaptureWallpaper As ToolStripMenuItem
      Private WithEvents _miCaptureMouseCursor As ToolStripMenuItem
      Private WithEvents _miCaptureWindowUnderCursor As ToolStripMenuItem
      Private toolStripSeparator1 As ToolStripSeparator
      Private WithEvents _miCaptureStopCapture As ToolStripMenuItem
      Private toolStripSeparator2 As ToolStripSeparator
      Private WithEvents _miCaptureFromExeDialogTree As ToolStripMenuItem
      Private WithEvents _miCaptureFromExeDialogTabbedView As ToolStripMenuItem
      Private _miOptions As ToolStripMenuItem
      Private WithEvents _miOptionsCaptureOptions As ToolStripMenuItem
      Private WithEvents _miOptionsCaptureAreaOptions As ToolStripMenuItem
      Private WithEvents _miOptionsCaptureObjectOptions As ToolStripMenuItem
      Private toolStripSeparator3 As ToolStripSeparator
      Private WithEvents _miOptionsMinimizeApplicationOnCapture As ToolStripMenuItem
      Private WithEvents _miOptionsActivateApplicationAfterCapture As ToolStripMenuItem
      Private toolStripSeparator4 As ToolStripSeparator
      Private WithEvents _miOptionsBeepOnCapture As ToolStripMenuItem
      Private _miView As ToolStripMenuItem
      Private WithEvents _miViewStatusBar As ToolStripMenuItem
      Private _miHelp As ToolStripMenuItem
      Private WithEvents _miHelpAbout As ToolStripMenuItem
      Private _sbiText As ToolStripStatusLabel
   End Class
End Namespace


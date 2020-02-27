' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System
Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Data

Imports Leadtools
Imports Leadtools.Twain
Imports Leadtools.Codecs
Imports Leadtools.Controls
Imports Leadtools.Demos.Dialogs
Imports Leadtools.ImageProcessing.Core
Imports Leadtools.ImageProcessing

Namespace VBFastTwainDemo
   ''' <summary>
   ''' Summary description for Form1.
   ''' </summary>
   Public Class MainForm : Inherits System.Windows.Forms.Form
      Private _mmMain As System.Windows.Forms.MainMenu
      Private _miFile As System.Windows.Forms.MenuItem
      Private WithEvents _miFileSave As System.Windows.Forms.MenuItem
      Private _miFileSep1 As System.Windows.Forms.MenuItem
      Private WithEvents _miFileExit As System.Windows.Forms.MenuItem
      Private _miTwain As System.Windows.Forms.MenuItem
      Private WithEvents _miTwainSelect As System.Windows.Forms.MenuItem
      Private WithEvents _miTwainAcquire As System.Windows.Forms.MenuItem
      Private _miTwainSep1 As System.Windows.Forms.MenuItem
      Private _miTwainCapability As System.Windows.Forms.MenuItem
      Private WithEvents _miTwainCapabilityGet As System.Windows.Forms.MenuItem
      Private WithEvents _miTwainCapabilitySet As System.Windows.Forms.MenuItem
      Private _miTwainSep2 As System.Windows.Forms.MenuItem
      Private WithEvents _miTwainFastTwain As System.Windows.Forms.MenuItem
      Private _miView As System.Windows.Forms.MenuItem
      Private WithEvents _miViewPrevious As System.Windows.Forms.MenuItem
      Private WithEvents _miViewNext As System.Windows.Forms.MenuItem
      Private _miHelp As System.Windows.Forms.MenuItem
      Private WithEvents _miHelpAbout As System.Windows.Forms.MenuItem
      Private WithEvents _miTwainTemplateShow As System.Windows.Forms.MenuItem
      Friend WithEvents _miTwainAcquireCleanup As System.Windows.Forms.MenuItem
      Friend WithEvents _miDocumentCleanup As System.Windows.Forms.MenuItem
      Friend WithEvents _miDocCleanDeskew As System.Windows.Forms.MenuItem
      Friend WithEvents _miDocCleanDespeckle As System.Windows.Forms.MenuItem
      Friend WithEvents _miDocCleanBorderRemove As System.Windows.Forms.MenuItem
      Friend WithEvents _miDocCleanHolePunchRemoval As System.Windows.Forms.MenuItem
      Friend WithEvents _miHelpInfo As System.Windows.Forms.MenuItem
      Private components As IContainer

      Public Sub New()
         '
         ' Required for Windows Form Designer support
         '
         InitializeComponent()

         '
         ' TODO: Add any constructor code after InitializeComponent call
         '
      End Sub

      ''' <summary>
      ''' Clean up any resources being used.
      ''' </summary>
      Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
         If disposing Then
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
         Me._mmMain = New System.Windows.Forms.MainMenu(Me.components)
         Me._miFile = New System.Windows.Forms.MenuItem()
         Me._miFileSave = New System.Windows.Forms.MenuItem()
         Me._miFileSep1 = New System.Windows.Forms.MenuItem()
         Me._miFileExit = New System.Windows.Forms.MenuItem()
         Me._miTwain = New System.Windows.Forms.MenuItem()
         Me._miTwainSelect = New System.Windows.Forms.MenuItem()
         Me._miTwainAcquire = New System.Windows.Forms.MenuItem()
         Me._miTwainSep1 = New System.Windows.Forms.MenuItem()
         Me._miTwainCapability = New System.Windows.Forms.MenuItem()
         Me._miTwainCapabilityGet = New System.Windows.Forms.MenuItem()
         Me._miTwainCapabilitySet = New System.Windows.Forms.MenuItem()
         Me._miTwainTemplateShow = New System.Windows.Forms.MenuItem()
         Me._miTwainSep2 = New System.Windows.Forms.MenuItem()
         Me._miTwainFastTwain = New System.Windows.Forms.MenuItem()
         Me._miView = New System.Windows.Forms.MenuItem()
         Me._miViewPrevious = New System.Windows.Forms.MenuItem()
         Me._miViewNext = New System.Windows.Forms.MenuItem()
         Me._miHelp = New System.Windows.Forms.MenuItem()
         Me._miHelpAbout = New System.Windows.Forms.MenuItem()
         Me._miDocumentCleanup = New System.Windows.Forms.MenuItem()
         Me._miDocCleanDeskew = New System.Windows.Forms.MenuItem()
         Me._miDocCleanDespeckle = New System.Windows.Forms.MenuItem()
         Me._miDocCleanBorderRemove = New System.Windows.Forms.MenuItem()
         Me._miDocCleanHolePunchRemoval = New System.Windows.Forms.MenuItem()
         Me._miHelpInfo = New System.Windows.Forms.MenuItem()
         Me._miTwainAcquireCleanup = New System.Windows.Forms.MenuItem()
         Me.SuspendLayout()
         '
         '_mmMain
         '
         Me._mmMain.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me._miFile, Me._miTwain, Me._miDocumentCleanup, Me._miView, Me._miHelp})
         '
         '_miFile
         '
         Me._miFile.Index = 0
         Me._miFile.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me._miFileSave, Me._miFileSep1, Me._miFileExit})
         Me._miFile.Text = "&File"
         '
         '_miFileSave
         '
         Me._miFileSave.Index = 0
         Me._miFileSave.Shortcut = System.Windows.Forms.Shortcut.CtrlS
         Me._miFileSave.Text = "Sa&ve"
         '
         '_miFileSep1
         '
         Me._miFileSep1.Index = 1
         Me._miFileSep1.Text = "-"
         '
         '_miFileExit
         '
         Me._miFileExit.Index = 2
         Me._miFileExit.Text = "E&xit"
         '
         '_miTwain
         '
         Me._miTwain.Index = 1
         Me._miTwain.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me._miTwainSelect, Me._miTwainAcquire, Me._miTwainAcquireCleanup, Me._miTwainSep1, Me._miTwainCapability, Me._miTwainTemplateShow, Me._miTwainSep2, Me._miTwainFastTwain})
         Me._miTwain.Text = "T&wain"
         '
         '_miTwainSelect
         '
         Me._miTwainSelect.Index = 0
         Me._miTwainSelect.Text = "&Select..."
         '
         '_miTwainAcquire
         '
         Me._miTwainAcquire.Index = 1
         Me._miTwainAcquire.Text = "Ac&quire..."
         '
         '_miTwainSep1
         '
         Me._miTwainSep1.Index = 3
         Me._miTwainSep1.Text = "-"
         '
         '_miTwainCapability
         '
         Me._miTwainCapability.Index = 4
         Me._miTwainCapability.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me._miTwainCapabilityGet, Me._miTwainCapabilitySet})
         Me._miTwainCapability.Text = "&Capability"
         '
         '_miTwainCapabilityGet
         '
         Me._miTwainCapabilityGet.Index = 0
         Me._miTwainCapabilityGet.Text = "&Get..."
         '
         '_miTwainCapabilitySet
         '
         Me._miTwainCapabilitySet.Index = 1
         Me._miTwainCapabilitySet.Text = "&Set..."
         '
         '_miTwainTemplateShow
         '
         Me._miTwainTemplateShow.Index = 5
         Me._miTwainTemplateShow.Text = "&Show Template..."
         '
         '_miTwainSep2
         '
         Me._miTwainSep2.Index = 6
         Me._miTwainSep2.Text = "-"
         '
         '_miTwainFastTwain
         '
         Me._miTwainFastTwain.Index = 7
         Me._miTwainFastTwain.Text = "Fast T&wain..."
         '
         '_miView
         '
         Me._miView.Index = 3
         Me._miView.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me._miViewPrevious, Me._miViewNext})
         Me._miView.Text = "&View"
         '
         '_miViewPrevious
         '
         Me._miViewPrevious.Index = 0
         Me._miViewPrevious.Text = "&Previous"
         '
         '_miViewNext
         '
         Me._miViewNext.Index = 1
         Me._miViewNext.Text = "&Next"
         '
         '_miHelp
         '
         Me._miHelp.Index = 4
         Me._miHelp.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me._miHelpAbout, Me._miHelpInfo})
         Me._miHelp.Text = "&Help"
         '
         '_miHelpAbout
         '
         Me._miHelpAbout.Index = 0
         Me._miHelpAbout.Text = "&About..."
         '
         '_miDocumentCleanup
         '
         Me._miDocumentCleanup.Index = 2
         Me._miDocumentCleanup.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me._miDocCleanDeskew, Me._miDocCleanDespeckle, Me._miDocCleanBorderRemove, Me._miDocCleanHolePunchRemoval})
         Me._miDocumentCleanup.Text = "Document &Cleanup"
         '
         '_miDocCleanDeskew
         '
         Me._miDocCleanDeskew.Checked = True
         Me._miDocCleanDeskew.Index = 0
         Me._miDocCleanDeskew.Text = "&Deskew"
         '
         '_miDocCleanDespeckle
         '
         Me._miDocCleanDespeckle.Checked = True
         Me._miDocCleanDespeckle.Index = 1
         Me._miDocCleanDespeckle.Text = "Des&peckle"
         '
         '_miDocCleanBorderRemove
         '
         Me._miDocCleanBorderRemove.Checked = True
         Me._miDocCleanBorderRemove.Index = 2
         Me._miDocCleanBorderRemove.Text = "&Border Remove"
         '
         '_miDocCleanHolePunchRemoval
         '
         Me._miDocCleanHolePunchRemoval.Checked = True
         Me._miDocCleanHolePunchRemoval.Index = 3
         Me._miDocCleanHolePunchRemoval.Text = "&Hole Punch Removal"
         '
         '_miHelpInfo
         '
         Me._miHelpInfo.Index = 1
         Me._miHelpInfo.Text = "&Information"
         '
         '_miTwainAcquireCleanup
         '
         Me._miTwainAcquireCleanup.Index = 2
         Me._miTwainAcquireCleanup.Text = "Acquire With &Cleanup..."
         '
         'MainForm
         '
         Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
         Me.ClientSize = New System.Drawing.Size(616, 393)
         Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
         Me.Menu = Me._mmMain
         Me.Name = "MainForm"
         Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
         Me.Text = "Twain Capabilities and Fast Twain VB demo"
         Me.ResumeLayout(False)

      End Sub
#End Region
      Private _twainSession As TwainSession
      Private _viewer As ImageViewer
      Private _codecs As RasterCodecs
      Private _transferMode As TwainCapabilityValue = TwainCapabilityValue.TransferMechanismNative
      Private Shared _twainAvailable As Boolean = False
      Private _infoDlg As TwainDocumentCleanupMessage = New TwainDocumentCleanupMessage()
      Private _cleanupAfterAcquire As Boolean = False

      ''' <summary>
      ''' The main entry point for the application.
      ''' </summary>
      <STAThread()> _
      Shared Sub Main()

         If Not Support.SetLicense() Then
            Return
         End If

         Application.Run(New MainForm())
      End Sub

      Private Sub _miHelpAbout_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _miHelpAbout.Click
         Using aboutDialog As New AboutDialog("Twain Capabilities and Fast Twain", ProgrammingInterface.VB)
            aboutDialog.ShowDialog(Me)
         End Using
      End Sub

      Private Sub _miFileExit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _miFileExit.Click
         Close()
      End Sub

      Public Shared ReadOnly Property TwainAvailable() As Boolean
         Get
            Return _twainAvailable
         End Get
      End Property

      Private Sub MainForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
         Messager.Caption = "Twain Capabilities and Fast Twain VB Demo"
         Text = Messager.Caption

         ' initialize the _viewer object
         _viewer = New ImageViewer()
         _viewer.Dock = DockStyle.Fill
         _viewer.BackColor = Color.DarkGray
         Controls.Add(_viewer)
         _viewer.BringToFront()

         ' initialize the codecs object
         _codecs = New RasterCodecs()

         Try
            _twainAvailable = TwainSession.IsAvailable(Me.Handle)
            If _twainAvailable Then
               _twainSession = New TwainSession()

               ' For 32-bit driver support in 64-bit applications, use the following TWAIN initialization method instead:
               '_twainSession.Startup(Me.Handle, "LEAD Technologies, Inc.", "LEAD Test Applications", "Version 1.0", "TWAIN Test Application", TwainStartupFlags.UseThunkServer)

               _twainSession.Startup(Me.Handle, "LEAD Technologies, Inc.", "LEAD Test Applications", "Version 1.0", "TWAIN Test Application", TwainStartupFlags.None)
               AddHandler _twainSession.AcquirePage, AddressOf _twain_AcquirePage
            Else
               _miTwainSelect.Enabled = False
               _miTwainAcquire.Enabled = False
               _miTwainAcquireCleanup.Enabled = False
               _miTwainCapabilityGet.Enabled = False
               _miTwainCapabilitySet.Enabled = False
               _miTwainTemplateShow.Enabled = False
               _miTwainFastTwain.Enabled = False
            End If

            _miFileSave.Enabled = False
            _miViewPrevious.Enabled = False
            _miViewNext.Enabled = False
         Catch ex As TwainException
            _miTwainSelect.Enabled = False
            _miTwainAcquire.Enabled = False
            _miTwainAcquireCleanup.Enabled = False
            _miTwainCapabilityGet.Enabled = False
            _miTwainCapabilitySet.Enabled = False
            _miTwainTemplateShow.Enabled = False
            _miTwainFastTwain.Enabled = False
            _miFileSave.Enabled = False
            _miViewPrevious.Enabled = False
            _miViewNext.Enabled = False
            If ex.Code = TwainExceptionCode.InvalidDll Then
               Messager.ShowError(Me, "You have an old version of TWAINDSM.DLL. Please download latest version of this DLL from www.twain.org")
            Else
               Messager.ShowError(Me, ex)
            End If
         Catch ex As Exception
            Messager.ShowError(Me, ex)
            _twainSession = Nothing
         End Try
      End Sub

      Private Sub MainForm_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles Me.Closing
         If Not _twainSession Is Nothing Then
            _twainSession.Shutdown()
         End If
      End Sub

      Private Sub _miTwainSelect_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _miTwainSelect.Click
         _twainSession.SelectSource(String.Empty)
      End Sub

      Private Sub _miTwainCapabilitySet_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _miTwainCapabilitySet.Click
         Using capDlg As CapabilityDialog = New CapabilityDialog()
            capDlg._useGetCapability = False
            capDlg._session = _twainSession

            capDlg.ShowDialog(Me)
         End Using
      End Sub

      Private Sub _miTwainCapabilityGet_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _miTwainCapabilityGet.Click
         Using capDlg As CapabilityDialog = New CapabilityDialog()
            capDlg._useGetCapability = True
            capDlg._session = _twainSession

            capDlg.ShowDialog(Me)
         End Using
      End Sub

      Private Sub _twain_AcquirePage(ByVal sender As Object, ByVal e As TwainAcquirePageEventArgs)
         Try
            If Not _transferMode = TwainCapabilityValue.TransferMechanismFile Then
               If (_cleanupAfterAcquire) Then
                  ApplyDocumentCleanupCommands(e.Image)
               End If

               If Not e.Image Is Nothing Then
                  If _viewer.Image Is Nothing Then
                     _viewer.Image = e.Image

                     _miViewPrevious.Enabled = False
                     _miViewNext.Enabled = False
                  Else
                     _viewer.Image.AddPage(e.Image)
                     _viewer.Image.Page = _viewer.Image.PageCount

                     _miViewPrevious.Enabled = True
                     _miViewNext.Enabled = False
                  End If

                  _miFileSave.Enabled = True
               End If
            Else
               MessageBox.Show(Me, "Acquired page(s) is saved to file(s)", "Acquire to File")
            End If
         Catch ex As Exception
            Messager.ShowError(Me, ex)
         End Try
      End Sub

      Private Sub _miTwainAcquire_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _miTwainAcquire.Click
         Acquire(False)
      End Sub

      Private Sub _miViewPrevious_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _miViewPrevious.Click
         Dim currentPage As Integer = _viewer.Image.Page
         If currentPage = 1 Then
            _miViewPrevious.Enabled = False
         Else
            currentPage -= 1
            _viewer.Image.Page = currentPage

            If (currentPage <> 1) Then
               _miViewPrevious.Enabled = True
            Else
               _miViewPrevious.Enabled = False
            End If
         End If

         _miViewNext.Enabled = True
      End Sub

      Private Sub _miViewNext_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _miViewNext.Click
         Dim currentPage As Integer = _viewer.Image.Page
         If currentPage = _viewer.Image.PageCount Then
            _miViewNext.Enabled = False
         Else
            currentPage += 1
            _viewer.Image.Page = currentPage
            If (currentPage <> _viewer.Image.PageCount) Then
               _miViewNext.Enabled = True
            Else
               _miViewNext.Enabled = False
            End If
         End If

         _miViewPrevious.Enabled = True
      End Sub

      Private Sub _miFileSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _miFileSave.Click
         Dim saver As ImageFileSaver = New ImageFileSaver()
         Try
            saver.Save(Me, _codecs, _viewer.Image)
         Catch ex As Exception
            Messager.ShowFileSaveError(Me, saver.FileName, ex)
         End Try
      End Sub

      Private Sub _miTwainFastTwain_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _miTwainFastTwain.Click
         Using fastOptsDlg As FastOptions = New FastOptions()
            fastOptsDlg._session = _twainSession
            fastOptsDlg.ShowDialog(Me)
         End Using
      End Sub

      Private Sub _miTwainTemplateShow_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _miTwainTemplateShow.Click
         Using templateDlg As Template = New Template()
            templateDlg._twainSession = _twainSession
            templateDlg.ShowDialog(Me)
            _transferMode = templateDlg._transferMode
         End Using
      End Sub

      Private Sub _miDocCleanDeskew_Click(sender As System.Object, e As System.EventArgs) Handles _miDocCleanDeskew.Click
         _miDocCleanDeskew.Checked = Not _miDocCleanDeskew.Checked
      End Sub

      Private Sub _miDocCleanDespeckle_Click(sender As System.Object, e As System.EventArgs) Handles _miDocCleanDespeckle.Click
         _miDocCleanDespeckle.Checked = Not _miDocCleanDespeckle.Checked
      End Sub

      Private Sub _miDocCleanBorderRemove_Click(sender As System.Object, e As System.EventArgs) Handles _miDocCleanBorderRemove.Click
         _miDocCleanBorderRemove.Checked = Not _miDocCleanBorderRemove.Checked
      End Sub

      Private Sub _miDocCleanHolePunchRemoval_Click(sender As System.Object, e As System.EventArgs) Handles _miDocCleanHolePunchRemoval.Click
         _miDocCleanHolePunchRemoval.Checked = Not _miDocCleanHolePunchRemoval.Checked
      End Sub

      Private Sub _miHelpInfo_Click(sender As System.Object, e As System.EventArgs) Handles _miHelpInfo.Click
         _infoDlg.ShowDialog()
      End Sub

      Private Sub ApplyDocumentCleanupCommands(image As RasterImage)
         Try
            If image.BitsPerPixel <> 1 Then
               Dim colorRes As ColorResolutionCommand = New ColorResolutionCommand()
               colorRes.BitsPerPixel = 1

               colorRes.Order = image.Order
               colorRes.Mode = ColorResolutionCommandMode.InPlace
               colorRes.Run(image)
            End If

            If _miDocCleanDeskew.Checked Then
               Dim cmd As DeskewCommand = New DeskewCommand()
               cmd.FillColor = RasterColor.White
               cmd.Flags = DeskewCommandFlags.FillExposedArea

               cmd.Run(image)
            End If

            If _miDocCleanDespeckle.Checked Then
               Dim cmd As DespeckleCommand = New DespeckleCommand()
               cmd.Run(image)
            End If

            If _miDocCleanBorderRemove.Checked Then
               Dim cmd As BorderRemoveCommand = New BorderRemoveCommand()
               cmd.Flags = BorderRemoveCommandFlags.AutoRemove
               cmd.Run(image)
            End If

            If _miDocCleanHolePunchRemoval.Checked Then
               Dim cmd As HolePunchRemoveCommand = New HolePunchRemoveCommand()

               ' try to remove left hole punches
               cmd.Flags = HolePunchRemoveCommandFlags.UseNormalDetection
               cmd.Run(image)

               ' try to remove right hole punches
               cmd.Flags = HolePunchRemoveCommandFlags.UseNormalDetection Or HolePunchRemoveCommandFlags.UseLocation
               cmd.Location = HolePunchRemoveCommandLocation.Right
               cmd.Run(image)
            End If
         Catch ex As Exception
            Messager.ShowError(Me, ex)
         End Try
      End Sub

      Private Sub _miTwainAcquireCleanup_Click(sender As System.Object, e As System.EventArgs) Handles _miTwainAcquireCleanup.Click
         Acquire(True)
      End Sub

      Private Sub Acquire(cleanup As Boolean)
         If (Not DemosGlobal.CheckKnown3rdPartyTwainIssues(Me, _twainSession.SelectedSourceName())) Then
            Return
         End If

         Try
            _cleanupAfterAcquire = cleanup

            If _cleanupAfterAcquire Then
               ShowCleanUpMessage()
            End If

            _twainSession.Acquire(TwainUserInterfaceFlags.Show Or TwainUserInterfaceFlags.Modal)
         Catch ex As Exception
            Messager.ShowError(Me, ex)
         End Try
      End Sub

      Private Sub ShowCleanUpMessage()
         If _miDocCleanDeskew.Checked Or _miDocCleanDespeckle.Checked Or _miDocCleanBorderRemove.Checked Or _miDocCleanHolePunchRemoval.Checked Then
            If _infoDlg.ShouldShow() Then
               _infoDlg.ShowDialog()
            End If
         End If
      End Sub
   End Class
End Namespace

' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports Leadtools
Imports Leadtools.Twain
Imports Leadtools.Codecs
Imports System.IO
Imports Leadtools.Demos.Dialogs
Imports Leadtools.ImageProcessing.Core
Imports Leadtools.ImageProcessing

Public Class MainForm
   Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

   Public Sub New()
      MyBase.New()

      'This call is required by the Windows Form Designer.
      InitializeComponent()

      'Add any initialization after the InitializeComponent() call

   End Sub

   'Form overrides dispose to clean up the component list.
   Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
      If disposing Then
         If Not (components Is Nothing) Then
            components.Dispose()
         End If
      End If
      MyBase.Dispose(disposing)
   End Sub

   'Required by the Windows Form Designer
   Private components As System.ComponentModel.IContainer

   'NOTE: The following procedure is required by the Windows Form Designer
   'It can be modified using the Windows Form Designer.  
   'Do not modify it using the code editor.
   Friend WithEvents _mmFileSep2 As System.Windows.Forms.MenuItem
   Friend WithEvents _miFileClose As System.Windows.Forms.MenuItem
   Friend WithEvents _miTwain As System.Windows.Forms.MenuItem
   Friend WithEvents _miTwainSelectSource As System.Windows.Forms.MenuItem
   Friend WithEvents _miTwainAcquire As System.Windows.Forms.MenuItem
   Friend WithEvents _miFileExit As System.Windows.Forms.MenuItem
   Friend WithEvents _miFileSep1 As System.Windows.Forms.MenuItem
   Friend WithEvents _miFile As System.Windows.Forms.MenuItem
   Friend WithEvents _miFileOpen As System.Windows.Forms.MenuItem
   Friend WithEvents _miFileSave As System.Windows.Forms.MenuItem
   Friend WithEvents _mmMain As System.Windows.Forms.MainMenu
   Friend WithEvents _miTemplate As System.Windows.Forms.MenuItem
   Friend WithEvents _miTemplateLEAD As System.Windows.Forms.MenuItem
   Friend WithEvents _miTemplateShowCaps As System.Windows.Forms.MenuItem
   Friend WithEvents _miTemplateSep1 As System.Windows.Forms.MenuItem
   Friend WithEvents _miTemplateShowErrors As System.Windows.Forms.MenuItem
   Friend WithEvents _miHelp As System.Windows.Forms.MenuItem
   Friend WithEvents _miTwainAcquireCleanup As System.Windows.Forms.MenuItem
   Friend WithEvents _miDocumentCleanup As System.Windows.Forms.MenuItem
   Friend WithEvents _miDocCleanDeskew As System.Windows.Forms.MenuItem
   Friend WithEvents _miDocCleanDespeckle As System.Windows.Forms.MenuItem
   Friend WithEvents _miDocCleanBorderRemove As System.Windows.Forms.MenuItem
   Friend WithEvents _miDocCleanHolePunchRemoval As System.Windows.Forms.MenuItem
   Friend WithEvents _miHelpInfo As System.Windows.Forms.MenuItem
   Friend WithEvents _miHelpAbout As System.Windows.Forms.MenuItem
   <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainForm))
      Me._mmFileSep2 = New System.Windows.Forms.MenuItem()
      Me._miFileClose = New System.Windows.Forms.MenuItem()
      Me._miTwain = New System.Windows.Forms.MenuItem()
      Me._miTwainSelectSource = New System.Windows.Forms.MenuItem()
      Me._miTwainAcquire = New System.Windows.Forms.MenuItem()
      Me._miFileExit = New System.Windows.Forms.MenuItem()
      Me._miFileSep1 = New System.Windows.Forms.MenuItem()
      Me._miFile = New System.Windows.Forms.MenuItem()
      Me._miFileOpen = New System.Windows.Forms.MenuItem()
      Me._miFileSave = New System.Windows.Forms.MenuItem()
      Me._mmMain = New System.Windows.Forms.MainMenu(Me.components)
      Me._miTemplate = New System.Windows.Forms.MenuItem()
      Me._miTemplateLEAD = New System.Windows.Forms.MenuItem()
      Me._miTemplateShowCaps = New System.Windows.Forms.MenuItem()
      Me._miTemplateSep1 = New System.Windows.Forms.MenuItem()
      Me._miTemplateShowErrors = New System.Windows.Forms.MenuItem()
      Me._miHelp = New System.Windows.Forms.MenuItem()
      Me._miHelpAbout = New System.Windows.Forms.MenuItem()
      Me._miHelpInfo = New System.Windows.Forms.MenuItem()
      Me._miTwainAcquireCleanup = New System.Windows.Forms.MenuItem()
      Me._miDocumentCleanup = New System.Windows.Forms.MenuItem()
      Me._miDocCleanDeskew = New System.Windows.Forms.MenuItem()
      Me._miDocCleanDespeckle = New System.Windows.Forms.MenuItem()
      Me._miDocCleanBorderRemove = New System.Windows.Forms.MenuItem()
      Me._miDocCleanHolePunchRemoval = New System.Windows.Forms.MenuItem()
      Me.SuspendLayout()
      '
      '_mmFileSep2
      '
      Me._mmFileSep2.Index = 4
      Me._mmFileSep2.Text = "-"
      '
      '_miFileClose
      '
      Me._miFileClose.Index = 3
      Me._miFileClose.Text = "&Close"
      '
      '_miTwain
      '
      Me._miTwain.Index = 1
      Me._miTwain.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me._miTwainSelectSource, Me._miTwainAcquire, Me._miTwainAcquireCleanup})
      Me._miTwain.Text = "T&wain"
      '
      '_miTwainSelectSource
      '
      Me._miTwainSelectSource.Index = 0
      Me._miTwainSelectSource.Text = "&Select Source"
      '
      '_miTwainAcquire
      '
      Me._miTwainAcquire.Index = 1
      Me._miTwainAcquire.Text = "Ac&quire"
      '
      '_miFileExit
      '
      Me._miFileExit.Index = 5
      Me._miFileExit.Text = "E&xit"
      '
      '_miFileSep1
      '
      Me._miFileSep1.Index = 2
      Me._miFileSep1.Text = "-"
      '
      '_miFile
      '
      Me._miFile.Index = 0
      Me._miFile.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me._miFileOpen, Me._miFileSave, Me._miFileSep1, Me._miFileClose, Me._mmFileSep2, Me._miFileExit})
      Me._miFile.Text = "&File"
      '
      '_miFileOpen
      '
      Me._miFileOpen.Index = 0
      Me._miFileOpen.Shortcut = System.Windows.Forms.Shortcut.CtrlO
      Me._miFileOpen.Text = "&Open"
      '
      '_miFileSave
      '
      Me._miFileSave.Index = 1
      Me._miFileSave.Shortcut = System.Windows.Forms.Shortcut.CtrlS
      Me._miFileSave.Text = "&Save"
      '
      '_mmMain
      '
      Me._mmMain.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me._miFile, Me._miTwain, Me._miDocumentCleanup, Me._miTemplate, Me._miHelp})
      '
      '_miTemplate
      '
      Me._miTemplate.Index = 3
      Me._miTemplate.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me._miTemplateLEAD, Me._miTemplateShowCaps, Me._miTemplateSep1, Me._miTemplateShowErrors})
      Me._miTemplate.Text = "Te&mplate"
      '
      '_miTemplateLEAD
      '
      Me._miTemplateLEAD.Index = 0
      Me._miTemplateLEAD.Text = "&LEAD Template"
      '
      '_miTemplateShowCaps
      '
      Me._miTemplateShowCaps.Index = 1
      Me._miTemplateShowCaps.Text = "Show Supported &Capabilities"
      '
      '_miTemplateSep1
      '
      Me._miTemplateSep1.Index = 2
      Me._miTemplateSep1.Text = "-"
      '
      '_miTemplateShowErrors
      '
      Me._miTemplateShowErrors.Index = 3
      Me._miTemplateShowErrors.Text = "Show &Error Codes..."
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
      Me._miHelpAbout.Text = "&About"
      '
      '_miHelpInfo
      '
      Me._miHelpInfo.Index = 1
      Me._miHelpInfo.Text = "&Information"
      '
      '_miTwainAcquireCleanup
      '
      Me._miTwainAcquireCleanup.Index = 2
      Me._miTwainAcquireCleanup.Text = "Acquire With &Cleanup"
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
      'MainForm
      '
      Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
      Me.ClientSize = New System.Drawing.Size(544, 342)
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.IsMdiContainer = True
      Me.Menu = Me._mmMain
      Me.Name = "MainForm"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "TWAIN VB.NET Demo"
      Me.ResumeLayout(False)

   End Sub

#End Region
   Public WithEvents _twainSession As TwainSession
   Public _codecs As RasterCodecs
   Public _scanCount As Integer
   Public _transferMode As TwainTransferMechanism = TwainTransferMechanism.Native
   Dim _twainAvailable As Boolean = False
   Private _openInitialPath As String = ""
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

      Application.EnableVisualStyles()
      Application.SetCompatibleTextRenderingDefault(False)
      Application.Run(New MainForm())
   End Sub

   Private Sub MainForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
      Messager.Caption = "Twain VB.NET Demo"
      Text = Messager.Caption

      ' initialize the codecs object
      _codecs = New RasterCodecs

      ' Determine whether a TWAIN source is installed
      _twainAvailable = TwainSession.IsAvailable(Me.Handle)

      If (_twainAvailable) Then
         Try
            ' Construct a new TwainSession object with default values
            _twainSession = New TwainSession
            ' Initialize the TWAIN session
            ' This method must be called before calling any other methods that require a TWAIN session

            ' For 32-bit driver support in 64-bit applications, use the following TWAIN initialization method instead:
            '_twainSession.Startup(Me.Handle, "LEAD Technologies, Inc.", "LEAD Test Applications", "Version 1.0", "TWAIN Test Application", TwainStartupFlags.UseThunkServer)

            _twainSession.Startup(Me.Handle, "LEAD Technologies, Inc.", "LEAD Test Applications", "Version 1.0", "TWAIN Test Application", TwainStartupFlags.None)

         Catch ex As TwainException
            If (ex.Code = TwainExceptionCode.InvalidDll) Then
               _miTwainSelectSource.Enabled = False
               _miTwainAcquire.Enabled = False
               _miTwainAcquireCleanup.Enabled = False
               _miTemplateLEAD.Enabled = False
               _miTemplateShowCaps.Enabled = False
               _miTemplateShowErrors.Enabled = False
               Messager.ShowError(Me, "You have an old version of TWAINDSM.DLL. Please download latest version of this DLL from www.twain.org")
            Else
               _miTwainSelectSource.Enabled = False
               _miTwainAcquire.Enabled = False
               _miTwainAcquireCleanup.Enabled = False
               _miTemplateLEAD.Enabled = False
               _miTemplateShowCaps.Enabled = False
               _miTemplateShowErrors.Enabled = False
               Messager.ShowError(Me, ex)
            End If

         Catch ex As Exception
            Messager.ShowError(Me, ex)
            _miTwainSelectSource.Enabled = False
            _miTwainAcquire.Enabled = False
            _miTwainAcquireCleanup.Enabled = False
            _miTemplateLEAD.Enabled = False
            _miTemplateShowCaps.Enabled = False
            _miTemplateShowErrors.Enabled = False
         End Try
      Else
         _miTwainSelectSource.Enabled = False
         _miTwainAcquire.Enabled = False
         _miTwainAcquireCleanup.Enabled = False
         _miTemplateLEAD.Enabled = False
         _miTemplateShowCaps.Enabled = False
         _miTemplateShowErrors.Enabled = False
      End If

      EnableMenuItems(False)
      _errorList = New ArrayList
   End Sub

   Public Sub EnableMenuItems(ByVal enable As Boolean)
      _miFileSave.Enabled = enable
      _miFileClose.Enabled = enable
   End Sub

   Private Sub _miFileClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _miFileClose.Click
      ActiveMdiChild.Close()
   End Sub

   Private Sub _miHelpAbout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _miHelpAbout.Click
      Using aboutDialog As New AboutDialog("Twain", ProgrammingInterface.VB)
         aboutDialog.ShowDialog(Me)
      End Using
   End Sub

   Private Sub _miTwainSelectSource_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _miTwainSelectSource.Click
      ' Display the TWAIN dialog box to be used to select a TWAIN source for acquiring images
      _twainSession.SelectSource(String.Empty)
   End Sub

   Private Sub _twainSession_AcquirePage(ByVal sender As Object, ByVal e As TwainAcquirePageEventArgs) Handles _twainSession.AcquirePage
      ' This event occurs for each page acquired using the Acquire method
      Try
         If _transferMode = TwainCapabilityValue.TransferMechanismFile Then
            MessageBox.Show(Me, "Acquired page(s) is saved to file(s)", "Acquire to File")
         Else
            If Not IsNothing(e.Image) Then
               _scanCount = _scanCount + 1
               Dim childCaption As String
               childCaption = String.Format("Twain Scanned page {0}", _scanCount.ToString())

               If (_cleanupAfterAcquire) Then
                  ApplyDocumentCleanupCommands(e.Image)
               End If

               CreateChildForm(e.Image, childCaption)
            End If
         End If
      Catch ex As Exception
         AddErrorToErrorList(ex.Message)
      End Try
   End Sub

   Private Sub CreateChildForm(ByVal img As RasterImage, ByVal caption As String)
      Dim child As ChildForm = New ChildForm
      child.MdiParent = Me
      child.InsertImage(img, caption)
      child.Show()

      EnableMenuItems(True)
   End Sub

   Private Sub _miFileOpen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _miFileOpen.Click
      Dim loader As ImageFileLoader = New ImageFileLoader

      Try
         loader.LoadOnlyOnePage = True
         loader.OpenDialogInitialPath = _openInitialPath
         If (loader.Load(Me, _codecs, True) > 0) Then
            _openInitialPath = Path.GetDirectoryName(loader.FileName)
            CreateChildForm(loader.Image, loader.FileName)
         End If
      Catch ex As Exception
         Messager.ShowFileOpenError(Me, loader.FileName, ex)
      End Try
   End Sub

   Private Sub _miFileExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _miFileExit.Click
      Close()
   End Sub

   Private Sub _miFileSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _miFileSave.Click
      Dim saver As ImageFileSaver = New ImageFileSaver

      Try
         Dim child As ChildForm = CType(ActiveMdiChild, ChildForm)
         saver.Save(Me, _codecs, child._viewer.Image)
      Catch ex As Exception
         Messager.ShowFileSaveError(Me, saver.FileName, ex)
      End Try
   End Sub

   Private Sub _miTwainAcquire_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _miTwainAcquire.Click
      Acquire(False)
   End Sub

   Private Sub SetTransferMode()
      Dim twnCap As TwainCapability = New TwainCapability

      Try
         twnCap.Information.Type = TwainCapabilityType.ImageTransferMechanism
         twnCap.Information.ContainerType = TwainContainerType.OneValue

         twnCap.OneValueCapability.ItemType = TwainItemType.Uint16
         twnCap.OneValueCapability.Value = CType(_transferMode, UInt16)

         ' Set the value of ICAP_XFERMECH (Image Transfer Mechanism) capability
         _twainSession.SetCapability(twnCap, TwainSetCapabilityMode.Set)
      Catch ex As Exception
         Dim errorMsg As String = String.Format("Error set TwainCapabilityType.ImageTransferMechanism is {0}", ex.Message)
         AddErrorToErrorList(errorMsg)
      End Try
   End Sub

   Private Sub _miTemplateShowCaps_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _miTemplateShowCaps.Click
      Dim supportedCapsDls As SupportedCaps = New SupportedCaps

      Try
         ' Get an array of Twain Capabilities supported in the current session
         supportedCapsDls._caps = _twainSession.QuerySupportedCapabilities
         supportedCapsDls.ShowDialog(Me)
      Catch ex As Exception
         AddErrorToErrorList(ex.Message)
      End Try
   End Sub

   Private Sub _miTemplateShowErrors_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _miTemplateShowErrors.Click
      Dim errorListDlg As ErrorList = New ErrorList

      Try
         errorListDlg._arrayList = _errorList
         If errorListDlg.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK Then
            If errorListDlg._listCleared Then
               _errorList.Clear()
            End If
         End If
      Catch ex As Exception
         ex = ex
      End Try
   End Sub

   Private Sub _miTemplateLEAD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _miTemplateLEAD.Click
      ' Show the Templates dialog which will allow to Save/Load scanning settings
      Dim templateDlg As Template = New Template

      Try
         templateDlg._twainSession = _twainSession
         templateDlg.ShowDialog(Me)

         If templateDlg.DialogResult = System.Windows.Forms.DialogResult.OK Then
            _transferMode = templateDlg._transferMode
         End If
      Catch ex As Exception
         ex = ex
      End Try
   End Sub

   Private Sub MainForm_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
      If Not IsNothing(_twainSession) AndAlso _twainAvailable Then
         ' End TWAIN session
         ' For each call to the Startup method there must be a call to the Shutdown method
         _twainSession.Shutdown()
      End If
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
      Try
         SetTransferMode()
         If (Not DemosGlobal.CheckKnown3rdPartyTwainIssues(Me, _twainSession.SelectedSourceName())) Then
            Return
         End If

         _cleanupAfterAcquire = cleanup

         If _cleanupAfterAcquire Then
            ShowCleanUpMessage()
         End If

         ' Acquire one or more images from a TWAIN source.
         _twainSession.Acquire(TwainUserInterfaceFlags.Show Or TwainUserInterfaceFlags.Modal)
      Catch ex As Exception
         AddErrorToErrorList(ex.Message)
         MessageBox.Show(Me, ex.Message)
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

' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System.IO

Imports Leadtools
Imports Leadtools.Codecs
Imports Leadtools.Twain
Imports Leadtools.Controls
Imports Leadtools.WinForms.CommonDialogs.File
Imports Leadtools.Demos.Dialogs
Imports Leadtools.ImageProcessing
Imports Leadtools.ImageProcessing.Core

Public Class MainForm
   Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

   Public Sub New()
      MyBase.New()

      'This call is required by the Windows Form Designer.
      InitializeComponent()

      'Add any initialization after the InitializeComponent() call
      InitClass()
   End Sub

   'Form overrides dispose to clean up the component list.
   Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
      If disposing Then
         CleanUp()

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
   Friend WithEvents _miFileSelectSource As System.Windows.Forms.MenuItem
   Friend WithEvents _miHelp As System.Windows.Forms.MenuItem
   Friend WithEvents _miHelpAbout As System.Windows.Forms.MenuItem
   Friend WithEvents _miPageLast As System.Windows.Forms.MenuItem
   Friend WithEvents _sbMain As System.Windows.Forms.StatusBar
   Friend WithEvents _miFileAcquire As System.Windows.Forms.MenuItem
   Friend WithEvents _miFile As System.Windows.Forms.MenuItem
   Friend WithEvents _miFileSep1 As System.Windows.Forms.MenuItem
   Friend WithEvents _miFileExit As System.Windows.Forms.MenuItem
   Friend WithEvents _miPageNext As System.Windows.Forms.MenuItem
   Friend WithEvents _mmMain As System.Windows.Forms.MainMenu
   Friend WithEvents _miPage As System.Windows.Forms.MenuItem
   Friend WithEvents _miPageFirst As System.Windows.Forms.MenuItem
   Friend WithEvents _miHelpInfo As System.Windows.Forms.MenuItem
   Friend WithEvents _miTwainAcquireCleanup As System.Windows.Forms.MenuItem
   Friend WithEvents _miDocumentCleanup As System.Windows.Forms.MenuItem
   Friend WithEvents _miDocCleanDeskew As System.Windows.Forms.MenuItem
   Friend WithEvents _miDocCleanDespeckle As System.Windows.Forms.MenuItem
   Friend WithEvents _miDocCleanBorderRemove As System.Windows.Forms.MenuItem
   Friend WithEvents _miDocCleanHolePunchRemoval As System.Windows.Forms.MenuItem
   Friend WithEvents _miPagePrevious As System.Windows.Forms.MenuItem
   <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainForm))
      Me._miFileSelectSource = New System.Windows.Forms.MenuItem()
      Me._miHelp = New System.Windows.Forms.MenuItem()
      Me._miHelpAbout = New System.Windows.Forms.MenuItem()
      Me._miPageLast = New System.Windows.Forms.MenuItem()
      Me._sbMain = New System.Windows.Forms.StatusBar()
      Me._miFileAcquire = New System.Windows.Forms.MenuItem()
      Me._miFile = New System.Windows.Forms.MenuItem()
      Me._miFileSep1 = New System.Windows.Forms.MenuItem()
      Me._miFileExit = New System.Windows.Forms.MenuItem()
      Me._miPageNext = New System.Windows.Forms.MenuItem()
      Me._mmMain = New System.Windows.Forms.MainMenu(Me.components)
      Me._miPage = New System.Windows.Forms.MenuItem()
      Me._miPageFirst = New System.Windows.Forms.MenuItem()
      Me._miPagePrevious = New System.Windows.Forms.MenuItem()
      Me._miTwainAcquireCleanup = New System.Windows.Forms.MenuItem()
      Me._miDocumentCleanup = New System.Windows.Forms.MenuItem()
      Me._miDocCleanDeskew = New System.Windows.Forms.MenuItem()
      Me._miDocCleanDespeckle = New System.Windows.Forms.MenuItem()
      Me._miDocCleanBorderRemove = New System.Windows.Forms.MenuItem()
      Me._miDocCleanHolePunchRemoval = New System.Windows.Forms.MenuItem()
      Me._miHelpInfo = New System.Windows.Forms.MenuItem()
      Me.SuspendLayout()
      '
      '_miFileSelectSource
      '
      Me._miFileSelectSource.Index = 0
      Me._miFileSelectSource.Text = "&Select Source..."
      '
      '_miHelp
      '
      Me._miHelp.Index = 3
      Me._miHelp.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me._miHelpAbout, Me._miHelpInfo})
      Me._miHelp.Text = "&Help"
      '
      '_miHelpAbout
      '
      Me._miHelpAbout.Index = 0
      Me._miHelpAbout.Text = "&About..."
      '
      '_miPageLast
      '
      Me._miPageLast.Index = 3
      Me._miPageLast.Text = "&Last"
      '
      '_sbMain
      '
      Me._sbMain.Location = New System.Drawing.Point(0, 387)
      Me._sbMain.Name = "_sbMain"
      Me._sbMain.Size = New System.Drawing.Size(608, 22)
      Me._sbMain.TabIndex = 3
      '
      '_miFileAcquire
      '
      Me._miFileAcquire.Index = 1
      Me._miFileAcquire.Text = "&Acquire..."
      '
      '_miFile
      '
      Me._miFile.Index = 0
      Me._miFile.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me._miFileSelectSource, Me._miFileAcquire, Me._miTwainAcquireCleanup, Me._miFileSep1, Me._miFileExit})
      Me._miFile.Text = "&File"
      '
      '_miFileSep1
      '
      Me._miFileSep1.Index = 3
      Me._miFileSep1.Text = "-"
      '
      '_miFileExit
      '
      Me._miFileExit.Index = 4
      Me._miFileExit.Text = "E&xit"
      '
      '_miPageNext
      '
      Me._miPageNext.Index = 2
      Me._miPageNext.Text = "&Next"
      '
      '_mmMain
      '
      Me._mmMain.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me._miFile, Me._miDocumentCleanup, Me._miPage, Me._miHelp})
      '
      '_miPage
      '
      Me._miPage.Index = 2
      Me._miPage.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me._miPageFirst, Me._miPagePrevious, Me._miPageNext, Me._miPageLast})
      Me._miPage.Text = "&Page"
      '
      '_miPageFirst
      '
      Me._miPageFirst.Index = 0
      Me._miPageFirst.Text = "&First"
      '
      '_miPagePrevious
      '
      Me._miPagePrevious.Index = 1
      Me._miPagePrevious.Text = "&Previous"
      '
      '_miTwainAcquireCleanup
      '
      Me._miTwainAcquireCleanup.Index = 2
      Me._miTwainAcquireCleanup.Text = "Acquire With &Cleanup"
      '
      '_miDocumentCleanup
      '
      Me._miDocumentCleanup.Index = 1
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
      'MainForm
      '
      Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
      Me.ClientSize = New System.Drawing.Size(608, 409)
      Me.Controls.Add(Me._sbMain)
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.Menu = Me._mmMain
      Me.Name = "MainForm"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "MainForm"
      Me.ResumeLayout(False)

   End Sub

#End Region

   ' the raster image viewer
   Private _viewer As ImageViewer

   ' the twain session used in acquiring
   Private _twainSession As TwainSession

   ' the raster codecs used in load\save
   Private _codecs As RasterCodecs

   ' save the output file name
   Private _fileName As String

   ' save the output file format
   Private _fileFormat As RasterImageFormat
   Private _bitsPerPixel As Integer

   ' save the no of pages acquired
   Private _pageNo As Integer

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

   ' <summary>
   ' Initialize the application
   ' </summary>
   Private Sub InitClass()
      ' setup our caption
      Messager.Caption = "LEADTOOLS for .NET VB Twain Multipage Demo"
      Text = Messager.Caption

      ' initialize the _viewer object
      _viewer = New ImageViewer
      _viewer.Dock = DockStyle.Fill
      _viewer.BackColor = Color.DarkGray
      Controls.Add(_viewer)
      _viewer.BringToFront()

      ' initialize the codecs object
      _codecs = New RasterCodecs

      If TwainSession.IsAvailable(Me.Handle) Then
         Try
            ' setup the Twain session object
            _twainSession = New TwainSession

            ' For 32-bit driver support in 64-bit applications, use the following TWAIN initialization method instead:
            '_twainSession.Startup(Me.Handle, "LEAD Technologies, Inc.", "LEAD Twain .NET", "Version 14", "LEADTools Twain test sample", TwainStartupFlags.UseThunkServer)

            ' start up the Twain session
            _twainSession.Startup(Me.Handle, "LEAD Technologies, Inc.", "LEAD Twain .NET", "Version 14", "LEADTools Twain test sample", TwainStartupFlags.None)
         Catch ex As TwainException
            If (ex.Code = TwainExceptionCode.InvalidDll) Then
               _twainSession = Nothing
               Messager.ShowError(Me, "You have an old version of TWAINDSM.DLL. Please download latest version of this DLL from www.twain.org")
               _miFileAcquire.Enabled = False
               _miTwainAcquireCleanup.Enabled = False
               _miFileSelectSource.Enabled = False
            Else
               _twainSession = Nothing
               Messager.ShowError(Me, ex)
               _miFileAcquire.Enabled = False
               _miTwainAcquireCleanup.Enabled = False
               _miFileSelectSource.Enabled = False
            End If

         Catch ex As Exception
            Messager.ShowError(Me, ex)
            _twainSession = Nothing
            _miFileAcquire.Enabled = False
            _miTwainAcquireCleanup.Enabled = False
            _miFileSelectSource.Enabled = False
         End Try
      Else
         _miFileAcquire.Enabled = False
         _miTwainAcquireCleanup.Enabled = False
         _miFileSelectSource.Enabled = False
      End If

      ' setup the other variables
      _fileName = String.Empty
      _fileFormat = RasterImageFormat.Tif
      _bitsPerPixel = 24
      _pageNo = 0

      UpdateMyControls()
      UpdateStatusBarText()
   End Sub

   Private Sub CleanUp()
      If (Not _twainSession Is Nothing) Then
         Try
            _twainSession.Shutdown()
         Catch ex As Exception
            Messager.ShowError(Me, ex)
         End Try
      End If
   End Sub

   ' <summary>
   ' Updates the UI depending on the program state
   ' </summary>
   Private Sub UpdateMyControls()
      ' update the menu items
      If (Not IsNothing(_viewer.Image)) Then
         _miPage.Enabled = True
         _miPage.Visible = True
         Dim page As Integer = _viewer.Image.Page
         _miPageFirst.Enabled = (page <> 1)
         _miPageFirst.Visible = True
         _miPagePrevious.Enabled = (page <> 1)
         _miPagePrevious.Visible = True
         _miPageNext.Enabled = (page <> _viewer.Image.PageCount)
         _miPageNext.Visible = True
         _miPageLast.Enabled = (page <> _viewer.Image.PageCount)
         _miPageLast.Visible = True
      Else
         _miPage.Enabled = False
         _miPage.Visible = False
         _miPageFirst.Enabled = False
         _miPageFirst.Visible = False
         _miPagePrevious.Enabled = False
         _miPagePrevious.Visible = False
         _miPageNext.Enabled = False
         _miPageNext.Visible = False
         _miPageLast.Enabled = False
         _miPageLast.Visible = False
         Text = Messager.Caption
      End If
   End Sub

   ' <summary>
   ' Updates the status bar text depending on the current page
   ' </summary>
   Private Sub UpdateStatusBarText()
      If (Not IsNothing(_viewer.Image)) Then
         _sbMain.Text = String.Format("Page {0}:{1}", _viewer.Image.Page, _viewer.Image.PageCount)
      Else
         _sbMain.Text = "Ready"
      End If
   End Sub

   ' <summary>
   ' Select Source to scan from
   ' </summary>
   Private Sub _miFileSelectSource_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _miFileSelectSource.Click
      Try
         _twainSession.SelectSource(String.Empty)
      Catch ex As Exception
         Messager.ShowError(Me, ex)
      End Try
   End Sub

   ' <summary>
   ' Acquire page event
   ' </summary>
   Private Sub _twain_AcquirePage(ByVal sender As Object, ByVal e As TwainAcquirePageEventArgs)
      Try
         If (Not IsNothing(e.Image)) Then
            If (_cleanupAfterAcquire) Then
               ApplyDocumentCleanupCommands(e.Image)
            End If

            ' Check if the required file format supports multi-page
            If ((_fileFormat = RasterImageFormat.Tif) OrElse _
               (_fileFormat = RasterImageFormat.Ccitt) OrElse _
               (_fileFormat = RasterImageFormat.CcittGroup31Dim) OrElse _
               (_fileFormat = RasterImageFormat.CcittGroup32Dim) OrElse _
               (_fileFormat = RasterImageFormat.CcittGroup4) OrElse _
               (_fileFormat = RasterImageFormat.TifCmp) OrElse _
               (_fileFormat = RasterImageFormat.TifCmw) OrElse _
               (_fileFormat = RasterImageFormat.TifCmyk) OrElse _
               (_fileFormat = RasterImageFormat.TifCustom) OrElse _
               (_fileFormat = RasterImageFormat.TifJ2k) OrElse _
               (_fileFormat = RasterImageFormat.TifJbig) OrElse _
               (_fileFormat = RasterImageFormat.TifJpeg) OrElse _
               (_fileFormat = RasterImageFormat.TifJpeg411) OrElse _
               (_fileFormat = RasterImageFormat.TifJpeg422) OrElse _
               (_fileFormat = RasterImageFormat.TifLead1Bit) OrElse _
               (_fileFormat = RasterImageFormat.TifLzw) OrElse _
               (_fileFormat = RasterImageFormat.TifLzwCmyk) OrElse _
               (_fileFormat = RasterImageFormat.TifLzwYcc) OrElse _
               (_fileFormat = RasterImageFormat.TifPackBits) OrElse _
               (_fileFormat = RasterImageFormat.TifPackBitsCmyk) OrElse _
               (_fileFormat = RasterImageFormat.TifPackbitsYcc) OrElse _
               (_fileFormat = RasterImageFormat.TifUnknown) OrElse _
               (_fileFormat = RasterImageFormat.TifYcc) OrElse _
               (_fileFormat = RasterImageFormat.Gif)) Then
               ' save the acquired page in multi-page file.
               _codecs.Save(e.Image, _fileName, _fileFormat, _bitsPerPixel, 1, 1, 1, CodecsSavePageMode.Append)
            Else ' we are trying to save each page in a separate file

               ' the extension of the file name
               Dim ext As String = String.Empty

               ' save the extension of the file name if it has one
               If (Path.HasExtension(_fileName)) Then
                  ext = Path.GetExtension(_fileName)
               End If
               ' save the file name with no indicates the page no.
               Dim tmpFileName As String = Path.GetFileNameWithoutExtension(_fileName)
               Dim tmpDirName As String = Path.GetDirectoryName(_fileName)
               Dim newFileName As String = String.Format("{0}\\{1}{2}{3}", tmpDirName, tmpFileName, _pageNo.ToString(), ext)

               _codecs.Save(e.Image, newFileName, _fileFormat, _bitsPerPixel)
               ' increment the page count
               _pageNo += 1
            End If

            ' Add the acquired page to the viewer
            If (IsNothing(_viewer.Image)) Then
               _viewer.Image = e.Image
            Else
               _viewer.Image.AddPage(e.Image)
               _viewer.Image.Page = _viewer.Image.PageCount
            End If
         End If
      Catch ex As Exception
         Messager.ShowError(Me, ex)
      End Try
   End Sub

   ' <summary>
   ' Scan pages
   ' </summary>
   Private Sub _miFileAcquire_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _miFileAcquire.Click
      Acquire(False)
   End Sub

   ' <summary>
   ' Shutdown.
   ' </summary>
   Private Sub _miFileExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _miFileExit.Click
      Close()
   End Sub

   ' <summary>
   ' Handles Page menu
   ' </summary>
   Private Sub _miPage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _miPageFirst.Click, _miPagePrevious.Click, _miPageNext.Click, _miPageLast.Click
      Dim page As Integer = _viewer.Image.Page
      If (sender Is _miPageFirst) Then
         page = 1
      ElseIf (sender Is _miPagePrevious) Then
         page -= 1
      ElseIf (sender Is _miPageNext) Then
         page += 1
      ElseIf (sender Is _miPageLast) Then
         page = _viewer.Image.PageCount
      End If
      page = Math.Max(1, Math.Min(_viewer.Image.PageCount, page))

      If (page <> _viewer.Image.Page) Then
         _viewer.Image.Page = page
         UpdateMyControls()
         UpdateStatusBarText()
      End If
   End Sub

   ' <summary>
   ' Show the about dialog
   ' </summary>
   Private Sub _miHelpAbout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _miHelpAbout.Click
      Using aboutDialog As New AboutDialog("Twain Multipage", ProgrammingInterface.VB)
         aboutDialog.ShowDialog(Me)
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
         ' get the output file name and file format
         Dim dlg As New RasterSaveDialog(_codecs)

         dlg.Title = "File Acquire Path"
         dlg.AutoProcess = False
         dlg.EnableSizing = True
         dlg.FileFormatsList = New RasterSaveDialogFileFormatsList(RasterDialogFileFormatDataContent.Default)
         dlg.ShowFileOptionsBasicJ2kOptions = False
         dlg.ShowFileOptionsJ2kOptions = False
         dlg.ShowFileOptionsMultipage = False
         dlg.ShowFileOptionsProgressive = False
         dlg.ShowFileOptionsQualityFactor = False
         dlg.ShowFileOptionsStamp = False
         dlg.ShowHelp = False
         dlg.ShowOptions = False
         dlg.ShowQualityFactor = False

         If (dlg.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK) Then
            ' save the output file name
            _fileName = dlg.FileName

            ' save the output file format
            _fileFormat = dlg.Format
            _bitsPerPixel = dlg.BitsPerPixel

            Dim pathName As String = Path.GetDirectoryName(_fileName)
            If (Directory.Exists(pathName)) Then
               ' initialize the page counter
               _pageNo = 0

               ' Add the Acquire page event.
               AddHandler _twainSession.AcquirePage, AddressOf _twain_AcquirePage

               _cleanupAfterAcquire = cleanup

               If _cleanupAfterAcquire Then
                  ShowCleanUpMessage()
               End If

               ' Acquire pages
               _twainSession.Acquire(TwainUserInterfaceFlags.Show)
               ' Remove the Acquire page event.
               RemoveHandler _twainSession.AcquirePage, AddressOf _twain_AcquirePage
            Else
               Messager.ShowError(Me, "Invalid File Name")
            End If
         End If
      Catch ex As Exception
         Messager.ShowError(Me, ex)
      Finally
         UpdateMyControls()
         UpdateStatusBarText()
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

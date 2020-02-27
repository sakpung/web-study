' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports System.Drawing.Printing
Imports System.IO

Imports Leadtools.Demos
Imports Leadtools
Imports Leadtools.Codecs
Imports Leadtools.ImageProcessing
Imports Leadtools.ImageProcessing.Effects
Imports Leadtools.ImageProcessing.Color
Imports Leadtools.ImageProcessing.Core
Imports Leadtools.Controls
Imports Leadtools.Wia
Imports Leadtools.Twain
Imports Leadtools.WinForms.CommonDialogs.Color
Imports Leadtools.Drawing
Imports Leadtools.Demos.Dialogs

Namespace DocumentCleanupDemo
   Partial Public Class MainForm : Inherits Form
      Private _codecs As RasterCodecs
      Private _fillColor As RasterColor

      Private _twainSession As TwainSession
      Private _inTwainAcquire As Boolean
      Private _acquirePageCount As Integer

      Private _wiaSession As WiaSession
      Private _wiaSourceSelected As Boolean
      Private _wiaAcquiring As Boolean
      Public _progressDlg As ProgressForm
      Public _wiaAcquireOptions As WiaAcquireOptions = WiaAcquireOptions.Empty

      Private _paintProperties As RasterPaintProperties
      Private _animateRegions As Boolean
      Private _rawdataLoad As RawData
      Private _rawdataSave As RawData
      Private Shared ReadOnly _minimumScaleFactor As Single = 0.05F
      Private Shared ReadOnly _maximumScaleFactor As Single = 11.0F
      Private _saver As ImageFileSaver
      Private _useDpi As Boolean = False
      Private _openInitialPath As String = ""

      ''' <summary>
      ''' The main entry point for the application.
      ''' </summary>
      <STAThread()> _
      Shared Sub Main()
         
         If Not Support.SetLicense() Then
            Return
         End If

         If RasterSupport.IsLocked(RasterSupportType.Document) Then
            MessageBox.Show("Document support must be unlocked for this demo!", "Support Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
         End If

         Application.EnableVisualStyles()
         Application.SetCompatibleTextRenderingDefault(False)
         Application.Run(New MainForm())
      End Sub

      Public Sub New()
         InitializeComponent()
         InitClass()
         _saver = New ImageFileSaver()
      End Sub

      Private Sub MainForm_Closing(ByVal sender As Object, ByVal e As CancelEventArgs) Handles MyBase.Closing
         If _inTwainAcquire Then
            e.Cancel = True
         End If
         CleanUp()
      End Sub

      Private Sub CleanUp()
         If Not _twainSession Is Nothing Then
            Try
               _twainSession.Shutdown()
            Catch ex As Exception
               Messager.ShowError(Me, ex)
            End Try
         End If

         If Not _wiaSession Is Nothing Then
            Try
               _wiaSession.Shutdown()
            Catch ex As Exception
               Messager.ShowError(Me, ex)
            End Try
         End If
      End Sub

      Private Sub InitClass()
         Messager.Caption = "LEADTOOLS For .Net VB Document CleanUp"
         Text = Messager.Caption

         '' initialize the codecs object
         _codecs = New RasterCodecs()
         _codecs.Options.Txt.Load.Enabled = False
         _fillColor = Leadtools.Demos.Converters.FromGdiPlusColor(Color.White)
         _paintProperties = RasterPaintProperties.Default
         _paintProperties.PaintDisplayMode = _paintProperties.PaintDisplayMode Or RasterPaintDisplayModeFlags.ScaleToGray
         _animateRegions = False
         _rawdataLoad = RawData.Default
         _rawdataSave = RawData.Default

         _wiaSourceSelected = False
         _wiaAcquiring = False

         Try
            Using wait As WaitCursor = New WaitCursor()
               '' Determine whether a TWAIN source is installed.  
               If TwainSession.IsAvailable(Me.Handle) Then
                  _twainSession = New TwainSession()
                  '' Start a TwainSession to acquire images from a Twain device.
                  '' This method must be called before calling any other methods that require a TWAIN session.
                  _twainSession.Startup(Me.Handle, "LEAD Technologies, Inc.", "LEAD Test Applications", "Version 1.0", "TWAIN Test Application", TwainStartupFlags.None)
                  AddHandler _twainSession.AcquirePage, AddressOf _twainSession_AcquirePage
               End If
            End Using
         Catch ex As Exception
            Messager.ShowError(Me, ex)
            _twainSession = Nothing
         End Try

         Try
            Using wait As WaitCursor = New WaitCursor()
               '' Determine whether a WIA source is installed.
               If WiaSession.IsAvailable(WiaVersion.Version1) Then
                  _wiaSession = New WiaSession()
                  '' Start a WiaSession to acquire images from a Wia device.
                  '' This method must be called before calling any other methods that require a WIA session.
                  _wiaSession.Startup(WiaVersion.Version1)
                  AddHandler _wiaSession.AcquireEvent, AddressOf _wiaSession_AcquireEvent
               End If
            End Using
         Catch ex As Exception
            Messager.ShowError(Me, ex)
            _wiaSession = Nothing
         End Try
      End Sub
      Private Sub _wiaSession_AcquireEvent(ByVal sender As Object, ByVal e As WiaAcquireEventArgs)
         '' This event occurs for each page acquired using the Acquire method.
         '' Update the progress bar with the received percent value;
         If _progressDlg.Visible Then
            If ((e.Flags And WiaAcquiredPageFlags.StartOfPage) = WiaAcquiredPageFlags.StartOfPage) AndAlso ((e.Flags And WiaAcquiredPageFlags.EndOfPage) <> WiaAcquiredPageFlags.EndOfPage) Then
               _progressDlg.Percent = 0
            Else
               _progressDlg.Percent = e.Percent
            End If

            Application.DoEvents()

            If _progressDlg.Abort Then
               e.Cancel = True
            End If
         End If

         If Not e.Image Is Nothing Then
            If _acquirePageCount = 1 Then
               NewImage(New ImageInformation(e.Image, "WIA Image"))
            Else
               ActiveViewerForm.Image.AddPage(e.Image)
            End If

            _acquirePageCount += 1
            Application.DoEvents()
         End If
      End Sub
      Private Sub _twainSession_AcquirePage(ByVal sender As Object, ByVal e As TwainAcquirePageEventArgs)
         '' This event occurs for each page acquired using the Acquire method.
         Application.DoEvents()

         If Not e.Image Is Nothing Then
            If _acquirePageCount = 1 Then
               NewImage(New ImageInformation(e.Image, "Twain Image"))
            Else
               ActiveViewerForm.Image.AddPage(e.Image)
            End If

            _acquirePageCount += 1
         End If
      End Sub
      Private Sub _menuItemFileOpen_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _menuItemFileOpen.Click
         LoadImage(False)
         UpdateMenus()
      End Sub

      Private Sub UpdateMenus()
         _menuItemDocument.Enabled = False

         If Not ActiveViewerForm Is Nothing Then
            _menuItemFileSave.Enabled = True
            editToolStripMenuItem.Enabled = True
            vToolStripMenuItem.Enabled = True
            imageToolStripMenuItem.Enabled = True
            _menuItemFileSaveRaw.Enabled = True
            _menuItemEditCopy.Enabled = True
            _menuItemEditRegion.Enabled = True
            _menuItemEditCancelRegion.Enabled = ActiveViewerForm.Viewer.Image.HasRegion

            If ActiveViewerForm.Viewer.Image.BitsPerPixel = 1 Then
               _menuItemDocument.Enabled = True
            End If
         Else
            _menuItemFileSave.Enabled = False
            vToolStripMenuItem.Enabled = False
            imageToolStripMenuItem.Enabled = False
            _menuItemDocument.Enabled = False
            _menuItemFileSaveRaw.Enabled = False
            _menuItemEditCopy.Enabled = False
            _menuItemEditCancelRegion.Enabled = False
            _menuItemEditRegion.Enabled = False
         End If

         Dim image As RasterImage = RasterClipboard.Paste(Me.Handle)
         If Not image Is Nothing Then
            _menuItemEditPaste.Enabled = True
         Else
            _menuItemEditPaste.Enabled = False
         End If

         _menuItemFileWiaSelectSource.Enabled = (Not _wiaSession Is Nothing AndAlso (Not _wiaAcquiring))
         _menuItemFileWiaAcquire.Enabled = (Not _wiaSession Is Nothing AndAlso _wiaSourceSelected AndAlso (Not _wiaAcquiring))

         EnableAndVisibleMenu(_menuItemFileTwainSelectSource, Not _twainSession Is Nothing)
         EnableAndVisibleMenu(_menuItemFileTwainAcquire, Not _twainSession Is Nothing)
         toolStripSeparator2.Visible = Not _twainSession Is Nothing
      End Sub

      Private Sub EnableAndVisibleMenu(ByVal menu As ToolStripMenuItem, ByVal value As Boolean)
         menu.Enabled = value
         menu.Visible = value
      End Sub
      Private Sub NewImage(ByVal info As ImageInformation)
         Dim child As ViewerForm = New ViewerForm()
         child.MdiParent = Me
         child.Viewer.Dock = DockStyle.Fill
         child.Initialize(info, _paintProperties, _animateRegions, True, _useDpi)
         child.Viewer.Zoom(ControlSizeMode.Fit, 1, LeadPoint.Empty)
         AddHandler child.Disposed, AddressOf child_Disposed
         AddHandler child.Viewer.PropertyChanged, AddressOf Viewer_PropertyChanged

         child.Show()
      End Sub

      Private Sub Viewer_PropertyChanged(sender As Object, e As PropertyChangedEventArgs)
         If (e.PropertyName = "WorkingInteractiveMode") Then
            UpdateMenus()
         End If
      End Sub

      Private Sub child_Disposed(ByVal sender As Object, ByVal e As EventArgs)
         UpdateMenus()
      End Sub

      Private Sub LoadImage(ByVal loadDefaultImage As Boolean)
         '' Load a defualt image on the viewer
         Dim loader As ImageFileLoader = New ImageFileLoader()
         loader.OpenDialogInitialPath = _openInitialPath
         Try
            If loadDefaultImage Then
               If loader.Load(Me, DemosGlobal.ImagesFolder & "\clean.tif", _codecs, 1, 1) Then
                  NewImage(New ImageInformation(loader.Image, loader.FileName))
               End If
            Else
               If loader.Load(Me, _codecs, True) > 0 Then
                  _openInitialPath = Path.GetDirectoryName(loader.FileName)
                  NewImage(New ImageInformation(loader.Image, loader.FileName))
               End If
            End If
         Catch ex As Exception
            Messager.ShowFileOpenError(Me, loader.FileName, ex)
         End Try
      End Sub

      Private Sub Form1_MdiChildActivate(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.MdiChildActivate
         Dim activeForm As ViewerForm = ActiveViewerForm
         UpdateMenus()
      End Sub

      Public ReadOnly Property ActiveViewerForm() As ViewerForm
         Get
            Return CType(ActiveMdiChild, ViewerForm)
         End Get
      End Property

      Private Sub _menuItemFileSave_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _menuItemFileSave.Click
         Try
            DemosGlobal.SetDefaultComments(ActiveViewerForm.Viewer.Image, _codecs)
            _saver.Save(Me, _codecs, ActiveViewerForm.Viewer.Image)
         Catch ex As Exception
            Messager.ShowFileSaveError(Me, _saver.FileName, ex)
         End Try
      End Sub

      Private Sub _menuItemCleanupLineRemove_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _menuItemCleanupLineRemove.Click
         Try
            Dim _LineRemove As LineRemoveCommand = Nothing
            Dim dlg As LineRemoveDialog = New LineRemoveDialog(New LineRemoveCommand(), ActiveViewerForm.Viewer.Image.XResolution, ActiveViewerForm.Viewer.Image.YResolution)
            '' Open the LineRemoveCommand dialog
            If dlg.ShowDialog() = Windows.Forms.DialogResult.OK Then
               _LineRemove = New LineRemoveCommand()
               AddHandler _LineRemove.Progress, AddressOf Command_Progress
               '' Update the LineRemoveCommand.Type to select which lines to remove
               _LineRemove.Type = dlg.LineRemoveCommand.Type
               '' Update the LineRemoveCommand UseDpi flag 
               _LineRemove.Flags = dlg.LineRemoveCommand.Flags
               '' Update the LineRemoveCommand.GapLength to set the maximum length of a break or a hole in a line.
               _LineRemove.GapLength = dlg.LineRemoveCommand.GapLength
               '' Update the LineRemoveCommand.MaximumLineWidth to set the maximum average width of a line that is considered for removal.   
               _LineRemove.MaximumLineWidth = dlg.LineRemoveCommand.MaximumLineWidth
               '' Update the LineRemoveCommand.MinimumLineLength to set the minimum length of a line considered for removal.   
               _LineRemove.MinimumLineLength = dlg.LineRemoveCommand.MinimumLineLength
               '' Update the LineRemoveCommand.MaximumWallPercent to set the maximum number of wall slices (expressed as a percent of the total length of the line) that are allowed.   
               _LineRemove.MaximumWallPercent = dlg.LineRemoveCommand.MaximumWallPercent
               '' Update LineRemoveCommand.Wall to set the height of a wall. Walls are slices of a line that are too wide to be considered part of the line. 
               _LineRemove.Wall = dlg.LineRemoveCommand.Wall
               ProgressBar.Visible = True
               '' Run the command on the loaded image
               _LineRemove.Run(ActiveViewerForm.Viewer.Image)
            End If

         Catch ex As RasterException
            Messager.ShowError(Me, ex)
         End Try
      End Sub

      Private Sub dotRemoveToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles dotRemoveToolStripMenuItem.Click
         Try
            Dim _DotRemove As DotRemoveCommand = Nothing

            Dim dlg As DotRemoveDialog = New DotRemoveDialog(New DotRemoveCommand(), ActiveViewerForm.Viewer.Image.XResolution, ActiveViewerForm.Viewer.Image.YResolution)
            '' Open the DotRemoveCommand Dialog
            If dlg.ShowDialog() = Windows.Forms.DialogResult.OK Then
               _DotRemove = New DotRemoveCommand()
               AddHandler _DotRemove.Progress, AddressOf Command_Progress
               '' Update the flags used to determine how to run this command
               _DotRemove.Flags = dlg.DotRemoveCommand.Flags
               '' Update the DotRemoveCommand.MaximumDotHeight to set the maximum height of a dot to be removed.
               _DotRemove.MaximumDotHeight = dlg.DotRemoveCommand.MaximumDotHeight
               '' Update the DotRemoveCommand.MaximumDotWidth to set the maximum width of a dot to be removed.
               _DotRemove.MaximumDotWidth = dlg.DotRemoveCommand.MaximumDotWidth
               '' Update the DotRemoveCommand.MinimumDotHeight to set the minimum height of a dot to be removed.
               _DotRemove.MinimumDotHeight = dlg.DotRemoveCommand.MinimumDotHeight
               '' Update the DotRemoveCommand.MinimumDotWidth to set the minimum width of a dot to be removed.
               _DotRemove.MinimumDotWidth = dlg.DotRemoveCommand.MinimumDotWidth
               ProgressBar.Visible = True
               '' Run the command on the loaded image
               _DotRemove.Run(ActiveViewerForm.Viewer.Image)
            End If

         Catch ex As RasterException
            Messager.ShowError(Me, ex)
         End Try

      End Sub

      Private Sub _menuItemCleanupHolePunchRemove_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _menuItemCleanupHolePunchRemove.Click
         Try
            Dim _HolePunchRemove As HolePunchRemoveCommand = Nothing

            Dim dlg As HolePunchRemoveDialog = New HolePunchRemoveDialog()
            '' Open HolePunchRemoveCommand Dialog
            If dlg.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
               _HolePunchRemove = New HolePunchRemoveCommand()
               AddHandler _HolePunchRemove.Progress, AddressOf Command_Progress
               '' Update the HolePunchRemoveCommand flags that determine how to process it
               _HolePunchRemove.Flags = dlg.Flags
               '' Update the HolePunchRemoveCommand.Location that indicates the location within the document of the hole punches to remove.
               _HolePunchRemove.Location = dlg.HoleLocation
               '' Update the HolePunchRemoveCommand.MaximumHoleCount to set the maximum number of holes to detect.
               _HolePunchRemove.MaximumHoleCount = dlg.MaxCount
               '' Update the HolePunchRemoveCommand.MinimumHoleCount to set the minimum number of holes to detect.
               _HolePunchRemove.MinimumHoleCount = dlg.MinCount
               '' Update the HolePunchRemoveCommand.MaximumHoleWidth to set the maximum width of one of the holes of the hole punch configuration to be removed.
               _HolePunchRemove.MaximumHoleWidth = dlg.MaxWidth
               '' Update the HolePunchRemoveCommand.MaximumHoleHeight to set the maximum height of one of the holes of the hole punch configuration to be removed.
               _HolePunchRemove.MaximumHoleHeight = dlg.MaxHeight
               '' Update the HolePunchRemoveCommand.MinimumHoleHeight to set the minimum height of one of the holes of the hole punch configuration to be removed.
               _HolePunchRemove.MinimumHoleWidth = dlg.MinWidth
               '' Update the HolePunchRemoveCommand.MinimumHoleWidth to set the minimum width of one of the holes of the hole punch configuration to be removed.
               _HolePunchRemove.MinimumHoleHeight = dlg.MinHeight
               ProgressBar.Visible = True
               '' Run the HolePunchRemoveCommand on the loaded image
               _HolePunchRemove.Run(ActiveViewerForm.Viewer.Image)
            End If

         Catch ex As RasterException
            Messager.ShowError(Me, ex)
         End Try

      End Sub
      Private Sub Command_Progress(ByVal sender As Object, ByVal e As RasterCommandProgressEventArgs)
         ProgressBar.Value = e.Percent
         If e.Percent = 100 Then
            ProgressBar.Visible = False
         End If
      End Sub
      Private Sub borderRemoveToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles borderRemoveToolStripMenuItem.Click
         Try
            Dim _BorderRemove As BorderRemoveCommand = Nothing

            Dim dlg As BorderRemoveDialog = New BorderRemoveDialog(New BorderRemoveCommand())
            '' Open BorderRemove Dialog
            If dlg.ShowDialog() = Windows.Forms.DialogResult.OK Then
               _BorderRemove = New BorderRemoveCommand()
               AddHandler _BorderRemove.Progress, AddressOf Command_Progress
               '' Update the BorderRemoveCommand.Border Flag to indicate which border to remove.
               _BorderRemove.Border = dlg.BorderRemoveCommand.Border
               '' Update the BorderRemoveCommand.Flags to determine the behavior of the border removal process.
               _BorderRemove.Flags = dlg.BorderRemoveCommand.Flags
               '' Update the BorderRemoveCommand.Percent to set the percent of the image dimension in which the border will be found.
               _BorderRemove.Percent = dlg.BorderRemoveCommand.Percent
               '' Update BorderRemoveCommand.Variance to set the amount of variance tolerated in the border.  
               _BorderRemove.Variance = dlg.BorderRemoveCommand.Variance
               '' Update the BorderRemoveCommand.WhiteNoiseLength to set the amount of white noise tolerated when determining the border.
               _BorderRemove.WhiteNoiseLength = dlg.BorderRemoveCommand.WhiteNoiseLength
               ProgressBar.Visible = True
               '' Run the BorderRemoveCommand on the loaded image
               _BorderRemove.Run(ActiveViewerForm.Viewer.Image)

            End If

         Catch ex As RasterException
            Messager.ShowError(Me, ex)
         End Try
      End Sub

      Private Sub characterSmoothToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles characterSmoothToolStripMenuItem.Click
         Try
            '' Create an instance for the SmoothCommand Class
            Dim _Smooth As SmoothCommand = Nothing
            '' Open the SmoothCommand dialog
            Dim dlg As SmoothTextDialog = New SmoothTextDialog(New SmoothCommand())
            If dlg.ShowDialog() = Windows.Forms.DialogResult.OK Then
               _Smooth = New SmoothCommand()
               AddHandler _Smooth.Progress, AddressOf Command_Progress
               '' Update the command with selected flags value SmoothCommandFlags.FavorLong or SmoothCommandFlags.FavorShor
               _Smooth.Flags = dlg.SmoothCommand.Flags
               '' Update the SmoothCommand.Length property
               If dlg.SmoothCommand.Length = 0 Then
                  _Smooth.Length = 1
               Else
                  _Smooth.Length = dlg.SmoothCommand.Length
               End If

               ProgressBar.Visible = True
               '' Apply the command on the loaded image
               _Smooth.Run(ActiveViewerForm.Viewer.Image)
            End If
         Catch ex As RasterException
            Messager.ShowError(Me, ex)
         End Try
      End Sub

      Private Sub _menuItemFileTwainSelectSource_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _menuItemFileTwainSelectSource.Click
         '' Display the TWAIN dialog box to be used to select a TWAIN source for acquiring images
         _inTwainAcquire = True
         Try
            If Not _twainSession Is Nothing Then
               _twainSession.SelectSource(Nothing)
            End If
         Catch ex As Exception
            Messager.ShowError(Me, ex)
         End Try
         _inTwainAcquire = False
      End Sub

      Private Sub _menuItemFileTwainAcquire_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _menuItemFileTwainAcquire.Click
         '' Acquire one or more images from a TWAIN source.
         _inTwainAcquire = True
         _acquirePageCount = 1

         Try
            If Not _twainSession Is Nothing Then
               If (Not DemosGlobal.CheckKnown3rdPartyTwainIssues(Me, _twainSession.SelectedSourceName())) Then
                  Return
               End If
               Dim res As DialogResult = _twainSession.Acquire(TwainUserInterfaceFlags.Modal Or TwainUserInterfaceFlags.Show)
            End If
         Catch ex As Exception
            If TypeOf ex Is TwainException Then
               Dim twnEx As TwainException = TryCast(ex, TwainException)
               If Not twnEx.Code = TwainExceptionCode.OperationError Then
                  Messager.ShowError(Me, ex)
               End If
            Else
               Messager.ShowError(Me, ex)
            End If
         Finally
            _acquirePageCount = -1
            _inTwainAcquire = False
         End Try
      End Sub

      Private Sub _menuItemFileWiaSelectSource_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _menuItemFileWiaSelectSource.Click
         '' Display the WIA dialog box to be used to select a WIA source for acquiring images.
         Try
            If Not _wiaSession Is Nothing Then
               Dim res As DialogResult = _wiaSession.SelectDeviceDlg(Me.Handle, WiaDeviceType.Default, WiaSelectSourceFlags.NoDefault)
               If res = Windows.Forms.DialogResult.OK Then
                  _wiaSourceSelected = True
               End If
            End If

            UpdateMenus()
         Catch ex As Exception
            Messager.ShowError(Me, ex)
            _wiaSourceSelected = False
         End Try
      End Sub

      Private Sub _menuItemFileWiaAcquire_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _menuItemFileWiaAcquire.Click
         '' Acquire one or more images from a WIA source.
         Try
            _wiaAcquiring = True
            _acquirePageCount = 1

            ' Disable the minimize and maximize buttons.
            Me.MinimizeBox = False
            Me.MaximizeBox = False

            If _wiaSession.SelectedDeviceType <> WiaDeviceType.Scanner Then
               _wiaAcquireOptions.FileName = "C:\WiaTest.jpg"
               _wiaSession.AcquireOptions = _wiaAcquireOptions
            End If

            Me._mainMenu.Enabled = False

            _progressDlg = New ProgressForm("Transferring...", "", 100)
            _progressDlg.Show(Me)

            _wiaSession.Acquire(Me.Handle, Nothing, WiaAcquireFlags.ShowUserInterface Or WiaAcquireFlags.UseCommonUI)

            Me._mainMenu.Enabled = True

            ' Enable back the minimize and maximize buttons.
            Me.MinimizeBox = True
            Me.MaximizeBox = True

            If _progressDlg.Visible Then
               If (Not _progressDlg.Abort) Then
                  _progressDlg.Dispose()
               End If
            End If

            If _wiaSession.FilesCount > 0 Then ' This property indicates how many files where saved when the transfer mode is File mode.
               Dim strMsg As String = "Acquired page(s) were saved to:" & Chr(13) + Chr(13)
               If _wiaSession.FilesPaths.Count > 0 Then
                  Dim i As Integer = 0
                  Do While i < _wiaSession.FilesPaths.Count
                     Dim strTemp As String = String.Format("{0}" & Chr(13), _wiaSession.FilesPaths(i))
                     strMsg &= strTemp
                     i += 1
                  Loop
                  MessageBox.Show(Me, strMsg, "File Transfer", MessageBoxButtons.OK, MessageBoxIcon.Information)
               End If
            End If

            _wiaAcquiring = False

            UpdateMenus()
         Catch ex As Exception
            Me._mainMenu.Enabled = True

            ' Enable back the minimize and maximize buttons.
            Me.MinimizeBox = True
            Me.MaximizeBox = True

            _wiaAcquiring = False

            If _progressDlg.Visible Then
               If (Not _progressDlg.Abort) Then
                  _progressDlg.Dispose()
               End If
            End If

            Messager.ShowError(Me, ex)
         Finally
            _acquirePageCount = -1
            UpdateMenus()
         End Try
      End Sub

      Private Sub _menuItemFileExit_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _menuItemFileExit.Click
         Close()
      End Sub

      Private Sub _menuItemCleanupInvertedText_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _menuItemCleanupInvertedText.Click
         Try
            Dim _InvertedText As InvertedTextCommand = Nothing

            Dim dlg As InvertedTextDialog = New InvertedTextDialog(New InvertedTextCommand(), ActiveViewerForm.Viewer.Image.XResolution, ActiveViewerForm.Viewer.Image.YResolution)
            '' Open the InvertedText dialog
            If dlg.ShowDialog() = Windows.Forms.DialogResult.OK Then
               _InvertedText = New InvertedTextCommand()
               AddHandler _InvertedText.Progress, AddressOf Command_Progress
               '' Update the InvertedTextCommand.Flags to determine how this command will process.
               _InvertedText.Flags = dlg.InvertedTextCommand.Flags
               '' Update the InvertedTextCommand.MaximumBlackPercent to set the maximum percent of total pixels in an inverted text area that must be black.
               _InvertedText.MaximumBlackPercent = dlg.InvertedTextCommand.MaximumBlackPercent
               '' Update the InvertedTextCommand.MinimumBlackPercent to set the minimum percent of total pixels in an inverted text area that must be black.
               _InvertedText.MinimumBlackPercent = dlg.InvertedTextCommand.MinimumBlackPercent
               '' Update the InvertedTextCommand.MinimumInvertHeight to set the minimum height of an area that is considered to be inverted text.
               _InvertedText.MinimumInvertHeight = dlg.InvertedTextCommand.MinimumInvertHeight
               '' InvertedTextCommand.MinimumInvertWidth to set the minimum Width of an area that is considered to be inverted text.
               _InvertedText.MinimumInvertWidth = dlg.InvertedTextCommand.MinimumInvertWidth

               ProgressBar.Visible = True
               '' Run the command on the loaded image
               _InvertedText.Run(ActiveViewerForm.Viewer.Image)
            End If
         Catch ex As RasterException
            Messager.ShowError(Me, ex)
         End Try
      End Sub

      Private Sub _menuItemCleanupDeskew_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _menuItemCleanupDeskew.Click
         Try
            Dim _Deskew As DeskewCommand = Nothing

            Dim dlg As DeskewDialog = New DeskewDialog(New DeskewCommand())
            '' Open the DeskewCommand dialog
            If dlg.ShowDialog() = Windows.Forms.DialogResult.OK Then
               _Deskew = New DeskewCommand()
               AddHandler _Deskew.Progress, AddressOf Command_Progress
               '' Update the DeskewCommandFlags, these flags will indicate whether to deskew the image, which background color to use, whether to deskew the image if the skew angle is very small, which type of interpolation to use, whether the image contains mostly text, and whether to use normal or fast rotation. 
               _Deskew.Flags = dlg.DeskewCommand.Flags
               '' Update the DeskewCommandFlags.FillExposedArea to fill areas exposed by rotation using the FillColor property
               _Deskew.FillColor = dlg.DeskewCommand.FillColor
               ProgressBar.Visible = True
               '' Run the DeskewCommand on the loaded image
               _Deskew.Run(ActiveViewerForm.Viewer.Image)
            End If
         Catch ex As RasterException
            Messager.ShowError(Me, ex)
         End Try
      End Sub

      Private Sub _menuItemCleanupDespeckle_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _menuItemCleanupDespeckle.Click
         Try
            Dim _Despeckle As DespeckleCommand = New DespeckleCommand()
            '' Remove speckles from the image.
            AddHandler _Despeckle.Progress, AddressOf Command_Progress
            ProgressBar.Visible = True
            '' Run the DespeckleCommand on the loaded image.
            _Despeckle.Run(ActiveViewerForm.Viewer.Image)
         Catch ex As RasterException
            Messager.ShowError(Me, ex)
         End Try

      End Sub

      Private Sub _menuItemCleanupInverte_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _menuItemCleanupInverte.Click
         Dim _Invert As InvertCommand = New InvertCommand()
         '' Invert the colors of the image.
         AddHandler _Invert.Progress, AddressOf Command_Progress
         ProgressBar.Visible = True
         '' Run the InvertCommand on the loaded image.
         _Invert.Run(ActiveViewerForm.Viewer.Image)

      End Sub

      Private Sub _menuItemCleanupfillWhite_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _menuItemCleanupfillWhite.Click
         '' Fill the image with White color. 
         Dim command As FillCommand = New FillCommand()
         command.Color = New RasterColor(255, 255, 255)

         AddHandler command.Progress, AddressOf Command_Progress
         ProgressBar.Visible = True
         '' Run the FillCommand on the loaded image.
         command.Run(ActiveViewerForm.Viewer.Image)
      End Sub

      Private Sub _menuItemCleanupfillBlack_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _menuItemCleanupfillBlack.Click
         '' Fill the image with black color. 
         Dim command As FillCommand = New FillCommand()
         command.Color = New RasterColor(0, 0, 0)

         AddHandler command.Progress, AddressOf Command_Progress
         ProgressBar.Visible = True
         '' Run the FillCommand on the loaded image.
         command.Run(ActiveViewerForm.Viewer.Image)
      End Sub

      Private Sub _menuItemCleanupDilate_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _menuItemCleanupDilate.Click
         '' Apply the Minimum filter using MinimumCommand. 
         Dim command As MinimumCommand = New MinimumCommand()
         '' Update the MinimumCommand.Dimension property.
         command.Dimension = 3

         ProgressBar.Visible = True
         AddHandler command.Progress, AddressOf Command_Progress
         '' Run the MinimumCommand on th eloaded image.
         command.Run(ActiveViewerForm.Viewer.Image)
      End Sub

      Private Sub _menuItemCleanupErode_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _menuItemCleanupErode.Click
         '' Apply the Maximum filter using MaximumCommand. 
         Dim command As MaximumCommand = New MaximumCommand()
         command.Dimension = 3

         AddHandler command.Progress, AddressOf Command_Progress
         ProgressBar.Visible = True
         '' Run the MaximumCommand on the loaded image.
         command.Run(ActiveViewerForm.Viewer.Image)
      End Sub

      Private Sub _menuItemImageRotateAnyAngle_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _menuItemImageRotateAnyAngle.Click
         '' Apply the RotateCommand.
         Dim _Rotate As RotateCommand = Nothing
         Dim dlg As RotateDialog = New RotateDialog()
         '' Open the Rotate dialog.
         If dlg.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
            '' Update the RotateCommand members.
            _Rotate = New RotateCommand(dlg.Angle, dlg.Flags, dlg.FillColor)
            '' Run the RotateCommand on the loaded image.
            _Rotate.Run(ActiveViewerForm.Viewer.Image)
         End If

      End Sub

      Private Sub _menuItemImageRotateRight90_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _menuItemImageRotateRight90.Click
         Dim _Rotate As RotateCommand = Nothing
         '' Run the RotateCommand on the loaded image with 90 degree angle to the right.
         _Rotate = New RotateCommand(90 * 100, RotateCommandFlags.Resize, Leadtools.Demos.Converters.FromGdiPlusColor(Color.Black))
         _Rotate.Run(ActiveViewerForm.Viewer.Image)

      End Sub

      Private Sub _menuItemImageRotateLeft90_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _menuItemImageRotateLeft90.Click
         Dim _Rotate As RotateCommand = Nothing
         '' Run the RotateCommand on the loaded image with 90 degree angle to the left.
         _Rotate = New RotateCommand(-90 * 100, RotateCommandFlags.Resize, Leadtools.Demos.Converters.FromGdiPlusColor(Color.Black))
         _Rotate.Run(ActiveViewerForm.Viewer.Image)
      End Sub

      Private Sub rotate180DegreesToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles rotate180DegreesToolStripMenuItem.Click
         Dim _Rotate As RotateCommand = Nothing
         '' Run the RotateCommand on the loaded image with 180 degree angle.
         _Rotate = New RotateCommand(180 * 100, RotateCommandFlags.Resize, Leadtools.Demos.Converters.FromGdiPlusColor(Color.Black))
         _Rotate.Run(ActiveViewerForm.Viewer.Image)
      End Sub

      Private Sub _menuItemImageflipHorizontal_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _menuItemImageflipHorizontal.Click
         ' Flip the image horizontally (reverse) 
         Dim cmd As FlipCommand = New FlipCommand()
         cmd.Horizontal = True
         cmd.Run(ActiveViewerForm.Viewer.Image)
      End Sub

      Private Sub _menuItemImagflipVerticalToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _menuItemImagflipVerticalToolStripMenuItem.Click
         ' Flip the image horizontally (reverse) 
         Dim cmd As FlipCommand = New FlipCommand()
         cmd.Horizontal = False
         cmd.Run(ActiveViewerForm.Viewer.Image)
      End Sub

      Private Sub _menuItemResize_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _menuItemResize.Click
         Dim _Resize As SizeCommand = Nothing

         Dim dlg As ResizeDialog = New ResizeDialog(ActiveViewerForm.Viewer.Image.Width, ActiveViewerForm.Viewer.Image.Height)
         '' Open the ResizeCommand dialog.
         If dlg.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
            '' Update the ResizeCommand members.
            _Resize = New SizeCommand(dlg.ImageWidth, dlg.ImageHeight, dlg.Flags)
            '' Run the ResizeCommand on the loaded image.
            _Resize.Run(ActiveViewerForm.Viewer.Image)
         End If
      End Sub

      Private Sub _menuItemEditCopy_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _menuItemEditCopy.Click
         Try
            Using wait As WaitCursor = New WaitCursor()
               '' Call the RasterClipboard.Copy to copy the loaded image to a clipboard.
               RasterClipboard.Copy(Me.Handle, ActiveViewerForm.Viewer.Image, RasterClipboardCopyFlags.Empty Or RasterClipboardCopyFlags.Dib Or RasterClipboardCopyFlags.Palette Or RasterClipboardCopyFlags.Region)

               UpdateMenus()

            End Using
         Catch ex As Exception
            Messager.ShowError(Me, ex)
         Finally
            UpdateMenus()
         End Try
      End Sub

      Private Sub _menuItemEditPaste_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _menuItemEditPaste.Click
         Try
            Using wait As WaitCursor = New WaitCursor()
               'Call the RasterClipboard.Paste to copy image data from the clipboard.
               Dim image As RasterImage = RasterClipboard.Paste(Me.Handle)
               If Not image Is Nothing Then
                  Dim activeForm As ViewerForm = ActiveViewerForm

                  If image.HasRegion AndAlso activeForm Is Nothing Then
                     image.MakeRegionEmpty()
                  End If
                  NewImage(New ImageInformation(image))
               End If
            End Using
         Catch ex As Exception
            Messager.ShowError(Me, ex)
         End Try

      End Sub

      Private Sub _menuItemEditRegionRectangle_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _menuItemEditRegionRectangle.Click
         If Not (ActiveViewerForm.regionInteractiveMode Is Nothing) Then
            ' Draw a Rectangular shaped region on the RasterImageViewer control.
            ActiveViewerForm.DisableInteractiveModes()
            ActiveViewerForm.regionInteractiveMode.Shape = ImageViewerRubberBandShape.Rectangle 'change the shape to rectangle            
            ActiveViewerForm.Viewer.InteractiveModes.EnableById(ActiveViewerForm.regionInteractiveMode.Id)
         End If
      End Sub

      Private Sub _menuItemEditRegionEllipse_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _menuItemEditRegionEllipse.Click
         If Not (ActiveViewerForm.regionInteractiveMode Is Nothing) Then
            ' Draw an Elliptical shaped region on the RasterImageViewer control.
            ActiveViewerForm.DisableInteractiveModes()
            ActiveViewerForm.regionInteractiveMode.Shape = ImageViewerRubberBandShape.Ellipse 'change the shape to Ellipse            
            ActiveViewerForm.Viewer.InteractiveModes.EnableById(ActiveViewerForm.regionInteractiveMode.Id)
         End If
      End Sub

      Private Sub _menuItemEditRegionFreehand_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _menuItemEditRegionFreehand.Click
         If Not (ActiveViewerForm.regionInteractiveMode Is Nothing) Then
            ' Draw an Freehand shaped region on the RasterImageViewer control.
            ActiveViewerForm.DisableInteractiveModes()
            ActiveViewerForm.regionInteractiveMode.Shape = ImageViewerRubberBandShape.Freehand 'change the shape to Freehand            
            ActiveViewerForm.Viewer.InteractiveModes.EnableById(ActiveViewerForm.regionInteractiveMode.Id)
         End If
      End Sub

      Private Sub _menuItemEditCancelRegion_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _menuItemEditCancelRegion.Click
         CancelFloater()
      End Sub
      Private Sub CancelFloater()
         '' Delete drawn region.
         Try
            If ActiveViewerForm.Viewer.Image.HasRegion Then
               ActiveViewerForm.Viewer.Image.MakeRegionEmpty()
               ActiveViewerForm.Viewer.InteractiveModes.BeginUpdate()
               ActiveViewerForm.Viewer.InteractiveModes.Clear()
               ActiveViewerForm.Viewer.InteractiveModes.EndUpdate()
            End If
            UpdateMenus()
         Catch ex As Exception
            Messager.ShowError(Me, ex)
         End Try
      End Sub

      Private Sub _menuItemViewSizeModeNormal_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _menuItemViewSizeModeNormal.Click
         '' Display the loaded image with 100% Zoom.
         ActiveViewerForm.Viewer.BeginUpdate()
         ActiveViewerForm.Viewer.Zoom(ControlSizeMode.ActualSize, 1, LeadPoint.Empty)
         ActiveViewerForm.Viewer.EndUpdate()
      End Sub

      Private Sub _menuItemViewSizeModeStretch_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _menuItemViewSizeModeStretch.Click
         '' Display the loaded image setting the Width the Height to the same value of the viewer width and height without maintaining the aspect ratio.
         ActiveViewerForm.Viewer.BeginUpdate()
         ActiveViewerForm.Viewer.Zoom(ControlSizeMode.Stretch, 1, LeadPoint.Empty)
         ActiveViewerForm.Viewer.EndUpdate()
      End Sub

      Private Sub _menuItemViewSizeModeFitAlways_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _menuItemViewSizeModeFitAlways.Click
         '' Display the loaded image setting the Width the Height to the same value of the viewer width and height maintaining the aspect ratio.
         ActiveViewerForm.Viewer.BeginUpdate()
         ActiveViewerForm.Viewer.Zoom(ControlSizeMode.FitAlways, 1, LeadPoint.Empty)
         ActiveViewerForm.Viewer.EndUpdate()
      End Sub

      Private Sub _menuItemViewSizeModeFitWidth_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _menuItemViewSizeModeFitWidth.Click
         '' Display the loaded image setting the Width to the same value of the viewer width.
         ActiveViewerForm.Viewer.BeginUpdate()
         ActiveViewerForm.Viewer.Zoom(ControlSizeMode.FitWidth, 1, LeadPoint.Empty)
         ActiveViewerForm.Viewer.EndUpdate()
      End Sub

      Private Sub _menuItemViewSizeModeFit_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _menuItemViewSizeModeFit.Click
         '' Display the loaded image with its original Width and height.
         ActiveViewerForm.Viewer.BeginUpdate()
         ActiveViewerForm.Viewer.Zoom(ControlSizeMode.Fit, 1, LeadPoint.Empty)
         ActiveViewerForm.Viewer.EndUpdate()
      End Sub

      Private Sub _menuItemViewSizeModeSnap_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _menuItemViewSizeModeSnap.Click
         ActiveViewerForm.Viewer.BeginUpdate()
         ActiveViewerForm.Snap()
         If ActiveViewerForm.WindowState <> FormWindowState.Normal Then
            ActiveViewerForm.WindowState = FormWindowState.Normal
         End If
         ActiveViewerForm.Viewer.Zoom(ActiveViewerForm.Viewer.SizeMode, 1, LeadPoint.Empty)
         ActiveViewerForm.Viewer.EndUpdate()
      End Sub

      Private Sub _menuItemViewAlignModeHorizontalNear_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _menuItemViewAlignModeHorizontalNear.Click
         '' Display the loaded image on the left Horizontal side of the viwere.
         ActiveViewerForm.Viewer.ViewHorizontalAlignment = ControlAlignment.Near
      End Sub

      Private Sub _menuItemViewAlignModeHorizontalCenter_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _menuItemViewAlignModeHorizontalCenter.Click
         '' Display the loaded image on the center Horizontal side of the viwere.
         ActiveViewerForm.Viewer.ViewHorizontalAlignment = ControlAlignment.Center
      End Sub

      Private Sub _menuItemViewAlignModeHorizontalFar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _menuItemViewAlignModeHorizontalFar.Click
         '' Display the loaded image on the right Horizontal side of the viwere.
         ActiveViewerForm.Viewer.ViewHorizontalAlignment = ControlAlignment.Far
      End Sub

      Private Sub _menuItemViewAlignModeVerticalNear_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _menuItemViewAlignModeVerticalNear.Click
         '' Display the loaded image on the top Vertical side of the viwere.
         ActiveViewerForm.Viewer.ViewVerticalAlignment = ControlAlignment.Near
      End Sub

      Private Sub _menuItemViewAlignModeVerticalCenter_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _menuItemViewAlignModeVerticalCenter.Click
         '' Display the loaded image on the center Vertical side of the viwere.
         ActiveViewerForm.Viewer.ViewVerticalAlignment = ControlAlignment.Center
      End Sub

      Private Sub _menuItemViewAlignModeVerticalFar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _menuItemViewAlignModeVerticalFar.Click
         '' Display the loaded image on the bottom Vertical side of the viwere.
         ActiveViewerForm.Viewer.ViewVerticalAlignment = ControlAlignment.Far
      End Sub

      Private Sub ViewZoom(ByVal zoom As Integer)
         Dim viewer As ImageViewer = ActiveViewerForm.Viewer ' get the active viewer

         ' zoom     
         Dim scaleFactor As Double = viewer.ScaleFactor
         Dim ratio As Single = 1.2F

         If (zoom = 1) Then
            scaleFactor *= ratio
         ElseIf (zoom = 2) Then
            scaleFactor /= ratio
         ElseIf (zoom = 3) Then
            scaleFactor = 1
         Else

            Dim dlg As ZoomDialog = New ZoomDialog()
            dlg.Value = CInt(scaleFactor * 100)
            dlg.MinimumValue = CInt(_minimumScaleFactor * 100.0F)
            dlg.MaximumValue = CInt(_maximumScaleFactor * 100.0F)

            If (dlg.ShowDialog(Me) = DialogResult.OK) Then
               scaleFactor = CSng(dlg.Value / 100.0F)
            End If
         End If

         scaleFactor = Math.Max(_minimumScaleFactor, Math.Min(_maximumScaleFactor, scaleFactor))

         If (viewer.ScaleFactor <> scaleFactor) Then
            viewer.Zoom(ControlSizeMode.None, scaleFactor, viewer.DefaultZoomOrigin)
         End If
         
      End Sub

      Private Sub _menuItemViewZoomIn_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _menuItemViewZoomIn.Click
         '' Display the image with increased zoom level.
         ViewZoom(1)
      End Sub

      Private Sub _menuItemViewZoomOut_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _menuItemViewZoomOut.Click
         '' Display the image with decreased zoom level.
         ViewZoom(2)
      End Sub

      Private Sub _menuItemViewZoomNormal_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _menuItemViewZoomNormal.Click
         '' Diaplay the image with 100% zoom level.
         ViewZoom(3)
      End Sub

      Private Sub _menuItemViewZoomValue_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _menuItemViewZoomValue.Click
         '' Display the image with custom zoom level (User specify the zoom level value).
         ViewZoom(4)
      End Sub

      Private Sub _menuItemImageColorResolution_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _menuItemImageColorResolution.Click
         Dim _ColorResolution As ColorResolutionCommand = Nothing

         Dim dlg As ColorResolutionDialog = New ColorResolutionDialog(New ColorResolutionCommand(), ActiveViewerForm.Viewer.Image.BitsPerPixel)
         '' Open the ColorResolution dialog.
         If dlg.ShowDialog() = Windows.Forms.DialogResult.OK Then
            _ColorResolution = New ColorResolutionCommand()
            AddHandler _ColorResolution.Progress, AddressOf Command_Progress
            '' Update the behaviour of the ColorResolutionCommand. 
            _ColorResolution.Mode = dlg.ColorResolutionCommand.Mode
            '' Update the ColorResolutionCommand.BitsPerPixel to set the number of bits per pixel for the conversion.
            _ColorResolution.BitsPerPixel = dlg.ColorResolutionCommand.BitsPerPixel
            '' Update the ColorResolutionCommand.Order to set the desired color byte order of the image data for the conversion.
            _ColorResolution.Order = dlg.ColorResolutionCommand.Order
            '' Update the ColorResolutionCommand.DitheringMethod to set the dithering options used when converted the image.
            _ColorResolution.DitheringMethod = dlg.ColorResolutionCommand.DitheringMethod
            '' Update the ColorResolutionCommand.PaletteFlags to set the Palette options used when converted the image.
            _ColorResolution.PaletteFlags = dlg.ColorResolutionCommand.PaletteFlags
            '' Run the ColorResolutionCommand on the loaded image.
            _ColorResolution.Run(ActiveViewerForm.Viewer.Image)
            UpdateMenus()

         End If
      End Sub

      Private Sub aboutToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles aboutToolStripMenuItem.Click
         Using aboutDialog As New AboutDialog("Document Cleanup", ProgrammingInterface.VB)
            aboutDialog.ShowDialog(Me)
         End Using
      End Sub

      Private Sub _menuItemFileOpenRaw_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _menuItemFileOpenRaw.Click
         Try
            Dim ofd As OpenFileDialog = New OpenFileDialog()
            ofd.Filter = "All Files (*.*)|*.*|RAW (*.raw)|*.raw|Fax (*.fax)|*.fax|ABIC (*.abic;*.abc)|*.abic;*.abc"
            ofd.FilterIndex = 1
            '' Open the Raw dialog.
            If ofd.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
               LoadRaw(ofd.FileName)
            End If
         Catch ex As Exception
            Messager.ShowError(Me, ex)
         End Try
      End Sub

      Private Sub LoadRaw(ByVal fileName As String)
         ' ' This part of the project shows how you can load Raw Data into LEADTOOLS
         Dim dlg As RawDialog = New RawDialog(True)
         dlg.CurrentRawData = _rawdataLoad
         If dlg.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
            Dim imageInfo As ImageInformation = New ImageInformation()
            imageInfo.Name = fileName
            _rawdataLoad = dlg.CurrentRawData

            Dim handler As EventHandler(Of CodecsLoadInformationEventArgs) = New EventHandler(Of CodecsLoadInformationEventArgs)(AddressOf codecs_LoadInformation)
            _codecs.Options.Load.Format = _rawdataLoad.Format
            AddHandler _codecs.LoadInformation, AddressOf codecs_LoadInformation


            Try
               Using wait As WaitCursor = New WaitCursor()
                  imageInfo.Image = _codecs.Load(fileName)
                  NewImage(imageInfo)
               End Using
            Catch ex As Exception
               MessageBox.Show("Invalid File Parameter " & ex.Message)
            Finally
               RemoveHandler _codecs.LoadInformation, handler
               _codecs.Options.Load.Format = RasterImageFormat.Unknown
            End Try
         End If
      End Sub

      Private Sub codecs_LoadInformation(ByVal sender As Object, ByVal e As CodecsLoadInformationEventArgs)
         ' Set the information for loading Raw Data 
         e.Format = _rawdataLoad.Format
         e.Width = _rawdataLoad.Width
         e.Height = _rawdataLoad.Height
         e.BitsPerPixel = _rawdataLoad.BitsPerPixel
         e.XResolution = _rawdataLoad.XResolution
         e.YResolution = _rawdataLoad.YResolution
         e.Offset = _rawdataLoad.Offset
         e.WhiteOnBlack = _rawdataLoad.WhiteOnBlack

         If _rawdataLoad.Padding Then
            e.Pad4 = True
         End If

         e.Order = _rawdataLoad.Order

         If _rawdataLoad.ReverseBits Then
            e.LeastSignificantBitFirst = True
         End If

         e.ViewPerspective = _rawdataLoad.ViewPerspective

         ' If image is palettized create a grayscale palette
         If _rawdataLoad.PaletteEnabled Then
            If e.BitsPerPixel <= 8 Then
               If (Not _rawdataLoad.FixedPalette) Then
                  Dim colors As Integer = 1 << e.BitsPerPixel
                  Dim palette As RasterColor() = New RasterColor(colors - 1) {}
                  Dim i As Integer = 0
                  Do While i < palette.Length
                     Dim val As Byte = CByte((i * 256) / colors)
                     palette(i) = New RasterColor(val, val, val)
                     i += 1
                  Loop

                  e.SetPalette(palette)
               Else
                  e.SetPalette(RasterPalette.Fixed(e.BitsPerPixel))
               End If
            End If
         End If
      End Sub

      Private Sub _menuItemFileSaveRaw_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _menuItemFileSaveRaw.Click
         Dim saver As ImageFileSaver = New ImageFileSaver()

         Try
            'CombineFloater();
            Dim sfd As SaveFileDialog = New SaveFileDialog()
            sfd.Filter = "RAW (*.raw)|*.raw|Fax (*.fax)|*.fax"
            sfd.FilterIndex = 1
            If sfd.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
               SaveRaw(sfd.FileName)
            End If
         Catch ex As Exception
            Messager.ShowFileSaveError(Me, saver.FileName, ex)
         End Try
      End Sub


      Private Sub SaveRaw(ByVal fileName As String)
         Dim activeForm As ViewerForm = ActiveViewerForm

         Dim dlg As RawDialog = New RawDialog(False)
         _rawdataSave.Width = activeForm.Viewer.Image.Width
         _rawdataSave.Height = activeForm.Viewer.Image.Height
         _rawdataSave.BitsPerPixel = activeForm.Viewer.Image.BitsPerPixel
         dlg.CurrentRawData = _rawdataSave
         If dlg.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
            Dim imageInfo As ImageInformation = New ImageInformation()
            _rawdataSave = dlg.CurrentRawData
            Try
               Using wait As WaitCursor = New WaitCursor()
                  ' Set RAW options
                  _codecs.Options.Raw.Save.Pad4 = _rawdataSave.Padding
                  _codecs.Options.Raw.Save.ReverseBits = _rawdataSave.ReverseBits
                  _codecs.Options.Save.OptimizedPalette = False
                  If _rawdataSave.Format = RasterImageFormat.Unknown Then
                     _rawdataSave.Format = RasterImageFormat.Raw
                  End If

                  Dim fs As FileStream = File.Create(fileName)
                  Using fs
                     _codecs.Save(activeForm.Viewer.Image, fs, _rawdataSave.Offset, _rawdataSave.Format, _rawdataSave.BitsPerPixel, 1, 1, 1, CodecsSavePageMode.Overwrite)
                     fs.Close()
                  End Using
               End Using
            Catch ex As Exception
               MessageBox.Show("Invalid File Parameter " & ex.Message)
            End Try
         End If
      End Sub

      Private Sub MainForm_FormClosing(ByVal sender As Object, ByVal e As FormClosingEventArgs)
         If _inTwainAcquire Then
            e.Cancel = True
         End If
      End Sub

      Private Sub MainForm_Activated(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Activated
         UpdateMenus()
      End Sub

      Private Sub MainForm_DragDrop(ByVal sender As Object, ByVal e As DragEventArgs) Handles MyBase.DragDrop
         If Tools.CanDrop(e.Data) Then
            Dim files As String() = Tools.GetDropFiles(e.Data)
            If Not files Is Nothing Then
               LoadDropFiles(Nothing, files)
            End If
         End If

      End Sub

      Public Sub LoadDropFiles(ByVal viewer As ViewerForm, ByVal files As String())
         '' Implementing Drop feature.
         Try
            If Not files Is Nothing Then
               Dim i As Integer = 0
               Do While i < files.Length
                  Try
                     Dim image As RasterImage = _codecs.Load(files(i))
                     Dim info As ImageInformation = New ImageInformation(image, files(i))
                     If i = 0 AndAlso Not viewer Is Nothing Then
                        viewer.Initialize(info, _paintProperties, _animateRegions, False, _useDpi)
                     Else
                        NewImage(info)
                     End If
                     UpdateMenus()
                  Catch ex As Exception
                     Messager.ShowFileOpenError(Me, files(i), ex)
                  End Try
                  i += 1
               Loop
            End If
         Catch ex As Exception
            Messager.ShowError(Me, ex)
         End Try
      End Sub
      Private Sub MainForm_DragEnter(ByVal sender As Object, ByVal e As DragEventArgs) Handles MyBase.DragEnter
         If Tools.CanDrop(e.Data) Then
            e.Effect = DragDropEffects.Copy
         End If
      End Sub

      Private Sub MainForm_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
         LoadImage(True)
         UpdateMenus()
      End Sub

      Private Sub rrrToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
         Clipboard.Clear()
         UpdateMenus()
      End Sub

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

         Return str
      End Function

      Private Sub _menuItemImagefillImage_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _menuItemImagefillImage.Click
         '' Use the FillCommand to fill the image with a specified color
         Dim command As FillCommand = New FillCommand()
         command.Color = New RasterColor(0, 0, 0)

         Dim dlg As ColorDialog = New ColorDialog()

         If dlg.ShowDialog() = Windows.Forms.DialogResult.OK Then
            command.Color = Leadtools.Demos.Converters.FromGdiPlusColor(dlg.Color)
            AddHandler command.Progress, AddressOf Command_Progress
            ProgressBar.Visible = True
            command.Run(ActiveViewerForm.Viewer.Image)
         End If

      End Sub

      Private Sub _menuItemMagGlassStart_Click(sender As System.Object, e As System.EventArgs) Handles _menuItemMagGlassStart.Click
         Dim activeForm As ViewerForm = CType(ActiveMdiChild, ViewerForm)
         activeForm.StartMagGlass()
         UpdateMenus()
      End Sub

      Private Sub _menuItemMagGlassStop_Click(sender As System.Object, e As System.EventArgs) Handles _menuItemMagGlassStop.Click
         Dim activeForm As ViewerForm = CType(ActiveMdiChild, ViewerForm)
         activeForm.StopMagGlass()
         UpdateMenus()
      End Sub

      Private Sub _menuItemHistogram_Click(sender As System.Object, e As System.EventArgs) Handles _menuItemHistogram.Click
         Dim activeForm As ViewerForm = CType(ActiveMdiChild, ViewerForm)
         ActiveForm.Histogram()
      End Sub
   End Class
End Namespace

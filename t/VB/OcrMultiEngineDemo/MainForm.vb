' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System.IO
Imports System.Text
Imports System.Drawing

Imports Leadtools
Imports Leadtools.Twain
Imports Leadtools.Codecs
Imports Leadtools.ImageProcessing
Imports Leadtools.ImageProcessing.Core
Imports Leadtools.ImageProcessing.Color
Imports Leadtools.ImageProcessing.Effects
Imports Leadtools.Ocr
Imports Leadtools.Document.Writer
Imports Leadtools.Controls
Imports Leadtools.Annotations.Engine
Imports OcrMultiEngineDemo.ViewerControl
Imports Leadtools.Demos.Dialogs
Imports Leadtools.Drawing

Public Class MainForm
   ' The RasterCodecs instance used to load/save images
   Private _rasterCodecs As RasterCodecs
   ' The OCR engine instance used in this demo
   Private _ocrEngine As IOcrEngine
   ' The current OCR document
   Private _ocrDocument As IOcrDocument
   ' The current OCR page in the viewer
   Private _ocrPage As IOcrPage
   ' View document on successful recognition
   Private _viewDocument As Boolean = True

   ' The twain session used for scanning
   Private _twainSession As TwainSession

   Private _filename As String
   Private _isCustomFileName As Boolean = False
   Private _outputDir As String = String.Empty

   Private _omrOptionsDismissed As Boolean
   Public Shared PerspectiveDeskewActive As Boolean = False
   Public Shared UnWarpActive As Boolean = False


   Public Sub New()

      ' This call is required by the Windows Form Designer.
      InitializeComponent()

      ' Add any initialization after the InitializeComponent() call.
      ' Setup the caption for this demo
      Messager.Caption = "VB OCR Multi-Engine Demo"

      ' Initialize the RasterCodecs object
      _rasterCodecs = New RasterCodecs()

      ' Use the new RasterizeDocumentOptions to default loading document files at 300 DPI
      _rasterCodecs.Options.RasterizeDocument.Load.XResolution = 300
      _rasterCodecs.Options.RasterizeDocument.Load.YResolution = 300
      _rasterCodecs.Options.Pdf.Load.EnableInterpolate = True
      _rasterCodecs.Options.Load.AutoFixImageResolution = True

      ' See if we have a scanning session
      If (TwainSession.IsAvailable(Me.Handle)) Then
         Try
            _twainSession = New TwainSession()
            _twainSession.Startup(Me.Handle, "LEAD Technologies, Inc.", "LEAD Test Applications", "Version 1.0", "TWAIN Test Application", TwainStartupFlags.None)
            AddHandler _twainSession.AcquirePage, AddressOf _twainSession_AcquirePage
         Catch ex As TwainException
            If (ex.Code = TwainExceptionCode.InvalidDll) Then
               _twainSession = Nothing
               Messager.ShowError(Me, "You have an old version of TWAINDSM.DLL. Please download latest version of this DLL from www.twain.org")
            Else
               _twainSession = Nothing
               Messager.ShowError(Me, ex)
            End If

         Catch ex As Exception
            Messager.ShowError(Me, ex)
            _twainSession = Nothing
         End Try
      End If

      _preferencesUseProgressBarsToolStripMenuItem.Checked = True

      _omrOptionsDismissed = False
   End Sub

   Protected Overrides Sub OnLoad(ByVal e As EventArgs)
      If (Not DesignMode) Then
         BeginInvoke(New MethodInvoker(AddressOf Startup))
      End If

      MyBase.OnLoad(e)
   End Sub

   Private Sub Startup()
      ' Show the OCR engine selection dialog to startup the OCR engine
      Dim engineType As String = My.Settings.OcrEngineType

      Using dlg As New OcrEngineSelectDialog(Messager.Caption, engineType, True)
         ' Use the same RasterCodecs instance in the OCR engine
         dlg.RasterCodecsInstance = _rasterCodecs

         If (dlg.ShowDialog(Me) = DialogResult.OK) Then
            _ocrEngine = dlg.OcrEngine
            Text = String.Format("{0} [{1} Engine]", Messager.Caption, _ocrEngine.EngineType.ToString())

            ' Load the default document
            Dim defaultDocumentFile As String
            If _ocrEngine.EngineType = OcrEngineType.OmniPageArabic Then
               defaultDocumentFile = Path.Combine(DemosGlobal.ImagesFolder, "ArabicSample.tif")
            Else
               defaultDocumentFile = Path.Combine(DemosGlobal.ImagesFolder, "ocr1.tif")
            End If

            UpdateActiveSpellCheckerLabel(If((_ocrEngine.SpellCheckManager IsNot Nothing), _ocrEngine.SpellCheckManager.SpellCheckEngine, OcrSpellCheckEngine.None))

            If (File.Exists(defaultDocumentFile)) Then
               OpenDocument(defaultDocumentFile, 1, -1)
            Else
               NewDocument("New Document")
            End If
         Else
            Close()
         End If
      End Using
   End Sub

   Protected Overrides Sub OnFormClosed(ByVal e As FormClosedEventArgs)
      ' Clean up

      ' Shutdown down if started
      If Not IsNothing(_twainSession) Then
         RemoveHandler _twainSession.AcquirePage, AddressOf _twainSession_AcquirePage
         _twainSession.Shutdown()
         _twainSession = Nothing
      End If

      ' Save the last setting
      If Not IsNothing(_ocrEngine) Then
         My.Settings.OcrEngineType = _ocrEngine.EngineType.ToString()
      End If

      My.Settings.Save()

      If Not IsNothing(_ocrDocument) Then
         _ocrDocument.Dispose()
         _ocrDocument = Nothing
      End If

      ' Dispose the OCR engine (this will call Shutdown as well)
      If Not IsNothing(_ocrEngine) Then
         _ocrEngine.Dispose()
         _ocrEngine = Nothing
      End If

      If Not IsNothing(_rasterCodecs) Then
         _rasterCodecs.Dispose()
         _rasterCodecs = Nothing
      End If

      MyBase.OnFormClosed(e)
   End Sub

   Private Sub _fileToolStripMenuItem_DropDownOpening(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _fileToolStripMenuItem.DropDownOpening
      ' Update the UI state of the File menu items

      Dim documentHasPages As Boolean = Not IsNothing(_ocrDocument) AndAlso (_ocrDocument.Pages.Count > 0)

      _fileCloseToolStripMenuItem.Enabled = documentHasPages

      If IsNothing(_twainSession) Then
         _fileScanToolStripMenuItem.Enabled = False
      End If
   End Sub

   Private Sub _fileOpenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _fileOpenToolStripMenuItem.Click
      OpenDocument()
   End Sub

   Private Sub _fileCloseToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _fileCloseToolStripMenuItem.Click
      ' Do the same as New document
      NewDocument("New Document")
   End Sub

   Private Sub _fileConvertLDToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _fileConvertLDToolStripMenuItem.Click
      ConvertLD()
   End Sub

   Private Sub _scanSelectSourceToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _scanSelectSourceToolStripMenuItem.Click
      ' Select the TWAIN source
      Try
         _twainSession.SelectSource(String.Empty)
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub _scanAcquireToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _scanAcquireToolStripMenuItem.Click
      ' Acquire the pages using TWAIN
      Try
         If (Not DemosGlobal.CheckKnown3rdPartyTwainIssues(Me, _twainSession.SelectedSourceName())) Then
            Return
         End If
         _twainSession.Acquire(TwainUserInterfaceFlags.Show)
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub _twainSession_AcquirePage(ByVal sender As Object, ByVal e As TwainAcquirePageEventArgs)
      ' Add the page to the OCR engine
      Try
         InsertPages(Nothing, -1, -1, e.Image, -1)
      Catch ex As Exception
         ShowError(ex)
         UpdateTimingLabel(Nothing, Nothing)
      End Try
   End Sub

   Private Sub _editToolStripMenuItem_DropDownOpening(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _editToolStripMenuItem.DropDownOpening
      ' Update the UI state of the Edit menu items

      Dim documentHasPages As Boolean = Not IsNothing(_ocrDocument) AndAlso (_ocrDocument.Pages.Count > 0)

      _editCopyToolStripMenuItem.Enabled = documentHasPages
      _editPasteToolStripMenuItem.Enabled = RasterClipboard.IsReady
   End Sub

   Private Sub _editCopyToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _editCopyToolStripMenuItem.Click
      ' Copy the current RasterImage to the clipboard
      Dim image As RasterImage = _viewerControl.RasterImage
      If Not IsNothing(image) Then
         Try
            Using wait As New WaitCursor()
               RasterClipboard.Copy( _
                  Me.Handle, _
                  image, _
                  RasterClipboardCopyFlags.Empty Or _
                  RasterClipboardCopyFlags.Dib Or _
                  RasterClipboardCopyFlags.Palette)
            End Using
         Catch ex As Exception
            ShowError(ex)
         End Try
      End If
   End Sub

   Private Sub _editPasteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _editPasteToolStripMenuItem.Click
      ' Paste the image in the clipboard (if any) as a new page in the current document

      If (RasterClipboard.IsReady) Then
         Try
            Using wait As New WaitCursor()
               Using image As RasterImage = RasterClipboard.Paste(Me.Handle)
                  InsertPages(Nothing, -1, -1, image, -1)
               End Using
            End Using
         Catch ex As Exception
            ShowError(ex)
            UpdateTimingLabel(Nothing, Nothing)
         End Try
      End If
   End Sub

   Private Sub _viewToolStripMenuItem_DropDownOpening(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _viewToolStripMenuItem.DropDownOpening
      ' Update the UI state of the View menu items

      Dim documentHasPages As Boolean = Not IsNothing(_ocrDocument) AndAlso (_ocrDocument.Pages.Count > 0)

      _viewZoomOutToolStripMenuItem.Enabled = documentHasPages
      _viewZoomInToolStripMenuItem.Enabled = documentHasPages

      _viewFitWidthToolStripMenuItem.Enabled = documentHasPages
      _viewFitPageToolStripMenuItem.Enabled = documentHasPages

      _viewFitWidthToolStripMenuItem.Checked = (_viewerControl.CurrentSizeMode = RasterPaintSizeMode.FitWidth)
      _viewFitPageToolStripMenuItem.Checked = (_viewerControl.CurrentSizeMode = RasterPaintSizeMode.Fit)
   End Sub

   Private Sub _viewZoomOutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _viewZoomOutToolStripMenuItem.Click
      _viewerControl.ZoomViewer(True)
   End Sub

   Private Sub _viewZoomInToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _viewZoomInToolStripMenuItem.Click
      _viewerControl.ZoomViewer(False)
   End Sub

   Private Sub _viewFitWidthToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _viewFitWidthToolStripMenuItem.Click
      _viewerControl.FitPage(True)
      _viewerControl.ZonesUpdated()
   End Sub

   Private Sub _viewFitPageToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _viewFitPageToolStripMenuItem.Click
      _viewerControl.FitPage(False)
   End Sub

   Private Sub _engineSettingsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _engineSettingsToolStripMenuItem.Click
      ' Show the dialog to let the user change any of the engine settings
      Using dlg As New EngineSettingsDialog(_ocrEngine)
         dlg.ShowDialog(Me)
      End Using
   End Sub

   Private Sub _engineComponentsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _engineComponentsToolStripMenuItem.Click
      ' Show the dialog to let the user see the OCR components installed on this system
      Using dlg As New OcrEngineComponentsDialog(_ocrEngine)
         dlg.ShowDialog(Me)
      End Using
   End Sub

   Private Sub _engineLanguagesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _engineLanguagesToolStripMenuItem.Click
      ' Show the dialog to let the user change the current enabled languages
      Dim moveRightImage As Image = LoadImageFromResource("MoveRight.png")
      Dim moveLeftImage As Image = LoadImageFromResource("MoveLeft.png")
      Dim moveTopImage As Image = LoadImageFromResource("MoveTop.png")
      Using dlg As New EnableLanguagesDialog(_ocrEngine, moveRightImage, moveLeftImage, moveTopImage)
         dlg.ShowDialog(Me)
      End Using
   End Sub

   Private Function LoadImageFromResource(ByVal resourceName As String) As Image
      Dim stream As Stream = Me.GetType().Assembly.GetManifestResourceStream(String.Format("{0}.{1}", Me.GetType().Namespace, resourceName))
      If stream Is Nothing Then
         Return Nothing
      End If

      Dim image As Image = image.FromStream(stream)
      Return image
   End Function

   Private Sub _pagesToolStripMenuItem_DropDownOpening(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _pagesToolStripMenuItem.DropDownOpening
      ' Update the UI state of the Pages menu items

      Dim documentHasPages As Boolean = Not IsNothing(_ocrDocument) AndAlso (_ocrDocument.Pages.Count > 0)

      _pagesDeleteCurrentPageToolStripMenuItem.Enabled = documentHasPages
      _pagesSaveProcessingImageToDiskToolStripMenuItem.Enabled = documentHasPages
      _pagesProcessToolStripMenuItem.Enabled = documentHasPages

      ' We only need this option for Professional and Advantage engines
      _pagesDetectPageLanguagesToolStripMenuItem.Visible = (_ocrEngine.EngineType = OcrEngineType.OmniPage OrElse _ocrEngine.EngineType = OcrEngineType.LEAD)
      _dualPageToolStripMenuItem.Visible = True

      _unwarpToolStripMenuItem.Enabled = documentHasPages AndAlso (_ocrPage.BitsPerPixel = 1 Or _ocrPage.BitsPerPixel = 8 Or _ocrPage.BitsPerPixel = 24 Or _ocrPage.BitsPerPixel = 32)
   End Sub

   Private Sub _pagesInsertToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _pagesInsertToolStripMenuItem.Click
      InsertPages()
   End Sub

   Private Sub _pagesDeleteCurrentPageToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _pagesDeleteCurrentPageToolStripMenuItem.Click
      DeletePage(CurrentPageIndex)
   End Sub

   Private Sub _pagesSaveProcessingImageToDiskToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _pagesSaveProcessingImageToDiskToolStripMenuItem.Click
      Dim tifFileName As String = Nothing

      Using dlg As New SaveFileDialog()
         dlg.Title = "Save processing image for this page as TIF"
         dlg.Filter = "TIFF Files (*.tif*.tiff)|*.tif*.tiff|All Files|*.*"
         dlg.DefaultExt = "tif"
         If dlg.ShowDialog(Me) = DialogResult.OK Then
            tifFileName = dlg.FileName
         End If
      End Using

      If tifFileName Is Nothing Then Exit Sub

      Try
         Using image As RasterImage = _ocrPage.GetRasterImage(OcrPageType.Processing)
            _rasterCodecs.Save(image, tifFileName, RasterImageFormat.CcittGroup4, 1)
         End Using
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub _processAllPagesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _processAllPagesToolStripMenuItem.Click
      ' Switch the process all pages or single page option
      _processAllPagesToolStripMenuItem.Checked = Not _processAllPagesToolStripMenuItem.Checked
   End Sub

   Private Sub _processFlipToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _processFlipToolStripMenuItem.Click
      ' Flip the current page or all pages
      FlipDocument(False)
   End Sub

   Private Sub _processReverseToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _processReverseToolStripMenuItem.Click
      ' Reverse (flip horizontal) the current page or pages
      FlipDocument(True)
   End Sub

   Private Sub _processRotate90ClockwiseToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _processRotate90ClockwiseToolStripMenuItem.Click
      ' Rotate the current page or pages 90 degrees clockwise
      RotateDocument(90)
   End Sub

   Private Sub _processRotate90CounterClockwiseToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _processRotate90CounterClockwiseToolStripMenuItem.Click
      ' Rotate the current page or pages 90 degrees counter-clockwise
      RotateDocument(-90)
   End Sub

   Private Sub _processPreprocessGetDeskewAngleToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _processPreprocessGetDeskewAngleToolStripMenuItem.Click
      ShowPreprocessingParameters(OcrAutoPreprocessPageCommand.Deskew)
   End Sub

   Private Sub _processPreprocessGetRotateAngleToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _processPreprocessGetRotateAngleToolStripMenuItem.Click
      ShowPreprocessingParameters(OcrAutoPreprocessPageCommand.Rotate)
   End Sub

   Private Sub _processPreprocessIsInvertedToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _processPreprocessIsInvertedToolStripMenuItem.Click
      ShowPreprocessingParameters(OcrAutoPreprocessPageCommand.Invert)
   End Sub

   Private Sub ShowPreprocessingParameters(ByVal command As OcrAutoPreprocessPageCommand)
      Dim allPages As Boolean = _processAllPagesToolStripMenuItem.Checked

      Try
         Dim sb As New StringBuilder()

         Dim wait As New WaitCursor()
         For i As Integer = 0 To _ocrDocument.Pages.Count - 1
            If allPages OrElse (i = CurrentPageIndex) Then
               Dim ocrPage As IOcrPage = _ocrDocument.Pages(i)

               sb.Append("Page " + (i + 1).ToString())

               Select Case command
                  Case OcrAutoPreprocessPageCommand.Deskew
                     Dim angle As Integer = ocrPage.GetDeskewAngle()
                     sb.AppendLine(" deskew angle is " + (angle / 10.0).ToString())

                  Case OcrAutoPreprocessPageCommand.Rotate
                     Dim angle As Integer = ocrPage.GetRotateAngle()
                     sb.AppendLine(" rotate angle is " + angle.ToString())

                  Case OcrAutoPreprocessPageCommand.Invert
                     Dim isInverted As Boolean = ocrPage.IsInverted()

                     If isInverted Then
                        sb.AppendLine(" is inverted")
                     Else
                        sb.AppendLine(" is not inverted")
                     End If
               End Select
            End If
         Next

         MessageBox.Show(Me, sb.ToString(), "Pre-processing", MessageBoxButtons.OK, MessageBoxIcon.Information)
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub _processPreprocessDeskewToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _processPreprocessDeskewToolStripMenuItem.Click
      Preprocess(OcrAutoPreprocessPageCommand.Deskew)
   End Sub

   Private Sub _processPreprocessRotateToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _processPreprocessRotateToolStripMenuItem.Click
      Preprocess(OcrAutoPreprocessPageCommand.Rotate)
   End Sub

   Private Sub _processPreprocessInvertToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _processPreprocessInvertToolStripMenuItem.Click
      Preprocess(OcrAutoPreprocessPageCommand.Invert)
   End Sub

   Private Sub _processPreprocessAllToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _processPreprocessAllToolStripMenuItem.Click
      Preprocess(OcrAutoPreprocessPageCommand.All)
   End Sub

   Private Sub _documentCleanupToolStripMenuItem_DropDownOpening(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _documentCleanupToolStripMenuItem.DropDownOpening
      _processLineRemoveToolStripMenuItem.Enabled = (_ocrPage.BitsPerPixel = 1)
   End Sub

   Private Sub _processAutoCropToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _processAutoCropToolStripMenuItem.Click
      ' Auto-crop the current page or pages
      RunImageProcessingCommand(New AutoCropCommand())
   End Sub

   Private Sub _processDespeckleToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _processDespeckleToolStripMenuItem.Click
      ' Despeckle the current page or pages
      RunImageProcessingCommand(New DespeckleCommand())
   End Sub

   Private Sub _processErodeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _processErodeToolStripMenuItem.Click
      ' Erode the current page or pages
      RunImageProcessingCommand(New BinaryFilterCommand(BinaryFilterCommandPredefined.ErosionOmniDirectional))
   End Sub

   Private Sub _processDilateToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _processDilateToolStripMenuItem.Click
      ' Dilate the current page or pages
      RunImageProcessingCommand(New BinaryFilterCommand(BinaryFilterCommandPredefined.DilationOmniDirectional))
   End Sub

   Private Sub _processInvertPageToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
      ' Auto-invert the current page or pages
      RunImageProcessingCommand(New InvertedPageCommand(InvertedPageCommandFlags.Process))
   End Sub

   Private Sub _processUnditherTextToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _processUnditherTextToolStripMenuItem.Click
      ' Undither text on current page or pages
      RunImageProcessingCommands(New RasterCommand() {New MedianCommand(3), New MinimumCommand(2)})
   End Sub

   Private Sub _processFixBrokenLettersToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _processFixBrokenLettersToolStripMenuItem.Click
      ' Fix broken text on current page or pages
      RunImageProcessingCommand(New MinimumCommand(2))
   End Sub

   Private Sub _processLineRemoveToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _processLineRemoveToolStripMenuItem.Click
      Dim horizontalRemoveCommand As New LineRemoveCommand()
      horizontalRemoveCommand.Type = LineRemoveCommandType.Horizontal

      Dim verticalRemoveCommand As New LineRemoveCommand()
      verticalRemoveCommand.Type = LineRemoveCommandType.Vertical

      RunImageProcessingCommands(New RasterCommand() {horizontalRemoveCommand, verticalRemoveCommand})
   End Sub

   Private Sub _processAutoBinarizeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _processAutoBinarizeToolStripMenuItem.Click
      ' Auto-binarize the current page or pages
      RunImageProcessingCommand(New AutoBinaryCommand())
   End Sub

   Private Sub _processDynamicBinarizeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _processDynamicBinarizeToolStripMenuItem.Click
      RunImageProcessingCommand(New DynamicBinaryCommand(7, 50))
   End Sub

   Private Sub _processHisogramEqualToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _processHisogramEqualToolStripMenuItem.Click
      RunImageProcessingCommand(New HistogramEqualizeCommand(HistogramEqualizeType.Yuv))
   End Sub

   Private Sub _processAutoLevelToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _processAutoLevelToolStripMenuItem.Click
      RunImageProcessingCommand(New AutoColorLevelCommand())
   End Sub

   Private Sub _processContrastBrightnessIntensityToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _processContrastBrightnessIntensityToolStripMenuItem.Click
      Using dlg As New ContrastBrightnessIntensityDialog(_viewerControl.RasterImageViewer)
         If dlg.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK Then
            RunImageProcessingCommand(dlg.Command)
         End If
      End Using
   End Sub

   Private Sub _processPageSplitterToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles _processPageSplitterToolStripMenuItem.Click

      Dim allPages As Boolean = _processAllPagesToolStripMenuItem.Checked
      Dim pagesCount As Integer = 1
      Dim firstPageIndex As Integer = 0
      Dim lastPageIndex As Integer = 0
      If allPages Then
         pagesCount = _ocrDocument.Pages.Count
         lastPageIndex = pagesCount - 1
         If pagesCount > 1 Then
            If MessageBox.Show("This function only works on 1-BPP images, so if any of your document pages is not then it will be converted to 1-BPP, press 'Yes' if you wish to proceed.", "Page splitter", MessageBoxButtons.YesNo, MessageBoxIcon.Information) <> DialogResult.Yes Then
               Return
            End If
         End If
      Else
         firstPageIndex = CurrentPageIndex
         lastPageIndex = CurrentPageIndex
         If _viewerControl.RasterImageViewer.Image IsNot Nothing AndAlso _viewerControl.RasterImageViewer.Image.BitsPerPixel <> 1 Then
            If MessageBox.Show("This function only works on 1-BPP images, press 'Yes' to convert the current image to 1-BPP and proceed.", "Page splitter", MessageBoxButtons.YesNo, MessageBoxIcon.Information) <> DialogResult.Yes Then
               Return
            End If
         End If
      End If

      For i As Integer = firstPageIndex To lastPageIndex
         ' Get the processed 1-BPP image from each OCR page and set it as the original page image
         Dim ocrPage As IOcrPage = _ocrDocument.Pages(i)
         Dim processingImage As RasterImage = ocrPage.GetRasterImage(OcrPageType.Processing)
         If processingImage IsNot Nothing Then
            ocrPage.SetRasterImage(processingImage)
         End If
      Next

      Dim borderRemoveCommand As New BorderRemoveCommand()
      borderRemoveCommand.Flags = BorderRemoveCommandFlags.AutoRemove
      RunImageProcessingCommands(New RasterCommand() {borderRemoveCommand, New AutoPageSplitterCommand()})
   End Sub

   Private Sub _processExpandContentToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles _processExpandContentToolStripMenuItem.Click

      Dim allPages As Boolean = _processAllPagesToolStripMenuItem.Checked
      Dim pagesCount As Integer = 1
      Dim firstPageIndex As Integer = 0
      Dim lastPageIndex As Integer = 0
      If allPages Then
         pagesCount = _ocrDocument.Pages.Count
         lastPageIndex = pagesCount - 1
         If pagesCount > 1 Then
            If MessageBox.Show("This function only works on 1-BPP images, so if any of your document pages is not then it will be converted to 1-BPP, press 'Yes' if you wish to proceed.", "Page expand content", MessageBoxButtons.YesNo, MessageBoxIcon.Information) <> DialogResult.Yes Then
               Return
            End If
         End If
      Else
         firstPageIndex = CurrentPageIndex
         lastPageIndex = CurrentPageIndex
         If _viewerControl.RasterImageViewer.Image IsNot Nothing AndAlso _viewerControl.RasterImageViewer.Image.BitsPerPixel <> 1 Then
            If MessageBox.Show("This function only works on 1-BPP images, press 'Yes' to convert the current image to 1-BPP and proceed.", "Page expand content", MessageBoxButtons.YesNo, MessageBoxIcon.Information) <> DialogResult.Yes Then
               Return
            End If
         End If
      End If

      For i As Integer = firstPageIndex To lastPageIndex
         ' Get the processed 1-BPP image from each OCR page and set it as the original page image
         Dim ocrPage As IOcrPage = Nothing
         ocrPage = _ocrDocument.Pages(i)
         Dim processingImage As RasterImage = ocrPage.GetRasterImage(OcrPageType.Processing)
         If processingImage IsNot Nothing Then
            ocrPage.SetRasterImage(processingImage)
         End If
      Next

      RunImageProcessingCommand(New ExpandContentCommand())
   End Sub

   Private Sub _manualPerspectiveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles _manualPerspectiveToolStripMenuItem.Click
      PerspectiveDeskewActive = True
      _mainMenuStrip.Enabled = False
      _mainToolStrip.Enabled = False
      _viewerControl.UpdateUIState()
      _pagesControl.UpdateUIState()
      _viewerControl.InteractiveMode = ViewerControlInteractiveMode.SelectMode
      _viewerControl.ZonesUpdated()

      Dim perspectiveDlg As PerspectiveDialog
      perspectiveDlg = New PerspectiveDialog(Me, _viewerControl, True)
      AddHandler perspectiveDlg.Action, AddressOf perspectiveDlg_Action
      perspectiveDlg.Show()
   End Sub

   Private Sub _inversePerspectiveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles _inversePerspectiveToolStripMenuItem.Click
      PerspectiveDeskewActive = True
      _mainMenuStrip.Enabled = False
      _mainToolStrip.Enabled = False
      _viewerControl.UpdateUIState()
      _pagesControl.UpdateUIState()
      _viewerControl.InteractiveMode = ViewerControlInteractiveMode.SelectMode
      _viewerControl.ZonesUpdated()

      Dim perspectiveDlg As PerspectiveDialog
      perspectiveDlg = New PerspectiveDialog(Me, _viewerControl, False)
      AddHandler perspectiveDlg.Action, AddressOf perspectiveDlg_Action
      perspectiveDlg.Show()
   End Sub

   Private Sub perspectiveDlg_Action(sender As Object, e As ActionEventArgs)
      Dim ocrPage As IOcrPage = _ocrDocument.Pages(CurrentPageIndex)

      If ocrPage IsNot Nothing Then
         If (Not PerspectiveDeskewActive) Then
            _mainMenuStrip.Enabled = True
            _mainToolStrip.Enabled = True
            _viewerControl.UpdateUIState()
            _pagesControl.UpdateUIState()
         End If
      End If

      _viewerControl.ZonesUpdated()
      Dim perspectiveDlg As PerspectiveDialog = TryCast(e.Data, PerspectiveDialog)
      If Not perspectiveDlg.IsDisposed And Not perspectiveDlg.OkButtonPressed Then
         Return
      End If

      ' Called from the PerspectiveDialog when a OK or Apply buttons clicked
      Select Case e.Action
         Case "ManualPerspectiveCommand", "InversePerspectiveCommand"
            Using wait As New WaitCursor()
               ocrPage.Zones.Clear()
               ocrPage.Unrecognize()
               ocrPage.SetRasterImage(_viewerControl.RasterImageViewer.Image)

               ' Re-paint current page
               _viewerControl.ZonesUpdated()
               UpdateUIState()
               ' Update the thumbnail(s)
               RefreshPagesControl(True)
               GotoPage(CurrentPageIndex)
            End Using
            Exit Select
      End Select

      RemoveHandler perspectiveDlg.Action, AddressOf perspectiveDlg_Action
      PerspectiveDeskewActive = False
      _mainMenuStrip.Enabled = True
      _mainToolStrip.Enabled = True
      _viewerControl.UpdateUIState()
      _pagesControl.UpdateUIState()
   End Sub

   Private Sub _perspectiveDeskewToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles _perspectiveDeskewToolStripMenuItem.Click
      If _viewerControl.RasterImageViewer.Image IsNot Nothing AndAlso _viewerControl.RasterImageViewer.Image.BitsPerPixel <> 24 AndAlso _viewerControl.RasterImageViewer.Image.BitsPerPixel <> 32 Then
         MessageBox.Show("This function only works on 24-BPP and 32-BPP images", "Perspective Deskew", MessageBoxButtons.OK, MessageBoxIcon.Information)
         Return
      End If

      RunImageProcessingCommand(New PerspectiveDeskewCommand())
   End Sub

   Private Sub _ocrToolStripMenuItem_DropDownOpening(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _ocrToolStripMenuItem.DropDownOpening
      ' Update the UI state of the OCR menu items
      UpdateUIState()
   End Sub

   Private Sub _ocrZonesToolStripMenuItem_DropDownOpening(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _ocrZonesToolStripMenuItem.DropDownOpening
      _zonesUpdateZonesToolStripMenuItem.Enabled = Not IsNothing(_ocrPage)
      _zonesShowZonesToolStripMenuItem.Checked = _viewerControl.ShowZones
      _zonesShowZoneNamesToolStripMenuItem.Checked = _viewerControl.ShowZoneNames
   End Sub

   Private Sub _ocrRecognizeDocumentToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _ocrRecognizeDocumentToolStripMenuItem.Click, _recognizeDocumentToolStripButton.Click
      If _ocrDocument Is Nothing OrElse _ocrDocument.Pages.Count = 0 Then
         Return
      End If

      RecognizeDocument(True)
   End Sub

   Private Sub _ocrRecognizePageToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _ocrRecognizePageToolStripMenuItem.Click, _recognizePageToolStripButton.Click
      If _ocrDocument Is Nothing OrElse _ocrDocument.Pages.Count = 0 Then
         Return
      End If

      RecognizeDocument(False)
   End Sub

   Private Sub _ocrSaveDocumentToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _ocrSaveDocumentToolStripMenuItem.Click, _saveDocumentToolStripButton.Click
      If _ocrDocument Is Nothing OrElse _ocrDocument.Pages.Count = 0 Then
         Return
      End If

      SaveDocument()
   End Sub


   Private Sub _ocrShowRecognizedWordsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _ocrShowRecognizedWordsToolStripMenuItem.Click
      If Not IsNothing(_ocrPage) AndAlso (_ocrPage.IsRecognized) Then
         Using dlg As New RecognizedWordsDialog(_ocrDocument)
            dlg.ShowDialog(Me)
         End Using
      End If
   End Sub

   Private Sub _ocrSaveRecognizedDataAsXmlToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _ocrSaveRecognizedDataAsXmlToolStripMenuItem.Click
      If Not IsNothing(_ocrPage) AndAlso (_ocrPage.IsRecognized) Then
         Using dlg As New SaveRecognizedXmlDialog(_ocrDocument)
            dlg.ShowDialog(Me)
         End Using
      End If
   End Sub

   Private Sub _ocrSpellCheckEngineStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _ocrSpellCheckEngineStripMenuItem.Click
      If _ocrEngine.SpellCheckManager Is Nothing Then
         MessageBox.Show("Feature not supported for this engine.", "Spell Language", MessageBoxButtons.OK, MessageBoxIcon.Information)
         Return
      End If

      Using dlg As New SpellCheckEngineDialog(_ocrEngine)
         If dlg.ShowDialog() = DialogResult.OK Then
            UpdateActiveSpellCheckerLabel(If((_ocrEngine.SpellCheckManager IsNot Nothing), _ocrEngine.SpellCheckManager.SpellCheckEngine, OcrSpellCheckEngine.None))
         End If
      End Using
   End Sub

   Private Sub _ocrOmrOptionsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _ocrOmrOptionsToolStripMenuItem.Click
      Using dlg As New OcrOmrOptionsDialog(_ocrEngine)
         dlg.ShowDialog(Me)
      End Using
   End Sub

   Private Sub _zonesAutoZoneDocumentToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _zonesAutoZoneDocumentToolStripMenuItem.Click
      AutoZone(True)
   End Sub

   Private Sub _zonesAutoZoneCurrentPageToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _zonesAutoZoneCurrentPageToolStripMenuItem.Click
      AutoZone(False)
   End Sub

   Private Sub _zonesUpdateZonesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _zonesUpdateZonesToolStripMenuItem.Click
      ShowZoneProperties()
   End Sub

   Private Sub _zonesLoadZonesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _zonesLoadZonesToolStripMenuItem.Click
      LoadZones(False)
   End Sub

   Private Sub _zonesSaveZonesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _zonesSaveZonesToolStripMenuItem.Click
      SaveZones(False)
   End Sub

   Private Sub _zonesShowZonesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _zonesShowZonesToolStripMenuItem.Click
      _viewerControl.ShowZones = Not _viewerControl.ShowZones
   End Sub

   Private Sub _zonesShowZoneNamesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _zonesShowZoneNamesToolStripMenuItem.Click
      _viewerControl.ShowZoneNames = Not _viewerControl.ShowZoneNames
   End Sub

   Private Sub _preferencesUseProgressBarsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _preferencesUseProgressBarsToolStripMenuItem.Click
      _preferencesUseProgressBarsToolStripMenuItem.Checked = Not _preferencesUseProgressBarsToolStripMenuItem.Checked
   End Sub

   Private Sub _helpAboutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _helpAboutToolStripMenuItem.Click
      Using aboutDialog As New AboutDialog("Multi-Engine OCR", ProgrammingInterface.VB)
         aboutDialog.ShowDialog(Me)
      End Using
   End Sub

   Private Sub _openDocumentToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _openDocumentToolStripButton.Click
      _fileOpenToolStripMenuItem.PerformClick()
   End Sub

   Private Sub _autoZoneDocumentToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _autoZoneDocumentToolStripButton.Click
      _zonesAutoZoneDocumentToolStripMenuItem.PerformClick()
   End Sub

   Private Sub _autoZonePageToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _autoZonePageToolStripButton.Click
      _zonesAutoZoneCurrentPageToolStripMenuItem.PerformClick()
   End Sub

   Private Sub _recognizeDocumentToolStripButton_Click(ByVal sender As Object, ByVal e As EventArgs)
      _ocrRecognizeDocumentToolStripMenuItem.PerformClick()
   End Sub

   Private Sub _recognizePageToolStripButton_Click(ByVal sender As Object, ByVal e As EventArgs)
      _ocrRecognizePageToolStripMenuItem.PerformClick()
   End Sub

   Private Sub _saveDocumentToolStripButton_Click(ByVal sender As Object, ByVal e As EventArgs)
      _ocrSaveDocumentToolStripMenuItem.PerformClick()
   End Sub

   Private Sub UpdateUIState()
      ' Update the UI state

      Dim documentHasPages As Boolean = Not IsNothing(_ocrDocument) AndAlso (_ocrDocument.Pages.Count > 0)

      ' Update toolbar buttons
      _autoZoneDocumentToolStripButton.Enabled = documentHasPages
      _autoZonePageToolStripButton.Enabled = documentHasPages
      _recognizeDocumentToolStripButton.Enabled = documentHasPages
      _recognizePageToolStripButton.Enabled = documentHasPages
      _saveDocumentToolStripButton.Enabled = documentHasPages

      ' Update menu items
      _ocrZonesToolStripMenuItem.Enabled = documentHasPages
      _ocrRecognizeDocumentToolStripMenuItem.Enabled = documentHasPages
      _ocrRecognizePageToolStripMenuItem.Enabled = documentHasPages
      _ocrSaveDocumentToolStripMenuItem.Enabled = documentHasPages
      _ocrShowRecognizedWordsToolStripMenuItem.Enabled = _ocrPage IsNot Nothing AndAlso _ocrPage.IsRecognized
      _ocrSaveRecognizedDataAsXmlToolStripMenuItem.Enabled = _ocrPage IsNot Nothing AndAlso _ocrPage.IsRecognized

      ' We only need this option for Advantage engine
      _processContrastBrightnessIntensityToolStripMenuItem.Visible = _ocrEngine.EngineType = OcrEngineType.LEAD

      ' OMR is not supported for Arabic OCR engine.
      _ocrOmrOptionsToolStripMenuItem.Enabled = _ocrEngine.EngineType <> OcrEngineType.OmniPageArabic
   End Sub

   Private Sub OpenDocument()
      ' Open a document from disk

      ' Show the LEADTOOLS common dialog
      Dim loader As New ImageFileLoader()
      loader.LoadOnlyOnePage = False
      loader.ShowLoadPagesDialog = True
      If Not String.IsNullOrEmpty(My.Settings.OpenDialogInitialPath) Then
         loader.OpenDialogInitialPath = My.Settings.OpenDialogInitialPath
      End If

      Try
         ' Insert the pages loader into the document
         If (loader.Load(Me, _rasterCodecs, False) > 0) Then
            My.Settings.OpenDialogInitialPath = Path.GetDirectoryName(loader.FileName)
            My.Settings.Save()
            OpenDocument(loader.FileName, loader.FirstPage, loader.LastPage)
         End If
      Catch ex As Exception
         ShowError(ex)
         UpdateTimingLabel(Nothing, Nothing)
      End Try
   End Sub

   Private Sub OpenDocument(ByVal fileName As String, ByVal firstPage As Integer, ByVal lastPage As Integer)
      ' Open the document in file name

      ' Create a new document and insert the pages
      _filename = fileName
      Try
         NewDocument(fileName)
         InsertPages(fileName, firstPage, lastPage, Nothing, -1)
         _isCustomFileName = False
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub NewDocument(ByVal title As String)
      ' Create a new document

      If Not IsNothing(_ocrDocument) Then
         _ocrDocument.Dispose()
      End If

      _ocrDocument = _ocrEngine.DocumentManager.CreateDocument(Nothing, OcrCreateDocumentOptions.InMemory)
      _ocrPage = Nothing

      _viewerControl.ClearZones()
      _viewerControl.Title = title

      _pagesControl.RasterImageList.Items.Clear()
      RepopulatePagesControl(0, -1, title)
      GotoPage(-1)

      UpdateUIState()
   End Sub

   Private Sub _pagesControl_Action(ByVal sender As System.Object, ByVal e As ActionEventArgs) Handles _pagesControl.Action
      ' Called from the PagesControl when a button is clicked

      Select Case e.Action
         Case "InsertPage"
            InsertPages()

         Case "DeletePage"
            DeletePage(CurrentPageIndex)

         Case "MovePageUp"
            MoveCurrentPage(True)

         Case "MovePageDown"
            MoveCurrentPage(False)

         Case "PageIndexChanged"
            ' Get the new page index and go to it
            Dim pageIndex As Integer = CType(e.Data, Integer)
            GotoPage(pageIndex)
      End Select
   End Sub

   Private Sub _viewerControl_Action(ByVal sender As System.Object, ByVal e As ActionEventArgs) Handles _viewerControl.Action
      ' Called from the ViewerControl when a button is clicked

      Select Case e.Action
         Case "PageIndexChanged"
            ' Get the new page index and go to it
            Dim pageIndex As Integer = CType(e.Data, Integer)
            GotoPage(pageIndex)

         Case "ShowZoneProperties"
            ShowZoneProperties()

         Case "RefreshPagesControl"
            Dim allPages As Boolean = CType(e.Data, Boolean)
            RefreshPagesControl(allPages)
      End Select
   End Sub

   Private ReadOnly Property CurrentPageIndex() As Integer
      Get
         ' Get the current OCR page index
         If IsNothing(_ocrPage) Then
            Return -1
         Else
            Return _ocrDocument.Pages.IndexOf(_ocrPage)
         End If
      End Get
   End Property

   Private Sub InsertPages()
      ' Insert new pages into the current document

      ' Show the common file dialog to let the user select a file
      Dim loader As ImageFileLoader = New ImageFileLoader()
      loader.LoadOnlyOnePage = False
      loader.ShowLoadPagesDialog = True

      Try
         If (Not String.IsNullOrEmpty(My.Settings.InsertPageDialogInitialPath)) Then
            loader.OpenDialogInitialPath = My.Settings.InsertPageDialogInitialPath
         End If

         ' Insert the pages loader into the document
         If loader.Load(Me, _rasterCodecs, False) > 0 Then
            My.Settings.InsertPageDialogInitialPath = Path.GetDirectoryName(loader.FileName)
            My.Settings.Save()
            InsertPages(loader.FileName, loader.FirstPage, loader.LastPage, Nothing, -1)
         End If
      Catch ex As Exception
         ShowError(ex)
         UpdateTimingLabel(Nothing, Nothing)
      End Try
   End Sub

   Private Sub InsertPages(ByVal fileName As String, ByVal firstPage As Integer, ByVal lastPage As Integer, ByVal image As RasterImage, ByVal insertionIndex As Integer)
      ' Insert the pages from file or directly into the current document
      ' Go to the first inserted page

      Dim pageIndex As Integer = insertionIndex
      If (insertionIndex = -1) Then
         pageIndex = CurrentPageIndex

         ' Insert the new pages after the current page
         If (pageIndex = -1) Then
            pageIndex = 0
         Else
            pageIndex = pageIndex + 1
         End If
      End If

      Dim oldPagesCount As Integer = _ocrDocument.Pages.Count

      Try
         ' Check if we are inserting a page from file or directly
         Using wait As New WaitCursor()
            Dim beginTime As DateTime = DateTime.Now

            If Not IsNothing(image) Then
               _ocrDocument.Pages.InsertPage( _
                  pageIndex, _
                  image, _
                  Nothing)
            Else
               _ocrDocument.Pages.InsertPages( _
                  pageIndex, _
                  fileName, _
                  firstPage, _
                  lastPage, _
                  Nothing)

               Dim ts As TimeSpan = DateTime.Now - beginTime
               UpdateTimingLabel(New String() {"Insert pages"}, New TimeSpan() {ts})
            End If
         End Using

         ' Update the pages control with the new document
         Dim newPagesCount As Integer = _ocrDocument.Pages.Count
         RepopulatePagesControl(pageIndex, newPagesCount - oldPagesCount, fileName)

         ' Go to the first page inserted in the document
         GotoPage(pageIndex)
      Catch ex As Exception
         If (ex.Message.Equals("Not enough memory available")) Then
            _ocrDocument.Pages.Clear()
         Else
            Dim newPagesCount As Integer = _ocrDocument.Pages.Count
            If (newPagesCount = oldPagesCount + 1) Then
               ' page was added successfully into the engine but the error occurred somewhere else after that, 
               ' so delete the last inserted page otherwise the demo PagesControl will have some problems.
               _ocrDocument.Pages.RemoveAt(newPagesCount - 1)
            End If
         End If

         Throw ex
      End Try
   End Sub

   Private Sub DeletePage(ByVal pageIndex As Integer)
      ' Delete the page with the passed index from the document
      Using wait As New WaitCursor()
         _ocrDocument.Pages.RemoveAt(pageIndex)

         _pagesControl.RasterImageList.Items.RemoveAt(pageIndex)

         If (pageIndex >= _ocrDocument.Pages.Count) Then
            pageIndex = _ocrDocument.Pages.Count - 1
         End If

         ' Update the pages control with the new document
         If (pageIndex >= 0) Then
            UpdatePagesControlItemsText(pageIndex)
         End If

         ' Go to the current page
         GotoPage(pageIndex)
      End Using
   End Sub

   Private Sub RepopulatePagesControl(ByVal pageIndex As Integer, ByVal count As Integer, ByVal fileName As String)
      Using wait As New WaitCursor()
         ' Re-insert the thumbnails from the pages control
         Dim imageList As ImageViewer = _pagesControl.RasterImageList
         imageList.BeginUpdate()

         ' Loop through all the pages in the document and create thumbnails for them,
         ' add the thumbnails to the pages control

         Try
            If Not IsNothing(_ocrDocument) Then
               Dim thumbSize As LeadSize = imageList.ItemSize

               Dim index As Integer = pageIndex
               Dim i As Integer = 0
               Do While i < count
                  Dim ocrPage As IOcrPage = _ocrDocument.Pages(index)
                  Dim image As RasterImage = ocrPage.CreateThumbnail(thumbSize.Width, thumbSize.Height)
                  Dim item As New ImageViewerItem()
                  item.Image = image
                  item.PageNumber = 1
                  item.Text = "Page " & (index + 1)
                  imageList.Items.Insert(index, item)
                  index += 1
                  i += 1
               Loop

               ' Loop through all image list items that followed the inserted item and correct their names orders
               i = index
               Do While i < imageList.Items.Count
                  If Not imageList.Items(i) Is Nothing Then
                     imageList.Items(i).Text = "Page " & (i + 1).ToString()
                  End If
                  i += 1
               Loop
            End If
         Catch ex As Exception
            ' need to resume image list update before throwing the error.
            imageList.EndUpdate()
            Throw ex
         End Try

         imageList.EndUpdate()
      End Using
   End Sub

   Private Sub UpdatePagesControlItemsText(ByVal pageIndex As Integer)
      Dim imageList As ImageViewer = _pagesControl.RasterImageList

      For i As Integer = pageIndex To imageList.Items.Count - 1
         Dim itemText As String = "Page " + (i + 1).ToString()
         imageList.Items(i).Text = itemText
      Next
   End Sub


   Private Sub RefreshPagesControl(ByVal allPages As Boolean)
      Using wait As New WaitCursor()
         ' Re-get the thumbnails from the pages control
         Dim imageList As ImageViewer = _pagesControl.RasterImageList
         imageList.BeginUpdate()

         Dim thumbSize As LeadSize = imageList.ItemSize

         Dim pageIndex As Integer = CurrentPageIndex

         For i As Integer = 0 To imageList.Items.Count - 1
            If (allPages) OrElse (i = pageIndex) Then
               Dim image As RasterImage = _ocrDocument.Pages(i).CreateThumbnail(thumbSize.Width, thumbSize.Height)
               imageList.Items(i).Image = image
            End If

            ' Set the item tag if the page is recognized, otherwise set it to null
            If _ocrDocument IsNot Nothing AndAlso _ocrDocument.Pages(i).IsRecognized Then
               imageList.Items(i).Tag = True
            Else
               imageList.Items(i).Tag = False
            End If

         Next

         imageList.EndUpdate()
      End Using
   End Sub

   Private Sub GotoPage(ByVal pageIndex As Integer)
      ' Goto this page in the OCR document
      If (pageIndex = -1) Then
         pageIndex = 0
      End If

      If Not IsNothing(_ocrDocument) AndAlso (_ocrDocument.Pages.Count > 0) Then
         _ocrPage = _ocrDocument.Pages(pageIndex)

         ' Set the current page in the pages control
         _pagesControl.SetCurrentPageIndex(pageIndex)

         ' Go to the current page in the viewer control
         _viewerControl.SetPages(pageIndex, _ocrDocument.Pages.Count)

         Dim pageType As OcrPageType = OcrPageType.Current

         Using wait As New WaitCursor()
            Dim image As RasterImage = _ocrPage.GetRasterImage(OcrPageType.Current)
            _viewerControl.SetImageAndPage(image, _ocrPage)
         End Using
      Else
         ' No more pages
         _ocrPage = Nothing

         _pagesControl.SetCurrentPageIndex(-1)
         _viewerControl.ClearZones()
         _viewerControl.SetImageAndPage(Nothing, Nothing)
         _viewerControl.SetPages(0, 0)
      End If

      If (_pagesControl.RasterImageList.Items.Count > 0 And pageIndex < _pagesControl.RasterImageList.Items.Count) Then
         _viewerControl.Title = _pagesControl.RasterImageList.Items(pageIndex).Text
      Else
         _viewerControl.Title = String.Empty
      End If

      UpdateUIState()
   End Sub

   Private Sub RunImageProcessingCommand(ByVal command As RasterCommand)
      RunImageProcessingCommands(New RasterCommand() {command})
   End Sub

   Private Sub RunImageProcessingCommands(ByVal commands() As RasterCommand)
      ' Run the command on all or just current page
      Dim allPages As Boolean = _processAllPagesToolStripMenuItem.Checked
      Dim isPageSplitterCommand As Boolean = False
      Dim currentPageIndex As Integer = Me.CurrentPageIndex

      Try
         Using wait As New WaitCursor()
            If allPages Then
               ' Loop through the pages of the document
               ' Get the page as a RasterImage object
               ' Run the command on it
               ' Set it back in the engine
               Dim i As Integer = 0
               Do While i < _ocrDocument.Pages.Count
                  Dim ocrPage As IOcrPage = _ocrDocument.Pages(i)
                  ' Remove the zones from the page and unrecognize
                  ocrPage.Zones.Clear()
                  ocrPage.Unrecognize()

                  Using image As RasterImage = ocrPage.GetRasterImage()
                     For Each command As RasterCommand In commands
                        command.Run(image)
                        If command.[GetType]() Is GetType(AutoPageSplitterCommand) Then
                           isPageSplitterCommand = True
                           Dim pageSplitterCommand As AutoPageSplitterCommand = CType(command, AutoPageSplitterCommand)
                           If pageSplitterCommand.FirstImage IsNot Nothing AndAlso pageSplitterCommand.SecondImage IsNot Nothing Then
                              ' Use the original image list item file name after applying this command to display 
                              ' the correct file name in viewer control title bar
                              Dim fileName As String = _pagesControl.RasterImageList.Items(i).Text

                              ' This command splits the page into two, so we need to remove the original page and 
                              ' add two pages instead with the images returned from this command.
                              DeletePage(i)
                              InsertPages(fileName, 1, 1, pageSplitterCommand.FirstImage, i)
                              InsertPages(fileName, 1, 1, pageSplitterCommand.SecondImage, i + 1)
                              i += 1
                           End If
                        End If
                     Next
                     If Not isPageSplitterCommand Then
                        ocrPage.SetRasterImage(image)
                     End If
                  End Using
                  i += 1
               Loop

               If isPageSplitterCommand Then
                  GotoPage(currentPageIndex)
               End If
            Else
               ' Remove the zones from the page and unrecognize
               _ocrPage.Zones.Clear()
               _ocrPage.Unrecognize()

               ' The image is in the viewer, use it
               Dim image As RasterImage = _ocrPage.GetRasterImage(OcrPageType.Current)
               For Each command As RasterCommand In commands
                  command.Run(image)
                  If command.[GetType]() Is GetType(AutoPageSplitterCommand) Then
                     isPageSplitterCommand = True
                     Dim pageSplitterCommand As AutoPageSplitterCommand = CType(command, AutoPageSplitterCommand)
                     If pageSplitterCommand.FirstImage IsNot Nothing AndAlso pageSplitterCommand.SecondImage IsNot Nothing Then
                        ' Use the original image list item file name after applying this command to display 
                        ' the correct file name in viewer control title bar
                        Dim fileName As String = _pagesControl.RasterImageList.Items(currentPageIndex).Text

                        ' This command splits the page into two, so we need to remove the original page and 
                        ' add two pages instead with the images returned from this command.
                        InsertPages(fileName, 1, 1, pageSplitterCommand.FirstImage, -1)
                        InsertPages(fileName, 1, 1, pageSplitterCommand.SecondImage, -1)
                        DeletePage(currentPageIndex)
                     End If
                  End If
               Next

               If Not isPageSplitterCommand Then
                  _ocrPage.SetRasterImage(image)
               End If
            End If
         End Using
      Catch ex As Exception
         ShowError(ex)
      Finally
         ' Update the page in the viewer from the engine
         GotoPage(currentPageIndex)
         ' Update the thumbnail(s)
         RefreshPagesControl(allPages)
      End Try
   End Sub

   Private Sub FlipDocument(ByVal horizontal As Boolean)
      ' Run the command on all or just current page
      Dim allPages As Boolean = _processAllPagesToolStripMenuItem.Checked

      Try
         Using wait As New WaitCursor()
            If (allPages) Then
               ' Loop through the pages of the document
               ' Get the page as a RasterImage object
               ' Run the command on it
               ' Set it back in the engine
               For Each ocrPage As IOcrPage In _ocrDocument.Pages
                  ' Remove the zones from the page and unrecognize
                  ocrPage.Zones.Clear()
                  ocrPage.Unrecognize()

                  Using image As RasterImage = ocrPage.GetRasterImage()
                     image.FlipViewPerspective(horizontal)
                     ocrPage.SetRasterImage(image)
                  End Using
               Next
            Else
               ' Remove the zones from the page and unrecognize
               _ocrPage.Zones.Clear()
               _ocrPage.Unrecognize()

               ' The image is in the viewer, use it
               Dim image As RasterImage = _viewerControl.RasterImage
               image.FlipViewPerspective(horizontal)
               _ocrPage.SetRasterImage(image)
            End If
         End Using
      Catch ex As Exception
         ShowError(ex)
      Finally
         ' Update the page in the viewer from the engine
         GotoPage(CurrentPageIndex)
         ' Update the thumbnail(s)
         RefreshPagesControl(allPages)
      End Try
   End Sub

   Private Sub RotateDocument(ByVal angle As Integer)
      ' Run the command on all or just current page
      Dim allPages As Boolean = _processAllPagesToolStripMenuItem.Checked
      Dim rotateCmd As New RotateCommand(angle * 100, RotateCommandFlags.Resize, New RasterColor(255, 255, 255))

      Try
         Using wait As New WaitCursor()
            If (allPages) Then
               ' Loop through the pages of the document
               ' Get the page as a RasterImage object
               ' Run the command on it
               ' Set it back in the engine
               For Each ocrPage As IOcrPage In _ocrDocument.Pages
                  ' Remove the zones from the page and unrecognize
                  ocrPage.Zones.Clear()
                  ocrPage.Unrecognize()

                  Using image As RasterImage = ocrPage.GetRasterImage()
                     rotateCmd.Run(image)
                     ocrPage.SetRasterImage(image)
                  End Using
               Next
            Else
               ' Remove the zones from the page and unrecognize
               _ocrPage.Zones.Clear()
               _ocrPage.Unrecognize()

               ' The image is in the viewer, use it
               Dim image As RasterImage = _viewerControl.RasterImage
               rotateCmd.Run(image)
               _ocrPage.SetRasterImage(image)
            End If
         End Using
      Catch ex As Exception
         ShowError(ex)
      Finally
         ' Update the page in the viewer from the engine
         GotoPage(CurrentPageIndex)
         ' Update the thumbnail(s)
         RefreshPagesControl(allPages)
      End Try
   End Sub

   Private Sub MoveCurrentPage(ByVal up As Boolean)
      ' Move the current page up or down
      ' We will do the move by swapping the two pages

      ' Get the page indices to move
      Dim pageIndex1 As Integer = CurrentPageIndex
      Dim pageIndex2 As Integer

      If (up) Then
         pageIndex2 = pageIndex1 - 1
      Else
         pageIndex2 = pageIndex1 + 1
      End If

      Using wait As New WaitCursor()
         ' First, move the pages in the OCR engine
         ' by swapping the RasterImage's
         Dim ocrPage1 As IOcrPage = _ocrDocument.Pages(pageIndex1)
         Dim ocrPage2 As IOcrPage = _ocrDocument.Pages(pageIndex2)

         Using _
               rasterImage1 As RasterImage = ocrPage1.GetRasterImage(), _
               rasterImage2 As RasterImage = ocrPage2.GetRasterImage()
            ocrPage1.SetRasterImage(rasterImage2)
            ocrPage2.SetRasterImage(rasterImage1)
         End Using

         ' Swap the zones
         Using _
            ms1 As New MemoryStream(), _
            ms2 As New MemoryStream()
            ocrPage1.SaveZones(ms1)
            ocrPage2.SaveZones(ms2)

            ms1.Position = 0
            ms2.Position = 0

            ocrPage1.LoadZones(ms2)
            ocrPage2.LoadZones(ms1)
         End Using

         ' Now, swap the thumbnails of the two pages in the pages control
         Dim imageList As ImageViewer = _pagesControl.RasterImageList

         imageList.BeginUpdate()

         Dim image As RasterImage = imageList.Items(pageIndex1).Image
         imageList.Items(pageIndex1).Image = imageList.Items(pageIndex2).Image
         imageList.Items(pageIndex2).Image = image

         imageList.EndUpdate()

         ' Finally, go to the new page
         GotoPage(pageIndex2)
      End Using
   End Sub

   Private Sub Preprocess(ByVal command As OcrAutoPreprocessPageCommand)
      ' Preprocess current or all pages in the document
      Dim allPages As Boolean = _processAllPagesToolStripMenuItem.Checked

      ' Setup the arguments for the callback
      Dim args As New Dictionary(Of String, Object)()
      args.Add("allPages", allPages)
      args.Add("command", command)

      ' Call the process dialog
      Try
         Dim allowProgress As Boolean = _preferencesUseProgressBarsToolStripMenuItem.Checked
         Using dlg As New OcrProgressDialog(allowProgress, "Preprocess", New OcrProgressDialog.ProcessDelegate(AddressOf DoPreprocess), args)
            dlg.ShowDialog(Me)
         End Using
      Catch ex As Exception
         ShowError(ex)
      Finally
         ' Update the page in the viewer from the engine
         GotoPage(CurrentPageIndex)
         ' Update the thumbnail(s)
         RefreshPagesControl(allPages)

         UpdateUIState()
      End Try
   End Sub

   Private Sub DoPreprocess(ByVal dlg As OcrProgressDialog, ByVal args As Dictionary(Of String, Object))
      ' Perform auto-zoning here

      Dim callback As OcrProgressCallback = dlg.OcrProgressCallback

      Try
         Dim allPages As Boolean = CType(args("allPages"), Boolean)
         Dim command As OcrAutoPreprocessPageCommand = CType(args("command"), OcrAutoPreprocessPageCommand)

         ' If we are not using a progress bar, update the description text
         If IsNothing(callback) Then
            dlg.UpdateDescription("Preprocessing the page(s) of the document...")
         End If

         ' Remove the zones from the page(s)

         If (allPages) Then
            For Each ocrPage As IOcrPage In _ocrDocument.Pages
               ' Remove the zones from the page and unrecognize
               ocrPage.Zones.Clear()
               ocrPage.Unrecognize()
            Next
         Else
            _ocrPage.Zones.Clear()
            _ocrPage.Unrecognize()
         End If

         Dim beginTime As DateTime = DateTime.Now

         If allPages Then
            _ocrDocument.Pages.AutoPreprocess(command, callback)
         Else
            _ocrPage.AutoPreprocess(command, callback)
         End If

         Dim ts As TimeSpan = DateTime.Now - beginTime
         UpdateTimingLabel(New String() {"Preprocess"}, New TimeSpan() {ts})

      Catch ex As Exception
         ShowError(ex)
         UpdateTimingLabel(Nothing, Nothing)
      Finally
         If IsNothing(callback) Then
            dlg.EndOperation()
         End If
      End Try
   End Sub

   Private Sub AutoZone(ByVal allPages As Boolean)
      ' Auto zone current or all pages in the document

      ' Setup the arguments for the callback
      Dim args As New Dictionary(Of String, Object)()
      args.Add("allPages", allPages)

      ' Call the process dialog
      Try
         Dim allowProgress As Boolean = _preferencesUseProgressBarsToolStripMenuItem.Checked
         Using dlg As New OcrProgressDialog(allowProgress, "Auto Zone", New OcrProgressDialog.ProcessDelegate(AddressOf DoAutoZone), args)
            dlg.ShowDialog(Me)
         End Using
      Catch ex As Exception
         ShowError(ex)
      Finally
         ' Re-paint current page to show new zones
         _viewerControl.ZonesUpdated()
         UpdateUIState()
      End Try
      _viewerControl.InteractiveMode = ViewerControlInteractiveMode.DrawZoneMode
      _viewerControl.AutomationManager.CurrentObjectId = AnnObject.SelectObjectId
   End Sub

   Private Sub DoAutoZone(ByVal dlg As OcrProgressDialog, ByVal args As Dictionary(Of String, Object))
      ' Perform auto-zoning here

      Dim callback As OcrProgressCallback = dlg.OcrProgressCallback

      Dim allPages As Boolean = CType(args("allPages"), Boolean)
      Try
         ' If we are not using a progress bar, update the description text
         If IsNothing(callback) Then
            dlg.UpdateDescription("Auto zoning the page(s) of the document...")
         End If

         Dim beginTime As DateTime = DateTime.Now

         If (allPages) Then
            _ocrDocument.Pages.AutoZone(callback)
         Else
            _ocrPage.AutoZone(callback)
         End If

         Dim ts As TimeSpan = DateTime.Now - beginTime
         UpdateTimingLabel(New String() {"Auto Zone"}, New TimeSpan() {ts})
      Catch ex As Exception
         ShowError(ex)
         UpdateTimingLabel(Nothing, Nothing)
      Finally
         If IsNothing(callback) Then
            dlg.EndOperation()
         End If

         ' Engine will correct the page deskew before AutoZone or Recognize, so we need to load the page again form the engine.
         GotoPage(CurrentPageIndex)
         ' Update the thumbnail(s)

         RefreshPagesControl(allPages)
      End Try
   End Sub

   Private Sub RecognizeDocument(ByVal allPages As Boolean)
      ' Recognize current or all pages in the document

      ' Setup the arguments for the callback
      Dim args As New Dictionary(Of String, Object)()
      args.Add("allPages", allPages)

      ' Call the process dialog
      Try
         Dim allowProgress As Boolean = _preferencesUseProgressBarsToolStripMenuItem.Checked
         Using dlg As New OcrProgressDialog(allowProgress, "Recognize", New OcrProgressDialog.ProcessDelegate(AddressOf DoRecognize), args)
            dlg.ShowDialog(Me)
         End Using
      Catch ex As Exception
         ShowError(ex)
      Finally
         ' Re-paint current page to show new zones
         _viewerControl.ZonesUpdated()
         UpdateUIState()
      End Try
   End Sub

   Private Sub DoRecognize(ByVal dlg As OcrProgressDialog, ByVal args As Dictionary(Of String, Object))
      ' Perform auto-zoning here

      Dim callback As OcrProgressCallback = dlg.OcrProgressCallback

      Dim allPages As Boolean = CBool(args("allPages"))

      Try
         ' If we are not using a progress bar, update the description text
         If callback Is Nothing Then
            dlg.UpdateDescription("Recognizing the page(s) of the document...")
         End If

         Dim beginTime As DateTime = DateTime.Now

         If allPages Then
            _ocrDocument.Pages.Recognize(callback)
         Else
            _ocrPage.Recognize(callback)
         End If

         Dim ts As TimeSpan = DateTime.Now - beginTime
         UpdateTimingLabel(New String() {"Recognize"}, New TimeSpan() {ts})
      Catch ex As Exception
         ShowError(ex)
         UpdateTimingLabel(Nothing, Nothing)
      Finally
         If callback Is Nothing Then
            dlg.EndOperation()
         End If

         ' Engine will correct the page deskew before AutoZone or Recognize, so we need to load the page again form the engine.
         GotoPage(CurrentPageIndex)
         ' Update the thumbnail(s)
         RefreshPagesControl(allPages)
      End Try
   End Sub

   Private Sub SaveDocument()
      ' Get the last format, options and document file name selected by the user
      Dim docWriter As DocumentWriter = _ocrEngine.DocumentWriterInstance

      Dim settings As New My.MySettings

      If Not _isCustomFileName Then
         settings.DocumentFileName = _filename
      End If


      Dim initialFormat As DocumentFormat = DocumentFormat.Pdf

      If Not String.IsNullOrEmpty(settings.Format) Then
         Try
            initialFormat = CType([Enum].Parse(GetType(DocumentFormat), settings.Format), DocumentFormat)
         Catch
         End Try
      End If

      If Not String.IsNullOrEmpty(settings.FormatOptionsXml) Then
         ' Set the document writer options from the last one we saved
         Try
            Dim buffer As Byte() = Encoding.Unicode.GetBytes(settings.FormatOptionsXml)
            Using ms As New MemoryStream(buffer)
               docWriter.LoadOptions(ms)
            End Using
         Catch
         End Try
      End If

      If Not String.IsNullOrEmpty(settings.EngineFormatName) Then
         If _ocrEngine.DocumentManager.IsEngineFormatSupported(settings.EngineFormatName) Then
            _ocrEngine.DocumentManager.EngineFormat = settings.EngineFormatName
         End If
      End If

      ' Show the save dialog
      Using dlg As New OcrMultiEngineDemo.SaveDocumentDialog(_ocrDocument, initialFormat, settings.DocumentFileName, _isCustomFileName, _outputDir, _viewDocument)
         If dlg.ShowDialog(Me) = DialogResult.OK Then
            ' Saved OK, save the last format, options and document file name used
            _viewDocument = dlg.SelectedViewDocument
            settings.Format = dlg.SelectedFormat.ToString()

            Using ms As New MemoryStream()
               docWriter.SaveOptions(ms)
               settings.FormatOptionsXml = Encoding.Unicode.GetString(ms.ToArray())
            End Using

            If _ocrEngine.DocumentManager.EngineFormat IsNot Nothing Then
               settings.EngineFormatName = _ocrEngine.DocumentManager.EngineFormat
            End If
            settings.DocumentFileName = dlg.SelectedFileName
            settings.Save()

            _isCustomFileName = dlg.IsCustomFileName

            If _isCustomFileName Then
               _outputDir = dlg.OutputDir
            End If

            ' Save the document
            SaveDocument(dlg.SelectedFileName, dlg.SelectedFormat)
         End If
      End Using
   End Sub

   Private Sub SaveDocument(ByVal documentFileName As String, ByVal format As DocumentFormat)
      ' Save the document

      ' Setup the arguments for the callback
      Dim args As New Dictionary(Of String, Object)()
      args.Add("documentFileName", documentFileName)
      args.Add("format", format)

      ' Call the process dialog
      Try
         Dim allowProgress As Boolean = _preferencesUseProgressBarsToolStripMenuItem.Checked
         Using dlg As New OcrProgressDialog(allowProgress, "Save", New OcrProgressDialog.ProcessDelegate(AddressOf DoSave), args)
            dlg.ShowDialog(Me)
         End Using
      Catch ex As Exception
         ShowError(ex)
      Finally
         ' Re-paint current page to show new zones
         _viewerControl.ZonesUpdated()
         UpdateUIState()
      End Try
   End Sub

   Private Sub DoSave(ByVal dlg As OcrProgressDialog, ByVal args As Dictionary(Of String, Object))
      ' Perform save here

      Dim callback As OcrProgressCallback = dlg.OcrProgressCallback

      Try
         Dim documentFileName As String = TryCast(args("documentFileName"), String)
         Dim format As DocumentFormat = CType(args("format"), DocumentFormat)

         If (format = DocumentFormat.Ltd AndAlso File.Exists(documentFileName)) Then
            File.Delete(documentFileName)
         End If

         ' This could be called without any pages being recognized. In this case, recognize
         ' the document before saving it
         Dim isRecognizeRequired As Boolean = True
         For Each ocrPage As IOcrPage In _ocrDocument.Pages
            If ocrPage.IsRecognized Then
               isRecognizeRequired = False
               Exit For
            End If
         Next

         Dim recognizeTimeSpan As New TimeSpan()

         If isRecognizeRequired Then
            ' Recognize before saving

            ' If we are not using a progress bar, update the description text
            If callback Is Nothing Then
               dlg.UpdateDescription("Recognizing the page(s) of the document...")
            End If

            If Not dlg.IsCanceled Then
               Dim beginTime As DateTime = DateTime.Now
               _ocrDocument.Pages.Recognize(callback)
               recognizeTimeSpan = DateTime.Now - beginTime

               ' Engine will correct the page deskew before AutoZone or Recognize, so we need to load the page again form the engine.
               GotoPage(CurrentPageIndex)

               ' Update the thumbnail(s)
               RefreshPagesControl(True)
            End If
         End If

         ' If we are not using a progress bar, update the description text
         If callback Is Nothing Then
            dlg.UpdateDescription("Saving the result document...")
         End If

         Dim saveTimeSpan As New TimeSpan()

         ' If it has not been canceled, save the document
         If Not dlg.IsCanceled Then
            Dim beginTime As DateTime = DateTime.Now
            _ocrDocument.Save(documentFileName, format, callback)
            saveTimeSpan = DateTime.Now - beginTime
         End If

         If Not dlg.IsCanceled Then
            If isRecognizeRequired Then
               UpdateTimingLabel(New String() {"Recognize", "Save Document"}, New TimeSpan() {recognizeTimeSpan, saveTimeSpan})
            Else
               UpdateTimingLabel(New String() {"Save Document"}, New TimeSpan() {saveTimeSpan})
            End If
         End If

         ' In the Plus engine, if the image DPI is not compatible with the engine,
         ' the engine will automatically change it, so check for that and get the
         ' the image from the engine if this is the case
         If _viewerControl.RasterImage IsNot Nothing AndAlso _ocrPage IsNot Nothing Then
            If _viewerControl.RasterImage.XResolution <> _ocrPage.DpiX OrElse _viewerControl.RasterImage.YResolution <> _ocrPage.DpiY Then
               GotoPage(CurrentPageIndex)
            End If
         End If

         ' If it has not been canceled, show the final document (if applicable)
         If Not dlg.IsCanceled AndAlso _viewDocument Then
            ' Put some delay before loading the saved file since Windows 7 is a little slower in creating the 
            ' documents specially the EMF format.
            System.Threading.Thread.Sleep(1000)
            Process.Start(documentFileName)
         End If
      Catch ex As Exception
         ShowError(ex)
         UpdateTimingLabel(Nothing, Nothing)
      Finally
         If callback Is Nothing Then
            dlg.EndOperation()
         End If
      End Try
   End Sub

   Private Sub LoadZones(ByVal loadAllPagesZones As Boolean)
      ' Load the zones from a disk file
      Using dlg As OpenFileDialog = New OpenFileDialog()
         dlg.Filter = "Zone files (*.ozf)|*.ozf|All Files|*.*"
         If dlg.ShowDialog(Me) = DialogResult.OK Then
            Try
               Using wait As WaitCursor = New WaitCursor()
                  If (Not loadAllPagesZones) Then
                     _ocrPage.LoadZones(dlg.FileName)
                  Else
                     _ocrDocument.LoadZones(dlg.FileName)
                  End If
               End Using

               CheckOmrOptions()
            Catch ex As Exception
               ShowError(ex)
            Finally
               For Each page As IOcrPage In _ocrDocument.Pages
                  page.Unrecognize()
               Next page
               _viewerControl.ZonesUpdated()
               RefreshPagesControl(True)
               UpdateUIState()
            End Try
         End If
      End Using
   End Sub

   Private Sub SaveZones(ByVal saveAllPagesZones As Boolean)
      ' Save the zones to a disk file
      Using dlg As SaveFileDialog = New SaveFileDialog()
         dlg.Filter = "Zone files (*.ozf)|*.ozf|All Files|*.*"
         dlg.DefaultExt = "ozf"
         If dlg.ShowDialog(Me) = DialogResult.OK Then
            Try
               Using wait As WaitCursor = New WaitCursor()
                  If (Not saveAllPagesZones) Then
                     _ocrPage.SaveZones(dlg.FileName)
                  Else
                     _ocrDocument.SaveZones(dlg.FileName)
                  End If
               End Using
            Catch ex As Exception
               ShowError(ex)
            End Try
         End If
      End Using
   End Sub

   Private Structure MyZoneData
      Public Zone As OcrZone
      Dim ZoneCells As OcrZoneCell()

      Public Sub New(ByVal z As OcrZone, ByVal cells As OcrZoneCell())
         Zone = z
         ZoneCells = cells
      End Sub
   End Structure

   Private Sub ShowZoneProperties()
      ' Show the zone properties dialog
      ' to let the user update the zones

      ' Get the selected zone from the viewer control
      Dim selectedZoneIndex As Integer = _viewerControl.SelectedZoneIndex

      ' Make a copy of the page zones in case the user canceled the dialog
      Dim zones As List(Of MyZoneData) = New List(Of MyZoneData)()
      For Each zone As OcrZone In _ocrPage.Zones
         Dim cells As OcrZoneCell() = Nothing

         If zone.ZoneType = OcrZoneType.Table Then
            cells = _ocrPage.Zones.GetZoneCells(zone)
         End If

         zones.Add(New MyZoneData(zone, cells))
      Next zone
      Using dlg As ZonePropertiesDialog = New ZonePropertiesDialog(_ocrEngine, _ocrPage, _viewerControl, selectedZoneIndex)
         If dlg.ShowDialog(Me) = DialogResult.OK Then
            ' We should mark the page as unrecognized since we updated its zones
            _ocrPage.Unrecognize()

            UpdateUIState()

            RefreshPagesControl(False)
         Else
            ' Restore the old zones
            _ocrPage.Zones.Clear()
            For Each zoneData As MyZoneData In zones
               _ocrPage.Zones.Add(zoneData.Zone)
               If zoneData.ZoneCells IsNot Nothing Then
                  _ocrPage.Zones.SetZoneCells(zoneData.Zone, zoneData.ZoneCells)
               End If
            Next
         End If

         ' Let the viewer control know that the zones has been updated
         _viewerControl.ZonesUpdated()
      End Using

      CheckOmrOptions()
   End Sub

   Private Sub ConvertLD()
      ' Get the last format, options and document file name selected by the user
      Dim docWriter As DocumentWriter = _ocrEngine.DocumentWriterInstance

      Dim initialFormat As DocumentFormat = DocumentFormat.Pdf

      If Not (String.IsNullOrEmpty(My.Settings.Format)) Then
         Try
            initialFormat = CType(System.Enum.Parse(GetType(DocumentFormat), My.Settings.Format), DocumentFormat)
         Catch
         End Try
      End If

      If Not (String.IsNullOrEmpty(My.Settings.FormatOptionsXml)) Then
         ' Set the document writer options from the last one we saved
         Try
            Dim buffer() As Byte = Encoding.Unicode.GetBytes(My.Settings.FormatOptionsXml)
            Using ms As New MemoryStream(buffer)
               docWriter.LoadOptions(ms)
            End Using
         Catch
         End Try
      End If

      ' Show the convert LTD dialog
      Using dlg As New ConvertLdDialog(_ocrDocument, docWriter, initialFormat, My.Settings.LdFileName, _viewDocument)
         If (dlg.ShowDialog(Me) = DialogResult.OK) Then
            ' Saved OK, save the last format, options and document file name used
            _viewDocument = dlg.SelectedViewDocument
            My.Settings.Format = dlg.SelectedFormat.ToString()
            My.Settings.LdFileName = dlg.SelectedInputFileName

            Using ms As New MemoryStream()
               docWriter.SaveOptions(ms)
               My.Settings.FormatOptionsXml = Encoding.Unicode.GetString(ms.ToArray())
            End Using

            My.Settings.Save()

            ' Convert the LTD file
            Try
               Using wait As New WaitCursor()
                  docWriter.Convert(dlg.SelectedInputFileName, dlg.SelectedOutputFileName, dlg.SelectedFormat)
                  If (_viewDocument) Then
                     ' Put some delay before loading the saved file since Windows 7 is a little slower in creating the 
                     ' documents specially the EMF format.
                     System.Threading.Thread.Sleep(1000)
                     Process.Start(dlg.SelectedOutputFileName)
                  End If
               End Using
            Catch ex As Exception
               ShowError(ex)
            End Try
         End If
      End Using
   End Sub

   Private Sub DoUpdateTimingLabel(ByVal str As String)
      _timingToolStripStatusLabel.Text = str
   End Sub

   Private Delegate Sub UpdateTimingLabelDelegate(ByVal str As String)

   Private Sub UpdateTimingLabel(ByVal labels() As String, ByVal times() As TimeSpan)
      Dim str As String

      If Not IsNothing(labels) Then
         Dim sb As New StringBuilder
         For i As Integer = 0 To labels.Length - 1
            sb.AppendFormat("{0}: {1} (s)", labels(i), times(i).TotalSeconds.ToString("F03"))
            If (i < (labels.Length - 1)) Then
               sb.Append(" - ")
            End If
         Next

         str = sb.ToString()
      Else
         str = String.Empty
      End If

      If (InvokeRequired) Then
         BeginInvoke(New UpdateTimingLabelDelegate(AddressOf DoUpdateTimingLabel), New Object() {str})
      Else
         DoUpdateTimingLabel(str)
      End If
   End Sub

   Private Sub DoShowError(ByVal ex As Exception)
      ' Shows an error, check if the exception is an OCR, raster or general one
      If TypeOf ex Is OcrException Then
         Dim ocr As OcrException = CType(ex, OcrException)
         Messager.ShowError(Me, String.Format("OCR Error\n\nCode: {0}\n\n{1}", ocr.Code, ocr.Message))
         Return
      End If

      If TypeOf ex Is OcrComponentMissingException Then
         Dim ocrComponent As OcrComponentMissingException = CType(ex, OcrComponentMissingException)
         Messager.ShowError(Me, String.Format("OCR Component Missing\n\n{0}\n\nUse 'Engine/Componets' from the menu to show the available components and instructions of how to install the additional components of this OCR engine.", ocrComponent.Message))
         Return
      End If

      If TypeOf ex Is RasterException Then
         Dim raster As RasterException = CType(ex, RasterException)
         Messager.ShowError(Me, String.Format("LEADTOOLS Error\n\nCode: {0}\n\n{1}", raster.Code, raster.Message))
         Return
      End If

      Messager.ShowError(Me, ex)
   End Sub

   Private Delegate Sub ShowErrorDelegate(ByVal ex As Exception)

   Private Sub ShowError(ByVal ex As Exception)
      If (InvokeRequired) Then
         BeginInvoke(New ShowErrorDelegate(AddressOf DoShowError), New Object() {ex})
      Else
         DoShowError(ex)
      End If
   End Sub

   Private Sub _fileExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _fileExitToolStripMenuItem.Click
      Close()
   End Sub

   Private Function HasOmrZones() As Boolean
      For Each ocrPage As IOcrPage In _ocrDocument.Pages
         For Each ocrZone As OcrZone In ocrPage.Zones
            If ocrZone.ZoneType = OcrZoneType.Omr Then
               Return True
            End If
         Next
      Next

      Return False
   End Function

   Public Shared Function ConvertColor(ByVal color As RasterColor) As Color
      Return RasterColorConverter.ToColor(color)
   End Function

   Public Shared Function ConvertColor(ByVal color As Color) As RasterColor
      Return RasterColorConverter.FromColor(color)
   End Function

   Private Sub CheckOmrOptions()
      If _omrOptionsDismissed OrElse IsNothing(_ocrDocument) OrElse _ocrDocument.Pages.Count = 0 Then
         Return
      End If

      If HasOmrZones() Then
         _omrOptionsDismissed = True

         Using dlg As New OcrOmrOptionsDialog(_ocrEngine)
            dlg.ShowDialog(Me)
         End Using
      End If
   End Sub

   Private Sub _saveAllPagesZonesToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _saveAllPagesZonesToolStripMenuItem.Click
      SaveZones(True)
   End Sub

   Private Sub _loadAllPagesZonesToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _loadAllPagesZonesToolStripMenuItem.Click
      LoadZones(True)
   End Sub

   Private Sub _clearAllPagesZonesToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _clearAllPagesZonesToolStripMenuItem.Click
      For Each page As IOcrPage In _ocrDocument.Pages
         page.Zones.Clear()
         page.Unrecognize()
      Next page

      ' Re-paint current page to show new zones
      _viewerControl.ZonesUpdated()
      UpdateUIState()
      ' Update the thumbnail(s)
      RefreshPagesControl(True)
   End Sub

   Private Sub _pagesDetectPageLanguagesToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles _pagesDetectPageLanguagesToolStripMenuItem.Click
      Using dlg As New DetectPageLanguagesDialog(_ocrEngine, _ocrPage)
         dlg.ShowDialog(Me)
         _viewerControl.ZonesUpdated()
      End Using
   End Sub

   Private Sub UpdateActiveSpellCheckerLabel(spellCheckEngine As OcrSpellCheckEngine)
      _activeSpellCheckerToolStripStatusLabel.Text = [Enum].GetName(GetType(OcrSpellCheckEngine), spellCheckEngine)
   End Sub

   Private Sub MainForm_Resize(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Resize
      If (_viewerControl.RasterImage IsNot Nothing) Then
         _viewerControl.ZonesUpdated()
      End If
   End Sub

   Private Sub _unwarpToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _unwarpToolStripMenuItem.Click
      UnWarpActive = True
      _mainMenuStrip.Enabled = False
      _mainToolStrip.Enabled = False
      _viewerControl.UpdateUIState()
      _pagesControl.UpdateUIState()
      _viewerControl.InteractiveMode = ViewerControlInteractiveMode.SelectMode
      _viewerControl.ZonesUpdated()

      Dim unwarpDlg As UnWarpDialog = New UnWarpDialog(Me, _viewerControl)
      AddHandler unwarpDlg.Action, AddressOf unwarpDlg_Action
      unwarpDlg.Show()
   End Sub

   Private Sub unwarpDlg_Action(ByVal sender As Object, ByVal e As ActionEventArgs)
      Dim ocrPage As IOcrPage = _ocrDocument.Pages(CurrentPageIndex)

      If ocrPage IsNot Nothing Then
         If (Not UnWarpActive) Then
            _mainMenuStrip.Enabled = True
            _mainToolStrip.Enabled = True
            _viewerControl.UpdateUIState()
            _pagesControl.UpdateUIState()
         End If
      End If

      _viewerControl.ZonesUpdated()
      Dim unwarpDlg As UnWarpDialog = TryCast(e.Data, UnWarpDialog)
      If Not unwarpDlg.IsDisposed And Not unwarpDlg.OkButtonPressed Then
         Return
      End If

      ' Called from the UnWarpDialog when a OK or Apply buttons clicked
      Select Case e.Action
         Case "UnWarpCommand"
            Using wait As New WaitCursor()
               ocrPage.Zones.Clear()
               ocrPage.Unrecognize()
               ocrPage.SetRasterImage(_viewerControl.RasterImageViewer.Image)

               ' Re-paint current page
               _viewerControl.ZonesUpdated()
               UpdateUIState()
               ' Update the thumbnail(s)
               RefreshPagesControl(True)
               GotoPage(CurrentPageIndex)
            End Using
            Exit Select
      End Select

      RemoveHandler unwarpDlg.Action, AddressOf unwarpDlg_Action
      UnWarpActive = False
      _mainMenuStrip.Enabled = True
      _mainToolStrip.Enabled = True
      _viewerControl.UpdateUIState()
      _pagesControl.UpdateUIState()
   End Sub
End Class


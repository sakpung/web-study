' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System.Collections.Generic
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports System.IO
Imports System.Diagnostics
Imports System

Imports Leadtools
Imports Leadtools.Twain
Imports Leadtools.Codecs
Imports Leadtools.Controls
Imports Leadtools.ImageProcessing
Imports Leadtools.ImageProcessing.Core
Imports Leadtools.ImageProcessing.Color
Imports Leadtools.ImageProcessing.Effects
Imports Leadtools.Ocr
Imports Leadtools.Document.Writer
Imports Leadtools.Demos.Dialogs
Imports Leadtools.Drawing
Imports System.ComponentModel

Namespace OcrDemo

   Partial Public Class MainForm
      Inherits Form
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

      Private _omrOptionsDismissed As Boolean
      Private _saveAfterRecognize As Boolean
      Private _ocrDocumentFilePath As String
      Private _openInitialPath As String = String.Empty
      Private _fileName As String = String.Empty
      Private Shared _customFileName As Boolean = False ' Has user given own file name for save.
      Private Shared _documentMode As Boolean = False
      Private Shared _outputDir As String = String.Empty

      Public Shared PerspectiveDeskewActive As Boolean = False
      Public Shared UnWarpActive As Boolean = False

      Public Sub New()
         InitializeComponent()

         _mainSplitContainer.Panel1Collapsed = True
         _viewerVertSplitContainer.Panel2Collapsed = True

         ' Setup the caption for this demo
         Messager.Caption = "VB.NET OCR Demo"

         ' Initialize the RasterCodecs object
         _rasterCodecs = New RasterCodecs()

         ' Use the new RasterizeDocumentOptions to default loading document files at 300 DPI
         _rasterCodecs.Options.RasterizeDocument.Load.XResolution = 300
         _rasterCodecs.Options.RasterizeDocument.Load.YResolution = 300
         _rasterCodecs.Options.Pdf.Load.EnableInterpolate = True
         _rasterCodecs.Options.Load.AutoFixImageResolution = True
         ' See if we have a scanning session
         Try
#If Not LEADTOOLS_V19_OR_LATER Then
            If TwainSession.IsAvailable(Me) Then
#Else
            If TwainSession.IsAvailable(Me.Handle) Then
#End If
               _twainSession = New TwainSession()
#If Not LEADTOOLS_V19_OR_LATER Then
                  _twainSession.Startup(Me, "LEAD Technologies, Inc.", "LEAD Test Applications", "Version 1.0", "TWAIN Test Application", TwainStartupFlags.None)
#Else
               _twainSession.Startup(Me.Handle, "LEAD Technologies, Inc.", "LEAD Test Applications", "Version 1.0", "TWAIN Test Application", TwainStartupFlags.None)
#End If
               AddHandler _twainSession.AcquirePage, AddressOf _twainSession_AcquirePage
            End If

         Catch ex As TwainException
            If ex.Code = TwainExceptionCode.InvalidDll Then
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

         _preferencesUseProgressBarsToolStripMenuItem.Checked = True
         _omrOptionsDismissed = False
         _saveAfterRecognize = False
      End Sub

      Protected Overrides Sub OnLoad(e As EventArgs)
         If Not DesignMode Then
            BeginInvoke(New MethodInvoker(AddressOf Startup))
         End If

         MyBase.OnLoad(e)
      End Sub

      Private Sub Startup()
         Dim settings As New Settings()


         Try
            _ocrEngine = OcrEngineManager.CreateEngine(OcrEngineType.LEAD, False)
            _ocrEngine.Startup(_rasterCodecs, Nothing, Nothing, Nothing)

            UpdateActiveSpellCheckerLabel(If((_ocrEngine.SpellCheckManager IsNot Nothing), _ocrEngine.SpellCheckManager.SpellCheckEngine, OcrSpellCheckEngine.None))

            ' Set document writer options
            SetDocumentWriterOptions()
            UpdateUIState()

            Application.DoEvents()
         Catch ex As System.Exception
            Dim message As String = String.Format("{0}. This demo cannot start without OCR capabilities.", ex.Message)
            MessageBox.Show(Me, message, "Engine Startup", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Close()
            Return
         End Try

         ' Load the default document
         Dim defaultDocumentFile As String = Path.Combine(DemosGlobal.ImagesFolder, "ocr1.tif")

         If File.Exists(defaultDocumentFile) Then
            OpenDocument(defaultDocumentFile, Nothing, 1, 1)
         End If
      End Sub

      Protected Overrides Sub OnFormClosed(e As FormClosedEventArgs)
         ' Clean up

         ' Shutdown down if started
         If _twainSession IsNot Nothing Then
            RemoveHandler _twainSession.AcquirePage, AddressOf _twainSession_AcquirePage
            _twainSession.Shutdown()
            _twainSession = Nothing
         End If

         ' Save the last setting
         Dim settings As New Settings()
         settings.Save()

         If _ocrPage IsNot Nothing Then
            If Not IsOcrDocumentInMemory() Then
               _ocrPage.Dispose()
            End If
            _ocrPage = Nothing
         End If

         If _ocrDocument IsNot Nothing Then
            _ocrDocument.Dispose()
            _ocrDocument = Nothing
         End If

         ' Dispose the OCR engine (this will call Shutdown as well)
         If _ocrEngine IsNot Nothing Then
            _ocrEngine.Dispose()
            _ocrEngine = Nothing
         End If

         If _rasterCodecs IsNot Nothing Then
            _rasterCodecs.Dispose()
            _rasterCodecs = Nothing
         End If

         MyBase.OnFormClosed(e)
      End Sub

      Private Sub SetDocumentWriterOptions()
         Dim docOptions As DocDocumentOptions = TryCast(_ocrEngine.DocumentWriterInstance.GetOptions(DocumentFormat.Doc), DocDocumentOptions)
         docOptions.TextMode = DocumentTextMode.Framed

         Dim docxOptions As DocxDocumentOptions = TryCast(_ocrEngine.DocumentWriterInstance.GetOptions(DocumentFormat.Docx), DocxDocumentOptions)
         docxOptions.TextMode = DocumentTextMode.Framed

         Dim rtfOptions As RtfDocumentOptions = TryCast(_ocrEngine.DocumentWriterInstance.GetOptions(DocumentFormat.Rtf), RtfDocumentOptions)
         rtfOptions.TextMode = DocumentTextMode.Framed

         Dim altoXmlOptions As AltoXmlDocumentOptions = TryCast(_ocrEngine.DocumentWriterInstance.GetOptions(DocumentFormat.AltoXml), AltoXmlDocumentOptions)
         altoXmlOptions.Formatted = True
      End Sub

      Private Sub _fileToolStripMenuItem_DropDownOpening(sender As Object, e As EventArgs) Handles _fileToolStripMenuItem.DropDownOpening
         ' Update the UI state of the File menu items

         If _twainSession Is Nothing Then
            _fileScanToolStripMenuItem.Enabled = False
         End If
      End Sub

      Private Sub _fileOpenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles _fileOpenToolStripMenuItem.Click
         OpenDocument()
      End Sub

      Private Sub _fileConvertLDToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles _fileConvertLDToolStripMenuItem.Click
         ConvertLD()
      End Sub

      Private Sub _scanSelectSourceToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles _scanSelectSourceToolStripMenuItem.Click
         ' Select the TWAIN source
         Try
            _twainSession.SelectSource(String.Empty)
         Catch ex As Exception
            ShowError(ex)
         End Try
      End Sub

      Private Sub _scanAcquireToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles _scanAcquireToolStripMenuItem.Click
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

      Private Sub _twainSession_AcquirePage(sender As Object, e As TwainAcquirePageEventArgs)
         ' Add the page to the OCR engine
         Try
            InsertPages(Nothing, 1, 1, e.Image, -1)
         Catch ex As Exception
            ShowError(ex)
            UpdateTimingLabel(Nothing, Nothing)
         End Try
      End Sub

      Private Sub _editToolStripMenuItem_DropDownOpening(sender As Object, e As EventArgs) Handles _editToolStripMenuItem.DropDownOpening
         ' Update the UI state of the Edit menu items

         _editCopyToolStripMenuItem.Enabled = _ocrPage IsNot Nothing
         _editPasteToolStripMenuItem.Enabled = RasterClipboard.IsReady
      End Sub

      Private Sub _editCopyToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles _editCopyToolStripMenuItem.Click
         ' Copy the current RasterImage to the clipboard
         Dim image As RasterImage = _viewerControl.RasterImage
         If image IsNot Nothing Then
            Try
               Using wait As New WaitCursor()
                  RasterClipboard.Copy(Me.Handle, image, RasterClipboardCopyFlags.Empty Or RasterClipboardCopyFlags.Dib Or RasterClipboardCopyFlags.Palette)
               End Using
            Catch ex As Exception
               ShowError(ex)
            End Try
         End If
      End Sub

      Private Sub _editPasteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles _editPasteToolStripMenuItem.Click
         ' Paste the image in the clipboard (if any) as a new page in the current document

         If RasterClipboard.IsReady Then
            Try
               Using wait As New WaitCursor()
                  Dim image As RasterImage = RasterClipboard.Paste(Me.Handle)
                  InsertPages(Nothing, 1, 1, image, -1)
               End Using
            Catch ex As Exception
               ShowError(ex)
               UpdateTimingLabel(Nothing, Nothing)
            End Try
         End If
      End Sub

      Private Sub _viewToolStripMenuItem_DropDownOpening(sender As Object, e As EventArgs) Handles _viewToolStripMenuItem.DropDownOpening
         ' Update the UI state of the View menu items

         Dim isOcrPageAvailable As Boolean = _ocrPage IsNot Nothing

         _viewZoomOutToolStripMenuItem.Enabled = isOcrPageAvailable
         _viewZoomInToolStripMenuItem.Enabled = isOcrPageAvailable

         _viewFitWidthToolStripMenuItem.Enabled = isOcrPageAvailable
         _viewFitPageToolStripMenuItem.Enabled = isOcrPageAvailable

         _viewFitWidthToolStripMenuItem.Checked = _viewerControl.CurrentSizeMode = ControlSizeMode.FitWidth
         _viewFitPageToolStripMenuItem.Checked = _viewerControl.CurrentSizeMode = ControlSizeMode.Fit
      End Sub

      Private Sub _viewZoomOutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles _viewZoomOutToolStripMenuItem.Click
         _viewerControl.ZoomViewer(True)
      End Sub

      Private Sub _viewZoomInToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles _viewZoomInToolStripMenuItem.Click
         _viewerControl.ZoomViewer(False)
      End Sub

      Private Sub _viewFitWidthToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles _viewFitWidthToolStripMenuItem.Click
         _viewerControl.FitPage(True)
         _viewerControl.ZonesUpdated()
      End Sub

      Private Sub _viewFitPageToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles _viewFitPageToolStripMenuItem.Click
         _viewerControl.FitPage(False)
      End Sub

      Private Sub _engineSettingsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles _engineSettingsToolStripMenuItem.Click
         ' Show the dialog to let the user change any of the engine settings
         Using dlg As New EngineSettingsDialog(_ocrEngine)
            dlg.ShowDialog(Me)
         End Using
      End Sub

      Private Sub _engineComponentsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles _engineComponentsToolStripMenuItem.Click
         ' Show the dialog to let the user see the OCR components installed on this system
         Using dlg As New OcrEngineComponentsDialog(_ocrEngine)
            dlg.ShowDialog(Me)
         End Using
      End Sub

      Private Sub _engineLanguagesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles _engineLanguagesToolStripMenuItem.Click
         ' Show the dialog to let the user change the current enabled languages
         Dim moveRightImage As Image = LoadImageFromResource("MoveRight.png")
         Dim moveLeftImage As Image = LoadImageFromResource("MoveLeft.png")
         Dim moveTopImage As Image = LoadImageFromResource("MoveTop.png")
         Using dlg As New EnableLanguagesDialog(_ocrEngine, moveRightImage, moveLeftImage, moveTopImage)
            dlg.ShowDialog(Me)
         End Using
      End Sub

      Private Function LoadImageFromResource(resourceName As String) As Image
         Dim stream As Stream = [GetType]().Assembly.GetManifestResourceStream(String.Format("{0}.Resources.{1}", [GetType]().[Namespace], resourceName))
         If stream Is Nothing Then
            Return Nothing
         End If

         Dim image__1 As Image = Image.FromStream(stream)
         Return image__1
      End Function

      Private Sub _pageToolStripMenuItem_DropDownOpening(sender As Object, e As EventArgs) Handles _pageToolStripMenuItem.DropDownOpening
         ' Update the UI state of the Pages menu items

         Dim isOcrPageAvailable As Boolean = _ocrPage IsNot Nothing

         _pageSaveProcessingImageToDiskToolStripMenuItem.Enabled = isOcrPageAvailable
         _pageDetectPageLanguagesToolStripMenuItem.Enabled = isOcrPageAvailable
         _pageCloseCurrentPageToolStripMenuItem.Enabled = isOcrPageAvailable AndAlso Not IsOcrDocumentInMemory()
         _pageSaveRecognizedDataAsXmlToolStripMenuItem.Enabled = isOcrPageAvailable AndAlso _ocrPage.IsRecognized
      End Sub

      Private Sub _processToolStripMenuItem_DropDownOpening(sender As Object, e As EventArgs) Handles _processToolStripMenuItem.DropDownOpening
         ' Update 'Process' menu items
         Dim isInMemory As Boolean = IsOcrDocumentInMemory()
         Dim isOcrPageAvailable As Boolean = _ocrPage IsNot Nothing

         _processAllPagesToolStripMenuItem.Enabled = isInMemory
         _processFlipToolStripMenuItem.Enabled = isOcrPageAvailable
         _processReverseToolStripMenuItem.Enabled = isOcrPageAvailable
         _processRotate90ClockwiseToolStripMenuItem.Enabled = isOcrPageAvailable
         _processRotate90CounterClockwiseToolStripMenuItem.Enabled = isOcrPageAvailable
         _processPreprocessToolStripMenuItem.Enabled = isOcrPageAvailable
         _documentCleanupToolStripMenuItem.Enabled = isOcrPageAvailable
         _binarizationToolStripMenuItem.Enabled = isOcrPageAvailable
         _brightnessToolStripMenuItem.Enabled = isOcrPageAvailable
         _processPageSplitterToolStripMenuItem.Enabled = isOcrPageAvailable
         _processExpandContentToolStripMenuItem.Enabled = isOcrPageAvailable
         _processLineRemoveToolStripMenuItem.Enabled = (isOcrPageAvailable AndAlso _ocrPage.BitsPerPixel = 1)

         _manualPerspectiveToolStripMenuItem.Enabled = isOcrPageAvailable
         _inversePerspectiveToolStripMenuItem.Enabled = isOcrPageAvailable
         _perspectiveDeskewToolStripMenuItem.Enabled = isOcrPageAvailable
         _unwarpToolStripMenuItem.Enabled = isOcrPageAvailable AndAlso (_ocrPage.BitsPerPixel = 1 Or _ocrPage.BitsPerPixel = 8 Or _ocrPage.BitsPerPixel = 24 Or _ocrPage.BitsPerPixel = 32)
      End Sub

      Private Sub _pagesSaveProcessingImageToDiskToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles _pageSaveProcessingImageToDiskToolStripMenuItem.Click
         Dim tifFileName As String = Nothing

         Using dlg As New SaveFileDialog()
            dlg.Title = "Save processing image for this page as TIF"
            dlg.Filter = "TIFF Files (*.tif;*.tiff)|*.tif;*.tiff|All Files|*.*"
            dlg.DefaultExt = "tif"
            If dlg.ShowDialog(Me) = DialogResult.OK Then
               tifFileName = dlg.FileName
            End If
         End Using

         If tifFileName Is Nothing Then
            Return
         End If

         Try
            Using image As RasterImage = _ocrPage.GetRasterImage(OcrPageType.Processing)
               _rasterCodecs.Save(image, tifFileName, RasterImageFormat.CcittGroup4, 1)
            End Using
         Catch ex As Exception
            ShowError(ex)
         End Try
      End Sub

      Private Sub _pagesDetectPageLanguagesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles _pageDetectPageLanguagesToolStripMenuItem.Click
         Using dlg As New DetectPageLanguagesDialog(_ocrEngine, _ocrPage)
            dlg.ShowDialog(Me)
            _viewerControl.ZonesUpdated()
         End Using
      End Sub

      Private Sub _pageCloseCurrentPageToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles _pageCloseCurrentPageToolStripMenuItem.Click
         CloseCurrentOcrPage()
      End Sub

      Private Sub _processAllPagesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles _processAllPagesToolStripMenuItem.Click
         ' Switch the process all pages or single page option
         _processAllPagesToolStripMenuItem.Checked = Not _processAllPagesToolStripMenuItem.Checked
      End Sub

      Private Sub _processFlipToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles _processFlipToolStripMenuItem.Click
         ' Flip the current page or all pages
         FlipDocument(False)
      End Sub

      Private Sub _processReverseToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles _processReverseToolStripMenuItem.Click
         ' Reverse (flip horizontal) the current page or pages
         FlipDocument(True)
      End Sub

      Private Sub _processRotate90ClockwiseToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles _processRotate90ClockwiseToolStripMenuItem.Click
         ' Rotate the current page or pages 90 degrees clockwise
         RotateDocument(90)
      End Sub

      Private Sub _processRotate90CounterClockwiseToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles _processRotate90CounterClockwiseToolStripMenuItem.Click
         ' Rotate the current page or pages 90 degrees counter-clockwise
         RotateDocument(-90)
      End Sub

      Private Sub _processPreprocessGetDeskewAngleToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles _processPreprocessGetDeskewAngleToolStripMenuItem.Click
         ShowPreprocessingParameters(OcrAutoPreprocessPageCommand.Deskew)
      End Sub

      Private Sub _processPreprocessGetRotateAngleToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles _processPreprocessGetRotateAngleToolStripMenuItem.Click
         ShowPreprocessingParameters(OcrAutoPreprocessPageCommand.Rotate)
      End Sub

      Private Sub _processPreprocessIsInvertedToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles _processPreprocessIsInvertedToolStripMenuItem.Click
         ShowPreprocessingParameters(OcrAutoPreprocessPageCommand.Invert)
      End Sub

      Private Sub ShowPreprocessingParameters(command As OcrAutoPreprocessPageCommand)
         Dim allPages As Boolean = _processAllPagesToolStripMenuItem.Checked

         Try
            Dim sb As New StringBuilder()

            Using wait As New WaitCursor()
               Select Case command
                  Case OcrAutoPreprocessPageCommand.Deskew
                     If True Then
                        Dim angle As Integer = _ocrPage.GetDeskewAngle()
                        sb.AppendLine("Deskew angle is " & (angle / 10.0).ToString())
                     End If
                     Exit Select

                  Case OcrAutoPreprocessPageCommand.Rotate
                     If True Then
                        Dim angle As Integer = _ocrPage.GetRotateAngle()
                        sb.AppendLine("Rotate angle is " & angle.ToString())
                     End If
                     Exit Select

                  Case OcrAutoPreprocessPageCommand.Invert
                     If True Then
                        Dim isInverted As Boolean = _ocrPage.IsInverted()

                        If isInverted Then
                           sb.AppendLine("Page is inverted")
                        Else
                           sb.AppendLine("Page is not inverted")
                        End If
                     End If
                     Exit Select
               End Select
            End Using

            MessageBox.Show(Me, sb.ToString(), "Pre-processing", MessageBoxButtons.OK, MessageBoxIcon.Information)
         Catch ex As Exception
            ShowError(ex)
         End Try
      End Sub

      Private Sub _processPreprocessDeskewToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles _processPreprocessDeskewToolStripMenuItem.Click
         Preprocess(OcrAutoPreprocessPageCommand.Deskew)
      End Sub

      Private Sub _processPreprocessRotateToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles _processPreprocessRotateToolStripMenuItem.Click
         Preprocess(OcrAutoPreprocessPageCommand.Rotate)
      End Sub

      Private Sub _processPreprocessInvertToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles _processPreprocessInvertToolStripMenuItem.Click
         Preprocess(OcrAutoPreprocessPageCommand.Invert)
      End Sub

      Private Sub _processPreprocessAllToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles _processPreprocessAllToolStripMenuItem.Click
         Preprocess(OcrAutoPreprocessPageCommand.All)
      End Sub

      Private Sub _processAutoCropToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles _processAutoCropToolStripMenuItem.Click
         ' Auto-crop the current page or pages
         RunImageProcessingCommand(New AutoCropCommand())
      End Sub

      Private Sub _processDespeckleToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles _processDespeckleToolStripMenuItem.Click
         ' Despeckle the current page or pages
         RunImageProcessingCommand(New DespeckleCommand())
      End Sub

      Private Sub _processErodeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles _processErodeToolStripMenuItem.Click
         ' Erode the current page or pages
         RunImageProcessingCommand(New BinaryFilterCommand(BinaryFilterCommandPredefined.ErosionOmniDirectional))
      End Sub

      Private Sub _processDilateToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles _processDilateToolStripMenuItem.Click
         ' Dilate the current page or pages
         RunImageProcessingCommand(New BinaryFilterCommand(BinaryFilterCommandPredefined.DilationOmniDirectional))
      End Sub

      Private Sub _processUnditherTextToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles _processUnditherTextToolStripMenuItem.Click
         ' Undither text on current page or pages
         RunImageProcessingCommands(New RasterCommand() {New MedianCommand(3), New MinimumCommand(2)})
      End Sub

      Private Sub _processFixBrokenLettersToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles _processFixBrokenLettersToolStripMenuItem.Click
         ' Fix broken text on current page or pages
         RunImageProcessingCommand(New MinimumCommand(2))
      End Sub

      Private Sub _processLineRemoveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles _processLineRemoveToolStripMenuItem.Click
         Dim horizontalRemoveCommand As New LineRemoveCommand()
         horizontalRemoveCommand.Type = LineRemoveCommandType.Horizontal

         Dim verticalRemoveCommand As New LineRemoveCommand()
         verticalRemoveCommand.Type = LineRemoveCommandType.Vertical

         RunImageProcessingCommands(New RasterCommand() {horizontalRemoveCommand, verticalRemoveCommand})
      End Sub

      Private Sub _processAutoBinarizeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles _processAutoBinarizeToolStripMenuItem.Click
         ' Auto-binarize the current page or pages
         RunImageProcessingCommand(New AutoBinaryCommand())
      End Sub

      Private Sub _processDynamicBinarizeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles _processDynamicBinarizeToolStripMenuItem.Click
         RunImageProcessingCommand(New DynamicBinaryCommand(7, 50))
      End Sub

      Private Sub _processHisogramEqualToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles _processHisogramEqualToolStripMenuItem.Click
         RunImageProcessingCommand(New HistogramEqualizeCommand(HistogramEqualizeType.Yuv))
      End Sub

      Private Sub _processAutoLevelToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles _processAutoLevelToolStripMenuItem.Click
         RunImageProcessingCommand(New AutoColorLevelCommand())
      End Sub

      Private Sub _processContrastBrightnessIntensityToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles _processContrastBrightnessIntensityToolStripMenuItem.Click
         Using dlg As New ContrastBrightnessIntensityDialog(_viewerControl.ImageViewer)
            If dlg.ShowDialog(Me) = DialogResult.OK Then
               RunImageProcessingCommand(dlg.Command)
            End If
         End Using
      End Sub

      Private Sub _processPageSplitterToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles _processPageSplitterToolStripMenuItem.Click
         If Not IsOcrDocumentInMemory() Then
            MessageBox.Show("This function only works in memory mode, please create in-memory OCR document first.", "Page splitter", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
         End If

         Dim allPages As Boolean = _processAllPagesToolStripMenuItem.Checked
         Dim pagesCount As Integer = 1
         Dim firstPageIndex As Integer = 0
         Dim lastPageIndex As Integer = 0
         If allPages Then
            pagesCount = GetOcrDocumentPagesCount()
            lastPageIndex = pagesCount - 1
            If pagesCount > 1 Then
               If MessageBox.Show("This function only works on 1-BPP images, so if any of your document pages is not then it will be converted to 1-BPP, press 'Yes' if you wish to proceed.", "Page splitter", MessageBoxButtons.YesNo, MessageBoxIcon.Information) <> DialogResult.Yes Then
                  Return
               End If
            End If
         Else
            firstPageIndex = _currentPageIndex
            lastPageIndex = _currentPageIndex
            If _viewerControl.ImageViewer.Image IsNot Nothing AndAlso _viewerControl.ImageViewer.Image.BitsPerPixel <> 1 Then
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

      Private Sub _processExpandContentToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles _processExpandContentToolStripMenuItem.Click
         Dim allPages As Boolean = _processAllPagesToolStripMenuItem.Checked
         Dim pagesCount As Integer = 1
         Dim firstPageIndex As Integer = 0
         Dim lastPageIndex As Integer = 0
         If allPages Then
            pagesCount = If(IsOcrDocumentInMemory(), GetOcrDocumentPagesCount(), 1)
            lastPageIndex = pagesCount - 1
            If pagesCount > 1 Then
               If MessageBox.Show("This function only works on 1-BPP images, so if any of your document pages is not then it will be converted to 1-BPP, press 'Yes' if you wish to proceed.", "Page expand content", MessageBoxButtons.YesNo, MessageBoxIcon.Information) <> DialogResult.Yes Then
                  Return
               End If
            End If
         Else
            firstPageIndex = _currentPageIndex
            lastPageIndex = _currentPageIndex
            If _viewerControl.ImageViewer.Image IsNot Nothing AndAlso _viewerControl.ImageViewer.Image.BitsPerPixel <> 1 Then
               If MessageBox.Show("This function only works on 1-BPP images, press 'Yes' to convert the current image to 1-BPP and proceed.", "Page expand content", MessageBoxButtons.YesNo, MessageBoxIcon.Information) <> DialogResult.Yes Then
                  Return
               End If
            End If
         End If

         For i As Integer = firstPageIndex To lastPageIndex
            ' Get the processed 1-BPP image from each OCR page and set it as the original page image
            Dim ocrPage As IOcrPage = Nothing
            If IsOcrDocumentInMemory() Then
               ocrPage = _ocrDocument.Pages(i)
            Else
               ocrPage = _ocrPage
            End If
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
         _viewerControl.InteractiveMode = ViewerControl.ViewerControlInteractiveMode.SelectMode
         _viewerControl.ZonesUpdated()

         Dim perspectiveDlg As New PerspectiveDialog(Me, _viewerControl, True)
         AddHandler perspectiveDlg.Action, AddressOf perspectiveDlg_Action
         perspectiveDlg.Show()
      End Sub

      Private Sub _inversePerspectiveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles _inversePerspectiveToolStripMenuItem.Click
         PerspectiveDeskewActive = True
         _mainMenuStrip.Enabled = False
         _mainToolStrip.Enabled = False
         _viewerControl.UpdateUIState()
         _pagesControl.UpdateUIState()
         _viewerControl.InteractiveMode = ViewerControl.ViewerControlInteractiveMode.SelectMode
         _viewerControl.ZonesUpdated()

         Dim perspectiveDlg As New PerspectiveDialog(Me, _viewerControl, False)
         AddHandler perspectiveDlg.Action, AddressOf perspectiveDlg_Action
         perspectiveDlg.Show()
      End Sub

      Private Sub perspectiveDlg_Action(sender As Object, e As ActionEventArgs)
         Dim isInMemory As Boolean = IsOcrDocumentInMemory()
         Dim ocrPage As IOcrPage = Nothing
         If isInMemory Then
            ocrPage = _ocrDocument.Pages(_currentPageIndex)
         Else
            ocrPage = _ocrPage
         End If

         If ocrPage IsNot Nothing Then
            If (Not PerspectiveDeskewActive) Then
               _mainMenuStrip.Enabled = True
               _mainToolStrip.Enabled = True
               _viewerControl.UpdateUIState()
               _pagesControl.UpdateUIState()
            End If
         End If

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
                  ocrPage.SetRasterImage(_viewerControl.ImageViewer.Image)

                  ' Re-paint current page
                  _viewerControl.ZonesUpdated()
                  UpdateUIState()
                  ' Update the thumbnail(s)
                  RefreshPagesControl(True)
                  GotoPage(_currentPageIndex)
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
         If _viewerControl.ImageViewer.Image IsNot Nothing AndAlso _viewerControl.ImageViewer.Image.BitsPerPixel <> 24 AndAlso _viewerControl.ImageViewer.Image.BitsPerPixel <> 32 Then
            MessageBox.Show("This function only works on 24-BPP and 32-BPP images", "Perspective Deskew", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
         End If

         RunImageProcessingCommand(New PerspectiveDeskewCommand())
      End Sub

      Private Sub _zonesAutoZoneDocumentToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles _zonesAutoZoneDocumentToolStripMenuItem.Click
         AutoZone(True)
      End Sub

      Private Sub _zonesAutoZoneCurrentPageToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles _zonesAutoZoneCurrentPageToolStripMenuItem.Click
         AutoZone(False)
      End Sub

      Private Sub _zonesUpdateZonesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles _zonesUpdateZonesToolStripMenuItem.Click
         ShowZoneProperties()
      End Sub

      Private Sub _zonesLoadZonesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles _zonesLoadZonesToolStripMenuItem.Click
         LoadZones(False)
      End Sub

      Private Sub _zonesSaveZonesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles _zonesSaveZonesToolStripMenuItem.Click
         SaveZones(False)
      End Sub

      Private Sub _saveAllPagesZonesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles _saveAllPagesZonesToolStripMenuItem.Click
         SaveZones(True)
      End Sub

      Private Sub _loadAllPagesZonesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles _loadAllPagesZonesToolStripMenuItem.Click
         LoadZones(True)
      End Sub

      Private Sub _clearAllPagesZonesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles _clearAllPagesZonesToolStripMenuItem.Click
         Dim pagesCount As Integer = 1

         If IsOcrDocumentInMemory() Then
            pagesCount = GetOcrDocumentPagesCount()
         End If

         For i As Integer = 0 To pagesCount - 1
            Dim ocrPage As IOcrPage = Nothing
            If IsOcrDocumentInMemory() Then
               ocrPage = _ocrDocument.Pages(i)
            Else
               ocrPage = _ocrPage
            End If

            If ocrPage IsNot Nothing Then
               ocrPage.Zones.Clear()
               ocrPage.Unrecognize()
            End If
         Next

         ' Re-paint current page to show new zones
         _viewerControl.ZonesUpdated()
         UpdateUIState()
         ' Update the thumbnail(s)
         RefreshPagesControl(True)
      End Sub

      Private Sub _zonesShowZonesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles _zonesShowZonesToolStripMenuItem.Click
         _viewerControl.ShowZones = Not _viewerControl.ShowZones
      End Sub

      Private Sub _zonesShowZoneNamesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles _zonesShowZoneNamesToolStripMenuItem.Click
         _viewerControl.ShowZoneNames = Not _viewerControl.ShowZoneNames
      End Sub

      Private Sub _zonesToolStripMenuItem_DropDownOpening(sender As Object, e As EventArgs) Handles _zonesToolStripMenuItem.DropDownOpening
         ' Update 'Zones' menu items
         Dim isInMemory As Boolean = IsOcrDocumentInMemory()
         Dim isOcrPageAvailable As Boolean = _ocrPage IsNot Nothing

         _zonesAutoZoneDocumentToolStripMenuItem.Enabled = isInMemory AndAlso GetOcrDocumentPagesCount() > 0
         _zonesAutoZoneCurrentPageToolStripMenuItem.Enabled = isOcrPageAvailable
         _zonesUpdateZonesToolStripMenuItem.Enabled = isOcrPageAvailable
         _zonesLoadZonesToolStripMenuItem.Enabled = isOcrPageAvailable
         _zonesSaveZonesToolStripMenuItem.Enabled = isOcrPageAvailable AndAlso _ocrPage.Zones.Count > 0
         _loadAllPagesZonesToolStripMenuItem.Enabled = isInMemory AndAlso GetOcrDocumentPagesCount() > 0
         _saveAllPagesZonesToolStripMenuItem.Enabled = isInMemory AndAlso GetOcrDocumentPagesCount() > 0
         _clearAllPagesZonesToolStripMenuItem.Enabled = (isOcrPageAvailable) OrElse (isInMemory AndAlso GetOcrDocumentPagesCount() > 0)
         _zonesShowZonesToolStripMenuItem.Checked = _viewerControl.ShowZones
         _zonesShowZoneNamesToolStripMenuItem.Checked = _viewerControl.ShowZoneNames
      End Sub

      Private Sub _recognizeToolStripMenuItem_DropDownOpening(sender As Object, e As EventArgs) Handles _recognizeToolStripMenuItem.DropDownOpening
         ' Update 'Recognize' menu items
         Dim isInMemory As Boolean = IsOcrDocumentInMemory()
         Dim isOcrPageAvailable As Boolean = _ocrPage IsNot Nothing

         _recognizeRecognizeDocumentToolStripMenuItem.Enabled = isInMemory AndAlso GetOcrDocumentPagesCount() > 0
         _recognizeRecognizePageToolStripMenuItem.Enabled = isOcrPageAvailable
         _recognizeSaveAfterRecognizeToolStripMenuItem.Checked = _saveAfterRecognize

         Dim enable As Boolean = False
         If isInMemory Then
            For Each page As IOcrPage In _ocrDocument.Pages
               enable = page.IsRecognized
               If enable Then
                  Exit For
               End If
            Next
         Else
            enable = If((_ocrPage IsNot Nothing), _ocrPage.IsRecognized, False)
         End If
      End Sub

      Private Sub _documentToolStripMenuItem_DropDownOpening(sender As Object, e As EventArgs) Handles _documentToolStripMenuItem.DropDownOpening
         ' Update 'Document' menu items
         Dim isInMemory As Boolean = IsOcrDocumentInMemory()
         Dim isOcrPageAvailable As Boolean = _ocrPage IsNot Nothing

         _documentAddCurrentPageToolStripMenuItem.Enabled = (_ocrDocument IsNot Nothing) AndAlso isOcrPageAvailable AndAlso (If((isInMemory), Not IsCurrentOcrPagePartOfOcrDocument(), True))
         _documentInsertPagesToolStripMenuItem.Enabled = (_ocrDocument IsNot Nothing) AndAlso isInMemory
         _documentRemoveCurrentPageToolStripMenuItem.Enabled = (_ocrDocument IsNot Nothing) AndAlso isOcrPageAvailable AndAlso isInMemory
         _documentClearDocumentPagesToolStripMenuItem.Enabled = (_ocrDocument IsNot Nothing) AndAlso isInMemory AndAlso GetOcrDocumentPagesCount() > 0
         _documentSaveDocumentToolStripMenuItem.Enabled = (isOcrPageAvailable OrElse ((_ocrDocument IsNot Nothing) AndAlso GetOcrDocumentPagesCount() > 0))
         _documentCloseDocumentToolStripMenuItem.Enabled = (_ocrDocument IsNot Nothing)
         _documentSaveRecognizedDataAsXmlToolStripMenuItem.Enabled = (_ocrDocument IsNot Nothing AndAlso _ocrDocument.IsInMemory AndAlso _ocrDocument.Pages.Count > 0)
      End Sub

      Private Sub _recognizeRecognizeDocumentToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles _recognizeRecognizeDocumentToolStripMenuItem.Click
         RecognizeDocument(True)
      End Sub

      Private Sub _recognizeRecognizePageToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles _recognizeRecognizePageToolStripMenuItem.Click
         RecognizeDocument(False)
      End Sub

      Private Sub SaveRecognizedDataAsXml(saveActivePageOnly As Boolean)
         Using dlg As New SaveRecognizedXmlDialog()
            If dlg.ShowDialog(Me) = DialogResult.OK Then
               Try
                  Using wait As New WaitCursor()
                     Dim xmlOptions As New OcrWriteXmlOptions(OcrXmlEncoding.UTF8, True, "  ")
                     Dim outputOptions As OcrXmlOutputOptions = dlg.OutputOptions
                     Dim fileName As String = dlg.FileName

                     If saveActivePageOnly Then
                        _ocrPage.SaveXml(fileName, 1, xmlOptions, outputOptions)
                     Else
                        _ocrDocument.SaveXml(fileName, xmlOptions, outputOptions)
                     End If

                     System.Threading.Thread.Sleep(1000)
                     System.Diagnostics.Process.Start(fileName)
                  End Using
               Catch ex As Exception
                  MessageBox.Show(Me, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                  DialogResult = DialogResult.None
               End Try
            End If
         End Using
      End Sub

      Private Sub _recognizeSpellCheckEngineStripMenuItem_Click(sender As Object, e As EventArgs) Handles _recognizeSpellCheckEngineStripMenuItem.Click
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

      Private Sub _recognizeOmrOptionsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles _recognizeOmrOptionsToolStripMenuItem.Click
         Using dlg As New OcrOmrOptionsDialog(_ocrEngine)
            dlg.ShowDialog(Me)
         End Using
      End Sub

      Private Sub _recognizeSaveAfterRecognizeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles _recognizeSaveAfterRecognizeToolStripMenuItem.Click
         _saveAfterRecognize = Not _recognizeSaveAfterRecognizeToolStripMenuItem.Checked
         _recognizeSaveAfterRecognizeToolStripMenuItem.Checked = _saveAfterRecognize
      End Sub

      Private Sub _documentCreateDocumentToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles _documentCreateDocumentToolStripMenuItem.Click
         Dim settings As New Settings()
         _ocrDocumentFilePath = settings.OcrDocumentFilePath
         Using dlg As New CreateOcrDocumentDialog(_ocrDocumentFilePath)
            If dlg.ShowDialog() = DialogResult.OK Then
               _ocrDocumentFilePath = dlg.OcrDocumentFilePath
               settings.OcrDocumentFilePath = _ocrDocumentFilePath
               settings.Save()

               CreateOcrDocument(dlg.OcrDocumentOptions, _ocrDocumentFilePath, True)
            End If
         End Using
      End Sub

      Private Sub _documentLoadDocumentToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles _documentLoadDocumentToolStripMenuItem.Click
         Using dlg As New OpenFileDialog()
            Dim extension As String = "ltd"
            Dim friendlyName As String = "LEAD Temporary Document"
            dlg.Filter = String.Format("{0} (*.{1})|*.{1}|All Files (*.*)|*.*", friendlyName, extension)
            dlg.DefaultExt = extension
            dlg.Title = "Select LEAD Temporary Document File (LTD)"
            If dlg.ShowDialog(Me) = DialogResult.OK Then
               CreateOcrDocument(OcrCreateDocumentOptions.LoadExisting, dlg.FileName, True)
            End If
         End Using
      End Sub

      Private Sub _documentAddCurrentPageToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles _documentAddCurrentPageToolStripMenuItem.Click
         ' Insert the existing OCR page into the document
         ' Check if we have file based document then use IOcrPageCollection.Add else then use IOcrPageCollection.Insert
         ' because the insert function is only supported for memory based document.
         Using wait As New WaitCursor()
            If Not IsOcrDocumentInMemory() Then
               If Not _ocrPage.IsRecognized Then
                  If MessageBox.Show("This page is not recognized. Are you sure you want to add it to this file-based Document? Saving this document will save the page as an image without any OCR data", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> DialogResult.Yes Then
                     Return
                  End If
               End If
               _ocrDocument.Pages.Add(_ocrPage)
            Else
               _ocrDocument.Pages.Insert(-1, _ocrPage)
            End If

            RefreshPagesControl(False)
            RepopulateDocumentInformationControl()
         End Using
      End Sub

      Private Sub _documentInsertPagesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles _documentInsertPagesToolStripMenuItem.Click
         InsertPages()
      End Sub

      Private Sub _documentRemoveCurrentPageToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles _documentRemoveCurrentPageToolStripMenuItem.Click
         DeletePage(CurrentPageIndex)
      End Sub

      Private Sub _documentClearDocumentPagesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles _documentClearDocumentPagesToolStripMenuItem.Click
         If _ocrDocument IsNot Nothing Then
            _ocrDocument.Pages.Clear()
         End If

         ' Check if in memory mode and the current loaded page is part of the cleared document, then just set
         ' the _ocrPage to null since the OCR document already freed that OCR page.
         If IsOcrDocumentInMemory() Then
            _ocrPage = Nothing
            _pagesControl.RasterImageList.Items.Clear()
         End If

         _currentPageIndex = -1
         _viewerControl.ClearZones()
         _viewerControl.SetImageAndPage(Nothing, Nothing)
         _viewerControl.SetPages(0, 0)

         RepopulatePagesControl(-1, -1, String.Empty)
         RepopulateDocumentInformationControl()
         RepopulateOcrPageTextWindow()
      End Sub

      Private Sub _documentSaveDocumentToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles _documentSaveDocumentToolStripMenuItem.Click
         SaveDocument()
      End Sub

      Private Sub _documentCloseDocumentToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles _documentCloseDocumentToolStripMenuItem.Click
         DoCloseOcrDocument(True)
      End Sub

      Private Sub DoCloseOcrDocument(showWarning As Boolean)
         ' Show warning message to the user that he is going to close the OCR document as reminder to save before close
         If showWarning Then
            If MessageBox.Show(Me, "Are you sure you want to close current OCR document?", "Close Document", MessageBoxButtons.YesNo, MessageBoxIcon.Information) <> DialogResult.Yes Then
               Return
            End If
         End If

         Dim isInMemory As Boolean = IsOcrDocumentInMemory()
         _ocrDocument.Dispose()
         _ocrDocument = Nothing
         _customFileName = False
         ' Remove check mark from 'All pages' menu item inside 'Preprocess' menu
         _processAllPagesToolStripMenuItem.Checked = False

         If isInMemory Then
            _ocrPage = Nothing
            _pagesControl.RasterImageList.Items.Clear()
            _viewerControl.ClearZones()
            _viewerControl.SetImageAndPage(Nothing, Nothing)
            _viewerControl.SetPages(0, 0)
         End If

         _documentMode = False

         _viewerControl.Title = String.Empty
         RepopulatePagesControl(-1, -1, String.Empty)
         RepopulateDocumentInformationControl()
         RepopulateOcrPageTextWindow()
         UpdateUIState()
      End Sub

      Private Sub _preferencesUseProgressBarsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles _preferencesUseProgressBarsToolStripMenuItem.Click
         _preferencesUseProgressBarsToolStripMenuItem.Checked = Not _preferencesUseProgressBarsToolStripMenuItem.Checked
      End Sub

      Private Sub _helpAboutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles _helpAboutToolStripMenuItem.Click
         Using aboutDialog As New AboutDialog("OCR Demo", ProgrammingInterface.VB)
            aboutDialog.ShowDialog(Me)
         End Using
      End Sub

      Private Sub _openDocumentToolStripButton_Click(sender As Object, e As EventArgs) Handles _openDocumentToolStripButton.Click
         _fileOpenToolStripMenuItem.PerformClick()
      End Sub

      Private Sub _autoZoneDocumentToolStripButton_Click(sender As Object, e As EventArgs) Handles _autoZoneDocumentToolStripButton.Click
         _zonesAutoZoneDocumentToolStripMenuItem.PerformClick()
      End Sub

      Private Sub _autoZonePageToolStripButton_Click(sender As Object, e As EventArgs) Handles _autoZonePageToolStripButton.Click
         _zonesAutoZoneCurrentPageToolStripMenuItem.PerformClick()
      End Sub

      Private Sub _recognizeDocumentToolStripButton_Click(sender As Object, e As EventArgs) Handles _recognizeDocumentToolStripButton.Click
         _recognizeRecognizeDocumentToolStripMenuItem.PerformClick()
      End Sub

      Private Sub _recognizePageToolStripButton_Click(sender As Object, e As EventArgs) Handles _recognizePageToolStripButton.Click
         _recognizeRecognizePageToolStripMenuItem.PerformClick()
      End Sub

      Private Sub _saveDocumentToolStripButton_Click(sender As Object, e As EventArgs) Handles _saveDocumentToolStripButton.Click
         _documentSaveDocumentToolStripMenuItem.PerformClick()
      End Sub

      Private Sub UpdateUIState()
         ' Update the UI state

         Dim isInMemory As Boolean = IsOcrDocumentInMemory()
         Dim isOcrPageAvailable As Boolean = _ocrPage IsNot Nothing
         Dim isOcrDocumentAvailable As Boolean = _ocrDocument IsNot Nothing

         ' Update toolbar buttons
         _autoZoneDocumentToolStripButton.Enabled = isInMemory AndAlso GetOcrDocumentPagesCount() > 0
         _autoZonePageToolStripButton.Enabled = isOcrPageAvailable
         _recognizeDocumentToolStripButton.Enabled = isInMemory AndAlso GetOcrDocumentPagesCount() > 0
         _recognizePageToolStripButton.Enabled = isOcrPageAvailable
         _saveDocumentToolStripButton.Enabled = isOcrPageAvailable OrElse isOcrDocumentAvailable

         _recognizeToolStripMenuItem_DropDownOpening(Nothing, Nothing)
         _documentToolStripMenuItem_DropDownOpening(Nothing, Nothing)
      End Sub

      Private Sub OpenDocument()
         ' Open a document from disk

         Dim settings As New Settings()

         ' Show the LEADTOOLS common dialog
         Dim loader As New ImageFileLoader()
         loader.LoadOnlyOnePage = True
         loader.ShowLoadPagesDialog = True
         loader.OpenDialogInitialPath = _openInitialPath
         If Not String.IsNullOrEmpty(settings.OpenDialogInitialPath) Then
            loader.OpenDialogInitialPath = settings.OpenDialogInitialPath
         End If

         Try
            ' Insert the pages loader into the document
            If loader.Load(Me, _rasterCodecs, False) > 0 Then
               _openInitialPath = Path.GetDirectoryName(loader.FileName)
               settings.OpenDialogInitialPath = Path.GetDirectoryName(loader.FileName)
               settings.Save()

               If Not _documentMode Then
                  _customFileName = False
               End If

               OpenDocument(loader.FileName, Nothing, loader.FirstPage, loader.LastPage)
            End If
         Catch ex As Exception
            ShowError(ex)
         End Try
      End Sub

      Private Sub SetFileName(fileName As String)
         If _documentMode AndAlso (_ocrDocument IsNot Nothing) AndAlso Not (_ocrDocument.Pages.Count >= 1) Then
            _fileName = fileName
         ElseIf Not _documentMode AndAlso _outputDir.Equals([String].Empty) Then
            If _customFileName Then
               _fileName = Path.Combine(Path.GetDirectoryName(_fileName), Path.GetFileName(fileName))
            Else
               _fileName = fileName
            End If
         ElseIf Not _documentMode Then
            If fileName IsNot Nothing Then
               If Not _outputDir.Equals([String].Empty) Then
                  _fileName = Path.Combine(_outputDir, Path.GetFileName(fileName))
               ElseIf _customFileName Then
                  _outputDir = Path.GetDirectoryName(_fileName)
               End If
            End If
         End If
      End Sub

      Private Sub OpenDocument(ByVal fileName As String, ByVal rasterImage As RasterImage, ByVal firstPage As Integer, ByVal lastPage As Integer)
         ' Open the document in file name

         Try
            SetFileName(fileName)
            Dim multipage As Boolean = lastPage <> firstPage
            If multipage AndAlso _ocrDocument IsNot Nothing AndAlso (Not IsOcrDocumentInMemory()) Then
               ' We already have a File OCR document loaded, so inform the user that the current OCR document will be closed 
               ' cause a new InMemory document is going to be created.
               If MessageBox.Show(Me, "In order to load a multi-page file the current file based OCR document should be closed and create new memory based one, do you wish to continue?", "Load Multi-Page", MessageBoxButtons.YesNo, MessageBoxIcon.Information) <> DialogResult.Yes Then
                  Return
               End If
            End If

            If _ocrPage IsNot Nothing AndAlso (Not IsOcrDocumentInMemory()) Then
               ' Dispose the current OcrPage (if exists)
               _ocrPage.Dispose()
               _ocrPage = Nothing
               _viewerControl.SetImageAndPage(Nothing, Nothing)
            End If

            ' Check if have OCR document in memory then we need to append the loaded pages into that document, 
            ' if we don't have InMemory document and we are only loading one page then don't create a document
            If multipage AndAlso (Not IsOcrDocumentInMemory()) Then
               CreateOcrDocument(OcrCreateDocumentOptions.InMemory, Nothing, False)
            End If

            ' Clear previous document pages when called from "File" -> "Open" menu
            _documentClearDocumentPagesToolStripMenuItem.PerformClick()

            Dim beginTime As Date = Date.Now
            Dim pageIndex As Integer = CurrentPageIndex

            Dim worker As New BackgroundWorker()
            worker.WorkerSupportsCancellation = True
            worker.WorkerReportsProgress = True
            Dim popup As New Form()
            popup.MainMenuStrip = Nothing
            popup.ShowInTaskbar = False
            Dim popupSize As New Size(300, 100)
            popup.MinimumSize = popupSize
            popup.MaximumSize = popupSize
            popup.StartPosition = FormStartPosition.CenterParent
            popup.FormBorderStyle = FormBorderStyle.None
            Dim progress As New ProgressBar()
            progress.Maximum = 100
            progress.Step = 1
            progress.Value = 0
            progress.Location = New Point((popup.Width \ 2) - 125, (popup.Height \ 2) - 12)
            progress.Height = 25
            progress.Width = 250
            Dim progressText As New Label()
            progressText.Width = popupSize.Width
            progressText.TextAlign = ContentAlignment.MiddleCenter
            Dim cancel As New Button()
            cancel.Text = "Cancel"
            cancel.Size = New Size(80, 25)
            cancel.Location = New Point((popup.Width \ 2) - 40, (popup.Height - 30))
            AddHandler cancel.Click, Sub(s, e) worker.CancelAsync()

            popup.Controls.Add(progress)
            popup.Controls.Add(progressText)
            popup.Controls.Add(cancel)

            Dim exception As Exception = Nothing
            AddHandler worker.DoWork, Sub(s, e)

                                         Me.BeginInvoke(New Action(Function() popup.ShowDialog(Me)))
                                         Try
                                            For i As Integer = firstPage To lastPage
                                               Dim pageNumber As Integer = i
                                               Me.BeginInvoke(New Action(Sub() progressText.Text = String.Format("Loading Page {0} of {1}...", pageNumber, lastPage)))
                                               If worker.CancellationPending Then
                                                  Me.BeginInvoke(New Action(Sub() progressText.Text = "Cancelling..."))
                                                  If _ocrPage IsNot Nothing Then
                                                     _ocrPage = Nothing
                                                  End If

                                                  If IsOcrDocumentInMemory() Then
                                                     _ocrDocument.Pages.Clear()
                                                  End If
                                                  e.Cancel = True
                                                  Return
                                               End If

                                               ' Load the bitmap page
                                               Dim image As RasterImage = Nothing

                                               If rasterImage IsNot Nothing Then
                                                  image = rasterImage
                                               Else
                                                  image = _rasterCodecs.Load(fileName, pageNumber)
                                               End If

                                               _ocrPage = _ocrEngine.CreatePage(image, OcrImageSharingMode.AutoDispose)

                                               ' Add the created IOcrPage into IOcrDocument in case of memory mode
                                               If IsOcrDocumentInMemory() Then
                                                  _ocrDocument.Pages.Insert(pageIndex + 1, _ocrPage)
                                               End If

                                               pageIndex += 1
                                               worker.ReportProgress((i * 100) \ lastPage)
                                            Next i
                                         Catch ex2 As Exception
                                            exception = ex2
                                            worker.CancelAsync()
                                         End Try
                                      End Sub

            AddHandler worker.ProgressChanged, Sub(s, e) progress.Value = e.ProgressPercentage

            AddHandler worker.RunWorkerCompleted, Sub(s, e)
                                                     popup.Close()

                                                     If Not e.Cancelled AndAlso exception Is Nothing Then
                                                        Dim ts As TimeSpan = Date.Now.Subtract(beginTime)
                                                        UpdateTimingLabel(New String() {"Load Pages"}, New TimeSpan() {ts})

                                                        Dim pagesCount As Integer = lastPage - firstPage + 1
                                                        RepopulatePagesControl(0, pagesCount, fileName)
                                                        RepopulateDocumentInformationControl()
                                                        RepopulateOcrPageTextWindow()
                                                        GotoPage(CurrentPageIndex + 1)
                                                        UpdateUIState()

                                                        If Not String.IsNullOrEmpty(fileName) Then
                                                           _viewerControl.Title = fileName
                                                        End If

                                                        ' Go to the current page in the viewer control
                                                        _viewerControl.SetPages(0, pagesCount)

                                                        Using wait As New WaitCursor()
                                                           Dim image As RasterImage = _ocrPage.GetRasterImage(OcrPageType.Current)
                                                           _viewerControl.SetImageAndPage(image, _ocrPage)
                                                        End Using
                                                     End If

                                                     If exception IsNot Nothing AndAlso exception.Message.Equals("Not enough memory available") Then
                                                        DoCloseOcrDocument(False)
                                                        ShowError(exception)
                                                     End If
                                                  End Sub

            worker.RunWorkerAsync()
         Catch ex As Exception
            ShowError(ex)
            UpdateTimingLabel(Nothing, Nothing)
         End Try
      End Sub

      Private Sub CreateOcrDocument(options As OcrCreateDocumentOptions, ocrDocumentFilePath As String, showWarning As Boolean)
         ' Create a new document
         If _ocrDocument IsNot Nothing Then
            If showWarning Then
               ' We already have a OCR document loaded, so inform the user that the current OCR document will be closed.
               If MessageBox.Show(Me, "In order to create/load new OCR document, the current OCR document will be closed, do you want to proceed?", "Create OCR Document", MessageBoxButtons.YesNo, MessageBoxIcon.Information) <> DialogResult.Yes Then
                  Return
               End If
            End If

            If IsOcrDocumentInMemory() Then
               DoCloseOcrDocument(False)
            End If

            If _ocrDocument IsNot Nothing Then
               _ocrDocument.Dispose()
               _ocrDocument = Nothing
            End If
         End If

         Dim ocrDocumentFile As String = If((options <> OcrCreateDocumentOptions.InMemory), ocrDocumentFilePath, Nothing)
         _ocrDocument = _ocrEngine.DocumentManager.CreateDocument(ocrDocumentFile, options)
         If options = OcrCreateDocumentOptions.InMemory AndAlso _ocrPage IsNot Nothing Then
            ' Insert the existing OCR page into the document
            _ocrDocument.Pages.Insert(-1, _ocrPage)
         End If

         Dim pagesCount As Integer = GetOcrDocumentPagesCount()
         RepopulatePagesControl(0, pagesCount, _fileName)
         RepopulateDocumentInformationControl()
         RepopulateOcrPageTextWindow()
         GotoPage(-1)

         _documentMode = True

         UpdateUIState()
      End Sub

      Private Function IsOcrDocumentInMemory() As Boolean
         Dim isInMemory As Boolean = False

         If _ocrDocument IsNot Nothing Then
            isInMemory = _ocrDocument.IsInMemory
         End If

         Return isInMemory
      End Function

      Private Function GetOcrDocumentPagesCount() As Integer
         Dim pagesCount As Integer = 0

         If _ocrDocument IsNot Nothing Then
            pagesCount = _ocrDocument.Pages.Count
         End If

         Return pagesCount
      End Function

      Private Function IsCurrentOcrPagePartOfOcrDocument() As Boolean
         If IsOcrDocumentInMemory() Then
            Dim pageIndex As Integer = -1
            pageIndex = _ocrDocument.Pages.IndexOf(_ocrPage)
            If pageIndex <> -1 Then
               Return True
            End If
         End If

         Return False
      End Function

      Private Sub CloseCurrentOcrPage()
         If _ocrPage IsNot Nothing Then
            _ocrPage.Dispose()
            _ocrPage = Nothing
            _viewerControl.ClearZones()
            _viewerControl.SetImageAndPage(Nothing, Nothing)
            _viewerControl.SetPages(0, 0)
            _viewerControl.Title = String.Empty
            RepopulateOcrPageTextWindow()
            UpdateUIState()
         End If
      End Sub


      Private Sub _pagesControl_Action(sender As Object, e As ActionEventArgs) Handles _pagesControl.Action
         ' Called from the PagesControl when a button is clicked

         Select Case e.Action
            Case "InsertPage"
               InsertPages()
               Exit Select

            Case "DeletePage"
               DeletePage(CurrentPageIndex)
               Exit Select

            Case "MovePageUp"
               MoveCurrentPage(True)
               Exit Select

            Case "MovePageDown"
               MoveCurrentPage(False)
               Exit Select

            Case "PageIndexChanged"
               If True Then
                  ' Get the new page index and go to it
                  Dim pageIndex As Integer = CInt(e.Data)
                  GotoPage(pageIndex)
               End If
               Exit Select
         End Select
      End Sub

      Private Sub _viewerControl_Action(sender As Object, e As ActionEventArgs) Handles _viewerControl.Action
         ' Called from the ViewerControl when a button is clicked

         Select Case e.Action
            Case "PageIndexChanged"
               If True Then
                  ' Get the new page index and go to it
                  Dim pageIndex As Integer = CInt(e.Data)
                  GotoPage(pageIndex)
               End If
               Exit Select

            Case "ShowZoneProperties"
               ShowZoneProperties()
               Exit Select

            Case "RefreshPagesControl"
               Dim allPages As Boolean = CBool(e.Data)
               RefreshPagesControl(allPages)
               Exit Select
         End Select
      End Sub

      Private _currentPageIndex As Integer = -1
      Private ReadOnly Property CurrentPageIndex() As Integer
         Get
            Return _currentPageIndex
         End Get
      End Property

      Private Sub InsertPages()
         ' Insert new pages into the current document

         ' Show the common file dialog to let the user select a file
         Dim loader As New ImageFileLoader()
         loader.LoadOnlyOnePage = False
         loader.ShowLoadPagesDialog = True

         Try
            Dim settings As New Settings()
            If Not String.IsNullOrEmpty(settings.InsertPageDialogInitialPath) Then
               loader.OpenDialogInitialPath = settings.InsertPageDialogInitialPath
            End If

            ' Insert the pages loader into the document
            If loader.Load(Me, _rasterCodecs, False) > 0 Then
               settings.InsertPageDialogInitialPath = Path.GetDirectoryName(loader.FileName)
               settings.Save()
               InsertPages(loader.FileName, loader.FirstPage, loader.LastPage, Nothing, -1)
            End If
         Catch ex As Exception
            ShowError(ex)
            UpdateTimingLabel(Nothing, Nothing)
         End Try
      End Sub

      Private Sub InsertPages(fileName As String, firstPage As Integer, lastPage As Integer, image As RasterImage, insertionIndex As Integer)
         ' Insert the pages from file or directly into the current document
         ' Go to the first inserted page

         SetFileName(fileName)

         Dim pageIndex As Integer = insertionIndex
         If insertionIndex = -1 Then
            pageIndex = CurrentPageIndex

            ' Insert the new pages after the current page
            If pageIndex = -1 Then
               pageIndex = 0
            Else
               pageIndex += 1
            End If
         End If

         Dim oldPagesCount As Integer = GetOcrDocumentPagesCount()

         ' Check if we are inserting a page from file or directly
         Using wait As New WaitCursor()
            Dim beginTime As DateTime = DateTime.Now

            If _ocrPage IsNot Nothing AndAlso Not IsOcrDocumentInMemory() Then
               _ocrPage.Dispose()
               _ocrPage = Nothing
            End If

            For i As Integer = firstPage To lastPage
               If image IsNot Nothing Then
                  _ocrPage = _ocrEngine.CreatePage(image, OcrImageSharingMode.AutoDispose)
               Else
                  ' Load the bitmap page
                  Dim rasterImage As RasterImage = _rasterCodecs.Load(fileName, i)
                  _ocrPage = _ocrEngine.CreatePage(rasterImage, OcrImageSharingMode.AutoDispose)
               End If

               If IsOcrDocumentInMemory() Then
                  _ocrDocument.Pages.Insert(pageIndex, _ocrPage)
               End If

               pageIndex += 1
            Next
            pageIndex -= 1

            Dim ts As TimeSpan = DateTime.Now - beginTime
            UpdateTimingLabel(New String() {"Insert pages"}, New TimeSpan() {ts})
         End Using

         pageIndex -= lastPage - firstPage
         If CurrentPageIndex = -1 Then
            pageIndex = 0
         End If

         ' Update the pages control with the new document
         Dim newPagesCount As Integer = GetOcrDocumentPagesCount()
         RepopulatePagesControl(pageIndex, newPagesCount - oldPagesCount, fileName)
         RepopulateDocumentInformationControl()

         ' Go to the first page inserted in the document
         GotoPage(pageIndex)
      End Sub

      Private Sub DeletePage(pageIndex As Integer)
         ' Delete the current page from the document
         Using wait As New WaitCursor()
            _ocrDocument.Pages.RemoveAt(pageIndex)

            _pagesControl.RasterImageList.Items.RemoveAt(pageIndex)
            If _pagesControl.RasterImageList.Items.Count <= 0 Then
               _currentPageIndex = -1
            End If

            If pageIndex >= GetOcrDocumentPagesCount() Then
               pageIndex = GetOcrDocumentPagesCount() - 1
            End If

            ' Update the pages control with the new document
            If pageIndex >= 0 Then
               UpdatePagesControlItemsText(pageIndex)
            End If

            RepopulateDocumentInformationControl()

            ' Go to the current page
            GotoPage(pageIndex)
         End Using
      End Sub

      Private Sub RepopulatePagesControl(pageIndex As Integer, count As Integer, fileName As String)
         If Not IsOcrDocumentInMemory() Then
            _pagesControl.RasterImageList.Items.Clear()
            _mainSplitContainer.Panel1Collapsed = True
            _currentPageIndex = -1
            Return
         End If

         _mainSplitContainer.Panel1Collapsed = False
         Using wait As New WaitCursor()
            ' Re-insert the thumbnails from the pages control
            Dim imageList As ImageViewer = _pagesControl.RasterImageList
            imageList.BeginUpdate()

            ' Loop through all the pages in the document and create thumbnails for them,
            ' add the thumbnails to the pages control

            If _ocrDocument IsNot Nothing Then
               Dim thumbSize As LeadSize = imageList.ItemSize

               Dim index As Integer = pageIndex
               If index <> -1 Then
                  For i As Integer = 0 To count - 1
                     Dim ocrPage As IOcrPage = _ocrDocument.Pages(index)
                     Dim image As RasterImage = ocrPage.CreateThumbnail(thumbSize.Width, thumbSize.Height)
                     Dim item As New ImageViewerItem()
                     item.Image = image
                     item.PageNumber = 1
                     item.Text = "Page " & (index + 1).ToString()

                     Dim itemData As ImageListItemData = Nothing
                     If item.Tag IsNot Nothing Then
                        itemData = TryCast(item.Tag, ImageListItemData)
                     Else
                        itemData = New ImageListItemData(fileName, ocrPage.IsRecognized)
                     End If

                     item.Tag = itemData
                     imageList.Items.Insert(index, item)
                     index += 1
                  Next

                  ' Loop through all image list items that followed the inserted item and correct their names orders
                  For i As Integer = index To imageList.Items.Count - 1
                     If imageList.Items(i) IsNot Nothing Then
                        imageList.Items(i).Text = "Page " & (i + 1).ToString()
                     End If
                  Next
               End If
            End If

            imageList.EndUpdate()
         End Using
      End Sub

      Private Sub RepopulateDocumentInformationControl()
         If _ocrDocument Is Nothing Then
            _viewerVertSplitContainer.Panel2Collapsed = True
            Return
         End If

         _viewerVertSplitContainer.Panel2Collapsed = False
         _documentInfoControl.RepopulateDocumentInformationControl(_ocrDocument)
      End Sub

      Private Sub RepopulateOcrPageTextWindow()
         If _ocrPage IsNot Nothing Then
            If Not _ocrPage.IsRecognized Then
               _pageTextControl.SetPageText(String.Empty)
               Return
            End If

            ' Get the page text and update the OCR page text pane
            Try
               Dim pageText As String = _ocrPage.GetText(-1)
               ' -1 will get all page recognized text
               If pageText IsNot Nothing AndAlso pageText.Length > 0 Then
                  _pageTextControl.SetPageText(pageText)
               End If
            Catch ex As Exception
               ShowError(ex)
            End Try
         Else
            _pageTextControl.SetPageText(String.Empty)
         End If
      End Sub

      Private Sub UpdatePagesControlItemsText(pageIndex As Integer)
         Dim imageList As ImageViewer = _pagesControl.RasterImageList

         For i As Integer = pageIndex To imageList.Items.Count - 1
            Dim itemText As String = "Page " & (i + 1).ToString()
            imageList.Items(i).Text = itemText
         Next
      End Sub

      Private Sub RefreshPagesControl(allPages As Boolean)
         Using wait As New WaitCursor()
            ' Re-get the thumbnails from the pages control
            Dim imageList As ImageViewer = _pagesControl.RasterImageList
            imageList.BeginUpdate()

            Dim thumbSize As LeadSize = imageList.ItemSize

            Dim pageIndex As Integer = CurrentPageIndex

            For i As Integer = 0 To imageList.Items.Count - 1
               If allPages OrElse i = pageIndex Then
                  Dim image As RasterImage = _ocrDocument.Pages(i).CreateThumbnail(thumbSize.Width, thumbSize.Height)
                  imageList.Items(i).Image = image
               End If

               ' Set the item tag if the page is recognized, otherwise set it to null
               Dim itemData As ImageListItemData = Nothing
               If imageList.Items(i).Tag IsNot Nothing Then
                  itemData = TryCast(imageList.Items(i).Tag, ImageListItemData)
               Else
                  itemData = New ImageListItemData(_fileName, False)
               End If

               If _ocrDocument IsNot Nothing AndAlso _ocrDocument.Pages(i).IsRecognized Then
                  itemData.IsRecognized = True
               Else
                  itemData.IsRecognized = False
               End If

               imageList.Items(i).Tag = itemData
            Next

            imageList.EndUpdate()
         End Using
      End Sub

      Private Sub GotoPage(pageIndex As Integer)
         Try
            If Not IsOcrDocumentInMemory() Then
               If _ocrPage IsNot Nothing Then
                  Dim image As RasterImage = _ocrPage.GetRasterImage(OcrPageType.Current)
                  If image IsNot Nothing Then
                     _viewerControl.SetImageAndPage(image, _ocrPage)
                  End If
               End If
               Return
            End If

            ' Goto this page in the OCR document
            If pageIndex = -1 Then
               pageIndex = 0
            End If

            If _ocrDocument IsNot Nothing AndAlso GetOcrDocumentPagesCount() > 0 Then
               _ocrPage = _ocrDocument.Pages(pageIndex)

               ' Set the current page in the pages control
               _pagesControl.SetCurrentPageIndex(pageIndex)
               _currentPageIndex = pageIndex

               ' Go to the current page in the viewer control
               _viewerControl.SetPages(pageIndex, GetOcrDocumentPagesCount())

               Using wait As New WaitCursor()
                  Dim image As RasterImage = _ocrPage.GetRasterImage(OcrPageType.Current)
                  _viewerControl.SetImageAndPage(image, _ocrPage)
               End Using
            Else
               ' No more pages
               _ocrPage = Nothing

               _currentPageIndex = -1
               _pagesControl.SetCurrentPageIndex(-1)
               _viewerControl.ClearZones()
               _viewerControl.SetImageAndPage(Nothing, Nothing)
               _viewerControl.SetPages(0, 0)
            End If

            If _pagesControl.RasterImageList.Items.Count > 0 AndAlso pageIndex < _pagesControl.RasterImageList.Items.Count Then
               Dim selectedItems As ImageViewerItem() = _pagesControl.RasterImageList.Items.GetSelected()
               If selectedItems.Length > 0 AndAlso selectedItems(0).Tag IsNot Nothing Then
                  Dim itemData As ImageListItemData = TryCast(selectedItems(0).Tag, ImageListItemData)
                  _viewerControl.Title = itemData.FileName
               Else
                  _viewerControl.Title = _pagesControl.RasterImageList.Items(pageIndex).Text
               End If
            Else
               _viewerControl.Title = String.Empty
            End If
         Finally
            UpdateUIState()
            RepopulateOcrPageTextWindow()
         End Try
      End Sub

      Private Sub RunImageProcessingCommand(command As RasterCommand)
         RunImageProcessingCommands(New RasterCommand() {command})
      End Sub

      Private Sub RunImageProcessingCommands(commands As RasterCommand())
         ' Run the command on all or just current page
         Dim allPages As Boolean = _processAllPagesToolStripMenuItem.Checked
         Dim isPageSplitterCommand As Boolean = False
         Dim currentPageIndex__1 As Integer = CurrentPageIndex

         Try
            Using wait As New WaitCursor()
               If allPages Then
                  ' Loop through the pages of the document
                  ' Get the page as a RasterImage object
                  ' Run the command on it
                  ' Set it back in the engine
                  For i As Integer = 0 To _ocrDocument.Pages.Count - 1
                     Dim ocrPage As IOcrPage = _ocrDocument.Pages(i)
                     ' Remove the zones from the page and unrecognize
                     ocrPage.Zones.Clear()
                     ocrPage.Unrecognize()

                     Using image As RasterImage = ocrPage.GetRasterImage()
                        For Each command As RasterCommand In commands
                           command.Run(image)
                           If command.GetType() Is GetType(AutoPageSplitterCommand) Then
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
                  Next

                  If isPageSplitterCommand Then
                     GotoPage(currentPageIndex__1)
                  End If
               Else
                  ' Remove the zones from the page and unrecognize
                  _ocrPage.Zones.Clear()
                  _ocrPage.Unrecognize()

                  ' The image is in the viewer, use it
                  Dim image As RasterImage = _ocrPage.GetRasterImage(OcrPageType.Current)
                  For Each command As RasterCommand In commands
                     command.Run(image)
                     If command.GetType() Is GetType(AutoPageSplitterCommand) Then
                        isPageSplitterCommand = True
                        Dim pageSplitterCommand As AutoPageSplitterCommand = CType(command, AutoPageSplitterCommand)
                        If pageSplitterCommand.FirstImage IsNot Nothing AndAlso pageSplitterCommand.SecondImage IsNot Nothing Then
                           ' Use the original image list item file name after applying this command to display 
                           ' the correct file name in viewer control title bar
                           Dim fileName As String = _pagesControl.RasterImageList.Items(currentPageIndex__1).Text

                           ' This command splits the page into two, so we need to remove the original page and 
                           ' add two pages instead with the images returned from this command.
                           InsertPages(fileName, 1, 1, pageSplitterCommand.FirstImage, -1)
                           InsertPages(fileName, 1, 1, pageSplitterCommand.SecondImage, -1)
                           DeletePage(currentPageIndex__1)
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
            GotoPage(CurrentPageIndex)
            ' Update the thumbnail(s)
            RefreshPagesControl(allPages)
         End Try
      End Sub

      Private Sub FlipDocument(horizontal As Boolean)
         ' Run the command on all or just current page
         Dim allPages As Boolean = _processAllPagesToolStripMenuItem.Checked

         Try
            Using wait As New WaitCursor()
               If allPages Then
                  ' Loop through the pages of the document
                  ' Get the page as a RasterImage object
                  ' Run the command on it
                  ' Set it back in the engine
                  For Each ocrPage As IOcrPage In _ocrDocument.Pages
                     ' Remove the zones from the page and unrecognize
                     ocrPage.Zones.Clear()
                     ocrPage.Unrecognize()

                     Dim image As RasterImage = ocrPage.GetRasterImage(OcrPageType.Current)
                     image.FlipViewPerspective(horizontal)
                     ocrPage.SetRasterImage(image)
                     _viewerControl.SetImageAndPage(image, ocrPage)
                  Next
               Else
                  ' Remove the zones from the page and unrecognize
                  _ocrPage.Zones.Clear()
                  _ocrPage.Unrecognize()

                  ' The image is in the viewer, use it
                  Dim image As RasterImage = _viewerControl.RasterImage
                  image.FlipViewPerspective(horizontal)
                  _ocrPage.SetRasterImage(image)
                  _viewerControl.SetImageAndPage(image, _ocrPage)
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

      Private Sub RotateDocument(angle As Integer)
         ' Run the command on all or just current page
         Dim allPages As Boolean = _processAllPagesToolStripMenuItem.Checked
         Dim rotateCmd As New RotateCommand(angle * 100, RotateCommandFlags.Resize, New RasterColor(255, 255, 255))

         Try
            Using wait As New WaitCursor()
               If allPages Then
                  ' Loop through the pages of the document
                  ' Get the page as a RasterImage object
                  ' Run the command on it
                  ' Set it back in the engine
                  For Each ocrPage As IOcrPage In _ocrDocument.Pages
                     ' Remove the zones from the page and unrecognize
                     ocrPage.Zones.Clear()
                     ocrPage.Unrecognize()

                     Dim image As RasterImage = ocrPage.GetRasterImage()
                     rotateCmd.Run(image)
                     ocrPage.SetRasterImage(image)
                     _viewerControl.SetImageAndPage(image, ocrPage)
                  Next
               Else
                  ' Remove the zones from the page and unrecognize
                  _ocrPage.Zones.Clear()
                  _ocrPage.Unrecognize()

                  ' The image is in the viewer, use it
                  rotateCmd.Run(_viewerControl.RasterImage)
                  _ocrPage.SetRasterImage(_viewerControl.RasterImage)
                  _viewerControl.SetImageAndPage(_viewerControl.RasterImage, _ocrPage)
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

      Private Sub MoveCurrentPage(up As Boolean)
         ' Move the current page up or down

         ' Get the page index to move
         Dim pageIndex1 As Integer = CurrentPageIndex
         Dim pageIndex2 As Integer

         If up Then
            pageIndex2 = pageIndex1 - 1
         Else
            pageIndex2 = pageIndex1 + 1
         End If

         Using wait As New WaitCursor()
            Dim ocrPage As IOcrPage = _ocrDocument.Pages(pageIndex1)

            _ocrDocument.Pages.MovePage(ocrPage, pageIndex2)

            RefreshPagesControl(True)

            ' Finally, go to the new page
            GotoPage(pageIndex2)
         End Using
      End Sub

      Private Sub Preprocess(command As OcrAutoPreprocessPageCommand)
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

      Private Sub DoPreprocess(dlg As OcrProgressDialog, args As Dictionary(Of String, Object))
         ' Perform auto-zoning here

         Dim callback As OcrProgressCallback = dlg.OcrProgressCallback

         Try
            Dim allPages As Boolean = CBool(args("allPages"))
            Dim command As OcrAutoPreprocessPageCommand = CType(args("command"), OcrAutoPreprocessPageCommand)

            ' If we are not using a progress bar, update the description text
            If callback Is Nothing Then
               dlg.UpdateDescription("Preprocessing the page(s) of the document...")
            End If

            ' Remove the zones from the page(s)

            If allPages Then
               For Each ocrPage As IOcrPage In _ocrDocument.Pages
                  ' Remove the zones from the page and un-recognize
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
            If callback Is Nothing Then
               dlg.EndOperation()
            End If
         End Try
      End Sub

      Private Sub AutoZone(allPages As Boolean)
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
      End Sub

      Private Sub DoAutoZone(dlg As OcrProgressDialog, args As Dictionary(Of String, Object))
         ' Perform auto-zoning here

         Dim callback As OcrProgressCallback = dlg.OcrProgressCallback

         Dim allPages As Boolean = CBool(args("allPages"))

         Try
            ' If we are not using a progress bar, update the description text
            If callback Is Nothing Then
               dlg.UpdateDescription("Auto zoning the page(s) of the document...")
            End If

            Dim beginTime As DateTime = DateTime.Now

            If allPages Then
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
            If callback Is Nothing Then
               dlg.EndOperation()
            End If

            ' Engine will correct the page deskew before AutoZone or Recognize, so we need to load the page again form the engine.
            GotoPage(CurrentPageIndex)
            ' Update the thumbnail(s)
            RefreshPagesControl(allPages)
         End Try
      End Sub

      Private Sub RecognizeDocument(allPages As Boolean)
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

            ' offer to save the recognized page/document after recognize
            If _saveAfterRecognize Then
               SaveDocument()
            End If
         End Try
      End Sub

      Private Sub DoRecognize(dlg As OcrProgressDialog, args As Dictionary(Of String, Object))
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
         ' If we have an empty document, nothing gets saved unless the document has some pages. Check...
         If _ocrDocument IsNot Nothing Then
            Dim pageCount As Integer = GetOcrDocumentPagesCount()
            If pageCount = 0 Then
               MessageBox.Show("This document has no pages. Add at least one page and try again", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
               Return
            End If

            ' check if we have memory mode document then check if non of its pages were recognized then recognize all pages first
            If IsOcrDocumentInMemory() Then
               Dim documentHasNoRecognizedPages As Boolean = True
               For i As Integer = 0 To pageCount - 1
                  Dim ocrPage As IOcrPage = Nothing
                  ocrPage = _ocrDocument.Pages(i)
                  If ocrPage IsNot Nothing Then
                     If ocrPage.IsRecognized Then
                        documentHasNoRecognizedPages = False
                        Exit For
                     End If
                  End If
               Next

               If documentHasNoRecognizedPages Then
                  _recognizeRecognizeDocumentToolStripMenuItem.PerformClick()
               End If
            End If
         End If

         ' Get the last format, options and document file name selected by the user
         Dim docWriter As DocumentWriter = _ocrEngine.DocumentWriterInstance

         Dim settings As New Settings()
         settings.DocumentFileName = _fileName

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

         Dim tempOcrDocument As IOcrDocument = Nothing
         If _ocrDocument Is Nothing Then
            ' User wish to save page while he/she doesn't have OCR Document yet, so we are going to create a temp document, 
            ' add the page, save then destroy the document.
            tempOcrDocument = _ocrEngine.DocumentManager.CreateDocument(Nothing, OcrCreateDocumentOptions.AutoDeleteFile)
            If tempOcrDocument IsNot Nothing Then
               ' Check if the page is recognized, otherwise, recognize
               If Not _ocrPage.IsRecognized Then
                  ' Recognize it first
                  Dim args As New Dictionary(Of String, Object)()
                  args.Add("allPages", False)
                  Dim allowProgress As Boolean = _preferencesUseProgressBarsToolStripMenuItem.Checked
                  Using dlg As New OcrProgressDialog(allowProgress, "Recognize", New OcrProgressDialog.ProcessDelegate(AddressOf DoRecognize), args)
                     If dlg.ShowDialog(Me) = DialogResult.Cancel Then
                        Return
                     End If
                  End Using
               End If
            End If
         Else
            tempOcrDocument = _ocrDocument
         End If

         ' Show the save dialog
         Using dlg As New SaveDocumentDialog(tempOcrDocument, initialFormat, settings.DocumentFileName, _viewDocument, _customFileName)
            If dlg.ShowDialog(Me) = DialogResult.OK Then
               If _ocrDocument Is Nothing Then
                  tempOcrDocument.Pages.Add(_ocrPage)
               End If

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

               If Not String.IsNullOrEmpty(_fileName) Then
                  If Not _fileName.Equals(dlg.SelectedFileName) Then
                     _customFileName = True
                     dlg.CustomFileName = True
                     _outputDir = Path.GetDirectoryName(dlg.SelectedFileName)
                  End If
               End If

               _fileName = dlg.SelectedFileName

               ' Save the document
               SaveDocument(tempOcrDocument, dlg.SelectedFileName, dlg.SelectedFormat)
            End If
         End Using

         If tempOcrDocument IsNot Nothing AndAlso _ocrDocument Is Nothing Then
            tempOcrDocument.Dispose()
         End If
      End Sub

      Private Sub SaveDocument(ocrDocument As IOcrDocument, documentFileName As String, format As DocumentFormat)
         ' Save the document

         ' Setup the arguments for the callback
         Dim args As New Dictionary(Of String, Object)()
         args.Add("OcrDocument", ocrDocument)
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

      Private Sub DoSave(dlg As OcrProgressDialog, args As Dictionary(Of String, Object))
         ' Perform save here

         Dim callback As OcrProgressCallback = dlg.OcrProgressCallback

         Try
            Dim ocrDocument As IOcrDocument = TryCast(args("OcrDocument"), IOcrDocument)
            Dim documentFileName As String = TryCast(args("documentFileName"), String)
            Dim format As DocumentFormat = CType(args("format"), DocumentFormat)

            If (format = DocumentFormat.Ltd AndAlso File.Exists(documentFileName)) Then
               File.Delete(documentFileName)
            End If

            ' If we are not using a progress bar, update the description text
            If callback Is Nothing Then
               dlg.UpdateDescription("Saving the result document...")
            End If

            Dim saveTimeSpan As New TimeSpan()

            ' If it has not been canceled, save the document
            If Not dlg.IsCanceled Then
               Dim beginTime As DateTime = DateTime.Now
               ocrDocument.Save(documentFileName, format, callback)
               saveTimeSpan = DateTime.Now - beginTime
            End If

            If Not dlg.IsCanceled Then
               UpdateTimingLabel(New String() {"Save Document"}, New TimeSpan() {saveTimeSpan})
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

      Private Sub LoadZones(loadAllPagesZones As Boolean)
         ' Load the zones from a disk file
         Using dlg As New OpenFileDialog()
            dlg.Filter = "Zone files (*.ozf)|*.ozf|All Files|*.*"
            If dlg.ShowDialog(Me) = DialogResult.OK Then
               Try
                  Using wait As New WaitCursor()
                     If Not loadAllPagesZones Then
                        _ocrPage.LoadZones(dlg.FileName)
                     Else
                        _ocrDocument.LoadZones(dlg.FileName)
                     End If
                  End Using

                  CheckOmrOptions()
               Catch ex As Exception
                  ShowError(ex)
               Finally
                  _viewerControl.ZonesUpdated()
                  UpdateUIState()
               End Try
            End If
         End Using
      End Sub

      Private Sub SaveZones(saveAllPagesZones As Boolean)
         ' Save the zones to a disk file
         Using dlg As New SaveFileDialog()
            dlg.Filter = "Zone files (*.ozf)|*.ozf|All Files|*.*"
            dlg.DefaultExt = "ozf"
            If dlg.ShowDialog(Me) = DialogResult.OK Then
               Try
                  Using wait As New WaitCursor()
                     If Not saveAllPagesZones Then
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

      Private Sub ShowZoneProperties()
         ' Show the zone properties dialog
         ' to let the user update the zones

         ' Get the selected zone from the viewer control
         Dim selectedZoneIndex As Integer = _viewerControl.SelectedZoneIndex

         Try
            ' Make a copy of the page zones in case the user canceled the dialog
            Dim zones As New List(Of OcrZone)()
            For Each zone As OcrZone In _ocrPage.Zones
               zones.Add(zone)
            Next
            Using dlg As New ZonePropertiesDialog(_ocrEngine, _ocrPage, _viewerControl, selectedZoneIndex)
               If dlg.ShowDialog(Me) = DialogResult.OK Then
                  ' We should mark the page as unrecognized since we updated its zones
                  _ocrPage.Unrecognize()

                  UpdateUIState()

                  RefreshPagesControl(False)
                  RepopulateOcrPageTextWindow()
               Else
                  ' Restore the old zones
                  _ocrPage.Zones.Clear()
                  For Each zone As OcrZone In zones
                     _ocrPage.Zones.Add(zone)
                  Next
               End If

               ' Let the viewer control know that the zones has been updated
               _viewerControl.ZonesUpdated()
            End Using

            CheckOmrOptions()
         Catch ex As Exception
            ShowError(ex)
         End Try
      End Sub

      Private Sub ConvertLD()
         ' Get the last format, options and document file name selected by the user
         Dim docWriter As DocumentWriter = _ocrEngine.DocumentWriterInstance

         Dim settings As New Settings()

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

         ' Show the convert LTD dialog
         Using dlg As New ConvertLdDialog(_ocrDocument, docWriter, initialFormat, settings.LdFileName, _viewDocument)
            If dlg.ShowDialog(Me) = DialogResult.OK Then
               ' Saved OK, save the last format, options and document file name used
               _viewDocument = dlg.SelectedViewDocument
               settings.Format = dlg.SelectedFormat.ToString()
               settings.LdFileName = dlg.SelectedInputFileName

               Using ms As New MemoryStream()
                  docWriter.SaveOptions(ms)
                  settings.FormatOptionsXml = Encoding.Unicode.GetString(ms.ToArray())
               End Using

               settings.Save()

               ' Convert the LTD file
               Try
                  Using wait As New WaitCursor()
                     docWriter.Convert(dlg.SelectedInputFileName, dlg.SelectedOutputFileName, dlg.SelectedFormat)
                     If _viewDocument Then
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

      Private Sub DoUpdateTimingLabel(str As String)
         _timingToolStripStatusLabel.Text = str
      End Sub

      Private Delegate Sub UpdateTimingLabelDelegate(str As String)

      Private Sub UpdateTimingLabel(labels As String(), times As TimeSpan())
         Dim str As String

         If labels IsNot Nothing Then
            Dim sb As New StringBuilder()
            For i As Integer = 0 To labels.Length - 1
               sb.AppendFormat("{0}: {1} (s)", labels(i), times(i).TotalSeconds.ToString("F03"))
               If i < (labels.Length - 1) Then
                  sb.Append(" - ")
               End If
            Next

            str = sb.ToString()
         Else
            str = String.Empty
         End If

         If InvokeRequired Then
            BeginInvoke(New UpdateTimingLabelDelegate(AddressOf DoUpdateTimingLabel), New Object() {str})
         Else
            DoUpdateTimingLabel(str)
         End If
      End Sub

      Private Sub DoShowError(ex As Exception)
         ' Shows an error, check if the exception is an OCR, raster or general one
         Dim ocr As OcrException = TryCast(ex, OcrException)
         If ocr IsNot Nothing Then
            Messager.ShowError(Me, String.Format("OCR Error" & Environment.NewLine & Environment.NewLine & "Code: {0}" & Environment.NewLine & Environment.NewLine & "{1}", ocr.Code, ocr.Message))
            Return
         End If

         Dim ocrComponent As OcrComponentMissingException = TryCast(ex, OcrComponentMissingException)
         If ocrComponent IsNot Nothing Then
            Messager.ShowError(Me, String.Format("OCR Component Missing" & Environment.NewLine & Environment.NewLine & "{0}" & Environment.NewLine & Environment.NewLine & "Use 'Engine/Componets' from the menu to show the available components and instructions of how to install the additional components of this OCR engine.", ocrComponent.Message))
            Return
         End If

         Dim raster As RasterException = TryCast(ex, RasterException)
         If raster IsNot Nothing Then
            Messager.ShowError(Me, String.Format("LEADTOOLS Error" & Environment.NewLine & Environment.NewLine & "Code: {0}" & Environment.NewLine & Environment.NewLine & "{1}", raster.Code, raster.Message))
            Return
         End If

         Messager.ShowError(Me, ex)
      End Sub

      Private Delegate Sub ShowErrorDelegate(ex As Exception)

      Private Sub ShowError(ex As Exception)
         If InvokeRequired Then
            BeginInvoke(New ShowErrorDelegate(AddressOf DoShowError), New Object() {ex})
         Else
            DoShowError(ex)
         End If
      End Sub

      Private Sub _fileExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles _fileExitToolStripMenuItem.Click
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

      Public Shared Function ConvertColor(color As RasterColor) As Color
         Return RasterColorConverter.ToColor(color)
      End Function

      Public Shared Function ConvertColor(color As Color) As RasterColor
         Return RasterColorConverter.FromColor(color)
      End Function

      Private Sub CheckOmrOptions()
         If _omrOptionsDismissed OrElse _ocrDocument Is Nothing OrElse GetOcrDocumentPagesCount() = 0 Then
            Return
         End If

         If HasOmrZones() Then
            _omrOptionsDismissed = True

            Using dlg As New OcrOmrOptionsDialog(_ocrEngine)
               dlg.ShowDialog(Me)
            End Using
         End If
      End Sub

      Private Sub _fileSetPDFLoadResolutionToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles _fileSetPDFLoadResolutionToolStripMenuItem.Click
         Using dlg As New LoadResolutionDialog(_rasterCodecs)
            dlg.ShowDialog(Me)
         End Using
      End Sub

      Private Sub UpdateActiveSpellCheckerLabel(spellCheckEngine As OcrSpellCheckEngine)
         _activeSpellCheckerToolStripStatusLabel.Text = [Enum].GetName(GetType(OcrSpellCheckEngine), spellCheckEngine)
      End Sub

      Private Sub MainForm_Resize(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Resize
         _viewerControl.ZonesUpdated()
      End Sub

      Private Sub _pageSaveRecognizedDataAsXmlToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles _pageSaveRecognizedDataAsXmlToolStripMenuItem.Click
         SaveRecognizedDataAsXml(True)
      End Sub

      Private Sub _documentSaveRecognizedDataAsXmlToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles _documentSaveRecognizedDataAsXmlToolStripMenuItem.Click
         SaveRecognizedDataAsXml(False)
      End Sub

      Private Sub _unwarpToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _unwarpToolStripMenuItem.Click
         UnWarpActive = True
         _mainMenuStrip.Enabled = False
         _mainToolStrip.Enabled = False
         _viewerControl.UpdateUIState()
         _pagesControl.UpdateUIState()
         _viewerControl.InteractiveMode = ViewerControl.ViewerControlInteractiveMode.SelectMode
         _viewerControl.ZonesUpdated()

         Dim unwarpDlg As UnWarpDialog = New UnWarpDialog(Me, _viewerControl)
         AddHandler unwarpDlg.Action, AddressOf unwarpDlg_Action
         unwarpDlg.Show()
      End Sub

      Private Sub unwarpDlg_Action(ByVal sender As Object, ByVal e As ActionEventArgs)
         Dim isInMemory As Boolean = IsOcrDocumentInMemory()
         Dim ocrPage As IOcrPage = Nothing
         If isInMemory Then
            ocrPage = _ocrDocument.Pages(_currentPageIndex)
         Else
            ocrPage = _ocrPage
         End If

         If Not ocrPage Is Nothing Then
            If (Not UnWarpActive) Then
               _viewerControl.UpdateUIState()
               _pagesControl.UpdateUIState()
               _mainMenuStrip.Enabled = True
               _mainToolStrip.Enabled = True
            End If
         End If

         _viewerControl.ZonesUpdated()
         Dim unwarpDlg As UnWarpDialog = TryCast(e.Data, UnWarpDialog)
         If (Not unwarpDlg.IsDisposed) AndAlso (Not unwarpDlg.OkButtonPressed) Then
            Return
         End If

         ' Called from the UnWarpDialog when a OK or Apply buttons clicked
         Select Case e.Action
            Case "UnWarpCommand"
               Dim wait As WaitCursor = New WaitCursor()
               Try
                  ocrPage.Zones.Clear()
                  ocrPage.Unrecognize()
                  ocrPage.SetRasterImage(_viewerControl.ImageViewer.Image)

                  ' Re-paint current page
                  _viewerControl.ZonesUpdated()
                  UpdateUIState()
                  ' Update the thumbnail(s)
                  RefreshPagesControl(True)
                  GotoPage(_currentPageIndex)
               Finally
                  CType(wait, IDisposable).Dispose()
               End Try
         End Select

         RemoveHandler unwarpDlg.Action, AddressOf unwarpDlg_Action
         _viewerControl.UpdateUIState()
         _pagesControl.UpdateUIState()
      End Sub
   End Class


   Public Class ImageListItemData
      Public FileName As String
      Public IsRecognized As Boolean

      Public Sub New(fileName As String, isRecognized As Boolean)
         Me.FileName = fileName
         Me.IsRecognized = isRecognized
      End Sub
   End Class
End Namespace

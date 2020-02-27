' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports Leadtools.Controls
Imports Leadtools.Demos.Dialogs

' In LEADTOOLS v17.5, we added IOcrPageCharacters.UpdateWord method
' that performs most of the functionality available in OcrWordUpdater
' So, for this version of LEADTOOLS. If you wish to use the old
' OcrWordUpdater included with this demo, then undefined the symbol
' below

#Const USE_TOOLKIT_WORD_UPDATER = True

Imports System.IO
Imports System.Drawing.Drawing2D
Imports System.Diagnostics

Imports Leadtools
Imports Leadtools.Codecs
Imports Leadtools.Ocr
Imports Leadtools.Document.Writer

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
   ' The current recognized characters
   Private _ocrPageCharacters As IOcrPageCharacters
   ' The current recognized words
   Private _ocrZoneWords As List(Of List(Of OcrWord))
   ' Selected word index into _ocrZoneWords
   Private _selectedZoneIndex As Integer
   ' Selected word index into the _ocrZoneWords(_selectedZoneIndex)
   Private _selectedWordIndex As Integer

   ' Last document we opened correctly
   Private _lastDocumentFile As String
   ' Minimum and maximum scale percentages allowed
   Private Const _minimumViewerScalePercentage As Double = 1
   Private Const _maximumViewerScalePercentage As Double = 6400
   ' Extra pixels to edge around the word when clicking/highlighting
   Private Const _wordEdge As Integer = 2

   Private _openInitialPath As String = ""

#Region "Main Form code"
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

   Public Sub New()

      ' This call is required by the Windows Form Designer.
      InitializeComponent()

      ' Add any initialization after the InitializeComponent() call.
      ' Setup the caption for this demo
      Messager.Caption = "VB .NET OCR Edit Demo"

      ' Initialize the RasterCodecs object
      _rasterCodecs = New RasterCodecs()

      ' Default to the PDF load resolution to 300
      _rasterCodecs.Options.RasterizeDocument.Load.XResolution = 300
      _rasterCodecs.Options.RasterizeDocument.Load.YResolution = 300
      _rasterCodecs.Options.Pdf.Load.EnableInterpolate = True
      _rasterCodecs.Options.Load.AutoFixImageResolution = True

      If Not DesignMode Then
         ' Use ScaleToGray and Bicubic for optimum viewing of black/white and color images
         Dim props As RasterPaintProperties = _imageViewer.PaintProperties
         props.PaintDisplayMode = props.PaintDisplayMode Or RasterPaintDisplayModeFlags.ScaleToGray Or RasterPaintDisplayModeFlags.Bicubic
         _imageViewer.PaintProperties = props

         ' Pad the viewer
         _imageViewer.Padding = New Padding(10)

         ' These events are needed and not visible from the designer, so
         ' hook into them here
         AddHandler _zoomToolStripComboBox.LostFocus, AddressOf _zoomToolStripComboBox_LostFocus

         ' Call the transform changed event
         _imageViewer_TransformChanged(_imageViewer, EventArgs.Empty)

         _mousePositionLabel.Text = String.Empty
      End If
   End Sub

   Protected Overrides Sub OnLoad(ByVal e As EventArgs)
      If Not DesignMode Then
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

         If dlg.ShowDialog(Me) = DialogResult.OK Then
            _ocrEngine = dlg.OcrEngine

            If _ocrEngine.SettingManager.IsSettingNameSupported("Recognition.SpaceIsValidCharacter") Then
               _ocrEngine.SettingManager.SetBooleanValue("Recognition.SpaceIsValidCharacter", False)
            End If

            Text = String.Format("{0} [{1} Engine]", Messager.Caption, _ocrEngine.EngineType.ToString())

            ' Load the default document
            Dim defaultDocumentFile As String
            If (_ocrEngine.EngineType = OcrEngineType.OmniPageArabic) Then
               defaultDocumentFile = Path.Combine(DemosGlobal.ImagesFolder, "ArabicSample.tif")
            Else
               defaultDocumentFile = Path.Combine(DemosGlobal.ImagesFolder, "ocr1.tif")
            End If

            If (File.Exists(defaultDocumentFile)) Then
               OpenDocument(defaultDocumentFile)
            End If

            UpdateUIState()
         Else
            ' Close the demo
            Close()
         End If
      End Using
   End Sub

   Protected Overrides Sub OnFormClosed(ByVal e As FormClosedEventArgs)
      ' Clean up

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
#End Region ' Main Form code

#Region "Tools"
   Private Sub DoShowError(ByVal ex As Exception)
      ' Shows an error, check if the exception is an OCR, raster or general one
      If (TypeOf ex Is OcrException) Then
         Dim oe As OcrException = CType(ex, OcrException)
         Messager.ShowError(Me, String.Format("LEADTOOLS Error{2}{2}Code: {0}{2}{2}{1}", oe.Code, ex.Message, Environment.NewLine))
      ElseIf (TypeOf ex Is RasterException) Then
         Dim re As RasterException = CType(ex, RasterException)
         Messager.ShowError(Me, String.Format("OCR Error{2}{2}Code: {0}{2}{2}{1}", re.Code, ex.Message, Environment.NewLine))
      Else
         Messager.ShowError(Me, ex)
      End If
   End Sub

   Private Delegate Sub ShowErrorDelegate(ByVal ex As Exception)

   Private Sub ShowError(ByVal ex As Exception)
      If (InvokeRequired) Then
         BeginInvoke(New ShowErrorDelegate(AddressOf DoShowError), New Object() {ex})
      Else
         DoShowError(ex)
      End If
   End Sub

   Private Sub UpdateUIState()
      ' Update the UI controls states

      _fitPageWidthToolStripButton.Checked = (_imageViewer.SizeMode = RasterPaintSizeMode.FitWidth)
      _fitPageToolStripButton.Checked = (_imageViewer.SizeMode = RasterPaintSizeMode.Fit)

      Dim imageOk As Boolean = Not IsNothing(_imageViewer.Image)

      _openToolStripButton.Enabled = True
      _saveToolStripButton.Enabled = imageOk
      _fitPageWidthToolStripButton.Enabled = imageOk
      _fitPageToolStripButton.Enabled = imageOk
      _zoomToolStripComboBox.Enabled = imageOk
      _zoomOutToolStripButton.Enabled = imageOk
      _zoomInToolStripButton.Enabled = imageOk

      _controlsPanel.Enabled = imageOk

      If Not imageOk Then
         _zoomToolStripComboBox.Text = String.Empty
      End If

      _highlightWordsToolStripButton.Enabled = imageOk

      Dim wordIsSelected As Boolean = (_selectedZoneIndex <> -1) AndAlso (_selectedWordIndex <> -1)

      _deleteButton.Enabled = (imageOk AndAlso wordIsSelected)
      _updateButton.Enabled = (imageOk AndAlso wordIsSelected AndAlso _wordTextBox.Text.Trim().Length > 0)

      _deleteWordToolStripButton.Enabled = _deleteButton.Enabled
      _updateWordToolStripButton.Enabled = _updateButton.Enabled
   End Sub
#End Region ' Tools

#Region "File Menu handlers"
   Private Sub _fileToolStripMenuItem_DropDownOpening(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _fileToolStripMenuItem.DropDownOpening
      Dim documentOk As Boolean = Not IsNothing(_ocrPage)

      _fileSaveToolStripMenuItem.Enabled = documentOk
   End Sub

   Private Sub _fileOpenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _fileOpenToolStripMenuItem.Click
      ' Open a document from disk

      ' Show the LEADTOOLS common dialog
      Dim loader As New ImageFileLoader()
      loader.LoadOnlyOnePage = True
      loader.ShowLoadPagesDialog = False
      loader.OpenDialogInitialPath = _openInitialPath

      Try
         ' Insert the pages loader into the document
         If loader.Load(Me, _rasterCodecs, False) > 0 Then
            _openInitialPath = Path.GetDirectoryName(loader.FileName)
            OpenDocument(loader.FileName)
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub _fileSaveToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _fileSaveToolStripMenuItem.Click
      ' Show the save file dialog
      Using dlg As New SaveFileDialog()
         Dim friendlyName As String = DocumentWriter.GetFormatFriendlyName(DocumentFormat.Pdf)
         Dim extension As String = DocumentWriter.GetFormatFileExtension(DocumentFormat.Pdf)

         dlg.Filter = String.Format("{0} Documents (*.{1})|*.{1}|All Files|*.*", friendlyName, extension)

         If Not String.IsNullOrEmpty(_lastDocumentFile) Then
            dlg.FileName = Path.ChangeExtension(_lastDocumentFile, extension)
         End If

         If dlg.ShowDialog(Me) = DialogResult.OK Then
            SaveDocument(dlg.FileName)
         End If
      End Using
   End Sub

   Private Sub _fileExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _fileExitToolStripMenuItem.Click
      Close()
   End Sub
#End Region ' File Menu handlers

#Region "View Menu handlers"
   Private Sub _viewToolStripMenuItem_DropDownOpening(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _viewToolStripMenuItem.DropDownOpening
      ' Update the UI state of the View menu items

      Dim documentOk As Boolean = Not IsNothing(_ocrPage)

      _viewZoomOutToolStripMenuItem.Enabled = documentOk
      _viewZoomInToolStripMenuItem.Enabled = documentOk

      _viewFitWidthToolStripMenuItem.Enabled = documentOk
      _viewFitPageToolStripMenuItem.Enabled = documentOk
      _viewHighlightRecognizedWordsToolStripMenuItem.Enabled = documentOk

      _viewFitWidthToolStripMenuItem.Checked = (documentOk AndAlso _imageViewer.SizeMode = RasterPaintSizeMode.FitWidth)
      _viewFitPageToolStripMenuItem.Checked = (documentOk AndAlso _imageViewer.SizeMode = RasterPaintSizeMode.Fit)
   End Sub

   Private Sub _viewZoomOutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _viewZoomOutToolStripMenuItem.Click
      ZoomViewer(True)
   End Sub

   Private Sub _viewZoomInToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _viewZoomInToolStripMenuItem.Click
      ZoomViewer(False)
   End Sub

   Private Sub _viewFitWidthToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _viewFitWidthToolStripMenuItem.Click
      FitPage(True)
   End Sub

   Private Sub _viewFitPageToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _viewFitPageToolStripMenuItem.Click
      FitPage(False)
   End Sub

   Private Sub _viewHighlightRecognizedWordsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _viewHighlightRecognizedWordsToolStripMenuItem.Click
      _highlightWordsToolStripButton.Checked = _viewHighlightRecognizedWordsToolStripMenuItem.Checked
      _imageViewer.Invalidate()
   End Sub
#End Region ' View Menu handlers

#Region "Words menu handlers"
   Private Sub _wordToolStripMenuItem_DropDownOpening(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _wordToolStripMenuItem.DropDownOpening
      ' Update the UI state of the Words menu items
      _wordUpdateToolStripMenuItem.Enabled = _updateButton.Enabled
      _wordDeleteToolStripMenuItem.Enabled = _deleteButton.Enabled
   End Sub

   Private Sub _wordUpdateToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _wordUpdateToolStripMenuItem.Click
      _updateButton.PerformClick()
   End Sub

   Private Sub _wordDeleteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _wordDeleteToolStripMenuItem.Click
      _deleteButton.PerformClick()
   End Sub
#End Region ' Words menu handlers

#Region "Preferences Menu handlers"
   Private Sub _preferencesPdfResolutionToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _preferencesPdfResolutionToolStripMenuItem.Click
      Using dlg As New LoadResolutionDialog(_rasterCodecs)
         dlg.ShowDialog(Me)
      End Using
   End Sub
#End Region ' Preferences Menu handlers

#Region "Help Menu handlers"
   Private Sub _helpAboutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _helpAboutToolStripMenuItem.Click
      Using aboutDialog As New AboutDialog("OCR Edit", ProgrammingInterface.VB)
         aboutDialog.ShowDialog(Me)
      End Using
   End Sub
#End Region ' Help Menu handlers

#Region "Viewer code"
   Private Sub SetImage(ByVal image As RasterImage)
      _imageViewer.Image = image

      UpdateUIState()
   End Sub

   Public Sub FitPage(ByVal fitWidth As Boolean)
      ' Since we are doing more than one operation on the viewer, it is
      ' recommended to disable then re-enable updates on the viewer to
      ' minimize flickering

      _imageViewer.BeginUpdate()

      If (fitWidth) Then
         _imageViewer.Zoom(ControlSizeMode.FitWidth, 1, _imageViewer.DefaultZoomOrigin)
      Else
         _imageViewer.Zoom(ControlSizeMode.Fit, 1, _imageViewer.DefaultZoomOrigin)
      End If

      _imageViewer.EndUpdate()

      UpdateUIState()
   End Sub

   Private Sub ZoomViewer(ByVal zoomOut As Boolean)
      ' Get the current scale factor
      Dim percentage As Double = _imageViewer.XScaleFactor * 100.0

      ' The valid scale factors are here
      Dim validPercentages() As Double = _
      { _
         _minimumViewerScalePercentage, 6.25, 12.5, 25, 33.3, 50, 66.7, 73.6, 92.5, 100, _
         125, 150, 200, 300, 400, 600, 800, 1200, 1600, 2400, _
         3200, _maximumViewerScalePercentage _
      }

      ' Find out where we are, move to the next one up or down depending on 'zoomOut'
      If zoomOut Then
         For i As Integer = validPercentages.Length - 1 To 0 Step -1
            If percentage > validPercentages(i) Then
               percentage = validPercentages(i)
               Exit For
            End If
         Next
      Else
         For i As Integer = 0 To validPercentages.Length - 1
            If percentage < validPercentages(i) Then
               percentage = validPercentages(i)
               Exit For
            End If
         Next
      End If

      SetViewerZoomPercentage(percentage)
   End Sub

   Private Sub UpdateZoomValueFromControl()
      ' We are invoking this instead of changing the properties
      ' directly because the Text value of a combo box is not
      ' updated till after the lost focus or enter event is exited
      BeginInvoke(New MethodInvoker(AddressOf DoUpdateZoomValueFromControl))
   End Sub

   Private Sub DoUpdateZoomValueFromControl()
      If Not IsNothing(_imageViewer.Image) Then
         Dim factor As Double = _imageViewer.XScaleFactor * 100.0
         _zoomToolStripComboBox.Text = factor.ToString("F1") + "%"
      Else
         _zoomToolStripComboBox.Text = String.Empty
      End If
   End Sub

   Private Sub _imageViewer_TransformChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _imageViewer.TransformChanged, _imageViewer.TransformChanged
      If IsHandleCreated Then
         UpdateZoomValueFromControl()
         UpdateUIState()
      End If
   End Sub

   Private Sub _openToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _openToolStripButton.Click
      _fileOpenToolStripMenuItem.PerformClick()
   End Sub

   Private Sub _saveToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _saveToolStripButton.Click
      _fileSaveToolStripMenuItem.PerformClick()
   End Sub

   Private Sub _zoomOutToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _zoomOutToolStripButton.Click
      ZoomViewer(True)
   End Sub

   Private Sub _zoomInToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _zoomInToolStripButton.Click
      ZoomViewer(False)
   End Sub

   Private Sub _zoomToolStripComboBox_LostFocus(ByVal sender As Object, ByVal e As EventArgs)
      UpdateZoomValueFromControl()
   End Sub

   Private Sub _zoomToolStripComboBox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _zoomToolStripComboBox.SelectedIndexChanged
      ' Parse the new zoom value
      Dim str As String = _zoomToolStripComboBox.Text.Trim()

      Select Case str
         Case "Actual Size"
            SetViewerZoomPercentage(100)

         Case "Fit Page"
            _fitPageToolStripButton.PerformClick()

         Case "Fit Width"
            _fitPageWidthToolStripButton.PerformClick()

         Case Else
            If Not String.IsNullOrEmpty(str) Then
               Dim val As Double = Double.Parse(str.Substring(0, str.Length - 1))
               SetViewerZoomPercentage(val)
            End If
      End Select
   End Sub

   Private Sub _zoomToolStripComboBox_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _zoomToolStripComboBox.KeyPress
      If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
         ' User has pressed enter, parse the new zoom value

         Dim str As String = _zoomToolStripComboBox.Text.Trim()

         If Not String.IsNullOrEmpty(str) Then
            ' Remove the % sign if present
            If str.EndsWith("%") Then
               str = str.Remove(str.Length - 1, 1).Trim()
            End If

            ' Try to parse the new zoom value
            Dim percentage As Double
            If Double.TryParse(str, percentage) Then
               SetViewerZoomPercentage(percentage)
            End If

            UpdateZoomValueFromControl()
         End If
      End If
   End Sub

   Private Sub _fitPageWidthToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _fitPageWidthToolStripButton.Click
      FitPage(True)
   End Sub

   Private Sub _fitPageToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _fitPageToolStripButton.Click
      FitPage(False)
   End Sub

   Private Sub _highlightWordsToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _highlightWordsToolStripButton.Click
      _viewHighlightRecognizedWordsToolStripMenuItem.Checked = _highlightWordsToolStripButton.Checked
      _imageViewer.Invalidate()
   End Sub

   Private Sub _updateWordToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _updateWordToolStripButton.Click
      _updateButton.PerformClick()
   End Sub

   Private Sub _deleteWordToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _deleteWordToolStripButton.Click
      _deleteButton.PerformClick()
   End Sub

   Private Sub SetViewerZoomPercentage(ByVal percentage As Double)
      ' Normalize the percentage based on min/max value allowed
      percentage = Math.Max(_minimumViewerScalePercentage, Math.Min(_maximumViewerScalePercentage, percentage))

      If Math.Abs(_imageViewer.XScaleFactor * 100.0 - percentage) > 0.01 Then
         _imageViewer.BeginUpdate()

         _imageViewer.Zoom(ControlSizeMode.None, percentage / 100.0, _imageViewer.DefaultZoomOrigin)

         _imageViewer.EndUpdate()

         _imageViewer_TransformChanged(_imageViewer, EventArgs.Empty)

         UpdateUIState()
      End If
   End Sub

   Private Sub _imageViewer_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles _imageViewer.MouseMove, _imageViewer.MouseMove
      Dim str As String

      If Not IsNothing(_imageViewer.Image) Then
         ' Show the mouse position in physical and logical (inches) coordinates

         Dim physical As LeadPoint = LeadPoint.Create(e.X, e.Y)
         Dim pixels As LeadPoint = _imageViewer.ConvertPoint(Nothing, ImageViewerCoordinateType.Control, ImageViewerCoordinateType.Image, physical)

         str = String.Format("{0},{1} px", CType(pixels.X, Integer), CType(pixels.Y, Integer))
      Else
         str = String.Empty
      End If

      _mousePositionLabel.Text = str
   End Sub
#End Region ' Viewer code

#Region "OCR open/recognize and save code"
   Private Sub OpenDocument(ByVal documentFileName As String)
      ' Create a new document, add the page to it and recognize it
      ' If all the above is OK, then use it

      ' Setup the arguments for the callback
      Dim args As New Dictionary(Of String, Object)()
      args.Add("documentFileName", documentFileName)

      ' Call the process dialog
      Try
         Dim allowProgress As Boolean = _preferencesUseCallbacksToolStripMenuItem.Checked
         Using dlg As New OcrProgressDialog(allowProgress, "Loading and Recognizing Document", AddressOf DoLoadAndRecognizeDocument, args)
            dlg.ShowDialog(Me)
         End Using
      Catch ex As Exception
         ShowError(ex)
      Finally
         UpdateUIState()
      End Try
   End Sub

   Private Sub DoLoadAndRecognizeDocument(ByVal dlg As OcrProgressDialog, ByVal args As Dictionary(Of String, Object))
      ' Perform load and recognize here

      Dim callback As OcrProgressCallback = dlg.OcrProgressCallback
      Dim ocrDocument As IOcrDocument = Nothing

      Try
         Dim documentFileName As String = CType(args("documentFileName"), String)

         ocrDocument = _ocrEngine.DocumentManager.CreateDocument(Nothing, OcrCreateDocumentOptions.InMemory)

         Dim ocrPage As IOcrPage = Nothing

         If Not dlg.IsCanceled Then
            ' If we are not using a progress bar, update the description text
            If IsNothing(callback) Then
               dlg.UpdateDescription("Loading the document (first page only)...")
            End If

            ocrPage = ocrDocument.Pages.AddPage(documentFileName, callback)
         End If

         If Not dlg.IsCanceled Then
            ' If we are not using a progress bar, update the description text
            If IsNothing(callback) Then
               dlg.UpdateDescription("Recognizing the page(s) of the document...")
            End If

            ocrPage.Recognize(callback)
         End If

         If Not dlg.IsCanceled Then
            ' We did not cancel, use this document
            SetDocument(ocrDocument, documentFileName)
            ocrDocument = Nothing
         End If
      Catch ex As Exception
         ShowError(ex)
      Finally
         If IsNothing(callback) Then
            dlg.EndOperation()
         End If

         ' Clean up
         If Not IsNothing(ocrDocument) Then
            ocrDocument.Dispose()
         End If
      End Try
   End Sub

   Private Sub SaveDocument(ByVal documentFileName As String)
      ' Update the characters from what we have so far
      ' The word is remove now from the OCR results
      _ocrPage.SetRecognizedCharacters(_ocrPageCharacters)

      ' Save this document as PDF

      ' Setup the arguments for the callback
      Dim args As New Dictionary(Of String, Object)()
      args.Add("documentFileName", documentFileName)
      args.Add("viewDocument", _preferencesViewSavedDocumentToolStripMenuItem.Checked)

      ' Call the process dialog
      Try
         Dim allowProgress As Boolean = _preferencesUseCallbacksToolStripMenuItem.Checked
         Using dlg As New OcrProgressDialog(allowProgress, "Saving Document", AddressOf DoSaveDocument, args)
            dlg.ShowDialog(Me)
         End Using
      Catch ex As Exception
         ShowError(ex)
      Finally
         UpdateUIState()
      End Try
   End Sub

   Private Sub DoSaveDocument(ByVal dlg As OcrProgressDialog, ByVal args As Dictionary(Of String, Object))
      ' Perform load and recognize here

      Dim callback As OcrProgressCallback = dlg.OcrProgressCallback

      Try
         Dim documentFileName As String = CType(args("documentFileName"), String)
         Dim viewDocument As Boolean = CType(args("viewDocument"), Boolean)

         If Not dlg.IsCanceled Then
            ' If we are not using a progress bar, update the description text
            If IsNothing(callback) Then
               dlg.UpdateDescription("Saving the document ...")
            End If


            Dim pdfOptions As PdfDocumentOptions = TryCast(_ocrDocument.DocumentWriterInstance.GetOptions(DocumentFormat.Pdf), PdfDocumentOptions)
            pdfOptions.Producer = "LEAD Technologies, Inc."
            pdfOptions.Creator = "LEADTOOLS PDFWriter"
            _ocrDocument.DocumentWriterInstance.SetOptions(DocumentFormat.Pdf, pdfOptions)
            _ocrDocument.Save(documentFileName, DocumentFormat.Pdf, callback)
         End If

         ' If it has not been canceled, show the final document (if applicable)
         If (Not dlg.IsCanceled) AndAlso viewDocument Then
            Process.Start(documentFileName)
         End If
      Catch ex As Exception
         ShowError(ex)
      Finally
         If IsNothing(callback) Then
            dlg.EndOperation()
         End If
      End Try
   End Sub

   Private Sub SetDocument(ByVal ocrDocument As IOcrDocument, ByVal documentFileName As String)
      ' Delete the old document if it exists
      If Not IsNothing(_ocrDocument) Then
         _ocrDocument.Dispose()
      End If

      _lastDocumentFile = documentFileName
      _ocrDocument = ocrDocument
      _ocrPage = _ocrDocument.Pages(0)

      BuildWordLists()

      _wordTextBox.Text = String.Empty

      SetImage(_ocrPage.GetRasterImage())

      UpdateUIState()
   End Sub
#End Region ' OCR open/recognize and save code

   Private Sub BuildWordLists()
      _ocrPageCharacters = _ocrPage.GetRecognizedCharacters()
      _ocrZoneWords = New List(Of List(Of OcrWord))()

      ' Build the words
      For Each zoneCharacters As IOcrZoneCharacters In _ocrPageCharacters
         Dim words As New List(Of OcrWord)()
         words.AddRange(zoneCharacters.GetWords())

         _ocrZoneWords.Add(words)
      Next

      _selectedZoneIndex = -1
      _selectedWordIndex = -1
   End Sub

   Private Sub _imageViewer_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles _imageViewer.MouseClick, _imageViewer.MouseClick
      If IsNothing(_imageViewer.Image) Then
         Return
      End If

      ' Get the mouse click in logical coordinates (page) and select the word under this point (if any)

      Dim physical As New LeadPoint(e.X, e.Y)
      Dim pixels As LeadPoint = _imageViewer.ConvertPoint(Nothing, ImageViewerCoordinateType.Control, ImageViewerCoordinateType.Image, physical)

      FindWordUnderPoint(New LeadPoint(Convert.ToInt32(pixels.X), Convert.ToInt32(pixels.Y)))
   End Sub

   Private Sub FindWordUnderPoint(ByVal pt As LeadPoint)
      For Each zoneWords As List(Of OcrWord) In _ocrZoneWords
         For wordIndex As Integer = 0 To zoneWords.Count - 1
            Dim word As OcrWord = zoneWords(wordIndex)

            Dim rc As LeadRect = word.Bounds

            rc.Inflate(_wordEdge, _wordEdge)

            If rc.Contains(pt) Then
               ' Found a word, select it and exit
               SelectWord(_ocrZoneWords.IndexOf(zoneWords), wordIndex, word)
               Return
            End If
         Next
      Next

      ' No word was selected, de-select the last word
      SelectWord(-1, -1, New OcrWord())
   End Sub

   Private Sub SelectWord(ByVal wordZoneIndex As Integer, ByVal wordIndex As Integer, ByVal word As OcrWord)
      _selectedZoneIndex = wordZoneIndex
      _selectedWordIndex = wordIndex
      _wordTextBox.Text = word.Value

      _imageViewer.Invalidate()
      UpdateUIState()
   End Sub

   Private Sub _imageViewer_PostRender(ByVal sender As System.Object, ByVal e As ImageViewerRenderEventArgs) Handles _imageViewer.PostRender, _imageViewer.PostRender
      If IsNothing(_imageViewer.Image) Then
         Return
      End If

      Dim g As Graphics = e.PaintEventArgs.Graphics

      If _viewHighlightRecognizedWordsToolStripMenuItem.Checked Then
         ' Highlight all words
         Using b As New SolidBrush(Color.FromArgb(64, Color.Black))
            Using p As New Pen(Color.FromArgb(64, Color.Black))
               For zoneIndex As Integer = 0 To _ocrZoneWords.Count - 1
                  Dim zoneWords As List(Of OcrWord) = _ocrZoneWords(zoneIndex)
                  For wordIndex As Integer = 0 To zoneWords.Count - 1
                     ' Only draw this if it is not the selected word
                     ' This will be painted later
                     If zoneIndex <> _selectedZoneIndex OrElse wordIndex <> _selectedWordIndex Then
                        HighlightWord(g, zoneIndex, wordIndex, b, p)
                     End If
                  Next
               Next
            End Using
         End Using
      End If

      ' If we have a word selected, highlight it
      If _selectedZoneIndex <> -1 AndAlso _selectedWordIndex <> -1 Then
         Using b As New SolidBrush(Color.FromArgb(128, Color.Yellow))
            Using p As New Pen(Color.FromArgb(128, Color.Red))
               HighlightWord(g, _selectedZoneIndex, _selectedWordIndex, b, p)
            End Using
         End Using
      End If
   End Sub

   Private Sub HighlightWord(ByVal g As Graphics, ByVal zoneIndex As Integer, ByVal wordIndex As Integer, ByVal b As Brush, ByVal p As Pen)
      Dim word As OcrWord = _ocrZoneWords(zoneIndex)(wordIndex)

      ' Get the word bounding rectangle and convert to physical so we can draw it on the viewer surface
      Dim rc As LeadRect = LeadRectD.FromLTRB(word.Bounds.Left, word.Bounds.Top, word.Bounds.Right, word.Bounds.Bottom).ToLeadRect()
      rc = _imageViewer.ConvertRect(Nothing, ImageViewerCoordinateType.Image, ImageViewerCoordinateType.Control, rc)

      ' Make the rectangle a little bit bigger for visibility purposes
      rc.Inflate(_wordEdge, _wordEdge)

      g.FillRectangle(b, Leadtools.Demos.Converters.ConvertRect(rc))
      g.DrawRectangle(p, rc.X, rc.Y, rc.Width - 1, rc.Height - 1)
   End Sub

   Private Sub _updateButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _updateButton.Click
      UpdateWord(_wordTextBox.Text)
   End Sub

   Private Sub _deleteButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _deleteButton.Click
      ' Nothing will delete a word
      UpdateWord(Nothing)
   End Sub

   Private Sub _wordTextBox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _wordTextBox.TextChanged
      UpdateUIState()
   End Sub

   Private Sub UpdateWord(ByVal value As String)
      ' Refer to the note on the beginning of this file
#If USE_TOOLKIT_WORD_UPDATER Then
      _ocrPageCharacters.UpdateWord( _
         _ocrZoneWords(_selectedZoneIndex), _
         _selectedZoneIndex, _
         _selectedWordIndex, _
         value)
#Else
      OcrWordUpdater.Update( _
         _selectedZoneIndex, _
         _selectedWordIndex, _
         value, _
         _ocrPage, _
         _ocrZoneWords, _
         _ocrPageCharacters)
#End If ' #if USE_TOOLKIT_WORD_UPDATER

      If (Not value Is Nothing) Then
         ' Word has been updated, invalidate
         _imageViewer.Invalidate()
         UpdateUIState()
      Else
         ' Word is deleted, remove selection
         SelectWord(-1, -1, New OcrWord())
      End If
   End Sub
End Class

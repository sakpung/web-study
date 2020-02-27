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

Imports Leadtools
Imports Leadtools.Codecs
Imports Leadtools.Controls
Imports Leadtools.Ocr
Imports System.IO

Imports Leadtools.Drawing
Imports Leadtools.Demos.Dialogs

Namespace OcrZonesRubberBandDemo
   Partial Public Class MainForm : Inherits Form
      Private _ocrEngine As IOcrEngine
      Private _document As IOcrDocument
      Private _currentHighlightRect As LeadRect
      Private _codecs As RasterCodecs
      Private _ocrEngineType As OcrEngineType
      Private _openInitialPath As String = ""
      Private _rubberBand As ImageViewerRubberBandInteractiveMode

      Public Sub New()
         InitializeComponent()

         '
         ' TODO: Add any constructor code after InitializeComponent call
         '
         Messager.Caption = "OCR Zones Rubberband Demo"

         _codecs = New RasterCodecs()

         ' Use the new RasterizeDocumentOptions to default loading document files at 300 DPI
         _codecs.Options.RasterizeDocument.Load.XResolution = 300
         _codecs.Options.RasterizeDocument.Load.YResolution = 300
         _codecs.Options.Pdf.Load.EnableInterpolate = True
         _codecs.Options.Load.AutoFixImageResolution = True

         InitializeViewer(_viewer)
         InitializeZoomComboBox()

         _viewer.InteractiveModes.BeginUpdate()
         _viewer.InteractiveModes.Clear()
         _rubberBand = New ImageViewerRubberBandInteractiveMode()
         AddHandler _rubberBand.RubberBandCompleted, AddressOf _rubberBand_RubberBandCompleted
         _rubberBand.MouseButtons = System.Windows.Forms.MouseButtons.Left
         _rubberBand.WorkOnBounds = True
         _rubberBand.IdleCursor = Cursors.Cross
         _rubberBand.WorkingCursor = Cursors.Cross
         _viewer.InteractiveModes.Add(_rubberBand)
         _viewer.InteractiveModes.EndUpdate()


         UpdateMyControls()
      End Sub

      Protected Overrides Sub OnLoad(ByVal e As EventArgs)
         If Not DesignMode Then
            BeginInvoke(New MethodInvoker(AddressOf Startup))
         End If

         MyBase.OnLoad(e)
      End Sub

      Private Sub Startup()
         Dim settings As Settings = New Settings()

         Dim engineType As String = settings.OcrEngineType

         ' Show the engine selection dialog
         Dim dlg As OcrEngineSelectDialog = New OcrEngineSelectDialog(Messager.Caption, engineType, True)
         Try
            dlg.RasterCodecsInstance = _codecs

            If dlg.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK Then
               _ocrEngine = dlg.OcrEngine
               _ocrEngineType = dlg.SelectedOcrEngineType

               ' Add the selected engine name to the demo caption
               Text = Text + " [" + _ocrEngineType.ToString() + " Engine]"

               _document = _ocrEngine.DocumentManager.CreateDocument(Nothing, OcrCreateDocumentOptions.InMemory)

               StartupEngine()

               'load default image
               LoadImage(True)
               Dim message As String = String.Format("To use this demo: {0} 1) Load an image with text on it. {0} 2) Draw a rectangle using the mouse around the portion of text you want to recognize.", Environment.NewLine)
               MessageBox.Show(message, "Instructions")

               UpdateMyControls()
            Else
               ' Close the demo
               Close()
            End If
         Finally
            CType(dlg, IDisposable).Dispose()
         End Try
      End Sub

      Private Sub _miFileOpen_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _miFileOpen.Click
         LoadImage(False)
      End Sub

      Private Sub LoadImage(ByVal loadDefaultImage As Boolean)
         Dim loader As ImageFileLoader = New ImageFileLoader()
         Dim bLoaded As Boolean

         Try
            loader.LoadOnlyOnePage = True
            loader.OpenDialogInitialPath = _openInitialPath

            If loadDefaultImage Then
               If _ocrEngineType = OcrEngineType.OmniPageArabic Then
                  bLoaded = loader.Load(Me, DemosGlobal.ImagesFolder & "\ArabicSample.tif", _codecs, 1, -1)
               Else
                  bLoaded = loader.Load(Me, DemosGlobal.ImagesFolder & "\ocr1.tif", _codecs, 1, -1)
               End If
            Else
               bLoaded = loader.Load(Me, _codecs, True) > 0
            End If

            If bLoaded Then
               _openInitialPath = Path.GetDirectoryName(loader.FileName)
               If Not _viewer.Image Is Nothing Then
                  _viewer.Image.Dispose()
               End If

               _viewer.Image = loader.Image

               If _viewer.Image.XResolution < 150 Then
                  _viewer.Image.XResolution = 150
               End If

               If _viewer.Image.YResolution < 150 Then
                  _viewer.Image.YResolution = 150
               End If

               If _ocrEngine.IsStarted Then
                  If _document.Pages.Count > 0 Then
                     _document.Pages.Clear()
                  End If

                  _document.Pages.AddPage(_viewer.Image.Clone(), Nothing)
               End If
               _currentHighlightRect = LeadRect.Empty
               _recognitionResults.Text = ""

               _tsMainZoomComboBox_SelectedIndexChanged(_tsMainZoomComboBox, New EventArgs())
            End If
         Catch ex As Exception
            Messager.ShowFileOpenError(Me, loader.FileName, ex)
         Finally
            _viewer.Invalidate()
         End Try
      End Sub

      Private Sub _viewer_Paint(ByVal sender As Object, ByVal e As ImageViewerRenderEventArgs) Handles _viewer.PostRenderItem, _viewer.PostRenderItem
         Try
            If Not _viewer.Image Is Nothing AndAlso _currentHighlightRect <> LeadRect.Empty Then
               Dim imageRect As LeadRect = _viewer.ConvertRect(Nothing, ImageViewerCoordinateType.Image, ImageViewerCoordinateType.Control, _currentHighlightRect)
               Dim drawRect As Rectangle = Rectangle.FromLTRB(imageRect.Left, imageRect.Top, imageRect.Right, imageRect.Bottom)

               e.PaintEventArgs.Graphics.DrawRectangle(New Pen(Color.Orange), drawRect)
               e.PaintEventArgs.Graphics.FillRectangle(New SolidBrush(Color.FromArgb(70, Color.Yellow)), drawRect)
            End If
         Catch ex As Exception
            Messager.ShowError(Me, ex)
         End Try
      End Sub

      Private Sub MainForm_FormClosing(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles MyBase.FormClosing
         Try
            Dim settings As Settings = New Settings()
            settings.OcrEngineType = _ocrEngineType.ToString()
            settings.Save()

            If Not _document Is Nothing Then
               _document.Dispose()
            End If

            If Not _ocrEngine Is Nothing AndAlso _ocrEngine.IsStarted Then
               _ocrEngine.Shutdown()
               _ocrEngine.Dispose()
            End If
         Catch ex As Exception
            Messager.ShowError(Me, ex)
         End Try
      End Sub

      Private Sub StartupEngine()
         If Not _viewer.Image Is Nothing Then
            _document.Pages.AddPage(_viewer.Image.Clone(), Nothing)
         End If

         ' Change the text box direction and font for more suitable Arabic font.
         If _ocrEngineType = OcrEngineType.OmniPageArabic Then
            _recognitionResults.RightToLeft = RightToLeft.Yes
            _recognitionResults.Font = New System.Drawing.Font("Times New Roman", 11)
         End If
      End Sub

      Private Sub UpdateMyControls()
         Dim bEnable As Boolean = Not _ocrEngine Is Nothing AndAlso _ocrEngine.IsStarted

         _miFileOpen.Enabled = bEnable
         _miFileSetLoadRes.Enabled = bEnable
         _tsMainZoomComboBox.Enabled = bEnable
         _recognitionResults.Enabled = bEnable
      End Sub

      Public Sub ShowError(ByVal ex As Exception, ByVal owner As IWin32Window, ByVal engineType As OcrEngineType)
         If TypeOf ex Is OcrException Then
            Dim oe As OcrException = CType(IIf(TypeOf ex Is OcrException, ex, Nothing), OcrException)
            Messager.ShowError(owner, String.Format("LEADTOOLS Error" & Constants.vbLf & "Code: {0}" & Constants.vbLf & "Message:{1}", oe.Code, ex.Message))
         ElseIf TypeOf ex Is RasterException Then
            Dim re As RasterException = CType(IIf(TypeOf ex Is RasterException, ex, Nothing), RasterException)
            Messager.ShowError(owner, String.Format("OCR Error" & Constants.vbLf & "Code: {0}" & Constants.vbLf & "Message:{1}", re.Code, ex.Message))
         Else
            Messager.ShowError(owner, ex)
         End If
      End Sub

      Private Shared Sub InitializeViewer(ByVal viewer As ImageViewer)
         ' Appearance
         viewer.BackColor = SystemColors.AppWorkspace
         viewer.Dock = DockStyle.Fill
         viewer.Padding = New Padding(4)

         ' Always use DPI
         viewer.UseDpi = True

         ' Set Scale-to-Gray
         Dim properties As RasterPaintProperties = RasterPaintProperties.Default
         properties.PaintDisplayMode = RasterPaintDisplayModeFlags.Bicubic Or RasterPaintDisplayModeFlags.ScaleToGray
         properties.PaintEngine = RasterPaintEngine.Gdi
         properties.UsePaintPalette = True
         viewer.PaintProperties = properties
      End Sub

      Private Sub InitializeZoomComboBox()
         _tsMainZoomComboBox.Items.Add("Fit")
         _tsMainZoomComboBox.Items.Add("Page Width")

         Dim initialValues As Integer() = {100, 25, 40, 50, 60, 75}

         For Each i As Integer In initialValues
            _tsMainZoomComboBox.Items.Add(i & "%")
         Next i

         For i As Integer = 125 To 1000 Step 25
            _tsMainZoomComboBox.Items.Add(i & "%")
         Next i

         _tsMainZoomComboBox.SelectedIndex = 0
      End Sub

      Private Sub _tsMainZoomComboBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _tsMainZoomComboBox.SelectedIndexChanged
         ' Zoom
         ' Get the size mode and scale factor
         Dim sizeMode As ControlSizeMode = ControlSizeMode.None
         Dim scaleFactor As Double = _viewer.ScaleFactor

         Dim selected As String = _tsMainZoomComboBox.SelectedItem.ToString()

         If selected = "Fit" Then
            sizeMode = ControlSizeMode.Fit
            scaleFactor = 1.0
         ElseIf selected = "Page Width" Then
            sizeMode = ControlSizeMode.FitWidth
            scaleFactor = 1.0
         Else
            Dim percentage As Integer = Integer.Parse(selected.Replace("%", ""))
            sizeMode = ControlSizeMode.None
            scaleFactor = CDbl(percentage) / 100.0
         End If

         ' Check if the size mode or scale factor has changed
         If Not sizeMode = _viewer.SizeMode OrElse scaleFactor <> _viewer.ScaleFactor Then
            ' yes, change it
            _viewer.BeginUpdate()

            _viewer.Zoom(sizeMode, scaleFactor, _viewer.DefaultZoomOrigin)

            _viewer.EndUpdate()
         End If
      End Sub

      Private Sub _rubberBand_RubberBandCompleted(ByVal sender As Object, ByVal e As ImageViewerRubberBandEventArgs)
         Try
            If _document.Pages Is Nothing Then
               Return
            End If

            _tsMainZoomComboBox.Enabled = False

            Dim cursor As WaitCursor = New WaitCursor()
            Try
               _currentHighlightRect = _viewer.ConvertRect(
                     Nothing,
                     ImageViewerCoordinateType.Control,
                     ImageViewerCoordinateType.Image,
                     LeadRect.FromLTRB(e.Points(0).X, e.Points(0).Y, e.Points(1).X, e.Points(1).Y))

               If (_currentHighlightRect.Width > 0 AndAlso _currentHighlightRect.Height > 2) Then
                  Dim zone As OcrZone = New Leadtools.Ocr.OcrZone()
                  zone.Bounds = _currentHighlightRect
                  zone.ZoneType = OcrZoneType.Text

                  zone.CharacterFilters = OcrZoneCharacterFilters.None

                  _document.Pages.Clear()
                  _document.Pages.AddPage(_viewer.Image, Nothing)
                  _document.Pages(0).Zones.Add(zone)

                  _document.Pages(0).Recognize(Nothing)
                  _recognitionResults.Text = _document.Pages(0).GetText(-1)

                  If _recognitionResults.Text = Constants.vbLf Or _recognitionResults.Text = "" Then
                     Messager.ShowInformation(Me, "No text was recognized.")
                  End If
               End If
            Finally
               CType(cursor, IDisposable).Dispose()
            End Try

         Catch ex As Exception
            Messager.ShowError(Me, ex)
         Finally
            _viewer.Invalidate()

            Application.DoEvents()

            _tsMainZoomComboBox.Enabled = True
         End Try
      End Sub

      Private Sub _miFileSetLoadRes_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _miFileSetLoadRes.Click
         Try
            Dim setResDlg As SetResolution = New SetResolution()

            setResDlg._xRes = _codecs.Options.RasterizeDocument.Load.XResolution
            setResDlg._yRes = _codecs.Options.RasterizeDocument.Load.YResolution

            If setResDlg.ShowDialog(Me) = DialogResult.OK Then
               ' Update PDF load resolutions
               _codecs.Options.RasterizeDocument.Load.XResolution = setResDlg._xRes
               _codecs.Options.RasterizeDocument.Load.YResolution = setResDlg._yRes

            End If
         Catch ex As Exception
            Messager.ShowError(Me, ex.Message)
         End Try
      End Sub

      Private Sub _miHelpAbout_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _miHelpAbout.Click
         Using aboutDialog As New AboutDialog("Ocr Zones Rubberband", ProgrammingInterface.VB)
            aboutDialog.ShowDialog(Me)
         End Using
      End Sub

      Private Sub _miFileExit_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _miFileExit.Click
         Close()
      End Sub

      Private Sub _viewer_MouseUp(ByVal sender As Object, ByVal e As MouseEventArgs) Handles _viewer.MouseUp, _viewer.MouseUp
         _viewer.Invalidate()
      End Sub
   End Class
End Namespace

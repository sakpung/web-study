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
Imports System.Windows.Forms
Imports System.IO
Imports System.Diagnostics
Imports System.Text

Imports Leadtools
Imports Leadtools.Codecs
Imports Leadtools.Controls
Imports Leadtools.Ocr
Imports Leadtools.Document.Writer
Imports Leadtools.Drawing

Partial Public Class MainForm : Inherits Form
   Private _codecs As RasterCodecs
   Private _viewer As ImageViewer
   Private _ocrEngine As IOcrEngine = Nothing
   Private _ocrEngineType As OcrEngineType
   Private _frameRect As Rectangle = New Rectangle(0, 0, 0, 0)
   Private _rubberBandingHelper As ViewerRubberBandingHelper
   Private _document As IOcrDocument
   Private _autoOcrImageName As String
   Private _openInitialPath As String = ""

   Public Sub New()
      InitializeComponent()

      Messager.Caption = ".NET VB OCR Modules Demo"
      Text = Messager.Caption

      _codecs = New RasterCodecs()

      _codecs.Options.RasterizeDocument.Load.XResolution = 300
      _codecs.Options.RasterizeDocument.Load.YResolution = 300
      _codecs.Options.Pdf.Load.EnableInterpolate = True
      _codecs.Options.Load.AutoFixImageResolution = True

      ' Create and initialize the raster image viewer
      _viewer = New ImageViewer()
      _viewer.Dock = DockStyle.Fill
      _viewer.BackColor = SystemColors.AppWorkspace
      _viewer.Padding = New Padding(10)
      _viewer.ViewBorderThickness = 2
      _viewer.ViewHorizontalAlignment = ControlAlignment.Center
      _viewer.ViewVerticalAlignment = ControlAlignment.Center
      _viewer.UseDpi = True
      _viewer.Zoom(ControlSizeMode.Fit, 200 / 100.0, _viewer.DefaultZoomOrigin)
      Dim props As RasterPaintProperties = RasterPaintProperties.Default
      props.PaintDisplayMode = RasterPaintDisplayModeFlags.ScaleToGray
      props.PaintEngine = RasterPaintEngine.Gdi
      _viewer.PaintProperties = props
      _splitContainer.Panel2.Controls.Add(_viewer)
      _viewer.BringToFront()
      AddHandler _viewer.PostRender, AddressOf _viewer_PostRender

      _rubberBandingHelper = New ViewerRubberBandingHelper()
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
         If dlg.ShowDialog(Me) = DialogResult.OK Then
            _ocrEngine = dlg.OcrEngine
            _ocrEngineType = dlg.SelectedOcrEngineType

            InitEngines()
         Else
            ' Close the demo
            Close()
         End If
      Finally
         CType(dlg, IDisposable).Dispose()
      End Try
   End Sub

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

   Private Sub CleanUp()
      If Not _document Is Nothing Then
         _document.Dispose()
         _document = Nothing
      End If

      If Not _ocrEngine Is Nothing AndAlso _ocrEngine.IsStarted Then
         _ocrEngine.Shutdown()
         _ocrEngine.Dispose()
      End If

      If Not _codecs Is Nothing Then
         _codecs.Dispose()
      End If

   End Sub

   Private Shared ReadOnly Property ImagesFolder() As String
      Get
         Dim strLEADTOOLSFolder As String = DemosGlobal.ImagesFolder + "\"
         Return strLEADTOOLSFolder
      End Get
   End Property

   Protected Overrides Sub OnFormClosed(ByVal e As FormClosedEventArgs)
      SaveSettings()
      MyBase.OnFormClosed(e)
   End Sub

   Private Function LoadImage(ByVal fileName As String) As Boolean
      Try
         Dim image As RasterImage = _codecs.Load(fileName)

         ' Clear any previously added pages and then add the new loaded page
         _document.Pages.Clear()

         ' Add the page first.
         _document.Pages.AddPage(image, Nothing)

         ' Add zones by default.
         AddZones(False)

         ' Engine will correct the page deskew before AutoZone or Recognize, so we need to load the page again form the engine.
         _viewer.Image = _document.Pages(_document.Pages.Count - 1).GetRasterImage()

         _viewer.Refresh()
         Return True
      Catch ex As Exception
         Messager.ShowError(Me, ex)
         Return False
      End Try
   End Function

   Private Sub InitEngines()
      _documentFormatSelector.SetDocumentWriter(_ocrEngine.DocumentWriterInstance, False)

      StartupEngine()

      _documentFormatSelector.SetOcrEngineType(_ocrEngineType)

      If (_ocrEngineType = OcrEngineType.OmniPageArabic) Then
         _autoOcrImageName = "ArabicSample.Tif"
      Else
         _autoOcrImageName = "OCR1.Tif"
      End If
      ' Add the selected engine name to the demo caption
      Text = Text + " [" + _ocrEngineType.ToString() + " Engine]"

      UpdateSupportedOcrModulesList()
      UpdateMyControls()
      Dim settings As Settings = New Settings()

      ' If user provided a command line argument then forget about the saved OCR Module
      ' otherwise use the saved OCR module (if there is any).
      If Environment.GetCommandLineArgs().Length > 1 Then
         Dim arguments As String() = Environment.GetCommandLineArgs()
         If arguments(1).Equals("Auto") Then
            _cmbOcrModules.SelectedIndex = 1
         ElseIf arguments(1).Equals("Omr") Then
            _cmbOcrModules.SelectedIndex = 2
         ElseIf arguments(1).Equals("HnrText") Then
            _cmbOcrModules.SelectedIndex = 3
         ElseIf arguments(1).Equals("HnrNum") Then
            _cmbOcrModules.SelectedIndex = 4
         Else
            _cmbOcrModules.SelectedIndex = 0
         End If
      Else
         If (Not String.IsNullOrEmpty(settings.OCRModule)) Then
            Dim i As Integer = 0
            Do While i < _cmbOcrModules.Items.Count
               Dim itemData As MyItemData = CType(_cmbOcrModules.Items(i), MyItemData)
               If itemData.ZoneType = CInt(System.Enum.Parse(GetType(OcrZoneType), settings.OCRModule)) Then
                  _cmbOcrModules.SelectedIndex = i
                  Exit Do
               End If
         i += 1
            Loop
            If _cmbOcrModules.SelectedIndex < 0 Then ' No match found
               _cmbOcrModules.SelectedIndex = 0
            End If
         Else
            _cmbOcrModules.SelectedIndex = 0
         End If
      End If

      If Not _ocrEngine Is Nothing AndAlso _ocrEngine.IsStarted Then
         Dim format As DocumentFormat = DocumentFormat.Pdf

         ' Load settings for the selected Document Format
         If (Not String.IsNullOrEmpty(settings.DocumentFormat)) Then
            Try
               format = CType(System.Enum.Parse(GetType(DocumentFormat), settings.DocumentFormat), DocumentFormat)
            Catch
            End Try
         End If

         _documentFormatSelector.SelectedFormat = format
      End If

      ' Load settings for user selected View Final Document check box status 
      _cbViewFinalDocument.Checked = settings.ViewFinalDocument
   End Sub

   Private Sub SaveSettings()
      Try
         Dim settings As Settings = New Settings()

         settings.OcrEngineType = _ocrEngineType.ToString()
         settings.OCRModule = (CType(_cmbOcrModules.SelectedItem, MyItemData)).OriginalName
         settings.DocumentFormat = _documentFormatSelector.SelectedFormat.ToString()
         settings.ViewFinalDocument = _cbViewFinalDocument.Checked
         settings.Save()
         settings.Upgrade()
         settings.Save()
      Catch e1 As Exception
      End Try
   End Sub

   Private Sub AddZones(ByVal bUserDrawnZone As Boolean)
      Try
         If (bUserDrawnZone AndAlso (_frameRect.Width < 2 Or _frameRect.Height < 2)) Then
            Exit Sub
         End If

         ' Initialize the OcrZone and add it to the image.
         Dim zoneData As New OcrZone()
         Dim itemData As MyItemData = CType(_cmbOcrModules.SelectedItem, MyItemData)
         Dim selectedModule As OcrZoneType = CType(itemData.ZoneType, OcrZoneType)

         Select Case selectedModule
            Case OcrZoneType.Text ' AUTO
               If bUserDrawnZone Then
                  zoneData.Bounds = New LeadRect(_frameRect.X, _frameRect.Y, _frameRect.Width, _frameRect.Height)
                  zoneData.ZoneType = OcrZoneType.Text
                  _document.Pages(0).Zones.Add(zoneData)
               Else
                  _document.Pages(0).AutoZone(Nothing)
               End If
               Exit Select

            Case OcrZoneType.Micr
               ' MICR
               If bUserDrawnZone Then
                  zoneData.Bounds = New LeadRect(_frameRect.X, _frameRect.Y, _frameRect.Width, _frameRect.Height)
               Else
                  zoneData.Bounds = New LeadRect(38, 678, 1655, 87)
               End If

               zoneData.ZoneType = OcrZoneType.Micr
               _document.Pages(0).Zones.Add(zoneData)
               Exit Select


            Case OcrZoneType.Omr ' OMR
               If bUserDrawnZone Then
                  zoneData.Bounds = New LeadRect(_frameRect.X, _frameRect.Y, _frameRect.Width, _frameRect.Height)

                  zoneData.ZoneType = OcrZoneType.Omr
                  _document.Pages(0).Zones.Add(zoneData)
               Else
#If LT_CLICKONCE Then
                  _document.Pages(0).LoadZones("Mix_omr.ozf")
#Else
                  _document.Pages(0).LoadZones(ImagesFolder + "Mix_omr.ozf")
#End If
               End If
               Exit Select

            Case OcrZoneType.Icr ' HandPrintedCharacter
               If bUserDrawnZone Then
                  zoneData.Bounds = New LeadRect(_frameRect.X, _frameRect.Y, _frameRect.Width, _frameRect.Height)
               Else
                  zoneData.Bounds = New LeadRect(0, 0, _document.Pages(0).Width, _document.Pages(0).Height)
               End If
               zoneData.ZoneType = OcrZoneType.Icr
               zoneData.CharacterFilters = CType(itemData.CharacterFilters, OcrZoneCharacterFilters)

               _document.Pages(0).Zones.Add(zoneData)
               Exit Select

         End Select
      Catch ex As Exception
         Messager.ShowError(Me, ex)
      End Try
   End Sub

   Private Sub UpdateSupportedOcrModulesList()
      ' Clear the previous items
      _cmbOcrModules.Items.Clear()

      Dim ocrModules As MyItemData() = {New MyItemData("Auto - OCR", "", CInt(OcrZoneType.Text), CInt(OcrZoneCharacterFilters.None), ImagesFolder & _autoOcrImageName, 0, 0), New MyItemData("Auto - MICR", OcrZoneType.Micr.ToString(), CInt(OcrZoneType.Micr), CInt(OcrZoneCharacterFilters.None), ImagesFolder & "MICR_SAMPLE.Tif", 0, 0), New MyItemData("OMR", OcrZoneType.Omr.ToString(), CInt(OcrZoneType.Omr), CInt(OcrZoneCharacterFilters.None), ImagesFolder & "MIXED.Tif", 0, 0), New MyItemData("Hand Printed Characters", OcrZoneType.Icr.ToString(), CInt(OcrZoneType.Icr), CInt(OcrZoneCharacterFilters.None), ImagesFolder & "DEMOICR2.Tif", 0, 0), New MyItemData("Hand Printed Numerals", OcrZoneType.Icr.ToString(), CInt(OcrZoneType.Icr), CInt(OcrZoneCharacterFilters.Digit), ImagesFolder & "DEMOICR.Tif", 0, 0)}


      If Not _ocrEngine Is Nothing AndAlso _ocrEngine.IsStarted Then
         For Each item As MyItemData In ocrModules

            If _ocrEngine.ZoneManager.IsZoneTypeSupported(CType(item.ZoneType, OcrZoneType)) Then
               _cmbOcrModules.Items.Add(item)
            End If
         Next item
      End If
   End Sub

   Private Sub UpdateMyControls()
      Dim bEnable As Boolean = False

      If Not _ocrEngine Is Nothing AndAlso _ocrEngine.IsStarted Then
         bEnable = True
         _documentFormatSelector.Enabled = bEnable

         If _document.Pages.Count > 0 AndAlso _document.Pages(0).Zones.Count > 0 Then
            _btnClearZones.Enabled = bEnable AndAlso _document.Pages(0).Zones.Count > 0
         Else
            _btnClearZones.Enabled = False
         End If
      Else
         _documentFormatSelector.Enabled = False
         _btnClearZones.Enabled = False
      End If

      _cmbOcrModules.Enabled = bEnable
      _cbViewFinalDocument.Enabled = True
      _btnBrowseImageFile.Enabled = bEnable
      _btnRecognize.Enabled = bEnable

      If (Not bEnable) Then
         _cmbOcrModules.SelectedIndex = -1
      End If
   End Sub

   Private Sub MainForm_Resize(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Resize
      _lblImageFileName.Width = _statusBar.ClientSize.Width - 25
   End Sub

   Private Sub _btnBrowseImageFile_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnBrowseImageFile.Click
      Dim loader As ImageFileLoader = New ImageFileLoader()

      loader.OpenDialogInitialPath = _openInitialPath

      Try
         If loader.Load(Me, _codecs, False) > 0 Then
            If LoadImage(loader.FileName) Then
               _openInitialPath = Path.GetDirectoryName(loader.FileName)
               _lblImageFileName.Text = loader.FileName
               Dim itemData As MyItemData = CType(_cmbOcrModules.Items(_cmbOcrModules.SelectedIndex), MyItemData)
               itemData.ImageFileName = loader.FileName
               RemoveHandler _cmbOcrModules.SelectedIndexChanged, AddressOf _cmbOcrModules_SelectedIndexChanged
               _cmbOcrModules.Items(_cmbOcrModules.SelectedIndex) = itemData
               AddHandler _cmbOcrModules.SelectedIndexChanged, AddressOf _cmbOcrModules_SelectedIndexChanged
            End If
         End If
      Catch ex As Exception
         Messager.ShowFileOpenError(Me, loader.FileName, ex)
      End Try
   End Sub

   Private Sub LoadOcrModuleAssociatedImage()
      Dim itemData As MyItemData = CType(_cmbOcrModules.Items(_cmbOcrModules.SelectedIndex), MyItemData)

      LoadImage(itemData.ImageFileName)
      _lblImageFileName.Text = itemData.ImageFileName
   End Sub

   Private Sub StartupEngine()
      If (Not _rubberBandingHelper.IsStarted) Then
         AddHandler _rubberBandingHelper.RubberBand, AddressOf _rubberBandingHelper_RubberBand
         _rubberBandingHelper.Viewer = _viewer
         _rubberBandingHelper.EnableAutomation = False
         _rubberBandingHelper.Start()
      End If

      _document = _ocrEngine.DocumentManager.CreateDocument(Nothing, OcrCreateDocumentOptions.InMemory)

      UpdateMyControls()
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

   Private Sub _cmbOcrModules_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _cmbOcrModules.SelectedIndexChanged
      Dim wait As WaitCursor = New WaitCursor()
      Try
         If _cmbOcrModules.SelectedIndex < 0 Then
            Return
         End If

         If Not _document Is Nothing Then
            _document.Dispose()
            _document = Nothing
         End If

         _document = _ocrEngine.DocumentManager.CreateDocument(Nothing, OcrCreateDocumentOptions.InMemory)

         ' Load the default image associated with each ocr module.
         LoadOcrModuleAssociatedImage()

         ' Save the image file name the user associate with the selected OCR module.
         Dim itemData As MyItemData = CType(_cmbOcrModules.Items(_cmbOcrModules.SelectedIndex), MyItemData)
         itemData.ImageFileName = _lblImageFileName.Text
         RemoveHandler _cmbOcrModules.SelectedIndexChanged, AddressOf _cmbOcrModules_SelectedIndexChanged
         _cmbOcrModules.Items(_cmbOcrModules.SelectedIndex) = itemData
         AddHandler _cmbOcrModules.SelectedIndexChanged, AddressOf _cmbOcrModules_SelectedIndexChanged

         _omrOptionsButton.Enabled = (CType(itemData.ZoneType, OcrZoneType) = OcrZoneType.Omr)

         UpdateMyControls()
      Finally
         CType(wait, IDisposable).Dispose()
         UpdateMyControls()
      End Try
   End Sub

   Private Sub _btnRecognize_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnRecognize.Click
      Try
         Dim wait As WaitCursor = New WaitCursor()
         Try
            Dim format As DocumentFormat = _documentFormatSelector.SelectedFormat
            Dim documentFileName As String = _lblImageFileName.Text

            documentFileName = String.Concat(documentFileName, ".", DocumentWriter.GetFormatFileExtension(format))

            _document.Pages(0).Recognize(Nothing)
            _document.Save(documentFileName, format, Nothing)

            ' Engine will correct the page deskew before AutoZone or Recognize, so we need to load the page again form the engine.
            _viewer.Image = _document.Pages(_document.Pages.Count - 1).GetRasterImage()
            _viewer.Refresh()
            UpdateMyControls()

            ' if the "View Final Document" option is checked then no need to show this message since
            ' it will load the saved document file.
            If (Not _cbViewFinalDocument.Checked) Then
               Messager.ShowInformation(Me, String.Format("The output document file was saved at ({0})", documentFileName))
            Else
               If (File.Exists(documentFileName)) Then
                  Try
                     Process.Start(documentFileName)
                  Catch
                     Messager.ShowError(Me, "Unable to open generated results file with external viewing application")
                  End Try
               Else
                  Messager.ShowError(Me, "Unable to open generated results file with external viewing application." & Constants.vbLf & "The system cannot find the file specified")
               End If
            End If
         Finally
            CType(wait, IDisposable).Dispose()
         End Try
      Catch ex As Exception
         Messager.ShowError(Me, ex.Message)
      End Try
   End Sub

   Private Sub _btnClearZones_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnClearZones.Click
      If Not _ocrEngine Is Nothing Then
         If _ocrEngine.IsStarted Then
            _document.Pages(0).Zones.Clear()
            _viewer.Refresh()
            UpdateMyControls()
         End If
      End If
   End Sub

   Private Sub _viewer_PostRender(ByVal sender As Object, ByVal e As ImageViewerRenderEventArgs)
      Try
         If Not _viewer.Image Is Nothing AndAlso _document.Pages(0).Zones.Count > 0 Then
            Dim i As Integer = 0
            Do While i < _document.Pages(0).Zones.Count
               Dim rect As Rectangle = Leadtools.Demos.Converters.ConvertRect(_document.Pages(0).Zones(i).Bounds)
               rect = Rectangle.Round(_rubberBandingHelper.RectangleToPhysical(rect))

               Dim pen As Pen = New Pen(Color.Red, 2)
               Try
                  _rubberBandingHelper.DrawRectangle(e.PaintEventArgs.Graphics, rect, pen, Nothing, False)
               Finally
                  CType(pen, IDisposable).Dispose()
               End Try
               i += 1
            Loop
         End If
      Catch e1 As Exception
      End Try
   End Sub

   Private Sub _rubberBandingHelper_RubberBand(ByVal sender As Object, ByVal e As ViewerRubberBandingHelperEventArgs)
      Try
         If Not _viewer.Image Is Nothing Then
            _frameRect = e.Bounds
            AddZones(True)
            _viewer.Invalidate()
            UpdateMyControls()
         End If
      Catch ex As Exception
         Messager.ShowError(Me, ex)
      End Try
   End Sub

   Private Sub _omrOptionsButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _omrOptionsButton.Click
      Using dlg As New OcrOmrOptionsDialog(_ocrEngine)
         dlg.ShowDialog(Me)
      End Using
   End Sub

   Private Sub _documentFormatSelector_SelectedFormatChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _documentFormatSelector.SelectedFormatChanged
      Dim options As DocumentOptions = _ocrEngine.DocumentWriterInstance.GetOptions(_documentFormatSelector.SelectedFormat)

      _documentFormatSelector.FormatHasOptions = True
      _documentFormatSelector.TotalPages = If((_document IsNot Nothing), _document.Pages.Count, 1)
      Select Case _documentFormatSelector.SelectedFormat
         Case DocumentFormat.Xps
            _documentFormatSelector.FormatHasOptions = False
            Exit Select

         Case DocumentFormat.Doc
            _documentFormatSelector.FormatHasOptions = True
            Exit Select

         Case DocumentFormat.Docx
            _documentFormatSelector.FormatHasOptions = True
            Exit Select

         Case DocumentFormat.Rtf
            _documentFormatSelector.FormatHasOptions = True
            Exit Select

         Case DocumentFormat.Xls
            _documentFormatSelector.FormatHasOptions = False
            Exit Select

         Case DocumentFormat.AltoXml
            _documentFormatSelector.FormatHasOptions = True
            Exit Select

         Case DocumentFormat.Pub
            _documentFormatSelector.FormatHasOptions = False
            Exit Select

         Case DocumentFormat.Mob
            _documentFormatSelector.FormatHasOptions = False
            Exit Select

         Case DocumentFormat.Svg
            _documentFormatSelector.FormatHasOptions = False
            Exit Select
      End Select

      If Not options Is Nothing Then
         _ocrEngine.DocumentWriterInstance.SetOptions(_documentFormatSelector.SelectedFormat, options)
      End If
   End Sub
End Class

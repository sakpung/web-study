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
Imports Leadtools.Twain
Imports Leadtools.Codecs
Imports Leadtools
Imports Leadtools.Ocr
Imports System.IO
Imports Leadtools.Forms.Commands
Imports System.Diagnostics
Imports System.Threading
Imports Leadtools.Drawing
Imports Leadtools.Controls
Imports System.Drawing.Drawing2D
Imports Leadtools.Demos.Dialogs
Imports Leadtools.ImageProcessing

Namespace MrtdPassportReaderDemo
   Partial Public Class MainForm : Inherits Form
      Public Sub New()
         InitializeComponent()
      End Sub

      <STAThread()> _
      Shared Sub Main()
         
         If Not Support.SetLicense() Then
            Return
         End If

         Dim bLocked As Boolean = RasterSupport.IsLocked(RasterSupportType.Forms)
         If bLocked Then
            MessageBox.Show("Forms support must be unlocked for this demo!", "Support Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
         End If

         Dim bOCRLocked As Boolean = (RasterSupport.IsLocked(RasterSupportType.OcrLEAD)) Or (RasterSupport.IsLocked(RasterSupportType.OcrOmniPage))
         If bOCRLocked Then
            MessageBox.Show("OCR support must be unlocked for this demo!", "Support Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
         End If

         If bLocked Or bOCRLocked Then
            Return
         End If

         Application.EnableVisualStyles()
         Application.SetCompatibleTextRenderingDefault(False)
         Application.Run(New MainForm())
      End Sub

      Private twainSession As TwainSession = Nothing
      Private inTwainAcquire As Boolean
      Private rasterCodecs As RasterCodecs
      Private ocrEngine As IOcrEngine
      Private _noneInteractiveMode As ImageViewerNoneInteractiveMode = Nothing
      Private _panInteractiveMode As ImageViewerPanZoomInteractiveMode = Nothing
      Private _zoomToInteractiveMode As ImageViewerZoomToInteractiveMode = Nothing
      Private _reader As MRTDReader
      Private scannedImage As RasterImage = Nothing
      Private _textEditMode As Boolean = False
      Private selectedRect As LeadRect = LeadRect.Empty
      Private brush As Brush = Nothing
      Private pen As Pen = Nothing
      Private infoDlg As InformationDlg = New InformationDlg()

      Public Property NoneInteractiveMode() As ImageViewerNoneInteractiveMode
         Get
            Return _noneInteractiveMode
         End Get
         Set(value As ImageViewerNoneInteractiveMode)
            _noneInteractiveMode = Value
         End Set
      End Property

      Public Property PanInteractiveMode() As ImageViewerPanZoomInteractiveMode
         Get
            Return _panInteractiveMode
         End Get
         Set(value As ImageViewerPanZoomInteractiveMode)
            _panInteractiveMode = Value
         End Set
      End Property

      Private Sub Startup()
         Try
            'Check if ocr engine was passed in. The recognition demos have the ability to launch this demo and it will pass
            'the ocr engine it is using. We will default to that engine
            Dim commandArgs As String() = Environment.GetCommandLineArgs()
            If commandArgs.Length = 2 Then
               Dim settings As Settings = New Settings()
               settings.OcrEngineType = commandArgs(1)
               settings.Save()
            End If

            If (Not StartUpEngines()) Then
               Messager.ShowError(Me, "One or more required engines did not start. The application will now close.")
               Me.Close()
               Return
            End If

            Messager.Caption = "LEADTOOLS Passport Reader"

            _reader = New MRTDReader()
            _reader.OcrEngine = ocrEngine
            brush = New SolidBrush(Color.FromArgb(127, Color.Yellow))
            pen = New Pen(brush)

         Catch exp As Exception
            Messager.ShowError(Me, exp)
         End Try

         _noneInteractiveMode = New ImageViewerNoneInteractiveMode()
         _panInteractiveMode = New ImageViewerPanZoomInteractiveMode()
         _panInteractiveMode.MouseButtons = System.Windows.Forms.MouseButtons.Left
         _zoomToInteractiveMode = New ImageViewerZoomToInteractiveMode()


         rasterImageViewer1.InteractiveModes.BeginUpdate()
         rasterImageViewer1.InteractiveModes.Add(_noneInteractiveMode)
         rasterImageViewer1.InteractiveModes.Add(_panInteractiveMode)
         rasterImageViewer1.InteractiveModes.Add(_zoomToInteractiveMode)
         AddHandler rasterImageViewer1.PostRender, AddressOf rasterImageViewer1_PostRender
         rasterImageViewer1.InteractiveModes.EndUpdate()

         ' Load the default document
         Dim defaultDocumentFile As String = Path.Combine(DemosGlobal.ImagesFolder, "MRZ_SAMPLE.jpg")

         If File.Exists(defaultDocumentFile) Then
            OpenImage(defaultDocumentFile)
         End If
      End Sub

      Private Sub rasterImageViewer1_PostRender(ByVal sender As Object, ByVal e As ImageViewerRenderEventArgs)
         If (Not selectedRect.IsEmpty) Then
            Dim rect As LeadRectD = rasterImageViewer1.ImageTransform.TransformRect(selectedRect.ToLeadRectD())
            e.PaintEventArgs.Graphics.FillRectangle(brush, New Rectangle(CInt(rect.X), CInt(rect.Y), CInt(rect.Width), CInt(rect.Height)))
         End If
      End Sub

      Protected Overrides Sub OnLoad(ByVal e As EventArgs)
         If (Not DesignMode) Then
            BeginInvoke(New MethodInvoker(AddressOf Startup))
         End If

         MyBase.OnLoad(e)
      End Sub

      Private Sub StartupTwain()
         Try
            twainSession = New TwainSession()
            If TwainSession.IsAvailable(Me.Handle) Then
               twainSession.Startup(Me.Handle, "LEAD Technologies, Inc.", "LEAD Test Applications", "Version 1.0", "TWAIN Test Application", TwainStartupFlags.None)
               AddHandler twainSession.AcquirePage, AddressOf twainSession_AcquirePage
            End If
         Catch ex As TwainException
            If ex.Code = TwainExceptionCode.InvalidDll Then
               twainSession = Nothing
               Messager.ShowError(Me, "You have an old version of TWAINDSM.DLL. Please download latest version of this DLL from www.twain.org")
            Else
               twainSession = Nothing
               Messager.ShowError(Me, ex)
            End If
         Catch ex As Exception
            Messager.ShowError(Me, ex)
            twainSession = Nothing
         End Try
      End Sub

      Public Function StartUpEngines() As Boolean
         Try
            StartUpRasterCodecs()
            StartUpOcrEngine()
            StartupTwain()
            Return True
         Catch
            Return False
         End Try
      End Function

      Private Sub ShutDownEngines()
         If Not ocrEngine Is Nothing AndAlso ocrEngine.IsStarted Then
            Dim settings As Settings = New Settings()
            settings.OcrEngineType = ocrEngine.EngineType.ToString()
            settings.Save()

            ocrEngine.Shutdown()
            ocrEngine.Dispose()
         End If

         If Not twainSession Is Nothing Then
            twainSession.Shutdown()
         End If
      End Sub

      Private Sub StartUpRasterCodecs()
         Try
            rasterCodecs = New RasterCodecs()

            'To turn off the dithering method when converting colored images to 1-bit black and white image during the load
            'so the text in the image is not damaged.
            RasterDefaults.DitheringMethod = RasterDitheringMethod.None
         Catch exp As Exception
            Messager.ShowError(Me, exp)
            Throw
         End Try
      End Sub

      Private Sub StartUpOcrEngine()
         Try
            Dim settings As Settings = New Settings()
            Dim engineType As String = settings.OcrEngineType

            ocrEngine = OcrEngineManager.CreateEngine(OcrEngineType.LEAD, False)
            ocrEngine.Startup(Nothing, Nothing, Nothing, Nothing)

                If ocrEngine.SettingManager.IsSettingNameSupported("Recognition.RecognitionModuleTradeoff") Then
                    ocrEngine.SettingManager.SetEnumValue("Recognition.RecognitionModuleTradeoff", "Accurate")
                End If

            Catch exp As Exception
                Messager.ShowError(Me, exp)
                Throw
            End Try
      End Sub

      Private Sub twainSession_AcquirePage(ByVal sender As Object, ByVal e As TwainAcquirePageEventArgs)
         If (Not (scannedImage) Is Nothing) Then
            scannedImage.Dispose()
            scannedImage = Nothing
         End If

         If (Not (e.Image) Is Nothing) Then
            scannedImage = e.Image.Clone
         End If
      End Sub

      Public Sub LoadImageScanner()
         If (Not DemosGlobal.CheckKnown3rdPartyTwainIssues(Me, twainSession.SelectedSourceName())) Then
            Return
         End If

         Dim showUI As Boolean = False
         inTwainAcquire = True
         'Set the scanner to scan a specified number of pages, scan at 1bpp B/W, and at 300DPI
         Try
            twainSession.MaximumTransferCount = 1
            twainSession.Resolution = New SizeF(300, 300)
         Catch
            MessageBox.Show("Unable to set scanner to 300DPI.")
            showUI = True
         End Try

         If showUI Then
            twainSession.Acquire(TwainUserInterfaceFlags.Modal)
         Else
            twainSession.Acquire(TwainUserInterfaceFlags.None)
         End If

         inTwainAcquire = False
      End Sub

      Private Sub EnableControls(ByVal bEnable As Boolean)
         Me.fileToolStripMenuItem.Enabled = bEnable
         Me.fileToolStripMenuItem.Enabled = bEnable
         Me.ControlBox = bEnable
         Me._btn_Edit.Enabled = bEnable
      End Sub


      Private Sub OpenImage(ByVal path As String)
         Dim image As RasterImage = rasterCodecs.Load(path)
         OpenImage(image)
      End Sub

      Private Sub OpenImage(ByVal image As RasterImage)
         EnableControls(False)
         ProcessImage(image)
         _btnFit_Click(Nothing, Nothing)
      End Sub

      Private Sub openToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles openToolStripMenuItem.Click
         Try
            Dim loader As ImageFileLoader = New ImageFileLoader()
            loader.ShowLoadPagesDialog = True
            loader.MultiSelect = False
            loader.ShowPdfOptions = True
            loader.ShowLoadPagesDialog = False
            If loader.Load(Me, rasterCodecs, True) > 0 Then
               OpenImage(loader.Image)
            End If
         Catch exp As Exception
            EnableControls(True)
            Messager.ShowError(Me, exp)
         End Try
      End Sub

      Private Sub ProcessImage(ByVal rasterImage As RasterImage)
         ClearOldData(True)
         Me.rasterImageViewer1.Image = rasterImage
         _reader.ProcessImage(rasterImage)

         _tB_MRZCode.Visible = False
         _tB_readonlyMRZCode.Visible = True
         _btn_Edit.Text = "Edit"
         _textEditMode = False

         UpdateControls()
      End Sub

      Private Function ThrowExp(ByVal ex As Exception) As Object
         MessageBox.Show(ex.Message)
         Return Nothing
      End Function

      Private Sub ClearOldData(ByVal clearImage As Boolean)
         selectedRect = LeadRect.Empty
         dGV_Results.Rows.Clear()
         dGV_Errors.Rows.Clear()
         If (clearImage) Then
            Me.rasterImageViewer1.Image = Nothing
         End If

         Me.rasterImageViewer1.Invalidate()
         _tB_readonlyMRZCode.Text = ""
         _tB_MRZCode.Text = ""
         closeToolStripMenuItem.Enabled = False
         Application.DoEvents()
      End Sub

      Private Sub UpdateControls()
         scanImageToolStripMenuItem.Enabled = Not twainSession Is Nothing AndAlso TwainSession.IsAvailable(Me.Handle)
         EnableControls(True)
         dGV_Results.Rows.Clear()
         dGV_Errors.Rows.Clear()

         _tB_readonlyMRZCode.Lines = _reader.Lines
         If Not rasterImageViewer1.Image Is Nothing Then
            selectedRect = _reader.Bounds
         Else
            selectedRect = LeadRect.Empty
         End If
         closeToolStripMenuItem.Enabled = True
         For Each item As KeyValuePair(Of MRTDField, MRTDDataElement) In _reader.Results
            Dim row As DataGridViewRow = New DataGridViewRow()
            row.CreateCells(dGV_Results, ToReadbleString(item.Key.ToString()), item.Value.ReadableValue, item.Value.MrzCharacters)
            row.Tag = item.Value
            If (Not item.Value.IsValid) Then
               row.DefaultCellStyle.BackColor = Color.Red
               Dim errorRow As DataGridViewRow = New DataGridViewRow()
               errorRow.CreateCells(dGV_Errors, ToReadbleString(item.Key.ToString()) & " Is Invalid")
               dGV_Errors.Rows.Add(errorRow)
            End If
            dGV_Results.Rows.Add(row)
         Next item

         If Not _reader.Errors = MRTDErrors.NoError Then
            For Each value As MRTDErrors In System.Enum.GetValues(GetType(MRTDErrors))
               If (_reader.Errors And CType(value, MRTDErrors)) = CType(value, MRTDErrors) AndAlso CType(value, MRTDErrors) <> MRTDErrors.NoError Then
                  Dim row As DataGridViewRow = New DataGridViewRow()
                  row.CreateCells(dGV_Errors, ToReadbleString((CType(value, MRTDErrors)).ToString()))
                  row.Tag = (CType(value, MRTDErrors))
                  dGV_Errors.Rows.Add(row)
               End If
            Next value
         End If
      End Sub

      Private Sub _btnZoomNormal_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnZoomNormal.Click
         Try
            rasterImageViewer1.Zoom(ControlSizeMode.ActualSize, 1, rasterImageViewer1.DefaultZoomOrigin)
         Catch exp As Exception
            Messager.ShowError(Me, exp)
         End Try
      End Sub

      Private Sub _btnFit_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnFit.Click
         Try
            rasterImageViewer1.Zoom(ControlSizeMode.FitAlways, 1, rasterImageViewer1.DefaultZoomOrigin)
         Catch exp As Exception
            Messager.ShowError(Me, exp)
         End Try
      End Sub

      Private Sub _btnFitWidth_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnFitWidth.Click
         Try
            rasterImageViewer1.Zoom(ControlSizeMode.FitWidth, 1, rasterImageViewer1.DefaultZoomOrigin)
         Catch exp As Exception
            Messager.ShowError(Me, exp)
         End Try
      End Sub

      Private Sub _btnZoomIn_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnZoomIn.Click
         Try
            Dim oldScaleFactor As Double = rasterImageViewer1.ScaleFactor
            rasterImageViewer1.Zoom(ControlSizeMode.None, oldScaleFactor + 0.1F, rasterImageViewer1.DefaultZoomOrigin)
         Catch exp As Exception
            Messager.ShowError(Me, exp)
         End Try
      End Sub

      Private Sub _btnZoomOut_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnZoomOut.Click
         Try
            If rasterImageViewer1.ScaleFactor > 0.1F Then
               Dim oldScaleFactor As Double = rasterImageViewer1.ScaleFactor
               rasterImageViewer1.Zoom(ControlSizeMode.None, oldScaleFactor - 0.1F, rasterImageViewer1.DefaultZoomOrigin)
            End If
         Catch exp As Exception
            Messager.ShowError(Me, exp)
         End Try
      End Sub

      Private Sub _btnZoomDrawTool_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnZoomDrawTool.Click
         ClearCheck(CType(IIf(TypeOf sender Is ToolStripButton, sender, Nothing), ToolStripButton))
         DisableInteractiveModes()
         rasterImageViewer1.InteractiveModes.EnableById(_zoomToInteractiveMode.Id)
      End Sub

      Private Sub _btnUseDpi_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnUseDpi.Click
         rasterImageViewer1.UseDpi = _btnUseDpi.Checked

         If _btnUseDpi.Checked Then
            _btnUseDpi.ToolTipText = "Ignore Image DPI When Viewing"
         Else
            _btnUseDpi.ToolTipText = "Use Image DPI When Viewing"
         End If
      End Sub

      Private Sub DisableInteractiveModes()
         For Each mode As ImageViewerInteractiveMode In rasterImageViewer1.InteractiveModes
            mode.IsEnabled = False
         Next mode
      End Sub

      Private Sub _btnPanTool_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnPanTool.Click
         ClearCheck(CType(IIf(TypeOf sender Is ToolStripButton, sender, Nothing), ToolStripButton))
         DisableInteractiveModes()
         rasterImageViewer1.InteractiveModes.EnableById(_panInteractiveMode.Id)
      End Sub

      Private Sub ClearCheck(ByVal toolStripButton As ToolStripButton)
         _btnPanTool.Checked = toolStripButton.Equals(_btnPanTool)
         _btnZoomDrawTool.Checked = toolStripButton.Equals(_btnZoomDrawTool)
      End Sub

      Private Sub closeToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles closeToolStripMenuItem.Click
         ClearOldData(True)
      End Sub

      Private Sub exitToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles exitToolStripMenuItem.Click
         Me.Close()
      End Sub

      Protected Overrides Sub OnClosed(ByVal e As EventArgs)
         ClearOldData(True)
         If Not _reader Is Nothing Then
            _reader.OcrEngine = Nothing
         End If

         ShutDownEngines()
         If Not ocrEngine Is Nothing AndAlso ocrEngine.IsStarted Then
            ocrEngine.Shutdown()
            ocrEngine.Dispose()
         End If
         MyBase.OnClosed(e)
      End Sub

      Private Sub aboutToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles aboutToolStripMenuItem.Click
         Using aboutDialog As New AboutDialog("Machine Readable Travel Documents Reader", ProgrammingInterface.VB)
            aboutDialog.ShowDialog(Me)
         End Using
      End Sub

      Private Sub _btn_Edit_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btn_Edit.Click
         _textEditMode = Not _textEditMode

         If _textEditMode Then
            _btn_Edit.Text = "Done Editing"
            _tB_MRZCode.Text = _tB_readonlyMRZCode.Text
            _tB_MRZCode.Visible = True
            _tB_readonlyMRZCode.Visible = False
            _tB_MRZCode.Focus()
         Else
            _btn_Edit.Text = "Edit"
            _tB_readonlyMRZCode.Text = _tB_MRZCode.Text
            _tB_MRZCode.Visible = False
            _tB_readonlyMRZCode.Visible = True

            If _tB_readonlyMRZCode.Text.Length > 0 Then
               _reader.ProcessText(_tB_readonlyMRZCode.Lines)
               UpdateControls()
            End If
         End If
      End Sub

      Private Sub _tB_readonlyMRZCode_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _tB_readonlyMRZCode.TextChanged
         Dim size As Size = TextRenderer.MeasureText(_tB_readonlyMRZCode.Text & " ", _tB_readonlyMRZCode.Font)
         _tB_readonlyMRZCode.Width = size.Width
         _tB_readonlyMRZCode.Height = CInt(size.Height * 3 / 2)

         _tB_readonlyMRZCode.Location = New Point(CInt(_tB_MRZCode.Width / 2 - _tB_readonlyMRZCode.Width / 2), CInt(_tB_MRZCode.Bounds.Height / 2 - _tB_readonlyMRZCode.Height / 2))
      End Sub

      Private Sub MainForm_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
         If infoDlg.ShouldShow() Then
            infoDlg.ShowDialog()
         End If
      End Sub

      Private Sub informationToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles informationToolStripMenuItem.Click
         infoDlg.ShowDialog()
      End Sub

      Private Function ToReadbleString(ByVal str As String) As String
         Dim str2 As String = CType(IIf(TypeOf str.Clone() Is String, str.Clone(), Nothing), String)
         Dim i As Integer = 0
         Do While i < str2.Length
            If Char.IsUpper(str2.Chars(i)) AndAlso i <> 0 Then
               str2 = str2.Insert(i, " ")
               i += 1
            End If
            i += 1
         Loop

         Return str2
      End Function

      Private Sub _tB_readonlyMRZCode_Resize(ByVal sender As Object, ByVal e As EventArgs) Handles _tB_readonlyMRZCode.Resize
         _tB_readonlyMRZCode_TextChanged(sender, Nothing)
      End Sub

      Private Sub enableImprovingResultsToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles enableImprovingResultsToolStripMenuItem.Click
         enableImprovingResultsToolStripMenuItem.Checked = Not enableImprovingResultsToolStripMenuItem.Checked
         _reader.ImproveResults = enableImprovingResultsToolStripMenuItem.Checked
         If Not rasterImageViewer1.Image Is Nothing Then
            Me.OpenImage(rasterImageViewer1.Image.Clone())
         End If
      End Sub

      Private Sub scanImageToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
         'select the desired scanner
         inTwainAcquire = True
         Try
            If (Not (twainSession) Is Nothing) Then
               If (twainSession.SelectSource(Nothing) <> DialogResult.OK) Then
                  inTwainAcquire = False
                  Return
               End If

            End If

         Catch ex As Exception
            Messager.ShowError(Me, ex)
         End Try

         inTwainAcquire = False
         Application.DoEvents()
         'Scan the first page
         LoadImageScanner()
         If (Not (scannedImage) Is Nothing) Then
            OpenImage(scannedImage)
         End If

      End Sub

      Private Function FeederLoaded() As Boolean
         Try
            'first enable feeder
            Dim autoFeedCap As New TwainCapability()

            autoFeedCap.Information.Type = TwainCapabilityType.FeederEnabled
            autoFeedCap.Information.ContainerType = TwainContainerType.OneValue

            autoFeedCap.OneValueCapability.ItemType = TwainItemType.Bool
            autoFeedCap.OneValueCapability.Value = True

            Try
               twainSession.SetCapability(autoFeedCap, TwainSetCapabilityMode.[Set])
            Catch
            End Try
            'now check if feeder is loaded
            Dim feederLoadedCap As New TwainCapability()
            feederLoadedCap = twainSession.GetCapability(TwainCapabilityType.FeederLoaded, TwainGetCapabilityMode.GetValues)
            Return CBool(feederLoadedCap.OneValueCapability.Value)
         Catch
            Dim ex As New Exception("To recognize scanned pages in this demo, your scanner must have a feeder")
            Me.ThrowExp(ex)
         End Try
         Return False
      End Function

      Private Sub dGV_Results_CellClick(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles dGV_Results.CellClick
         Dim selectedRowIndex As Integer = e.RowIndex

         If selectedRowIndex >= 0 AndAlso selectedRowIndex < dGV_Results.Rows.Count Then
            Dim element As MRTDDataElement = CType(IIf(TypeOf dGV_Results.Rows(selectedRowIndex).Tag Is MRTDDataElement, dGV_Results.Rows(selectedRowIndex).Tag, Nothing), MRTDDataElement)
            If element.LineIndex >= 0 Then
               Dim linePadding As Integer = 0
               Dim i As Integer = 0
               Do While i < element.LineIndex
                  linePadding += _tB_readonlyMRZCode.Lines(i).Length + 2 '(+2) for /r/n
                  i += 1
               Loop
               _tB_readonlyMRZCode.SelectionStart = element.BeginIndex + linePadding
               _tB_readonlyMRZCode.SelectionLength = element.Length
               _tB_readonlyMRZCode.Focus()
            End If
         End If
      End Sub

      Private Sub _btnRetry_Click(sender As System.Object, e As System.EventArgs) Handles _btnRetry.Click
         Dim image As RasterImage = Me.rasterImageViewer1.Image
         If image IsNot Nothing Then
            ProcessImage(image.Clone())
         End If
      End Sub

      Private Sub _btnRotateLeft_Click(sender As System.Object, e As System.EventArgs) Handles _btnRotateLeft.Click
         Dim image As RasterImage = Me.rasterImageViewer1.Image
         If image IsNot Nothing Then
            Dim cmd As New RotateCommand(-9000, ImageProcessing.RotateCommandFlags.Resize, RasterColor.Black)
            cmd.Run(image)
            ClearOldData(False)
         End If
      End Sub

      Private Sub _btnRotateRight_Click(sender As System.Object, e As System.EventArgs) Handles _btnRotateRight.Click
         Dim image As RasterImage = Me.rasterImageViewer1.Image
         If image IsNot Nothing Then
            Dim cmd As New RotateCommand(9000, ImageProcessing.RotateCommandFlags.Resize, RasterColor.Black)
            cmd.Run(image)
            ClearOldData(False)
         End If
      End Sub

      Private Sub MainForm_FormClosing(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles Me.FormClosing
         If inTwainAcquire Then
            e.Cancel = True
         End If
      End Sub
   End Class
End Namespace

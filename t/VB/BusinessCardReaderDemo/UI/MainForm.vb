Imports System
Imports System.Collections.Generic
Imports System.Drawing
Imports System.Windows.Forms
Imports Leadtools.Twain
Imports Leadtools.Codecs
Imports Leadtools.Demos.Dialogs
Imports Leadtools
Imports Leadtools.Ocr
Imports System.IO
Imports Leadtools.Forms.Commands
Imports Leadtools.Controls
Imports Leadtools.ImageProcessing
Imports Leadtools.ImageProcessing.Core
Imports Leadtools.Barcode
Imports System.Linq

Partial Public Class MainForm : Inherits Form

   Public Sub New()
      InitializeComponent()
   End Sub

   <STAThread>
   Shared Sub Main()
      If Not Support.SetLicense() Then Return
      Dim bLocked As Boolean = RasterSupport.IsLocked(RasterSupportType.Forms)
      If bLocked Then MessageBox.Show("Forms support must be unlocked for this demo!", "Support Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
      Dim bOCRLocked As Boolean = RasterSupport.IsLocked(RasterSupportType.OcrLEAD) And RasterSupport.IsLocked(RasterSupportType.OcrOmniPage)
      If bOCRLocked Then MessageBox.Show("OCR support must be unlocked for this demo!", "Support Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
      If bLocked Or bOCRLocked Then Return
      Application.EnableVisualStyles()
      Application.SetCompatibleTextRenderingDefault(False)
      Application.Run(New MainForm())
   End Sub

   Private _twainSession As TwainSession = Nothing
   Private _inTwainAcquire As Boolean
   Private _rasterCodecs As RasterCodecs
   Private _barcodeEngine As BarcodeEngine
   Private _ocrEngine As IOcrEngine
   Private _noneInteractiveMode As ImageViewerNoneInteractiveMode = Nothing
   Private _panInteractiveMode As ImageViewerPanZoomInteractiveMode = Nothing
   Private _zoomToInteractiveMode As ImageViewerZoomToInteractiveMode = Nothing
   Private _bcrReader As BusinessCardReader
   Private _scannedImage As RasterImage = Nothing
   Private _caption As String

   Public Property NoneInteractiveMode As ImageViewerNoneInteractiveMode
      Get
         Return _noneInteractiveMode
      End Get
      Set(ByVal value As ImageViewerNoneInteractiveMode)
         _noneInteractiveMode = value
      End Set
   End Property

   Public Property PanInteractiveMode As ImageViewerPanZoomInteractiveMode
      Get
         Return _panInteractiveMode
      End Get
      Set(ByVal value As ImageViewerPanZoomInteractiveMode)
         _panInteractiveMode = value
      End Set
   End Property

   Private Sub Startup()
      Try

         If Not StartUpEngines() Then
            Messager.ShowError(Me, "One or more required engines did not start. The application will now close.")
            Me.Close()
            Return
         End If

         Messager.Caption = "LEADTOOLS Business Card Reader"
         _bcrReader = New BusinessCardReader(_ocrEngine, _barcodeEngine)
      Catch exp As Exception
         Messager.ShowError(Me, exp)
      End Try

      closeToolStripMenuItem.Enabled = False
      _noneInteractiveMode = New ImageViewerNoneInteractiveMode()
      _panInteractiveMode = New ImageViewerPanZoomInteractiveMode()
      _panInteractiveMode.MouseButtons = System.Windows.Forms.MouseButtons.Left
      _zoomToInteractiveMode = New ImageViewerZoomToInteractiveMode()
      rasterImageViewer1.InteractiveModes.BeginUpdate()
      rasterImageViewer1.InteractiveModes.Add(_noneInteractiveMode)
      rasterImageViewer1.InteractiveModes.Add(_panInteractiveMode)
      rasterImageViewer1.InteractiveModes.Add(_zoomToInteractiveMode)
      rasterImageViewer1.InteractiveModes.EndUpdate()
      AddHandler Me.rasterImageViewer1.PostRender, AddressOf RasterImageViewer1_PostRender
      Dim defaultDocumentFile As String = Path.Combine(DemosGlobal.ImagesFolder, "business_card_sample.jpg")
      If File.Exists(defaultDocumentFile) Then OpenImage(defaultDocumentFile)
   End Sub

   Protected Overrides Sub OnLoad(ByVal e As EventArgs)
      If Not DesignMode Then
         BeginInvoke(New MethodInvoker(AddressOf Startup))
      End If

      MyBase.OnLoad(e)
   End Sub

   Private Sub StartupBarcode()
      _barcodeEngine = New BarcodeEngine()
   End Sub

   Private Sub StartupTwain()
      Try

         If TwainSession.IsAvailable(Me.Handle) Then
            _twainSession = New TwainSession()
            _twainSession.Startup(Me.Handle, "LEAD Technologies, Inc.", "LEAD Test Applications", "Version 1.0", "TWAIN Test Application", TwainStartupFlags.None)
            AddHandler _twainSession.AcquirePage, New EventHandler(Of TwainAcquirePageEventArgs)(AddressOf twainSession_AcquirePage)
         End If

         scanImageToolStripMenuItem.Enabled = _twainSession IsNot Nothing
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
   End Sub

   Public Function StartUpEngines() As Boolean
      Try
         StartUpRasterCodecs()
         StartUpOcrEngine()
         StartupTwain()
         StartupBarcode()
         Return True
      Catch
         Return False
      End Try
   End Function

   Private Sub ShutDownEngines()
      If _ocrEngine IsNot Nothing AndAlso _ocrEngine.IsStarted Then
         _ocrEngine.Shutdown()
         _ocrEngine.Dispose()
      End If

      If _twainSession IsNot Nothing Then

         Try
            _twainSession.Shutdown()
         Catch
         End Try
      End If
   End Sub

   Private Sub StartUpRasterCodecs()
      Try
         _rasterCodecs = New RasterCodecs()
         RasterDefaults.DitheringMethod = RasterDitheringMethod.None
      Catch exp As Exception
         Messager.ShowError(Me, exp)
         Throw
      End Try
   End Sub

   Private Sub StartUpOcrEngine()
      Try
         _ocrEngine = OcrEngineManager.CreateEngine(OcrEngineType.LEAD, False)
         _ocrEngine.Startup(Nothing, Nothing, Nothing, Nothing)

         If _ocrEngine.SettingManager.IsSettingNameSupported("Recognition.RecognitionModuleTradeoff") Then _ocrEngine.SettingManager.SetEnumValue("Recognition.RecognitionModuleTradeoff", "Accurate")
         If _ocrEngine.SettingManager.IsSettingNameSupported("Recognition.Threading.MaximumThreads") Then _ocrEngine.SettingManager.SetIntegerValue("Recognition.Threading.MaximumThreads", 0)
         If _ocrEngine.SettingManager.IsSettingNameSupported("Recognition.DetectColors") Then _ocrEngine.SettingManager.SetBooleanValue("Recognition.DetectColors", False)
         If _ocrEngine.SettingManager.IsSettingNameSupported("Recognition.Preprocess.MobileImagePreprocess") Then _ocrEngine.SettingManager.SetBooleanValue("Recognition.Preprocess.MobileImagePreprocess", True)
         If _ocrEngine.SettingManager.IsSettingNameSupported("Recognition.Fonts.RecognizeFontAttributes") Then _ocrEngine.SettingManager.SetBooleanValue("Recognition.Fonts.RecognizeFontAttributes", False)

         Me.Text = String.Format("{0}", Me.Text)
         _caption = Me.Text
      Catch exp As Exception
         Messager.ShowError(Me, exp)
         Throw
      End Try
   End Sub

   Private Sub twainSession_AcquirePage(ByVal sender As Object, ByVal e As TwainAcquirePageEventArgs)
      If _scannedImage IsNot Nothing Then
         _scannedImage.Dispose()
         _scannedImage = Nothing
      End If

      If e.Image IsNot Nothing Then _scannedImage = e.Image.Clone()
   End Sub

   Public Sub LoadImageScanner()
      If Not DemosGlobal.CheckKnown3rdPartyTwainIssues(Me, _twainSession.SelectedSourceName()) Then Return
      Dim showUI As Boolean = False
      _inTwainAcquire = True

      Try
         _twainSession.MaximumTransferCount = 1
         _twainSession.Resolution = New SizeF(300, 300)
      Catch
         MessageBox.Show("Unable to set scanner to 300DPI.")
         showUI = True
      End Try

      Try
         If (showUI) Then
            _twainSession.Acquire(TwainUserInterfaceFlags.Modal)
         Else
            _twainSession.Acquire(TwainUserInterfaceFlags.None)
         End If
      Catch twEx As TwainException
         MessageBox.Show(twEx.Message, "Scanner Error")
      End Try

      _inTwainAcquire = False
   End Sub

   Private Sub EnableControls(ByVal bEnable As Boolean)
      Me.fileToolStripMenuItem.Enabled = bEnable
      Me.fileToolStripMenuItem.Enabled = bEnable
      Me.ControlBox = bEnable
   End Sub

   Private Sub OpenImage(ByVal path As String)
      Dim image As RasterImage = _rasterCodecs.Load(path)
      Me.Text = String.Format("{0} [{1}]", _caption, path)
      OpenImage(image)
   End Sub

   Private Sub OpenImage(ByVal image As RasterImage)
      Cursor = Cursors.WaitCursor
      EnableControls(False)
      ProcessImage(image)
      _btnFit_Click(Nothing, Nothing)
      Cursor = Cursors.Arrow
   End Sub

   Private Sub openToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles openToolStripMenuItem.Click
      Try
         Dim loader As ImageFileLoader = New ImageFileLoader()
         loader.ShowLoadPagesDialog = True
         loader.MultiSelect = False
         loader.ShowPdfOptions = True
         loader.ShowLoadPagesDialog = False

         If loader.Load(Me, _rasterCodecs, True) > 0 Then
            Me.Text = String.Format("{0} [{1}]", _caption, loader.FileName)
            OpenImage(loader.Image)
         End If

      Catch exp As Exception
         EnableControls(True)
         Messager.ShowError(Me, exp)
      End Try
   End Sub

   Private Sub ProcessImage(ByVal rasterImage As RasterImage)
      If rasterImage.BitsPerPixel = 1 Then
         Dim cmd As ColorResolutionCommand = New ColorResolutionCommand()
         cmd.BitsPerPixel = 8
         cmd.Run(rasterImage)
      End If

      Dim status As BCProcessStatus
      status = _bcrReader.Process(rasterImage)
      Me.rasterImageViewer1.Image = rasterImage

      If status = BCProcessStatus.BlurDetected Then
         Messager.ShowError(Me, "Blur detected in image.")
      Else
         If status = BCProcessStatus.GlareDetected Then
            Messager.ShowError(Me, "Glare detected in image.")
         Else
            If status = BCProcessStatus.Failed Then
               Messager.ShowError(Me, "Failed to recognize image.")
            End If
         End If
      End If

      UpdateControls()
   End Sub

   Private Sub FillResults()
      If dGV_Results.Rows.Count > 0 Then dGV_Results.Rows.Clear()

      If _bcrReader.Results IsNot Nothing Then
         For Each item As KeyValuePair(Of String, BCResult) In _bcrReader.Results
            Dim row As DataGridViewRow = New DataGridViewRow()
            row.CreateCells(dGV_Results, item.Key, item.Value.Value, item.Value.Confidence)
            row.Tag = item.Value
            dGV_Results.Rows.Add(row)
         Next item
      End If
   End Sub

   Private Sub ClearOldData(ByVal clearImage As Boolean)
      dGV_Results.Rows.Clear()

      If clearImage Then
         Me.rasterImageViewer1.Image = Nothing
      End If

      Me.rasterImageViewer1.Invalidate()
      closeToolStripMenuItem.Enabled = False
      Application.DoEvents()
   End Sub

   Private Sub UpdateControls()
      scanImageToolStripMenuItem.Enabled = _twainSession IsNot Nothing
      EnableControls(True)
      dGV_Results.Rows.Clear()
      closeToolStripMenuItem.Enabled = True
      If _bcrReader.Results IsNot Nothing Then FillResults()
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
      ClearCheck(TryCast(sender, ToolStripButton))
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
      Next
   End Sub

   Private Sub _btnPanTool_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnPanTool.Click
      ClearCheck(TryCast(sender, ToolStripButton))
      DisableInteractiveModes()
      rasterImageViewer1.InteractiveModes.EnableById(_panInteractiveMode.Id)
   End Sub

   Private Sub ClearCheck(ByVal toolStripButton As ToolStripButton)
      _btnPanTool.Checked = toolStripButton.Equals(_btnPanTool)
      _btnZoomDrawTool.Checked = toolStripButton.Equals(_btnZoomDrawTool)
   End Sub

   Private Sub closeToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles closeToolStripMenuItem.Click
      Me.Text = _caption
      ClearOldData(True)
   End Sub

   Private Sub exitToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles exitToolStripMenuItem.Click
      Me.Close()
   End Sub

   Protected Overrides Sub OnClosed(ByVal e As EventArgs)
      ClearOldData(True)
      ShutDownEngines()

      If _ocrEngine IsNot Nothing AndAlso _ocrEngine.IsStarted Then
         _ocrEngine.Shutdown()
         _ocrEngine.Dispose()
      End If

      MyBase.OnClosed(e)
   End Sub

   Private Sub aboutToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles aboutToolStripMenuItem.Click
      Using aboutDialog As AboutDialog = New AboutDialog("Business Card Reader", ProgrammingInterface.VB)
         aboutDialog.ShowDialog(Me)
      End Using
   End Sub

   Private Function ToReadbleString(ByVal str As String) As String
      Dim str2 As String = TryCast(str.Clone(), String)

      For i As Integer = 0 To str2.Length - 1

         If Char.IsUpper(str2(i)) AndAlso i <> 0 Then
            str2 = str2.Insert(i, " ")
            i += 1
         End If
      Next

      Return str2
   End Function

   Private Sub scanImageToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles scanImageToolStripMenuItem.Click
      _inTwainAcquire = True

      Try

         If _twainSession IsNot Nothing Then

            If _twainSession.SelectSource(Nothing) <> DialogResult.OK Then
               _inTwainAcquire = False
               Return
            End If
         End If

      Catch ex As Exception
         Messager.ShowError(Me, ex)
      End Try

      _inTwainAcquire = False
      Application.DoEvents()
      LoadImageScanner()

      If _scannedImage IsNot Nothing Then
         Me.Text = String.Format("{0} [Scanned image]", _caption)
         OpenImage(_scannedImage)
      End If
   End Sub

   Private Sub _btnRotateRight_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnRotateRight.Click
      Dim image As RasterImage = Me.rasterImageViewer1.Image

      If image IsNot Nothing Then
         Dim cmd As RotateCommand = New RotateCommand(9000, RotateCommandFlags.Resize, RasterColor.Black)
         cmd.Run(image)
         ClearOldData(False)
      End If
   End Sub

   Private Sub _btnRotateLeft_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnRotateLeft.Click
      Dim image As RasterImage = Me.rasterImageViewer1.Image

      If image IsNot Nothing Then
         Dim cmd As RotateCommand = New RotateCommand(-9000, RotateCommandFlags.Resize, RasterColor.Black)
         cmd.Run(image)
         ClearOldData(False)
      End If
   End Sub

   Private Sub _btnRetry_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnRetry.Click
      Dim image As RasterImage = Me.rasterImageViewer1.Image

      If image IsNot Nothing Then
         ProcessImage(image.Clone())
      End If
   End Sub

   Private Sub MainForm_FormClosing(ByVal sender As Object, ByVal e As FormClosingEventArgs)
      If _inTwainAcquire Then e.Cancel = True
   End Sub

   Private _selectedFieldBounds As LeadRect = LeadRect.Empty
   Private _brush As Brush = New SolidBrush(Color.FromArgb(127, Color.Yellow))

   Private Sub dGV_Results_SelectionChanged(ByVal sender As Object, ByVal e As EventArgs) Handles dGV_Results.SelectionChanged
      _selectedFieldBounds = LeadRect.Empty
      Dim dataGrid As DataGridView = TryCast(sender, DataGridView)

      If dataGrid.SelectedRows IsNot Nothing AndAlso dataGrid.SelectedRows.Count > 0 Then
         _selectedFieldBounds = TryCast(dataGrid.SelectedRows(0).Tag, BCResult).Bounds
      End If

      Me.rasterImageViewer1.Invalidate()
   End Sub

   Private Sub RasterImageViewer1_PostRender(ByVal sender As Object, ByVal e As ImageViewerRenderEventArgs)
      If Not _selectedFieldBounds.IsEmpty Then
         Dim rect As LeadRectD = rasterImageViewer1.ImageTransform.TransformRect(_selectedFieldBounds.ToLeadRectD())
         e.PaintEventArgs.Graphics.FillRectangle(_brush, New Rectangle(CInt(rect.X), CInt(rect.Y), CInt(rect.Width), CInt(rect.Height)))
      End If
   End Sub
End Class

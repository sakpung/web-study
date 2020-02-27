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
Imports VBBankCheckReader.VBBankCheckReader.UI
Imports Leadtools.Demos.Dialogs
Imports Leadtools.ImageProcessing
Imports System.Globalization

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

   Private rasterCodecs As RasterCodecs
   Private ocrEngine As IOcrEngine
   Private _noneInteractiveMode As ImageViewerNoneInteractiveMode = Nothing
   Private _panInteractiveMode As ImageViewerPanZoomInteractiveMode = Nothing
   Private _zoomToInteractiveMode As ImageViewerZoomToInteractiveMode = Nothing
   Private checkReader As BankCheckReader = Nothing
   Private processdlg As ProcessDialog
   Private selectedRowIndex As Integer = 0
   Private selectedRect As LeadRect = LeadRect.Empty
   Private brush As Brush = Nothing
   Private pen As Pen = Nothing

   Public Property NoneInteractiveMode() As ImageViewerNoneInteractiveMode
      Get
         Return _noneInteractiveMode
      End Get
      Set(value As ImageViewerNoneInteractiveMode)
         _noneInteractiveMode = value
      End Set
   End Property

   Public Property PanInteractiveMode() As ImageViewerPanZoomInteractiveMode
      Get
         Return _panInteractiveMode
      End Get
      Set(value As ImageViewerPanZoomInteractiveMode)
         _panInteractiveMode = value
      End Set
   End Property

   Private Sub Startup()
      Try
         'Check if ocr engine was passed in. The recognition demos have the ability to launch this demo and it will pass
         'the ocr engine it is using. We will default to that engine
         Dim commandArgs As String() = Environment.GetCommandLineArgs()
         If commandArgs.Length = 2 Then
            Dim settings As My.Settings = New My.Settings()
            settings.OcrEngineType = commandArgs(1)
            settings.Save()
         End If

         If (Not StartUpEngines()) Then
            Messager.ShowError(Me, "One or more required engines did not start. The application will now close.")
            Me.Close()
            Return
         End If

         Messager.Caption = "LEADTOOLS Check Reader"

         checkReader = New BankCheckReader()
         checkReader.OcrEngine = ocrEngine
#If LEADTOOLS_V20_OR_LATER Then
         checkReader.MicrFontType = BankCheckMicrFontType.Unknown
#End If ' #if LEADTOOLS_V20_OR_LATER

         brush = New SolidBrush(Color.FromArgb(127, Color.Yellow))
         pen = New Pen(brush)

      Catch exp As Exception
         Messager.ShowError(Me, exp)
         Return
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

      dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells

      ' Load the default document
      Dim defaultDocumentFile As String = Path.Combine(DemosGlobal.ImagesFolder, "BankCheck.jpg")

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

   Private Sub _menuItemComponents_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _menuItemComponents.Click
      ' Show the dialog to let the user see the OCR components installed on this system
      Dim dlg As OcrEngineComponentsDialog = New OcrEngineComponentsDialog(ocrEngine)
      Try
         dlg.ShowDialog(Me)
      Finally
         CType(dlg, IDisposable).Dispose()
      End Try
   End Sub

   Private Sub _menuItemLanguages_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _menuItemLanguages.Click
      ' Show the dialog to let the user change the current enabled languages
      Dim dlg As EnableLanguagesDialog = New EnableLanguagesDialog(ocrEngine)
      Try
         dlg.ShowDialog(Me)
      Finally
         CType(dlg, IDisposable).Dispose()
      End Try
   End Sub

   Public Function StartUpEngines() As Boolean
      Try
         StartUpRasterCodecs()
         StartUpOcrEngine()
         Return True
      Catch
         Return False
      End Try
   End Function

   Private Sub ShutDownOcrEngine()
      If Not ocrEngine Is Nothing AndAlso ocrEngine.IsStarted Then
         Dim settings As My.Settings = New My.Settings()
         settings.OcrEngineType = ocrEngine.EngineType.ToString()
         settings.Save()

         ocrEngine.Shutdown()
         ocrEngine.Dispose()
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
         Dim settings As My.Settings = New My.Settings()
         Dim engineType As String = settings.OcrEngineType

         ' Show the engine selection dialog
         Dim dlg As OcrEngineSelectDialog = New OcrEngineSelectDialog(Messager.Caption, engineType, False)
         Try
            If dlg.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK Then
               ocrEngine = OcrEngineManager.CreateEngine(dlg.SelectedOcrEngineType, False)

               ocrEngine.Startup(Nothing, Nothing, Nothing, Nothing)

               If ocrEngine.EngineType = OcrEngineType.LEAD Then
                  If ocrEngine.SettingManager.IsSettingNameSupported("Recognition.RecognitionModuleTradeoff") Then
                     ocrEngine.SettingManager.SetEnumValue("Recognition.RecognitionModuleTradeoff", "Accurate")
                  End If
               End If

               Me.Text = String.Format("{0} [{1} Engine]", Me.Text, dlg.SelectedOcrEngineType.ToString())
            Else
               Throw New Exception("No engine selected.")
            End If
         Finally
            CType(dlg, IDisposable).Dispose()
         End Try
      Catch exp As Exception
         Messager.ShowError(Me, exp)
         Throw
      End Try
   End Sub

   Private Sub EnableControls(ByVal bEnable As Boolean)
      Me.fileToolStripMenuItem.Enabled = bEnable
      Me._menuItemEngine.Enabled = bEnable
      Me.fileToolStripMenuItem.Enabled = bEnable
      Me.ControlBox = bEnable
   End Sub

   Private Sub openToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles openToolStripMenuItem.Click
      Dim loader As ImageFileLoader = New ImageFileLoader()
      loader.ShowLoadPagesDialog = True
      loader.MultiSelect = False
      loader.ShowPdfOptions = True
      loader.ShowLoadPagesDialog = False
      If loader.Load(Me, rasterCodecs, True) > 0 Then
         OpenImage(loader.FileName)
      End If
   End Sub

   Private Sub OpenImage(fileName As String)
      Try
         Dim image As RasterImage = rasterCodecs.Load(fileName)
         Me.Text = "LEADTOOLS Check Reader " & fileName
         EnableControls(False)
         ProcessImage(image)
      Catch exp As Exception
         EnableControls(True)
         Messager.ShowError(Me, exp)
         If processdlg IsNot Nothing Then
            processdlg.Close()
         End If
      End Try
   End Sub

   Private Sub ProcessImage(ByVal rasterImage As RasterImage)
      ClearOldData(False)
      selectedRowIndex = -1
      If rasterImage.ViewPerspective <> RasterViewPerspective.TopLeft Then
         Dim cmd As New ChangeViewPerspectiveCommand()
         cmd.InPlace = True
         cmd.ViewPerspective = RasterViewPerspective.TopLeft
         cmd.Run(rasterImage)
      End If
      Me.rasterImageViewer1.Image = rasterImage
      processdlg = New ProcessDialog(checkReader)
      processdlg.Show()
      AddHandler processdlg.ProcessFinished, AddressOf processdlg_ProcessFinished
      Dim TempThread As Thread = New Thread(Sub()
                                               Try
                                                  checkReader.ProcessImage(rasterImage)
                                               Catch e As Exception
                                                  checkReader.Cancel()
                                                  Me.Invoke(New Action(Function() ThrowExp(e)))

                                               End Try



                                            End Sub
      )

      TempThread.Start()
   End Sub

   Private Function ThrowExp(ByVal ex As Exception) As Object
      MessageBox.Show(ex.Message)
      Return Nothing
   End Function

   Private Sub ClearOldData(ByVal clearTitle As Boolean)
      If clearTitle Then
         Me.Text = "LEADTOOLS Check Reader "
         If ocrEngine IsNot Nothing Then
            Me.Text = [String].Format("{0} [{1} Engine]", Me.Text, ocrEngine.ToString())
         End If
      End If
      selectedRect = LeadRect.Empty
      dataGridView1.Rows.Clear()
      Me.imageViewerField.Image = Nothing
      Me.rasterImageViewer1.Image = Nothing
      Me.rasterImageViewer1.Invalidate()
      Application.DoEvents()
   End Sub

   Private Sub processdlg_ProcessFinished(ByVal sender As Object, ByVal e As EventArgs)
      UpdateControls()
      processdlg = Nothing
   End Sub

   Private Sub UpdateControls()
      EnableControls(True)
      dataGridView1.Rows.Clear()

      For Each item As KeyValuePair(Of String, BankCheckField) In checkReader.Results
         Dim row As DataGridViewRow = New DataGridViewRow()
         row.CreateCells(dataGridView1, item.Key, item.Value.Text)
         row.Tag = item.Value
         dataGridView1.Rows.Add(row)
      Next item
   End Sub

   Private Sub dataGridView1_CellEnter(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles dataGridView1.CellEnter
      selectedRowIndex = e.RowIndex

      If selectedRowIndex >= 0 AndAlso selectedRowIndex < dataGridView1.Rows.Count Then
         Dim field As BankCheckField = CType(IIf(TypeOf dataGridView1.Rows(selectedRowIndex).Tag Is BankCheckField, dataGridView1.Rows(selectedRowIndex).Tag, Nothing), BankCheckField)
         selectedRect = field.Bounds

         Me.imageViewerField.Image = Me.rasterImageViewer1.Image.Clone(selectedRect)
         rasterImageViewer1.Invalidate()

         Dim centerPoint As LeadPoint = New LeadPoint(CInt(selectedRect.X + selectedRect.Width / 2), CInt(selectedRect.Y + selectedRect.Height / 2))
         centerPoint = Me.rasterImageViewer1.ConvertPoint(Me.rasterImageViewer1.Items(0), ImageViewerCoordinateType.Image, ImageViewerCoordinateType.Control, centerPoint)
         Me.rasterImageViewer1.CenterAtPoint(centerPoint)
      End If
   End Sub

   Private Sub CheckToolButtons(ByVal sender As Object)
      _btnZoomDrawTool.Checked = False
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
      DisableInteractiveModes()
      rasterImageViewer1.InteractiveModes.EnableById(_zoomToInteractiveMode.Id)
      CheckToolButtons(sender)
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
      DisableInteractiveModes()
      rasterImageViewer1.InteractiveModes.EnableById(_panInteractiveMode.Id)
      CheckToolButtons(sender)
   End Sub

   Private Sub closeToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles closeToolStripMenuItem.Click
      Me.Text = "LEADTOOLS Check Reader "
      ClearOldData(True)
   End Sub

   Private Sub exitToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles exitToolStripMenuItem.Click
      Me.Close()
   End Sub

   Protected Overrides Sub OnClosed(ByVal e As EventArgs)
      ClearOldData(True)
      If Not checkReader Is Nothing Then
         checkReader.OcrEngine = Nothing
      End If

      ShutDownOcrEngine()
      MyBase.OnClosed(e)
   End Sub

   Private Sub aboutToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles aboutToolStripMenuItem.Click
      Using aboutDialog As New AboutDialog("Bank Check Reader", ProgrammingInterface.VB)
         aboutDialog.ShowDialog(Me)
      End Using
   End Sub

   Private Sub _miFontType_Click(sender As Object, e As EventArgs) Handles _miFontUnknown.Click, _miFontE13B.Click, _miFontCMC7.Click
      _miFontUnknown.Checked = If(_miFontE13B.Checked, _miFontCMC7.Checked, False)

      Dim menuItem As ToolStripMenuItem = CType(sender, ToolStripMenuItem)
      menuItem.Checked = True

#If LEADTOOLS_V20_OR_LATER Then
      If checkReader IsNot Nothing Then
         checkReader.MicrFontType = CType([Enum].Parse(GetType(BankCheckMicrFontType), CultureInfo.CurrentCulture.TextInfo.ToTitleCase(menuItem.Text.ToLower)), BankCheckMicrFontType)
      End If
#End If ' #if LEADTOOLS_V20_OR_LATER
   End Sub
End Class

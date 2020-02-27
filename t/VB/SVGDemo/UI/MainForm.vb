' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System
Imports System.Drawing.Imaging
Imports System.Collections.Generic
Imports System.Drawing
Imports System.Drawing.Printing
Imports System.Windows.Forms
Imports System.IO
Imports System.Text

Imports Leadtools
Imports Leadtools.Drawing
Imports Leadtools.Codecs
Imports Leadtools.Svg
Imports Leadtools.Demos
Imports Leadtools.Demos.Dialogs

Namespace SvgDemo
   Partial Public Class MainForm
      Inherits Form
      Public Sub New()
         InitializeComponent()


         If Not Support.SetLicense() Then
            Return
         End If

         Me.SetStyle(ControlStyles.AllPaintingInWmPaint Or ControlStyles.UserPaint Or ControlStyles.OptimizedDoubleBuffer Or ControlStyles.ResizeRedraw, True)

         Messager.Caption = "LEADTOOLS for .NET VB SVG Demo"
         Text = Messager.Caption
      End Sub

      Protected Overrides Sub OnLoad(e As EventArgs)
         If Not DesignMode Then
            Init()
         End If

         MyBase.OnLoad(e)
      End Sub

      Private Sub MainForm_FormClosing(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles Me.FormClosing
         If _viewer IsNot Nothing Then
            _viewer.DocumentList = Nothing
         End If
      End Sub


      Private _viewer As Viewer
      Private _name As String
      Private _printDocument As PrintDocument
      Private _currentPrintPageNumber As Integer
      Private _loadSvgOptions As CodecsLoadSvgOptions

      Private Sub Init()
         _viewer = New Viewer()
         _viewer.Dock = DockStyle.Fill
         _viewer.BackColor = Color.Bisque
         _viewer.BorderStyle = BorderStyle.Fixed3D
         Controls.Add(_viewer)
         _viewer.BringToFront()
         AddHandler _viewer.MouseMove, AddressOf _viewer_MouseMove
         _viewer.UseDpi = True
         _selectTextToolStripMenuItem.Checked = True

         _loadSvgOptions = New CodecsLoadSvgOptions()

         Try
            If PrinterSettings.InstalledPrinters IsNot Nothing AndAlso PrinterSettings.InstalledPrinters.Count > 0 Then
               _printDocument = New PrintDocument()
               AddHandler _printDocument.BeginPrint, AddressOf _printDocument_BeginPrint
               AddHandler _printDocument.PrintPage, AddressOf _printDocument_PrintPage
               AddHandler _printDocument.EndPrint, AddressOf _printDocument_EndPrint
            Else
               _printDocument = Nothing
            End If
         Catch generatedExceptionName As Exception
            _printDocument = Nothing
         End Try

         InitPan()
         UpdateControls()
         Dim defaultFile As String
#If LT_CLICKONCE Then
			defaultFile = Path.Combine(Application.StartupPath, "documents\Leadtools.pdf")
#Else
         defaultFile = Path.Combine(DemosGlobal.ImagesFolder, "Leadtools.pdf")
#End If

         If File.Exists(defaultFile) Then
            LoadDocument(defaultFile, True)
         End If
      End Sub

      Private Sub _viewer_MouseMove(sender As Object, e As MouseEventArgs)
         Dim document As SvgDocument = _viewer.CurrentDocument
         If document IsNot Nothing Then
            Dim imagePos As LeadPointD = _viewer.ConvertPoint(Viewer.CoordinateType.Control, Viewer.CoordinateType.Image, New LeadPointD(e.X, e.Y))
            _mousePositionLabel.Text = String.Format("Viewer: {0}, {1} - SVG: {2}, {3}", e.X, e.Y, CInt(imagePos.X), CInt(imagePos.Y))
         Else
            _mousePositionLabel.Text = String.Empty
         End If
      End Sub

      Private _currentPoint As LeadPoint = LeadPoint.Empty
      Private Sub InitPan()
         AddHandler _viewer.PanBegin, AddressOf _viewer_PanBegin
         AddHandler _viewer.Panning, AddressOf _viewer_Panning
         AddHandler _viewer.PanEnd, AddressOf _viewer_PanEnd
      End Sub

      Private Sub _viewer_PanEnd(sender As Object, e As EventArgs)
      End Sub

      Private Sub _viewer_Panning(sender As Object, e As MouseEventArgs)
         If e.Button = MouseButtons.Right Then
            Return
         End If

         Dim dx As Integer = e.X - _currentPoint.X
         Dim dy As Integer = e.Y - _currentPoint.Y

         If dx <> 0 OrElse dy <> 0 Then
            Dim transform As LeadMatrix = LeadMatrix.Identity

            Dim zoom As Boolean = (Control.ModifierKeys And Keys.Control) = Keys.Control
            Dim rotate As Boolean = (Control.ModifierKeys And Keys.Alt) = Keys.Alt

            If zoom Then
               If dy <> 0 Then
                  Dim factor As Integer = CInt(1.0 - ((dy * 4.0) / _viewer.ClientSize.Height))
                  factor = If(factor < 0, -factor, factor)
                  Dim center As LeadPointD = _currentPoint.ToLeadPointD()

                  If _transformAtCenterToolStripMenuItem.Checked Then
                     center = New LeadPointD(_viewer.ImageSize.Width / 2, _viewer.ImageSize.Height / 2)
                     center = _viewer.ConvertPoint(Viewer.CoordinateType.Image, Viewer.CoordinateType.Control, center)
                  End If

                  transform.ScaleAt(factor, factor, center.X, center.Y)
               End If
            ElseIf rotate Then
               If dx <> 0 Then
                  Const rotateAngle As Double = 5.0
                  Dim center As LeadPointD = _currentPoint.ToLeadPointD()

                  If _transformAtCenterToolStripMenuItem.Checked Then
                     center = New LeadPointD(_viewer.ImageSize.Width / 2, _viewer.ImageSize.Height / 2)
                     center = _viewer.ConvertPoint(Viewer.CoordinateType.Image, Viewer.CoordinateType.Control, center)
                  End If

                  transform.RotateAt(If(dx > 0, rotateAngle, -rotateAngle), center.X, center.Y)
               End If
            Else
               If dx <> 0 OrElse dy <> 0 Then
                  transform.Translate(dx, dy)
               End If
            End If

            transform = LeadMatrix.Multiply(_viewer.Transform, transform)
            If IsScaleInRange(transform) Then
               _viewer.Transform = transform
            End If
         End If

         _currentPoint = New LeadPoint(e.X, e.Y)
      End Sub

      Private Function IsScaleInRange(matrix As LeadMatrix) As Boolean
         Dim scaleX As Double = Math.Sqrt(Math.Pow(matrix.M11, 2) + Math.Pow(matrix.M12, 2))
         Dim scaleY As Double = Math.Sqrt(Math.Pow(matrix.M21, 2) + Math.Pow(matrix.M22, 2))
         Return (scaleX < 50 AndAlso scaleY < 50)
      End Function

      Private Sub _viewer_PanBegin(sender As Object, e As MouseEventArgs)
         If e.Button = MouseButtons.Right Then
            _viewer.Identity()
         Else
            _currentPoint = New LeadPoint(e.X, e.Y)
         End If
      End Sub

      Private Sub PrepareDocument(document As SvgDocument)
         If Not document.IsFlat Then
            document.Flat(Nothing)
         End If

         If Not document.Bounds.IsValid OrElse document.Bounds.IsTrimmed Then

            document.CalculateBounds(False)
         End If

         document.BeginRenderOptimize()
      End Sub

      Private Sub LoadDocument(fileName As String, loadDefault As Boolean)
         Try
            Using codecs As New RasterCodecs()
               ' Set load resolution
               codecs.Options.RasterizeDocument.Load.XResolution = 300
               codecs.Options.RasterizeDocument.Load.YResolution = 300

               Dim firstPage As Integer = 1
               Dim lastPage As Integer = 1
               Dim documents As New List(Of SvgDocument)()

               If Not loadDefault Then
                  ' Check if the file can be loaded as svg
                  Dim canLoadSvg As Boolean = codecs.CanLoadSvg(fileName)
                  Using info As CodecsImageInfo = codecs.GetInformation(fileName, True)
                     If Not canLoadSvg Then
                        ' Check if the file type is not PDF
                        If info.Format <> RasterImageFormat.PdfLeadMrc AndAlso info.Format <> RasterImageFormat.RasPdf AndAlso info.Format <> RasterImageFormat.RasPdfCmyk AndAlso info.Format <> RasterImageFormat.RasPdfG31Dim AndAlso info.Format <> RasterImageFormat.RasPdfG32Dim AndAlso info.Format <> RasterImageFormat.RasPdfG4 AndAlso info.Format <> RasterImageFormat.RasPdfJbig2 AndAlso info.Format <> RasterImageFormat.RasPdfJpeg AndAlso info.Format <> RasterImageFormat.RasPdfJpeg411 AndAlso info.Format <> RasterImageFormat.RasPdfJpeg422 AndAlso info.Format <> RasterImageFormat.RasPdfJpx AndAlso info.Format <> RasterImageFormat.RasPdfLzw AndAlso info.Format <> RasterImageFormat.RasPdfLzwCmyk Then
                           MessageBox.Show("The selected file can't be loaded as an SVG file", "Invalid File Format", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                           Return
                        End If
                     End If

                     If info.TotalPages > 1 Then
                        Using dlg As New ImageFileLoaderPagesDialog(info.TotalPages, False)
                           If dlg.ShowDialog(Me) = DialogResult.Cancel Then
                              Return
                           End If

                           firstPage = dlg.FirstPage
                           lastPage = dlg.LastPage
                        End Using
                     End If
                  End Using
               End If

               Using wait As New WaitCursor()
                  For page As Integer = firstPage To lastPage
                     Dim svgDoc As SvgDocument = TryCast(codecs.LoadSvg(fileName, page, _loadSvgOptions), SvgDocument)
                     documents.Add(svgDoc)
                  Next
                  SetDocument(fileName, documents, firstPage)
               End Using

               UpdateControls()
            End Using
         Catch ex As Exception
            MessageBox.Show(Me, String.Format("Error {0}{1}{2}", ex.[GetType]().FullName, Environment.NewLine, ex.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
         End Try
      End Sub

      Private Sub SetDocument(name As String, documents As List(Of SvgDocument), pageNumber As Integer)
         _name = name
         Dim docsInfo As New List(Of SvgDocumentInformation)()
         For Each doc As SvgDocument In documents
            docsInfo.Add(New SvgDocumentInformation(doc))
            PrepareDocument(doc)
         Next

         _viewer.DocumentList = docsInfo
         _viewer.CurrentPageIndex = If((pageNumber <= docsInfo.Count), pageNumber - 1, 0)
         _viewer.TotalPages = docsInfo.Count
         _viewer.Identity()
         _viewer.Invalidate()

         Invalidate()
      End Sub

      Private Sub _useDpiToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles _useDpiToolStripMenuItem.Click
         _useDpiToolStripMenuItem.Checked = Not _useDpiToolStripMenuItem.Checked
         _viewer.UseDpi = _useDpiToolStripMenuItem.Checked
      End Sub

      Private Sub _transformAtCenterToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles _transformAtCenterToolStripMenuItem.Click
         _transformAtCenterToolStripMenuItem.Checked = Not _transformAtCenterToolStripMenuItem.Checked
      End Sub

      Private Sub _getTextToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles _getTextToolStripMenuItem.Click
         Dim document As SvgDocument = _viewer.CurrentDocument
         If document IsNot Nothing Then
            Dim documentText__1 As DocumentText = DocumentText.FromSvgDocument(document)
            If documentText__1 IsNot Nothing Then
               documentText__1.BuildWords()
               _viewer.DocumentList(_viewer.CurrentPageIndex).DocumentText = documentText__1
               _viewer.DocumentList(_viewer.CurrentPageIndex).ShowText = _selectTextToolStripMenuItem.Checked
               _viewer.Invalidate()
               UpdateControls()
            End If
         End If
      End Sub

      Private Sub _saveTextToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles _saveTextToolStripMenuItem.Click
         Dim documentText As DocumentText = _viewer.DocumentList(_viewer.CurrentPageIndex).DocumentText
         If documentText Is Nothing Then
            Return
         End If

         Using dlg As SaveFileDialog = New SaveFileDialog()
            dlg.Filter = String.Format("Text files (*.txt)|*.txt")
            dlg.DefaultExt = "txt"
            If dlg.ShowDialog(Me) = DialogResult.OK Then
               Dim txt As String = documentText.BuildText()
               File.WriteAllText(dlg.FileName, txt, Encoding.UTF8)
               System.Diagnostics.Process.Start(dlg.FileName)
            End If
         End Using
      End Sub

      Private Sub _selectTextToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles _selectTextToolStripMenuItem.Click
         _selectTextToolStripMenuItem.Checked = Not _selectTextToolStripMenuItem.Checked
         If _viewer.DocumentList.Count <> 0 Then
            _viewer.DocumentList(_viewer.CurrentPageIndex).ShowText = _selectTextToolStripMenuItem.Checked
            _viewer.Invalidate()
         End If
      End Sub

      Private Sub _exitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles _exitToolStripMenuItem.Click
         Close()
      End Sub

      Private Sub _openToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles _openToolStripMenuItem.Click
         Using dlg As OpenFileDialog = New OpenFileDialog()
#If LT_CLICKONCE Then
            dlg.InitialDirectory = Path.Combine(Application.StartupPath, "documents")
#End If
            Const documentFormats As String = "*.afp;*.doc;*.docx;*.pdf;*.ppt;*.pptx;*.ptk;*.rtf;*.xls;*.xlsx;*.epub;*.mob;*.mobi;*.prc"
            Const vectorFormats As String = "*.cgm;*.cmx;*.dgn;*.drw;*.dwf;*.dwfx;*.dwg;*.dxf;*.e00;*.gbr;*.mif;*.nap;*.pcl;*.shp;*.svg"
            dlg.Filter = String.Format("All Files(*.*)|*.*|Document Files({0})|{0}|Vector Files({1})|{1}", documentFormats, vectorFormats)
            If dlg.ShowDialog(Me) = DialogResult.OK Then
               LoadDocument(dlg.FileName, False)
            End If
         End Using
      End Sub

      Private Sub _aboutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles _aboutToolStripMenuItem.Click
         Using aboutDialog As New AboutDialog("Svg", ProgrammingInterface.VB)
            aboutDialog.ShowDialog(Me)
         End Using
      End Sub

      Private Sub _showDocInfoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles _showDocInfoToolStripMenuItem.Click
         Dim docInfo As New DocumentInfo(_viewer.CurrentDocument, _name, _viewer.CurrentPageIndex, _viewer.TotalPages)
         docInfo.ShowDialog(Me)
      End Sub

      Private Sub _printToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles _printToolStripMenuItem.Click
         If _printDocument IsNot Nothing Then
            Try
               _printDocument.PrinterSettings.MinimumPage = 1
               _printDocument.PrinterSettings.MaximumPage = _viewer.DocumentList.Count
               _printDocument.PrinterSettings.FromPage = 1
               _printDocument.PrinterSettings.ToPage = _viewer.DocumentList.Count

               _printDocument.Print()
            Catch
            End Try
         End If
      End Sub

      Private Sub _printPreviewToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles _printPreviewToolStripMenuItem.Click
         If _printDocument IsNot Nothing Then
            Try
               Using dlg As New PrintPreviewDialog()
                  _printDocument.PrinterSettings.MinimumPage = 1
                  _printDocument.PrinterSettings.MaximumPage = _viewer.DocumentList.Count
                  _printDocument.PrinterSettings.FromPage = 1
                  _printDocument.PrinterSettings.ToPage = _viewer.DocumentList.Count

                  dlg.Document = _printDocument
                  dlg.WindowState = FormWindowState.Maximized
                  dlg.ShowDialog(Me)
               End Using
            Catch
            End Try
         End If
      End Sub

      Private Sub _printDocument_BeginPrint(sender As Object, e As PrintEventArgs)
         ' Start from first page in the image
         _currentPrintPageNumber = 1
      End Sub

      Private Sub _printDocument_PrintPage(sender As Object, e As PrintPageEventArgs)
         ' Get the print document object
         Dim document As PrintDocument = TryCast(sender, PrintDocument)
         Dim dpiX As Single = e.Graphics.DpiX
         Dim dpiY As Single = e.Graphics.DpiY
         Dim pageBounds As Rectangle = e.PageBounds

         Dim svgDoc As SvgDocument = _viewer.DocumentList(_currentPrintPageNumber - 1).Document
         Dim svgResolution As LeadSizeD = svgDoc.Bounds.Resolution
         Dim svgBounds As LeadRectD = svgDoc.Bounds.Bounds


         ' Get page size in pixels
         Dim pixelSize As LeadSizeD = LeadSizeD.Create(svgBounds.Width, svgBounds.Height)

         Using bitmap As New Bitmap(CInt(pixelSize.Width), CInt(pixelSize.Height), PixelFormat.Format32bppPArgb)
            ' Convert to DPI
            Dim size As LeadSize = LeadSizeD.Create(pixelSize.Width * bitmap.HorizontalResolution / svgResolution.Width, pixelSize.Height * bitmap.VerticalResolution / svgResolution.Height).ToLeadSize()
            ' Fit in the margin bounds
            Dim destRect As LeadRect = LeadRect.Create(e.MarginBounds.X, e.MarginBounds.Y, e.MarginBounds.Width, e.MarginBounds.Height)
            destRect = RasterImage.CalculatePaintModeRectangle(size.Width, size.Height, destRect, RasterPaintSizeMode.Fit, RasterPaintAlignMode.Center, RasterPaintAlignMode.Center)

            Using g As Graphics = Graphics.FromImage(bitmap)
               Using engine As IRenderingEngine = RenderingEngineFactory.Create(g)
                  Dim options As SvgRenderOptions = New SvgRenderOptions()
                  options.Bounds = svgBounds
                  svgDoc.Render(engine, options)
               End Using
            End Using
            e.Graphics.DrawImage(bitmap, destRect.X, destRect.Y, destRect.Width, destRect.Height)
         End Using

         ' Go to the next page
         _currentPrintPageNumber += 1

         ' Inform the printer whether we have more pages to print
         If _currentPrintPageNumber <= document.PrinterSettings.ToPage Then
            e.HasMorePages = True
         Else
            e.HasMorePages = False
         End If
      End Sub

      Private Sub _printDocument_EndPrint(sender As Object, e As PrintEventArgs)
         ' Nothing to do here
      End Sub

      Private Sub _firstPageToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles _firstPageToolStripMenuItem.Click
         _viewer.CurrentPageIndex = 0
         UpdateControls()
      End Sub

      Private Sub _lastPageToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles _lastPageToolStripMenuItem.Click
         _viewer.CurrentPageIndex = _viewer.DocumentList.Count - 1
         UpdateControls()
      End Sub

      Private Sub _previousPageToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles _previousPageToolStripMenuItem.Click
         Dim newCurrentPageIndex As Integer = _viewer.CurrentPageIndex - 1
         If newCurrentPageIndex >= 0 Then
            _viewer.CurrentPageIndex = newCurrentPageIndex
         End If

         UpdateControls()
      End Sub

      Private Sub _nextPageToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles _nextPageToolStripMenuItem.Click
         Dim newCurrentPageIndex As Integer = _viewer.CurrentPageIndex + 1
         If newCurrentPageIndex < _viewer.DocumentList.Count Then
            _viewer.CurrentPageIndex = newCurrentPageIndex
         End If

         UpdateControls()
      End Sub

      Private Sub UpdateControls()
         Dim isDocumentLoaded As Boolean = _viewer.DocumentList.Count <> 0

         _printToolStripMenuItem.Enabled = isDocumentLoaded
         _printPreviewToolStripMenuItem.Enabled = isDocumentLoaded

         _getTextToolStripMenuItem.Enabled = isDocumentLoaded
         _saveTextToolStripMenuItem.Enabled = isDocumentLoaded AndAlso _viewer.DocumentList(_viewer.CurrentPageIndex).DocumentText IsNot Nothing
         _selectTextToolStripMenuItem.Enabled = isDocumentLoaded AndAlso _viewer.DocumentList(_viewer.CurrentPageIndex).DocumentText IsNot Nothing
         _showDocInfoToolStripMenuItem.Enabled = isDocumentLoaded

         _firstPageToolStripMenuItem.Enabled = isDocumentLoaded AndAlso _viewer.CurrentPageIndex > 0
         _previousPageToolStripMenuItem.Enabled = isDocumentLoaded AndAlso _viewer.CurrentPageIndex > 0
         _nextPageToolStripMenuItem.Enabled = isDocumentLoaded AndAlso (_viewer.CurrentPageIndex + 1) <> _viewer.DocumentList.Count
         _lastPageToolStripMenuItem.Enabled = isDocumentLoaded AndAlso (_viewer.CurrentPageIndex + 1) <> _viewer.DocumentList.Count
         _gotoPageToolStripMenuItem.Enabled = isDocumentLoaded AndAlso _viewer.TotalPages > 1

         _useDpiToolStripMenuItem.Checked = _viewer.UseDpi
         _pagePanel.Visible = isDocumentLoaded
         If isDocumentLoaded Then
            _fileNameLabel.Text = String.Format("{0} [Page {1}:{2}]", _name, _viewer.CurrentPageIndex + 1, _viewer.TotalPages)
         End If
      End Sub

      Private Sub MainForm_Resize(sender As Object, e As EventArgs) Handles Me.Resize
         Dim x As Integer = CInt(_gbSvgInfo.Size.Width / 2)
         _gbSvgInfo.Location = New Point(CInt(Me.Size.Width / 2 - x - 13), _gbSvgInfo.Location.Y)
      End Sub

      Private Sub _loadSVGOptionsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles _loadSVGOptionsToolStripMenuItem.Click
         Using dlg As PropertiesDialog = New PropertiesDialog()
            dlg.Properties = New LoadSvgProperties(_loadSvgOptions)
            If dlg.ShowDialog(Me) = DialogResult.OK Then
               dlg.Properties.UpdateCodecsLoadSvgOptions(_loadSvgOptions)
            End If
         End Using
      End Sub

      Private Sub _gotoPageToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles _gotoPageToolStripMenuItem.Click
         Using selPage As SelectPage = New SelectPage()
            selPage.SelectedPageNumber = _viewer.CurrentPageIndex + 1
            selPage.TotalPage = _viewer.TotalPages

            If selPage.ShowDialog(Me) = DialogResult.OK Then
               _viewer.CurrentPageIndex = selPage.SelectedPageNumber - 1
               UpdateControls()
            End If
         End Using
      End Sub
   End Class
End Namespace

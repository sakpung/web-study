' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System.Drawing.Printing

Imports Leadtools
Imports Leadtools.Controls
Imports Leadtools.Codecs
Public Class ViewerForm
   ' The document we are printing
   Private _printDocument As PrintDocument
   ' The current page being printed
   Private _currentPrintPageNumber As Integer

   Public Sub Initialize(ByVal documentFileName As String, ByVal totalPages As Integer, ByVal rasterCodecsInstance As RasterCodecs)
      Text = String.Format("{0} - {1}", documentFileName, Messager.Caption)

      _viewerControl.SetDocument(documentFileName, totalPages, rasterCodecsInstance)

      ' Initialize printing
      If Not IsNothing(PrinterSettings.InstalledPrinters) AndAlso (PrinterSettings.InstalledPrinters.Count > 0) Then
         _printDocument = New PrintDocument()
         _printDocument.PrinterSettings = New PrinterSettings()
         AddHandler _printDocument.BeginPrint, AddressOf _printDocument_BeginPrint
         AddHandler _printDocument.PrintPage, AddressOf _printDocument_PrintPage
         AddHandler _printDocument.EndPrint, AddressOf _printDocument_EndPrint
      Else
         ' No installed printers on this machine
         _printDocument = Nothing
      End If
   End Sub

   Protected Overrides Sub OnFormClosed(ByVal e As System.Windows.Forms.FormClosedEventArgs)
      If Not IsNothing(_printDocument) Then
         _printDocument.Dispose()
      End If

      MyBase.OnFormClosed(e)
   End Sub

   Private Sub _fileToolStripMenuItem_DropDownOpening(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _fileToolStripMenuItem.DropDownOpening
      ' Update the menu items
      _filePrintToolStripMenuItem.Enabled = Not IsNothing(_printDocument)
      _filePrintPreviewToolStripMenuItem.Enabled = _filePrintToolStripMenuItem.Enabled
      _filePrintSetupToolStripMenuItem.Enabled = _filePrintToolStripMenuItem.Enabled
   End Sub

   Private Sub _filePrintToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _filePrintToolStripMenuItem.Click
      ' Only print if we have a printer installed and a document in the viewer
      If Not IsNothing(_printDocument) Then
         ' Setup the print document
         Dim image As RasterImage = _viewerControl.RasterImageViewer.Image

         _printDocument.PrinterSettings.MinimumPage = 1
         _printDocument.PrinterSettings.MaximumPage = image.PageCount
         _printDocument.PrinterSettings.FromPage = _printDocument.PrinterSettings.MinimumPage
         _printDocument.PrinterSettings.ToPage = _printDocument.PrinterSettings.MaximumPage

         Using dlg As New PrintDialog()
            dlg.Document = _printDocument
            If dlg.ShowDialog(Me) = DialogResult.OK Then
               _printDocument.Print()
            End If
         End Using
      End If

   End Sub

   Private Sub _filePrintPreviewToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _filePrintPreviewToolStripMenuItem.Click
      ' Only print if we have a printer installed and a document in the viewer
      If Not IsNothing(_printDocument) Then
         ' Setup the print document
         Dim image As RasterImage = _viewerControl.RasterImageViewer.Image

         _printDocument.PrinterSettings.MinimumPage = 1
         _printDocument.PrinterSettings.MaximumPage = image.PageCount
         _printDocument.PrinterSettings.FromPage = _printDocument.PrinterSettings.MinimumPage
         _printDocument.PrinterSettings.ToPage = _printDocument.PrinterSettings.MaximumPage

         Using dlg As New PrintPreviewDialog()
            dlg.Document = _printDocument
            dlg.Icon = Me.Icon
            dlg.WindowState = FormWindowState.Maximized
            dlg.UseAntiAlias = True
            dlg.ShowDialog(Me)
         End Using
      End If

   End Sub

   Private Sub _filePrintSetupToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _filePrintSetupToolStripMenuItem.Click
      ' Only show the print page setup dialog if we have a printer installed
      If Not IsNothing(_printDocument) Then
         Using dlg As New PageSetupDialog()
            dlg.Document = _printDocument
            dlg.ShowDialog(Me)
         End Using
      End If
   End Sub

   Private Sub _fileCloseToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _fileCloseToolStripMenuItem.Click
      Close()
   End Sub

   Private Sub _viewToolStripMenuItem_DropDownOpening(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _viewToolStripMenuItem.DropDownOpening
      _viewFitWidthToolStripMenuItem.Checked = (_viewerControl.RasterImageViewer.SizeMode = RasterPaintSizeMode.FitWidth)
      _viewFitPageToolStripMenuItem.Checked = (_viewerControl.RasterImageViewer.SizeMode = RasterPaintSizeMode.Fit)
      _viewUseDpiToolStripMenuItem.Checked = _viewerControl.RasterImageViewer.UseDpi
      _viewHighQualityPaintToolStripMenuItem.Checked = _viewerControl.HighQualityPaintScaling
   End Sub

   Private Sub _viewGotoToolStripMenuItem_DropDownOpening(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _viewGotoToolStripMenuItem.DropDownOpening
      Dim image As RasterImage = _viewerControl.RasterImageViewer.Image
      Dim page As Integer = image.Page
      Dim pageCount As Integer = image.PageCount

      _viewGotoFirstPageToolStripMenuItem.Enabled = (page > 1)
      _viewGotoPreviousPageToolStripMenuItem.Enabled = _viewGotoFirstPageToolStripMenuItem.Enabled
      _viewGotoNextPageToolStripMenuItem.Enabled = (page < pageCount)
      _viewGotoLastPageToolStripMenuItem.Enabled = _viewGotoNextPageToolStripMenuItem.Enabled
      _viewGotoPageToolStripMenuItem.Enabled = pageCount > 1
   End Sub

   Private Sub _viewGotoPageToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _viewGotoPreviousPageToolStripMenuItem.Click, _viewGotoPageToolStripMenuItem.Click, _viewGotoNextPageToolStripMenuItem.Click, _viewGotoLastPageToolStripMenuItem.Click, _viewGotoFirstPageToolStripMenuItem.Click
      Dim image As RasterImage = _viewerControl.RasterImageViewer.Image
      Dim page As Integer = image.Page
      Dim pageCount As Integer = image.PageCount

      If sender Is _viewGotoFirstPageToolStripMenuItem Then
         page = 1
      ElseIf sender Is _viewGotoPreviousPageToolStripMenuItem Then
         page = page - 1
      ElseIf sender Is _viewGotoNextPageToolStripMenuItem Then
         page = page + 1
      ElseIf sender Is _viewGotoLastPageToolStripMenuItem Then
         page = pageCount
      Else
         Using dlg As New GotoPageDialog(page, pageCount)
            If dlg.ShowDialog(Me) = DialogResult.OK Then
               page = dlg.Page
            End If
         End Using
      End If

      If page >= 1 AndAlso page <= pageCount AndAlso page <> image.Page Then
         image.Page = page
      End If
   End Sub

   Private Sub _viewZoomOutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _viewZoomOutToolStripMenuItem.Click
      _viewerControl.ZoomViewer(True)
   End Sub

   Private Sub _viewZoomInToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _viewZoomInToolStripMenuItem.Click
      _viewerControl.ZoomViewer(False)
   End Sub

   Private Sub _viewFitWidthToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _viewFitWidthToolStripMenuItem.Click
      _viewerControl.FitPage(True)
   End Sub

   Private Sub _viewFitPageToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _viewFitPageToolStripMenuItem.Click
      _viewerControl.FitPage(False)
   End Sub

   Private Sub _viewUseDpiToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _viewUseDpiToolStripMenuItem.Click
      _viewerControl.RasterImageViewer.UseDpi = Not _viewerControl.RasterImageViewer.UseDpi
   End Sub

   Private Sub _viewRulerToolStripMenuItem_DropDownOpening(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _viewRulerToolStripMenuItem.DropDownOpening
      _viewRulerInchesToolStripMenuItem.Checked = _viewerControl.RulerInInches
      _viewRulerMillimetersToolStripMenuItem.Checked = Not _viewerControl.RulerInInches
   End Sub

   Private Sub _viewRulerInchesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _viewRulerInchesToolStripMenuItem.Click
      _viewerControl.RulerInInches = True
   End Sub

   Private Sub _viewRulerMillimetersToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _viewRulerMillimetersToolStripMenuItem.Click
      _viewerControl.RulerInInches = False
   End Sub

   Private Sub _viewHighQualityPaintToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _viewHighQualityPaintToolStripMenuItem.Click
      _viewerControl.HighQualityPaintScaling = Not _viewerControl.HighQualityPaintScaling
   End Sub

   Private Sub _printDocument_BeginPrint(ByVal sender As Object, ByVal e As PrintEventArgs)
      ' Start from first page in the image
      _currentPrintPageNumber = 1
   End Sub

   Private Sub _printDocument_PrintPage(ByVal sender As Object, ByVal e As PrintPageEventArgs)
      Dim image As RasterImage = _viewerControl.RasterImageViewer.Image

      ' Get the print document object
      Dim document As PrintDocument = CType(sender, PrintDocument)

      ' Create an new LEADTOOLS image printer class
      Dim printer As New RasterImagePrinter()

      ' Set the document object so page calculations can be performed
      printer.PrintDocument = document

      ' We want to fit and center the image into the maximum print area
      printer.SizeMode = RasterPaintSizeMode.FitAlways
      printer.HorizontalAlignMode = RasterPaintAlignMode.Center
      printer.VerticalAlignMode = RasterPaintAlignMode.Center

      ' Account for FAX images that may have different horizontal and vertical resolution
      printer.UseDpi = True

      ' Print the whole image
      printer.ImageRectangle = Rectangle.Empty

      ' Use maximum page dimension ignoring the margins, this will be equivalant of printing
      ' using Windows Photo Gallery
      printer.PageRectangle = RectangleF.Empty
      printer.UseMargins = False

      ' Print the current page
      printer.Print(image, _currentPrintPageNumber, e)

      ' Go to the next page
      _currentPrintPageNumber = _currentPrintPageNumber + 1

      ' Inform the printer whether we have more pages to print
      If _currentPrintPageNumber <= document.PrinterSettings.ToPage Then
         e.HasMorePages = True
      Else
         e.HasMorePages = False
      End If
   End Sub

   Private Sub _printDocument_EndPrint(ByVal sender As Object, ByVal e As PrintEventArgs)
      ' Nothing to do here
   End Sub
End Class

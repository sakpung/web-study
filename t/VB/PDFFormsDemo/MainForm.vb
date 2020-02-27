' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************

Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Drawing.Printing
Imports System.IO
Imports System.Text
Imports System.Windows.Forms

Imports Leadtools
Imports Leadtools.Codecs
Imports Leadtools.Controls
Imports Leadtools.Demos
Imports Leadtools.Demos.Dialogs
Imports Leadtools.Drawing
Imports Leadtools.Pdf
Imports Leadtools.Svg
Imports System

Namespace PDFFormsDemo
   Partial Public Class MainForm
      Inherits Form
      Private _pdfDocument As PDFDocument
      Private _currentPageIndex As Integer = -1
      Private _currentPrintPageNumber As Integer = 0

      Public Sub New()
         InitializeComponent()

         Messager.Caption = "PDF Forms VB Demo"
         Text = Messager.Caption

         FormFieldControl.FormFieldsToolTip = _formFieldToolTip
         FormFieldControl.FormFieldsContextMenu = _formFieldContextMenu

         ' Load default document.
         Dim defaultDocumentPath As String = DemosGlobal.ImagesFolder + "\Employee benefits survey.pdf"
         If File.Exists(defaultDocumentPath) Then
            LoadPDFFile(defaultDocumentPath)
         End If
      End Sub

      Private Sub _imageList_SelectedItemsChanged(sender As Object, e As System.EventArgs) Handles _imageList.SelectedItemsChanged
         For index As Integer = 0 To _imageList.Items.Count - 1
            If _imageList.Items(index).IsSelected Then
               _currentPageIndex = index

               PDFFormContolsHelper.SetPageControlsToCanvas(CType(_imageList.Items(index), PDFPageItem), _imageViewer)

               SetViewerImage(CType(_imageList.Items(_currentPageIndex), PDFPageItem))

               UpdateControls()
            End If
         Next
      End Sub

      Private Sub _miFileOpen_Click(sender As Object, e As System.EventArgs) Handles _miFileOpen.Click
         Using dlg As New OpenFileDialog()

            dlg.Filter = "PDF Documents (*.pdf)|*.pdf"
            If dlg.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK Then
               Dim dir As String = Path.GetDirectoryName(dlg.FileName)

               LoadPDFFile(dlg.FileName)

               If Not PDFDocumentHelper.HasForms Then
                  Messager.ShowError(Me, "The PDF document does not contain any forms data")
               End If
            End If
         End Using
      End Sub

      Private Sub _miFileSaveDataToXML_Click(sender As Object, e As System.EventArgs) Handles _miFileSaveDataToXML.Click
         Dim dlg As New SaveFileDialog()
         dlg.Filter = String.Format("XML (*.xml)|*.xml")

         If dlg.ShowDialog() = DialogResult.OK Then
            Dim pages As New List(Of PDFPageItem)()

            For Each item As PDFPageItem In _imageList.Items
               pages.Add(item)
            Next

            ' Save forms fields as XML file.
            PDFFormsSerializationManager.SaveXML(pages, dlg.FileName)
         End If
      End Sub

      Private Sub _miFileLoadDataFromXML_Click(sender As Object, e As System.EventArgs) Handles _miFileLoadDataFromXML.Click
         Dim dlg As New OpenFileDialog()
         dlg.Filter = String.Format("XML (*.xml)|*.xml")

         If dlg.ShowDialog(Me) = DialogResult.OK Then
            PDFDocumentHelper.LoadFormsFieldsFromXML(dlg.FileName, _pdfDocument, _imageList)

            If Not PDFDocumentHelper.HasForms Then
               MessageBox.Show("The XML file does not contain any forms data", "PDF Forms Demo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If

            PDFFormContolsHelper.SetPageControlsToCanvas(CType(_imageList.ActiveItem, PDFPageItem), _imageViewer)

            _imageViewer.Invalidate()
         End If
      End Sub

      Private Sub _miFilePrint_Click(sender As Object, e As System.EventArgs) Handles _miFilePrint.Click
         Dim image As RasterImage = CType(_imageList.ActiveItem, PDFPageItem).PageImage

         Using printDialog As New PrintDialog()
            Using printDocument As New PrintDocument()
               printDialog.AllowSomePages = True
               printDialog.Document = printDocument
               printDialog.Document.DocumentName = _pdfDocument.FileName

               AddHandler printDocument.BeginPrint, AddressOf printDocument_BeginPrint
               AddHandler printDocument.PrintPage, AddressOf printDocument_PrintPage
               AddHandler printDocument.EndPrint, AddressOf printDocument_EndPrint

               printDocument.PrinterSettings.MinimumPage = 1
               printDocument.PrinterSettings.MaximumPage = image.PageCount
               printDocument.PrinterSettings.FromPage = 1
               printDocument.PrinterSettings.ToPage = image.PageCount

               If printDialog.ShowDialog() = DialogResult.OK Then
                  printDocument.Print()
               End If
            End Using
         End Using
      End Sub

      Private Sub printDocument_BeginPrint(sender As Object, e As PrintEventArgs)
         _currentPrintPageNumber = 1
      End Sub

      Private Sub printDocument_PrintPage(sender As Object, e As PrintPageEventArgs)
         Dim image As RasterImage = TryCast(_imageList.ActiveItem, PDFPageItem).PageImage

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


         Using printImage As Image = RasterImageConverter.ConvertToImage(image, ConvertToImageOptions.None)
            Using printBitmap As New Bitmap(printImage)
               For Each control As FormFieldControl In _imageViewer.Controls
                  If control.IsFieldPrintable Then
                     Dim isFieldVisible As Boolean = control.IsFieldVisible
                     control.IsFieldVisible = True

                     Dim leadBounds As New LeadRect(control.Bounds.X, control.Bounds.Y, control.FiedlBounds.Width, control.Bounds.Height)

                     ' convert from Control to Image coordinates
                     leadBounds = _imageViewer.ConvertRect(Nothing, ImageViewerCoordinateType.Control, ImageViewerCoordinateType.Image, leadBounds)

                     Dim bounds As New Rectangle(leadBounds.X, leadBounds.Y, leadBounds.Width, leadBounds.Height)

                     control.DrawToBitmap(printBitmap, bounds)

                     control.IsFieldVisible = isFieldVisible
                  End If
               Next

               image = RasterImageConverter.ConvertFromImage(printBitmap, ConvertFromImageOptions.None)
            End Using
         End Using

         ' Print the current page
         printer.Print(image, _currentPrintPageNumber, e)

         ' Go to the next page
         _currentPrintPageNumber += 1

         ' Inform the printer whether we have more pages to print
         If _currentPrintPageNumber <= document.PrinterSettings.ToPage Then
            e.HasMorePages = True
         Else
            e.HasMorePages = False
         End If
      End Sub

      Private Sub printDocument_EndPrint(sender As Object, e As PrintEventArgs)
         ' Nothing to do here
      End Sub

      Private Sub _miFileClose_Click(sender As Object, e As System.EventArgs) Handles _miFileClose.Click
         Me.SuspendLayout()

         'Clean PDF Document
         _pdfDocument.Dispose()
         _pdfDocument = Nothing

         'Clean Image Viewer Control.
         _imageViewer.Controls.Clear()
         _imageViewer.Image = Nothing
         _imageViewer.SvgDocument = Nothing

         'Clean Image List Control.
         _imageList.BeginUpdate()
         For index As Integer = 0 To _imageList.Items.Count - 1
            _imageList.Items(index).Image.Dispose()
         Next
         _imageList.Items.Clear()
         _imageList.EndUpdate()

         'Reset Current Page Index.
         _currentPageIndex = -1

         Me.ResumeLayout()

         UpdateControls()
      End Sub

      Private Sub _miFileExit_Click(sender As Object, e As System.EventArgs) Handles _miFileExit.Click
         Me.Close()
      End Sub

      Private Sub _miViewSizeMode_Click(sender As Object, e As EventArgs) Handles _miViewSizeModeActualSize.Click, _miViewSizeModeStretch.Click, _miViewSizeModeFitAlways.Click, _miViewSizeModeFitWidth.Click, _miViewSizeModeFit.Click, _miViewSizeModeFitHeight.Click
         If sender Is _miViewSizeModeFit Then
            Me._imageViewer.Zoom(ControlSizeMode.Fit, 1, _imageViewer.DefaultZoomOrigin)
         ElseIf sender Is _miViewSizeModeFitWidth Then
            Me._imageViewer.Zoom(ControlSizeMode.FitWidth, 1, _imageViewer.DefaultZoomOrigin)
         ElseIf sender Is _miViewSizeModeFitAlways Then
            Me._imageViewer.Zoom(ControlSizeMode.FitAlways, 1, _imageViewer.DefaultZoomOrigin)
         ElseIf sender Is _miViewSizeModeStretch Then
            Me._imageViewer.Zoom(ControlSizeMode.Stretch, 1, _imageViewer.DefaultZoomOrigin)
         ElseIf sender Is _miViewSizeModeActualSize Then
            Me._imageViewer.Zoom(ControlSizeMode.ActualSize, 1, _imageViewer.DefaultZoomOrigin)
         ElseIf sender Is _miViewSizeModeFitHeight Then
            Me._imageViewer.Zoom(ControlSizeMode.FitHeight, 1, _imageViewer.DefaultZoomOrigin)
         End If

         UpdateControls()
      End Sub

      Private Sub _miViewZoom_Click(sender As Object, e As EventArgs) Handles _miViewZoom25.Click, _miViewZoom50.Click, _miViewZoom75.Click, _miViewZoom100.Click, _miViewZoom125.Click, _miViewZoom150.Click, _miViewZoom200.Click
         Dim sf As Double = _imageViewer.ScaleFactor
         sf = 0.25
         If sender Is _miViewZoom50 Then
            sf = 0.5
         End If
         If sender Is _miViewZoom75 Then
            sf = 0.75
         End If
         If sender Is _miViewZoom100 Then
            sf = 1.0
         End If
         If sender Is _miViewZoom125 Then
            sf = 1.25
         End If
         If sender Is _miViewZoom150 Then
            sf = 1.5
         End If
         If sender Is _miViewZoom200 Then
            sf = 2.0
         End If

         _imageViewer.Zoom(_imageList.SizeMode, sf, _imageViewer.DefaultZoomOrigin)

         UpdateControls()
      End Sub

      Private Sub _miViewSVGMode_Click(sender As Object, e As System.EventArgs) Handles _miViewUseSVGMode.Click
         _miViewUseSVGMode.Checked = Not _miViewUseSVGMode.Checked

         SetViewerImage(CType(_imageList.Items(_currentPageIndex), PDFPageItem))

         UpdateControls()
      End Sub

      Private Sub _miMultiPage_Click(sender As Object, e As EventArgs) Handles _miMultiPageFirst.Click, _miMultiPagePrevious.Click, _miMultiPageNext.Click, _miMultiPageLast.Click, _miMultiPageGoto.Click
         Dim firstIndex As Integer = 0
         Dim previousIndex As Integer = _currentPageIndex - 1
         Dim nextIndex As Integer = _currentPageIndex + 1
         Dim lastIndex As Integer = _imageList.Items.Count - 1
         Dim goToIndex As Integer = _currentPageIndex

         For index As Integer = 0 To _imageList.Items.Count - 1
            _imageList.Items(index).IsSelected = False
         Next
         If sender Is _miMultiPageFirst Then
            _imageList.Items(firstIndex).IsSelected = True
         ElseIf sender Is _miMultiPagePrevious Then
            _imageList.Items(previousIndex).IsSelected = True
         ElseIf sender Is _miMultiPageNext Then
            _imageList.Items(nextIndex).IsSelected = True
         ElseIf sender Is _miMultiPageLast Then
            _imageList.Items(lastIndex).IsSelected = True
         ElseIf sender Is _miMultiPageGoto Then
            Dim goToPageWindow As New GoToPageDailog(_currentPageIndex, _imageList.Items.Count)
            If goToPageWindow.ShowDialog() = DialogResult.OK Then
               goToIndex = goToPageWindow.PageNumber - 1
            End If

            _imageList.Items(goToIndex).IsSelected = True
         End If
      End Sub

      Private Sub _miHelpAbout_Click(sender As Object, e As System.EventArgs) Handles _miHelpAbout.Click
         Using aboutDialog As New AboutDialog("PDF Forms", ProgrammingInterface.VB)
            aboutDialog.ShowDialog(Me)
         End Using
      End Sub

      Private Sub _propertiesToolStripMenuItem_Click(sender As Object, e As System.EventArgs) Handles _propertiesToolStripMenuItem.Click
         Dim formFieldControl As FormFieldControl = CType(_formFieldContextMenu.SourceControl.Tag, FormFieldControl)

         If formFieldControl IsNot Nothing Then
            Using pdfFormFieldPropertiesDailog As New PDFFormFieldPropertiesDailog(formFieldControl)
               pdfFormFieldPropertiesDailog.ShowDialog()
            End Using
         End If
      End Sub


      Private Sub _imageViewer_PostRender(sender As Object, e As ImageViewerRenderEventArgs) Handles _imageViewer.PostRender
         For Each control As FormFieldControl In _imageViewer.Controls
            control.Invalidate()
         Next
      End Sub

      Private Sub _imageViewer_TransformChanged(sender As Object, e As System.EventArgs) Handles _imageViewer.TransformChanged
         For Each control As FormFieldControl In _imageViewer.Controls
            control.SuspendLayout()

            ' Convert from image to view coordinates
            Dim bounds As LeadRect = _imageViewer.ConvertRect(Nothing, ImageViewerCoordinateType.Image, ImageViewerCoordinateType.Control, control.FiedlBounds)

            ' Update Move/Size the control
            control.Left = Bounds.X
            control.Top = Bounds.Y
            control.Width = Bounds.Width
            control.Height = Bounds.Height


            control.ResumeLayout()
         Next
      End Sub

      Private Sub _imageViewer_LostFocus(sender As Object, e As EventArgs) Handles _imageViewer.LostFocus
         Me._imageViewer.Invalidate()
      End Sub

      Private Sub LoadPDFFile(fileName As String)
         Try
            Using codecs As New RasterCodecs()
               codecs.Options.RasterizeDocument.Load.XResolution = 300
               codecs.Options.RasterizeDocument.Load.YResolution = 300
               codecs.Options.Pdf.Load.HideFormFields = True

               If _pdfDocument IsNot Nothing Then
                  _pdfDocument.Dispose()
                  _pdfDocument = Nothing
               End If

               _pdfDocument = New PDFDocument(fileName)

               Dim _parseDocumentStructOptions As PDFParseDocumentStructureOptions = PDFParseDocumentStructureOptions.InternalLinks Or PDFParseDocumentStructureOptions.Bookmarks

               _pdfDocument.ParseDocumentStructure(_parseDocumentStructOptions)

               PDFDocumentHelper.LoadPDFDocument(codecs, _pdfDocument, _imageList)

               ' Reset current page index value.
               _currentPageIndex = 0

               _imageList.Items(_currentPageIndex).IsSelected = True
            End Using
         Catch ex As Exception
            Messager.ShowError(Me, ex.Message)
         Finally
            UpdateControls()
         End Try
      End Sub

      Private Sub SetViewerImage(item As PDFPageItem)
         ' Scroll Home.
         _imageViewer.ScrollOffset = New LeadPoint(0, 0)

         If _miViewUseSVGMode.Checked Then
            _imageViewer.ActiveItem.SvgDocument = item.PageSVG
         Else
            _imageViewer.ActiveItem.Image = item.PageImage
         End If
      End Sub

      Private Sub UpdateControls()
         Dim hasImage As Boolean = (_imageViewer.Image IsNot Nothing OrElse _imageViewer.SvgDocument IsNot Nothing)
         Dim isMultiPage As Boolean = If(_imageList.Items.Count > 1, True, False)
         Dim isFirstPage As Boolean = _currentPageIndex = 0
         Dim isLastPage As Boolean = _currentPageIndex = _imageList.Items.Count - 1

         _miView.Visible = If(hasImage, True, False)
         _miMultiPage.Visible = If(hasImage, True, False)

         _miFileLoadDataFromXML.Enabled = hasImage
         _miFileSaveDataToXML.Enabled = hasImage
         _miFileClose.Enabled = hasImage

         _miViewSizeModeFit.Checked = (_imageViewer.SizeMode = ControlSizeMode.Fit)
         _miViewSizeModeFitAlways.Checked = (_imageViewer.SizeMode = ControlSizeMode.FitAlways)
         _miViewSizeModeFitWidth.Checked = (_imageViewer.SizeMode = ControlSizeMode.FitWidth)
         _miViewSizeModeStretch.Checked = (_imageViewer.SizeMode = ControlSizeMode.Stretch)
         _miViewSizeModeFitHeight.Checked = (_imageViewer.SizeMode = ControlSizeMode.FitHeight)
         _miViewSizeModeActualSize.Checked = (_imageViewer.SizeMode = ControlSizeMode.ActualSize)

         If _imageViewer.SizeMode = ControlSizeMode.None OrElse _imageViewer.SizeMode = ControlSizeMode.ActualSize Then
            _miViewZoom.Enabled = True
         Else
            _miViewZoom.Enabled = False
         End If

         _miViewZoom25.Checked = (_imageViewer.ScaleFactor = 0.25)
         _miViewZoom50.Checked = (_imageViewer.ScaleFactor = 0.5)
         _miViewZoom75.Checked = (_imageViewer.ScaleFactor = 0.75)
         _miViewZoom100.Checked = (_imageViewer.ScaleFactor = 1.0)
         _miViewZoom125.Checked = (_imageViewer.ScaleFactor = 1.25)
         _miViewZoom150.Checked = (_imageViewer.ScaleFactor = 1.5)
         _miViewZoom200.Checked = (_imageViewer.ScaleFactor = 2.0)

         _miMultiPageFirst.Enabled = isMultiPage AndAlso Not isFirstPage
         _miMultiPagePrevious.Enabled = isMultiPage AndAlso Not isFirstPage
         _miMultiPageNext.Enabled = isMultiPage AndAlso Not isLastPage
         _miMultiPageLast.Enabled = isMultiPage AndAlso Not isLastPage
         _miMultiPageGoto.Enabled = isMultiPage
      End Sub
   End Class
End Namespace

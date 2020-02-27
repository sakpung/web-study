// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Text;
using System.Windows.Forms;

using Leadtools;
using Leadtools.Codecs;
using Leadtools.Controls;
using Leadtools.Demos;
using Leadtools.Demos.Dialogs;
using Leadtools.Drawing;
using Leadtools.Pdf;
using Leadtools.Svg;

namespace PDFFormsDemo
{
   public partial class MainForm : Form
   {
      private PDFDocument _pdfDocument;
      private int _currentPageIndex = -1;
      private int _currentPrintPageNumber = 0;

      public MainForm()
      {
         InitializeComponent();

         Messager.Caption = "PDF Forms C# Demo";
         Text = Messager.Caption;

         FormFieldControl.FormFieldsToolTip = _formFieldToolTip;
         FormFieldControl.FormFieldsContextMenu = _formFieldContextMenu;

         // Load default document.
         string defaultDocumentPath = DemosGlobal.ImagesFolder + @"\Employee benefits survey.pdf";
         if (File.Exists(defaultDocumentPath))
            LoadPDFFile(defaultDocumentPath);
      }

      private void _imageList_SelectedItemsChanged(object sender, EventArgs e)
      {
         for (int index = 0; index < _imageList.Items.Count; index++)
         {
            if (_imageList.Items[index].IsSelected)
            {
               _currentPageIndex = index;

               PDFFormContolsHelper.SetPageControlsToCanvas(_imageList.Items[index] as PDFPageItem, _imageViewer);

               SetViewerImage(_imageList.Items[_currentPageIndex] as PDFPageItem);

               UpdateControls();
            }
         }
      }

      private void _miFileOpen_Click(object sender, EventArgs e)
      {
         using (OpenFileDialog dlg = new OpenFileDialog())
         {
            dlg.Filter = "PDF Documents (*.pdf)|*.pdf";
            if (dlg.ShowDialog(this) == DialogResult.OK)
            {
               string dir = Path.GetDirectoryName(dlg.FileName);

               LoadPDFFile(dlg.FileName);

               if (!PDFDocumentHelper.HasForms)
                  Messager.ShowError(this, "The PDF document does not contain any forms data");
            }
         }
      }

      private void _miFileSaveDataToXML_Click(object sender, EventArgs e)
      {
         SaveFileDialog dlg = new SaveFileDialog();
         dlg.Filter = string.Format("XML (*.xml)|*.xml");

         if (dlg.ShowDialog() == DialogResult.OK)
         {
            List<PDFPageItem> pages = new List<PDFPageItem>();

            foreach (PDFPageItem item in _imageList.Items)
               pages.Add(item);

            // Save forms fields as XML file.
            PDFFormsSerializationManager.SaveXML(pages, dlg.FileName);
         }
      }

      private void _miFileLoadDataFromXML_Click(object sender, EventArgs e)
      {
         OpenFileDialog dlg = new OpenFileDialog();
         dlg.Filter = string.Format("XML (*.xml)|*.xml");

         if (dlg.ShowDialog(this) == DialogResult.OK)
         {
            PDFDocumentHelper.LoadFormsFieldsFromXML(dlg.FileName, _pdfDocument, _imageList);

            if (!PDFDocumentHelper.HasForms)
               MessageBox.Show("The XML file does not contain any forms data", "PDF Forms Demo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            PDFFormContolsHelper.SetPageControlsToCanvas(_imageList.ActiveItem as PDFPageItem, _imageViewer);

            _imageViewer.OnTransformChanged(e);
         }
      }

      private void _miFilePrint_Click(object sender, EventArgs e)
      {
         RasterImage image = (_imageList.ActiveItem as PDFPageItem).PageImage;

         using (PrintDialog printDialog = new PrintDialog())
         {
            using (PrintDocument printDocument = new PrintDocument())
            {
               printDialog.AllowSomePages = true;
               printDialog.Document = printDocument;
               printDialog.Document.DocumentName = _pdfDocument.FileName;

               printDocument.BeginPrint += new PrintEventHandler(printDocument_BeginPrint);
               printDocument.PrintPage += new PrintPageEventHandler(printDocument_PrintPage);
               printDocument.EndPrint += new PrintEventHandler(printDocument_EndPrint);

               printDocument.PrinterSettings.MinimumPage = 1;
               printDocument.PrinterSettings.MaximumPage = image.PageCount;
               printDocument.PrinterSettings.FromPage = 1;
               printDocument.PrinterSettings.ToPage = image.PageCount;

               if (printDialog.ShowDialog() == DialogResult.OK)
               {
                  printDocument.Print();
               }
            }
         }
      }

      private void printDocument_BeginPrint(object sender, PrintEventArgs e)
      {
         _currentPrintPageNumber = 1;
      }

      private void printDocument_PrintPage(object sender, PrintPageEventArgs e)
      {
         RasterImage image = (_imageList.ActiveItem as PDFPageItem).PageImage;

         // Get the print document object
         PrintDocument document = sender as PrintDocument;

         // Create an new LEADTOOLS image printer class
         RasterImagePrinter printer = new RasterImagePrinter();

         // Set the document object so page calculations can be performed
         printer.PrintDocument = document;

         // We want to fit and center the image into the maximum print area
         printer.SizeMode = RasterPaintSizeMode.FitAlways;
         printer.HorizontalAlignMode = RasterPaintAlignMode.Center;
         printer.VerticalAlignMode = RasterPaintAlignMode.Center;

         // Account for FAX images that may have different horizontal and vertical resolution
         printer.UseDpi = true;

         // Print the whole image
         printer.ImageRectangle = Rectangle.Empty;

         // Use maximum page dimension ignoring the margins, this will be equivalant of printing
         // using Windows Photo Gallery
         printer.PageRectangle = RectangleF.Empty;
         printer.UseMargins = false;

         using (Image printImage = RasterImageConverter.ConvertToImage(image, ConvertToImageOptions.None))
         {
            using (Bitmap printBitmap = new Bitmap(printImage))
            {
               foreach (FormFieldControl control in _imageViewer.Controls)
               {
                  if (control.IsFieldPrintable)
                  {
                     bool isFieldVisible = control.IsFieldVisible;
                     control.IsFieldVisible = true;

                     LeadRect leadBounds = new LeadRect(control.Bounds.X, control.Bounds.Y, control.FiedlBounds.Width, control.Bounds.Height);

                     // convert from Control to Image coordinates
                     leadBounds = _imageViewer.ConvertRect(null, ImageViewerCoordinateType.Control, ImageViewerCoordinateType.Image, leadBounds);

                     Rectangle bounds = new Rectangle(leadBounds.X, leadBounds.Y, leadBounds.Width, leadBounds.Height);

                     control.DrawToBitmap(printBitmap, bounds);

                     control.IsFieldVisible = isFieldVisible;
                  }
               }

               image = RasterImageConverter.ConvertFromImage(printBitmap, ConvertFromImageOptions.None);
            }
         }

         // Print the current page
         printer.Print(image, _currentPrintPageNumber, e);

         // Go to the next page
         _currentPrintPageNumber++;

         // Inform the printer whether we have more pages to print
         if (_currentPrintPageNumber <= document.PrinterSettings.ToPage)
            e.HasMorePages = true;
         else
            e.HasMorePages = false;
      }

      private void printDocument_EndPrint(object sender, PrintEventArgs e)
      {
         // Nothing to do here
      }

      private void _miFileClose_Click(object sender, EventArgs e)
      {
         this.SuspendLayout();

         //Clean PDF Document
         _pdfDocument.Dispose();
         _pdfDocument = null;

         //Clean Image Viewer Control.
         _imageViewer.Controls.Clear();
         _imageViewer.Image = null;
         _imageViewer.SvgDocument = null;

         //Clean Image List Control.
         _imageList.BeginUpdate();
         for (int index = 0; index < _imageList.Items.Count; index++)
         {
            _imageList.Items[index].Image.Dispose();
         }
         _imageList.Items.Clear();
         _imageList.EndUpdate();

         //Reset Current Page Index.
         _currentPageIndex = -1;

         this.ResumeLayout();

         UpdateControls();
      }

      private void _miFileExit_Click(object sender, EventArgs e)
      {
         this.Close();
      }

      private void _miViewSizeMode_Click(object sender, EventArgs e)
      {
         if (sender == _miViewSizeModeFit)
            this._imageViewer.Zoom(ControlSizeMode.Fit, 1, _imageViewer.DefaultZoomOrigin);
         else if (sender == _miViewSizeModeFitWidth)
            this._imageViewer.Zoom(ControlSizeMode.FitWidth, 1, _imageViewer.DefaultZoomOrigin);
         else if (sender == _miViewSizeModeFitAlways)
            this._imageViewer.Zoom(ControlSizeMode.FitAlways, 1, _imageViewer.DefaultZoomOrigin);
         else if (sender == _miViewSizeModeStretch)
            this._imageViewer.Zoom(ControlSizeMode.Stretch, 1, _imageViewer.DefaultZoomOrigin);
         else if (sender == _miViewSizeModeActualSize)
            this._imageViewer.Zoom(ControlSizeMode.ActualSize, 1, _imageViewer.DefaultZoomOrigin);
         else if (sender == _miViewSizeModeFitHeight)
            this._imageViewer.Zoom(ControlSizeMode.FitHeight, 1, _imageViewer.DefaultZoomOrigin);

         UpdateControls();
      }

      private void _miViewZoom_Click(object sender, EventArgs e)
      {
         double sf = _imageViewer.ScaleFactor;
         sf = 0.25;
         if (sender == _miViewZoom50)
            sf = 0.5;
         if (sender == _miViewZoom75)
            sf = 0.75;
         if (sender == _miViewZoom100)
            sf = 1.0;
         if (sender == _miViewZoom125)
            sf = 1.25;
         if (sender == _miViewZoom150)
            sf = 1.5;
         if (sender == _miViewZoom200)
            sf = 2.0;

         _imageViewer.Zoom(_imageList.SizeMode, sf, _imageViewer.DefaultZoomOrigin);

         UpdateControls();
      }

      private void _miViewUseDpi_Click(object sender, EventArgs e)
      {
         _imageViewer.UseDpi = !_imageViewer.UseDpi;

         _imageViewer.Invalidate();

         UpdateControls();
      }

      private void _miViewSVGMode_Click(object sender, EventArgs e)
      {
         _miViewUseSVGMode.Checked = !_miViewUseSVGMode.Checked;

         SetViewerImage(_imageList.Items[_currentPageIndex] as PDFPageItem);

         UpdateControls();
      }

      private void _miMultiPage_Click(object sender, EventArgs e)
      {
         int firstIndex = 0;
         int previousIndex = _currentPageIndex - 1;
         int nextIndex = _currentPageIndex + 1;
         int lastIndex = _imageList.Items.Count - 1;
         int goToIndex = _currentPageIndex;

         for (int index = 0; index < _imageList.Items.Count; index++)
         {
            _imageList.Items[index].IsSelected = false;
         }
         if (sender == _miMultiPageFirst)
         {
            _imageList.Items[firstIndex].IsSelected = true;
         }
         else if (sender == _miMultiPagePrevious)
         {
            _imageList.Items[previousIndex].IsSelected = true;
         }
         else if (sender == _miMultiPageNext)
         {
            _imageList.Items[nextIndex].IsSelected = true;
         }
         else if (sender == _miMultiPageLast)
         {
            _imageList.Items[lastIndex].IsSelected = true;
         }
         else if (sender == _miMultiPageGoto)
         {
            GoToPageDailog goToPageWindow = new GoToPageDailog(_currentPageIndex, _imageList.Items.Count);
            if (goToPageWindow.ShowDialog() == DialogResult.OK)
            {
               goToIndex = goToPageWindow.PageNumber - 1;
            }

            _imageList.Items[goToIndex].IsSelected = true;
         }
      }

      private void _miHelpAbout_Click(object sender, EventArgs e)
      {
         using (AboutDialog aboutDialog = new AboutDialog("PDF Forms", ProgrammingInterface.CS))
            aboutDialog.ShowDialog(this);
      }

      private void _propertiesToolStripMenuItem_Click(object sender, EventArgs e)
      {
         FormFieldControl formFieldControl = _formFieldContextMenu.SourceControl.Tag as FormFieldControl;

         if (formFieldControl != null)
         {
            using (PDFFormFieldPropertiesDailog pdfFormFieldPropertiesDailog = new PDFFormFieldPropertiesDailog(formFieldControl))
               pdfFormFieldPropertiesDailog.ShowDialog();
         }
      }

      private void _imageViewer_PostRender(object sender, ImageViewerRenderEventArgs e)
      {
         foreach (FormFieldControl control in _imageViewer.Controls)
         {
            control.Invalidate();
         }
      }

      private void _imageViewer_TransformChanged(object sender, EventArgs e)
      {
         foreach (FormFieldControl control in _imageViewer.Controls)
         {
            control.SuspendLayout();

            // Convert from image to view coordinates
            LeadRect bounds = _imageViewer.ConvertRect(null, ImageViewerCoordinateType.Image, ImageViewerCoordinateType.Control, control.FiedlBounds);

            // Update Move/Size the control
            control.Left = bounds.X;
            control.Top = bounds.Y;
            control.Width = bounds.Width;
            control.Height = bounds.Height;

            control.ResumeLayout();
         }
      }

      private void _imageViewer_LostFocus(object sender, EventArgs e)
      {
         this._imageViewer.Invalidate();
      }

      private void LoadPDFFile(string fileName)
      {
         try
         {
            using (RasterCodecs codecs = new RasterCodecs())
            {
               codecs.Options.RasterizeDocument.Load.XResolution = 300;
               codecs.Options.RasterizeDocument.Load.YResolution = 300;
               codecs.Options.Pdf.Load.HideFormFields = true;

               if (_pdfDocument != null)
               {
                  _pdfDocument.Dispose();
                  _pdfDocument = null;
               }

               _pdfDocument = new PDFDocument(fileName);

               PDFParseDocumentStructureOptions _parseDocumentStructOptions = PDFParseDocumentStructureOptions.InternalLinks | PDFParseDocumentStructureOptions.Bookmarks;

               _pdfDocument.ParseDocumentStructure(_parseDocumentStructOptions);

               PDFDocumentHelper.LoadPDFDocument(codecs, _pdfDocument, _imageList);

               // Reset current page index value.
               _currentPageIndex = 0;

               _imageList.Items[_currentPageIndex].IsSelected = true;
            }
         }
         catch (Exception ex)
         {
            Messager.ShowError(this, ex.Message);
         }
         finally
         {
            UpdateControls();
         }
      }

      private void SetViewerImage(PDFPageItem item)
      {
         // Scroll Home.
         _imageViewer.ScrollOffset = new LeadPoint(0, 0);

         if (_miViewUseSVGMode.Checked)
         {
            _imageViewer.ActiveItem.SvgDocument = item.PageSVG;
         }
         else
         {
            _imageViewer.ActiveItem.Image = item.PageImage;
         }
      }

      private void UpdateControls()
      {
         bool hasImage = (_imageViewer.Image != null || _imageViewer.SvgDocument != null);
         bool isMultiPage = _imageList.Items.Count > 1 ? true : false;
         bool isFirstPage = _currentPageIndex == 0;
         bool isLastPage = _currentPageIndex == _imageList.Items.Count - 1;

         _miView.Visible = hasImage ? true : false;
         _miMultiPage.Visible = hasImage ? true : false;

         _miFileLoadDataFromXML.Enabled = hasImage;
         _miFileSaveDataToXML.Enabled = hasImage;
         _miFileClose.Enabled = hasImage;

         _miViewSizeModeFit.Checked = (_imageViewer.SizeMode == ControlSizeMode.Fit);
         _miViewSizeModeFitAlways.Checked = (_imageViewer.SizeMode == ControlSizeMode.FitAlways);
         _miViewSizeModeFitWidth.Checked = (_imageViewer.SizeMode == ControlSizeMode.FitWidth);
         _miViewSizeModeStretch.Checked = (_imageViewer.SizeMode == ControlSizeMode.Stretch);
         _miViewSizeModeFitHeight.Checked = (_imageViewer.SizeMode == ControlSizeMode.FitHeight);
         _miViewSizeModeActualSize.Checked = (_imageViewer.SizeMode == ControlSizeMode.ActualSize);

         if (_imageViewer.SizeMode == ControlSizeMode.None || _imageViewer.SizeMode == ControlSizeMode.ActualSize)
            _miViewZoom.Enabled = true;
         else
            _miViewZoom.Enabled = false;

         _miViewZoom25.Checked = (_imageViewer.ScaleFactor == 0.25);
         _miViewZoom50.Checked = (_imageViewer.ScaleFactor == 0.5);
         _miViewZoom75.Checked = (_imageViewer.ScaleFactor == 0.75);
         _miViewZoom100.Checked = (_imageViewer.ScaleFactor == 1.0);
         _miViewZoom125.Checked = (_imageViewer.ScaleFactor == 1.25);
         _miViewZoom150.Checked = (_imageViewer.ScaleFactor == 1.5);
         _miViewZoom200.Checked = (_imageViewer.ScaleFactor == 2.0);

         _miMultiPageFirst.Enabled = isMultiPage && !isFirstPage;
         _miMultiPagePrevious.Enabled = isMultiPage && !isFirstPage;
         _miMultiPageNext.Enabled = isMultiPage && !isLastPage;
         _miMultiPageLast.Enabled = isMultiPage && !isLastPage;
         _miMultiPageGoto.Enabled = isMultiPage;
      }
   }
}

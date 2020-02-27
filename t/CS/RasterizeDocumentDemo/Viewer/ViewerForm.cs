// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Printing;

using Leadtools.Demos;
using Leadtools;
using Leadtools.Controls;

namespace RasterizeDocumentDemo.Viewer
{
   public partial class ViewerForm : Form
   {
      // The document we are printing
      private PrintDocument _printDocument;
      // The current page being printed
      private int _currentPrintPageNumber;

      public ViewerForm()
      {
         InitializeComponent();
      }

      public void Initialize(string documentFileName, int firstPageNumber, int lastPageNumber, Leadtools.Codecs.RasterCodecs rasterCodecsInstance)
      {
         Text = string.Format("{0} - {1}", documentFileName, Messager.Caption);

         _viewerControl.SetDocument(documentFileName, firstPageNumber, lastPageNumber, rasterCodecsInstance);
         
         // Initialize printing
         if (PrinterSettings.InstalledPrinters != null && PrinterSettings.InstalledPrinters.Count > 0)
         {
            _printDocument = new PrintDocument();
            _printDocument.PrinterSettings = new PrinterSettings();
            _printDocument.BeginPrint += new PrintEventHandler(_printDocument_BeginPrint);
            _printDocument.PrintPage += new PrintPageEventHandler(_printDocument_PrintPage);
            _printDocument.EndPrint += new PrintEventHandler(_printDocument_EndPrint);
         }
         else
         {
            // No installed printers on this machine
            _printDocument = null;
         }
      }

      protected override void OnFormClosed(FormClosedEventArgs e)
      {
         if (_printDocument != null)
         {
            _printDocument.Dispose();
         }

         base.OnFormClosed(e);
      }

      private void _fileToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
      {
         // Update the menu items
         _filePrintToolStripMenuItem.Enabled = _printDocument != null;
         _filePrintPreviewToolStripMenuItem.Enabled = _filePrintToolStripMenuItem.Enabled;
         _filePrintSetupToolStripMenuItem.Enabled = _filePrintToolStripMenuItem.Enabled;
      }

      private void _filePrintToolStripMenuItem_Click(object sender, EventArgs e)
      {
         // Only print if we have a printer installed and a document in the viewer
         if (_printDocument != null)
         {
            // Setup the print document
            RasterImage image = _viewerControl.ImageViewer.Image;

            _printDocument.PrinterSettings.MinimumPage = 1;
            _printDocument.PrinterSettings.MaximumPage = image.PageCount;
            _printDocument.PrinterSettings.FromPage = _printDocument.PrinterSettings.MinimumPage;
            _printDocument.PrinterSettings.ToPage = _printDocument.PrinterSettings.MaximumPage;

            using (PrintDialog dlg = new PrintDialog())
            {
               dlg.Document = _printDocument;
               if (dlg.ShowDialog(this) == DialogResult.OK)
               {
                  _printDocument.Print();
               }
            }
         }
      }

      private void _filePrintPreviewToolStripMenuItem_Click(object sender, EventArgs e)
      {
         // Only print if we have a printer installed and a document in the viewer
         if (_printDocument != null)
         {
            // Setup the print document
            RasterImage image = _viewerControl.ImageViewer.Image;

            _printDocument.PrinterSettings.MinimumPage = 1;
            _printDocument.PrinterSettings.MaximumPage = image.PageCount;
            _printDocument.PrinterSettings.FromPage = _printDocument.PrinterSettings.MinimumPage;
            _printDocument.PrinterSettings.ToPage = _printDocument.PrinterSettings.MaximumPage;

            using (PrintPreviewDialog dlg = new PrintPreviewDialog())
            {
               dlg.Document = _printDocument;
               dlg.Icon = this.Icon;
               dlg.WindowState = FormWindowState.Maximized;
               dlg.UseAntiAlias = true;
               dlg.ShowDialog(this);
            }
         }
      }

      private void _filePrintSetupToolStripMenuItem_Click(object sender, EventArgs e)
      {
         // Only show the print page setup dialog if we have a printer installed
         if (_printDocument != null)
         {
            using (PageSetupDialog dlg = new PageSetupDialog())
            {
               dlg.Document = _printDocument;
               dlg.ShowDialog(this);
            }
         }
      }

      private void _fileCloseToolStripMenuItem_Click(object sender, EventArgs e)
      {
         Close();
      }

      private void _viewToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
      {
         _viewFitWidthToolStripMenuItem.Checked = _viewerControl.ImageViewer.SizeMode == ControlSizeMode.FitWidth;
         _viewFitPageToolStripMenuItem.Checked = _viewerControl.ImageViewer.SizeMode == ControlSizeMode.Fit;
         _viewUseDpiToolStripMenuItem.Checked = _viewerControl.ImageViewer.UseDpi;
         _viewHighQualityPaintToolStripMenuItem.Checked = _viewerControl.HighQualityPaintScaling;
      }

      private void _viewGotoToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
      {
         int page = _viewerControl.CurrentPage;
         int pageCount = _viewerControl.PagesCount;

         _viewGotoFirstPageToolStripMenuItem.Enabled = page > _viewerControl.FirstPage;
         _viewGotoPreviousPageToolStripMenuItem.Enabled = _viewGotoFirstPageToolStripMenuItem.Enabled;
         _viewGotoNextPageToolStripMenuItem.Enabled = page < _viewerControl.LastPage;
         _viewGotoLastPageToolStripMenuItem.Enabled = _viewGotoNextPageToolStripMenuItem.Enabled;
         _viewGotoPageToolStripMenuItem.Enabled = pageCount > 1;
      }

      private void _viewGotoPageToolStripMenuItem_Click(object sender, EventArgs e)
      {
         int currentPage = _viewerControl.CurrentPage;
         int firstPage = _viewerControl.FirstPage;
         int lastPage = _viewerControl.LastPage;
         int page = currentPage;
         int pageCount = _viewerControl.PagesCount;

         if (sender == _viewGotoFirstPageToolStripMenuItem)
            page = firstPage;
         else if (sender == _viewGotoPreviousPageToolStripMenuItem)
            page--;
         else if (sender == _viewGotoNextPageToolStripMenuItem)
            page++;
         else if (sender == _viewGotoLastPageToolStripMenuItem)
            page = lastPage;
         else
         {
            // Set view page number
            int viewPageNumber = page - firstPage + 1;
            using (GotoPageDialog dlg = new GotoPageDialog(viewPageNumber, pageCount))
            {
               if (dlg.ShowDialog(this) == DialogResult.OK)
                  page = dlg.Page + firstPage - 1;
            }
         }

         if (page >= firstPage && page <= lastPage && page != currentPage)
            _viewerControl.TryGotoPage(page);
      }

      private void _viewZoomOutToolStripMenuItem_Click(object sender, EventArgs e)
      {
         _viewerControl.ZoomViewer(true);
      }

      private void _viewZoomInToolStripMenuItem_Click(object sender, EventArgs e)
      {
         _viewerControl.ZoomViewer(false);
      }

      private void _viewFitWidthToolStripMenuItem_Click(object sender, EventArgs e)
      {
         _viewerControl.FitPage(true);
      }

      private void _viewFitPageToolStripMenuItem_Click(object sender, EventArgs e)
      {
         _viewerControl.FitPage(false);
      }

      private void _viewUseDpiToolStripMenuItem_Click(object sender, EventArgs e)
      {
         _viewerControl.ImageViewer.UseDpi = !_viewerControl.ImageViewer.UseDpi;
      }

      private void _viewRulerToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
      {
         _viewRulerInchesToolStripMenuItem.Checked = _viewerControl.RulerInInches;
         _viewRulerMillimetersToolStripMenuItem.Checked = !_viewerControl.RulerInInches;
      }

      private void _viewRulerInchesToolStripMenuItem_Click(object sender, EventArgs e)
      {
         _viewerControl.RulerInInches = true;
      }

      private void _viewRulerMillimetersToolStripMenuItem_Click(object sender, EventArgs e)
      {
         _viewerControl.RulerInInches = false;
      }

      private void _viewHighQualityPaintToolStripMenuItem_Click(object sender, EventArgs e)
      {
         _viewerControl.HighQualityPaintScaling = !_viewerControl.HighQualityPaintScaling;
      }

      private void _printDocument_BeginPrint(object sender, PrintEventArgs e)
      {
         // Start from first page in the image
         _currentPrintPageNumber = 1;
      }

      private void _printDocument_PrintPage(object sender, PrintPageEventArgs e)
      {
         RasterImage image = _viewerControl.ImageViewer.Image;

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

      private void _printDocument_EndPrint(object sender, PrintEventArgs e)
      {
         // Nothing to do here
      }
   }
}

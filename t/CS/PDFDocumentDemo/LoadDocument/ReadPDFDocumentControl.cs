// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using Leadtools.Demos;
using Leadtools.Pdf;

namespace PDFDocumentDemo.LoadDocument
{
   public partial class ReadPDFDocumentControl : UserControl
   {
      public ReadPDFDocumentControl()
      {
         InitializeComponent();
      }

      private bool _stopReading;

      protected override void OnLoad(EventArgs e)
      {
         if (!DesignMode)
         {
            _readDocumentStructureLabel.Visible = false;
            _readDocumentStructureValueLabel.Visible = false;
            _readObjectsLabel.Visible = false;
            _readObjectsValueLabel.Visible = false;
            _readObjectsProgressBar.Visible = false;
            _stopButton.Visible = false;
            _errorsGroupBox.Visible = false;
            _errorsLabel.Visible = false;
            _copyToClipboardButton.Visible = false;
            _stopReading = false;
         }

         base.OnLoad(e);
      }

      public bool Run(PDFDocument document, PDFParseDocumentStructureOptions parseDocumentStructureOptions, PDFParsePagesOptions parsePagesOptions, bool parseChunks)
      {
         // - Read the document structure
         ReadDocumentStructure(document, parseDocumentStructureOptions);

         // - Parse the document objects
         ParseObjects(document, parsePagesOptions, parseChunks);

         if (_errorsListBox.Items.Count > 0)
         {
            _errorsLabel.Visible = true;
            _copyToClipboardButton.Visible = true;
            return false;
         }

         return true;
      }

      private void ReadDocumentStructure(PDFDocument document, PDFParseDocumentStructureOptions parseDocumentStructureOptions)
      {
         _readDocumentStructureLabel.Visible = true;
         _readDocumentStructureValueLabel.Visible = true;
         Application.DoEvents();

         try
         {
            if (parseDocumentStructureOptions != PDFParseDocumentStructureOptions.None)
            {
               using (WaitCursor wait = new WaitCursor())
               {
                  document.ParseDocumentStructure(parseDocumentStructureOptions);
                  _readDocumentStructureValueLabel.Text = DemosGlobalization.GetResxString(GetType(),"resx_Finished");
               }
            }
            else
            {
               _readDocumentStructureValueLabel.Text = DemosGlobalization.GetResxString(GetType(),"resx_Skipped");
            }
         }
         catch (Exception ex)
         {
            _readDocumentStructureValueLabel.Text = DemosGlobalization.GetResxString(GetType(),"resx_Error");
            AddError(DemosGlobalization.GetResxString(GetType(),"resx_ReadingDocumentStructure"), ex);
         }

         Application.DoEvents();
      }

      private void ParseObjects(PDFDocument document, PDFParsePagesOptions parsePagesOptions, bool parseChunks)
      {
         if (parsePagesOptions == PDFParsePagesOptions.None)
         {
            return;
         }

         _readObjectsLabel.Visible = true;

         int pageCount = document.Pages.Count;

         int chunkSize;

         if (parseChunks)
         {
            _readObjectsValueLabel.Visible = false;
            _readObjectsProgressBar.Visible = true;
            _stopButton.Visible = true;
            _readObjectsProgressBar.Minimum = 1;
            _readObjectsProgressBar.Maximum = pageCount;
            chunkSize = 50;
         }
         else
         {
            _readObjectsValueLabel.Visible = true;
            _readObjectsProgressBar.Visible = false;
            chunkSize = pageCount;
            Application.DoEvents();
         }

         int pagesLeft = pageCount;

         int firstPageNumber = 1;
         while (pagesLeft > 0 && !_stopReading)
         {
            int toRead = Math.Min(pagesLeft, chunkSize);
            if (toRead > 0)
            {
               if (parseChunks)
               {
                  Application.DoEvents();
               }

               int lastPageNumber = firstPageNumber + toRead - 1;

               try
               {
                  if (parseChunks)
                  {
                     document.ParsePages(parsePagesOptions, firstPageNumber, lastPageNumber);
                  }
                  else
                  {
                     using (WaitCursor wait = new WaitCursor())
                     {
                        document.ParsePages(parsePagesOptions, firstPageNumber, lastPageNumber);
                     }
                  }
               }
               catch (Exception ex)
               {
                  AddError(string.Format("{0} {1} {2} {3}", DemosGlobalization.GetResxString(GetType(), "resx_ReadingPages"), firstPageNumber, DemosGlobalization.GetResxString(GetType(), "resx_To"), lastPageNumber), ex);
               }

               pagesLeft -= toRead;
               firstPageNumber += toRead;

               if (_readObjectsProgressBar.Visible)
               {
                  _readObjectsProgressBar.Value = firstPageNumber - 1;
                  Application.DoEvents();
               }
            }
         }

         if (!parseChunks)
         {
            _readObjectsValueLabel.Text = DemosGlobalization.GetResxString(GetType(), "resx_Finished");
            Application.DoEvents();
         }
      }

      private void AddError(string message, Exception ex)
      {
         if (!_errorsGroupBox.Visible)
         {
            _errorsGroupBox.Visible = true;
         }

         _errorsListBox.TopIndex = _errorsListBox.Items.Add(string.Format("{0}: {1}", message, ex.Message));
      }

      private void _stopButton_Click(object sender, EventArgs e)
      {
         _stopReading = true;
      }

      private void _copyToClipboardButton_Click(object sender, EventArgs e)
      {
         StringBuilder sb = new StringBuilder();
         for (int i = 0; i < _errorsListBox.Items.Count; i++)
         {
            sb.AppendLine(_errorsListBox.Items[i].ToString());
         }

         Clipboard.SetText(sb.ToString(), TextDataFormat.Text);
      }
   }
}

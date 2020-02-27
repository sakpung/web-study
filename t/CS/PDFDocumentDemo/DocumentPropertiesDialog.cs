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

using Leadtools.Pdf;
using Leadtools.Demos;

namespace PDFDocumentDemo
{
   public partial class DocumentPropertiesDialog : Form
   {
      private PDFDocument _document;
      private PDFFile _file;

      public DocumentPropertiesDialog(PDFDocument document, PDFFile file)
      {
         InitializeComponent();

         _document = document;
         _file = file;
      }

      protected override void OnLoad(EventArgs e)
      {
         if (!DesignMode)
         {
            try
            {
               PDFDocumentProperties pdfProperties;

               string yes = DemosGlobalization.GetResxString(GetType(), "resx_Yes");
               if (string.IsNullOrEmpty(yes)) yes = "Yes";
               string no = DemosGlobalization.GetResxString(GetType(), "resx_No");
               if (string.IsNullOrEmpty(no)) no = "No";

               if (_document != null)
               {
                  _fileNameTextBox.Text = _document.FileName;
                  _isEncryptedTextBox.Text = _document.IsEncrypted ? yes : no;
                  _isLinearizedTextBox.Text = _document.IsLinearized ? yes : no;
                  _isPdfATextBox.Text = _document.IsPdfA ? yes : no;
                  _versionTextBox.Text = GetPDFFileTypeName(_document.FileType);
                  _numberOfPagesTextBox.Text = string.Format("{0} {1}", _document.Pages.Count, DemosGlobalization.GetResxString(GetType(), "resx_Pages"));

                  double inchesWidth = _document.Pages[0].WidthInches;
                  double inchesHeight = _document.Pages[0].HeightInches;

                  _pageSizeTextBox.Text = string.Format("{0} {1} {2} {3}", inchesWidth, DemosGlobalization.GetResxString(GetType(), "resx_By"), inchesHeight, DemosGlobalization.GetResxString(GetType(), "resx_Inches"));
                  pdfProperties = _document.DocumentProperties;
               }
               else
               {
                  _fileNameTextBox.Text = _file.FileName;
                  _isEncryptedTextBox.Text = PDFFile.IsEncrypted(_file.FileName) ? yes : no;
                  try
                  {
                     _isLinearizedTextBox.Text = PDFFile.IsLinearized(_file.FileName, null) ? yes : no;
                  }
                  catch
                  {
                     _isLinearizedTextBox.Text = no;
                  }
                  _isPdfATextBox.Text = PDFFile.IsPdfA(_file.FileName) ? yes : no;
                  _versionTextBox.Text = GetPDFFileTypeName(PDFFile.GetPDFFileType(_file.FileName, true));
                  _numberOfPagesTextBox.Text = string.Format("{0} pages", _file.Pages.Count);

                  double inchesWidth = _file.Pages[0].Width;
                  double inchesHeight = _file.Pages[0].Height;

                  _pageSizeTextBox.Text = string.Format("{0} {1} {2} {3}", inchesWidth, DemosGlobalization.GetResxString(GetType(), "resx_By"), inchesHeight, DemosGlobalization.GetResxString(GetType(), "resx_Inches"));
                  pdfProperties = _file.DocumentProperties;
               }

               _documentPropertiesControl.SetDocumentProperties(pdfProperties, true);
            }
            catch (Exception ex)
            {
               Messager.ShowError(this, ex);
            }
         }

         base.OnLoad(e);
      }

      private string GetPDFFileTypeName(PDFFileType fileType)
      {
         switch (fileType)
         {
            case PDFFileType.PDF10: return "PDF 1.0";
            case PDFFileType.PDF11: return "PDF 1.1";
            case PDFFileType.PDF12: return "PDF 1.2";
            case PDFFileType.PDF13: return "PDF 1.3";
            case PDFFileType.PDF14: return "PDF 1.4";
            case PDFFileType.PDF15: return "PDF 1.5";
            case PDFFileType.PDF16: return "PDF 1.6";
            case PDFFileType.PDF17: return "PDF 1.7";
            default: return "Unknown";
         }
      }
   }
}

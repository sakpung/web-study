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

using Leadtools.Pdf;

namespace PDFFileDemo
{
   public partial class FilePropertiesControl : UserControl
   {
      public FilePropertiesControl()
      {
         InitializeComponent();
      }

      public void SetFileProperties(PDFFile document)
      {
         try
         {
            _isEncryptedTextBox.Text = PDFFile.IsEncrypted(document.FileName) ? "Yes" : "No";
         }
         catch
         {
            _isEncryptedTextBox.Text = "No";
         }

         try
         {
            _versionTextBox.Text = GetPDFFileTypeName(PDFFile.GetPDFFileType(document.FileName, true));
         }
         catch
         {
            _versionTextBox.Text = GetPDFFileTypeName(PDFFileType.PDF14);
         }

         _numberOfPagesTextBox.Text = string.Format("{0} pages", document.Pages.Count);

         double inchesWidth = document.Pages[0].Width/72.0;
         double inchesHeight = document.Pages[0].Height/72.0;

         _pageSizeTextBox.Text = string.Format("{0} by {1} inches", inchesWidth, inchesHeight);

         try
         {
            _isLinearizedTextBox.Text = PDFFile.IsLinearized(document.FileName, null) ? "Yes" : "No";
         }
         catch
         {
            _isLinearizedTextBox.Text = "No";
         }
      }

      private static string GetPDFFileTypeName(PDFFileType fileType)
      {
         switch(fileType)
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

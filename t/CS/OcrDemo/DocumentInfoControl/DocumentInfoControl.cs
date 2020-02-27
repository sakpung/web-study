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
using Leadtools.Ocr;

namespace OcrDemo.DocumentInfoControl
{
   public partial class DocumentInfoControl : UserControl
   {
      public DocumentInfoControl()
      {
         InitializeComponent();
      }

      public void RepopulateDocumentInformationControl(IOcrDocument ocrDocument)
      {
         _lvOcrDocumentInfo.Items[0].SubItems[1].Text = (ocrDocument != null) ? ((ocrDocument.IsInMemory) ? "Memory" : "File") : "None";
         _lvOcrDocumentInfo.Items[1].SubItems[1].Text = string.Format("{0}", (ocrDocument != null) ? ocrDocument.Pages.Count : 0);
      }
   }
}

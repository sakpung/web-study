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
   public partial class GetDocumentPropertiesControl : UserControl
   {
      public GetDocumentPropertiesControl()
      {
         InitializeComponent();
      }

      protected override void OnLoad(EventArgs e)
      {
         _fileTypeLabel.Visible = false;
         _fileTypeValueLabel.Visible = false;
         _encryptionLabel.Visible = false;
         _encryptionValueLabel.Visible = false;
         _createDocumentLabel.Visible = false;
         _createDocumentValueLabel.Visible = false;

         base.OnLoad(e);
      }

      private string _fileName;
      private string _password;

      public PDFDocument Run(string fileName)
      {
         PDFDocument document = null;

         _fileName = fileName;

         try
         {
            // - Get the file type, must be PDF
            GetFileType();

            // - Check its encryption
            if (CheckEncryption())
            {
               // Create the PDF document and get its properties
               document = CreateDocument();
            }
         }
         catch (Exception ex)
         {
            Messager.ShowError(this, ex);
         }

         return document;
      }

      private void GetFileType()
      {
         _fileTypeLabel.Visible = true;
         Application.DoEvents();

         using (WaitCursor wait = new WaitCursor())
         {
            PDFFileType fileType = PDFFile.GetPDFFileType(_fileName, true);
            _fileTypeValueLabel.Visible = true;
            _fileTypeValueLabel.Text = DemosGlobalization.GetResxString(GetType(), "resx_Finished");
            Application.DoEvents();
         }
      }

      private bool CheckEncryption()
      {
         _encryptionLabel.Visible = true;
         Application.DoEvents();

         bool success = false;

         using (WaitCursor wait = new WaitCursor())
         {
            bool encrypted = PDFFile.IsEncrypted(_fileName);

            _encryptionValueLabel.Visible = true;
            _encryptionValueLabel.Text = encrypted ? DemosGlobalization.GetResxString(GetType(), "resx_Encrypted") : DemosGlobalization.GetResxString(GetType(), "resx_NotEncrypted");
            Application.DoEvents();

            if (encrypted)
            {
               using (GetPasswordDialog dlg = new GetPasswordDialog())
               {
                  if (dlg.ShowDialog(this) == DialogResult.OK)
                  {
                     success = true;
                     _password = dlg.Password;
                  }
               }
            }
            else
            {
               success = true;
            }
         }

         return success;
      }

      private PDFDocument CreateDocument()
      {
         _createDocumentLabel.Visible = true;
         Application.DoEvents();

         using (WaitCursor wait = new WaitCursor())
         {
            PDFDocument document = new PDFDocument(_fileName, _password);
            if (string.IsNullOrEmpty(document.DocumentProperties.Creator))
               document.DocumentProperties.Creator = "LEADTOOLS PDFWriter";
            if (string.IsNullOrEmpty(document.DocumentProperties.Producer))
               document.DocumentProperties.Producer = "LEAD Technologies, Inc.";

            _createDocumentValueLabel.Visible = true;
            _createDocumentValueLabel.Text = DemosGlobalization.GetResxString(GetType(), "resx_Finished");
            Application.DoEvents();

            return document;
         }
      }
   }
}

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

namespace PDFDocumentDemo
{
   public partial class SignatureValidationStatusDialog : Form
   {
      private PDFSignature _signature;

      public SignatureValidationStatusDialog(PDFSignature signature)
      {
         InitializeComponent();

         if (signature == null)
            return;

         _signature = signature;

         SetCertificationInformation();
      }

      private void SetCertificationInformation()
      {
         string state = PDFSignaturesHelper.GetState(_signature.State);

         _infoLabel.Text = string.Format(_infoLabel.Text, state);
      }

      private void _signatureDetailsButton_Click(object sender, EventArgs e)
      {
         using (DigitalSignaturesDialog signaturesDialog = new DigitalSignaturesDialog(_signature))
            signaturesDialog.ShowDialog();
      }

      private void _closeButton_Click(object sender, EventArgs e)
      {
         this.Close();
      }
   }
}

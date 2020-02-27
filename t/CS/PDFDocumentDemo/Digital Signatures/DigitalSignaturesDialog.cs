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
   public partial class DigitalSignaturesDialog : Form
   {
      private PDFSignature _signature;

      public DigitalSignaturesDialog(PDFSignature signature)
      {
         InitializeComponent();

         _signature = signature;

         InitializeSummaryTab();
         InitializeDetailsTab();
      }

      private void InitializeSummaryTab()
      {
         _signatureValidityStateValueLabel.Text = PDFSignaturesHelper.GetState(_signature.State);

         _signedByValueLabel.Text = PDFSignaturesHelper.GetSignedByString(_signature.CertificateInfo["Subject"]);

         _issuedByValueLabel.Text = PDFSignaturesHelper.GetSignedByString(_signature.CertificateInfo["Issuer"]);

         _validFromValueLabel.Text = _signature.ValidFrom.ToLocalTime().ToString();

         _validToValueLabel.Text = _signature.ValidTo.ToLocalTime().ToString();

         _intededUsageValueLabel.Text = PDFSignaturesHelper.GetKeyUsageString(_signature.KeyUsage);

         _certificationInformationLabel.Text = GetCertificationInformationLabelData();
      }

      private string GetCertificationInformationLabelData()
      {
         string infoText = _certificationInformationLabel.Text;

         string state = PDFSignaturesHelper.GetState(_signature.State);
         string signedBy = PDFSignaturesHelper.GetSignedByString(_signature.CertificateInfo["Subject"]);

         return string.Format(infoText, state, signedBy, state);
      }

      private void InitializeDetailsTab()
      {
         //Fiil DataGridView with the details of the signature
         foreach (KeyValuePair<string, string> entry in _signature.CertificateInfo)
         {
            DataGridViewRow row = CreateGridViewRow(entry.Key, entry.Value);
            _certificateDataGridView.Rows.Add(row);
         }

         _certificateDataGridView.Rows.Add(CreateGridViewRow("Version", _signature.Version.ToString()));
         _certificateDataGridView.Rows.Add(CreateGridViewRow("Valid To", _signature.ValidTo.ToLocalTime().ToString()));
         _certificateDataGridView.Rows.Add(CreateGridViewRow("Valid From", _signature.ValidFrom.ToLocalTime().ToString()));
         _certificateDataGridView.Rows.Add(CreateGridViewRow("KeyUsage", PDFSignaturesHelper.GetKeyUsageString(_signature.KeyUsage)));
      }

      private DataGridViewRow CreateGridViewRow(string name, string value)
      {
         DataGridViewRow row = new DataGridViewRow();
         row.CreateCells(_certificateDataGridView, new object[] { "Name", "Value" });
         row.Cells[0].Value = name;
         row.Cells[1].Value = value;
         return row;
      }

      private void _certificateDataGridView_SelectionChanged(object sender, EventArgs e)
      {
         //Change The information data as the selected row.
         DataGridViewRow row = _certificateDataGridView.SelectedRows[0];

         string descriptionInfo = row.Cells[1].Value.ToString();

         if (row.Cells[0].Value.ToString() == "Issuer" || row.Cells[0].Value.ToString() == "Subject")
         {
            descriptionInfo = PDFSignaturesHelper.GetSubjcetOrIssure(descriptionInfo);
         }
         else if (row.Cells[0].Value.ToString() == "KeyUsage")
         {
            string keyUsageInfo = (string)row.Cells[1].Value;

            keyUsageInfo = keyUsageInfo.Replace(", ", System.Environment.NewLine);

            descriptionInfo = keyUsageInfo;
         }

         _valueDescriptionTextBox.Text = descriptionInfo;
      }

      private void _okButton_Click(object sender, EventArgs e)
      {
         this.Close();
      }
   }
}

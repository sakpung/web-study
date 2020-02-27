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
using System.IO;
using Leadtools.Demos;

namespace DicomDigitalSignatureDemo.UI
{
   public partial class CreateSignature : Form
   {
      public string PrivateKey
      {
         get
         {
            return _txtBx_PrivateKey.Text;
         }
      }
      public string DigitalCertificate
      {
         get
         {
            return _txtBx_DigitalCertificate.Text;
         }
      }
      public string Password
      {
         get
         {
            return _txtBx_Password.Text;
         }
      }
      public string SignedDataSet
      {
         get
         {
            return _txtBox_SignedDataSet.Text;
         }
      }
      public CreateSignature()
      {
         InitializeComponent();

         string certificate = GetFullCertificatePath();

         if (certificate != null)
         {
            _txtBx_DigitalCertificate.Text = certificate;
            _txtBx_PrivateKey.Text = certificate;
            _txtBx_Password.Text = "test";
         }

         checkIfOKEnabled();
      }

      private void _btn_PrivateKey_Click(object sender, EventArgs e)
      {
         OpenFileDialog fileDialog=new OpenFileDialog();
         fileDialog.Filter="All Files (*.*)|*.*";

         if (fileDialog.ShowDialog() == DialogResult.OK)
         {
            this._txtBx_PrivateKey.Text = fileDialog.FileName;
         }
      }

      private void _btn_DigitalCertificate_Click(object sender, EventArgs e)
      {
         OpenFileDialog fileDialog = new OpenFileDialog();
         fileDialog.Filter = "Digital Certificates (*.pem; *.cer; *.crt; *.p7b; *.spc; *.pfx; *.p12)|" +
                              "*.pem; *.cer; *.crt; *.p7b; *.spc; *.pfx; *.p12|" +
                              "All Files (*.*)|*.*";

         if (fileDialog.ShowDialog() == DialogResult.OK)
         {
            this._txtBx_DigitalCertificate.Text = fileDialog.FileName;
         }
      }

      private void _btn_SignedDataSet_Click(object sender, EventArgs e)
      {
         SaveFileDialog fileDialog = new SaveFileDialog();
         fileDialog.Filter = "DCM Files (*.dcm)|*.dcm|All Files (*.*)|*.*";

         if (fileDialog.ShowDialog() == DialogResult.OK)
         {
            this._txtBox_SignedDataSet.Text = fileDialog.FileName;
         }
      }

      private string GetFullCertificatePath()
      {
         string path = Path.GetDirectoryName(Application.ExecutablePath);
         path = Path.Combine(path, "client.pem");
         if (!File.Exists(path))
         {
            path = Path.Combine(DemosGlobal.ImagesFolder, "client.pem");
         }

         if (File.Exists(path))
            return path;
         return null;
      }

      private void _txtBx_PrivateKey_TextChanged(object sender, EventArgs e)
      {
         checkIfOKEnabled();
      }

      private void _txtBx_DigitalCertificate_TextChanged(object sender, EventArgs e)
      {
         checkIfOKEnabled();
      }

      private void _txtBox_SignedDataSet_TextChanged(object sender, EventArgs e)
      {
         checkIfOKEnabled();
      }

      void checkIfOKEnabled() 
      {
         if (_txtBx_PrivateKey.Text == "" || _txtBx_DigitalCertificate.Text == "" || _txtBox_SignedDataSet.Text == "")
            _btn_OK.Enabled = false;
         else
            _btn_OK.Enabled = true;
      }
   }
}

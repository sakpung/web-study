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
using System.Drawing.Drawing2D;

using Leadtools.Demos;
using Leadtools;
using Leadtools.Codecs;
using Leadtools.Dicom;
using Leadtools.ImageProcessing.Color;
using DicomDigitalSignatureDemo.UI;
using Leadtools.DicomDemos;

namespace DicomDigitalSignatureDemo
{
   public partial class MainForm : Form
   {
      CreateSignature m_CreateSignatureDlg;

      public MainForm()
      {
         InitializeComponent();

         // Setup the caption for this demo
         Messager.Caption = "C# Dicom Digital Signature Demo";

         // Create Signature Dialog
         m_CreateSignatureDlg = new CreateSignature();
         DicomEngine.Startup();
      }

      private void _btn_Open_Click(object sender, EventArgs e)
      {
         OpenFileDialog fileDialog = new OpenFileDialog();
         fileDialog.Filter = "DICOM Files (*.dic; *.dcm)|*.dic; *.dcm|All Files (*.*)|*.*";
         if (fileDialog.ShowDialog() == DialogResult.OK)
         {
            this._txBx_DataSet.Text = fileDialog.FileName;
         }
      }

      private void _txBx_DataSet_TextChanged(object sender, EventArgs e)
      {
         if (this._txBx_DataSet.Text == "")
         {
            this._btn_Sign.Enabled = false;
            this._btn_Verify.Enabled = false;
         }
         else
         {
            this._btn_Sign.Enabled = true;
            this._btn_Verify.Enabled = true;
         }
      }

      private void _btn_Sign_Click(object sender, EventArgs e)
      {
         if (Utils.VerifyOpensslVersion(this) == false)
            return;

         if (m_CreateSignatureDlg.ShowDialog() == DialogResult.OK)
         {
            EnableControls(false);

            string sDataSet;
            sDataSet = this._txBx_DataSet.Text;

            try
            {
               DicomDataSet DataSet = new DicomDataSet();

               // Load the Data Set to be signed
               DataSet.Load(sDataSet, DicomDataSetLoadFlags.LoadAndClose);

               WaitCursor waitCursor = new WaitCursor();

               // Create a Digital Signature in the main Data Set
               DataSet.CreateSignature(null,
                                              m_CreateSignatureDlg.PrivateKey,
                                              m_CreateSignatureDlg.DigitalCertificate,
                                              m_CreateSignatureDlg.Password,
                                              null,
                                              0,
                                              null,
                                              0);


               // Save the signed Data Set
               DataSet.Save(m_CreateSignatureDlg.SignedDataSet, DicomDataSetSaveFlags.None);


               MessageBox.Show("The Data Set was signed successfully.", "Demo");
            }
            catch (Exception ex)
            {
               MessageBox.Show(ex.Message, "Sign Failed");
            }
            finally
            {
               EnableControls();
            }
         }
      }

      private void EnableControls(bool bEnable)
      {
         if (bEnable == false)
         {
            this._btn_Verify.Enabled = false;
            this._btn_Open.Enabled = false;
            this._btn_Sign.Enabled = false;
            this._txBx_DataSet.Enabled = false;
         }
         else
         {
            this._btn_Verify.Enabled = (_txBx_DataSet.Text != "");
            this._btn_Sign.Enabled = (_txBx_DataSet.Text != "");
            this._btn_Open.Enabled = true;
            this._txBx_DataSet.Enabled = true;
         }
      }

      private void EnableControls()
      {
         EnableControls(true);
      }

      private void _btn_Verify_Click(object sender, EventArgs e)
      {
         if (Utils.VerifyOpensslVersion(this) == false)
            return;

         EnableControls(false);

         try
         {
            string sDataSet = _txBx_DataSet.Text;

            DicomDataSet DataSet = new DicomDataSet();

            // Load the Data Set
            DataSet.Load(sDataSet, DicomDataSetLoadFlags.LoadAndClose);
            WaitCursor waitCursor = new WaitCursor();

            // Get the Digital Signature Count
            int iCount = DataSet.GetSignaturesCount(null);
            if (iCount < 1)
            {
               MessageBox.Show("There are no digital signatures in this DICOM data set.", "Demo");
            }
            else
            {
               // Verify all the Digital Signatures in the whole Data Set
               bool bRet = DataSet.VerifySignature(null);
               if (bRet == true)
               {
                  string szMsg = string.Format("There are {0} digital signatures, and all were verified", iCount);
                  MessageBox.Show(szMsg, "Demo");
               }
               else
               {
                  string szMsg = string.Format("Failed to verify the Digital Signatures");
                  MessageBox.Show("Failed to verify the Digital Signatures", "Demo");
               }
            }
         }
         catch(Exception ex)
         {
            MessageBox.Show(ex.Message, "Failed");
         }
         finally
         {
            EnableControls();
         }
      }
   }
}

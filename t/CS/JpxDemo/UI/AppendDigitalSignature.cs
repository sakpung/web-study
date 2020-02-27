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

namespace JPXDemo
{
   public partial class AppendDigitalSignature : Form
   {
      public AppendDigitalSignature()
      {
         InitializeComponent();

         InitClass();
      }

      private DigitalSignatureStructure _digitalSignatureData;

      public DigitalSignatureStructure DigitalSignatureData
      {
         get
         {
            return _digitalSignatureData;
         }
         set
         {
            _digitalSignatureData = value;
         }
      }

      private void InitClass()
      {
         _nudLength.Value = 0;

         _nudOffset.Value = 0;

         for (int index = 0; index < 256; index++)
         {
            _cbSignatureType.Items.Add(index.ToString());
         }
         _cbSignatureType.SelectedIndex = 0;

         _cbPointerType.Items.Add("Full");
         _cbPointerType.Items.Add("Partial");
         _cbPointerType.SelectedIndex = 0;

         UpdateControls(false);
      }

      private void UpdateControls(bool enable)
      {
         _grpPointerData.Enabled = enable;

         _lblOffset.Enabled = enable;
         _nudOffset.Enabled = enable;

         _lblLength.Enabled = enable;
         _nudLength.Enabled = enable;
      }

      private void _btnJPEGBrowse_Click(object sender, EventArgs e)
      {
         OpenFileDialog ofd = new OpenFileDialog();

         ofd.Title = "Open a File";
         ofd.Filter = "Jpx Files (*.jpx)|*.jpx";

         if (ofd.ShowDialog() == DialogResult.OK)
         {
            _txtJPEG2000File.Text = ofd.FileName;
         }
      }

      private void _btnSignatureData_Click(object sender, EventArgs e)
      {
         OpenFileDialog ofd = new OpenFileDialog();

         ofd.Title = "Open a File";
         ofd.Filter = "All Files (*.*)|*.*";

         if (ofd.ShowDialog() == DialogResult.OK)
         {
            _txtSignatureDataFile.Text = ofd.FileName;
         }
      }

      private void _cbPointerType_SelectedIndexChanged(object sender, EventArgs e)
      {
         UpdateControls(_cbPointerType.SelectedIndex == 1);
      }

      private void _btnOk_Click(object sender, EventArgs e)
      {
         if (_txtJPEG2000File.Text == "")
         {
            Messager.ShowError(this, "Please select a Jpeg2000 file");
            return;
         }

         if (_txtSignatureDataFile.Text == "")
         {
            Messager.ShowError(this, "Please select a signature data file");
            return;
         }

         DigitalSignatureStructure temp = new DigitalSignatureStructure();
         temp.length = Convert.ToInt32(_nudLength.Value);
         temp.offset = Convert.ToInt32(_nudOffset.Value);
         temp.pointerType = _cbPointerType.SelectedIndex;
         temp.signatureType = Convert.ToUInt32(_cbSignatureType.SelectedIndex);

         //Load Box Data File
         temp.data = File.ReadAllBytes(_txtSignatureDataFile.Text);

         //Get Jpeg 2000 file name
         temp.jPG2FileName = _txtJPEG2000File.Text;

         DigitalSignatureData = temp;

         this.DialogResult = DialogResult.OK;
         this.Close();
      }
   }
}

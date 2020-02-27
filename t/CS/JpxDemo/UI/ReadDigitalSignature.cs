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
using Leadtools.Jpeg2000;
using Leadtools.Demos;
using System.IO;

namespace JPXDemo
{
   public partial class ReadDigitalSignature : Form
   {
      public ReadDigitalSignature(MainForm parentForm)
      {
         InitializeComponent();

         MainParentForm = parentForm;

         InitClass();
      }

      private MainForm _mainParentForm;

      public MainForm MainParentForm
      {
         get
         {
            return _mainParentForm;
         }
         set
         {
            _mainParentForm = value;
         }
      }

      private void InitClass()
      {
         _nudBoxIndex.Value = 0;
      }

      private void _btnJPEG2000Browse_Click(object sender, EventArgs e)
      {
         OpenFileDialog ofd = new OpenFileDialog();

         ofd.Title = "Open a File";
         ofd.Filter = "All Files (*.*)|*.*";

         if (ofd.ShowDialog() == DialogResult.OK)
         {
            _txtJPEG2000.Text = ofd.FileName;
            _btnRead.Enabled = true;
         }
      }

      private void _btnDataFileBrowse_Click(object sender, EventArgs e)
      {
         SaveFileDialog sfd = new SaveFileDialog();

         sfd.Title = "Save a File";
         sfd.Filter = "All Files (*.*)|*.*";

         if (sfd.ShowDialog() == DialogResult.OK)
         {
            _txtDataFile.Text = sfd.FileName;
         }
      }

      private void _btnRead_Click(object sender, EventArgs e)
      {
         int boxIndex;
         Jpeg2000FileInformation fileInfo;
         DigitalSignatureBox _digitalSignatureBox;

         if(_txtJPEG2000.Text == "")
         {
            Messager.ShowError(this, "Please select a JPEG 2000 file");
            return;
         }

         if(_txtDataFile.Text == "")
         {
            Messager.ShowError(this, "Please select a data file");
            return;
         }

         try
         {
            fileInfo = MainParentForm.Jpeg2000Eng.GetFileInformation(_txtJPEG2000.Text);
         }
         catch(Exception ex)
         {
            Messager.ShowError(this, ex);
            return;
         }

         boxIndex = Convert.ToInt32(_nudBoxIndex.Value);
         if (fileInfo.DigitalSignature == null || boxIndex >= fileInfo.DigitalSignature.Length)
         {
            Messager.ShowError(this, string.Format("Box Index should be less than {0}.", (fileInfo.DigitalSignature == null) ? 0 : fileInfo.DigitalSignature.Length));
            return;
         }

         try
         {
             _digitalSignatureBox = (DigitalSignatureBox) MainParentForm.Jpeg2000Eng.ReadBox(_txtJPEG2000.Text, Jpeg2000BoxType.DigitalSignatureBox, boxIndex);
         }
         catch(Exception ex)
         {
            Messager.ShowError(this, ex);
            return;
         }

         if(ReadSGSaveData(_digitalSignatureBox.Data))
         {
            _txtSignatureType.Text = _digitalSignatureBox.SignatureType.ToString();
            _txtPointerType.Text = _digitalSignatureBox.PointerType.ToString();
            _txtOffset.Text = _digitalSignatureBox.Offset.ToString();
            _txtLength.Text = _digitalSignatureBox.Length.ToString();
         }

         Messager.ShowInformation(this, "Read succeeded");
      }

      private bool ReadSGSaveData(byte[] data)
      {
         if(data == null)
            return true;
         try
         {
            FileStream _readFile = File.Open(_txtDataFile.Text, FileMode.Create);
            _readFile.Write(data, 0, data.Length);
            _readFile.Close();
         }
         catch (Exception ex)
         {
            Messager.ShowError(this, ex);
            return false;
         }

         return true;
      }
   }
}

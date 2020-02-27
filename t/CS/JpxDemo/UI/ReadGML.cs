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

namespace JPXDemo
{
   public partial class ReadGML : Form
   {
      public ReadGML(MainForm mainParentForm)
      {
         InitializeComponent();

         _mainParentForm = mainParentForm;

         InitClass();
      }

      private void InitClass()
      {
         _btnRead.Enabled = false;
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

      private void _btnRead_Click(object sender, EventArgs e)
      {
         GmlData _gmlData;

         if(_txtJPEG2000.Text == "")
         {
            Messager.ShowError(this, "Please select a file!");
            return;
         }

         try
         {
            _gmlData = MainParentForm.Jpeg2000Eng.ReadGmlData(_txtJPEG2000.Text);
         }
         catch (Exception ex)
         {
            Messager.ShowError(this, ex);
            return;
         }

         string message;
         if(_gmlData.Data.Count > 0)
            message = string.Format("This file has GML data for {0} codestreams", _gmlData.Data.Count);
         else
            message = "This file has no GML data";

         Messager.ShowInformation(this, message);

         this.DialogResult = DialogResult.OK;
         this.Close();
      }
   }
}

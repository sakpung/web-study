// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Leadtools.Demos;

namespace FormsDemo
{
   public partial class MasterFormList : Form
   {
      private string _workingDir;
      private string _selectedFormSet;
      private bool _isICRSupported;

      public MasterFormList(string workingDir, bool isICRSupported)
      {
         InitializeComponent();
         _workingDir = workingDir;
         _isICRSupported = isICRSupported;
      }

      private void _btnOk_Click(object sender, EventArgs e)
      {
         _selectedFormSet = _masterFormList.Items[_masterFormList.SelectedIndex].ToString();
         DialogResult = DialogResult.OK;
      }

      private void _btnCancel_Click(object sender, EventArgs e)
      {
         DialogResult = DialogResult.Cancel;
      }

      private void MasterFormList_Load(object sender, EventArgs e)
      {
         string[] dirs = Directory.GetDirectories(_workingDir);

         foreach (string dir in dirs)
         {
            DirectoryInfo dirInfo = new DirectoryInfo(dir);
            if (!_isICRSupported && dirInfo.Name.Contains("ICR"))
            {
               //Some engines like LEAD do not support ICR so we should not
               //show the ICR MasterFormSet
               continue; 
            }
            else
               _masterFormList.Items.Add(dirInfo.Name);
         }

         if (_masterFormList.Items.Count > 0)
         {
             //Attempt to select the OCR form list as default
             int defaultIndex = _masterFormList.Items.IndexOf("OCR");
             if (defaultIndex != -1)
                 _masterFormList.SelectedIndex = defaultIndex;
         }
      }

      public string SelectedFormSet
      {
         get { return _selectedFormSet; }
      }

      private void _masterFormList_SelectedIndexChanged(object sender, EventArgs e)
      {
         try
         {
            _btnOk.Enabled = _masterFormList.SelectedIndices.Count == 1;
         }
         catch (Exception exp)
         {
            Messager.ShowError(this, exp);
         }
      }

      private void _masterFormList_MouseDoubleClick(object sender, MouseEventArgs e)
      {
         try
         {
            if (_masterFormList.SelectedIndices.Count == 1)
               _btnOk_Click(this, new EventArgs());
         }
         catch (Exception exp)
         {
            Messager.ShowError(this, exp);
         }
      }
   }
}

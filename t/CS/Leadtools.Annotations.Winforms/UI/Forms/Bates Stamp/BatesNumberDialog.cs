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
using Leadtools.Annotations.BatesStamp;

namespace Leadtools.Annotations.WinForms
{
   public partial class BatesNumberDialog : Form
   {
      private AnnBatesNumber _batesNumber = null;
      public AnnBatesNumber BatesNumber
      {
         get
         {
            return _batesNumber;
         }
      }

      public BatesNumberDialog()
      {
         InitializeComponent();

         //Get Default Properties
         AnnBatesNumber batesNumber = new AnnBatesNumber();
         _numericNumberOfDigits.Value = batesNumber.NumberOfDigits;
         _checkBoxAutoIncrement.Checked = batesNumber.AutoIncrement;
         _checkBoxUseAllDigits.Checked = batesNumber.UseAllDigits;
         _numericStartNumber.Value = batesNumber.StartNumber;
      }

      private void _btnOk_Click(object sender, EventArgs e)
      {
         _batesNumber = new AnnBatesNumber();
         _batesNumber.NumberOfDigits = (int)_numericNumberOfDigits.Value;
         _batesNumber.UseAllDigits = _checkBoxUseAllDigits.Checked;
         _batesNumber.StartNumber = (int)_numericStartNumber.Value;
         _batesNumber.AutoIncrement = _checkBoxAutoIncrement.Checked;
         _batesNumber.PrefixText = _txtPrefixText.Text;
         _batesNumber.SuffixText = _txtSuffixText.Text;
      }

      private void _checkBoxAutoIncrement_CheckedChanged(object sender, EventArgs e)
      {
         if (_checkBoxAutoIncrement.Checked)
            _numericStartNumber.Enabled = true;
         else
            _numericStartNumber.Enabled = false;

      }
   }
}

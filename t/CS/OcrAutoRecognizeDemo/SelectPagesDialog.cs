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

namespace OcrAutoRecognizeDemo
{
   public partial class SelectPagesDialog : Form
   {
      public SelectPagesDialog()
      {
         InitializeComponent();
      }

      private int _firstPageNumber;
      public int FirstPageNumber { get { return _firstPageNumber; } set { _firstPageNumber = value; } }
      private int _lastPageNumber;
      public int LastPageNumber { get { return _lastPageNumber; } set { _lastPageNumber = value; } }

      protected override void OnLoad(EventArgs e)
      {
         if(!DesignMode)
         {
            _fromPageTextBox.Text = FirstPageNumber.ToString();
            _toPageTextBox.Text = LastPageNumber.ToString();

            if(FirstPageNumber == 1 && LastPageNumber == -1)
            {
               _allPagesCheckBox.Checked = true;
            }
            else if(LastPageNumber == -1)
            {
               _lastPageCheckBox.Checked = true;
            }

            UpdateMyControls();
         }

         base.OnLoad(e);
      }

      private void UpdateMyControls()
      {
         if(_allPagesCheckBox.Checked)
         {
            _fromPageTextBox.Enabled = false;
            _toPageTextBox.Enabled = false;
            _lastPageCheckBox.Enabled = false;
         }
         else
         {
            _fromPageTextBox.Enabled = true;
            _lastPageCheckBox.Enabled = true;

            if(_lastPageCheckBox.Checked)
            {
               _toPageTextBox.Enabled = false;
            }
            else
            {
               _toPageTextBox.Enabled = true;
            }
         }
      }

      private void _allPagesCheckBox_CheckedChanged(object sender, EventArgs e)
      {
         UpdateMyControls();
      }

      private void _lastPageCheckBox_CheckedChanged(object sender, EventArgs e)
      {
         UpdateMyControls();
      }

      private void _okButton_Click(object sender, EventArgs e)
      {
         if(_allPagesCheckBox.Checked)
         {
            FirstPageNumber = 1;
            LastPageNumber = -1;
         }
         else
         {
            int fromPageNumber;
            if(!int.TryParse(_fromPageTextBox.Text, out fromPageNumber) || fromPageNumber < 1)
            {
               MessageBox.Show(this, "Enter a number greater to or equal to 1 for 'From page'", "Select Pages", MessageBoxButtons.OK, MessageBoxIcon.Information);
               DialogResult = DialogResult.None;
               _fromPageTextBox.SelectAll();
               _fromPageTextBox.Focus();
               return;
            }

            int toPageNumber;
            if(_lastPageCheckBox.Checked)
            {
               toPageNumber = -1;
            }
            else
            {
               if(!int.TryParse(_toPageTextBox.Text, out toPageNumber) || (toPageNumber != -1 && toPageNumber < fromPageNumber))
               {
                  MessageBox.Show(this, "Enter a number greater to or equal to 'From page' or -1 for 'From page'", "Select Pages", MessageBoxButtons.OK, MessageBoxIcon.Information);
                  DialogResult = DialogResult.None;
                  _toPageTextBox.SelectAll();
                  _toPageTextBox.Focus();
                  return;
               }
            }

            FirstPageNumber = fromPageNumber;
            LastPageNumber = toPageNumber;
         }
      }
   }
}

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

namespace SvgDemo
{
   public partial class SelectPage : Form
   {
      int _totalPages;
      int _selectedPage = 1;
      public SelectPage()
      {
         InitializeComponent();
      }

      private void SelectPage_Load(object sender, EventArgs e)
      {
         _pageNumberTextBox.Text = _selectedPage.ToString();
      }

      public int TotalPage
      {
         get { return _totalPages; }
         set { _totalPages = value; }
      }

      public int SelectedPageNumber
      {
         get { return _selectedPage; }
         set { _selectedPage = value; }
      }

      private void _pageNumberTextBox_TextChanged(object sender, EventArgs e)
      {
         try
         {
            int val = int.Parse(_pageNumberTextBox.Text);
            if (val >= 1 && val <= _totalPages)
               SelectedPageNumber = val;
            else
            {
               _pageNumberTextBox.Text = SelectedPageNumber.ToString();
               MessageBox.Show(string.Format("Please select page betwee 1 and {0}", _totalPages));
            }
         }
         catch { }
      }

      private void _pageNumberTextBox_KeyPress(object sender, KeyPressEventArgs e)
      {
         if (!e.Handled)
         {
            if (!Char.IsControl(e.KeyChar) && !Char.IsDigit(e.KeyChar))
               e.Handled = true;
         }
      }
   }
}

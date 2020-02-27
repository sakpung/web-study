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

namespace RasterizeDocumentDemo.Viewer
{
   public partial class GotoPageDialog : Form
   {
      private int _page;
      private int _pageCount;

      public GotoPageDialog(int page, int pageCount)
      {
         InitializeComponent();

         if(!DesignMode)
         {
            _page = page;
            _pageCount = pageCount;

            _pageTextBox.Text = _page.ToString();
            _pagesLabel.Text = string.Format("of {0}", _pageCount);
         }
      }

      public int Page
      {
         get { return _page; }
      }

      private void _okButton_Click(object sender, EventArgs e)
      {
         bool valid = true;
         string errorMessage = null;

         int page = _page;

         if(string.IsNullOrEmpty(_pageTextBox.Text))
         {
            errorMessage = "Please enter a value for the new page";
            valid = false;
         }

         if(valid && !int.TryParse(_pageTextBox.Text, out page))
         {
            errorMessage = string.Format("'{0}' is not a valid value for a page number", _pageTextBox.Text);
            valid = false;
         }

         if(valid && page < 1 || page > _pageCount)
         {
            errorMessage = string.Format("Page must be a number between 1 and {0}", _pageCount);
            valid = false;
         }

         if(valid)
         {
            _page = page;
         }
         else
         {
            MessageBox.Show(this, errorMessage, Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            _pageTextBox.Focus();
            DialogResult = DialogResult.None;
         }
      }
   }
}

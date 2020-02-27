// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PDFFormsDemo
{
   public partial class GoToPageDailog : Form
   {
      private int _pagesCount;
      public GoToPageDailog(int currentPageIndex, int pagesCount)
      {
         InitializeComponent();

         _pagesCount = pagesCount;
         _pageNumberTextBox.Text = (currentPageIndex + 1).ToString();

         _pagesCountLabel.Text = pagesCount.ToString();
      }

      private void _okButton_Click(object sender, EventArgs e)
      {
         int pageNumber = 0;
         int.TryParse(_pageNumberTextBox.Text, out pageNumber);

         if (pageNumber > 0 && pageNumber <= _pagesCount)
            PageNumber = pageNumber;
         else
         {
            MessageBox.Show("Please insert valid page number");
            return;
         }

         this.DialogResult = DialogResult.OK;

         this.Close();
      }

      private void _cancelButton_Click(object sender, EventArgs e)
      {
         this.DialogResult = DialogResult.Cancel;

         this.Close();
      }

      public int PageNumber { get; set; }
   }
}

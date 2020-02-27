// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using Leadtools.Demos;

namespace RasterizeDocumentDemo.UserControls
{
   public partial class DocumentPagesControl : UserControl
   {
      public DocumentPagesControl()
      {
         InitializeComponent();
      }

      private int _totalPages;

      [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
      public int TotalPages
      {
         get { return _totalPages; }
         set { _totalPages = value; }
      }

      private int _firstPageNumber;

      [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
      public int FirstPageNumber
      {
         get { return _firstPageNumber; }
         set { _firstPageNumber = value; }
      }

      private int _lastPageNumber;

      [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
      public int LastPageNumber
      {
         get { return _lastPageNumber; }
         set { _lastPageNumber = value; }
      }

      /// <summary>
      /// Called by the owner to initialize
      /// </summary>
      public void SetData()
      {
         _pagesGroupBox.Text = string.Format("This document contains {0} total &pages.  Select the pages you want to load:", _totalPages);

         if(_firstPageNumber == 1 && _lastPageNumber == -1)
         {
            _firstPageNumberTextBox.Text = "1";
            _lastPageNumberTextBox.Text = _totalPages.ToString();
            _loadAllPagesCheckBox.Checked = true;
         }
         else
         {
            _firstPageNumberTextBox.Text = _firstPageNumber.ToString();
            _lastPageNumberTextBox.Text = _lastPageNumber.ToString();
            _loadAllPagesCheckBox.Checked = false;
         }
      }

      /// <summary>
      /// Called by the owner to get the data
      /// </summary>
      public bool GetData()
      {
         bool ret = true;

         if(_loadAllPagesCheckBox.Checked)
         {
            _firstPageNumber = 1;
            _lastPageNumber = -1;
         }
         else
         {
            int firstPageNumber;
            ret = GetPageNumber(_firstPageNumberTextBox, "First page number", 1, _totalPages, out firstPageNumber);

            if(ret)
            {
               int lastPageNumber;
               ret = GetPageNumber(_lastPageNumberTextBox, "Last page number", firstPageNumber, _totalPages, out lastPageNumber);
               if(ret)
               {
                  _firstPageNumber = firstPageNumber;
                  _lastPageNumber = lastPageNumber;
               }
            }
         }

         return ret;
      }

      private void _loadAllPagesCheckBox_CheckedChanged(object sender, EventArgs e)
      {
         if(_loadAllPagesCheckBox.Checked)
         {
            _firstPageNumberTextBox.Text = "1";
            _lastPageNumberTextBox.Text = _totalPages.ToString();

            _firstPageNumberTextBox.Enabled = false;
            _lastPageNumberTextBox.Enabled = false;
         }
         else
         {
            if(_lastPageNumber == -1)
            {
               _lastPageNumber = _totalPages;
            }

            _firstPageNumberTextBox.Text = _firstPageNumber.ToString();
            _lastPageNumberTextBox.Text = _lastPageNumber.ToString();

            _firstPageNumberTextBox.Enabled = true;
            _lastPageNumberTextBox.Enabled = true;
         }
      }

      private bool GetPageNumber(TextBox pageNumberTextBox, string name, int minimumNumber, int maximumNumber, out int pageNumber)
      {
         if(!int.TryParse(pageNumberTextBox.Text, out pageNumber))
         {
            Messager.ShowError(
               this,
               string.Format("{0} must be an integer between {1} and {2}", name, minimumNumber, maximumNumber));
            pageNumberTextBox.Focus();
            return false;
         }

         if(pageNumber < minimumNumber || pageNumber > maximumNumber)
         {
            Messager.ShowError(
               this,
               string.Format("{0} must be an integer between {1} and {2}", name, minimumNumber, maximumNumber));
            pageNumberTextBox.Focus();
            return false;
         }

         return true;
      }
   }
}

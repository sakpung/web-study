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

namespace RasterizeDocumentDemo
{
   public partial class LoadPagesDialog : Form
   {
      public LoadPagesDialog()
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

      protected override void OnLoad(EventArgs e)
      {
         if(!DesignMode)
         {
            _documentPagesControl.TotalPages = _totalPages;
            _documentPagesControl.FirstPageNumber = _firstPageNumber;
            _documentPagesControl.LastPageNumber = _lastPageNumber;
            _documentPagesControl.SetData();
         }

         base.OnLoad(e);
      }

      private void _okButton_Click(object sender, EventArgs e)
      {
         if(_documentPagesControl.GetData())
         {
            _totalPages = _documentPagesControl.TotalPages;
            _firstPageNumber = _documentPagesControl.FirstPageNumber;
            _lastPageNumber = _documentPagesControl.LastPageNumber;
         }
         else
         {
            DialogResult = DialogResult.None;
         }
      }
   }
}

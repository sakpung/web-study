// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Windows.Forms;

using Leadtools.Svg;

namespace SvgDemo
{
   public partial class DocumentInfo : Form
   {
      private SvgDocument _document;
      private string _fileName;
      private int _pageNumber;
      private int _totalPages;

      public DocumentInfo(SvgDocument document, string fileName, int pageIndex, int totalPages)
      {
         InitializeComponent();
         _document = document;
         _fileName = fileName;
         _pageNumber = pageIndex + 1;
         _totalPages = totalPages;
      }

      private void DocumentInfo_Load(object sender, EventArgs e)
      {
         for (int i = 0; i < _documentInfo.Items.Count; i++)
            _documentInfo.Items[i].SubItems.Add(string.Empty);

         _documentInfo.Items[0].SubItems[1].Text = _fileName;
         _documentInfo.Items[1].SubItems[1].Text = _pageNumber.ToString();
         _documentInfo.Items[2].SubItems[1].Text = _totalPages.ToString();
         _documentInfo.Items[3].SubItems[1].Text = _document.IsFlat.ToString();
         _documentInfo.Items[4].SubItems[1].Text = _document.IsRenderOptimized.ToString();
         var bounds = _document.Bounds;
         _documentInfo.Items[7].SubItems[1].Text = bounds.IsValid.ToString();
         _documentInfo.Items[8].SubItems[1].Text = bounds.IsTrimmed.ToString();
         _documentInfo.Items[9].SubItems[1].Text = bounds.Resolution.ToString();
         _documentInfo.Items[10].SubItems[1].Text = bounds.Bounds.ToString();
      }

      private void _closeButton_Click(object sender, EventArgs e)
      {
         Close();
      }
   }
}

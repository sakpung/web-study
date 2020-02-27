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

namespace OcrDemo.PageTextControl
{
   public partial class PageTextControl : UserControl
   {
      public PageTextControl()
      {
         InitializeComponent();
      }

      public void SetPageText(string pageText)
      {
         _tbPageText.Text = pageText;
      }
   }
}

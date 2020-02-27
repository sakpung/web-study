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

namespace PrintToPACSDemo.UI
{
   public partial class FrmOperation : Form
   {
      public event EventHandler Cancel;
      string _strCaption = "";
      public string Caption
      {
         get { return _strCaption; }
         set { _strCaption = value; }
      }

      string _strBtnCaption = "";
      public string ButtontCaption
      {
         get { return _strBtnCaption; }
         set { _strBtnCaption = value; }
      }

      private FrmOperation()
      {
         InitializeComponent();
      }

      public FrmOperation(string strCaption, string strBtnCaption)
      {
         InitializeComponent();
         _strBtnCaption = strBtnCaption;
         _strCaption = strCaption;
         _lblCaption.Text = strCaption;
         _btnCancelOperation.Text = strBtnCaption;

         if (strBtnCaption == "")
            _btnCancelOperation.Visible = false;
      }

      private void _btnCancelOperation_Click(object sender, EventArgs e)
      {
         if (Cancel != null)
            Cancel(null, null);
      }

   }
}

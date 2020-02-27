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

namespace CSMasterFormsEditor.UI
{
   public partial class FieldNameDlg : Form
   {
      public FieldNameDlg()
      {
         InitializeComponent();
      }

      public FieldNameDlg(string fieldName)
      {
         InitializeComponent();
         this._txtBox_FieldName.Text = fieldName;
      }

      public string TextFieldName
      {
         get
         {
            return this._txtBox_FieldName.Text;
         }
      }
      private void _btn_ok_Click(object sender, EventArgs e)
      {
         if (_txtBox_FieldName.Text == "")
            MessageBox.Show("FieldName Should Not Be Empty");
         else
            this.DialogResult = DialogResult.OK;
      }
   }
}

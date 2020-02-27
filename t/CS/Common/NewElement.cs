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
using Leadtools.Demos;

namespace FormsDemo
{
   public partial class NewElement : Form
   {
      string[] _invalidValues;

      public NewElement(string title, string nameLabelText, string [] invalidValues)
      {
         InitializeComponent();
         _txtName.Text = "";
         this.Text = title;
         _lblName.Text = nameLabelText;
         _invalidValues = invalidValues;
      }

      private void _btnOk_Click(object sender, EventArgs e)
      {
         if (String.IsNullOrEmpty(_txtName.Text))
         {
             MessageBox.Show(DemosGlobalization.GetResxString(GetType(), "Resx_ValidValue"), DemosGlobalization.GetResxString(GetType(), "Resx_Error"));
            return;
         }

         foreach (string invalidName in _invalidValues)
         {
            if (invalidName.ToUpper() == _txtName.Text.Trim().ToUpper())
            {
                MessageBox.Show(DemosGlobalization.GetResxString(GetType(), "Resx_AlreadyExist"), DemosGlobalization.GetResxString(GetType(), "Resx_Error"));
               return;
            }
         }
         
         this.DialogResult = DialogResult.OK;
      }

      private void _btnCancel_Click(object sender, EventArgs e)
      {
         this.DialogResult = DialogResult.Cancel;
      }

      public string ElementName
      {
         get { return _txtName.Text; }
         set { _txtName.Text = value; }
      }
   }
}

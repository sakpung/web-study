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

namespace AnnotationsRolesDemo
{
   public partial class AddForm : Form
   {
      public string Value
      {
         get
         {
            return _txtValue.Text;
         }
      }
      public AddForm(AddType type)
      {
         InitializeComponent();
         if (type == AddType.Group)
         {
            label1.Text = "Group Name";
            Text = "Add Group";
         }
         else
         {
            label1.Text = "User Name";
            Text = "Add User";
         }
      }
      public AddForm()
      {
         InitializeComponent();
      }

      private void _btnOk_Click(object sender, EventArgs e)
      {
         if (!string.IsNullOrEmpty(_txtValue.Text))
            DialogResult = DialogResult.OK;
      }
   }

   public enum AddType
   {
      Group,
      User,
   }
}

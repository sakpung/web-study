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

namespace PDFFileDemo
{
   public partial class GetPasswordDialog : Form
   {
      private string _password;
      public string Password
      {
         get { return _password; }
      }

      public GetPasswordDialog()
      {
         InitializeComponent();
      }

      private void _showCharactersCheckBox_CheckedChanged(object sender, EventArgs e)
      {
         if(_showCharactersCheckBox.Checked)
         {
            _passwordTextBox.PasswordChar = (char)0;
         }
         else
         {
            _passwordTextBox.PasswordChar = '*';
         }
      }

      private void _okButton_Click(object sender, EventArgs e)
      {
         _password = _passwordTextBox.Text;
      }
   }
}

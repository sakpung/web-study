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
using System.Security;

namespace DicomDemo.Authentication
{
   public partial class LoginDialog : Form
   {
      public event EventHandler<AuthenticateUserEventArgs> AuthenticateUser = delegate { };      

      public string Username 
      {
         get
         {
            return textBoxUserName.Text;
         }
      }

      public LoginDialog()
      {
         InitializeComponent();
      }

      private void buttonLogin_Click(object sender, EventArgs e)
      {
         AuthenticateUserEventArgs ea = new AuthenticateUserEventArgs(textBoxUserName.Text, textBoxPassword.Text.ToSecureString());

         AuthenticateUser(this, ea);
         if (ea.Cancel)
            DialogResult = DialogResult.Cancel;
         if (ea.InvalidCredentials)
         {
            DialogResult = DialogResult.None;
            textBoxPassword.Text = string.Empty;
            textBoxUserName.Focus();
         }
      }

      private void Credentials_Changed(object sender, EventArgs e)
      {
         buttonLogin.Enabled = textBoxUserName.Text.Length > 0 && textBoxPassword.Text.Length > 0;
      }
   }
}

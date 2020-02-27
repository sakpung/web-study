// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Security ;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DicomDemo.Authentication
{
   public partial class PasswordDialog : Form
   {
      public event EventHandler<ValidatePasswordEventArgs> ValidatePassword = delegate { };

      public PasswordDialog()
      {
         InitializeComponent ( ) ;

         OKButton.Click += new EventHandler ( okButton_Click ) ;
      }

      void okButton_Click ( object sender, EventArgs e )
      {
         try
         {
            ValidatePasswordEventArgs ea = new ValidatePasswordEventArgs();

            _password = null;
            ea.Password = passwordTextBox.Text;
            ea.ConfirmPassword = ConfirmPasswordTextBox.Text;
            ValidatePassword(this, ea);

            if (ea.Valid)
            {
               _password = passwordTextBox.Text.ToSecureString();

               passwordTextBox.Text = string.Empty;
               ConfirmPasswordTextBox.Text = string.Empty;
            }
            else
               DialogResult = DialogResult.None;                                  
         }
         catch ( Exception exception ) 
         {
            MessageBox.Show ( this, exception.Message, "Password", MessageBoxButtons.OK, MessageBoxIcon.Error ) ;
         }
      }     
      
      public SecureString Password
      {
         get
         {
            return GetUserPassword ( ) ;
         }
      }      
      
      protected virtual SecureString GetUserPassword ( )
      {
         return _password ;
      }
      
      private SecureString _password ;
   }
}

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

namespace Leadtools.Medical.Winforms
{
   public partial class PasswordDialog : Form
   {
      public PasswordDialog()
      {
         InitializeComponent ( ) ;

         OKButton.Click += new EventHandler ( okButton_Click ) ;
      }

      void okButton_Click ( object sender, EventArgs e )
      {
         try
         {
            _password = null ;
            
            if ( passwordTextBox.Text.Length == 0 )
            {
               DialogResult = DialogResult.None ;
               
               MessageBox.Show ( this, "Password can't be empty.", "Password", MessageBoxButtons.OK, MessageBoxIcon.Error ) ;
            }
            else if ( passwordTextBox.Text != ConfirmPasswordTextBox.Text )
            {
               DialogResult = DialogResult.None ;
               
               MessageBox.Show ( this, "Password and confirm password don't match." , "Password", MessageBoxButtons.OK, MessageBoxIcon.Error ) ;
            }
            else
            {
               _password = UserAccessManager.GetSecureString ( passwordTextBox.Text ) ;
               
               passwordTextBox.Text        = string.Empty ;
               ConfirmPasswordTextBox.Text = string.Empty ;
            }
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

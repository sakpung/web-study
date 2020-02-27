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

namespace Leadtools.Medical.Winforms
{
   public partial class LogInDialog : Form
   {
      public LogInDialog()
      {
         InitializeComponent ( ) ;
         
         okButton.Click += new EventHandler(okButton_Click);
         this.Load += new EventHandler(LogInDialog_Load);
      }

      void okButton_Click(object sender, EventArgs e)
      {
         try
         {
            this.DialogResult = DialogResult.None ;
            
            if ( userNamTextBox.Text.Length == 0 )
            {
               MessageBox.Show ( this, "Enter a user name.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error ) ;
               
               return ;
            }
            else if ( passwordTextBox.Text.Length == 0 )
            {
               MessageBox.Show ( this, "Enter a user password.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error ) ;
               
               return ;
            }
            else if ( !UserAccessManager.AuthenticateUser ( userNamTextBox.Text, UserAccessManager.GetSecureString ( passwordTextBox.Text ) ) )
            {
               MessageBox.Show ( this, "Invalid user name or password.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error ) ;
               
               return ;
            }
            else
            {
               DialogResult = DialogResult.OK ;
            }
         }
         catch ( Exception exception ) 
         {
            MessageBox.Show ( this, exception.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error ) ;
         }
         finally 
         {
            passwordTextBox.Text = string.Empty ;
         }
         
      }
      
      void LogInDialog_Load(object sender, EventArgs e)
      {
         this.Focus ( ) ;
      }
   }
}

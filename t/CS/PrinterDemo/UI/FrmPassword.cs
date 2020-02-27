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

namespace PrinterDemo
{
   public partial class FrmPassword : Form
   {
      #region Constructor...
      public FrmPassword(bool bLock)
      {
         InitializeComponent();
         _bLock = bLock;
      }
      #endregion

      #region Fields...
      private string _password = string.Empty;
      bool _bLock = false;
      #endregion

      #region Properties...
      public string Password
      {
         get
         {
            return _password;
         }
      }
      #endregion

      #region Events...
      private void FrmPassword_FormClosing(object sender, FormClosingEventArgs e)
      {
         try
         {
            _password = _txtBoxPassword.Text;
         }
         catch (Exception Ex)
         {
            MessageBox.Show(Ex.ToString(), "LEADTOOLS Printer Demo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
         }
      }
      #endregion

      private void FrmPassword_Load(object sender, EventArgs e)
      {
         try
         {
            string formTitle = string.Empty;

            if (_bLock)
            {
               formTitle = "Lock Printer";
            }
            else
            {
               formTitle="Unlock Printer";
            }
            this.Text = formTitle;
         }
         catch (Exception Ex)
         {
            MessageBox.Show(Ex.ToString(), "LEADTOOLS Printer Demo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
         } 
      }

   }
}

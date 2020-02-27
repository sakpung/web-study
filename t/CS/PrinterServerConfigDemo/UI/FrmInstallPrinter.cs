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
using Leadtools;

namespace PrinterDemo
{
   public partial class FrmInstallPrinter : Form
   {
      #region Constructor...
      public FrmInstallPrinter()
      {
         InitializeComponent();
      }
      #endregion

      #region Fields...
      string _printerName = string.Empty;
      bool _enableNetwork = false;
      #endregion

      #region Properties...
      public string PrinterName
      {
         get
         {
            return _printerName;
         }
      }

      public bool EnableNetwork
      {
         get
         {
            return _enableNetwork;
         }
      }
      #endregion

      #region Events...
      private void FrmInstallPrinter_Load(object sender, EventArgs e)
      {
         try
         {
            EnableControls();
         }
         catch (Exception Ex)
         {
            MessageBox.Show(Ex.ToString(), "LEADTOOLS Printer Demo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
         }
      }

      private void FrmInstallPrinter_FormClosing(object sender, FormClosingEventArgs e)
      {
         try
         {
            _printerName = _txtBoxPrinterName.Text;
            _enableNetwork = _ckEnableNetwork.Checked;
         }
         catch (Exception Ex)
         {
            MessageBox.Show(Ex.ToString(), "LEADTOOLS Printer Demo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
         }
      }

      private void _txtBoxPrinterName_TextChanged(object sender, EventArgs e)
      {
         try
         {
            EnableControls();
         }
         catch (Exception Ex)
         {
            MessageBox.Show(Ex.ToString(), "LEADTOOLS Printer Demo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
         }
      }
      #endregion

      #region Methods...
      private void EnableControls()
      {
         try
         {
            bool bEnable = (_txtBoxPrinterName.Text != string.Empty);
            _btnOk.Enabled = bEnable;

            if(RasterSupport.IsLocked(RasterSupportType.PrintDriverServer)) //Network Key
               _ckEnableNetwork.Enabled = false;
         }
         catch (Exception Ex)
         {
            MessageBox.Show(Ex.ToString(), "LEADTOOLS Printer Demo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
         }
      }
      #endregion
   }
}

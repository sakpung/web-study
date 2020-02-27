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
   public partial class FrmUninstallPrinter : Form
   {
      #region Constructor...
      public FrmUninstallPrinter()
      {
         InitializeComponent();
      }
      #endregion

      #region Fields...
      string _printerName = string.Empty;
      #endregion

      #region Properties...
      public string PrinterName
      {
         get
         {
            return _printerName;
         }
      }
      #endregion

      #region Events...
      private void FrmUninstallPrinter_Load(object sender, EventArgs e)
      {
         try
         {
            FillLeadtoolsPrintersList();
            EnableControls();
         }
         catch (Exception Ex)
         {
            MessageBox.Show(Ex.ToString(), "LEADTOOLS Printer Demo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
         }
      }

      private void FrmUninstallPrinter_FormClosing(object sender, FormClosingEventArgs e)
      {
         try
         {
            _printerName = _cmbPrintersList.Text;
         }
         catch (Exception Ex)
         {
            MessageBox.Show(Ex.ToString(), "LEADTOOLS Printer Demo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
         }
      }
      #endregion

      #region Methods...
      private void FillLeadtoolsPrintersList()
      {
         try
         {
            _cmbPrintersList.Items.Clear();
            _cmbPrintersList.Items.AddRange(PrintingUtilities.GetLeadtoolsPrintersList());
            _cmbPrintersList.SelectedIndex = 0;
            EnableControls();
         }
         catch (Exception Ex)
         {
            MessageBox.Show(Ex.ToString(), "LEADTOOLS Printer Demo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
         }
      }

      private void EnableControls()
      {
         try
         {
            bool bEnable = (_cmbPrintersList.Items.Count>0);
            _btnOk.Enabled = bEnable;
         }
         catch (Exception Ex)
         {
            MessageBox.Show(Ex.ToString(), "LEADTOOLS Printer Demo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
         }
      }
      #endregion
   }
}

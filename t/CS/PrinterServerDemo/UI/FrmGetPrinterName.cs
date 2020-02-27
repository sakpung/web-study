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
using Leadtools.Printer;

namespace ServerPrinterDemo
{
   public partial class FrmGetPrinterName : Form
   {
      #region Constructor...
      public FrmGetPrinterName()
      {
         InitializeComponent();
      }

      public FrmGetPrinterName(string activePrinter)
      {
         InitializeComponent();
         _printerName = activePrinter;
      }
      #endregion

      #region Fields...
      PrintingUtilities _printingUtilities = new PrintingUtilities();
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
      private void FrmGetPrinterName_Load(object sender, EventArgs e)
      {
         try
         {
            _cmbPrintersList.Items.Clear();
            FillLeadtoolsPrintersList();
            EnableControls();
         }
         catch (Exception Ex)
         {
            MessageBox.Show(Ex.ToString(), "LEADTOOLS Printer Demo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
         }
      }

      private void FrmGetPrinterName_FormClosed(object sender, FormClosedEventArgs e)
      {
         try
         {
            if (_cmbPrintersList.Items.Count > 0)
            {
               _printerName = _cmbPrintersList.Text;
            }
         }
         catch (Exception Ex)
         {
            MessageBox.Show(Ex.ToString(), "LEADTOOLS Printer Demo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
         }
      }
      #endregion

      #region Methods...
      private static bool Is64Bit()
      {
         return IntPtr.Size == 8;
      }

      private void FillLeadtoolsPrintersList()
      {
         string setupPrinter = string.Empty;

#if LTV20_CONFIG
         if(Is64Bit())
            setupPrinter = "LEADTOOLS 20 .NET Network Printer 64-bit";
         else
            setupPrinter = "LEADTOOLS 20 .NET Network Printer 32-bit";
#endif

         try
         {
             List<string> lstPrinters = new List<string>();
             Printer printer;
             foreach (string str in PrintingUtilities.GetLeadtoolsPrintersList())
             {
                 printer = new Printer(str);
                 if (printer.EnableNetworkPrinting)
                 {
                     lstPrinters.Add(str);
                 }
                 printer.Dispose();
                 printer = null;
             }

            _cmbPrintersList.Items.Clear();
            _cmbPrintersList.Items.AddRange(lstPrinters.ToArray());

            if (_cmbPrintersList.Items.Count > 0)
            {
               if (_printerName != string.Empty)
               {
                  _cmbPrintersList.Text = _printerName;
               }
               else
               {
                  _cmbPrintersList.SelectedIndex = 0;
               }

               if (_printerName == string.Empty)
               {
                  for (int i = 0; i < _cmbPrintersList.Items.Count; i++)
                  {
                     if ((_cmbPrintersList.Items[i] as string).ToLower() == setupPrinter.ToLower())
                        _cmbPrintersList.SelectedIndex = i;
                  }
               }
            }
            else
            {
               string errorMessage = "No printers are available.";
               MessageBox.Show(errorMessage, "LEADTOOLS Printer Demo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
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
            bool bprinterExist = (_cmbPrintersList.Items.Count > 0);
            _btnOk.Enabled = bprinterExist;
            _cmbPrintersList.Enabled = bprinterExist;
         }
         catch (Exception Ex)
         {
            MessageBox.Show(Ex.ToString(), "LEADTOOLS Printer Demo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
         }
      }
      #endregion
   }
}

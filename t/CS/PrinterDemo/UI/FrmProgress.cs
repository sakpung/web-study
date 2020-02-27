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

namespace PrinterDemo
{
   public partial class FrmProgress : Form
   {
      #region Constructor...
      public FrmProgress()
      {
         InitializeComponent();
      }

      public FrmProgress(string printerName, Printer printer)
      {
         InitializeComponent();
         _printer = printer;
         _lblPrinter.Text = "Printer " + printerName + " Is Printing Now";
      }
      #endregion

      #region Fields...
      private Printer _printer;
      private int _jobId;
      #endregion

      #region Events...
      private void _btnCancel_Click(object sender, EventArgs e)
      {
         try
         {
            _printer.CancelPrintedJob(_jobId);
         }
         catch
         {
         }
      }
      #endregion

      #region Methods...
      public void SetProgressState(int pageNo, int jobId)
      {
         try
         {
            _jobId = jobId;
            _lblPage.Text = "Page No: " + pageNo.ToString() + " of job ID " + jobId.ToString();
         }
         catch (Exception Ex)
         {
            MessageBox.Show(Ex.ToString(), "LEADTOOLS Printer Demo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
         }
      }
      #endregion
   }
}

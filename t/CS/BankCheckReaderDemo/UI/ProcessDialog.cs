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
using Leadtools.Forms.Commands;

namespace CSBankCheckReader.UI
{
   public partial class ProcessDialog : Form
   {

      public event EventHandler ProcessFinished;
      bool CancelHit = false;
      BankCheckReader _reader = null;

      public ProcessDialog(BankCheckReader reader)
      {
         InitializeComponent();
         _reader = reader;
         reader.Process += new  EventHandler<ProgressEventArgs>(reader_Processed);
      }

      void reader_Processed(object sender, ProgressEventArgs e)
      {
         this.Invoke(new Action(() => UpdateControls(e)));
         
         e.Cancel = CancelHit;
      }

      private object UpdateControls(ProgressEventArgs e)
      {
         _progressBar.Value = e.Percentage;
         _labelField.Text = e.FieldType.ToString();
         _lableStatus.Text = (e.State==ProcessState.Finish || e.State==ProcessState.Start)? e.State.ToString() : "Processing";
         Application.DoEvents();

         if (e.State == ProcessState.Finish || e.Percentage == 100)
         {
            _reader.Process -= new EventHandler<ProgressEventArgs>(reader_Processed);
            this.Close();
            if (ProcessFinished != null)
               ProcessFinished(this, null);
         }

         return null;
      }

      private void _buttonCancel_Click(object sender, EventArgs e)
      {
         CancelHit = true;
         _buttonCancel.Enabled = false;
         _reader.Cancel();
      }
   }
}

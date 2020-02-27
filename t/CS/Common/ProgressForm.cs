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

namespace Leadtools.Demos
{
   public partial class ProgressForm : Form
   {
      private bool _abort;

      public ProgressForm(string caption, string informationString, int progressMaxValue)
      {
         InitializeComponent();

         _abort = false;
         this.Text = caption;
         _lblInformation.Text = informationString;
         _progress.Maximum = progressMaxValue;
      }

      public int Percent
      {
         get
         {
            return _progress.Value;
         }
         set
         {
            _progress.Value = value;
         }
      }

      public string InformationString
      {
         get
         {
            return _lblInformation.Text;
         }
         set
         {
            _lblInformation.Text = value;
         }
      }

      public string Caption
      {
         get
         {
            return this.Text;
         }
         set
         {
            this.Text = value;
         }
      }

      public bool Abort
      {
         get
         {
            return _abort;
         }
      }

      private void _btnCancel_Click(object sender, EventArgs e)
      {
         _abort = true;
         DialogResult = DialogResult.Abort;

         this.Dispose();
         Application.DoEvents();
      }


   }
}

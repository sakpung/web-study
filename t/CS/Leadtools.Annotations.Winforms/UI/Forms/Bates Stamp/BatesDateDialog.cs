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

using Leadtools.Annotations.BatesStamp;

namespace Leadtools.Annotations.WinForms
{
   public partial class BatesDateDialog : Form
   {
      private AnnBatesDateTime _batesDateTime = null;
      public AnnBatesDateTime BatesDateTime
      {
         get
         {
            return _batesDateTime;
         }
      }

      public BatesDateDialog()
      {
         InitializeComponent();

         //Get Default Properties
         AnnBatesDateTime batesDateTime = new AnnBatesDateTime();
         _comboDateFormat.SelectedIndex = 0;
         _comboDateKind.SelectedIndex = (int)batesDateTime.Kind;
      }

      private void _btnOk_Click(object sender, EventArgs e)
      {
         _batesDateTime = new AnnBatesDateTime();
         _batesDateTime.CurrentDateTime = DateTime.Now;
         _batesDateTime.Format = _comboDateFormat.SelectedItem.ToString();
         _batesDateTime.Kind = (AnnDateTimeKind)_comboDateKind.SelectedIndex;
      }
   }
}

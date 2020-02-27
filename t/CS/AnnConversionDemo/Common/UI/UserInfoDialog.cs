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

namespace AnnConversionDemo
{
   public partial class UserInfoDialog : Form
   {
      private UserInfoDialog()
      {
         InitializeComponent();
      }

      public UserInfoDialog(string description)
      {
         InitializeComponent();
         _labelDescription.Text = description;
      }

   }
}

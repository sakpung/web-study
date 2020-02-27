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

namespace FormsDemo
{
   public partial class FormsInformation : Form
   {
      public FormsInformation()
      {
         InitializeComponent();
      }

      private void _lbllink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
      {
         System.Diagnostics.Process.Start("https://www.leadtools.com/videos/playvideo.asp?id=11");
      }

      private void _btnOK_Click(object sender, EventArgs e)
      {
         this.Close();
      }
   }
}

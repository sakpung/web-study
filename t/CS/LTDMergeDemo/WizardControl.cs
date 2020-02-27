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

namespace LTDMergeDemo
{
   public partial class WizardControl : TabControl
   {
      public WizardControl()
      {
         InitializeComponent();
      }

      protected override void WndProc(ref Message m)
      {
         const int TCM_ADJUSTRECT = 0x1328;
         if(!DesignMode && m.Msg == TCM_ADJUSTRECT)
         {
            m.Result = (IntPtr)1;
         }
         else
         {
            base.WndProc(ref m);
         }
      }
   }
}

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
using System.IO;

namespace PrinterServerISSConfig
{
   public partial class FrmUsage : Form
   {
      public FrmUsage()
      {
         InitializeComponent();
      }

      private void FrmUsage2_Load(object sender, EventArgs e)
      {
         try
         {
            string strRtfFile;
            strRtfFile = Path.GetDirectoryName(Application.ExecutablePath);
            strRtfFile += "\\Troubleshoot.rtf";
            richTextBox1.Rtf = File.ReadAllText(strRtfFile);
         }
         catch { }
      }
   }
}

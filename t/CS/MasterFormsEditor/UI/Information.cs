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
using System.Reflection;
using System.IO;

namespace CSMasterFormsEditor.UI
{
   public partial class InformationDlg : Form
   {
      public InformationDlg()
      {
         InitializeComponent();
      }

      public bool ShouldShow()
      {
         try
         {
            if (Properties.Settings.Default["ShowAgain"] as string == "False")
               return false;
         }
         catch
         {
            return true;
         }

         return true;
      }

      private void Information_Load(object sender, EventArgs e)
      {
         MemoryStream stream = new MemoryStream(CSMasterFormsEditor.Properties.Resources.Info);
         richTextBox1.LoadFile(stream, RichTextBoxStreamType.RichText);
         stream.Close();
         checkBox1.Checked = !ShouldShow();
      }

      private void checkBox1_CheckedChanged(object sender, EventArgs e)
      {
         if (checkBox1.Checked == true)
         {
            Properties.Settings.Default["ShowAgain"] = "False";
         }
         else
         {
            Properties.Settings.Default["ShowAgain"] = "True";
         }
         Properties.Settings.Default.Save(); // Saves settings in application configuration file
      }
   }
}

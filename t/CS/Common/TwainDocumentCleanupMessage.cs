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

namespace Leadtools.Demos
{

   public partial class TwainDocumentCleanupMessage : Form
   {
      public TwainDocumentCleanupMessage()
      {
         InitializeComponent();
      }

      public bool ShouldShow()
      {
         try
         {
            if (Settings.Default["ShowAgain"] as string == "False")
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
         checkBox1.Checked = !ShouldShow();
      }

      private void checkBox1_CheckedChanged(object sender, EventArgs e)
      {
         if (checkBox1.Checked == true)
         {
            Settings.Default["ShowAgain"] = "False";
         }
         else
         {
            Settings.Default["ShowAgain"] = "True";
         }
         Settings.Default.Save(); // Saves settings in application configuration file
      }
   }
}
// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Leadtools.Demos;
using Leadtools;

namespace DicomVideoCaptureDemo
{
   static class Program
   {
      /// <summary>
      /// The main entry point for the application.
      /// </summary>
      [STAThread]
      static void Main()
      {
         if (!Support.SetLicense())
            return;

         if (RasterSupport.IsLocked(RasterSupportType.Medical))
         {
            MessageBox.Show("Medical support must be unlocked for this demo!", "Support Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
         }

         Application.EnableVisualStyles();
         Application.SetCompatibleTextRenderingDefault(false);
         try
         {
            mainForm = new MainForm();
            Application.Run(mainForm);
         }
         catch (System.IO.FileNotFoundException)
         {
            string LTMM_MISSING = string.Format("This demo is designed to run ONLY if you have both a LEADTOOLS Medical toolkit " +
                          "and a LEADTOOLS Multimedia toolkit installed.\n\n" +
                          "In order to run this demo, please download and install the LEADTOOLS Multimedia SDK:\n" +
                          "https://www.leadtools.com/downloads?category=mm");

            if (MessageBox.Show(LTMM_MISSING + "\n\nDo you wish to navigate there now?", "LEADTOOLS Multimedia SDK Missing", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Error) == DialogResult.Yes)
               System.Diagnostics.Process.Start("https://www.leadtools.com/downloads?category=mm");
         }
         
      }

      public static MainForm mainForm=null;
   }
}

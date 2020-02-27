// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Leadtools.Demos;
using Leadtools;

namespace OcrMultiEngineDemo
{
   static class Program
   {
      /// <summary>
      /// The main entry point for the application.
      /// </summary>
      [STAThread]
      static void Main()
      {
         Application.EnableVisualStyles();
         Application.SetCompatibleTextRenderingDefault(false);

         if (!Support.SetLicense())
            return;

         Boolean bOCRLocked = RasterSupport.IsLocked(RasterSupportType.OcrLEAD) & RasterSupport.IsLocked(RasterSupportType.OcrOmniPage);
         if (bOCRLocked)
            MessageBox.Show("OCR support must be unlocked for this demo!", "Support Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);

         Boolean bLocked = RasterSupport.IsLocked(RasterSupportType.Document);
         if (bLocked)
            MessageBox.Show("Document support must be unlocked for this demo!", "Support Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);

         if (bLocked | bOCRLocked)
            return;

         Application.Run(new MainForm());
      }
   }
}

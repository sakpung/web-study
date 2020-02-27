// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Leadtools.Demos;
using Leadtools;

#warning //Todo ****************************************************************************************
#warning //Todo Note: LEADTOOLS Multimedia Toolkit must be installed before this project can be compiled.
#warning //Todo ****************************************************************************************

namespace CreditCardCapture
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

         if (RasterSupport.IsLocked(RasterSupportType.Basic))
         {
            MessageBox.Show("Raster support must be unlocked for this demo!", "Support Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
         }

         Application.EnableVisualStyles();
         Application.SetCompatibleTextRenderingDefault(false);
         Application.Run(new Form1());
      }
   }
}

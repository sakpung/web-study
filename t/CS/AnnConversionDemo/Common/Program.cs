// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

using Leadtools;
using Leadtools.Demos;

namespace AnnConversionDemo
{
   static class Program
   {
      /// <summary>
      /// The main entry point for the application.
      /// </summary>
      [STAThread]
      static void Main()
      {
         // Set license
         if (!Support.SetLicense())
            return;

         if (RasterSupport.IsLocked(RasterSupportType.Document))
         {
            MessageBox.Show(String.Format("{0} Support is locked!", RasterSupportType.Document.ToString()), "Warning");
            return;
         }

         Application.EnableVisualStyles();
         Application.DoEvents();

         Application.Run(new MainForm());
      }
   }
}

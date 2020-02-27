// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Leadtools.Demos;

namespace CSCustomizingWorklistDAL
{
   static class Program
   {
      /// <summary>
      /// The main entry point for the application.
      /// </summary>
      [STAThread]
      static void Main(string[] args)
      {
         if (!Support.SetLicense())
            return;

         if (DemosGlobal.MustRestartElevated())
         {
            DemosGlobal.TryRestartElevated(args);
            return;
         }
         
         Application.EnableVisualStyles();
         Application.SetCompatibleTextRenderingDefault(false);
         
         try
         {
            Leadtools.Dicom.DicomEngine.Startup ( ) ;
            Application.Run(new Form1());
         }
         finally
         {
            Leadtools.Dicom.DicomEngine.Shutdown ( ) ;
         }
      }
   }
}

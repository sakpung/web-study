// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Leadtools.Demos;
using System.Data.Common;

namespace WebViewerConfiguration
{
   static class Program
   {
      /// <summary>
      /// The main entry point for the application.
      /// </summary>
      [STAThread]
      static void Main(string[] args)
      {
         Application.EnableVisualStyles();
         Application.SetCompatibleTextRenderingDefault(false);
         
         if (DemosGlobal.MustRestartElevated())
         {
            DemosGlobal.TryRestartElevated(args);
            return;
         }

#if (LEADTOOLS_V20_OR_LATER)
         if (DemosGlobal.IsDotNet45OrLaterInstalled() == false)
         {
            MessageBox.Show("To run this application, you must first install Microsoft .NET Framework 4.5 or later.",
               "Microsoft .NET Framework 4.5 or later Required",
               MessageBoxButtons.OK,
               MessageBoxIcon.Exclamation);
            return;
         }
#endif

         Messager.Caption = "Medical Web Viewer Configuration" ;
         Application.Run(new Form1());
      }
   }

   partial class WebViewerDataAccess
   {
#if LEADTOOLS_V19_OR_LATER
      public static void SetDefaultOptions()
      {
         OptionsAgent.SaveDefaultOptions(MedicalOptions);
      }
#endif
   }
}

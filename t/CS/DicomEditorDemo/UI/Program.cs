// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Leadtools.Dicom;
using Leadtools.Demos;
using Leadtools;

namespace DicomEditorDemo
{
   static class Program
   {
      /// <summary>
      /// The main entry point for the application.
      /// </summary>
      [STAThread]
      static void Main()
      {
#if LEADTOOLS_V175_OR_LATER
         if (!Support.SetLicense())
            return;
#else
         Support.Unlock(false);
#endif // #if LEADTOOLS_V175_OR_LATER

         if (RasterSupport.IsLocked(RasterSupportType.Medical))
         {
            MessageBox.Show(String.Format("{0} Support is locked!", RasterSupportType.Medical.ToString()), "Warning");
            return;
         }

         DicomEngine.Startup();
         Application.EnableVisualStyles();
         Application.SetCompatibleTextRenderingDefault(false);
         Application.Run(new MainForm());

         DicomEngine.Shutdown();
      }
   }
}

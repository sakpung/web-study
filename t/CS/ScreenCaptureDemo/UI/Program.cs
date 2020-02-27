// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Leadtools.Demos;

namespace ScreenCaptureDemo
{
   static class Program
   {
      /// <summary>
      /// The main entry point for the application.
      /// </summary>
      [STAThread]
      static void Main()
      {
         // unlock support
#if LEADTOOLS_V175_OR_LATER
         if (!Support.SetLicense())
            return;
#else
         Support.Unlock(false);
#endif // #if LEADTOOLS_V175_OR_LATER

         Application.EnableVisualStyles();
         Application.SetCompatibleTextRenderingDefault(false);
         Application.Run(new MainForm());
      }
   }
}

// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CSDicomDirLinqDemo.UI;
using Leadtools.Dicom;
using Leadtools.Demos;
using System.Threading;
using System.Runtime.InteropServices;
using System.Diagnostics;
using Leadtools;

namespace CSDicomDirLinqDemo
{
   public static class Program
   {
      static Program()
      {
         DicomEngine.Startup();
      }

      [DllImport("user32.dll")]
      [return: MarshalAs(UnmanagedType.Bool)]
      static extern bool SetForegroundWindow(IntPtr hWnd);

      /// <summary>
      /// The main entry point for the application.
      /// </summary>
      [STAThread]
      public static void Main()
      {
         bool created = false;
         Mutex m = new Mutex(true, "DicomDirLinqDemo", out created);

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

         if (created)
         {
            Application.ApplicationExit += new EventHandler(Application_ApplicationExit);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());

            GC.KeepAlive(m);
         }
         else
         {
            Process current = Process.GetCurrentProcess();

            foreach (Process process in Process.GetProcessesByName(current.ProcessName))
            {
               if (process.Id != current.Id)
               {
                  SetForegroundWindow(process.MainWindowHandle);
                  break;
               }
            }
         }
      }

      static void Application_ApplicationExit(object sender, EventArgs e)
      {
         DicomEngine.Shutdown();
      }
   }
}

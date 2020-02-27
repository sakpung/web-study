// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Leadtools.Demos;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace OcrScreenCaptureDemo
{
   static class Program
   {
      [DllImport("user32.dll")]
      private static extern
         bool SetForegroundWindow(IntPtr hWnd);
      [DllImport("user32.dll")]
      private static extern
         bool ShowWindowAsync(IntPtr hWnd, int nCmdShow);
      [DllImport("user32.dll")]
      private static extern
         bool IsIconic(IntPtr hWnd);
      /// <summary>
      /// The main entry point for the application.
      /// </summary>
      [STAThread]
      static void Main()
      {
         string proc = Process.GetCurrentProcess().ProcessName;
         Process[] processes = Process.GetProcessesByName(proc);
         if (processes.Length > 1)
         {
            Process p = Process.GetCurrentProcess();
            int n = 0;
            if (processes[0].Id == p.Id)
               n = 1;

            IntPtr hWnd = processes[n].MainWindowHandle;
            if (IsIconic(hWnd))
            {
               ShowWindowAsync(hWnd, 9);
            }
            SetForegroundWindow(hWnd);
            return;
         }

         Application.EnableVisualStyles();
         Application.SetCompatibleTextRenderingDefault(false);

         if (!Support.SetLicense())
            return;

         Application.Run(new MainForm());
      }
   }
}

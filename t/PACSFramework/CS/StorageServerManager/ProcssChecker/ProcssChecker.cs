// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Windows.Forms;
using System.IO;

namespace Leadtools.Demos.StorageServer
{
   static class ProcessChecker
   {
      static string _requiredString;

       internal static class NativeMethods
       {
         [DllImport("user32.dll")]
         public static extern bool ShowWindowAsync(IntPtr hWnd, int nCmdShow);

         [DllImport("user32.dll")]
         public static extern bool SetForegroundWindow(IntPtr hWnd);

         [DllImport("user32.dll")]
         public static extern bool EnumWindows ( EnumWindowsProcDel lpEnumFunc, Int32 lParam ) ;

         [DllImport("user32.dll")]
         public static extern int GetWindowThreadProcessId(IntPtr hWnd,
             ref Int32 lpdwProcessId);

         [DllImport("user32.dll")]
         public static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString,
             Int32 nMaxCount);
         
         [DllImport("user32.dll")]    
         public static extern IntPtr FindWindow( StringBuilder lpClassName, StringBuilder lpWindowName ) ;

         public const int SW_SHOWNORMAL = 1;
      }

      public delegate bool EnumWindowsProcDel ( IntPtr hWnd, Int32 lParam ) ;

      static private bool EnumWindowsProc ( IntPtr hWnd, Int32 lParam )
      {
         int processId = 0;
         NativeMethods.GetWindowThreadProcessId(hWnd, ref processId);

         StringBuilder caption = new StringBuilder(1024);
         NativeMethods.GetWindowText(hWnd, caption, 1024);

         // Use IndexOf to make sure our required string is in the title.
         if (processId == lParam && (caption.ToString().IndexOf(_requiredString,
             StringComparison.OrdinalIgnoreCase) != -1))
         {
             // Restore the window.
             NativeMethods.ShowWindowAsync(hWnd, NativeMethods.SW_SHOWNORMAL);
             NativeMethods.SetForegroundWindow(hWnd);
         }
         return true; // Keep this.
      }


      static public bool IsOnlyProcess ( string forceTitle )
      {
         string exeName = Path.GetFileNameWithoutExtension ( Application.ExecutablePath ) ;
         Process current = Process.GetCurrentProcess ( ) ;
         
         _requiredString = forceTitle ;
         
         foreach ( Process proc in Process.GetProcessesByName ( exeName ).Where( process => process.SessionId == current.SessionId ))
         {
            if ( proc.Id != current.Id )
            {
               NativeMethods.EnumWindows ( new EnumWindowsProcDel( EnumWindowsProc ), proc.Id ) ;
               
               IntPtr windowHandle = NativeMethods.FindWindow ( null, new StringBuilder ( proc.MainWindowTitle ) ) ;
               
               return false ;
            }
         }
         
         return true ;
      }
   }
}

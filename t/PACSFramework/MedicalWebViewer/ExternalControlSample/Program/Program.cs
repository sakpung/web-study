// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Security.Principal;
using Leadtools.Demos;
using System.Diagnostics;

namespace ExternalControlSample
{
   static class Program
   {
      /// <summary>
      /// The main entry point for the application.
      /// </summary>
      [STAThread]
      static int Main(string[] args)
      {
         Application.EnableVisualStyles();
         Application.SetCompatibleTextRenderingDefault(false);

         if (MustRestartElevated())
         {
            TryRestartElevated(args);
            return 0;
         }

         Application.Run(new Form1());
         return 0;
      }

      public static bool NeedUAC()
      {
         OperatingSystem system = Environment.OSVersion;

         if (system.Platform == PlatformID.Win32NT && system.Version.Major >= 6)
            return true;

         return false;
      }

      public static bool IsAdmin()
      {
         WindowsIdentity id = WindowsIdentity.GetCurrent();
         WindowsPrincipal p = new WindowsPrincipal(id);

         return p.IsInRole(WindowsBuiltInRole.Administrator);
      }

      public static bool MustRestartElevated()
      {
         return NeedUAC() && !IsAdmin();
      }

      public static void RestartElevated(string[] args)
      {
         ProcessStartInfo startInfo = new ProcessStartInfo();

         startInfo.UseShellExecute = true;
         startInfo.WorkingDirectory = Environment.CurrentDirectory;
         startInfo.FileName = Application.ExecutablePath;
         startInfo.Verb = "runas";
         startInfo.Arguments = string.Join(" ", args);
         try
         {
            Process p = Process.Start(startInfo);
         }
         catch (System.ComponentModel.Win32Exception)
         {
            return;
         }
      }

      public static void TryRestartElevated(string[] args)
      {
         foreach (string s in args)
         {
            if (string.Compare("/restartElevated", s) == 0)
            {
               string msg = string.Format("{0}: {1}", DemosGlobalization.AdminPrivilege, Process.GetCurrentProcess().ProcessName);
               MessageBox.Show(msg, DemosGlobalization.Warning, MessageBoxButtons.OK, MessageBoxIcon.Warning);
               return;
            }
         }
         string[] argsNew = new string[args.Length + 1];
         Array.Copy(args, argsNew, args.Length);
         argsNew[args.Length] = "/restartElevated";

         RestartElevated(argsNew);
      }
   }
}

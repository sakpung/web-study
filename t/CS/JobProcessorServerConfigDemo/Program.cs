// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Security.Principal;
using System.Windows.Forms;

namespace JobProcessorServerConfigDemo
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

         string command = null;

         if (args.Length > 0)
         {
            command = args[0].ToLower();
         }

         if (command == "/delete")
         {
            string toolkit = string.Empty;
            if (args[1] != null)
            {
               toolkit = args[1].ToLower();
            }

            int ret = DoDelete(toolkit);
            return ret;
         }
         else if (command == null || command == "/restartelevated")
         {
            // No command line arguments, show the UI
            if (!CheckAdminRights(command))
               return 0;

            if (!Globals.Initialize(false, string.Empty))
               return 1;

            // This program requires admin privileges if this is a Windows Vista or 7 machine

            Application.Run(new MainForm());

            return 0;
         }
         else
         {
            return 1;
         }
      }

      private static bool CheckAdminRights(string command)
      {
         bool elevate = false;

         bool needUAC = false;

         // Check if we need UAC to elevate the rights
         OperatingSystem os = Environment.OSVersion;
         if (os.Platform == PlatformID.Win32NT && os.Version.Major >= 6)
            needUAC = true;
         else
            needUAC = false;

         if (needUAC)
         {
            // Check if we are not running in admin mode
            WindowsIdentity wi = WindowsIdentity.GetCurrent();
            WindowsPrincipal wp = new WindowsPrincipal(wi);

            if (!wp.IsInRole(WindowsBuiltInRole.Administrator))
               elevate = true;
         }

         if (elevate)
         {
            if (command != null && command == "/restartelevated")
            {
               string msg = string.Format("This application needs to be run with administrator privileges: {0}", Process.GetCurrentProcess().ProcessName);
               MessageBox.Show(msg, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
               return false;
            }

            // We must restart this application elevated as admin
            ProcessStartInfo startInfo = new ProcessStartInfo();

            startInfo.UseShellExecute = true;
            startInfo.WorkingDirectory = Environment.CurrentDirectory;
            startInfo.FileName = Application.ExecutablePath;
            startInfo.Verb = "runas";
            startInfo.Arguments = "/restartelevated";

            try
            {
               Process p = Process.Start(startInfo);
            }
            catch (Win32Exception)
            {
            }
         }

         return !elevate;
      }

      private static int DoDelete(string toolkit)
      {
         // Setup the globals
         if (!Globals.Initialize(true, toolkit))
            return 1;

         try
         {
            MainForm.DeleteAppPoolAndVirtualDir();
         }
         catch (Exception)
         {
            return 1;
         }

         return 0;
      }
   }
}

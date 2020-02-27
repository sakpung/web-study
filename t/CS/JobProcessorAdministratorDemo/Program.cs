// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Configuration;
using Leadtools.Common.JobProcessor;
using System.Security.Principal;
using System.Diagnostics;
using System.ComponentModel;

namespace JobProcessorAdministratorDemo
{
   static class Program
   {
      static bool _enableUserHost = false;
      /// <summary>
      /// The main entry point for the application.
      /// </summary>
      [STAThread]
      static void Main(string[] args)
      {
         Application.EnableVisualStyles();
         Application.SetCompatibleTextRenderingDefault(false);

         foreach (string command in args)
         {
            if (String.Compare(command, "EnableUserHost", true) == 0)
            {
               _enableUserHost = true;
               break;
            }
         }

         // This application requires admin privileges if this is a Windows Vista or 7 machine
         if (!CheckAdminRights(args))
            return;

         bool userHost = true;
         string address = string.Empty;
         string connectionString = string.Empty;

         Properties.Settings settings = new Properties.Settings();
         if (settings["HostAddress"] != null) address = settings.HostAddress;
         if (settings["UserHost"] != null) userHost = settings.UserHost;
         if (settings["ConnectionString"] != null) connectionString = settings.ConnectionString;

         if (String.IsNullOrEmpty(address))
         {
            address = string.Format("http://{0}:8181/LEADTOOLSJobProcessorServices", Environment.MachineName);
         }

         ConnectionForm connectionForm = new ConnectionForm(userHost, address, connectionString, "LEADTOOLS C# JobProcessor Administrator Demo", false, _enableUserHost);
         connectionForm.Type = ServicesType.JobProcessorJobService;

         if (connectionForm.ShowDialog() == DialogResult.OK)
         {
            if (SqlUtilities.IsDatabaseExist(connectionForm.ConnectionString))
            {
               Application.Run(new MainForm(connectionForm.Address, connectionForm.UserHost, connectionForm.ConnectionString));
            }
            else
            {
               MessageBox.Show("The specified database was not found. Please ensure the database is available.", "Error");
            }
         }
      }

      private static bool CheckAdminRights(string[] commands)
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
            foreach (string command in commands)
            {
               if (String.Compare(command, "restartelevated", true) == 0)
               {
                  string msg = string.Format("This application needs to be run with administrator privileges: {0}", Process.GetCurrentProcess().ProcessName);
                  MessageBox.Show(msg, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                  return false;
               }
            }

            // We must restart this application elevated as admin
            ProcessStartInfo startInfo = new ProcessStartInfo();

            startInfo.UseShellExecute = true;
            startInfo.WorkingDirectory = Environment.CurrentDirectory;
            startInfo.FileName = Application.ExecutablePath;
            startInfo.Verb = "runas";
            startInfo.Arguments = string.Format("{0} {1}", "restartelevated", _enableUserHost ? "EnableUserHost" : string.Empty);

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
   }
}

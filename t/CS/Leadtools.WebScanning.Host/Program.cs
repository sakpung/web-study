// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Security.Principal;
using System.Windows.Forms;
using Leadtools.Demos;
using Leadtools.Services.Twain;
using Microsoft.VisualBasic.ApplicationServices;

namespace Leadtools.WebScanning.Host
{
   static class Program
   {
      /// <summary>
      /// The main entry point for the application.
      /// </summary>
      [STAThread]
      static void Main()
      {
         string[] args = Environment.GetCommandLineArgs();
         // Register\Unregister APP URL
         {
            int argCount = 0;
            if (args != null && args.Length > 0)
            {
               try
               {
                  foreach (string cmd in args)
                  {
                     string command = cmd.StartsWith("/") ? cmd.Substring(1) : cmd;
                     if (command.CompareTo("install") == 0)
                     {
                        // Register service url using netsh to avoid running the app as privileged 
                        // user later (Only needed for installation)
                        DemoUtils.RegisterServiceUrl();
                        // Register Custom app url
                        Utils.RegisterAppUrl("Leadtools.WebScanning.Host");
                        return;
                     }
                     else if (command.CompareTo("uninstall") == 0)
                     {
                        DemoUtils.UnRegisterServiceUrl();
                        Utils.UnregisterAppUrl("Leadtools.WebScanning.Host");
                        return;
                     }
                     argCount++;
                  }
               }
               catch (Exception ex)
               {
                  MessageBox.Show(ex.Message);
                  return;
               }
            }
         }

         if (!Support.SetLicense())
            return;

         SingleInstanceController controller;

         Application.EnableVisualStyles();
         Application.SetCompatibleTextRenderingDefault(false);

         controller = new SingleInstanceController();
         controller.Run(args);
      }

      static private bool IsRunAsAdministrator()
      {
         var wi = WindowsIdentity.GetCurrent();
         var wp = new WindowsPrincipal(wi);

         return wp.IsInRole(WindowsBuiltInRole.Administrator);
      }

      //
      // Allow only one instance of the application to run
      //
      public class SingleInstanceController : WindowsFormsApplicationBase
      {
         public SingleInstanceController()
         {
            IsSingleInstance = true;
            Startup += new StartupEventHandler(SingleInstanceController_Startup);
            StartupNextInstance += this_StartupNextInstance;
         }

         void SingleInstanceController_Startup(object sender, StartupEventArgs e)
         {
            if (RasterSupport.KernelExpired)
               Environment.Exit(0);
         }

         void this_StartupNextInstance(object sender, StartupNextInstanceEventArgs e)
         {
            e.BringToForeground = true;
         }

         protected override void OnCreateMainForm()
         {
            MainForm = new WebScanningForm();
         }
      }
   }
}

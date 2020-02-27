// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Microsoft.VisualBasic.ApplicationServices;
using System.Security.Principal;
using System.Diagnostics;

using Leadtools;
using Leadtools.Demos;
using System.Threading;
using System.IO;
using Leadtools.Demos.StorageServer.DataTypes;
using Leadtools.DicomDemos;

namespace Leadtools.Dicom.Server.Manager
{
    static class Program
    {
      static string[] PacsDatabaseConfigurationDemoNames = { "CSPacsDatabaseConfigurationDemo_Original.exe", "CSPacsDatabaseConfigurationDemo.exe" };

      static public string BaseDir
      {
         get;
         set;
      }
      
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static int Main(string[] args)
        {
#if LEADTOOLS_V19_OR_LATER
            if(!Support.SetLicense())
               return 0;
#else
            Support.SetLicense();
            if (RasterSupport.KernelExpired)
               return 0;
#endif

           Mutex m;
           if (DemosGlobal.MustRestartElevated())
           {
              DemosGlobal.TryRestartElevated(args);
              return 0;
           }
#if !FOR_DOTNET4
           bool dotNet35Installed = DemosGlobal.IsDotNet35Installed();
           if (!dotNet35Installed)
           {
              return 0;
           }
#endif
            
           bool ok;

#if LEADTOOLS_V175_OR_LATER
           m = new Mutex(true, "LEADTOOLS_V175_OR_LATER", out ok);

           if (!ok)
           {
              return 1;
           }
#else
           SingleInstanceController controller;
#endif           
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);



#if LEADTOOLS_V175_OR_LATER
            if (RasterSupport.IsLocked(RasterSupportType.DicomCommunication))
#else
            if (RasterSupport.IsLocked(RasterSupportType.MedicalNet))
#endif
            {
               MessageBox.Show("Support for LEADTOOLS PACS Module is locked!\nServer Manager cannot run!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
               return -1;
            }

#if (LEADTOOLS_V20_OR_LATER)
         if (DemosGlobal.IsDotNet45OrLaterInstalled() == false)
         {
            MessageBox.Show("To run this application, you must first install Microsoft .NET Framework 4.5 or later.",
               "Microsoft .NET Framework 4.5 or later Required",
               MessageBoxButtons.OK,
               MessageBoxIcon.Exclamation);
            return -1;
         }
#endif

         {
            string message = string.Empty;
            string[] productsToCheck = new string[] { DicomDemoSettingsManager.ProductNameStorageServer };
            bool dbConfigured = GlobalPacsUpdater.IsDbComponentsConfigured(productsToCheck, out message);

            if (!dbConfigured &&
                 !RequestUserToConfigureDbSucess(message))
            {
               return -1;
            }

            if (!GlobalPacsUpdater.IsProductDatabaseUpTodate(DicomDemoSettingsManager.ProductNameDemoServer) &&
                 !RequestUserToUpgradeDbSucess())
            {
               return -1;
            }

            if (!ok)
            {
               return -1;
            }
         }


         BaseDir = Path.GetFullPath(GetWorkingDirectory()).ToLower();
            DicomEngine.Startup();
            DicomNet.Startup();
#if !LEADTOOLS_V175_OR_LATER
            controller = new SingleInstanceController();
            controller.Run(Environment.GetCommandLineArgs());
#else

            try
            {
               Application.Run(new MainForm());
            }
            catch (FileNotFoundException ex)
            {
               MessageBox.Show("File not found exception.\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
               MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
#endif
            DicomNet.Shutdown();
            DicomEngine.Shutdown();
#if LEADTOOLS_V175_OR_LATER
            GC.KeepAlive(m);
#endif
            return 0;
        }
        
       static public string GetWorkingDirectory()
      {
         string executableName = Application.ExecutablePath;
         FileInfo executableFileInfo = new FileInfo(executableName);
         return executableFileInfo.DirectoryName.ToLower();
      }


      private static bool RequestUserToConfigureDbSucess(string missingDbComponents)
      {
         string message;
         DialogResult result;
         string Caption = "Warning";

         string pacsDatabaseConfigDemoFileName = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), PacsDatabaseConfigurationDemoNames[0]);

         if (!File.Exists(pacsDatabaseConfigDemoFileName) && PacsDatabaseConfigurationDemoNames.Length > 1)
         {
            pacsDatabaseConfigDemoFileName = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), PacsDatabaseConfigurationDemoNames[1]);
         }

         message = "The following databases are not configured:\n\n{0}\nRun the " +
                   PacsDatabaseConfigurationDemoNames[0] + " to configure the missing databases.\n\n" +
                   "Do you want to run the " + PacsDatabaseConfigurationDemoNames[0] + " wizard now?";

         message = string.Format(message, missingDbComponents);

         result = MessageBox.Show(message,
                                    Caption,
                                    MessageBoxButtons.YesNo,
                                    MessageBoxIcon.Warning);

         if (DialogResult.Yes == result)
         {

            if (File.Exists(pacsDatabaseConfigDemoFileName))
            {
               Process dbConfigProcess;


               dbConfigProcess = new Process();
               dbConfigProcess.StartInfo.FileName = pacsDatabaseConfigDemoFileName;

               dbConfigProcess.Start();

               dbConfigProcess.WaitForExit();

               string[] productsToCheck = new string[] { DicomDemoSettingsManager.ProductNameStorageServer };

               bool isDbConfigured = GlobalPacsUpdater.IsDbComponentsConfigured(productsToCheck, out missingDbComponents);

               if (!isDbConfigured)
               {
                  MessageBox.Show("Database is not configured.",
                                    Caption,
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);


                  return false;

               }
            }
            else
            {
               MessageBox.Show("Could not find the " + PacsDatabaseConfigurationDemoNames[0] + " wizard",
                                 Caption,
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Error);

               return false;
            }
         }
         else
         {
            return false;
         }
         return true;
      }

      private static bool RequestUserToUpgradeDbSucess()
      {
         string message;
         DialogResult result;
         string Caption = "Upgrade Notice";

         message = "The Worklist database needs to be upgraded.\n\n" +
                   "Do you want to upgrade the database now?";

         result = MessageBox.Show(message,
                                    Caption,
                                    MessageBoxButtons.YesNo,
                                    MessageBoxIcon.Warning);

         if (DialogResult.Yes == result)
         {
            GlobalPacsUpdater.UpgradeProductDatabase(DicomDemoSettingsManager.ProductNameDemoServer);

            if (GlobalPacsUpdater.IsProductDatabaseUpTodate(DicomDemoSettingsManager.ProductNameDemoServer))
            {
               MessageBox.Show("Database upgraded successfully",
                                Caption,
                                MessageBoxButtons.OK,
                                 MessageBoxIcon.Information);

               return true;
            }
         }

         return false;

      }
   }


#if !LEADTOOLS_V175_OR_LATER
    public class SingleInstanceController : WindowsFormsApplicationBase
    {
        public SingleInstanceController()
        {
            IsSingleInstance = true;

            StartupNextInstance += new StartupNextInstanceEventHandler(SingleInstanceController_StartupNextInstance);
        }

        void SingleInstanceController_StartupNextInstance(object sender, StartupNextInstanceEventArgs e)
        {
            if (MainForm.WindowState == FormWindowState.Minimized)
            {
                (MainForm as MainForm).ShowFromTaskBar();
            }

            MainForm.Activate();
        }        

        protected override void OnCreateMainForm()
        {
            MainForm = new MainForm();
        }
    }
#endif
}

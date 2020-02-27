// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Leadtools.Demos.StorageServer.UI.AdministrativeSettings.Users;
using Leadtools.Demos.StorageServer.UI.Authentication;
using System.Diagnostics;
using System.Windows.Forms;
using Leadtools.Medical.OptionsDataAccessLayer;
using Leadtools.Medical.DataAccessLayer;
using Leadtools.DicomDemos;
using System.IO;
using System.Reflection;
using System.Drawing;
using Leadtools.Demos.StorageServer.DataTypes;
using Leadtools.Medical.OptionsDataAccessLayer.Configuration;
using System.ServiceProcess;
using Leadtools.Dicom.Server.Admin;
using Leadtools.Medical.Winforms;

namespace Leadtools.Demos.StorageServer
{
   partial class Program
   {
      private static string[] PacsDatabaseConfigurationDemoNames = { "CSPacsDatabaseConfigurationDemo_Original.exe", "CSPacsDatabaseConfigurationDemo.exe" };

      public static void InitializeLicense()
      {
      }

      public static void CheckPacsConfigDemo()
      {
         try
         {
            string demoName = Path.GetFileName(Application.ExecutablePath);
            DicomDemoSettings mySettings = DicomDemoSettingsManager.LoadSettings(demoName);
            if (mySettings == null)
            {
               DicomDemoSettingsManager.RunPacsConfigDemo();
               mySettings = DicomDemoSettingsManager.LoadSettings(demoName);
               if (mySettings == null)
               {
                  Messager.ShowWarning(null, "Since the PACSConfigDemo has not been run, the PACS High Level Demos are not pre-configured.");
               }
            }
         }
         catch (Exception)
         {
         }
      }

      public static bool Login(string info, bool relogin)
      {
         try
         {
            IOptionsDataAccessAgent optionsAgent = DataAccessServices.GetDataAccessService<IOptionsDataAccessAgent>();
            PasswordOptions passwordOptions = optionsAgent.Get<PasswordOptions>("PasswordOptions", new PasswordOptions());

            LoginDialog dlgLogin = new LoginDialog(passwordOptions.LoginType);
            Process process = Process.GetCurrentProcess();
            string lastUser = optionsAgent.Get<string>("LastUser", string.Empty);
            bool lastLoginUseCardReader = optionsAgent.Get<bool>("LastLoginUseCardReader", false);

            dlgLogin.Text = Shell.storageServerName + " Login";
            dlgLogin.Info = info;
            dlgLogin.RegularUsername = lastUser;

            if (passwordOptions.LoginType ==  LoginType.Both)
            {
               dlgLogin.UseCardReaderCheckBox = lastLoginUseCardReader;
            }
            dlgLogin.CanSetUserName = !relogin;
            dlgLogin.AuthenticateUser += new EventHandler<AuthenticateUserEventArgs>(dlgLogin_AuthenticateUser);
            if (dlgLogin.ShowDialog(new WindowWrapper(process.MainWindowHandle)) == DialogResult.OK)
            {
               UserManager.User = new ManagerUser(dlgLogin.GetUserName(), dlgLogin.GetFriendlyName(), UserManager.GetUserPermissions(dlgLogin.GetUserName()));

               optionsAgent.Set<bool>("LastLoginUseCardReader", dlgLogin.UseCardReaderCheckBox);

               LoadSplash();
               return true;
            }
            return false;
         }
         catch (Exception ex)
         {
            Messager.ShowError(null, ex);
            return false;
         }
      }

      private static void LoadSplash()
      {
         Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("Leadtools.Demos.StorageServer.Resources.splash-screen.jpg");

         if (stream != null)
         {
            SplashForm.SplashBitmap = new Bitmap(stream);
         }
      }

      public static bool ShouldHideUserDetails()
      {
         return false;
      }

      private static void StopDicomServices(string baseDirectory)
      {
         foreach (ServiceController scService in ServiceController.GetServices())
         {
            DicomServiceController service = new DicomServiceController(scService);

            if (service != null && service.PathName.ToLower().Contains(Path.Combine(baseDirectory.ToLower(), "leadtools.dicom.server.exe")))
            {
               try
               {
                  if (service.Status != ServiceControllerStatus.Stopped)
                  {
                     service.Stop();
                     service.WaitForStatus(ServiceControllerStatus.Stopped, TimeSpan.FromSeconds(1));
                     if (service.Status != ServiceControllerStatus.Stopped)
                     {
                        service.Stop();
                     }
                  }                  
               }
               catch (Exception ex)
               {
                  Debug.Assert(false,ex.Message);
               }
               finally
               {
//                  si.UnInstallService(service.ServiceName);
               }
            }
         }
      }

      public static void StopDicomServices()
      {
         StopDicomServices(Application.StartupPath);
      }

      private static bool UpgradeConfigFiles()
      {
#if (LEADTOOLS_V19_OR_LATER_MEDICAL_EXTERNAL_STORE) || (LEADTOOLS_V19_OR_LATER)
         string exeName = Path.GetFileNameWithoutExtension(Application.ExecutablePath);
         string globalPacsConfigPath = DicomDemoSettingsManager.GlobalPacsConfigFullFileName;
         string backupGlobalPacsConfigPath = string.Empty;

         // Upgrade GlobalPacs.Config if necessary

         bool bNeedsUpdateExternalStore = GlobalPacsUpdater.AddExternalStoreToGlobalPacsConfig(globalPacsConfigPath, false);
         bool bNeedsUpdate = bNeedsUpdateExternalStore;


#if (LEADTOOLS_V20_OR_LATER)
         bool bNeedsUpdateExportLayout = GlobalPacsUpdater.AddExportLayoutToGlobalPacsConfig(globalPacsConfigPath, false);
         bNeedsUpdate = bNeedsUpdate | bNeedsUpdateExportLayout;
#endif
         if (bNeedsUpdate)
         {
            string msg = string.Format("The existing globalPacs.config must be upgraded\n\nDo you want to continue?", exeName);
            DialogResult dr = MessageBox.Show(msg, "Upgrade Notice", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dr != DialogResult.Yes)
               return false;

            backupGlobalPacsConfigPath = GlobalPacsUpdater.BackupFile(globalPacsConfigPath);

            if (bNeedsUpdateExternalStore)
            {
               GlobalPacsUpdater.AddExternalStoreToGlobalPacsConfig(globalPacsConfigPath, true);
            }
         }
#endif // #if (LEADTOOLS_V19_OR_LATER_MEDICAL_EXTERNAL_STORE) || (LEADTOOLS_V19_OR_LATER)

#if (LEADTOOLS_V20_OR_LATER)
         if (bNeedsUpdateExportLayout)
         {
            GlobalPacsUpdater.AddExportLayoutToGlobalPacsConfig(globalPacsConfigPath, true);
         }
#endif // (LEADTOOLS_V20_OR_LATER)
         return true;
      }
   }
}

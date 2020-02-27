// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Leadtools.Demos;
using Leadtools;
using System.Windows.Forms;
using DicomDemo.Authentication;
using System.Diagnostics;
using Leadtools.Medical.UserManagementDataAccessLayer;
using Leadtools.Medical.PermissionsManagement.DataAccessLayer;
using Leadtools.Medical.OptionsDataAccessLayer;
using Leadtools.Medical.DataAccessLayer;
using Leadtools.Medical.UserManagementDataAccessLayer.Configuration;
using Leadtools.Medical.PermissionsManagement.DataAccessLayer.Configuration;
using Leadtools.Medical.OptionsDataAccessLayer.Configuration;
using Leadtools.DicomDemos;
using System.Configuration;
using Leadtools.Medical.DataAccessLayer.Configuration;

namespace DicomDemo
{
   partial class Program
   {
      public static bool InitializeLicense()
      {
         bool ret = true;
#if LEADTOOLS_V19_OR_LATER
            ret = Support.SetLicense();
#else
            Support.SetLicense();
            if (RasterSupport.KernelExpired)
               ret = false;
#endif
         return ret;
      }

      public static MainForm CreateMainForm()
      {
         MainForm main = new MainForm();

         main = new MainForm();
         return main;
      }

      public static bool Login()
      {
         if (IsUserDBConfigured())
         {
            LoginDialog dlgLogin = new LoginDialog();
            Process process = Process.GetCurrentProcess();

            dlgLogin.Text = "Patient Updater Login";
            dlgLogin.AuthenticateUser += new EventHandler<AuthenticateUserEventArgs>(dlgLogin_AuthenticateUser);
            if (dlgLogin.ShowDialog() == DialogResult.OK)
            {
               UserManager.User = new ManagerUser(dlgLogin.Username, UserManager.GetUserPermissions(dlgLogin.Username));
               return true;
            }           
         }
         else
         {
            MessageBox.Show("Patient Updater DB Configuration Incomplete. Please run " + Program.PacsDatabaseConfigurationDemoNames[0] + " to configure the database.",
                            "Application will exit.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Environment.Exit(0);
         }
         return false;
      }
      
      private static string[] PacsDatabaseConfigurationDemoNames = { "CSPacsDatabaseConfigurationDemo_Original.exe", "CSPacsDatabaseConfigurationDemo.exe" };

      private static bool IsUserDBConfigured()
      {
         System.Configuration.Configuration configuration = DicomDemoSettingsManager.GetGlobalPacsConfiguration();

         if (configuration != null)
         {
            ConnectionStringSettings settings = GetConnectionString(configuration, new UserManagementDataAccessConfigurationView().DataAccessSettingsSectionName);

            if (settings == null)
            {
               return false;
            }

            settings = GetConnectionString(configuration, new PermissionManagementDataAccessConfigurationView().DataAccessSettingsSectionName);
            if (settings == null)
            {
               return false;
            }

            settings = GetConnectionString(configuration, new OptionsDataAccessConfigurationView().DataAccessSettingsSectionName);
            if (settings == null)
            {
               return false;
            }
         }

         return true;
      }

      private static ConnectionStringSettings GetConnectionString(Configuration config, string dataAccessSectionName)
      {
         DataAccessSettings settings;

         try
         {
            settings = config.GetSection(dataAccessSectionName) as DataAccessSettings;

            if (settings == null)
            {
               return null;
            }
            else
            {
               ConnectionElement puElement = null;
               ConnectionStringSettings connection = null;

               for (int i = 0; i < settings.Connections.Count; i++)
               {
                  if (settings.Connections[i].ProductName == DicomDemoSettingsManager.ProductNameStorageServer)
                  {
                     puElement = settings.Connections[i];
                     break;
                  }
               }

               if (puElement != null)
                  connection = config.ConnectionStrings.ConnectionStrings[puElement.ConnectionName];

               return connection;
            }
         }
         catch (Exception)
         {
            return null;
         }
      }

      public static IUserManagementDataAccessAgent2 GetUserAgent(System.Configuration.Configuration configuration)
      {
         return DataAccessFactory.GetInstance(new UserManagementDataAccessConfigurationView(configuration, DicomDemoSettingsManager.ProductNameStorageServer, null)).CreateDataAccessAgent<IUserManagementDataAccessAgent2>();
      }

      public static IPermissionManagementDataAccessAgent2 GetPermissionsAgent(System.Configuration.Configuration configuration)
      {
         return DataAccessFactory.GetInstance(new PermissionManagementDataAccessConfigurationView(configuration, DicomDemoSettingsManager.ProductNameStorageServer, null)).CreateDataAccessAgent<IPermissionManagementDataAccessAgent2>();
      }

      public static IOptionsDataAccessAgent GetOptionsAgent(System.Configuration.Configuration configuration)
      {
         return DataAccessFactory.GetInstance(new OptionsDataAccessConfigurationView(configuration, DicomDemoSettingsManager.ProductNameStorageServer, null)).CreateDataAccessAgent<IOptionsDataAccessAgent>();
      }

      private static bool UpgradeConfigFiles(string[] args)
      {
         // do nothing -- we do not upgrade the toolkit version of the storage server
         return true;
      }

      private static bool MustRunAsAdmin(string[] args)
      {
         if (DemosGlobal.MustRestartElevated())
         {
            DemosGlobal.TryRestartElevated(args);
            return true;
         }
         return false;
      }
   }
}

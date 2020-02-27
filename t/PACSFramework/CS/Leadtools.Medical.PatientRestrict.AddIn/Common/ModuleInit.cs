// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************

using Leadtools.Dicom.AddIn;
using Leadtools.Dicom.AddIn.Configuration;
using Leadtools.Dicom.AddIn.Interfaces;
using Leadtools.Dicom.Server.Admin;
using Leadtools.DicomDemos;
using Leadtools.Logging;
using Leadtools.Medical.AeManagement.DataAccessLayer;
using Leadtools.Medical.AeManagement.DataAccessLayer.Configuration;
using Leadtools.Medical.DataAccessLayer;
using Leadtools.Medical.PatientRestrict.AddIn.Common;
using Leadtools.Medical.PermissionsManagement.DataAccessLayer;
using Leadtools.Medical.PermissionsManagement.DataAccessLayer.Configuration;
using Leadtools.Medical.WebViewer.PatientAccessRights;
using Leadtools.Medical.WebViewer.PatientAccessRights.DataAccessAgent;
using System;
using System.Collections.Generic;

namespace Leadtools.Medical.PatientRestrict.AddIn
{
   public class Module : ModuleInit, IProcessBreak
   {
      private static readonly object optionsLock = new object();
      public static PatientRestrictOptions _options;
      public const string Source = "SearchOtherPatientId";
      public const string OptionsName = "PatientRestrictOptions";
      private static IPatientRightsDataAccessAgent2 _patientRightsDataAccess = null;
      private static IPermissionManagementDataAccessAgent2 _permissionManagementDataAccess = null;
      private static IAeManagementDataAccessAgent2 _aeManagementDataAccess = null;

      public static IPatientRightsDataAccessAgent2 PatientRightsDataAccess
      {
         get
         {
            if (_patientRightsDataAccess == null)
            {
               if (DataAccessServices.IsDataAccessServiceRegistered<IPatientRightsDataAccessAgent2>())
               {
                  _patientRightsDataAccess =  DataAccessServices.GetDataAccessService<IPatientRightsDataAccessAgent2>();
               }
               else // not registered -- try to register
               {
                  try
                  {
                     _patientRightsDataAccess = DataAccessFactory.GetInstance(new PatientRightsDataAccessConfigurationView(DicomDemoSettingsManager.GetGlobalPacsAddinsConfiguration(ServiceDirectory), null, ServiceName)).CreateDataAccessAgent<IPatientRightsDataAccessAgent2>();

                     DataAccessServices.RegisterDataAccessService<IPatientRightsDataAccessAgent2>(_patientRightsDataAccess);
                  }
                  catch (Exception)
                  {
                     //Log
                  }
               }
            }
           
            return _patientRightsDataAccess;
         }
      }

      public static IPermissionManagementDataAccessAgent2 PermissionManagementDataAccessAgent
      {
         get
         {
            if (_permissionManagementDataAccess == null)
            {
               if (DataAccessServices.IsDataAccessServiceRegistered<IPermissionManagementDataAccessAgent2>())
               {
                  _permissionManagementDataAccess = DataAccessServices.GetDataAccessService<IPermissionManagementDataAccessAgent2>();
               }
               else // not registered -- try to register
               {
                  try
                  {
                     _permissionManagementDataAccess = DataAccessFactory.GetInstance(new PermissionManagementDataAccessConfigurationView(DicomDemoSettingsManager.GetGlobalPacsAddinsConfiguration(ServiceDirectory), null, ServiceName)).CreateDataAccessAgent<IPermissionManagementDataAccessAgent2>();

                     DataAccessServices.RegisterDataAccessService<IPermissionManagementDataAccessAgent2>(_permissionManagementDataAccess);
                  }
                  catch (Exception)
                  {
                     //Log
                  }
               }
            }

            return _permissionManagementDataAccess;
         }
      }

      public static IAeManagementDataAccessAgent AeManagementDataAccessAgent
      {
         get
         {
            if (_aeManagementDataAccess == null)
            {
               if (DataAccessServices.IsDataAccessServiceRegistered<IAeManagementDataAccessAgent2>())
               {
                  _aeManagementDataAccess = DataAccessServices.GetDataAccessService<IAeManagementDataAccessAgent2>();
               }
               else // not registered -- try to register
               {
                  try
                  {
                     _aeManagementDataAccess = DataAccessFactory.GetInstance(new AeManagementDataAccessConfigurationView(DicomDemoSettingsManager.GetGlobalPacsAddinsConfiguration(ServiceDirectory), null, ServiceName)).CreateDataAccessAgent<IAeManagementDataAccessAgent2>();

                     DataAccessServices.RegisterDataAccessService<IAeManagementDataAccessAgent2>(_aeManagementDataAccess);
                  }
                  catch (Exception)
                  {
                     //Log
                  }
               }
            }

            return _aeManagementDataAccess;
         }
      }

      private static DicomServer _server;

      public static DicomServer Server
      {
         get
         {
            return _server;
         }
         set
         {
            _server = value;
         }
      }

      private static DicomService _Service;
      public static DicomService Service
      {
         get
         {
            return _Service;
         }

         set
         {
            _Service = value;
         }
      }

      public static string ServiceDirectory
      {
         get;
         set;
      }

      public static string DisplayName
      {
         get;
         set;
      }

      public static string ServiceName
      {
         get;
         set;
      }

      public static bool IsServiceRunning()
      {
         return (_Service != null) && (_Service.Status == System.ServiceProcess.ServiceControllerStatus.Running);
      }

      public static void MyTellServiceSettingsHaveChanged()
      {
         if (IsServiceRunning())
            Module.Service.SendMessage(PatientRestrictMessage.SettingsChanged);
      }

      public static void GetService(string serviceDirectory, string displayName)
      {
         string dir = serviceDirectory.Replace(displayName, string.Empty);
         ServiceAdministrator _Administrator = new ServiceAdministrator(dir);

         _Administrator.Initialize(new List<string>() { displayName });
         if (_Administrator.Services.ContainsKey(displayName))
         {
            _Service = _Administrator.Services[displayName];
         }
      }

      // Leadtools.Dicom.Server.exe calls this
      public override void Load(string serviceDirectory, string displayName)
      {
         try
         {
            // Open 'advanced.config' which contains all settings for CSStorageServerManger.exe addins (including this addin)
            AdvancedSettings settings = AdvancedSettings.Open(serviceDirectory);

            ServiceDirectory = serviceDirectory;
            DisplayName = displayName;
            _server = ServiceLocator.Retrieve<DicomServer>();
            ServiceName = _server.Name;

            if (!ServiceLocator.IsRegistered<SettingsChangedNotifier>())
            {
               SettingsChangedNotifier configChangedNotifier = new SettingsChangedNotifier(settings);

               configChangedNotifier.SettingsChanged += ConfigChangedNotifier_SettingsChanged;
               configChangedNotifier.Enabled = true;
               ServiceLocator.Register<SettingsChangedNotifier>(configChangedNotifier);
            }
            else
            {
               ServiceLocator.Retrieve<SettingsChangedNotifier>().SettingsChanged += ConfigChangedNotifier_SettingsChanged;
            }

            ConfigureAddin(settings);
         }
         catch (Exception)
         {
         }
      }

      private void ConfigChangedNotifier_SettingsChanged(object sender, EventArgs e)
      {
         AdvancedSettings settings = AdvancedSettings.Open(ServiceDirectory);

         ConfigureAddin(settings);
      }

      public static void ConfigureAddin(AdvancedSettings settings)
      {
         _options = GetPatientRestrictOptions(settings);
      }

      public static PatientRestrictOptions GetPatientRestrictOptions(AdvancedSettings settings)
      {
         PatientRestrictOptions options = null;

         try
         {
            settings.RefreshSettings();
            options = settings.GetAddInCustomData<PatientRestrictOptions>(Source, OptionsName);
            if (options == null)
            {
               options = new PatientRestrictOptions();
            }
         }
         catch (Exception e)
         {
            if (options == null)
               options = new PatientRestrictOptions();

            Logger.Global.SystemMessage(LogType.Error, e.Message);
         }

         return options;
      }

      public void Break(BreakType type)
      {
         // throw new NotImplementedException();
      }

      public static PatientRestrictOptions Options
      {
         get
         {
            lock (optionsLock)
            {
               return Module._options;
            }
         }
         set
         {
            lock (optionsLock)
            {
               Module._options = value;
            }
         }
      }
   }
}

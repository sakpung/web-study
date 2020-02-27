// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Leadtools.Dicom.AddIn ;
using Leadtools.Dicom.Server.Admin ;
using Leadtools.Medical.Storage.DataAccessLayer;
using Leadtools.Medical.DataAccessLayer;
using Leadtools.Medical.Storage.DataAccessLayer.Configuration;
using Leadtools.Dicom.AddIn.Configuration;
using Leadtools.Medical.Storage.AddIns.Configuration;
using System.Diagnostics;
using Leadtools.Medical.PermissionsManagement.DataAccessLayer;
using Leadtools.Medical.Winforms.DataAccessLayer.Configuration;
using System.Security.AccessControl;
using System.IO;
using System.Security.Principal;
using Leadtools.Dicom;
using Leadtools.Logging;
using Leadtools.Logging.Medical;
using Leadtools.Medical.OptionsDataAccessLayer;
using Leadtools.Medical.DataAccessLayer.Configuration;
using Leadtools.Medical.OptionsDataAccessLayer.Configuration;
using Leadtools.Medical.Winforms;
using Leadtools.Dicom.AddIn.Interfaces;
using System.Windows.Forms;
using System.Configuration;
using Leadtools.DicomDemos;
using System.Threading;

namespace Leadtools.Medical.Storage.AddIns
{
   public class AddInsSession : ModuleInit
   {
      public override void Load ( string serviceDirectory, string displayName )
      {
         base.Load ( serviceDirectory, displayName ) ;

         LoadSession ( serviceDirectory, displayName, true ) ;
      }

      public void LoadSession ( string serviceDirectory, string displayName, bool fromServer )
      {
         if (ServiceLocator.IsRegistered<ILicense>())
         {
            _License = ServiceLocator.Retrieve<ILicense>();             
         }
         
         if (  ServiceLocator.IsRegistered <DicomServer> ( ) )
         {
            _server = ServiceLocator.Retrieve <DicomServer> ( ) ;
         }

         ServiceDirectory = serviceDirectory ;
         DisplayName      = displayName ;
         
         RegisterDataAccessAgents ( displayName ) ;
         
         if ( null != _server )
         {
            ServerAE      = _server.AETitle ;
            ServerAddress = _server.HostAddress ;
            ServerPort    = _server.Port ;
         }
            
         _configurationManager = new StorageModuleConfigurationManager ( fromServer ) ;
         
         _configurationManager.Load ( serviceDirectory ) ;
         
         StorageAddInsConfiguration storageConfiguration = _configurationManager.GetStorageAddInsSettings ( ) ;
         
         _configurationManager.GetPresentationContexts ( ) ;//Laod this in the load so it won't delay the process later

         UpdateDataAccessLayerSettings ( storageConfiguration ) ;
         
         bool ret = CheckPermissions ( storageConfiguration ) ;


         if (ret == false)
         {
            // Sleep so that the service is in the PendingStart state for a while
            // Otherwise, it sometimes skips the PendingStart state altogether
            Thread.Sleep(1000);
            throw new ServiceStartException("Cannot start the Storage Server Service: One or more folders do not exist.");
         }
      }

      private static void UpdateDataAccessLayerSettings( StorageAddInsConfiguration storageConfiguration )
      {
         if ( DataAccess != null && DataAccess is StorageDbDataAccessAgent )
         {
            ( ( StorageDbDataAccessAgent ) DataAccess ).AutoTruncateData = storageConfiguration.StoreAddIn.AutoTruncateData;
         }
      }

      static void RegisterDataAccessAgents ( string serviceName)
      {
         System.Configuration.Configuration configuration = DicomDemoSettingsManager.GetGlobalPacsAddinsConfiguration(ServiceDirectory);
         if ( !DataAccessServices.IsDataAccessServiceRegistered <IStorageDataAccessAgent> ( ) )
         {
            IStorageDataAccessAgent storageDataAccess = DataAccessFactory.GetInstance ( new StorageDataAccessConfigurationView (configuration, null, serviceName) ).CreateDataAccessAgent <IStorageDataAccessAgent> ( ) ;
            
            DataAccessServices.RegisterDataAccessService <IStorageDataAccessAgent> ( storageDataAccess ) ;
            
            DataAccess = storageDataAccess ;
         }
         else
         {
            DataAccess = DataAccessServices.GetDataAccessService<IStorageDataAccessAgent>();
         }
         
         if ( !DataAccessServices.IsDataAccessServiceRegistered <IPermissionManagementDataAccessAgent> ( ) )
         {
            try
            {
               IPermissionManagementDataAccessAgent permissionsDataAccess = DataAccessFactory.GetInstance(new AePermissionManagementDataAccessConfigurationView(configuration, null, serviceName)).CreateDataAccessAgent<IPermissionManagementDataAccessAgent>();

               DataAccessServices.RegisterDataAccessService<IPermissionManagementDataAccessAgent>(permissionsDataAccess);

               PermissionsAgent = permissionsDataAccess;
            }
            catch (Exception)
            {
            }
         }
         else
         {
            PermissionsAgent = DataAccessServices.GetDataAccessService<IPermissionManagementDataAccessAgent>();
         }
         
         if ( !DataAccessServices.IsDataAccessServiceRegistered <IOptionsDataAccessAgent> ( ) )
         {
            try
            {
               IOptionsDataAccessAgent optionsDataAccess = DataAccessFactory.GetInstance(new OptionsDataAccessConfigurationView(configuration, null, serviceName)).CreateDataAccessAgent<IOptionsDataAccessAgent>();

               DataAccessServices.RegisterDataAccessService<IOptionsDataAccessAgent>(optionsDataAccess);
            }
            catch (Exception)
            {
            }
         }
         
         //TODO: Check if workstastion data access is registered if not then check if config information 
         //is available. create only if config options available otherwise don't.
         //the database manager will use the ws dataAccess only if registered.
         //if ( !DataAccessServices.IsDataAccessServiceRegistered <IWorkstationDataAccess> ( ) )
         //{
         //   IOptionsDataAccessAgent optionsDataAccess = DataAccessFactory.GetInstance ( new OptionsDataAccessConfigurationView (configuration, null, serviceName) ).CreateDataAccessAgent <IOptionsDataAccessAgent> ( ) ;
            
         //   DataAccessServices.RegisterDataAccessService <IOptionsDataAccessAgent> ( optionsDataAccess ) ;
         //}
      }

      public override void AddServices ( )
      {
         StoreCommandInitializationService initializationService = new StoreCommandInitializationService ( ) ;
         
         ServiceLocator.Register<StorageModuleConfigurationManager> ( _configurationManager ) ;
         ServiceLocator.Register<StoreCommandInitializationService> ( initializationService ) ;
      }
      
      private void AutoCreateFolder(string folder)
      {
         if (!Directory.Exists(folder))
         {
            try
            {
               Directory.CreateDirectory(folder);
               Logger.Global.Log(string.Empty, string.Empty, -1, string.Empty, string.Empty, -1, DicomCommandType.Undefined, DateTime.Now,
                  LogType.Information, MessageDirection.None, "Directory has been created: " + folder, null, null);
            }
            catch (Exception)
            {
            }
         }
      }
      
      public bool CheckOnePermission(WindowsIdentity identity, string name, string folder, bool autoCreateFolder)
      {
         bool ret = true;
         string message = string.Empty;
         if (autoCreateFolder)
         {
            AutoCreateFolder(folder);
         }
         if (Directory.Exists(folder))
         {
            DirectorySecurity security = Directory.GetAccessControl(folder);

            FileSystemRights rights = GetDirectoryRights(security, identity);

            message = string.Format("PERMISSIONS => {0} ({1}): \r\n{2}", name, folder, rights);

            Logger.Global.Log(string.Empty, string.Empty, -1, string.Empty, string.Empty, -1, DicomCommandType.Undefined, DateTime.Now,
                                LogType.Information, MessageDirection.None, message, null, null);

            ret = true;
         }
         else
         {
            message = string.Format("{1} ({0}) does not exist.", folder, name);
            Logger.Global.Log(string.Empty, string.Empty, -1, string.Empty, string.Empty, -1, DicomCommandType.Undefined, DateTime.Now,
                              LogType.Error, MessageDirection.None, message, null, null);

            ret = false;
         }
         return ret;
      }

      public bool CheckPermissions ( StorageAddInsConfiguration storageConfiguration )
      {
         WindowsIdentity identity = WindowsIdentity.GetCurrent();

         bool ret = true;
         
         try
         {
            string message = string.Empty;
            
            
            ret &= CheckOnePermission(identity, "'Store File Settings' Folder", storageConfiguration.StoreAddIn.StorageLocation, storageConfiguration.StoreAddIn.AutoCreateFolderLocations);

            if (storageConfiguration.StoreAddIn.CreateBackupBeforeOverwrite)
            {
               ret &= CheckOnePermission(identity, "'Overwrite Settings' Folder", storageConfiguration.StoreAddIn.OverwriteBackupLocation, storageConfiguration.StoreAddIn.AutoCreateFolderLocations);
            }

            if (storageConfiguration.StoreAddIn.BackupFilesOnDelete && storageConfiguration.StoreAddIn.DeleteFiles)
            {
               ret &= CheckOnePermission(identity, "'Delete Settings' Folder", storageConfiguration.StoreAddIn.DeleteBackupLocation, storageConfiguration.StoreAddIn.AutoCreateFolderLocations);
            }

            if (storageConfiguration.StoreAddIn.SaveCStoreFailures)
            {
               ret &= CheckOnePermission(identity, "'Store Failure Settings' Folder", storageConfiguration.StoreAddIn.CStoreFailuresPath, storageConfiguration.StoreAddIn.AutoCreateFolderLocations);
            }
         }
         catch (Exception e)
         {
            Logger.Global.Log(string.Empty, string.Empty, -1, string.Empty, string.Empty, -1, DicomCommandType.Undefined, DateTime.Now,
                              LogType.Information, MessageDirection.None, e.Message, null, null);
         }
         
         return ret;
      }

      private FileSystemRights GetDirectoryRights(DirectorySecurity security,WindowsIdentity id)
      {
         FileSystemRights allowedRights = 0;
         FileSystemRights deniedRights = 0;

         foreach (FileSystemAccessRule rule in
                    security.GetAccessRules(true, true, id.User.GetType()))
         {
            //If the identity associated with the rule        
            //matches the user or any of their groups  
            if (rule.IdentityReference.Equals(id) ||
                   id.Groups.Contains(rule.IdentityReference))
            {
               uint right = (uint)rule.FileSystemRights & 0x00FFFFFF;

               //Filter out the generic rights so we get a           
               //nice enumerated value  
               if (rule.AccessControlType == AccessControlType.Allow)
                  allowedRights |= (FileSystemRights)(right);
               else
                  deniedRights |= (FileSystemRights)(right);
            };
         };

         return allowedRights ^ deniedRights;
      } 
      
      public static IStorageDataAccessAgent DataAccess
      {
         get
         {
            return _dataAccess ;
         }
         
         set
         {
            _dataAccess = value ;
         }
      }
      
      public static string ServiceDirectory
      {
         get
         {
            return _serviceDirectory ;
         }
         
         set
         {
            _serviceDirectory = value ;
         }
      }
      
      public static string DisplayName
      {
         get
         {
            return _displayName ;
         }
         
         set
         {
            _displayName = value ;
         }
      }
      
      public static string ServerAE 
      {
         get
         {
            return _serverAE ;
         }
         
         set
         {
            _serverAE = value ;
         }
      }
      
      public static string ServerAddress
      {
         get
         {
            return _serverAddress ; 
         }
         
         set
         {
            _serverAddress = value ;
         }
      }
      
      public static int ServerPort 
      {
         get
         {
            return _serverPort ;
         }
         
         set
         {
            _serverPort = value ;
         }
      }

      private static IPermissionManagementDataAccessAgent _PermissionsAgent;

      public static IPermissionManagementDataAccessAgent PermissionsAgent
      {
         get { return AddInsSession._PermissionsAgent; }
         set { AddInsSession._PermissionsAgent = value; }
      }
      
      public static ILicense License
      {
         get
         {
            return _License;
         }
         set
         {
            _License = value;
         }
      }
      
      private static string _serviceDirectory ;
      private static string _displayName ;
      private static string _serverAE ;
      private static string _serverAddress ;
      private static int _serverPort ;
      private static IStorageDataAccessAgent _dataAccess ;
      private static ILicense _License;
      private static DicomServer _server ;
      private StorageModuleConfigurationManager _configurationManager ;
      
   }
}

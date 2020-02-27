// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.IO;
using Leadtools.Dicom.AddIn;
using Leadtools.Dicom.AddIn.Common;
using Leadtools.Dicom.AddIn.Configuration;
using Leadtools.Dicom.Common.DataTypes;
using Leadtools.Dicom.Common.DataTypes.MediaCreation;
using Leadtools.Dicom.Scp;
using Leadtools.Dicom.Scp.Command;
using Leadtools.Dicom.Scp.Media;
using Leadtools.Dicom.Server.Admin;
using Leadtools.Medical.DataAccessLayer;
using Leadtools.Medical.Media.AddIns.Commands;
using Leadtools.Medical.Media.AddIns.Composing;
using Leadtools.Medical.Media.AddIns.MediaBurningProcessor;
using Leadtools.Medical.Media.AddIns.MediaBurningProcessor.Primera;
using Leadtools.Medical.Media.DataAccessLayer;
using Leadtools.Medical.Media.DataAccessLayer.Configuration;
using Leadtools.Medical.Storage.DataAccessLayer;
using Leadtools.Medical.Storage.DataAccessLayer.Configuration;
using Leadtools.DicomDemos;

namespace Leadtools.Medical.Media.AddIns
{
   public class AddInsSession : ModuleInit
   {
      #region Public
         
         #region Methods
               
            public override void Load ( string serviceDirectory, string displayName )
            {
               base.Load ( serviceDirectory, displayName ) ;

               SetLoadSettings ( serviceDirectory, displayName ) ;
               
               UnlockService ( serviceDirectory, displayName ) ;

               MediaCreationEventBroker.Instance.MediaObjectUpdated += new EventHandler<MediaItemEventArgs> ( Instance_MediaObjectUpdated ) ;
            }

            public override void AddServices ( )
            {
               MediaObjectsStateService mediaService ;
               
               
               mediaService = new MediaObjectsStateService ( new MediaCreationQueue ( ) ) ;

               RegisterServices ( DisplayName ) ;
               
               RegisterMediaCleaningService ( mediaService ) ;
               
               RegisterAutoCreationService ( mediaService ) ;
            }
         
            public static void SaveAddInConfiguration  ( )
            {
               if ( _settings != null ) 
               {
                  SettingsChangedNotifier configChangedNotifier = null ;
                  string addInsName    ;
                  
                  
                  if ( ServiceLocator.IsRegistered <SettingsChangedNotifier> ( ) )
                  { 
                     configChangedNotifier = ServiceLocator.Retrieve <SettingsChangedNotifier> ( ) ;
                  }
                  
                  if ( null != configChangedNotifier ) 
                  {
                     configChangedNotifier.Enabled = false ;
                  }
                  
                  addInsName = System.Reflection.Assembly.GetExecutingAssembly ( ).GetName ( ).Name ;
                  
                  _settings.SetAddInCustomData <MediaAddInConfiguration> ( addInsName, 
                                                                           typeof ( MediaAddInConfiguration ).Name, 
                                                                           AddInConfiguration ) ;
                                                                           
                  _settings.SetAddInCustomData <MediaMaintenanceState> ( addInsName, 
                                                                         typeof ( MediaMaintenanceState ).Name, 
                                                                         MaintenanceConfiguration ) ;
                  
                  _settings.SetAddInCustomData <MediaAutoCreationConfiguration> ( addInsName, 
                                                                                  typeof ( MediaAutoCreationConfiguration ).Name, 
                                                                                  MediaAutoCreationConfiguration ) ;
                  
                  _settings.Save ( ) ;
                  
                  if ( null != configChangedNotifier )
                  {
                     configChangedNotifier.Enabled = true ;
                  }
                  
                  if ( ServiceLocator.IsRegistered <MediaServicesState> ( ) )
                  {
                     ServiceLocator.Retrieve<MediaServicesState> ( ).MediaMaintenanceServiceEnabled = MaintenanceConfiguration.Enabled ;
                     ServiceLocator.Retrieve<MediaServicesState> ( ).AutoCreationServiceEnabled     = MediaAutoCreationConfiguration.EnableAutoMediaCreation ;
                  }
                  
                  OnAddInConfigurationSaved ( ) ;
               }
            }
            
            public static void OnAddInsConfigurationChanged ( ) 
            {
               if ( null != AddInsConfigurationChanged ) 
               {
                  AddInsConfigurationChanged ( ) ;
               }
            }
            
         #endregion
         
         #region Properties
         
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
            
            public static MediaAddInConfiguration AddInConfiguration
            {
               get
               {
                  if ( _settings == null ) 
                  {
                     _settings = AdvancedSettings.Open ( ServiceDirectory ) ;
                  }
                  
                  return GetMediaAddInsSettings ( ) ;
               }
            }
            
            
            public static MediaMaintenanceState MaintenanceConfiguration
            {
               get
               {
                  if ( _settings == null ) 
                  {
                     _settings = AdvancedSettings.Open ( ServiceDirectory ) ;
                  }
                  
                  return GetMaintenanceConfiguration ( ) ;
               }
            }
            
            public static MediaAutoCreationConfiguration MediaAutoCreationConfiguration
            {
               get
               {
                  if ( _settings == null ) 
                  {
                     _settings = AdvancedSettings.Open ( ServiceDirectory ) ;
                  }
                  
                  return GetMediaAutoCreationConfiguration ( ) ;
               }
            }
            
         #endregion
         
         #region Events
            
         #endregion
         
         #region Data Types Definition
            
         #endregion
         
         #region Callbacks
         
            public delegate void AddInsConfigurationHandler ( ) ;
            
            public static event AddInsConfigurationHandler AddInsConfigurationSaved ;
            public static event AddInsConfigurationHandler AddInsConfigurationChanged ;
            
         #endregion
         
      #endregion
      
      #region Protected
         
         #region Methods
            
         #endregion
         
         #region Properties
            
         #endregion
         
         #region Events
            
         #endregion
         
         #region Data Members
            
         #endregion
         
         #region Data Types Definition
            
         #endregion
         
      #endregion
      
      #region Private
         
         #region Methods
         
            private void RegisterMediaCleaningService ( MediaObjectsStateService  mediaService )
            {
               CommandAsyncProcessor        cleaner ;
               CleanExpiredMediaJobsCommand cleanCommand ;
               
               
               cleaner      = new CommandAsyncProcessor ( ) ;
               cleanCommand = new CleanExpiredMediaJobsCommand ( mediaService ) ;
               
               cleaner.Commands.Add ( new RefereshQueueCommand ( mediaService ) ) ;
               cleaner.Commands.Add ( cleanCommand ) ;
               
               if ( MaintenanceConfiguration.Enabled ) 
               {
                  cleaner.Start ( ) ;
               }
               
               ServiceLocator.Register <CommandAsyncProcessor> ( cleaner ) ;
            }
            
            private void RegisterAutoCreationService ( MediaObjectsStateService  mediaService )
            {
               MediaAutoCretionService mediaCreator ;
               PRIMERABurningProcessor processor ;
               
               
               mediaCreator = new MediaAutoCretionService ( mediaService ) ;
               processor    = new PRIMERABurningProcessor ( AddInsSession.AddInConfiguration.MediaFolder, new MediaLabelsCreator ( ) ) ;


               mediaCreator.MediaBurningProcessor = processor ;
               
               if ( MediaAutoCreationConfiguration.EnableAutoMediaCreation )
               {
                  mediaCreator.Start ( ) ;
               }
               
               ServiceLocator.Register <MediaAutoCretionService> ( mediaCreator ) ;
            }
            
            private static MediaAddInConfiguration GetMediaAddInsSettings ( )
            {
               MediaAddInConfiguration configuration ;
               string                  addInsName ;
               
               
               addInsName    = System.Reflection.Assembly.GetExecutingAssembly ( ).GetName ( ).Name ;
               configuration = _settings.GetAddInCustomData <MediaAddInConfiguration> ( addInsName, 
                                                                                        typeof ( MediaAddInConfiguration ).Name ) ;

               if ( null == configuration )
               {
                  configuration = new MediaAddInConfiguration ( Path.Combine ( ServiceDirectory, "Media" ),  
                                                                MediaProfiles.GeneralPurposeCDInterchange.Name ) ;
                  
                  _settings.SetAddInCustomData <MediaAddInConfiguration> ( addInsName, 
                                                                           typeof ( MediaAddInConfiguration ).Name, 
                                                                           configuration ) ;
               
                  _settings.Save ( ) ;
               }
               
               return configuration ;
            }
            
            private static MediaMaintenanceState GetMaintenanceConfiguration ( )
            
            {
               MediaMaintenanceState configuration ;
               string                addInsName ;
               
               
               addInsName    = System.Reflection.Assembly.GetExecutingAssembly ( ).GetName ( ).Name ;
               configuration = _settings.GetAddInCustomData <MediaMaintenanceState> ( addInsName, 
                                                                                      typeof ( MediaMaintenanceState ).Name ) ;
               if ( null == configuration )
               {
                  configuration = new MediaMaintenanceState ( ) ;
                  
                  _settings.SetAddInCustomData <MediaMaintenanceState> ( addInsName, 
                                                                         typeof ( MediaMaintenanceState ).Name, 
                                                                         configuration ) ;
               
                  _settings.Save ( ) ;
               }
               
               return configuration ;
            }
            
            private static MediaAutoCreationConfiguration GetMediaAutoCreationConfiguration ( ) 
            {
               MediaAutoCreationConfiguration configuration ;
               string                         addInsName ;
               
               
               addInsName    = System.Reflection.Assembly.GetExecutingAssembly ( ).GetName ( ).Name ;
               configuration = _settings.GetAddInCustomData <MediaAutoCreationConfiguration> ( addInsName, 
                                                                                               typeof ( MediaAutoCreationConfiguration ).Name ) ;
               if ( null == configuration )
               {
                  configuration = new MediaAutoCreationConfiguration ( ) ;
                  
                  _settings.SetAddInCustomData <MediaAutoCreationConfiguration> ( addInsName, 
                                                                         typeof ( MediaAutoCreationConfiguration ).Name, 
                                                                         configuration ) ;
               
                  _settings.Save ( ) ;
               }
               
               return configuration ;
            }
            
            private static void OnAddInConfigurationSaved ( )
            {
               if ( null != AddInsConfigurationSaved )
               {
                  AddInsConfigurationSaved ( ) ;
               }
            }
            
         #endregion
         
         #region Properties
         
         #endregion
         
         #region Events
         
            static void configChangedNotifier_SettingsChanged ( object sender, EventArgs e )
            {
               _settings.RefreshSettings ( ) ;
               
               if ( ServiceLocator.IsRegistered <MediaServicesState> ( ) )
               {
                  MediaServicesState servicesState ;
                  
                  
                  servicesState = ServiceLocator.Retrieve<MediaServicesState> ( ) ;
                  
                  servicesState.MediaMaintenanceServiceEnabled = MaintenanceConfiguration.Enabled ;
                  servicesState.AutoCreationServiceEnabled     = MediaAutoCreationConfiguration.EnableAutoMediaCreation ;
               }

               if (CommandRequestValidationManager.IsRegistered<MediaCreationReferencedSopsValidator>())
               {
                  MediaCreationReferencedSopsValidator validator = CommandRequestValidationManager.GetValidator<MediaCreationReferencedSopsValidator>();
                  
                  
                  if ( null != validator )
                  {
                     validator.Enabled = AddInConfiguration.ValidateReferencedSopInstances ;
                  }
               }
            }
            
            static void servicesState_MediaMaintenanceServiceStateChanged ( object sender, EventArgs e )
            {
               if ( ServiceLocator.IsRegistered <CommandAsyncProcessor> ( ) )
               {
                  CommandAsyncProcessor cleaner ;
                  
                  
                  cleaner = ServiceLocator.Retrieve <CommandAsyncProcessor> ( ) ;
                  
                  if ( cleaner != null ) 
                  {
                     if ( MaintenanceConfiguration.Enabled ) 
                     {
                        cleaner.Start ( ) ;
                     }
                     else
                     {
                        cleaner.WaitAndStop ( ) ;
                     }
                  }
               }
            }

            static void servicesState_AutoCreationServiceStateChanged ( object sender, EventArgs e )
            {
               if ( ServiceLocator.IsRegistered <MediaAutoCretionService> ( ) )
               {
                  MediaAutoCretionService creator ;
                  
                  
                  creator = ServiceLocator.Retrieve <MediaAutoCretionService> ( ) ;
                  
                  if ( creator != null ) 
                  {
                     if ( MediaAutoCreationConfiguration.EnableAutoMediaCreation ) 
                     {
                        if ( creator.MediaBurningProcessor is PRIMERABurningProcessor )
                        {
                           ( ( PRIMERABurningProcessor ) creator.MediaBurningProcessor ).ProcessingFolder = AddInConfiguration.MediaFolder ;
                        }
                        
                        creator.Start ( ) ;
                     }
                     else
                     {
                        creator.WaitAndStop ( ) ;
                     }
                  }
               }
            }
            
            void Instance_MediaObjectUpdated ( object sender, MediaItemEventArgs e )
            {
               try
               {
                  if ( e.Item.ExecutionStatus.ExecutionStatus.Value == ExecutionStatus.Pending &&
                       MediaAutoCreationConfiguration.EnableAutoMediaCreation  )
                  {
                     if ( ServiceLocator.IsRegistered <MediaAutoCretionService> ( ) )
                     {
                        ServiceLocator.Retrieve <MediaAutoCretionService> ( ).SignalProcessor ( ) ;
                     }
                  }
               }
               catch {}
            }
            
         #endregion
         
         #region Data Members
         
            private static AdvancedSettings _settings ;
            private static string _serviceDirectory ;
            private static string _displayName ;
            private static string _serverAE ;
            private static string _serverAddress ;
            private static int _serverPort ;
            
         #endregion
         
         #region Data Types Definition
            
         #endregion
         
      #endregion
      
      #region internal
         
         #region Methods
               
            internal static void SetLoadSettings(string serviceDirectory, string displayName)
            {
               ServiceDirectory = serviceDirectory ;
               DisplayName      = displayName ;
               
               _settings = AdvancedSettings.Open ( ServiceDirectory ) ;
            }

            internal static void UnlockService ( string serviceDirectory, string displayName )
            {
               List <string>        unlockedSerivces ;
               DicomService         service ;
               
               unlockedSerivces = new List<string> ( ) ;
               
               unlockedSerivces.Add ( displayName ) ;
               
               using ( ServiceAdministrator serviceAdmin = new ServiceAdministrator ( serviceDirectory ) )
               {
                  //Add the key
#if LEADTOOLS_V175_OR_LATER
                  serviceAdmin.Initialize(unlockedSerivces);
#else
                  serviceAdmin.Unlock ( string.Empty, unlockedSerivces ) ;
#endif
                  
                  if ( serviceAdmin.Services.ContainsKey ( displayName ) )
                  {
                     service = serviceAdmin.Services [ displayName ] ;

                     ConfigureSettings ( service.Settings ) ;
                  }
               }
            }

            internal static void ConfigureSettings ( ServerSettings settings )
            {
               ServerAE      = settings.AETitle ;
               ServerAddress = settings.IpAddress ;
               ServerPort    = settings.Port ;
            }

            internal static void RegisterServices ( string serviceName )
            {
               if ( !DataAccessServices.IsDataAccessServiceRegistered<IMediaCreationDataAccessAgent> ( ) )
               {
                  IMediaCreationDataAccessAgent mediaCreationService ;

                  System.Configuration.Configuration configuration = DicomDemoSettingsManager.GetGlobalPacsConfiguration();
                  
                  mediaCreationService = DataAccessFactory.GetInstance ( new MediaCreationDataAccessConfigurationView ( configuration, null, serviceName) ).CreateDataAccessAgent <IMediaCreationDataAccessAgent> ( ) ;
                  
                  DataAccessServices.RegisterDataAccessService<IMediaCreationDataAccessAgent> ( mediaCreationService ) ;
               }
               
               IStorageDataAccessAgent storageService ;
               
               if ( !DataAccessServices.IsDataAccessServiceRegistered<IStorageDataAccessAgent> ( ) )
               {
                  System.Configuration.Configuration configuration = DicomDemoSettingsManager.GetGlobalPacsConfiguration();

                  storageService = DataAccessFactory.GetInstance(new StorageDataAccessConfigurationView(configuration, null, serviceName)).CreateDataAccessAgent<IStorageDataAccessAgent>();
                  
                  DataAccessServices.RegisterDataAccessService <IStorageDataAccessAgent> ( storageService ) ;
               }
               else
               {
                  storageService = DataAccessServices.GetDataAccessService<IStorageDataAccessAgent> ( );
               }
               
               if ( !CommandRequestValidationManager.IsRegistered <CommandRequestDataSetValidator> ( ) )
               {
                  CommandRequestValidationManager.AddValidator ( new CommandRequestDataSetValidator ( ) ) ;
               }
               
               if ( !CommandRequestValidationManager.IsRegistered <MediaCreationReferencedSopsValidator> ( ) )
               {
                  MediaCreationReferencedSopsValidator validator = new MediaCreationReferencedSopsValidator ( storageService ) ;
                  
                  
                  validator.Enabled = AddInConfiguration.ValidateReferencedSopInstances ;

                  CommandRequestValidationManager.AddValidator(validator );
               }
               
               if ( !DicomCommandFactory.IsCommandServiceRegistered ( typeof ( MediaNCreateCommand ) ) )
               {
                  DicomCommandFactory.RegisterCommandInitializationService ( typeof ( MediaNCreateCommand ), 
                                                                             new MediaNCreateCommandInitializationService ( ) ) ;
               }
               
               if ( !ServiceLocator.IsRegistered <MediaServicesState> ( ) )
               {
                  MediaServicesState servicesState ;
                  
                  
                  servicesState = new MediaServicesState ( ) ;
                  
                  servicesState.AutoCreationServiceEnabled     = MediaAutoCreationConfiguration.EnableAutoMediaCreation ;
                  servicesState.MediaMaintenanceServiceEnabled = MaintenanceConfiguration.Enabled ;

                  servicesState.AutoCreationServiceStateChanged     += new EventHandler ( servicesState_AutoCreationServiceStateChanged ) ;
                  servicesState.MediaMaintenanceServiceStateChanged += new EventHandler ( servicesState_MediaMaintenanceServiceStateChanged ) ;
                  
                  ServiceLocator.Register <MediaServicesState> ( servicesState ) ;
               }
               
               if ( !ServiceLocator.IsRegistered <SettingsChangedNotifier> ( ) )
               {
                  SettingsChangedNotifier configChangedNotifier = new SettingsChangedNotifier ( _settings ) ;

                  configChangedNotifier.SettingsChanged += new EventHandler ( configChangedNotifier_SettingsChanged ) ;
                  
                  configChangedNotifier.Enabled = true ;
                  
                  ServiceLocator.Register <SettingsChangedNotifier> ( configChangedNotifier ) ;
               }
            }
            

         #endregion
         
         #region Properties
            
         #endregion
         
         #region Events
            
         #endregion
         
         #region Data Types Definition
            
         #endregion
         
         #region Callbacks
            
         #endregion
         
      #endregion
   }
   
   public static class MediaCreationManagementExtension
   {
      public static void SetCreationPath ( this MediaCreationManagement mediaObject, string path ) 
      {
         if ( null == path ) 
         {
            RemoveObject ( mediaObject ) ;
         }
         else
         {
            EnsurePropertyBagCreated ( mediaObject, PathProperty ) ;
            
            _mediaObjectPropertyBag [ mediaObject ] [ PathProperty ] = path ;
         }
      }

      public static string GetCreationPath ( this MediaCreationManagement mediaObject )
      {
         if ( !_mediaObjectPropertyBag.ContainsKey ( mediaObject ) )
         {
            return null ;
         }
         else
         {
            EnsurePropertyBagCreated ( mediaObject, PathProperty ) ;
         
            return _mediaObjectPropertyBag [ mediaObject ] [ PathProperty ] as string ;
         }
      }
      
      public static void SetStatusUpdateDate ( this MediaCreationManagement mediaObject, DateTime? date ) 
      {
         if ( null == date ) 
         {
            RemoveObject ( mediaObject ) ;
         }
         else
         {
            EnsurePropertyBagCreated ( mediaObject, StatusDateProperty ) ;
            
            _mediaObjectPropertyBag [ mediaObject ] [ StatusDateProperty ] = date ;
         }
      }
      
      public static DateTime? GetStatusUpdateDate ( this MediaCreationManagement mediaObject ) 
      {
         if ( !_mediaObjectPropertyBag.ContainsKey ( mediaObject ) )
         {
            return null ;
         }
         else
         {
            EnsurePropertyBagCreated ( mediaObject, StatusDateProperty ) ;
            
            return _mediaObjectPropertyBag [ mediaObject ] [ StatusDateProperty ] as DateTime? ;
         }
      }
      
      private static void EnsurePropertyBagCreated ( MediaCreationManagement mediaObject, string propertyName ) 
      {
         if ( _mediaObjectPropertyBag.ContainsKey ( mediaObject ) )
         {
            if ( null == _mediaObjectPropertyBag [ mediaObject ] )
            {
               _mediaObjectPropertyBag [ mediaObject ] = new Dictionary<string,object> ( ) ;
               
               _mediaObjectPropertyBag [ mediaObject ].Add ( propertyName, null ) ;
            }
            else if ( !_mediaObjectPropertyBag [ mediaObject ].ContainsKey ( propertyName ) )
            {
               _mediaObjectPropertyBag [ mediaObject ].Add ( propertyName, null ) ;
            }
         }
         else
         {
            _mediaObjectPropertyBag.Add ( mediaObject, new Dictionary<string,object> ( ) ) ;
               
            _mediaObjectPropertyBag [ mediaObject ].Add ( propertyName, null ) ;
         }
      }
      
      private static void RemoveObject(MediaCreationManagement mediaObject)
      {
         if ( _mediaObjectPropertyBag.ContainsKey ( mediaObject ) )
         {
            _mediaObjectPropertyBag.Remove ( mediaObject ) ;
         }
      }
      
      public static string PathProperty       = "Path" ;
      public static string StatusDateProperty = "StatusDate" ;
      
      private static Dictionary <MediaCreationManagement, Dictionary <string, object>> _mediaObjectPropertyBag = new Dictionary<MediaCreationManagement,Dictionary<string,object>> ( ) ;
   }
}

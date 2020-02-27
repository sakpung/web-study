// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Leadtools.Dicom.AddIn.Configuration;
using Leadtools.Medical.Storage.AddIns.Configuration;
using Leadtools.Dicom.Scp.Command;
using System.IO;
using Leadtools.Medical.Winforms;

namespace Leadtools.Medical.Storage.AddIns
{
   public class StorageModuleConfigurationManager : IDisposable
   {
      #region Public
         
         #region Methods
         
            public StorageModuleConfigurationManager ( bool autoRefresh ) 
            {
               AutoRefresh = autoRefresh ;
            }
            
            public void Dispose ( )
            {
               Dispose(true);
               GC.SuppressFinalize ( this ) ;
            }
            
            ~StorageModuleConfigurationManager() 
            {
               Dispose(false);
            }
            
            public bool AutoRefresh
            {
               get ;
               private set ;
            }
            
            public void Save ( ) 
            {
               if ( IsLoaded ) 
               {
                  _settingsChangedNotify.Enabled = false ;
                  
                  _settingsChangedNotify.SettingsChanged -= new EventHandler ( notifier_SettingsChanged ) ;
                  
                  try
                  {
                     _advancedSettings.Save ( ) ;
                  }
                  finally
                  {
                     _settingsChangedNotify.SettingsChanged += new EventHandler ( notifier_SettingsChanged ) ;
                     
                     _settingsChangedNotify.Enabled = true ;
                  }
               }
               else
               {
                  throw new InvalidOperationException ( "Service has not been initialized. Call the Load method" ) ;
               }
            }
            
            public void Load ( string serviceDirectory )
            {
               if ( IsLoaded ) 
               {
                  Unload ( ) ;
               }
               
               _advancedSettings = AdvancedSettings.Open ( serviceDirectory ) ;
               
               _settingsChangedNotify = new SettingsChangedNotifier ( _advancedSettings ) ;
               
               _settingsChangedNotify.SettingsChanged += new EventHandler ( notifier_SettingsChanged ) ;
               
               _settingsChangedNotify.Enabled = true ;
            }

            public void Unload ( ) 
            {
               if ( IsLoaded ) 
               {
                  _settingsChangedNotify.SettingsChanged -= new EventHandler ( notifier_SettingsChanged ) ;
                  
                  _settingsChangedNotify.Enabled = false ;
                  
                  _settingsChangedNotify.Dispose ( ) ;
                  
                  _settingsChangedNotify = null ;
               }
               
               _advancedSettings   = null ;
               _storeAddinSettings = null ;
            }
            
            public void SetStorageAddinsSettings
            (
               StorageAddInsConfiguration settings
            )
            {
               if ( null == _advancedSettings) 
               {
                  throw new InvalidOperationException ( "Service has not been initialized. Call the Load method" ) ;
               }
               
               string addInsName = System.Reflection.Assembly.GetExecutingAssembly ( ).GetName ( ).Name ;
               
               _advancedSettings.SetAddInCustomData<StorageAddInsConfiguration> ( addInsName,
                                                                                  StorageAddInsConfiguration.SectionName,
                                                                                  settings ) ;
            }
            
            public StorageAddInsConfiguration GetStorageAddInsSettings ( string serviceName)
            {
               if ( null == _storeAddinSettings ) 
               {
                  _storeAddinSettings = GetStorageAddInsSettingsInternal ( serviceName) ;
               }
               
               return _storeAddinSettings ;
            }
            
            public StorageAddInsConfiguration GetStorageAddInsSettings ( )
            {
               return GetStorageAddInsSettings(AddInsSession.DisplayName);
            }
            
            public PresentationContextList GetPresentationContexts ( ) 
            {
               if ( null == _presentationContexts ) 
               {
                  _presentationContexts = _storageClassesPresenter.LoadSettings ( ) ;
                  
                  _presentationsTimeStamp = DateTime.Now ;
               }
               
               return _presentationContexts ;
            }
            
            public void SetPresentationContextsTimestamp ( ) 
            {
               if ( IsLoaded ) 
               {
                  _advancedSettings.SetAddInCustomData <DateTime> ( typeof (AddInsSession).Name, typeof (PresentationContextList).Name, DateTime.Now ) ;
               }
            }
         
         #endregion
         
         #region Properties
         
            public bool IsLoaded
            {
               get
               {
                  return _advancedSettings != null ;
               }
            }
            
         #endregion
         
         #region Data Types Definition
            
         #endregion
         
         #region Callbacks
            
         #endregion
         
      #endregion
      
      #region Protected
         
         #region Methods
         
             protected virtual void Dispose ( bool disposing )
             {
                 if ( disposing ) 
                 {
                     // free managed resources
                     if ( null != _settingsChangedNotify )
                     {
                         _settingsChangedNotify.Dispose ( ) ;
                         
                         _settingsChangedNotify = null;
                     }
                 }
             }
            
         #endregion
         
         #region Properties
            
         #endregion
         
         #region Data Types Definition
            
         #endregion
         
      #endregion
      
      #region Private
         
         #region Methods
         
            private StorageAddInsConfiguration GetStorageAddInsSettingsInternal ( string serviceName)
            {
               StorageAddInsConfiguration settings;
               string addInsName ;
               
               
               if ( null == _advancedSettings ) 
               {
                  throw new InvalidOperationException ( "Service has not been initialized. Call the Load method" ) ;
               }
               
               addInsName = System.Reflection.Assembly.GetExecutingAssembly ( ).GetName ( ).Name ;
               
               settings = _advancedSettings.GetAddInCustomData <StorageAddInsConfiguration> ( addInsName, 
                                                                                              StorageAddInsConfiguration.SectionName ) ;
               if ( null == settings ) 
               {
                  settings = new StorageAddInsConfiguration ( ) ;
                  
                  FillDefaultConfiguration ( settings, serviceName) ;

                  SetStorageAddinsSettings ( settings ) ;
               
                  _advancedSettings.Save ( ) ;
               }
               
               if ( string.IsNullOrEmpty ( settings.StoreAddIn.StorageLocation ) )
               {
                  string storeLocation ;
                  
                  
                  //storeLocation = Environment.GetFolderPath ( Environment.SpecialFolder.MyDocuments ) ;
                  storeLocation = GetCommonDocumentsFolder();
                  
                  storeLocation = Path.Combine ( storeLocation, "DICOM Store" ) ;
                  
                  storeLocation = Path.Combine(storeLocation, serviceName);
                  
                  settings.StoreAddIn.StorageLocation = storeLocation ;
               }
#if (LEADTOOLS_V19_OR_LATER)
               if ( string.IsNullOrEmpty ( settings.StoreAddIn.HangingProtocolLocation ) )
               {
                  if (!string.IsNullOrEmpty(serviceName))
                  {
                     string storeLocation = GetCommonDocumentsFolder();

                     storeLocation = Path.Combine(storeLocation, "HangingProtocol");

                     storeLocation = Path.Combine(storeLocation, serviceName);

                     settings.StoreAddIn.HangingProtocolLocation = storeLocation;
                  }
               }
#endif
               if (string.IsNullOrEmpty(settings.StoreAddIn.OverwriteBackupLocation))
               {
                  string overwriteLocation;


                  overwriteLocation = GetCommonDocumentsFolder();

                  overwriteLocation = Path.Combine(overwriteLocation, "Overwrite");

                  overwriteLocation = Path.Combine(overwriteLocation, serviceName);

                  settings.StoreAddIn.OverwriteBackupLocation = overwriteLocation;
               }

               if (string.IsNullOrEmpty(settings.StoreAddIn.DeleteBackupLocation))
               {
                  string deleteBackupLocation;


                  deleteBackupLocation = GetCommonDocumentsFolder();

                  deleteBackupLocation = Path.Combine(deleteBackupLocation, "Backup");

                  deleteBackupLocation = Path.Combine(deleteBackupLocation, serviceName);


                  settings.StoreAddIn.DeleteBackupLocation = deleteBackupLocation;
               }
               
               if ( string.IsNullOrEmpty ( settings.StoreAddIn.CStoreFailuresPath ) )
               {
                  string failureLocation ;
                  
                  
                  failureLocation = GetCommonDocumentsFolder ( ) ;
                  
                  failureLocation = Path.Combine ( failureLocation, "StoreFailures" ) ;
                  
                  failureLocation = Path.Combine(failureLocation, serviceName);
                  
                  settings.StoreAddIn.CStoreFailuresPath = failureLocation ;
               }
               
               return settings;
            }
            
            private PresentationContextList GetPresentationContextsInternal ( ) 
            {
               if ( IsLoaded ) 
               {
                  DateTime updateTime = _advancedSettings.GetAddInCustomData <DateTime> ( typeof (AddInsSession).Name, typeof (PresentationContextList).Name ) ;
               
                  if ( updateTime > _presentationsTimeStamp )
                  {
                     _presentationContexts = null ;
                  }
               }
               
               return GetPresentationContexts ( ) ;
            }
            
            private static void FillDefaultConfiguration ( StorageAddInsConfiguration settings, string serviceName)
            {
               FillStoreCommandDefualtSettings(settings, serviceName);
               FillInstanceStoreCommandDefualtSettings ( settings ) ;
               
               FillQueryDefaultSettings(settings);
            }

            private static void FillQueryDefaultSettings(StorageAddInsConfiguration settings)
            {               
               settings.QueryAddIn.DataSetResponseOptions.IncludeNumberOfPatientStudies = false;
               settings.QueryAddIn.DataSetResponseOptions.IncludeNumberOfPatientSeries = false;
               settings.QueryAddIn.DataSetResponseOptions.IncludeNumberOfPatientInstances = false;
               
               settings.QueryAddIn.DataSetResponseOptions.IncludeNumberOfStudySeries = false;
               settings.QueryAddIn.DataSetResponseOptions.IncludeNumberOfStudyInstances = false;
               settings.QueryAddIn.DataSetResponseOptions.IncludeNumberOfSeriesInstances = true;

               settings.QueryAddIn.LimitCFindRsp = false;
            }

            private static void FillStoreCommandDefualtSettings(StorageAddInsConfiguration settings, string serviceName )
            {
               CStoreCommandConfiguration defaultStoreConfiguration ;


               defaultStoreConfiguration = new CStoreCommandConfiguration();

               //// Default the TifJ2K
               //// This is for the ImagePyramid and automatic generation of instance.json files on store
               //// This speeds access to image in the HTML5 Medical Web Viewer
               //SaveImageFormat defaultFormat = new SaveImageFormat
               //                                   {
               //                                      Format = RasterImageFormat.TifJ2k,
               //                                      Width = 0,
               //                                      Height = 0,
               //                                      QualityFactor = 2
               //                                   };
               //defaultStoreConfiguration.OtherImageFormat.Add(defaultFormat);
               
               // Set the default store location
               settings.StoreAddIn.StorageLocation = Path.Combine(defaultStoreConfiguration.DataSetStorageLocation, serviceName);
#if (LEADTOOLS_V19_OR_LATER)
               settings.StoreAddIn.HangingProtocolLocation = Path.Combine(defaultStoreConfiguration.HangingProtocolLocation, serviceName);
#endif
               settings.StoreAddIn.StoreFileExtension = defaultStoreConfiguration.DicomFileExtension ;
               
               // Set the default Overwrite location
               settings.StoreAddIn.OverwriteBackupLocation = Path.Combine(defaultStoreConfiguration.OverwriteBackupLocation, serviceName);
               
               // Set the default Backup location
               string storeLocation = GetCommonDocumentsFolder();
               string deleteBackupLocation = Path.Combine ( storeLocation, "Backup" ) ;
               settings.StoreAddIn.DeleteBackupLocation = Path.Combine(deleteBackupLocation, serviceName);
               
               // Set the default CStoreFailures location
               string storeFailuresLocation = Path.Combine(storeLocation, "StoreFailures");
               settings.StoreAddIn.CStoreFailuresPath = Path.Combine(storeFailuresLocation, serviceName);
               
               settings.StoreAddIn.DirectoryStructure.CreatePatientFolder = defaultStoreConfiguration.DirectoryStructure.CreatePatientFolder ;
               settings.StoreAddIn.DirectoryStructure.CreateSeriesFolder  = defaultStoreConfiguration.DirectoryStructure.CreateSeriesFolder ;
               settings.StoreAddIn.DirectoryStructure.CreateStudyFolder   = defaultStoreConfiguration.DirectoryStructure.CreateStudyFolder ;
               settings.StoreAddIn.DirectoryStructure.UsePatientName      = defaultStoreConfiguration.DirectoryStructure.UsePatientName ;
               settings.StoreAddIn.DirectoryStructure.SplitPatientId      = defaultStoreConfiguration.DirectoryStructure.SplitPatientId;
               
               foreach ( SaveImageFormat imageFormat in defaultStoreConfiguration.OtherImageFormat )
               {
                  SaveImageFormatElement saveImageElement ;
                  
                  
                  saveImageElement = new SaveImageFormatElement ( ) ;
                  
                  saveImageElement = GetImageFormatElement ( imageFormat ) ;
                  
                  settings.StoreAddIn.ImagesFormat.Add ( saveImageElement ) ;
               }
               
               settings.StoreAddIn.CreateThumbnailImage = defaultStoreConfiguration.SaveThumbnail ;
               
               if ( defaultStoreConfiguration.SaveThumbnail )
               {
                  settings.StoreAddIn.ThumbnailFormat = GetImageFormatElement ( defaultStoreConfiguration.ThumbnailFormat ) ;
               }
            }
            
            private static void FillInstanceStoreCommandDefualtSettings ( StorageAddInsConfiguration settings )
            {
               InstanceCStoreCommandConfiguration defaultInstanceConfiguration ;
               
               
               defaultInstanceConfiguration = new InstanceCStoreCommandConfiguration ( ) ;
               
               settings.StoreAddIn.CreateBackupBeforeOverwrite             = defaultInstanceConfiguration.CreateBackupForDuplicateSop ;
               settings.StoreAddIn.DatabaseOptions.UpdateExistentInstance  = defaultInstanceConfiguration.UpdateInstanceData ;
               settings.StoreAddIn.DatabaseOptions.UpdateExistentPatient   = defaultInstanceConfiguration.UpdatePatientData ;
               settings.StoreAddIn.DatabaseOptions.UpdateExistentSeries    = defaultInstanceConfiguration.UpdateSeriesData ;
               settings.StoreAddIn.DatabaseOptions.UpdateExistentStudy     = defaultInstanceConfiguration.UpdateStudyData ;
               
               settings.StoreAddIn.PreventStoringDuplicateInstance = defaultInstanceConfiguration.ValidateDuplicateSopInstanceUID ;
            }
            
            private static SaveImageFormatElement GetImageFormatElement
            (
               SaveImageFormat imageFormat
            )
            {
               SaveImageFormatElement imageFormatElement ;
               
               
               imageFormatElement = new SaveImageFormatElement ( ) ;
               
               imageFormatElement.Format = Enum.GetName ( typeof ( RasterImageFormat ), imageFormat.Format ) ;
               imageFormatElement.Height = imageFormat.Height ;
               imageFormatElement.Width  = imageFormat.Width ;
               imageFormatElement.QFactor = imageFormat.QualityFactor ;
               
               return imageFormatElement ;
            }
            
            private static string GetCommonDocumentsFolder()
            {
               int SIDL_COMMON_DOCUMENTS = 0x002E;
               System.Text.StringBuilder sb = new System.Text.StringBuilder(1024);
               SHGetFolderPath(IntPtr.Zero, SIDL_COMMON_DOCUMENTS, IntPtr.Zero, 0, sb);
               return sb.ToString();
            }
            
            [System.Runtime.InteropServices.DllImport("shell32.dll")]
            private static extern int SHGetFolderPath(IntPtr hwndOwner, int nFolder, IntPtr hToken, uint dwFlags, [System.Runtime.InteropServices.Out] System.Text.StringBuilder pszPath);
            
         #endregion
         
         #region Properties
            
         #endregion
         
         #region Events
         
            private void notifier_SettingsChanged ( object sender, EventArgs e )
            {
               try
               {
                  if ( IsLoaded )
                  {
                     if ( AutoRefresh ) 
                     {
                        _advancedSettings.RefreshSettings ( ) ;
                     }
                     
                     _storeAddinSettings   = GetStorageAddInsSettingsInternal ( string.Empty ) ;
                     _presentationContexts = GetPresentationContextsInternal ( ) ;
                  }
               }
               catch ( Exception exception ) 
               {
                  System.Diagnostics.Debug.Assert ( false, exception.Message ) ;
               }
            }
         
         #endregion
         
         #region Data Members
         
            private AdvancedSettings _advancedSettings ;
            
            private StorageAddInsConfiguration _storeAddinSettings ;
            
            private StorageClassesPresenter _storageClassesPresenter = new StorageClassesPresenter ( ) ;
         
            private PresentationContextList _presentationContexts ;
            
            private DateTime _presentationsTimeStamp = DateTime.MinValue ;
            
            private SettingsChangedNotifier _settingsChangedNotify ;
            
         #endregion
         
         #region Data Types Definition
            
         #endregion
         
      #endregion
      
      #region internal
         
         #region Methods
            
         #endregion
         
         #region Properties
            
         #endregion
         
         #region Data Types Definition
            
         #endregion
         
         #region Callbacks
            
         #endregion
         
      #endregion
   }
}

// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel ;
using System.Text ;
using Leadtools.Dicom.Scu ;
using System.IO ;
using System.Configuration ;
using System.Xml ;
using System.Xml.Serialization ;
using System.Net ;
using System.Linq ;
using Leadtools.Dicom.AddIn.Common ;
using Leadtools.DicomDemos;
using System.Drawing;
using Leadtools.MedicalViewer;
using Leadtools.Annotations.Engine;
using System.Windows.Forms;


namespace Leadtools.Demos.Workstation.Configuration
{
   public static class ConfigurationData
   {
#region Public
   
#region Methods
         
            public static bool HasChanges ( ) 
            {
               return _isDirty ;
            }
            
            public static void SaveChanges ( ) 
            {
               Save ( ) ;
            }
         
#endregion
   
#region Properties
         
            public static string ApplicationName
            {
               get
               {
                  return _appName ;
               }
               
               set
               {
                  _appName = value ;
               }
            }
            
            public static string HelpFile
            {
               get ;
               set ;
            }
            
            public static string DatabaseConfigName
            {
               get ;
               
               set ;
            }
            
            public static string DatabaseConfigEXEName
            {
               get ;
               
               set ;
            }
            
            public static string DatabaseConfigAltEXEName
            {
               get ;
               
               set ;
            }
            
            public static bool MoveToWSClient
            {
               get 
               {
                  return _moveToClient ;
               }
               
               set 
               {
                  if ( value != _moveToClient ) 
                  {
                     _moveToClient = value ;
                     
                     OnValueChanged ( null, new EventArgs ( ) ) ;
                  }
               }
            }
            
            public static bool SetClientToAllWorkstations
            {
               get 
               {
                  return _setClientToAllWS ;
               }
               
               set
               {
                  if ( value != _setClientToAllWS ) 
                  {
                     _setClientToAllWS = value ;
                     
                     OnValueChanged ( null, EventArgs.Empty ) ;
                  }
               }
            }
            
            public static bool RunPacsConfig
            {
               get ;
               set ;
            }
            
            public static IList <ScpInfo> PACS
            {
               get
               {
                  return _pacs ;
               }
               
               private set
               {
                  _pacs = value ;
               }
            }
            
            public static DebuggingConfig Debugging
            {
               get
               {
                  return _debuggingConfig ;
               }
               
               private set
               {
                  _debuggingConfig = value ; 
               }
            }
            
            public static StorageCompression Compression
            {
               get
               {
                  return _compression ;
               }
               
               private set
               {
                  _compression = value ;
               }
            }
            
            public static ScuInfo WorkstationClient
            {
               get
               {
                  return _workstationClient ;
               }
               
               private set
               {
                  _workstationClient = value ;
               }
            }

            public static ScpInfo ActivePacs
            {
               get
               {
                  if ( __ActivePacsIndex < 0 || __ActivePacsIndex >= PACS.Count )
                  {
                     return null ;
                  }
                  
                  return PACS [ __ActivePacsIndex ] ;
               }
               
               set
               {
                  if ( value != null && !PACS.Contains ( value ) )
                  {
                     throw new InvalidOperationException ( "Server " + value + " doens't exist in configured PACS list" ) ;
                  }
                  
                  int newIndex ;
                  
                  
                  newIndex = PACS.IndexOf ( value ) ;
                  
                  if ( newIndex != __ActivePacsIndex ) 
                  {
                     __ActivePacsIndex = newIndex ;
                     
                     OnValueChanged ( null, new EventArgs ( ) ) ;
                  }
               }
            }
            
            public static ScpInfo DefaultStorageServer
            {
               get
               {
                  return _defaultStorageServer ;
               }
               
               set
               {
                  if ( _defaultStorageServer != value )
                  {
                     _defaultStorageServer = value ;
                     
                     OnValueChanged ( null, new EventArgs ( ) ) ;
                  }
               }
            }
            
            public static ScpInfo DefaultQueryRetrieveServer
            {
               get
               {
                  return _defaultQueryRetrieveServer ;
               }
               
               set
               {
                  if ( _defaultQueryRetrieveServer != value )
                  {
                     _defaultQueryRetrieveServer = value ;
                     
                     OnValueChanged ( null, new EventArgs ( ) ) ;
                  }
               }
            }
            
            public static DicomClientMode ClientBrowsingMode
            {
               get
               {
                  return _clientMode ;
               }
               
               set
               {
                  if ( value != _clientMode )
                  {
                     _clientMode = value ;
                     
                     OnValueChanged ( null, new EventArgs ( ) ) ;
                  }
               }               
            }
            
            public static LazyLoading ViewerLazyLoading
            {
               get
               {
                  return _viewerLazyLoading ;
               }
               
               private set
               {
                  _viewerLazyLoading = value ;
               }
            }
            
            public static bool RunFullScreen
            {
               get
               {
                  return _runFullScreen ;
               }
               
               set
               {
                  if ( value != _runFullScreen ) 
                  {
                     _runFullScreen = value ;
                     
                     OnValueChanged ( null, new EventArgs ( ) ) ;
                  }
               }
            }
            
            public static bool QueueAutoLoad
            {
               get
               {
                  return _queueAutoLoad ;
               }
               
               set
               {
                  if ( _queueAutoLoad != value )
                  {
                     _queueAutoLoad = value ;
                     
                     OnValueChanged ( null, new EventArgs ( ) ) ;
                  }
               }               
            }
            
            public static bool QueueRemoveItem
            {
               get
               {
                  return _queueRemoveItem ;
               }
               
               set
               {
                  if ( _queueRemoveItem != value )
                  {
                     _queueRemoveItem = value ;
                     
                     OnValueChanged ( null, new EventArgs ( ) ) ;
                  }
               }               
            }
            
            public static bool ContinueRetrieveOnDuplicateInstance
            {
               get
               {
                  return _storeRetrievedImages ;
               }
               
               set
               {
                  if ( value != _storeRetrievedImages )
                  {
                     _storeRetrievedImages = value ;
                     
                     OnValueChanged ( null, new EventArgs ( ) ) ;
                  }
               }               
            }
            
            //TODO: this should be not wirtten in config, the user should call this from the demo.
            public static string MedicalNetKey
            {
               get
               {
                  return _medicalNetKey ;
               }
               
               set 
               {
                  _medicalNetKey = value ;
               }
            }
            
            //TODO: this should be not wirtten in config, the user should call this from the demo.
            public static string PacsFrmKey
            {
               get
               {
                  return _pacsFrmKey ;
               }
               
               set
               {
                  _pacsFrmKey = value ;
               }
            }
            
            public static bool AutoCreateService 
            {
               get
               {
                  return _autoCreateService ;
               }
               
               set
               {
                  if ( value != _autoCreateService ) 
                  {
                     _autoCreateService = value ;
                     
                     OnValueChanged ( null, new EventArgs ( ) ) ;
                  }
               }
            }
            
            public static string WorkstationServiceAE
            {
               get
               {
                  return _workstationServiceAE ;
               }
               
               set
               {
                  if ( value != _workstationServiceAE ) 
                  {
                     _workstationServiceAE = value ;
                     
                     OnValueChanged ( null, new EventArgs ( ) ) ;
                  }
               }
            }
            
            public static string ListenerServiceName
            {
               get
               {
                  return _listenerServiceName ;
               }
               
               set
               {
                  if ( value != _listenerServiceName ) 
                  {
                     _listenerServiceName = value ;
                     
                     OnValueChanged ( null, new EventArgs ( ) ) ;
                  }
               }
            }
            
            public static string ListenerServiceDefaultName
            {
               get
               {
                  return _listenerServiceDefaultName ;
               }
               
               set
               {
                  if ( value != _listenerServiceDefaultName ) 
                  {
                     _listenerServiceDefaultName = value ;
                     
                     OnValueChanged ( null, new EventArgs ( ) ) ;
                  }
               }
            }
            
            public static string ListenerServiceDefaultDisplayName
            {
               get
               {
                  return _listenerServiceDisplayName ;
               }
               
               set
               {
                  if ( value != _listenerServiceDisplayName ) 
                  {
                     _listenerServiceDisplayName = value ;
                     
                     OnValueChanged ( null, new EventArgs ( ) ) ;
                  }
               }
            }
            
            public static int ViewerOverlayTextSize
            {
               get
               {
                  return _viewerOverlayTextSize ;
               }
               
               set
               {
                  if ( value != _viewerOverlayTextSize ) 
                  {
                     _viewerOverlayTextSize = value ;
                     
                     OnValueChanged ( null, new EventArgs ( ) ) ;
                  }
               }
            }
            
            public static bool ViewerAutoSizeOverlayText
            {
               get
               {
                  return _viewerAutoSizeOverlayText ;
               }
               
               set
               {
                  if ( value != _viewerAutoSizeOverlayText ) 
                  {
                     _viewerAutoSizeOverlayText = value ;
                     
                     OnValueChanged ( null, new EventArgs ( ) ) ;
                  }
               }
            }
            
            public static SaveOptions SaveSessionBehavior
            {
               get 
               {
                  return _saveConfigBehavior ;
               }
               
               set 
               {
                  if ( value != _saveConfigBehavior ) 
                  {
                     _saveConfigBehavior = value ;
                     
                     OnValueChanged ( null, EventArgs.Empty ) ;
                  }
               }
            }
            
            public static bool SupportDicomCommunication
            {
               get ;
               set ;
            }
            
            public static bool SupportLocalQueriesStore
            {
               get ;
               set ;
            }
            
            public static string CurrentDicomDir
            {
               get ;
               set ;
            }
            
            public static bool CheckDataAccessServices
            {
               get ;
               set ;
            }
            
            public static bool ShowSplashScreen
            {
               get; 
               set;
            }
            
            public static bool AutoQuery
            {
               get; 
               set;
            }
            
            public static Color AnnotationDefaultColor
            {
               get 
               {
                  return _annotationDefaultColor ;
               }
               
               set 
               {
                  if ( value != _annotationDefaultColor ) 
                  {
                     _annotationDefaultColor = value ;
                     
                     OnValueChanged ( null, new EventArgs ( ) ) ;
                  }
               }
            }
            
            public static AnnUnit MeasurementUnit
            {
               get 
               {
                  return _measurementUnit ;
               }

               set 
               {
                  if ( value != _measurementUnit ) 
                  {
                     _measurementUnit = value ;
                     
                     OnValueChanged ( null, new EventArgs ( ) ) ;
                  }
               }
            }
            
#endregion
   
#region Events
         
            public static event EventHandler ValueChanged ;
            public static event EmptyHandler ChangesSaved ;
   
#endregion
   
#region Data Types Definition
         
            public delegate void EmptyHandler ( ) ;
   
#endregion
   
#region Callbacks
   
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
         
            static ConfigurationData ( ) 
            {
               try
               {
                  AppSettingsReader configReader ;
                  
                  
                  SupportDicomCommunication = true ;
                  SupportLocalQueriesStore  = true ;
                  CheckDataAccessServices   = true ;
                  ShowSplashScreen          = true ;
                  AutoQuery                 = false ;
                  
                  WorkstationClient = new ScuInfo ( ) ;
                  PACS              = new ScpInfoBindingList ( ) ;
                  Debugging         = new DebuggingConfig ( ) ;
                  Compression       = new StorageCompression ( ) ;
                  ViewerLazyLoading = new LazyLoading ( ) ;
                  configReader      = new AppSettingsReader ( ) ;
                  
                  DefaultQueryRetrieveServer = null ;
                  DefaultStorageServer       = null ;

                  ReadKeys                    ( configReader ) ;
                  ReadConfiguredPacs          ( configReader ) ;
                  ReadDebugConfig             ( configReader ) ;
                  ReadCompressionConfig       ( configReader ) ;
                  ReadWorkstationClientConfig ( configReader ) ;
                  ReadGeneralConfigData       ( configReader ) ;
                  ReadLazyLoadingConfigData   ( configReader ) ;
                  ReadAutoCreateServiceConfigData ( configReader ) ;
                  ReadOverlayTextSizeConfigData   ( configReader ) ;
                  
                  ReadViewerCommonSettings ( ) ;
                  
                  if ( ActivePacs == null && PACS.Count > 0 )
                  {
                     ActivePacs = PACS [ 0 ] ;
                  }
                  
                  _isDirty = false ;
                  
                  RegisterEvents ( ) ;
               }
               catch ( Exception exception )
               {
                  System.Diagnostics.Debug.Assert ( false, exception.Message ) ;
                                 
                  throw ;
               }
            }

            private static void ReadViewerCommonSettings ( )
            {
               AnnotationDefaultColor = Color.Yellow ;
               MeasurementUnit        = AnnUnit.Centimeter ;
               
               ExeConfigurationFileMap exeCommonConfig = new ExeConfigurationFileMap ( ) ;
               exeCommonConfig.ExeConfigFilename = Path.Combine ( Application.StartupPath, "ViewerCommon.config" ) ;
               
               if ( !File.Exists ( exeCommonConfig.ExeConfigFilename ) )
               {
                  return ;
               }
               System.Configuration.Configuration config = ConfigurationManager.OpenMappedExeConfiguration ( exeCommonConfig, ConfigurationUserLevel.None ) ;
               
               try
               {
                  if ( config.AppSettings.Settings.AllKeys.Contains ( Constants.AnnotationDefaultColor ) )
                  {
                     AnnotationDefaultColor = Color.FromArgb ( int.Parse ( config.AppSettings.Settings [ Constants.AnnotationDefaultColor ].Value ) ) ;
                  }
               }catch {}
                  
               try
               {
                  if ( config.AppSettings.Settings.AllKeys.Contains ( Constants.MeasurementUnit ) )
                  {
                     MeasurementUnit = (AnnUnit) Enum.Parse ( typeof ( AnnUnit ), config.AppSettings.Settings [ Constants.MeasurementUnit ].Value ) ;
                  }
               }catch {}
            }
            
            private static void RegisterEvents ( )
            {
               ( PACS as BindingList<ScpInfo> ).ListChanged += new ListChangedEventHandler ( PacsConfiguration_ListChanged ) ;
               
               ( PACS as ScpInfoBindingList ).ScpValueChanged += new EventHandler(OnValueChanged);
               Debugging.ValueChanged         += new EventHandler(OnValueChanged);
               Compression.ValueChanged       += new EventHandler(OnValueChanged);
               ViewerLazyLoading.ValueChanged += new EventHandler(OnValueChanged);
               WorkstationClient.ValueChanged += new EventHandler(OnValueChanged);
            }

            private static void ReadKeys ( AppSettingsReader configReader )
            {
               try
               {
                  MedicalNetKey = ( string ) configReader.GetValue ( Constants.MedicalNetKey, typeof ( string ) ) ;
               }
               catch
               {
                  MedicalNetKey = string.Empty ;
               }
               
               try
               {
                  PacsFrmKey = ( string ) configReader.GetValue ( Constants.PacsFrmKey, typeof ( string ) ) ;
               }
               catch
               {
                  PacsFrmKey = string.Empty ;
               }
            }
            
            private static void ReadWorkstationClientConfig ( AppSettingsReader configReader )
            {
               try
               {
                  try
                  {
                     WorkstationClient.AETitle = ( string ) configReader.GetValue ( Constants.WorkstationAETitle, typeof (string) ) ;
                  }
                  catch
                  {
                     WorkstationClient.AETitle = "LTSTATION_CLIENT" ;
                  }
                  
                  try
                  {
                     WorkstationClient.Address = ValidateAndGetValidHostAddress ( ( string ) configReader.GetValue ( Constants.WorkstationAddress, typeof (string) ) ) ;
                  }
                  catch
                  {
                     WorkstationClient.Address = Dns.GetHostName ( ) ;
                  }
                  
                  try
                  {
                     WorkstationClient.Port = ( int ) configReader.GetValue ( Constants.WorkstationPort, typeof (int) ) ;
                  }
                  catch
                  {
                     WorkstationClient.Port = 1000 ;
                  }
               }
               catch ( Exception exception )
               {
                  System.Diagnostics.Debug.Assert ( false, exception.Message ) ;
               }
            }

            private static void ReadConfiguredPacs ( AppSettingsReader configReader )
            {
               try
               {
                  string scpServers ;
                  
                  try
                  {
                     scpServers = (string)configReader.GetValue(Constants.PacsServers, typeof(string));
                  }
                  catch
                  {
                     scpServers = "";
                  }
                  
                  if ( !string.IsNullOrEmpty ( scpServers ) )
                  {
                     string [ ] serversArray ;
                     
                     
                     serversArray = scpServers.Split ( ';' ) ;
                     
                     foreach ( string server in serversArray ) 
                     {
                        string [ ] serverInfoArray ;
                        
                        
                        serverInfoArray = server.Split ( ',' ) ;
                        
                        if ( serverInfoArray.Length != 6 ) 
                        {
                           continue ;
                        }
                        
                        PACS.Add ( new ScpInfo ( serverInfoArray [ 0 ],
                                                 serverInfoArray [ 1 ],
                                                 int.Parse ( serverInfoArray [ 2 ] ),
                                                 int.Parse ( serverInfoArray [ 3 ] ) ) ) ; 
                                                 
                        if ( int.Parse ( serverInfoArray [ 4 ] ) == 1 )
                        {
                           DefaultQueryRetrieveServer = PACS [ PACS.Count - 1 ] ;
                        }
                        
                        if ( int.Parse ( serverInfoArray [ 5 ] ) == 1 )
                        {
                           DefaultStorageServer = PACS [ PACS.Count - 1 ] ;
                        }
                     }
                  }
                  
                  try
                  {
                     if ( ConfigurationManager.AppSettings.AllKeys.Contains ( Constants.ActivePacs ) )
                     {
                        __ActivePacsIndex = (int) configReader.GetValue ( Constants.ActivePacs, typeof ( int ) ) ;
                     }
                  }
                  catch
                  {
                     __ActivePacsIndex = -1 ;
                  }
               }
               catch ( Exception exception )
               {
                  System.Diagnostics.Debug.Assert ( false, exception.Message ) ;
                                 
                  throw ;
               }
            }
            
            private static void ReadDebugConfig ( AppSettingsReader configReader ) 
            {
               try
               {
                  string debugInfo ;
                  
                  try
                  {
                     debugInfo = (string) configReader.GetValue ( Constants.DebugInfo, 
                                                                  typeof ( string ) ) ;
                                                                  
                     debugInfo = debugInfo.Trim ( ) ;
                  }
                  catch
                  {
                     debugInfo = "";
                  }

                  if ( !string.IsNullOrEmpty ( debugInfo ) )
                  {
                     string [ ] debugInfoArray ;
                     
                     
                     debugInfoArray = debugInfo.Split ( ';' ) ;
                     
                     if ( debugInfoArray.Length == 4 )
                     {
                        Debugging.Enable                = bool.Parse ( debugInfoArray [ 0 ] ) ; 
                        Debugging.DisplayDetailedErrors = bool.Parse ( debugInfoArray [ 1 ] ) ;
                        Debugging.GenerateLogFile       = bool.Parse ( debugInfoArray [ 2 ] ) ;
                        Debugging.LogFileName           = debugInfoArray [ 3 ] ;
                     }
                  }
               }
               catch ( Exception exception )
               {
                  System.Diagnostics.Debug.Assert ( false, exception.Message ) ;
                  
                  Debugging.Enable = false ;
               }
            }
            
            private static void ReadCompressionConfig ( AppSettingsReader configReader ) 
            {
               try
               {
                  string compressionInfo ;
                  
                  try
                  {
                     compressionInfo = (string) configReader.GetValue ( Constants.CompressionInfo, 
                                                                  typeof ( string ) ) ;
                                                                  
                     compressionInfo = compressionInfo.Trim ( ';' ) ;
                     compressionInfo = compressionInfo.Trim ( ) ;
                  }
                  catch
                  {
                     compressionInfo = "";
                  }

                  if ( !string.IsNullOrEmpty ( compressionInfo ) )
                  {
                     string [ ] compressionInfoArray ;
                     
                     
                     compressionInfoArray = compressionInfo.Split ( ';' ) ;
                     
                     if ( compressionInfoArray.Length == 2 )
                     {
                        Compression.Enable = bool.Parse ( compressionInfoArray [ 0 ] ) ; 
                        Compression.Lossy  = bool.Parse ( compressionInfoArray [ 1 ] ) ;
                     }
                  }
               }
               catch ( Exception exception )
               {
                  System.Diagnostics.Debug.Assert ( false, exception.Message ) ;
                  
                  Compression.Enable = false ;
               }
            }
            
            private static void ReadGeneralConfigData ( AppSettingsReader configReader ) 
            {
               try
               {
                  try
                  {
                     ApplicationName = configReader.GetValue ( Constants.ApplicationName, typeof(string) ) as string ;
                     
                     if ( string.IsNullOrEmpty ( ApplicationName ) )
                     {
                        ApplicationName = DefaultValues.ApplicationName ;
                     }
                  }
                  catch
                  {
                     ApplicationName = DefaultValues.ApplicationName ;
                  }
                  
                  try
                  {
                     HelpFile = configReader.GetValue ( Constants.HelpFile, typeof(string) ) as string ;
                  }
                  catch
                  {
                     HelpFile = null ;
                  }                  
                  
                  try
                  {
                     DatabaseConfigName = configReader.GetValue ( Constants.DatabaseConfigName, typeof (string) ) as string ;
                     
                     if ( string.IsNullOrEmpty ( DatabaseConfigName ) )
                     {
                        DatabaseConfigName = DefaultValues.DatabaseConfigName ;
                     }
                  }
                  catch
                  {
                     DatabaseConfigName = DefaultValues.DatabaseConfigName ;
                  }
                  
                  try
                  {
                     DatabaseConfigEXEName = configReader.GetValue ( Constants.DatabaseConfigEXEName, typeof (string) ) as string ;
                     
                     if ( string.IsNullOrEmpty ( DatabaseConfigEXEName ) )
                     {
                        DatabaseConfigEXEName = DefaultValues.DatabaseConfigEXEName ;
                     }
                  }
                  catch
                  {
                     DatabaseConfigEXEName = DefaultValues.DatabaseConfigEXEName ;
                  }
                  
                  try
                  {
                     DatabaseConfigAltEXEName = configReader.GetValue ( Constants.DatabaseConfigAltEXEName, typeof (string) ) as string ;
                     
                     if ( string.IsNullOrEmpty ( DatabaseConfigAltEXEName ) )
                     {
                        DatabaseConfigAltEXEName = DefaultValues.DatabaseConfigAltEXEName ;
                     }
                  }
                  catch
                  {
                     DatabaseConfigEXEName = DefaultValues.DatabaseConfigEXEName ;
                  }
                  
                  try
                  {
                     RunPacsConfig = bool.Parse ( ( string ) configReader.GetValue ( Constants.RunPacsConfig, typeof (string) ) ) ;
                     
                  }
                  catch
                  {
                     RunPacsConfig = false ;
                  }
                  
                  try
                  {
                     MoveToWSClient = bool.Parse ( (string) configReader.GetValue ( Constants.MoveToWSClient, typeof (string) ) ) ;
                  }
                  catch
                  {
                     MoveToWSClient = false ;
                  }
                  
                  try
                  {
                     SetClientToAllWorkstations = bool.Parse ( (string) configReader.GetValue ( Constants.SetClientToAllWS, typeof (string) ) ) ;
                  }
                  catch 
                  {
                     SetClientToAllWorkstations = false ;
                  }
                  
                  try
                  {
                     ClientBrowsingMode = ( DicomClientMode ) Enum.Parse ( typeof ( DicomClientMode ),
                                                                           ( string )configReader.GetValue ( Constants.ClientBrowsingMode, 
                                                                                                             typeof ( string ) ) ) ;
                  }
                  catch
                  {
                     ClientBrowsingMode = DicomClientMode.LocalDb ;
                  }

                  try
                  {
                     RunFullScreen = bool.Parse ( (string) configReader.GetValue ( Constants.RunFullScreen, typeof (string) ) ) ;
                  }
                  catch
                  {
                     RunFullScreen = false ;
                  }

                  try
                  {
                     QueueAutoLoad = bool.Parse ( ( string )configReader.GetValue ( Constants.QueueAutoLoad, typeof (string) ) ) ;
                  }
                  catch
                  {
                     QueueAutoLoad = false ;
                  }
                  
                  try
                  {
                     QueueRemoveItem = bool.Parse ( ( string )configReader.GetValue ( Constants.QueueRemoveItem, typeof (string) ) ) ;
                  }
                  catch
                  {
                     QueueRemoveItem = false ;
                  }
                  
                  try
                  {
                     ContinueRetrieveOnDuplicateInstance = bool.Parse ( ( string ) configReader.GetValue ( Constants.ContinueRetrieveOnDuplicateInstance, typeof (string) ) ) ;
                  }
                  catch
                  {
                     ContinueRetrieveOnDuplicateInstance = false ;
                  }
                  
                  try
                  {
                     if ( ConfigurationManager.AppSettings.AllKeys.Contains ( Constants.SaveSessionBehavior ) )
                     {
                        SaveSessionBehavior = ( SaveOptions ) Enum.Parse ( typeof ( SaveOptions ), configReader.GetValue ( Constants.SaveSessionBehavior, typeof (string) ) as string ) ;
                     }
                     else
                     {
                        SaveSessionBehavior = SaveOptions.PromptUser ;
                     }
                  }
                  catch
                  {
                     SaveSessionBehavior = SaveOptions.PromptUser ;
                  }
                  
               }
               catch ( Exception exception )
               {
                  System.Diagnostics.Debug.Assert ( false, exception.Message ) ;
                                 
                  throw ;
               }
            }
            
            private static void ReadLazyLoadingConfigData ( AppSettingsReader configReader ) 
            {
               try
               {
                  ViewerLazyLoading.Enable = ( bool ) bool.Parse ( ( string )configReader.GetValue ( Constants.EnableLazyLoading, 
                                                                                                     typeof ( string ) ) ) ;
               }
               catch
               {
                  ViewerLazyLoading.Enable = true ;
               }

               try
               {
                  ViewerLazyLoading.HiddenImages = int.Parse ( ( string )configReader.GetValue ( Constants.LazyLoadingHiddenImages, 
                                                                                                 typeof (string) ) ) ;
               }
               catch
               {
                  ViewerLazyLoading.HiddenImages = 2 ;
               }

            }
            
            private static void ReadAutoCreateServiceConfigData ( AppSettingsReader configReader ) 
            {
               try
               {
                  AutoCreateService = ( bool ) bool.Parse ( ( string ) configReader.GetValue ( Constants.AutoCreateService, 
                                                                                               typeof ( string ) ) ) ;
               }
               catch 
               {
                  AutoCreateService = true ;
               }
               
               try
               {
                  ListenerServiceName = ( string ) configReader.GetValue ( Constants.WorkstationServiceName, 
                                                                            typeof ( string ) ) ;
               }
               catch 
               {
                  ListenerServiceName = "" ;
               }
               
               try
               {
                  WorkstationServiceAE = ( string ) configReader.GetValue ( Constants.WorkstationServiceAE, 
                                                                            typeof ( string ) ) ;
               }
               catch 
               {
                  WorkstationServiceAE = "" ;
               }
               
               try
               {
                  ListenerServiceDefaultName = ( string ) configReader.GetValue ( Constants.DefualtServiceName, 
                                                                                  typeof ( string ) ) ;
               }
               catch 
               {
                  ListenerServiceDefaultName = "LTSTATION_SERVER" ;
               }
               
               try
               {
                  ListenerServiceDefaultDisplayName = ( string ) configReader.GetValue ( Constants.DefualtServiceDisplay, 
                                                                                  typeof ( string ) ) ;
               }
               catch 
               {
                  ListenerServiceDefaultDisplayName = "LEADTOOLS Workstation Listener Service" ;
               }
            }
            
            
            private static void ReadOverlayTextSizeConfigData ( AppSettingsReader configReader ) 
            {
               try
               {
                  ViewerOverlayTextSize = int.Parse ( ( string ) configReader.GetValue ( Constants.ViewerOverlayTextSize,
                                                                                         typeof ( string ) ) ) ;
               }
               catch
               {
                  ViewerOverlayTextSize = 14 ;
               }
               
               try
               {
                  ViewerAutoSizeOverlayText = bool.Parse ( ( string ) configReader.GetValue ( Constants.ViewerAutoSizeOverlayText,
                                                                                              typeof ( string ) ) ) ;
               }
               catch
               {
                  ViewerAutoSizeOverlayText = true ;
               }
            }
            
            private static void AddConfigValue
            ( 
               System.Configuration.Configuration config,
               List <string> keys, 
               string key, 
               string value 
            ) 
            {
               try
               {
                  if ( keys.Contains ( key ) )
                  {
                     config.AppSettings.Settings [ key ].Value = value ;
                  }
                  else
                  {
                     config.AppSettings.Settings.Add ( key, value ) ; ;
                  }
               }
               catch ( Exception exception )
               {
                  System.Diagnostics.Debug.Assert ( false, exception.Message ) ;
                                 
                  throw ;
               }
            }
            
            private static void OnValueChanged ( object sender, EventArgs e )
            {
               _isDirty = true ;
               
               if ( null != ValueChanged )
               {
                  ValueChanged ( null, new EventArgs ( ) ) ;
               }
            }
            
            private static string ValidateAndGetValidHostAddress ( string testAddress ) 
            {
               string validAddress ;
               
               
               validAddress = Dns.GetHostName ( ) ;
               
               if ( validAddress.ToLower ( ) == testAddress.ToLower ( ) )
               {
                  return testAddress ;
               }
               else
               {
                  IPAddress [ ] localIpAddress = Dns.GetHostAddresses ( validAddress ) ;
                  
                  foreach ( IPAddress address in localIpAddress ) 
                  {
                     if ( address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork ) 
                     {
                        if ( testAddress == address.ToString ( ) )
                        {
                           return testAddress ;
                        }
                     }
                  }
               }
               
               return validAddress ;
            }
   
#endregion
   
#region Properties
   
            private static int __ActivePacsIndex
            {
               get ;
               set ;
            }
   
#endregion
   
#region Events
         
            private static void PacsConfiguration_ListChanged
            (
               object sender, 
               ListChangedEventArgs e
            )
            {
               try
               {
                  if ( null != DefaultStorageServer && !PACS.Contains ( DefaultStorageServer ) )
                  {
                     DefaultStorageServer = null ;
                  }
                  
                  if ( null != DefaultQueryRetrieveServer && !PACS.Contains ( DefaultQueryRetrieveServer ) )
                  {
                     DefaultQueryRetrieveServer = null ;
                  }
                  
                  OnValueChanged ( null, new EventArgs ( ) ) ;
               }
               catch ( Exception exception )
               {
                  System.Diagnostics.Debug.Assert ( false, exception.Message ) ;
                                 
                  throw ;
               }
            }
   
#endregion
   
#region Data Members
         
            private static IList <ScpInfo> _pacs ;
            private static ScuInfo _workstationClient ;
            private static ScpInfo _defaultStorageServer ;
            private static ScpInfo _defaultQueryRetrieveServer ;
            private static DicomClientMode _clientMode ;
            private static DebuggingConfig _debuggingConfig ;
            private static StorageCompression _compression ;
            private static LazyLoading        _viewerLazyLoading ;
            private static bool _runFullScreen ;
            private static bool _queueAutoLoad ;
            private static bool _queueRemoveItem ;
            private static bool _storeRetrievedImages ;
            private static bool _autoCreateService ;
            private static bool _moveToClient ;
            private static bool _setClientToAllWS ;
            private static bool _isDirty = false ;
            private static string _medicalNetKey ;
            private static string _pacsFrmKey ;
            private static string _workstationServiceAE ;
            private static string _listenerServiceName ;
            private static string _listenerServiceDefaultName ;
            private static string _listenerServiceDisplayName ;
            private static string _appName ;
            private static bool _viewerAutoSizeOverlayText ;
            private static int  _viewerOverlayTextSize ;
            private static SaveOptions _saveConfigBehavior ;
            private static Color _annotationDefaultColor ;
            private static AnnUnit _measurementUnit ;
   
#endregion
   
#region Data Types Definition
         
            private abstract class Constants
            {
               public const string MedicalNetKey         = "MedicalNetKey" ;
               public const string PacsFrmKey            = "PacsFrmKey" ;
               public const string ScpServerFormat       = "{0},{1},{2},{3},{4},{5};" ;
               public const string PacsServers           = "PacsServers" ;
               public const string WorkstationAETitle    = "WsAETitle" ;
               public const string WorkstationPort       = "WsPort" ;
               public const string WorkstationAddress    = "WsAddress" ;
               public const string DebugInfo             = "DebugInfo" ;
               public const string CompressionInfo       = "CompressionInfo" ;
               public const string ApplicationName       = "ApplicationName" ;
               
               public const string DatabaseConfigName       = "DatabaseConfigName" ;
               public const string DatabaseConfigEXEName    = "DatabaseConfigEXENam" ;
               public const string DatabaseConfigAltEXEName = "DatabaseConfigAltEXENam" ;
               public const string RunPacsConfig            = "RunPacsConfig" ;
               public const string MoveToWSClient           = "MoveToWSClient" ;
               public const string SetClientToAllWS         = "SetClientToAllWS" ;
               public const string ClientBrowsingMode    = "ClientBrowsingMode" ;
               public const string RunFullScreen         = "RunFullScreen" ;
               public const string QueueAutoLoad         = "QueueAutoLoad" ;
               public const string QueueRemoveItem       = "QueueRemoveItem";
               public const string EnableLazyLoading     = "EnableLazyLoading" ;
               public const string AutoCreateService     = "AutoCreateListenerService" ;
               public const string WorkstationServiceAE  = "WorkstationServiceAE" ;
               public const string DefualtServiceName    = "DefaultListenerServiceName" ;
               public const string WorkstationServiceName = "WorkstationServiceName" ;
               public const string DefualtServiceDisplay = "DefaultListenerServiceDisplayName" ;
               public const string ActivePacs            = "ActivePacs" ;
               public const string LazyLoadingHiddenImages             = "LazyLoadingHiddenImages" ;
               public const string ContinueRetrieveOnDuplicateInstance = "ContinueRetrieveOnDuplicateInstance" ; 
               
               public const string ViewerOverlayTextSize     = "ViewerOverlayTextSize" ;
               public const string ViewerAutoSizeOverlayText = "ViewerAutoSizeOverlayText" ;
               public const string HelpFile                  = "HelpFile" ;
               public const string SaveSessionBehavior       = "SaveSessionBehavior" ;
               
               public const string MeasurementUnit        = "MeasurementUnit" ;
               public const string AnnotationDefaultColor = "AnnotationDefaultColor" ;
            }
            
            private abstract class DefaultValues 
            {
               public const string ApplicationName          = "Medical Workstation Viewer Main Demo" ;
               public const string DatabaseConfigName       = "CSPacsDatabaseConfigurationDemo" ;
               public const string DatabaseConfigEXEName    = "CSPacsDatabaseConfigurationDemo_Original.exe" ;
               public const string DatabaseConfigAltEXEName = "CSPacsDatabaseConfigurationDemo.exe" ;
            }
   
#endregion
   
#endregion
   
#region internal
   
#region Methods
         
            internal static void Save ( ) 
            {
               try
               {
                  System.Configuration.Configuration config ;
                  System.Configuration.Configuration commonConfig ;
                  string pacsServers = string.Empty ;
                  string debugging   = string.Empty ;
                  string compression = string.Empty ;
                  
                  
                  foreach ( ScpInfo scp in PACS )
                  {
                     pacsServers += string.Format ( Constants.ScpServerFormat, 
                                                    scp.AETitle, 
                                                    scp.Address, 
                                                    scp.Port, 
                                                    scp.Timeout,
                                                    ( scp == DefaultQueryRetrieveServer ) ? 1 : 0,
                                                    ( scp == DefaultStorageServer ) ? 1 : 0  ) ;
                  }
                  
                  debugging = string.Format ( "{0};{1};{2};{3}", 
                                              Debugging.Enable.ToString ( ),
                                              Debugging.DisplayDetailedErrors.ToString ( ),
                                              Debugging.GenerateLogFile.ToString ( ),
                                              Debugging.LogFileName ) ;
                                              
                  compression = string.Format ( "{0};{1}", 
                                                Compression.Enable.ToString ( ),
                                                Compression.Lossy.ToString ( ) ) ;

                  config       = ConfigurationManager.OpenExeConfiguration ( ConfigurationUserLevel.None ) ;
                  
                  ExeConfigurationFileMap exeCommonConfig = new ExeConfigurationFileMap ( ) ;
                  exeCommonConfig.ExeConfigFilename = Path.Combine ( Application.StartupPath, "ViewerCommon.config" ) ;
                  
                  commonConfig = ConfigurationManager.OpenMappedExeConfiguration ( exeCommonConfig, ConfigurationUserLevel.None ) ;
                  
                  List <string> keys       = new List<string> ( config.AppSettings.Settings.AllKeys ) ;
                  List <string> commonKeys = new List<string> ( commonConfig.AppSettings.Settings.AllKeys ) ;
                  
                  
                  AddConfigValue ( config, keys, Constants.WorkstationAETitle, WorkstationClient.AETitle ) ;
                  AddConfigValue ( config, keys, Constants.WorkstationAddress, WorkstationClient.Address ) ;
                  AddConfigValue ( config, keys, Constants.WorkstationPort, WorkstationClient.Port.ToString ( ) ) ;
                  AddConfigValue ( config, keys, Constants.PacsServers, pacsServers ) ;
                  AddConfigValue ( config, keys, Constants.DebugInfo, debugging ) ;
                  AddConfigValue ( config, keys, Constants.CompressionInfo, compression ) ;
                  AddConfigValue ( config, keys, Constants.ApplicationName, ApplicationName ) ;
                  AddConfigValue ( config, keys, Constants.HelpFile, HelpFile ) ;
                  AddConfigValue ( config, keys, Constants.DatabaseConfigName, DatabaseConfigName ) ;
                  AddConfigValue ( config, keys, Constants.DatabaseConfigEXEName, DatabaseConfigEXEName ) ;
                  AddConfigValue ( config, keys, Constants.DatabaseConfigAltEXEName, DatabaseConfigAltEXEName ) ;
                  AddConfigValue ( config, keys, Constants.RunPacsConfig, RunPacsConfig.ToString ( ) ) ;
                  AddConfigValue ( config, keys, Constants.MoveToWSClient, MoveToWSClient.ToString ( ) ) ;
                  AddConfigValue ( config, keys, Constants.SetClientToAllWS, SetClientToAllWorkstations.ToString ( ) ) ;
                  AddConfigValue ( config, keys, Constants.ClientBrowsingMode, ClientBrowsingMode.ToString ( ) ) ;
                  AddConfigValue ( config, keys, Constants.RunFullScreen, RunFullScreen.ToString ( ) ) ;
                  AddConfigValue ( config, keys, Constants.QueueAutoLoad, QueueAutoLoad.ToString ( ) ) ;
                  AddConfigValue ( config, keys, Constants.QueueRemoveItem, QueueRemoveItem.ToString ( ) ) ;
                  AddConfigValue ( config, keys, Constants.ContinueRetrieveOnDuplicateInstance, ContinueRetrieveOnDuplicateInstance.ToString ( ) ) ;
                  AddConfigValue ( config, keys, Constants.EnableLazyLoading, ViewerLazyLoading.Enable.ToString ( ) ) ;
                  AddConfigValue ( config, keys, Constants.AutoCreateService, AutoCreateService.ToString ( ) ) ;
                  AddConfigValue ( config, keys, Constants.LazyLoadingHiddenImages, ViewerLazyLoading.HiddenImages.ToString ( ) ) ;
                  AddConfigValue ( config, keys, Constants.ViewerOverlayTextSize, ViewerOverlayTextSize.ToString ( ) ) ;
                  AddConfigValue ( config, keys, Constants.ViewerAutoSizeOverlayText, ViewerAutoSizeOverlayText.ToString ( ) ) ;
                  AddConfigValue ( config, keys, Constants.ActivePacs, __ActivePacsIndex.ToString ( ) ) ;
                  AddConfigValue ( config, keys, Constants.SaveSessionBehavior, SaveSessionBehavior.ToString ( ) ) ;
                  AddConfigValue ( config, keys, Constants.DefualtServiceDisplay, ListenerServiceDefaultDisplayName ) ;
                  AddConfigValue ( config, keys, Constants.DefualtServiceName, ListenerServiceDefaultName ) ;
                  AddConfigValue ( config, keys, Constants.WorkstationServiceName, ListenerServiceName ) ;
                  AddConfigValue ( config, keys, Constants.WorkstationServiceAE, WorkstationServiceAE ) ;
                  AddConfigValue ( commonConfig, commonKeys, Constants.AnnotationDefaultColor, AnnotationDefaultColor.ToArgb ( ).ToString ( ) ) ;
                  AddConfigValue ( commonConfig, commonKeys, Constants.MeasurementUnit, MeasurementUnit.ToString ( ) ) ;
                  
                  config.Save       ( ConfigurationSaveMode.Modified ) ;
                  commonConfig.Save ( ConfigurationSaveMode.Modified ) ;
                  
                  ConfigurationManager.RefreshSection ( "appSettings" ) ;
                  
                  _isDirty = false ;
                  
                  OnChangesSaved ( ) ;
               }
               catch ( Exception exception )
               {
                  System.Diagnostics.Debug.Assert ( false, exception.Message ) ;
                                 
                  throw ;
               }
            }

            private static void OnChangesSaved()
            {
               if ( null != ChangesSaved ) 
               {
                  ChangesSaved ( ) ;
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
   
   [Serializable]
   public class ScpInfo
   {
      public ScpInfo ( ) :
      this ( "", null, 1000, 30 )
      {
      
      }
      
      public ScpInfo 
      ( 
         string aeTitle, 
         string address, 
         int port, 
         int timeout 
      )
      {
         AETitle = aeTitle ;
         Address = address ;
         Port    = port ;
         Timeout = timeout ;
      }

      public string Address 
      {
          get
          {
            return _address ;
          }
          
          set
          {
            
            if ( _address == null || 
               ( value.ToString ( ) !=  _address.ToString ( ) ) )
            {
               _address = value ;
               
               OnValueChanged ( ) ;
            }
          }
      }
      
      public string AETitle 
      { 
         get
         {
            return _aeTitle ;
         }
         
         set
         {
            if ( value != _aeTitle )
            {
               _aeTitle  = value ; 
               
               OnValueChanged ( ) ;
            }
         }
      }
      
      public int Port 
      { 
         get
         {
            return _port ;
         }
         
         set
         {  
            if ( _port != value ) 
            {
               _port = value  ;
               
               OnValueChanged ( ) ;
            }
         }
      }
      
      public int Timeout 
      { 
         get
         {
            return _timeout ;
         }
         
         set
         {
            if ( _timeout != value ) 
            {
               _timeout = value ;
               
               OnValueChanged ( ) ;
            }
         }
      }
      
      public override string ToString ( )
      {
         return AETitle ;
      }
      
      private void OnValueChanged ( ) 
      {
         if ( null != ValueChanged )
         {
            ValueChanged ( this, new EventArgs ( ) ) ;
         }
      }
      
      public event EventHandler ValueChanged ;

      private string _address  ;
      private string _aeTitle ;
      private int    _port ;
      private int    _timeout ;


      public override bool Equals ( object obj )
      {
         try
         {
            ScpInfo scpObj ;
            
            
            scpObj = obj as ScpInfo ;
            
            if ( null == scpObj )
            {
               return false ;
            }
            
            return ( this.AETitle == scpObj.AETitle && this.Address == scpObj.Address && this.Port == scpObj.Port && this.Timeout == scpObj.Timeout ) ;
         }
         catch ( Exception ) 
         {
            return false ;
         }
      }

      public override int GetHashCode()
      {
         return AETitle.GetHashCode ( ) ^ Address.GetHashCode ( ) ^ Port.GetHashCode ( ) ^ Timeout.GetHashCode ( ) ;
      }
   }
   
   
   [Serializable]
   public class ScuInfo
   {
      public ScuInfo ( )
      {
         
      }


      internal AeInfo ToAeInfo ( ) 
      {
         AeInfo ae = new AeInfo ( ) ;
         
         ae.Address = Address ;
         ae.AETitle = AETitle ;
         ae.Port    = Port ;
         ae.SecurePort = 0 ;
         
         return ae ;
      }
      
      internal DicomAE ToDicomAE ( ) 
      {
         DicomAE ae = new DicomAE ( ) ;
         
         ae.AE = AETitle ;
         ae.IPAddress = Address ;
         ae.Port = Port ;
         
         return ae ;
      }
      
      public string Address 
      { 
         get
         {
            return _address ;
         }
         
         set
         {
            if ( value != _address ) 
            {
               _address = value ;
               
               OnValueChanged ( ) ;
            }
         }
      }

      public string AETitle 
      { 
         get
         {
            return _aeTitle ;
         }
         
         set
         {
            if ( _aeTitle != value ) 
            {
               _aeTitle = value ;
               
               OnValueChanged ( ) ;
            }
         }
      }
      
      public int Port 
      { 
         get
         {
            return _port ;
         }
         
         set
         {
            if ( _port != value ) 
            {
               _port = value ;
               
               OnValueChanged ( )  ;
            }
         }
      }
      
      private void OnValueChanged ( ) 
      {
         if ( null != ValueChanged ) 
         {
            ValueChanged ( this, new EventArgs ( ) ) ;
         }
      }
      
      public event EventHandler ValueChanged ;
      private string _address = string.Empty ;
      private string _aeTitle = string.Empty ;
      private int    _port = -1 ;
   }
   
   class ScpInfoBindingList : BindingList <ScpInfo>
   {
      protected override void InsertItem(int index, ScpInfo item)
      {
         base.InsertItem(index, item);

         item.ValueChanged += new EventHandler(item_ValueChanged);
      }

      void item_ValueChanged(object sender, EventArgs e)
      {
         if ( null != ScpValueChanged ) 
         {
            ScpValueChanged ( sender, new EventArgs ( ) ) ;
         }
      }

      protected override void RemoveItem(int index)
      {
         if ( index >= 0 && index < Count )
         {
            this [ index ].ValueChanged -= new EventHandler(item_ValueChanged);
         }
         
         base.RemoveItem(index);
      }
      
      public event EventHandler ScpValueChanged ;
   }
   
   public enum SaveOptions
   {
      AlwaysSave,
      NeverSave,
      PromptUser
   }
}

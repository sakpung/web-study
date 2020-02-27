// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Leadtools.Dicom.Server.Admin;
using System.Net;
using System.IO;
using System.Configuration;
using System.Xml;
using Leadtools.Dicom.AddIn.Common;
using Leadtools.Demos.StorageServer.DataTypes;
using Leadtools.Medical.DataAccessLayer.Configuration;
using Leadtools.DicomDemos;
using Leadtools.Medical.Winforms;
using Leadtools.Medical.Storage.AddIns;
using Leadtools.Dicom.AddIn;
using Leadtools.Medical.Logging.Addins;
using Leadtools.Dicom;
using Leadtools.Dicom.AddIn.Configuration;
using Leadtools.Demos.StorageServer.Properties;
using System.Windows.Forms;
using Leadtools.Medical.Storage.DataAccessLayer;
using Leadtools.Medical.DataAccessLayer;
using Leadtools.Medical.Storage.AddIns.Configuration;

namespace Leadtools.Demos.StorageServer.UI
{
   partial class GeneralSettingsPresenter
   {
      #region Public
         
         #region Methods
         
            public void RunView ( GeneralSettingsView view ) 
            {
               ServerState.Instance.ServerServiceChanged  += new EventHandler ( Instance_ServerServiceChanged ) ;
               ServerState.Instance.ServiceAdminChanged   += new EventHandler ( OnConfigureView ) ;
               ServerState.Instance.IsRemoteServerChanged += new EventHandler ( OnConfigureView ) ;
               
               EventBroker.Instance.Subscribe <ApplyServerSettingsEventArgs>  ( OnUpdateServerSettings ) ;
               EventBroker.Instance.Subscribe <CancelServerSettingsEventArgs> ( OnCancelServerSettings ) ;

               View = view ;
               ConfigureView ( ) ;

               View.AddServer        += new EventHandler ( View_AddServer ) ;
               View.DeleteServer     += new EventHandler ( View_DeleteServer ) ;
               View.AETitleChanged   += new EventHandler ( View_AETitlechanged ) ;
               View.IpAddressChanged += new EventHandler ( View_IpAddressChanged ) ;
               View.PortChanged      += new EventHandler ( View_PortChanged ) ;

               View.ImplementationClassUIDChanged    += new EventHandler ( View_ImplementationClassUIDChanged ) ;
               View.ImplementationVersionNameChanged += new EventHandler ( View_ImplementationVersionNameChanged ) ;
               View.ServiceStartModeChanged          += new EventHandler ( View_ServiceStartModeChanged ) ;

               View.IpTypeChanged += new EventHandler(View_IpTypeChanged);

               View.VisibleChanged += new EventHandler(View_VisibleChanged);

               View.SettingsChanged += new EventHandler(View_SettingsChanged);
               
               View.SetWindowsServiceDescription(WindowsServiceDescription);
               
               View.SetWindowsServiceDescriptionEnabled(WindowsServiceDescriptionEnabled);
               
            }

            public event EventHandler SettingsChanged;

            private void View_SettingsChanged(object sender, EventArgs e)
            {
               try
               {
                  if (SettingsChanged != null)
                  {
                     SettingsChanged(sender, e);
                  }
               }
               catch (Exception)
               {
                  System.Diagnostics.Debug.Assert(false);
               }
            }


            public bool IsDirty
            {
               get
               {
                  return View.IsDirty;
               }
            }


            void View_VisibleChanged(object sender, EventArgs e)
            {
               UpdateIpControls();
            }

            void View_IpTypeChanged(object sender, EventArgs e)
            {
               __IsDirty = true;

               GeneralSettingsView view = sender as GeneralSettingsView;
               if (view != null)
               {
                  List<string> addressesStringList = ConfigureIpList(View.IpType);
                  View.IpAddress = (addressesStringList.Count > 0) ? (View.IpType == DicomNetIpTypeFlags.Ipv4OrIpv6 ? addressesStringList[0] : addressesStringList[1]) : ServerDefaultValues.IpAddress;

               }
               
            }

            public void UpdateSettings ( ) 
            {
               if ( ServerState.Instance.ServerService != null ) 
               {
                  UpdateServerSettings ( ServerState.Instance.ServerService.Settings ) ;

                  ServerState.Instance.ServerService.Settings = ServerState.Instance.ServerService.Settings ;
               }
            }
         
         #endregion
         
         #region Properties
               
            public GeneralSettingsView View
            {
               get ;
               private set ;
            }
            
         #endregion
         
         #region Data Types Definition
            
         #endregion
         
         #region Callbacks
            
         #endregion
         
      #endregion
      
      #region Protected
         
         #region Methods
            
         #endregion
         
         #region Properties
            
         #endregion
         
         #region Data Types Definition
            
         #endregion
         
      #endregion
      
      #region Private
         
         #region Methods

            private List<string> ConfigureIpList(DicomNetIpTypeFlags ipType)
            {
               IPAddress[] addresses = Dns.GetHostAddresses(Dns.GetHostName());
               List<string> addressesStringList = new List<string>();
               List<string> addressesIpv4StringList = new List<string>();
               List<string> addressesIpv6StringList = new List<string>();


               foreach (IPAddress address in addresses)
               {
                  if (address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                  {
                     addressesIpv4StringList.Add(address.ToString());
                  }
                  else if (address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetworkV6)
                  {
                     addressesIpv6StringList.Add(address.ToString());
                  }
               }

               View.CanIpV6CheckBox = addressesIpv6StringList.Count > 0;
               View.CanIpBothCheckBox = DemosGlobal.IsOnVistaOrLater && View.CanIpV6CheckBox;

               switch (ipType)
               {
                  case DicomNetIpTypeFlags.Ipv4:
                     // nothing
                     break;
                  case DicomNetIpTypeFlags.Ipv6:
                     if (!View.CanIpV6CheckBox)
                        ipType = DicomNetIpTypeFlags.Ipv4;
                     break;
                  case DicomNetIpTypeFlags.Ipv4OrIpv6:
                     if (!View.CanIpBothCheckBox)
                        ipType = DicomNetIpTypeFlags.Ipv4;
                     break;
               }
               
               addressesStringList.Clear();
               addressesStringList.Add("All");

               if ((ipType & DicomNetIpTypeFlags.Ipv4) == DicomNetIpTypeFlags.Ipv4)
               {
                  foreach (string s in addressesIpv4StringList)
                  {
                     if (s != "0.0.0.0")
                     {
                        addressesStringList.Add(s);
                     }
                  }
               }

               if ((ipType & DicomNetIpTypeFlags.Ipv6) == DicomNetIpTypeFlags.Ipv6)
               {
                  foreach (string s in addressesIpv6StringList)
                  {
                     {
                        addressesStringList.Add(s);
                     }
                  }
               }
               View.SetIpAddressList(addressesStringList.ToArray());
               View.IpType = ipType;
               return addressesStringList;
            }
            
            private void UpdateIpControls()
            {
               bool serviceRunning = false;
               if ( ServerState.Instance.ServerService != null )
               {
                  serviceRunning = ServerState.Instance.ServerService.Status == System.ServiceProcess.ServiceControllerStatus.Running;
               }
               View.CanSelectIpAddress = !serviceRunning;
               View.CanSelectIpType = !serviceRunning;
               View.CanSelectPort = !serviceRunning;

            }
         
            private void ConfigureView ( )
            {
               
               if ( ServerState.Instance.IsRemoteServer )
               {
                  View.Enabled = false ;
                  
                  return ;
               }

               List<string> addressesStringList = null; 
               
               View.SetStartupModeList ( new string [] { "Automatic", "Manual", "Disabled" } ) ;

               if ( ServerState.Instance.ServerService == null ) 
               {
                  View.AeTitle                = ServerDefaultValues.AeTitle ;
                  View.Port                   = ServerDefaultValues.Port   ;
                  View.IpType                 = Leadtools.Dicom.DicomNetIpTypeFlags.Ipv4;
                  addressesStringList         = ConfigureIpList(View.IpType);
                  View.IpAddress              = (addressesStringList.Count > 0) ? (View.IpType == DicomNetIpTypeFlags.Ipv4OrIpv6 ? addressesStringList[0] : addressesStringList[1]) : ServerDefaultValues.IpAddress;
                  View.ImplementationClassUID = ServerDefaultValues.ImplementationClassUID ;
                  View.ImplementationVersion  = ServerDefaultValues.ImplementationVersion ;
                  View.ServiceDisplayName     = ServerDefaultValues.AeTitle ;
                  View.ServiceDecription      = ServerDefaultValues.ServiceDecription ;
                  View.ServiceStartupMode     = ServerDefaultValues.ServiceStartupMode ;

                  View.CanChangeServiceDescription = true ;
                  View.CanShowServerDelete     = CanShowServerDelete();
                  View.CanDeleteServer             = false ;
                  View.CanAddServer                = true  && ServerState.Instance.ServiceAdmin != null ;
               }
               else
               {
                  View.AeTitle                = ServerState.Instance.ServerService.Settings.AETitle ;
                  View.Port                   = ServerState.Instance.ServerService.Settings.Port ;
                  View.IpType                 = ServerState.Instance.ServerService.Settings.IpType ;
                  addressesStringList         = ConfigureIpList(ServerState.Instance.ServerService.Settings.IpType);
                  View.IpAddress              = ServerState.Instance.ServerService.Settings.IpAddress ;
                  View.ImplementationClassUID = ServerState.Instance.ServerService.Settings.ImplementationClass ;
                  View.ImplementationVersion  = ServerState.Instance.ServerService.Settings.ImplementationVersionName ;
                  View.ServiceDisplayName     = ServerState.Instance.ServerService.ServiceName ;
                  View.ServiceDecription      = ServerState.Instance.ServerService.Settings.Description ;
                  View.ServiceStartupMode     = ServerState.Instance.ServerService.Settings.StartMode ;            

                  View.CanChangeServiceDescription = false ;
                  View.CanShowServerDelete = CanShowServerDelete();
                  View.CanDeleteServer             = true  && ServerState.Instance.ServiceAdmin != null ;
                  View.CanAddServer                = false ;
               }
               
               View.CanChangeServiceDisplayName = false ;
               
               UpdateIpControls();

               __IsDirty = false ;
            }

            private const string ShowServerDelete = "ShowServerDelete";

            public bool CanShowServerDelete()
            {
               string canShow = ConfigurationManager.AppSettings[ShowServerDelete];
               bool show = true;

               if (string.IsNullOrEmpty(canShow))
                  return true;

               if (!bool.TryParse(canShow, out show))
                  return true;

               return show;
            }

            private void UpdateServerSettings ( ServerSettings settings )
            {
               settings.AETitle   = View.AeTitle ;
               settings.IpAddress = View.IpAddress == Constants.BothIp ? "*" : View.IpAddress ;
               settings.Port      = View.Port ;
               settings.StartMode = View.ServiceStartupMode ;

               settings.ImplementationClass       = View.ImplementationClassUID ;
               settings.ImplementationVersionName = View.ImplementationVersion ;
               settings.Description               = View.ServiceDecription ;
               
               settings.IpType = View.IpType ;
            }

            private void CreateServiceAdmin ( string serviceName )
            {
               ServiceAdministrator serviceAdmin ;
               List <string> services ;
                     
                     
               serviceAdmin = new ServiceAdministrator ( ServerState.Instance.BaseDirectory ) ;
               services     = new List <string> ( ) ;

               
                     
               services.Add ( serviceName ) ;
                     
               serviceAdmin.Initialize(services);

               if ( serviceAdmin.IsLocked )
               {
                  throw new InvalidOperationException ( "PACS Framework locked." );
               }

               ServerState.Instance.ServiceAdmin = serviceAdmin ;
            }

            private void InstallAddIns ( string [ ] addIns, string[] configurationAddIns, string serviceName )
            {
               string addInsDirectory = Path.Combine(Path.Combine(ServerState.Instance.ServiceAdmin.BaseDirectory, serviceName), "AddIns");
               string configurationDirectory = Path.Combine(Path.Combine(ServerState.Instance.ServiceAdmin.BaseDirectory, serviceName), "Configuration");

               Shell.InstallAddIns ( addIns, addInsDirectory );
               Shell.InstallAddIns ( configurationAddIns, configurationDirectory ) ;

               CreateAddInConfigurationFile ( Path.Combine ( ServerState.Instance.ServiceAdmin.BaseDirectory, serviceName ) ) ;
            }

            private void CreateAddInConfigurationFile ( string serviceDirectory ) 
            {
               string addInConfigurationFile ;
               System.Configuration.Configuration config ;
               System.Configuration.ConfigXmlDocument xml = new ConfigXmlDocument ( ) ;
               XmlNodeList nodes ;
                     
                     
                     
               addInConfigurationFile = Path.Combine ( serviceDirectory, "service.config" ) ;
               config = ConfigurationManager.OpenExeConfiguration ( System.Configuration.ConfigurationUserLevel.None ) ;
                     
               config.SaveAs ( addInConfigurationFile ) ;
                     
               xml.Load ( addInConfigurationFile ) ;
                     
               nodes = xml.GetElementsByTagName ( "appSettings" ) ;
                     
               if ( nodes.Count > 0 )
               {
                  nodes [ 0 ].ParentNode.RemoveChild ( nodes [ 0 ] ) ;
                        
                  xml.Save ( addInConfigurationFile ) ;
               }
            }

            private bool ValidateAETitle ( )
            {
               if ( View.AeTitle.Length == 0 || View.AeTitle.Length > 16 ) 
               {
                  View.AETitelValidationMessage ( "AE Title can't be empty and must be less than 16 characters." ) ;
                  
                  return false ;
               }
               else if ( View.AeTitle.ToUpper ( ) != View.AeTitle )
               {
                  View.AETitelValidationMessage ( "AE Title must be in upper case letters." ) ;
                  
                  return false ;
               }
               else
               {
                  View.AETitelValidationMessage ( "" ) ;
                  
                  return true ;
               }
            }

            private void InitializeStorageAddinsSettings()
            {
               IStorageDataAccessAgent storageDataAccess = DataAccessServices.GetDataAccessService<IStorageDataAccessAgent>();

               if (storageDataAccess != null && storageDataAccess is StorageDbDataAccessAgent)
               {
                  StorageModuleConfigurationManager storageConfig = ServiceLocator.Retrieve<StorageModuleConfigurationManager>();

                  if (storageConfig.IsLoaded)
                  {
                     StorageAddInsConfiguration settings = storageConfig.GetStorageAddInsSettings(ServerState.Instance.ServiceName);
                     if (settings != null)
                     {
                        if (settings.StoreAddIn.AutoCreateFolderLocations != AutoCreateLocationsDefault)
                        {
                           settings.StoreAddIn.AutoCreateFolderLocations = AutoCreateLocationsDefault;
                           storageConfig.SetStorageAddinsSettings(settings);
                           storageConfig.Save();
                        }
                     }
                  }
               }
      }

         #endregion
         
         #region Properties


            public bool __IsDirty { get; set; }
            
            
         #endregion
         
         #region Events
         
            void Instance_ServerServiceChanged(object sender, EventArgs e)
            {
               ConfigureView ( ) ;
            }

            void View_AddServer ( object sender, EventArgs e )
            {
               ServerSettings settings ;
               DicomService   service ;

               if ( null == ServerState.Instance.ServiceAdmin ) 
               {
                  CreateServiceAdmin ( ServerState.Instance.ServiceName ) ;
               }

               settings = new ServerSettings ( ) ;

               UpdateServerSettings ( settings ) ;

               string[] addIns = GetAddIns();
               //string [] addIns =  new string [] { 
               //   "Leadtools.Medical.AutoCopy.AddIn.dll",
               //   "Leadtools.Medical.PatientUpdater.AddIn.dll",
               //   "Leadtools.Medical.Storage.Addins.dll",
               //   "Leadtools.Medical.Forwarder.AddIn.dll", 
               //};

               string[] configurationAddIns = GetConfigurationAddIns();
               //string[] configurationAddIns = new string[] {
               //   "Leadtools.Medical.Ae.Configuration.dll",
               //   "Leadtools.Medical.Logging.Addin.dll",
               //   "Leadtools.Medical.License.Configuration.dll",
               //};

               InstallAddIns ( addIns, configurationAddIns, settings.AETitle ) ;
               
               // Delete the advanced.config if it exsists
               // It might be left over from a previous uninstall
               string configLocation = Path.Combine(Path.Combine(ServerState.Instance.ServiceAdmin.BaseDirectory, settings.AETitle), "advanced.config");
               try
               {
                  if (File.Exists(configLocation))
                  {
                     File.Delete(configLocation);
                  }
               }
               catch (Exception)
               {
               }
                     
               service = ServerState.Instance.ServiceAdmin.InstallService ( settings ) ;

               StorageModuleConfigurationManager sotrageConfigManager = ServiceLocator.Retrieve <StorageModuleConfigurationManager> ( ) ;
               LoggingModuleConfigurationManager loggingConfigManager = ServiceLocator.Retrieve <LoggingModuleConfigurationManager> ( ) ;
               
               sotrageConfigManager.Load ( service.ServiceDirectory ) ;
               loggingConfigManager.Load ( service.ServiceDirectory ) ;
               
               ServerState.Instance.ServerService = service ;

#if (LEADTOOLS_V19_OR_LATER_MEDICAL_VERIFY_ADDINS) || (LEADTOOLS_V19_OR_LATER)
               ServerState.Instance.ServerService.Message += new EventHandler<MessageEventArgs>(Shell.ServerService_Message);
#endif
               InitializeStorageAddinsSettings();
               
               AddConfigAssemblies(service.ServiceDirectory, "Leadtools.Medical.Logging.Addin.dll");
               GlobalPacsUpdater.ModifyGlobalPacsConfiguration ( DicomDemoSettingsManager.ProductNameStorageServer, settings.AETitle, GlobalPacsUpdater.ModifyConfigurationType.Add) ;
               
               LocalAuditLogQueue.AddAuditMessage ( AuditMessages.ServerServiceCreated.Key,
                                                    string.Format ( AuditMessages.ServerServiceCreated.Message, service.ServiceName, service.Settings.AETitle, service.Settings.IpAddress, service.Settings.Port ) ) ;
            }

            private void AddConfigAssemblies(string serviceDirectory, params string[] assemblies)
            {
               AdvancedSettings settings = AdvancedSettings.Open(serviceDirectory);

               if (settings != null)
               {
                  settings.SetConfigAssemblies(assemblies);
                  settings.Save();
               }
            }
            
            void View_DeleteServer ( object sender, EventArgs e )
            {
               if ( null != ServerState.Instance.ServerService )
               {
                  using (ConfirmWithReasonDialog confirmDlg = new ConfirmWithReasonDialog())
                  {
                     confirmDlg.Text = "Confirm Delete";

                     confirmDlg.Message = string.Format("Are you sure you want to delete {0}?\n\nType the reason for deleting {0}.",ServerState.Instance.ServerService.Settings.AETitle);

                     confirmDlg.ConfirmIcon = Resources.Warning_128;
                     
                     confirmDlg.ConfirmCheckBoxVisible = false;

                     if (confirmDlg.ShowDialog(View) != DialogResult.OK)
                     {
                        return;
                     }


                     string serviceName = ServerState.Instance.ServerService.ServiceName;
                     string additionalInfo = string.Format("\n\nReason for deleting: {0}", confirmDlg.Reason);

                     GlobalPacsUpdater.ModifyGlobalPacsConfiguration(DicomDemoSettingsManager.ProductNameStorageServer, serviceName, GlobalPacsUpdater.ModifyConfigurationType.Remove);

#if (LEADTOOLS_V19_OR_LATER_MEDICAL_VERIFY_ADDINS) || (LEADTOOLS_V19_OR_LATER)
                     ServerState.Instance.ServerService.Message -= new EventHandler<MessageEventArgs>(Shell.ServerService_Message);
#endif
                     ServerState.Instance.ServiceAdmin.UnInstallService(ServerState.Instance.ServerService);

                     ServerState.Instance.ServerService.Dispose();

                     StorageModuleConfigurationManager sotrageConfigManager = ServiceLocator.Retrieve<StorageModuleConfigurationManager>();
                     LoggingModuleConfigurationManager loggingConfigManager = ServiceLocator.Retrieve<LoggingModuleConfigurationManager>();

                     sotrageConfigManager.Unload();
                     loggingConfigManager.Unload();

                     ServerState.Instance.ServerService = null;

                     LocalAuditLogQueue.AddAuditMessage(AuditMessages.ServerServiceDeleted.Key,
                                                          string.Format(AuditMessages.ServerServiceDeleted.Message, serviceName) + additionalInfo);
                  }
               }
            }

            void View_AETitlechanged(object sender, EventArgs e)
            {
               if ( ValidateAETitle ( ) )
               {
                  __IsDirty = true ;
                  
                  if ( ServerState.Instance.ServerService == null ) 
                  {
                     View.ServiceDisplayName = View.AeTitle ;
                  }
                  
                  LocalAuditLogQueue.AddAuditMessage ( AuditMessages.AeTitleChanged.Key, 
                                                       string.Format ( AuditMessages.AeTitleChanged.Message, View.AeTitle ) ) ;
               }
            }

            void OnConfigureView ( object sender, EventArgs e )
            {
               ConfigureView ( ) ;
            }

            void View_IpAddressChanged ( object sender, EventArgs e )
            {
               __IsDirty = true ;
               
               LocalAuditLogQueue.AddAuditMessage ( AuditMessages.IpAddressChanged.Key, 
                                                    string.Format ( AuditMessages.IpAddressChanged.Message, View.IpAddress ) ) ;
            }
            
            void View_PortChanged ( object sender, EventArgs e )
            {
               __IsDirty = true ;
               
               LocalAuditLogQueue.AddAuditMessage ( AuditMessages.PortChanged.Key, 
                                                    string.Format ( AuditMessages.PortChanged.Message, View.Port ) ) ;
            }
            
            void View_ImplementationClassUIDChanged ( object sender, EventArgs e )
            {
               __IsDirty = true ;
               
               LocalAuditLogQueue.AddAuditMessage ( AuditMessages.ImplementationClassUIDChanged.Key,
                                                    string.Format ( AuditMessages.ImplementationClassUIDChanged.Message, View.ImplementationClassUID ) ) ;
            }
            
            void View_ImplementationVersionNameChanged(object sender, EventArgs e)
            {
               __IsDirty = true ;
               
               LocalAuditLogQueue.AddAuditMessage ( AuditMessages.ImplementationVersionNameChanged.Key,
                                                    string.Format ( AuditMessages.ImplementationVersionNameChanged.Message, View.ImplementationVersion ) ) ;
            }
            
            void View_ServiceStartModeChanged ( object sender, EventArgs e )
            {
               __IsDirty = true ;
               
               LocalAuditLogQueue.AddAuditMessage ( AuditMessages.ServiceStartModeChanged.Key,
                                                    string.Format ( AuditMessages.ServiceStartModeChanged.Message, View.ServiceStartupMode ) ) ;
            }

            void OnUpdateServerSettings ( object sender, EventArgs e ) 
            {
               if ( __IsDirty ) 
               {
                  UpdateSettings ( ) ;
               }
            }

            void OnCancelServerSettings ( object sender, EventArgs e ) 
            {
               if ( __IsDirty ) 
               {
                  ConfigureView ( ) ;
               }
            }
         
         #endregion
         
         #region Data Members
            
         #endregion
         
         #region Data Types Definition
         
            class ServerDefaultValues
            {
               public static string AeTitle                = ServerState.Instance.ServiceName ;
               public static int Port                      = 504 ;
               public static string IpAddress              = String.Empty ;
               public static string ImplementationClassUID = "1.2.840.114257.1123456" ;
               public static string ImplementationVersion  = "LTPACSF V20" ;
               public static string ServiceDisplayName     = "LEAD Storage Server" ;
               public static string ServiceDecription      = String.Empty ;
               public static string ServiceStartupMode     = "Automatic" ;
            }
            
            static class Constants
            {
               public const string BothIp = "All" ;
            }
            
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

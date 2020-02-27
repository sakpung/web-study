// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;
using Leadtools.Dicom.Server.Admin;
using Leadtools.Medical.Gateway.CFindAddin.DataTypes;
using Leadtools.Dicom.AddIn.Common;
using System.Net;
using Leadtools.Dicom.AddIn.Configuration;
using Leadtools.Medical.Gateway;
using Leadtools.Medical.Storage.AddIns;
using Leadtools.Medical.Storage.AddIns.Configuration;
using Leadtools.Demos.StorageServer.DataTypes;
using Leadtools.Medical.Winforms.Forwarder;
using System.ServiceProcess;
using System.Drawing;
using System.IO;
using Leadtools.Medical.Winforms;
using Leadtools.Medical.Logging.Addins;
using Leadtools.Demos.StorageServer.Properties;
using Leadtools.Dicom.AddIn;
using Leadtools.Dicom.AddIn.Interfaces;
using System.Diagnostics;
using Leadtools.DicomDemos;
using Leadtools.Medical.Winforms.SecurityOptions;

namespace Leadtools.Demos.StorageServer.UI
{
   partial class GatewaySettingsPresenter
   {
      #region Public
         
         #region Methods

            public void RunView ( GatewaySettingsView view ) 
            {
               __View = view ;
               
               __GatewayServers = new List<GatewayServer> ( ) ;
               
               if ( ServerState.Instance.ServerService != null )
               {
                  Init ( view ) ;
               }
               else
               {
                  view.Enabled = false ;
               }

               ServerState.Instance.ServerServiceChanged += new EventHandler ( Instance_ServerServiceChanged ) ;
               ServerState.Instance.LicenseChanged += new EventHandler(Instance_LicenseChanged);
            }

            void Instance_LicenseChanged(object sender, EventArgs e)
            {               
               // __View.Enabled = HasGateway();
            }
         
         #endregion
         
         #region Properties

            public GatewaySettingsView View
            {
               get
               {
                  return __View;
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
            
         #endregion
         
         #region Properties
            
         #endregion
         
         #region Data Types Definition
            
         #endregion
         
      #endregion
      
      #region Private
         
         #region Methods
         
            private void CreateGatewayServersList ( )
            {
               AdvancedSettings serverSettings = AdvancedSettings.Open ( ServerState.Instance.ServerService.ServiceDirectory ) ;
               
               
               List<string> gatewaysList = serverSettings.GetAddInCustomData <List<string>> ( this.GetType ( ).Name, typeof (GatewayServer).Name ) ;
               
               if ( null == gatewaysList ) 
               {
                  gatewaysList = new List<string> ( ) ;
               }
               
               ServerState.Instance.GatewayServers = gatewaysList ;
               
               ServerState.Instance.ServiceAdmin.LoadServices ( gatewaysList ) ;
               
               foreach ( string gatewayService in gatewaysList ) 
               {
                  if ( ServerState.Instance.ServiceAdmin.Services.ContainsKey ( gatewayService ) )
                  {
                     DicomService gateway = ServerState.Instance.ServiceAdmin.Services [ gatewayService ] ;
                     
                     AdvancedSettings gatewaySettings = AdvancedSettings.Open ( gateway.ServiceDirectory ) ;
                     
                     GatewayServer server = gatewaySettings.GetAddInCustomData <GatewayServer> ( typeof ( GatewaySession ).Name, typeof ( GatewayServer ).Name ) ;
                     
                     if ( null != server ) 
                     {
                        __GatewayServers.Add ( server ) ;
                     }

                     gateway.StatusChange += new EventHandler ( gateway_StatusChange ) ;
                  }
               }
            }

            private void Init ( GatewaySettingsView view )
            {
               CreateGatewayServersList ( ) ;
               
               ConfigureView ( view ) ;

               RegisterEvents ( view ) ;               
            }

            private void RegisterEvents ( GatewaySettingsView view )
            {
               view.GatewaysItemsGridView.AddItem    += new EventHandler ( GatewaysItemsGridView_AddItem ) ;
               view.GatewaysItemsGridView.DeleteItem += new EventHandler ( GatewaysItemsGridView_DeleteItem ) ;
               view.GatewaysItemsGridView.ModifyItem += new EventHandler ( GatewaysItemsGridView_ModifyItem ) ;

               view.GatewaysItemsGridView.SelectedItemChanged += new EventHandler ( GatewaysItemsGridView_SelectedItemChanged ) ;

               view.RemoteServersItemsGridView.AddItem    += new EventHandler ( RemoteServersItemsGridView_AddItem ) ;
               view.RemoteServersItemsGridView.DeleteItem += new EventHandler ( RemoteServersItemsGridView_DeleteItem ) ;
               view.RemoteServersItemsGridView.ModifyItem += new EventHandler ( RemoteServersItemsGridView_ModifyItem ) ;

               view.NumberOfTimesToUseSecondaryServerChanged += new EventHandler ( view_NumberOfTimesToUseSecondaryServerChanged ) ;
               
               EventBroker.Instance.Subscribe <ServerSettingsAppliedEventArgs> ( ServerSettingsAppliedHandler ) ;
            }

            private void UnregisterEvents ( GatewaySettingsView view )
            {
               view.GatewaysItemsGridView.AddItem    -= new EventHandler(GatewaysItemsGridView_AddItem);
               view.GatewaysItemsGridView.DeleteItem -= new EventHandler(GatewaysItemsGridView_DeleteItem);
               view.GatewaysItemsGridView.ModifyItem -= new EventHandler(GatewaysItemsGridView_ModifyItem);

               view.RemoteServersItemsGridView.AddItem    -= new EventHandler ( RemoteServersItemsGridView_AddItem ) ;
               view.RemoteServersItemsGridView.DeleteItem -= new EventHandler ( RemoteServersItemsGridView_DeleteItem ) ;
               view.RemoteServersItemsGridView.ModifyItem -= new EventHandler ( RemoteServersItemsGridView_ModifyItem ) ;
               
               view.NumberOfTimesToUseSecondaryServerChanged += new EventHandler ( view_NumberOfTimesToUseSecondaryServerChanged ) ;
               
               EventBroker.Instance.Unsubscribe <ServerSettingsAppliedEventArgs> ( ServerSettingsAppliedHandler ) ;
            }
            
            private void ConfigureView ( GatewaySettingsView view )
            {
               Gateways gateways = new Gateways ( ) ;
               
               foreach ( GatewayServer gateway in __GatewayServers )
               {
                  CreateGatewayRow ( gateways, gateway ) ;
               }
               
               
               __GatewaySource = new BindingSource ( ) ;
               __GatewaySource.DataSource = gateways ;
               __GatewaySource.DataMember = gateways.GatewayServer.TableName ;
               
               view.GatewaysItemsGridView.DataSource = __GatewaySource ;
               
               FormatGatewayGridViewStyles ( view.GatewaysItemsGridView, gateways ) ;
               AddServiceStateImageColumn  ( view.GatewaysItemsGridView, gateways ) ;
               
               __RemoteServersSource = new BindingSource ( ) ;
               
               __RemoteServersSource.DataSource = __GatewaySource ;
               __RemoteServersSource.DataMember = gateways.Relations [ 0 ].RelationName ;
               
               view.RemoteServersItemsGridView.DataSource = __RemoteServersSource ;
               
               FormatRemoteServersGridViewStyles ( view.RemoteServersItemsGridView, gateways ) ;
               
               view.NumberOfTimesToUseSecondaryServer = ( __GatewayServers.Count > 0 ) ? Math.Min ( Math.Max ( __GatewayServers [ 0 ].NumberOfTimesToUseSecondaryServer, 1 ), 100 ) : 1 ;
               
               if ( __ServerController == null ) 
               {
                  __ServerController = new GatewayServerControlPresenter ( ) ;
                  
                  __ServerController.RunView ( __View.GatewaysItemsGridView, __GatewaySource ) ;
               }
               else
               {
                  __ServerController.Reconfigure ( __GatewaySource ) ;
               }
               
               if ( __RemoteController == null ) 
               {
                  __RemoteController = new RemoteServerSortPresenter ( ) ;
                  
                  __RemoteController.RunView ( __View.RemoteServersItemsGridView.MainToolStrip, __GatewaySource, __RemoteServersSource ) ;
               }
               else
               {
                  __RemoteController.Reconfigure ( __GatewaySource, __RemoteServersSource ) ;
               }
            }

            private void AddServiceStateImageColumn ( ItemsGridView itemsGridView, Gateways source )
            {
               if ( !itemsGridView.ItemsDataGridView.Columns.Contains ( Constants.ServiceStateColumn ) )
               {
                  DataGridViewImageColumn imageColumn = new DataGridViewImageColumn (){ Name=Constants.ServiceStateColumn } ;                  
                  
                  imageColumn.Width       = 16 ;                  
                  imageColumn.HeaderText  = "State" ;                  
                  itemsGridView.ItemsDataGridView.Columns.Add ( imageColumn ) ;
                  imageColumn.DefaultCellStyle.NullValue = Resources.Stopped;
                  imageColumn.DisplayIndex = 0 ;
               }

               itemsGridView.ItemsDataGridView.CellFormatting += new DataGridViewCellFormattingEventHandler(ItemsDataGridView_CellFormatting);                                       
            }

            void ItemsDataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
            {
               try
               {
                  DataGridView view = sender as DataGridView;

                  if (view != null && view.Columns[e.ColumnIndex].Name == Constants.ServiceStateColumn)
                  {
                     DataGridViewRow row = view.Rows[e.RowIndex];
                     Gateways source = __GatewaySource.DataSource as Gateways;
                     GatewayServer server = (GatewayServer)row.Cells[source.GatewayServer.GatewayServerColumn.ColumnName].Value;

                     if (server != null)
                     {
                        if (ServerState.Instance.ServiceAdmin.Services.ContainsKey(server.ServiceName))
                        {
                           DicomService service = ServerState.Instance.ServiceAdmin.Services[server.ServiceName];

                           UpdateGatewayServiceStatus(service, e);
                        }
                     }
                  }
               }
               catch ( Exception ){}
            }

            private void UpdateGatewayServiceStatus(DicomService service, DataGridViewRow gatewayRow)
            {
               if ( service.Status == ServiceControllerStatus.Stopped )
               {                  
                  gatewayRow.Cells[Constants.ServiceStateColumn].Value = Resources.Stopped;                  
               }
               else
               {                
                  gatewayRow.Cells[Constants.ServiceStateColumn].Value = Resources.Running;
               }               
            }

            private void UpdateGatewayServiceStatus(DicomService service, DataGridViewCellFormattingEventArgs e)
            {
               if (service.Status == ServiceControllerStatus.Stopped)
               {
                  e.Value = Resources.Stopped;
               }
               else
               {
                  e.Value = Resources.Running;
               }
            }

            private void FormatGatewayGridViewStyles ( ItemsGridView itemsGridView, Gateways source )
            {
               itemsGridView.ItemsDataGridView.Columns [ source.GatewayServer.AETitleColumn.ColumnName ].HeaderText     = "AE Title" ;
               itemsGridView.ItemsDataGridView.Columns [ source.GatewayServer.IpAddressColumn.ColumnName ].HeaderText   = "IP Address" ;
               itemsGridView.ItemsDataGridView.Columns[source.GatewayServer.PortColumn.ColumnName].HeaderText           = "Port"; 
               itemsGridView.ItemsDataGridView.Columns[source.GatewayServer.SecureColumn.ColumnName].HeaderText         = "Secure (TLS)";
               itemsGridView.ItemsDataGridView.Columns [ source.GatewayServer.GatewayServerColumn.ColumnName ].Visible  = false ;
            }
            
            private void FormatRemoteServersGridViewStyles(ItemsGridView itemsGridView, Gateways source )
            {
               itemsGridView.ItemsDataGridView.Columns [ source.RemoteServer.AETitleColumn.ColumnName ].HeaderText       = "AE Title" ;
               itemsGridView.ItemsDataGridView.Columns [ source.RemoteServer.IpAddressColumn.ColumnName ].HeaderText     = "IP Address" ;
               itemsGridView.ItemsDataGridView.Columns [ source.RemoteServer.PortColumn.ColumnName].HeaderText           = "Port";
               itemsGridView.ItemsDataGridView.Columns [ source.RemoteServer.SecurePortColumn.ColumnName ].HeaderText    = "Secure Port" ;
               itemsGridView.ItemsDataGridView.Columns [ source.RemoteServer.UseSecurePortColumn.ColumnName ].HeaderText = "Secure (TLS)" ;
               
               itemsGridView.ItemsDataGridView.Columns [ source.RemoteServer.GatewayServerAEColumn.ColumnName ].Visible      = false ;
               itemsGridView.ItemsDataGridView.Columns [ source.RemoteServer.RemoteServerSettingsColumn.ColumnName ].Visible = false ;
               itemsGridView.ItemsDataGridView.Columns [ source.RemoteServer.SecurePortColumn.ColumnName ].Visible           = false;
            }

            private Gateways.GatewayServerRow CreateGatewayRow ( Gateways gateways, GatewayServer gateway )
            {
               Gateways.GatewayServerRow r1 = gateways.GatewayServer.AddGatewayServerRow ( gateway.Server.AETitle, 
                                                                                           gateway.Server.Address, 
                                                                                           gateway.Server.Port == 0 ? gateway.Server.SecurePort : gateway.Server.Port, 
                                                                                           gateway.Server.SecurePort > 0, 
                                                                                           gateway ) ;
               
               foreach ( AeInfo remoteServer in gateway.RemoteServers )
               {
                  AddGatewayRemoteServerRow ( gateways, r1, remoteServer ) ;
               }
               
               return r1 ;
            }

            private static void AddGatewayRemoteServerRow ( Gateways gateways, Gateways.GatewayServerRow r1, AeInfo remoteServer )
            {
               gateways.RemoteServer.AddRemoteServerRow( remoteServer.AETitle, 
                                                         remoteServer.Address, 
                                                         remoteServer.Port == 0 ? remoteServer.SecurePort : remoteServer.Port, 
                                                         remoteServer.SecurePort, 
                                                         r1, 
                                                         remoteServer,
                                                         remoteServer.SecurePort > 0);
            }
            
            private string[] GetIpAddresses ( ) 
            {
               if ( null == __IpAddresses ) 
               {
                  IPAddress[] addresses = Dns.GetHostAddresses ( Dns.GetHostName ( ) ) ;
                  List<string> addressesStringList = new List<string> ( ) ;


                  foreach ( IPAddress address in addresses ) 
                  {
                     addressesStringList.Add ( address.ToString ( ) ) ;
                  }

                  __IpAddresses = addressesStringList.ToArray ( ) ;
               }
               
               return __IpAddresses ;
            }
            
            private static void UpdateGatewaySettings(ServerSettings settings)
            {
               settings.ImplementationClass = ServerState.Instance.ServerService.Settings.ImplementationClass ;
               settings.ImplementationVersionName = ServerState.Instance.ServerService.Settings.ImplementationVersionName ;
               
               settings.AddInTimeout = ServerState.Instance.ServerService.Settings.AddInTimeout ;
               settings.AdministrativePipes = ServerState.Instance.ServerService.Settings.AdministrativePipes ;
               settings.AllowAnonymous = ServerState.Instance.ServerService.Settings.AllowAnonymous ;
               
               settings.ClientTimeout = ServerState.Instance.ServerService.Settings.ClientTimeout ;
               
               settings.MaxClients = ServerState.Instance.ServerService.Settings.MaxClients ;
               settings.MaxPduLength = ServerState.Instance.ServerService.Settings.MaxPduLength ;
               settings.NoDelay = ServerState.Instance.ServerService.Settings.NoDelay ;
               settings.ReceiveBufferSize = ServerState.Instance.ServerService.Settings.ReceiveBufferSize ;
               settings.ReconnectTimeout = ServerState.Instance.ServerService.Settings.ReconnectTimeout ;
               settings.SendBufferSize = ServerState.Instance.ServerService.Settings.SendBufferSize ;
               settings.StartMode = ServerState.Instance.ServerService.Settings.StartMode ;
               settings.TemporaryDirectory = ServerState.Instance.ServerService.Settings.TemporaryDirectory ;
               settings.RelationalQueries = ServerState.Instance.ServerService.Settings.RelationalQueries;
            }

            private void InstallGateway ( ServerSettings settings )
            {
               DicomService  gatewayService ;
               GatewayServer gatewayServer   = null ;
               Gateways.GatewayServerRow gatewayRow = null ;
               AeInfo        gatewayAe ;
               Gateways      gateways  = null ;
               
                              
               //
               // Set License File to the server license file
               //
               settings.LicenseFile = ServerState.Instance.ServerService.Settings.LicenseFile;
               gatewayService = ServerState.Instance.ServiceAdmin.InstallService ( settings ) ;
               
               try
               {
                  gatewayServer  = new GatewayServer ( ) ;
                  gatewayAe      = new AeInfo ( ) ;
                  gateways       = (Gateways) __GatewaySource.DataSource ;
                  
                  
                  gatewayAe.AETitle    = settings.AETitle ;
                  gatewayAe.Address    = settings.IpAddress ;
                  gatewayAe.Port       = settings.Secure ? 0 : settings.Port ;
                  gatewayAe.SecurePort = settings.Secure ? settings.Port : 0 ;
                  
                  gatewayServer.Server                            = gatewayAe ;
                  gatewayServer.ServiceName                       = gatewayService.ServiceName ;
                  gatewayServer.NumberOfTimesToUseSecondaryServer = View.NumberOfTimesToUseSecondaryServer ;
                  
                  gatewayRow = CreateGatewayRow ( gateways, gatewayServer ) ;
                  
                  __GatewayServers.Add ( gatewayServer ) ;

                  ServerState.Instance.GatewayServers.Add ( gatewayServer.ServiceName ) ;
                  
                  UpdateGatewayServersInMainServerSettings ( ) ;
                  
                  AdvancedSettings gatewaySettings = AdvancedSettings.Open ( gatewayService.ServiceDirectory ) ;
                  
                  gatewaySettings.SetAddInCustomData <GatewayServer> ( typeof ( GatewaySession ).Name, typeof ( GatewayServer ).Name, gatewayServer ) ;
                  gatewaySettings.SetConfigAssemblies("Leadtools.Medical.Logging.AddIn.dll");
                  
                  InstallAddins ( gatewayService ) ;
               
                  IgnoreStroageFindMoveAddins ( gatewaySettings ) ;
                  
                  SetStorageAddInConfig ( gatewayService.ServiceDirectory ) ;
                  SetLoggingAddInConfig ( gatewayService.ServiceDirectory ) ;
                  SetForwardAddinConfig ( gatewaySettings ) ;
                  SetSecurityAddinConfig( gatewaySettings );


                  gatewaySettings.Save ( ) ;
                  
                  GlobalPacsUpdater.ModifyGlobalPacsConfiguration ( DicomDemoSettingsManager.ProductNameGateway, gatewayService.ServiceName, GlobalPacsUpdater.ModifyConfigurationType.Add ) ;
                  
                  foreach ( DataGridViewRow serverRow in __View.GatewaysItemsGridView.ItemsDataGridView.Rows ) 
                  {
                     if ( serverRow.Cells [ gateways.GatewayServer.GatewayServerColumn.ColumnName ].Value == gatewayServer )
                     {
                        UpdateGatewayServiceStatus ( gatewayService, serverRow ) ;
                        
                        break ;
                     }
                  }
                  
                  gatewayService.StatusChange += new EventHandler ( gateway_StatusChange ) ;
               }
               catch ( Exception )
               {
                  if ( null != gateways && null != gatewayRow && gatewayRow.Table == gateways.GatewayServer ) 
                  {
                     gateways.GatewayServer.Rows.Remove ( gatewayRow ) ;
                  }
                  
                  if ( null != gatewayServer && __GatewayServers.Contains ( gatewayServer ) )
                  {
                     __GatewayServers.Remove ( gatewayServer ) ;
                  }
                  
                  if ( ServerState.Instance.GatewayServers.Contains ( gatewayServer.ServiceName ) )
                  {
                     ServerState.Instance.GatewayServers.Add ( gatewayServer.ServiceName ) ;
                  }
                  
                  GlobalPacsUpdater.ModifyGlobalPacsConfiguration ( DicomDemoSettingsManager.ProductNameGateway, gatewayService.ServiceName, GlobalPacsUpdater.ModifyConfigurationType.Remove ) ;
                  
                  if ( null != gatewayService ) 
                  {
                     ServerState.Instance.ServiceAdmin.UnInstallService ( gatewayService ) ;
                  }
                  
                  UpdateGatewayServersInMainServerSettings ( ) ;
                  
                  throw ;
               }
            }

            private void UpdateGatewayServersInMainServerSettings ( )
            {
               if ( null != ServerState.Instance.ServerService ) 
               {
                  AdvancedSettings serverSettings = AdvancedSettings.Open ( ServerState.Instance.ServerService.ServiceDirectory ) ;
                  
                  serverSettings.SetAddInCustomData <List<string>> ( this.GetType ( ).Name, typeof ( GatewayServer ).Name, ServerState.Instance.GatewayServers ) ;                                    
                  serverSettings.Save ( ) ;
               }
            }

            private void SetStorageAddInConfig ( string gatewayServiceDirectory )
            {
               StorageModuleConfigurationManager serverStoreConfigManger  = ServiceLocator.Retrieve <StorageModuleConfigurationManager> ( ) ;
               using ( StorageModuleConfigurationManager gatewayStoreConfigManger = new StorageModuleConfigurationManager ( false ) ) 
               {
                  gatewayStoreConfigManger.Load ( gatewayServiceDirectory ) ;
                  
                  if ( gatewayStoreConfigManger.IsLoaded && serverStoreConfigManger.IsLoaded )
                  {
                     StorageAddInsConfiguration storageaddinSettings = serverStoreConfigManger.GetStorageAddInsSettings ( ) ;
                     
                     gatewayStoreConfigManger.SetStorageAddinsSettings ( storageaddinSettings ) ;
                  }
               }
            }
            
            private void SetLoggingAddInConfig ( string gatewayServiceDirectory )
            {
               LoggingModuleConfigurationManager serverLoggingConfigManger  = ServiceLocator.Retrieve <LoggingModuleConfigurationManager> ( ) ;
               
               using ( LoggingModuleConfigurationManager gatewayLoggingConfigManger = new LoggingModuleConfigurationManager ( false ) )
               {
                  gatewayLoggingConfigManger.Load ( gatewayServiceDirectory ) ;
                  
                  if ( gatewayLoggingConfigManger.IsLoaded && serverLoggingConfigManger.IsLoaded )
                  {
                     LoggingState loggingState = serverLoggingConfigManger.GetLoggingState ( ) ;
                     
                     gatewayLoggingConfigManger.SetLoggingState ( loggingState ) ;
                  }
               }
            }
            
            private void SetForwardAddinConfig ( AdvancedSettings gatewaySetting ) 
            {
               AdvancedSettings serviceSettings = AdvancedSettings.Open ( ServerState.Instance.ServerService.ServiceDirectory ) ;
               
               ForwardOptions options = serviceSettings.GetAddInCustomData<ForwardOptions>(ForwardManagerPresenter._addinName, "ForwardOptions");
               
               gatewaySetting.SetAddInCustomData <ForwardOptions> ( ForwardManagerPresenter._addinName, "ForwardOptions", options ) ;
            }

           private void SetSecurityAddinConfig(AdvancedSettings gatewaySetting)
           {
              AdvancedSettings serviceSettings = AdvancedSettings.Open(ServerState.Instance.ServerService.ServiceDirectory);

              DicomSecurityOptions options = serviceSettings.GetAddInCustomData<DicomSecurityOptions>(SecurityOptionsPresenter.AddinName, SecurityOptionsPresenter.CustomDataName);

              gatewaySetting.SetAddInCustomData<DicomSecurityOptions>(SecurityOptionsPresenter.AddinName, SecurityOptionsPresenter.CustomDataName, options);
           }

           private void InstallAddins ( DicomService gatewayService )
            {
               string addInsDirectory ;
               string configDirectory ;
               
               addInsDirectory = Path.Combine ( gatewayService.ServiceDirectory, "AddIns" ) ;
               configDirectory = Path.Combine ( gatewayService.ServiceDirectory, "Configuration" ) ;

               Shell.InstallAddIns ( GetAddIns(), addInsDirectory ) ;
               Shell.InstallAddIns(GetConfigurationAddIns(), configDirectory);               
            }

            private void IgnoreStroageFindMoveAddins ( AdvancedSettings serviceSettings )
            {
               serviceSettings.SetIgnoreType ( "CFind", typeof ( Leadtools.Medical.Storage.AddIns.FindAddIn ) ) ;
               serviceSettings.SetIgnoreType ( "CMove", typeof ( Leadtools.Medical.Storage.AddIns.MoveAddIn ) ) ;
            }

            internal static void SetGatwayServerAddInSettings ( GatewayServer server )
            {
               if ( ServerState.Instance.ServiceAdmin.Services.ContainsKey ( server.ServiceName ) )
               {
                  DicomService gatewayService = ServerState.Instance.ServiceAdmin.Services [ server.ServiceName ] ;
                  
                  AdvancedSettings gatewaySettings = AdvancedSettings.Open ( gatewayService.ServiceDirectory ) ;
                  
                  gatewaySettings.SetAddInCustomData <GatewayServer> ( typeof ( GatewaySession ).Name, typeof ( GatewayServer ).Name, server ) ;
                  
                  gatewaySettings.Save ( ) ;
               }
            }
            
         #endregion
         
         #region Properties
         
            private GatewayServerControlPresenter __ServerController { get ; set ; }
            private RemoteServerSortPresenter     __RemoteController { get ; set ; }
            
         #endregion
         
         #region Events
         
            private void Instance_ServerServiceChanged ( object sender, EventArgs e )
            {
               try
               {
                  if ( null == ServerState.Instance.ServerService ) 
                  {
                     UnregisterEvents ( __View ) ;
                     
                     __View.Enabled = false ;
                     
                     if ( __GatewayServers.Count > 0  )
                     {
                        DeleteAllGateways ( ) ;
                     }
                  }
                  else
                  {                     
                     __View.Enabled = HasGateway() ;
                     
                     if ( null == ServerState.Instance.GatewayServers || ServerState.Instance.GatewayServers.Count > 0 )
                     {
                        CreateGatewayServersList ( ) ;
                        
                        ConfigureView ( __View ) ;
                     }
                     
                     RegisterEvents ( __View ) ;
                  }
               }
               catch ( Exception exception ) 
               {
                  __View.ShowErrorMessage ( exception.Message ) ;
               }
               
            }

            private bool HasGateway()
            {
               ILicense license = ServerState.Instance.License;

               return (license != null && (license.IsFeatureValid(ServerFeatures.Gateway) || (license.IsFeatureEvaluation(ServerFeatures.Gateway) 
                       && !license.IsFeatureExpired(ServerFeatures.Gateway))));
            }
            
            private void ServerSettingsAppliedHandler ( object sender, ServerSettingsAppliedEventArgs e ) 
            {
               try
               {
                  if ( ServerState.Instance.ServiceAdmin != null && ServerState.Instance.ServerService != null ) 
                  {
                     foreach ( GatewayServer server in __GatewayServers )
                     {
                        DicomService gatewayService ;
                        
                        
                        if ( ServerState.Instance.ServiceAdmin.Services.ContainsKey ( server.ServiceName ) )
                        {
                           AdvancedSettings gatewaySettings ;
                           
                           
                           gatewayService = ServerState.Instance.ServiceAdmin.Services [ server.ServiceName ] ;
                           
                           gatewaySettings = AdvancedSettings.Open ( gatewayService.ServiceDirectory ) ;
                           
                           SetStorageAddInConfig ( gatewayService.ServiceDirectory ) ;
                           SetLoggingAddInConfig ( gatewayService.ServiceDirectory ) ;
                           SetForwardAddinConfig ( gatewaySettings ) ;
                           SetSecurityAddinConfig ( gatewaySettings ) ;
                           
                           gatewaySettings.Save ( ) ;
                           
                           UpdateGatewaySettings ( gatewayService.Settings ) ;
                           
                           gatewayService.Settings = gatewayService.Settings ;
                        }
                     }
                  }
               }
               catch ( Exception exception ) 
               {
                  __View.ShowErrorMessage ( exception.Message ) ;
               }
            }
            
            private void GatewaysItemsGridView_AddItem (object sender, EventArgs e )
            {
               try
               {
                  using ( AeInfoDetails aeInfoDlg = new AeInfoDetails ( ) )
                  {
                     aeInfoDlg.DialogTitle = "Create Gateway Server" ;
                     aeInfoDlg.ConfirmText = "Create" ;
                     aeInfoDlg.Port        = 104 ;
                     
                     aeInfoDlg.SetIpAddressList ( GetIpAddresses ( ) ) ;
                     
                     if ( aeInfoDlg.ShowDialog ( __View ) == DialogResult.OK ) 
                     {
                        ServerSettings settings = new ServerSettings ( ) ;
                        
                        
                        var existServer = __GatewayServers.Where ( n=>n.Server.AETitle == aeInfoDlg.AETitle || n.ServiceName == aeInfoDlg.AETitle ).FirstOrDefault ( ) ;
                        
                        if ( null != existServer ) 
                        {
                           __View.ShowErrorMessage ( "AE Title already exists or matches another server name." ) ;
                        }
                        else
                        {
                           settings.AETitle    = aeInfoDlg.AETitle ;
                           settings.IpAddress  = aeInfoDlg.Address ;
                           settings.Port       = aeInfoDlg.Port ;
                           settings.Secure     = aeInfoDlg.Secure ;
                           
                           settings.AllowMultipleConnections = true ;
#if !LEADTOOLS_V19_OR_LATER
                           settings.EnableLog = true ; //login configuration Addin will handle the logging state
#endif // #if !LEADTOOLS_V19_OR_LATER

                           UpdateGatewaySettings ( settings ) ;

                           InstallGateway ( settings ) ;
                        }
                     }
                  }
               }
               catch ( Exception exception ) 
               {
                  __View.ShowErrorMessage ( "Failed to create gateway.\n" + exception.Message ) ;
               }
            }

      private void GatewaysItemsGridView_DeleteItem(object sender, EventArgs e)
      {
         try
         {
            if (null != __GatewaySource.Current)
            {
               DataRowView selectedRow = (DataRowView)__GatewaySource.Current;
               Gateways.GatewayServerRow gatewayRow = (Gateways.GatewayServerRow)selectedRow.Row;
               GatewayServer gatewayServer = (GatewayServer)gatewayRow.GatewayServer;

               bool confirm = __View.ShowConfirmMessage(string.Format("Are you sure you want to remove {0}?", gatewayServer.ServiceName));
               if (confirm)
               {
                  ServerState.Instance.ServiceAdmin.UnInstallService(ServerState.Instance.ServiceAdmin.Services[gatewayServer.ServiceName]);

                  GlobalPacsUpdater.ModifyGlobalPacsConfiguration(DicomDemoSettingsManager.ProductNameGateway, gatewayServer.ServiceName, GlobalPacsUpdater.ModifyConfigurationType.Remove);

                  selectedRow.Row.Delete();

                  __GatewayServers.Remove(gatewayServer);

                  ServerState.Instance.GatewayServers.Remove(gatewayServer.ServiceName);

                  UpdateGatewayServersInMainServerSettings();
               }
               else
               {
                  __View.ShowMessage(string.Format("{0} has not been removed.", gatewayServer.ServiceName));
               }
            }
         }
         catch (Exception exception)
         {
            __View.ShowErrorMessage("Failed to delete gateway.\n" + exception.Message);
         }
      }

      private void DeleteAllGateways ( ) 
            {
               foreach ( GatewayServer server in __GatewayServers ) 
               {
                  ServerState.Instance.ServiceAdmin.UnInstallService ( ServerState.Instance.ServiceAdmin.Services [ server.ServiceName ] ) ;
                  
                  ServerState.Instance.GatewayServers.Remove ( server.ServiceName ) ;
               }
               
               __GatewayServers.Clear ( ) ;
               
               (  ( Gateways ) __GatewaySource.DataSource ).RemoteServer.Clear ( ) ;
               (  ( Gateways ) __GatewaySource.DataSource ).GatewayServer.Clear ( ) ;
               
            }
            
            private void GatewaysItemsGridView_ModifyItem ( object sender, EventArgs e )
            {
               try
               {
                  if ( null != __GatewaySource.Current ) 
                  {
                     DataRowView               selectedRow   = (DataRowView)               __GatewaySource.Current ;
                     Gateways.GatewayServerRow gatewayRow    = (Gateways.GatewayServerRow) selectedRow.Row ;
                     GatewayServer             gatewayServer = (GatewayServer)             gatewayRow.GatewayServer ;
                     
                     DicomService gatewayService ;
                     
                     if ( !ServerState.Instance.ServiceAdmin.Services.ContainsKey ( gatewayServer.ServiceName ) )
                     {
                        throw new InvalidOperationException ( "Gateway service not available." ) ;
                     }
                     else
                     {
                        gatewayService = ServerState.Instance.ServiceAdmin.Services [ gatewayServer.ServiceName ] ;
                     }
                     
                     using ( AeInfoDetails aeInfoDlg = new AeInfoDetails ( ) )
                     {
                        aeInfoDlg.DialogTitle = "Modify Gateway Server" ;
                        aeInfoDlg.ConfirmText = "Modify" ;
                        
                        aeInfoDlg.SetIpAddressList ( GetIpAddresses ( ) ) ;
                        
                        aeInfoDlg.AETitle = gatewayServer.Server.AETitle ;
                        aeInfoDlg.Address = gatewayServer.Server.Address ;
                        aeInfoDlg.Port    = gatewayServer.Server.SecurePort == 0 ? gatewayServer.Server.Port : gatewayServer.Server.SecurePort ;
                        aeInfoDlg.Secure  = gatewayServer.Server.SecurePort != 0 ;
                        
                        if ( aeInfoDlg.ShowDialog ( __View ) == DialogResult.OK ) 
                        {
                           gatewayServer.Server.AETitle    = aeInfoDlg.AETitle ;
                           gatewayServer.Server.Address    = aeInfoDlg.Address ;
                           gatewayServer.Server.Port       = aeInfoDlg.Secure ? 0 : aeInfoDlg.Port ;
                           gatewayServer.Server.SecurePort = aeInfoDlg.Secure ? aeInfoDlg.Port : 0 ;
                           gatewayServer.Server.ClientPortUsage = (aeInfoDlg.Secure) ? Dicom.ClientPortUsageType.Secure : Dicom.ClientPortUsageType.Unsecure;
                           gatewayServer.Server.LastAccessDate = DateTime.Now;
                           
                           SetGatwayServerAddInSettings ( gatewayServer ) ;
                           
                           gatewayRow.AETitle   = aeInfoDlg.AETitle ;
                           gatewayRow.IpAddress = aeInfoDlg.Address ;
                           gatewayRow.Port      = aeInfoDlg.Port ;
                           gatewayRow.Secure    = aeInfoDlg.Secure ;
                           
                           gatewayService.Settings.AETitle   = aeInfoDlg.AETitle ;
                           gatewayService.Settings.IpAddress = aeInfoDlg.Address ;
                           gatewayService.Settings.Port      = aeInfoDlg.Port ;
                           gatewayService.Settings.Secure    = aeInfoDlg.Secure ;
                           
                           gatewayService.Settings = gatewayService.Settings ;
                        }
                     }
                  }
               }
               catch ( Exception exception ) 
               {
                  __View.ShowErrorMessage ( "Failed to modify gateway settings.\n" + exception.Message ) ;
               }
            }
            
            private void RemoteServersItemsGridView_ModifyItem(object sender, EventArgs e)
            {
               try
               {
                  if ( null != __RemoteServersSource.Current ) 
                  {
                     using ( AeInfoDetails aeInfoDlg = new AeInfoDetails ( ) )
                     {
                        DataRowView              currentRowView  = (DataRowView) __RemoteServersSource.Current ;
                        Gateways.RemoteServerRow remoteServerRow = (Gateways.RemoteServerRow) currentRowView.Row ;
                        AeInfo                   remoteAeInfo    = (AeInfo) remoteServerRow.RemoteServerSettings ;
                        
                        aeInfoDlg.DialogTitle = "Modify Remote Server" ;
                        aeInfoDlg.ConfirmText = "Modify" ;
                        aeInfoDlg.CanEnterIp  = true ;
                        
                        aeInfoDlg.AETitle = remoteAeInfo.AETitle ;
                        aeInfoDlg.Port    = remoteAeInfo.Port > 0 ? remoteAeInfo.Port : remoteAeInfo.SecurePort ;
                        aeInfoDlg.Secure  = (remoteAeInfo.ClientPortUsage == Dicom.ClientPortUsageType.Secure);
                        aeInfoDlg.Address = remoteAeInfo.Address ;
                        
                        if ( aeInfoDlg.ShowDialog (  __View ) == DialogResult.OK )
                        {
                           remoteServerRow.AETitle    = aeInfoDlg.AETitle ;
                           remoteServerRow.IpAddress  = aeInfoDlg.Address ;                           
                           remoteServerRow.Port       =  aeInfoDlg.Port ;
                           remoteServerRow.SecurePort = 0; // ( !aeInfoDlg.Secure ) ? 0 : aeInfoDlg.Port ;
                           remoteServerRow.UseSecurePort = aeInfoDlg.Secure;

                           remoteAeInfo.AETitle    = aeInfoDlg.AETitle ;
                           remoteAeInfo.Address    = aeInfoDlg.Address ;
                           remoteAeInfo.Port       = aeInfoDlg.Secure ? 0 : aeInfoDlg.Port ;
                           remoteAeInfo.SecurePort = aeInfoDlg.Secure ? aeInfoDlg.Port : 0 ;
                           remoteAeInfo.ClientPortUsage = (aeInfoDlg.Secure) ? Dicom.ClientPortUsageType.Secure : Dicom.ClientPortUsageType.Unsecure;
                           remoteAeInfo.LastAccessDate = DateTime.Now;
                           
                           if ( null != __GatewaySource.Current ) 
                           {
                              GatewayServer server = (GatewayServer) ( ( Gateways.GatewayServerRow ) ( ( DataRowView ) __GatewaySource.Current ).Row ).GatewayServer ;
                              
                              
                              SetGatwayServerAddInSettings ( server ) ;
                           }
                        }
                     }
                  }
               }
               catch ( Exception exception ) 
               {
                  __View.ShowErrorMessage ( "Failed to modify remote server.\n" + exception.Message ) ;
               }
            }

      private void RemoteServersItemsGridView_DeleteItem(object sender, EventArgs e)
      {
         try
         {
            if (null != __RemoteServersSource.Current && null != __GatewaySource.Current)
            {
               DataRowView selectedGatewayRow = (DataRowView)__GatewaySource.Current;
               Gateways.GatewayServerRow gatewayRow = (Gateways.GatewayServerRow)selectedGatewayRow.Row;
               GatewayServer gatewayServer = (GatewayServer)gatewayRow.GatewayServer;


               DataRowView currentRowView = (DataRowView)__RemoteServersSource.Current;
               Gateways.RemoteServerRow remoteServerRow = (Gateways.RemoteServerRow)currentRowView.Row;
               AeInfo remoteAeInfo = (AeInfo)remoteServerRow.RemoteServerSettings;

               bool confirm = __View.ShowConfirmMessage(string.Format("Are you sure you want to remove {0}?", remoteAeInfo.AETitle));
               if (confirm)
               {
                  gatewayServer.RemoteServers.Remove(remoteAeInfo);

                  remoteServerRow.Delete();

                  SetGatwayServerAddInSettings(gatewayServer);
               }
               else
               {
                  __View.ShowMessage(string.Format("{0} has not been removed.", remoteAeInfo.AETitle));
               }


            }
         }
         catch (Exception exception)
         {
            __View.ShowErrorMessage("Failed to delete remote server.\n" + exception.Message);
         }
      }

      private void RemoteServersItemsGridView_AddItem ( object sender, EventArgs e )
            {
               try
               {
                  if ( null != __GatewaySource.Current ) 
                  {
                     using ( AeInfoDetails aeInfoDlg = new AeInfoDetails ( ) )
                     {
                        aeInfoDlg.DialogTitle = "Add Remote Server" ;
                        aeInfoDlg.ConfirmText = "Add" ;
                        aeInfoDlg.Port        = 105 ;
                        aeInfoDlg.CanEnterIp  = true ;
                        
                        if ( aeInfoDlg.ShowDialog (  __View ) == DialogResult.OK )
                        {
                           AeInfo                    remoteServer  = new AeInfo ( ) ;
                           DataRowView               currentParent = (DataRowView) __GatewaySource.Current ;
                           Gateways.GatewayServerRow parentGateway = (Gateways.GatewayServerRow) currentParent.Row ;
                           
                           
                           remoteServer.AETitle    = aeInfoDlg.AETitle ;
                           remoteServer.Address    = aeInfoDlg.Address ;
                           remoteServer.Port       = ( aeInfoDlg.Secure ) ? 0 : aeInfoDlg.Port ;
                           remoteServer.SecurePort = ( !aeInfoDlg.Secure ) ? 0 : aeInfoDlg.Port ;
                           
                           AddGatewayRemoteServerRow ( ( Gateways ) __GatewaySource.DataSource,
                                                       parentGateway,
                                                       remoteServer ) ;
                                                       
                           GatewayServer server = (GatewayServer) parentGateway.GatewayServer ;
                           
                           server.RemoteServers.Add ( remoteServer ) ;

                           SetGatwayServerAddInSettings ( server ) ;
                        }
                     }
                  }
               }
               catch ( Exception exception ) 
               {
                  __View.ShowErrorMessage ( "Failed to add remote server.\n" + exception.Message ) ;
               }
            }
            
            private void view_NumberOfTimesToUseSecondaryServerChanged ( object sender, EventArgs e )
            {
               try
               {
                  foreach ( GatewayServer gateway in __GatewayServers )
                  {
                     gateway.NumberOfTimesToUseSecondaryServer = __View.NumberOfTimesToUseSecondaryServer ;
                     
                     SetGatwayServerAddInSettings ( gateway ) ;
                  }
               }
               catch ( Exception exception ) 
               {
                  __View.ShowErrorMessage ( exception.Message ) ;
               }
            }
            
            void gateway_StatusChange ( object sender, EventArgs e )
            {
               try
               {
                  DicomService service = (DicomService ) sender ;
                  
                  
                  var gatewayServer = __GatewayServers.Where ( n=>n.ServiceName == service.ServiceName ).FirstOrDefault ( ) ;
                  
                  if ( null != gatewayServer ) 
                  {
                     foreach ( DataGridViewRow serverRow in __View.GatewaysItemsGridView.ItemsDataGridView.Rows ) 
                     {
                        if ( serverRow.Cells [ "GatewayServer" ].Value == gatewayServer )
                        {
                           UpdateGatewayServiceStatus ( service, serverRow ) ;
                           
                           break ;
                        }
                     }
                  }
                  
                  if ( null != __ServerController ) 
                  {
                     __ServerController.UpdateUI ( ) ;
                  }
               }
               catch{}
            }
            
            void GatewaysItemsGridView_SelectedItemChanged ( object sender, EventArgs e )
            {
               try
               {
                  __View.RemoteServersItemsGridView.CanAdd = __View.GatewaysItemsGridView.SelectedRow != null ;
                  
                  if ( __View.GatewaysItemsGridView.SelectedRow == null ) 
                  {
                     __RemoteServersSource.Filter = "GatewayServerAE = ''" ;
                  }
                  else
                  {
                     __RemoteServersSource.Filter = string.Empty ;
                  }
               }
               catch {}
            }
         
         #endregion
         
         #region Data Members
         
            private BindingSource       __GatewaySource       { get ; set ; }
            private BindingSource       __RemoteServersSource { get ; set ; }
            private GatewaySettingsView __View                { get ; set ; }
            private string[]            __IpAddresses         { get ; set ; }
            public List <GatewayServer> __GatewayServers      { get ; set ; }
            
         #endregion
         
         #region Data Types Definition
         
            private abstract class Constants
            {
               public const string ServiceStateColumn = "ServiceState" ;
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

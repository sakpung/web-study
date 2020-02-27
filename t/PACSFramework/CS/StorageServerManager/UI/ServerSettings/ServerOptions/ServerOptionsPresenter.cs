// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Leadtools.Dicom.AddIn.Common;
using Leadtools.Demos.StorageServer.DataTypes;
using Leadtools.Dicom.AddIn.Interfaces;
using Leadtools.Dicom.AddIn.Configuration;
using Leadtools.Medical.Gateway.CFindAddin.DataTypes;
using Leadtools.Dicom.Server.Admin;
using System.IO;
using Leadtools.Dicom.AddIn;
using Leadtools.Medical.Winforms;

namespace Leadtools.Demos.StorageServer.UI
{
   public class ServerOptionsPresenter
   {
      #region Public
         
         #region Methods
         
            public void RunView ( ServerOptionsView view ) 
            {
               ServerState.Instance.ServerServiceChanged  += new EventHandler ( OnConfigureView ) ;
               ServerState.Instance.ServiceAdminChanged   += new EventHandler ( OnConfigureView ) ;
               ServerState.Instance.IsRemoteServerChanged += new EventHandler ( OnConfigureView ) ;
               ServerState.Instance.LicenseChanged += new EventHandler(OnLicenseChanged);
               
               EventBroker.Instance.Subscribe <ApplyServerSettingsEventArgs>  ( OnUpdateServerSettings ) ;
               EventBroker.Instance.Subscribe <CancelServerSettingsEventArgs> ( OnCancelServerSettings ) ;

               View = view ;

               ConfigureView ( ) ;

               View.SettingsChanged += new EventHandler ( View_SettingsChanged ) ;
            }

            void OnLicenseChanged(object sender, EventArgs e)
            {
               ConfigureMax();
               SetGateWayLicense();
            }

            private void SetGateWayLicense()
            {
               if ( null == ServerState.Instance.ServerService ) 
               {
                  return ;
               }
               
               AdvancedSettings serverSettings = AdvancedSettings.Open(ServerState.Instance.ServerService.ServiceDirectory);
               List<string> gatewaysList = serverSettings.GetAddInCustomData<List<string>>(typeof(GatewaySettingsPresenter).Name, typeof(GatewayServer).Name);

               if (null == gatewaysList)
               {
                  gatewaysList = new List<string>();
               }               

               ServerState.Instance.ServiceAdmin.LoadServices(gatewaysList);

               foreach (string gatewayService in gatewaysList)
               {
                  if (ServerState.Instance.ServiceAdmin.Services.ContainsKey(gatewayService))
                  {
                     DicomService gateway = ServerState.Instance.ServiceAdmin.Services[gatewayService];
                     string configFile = Path.Combine(gateway.ServiceDirectory, "settings.xml");

                     gateway.Settings.LicenseFile = ServerState.Instance.ServerService.Settings.LicenseFile;
                     AddInUtils.Serialize<ServerSettings>(gateway.Settings, configFile);
                  }
               }
            }
         
         #endregion
         
         #region Properties
         
            public ServerOptionsView View 
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
         
            private void ConfigureView ( )
            {
               if ( ServerState.Instance.IsRemoteServer ) 
               {
                  View.Enabled = false ;
                  
                  return ;
               }

               ConfigureMax();
               if ( ServerState.Instance.ServerService != null ) 
               {
                  View.AllowAnonymousConnections      = ServerState.Instance.ServerService.Settings.AllowAnonymous ;
#if (LEADTOOLS_V19_OR_LATER)
                  View.AllowAnonymousCMove            = ServerState.Instance.ServerService.Settings.AllowAnonymousCMove;
                  View.AnonymousClientPort            = ServerState.Instance.ServerService.Settings.AnonymousClientPort;
#endif // #if (LEADTOOLS_V19_OR_LATER)
                  View.AllowClientMultipleConnections = ServerState.Instance.ServerService.Settings.AllowMultipleConnections ;
                  View.MaxClients                     = ServerState.Instance.ServerService.Settings.MaxClients > View.MaxClientsMaxValue ? View.MaxClientsMaxValue : ServerState.Instance.ServerService.Settings.MaxClients;
                  View.ClientIdleTimeout              = ServerState.Instance.ServerService.Settings.ClientTimeout ;
                  View.MessageProcessingTimeout       = ServerState.Instance.ServerService.Settings.AddInTimeout ;
                  View.StoreSubOperationsTimeout      = ServerState.Instance.ServerService.Settings.ReconnectTimeout ;                  
                  View.TempDirectory                  = ServerState.Instance.ServerService.Settings.TemporaryDirectory ;
                  View.RelationalQueries              = ServerState.Instance.ServerService.Settings.RelationalQueries;
                  View.RoleSelectionOptions           = ServerState.Instance.ServerService.Settings.RoleSelectionOptions;

                  View.UseTlsSecurity                 = ServerState.Instance.ServerService.Settings.Secure;
               }
               else
               {                  
                  View.AllowAnonymousConnections      = true ;
                  View.AllowAnonymousCMove            = false;
                  View.AnonymousClientPort            = 104;
                  View.AllowClientMultipleConnections = true ;
                  View.MaxClientsMaxValue             = 100;
                  View.MaxClients                     = 99 ;
                  View.ClientIdleTimeout              = 30 ;
                  View.MessageProcessingTimeout       = 30 ;
                  View.StoreSubOperationsTimeout      = 30 ;                  
                  View.RelationalQueries              = RelationalQuerySupportEnum.Negotiation;
                  View.RoleSelectionOptions           = RoleSelectionFlags.AcceptAllProposed;

                  View.UseTlsSecurity                 = false;
               }              
               __IsDirty = false ;
            }

            private void ConfigureMax()
            {
               if (ServerState.Instance.License != null)
               {
                  ILicense license = ServerState.Instance.License;
                  IFeature feature = license.GetFeature(ServerFeatures.MaxConcurrentConnections);

                  if (feature != null && feature.Type == LicenseFeatureType.LimitedNumber)
                     View.MaxClientsMaxValue = feature.Counter!=null && feature.Counter.Value > 0 ? feature.Counter.Value : int.MaxValue;
                  else if (feature != null && feature.Type == LicenseFeatureType.Eval && !feature.IsExpired)
                     View.MaxClientsMaxValue = 10;
                  else
                     View.MaxClientsMaxValue = 5;
               }
               else
                  View.MaxClientsMaxValue = 100;
            }

            private void UpdateServerSettings ( ServerSettings settings )
            {
               settings.AllowAnonymous           = View.AllowAnonymousConnections ;
#if (LEADTOOLS_V19_OR_LATER)
               settings.AllowAnonymousCMove      = View.AllowAnonymousCMove;
               settings.AnonymousClientPort      = View.AnonymousClientPort;
#endif // #if (LEADTOOLS_V19_OR_LATER)
               settings.AllowMultipleConnections = View.AllowClientMultipleConnections ;
               settings.MaxClients               = View.MaxClients ;
               settings.ClientTimeout            = View.ClientIdleTimeout ;
               settings.AddInTimeout             = View.MessageProcessingTimeout ;
               settings.ReconnectTimeout         = View.StoreSubOperationsTimeout ;
               settings.TemporaryDirectory       = View.TempDirectory ;
               settings.RelationalQueries        = View.RelationalQueries;

               settings.RoleSelectionOptions     = View.RoleSelectionOptions;
               settings.Secure                   = View.UseTlsSecurity;
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
         
            private bool __IsDirty { get; set; }
            
         #endregion
         
         #region Events

            public event EventHandler SettingsChanged;
         
            void View_SettingsChanged ( object sender, EventArgs e )
            {
               try
               {
                  if (SettingsChanged != null)
                  {
                     __IsDirty = true;
                     SettingsChanged(sender, e);
                  }
               }
               catch (Exception)
               {
                  System.Diagnostics.Debug.Assert(false);
               }
            }
            
            void OnConfigureView ( object sender, EventArgs e )
            {
               ConfigureView ( ) ;
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

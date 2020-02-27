// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Leadtools.Demos.StorageServer.DataTypes;
using Leadtools.Dicom.AddIn.Common;
using Leadtools.Medical.Winforms;

namespace Leadtools.Demos.StorageServer.UI
{
   public class ServerNetworkingPresenter
   {
      #region Public
         
         #region Methods
         
            public void RunView ( ServerNetworkingView view ) 
            {
               ServerState.Instance.ServerServiceChanged += new EventHandler  ( OnConfigureView ) ;
               ServerState.Instance.ServiceAdminChanged  += new EventHandler  ( OnConfigureView ) ;
               ServerState.Instance.IsRemoteServerChanged += new EventHandler ( OnConfigureView ) ;
               
               EventBroker.Instance.Subscribe <ApplyServerSettingsEventArgs>  ( OnUpdateServerSettings ) ;
               EventBroker.Instance.Subscribe <CancelServerSettingsEventArgs> ( OnCancelServerSettings ) ;

               View = view ;

               ConfigureView ( ) ;

               View.SettingsChanged += new EventHandler(View_SettingsChanged);
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
         
            public ServerNetworkingView View { get; private set; }
            
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
               
               if ( ServerState.Instance.ServerService != null ) 
               {
                  View.IsMaxPduLengthChecked = ServerState.Instance.ServerService.Settings.MaxPduLength != -1 ;
                  View.MaxPduLength          = ServerState.Instance.ServerService.Settings.MaxPduLength == -1 ? 0 : ServerState.Instance.ServerService.Settings.MaxPduLength ;
                  View.ReceiveBufferSize     = ServerState.Instance.ServerService.Settings.ReceiveBufferSize ;
                  View.SendBufferSize        = ServerState.Instance.ServerService.Settings.SendBufferSize ;
                  View.NoDelay               = ServerState.Instance.ServerService.Settings.NoDelay ;
               }
               else
               {
                  View.IsMaxPduLengthChecked = false ;
                  View.MaxPduLength          = 0;
                  View.ReceiveBufferSize     = 29696 ;
                  View.SendBufferSize        = 29696 ;
                  View.NoDelay               = false ;
               }

               __IsDirty = false ;
            }

            private void UpdateServerSettings ( ServerSettings serverSettings )
            {
               serverSettings.MaxPduLength = View.IsMaxPduLengthChecked ? View.MaxPduLength : -1 ;
               serverSettings.ReceiveBufferSize = View.ReceiveBufferSize ;
               serverSettings.SendBufferSize = View.SendBufferSize ;
               serverSettings.NoDelay = View.NoDelay ;
            }
            
         #endregion
         
         #region Properties
         
            private bool __IsDirty { get; set; }
            
         #endregion
         
         #region Events
         
            void OnConfigureView ( object sender, EventArgs e )
            {
               ConfigureView ( ) ;
            }

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

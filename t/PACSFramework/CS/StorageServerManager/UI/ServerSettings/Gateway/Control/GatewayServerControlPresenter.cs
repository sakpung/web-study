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
using Leadtools.Medical.Gateway.CFindAddin.DataTypes;
using Leadtools.Dicom.Server.Admin;
using System.ServiceProcess;
using System.Threading;

namespace Leadtools.Demos.StorageServer.UI
{
   class GatewayServerControlPresenter
   {
      public GatewayServerControlPresenter ( ) 
      {
         _syncContext = WindowsFormsSynchronizationContext.Current ;
      }
      public void RunView ( ItemsGridView view, BindingSource gatewaySource ) 
      {
         _serverControlStrip = new ServerControlToolStrip ( ) ;
         _gatewaySource      = gatewaySource ;
         _view               = view ;
         view.MainToolStrip.Items.Add ( new ToolStripSeparator ( ) ) ;
         
         ToolStripManager.Merge ( _serverControlStrip, view.MainToolStrip ) ;
         
         UpdateUI ( ) ;

         _view.SelectedItemChanged += new EventHandler ( _view_SelectedItemChanged ) ;
         
         _serverControlStrip.StartServer     += new EventHandler ( _serverControlStrip_StartServer ) ;
         _serverControlStrip.StopServer      += new EventHandler ( _serverControlStrip_StopServer ) ;
         _serverControlStrip.StartAllServers += new EventHandler ( _serverControlStrip_StartAllServers ) ;
         _serverControlStrip.StopAllServers  += new EventHandler ( _serverControlStrip_StopAllServers ) ;
      }
      
      public void Reconfigure ( BindingSource gatewaySource )
      {
         _gatewaySource = gatewaySource ;
         
         UpdateUI ( ) ;
      }
      
      void _view_SelectedItemChanged ( object sender, EventArgs e )
      {
         UpdateUI ( ) ;
      }

      public void UpdateUI ( )
      {
         _syncContext.Send ( new SendOrPostCallback ( delegate ( object state ) {
         
            _serverControlStrip.CanStart    = _serverControlStrip.CanStop    = ( _view.SelectedRow != null ) && ServerState.Instance.ServiceAdmin != null ;
            _serverControlStrip.CanStartAll = _serverControlStrip.CanStopAll = _gatewaySource.Count > 0 && ServerState.Instance.ServiceAdmin != null ;
            
            if ( null != _view.SelectedRow && _gatewaySource.Current != null ) 
            {
               GatewayServer server = (GatewayServer) ( ( Gateways.GatewayServerRow ) ( ( DataRowView )_gatewaySource.Current ).Row ).GatewayServer ;
               
               if ( null != ServerState.Instance.ServiceAdmin && 
                    ServerState.Instance.ServiceAdmin.Services.ContainsKey ( server.ServiceName ) )
               {
                  DicomService service = ServerState.Instance.ServiceAdmin.Services [ server.ServiceName ] ;
                  
                  
                  _serverControlStrip.CanStart = service.Status != ServiceControllerStatus.Running ;
                  _serverControlStrip.CanStop  = service.Status != ServiceControllerStatus.Stopped ;
               }
            }
         } ), null ) ;
      }

      private DicomService GetCurrentDicomService ( )
      {
         DicomService gatewayService = null ;
         
         if ( _gatewaySource.Current != null ) 
         {
            Gateways.GatewayServerRow gatewayRow = ( Gateways.GatewayServerRow ) ( ( DataRowView ) _gatewaySource.Current ).Row  ;

            gatewayService = GetGatewayService ( gatewayRow ) ;
         }
         
         return gatewayService;
      }

      private static DicomService GetGatewayService ( Gateways.GatewayServerRow gatewayRow )
      {
         DicomService gatewayService = null ;
         GatewayServer gatewayServer =  (GatewayServer) gatewayRow.GatewayServer ;
         
         if ( ServerState.Instance.ServiceAdmin.Services.ContainsKey ( gatewayServer.ServiceName ) )
         {
            gatewayService =  ServerState.Instance.ServiceAdmin.Services [ gatewayServer.ServiceName ] ;
         }
         
         return gatewayService;
      }

      void _serverControlStrip_StartServer ( object sender, EventArgs e )
      {
         DicomService gatewayService = null ;

         gatewayService = GetCurrentDicomService ( ) ;
         
         if ( gatewayService != null ) 
         {
            if ( gatewayService.Status != ServiceControllerStatus.Running ) 
            {
               gatewayService.Start ( ) ;
            }
         }
      }

      void _serverControlStrip_StopServer(object sender, EventArgs e)
      {
         DicomService gatewayService = null ;

         gatewayService = GetCurrentDicomService ( ) ;
         
         if ( gatewayService != null ) 
         {
            if ( gatewayService.Status != ServiceControllerStatus.Stopped ) 
            {
               gatewayService.Stop ( ) ;
            }
         }
      }
      
      void _serverControlStrip_StartAllServers ( object sender, EventArgs e )
      {
         Gateways gateways = (Gateways) _gatewaySource.DataSource ;
         
         foreach ( Gateways.GatewayServerRow gateway in gateways.GatewayServer )
         {
            DicomService service = GetGatewayService ( gateway ) ;
            
            if ( null != service && service.Status != ServiceControllerStatus.Running )
            {
               service.Start ( ) ;
            }
         }
      }
      
      void _serverControlStrip_StopAllServers(object sender, EventArgs e)
      {
         Gateways gateways = (Gateways) _gatewaySource.DataSource ;
         
         foreach ( Gateways.GatewayServerRow gateway in gateways.GatewayServer )
         {
            DicomService service = GetGatewayService ( gateway ) ;
            
            if ( null != service && service.Status != ServiceControllerStatus.Stopped )
            {
               service.Stop ( ) ;
            }
         }
      }
      
      ServerControlToolStrip _serverControlStrip ;
      BindingSource _gatewaySource ;
      ItemsGridView _view ;
      SynchronizationContext  _syncContext ;
   }
}

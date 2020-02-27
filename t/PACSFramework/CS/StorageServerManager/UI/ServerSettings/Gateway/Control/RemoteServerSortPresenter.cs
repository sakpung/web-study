// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Leadtools.Dicom.AddIn.Common;
using System.Data;
using Leadtools.Medical.Gateway.CFindAddin.DataTypes;

namespace Leadtools.Demos.StorageServer.UI
{
   class RemoteServerSortPresenter
   {
      public void RunView ( ToolStrip mainToolStrip, BindingSource gatewaySource, BindingSource remoteServerSource ) 
      {
         _gatewaySource      = gatewaySource ;
         _remoteServerSource = remoteServerSource ;
         
         _remoteServerUpDownMenu = new RemoteServerSortToolStrip ( ) ;
         
         mainToolStrip.Items.Add ( new ToolStripSeparator ( ) ) ;
         
         ToolStripManager.Merge ( _remoteServerUpDownMenu, mainToolStrip ) ;

         _remoteServerUpDownMenu.MoveUp   += new EventHandler ( _remoteServerUpDownMenu_MoveUp ) ;
         _remoteServerUpDownMenu.MoveDown += new EventHandler ( _remoteServerUpDownMenu_MoveDown ) ;

         _remoteServerSource.PositionChanged += new EventHandler ( _remoteServerSource_PositionChanged ) ;
      }
      
      public void Reconfigure ( BindingSource gatewaySource, BindingSource remoteServersSource )
      {
         if ( _remoteServerSource != null ) 
         {
            _remoteServerSource.PositionChanged -= new EventHandler ( _remoteServerSource_PositionChanged ) ;
         }
         
         _gatewaySource      = gatewaySource ;
         _remoteServerSource = remoteServersSource ;
         
         if ( null != _remoteServerSource ) 
         {
            _remoteServerSource.PositionChanged += new EventHandler ( _remoteServerSource_PositionChanged ) ;
         }
      }

      void _remoteServerSource_PositionChanged(object sender, EventArgs e)
      {
         _remoteServerUpDownMenu.CanMoveDown = ( _remoteServerSource.Position < _remoteServerSource.Count - 1 ) ;
         _remoteServerUpDownMenu.CanMoveUp   = ( _remoteServerSource.Position > 0 ) ; 
      }

      void _remoteServerUpDownMenu_MoveDown ( object sender, EventArgs e )
      {
         if ( _remoteServerSource.Position < _remoteServerSource.Count - 1 )
         {
            MoveRow ( 1 ) ;
         }
      }

      void _remoteServerUpDownMenu_MoveUp(object sender, EventArgs e)
      {
         if ( _remoteServerSource.Position > 0 )
         {
            MoveRow ( -1 ) ;
         }
      }
      
      private void MoveRow ( int direction) 
      {
         Gateways gateways = (Gateways) _gatewaySource.DataSource ;
         
         Gateways.RemoteServerRow currentRow = ( ( Gateways.RemoteServerRow ) ( ( DataRowView ) _remoteServerSource.Current ).Row ) ;
         _remoteServerSource.Position += direction ;
         Gateways.RemoteServerRow newRow = ( ( Gateways.RemoteServerRow ) ( ( DataRowView ) _remoteServerSource.Current ).Row ) ;
         AeInfo remoteServer  = (AeInfo) currentRow.RemoteServerSettings ;
         int currentIndex = gateways.RemoteServer.Rows.IndexOf ( currentRow ) ;
         int newIndex = gateways.RemoteServer.Rows.IndexOf ( newRow ) ;
         
         object[] items = currentRow.ItemArray ;
         
         gateways.RemoteServer.Rows.Remove ( currentRow ) ;
         DataRow updateRow = gateways.RemoteServer.NewRow ( ) ;
         updateRow.ItemArray = items ;
         gateways.RemoteServer.Rows.InsertAt ( updateRow, newIndex ) ;
         _remoteServerSource.Position = newIndex ;
         
         GatewayServer server = ( GatewayServer ) ( ( Gateways.GatewayServerRow ) ( ( DataRowView ) _gatewaySource.Current ).Row ).GatewayServer ;
         
         int aeInfoIndex = server.RemoteServers.IndexOf ( remoteServer ) ;
         aeInfoIndex += direction ;
         server.RemoteServers.Remove ( remoteServer  ) ;
         server.RemoteServers.Insert ( aeInfoIndex, remoteServer ) ;
         
         GatewaySettingsPresenter.SetGatwayServerAddInSettings ( server ) ;
      }
      
      private RemoteServerSortToolStrip _remoteServerUpDownMenu ;
      private BindingSource _gatewaySource ;
      private BindingSource _remoteServerSource ;
   }
}

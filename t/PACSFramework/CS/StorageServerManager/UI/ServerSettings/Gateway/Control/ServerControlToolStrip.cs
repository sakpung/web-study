// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Leadtools.Demos.StorageServer.UI
{
   class ServerControlToolStrip : ToolStrip
   {
      public ServerControlToolStrip ( ) 
      {
         _startServer.Text     = "Start" ;
         _stopServer.Text      = "Stop" ;
         _startAllServers.Text = "Start All" ;
         _stopAllServers.Text  = "Stop All" ;
         
         _startServer.Image     = global::Leadtools.Demos.StorageServer.Properties.Resources.Start;
         _stopServer.Image      = global::Leadtools.Demos.StorageServer.Properties.Resources.Stop ;
         _startAllServers.Image = global::Leadtools.Demos.StorageServer.Properties.Resources.StartAll ;
         _stopAllServers.Image  = global::Leadtools.Demos.StorageServer.Properties.Resources.StopAll ;
         
         
         _startServer.DisplayStyle = _stopServer.DisplayStyle     = _startAllServers.DisplayStyle = 
                                     _stopAllServers.DisplayStyle = ToolStripItemDisplayStyle.Image ;
         
         this.Items.AddRange ( new ToolStripItem [] { _startServer, _stopServer, _startAllServers, _stopAllServers } ) ;

         _startServer.Click     += new EventHandler ( _startServer_Click ) ;
         _stopServer.Click      += new EventHandler ( _stopServer_Click ) ;
         _startAllServers.Click += new EventHandler ( _startAllServers_Click ) ;
         _stopAllServers.Click  += new EventHandler ( _stopAllServers_Click ) ;

      }
      
      public bool CanStart
      {
         get
         {
            return _startServer.Enabled ;
         }
         
         set
         {
            _startServer.Enabled = value ;
         }
      }
      
      public bool CanStop
      {
         get
         {
            return _stopServer.Enabled ;
         }
         
         set
         {
            _stopServer.Enabled = value ;
         }
      }
      
      public bool CanStartAll
      {
         get
         {
            return _startAllServers.Enabled ;
         }
         
         set
         {
            _startAllServers.Enabled = value ;
         }
      }
      
      public bool CanStopAll
      {
         get
         {
            return _stopAllServers.Enabled ;
         }
         
         set
         {
            _stopAllServers.Enabled = value ;
         }
      }

      public event EventHandler StartServer ;
      public event EventHandler StopServer ;
      public event EventHandler StartAllServers ;
      public event EventHandler StopAllServers ;
      
      void _startServer_Click ( object sender, EventArgs e )
      {
         if ( null != StartServer ) 
         {
            StartServer ( this, e ) ;
         }
      }
      
      void _stopServer_Click ( object sender, EventArgs e )
      {
         if ( null != StopServer ) 
         {
            StopServer ( this, e ) ;
         }
      }

      void _startAllServers_Click ( object sender, EventArgs e )
      {
         if ( null != StartAllServers ) 
         {
            StartAllServers ( this, e ) ;
         }
      }

      void _stopAllServers_Click ( object sender, EventArgs e )
      {
         StopAllServers ( this, e ) ;
      }

      
      
      private ToolStripButton _startServer     = new ToolStripButton ( ) ;
      private ToolStripButton _stopServer      = new ToolStripButton ( ) ;
      private ToolStripButton _startAllServers = new ToolStripButton ( ) ;
      private ToolStripButton _stopAllServers  = new ToolStripButton ( ) ;
   }
}

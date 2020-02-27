// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO ;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Configuration ;
using Leadtools ;
using Leadtools.Demos ;
using Leadtools.Jpip ;
using Leadtools.Jpip.Server ;
using Microsoft.Win32 ;

#if LEADTOOLS_V19_OR_LATER
using Leadtools.Demos.Dialogs;
#endif

namespace JpipServerDemo
{
   public partial class MainForm : Form
   {
      JpipServer   _server ;
      private bool _displayLogs ;
      private string [ ]  _deniedIpAddress ; 
      private string [ ]  _dataIpAddress ; 
      private string _datafolder = string.Empty ; 
      private ImagesEnumerationService _service ;
      private int    responseCount = 0 ;
      
      public MainForm ( )
      {
         InitializeComponent();

         Messager.Caption = "JPIP Server Demo" ;

         _server      = new JpipServer ( ) ;
         _displayLogs = true ;
         _deniedIpAddress   = new string [ 0 ] ;
         _dataIpAddress     = new string [ 0 ] ;

         AppSettingsReader configReader = new AppSettingsReader ( ) ;
         
         try { _server.Configuration.Port             = ( int )  configReader.GetValue ( "Port", typeof (int) ) ; } catch { _server.Configuration.Port = 49201 ; } 
         try { _server.Configuration.DivideSuperBoxes = ( bool ) configReader.GetValue ( "DivideSuperBoxes", typeof ( bool ) ) ; } catch { _server.Configuration.DivideSuperBoxes = true ; }
         try { _server.Configuration.ChunkSize        = ( int )  configReader.GetValue ( "ChunkSize", typeof ( int ) ) ; } catch { _server.Configuration.ChunkSize =  512 ; }
         
         SetImagesPath ( _server, configReader ) ;
         
         _service = new ImagesEnumerationService ( _server ) ;
         
         _service.ImagesExtension.Add ( "*.j2k" ) ;
         _service.ImagesExtension.Add ( "*.jp2" ) ;
         _service.ImagesExtension.Add ( "*.jpx" ) ;
      }

      private void SetImagesPath ( JpipServer server, AppSettingsReader configReader ) 
      {
         try
         {
            string imagesPath ;

            
            try { imagesPath = ( string ) configReader.GetValue ( "ImagesFolder", typeof ( string ) ) ; } catch { imagesPath = Path.GetFullPath ( @"..\..\..\..\..\..\Images" ) ; } 
                                                                      
            if ( !Directory.Exists ( imagesPath ) )
            {
               imagesPath = DemosGlobal.ImagesFolder ;
            }
            
            if ( null != imagesPath )
            {
               server.Configuration.ImagesFolder = imagesPath.ToString ( ) ;
            }
         }
         catch ( Exception exception )
         {
            Messager.ShowError ( this, exception ) ;
         }
      }
      
      void UpdateUIMenuStsate ( )
      {
         if ( null == _server ) 
         {
            return ;
         }
         
         if ( _server.IsRunning ) 
         {
            startToolStripMenuItem.Enabled = false ;
            stopToolStripMenuItem.Enabled = true ;
         }
         else
         {
            startToolStripMenuItem.Enabled = true ;
            stopToolStripMenuItem.Enabled = false ;
         }
      }

      private delegate void InvokeLogerHandler ( object sender, Leadtools.Jpip.Logging.EventLogEntry entry ) ;
      
      void EventLogger_EventLog ( object sender, Leadtools.Jpip.Logging.EventLogEntry entry )
      {
         if ( !_displayLogs )
         {
            return ;
         }
         
         ListViewItem item ;
         
         if ( lstvwEventLog.InvokeRequired )
         {
            lstvwEventLog.Invoke ( new InvokeLogerHandler ( EventLogger_EventLog ), new object [ ] { sender, entry } ) ;
            
            return ;
         }
         
         item = new ListViewItem ( entry.ServerName ) ;
         
         item.SubItems.AddRange ( new string [ ] { entry.ServerIPAddress, 
                                                   entry.ServerPort, 
                                                   entry.ClientIPAddress, 
                                                   entry.ClientPort, 
                                                   entry.Type.ToString ( ), 
                                                   entry.ChannelID,
                                                   entry.DateTime.ToString ( ),
                                                   entry.Description } ) ;
         
         lstvwEventLog.Items.Add ( item ) ;
         
         lstvwEventLog.Items [ lstvwEventLog.Items.Count - 1 ].EnsureVisible ( ) ;
      }
      
      void _server_RequestReceived(object sender, RequestReceivedEventArgs e)
      {
         try
         {
            foreach ( string clientIpAddress in _deniedIpAddress )
            {
               if ( e.ClientIpAddress == clientIpAddress )
               {
                  e. Deny       = true ;
                  e.StatusCode  = ( int ) System.Net.HttpStatusCode.Forbidden ;
                  e.Description = "Server refused to process request." ;
                  
                  break ;
               }
            }
         }
         catch ( Exception exception )
         {
            Messager.ShowError ( this, exception ) ;
         }
      }
      
      void _server_ResponseSending(object sender, ResponseSendingEventArgs e)
      {
         try
         {
            if ( string.IsNullOrEmpty ( _datafolder ) ) 
            {
               return ;
            }
            
            if ( !Directory.Exists ( _datafolder ) ) 
            {
               Directory.CreateDirectory ( _datafolder ) ;
            }
            
            foreach ( string clientIpAddress in _dataIpAddress )
            {
               if ( e.ClientIpAddress == clientIpAddress )
               {
                  string subDirectoryPath ;
                  string responseDataFile ;
                  
                  responseCount++ ;
                  
                  subDirectoryPath = string.Concat ( _datafolder, "\\", clientIpAddress ) ;
                  responseDataFile = string.Concat ( subDirectoryPath, "\\response_", responseCount ) ;
                  
                  if ( !Directory.Exists ( subDirectoryPath ) ) 
                  {
                     Directory.CreateDirectory ( subDirectoryPath ) ;
                  }
                  
                  File.WriteAllBytes ( responseDataFile, e.Data ) ;
                  
                  break ;
               }
            }
         }
         catch ( Exception exception )
         {
            Messager.ShowError ( this, exception ) ;
         }
      }

      private void startToolStripMenuItem_Click(object sender, EventArgs e)
      {
         try
         {
            if ( !_server.IsRunning )
            {
            //EventLogger_EventLog
               Leadtools.Jpip.Logging.EventLogger.EventLog += new EventHandler<Leadtools.Jpip.Logging.EventLogEntry>(EventLogger_EventLog);
               _server.RequestReceived += new EventHandler<RequestReceivedEventArgs> ( _server_RequestReceived ) ;
               _server.ResponseSending += new EventHandler<ResponseSendingEventArgs> ( _server_ResponseSending ) ;
               _server.Start ( ) ;
               
               if ( _server.Configuration.IPAddress != _service.IpAddress.ToString ( ) )
               {
                  if ( _service.Running ) 
                  {
                     _service.Stop ( ) ;
                  }
                  
                  _service.IpAddress = System.Net.IPAddress.Parse ( _server.Configuration.IPAddress ) ;
               }
               
               if ( !_service.Running )
               {
                  _service.Start ( ) ;
               }
            }
            
            UpdateUIMenuStsate ( ) ;
         }
         catch ( Exception exception )
         {
            Leadtools.Jpip.Logging.EventLogger.EventLog -= new EventHandler<Leadtools.Jpip.Logging.EventLogEntry>(EventLogger_EventLog);
            _server.RequestReceived -= new EventHandler<RequestReceivedEventArgs> ( _server_RequestReceived ) ;
            _server.ResponseSending -= new EventHandler<ResponseSendingEventArgs> ( _server_ResponseSending ) ;
            
            Messager.ShowError ( this, exception ) ;
         }
      }

      private void stopToolStripMenuItem_Click(object sender, EventArgs e)
      {
         try
         {
            if ( _server.IsRunning )
            {
               _server.Stop ( ) ;
               
               if ( _service.Running )
               {
                  _service.Stop  ( ) ;
               }
               
               Leadtools.Jpip.Logging.EventLogger.EventLog -= new EventHandler<Leadtools.Jpip.Logging.EventLogEntry> ( EventLogger_EventLog ) ;
               _server.RequestReceived -= new EventHandler<RequestReceivedEventArgs> (_server_RequestReceived ) ;
               _server.ResponseSending -= new EventHandler<ResponseSendingEventArgs> ( _server_ResponseSending ) ;
            }
            
            UpdateUIMenuStsate ( ) ;
         }
         catch ( Exception exception )
         {
            Messager.ShowError ( this, exception ) ;
         }
      }

      private void exitToolStripMenuItem_Click(object sender, EventArgs e)
      {
         this.Close ( ) ;
      }

      private void clearLogsToolStripMenuItem_Click(object sender, EventArgs e)
      {
         lstvwEventLog.Items.Clear ( ) ;
      }

      private void displayLogsToolStripMenuItem_Click(object sender, EventArgs e)
      {
         _displayLogs = displayLogsToolStripMenuItem.Checked ;
      }
      
      private void cacheToolStripMenuItem_Click(object sender, EventArgs e)
      {
         DialogResult deleteCache ;
         
         
         deleteCache = Messager.ShowQuestion ( this,
                                               "Are you sure you want to clear all cache contents?",
                                                MessageBoxButtons.YesNo ) ;

         if ( deleteCache == DialogResult.Yes ) 
         {
            try
            {
               _server.ClearCacheContents ( ) ;
            }
            catch ( Exception exception )
            {
               Messager.ShowError ( this, exception ) ;
            }
         }
      }

      private void configurationToolStripMenuItem_Click(object sender, EventArgs e)
      {
         try
         {
            Configuration configDlg ;
            
            
            configDlg = new Configuration ( _server ) ;
            
            configDlg.ShowDialog ( ) ;
         }
         catch ( Exception exception )
         {
            Messager.ShowError ( this, exception ) ;
         }
      }

      private void InteractiveRequeststoolStripMenuItem_Click(object sender, EventArgs e)
      {
         try
         {
            RequestsHandling requestsDlg ;
            
            
            
            requestsDlg = new RequestsHandling ( _deniedIpAddress ) ;
            
            if ( requestsDlg.ShowDialog ( ) == DialogResult.OK ) 
            {
               _deniedIpAddress = requestsDlg.IpAddresses ;
            }
         }
         catch ( Exception exception )
         {
            Messager.ShowError ( this, exception ) ;
         }
      }

      private void InteractiveResponsestoolStripMenuItem3_Click(object sender, EventArgs e)
      {
         try
         {
            ResponseHandling responseDlg ;
            
            
            responseDlg = new ResponseHandling ( _dataIpAddress ) ;
            responseDlg.DataFolder = _datafolder ;
            
            if ( responseDlg.ShowDialog ( )== DialogResult.OK ) 
            {
               _dataIpAddress = responseDlg.IpAddresses ;
               _datafolder    = responseDlg.DataFolder ;
            }
         }
         catch ( Exception exception )
         {
            Messager.ShowError ( this, exception ) ;
         }

      }

      private void fileEnumerationServiceToolStripMenuItem_Click(object sender, EventArgs e)
      {
         try
         {
            ImagesEnumerationServiceDlg ImagesEnumSrvcDlg ;
            
            
            ImagesEnumSrvcDlg = new ImagesEnumerationServiceDlg ( _service ) ;
            
            ImagesEnumSrvcDlg.TopMost = true ;
            
            ImagesEnumSrvcDlg.Show ( ) ;

         }
         catch ( Exception exception )
         {
            Messager.ShowError ( this, exception ) ;
         }
      }

      private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
      {
         try
         {
#if LEADTOOLS_V19_OR_LATER
            using (AboutDialog aboutDialog = new AboutDialog("Jpip Server", ProgrammingInterface.CS))
               aboutDialog.ShowDialog(this);
#else
         using (AboutDialog aboutDialog = new AboutDialog("Jpip Server"))
            aboutDialog.ShowDialog(this);
#endif
         }
         catch ( Exception exception )
         {
            Messager.ShowError ( this, exception ) ;
         }
      }

      private void howToToolStripMenuItem_Click(object sender, EventArgs e)
      {
         try
         {
            DemosGlobal.LaunchHowTo("Jpip.html");
         }
         catch (Exception ex)
         {
            Messager.ShowError(this, ex.Message);
         } 
      }

      private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
      {
         stopToolStripMenuItem_Click ( sender, e ) ;
      }
   }
}

// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************

using System;
using System.IO ;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Leadtools.Demos ;
using Leadtools.Jpip ;
using Leadtools.Jpip.Server ;
using Leadtools.Codecs;


namespace JpipServerDemo
{
   public partial class Configuration : Form
   {
      JpipServer _server = null ;
      
      public Configuration ( )
      {
         InitializeComponent ( ) ;
      }
      
      public Configuration ( JpipServer server )
      : this ( ) 
      {
         _server = server ;
         
         Init ( ) ;
      }
      
      private void Init ( )
      {
         InitServerSettings ( ) ;
         InitClientsSettings ( ) ;
         InitCommunicationSettings ( ) ;
         InitImagesSettings ( ) ;
         InitLoggingSettings ( ) ;
         
         FillDelegatedServers ( ) ;
      }
      
      private void InitServerSettings ( )
      {
         txtServerName.Text   = _server.Configuration.ServerName ;
         txtIpAddress.Text    = _server.Configuration.IPAddress ;
         mtxtPort.Text        = _server.Configuration.Port.ToString ( ) ;
         txtImagesFolder.Text = _server.Configuration.ImagesFolder ;
         txtCacheFolder.Text  = _server.Configuration.CacheFolder ;
         mtxtCacheSize.Text   = _server.Configuration.CacheSize.ToString ( ) ;
         
         mtxtServerBandwidth.Text = ( _server.Configuration.MaxServerBandwidth ).ToString ( ) ;
         
         if ( _server.Configuration.MaxServerBandwidth == -1 )
         {
            chkServerUnlimitedBandWidth.Checked = true ;
            mtxtServerBandwidth.Enabled = false ;
         }
         else
         {
            mtxtServerBandwidth.Enabled = true ;
            chkServerUnlimitedBandWidth.Checked = false ;
         }
         
         FillAliasFolders ( ) ;
         
         btnReset.Enabled      = !_server.IsRunning ;
         txtServerName.Enabled = !_server.IsRunning ;
         txtIpAddress.Enabled  = !_server.IsRunning ; 
         mtxtPort.Enabled      = !_server.IsRunning ;
         btnAddDelegatedServer.Enabled    = !_server.IsRunning ;
         btnRemoveDelegatedServer.Enabled = !_server.IsRunning ;
      }
      
      private void InitClientsSettings ( )
      {
         mtxtMaxClients.Text            = _server.Configuration.MaxClientCount.ToString ( ) ;
         mtxtConnectionIdleTimeout.Text = _server.Configuration.ConnectionIdleTimeout.TotalSeconds.ToString ( ) ;
         mtxtMaxSessionLife.Text        = _server.Configuration.MaxSessionLifetime.TotalSeconds.ToString ( ) ;
         
         
         mtxtConnectionBW.Text = (  _server.Configuration.MaxConnectionBandwidth ).ToString ( ) ;
         
         if ( _server.Configuration.MaxConnectionBandwidth == -1 )
         {
            mtxtConnectionBW.Enabled = false ;
            chkClientUnlimitedBandWidth.Checked = true ;
         }
         else
         {
            mtxtConnectionBW.Enabled            = true ;
            chkClientUnlimitedBandWidth.Checked = false ;
         }
      }
      
      private void InitCommunicationSettings ( )
      {
         mtxtMaxTransport.Text     = _server.Configuration.MaxTransportConnections.ToString ( ) ;
         mtxtHandshakeTimeout.Text = _server.Configuration.HandshakeTimeout.TotalSeconds.ToString ( ) ;
         mtxtChunkSize.Text        = _server.Configuration.ChunkSize.ToString ( ) ;
         
         mtxtRequestTimeout.Text =_server.Configuration.RequestTimeout.TotalSeconds.ToString ( ) ;
         
         if ( _server.Configuration.RequestTimeout == TimeSpan.MaxValue )
         {
            chkCommunicationUnlimitedRequest.Checked = true ;
            mtxtRequestTimeout.Enabled = false ;
         }
         else
         {
            chkCommunicationUnlimitedRequest.Checked = false ;
            mtxtRequestTimeout.Enabled = true ;
         }
      }
      
      private void InitImagesSettings ( ) 
      {
         mtxtParsingTimeout.Text = _server.Configuration.ImageParsingTimeout.TotalSeconds.ToString ( ) ;
         
         if ( _server.Configuration.ImageParsingTimeout == TimeSpan.MaxValue ) 
         {
            chkImageParsingTimeout.Checked = true ;
            mtxtParsingTimeout.Enabled = false ;
         }
         else
         {
            chkImageParsingTimeout.Checked = false ;
            mtxtParsingTimeout.Enabled     = true ;
         }
         
         mtxtPartitionSize.Text      = _server.Configuration.PartitionBoxSize.ToString ( ) ;  
         chkDivideSuperBoxes.Checked = _server.Configuration.DivideSuperBoxes ;
      }
      
      private void InitLoggingSettings ( ) 
      {
         chkEnableLog.Checked      = _server.Configuration.EnableLogging ;
         txtLogFile.Text           = _server.Configuration.LoggingFile ;
         chkLogInformation.Checked = _server.Configuration.LogInformation ;
         chkLogWarnings.Checked    = _server.Configuration.LogWarnings ;
         chkLogDebug.Checked       = _server.Configuration.LogDebug ;
         chkLogErrors.Checked      = _server.Configuration.LogErrors ;
         
         grpFileLog.Enabled = !_server.IsRunning ;
      }
      
      private void SetServerSttings ( )
      {
         _server.Configuration.ServerName         = txtServerName.Text ;
         _server.Configuration.IPAddress          = txtIpAddress.Text ;
         _server.Configuration.Port               = int.Parse ( mtxtPort.Text ) ;
         _server.Configuration.ImagesFolder       = txtImagesFolder.Text ;
         _server.Configuration.CacheFolder        = txtCacheFolder.Text ;
         _server.Configuration.CacheSize          = int.Parse ( mtxtCacheSize.Text ) ;
         
         int maxServerBandwidth = ( chkServerUnlimitedBandWidth.Checked ) ? -1 : int.Parse ( mtxtServerBandwidth.Text ) ;
         
         if ( ( maxServerBandwidth != - 1 ) && ( maxServerBandwidth < _server.Configuration.MaxConnectionBandwidth ) ) 
         {
            _server.Configuration.MaxConnectionBandwidth = int.Parse ( mtxtConnectionBW.Text ) ;
         }
         
         _server.Configuration.MaxServerBandwidth = maxServerBandwidth ;
         
         SetAliasFolders ( ) ;
      }
      
      private void SetClientsSettings ( ) 
      {
         _server.Configuration.MaxClientCount        = int.Parse ( mtxtMaxClients.Text ) ;
         _server.Configuration.ConnectionIdleTimeout = TimeSpan.FromSeconds ( double.Parse ( mtxtConnectionIdleTimeout.Text ) ) ;
         _server.Configuration.MaxSessionLifetime    = TimeSpan.FromSeconds ( double.Parse ( mtxtMaxSessionLife.Text  ) ) ;
         
         if ( chkClientUnlimitedBandWidth.Checked )
         {
            _server.Configuration.MaxConnectionBandwidth = -1 ;
         }
         else
         {
            _server.Configuration.MaxConnectionBandwidth = int.Parse ( mtxtConnectionBW.Text ) ;
         }
      }
      
      private void SetCommunicationSettings ( ) 
      {
         _server.Configuration.MaxTransportConnections = int.Parse ( mtxtMaxTransport.Text ) ;
         _server.Configuration.HandshakeTimeout        = TimeSpan.FromSeconds ( double.Parse ( mtxtHandshakeTimeout.Text ) ) ;
         _server.Configuration.ChunkSize               = int.Parse ( mtxtChunkSize.Text ) ;
         
         if ( chkCommunicationUnlimitedRequest.Checked ) 
         {
            _server.Configuration.RequestTimeout = TimeSpan.MaxValue ;
         }
         else
         {
            _server.Configuration.RequestTimeout = TimeSpan.FromSeconds ( double.Parse ( mtxtRequestTimeout.Text ) ) ;
         }
      }
      
      
      private void SetImagesSettings ( ) 
      {
         if ( chkImageParsingTimeout.Checked ) 
         {
            _server.Configuration.ImageParsingTimeout = TimeSpan.MaxValue ;
         }
         else
         {
            _server.Configuration.ImageParsingTimeout = TimeSpan.FromSeconds ( double.Parse ( mtxtParsingTimeout.Text ) ) ;
         }
         
         _server.Configuration.PartitionBoxSize = int.Parse ( mtxtPartitionSize.Text ) ;
         _server.Configuration.DivideSuperBoxes = chkDivideSuperBoxes.Checked ;
      }
      
      private void SetLoggingSettings ( ) 
      {
         _server.Configuration.EnableLogging  = chkEnableLog.Checked ;
         _server.Configuration.LoggingFile    = txtLogFile.Text ;
         _server.Configuration.LogInformation = chkLogInformation.Checked ;
         _server.Configuration.LogWarnings    = chkLogWarnings.Checked ;
         _server.Configuration.LogDebug       = chkLogDebug.Checked ;
         _server.Configuration.LogErrors      = chkLogErrors.Checked ;
      }
      
      private void FillAliasFolders ( ) 
      {
         foreach ( KeyValuePair <string, string> aliasToPath in _server.Configuration.AliasFolders )
         {
            lsvAliases.Items.Add ( new ListViewItem ( new string [ ] { aliasToPath.Key, aliasToPath.Value } ) ) ;
         }
      }
      
      private void SetAliasFolders ( )
      {
         _server.Configuration.ClearAliases ( ) ;
         
         foreach ( ListViewItem lstvItem in lsvAliases.Items )
         {
            _server.Configuration.AddAliasFolder ( lstvItem.Text, lstvItem.SubItems [ 1 ].Text ) ;
         }
      }
      
      private void FillDelegatedServers ( ) 
      {
         foreach ( DelegatedServer server in _server.Configuration.DelegateServers )
         {
            lsvServers.Items.Add ( new ListViewItem ( new string [ ] { server.IpAddress, server.Port.ToString ( ), server.HostLoad.ToString ( ) } ) ) ;
         }
      }
      
      private void SetDelegatedServers ( )
      {
         _server.Configuration.DelegateServers.Clear ( ) ;
         
         foreach ( ListViewItem lstvItem in lsvServers.Items )
         {
            _server.Configuration.DelegateServers.Add ( new DelegatedServer ( lstvItem.Text, int.Parse ( lstvItem.SubItems [ 1 ].Text ), int.Parse ( lstvItem.SubItems [ 2 ].Text ) ) ) ;
         }
      }
      
      private void SetConfiguration ( )
      {
         try
         {
            if ( _server == null ) 
            {
               throw new ApplicationException ( "Server not initialized" ) ;
            }
            
            SetServerSttings   ( ) ;
            SetClientsSettings ( ) ;
            SetCommunicationSettings ( ) ;
            SetImagesSettings ( ) ;
            SetLoggingSettings ( ) ;
            SetDelegatedServers ( ) ;
            
            try
            {
               _server.Configuration.Save ( ) ;
            }
            catch ( Exception exception ) 
            {
               Messager.ShowError ( this, 
                                    string.Format ( "Unable to save configuration values into configuration file, exact error is: {0}",
                                                    exception.Message ) ) ;
            }
         }
         catch ( Exception exception )
         {
            Messager.ShowError ( this,  exception ) ;
         }
      }

      private void btnApply_Click(object sender, EventArgs e)
      {
         SetConfiguration ( ) ;
      }

      private void btnBrowseImages_Click(object sender, EventArgs e)
      {
         folderBrowserDialog1.SelectedPath = txtImagesFolder.Text ;
         
         if ( folderBrowserDialog1.ShowDialog ( ) == DialogResult.OK )
         {
            txtImagesFolder.Text = folderBrowserDialog1.SelectedPath ;
         }
      }

      private void btnBrowseCache_Click(object sender, EventArgs e)
      {
         folderBrowserDialog1.SelectedPath = txtCacheFolder.Text ;
         
         if ( folderBrowserDialog1.ShowDialog ( ) == DialogResult.OK )
         {
            txtCacheFolder.Text = folderBrowserDialog1.SelectedPath ;
         }
      }

      private void btnBrowsePath_Click(object sender, EventArgs e)
      {
         folderBrowserDialog1.SelectedPath = txtAliasPath.Text ;
         if ( folderBrowserDialog1.ShowDialog ( ) == DialogResult.OK )
         {
            txtAliasPath.Text = folderBrowserDialog1.SelectedPath ;
         }
      }

      private void btnAdd_Click(object sender, EventArgs e)
      {
         if ( ( txtAlias.Text.Length != 0 ) && ( txtAliasPath.Text.Length != 0 ) )
         {
            if ( Directory.Exists ( txtAliasPath.Text ) )
            {
               lsvAliases.Items.Add ( new ListViewItem ( new string [ ] { txtAlias.Text, txtAliasPath.Text } ) ) ;
               
               txtAlias.Text     = string.Empty ;
               txtAliasPath.Text = string.Empty ;
            }
            else
            {
               Messager.ShowWarning ( this, "Alias path doesn't exist." ) ;
            }
         }
         else
         {
            Messager.ShowError ( this, "Please insert an alias and path information." ) ;
         }
      }

      private void btnRemove_Click(object sender, EventArgs e)
      {
         foreach ( ListViewItem selectedItem in lsvAliases.SelectedItems )
         {
            lsvAliases.Items.Remove ( selectedItem ) ;
         }
      }

      private void btnOK_Click(object sender, EventArgs e)
      {
         SetConfiguration ( ) ;
      }

      private void txtIpAddress_Validating(object sender, CancelEventArgs e)
      {
         TextBox textBox ;
         System.Net.IPAddress ipAddress ;
         
         
         textBox = ( TextBox ) sender ;
         
         if ( textBox == txtDelegatedServerIP )
         {
            if ( String.IsNullOrEmpty ( textBox.Text ) )
            {
               e.Cancel = false ;
               
               return ;
            }
         }
         
         if ( ( !System.Text.RegularExpressions.Regex.IsMatch ( textBox.Text, @"^[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}$" ) ) ||
              ( !System.Net.IPAddress.TryParse ( textBox.Text, out ipAddress ) ) )
         {
            Messager.ShowError ( this, "Invalid IP Address." ) ;

            e.Cancel = true ;
         }
         else
         {
            e.Cancel = false ;
         }
      }

      private void btnReset_Click(object sender, EventArgs e)
      {
         txtServerName.Text             = ConfigurationDefaults.ServerName ;
         txtIpAddress.Text              = ConfigurationDefaults.IPAddress ;
         mtxtPort.Text                  = ConfigurationDefaults.Port.ToString ( ) ;
         txtImagesFolder.Text           = ConfigurationDefaults.ImagesFolder ;
         txtCacheFolder.Text            = ConfigurationDefaults.CacheFolder ;
         mtxtServerBandwidth.Text       = ConfigurationDefaults.MaxServerBandwidth.ToString ( ) ;
         mtxtCacheSize.Text             = ConfigurationDefaults.CacheSize.ToString ( ) ;
         mtxtMaxClients.Text            = ConfigurationDefaults.MaxClientCount.ToString ( ) ;
         mtxtConnectionIdleTimeout.Text = ConfigurationDefaults.ConnectionIdleTimeout.ToString ( ) ;
         mtxtMaxSessionLife.Text        = ConfigurationDefaults.MaxSessionLifetime.ToString ( ) ;
         mtxtConnectionBW.Text          = ConfigurationDefaults.MaxConnectionBandwidth.ToString ( ) ;
         mtxtMaxTransport.Text          = ConfigurationDefaults.MaxTransportConnections.ToString ( ) ;
         mtxtHandshakeTimeout.Text      = ConfigurationDefaults.HandshakeTimeout.ToString ( ) ;
         mtxtRequestTimeout.Text        = ConfigurationDefaults.RequestTimeout.ToString ( ) ;
         mtxtChunkSize.Text             = ConfigurationDefaults.ChunkSize.ToString ( ) ;
         mtxtParsingTimeout.Text        = ConfigurationDefaults.ImageParsingTimeout.ToString ( ) ;
         mtxtPartitionSize.Text         = ConfigurationDefaults.PartitionBoxSize.ToString ( ) ;
         chkDivideSuperBoxes.Checked    = ConfigurationDefaults.DivideSuperBoxes ;
         chkEnableLog.Checked           = ConfigurationDefaults.EnableLogging ;
         txtLogFile.Text                = ConfigurationDefaults.LoggingFile ;
         chkLogInformation.Checked      = ConfigurationDefaults.LogInformation ;
         chkLogWarnings.Checked         = ConfigurationDefaults.LogWarnings ;
         chkLogDebug.Checked            = ConfigurationDefaults.LogDebug ;
         chkLogErrors.Checked           = ConfigurationDefaults.LogErrors ;
         
         lsvAliases.Items.Clear ( ) ;
         lsvServers.Items.Clear ( ) ;
      }

      private void btnAddDelegatedServer_Click(object sender, EventArgs e)
      {
         if ( ( txtDelegatedServerIP.Text.Length != 0 ) && 
              ( mtxtDelegatedServerPort.Text.Length != 0 ) &&
              ( mtxtDelegatedServerLoad.Text.Length != 0 ) )
         {
            lsvServers.Items.Add ( new ListViewItem ( new string [ ] { txtDelegatedServerIP.Text, mtxtDelegatedServerPort.Text, mtxtDelegatedServerLoad.Text } ) ) ;
            
            txtDelegatedServerIP.Text     = string.Empty ;
            mtxtDelegatedServerPort.Text  = string.Empty ;
            mtxtDelegatedServerLoad.Text  = string.Empty ;
         }
         else
         {
            Messager.ShowError ( this, "Please insert a valid IP address, port and server load values." ) ;
         }
      }

      private void btnRemoveDelegatedServer_Click(object sender, EventArgs e)
      {
         foreach ( ListViewItem selectedItem in lsvServers.SelectedItems )
         {
            lsvServers.Items.Remove ( selectedItem ) ;
         }
      }

      private void button1_Click(object sender, EventArgs e)
      {
         if ( openFileDialog1.ShowDialog ( ) == DialogResult.OK )
         {
            txtLogFile.Text = openFileDialog1.FileName ;
         }
      }

      private void chkClientUnlimitedBandWidth_CheckedChanged(object sender, EventArgs e)
      {
         mtxtConnectionBW.Enabled = !chkClientUnlimitedBandWidth.Checked ;
      }

      private void chkServerUnlimitedBandWidth_CheckedChanged(object sender, EventArgs e)
      {
         mtxtServerBandwidth.Enabled = !chkServerUnlimitedBandWidth.Checked ;
      }

      private void chkCommunicationUnlimitedRequest_CheckedChanged(object sender, EventArgs e)
      {
         mtxtRequestTimeout.Enabled = !chkCommunicationUnlimitedRequest.Checked ;
      }

      private void chkImageParsingTimeout_CheckedChanged(object sender, EventArgs e)
      {
         mtxtParsingTimeout.Enabled = !chkImageParsingTimeout.Checked ;
      }

      private void btnImportImage_Click(object sender, EventArgs e)
      {
         OpenFileDialog dlg = new OpenFileDialog();
         if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
         {
            try
            {
               using (RasterCodecs codecs = new RasterCodecs())
               {
                  string outfile = Path.GetFileNameWithoutExtension(dlg.FileName);
                  outfile += ".jp2";
                  outfile = Path.Combine(_server.Configuration.ImagesFolder, outfile);
                  if (File.Exists(outfile))
                     MessageBox.Show("Target file already exists.", "Cannot import", MessageBoxButtons.OK, MessageBoxIcon.Information);
                  else
                  {
                     this.Cursor = Cursors.WaitCursor;
                     codecs.Convert(dlg.FileName, outfile, Leadtools.RasterImageFormat.Jp2, 0, 0, 0, null);
                     this.Cursor = Cursors.Default;
                     MessageBox.Show(String.Format("{0} has been imported to {1}.", dlg.FileName, outfile), "Imported", MessageBoxButtons.OK, MessageBoxIcon.Information);
                  }
               }
            }
            catch (Exception ex)
            {
               MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
         }
      }
   }
}

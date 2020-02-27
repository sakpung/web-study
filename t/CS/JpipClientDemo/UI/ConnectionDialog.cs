// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using Leadtools.Jpip;
using Leadtools.Demos;

namespace JpipClientDemo
{
   public partial class ConnectionDialog : Form
   {
      string _defualtCacheDirectoryName;
      int _defaultPortNumber;
      int _defaultEnumerationServicePort;
      string _defaultIPAddress;
      int _defaultPacketSize;
      TimeSpan _defaultRequestTimeout;
      string _defaultChannelType;

      public ConnectionDialog()
      {
         InitializeComponent();

         DataSet channelTypeLookup = new DataSet();
         channelTypeLookup.Tables.Add();

         channelTypeLookup.Tables[0].Columns.Add("ConnectionName", typeof(string));
         channelTypeLookup.Tables[0].Columns.Add("ConnectionType", typeof(string));

         channelTypeLookup.Tables[0].Rows.Add(new object[] { "Stateless", JpipChannelTypes.StatelessChannel });
         channelTypeLookup.Tables[0].Rows.Add(new object[] { "HTTP", JpipChannelTypes.HttpChannel });
         channelTypeLookup.Tables[0].Rows.Add(new object[] { "HTTP TCP", JpipChannelTypes.HttpTcpChannel });

         cmbConnectionType.DataSource = channelTypeLookup.DefaultViewManager;
         cmbConnectionType.DisplayMember = channelTypeLookup.Tables[0].TableName + "." + channelTypeLookup.Tables[0].Columns[0].ColumnName;
         cmbConnectionType.ValueMember = channelTypeLookup.Tables[0].TableName + "." + channelTypeLookup.Tables[0].Columns[1].ColumnName;
         
         DataTable ipAddrressMap ;
         
         
         ipAddrressMap = new DataTable ( ) ;
         
         ipAddrressMap.Columns.Add ( "DisplayName", typeof ( string ) ) ;
         ipAddrressMap.Columns.Add ( "Value", typeof ( string ) ) ;
         
         ipAddrressMap.Rows.Add ( new object [ ] { "127.0.0.1 (localhost)", "127.0.0.1" } ) ;
         ipAddrressMap.Rows.Add(new object[] { "jpipserver.leadtools.com (LEAD hosted server)", "jpipserver.leadtools.com" });
         
         cmbIpAddress.DataSource = ipAddrressMap ;
         cmbIpAddress.DisplayMember = "DisplayName" ;
         cmbIpAddress.ValueMember   = "Value" ;

         cmbIpAddress.SelectionChangeCommitted += new EventHandler ( cmbIpAddress_SelectionChangeCommitted ) ;
         
         AppSettingsReader configReader = new AppSettingsReader();

         try { _defualtCacheDirectoryName = (string)configReader.GetValue("CacheDirectoryName", typeof(string)); } catch { _defualtCacheDirectoryName = Application.StartupPath; }
         try { _defaultPortNumber = (int)configReader.GetValue("PortNumber", typeof(int)); } catch { _defaultPortNumber = 49201 ; }
         try { _defaultIPAddress = (string)configReader.GetValue("IPAddress", typeof(string)); } catch { _defaultIPAddress = "127.0.0.1" ; }
         try { _defaultEnumerationServicePort = (int)configReader.GetValue ( "FileEnumerationPortNumber", typeof(int)); } catch { _defaultEnumerationServicePort = 49202 ; }
         try { _defaultPacketSize = (int)configReader.GetValue("PacketSize", typeof(int)); } catch { _defaultPacketSize = 16384 ; }
         try { _defaultRequestTimeout = TimeSpan.FromSeconds(((double)configReader.GetValue("RequestTimeout", typeof(double)))); } catch { _defaultRequestTimeout = TimeSpan.FromSeconds ( 60 ) ; }
         try { _defaultChannelType = (string)configReader.GetValue("ChannelType", typeof(string)); } catch { _defaultChannelType = "http" ; }
      }

      public string ChannelType
      {
         set { cmbConnectionType.SelectedValue = value; }
         get
         {
            return (string)cmbConnectionType.SelectedValue;
         }
      }

      public string IpAddress
      {
         set 
         { 
            cmbIpAddress.SelectedValue = value; 
            
            if ( cmbIpAddress.SelectedIndex == -1 )
            {
               cmbIpAddress.Text = value ;
            }
         }
         get
         {
            if (cmbIpAddress.Text != "")
            {
               if ( cmbIpAddress.SelectedIndex != -1 )
               {
                  return cmbIpAddress.SelectedValue.ToString ( ) ;
               }
               else
               {
                  return cmbIpAddress.Text ;
               }
            }
            else
            {
               return _defaultIPAddress ;
            }
         }
      }

      public int PortNumber
      {
         set { textPortNumber.Text = value.ToString(); }
         get
         {
            if (textPortNumber.Text != "")
               return Convert.ToInt32(textPortNumber.Text);
            else
               return _defaultPortNumber;
         }
      }
      
      public int EnumerationServicePort
      {
         set { txtEnumerationServicePort.Text = value.ToString(); }
         get
         {
            if (txtEnumerationServicePort.Text != "")
               return Convert.ToInt32(txtEnumerationServicePort.Text);
            else
               return _defaultEnumerationServicePort;
         }
      }
      

      public int PacketSize
      {
         set { textPacketSize.Text = value.ToString(); }
         get
         {
            if (textPacketSize.Text != "")
               return Convert.ToInt32(textPacketSize.Text);
            else
               return _defaultPacketSize;
         }
      }

      public TimeSpan RequestTimeout
      {
         set 
         { 
            textRequestTimeout.Text = value.TotalSeconds.ToString ( ) ; 
            
            if ( value == TimeSpan.MaxValue )
            {
               textRequestTimeout.Enabled = false ;
               chkRequestTimeout.Checked  = true ;
            }
            
         }
         get
         {
            if (chkRequestTimeout.Checked )
            {
               return TimeSpan.MaxValue ;
            }
            else if ( textRequestTimeout.Text != "")
            {
               return TimeSpan.FromSeconds(Convert.ToDouble(textRequestTimeout.Text));
            }
            else
            {
               return _defaultRequestTimeout ;
            }
         }
      }

      public string CacheDirectoryName
      {
         set { textCacheDirectoryName.Text = value; }
         get
         {
            if (textCacheDirectoryName.Text != "")
               return textCacheDirectoryName.Text;
            else
               return null; // mean don't use cache file
         }
      }

      private void OpenFolderDialogButton_Click(object sender, EventArgs e)
      {
         if( folderBrowserDialog.ShowDialog() == DialogResult.OK )
            textCacheDirectoryName.Text = folderBrowserDialog.SelectedPath;
      }

      private void btnOK_Click(object sender, EventArgs e)
      {
         if (cmbIpAddress.Text == "")
         {
            Messager.ShowError(this, "Invaild IP Address");
            this.DialogResult = System.Windows.Forms.DialogResult.None;
            return;
         }

         if (textPortNumber.Text == "")
         {
            Messager.ShowError(this, "Invaild Port Number");
            this.DialogResult = System.Windows.Forms.DialogResult.None;
            return;
         }

         if (textPacketSize.Text == "")
         {
            Messager.ShowError(this, "Invaild Packet Size");
            this.DialogResult = System.Windows.Forms.DialogResult.None;
            return;
         }

         if (textRequestTimeout.Text == "")
         {
            Messager.ShowError(this, "Invaild Request Timeout");
            this.DialogResult = System.Windows.Forms.DialogResult.None;
            return;
         }

         this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
      }

      private void btnDefault_Click(object sender, EventArgs e)
      {
         cmbConnectionType.SelectedValue = _defaultChannelType ;
         textCacheDirectoryName.Text     = _defualtCacheDirectoryName ;
         IpAddress                       = _defaultIPAddress ;
         textPortNumber.Text             = _defaultPortNumber.ToString ( ) ;
         EnumerationServicePort          = _defaultEnumerationServicePort ;
         textPacketSize.Text             = _defaultPacketSize.ToString ( ) ;
         textRequestTimeout.Text         = _defaultRequestTimeout.TotalSeconds.ToString ( ) ;
      }

      void cmbIpAddress_SelectionChangeCommitted ( object sender, EventArgs e )
      {
         if ( cmbIpAddress.SelectedIndex == 1 )
         {
            textPortNumber.Text = "49201"; //this is the port for LEAD public server.
            txtEnumerationServicePort.Text = "49202" ; //this is the port for LEAD public server enumeration service.
         }
      }

      private void chkRequestTimeout_CheckedChanged(object sender, EventArgs e)
      {
         textRequestTimeout.Enabled = !chkRequestTimeout.Checked ;
      }

   }
}

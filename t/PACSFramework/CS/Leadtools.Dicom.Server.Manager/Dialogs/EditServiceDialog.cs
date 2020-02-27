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
using System.Management;
using Leadtools.Dicom.AddIn.Common;
using System.IO;
using Leadtools.Dicom.Server.Manager.Properties;
using System.Collections;
using Leadtools.Demos;
using Leadtools.DicomDemos;

namespace Leadtools.Dicom.Server.Manager.Dialogs
{
    public partial class EditServiceDialog : Form
    {
        private ServerSettings _Settings;
        private List<ServerSettings> _Servers;

        public bool DirFocus = false;
        private DicomNetIpTypeFlags _ipType;

        public DicomNetIpTypeFlags IpType
        {
           get { return _ipType; }
           set { _ipType = value; }
        }

        public ServerSettings Settings
        {
            get
            {
                return _Settings;
            }
        }

        public void UpdateIpRadioButtons()
        {
           switch (_ipType)
           {
              case DicomNetIpTypeFlags.None:
              case DicomNetIpTypeFlags.Ipv4:
                 radioButtonIpv4.Checked = true;
                 break;
              case DicomNetIpTypeFlags.Ipv6:
                 radioButtonIpv6.Checked = true;
                 break;
              case DicomNetIpTypeFlags.Ipv4OrIpv6:
                 radioButtonIpv4Ipv6.Checked = true;
                 break;
           }
        }

        public void Initialize()
        {
              if (System.Net.Sockets.Socket.OSSupportsIPv6)
              {
                 radioButtonIpv6.Enabled = true;
                 radioButtonIpv4Ipv6.Enabled = true;
                 radioButtonIpv4Ipv6.Enabled = DemosGlobal.IsOnVistaOrLater;
              }
              else
              {
                 radioButtonIpv6.Enabled = false;
                 radioButtonIpv4Ipv6.Enabled = false;
                 _ipType = DicomNetIpTypeFlags.Ipv4;
              }

         this.ServerSecure.CheckedChanged += ServerSecure_CheckedChanged;
        }

      private void ServerSecure_CheckedChanged(object sender, EventArgs e)
      {
         if (ServerSecure.Checked)
         {
            if (Utils.VerifyOpensslVersion(this) == false)
            {
               ServerSecure.Checked = false;
            }
         }
      }

      public EditServiceDialog(ServerSettings settings)
        {
            InitializeComponent();

            _Settings = settings;
            Initialize();
        }

        public EditServiceDialog(ServerSettings settings, List<ServerSettings> servers)
        {
            InitializeComponent();

            _Settings = settings;
            _Servers = servers;
            InitializeStrings();
            Icon = Resources.ApplicationIcon;
            Initialize();
        }

        private void InitializeStrings()
        {
            //
            // Settings Tab
            //
            tabPageSettings.Text = Resources.SettingsTabPageLabel;
            tabPageAdvanced.Text = Resources.AdvancedTabPageLabel;
            labelAeTitle.Text = Resources.AeTitleLabel + ":";
            labelImplementationClass.Text = Resources.ImplementationClassLabel;
            labelDescription.Text = Resources.DescriptionLabel;
            labelImplementationVersionName.Text = Resources.ImplementationVersionNameLabel;
            labelIpAddress.Text = Resources.IPAddressLabel;
            labelTemporaryDirectory.Text = Resources.TemporaryDirectoryLabel;
            labelPort.Text = Resources.ServerPortLabel;
            labelMaxClients.Text = Resources.MaxClientsLabel;
            ServerSecure.Text = Resources.ServerSecureLabel;
            ServerAllowAnonymous.Text = Resources.AllowAnonymousLabel;

            //
            // Advanced Tab
            //
            labelDisplayName.Text = Resources.DisplayNameLabel;
            labelMaxPdu.Text = Resources.MaxPduLabel;
            groupBoxTimeout.Text = Resources.TimeoutGroupBoxLabel;
            labelClientTimeout.Text = Resources.ClientTimeoutLabel;
            labelReconnectTimeout.Text = Resources.ReconnectTimeoutLabel;
            labelAddInTimeout.Text = Resources.AddInTimeoutLabel;
            groupBoxSocketOptions.Text = Resources.SocketOptionsGroupBoxLabel;
            labelReceiveBuffer.Text = Resources.ReceiveBufferLabel;
            labelSendBuffer.Text = Resources.SendBufferLabel;
            NoDelay.Text = Resources.NoDelayLabel;
            labelStartMode.Text = Resources.StartModeLabel;

            buttonOk.Text = Resources.OkText;
            buttonCancel.Text = Resources.CancelText;
        }

        private void EditServerDialog_Load(object sender, EventArgs e)
        {
            labelError.Text = string.Empty; 

            if (_Settings == null)
            {
                ClientTimeout.Value = 300;
                ServerPort.Text = "104";
                ServerMaxClients.Text = "0";
                StartMode.Text = "Automatic";
                ReconnectTimeout.Value = 300;
                AddInTimeout.Value = 300;
                Text = Resources.AddNewServer;
                labelRestart.Text = string.Empty;
                TemporaryDirectory.Text = Path.GetTempPath();
                checkBoxImageCopy.Checked = false;
                MaxPduLength.Text = "46726";
            }
            else
            {
                Text = Resources.EditServer + " [" + _Settings.AETitle + "]";
                ServerAE.Text = _Settings.AETitle;
                ServerAE.Enabled = false;
                ServerAllowAnonymous.Checked = _Settings.AllowAnonymous;
                ServerDescription.Text = _Settings.Description;
                IpType = _Settings.IpType;
                ServerMaxClients.Text = _Settings.MaxClients.ToString();                
                ServerPort.Text = _Settings.Port.ToString();
                ServerSecure.Checked = _Settings.Secure;
                ClientTimeout.Value = Convert.ToDecimal(_Settings.ClientTimeout);
                TemporaryDirectory.Text = _Settings.TemporaryDirectory;
                ImplementationClass.Text = _Settings.ImplementationClass;
                ImplementationVersionName.Text = _Settings.ImplementationVersionName;                             
                DisplayName.Text = _Settings.DisplayName;
                MaxPduLength.Text = _Settings.MaxPduLength.ToString();
                ReconnectTimeout.Value = Convert.ToDecimal(_Settings.ReconnectTimeout);
                AddInTimeout.Value = Convert.ToDecimal(_Settings.AddInTimeout);
                NoDelay.Checked = _Settings.NoDelay;
                ReceiveBuffer.Text = _Settings.ReceiveBufferSize.ToString();
                SendBuffer.Text = _Settings.SendBufferSize.ToString();
                StartMode.Text = _Settings.StartMode;
                AllowMultipleConnections.Checked = _Settings.AllowMultipleConnections;
                if (StartMode.SelectedIndex == -1)
                    StartMode.SelectedIndex = 0;
                labelRestart.Text = "Server will need to be restarted for changes to take effect";
                checkBoxImageCopy.Checked = _Settings.DataSetImageCopy;
                numericUpDownPipes.Value = Convert.ToDecimal(_Settings.AdministrativePipes);
            }
            UpdateIpRadioButtons();

            if (DirFocus)
            {
                TemporaryDirectory.Focus();
                TemporaryDirectory.SelectAll();
            }
            else
                ServerAE.Focus();
            ServerAE_TextChanged(null, null);           
        }        

        private void EditServerDialog_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult == DialogResult.OK)
            {
                if (_Settings == null)
                {
                    _Settings = new ServerSettings();
                }

                if (ServerMaxClients.Text.Length == 0)
                    ServerMaxClients.Text = "0";

                if (ServerPort.Text.Length == 0)
                    ServerPort.Text = "0";

                _Settings.AETitle = ServerAE.Text;
                _Settings.AllowAnonymous = ServerAllowAnonymous.Checked;
                _Settings.Description = ServerDescription.Text;
                _Settings.IpAddress = ServerIp.Text;
                if (_Settings.IpAddress == "All")
                   _Settings.IpAddress = "*";
                _Settings.IpType = IpType;
                _Settings.MaxClients = Convert.ToInt32(ServerMaxClients.Text);                
                _Settings.Port = Convert.ToInt32(ServerPort.Text);
                _Settings.Secure = ServerSecure.Checked;
                _Settings.ClientTimeout = Convert.ToInt32(ClientTimeout.Value);
                _Settings.TemporaryDirectory = TemporaryDirectory.Text;
                _Settings.ImplementationClass = ImplementationClass.Text;
                _Settings.ImplementationVersionName = ImplementationVersionName.Text;               
                _Settings.DisplayName = DisplayName.Text;
                _Settings.ReconnectTimeout = Convert.ToInt32(ReconnectTimeout.Value);
                _Settings.AddInTimeout = Convert.ToInt32(AddInTimeout.Value);
                _Settings.NoDelay = NoDelay.Checked;
                _Settings.AllowMultipleConnections = AllowMultipleConnections.Checked;
                _Settings.DataSetImageCopy = checkBoxImageCopy.Checked;
                _Settings.AdministrativePipes = Convert.ToInt32(numericUpDownPipes.Value);

                if (MaxPduLength.Text.Length == 0)
                    _Settings.MaxPduLength = 46726;
                else
                    _Settings.MaxPduLength = Convert.ToInt32(MaxPduLength.Text);

                if (ReceiveBuffer.Text.Length == 0)
                    _Settings.ReceiveBufferSize = 29696;
                else
                    _Settings.ReceiveBufferSize = Convert.ToInt32(ReceiveBuffer.Text);

                if (SendBuffer.Text.Length == 0)
                    _Settings.SendBufferSize = 29696;
                else
                    _Settings.SendBufferSize = Convert.ToInt32(SendBuffer.Text);

                _Settings.StartMode = StartMode.Text;                
            }
        }

        private void InitIpList()
        {
           ArrayList ipListIpv4 = null;
           ArrayList ipListIpv6 = null;

         if (DemosGlobal.IsOnVistaOrLater)
            MainForm.GetIpListsVistaOrHigher(IpType, out ipListIpv4, out ipListIpv6);
         else
            MainForm.GetIpListsXp(IpType, out ipListIpv4, out ipListIpv6);

            ServerIp.Items.Clear();
            int index = 0;
            index = ServerIp.Items.Add("All");
            foreach (string s in ipListIpv4)
            {
               if (s != "0.0.0.0")
               {
                  index = ServerIp.Items.Add(s);
               }
            }

         foreach (string s in ipListIpv6)
         {
            index = ServerIp.Items.Add(s);
         }

         ServerIp.SelectedIndex = 0;
        }

        private void buttonFolderBrowse_Click(object sender, EventArgs e)
        {
            folderBrowserDialog.SelectedPath = TemporaryDirectory.Text;
            if (folderBrowserDialog.ShowDialog(this) == DialogResult.OK)
            {
                TemporaryDirectory.Text = folderBrowserDialog.SelectedPath;
            }
        }

        private void ServerPort_TextChanged(object sender, EventArgs e)
        {
            if (!IsPortValid())
            {
                buttonOk.Enabled = false;
                labelError.Text = "Port already in use";
            }
            else
            {
                buttonOk.Enabled = ServerAE.Text.Length > 0;
                labelError.Text = string.Empty;
            }
        }

        private bool IsPortValid()
        {
            int port = 0;

            if (int.TryParse(ServerPort.Text, out port))
            {
                foreach (ServerSettings setting in _Servers)
                {
                    if (_Settings!=null && setting.AETitle == _Settings.AETitle)
                        break;

                    if (port == setting.Port)
                    {                        
                        return false;
                    }
                }
            }
            return true;
        }

        private bool IsDirectoryValid()
        {
            if (TemporaryDirectory.Text != string.Empty)
            {
                string f = TemporaryDirectory.Text;

                if(f.IndexOfAny(Path.GetInvalidPathChars())!=-1)
                    return false;
            }

            return true;
        }        

        private void ServerPort_Leave(object sender, EventArgs e)
        {
            if (!IsPortValid())
                ServerPort.Focus();
        }

        private void TemporaryDirectory_TextChanged(object sender, EventArgs e)
        {
            if (!IsDirectoryValid())
            {
                buttonOk.Enabled = false;
                labelError.Text = "Invalid directory name";
            }
            else if(TemporaryDirectory.Text!=string.Empty && !Directory.Exists(TemporaryDirectory.Text))
            {
                buttonOk.Enabled = false;
                labelError.Text = "Temporary directory doesn't exist";
            }
            else
            {
                buttonOk.Enabled = true;
                labelError.Text = string.Empty;
            }
        }

        private void TemporaryDirectory_Leave(object sender, EventArgs e)
        {
            if (TemporaryDirectory.Text == string.Empty)
                return;

            if (!IsDirectoryValid() || !Directory.Exists(TemporaryDirectory.Text))
                TemporaryDirectory.Focus();
        }

        private void DisplayName_TextChanged(object sender, EventArgs e)
        {
            if (!IsDisplayNameValid())
            {
                buttonOk.Enabled = false;
                if(DisplayName.Text == string.Empty)
                    labelError.Text = "Service display name cannot be empty";
                else
                    labelError.Text = "Service display name already exist";
            }
            else
            {
                buttonOk.Enabled = ServerAE.Text.Length > 0;
                labelError.Text = string.Empty;
            }
        }

        private bool IsDisplayNameValid()
        {
            if (DisplayName.Text == string.Empty && _Settings == null)
                return true;
            else if (DisplayName.Text == string.Empty)
                return false;

            if (_Settings != null && _Settings.DisplayName == DisplayName.Text)
                return true;

            Service.ServiceCollection services = Service.GetInstances(string.Format("DisplayName = '{0}'",DisplayName.Text));

            return services.Count == 0;
        }        

        private void DisplayName_Leave(object sender, EventArgs e)
        {
            if (!IsDisplayNameValid())
                DisplayName.Focus();
        }

        private void ServerAE_KeyPress(object sender, KeyPressEventArgs e)
        {
            //
            // AE Title shouldn't have spaces.  This will also become the install name
            //  of our service.
            //
            if (e.KeyChar == ' ')
            {
                e.Handled = true;
            }
        }

        private void ServerAE_TextChanged(object sender, EventArgs e)
        {            
            if (buttonOk.Enabled)
            {               
                ServerPort_TextChanged(null, EventArgs.Empty);
            }
            if (buttonOk.Enabled)
            {
                DisplayName_TextChanged(null, EventArgs.Empty);
            }

            buttonOk.Enabled = ServerAE.Text.Length > 0;
        }

        private void UpdateIpType()
        {
         if (radioButtonIpv4.Checked)
            IpType = DicomNetIpTypeFlags.Ipv4;
         else if (radioButtonIpv6.Checked)
            IpType = DicomNetIpTypeFlags.Ipv6;
         else
            IpType = DicomNetIpTypeFlags.Ipv4OrIpv6;
        }

        private void radioButtonIp_CheckedChanged(object sender, EventArgs e)
        {
           RadioButton rb = sender as RadioButton;
           if (rb != null)
           {
              if (rb.Checked)
              {
                 UpdateIpType();
                 InitIpList();
                 if (_Settings == null)
                 {
                    ServerIp.Text = "All";
                 }
                 else
                 {
                    ServerIp.Text = _Settings.IpAddress == "*" ? "All" : _Settings.IpAddress;
                 }
              }
           }
        }

    }
}

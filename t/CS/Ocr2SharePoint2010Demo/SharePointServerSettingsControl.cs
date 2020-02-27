// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Ocr2SharePointDemo
{
   public partial class SharePointServerSettingsControl : UserControl
   {
      public SharePointServerSettingsControl()
      {
         InitializeComponent();
      }

      private SharePoint.SPListInfo[] _lists;
      [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
      public SharePoint.SPListInfo[] SharePointLists
      {
         get { return _lists; }
      }

      private SharePoint.SharePointServerSettings _serverSettings;
      [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
      public SharePoint.SharePointServerSettings ServerSettings
      {
         get { return _serverSettings; }
      }

      private MainForm _mainForm;
      public void SetOwner(MainForm mainForm)
      {
         _mainForm = mainForm;
      }

      public void SetServerSettings(SharePoint.SharePointServerSettings serverSettings)
      {
         _serverSettings = serverSettings;

         _urlTextBox.Text = _serverSettings.Uri;
         _useCredentialsCheckBox.Checked = _serverSettings.UserName != null;
         _userNameTextBox.Text = _serverSettings.UserName;
         _passwordTextBox.Text = _serverSettings.Password;
         _domainTextBox.Text = _serverSettings.Domain;
         _useProxyCheckBox.Checked = _serverSettings.ProxyUri != null;
         _hostTextBox.Text = _serverSettings.ProxyUri;
         _portTextBox.Text = _serverSettings.ProxyPort.ToString();

         UpdateUIState();
      }

      private void UpdateUIState()
      {
         _userNameTextBox.Enabled = _useCredentialsCheckBox.Checked;
         _passwordTextBox.Enabled = _useCredentialsCheckBox.Checked;
         _domainTextBox.Enabled = _useCredentialsCheckBox.Checked;

         _hostTextBox.Enabled = _useProxyCheckBox.Checked;
         _portTextBox.Enabled = _useProxyCheckBox.Checked;

         _connectButton.Enabled = !string.IsNullOrEmpty(_urlTextBox.Text);
      }

      private void _urlTextBox_TextChanged(object sender, EventArgs e)
      {
         UpdateUIState();
      }

      private void _useCredentialsCheckBox_CheckedChanged(object sender, EventArgs e)
      {
         UpdateUIState();
      }

      private void _useProxyCheckBox_CheckedChanged(object sender, EventArgs e)
      {
         UpdateUIState();
      }

      private SharePoint.SharePointServerSettings _serverSettingsToTry;

      private void _connectButton_Click(object sender, EventArgs e)
      {
         _serverSettingsToTry = new SharePoint.SharePointServerSettings();

         _serverSettingsToTry.Uri = _urlTextBox.Text.Trim();

         if (_useCredentialsCheckBox.Checked)
         {
            _serverSettingsToTry.UserName = _userNameTextBox.Text.Trim();
            _serverSettingsToTry.Password = _passwordTextBox.Text;
            _serverSettingsToTry.Domain = _domainTextBox.Text.Trim();
         }
         else
         {
            _serverSettingsToTry.UserName = null;
            _serverSettingsToTry.Password = null;
            _serverSettingsToTry.Domain = null;
         }

         if (_useProxyCheckBox.Checked)
         {
            _serverSettingsToTry.ProxyUri = _hostTextBox.Text.Trim();
            int.TryParse(_portTextBox.Text, out _serverSettingsToTry.ProxyPort);
         }
         else
         {
            _serverSettingsToTry.ProxyUri = null;
            _serverSettingsToTry.ProxyPort = 0;
         }

         // Try to connect
         _mainForm.BeginOperation(new MethodInvoker(TryConnect));
      }

      private void TryConnect()
      {
         _mainForm.SetOperationText("Connecting to SharePoint Server...");
         Exception error = null;

         try
         {
            // To make sure we can connect to this 2010 SharePoint Server, use
            // the helper to get the lists
            SharePoint.SPHelper helper = new SharePoint.SPHelper(_serverSettingsToTry);
            SharePoint.SPListInfo[] lists = helper.GetLists();

            if (lists == null || lists.Length == 0)
            {
               error = new Exception("Could not find any lists in the SharePoint Server.\n\nTry again with a different server.");
            }
            else
            {
               // We are golden, save the lists and the server properties
               _lists = lists;
               _serverSettings = _serverSettingsToTry;
            }
         }
         catch (Exception ex)
         {
            // Throw our own exception with info
            error = new Exception(string.Format("Error: {0}\n\nReasons might be:\n- Invalid credentials\n- Invalid Proxy settings\n- Server may not be SharePoint 2010. Try again with a valid URL to SharePoint 2010", ex.Message));
         }

         _mainForm.EndOperation(error);
      }
   }
}

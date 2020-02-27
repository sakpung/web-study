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
using System.Net;

namespace SharePointDemo
{
   public partial class ServerPropertiesDialog : Form
   {
      // The properties used for both input to
      // initialize the dialog and output if
      // the user change the settings
      private SharePointServerProperties _serverProperties;

      public ServerPropertiesDialog(SharePointServerProperties serverProperties)
      {
         InitializeComponent();

         _serverProperties = serverProperties;
      }

      public SharePointServerProperties ServerProperties
      {
         get { return _serverProperties; }
      }

      protected override void OnLoad(EventArgs e)
      {
         // Initialize the controls values from ServerProperties

         _urlTextBox.Text = _serverProperties.Url;

         _useCredentialsCheckBox.Checked = _serverProperties.UseCredentials;
         _userNameTextBox.Text = _serverProperties.UserName;
         _passwordTextBox.Text = _serverProperties.Password;
         _domainTextBox.Text = _serverProperties.Domain;

         _useProxyCheckBox.Checked = _serverProperties.UseProxy;
         _hostTextBox.Text = _serverProperties.Host;
         _portTextBox.Text = _serverProperties.Port.ToString();

         _useCredentialsCheckBox_CheckedChanged(this, EventArgs.Empty);
         _useProxyCheckBox_CheckedChanged(this, EventArgs.Empty);

         base.OnLoad(e);
      }

      private void _useCredentialsCheckBox_CheckedChanged(object sender, EventArgs e)
      {
         _userNameLabel.Enabled = _useCredentialsCheckBox.Checked;
         _userNameTextBox.Enabled = _useCredentialsCheckBox.Checked;
         _passwordLabel.Enabled = _useCredentialsCheckBox.Checked;
         _passwordTextBox.Enabled = _useCredentialsCheckBox.Checked;
         _domainLabel.Enabled = _useCredentialsCheckBox.Checked;
         _domainTextBox.Enabled = _useCredentialsCheckBox.Checked;
      }

      private void _useProxyCheckBox_CheckedChanged(object sender, EventArgs e)
      {
         _hostLabel.Enabled = _useProxyCheckBox.Checked;
         _hostTextBox.Enabled = _useProxyCheckBox.Checked;
         _portLabel.Enabled = _useProxyCheckBox.Checked;
         _portTextBox.Enabled = _useProxyCheckBox.Checked;
      }

      private void _okButton_Click(object sender, EventArgs e)
      {
         SharePointServerProperties tempProperties = new SharePointServerProperties();

         // Get and check the parameters

         tempProperties.Url = _urlTextBox.Text.Trim();

         if(!Uri.IsWellFormedUriString(tempProperties.Url, UriKind.Absolute))
         {
            MessageBox.Show(this, "Invalid URL format", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            _urlTextBox.SelectAll();
            _urlTextBox.Focus();
            DialogResult = DialogResult.None;
            return;
         }

         tempProperties.UseCredentials = _useCredentialsCheckBox.Checked;

         if(tempProperties.UseCredentials)
         {
            tempProperties.UserName = _userNameTextBox.Text.Trim();
            if(string.IsNullOrEmpty(tempProperties.UserName))
            {
               MessageBox.Show(this, "Enter a valid user name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
               _userNameTextBox.SelectAll();
               _userNameTextBox.Focus();
               DialogResult = DialogResult.None;
               return;
            }

            tempProperties.Password = _passwordTextBox.Text;
            tempProperties.Domain = _domainTextBox.Text;
         }

         tempProperties.UseProxy = _useProxyCheckBox.Checked;

         if(tempProperties.UseProxy)
         {
            tempProperties.Host = _hostTextBox.Text.Trim();

            if(!Uri.IsWellFormedUriString(tempProperties.Host, UriKind.Absolute))
            {
               MessageBox.Show(this, "Invalid URL format", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
               _hostTextBox.SelectAll();
               _hostTextBox.Focus();
               DialogResult = DialogResult.None;
               return;
            }

            if(!int.TryParse(_portTextBox.Text, out tempProperties.Port))
            {
               MessageBox.Show(this, "Invalid port number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
               _portTextBox.SelectAll();
               _portTextBox.Focus();
               DialogResult = DialogResult.None;
               return;
            }
         }

         _serverProperties = tempProperties;
      }
   }
}

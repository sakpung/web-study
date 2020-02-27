' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports System.Net

Namespace SharePointDemo
   Partial Public Class ServerPropertiesDialog : Inherits Form
      ' The properties used for both input to
      ' initialize the dialog and output if
      ' the user change the settings
      Private _serverProperties As SharePointServerProperties

      Public Sub New(ByVal serverProperties_Renamed As SharePointServerProperties)
         InitializeComponent()

         _serverProperties = serverProperties_Renamed
      End Sub

      Public ReadOnly Property ServerProperties() As SharePointServerProperties
         Get
            Return _serverProperties
         End Get
      End Property

      Protected Overrides Sub OnLoad(ByVal e As EventArgs)
         ' Initialize the controls values from ServerProperties

         _urlTextBox.Text = _serverProperties.Url

         _useCredentialsCheckBox.Checked = _serverProperties.UseCredentials
         _userNameTextBox.Text = _serverProperties.UserName
         _passwordTextBox.Text = _serverProperties.Password
         _domainTextBox.Text = _serverProperties.Domain

         _useProxyCheckBox.Checked = _serverProperties.UseProxy
         _hostTextBox.Text = _serverProperties.Host
         _portTextBox.Text = _serverProperties.Port.ToString()

         _useCredentialsCheckBox_CheckedChanged(Me, EventArgs.Empty)
         _useProxyCheckBox_CheckedChanged(Me, EventArgs.Empty)

         MyBase.OnLoad(e)
      End Sub

      Private Sub _useCredentialsCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _useCredentialsCheckBox.CheckedChanged
         _userNameLabel.Enabled = _useCredentialsCheckBox.Checked
         _userNameTextBox.Enabled = _useCredentialsCheckBox.Checked
         _passwordLabel.Enabled = _useCredentialsCheckBox.Checked
         _passwordTextBox.Enabled = _useCredentialsCheckBox.Checked
         _domainLabel.Enabled = _useCredentialsCheckBox.Checked
         _domainTextBox.Enabled = _useCredentialsCheckBox.Checked
      End Sub

      Private Sub _useProxyCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _useProxyCheckBox.CheckedChanged
         _hostLabel.Enabled = _useProxyCheckBox.Checked
         _hostTextBox.Enabled = _useProxyCheckBox.Checked
         _portLabel.Enabled = _useProxyCheckBox.Checked
         _portTextBox.Enabled = _useProxyCheckBox.Checked
      End Sub

      Private Sub _okButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _okButton.Click
         Dim tempProperties As SharePointServerProperties = New SharePointServerProperties()

         ' Get and check the parameters

         tempProperties.Url = _urlTextBox.Text.Trim()

         If (Not Uri.IsWellFormedUriString(tempProperties.Url, UriKind.Absolute)) Then
            MessageBox.Show(Me, "Invalid URL format", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            _urlTextBox.SelectAll()
            _urlTextBox.Focus()
            DialogResult = DialogResult.None
            Return
         End If

         tempProperties.UseCredentials = _useCredentialsCheckBox.Checked

         If tempProperties.UseCredentials Then
            tempProperties.UserName = _userNameTextBox.Text.Trim()
            If String.IsNullOrEmpty(tempProperties.UserName) Then
               MessageBox.Show(Me, "Enter a valid user name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
               _userNameTextBox.SelectAll()
               _userNameTextBox.Focus()
               DialogResult = DialogResult.None
               Return
            End If

            tempProperties.Password = _passwordTextBox.Text
            tempProperties.Domain = _domainTextBox.Text
         End If

         tempProperties.UseProxy = _useProxyCheckBox.Checked

         If tempProperties.UseProxy Then
            tempProperties.Host = _hostTextBox.Text.Trim()

            If (Not Uri.IsWellFormedUriString(tempProperties.Host, UriKind.Absolute)) Then
               MessageBox.Show(Me, "Invalid URL format", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
               _hostTextBox.SelectAll()
               _hostTextBox.Focus()
               DialogResult = DialogResult.None
               Return
            End If

            If (Not Integer.TryParse(_portTextBox.Text, tempProperties.Port)) Then
               MessageBox.Show(Me, "Invalid port number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
               _portTextBox.SelectAll()
               _portTextBox.Focus()
               DialogResult = DialogResult.None
               Return
            End If
         End If

         _serverProperties = tempProperties
      End Sub
   End Class
End Namespace

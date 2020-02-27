' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Drawing
Imports System.Data
Imports System.Text
Imports System.Windows.Forms

Namespace Ocr2SharePointDemo
   Partial Public Class SharePointServerSettingsControl : Inherits UserControl
      Public Sub New()
         InitializeComponent()
      End Sub

      Private _lists As SharePoint.SPListInfo()
      <DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
      Public ReadOnly Property SharePointLists() As SharePoint.SPListInfo()
         Get
            Return _lists
         End Get
      End Property

      Private _serverSettings As SharePoint.SharePointServerSettings
      <DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
      Public ReadOnly Property ServerSettings() As SharePoint.SharePointServerSettings
         Get
            Return _serverSettings
         End Get
      End Property

      Private _mainForm As MainForm
      Public Sub SetOwner(ByVal mainForm As MainForm)
         _mainForm = mainForm
      End Sub

      Public Sub SetServerSettings(ByVal serverSettings_Renamed As SharePoint.SharePointServerSettings)
         _serverSettings = serverSettings_Renamed

         _urlTextBox.Text = _serverSettings.Uri
         _useCredentialsCheckBox.Checked = Not _serverSettings.UserName Is Nothing
         _userNameTextBox.Text = _serverSettings.UserName
         _passwordTextBox.Text = _serverSettings.Password
         _domainTextBox.Text = _serverSettings.Domain
         _useProxyCheckBox.Checked = Not _serverSettings.ProxyUri Is Nothing
         _hostTextBox.Text = _serverSettings.ProxyUri
         _portTextBox.Text = _serverSettings.ProxyPort.ToString()

         UpdateUIState()
      End Sub

      Private Sub UpdateUIState()
         _userNameTextBox.Enabled = _useCredentialsCheckBox.Checked
         _passwordTextBox.Enabled = _useCredentialsCheckBox.Checked
         _domainTextBox.Enabled = _useCredentialsCheckBox.Checked

         _hostTextBox.Enabled = _useProxyCheckBox.Checked
         _portTextBox.Enabled = _useProxyCheckBox.Checked

         _connectButton.Enabled = Not String.IsNullOrEmpty(_urlTextBox.Text)
      End Sub

      Private Sub _urlTextBox_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _urlTextBox.TextChanged
         UpdateUIState()
      End Sub

      Private Sub _useCredentialsCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _useCredentialsCheckBox.CheckedChanged
         UpdateUIState()
      End Sub

      Private Sub _useProxyCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _useProxyCheckBox.CheckedChanged
         UpdateUIState()
      End Sub

      Private _serverSettingsToTry As SharePoint.SharePointServerSettings

      Private Sub _connectButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _connectButton.Click
         _serverSettingsToTry = New SharePoint.SharePointServerSettings()

         _serverSettingsToTry.Uri = _urlTextBox.Text.Trim()

         If _useCredentialsCheckBox.Checked Then
            _serverSettingsToTry.UserName = _userNameTextBox.Text.Trim()
            _serverSettingsToTry.Password = _passwordTextBox.Text
            _serverSettingsToTry.Domain = _domainTextBox.Text.Trim()
         Else
            _serverSettingsToTry.UserName = Nothing
            _serverSettingsToTry.Password = Nothing
            _serverSettingsToTry.Domain = Nothing
         End If

         If _useProxyCheckBox.Checked Then
            _serverSettingsToTry.ProxyUri = _hostTextBox.Text.Trim()
            Integer.TryParse(_portTextBox.Text, _serverSettingsToTry.ProxyPort)
         Else
            _serverSettingsToTry.ProxyUri = Nothing
            _serverSettingsToTry.ProxyPort = 0
         End If

         ' Try to connect
         _mainForm.BeginOperation(New MethodInvoker(AddressOf TryConnect))
      End Sub

      Private Sub TryConnect()
         BeginInvoke(New SetOperationTextDelegate(AddressOf _mainForm.SetOperationText), New Object() {"Connecting to SharePoint Server..."})
         Dim err As Exception = Nothing

         Try
            ' To make sure we can connect to this 2010 SharePoint Server, use
            ' the helper to get the lists
            Dim helper As SharePoint.SPHelper = New SharePoint.SPHelper(_serverSettingsToTry)
            Dim lists As SharePoint.SPListInfo() = helper.GetLists()

            If lists Is Nothing OrElse lists.Length = 0 Then
               err = New Exception("Could not find any lists in the SharePoint Server." & Constants.vbLf + Constants.vbLf & "Try again with a different server.")
            Else
               ' We are golden, save the lists and the server properties
               _lists = lists
               _serverSettings = _serverSettingsToTry
            End If
         Catch ex As Exception
            ' Throw our own exception with info
            err = New Exception(String.Format("Error: {0}" & Constants.vbLf + Constants.vbLf & "Reasons might be:" & Constants.vbLf & "- Invalid credentials" & Constants.vbLf & "- Invalid Proxy settings" & Constants.vbLf & "- Server may not be SharePoint 2010. Try again with a valid URL to SharePoint 2010", ex.Message))
         End Try

         _mainForm.EndOperation(err)
      End Sub
   End Class
End Namespace

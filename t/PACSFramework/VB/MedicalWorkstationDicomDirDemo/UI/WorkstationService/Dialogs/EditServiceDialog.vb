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
Imports System.Net
Imports System.Windows.Forms
Imports System.Management
Imports Leadtools.Dicom.AddIn.Common
Imports System.IO


Namespace Leadtools.Demos.Workstation
   Partial Public Class EditServiceDialog
	   Inherits Form
	  Public Enum EditMode
		 AddServer
		 EditServer
	  End Enum

	  Private _Settings As ServerSettings
	  Private _mode As EditMode

	  Public Property Settings() As ServerSettings
		 Get
			Return _Settings
		 End Get

		 Friend Set(ByVal value As ServerSettings)
			_Settings = value
		 End Set
	  End Property

	  Public Property ServiceName() As String
		 Get
			Return ServiceNameTextBox.Text
		 End Get

		 Set(ByVal value As String)
			ServiceNameTextBox.Text = value
		 End Set
	  End Property

	  Public Property Mode() As EditMode
		 Get
			Return _mode
		 End Get

		 Set(ByVal value As EditMode)
			_mode = value
		 End Set
	  End Property

		Public Sub New()
			Me.New(Nothing)

		End Sub

		Public Sub New(ByVal settings As ServerSettings)
			InitializeComponent()

			Icon = WorkstationUtils.GetApplicationIcon ()

			AddHandler ServerAETextBox.Validating, AddressOf ServerAE_Validating
			AddHandler ServerAETextBox.Validated, AddressOf ServerAETextBox_Validated

			Settings = settings
		End Sub

		Private Sub ServerAE_Validating(ByVal sender As Object, ByVal e As CancelEventArgs)
			If ServerAETextBox.Text.Length = 0 Then
			   ControlsErrorProvider.SetError (ServerAETextBox, "AE Title can't be empty.")

			   e.Cancel = True
			ElseIf ServerAETextBox.Text.Length > 16 Then
			   ControlsErrorProvider.SetError (ServerAETextBox, "AE Title must be less than 16 characters.")

			   e.Cancel = True
			Else
			   ControlsErrorProvider.SetError (ServerAETextBox, String.Empty)
			End If
		End Sub

	  Private Sub ServerAETextBox_Validated(ByVal sender As Object, ByVal e As EventArgs)
		 If Mode = EditMode.AddServer Then
			ServiceNameTextBox.Text = ServerAETextBox.Text
		 End If
	  End Sub

		Private Sub EditServerDialog_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
			ErrorLabel.Text = String.Empty
			LoadIps ()

			If _Settings Is Nothing Then
				ClientTimeoutNumericUpDown.Value = 300
				ServerPortMaskedNumeric.Value = 205
				ServerMaxClientsMaskedNumeric.Value = 5
				StartModeComboBox.Text = "Automatic"
				ReconnectTimeoutNumericUpDown.Value = 300
				AddInTimeoutNumericUpDown.Value = 300
				Text = "Add New Server"
				RestartLabel.Text = String.Empty
				TemporaryDirectoryTextBox.Text = Path.GetTempPath()
			Else
			   If Mode = EditMode.AddServer Then
				  Text = "Add New Server"
			   Else
				  Text = "Edit Server" & " [" & _Settings.AETitle & "]"
			   End If

				ServerAETextBox.Text = _Settings.AETitle
				ServerAllowAnonymousCheckBox.Checked = _Settings.AllowAnonymous
				ServerDescriptionTextBox.Text = _Settings.Description

				If ServerIpComboBox.Items.Contains (_Settings.IpAddress) Then
				  ServerIpComboBox.SelectedItem = _Settings.IpAddress
				End If

				ServerMaxClientsMaskedNumeric.Value = _Settings.MaxClients
				ServerPortMaskedNumeric.Value = _Settings.Port
				ServerSecureCheckBox.Checked = _Settings.Secure
				ClientTimeoutNumericUpDown.Value = Convert.ToDecimal(_Settings.ClientTimeout)
				TemporaryDirectoryTextBox.Text = _Settings.TemporaryDirectory
				ImplementationClassTextBox.Text = _Settings.ImplementationClass
				ImplementationVersionNameTextBox.Text = _Settings.ImplementationVersionName
				DisplayNameTextBox.Text = _Settings.DisplayName
				MaxPduLengthMaskedTextBox.Text = _Settings.MaxPduLength.ToString()
				ReconnectTimeoutNumericUpDown.Value = Convert.ToDecimal(_Settings.ReconnectTimeout)
				AddInTimeoutNumericUpDown.Value = Convert.ToDecimal(_Settings.AddInTimeout)
				NoDelayCheckBox.Checked = _Settings.NoDelay
				ReceiveBufferNumericUpDown.Text = _Settings.ReceiveBufferSize.ToString()
				SendBufferNumericUpDown.Text = _Settings.SendBufferSize.ToString()
				StartModeComboBox.Text = _Settings.StartMode
				AllowMultipleConnectionsChcekBox.Checked = _Settings.AllowMultipleConnections
				If StartModeComboBox.SelectedIndex = -1 Then
					StartModeComboBox.SelectedIndex = 0
				End If
				RestartLabel.Text = "Server will need to be restarted for changes to take effect"
			End If


			ServerAETextBox.Focus()

			ServerAE_TextChanged (Nothing, Nothing)
		End Sub

		Private Sub EditServerDialog_FormClosing(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles MyBase.FormClosing
			If DialogResult = System.Windows.Forms.DialogResult.OK Then
				If _Settings Is Nothing Then
					_Settings = New ServerSettings()
				End If

				_Settings.AETitle = ServerAETextBox.Text
				_Settings.AllowAnonymous = ServerAllowAnonymousCheckBox.Checked
				_Settings.Description = ServerDescriptionTextBox.Text
				_Settings.IpAddress = ServerIpComboBox.Text
				_Settings.MaxClients = CInt(Fix(ServerMaxClientsMaskedNumeric.Value))
				_Settings.Port = CInt(Fix(ServerPortMaskedNumeric.Value))
				_Settings.Secure = ServerSecureCheckBox.Checked
				_Settings.ClientTimeout = Convert.ToInt32(ClientTimeoutNumericUpDown.Value)
				_Settings.TemporaryDirectory = TemporaryDirectoryTextBox.Text
				_Settings.ImplementationClass = ImplementationClassTextBox.Text
				_Settings.ImplementationVersionName = ImplementationVersionNameTextBox.Text
				_Settings.DisplayName = DisplayNameTextBox.Text
				_Settings.ReconnectTimeout = Convert.ToInt32(ReconnectTimeoutNumericUpDown.Value)
				_Settings.AddInTimeout = Convert.ToInt32(AddInTimeoutNumericUpDown.Value)
				_Settings.NoDelay = NoDelayCheckBox.Checked
				_Settings.AllowMultipleConnections = AllowMultipleConnectionsChcekBox.Checked

				If MaxPduLengthMaskedTextBox.Text.Length = 0 Then
					_Settings.MaxPduLength = -1
				Else
					_Settings.MaxPduLength = Convert.ToInt32(MaxPduLengthMaskedTextBox.Text)
				End If

				If ReceiveBufferNumericUpDown.Text.Length = 0 Then
					_Settings.ReceiveBufferSize = 29696
				Else
					_Settings.ReceiveBufferSize = Convert.ToInt32(ReceiveBufferNumericUpDown.Text)
				End If

				If SendBufferNumericUpDown.Text.Length = 0 Then
					_Settings.SendBufferSize = 29696
				Else
					_Settings.SendBufferSize = Convert.ToInt32(SendBufferNumericUpDown.Text)
				End If

				_Settings.StartMode = StartModeComboBox.Text
			End If
		End Sub

		 Private Sub LoadIps()
			Dim hostName As String
			Dim localIpAddress() As IPAddress


			hostName = Dns.GetHostName ()

			ServerIpComboBox.Items.Add (hostName)

			localIpAddress = Dns.GetHostAddresses (hostName)

			For Each address As IPAddress In localIpAddress
			   If address.AddressFamily = System.Net.Sockets.AddressFamily.InterNetwork Then
				  ServerIpComboBox.Items.Add (address.ToString ())
			   End If
			Next address

			If ServerIpComboBox.Items.Count > 0 Then
				ServerIpComboBox.SelectedIndex = 0
			End If

			ServerIpComboBox.Enabled = ServerIpComboBox.Items.Count > 1
		 End Sub

		Private Sub buttonFolderBrowse_Click(ByVal sender As Object, ByVal e As EventArgs) Handles TempFolderBrowseButton.Click
			TempFolderBrowserDialog.SelectedPath = TemporaryDirectoryTextBox.Text
			If TempFolderBrowserDialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK Then
				TemporaryDirectoryTextBox.Text = TempFolderBrowserDialog.SelectedPath
			End If
		End Sub

		Private Function IsDirectoryValid() As Boolean
			If TemporaryDirectoryTextBox.Text <> String.Empty Then
				Dim f As String = TemporaryDirectoryTextBox.Text

				If f.IndexOfAny(Path.GetInvalidPathChars())<>-1 Then
					Return False
				End If
			End If

			Return True
		End Function

		Private Sub TemporaryDirectory_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles TemporaryDirectoryTextBox.TextChanged
			If (Not IsDirectoryValid()) Then
				OkButton.Enabled = False
				ErrorLabel.Text = "Invalid directory name"
			ElseIf TemporaryDirectoryTextBox.Text<>String.Empty AndAlso (Not Directory.Exists(TemporaryDirectoryTextBox.Text)) Then
				OkButton.Enabled = False
				ErrorLabel.Text = "Temporary directory doesn't exist"
			Else
				OkButton.Enabled = True
				ErrorLabel.Text = String.Empty
			End If
		End Sub

		Private Sub TemporaryDirectory_Leave(ByVal sender As Object, ByVal e As EventArgs) Handles TemporaryDirectoryTextBox.Leave
			If TemporaryDirectoryTextBox.Text = String.Empty Then
				Return
			End If

			If (Not IsDirectoryValid()) OrElse (Not Directory.Exists(TemporaryDirectoryTextBox.Text)) Then
				TemporaryDirectoryTextBox.Focus()
			End If
		End Sub

		Private Sub DisplayName_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles DisplayNameTextBox.TextChanged
			If (Not IsDisplayNameValid()) Then
				OkButton.Enabled = False
				If DisplayNameTextBox.Text = String.Empty Then
					ErrorLabel.Text = "Service display name cannot be empty"
				Else
					ErrorLabel.Text = "Service display name already exist"
				End If
			Else
				OkButton.Enabled = ServerAETextBox.Text.Length > 0
				ErrorLabel.Text = String.Empty
			End If
		End Sub

		Private Function IsDisplayNameValid() As Boolean
			If DisplayNameTextBox.Text = String.Empty AndAlso _Settings Is Nothing Then
				Return True
			ElseIf DisplayNameTextBox.Text = String.Empty Then
				Return False
			End If

			If _Settings IsNot Nothing AndAlso _Settings.DisplayName = DisplayNameTextBox.Text Then
				Return True
			End If

			Return True
		End Function

		Private Sub DisplayName_Leave(ByVal sender As Object, ByVal e As EventArgs) Handles DisplayNameTextBox.Leave
			If (Not IsDisplayNameValid()) Then
				DisplayNameTextBox.Focus()
			End If
		End Sub

		Private Sub ServerAE_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles ServerAETextBox.KeyPress
			'
			' AE Title shouldn't have spaces.  This will also become the install name
			'  of our service.
			'
			If e.KeyChar = " "c Then
				e.Handled = True
			End If
		End Sub

		Private Sub ServerAE_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ServerAETextBox.TextChanged
			If OkButton.Enabled Then
				DisplayName_TextChanged(Nothing, EventArgs.Empty)
			End If

			OkButton.Enabled = ServerAETextBox.Text.Length > 0
		End Sub
   End Class
End Namespace

' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports System.Management
Imports Leadtools.Dicom.AddIn.Common
Imports System.IO
Imports System.Collections
Imports Leadtools.DicomDemos

Namespace Leadtools.Dicom.Server.Manager.Dialogs
    Partial Public Class EditServiceDialog
        Inherits Form
        Private _Settings As ServerSettings
        Private _Servers As List(Of ServerSettings)

        Public DirFocus As Boolean = False

        Private _ipType As DicomNetIpTypeFlags

        Public Property IpType() As DicomNetIpTypeFlags
            Get
                Return _ipType
            End Get
            Set(ByVal value As DicomNetIpTypeFlags)
                _ipType = value
            End Set
        End Property

        Public ReadOnly Property Settings() As ServerSettings
            Get
                Return _Settings
            End Get
        End Property

        Public Sub UpdateIpRadioButtons()
            Select Case _ipType
                Case DicomNetIpTypeFlags.None, DicomNetIpTypeFlags.Ipv4
                    radioButtonIpv4.Checked = True
                Case DicomNetIpTypeFlags.Ipv6
                    radioButtonIpv6.Checked = True
                Case DicomNetIpTypeFlags.Ipv4OrIpv6
                    radioButtonIpv4Ipv6.Checked = True
            End Select
        End Sub

        Public Sub Initialize()
            If System.Net.Sockets.Socket.OSSupportsIPv6 Then
                radioButtonIpv6.Enabled = True
                radioButtonIpv4Ipv6.Enabled = True
                radioButtonIpv4Ipv6.Enabled = DemosGlobal.IsOnVistaOrLater
            Else
                radioButtonIpv6.Enabled = False
                radioButtonIpv4Ipv6.Enabled = False
                _ipType = DicomNetIpTypeFlags.Ipv4
            End If
        End Sub

        Private Sub ServerSecure_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ServerSecure.CheckedChanged
            If ServerSecure.Checked Then
                If Utils.VerifyOpensslVersion(Me) = False Then
                    ServerSecure.Checked = False
                End If
            End If
        End Sub

        Public Sub New(ByVal settings As ServerSettings)
            InitializeComponent()

            _Settings = settings
            Initialize()
        End Sub

        Public Sub New(ByVal settings As ServerSettings, ByVal servers As List(Of ServerSettings))
            InitializeComponent()

            _Settings = settings
            _Servers = servers
            InitializeStrings()
            Icon = My.Resources.ApplicationIcon
            Initialize()
        End Sub

        Private Sub InitializeStrings()
            '
            ' Settings Tab
            '
            tabPageSettings.Text = My.Resources.SettingsTabPageLabel
            tabPageAdvanced.Text = My.Resources.AdvancedTabPageLabel
            labelAeTitle.Text = My.Resources.AeTitleLabel & ":"
            labelImplementationClass.Text = My.Resources.ImplementationClassLabel
            labelDescription.Text = My.Resources.DescriptionLabel
            labelImplementationVersionName.Text = My.Resources.ImplementationVersionNameLabel
            labelIpAddress.Text = My.Resources.IPAddressLabel
            labelTemporaryDirectory.Text = My.Resources.TemporaryDirectoryLabel
            labelPort.Text = My.Resources.ServerPortLabel
            labelMaxClients.Text = My.Resources.MaxClientsLabel
            ServerSecure.Text = My.Resources.ServerSecureLabel
            ServerAllowAnonymous.Text = My.Resources.AllowAnonymousLabel

            '
            ' Advanced Tab
            '
            labelDisplayName.Text = My.Resources.DisplayNameLabel
            labelMaxPdu.Text = My.Resources.MaxPduLabel
            groupBoxTimeout.Text = My.Resources.TimeoutGroupBoxLabel
            labelClientTimeout.Text = My.Resources.ClientTimeoutLabel
            labelReconnectTimeout.Text = My.Resources.ReconnectTimeoutLabel
            labelAddInTimeout.Text = My.Resources.AddInTimeoutLabel
            groupBoxSocketOptions.Text = My.Resources.SocketOptionsGroupBoxLabel
            labelReceiveBuffer.Text = My.Resources.ReceiveBufferLabel
            labelSendBuffer.Text = My.Resources.SendBufferLabel
            NoDelay.Text = My.Resources.NoDelayLabel
            labelStartMode.Text = My.Resources.StartModeLabel

            buttonOk.Text = My.Resources.OkText
            buttonCancel.Text = My.Resources.CancelText
        End Sub

        Private Sub EditServerDialog_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
            labelError.Text = String.Empty

            If _Settings Is Nothing Then
                ClientTimeout.Value = 300
                ServerPort.Text = "104"
                ServerMaxClients.Text = "0"
                StartMode.Text = "Automatic"
                ReconnectTimeout.Value = 300
                AddInTimeout.Value = 300
                Text = My.Resources.AddNewServer
                labelRestart.Text = String.Empty
                TemporaryDirectory.Text = Path.GetTempPath()
                checkBoxImageCopy.Checked = False
                MaxPduLength.Text = "46726"
            Else
                Text = My.Resources.EditServer & " [" & _Settings.AETitle & "]"
                ServerAE.Text = _Settings.AETitle
                ServerAE.Enabled = False
                ServerAllowAnonymous.Checked = _Settings.AllowAnonymous
                ServerDescription.Text = _Settings.Description
                IpType = _Settings.IpType
                ServerMaxClients.Text = _Settings.MaxClients.ToString()
                ServerPort.Text = _Settings.Port.ToString()
                ServerSecure.Checked = _Settings.Secure
                ClientTimeout.Value = Convert.ToDecimal(_Settings.ClientTimeout)
                TemporaryDirectory.Text = _Settings.TemporaryDirectory
                ImplementationClass.Text = _Settings.ImplementationClass
                ImplementationVersionName.Text = _Settings.ImplementationVersionName
                DisplayName.Text = _Settings.DisplayName
                MaxPduLength.Text = _Settings.MaxPduLength.ToString()
                ReconnectTimeout.Value = Convert.ToDecimal(_Settings.ReconnectTimeout)
                AddInTimeout.Value = Convert.ToDecimal(_Settings.AddInTimeout)
                NoDelay.Checked = _Settings.NoDelay
                ReceiveBuffer.Text = _Settings.ReceiveBufferSize.ToString()
                SendBuffer.Text = _Settings.SendBufferSize.ToString()
                StartMode.Text = _Settings.StartMode
                AllowMultipleConnections.Checked = _Settings.AllowMultipleConnections
                If StartMode.SelectedIndex = -1 Then
                    StartMode.SelectedIndex = 0
                End If
                labelRestart.Text = "Server will need to be restarted for changes to take effect"
                checkBoxImageCopy.Checked = _Settings.DataSetImageCopy
                numericUpDownPipes.Value = Convert.ToDecimal(_Settings.AdministrativePipes)
            End If
            UpdateIpRadioButtons()

            If DirFocus Then
                TemporaryDirectory.Focus()
                TemporaryDirectory.SelectAll()
            Else
                ServerAE.Focus()
            End If
            ServerAE_TextChanged(Nothing, Nothing)
        End Sub

        Private Sub EditServerDialog_FormClosing(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles MyBase.FormClosing
            If DialogResult = System.Windows.Forms.DialogResult.OK Then
                If _Settings Is Nothing Then
                    _Settings = New ServerSettings()
                End If

                If ServerMaxClients.Text.Length = 0 Then
                    ServerMaxClients.Text = "0"
                End If

                If ServerPort.Text.Length = 0 Then
                    ServerPort.Text = "0"
                End If

                _Settings.AETitle = ServerAE.Text
                _Settings.AllowAnonymous = ServerAllowAnonymous.Checked
                _Settings.Description = ServerDescription.Text
                _Settings.IpAddress = ServerIp.Text
                If _Settings.IpAddress = "All" Then
                    _Settings.IpAddress = "*"
                End If
                _Settings.IpType = IpType
                _Settings.MaxClients = Convert.ToInt32(ServerMaxClients.Text)
                _Settings.Port = Convert.ToInt32(ServerPort.Text)
                _Settings.Secure = ServerSecure.Checked
                _Settings.ClientTimeout = Convert.ToInt32(ClientTimeout.Value)
                _Settings.TemporaryDirectory = TemporaryDirectory.Text
                _Settings.ImplementationClass = ImplementationClass.Text
                _Settings.ImplementationVersionName = ImplementationVersionName.Text
                _Settings.DisplayName = DisplayName.Text
                _Settings.ReconnectTimeout = Convert.ToInt32(ReconnectTimeout.Value)
                _Settings.AddInTimeout = Convert.ToInt32(AddInTimeout.Value)
                _Settings.NoDelay = NoDelay.Checked
                _Settings.AllowMultipleConnections = AllowMultipleConnections.Checked
                _Settings.DataSetImageCopy = checkBoxImageCopy.Checked
                _Settings.AdministrativePipes = Convert.ToInt32(numericUpDownPipes.Value)

                If MaxPduLength.Text.Length = 0 Then
                    _Settings.MaxPduLength = 46726
                Else
                    _Settings.MaxPduLength = Convert.ToInt32(MaxPduLength.Text)
                End If

                If ReceiveBuffer.Text.Length = 0 Then
                    _Settings.ReceiveBufferSize = 29696
                Else
                    _Settings.ReceiveBufferSize = Convert.ToInt32(ReceiveBuffer.Text)
                End If

                If SendBuffer.Text.Length = 0 Then
                    _Settings.SendBufferSize = 29696
                Else
                    _Settings.SendBufferSize = Convert.ToInt32(SendBuffer.Text)
                End If

                _Settings.StartMode = StartMode.Text
            End If
        End Sub

        Private Sub InitIpList()
            Dim ipListIpv4 As ArrayList = Nothing
            Dim ipListIpv6 As ArrayList = Nothing

            If DemosGlobal.IsOnVistaOrLater Then
                MainForm.GetIpListsVistaOrHigher(IpType, ipListIpv4, ipListIpv6)
            Else
                MainForm.GetIpListsXp(IpType, ipListIpv4, ipListIpv6)
            End If

            ServerIp.Items.Clear()
            Dim index As Integer = 0
            index = ServerIp.Items.Add("All")
            For Each s As String In ipListIpv4
                If s <> "0.0.0.0" Then
                    index = ServerIp.Items.Add(s)
                End If
            Next s

            For Each s As String In ipListIpv6
                index = ServerIp.Items.Add(s)
            Next s

            ServerIp.SelectedIndex = 0
        End Sub

        Private Sub buttonFolderBrowse_Click(ByVal sender As Object, ByVal e As EventArgs)
            folderBrowserDialog.SelectedPath = TemporaryDirectory.Text
            If folderBrowserDialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK Then
                TemporaryDirectory.Text = folderBrowserDialog.SelectedPath
            End If
        End Sub

        Private Sub ServerPort_TextChanged(ByVal sender As Object, ByVal e As EventArgs)
            If (Not IsPortValid()) Then
                buttonOk.Enabled = False
                labelError.Text = "Port already in use"
            Else
                buttonOk.Enabled = ServerAE.Text.Length > 0
                labelError.Text = String.Empty
            End If
        End Sub

        Private Function IsPortValid() As Boolean
            Dim port As Integer = 0

            If Integer.TryParse(ServerPort.Text, port) Then
                For Each setting As ServerSettings In _Servers
                    If _Settings IsNot Nothing AndAlso setting.AETitle = _Settings.AETitle Then
                        Exit For
                    End If

                    If port = setting.Port Then
                        Return False
                    End If
                Next setting
            End If
            Return True
        End Function

        Private Function IsDirectoryValid() As Boolean
            If TemporaryDirectory.Text <> String.Empty Then
                Dim f As String = TemporaryDirectory.Text

                If f.IndexOfAny(Path.GetInvalidPathChars()) <> -1 Then
                    Return False
                End If
            End If

            Return True
        End Function

        Private Sub ServerPort_Leave(ByVal sender As Object, ByVal e As EventArgs)
            If (Not IsPortValid()) Then
                ServerPort.Focus()
            End If
        End Sub

        Private Sub TemporaryDirectory_TextChanged(ByVal sender As Object, ByVal e As EventArgs)
            If (Not IsDirectoryValid()) Then
                buttonOk.Enabled = False
                labelError.Text = "Invalid directory name"
            ElseIf TemporaryDirectory.Text <> String.Empty AndAlso (Not Directory.Exists(TemporaryDirectory.Text)) Then
                buttonOk.Enabled = False
                labelError.Text = "Temporary directory doesn't exist"
            Else
                buttonOk.Enabled = True
                labelError.Text = String.Empty
            End If
        End Sub

        Private Sub TemporaryDirectory_Leave(ByVal sender As Object, ByVal e As EventArgs)
            If TemporaryDirectory.Text = String.Empty Then
                Return
            End If

            If (Not IsDirectoryValid()) OrElse (Not Directory.Exists(TemporaryDirectory.Text)) Then
                TemporaryDirectory.Focus()
            End If
        End Sub

        Private Sub DisplayName_TextChanged(ByVal sender As Object, ByVal e As EventArgs)
            If (Not IsDisplayNameValid()) Then
                buttonOk.Enabled = False
                If DisplayName.Text = String.Empty Then
                    labelError.Text = "Service display name cannot be empty"
                Else
                    labelError.Text = "Service display name already exist"
                End If
            Else
                buttonOk.Enabled = ServerAE.Text.Length > 0
                labelError.Text = String.Empty
            End If
        End Sub

        Private Function IsDisplayNameValid() As Boolean
            If DisplayName.Text = String.Empty AndAlso _Settings Is Nothing Then
                Return True
            ElseIf DisplayName.Text = String.Empty Then
                Return False
            End If

            If _Settings IsNot Nothing AndAlso _Settings.DisplayName = DisplayName.Text Then
                Return True
            End If

            Dim services As Service.ServiceCollection = Service.GetInstances(String.Format("DisplayName = '{0}'", DisplayName.Text))

            Return services.Count = 0
        End Function

        Private Sub DisplayName_Leave(ByVal sender As Object, ByVal e As EventArgs)
            If (Not IsDisplayNameValid()) Then
                DisplayName.Focus()
            End If
        End Sub

        Private Sub ServerAE_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs)
            '
            ' AE Title shouldn't have spaces.  This will also become the install name
            '  of our service.
            '
            If e.KeyChar = " "c Then
                e.Handled = True
            End If
        End Sub

        Private Sub ServerAE_TextChanged(ByVal sender As Object, ByVal e As EventArgs)
            If buttonOk.Enabled Then
                ServerPort_TextChanged(Nothing, EventArgs.Empty)
            End If
            If buttonOk.Enabled Then
                DisplayName_TextChanged(Nothing, EventArgs.Empty)
            End If

            buttonOk.Enabled = ServerAE.Text.Length > 0
        End Sub

        Private Sub UpdateIpType()
            If radioButtonIpv4.Checked Then
                IpType = DicomNetIpTypeFlags.Ipv4
            ElseIf radioButtonIpv6.Checked Then
                IpType = DicomNetIpTypeFlags.Ipv6
            Else
                IpType = DicomNetIpTypeFlags.Ipv4OrIpv6
            End If
        End Sub



        Private Sub radioButtonIp_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radioButtonIpv4.CheckedChanged, radioButtonIpv6.CheckedChanged, radioButtonIpv4Ipv6.CheckedChanged
            Dim rb As RadioButton = TryCast(sender, RadioButton)
            If rb IsNot Nothing Then
                If rb.Checked Then
                    UpdateIpType()
                    InitIpList()
                    If _Settings Is Nothing Then
                        ServerIp.Text = "All"
                    Else
                        ServerIp.Text = If(_Settings.IpAddress = "*", "All", _Settings.IpAddress)
                    End If
                End If
            End If

        End Sub
    End Class
End Namespace

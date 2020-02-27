' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Drawing
Imports System.Data
Imports System.Linq
Imports System.Text
Imports System.Windows.Forms
Imports Leadtools.Dicom
Imports System.ServiceProcess
Imports Leadtools.Dicom.Server.Admin
Imports Leadtools.Dicom.AddIn.Common
Imports System.Threading
Imports Leadtools.Medical.Storage.AddIns.Messages

Namespace Leadtools.Demos.StorageServer.UI
   Partial Friend Class GeneralSettingsView : Inherits UserControl
#Region "Public"

#Region "Methods"

      Public Sub New()
         InitializeComponent()

         AddHandler AddServerToolStripButton.Click, AddressOf AddServerToolStripButton_Click
         AddHandler DeleteServerToolStripButton.Click, AddressOf DeleteServerToolStripButton_Click
         AddHandler AeTitleTextBox.Validating, AddressOf AeTitleTextBox_Validating
         AddHandler AeTitleTextBox.TextChanged, AddressOf AeTitleTextBox_TextChanged

         AddHandler IpAddressComboBox.SelectionChangeCommitted, AddressOf OnIpAddressChanged
         AddHandler PortNumericUpDown.ValueChanged, AddressOf OnPortChanged
         AddHandler ImplementationClassTextBox.TextChanged, AddressOf OnImplementationClassUIDChanged
         AddHandler ImplementationVersionTextBox.TextChanged, AddressOf OnImplementationVersionNameChanged
         AddHandler StartModeComboBox.SelectionChangeCommitted, AddressOf OnServiceStartModeChanged

         AddHandler IpV4CheckBox.CheckedChanged, AddressOf OnIpTypeChanged
         AddHandler IpV6CheckBox.CheckedChanged, AddressOf OnIpTypeChanged
         AddHandler IpBothCheckBox.CheckedChanged, AddressOf OnIpTypeChanged

#If LEADTOOLS_V19_OR_LATER Then
         AddHandler TestServiceButton.Click, AddressOf TestServiceButton_Click
#Else
			   TestServiceButton.Visible = False
#End If

         ' IsDirty Handlers
         AddHandler ServiceDisplayNameTextBox.TextChanged, AddressOf ServiceDisplayNameTextBox_TextChanged
         AddHandler ServiceDescriptionTextBox.TextChanged, AddressOf ServiceDescriptionTextBox_TextChanged


      End Sub

      Public Property CanIpV6CheckBox() As Boolean
         Get
            Return IpV6CheckBox.Enabled
         End Get

         Set(ByVal value As Boolean)
            IpV6CheckBox.Enabled = value
         End Set
      End Property

      Public Property CanIpBothCheckBox() As Boolean
         Get
            Return IpBothCheckBox.Enabled
         End Get

         Set(ByVal value As Boolean)
            IpBothCheckBox.Enabled = value
         End Set
      End Property


      Public Sub SetIpAddressList(ByVal ipadresses As String())
         IpAddressComboBox.DataSource = ipadresses
      End Sub

      Private _SelectedIpAddressIndex As Integer
      Public Property SelectedIpAddressIndex() As Integer
         Get
            Return _SelectedIpAddressIndex
         End Get
         Set(ByVal value As Integer)
            _SelectedIpAddressIndex = value
         End Set
      End Property

      Private _SelectedIp As String
      Public Property SelectedIp() As String
         Get
            Return _SelectedIp
         End Get
         Set(ByVal value As String)
            _SelectedIp = value
         End Set
      End Property

      Public Sub SetStartupModeList(ByVal modes As String())
         StartModeComboBox.DataSource = modes
      End Sub

      Public Sub AETitelValidationMessage(ByVal validationMessage As String)
         AETitleErrorProvider.SetError(AeTitleTextBox, validationMessage)
      End Sub

#End Region

#Region "Properties"

      Public Property AeTitle() As String
         Get
            Return AeTitleTextBox.Text
         End Get

         Set(ByVal value As String)
            AeTitleTextBox.Text = value
         End Set
      End Property

      Public Property IpAddress() As String
         Get
            Return TryCast(IpAddressComboBox.SelectedItem, String)
         End Get

         Set(ByVal value As String)
            IpAddressComboBox.SelectedItem = value
         End Set
      End Property


      Public Property Port() As Integer
         Get
            Return CInt(PortNumericUpDown.Value)
         End Get

         Set(ByVal value As Integer)
            PortNumericUpDown.Value = value
         End Set
      End Property

      Public Property ImplementationClassUID() As String
         Get
            Return ImplementationClassTextBox.Text
         End Get

         Set(ByVal value As String)
            ImplementationClassTextBox.Text = value
         End Set
      End Property

      Public Property ImplementationVersion() As String
         Get
            Return ImplementationVersionTextBox.Text
         End Get

         Set(ByVal value As String)
            ImplementationVersionTextBox.Text = value
         End Set
      End Property

      Public Property ServiceDisplayName() As String
         Get
            Return ServiceDisplayNameTextBox.Text
         End Get

         Set(ByVal value As String)
            ServiceDisplayNameTextBox.Text = value
         End Set
      End Property

      Public Property ServiceDecription() As String
         Get
            Return ServiceDescriptionTextBox.Text
         End Get

         Set(ByVal value As String)
            ServiceDescriptionTextBox.Text = value
         End Set
      End Property

      Public Property ServiceStartupMode() As String
         Get
            Return TryCast(StartModeComboBox.SelectedItem, String)
         End Get

         Set(ByVal value As String)
            StartModeComboBox.SelectedItem = value
         End Set
      End Property

      Public Property CanChangeServiceDisplayName() As Boolean
         Get
            Return ServiceDisplayNameTextBox.Enabled
         End Get

         Set(ByVal value As Boolean)
            ServiceDisplayNameTextBox.Enabled = value
         End Set
      End Property

      Public Property CanChangeServiceDescription() As Boolean
         Get
            Return ServiceDescriptionTextBox.Enabled
         End Get

         Set(ByVal value As Boolean)
            ServiceDescriptionTextBox.Enabled = value
         End Set
      End Property

      Public Property CanAddServer() As Boolean
         Get
            Return AddServerToolStripButton.Enabled
         End Get

         Set(ByVal value As Boolean)
            AddServerToolStripButton.Enabled = value
         End Set
      End Property

      Public Property CanDeleteServer() As Boolean
         Get
            Return DeleteServerToolStripButton.Enabled
         End Get

         Set(ByVal value As Boolean)
            DeleteServerToolStripButton.Enabled = value
         End Set
      End Property

      Public Property IpType() As DicomNetIpTypeFlags
         Get
            Dim flags As DicomNetIpTypeFlags = DicomNetIpTypeFlags.Ipv4OrIpv6

            If IpBothCheckBox.Checked Then
               Return flags
            Else
               If (Not IpV4CheckBox.Checked) Then
                  flags = Not DicomNetIpTypeFlags.Ipv4
               End If

               If (Not IpV6CheckBox.Checked) Then
                  flags = Not DicomNetIpTypeFlags.Ipv6
               End If

               Return flags
            End If
         End Get

         Set(ByVal value As DicomNetIpTypeFlags)
            If value = DicomNetIpTypeFlags.Ipv4 Then
               IpV4CheckBox.Checked = True
            ElseIf value = DicomNetIpTypeFlags.Ipv6 Then
               IpV6CheckBox.Checked = True
            Else
               IpBothCheckBox.Checked = True
            End If
         End Set
      End Property

      Public Property CanSelectIpAddress() As Boolean
         Get
            Return IpAddressComboBox.Enabled
         End Get

         Set(ByVal value As Boolean)
            IpAddressComboBox.Enabled = value
         End Set
      End Property

      Public Property CanSelectIpType() As Boolean
         Get
            Return IpTypePanel.Enabled
         End Get

         Set(ByVal value As Boolean)
            IpTypePanel.Enabled = value
         End Set
      End Property

      Public Property CanSelectPort() As Boolean
         Get
            Return PortNumericUpDown.Enabled
         End Get

         Set(ByVal value As Boolean)
            PortNumericUpDown.Enabled = value
         End Set
      End Property

      Sub OnValueChanged(ByVal sender As Object, ByVal e As EventArgs)
         SetIsDirty(sender, e)
      End Sub

      Private _isDirty As Boolean = False

      Private Sub SetIsDirty(ByVal sender As Object, ByVal e As EventArgs)
         IsDirty = True
         OnSettingsChanged(sender, e)
      End Sub

      Public Property IsDirty() As Boolean
         Get
            Return _isDirty
         End Get
         Private Set(ByVal value As Boolean)
            _isDirty = value
         End Set
      End Property

#End Region

#Region "Data Types Definition"

#End Region

#Region "Callbacks"

      Public Event AddServer As EventHandler
      Public Event DeleteServer As EventHandler
      Public Event IpAddressChanged As EventHandler
      Public Event PortChanged As EventHandler
      Public Event ImplementationClassUIDChanged As EventHandler
      Public Event ImplementationVersionNameChanged As EventHandler
      Public Event ServiceStartModeChanged As EventHandler
      Public Event AETitleChanged As EventHandler
      Public Event SettingsChanged As EventHandler
      Public Event IpTypeChanged As EventHandler

#End Region

#End Region

#Region "Protected"

#Region "Methods"

#End Region

#Region "Properties"

#End Region

#Region "Data Types Definition"

#End Region

#End Region

#Region "Private"

#Region "Methods"

#End Region

#Region "Properties"

#End Region

#Region "Events"

      Sub DeleteServerToolStripButton_Click(ByVal sender As Object, ByVal e As EventArgs)
         Try
            Me.ValidateChildren(ValidationConstraints.None)

            If Not Nothing Is DeleteServerEvent Then
               RaiseEvent DeleteServer(Me, EventArgs.Empty)
            End If
         Catch ex As Exception
            Messager.ShowError(Me, ex)
         End Try
      End Sub

      Sub AddServerToolStripButton_Click(ByVal sender As Object, ByVal e As EventArgs)
         Try
            If Me.ValidateChildren(ValidationConstraints.None) Then
               If Not Nothing Is AddServerEvent Then
                  RaiseEvent AddServer(Me, e)
               End If
            End If
         Catch ex As Exception
            Messager.ShowError(Me, ex)
         End Try
      End Sub

#If LEADTOOLS_V19_OR_LATER Then
      Private Sub TestServiceButton_Click(ByVal sender As Object, ByVal e As EventArgs)
         Dim message As String = String.Empty
         Dim errorMessage As String = String.Empty
         Dim result As DicomServiceTesterResult = DicomServiceTester.Test(ServerState.Instance.ServerService, errorMessage)
         Dim serviceName As String = ServerState.Instance.ServerService.ServiceName
         Select Case result
            Case DicomServiceTesterResult.Success
               message = String.Format("{0} Listening Service is valid", serviceName)
            Case DicomServiceTesterResult.ErrorServiceIsNull
               message = String.Format("{0} Listening Service has not been created", serviceName)
            Case DicomServiceTesterResult.ErrorServiceNotRunning
               message = String.Format("{0} Listening Service must be running to verify", serviceName)
            Case DicomServiceTesterResult.ErrorServiceCannotAccessDatabase
               message = String.Format("{0} Listening Service cannot access database. {1}", serviceName, errorMessage)
            Case DicomServiceTesterResult.ErrorServiceNotResponding
               message = String.Format("Unable to communicate with {0} Listening Service", serviceName)
         End Select

         Messager.Caption = "Test DICOM Server"
         If result = DicomServiceTesterResult.Success Then
            Messager.ShowInformation(Me, message)
         Else
            Messager.ShowWarning(Me, message)
         End If
      End Sub
#End If ' #if LEADTOOLS_V19_OR_LATER

      Sub AeTitleTextBox_Validating(ByVal sender As Object, ByVal e As CancelEventArgs)
         Try
            AETitleErrorProvider.SetError(AeTitleTextBox, String.Empty)

            If Not Nothing Is AETitleChangedEvent Then
               RaiseEvent AETitleChanged(Me, e)
            End If

            e.Cancel = AETitleErrorProvider.GetError(AeTitleTextBox) <> String.Empty
         Catch ex As Exception
            Messager.ShowError(Me, ex)
         End Try
      End Sub

      Sub AeTitleTextBox_TextChanged(ByVal sender As Object, ByVal e As EventArgs)
         SetIsDirty(sender, e)
      End Sub

      Sub OnSettingsChanged(ByVal sender As Object, ByVal e As EventArgs)
         Try
            If Not Nothing Is SettingsChangedEvent Then
               RaiseEvent SettingsChanged(Me, e)
            End If
         Catch ex As Exception
            Messager.ShowError(Me, ex)
         End Try
      End Sub

      Private Sub OnIpAddressChanged(ByVal sender As Object, ByVal e As EventArgs)
         If Not Nothing Is IpAddressChangedEvent Then
            RaiseEvent IpAddressChanged(Me, e)
            OnSettingsChanged(sender, e)
         End If
      End Sub

      Private Sub OnPortChanged(ByVal sender As Object, ByVal e As EventArgs)
         If Not PortChangedEvent Is Nothing Then
            RaiseEvent PortChanged(Me, e)
            SetIsDirty(sender, e)
         End If
      End Sub

      Private Sub OnImplementationClassUIDChanged(ByVal sender As Object, ByVal e As EventArgs)
         If Not Nothing Is ImplementationClassUIDChangedEvent Then
            RaiseEvent ImplementationClassUIDChanged(Me, e)
            SetIsDirty(Me, e)
         End If
      End Sub

      Private Sub OnImplementationVersionNameChanged(ByVal sender As Object, ByVal e As EventArgs)
         If Not Nothing Is ImplementationVersionNameChangedEvent Then
            RaiseEvent ImplementationVersionNameChanged(Me, e)
            SetIsDirty(Me, e)
         End If
      End Sub

      Private Sub OnServiceStartModeChanged(ByVal sender As Object, ByVal e As EventArgs)
         If Not Nothing Is ServiceStartModeChangedEvent Then
            RaiseEvent ServiceStartModeChanged(Me, e)
            SetIsDirty(Me, e)
         End If
      End Sub

      Private Sub OnIpTypeChanged(ByVal sender As Object, ByVal e As EventArgs)
         Dim rb As RadioButton = TryCast(sender, RadioButton)
         If (Not Nothing Is IpTypeChangedEvent) AndAlso (rb.Checked) Then
            RaiseEvent IpTypeChanged(Me, e)
            SetIsDirty(sender, e)
         End If
      End Sub

      Private Sub ServiceDescriptionTextBox_TextChanged(ByVal sender As Object, ByVal e As EventArgs)
         SetIsDirty(sender, e)
      End Sub

      Private Sub ServiceDisplayNameTextBox_TextChanged(ByVal sender As Object, ByVal e As EventArgs)
         SetIsDirty(sender, e)
      End Sub

#End Region

#Region "Data Members"

#End Region

#Region "Data Types Definition"

#End Region

#End Region

#Region "internal"

#Region "Methods"

#End Region

#Region "Properties"

#End Region

#Region "Data Types Definition"

#End Region

#Region "Callbacks"

#End Region

#End Region

   End Class
End Namespace

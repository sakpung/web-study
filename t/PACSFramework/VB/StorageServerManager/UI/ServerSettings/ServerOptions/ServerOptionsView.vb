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
Imports Leadtools.Dicom.AddIn.Common
Imports Leadtools.Medical.Winforms
Imports Leadtools.Demos.StorageServer.DataTypes
Imports Leadtools.Dicom.AddIn.Interfaces
Imports Leadtools.DicomDemos

Namespace Leadtools.Demos.StorageServer.UI
    Partial Public Class ServerOptionsView : Inherits UserControl
#Region "Public"

#Region "Methods"

        Public Sub New()
            InitializeComponent()

            AddHandler AllowAnonCheckBox.CheckedChanged, AddressOf OnSettingsChanged
            AddHandler AllowAnonymousCMoveCheckBox.CheckedChanged, AddressOf OnSettingsChanged
            AddHandler AnonymousClientPortNumericUpDown.ValueChanged, AddressOf OnSettingsChanged
            AddHandler AllowMultipleCheckBox.CheckedChanged, AddressOf OnSettingsChanged

            AddHandler UseTlsSecurityCheckBox.CheckedChanged, AddressOf UseTlsSecurityCheckBox_CheckedChanged

            AddHandler MaxClientsNumericUpDown.ValueChanged, AddressOf OnSettingsChanged
            AddHandler ClientTimeoutNumericUpDown.ValueChanged, AddressOf OnSettingsChanged
            AddHandler AddinsTimeoutNumericUpDown.ValueChanged, AddressOf OnSettingsChanged
            AddHandler ReconnectTimeoutNumericUpDown.ValueChanged, AddressOf OnSettingsChanged
            AddHandler TempFolderTextBox.TextChanged, AddressOf OnSettingsChanged

            AddHandler rbRelationalQueriesNever.CheckedChanged, AddressOf OnSettingsChanged
            AddHandler rbRelationalQueriesNegotiate.CheckedChanged, AddressOf OnSettingsChanged
            AddHandler rbRelationalQueriesAlways.CheckedChanged, AddressOf OnSettingsChanged

            AddHandler checkBoxEnableDefaultRoleSelection.CheckedChanged, AddressOf OnSettingsChanged
            AddHandler radioButtonProviderRoleAccept.CheckedChanged, AddressOf OnSettingsChanged
            AddHandler radioButtonUserRoleAccept.CheckedChanged, AddressOf OnSettingsChanged

            AddHandler BrowseTempButton.Click, AddressOf BrowseTempButton_Click
        End Sub

        Dim ignoreCheckChanged As Boolean = False

        Private Sub UseTlsSecurityCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs)
            If UseTlsSecurityCheckBox.Checked Then
                If Utils.VerifyOpensslVersion(Me.ParentForm) = False Then
                    ignoreCheckChanged = True
                    UseTlsSecurityCheckBox.Checked = False
                    Return
                End If
            End If

            If ignoreCheckChanged = False Then
                EventBroker.Instance.PublishEvent(Of ServerSettingsSecureChangedEventArgs)(Me, New ServerSettingsSecureChangedEventArgs(UseTlsSecurityCheckBox.Checked))
                OnSettingsChanged(sender, e)
            End If
            ignoreCheckChanged = False
        End Sub

        Private Sub BrowseTempButton_Click(ByVal sender As Object, ByVal e As EventArgs)
            Using browseFolderDlg As FolderBrowserDialog = New FolderBrowserDialog()
                browseFolderDlg.SelectedPath = TempFolderTextBox.Text

                If browseFolderDlg.ShowDialog(Me) = DialogResult.OK Then
                    TempFolderTextBox.Text = browseFolderDlg.SelectedPath
                End If
            End Using
        End Sub

#End Region

#Region "Properties"

        Public Property AllowAnonymousConnections() As Boolean
            Get
                Return AllowAnonCheckBox.Checked
            End Get

            Set(ByVal value As Boolean)
                AllowAnonCheckBox.Checked = value
            End Set
        End Property

        Public Property AllowAnonymousCMove() As Boolean
            Get
                Return AllowAnonymousCMoveCheckBox.Checked
            End Get

            Set(ByVal value As Boolean)
                AllowAnonymousCMoveCheckBox.Checked = value
            End Set
        End Property

        Public Property AnonymousClientPort() As Integer
            Get
                Return CInt(AnonymousClientPortNumericUpDown.Value)
            End Get

            Set(ByVal value As Integer)
                AnonymousClientPortNumericUpDown.Value = value
            End Set
        End Property

        Public Property AllowClientMultipleConnections() As Boolean
            Get
                Return AllowMultipleCheckBox.Checked
            End Get

            Set(ByVal value As Boolean)
                AllowMultipleCheckBox.Checked = value
            End Set
        End Property

        Public Property UseTlsSecurity() As Boolean
            Get
                Return UseTlsSecurityCheckBox.Checked
            End Get
            Set(ByVal value As Boolean)
                UseTlsSecurityCheckBox.Checked = value
            End Set
        End Property

        Public Property MaxClients() As Integer
            Get
                Return CInt(MaxClientsNumericUpDown.Value)
            End Get

            Set(ByVal value As Integer)
                MaxClientsNumericUpDown.Value = value
            End Set
        End Property

        Public Property MaxClientsMaxValue() As Integer
            Get
                Return Convert.ToInt32(MaxClientsNumericUpDown.Maximum)
            End Get
            Set(ByVal value As Integer)
                MaxClientsNumericUpDown.Maximum = value
            End Set
        End Property

        Public Property ClientIdleTimeout() As Integer
            Get
                Return CInt(ClientTimeoutNumericUpDown.Value)
            End Get

            Set(ByVal value As Integer)
                ClientTimeoutNumericUpDown.Value = value
            End Set
        End Property

        Public Property MessageProcessingTimeout() As Integer
            Get
                Return CInt(AddinsTimeoutNumericUpDown.Value)
            End Get

            Set(ByVal value As Integer)
                AddinsTimeoutNumericUpDown.Value = value
            End Set
        End Property

        Public Property StoreSubOperationsTimeout() As Integer
            Get
                Return CInt(ReconnectTimeoutNumericUpDown.Value)
            End Get

            Set(ByVal value As Integer)
                ReconnectTimeoutNumericUpDown.Value = value
            End Set
        End Property

        Public Property TempDirectory() As String
            Get
                Return TempFolderTextBox.Text
            End Get

            Set(ByVal value As String)
                TempFolderTextBox.Text = value
            End Set
        End Property

        Public Property RelationalQueries() As RelationalQuerySupportEnum
            Get
                If Me.rbRelationalQueriesNever.Checked Then
                    Return RelationalQuerySupportEnum.Never
                ElseIf rbRelationalQueriesNegotiate.Checked Then
                    Return RelationalQuerySupportEnum.Negotiation
                End If
                Return RelationalQuerySupportEnum.Always
            End Get

            Set(ByVal value As RelationalQuerySupportEnum)
                Select Case value
                    Case RelationalQuerySupportEnum.Never
                        rbRelationalQueriesNever.Checked = True
                    Case RelationalQuerySupportEnum.Negotiation
                        rbRelationalQueriesNegotiate.Checked = True
                    Case RelationalQuerySupportEnum.Always
                        rbRelationalQueriesAlways.Checked = True
                End Select
            End Set
        End Property

        Public Property RoleSelectionOptions() As RoleSelectionFlags
            Get
                Dim roleSelectionFlags As RoleSelectionFlags = RoleSelectionFlags.None
                If Me.checkBoxEnableDefaultRoleSelection.Checked Then
                    roleSelectionFlags = roleSelectionFlags Or RoleSelectionFlags.Enabled
                    If Me.radioButtonUserRoleAccept.Checked Then
                        roleSelectionFlags = roleSelectionFlags Or RoleSelectionFlags.AcceptUserRoleProposed
                    End If

                    If Me.radioButtonProviderRoleAccept.Checked Then
                        roleSelectionFlags = roleSelectionFlags Or RoleSelectionFlags.AcceptProviderRoleProposed
                    End If
                Else
                    roleSelectionFlags = roleSelectionFlags Or RoleSelectionFlags.Disabled
                End If
                Return roleSelectionFlags
            End Get
            Set(ByVal value As RoleSelectionFlags)
                checkBoxEnableDefaultRoleSelection.Checked = (Leadtools.DicomDemos.Extensions.IsFlagged(value, RoleSelectionFlags.Enabled))
                radioButtonUserRoleAccept.Checked = Leadtools.DicomDemos.Extensions.IsFlagged(value, RoleSelectionFlags.AcceptUserRoleProposed)
                radioButtonUserRoleTurnDown.Checked = Not radioButtonUserRoleAccept.Checked

                radioButtonProviderRoleAccept.Checked = Leadtools.DicomDemos.Extensions.IsFlagged(value, RoleSelectionFlags.AcceptProviderRoleProposed)
                radioButtonProviderRoleTurnDown.Checked = Not radioButtonProviderRoleAccept.Checked
            End Set
        End Property

#End Region

#Region "Data Types Definition"

#End Region

#Region "Callbacks"

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

        Public Event SettingsChanged As EventHandler

#End Region

#Region "Data Members"

#End Region

#Region "Data Types Definition"

        Private Sub EnableRoleSelectItems(ByVal enable As Boolean)
            groupBoxUserRole.Enabled = enable
            groupBoxProviderRole.Enabled = enable
        End Sub

        Private Sub EnableRoleSelectItems()
            EnableRoleSelectItems(checkBoxEnableDefaultRoleSelection.Checked)
        End Sub

        Private Sub UpdateUI()
            Dim allowAnonymousCMoveEnabled As Boolean = False
            Dim anonymousClientPortEnabled As Boolean = False

#If (LEADTOOLS_V19_OR_LATER) Then
            allowAnonymousCMoveEnabled = AllowAnonCheckBox.Checked
            anonymousClientPortEnabled = allowAnonymousCMoveEnabled AndAlso AllowAnonymousCMoveCheckBox.Checked
#End If ' #if (LEADTOOLS_V19_OR_LATER)

            AllowAnonymousCMoveCheckBox.Enabled = allowAnonymousCMoveEnabled
            AnonymousClientPortLabel.Enabled = anonymousClientPortEnabled
            AnonymousClientPortNumericUpDown.Enabled = anonymousClientPortEnabled

            EnableRoleSelectItems()
        End Sub

        Private Sub OnSettingsChanged(ByVal sender As Object, ByVal e As EventArgs)
            UpdateUI()
            Try
                If Not Nothing Is SettingsChangedEvent Then
                    RaiseEvent SettingsChanged(Me, e)
                End If
            Catch ex As Exception
                Messager.ShowError(Me, ex)
            End Try
        End Sub

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

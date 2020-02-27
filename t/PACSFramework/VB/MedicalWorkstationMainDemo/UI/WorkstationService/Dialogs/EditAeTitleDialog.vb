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
Imports System.Text.RegularExpressions
Imports Leadtools.Dicom.AddIn.Common
Imports Leadtools.Dicom
Imports Leadtools.DicomDemos


Namespace Leadtools.Demos.Workstation
    Partial Public Class EditAeTitleDialog
        Inherits Form

        Private _serverSecure As Boolean
        Public Property ServerSecure() As Boolean
            Get
                Return _serverSecure
            End Get
            Set(ByVal value As Boolean)
                _serverSecure = value
            End Set
        End Property

        Private _AeInfo As AeInfo = Nothing

        Public Property AeInfo() As AeInfo
            Get
                Return _AeInfo
            End Get

            Set(ByVal value As AeInfo)
                _AeInfo = value
            End Set
        End Property

        Public Sub New()
            InitializeComponent()

            Icon = WorkstationUtils.GetApplicationIcon()

            AddHandler AETitleTextBox.Validating, AddressOf AETitle_Validating
        End Sub

        Private Sub AETitle_Validating(ByVal sender As Object, ByVal e As CancelEventArgs)
            If AETitleTextBox.Text.Length = 0 Then
                AeErrorProvider.SetError(AETitleTextBox, "AE Title can't be empty.")

                e.Cancel = True
            ElseIf AETitleTextBox.Text.Length > 16 Then
                AeErrorProvider.SetError(AETitleTextBox, "AE Title must be less than 16 characters.")

                e.Cancel = True
            Else
                AeErrorProvider.SetError(AETitleTextBox, String.Empty)
            End If
        End Sub

        Private Sub EditAeTitleDialog_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
            comboBoxClientPortSelection.Items.Add(ClientPortUsageType.Unsecure)
            comboBoxClientPortSelection.Items.Add(ClientPortUsageType.Secure)
            comboBoxClientPortSelection.Items.Add(ClientPortUsageType.SameAsServer)

            If _AeInfo Is Nothing Then
                Text = "Add AE Title"
                comboBoxClientPortSelection.SelectedItem = ClientPortUsageType.Unsecure
            Else
                Text = "Edit AE Title"
                AETitleTextBox.Text = _AeInfo.AETitle
                HostNameTextBox.Text = _AeInfo.Address

                PortNumericUpDown.Value = Convert.ToDecimal(_AeInfo.Port)
                SecurePortNumericUpDown.Value = Convert.ToDecimal(_AeInfo.SecurePort)
                comboBoxClientPortSelection.SelectedItem = _AeInfo.ClientPortUsage
            End If

            AddHandler comboBoxClientPortSelection.SelectedIndexChanged, AddressOf ComboBoxClientPortSelection_SelectedIndexChanged

            UpdateClientPortIcons()
            AETitle_TextChanged(Nothing, EventArgs.Empty)
        End Sub

        Private Sub UpdateClientPortIcons()
            If TypeOf comboBoxClientPortSelection.SelectedItem Is ClientPortUsageType Then
                Dim portUsage As ClientPortUsageType = CType(comboBoxClientPortSelection.SelectedItem, ClientPortUsageType)
                Select Case portUsage
                    Case ClientPortUsageType.Unsecure
                        pictureBoxUnsecurePort.Visible = True
                        pictureBoxSecurePort.Visible = False
                    Case ClientPortUsageType.Secure
                        pictureBoxUnsecurePort.Visible = False
                        pictureBoxSecurePort.Visible = True
                    Case ClientPortUsageType.SameAsServer
                        pictureBoxUnsecurePort.Visible = Not Me.ServerSecure
                        pictureBoxSecurePort.Visible = Me.ServerSecure
                End Select
            End If
        End Sub

        Private Sub ComboBoxClientPortSelection_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
            Dim portUsage As ClientPortUsageType = CType(comboBoxClientPortSelection.SelectedItem, ClientPortUsageType)
            If portUsage = ClientPortUsageType.Secure OrElse portUsage = ClientPortUsageType.SameAsServer Then
                If Utils.VerifyOpensslVersion(Me) = False Then
                    comboBoxClientPortSelection.SelectedIndex = 0
                    Return
                End If
            End If
            UpdateClientPortIcons()
        End Sub

        Private Sub EditAeTitleDialog_FormClosing(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles MyBase.FormClosing
            If DialogResult = System.Windows.Forms.DialogResult.OK Then
                If _AeInfo Is Nothing Then
                    _AeInfo = New AeInfo()
                End If

                _AeInfo.AETitle = AETitleTextBox.Text
                _AeInfo.Address = HostNameTextBox.Text
                _AeInfo.Port = Convert.ToInt32(PortNumericUpDown.Value)
                _AeInfo.SecurePort = Convert.ToInt32(SecurePortNumericUpDown.Value)
                If TypeOf comboBoxClientPortSelection.SelectedItem Is ClientPortUsageType Then
                    Dim clientPortUsage As ClientPortUsageType = CType(comboBoxClientPortSelection.SelectedItem, ClientPortUsageType)

                    If clientPortUsage <> ClientPortUsageType.None Then
                        _AeInfo.ClientPortUsage = clientPortUsage
                    End If
                End If
            End If
        End Sub


        Private Sub AETitle_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles AETitleTextBox.TextChanged
            OkButton.Enabled = AETitleTextBox.Text <> String.Empty
        End Sub
    End Class
End Namespace

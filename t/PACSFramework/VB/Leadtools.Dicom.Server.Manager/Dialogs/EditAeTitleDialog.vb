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
Imports System.Text.RegularExpressions
Imports Leadtools.Dicom.AddIn.Common
Imports System.Net

Namespace Leadtools.Dicom.Server.Manager.Dialogs
    Partial Public Class EditAeTitleDialog
        Inherits Form
        Private _AeInfo As AeInfo = Nothing

        Public ReadOnly Property AeInfo() As AeInfo
            Get
                Return _AeInfo
            End Get
        End Property

        Public Sub New(ByVal info As AeInfo)
            InitializeComponent()
            _AeInfo = info
            If _AeInfo Is Nothing Then
                Text = My.Resources.AddAeTitle
            Else
                Text = My.Resources.EditAeTitle
            End If

            InitializeStrings()
            Icon = My.Resources.ApplicationIcon
        End Sub

        Private Sub InitializeStrings()
            labelAeTitle.Text = My.Resources.AeTitleLabel & ":"
            radioButtonHost.Text = My.Resources.HostnameLabel
            radioButtonIp.Text = My.Resources.IPAddressLabel
            labelPort.Text = My.Resources.PortLabel & ":"
            labelSecurePort.Text = My.Resources.SecurePortColumnLabel & ":"

            buttonOk.Text = My.Resources.OkText
            buttonCancel.Text = My.Resources.CancelText
        End Sub

        Private Sub EditAeTitleDialog_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
            If _AeInfo Is Nothing Then
                radioButtonHost.Checked = False
                Hostname.Enabled = False
                radioButtonIp.Checked = True
            Else
                Dim ip As System.Net.IPAddress = System.Net.IPAddress.None

                AETitle.Text = _AeInfo.AETitle
                If (Not System.Net.IPAddress.TryParse(_AeInfo.Address, ip)) Then
                    radioButtonIp.Checked = False
                    radioButtonHost.Checked = True
                    textboxIPAddress.Enabled = False
                    Hostname.Text = _AeInfo.Address
                Else
                    radioButtonHost.Checked = False
                    radioButtonIp.Checked = True
                    Hostname.Enabled = False
                    textboxIPAddress.Text = _AeInfo.Address
                End If

                Port.Value = Convert.ToDecimal(_AeInfo.Port)
                SecurePort.Value = Convert.ToDecimal(_AeInfo.SecurePort)
            End If
            AETitle_TextChanged(Nothing, EventArgs.Empty)
            buttonOk.Enabled = IsValidData()
        End Sub

        Private Function IsAlphaNumeric(ByVal check As String) As Boolean
            Dim objAlphaNumericPattern As New Regex("[^a-zA-Z0-9]")

            Return Not objAlphaNumericPattern.IsMatch(check)
        End Function

        Private Sub EditAeTitleDialog_FormClosing(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles MyBase.FormClosing
            If DialogResult = System.Windows.Forms.DialogResult.OK Then
                If _AeInfo Is Nothing Then
                    _AeInfo = New AeInfo()
                End If

                _AeInfo.AETitle = AETitle.Text
                If radioButtonHost.Checked Then
                    _AeInfo.Address = Hostname.Text
                Else
                    _AeInfo.Address = textboxIPAddress.Text
                End If
                _AeInfo.Port = Convert.ToInt32(Port.Value)
                _AeInfo.SecurePort = Convert.ToInt32(SecurePort.Value)
            End If
        End Sub

        Private Sub radioButtonHost_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles radioButtonHost.CheckedChanged
            radioButtonIp.Checked = Not radioButtonHost.Checked
            Hostname.Enabled = radioButtonHost.Checked
            buttonOk.Enabled = IsValidData()
        End Sub

        Private Sub radioButtonIp_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles radioButtonIp.CheckedChanged
            radioButtonHost.Checked = Not radioButtonIp.Checked
            textboxIPAddress.Enabled = radioButtonIp.Checked
            buttonOk.Enabled = IsValidData()
        End Sub

        Private Function IsHex(ByVal c As Char) As Boolean
            Return Char.IsLetterOrDigit(c) AndAlso Char.ToLower(c) <= "f"c
        End Function

        Private Sub IPAddress_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles textboxIPAddress.KeyPress
            Dim bValid As Boolean = IsHex(e.KeyChar) OrElse (e.KeyChar = "."c) OrElse (e.KeyChar = ":"c) OrElse Char.IsControl(e.KeyChar)
            e.Handled = Not bValid
        End Sub

        Private Function IsValidData() As Boolean
            Dim bValid As Boolean = False
            bValid = AETitle.Text.Trim() <> String.Empty
            If bValid Then
                If radioButtonHost.Checked Then
                    bValid = (Hostname.Text.Trim() <> String.Empty)
                End If
            End If
            If bValid Then
                If radioButtonIp.Checked Then
               Dim address As IPAddress = IPAddress.None
                    bValid = IPAddress.TryParse(textboxIPAddress.Text, address)
                End If
            End If
            Return bValid
        End Function

        Private Sub AETitle_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AETitle.TextChanged
            buttonOk.Enabled = IsValidData()
        End Sub

        Private Sub Hostname_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Hostname.TextChanged
            buttonOk.Enabled = IsValidData()
        End Sub

        Private Sub IPAddress_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles textboxIPAddress.TextChanged
            buttonOk.Enabled = IsValidData()
        End Sub
    End Class
End Namespace

' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Linq
Imports System.Text
Imports System.Windows.Forms
Imports System.IO
Imports System.Net
Imports System.Text.RegularExpressions
Imports System.Runtime.InteropServices
Imports Microsoft.WindowsAPICodePack.Dialogs
Imports Leadtools.Dicom.Scu
Imports DicomDemo.DicomDemo.Dicom
Imports DicomDemo.DicomDemo.Utils

Namespace DicomDemo
   Partial Class OptionsDialog : Inherits Form
      Private _ServerAE As String

      Public Property ServerAE() As String
         Get
            Return _ServerAE
         End Get
         Set(ByVal value As String)
            _ServerAE = value
         End Set
      End Property

      Private _ServerIP As String

      Public Property ServerIP() As String
         Get
            Return _ServerIP
         End Get
         Set(ByVal value As String)
            _ServerIP = value
         End Set
      End Property

      Private _ServerPort As Integer

      Public Property ServerPort() As Integer
         Get
            Return _ServerPort
         End Get
         Set(ByVal value As Integer)
            _ServerPort = value
         End Set
      End Property

      Private _ClientAE As String

      Public Property ClientAE() As String
         Get
            Return _ClientAE
         End Get
         Set(ByVal value As String)
            _ClientAE = value
         End Set
      End Property

      Private _Timeout As Integer

      Public Property Timeout() As Integer
         Get
            Return _Timeout
         End Get
         Set(ByVal value As Integer)
            _Timeout = value
         End Set
      End Property

      Public Sub New()
         InitializeComponent()
      End Sub

      Private Function CheckInteger(ByVal tb As TextBox, ByVal lb As Label, ByVal showError As Boolean) As Boolean
         Try
            Convert.ToInt32(tb.Text)
            Return True
         Catch e1 As Exception
            If showError Then
               If tb.Text.Trim() = String.Empty Then
                  MessageBox.Show("Invalid " & lb.Text, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
               End If
               tb.SelectAll()
               tb.Focus()
               DialogResult = DialogResult.None
            End If
            Return False
         End Try
      End Function

      Private Function CheckIP(ByVal tb As TextBox, ByVal lb As Label, ByVal showError As Boolean) As Boolean
         Try
            System.Net.IPAddress.Parse(tb.Text)
            Return True
         Catch e1 As Exception
            If showError Then
               If tb.Text.Trim() = String.Empty Then
                  MessageBox.Show("Invalid " & lb.Text, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
               End If
               tb.SelectAll()
               tb.Focus()
               DialogResult = DialogResult.None
            End If
            Return False
         End Try
      End Function

      Public Function IsValidIP(ByVal addr As String) As Boolean
         'create our match pattern
         Dim pattern As String = "^([1-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5])(\.([0-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5])){3}$"
         'create our Regular Expression object
         Dim check As Regex = New Regex(pattern)

         'boolean variable to hold the status
         Dim valid As Boolean = False
         'check to make sure an ip address was provided
         If addr = "" Then
            'no address provided so return false
            valid = False
         Else
            'address provided so use the IsMatch Method
            'of the Regular Expression object
            valid = check.IsMatch(addr, 0)
         End If
         'return the results
         Return valid
      End Function

      Private Sub OptionsDialog_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
         _textBoxServerAE.Text = ServerAE
         _textBoxServerIP.Text = ServerIP
         _textBoxServerPort.Text = ServerPort.ToString()
         _textBoxClientAE.Text = ClientAE
         _textBoxTimeout.Text = Timeout.ToString()

         AddHandler Application.Idle, AddressOf Application_Idle
      End Sub

      Private Sub Application_Idle(ByVal sender As Object, ByVal e As EventArgs)
         If String.IsNullOrEmpty(_textBoxServerIP.Text) OrElse String.IsNullOrEmpty(_textBoxServerAE.Text) OrElse String.IsNullOrEmpty(_textBoxServerPort.Text) Then
            VerifyButton.Enabled = False
         Else
            VerifyButton.Enabled = IsValidIP(_textBoxServerIP.Text) AndAlso CheckInteger(_textBoxServerPort, Nothing, False)
         End If
      End Sub

      Private Sub _textBoxServerIP_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles _textBoxServerIP.KeyPress
         Dim bValid As Boolean = Char.IsNumber(e.KeyChar) OrElse (e.KeyChar = "."c) OrElse Char.IsControl(e.KeyChar)

         e.Handled = Not bValid
      End Sub

      Private Sub _textBoxServerPort_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles _textBoxServerPort.KeyPress
         If Not (Char.IsDigit(e.KeyChar) OrElse Char.IsControl(e.KeyChar)) Then
            e.Handled = True
         End If
      End Sub

      Private Sub VerifyButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles VerifyButton.Click
         Dim scp As DicomScp = New DicomScp()
         Dim scu As PatientUpdaterConnection = New PatientUpdaterConnection()

         scp.AETitle = _textBoxServerAE.Text
         scp.PeerAddress = IPAddress.Parse(_textBoxServerIP.Text)
         scp.Port = Convert.ToInt32(_textBoxServerPort.Text)
         scu.AETitle = _textBoxClientAE.Text
         Try
            Dim ret As Boolean = scu.Verify(scp)
            Dim scpInfo As String = scp.PeerAddress.ToString() & " (" & scp.Port.ToString() & ")"

            If (Not scu.Rejected) Then
               If ret Then
                  TaskDialogHelper.ShowMessageBox(Me, "Successfull Verification", "Verified " & scp.AETitle, String.Empty, scpInfo, TaskDialogStandardButtons.Ok, TaskDialogStandardIcon.Information, Nothing)
               Else
                  TaskDialogHelper.ShowMessageBox(Me, "Failed Verification", "Unable to verify " & scp.AETitle, String.Empty, scpInfo, TaskDialogStandardButtons.Ok, TaskDialogStandardIcon.Error, Nothing)
               End If
            Else
               TaskDialogHelper.ShowMessageBox(Me, "Failed Verification", "Unable to verify " & scp.AETitle, scu.Reason, scpInfo, TaskDialogStandardButtons.Ok, TaskDialogStandardIcon.Error, Nothing)
            End If
         Catch ex As Exception
            ApplicationUtils.ShowException(Me, ex)
         End Try
      End Sub

      Private Sub OptionsDialog_FormClosing(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles Me.FormClosing
         If (Not CheckIP(_textBoxServerIP, _labelServerIP, True)) Then
            e.Cancel = True
            Return
         End If

         If (Not CheckInteger(_textBoxServerPort, _labelServerPort, True)) Then
            e.Cancel = True
            Return
         End If

         If (Not CheckInteger(_textBoxTimeout, _labelTimeout, True)) Then
            e.Cancel = True
            Return
         End If

         ServerAE = _textBoxServerAE.Text
         ServerIP = _textBoxServerIP.Text
         ServerPort = Convert.ToInt32(_textBoxServerPort.Text)
         ClientAE = _textBoxClientAE.Text
         Timeout = Convert.ToInt32(_textBoxTimeout.Text)
      End Sub
   End Class
End Namespace

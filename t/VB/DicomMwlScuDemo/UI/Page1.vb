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
Imports System.Net
Imports System.Text
Imports System.Windows.Forms

Imports Leadtools.Dicom
Imports Leadtools.DicomDemos
Imports Leadtools.DicomDemos.Scu.CEcho

Namespace DicomDemo
   Partial Public Class Page1 : Inherits UserControl
      Private _globals As Globals
      Private _cecho As CEcho

      Private Const CONFIGURATION_IMPLEMENTATIONCLASS As String = "1.2.840.114257.1123456"
      Private Const CONFIGURATION_IMPLEMENTATIONVERSIONNAME As String = "1"
      Private Const CONFIGURATION_PROTOCOLVERSION As String = "1"

      Public Sub New(ByRef pGlobals As Globals)
         InitializeComponent()

         ' Set up globals
         _globals = pGlobals

         _globals.m_bMWLServerValid = False

      End Sub

      '
      '* Disables the next button since server settings were changed and we don't know if the
      '*   client/server information is valid.
      '
      Private Sub settingsChanged()
         _globals.m_bMWLServerValid = False
         CType(ParentForm, MainForm).btnNext.Enabled = _globals.m_bMWLServerValid
      End Sub

      '
      '* Sends a CEcho request to the server to verify that the client/server info is valid
      '
      Private Sub btnVerify_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnVerify.Click
         Try
            txtLog.Text = ""

            ' update changed settings
            _globals.m_MWLServer.AETitle = txtServerAE.Text
            _globals.m_MWLServer.Address = IPAddress.Parse(txtServerIP.Text)
            _globals.m_MWLServer.Port = Convert.ToInt32(txtServerPort.Text)
            _globals.m_strMWLClientAE = txtClientAE.Text

            ' Send a CEcho to check the settings
            EnableControls(False)
            Dim cecho As New CEcho()

            cecho.ImplementationClass = CONFIGURATION_IMPLEMENTATIONCLASS
            cecho.ImplementationVersionName = CONFIGURATION_IMPLEMENTATIONVERSIONNAME
            cecho.ProtocolVersion = CONFIGURATION_PROTOCOLVERSION
            AddHandler cecho.Status, AddressOf cecho_Status
            _cecho = cecho
            cecho.Echo(_globals.m_MWLServer, _globals.m_strMWLClientAE)
         Catch ex As FormatException
            If ex.Message = "An invalid IP address was specified." Then
               MessageBox.Show("The specified IP address is invalid.")
            Else
               MessageBox.Show("Error:" & Constants.vbCrLf & ex.ToString())
            End If
         Catch ex As Exception
            MessageBox.Show("Error:" & Constants.vbCrLf & ex.ToString())
         End Try
      End Sub

      Private Sub Page1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
         Try
            ' Initialize text boxes
            txtServerAE.Text = _globals.m_MWLServer.AETitle
            txtServerIP.Text = _globals.m_MWLServer.Address.ToString()
            txtServerPort.Text = _globals.m_MWLServer.Port.ToString()
            txtClientAE.Text = _globals.m_strMWLClientAE
         Catch ex As Exception
            MessageBox.Show(ex.ToString())
         End Try
      End Sub

      Private Sub txtServerAE_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtServerAE.TextChanged
         settingsChanged()
      End Sub

      Private Sub txtServerIP_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtServerIP.TextChanged
         settingsChanged()
      End Sub

      Private Sub txtServerPort_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtServerPort.TextChanged
         settingsChanged()
      End Sub

      Private Sub txtClientAE_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtClientAE.TextChanged
         settingsChanged()
      End Sub

      '
      '* Provides feedback regarding the CEcho request
      '
      Private Sub cecho_Status(ByVal sender As Object, ByVal e As StatusEventArgs)
         Try
            Dim message As String = ""
            Dim done As Boolean = False

            If e.Type = StatusType.Error Then
               message = "DICOM error. The process will be terminated! -- Error code is: " & e.Error.ToString()
            Else
               Select Case e.Type
                  Case StatusType.ConnectFailed
                     message = "Connect operation failed." & Constants.vbCrLf
                     message &= Constants.vbTab & "Error: " & e.Error.ToString()
                     done = True
                  Case StatusType.ConnectSucceeded
                     message = "Connected successfully." & Constants.vbCrLf
                     message &= Constants.vbTab & "Peer Address:" & Constants.vbTab + e.PeerIP.ToString() & Constants.vbCrLf
                     message &= Constants.vbTab & "Peer Port:" & Constants.vbTab + Constants.vbTab + e.PeerPort.ToString()
                  Case StatusType.SendAssociateRequest
                     message = "Sending association request..."
                  Case StatusType.ReceiveAssociateAccept
                     message = "Received Associate Accept." & Constants.vbCrLf
                     message &= Constants.vbTab & "Calling AE:" & Constants.vbTab + e.CallingAE & Constants.vbCrLf
                     message &= Constants.vbTab & "Called AE:" & Constants.vbTab + e.CalledAE
                  Case StatusType.ReceiveAssociateReject
                     message = "Received Associate Reject! " & Constants.vbCrLf
                     message &= Constants.vbTab & "Result: " & e.Result.ToString() & Constants.vbCrLf
                     message &= Constants.vbTab & "Reason: " & e.Reason.ToString() & Constants.vbCrLf
                     message &= Constants.vbTab & "Source: " & e.Source.ToString()
                  Case StatusType.AbstractSyntaxNotSupported
                     message = "Abstract Syntax NOT supported!"
                  Case StatusType.ConnectionClosed
                     message = "Network Connection closed!"
                     done = True
                  Case StatusType.ProcessTerminated
                     message = "Process has been terminated!"
                     done = True
                  Case StatusType.SendCEchoRequest
                     message = "Sending CEcho request..."
                  Case StatusType.ReceiveCEchoResponse
                     message = "Received CEcho response." & Constants.vbCrLf
                     message &= Constants.vbTab & "Presentation ID: " & e.PresentationID.ToString() & Constants.vbCrLf
                     message &= Constants.vbTab & "Message ID: " & e.MessageID.ToString() & Constants.vbCrLf
                     message &= Constants.vbTab & "Affected Class: " & e.AffectedClass.ToString()
                     If e._Error = DicomExceptionCode.Success Then
                        _globals.m_bMWLServerValid = True
                     End If
                  Case StatusType.SendReleaseRequest
                     message = "Sending release request..."
                  Case StatusType.ReceiveReleaseResponse
                     message = "Receiving release response"
                     done = True
                  Case StatusType.Timeout
                     message = "Communication timeout. Process will be terminated."
                     done = True
               End Select
            End If
            LogText(message)
            If done Then
               EnableControls(True)

               If Nothing IsNot _cecho AndAlso _cecho.IsConnected() Then
                  _cecho.Close()
                  _cecho.Dispose()
                  _cecho = Nothing
               End If
            End If
         Catch ex As Exception
            MessageBox.Show(ex.ToString())
         End Try
      End Sub

Public Delegate Sub LogTextDelegate(ByVal sentence As String)
        Public Sub LogText(ByVal sLogText As String)
            If Globals._closing = True OrElse Me.Disposing OrElse Me.IsDisposed Then
                Return
            End If

            If InvokeRequired Then
                Try
                    Invoke(New LogTextDelegate(AddressOf Me.LogText), New Object() {sLogText})
                Catch ex As Exception
                    If Globals._closing = False Then
                        Throw ex
                    End If
                End Try
            Else
                Try
                    If txtLog.Disposing = False Then
                        txtLog.Text = txtLog.Text & sLogText & Constants.vbCrLf
                        txtLog.SelectionStart = txtLog.Text.Length
                        txtLog.ScrollToCaret()
                    End If
                Catch ex As Exception
                    If Globals._closing = False Then
                        MessageBox.Show(ex.ToString())
                    End If
                End Try
            End If
        End Sub

      '
      '* Enables or disables controls
      '
        Public Delegate Sub EnableControlsDelegate(ByVal enable As Boolean)
        Private Sub EnableControls(ByVal enable As Boolean)
            If Globals._closing = True OrElse Me.Disposing OrElse Me.IsDisposed Then
                Return
            End If
            If Me.InvokeRequired Then
                Invoke(New EnableControlsDelegate(AddressOf EnableControls), New Object() {enable})
            Else
                Try
                    txtServerAE.Enabled = enable
               txtServerIP.Enabled = enable
               txtServerPort.Enabled = enable
               txtClientAE.Enabled = enable
               btnVerify.Enabled = enable

               CType(Parent.Parent, MainForm).btnNext.Enabled = _globals.m_bMWLServerValid
            Catch ex As Exception
               MessageBox.Show(ex.ToString())
            End Try
         End If
      End Sub
   End Class
End Namespace

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
Imports Leadtools.DicomDemos.Scu.CStore

Namespace DicomDemo
   Partial Public Class Page6 : Inherits UserControl
      Private _globals As Globals
      Private cstore As CStore
      Private m_strTemporaryDicomFileName As String = Environment.GetEnvironmentVariable("TEMP") & "\temp.dcm"

      Private Const CONFIGURATION_IMPLEMENTATIONCLASS As String = "1.2.840.114257.1123456"
      Private Const CONFIGURATION_IMPLEMENTATIONVERSIONNAME As String = "1"
      Private Const CONFIGURATION_PROTOCOLVERSION As String = "1"

      Public Sub New(ByRef pGlobals As Globals)
         InitializeComponent()

         _globals = pGlobals


         cstore = New CStore()

         cstore.ImplementationClass = CONFIGURATION_IMPLEMENTATIONCLASS
         cstore.ImplementationVersionName = CONFIGURATION_IMPLEMENTATIONVERSIONNAME
         cstore.ProtocolVersion = CONFIGURATION_PROTOCOLVERSION
         AddHandler cstore.Status, AddressOf cstore_Status
      End Sub

      Private Sub radServer_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles radServer.CheckedChanged
         ToggleControls()
      End Sub

      Private Sub radLocal_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles radLocal.CheckedChanged
         ToggleControls()
      End Sub

      '
      '* Toggles the text boxes' Enabled property based on whether the user is storing
      '*   on a server or locally.
      '
      Private Sub ToggleControls()
         Try
            _globals.m_bStoreOnServer = radServer.Checked
            txtServerAE.Enabled = _globals.m_bStoreOnServer
            txtServerIP.Enabled = _globals.m_bStoreOnServer
            txtServerPort.Enabled = _globals.m_bStoreOnServer
            txtClientAE.Enabled = _globals.m_bStoreOnServer
         Catch ex As Exception
            System.Windows.Forms.MessageBox.Show(ex.ToString())
         End Try
      End Sub

      '
      '* Enables or disables all of the controls
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
               radServer.Enabled = enable
               radLocal.Enabled = enable
               txtServerAE.Enabled = enable
               txtServerIP.Enabled = enable
               txtServerPort.Enabled = enable
               txtClientAE.Enabled = enable

               CType(Parent.Parent, MainForm).btnNext.Enabled = enable
            Catch ex As Exception
               System.Windows.Forms.MessageBox.Show(ex.ToString())
            End Try
         End If
      End Sub

      Private Sub Page6_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
         Try
            If _globals.m_bStoreOnServer Then
               radServer.Checked = True
            Else
               radLocal.Checked = True
            End If

            ' Initialize text boxes
            txtServerAE.Text = _globals.m_StorageServer.AETitle
            txtServerIP.Text = _globals.m_StorageServer.Address.ToString()
            txtServerPort.Text = _globals.m_StorageServer.Port.ToString()
            txtClientAE.Text = _globals.m_strStorageClientAE
         Catch ex As Exception
            System.Windows.Forms.MessageBox.Show(ex.ToString())
         End Try
      End Sub

      '
      '* Stores the dataset locally or on a server
      '
      Private Sub btnStore_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnStore.Click
         txtLog.Text = ""
         If _globals.m_bStoreOnServer Then ' Send to storage server
            Try
               EnableControls(False)

               ' Update changed settings
               _globals.m_StorageServer.AETitle = txtServerAE.Text
               _globals.m_StorageServer.Address = IPAddress.Parse(txtServerIP.Text)
               _globals.m_StorageServer.Port = Convert.ToInt32(txtServerPort.Text)
               _globals.m_strStorageClientAE = txtClientAE.Text

               ' Temporarily save the dataset to disk for the CStore process
               _globals.m_DS.Save(m_strTemporaryDicomFileName, DicomDataSetSaveFlags.LittleEndian Or DicomDataSetSaveFlags.ExplicitVR Or DicomDataSetSaveFlags.GroupLengths)
               cstore.Files.Add(m_strTemporaryDicomFileName)
               cstore.Store(_globals.m_StorageServer, _globals.m_strStorageClientAE)
            Catch ex As FormatException
               If ex.Message = "An invalid IP address was specified." Then
                  MessageBox.Show("The specified IP address is invalid.")
               Else
                  MessageBox.Show(ex.ToString())
               End If
            Catch ex As Exception
               MessageBox.Show(ex.ToString())
            End Try
         Else ' Store locally
            Dim sfd As SaveFileDialog = New SaveFileDialog()
                sfd.Filter = "DCM (*.dcm)|*.dcm|DICOM (*.dic)|*.dic|All Files (*.*)|*.*||"
            sfd.FilterIndex = 0
                sfd.FileName = "mwl.dcm"
            If sfd.ShowDialog(Me) = DialogResult.OK Then
               Try
                  _globals.m_DS.Save(sfd.FileName, DicomDataSetSaveFlags.LittleEndian Or DicomDataSetSaveFlags.ExplicitVR Or DicomDataSetSaveFlags.GroupLengths)
               Catch ex As Exception
                  MessageBox.Show("Error saving file: " & Constants.vbCrLf & Constants.vbCrLf & ex.ToString())
               End Try
            End If
         End If
      End Sub

      '
      '* Provides feedback on the status of the CStore process
      '
      Private Sub cstore_Status(ByVal sender As Object, ByVal e As StatusEventArgs)
         Try
            Dim message As String = ""
            Dim done As Boolean = False

            If e.Type = StatusType.Error Then
               message = "DICOM error. The process will be terminated! -- Error code is: " & e.Error.ToString()
            Else
               Select Case e.Type
                  Case StatusType.ConnectFailed
                     message = "Connect operation failed."
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
                     message = "Received Associate Reject!"
                     message &= Constants.vbTab & "Result: " & e.Result.ToString()
                     message &= Constants.vbTab & "Reason: " & e.Reason.ToString()
                     message &= Constants.vbTab & "Source: " & e.Source.ToString()
                  Case StatusType.AbstractSyntaxNotSupported
                     message = "Abstract Syntax NOT supported!"
                  Case StatusType.SendCStoreRequest
                     message = "Sending C-STORE Request..."
                  Case StatusType.ReceiveCStoreResponse
                     If e.Error = DicomExceptionCode.Success Then
                        message = "**** Storage completed successfully ****"
                     Else
                        message = "**** Storage failed with status: " & e.Status.ToString()
                     End If
                  Case StatusType.ConnectionClosed
                     message = "Network Connection closed!"
                     done = True
                  Case StatusType.ProcessTerminated
                     message = "Process has been terminated!"
                     done = True
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
               'enable buttons
               EnableControls(True)

               'remove file name from CStore object and remove temporary file from disk
               cstore.Files.Clear()
               System.IO.File.Delete(m_strTemporaryDicomFileName)

               If cstore.IsConnected() Then
                  cstore.Close()
               End If
            End If
         Catch ex As Exception
            System.Windows.Forms.MessageBox.Show(ex.ToString())
         End Try
      End Sub

      Public Delegate Sub LogTextDelegate(ByVal sentence As String)
      Public Sub LogText(ByVal logText_Renamed As String)
         If Globals._closing = True OrElse Me.Disposing OrElse Me.IsDisposed Then
            Return
         End If
         If InvokeRequired Then
            Invoke(New LogTextDelegate(AddressOf LogText), New Object() {logText_Renamed})
         Else
            Try
               txtLog.Text = txtLog.Text & logText_Renamed & Constants.vbCrLf
               txtLog.SelectionStart = txtLog.Text.Length
               txtLog.ScrollToCaret()
            Catch ex As Exception
               If Globals._closing = False Then
                  System.Windows.Forms.MessageBox.Show(ex.ToString())
               End If
            End Try
         End If
      End Sub

   End Class
End Namespace

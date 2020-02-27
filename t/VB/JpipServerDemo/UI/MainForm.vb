' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.IO
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports System.Configuration
Imports Leadtools
Imports Leadtools.Jpip
Imports Leadtools.Jpip.Server
Imports Microsoft.Win32
#If LEADTOOLS_V19_OR_LATER Then
Imports Leadtools.Demos.Dialogs
#End If

Partial Public Class MainForm : Inherits Form
   Private _server As JpipServer
   Private _displayLogs As Boolean
   Private _deniedIpAddress As String()
   Private _dataIpAddress As String()
   Private _datafolder As String = String.Empty
   Private _service As ImagesEnumerationService
   Private responseCount As Integer = 0

   Public Sub New()
      InitializeComponent()

      Messager.Caption = "JPIP Server Demo"

      _server = New JpipServer()
      _displayLogs = True
      _deniedIpAddress = New String() {}
      _dataIpAddress = New String() {}

      Dim configReader As AppSettingsReader = New AppSettingsReader()

      Try
         _server.Configuration.Port = CInt(configReader.GetValue("Port", GetType(Integer)))
      Catch
         _server.Configuration.Port = 49201
      End Try
      Try
         _server.Configuration.DivideSuperBoxes = CBool(configReader.GetValue("DivideSuperBoxes", GetType(Boolean)))
      Catch
         _server.Configuration.DivideSuperBoxes = True
      End Try
      Try
         _server.Configuration.ChunkSize = CInt(configReader.GetValue("ChunkSize", GetType(Integer)))
      Catch
         _server.Configuration.ChunkSize = 512
      End Try

      SetImagesPath(_server, configReader)

      _service = New ImagesEnumerationService(_server)

      _service.ImagesExtension.Add("*.j2k")
      _service.ImagesExtension.Add("*.jp2")
      _service.ImagesExtension.Add("*.jpx")

   End Sub

   Private Sub SetImagesPath(ByVal server As JpipServer, ByVal configReader As AppSettingsReader)
      Try
         Dim imagesPath As String


         Try
            imagesPath = CStr(configReader.GetValue("ImagesFolder", GetType(String)))
         Catch
            imagesPath = Path.GetFullPath("..\..\..\..\..\..\Images")
         End Try


         If (Not Directory.Exists(imagesPath)) Then
            imagesPath = DemosGlobal.ImagesFolder
         End If

         If Not Nothing Is imagesPath Then
            server.Configuration.ImagesFolder = imagesPath.ToString()
         End If
      Catch exception As Exception
         Messager.ShowError(Me, exception)
      End Try
   End Sub

   Private Sub UpdateUIMenuStsate()
      If Nothing Is _server Then
         Return
      End If

      If _server.IsRunning Then
         StartToolStripMenuItem.Enabled = False
         StopToolStripMenuItem.Enabled = True
      Else
         StartToolStripMenuItem.Enabled = True
         StopToolStripMenuItem.Enabled = False
      End If
   End Sub

   Private Delegate Sub InvokeLogerHandler(ByVal sender As Object, ByVal entry As Jpip.Logging.EventLogEntry)

   Private Sub EventLogger_EventLog(ByVal sender As Object, ByVal entry As Jpip.Logging.EventLogEntry)
      If (Not _displayLogs) Then
         Return
      End If

      Dim item As ListViewItem

      If lstvwEventLog.InvokeRequired Then
         lstvwEventLog.Invoke(New InvokeLogerHandler(AddressOf EventLogger_EventLog), New Object() {sender, entry})

         Return
      End If

      item = New ListViewItem(entry.ServerName)

      item.SubItems.AddRange(New String() {entry.ServerIPAddress, entry.ServerPort, entry.ClientIPAddress, entry.ClientPort, entry.Type.ToString(), entry.ChannelID, entry.DateTime.ToString(), entry.Description})

      lstvwEventLog.Items.Add(item)

      lstvwEventLog.Items(lstvwEventLog.Items.Count - 1).EnsureVisible()
   End Sub

   Private Sub _server_RequestReceived(ByVal sender As Object, ByVal e As RequestReceivedEventArgs)
      Try
         For Each clientIpAddress As String In _deniedIpAddress
            If e.ClientIpAddress = clientIpAddress Then
               e.Deny = True
               e.StatusCode = CInt(System.Net.HttpStatusCode.Forbidden)
               e.Description = "Server refused to process request."

               Exit For
            End If
         Next clientIpAddress
      Catch exception As Exception
         Messager.ShowError(Me, exception)
      End Try
   End Sub

   Private Sub _server_ResponseSending(ByVal sender As Object, ByVal e As ResponseSendingEventArgs)
      Try
         If String.IsNullOrEmpty(_datafolder) Then
            Return
         End If

         If (Not Directory.Exists(_datafolder)) Then
            Directory.CreateDirectory(_datafolder)
         End If

         For Each clientIpAddress As String In _dataIpAddress
            If e.ClientIpAddress = clientIpAddress Then
               Dim subDirectoryPath As String
               Dim responseDataFile As String

               responseCount += 1

               subDirectoryPath = String.Concat(_datafolder, "\", clientIpAddress)
               responseDataFile = String.Concat(subDirectoryPath, "\response_", responseCount)

               If (Not Directory.Exists(subDirectoryPath)) Then
                  Directory.CreateDirectory(subDirectoryPath)
               End If

               File.WriteAllBytes(responseDataFile, e.Data)

               Exit For
            End If
         Next clientIpAddress
      Catch exception As Exception
         Messager.ShowError(Me, exception)
      End Try
   End Sub


   Private Sub startToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles StartToolStripMenuItem.Click
      Try
         If (Not _server.IsRunning) Then
            AddHandler Jpip.Logging.EventLogger.EventLog, AddressOf EventLogger_EventLog
            AddHandler _server.RequestReceived, AddressOf _server_RequestReceived
            AddHandler _server.ResponseSending, AddressOf _server_ResponseSending
            _server.Start()

            If (_server.Configuration.IPAddress <> _service.IpAddress.ToString()) Then

               If (_service.Running) Then

                  _service.Stop()
               End If

               _service.IpAddress = System.Net.IPAddress.Parse(_server.Configuration.IPAddress)
            End If

            If (Not _service.Running) Then
               _service.Start()
            End If
         End If
         UpdateUIMenuStsate()
      Catch exception As Exception
         RemoveHandler Jpip.Logging.EventLogger.EventLog, AddressOf EventLogger_EventLog
         RemoveHandler _server.RequestReceived, AddressOf _server_RequestReceived
         RemoveHandler _server.ResponseSending, AddressOf _server_ResponseSending

         Messager.ShowError(Me, exception)
      End Try
   End Sub

   Private Sub stopToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles StopToolStripMenuItem.Click
      Try
         If _server.IsRunning Then
            _server.Stop()

            If (_service.Running) Then
               _service.Stop()
            End If

            RemoveHandler Jpip.Logging.EventLogger.EventLog, AddressOf EventLogger_EventLog
            RemoveHandler _server.RequestReceived, AddressOf _server_RequestReceived
            RemoveHandler _server.ResponseSending, AddressOf _server_ResponseSending
         End If
         UpdateUIMenuStsate()
      Catch exception As Exception
         Messager.ShowError(Me, exception)
      End Try
   End Sub

   Private Sub exitToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ExitToolStripMenuItem1.Click
      Me.Close()
   End Sub

   Private Sub clearLogsToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles clearLogsToolStripMenuItem.Click
      lstvwEventLog.Items.Clear()
   End Sub

   Private Sub displayLogsToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles displayLogsToolStripMenuItem.Click
      _displayLogs = displayLogsToolStripMenuItem.Checked
   End Sub

   Private Sub clearCachetoolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ClearCacheToolStripMenuItem.Click
      Dim deleteCache As DialogResult


      deleteCache = Messager.ShowQuestion(Me, "Are you sure you want to clear all cache contents?", MessageBoxButtons.YesNo)

      If deleteCache = DialogResult.Yes Then
         Try
            _server.ClearCacheContents()
         Catch exception As Exception
            Messager.ShowError(Me, exception)
         End Try
      End If
   End Sub

   Private Sub configurationToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ConfiguraitonToolStripMenuItem.Click
      Try
         Dim configDlg As Configuration


         configDlg = New Configuration(_server)

         configDlg.ShowDialog()
      Catch exception As Exception
         Messager.ShowError(Me, exception)
      End Try
   End Sub

   Private Sub InteractiveRequeststoolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles InteractiveRequeststoolStripMenuItem.Click
      Try
         Dim requestsDlg As RequestsHandling



         requestsDlg = New RequestsHandling(_deniedIpAddress)

         If requestsDlg.ShowDialog() = DialogResult.OK Then
            _deniedIpAddress = requestsDlg.IpAddresses
         End If
      Catch exception As Exception
         Messager.ShowError(Me, exception)
      End Try
   End Sub

   Private Sub InteractiveResponsestoolStripMenuItem3_Click(ByVal sender As Object, ByVal e As EventArgs) Handles InteractiveResponsestoolStripMenuItem3.Click
      Try
         Dim responseDlg As ResponseHandling


         responseDlg = New ResponseHandling(_dataIpAddress)
         responseDlg.DataFolder = _datafolder

         If responseDlg.ShowDialog() = DialogResult.OK Then
            _dataIpAddress = responseDlg.IpAddresses
            _datafolder = responseDlg.DataFolder
         End If
      Catch exception As Exception
         Messager.ShowError(Me, exception)
      End Try

   End Sub

   Private Sub fileEnumerationServiceToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles FileEnumerationServiceToolStripMenuItem1.Click
      Try
         Dim ImagesEnumSrvcDlg As ImagesEnumerationServiceDlg


         ImagesEnumSrvcDlg = New ImagesEnumerationServiceDlg(_service)

         ImagesEnumSrvcDlg.TopMost = True

         ImagesEnumSrvcDlg.Show()

      Catch exception As Exception
         Messager.ShowError(Me, exception)
      End Try
   End Sub

   Private Sub aboutToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles aboutToolStripMenuItem.Click
      Try
#If LEADTOOLS_V19_OR_LATER Then
         Using aboutDialog As New AboutDialog("Jpip Server", ProgrammingInterface.VB)
            aboutDialog.ShowDialog(Me)
         End Using
#Else
         Using aboutDialog As New AboutDialog("Jpip Server")
	         aboutDialog.ShowDialog(Me)
         End Using
#End If
      Catch exception As Exception
         Messager.ShowError(Me, exception)
      End Try
   End Sub

   Private Sub howToToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles howToToolStripMenuItem.Click
      Try
         DemosGlobal.LaunchHowTo("Jpip.html")
      Catch ex As Exception
         Messager.ShowError(Me, ex.Message)
      End Try
   End Sub

   Private Sub MainForm_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
      stopToolStripMenuItem_Click(sender, e)
   End Sub
End Class

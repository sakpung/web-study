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
Imports System.IO
Imports System.Data.SqlServerCe
Imports System.Diagnostics
Imports Leadtools.Demos
Imports Leadtools.Dicom.Server.Admin
Imports Leadtools.Configuration.Logging


Namespace Leadtools.Dicom.Server.Manager.Dialogs
    Partial Public Class EventLogDialog
      Inherits Form

      Public Const LogDatabaseName As String = "Logging.sdf"

      Public Sub New(ByVal activeService As DicomService)
         InitializeComponent()

         ActiveService = activeService
         UpdateService()
      End Sub

      Private privateActiveService As DicomService
      Public Property ActiveService() As DicomService
         Get
            Return privateActiveService
         End Get
         Set(ByVal value As DicomService)
            privateActiveService = value
         End Set
      End Property

      Public ReadOnly Property ServiceDirectory() As String
         Get
            If ActiveService IsNot Nothing AndAlso ActiveService.ServiceDirectory IsNot Nothing Then
               Return ActiveService.ServiceDirectory
            Else
               Return String.Empty
            End If
         End Get
      End Property

      Public ReadOnly Property ServiceName() As String
         Get
            If ActiveService IsNot Nothing AndAlso ActiveService.ServiceName IsNot Nothing Then
               Return ActiveService.ServiceName
            Else
               Return String.Empty
            End If
         End Get
      End Property


      Public Function GetLogDatabaseFullPath() As String
         Debug.Assert((Not String.IsNullOrEmpty(ServiceDirectory)))
         Dim startPath As String = ServiceDirectory
         Dim LogDatabaseFullPath As String = Path.Combine(startPath, LogDatabaseName)
         Return LogDatabaseFullPath
      End Function

      Public Function GetLogDatasetsFolder() As String
         Dim startPath As String = ServiceDirectory
         Dim LogDatasetsFolder As String = Path.Combine(startPath, "log\\Datasets")
         Return LogDatasetsFolder.Trim()
      End Function

      Public Function GetConnectionString() As String
         Dim LogDatabaseFullPath As String = GetLogDatabaseFullPath()
         Dim ConnectionString As String = "Data Source='" & LogDatabaseFullPath & "'"
         Return ConnectionString
      End Function

      Private Sub EventLogDialog_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
         UpdateUI()
         numericUpDownLastLogs.Value = 100
         SizeColumns(listViewEventLog)
      End Sub

      Private Sub SizeColumns(ByVal listview As ListView)
         listview.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize)
      End Sub

      Public Sub Clear()
         listViewEventLog.Items.Clear()
      End Sub

      Private Function GetPortString(ByVal o As Object) As String
         Dim sRet As String = String.Empty
         Dim nServerPort As Integer = Convert.ToInt32(o)
         If nServerPort <> -1 Then
            sRet = nServerPort.ToString()
         End If
         Return sRet
      End Function

      Private Sub DoQuery()
         Dim sQuery As String = "SELECT * FROM [DICOMServerEventLog]"
         Dim nCount As Decimal = numericUpDownLastLogs.Value
         If checkBoxLastLogs.Checked Then
            sQuery = String.Format("SELECT TOP ({0}) * FROM [DICOMServerEventLog]", nCount)
         End If

         Dim bAnd As Boolean = False
         If checkBoxServerAeTitle.Checked Then
            Dim sSearchValue As String = textBoxServerAeTitle.Text.Trim()
            sSearchValue = sSearchValue.Replace("*", String.Empty)
            Dim sAppend As String = String.Format(" {0} ServerAETitle like '{1}%'", If(bAnd, "AND", "WHERE"), sSearchValue)
            sQuery = sQuery & sAppend
            bAnd = True
         End If

         If checkBoxClientAeTitle.Checked Then
            Dim sSearchValue As String = textBoxClientAeTitle.Text.Trim()
            sSearchValue = sSearchValue.Replace("*", String.Empty)
            Dim sAppend As String = String.Format(" {0} ClientAETitle like '{1}%'", If(bAnd, "AND", "WHERE"), sSearchValue)
            sQuery = sQuery & sAppend
            bAnd = True
         End If

         sQuery = String.Concat(sQuery, " ORDER BY EventID")

         listViewEventLog.Items.Clear()
         Dim connectionString As String = GetConnectionString()
         Using connection As New SqlCeConnection(connectionString)
            connection.Open()
            Using com As New SqlCeCommand(sQuery, connection)
               Dim reader As SqlCeDataReader = com.ExecuteReader()
               Do While reader.Read()
                  Try
                     Dim id As Object = reader("EventID")
                     Dim nEventId As Integer = Convert.ToInt32(id)
                     Dim serverAeTitle As String = CStr(reader("ServerAETitle").ToString())
                     Dim serverIpAddress As String = CStr(reader("ServerIPAddress").ToString())

                     Dim serverPort As String = GetPortString(reader("ServerPort"))
                     Dim clientAeTitle As String = CStr(reader("ClientAETitle").ToString())
                     Dim clientHostAddress As String = CStr(reader("ClientHostAddress").ToString())
                     Dim clientPort As String = GetPortString(reader("ClientPort"))
                     Dim command As String = CStr(reader("Command").ToString())
                     Dim eventDateTime As String = CStr(reader("EventDateTime").ToString())
                     ' string logType                = (string)reader["Type"].ToString();
                     Dim messageDirection As String = CStr(reader("MessageDirection").ToString())
                     Dim datasetPath As String = CStr(reader("DatasetPath").ToString())
                     Dim description As String = CStr(reader("Description").ToString())
                     ' CustomInformation

                     If String.Compare(command, "Undefined", True) = 0 Then
                        command = String.Empty
                     End If

                     If String.Compare(messageDirection, "None", True) = 0 Then
                        messageDirection = String.Empty
                     End If


                     Dim item As ListViewItem = listViewEventLog.Items.Add(serverAeTitle)
                     item.Tag = New EventLogItem(nEventId, datasetPath)
                     If item IsNot Nothing Then
                        item.SubItems.Add(serverIpAddress) ' 1
                        item.SubItems.Add(serverPort) ' 2
                        item.SubItems.Add(clientAeTitle) ' 3
                        item.SubItems.Add(clientHostAddress) ' 4
                        item.SubItems.Add(clientPort.ToString()) ' 5
                        item.SubItems.Add(command) ' 6
                        item.SubItems.Add(eventDateTime) ' 7
                        ' item.SubItems.Add(logType);
                        item.SubItems.Add(messageDirection) ' 8
                        item.SubItems.Add(description) ' 9
                        item.SubItems.Add(datasetPath) ' 10
                     End If

                  Catch ex As Exception
                     MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                  End Try
               Loop
            End Using
         End Using
      End Sub

      Private Sub buttonQuery_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles buttonQuery.Click
         DoQuery()
         SizeColumns(listViewEventLog)
      End Sub

      Private Sub UpdateUI()
         ' LastLogs checkbox
         Dim enabledLastLogs As Boolean = checkBoxLastLogs.Checked
         numericUpDownLastLogs.Enabled = enabledLastLogs
         labelLastLogs.Enabled = enabledLastLogs

         ' Server AE checkbox
         textBoxServerAeTitle.Enabled = checkBoxServerAeTitle.Checked

         ' Client AE checkbox
         textBoxClientAeTitle.Enabled = checkBoxClientAeTitle.Checked

         Dim nSelectedCount As Integer = listViewEventLog.SelectedItems.Count
         buttonDetail.Enabled = (nSelectedCount = 1)
         buttonDeleteSelected.Enabled = (nSelectedCount > 0)
      End Sub

      Public Sub UpdateService()
         Text = "Event Log - " & ServiceName
         ConfigurationLoggingSession.ServerDirectory = ServiceDirectory
         checkBoxEnableLogging.Text = String.Format("Enable Logging ({0})", ServiceName)
         Dim logDicomDataset As Boolean = False
         checkBoxEnableLogging.Checked = ConfigurationLoggingSession.ReadSettings(logDicomDataset)
         checkBoxLogDatasets.Checked = logDicomDataset
      End Sub

      Private Sub buttonDeleteAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles buttonDeleteAll.Click
         Dim dr As DialogResult = MessageBox.Show("You are about to permanently remove all log messages.  Do you want to continue?", "Delete All", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
         If dr = DialogResult.Yes Then
            ' Delete any existing datasets
            DeleteAllDatasets()
            listViewEventLog.Items.Clear()
            SizeColumns(listViewEventLog)
            Dim connectionString As String = GetConnectionString()
            Using connection As New SqlCeConnection(connectionString)
               connection.Open()
               Using com As New SqlCeCommand("DELETE FROM DICOMServerEventLog", connection)
                  com.ExecuteNonQuery()
               End Using
            End Using
         End If
      End Sub

      Public Function GetDeleteSelectedQuery() As String
         Dim sQuery As String = "DELETE FROM DICOMServerEventLog"
         Dim bFirst As Boolean = True

         For Each lvi As ListViewItem In listViewEventLog.SelectedItems
            Dim eventLogItem As EventLogItem = TryCast(lvi.Tag, EventLogItem)
            Dim eventId As Integer = eventLogItem.EventId
            If bFirst Then
               sQuery = sQuery & String.Format(" WHERE EventId = '{0}' ", eventId)
               bFirst = False
            Else
               sQuery = sQuery & String.Format(" OR EventId = '{0}' ", eventId)
            End If
         Next lvi

         Return sQuery
      End Function

      Public Sub DeleteSelectedDatasets()
         For Each lvi As ListViewItem In listViewEventLog.SelectedItems
            Dim eventLogItem As EventLogItem = TryCast(lvi.Tag, EventLogItem)

            Dim strFile As String = eventLogItem.DatasetPath
            If File.Exists(strFile) Then
               Try
                  File.Delete(strFile)
               Catch
               End Try
            End If
         Next lvi
      End Sub

      Public Sub DeleteAllDatasets()
         Dim LogDatasetsFolder As String = GetLogDatasetsFolder()
         If Not String.IsNullOrEmpty(LogDatasetsFolder) Then
            Dim directoryInfo As DirectoryInfo = New DirectoryInfo(LogDatasetsFolder)
            For Each file As FileInfo In DirectoryInfo.GetFiles()
               ' Just a precaution, but only delete files that have pattern xxxxxxxx.xxx
               If file.Name.Length = 12 And file.Name(8) = "." Then
                  file.Delete()
               End If
            Next file
         End If
      End Sub

      Private Sub buttonDeleteSelected_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles buttonDeleteSelected.Click
         Dim sMsg As String = String.Format("You are about to permanently remove {0} selected log messages.  Do you want to continue?", listViewEventLog.SelectedItems.Count)

         Dim dr As DialogResult = MessageBox.Show(sMsg, "Delete Selected", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
         If dr = DialogResult.Yes Then
            SizeColumns(listViewEventLog)
            Dim connectionString As String = GetConnectionString()
            Using connection As New SqlCeConnection(connectionString)
               connection.Open()
               Dim sQuery As String = GetDeleteSelectedQuery()
               Using com As New SqlCeCommand(sQuery, connection)
                  com.ExecuteNonQuery()
               End Using
            End Using

            ' Now remove selected items from ListView
            For Each itemSelected As ListViewItem In listViewEventLog.SelectedItems
               listViewEventLog.Items.Remove(itemSelected)
            Next itemSelected
         End If
      End Sub

      Private Sub checkBoxLastLogs_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles checkBoxLastLogs.CheckedChanged
         UpdateUI()
      End Sub

      Private Sub listViewEventLog_ItemSelectionChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ListViewItemSelectionChangedEventArgs) Handles listViewEventLog.ItemSelectionChanged
         UpdateUI()
      End Sub

      Private Sub checkBoxServerAeTitle_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles checkBoxServerAeTitle.CheckedChanged
         UpdateUI()
      End Sub

      Private Sub checkBoxClientAeTitle_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles checkBoxClientAeTitle.CheckedChanged
         UpdateUI()
      End Sub

      Private Sub buttonClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles buttonClose.Click
         Close()
      End Sub

      Private Sub ShowDetails()
         If listViewEventLog.SelectedItems.Count = 1 Then
            Dim item As ListViewItem = listViewEventLog.SelectedItems(0)
            Dim dlg As New EventLogDetailDialog()

            ' string sNotUsed         = item.SubItems[1].Name;
            dlg.ServerAeTitle = item.Text
            dlg.ServerIpAddress = item.SubItems(1).Text
            dlg.ServerPort = item.SubItems(2).Text
            dlg.ClientAeTitle = item.SubItems(3).Text
            dlg.ClientIpAddress = item.SubItems(4).Text
            dlg.ClientPort = item.SubItems(5).Text
            dlg.Command = item.SubItems(6).Text
            dlg.EventDateTime = item.SubItems(7).Text
            ' dlg.MessageDirection    = item.SubItems[8].Text;
            dlg.Description = item.SubItems(9).Text
            dlg.DatasetPath = item.SubItems(10).Text

            dlg.ShowDialog()
         End If
      End Sub

      Private Sub buttonDetail_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles buttonDetail.Click
         ShowDetails()
      End Sub

      Private Sub listViewEventLog_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles listViewEventLog.DoubleClick
         ShowDetails()
      End Sub

      Private Sub UpdateSettings()
         ConfigurationLoggingSession.ServerDirectory = ServiceDirectory

         Try
            ConfigurationLoggingSession.WriteSettings(checkBoxEnableLogging.Checked, checkBoxLogDatasets.Checked)
            If ActiveService IsNot Nothing AndAlso ActiveService.Status = System.ServiceProcess.ServiceControllerStatus.Running Then
               ActiveService.SendMessage(MyDicomLoggingChannel.SettingsChanged)
            End If
         Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
         End Try
      End Sub

      Private Sub checkBoxEnableLogging_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles checkBoxEnableLogging.CheckedChanged
         UpdateSettings()
      End Sub

      Private Sub checkBoxLogDatasets_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles checkBoxLogDatasets.CheckedChanged
         UpdateSettings()
      End Sub
   End Class

   Public Class EventLogItem
      Public Sub New(eventId As Integer, datasetPath As String)
         _eventId = eventId
         _datasetPath = datasetPath
      End Sub

      Private _eventId As Integer

      Public Property EventId() As Integer
         Get
            Return _eventId
         End Get
         Set(value As Integer)
            _eventId = value
         End Set
      End Property
      Private _datasetPath As String

      Public Property DatasetPath() As String
         Get
            Return _datasetPath
         End Get
         Set(value As String)
            _datasetPath = value
         End Set
      End Property
   End Class
End Namespace

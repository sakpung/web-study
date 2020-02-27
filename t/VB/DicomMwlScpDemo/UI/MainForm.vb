' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Data.SQLite
Imports System.Drawing
Imports System.IO
Imports System.Net
Imports System.Text
Imports System.Windows.Forms
Imports Microsoft.Win32
Imports System.Security.Principal
Imports System.Diagnostics

Imports Leadtools
Imports Leadtools.Dicom
Imports Leadtools.DicomDemos

Namespace DicomDemo
   Partial Public Class MainForm : Inherits Form
      Private dicomServer As Server = New Server()
      Public m_strDBFileName As String
      Public DB_FILENAME As String = "MWLSCP.db"

      Public Sub New()
         InitializeComponent()
      End Sub

      ''' The main entry point for the application.
      <STAThread()> _
      Shared Sub Main(ByVal args As String())
         
         If Not Support.SetLicense() Then
            Return
         End If

         If (RasterSupport.IsLocked(RasterSupportType.DicomCommunication)) Then
            MessageBox.Show(String.Format("{0} Support is locked!", RasterSupportType.DicomCommunication.ToString()), "Warning")
            Return
         End If

         If DemosGlobal.MustRestartElevated() Then
            DemosGlobal.TryRestartElevated(args)
            Return
         End If

         Utils.EngineStartup()
         Utils.DicomNetStartup()

         Application.Run(New MainForm())
      End Sub


      Private Sub btnClose_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnClose.Click
         Close()
      End Sub

      '
      '* Loads settings from the registry.
      '
      Private Sub LoadSettings()
         Try
            Dim user As RegistryKey = Registry.CurrentUser

#If LTV19_CONFIG Then
            Dim settings As RegistryKey = user.OpenSubKey("SOFTWARE\LEAD Technologies, Inc.\19\VB_DicomMwlScp19", True)
#ElseIf LTV20_CONFIG Then
            Dim settings As RegistryKey = user.OpenSubKey("SOFTWARE\LEAD Technologies, Inc.\20\VB_DicomMwlScp20", True)
#End If

            If settings Is Nothing Then
               ' We haven't saved any setting yet.  Use defaults
               txtCalledAE.Text = "LEAD_SERVER"
               txtPort.Text = "104"
               txtConcurrentConnections.Text = "5"

               m_strDBFileName = ""
               Return
            End If

            txtCalledAE.Text = Convert.ToString(settings.GetValue("CalledAE"))
            txtPort.Text = Convert.ToString(settings.GetValue("Port"))
            txtConcurrentConnections.Text = Convert.ToString(settings.GetValue("MaxConcurrentConnections"))

            m_strDBFileName = Convert.ToString(settings.GetValue("strDBFileName"))
            settings.Close()
         Catch ex As Exception
            MessageBox.Show("Error loading settings from registry:" & Constants.vbCrLf & Constants.vbCrLf & ex.ToString())
         End Try
      End Sub

      '
      '* Saves settings to the registry
      '
      Private Sub SaveSettings()
         Try
            Dim user As RegistryKey = Registry.CurrentUser
            Dim subKey As String

#If LTV19_CONFIG Then
            subKey = "SOFTWARE\LEAD Technologies, Inc.\19\VB_DicomMwlScp19"
#ElseIf LTV20_CONFIG Then
            subKey = "SOFTWARE\LEAD Technologies, Inc.\20\VB_DicomMwlScp20"
#End If

            Dim settings As RegistryKey = user.OpenSubKey(subKey, True)
            If settings Is Nothing Then
               settings = user.CreateSubKey(subKey)
            End If

            settings.SetValue("CalledAE", txtCalledAE.Text)
            settings.SetValue("Port", Convert.ToInt32(txtPort.Text), RegistryValueKind.DWord)
            settings.SetValue("MaxConcurrentConnections", Convert.ToInt32(txtConcurrentConnections.Text), RegistryValueKind.DWord)

            settings.SetValue("strDBFileName", m_strDBFileName)

            settings.Close()
         Catch ex As Exception
            MessageBox.Show("Error xaving xettings to registry:" & Constants.vbCrLf & Constants.vbCrLf & ex.ToString())
         End Try
      End Sub

      Private Sub MainForm_FormClosing(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles MyBase.FormClosing
         ' Save settings to registry
         SaveSettings()
      End Sub

      Private Sub MainForm_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
         ' Try to get settings from registry
         LoadSettings()

         dicomServer.mf = Me

         If (Not PrepareDatabase()) Then
            MessageBox.Show("The application couldn't be started because no database could be found.")
            Close()
         End If

         If (Not PopulateDatabaseList()) Then
            MessageBox.Show("The application couldn't be started because the database seems to be incompatible.")
            Close()
         End If
      End Sub

      '
      '* Adds a client to the ListView
      '
      Private Sub btnAddClient_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnAddClient.Click
         If txtCallingAE.Text = "" Then
            MessageBox.Show("You must enter a name for the client")
         Else
            Try
               ' to make sure the IP address is valid
               Dim newClient As String() = New String() {txtCallingAE.Text, IPAddress.Parse(txtIP.Text).ToString()}
               lstClients.Items.Add(New ListViewItem(newClient))
               txtCallingAE.Text = ""
               txtIP.Text = ""
            Catch ex As FormatException
               If ex.Message = "An invalid IP address was specified." Then
                  MessageBox.Show("The specified IP address is invalid.")
               Else
                  MessageBox.Show("Error:" & Constants.vbCrLf & Constants.vbCrLf & ex.ToString())
               End If
            Catch ex As Exception
               MessageBox.Show("Error:" & Constants.vbCrLf & Constants.vbCrLf & ex.ToString())
            End Try
         End If
      End Sub

      '
      '* Deletes a client from the ListView
      '
      Private Sub btnDeleteClient_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnDeleteClient.Click
         If lstClients.SelectedIndices.Count > 0 Then
            lstClients.Items.RemoveAt(lstClients.SelectedIndices(0))
         End If
      End Sub

      '
      '* Starts the server
      '
      Private Sub btnStart_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnStart.Click
         Dim ret As DicomExceptionCode

         Try
            dicomServer.CalledAE = txtCalledAE.Text
            dicomServer.Port = Convert.ToInt32(txtPort.Text)
            dicomServer.Peers = Convert.ToInt32(txtConcurrentConnections.Text)

            ret = dicomServer.Listen()
            If ret = DicomExceptionCode.Success Then
               EnableControls(True)
               Log("Server Started..." & Constants.vbCrLf)
               tabControl1.SelectedIndex = 2
            Else
               Log("Error starting server: " & ret.ToString() & Constants.vbCrLf)
            End If
         Catch ex As Exception
            Log("Error starting server:" & Constants.vbCrLf & Constants.vbCrLf & ex.ToString())
         End Try
      End Sub

      '
      '* Stops the server
      '
      Private Sub btnStop_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnStop.Click
         Try
            dicomServer.Close()
            EnableControls(False)
            Log("Server Stopped..." & Constants.vbCrLf)
         Catch ex As Exception
            Log("Error stopping server:" & Constants.vbCrLf & Constants.vbCrLf & ex.ToString())
         End Try
      End Sub

      '
      '* Adds a string to the textbox on the log tab
      '
      Public Delegate Sub LogDelegate(ByVal str As String)
      Public Sub Log(ByVal str As String)
         If Me.InvokeRequired Then
            Me.Invoke(New LogDelegate(AddressOf Log), New Object() {str})
         Else
            txtLog.Text += str
         End If
      End Sub

      '
      '* Enables or disables controls based on whether the server is running
      '
      Private Sub EnableControls(ByVal serverStarted As Boolean)
         txtCalledAE.Enabled = Not serverStarted
         txtCallingAE.Enabled = Not serverStarted
         txtConcurrentConnections.Enabled = Not serverStarted
         txtIP.Enabled = Not serverStarted
         txtPort.Enabled = Not serverStarted
         btnAddClient.Enabled = Not serverStarted
         btnDeleteClient.Enabled = Not serverStarted
         lstClients.Enabled = Not serverStarted
         btnStart.Enabled = Not serverStarted
         btnStop.Enabled = serverStarted
      End Sub

      '
      '* Clears the log
      '
      Private Sub btnClearAll_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnClearAll.Click
         txtLog.Text = ""
      End Sub

      '
      '* Attempts to find the database file referred to in the registry settings.  If it cannot find it, then
      '*   look for it in the <LEADTOOLS>\Images\ directory.  If it cannot find it, then prompt the user.
      '*
      '* Returns true if successful, false otherwise.
      '
      Private Function PrepareDatabase() As Boolean
         Dim strAppFolder As String = ""
         Dim strLEADTOOLSFolder As String = ""
         Dim strNewDBFileName As String = ""
         Dim strExistingDBFileName As String = ""
         Dim strMessage As String = ""

         Try
            ' Check the existance of the file saved in registry 
            If File.Exists(m_strDBFileName) Then
               Return True
            End If

            strAppFolder = Application.StartupPath

            strNewDBFileName = strAppFolder & "\" & DB_FILENAME

            ' At first, we will assume that the application is running from the "Bin" subfolder of
            ' the folder where LEADTOOLS is installed.
            If strAppFolder <> "" Then
               strLEADTOOLSFolder = DemosGlobal.ImagesFolder
            End If

            ' Locate the database file
            strExistingDBFileName = strLEADTOOLSFolder & "\" & DB_FILENAME

            If (Not File.Exists(strExistingDBFileName)) Then
               'Locate the database file
               ' Prompt the user to locate the file
               strMessage = "Failed to locate file (DB) used by this demo. Do you want " & "to locate it yourself?" & Constants.vbCrLf & Constants.vbCrLf & "Note: A Simple DB file is located under the LEADTOOLS Images directory created by LEADTOOLS " & Constants.vbCrLf & "If your system is on the C:\ drive, the path for the database would be:" & Constants.vbCrLf & "<for windows XP>" & Constants.vbCrLf & "  C:\Documents and Settings\UserProfile\My Documents\LEADTOOLS Images\" & DB_FILENAME & Constants.vbCrLf & "<for windows VISTA>" & Constants.vbCrLf & "  C:\Users\UserProfile\Documents\LEADTOOLS Images\" & DB_FILENAME

               If MessageBox.Show(strMessage, "", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                  'Allow the user to select a file
                  Dim ofd As OpenFileDialog = New OpenFileDialog()
                  ofd.FileName = DB_FILENAME
                  ofd.Filter = "SQLite Databases (*.db)|*.db|All Files (*.*)|*.*"
                  'txt files (*.txt)|*.txt|All files (*.*)|*.*
                  ofd.Title = "Locate DB File"
                  ofd.CheckFileExists = True

                  If ofd.ShowDialog() = Windows.Forms.DialogResult.OK Then
                     strExistingDBFileName = ofd.FileName
                  Else
                     Return False
                  End If
               Else
                  Return False
               End If
            End If

            ' Copy the existing database file
            Try
               If File.Exists(strNewDBFileName) Then
                  If MessageBox.Show("Database file, " & strNewDBFileName & ", already exists.  Do you want to replace it?", "Database Exists", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                     File.Copy(strExistingDBFileName, strNewDBFileName, True)
                  End If
               Else
                  File.Copy(strExistingDBFileName, strNewDBFileName, False)
               End If
            Catch ex As Exception
               MessageBox.Show("Error copying file: " & Constants.vbCrLf & Constants.vbCrLf & ex.ToString())
               Return False
            End Try
         Catch ex As Exception
            MessageBox.Show("Error initializing database:" & Constants.vbCrLf & Constants.vbCrLf & ex.ToString())
            Return False
         End Try

         m_strDBFileName = strNewDBFileName
         Return True
      End Function

      '
      '* Queries the entire database and populates the ListView
      '
      Private Function PopulateDatabaseList() As Boolean
         Try
            ' Query database
            Dim SqlConn As SQLiteConnection = New SQLiteConnection()
            SqlConn.ConnectionString = String.Format("Data Source={0};New=False;Version=3", m_strDBFileName)
            SqlConn.Open()

            Dim strSQLQuery As String = "SELECT " & "TAG_ACCESSION_NUMBER as [Accession Number]," & "TAG_MODALITY  as [Modality]," & "TAG_INSTITUTION_NAME as [Institution Name]," & "TAG_REFERRING_PHYSICIAN_NAME as [Referring Physician Name]," & "TAG_PATIENT_NAME as [Patient Name]," & "TAG_PATIENT_ID as [Patient ID]," & "TAG_PATIENT_BIRTH_DATE as [Patient Birth Date]," & "TAG_PATIENT_SEX as [Patient Sex]," & "TAG_PATIENT_WEIGHT as [Patient Weight]," & "TAG_STUDY_INSTANCE_UID AS [Study Instance UID]," & "TAG_REQUESTING_PHYSICIAN AS [Requesting Physician]," & "TAG_REQUESTED_PROCEDURE_DESCRIPTION AS [Requested Procedure Description]," & "TAG_ADMISSION_ID AS [Admission ID]," & "TAG_SCHEDULED_STATION_AE_TITLE AS [Scheduled Station AE Title]," & "TAG_SCHEDULED_PROCEDURE_STEP_START_DATE AS [Scheduled Procedure Step Start Date]," & "TAG_SCHEDULED_PROCEDURE_STEP_START_TIME AS [Scheduled Procedure Step Start Time]," & "TAG_SCHEDULED_PERFORMING_PHYSICIAN_NAME AS [Scheduled Performing Physician Name]," & "TAG_SCHEDULED_PROCEDURE_STEP_DESCRIPTION AS [Scheduled Procedure Step Description]," & "TAG_SCHEDULED_PROCEDURE_STEP_ID AS [Scheduled Procedure Step ID]," & "TAG_SCHEDULED_PROCEDURE_STEP_LOCATION AS [Scheduled Procedure Step Location]," & "TAG_REQUESTED_PROCEDURE_ID AS [Requested Procedure ID]," & "TAG_REASON_FOR_THE_REQUESTED_PROCEDURE AS [Reason for the Requested Procedure]," & "TAG_REQUESTED_PROCEDURE_PRIORITY AS [Requested Procedure Priority]," & "Item_ID  " & "FROM MwlSCPTbl ORDER BY Item_ID;"

            Dim cmd As SQLiteCommand = SqlConn.CreateCommand()
            cmd.CommandText = strSQLQuery
            Dim reader As SQLiteDataReader = cmd.ExecuteReader(CommandBehavior.Default)

            ' Create the columns
            Dim columnHeaders As ColumnHeader() = New ColumnHeader(reader.FieldCount - 2) {} 'one less field because we don't care about displaying the Item_ID
            Dim g As Graphics = lstDatabase.CreateGraphics()
            Dim i As Integer = 0
            Do While i < columnHeaders.Length
               columnHeaders(i) = New ColumnHeader()
               columnHeaders(i).Text = reader.GetName(i)
               columnHeaders(i).Width = Convert.ToInt32((g.MeasureString(columnHeaders(i).Text, lstDatabase.Font)).Width) + 10
               i += 1
            Loop
            lstDatabase.Columns.AddRange(columnHeaders)

            ' Create the rows
            Do While reader.Read()
               Dim items As String() = New String(reader.FieldCount - 1) {} ' We use all fields here, but Item_ID is hidden

               i = 0
               Do While i < reader.FieldCount
                  ' SQLite stores dates as strings, so avoid the internal conversion
                  If reader.GetFieldType(i).ToString() = "System.DateTime" Then
                     items(i) = reader.GetString(i)
                  Else
                     items(i) = reader.GetValue(i).ToString()
                  End If
                  i += 1
               Loop

               lstDatabase.Items.Add(New ListViewItem(items))
            Loop

            SqlConn.Close()
         Catch ex As Exception
            MessageBox.Show("Error populating listbox with database:" & Constants.vbCrLf & Constants.vbCrLf & ex.ToString())
            Return False
         End Try

         Return True
      End Function

      '
      '* Adds a record to the database and its corresponding ListViewItem
      '
      Private Sub btnAddRecord_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnAddRecord.Click
         Dim itemDlg As MwlItemDialog = New MwlItemDialog(True)
         If itemDlg.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
            Try
               ' Add the new item into the database
               Dim SqlConn As SQLiteConnection = New SQLiteConnection()
               SqlConn.ConnectionString = String.Format("Data Source={0};New=False;Version=3", m_strDBFileName)
               SqlConn.Open()

               Dim cmd As SQLiteCommand = SqlConn.CreateCommand()
               cmd.CommandText = itemDlg.m_strSqlQuery
               cmd.ExecuteNonQuery()

               ' Get the Item_ID of the record we just added and update the string array for creating the ListViewItem
               cmd = SqlConn.CreateCommand()
               cmd.CommandText = "SELECT last_insert_rowid()"
               itemDlg.m_strItemValues(23) = Convert.ToString(cmd.ExecuteScalar())

               SqlConn.Close()

               ' Add the new ListViewItem
               lstDatabase.Items.Add(New ListViewItem(itemDlg.m_strItemValues))
            Catch ex As Exception
               MessageBox.Show("Error adding record to database:" & Constants.vbCrLf & Constants.vbCrLf & ex.ToString())
            End Try
         End If
      End Sub

      '
      '* Modifys a record from the database and its corresponding ListViewItem
      '
      Private Sub btnEditRecord_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnEditRecord.Click
         If lstDatabase.SelectedItems.Count > 0 Then
            Dim itemDlg As MwlItemDialog = New MwlItemDialog(False)
            If itemDlg.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
               Try
                  ' Update the item in the database
                  Dim SqlConn As SQLiteConnection = New SQLiteConnection()
                  SqlConn.ConnectionString = String.Format("Data Source={0};New=False;Version=3", m_strDBFileName)
                  SqlConn.Open()

                  Dim cmd As SQLiteCommand = SqlConn.CreateCommand()
                  cmd.CommandText = itemDlg.m_strSqlQuery
                  cmd.ExecuteNonQuery()

                  SqlConn.Close()

                  ' Update the ListViewItem
                  lstDatabase.Items(lstDatabase.SelectedIndices(0)) = New ListViewItem(itemDlg.m_strItemValues)
               Catch ex As Exception
                  MessageBox.Show("Error modifying record in database:" & Constants.vbCrLf & Constants.vbCrLf & ex.ToString())
               End Try
            End If
         Else
            MessageBox.Show("Please select an item to edit")
         End If
      End Sub

      '
      '* Deletes a record from the database and its corresponding ListViewItem
      '
      Private Sub btnDeleteRecord_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnDeleteRecord.Click
         If lstDatabase.SelectedItems.Count > 0 Then
            Try
               ' Delete the item from the database
               Dim strSQLQuery As String = "DELETE FROM MwlSCPTbl WHERE Item_ID='" & lstDatabase.SelectedItems(0).SubItems(23).Text & "'"
               Dim SqlConn As SQLiteConnection = New SQLiteConnection()
               SqlConn.ConnectionString = String.Format("Data Source={0};New=False;Version=3", m_strDBFileName)
               SqlConn.Open()

               Dim cmd As SQLiteCommand = SqlConn.CreateCommand()
               cmd.CommandText = strSQLQuery
               cmd.ExecuteNonQuery()

               SqlConn.Close()

               ' Delete the corresponding ListViewItem
               lstDatabase.Items.RemoveAt(lstDatabase.SelectedIndices(0))

            Catch ex As Exception
               MessageBox.Show("Error removing record from database:" & Constants.vbCrLf & Constants.vbCrLf & ex.ToString())
            End Try
         Else
            MessageBox.Show("Please select an item to delete")
         End If
      End Sub
   End Class
End Namespace

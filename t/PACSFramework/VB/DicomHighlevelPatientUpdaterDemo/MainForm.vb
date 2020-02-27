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
Imports System.Resources
Imports Leadtools.Dicom.Scu.Common
Imports Leadtools.Dicom.Scu
Imports System.IO
Imports Leadtools.Dicom
Imports System.Threading
Imports System.Net
Imports System.Diagnostics
Imports System.Runtime.InteropServices
Imports Microsoft.WindowsAPICodePack.Dialogs
Imports System.Globalization
Imports Leadtools.Demos
Imports Leadtools.DicomDemos
Imports Leadtools.Dicom.Scu.Queries
Imports DicomDemo.DicomDemo.Utils
Imports DicomDemo.DicomDemo.Authentication
Imports DicomDemo.DicomDemo.Dicom

Namespace DicomDemo
   Partial Class MainForm : Inherits Form
      Private _query As PatientRootQueryPatient = New PatientRootQueryPatient()
      Private _studyQuery As StudyRootQueryStudy = New StudyRootQueryStudy()

      Private _find As PatientUpdateQuery = Nothing

      ' Settings
      Public _mySettings As DicomDemoSettings = New DicomDemoSettings()
      Public _demoName As String = Path.GetFileName(Application.ExecutablePath)

      Private _patientSorter As ListViewColumnSorter = New ListViewColumnSorter()
      Private _seriesSorter As ListViewColumnSorter = New ListViewColumnSorter()
      Private _studies As List(Of Study) = New List(Of Study)()
      Private _CurrentPatient As Patient = Nothing
      Private _naction As NActionScu = Nothing
      Private _server As DicomScp = New DicomScp()

      Private Const defaultServerAE As String = "LEAD_SERVER"
      Private Const defaultServerIP As String = "127.0.0.1"
      Private Const defaultServerPort As Integer = 104
      Private Const defaultServerTimeout As Integer = 30
      Private Const defaultServerUseTls As Boolean = False

      Private Const defaultClientAE As String = "LEAD_CLIENT"
      Private Const defaultClientPort As Integer = 1000
      Private Function DefaultSettings() As DicomDemoSettings
         Dim settings As DicomDemoSettings = New DicomDemoSettings()
         settings.ClientAe.AE = defaultClientAE
         settings.ClientAe.Port = defaultServerPort
         Dim serverAE As DicomAE = New DicomAE()
         serverAE.AE = defaultServerAE
         serverAE.IPAddress = defaultServerIP
         serverAE.Port = defaultServerPort
         serverAE.Timeout = defaultServerTimeout
         serverAE.UseTls = defaultServerUseTls
         settings.ServerList.Add(serverAE)
         SetOtherDefaults(settings)
         Return settings
      End Function

      Public Sub New()
         InitializeComponent()
      End Sub

      Private Sub ExitButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles exitToolStripMenuItem.Click
         Close()
      End Sub

      Private Sub CreateFind()
         If Not _find Is Nothing Then
            _find.Dispose()
         End If

#If Not LEADTOOLS_V20_OR_LATER Then
         _find = New PatientUpdateQuery(_mySettings.TemporaryDirectory, DicomNetSecurityeMode.None, Nothing)
#Else
         _find = New PatientUpdateQuery(_mySettings.TemporaryDirectory, DicomNetSecurityMode.None, Nothing)
#End If ' #If Not LEADTOOLS_V20_OR_LATER Then

         _find.ImplementationClass = _mySettings.ImplementationClass
         _find.ProtocolVersion = _mySettings.ProtocolVersion
         _find.ImplementationVersionName = _mySettings.ImplementationVersionName
         _find.AETitle = _mySettings.ClientAe.AE

         AddHandler _find.BeforeConnect, AddressOf _find_BeforeConnect
         AddHandler _find.AfterConnect, AddressOf _find_AfterConnect
         AddHandler _find.BeforeAssociateRequest, AddressOf _find_BeforeAssociateRequest
         AddHandler _find.AfterAssociateRequest, AddressOf _find_AfterAssociateRequest
         AddHandler _find.BeforeCFind, AddressOf _find_BeforeCFind
         AddHandler _find.AfterCFind, AddressOf _find_AfterCFind

         CreateNAction()
      End Sub

      Private Sub CreateNAction()
         If Not _naction Is Nothing Then
            _naction.Dispose()
         End If

#If Not LEADTOOLS_V20_OR_LATER Then
         _naction = New NActionScu(_mySettings.TemporaryDirectory, DicomNetSecurityeMode.None, Nothing)
#Else
         _naction = New NActionScu(_mySettings.TemporaryDirectory, DicomNetSecurityMode.None, Nothing)
#End If ' #If Not LEADTOOLS_V20_OR_LATER Then

         _naction.ImplementationClass = _mySettings.ImplementationClass
         _naction.ProtocolVersion = _mySettings.ProtocolVersion
         _naction.ImplementationVersionName = _mySettings.ImplementationVersionName
         _naction.AETitle = _mySettings.ClientAe.AE

         AddHandler _naction.BeforeConnect, AddressOf _find_BeforeConnect
         AddHandler _naction.AfterConnect, AddressOf _find_AfterConnect
         AddHandler _naction.BeforeAssociateRequest, AddressOf _find_BeforeAssociateRequest
         AddHandler _naction.AfterAssociateRequest, AddressOf _find_AfterAssociateRequest
      End Sub

      Private Sub _find_BeforeConnect(ByVal sender As Object, ByVal e As BeforeConnectEventArgs)
      End Sub

      Private Sub _find_AfterConnect(ByVal sender As Object, ByVal e As AfterConnectEventArgs)
      End Sub


      Private Sub _find_BeforeAssociateRequest(ByVal sender As Object, ByVal e As BeforeAssociateRequestEventArgs)
      End Sub

      Private Sub _find_AfterAssociateRequest(ByVal sender As Object, ByVal e As AfterAssociateRequestEventArgs)
      End Sub

      Private Sub _find_BeforeCFind(ByVal sender As Object, ByVal e As BeforeCFindEventArgs)
      End Sub

      Private Sub _find_AfterCFind(ByVal sender As Object, ByVal e As AfterCFindEventArgs)
      End Sub

      Public Sub SynchronizedInvoke(ByVal del As MethodInvoker)
         If InvokeRequired Then
            Invoke(del, Nothing)
         Else
            del()
         End If
      End Sub

      Private Function GetPatientNameSearch() As String
         Dim last As String = String.Empty

         If textBoxPatientName.Text.Length = 0 Then
            Return String.Empty
         End If

         last = textBoxPatientName.Text.Substring(textBoxPatientName.Text.Length - 1)
         If last <> "*" Then
            Return textBoxPatientName.Text.Replace(","c, "^"c) & "*"
         End If

         Return textBoxPatientName.Text.Replace(","c, "^"c)
      End Function

      Private Sub SortPatientView()
         listViewPatients.Sort()
      End Sub

      Private Sub SortStudyView()
         listViewSeries.Sort()
      End Sub

      Private Sub Abort()
         If _find.IsAssociated() Then
            _find.AbortRequest(DicomAbortSourceType.User, DicomAbortReasonType.Unexpected)
         End If
      End Sub

      Private Sub AddPatientThreaded()
         Try
            _find.Find(Of PatientRootQueryPatient, Patient)(_server, _query, Function(p As Patient, ds As DicomDataSet) AddPatient(p))
            If _find.Rejected Then
               SynchronizedInvoke(Function() TaskDialogHelper.ShowMessageBox(Me, "No Records Found", "Association Failed", _find.Reason, "Modify options and try again.", TaskDialogStandardButtons.Ok, TaskDialogStandardIcon.Error, TaskDialogStandardIcon.Information))
            End If
         Catch e As Exception
            ApplicationUtils.ShowException(Me, e)
         End Try
      End Sub

      Private Function AddStudy(ByVal s As Study) As Boolean
         If InvokeRequired Then
            Invoke(New Action(Of Study)(AddressOf AddStudy), s)
         Else
            _studies.Add(s)
         End If
         Return True
      End Function

      Private Sub AddStudiesThreaded()
         Try
            _studies.Clear()
            Dim seriesQuery As StudyRootQuerySeries = New StudyRootQuerySeries()
            _find.Find(Of StudyRootQueryStudy, Study)(_server, _studyQuery, Function(s As Study, ds As DicomDataSet) AddStudy(s))

            For Each study As Study In _studies
               seriesQuery.Patient.PatientId = study.Patient.Id
               Dim studyUID As String = study.InstanceUID
               seriesQuery.Study.StudyInstanceUID = studyUID
               _find.Find(Of StudyRootQuerySeries, PatientUpdaterSeries)(_server, seriesQuery, Function(s As PatientUpdaterSeries, ds As DicomDataSet) AddSeries(s, studyUID))
            Next study
         Catch e As Exception
            ApplicationUtils.ShowException(Me, e)
         End Try

         SynchronizedInvoke(AddressOf SortStudyView)
      End Sub

      Private Sub DoSearch()
         Dim progress As ProgressDialog = New ProgressDialog()

         _query.PatientQuery.PatientId = textBoxPatientId.Text
         _query.PatientQuery.PatientName = GetPatientNameSearch()
         listViewSeries.BeginUpdate()
         listViewSeries.Items.Clear()
         listViewSeries.EndUpdate()
         listViewPatients.Items.Clear()
         _CurrentPatient = Nothing
         EditPatientButton.Enabled = False
         DeletePatientButton.Enabled = False
         EditSeriesButton.Enabled = False
         DeleteSeriesButton.Enabled = False

         Dim scp As DicomAE = _mySettings.GetServer(_mySettings.HighLevelStorageServer)
         If scp Is Nothing Then
            Return
         End If

         _server.AETitle = scp.AE
         _server.PeerAddress = IPAddress.Parse(scp.IPAddress)
         _server.Port = scp.Port
         _server.Timeout = scp.Timeout

         Dim thrd As Thread = New Thread(AddressOf AddPatientThreaded)

         SynchronizedInvoke(AddressOf SortPatientView)

         progress.Cancel = New Action(AddressOf Abort)

         progress.ActionThread = thrd
         progress.Title = "Finding Patients"
         progress.ProgressInfo = "Performing a patient search."
         progress.ShowDialog(Me)
      End Sub

      Private Sub GetPatientSeries(ByVal p As Patient)
         Dim progress As ProgressDialog = New ProgressDialog()

         _studyQuery.Patient.PatientId = p.Id
         'listViewSeries.BeginUpdate();
         listViewSeries.Items.Clear()
         Dim thrd As Thread = New Thread(AddressOf AddStudiesThreaded)
         progress.Cancel = New Action(AddressOf Abort)
         progress.ActionThread = thrd
         progress.Title = "Retrieving Patient Series"
         progress.ProgressInfo = "Performing a series search."
         progress.ShowDialog(Me)
         'listViewSeries.EndUpdate();
      End Sub

      Public Function AddPatient(ByVal p As Patient) As ListViewItem
         If InvokeRequired Then
            Return CType(Invoke(New Action(Of Patient)(AddressOf AddPatient), p), ListViewItem)
         Else
            Dim item As ListViewItem = New ListViewItem(p.Name.Full)

            item.SubItems.Add(p.Id)
            item.SubItems.Add(p.Sex)
            item.SubItems.Add(Program.DateString(p.BirthDate))
            item.Tag = p
            listViewPatients.Items.Add(item)
            Return item
         End If
      End Function

      Public Function AddSeries(ByVal s As PatientUpdaterSeries, ByVal studyInstanceUID As String) As ListViewItem
         If InvokeRequired Then
            Return CType(Invoke(New Action(Of PatientUpdaterSeries, String)(AddressOf AddSeries), s, studyInstanceUID), ListViewItem)
         Else
            Dim item As ListViewItem = New ListViewItem(s.Description)

            item.SubItems.Add(Program.DateString(s.Date))
            If s.Time.HasValue Then
               item.SubItems.Add(s.Time.Value.ToString("h:mm:ss.ff"))
            Else
               item.SubItems.Add(String.Empty)
            End If
            item.SubItems.Add(s.Modality)
            item.SubItems.Add(studyInstanceUID)
            item.Tag = s
            listViewSeries.Items.Add(item)
            Return item
         End If
      End Function

      Private Sub SetOtherDefaults(ByVal settings As DicomDemoSettings)
         settings.ClientCertificate = DicomDemoSettingsManager.GetClientCertificateFullPath()
         settings.ClientPrivateKey = DicomDemoSettingsManager.GetClientCertificateFullPath()
         settings.ClientPrivateKeyPassword = DicomDemoSettingsManager.GetClientCertificatePassword()

         settings.LogLowLevel = True
         settings.ShowHelpOnStart = True
      End Sub

      Private Sub LoadSettings()
         Try
            ' Settings are stored at:
            ' %USERPROFILE%\Local Settings\Application Data\<Company Name>\<appdomainname>_<eid>_<hash>\<verison>\user.config

            _mySettings = Nothing

            Try
               _mySettings = DicomDemoSettingsManager.LoadSettings(_demoName)
               If _mySettings Is Nothing Then
                  DicomDemoSettingsManager.RunPacsConfigDemo()
                  _mySettings = DicomDemoSettingsManager.LoadSettings(_demoName)
               End If
            Catch e1 As Exception
            End Try
            If _mySettings Is Nothing Then
               _mySettings = DefaultSettings()
            Else
               ' found settings -- set any necessary defaults 
               If (_mySettings.FirstRun AndAlso _mySettings.IsPreconfigured) Then
                  SetOtherDefaults(_mySettings)
               End If
            End If

            ' SetDefaultQueryServer();
            _mySettings.FirstRun = False
            DicomDemoSettingsManager.SaveSettings(_demoName, _mySettings)
         Catch ex As Exception
            System.Diagnostics.Debug.Assert(False, ex.Message)
         End Try
      End Sub

      Private Sub MainForm_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
         textBoxPatientId.Text = "*"

         LoadSettings()

         Dim scp As DicomAE = _mySettings.GetServer(_mySettings.HighLevelStorageServer)
         If scp Is Nothing Then
            Return
         End If

         ' _mySettings = MiUpdaterSettings.Load();
         If (Not String.IsNullOrEmpty(scp.IPAddress)) Then
            Dim ip As IPAddress = IPAddress.None

            If IPAddress.TryParse(scp.IPAddress, ip) Then
               _server.PeerAddress = ip
            End If
         End If
         listViewPatients.ListViewItemSorter = _patientSorter
         listViewSeries.ListViewItemSorter = _seriesSorter
         CreateFind()

         optionsToolStripMenuItem.Enabled = UserManager.User.IsAdmin()
      End Sub

      Private Sub MainForm_FormClosing(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles Me.FormClosing
         DicomDemoSettingsManager.SaveSettings(_demoName, _mySettings)
      End Sub

      Private Sub optionsToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles optionsToolStripMenuItem.Click
         Dim dlgOptions As OptionsDialog = New OptionsDialog()

         Dim scp As DicomAE = _mySettings.GetServer(_mySettings.HighLevelStorageServer)
         If scp Is Nothing Then
            Return
         End If

         dlgOptions.ServerAE = scp.AE
         dlgOptions.ServerPort = scp.Port
         dlgOptions.ServerIP = scp.IPAddress
         dlgOptions.ClientAE = _mySettings.ClientAe.AE
         dlgOptions.Timeout = scp.Timeout
         If dlgOptions.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK Then
            scp.AE = dlgOptions.ServerAE
            scp.Port = dlgOptions.ServerPort
            scp.IPAddress = IPAddress.Parse(dlgOptions.ServerIP).ToString()
            scp.Timeout = dlgOptions.Timeout
            _mySettings.HighLevelStorageServer = dlgOptions.ServerAE
            DicomDemoSettingsManager.SaveSettings(_demoName, _mySettings)
            CreateFind()
         End If
      End Sub

      Private Sub SearchButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles SearchButton.Click
         DoSearch()
      End Sub

      Private Sub listViewPatients_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles listViewPatients.SelectedIndexChanged
         EditPatientButton.Enabled = listViewPatients.SelectedItems.Count > 0 AndAlso UserManager.User.CanEdit()
         DeletePatientButton.Enabled = listViewPatients.SelectedItems.Count > 0 AndAlso UserManager.User.CanDelete()
         listViewSeries.SelectedItems.Clear()
         DeleteSeriesButton.Enabled = False
         EditSeriesButton.Enabled = False
         If listViewPatients.SelectedItems.Count > 0 Then
            Dim p As Patient = TryCast(listViewPatients.SelectedItems(0).Tag, Patient)

            If Not _CurrentPatient Is p Then
               GetPatientSeries(p)
               _CurrentPatient = p
            End If
         End If
      End Sub

      Private Sub listViewSeries_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles listViewSeries.SelectedIndexChanged
         DeleteSeriesButton.Enabled = listViewSeries.SelectedItems.Count > 0 AndAlso UserManager.User.CanDelete()
         EditSeriesButton.Enabled = listViewSeries.SelectedItems.Count > 0 AndAlso UserManager.User.CanEdit()
         If listViewSeries.SelectedItems.Count > 0 Then
            EditPatientButton.Enabled = False
            DeletePatientButton.Enabled = False
         End If
      End Sub

      Private Sub EditPatientButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles EditPatientButton.Click
         Dim p As Patient = TryCast(listViewPatients.SelectedItems(0).Tag, Patient)
         Dim dlgPatient As EditPatientDialog = New EditPatientDialog(_naction, _find, _server, p)

         If dlgPatient.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK Then
            '
            ' If there was a change action we need to update the current patient information
            '
            If dlgPatient.Action = ActionType.Change Then
               Dim item As ListViewItem = listViewPatients.SelectedItems(0)

               item.Tag = dlgPatient.Patient
               item.Text = dlgPatient.Patient.Name.Full
               item.SubItems(1).Text = dlgPatient.Patient.Id
               item.SubItems(2).Text = dlgPatient.Patient.Sex
               item.SubItems(3).Text = Program.DateString(dlgPatient.Patient.BirthDate)
            ElseIf dlgPatient.Action = ActionType.Merge Then
               DeletePatient(listViewPatients.SelectedItems(0))
            End If
         End If
      End Sub

      Private Sub Sort(ByVal listview As ListView, ByVal sorter As ListViewColumnSorter, ByVal e As ColumnClickEventArgs)
         sorter.ShowHeaderIcon(listview, sorter.SortColumn, SortOrder.None)
         If e.Column = sorter.SortColumn Then
            ' Reverse the current sort direction for this column.
            If sorter.Order = SortOrder.Ascending Then
               sorter.Order = SortOrder.Descending
            Else
               sorter.Order = SortOrder.Ascending
            End If
         Else
            ' Set the column number that is to be sorted; default to ascending.
            sorter.SortColumn = e.Column
            sorter.Order = SortOrder.Ascending
         End If
         listview.Sort()
         sorter.ShowHeaderIcon(listview, e.Column, sorter.Order)
      End Sub

      Private Sub listViewPatients_ColumnClick(ByVal sender As Object, ByVal e As ColumnClickEventArgs) Handles listViewPatients.ColumnClick
         Sort(TryCast(sender, ListView), _patientSorter, e)
      End Sub

      Private Sub listViewSeries_ColumnClick(ByVal sender As Object, ByVal e As ColumnClickEventArgs) Handles listViewSeries.ColumnClick
         Sort(TryCast(sender, ListView), _seriesSorter, e)
      End Sub

      Private Sub listViewPatients_Enter(ByVal sender As Object, ByVal e As EventArgs) Handles listViewPatients.Enter
         listViewPatients_SelectedIndexChanged(sender, EventArgs.Empty)
      End Sub

      Private Sub MainForm_Shown(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Shown
         textBoxPatientId.Focus()
      End Sub

      Private Sub EditSeriesButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles EditSeriesButton.Click
         Dim series As PatientUpdaterSeries = TryCast(listViewSeries.SelectedItems(0).Tag, PatientUpdaterSeries)
         Dim patient As Patient = TryCast(listViewPatients.SelectedItems(0).Tag, Patient)
         Dim studyinstance As String = listViewSeries.SelectedItems(0).SubItems(listViewSeries.SelectedItems(0).SubItems.Count - 1).Text
         Dim dlgSeries As EditSeriesDialog = New EditSeriesDialog(_naction, _find, _server, studyinstance, series, patient)

         If dlgSeries.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK Then
            If dlgSeries.Action = ActionType.Change Then
               Dim item As ListViewItem = listViewSeries.SelectedItems(0)

               item.Tag = dlgSeries.Series
               item.Text = dlgSeries.Series.Description
               item.SubItems(1).Text = Program.DateString(dlgSeries.Series.Date)
               item.SubItems(2).Text = dlgSeries.Series.Modality
            ElseIf dlgSeries.Action = ActionType.Merge Then
               DeleteSeries(listViewSeries.SelectedItems(0))
            ElseIf dlgSeries.Action <> ActionType.CopyStudy Then
               Dim item As ListViewItem = Nothing

               DeleteSeries(listViewSeries.SelectedItems(0))
               item = AddPatient(dlgSeries.Patient)
               item.Selected = True
               listViewPatients.Sort()
               listViewPatients.EnsureVisible(item.Index)
               listViewSeries.BeginUpdate()
               listViewSeries.Items.Clear()
               item = AddSeries(dlgSeries.Series, dlgSeries.StudyInstanceUID)
               item.Selected = True
               listViewSeries.EndUpdate()
            End If
         End If
      End Sub

      Private Sub DeletePatient(ByVal item As ListViewItem)
         listViewPatients.Items.Remove(item)
         listViewSeries.BeginUpdate()
         listViewSeries.Items.Clear()
         listViewSeries.EndUpdate()
      End Sub

      Private Sub DeleteSeries(ByVal item As ListViewItem)
         listViewSeries.Items.Remove(item)
         If listViewSeries.Items.Count = 0 Then
            DeletePatient(listViewPatients.SelectedItems(0))
         End If
      End Sub

      Private Sub DeletePatientButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles DeletePatientButton.Click
         Dim dlgReason As ReasonDialog = New ReasonDialog("Input Reason For Deleting Patient")

         If dlgReason.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK Then
            Dim progress As ProgressDialog = New ProgressDialog()
            Dim patient As Patient = TryCast(listViewPatients.SelectedItems(0).Tag, Patient)
            Dim delPatient As DeletePatient = New DeletePatient()
            Dim status As DicomCommandStatusType = DicomCommandStatusType.Success

            delPatient.Reason = dlgReason.Reason
            If Environment.UserName <> String.Empty Then
               delPatient.Operator = Environment.UserName
            Else
               delPatient.Operator = Environment.MachineName
            End If
            delPatient.Station = Environment.MachineName
            delPatient.PatientId = patient.Id
            delPatient.Description = "Patient Delete"

            Try
               Dim sThreaded As ThreadedClass = New ThreadedClass(_naction, _server, NActionScu.DeletePatient, NActionScu.PatientUpdateInstance)
               sThreaded.DelPatient = delPatient
               Dim thrd As Thread = New Thread(AddressOf sThreaded.SendNActionRequest)

               progress.ActionThread = thrd
               progress.Title = "Deleting Patient: " & patient.Name.Full
               progress.ProgressInfo = "Performing patient delete."
               progress.ShowDialog(Me)

               status = sThreaded.Status
            Catch ex As Exception
               ApplicationUtils.ShowException(Me, ex)
            End Try

            If status = DicomCommandStatusType.Success Then
               '
               ' Remove the deleted patient from the list
               '
               DeletePatient(listViewPatients.SelectedItems(0))
            Else
               If status = DicomCommandStatusType.UnrecognizedOperation Then
                  TaskDialogHelper.ShowMessageBox(Me, "Error Deleting Patient", "Check Server Permissions", "There was an error deleting the patient. " & "This is usually caused by invalid AE permissions.", String.Empty, TaskDialogStandardButtons.Ok, TaskDialogStandardIcon.Error, Nothing)
               Else
                  TaskDialogHelper.ShowMessageBox(Me, "Error Deleting Patient", "Check Server Log", "There was an error deleting the patient. " & String.Format("The server return the following error: {0}.", status), String.Empty, TaskDialogStandardButtons.Ok, TaskDialogStandardIcon.Error, Nothing)
               End If
            End If
         End If
      End Sub

      Private Sub DeleteSeriesButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles DeleteSeriesButton.Click
         Dim dlgReason As ReasonDialog = New ReasonDialog("Input Reason For Deleting Series")

         If dlgReason.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK Then
            Dim series As Series = TryCast(listViewSeries.SelectedItems(0).Tag, Series)
            Dim delSeries As DeleteSeries = New DeleteSeries()
            Dim status As DicomCommandStatusType = DicomCommandStatusType.Success

            delSeries.Reason = dlgReason.Reason
            If Environment.UserName <> String.Empty Then
               delSeries.Operator = Environment.UserName
            Else
               delSeries.Operator = Environment.MachineName
            End If
            delSeries.Description = "Series Delete"
            delSeries.StudyInstanceUID = listViewSeries.SelectedItems(0).SubItems(listViewSeries.SelectedItems(0).SubItems.Count - 1).Text
            delSeries.SeriesInstanceUID = series.InstanceUID

            status = _naction.SendNActionRequest(Of DeleteSeries)(_server, delSeries, NActionScu.DeleteSeries, NActionScu.PatientUpdateInstance)
            If status = DicomCommandStatusType.Success Then
               DeleteSeries(listViewSeries.SelectedItems(0))
            Else
               If status = DicomCommandStatusType.UnrecognizedOperation Then
                  TaskDialogHelper.ShowMessageBox(Me, "Error Deleting Series", "Check Server Permissions", "There was an error deleting the series. " & "This is usually caused by invalid AE permissions.", String.Empty, TaskDialogStandardButtons.Ok, TaskDialogStandardIcon.Error, Nothing)
               Else
                  TaskDialogHelper.ShowMessageBox(Me, "Error Deleting Series", "Check Server Log", "There was an error deleting the series. " & String.Format("The server return the following error: {0}.", status), String.Empty, TaskDialogStandardButtons.Ok, TaskDialogStandardIcon.Error, Nothing)
               End If
            End If
         End If
      End Sub

      Private Sub Search_Changed(ByVal sender As Object, ByVal e As EventArgs) Handles textBoxPatientId.TextChanged, textBoxPatientName.TextChanged
         SearchButton.Enabled = textBoxPatientId.Text.Length > 0 OrElse textBoxPatientName.Text.Length > 0
      End Sub

      Private Sub Search_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles textBoxPatientId.KeyDown, textBoxPatientName.KeyDown
         If e.KeyCode = Keys.Enter Then
            If SearchButton.Enabled Then
               e.Handled = True
               SearchButton_Click(SearchButton, EventArgs.Empty)
            End If
         End If
      End Sub

      Private Sub textBoxPatientName_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles textBoxPatientName.KeyPress
         If Char.IsLetter(e.KeyChar) Then
            e.KeyChar = Char.ToUpper(e.KeyChar)
         End If
      End Sub

      Private Sub aboutToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles aboutToolStripMenuItem.Click
         Dim dlg As AboutDialog = New AboutDialog("DICOM High Level Patient Updater")

         dlg.ShowDialog(Me)
      End Sub
   End Class

   Class ThreadedClass
      Private _naction As NActionScu
      Private _scp As DicomScp
      Private _action As Integer
      Private _patientUpdateInstance As String
      Private _status As DicomCommandStatusType
      Private _mergePatient As MergePatient
      Private _delPatient As DeletePatient
      Private _moveToNewPationt As MoveToNewPatient
      Private _mergeStudy As MergeStudy
      Private _copyStudy As CopyStudy
      Private _changeSeries As ChangeSeries

      Public ReadOnly Property Status() As DicomCommandStatusType
         Get
            Return _status
         End Get
      End Property

      Public Property MrgPatient() As MergePatient
         Get
            Return _mergePatient
         End Get
         Set(ByVal value As MergePatient)
            _mergePatient = value
         End Set
      End Property

      Public Property DelPatient() As DeletePatient
         Get
            Return _delPatient
         End Get
         Set(ByVal value As DeletePatient)
            _delPatient = value
         End Set
      End Property

      Public Property MoveToNewPatient() As MoveToNewPatient
         Get
            Return _moveToNewPationt
         End Get
         Set(ByVal value As MoveToNewPatient)
            _moveToNewPationt = value
         End Set
      End Property

      Public Property MrgStudy() As MergeStudy
         Get
            Return _mergeStudy
         End Get
         Set(ByVal value As MergeStudy)
            _mergeStudy = value
         End Set
      End Property

      Public Property CopyStudy() As CopyStudy
         Get
            Return _copyStudy
         End Get
         Set(ByVal value As CopyStudy)
            _copyStudy = value
         End Set
      End Property

      Public Property ChangeSeries() As ChangeSeries
         Get
            Return _changeSeries
         End Get
         Set(ByVal value As ChangeSeries)
            _changeSeries = value
         End Set
      End Property

      Public Sub New(ByRef naction As NActionScu, ByRef scp As DicomScp, ByVal action As Integer, ByVal patientUpdateInstance As String)
         _naction = naction
         _scp = scp
         _action = action
         _patientUpdateInstance = patientUpdateInstance
      End Sub

      Public Sub SendNActionRequest()
         Select Case _action
            Case NActionScu.ChangeSeries
               _status = _naction.SendNActionRequest(Of ChangeSeries)(_scp, _changeSeries, _action, _patientUpdateInstance)
               Exit Select
            Case NActionScu.CopyStudy
               _status = _naction.SendNActionRequest(Of CopyStudy)(_scp, _copyStudy, _action, _patientUpdateInstance)
               Exit Select
            Case NActionScu.DeletePatient
               _status = _naction.SendNActionRequest(Of DeletePatient)(_scp, _delPatient, _action, _patientUpdateInstance)
               Exit Select
            Case NActionScu.MergePatient
               _status = _naction.SendNActionRequest(Of MergePatient)(_scp, _mergePatient, _action, _patientUpdateInstance)
               Exit Select
            Case NActionScu.MergeStudy
               _status = _naction.SendNActionRequest(Of MergeStudy)(_scp, _mergeStudy, _action, _patientUpdateInstance)
               Exit Select
            Case NActionScu.MoveStudyToNewPatient
               _status = _naction.SendNActionRequest(Of MoveToNewPatient)(_scp, _moveToNewPationt, _action, _patientUpdateInstance)
               Exit Select
         End Select
      End Sub
   End Class

End Namespace

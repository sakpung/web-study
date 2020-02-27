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
Imports System.Linq
Imports System.Text
Imports System.Windows.Forms
Imports System.Threading
Imports Microsoft.WindowsAPICodePack.Dialogs
Imports Leadtools.Dicom
Imports Leadtools.Dicom.Scu
Imports Leadtools.Dicom.Scu.Queries
Imports DicomDemo.DicomDemo.Utils
Imports DicomDemo.DicomDemo.Dicom
Imports DicomDemo.My

Namespace DicomDemo
   Partial Class EditSeriesDialog : Inherits Form
      Private _naction As NActionScu = Nothing
      Private _scp As DicomScp = Nothing
      Private _find As QueryRetrieveScu = Nothing
      Private _FocusManager As FocusManager

      Private _Series As PatientUpdaterSeries = Nothing

      Public ReadOnly Property Series() As PatientUpdaterSeries
         Get
            Return _Series
         End Get
      End Property

      Private _Action As ActionType = ActionType.None

      Public ReadOnly Property Action() As ActionType
         Get
            Return _Action
         End Get
      End Property

      Private _Patient As Patient = Nothing

      Public ReadOnly Property Patient() As Patient
         Get
            Return _Patient
         End Get
      End Property

      Private _StudyInstanceUID As String = String.Empty

      Public ReadOnly Property StudyInstanceUID() As String
         Get
            Return _StudyInstanceUID
         End Get
      End Property

      Public Sub New(ByVal naction As NActionScu, ByVal find As QueryRetrieveScu, ByVal scp As DicomScp, ByVal studyInstanceUID As String, ByVal series As PatientUpdaterSeries, ByVal patient As Patient)
         InitializeComponent()
         _Series = series
         _Patient = patient
         _naction = naction
         _scp = scp
         _find = find
         _StudyInstanceUID = studyInstanceUID
         InitializeModalities()
      End Sub

      Private Sub InitializeModalities()
         Dim modalities As String() = Settings.Default.Modalities.Split(New String() {","}, StringSplitOptions.RemoveEmptyEntries)

         comboBoxModality.Items.AddRange(modalities)
      End Sub

      Private Sub SetPatientInfo()
         PatientId.Text = _Patient.Id
         LastName.Text = _Patient.Name.Family
         FirstName.Text = _Patient.Name.Given
         Sex.Text = _Patient.Sex
         DateOfBirth.Text = Program.DateString(_Patient.BirthDate)

         textBoxId.Text = _Patient.Id
         textBoxLastname.Text = _Patient.Name.Family
         textBoxFirstname.Text = _Patient.Name.Given
         If String.IsNullOrEmpty(_Patient.Sex) Then
            comboBoxSex.Text = String.Empty
         Else
            comboBoxSex.SelectedIndex = comboBoxSex.FindStringExact(_Patient.Sex)
         End If
         If _Patient.BirthDate.HasValue Then
            dateTimePickerBirth.Value = _Patient.BirthDate.Value
            dateTimePickerBirth.Checked = True
         Else
            dateTimePickerBirth.Checked = False
         End If
      End Sub

      Private Sub SetSeriesInfo()
         SeriesDate.Text = Program.DateString(_Series.Date)
         If _Series.Time.HasValue Then
            SeriesTime.Text = _Series.Time.Value.ToString("h:mm:ss.ff")
         Else
            SeriesTime.Text = String.Empty
         End If
         SeriesDescription.Text = _Series.Description
         SeriesModality.Text = _Series.Modality

         If _Series.Date.HasValue Then
            dateTimePickerSeriesDate.Value = _Series.Date.Value
            dateTimePickerSeriesDate.Checked = True
         Else
            dateTimePickerSeriesDate.Checked = False
         End If

         textBoxDescription.Text = _Series.Description
         comboBoxModality.Text = _Series.Modality
      End Sub

      Private Sub SetMode()
         If radioButtonChange.Checked Then
            textBoxId.Width = textBoxLastname.Width
            ActionButton.Enabled = True
         Else
            textBoxId.Width = Convert.ToInt32(textBoxLastname.Width * 0.65)
            If radioButtonMerge.Checked Then
               textBoxId_TextChanged(Nothing, EventArgs.Empty)
               ActionButton.Enabled = False
            End If
         End If

         textBoxId.Enabled = Not radioButtonChange.Checked
         SearchButton.Visible = radioButtonMerge.Checked Or radioButtonMove.Checked
         textBoxLastname.Enabled = radioButtonMove.Checked
         textBoxFirstname.Enabled = radioButtonMove.Checked
         comboBoxSex.Enabled = radioButtonMove.Checked
         dateTimePickerBirth.Enabled = radioButtonMove.Checked
         dateTimePickerSeriesDate.Enabled = radioButtonChange.Checked
         textBoxDescription.Enabled = radioButtonChange.Checked
         comboBoxModality.Enabled = radioButtonChange.Checked

         If radioButtonChange.Checked Then
            ActionButton.Text = "Change"
         Else
            ActionButton.Text = "Move"
         End If
         CopyButton.Enabled = textBoxId.Text.Length > 0 AndAlso textBoxId.Text <> _Patient.Id AndAlso Not radioButtonChange.Checked
      End Sub

      Private Sub EditSeriesDialog_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
         SetPatientInfo()
         SetSeriesInfo()
         SetMode()
         _FocusManager = New FocusManager(textBoxId, textBoxLastname, textBoxFirstname, comboBoxSex, dateTimePickerBirth, dateTimePickerSeriesDate, textBoxDescription, comboBoxModality)
      End Sub

      Private Sub ModeChanged(ByVal sender As Object, ByVal e As EventArgs) Handles radioButtonMove.CheckedChanged, radioButtonMerge.CheckedChanged, radioButtonChange.CheckedChanged
         SetMode()
      End Sub

      Private Sub ActionButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ActionButton.Click
         If radioButtonChange.Checked Then
            ChangeSeries()
         ElseIf radioButtonMerge.Checked Then
            MergeStudy()
         Else
            MoveToNewPatient()
         End If
      End Sub

      Private Sub ChangeSeries()
         Dim dlgReason As ReasonDialog = New ReasonDialog("Input Reason For Changing Series")

         If dlgReason.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK Then
            Dim change As ChangeSeries = New ChangeSeries()
            Dim status As DicomCommandStatusType = DicomCommandStatusType.Success
            Dim progress As ProgressDialog = New ProgressDialog()

            change.SeriesInstanceUID = _Series.InstanceUID
            If Environment.UserName <> String.Empty Then
               change.Operator = Environment.UserName
            Else
               change.Operator = Environment.MachineName
            End If
            change.Reason = dlgReason.Reason
            change.Description = "Change Series"
            change.Modality = comboBoxModality.Text
            change.SeriesDescription = textBoxDescription.Text.Replace("\", "\\").Replace("'", "''")
            If dateTimePickerSeriesDate.Checked Then
               change.SeriesDate = dateTimePickerSeriesDate.Value
            Else
               change.SeriesDate = Nothing
            End If

            Try
               Dim sThreaded As ThreadedClass = New ThreadedClass(_naction, _scp, NActionScu.ChangeSeries, NActionScu.PatientUpdateInstance)
               sThreaded.ChangeSeries = change
               Dim thrd As Thread = New Thread(AddressOf sThreaded.SendNActionRequest)

               progress.ActionThread = thrd
               progress.Title = "Changing Series"
               progress.ProgressInfo = "Performing series change."
               progress.ShowDialog(Me)

               status = sThreaded.Status
            Catch e As Exception
               ApplicationUtils.ShowException(Me, e)
               status = DicomCommandStatusType.Failure
            End Try

            If status = DicomCommandStatusType.Success Then
               _Series.Modality = comboBoxModality.Text
               _Series.Description = textBoxDescription.Text
               If dateTimePickerSeriesDate.Checked Then
                  _Series.Date = dateTimePickerSeriesDate.Value
               Else
                  _Series.Date = Nothing
               End If
               _Action = ActionType.Change
               TaskDialogHelper.ShowMessageBox(Me, "Series Changed", "The series has been successfully changed.", String.Empty, String.Empty, TaskDialogStandardButtons.Close, TaskDialogStandardIcon.Information, Nothing)
               DialogResult = System.Windows.Forms.DialogResult.OK
            Else
               Dim message As String = "The series was not changed." & Constants.vbCrLf & "Error - " & status

               If status = DicomCommandStatusType.MissingAttribute Then
                  message = "The series was not changed." & Constants.vbCrLf & "Series not found on server."
               End If

               TaskDialogHelper.ShowMessageBox(Me, "Change Series Error", "The series was not changed.", message, String.Empty, TaskDialogStandardButtons.Close, TaskDialogStandardIcon.Information, Nothing)
            End If
         End If
      End Sub

      Private Sub MergeStudy()
         Dim dlgReason As ReasonDialog = New ReasonDialog("Input Reason For Merging Study")

         If dlgReason.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK Then
            Dim merge As MergeStudy = New MergeStudy()
            Dim status As DicomCommandStatusType = DicomCommandStatusType.Success
            Dim progress As ProgressDialog = New ProgressDialog()

            merge.PatientId = textBoxId.Text.Replace("\", "\\").Replace("'", "''")
            merge.PatientToMerge.Add(New MergePatientSequence(_Patient.Id))
            merge.StudyInstanceUID = _StudyInstanceUID
            merge.Reason = dlgReason.Reason
            If Environment.UserName <> String.Empty Then
               merge.Operator = Environment.UserName
            Else
               merge.Operator = Environment.MachineName
            End If
            merge.Description = "Merge Study"

            Try
               Dim sThreaded As ThreadedClass = New ThreadedClass(_naction, _scp, NActionScu.MergeStudy, NActionScu.PatientUpdateInstance)
               sThreaded.MrgStudy = merge
               Dim thrd As Thread = New Thread(AddressOf sThreaded.SendNActionRequest)

               progress.ActionThread = thrd
               progress.Title = "Merging Study"
               progress.ProgressInfo = "Performing study merge to patient: " & textBoxFirstname.Text & " " & textBoxLastname.Text & "."
               progress.ShowDialog(Me)

               status = sThreaded.Status
            Catch e As Exception
               ApplicationUtils.ShowException(Me, e)
               status = DicomCommandStatusType.Failure
            End Try

            If status = DicomCommandStatusType.Success Then
               _Action = ActionType.Merge
               TaskDialogHelper.ShowMessageBox(Me, "Study Merge", "The study has been successfully merged.", GetMergeInfo(), String.Empty, TaskDialogStandardButtons.Close, TaskDialogStandardIcon.Information, Nothing)
               DialogResult = System.Windows.Forms.DialogResult.OK
            Else
               Dim message As String = "The study was not merged." & Constants.vbCrLf & "Error - " & status

               If status = DicomCommandStatusType.MissingAttribute Then
                  message = "The study was not merged." & Constants.vbCrLf & "Study not found on server."
               End If

               TaskDialogHelper.ShowMessageBox(Me, "Merge Study Error", "The study was not merged.", message, String.Empty, TaskDialogStandardButtons.Close, TaskDialogStandardIcon.Information, Nothing)
            End If
         End If
      End Sub

      Private Sub MoveToNewPatient()
         Dim dlgReason As New ReasonDialog("Input Reason For Moving Study To New Patient")

         If dlgReason.ShowDialog(Me) = DialogResult.OK Then
            Dim move As New MoveToNewPatient()
            Dim status As DicomCommandStatusType = DicomCommandStatusType.Success
            Dim progress As New ProgressDialog()

            move.PatientId = textBoxId.Text.Replace("\", "\\").Replace("'", "''")
            move.Name.Given = textBoxFirstname.Text.Replace("\", "\\").Replace("'", "''")
            move.Name.Family = textBoxLastname.Text.Replace("\", "\\").Replace("'", "''")
            move.Sex = comboBoxSex.Text
            move.PatientToMerge.Add(New MergePatientSequence(_Patient.Id))
            If dateTimePickerBirth.Checked Then
               move.Birthdate = dateTimePickerBirth.Value
            Else
               move.Birthdate = Nothing
            End If
            move.StudyInstanceUID = _StudyInstanceUID
            move.Reason = dlgReason.Reason
            move.[Operator] = If(Environment.UserName <> String.Empty, Environment.UserName, Environment.MachineName)
            move.Description = "Move Study To New Patient"

            Try
               Dim sThreaded As ThreadedClass = New ThreadedClass(_naction, _scp, NActionScu.MoveStudyToNewPatient, NActionScu.PatientUpdateInstance)
               sThreaded.MoveToNewPatient = move
               Dim thrd As Thread = New Thread(AddressOf sThreaded.SendNActionRequest)

               progress.ActionThread = thrd
               progress.Title = "Moving Study To New Patient"
               progress.ProgressInfo = ("Performing study move to patient: " + textBoxFirstname.Text & " ") + textBoxLastname.Text & "."
               progress.ShowDialog(Me)

               status = sThreaded.Status
            Catch e As Exception
               ApplicationUtils.ShowException(Me, e)
               status = DicomCommandStatusType.Failure
            End Try

            If status = DicomCommandStatusType.Success Then
               _Patient.Id = textBoxId.Text
               _Patient.Name.Given = textBoxFirstname.Text
               _Patient.Name.Family = textBoxLastname.Text
               _Patient.Sex = comboBoxSex.Text
               If dateTimePickerBirth.Checked Then
                  _Patient.BirthDate = dateTimePickerBirth.Value
               Else
                  _Patient.BirthDate = Nothing
               End If
               _Action = ActionType.Move
               TaskDialogHelper.ShowMessageBox(Me, "Study Moved To New Patient", "The study has been successfully moved.", String.Empty, String.Empty, TaskDialogStandardButtons.Close, _
                TaskDialogStandardIcon.Information, Nothing)
               DialogResult = DialogResult.OK
            Else
               Dim message As String = "The series was not moved." & vbCr & vbLf & "Error - " & status

               If status = DicomCommandStatusType.MissingAttribute Then
                  message = "The series was not moved." & vbCr & vbLf & "Series not found on server."
               End If

               TaskDialogHelper.ShowMessageBox(Me, "Move Series Error", "The series was not moved.", message, String.Empty, TaskDialogStandardButtons.Close, _
                TaskDialogStandardIcon.Information, Nothing)
            End If
         End If
      End Sub
      Private Sub CopyStudy()
         Dim dlgReason As ReasonDialog = New ReasonDialog("Input Reason For Copying Study")

         If dlgReason.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK Then
            Dim move As CopyStudy = New CopyStudy()
            Dim status As DicomCommandStatusType = DicomCommandStatusType.Success
            Dim progress As ProgressDialog = New ProgressDialog()

            move.PatientId = textBoxId.Text.Replace("\", "\\").Replace("'", "''")
            move.Name.Given = textBoxFirstname.Text.Replace("\", "\\").Replace("'", "''")
            move.Name.Family = textBoxLastname.Text.Replace("\", "\\").Replace("'", "''")
            move.Sex = comboBoxSex.Text
            move.PatientToMerge.Add(New MergePatientSequence(_Patient.Id))
            If dateTimePickerBirth.Checked Then
               move.Birthdate = dateTimePickerBirth.Value
            Else
               move.Birthdate = Nothing
            End If
            move.StudyInstanceUID = _StudyInstanceUID
            move.Reason = dlgReason.Reason
            If Environment.UserName <> String.Empty Then
               move.Operator = Environment.UserName
            Else
               move.Operator = Environment.MachineName
            End If
            move.Description = "Copy Study"

            Try
               Dim sThreaded As ThreadedClass = New ThreadedClass(_naction, _scp, NActionScu.CopyStudy, NActionScu.PatientUpdateInstance)
               sThreaded.CopyStudy = move
               Dim thrd As Thread = New Thread(AddressOf sThreaded.SendNActionRequest)

               progress.ActionThread = thrd
               progress.Title = "Copying Study"
               progress.ProgressInfo = "Performing study copy: " & textBoxFirstname.Text & " " & textBoxLastname.Text & "."
               progress.ShowDialog(Me)

               status = sThreaded.Status
            Catch e As Exception
               ApplicationUtils.ShowException(Me, e)
               status = DicomCommandStatusType.Failure
            End Try

            If status = DicomCommandStatusType.Success Then
               _Action = ActionType.CopyStudy
               TaskDialogHelper.ShowMessageBox(Me, "Study Copied", "The study has been successfully copied.", String.Empty, String.Empty, TaskDialogStandardButtons.Close, TaskDialogStandardIcon.Information, Nothing)
               DialogResult = System.Windows.Forms.DialogResult.OK
            Else
               Dim message As String = "The series was not copied." & Constants.vbCrLf & "Error - " & status

               If status = DicomCommandStatusType.MissingAttribute Then
                  message = "The series was not copied." & Constants.vbCrLf & "Series not found on server."
               End If

               TaskDialogHelper.ShowMessageBox(Me, "Copy Series Error", "The series was not copied.", message, String.Empty, TaskDialogStandardButtons.Close, TaskDialogStandardIcon.Information, Nothing)
            End If
         End If
      End Sub

      Private Function GetMergeInfo() As String
         Dim info As String = String.Empty

         info = String.Format("The study has been moved to patient {0}({1})", textBoxFirstname.Text & " " & textBoxLastname.Text, textBoxId.Text)
         Return info
      End Function

      Private Sub SearchButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles SearchButton.Click
         Dim foundPatient As Patient = DicomUtils.FindPatient(Me, _find, _scp, textBoxId.Text)

         If (Not radioButtonMove.Checked) Then
            If Not foundPatient Is Nothing Then
               textBoxLastname.Text = foundPatient.Name.Family
               textBoxFirstname.Text = foundPatient.Name.Given
               If String.IsNullOrEmpty(foundPatient.Sex) Then
                  comboBoxSex.Text = String.Empty
               Else
                  comboBoxSex.SelectedIndex = comboBoxSex.FindStringExact(foundPatient.Sex)
               End If
               If foundPatient.BirthDate.HasValue Then
                  dateTimePickerBirth.Value = foundPatient.BirthDate.Value
                  dateTimePickerBirth.Checked = True
               Else
                  dateTimePickerBirth.Checked = False
               End If
            Else
               TaskDialogHelper.ShowMessageBox(Me, "Patient Search", "Patient with specified id was not found.", String.Empty, String.Empty, TaskDialogStandardButtons.Close, TaskDialogStandardIcon.Information, Nothing)
            End If
            ActionButton.Enabled = Not foundPatient Is Nothing
         Else
            If Not foundPatient Is Nothing Then
               Dim result As TaskDialogResult = TaskDialogResult.Yes

               result = TaskDialogHelper.ShowMessageBox(Me, "Patient Id Already Exits", "Would you like to merge the study with existing patient?", "The patient id already exisits.", "Existing Patient: " & foundPatient.Name.Full, TaskDialogStandardButtons.Yes Or TaskDialogStandardButtons.No, TaskDialogStandardIcon.Error, TaskDialogStandardIcon.Warning)
               If result = TaskDialogResult.Yes Then
                  radioButtonMerge.Checked = True
                  textBoxLastname.Text = foundPatient.Name.Family
                  textBoxFirstname.Text = foundPatient.Name.Given
                  If String.IsNullOrEmpty(foundPatient.Sex) Then
                     comboBoxSex.Text = String.Empty
                  Else
                     comboBoxSex.SelectedIndex = comboBoxSex.FindStringExact(foundPatient.Sex)
                  End If
                  If foundPatient.BirthDate.HasValue Then
                     dateTimePickerBirth.Value = foundPatient.BirthDate.Value
                     dateTimePickerBirth.Checked = True
                  Else
                     dateTimePickerBirth.Checked = False
                  End If
                  ActionButton.Enabled = True
               Else
                  ActionButton.Enabled = False
               End If
            Else
               ActionButton.Enabled = True
            End If
         End If

         CopyButton.Enabled = ActionButton.Enabled
      End Sub

      Private Sub textBoxId_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles textBoxId.TextChanged
         If radioButtonMerge.Checked OrElse radioButtonMove.Checked Then
            SearchButton.Enabled = textBoxId.Text.Length > 0 AndAlso textBoxId.Text <> _Patient.Id
            ActionButton.Enabled = False
         End If
      End Sub

      Private Sub EditSeriesDialog_Shown(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Shown
         dateTimePickerSeriesDate.Focus()
      End Sub

      Private Sub comboBoxModality_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles comboBoxModality.KeyPress
         If Char.IsLetterOrDigit(e.KeyChar) Then
            e.Handled = comboBoxModality.Text.Length = 16
            If (Not e.Handled) Then
               e.KeyChar = Char.ToUpper(e.KeyChar)
            End If
         End If
      End Sub

      Private Sub Uppercase_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles textBoxFirstname.KeyPress, textBoxLastname.KeyPress
         If Char.IsLetter(e.KeyChar) Then
            e.KeyChar = Char.ToUpper(e.KeyChar)
         End If
      End Sub

      Private Sub textBoxId_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles textBoxId.KeyPress
         If e.KeyChar = "*"c Then
            e.Handled = True
         End If
      End Sub

      Private Sub CopyButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles CopyButton.Click
         CopyStudy()
      End Sub
   End Class
End Namespace

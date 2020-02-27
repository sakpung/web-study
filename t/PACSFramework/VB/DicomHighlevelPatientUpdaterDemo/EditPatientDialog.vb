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
Imports Leadtools.Dicom.Scu
Imports Leadtools.Dicom.Scu.Queries
Imports Leadtools.Dicom
Imports DicomDemo.DicomDemo.Dicom
Imports DicomDemo.DicomDemo.Utils
Imports Leadtools.Dicom.Common.DataTypes

Namespace DicomDemo
    Partial Class EditPatientDialog : Inherits Form
        Private _naction As NActionScu = Nothing
        Private _find As QueryRetrieveScu = Nothing
        Private _scp As DicomScp
        Private _FocusManager As FocusManager
        Private _Patient As Patient = Nothing

        Private errorProvider As ErrorProvider

        Public Property Patient() As Patient
            Get
                Return _Patient
            End Get
            Set(ByVal value As Patient)
                _Patient = value
            End Set
        End Property

        Private _Action As ActionType = ActionType.None

        Public Property Action() As ActionType
            Get
                Return _Action
            End Get
            Set(ByVal value As ActionType)
                _Action = value
            End Set
        End Property

        Public Sub New(ByVal naction As NActionScu, ByVal find As QueryRetrieveScu, ByVal scp As DicomScp, ByVal patient As Patient)
            InitializeComponent()
            _Patient = patient
            _naction = naction
            _find = find
            _scp = scp

            errorProvider = New ErrorProvider(Me)
            errorProvider.SetIconAlignment(textBoxLastname, ErrorIconAlignment.TopLeft)
            errorProvider.SetIconAlignment(textBoxId, ErrorIconAlignment.TopLeft)
        End Sub

        Private Sub EditPatientDialog_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
            SetPatientInfo()
            SetMode(False)
            _FocusManager = New FocusManager(textBoxId, textBoxLastname, textBoxFirstname, comboBoxSex, dateTimePickerBirth)
            VerifyPatientSettings()

            AddHandler textBoxId.TextChanged, AddressOf TextBoxId_TextChanged
            AddHandler textBoxOtherPid.TextChanged, AddressOf TextBoxOtherPid_TextChanged
            AddHandler textBoxLastname.TextChanged, AddressOf TextBoxLastname_TextChanged
            AddHandler textBoxFirstname.TextChanged, AddressOf TextBoxFirstname_TextChanged

            AddHandler textBoxId.KeyPress, AddressOf textBoxId_KeyPress
            AddHandler textBoxLastname.KeyPress, AddressOf UpperCase_KeyPress
            AddHandler textBoxFirstname.KeyPress, AddressOf UpperCase_KeyPress

            AddHandler radioButtonMerge.CheckedChanged, AddressOf RadioButtonMerge_CheckedChanged
        End Sub

        Private Sub RadioButtonMerge_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs)
            Dim isError As Boolean = VerifyPatientSettings()
            SetMode(isError)
        End Sub

        Private Sub TextBoxId_TextChanged(ByVal sender As Object, ByVal e As EventArgs)
            VerifyPatientSettings()
        End Sub

        Private Sub TextBoxOtherPid_TextChanged(ByVal sender As Object, ByVal e As EventArgs)
            VerifyPatientSettings()
        End Sub

        Private Sub TextBoxFirstname_TextChanged(ByVal sender As Object, ByVal e As EventArgs)
            VerifyPatientSettings()
        End Sub

        Private Sub TextBoxLastname_TextChanged(ByVal sender As Object, ByVal e As EventArgs)
            VerifyPatientSettings()
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
            comboBoxSex.SelectedIndex = comboBoxSex.FindStringExact(_Patient.Sex)
            If _Patient.BirthDate.HasValue Then
                dateTimePickerBirth.Value = _Patient.BirthDate.Value
                dateTimePickerBirth.Checked = True
            Else
                dateTimePickerBirth.Checked = False
            End If

            If Program.OtherPID.ContainsKey(_Patient.Id) Then
                OtherPatientIds.Text = Program.OtherPID(_Patient.Id)
                textBoxOtherPid.Text = Program.OtherPID(_Patient.Id)
            Else
                OtherPatientIds.Text = String.Empty
                textBoxOtherPid.Text = String.Empty
            End If

            radioButtonChange.Checked = True
        End Sub

        Private Sub SetMode(ByVal isError As Boolean)
            If radioButtonChange.Checked Then
                textBoxId.Width = textBoxLastname.Width
            Else
                textBoxId.Width = Convert.ToInt32(textBoxLastname.Width * 0.65)
                TextBoxId_TextChanged(Nothing, EventArgs.Empty)
            End If

            SearchButton.Visible = radioButtonMerge.Checked
            textBoxOtherPid.Enabled = radioButtonChange.Checked
            textBoxLastname.Enabled = radioButtonChange.Checked
            textBoxFirstname.Enabled = radioButtonChange.Checked
            comboBoxSex.Enabled = radioButtonChange.Checked
            dateTimePickerBirth.Enabled = radioButtonChange.Checked

            ActionButton.Text = If(radioButtonChange.Checked, "Change", "Merge")
            ActionButton.Enabled = (Not isError) AndAlso radioButtonChange.Checked
        End Sub



        Private Function VerifyPatientSettings() As Boolean
            errorProvider.Clear()

            Dim errorString As String = String.Empty
            Dim control As Control = Nothing

            ' (0010:0020) PatientID
            If String.IsNullOrEmpty(errorString) Then
                Dim patientId As String = textBoxId.Text.Trim()
                If patientId.Contains("\") Then
                    errorString = "Patient ID cannot contain the '' character."
                    control = textBoxId
                ElseIf patientId.Length > 64 Then
                    errorString = String.Format("Patient ID cannot exceed 64 characters in length")
                    control = textBoxId
                ElseIf patientId.Length = 0 Then
                    errorString = String.Format("Patient ID must contain a value")
                    control = textBoxId
                End If
            End If

            If radioButtonChange.Checked Then
                ' (0010:0010) PatientName
                If String.IsNullOrEmpty(errorString) Then
                    Dim familyName As String = textBoxLastname.Text.Trim()
                    Dim givenName As String = textBoxFirstname.Text.Trim()

                    If familyName.Length > 64 Then
                        errorString = String.Format("Last name cannot exceed 64 characters in length: {0}", familyName)
                        control = textBoxLastname
                    ElseIf givenName.Length > 64 Then
                        errorString = String.Format("First name cannot exceed 64 characters in length: {0}", givenName)
                        control = textBoxFirstname
                    Else
                        Dim personName As New PersonName()
                        personName.Family = textBoxLastname.Text.Trim()
                        personName.Given = textBoxFirstname.Text.Trim()

                        Dim patientName As String = personName.FullDicomEncoded
                        If patientName.Length > 64 Then
                            errorString = String.Format("Full patient name {{LastName}}^{{FirstName}} cannot exceed 64 characters in length: {0}", patientName)
                            control = textBoxLastname
                        ElseIf patientName.Length = 0 Then
                            errorString = String.Format("Full patient name {{LastName}}^{{FirstName}} must contain a value")
                            control = textBoxLastname
                        End If
                    End If
                End If
            End If

            If control IsNot Nothing Then
                errorProvider.SetIconAlignment(control, ErrorIconAlignment.TopLeft)
                errorProvider.SetError(control, errorString)
            End If

            Dim isError As Boolean = Not String.IsNullOrEmpty(errorString)

            ActionButton.Enabled = (Not isError) AndAlso radioButtonChange.Checked
            CopyButton.Enabled = (Not isError) AndAlso (textBoxId.Text.Length > 0) AndAlso (textBoxId.Text <> _Patient.Id) AndAlso Not radioButtonMerge.Checked
            SearchButton.Enabled = (Not isError) AndAlso (textBoxId.Text.Length > 0) AndAlso (textBoxId.Text <> _Patient.Id) AndAlso radioButtonMerge.Checked


            Return isError
        End Function

        Private Function AddPatientToList(ByRef patients As List(Of Patient), ByVal p As Patient) As Boolean
            patients.Add(p)
            Return True
        End Function

        Private Sub ChangePatient()
            '
            ' If the patient ID has changed then we need to see if a patient with that id already exists
            '
            If _Patient.Id <> textBoxId.Text Then
                Dim query As New PatientRootQueryPatient()
                Dim patients As New List(Of Patient)()

                query.PatientQuery.PatientId = textBoxId.Text
                Try
                    _find.Find(Of PatientRootQueryPatient, Patient)(_scp, query, Function(p As Patient, ds As DicomDataSet) AddPatientToList(patients, p))
                    If patients.Count > 0 Then
                        Dim result As TaskDialogResult = TaskDialogResult.Yes

                        result = TaskDialogHelper.ShowMessageBox(Me, "Patient Id Already Exits", "Would you like to merge with existing patient?", "The patient id already exisits.", "Existing Patient: " & patients(0).Name.Full, TaskDialogStandardButtons.Yes Or TaskDialogStandardButtons.No, TaskDialogStandardIcon.Error, TaskDialogStandardIcon.Warning)

                        If result = TaskDialogResult.Yes Then
                            radioButtonMerge.Checked = True
                            textBoxLastname.Text = patients(0).Name.Family
                            textBoxFirstname.Text = patients(0).Name.Given
                            comboBoxSex.SelectedIndex = comboBoxSex.FindStringExact(patients(0).Sex)
                            If patients(0).BirthDate.HasValue Then
                                dateTimePickerBirth.Value = patients(0).BirthDate.Value
                                dateTimePickerBirth.Checked = True
                            Else
                                dateTimePickerBirth.Checked = False
                            End If
                            MergePatient()
                            Return
                        Else
                            textBoxId.Text = _Patient.Id
                            Return
                        End If
                    End If
                Catch e As Exception
                    ApplicationUtils.ShowException(Me, e)
                    Return
                End Try
            End If

            Dim isError As Boolean = VerifyPatientSettings()
            If isError Then
                Return
            End If

            Dim dlgReason As New ReasonDialog("Input Reason For Changing Patient")

            If dlgReason.ShowDialog(Me) = DialogResult.OK Then
                Dim change As New ChangePatient()
                Dim status As DicomCommandStatusType = DicomCommandStatusType.Success

                change.OriginalPatientId = _Patient.Id.Replace("\", "\\").Replace("'", "''")
                change.Operator = If(Environment.UserName <> String.Empty, Environment.UserName, Environment.MachineName)
                change.PatientId = textBoxId.Text.Replace("\", "\\").Replace("'", "''")
                change.Reason = dlgReason.Reason
                change.Description = "Change Patient"
                change.Name.Given = textBoxFirstname.Text.Replace("\", "\\").Replace("'", "''")
                change.Name.Family = textBoxLastname.Text.Replace("\", "\\").Replace("'", "''")
                change.Sex = comboBoxSex.Text
                If dateTimePickerBirth.Checked Then
                    change.Birthdate = dateTimePickerBirth.Value
                Else
                    change.Birthdate = Nothing
                End If

#If (LEADTOOLS_V19_OR_LATER) Then
                If textBoxOtherPid.Text.Length > 0 Then
                    change.OtherPatientIdsSequence = New List(Of PatientUpdater.OtherPatientID)()
                    Dim textBoxStringOtherPid As String = textBoxOtherPid.Text.Replace("'", "''")

                    If (Not String.IsNullOrEmpty(textBoxStringOtherPid)) Then
                        Dim delimiterChars() As Char = {"\"c}
                        Dim otherPatientIds() As String = textBoxStringOtherPid.Split(delimiterChars, StringSplitOptions.RemoveEmptyEntries)

                        For Each otherPatientId As String In otherPatientIds
                            Dim opid As New PatientUpdater.OtherPatientID()
                            opid.PatientId = otherPatientId
                            opid.TypeOfPatientId = "TEXT"
                            change.OtherPatientIdsSequence.Add(opid)
                        Next otherPatientId
                    End If

                End If
#End If

                status = _naction.SendNActionRequest(Of ChangePatient)(_scp, change, NActionScu.ChangePatient, NActionScu.PatientUpdateInstance)
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
                    Action = ActionType.Change
                    TaskDialogHelper.ShowMessageBox(Me, "Patient Changed", "The patient has been successfully changed.", String.Empty, String.Empty, TaskDialogStandardButtons.Close, TaskDialogStandardIcon.Information, Nothing)
                    DialogResult = DialogResult.OK

                    If change.OriginalPatientId <> _Patient.Id Then
                        If Program.OtherPID.ContainsKey(change.OriginalPatientId) Then
                            Program.OtherPID.Remove(change.OriginalPatientId)
                        End If
                    End If

                    Program.OtherPID(_Patient.Id) = textBoxOtherPid.Text
                Else
                    Dim message As String = "The patient was not changed." & Constants.vbCrLf & "Error - " & _naction.GetErrorMessage()

                    If status = DicomCommandStatusType.MissingAttribute Then
                        message = "The patient was not changed." & Constants.vbCrLf & "Patient not found on server."
                    End If

                    TaskDialogHelper.ShowMessageBox(Me, "Change Patient Error", "The patient was not changed.", message, String.Empty, TaskDialogStandardButtons.Close, TaskDialogStandardIcon.Information, Nothing)
                End If
            End If
        End Sub

        Private Sub MergePatient()
            Dim dlgReason As ReasonDialog = New ReasonDialog("Input Reason For Merging Patient")

            If dlgReason.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK Then
                Dim merge As MergePatient = New MergePatient()
                Dim status As DicomCommandStatusType = DicomCommandStatusType.Success
                Dim progress As ProgressDialog = New ProgressDialog()

                merge.PatientId = textBoxId.Text
                If Environment.UserName <> String.Empty Then
                    merge.Operator = Environment.UserName
                Else
                    merge.Operator = Environment.MachineName
                End If
                merge.Reason = dlgReason.Reason
                merge.Description = "Merge Patient"
                merge.PatientToMerge.Add(New MergePatientSequence(_Patient.Id))

                Try
                    Dim sThreaded As ThreadedClass = New ThreadedClass(_naction, _scp, NActionScu.MergePatient, NActionScu.PatientUpdateInstance)
                    sThreaded.MrgPatient = merge
                    Dim thrd As Thread = New Thread(AddressOf sThreaded.SendNActionRequest)

                    progress.ActionThread = thrd
                    progress.Title = "Merging Patient: " & _Patient.Name.Full
                    progress.ProgressInfo = "Performing patient merge."
                    progress.ShowDialog(Me)

                    status = sThreaded.Status
                Catch e As Exception
                    ApplicationUtils.ShowException(Me, e)
                    status = DicomCommandStatusType.Failure
                End Try

                If status = DicomCommandStatusType.Success Then
                    Action = ActionType.Merge
                    TaskDialogHelper.ShowMessageBox(Me, "Patient Merge", "The patient has been successfully merged.", GetMergeInfo(), String.Empty, TaskDialogStandardButtons.Close, TaskDialogStandardIcon.Information, Nothing)
                    DialogResult = System.Windows.Forms.DialogResult.OK
                Else
                    Dim message As String = "The patient has not been merged." & Constants.vbCrLf & "Error - "
                    Dim footer As String = String.Empty

                    If status = DicomCommandStatusType.Reserved2 Then
                        message &= "Missing Files"
                    Else
                        message &= _naction.GetErrorMessage()
                    End If

                    If status = DicomCommandStatusType.MissingAttribute Then
                        message = "The patient has not been merged." & Constants.vbCrLf & "Patient not found on server."
                    ElseIf status = DicomCommandStatusType.Reserved2 Then
                        footer = "Contact system administrator for help in resolving this issue."
                    End If

                    TaskDialogHelper.ShowMessageBox(Me, "Merge Patient Error", "The patient has not been merged.", message, footer, TaskDialogStandardButtons.Close, TaskDialogStandardIcon.Information, Nothing)
                End If
            End If
        End Sub

        Private Sub CopyPatient()
            '
            ' If the patient ID has changed then we need to see if a patient with that id already exists
            '
            If _Patient.Id <> textBoxId.Text Then
                Dim query As PatientRootQueryPatient = New PatientRootQueryPatient()
                Dim patients As List(Of Patient) = New List(Of Patient)()

                query.PatientQuery.PatientId = textBoxId.Text
                Try
                    _find.Find(Of PatientRootQueryPatient, Patient)(_scp, query, Function(p As Patient, ds As DicomDataSet) AddPatientToList(patients, p))

                    If patients.Count > 0 Then
                        Dim result As TaskDialogResult = TaskDialogResult.Yes

                        result = TaskDialogHelper.ShowMessageBox(Me, "Patient Id Already Exits", "Would you like to merge with existing patient?", "The patient id already exisits.", "Existing Patient: " & patients(0).Name.Full, TaskDialogStandardButtons.Yes Or TaskDialogStandardButtons.No, TaskDialogStandardIcon.Error, TaskDialogStandardIcon.Warning)

                        If result = TaskDialogResult.Yes Then
                            radioButtonMerge.Checked = True
                            textBoxLastname.Text = patients(0).Name.Family
                            textBoxFirstname.Text = patients(0).Name.Given
                            If String.IsNullOrEmpty(patients(0).Sex) Then
                                comboBoxSex.Text = String.Empty
                            Else
                                comboBoxSex.SelectedIndex = comboBoxSex.FindStringExact(patients(0).Sex)
                            End If
                            If patients(0).BirthDate.HasValue Then
                                dateTimePickerBirth.Value = patients(0).BirthDate.Value
                                dateTimePickerBirth.Checked = True
                            Else
                                dateTimePickerBirth.Checked = False
                            End If
                        Else
                            textBoxId.Text = _Patient.Id
                            Return
                        End If
                    End If
                Catch e As Exception
                    ApplicationUtils.ShowException(Me, e)
                    Return
                End Try
            End If

            Dim dlgReason As ReasonDialog = New ReasonDialog("Input Reason For Copying Patient")

            If dlgReason.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK Then
                Dim change As CopyPatient = New CopyPatient()
                Dim status As DicomCommandStatusType = DicomCommandStatusType.Success

                change.OriginalPatientId = _Patient.Id.Replace("\", "\\").Replace("'", "''")
                If Environment.UserName <> String.Empty Then
                    change.Operator = Environment.UserName
                Else
                    change.Operator = Environment.MachineName
                End If
                change.PatientId = textBoxId.Text.Replace("\", "\\").Replace("'", "''")
                change.Reason = dlgReason.Reason
                change.Description = "Copy Patient"
                change.Name.Given = textBoxFirstname.Text.Replace("\", "\\").Replace("'", "''")
                change.Name.Family = textBoxLastname.Text.Replace("\", "\\").Replace("'", "''")
                change.Sex = comboBoxSex.Text
                If dateTimePickerBirth.Checked Then
                    change.Birthdate = dateTimePickerBirth.Value
                Else
                    change.Birthdate = Nothing
                End If

#If (LEADTOOLS_V19_OR_LATER) Then
                If textBoxOtherPid.Text.Length > 0 Then
                    Dim opid As New PatientUpdater.OtherPatientID()

                    change.OtherPatientIdsSequence = New List(Of PatientUpdater.OtherPatientID)()
                    opid.PatientId = textBoxOtherPid.Text.Replace("\", "\\").Replace("'", "''")
                    opid.TypeOfPatientId = "TEXT"
                    change.OtherPatientIdsSequence.Add(opid)
                End If
#End If

                status = _naction.SendNActionRequest(Of CopyPatient)(_scp, change, NActionScu.CopyPatient, NActionScu.PatientUpdateInstance)
                If status = DicomCommandStatusType.Success Then
                    '_Patient.Id = textBoxId.Text;
                    '_Patient.Name.Given = textBoxFirstname.Text;
                    '_Patient.Name.Family = textBoxLastname.Text;
                    '_Patient.Sex = comboBoxSex.Text;
                    'if (dateTimePickerBirth.Checked)
                    '    _Patient.BirthDate = dateTimePickerBirth.Value;
                    'else
                    '    _Patient.BirthDate = null;
                    Action = ActionType.CopyPatient
                    TaskDialogHelper.ShowMessageBox(Me, "Patient Copied", "The patient has been successfully copied.", String.Empty, String.Empty, TaskDialogStandardButtons.Close, TaskDialogStandardIcon.Information, Nothing)
                    DialogResult = System.Windows.Forms.DialogResult.OK
                Else
                    TaskDialogHelper.ShowMessageBox(Me, "Copy Error", "The patient has not been successfully copied.", String.Empty, "Error - " & _naction.GetErrorMessage(), TaskDialogStandardButtons.Close, TaskDialogStandardIcon.Information, Nothing)
                End If
            End If
        End Sub

        Private Function GetMergeInfo() As String
            Dim info As String = String.Empty

            info = String.Format("Patient {0} ({1}) has been merged with patient {2}({3})", _Patient.Name.Full, _Patient.Id, textBoxFirstname.Text & " " & textBoxLastname.Text, textBoxId.Text)
            Return info
        End Function

        Private Sub SearchButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles SearchButton.Click
            Dim patient As Patient = DicomUtils.FindPatient(Me, _find, _scp, textBoxId.Text)

            If Not patient Is Nothing Then
                textBoxLastname.Text = patient.Name.Family
                textBoxFirstname.Text = patient.Name.Given
                comboBoxSex.SelectedIndex = comboBoxSex.FindStringExact(patient.Sex)
                If patient.BirthDate.HasValue Then
                    dateTimePickerBirth.Value = patient.BirthDate.Value
                    dateTimePickerBirth.Checked = True
                End If
            Else
                TaskDialogHelper.ShowMessageBox(Me, "Patient Search", "Patient with specified id was not found.", String.Empty, String.Empty, TaskDialogStandardButtons.Close, TaskDialogStandardIcon.Information, Nothing)
            End If
            ActionButton.Enabled = Not patient Is Nothing
        End Sub

        Private Sub EditPatientDialog_Shown(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Shown
            textBoxId.Focus()
            helpOtherPaitientIds.Visible = False
        End Sub

        Private Sub textBoxId_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles textBoxId.KeyPress
            If e.KeyChar = "*"c Then
                e.Handled = True
            End If
        End Sub

        Private Sub UpperCase_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles textBoxLastname.KeyPress, textBoxFirstname.KeyPress
            If Char.IsLetter(e.KeyChar) Then
                e.KeyChar = Char.ToUpper(e.KeyChar)
            End If
        End Sub


        Private Sub CopyButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles CopyButton.Click
            CopyPatient()
        End Sub

        Private Sub textBoxOtherPid_Enter(ByVal sender As Object, ByVal e As EventArgs) Handles textBoxOtherPid.Enter
            helpOtherPaitientIds.Visible = True
        End Sub

        Private Sub textBoxOtherPid_Leave(ByVal sender As Object, ByVal e As EventArgs) Handles textBoxOtherPid.Leave
            helpOtherPaitientIds.Visible = False
        End Sub
    End Class
End Namespace
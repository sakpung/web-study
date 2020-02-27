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
Imports System.Linq
Imports System.Text
Imports System.Windows.Forms
Imports Leadtools.Wizard.Pages
Imports Leadtools.Wizard
Imports ModalityWorklistWCFDemo.Broker
Imports Leadtools.Demos
Imports System.ServiceModel
Imports Leadtools.Dicom

Namespace ModalityWorklistWCFDemo.UI.Pages
	Partial Public Class PatientPage
		Inherits InternalTemplatePage
		Private _Update As Boolean = False
		Private _OriginalPatientId As String = String.Empty
		Private _OriginalIssuerOfPatientId As String = String.Empty
		Private _PatientKeys As List(Of PatientKey)

		Private _Patient As New WCFPatient()

		Public ReadOnly Property Patient() As WCFPatient
			Get
				Return _Patient
			End Get
		End Property

		Public Sub New()
			InitializeComponent()
			errorProvider.SetIconAlignment(comboBoxPatientId, ErrorIconAlignment.TopLeft)
		End Sub

		Public _clientPatientPage As CustomBrokerClient
		Public _idsPatientPage As List(Of String)

#If (LTV19_CONFIG) Then
      Dim _worklistServer As String = "L19_MWL_SCP32"
#ElseIf (LTV18_CONFIG) Then
	  Dim _worklistServer As String = "L18_MWL_SCP32"
#ElseIf (LTV175_CONFIG) Then
	  Dim _worklistServer As String = "L175_MWL_SCP32"
#Else
	  Dim _worklistServer As String = "L17_MWL_SCP32"
#End If

		Public Overrides Sub OnSetActive(ByVal sender As Object, ByVal e As WizardCancelEventArgs)
			MyBase.OnSetActive(sender, e)
			GetWizard().Option1Caption = "Clear"
			If _PatientKeys Is Nothing Then
				Dim dlgProgresss As New ProgressDialog()
				_clientPatientPage = TryCast(GetWizard().Tag, CustomBrokerClient)
				_idsPatientPage = Nothing

				dlgProgresss.Title = "Find"
				dlgProgresss.Description = "Getting list of patient ids"
				dlgProgresss.Action = AddressOf AnonymousMethodPatientPage

				If dlgProgresss.ShowDialog(Me) = DialogResult.OK Then              
               If _idsPatientPage IsNot Nothing Then
                  _PatientKeys = New List(Of PatientKey)()
                  For Each id As String In _idsPatientPage
                     Dim info() As String = id.Split(";"c)
                     Dim key As New PatientKey() With {.PatientId = info(0), .IssurerOfPatientId = info(1)}

                     _PatientKeys.Add(key)
                     comboBoxPatientId.Items.Add(key)
                  Next id
               End If
            End If
            If dlgProgresss.Exception IsNot Nothing Then
               Dim errorMessage As String = dlgProgresss.Exception.Message
               If errorMessage.Contains("There was no endpoint listening at") Then
                  Dim append As String = String.Format(Constants.vbLf + Constants.vbLf & "This can happen if the '{0}' listening service is not running.  To start '{0}' listening service:" & Constants.vbLf & "* Run 'CSLeadtools.Dicom.Server.Manager_Original.exe'" & Constants.vbLf & "* Click the double-green arrow (Start All Servers)", _worklistServer)
                  errorMessage &= append
               End If
               Messager.ShowError(Me, errorMessage)
            End If
         End If
		End Sub
		Private Sub AnonymousMethodPatientPage()
			_idsPatientPage = _clientPatientPage.GetPatientIDs()
		End Sub

		Protected Overrides Function GetWizardButtons() As WizardSheet.WizardButtons
			Dim buttons As WizardSheet.WizardButtons = MyBase.GetWizardButtons()

			buttons = buttons Or WizardSheet.WizardButtons.Option1
			Return buttons
		End Function

		Public Overrides Sub OnOptionButton1(ByVal sender As Object, ByVal e As EventArgs)
			comboBoxPatientId.Text = String.Empty
			textBoxIssuerOfPatientId.Text = String.Empty
			textBoxPrefix.Text = String.Empty
			textBoxFamily.Text = String.Empty
			textBoxGiven.Text = String.Empty
			textBoxSuffix.Text = String.Empty
			dateTimePickerBirth.Value = DateTime.Now
			dateTimePickerBirth.Checked = False
			comboBoxSex.SelectedIndex = -1
			textBoxSpecialNeeds.Text = String.Empty
			textBoxComments.Text = String.Empty
			_Update = False
			errorProvider.Clear()
		End Sub

		Public _clientPatientPageOnWizardNext As CustomBrokerClient
		Public Overrides Sub OnWizardNext(ByVal sender As Object, ByVal e As WizardPageEventArgs)
			If (Not IsValid()) Then
				e.Cancel = True
				Return
			Else
				Dim dlgProgresss As New ProgressDialog()
				_clientPatientPageOnWizardNext = TryCast(GetWizard().Tag, CustomBrokerClient)

				'
				' See if the user wants to update are add.  The user will only be asked if the originally did a search but
				' changed one of the patient ids.
				'
				If _Update AndAlso (comboBoxPatientId.Text <> _OriginalPatientId) Then
					Dim r As DialogResult = Messager.ShowQuestion(Me, "You searched for a patient but have changed some of the identifying information.  " & "Would you like to update this patient with the new information? " & Constants.vbCrLf & Constants.vbCrLf & "Clicking No will add a new patient.", MessageBoxButtons.YesNo)
					_Update = r = DialogResult.Yes
				End If

				UpdatePatient()
				dlgProgresss.Title = If(_Update, "Update patient", "Add Patient")
				dlgProgresss.Description = If(_Update, "Updating...", "Adding...")
				dlgProgresss.Action = AddressOf AnonymousMethod2

				If dlgProgresss.ShowDialog(Me) = DialogResult.Cancel Then
					If dlgProgresss.Exception IsNot Nothing Then
						e.Cancel = True
						Messager.ShowError(Me, dlgProgresss.Exception)
					End If
				Else
				   If _Update Then
					  UpdatePatient(_OriginalPatientId, _OriginalIssuerOfPatientId, _Patient.PatientID, _Patient.IssuerOfPatientID)
				   Else
					  comboBoxPatientId.Items.Add(New PatientKey() With {.PatientId = _Patient.PatientID, .IssurerOfPatientId = _Patient.IssuerOfPatientID})
				   End If

				   comboBoxPatientId.Text = _Patient.PatientID
				   _OriginalPatientId = _Patient.PatientID
				   _OriginalIssuerOfPatientId = _Patient.IssuerOfPatientID
				End If
			End If

			MyBase.OnWizardNext(sender, e)
		End Sub
		Private Sub AnonymousMethod2()
			If _Update Then
				_clientPatientPageOnWizardNext.UpdatePatient(_OriginalPatientId, _OriginalIssuerOfPatientId, _Patient)
			Else
				_clientPatientPageOnWizardNext.AddPatient(_Patient)
			End If
		End Sub

		Private Sub UpdatePatient(ByVal pid As String, ByVal ipid As String, ByVal p As String, ByVal i As String)
			For Each key As PatientKey In _PatientKeys
				If key.PatientId = pid AndAlso key.IssurerOfPatientId = ipid Then
					Dim index As Integer = comboBoxPatientId.Items.IndexOf(key)

					_PatientKeys.ElementAt(index).PatientId = p
					_PatientKeys.ElementAt(index).IssurerOfPatientId = i
					Exit For
				End If
			Next key
		End Sub

		Public Function IsValid() As Boolean
			Dim valid As Boolean = True

			If comboBoxPatientId.Text.Length = 0 Then
				valid = False
				errorProvider.SetError(comboBoxPatientId, "Must provide patient id")
				comboBoxPatientId.Focus()
			Else
				errorProvider.SetError(comboBoxPatientId, String.Empty)
			End If

			If textBoxIssuerOfPatientId.Text.Length = 0 Then
				If valid Then
					valid = False
					textBoxIssuerOfPatientId.Focus()
				End If
				errorProvider.SetError(textBoxIssuerOfPatientId, "Must provide issuer of patient id")
			Else
				errorProvider.SetError(textBoxIssuerOfPatientId, String.Empty)
			End If

			If textBoxGiven.Text.Length = 0 AndAlso textBoxFamily.Text.Length = 0 Then
				If valid Then
					valid = False
					textBoxGiven.Focus()
				End If
				errorProvider.SetError(groupBoxName, "Must provide value for Given or Family portion of name")
			Else
				errorProvider.SetError(groupBoxName, String.Empty)
			End If

			If comboBoxSex.SelectedItem Is Nothing Then
			   If valid Then
				  valid = False
				  comboBoxSex.Focus()
			   End If
			   errorProvider.SetError(comboBoxSex, "Must provide a value for sex")
			Else
			   errorProvider.SetError(comboBoxSex, String.Empty)
			End If

			Return valid
		End Function

		Private Sub UpdateUI()
			textBoxPrefix.Text = _Patient.PatientNamePrefix
			textBoxFamily.Text = _Patient.PatientNameFamilyName
			textBoxGiven.Text = _Patient.PatientNameGivenName
			textBoxSuffix.Text = _Patient.PatientNameSuffix

			If _Patient.PatientBirthDate.HasValue Then
				dateTimePickerBirth.Value = _Patient.PatientBirthDate.Value.Date1.ToDateTime()
			End If

			If (Not String.IsNullOrEmpty(_Patient.PatientSex)) Then
				Dim index As Integer = comboBoxSex.FindStringExact(_Patient.PatientSex)

				comboBoxSex.SelectedIndex = index
			Else
				comboBoxSex.Text = ""
			End If

			textBoxSpecialNeeds.Text = _Patient.SpecialNeeds
			textBoxComments.Text = _Patient.PatientComments
		End Sub

		Private Sub UpdatePatient()
			_Patient.PatientID = comboBoxPatientId.Text
			_Patient.IssuerOfPatientID = textBoxIssuerOfPatientId.Text
			_Patient.PatientNamePrefix = textBoxPrefix.Text
			_Patient.PatientNameFamilyName = textBoxFamily.Text
			_Patient.PatientNameGivenName = textBoxGiven.Text
			_Patient.PatientNameSuffix = textBoxSuffix.Text

			If dateTimePickerBirth.Checked Then
				_Patient.PatientBirthDate = New DicomDateRangeValue() With {.Date1 = New DicomDateValue(dateTimePickerBirth.Value)}
			End If

			_Patient.PatientSex = comboBoxSex.Text
			_Patient.SpecialNeeds = textBoxSpecialNeeds.Text
			_Patient.PatientComments = textBoxComments.Text
		End Sub

		Public Overrides Sub OnReset()
			OnOptionButton1(Me, EventArgs.Empty)
		End Sub

		Public _clientGetPatientInformation As BrokerServiceClient
		Public _pidGetPatientInformation As String
		Public _ipidGetPatientInformation As String

		Private Sub GetPatientInformation()
			Dim dlgProgresss As New ProgressDialog()
			_clientGetPatientInformation = TryCast(GetWizard().Tag, BrokerServiceClient)
			_pidGetPatientInformation = comboBoxPatientId.Text
			_ipidGetPatientInformation = textBoxIssuerOfPatientId.Text

			dlgProgresss.Title = "Querying"
			dlgProgresss.Description = "Getting patient information"
			dlgProgresss.Action = AddressOf AnonymousMethodGetPatientInformation

			_Update = False
			_OriginalPatientId = String.Empty
			_OriginalIssuerOfPatientId = String.Empty
			If dlgProgresss.ShowDialog(Me) = DialogResult.OK Then
				If _Patient IsNot Nothing Then
					_Update = True
					UpdateUI()
					_OriginalPatientId = _Patient.PatientID
					_OriginalIssuerOfPatientId = _Patient.IssuerOfPatientID
					errorProvider.Clear()
				Else
					Messager.ShowError(Me, "Patient not found.")
				End If
			Else
				If dlgProgresss.Exception IsNot Nothing Then
					Messager.ShowError(Me, dlgProgresss.Exception)
				End If
			End If
		End Sub
		Private Sub AnonymousMethodGetPatientInformation()
				_Patient = _clientGetPatientInformation.FindPatient(_pidGetPatientInformation, _ipidGetPatientInformation)
		End Sub

		Private Sub PatientPage_Paint(ByVal sender As Object, ByVal e As PaintEventArgs) Handles MyBase.Paint
			PaintUtils.HighlightRequiredFields(Me, e.Graphics, True, Color.Red)
		End Sub

		Private Class PatientKey
			Private privatePatientId As String
			Public Property PatientId() As String
				Get
					Return privatePatientId
				End Get
				Set(ByVal value As String)
					privatePatientId = value
				End Set
			End Property
			Private privateIssurerOfPatientId As String
			Public Property IssurerOfPatientId() As String
				Get
					Return privateIssurerOfPatientId
				End Get
				Set(ByVal value As String)
					privateIssurerOfPatientId = value
				End Set
			End Property

			Public Overrides Function ToString() As String
				Return PatientId
			End Function
		End Class

		Private Sub comboBoxPatientId_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles comboBoxPatientId.SelectedIndexChanged
			If comboBoxPatientId.SelectedIndex <> -1 Then
				Dim key As PatientKey = TryCast(comboBoxPatientId.SelectedItem, PatientKey)

				textBoxIssuerOfPatientId.Text = key.IssurerOfPatientId
				GetPatientInformation()
			End If
		End Sub
	End Class
End Namespace

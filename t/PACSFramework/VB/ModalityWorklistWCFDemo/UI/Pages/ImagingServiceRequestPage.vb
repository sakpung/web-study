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

Namespace ModalityWorklistWCFDemo.UI.Pages
	Partial Public Class ImagingServiceRequestPage
		Inherits InternalTemplatePage
		Private _Patient As Patient = Nothing
		Private _OriginalAccessionNumber As String = String.Empty
		Private _Update As Boolean = False

		Private _ImagingServiceRequest As New ImagingServiceRequest()

		Public ReadOnly Property ImagingServiceRequest() As ImagingServiceRequest
			Get
				Return _ImagingServiceRequest
			End Get
		End Property

		Public Sub New()
			InitializeComponent()
		End Sub

		Protected Overrides Function GetWizardButtons() As WizardSheet.WizardButtons
			Dim buttons As WizardSheet.WizardButtons = MyBase.GetWizardButtons()

			buttons = buttons Or WizardSheet.WizardButtons.Option1
			Return buttons
		End Function

		Public _accessionNumbers As List(Of String)
		Public _client As CustomBrokerClient


        Private Sub AnonymousMethodImagingServiceRequestPage()
            _accessionNumbers = _client.GetAccessionNumbers(_Patient.PatientID, _Patient.IssuerOfPatientID)
        End Sub


		Public Overrides Sub OnSetActive(ByVal sender As Object, ByVal e As WizardCancelEventArgs)
			MyBase.OnSetActive(sender, e)

            If e.PreviousPage IsNot Nothing AndAlso e.PreviousPage.GetType() Is GetType(PatientPage) Then
                Dim p As PatientPage = TryCast(e.PreviousPage, PatientPage)
				Dim previous As Patient = _Patient

				_Patient = p.Patient
				If previous Is Nothing OrElse (previous.IssuerOfPatientID <> p.Patient.IssuerOfPatientID OrElse previous.PatientID <> p.Patient.PatientID) Then
					Dim dlgProgresss As New ProgressDialog()
					_client = TryCast(GetWizard().Tag, CustomBrokerClient)
					' List<string> accessionNumbers = null;
				   _accessionNumbers = Nothing

					dlgProgresss.Title = "Find"
					dlgProgresss.Description = "Getting list of accession numbers"
                    dlgProgresss.Action = AddressOf AnonymousMethodImagingServiceRequestPage

					UpdateUI(True)
					comboBoxAccessionNumber.Items.Clear()
					If dlgProgresss.ShowDialog(Me) = DialogResult.OK Then
						For Each accessionNumber As String In _accessionNumbers
							comboBoxAccessionNumber.Items.Add(accessionNumber)
						Next accessionNumber
					End If
					If dlgProgresss.Exception IsNot Nothing Then
						Messager.ShowError(Me, dlgProgresss.Exception)
					End If
				End If
			End If
			errorProvider.SetIconAlignment(comboBoxAccessionNumber, ErrorIconAlignment.TopLeft)
		End Sub

		Public _clientOnWizardNext As CustomBrokerClient
        Private Sub AnonymousMethodOnWizardNext()
            If _Update Then
                _clientOnWizardNext.UpdateImagingServiceRequest(_OriginalAccessionNumber, _Patient.PatientID, _Patient.IssuerOfPatientID, _ImagingServiceRequest)
            Else
                _clientOnWizardNext.AddImagingServiceRequest(_Patient.PatientID, _Patient.IssuerOfPatientID, _ImagingServiceRequest)
            End If
        End Sub
		Public Overrides Sub OnWizardNext(ByVal sender As Object, ByVal e As WizardPageEventArgs)
			If (Not IsValid()) Then
				e.Cancel = True
				Return
			Else
				Dim dlgProgresss As New ProgressDialog()
				_clientOnWizardNext = TryCast(GetWizard().Tag, CustomBrokerClient)

				'
				' See if the user wants to update are add.  The user will only be asked if the originally did a search but
				' changed one of the patient ids.
				'
				If _Update AndAlso (comboBoxAccessionNumber.Text <> _OriginalAccessionNumber) Then
					Dim r As DialogResult = Messager.ShowQuestion(Me, "You searched for an imaging service request but have changed the accession number.  " & "Would you like to update this imaging service request with the accession number?  " & Constants.vbCrLf & Constants.vbCrLf & "Clicking No will add a new imaging service request.",MessageBoxButtons.YesNo)
					_Update = r = DialogResult.Yes
				End If

				UpdateImagingServiceRequest()
				dlgProgresss.Title = If(_Update, "Update Imaging Service Request", "Add Imaging Service Request")
				dlgProgresss.Description = If(_Update, "Updating...", "Adding...")
                dlgProgresss.Action = AddressOf AnonymousMethodOnWizardNext

				If dlgProgresss.ShowDialog(Me) = DialogResult.Cancel Then
					If dlgProgresss.Exception IsNot Nothing Then
						e.Cancel = True
						Messager.ShowError(Me, dlgProgresss.Exception)
					End If
				Else
					If _Update Then
						Dim index As Integer = comboBoxAccessionNumber.Items.IndexOf(_OriginalAccessionNumber)

						If index <> -1 Then
							comboBoxAccessionNumber.Items.Remove(_OriginalAccessionNumber)
						End If
					End If
					comboBoxAccessionNumber.Items.Add(_ImagingServiceRequest.AccessionNumber)
					comboBoxAccessionNumber.Text = _ImagingServiceRequest.AccessionNumber
					_OriginalAccessionNumber = _ImagingServiceRequest.AccessionNumber
				End If
			End If
			MyBase.OnWizardNext(sender, e)
		End Sub


		Public Overrides Sub OnOptionButton1(ByVal sender As Object, ByVal e As EventArgs)
			UpdateUI(True)
		End Sub

		Public Function IsValid() As Boolean
			If comboBoxAccessionNumber.Text.Length = 0 Then
				errorProvider.SetError(comboBoxAccessionNumber, "Must provide a value for accession number")
				comboBoxAccessionNumber.Focus()
				Return False
			Else
				errorProvider.SetError(comboBoxAccessionNumber, String.Empty)
			End If
			Return True
		End Function

		Private Sub UpdateUI(ByVal clear As Boolean)
			If (Not clear) Then
				textBoxRequestingService.Text = _ImagingServiceRequest.RequestingService
				textBoxPrefix.Text = _ImagingServiceRequest.RequestingPhysicianPrefix
				textBoxGiven.Text = _ImagingServiceRequest.RequestingPhysicianGivenName
				textBoxFamily.Text = _ImagingServiceRequest.RequestingPhysicianFamilyName
				textBoxSuffix.Text = _ImagingServiceRequest.RequestingPhysicianSuffix
				textBoxRPPrefix.Text = _ImagingServiceRequest.ReferringPhysicianPrefix
				textBoxRPGiven.Text = _ImagingServiceRequest.ReferringPhysicianGivenName
				textBoxRPFamily.Text = _ImagingServiceRequest.ReferringPhysicianFamilyName
				textBoxRPSuffix.Text = _ImagingServiceRequest.ReferringPhysicianSuffix
				textBoxPlaceOrderNumber.Text = _ImagingServiceRequest.PlacerOrderNumber_ImagingServiceRequest
				textBoxFillOrderNumber.Text = _ImagingServiceRequest.FillerOrderNumber_ImagingServiceRequest
			Else
				comboBoxAccessionNumber.Text = String.Empty
				textBoxRequestingService.Text = String.Empty
				textBoxPrefix.Text = String.Empty
				textBoxGiven.Text = String.Empty
				textBoxFamily.Text = String.Empty
				textBoxSuffix.Text = String.Empty
				textBoxRPPrefix.Text = String.Empty
				textBoxRPGiven.Text = String.Empty
				textBoxRPFamily.Text = String.Empty
				textBoxRPSuffix.Text = String.Empty
				textBoxPlaceOrderNumber.Text = String.Empty
				textBoxFillOrderNumber.Text = String.Empty
				_Update = False
				errorProvider.Clear()
			End If
		End Sub

		Private Sub UpdateImagingServiceRequest()
			_ImagingServiceRequest.AccessionNumber = comboBoxAccessionNumber.Text
			_ImagingServiceRequest.RequestingService = textBoxRequestingService.Text
			_ImagingServiceRequest.RequestingPhysicianPrefix = textBoxPrefix.Text
			_ImagingServiceRequest.RequestingPhysicianGivenName = textBoxGiven.Text
			_ImagingServiceRequest.RequestingPhysicianFamilyName = textBoxFamily.Text
			_ImagingServiceRequest.RequestingPhysicianSuffix = textBoxSuffix.Text
			_ImagingServiceRequest.ReferringPhysicianPrefix = textBoxRPPrefix.Text
			_ImagingServiceRequest.ReferringPhysicianGivenName = textBoxRPGiven.Text
			_ImagingServiceRequest.ReferringPhysicianFamilyName = textBoxRPFamily.Text
			_ImagingServiceRequest.ReferringPhysicianSuffix = textBoxRPSuffix.Text
			_ImagingServiceRequest.PlacerOrderNumber_ImagingServiceRequest = textBoxPlaceOrderNumber.Text
			_ImagingServiceRequest.FillerOrderNumber_ImagingServiceRequest = textBoxFillOrderNumber.Text
		End Sub

		Public Overrides Sub OnReset()
			UpdateUI(True)
		End Sub

		Public _clientGetImagingServiceRequestInfo As CustomBrokerClient
		Public _accessionNumberGetImagingServiceRequestInfo As String

		Private Sub GetImagingServiceRequestInfo()
			Dim dlgProgresss As New ProgressDialog()
			_clientGetImagingServiceRequestInfo = TryCast(GetWizard().Tag, CustomBrokerClient)
			_accessionNumberGetImagingServiceRequestInfo = comboBoxAccessionNumber.Text

			dlgProgresss.Title = "Search"
			dlgProgresss.Description = "Searching for imaging service request"
			dlgProgresss.Action = AddressOf AnonymousMethod3

			_Update = False
			_OriginalAccessionNumber = String.Empty
			If dlgProgresss.ShowDialog(Me) = DialogResult.OK Then
				If _ImagingServiceRequest IsNot Nothing Then
					_Update = True
					UpdateUI(False)
					_OriginalAccessionNumber = _ImagingServiceRequest.AccessionNumber
					errorProvider.Clear()
				Else
					Messager.ShowError(Me, "Imaging service request not found.")
				End If
			Else
				If dlgProgresss.Exception IsNot Nothing Then
					Messager.ShowError(Me, dlgProgresss.Exception)
				End If
			End If
		End Sub
		Private Sub AnonymousMethod3()
		   _ImagingServiceRequest = _clientGetImagingServiceRequestInfo.FindImagingServiceRequest(_accessionNumberGetImagingServiceRequestInfo, _Patient.PatientID, _Patient.IssuerOfPatientID)
		End Sub

		Private Sub ImagingServiceRequestPage_Paint(ByVal sender As Object, ByVal e As PaintEventArgs) Handles MyBase.Paint
			PaintUtils.HighlightRequiredFields(Me, e.Graphics, True, Color.Red)
		End Sub

		Private Sub comboBoxAccessionNumber_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles comboBoxAccessionNumber.SelectedIndexChanged
			If comboBoxAccessionNumber.SelectedIndex <> -1 Then
				GetImagingServiceRequestInfo()
			End If
		End Sub
	End Class
End Namespace

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
Imports MPPSWCFDemo.Broker
Imports Leadtools.Demos
Imports System.ServiceModel
Imports Leadtools.Dicom

Namespace MPPSWCFDemo.UI.Pages
	Partial Public Class PatientPage
		Inherits InternalTemplatePage
		Public Sub New()
			InitializeComponent()
		End Sub

		Public Overrides Sub OnSetActive(ByVal sender As Object, ByVal e As WizardCancelEventArgs)
			MyBase.OnSetActive(sender, e)
			UpdateUI(False)
		End Sub

		Protected Overrides Function GetWizardButtons() As WizardSheet.WizardButtons
			Dim buttons As WizardSheet.WizardButtons = MyBase.GetWizardButtons()

			buttons = buttons Or WizardSheet.WizardButtons.Option1 And (Not WizardSheet.WizardButtons.Next) Or WizardSheet.WizardButtons.Finish
			Return buttons
		End Function

		Public Overrides Sub OnOptionButton1(ByVal sender As Object, ByVal e As EventArgs)
			textBoxId.Text = String.Empty
			textBoxIssuerOfPatientId.Text = String.Empty
			dateTimePickerBirth.Value = DateTime.Now
			dateTimePickerBirth.Checked = False
			comboBoxSex.SelectedIndex = -1
			textBoxName.Text = String.Empty
		End Sub

	   Public _clientPatientPageOnWizardFinish As BrokerServiceClient
		Public Overrides Sub OnWizardFinish(ByVal sender As Object, ByVal e As CancelEventArgs)
			Dim dlgProgresss As New ProgressDialog()
			_clientPatientPageOnWizardFinish = TryCast(GetWizard().Tag, BrokerServiceClient)

			UpdatePatient()
			dlgProgresss.Title = "Update patient information"
			dlgProgresss.Description = "Updating..."
			dlgProgresss.Action = AddressOf AnonymousMethodPatientPageOnWizardFinish

			If dlgProgresss.ShowDialog(Me) = DialogResult.Cancel Then
				If dlgProgresss.Exception IsNot Nothing Then
					e.Cancel = True
					Messager.ShowError(Me, dlgProgresss.Exception)
				End If
			End If

			MyBase.OnWizardFinish(sender, e)
		End Sub
		Private Sub AnonymousMethodPatientPageOnWizardFinish()
			_clientPatientPageOnWizardFinish.UpdateMPPS(MainForm.Mpps.MPPSSOPInstanceUID, MainForm.Mpps)
		End Sub

		Private Sub UpdateUI(ByVal clear As Boolean)
		   If (Not clear) Then
			  If MainForm.Mpps.Patient Is Nothing Then
				 MainForm.Mpps.Patient = New PatientInfoforUnscheduledPPS()
			  End If

			  textBoxId.Text = MainForm.Mpps.Patient.PatientID
			  textBoxIssuerOfPatientId.Text = MainForm.Mpps.Patient.IssuerofPatientID
			  textBoxName.Text = MainForm.Mpps.Patient.PatientName

			  If MainForm.Mpps.Patient.PatientBirthDate.HasValue Then
				 dateTimePickerBirth.Value = MainForm.Mpps.Patient.PatientBirthDate.Value.Date1.ToDateTime()
			  End If

			  If (Not String.IsNullOrEmpty(MainForm.Mpps.Patient.PatientSex)) Then
				 Dim index As Integer = comboBoxSex.FindStringExact(MainForm.Mpps.Patient.PatientSex)

				 comboBoxSex.SelectedIndex = index
			  Else
				 comboBoxSex.Text = ""
			  End If
		   Else
			  textBoxId.Text = String.Empty
			  textBoxIssuerOfPatientId.Text = String.Empty
			  textBoxName.Text = String.Empty
			  dateTimePickerBirth.Value = DateTime.Now
			  comboBoxSex.SelectedIndex = -1
		   End If
		End Sub

		Private Sub UpdatePatient()
			MainForm.Mpps.Patient.PatientID = textBoxId.Text
			MainForm.Mpps.Patient.IssuerofPatientID = textBoxIssuerOfPatientId.Text
			MainForm.Mpps.Patient.PatientName = textBoxName.Text
			MainForm.Mpps.Patient.PatientSex = comboBoxSex.Text

			If dateTimePickerBirth.Checked Then
				MainForm.Mpps.Patient.PatientBirthDate = New DicomDateRangeValue() With {.Date1 = New DicomDateValue(dateTimePickerBirth.Value)}
			End If
		End Sub

		Public Overrides Sub OnReset()
		   UpdateUI(True)
		End Sub
	End Class
End Namespace

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
Imports MPPSWCFDemo.Broker
Imports Leadtools.Dicom

Namespace MPPSWCFDemo.UI
   Public Partial Class PatientForm : Inherits Form
	  Private _Mpps As WCFPPSInformation

	  Public Sub New(ByVal mpps As WCFPPSInformation)
		 InitializeComponent()
		 _Mpps = mpps
	  End Sub

	  Private Sub PatientForm_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
		 If Not _Mpps.Patient Is Nothing Then
			Text = "Edit Patient [" & _Mpps.Patient.PatientID & "]"
			textBoxPatientId.Enabled = False
			textBoxIssuerOfPatientId.Enabled = False
			UpdateUI()
		 Else
			Text = "Add New Patient"
		 End If
	  End Sub

	  Public Function IsValid() As Boolean
		 Dim valid As Boolean = True

		 If textBoxPatientId.Text.Length = 0 Then
			valid = False
			errorProvider.SetError(textBoxPatientId, "Must provide patient id")
			textBoxPatientId.Focus()
		 Else
			errorProvider.SetError(textBoxPatientId, String.Empty)
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
		 textBoxPrefix.Text = _Mpps.Patient.PatientNamePrefix
		 textBoxFamily.Text = _Mpps.Patient.PatientNameFamilyName
		 textBoxGiven.Text = _Mpps.Patient.PatientNameGivenName
		 textBoxSuffix.Text = _Mpps.Patient.PatientNameSuffix
		 textBoxPatientId.Text = _Mpps.Patient.PatientID
		 textBoxIssuerOfPatientId.Text = _Mpps.Patient.IssuerOfPatientID

		 If _Mpps.Patient.PatientBirthDate.HasValue Then
			dateTimePickerBirth.Value = _Mpps.Patient.PatientBirthDate.Value.Date1.ToDateTime()
		 End If

		 If (Not String.IsNullOrEmpty(_Mpps.Patient.PatientSex)) Then
			Dim index As Integer = comboBoxSex.FindStringExact(_Mpps.Patient.PatientSex)

			comboBoxSex.SelectedIndex = index
		 Else
			comboBoxSex.Text = ""
		 End If

		 textBoxSpecialNeeds.Text = _Mpps.Patient.SpecialNeeds
		 textBoxComments.Text = _Mpps.Patient.PatientComments
	  End Sub

	  Private Sub UpdatePatient()
		 _Mpps.Patient.PatientID = textBoxPatientId.Text
		 _Mpps.Patient.IssuerOfPatientID = textBoxIssuerOfPatientId.Text
		 _Mpps.Patient.PatientNamePrefix = textBoxPrefix.Text
		 _Mpps.Patient.PatientNameFamilyName = textBoxFamily.Text
		 _Mpps.Patient.PatientNameGivenName = textBoxGiven.Text
		 _Mpps.Patient.PatientNameSuffix = textBoxSuffix.Text

		 If dateTimePickerBirth.Checked Then
            _Mpps.Patient.PatientBirthDate = New DicomDateRangeValue() With {.Date1 = New DicomDateValue(dateTimePickerBirth.Value)}
		 End If

		 _Mpps.Patient.PatientSex = comboBoxSex.Text
		 _Mpps.Patient.SpecialNeeds = textBoxSpecialNeeds.Text
		 _Mpps.Patient.PatientComments = textBoxComments.Text
	  End Sub

	  Private Sub PatientForm_FormClosing(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles MyBase.FormClosing
		 If DialogResult = System.Windows.Forms.DialogResult.OK Then
			e.Cancel = Not IsValid()
			If (Not e.Cancel) Then
			   If _Mpps.Patient Is Nothing Then
				  _Mpps.Patient = New WCFPatient()
			   End If
			   UpdatePatient()
			End If
		 End If
	  End Sub

	  Private Sub PatientForm_Paint(ByVal sender As Object, ByVal e As PaintEventArgs) Handles MyBase.Paint
		 PaintUtils.HighlightRequiredFields(Me, e.Graphics, True, Color.Red)
	  End Sub
   End Class
End Namespace

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
Imports ModalityWorklistWCFDemo.Broker

Namespace ModalityWorklistWCFDemo.UI
	Partial Public Class VisitEditor
		Inherits Form
		Private _Visit As WCFVisit

		Public ReadOnly Property Visit() As WCFVisit
			Get
				Return _Visit
			End Get
		End Property

		Private _OriginalAdmissionId As String = String.Empty

		Public ReadOnly Property OriginalAdmissionId() As String
			Get
				Return _OriginalAdmissionId
			End Get
		End Property

		Public Sub New(ByVal visit As WCFVisit)
			InitializeComponent()
			If visit Is Nothing Then
				_Visit = New WCFVisit()
				Text = "Add Visit"
			Else
				_Visit = visit
				Text = "Edit Visit"
				textBoxAdmissionId.Text = _Visit.AdmissionID
				textBoxLocation.Text = _Visit.CurrentPatientLocation
				propertyGridReferencedPatient.SelectedObject = _Visit.ReferencedPatientSequence
				_OriginalAdmissionId = visit.AdmissionID
			End If
		End Sub

		Private Sub VisitEditor_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
			AddHandler Application.Idle, AddressOf Application_Idle
			errorProvider1.SetIconAlignment(propertyGridReferencedPatient, ErrorIconAlignment.MiddleLeft)
		End Sub

		Private Sub Application_Idle(ByVal sender As Object, ByVal e As EventArgs)
			buttonAdd.Enabled = propertyGridReferencedPatient.SelectedObject Is Nothing
			buttonDelete.Enabled = Not buttonAdd.Enabled

			Dim buttonOKEnabled As Boolean = textBoxAdmissionId.Text.Length > 0
			buttonOK.Enabled = buttonOKEnabled
		End Sub

		Private Sub buttonAdd_Click(ByVal sender As Object, ByVal e As EventArgs) Handles buttonAdd.Click
			_Visit.ReferencedPatientSequence = New ReferencedPatientSequence()
			propertyGridReferencedPatient.SelectedObject = _Visit.ReferencedPatientSequence
		End Sub

		Private Sub buttonDelete_Click(ByVal sender As Object, ByVal e As EventArgs) Handles buttonDelete.Click
			propertyGridReferencedPatient.SelectedObject = Nothing
			_Visit.ReferencedPatientSequence = Nothing
			errorProvider1.SetError(propertyGridReferencedPatient, String.Empty)
		End Sub

		Private Sub VisitEditor_FormClosing(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles MyBase.FormClosing
			If DialogResult = System.Windows.Forms.DialogResult.OK Then
				_Visit.AdmissionID = textBoxAdmissionId.Text
				_Visit.CurrentPatientLocation = textBoxLocation.Text
				_Visit.ReferencedPatientSequence = TryCast(propertyGridReferencedPatient.SelectedObject, ReferencedPatientSequence)
				If _Visit.ReferencedPatientSequence IsNot Nothing Then

				   Dim isInvalid As Boolean = String.IsNullOrEmpty(_Visit.ReferencedPatientSequence.ReferencedSOPClassUID) OrElse String.IsNullOrEmpty(_Visit.ReferencedPatientSequence.ReferencedSOPInstanceUID)

				   If isInvalid Then
					  errorProvider1.SetError(propertyGridReferencedPatient, "Existing Referenced Patient Sequence Items cannot be null.")
				   End If

				   e.Cancel = isInvalid
				End If

			End If
		End Sub
	End Class
End Namespace

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
Imports Leadtools.DicomDemos

Namespace ModalityWorklistWCFDemo.UI.Pages
	Partial Public Class RequestedProcedurePage
		Inherits InternalTemplatePage
		Private _Update As Boolean = False
		Private _OriginalRequestedProcedureId As String

		Private _ImagingServiceRequest As ImagingServiceRequest

		Public ReadOnly Property ImagingServiceRequest() As ImagingServiceRequest
			Get
				Return _ImagingServiceRequest
			End Get
		End Property

		Private _RequestedProcedure As New WCFRequestedProcedure() With {.ReferencedStudySequence = New List(Of ReferencedStudySequence)()}

		Public ReadOnly Property RequestedProcedure() As WCFRequestedProcedure
			Get
				Return _RequestedProcedure
			End Get
		End Property

		Public Sub New()
			InitializeComponent()
			errorProvider.SetIconAlignment(comboBoxRequestedId, ErrorIconAlignment.TopLeft)
			AddHandler Application.Idle, AddressOf Application_Idle
		End Sub

		Private Sub Application_Idle(ByVal sender As Object, ByVal e As EventArgs)
			buttonAddRPCS.Enabled = propertyGridRequestedProcedure.SelectedObject Is Nothing
			buttonDeleteRPCS.Enabled = Not buttonAddRPCS.Enabled
			buttonDeleteRS.Enabled = listViewReferencedStudy.SelectedItems.Count = 1
			buttonEditRS.Enabled = buttonDeleteRS.Enabled
			buttonEditVisit.Enabled = textBoxAdmissionId.Text.Length > 0
			buttonDeleteVisit.Enabled = buttonEditVisit.Enabled
			buttonAddVisit.Enabled = textBoxAdmissionId.Text.Length = 0
		End Sub

		Protected Overrides Function GetWizardButtons() As WizardSheet.WizardButtons
			Dim buttons As WizardSheet.WizardButtons = MyBase.GetWizardButtons()

			buttons = buttons Or WizardSheet.WizardButtons.Option1
			Return buttons
		End Function

		Public Overrides Sub OnOptionButton1(ByVal sender As Object, ByVal e As EventArgs)
			UpdateUI(True)
		End Sub

		Public _clientRequestProcedurePageOnSetActive As BrokerServiceClient
	   Public _idsRequestedProcedurePageOnSetActive As List(Of String)
		Public Overrides Sub OnSetActive(ByVal sender As Object, ByVal e As WizardCancelEventArgs)
			MyBase.OnSetActive(sender, e)
			If e.PreviousPage IsNot Nothing AndAlso e.PreviousPage.GetType() Is GetType(ImagingServiceRequestPage) Then
				Dim p As ImagingServiceRequestPage = TryCast(e.PreviousPage, ImagingServiceRequestPage)
				Dim o As ImagingServiceRequest = _ImagingServiceRequest

				_ImagingServiceRequest = p.ImagingServiceRequest
				If o Is Nothing OrElse o.AccessionNumber <> _ImagingServiceRequest.AccessionNumber Then
					Dim dlgProgresss As New ProgressDialog()
					_clientRequestProcedurePageOnSetActive = TryCast(GetWizard().Tag, BrokerServiceClient)
					_idsRequestedProcedurePageOnSetActive = Nothing

					_idsRequestedProcedurePageOnSetActive = New List(Of String)()
					dlgProgresss.Title = "Find"
					dlgProgresss.Description = "Getting list of requested procedure ids"
					dlgProgresss.Action = AddressOf AnonymousMethodRequestedProcedurePageOnSetActive

					UpdateUI(True)
					comboBoxRequestedId.Items.Clear()
					If dlgProgresss.ShowDialog(Me) = DialogResult.OK Then
						For Each id As String In _idsRequestedProcedurePageOnSetActive
							comboBoxRequestedId.Items.Add(id)
						Next id
					End If

					If dlgProgresss.Exception IsNot Nothing Then
						Messager.ShowError(Me, dlgProgresss.Exception)
					End If

					If dlgProgresss.Exception IsNot Nothing Then
						Messager.ShowError(Me, dlgProgresss.Exception)
					End If
				End If
			End If
		End Sub
		Private Sub AnonymousMethodRequestedProcedurePageOnSetActive()
			_idsRequestedProcedurePageOnSetActive = _clientRequestProcedurePageOnSetActive.GetRequestedProcedureIDs(_ImagingServiceRequest.AccessionNumber)
		End Sub

		Public _clientOnWizardNext As BrokerServiceClient
		Public Overrides Sub OnWizardNext(ByVal sender As Object, ByVal e As WizardPageEventArgs)
			If (Not IsValid()) Then
				e.Cancel = True
				Return
			Else
				Dim dlgProgresss As New ProgressDialog()
				_clientOnWizardNext = TryCast(GetWizard().Tag, BrokerServiceClient)

				If _Update AndAlso comboBoxRequestedId.Text <> _OriginalRequestedProcedureId Then
					Dim r As DialogResult = Messager.ShowQuestion(Me, "You searched for a requested procedure but have changed some of the identifying information.  " & "Would you like to update this requested procedure with the new information?" & Constants.vbCrLf & Constants.vbCrLf & "Clicking No will add a new requested procedure.", MessageBoxButtons.YesNo)
					_Update = r = DialogResult.Yes
				End If

				UpdateRequestedProcedure()
				dlgProgresss.Title = If(_Update, "Update Requested Procedure", "Add Requested Procedure")
				dlgProgresss.Description = If(_Update, "Updating...", "Adding...")
				dlgProgresss.Action = AddressOf AnonymousMethod2

				If dlgProgresss.ShowDialog(Me) = DialogResult.Cancel Then
					If dlgProgresss.Exception IsNot Nothing Then
						e.Cancel = True
						Messager.ShowError(Me, dlgProgresss.Exception)
					End If
				Else
					If _Update Then
						Dim index As Integer = comboBoxRequestedId.Items.IndexOf(_OriginalRequestedProcedureId)

						If index <> -1 Then
							comboBoxRequestedId.Items.Remove(_OriginalRequestedProcedureId)
						End If
					End If
					comboBoxRequestedId.Items.Add(RequestedProcedure.RequestedProcedureID)
					comboBoxRequestedId.Text = RequestedProcedure.RequestedProcedureID
					_OriginalRequestedProcedureId = RequestedProcedure.RequestedProcedureID
				End If
			End If

			MyBase.OnWizardNext(sender, e)
		End Sub
		Private Sub AnonymousMethod2()
			If _Update Then
				_clientOnWizardNext.UpdateRequestedProcedure(_ImagingServiceRequest.AccessionNumber, _OriginalRequestedProcedureId, RequestedProcedure)
			Else
				_clientOnWizardNext.AddRequestedProcedure(_ImagingServiceRequest.AccessionNumber, RequestedProcedure)
			End If
		End Sub

		Private Function IsValid() As Boolean
			Dim valid As Boolean = True

			If String.IsNullOrEmpty(comboBoxRequestedId.Text) Then
				valid = False
				errorProvider.SetError(comboBoxRequestedId, "Must provide a value requested procedure id.")
			Else
				errorProvider.SetError(comboBoxRequestedId, String.Empty)
			End If

			If String.IsNullOrEmpty(textBoxStudyInstanceUID.Text) Then
				valid = False
				errorProvider.SetError(textBoxStudyInstanceUID, "Must provide a value for study instance uid.")
			Else
				errorProvider.SetError(textBoxStudyInstanceUID, String.Empty)
			End If

			If String.IsNullOrEmpty(textBoxDescription.Text) Then
				valid = False
				errorProvider.SetError(textBoxDescription, "Must provide a value for requested procedure description.")
			Else
				errorProvider.SetError(textBoxDescription, String.Empty)
			End If

			Return valid
		End Function

		Private Sub UpdateUI(ByVal clear As Boolean)
			If (Not clear) Then
				textBoxStudyInstanceUID.Text = _RequestedProcedure.StudyInstanceUID
				textBoxComments.Text = _RequestedProcedure.RequestedProcedureComments
				textBoxDescription.Text = _RequestedProcedure.RequestedProcedureDescription
				If _RequestedProcedure.Visit IsNot Nothing Then
				   textBoxAdmissionId.Text = _RequestedProcedure.Visit.AdmissionID
				   textBoxAdmissionId.Tag = _RequestedProcedure.Visit
				Else
				   textBoxAdmissionId.Tag = Nothing
				   textBoxAdmissionId.Text = String.Empty
				End If

				If (Not String.IsNullOrEmpty(_RequestedProcedure.RequestedProcedurePriority)) Then
					Dim index As Integer = comboBoxPriority.FindStringExact(_RequestedProcedure.RequestedProcedurePriority.ToUpper())

					comboBoxPriority.SelectedIndex = index
				End If

				propertyGridRequestedProcedure.SelectedObject = _RequestedProcedure.RequestedProcedureCodeSequence

				listViewReferencedStudy.Items.Clear()
				For Each rs As ReferencedStudySequence In _RequestedProcedure.ReferencedStudySequence
					AddReferencedStudy(rs)
				Next rs
			Else
				comboBoxRequestedId.Text = String.Empty
				textBoxStudyInstanceUID.Text = String.Empty
				textBoxComments.Text = String.Empty
				textBoxDescription.Text = String.Empty
				textBoxAdmissionId.Text = String.Empty
				comboBoxPriority.SelectedIndex = -1
				propertyGridRequestedProcedure.SelectedObject = Nothing
				listViewReferencedStudy.Items.Clear()
				_Update = False
				errorProvider.Clear()
			End If
		End Sub

		Private Sub UpdateRequestedProcedure()
			_RequestedProcedure.RequestedProcedureID = comboBoxRequestedId.Text
			_RequestedProcedure.StudyInstanceUID = textBoxStudyInstanceUID.Text
			_RequestedProcedure.RequestedProcedureComments = textBoxComments.Text
			_RequestedProcedure.RequestedProcedureDescription = textBoxDescription.Text
			_RequestedProcedure.RequestedProcedureCodeSequence = TryCast(propertyGridRequestedProcedure.SelectedObject, RequestedProcedureCodeSequence)
			_RequestedProcedure.RequestedProcedurePriority = comboBoxPriority.Text

			_RequestedProcedure.ReferencedStudySequence.Clear()
			For Each item As ListViewItem In listViewReferencedStudy.Items
				_RequestedProcedure.ReferencedStudySequence.Add(TryCast(item.Tag, ReferencedStudySequence))
			Next item
		End Sub

		Private Sub AddReferencedStudy(ByVal rs As ReferencedStudySequence)
			Dim item As ListViewItem = listViewReferencedStudy.Items.Add(rs.ReferencedSOPClassUID)

			item.SubItems.Add(rs.ReferencedSOPInstanceUID)			
			item.Tag = rs
		End Sub

		Public Overrides Sub OnReset()
			UpdateUI(True)
		End Sub

		Public _clientGetRequestedProcedureInfo As BrokerServiceClient
	   Public _idGetRequestedProcedureInfo As String
		Private Sub GetRequestedProcedureInfo()
			Dim dlgProgresss As New ProgressDialog()
			_clientGetRequestedProcedureInfo = TryCast(GetWizard().Tag, BrokerServiceClient)
			_idGetRequestedProcedureInfo = comboBoxRequestedId.Text

			dlgProgresss.Title = "Search"
			dlgProgresss.Description = "Searching for requested procedure"
			dlgProgresss.Action = AddressOf AnonymousMethod3

			_Update = False
			_OriginalRequestedProcedureId = String.Empty
			If dlgProgresss.ShowDialog(Me) = DialogResult.OK Then
				If _RequestedProcedure IsNot Nothing Then
					_Update = True
					UpdateUI(False)
					_OriginalRequestedProcedureId = _RequestedProcedure.RequestedProcedureID
					errorProvider.Clear()
				Else
					Messager.ShowError(Me, "Requested procedure not found.")
				End If
			Else
				If dlgProgresss.Exception IsNot Nothing Then
					Messager.ShowError(Me, dlgProgresss.Exception)
				End If
			End If
		End Sub
		Private Sub AnonymousMethod3()
			_RequestedProcedure = _clientGetRequestedProcedureInfo.FindRequestedProcedure(_ImagingServiceRequest.AccessionNumber, _idGetRequestedProcedureInfo)
		End Sub

		Private Sub buttonAddRPCS_Click(ByVal sender As Object, ByVal e As EventArgs) Handles buttonAddRPCS.Click
			propertyGridRequestedProcedure.SelectedObject = New RequestedProcedureCodeSequence()
		End Sub

		Private Sub buttonDeleteRPCS_Click(ByVal sender As Object, ByVal e As EventArgs) Handles buttonDeleteRPCS.Click
			propertyGridRequestedProcedure.SelectedObject = Nothing
		End Sub

		Private Sub buttonAddRS_Click(ByVal sender As Object, ByVal e As EventArgs) Handles buttonAddRS.Click
			Dim editor As New ObjectEditor(Of ReferencedStudySequence)(Nothing, "Referenced Study Sequence")

			If editor.ShowDialog(Me) = DialogResult.OK Then
				AddReferencedStudy(editor.EditObject)
			End If
		End Sub

		Private Sub buttonEditRS_Click(ByVal sender As Object, ByVal e As EventArgs) Handles buttonEditRS.Click
			Dim item As ListViewItem = listViewReferencedStudy.SelectedItems(0)
			Dim rs As ReferencedStudySequence = TryCast(item.Tag, ReferencedStudySequence)
			Dim editor As New ObjectEditor(Of ReferencedStudySequence)(rs, "Referenced Study Sequence")

			If editor.ShowDialog(Me) = DialogResult.OK Then
				item.Text = editor.EditObject.ReferencedSOPClassUID
				item.SubItems(1).Text = editor.EditObject.ReferencedSOPInstanceUID				
				item.Tag = editor.EditObject
			End If
		End Sub

		Private Sub buttonDeleteRS_Click(ByVal sender As Object, ByVal e As EventArgs) Handles buttonDeleteRS.Click
			Dim item As ListViewItem = listViewReferencedStudy.SelectedItems(0)

			listViewReferencedStudy.Items.Remove(item)
		End Sub

		Private Sub buttonEditVisit_Click(ByVal sender As Object, ByVal e As EventArgs) Handles buttonEditVisit.Click
		   Dim editor As New VisitEditor(_RequestedProcedure.Visit)

		   If editor.ShowDialog(Me) = DialogResult.OK Then
			  textBoxAdmissionId.Text = editor.Visit.AdmissionID
		   End If
		End Sub

      Private Sub buttonAddVisit_Click(ByVal sender As Object, ByVal e As EventArgs) Handles buttonAddVisit.Click
         Dim editor As New VisitEditor(Nothing)

         If editor.ShowDialog(Me) = DialogResult.OK Then
            _RequestedProcedure.Visit = editor.Visit
            textBoxAdmissionId.Text = editor.Visit.AdmissionID
         End If
      End Sub

		Private Sub buttonDeleteVisit_Click(ByVal sender As Object, ByVal e As EventArgs) Handles buttonDeleteVisit.Click
		   _RequestedProcedure.Visit = Nothing
		   textBoxAdmissionId.Text = String.Empty
		End Sub

		Private Sub RequestedProcedurePage_Paint(ByVal sender As Object, ByVal e As PaintEventArgs) Handles MyBase.Paint
			PaintUtils.HighlightRequiredFields(Me, e.Graphics, True, Color.Red)
		End Sub

		Private Sub comboBoxRequestedId_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles comboBoxRequestedId.SelectedIndexChanged
			If comboBoxRequestedId.SelectedIndex <> -1 Then
				GetRequestedProcedureInfo()
			End If
		End Sub

      Private Sub buttonNewUID_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles buttonNewUID.Click
         textBoxStudyInstanceUID.Text = Utils.GenerateDicomUniqueIdentifier()
      End Sub
   End Class
End Namespace

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
Imports ModalityWorklistWCFDemo.Broker
Imports Leadtools.Wizard
Imports Leadtools.Demos
Imports Leadtools.Dicom.Common.DataTypes

Namespace ModalityWorklistWCFDemo.UI.Pages
	Partial Public Class ScheduledProcedureStepPage
		Inherits InternalTemplatePage
		Private _RequestedProcedure As RequestedProcedure
		Private _ImagingServiceRequest As ImagingServiceRequest
		Private _ScheduledProcedureStep As New WCFScheduledProcedureStep() With {.ScheduledProtocolCodeSequence = New List(Of ScheduledProtocolCodeSequence)(), .ScheduledStationAETitle = New List(Of String)()}
		Private _OriginalScheduledProcedureId As String = String.Empty
		Private _Update As Boolean = False

		Public Sub New()
			InitializeComponent()
			errorProvider.SetIconAlignment(comboBoxId, ErrorIconAlignment.TopLeft)
			errorProvider.SetIconAlignment(textBoxDescription, ErrorIconAlignment.TopLeft)
			LoadModalities()
			AddHandler Application.Idle, AddressOf Application_Idle
		End Sub

		Private Sub LoadModalities()
			Dim modalities As IEnumerator(Of KeyValuePair(Of ModalityType, String)) = ModalityDescriptor.GetEnumerator()

			Do While modalities.MoveNext()
				comboBoxModality.Items.Add(modalities.Current.Key)
			Loop
		End Sub

		Private Sub Application_Idle(ByVal sender As Object, ByVal e As EventArgs)
			buttonEditSP.Enabled = listViewSPCS.SelectedItems.Count = 1
			buttonDeleteSP.Enabled = buttonEditSP.Enabled
		End Sub

		Protected Overrides Function GetWizardButtons() As WizardSheet.WizardButtons
			Dim buttons As WizardSheet.WizardButtons = MyBase.GetWizardButtons()

			buttons = buttons Or WizardSheet.WizardButtons.Option1 And (Not WizardSheet.WizardButtons.Next) Or WizardSheet.WizardButtons.Finish
			Return buttons
		End Function

		Public Overrides Sub OnOptionButton1(ByVal sender As Object, ByVal e As EventArgs)
			UpdateUI(True)
		End Sub

		Public _clientScheduledProcedureStepPageOnSetActive As BrokerServiceClient
		Private _idsScheduledProcedureStepPageOnSetActive As List(Of String)
		Public Overrides Sub OnSetActive(ByVal sender As Object, ByVal e As WizardCancelEventArgs)
			MyBase.OnSetActive(sender, e)
			If e.PreviousPage IsNot Nothing AndAlso e.PreviousPage.GetType() Is GetType(RequestedProcedurePage) Then
				Dim p As RequestedProcedurePage = TryCast(e.PreviousPage, RequestedProcedurePage)
				Dim [or] As RequestedProcedure = _RequestedProcedure
				Dim oi As ImagingServiceRequest = _ImagingServiceRequest


				_RequestedProcedure = p.RequestedProcedure
				_ImagingServiceRequest = p.ImagingServiceRequest
				If ([or] Is Nothing OrElse [or].RequestedProcedureID <> _RequestedProcedure.RequestedProcedureID) OrElse (oi Is Nothing OrElse oi.AccessionNumber <> _ImagingServiceRequest.AccessionNumber) Then
					Dim dlgProgresss As New ProgressDialog()
					_clientScheduledProcedureStepPageOnSetActive = TryCast(GetWizard().Tag, BrokerServiceClient)
					_idsScheduledProcedureStepPageOnSetActive = Nothing

					UpdateUI(True)
					comboBoxId.Items.Clear()
					dlgProgresss.Title = "Find"
					dlgProgresss.Description = "Getting list of scheduled procedure step ids"
					dlgProgresss.Action = AddressOf AnonymousMethodScheduledProcedureStepPageOnSetActive

					If dlgProgresss.ShowDialog(Me) = DialogResult.OK Then
						For Each id As String In _idsScheduledProcedureStepPageOnSetActive
							comboBoxId.Items.Add(id)
						Next id
					End If
					If dlgProgresss.Exception IsNot Nothing Then
						Messager.ShowError(Me, dlgProgresss.Exception)
					End If
				End If
			End If
		End Sub
		Private Sub AnonymousMethodScheduledProcedureStepPageOnSetActive()
		   _idsScheduledProcedureStepPageOnSetActive = _clientScheduledProcedureStepPageOnSetActive.GetScheduledProcedureStepIDs(_ImagingServiceRequest.AccessionNumber, _RequestedProcedure.RequestedProcedureID)
		End Sub


		Public _clientScheduledProcedureStepPageOnWizardFinish As BrokerServiceClient

		Public Overrides Sub OnWizardFinish(ByVal sender As Object, ByVal e As CancelEventArgs)
			If (Not IsValid()) Then
				e.Cancel = True
				Return
			Else
				Dim dlgProgresss As New ProgressDialog()
				_clientScheduledProcedureStepPageOnWizardFinish = TryCast(GetWizard().Tag, BrokerServiceClient)

				If _Update AndAlso comboBoxId.Text <> _OriginalScheduledProcedureId Then
					Dim r As DialogResult = Messager.ShowQuestion(Me, "You searched for a scheduled procedure but have changed te scheduled procedure UID.  " & "Would you like to update this scheduled procedure with the new UID?" & Constants.vbCrLf & Constants.vbCrLf & " Clicking No will add a new scheduled procedure.", MessageBoxButtons.YesNo)
					_Update = r = DialogResult.Yes
				End If

				UpdateScheduledProcedureStep()
				dlgProgresss.Title = If(_Update, "Update Scheduled Procedure", "Add Scheduled Procedure")
				dlgProgresss.Description = If(_Update, "Updating...", "Adding...")
				dlgProgresss.Action = AddressOf AnonymousMethodScheduledProcedureStepPageOnWizardFinish

				If dlgProgresss.ShowDialog(Me) = DialogResult.Cancel Then
					If dlgProgresss.Exception IsNot Nothing Then
						e.Cancel = True
						Messager.ShowError(Me, dlgProgresss.Exception)
						Return
					End If
				Else
					If _Update Then
						Dim index As Integer = comboBoxId.Items.IndexOf(_OriginalScheduledProcedureId)

						If index <> -1 Then
							comboBoxId.Items.Remove(_OriginalScheduledProcedureId)
						End If
					End If
					comboBoxId.Items.Add(_ScheduledProcedureStep.ScheduledProcedureStepID)
					comboBoxId.Text = _ScheduledProcedureStep.ScheduledProcedureStepID
					_OriginalScheduledProcedureId = _ScheduledProcedureStep.ScheduledProcedureStepID
				End If
			End If

			MyBase.OnWizardFinish(sender, e)
		End Sub
		Private Sub AnonymousMethodScheduledProcedureStepPageOnWizardFinish()
			If _Update Then
				_clientScheduledProcedureStepPageOnWizardFinish.UpdateScheduledProcedureStep(_OriginalScheduledProcedureId, _ScheduledProcedureStep)
			Else
				_clientScheduledProcedureStepPageOnWizardFinish.AddScheduledProcedureStep(_ImagingServiceRequest.AccessionNumber,_RequestedProcedure.RequestedProcedureID,_ScheduledProcedureStep)
			End If
		End Sub


		Public Function IsValid() As Boolean
			Dim valid As Boolean = True

			If String.IsNullOrEmpty(comboBoxId.Text) Then
				valid = False
				errorProvider.SetError(comboBoxId, "Must provide scheduled procedure step id")
			Else
				errorProvider.SetError(comboBoxId, String.Empty)
			End If

			If String.IsNullOrEmpty(comboBoxModality.Text) Then
				valid = False
				errorProvider.SetError(comboBoxModality, "Must provide a value for modality")
			Else
				errorProvider.SetError(comboBoxModality, String.Empty)
			End If

			If String.IsNullOrEmpty(textBoxDescription.Text) Then
				valid = False
				errorProvider.SetError(textBoxDescription, "Must provide a value for description")
			Else
				errorProvider.SetError(textBoxDescription, String.Empty)
         End If

         If String.IsNullOrEmpty(textBoxScheduledStationAE.Text) Then
            valid = False
            errorProvider.SetError(textBoxScheduledStationAE, "Must provide a value for scheduled station ae")
         Else
            errorProvider.SetError(textBoxScheduledStationAE, String.Empty)
         End If

			Return valid
		End Function


		''' <summary>
		''' Updates the UI.
		''' </summary>
		''' <remarks></remarks>
		Private Sub UpdateUI(ByVal clear As Boolean)
			If (Not clear) Then
				Dim aes As String = String.Empty

				textBoxLocation.Text = _ScheduledProcedureStep.ScheduledProcedureStepLocation
				If _ScheduledProcedureStep.ScheduledProcedureStepStartDate_Time.StartDate.HasValue Then
				   dateTimePickerStartDate.Value = _ScheduledProcedureStep.ScheduledProcedureStepStartDate_Time.StartDate.Value
				Else
				   dateTimePickerStartDate.Value = DateTime.Now
				End If
				comboBoxModality.Text = _ScheduledProcedureStep.Modality
				textBoxPrefix.Text = _ScheduledProcedureStep.ScheduledPerformingPhysicianNamePrefix
				textBoxGiven.Text = _ScheduledProcedureStep.ScheduledPerformingPhysicianNameGivenName
				textBoxFamily.Text = _ScheduledProcedureStep.ScheduledPerformingPhysicianNameFamilyName
				textBoxSuffix.Text = _ScheduledProcedureStep.ScheduledPerformingPhysicianNameSuffix
				textBoxDescription.Text = _ScheduledProcedureStep.ScheduledProcedureStepDescription
				For Each ae As String In _ScheduledProcedureStep.ScheduledStationAETitle
					If aes.Length > 0 Then
						aes &= ","
					End If
					aes &= ae
				Next ae
				textBoxScheduledStationAE.Text = aes

				listViewSPCS.Items.Clear()
				For Each spcs As ScheduledProtocolCodeSequence In _ScheduledProcedureStep.ScheduledProtocolCodeSequence
					AddScheduledProtocolCodeSequence(spcs)
				Next spcs
			Else
				comboBoxId.Text = String.Empty
				textBoxLocation.Text = String.Empty
				dateTimePickerStartDate.Value = DateTime.Now
				comboBoxModality.Text = String.Empty
				textBoxPrefix.Text = String.Empty
				textBoxGiven.Text = String.Empty
				textBoxFamily.Text = String.Empty
				textBoxSuffix.Text = String.Empty
				textBoxDescription.Text = String.Empty
				textBoxScheduledStationAE.Text = String.Empty
				listViewSPCS.Items.Clear()
				_Update = False
				errorProvider.Clear()
			End If
		End Sub

		Private Sub UpdateScheduledProcedureStep()
			_ScheduledProcedureStep.ScheduledProcedureStepID = comboBoxId.Text
			_ScheduledProcedureStep.ScheduledProcedureStepLocation = textBoxLocation.Text
			_ScheduledProcedureStep.Modality = comboBoxModality.Text
			_ScheduledProcedureStep.ScheduledPerformingPhysicianNamePrefix = textBoxPrefix.Text
			_ScheduledProcedureStep.ScheduledPerformingPhysicianNameGivenName = textBoxGiven.Text
			_ScheduledProcedureStep.ScheduledPerformingPhysicianNameFamilyName = textBoxFamily.Text
			_ScheduledProcedureStep.ScheduledPerformingPhysicianNameSuffix = textBoxSuffix.Text
			_ScheduledProcedureStep.ScheduledProcedureStepDescription = textBoxDescription.Text
			_ScheduledProcedureStep.ScheduledProcedureStepStartDate_Time = New DateRange() With {.StartDate = dateTimePickerStartDate.Value}

			_ScheduledProcedureStep.ScheduledStationAETitle.Clear()
			If textBoxScheduledStationAE.Text.Length > 0 Then
				Dim aes() As String = textBoxScheduledStationAE.Text.Split(","c, ControlChars.Cr, ControlChars.Lf, ";"c)

				For Each ae As String In aes
					_ScheduledProcedureStep.ScheduledStationAETitle.Add(ae.Trim())
				Next ae
			End If

			_ScheduledProcedureStep.ScheduledProtocolCodeSequence.Clear()
			For Each item As ListViewItem In listViewSPCS.Items
				_ScheduledProcedureStep.ScheduledProtocolCodeSequence.Add(TryCast(item.Tag, ScheduledProtocolCodeSequence))
			Next item
		End Sub

		Private Sub AddScheduledProtocolCodeSequence(ByVal sequence As ScheduledProtocolCodeSequence)
			Dim item As ListViewItem = listViewSPCS.Items.Add(sequence.CodeValue)

			item.SubItems.Add(sequence.CodingSchemeDesignator)
			item.SubItems.Add(sequence.CodeMeaning)
			item.SubItems.Add(sequence.CodingSchemeVersion)			
			item.Tag = sequence
		End Sub

		Public Overrides Sub OnReset()
			UpdateUI(True)
		End Sub

		Public _idScheduledProcedureStepPageGetScheduledProcedureStepInfo As String
	   Private _clientScheduledProcedureStepPageGetScheduledProcedureStepInfo As BrokerServiceClient
		Private Sub GetScheduledProcedureStepInfo()
			Dim dlgProgresss As New ProgressDialog()
			_clientScheduledProcedureStepPageGetScheduledProcedureStepInfo = TryCast(GetWizard().Tag, BrokerServiceClient)
			_idScheduledProcedureStepPageGetScheduledProcedureStepInfo = comboBoxId.Text

			dlgProgresss.Title = "Search"
			dlgProgresss.Description = "Searching for scheduled procedure step"
			dlgProgresss.Action = AddressOf AnonymousMethod3

			_Update = False
			_OriginalScheduledProcedureId = String.Empty
			If dlgProgresss.ShowDialog(Me) = DialogResult.OK Then
				If _ScheduledProcedureStep IsNot Nothing Then
					_Update = True
					UpdateUI(False)
					_OriginalScheduledProcedureId = _ScheduledProcedureStep.ScheduledProcedureStepID
					errorProvider.Clear()
				Else
					Messager.ShowError(Me, "Schedule procedure step not found.")
				End If
			Else
				If dlgProgresss.Exception IsNot Nothing Then
					Messager.ShowError(Me, dlgProgresss.Exception)
				End If
			End If
		End Sub
		Private Sub AnonymousMethod3()
		   _ScheduledProcedureStep = _clientScheduledProcedureStepPageGetScheduledProcedureStepInfo.FindScheduledProcedureStep(_idScheduledProcedureStepPageGetScheduledProcedureStepInfo)
		End Sub

		Private Sub buttonAddSP_Click(ByVal sender As Object, ByVal e As EventArgs) Handles buttonAddSP.Click
			Dim editor As New ObjectEditor(Of ScheduledProtocolCodeSequence)(Nothing, "Scheduled Protocol Sequence")

			If editor.ShowDialog(Me) = DialogResult.OK Then
				AddScheduledProtocolCodeSequence(editor.EditObject)
			End If
		End Sub

		Private Sub buttonEditSP_Click(ByVal sender As Object, ByVal e As EventArgs) Handles buttonEditSP.Click
			Dim item As ListViewItem = listViewSPCS.SelectedItems(0)
			Dim sequence As ScheduledProtocolCodeSequence = TryCast(item.Tag, ScheduledProtocolCodeSequence)
			Dim editor As New ObjectEditor(Of ScheduledProtocolCodeSequence)(sequence, "Scheduled Protocol Sequence")

			If editor.ShowDialog(Me) = DialogResult.OK Then
				item.Text = editor.EditObject.CodeValue
				item.SubItems(1).Text = editor.EditObject.CodingSchemeDesignator
				item.SubItems(2).Text = editor.EditObject.CodeMeaning
				item.SubItems(3).Text = editor.EditObject.CodingSchemeVersion				
				item.Tag = editor.EditObject
			End If
		End Sub

		Private Sub buttonDeleteSP_Click(ByVal sender As Object, ByVal e As EventArgs) Handles buttonDeleteSP.Click
			Dim item As ListViewItem = listViewSPCS.SelectedItems(0)

			listViewSPCS.Items.Remove(item)
		End Sub

		Private Sub ScheduledProcedureStepPage_Paint(ByVal sender As Object, ByVal e As PaintEventArgs) Handles MyBase.Paint
			PaintUtils.HighlightRequiredFields(Me, e.Graphics, True, Color.Red)
		End Sub

		Private Sub comboBoxId_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles comboBoxId.SelectedIndexChanged
			If comboBoxId.SelectedIndex <> -1 Then
				GetScheduledProcedureStepInfo()
			End If
		End Sub
	End Class
End Namespace

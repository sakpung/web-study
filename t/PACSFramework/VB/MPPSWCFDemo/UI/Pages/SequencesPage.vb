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
Imports MPPSWCFDemo.Broker
Imports Leadtools.Wizard
Imports Leadtools.Demos
Imports Leadtools.Dicom.Common.DataTypes

Namespace MPPSWCFDemo.UI.Pages
	Partial Public Class SequencesPage
		Inherits InternalTemplatePage
		Public Sub New()
			InitializeComponent()
			AddHandler Application.Idle, AddressOf Application_Idle
		End Sub

		Private Sub Application_Idle(ByVal sender As Object, ByVal e As EventArgs)
			EnableEditButtons(listViewReasonCode, buttonEditReasonCode, buttonDeleteReasonCode)
			EnableEditButtons(listViewCodeSequence, buttonEditCodeSequence, buttonDeleteCodeSequence)
			EnableEditButtons(listViewProtocol, buttonEditProtocol, buttonDeleteProtocol)
		End Sub

		Private Sub EnableEditButtons(ByVal listView As ListView, ByVal edit As Button, ByVal delete As Button)
			edit.Enabled = listView.SelectedItems.Count = 1
			delete.Enabled = edit.Enabled
		End Sub

		Protected Overrides Function GetWizardButtons() As WizardSheet.WizardButtons
			Dim buttons As WizardSheet.WizardButtons = MyBase.GetWizardButtons()

			buttons = buttons Or WizardSheet.WizardButtons.Option1
			Return buttons
		End Function

		Public Overrides Sub OnOptionButton1(ByVal sender As Object, ByVal e As EventArgs)
			UpdateUI(True)
		End Sub

		Public Overrides Sub OnSetActive(ByVal sender As Object, ByVal e As WizardCancelEventArgs)
			MyBase.OnSetActive(sender, e)
			LoadSequences()
		End Sub

	   Public _clientSequencesPageOnWizardNext As BrokerServiceClient
		Public Overrides Sub OnWizardNext(ByVal sender As Object, ByVal e As WizardPageEventArgs)
			Dim dlgProgresss As New ProgressDialog()
			_clientSequencesPageOnWizardNext = TryCast(GetWizard().Tag, BrokerServiceClient)

			MyBase.OnWizardNext(sender, e)
			UpdateMPPS()

			dlgProgresss.Title = "Update MPPS"
			dlgProgresss.Description = "Updating..."
			dlgProgresss.Action = AddressOf AnonymousMethod1

			If dlgProgresss.ShowDialog(Me) = DialogResult.Cancel Then
				If dlgProgresss.Exception IsNot Nothing Then
					e.Cancel = True
					Messager.ShowError(Me, dlgProgresss.Exception)
				End If
			End If
		End Sub
		Private Sub AnonymousMethod1()
			_clientSequencesPageOnWizardNext.UpdateMPPS(MainForm.Mpps.MPPSSOPInstanceUID, MainForm.Mpps)
		End Sub

		Private Sub UpdateMPPS()
			MainForm.Mpps.PPSDiscontinuationReasonCodeSequence.Clear()
			For Each item As ListViewItem In listViewReasonCode.Items
				Dim s As PPSDiscontinuationReasonCodeSequence = TryCast(item.Tag, PPSDiscontinuationReasonCodeSequence)

				MainForm.Mpps.PPSDiscontinuationReasonCodeSequence.Add(s)
			Next item

			MainForm.Mpps.ProcedureCodeSequence.Clear()
			For Each item As ListViewItem In listViewCodeSequence.Items
				Dim s As ProcedureCodeSequence = TryCast(item.Tag, ProcedureCodeSequence)

				MainForm.Mpps.ProcedureCodeSequence.Add(s)
			Next item

			MainForm.Mpps.PerformedProtocolCodeSequence.Clear()
			For Each item As ListViewItem In listViewProtocol.Items
				Dim s As PerformedProtocolCodeSequence = TryCast(item.Tag, PerformedProtocolCodeSequence)

				MainForm.Mpps.PerformedProtocolCodeSequence.Add(s)
			Next item
		End Sub


		''' <summary>
		''' Updates the UI.
		''' </summary>
		''' <remarks></remarks>
		Private Sub UpdateUI(ByVal clear As Boolean)
			If (Not clear) Then
				LoadSequences()
			Else
				ClearSequences()
			End If
		End Sub

		Private Sub LoadSequences()
			ClearSequences()
			For Each s As PPSDiscontinuationReasonCodeSequence In MainForm.Mpps.PPSDiscontinuationReasonCodeSequence
				AddPPSDiscontinuationReasonCodeSequence(s)
			Next s

			For Each s As ProcedureCodeSequence In MainForm.Mpps.ProcedureCodeSequence
				AddProcedureCodeSequence(s)
			Next s

			For Each s As PerformedProtocolCodeSequence In MainForm.Mpps.PerformedProtocolCodeSequence
				AddPerformedProtocolCodeSequence(s)
			Next s
		End Sub

		Public Sub ClearSequences()
			listViewReasonCode.Items.Clear()
			listViewCodeSequence.Items.Clear()
			listViewProtocol.Items.Clear()
		End Sub

		Private Sub AddPPSDiscontinuationReasonCodeSequence(ByVal sequence As PPSDiscontinuationReasonCodeSequence)
			Dim item As ListViewItem = listViewReasonCode.Items.Add(sequence.CodeValue)

			item.SubItems.Add(sequence.CodingSchemeDesignator)
			item.SubItems.Add(sequence.CodeMeaning)
			item.SubItems.Add(sequence.CodingSchemeVersion)
			item.SubItems.Add(sequence.OrderNumber)
			item.Tag = sequence
		End Sub

		Private Sub AddProcedureCodeSequence(ByVal sequence As ProcedureCodeSequence)
			Dim item As ListViewItem = listViewCodeSequence.Items.Add(sequence.CodeValue)

			item.SubItems.Add(sequence.CodingSchemeDesignator)
			item.SubItems.Add(sequence.CodeMeaning)
			item.SubItems.Add(sequence.CodingSchemeVersion)
			item.SubItems.Add(sequence.OrderNumber)
			item.Tag = sequence
		End Sub

		Private Sub AddPerformedProtocolCodeSequence(ByVal sequence As PerformedProtocolCodeSequence)
			Dim item As ListViewItem = listViewProtocol.Items.Add(sequence.CodeValue)

			item.SubItems.Add(sequence.CodingSchemeDesignator)
			item.SubItems.Add(sequence.CodeMeaning)
			item.SubItems.Add(sequence.CodingSchemeVersion)
			item.SubItems.Add(sequence.OrderNumber)
			item.Tag = sequence
		End Sub

		Public Overrides Sub OnReset()
			UpdateUI(True)
		End Sub

		Private Sub EditSequence(Of T As Class)(ByVal listView As ListView, ByVal description As String)
			Dim item As ListViewItem = listView.SelectedItems(0)
			Dim sequence As T = TryCast(item.Tag, T)
			Dim editor As New ObjectEditor(Of T)(sequence, description)

			If editor.ShowDialog(Me) = DialogResult.OK Then
				Dim myType As Type = GetType(T)

				item.Text = TryCast(myType.GetProperty("CodeValue").GetValue(editor.EditObject,Nothing), String)
				item.SubItems(1).Text = TryCast(myType.GetProperty("CodingSchemeDesignator").GetValue(editor.EditObject, Nothing), String)
				item.SubItems(2).Text = TryCast(myType.GetProperty("CodeMeaning").GetValue(editor.EditObject, Nothing), String)
				item.SubItems(3).Text = TryCast(myType.GetProperty("CodingSchemeVersion").GetValue(editor.EditObject, Nothing), String)
				item.SubItems(4).Text = TryCast(myType.GetProperty("OrderNumber").GetValue(editor.EditObject, Nothing), String)
				item.Tag = editor.EditObject
			End If
		End Sub

		Private Sub RemoveSelectedItem(ByVal listview As ListView)
			Dim item As ListViewItem = listview.SelectedItems(0)

			listview.Items.Remove(item)
		End Sub

		Private Sub buttonAddReasonCode_Click(ByVal sender As Object, ByVal e As EventArgs) Handles buttonAddReasonCode.Click
			Dim editor As New ObjectEditor(Of PPSDiscontinuationReasonCodeSequence)(Nothing, "PPS Discontinuation Reason Code Sequence")

			If editor.ShowDialog(Me) = DialogResult.OK Then
			   Dim sequence As PPSDiscontinuationReasonCodeSequence = TryCast(editor.EditObject, PPSDiscontinuationReasonCodeSequence)

			   If String.IsNullOrEmpty(sequence.CodeValue) OrElse String.IsNullOrEmpty(sequence.CodingSchemeDesignator) Then
				  Messager.ShowError(Me, "Must provide a value for CodeValue and CodingSchemeDesignator.  Item not added to sequence.")
			   Else
				  AddPPSDiscontinuationReasonCodeSequence(editor.EditObject)
			   End If
			End If
		End Sub

		Private Sub buttonEditReasonCode_Click(ByVal sender As Object, ByVal e As EventArgs) Handles buttonEditReasonCode.Click
			EditSequence(Of PPSDiscontinuationReasonCodeSequence)(listViewReasonCode, "PPS Discontinuation Reason Code Sequence")
		End Sub

		Private Sub buttonDeleteReasonCode_Click(ByVal sender As Object, ByVal e As EventArgs) Handles buttonDeleteReasonCode.Click
			RemoveSelectedItem(listViewReasonCode)
		End Sub

		Private Sub buttonAddCodeSequence_Click(ByVal sender As Object, ByVal e As EventArgs) Handles buttonAddCodeSequence.Click
			Dim editor As New ObjectEditor(Of ProcedureCodeSequence)(Nothing, "Procedure Code Sequence")

			If editor.ShowDialog(Me) = DialogResult.OK Then
			   Dim sequence As ProcedureCodeSequence = TryCast(editor.EditObject, ProcedureCodeSequence)

			   If String.IsNullOrEmpty(sequence.CodeValue) OrElse String.IsNullOrEmpty(sequence.CodingSchemeDesignator) Then
				  Messager.ShowError(Me, "Must provide a value for CodeValue and CodingSchemeDesignator.  Item not added to sequence.")
			   Else
				  AddProcedureCodeSequence(editor.EditObject)
			   End If
			End If
		End Sub

		Private Sub buttonEditCodeSequence_Click(ByVal sender As Object, ByVal e As EventArgs) Handles buttonEditCodeSequence.Click
			EditSequence(Of ProcedureCodeSequence)(listViewCodeSequence, "Procedure Code Sequence")
		End Sub

		Private Sub buttonDeleteCodeSequence_Click(ByVal sender As Object, ByVal e As EventArgs) Handles buttonDeleteCodeSequence.Click
			RemoveSelectedItem(listViewCodeSequence)
		End Sub

		Private Sub buttonAddProtocol_Click(ByVal sender As Object, ByVal e As EventArgs) Handles buttonAddProtocol.Click
			Dim editor As New ObjectEditor(Of PerformedProtocolCodeSequence)(Nothing, "Performed Protocol Sequence")

			If editor.ShowDialog(Me) = DialogResult.OK Then
			   Dim sequence As PerformedProtocolCodeSequence = TryCast(editor.EditObject, PerformedProtocolCodeSequence)

			   If String.IsNullOrEmpty(sequence.CodeValue) OrElse String.IsNullOrEmpty(sequence.CodingSchemeDesignator) Then
				  Messager.ShowError(Me, "Must provide a value for CodeValue and CodingSchemeDesignator.  Item not added to sequence.")
			   Else
				  AddPerformedProtocolCodeSequence(editor.EditObject)
			   End If
			End If
		End Sub

		Private Sub buttonEditProtocol_Click(ByVal sender As Object, ByVal e As EventArgs) Handles buttonEditProtocol.Click
			EditSequence(Of PerformedProtocolCodeSequence)(listViewProtocol, "Performed Protocol Code Sequence")
		End Sub

		Private Sub buttonDeleteProtocol_Click(ByVal sender As Object, ByVal e As EventArgs) Handles buttonDeleteProtocol.Click
			RemoveSelectedItem(listViewProtocol)
		End Sub
	End Class
End Namespace

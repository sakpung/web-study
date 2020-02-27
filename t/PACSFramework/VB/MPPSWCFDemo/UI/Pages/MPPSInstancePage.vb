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
Imports Leadtools.Dicom
Imports Leadtools.Dicom.Common.DataTypes

Namespace MPPSWCFDemo.UI.Pages
   Partial Public Class MPPSInstancePage : Inherits InternalTemplatePage
      Private _OriginalMppsInstance As String = String.Empty

      Public Sub New()
         InitializeComponent()
         LoadModalities()
      End Sub

      Private Sub LoadModalities()
         Dim modalities As IEnumerator(Of KeyValuePair(Of ModalityType, String)) = ModalityDescriptor.GetEnumerator()

         While modalities.MoveNext()
            comboBoxModality.Items.Add(modalities.Current.Key)
         End While
      End Sub

      Protected Overrides Function GetWizardButtons() As WizardSheet.WizardButtons
         Dim buttons As WizardSheet.WizardButtons = MyBase.GetWizardButtons()

         buttons = buttons Or WizardSheet.WizardButtons.Option1
         Return buttons
      End Function

      Public Overrides Sub OnSetActive(ByVal sender As Object, ByVal e As WizardCancelEventArgs)
         MyBase.OnSetActive(sender, e)

         If TypeOf e.PreviousPage Is IntroductionPage Then
            buttonQuery_Click(buttonQuery, EventArgs.Empty)
         End If

      End Sub
      Public Sub Action_UpdateMPPS()
         Dim client As BrokerServiceClient = TryCast(GetWizard().Tag, BrokerServiceClient)

         client.UpdateMPPS(MainForm.Mpps.MPPSSOPInstanceUID, MainForm.Mpps)
      End Sub

      Public Sub Action_UpdatePatient()
         Dim client As BrokerServiceClient = TryCast(GetWizard().Tag, BrokerServiceClient)

         client.UpdatePatient(MainForm.Mpps.Patient.PatientID, MainForm.Mpps.Patient.IssuerOfPatientID, MainForm.Mpps.Patient)
      End Sub

      Public Overrides Sub OnWizardNext(ByVal sender As Object, ByVal e As WizardPageEventArgs)
         If (Not IsValid()) Then
            e.Cancel = True
            Return
         Else
            Dim dlgProgresss As ProgressDialog = New ProgressDialog()
            Dim client As BrokerServiceClient = TryCast(GetWizard().Tag, BrokerServiceClient)

            UpdateMpps()
            dlgProgresss.Title = "Update MPPS"
            dlgProgresss.Description = "Updating..."
            dlgProgresss.Action = New Action(AddressOf Action_UpdateMPPS)
            If dlgProgresss.ShowDialog(Me) = DialogResult.Cancel Then
               If Not dlgProgresss.Exception Is Nothing Then
                  e.Cancel = True
                  Messager.ShowError(Me, dlgProgresss.Exception)
               End If
            End If

            dlgProgresss.Title = "Update Patient"
            dlgProgresss.Description = "Updating..."
            dlgProgresss.Action = New Action(AddressOf Action_UpdatePatient)

            If dlgProgresss.ShowDialog(Me) = DialogResult.Cancel Then
               If Not dlgProgresss.Exception Is Nothing Then
                  e.Cancel = True
                  Messager.ShowError(Me, dlgProgresss.Exception)
               End If
            End If
         End If
         MyBase.OnWizardNext(sender, e)
      End Sub

      Public Overrides Sub OnOptionButton1(ByVal sender As Object, ByVal e As EventArgs)
         UpdateUI(True)
      End Sub

      Public Function IsValid() As Boolean
         Dim valid As Boolean = True

         ValidateMPPS(textBoxPPSId, "Must provide a value for performed procedure step id", valid)
         ValidateMPPS(textBoxStationAE, "Must provide a value for performed station ae title", valid)
         ValidateMPPS(comboBoxStatus, "Must provide a value for performed procedure step status", valid)
         ValidateMPPS(comboBoxModality, "Must provide a value for modality", valid)
         ValidateMPPS(textBoxStudyInstance, "Must provide a value for study instance uid", valid)

         Return valid
      End Function


      Private Sub ValidateMPPS(ByVal control As Control, ByVal [error] As String, ByRef valid As Boolean)
         If control.Text.Length = 0 Then
            errorProvider.SetError(control, [error])
            valid = False
         Else
            errorProvider.SetError(control, String.Empty)
         End If
      End Sub

      Private Sub UpdateUI(ByVal clear As Boolean)
         If (Not clear) Then
            textBoxMPPSInstance.Text = MainForm.Mpps.MPPSSOPInstanceUID
            textBoxPPSId.Text = MainForm.Mpps.PerformedProcedureStepID
            textBoxStationAE.Text = MainForm.Mpps.PerformedStationAETitle
            textBoxStationName.Text = MainForm.Mpps.PerformedStationName
            textBoxLocation.Text = MainForm.Mpps.PerformedLocation
            comboBoxStatus.Text = MainForm.Mpps.PerformedProcedureStepStatus
            dateTimePickerStartDate.Value = MainForm.Mpps.PerformedProcedureStepStartDate.Value.Date1.ToDateTime()
            dateTimePickerStartTime.Value = MainForm.Mpps.PerformedProcedureStepStartTime.Value.Time1.ToDateTime()
            If MainForm.Mpps.PerformedProcedureStepEndDate.HasValue Then
               dateTimePickerEndDate.Value = MainForm.Mpps.PerformedProcedureStepEndDate.Value.Date1.ToDateTime()
               dateTimePickerEndDate.Checked = True
            Else
               dateTimePickerEndDate.Checked = False
            End If
            If MainForm.Mpps.PerformedProcedureStepEndTime.HasValue Then
               dateTimePickerEndTime.Value = MainForm.Mpps.PerformedProcedureStepEndTime.Value.Time1.ToDateTime()
               dateTimePickerEndTime.Checked = True
            Else
               dateTimePickerEndTime.Checked = False
            End If
            comboBoxModality.Text = MainForm.Mpps.Modality
            textBoxStudyInstance.Text = MainForm.Mpps.StudyInstanceUID
            textBoxDescription.Text = MainForm.Mpps.PerformedProcedureStepDescription
            textBoxComments.Text = MainForm.Mpps.CommentsonthePerformedProcedureStep
            SetPatientInfo()
         Else
            textBoxMPPSInstance.Text = String.Empty
            textBoxPPSId.Text = String.Empty
            textBoxStationAE.Text = String.Empty
            textBoxStationName.Text = String.Empty
            textBoxLocation.Text = String.Empty
            comboBoxStatus.SelectedIndex = -1
            dateTimePickerStartDate.Value = DateTime.Now
            dateTimePickerStartTime.Value = DateTime.Now
            dateTimePickerEndDate.Value = DateTime.Now
            dateTimePickerEndDate.Checked = False
            dateTimePickerEndTime.Value = DateTime.Now
            dateTimePickerEndTime.Checked = False
            comboBoxModality.SelectedIndex = -1
            textBoxStudyInstance.Text = String.Empty
            textBoxDescription.Text = String.Empty
            textBoxComments.Text = String.Empty
            labelPatient.Text = String.Empty
            errorProvider.Clear()
         End If
      End Sub

      Private Sub UpdateMpps()
         If MainForm.Mpps Is Nothing Then
            MainForm.Mpps = New WCFPPSInformation()
            MainForm.Mpps.PPSDiscontinuationReasonCodeSequence = New List(Of PPSDiscontinuationReasonCodeSequence)()
            MainForm.Mpps.ProcedureCodeSequence = New List(Of ProcedureCodeSequence)()
            MainForm.Mpps.PerformedProtocolCodeSequence = New List(Of PerformedProtocolCodeSequence)()
            MainForm.Mpps.PPSRelationShip = New List(Of PPSRelationship)()
            MainForm.Mpps.PerformedSeriesSequence = New List(Of PerformedSeriesSequence)()
            MainForm.Mpps.ReferencedImageSequence = New List(Of WCFReferencedImageSequence)()
            MainForm.Mpps.ReferencedNonImageCompositeSequence = New List(Of ReferencedNonImageCompositeSequence)()
            MainForm.Mpps.UnscheduledPatient = New PatientInfoforUnscheduledPPS()
         End If

         MainForm.Mpps.MPPSSOPInstanceUID = textBoxMPPSInstance.Text
         MainForm.Mpps.PerformedProcedureStepID = textBoxPPSId.Text
         MainForm.Mpps.PerformedStationAETitle = textBoxStationAE.Text
         MainForm.Mpps.PerformedStationName = textBoxStationName.Text
         MainForm.Mpps.PerformedLocation = textBoxLocation.Text
         MainForm.Mpps.PerformedProcedureStepStatus = comboBoxStatus.Text
         MainForm.Mpps.PerformedProcedureStepStartDate = New DicomDateRangeValue() With {.Date1 = New DicomDateValue(dateTimePickerStartDate.Value)}
         MainForm.Mpps.PerformedProcedureStepStartTime = New DicomTimeRangeValue() With {.Time1 = New DicomTimeValue(dateTimePickerStartTime.Value)}
         If dateTimePickerEndDate.Checked Then
            MainForm.Mpps.PerformedProcedureStepEndDate = New DicomDateRangeValue() With {.Date1 = New DicomDateValue(dateTimePickerEndDate.Value)}
            MainForm.Mpps.PerformedProcedureStepEndTime = New DicomTimeRangeValue() With {.Time1 = New DicomTimeValue(dateTimePickerEndTime.Value)}
         End If
         MainForm.Mpps.Modality = comboBoxModality.Text
         MainForm.Mpps.StudyInstanceUID = textBoxStudyInstance.Text
         MainForm.Mpps.PerformedProcedureStepDescription = textBoxDescription.Text
         MainForm.Mpps.CommentsonthePerformedProcedureStep = textBoxComments.Text
      End Sub

      Public Overrides Sub OnReset()
         UpdateUI(True)
      End Sub

      Private Sub SetPatientInfo()
         If Not MainForm.Mpps.Patient Is Nothing Then
            Dim p As WCFPatient = MainForm.Mpps.Patient

            labelPatient.Text = String.Format("[{0}] {1} {2}", p.PatientID, p.PatientNameGivenName, p.PatientNameFamilyName)
         Else
            labelPatient.Text = "Not Associated With A Patient"
         End If
      End Sub

      Private Sub MPPSInstancePage_Paint(ByVal sender As Object, ByVal e As PaintEventArgs) Handles MyBase.Paint
         PaintUtils.HighlightRequiredFields(Me, e.Graphics, True, Color.Red)
      End Sub

      Private Sub MPPSInstancePage_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
         GetWizard().Option1Caption = "Clear"

         AddHandler Application.Idle, AddressOf Application_Idle
      End Sub

      Private Sub Application_Idle(ByVal sender As Object, ByVal e As EventArgs)
         buttonDelete.Enabled = textBoxMPPSInstance.Text.Length > 0
         If GetWizard().ActivePage Is Me Then
            GetWizard().NextButton.Enabled = MainForm.Mpps IsNot Nothing
         End If
         linkLabelPatient.Enabled = Not MainForm.Mpps Is Nothing
      End Sub

      Private Sub dateTimePickerEndDate_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs) Handles dateTimePickerEndDate.MouseDown
         dateTimePickerEndTime.Checked = dateTimePickerEndDate.Checked
      End Sub

      Private Sub dateTimePickerEndTime_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs) Handles dateTimePickerEndTime.MouseDown
         dateTimePickerEndDate.Checked = dateTimePickerEndTime.Checked
      End Sub

      Private Sub dateTimePickerEndDate_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles dateTimePickerEndDate.KeyDown
         If e.KeyCode = Keys.Space Then
            dateTimePickerEndTime.Checked = Not dateTimePickerEndDate.Checked
         End If
      End Sub

      Private Sub dateTimePickerEndTime_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles dateTimePickerEndTime.KeyDown
         If e.KeyCode = Keys.Space Then
            dateTimePickerEndDate.Checked = Not dateTimePickerEndTime.Checked
         End If
      End Sub

      Private Sub buttonQuery_Click(ByVal sender As Object, ByVal e As EventArgs) Handles buttonQuery.Click
         Dim queryForm As QueryForm = New QueryForm(TryCast(GetWizard().Tag, BrokerServiceClient))

         If queryForm.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK Then
            MainForm.Mpps = queryForm.PPSInfo
            errorProvider.Clear()
            UpdateUI(False)            
         End If
      End Sub

      Sub Action_DeleteMPPS()
         Dim client As BrokerServiceClient = TryCast(GetWizard().Tag, BrokerServiceClient)

         client.DeleteMPPS(MainForm.Mpps.MPPSSOPInstanceUID)
      End Sub

      Private Sub buttonDelete_Click(ByVal sender As Object, ByVal e As EventArgs) Handles buttonDelete.Click
         Dim dlgProgresss As ProgressDialog = New ProgressDialog()

         dlgProgresss.Title = "Deleting MPPS"
         dlgProgresss.Description = "Deleting..."
         dlgProgresss.Action = New Action(AddressOf Action_DeleteMPPS)

         If dlgProgresss.ShowDialog(Me) = DialogResult.Cancel Then
            If Not dlgProgresss.Exception Is Nothing Then
               Messager.ShowError(Me, dlgProgresss.Exception)
            End If
         Else
            OnReset()
            buttonQuery_Click(buttonQuery, EventArgs.Empty)
         End If
      End Sub

      Private Sub linkLabelPatient_LinkClicked(ByVal sender As Object, ByVal e As LinkLabelLinkClickedEventArgs) Handles linkLabelPatient.LinkClicked
         Dim patientForm As PatientForm = New PatientForm(MainForm.Mpps)

         If patientForm.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK Then
            SetPatientInfo()
         End If
      End Sub
   End Class
End Namespace

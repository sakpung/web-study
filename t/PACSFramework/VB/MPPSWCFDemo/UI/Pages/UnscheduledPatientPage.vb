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
   Partial Public Class UnscheduledPatientPage : Inherits InternalTemplatePage
      Public Sub New()
         InitializeComponent()
      End Sub

      Public Overrides Sub OnSetActive(ByVal sender As Object, ByVal e As WizardCancelEventArgs)
         MyBase.OnSetActive(sender, e)
         labelUnscheduled.Visible = Not MainForm.Mpps.Patient Is Nothing
         If (Not labelUnscheduled.Visible) Then
            UpdateUI(False)
         End If
         SetControlsState()
      End Sub

      Private Sub SetControlsState()
         For Each control As Control In Controls
            If Not control Is labelUnscheduled Then
               control.Enabled = Not labelUnscheduled.Visible
            End If
         Next control
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

      Sub Action_UpdateMPPS()
         Dim client As BrokerServiceClient = TryCast(GetWizard().Tag, BrokerServiceClient)

         client.UpdateMPPS(MainForm.Mpps.MPPSSOPInstanceUID, MainForm.Mpps)
      End Sub

      Public Overrides Sub OnWizardFinish(ByVal sender As Object, ByVal e As CancelEventArgs)
         If MainForm.Mpps.Patient Is Nothing Then
            Dim dlgProgresss As ProgressDialog = New ProgressDialog()


            UpdatePatient()
            dlgProgresss.Title = "Update patient information"
            dlgProgresss.Description = "Updating..."
            dlgProgresss.Action = New Action(AddressOf Action_UpdateMPPS)

            If dlgProgresss.ShowDialog(Me) = DialogResult.Cancel Then
               If Not dlgProgresss.Exception Is Nothing Then
                  e.Cancel = True
                  Messager.ShowError(Me, dlgProgresss.Exception)
               End If
            End If
         End If

         MyBase.OnWizardFinish(sender, e)
      End Sub

      Private Sub UpdateUI(ByVal clear As Boolean)
         If (Not clear) Then
            If MainForm.Mpps.Patient Is Nothing Then
               MainForm.Mpps.UnscheduledPatient = New PatientInfoforUnscheduledPPS()
            End If

            textBoxId.Text = MainForm.Mpps.UnscheduledPatient.PatientID
            textBoxIssuerOfPatientId.Text = MainForm.Mpps.UnscheduledPatient.IssuerofPatientID
            textBoxName.Text = MainForm.Mpps.UnscheduledPatient.PatientName

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
         MainForm.Mpps.UnscheduledPatient.PatientID = textBoxId.Text
         MainForm.Mpps.UnscheduledPatient.IssuerofPatientID = textBoxIssuerOfPatientId.Text
         MainForm.Mpps.UnscheduledPatient.PatientName = textBoxName.Text
         MainForm.Mpps.UnscheduledPatient.PatientSex = comboBoxSex.Text

         If dateTimePickerBirth.Checked Then
            MainForm.Mpps.UnscheduledPatient.PatientBirthDate = New DicomDateRangeValue() With {.Date1 = New DicomDateValue(dateTimePickerBirth.Value)}
         End If
      End Sub

      Public Overrides Sub OnReset()
         UpdateUI(True)
      End Sub
   End Class
End Namespace

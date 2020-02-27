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
Imports Leadtools.Demos
Imports Leadtools.Dicom.Common.DataTypes
Imports Leadtools.Dicom

Namespace MPPSWCFDemo.UI
   Partial Public Class QueryForm : Inherits Form
      Private _Client As BrokerServiceClient

      Public ReadOnly Property PPSInfo() As WCFPPSInformation
         Get
            If SearchResults.SelectedItems.Count = 1 Then
               Return TryCast(SearchResults.SelectedItems(0).Tag, WCFPPSInformation)
            End If
            Return Nothing
         End Get
      End Property

      Public Sub New(ByVal client As BrokerServiceClient)
         InitializeComponent()
         _Client = client
         LoadModalities()
      End Sub

      Private Sub LoadModalities()
         Dim modalities As IEnumerator(Of KeyValuePair(Of ModalityType, String)) = ModalityDescriptor.GetEnumerator()

         While modalities.MoveNext()
            Modality.Items.Add(modalities.Current.Key)
         End While
      End Sub

      Private Delegate Function GetDateDelegate(ByVal start As DateTimePicker, ByVal [end] As DateTimePicker) As System.Nullable(Of DicomDateRangeValue)

      Private Function GetDate(ByVal start As DateTimePicker, ByVal [end] As DateTimePicker) As System.Nullable(Of DicomDateRangeValue)
         If InvokeRequired Then
            Return CType(Invoke(New GetDateDelegate(AddressOf GetDate), start, [end]), System.Nullable(Of DicomDateRangeValue))
         Else
            If start.Checked OrElse [end].Checked Then
               Dim range As New DicomDateRangeValue()

               If start.Checked Then
                  range.Date1 = New DicomDateValue(start.Value)
               End If
               If [end].Checked Then
                  range.Date2 = New DicomDateValue([end].Value)
               End If
               Return range
            End If
            Return Nothing
         End If
      End Function

      Dim mppsInfo As List(Of WCFPPSInformation) = Nothing
      Dim currentModality As String = String.Empty
      Dim currentStatus As String = String.Empty

      Sub Action_QueryMPPS()
         Dim query As MPPSQuery = New MPPSQuery() With {.AccessionNumber = AccessionNumber.Text, .RequestedProcedureId = RequestedProcedureId.Text, .ScheduledProcedureId = ScheduledProcedureId.Text}

         query.Patient = New WCFPatient() With {.PatientID = PatientId.Text, .PatientNameGivenName = Firstname.Text, .PatientNameFamilyName = Lastname.Text}
         query.PPSInfo = New WCFPPSInformation() With {.PerformedStationAETitle = PerformedStationAe.Text, .Modality = currentModality, .PerformedProcedureStepStatus = currentStatus}
         query.PPSInfo.PerformedProcedureStepStartDate = GetDate(StartDateBegin, StartDateEnd)
         query.PPSInfo.PerformedProcedureStepEndDate = GetDate(EndDateBegin, EndDateEnd)
         mppsInfo = _Client.QueryMPPS(query)
      End Sub

#If (LTV19_CONFIG) Then
      Dim _worklistServer As String = "L19_MWL_SCP32"
#ElseIf (LTV18_CONFIG) Then
	  Dim _worklistServer As String = "L18_MWL_SCP32"
#ElseIf (LTV175_CONFIG) Then
	  Dim _worklistServer As String = "L175_MWL_SCP32"
#Else
	  Dim _worklistServer As String = "L17_MWL_SCP32"
#End If

      Private Sub buttonQuery_Click(ByVal sender As Object, ByVal e As EventArgs) Handles buttonQuery.Click
         Dim dlgProgresss As ProgressDialog = New ProgressDialog()

         SearchResults.Items.Clear()
         dlgProgresss.Title = "Query"
         dlgProgresss.Description = "Getting list of unscheduled mpps"
         dlgProgresss.Action = New Action(AddressOf Action_QueryMPPS)

         currentModality = Modality.Text
         currentStatus = Status.Text
         If dlgProgresss.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK And mppsInfo IsNot Nothing Then
            For Each info As WCFPPSInformation In mppsInfo
               Dim patientid_Renamed As String
               If Not info.Patient Is Nothing Then
                  patientid_Renamed = info.Patient.PatientID
               Else
                  patientid_Renamed = String.Empty
               End If
               Dim item As ListViewItem = SearchResults.Items.Add(patientid_Renamed)

               If Not info.Patient Is Nothing Then
                  item.SubItems.Add(info.Patient.PatientNameGivenName & " " & info.Patient.PatientNameFamilyName)
               Else
                  item.SubItems.Add(String.Empty)
               End If

               item.SubItems.Add(info.PerformedProcedureStepStatus)
               item.SubItems.Add(info.Modality)
               item.SubItems.Add(info.PerformedProcedureStepID)
               item.SubItems.Add(info.PerformedStationAETitle)
               If info.PerformedProcedureStepStartDate.HasValue Then
                  item.SubItems.Add(info.PerformedProcedureStepStartDate.Value.Date1.ToString())
               Else
                  item.SubItems.Add(String.Empty)
               End If
               If info.PerformedProcedureStepEndDate.HasValue Then
                  item.SubItems.Add(info.PerformedProcedureStepEndDate.Value.Date1.ToString())
               Else
                  item.SubItems.Add(String.Empty)
               End If
               item.Tag = info
            Next info
         End If

         If dlgProgresss.Exception IsNot Nothing Then
            Dim errorMessage As String = dlgProgresss.Exception.Message
            If errorMessage.Contains("There was no endpoint listening at") Then
               Dim append As String = String.Format(Constants.vbLf + Constants.vbLf & "This can happen if the '{0}' listening service is not running.  To start '{0}' listening service:" & Constants.vbLf & "* Run 'CSLeadtools.Dicom.Server.Manager_Original.exe'" & Constants.vbLf & "* Click the double-green arrow (Start All Servers)", _worklistServer)
               errorMessage &= append
            End If
            Messager.ShowError(Me, errorMessage)
         End If
      End Sub

      Private Sub buttonClear_Click(ByVal sender As Object, ByVal e As EventArgs) Handles buttonClear.Click
         PatientId.Text = String.Empty
         Firstname.Text = String.Empty
         AccessionNumber.Text = String.Empty
         Modality.SelectedIndex = -1
         RequestedProcedureId.Text = String.Empty
         ScheduledProcedureId.Text = String.Empty
         PerformedStationAe.Text = String.Empty
         StartDateBegin.Checked = False
         StartDateEnd.Checked = False
         EndDateBegin.Checked = False
         EndDateEnd.Checked = False
         Status.SelectedIndex = -1
      End Sub

      Private Sub SearchResults_DoubleClick(ByVal sender As Object, ByVal e As EventArgs) Handles SearchResults.DoubleClick
         DialogResult = System.Windows.Forms.DialogResult.OK
      End Sub

      Private Sub QueryForm_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
         AddHandler Application.Idle, AddressOf Application_Idle
      End Sub

      Private Sub Application_Idle(ByVal sender As Object, ByVal e As EventArgs)
         buttonOK.Enabled = SearchResults.SelectedItems.Count = 1
      End Sub
   End Class
End Namespace

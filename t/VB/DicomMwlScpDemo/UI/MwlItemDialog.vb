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
Imports System.Text
Imports System.Windows.Forms
Imports Leadtools.DicomDemos

Namespace DicomDemo
	Public Partial Class MwlItemDialog : Inherits Form
      ' Private properties
      Private m_bIsNew As Boolean
      Private m_strItemID As String

      ' Public properties
      Public m_strSqlQuery As String
		Public m_strItemValues As String()

      Public Sub New(ByVal bIsNew As Boolean)
         InitializeComponent()

         m_bIsNew = bIsNew
         m_strItemID = ""
         m_strSqlQuery = ""
      End Sub

      '        
      '         * Populates the forms controls
      '         
      Private Sub PopulateFormControls()
         Try
            ' Combo Boxes
            ' Sex
            cboSex.Items.Add("M")
            cboSex.Items.Add("F")
            cboSex.Items.Add("O")

            ' Procedure Priority
            cboProcedurePriority.Items.Add("STAT")
            cboProcedurePriority.Items.Add("HIGH")
            cboProcedurePriority.Items.Add("ROUTINE")
            cboProcedurePriority.Items.Add("MEDIUM")
            cboProcedurePriority.Items.Add("LOW")

            ' If we are editing an item, update the form with current information
            If (Not m_bIsNew) Then
               Dim items As ListViewItem.ListViewSubItemCollection = (CType(Owner, MainForm)).lstDatabase.SelectedItems(0).SubItems
               txtAccessionNumber.Text = items(0).Text
               txtModality.Text = items(1).Text
               txtInstitutionName.Text = items(2).Text
               txtReferringPhysicianName.Text = items(3).Text
               txtPatientName.Text = items(4).Text
               txtPatientID.Text = items(5).Text
               txtPatientBirthDate.Text = FormatDateTime(items(6).Text, True, True)
               cboSex.Text = items(7).Text
               txtWeight.Text = items(8).Text
               txtStudyInstanceUID.Text = items(9).Text
               txtRequestingPhysician.Text = items(10).Text
               txtRequestedProcedureDescription.Text = items(11).Text
               txtAdmissionID.Text = items(12).Text
               txtStartDate.Text = FormatDateTime(items(14).Text, True, True)
               txtStartTime.Text = FormatDateTime(items(15).Text, False, True)
               txtPhysicianName.Text = items(16).Text
               txtDescription.Text = items(17).Text
               txtID.Text = items(18).Text
               txtLocation.Text = items(19).Text
               txtStationAETitle.Text = items(13).Text
               txtRequestedProcedureID.Text = items(20).Text
               txtReasonForProcedure.Text = items(21).Text
               cboProcedurePriority.Text = items(22).Text

               ' Item ID is invisible
               m_strItemID = items(23).Text
            End If
         Catch ex As Exception
            MessageBox.Show("Error populating controls:" & Constants.vbCrLf & Constants.vbCrLf & ex.ToString())
         End Try
      End Sub

		Private Sub btnCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCancel.Click
			DialogResult = Windows.Forms.DialogResult.Cancel
         Close()
      End Sub

		Private Sub btnOk_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnOk.Click
         m_strItemValues = New String(23) {txtAccessionNumber.Text, txtModality.Text, txtInstitutionName.Text, txtReferringPhysicianName.Text, txtPatientName.Text, txtPatientID.Text, FormatDateTime(txtPatientBirthDate.Text, True, False), cboSex.Text, txtWeight.Text, txtStudyInstanceUID.Text, txtRequestingPhysician.Text, txtRequestedProcedureDescription.Text, txtAdmissionID.Text, txtStationAETitle.Text, FormatDateTime(txtStartDate.Text, True, False), FormatDateTime(txtStartTime.Text, False, False), txtPhysicianName.Text, txtDescription.Text, txtID.Text, txtLocation.Text, txtRequestedProcedureID.Text, txtReasonForProcedure.Text, cboProcedurePriority.Text, m_strItemID}
         If m_bIsNew Then
            ' Set up SQL Query to add a new record
            m_strSqlQuery = "INSERT INTO MwlSCPTbl VALUES(NULL, " & "'" & txtAccessionNumber.Text.PrepareDatabaseQueryString() & "'," & "'" & txtModality.Text.PrepareDatabaseQueryString() & "'," & "'" & txtInstitutionName.Text.PrepareDatabaseQueryString() & "'," & "'" & txtReferringPhysicianName.Text.PrepareDatabaseQueryString() & "'," & "'" & txtPatientName.Text.PrepareDatabaseQueryString() & "'," & "'" & txtPatientID.Text.PrepareDatabaseQueryString() & "'," & "'" & FormatDateTime(txtPatientBirthDate.Text, True, False) & "'," & "'" & cboSex.Text.PrepareDatabaseQueryString() & "'," & "'" & txtWeight.Text.PrepareDatabaseQueryString() & "'," & "'" & txtStudyInstanceUID.Text.PrepareDatabaseQueryString() & "'," & "'" & txtRequestingPhysician.Text.PrepareDatabaseQueryString() & "'," & "'" & txtRequestedProcedureDescription.Text.PrepareDatabaseQueryString() & "'," & "'" & txtAdmissionID.Text.PrepareDatabaseQueryString() & "'," & "'" & txtStationAETitle.Text.PrepareDatabaseQueryString() & "'," & "'" & FormatDateTime(txtStartDate.Text, True, False) & "'," & "'" & FormatDateTime(txtStartTime.Text, False, False) & "'," & "'" & txtPhysicianName.Text.PrepareDatabaseQueryString() & "'," & "'" & txtDescription.Text.PrepareDatabaseQueryString() & "'," & "'" & txtID.Text.PrepareDatabaseQueryString() & "'," & "'" & txtLocation.Text.PrepareDatabaseQueryString() & "'," & "'" & txtRequestedProcedureID.Text.PrepareDatabaseQueryString() & "'," & "'" & txtReasonForProcedure.Text.PrepareDatabaseQueryString() & "'," & "'" & cboProcedurePriority.Text.PrepareDatabaseQueryString() & "')"
         Else
            ' Set up SQL Query to add a new record
            m_strSqlQuery = "UPDATE MwlSCPTbl SET " & "TAG_ACCESSION_NUMBER = '" & txtAccessionNumber.Text.PrepareDatabaseQueryString() & "'," & "TAG_MODALITY = '" & txtModality.Text.PrepareDatabaseQueryString() & "'," & "TAG_INSTITUTION_NAME = '" & txtInstitutionName.Text.PrepareDatabaseQueryString() & "'," & "TAG_REFERRING_PHYSICIAN_NAME = '" & txtReferringPhysicianName.Text.PrepareDatabaseQueryString() & "'," & "TAG_PATIENT_NAME = '" & txtPatientName.Text.PrepareDatabaseQueryString() & "'," & "TAG_PATIENT_ID = '" & txtPatientID.Text.PrepareDatabaseQueryString() & "'," & "TAG_PATIENT_BIRTH_DATE = '" & FormatDateTime(txtPatientBirthDate.Text, True, False) & "'," & "TAG_PATIENT_SEX = '" & cboSex.Text.PrepareDatabaseQueryString() & "'," & "TAG_PATIENT_WEIGHT = '" & txtWeight.Text.PrepareDatabaseQueryString() & "'," & "TAG_STUDY_INSTANCE_UID = '" & txtStudyInstanceUID.Text.PrepareDatabaseQueryString() & "'," & "TAG_REQUESTING_PHYSICIAN = '" & txtRequestingPhysician.Text.PrepareDatabaseQueryString() & "'," & "TAG_REQUESTED_PROCEDURE_DESCRIPTION = '" & txtRequestedProcedureDescription.Text.PrepareDatabaseQueryString() & "'," & "TAG_ADMISSION_ID = '" & txtAdmissionID.Text.PrepareDatabaseQueryString() & "'," & "TAG_SCHEDULED_STATION_AE_TITLE = '" & txtStationAETitle.Text.PrepareDatabaseQueryString() & "'," & "TAG_SCHEDULED_PROCEDURE_STEP_START_DATE = '" & FormatDateTime(txtStartDate.Text, True, False) & "'," & "TAG_SCHEDULED_PROCEDURE_STEP_START_TIME = '" & FormatDateTime(txtStartTime.Text, False, False) & "'," & "TAG_SCHEDULED_PERFORMING_PHYSICIAN_NAME = '" & txtPhysicianName.Text.PrepareDatabaseQueryString() & "'," & "TAG_SCHEDULED_PROCEDURE_STEP_DESCRIPTION = '" & txtDescription.Text.PrepareDatabaseQueryString() & "'," & "TAG_SCHEDULED_PROCEDURE_STEP_ID = '" & txtID.Text.PrepareDatabaseQueryString() & "'," & "TAG_SCHEDULED_PROCEDURE_STEP_LOCATION = '" & txtLocation.Text.PrepareDatabaseQueryString() & "'," & "TAG_REQUESTED_PROCEDURE_ID = '" & txtRequestedProcedureID.Text.PrepareDatabaseQueryString() & "'," & "TAG_REASON_FOR_THE_REQUESTED_PROCEDURE = '" & txtReasonForProcedure.Text.PrepareDatabaseQueryString() & "'," & "TAG_REQUESTED_PROCEDURE_PRIORITY = '" & cboProcedurePriority.Text.PrepareDatabaseQueryString() & "'" & " WHERE Item_ID = " & m_strItemID
         End If

         DialogResult = DialogResult.OK
         Close()
      End Sub

		Private Sub MwlItemDialog_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
         PopulateFormControls()
      End Sub

      '        
      '         * Formats a string representing a DateTime, Date, or Time into the proper string
      '         
      Private Function FormatDateTime(ByVal strDateTime As String, ByVal bIsDate As Boolean, ByVal bIsLoading As Boolean) As String
			Dim splitter As Char() = New Char(0) { " "c }
         Dim strRet As String = ""
         If bIsDate Then ' Date
            If bIsLoading Then ' coming from database to form, format as "yyyy/mm/dd"
               strRet = strDateTime.Split(splitter, StringSplitOptions.None)(0)
            Else ' coming from form to database, format as "yyyy/mm/dd HH:MM:SS"
               strRet = strDateTime & " 00:00:00"
            End If
         Else ' Time
            If bIsLoading Then ' coming from database to form, format as "HH:MM:SS"
               strRet = strDateTime.Split(splitter, StringSplitOptions.None)(1)
            Else ' coming from form to database, format as "yyyy/mm/dd HH:MM:SS"
               strRet = "1899/12/30 " & strDateTime
            End If
         End If

         Return strRet
      End Function
   End Class


   Public Module Extensions
      <System.Runtime.CompilerServices.Extension()> _
      Public Function PrepareDatabaseQueryString(ByVal s As String) As String
         If s.Contains("'") Then
            s = s.Replace("'", "''")
         End If
         Return s
      End Function
   End Module
End Namespace

#If (Not FOR_DOTNET4) Then
Namespace System.Runtime.CompilerServices
    <AttributeUsage(AttributeTargets.Method Or AttributeTargets.Assembly Or AttributeTargets.Class)> _
    Public Class ExtensionAttribute
        Inherits Attribute
    End Class
End Namespace
#End If

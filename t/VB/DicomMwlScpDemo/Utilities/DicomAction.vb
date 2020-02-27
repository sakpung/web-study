' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports Microsoft.VisualBasic
Imports System.Collections.Specialized
Imports System.Data
Imports System.Data.SQLite
Imports System.Net
Imports System.Threading
Imports System.Windows.Forms

Imports Leadtools
Imports Leadtools.Dicom
Imports Leadtools.DicomDemos
Imports Leadtools.DicomDemos.Scu
Imports System

Namespace DicomDemo
   Public Enum ProcessType
      EchoRequest
      StoreRequest
      FindRequest
      MoveRequest
   End Enum

   Public Enum QueryLevel
      Patient
      Study
      Series
      Image
   End Enum

   ''' <summary>
   ''' Summary description for DicomThread.
   ''' </summary>
   Public Class DicomAction
      Private server As Server
      Private m_client As Client
      Private process As ProcessType
      Private _AETitle As String
      Private _ipAddress As String
      Private _PresentationID As Byte
      Private _MessageID As Integer
      Private _Class As String
      Private _Instance As String
      Private _Priority As DicomCommandPriorityType
      Private _MoveAETitle As String
      Private _MoveMessageID As Integer

      Public dsFileName As String

      Private m_ds As New DicomDataSet()

      Public Delegate Sub ActionCompleteHandler(ByVal sender As Object, ByVal e As EventArgs)

      Public Event ActionComplete As ActionCompleteHandler

      Public ReadOnly Property Client() As Client
         Get
            Return m_client
         End Get
      End Property

      Public ReadOnly Property DS() As DicomDataSet
         Get
            Return m_ds
         End Get
      End Property

      Public Property AETitle() As String
         Get
            Return _AETitle
         End Get
         Set(ByVal value As String)
            _AETitle = value
         End Set
      End Property

      Public Property ipAddress() As String
         Get
            Return _ipAddress
         End Get
         Set(ByVal value As String)
            _ipAddress = value
         End Set
      End Property

      Public Property PresentationID() As Byte
         Get
            Return _PresentationID
         End Get
         Set(ByVal value As Byte)
            _PresentationID = value
         End Set
      End Property

      Public Property MessageID() As Integer
         Get
            Return _MessageID
         End Get
         Set(ByVal value As Integer)
            _MessageID = value
         End Set
      End Property

      Public Property [Class]() As String
         Get
            Return _Class
         End Get
         Set(ByVal value As String)
            _Class = value
         End Set
      End Property

      Public Property Instance() As String
         Get
            Return _Instance
         End Get
         Set(ByVal value As String)
            _Instance = value
         End Set
      End Property

      Public Property Priority() As DicomCommandPriorityType
         Get
            Return _Priority
         End Get
         Set(ByVal value As DicomCommandPriorityType)
            _Priority = value
         End Set
      End Property

      Public Property MoveAETitle() As String
         Get
            Return _MoveAETitle
         End Get
         Set(ByVal value As String)
            _MoveAETitle = value
         End Set
      End Property

      Public Property MoveMessageID() As Integer
         Get
            Return _MoveMessageID
         End Get
         Set(ByVal value As Integer)
            _MoveMessageID = value
         End Set
      End Property

      Public Sub New(ByVal process As ProcessType, ByVal server As Server, ByVal client As Client)
         Me.server = server
         Me.m_client = client
         Me.process = process
      End Sub

      Public Sub New(ByVal process As ProcessType, ByVal server As Server, ByVal client As Client, ByVal ds As DicomDataSet)
         Me.server = server
         Me.m_client = client
         Me.process = process

         If ds IsNot Nothing Then
            Me.m_ds.Copy(ds, Nothing, Nothing)
         End If
      End Sub

      Protected Overridable Sub OnActionComplete()
         ' Invokes the delegates. 
         RaiseEvent ActionComplete(Me, New EventArgs())

         If m_ds IsNot Nothing Then
            m_ds.Dispose()

            m_ds = Nothing
         End If
      End Sub

      Public Sub DoAction()
         If m_client.Association IsNot Nothing Then
            Select Case process
               Case ProcessType.EchoRequest
                  DoEchoRequest()
                  Exit Select
               Case ProcessType.FindRequest
                  DoFindRequest()
                  Exit Select
            End Select
         End If
         OnActionComplete()
      End Sub

      Private Function IsActionSupported() As Boolean
         Dim id As Byte

         If DicomUidTable.Instance.Find([Class]) Is Nothing Then
            Return False
         End If

         id = m_client.Association.FindAbstract([Class])
         If id = 0 OrElse m_client.Association.GetResult(id) <> DicomAssociateAcceptResultType.Success Then
            Return False
         End If

         Return True
      End Function

      Private Function GetUIDName() As String
         Dim uid As DicomUid = DicomUidTable.Instance.Find([Class])

         If uid Is Nothing Then
            Return [Class]
         End If

         Return uid.Name
      End Function

      '
      '       * Handles a C-ECHO request
      '       

      Private Sub DoEchoRequest()
         Try
            server.mf.Log("Client Name: " & Convert.ToString(m_client.Association.Calling) & " -- Receiving C-Echo Response..." & vbCr & vbLf)

            If Not IsActionSupported() Then
               Dim name As String = GetUIDName()

               server.mf.Log("Client Name: " & Convert.ToString(m_client.Association.Calling) & " -- Sending C-Echo Response - Status: Abstract Syntax not supported!" & vbCr & vbLf)
               m_client.SendCEchoResponse(_PresentationID, _MessageID, [Class], DicomCommandStatusType.ClassNotSupported)
               Return
            End If

            server.mf.Log("Client Name: " & Convert.ToString(m_client.Association.Calling) & " -- Sending C-Echo Response..." & vbCr & vbLf)
            m_client.SendCEchoResponse(_PresentationID, MessageID, [Class], DicomCommandStatusType.Success)
         Catch ex As Exception
            server.mf.Log("Error handling CEcho request:" & vbCr & vbLf & vbCr & vbLf & ex.ToString())
         End Try
      End Sub

      '
      '       * Handles a C-FIND request
      '       

      Private Sub DoFindRequest()
         Try
            ' We have received a C-Find Request
            server.mf.Log("Client Name:" & AETitle & " -- Receiving C-Find Request..." & vbCr & vbLf)

            If Not IsActionSupported() Then
               Dim name As String = GetUIDName()

               server.mf.Log("Client Name:" & AETitle & " -- Sending C-Find Response - Status: Abstract Syntax not supported!" & vbCr & vbLf)
               m_client.SendCFindResponse(_PresentationID, _MessageID, _Class, DicomCommandStatusType.ClassNotSupported, Nothing)
               Return
            End If

            If m_ds Is Nothing Then
               server.mf.Log("Client Name:" & AETitle & " -- Sending C-Find Response - Status: Invalid argument value!" & vbCr & vbLf)
               m_client.SendCFindResponse(_PresentationID, _MessageID, _Class, DicomCommandStatusType.InvalidArgumentValue, Nothing)
               Return
            End If

            ' Build
            Dim strSQLQuery As String
            strSQLQuery = GenerateMatchingQuery()
            FindMatchingAttributes(strSQLQuery)
         Catch ex As Exception
            server.mf.Log("Error handling CFind request:" & vbCr & vbLf & vbCr & vbLf & ex.ToString())
         End Try
      End Sub

      '
      '       * Generates an SQL query based on the client's search parameters
      '       

      Private Function GenerateMatchingQuery() As String
         Dim strSqlQuery As String = ""
         Dim strAttributeValue As String = ""
         Dim element As DicomElement

         Try
            strSqlQuery = "SELECT * FROM MwlSCPTbl WHERE 1=1"

            ' TAG_ACCESSION_NUMBER
            element = m_ds.FindFirstElement(Nothing, DemoDicomTags.AccessionNumber, False)
            If element IsNot Nothing Then
               strAttributeValue = m_ds.GetStringValue(element, 0)
               If (strAttributeValue IsNot Nothing) AndAlso (strAttributeValue <> "") Then
                  ' Wild Card Matching or Single Value Matching
                  If (strAttributeValue.IndexOf("*"c) >= 0) OrElse (strAttributeValue.IndexOf("?"c) >= 0) Then
                     ' Wild card matching -- case insensitive
                     strSqlQuery += " And TAG_ACCESSION_NUMBER LIKE '" & PrepareForWCM(strAttributeValue) & "'"
                  Else
                     ' Single value matching -- case sensitive
                     strSqlQuery += " And TAG_ACCESSION_NUMBER = '" & strAttributeValue & "'"
                  End If
               End If
            End If

            ' TAG_MODALITY
            element = m_ds.FindFirstElement(Nothing, DemoDicomTags.Modality, False)
            If element IsNot Nothing Then
               strAttributeValue = m_ds.GetStringValue(element, 0)
               If (strAttributeValue IsNot Nothing) AndAlso (strAttributeValue <> "") Then
                  ' Single value matching -- case sensitive
                  strSqlQuery += " And TAG_MODALITY = '" & FilterForSingleValueMatch(strAttributeValue) & "'"
               End If
            End If

            ' TAG_INSTITUTION_NAME
            element = m_ds.FindFirstElement(Nothing, DemoDicomTags.InstitutionName, False)
            If element IsNot Nothing Then
               strAttributeValue = m_ds.GetStringValue(element, 0)
               If (strAttributeValue IsNot Nothing) AndAlso (strAttributeValue <> "") Then
                  ' Wild Card Matching or Single Value Matching
                  If (strAttributeValue.IndexOf("*"c) >= 0) OrElse (strAttributeValue.IndexOf("?"c) >= 0) Then
                     ' Wild card matching -- case insensitive
                     strSqlQuery += " And TAG_INSTITUTION_NAME LIKE '" & PrepareForWCM(strAttributeValue) & "'"
                  Else
                     ' Single value matching -- case sensitive
                     strSqlQuery += " And TAG_INSTITUTION_NAME = '" & strAttributeValue & "'"
                  End If
               End If
            End If

            ' TAG_REFERRING_PHYSICIAN_NAME
            element = m_ds.FindFirstElement(Nothing, DemoDicomTags.ReferringPhysicianName, False)
            If element IsNot Nothing Then
               strAttributeValue = m_ds.GetStringValue(element, 0)
               If (strAttributeValue IsNot Nothing) AndAlso (strAttributeValue <> "") Then
                  ' Wild card matching -- case insensitive
                  strSqlQuery += " And TAG_REFERRING_PHYSICIAN_NAME LIKE '" & PrepareForWCM(strAttributeValue) & "'"
               End If
            End If

            ' TAG_PATIENT_NAME
            element = m_ds.FindFirstElement(Nothing, DemoDicomTags.PatientName, False)
            If element IsNot Nothing Then
               strAttributeValue = m_ds.GetStringValue(element, 0)
               If (strAttributeValue IsNot Nothing) AndAlso (strAttributeValue <> "") Then
                  ' Wild card matching -- case insensitive
                  strSqlQuery += " And TAG_PATIENT_NAME LIKE '" & PrepareForWCM(strAttributeValue) & "'"
               End If
            End If

            ' TAG_PATIENT_ID
            element = m_ds.FindFirstElement(Nothing, DemoDicomTags.PatientID, False)
            If element IsNot Nothing Then
               strAttributeValue = m_ds.GetStringValue(element, 0)
               If (strAttributeValue IsNot Nothing) AndAlso (strAttributeValue <> "") Then
                  ' Single value matching -- case sensitive
                  strSqlQuery += " And TAG_PATIENT_ID = '" & FilterForSingleValueMatch(strAttributeValue) & "'"
               End If
            End If

            ' TAG_PATIENT_BIRTH_DATE
            element = m_ds.FindFirstElement(Nothing, DemoDicomTags.PatientBirthDate, False)
            If element IsNot Nothing Then
               Dim dateValue As DicomDateValue() = m_ds.GetDateValue(element, 0, 1)

               If dateValue.Length > 0 Then
                  strSqlQuery += " And (julianday(substr(TAG_PATIENT_BIRTH_DATE,1,10)) = julianday('" & ConvertDicomDateToQueryDate(dateValue(0)) & "'))"
               End If
            End If

            ' TAG_PATIENT_SEX
            element = m_ds.FindFirstElement(Nothing, DemoDicomTags.PatientSex, False)
            If element IsNot Nothing Then
               strAttributeValue = m_ds.GetStringValue(element, 0)
               If (strAttributeValue IsNot Nothing) AndAlso (strAttributeValue <> "") Then
                  ' Single value matching -- case sensitive
                  strSqlQuery += " And TAG_PATIENT_SEX = '" & FilterForSingleValueMatch(strAttributeValue) & "'"
               End If
            End If

            ' TAG_PATIENT_WEIGHT
            element = m_ds.FindFirstElement(Nothing, DemoDicomTags.PatientWeight, False)
            If element IsNot Nothing Then
               Dim dAttributeValue As Double() = m_ds.GetDoubleValue(element, 0, 1)

               'strAttributeValue = 
               If dAttributeValue.Length > 0 Then
                  strAttributeValue = dAttributeValue(0).ToString()
                  ' Single value matching -- case sensitive
                  strSqlQuery += " And TAG_PATIENT_WEIGHT = '" & FilterForSingleValueMatch(strAttributeValue) & "'"
               End If
            End If

            ' TAG_STUDY_INSTANCE_UID
            strSqlQuery += GetUIDCondition(CLng(DemoDicomTags.StudyInstanceUID), "TAG_STUDY_INSTANCE_UID")
            ' List of Matching UIDs
            ' TAG_REQUESTING_PHYSICIAN
            element = m_ds.FindFirstElement(Nothing, DemoDicomTags.RequestingPhysician, False)
            If element IsNot Nothing Then
               strAttributeValue = m_ds.GetStringValue(element, 0)
               If (strAttributeValue IsNot Nothing) AndAlso (strAttributeValue <> "") Then
                  ' Wild card matching -- case insensitive
                  strSqlQuery += " And TAG_REQUESTING_PHYSICIAN LIKE '" & PrepareForWCM(strAttributeValue) & "'"
               End If
            End If

            ' TAG_REQUESTED_PROCEDURE_DESCRIPTION
            element = m_ds.FindFirstElement(Nothing, DemoDicomTags.RequestedProcedureDescription, False)
            If (strAttributeValue IsNot Nothing) AndAlso (strAttributeValue <> "") Then
               strAttributeValue = m_ds.GetStringValue(element, 0)
               If (strAttributeValue IsNot Nothing) AndAlso (strAttributeValue <> "") Then
                  ' Wild card matching -- case insensitive
                  strSqlQuery += " And TAG_REQUESTED_PROCEDURE_DESCRIPTION LIKE '" & PrepareForWCM(strAttributeValue) & "'"
               End If
            End If

            ' TAG_ADMISSION_ID
            element = m_ds.FindFirstElement(Nothing, DemoDicomTags.AdmissionID, False)
            If (strAttributeValue IsNot Nothing) AndAlso (strAttributeValue <> "") Then
               strAttributeValue = m_ds.GetStringValue(element, 0)
               If (strAttributeValue IsNot Nothing) AndAlso (strAttributeValue <> "") Then
                  ' Single value matching -- case sensitive
                  strSqlQuery += " And TAG_ADMISSION_ID = '" & FilterForSingleValueMatch(strAttributeValue) & "'"
               End If
            End If

            ' TAG_SCHEDULED_STATION_AE_TITLE
            element = m_ds.FindFirstElement(Nothing, DemoDicomTags.ScheduledStationAETitle, False)
            If (strAttributeValue IsNot Nothing) AndAlso (strAttributeValue <> "") Then
               strAttributeValue = m_ds.GetStringValue(element, 0)
               If (strAttributeValue IsNot Nothing) AndAlso (strAttributeValue <> "") Then
                  ' Single value matching -- case sensitive
                  strSqlQuery += " And TAG_SCHEDULED_STATION_AE_TITLE = '" & FilterForSingleValueMatch(strAttributeValue) & "'"
               End If
            End If

            ' TAG_SCHEDULED_PROCEDURE_STEP_START_DATE
            element = m_ds.FindFirstElement(Nothing, DemoDicomTags.ScheduledProcedureStepStartDate, False)
            If element IsNot Nothing Then
               Dim dateValue As DicomDateValue() = m_ds.GetDateValue(element, 0, 1)

               If dateValue.Length > 0 Then
                  strSqlQuery += " And (julianday(substr(TAG_SCHEDULED_PROCEDURE_STEP_START_DATE,1,10)) = julianday('" & ConvertDicomDateToQueryDate(dateValue(0)) & "'))"
               End If
            End If

            ' TAG_SCHEDULED_PROCEDURE_STEP_START_TIME
            element = m_ds.FindFirstElement(Nothing, DemoDicomTags.ScheduledProcedureStepStartTime, False)
            If element IsNot Nothing Then
               Dim timeValue As DicomTimeValue() = m_ds.GetTimeValue(element, 0, 1)

               If timeValue.Length > 0 Then
                  strSqlQuery += " And (julianday(substr(TAG_SCHEDULED_PROCEDURE_STEP_START_TIME,-8,8)) = julianday('" & ConvertDicomTimeToQueryTime(timeValue(0)) & "'))"
               End If
            End If

            ' TAG_SCHEDULED_PERFORMING_PHYSICIAN_NAME
            element = m_ds.FindFirstElement(Nothing, DemoDicomTags.ScheduledPerformingPhysicianName, False)
            If element IsNot Nothing Then
               strAttributeValue = m_ds.GetStringValue(element, 0)
               If (strAttributeValue IsNot Nothing) AndAlso (strAttributeValue <> "") Then
                  ' Wild card matching -- case insensitive
                  strSqlQuery += " And TAG_SCHEDULED_PERFORMING_PHYSICIAN_NAME LIKE '" & PrepareForWCM(strAttributeValue) & "'"
               End If
            End If

            ' TAG_SCHEDULED_PROCEDURE_STEP_DESCRIPTION
            element = m_ds.FindFirstElement(Nothing, DemoDicomTags.ScheduledProcedureStepDescription, False)
            If element IsNot Nothing Then
               strAttributeValue = m_ds.GetStringValue(element, 0)
               If (strAttributeValue IsNot Nothing) AndAlso (strAttributeValue <> "") Then
                  ' Wild card matching -- case insensitive
                  strSqlQuery += " And TAG_SCHEDULED_PROCEDURE_STEP_DESCRIPTION LIKE '" & PrepareForWCM(strAttributeValue) & "'"
               End If
            End If

            ' TAG_SCHEDULED_PROCEDURE_STEP_ID
            element = m_ds.FindFirstElement(Nothing, DemoDicomTags.ScheduledProcedureStepID, False)
            If element IsNot Nothing Then
               strAttributeValue = m_ds.GetStringValue(element, 0)
               If (strAttributeValue IsNot Nothing) AndAlso (strAttributeValue <> "") Then
                  ' Single value matching -- case sensitive
                  strSqlQuery += " And TAG_SCHEDULED_PROCEDURE_STEP_ID = '" & FilterForSingleValueMatch(strAttributeValue) & "'"
               End If
            End If

            ' TAG_SCHEDULED_PROCEDURE_STEP_LOCATION
            element = m_ds.FindFirstElement(Nothing, DemoDicomTags.ScheduledProcedureStepLocation, False)
            If element IsNot Nothing Then
               strAttributeValue = m_ds.GetStringValue(element, 0)
               If (strAttributeValue IsNot Nothing) AndAlso (strAttributeValue <> "") Then
                  ' Wild card matching -- case insensitive
                  strSqlQuery += " And TAG_SCHEDULED_PROCEDURE_STEP_LOCATION LIKE '" & PrepareForWCM(strAttributeValue) & "'"
               End If
            End If

            ' TAG_REQUESTED_PROCEDURE_ID
            element = m_ds.FindFirstElement(Nothing, DemoDicomTags.RequestedProcedureID, False)
            If element IsNot Nothing Then
               strAttributeValue = m_ds.GetStringValue(element, 0)
               If (strAttributeValue IsNot Nothing) AndAlso (strAttributeValue <> "") Then
                  ' Single value matching -- case sensitive
                  strSqlQuery += " And TAG_REQUESTED_PROCEDURE_ID = '" & FilterForSingleValueMatch(strAttributeValue) & "'"
               End If
            End If

            ' TAG_REASON_FOR_THE_REQUESTED_PROCEDURE
            element = m_ds.FindFirstElement(Nothing, DemoDicomTags.ReasonForTheRequestedProcedure, False)
            If element IsNot Nothing Then
               strAttributeValue = m_ds.GetStringValue(element, 0)
               If (strAttributeValue IsNot Nothing) AndAlso (strAttributeValue <> "") Then
                  ' Single value matching -- case sensitive
                  strSqlQuery += " And TAG_REASON_FOR_THE_REQUESTED_PROCEDURE = '" & FilterForSingleValueMatch(strAttributeValue) & "'"
               End If
            End If

            ' TAG_REQUESTED_PROCEDURE_PRIORITY
            element = m_ds.FindFirstElement(Nothing, DemoDicomTags.RequestedProcedurePriority, False)
            If element IsNot Nothing Then
               strAttributeValue = m_ds.GetStringValue(element, 0)
               If (strAttributeValue IsNot Nothing) AndAlso (strAttributeValue <> "") Then
                  ' Single value matching -- case sensitive
                  strSqlQuery += " And TAG_REQUESTED_PROCEDURE_PRIORITY = '" & FilterForSingleValueMatch(strAttributeValue) & "'"
               End If
            End If
         Catch ex As Exception
            server.mf.Log("Error generating SQL query:" & vbCr & vbLf & vbCr & vbLf & ex.ToString())
            Return ""
         End Try

         Return strSqlQuery
      End Function

      '
      '       * Finds, builds, and returns to SCU datasets that match the query.
      '       

      Private Sub FindMatchingAttributes(ByVal strSQLQuery As String)
         ' Get matching data from the database
         Dim SqlConn As New SQLiteConnection()
         SqlConn.ConnectionString = [String].Format("Data Source={0};New=False;Version=3", server.mf.m_strDBFileName)

         Try
            SqlConn.Open()

            Dim cmd As SQLiteCommand = SqlConn.CreateCommand()
            cmd.CommandText = strSQLQuery
            Dim reader As SQLiteDataReader = cmd.ExecuteReader(CommandBehavior.[Default])

            ' Loop over the retrieved data
            While reader.Read()
               Using ResponseDicomDS As DicomDataSet = PrepareResponseDS()
                  Dim value As String
                  Dim time As DateTime

                  If Not reader("TAG_ACCESSION_NUMBER") Is DBNull.Value Then
                     value = CType(reader("TAG_ACCESSION_NUMBER"), String)
                  Else
                     value = ""
                  End If
                  Utils.SetKeyElement(ResponseDicomDS, DemoDicomTags.AccessionNumber, value, False)

                  If Not reader("TAG_MODALITY") Is DBNull.Value Then
                     value = CType(reader("TAG_MODALITY"), String)
                  Else
                     value = ""
                  End If
                  Utils.SetKeyElement(ResponseDicomDS, DemoDicomTags.Modality, value, False)

                  If Not reader("TAG_INSTITUTION_NAME") Is DBNull.Value Then
                     value = CType(reader("TAG_INSTITUTION_NAME"), String)
                  Else
                     value = ""
                  End If
                  Utils.SetKeyElement(ResponseDicomDS, DemoDicomTags.InstitutionName, value, False)


                  If Not reader("TAG_REFERRING_PHYSICIAN_NAME") Is DBNull.Value Then
                     value = CType(reader("TAG_REFERRING_PHYSICIAN_NAME"), String)
                  Else
                     value = ""
                  End If
                  Utils.SetKeyElement(ResponseDicomDS, DemoDicomTags.ReferringPhysicianName, value, False)


                  If Not reader("TAG_PATIENT_NAME") Is DBNull.Value Then
                     value = CType(reader("TAG_PATIENT_NAME"), String)
                  Else
                     value = ""
                  End If
                  Utils.SetKeyElement(ResponseDicomDS, DemoDicomTags.PatientName, value, False)

                  If Not reader("TAG_PATIENT_ID") Is DBNull.Value Then
                     value = CType(reader("TAG_PATIENT_ID"), String)
                  Else
                     value = ""
                  End If
                  Utils.SetKeyElement(ResponseDicomDS, DemoDicomTags.PatientID, value, False)

                  ' dates must be handled specially
                  If reader.GetString(reader.GetOrdinal("TAG_PATIENT_BIRTH_DATE")) <> "" Then
                     time = DateTime.Parse(reader.GetString(reader.GetOrdinal("TAG_PATIENT_BIRTH_DATE")))
                     SetTimeDateKeyElement(ResponseDicomDS, time, DemoDicomTags.PatientBirthDate, False)
                  Else
                     Utils.SetKeyElement(ResponseDicomDS, DemoDicomTags.PatientBirthDate, value)
                  End If

                  If Not reader("TAG_PATIENT_SEX") Is DBNull.Value Then
                     value = CType(reader("TAG_PATIENT_SEX"), String)
                  Else
                     value = ""
                  End If
                  Utils.SetKeyElement(ResponseDicomDS, DemoDicomTags.PatientSex, value, False)

                  If Not reader("TAG_PATIENT_WEIGHT") Is DBNull.Value Then
                     value = CDec(reader("TAG_PATIENT_WEIGHT")).ToString()
                  Else
                     value = ""
                  End If
                  Utils.SetKeyElement(ResponseDicomDS, DemoDicomTags.PatientWeight, value, False)

                  If Not reader("TAG_STUDY_INSTANCE_UID") Is DBNull.Value Then
                     value = CType(reader("TAG_STUDY_INSTANCE_UID"), String)
                  Else
                     value = ""
                  End If
                  Utils.SetKeyElement(ResponseDicomDS, DemoDicomTags.StudyInstanceUID, value, False)

                  If Not reader("TAG_REQUESTING_PHYSICIAN") Is DBNull.Value Then
                     value = CType(reader("TAG_REQUESTING_PHYSICIAN"), String)
                  Else
                     value = ""
                  End If
                  Utils.SetKeyElement(ResponseDicomDS, DemoDicomTags.RequestingPhysician, value, False)

                  If Not reader("TAG_REQUESTED_PROCEDURE_DESCRIPTION") Is DBNull.Value Then
                     value = CType(reader("TAG_REQUESTED_PROCEDURE_DESCRIPTION"), String)
                  Else
                     value = ""
                  End If
                  Utils.SetKeyElement(ResponseDicomDS, DemoDicomTags.RequestedProcedureDescription, value, False)

                  If Not reader("TAG_ADMISSION_ID") Is DBNull.Value Then
                     value = CType(reader("TAG_ADMISSION_ID"), String)
                  Else
                     value = ""
                  End If
                  Utils.SetKeyElement(ResponseDicomDS, DemoDicomTags.AdmissionID, value, False)

                  If Not reader("TAG_SCHEDULED_STATION_AE_TITLE") Is DBNull.Value Then
                     value = CType(reader("TAG_SCHEDULED_STATION_AE_TITLE"), String)
                  Else
                     value = ""
                  End If
                  Utils.SetKeyElement(ResponseDicomDS, DemoDicomTags.ScheduledStationAETitle, value, False)

                  ' dates must be handled specially
                  If reader.GetString(reader.GetOrdinal("TAG_SCHEDULED_PROCEDURE_STEP_START_DATE")) <> "" Then
                     time = DateTime.Parse(reader.GetString(reader.GetOrdinal("TAG_SCHEDULED_PROCEDURE_STEP_START_DATE")))
                     SetTimeDateKeyElement(ResponseDicomDS, time, DemoDicomTags.ScheduledProcedureStepStartDate, False)
                  Else
                     Utils.SetKeyElement(ResponseDicomDS, DemoDicomTags.PatientBirthDate, value, False)
                  End If

                  ' dates must be handled specially
                  If reader.GetString(reader.GetOrdinal("TAG_SCHEDULED_PROCEDURE_STEP_START_TIME")) <> "" Then
                     time = DateTime.Parse(reader.GetString(reader.GetOrdinal("TAG_SCHEDULED_PROCEDURE_STEP_START_TIME")))
                     SetTimeDateKeyElement(ResponseDicomDS, time, DemoDicomTags.ScheduledProcedureStepStartTime, True)
                  Else
                     Utils.SetKeyElement(ResponseDicomDS, DemoDicomTags.PatientBirthDate, value, False)
                  End If

                  If Not reader("TAG_SCHEDULED_PERFORMING_PHYSICIAN_NAME") Is DBNull.Value Then
                     value = CType(reader("TAG_SCHEDULED_PERFORMING_PHYSICIAN_NAME"), String)
                  Else
                     value = ""
                  End If
                  Utils.SetKeyElement(ResponseDicomDS, DemoDicomTags.ScheduledPerformingPhysicianName, value, False)

                  If Not reader("TAG_SCHEDULED_PROCEDURE_STEP_DESCRIPTION") Is DBNull.Value Then
                     value = CType(reader("TAG_SCHEDULED_PROCEDURE_STEP_DESCRIPTION"), String)
                  Else
                     value = ""
                  End If
                  Utils.SetKeyElement(ResponseDicomDS, DemoDicomTags.ScheduledProcedureStepDescription, value, False)

                  If Not reader("TAG_SCHEDULED_PROCEDURE_STEP_ID") Is DBNull.Value Then
                     value = CType(reader("TAG_SCHEDULED_PROCEDURE_STEP_ID"), String)
                  Else
                     value = ""
                  End If
                  Utils.SetKeyElement(ResponseDicomDS, DemoDicomTags.ScheduledProcedureStepID, value, False)

                  If Not reader("TAG_SCHEDULED_PROCEDURE_STEP_LOCATION") Is DBNull.Value Then
                     value = CType(reader("TAG_SCHEDULED_PROCEDURE_STEP_LOCATION"), String)
                  Else
                     value = ""
                  End If
                  Utils.SetKeyElement(ResponseDicomDS, DemoDicomTags.ScheduledProcedureStepLocation, value, False)

                  If Not reader("TAG_REQUESTED_PROCEDURE_ID") Is DBNull.Value Then
                     value = CType(reader("TAG_REQUESTED_PROCEDURE_ID"), String)
                  Else
                     value = ""
                  End If
                  Utils.SetKeyElement(ResponseDicomDS, DemoDicomTags.RequestedProcedureID, value, False)

                  If Not reader("TAG_REASON_FOR_THE_REQUESTED_PROCEDURE") Is DBNull.Value Then
                     value = CType(reader("TAG_REASON_FOR_THE_REQUESTED_PROCEDURE"), String)
                  Else
                     value = ""
                  End If
                  Utils.SetKeyElement(ResponseDicomDS, DemoDicomTags.ReasonForTheRequestedProcedure, value, False)

                  If Not reader("TAG_REQUESTED_PROCEDURE_PRIORITY") Is DBNull.Value Then
                     value = CType(reader("TAG_REQUESTED_PROCEDURE_PRIORITY"), String)
                  Else
                     value = ""
                  End If
                  Utils.SetKeyElement(ResponseDicomDS, DemoDicomTags.RequestedProcedurePriority, value, False)

                  ' Send the response Dataset
                  If m_client.IsConnected() Then
                     server.mf.Log("Client Name:" & AETitle & " -- Sending C-Find Response - Status: Pending" & vbCr & vbLf)
                     m_client.SendCFindResponse(_PresentationID, _MessageID, _Class, DicomCommandStatusType.Pending, ResponseDicomDS)
                  Else
                     server.mf.Log("Client Name:" & AETitle & " -- Cannot send C-Find Response because client is no longer connected." & Constants.vbCrLf)
                     Exit While
                  End If
               End Using
            End While
         Catch ex As Exception
            server.mf.Log(ex.ToString())
            server.mf.Log("Client Name:" & AETitle & " -- Sending C-Find Response - Status: Processing failure!" & vbCr & vbLf)
            Try
               m_client.SendCFindResponse(_PresentationID, _MessageID, _Class, DicomCommandStatusType.ProcessingFailure, Nothing)
            Catch ex2 As Exception
               ' do nothing since we can't send a response to the client.  The client can handle a timeout if necessary.
               server.mf.Log(ex2.ToString())
            End Try
            Return
         End Try

         SqlConn.Close()

         ' The final C-FIND-RSP

         If m_client.IsConnected() Then
            server.mf.Log("Client Name:" & AETitle & " -- Sending C-Find Response - Status: Success" & vbCr & vbLf)
            m_client.SendCFindResponse(_PresentationID, _MessageID, _Class, DicomCommandStatusType.Success, Nothing)
         End If
      End Sub

      '
      '       * Replaces every '*' with '%' and every '?' with '_' for the SQL Wildcard matching
      '       

      Private Function PrepareForWCM(ByVal strValue As String) As String
         Try
            strValue = strValue.Replace("*"c, "%"c)
            strValue = strValue.Replace("?"c, "_"c)
         Catch ex As Exception
            server.mf.Log("Error preparing string for Wild Card matching:" & vbCr & vbLf & vbCr & vbLf & ex.ToString())
         End Try
         Return strValue
      End Function

      '
      '       * Ensures that the string will return only a perfect match.
      '       

      Private Function FilterForSingleValueMatch(ByVal strValue As String) As String
         Try
            strValue = strValue.Replace("*", "")
            strValue = strValue.Replace("?", "")
         Catch ex As Exception
            server.mf.Log("Error filtering string for single value matching:" & vbCr & vbLf & vbCr & vbLf & ex.ToString())
         End Try
         Return strValue
      End Function

      '
      '       * Converts a DicomDateValue object into a string formatted as yyyy-mm-dd
      '       

      Private Function ConvertDicomDateToQueryDate(ByVal ddv As DicomDateValue) As String
         Try
            ' Add 0s to beginning if necessary, e.g. yyyy-m-dd needs to be yyyy-mm-dd
            Return ddv.Year.ToString().PadLeft(4, "0"c) & "-" & ddv.Month.ToString().PadLeft(2, "0"c) & "-" & ddv.Day.ToString().PadLeft(2, "0"c)
         Catch ex As Exception
            server.mf.Log("Error Converting date:" & vbCr & vbLf & vbCr & vbLf & ex.ToString())
            Return ""
         End Try
      End Function

      '
      '       * Converts a DicomTimeValue object into a string formatted as HH:MM:SS
      '       

      Private Function ConvertDicomTimeToQueryTime(ByVal dtv As DicomTimeValue) As String
         Try
            ' Add 0s to beginning if necessary, e.g. HH-M-SS needs to be HH-MM-SS
            Return dtv.Hours.ToString().PadLeft(2, "0"c) & ":" & dtv.Minutes.ToString().PadLeft(2, "0"c) & ":" & dtv.Seconds.ToString().PadLeft(2, "0"c)
         Catch ex As Exception
            server.mf.Log("Error converting time:" & vbCr & vbLf & vbCr & vbLf & ex.ToString())
            Return ""
         End Try
      End Function

      Private Sub AddSecheduledProcedureStepSequenceAttributes(ByVal ResponseDicomDS As DicomDataSet, ByVal item As DicomElement)
         ResponseDicomDS.InsertElement(item, True, DemoDicomTags.ScheduledStationAETitle, DicomVRType.UN, False, 0)
         ResponseDicomDS.InsertElement(item, True, DemoDicomTags.ScheduledProcedureStepStartDate, DicomVRType.UN, False, 0)
         ResponseDicomDS.InsertElement(item, True, DemoDicomTags.ScheduledProcedureStepStartTime, DicomVRType.UN, False, 0)
         ResponseDicomDS.InsertElement(item, True, DemoDicomTags.Modality, DicomVRType.UN, False, 0)
         ResponseDicomDS.InsertElement(item, True, DemoDicomTags.ScheduledPerformingPhysicianName, DicomVRType.UN, False, 0)
         ResponseDicomDS.InsertElement(item, True, DemoDicomTags.ScheduledProcedureStepDescription, DicomVRType.UN, False, 0)
         ResponseDicomDS.InsertElement(item, True, DicomTag.ScheduledStationName, DicomVRType.UN, False, 0)
         ResponseDicomDS.InsertElement(item, True, DemoDicomTags.ScheduledProcedureStepLocation, DicomVRType.UN, False, 0)
         Dim sequence As DicomElement = ResponseDicomDS.InsertElement(item, True, DemoDicomTags.ScheduledProtocolCodeSequence, DicomVRType.SQ, True, 0)
         sequence = ResponseDicomDS.InsertElement(sequence, True, DemoDicomTags.Item, DicomVRType.SQ, True, 0)
         ResponseDicomDS.InsertElement(sequence, True, DicomTag.CodeValue, DicomVRType.UN, False, 0)
         ResponseDicomDS.InsertElement(sequence, True, DicomTag.CodingSchemeDesignator, DicomVRType.UN, False, 0)
         ResponseDicomDS.InsertElement(sequence, True, DicomTag.CodeMeaning, DicomVRType.UN, False, 0)
         ResponseDicomDS.InsertElement(item, True, DicomTag.PreMedication, DicomVRType.UN, False, 0)
         ResponseDicomDS.InsertElement(item, True, DemoDicomTags.ScheduledProcedureStepID, DicomVRType.UN, False, 0)
         ResponseDicomDS.InsertElement(item, True, DicomTag.RequestedContrastAgent, DicomVRType.UN, False, 0)

      End Sub

      '
      '       * Initializes a blank dataset to send back to the SCU
      '       

      Private Function PrepareResponseDS() As DicomDataSet
         Try
            Dim ResponseDicomDS As New DicomDataSet()

            ResponseDicomDS.Initialize(DicomClassType.Undefined, DicomDataSetInitializeType.ImplicitVRLittleEndian)

            Dim element As DicomElement

            ' Scheduled Procedure Step
            element = m_ds.FindFirstElement(Nothing, DemoDicomTags.ScheduledProcedureStepSequence, False)
            If element IsNot Nothing Then
               Dim sequence As DicomElement = Nothing
               Dim item As DicomElement = Nothing
               sequence = ResponseDicomDS.InsertElement(Nothing, False, DemoDicomTags.ScheduledProcedureStepSequence, DicomVRType.SQ, True, 0)
               If sequence IsNot Nothing Then
                  item = ResponseDicomDS.InsertElement(sequence, True, DemoDicomTags.Item, DicomVRType.SQ, False, 0)
               End If

               If item IsNot Nothing Then
                  element = m_ds.GetChildElement(element, True)
                  If element IsNot Nothing Then
                     element = m_ds.GetChildElement(element, True)

                     If element Is Nothing Then
                        AddSecheduledProcedureStepSequenceAttributes(ResponseDicomDS, item)
                     Else
                        While element IsNot Nothing
                           Select Case element.Tag
                              Case DemoDicomTags.ScheduledStationAETitle, DemoDicomTags.ScheduledProcedureStepStartDate, DemoDicomTags.ScheduledProcedureStepStartTime, DemoDicomTags.Modality, DemoDicomTags.ScheduledPerformingPhysicianName, DemoDicomTags.ScheduledProcedureStepDescription, _
                               DemoDicomTags.ScheduledProcedureStepLocation, DemoDicomTags.ScheduledProcedureStepID
                                 ResponseDicomDS.InsertElement(item, True, element.Tag, DicomVRType.UN, False, 0)
                                 Exit Select
                           End Select

                           element = m_ds.GetNextElement(element, True, True)
                        End While
                     End If
                  Else
                     AddSecheduledProcedureStepSequenceAttributes(ResponseDicomDS, item)
                  End If
               End If
            End If

            ' Requested Procedure
            Utils.InsertKeyElement(ResponseDicomDS, m_ds, DemoDicomTags.RequestedProcedureID)
            Utils.InsertKeyElement(ResponseDicomDS, m_ds, DemoDicomTags.RequestedProcedureDescription)
            Utils.InsertKeyElement(ResponseDicomDS, m_ds, DemoDicomTags.StudyInstanceUID)
            Utils.InsertKeyElement(ResponseDicomDS, m_ds, DemoDicomTags.RequestedProcedurePriority)
            Utils.InsertKeyElement(ResponseDicomDS, m_ds, DemoDicomTags.ReasonForTheRequestedProcedure)

            ' Imaging Service Request
            Utils.InsertKeyElement(ResponseDicomDS, m_ds, DemoDicomTags.AccessionNumber)
            Utils.InsertKeyElement(ResponseDicomDS, m_ds, DemoDicomTags.RequestingPhysician)
            Utils.InsertKeyElement(ResponseDicomDS, m_ds, DemoDicomTags.ReferringPhysicianName)

            ' Visit Identification
            Utils.InsertKeyElement(ResponseDicomDS, m_ds, DemoDicomTags.AdmissionID)
            Utils.InsertKeyElement(ResponseDicomDS, m_ds, DemoDicomTags.InstitutionName)

            ' Patient Identification
            Utils.InsertKeyElement(ResponseDicomDS, m_ds, DemoDicomTags.PatientName)
            Utils.InsertKeyElement(ResponseDicomDS, m_ds, DemoDicomTags.PatientID)

            ' Patient Demographic
            Utils.InsertKeyElement(ResponseDicomDS, m_ds, DemoDicomTags.PatientBirthDate)
            Utils.InsertKeyElement(ResponseDicomDS, m_ds, DemoDicomTags.PatientSex)
            Utils.InsertKeyElement(ResponseDicomDS, m_ds, DemoDicomTags.PatientWeight)

            Return ResponseDicomDS
         Catch ex As Exception
            ' Throw the exception and let the calling function handle it.
            Throw ex
         End Try
      End Function

      '
      '       * Sets a DicomElement that is either a DicomDateValue or DicomTimeValue
      '       

      Private Sub SetTimeDateKeyElement(ByVal ResponseDS As DicomDataSet, ByVal dt As DateTime, ByVal tag As Long, ByVal bTimeValue As Boolean)
         Try
            Dim element As DicomElement = ResponseDS.FindFirstElement(Nothing, tag, False)
            If element IsNot Nothing Then
               If bTimeValue Then
                  Dim dtv As DicomTimeValue() = New DicomTimeValue(0) {}
                  dtv(0) = New DicomTimeValue(dt)
                  ResponseDS.SetTimeValue(element, dtv)
               Else
                  Dim ddv As DicomDateValue() = New DicomDateValue(0) {}
                  ddv(0) = New DicomDateValue(dt)
                  ResponseDS.SetDateValue(element, ddv)
               End If
            End If
         Catch ex As Exception
            server.mf.Log("Error setting time or date element:" & vbCr & vbLf & vbCr & vbLf & ex.ToString())
            Return
         End Try
      End Sub

      '
      '       * Builds a SQL condition for a list of UIDs.
      '       


      Private Function GetUIDCondition(ByVal Tag As Long, ByVal strFieldName As String) As String
         Dim strRetCondition As String = ""

         Try
            Dim element As DicomElement = m_ds.FindFirstElement(Nothing, Tag, False)
            If element IsNot Nothing Then
               Dim strUID As String
               Dim nUIDsCount As Integer = m_ds.GetElementValueCount(element)

               If nUIDsCount > 0 Then
                  strRetCondition += " AND ("

                  For i As Integer = 0 To nUIDsCount - 1
                     strUID = m_ds.GetStringValue(element, i)
                     strRetCondition += strFieldName & "='" & strUID & "'"

                     If i <> nUIDsCount - 1 Then
                        strRetCondition += " OR "
                     End If
                  Next

                  strRetCondition += ")"
               End If
            End If
         Catch ex As Exception
            server.mf.Log("Error creating UID condition:" & vbCr & vbLf & vbCr & vbLf & ex.ToString())
            strRetCondition = ""
         End Try

         Return strRetCondition
      End Function
   End Class
End Namespace

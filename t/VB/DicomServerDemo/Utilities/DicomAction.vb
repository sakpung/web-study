' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports Microsoft.VisualBasic
Imports System
Imports System.Net
Imports System.Data
Imports System.Threading
Imports System.Collections.Specialized

Imports Leadtools
Imports Leadtools.Dicom
Imports Leadtools.DicomDemos
Imports Leadtools.DicomDemos.Scu
Imports Leadtools.Demos.Database
Imports Leadtools.DicomDemos.Scu.CStore

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
      Private client_Renamed As Client
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
      Dim _store As CStore = Nothing

      Public dsFileName As String

      Private ds_Renamed As DicomDataSet = New DicomDataSet()

      Public Delegate Sub ActionCompleteHandler(ByVal sender As Object, ByVal e As EventArgs)

      Public Event ActionComplete As ActionCompleteHandler

      Public ReadOnly Property Client() As Client
         Get
            Return client_Renamed
         End Get
      End Property

      Public ReadOnly Property DS() As DicomDataSet
         Get
            Return ds_Renamed
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

      Public Sub New(ByVal process As ProcessType, ByVal server As Server, ByVal NetClient As Client)
         Me.server = server
         Me.client_Renamed = NetClient
         Me.process = process
      End Sub

      Public Sub New(ByVal process As ProcessType, ByVal server As Server, ByVal NetClient As Client, ByVal dataset As DicomDataSet)
         Me.server = server
         Me.client_Renamed = NetClient
         Me.process = process

         If Not dataset Is Nothing Then
            Me.ds_Renamed.Copy(dataset, Nothing, Nothing)
         End If
      End Sub

      Protected Overridable Sub OnActionComplete()
         'LastError = e.Error;
         If Not ActionCompleteEvent Is Nothing Then
            ' Invokes the delegates. 
            RaiseEvent ActionComplete(Me, New EventArgs())
         End If

         If ds_Renamed IsNot Nothing Then
            ds_Renamed.Dispose()
            ds_Renamed = Nothing
         End If
      End Sub

      Public Sub Close()
         If _store IsNot Nothing AndAlso _store.IsConnected() Then
            _store.Terminate()
         End If
      End Sub


      Public Sub DoAction()
         If Not client_Renamed.Association Is Nothing Then
            Select Case process
               Case ProcessType.EchoRequest
                  DoEchoRequest()
               Case ProcessType.StoreRequest
                  DoStoreRequest()
               Case ProcessType.FindRequest
                  DoFindRequest()
               Case ProcessType.MoveRequest
                  DoMoveRequest()
            End Select
         End If
         OnActionComplete()
      End Sub

      Private Function IsActionSupported() As Boolean
         Dim id As Byte

         If DicomUidTable.Instance.Find([Class]) Is Nothing Then
            Return False
         End If

         id = client_Renamed.Association.FindAbstract([Class])
         If id = 0 OrElse client_Renamed.Association.GetResult(id) <> DicomAssociateAcceptResultType.Success Then
            Return False
         End If

         Return True
      End Function

      Private Function SaveDataSet(ByVal filename As String) As DicomExceptionCode
         Dim temp As String

         Utils.SetTag(ds_Renamed, DemoDicomTags.FillerOrderNumberProcedure, "01")

         temp = Utils.GetStringValue(ds_Renamed, DemoDicomTags.SOPClassUID)
         Utils.SetTag(ds_Renamed, DemoDicomTags.MediaStorageSOPClassUID, temp)

         temp = Utils.GetStringValue(ds_Renamed, DemoDicomTags.SOPInstanceUID)
         Utils.SetTag(ds_Renamed, DemoDicomTags.MediaStorageSOPInstanceUID, temp)

         Utils.SetTag(ds_Renamed, DemoDicomTags.ImplementationClassUID, client_Renamed.Association.ImplementClass)

         Utils.SetTag(ds_Renamed, DemoDicomTags.ImplementationVersionName, client_Renamed.Association.ImplementationVersionName)

         Try
            ds_Renamed.Save(filename, DicomDataSetSaveFlags.MetaHeaderPresent Or DicomDataSetSaveFlags.GroupLengths)
         Catch de As DicomException
            Return de.Code
         End Try

         Return DicomExceptionCode.Success
      End Function

      Private Function GetUIDName() As String
         Dim uid As DicomUid = DicomUidTable.Instance.Find([Class])

         If uid Is Nothing Then
            Return [Class]
         End If

         Return uid.Name
      End Function

      Private Sub DoEchoRequest()
         If (Not IsActionSupported()) Then
            Dim name As String = GetUIDName()

            server.mf.Log("C-ECHO-REQUEST", "Abstract syntax (" & name & ") not supported by association")
            client_Renamed.SendCEchoResponse(_PresentationID, _MessageID, [Class], DicomCommandStatusType.ClassNotSupported)
            Return
         End If

         client_Renamed.SendCEchoResponse(_PresentationID, MessageID, [Class], DicomCommandStatusType.Success)
         server.mf.Log("C-ECHO-RESPONSE", "Response sent to " & AETitle)
      End Sub

      Private Sub DoStoreRequest()
         Dim status As DicomCommandStatusType = DicomCommandStatusType.ProcessingFailure
         Dim msg As String = "Error saving dataset received from: " & AETitle
         Dim element As DicomElement

         If (Not IsActionSupported()) Then
            Dim name As String = GetUIDName()

            server.mf.Log("C-STORE-REQUEST", "Abstract syntax (" & name & ") not supported by association")
            client_Renamed.SendCStoreResponse(_PresentationID, _MessageID, _Class, _Instance, DicomCommandStatusType.ClassNotSupported)
            Return
         End If

         element = ds_Renamed.FindFirstElement(Nothing, DemoDicomTags.SOPInstanceUID, True)
         If Not element Is Nothing Then
            Dim value As String = ds_Renamed.GetConvertValue(element)
            Dim file As String
            Dim ret As InsertReturn

            file = server.ImageDir & value & ".dcm"
            ret = server.mf.DicomData.Insert(ds_Renamed, file)
            Select Case ret
               Case InsertReturn.Success
                  Dim dret As DicomExceptionCode = SaveDataSet(file)
                  If dret = DicomExceptionCode.Success Then
                     status = DicomCommandStatusType.Success
                  Else
                     msg = "Error saving dicom file: " & dret.ToString()
                  End If
                  server.mf.Log("C-STORE-REQUEST", "New file imported: " & file)
               Case InsertReturn.Exists
                  msg = "File (" & file & ") not imported. Record already exists in database"
               Case InsertReturn.Error
                  msg = "Error importing file: " & file
            End Select

         End If

         If status <> DicomCommandStatusType.Success Then
            server.mf.Log("C-STORE-REQUEST", msg)
         End If

         client_Renamed.SendCStoreResponse(_PresentationID, _MessageID, _Class, _Instance, status)
         server.mf.Log("C-STORE-RESPONSE", "Response sent to " & AETitle)
      End Sub

      Private Sub DoFindRequest()
         Dim level As String
         Dim msgTag As String = ""
         Dim status As DicomCommandStatusType

         If (Not IsActionSupported()) Then
            Dim name As String = GetUIDName()

            server.mf.Log("C-FIND-REQUEST", "Abstract syntax (" & name & ") not supported by association")
            client_Renamed.SendCFindResponse(_PresentationID, _MessageID, _Class, DicomCommandStatusType.ClassNotSupported, Nothing)
            Return
         End If

         If ds_Renamed Is Nothing Then
            server.mf.Log("C-FIND-REQUEST", "No dataset provided")
            client_Renamed.SendCFindResponse(_PresentationID, _MessageID, _Class, DicomCommandStatusType.InvalidArgumentValue, Nothing)
            Return
         End If

         level = Utils.GetStringValue(ds_Renamed, DemoDicomTags.QueryRetrieveLevel)
         status = AttributeStatus(level, msgTag)
         If status <> DicomCommandStatusType.Success Then
            server.mf.Log("C-FIND-REQUEST", msgTag)
            client_Renamed.SendCFindResponse(_PresentationID, _MessageID, _Class, status, Nothing)
            Return
         End If

         Try
            Select Case level
               Case "PATIENT"
                  DoPatientFind()
               Case "STUDY"
                  DoStudyFind()
               Case "SERIES"
                  DoSeriesFind()
               Case "IMAGE"
                  DoFindImage()
               Case Else
                  server.mf.Log("C-FIND-REQUEST", "Invalid query retrieve level: " & level)
                  client_Renamed.SendCFindResponse(_PresentationID, _MessageID, _Class, DicomCommandStatusType.InvalidAttributeValue, Nothing)
            End Select
         Catch e As Exception
            server.mf.Log("C-FIND-REQUEST", "Processing failure: " & e.Message)
            If Nothing IsNot client_Renamed AndAlso client_Renamed.IsConnected() Then
               client_Renamed.SendCFindResponse(_PresentationID, _MessageID, _Class, DicomCommandStatusType.ProcessingFailure, Nothing)
            End If
         End Try
      End Sub

      Private Sub DoMoveRequest()
         Dim status As DicomCommandStatusType
         Dim ui As UserInfo
         Dim level As String, msgTag As String = ""

         If (Not IsActionSupported()) Then
            Dim name As String = GetUIDName()

            server.mf.Log("C-MOVE-REQUEST", "Abstract syntax (" & name & ") not supported by association")
            client_Renamed.SendCMoveResponse(_PresentationID, _MessageID, _Class, DicomCommandStatusType.ClassNotSupported, 0, 0, 0, 0, Nothing)
            Return
         End If

         ui = server.mf.UsersData.LoadMoveAE(_MoveAETitle)
         If ui Is Nothing Then
            server.mf.Log("C-MOVE-REQUEST", "User information not found")
            client_Renamed.SendCMoveResponse(_PresentationID, _MessageID, _Class, DicomCommandStatusType.ProcessingFailure, 0, 0, 0, 0, Nothing)
            Return
         End If

         level = Utils.GetStringValue(ds_Renamed, DemoDicomTags.QueryRetrieveLevel)
         status = AttributeStatus(level, msgTag)
         If status <> DicomCommandStatusType.Success Then
            server.mf.Log("C-MOVE-REQUEST", msgTag)
            client_Renamed.SendCMoveResponse(_PresentationID, _MessageID, _Class, status, 0, 0, 0, 0, Nothing)
            Return
         End If

         Select Case level
            Case "PATIENT"
               MoveImages(ui, QueryLevel.Patient)
            Case "STUDY"
               MoveImages(ui, QueryLevel.Study)
            Case "SERIES"
               MoveImages(ui, QueryLevel.Series)
            Case "IMAGE"
               MoveImages(ui, QueryLevel.Image)
            Case Else
               server.mf.Log("C-MOVE-REQUEST", "Invalid query retrieve level: " & level)
               client_Renamed.SendCMoveResponse(_PresentationID, _MessageID, _Class, DicomCommandStatusType.InvalidAttributeValue, 0, 0, 0, 0, Nothing)
         End Select
      End Sub

      Private Function AttributeStatus(ByVal level As String, ByRef msgTag As String) As DicomCommandStatusType
         If level.Length = 0 Then
            msgTag = "Query Retrieve Level"
            Return DicomCommandStatusType.InvalidArgumentValue
         End If

         If _Class = DicomUidType.PatientRootQueryFind AndAlso level <> "PATIENT" Then
            If (Not Utils.IsTagPresent(ds_Renamed, DemoDicomTags.PatientID)) Then
               msgTag = "Patient ID"
               Return DicomCommandStatusType.MissingAttribute
            End If

            Dim pid As String

            pid = Utils.GetStringValue(ds_Renamed, DemoDicomTags.PatientID)

            If pid.Length = 0 Then
               msgTag = "Patient ID missing value"
               Return DicomCommandStatusType.MissingAttribute
            End If
         End If

         If level = "STUDY" OrElse level = "SERIES" OrElse level = "IMAGE" Then
            If (Not Utils.IsTagPresent(ds_Renamed, DemoDicomTags.StudyInstanceUID)) Then
               msgTag = "Study Instance UID"
               Return DicomCommandStatusType.MissingAttribute
            End If

            If level = "SERIES" OrElse level = "IMAGE" Then
               If Utils.GetStringValue(ds_Renamed, DemoDicomTags.StudyInstanceUID).Length = 0 Then
                  msgTag = "Study Instance UID missing value"
                  Return DicomCommandStatusType.MissingAttribute
               End If
            End If
         End If

         If level = "SERIES" OrElse level = "IMAGE" Then
            If (Not Utils.IsTagPresent(ds_Renamed, DemoDicomTags.SeriesInstanceUID)) Then
               msgTag = "Series Instance ID"
               Return DicomCommandStatusType.MissingAttribute
            End If
         End If

         If level = "IMAGE" Then
            If (Not Utils.IsTagPresent(ds_Renamed, DemoDicomTags.SOPInstanceUID)) Then
               msgTag = "SOP Instance ID"
               Return DicomCommandStatusType.MissingAttribute
            End If
         End If

         Return DicomCommandStatusType.Success
      End Function

      Private Sub DoPatientFind()
         Dim dv As DataView = Nothing
         Dim filter As String = "PATIENTID LIKE '*'"
         Dim patientID As String = Utils.GetStringValue(ds_Renamed, DemoDicomTags.PatientID)
         Dim patientName As String = Utils.GetStringValue(ds_Renamed, DemoDicomTags.PatientName)
         Dim rspDs As DicomDataSet

         If patientID.Length > 0 Then
            filter = "PATIENTID LIKE '" & patientID & "'"
         End If
         If patientName.Length > 0 Then
            If filter.Length > 0 Then
               filter &= " AND "
            End If
            filter &= "PATIENTNAME LIKE '" & patientName & "'"
         End If


         server.mf.Log("DB QUERY", filter)
         dv = server.mf.DicomData.FindRecords("Patients", filter)
         For Each drv As DataRowView In dv
            Dim row As DataRow = drv.Row

            rspDs = InitResponseDS(QueryLevel.Patient)
            Utils.SetKeyElement(rspDs, DemoDicomTags.PatientID, row("PatientID"))
            If Not row("PatientName") Is Nothing Then
               Utils.SetKeyElement(rspDs, DemoDicomTags.PatientName, row("PatientName"))
            End If
            If Not row("PatientBirthDate") Is Nothing Then
               Utils.SetKeyElement(rspDs, DemoDicomTags.PatientBirthDate, row("PatientBirthDate"))
            End If
            If Not row("PatientBirthTime") Is Nothing Then
               Utils.SetKeyElement(rspDs, DemoDicomTags.PatientBirthTime, row("PatientBirthTime"))
            End If
            If Not row("PatientSex") Is Nothing Then
               Utils.SetKeyElement(rspDs, DemoDicomTags.PatientSex, row("PatientSex"))
            End If
            If Not row("EthnicGroup") Is Nothing Then
               Utils.SetKeyElement(rspDs, DemoDicomTags.EthnicGroup, row("EthnicGroup"))
            End If
            If Not row("PatientComments") Is Nothing Then
               Utils.SetKeyElement(rspDs, DemoDicomTags.PatientComments, row("PatientComments"))
            End If

            Dim seriesCount As Integer = 0
            Dim imageCount As Integer = 0

            Dim dvStudies As DataView = server.mf.DicomData.FindRecords("Studies", "PatientID = '" & row("PatientID").ToString() & "'")
            Utils.SetKeyElement(rspDs, DemoDicomTags.NumberOfPatientRelatedStudies, dvStudies.Count)
            For Each drvStudies As DataRowView In dvStudies
               Dim rowStudy As DataRow = drvStudies.Row
               Dim dvSeries As DataView

               dvSeries = server.mf.DicomData.FindRecords("Series", "StudyInstanceUID = '" & rowStudy("StudyInstanceUID").ToString() & "'")
               seriesCount += dvSeries.Count
               For Each drvSeries As DataRowView In dvSeries
                  Dim rowSeries As DataRow = drvSeries.Row
                  Dim drvImages As DataView

                  drvImages = server.mf.DicomData.FindRecords("Images", "SeriesInstanceUID = '" & rowSeries("SeriesInstanceUID").ToString() & "'")
                  imageCount += drvImages.Count
               Next drvSeries
            Next drvStudies
            Utils.SetKeyElement(rspDs, DemoDicomTags.NumberOfPatientRelatedSeries, seriesCount)
            Utils.SetKeyElement(rspDs, DemoDicomTags.NumberOfPatientRelatedInstances, imageCount)

            Try
               Dim file As String = ""

               client_Renamed.SendCFindResponse(_PresentationID, _MessageID, _Class, DicomCommandStatusType.Pending, rspDs)

               If server.SaveDSSent AndAlso (Not Logger.DisableLogging) Then
                  file = server.LogDS("C-FIND-RESPONSE", client_Renamed, rspDs)
               End If

               server.mf.Log("C-FIND-RESPONSE", "Response sent to " & _AETitle & " (pending)", file)
            Catch
            End Try
            rspDs.Dispose()
         Next drv
         client_Renamed.SendCFindResponse(_PresentationID, _MessageID, _Class, DicomCommandStatusType.Success, Nothing)
         server.mf.Log("C-FIND-RESPONSE", "Response sent to " & _AETitle & " (final)")
      End Sub

      Private Sub DoStudyFind()
         Dim dv As DataView = Nothing
         Dim filter As String = ""
         Dim patientID As String = "", accessionNum As String, studyID As String, patientName As String, referringPhysicianName As String
         Dim studyInstance As StringCollection
         Dim rspDs As DicomDataSet
         Dim studyDate As Byte()

         If Utils.IsTagPresent(ds_Renamed, DemoDicomTags.PatientID) Then
            patientID = Utils.GetStringValue(ds_Renamed, DemoDicomTags.PatientID)
         End If

         accessionNum = Utils.GetStringValue(ds_Renamed, DemoDicomTags.AccessionNumber)
         studyID = Utils.GetStringValue(ds_Renamed, DemoDicomTags.StudyID)
         patientName = Utils.GetStringValue(ds_Renamed, DemoDicomTags.PatientName)
         referringPhysicianName = Utils.GetStringValue(ds_Renamed, DemoDicomTags.ReferringPhysicianName)

         If patientID.Length > 0 Then
            If filter.Length > 0 Then
               filter &= " AND "
            End If
            filter &= "PatientID = '" & patientID & "'"
         End If

         If patientName.Length > 0 Then
            If filter.Length > 0 Then
               filter &= " AND "
            End If
            filter &= "PatientName = '" & patientName & "'"
         End If

         studyInstance = Utils.GetStringValues(ds_Renamed, DemoDicomTags.StudyInstanceUID)

         For Each inst As String In studyInstance
            If filter.Length > 0 Then
               filter &= " AND "
            End If
            filter &= "StudyInstanceUID = '" & inst & "'"
         Next inst

         studyDate = Utils.GetBinaryValues(ds_Renamed, DemoDicomTags.StudyDate)
         If Not studyDate Is Nothing AndAlso studyDate.Length > 0 Then
            Dim [date] As String
            Dim del As String = "\"
            Dim dateArray As String()

            [date] = System.Text.ASCIIEncoding.ASCII.GetString(studyDate)
            Do While [date].IndexOf(Constants.vbNullChar) <> -1
               [date] = [date].Remove([date].IndexOf(Constants.vbNullChar), 1)
            Loop
            dateArray = [date].Split(del.ToCharArray())

            Dim i As Integer = 0

            For i = 0 To dateArray.Length - 1
               dateArray(i) = dateArray(i).Trim()
            Next

            If filter.Length > 0 Then
               filter &= " AND "
            End If
            If dateArray(0).IndexOf("-") <> -1 Then
               Dim reqDate As String

               ' We are working with a date range
               '
               ' These are the rules

               '  1. The date inside DICOM is formatted as yyyymmdd so
               '     "19930822" would represent August 22, 1993.
               '  2. A string of the form "<date1> - <date2>" shall match
               '     all occurrences of dates which fall between <date1>
               '     and <date2> inclusive.
               '  3. A string of the form "- <date1>" shall match all occurrences of
               '     dates prior to and including <date1>.
               '  4. A string of the form "<date1> -" shall match all occurrences of
               '     <date1> and subsequent dates.

               If dateArray(0).Substring(0, 1) = "-" Then
                  reqDate = dateArray(0).Substring(1)

                  filter &= "( StudyDate <= #" & ConvertToQueryDate(reqDate) & "#)"
               ElseIf dateArray(0).Substring(dateArray(0).Length - 1, 1) = "-" Then
                  reqDate = dateArray(0).Substring(0, dateArray(0).Length - 1)

                  filter &= "( StudyDate >= #" & ConvertToQueryDate(reqDate) & "#)"
               Else
                  Dim cmpDates As String() = dateArray(0).Split("-"c)

                  filter &= "( StudyDate >= #" & ConvertToQueryDate(cmpDates(0)) & "# AND "
                  filter &= "StudyDate <= #" & ConvertToQueryDate(cmpDates(1)) & "#)"
               End If
            Else
               filter &= "( StudyDate = #" & ConvertToQueryDate(dateArray(0)) & "#)"
            End If
         End If

         If accessionNum.Length > 0 Then
            If filter.Length > 0 Then
               filter &= " AND "
            End If
            filter &= "AccessionNumber LIKE '" & accessionNum & "'"
         End If

         If studyID.Length > 0 Then
            If filter.Length > 0 Then
               filter &= " AND "
            End If
            filter &= "StudyID LIKE '" & studyID & "'"
         End If

         If referringPhysicianName.Length > 0 Then
            If filter.Length > 0 Then
               filter &= " AND "
            End If
            filter &= "ReferringDrName LIKE '" & referringPhysicianName & "'"
         End If


         If filter.Length = 0 Then
            filter = "STUDYID LIKE '*'"
         End If

         server.mf.Log("DB QUERY", filter)
         dv = server.mf.DicomData.FindRecords("Studies", filter)
         For Each drv As DataRowView In dv
            Dim row As DataRow = drv.Row

            rspDs = InitResponseDS(QueryLevel.Study)
            If _Class = DicomUidType.PatientRootQueryFind Then
               Utils.SetKeyElement(rspDs, DemoDicomTags.PatientID, patientID)
            End If
            Utils.SetKeyElement(rspDs, DemoDicomTags.StudyInstanceUID, row("StudyInstanceUID"))

            If Not row("StudyDate") Is Nothing Then
               Utils.SetKeyElement(rspDs, DemoDicomTags.StudyDate, row("StudyDate"))
            End If
            If Not row("StudyTime") Is Nothing Then
               Utils.SetKeyElement(rspDs, DemoDicomTags.StudyTime, row("StudyTime"))
            End If
            If Not row("AccessionNumber") Is Nothing Then
               Utils.SetKeyElement(rspDs, DemoDicomTags.AccessionNumber, row("AccessionNumber"))
            End If
            If Not row("StudyID") Is Nothing Then
               Utils.SetKeyElement(rspDs, DemoDicomTags.StudyID, row("StudyID"))
            End If

            If Not row("PatientID") Is Nothing Then
               Utils.SetKeyElement(rspDs, DemoDicomTags.PatientID, row("PatientID"))
            End If
            If Not row("PatientName") Is Nothing Then
               Utils.SetKeyElement(rspDs, DemoDicomTags.PatientName, row("PatientName"))
            End If

            If Not row("ReferringDrName") Is Nothing Then
               Utils.SetKeyElement(rspDs, DemoDicomTags.ReferringPhysicianName, row("ReferringDrName"))
            End If

            Dim dvSeries As DataView
            Dim seriesCount As Integer = 0
            Dim imageCount As Integer = 0

            dvSeries = server.mf.DicomData.FindRecords("Series", "StudyInstanceUID = '" & row("StudyInstanceUID").ToString() & "'")
            seriesCount += dvSeries.Count
            For Each drvSeries As DataRowView In dvSeries
               Dim rowSeries As DataRow = drvSeries.Row
               Dim drvImages As DataView

               drvImages = server.mf.DicomData.FindRecords("Images", "SeriesInstanceUID = '" & rowSeries("SeriesInstanceUID").ToString() & "'")
               imageCount += drvImages.Count
            Next drvSeries

            Utils.SetKeyElement(rspDs, DemoDicomTags.NumberOfStudyRelatedSeries, seriesCount)
            Utils.SetKeyElement(rspDs, DemoDicomTags.NumberOfStudyRelatedInstances, imageCount)

            Try
               Dim file As String = ""

               client_Renamed.SendCFindResponse(_PresentationID, _MessageID, _Class, DicomCommandStatusType.Pending, rspDs)

               If server.SaveDSSent AndAlso (Not Logger.DisableLogging) Then
                  file = server.LogDS("C-FIND-RESPONSE", client_Renamed, rspDs)
               End If

               server.mf.Log("C-FIND-RESPONSE", "Response sent to " & _AETitle & " (pending)", file)
            Catch
            End Try
            rspDs.Dispose()
         Next drv
         client_Renamed.SendCFindResponse(_PresentationID, _MessageID, _Class, DicomCommandStatusType.Success, Nothing)
         server.mf.Log("C-FIND-RESPONSE", "Response sent to " & _AETitle & " (final)")
      End Sub

      Private Sub DoSeriesFind()
         Dim dv As DataView = Nothing
         Dim filter As String = ""
         Dim modality, seriesNumber, patientID, studyInstance As String
         Dim seriesInstance As StringCollection
         Dim rspDS As DicomDataSet

         patientID = Utils.GetStringValue(ds_Renamed, DemoDicomTags.PatientID)
         modality = Utils.GetStringValue(ds_Renamed, DemoDicomTags.Modality)
         seriesNumber = Utils.GetStringValue(ds_Renamed, DemoDicomTags.SeriesNumber)
         studyInstance = Utils.GetStringValue(ds_Renamed, DemoDicomTags.StudyInstanceUID)

         filter = "StudyInstanceUID = '" & studyInstance & "'"

         If _Class = DicomUidType.PatientRootQueryFind AndAlso patientID.Length > 0 Then
            filter &= " AND PatientID = '" & patientID & "'"
         End If

         seriesInstance = Utils.GetStringValues(ds_Renamed, DemoDicomTags.SeriesInstanceUID)

         For Each inst As String In seriesInstance
            filter &= " AND SeriesInstanceUID='" & inst & "'"
         Next inst

         If modality.Length > 0 Then
            filter &= " AND Modality LIKE '" & modality & "'"
         End If

         If seriesNumber.Length > 0 Then
            filter &= " AND SeriesNumber = " & seriesNumber
         End If

         server.mf.Log("DB QUERY", filter)
         dv = server.mf.DicomData.FindRecords("Series", filter)
         For Each drv As DataRowView In dv
            Dim row As DataRow = drv.Row

            rspDS = InitResponseDS(QueryLevel.Series)
            If _Class = DicomUidType.PatientRootQueryFind Then
               Utils.SetKeyElement(rspDS, DemoDicomTags.PatientID, patientID)
            End If
            Utils.SetKeyElement(rspDS, DemoDicomTags.StudyInstanceUID, studyInstance)
            Utils.SetKeyElement(rspDS, DemoDicomTags.SeriesInstanceUID, row("SeriesInstanceUID"))

            If Not row("Modality") Is Nothing Then
               Utils.SetKeyElement(rspDS, DemoDicomTags.Modality, row("Modality"))
            End If

            If Not row("SeriesNumber") Is Nothing Then
               Utils.SetKeyElement(rspDS, DemoDicomTags.SeriesNumber, row("SeriesNumber"))
            End If

            If Not row("SeriesDate") Is Nothing Then
               Utils.SetKeyElement(rspDS, DemoDicomTags.SeriesDate, row("SeriesDate"))
            End If

            Dim dvImages As DataView

            dvImages = server.mf.DicomData.FindRecords("Images", "SeriesInstanceUID = '" & row("SeriesInstanceUID").ToString() & "'")
            Utils.SetKeyElement(rspDS, DemoDicomTags.NumberOfSeriesRelatedInstances, dv.Count)

            Try
               Dim file As String = ""

               client_Renamed.SendCFindResponse(_PresentationID, _MessageID, _Class, DicomCommandStatusType.Pending, rspDS)

               If server.SaveDSSent AndAlso (Not Logger.DisableLogging) Then
                  file = server.LogDS("C-FIND-RESPONSE", client_Renamed, rspDS)
               End If

               server.mf.Log("C-FIND-RESPONSE", "Response sent to " & _AETitle & " (pending)", file)
            Catch
            End Try
            rspDS.Dispose()
         Next drv
         client_Renamed.SendCFindResponse(_PresentationID, _MessageID, _Class, DicomCommandStatusType.Success, Nothing)
         server.mf.Log("C-FIND-RESPONSE", "Response sent to " & _AETitle & " (final)")
      End Sub

      Private Sub DoFindImage()
         Dim dv As DataView = Nothing
         Dim filter As String = ""
         Dim rspDS As DicomDataSet
         Dim studyInstance, patientID, instanceNumber As String
         Dim seriesInstance As String
         Dim sopInstanceUID As StringCollection

         studyInstance = Utils.GetStringValue(ds_Renamed, DemoDicomTags.StudyInstanceUID)
         seriesInstance = Utils.GetStringValue(ds_Renamed, DemoDicomTags.SeriesInstanceUID)
         patientID = Utils.GetStringValue(ds_Renamed, DemoDicomTags.PatientID)
         instanceNumber = Utils.GetStringValue(ds_Renamed, DemoDicomTags.InstanceNumber)

         filter = "StudyInstanceUID = '" & studyInstance & "'"
         filter &= " AND SeriesInstanceUID = '" & seriesInstance & "'"

         If _Class = DicomUidType.PatientRootQueryFind AndAlso patientID.Length > 0 Then
            filter &= " AND PatientID = '" & patientID & "'"
         End If

         sopInstanceUID = Utils.GetStringValues(ds_Renamed, DemoDicomTags.SOPInstanceUID)

         For Each inst As String In sopInstanceUID
            filter &= " AND SOPInstanceUID ='" & inst & "'"
         Next inst

         If instanceNumber.Length > 0 Then
            filter &= " AND InstanceNumber = " & instanceNumber.ToString()
         End If

         server.mf.Log("DB QUERY", filter)
         dv = server.mf.DicomData.FindRecords("Images", filter)
         For Each drv As DataRowView In dv
            Dim row As DataRow = drv.Row

            rspDS = InitResponseDS(QueryLevel.Image)
            If _Class = DicomUidType.PatientRootQueryFind Then
               Utils.SetKeyElement(rspDS, DemoDicomTags.PatientID, patientID)
            End If
            Utils.SetKeyElement(rspDS, DemoDicomTags.SOPInstanceUID, row("SOPInstanceUID"))

            If Not row("InstanceNumber") Is Nothing Then
               Utils.SetKeyElement(rspDS, DemoDicomTags.InstanceNumber, row("InstanceNumber"))
            End If

            Try
               Dim file As String = ""

               client_Renamed.SendCFindResponse(_PresentationID, _MessageID, _Class, DicomCommandStatusType.Pending, rspDS)

               If server.SaveDSSent AndAlso (Not Logger.DisableLogging) Then
                  file = server.LogDS("C-FIND-RESPONSE", Client, rspDS)
               End If

               server.mf.Log("C-FIND-RESPONSE", "Response sent to " & _AETitle & " (pending)", file)
            Catch
            End Try
            rspDS.Dispose()
         Next drv
         client_Renamed.SendCFindResponse(_PresentationID, _MessageID, _Class, DicomCommandStatusType.Success, Nothing)
         server.mf.Log("C-FIND-RESPONSE", "Response sent to " & _AETitle & " (final)")
      End Sub

      Private Function ConvertToQueryDate(ByVal reqDate As String) As String
         Return reqDate.Substring(4, 2) & "/" & reqDate.Substring(6, 2) & "/" & reqDate.Substring(0, 4)
      End Function

      Private Function InitResponseDS(ByVal level As QueryLevel) As DicomDataSet
         Dim rspDs As DicomDataSet = New DicomDataSet()

         rspDs.Initialize(DicomClassType.Undefined, DicomDataSetInitializeType.ExplicitVRLittleEndian)
         Select Case level
            Case QueryLevel.Patient
               Utils.SetTag(rspDs, DemoDicomTags.QueryRetrieveLevel, "PATIENT")

               ' Required Keys
               Utils.InsertKeyElement(rspDs, ds_Renamed, DemoDicomTags.PatientName)

               ' Optional Keys
               Utils.InsertKeyElement(rspDs, ds_Renamed, DemoDicomTags.PatientBirthDate)
               Utils.InsertKeyElement(rspDs, ds_Renamed, DemoDicomTags.PatientBirthTime)
               Utils.InsertKeyElement(rspDs, ds_Renamed, DemoDicomTags.PatientSex)
               Utils.InsertKeyElement(rspDs, ds_Renamed, DemoDicomTags.EthnicGroup)
               Utils.InsertKeyElement(rspDs, ds_Renamed, DemoDicomTags.PatientComments)
               Utils.InsertKeyElement(rspDs, ds_Renamed, DemoDicomTags.NumberOfPatientRelatedStudies)
               Utils.InsertKeyElement(rspDs, ds_Renamed, DemoDicomTags.NumberOfPatientRelatedSeries)
               Utils.InsertKeyElement(rspDs, ds_Renamed, DemoDicomTags.NumberOfPatientRelatedInstances)
            Case QueryLevel.Study
               Utils.SetTag(rspDs, DemoDicomTags.QueryRetrieveLevel, "STUDY")

               ' Require Keys
               Utils.InsertKeyElement(rspDs, ds_Renamed, DemoDicomTags.StudyDate)
               Utils.InsertKeyElement(rspDs, ds_Renamed, DemoDicomTags.StudyTime)
               Utils.InsertKeyElement(rspDs, ds_Renamed, DemoDicomTags.AccessionNumber)
               Utils.InsertKeyElement(rspDs, ds_Renamed, DemoDicomTags.StudyID)

               Utils.InsertKeyElement(rspDs, ds_Renamed, DemoDicomTags.PatientName)
               Utils.InsertKeyElement(rspDs, ds_Renamed, DemoDicomTags.PatientID)

               ' Optional Keys
               Utils.InsertKeyElement(rspDs, ds_Renamed, DemoDicomTags.StudyDescription)
               Utils.InsertKeyElement(rspDs, ds_Renamed, DemoDicomTags.ReferringPhysicianName)
               Utils.InsertKeyElement(rspDs, ds_Renamed, DemoDicomTags.NumberOfStudyRelatedSeries)
               Utils.InsertKeyElement(rspDs, ds_Renamed, DemoDicomTags.NumberOfStudyRelatedInstances)
            Case QueryLevel.Series
               Utils.SetTag(rspDs, DemoDicomTags.QueryRetrieveLevel, "SERIES")

               ' Required Keys
               Utils.InsertKeyElement(rspDs, ds_Renamed, DemoDicomTags.Modality)
               Utils.InsertKeyElement(rspDs, ds_Renamed, DemoDicomTags.SeriesNumber)
               Utils.InsertKeyElement(rspDs, ds_Renamed, DemoDicomTags.SeriesDate)

               ' Optional Keys
               Utils.InsertKeyElement(rspDs, ds_Renamed, DemoDicomTags.NumberOfSeriesRelatedInstances)
            Case QueryLevel.Image
               Utils.SetTag(rspDs, DemoDicomTags.QueryRetrieveLevel, "IMAGE")

               ' Required Keys
               Utils.InsertKeyElement(rspDs, ds_Renamed, DemoDicomTags.InstanceNumber)
         End Select

         If _Class = DicomUidType.PatientRootQueryFind And level <> QueryLevel.Study Then
            rspDs.InsertElement(Nothing, False, DemoDicomTags.PatientID, DicomVRType.UN, False, 0)
         End If

         If level = QueryLevel.Study OrElse level = QueryLevel.Series OrElse level = QueryLevel.Image Then
            rspDs.InsertElement(Nothing, False, DemoDicomTags.StudyInstanceUID, DicomVRType.UN, False, 0)
         End If

         If level = QueryLevel.Series OrElse level = QueryLevel.Image Then
            rspDs.InsertElement(Nothing, False, DemoDicomTags.SeriesInstanceUID, DicomVRType.UN, False, 0)
         End If

         If level = QueryLevel.Image Then
            rspDs.InsertElement(Nothing, False, DemoDicomTags.SOPInstanceUID, DicomVRType.UN, False, 0)
         End If

         Return rspDs
      End Function

      Public Sub MoveImages(ByVal ui As UserInfo, ByVal level As QueryLevel)
         Dim filter As String = ""
         Dim instanceIds As StringCollection
         Dim dv As DataView

         If _Class = DicomUidType.PatientRootQueryFind Then
            filter = "PatientID = '" & Utils.GetStringValue(ds_Renamed, DemoDicomTags.PatientID) & "'"
         End If

         If level = QueryLevel.Study OrElse level = QueryLevel.Series OrElse level = QueryLevel.Image Then
            If filter.Length > 0 Then
               filter &= " AND "
            End If

            If level <> QueryLevel.Study Then
               filter &= "StudyInstanceUID = '" & Utils.GetStringValue(ds_Renamed, DemoDicomTags.StudyInstanceUID) & "'"
            Else
               instanceIds = Utils.GetStringValues(ds_Renamed, DemoDicomTags.StudyInstanceUID)
               Dim i As Integer = 0
               Do While i < instanceIds.Count
                  filter &= "StudyInstanceUID ='" & instanceIds(i) & "'"
                  If i < instanceIds.Count - 1 Then
                     filter &= " AND "
                  End If
                  i += 1
               Loop
            End If
         End If

         If level = QueryLevel.Series OrElse level = QueryLevel.Image Then
            If filter.Length > 0 Then
               filter &= " AND "
            End If

            If level <> QueryLevel.Series Then
               filter &= "SeriesInstanceUID = '" & Utils.GetStringValue(ds_Renamed, DemoDicomTags.SeriesInstanceUID) & "'"
            Else
               instanceIds = Utils.GetStringValues(ds_Renamed, DemoDicomTags.SeriesInstanceUID)
               Dim i As Integer = 0
               Do While i < instanceIds.Count
                  filter &= "SeriesInstanceUID ='" & instanceIds(i) & "'"
                  If i < instanceIds.Count - 1 Then
                     filter &= " AND "
                  End If
                  i += 1
               Loop
            End If
         End If

         If level = QueryLevel.Image Then
            If filter.Length > 0 Then
               filter &= " AND "
            End If

            instanceIds = Utils.GetStringValues(ds_Renamed, DemoDicomTags.SOPInstanceUID)
            Dim i As Integer = 0
            Do While i < instanceIds.Count
               filter &= "SOPInstanceUID ='" & instanceIds(i) & "'"
               If i < instanceIds.Count - 1 Then
                  filter &= " AND "
               End If
               i += 1
            Loop
         End If

         server.mf.Log("DB QUERY", filter)
         dv = server.mf.DicomData.FindRecords("Images", filter)
         If dv.Count = 0 Then
            server.mf.Log("C-MOVE-REQUEST", "No matching images found" & level)
            client_Renamed.SendCMoveResponse(_PresentationID, _MessageID, _Class, DicomCommandStatusType.Success, 0, 0, 0, 0, Nothing)
            Return
         End If

         Dim dcmServer As DicomServer = New DicomServer()
         Dim store As CStore = New CStore()
         For Each drv As DataRowView In dv
            Dim row As DataRow = drv.Row

            store.Files.Add(row("ReferencedFile").ToString())
         Next drv
         dcmServer.AETitle = ui.AETitle
         dcmServer.Port = ui.Port
         dcmServer.Timeout = server.Timeout * 60
         dcmServer.Address = System.Net.IPAddress.Parse(ui.IPAddress)
#If (LEADTOOLS_V17_OR_LATER) Then
         dcmServer.IpType = server.IpType
#End If

         store.ImplementationClass = "1.2.840.114257.1123456"
         store.ImplementationVersionName = "1"
         store.ProtocolVersion = "1"
         AddHandler store.Status, AddressOf store_Status
         AddHandler store.ProgressFiles, AddressOf store_ProgressFiles
         store.Store(dcmServer, server.CalledAE)
         _store = store
      End Sub

      Private Sub store_Status(ByVal sender As Object, ByVal e As StatusEventArgs)
         Dim message As String = ""
         Dim done As Boolean = False
         Dim status As DicomCommandStatusType = DicomCommandStatusType.Success

         If e.Type = StatusType.Error Then
            message = "DICOM error. The process will be terminated! -- Error code is: " & e.Error.ToString()
            done = True
         Else
            Select Case e.Type
               Case StatusType.ConnectFailed
                  message = "Connect operation failed."
                  done = True
                  status = DicomCommandStatusType.ProcessingFailure
               Case StatusType.ConnectSucceeded
                  message = "Connected successfully."
                  message &= "  Peer Address:  " & e.PeerIP.ToString()
                  message &= "  Peer Port:  " & e.PeerPort.ToString()
               Case StatusType.SendAssociateRequest
                  message = "Sending association request..."
               Case StatusType.ReceiveAssociateAccept
                  message = "Received Associate Accept."
                  message &= "  Calling AE:  " & e.CallingAE
                  message &= "  Called AE:  " & e.CalledAE
               Case StatusType.ReceiveAssociateReject
                  message = "Received Associate Reject!"
                  done = True
               Case StatusType.AbstractSyntaxNotSupported
                  message = "Abstract Syntax NOT supported!"
                  done = True
               Case StatusType.SendCStoreRequest
                  message = "Sending C-STORE Request..."
               Case StatusType.ReceiveCStoreResponse
                  If e.Error = DicomExceptionCode.Success Then
                     message = "**** Storage completed successfully ****"
                  Else
                     message = "**** Status code is: " & e.Status.ToString()
                  End If
               Case StatusType.ConnectionClosed
                  message = "Network Connection closed!"
                  done = True
               Case StatusType.ProcessTerminated
                  message = "Process has been terminated!"
                  done = True
               Case StatusType.SendReleaseRequest
                  message = "Sending release request..."
               Case StatusType.ReceiveReleaseResponse
                  message = "Receiving release response"
                  done = True
               Case StatusType.Timeout
                  message = "Communication timeout. Process will be terminated."
                  done = True
            End Select
         End If

         server.mf.Log("C-STORE-REQUEST", message)

         If done Then
            If client_Renamed.IsConnected() Then

               client_Renamed.SendCMoveResponse(_PresentationID, _MessageID, _Class, status, 0, 0, 0, 0, Nothing)
               If Not _store Is Nothing Then
                  _store.Close()
                  _store.Dispose()
                  _store = Nothing
               End If
            End If
         End If
      End Sub

      Private Sub store_ProgressFiles(ByVal sender As Object, ByVal e As ProgressFilesEventArgs)
         server.mf.Log("C-STORE-REQUEST", "Processing file: " & e.File.FullName, e.File.FullName)
      End Sub
   End Class
End Namespace

' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports Microsoft.VisualBasic
Imports System
Imports System.IO
Imports System.Data

Imports Leadtools.Dicom
Imports Leadtools.DicomDemos

Namespace Leadtools.Demos.Database
   Public Enum InsertReturn
      Exists
      [Error]
      Success
   End Enum

   ''' <summary>
   ''' Summary description for DicomDB.
   ''' </summary>
   Public Class DicomDB : Inherits DBBase
      ' If we have to create database this will signal us to load
      '  default images.
      Public NeedImport As Boolean = False
      Public ImageDir As String = ""
      Private adoDatasetLock As Object = New Object()

      Protected WithEvents ImageTable As DataTable

      Public Sub New(ByVal dbFileName As String)
         Me.dbFileName = dbFileName

         If (Not LoadDatabase()) Then
            CreateDatabase()
            NeedImport = True
         End If
         SyncLock adoDatasetLock
            If Not ds.Tables("Images") Is Nothing Then
               ImageTable = ds.Tables("Images")
            End If
         End SyncLock
      End Sub

      Private Function CreateDatabase() As Boolean
         Dim created As Boolean = True
         SyncLock adoDatasetLock
            Try
               Dim table As DataTable
               Dim Patients_PatientID, Studies_PatientID As DataColumn
               Dim Studies_InstUID, Series_InstUID As DataColumn
               Dim Series_ID, Images_ID As DataColumn
               Dim key As DataColumn() = New DataColumn(0) {}

               table = ds.Tables.Add("Patients")
               Patients_PatientID = table.Columns.Add("PatientID", GetType(String))
               table.Columns.Add("PatientName", GetType(String))
               table.Columns.Add("PatientBirthDate", GetType(DateTime))
               table.Columns.Add("PatientBirthTime", GetType(DateTime))
               table.Columns.Add("PatientSex", GetType(String))
               table.Columns.Add("EthnicGroup", GetType(String))
               table.Columns.Add("PatientComments", GetType(String))

               key(0) = Patients_PatientID
               table.PrimaryKey = key

               table = ds.Tables.Add("Studies")
               Studies_InstUID = table.Columns.Add("StudyInstanceUID", GetType(String))
               table.Columns.Add("StudyDate", GetType(DateTime))
               table.Columns.Add("StudyTime", GetType(DateTime))
               table.Columns.Add("AccessionNumber", GetType(String))
               table.Columns.Add("StudyID", GetType(String))
               table.Columns.Add("PatientName", GetType(String))
               Studies_PatientID = table.Columns.Add("PatientID", GetType(String))
               table.Columns.Add("StudyDescription", GetType(String))
               table.Columns.Add("ReferringDrName", GetType(String))

               key(0) = Studies_InstUID
               table.PrimaryKey = key
               ds.Relations.Add("Studies", Patients_PatientID, Studies_PatientID)

               table = ds.Tables.Add("Series")
               Series_ID = table.Columns.Add("SeriesInstanceUID", GetType(String))
               Series_InstUID = table.Columns.Add("StudyInstanceUID", GetType(String))
               table.Columns.Add("Modality", GetType(String))
               table.Columns.Add("SeriesNumber", GetType(Integer))
               table.Columns.Add("PatientID", GetType(String))
               table.Columns.Add("SeriesDate", GetType(DateTime))

               key(0) = Series_ID
               table.PrimaryKey = key
               ds.Relations.Add("Series", Studies_InstUID, Series_InstUID)

               table = ds.Tables.Add("Images")
               table.Columns.Add("SOPInstanceUID", GetType(String))
               Images_ID = table.Columns.Add("SeriesInstanceUID", GetType(String))
               table.Columns.Add("StudyInstanceUID", GetType(String))
               table.Columns.Add("InstanceNumber", GetType(Integer))
               table.Columns.Add("ReferencedFile", GetType(String))
               table.Columns.Add("PatientID", GetType(String))
               table.Columns.Add("SOPClassUID", GetType(String))
               table.Columns.Add("TransferSyntaxUID", GetType(String))

               ds.Relations.Add("Images", Series_ID, Images_ID)

               Save()
            Catch e As Exception
               created = False
            End Try
         End SyncLock

         Return created
      End Function

      ''' <summary>
      ''' Insert a dicom file into the database.
      ''' </summary>
      ''' <param name="filename"></param>
      ''' <returns></returns>
      Public Function Insert(ByVal filename As String) As InsertReturn
         Dim dcm As DicomDataSet
         Dim patientID, studyInstanceUID As String
         Dim seriesInstanceUID, sopInstanceUID As String
         Dim iret As InsertReturn = InsertReturn.Success

         dcm = New DicomDataSet()
         If dcm Is Nothing Then
            Return InsertReturn.Error
         End If

         Try
            Dim src As FileInfo = New FileInfo(filename)
            Dim dstDir As DirectoryInfo = New DirectoryInfo(ImageDir)

            If src.Directory.FullName <> dstDir.FullName Then
               filename = dstDir.FullName & src.Name
               src.CopyTo(filename)
            End If
            dcm.Load(filename, DicomDataSetLoadFlags.LoadAndClose)
         Catch de As Exception
            Return InsertReturn.Error
         End Try

         patientID = AddPatient(dcm, iret)
         If ((iret <> InsertReturn.Success) And (iret <> InsertReturn.Exists)) Then
            Return iret
         End If

         studyInstanceUID = AddStudy(dcm, patientID, iret)
         If ((iret <> InsertReturn.Success) And (iret <> InsertReturn.Exists)) Then
            Return iret
         End If
         seriesInstanceUID = AddSeries(dcm, studyInstanceUID, patientID, iret)

         If ((iret <> InsertReturn.Success) And (iret <> InsertReturn.Exists)) Then
            Return iret
         End If

         sopInstanceUID = AddImage(dcm, seriesInstanceUID, studyInstanceUID, patientID, filename, iret)

         If iret = InsertReturn.Success Then
            Save()
         End If
         Return iret
      End Function

      Public Function Insert(ByVal dcm As DicomDataSet, ByVal filename As String) As InsertReturn
         Dim patientID As String
         Dim studyInstanceUID As String
         Dim seriesInstanceUID As String
         Dim sopInstanceUID As String
         Dim ret As InsertReturn = InsertReturn.Success

         patientID = AddPatient(dcm, ret)
            If ret <> InsertReturn.Success And ret <> InsertReturn.Exists Then
                Return ret
            End If

         studyInstanceUID = AddStudy(dcm, patientID, ret)
         seriesInstanceUID = AddSeries(dcm, studyInstanceUID, patientID, ret)
         sopInstanceUID = AddImage(dcm, seriesInstanceUID, studyInstanceUID, patientID, filename, ret)

         If ret = InsertReturn.Success Then
            Save()
         End If
         Return ret
      End Function

      Private Function AddPatient(ByVal dcm As DicomDataSet, ByRef ret As InsertReturn) As String
         Dim patientID As String

         ret = InsertReturn.Success
         patientID = Utils.GetStringValue(dcm, DemoDicomTags.PatientID)
         If patientID.Length = 0 Then
            ret = InsertReturn.Error
            Return ""
         End If

         SyncLock adoDatasetLock
            If (Not RecordExists(ds.Tables("Patients"), "PatientID = '" & patientID & "'")) Then
               Dim dr As DataRow

               dr = ds.Tables("Patients").NewRow()
               If Not dr Is Nothing Then
                  dr("PatientID") = patientID
                  dr("PatientName") = Utils.GetStringValue(dcm, DemoDicomTags.PatientName)
                  dr("PatientSex") = Utils.GetStringValue(dcm, DemoDicomTags.PatientSex)
                  dr("EthnicGroup") = Utils.GetStringValue(dcm, DemoDicomTags.EthnicGroup)
                  dr("PatientComments") = Utils.GetStringValue(dcm, DemoDicomTags.PatientComments)

                  Try
                     dr("PatientBirthDate") = DateTime.Parse(Utils.GetStringValue(dcm, DemoDicomTags.PatientBirthDate))
                     dr("PatientBirthTime") = DateTime.Parse(Utils.GetStringValue(dcm, DemoDicomTags.PatientBirthTime))
                  Catch
                  End Try

                  ds.Tables("Patients").Rows.Add(dr)
               End If
            Else
               ret = InsertReturn.Exists
            End If
         End SyncLock
         Return patientID
      End Function

      Private Function AddStudy(ByVal dcm As DicomDataSet, ByVal patientID As String, ByRef ret As InsertReturn) As String
         Dim studyInstanceUID As String
         Dim filter As String

         ret = InsertReturn.Success
         studyInstanceUID = Utils.GetStringValue(dcm, DemoDicomTags.StudyInstanceUID)
         If studyInstanceUID.Length = 0 Then
            ret = InsertReturn.Error
            Return ""
         End If

         SyncLock adoDatasetLock
            filter = "StudyInstanceUID = '" & studyInstanceUID & "' AND PatientID = '" & patientID & "'"
            If (Not RecordExists(ds.Tables("Studies"), filter)) Then
               Dim dr As DataRow

               dr = ds.Tables("Studies").NewRow()
               If Not dr Is Nothing Then
                  dr("StudyInstanceUID") = studyInstanceUID
                  dr("StudyID") = Utils.GetStringValue(dcm, DemoDicomTags.StudyID)
                  dr("StudyDescription") = Utils.GetStringValue(dcm, DemoDicomTags.StudyDescription)
                  dr("AccessionNumber") = Utils.GetStringValue(dcm, DemoDicomTags.AccessionNumber)
                  dr("PatientID") = patientID
                  dr("PatientName") = Utils.GetStringValue(dcm, DemoDicomTags.PatientName)
                  dr("ReferringDrName") = Utils.GetStringValue(dcm, DemoDicomTags.ReferringPhysicianName)

                  Try
                     dr("StudyDate") = DateTime.Parse(Utils.GetStringValue(dcm, DemoDicomTags.StudyDate))
                     dr("StudyTime") = DateTime.Parse(Utils.GetStringValue(dcm, DemoDicomTags.StudyTime))
                  Catch
                  End Try

                  ds.Tables("Studies").Rows.Add(dr)
               End If
            Else
               ret = InsertReturn.Exists
            End If
         End SyncLock
         Return studyInstanceUID
      End Function

      Private Function AddSeries(ByVal dcm As DicomDataSet, ByVal studyInstanceUID As String, ByVal patientID As String, ByRef ret As InsertReturn) As String
         Dim seriesInstanceUID As String
         Dim filter As String

         ret = InsertReturn.Success
         seriesInstanceUID = Utils.GetStringValue(dcm, DemoDicomTags.SeriesInstanceUID)
         If seriesInstanceUID.Length = 0 Then
            ret = InsertReturn.Error
            Return ""
         End If

         filter = "StudyInstanceUID = '" & studyInstanceUID & "' AND SeriesInstanceUID = '" & seriesInstanceUID & "'"
         SyncLock adoDatasetLock
            If (Not RecordExists(ds.Tables("Series"), filter)) Then
               Dim dr As DataRow

               dr = ds.Tables("Series").NewRow()
               If Not dr Is Nothing Then
                  Dim temp As String

                  temp = Utils.GetStringValue(dcm, DemoDicomTags.SeriesNumber)

                  dr("SeriesInstanceUID") = seriesInstanceUID
                  dr("StudyInstanceUID") = studyInstanceUID
                  dr("Modality") = Utils.GetStringValue(dcm, DemoDicomTags.Modality)
                  dr("PatientID") = patientID

                  Try
                     dr("SeriesDate") = DateTime.Parse(Utils.GetStringValue(dcm, DemoDicomTags.SeriesDate))
                  Catch
                  End Try

                  Try
                     If temp.Length > 0 Then
                        dr("SeriesNumber") = Convert.ToInt32(temp)
                     End If
                  Catch
                  End Try

                  ds.Tables("Series").Rows.Add(dr)
               End If
            Else
               ret = InsertReturn.Exists
            End If
         End SyncLock

         Return seriesInstanceUID
      End Function

      Private Function AddImage(ByVal dcm As DicomDataSet, ByVal seriesInstanceUID As String, ByVal studyInstanceUID As String, ByVal patientID As String, ByVal filename As String, ByRef ret As InsertReturn) As String
         Dim sopInstanceUID As String
         Dim filter As String

         ret = InsertReturn.Success
         sopInstanceUID = Utils.GetStringValue(dcm, DemoDicomTags.SOPInstanceUID)
         If sopInstanceUID.Length = 0 Then
            ret = InsertReturn.Error
            Return ""
         End If

         filter = "StudyInstanceUID = '" & studyInstanceUID & "' AND SeriesInstanceUID = '" & seriesInstanceUID & "'"
         filter &= " AND SOPInstanceUID = '" & sopInstanceUID & "'"

         SyncLock adoDatasetLock
            If (Not RecordExists(ds.Tables("Images"), filter)) Then
               Dim dr As DataRow

               dr = ds.Tables("Images").NewRow()
               If Not dr Is Nothing Then
                  Dim temp As String

                  dr("SOPInstanceUID") = sopInstanceUID
                  dr("SeriesInstanceUID") = seriesInstanceUID
                  dr("StudyInstanceUID") = studyInstanceUID
                  dr("PatientID") = patientID
                  dr("ReferencedFile") = filename

                  temp = Utils.GetStringValue(dcm, DemoDicomTags.SOPClassUID)
                  If temp.Length = 0 Then
                     temp = Utils.GetStringValue(dcm, DemoDicomTags.MediaStorageSOPClassUID)
                     If temp.Length = 0 Then
                        temp = "1.1.1.1"
                     End If
                  End If
                  dr("SOPClassUID") = temp

                  temp = Utils.GetStringValue(dcm, DemoDicomTags.TransferSyntaxUID)
                  If temp.Length = 0 Then
                     temp = DicomUidType.ImplicitVRLittleEndian
                  End If
                  dr("TransferSyntaxUID") = temp

                  temp = Utils.GetStringValue(dcm, DemoDicomTags.InstanceNumber)
                  If temp.Length > 0 Then
                     dr("InstanceNumber") = Convert.ToInt32(temp)
                  End If

                  ds.Tables("Images").Rows.Add(dr)
               End If
            Else
               ret = InsertReturn.Exists
            End If
         End SyncLock
         Return sopInstanceUID
      End Function

      Private Function RecordExists(ByVal table As DataTable, ByVal filter As String) As Boolean
         Dim dv As DataView = New DataView(table)

         If Not dv Is Nothing Then
            dv.RowFilter = filter
            Return dv.Count > 0
         End If
         Return False
      End Function

      Public Function FindRecords(ByVal type As String, ByVal filter As String) As DataView
         Dim dv As DataView = New DataView(ds.Tables(type))
         SyncLock adoDatasetLock
            If Not dv Is Nothing Then
               dv.RowFilter = filter
            End If
         End SyncLock
         Return dv
      End Function

      Private Sub ImageTable_RowDeleting1(ByVal sender As Object, ByVal e As System.Data.DataRowChangeEventArgs) Handles ImageTable.RowDeleting
         Dim file As String = e.Row("ReferencedFile").ToString()

         Try
            System.IO.File.Delete(file)
         Catch
         End Try
      End Sub

      Public Sub Delete(ByVal table As String, ByVal field As String, ByVal key As String)
         SyncLock adoDatasetLock
            Dim dv As DataView = New DataView(ds.Tables(table))

            If Not dv Is Nothing Then
               Dim dr As DataRow

               dv.RowFilter = field & " = '" & key & "'"
               dr = dv(0).Row
               If Not dr Is Nothing Then
                  ds.Tables(table).Rows.Remove(dr)
               End If
            End If
         End SyncLock
      End Sub

   End Class
End Namespace

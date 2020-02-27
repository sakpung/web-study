' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Drawing
Imports System.Data
Imports System.Linq
Imports System.Text
Imports System.Windows.Forms
Imports System.Threading
Imports Leadtools.Dicom
Imports Leadtools.Dicom.Scp.Command
Imports Leadtools.Medical.DataAccessLayer
Imports Leadtools.Medical.Worklist.DataAccessLayer
Imports VBCustomizingWorklistDAL.DataTypes
Imports VBCustomizingWorklistDAL.MyClientSession
Imports Leadtools.Demos

Namespace VBCustomizingWorklistDAL.UI
   Partial Public Class DICOMQuery : Inherits UserControl
      Private _source As List(Of DatabaseDicomTags)
      Private _additionalDisplay As List(Of DatabaseDicomTags)
      Private _iodPath As String
      Public Sub New()
         InitializeComponent()
      End Sub

      Public Sub SetSource(ByVal source As List(Of DatabaseDicomTags), ByVal iodPath As String)
         _source = source
         _additionalDisplay = New List(Of DatabaseDicomTags)()
         _iodPath = iodPath

         _additionalDisplay.Add(New DatabaseDicomTags("", "Patient Name", DicomTag.PatientName))
         _additionalDisplay.Add(New DatabaseDicomTags("", "Admission ID", DicomTag.AdmissionID))
         _additionalDisplay.Add(New DatabaseDicomTags("", "Accesion Number", DicomTag.AccessionNumber))
         _additionalDisplay.Add(New DatabaseDicomTags("", "Modality", DicomTag.Modality))
         _additionalDisplay.Add(New DatabaseDicomTags("", "Requested Procedure ID", DicomTag.RequestedProcedureID))
         _additionalDisplay.Add(New DatabaseDicomTags("", "Scheduled Station AE Title", DicomTag.ScheduledStationAETitle))
         _additionalDisplay.Add(New DatabaseDicomTags("", "Scheduled Procedure Step Description", DicomTag.ScheduledProcedureStepDescription))

         AddHandler QueryButton.Click, AddressOf QueryButton_Click
      End Sub


      Private Sub QueryButton_Click(ByVal sender As Object, ByVal e As EventArgs)
         Try
            Dim clientSession As DemoClientSession = New DemoClientSession()
            Dim requestDS As DicomDataSet


            requestDS = GetQueryDataSet()
            Dim command As MWLCFindCommand = New MWLCFindCommand(clientSession, requestDS, DataAccessServices.GetDataAccessService(Of IWorklistDataAccessAgent)())
            Dim resetEvent As AutoResetEvent = New AutoResetEvent(False)
            command.MWLConfiguration.ModalityWorklistIODPath = _iodPath

            command.Execute(resetEvent)

            resetEvent.WaitOne()

            InitializeWorklistView()

            If clientSession.Status = DicomCommandStatusType.Success Then
               For Each response As DicomDataSet In clientSession.ResponseDS
                  FillWorklistItem(response)
               Next response
            Else
               Messager.ShowError(Me, "Failed to Query." + Environment.NewLine + clientSession.StatusMessage)
            End If
         Catch exception As Exception
            Messager.ShowError(Me, exception)
         End Try
      End Sub

      Private Sub FillWorklistItem(ByVal response As DicomDataSet)
         Try
            Dim item As ListViewItem = Nothing
            Dim element As DicomElement = Nothing


            For Each dbTag As DatabaseDicomTags In _additionalDisplay
               element = response.FindFirstElement(Nothing, dbTag.DicomTag, False)

               If item Is Nothing Then
                  item = New ListViewItem()

                  item.UseItemStyleForSubItems = False

                  If Not Nothing Is element Then
                     item.Text = response.GetConvertValue(element)
                  End If
               Else
                  Dim subItemValue As String = String.Empty

                  If Not Nothing Is element Then
                     subItemValue = response.GetConvertValue(element)
                  End If

                  item.SubItems.Add(subItemValue)
               End If
            Next dbTag


            If IsDatabaseUpdated() Then
               For Each dbTag As DatabaseDicomTags In _source
                  element = response.FindFirstElement(Nothing, dbTag.DicomTag, False)

                  Dim subItemValue As String = String.Empty

                  If Not Nothing Is element Then
                     subItemValue = response.GetConvertValue(element)
                  End If

                  Dim subItem As ListViewItem.ListViewSubItem = New ListViewItem.ListViewSubItem(item, subItemValue, Color.Red, Color.Blue, Font)
                  item.SubItems.Add(subItem)
               Next dbTag
            End If

            WorklistItemsListView.Items.Add(item)
         Catch exception As Exception
            Messager.ShowError(Me, exception)
         End Try
      End Sub

      Private Sub InitializeWorklistView()
         WorklistItemsListView.Clear()

         For Each dbTag As DatabaseDicomTags In _additionalDisplay
            WorklistItemsListView.Columns.Add(dbTag.ColumnName)
         Next dbTag

         If IsDatabaseUpdated() Then
            For Each dbTag As DatabaseDicomTags In _source
               WorklistItemsListView.Columns.Add(dbTag.ColumnName)
            Next dbTag
         End If
      End Sub

      Private Function IsDatabaseUpdated() As Boolean
         Dim form1 As Form1 = TryCast(Me.Parent, Form1)
         Dim ret As Boolean = (Not form1 Is Nothing AndAlso form1.DatabaseLayer.IsDatabaseUpdated())
         Return ret
      End Function

      Private Function GetQueryDataSet() As DicomDataSet
         Try
            Dim requestDataset As DicomDataSet


            requestDataset = New DicomDataSet()

            requestDataset.Initialize(DicomClassType.ModalityWorklist, DicomDataSetInitializeFlags.None)

            If IsDatabaseUpdated() Then
               'make sure we request all the new tags
               For Each dbTag As DatabaseDicomTags In _source
                  requestDataset.InsertElementAndSetValue(dbTag.DicomTag, String.Empty)
               Next dbTag
            End If

            Return requestDataset
         Catch exception As Exception
            System.Diagnostics.Debug.Assert(False, exception.Message)

            Throw
         End Try
      End Function
   End Class
End Namespace

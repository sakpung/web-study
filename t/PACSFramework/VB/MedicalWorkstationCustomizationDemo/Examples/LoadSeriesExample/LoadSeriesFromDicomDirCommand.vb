' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Windows.Forms
Imports Leadtools.Medical.Workstation.Commands
Imports Leadtools.Medical.Workstation
Imports Leadtools.Medical.Workstation.Client.Local
Imports Leadtools.Dicom
Imports Leadtools.Dicom.Scu.Common

Namespace Leadtools.Demos.Workstation.Customized
   Class LoadSeriesFromDicomDirCommand : Inherits WorkstationCommand
      Public Sub New(ByVal featureId As String, ByVal container As WorkstationContainer)
         MyBase.New(featureId, container)

      End Sub

      Protected Overrides Sub DoExecute()
         Dim dicomDirFile As String


         dicomDirFile = GetDicomDir()

         If (Not String.IsNullOrEmpty(dicomDirFile)) Then
            Dim serieses As List(Of SeriesInformation)
            Dim argument As LoadSeriesFromDicomDirCommandArgument

            serieses = GetSeriesForLoading(dicomDirFile)


            For Each series As SeriesInformation In serieses
               If Container.ArgumentsService.Exists(Of LoadSeriesFromDicomDirCommandArgument)() Then
                  argument = Container.ArgumentsService.PopArgument(Of LoadSeriesFromDicomDirCommandArgument)()

                  argument.DicomDirFile = dicomDirFile
               Else
                  argument = New LoadSeriesFromDicomDirCommandArgument(dicomDirFile)
               End If

               Container.ArgumentsService.PushArgument(Of LoadSeriesFromDicomDirCommandArgument)(argument)

               Container.State.ActiveWorkstation.LoadSeries(series)
            Next series
         End If
      End Sub

      Protected Overrides Function DoCanExecute() As Boolean
         Return True
      End Function

      Private Function GetSeriesForLoading(ByVal dicomDirFile As String) As List(Of SeriesInformation)
         Dim seriesInfo As List(Of SeriesInformation)
         Dim client As DicomDirQueryClient
         Dim seriesDataSets As DicomDataSet()


         seriesInfo = New List(Of SeriesInformation)()
         client = New DicomDirQueryClient(dicomDirFile)
         seriesDataSets = client.FindSeries(New FindQuery())


         For Each sereisDs As DicomDataSet In seriesDataSets
            Dim series As SeriesInformation


            series = New SeriesInformation(sereisDs.GetValue(Of String)(DicomTag.PatientID, String.Empty), sereisDs.GetValue(Of String)(DicomTag.StudyInstanceUID, String.Empty), sereisDs.GetValue(Of String)(DicomTag.SeriesInstanceUID, String.Empty), sereisDs.GetValue(Of String)(DicomTag.SeriesDescription, String.Empty))

            seriesInfo.Add(series)

            sereisDs.Dispose()
         Next sereisDs

         Return seriesInfo
      End Function

      Private Function GetDicomDir() As String
         Dim openFileDialog As OpenFileDialog = New OpenFileDialog()

         openFileDialog.FileName = "DICOMDIR"

         If openFileDialog.ShowDialog() = DialogResult.OK Then
            If openFileDialog.SafeFileName <> "DICOMDIR" Then
               MessageBox.Show("Invalid DICOMDIR file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

               Return Nothing
            Else
               Return openFileDialog.FileName
            End If
         End If

         Return Nothing
      End Function
   End Class

   Public Class LoadSeriesFromDicomDirCommandArgument
      Public Sub New(ByVal dicomDirFile As String)
         Me.DicomDirFile = dicomDirFile
      End Sub

      Public DicomDirFile As String
   End Class
End Namespace

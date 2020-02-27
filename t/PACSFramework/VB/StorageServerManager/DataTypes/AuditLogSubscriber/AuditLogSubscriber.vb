' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports Leadtools.Medical.Winforms
Imports Leadtools.Logging
Imports Leadtools.Logging.Medical
Imports Leadtools.Demos.StorageServer.UI.AdministrativeSettings.Users
Imports Leadtools.Medical.Winforms.EventBrokerArgs

Namespace Leadtools.Demos.StorageServer.DataTypes
   Friend Class AuditLogSubscriber
      Public Sub Start()
         EventBroker.Instance.Subscribe(Of DicomFileDeletedEventArgs)(AddressOf OnDicomFileDeleted)
         EventBroker.Instance.Subscribe(Of ImageFileDeletedEventArgs)(AddressOf OnImageFileDeleted)
         EventBroker.Instance.Subscribe(Of DicomFileImportedEventArgs)(AddressOf OnDicomFileImported)
         EventBroker.Instance.Subscribe(Of DeletingDicomFilesEventArgs)(AddressOf OnDeletingDicomFile)
         EventBroker.Instance.Subscribe(Of EmptyDatabaseEventArgs)(AddressOf OnEmptyDatabase)
         EventBroker.Instance.Subscribe(Of CleanForwardedDatasetsEventArgs)(AddressOf OnCleanForwardedDatasets)
         EventBroker.Instance.Subscribe(Of MultiDicomImportEventArgs)(AddressOf OnMultiDicomImport)
      End Sub

      Public Sub [Stop]()
         EventBroker.Instance.Unsubscribe(Of DicomFileDeletedEventArgs)(AddressOf OnDicomFileDeleted)
         EventBroker.Instance.Unsubscribe(Of ImageFileDeletedEventArgs)(AddressOf OnImageFileDeleted)
         EventBroker.Instance.Unsubscribe(Of DicomFileImportedEventArgs)(AddressOf OnDicomFileImported)
         EventBroker.Instance.Unsubscribe(Of DeletingDicomFilesEventArgs)(AddressOf OnDeletingDicomFile)
         EventBroker.Instance.Unsubscribe(Of EmptyDatabaseEventArgs)(AddressOf OnEmptyDatabase)
         EventBroker.Instance.Unsubscribe(Of CleanForwardedDatasetsEventArgs)(AddressOf OnCleanForwardedDatasets)
         EventBroker.Instance.Unsubscribe(Of MultiDicomImportEventArgs)(AddressOf OnMultiDicomImport)
      End Sub

      Private Sub OnDicomFileDeleted(ByVal sender As Object, ByVal args As DicomFileDeletedEventArgs)
         Log(String.Format(AuditMessages.DicomFileDeleted.Message, args.FilePath))
      End Sub

      Private Sub OnImageFileDeleted(ByVal sender As Object, ByVal args As ImageFileDeletedEventArgs)
         Log(String.Format(AuditMessages.ImageFileDeleted.Message, args.FilePath))
      End Sub

      Private Sub OnDicomFileImported(ByVal sender As Object, ByVal args As DicomFileImportedEventArgs)
         If args.Status = Dicom.DicomCommandStatusType.Success Then
            Log(String.Format(AuditMessages.DicomFileImported.Message, args.FilePath))
         Else
            Log(String.Format(AuditMessages.DicomFileImportedFailure.Message, args.FilePath, args.Status, args.Description), LogType.Error)
         End If
      End Sub

      Private Sub OnDeletingDicomFile(ByVal sender As Object, ByVal args As DeletingDicomFilesEventArgs)
         Log(String.Format(AuditMessages.DeletingDicomFile.Message, UserManager.User.Name, args.Reason))
      End Sub

      Private Sub OnEmptyDatabase(ByVal sender As Object, ByVal args As EmptyDatabaseEventArgs)
         Log(String.Format(AuditMessages.EmptyDatabase.Message, UserManager.User.Name, args.Reason))
      End Sub

      Private Sub OnCleanForwardedDatasets(ByVal sender As Object, ByVal args As CleanForwardedDatasetsEventArgs)
         Log(String.Format(AuditMessages.CleanForwardedDatasets.Message, UserManager.User.Name, args.CleanCount, args.Reason))
      End Sub

      Private Sub OnMultiDicomImport(ByVal sender As Object, ByVal args As MultiDicomImportEventArgs)
         Dim finalState As String = "Completed"
         If args.Cancelled Then
            finalState = "Cancelled"
         End If
         If args.State = MultiDicomImportState.Starting Then
            Log(String.Format(AuditMessages.MultiDicomImportStarting.Message, args.TotalFileCount))
         Else
            If args.TotalFailed = 0 Then
               Log(String.Format(AuditMessages.MultiDicomImportEndingSuccess.Message, finalState, args.TotalFileCount, args.TotalStored))
            Else
               Log(String.Format(AuditMessages.MultiDicomImportEndingPartialSuccess.Message, finalState, args.TotalFileCount, args.TotalStored, args.TotalFailed))
            End If
         End If
      End Sub

      Private Shared Sub Log(ByVal message As String)
         Dim logEntry As New DicomLogEntry()

         If Nothing IsNot UserManager.User Then
            logEntry.ClientAETitle = UserManager.User.Name
         End If

         logEntry.LogType = LogType.Audit
         logEntry.Description = message

         Logger.Global.Log(logEntry)
      End Sub

      Private Shared Sub Log(ByVal message As String, ByVal logType As LogType)
         Dim logEntry As New DicomLogEntry()

         If Nothing IsNot UserManager.User Then
            logEntry.ClientAETitle = UserManager.User.Name
         End If

         logEntry.LogType = logType
         logEntry.Description = message

         Logger.Global.Log(logEntry)
      End Sub
   End Class
End Namespace

' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports Leadtools.Logging
Imports Leadtools.Logging.Medical
Imports System.Collections.Specialized

Namespace Leadtools.Demos.StorageServer.DataTypes
   Friend MustInherit Class LocalAuditLogQueue
      Private Shared _audits As OrderedDictionary = New OrderedDictionary()
      Private Shared _lock As Object = New Object()

      Public Shared Sub AddAuditMessage(ByVal id As Integer, ByVal message As String)
         SyncLock _lock
            If _audits.Contains(id) Then
               _audits.Remove(id)
            End If

            _audits.Add(id, message)
         End SyncLock
      End Sub

      Public Shared Sub FlushLogs(ByVal logger As Logger, ByVal user As String)
         SyncLock _lock
            Do While _audits.Count <> 0
               Dim logEntry As DicomLogEntry = New DicomLogEntry()

               logEntry.ClientAETitle = user
               logEntry.Description = _audits(0).ToString()
               logEntry.LogType = LogType.Audit

               logger.Log(logEntry)

               _audits.RemoveAt(0)
            Loop
         End SyncLock
      End Sub

      Public Shared Sub Clear()
         SyncLock _lock
            _audits.Clear()
         End SyncLock
      End Sub
   End Class
End Namespace

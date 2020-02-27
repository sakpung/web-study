' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text

Namespace Leadtools.Demos.StorageServer.DataTypes
   Friend MustInherit Class AuditMessages
      Public Shared ReadOnly UserLogIn As Entry = New Entry(0, "User Log in: {0}")
      Public Shared ReadOnly UserLogOff As Entry = New Entry(1, "User Log Off: {0}")
      Public Shared ReadOnly ServerServiceCreated As Entry = New Entry(2, "Service Created: Name={0}, AE Title={1}, IP Address={2}, Port={3}")
      Public Shared ReadOnly ServerServiceDeleted As Entry = New Entry(3, "Service Deleted: Name={0}")
      Public Shared ReadOnly AeTitleChanged As Entry = New Entry(4, "Server AE Title Changed: {0}")
      Public Shared ReadOnly IpAddressChanged As Entry = New Entry(5, "Server IP Address Changed: {0}")
      Public Shared ReadOnly PortChanged As Entry = New Entry(6, "Server Port Changed: {0}")
      Public Shared ReadOnly ImplementationClassUIDChanged As Entry = New Entry(7, "Server Implementation Class UID Changed: {0}")
      Public Shared ReadOnly ImplementationVersionNameChanged As Entry = New Entry(8, "Server Implementation Version Name Changed: {0}")
      Public Shared ReadOnly ServiceStartModeChanged As Entry = New Entry(9, "Service Start Mode Changed: {0}")
      Public Shared ReadOnly DicomFileDeleted As Entry = New Entry(10, "DICOM File Deleted: {0}")
      Public Shared ReadOnly ImageFileDeleted As Entry = New Entry(11, "Image File Deleted: {0}")
      Public Shared ReadOnly DicomFileImported As Entry = New Entry(12, "DICOM File Imported: {0}")
      Public Shared ReadOnly NewUserAdded As Entry = New Entry(13, "New User Added: {0}")
      Public Shared ReadOnly UserRemoved As Entry = New Entry(14, "User Removed: {0}")
      Public Shared ReadOnly UserPasswordChanged As Entry = New Entry(15, "User Password Changed: {0}")
      Public Shared ReadOnly PermissionAdded As Entry = New Entry(16, "User Permission Granted. User: {0}, Permission: {1}")
      Public Shared ReadOnly PermissionRemoved As Entry = New Entry(17, "User Permission Removed. User: {0}, Permission: {1}")
      Public Shared ReadOnly DeletingDicomFile As Entry = New Entry(18, "User {0} requested to delete DICOM files, Reason: {1}")
      Public Shared ReadOnly EmptyDatabase As Entry = New Entry(19, "User {0} requested to delete all DICOM files, Reason: {1}")
   End Class

   Public Structure Entry
      Public Sub New(ByVal key_Renamed As Integer, ByVal message_Renamed As String)
         _key = key_Renamed
         _message = message_Renamed
      End Sub

      Public ReadOnly Property Key() As Integer
         Get
            Return _key
         End Get
      End Property
      Public ReadOnly Property Message() As String
         Get
            Return _message
         End Get
      End Property

      Private _key As Integer
      Private _message As String
   End Structure
End Namespace

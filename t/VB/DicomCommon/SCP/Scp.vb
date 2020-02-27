' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports Microsoft.VisualBasic
Imports System
Imports System.Threading
Imports System.Collections.Specialized

Imports Leadtools
Imports Leadtools.Dicom

Namespace Leadtools.DicomDemos.Scp
   ''' <summary>
   ''' Summary description for Scp.
   ''' </summary>
   Public Class Scp : Inherits Base
      Private _CalledAE As String
      Private _CallingAE As String
      Private _UidExclusionList As StringCollection = New StringCollection()

      Public ReadOnly Property UidExclusionList() As StringCollection
         Get
            Return _UidExclusionList
         End Get
      End Property

      Public Property CalledAE() As String
         Get
            Return _CalledAE
         End Get
         Set(ByVal value As String)
            _CalledAE = value
         End Set
      End Property

      Public Property CallingAE() As String
         Get
            Return _CallingAE
         End Get
         Set(ByVal value As String)
            _CallingAE = value
         End Set
      End Property

      Public Sub New()
         '
         ' TODO: Add constructor logic here
         '
      End Sub

      Public Overloads Function Listen(ByVal port As Integer, ByVal peers As Integer) As DicomExceptionCode
         Dim ret As DicomExceptionCode = DicomExceptionCode.Success

         Try
            MyBase.Listen("", port, peers)
         Catch de As DicomException
            ret = de.Code
         End Try

            Return ret
        End Function

#If LEADTOOLS_V17_OR_LATER Then
        Public Overloads Function Listen(ByVal port As Integer, ByVal peers As Integer, ByVal ipType As DicomNetIpTypeFlags) As DicomExceptionCode
            Dim ret As DicomExceptionCode = DicomExceptionCode.Success

            Try
                Listen("*", port, peers, ipType)
            Catch de As DicomException
                ret = de.Code
            End Try

            Return ret
        End Function
#End If

      Public Overrides Sub Init()
         MyBase.Init()
      End Sub

      Public Function IsSupported(ByVal uid As String) As Boolean
         If UidExclusionList.IndexOf(uid) <> -1 Then
            Return False
         End If

         Return (Not DicomUidTable.Instance.Find(uid) Is Nothing)
      End Function

      Public Overridable Function IsConnectionValid(ByVal peerAddress As String, ByRef reject As DicomAssociateRejectReasonType) As Boolean
         Return True
      End Function
   End Class
End Namespace

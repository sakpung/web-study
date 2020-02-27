' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports Leadtools.Dicom.Scu
Imports Leadtools.Dicom.Scu.Queries
Imports System.Threading
Imports System.Windows.Forms
Imports Leadtools.Dicom.Common.Extensions
Imports Leadtools.Dicom

Namespace DicomDemo.Utils
   Public Class DicomUtils
      Private Shared _patient As Patient
      Private Shared _owner As Control
      Private Shared _find As QueryRetrieveScu
      Private Shared _scp As DicomScp
      Private Shared _pid As String

      Private Sub New()
         _patient = Nothing
      End Sub

      Private Shared Function CopyPatient(ByVal pSrc As Patient) As Patient
         _patient = pSrc
         Return _patient
      End Function
      Private Shared Sub GetPatient()
         Dim query As PatientRootQueryPatient = New PatientRootQueryPatient()
         query.PatientQuery.PatientId = _pid
         Try
            _find.Find(Of PatientRootQueryPatient, Patient)(_scp, query, Function(p As Patient, ds As DicomDataSet) CopyPatient(p))
         Catch e As Exception
            ApplicationUtils.ShowException(_owner, e)
         End Try
      End Sub
      Public Shared Function FindPatient(ByVal owner As Control, ByVal find As QueryRetrieveScu, ByVal scp As DicomScp, ByVal pid As String) As Patient
         Dim query As New PatientRootQueryPatient()
         Dim progress As New ProgressDialog()
         _patient = Nothing

         query.PatientQuery.PatientId = pid
         _owner = owner
         _find = find
         _scp = scp
         _pid = pid

         Try
            Dim thrd As Thread = New Thread(AddressOf GetPatient)

            progress.ActionThread = thrd
            progress.Title = "Searching For Patient"
            progress.ProgressInfo = "Looking for patient to merge with."
            progress.ShowDialog(owner)

         Catch e As Exception
            ApplicationUtils.ShowException(owner, e)
         End Try

         Return _patient
      End Function
   End Class

   Public Class PatientUpdaterSeries : Inherits Series
      <Element(DicomTag.SeriesTime)> _
    Public Property Time() As System.Nullable(Of DateTime)
         Get
            Return m_Time
         End Get
         Set(ByVal value As System.Nullable(Of DateTime))
            m_Time = value
         End Set
      End Property
      Private m_Time As System.Nullable(Of DateTime)

      Friend Class NoFlashListView : Inherits ListView
         Public Sub New()
            'Activate double buffering
            SetStyle(ControlStyles.OptimizedDoubleBuffer Or ControlStyles.AllPaintingInWmPaint, True)

            'Enable the OnNotifyMessage event so we get a chance to filter out 
            ' Windows messages before they get to the form's WndProc
            SetStyle(ControlStyles.EnableNotifyMessage, True)
         End Sub

         Protected Overrides Sub OnNotifyMessage(ByVal m As Message)
            'Filter out the WM_ERASEBKGND message
            If m.Msg <> &H14 Then
               MyBase.OnNotifyMessage(m)
            End If
         End Sub
      End Class

   End Class
End Namespace

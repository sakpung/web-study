' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System.Collections.Generic
Imports System.Text
Imports System.Runtime.InteropServices
Imports System

Namespace DicomVideoCaptureDemo.UI
   Class WinAPI
      <StructLayout(LayoutKind.Sequential)> _
      Public Class SystemTime
         Public Year As UShort
         Public Month As UShort
         Public DayOfWeek As UShort
         Public Day As UShort
         Public Hour As UShort
         Public Minute As UShort
         Public Second As UShort
         Public Milliseconds As UShort
      End Class

      <DllImport("kernel32.dll")> _
      Public Shared Sub GetSystemTime(<[In](), Out()> ByVal lpSystemTime As SystemTime)
      End Sub

      <DllImport("kernel32.dll", EntryPoint:="SystemTimeToFileTime", SetLastError:=True)> _
      Public Shared Function SystemTimeToFileTime(<[In]()> ByVal lpSystemTime As SystemTime, ByRef lpFileTime As FILETIME) As Boolean
      End Function

      <DllImport("kernel32.dll")> _
      Public Shared Function GetTickCount() As UInteger
      End Function

      Public Shared Function LOWORD(ByVal l As UInteger) As UShort
         Return CUShort(l And &HFFFF)
      End Function

      Public Shared Function HIWORD(ByVal l As UInteger) As UShort
         Return CUShort((l >> 16) And &HFFFF)
      End Function

      Public Shared Function GenerateDicomUniqueIdentifier() As String
         Dim systemTime As New SystemTime()
         Dim fileTime As New FILETIME()
         Dim Tick As UInteger
         Dim HighWord As UInteger
         Dim rand As New Random()
         GetSystemTime(systemTime)
         SystemTimeToFileTime(systemTime, fileTime)
         Tick = GetTickCount()
         HighWord = CUInt(CUInt(fileTime.dwHighDateTime) + &H146BF4)

         Return String.Format("1.2.840.114257.1.1{0:D010}{1:D05}{2:D05}{3:D05}{4:D05}{5:D05}{6:D05}", fileTime.dwLowDateTime, LOWORD(HighWord), HIWORD(CUInt(HighWord Or &H10000000)), LOWORD(CUInt(rand.[Next]())), HIWORD(Tick), _
          LOWORD(Tick), LOWORD(CUInt(rand.[Next]())))
      End Function
   End Class
End Namespace

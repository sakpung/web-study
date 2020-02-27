' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Windows.Forms

Namespace DicomAnonymizer.UI.Controls
   Public Class TagListView : Inherits ListView
      Public Sub New()
         If (Not DesignMode) Then
            'Activate double buffering
            SetStyle(ControlStyles.OptimizedDoubleBuffer Or ControlStyles.AllPaintingInWmPaint, True)

            'Enable the OnNotifyMessage event so we get a chance to filter out 
            ' Windows messages before they get to the form's WndProc
            SetStyle(ControlStyles.EnableNotifyMessage, True)
         End If
      End Sub

      Protected Overrides Sub OnNotifyMessage(ByVal m As Message)
         'Filter out the WM_ERASEBKGND message
         If m.Msg <> &H14 Then
            MyBase.OnNotifyMessage(m)
         End If
      End Sub
   End Class
End Namespace

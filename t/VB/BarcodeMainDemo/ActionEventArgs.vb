' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System
Imports System.Collections.Generic
Imports System.Text

''' <summary>
''' Arguments for the Action event used in the viewer and pages control
''' </summary>
Public Class ActionEventArgs : Inherits EventArgs
   Private _action As String ' String identifying the action
   Private _data As Object ' The data for this action

   Private Sub New()
      ' No default ctor
   End Sub

   Public Sub New(ByVal action_Renamed As String, ByVal data_Renamed As Object)
      _action = action_Renamed
      _data = data_Renamed
   End Sub

   Public ReadOnly Property Action() As String
      Get
         Return _action
      End Get
   End Property

   Public ReadOnly Property Data() As Object
      Get
         Return _data
      End Get
   End Property
End Class

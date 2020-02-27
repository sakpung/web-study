' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System
Imports System.Threading
Imports System.Windows.Forms
Imports System.Diagnostics

Friend Class BusyOperation(Of T)
   Public Name As String
   Public Begin As Action
   Public InThread As Func(Of T)
   Public [End] As Action
   Public ThenInvoke As Action(Of T)
   Public [Error] As Action(Of Exception)

   Private Sub New()
   End Sub

   Public Sub New(ByVal name_Renamed As String)
      Me.Name = name_Renamed
   End Sub

   Public Sub Run(invoker As Control)
      If Me.Begin IsNot Nothing Then
         Debug.WriteLine("Begin busy operation " & Convert.ToString(Me.Name))
         Me.Begin()
      End If

      ThreadPool.QueueUserWorkItem(Sub(state As Object)
                                      Dim result As T = Nothing
                                      Dim doInvoke As Boolean = False

                                      Try
                                         Debug.WriteLine("In thread busy operation " & Convert.ToString(Me.Name))
                                         result = Me.InThread()
                                         doInvoke = True
                                      Catch ex As Exception
                                         Debug.WriteLine("Error busy operation " & Convert.ToString(Me.Name))
                                         Me.[Error](ex)
                                      End Try

                                      If Me.[End] IsNot Nothing Then
                                         Debug.WriteLine("End busy operation " & Convert.ToString(Me.Name))
                                         Me.[End]()
                                      End If

                                      If doInvoke AndAlso invoker IsNot Nothing AndAlso Me.ThenInvoke IsNot Nothing Then
                                         Debug.WriteLine("Then invoke busy operation " & Convert.ToString(Me.Name))
                                         invoker.BeginInvoke(CType(Sub() Me.ThenInvoke(result), MethodInvoker))
                                      End If

                                   End Sub)
   End Sub
End Class

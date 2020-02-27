' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System.Windows.Forms
Imports System

Friend NotInheritable Class Helper
   Private Sub New()
   End Sub
   Public Shared Sub ShowError(owner As Form, [error] As Exception)
      If owner IsNot Nothing AndAlso owner.InvokeRequired Then
         owner.BeginInvoke(CType(Sub() Messager.ShowError(owner, [error]), MethodInvoker))
      Else
         Messager.ShowError(owner, [error])
      End If
   End Sub

   Public Shared Sub ShowError(owner As Form, message As String)
      If owner IsNot Nothing AndAlso owner.InvokeRequired Then
         owner.BeginInvoke(CType(Sub() Messager.ShowError(owner, message), MethodInvoker))
      Else
         Messager.ShowError(owner, message)
      End If
   End Sub

   Public Shared Sub ShowInformation(owner As Form, message As String)
      If owner IsNot Nothing AndAlso owner.InvokeRequired Then
         owner.BeginInvoke(CType(Sub() Messager.ShowInformation(owner, message), MethodInvoker))
      Else
         Messager.ShowInformation(owner, message)
      End If
   End Sub

   Public Shared Sub ShowWarning(owner As Form, message As String)
      If owner IsNot Nothing AndAlso owner.InvokeRequired Then
         owner.BeginInvoke(CType(Sub() Messager.ShowWarning(owner, message), MethodInvoker))
      Else
         Messager.ShowWarning(owner, message)
      End If
   End Sub

   Public Shared Function AddTextNote(message As String, noPages As Boolean) As String
      Return String.Format("{1}{0}{0}Note that 'Auto Get Text Mode' is off and {2}.{0}Either turn on 'Auto Get Text' from the 'Preferences' menu or get the text using the 'Page' menu.", Environment.NewLine, message, If(noPages, "none of the pages have their text parsed", "one or more pages do not have their text parsed"))
   End Function
End Class

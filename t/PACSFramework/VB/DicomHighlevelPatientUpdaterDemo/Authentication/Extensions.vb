' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Security

Namespace DicomDemo.Authentication
   Public Class Extensions
      Private Sub New()
      End Sub
      Public Shared Function ToSecureString(ByVal password As String) As SecureString
         Dim passwordChars As Char()
         Dim secure As SecureString


         passwordChars = password.ToCharArray()
         secure = New SecureString()

         For Each c As Char In passwordChars
            secure.AppendChar(c)
         Next

         secure.MakeReadOnly()

         Return secure
      End Function
   End Class
End Namespace

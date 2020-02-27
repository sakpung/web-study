' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Text

Namespace DicomTranDemo
   Friend Class MyTransferSyntax
      Public szUID As String
      Public szDescription As String

      Public Overrides Function ToString() As String
         Return szDescription
      End Function
   End Class
End Namespace

' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System
Imports System.Collections.Specialized

Namespace Leadtools.DicomDemos

   Public Class PresentationContext
      Private _AbstractSyntax As String
      Private _TransferSyntaxList As StringCollection = New StringCollection

      Public Sub New()
      End Sub

      Public Property AbstractSyntax() As String
         Get
            Return _AbstractSyntax
         End Get
         Set(ByVal Value As String)
            _AbstractSyntax = Value
         End Set
      End Property

      Public ReadOnly Property TransferSyntaxList() As StringCollection
         Get
            Return _TransferSyntaxList
         End Get
      End Property

   End Class

End Namespace

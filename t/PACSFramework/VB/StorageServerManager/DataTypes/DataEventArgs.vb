' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text

Namespace Leadtools.Demos.StorageServer.DataTypes
   Public Class DataEventArgs(Of T) : Inherits EventArgs
      Public Sub New(ByVal dataParam As T)
         Data = dataParam
      End Sub

      Private _data As T
      Public Property Data() As T
         Get
            Return _data
         End Get
         Private Set(ByVal value As T)
            _data = value
         End Set
      End Property
   End Class
End Namespace


' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text

Namespace Leadtools.Demos.StorageServer.DataTypes
   Public Class DisplayFeatureEventArgs : Inherits EventArgs
      Public Sub New(ByVal _feature As FeatureNames)
         Feature = _feature
      End Sub

      Dim _feature As FeatureNames
      Public Property Feature() As FeatureNames
         Get
            Return _feature
         End Get
         Private Set(ByVal value As FeatureNames)
            _feature = value
         End Set
      End Property
   End Class
End Namespace

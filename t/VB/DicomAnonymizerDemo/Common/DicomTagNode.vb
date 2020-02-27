' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports DicomAnonymizer.UI.Controls
Imports Leadtools.Dicom

Namespace DicomAnonymizer.Common
   Public Class DicomTagNode : Inherits TreeGridNode

      Private _DicomTag As DicomTag
      Public Property DicomTag() As DicomTag
         Get
            Return _DicomTag
         End Get
         Set(ByVal value As DicomTag)
            _DicomTag = value
         End Set
      End Property
   End Class
End Namespace

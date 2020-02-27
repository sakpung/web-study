' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports Microsoft.VisualBasic
Imports System
Imports System.Windows.Forms

Namespace DicomDemo
   ''' <summary>
   ''' Summary description for DicomTimer.
   ''' </summary>
   Public Class DicomTimer : Inherits Timer
      Private _Client As Client

      Public ReadOnly Property Client() As Client
         Get
            Return _Client
         End Get
      End Property

      Public Sub New(ByVal NetClient As Client, ByVal time As Integer)
         _Client = NetClient
         Interval = (time * 1000)
      End Sub
   End Class
End Namespace

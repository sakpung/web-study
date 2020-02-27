' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports Microsoft.VisualBasic
Imports System
Imports System.Data

Namespace Leadtools.Demos.Database
   ''' <summary>
   ''' Summary description for DBBase.
   ''' </summary>
   Public Class DBBase
      Protected ds As DataSet = New DataSet("DICOMSVR")
      Protected dbFileName As String

      Public ReadOnly Property Count() As Integer
         Get
            Return ds.Tables(0).Rows.Count
         End Get
      End Property

      Public ReadOnly Property DB() As DataSet
         Get
            Return ds
         End Get
      End Property

      Public Sub New()
         '
         ' TODO: Add constructor logic here
         '
      End Sub

      Protected Function LoadDatabase() As Boolean
         Dim loaded As Boolean = True

         Try
            ds.ReadXml(dbFileName)
         Catch e As Exception
            loaded = False
         End Try
         Return loaded
      End Function

      Public Function Save() As Boolean
         Dim ret As Boolean = False

         Try
            ds.WriteXml(dbFileName, XmlWriteMode.WriteSchema)
            ret = True
         Catch
         End Try
         Return ret
      End Function

   End Class
End Namespace

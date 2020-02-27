' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.IO
Imports System.Xml
Imports System.Xml.Serialization

Namespace PDFDocumentDemo
   ' Current demo options, we can load/save this to disk
   Public Structure DemoOptions
      Public OpenCommonDialogFolder As String

      Public Shared ReadOnly Property [Default]() As DemoOptions
         Get
            Dim obj As DemoOptions = New DemoOptions()
            Return obj
         End Get
      End Property

      Private Shared ReadOnly Property DataFileName() As String
         Get
            Return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "PDFDocumentDemo.xml")
         End Get
      End Property

      Private Shared _serializer As XmlSerializer

      Public Shared Function Load() As DemoOptions
         Try
            If File.Exists(DataFileName) Then
               Dim reader As XmlTextReader = New XmlTextReader(DataFileName)
               Try
                  Return CType(_serializer.Deserialize(reader), DemoOptions)
               Finally
                  CType(reader, IDisposable).Dispose()
               End Try
            Else
               Return DemoOptions.Default
            End If
         Catch
            Return DemoOptions.Default
         End Try
      End Function

      Public Sub Save()
         Try
            Dim writer As XmlTextWriter = New XmlTextWriter(DataFileName, Encoding.Unicode)
            Try
               writer.Formatting = Formatting.Indented
               writer.Indentation = 2
               _serializer.Serialize(writer, Me)
            Finally
               CType(writer, IDisposable).Dispose()
            End Try
         Catch
         End Try
      End Sub
      Shared Sub New()
         _serializer = New XmlSerializer(GetType(DemoOptions))
      End Sub
   End Structure
End Namespace

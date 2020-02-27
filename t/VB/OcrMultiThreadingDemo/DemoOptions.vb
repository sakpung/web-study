' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.Xml
Imports System.Xml.Serialization
Imports System.IO
Imports System.Windows.Forms

Imports Leadtools.Ocr
Imports Leadtools.Document.Writer

Namespace OcrMultiThreadingDemo
   <Serializable()> _
   Public Class DemoOptions
      ' The engine type to use
      Public OcrEngineType As OcrEngineType = OcrEngineType.OmniPage
      ' The source directory
      Public SourceDirectory As String = Nothing
      ' Filter of source files (e.g, *.tif)
      Public SourceFilter As String = "*.tif"
      ' Destination directory where recognized documents will be created
      Public DestinationDirectory As String = Nothing
      ' Format to use
      Public DestinationDocumentFormat As DocumentFormat = DocumentFormat.Pdf
      ' All formats options
      Public DocumentFormatOptionsAsXml As String = Nothing

      ' Load/Save
      Private Shared _serializer As New XmlSerializer(GetType(DemoOptions))

      Private Shared Function GetXmlFileName() As String
         Return Path.Combine(Application.CommonAppDataPath, "OcrMultiThreadingDemo.xml")
      End Function

      Public Shared Function LoadDefault() As DemoOptions
         Dim options As New DemoOptions()

         Dim xmlFileName As String = GetXmlFileName()
         If File.Exists(xmlFileName) Then
            Try
               Using reader As StreamReader = File.OpenText(xmlFileName)
                  options = TryCast(_serializer.Deserialize(reader), DemoOptions)
               End Using
            Catch
            End Try
         End If

         Return options
      End Function

      Public Sub SaveDefault()
         Dim xmlFileName As String = GetXmlFileName()

         Try
            Using writer As TextWriter = New StreamWriter(xmlFileName)
               _serializer.Serialize(writer, Me)
            End Using
         Catch
         End Try
      End Sub
   End Class
End Namespace

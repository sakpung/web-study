' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.Xml
Imports System.Xml.Serialization
Imports System.IO

Namespace Ocr2SharePointDemo
   Public Structure DemoOptions
	  Public SharePointServerSettings As SharePoint.SharePointServerSettings
	  Public ImageDocumentFileName As String
	  Public DocumentFormatIndex As Integer

	  Public Shared ReadOnly Property [Default]() As DemoOptions
		 Get
			Dim obj As DemoOptions = New DemoOptions()
			obj.SharePointServerSettings = SharePoint.SharePointServerSettings.Default
			obj.ImageDocumentFileName = Nothing
			obj.DocumentFormatIndex = 0
			Return obj
		 End Get
	  End Property

	  Private Shared ReadOnly Property DataFileName() As String
		 Get
			Return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Ocr2SharePoint2010Demo.xml")
		 End Get
	  End Property

	  Private Shared _serializer As XmlSerializer

	  Public Shared Function Load() As DemoOptions
		 Try
			If File.Exists(DataFileName) Then
			   Using reader As XmlTextReader = New XmlTextReader(DataFileName)
				  Return CType(_serializer.Deserialize(reader), DemoOptions)
			   End Using
			Else
			   Return DemoOptions.Default
			End If
		 Catch
			Return DemoOptions.Default
		 End Try
	  End Function

	  Public Sub Save()
		 Try
			Using writer As XmlTextWriter = New XmlTextWriter(DataFileName, Encoding.Unicode)
			   writer.Formatting = Formatting.Indented
			   writer.Indentation = 2
			   _serializer.Serialize(writer, Me)
			End Using
		 Catch
		 End Try
	  End Sub
	   Shared Sub New()
		   _serializer = New XmlSerializer(GetType(DemoOptions), New Type() { GetType(SharePoint.SharePointServerSettings) })
	   End Sub
   End Structure
End Namespace

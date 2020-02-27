' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Xml.Serialization
Imports System.IO
Imports System.Runtime.InteropServices
Imports System.Security.Permissions

Namespace VBDicomDirLinqDemo.Utils
	Public NotInheritable Class SettingsManager
		<DllImport("shfolder.dll", CharSet := CharSet.Auto)> _
		Private Shared Function SHGetFolderPath(ByVal hwndOwner As IntPtr, ByVal nFolder As Integer, ByVal hToken As IntPtr, ByVal dwFlags As Integer, ByVal lpszPath As StringBuilder) As Integer
		End Function

		Private Const CommonDocumentsFolder As Integer = &H2e

		Public Enum InstallPlatform
			win32 = 0
			x64 = 1
		End Enum

		Private Sub New()
		End Sub
		Public Shared Function Load(Of T)(ByVal demoName As String) As T
			Dim SerializerObj As New XmlSerializer(GetType(T))
			Dim filename As String = GetSettingsFilename(demoName)
			Dim settings As T = Nothing

			If File.Exists(filename) Then
				Try
					' Create a new file stream for reading the XML file
					Using ReadFileStream As TextReader = New StreamReader(filename)
						settings = CType(SerializerObj.Deserialize(ReadFileStream), T)
						ReadFileStream.Close()
					End Using
				Catch e1 As Exception
					Throw
				End Try
			Else
				Try
					Dim data() As Byte = Encoding.ASCII.GetBytes(My.Resources.DefaultQueries)

					Using stream As New MemoryStream(data)
						settings = CType(SerializerObj.Deserialize(stream), T)
					End Using
				Catch e As Exception
					Throw e
				End Try
			End If

			If settings Is Nothing Then
				settings = Nothing
			End If

			Return settings
		End Function

		Public Shared Sub Save(Of T)(ByVal demoName As String, ByVal settings As T)
			Try
				Dim filename As String = GetSettingsFilename(demoName)
				Dim xs As New XmlSerializer(GetType(T))

				Using xmlTextWriter As TextWriter = New StreamWriter(filename)
					xs.Serialize(xmlTextWriter, settings)
					xmlTextWriter.Close()
				End Using
			Catch e1 As Exception
				Throw
			End Try
		End Sub

		Private Shared Function GetSettingsFilename(ByVal demo As String) As String
			Dim commonFolder As String = GetFolderPath()
			If Is64Process() Then
				Return GetSettingsFilename(demo, InstallPlatform.x64)
			Else
				Return GetSettingsFilename(demo, InstallPlatform.win32)
			End If
		End Function

		Private Shared Function Is64Process() As Boolean
			Return IntPtr.Size = 8
		End Function

		Public Shared Function GetFolderPath() As String
			Dim lpszPath As New StringBuilder(260)
			' CommonDocuments is the folder than any Vista user (including 'guest') has read/write access
			SHGetFolderPath(IntPtr.Zero, CInt(Fix(CommonDocumentsFolder)), IntPtr.Zero, 0, lpszPath)
			Dim path As String = lpszPath.ToString()
			CType(New FileIOPermission(FileIOPermissionAccess.PathDiscovery, path), FileIOPermission).Demand()
			Return path
		End Function

		Public Shared Function GetSettingsFilename(ByVal demo As String, ByVal platform As InstallPlatform) As String
			Dim commonFolder As String = GetFolderPath()
			Dim sPlatform As String = "32"

			If platform = InstallPlatform.x64 Then
				sPlatform = "64"
			Else
				sPlatform = "32"
			End If

			Dim ext As String = Path.GetExtension(demo)
			Dim name As String = Path.GetFileNameWithoutExtension(demo)

			Dim settingsFilename As String = String.Format("{0}\{1}{2}{3}_17.xml", commonFolder, name, sPlatform, ext)
			Return settingsFilename
		End Function
	End Class
End Namespace

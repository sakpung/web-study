' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Runtime.InteropServices
Imports System.IO
Imports System.Windows.Forms
Imports System.Drawing

Namespace Ocr2SharePointDemo
   ' A dictionary that holds the icon and description for file types
   Public Class FileTypeDictionary
	  ' Each file type has a description and an image (index into the image list)
	  Friend Structure MyFileType
		 Public Description As String
		 Public ImageIndex As Integer
	  End Structure

	  ' The image list to hold the icons into
	  Private _imageList As ImageList
	  ' A dictionary of FileType based on "Extension"
	  Private _fileTypes As Dictionary(Of String, MyFileType)

	  Public Sub New(ByVal il As ImageList)
		 _imageList = il
		 _fileTypes = New Dictionary(Of String, MyFileType)()
	  End Sub

	  ' Interop

	  <Flags> _
	  Private Enum SHGFI
		 None = &H000
		 SHGFI_SMALLICON = &H001
		 SHGFI_USEFILEATTRIBUTES = &H010
		 SHGFI_ICON = &H100
		 SHGFI_TYPENAME = &H400
	  End Enum

	  <StructLayout(LayoutKind.Sequential, Pack := 1)> _
	  Private Structure SHFILEINFO
		 Public hIcon As IntPtr
		 Public iIcon As Integer
		 Public dwAttributes As Integer
		 <MarshalAs(UnmanagedType.ByValTStr, SizeConst := 260)> _
		 Public szDisplayName As String
		 <MarshalAs(UnmanagedType.ByValTStr, SizeConst := 80)> _
		 Public szTypeName As String
	  End Structure

	  <DllImport("shell32.dll")> _
	  Private Shared Function SHGetFileInfo(ByVal pszPath As String, ByVal dwFileAttributes As UInteger, ByRef psfi As SHFILEINFO, ByVal cbFileInfo As Integer, ByVal uFlags As SHGFI) As IntPtr
	  End Function
	  Public Const FILE_ATTRIBUTE_DIRECTORY As UInteger = &H00000010
	  Public Const FILE_ATTRIBUTE_NORMAL As UInteger = &H00000080

	  Public Const DiretoryType As String = "##directory##"

	  Public Sub Add(ByVal extension As String)
		 ' Add the following extension properties into the internal
		 ' dictionary. If it is already there, we will not do anything

		 If _fileTypes.ContainsKey(extension) Then
			Return
		 End If

		 ' Not found, get the file info for this extension from the system

		 ' Get a dummy file name
		 Dim dummyFileName As String = Path.ChangeExtension("C:\Dummy", extension)

		 Dim shinfo As SHFILEINFO = New SHFILEINFO()
		 Dim flags As SHGFI = SHGFI.SHGFI_ICON Or SHGFI.SHGFI_SMALLICON Or SHGFI.SHGFI_USEFILEATTRIBUTES Or SHGFI.SHGFI_TYPENAME
		 Dim ret As IntPtr
		 If String.Compare(extension, DiretoryType, StringComparison.OrdinalIgnoreCase) = 0 Then
			 ret = SHGetFileInfo(dummyFileName,FILE_ATTRIBUTE_DIRECTORY, shinfo, Marshal.SizeOf(shinfo), flags)
		 Else
			 ret = SHGetFileInfo(dummyFileName,FILE_ATTRIBUTE_NORMAL, shinfo, Marshal.SizeOf(shinfo), flags)
		 End If

		 ' The icon is returned in the hIcon member of the shinfo struct.
		 Dim fileType As MyFileType = New MyFileType()

		 If Not ret.Equals(IntPtr.Zero) Then
			fileType.Description = shinfo.szTypeName

			If Not shinfo.hIcon.Equals(IntPtr.Zero) Then
			   _imageList.Images.Add(Icon.FromHandle(shinfo.hIcon))
			   fileType.ImageIndex = _imageList.Images.Count - 1
			Else
			   fileType.ImageIndex = -1
			End If
		 Else
			fileType.Description = "Unknown"
			fileType.ImageIndex = -1
		 End If

		 ' Add it to the dictionary
		 _fileTypes.Add(extension, fileType)
	  End Sub

	  Public Function GetDescription(ByVal extension As String) As String
		 ' Return the description
		 If _fileTypes.ContainsKey(extension) Then
			Return _fileTypes(extension).Description
		 Else
			Return String.Empty
		 End If
	  End Function

	  Public Function GetImageIndex(ByVal extension As String) As Integer
		 ' Return the description
		 If _fileTypes.ContainsKey(extension) Then
			Return _fileTypes(extension).ImageIndex
		 Else
			Return -1
		 End If
	  End Function
   End Class
End Namespace

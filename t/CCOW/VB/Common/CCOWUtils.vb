' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports Microsoft.VisualBasic
Imports System.Security.Cryptography
Imports System.Text
Imports System
Imports System.IO
Imports System.Windows.Forms
Imports System.Diagnostics
Imports System.Reflection
Imports System.Security.Permissions
Imports System.Runtime.InteropServices

Namespace Leadtools.Demos
	Public Enum InstallPlatform
		win32 = 0
		x64 = 1
	End Enum

	Public Class Win32Window : Implements IWin32Window
		Private _Handle As IntPtr = IntPtr.Zero

		Public Sub New(ByVal handle_Renamed As IntPtr)
			_Handle = handle_Renamed
		End Sub

		#Region "IWin32Window Members"

		Public ReadOnly Property Handle() As IntPtr Implements IWin32Window.Handle
			Get
				Return _Handle
			End Get
		End Property

		#End Region
	End Class

	Public Class CCOWUtils
		Private Shared ReadOnly random As Random = New Random()
		Private Const _Chars As String = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789"

		Private Sub New()
		End Sub
		Public Shared Function EncodePassword(ByVal originalPassword As String) As String
			'Declarations
			Dim originalBytes As Byte()
			Dim encodedBytes As Byte()
			Dim md5 As MD5

			'Instantiate MD5CryptoServiceProvider, get bytes for original password and compute hash (encoded password)
			md5 = New MD5CryptoServiceProvider()
			originalBytes = ASCIIEncoding.Default.GetBytes(originalPassword)
			encodedBytes = md5.ComputeHash(originalBytes)

			'Convert encoded bytes back to a 'readable' string
			Return BitConverter.ToString(encodedBytes)
		End Function

		Public Shared Function GetUniqueId(ByVal size As Integer) As String
			Dim buffer As Char() = New Char(size - 1){}

			Dim i As Integer = 0
			Do While i < size
				buffer(i) = _Chars.Chars(random.Next(_Chars.Length))
				i += 1
			Loop
			Return New String(buffer)
		End Function

		Public Shared Function LauchAuthApplication(ByVal handler As EventHandler) As Boolean
            Dim dbAuthAppFileName As String = Path.Combine(Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath), "VBCCOWAuthenticationDemo_Original.exe")

			If (Not File.Exists(dbAuthAppFileName)) Then
                dbAuthAppFileName = Path.Combine(Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath), "VBCCOWAuthenticationDemo.exe")
			End If

			If File.Exists(dbAuthAppFileName) Then
				Dim dbAuthProcess As Process = New Process()
				Dim args As String() = Environment.GetCommandLineArgs()

				dbAuthProcess.EnableRaisingEvents = True
				dbAuthProcess.StartInfo.Arguments = String.Join(" ", args, 1, args.Length - 1)
				If Not handler Is Nothing Then
					AddHandler dbAuthProcess.Exited, handler
				End If
				dbAuthProcess.StartInfo.FileName = dbAuthAppFileName
				If dbAuthProcess.Start() Then
					Return True
				End If
			Else
                Messager.ShowError(Nothing, "Could not find the VBCCOWAuthenticationDemo")
			End If

			Return False
		End Function

		<DllImport("shfolder.dll", CharSet := CharSet.Auto)> _
		Private Shared Function SHGetFolderPath(ByVal hwndOwner As IntPtr, ByVal nFolder As Integer, ByVal hToken As IntPtr, ByVal dwFlags As Integer, ByVal lpszPath As StringBuilder) As Integer
		End Function

		Private Const CommonDocumentsFolder As Integer = &H2e

		Private Shared Function GetFolderPath() As String
			Dim lpszPath As StringBuilder = New StringBuilder(260)
			' CommonDocuments is the folder than any Vista user (including 'guest') has read/write access
			SHGetFolderPath(IntPtr.Zero, CInt(CommonDocumentsFolder), IntPtr.Zero, 0, lpszPath)
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

		Private Shared Function GetActiveScenarioFilename(ByVal platform As InstallPlatform) As String
			Dim commonFolder As String = GetFolderPath()
			Dim settingsFilename As String = String.Format("{0}\{1}_17.xml", commonFolder, "ActiveScenario")

			Return settingsFilename
		End Function

		Public Shared Function GetActiveScenarioFilename() As String
			If DemosGlobal.Is64Process() Then
				Return GetActiveScenarioFilename(InstallPlatform.x64)
			Else
				Return GetActiveScenarioFilename(InstallPlatform.win32)
			End If
		End Function

		Private Shared Function GetSettingsFilename(ByVal demo As String) As String
			If DemosGlobal.Is64Process() Then
				Return GetSettingsFilename(demo, InstallPlatform.x64)
			Else
				Return GetSettingsFilename(demo, InstallPlatform.win32)
			End If
		End Function

		Private Shared Function GetSettingsFilename() As String
			Dim fullname As String = System.Reflection.Assembly.GetExecutingAssembly().Location
			Dim settingsFilename As String = GetSettingsFilename(Path.GetFileName(fullname))

			Return settingsFilename
		End Function

		Public Shared Sub Restart()
			Dim arguments As String = String.Empty
			Dim args As String() = Environment.GetCommandLineArgs()

			Dim i As Integer = 1
			Do While i < args.Length
				arguments &= args(i) & " "
				i += 1
			Loop

			Process.Start(Application.ExecutablePath, arguments)
		End Sub
	End Class
End Namespace

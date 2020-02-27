' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports Microsoft.Win32

Namespace Leadtools.Demos
	Public Class Constants
		Public Shared ReadOnly Property InstallLocation() As String
			Get
				Dim regKey As String = String.Empty
				Dim location As String = String.Empty

				regKey = "SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\{5ADEDEED-1ED0-40F7-88A7-C6D485CDBDBD}"
				If regKey.Length <> 0 Then
					Dim key As RegistryKey = Registry.LocalMachine.OpenSubKey(regKey)

					If Not key Is Nothing Then
						Dim Value As Object = key.GetValue("InstallLocation")

						key.Close()
						If Not Value Is Nothing Then
							location = Value.ToString()
						End If
					End If
				End If

				If location = String.Empty Then
					location = System.Windows.Forms.Application.StartupPath
				End If
				Return location
			End Get
		End Property
	End Class
End Namespace

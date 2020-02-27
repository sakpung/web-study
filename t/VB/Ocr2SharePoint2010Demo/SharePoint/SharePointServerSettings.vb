' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Text

Namespace Ocr2SharePointDemo.SharePoint
   Public Structure SharePointServerSettings
	  ' The properties for the Share Point server we are connecting to
	  ' The URL to the server
	  Public Uri As String
	  ' Credentials to use, if UserName is null, credentials are not used
	  Public UserName As String
	  Public Password As String
	  Public Domain As String
	  ' Proxy settings, if Host is null, not used
	  Public ProxyUri As String
	  Public ProxyPort As Integer

	  Public Shared ReadOnly Property [Default]() As SharePointServerSettings
		 Get
			Dim obj As SharePointServerSettings = New SharePointServerSettings()
			Return obj
		 End Get
	  End Property
   End Structure
End Namespace

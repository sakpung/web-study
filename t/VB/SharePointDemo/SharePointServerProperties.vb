' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.Net

Namespace SharePointDemo
   ' The properties for the Share Point server we are connecting to
   Public Structure SharePointServerProperties
      ' The URL to the server
      Public Url As String
      ' Credentials to use
      Public UseCredentials As Boolean
      Public UserName As String
      Public Password As String
      Public Domain As String
      ' Proxy settings
      Public UseProxy As Boolean
      Public Host As String
      Public Port As Integer
   End Structure
End Namespace

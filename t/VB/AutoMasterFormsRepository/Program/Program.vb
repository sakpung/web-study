' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.Text.RegularExpressions
Imports System.Xml
Imports System.IO
Imports Leadtools
Imports Leadtools.Codecs
Imports Leadtools.Forms.Auto
Imports Leadtools.Forms.Recognition
Imports Leadtools.Forms.Processing

'This project is provided as an example of how to implement the following three interfaces: IMasterFormsRepository, IMasterFormsCategory, and IMasterForm.
'This demo is not intended to be a running one. These three interfaces are used with Leadtools.Forms.Auto.AutoFormsEngine class to store master forms and categorize them.
'The code provided in this project is the default implementation for the three mentioned interfaces that is shipped with LEADTOOLS SDK for Forms
'This project may help a user to build his own implementation of these interfaces that fits his application, for example, database repository.

Namespace FormProcessingCommandLineDemo
   Friend Class Program
	  Shared Sub Main(ByVal args As String())
	  End Sub
   End Class
End Namespace

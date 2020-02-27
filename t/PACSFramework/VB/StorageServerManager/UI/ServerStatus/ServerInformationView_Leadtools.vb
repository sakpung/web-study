' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text

Namespace Leadtools.Demos.StorageServer.UI
   Partial Friend Class ServerInformationView
      Public Sub ShowAbout()
         Dim dialogAbout As AboutDialog = New AboutDialog("Storage Server Manager")

         dialogAbout.ShowDialog()
      End Sub
   End Class
End Namespace

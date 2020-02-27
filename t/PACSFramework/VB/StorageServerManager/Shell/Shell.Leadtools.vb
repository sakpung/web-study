' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports Leadtools.Medical.License.Configuration
Imports System.Windows.Forms
Imports Leadtools.Logging

Namespace Leadtools.Demos.StorageServer
   Partial Public Class Shell
      Private Sub LoadLicense(ByVal licenseFile As String)
         If ServerState.Instance.License Is Nothing Then
            Dim license As ServerLicense = New ServerLicense(licenseFile)

            license.Initialize()
            ServerState.Instance.License = license
         Else
            ServerState.Instance.License.Load(licenseFile)
         End If
      End Sub

      Private Sub Start(ByVal form As Form)
         Try
            Application.Run(form)
         Finally
            Logger.Global.Dispose()
         End Try
      End Sub
   End Class
End Namespace

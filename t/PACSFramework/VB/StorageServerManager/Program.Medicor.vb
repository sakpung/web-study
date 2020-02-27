' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.IO
Imports System.Reflection
Imports Leadtools.Demos.StorageServer.UI.Authentication
Imports System.Diagnostics
Imports Leadtools.Demos.StorageServer.UI.AdministrativeSettings.Users
Imports System.Windows.Forms
Imports Leadtools.Demos.StorageServer.Properties
Imports System.Drawing
Imports Leadtools.Medical.OptionsDataAccessLayer
Imports Leadtools.Medical.DataAccessLayer

Namespace Leadtools.Demos.StorageServer
   Partial Friend Class Program
      Private Shared Sub InitializeLicense()
         Dim key As String = String.Empty
         Dim license As String = String.Empty

         Using stream As Stream = System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("Leadtools.Demos.StorageServer.Resources.License.lic")
            Using reader As StreamReader = New StreamReader(stream)
               license = reader.ReadToEnd()
            End Using
         End Using

         Using stream As Stream = System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("Leadtools.Demos.StorageServer.Resources.License.key")
            Using reader As StreamReader = New StreamReader(stream)
               key = reader.ReadToEnd()
            End Using
         End Using

         If key.Length > 0 AndAlso license.Length > 0 Then
            RasterSupport.SetLicense(System.Text.ASCIIEncoding.ASCII.GetBytes(license), key)
#If LEADTOOLS_V19_OR_LATER Then
            If(RasterSupport.KernelExpired) Then
               System.Diagnostics.Debugger.Log(0, Nothing, "*******************************************************************************" + Environment.NewLine)
               System.Diagnostics.Debugger.Log(0, Nothing, "*** NOTE: Your license file is missing, invalid or expired. LEADTOOLS will not function. Please contact LEAD Sales for information on obtaining a valid license.***" + Environment.NewLine)
               System.Diagnostics.Debugger.Log(0, Nothing, "*******************************************************************************" + Environment.NewLine)
            End If
#End If ' #If LEADTOOLS_V19_OR_LATER
         End If
      End Sub

      Public Shared Function CheckPacsConfigDemo() As Boolean
         ' do nothing
      End Function

      Public Shared Function Login(ByVal info As String, ByVal relogin As Boolean) As Boolean
         Dim dlgLogin As LoginDialog = New LoginDialog()
         Dim process As Process = Process.GetCurrentProcess()
         Dim optionsAgent As IOptionsDataAccessAgent = DataAccessServices.GetDataAccessService(Of IOptionsDataAccessAgent)()
         Dim lastUser As String = optionsAgent.Get(Of String)("LastUser", String.Empty)

         dlgLogin.Text = "Medicor Storage Server Manager Login"
         dlgLogin.Info = info
         dlgLogin.Username = lastUser
         dlgLogin.Icon = Resources.MainApp
         dlgLogin.CanSetUserName = Not relogin
         AddHandler dlgLogin.AuthenticateUser, AddressOf Of AuthenticateUserEventArgs
         If dlgLogin.ShowDialog(New WindowWrapper(process.MainWindowHandle)) = DialogResult.OK Then
            UserManager.User = New ManagerUser(dlgLogin.Username, UserManager.GetUserPermissions(dlgLogin.Username))
            LoadSplash()
            Return True
         End If
         Return False
      End Function

      Private Shared Sub LoadSplash()
         Dim stream As Stream = System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("Resources.Splash.bmp")

         If Not stream Is Nothing Then
            SplashForm.SplashBitmap = New Bitmap(stream)
         End If
      End Sub
   End Class
End Namespace

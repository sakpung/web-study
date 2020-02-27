' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Windows.Forms
Imports Leadtools.Logging
Imports Leadtools.Demos.StorageServer.UI.AdministrativeSettings.Users
Imports Leadtools.Demos.StorageServer.UI
Imports Leadtools.Demos.StorageServer.UI.Authentication
Imports System.Diagnostics
Imports Leadtools.Medical.Winforms
Imports Leadtools.DicomDemos
Imports System.Threading
Imports System.IO
Imports Leadtools.Medical.OptionsDataAccessLayer
Imports Leadtools.Medical.DataAccessLayer
Imports Leadtools.Medical.OptionsDataAccessLayer.Configuration
Imports Leadtools.Demos.StorageServer.DataTypes
Imports Microsoft.VisualBasic


Namespace Leadtools.Demos.StorageServer
   Partial Friend Class Program
      ''' <summary>
      ''' The main entry point for the application.
      ''' </summary>
      Private Sub New()
      End Sub
      <STAThread()> _
      Shared Sub Main()
         If ProcessChecker.IsOnlyProcess(Shell.storageServerName) Then

            ' Still want to let this application run with an expired license (as this is an enterprise level application), but in very a limited mode
            ' For example, the user should be able to view the log
            ' Support.SetLicense()
            ' If Support.KernelExpired Then
            ' Return
            ' End If

            Application.EnableVisualStyles()
            Application.SetCompatibleTextRenderingDefault(False)
            PacsProduct.ProductName = DicomDemoSettingsManager.ProductNameStorageServer

            Dim ok As Boolean

            Dim exeName As String = Path.GetFileNameWithoutExtension(Application.ExecutablePath)

            If Demos.DemosGlobal.Is64Process() Then
               exeName &= "64"
            Else
               exeName &= "32"
            End If

            Dim m As Mutex = New Mutex(True, exeName, ok)

            CheckPacsConfigDemo()

            Try
               Dim message As String = String.Empty
               Dim productsToCheck As String() = New String() {DicomDemoSettingsManager.ProductNameStorageServer}
               Dim dbConfigured As Boolean = GlobalPacsUpdater.IsDbComponentsConfigured(productsToCheck, message)

               If (Not dbConfigured) AndAlso (Not RequestUserToConfigureDbSucess(message)) Then
                  Return
               End If

               Dim optionsAgent As IOptionsDataAccessAgent
               Dim configuration As System.Configuration.Configuration = DicomDemoSettingsManager.GetGlobalPacsConfiguration()

               If (Not ok) Then
                  Return
               End If

               optionsAgent = DataAccessFactory.GetInstance(New OptionsDataAccessConfigurationView(configuration, DicomDemoSettingsManager.ProductNameStorageServer, Nothing)).CreateDataAccessAgent(Of IOptionsDataAccessAgent)()
               DataAccessServices.RegisterDataAccessService(Of IOptionsDataAccessAgent)(optionsAgent)

               If Login(String.Empty, False) Then
#If (Not DEBUG) Then
                  SplashForm.SplashBitmap = My.Resources.splash_screen
                  SplashForm.ShowSplash()
#End If
                  Dim shell As Shell = New Shell()

                  shell.Run()
               End If
            Catch ex As Exception
               MessageBox.Show("The program failed to run with the following error:" & Constants.vbLf + Constants.vbLf + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
               m.Close()
            End Try
         End If
      End Sub
      Private Shared Function RequestUserToConfigureDbSucess(ByVal missingDbComponents As String) As Boolean
         Dim message As String
         Dim result As DialogResult
         Dim Caption As String = "Warning"
         Dim pacsDatabaseConfigurationDemoName As String = "CSPacsDatabaseConfigurationDemo.exe"

         Dim pacsDatabaseConfigDemoFileName As String = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "CSPacsDatabaseConfigurationDemo_Original.exe")

         If (Not File.Exists(pacsDatabaseConfigDemoFileName)) Then
            pacsDatabaseConfigDemoFileName = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "CSPacsDatabaseConfigurationDemo.exe")
         End If

         message = "The following databases are not configured:" & Constants.vbLf + Constants.vbLf & "{0}" & Constants.vbLf & "Run the " & pacsDatabaseConfigurationDemoName & " to configure the missing databases." & Constants.vbLf + Constants.vbLf & "Do you want to run the " & pacsDatabaseConfigurationDemoName & " wizard?"

         message = String.Format(message, missingDbComponents)

         result = MessageBox.Show(message, Caption, MessageBoxButtons.YesNo, MessageBoxIcon.Warning)

         If DialogResult.Yes = result Then

            If File.Exists(pacsDatabaseConfigDemoFileName) Then
               Dim dbConfigProcess As Process


               dbConfigProcess = New Process()
               dbConfigProcess.StartInfo.FileName = pacsDatabaseConfigDemoFileName

               dbConfigProcess.Start()

               dbConfigProcess.WaitForExit()

               Dim productsToCheck As String() = New String() {DicomDemoSettingsManager.ProductNameStorageServer}

               Dim isDbConfigured As Boolean = GlobalPacsUpdater.IsDbComponentsConfigured(productsToCheck, missingDbComponents)

               If (Not isDbConfigured) Then
                  MessageBox.Show("Database is not configured.", Caption, MessageBoxButtons.OK, MessageBoxIcon.Error)


                  Return False

               End If
            Else
               MessageBox.Show("Could not find the " & pacsDatabaseConfigurationDemoName & " wizard", Caption, MessageBoxButtons.OK, MessageBoxIcon.Error)

               Return False
            End If
         Else
            Return False
         End If

         Return True
      End Function

      Private Shared _UserName As String

      Private Shared Sub dlgLogin_AuthenticateUser(ByVal sender As Object, ByVal e As AuthenticateUserEventArgs)
         '
         ' Once user is logged in we need to check to see if the user password
         ' has expired.
         '
         _UserName = e.Username
         Try
            If UserManager.Authenticate(e.Username, e.Password) Then
               If UserManager.IsPasswordExpired(e.Username) Then
                  Dim dlgPassword As StorageServer.UI.PasswordDialog = New StorageServer.UI.PasswordDialog()

                  dlgPassword.Text = "Reset Expired Password"
                  AddHandler dlgPassword.ValidatePassword, AddressOf dlgPassword_ValidatePassword
                  If dlgPassword.ShowDialog(TryCast(sender, Form)) = DialogResult.OK Then
                     UserManager.ResetPassword(e.Username, dlgPassword.Password)
                  Else
                     e.Cancel = True
                  End If
               End If
            Else
               Messager.ShowError(TryCast(sender, Form), "Invalid user name or password.")
               e.InvalidCredentials = True
            End If
         Catch exception As Exception
            Messager.ShowError(TryCast(sender, Form), exception)
            e.InvalidCredentials = True
         End Try

         If (Not e.Cancel) AndAlso (Not e.InvalidCredentials) Then
            Dim optionsAgent As IOptionsDataAccessAgent = DataAccessServices.GetDataAccessService(Of IOptionsDataAccessAgent)()

            optionsAgent.Set(Of String)("LastUser", e.Username)
         End If
      End Sub

      Private Shared Sub dlgPassword_ValidatePassword(ByVal sender As Object, ByVal e As ValidatePasswordEventArgs)
         Dim message As String = String.Empty

         e.Valid = True
         If (Not UserManager.ValidatePassword(e.Password, e.ConfirmPassword, message)) Then
            e.Valid = False
            Messager.ShowError(TryCast(sender, Form), message)
         ElseIf UserManager.IsPreviousPassword(_UserName, Extensions.ToSecureString(e.Password)) Then
            e.Valid = False
            Messager.ShowError(TryCast(sender, Form), "The password chosen has already been used.  Please choose a new password.")
         End If
      End Sub

      Public Class WindowWrapper : Implements System.Windows.Forms.IWin32Window
         Public Sub New(ByVal _handle As IntPtr)
            _hwnd = _handle
         End Sub

         Public ReadOnly Property Handle() As IntPtr Implements System.Windows.Forms.IWin32Window.Handle
            Get
               Return _hwnd
            End Get
         End Property

         Private _hwnd As IntPtr
      End Class
   End Class
End Namespace

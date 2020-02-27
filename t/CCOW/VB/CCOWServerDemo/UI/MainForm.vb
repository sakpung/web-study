' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System
Imports System.ComponentModel
Imports System.Runtime.InteropServices
Imports System.Security.Principal
Imports System.Threading
Imports System.Windows.Forms
Imports Leadtools.Ccow.Dialogs
Imports Leadtools.Ccow.Server
Imports Leadtools.Ccow.Services
Imports Leadtools.Demos
Imports Leadtools.Demos.Dialogs
Imports CcowServerDemo.Leadtools.Demos
Imports Microsoft.VisualBasic

Namespace VBCcowServerDemo
   Partial Public Class MainForm
      Inherits Form
      ''' <summary>
      ''' The main entry point for the application.
      ''' </summary>
      <STAThread()> _
      Shared Sub Main(args As String())
         If Environment.Version.Major < 4 Then
            ' Check if .NET 3.5 is installed
            If Not DemoUtils.IsDotNet35Installed() Then
               MessageBox.Show(Nothing, ".NET Framework 3.5 could not be found on this machine." & vbLf & vbLf & "Please install the .NET Framework 3.5 runtime and try again. This program will now exit.", "LEADTOOLS Ccow Participant Service Host", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
               Return
            End If
         End If

         ' Set license
         Support.SetLicense()

         For Each arg As String In args
            If String.IsNullOrEmpty(arg) Then
               Continue For
            End If

            Dim strippedArg As String = arg.Substring(1)
            Dim close As Boolean = False
            ' Register CCOW COM components
            If String.Compare(strippedArg, "register", True) = 0 Then
               CcowServer.Register()
               close = True
               ' Unregister CCOW COM components
            ElseIf String.Compare(strippedArg, "unregister", True) = 0 Then
               CcowServer.Unregister()
               close = True
            End If

            If close Then
               Return
            End If
         Next

         Application.EnableVisualStyles()
         Application.DoEvents()

         Dim frm As New MainForm()

         ' Start the CCOW server
         CcowServer.Start()

         Application.Run(frm)

         ' Stop the CCOW server
         CcowServer.[Stop]()

         Return
      End Sub

      Private _trayIcon As NotifyIcon
      Private _trayMenu As ContextMenu
      Private _ConfigDialog As ConfigurationDialog
      Private _ParticipantDialog As ParticipantDialog

      ' CCOW context management registry (ContextManagementRegistry Web Interface)
      '      Responsible for hosting and locating CCOW components services
      Private _ccowService As ContextManagementRegistryService

      Private _address As String
      ' Disable Close button
      Protected Overrides ReadOnly Property CreateParams() As CreateParams
         Get
            Const CP_NOCLOSE_BUTTON As Integer = &H200
            Dim myCp As CreateParams = MyBase.CreateParams
            myCp.ClassStyle = myCp.ClassStyle Or CP_NOCLOSE_BUTTON
            Return myCp
         End Get
      End Property

      Public Sub New()
         InitializeComponent()

         ' Start the web service
         If DemoUtils.CheckAdminRights() Then
            Me._address = String.Format("{0}/Leadtools", Environment.MachineName)
         End If

         ' Init Dialogs
         InitDialogs()
         ' Init try icon and menu
         InitTrayIcon()
         ' Hide main form
         HideForm()
      End Sub

      Private _trayMenu_Configuration As MenuItem
      Private _trayMenu_Participants As MenuItem

      Private Sub InitDialogs()
         _ConfigDialog = New ConfigurationDialog(Me._address)
         _ParticipantDialog = New ParticipantDialog()
      End Sub

      Private Sub InitTrayIcon()
         _trayMenu = New ContextMenu()
         AddHandler _trayMenu.Popup, AddressOf TrayMenu_Popup
         _trayMenu_Configuration = _trayMenu.MenuItems.Add("Configuration...", AddressOf TrayMenu_OnConfiguration)
         _trayMenu_Participants = _trayMenu.MenuItems.Add("Participants...", AddressOf TrayMenu_OnParticipants)
         _trayMenu_Participants = _trayMenu.MenuItems.Add("-")
         _trayMenu.MenuItems.Add("About", AddressOf TrayMenu_OnAbout)
         _trayMenu.MenuItems.Add("Exit", AddressOf TrayMenu_OnExit)
         _trayIcon = New NotifyIcon()
         _trayIcon.Text = Me.Text
         _trayIcon.Icon = Me.Icon

         _trayIcon.ContextMenu = _trayMenu
      End Sub

      Private Sub TrayMenu_Popup(sender As Object, e As EventArgs)
         _trayMenu_Configuration.Enabled = Not _ConfigDialog.Visible
         _trayMenu_Participants.Enabled = Not _ParticipantDialog.Visible
      End Sub

      Private Sub TrayMenu_OnConfiguration(sender As Object, e As EventArgs)
         Try
            ' Login as admin
            If Login() Then
               ' Show the CCOW server configuration dialog
               ShowCcowDialog(_ConfigDialog)
            End If
         Catch exception As Exception
            MessageBox.Show(exception.Message, "Error During Configuration", MessageBoxButtons.OK, MessageBoxIcon.[Error])
         End Try
      End Sub

      Private Sub TrayMenu_OnParticipants(sender As Object, e As EventArgs)
         ' Show the CCOW participants dialog
         ShowCcowDialog(_ParticipantDialog)
      End Sub

      Private Sub ShowCcowDialog(dialog As Form)
         If Not dialog.Visible Then
            dialog.Show()
         Else
            dialog.Activate()
         End If
      End Sub

      Private Sub TrayMenu_OnAbout(sender As Object, e As EventArgs)
         Dim aboutDialog As New AboutDialog(Me.Text, ProgrammingInterface.VB)
         aboutDialog.ShowDialog(Me)
      End Sub

      Private Sub TrayMenu_OnExit(sender As Object, e As EventArgs)
         If _ConfigDialog.Visible OrElse _ParticipantDialog.Visible Then
            MessageBox.Show("Must close all dialogs before existing", "Close Config Dialog", MessageBoxButtons.OK, MessageBoxIcon.[Stop])
            If _ConfigDialog.Visible Then
               ShowCcowDialog(_ConfigDialog)
            Else
               ShowCcowDialog(_ParticipantDialog)
            End If
         Else
            Application.[Exit]()
         End If
      End Sub

      Private Sub ShowForm()
         ' Show the Main window and hide the try icon
         Me.Show()
         Me.WindowState = FormWindowState.Normal
         Me.BringToFront()
         Me._trayIcon.Visible = False
      End Sub

      Private Sub HideForm()
         ' Mimize the Main window and show the try icon
         Me.WindowState = FormWindowState.Minimized
         Me.ShowInTaskbar = False
         Me._trayIcon.Visible = True
      End Sub


      Private Sub MainForm_Resize(sender As Object, e As EventArgs) Handles Me.Resize
         ' If minize, then hide the form
         If Me.WindowState = FormWindowState.Minimized Then
            Me.HideForm()
         End If
      End Sub

      Private Sub StartService()
         ' Start the CCOW web services
         Try
            ' Set the base address
            _ccowService = New ContextManagementRegistryService("LEADTOOLS", Me._address, Guid.NewGuid().ToString("N"))
            _ccowService.Start()
         Catch ex As Exception
            MessageBox.Show(ex.Message)
         End Try
      End Sub

      Private Sub BtnClose_Click(sender As Object, e As EventArgs)
         Close()
      End Sub

      Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles Me.Load
         ' Start the CCOW web services
         If DemoUtils.CheckAdminRights() Then
            StartService()
         End If
      End Sub

      Private Sub MainForm_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
         ' Close the host
         If _ccowService IsNot Nothing Then
            _ccowService.[Stop]()
         End If

         Me._trayIcon.Visible = False
      End Sub

      Private Function Login() As Boolean
         Using dlgLogin As New CredentialsDialog()
            dlgLogin.User = Config.[Get](Of String)("LastUser", String.Empty)
            dlgLogin.Caption = "CCOW Server"
            dlgLogin.Message = "Please provide an administrative user to access configuration settings."
            While True
               If dlgLogin.ShowDialog() = DialogResult.OK Then
                  Dim token As IntPtr = IntPtr.Zero

                  If AuthenticationUtils.Login(dlgLogin.Domain, dlgLogin.User, dlgLogin.PasswordToString(), token) Then
                     Dim principal As WindowsPrincipal = TryCast(Thread.CurrentPrincipal, WindowsPrincipal)

                     If AuthenticationUtils.IsAdmin(principal) OrElse AuthenticationUtils.IsDomainAdmin(principal) Then
                        Dim saveUser As String = dlgLogin.User

                        If Not String.IsNullOrEmpty(dlgLogin.Domain) Then
                           saveUser = dlgLogin.Domain + "\" + dlgLogin.User
                        End If

                        Config.[Set](Of String)("LastUser", saveUser)
                        Return True
                     Else
                        MessageBox.Show(Me, "User is not a member of Administrators group.", "Invalid User", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                     End If
                  Else
                     Dim e As New Win32Exception(Marshal.GetLastWin32Error())

                     MessageBox.Show(Me, e.Message, "Authentication Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                  End If
               Else
                  Exit While
               End If
            End While
         End Using
         Return False
      End Function
   End Class
End Namespace

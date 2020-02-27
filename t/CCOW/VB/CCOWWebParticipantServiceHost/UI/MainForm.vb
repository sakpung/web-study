' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System
Imports System.ServiceModel
Imports System.ServiceModel.Description
Imports System.Windows.Forms
Imports Leadtools.Ccow.Services
Imports Leadtools.Demos
Imports Leadtools.Demos.Dialogs
Imports Leadtools.Wcf
Imports Microsoft.VisualBasic
Imports Leadtools.Ccow
Imports CcowWebParticipantServiceHost.Leadtools.Demos

Namespace CcowWebParticipantServiceHost
   Partial Public Class MainForm
      Inherits Form
      ''' <summary>
      ''' The main entry point for the application.
      ''' </summary>
      <STAThread()> _
      Shared Sub Main()
         If DemoUtils.IsAlreadyRunning() Then
            Return
         End If

         If Environment.Version.Major < 4 Then
            ' Check if .NET 3.5 is installed
            If Not DemoUtils.IsDotNet35Installed() Then
               MessageBox.Show(Nothing, ".NET Framework 3.5 could not be found on this machine." & vbLf & vbLf & "Please install the .NET Framework 3.5 runtime and try again. This program will now exit.", "LEADTOOLS Ccow Participant Service Host", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
               Return
            End If
         End If

         Dim args As String() = Environment.GetCommandLineArgs()
         If args IsNot Nothing AndAlso args.Length > 0 Then
            For Each command As String In args
               If command.CompareTo("install") = 0 Then
                  Utils.RegisterAppUrl("VBCcowWebParticipantServiceHost")
                  Return
               ElseIf command.CompareTo("uninstall") = 0 Then
                  Utils.UnregisterAppUrl("VBCcowWebParticipantServiceHost")
                  Return
               End If
            Next
         End If

         Application.EnableVisualStyles()
         Application.DoEvents()

         Application.Run(New MainForm())
      End Sub

      Private _trayIcon As NotifyIcon
      Private _trayMenu As ContextMenu

      Private _host As ServiceHost
      Private _service As CcowParticipantService
      Private _clientsCount As Integer

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

         Dim settings As New Properties.Settings()

         ' Set license
         Support.SetLicense()

         ' Init try icon and menu
         InitTrayIcon()
         ' Hide main form
         HideForm()
      End Sub

      Private Sub InitTrayIcon()
         Me._trayMenu = New ContextMenu()
         Me._trayMenu.MenuItems.Add("About", AddressOf TrayMenu_OnAbout)
         Me._trayMenu.MenuItems.Add("Exit", AddressOf TrayMenu_OnExit)
         Me._trayIcon = New NotifyIcon()
         Me._trayIcon.Text = Me.Text
         Me._trayIcon.Icon = Me.Icon
         Me._trayIcon.ContextMenu = _trayMenu
         ' Show Main window on double click
         AddHandler Me._trayIcon.DoubleClick, AddressOf TrayIcon_DoubleClick
      End Sub

      Private Sub TrayMenu_OnAbout(sender As Object, e As EventArgs)
         Dim aboutDialog As New AboutDialog(Me.Text, ProgrammingInterface.VB)
         aboutDialog.ShowDialog(Me)
      End Sub

      Private Sub TrayMenu_OnExit(sender As Object, e As EventArgs)
         Application.[Exit]()
      End Sub

      Private Sub TrayIcon_DoubleClick(sender As Object, e As EventArgs)
         Me.ShowForm()
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
         If Me._host IsNot Nothing Then
            Me._host.Close()
            Me._host = Nothing
         End If

         ' Init the address
         Dim localAddress As New Uri(Me._txtAddress.Text)
         Dim binding As New WebHttpBinding()

         Me._clientsCount = 0
         ' Init the service
         Me._service = New CcowParticipantService()
         AddHandler Me._service.ClientConnected, AddressOf Service_ClientConnected
         AddHandler Me._service.ClientDisconnected, AddressOf Service_ClientDisconnected

         Me._host = New ServiceHost(_service, localAddress)
#If Not DOTNET_2 Then
         binding.CrossDomainScriptAccessEnabled = True
#End If
         Dim endpoint As ServiceEndpoint = _host.AddServiceEndpoint(GetType(ICcowParticipantService), binding, localAddress)
         ' Add cors support (for Cross Domain)
         endpoint.Behaviors.Add(New CorsSupportBehavior())
         ' Add CcowWebHttpBehavior for parameters conversion
         endpoint.Behaviors.Add(New CcowWebHttpBehavior())
         Me._host.Open()
      End Sub

      Private Sub Service_ClientConnected(sender As Object, e As ClientConnectionEventArgs)
         Me._clientsCount += 1
      End Sub

      Private Sub Service_ClientDisconnected(sender As Object, e As ClientConnectionEventArgs)
         Me._clientsCount -= 1
         ' Close the application if the counts is zero
         If Me._clientsCount = 0 Then
            Me.Invoke(New MethodInvoker(Sub() Close()))
         End If
      End Sub

      Private Sub BtnClose_Click(sender As Object, e As EventArgs) Handles _btnClose.Click
         Close()
      End Sub

      Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles Me.Load
         ' Set the base address
         Me._txtAddress.Text = "http://localhost:80/LEADTOOLSContextParticipant"

         ' Start the participant service
         StartService()
      End Sub

      Private Sub MainForm_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
         ' Close the host
         If _host IsNot Nothing Then
            _host.Close()
            _host = Nothing
            _service = Nothing
         End If
         Me._trayIcon.Visible = False
      End Sub
   End Class
End Namespace

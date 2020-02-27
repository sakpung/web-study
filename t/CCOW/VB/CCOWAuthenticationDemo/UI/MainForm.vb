' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports Microsoft.VisualBasic
Imports System
Imports System.Windows.Forms
Imports Leadtools.Demos
Imports Leadtools
Imports Leadtools.Ccow
Imports System.IO
Imports System.Diagnostics
Imports System.Runtime.InteropServices
Imports System.Threading

#If LEADTOOLS_V19_OR_LATER Then
Imports System.Linq
Imports Leadtools.Ccow.Server
Imports Leadtools.Ccow.Server.Data
#End If ' #if LEADTOOLS_V19_OR_LATER

Namespace CCOWAuthenticationDemo
   Partial Public Class MainForm : Inherits Form
      Public Const _ApplicationName As String = "CCOW Authentication Application"
      Public Const _Suffix As String = "AuthApp"
      Private _LoggedIn As Boolean = False

      Private _Context As ClientContext = Nothing
      Private _Passcode As String = "5DC2ABCD-A855-4530-BC9C-2F13C58DDC0E"
      Public Shared _LaunchArgs As String = String.Empty

      <DllImport("user32.dll")> _
      Private Shared Function SetForegroundWindow(ByVal hWnd As IntPtr) As <MarshalAs(UnmanagedType.Bool)> Boolean
      End Function


        Public Class Program
            ''' <summary>
            ''' The main entry point for the application.
            ''' </summary>
            Private Sub New()
            End Sub
            <STAThread()> _
            Shared Sub Main(ByVal args As String())
                Dim createdNew As Boolean = True

                Using mutex As Mutex = New Mutex(True, "CSCCOWAthenticationDemo", createdNew)
               If createdNew Then
                  If Not Support.SetLicense() Then
                     Return
                  End If

                  If RasterSupport.IsLocked(RasterSupportType.Ccow) Then
                     MessageBox.Show("CCOW Support is locked!  Application will exit.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                     Return
                  End If

                  If args.Length > 0 Then
                     _LaunchArgs = String.Join(" ", args)
                  End If

                  Application.EnableVisualStyles()
                  Application.SetCompatibleTextRenderingDefault(False)
                  Application.Run(New MainForm())
               Else
                  Dim current As Process = Process.GetCurrentProcess()

                  For Each process As Process In process.GetProcessesByName(current.ProcessName)
                     If process.Id <> current.Id Then
                        SetForegroundWindow(process.MainWindowHandle)
                        Exit For
                     End If
                  Next process

               End If
            End Using
            End Sub
        End Class

        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub MainForm_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
            Messager.Caption = "CCOW Sign-On Application"
            Text = "VB.NET " & Messager.Caption

            AddHandler Application.ThreadException, AddressOf Application_ThreadException
            Try
                _Context = New ClientContext(Messager.Caption, _Passcode, Me)
                If _Context.IsValid Then
                    AddHandler _Context.JoinedContext, AddressOf Context_JoinedContext
                    AddHandler _Context.ChangesAccepted, AddressOf Context_ChangesAccepted
                    labelCurrentUser.Text = String.Empty
                    labelFullName.Text = String.Empty
                    JoinContext()
                    AddHandler System.Windows.Forms.Application.Idle, AddressOf Application_Idle
                Else
                    Messager.ShowError(Me, "The Context Manager COM object could not be created.")
                    Close()
                End If
            Catch exception As Exception
                Messager.ShowError(Me, exception)
            End Try
        End Sub

        Private Sub Application_ThreadException(ByVal sender As Object, ByVal e As ThreadExceptionEventArgs)
            Throw New NotImplementedException()
        End Sub

        Private Sub Join()
            _Context.Join(_ApplicationName, True)
        End Sub

        Private Sub JoinContext()
            Try
                Dim dlgProgress As ProgressInfoDialog = New ProgressInfoDialog(Me)

                dlgProgress.Title = "Joining Common Context"
                dlgProgress.Description = "Attempting to join common context"
                If dlgProgress.ShowDialog(New MethodInvoker(AddressOf Join)) = System.Windows.Forms.DialogResult.OK Then
                    _Context.SetFilter("User")
                Else
                    If Not dlgProgress.Exception Is Nothing Then
                        Throw dlgProgress.Exception
                    End If
                End If
            Catch e As Exception
                Messager.ShowError(Me, e)
                Close()
            End Try
        End Sub

#Region "Context Events"

        Private Sub Context_JoinedContext(ByVal sender As Object, ByVal e As EventArgs)
            SetCCowIcon(ContextState.Linked)
        End Sub

        Private Sub Context_ChangesAccepted(ByVal sender As Object, ByVal e As ContextEventArgs)
         Dim logOff_Renamed As Boolean = False

            If _Context.IsSetting("user", "logon", e.ContextCoupon) Then
                Dim item As ContextItem = New ContextItem("User.Id.logon." & _Suffix)
                Dim temp As String = _Context.GetItemValue(item, False, e.ContextCoupon)

                '
                ' Check to see if an application has logged off the user
                '
                If String.IsNullOrEmpty(temp) Then
                    logOff_Renamed = True
                End If
            Else
                logOff_Renamed = True
            End If

            If logOff_Renamed Then
                Invoke(New MethodInvoker(AddressOf LogOff))
            End If
        End Sub

#End Region

      Private Sub LogOff()
         buttonLogon.Text = "Logon"
         labelCurrentUser.Text = String.Empty
         labelFullName.Text = String.Empty
         _LoggedIn = False
#If LEADTOOLS_V19_OR_LATER Then
         If (CheckPatientDependencies()) Then
            _Context.Leave()
         End If
#End If ' #if LEADTOOLS_V19_OR_LATER
      End Sub

#If LEADTOOLS_V19_OR_LATER Then
      Private Shared Function CheckPatientDependencies() As Boolean
         Monitor.Enter(CcowServer.LockObject)
         Try
            Using db As Database = Leadtools.Ccow.Server.Utils.GetDatabase()
               Dim patientSubject As CCOWSubject = db.CCOWSubject.FirstOrDefault(Function(a) a.Subject.ToLower() = "patient")
               For Each dp As CCOWSubjectDependency In patientSubject.DependentSubjects
                  If dp.CCOWSubject.Subject.ToLower() = "user" Then
                     Return True
                  End If
               Next
            End Using
         Finally
            Monitor.[Exit](CcowServer.LockObject)
         End Try

         Return False
      End Function
#End If ' #if LEADTOOLS_V19_OR_LATER

      Private Sub SetCCowIcon(ByVal state As ContextState)
         Select Case state
            Case ContextState.Broken
               pictureBoxCcowStatus.Image = My.Resources.Broken
            Case ContextState.Changing
               pictureBoxCcowStatus.Image = My.Resources.Changing
            Case ContextState.Linked
               pictureBoxCcowStatus.Image = My.Resources.Linked
         End Select
      End Sub

      Private Sub Application_Idle(ByVal sender As Object, ByVal e As EventArgs)
      End Sub

      Private Sub aboutToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
         Dim dlgAbout As AboutDialog = New AboutDialog(Messager.Caption)

         dlgAbout.ShowDialog(Me)
      End Sub

      Private Sub exitToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
         Close()
      End Sub

      Private Sub buttonAbout_Click(ByVal sender As Object, ByVal e As EventArgs) Handles buttonAbout.Click
         Dim dlgAbout As AboutDialog = New AboutDialog(Messager.Caption)

         dlgAbout.ShowDialog(Me)
      End Sub

      Private Sub LeaveContext()
         _Context.Leave()
      End Sub

      Private Sub MainForm_FormClosing(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles MyBase.FormClosing
         If Not _Context Is Nothing Then
            If _Context.Joined Then
               Dim dlgProgress As ProgressInfoDialog = New ProgressInfoDialog(Me)

               dlgProgress.Title = "Leaving Common Context"
               dlgProgress.Description = "Attempting to leave common context"
               Try
                  dlgProgress.ShowDialog(New MethodInvoker(AddressOf LeaveContext))
               Catch ex As Exception
                  Messager.ShowError(Me, ex)
                  e.Cancel = True
               End Try
            End If
         End If
      End Sub

      Private Sub buttonLogon_Click(ByVal sender As Object, ByVal e As EventArgs) Handles buttonLogon.Click
         Try
            _Context.SecureBind()
            If _Context.CanPerformAuthenticateAction Then
               Dim success As Boolean = PerformLogin()

               If (Not String.IsNullOrEmpty(_LaunchArgs)) AndAlso _LoggedIn AndAlso success Then
                  LaunchParticipant()
                  _LaunchArgs = String.Empty
               End If
            Else
               Messager.ShowInformation(Me, _ApplicationName & " can't perform authentication." & vbCrLf & "Launch the context manager and add this application to the" & vbCrLf & "Authenticate-User Action subject")
            End If
         Catch exception As Exception
            ' 
            ' If this fails the application cannot perform a secure bind.  Therefore they will not
            ' be able to perform the logon action.
            '
            If TypeOf exception Is COMException Then
               '
               ' Check to see if the Context Manager server has terminated.
               '
               If exception.Message.Contains("The RPC server is unavailable") Then
                  Messager.Show(Me, "Context Manager Server has terminated.  Application can no longer access the context.  The application will restart and try to rejoin the context.", MessageBoxIcon.Exclamation, MessageBoxButtons.OK)
                  Close()
                  CCOWUtils.Restart()
               Else
                  Messager.ShowError(Nothing, exception)
               End If
            Else
               Messager.ShowError(Nothing, exception)
            End If
         End Try
      End Sub

      Private Sub LaunchParticipant()
         Dim participantFileName As String = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "VBCCOWClientParticipationDemo_Original.exe")

         If (Not File.Exists(participantFileName)) Then
            participantFileName = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "VBCCOWClientParticipationDemo.exe")
         End If

         If File.Exists(participantFileName) Then
            Dim process As Process = New Process()

            process.StartInfo.FileName = participantFileName
            process.StartInfo.Arguments = _LaunchArgs
            process.Start()
         Else
            Messager.ShowError(Nothing, "Could not find the VBCCOWClientParticipationDemo")
         End If
      End Sub

      Private Function PerformLogin() As Boolean
         If (Not _LoggedIn) Then
            Dim user As String = String.Empty
            Dim name As String = String.Empty

            If _Context.Login(_Suffix, user, name) Then
               Dim s As Subject = New Subject("User")
               Dim item As ContextItem = New ContextItem("User.id.logon." & _Suffix, user)

               Try
                  s.Items.Add(item)
                  If _Context.SetSecure(s) Then
                     _LoggedIn = True
                     buttonLogon.Text = "Logout"
                     labelCurrentUser.Text = user
                     labelFullName.Text = name
                  End If
               Catch e As Exception
                  Messager.ShowError(Me, e)
                  Return False
               End Try
            End If
         Else
            Dim userSubject As Subject = New Subject("User")
            Dim item As ContextItem = New ContextItem("User.Id.logon." & _Suffix, String.Empty)

            userSubject.Items.Add(item)
            _Context.Set(userSubject)
            buttonLogon.Text = "Logon"
            labelCurrentUser.Text = String.Empty
            labelFullName.Text = String.Empty
            _LoggedIn = False
         End If
         Return True
      End Function

      Private Sub AutoLogOn()
         buttonLogon_Click(buttonLogon, EventArgs.Empty)
      End Sub

      Private Sub MainForm_Shown(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Shown
         '
         ' Automatically display the login dialog if we were lauched from a participant application
         '
         If (Not String.IsNullOrEmpty(_LaunchArgs)) Then
            BeginInvoke(New MethodInvoker(AddressOf AutoLogOn))
         End If
      End Sub
   End Class
End Namespace

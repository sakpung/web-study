' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************

Imports System.Collections.Generic
Imports System.Diagnostics
Imports System.Drawing
Imports System.IO
Imports System.Net
Imports System.Windows.Forms
Imports Leadtools
Imports Leadtools.Demos
Imports System

Namespace CCOWDashboard
   Partial Public Class MainForm : Inherits Form
      Private _Scenarios As List(Of Scenario)
      Private _ActiveScenario As ActiveScenario
      Private _Participant1 As Process
      Private _Participant2 As Process
      Private _Participant3 As Process

      Public Class Program
         Private Sub New()
         End Sub
         ''' <summary>
         ''' The main entry point for the application.
         ''' </summary>
         <STAThread()> _
         Shared Sub Main(args As String())
            If Not Support.SetLicense() Then
               Return
            End If

            If RasterSupport.IsLocked(RasterSupportType.Ccow) Then
               MessageBox.Show("CCOW Support is locked!  Application will exit.", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
               Return
            End If

            Application.EnableVisualStyles()
            Application.SetCompatibleTextRenderingDefault(False)
            Application.Run(New MainForm())
         End Sub
      End Class

      Public Sub New()
         InitializeComponent()
#If LEADTOOLS_V19_OR_LATER Then
         AddHandler Me.linkLabelWebWarning.LinkClicked, AddressOf Me.LinkLabel_LinkClicked
         AddHandler Me.buttonLaunchWebParticipant1.Click, AddressOf Me.buttonLaunchWebParticipant1_Click
         AddHandler Me.buttonLaunchWebParticipant2.Click, AddressOf Me.buttonLaunchWebParticipant2_Click

         CheckWebComponents()
#Else
         Me.Height = 377
#End If
      End Sub

      Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles Me.Load
         Messager.Caption = "CCOW Dashboard"
         Text = "VB " + Messager.Caption
         AddHandler Application.Idle, AddressOf Application_Idle
         _ActiveScenario = ActiveScenario.Load()
         InitializeScenarios()
      End Sub

      Private Sub Application_Idle(sender As Object, e As EventArgs)
         buttonLaunchParticipant1.Enabled = CanLaunchParticipant(_Participant1)
         buttonLaunchParticipant2.Enabled = CanLaunchParticipant(_Participant2)
         buttonLaunchParticipant3.Enabled = CanLaunchParticipant(_Participant3)
      End Sub

      Private Sub InitializeScenarios()
         _Scenarios = Scenario.LoadScenarios()
         For Each scenario__1 As Scenario In _Scenarios
            Dim i As Integer = comboBoxScenarios.Items.Add(scenario__1)
            Dim a As New FileInfo(_ActiveScenario.Filename.ToLower())
            Dim b As New FileInfo(scenario__1.Filename.ToLower())

            If a.Name.ToLower() = b.Name.ToLower() Then
               comboBoxScenarios.SelectedIndex = i
            End If
         Next
      End Sub

      Private Function CanLaunchParticipant(process As Process) As Boolean
         If process Is Nothing OrElse (process IsNot Nothing AndAlso process.HasExited) Then
            Return True
         End If

         Return False
      End Function

      Private Sub exitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles exitToolStripMenuItem.Click
         Close()
      End Sub

      Private Sub LaunchParticipant(args As String, ByRef process As Process, color As Color, applicationIndex As Integer)
         Dim participantFileName As String = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "VBCCOWClientParticipationDemo.exe")

         If Not File.Exists(participantFileName) Then
            participantFileName = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "VBCCOWClientParticipationDemo.exe")
         End If

         If File.Exists(participantFileName) Then
            If process Is Nothing Then
               process = New Process()
               process.EnableRaisingEvents = True
               AddHandler process.Exited, AddressOf Process_Exited
               process.StartInfo.FileName = participantFileName
            End If

            process.StartInfo.Arguments = (Convert.ToString("/dashboard ") & args) + " /color=" + ColorTranslator.ToHtml(color) + " /index=" + applicationIndex.ToString()
            process.Start()
         Else
            Messager.ShowError(Nothing, "Could not find the VBCCOWClientParticipationDemo")
         End If
      End Sub

      Private Sub Process_Exited(sender As Object, e As EventArgs)
         Dim process As Process = TryCast(sender, Process)

         If process IsNot Nothing Then
            If process Is _Participant1 Then
               Invoke(New MethodInvoker(Function() InlineAssignHelper(buttonLaunchParticipant1.Enabled, True)))
            ElseIf process Is _Participant2 Then
               Invoke(New MethodInvoker(Function() InlineAssignHelper(buttonLaunchParticipant2.Enabled, True)))
            ElseIf process Is _Participant3 Then
               Invoke(New MethodInvoker(Function() InlineAssignHelper(buttonLaunchParticipant3.Enabled, True)))
            End If
         End If
      End Sub

      Private Sub comboBoxScenarios_SelectedIndexChanged(sender As Object, e As EventArgs) Handles comboBoxScenarios.SelectedIndexChanged
         Dim scenario As Scenario = TryCast(comboBoxScenarios.SelectedItem, Scenario)

         If scenario IsNot Nothing Then
            _ActiveScenario.Filename = scenario.Filename
            _ActiveScenario.Scenario = scenario
            _ActiveScenario.Save()
         End If
      End Sub

      Private Sub buttonLaunchParticipant1_Click(sender As Object, e As EventArgs) Handles buttonLaunchParticipant1.Click
         LaunchParticipant(If(checkBoxSSO1.Checked, "/link=user", String.Empty), _Participant1, panelParticipant1.BackColor, 0)
      End Sub

      Private Sub buttonLaunchParticipant2_Click(sender As Object, e As EventArgs) Handles buttonLaunchParticipant2.Click
         LaunchParticipant(If(checkBoxSSO2.Checked, "/link=user", String.Empty), _Participant2, panelParticipant2.BackColor, 1)
      End Sub

      Private Sub buttonLaunchParticipant3_Click(sender As Object, e As EventArgs) Handles buttonLaunchParticipant3.Click
         LaunchParticipant(If(checkBoxSSO3.Checked, "/link=user", String.Empty), _Participant3, panelParticipant3.BackColor, 2)
      End Sub

      Private Sub aboutToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles aboutToolStripMenuItem1.Click
         Dim dlgAbout As New AboutDialog(Messager.Caption)

         dlgAbout.ShowDialog(Me)
      End Sub

      Private Sub showDetailedHelpToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles showDetailedHelpToolStripMenuItem.Click
         Dim bHelpFound As Boolean = True
         Try
            DemosGlobal.LaunchHelp2("CcowDashboardDemo")
         Catch generatedExceptionName As Exception
            bHelpFound = False
         Finally
            If Not bHelpFound Then
               Messager.ShowWarning(Me, "Help failed to load.")
            End If
         End Try

      End Sub

#If LEADTOOLS_V19_OR_LATER Then
#If LTV20_CONFIG Then
      Private Const LT_VER As String = "20"
#ElseIf LTV19_CONFIG Then
      Private Const LT_VER As String = "19"
#End If

      Private _webDemoUrl As String = String.Format("http://localhost/CCOW{0}/CCOWWebClientParticipationDemo/index.html", LT_VER)

      Private Sub EnableWebUIElements(enable As Boolean)
         Me.buttonLaunchWebParticipant1.Enabled = enable
         Me.buttonLaunchWebParticipant2.Enabled = enable
         Me.checkBoxWebSSO1.Enabled = enable
         Me.checkBoxWebSSO2.Enabled = enable
      End Sub

      Private Sub CheckWebComponents()
         Dim isAdmin As Boolean = DemosGlobal.IsAdmin()
         Dim isWebHosted As Boolean = WebDemoHosted()
         If isAdmin AndAlso isWebHosted Then
            StartCcowServer()
            Me.linkLabelWebWarning.Visible = False
            EnableWebUIElements(True)
         Else
            If Not isAdmin Then
               Me.labelWebWarning.Visible = True
            ElseIf Not isWebHosted Then
               Me.linkLabelWebWarning.Visible = True
            End If

            EnableWebUIElements(False)
         End If
      End Sub

      Private Sub LaunchWebParticipant(userLink As Boolean, color As Color, applicationIndex As Integer)
         Process.Start(String.Format("{0}?dashboard={1}&userlink={1}&color={2}&index={3}", _webDemoUrl, userLink, ColorTranslator.ToHtml(color), applicationIndex))
      End Sub

      Private Sub buttonLaunchWebParticipant1_Click(sender As Object, e As EventArgs)
         LaunchWebParticipant(checkBoxWebSSO1.Checked, panelWebParticipant1.BackColor, 1)
      End Sub

      Private Sub buttonLaunchWebParticipant2_Click(sender As Object, e As EventArgs)
         LaunchWebParticipant(checkBoxWebSSO2.Checked, panelWebParticipant2.BackColor, 2)
      End Sub

      Private Function WebDemoHosted() As Boolean
         Try
            ' First check if it is reachable through HTTP
            Dim request As HttpWebRequest = TryCast(WebRequest.Create(_webDemoUrl), HttpWebRequest)
            request.Timeout = 5000

            Using response As HttpWebResponse = TryCast(request.GetResponse(), HttpWebResponse)
               Using reader As New StreamReader(response.GetResponseStream())
                  Dim str As String = reader.ReadToEnd()
               End Using
            End Using

            Return True
         Catch
            Return False
         End Try
      End Function

      Private Sub LinkLabel_LinkClicked(sender As Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)
         Try
            Dim serviceManagerPath As String = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "LeadtoolsServicesHostManager_Original.exe")
            Process.Start(serviceManagerPath, "/group:""LEADTOOLS CCOW Web Participation Demo (Version 19)""").WaitForExit()
            CheckWebComponents()
         Catch ex As Exception
            Messager.ShowError(Me, ex)
         End Try
      End Sub

      Private Sub StartCcowServer()
         Dim serverPath As String = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "VBCcowServerDemo.exe")
         Try
            If Process.GetProcessesByName("VBCcowServerDemo").Length = 0 Then
               Process.Start(serverPath)
            End If
         Catch ex As Exception
            Messager.ShowError(Me, ex)
         End Try
      End Sub
      Private Shared Function InlineAssignHelper(Of T)(ByRef target As T, value As T) As T
         target = value
         Return value
      End Function
#End If
   End Class
End Namespace

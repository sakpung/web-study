' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System
Imports System.Collections.Generic
Imports System.Windows.Forms
Imports Microsoft.VisualBasic.ApplicationServices
Imports System.Security.Principal
Imports System.Diagnostics
Imports System.IO
Imports System.Threading
Imports Microsoft.VisualBasic

Imports Leadtools
Imports Leadtools.Demos



Namespace Leadtools.Dicom.Server.Manager
   Friend Class Program
      ''' <summary>
      ''' The main entry point for the application.
      ''' </summary>
      Private Sub New()
      End Sub

      Private Shared privateBaseDir As String
      Public Shared Property BaseDir() As String
         Get
            Return privateBaseDir
         End Get
         Set(ByVal value As String)
            privateBaseDir = value
         End Set
      End Property

      <STAThread()> _
      Shared Function Main(ByVal args() As String) As Integer
         Dim m As Mutex
         If DemosGlobal.MustRestartElevated() Then
            DemosGlobal.TryRestartElevated(args)
            Return 0
         End If
         If Not Support.SetLicense() Then
            Return 0
         End If

#If (Not FOR_DOTNET4) Then
         Dim dotNet35Installed As Boolean = DemosGlobal.IsDotNet35Installed()
         If (Not dotNet35Installed) Then
            Return 0
         End If
#End If

         Dim ok As Boolean

#If LEADTOOLS_V175_OR_LATER Then
         m = New Mutex(True, "LEADTOOLS_V175_OR_LATER", ok)

         If (Not ok) Then
            Return 1
         End If
#Else
		   Dim controller As SingleInstanceController
#End If
         Application.EnableVisualStyles()
         Application.SetCompatibleTextRenderingDefault(False)



#If LEADTOOLS_V175_OR_LATER Then
         If RasterSupport.IsLocked(RasterSupportType.DicomCommunication) Then
#Else
			If RasterSupport.IsLocked(RasterSupportType.MedicalNet) Then
#End If
            MessageBox.Show("Support for LEADTOOLS PACS Module is locked!" & Constants.vbLf & "Server Manager cannot run!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return -1
         End If

         BaseDir = Path.GetFullPath(GetWorkingDirectory()).ToLower()
         DicomEngine.Startup()
         DicomNet.Startup()
#If (Not LEADTOOLS_V175_OR_LATER) Then
			controller = New SingleInstanceController()
			controller.Run(Environment.GetCommandLineArgs())
#Else
         Try
            Application.Run(New MainForm())
         Catch ex As FileNotFoundException
            MessageBox.Show("File not found exception." & Constants.vbLf + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
         Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
         End Try
#End If
         DicomNet.Shutdown()
         DicomEngine.Shutdown()
#If LEADTOOLS_V175_OR_LATER Then
         GC.KeepAlive(m)
#End If
         Return 0
      End Function

      Public Shared Function GetWorkingDirectory() As String
         Dim executableName As String = Application.ExecutablePath
         Dim executableFileInfo As New FileInfo(executableName)
         Return executableFileInfo.DirectoryName.ToLower()
      End Function

   End Class

   Public Class SingleInstanceController : Inherits WindowsFormsApplicationBase
      Public Sub New()
         IsSingleInstance = True

         AddHandler StartupNextInstance, AddressOf SingleInstanceController_StartupNextInstance
      End Sub

      Private Sub SingleInstanceController_StartupNextInstance(ByVal sender As Object, ByVal e As StartupNextInstanceEventArgs)
         If MainForm.WindowState = FormWindowState.Minimized Then
            TryCast(MainForm, MainForm).ShowFromTaskBar()
         End If

         MainForm.Activate()
      End Sub

      Protected Overrides Sub OnCreateMainForm()
         MainForm = New MainForm()
      End Sub
   End Class
End Namespace

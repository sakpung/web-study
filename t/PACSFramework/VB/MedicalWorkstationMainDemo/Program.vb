' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports Microsoft.VisualBasic
Imports System
Imports System.Configuration
Imports System.Diagnostics
Imports System.Drawing
Imports System.IO
Imports System.Security.Principal
Imports System.Windows.Forms
Imports Leadtools.Dicom
Imports Leadtools.Medical.DataAccessLayer.Configuration
Imports Leadtools.Medical.Workstation.UI
Imports Leadtools.Demos.Workstation.Configuration
Imports Leadtools.Medical.Winforms
Imports Leadtools.Medical.UserManagementDataAccessLayer


Namespace Leadtools.Demos.Workstation
   Friend NotInheritable Class Program
	  ''' <summary>
	  ''' The main entry point for the application.
	  ''' </summary>
	  Private Sub New()
	  End Sub
	  <STAThread> _
	  Shared Sub Main(ByVal args() As String)
		 If DemosGlobal.MustRestartElevated() Then
			DemosGlobal.TryRestartElevated(args)
			Return
		 End If

		 Application.EnableVisualStyles()
		 Application.SetCompatibleTextRenderingDefault(False)


		 Try
            If Not Support.SetLicense() Then
               Return
            End If

            Leadtools.Dicom.DicomEngine.Startup()
            Leadtools.Dicom.DicomNet.Startup()

            AddHandler Application.ThreadException, AddressOf Application_ThreadException

            WorkstationShellController.Instance.Run()
         Catch exception As Exception
            Dim detailedError As ViewErrorDetailsDialog


            detailedError = New ViewErrorDetailsDialog(exception)

            detailedError.ShowDialog()
		 Finally
			Leadtools.Dicom.DicomEngine.Shutdown ()
			Leadtools.Dicom.DicomNet.Shutdown ()
		 End Try
	  End Sub

	  Private Shared Sub Application_ThreadException(ByVal sender As Object, ByVal e As System.Threading.ThreadExceptionEventArgs)
		 Dim detailedError As ViewErrorDetailsDialog


		 detailedError = New ViewErrorDetailsDialog (e.Exception)

		 detailedError.ShowDialog ()

	  End Sub

	  Private Shared Function NeedUAC() As Boolean
		 Dim system As OperatingSystem = Environment.OSVersion

		 If system.Platform = PlatformID.Win32NT AndAlso system.Version.Major >= 6 Then
			Return True
		 End If

		 Return False
	  End Function

	  Private Shared Function IsAdmin() As Boolean
		 Dim id As WindowsIdentity = WindowsIdentity.GetCurrent()
		 Dim p As New WindowsPrincipal(id)

		 Return p.IsInRole(WindowsBuiltInRole.Administrator)
	  End Function

	  Private Shared Sub RestartElevated()
		 Dim startInfo As New ProcessStartInfo()

		 startInfo.UseShellExecute = True
		 startInfo.WorkingDirectory = Environment.CurrentDirectory
		 startInfo.FileName = Application.ExecutablePath
		 startInfo.Verb = "runas"
		 Try
			Dim p As Process = Process.Start(startInfo)
		 Catch e1 As System.ComponentModel.Win32Exception
			Return
		 End Try
	  End Sub

   End Class

	  Public NotInheritable Class WorkstationUtils
		 Private Sub New()
		 End Sub
		 Public Shared Function IsDataAccessSettingsValid(ByVal sectionName As String) As Boolean
			ConfigurationManager.RefreshSection (sectionName)

			Dim section As DataAccessSettings = TryCast(ConfigurationManager.GetSection (sectionName), DataAccessSettings)


			If Nothing IsNot section Then
			   Dim connectionSettings As ConnectionStringSettings


			   ConfigurationManager.RefreshSection ("connectionStrings")
			   connectionSettings = ConfigurationManager.ConnectionStrings (section.ConnectionName)

			   If Nothing IsNot connectionSettings Then
				  Return True
			   End If
			End If

			Return False
		 End Function

		 Public Shared Function GetApplicationIcon() As Icon
			Try
			   Dim iconPath As String


			   iconPath = Path.Combine (Application.StartupPath, "app.ico")

			   If File.Exists (iconPath) Then
				  Return New Icon (iconPath)
			   Else
               Return Resources.MedAddon
            End If
         Catch e1 As Exception
            Return Resources.MedAddon
			End Try
		 End Function

		 Public Shared Function GetAssociationReasonMessage(ByVal reason As DicomAssociateRejectReasonType) As String
         If reason = DicomAssociateRejectReasonType.Calling Then
            Return "Calling AE Title Not Recognized"
         End If

         If reason = DicomAssociateRejectReasonType.Called Then
            Return "Called AE Title Not Recognized"
         End If

			Return String.Empty
		 End Function
	  End Class
End Namespace

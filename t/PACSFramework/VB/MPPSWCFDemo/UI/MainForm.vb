' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Linq
Imports System.Text
Imports System.Windows.Forms
Imports MPPSWCFDemo.UI.Pages
Imports Leadtools.Demos
Imports MPPSWCFDemo.Broker
Imports System.Runtime.InteropServices
Imports System.Security.Permissions
Imports System.IO
Imports Leadtools.DicomDemos

Namespace MPPSWCFDemo.UI
   Public Partial Class MainForm : Inherits Form
	  Private Shared _Mpps As WCFPPSInformation
	  Private _ConfigFile As String = String.Empty

	  Public Shared Property Mpps() As WCFPPSInformation
		 Get
			 Return _Mpps
		 End Get
		 Set
			 _Mpps = Value
		 End Set
	  End Property

	  <DllImport("shfolder.dll", CharSet := CharSet.Auto)> _
	  Private Shared Function SHGetFolderPath(ByVal hwndOwner As IntPtr, ByVal nFolder As Integer, ByVal hToken As IntPtr, ByVal dwFlags As Integer, ByVal lpszPath As StringBuilder) As Integer
	  End Function

	  Private Const CommonDocumentsFolder As Integer = &H2e

	  Public Shared Function GetFolderPath() As String
		 Dim lpszPath As StringBuilder = New StringBuilder(260)
		 ' CommonDocuments is the folder than any Vista user (including 'guest') has read/write access
		 SHGetFolderPath(IntPtr.Zero, CInt(CommonDocumentsFolder), IntPtr.Zero, 0, lpszPath)
		 Dim path As String = lpszPath.ToString()
		 CType(New FileIOPermission(FileIOPermissionAccess.PathDiscovery, path), FileIOPermission).Demand()
		 Return path
	  End Function

	  Public Sub New()
		 InitializeComponent()
	  End Sub

	  Private Sub MainForm_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
         Messager.Caption = "VB.Net MPPS WCF Demo"
		 Text = Messager.Caption

		 Try
			_ConfigFile = DicomDemoSettingsManager.GetSettingsFilename("WCFClient")
			If (Not File.Exists(_ConfigFile)) Then
			   DicomDemoSettingsManager.RunPacsConfigDemo()
			   If (Not File.Exists(_ConfigFile)) Then
				  Messager.Show(Me, "No configuration file." & Constants.vbLf & "Application cannot continue without configuration", MessageBoxIcon.Warning, MessageBoxButtons.OK)
				  Close()
			   End If
			End If

			SetServiceClient()
			wizardSheet.Pages.Add(New IntroductionPage())
			wizardSheet.Pages.Add(New MPPSInstancePage())
			wizardSheet.Pages.Add(New SequencesPage())
			wizardSheet.Pages.Add(New UnscheduledPatientPage())
			wizardSheet.SetActivePage(0)
		 Catch ex As Exception
			Messager.ShowError(Me, ex.Message & Constants.vbCrLf & Constants.vbCrLf & "Application will exit.")
			Application.Exit()
		 End Try
	  End Sub

	  Public Sub Channel_Faulted(ByVal sender As Object, ByVal e As EventArgs)
		 Dim client As BrokerServiceClient = TryCast(wizardSheet.Tag, BrokerServiceClient)

		 RemoveHandler client.InnerChannel.Faulted, AddressOf Channel_Faulted
		 client.Abort()
		 SetServiceClient()
	  End Sub

	  Private Sub SetServiceClient()
		 Dim client As CustomBrokerClient = New CustomBrokerClient(_ConfigFile)

		 AddHandler client.InnerChannel.Faulted, AddressOf Channel_Faulted
		 wizardSheet.Tag = client
	  End Sub

	  Private Sub wizardSheet_About(ByVal sender As Object, ByVal e As EventArgs) Handles wizardSheet.About
		 Dim dlgAbout As AboutDialog = New AboutDialog("MPPS WCF")

		 dlgAbout.ShowDialog(Me)
	  End Sub

	  Private Sub wizardSheet_WizardFinished(ByVal sender As Object, ByVal e As CancelEventArgs) Handles wizardSheet.WizardFinished
		 Dim result As DialogResult = Messager.Show(Me, "The wizard has completed editing the modality performed procedure step.  " & "Would you like edit another modality performed procedure step?  Clicking No " & "will exit the application.", MessageBoxIcon.Information, MessageBoxButtons.YesNo)

		 If result = DialogResult.Yes Then
            e.Cancel = True
            wizardSheet.Reset()
			wizardSheet.SetActivePage(1)			
			Return
		 End If
	  End Sub
   End Class

   Public Class CustomBrokerClient : Inherits BrokerServiceClient
	  Private _ConfigFile As String

	  Public Sub New(ByVal configFile As String)
		  MyBase.New("WSHttpBinding_IBrokerService")
		 _ConfigFile = configFile
	  End Sub

	  Protected Overrides Function CreateChannel() As IBrokerService
		 Dim factory As CustomChannelFactory(Of IBrokerService) = New CustomChannelFactory(Of IBrokerService)("WSHttpBinding_IBrokerService", _ConfigFile)

		 Return factory.CreateChannel()
	  End Function
   End Class
End Namespace

' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Linq
Imports System.Text
Imports System.Windows.Forms
Imports Leadtools.Demos.Workstation.Customized
Imports Leadtools.Medical.Workstation.UI

Namespace Leadtools.Demos.Workstation.UI
   Partial Public Class MainForm : Inherits Form
      Public Sub New()
         InitializeComponent()
      End Sub

      <STAThread()> _
        Shared Sub Main(ByVal args() As String)
         Try
            Application.EnableVisualStyles()
            Application.SetCompatibleTextRenderingDefault(False)

            If Not Support.SetLicense() Then
               Return
            End If

            Leadtools.Dicom.DicomEngine.Startup()
            Leadtools.Dicom.DicomNet.Startup()

            AddHandler Application.ThreadException, New System.Threading.ThreadExceptionEventHandler(AddressOf Application_ThreadException)

            Dim workstationShell As WorkstationShellController = New WorkstationShellController()
            workstationShell.Run()
         Catch exception As Exception
            Dim detailedError As ViewErrorDetailsDialog


            detailedError = New ViewErrorDetailsDialog(exception)

            detailedError.ShowDialog()
         Finally
            Leadtools.Dicom.DicomEngine.Shutdown()
            Leadtools.Dicom.DicomNet.Shutdown()
         End Try
      End Sub

      Private Shared Sub Application_ThreadException(ByVal sender As Object, ByVal e As System.Threading.ThreadExceptionEventArgs)
         Dim detailedError As ViewErrorDetailsDialog


         detailedError = New ViewErrorDetailsDialog(e.Exception)

         detailedError.ShowDialog()

      End Sub
   End Class
End Namespace

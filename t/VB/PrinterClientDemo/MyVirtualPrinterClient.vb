' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports Microsoft.VisualBasic
Imports System
Imports System.Text
Imports System.Windows.Forms
Imports ManagedPrinterClientDemo
Imports System.Runtime.InteropServices
Imports Leadtools.Printer.Client

Namespace Client_ManagedDemo
   ' Managed client demo
   Public Class MyVirtualPrinterClient : Implements IVirtualPrinterClient
      Private mainFrm As MainForm

      Public Sub New()
      End Sub

      Private ReadOnly Property Is64() As Boolean
         Get
            Return IntPtr.Size = 8
         End Get
      End Property

      Private Function Startup(ByVal virtualPrinterName As String, ByVal initialData As Byte()) As Boolean Implements IVirtualPrinterClient.Startup
         If initialData Is Nothing OrElse initialData.Length = 0 Then
            Dim strTittle As String
            If (Is64) Then
               strTittle = "LEADTOOLS VB Printer Client Demo 64-bit"
            Else
               strTittle = "LEADTOOLS VB Printer Client Demo 32-bit"
            End If
            Dim strErrorMessage As String

            strErrorMessage = "Incorrect IIS Configuration - Couldn't read initialization data from the server." & Constants.vbLf + Constants.vbLf & _
                              "In order to use the LEADTOOLS Network Virtual Printer:" & Constants.vbLf & _
                              "  1. IIS should be installed on the server." & Constants.vbLf & _
                              "  2. IIS must be configured using the LEADTOOLS Printer Server IIS Configuration Demo on the server." & Constants.vbLf + Constants.vbLf & _
                              "Print job will be canceled."
            MessageBox.Show(Nothing, strErrorMessage, strTittle, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
         End If

            mainFrm = New MainForm(virtualPrinterName, initialData)
            Return True
      End Function

      Private Sub Shutdown(ByVal virtualPrinterName As String) Implements IVirtualPrinterClient.Shutdown
      End Sub

      Private Function PrintJob(ByVal printJobData As PrintJobData) As Boolean Implements IVirtualPrinterClient.PrintJob
         Dim dlgRes As DialogResult = mainFrm.ShowDialog()

         If dlgRes <> DialogResult.OK Then
            Return False
         End If
         Dim enc As Encoding = Encoding.Unicode

         printJobData.UserData = enc.GetBytes(mainFrm.GetData())

         ' Or false to abort the printing
         Return True
      End Function
   End Class
End Namespace

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
Imports System.Text
Imports System.Windows.Forms
Imports Leadtools.Printer

Namespace PrintToPACSDemo
   Public Partial Class FrmProgress : Inherits Form
	  #Region "Constructor..."
	  Public Sub New()
		 InitializeComponent()
	  End Sub

	  Public Sub New(ByVal printerName As String, ByVal printer As Printer)
		 InitializeComponent()
		 _printer = printer
		 _lblPrinter.Text = "Printer " & printerName & " Is Printing Now"
	  End Sub
	  #End Region

	  #Region "Fields..."
	  Private _printer As Printer
	  Private _jobId As Integer
	  #End Region

	  #Region "Events..."
	  Private Sub _btnCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnCancel.Click
		 Try
			_printer.CancelPrintedJob(_jobId)
		 Catch
		 End Try
	  End Sub
	  #End Region

	  #Region "Methods..."
	  Public Sub SetProgressState(ByVal pageNo As Integer, ByVal jobId As Integer)
		 Try
			_jobId = jobId
			_lblPage.Text = "Page No: " & pageNo.ToString() & " of job ID " & jobId.ToString()
		 Catch Ex As Exception
   MessageBox.Show(Ex.ToString(), "LEADTOOLS VB Print to PACS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
		 End Try
	  End Sub
	  #End Region
   End Class
End Namespace

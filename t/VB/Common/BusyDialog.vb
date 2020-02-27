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

Namespace FormsDemo
   Public Partial Class BusyDialog : Inherits Form
	  Public Sub New()
		 InitializeComponent()
	  End Sub

	  Public ReadOnly Property Label1() As Label
		 Get
			 Return _lblLabel1
		 End Get
	  End Property

	  Public ReadOnly Property Label2() As Label
		 Get
			 Return _lblLabel2
		 End Get
	  End Property

	  Public ReadOnly Property FormName() As Label
		 Get
			 Return _lblFormName
		 End Get
	  End Property

	  Public ReadOnly Property Progress() As ProgressBar
		 Get
			 Return _progressBar
		 End Get
	  End Property

	  Public ReadOnly Property Ok() As Button
		 Get
			 Return _btnOk
		 End Get
	  End Property

	  Public ReadOnly Property Cancel() As Button
		 Get
			 Return _btnCancel
		 End Get
	  End Property

	  Private Sub _btnOk_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnOk.Click
		 Visible = False
		 DialogResult = System.Windows.Forms.DialogResult.OK
	  End Sub

	  Private Sub _btnCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnCancel.Click
		 Visible = False
		 DialogResult = DialogResult.Cancel
	  End Sub
   End Class
End Namespace

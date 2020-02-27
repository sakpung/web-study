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
   Public Partial Class NewElement : Inherits Form
	  Public Sub New(ByVal title As String, ByVal nameLabelText As String)
		 InitializeComponent()
		 _txtName.Text = ""
		 Me.Text = title
		 _lblName.Text = nameLabelText
	  End Sub

	  Private Sub _btnOk_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnOk.Click
		 If _txtName.Text <> "" Then
			Me.DialogResult = System.Windows.Forms.DialogResult.OK
		 End If
	  End Sub

	  Private Sub _btnCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnCancel.Click
		 Me.DialogResult = DialogResult.Cancel
	  End Sub

	  Public Property ElementName() As String
		 Get
			 Return _txtName.Text
		 End Get
		 Set
			 _txtName.Text = Value
		 End Set
	  End Property

	  Private Sub NewElement_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load

	  End Sub
   End Class
End Namespace

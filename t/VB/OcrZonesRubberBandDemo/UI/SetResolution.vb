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

Namespace OcrZonesRubberBandDemo
   Public Partial Class SetResolution : Inherits Form
	  Public _xRes As Integer
	  Public _yRes As Integer

	  Public Sub New()
		 InitializeComponent()
	  End Sub

	  Private Sub SetResolution_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
		 _txtXRes.Text = _xRes.ToString()
		 _txtYRes.Text = _yRes.ToString()
	  End Sub

	  Private Sub _btnOk_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnOk.Click
		 Try
			_xRes = Convert.ToInt32(_txtXRes.Text)
			_yRes = Convert.ToInt32(_txtYRes.Text)
			If (_xRes >= 10 AndAlso _xRes <= 1000) AndAlso (_yRes >= 10 AndAlso _yRes <= 1000) Then
               DialogResult = System.Windows.Forms.DialogResult.OK
			Else
			   Messager.ShowError(Me, "Please enter an integer between 10 and 1000")
			End If
		 Catch ex As Exception
			Messager.ShowError(Me, ex.Message)
		 End Try
	  End Sub

	  Private Sub _txtXRes_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _txtXRes.TextChanged
		 CheckOkButton()
	  End Sub

	  Private Sub _txtYRes_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _txtYRes.TextChanged
		 CheckOkButton()
	  End Sub

	  Private Sub CheckOkButton()
		 Try
			If _txtXRes.Text <> "" AndAlso _txtYRes.Text <> "" Then
			   _btnOk.Enabled = True
			Else
			   _btnOk.Enabled = False
			End If
		 Catch
		 End Try
	  End Sub

	  Private Sub _txtXRes_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles _txtXRes.KeyPress
		 If (Not Char.IsControl(e.KeyChar)) AndAlso (Not Char.IsNumber(e.KeyChar)) Then
			e.Handled = True
		 End If
	  End Sub

	  Private Sub _txtYRes_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles _txtYRes.KeyPress
		 If (Not Char.IsControl(e.KeyChar)) AndAlso (Not Char.IsNumber(e.KeyChar)) Then
			e.Handled = True
		 End If
	  End Sub
   End Class
End Namespace

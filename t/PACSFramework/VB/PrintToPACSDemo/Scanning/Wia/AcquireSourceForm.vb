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

Namespace PrintToPACSDemo
   Public Partial Class AcquireSourceForm : Inherits Form
	  Public Sub New()
		 InitializeComponent()
	  End Sub

	  Private Sub AcquireSourceForm_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
		 _lbAcquireSources.Items.Add("Feeder")
		 _lbAcquireSources.Items.Add("Flatbed")
		 _lbAcquireSources.SelectedIndex = 0
	  End Sub

	  Private Sub _lbAcquireSources_DoubleClick(ByVal sender As Object, ByVal e As EventArgs) Handles _lbAcquireSources.DoubleClick
		 If _lbAcquireSources.SelectedIndex = 0 Then ' Feeder selected
			FrmMain._acquireFromFeeder = True
		 Else
			FrmMain._acquireFromFeeder = False
		 End If

		 DialogResult = DialogResult.OK
	  End Sub

	  Private Sub _btnOK_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnOK.Click
		 If _lbAcquireSources.SelectedIndex = 0 Then ' Feeder selected
			FrmMain._acquireFromFeeder = True
		 Else
			FrmMain._acquireFromFeeder = False
		 End If

		 DialogResult = DialogResult.OK
	  End Sub
   End Class
End Namespace

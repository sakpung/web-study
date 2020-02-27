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

Namespace MedicalViewerLayoutDemo
   Public Partial Class DefaultImagesDialog : Inherits Form
	  Public Sub New()
		 InitializeComponent()
	  End Sub

	  Private Sub okButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles okButton.Click
		 If loadRadio.Checked Then
			 Me.DialogResult = DialogResult.Yes
		 Else
			 Me.DialogResult = DialogResult.No
		 End If
		 Me.Close()
	  End Sub
   End Class
End Namespace

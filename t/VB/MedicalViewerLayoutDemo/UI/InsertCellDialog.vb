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
Imports Leadtools
Imports Leadtools.Codecs
Imports Leadtools.WinForms.CommonDialogs.File
Imports Leadtools.MedicalViewer

Namespace MedicalViewerLayoutDemo
	Public Partial Class InsertCellDialog : Inherits Form
		'private RasterCodecs _codecs;

		Private _Position As MedicalViewerLayoutPosition

		Public ReadOnly Property Position() As MedicalViewerLayoutPosition
			Get
				Return _Position
			End Get
		End Property

		Public Sub New(ByVal owner As MainForm)
			InitializeComponent()
		End Sub

		Private Sub okButton_Click(ByVal sender As Object, ByVal e As EventArgs)
			DialogResult = System.Windows.Forms.DialogResult.OK
		End Sub

		Private Sub InsertCellDialog_FormClosing(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles MyBase.FormClosing
			If DialogResult = System.Windows.Forms.DialogResult.OK Then
			   _Position = New MedicalViewerLayoutPosition(Convert.ToSingle(ltx.Value), Convert.ToSingle(lty.Value),Convert.ToSingle(rbx.Value), Convert.ToSingle(rby.Value))
			End If
		End Sub

		Private Sub InsertCellDialog_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load

		End Sub

		Private Sub InsertCellDialog_Shown(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Shown
			ltx.Focus()
		End Sub
	End Class
End Namespace

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

Namespace VBLEADUniversalViewer
   ' This dialog is designed to give the user the ability to change the // loading resolution for document files (DOC, DOCx, PDF, etc.)
   Partial Public Class LoadingResolutionDialog : Inherits Form
      Private _LoadingResolution As Integer

      Private _selecteResdIndex As Integer

      Public Property LoadingResolution() As Integer
         Get
            Return _LoadingResolution
         End Get
         Set(value As Integer)
            _LoadingResolution = Value
         End Set
      End Property

      Public Property SelecteResdIndex() As Integer
         Get
            Return _selecteResdIndex
         End Get
         Set(value As Integer)
            _selecteResdIndex = Value
         End Set
      End Property

      Public Sub New()
         InitializeComponent()
         _LoadingResolution = 150
         cmbResolutions.SelectedIndex = 3
      End Sub

      Private Sub LoadingResolutionDialog_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
         txtInfo.Text = "When you load big document files (PDF, Doc, Docx, etc.), or big number of pages, you might require sufficient free memory on your machine to load them smoothly. If you are facing any delay or memory consuming issues, try to reduce the loading resolution to smaller values (72, 96, 100, etc)."
         cmbResolutions.SelectedIndex = SelecteResdIndex
      End Sub

      Private Sub chkChangeResolution_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles chkChangeResolution.CheckedChanged
         cmbResolutions.Enabled = chkChangeResolution.Checked
      End Sub

      Private Sub btnOK_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnOK.Click
         _LoadingResolution = Integer.Parse(cmbResolutions.Text)

         Me.Hide()
      End Sub

      Private Sub cmbResolutions_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cmbResolutions.SelectedIndexChanged
         SelecteResdIndex = cmbResolutions.SelectedIndex
      End Sub

      Private Sub LoadingResolutionDialog_FormClosing(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles Me.FormClosing
         SelecteResdIndex = cmbResolutions.SelectedIndex
      End Sub
   End Class
End Namespace

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

Namespace DicomDemo
   Partial Class ReasonDialog : Inherits Form
      Private _Reason As String = String.Empty

      Public Property Reason() As String
         Get
            Return _Reason
         End Get
         Set(ByVal value As String)
            _Reason = value
         End Set
      End Property

      Public Sub New(ByVal title As String)
         InitializeComponent()
         Text = title
      End Sub

      Private Sub textBoxReason_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles textBoxReason.TextChanged
         OkButton.Enabled = textBoxReason.Text.Length > 0
      End Sub

      Private Sub ReasonDialog_FormClosing(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles Me.FormClosing
         If DialogResult = System.Windows.Forms.DialogResult.OK Then
            _Reason = textBoxReason.Text
         End If
      End Sub
   End Class
End Namespace

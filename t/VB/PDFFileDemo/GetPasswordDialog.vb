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

Namespace PDFFileDemo
   Partial Public Class GetPasswordDialog : Inherits Form
      Private _password As String
      Public ReadOnly Property Password() As String
         Get
            Return _password
         End Get
      End Property

      Public Sub New()
         InitializeComponent()
      End Sub

      Private Sub _showCharactersCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _showCharactersCheckBox.CheckedChanged
         If _showCharactersCheckBox.Checked Then
            _passwordTextBox.PasswordChar = ChrW(0)
         Else
            _passwordTextBox.PasswordChar = "*"c
         End If
      End Sub

      Private Sub _okButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _okButton.Click
         _password = _passwordTextBox.Text
      End Sub
   End Class
End Namespace

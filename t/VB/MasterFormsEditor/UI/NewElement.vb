' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms

Partial Public Class NewElement : Inherits Form
   Private _invalidValues As String()

   Public Sub New(ByVal title As String, ByVal nameLabelText As String, ByVal invalidValues As String())
      InitializeComponent()
      _txtName.Text = ""
      Me.Text = title
      _lblName.Text = nameLabelText
      _invalidValues = invalidValues
   End Sub

   Private Sub _btnOk_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnOk.Click
      If String.IsNullOrEmpty(_txtName.Text) Then
         MessageBox.Show("You must specify a valid value", "Error")
         Return
      End If

      For Each invalidName As String In _invalidValues
         If invalidName.ToUpper() = _txtName.Text.Trim().ToUpper() Then
            MessageBox.Show("That value already exist", "Error")
            Return
         End If
      Next invalidName

      Me.DialogResult = System.Windows.Forms.DialogResult.OK
   End Sub

   Private Sub _btnCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnCancel.Click
      Me.DialogResult = DialogResult.Cancel
   End Sub

   Public Property ElementName() As String
      Get
         Return _txtName.Text
      End Get
      Set(value As String)
         _txtName.Text = value
      End Set
   End Property
End Class

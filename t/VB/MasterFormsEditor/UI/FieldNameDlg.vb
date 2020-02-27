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

Partial Public Class FieldNameDlg : Inherits Form
   Public Sub New()
      InitializeComponent()
   End Sub

   Public Sub New(ByVal fieldName As String)
      InitializeComponent()
      Me._txtBox_FieldName.Text = fieldName
   End Sub

   Public ReadOnly Property TextFieldName() As String
      Get
         Return Me._txtBox_FieldName.Text
      End Get
   End Property
   Private Sub _btn_ok_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btn_ok.Click
      If _txtBox_FieldName.Text = "" Then
         MessageBox.Show("FieldName Should Not Be Empty")
      Else
         Me.DialogResult = System.Windows.Forms.DialogResult.OK
      End If
   End Sub
End Class

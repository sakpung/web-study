' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************

Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports System

Partial Public Class Result
   Inherits Form
   Private _result As String
   Public Sub New(result__1 As String)
      InitializeComponent()
      _result = result__1
   End Sub

   Private Sub Result_Load(sender As Object, e As EventArgs) Handles Me.Load
      _lblResult.Text = _result
   End Sub

   Private Sub _btnOk_Click(sender As Object, e As EventArgs) Handles _btnOk.Click
      Close()
   End Sub
End Class

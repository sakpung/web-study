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

Namespace MainDemo
   Partial Public Class LambdaConnectednessDialog : Inherits Form
      Public Lambda As Integer

      Public Sub New()
         InitializeComponent()
      End Sub

      Private Sub _btnOk_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnOk.Click
         Lambda = CInt(_numLambda.Value)
      End Sub

      Private Sub LambdaConnectednessDialog_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load

      End Sub
   End Class
End Namespace

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

Imports Leadtools.ImageProcessing.Core
Imports System

Partial Public Class LambdaConnectednessDialog
   Inherits Form
   Private _lambda As Integer

   Public Lambda As Integer
   Public Sub New()
      InitializeComponent()
   End Sub

   Private Sub LambdaConnectednessDialog_Load(sender As Object, e As EventArgs) Handles Me.Load
      _lambda = 950

      Lambda = _lambda
      _numLambda.Value = Lambda
   End Sub

   Private Sub _btnOk_Click(sender As Object, e As EventArgs) Handles _btnOk.Click
      Lambda = CInt(_numLambda.Value)
      _lambda = Lambda
   End Sub
End Class

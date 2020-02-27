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

Imports Leadtools
Imports Leadtools.ImageProcessing.Core
Imports System

Partial Public Class SRADFilterDialog
   Inherits Form
   Public _lambda As Integer
   Public _iterations As Integer

   Public Lambda As Integer
   Public Iterations As Integer

   Public Sub New()
      InitializeComponent()
   End Sub

   Private Sub SRADFilterDialog_Load(sender As Object, e As EventArgs) Handles Me.Load
      Dim cmd As New SRADAnisotropicDiffusionCommand()
      _lambda = cmd.Lambda
      _iterations = cmd.Iterations


      Lambda = _lambda
      Iterations = _iterations

      _numIterations.Value = Iterations
      _numLambda.Value = Lambda
   End Sub

   Private Sub _btnOK_Click(sender As Object, e As EventArgs) Handles _btnOK.Click
      Lambda = CInt(_numLambda.Value)
      Iterations = CInt(_numIterations.Value)

      _lambda = Lambda
      _iterations = Iterations
   End Sub
End Class

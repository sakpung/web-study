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

Partial Public Class TDAFilterDialog
   Inherits Form
   Private Shared _flux As TADAnisotropicDiffusionFlags

   Private Shared _lambda As Integer
   Private Shared _kappa As Integer
   Private Shared _iterations As Integer
   Public Lambda As Integer
   Public Kappa As Integer
   Public Iterations As Integer
   Public Flux As TADAnisotropicDiffusionFlags

   Public Sub New()
      InitializeComponent()
   End Sub

   Private Sub TDAFilter_Load(sender As Object, e As EventArgs) Handles Me.Load

      Dim cmd As New TADAnisotropicDiffusionCommand()
      _flux = TADAnisotropicDiffusionFlags.ExponentialFlux

      _lambda = cmd.Lambda
      _kappa = cmd.Kappa
      _iterations = cmd.Iterations

      Flux = _flux

      Lambda = _lambda
      Kappa = _kappa
      Iterations = _iterations

      _numLambda.Value = Lambda
      _numKappa.Value = Kappa
      _numIterations.Value = Iterations
      Select Case Flux
         Case TADAnisotropicDiffusionFlags.ExponentialFlux
            _cbFlux.SelectedIndex = 0
            Exit Select
         Case TADAnisotropicDiffusionFlags.QuadraticFlux
            _cbFlux.SelectedIndex = 1
            Exit Select
      End Select
   End Sub

   Private Sub _btnOK_Click(sender As Object, e As EventArgs) Handles _btnOK.Click
      _iterations = CInt(_numIterations.Value)
      _kappa = CInt(_numKappa.Value)
      _lambda = CInt(_numLambda.Value)

      Select Case _cbFlux.SelectedIndex
         Case 0
            _flux = TADAnisotropicDiffusionFlags.ExponentialFlux
            Exit Select
         Case 1
            _flux = TADAnisotropicDiffusionFlags.QuadraticFlux
            Exit Select
      End Select

      Iterations = _iterations
      Lambda = _lambda
      Kappa = _kappa
      Flux = _flux
   End Sub
End Class

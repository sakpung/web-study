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

Imports Leadtools
Imports Leadtools.ImageProcessing.Core


Namespace MainDemo
   Partial Public Class TADAnisotropicDialog : Inherits Form
      Public Flux As TADAnisotropicDiffusionFlags
      Public Lambda As Integer
      Public Kappa As Integer
      Public Iterations As Integer

      Public Sub New()
         InitializeComponent()
         _cbFlux.SelectedIndex = 0
      End Sub

      Private Sub TADAnisotropicDialog_FormClosing(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles Me.FormClosing
         Lambda = CInt(_numLambda.Value)
         Kappa = CInt(_numKappa.Value)
         Iterations = CInt(_numIterations.Value)

         If (_cbFlux.SelectedIndex = 0) Then
            Flux = TADAnisotropicDiffusionFlags.ExponentialFlux
         Else
            Flux = TADAnisotropicDiffusionFlags.QuadraticFlux
         End If
      End Sub

   End Class
End Namespace

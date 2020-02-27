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
   Partial Public Class SRADAnisotropicDialog : Inherits Form
      Public Lambda As Integer
      Public Iterations As Integer

      Public Sub New()
         InitializeComponent()
      End Sub

      Private Sub SRADAnisotropicDialog_FormClosing(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles Me.FormClosing
         Lambda = CInt(_numLambda.Value)
         Iterations = CInt(_numIterations.Value)
      End Sub

   End Class
End Namespace

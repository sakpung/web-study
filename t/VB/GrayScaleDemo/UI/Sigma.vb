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

Partial Public Class SigmaDialog
   Inherits Form
   Private Shared _dimension As Integer
   Private Shared _outline As Boolean
   Private Shared _threshold As Single
   Private Shared _sigma As Integer

   Public ReadOnly Property Dimension() As Integer
      Get
         Return _dimension
      End Get
   End Property

   Public ReadOnly Property Sigma() As Integer
      Get
         Return SigmaDialog._sigma
      End Get
   End Property

   Public ReadOnly Property Threshold() As Single
      Get
         Return SigmaDialog._threshold
      End Get
   End Property

   Public ReadOnly Property Outline() As Boolean
      Get
         Return SigmaDialog._outline
      End Get
   End Property

   Public Sub New()
      InitializeComponent()
   End Sub

   Private Sub Sigma_Load(sender As Object, e As EventArgs) Handles Me.Load
      Dim cmd As New SigmaCommand()
      _dimension = cmd.Dimension
      _outline = cmd.Outline
      _threshold = cmd.Threshold
      _sigma = cmd.Sigma

      _numDimension.Value = _dimension
      _numThreshold.Value = CDec(_threshold)
      _numSigma.Value = _sigma
      _cbOutline.Checked = _outline
   End Sub

   Private Sub _btnOk_Click(sender As Object, e As EventArgs) Handles _btnOk.Click
      _dimension = CInt(_numDimension.Value)
      _threshold = CSng(_numThreshold.Value)
      _sigma = CInt(_numSigma.Value)
      _outline = _cbOutline.Checked
   End Sub
End Class

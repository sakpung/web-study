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

Partial Public Class AnisotropicDiffusionDialog
   Inherits Form
   Private Shared _iterations As Integer
   Private Shared _smoothing As Integer
   Private Shared _timeStep As Single
   Private Shared _minVariation As Single
   Private Shared _maxVariation As Single
   Private Shared _edgeHeight As Single
   Private Shared _update As Integer

   Public Iterations As Integer
   Public Smoothing As Integer
   Public TimeStep As Single
   Public MinVariation As Single
   Public MaxVariation As Single
   Public EdgeHeight As Single
   Public nUpdate As Integer

   Public Sub New()
      InitializeComponent()
   End Sub

   Private Sub AnisotropicDiffusionDialog_Load(sender As Object, e As EventArgs) Handles Me.Load
      Dim cmd As New AnisotropicDiffusionCommand()
      _iterations = cmd.Iterations
      _smoothing = cmd.Smoothing
      _timeStep = cmd.TimeStep
      _minVariation = cmd.MinVariation
      _maxVariation = cmd.MaxVariation
      _edgeHeight = cmd.EdgeHeight
      _update = cmd.Update

      Try
         Iterations = _iterations
         Smoothing = _smoothing
         TimeStep = _timeStep * 100
         MinVariation = _minVariation * 100
         MaxVariation = _maxVariation * 100
         EdgeHeight = _edgeHeight * 100
         nUpdate = _update

         _numIterations.Value = Iterations
         _numSmoothing.Value = Smoothing
         _numTimeStep.Value = CDec(TimeStep)
         _numMinVariation.Value = CDec(MinVariation)
         _numMaxVariation.Value = CDec(MaxVariation)
         _numEdgeHeight.Value = CDec(EdgeHeight)
         _numUpdate.Value = nUpdate
      Catch generatedExceptionName As Exception
         'ex
      End Try
   End Sub

   Private Sub _btnOk_Click(sender As Object, e As EventArgs) Handles _btnOk.Click
      Iterations = CInt(_numIterations.Value)
      Smoothing = CInt(_numSmoothing.Value)
      TimeStep = CSng(_numTimeStep.Value) / 100
      MinVariation = CSng(_numMinVariation.Value) / 100
      MaxVariation = CSng(_numMaxVariation.Value) / 100
      EdgeHeight = CSng(_numEdgeHeight.Value) / 100
      nUpdate = CInt(_numUpdate.Value)

      _iterations = Iterations
      _smoothing = Smoothing
      _timeStep = TimeStep
      _minVariation = MinVariation
      _maxVariation = MaxVariation
      _edgeHeight = EdgeHeight
      _update = nUpdate
   End Sub

   Private Sub _numIterations_ValueChanged(sender As Object, e As EventArgs) Handles _numIterations.ValueChanged
      If _numUpdate.Value > _numIterations.Value Then
         _numUpdate.Value = _numIterations.Value
      End If

      _numUpdate.Maximum = _numIterations.Value
   End Sub


End Class

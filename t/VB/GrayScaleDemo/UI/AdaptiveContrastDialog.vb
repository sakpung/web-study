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

Imports GrayScaleDemo.Leadtools.Demos
Imports Leadtools.ImageProcessing.Color
Imports System

Partial Public Class AdaptiveContrastDialog
   Inherits Form
   Private Shared _amount As Integer
   Private Shared _dimension As Integer
   Private Shared _initialAdaptiveContrastType As AdaptiveContrastCommandType

   Public Amount As Integer
   Public Dimentions As Integer
   Public AdaptiveContrastType As AdaptiveContrastCommandType

   Public Sub New()
      InitializeComponent()
   End Sub

   Private Sub _btnOk_Click(sender As Object, e As EventArgs) Handles _btnOk.Click
      Amount = CInt(_numAmount.Value)
      Dimentions = CInt(_numDimension.Value)

      Select Case _cmbAdaptiveType.SelectedIndex
         Case 0
            AdaptiveContrastType = AdaptiveContrastCommandType.Exponential
            Exit Select
         Case 1
            AdaptiveContrastType = AdaptiveContrastCommandType.Linear
            Exit Select
      End Select
      _amount = Amount
      _dimension = Dimentions
      _initialAdaptiveContrastType = AdaptiveContrastType
   End Sub

   Private Sub AdaptiveContrastDialog_Load(sender As Object, e As EventArgs) Handles Me.Load
      Dim command As New AdaptiveContrastCommand()
      _amount = command.Amount
      _dimension = command.Dimension
      _initialAdaptiveContrastType = command.Type


      Amount = _amount
      Dimentions = _dimension
      AdaptiveContrastType = _initialAdaptiveContrastType

      Try
         _numAmount.Value = Amount
         _numDimension.Value = Dimentions

         Select Case CInt(AdaptiveContrastType)
            Case &H1
               _cmbAdaptiveType.SelectedIndex = 0
               Exit Select
            Case &H2
               _cmbAdaptiveType.SelectedIndex = 1
               Exit Select

         End Select
      Catch generatedExceptionName As Exception

         'ex
      End Try
   End Sub
End Class

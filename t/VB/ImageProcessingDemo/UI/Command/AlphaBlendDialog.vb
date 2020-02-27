' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms

Imports Leadtools
Imports Leadtools.ImageProcessing.Effects


Namespace ImageProcessingDemo
   'This dialog is used to allow the user to specify values which
   'will be used for the AlphaBlendCommand
   Partial Public Class AlphaBlendDialog : Inherits Form
      Private _AlphaBlendCommand As AlphaBlendCommand
      Private _X1, _Y1, _Width, _Height, _X2, _Y2 As Integer

      Public Sub New(ByVal TempImage As RasterImage)
         InitializeComponent()
         _AlphaBlendCommand = New AlphaBlendCommand()
         _X1 = CType(TempImage.Width / 8, Integer)
         _Y1 = CType(TempImage.Height / 8, Integer)
         _Width = TempImage.Width
         _Height = TempImage.Height
         _X2 = 0
         _Y2 = 0

         _numOpacity.Minimum = 0
         _tbOpacity.Minimum = 0
         If (TempImage.BitsPerPixel = 64) OrElse (TempImage.BitsPerPixel = 48) OrElse (TempImage.BitsPerPixel = 16) Then
            _numOpacity.Maximum = 65535
            _tbOpacity.Maximum = 65535
         ElseIf TempImage.BitsPerPixel = 12 Then
            _numOpacity.Maximum = 4095
            _tbOpacity.Maximum = 4095
         Else
            _numOpacity.Maximum = 255
            _tbOpacity.Maximum = 255
         End If

         _numOpacity.Value = 128
         _tbOpacity.Value = 128
         'Set command default values
         InitializeUI()
      End Sub

      Public Property AlphaBlendCommand() As AlphaBlendCommand
         Get
            'Update command values
            UpdateCommand()
            Return _AlphaBlendCommand
         End Get
         Set(ByVal value As AlphaBlendCommand)
            _AlphaBlendCommand = value
            InitializeUI()
         End Set
      End Property
      Private Sub InitializeUI()
         _numX1.Maximum = _Width
         _numX1.Value = _X1

         _numY1.Maximum = _Height
         _numY1.Value = _Y1

         _numWidth.Maximum = _Width
         _numWidth.Value = CInt(_Width / 2)

         _numHeight.Maximum = _Height
         _numHeight.Value = CInt(_Height / 2)

         _numX2.Maximum = _Width
         _numX2.Value = _X2

         _numY2.Maximum = _Height
         _numY2.Value = _Y2

         _numOpacity.Value = 128
         _tbOpacity.Value = 128
      End Sub

      Private Sub UpdateCommand()
         _X1 = Convert.ToInt32(_numX1.Value)
         _Y1 = Convert.ToInt32(_numY1.Value)
         _Width = Convert.ToInt32(_numWidth.Value)
         _Height = Convert.ToInt32(_numHeight.Value)
         _X2 = Convert.ToInt32(_numX2.Value)
         _Y2 = Convert.ToInt32(_numY2.Value)

         _AlphaBlendCommand.DestinationRectangle = New LeadRect(_X1, _Y1, _Width, _Height)
         _AlphaBlendCommand.SourcePoint = New LeadPoint(_X2, _Y2)
         _AlphaBlendCommand.Opacity = Convert.ToInt32(_numOpacity.Value)
      End Sub

      Private Sub _numX1_Leave(ByVal sender As Object, ByVal e As EventArgs) Handles _numX1.Leave
         DialogUtilities.NumericOnLeave(sender)
      End Sub

      Private Sub _numWidth_Leave(ByVal sender As Object, ByVal e As EventArgs) Handles _numWidth.Leave
         DialogUtilities.NumericOnLeave(sender)
      End Sub

      Private Sub _numY1_Leave(ByVal sender As Object, ByVal e As EventArgs) Handles _numY1.Leave
         DialogUtilities.NumericOnLeave(sender)
      End Sub

      Private Sub _numHeight_Leave(ByVal sender As Object, ByVal e As EventArgs) Handles _numHeight.Leave
         DialogUtilities.NumericOnLeave(sender)
      End Sub

      Private Sub _numX2_Leave(ByVal sender As Object, ByVal e As EventArgs) Handles _numX2.Leave
         DialogUtilities.NumericOnLeave(sender)
      End Sub

      Private Sub _numY2_Leave(ByVal sender As Object, ByVal e As EventArgs) Handles _numY2.Leave
         DialogUtilities.NumericOnLeave(sender)
      End Sub

      Private Sub _numOpacity_Leave(ByVal sender As Object, ByVal e As EventArgs) Handles _numOpacity.Leave
         DialogUtilities.NumericOnLeave(sender)
      End Sub

      Private Sub _tbOpacity_Scroll(ByVal sender As Object, ByVal e As EventArgs) Handles _tbOpacity.Scroll
         _numOpacity.Value = _tbOpacity.Value
      End Sub

      Private Sub _numOpacity_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _numOpacity.ValueChanged
         _tbOpacity.Value = Convert.ToInt32(_numOpacity.Value)
      End Sub

      Private Sub _btnOk_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnOk.Click
         UpdateCommand()
         Me.DialogResult = DialogResult.OK
         Me.Close()
      End Sub

      Private Sub _btnCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnCancel.Click
         Me.DialogResult = DialogResult.Cancel
      End Sub
   End Class
End Namespace

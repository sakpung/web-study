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
   'will be used for the EdgeDetectStatisticalCommand

   Partial Public Class EdgeDetectStatisticalDialog : Inherits Form
      Private _EdgeDetectStatisticalCommand As EdgeDetectStatisticalCommand
      Private _Dimension, _Threshold As Integer
      Private _EdgeColor, _BackGroundColor As RasterColor

      Public Sub New()
         InitializeComponent()
         _EdgeDetectStatisticalCommand = New EdgeDetectStatisticalCommand()

         'Set command default values
         InitializeUI()

      End Sub

      Public Property EdgeDetectStatisticalCommand() As EdgeDetectStatisticalCommand
         Get
            'Update command values
            UpdateCommand()
            Return _EdgeDetectStatisticalCommand
         End Get
         Set(ByVal value As EdgeDetectStatisticalCommand)
            _EdgeDetectStatisticalCommand = value
            InitializeUI()
         End Set
      End Property

      Private Sub InitializeUI()
         _Dimension = 1
         _Threshold = 128

         _BackGroundColor = Leadtools.Demos.Converters.FromGdiPlusColor(Color.Black)
         _EdgeColor = Leadtools.Demos.Converters.FromGdiPlusColor(Color.White)

         _numDimension.Value = _Dimension
         _numThreshold.Value = _Threshold

         _lblBackGroundColor.BackColor = Color.Black
         _lblEdgeColor.BackColor = Color.White
      End Sub
      Private Sub UpdateCommand()
         _Dimension = Convert.ToInt32(_numDimension.Value)
         _Threshold = Convert.ToInt32(_numThreshold.Value)

         _BackGroundColor = Leadtools.Demos.Converters.FromGdiPlusColor(_lblBackGroundColor.BackColor)
         _EdgeColor = Leadtools.Demos.Converters.FromGdiPlusColor(_lblEdgeColor.BackColor)

         _EdgeDetectStatisticalCommand.BackGroundColor = _BackGroundColor
         _EdgeDetectStatisticalCommand.EdgeColor = _EdgeColor
         _EdgeDetectStatisticalCommand.Dimension = _Dimension
         _EdgeDetectStatisticalCommand.Threshold = _Threshold
      End Sub
      Private Sub _numDimension_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _numDimension.ValueChanged
         _tbDimension.Value = Convert.ToInt32(_numDimension.Value)
      End Sub

      Private Sub _numThreshold_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _numThreshold.ValueChanged
         _tbThreshold.Value = Convert.ToInt32(_numThreshold.Value)
      End Sub

      Private Sub _numDimension_Leave(ByVal sender As Object, ByVal e As EventArgs) Handles _numDimension.Leave
         DialogUtilities.NumericOnLeave(sender)
      End Sub

      Private Sub _numThreshold_Leave(ByVal sender As Object, ByVal e As EventArgs) Handles _numThreshold.Leave
         DialogUtilities.NumericOnLeave(sender)
      End Sub

      Private Sub _tbDimension_Scroll(ByVal sender As Object, ByVal e As EventArgs) Handles _tbDimension.Scroll
         _numDimension.Value = _tbDimension.Value
      End Sub

      Private Sub _tbThreshold_Scroll(ByVal sender As Object, ByVal e As EventArgs) Handles _tbThreshold.Scroll
         _numThreshold.Value = _tbThreshold.Value
      End Sub

      Private Sub _BtnEdgeColor_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _BtnEdgeColor.Click
         Dim ColorDlg As ColorDialog = New ColorDialog()
         If ColorDlg.ShowDialog(Me) = DialogResult.OK Then
            _lblEdgeColor.BackColor = ColorDlg.Color
         End If
      End Sub

      Private Sub _BtnBackGroundColor_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _BtnBackGroundColor.Click
         Dim ColorDlg As ColorDialog = New ColorDialog()
         If ColorDlg.ShowDialog(Me) = DialogResult.OK Then
            _lblBackGroundColor.BackColor = ColorDlg.Color
         End If
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

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
Imports Leadtools.ImageProcessing.Color

Namespace ImageProcessingDemo
   'This dialog is used to allow the user to specify values which
   'will be used for the LocalHistogramEqualizeCommand

   Partial Public Class LocalHistogramEqualizeDialog : Inherits Form
      Private _LocalHistogramEqualizeCommand As LocalHistogramEqualizeCommand
      Private _MaxWidth, _MaxHeight As Integer

      Public Sub New(ByVal TempImage As RasterImage)
         InitializeComponent()
         _LocalHistogramEqualizeCommand = New LocalHistogramEqualizeCommand()
         _MaxWidth = TempImage.Width
         _MaxHeight = TempImage.Height

         'Set command default values
         InitializeUI()
      End Sub

      Public Property LocalHistogramEqualizeCommand() As LocalHistogramEqualizeCommand
         Get
            'Update command values
            UpdateCommand()
            Return _LocalHistogramEqualizeCommand
         End Get
         Set(ByVal value As LocalHistogramEqualizeCommand)
            _LocalHistogramEqualizeCommand = value
            InitializeUI()
         End Set
      End Property

      Private Sub InitializeUI()
         Dim names As String()
         names = System.Enum.GetNames(GetType(HistogramEqualizeType))
         For Each name As String In names
            If name <> "None" Then
               _cmbColorSpace.Items.Add(name)
            End If
         Next name
         _cmbColorSpace.SelectedIndex = 0

         _numWidth.Maximum = _MaxWidth
         _tbWidth.Maximum = _MaxWidth
         _numWidth.Value = _MaxWidth
         _tbWidth.Value = _MaxWidth


         _numHeight.Maximum = _MaxHeight
         _tbHeight.Maximum = _MaxHeight
         _numHeight.Value = _MaxHeight
         _tbHeight.Value = _MaxHeight


         _numWidthExtension.Maximum = _MaxWidth
         _tbWidthExtension.Maximum = _MaxWidth

         _numHeightExtension.Maximum = _MaxHeight
         _tbHeightExtension.Maximum = _MaxHeight
      End Sub

      Private Sub UpdateCommand()

         _LocalHistogramEqualizeCommand.Width = Convert.ToInt32(_numWidth.Value)
         _LocalHistogramEqualizeCommand.Height = Convert.ToInt32(_numHeight.Value)
         _LocalHistogramEqualizeCommand.WidthExtension = Convert.ToInt32(_numWidthExtension.Value)
         _LocalHistogramEqualizeCommand.HeightExtension = Convert.ToInt32(_numHeightExtension.Value)
         _LocalHistogramEqualizeCommand.Smooth = Convert.ToInt32(_numSmooth.Value)
         _LocalHistogramEqualizeCommand.Type = TranslateType()
      End Sub

      Public Function TranslateType() As HistogramEqualizeType
         Select Case _cmbColorSpace.SelectedIndex
            Case 0
               Return HistogramEqualizeType.Rgb
            Case 1
               Return HistogramEqualizeType.Yuv
            Case 2
               Return HistogramEqualizeType.Gray
            Case Else
               Return HistogramEqualizeType.Rgb
         End Select
      End Function

      Private Sub _numWidth_Leave(ByVal sender As Object, ByVal e As EventArgs) Handles _numWidth.Leave
         DialogUtilities.NumericOnLeave(sender)
      End Sub

      Private Sub _numHeight_Leave(ByVal sender As Object, ByVal e As EventArgs) Handles _numHeight.Leave
         DialogUtilities.NumericOnLeave(sender)
      End Sub

      Private Sub _numWidthExtension_Leave(ByVal sender As Object, ByVal e As EventArgs) Handles _numWidthExtension.Leave
         DialogUtilities.NumericOnLeave(sender)
      End Sub

      Private Sub _numHeightExtension_Leave(ByVal sender As Object, ByVal e As EventArgs) Handles _numHeightExtension.Leave
         DialogUtilities.NumericOnLeave(sender)
      End Sub

      Private Sub _numSmooth_Leave(ByVal sender As Object, ByVal e As EventArgs) Handles _numSmooth.Leave
         DialogUtilities.NumericOnLeave(sender)
      End Sub

      Private Sub _tbWidth_Scroll(ByVal sender As Object, ByVal e As EventArgs) Handles _tbWidth.Scroll
         _numWidth.Value = _tbWidth.Value
      End Sub

      Private Sub _tbHeight_Scroll(ByVal sender As Object, ByVal e As EventArgs) Handles _tbHeight.Scroll
         _numHeight.Value = _tbHeight.Value
      End Sub

      Private Sub _tbWidthExtension_Scroll(ByVal sender As Object, ByVal e As EventArgs) Handles _tbWidthExtension.Scroll
         _numWidthExtension.Value = _tbWidthExtension.Value
      End Sub

      Private Sub _tbHeightExtension_Scroll(ByVal sender As Object, ByVal e As EventArgs) Handles _tbHeightExtension.Scroll
         _numHeightExtension.Value = _tbHeightExtension.Value
      End Sub

      Private Sub _tbSmooth_Scroll(ByVal sender As Object, ByVal e As EventArgs) Handles _tbSmooth.Scroll
         _numSmooth.Value = _tbSmooth.Value
      End Sub

      Private Sub _numWidth_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _numWidth.ValueChanged
         _tbWidth.Value = Convert.ToInt32(_numWidth.Value)
      End Sub

      Private Sub _numHeight_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _numHeight.ValueChanged
         _tbHeight.Value = Convert.ToInt32(_numHeight.Value)
      End Sub

      Private Sub _numWidthExtension_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _numWidthExtension.ValueChanged
         _tbWidthExtension.Value = Convert.ToInt32(_numWidthExtension.Value)
      End Sub

      Private Sub _numHeightExtension_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _numHeightExtension.ValueChanged
         _tbHeightExtension.Value = Convert.ToInt32(_numHeightExtension.Value)
      End Sub

      Private Sub _numSmooth_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _numSmooth.ValueChanged
         _tbSmooth.Value = Convert.ToInt32(_numSmooth.Value)
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

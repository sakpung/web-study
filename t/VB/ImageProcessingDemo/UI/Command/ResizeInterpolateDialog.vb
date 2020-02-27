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
Imports Leadtools.ImageProcessing.Core

Namespace ImageProcessingDemo
   'This dialog is used to allow the user to specify values which
   'will be used for the ResizeInterpolateCommand

   Partial Public Class ResizeInterpolateDialog : Inherits Form
      Private _ResizeInterpolateCommand As ResizeInterpolateCommand
      Private RasImage As RasterImage

      Public ImageWidth As Integer
      Public ImageHeight As Integer

      Public Sub New()
         InitializeComponent()
         _ResizeInterpolateCommand = New ResizeInterpolateCommand()

         'Set command default values
         InitializeUI()
      End Sub

      Public Sub New(ByVal TempImage As RasterImage)
         InitializeComponent()
         _ResizeInterpolateCommand = New ResizeInterpolateCommand()
         RasImage = TempImage
         InitializeUI()
      End Sub

      Public Property ResizeInterpolatecommand() As ResizeInterpolateCommand
         Get
            'Update command values
            UpdateCommand()
            Return _ResizeInterpolateCommand
         End Get
         Set(ByVal value As ResizeInterpolateCommand)
            _ResizeInterpolateCommand = value
            InitializeUI()
         End Set
      End Property

      Private Sub InitializeUI()

         Dim names As String()
         names = System.Enum.GetNames(GetType(ResizeInterpolateCommandType))
         For Each name As String In names
            _cmbInterpolation.Items.Add(name)
         Next name
         _cmbInterpolation.SelectedIndex = _cmbInterpolation.Items.IndexOf(_ResizeInterpolateCommand.ResizeType.ToString())

         ImageWidth = RasImage.Width
         ImageHeight = RasImage.Height

         _numWidth.Value = ImageWidth
         _numHeight.Value = ImageHeight
      End Sub

      Private Sub UpdateCommand()
         ImageWidth = Convert.ToInt32(_numWidth.Value)
         ImageHeight = Convert.ToInt32(_numHeight.Value)

         _ResizeInterpolateCommand.Width = ImageWidth
         _ResizeInterpolateCommand.Height = ImageHeight
         _ResizeInterpolateCommand.ResizeType = TranslateDirection()
      End Sub


      Public Function TranslateDirection() As ResizeInterpolateCommandType
         Select Case _cmbInterpolation.SelectedIndex
            Case 0
               Return ResizeInterpolateCommandType.Normal
            Case 1
               Return ResizeInterpolateCommandType.Resample
            Case 2
               Return ResizeInterpolateCommandType.Bicubic
            Case 3
               Return ResizeInterpolateCommandType.Triangle
            Case 4
               Return ResizeInterpolateCommandType.Hermite
            Case 5
               Return ResizeInterpolateCommandType.Bell
            Case 6
               Return ResizeInterpolateCommandType.QuadraticBSpline
            Case 7
               Return ResizeInterpolateCommandType.CubicBSpline
            Case 8
               Return ResizeInterpolateCommandType.BoxFilter
            Case 9
               Return ResizeInterpolateCommandType.Lanczos
            Case 10
               Return ResizeInterpolateCommandType.Michell
            Case 11
               Return ResizeInterpolateCommandType.Cosine
            Case 12
               Return ResizeInterpolateCommandType.Catrom
            Case 13
               Return ResizeInterpolateCommandType.Quadratic
            Case 14
               Return ResizeInterpolateCommandType.CubicConvolution
            Case 15
               Return ResizeInterpolateCommandType.Bilinear
            Case 16
               Return ResizeInterpolateCommandType.Bresenham
            Case Else
               Return ResizeInterpolateCommandType.Normal
         End Select
      End Function

      Private Sub _btnOk_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnOk.Click
         UpdateCommand()
         Me.DialogResult = DialogResult.OK
         Me.Close()
      End Sub

      Private Sub _btnCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnCancel.Click
         InitializeUI()
         Me.DialogResult = DialogResult.Cancel
      End Sub
   End Class
End Namespace

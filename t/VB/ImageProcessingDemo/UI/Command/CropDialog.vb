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
Imports Leadtools.ImageProcessing

Namespace ImageProcessingDemo
   'This dialog is used to allow the user to specify values which
   'will be used for the CropCommand
   Partial Public Class CropDialog : Inherits Form
      Private _CropImage As RasterImage
      Private _CropCommand As CropCommand
      Private _X As Integer
      Private _Y As Integer
      Private _Width As Integer
      Private _Height As Integer

      Public Sub New()
         InitializeComponent()
         _CropCommand = New CropCommand()

         'Set command default values
         InitializeUI()

      End Sub
      Public Sub New(ByVal Cropcommand As CropCommand, ByVal CropImage As RasterImage)
         InitializeComponent()
         _CropCommand = Cropcommand
         _CropImage = CropImage
         InitializeUI()
      End Sub

      Public Property CropImage() As RasterImage
         Get
            Return _CropImage
         End Get
         Set(ByVal value As RasterImage)
            _CropImage = value
         End Set
      End Property

      Public Property Cropcommand() As CropCommand
         Get
            'Update command values
            UpdateCommand()
            Return _CropCommand
         End Get
         Set(ByVal value As CropCommand)
            _CropCommand = value
            InitializeUI()
         End Set
      End Property

      Private Sub InitializeUI()
         _X = CType(_CropImage.Width / 8, Integer)
         _Y = CType(_CropImage.Height / 8, Integer)
         _Width = _CropImage.Width - _X * 2
         _Height = _CropImage.Height - _Y * 2

         _numX.Maximum = _CropImage.Width
         _numX.Value = _X

         _numY.Maximum = _CropImage.Height
         _numY.Value = _Y

         _numWidth.Maximum = _CropImage.Width
         _numWidth.Value = _Width

         _numHeight.Maximum = _CropImage.Height
         _numHeight.Value = _Height
      End Sub
      Private Sub UpdateCommand()
         _X = Convert.ToInt32(_numX.Value)
         _Y = Convert.ToInt32(_numY.Value)
         _Width = Convert.ToInt32(_numWidth.Value)
         _Height = Convert.ToInt32(_numHeight.Value)

         _CropCommand.Rectangle = New LeadRect(_X, _Y, _Width, _Height)
      End Sub

      Private Sub _btnOk_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnOk.Click
         UpdateCommand()
         Me.DialogResult = DialogResult.OK
         Me.Close()
      End Sub

      Private Sub _btnCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnCancel.Click
         InitializeUI()
         Me.DialogResult = DialogResult.Cancel
      End Sub

      Private Sub _numX_Leave(ByVal sender As Object, ByVal e As EventArgs) Handles _numX.Leave
         DialogUtilities.NumericOnLeave(sender)
      End Sub

      Private Sub _numY_Leave(ByVal sender As Object, ByVal e As EventArgs) Handles _numY.Leave
         DialogUtilities.NumericOnLeave(sender)
      End Sub

      Private Sub _numWidth_Leave(ByVal sender As Object, ByVal e As EventArgs) Handles _numWidth.Leave
         DialogUtilities.NumericOnLeave(sender)
      End Sub

      Private Sub _numHeight_Leave(ByVal sender As Object, ByVal e As EventArgs) Handles _numHeight.Leave
         DialogUtilities.NumericOnLeave(sender)
      End Sub
   End Class
End Namespace

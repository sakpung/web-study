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
   'will be used for the FeatherAlphaBlendCommand

   Partial Public Class FeatherAlphaBlendDialog : Inherits Form
      Private _FeatherAlphaBlendCommand As FeatherAlphaBlendCommand
      Private _RectX, _RectY, _RectWidth, _RectHeight As Integer
      Private _XP1, _YP1, _XP2, _YP2 As Integer

      Public Sub New(ByVal TempSrcImage As RasterImage, ByVal TempMaskImage As RasterImage)
         InitializeComponent()
         _FeatherAlphaBlendCommand = New FeatherAlphaBlendCommand()

         'Set command default values
         _RectX = 0
         _RectY = 0
         _RectWidth = CInt(TempMaskImage.Width)
         _RectHeight = CInt(TempMaskImage.Height)

         _numX.Maximum = TempMaskImage.Width
         _numY.Maximum = TempMaskImage.Height
         _numWidth.Maximum = TempMaskImage.Width
         _numHeight.Maximum = TempMaskImage.Height


         _XP1 = CInt(TempSrcImage.Width / 2)
         _YP1 = CInt(TempSrcImage.Height / 2)

         _numX1.Maximum = TempMaskImage.Width
         _numY1.Maximum = TempMaskImage.Height

         _XP2 = 0
         _YP2 = 0

         _numX2.Maximum = TempMaskImage.Width
         _numY2.Maximum = TempMaskImage.Height

         InitializeUI()
      End Sub

      Public Property FeatherAlphaBlendCommand() As FeatherAlphaBlendCommand
         Get
            'Update command values
            UpdateCommand()
            Return _FeatherAlphaBlendCommand
         End Get
         Set(ByVal value As FeatherAlphaBlendCommand)
            _FeatherAlphaBlendCommand = value
            InitializeUI()
         End Set
      End Property


      Private Sub InitializeUI()
         _numX.Value = _RectX
         _numY.Value = _RectY
         _numWidth.Value = _RectWidth
         _numHeight.Value = _RectHeight

         _numX1.Value = _XP1
         _numY1.Value = _YP1

         _numX2.Value = _XP2
         _numY2.Value = _YP2
      End Sub

      Private Sub UpdateCommand()
         _RectX = Convert.ToInt32(_numX.Value)
         _RectY = Convert.ToInt32(_numY.Value)
         _RectWidth = Convert.ToInt32(_numWidth.Value)
         _RectHeight = Convert.ToInt32(_numHeight.Value)

         _XP1 = Convert.ToInt32(_numX1.Value)
         _YP1 = Convert.ToInt32(_numY1.Value)

         _XP2 = Convert.ToInt32(_numX2.Value)
         _YP2 = Convert.ToInt32(_numY2.Value)

         _FeatherAlphaBlendCommand.DestinationRectangle = New LeadRect(_RectX, _RectY, _RectWidth, _RectHeight)

         _FeatherAlphaBlendCommand.SourcePoint = New LeadPoint(_XP1, _YP1)

         _FeatherAlphaBlendCommand.MaskSourcePoint = New LeadPoint(_XP2, _YP2)
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

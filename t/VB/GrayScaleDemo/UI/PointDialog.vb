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
Imports System

Partial Public Class SetPixelColorDialog
   Inherits Form
   Private _ptX As Integer
   Private _ptY As Integer
   Private _level As Integer
   Private _maxX As Integer
   Private _maxY As Integer
   Private _minValue As Integer
   Private _maxValue As Integer
   Private _maxLevel As Integer
   Private _imgCat As ImageCategory
   Private _r As Byte, _g As Byte, _b As Byte

   Public ReadOnly Property B() As Byte
      Get
         Return _b
      End Get
   End Property

   Public ReadOnly Property G() As Byte
      Get
         Return _g
      End Get
   End Property

   Public ReadOnly Property R() As Byte
      Get
         Return _r
      End Get
   End Property


   Public Property MaxLevel() As Integer
      Get
         Return _maxLevel
      End Get
      Set(value As Integer)
         _maxLevel = value
      End Set
   End Property

   Public WriteOnly Property MaxY() As Integer
      Set(value As Integer)
         _maxY = value
      End Set
   End Property

   Public WriteOnly Property MaxX() As Integer
      Set(value As Integer)
         _maxX = value
      End Set
   End Property

   Public ReadOnly Property Level() As Integer
      Get
         Return _level
      End Get
   End Property

   Public ReadOnly Property PtX() As Integer
      Get
         Return _ptX
      End Get
   End Property

   Public ReadOnly Property PtY() As Integer
      Get
         Return _ptY
      End Get
   End Property

   Public Sub New(cat As ImageCategory, bpp As Integer)
      InitializeComponent()
      _imgCat = cat
      _maxValue = CInt(Math.Pow(2, bpp)) - 1
      _minValue = 0
   End Sub


   Private Sub PointDialog_Load(sender As Object, e As EventArgs) Handles Me.Load
      If _imgCat = ImageCategory.GrayScale_8_12_16_BPP Then
         _gbGray.Visible = True
         _gbRGB.Visible = False
         _numLevel.Maximum = _maxValue
         _numLevel.Minimum = _minValue
      ElseIf _imgCat = ImageCategory.ColoredImage Then
         _gbGray.Visible = False
         _gbRGB.Visible = True
      End If
      _numX.Maximum = _maxX
      _numY.Maximum = _maxY
   End Sub

   Private Sub _btnOk_Click(sender As Object, e As EventArgs) Handles _btnOk.Click
      If _imgCat = ImageCategory.GrayScale_8_12_16_BPP Then
         _level = CInt(_numLevel.Value)
      ElseIf _imgCat = ImageCategory.ColoredImage Then
         _r = CByte(_numR.Value)
         _g = CByte(_numG.Value)
         _b = CByte(_numB.Value)
      End If

      _ptX = CInt(_numX.Value)
      _ptY = CInt(_numY.Value)
   End Sub

   Private Sub _btnCancel_Click(sender As Object, e As EventArgs) Handles _btnCancel.Click
      Close()
   End Sub
End Class

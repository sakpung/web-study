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
Imports Leadtools
Imports System

Namespace AnimationDemo
   Partial Public Class ChooseColorDialog
      Inherits Form
      Private _image As RasterImage
      Private _itemSize As New Size(24, 12)
      Private _horzspace As Integer = 5
      Private _vertSpace As Integer = 5
      Private _startLocation As New Point(10, 15)
      Private _selectedColor As Color
      Private _enableChangeColor As Boolean = True

      Public Sub New(image As RasterImage, enableChangeColor As Boolean)
         InitializeComponent()
         _image = image
         _enableChangeColor = enableChangeColor
      End Sub

      Private Sub ColorDialog_Load(sender As Object, e As EventArgs) Handles Me.Load
         Dim colors As RasterColor() = _image.GetPalette()
         Dim colorsCount As Integer = colors.Length

         Dim vertSpace As Integer = 10
         Dim horzSpace As Integer = 20

         _gpBitmapColors.Height = CInt(If(colorsCount > 16, colorsCount / 16, 1)) * (_itemSize.Height + _vertSpace) + _startLocation.Y + _vertSpace
         _gpBitmapColors.Width = (_itemSize.Width + _horzspace) * 16

         'Adjust Current Color group box.
         _gpCurrentColor.Top = _gpBitmapColors.Bottom + vertSpace

         ' Adjust OK & Cancel buttons;
         _btnOK.Top = _gpCurrentColor.Top
         _btnOK.Left = _gpBitmapColors.Right - _btnOK.Width + _startLocation.X + _horzspace

         _btnCancel.Top = _btnOK.Bottom + vertSpace
         _btnCancel.Left = _btnOK.Left

         _gpCurrentColor.Width = _btnOK.Left - vertSpace - _gpCurrentColor.Left

         For i As Integer = 0 To colorsCount - 1
            Dim pt As Point = Point.Empty

            pt.X = i * (_itemSize.Width + _horzspace) Mod _gpBitmapColors.Width
            pt.Y = CInt(Math.Floor((i * (_itemSize.Width + _horzspace)) / _gpBitmapColors.Width)) * (_itemSize.Height + _vertSpace)

            pt.X += _startLocation.X
            pt.Y += _startLocation.Y

            Dim panel As Panel = CreateLabel(pt, Leadtools.Demos.Converters.ToGdiPlusColor(colors(i)))
            panel.Tag = i
            Me._gpBitmapColors.Controls.Add(panel)
         Next

         _gpBitmapColors.Width += _startLocation.X + _horzspace
         _gpRGB.Left = _gpCurrentColor.Right - _gpRGB.Width - horzSpace

         'Adjust Color Dialog form.
         Me.Size = New Size(_gpBitmapColors.Right + horzSpace, _gpCurrentColor.Bottom + vertSpace + 20)
      End Sub

      Private Function CreateLabel(location As Point, color As Color) As Panel
         Dim label As New Panel()
         label.Size = _itemSize
         label.BackColor = color
         label.Location = location
         label.Text = ""
         label.BorderStyle = BorderStyle.FixedSingle
         AddHandler label.Click, AddressOf label_Click
         AddHandler label.DoubleClick, AddressOf label_DoubleClick

         Return label
      End Function

      Private Sub label_DoubleClick(sender As Object, e As EventArgs)
         Dim color As New RasterColor()
         If Tools.ShowColorDialog(Me, color) = True Then
            Dim panel As Panel = TryCast(sender, Panel)
            If panel IsNot Nothing Then
               panel.BackColor = Leadtools.Demos.Converters.ToGdiPlusColor(color)
               panel1.BackColor = Leadtools.Demos.Converters.ToGdiPlusColor(color)
            End If
         End If
      End Sub

      Private Sub label_Click(sender As Object, e As EventArgs)
         panel1.BackColor = TryCast(sender, Panel).BackColor
         _txtRed.Text = panel1.BackColor.R.ToString()
         _txtGreen.Text = panel1.BackColor.G.ToString()
         _txtBlue.Text = panel1.BackColor.B.ToString()
      End Sub

      Private Sub _btnOK_Click(sender As Object, e As EventArgs) Handles _btnOK.Click
         SelectedColor = panel1.BackColor
         If _enableChangeColor Then
            Dim colors As RasterColor() = New RasterColor(Me._gpBitmapColors.Controls.Count - 1) {}
            For i As Integer = 0 To Me._gpBitmapColors.Controls.Count - 1
               colors(i) = Leadtools.Demos.Converters.FromGdiPlusColor(Me._gpBitmapColors.Controls(i).BackColor)
            Next

            _image.SetPalette(colors, 0, Me._gpBitmapColors.Controls.Count)
         End If
      End Sub

      Public Property SelectedColor() As Color
         Get
            Return _selectedColor
         End Get
         Set(value As Color)
            _selectedColor = panel1.BackColor
         End Set
      End Property
   End Class
End Namespace

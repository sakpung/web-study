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
Imports Leadtools.Demos

Namespace MainDemo
   Partial Public Class PaletteDialog : Inherits Form
      Public Palette As RasterColor()

      Private Const _gridWidth As Integer = 24
      Private Const _gridHeight As Integer = 24
      Private Const _minWidth As Integer = 200
      Private Const _minHeight As Integer = 200

      Public Sub New()
         InitializeComponent()
      End Sub

      Private Sub PaletteDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
         _lblPaletteInfo.Text = String.Format("Count: {0}", Palette.Length)

         Dim xGrids As Integer = 16
         Dim yGrids As Integer = Math.Max(1, CInt(Palette.Length / 16))

         SuspendLayout()

         _pnlPalette.Size = New Size(xGrids * _gridWidth + SystemInformation.Border3DSize.Width * 2, yGrids * _gridHeight + SystemInformation.Border3DSize.Height * 2)

         Dim d As Integer = _lblPaletteInfo.Top
         ClientSize = New Size(Math.Max(d * 2 + _pnlPalette.Width, _minWidth), Math.Max(d * 5 + _pnlPalette.Height + _lblPaletteInfo.Height * 2 + _btnClose.Height, _minHeight))
         _lblPaletteInfo.Bounds = New System.Drawing.Rectangle(d, d, ClientSize.Width - d * 2, _lblPaletteInfo.Height)
         _lblCurrentColor.Bounds = New System.Drawing.Rectangle(d, _lblPaletteInfo.Bottom + d, _lblPaletteInfo.Width, _lblCurrentColor.Height)
         _pnlPalette.Location = New Point(CInt((ClientSize.Width - _pnlPalette.Width) / 2), _lblCurrentColor.Bottom + d)
         _btnClose.Location = New Point(CInt((ClientSize.Width - _btnClose.Width) / 2), _pnlPalette.Bottom + d)

         ResumeLayout()
      End Sub

      Private Sub _pnlPalette_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles _pnlPalette.Paint
         Dim g As Graphics = e.Graphics

         Dim i As Integer = 0
         Do While i < Palette.Length
            Dim rc As System.Drawing.Rectangle = GetColorRectangle(i)

            g.DrawRectangle(Pens.Black, rc)
            rc.Inflate(-1, -1)

            Dim color As Color = Converters.ToGdiPlusColor(Palette(i))
            Dim brush As Brush = New SolidBrush(color)
            Try
               g.FillRectangle(brush, rc)
            Finally
               CType(brush, IDisposable).Dispose()
            End Try
            i += 1
         Loop
      End Sub

      Private Function GetColorRectangle(ByVal index As Integer) As System.Drawing.Rectangle
         Dim xGrids As Integer = Palette.Length Mod 16
         If xGrids = 0 Then
            xGrids = 16
         End If
         Dim yGrids As Integer = Math.Max(1, CInt(Palette.Length / 16))

         Dim x As Integer = index Mod xGrids
         Dim y As Integer = CInt(index / 16)

         Return New System.Drawing.Rectangle(CInt((_pnlPalette.ClientSize.Width - xGrids * _gridWidth) / 2) + x * _gridWidth, CInt(CInt((_pnlPalette.ClientSize.Height - yGrids * _gridHeight) / 2)) + y * _gridHeight, _gridWidth, _gridHeight)
      End Function

      Private Sub _pnlPalette_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles _pnlPalette.MouseMove
         Dim i As Integer
         Dim color As RasterColor
         Dim foreColor As Color
         For i = 0 To Palette.Length - 1
            If (GetColorRectangle(i).Contains(e.X, e.Y)) Then
               color = Palette(i)
               _lblCurrentColor.BackColor = Converters.ToGdiPlusColor(color)
               foreColor = System.Drawing.Color.FromArgb( _
                  CInt((color.R + 128) Mod 256), _
                  CInt((color.G + 128) Mod 256), _
                  CInt((color.B + 128) Mod 256))
               _lblCurrentColor.ForeColor = foreColor
               _lblCurrentColor.Text = String.Format("Index = {0} : {1}", i, color.ToString())
               Return
            End If
         Next

         If (Not _lblCurrentColor.BackColor.Equals(SystemColors.Control)) Then
            _lblCurrentColor.BackColor = SystemColors.Control
         End If

         If (Not _lblCurrentColor.ForeColor.Equals(SystemColors.ControlText)) Then
            _lblCurrentColor.BackColor = SystemColors.ControlText
         End If

         If (_lblCurrentColor.Text <> String.Empty) Then
            _lblCurrentColor.Text = String.Empty
         End If
      End Sub
   End Class
End Namespace

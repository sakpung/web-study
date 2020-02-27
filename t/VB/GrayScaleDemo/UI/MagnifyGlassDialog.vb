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

Imports Leadtools.Controls
Imports Leadtools
Imports System

Partial Public Class MagnifyGlassDialog
   Inherits Form
   Private _magnifyGlass As ImageViewerMagnifyGlassInteractiveMode

   Public Sub New(MagnifyGlass As ImageViewerMagnifyGlassInteractiveMode)
      InitializeComponent()
      _magnifyGlass = MagnifyGlass
   End Sub

   Private Sub MagnifyGlassDialog_Load(sender As Object, e As EventArgs) Handles Me.Load
      Try
         _numBorderSize.Value = CDec(_magnifyGlass.BorderPen.Width)
         _numHeight.Value = _magnifyGlass.Size.Height
         _numWidth.Value = _magnifyGlass.Size.Width
         _numScaleFactor.Value = CDec(_magnifyGlass.ScaleFactor)
         _cmbShape.SelectedIndex = CInt(_magnifyGlass.Shape)
         _txtInterSectionColor.BackColor = TryCast(_magnifyGlass.CrosshairPen.Brush, SolidBrush).Color
         _txtBorderColor.BackColor = TryCast(_magnifyGlass.BorderPen.Brush, SolidBrush).Color
      Catch generatedExceptionName As Exception
      End Try
   End Sub

   Private Sub _btnOk_Click(sender As Object, e As EventArgs) Handles _btnOk.Click
      _magnifyGlass.BorderPen = New Pen(_txtBorderColor.BackColor, Convert.ToInt32(_numBorderSize.Value))
      _magnifyGlass.Size = New LeadSize(Convert.ToInt32(_numWidth.Value), Convert.ToInt32(_numHeight.Value))
      _magnifyGlass.ScaleFactor = Convert.ToInt32(_numScaleFactor.Value)
      _magnifyGlass.Shape = CType(_cmbShape.SelectedIndex, ImageViewerSpyGlassShape)
      _magnifyGlass.CrosshairPen = New Pen(_txtInterSectionColor.BackColor)
   End Sub

   Private Sub Color_Click(sender As Object, e As EventArgs) Handles _btnBorderColor.Click, _btnIntersectionColor.Click
      Dim colorDlg As New ColorDialog()
      If colorDlg.ShowDialog() = DialogResult.OK Then
         If sender Is _btnBorderColor Then
            _txtBorderColor.BackColor = colorDlg.Color
         ElseIf sender Is _btnIntersectionColor Then
            _txtInterSectionColor.BackColor = colorDlg.Color
         End If
      End If
   End Sub
End Class

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

Imports GrayScaleDemo.Leadtools.Demos
Imports Leadtools
Imports Leadtools.ImageProcessing
Imports System


Partial Public Class ShearDialog
   Inherits Form
   Private Shared _initialAngle As Integer
   Private Shared _initialHorizontal As Boolean
   Private Shared _initialFillColorLevel As Integer
   Private _isGray As Boolean

   Public Angle As Integer
   Public FillColor As Color
   Public Horizontal As Boolean
   Public FillColorLevel As Integer

   Public Sub New(isGray As Boolean)
      InitializeComponent()
      _isGray = isGray
   End Sub

   Private Sub ShearDialog_Load(sender As Object, e As EventArgs) Handles Me.Load
      Dim command As New ShearCommand()
      _initialAngle = command.Angle
      _initialHorizontal = command.Horizontal
      _initialFillColorLevel = 0

      Angle = CInt(_initialAngle / 100)
      Horizontal = _initialHorizontal
      FillColorLevel = _initialFillColorLevel
      FillColor = Color.Black
      _pnlRevColor.BackColor = Color.Black

      _numAngle.Value = Angle
      _numFillColorLevel.Value = FillColorLevel

      _rbHorizontal.Checked = Horizontal
      _rbVertical.Checked = Not Horizontal

      If _isGray Then
         _pnlLevel.Visible = True
         _pnlColor.Visible = False
      Else
         _pnlLevel.Visible = False
         _pnlColor.Visible = True
      End If
   End Sub


   Private Sub _btnOk_Click(sender As Object, e As System.EventArgs) Handles _btnOk.Click
      Angle = CInt(_numAngle.Value) * 100
      Horizontal = _rbHorizontal.Checked
      FillColorLevel = CInt(_numFillColorLevel.Value)

      _initialAngle = Angle
      _initialHorizontal = Horizontal
      _initialFillColorLevel = FillColorLevel
   End Sub

   Private Sub _btnDlgColor_Click(sender As Object, e As EventArgs) Handles _btnDlgColor.Click
      Dim colorDlg As New ColorDialog()
      If colorDlg.ShowDialog() = DialogResult.OK Then
         _pnlRevColor.BackColor = colorDlg.Color
         FillColor = colorDlg.Color
      End If
   End Sub
End Class

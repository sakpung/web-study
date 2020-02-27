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

Partial Public Class FillDialog
   Inherits Form
   Public Level As Integer
   Public FillColor As Color
   Private _isGray As Boolean
   Private _type As TypeConstants

   Public Sub New(isGray As Boolean, type As TypeConstants)
      InitializeComponent()
      _isGray = isGray
      _type = type
   End Sub

   Public Enum TypeConstants
      AddColorToRegion
      Fill
   End Enum

   Private Structure TypeProp
      Public Type As TypeConstants
      Public CaptionName As String

      Public Sub New(type__1 As TypeConstants, captionName__2 As String)
         Type = type__1
         CaptionName = captionName__2
      End Sub
   End Structure

   Private Shared _typeProp As TypeProp() = New TypeProp() {New TypeProp(TypeConstants.AddColorToRegion, "Add Color To Region"), New TypeProp(TypeConstants.Fill, "Fill")}

   Private Sub FillDialog_Load(sender As Object, e As EventArgs) Handles Me.Load
      If _isGray Then
         _pnlColor.Visible = False
         _pnlLevel.Visible = True
      Else
         _pnlColor.Visible = True
         _pnlLevel.Visible = False
      End If
      _numLevel.Value = 0
      _pnlRevColor.BackColor = Color.Black
      FillColor = Color.Black

      Dim prop As TypeProp = _typeProp(CInt(_type))
      Text = prop.CaptionName
   End Sub

   Private Sub _btnCancel_Click(sender As Object, e As EventArgs) Handles _btnCancel.Click
      Close()
   End Sub

   Private Sub _btnOk_Click(sender As Object, e As EventArgs) Handles _btnOk.Click
      Level = CInt(_numLevel.Value)
      Me.DialogResult = DialogResult.OK
      Me.Close()
   End Sub

   Private Sub _btnDlgColor_Click(sender As Object, e As EventArgs) Handles _btnDlgColor.Click
      Dim colorDlg As New ColorDialog()
      If colorDlg.ShowDialog() = DialogResult.OK Then
         _pnlRevColor.BackColor = colorDlg.Color
         FillColor = colorDlg.Color
      End If
   End Sub

End Class

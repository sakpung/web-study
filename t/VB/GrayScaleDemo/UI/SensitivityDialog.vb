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

Partial Public Class SensitivityDialog
   Inherits Form
   Private _senValue As Integer

   Public Property SenValue() As Integer
      Get
         Return _senValue
      End Get
      Set(value As Integer)
         _senValue = value
      End Set
   End Property

   Public Sub New(senValue As Integer)
      InitializeComponent()

      _senValue = senValue
   End Sub

   Private Sub SensitivityDialog_Load(sender As Object, e As EventArgs) Handles Me.Load
      _numValue.Value = _senValue
   End Sub

   Private Sub _btnOk_Click(sender As Object, e As EventArgs) Handles _btnOk.Click
      _senValue = CInt(_numValue.Value)
   End Sub
End Class

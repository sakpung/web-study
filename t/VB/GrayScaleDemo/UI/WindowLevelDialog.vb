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

Partial Public Class WindowLevelDialog
   Inherits Form
   Private _level As Integer
   Private _width As Integer

   Public Property WL_Width() As Integer
      Get
         Return _width
      End Get
      Set(value As Integer)
         _width = value
      End Set
   End Property

   Public Property WL_Level() As Integer
      Get
         Return _level
      End Get
      Set(value As Integer)
         _level = value
      End Set
   End Property

   Public Sub New(level As Integer, width As Integer, minWidth As Integer, maxWidth As Integer, minLevel As Integer, maxLevel As Integer)
      InitializeComponent()
      _level = level
      _width = width
      _numLevel.Maximum = maxLevel
      _numLevel.Minimum = minLevel
      _numWidth.Maximum = maxWidth
      _numWidth.Minimum = minWidth
   End Sub

   Private Sub WindowLevelDialog_Load(sender As Object, e As EventArgs) Handles Me.Load
      _numWidth.Value = _width
      _numLevel.Value = _level
   End Sub

   Private Sub _btnOk_Click(sender As Object, e As EventArgs) Handles _btnOk.Click
      _width = CInt(_numWidth.Value)
      _level = CInt(_numLevel.Value)
   End Sub
End Class

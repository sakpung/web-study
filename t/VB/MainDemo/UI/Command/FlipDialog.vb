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

Imports Leadtools.ImageProcessing

Namespace MainDemo
   Partial Public Class FlipDialog : Inherits Form
      Private Shared _firstTimer As Boolean = True
      Private Shared _initialHorizontal As Boolean
      Public Horizontal As Boolean

      Public Sub New()
         InitializeComponent()
      End Sub

      Private Sub FlipDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
         If _firstTimer Then
            _firstTimer = False
            Dim command As FlipCommand = New FlipCommand()
            _initialHorizontal = command.Horizontal
         End If

         Horizontal = _initialHorizontal
         _rbHorizontal.Checked = Horizontal
         _rbVertical.Checked = Not Horizontal
      End Sub

      Private Sub _btnOk_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _btnOk.Click
         Horizontal = _rbHorizontal.Checked
         _initialHorizontal = Horizontal
      End Sub
   End Class
End Namespace

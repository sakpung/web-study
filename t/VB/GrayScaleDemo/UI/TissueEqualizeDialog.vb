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

Imports Leadtools.ImageProcessing.Core
Imports GrayScaleDemo.Leadtools.Demos
Imports System

Partial Public Class TissueEqualizeDialog
   Inherits Form
   Private Shared _flags As TissueEqualizeCommandFlags

   Public ReadOnly Property Flags() As TissueEqualizeCommandFlags
      Get
         Return TissueEqualizeDialog._flags
      End Get
   End Property

   Public Sub New()
      InitializeComponent()
   End Sub

   Private Sub TissueEqualizeDialog_Load(sender As Object, e As EventArgs) Handles Me.Load
      Dim cmd As New TissueEqualizeCommand()
      _flags = cmd.Flags

      Select Case CInt(_flags)
         Case &H1
            _rbUseSimplifyOption.Checked = True
            Exit Select
         Case &H2
            _rbUseIntensifyOption.Checked = True
            Exit Select
      End Select
   End Sub

   Private Sub _btnOk_Click(sender As Object, e As EventArgs) Handles _btnOk.Click
      If _rbUseIntensifyOption.Checked Then
         _flags = TissueEqualizeCommandFlags.UseIntensifyOption
      Else
         _flags = TissueEqualizeCommandFlags.UseSimplifyOption
      End If
   End Sub

End Class

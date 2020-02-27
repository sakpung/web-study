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

Imports Leadtools.ImageProcessing.Color
Imports Leadtools.Demos

Namespace MainDemo
   Partial Public Class SwapColorsDialog : Inherits Form
      Private Shared _firstTimer As Boolean = True
      Private Shared _initialType As SwapColorsCommandType

      Public Type As SwapColorsCommandType

      Public Sub New()
         InitializeComponent()
      End Sub

      Private Sub SwapColorsDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
         If _firstTimer Then
            _firstTimer = False
            Dim command As SwapColorsCommand = New SwapColorsCommand()
            _initialType = command.Type
         End If

         Type = _initialType

         Tools.FillComboBoxWithEnum(_cbType, GetType(SwapColorsCommandType), Type)
      End Sub

      Private Sub _btnOk_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _btnOk.Click
         Type = CType(Leadtools.Demos.Constants.GetValueFromName(GetType(SwapColorsCommandType), CStr(_cbType.SelectedItem), _initialType), SwapColorsCommandType)

         _initialType = Type
      End Sub
   End Class
End Namespace

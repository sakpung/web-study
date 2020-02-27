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

Imports Leadtools.ImageProcessing.Effects
Imports Leadtools.Demos

Namespace MainDemo
   Partial Public Class EmbossDialog : Inherits Form
      Private Shared _firstTimer As Boolean = True
      Private Shared _initialDirection As EmbossCommandDirection
      Private Shared _initialDepth As Integer

      Public Direction As EmbossCommandDirection
      Public Depth As Integer

      Public Sub New()
         InitializeComponent()
      End Sub

      Private Sub EmbossDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
         If _firstTimer Then
            _firstTimer = False
            Dim command As EmbossCommand = New EmbossCommand()
            _initialDirection = command.Direction
            _initialDepth = command.Depth
         End If

         Direction = _initialDirection
         Depth = CInt(_initialDepth / 10)

         Tools.FillComboBoxWithEnum(_cbDirection, GetType(EmbossCommandDirection), Direction)
         _numDepth.Value = Depth
      End Sub

      Private Sub _num_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles _numDepth.Leave
         DialogUtilities.NumericOnLeave(sender)
      End Sub

      Private Sub _btnOk_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _btnOk.Click
         Direction = CType(Leadtools.Demos.Constants.GetValueFromName(GetType(EmbossCommandDirection), CStr(_cbDirection.SelectedItem), _initialDirection), EmbossCommandDirection)

         Depth = CInt(_numDepth.Value) * 10

         _initialDirection = Direction
         _initialDepth = Depth
      End Sub
   End Class
End Namespace

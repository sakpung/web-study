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
Imports Leadtools.ImageProcessing.Core
Imports Leadtools.ImageProcessing.Effects

Namespace MainDemo
   Partial Public Class SmoothDialog : Inherits Form
      Private Shared _firstTimer As Boolean = True
      Private Shared _initialFlags As SmoothCommandFlags
      Private Shared _initialLength As Integer

      Public Flags As SmoothCommandFlags
      Public Length As Integer

      Public Sub New()
         InitializeComponent()
      End Sub

      Private Sub SmoothDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
         If _firstTimer Then
            _firstTimer = False
            Dim command As SmoothCommand = New SmoothCommand()
            _initialFlags = command.Flags
            _initialLength = command.Length
         End If

         Flags = _initialFlags
         Length = _initialLength

         _cbImageUnchanged.Checked = (Flags And SmoothCommandFlags.ImageUnchanged) = SmoothCommandFlags.ImageUnchanged
         _cbFavorLong.Checked = (Flags And SmoothCommandFlags.FavorLong) = SmoothCommandFlags.FavorLong

         _numLength.Value = Length
      End Sub

      Private Sub _num_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles _numLength.Leave
         DialogUtilities.NumericOnLeave(sender)
      End Sub

      Private Sub _btnOk_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _btnOk.Click
         Flags = SmoothCommandFlags.None

         If _cbImageUnchanged.Checked Then
            Flags = Flags Or SmoothCommandFlags.ImageUnchanged
         End If
         If _cbFavorLong.Checked Then
            Flags = Flags Or SmoothCommandFlags.FavorLong
         End If

         Length = CInt(_numLength.Value)

         _initialFlags = Flags
         _initialLength = Length
      End Sub
   End Class
End Namespace

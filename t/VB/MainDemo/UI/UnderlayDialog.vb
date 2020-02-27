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

Namespace MainDemo
   Partial Public Class UnderlayDialog : Inherits Form
      Private Shared _firstTimer As Boolean = True
      Private Shared _initialFlags As RasterImageUnderlayFlags
      Public Flags As RasterImageUnderlayFlags

      Public Sub New()
         InitializeComponent()
      End Sub

      Private Sub UnderlayDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
         If _firstTimer Then
            _firstTimer = False
            _initialFlags = RasterImageUnderlayFlags.Stretch
         End If

         Flags = _initialFlags
         _rbStretch.Checked = (Flags And RasterImageUnderlayFlags.Stretch) = RasterImageUnderlayFlags.Stretch
         _rbTile.Checked = (Flags And RasterImageUnderlayFlags.None) = RasterImageUnderlayFlags.None
      End Sub

      Private Sub _btnOk_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _btnOk.Click
         If _rbStretch.Checked Then
            Flags = RasterImageUnderlayFlags.Stretch
         End If
         If _rbTile.Checked Then
            Flags = RasterImageUnderlayFlags.None
         End If

         _initialFlags = Flags
      End Sub
   End Class
End Namespace

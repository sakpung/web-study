' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports System.Runtime.InteropServices

Namespace MedicalViewerDemo
   Partial Public Class StentEnhancementDialog : Inherits Form
      Public CancelClicked As Boolean
      Private _form As MainForm


      Private Const SC_CLOSE As Integer = &HF060
      Private Const MF_GRAYED As Integer = &H1

      <DllImport("user32.dll")> _
      Private Shared Function GetSystemMenu(ByVal hWnd As IntPtr, ByVal bRevert As Boolean) As IntPtr
      End Function

      <DllImport("user32.dll")> _
      Private Shared Function EnableMenuItem(ByVal hMenu As IntPtr, ByVal wIDEnableItem As Integer, ByVal wEnable As Integer) As Integer
      End Function

      Public Sub EnableClose(ByVal isEnable As Boolean)
         EnableMenuItem(GetSystemMenu(Me.Handle, isEnable), SC_CLOSE, MF_GRAYED)
      End Sub

      Public Sub New(ByVal form As MainForm)
         InitializeComponent()
         _form = form
      End Sub

      Public Sub UpdateProgress(ByVal percent As Integer)
         _stentProgressBar.Value = percent
      End Sub

      Private Sub _btnOk_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnOk.Click
         _form._stentDialog_FormClosing(Nothing, Nothing)
         Me.Close()
      End Sub

      Private Sub _btnApply_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnApply.Click
         _btnOk.Enabled = False
         _btnApply.Enabled = False
         EnableClose(False)

         _form.ApplyStent()

         _btnOk.Enabled = True
         _btnApply.Enabled = True
         EnableClose(True)
      End Sub

      Private Sub _btnCancel_Click(ByVal sender As Object, ByVal e As EventArgs)
         CancelClicked = True
      End Sub

      Private Sub StentEnhancementDialog_FormClosing(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles Me.FormClosing
         _form.FinishStentEnhancement()
      End Sub

      Private Sub _btnReset_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnReset.Click
         _form.ResetRegion()
      End Sub

      Public Sub ResetBtnEnabled(ByVal value As Boolean)
         _btnReset.Enabled = value
      End Sub

      Private Sub _btnResetAvg_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnResetAvg.Click
         _form.ResetAverage()
      End Sub

      Public Sub ResetAvgEnabled(ByVal value As Boolean)
         _btnResetAvg.Enabled = value
      End Sub
   End Class
End Namespace

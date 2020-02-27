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

Namespace PrintToPACSDemo
   Partial Public Class LogWindow : Inherits Form
   Private _frmMain As FrmMain = Nothing
   Public Sub New(ByVal frmMain As FrmMain)
   InitializeComponent()
   Me.Visible = False
   _frmMain = frmMain
   _ckbtnLowLevel.Checked = _frmMain._mySettings._settings.logLowLevel
   End Sub

   Public Property RichTextBox() As RichTextBox
   Get
    Return _rctxtLog
   End Get
   Set(ByVal value As RichTextBox)
    _rctxtLog = Value
   End Set
   End Property

   Private Sub _btnClearLog_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnClearLog.Click
   _rctxtLog.Clear()
   End Sub

   Private Sub _rctxtLog_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _rctxtLog.TextChanged
   _btnClearLog.Enabled = Not (_rctxtLog.Text.Length = 0)

   End Sub

   Private Sub LogWindow_FormClosing(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles MyBase.FormClosing
   e.Cancel = True
   Me.Visible = False
   _frmMain.UpdateToolBarState()
   End Sub

   Private Sub _ckbtnLowLevel_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _ckbtnLowLevel.CheckedChanged
   _frmMain._mySettings._settings.logLowLevel = _ckbtnLowLevel.Checked
   _frmMain._mySettings.Save()
   End Sub

   Private Sub checkBox1_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles checkBox1.CheckedChanged
   Me.TopMost = checkBox1.Checked
   End Sub

   Private Sub _btnSaveToText_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnSaveToText.Click
   Dim dlgSave As SaveFileDialog = New SaveFileDialog()
   dlgSave.Filter = "Text File|*.txt"
   Dim dlgRes As DialogResult = dlgSave.ShowDialog()
   If dlgRes = DialogResult.Cancel Then
   Return
   End If

   Try
   System.IO.File.WriteAllLines(dlgSave.FileName, _rctxtLog.Lines)
   Catch ex As System.Exception
   MessageBox.Show(Me, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
   End Try

   End Sub
   End Class
End Namespace

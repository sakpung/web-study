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


Imports Leadtools.MedicalViewer
Imports Leadtools.ImageProcessing.Core
Imports Leadtools.ImageProcessing

Namespace MedicalViewerDemo
   Partial Public Class ModifyStent : Inherits Form
      Private _cell As MedicalViewerMultiCell
      Private _frameEnabled As Boolean()
      Private _form As MainForm
      Private _firstTime As Boolean

      Public Sub New(ByVal cell As MedicalViewerMultiCell, ByVal stentCommand As StentEnhancementCommand, ByVal form As MainForm)
         _firstTime = True
         _cell = CType(cell, MedicalViewerMultiCell)
         _form = form

         _frameEnabled = _form.FrameEnabled


         InitializeComponent()
      End Sub

      Private Sub ModifyStent_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
         Dim i As Integer = 1
         Do While i <= _cell.Image.PageCount
            _cbFrames.Items.Add("Frame " & i.ToString(), _frameEnabled(i - 1))
            i += 1
         Loop
      End Sub

      Private Sub _cbFrames_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _cbFrames.SelectedIndexChanged
         _firstTime = False
         _cell.ActiveSubCell = _cbFrames.SelectedIndex
      End Sub

      Private Sub _btnOk_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnOk.Click
         Me.Close()
      End Sub

      Private Sub _cbFrames_ItemCheck(ByVal sender As Object, ByVal e As ItemCheckEventArgs) Handles _cbFrames.ItemCheck

         If (Not _firstTime) Then

            If Not _form.StentCommand Is Nothing Then
               If Not (e.CurrentValue = CheckState.Checked) Then
                  _form.StentCommand.SelectFrame(_cell.Image, e.Index)
               Else
                  _form.StentCommand.UnSelectFrame(_cell.Image, e.Index)

               End If

               _form.ApplyEnhancements(_form.StentCommand.EnhancedImage)
               _cell.Invalidate()
            End If

         End If

      End Sub

      Private Sub ModifyStent_FormClosing(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles Me.FormClosing
         _form._modifyStentDlg = Nothing
         _cell = Nothing
         _frameEnabled = Nothing
         _form = Nothing
         _firstTime = True
      End Sub
   End Class
End Namespace

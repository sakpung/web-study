' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports Microsoft.VisualBasic
Imports System
Imports System.IO
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms

Namespace FormsDemo
   Partial Public Class MasterFormList : Inherits Form
      Private _workingDir As String
      Private _selectedFormSet As String
      Private _isICRSupported As Boolean

      Public Sub New(ByVal workingDir As String, ByVal isICRSupported As Boolean)
         InitializeComponent()
         _workingDir = workingDir
         _isICRSupported = isICRSupported
      End Sub

      Private Sub _btnOk_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnOk.Click
         _selectedFormSet = _masterFormList.Items(_masterFormList.SelectedIndex).ToString()
         DialogResult = System.Windows.Forms.DialogResult.OK
      End Sub

      Private Sub _btnCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnCancel.Click
         DialogResult = DialogResult.Cancel
      End Sub

      Private Sub MasterFormList_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
         Dim dirs As String() = Directory.GetDirectories(_workingDir)

         For Each dir As String In dirs
            Dim dirInfo As DirectoryInfo = New DirectoryInfo(dir)
            If (Not _isICRSupported) AndAlso dirInfo.Name.Contains("ICR") Then
               'Some engines like Advantage do not support ICR so we should not
               'show the ICR MasterFormSet
               Continue For
            Else
               _masterFormList.Items.Add(dirInfo.Name)
            End If
         Next dir

         If _masterFormList.Items.Count > 0 Then
            'Attempt to select the OCR form list as default
            Dim defaultIndex As Integer = _masterFormList.Items.IndexOf("OCR")
            If defaultIndex <> -1 Then
               _masterFormList.SelectedIndex = defaultIndex
            End If
         End If
      End Sub

      Public ReadOnly Property SelectedFormSet() As String
         Get
            Return _selectedFormSet
         End Get
      End Property

      Private Sub _masterFormList_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _masterFormList.SelectedIndexChanged
         Try
            _btnOk.Enabled = _masterFormList.SelectedIndices.Count = 1
         Catch exp As Exception
            Messager.ShowError(Me, exp)
         End Try
      End Sub

      Private Sub _masterFormList_MouseDoubleClick(ByVal sender As Object, ByVal e As MouseEventArgs) Handles _masterFormList.MouseDoubleClick
         Try
            If _masterFormList.SelectedIndices.Count = 1 Then
               _btnOk_Click(Me, New EventArgs())
            End If
         Catch exp As Exception
            Messager.ShowError(Me, exp)
         End Try
      End Sub
   End Class
End Namespace

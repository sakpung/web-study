' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Drawing
Imports System.Data
Imports System.Text
Imports System.Windows.Forms

Namespace DicomDemo
   Partial Public Class Page0 : Inherits UserControl
      Private _globals As Globals

      Public Sub New(ByRef pGlobals As Globals)
         InitializeComponent()

         _globals = pGlobals
      End Sub

      '
      '* Makes sure that the client timeout amount is reasonable
      '
      Private Sub txtTimeout_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtTimeout.TextChanged
         Try
            Dim timeout As Integer = Convert.ToInt32(txtTimeout.Text)
            If timeout < 15 OrElse timeout > 120 Then
               CType(ParentForm, MainForm).btnNext.Enabled = False
            Else
               CType(ParentForm, MainForm).btnNext.Enabled = True
            End If

         Catch ex As Exception
            If ex.Message = "Input string was not in a correct format." Then
               CType(ParentForm, MainForm).btnNext.Enabled = False
            Else
               MessageBox.Show(ex.ToString())
            End If
         End Try
      End Sub

      Private Sub Page0_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
         ' Initialize text boxes
         txtTimeout.Text = _globals.m_nTimerMax.ToString()
      End Sub
   End Class
End Namespace

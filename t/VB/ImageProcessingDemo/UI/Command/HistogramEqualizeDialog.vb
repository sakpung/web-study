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

Namespace ImageProcessingDemo
   'This dialog is used to allow the user to specify values which
   'will be used for the HistogramEqualizeCommand

   Partial Public Class HistogramEqualizeDialog : Inherits Form
      Private Shared _firstTimer As Boolean = True
      Private Shared _initialColorSpace As HistogramEqualizeType
      Private _HistogramEqualizeCommand As HistogramEqualizeCommand

      Public ColorSpace As HistogramEqualizeType

      Public Sub New()
         InitializeComponent()
         _HistogramEqualizeCommand = New HistogramEqualizeCommand()
      End Sub

      Public Property HistogramEqualizeCommand() As HistogramEqualizeCommand
         Get
            Return _HistogramEqualizeCommand
         End Get
         Set(ByVal value As HistogramEqualizeCommand)
            _HistogramEqualizeCommand = value
         End Set

      End Property
      Private Sub HistogramEqualizeDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
         If _firstTimer Then
            _firstTimer = False
            _initialColorSpace = _HistogramEqualizeCommand.Type
         End If

         ColorSpace = _initialColorSpace

         'Set command default values
         Dim names As String()
         names = System.Enum.GetNames(GetType(HistogramEqualizeType))
         For Each name As String In names
            If name <> "None" Then
               _cmbColorSpace.Items.Add(name)
            End If
         Next name
         _cmbColorSpace.SelectedIndex = _cmbColorSpace.Items.IndexOf(ColorSpace.ToString())
      End Sub
      Public Function TranslateType() As HistogramEqualizeType
         Select Case _cmbColorSpace.SelectedIndex
            Case 0
               Return HistogramEqualizeType.Rgb
            Case 1
               Return HistogramEqualizeType.Yuv
            Case 2
               Return HistogramEqualizeType.Gray
            Case Else
               Return HistogramEqualizeType.Rgb
         End Select
      End Function
      Private Sub _btnOk_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _btnOk.Click
         'Update command values
         ColorSpace = TranslateType()
         _HistogramEqualizeCommand.Type = ColorSpace
         _initialColorSpace = ColorSpace
         Me.DialogResult = DialogResult.OK
      End Sub

      Private Sub _btnCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnCancel.Click
         Me.DialogResult = DialogResult.Cancel
      End Sub
   End Class
End Namespace

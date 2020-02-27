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
Imports Leadtools.ImageProcessing.Color

Namespace ImageProcessingDemo
   'This dialog is used to allow the user to specify values which
   'will be used for the GrayScaleToDuotoneCommand

   Partial Public Class GrayScaleToDuotoneDialog : Inherits Form
      Private _GrayScaleToDuotoneCommand As GrayScaleToDuotoneCommand
      Private _Color As RasterColor

      Public Sub New()
         InitializeComponent()
         _GrayScaleToDuotoneCommand = New GrayScaleToDuotoneCommand()

         'Set command default values
         InitializeUI()

      End Sub

      Public Property GrayScaleToDuotoneCommand() As GrayScaleToDuotoneCommand
         Get
            'Update command values
            UpdateCommand()
            Return _GrayScaleToDuotoneCommand
         End Get
         Set(ByVal value As GrayScaleToDuotoneCommand)
            _GrayScaleToDuotoneCommand = value
            InitializeUI()
         End Set
      End Property

      Private Sub InitializeUI()
         _Color = Leadtools.Demos.Converters.FromGdiPlusColor(Color.Black)

         Dim names As String()
         names = System.Enum.GetNames(GetType(GrayScaleToDuotoneCommandMixingType))
         For Each name As String In names
            If name <> "None" Then
               _cmbType.Items.Add(name)
            End If
         Next name
         _cmbType.SelectedIndex = 0
      End Sub

      Private Sub UpdateCommand()
         _Color = Leadtools.Demos.Converters.FromGdiPlusColor(_lblColor.BackColor)
         _GrayScaleToDuotoneCommand.Color = _Color
         _GrayScaleToDuotoneCommand.Type = TranslateType()
      End Sub

      Public Function TranslateType() As GrayScaleToDuotoneCommandMixingType
         Select Case _cmbType.SelectedIndex
            Case 0
               Return GrayScaleToDuotoneCommandMixingType.MixWithOldValue
            Case 1
               Return GrayScaleToDuotoneCommandMixingType.ReplaceOldWithNew
            Case Else
               Return GrayScaleToDuotoneCommandMixingType.MixWithOldValue
         End Select
      End Function

      Private Sub _btnColor_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnColor.Click
         Dim ColorDlg As ColorDialog = New ColorDialog()
         If ColorDlg.ShowDialog(Me) = DialogResult.OK Then
            _lblColor.BackColor = ColorDlg.Color
         End If
      End Sub

      Private Sub _btnOk_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnOk.Click
         UpdateCommand()
         Me.DialogResult = DialogResult.OK
         Me.Close()
      End Sub

      Private Sub _btnCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnCancel.Click
         Me.DialogResult = DialogResult.Cancel
      End Sub
   End Class
End Namespace

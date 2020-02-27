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
Imports Leadtools

Namespace ImageProcessingDemo
   'This dialog is used to allow the user to specify values which
   'will be used for the EdgeDetectEffectCommand

   Partial Public Class EdgeDetectEffectDialog : Inherits Form
      Private _EdgeDetectEffectCommand As EdgeDetectEffectCommand
      Private _Level As Integer
      Private _Threshold As Integer

      Public Sub New()
         InitializeComponent()
         _EdgeDetectEffectCommand = New EdgeDetectEffectCommand()

         'Set command default values
         _Level = 50
         _Threshold = 0
         InitializeUI()
      End Sub

      Public Property EdgeDetectEffectCommand() As EdgeDetectEffectCommand
         Get
            'Update command values
            UpdateCommand()
            Return _EdgeDetectEffectCommand
         End Get
         Set(ByVal value As EdgeDetectEffectCommand)
            _EdgeDetectEffectCommand = value
            InitializeUI()
         End Set
      End Property

      Private Sub _tbLevel_Scroll(ByVal sender As Object, ByVal e As EventArgs) Handles _tbLevel.Scroll
         _txbLevel.Text = _tbLevel.Value.ToString()
      End Sub

      Private Sub _txbLevel_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _txbLevel.TextChanged
         Try
            _txbLevel.Text = MainForm.IsValidNumber(_txbLevel.Text, 1, 100)

            Dim Val As Integer = Integer.Parse(_txbLevel.Text)
            If Val >= _tbLevel.Minimum AndAlso Val <= _tbLevel.Maximum Then
               _tbLevel.Value = Val
            End If
         Catch
         End Try
      End Sub

      Private Sub InitializeUI()
         Dim names As String()

         names = System.Enum.GetNames(GetType(EdgeDetectEffectCommandType))

         For Each name As String In names
            _cmbType.Items.Add(name)
         Next name
         _cmbType.SelectedIndex = 0

         _txbLevel.Text = _Level.ToString()
         _txbThreshold.Text = _Threshold.ToString()
         _EdgeDetectEffectCommand.Type = EdgeDetectEffectCommandType.Smooth
      End Sub

      Private Sub UpdateCommand()
         _Level = Convert.ToInt32(_txbLevel.Text)
         _Threshold = Convert.ToInt32(_txbThreshold.Text)

         _EdgeDetectEffectCommand.Type = TranslateType()
         _EdgeDetectEffectCommand.Level = _Level
         _EdgeDetectEffectCommand.Threshold = _Threshold
      End Sub

      Public Function TranslateType() As EdgeDetectEffectCommandType
         Select Case _cmbType.SelectedIndex
            Case 0
               Return EdgeDetectEffectCommandType.Smooth
            Case 1
               Return EdgeDetectEffectCommandType.Solid
            Case Else
               Return EdgeDetectEffectCommandType.Smooth
         End Select

      End Function

      Private Sub _tbThreshold_Scroll(ByVal sender As Object, ByVal e As EventArgs) Handles _tbThreshold.Scroll
         _txbThreshold.Text = _tbThreshold.Value.ToString()
      End Sub

      Private Sub _txbThreshold_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _txbThreshold.TextChanged
         Try
            _txbThreshold.Text = MainForm.IsValidNumber(_txbThreshold.Text, 0, 255)

            Dim Val As Integer = Integer.Parse(_txbThreshold.Text)
            If Val >= _tbThreshold.Minimum AndAlso Val <= _tbThreshold.Maximum Then
               _tbThreshold.Value = Val
            End If
         Catch
         End Try
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

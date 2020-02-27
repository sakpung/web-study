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
Imports Leadtools.ImageProcessing.Effects

Namespace ImageProcessingDemo
   'This dialog is used to allow the user to specify values which
   'will be used for the ContourFilterCommand

   Partial Public Class ContourFilterDialog : Inherits Form
      Private _ContourFilterCommand As ContourFilterCommand
      Private _DeltaDirection As Integer
      Private _MaximumError As Integer
      Private _Threshold As Integer

      Public Sub New()
         InitializeComponent()
         _ContourFilterCommand = New ContourFilterCommand()

         'Set command default values
         InitializeUI()
      End Sub

      Public Property ContourFilterCommand() As ContourFilterCommand
         Get
            'Update command values
            UpdateCommand()
            Return _ContourFilterCommand
         End Get
         Set(ByVal value As ContourFilterCommand)
            _ContourFilterCommand = value
            InitializeUI()
         End Set
      End Property

      Private Sub InitializeUI()
         Dim names As String()
         names = System.Enum.GetNames(GetType(ContourFilterCommandType))
         For Each name As String In names
            _cmbType.Items.Add(name)
         Next name
         _cmbType.SelectedIndex = _cmbType.Items.IndexOf(_ContourFilterCommand.Type.ToString())

         _DeltaDirection = 35
         _MaximumError = 5
         _Threshold = 15

         _txbDeltaDirection.Text = _DeltaDirection.ToString()
         _txbMaximumError.Text = _MaximumError.ToString()
         _txbThreshold.Text = _Threshold.ToString()
      End Sub

      Private Sub UpdateCommand()
         _DeltaDirection = Convert.ToInt32(_txbDeltaDirection.Text)
         _MaximumError = Convert.ToInt32(_txbMaximumError.Text)
         _Threshold = Convert.ToInt32(_txbThreshold.Text)

         _ContourFilterCommand.Type = TranslateType()
         _ContourFilterCommand.DeltaDirection = _DeltaDirection
         _ContourFilterCommand.MaximumError = _MaximumError
         _ContourFilterCommand.Threshold = _Threshold
      End Sub

      Private Function TranslateType() As ContourFilterCommandType
         Select Case _cmbType.SelectedIndex
            Case 0
               Return ContourFilterCommandType.Thin
            Case 1
               Return ContourFilterCommandType.LinkBlackWhite
            Case 2
               Return ContourFilterCommandType.LinkGray
            Case 3
               Return ContourFilterCommandType.LinkColor
            Case 4
               Return ContourFilterCommandType.ApproxColor
            Case Else
               Return ContourFilterCommandType.Thin

         End Select
      End Function

      Private Sub _btnOk_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnOk.Click
         UpdateCommand()
         Me.DialogResult = DialogResult.OK
         Me.Close()
      End Sub

      Private Sub _btnCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnCancel.Click
         Me.DialogResult = DialogResult.Cancel
      End Sub

      Private Sub _tbDeltaDirection_Scroll(ByVal sender As Object, ByVal e As EventArgs) Handles _tbDeltaDirection.Scroll
         _txbDeltaDirection.Text = _tbDeltaDirection.Value.ToString()
      End Sub

      Private Sub _txbDeltaDirection_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _txbDeltaDirection.TextChanged
         Try
            _txbDeltaDirection.Text = MainForm.IsValidNumber(_txbDeltaDirection.Text, 1, 64)

            Dim Val As Integer = Integer.Parse(_txbDeltaDirection.Text)
            If Val >= _tbDeltaDirection.Minimum AndAlso Val <= _tbDeltaDirection.Maximum Then
               _tbDeltaDirection.Value = Val
            End If
         Catch
         End Try
      End Sub

      Private Sub _tbMaximumError_Scroll(ByVal sender As Object, ByVal e As EventArgs) Handles _tbMaximumError.Scroll
         _txbMaximumError.Text = _tbMaximumError.Value.ToString()

      End Sub

      Private Sub _txbMaximumError_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _txbMaximumError.TextChanged
         Try
            _txbMaximumError.Text = MainForm.IsValidNumber(_txbMaximumError.Text, 0, 255)

            Dim Val As Integer = Integer.Parse(_txbMaximumError.Text)
            If Val >= _tbMaximumError.Minimum AndAlso Val <= _tbMaximumError.Maximum Then
               _tbMaximumError.Value = Val
            End If
         Catch
         End Try
      End Sub

      Private Sub _tbThreshold_Scroll(ByVal sender As Object, ByVal e As EventArgs) Handles _tbThreshold.Scroll
         _txbThreshold.Text = _tbThreshold.Value.ToString()
      End Sub

      Private Sub _txbThreshold_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _txbThreshold.TextChanged
         Try
            _txbThreshold.Text = MainForm.IsValidNumber(_txbThreshold.Text, 1, 254)

            Dim Val As Integer = Integer.Parse(_txbThreshold.Text)
            If Val >= _tbThreshold.Minimum AndAlso Val <= _tbThreshold.Maximum Then
               _tbThreshold.Value = Val
            End If
         Catch
         End Try
      End Sub

      Private Sub _cmbType_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _cmbType.SelectedIndexChanged
         If _cmbType.SelectedItem.ToString() = "ApproxColor" Then
            _gbMaximumError.Enabled = True
         Else
            _gbMaximumError.Enabled = False
         End If
      End Sub
   End Class
End Namespace

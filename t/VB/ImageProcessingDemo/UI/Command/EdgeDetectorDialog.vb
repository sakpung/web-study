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
   'will be used for the EdgeDetectorCommand

   Partial Public Class EdgeDetectorDialog : Inherits Form
      Private _EdgeDetectorCommand As EdgeDetectorCommand
      Private _Threshold As Integer

      Public Sub New()
         InitializeComponent()
         _EdgeDetectorCommand = New EdgeDetectorCommand()

         'Set command default values
         _Threshold = 60
         InitializeUI()
      End Sub

      Public Property EdgeDetectorCommand() As EdgeDetectorCommand
         Get
            'Update command values
            UpdateCommand()
            Return _EdgeDetectorCommand
         End Get
         Set(ByVal value As EdgeDetectorCommand)
            _EdgeDetectorCommand = value
            InitializeUI()
         End Set
      End Property

      Private Sub InitializeUI()
         Dim names As String()

         names = System.Enum.GetNames(GetType(EdgeDetectorCommandType))

         For Each name As String In names
            _cmbFilter.Items.Add(name)
         Next name

         _cmbFilter.SelectedIndex = 0

         _txbThreshold.Text = _Threshold.ToString()
      End Sub

      Private Sub UpdateCommand()
         _Threshold = Convert.ToInt32(_txbThreshold.Text)

         _EdgeDetectorCommand.Filter = TranslateFilter()
         _EdgeDetectorCommand.Threshold = _Threshold
      End Sub

      Private Function TranslateFilter() As EdgeDetectorCommandType
         Select Case _cmbFilter.SelectedIndex
            Case 0
               Return EdgeDetectorCommandType.SobelVertical
            Case 1
               Return EdgeDetectorCommandType.SobelHorizontal
            Case 2
               Return EdgeDetectorCommandType.SobelBoth
            Case 3
               Return EdgeDetectorCommandType.PrewittVertical
            Case 4
               Return EdgeDetectorCommandType.PrewittHorizontal
            Case 5
               Return EdgeDetectorCommandType.PrewittBoth
            Case 6
               Return EdgeDetectorCommandType.Laplace1
            Case 7
               Return EdgeDetectorCommandType.Laplace2
            Case 8
               Return EdgeDetectorCommandType.Laplace3
            Case 9
               Return EdgeDetectorCommandType.LaplaceDiagonal
            Case 10
               Return EdgeDetectorCommandType.LaplaceHorizontal
            Case 11
               Return EdgeDetectorCommandType.LaplaceVertical
            Case 12
               Return EdgeDetectorCommandType.GradientNorth
            Case 13
               Return EdgeDetectorCommandType.GradientNorthEast
            Case 14
               Return EdgeDetectorCommandType.GradientEast
            Case 15
               Return EdgeDetectorCommandType.GradientSouthEast
            Case 16
               Return EdgeDetectorCommandType.GradientSouth
            Case 17
               Return EdgeDetectorCommandType.GradientSouthWest
            Case 18
               Return EdgeDetectorCommandType.GradientWest
            Case 19
               Return EdgeDetectorCommandType.GradientNorthWest
            Case Else
               Return EdgeDetectorCommandType.SobelVertical
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

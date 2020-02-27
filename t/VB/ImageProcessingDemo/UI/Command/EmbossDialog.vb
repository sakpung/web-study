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
   'will be used for the EmbossCommand

   Partial Public Class EmbossDialog : Inherits Form
      Private _EmbossCommand As EmbossCommand
      Private _Depth As Integer

      Public Sub New()
         InitializeComponent()
         _EmbossCommand = New EmbossCommand()

         'Set command default values
         InitializeUI()
      End Sub

      Public Property Embosscommand() As EmbossCommand
         Get
            'Update command values
            UpdateCommand()
            Return _EmbossCommand
         End Get
         Set(ByVal value As EmbossCommand)
            _EmbossCommand = value
            InitializeUI()
         End Set
      End Property

      Private Sub InitializeUI()

         Dim names As String()
         names = System.Enum.GetNames(GetType(EmbossCommandDirection))
         For Each name As String In names
            _cmbDirection.Items.Add(name)
         Next name
         _cmbDirection.SelectedIndex = _cmbDirection.Items.IndexOf(_EmbossCommand.Direction.ToString())

         _Depth = 500
         _txbDepth.Text = _Depth.ToString()
      End Sub

      Private Sub UpdateCommand()
         If _txbDepth.Text <> "" Then
            _EmbossCommand.Depth = Convert.ToInt32(_txbDepth.Text)
         End If

         _EmbossCommand.Direction = TranslateDirection()
      End Sub


      Public Function TranslateDirection() As EmbossCommandDirection
         Select Case _cmbDirection.SelectedIndex
            Case 0
               Return EmbossCommandDirection.North
            Case 1
               Return EmbossCommandDirection.NorthEast
            Case 2
               Return EmbossCommandDirection.East
            Case 3
               Return EmbossCommandDirection.SouthEast
            Case 4
               Return EmbossCommandDirection.South
            Case 5
               Return EmbossCommandDirection.SouthWest
            Case 6
               Return EmbossCommandDirection.West
            Case 7
               Return EmbossCommandDirection.NorthWest
            Case Else
               Return EmbossCommandDirection.North
         End Select
      End Function

      Private Sub _tbDepth_Scroll(ByVal sender As Object, ByVal e As EventArgs) Handles _tbDepth.Scroll
         _txbDepth.Text = _tbDepth.Value.ToString()
      End Sub

      Private Sub _txbDepth_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _txbDepth.TextChanged
         Try
            _txbDepth.Text = MainForm.IsValidNumber(_txbDepth.Text, 0, 1000)

            Dim Val As Integer = Integer.Parse(_txbDepth.Text)
            If Val >= _tbDepth.Minimum AndAlso Val <= _tbDepth.Maximum Then
               _tbDepth.Value = Val
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
         InitializeUI()
         Me.DialogResult = DialogResult.Cancel
      End Sub

   End Class
End Namespace

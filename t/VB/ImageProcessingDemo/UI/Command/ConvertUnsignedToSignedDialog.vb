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
Imports Leadtools.ImageProcessing.Core

Namespace ImageProcessingDemo
   'This dialog is used to allow the user to specify values which
   'will be used for the ConvertUnsignedToSignedCommand

   Partial Public Class ConvertUnsignedToSignedDialog : Inherits Form
      Private _ConvertUnsignedToSignedCommand As ConvertUnsignedToSignedCommand

      Public Sub New()
         InitializeComponent()
         _ConvertUnsignedToSignedCommand = New ConvertUnsignedToSignedCommand()

         'Set command default values
         InitializeUI()
      End Sub

      Public Property ConvertUnsignedToSignedCommand() As ConvertUnsignedToSignedCommand
         Get
            'Update command values
            UpdateCommand()
            Return _ConvertUnsignedToSignedCommand
         End Get
         Set(ByVal value As ConvertUnsignedToSignedCommand)
            _ConvertUnsignedToSignedCommand = value
            InitializeUI()
         End Set
      End Property

      Private Sub InitializeUI()

         Dim names As String()
         names = System.Enum.GetNames(GetType(ConvertUnsignedToSignedCommandType))
         For Each name As String In names
            _cmbType.Items.Add(name)
         Next name
         _cmbType.SelectedIndex = _cmbType.Items.IndexOf(_ConvertUnsignedToSignedCommand.Type.ToString())
      End Sub

      Private Sub UpdateCommand()
         _ConvertUnsignedToSignedCommand.Type = TranslateType()
      End Sub

      Private Function TranslateType() As ConvertUnsignedToSignedCommandType
         Select Case _cmbType.SelectedIndex
            Case 0
               Return ConvertUnsignedToSignedCommandType.ProcessRangeOnly
            Case 1
               Return ConvertUnsignedToSignedCommandType.ProcessOutSideRange
            Case Else
               Return ConvertUnsignedToSignedCommandType.ProcessRangeOnly

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
   End Class
End Namespace

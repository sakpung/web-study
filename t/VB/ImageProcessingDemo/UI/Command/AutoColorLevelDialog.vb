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
   'will be used for the AutoColorLevelCommand
   Partial Public Class AutoColorLevelDialog : Inherits Form
      Private _AutoColorLevelCommand As AutoColorLevelCommand
      Private _BlackClip, _WhiteClip As Integer

      Public Sub New()
         InitializeComponent()
         _AutoColorLevelCommand = New AutoColorLevelCommand()
         _BlackClip = 50
         _WhiteClip = 50
         'Set command default values
         InitializeUI()

      End Sub

      Public Property AutoColorLevelCommand() As AutoColorLevelCommand
         Get
            'Update command values
            UpdateCommand()
            Return _AutoColorLevelCommand
         End Get
         Set(ByVal value As AutoColorLevelCommand)
            _AutoColorLevelCommand = value
            InitializeUI()
         End Set
      End Property

      Private Sub InitializeUI()
         Dim names As String()
         names = System.Enum.GetNames(GetType(AutoColorLevelCommandFlags))
         For Each name As String In names
            'if(name != "None")
            _cmbFlag.Items.Add(name)
         Next name
         _cmbFlag.SelectedIndex = 0

         names = System.Enum.GetNames(GetType(AutoColorLevelCommandType))
         For Each name As String In names
            If name <> "None" Then
               _cmbType.Items.Add(name)
            End If
         Next name
         _cmbType.SelectedIndex = 0

         _numBlackClip.Value = _BlackClip
         _numWhiteClip.Value = _WhiteClip
      End Sub

      Private Sub UpdateCommand()
         _BlackClip = Convert.ToInt32(_numBlackClip.Value)
         _WhiteClip = Convert.ToInt32(_numWhiteClip.Value)

         _AutoColorLevelCommand.BlackClip = _BlackClip
         _AutoColorLevelCommand.WhiteClip = _WhiteClip
         _AutoColorLevelCommand.Flag = TranslateFlag()
         _AutoColorLevelCommand.Type = TranslateType()
      End Sub

      Public Function TranslateType() As AutoColorLevelCommandType
         Select Case _cmbFlag.SelectedIndex
            Case 0
               Return AutoColorLevelCommandType.Level
            Case 1
               Return AutoColorLevelCommandType.Contrast
            Case 2
               Return AutoColorLevelCommandType.Intensity
            Case Else
               Return AutoColorLevelCommandType.Level
         End Select
      End Function

      Public Function TranslateFlag() As AutoColorLevelCommandFlags
         Select Case _cmbFlag.SelectedIndex
            Case 0
               Return AutoColorLevelCommandFlags.None
            Case 1
               Return AutoColorLevelCommandFlags.NoProcess
            Case Else
               Return AutoColorLevelCommandFlags.None
         End Select
      End Function

      Private Sub _numBlackClip_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _numBlackClip.ValueChanged
         _tbBlackClip.Value = Convert.ToInt32(_numBlackClip.Value)
      End Sub

      Private Sub _numWhiteClip_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _numWhiteClip.ValueChanged
         _tbWhiteClip.Value = Convert.ToInt32(_numWhiteClip.Value)
      End Sub

      Private Sub _tbBlackClip_Scroll(ByVal sender As Object, ByVal e As EventArgs) Handles _tbBlackClip.Scroll
         _numBlackClip.Value = _tbBlackClip.Value
      End Sub

      Private Sub _tbWhiteClip_Scroll(ByVal sender As Object, ByVal e As EventArgs) Handles _tbWhiteClip.Scroll
         _numWhiteClip.Value = _tbWhiteClip.Value
      End Sub

      Private Sub _numBlackClip_Leave(ByVal sender As Object, ByVal e As EventArgs) Handles _numBlackClip.Leave
         DialogUtilities.NumericOnLeave(sender)
      End Sub

      Private Sub _numWhiteClip_Leave(ByVal sender As Object, ByVal e As EventArgs) Handles _numWhiteClip.Leave
         DialogUtilities.NumericOnLeave(sender)
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

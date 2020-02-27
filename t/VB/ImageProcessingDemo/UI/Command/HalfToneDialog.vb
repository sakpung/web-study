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
   'will be used for the HalfToneCommand

   Partial Public Class HalfToneDialog : Inherits Form
      Private _HalfToneCommand As HalfToneCommand
      Private _Angle, _Dimension As Integer
      Public UserDefined As Boolean

      Public Sub New()
         InitializeComponent()
         _HalfToneCommand = New HalfToneCommand()

         'Set command default values
         _Angle = 0
         _Dimension = 1
         UserDefined = False
         InitializeUI()
      End Sub

      Public Property HalfToneCommand() As HalfToneCommand
         Get
            'Update command values
            UpdateCommand()
            Return _HalfToneCommand
         End Get
         Set(ByVal value As HalfToneCommand)
            _HalfToneCommand = value
            InitializeUI()
         End Set
      End Property

      Private Sub InitializeUI()
         Dim names As String()
         names = System.Enum.GetNames(GetType(HalfToneCommandType))
         For Each name As String In names
            _cmbType.Items.Add(name)
         Next name
         _cmbType.SelectedIndex = _cmbType.Items.IndexOf(_HalfToneCommand.Type.ToString())

         _numDimension.Value = _Dimension
         _numAngle.Value = _Angle
      End Sub

      Private Sub UpdateCommand()
         _HalfToneCommand.Angle = Convert.ToInt32(_numAngle.Value)
         _HalfToneCommand.Dimension = Convert.ToInt32(_numDimension.Value)
         _HalfToneCommand.Type = TranslateType()
      End Sub

      Public Function TranslateType() As HalfToneCommandType
         Select Case _cmbType.SelectedIndex
            Case 0
               Return HalfToneCommandType.Print
            Case 1
               Return HalfToneCommandType.View
            Case 2
               Return HalfToneCommandType.Rectangular
            Case 3
               Return HalfToneCommandType.Circular
            Case 4
               Return HalfToneCommandType.Elliptical
            Case 5
               Return HalfToneCommandType.Random
            Case 6
               Return HalfToneCommandType.Linear
            Case 7
               Return HalfToneCommandType.UserDefined
            Case Else
               Return HalfToneCommandType.Print
         End Select
      End Function

      Private Sub _tbAngle_Scroll(ByVal sender As Object, ByVal e As EventArgs) Handles _tbAngle.Scroll
         _numAngle.Value = _tbAngle.Value
      End Sub

      Private Sub _tbDimension_Scroll(ByVal sender As Object, ByVal e As EventArgs) Handles _tbDimension.Scroll
         _numDimension.Value = _tbDimension.Value
      End Sub

      Private Sub _cmbType_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _cmbType.SelectedIndexChanged
         Dim str As String = _cmbType.SelectedItem.ToString()

         If (str = "Rectangular") Or (str = "Circular") Or (str = "Random") Or (str = "UserDefined") Then
            _gbAngle.Enabled = False
         Else
            _gbAngle.Enabled = True
         End If

         If (str = "View") Or (str = "Print") Then
            _gbDimension.Enabled = False
         Else
            _gbDimension.Enabled = True
         End If

         If str = "UserDefined" Then
            UserDefined = True
         Else
            UserDefined = False
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

      Private Sub _numAngle_Leave(ByVal sender As Object, ByVal e As EventArgs) Handles _numAngle.Leave
         DialogUtilities.NumericOnLeave(sender)
      End Sub

      Private Sub _numDimension_Leave(ByVal sender As Object, ByVal e As EventArgs) Handles _numDimension.Leave
         DialogUtilities.NumericOnLeave(sender)
      End Sub

      Private Sub _numAngle_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _numAngle.ValueChanged
         _tbAngle.Value = Convert.ToInt32(_numAngle.Value)
      End Sub

      Private Sub _numDimension_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _numDimension.ValueChanged
         _tbDimension.Value = Convert.ToInt32(_numDimension.Value)
      End Sub
   End Class
End Namespace

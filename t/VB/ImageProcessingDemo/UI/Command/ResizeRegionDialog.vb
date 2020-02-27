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
   'will be used for the ResizeRegionCommand

   Partial Public Class ResizeRegionDialog : Inherits Form
      Private _ResizeRegionCommand As ResizeRegionCommand
      Private _Dimension As Integer
      Private _AsFrame As Boolean

      Public Sub New()
         InitializeComponent()
         _ResizeRegionCommand = New ResizeRegionCommand()
         _Dimension = 1
         _AsFrame = True

         'Set command default values
         InitializeUI()
      End Sub

      Public Property ResizeRegionCommand() As ResizeRegionCommand
         Get
            'Update command values
            UpdateCommand()
            Return _ResizeRegionCommand
         End Get
         Set(ByVal value As ResizeRegionCommand)
            _ResizeRegionCommand = value
            InitializeUI()
         End Set
      End Property
      Private Sub InitializeUI()
         Dim names As String()
         names = System.Enum.GetNames(GetType(ResizeRegionCommandType))
         For Each name As String In names
            _cmbType.Items.Add(name)
         Next name
         _cmbType.SelectedIndex = _cmbType.Items.IndexOf(_ResizeRegionCommand.Type.ToString())

         _Dimension = 20
         _AsFrame = True

         _txbDimension.Text = _Dimension.ToString()
         _chkFrame.Checked = _AsFrame
      End Sub

      Private Sub UpdateCommand()
         _Dimension = Convert.ToInt32(_txbDimension.Text)
         _AsFrame = _chkFrame.Checked

         _ResizeRegionCommand.Dimension = _Dimension
         _ResizeRegionCommand.AsFrame = _AsFrame
         _ResizeRegionCommand.Type = TranslateType()
      End Sub
      Private Function TranslateType() As ResizeRegionCommandType
         Select Case _cmbType.SelectedIndex
            Case 0
               Return ResizeRegionCommandType.ExpandRegion
            Case 1
               Return ResizeRegionCommandType.ContractRegion
            Case Else
               Return ResizeRegionCommandType.ExpandRegion
         End Select
      End Function
      Private Sub _tbDimension_Scroll(ByVal sender As Object, ByVal e As EventArgs) Handles _tbDimension.Scroll
         _txbDimension.Text = _tbDimension.Value.ToString()
      End Sub

      Private Sub _txbDimension_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _txbDimension.TextChanged
         Try
            _txbDimension.Text = MainForm.IsValidNumber(_txbDimension.Text, 1, 500)

            Dim Val As Integer = Integer.Parse(_txbDimension.Text)
            If Val >= _tbDimension.Minimum AndAlso Val <= _tbDimension.Maximum Then
               _tbDimension.Value = Val
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

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
Imports Leadtools.ImageProcessing
Imports Leadtools.ImageProcessing.Effects

Namespace ImageProcessingDemo
   'This dialog is used to allow the user to specify values which
   'will be used for the AddNoiseCommand
   Partial Public Class AddNoiseDialog : Inherits Form
      Private _AddNoiseCommand As AddNoiseCommand = Nothing

      Public Sub New()
         InitializeComponent()
         _AddNoiseCommand = New AddNoiseCommand()
         'Set command default values
         InitializeUI()
      End Sub

      Public Property AddNoisecommand() As AddNoiseCommand
         Get
            'Update command values
            UpdateCommand()
            Return _AddNoiseCommand
         End Get
         Set(ByVal value As AddNoiseCommand)
            _AddNoiseCommand = value
            InitializeUI()
         End Set
      End Property

      Private Sub InitializeUI()
         _AddNoiseCommand.Channel = RasterColorChannel.Red
         _AddNoiseCommand.Range = 250
         _numRange.Value = _AddNoiseCommand.Range
         _rbRed.Checked = True

      End Sub

      Private Sub UpdateCommand()
         If _rbRed.Checked Then
            _AddNoiseCommand.Channel = RasterColorChannel.Red
         End If
         If _rbGreen.Checked Then
            _AddNoiseCommand.Channel = RasterColorChannel.Green
         End If
         If _rbBlue.Checked Then
            _AddNoiseCommand.Channel = RasterColorChannel.Blue
         End If
         If _rbMaster.Checked Then
            _AddNoiseCommand.Channel = RasterColorChannel.Master
         End If

         _AddNoiseCommand.Range = Convert.ToInt32(_numRange.Value)

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

      Private Sub _numRange_Leave(ByVal sender As Object, ByVal e As EventArgs) Handles _numRange.Leave
         DialogUtilities.NumericOnLeave(sender)
      End Sub

   End Class
End Namespace

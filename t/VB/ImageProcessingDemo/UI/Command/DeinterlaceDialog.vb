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
   'will be used for the DeinterlaceCommand

   Partial Public Class DeinterlaceDialog : Inherits Form
      Private _DeinterlaceCommand As DeinterlaceCommand

      Public Sub New()
         InitializeComponent()
         _DeinterlaceCommand = New DeinterlaceCommand()

         'Set command default values
         InitializeUI()
      End Sub

      Public Property DeinterlaceCommand() As DeinterlaceCommand
         Get
            'Update command values
            UpdateCommand()
            Return _DeinterlaceCommand
         End Get
         Set(ByVal value As DeinterlaceCommand)
            _DeinterlaceCommand = value
            InitializeUI()
         End Set
      End Property

      Private Sub InitializeUI()
         If (_DeinterlaceCommand.Flags And DeinterlaceCommandFlags.Smooth) = DeinterlaceCommandFlags.Smooth Then
            _rbSmooth.Checked = True
         End If
         If (_DeinterlaceCommand.Flags And DeinterlaceCommandFlags.Normal) = DeinterlaceCommandFlags.Normal Then
            _rbNormal.Checked = True
         End If
         If (_DeinterlaceCommand.Flags And DeinterlaceCommandFlags.Odd) = DeinterlaceCommandFlags.Odd Then
            _rbOddLines.Checked = True
         End If
         If (_DeinterlaceCommand.Flags And DeinterlaceCommandFlags.Even) = DeinterlaceCommandFlags.Even Then
            _rbEvenLines.Checked = True
         End If
      End Sub

      Private Sub UpdateCommand()
         _DeinterlaceCommand.Flags = CType(0, DeinterlaceCommandFlags)
         If _rbSmooth.Checked Then
            _DeinterlaceCommand.Flags = _DeinterlaceCommand.Flags Or DeinterlaceCommandFlags.Smooth
         End If
         If _rbNormal.Checked Then
            _DeinterlaceCommand.Flags = _DeinterlaceCommand.Flags Or DeinterlaceCommandFlags.Normal
         End If
         If _rbOddLines.Checked Then
            _DeinterlaceCommand.Flags = _DeinterlaceCommand.Flags Or DeinterlaceCommandFlags.Odd
         End If
         If _rbEvenLines.Checked Then
            _DeinterlaceCommand.Flags = _DeinterlaceCommand.Flags Or DeinterlaceCommandFlags.Even
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

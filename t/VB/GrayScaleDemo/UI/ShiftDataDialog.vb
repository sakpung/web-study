' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************

Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms

Imports Leadtools.ImageProcessing.Core
Imports GrayScaleDemo.Leadtools.Demos
Imports System

Partial Public Class ShiftDataDialog
   Inherits Form
   Private Shared _destinationBitsPerPixel As Integer
   Private Shared _destinationLowBit As Integer
   Private Shared _sourceLowBit As Integer
   Private Shared _sourceHighBit As Integer

   Public DestinationBitsPerPixel As Integer
   Public DestinationLowBit As Integer
   Public SourceLowBit As Integer
   Public SourceHighBit As Integer

   Public Sub New(imageBpp As Integer, isSegned As Boolean)
      InitializeComponent()
      _numSourceHighBit.Maximum = imageBpp - 1
      _numSourceLowBit.Maximum = imageBpp - 1

      If Not isSegned Then
         _cmbDestBPP.Items.Add("8")
      End If
      _cmbDestBPP.Items.Add("12")
      _cmbDestBPP.Items.Add("16")
   End Sub

   Private Sub ShiftDataDialog_Load(sender As Object, e As EventArgs) Handles Me.Load
      Dim cmd As New ShiftDataCommand()
      _destinationBitsPerPixel = 8
      _destinationLowBit = cmd.DestinationLowBit
      _sourceLowBit = cmd.SourceLowBit
      _sourceHighBit = cmd.SourceHighBit

      DestinationBitsPerPixel = _destinationBitsPerPixel
      DestinationLowBit = _destinationLowBit
      SourceLowBit = _sourceLowBit
      SourceHighBit = _sourceHighBit

      Try
         _numDestLowBit.Value = DestinationLowBit
         _numSourceHighBit.Value = SourceHighBit
         _numSourceLowBit.Value = SourceLowBit

         Select Case DestinationBitsPerPixel
            Case 8
               _cmbDestBPP.SelectedIndex = 0
               Exit Select
            Case 12
               _cmbDestBPP.SelectedIndex = 1
               Exit Select
            Case 16
               _cmbDestBPP.SelectedIndex = 2
               Exit Select
         End Select
      Catch generatedExceptionName As Exception
         'ex
         _cmbDestBPP.SelectedIndex = 0
         _numDestLowBit.Value = 0
         _numSourceHighBit.Value = 7
         _numSourceLowBit.Value = 0
      End Try
   End Sub

   Private Sub _btnOk_Click(sender As Object, e As EventArgs) Handles _btnOk.Click

      If _numSourceHighBit.Value <= _numSourceLowBit.Value Then
         Messager.ShowWarning(Me, _lblMsg.Text)
         DialogResult = DialogResult.None
         Return
      End If

      DestinationBitsPerPixel = Integer.Parse(_cmbDestBPP.Text)
      DestinationLowBit = CInt(_numDestLowBit.Value)
      SourceLowBit = CInt(_numSourceLowBit.Value)
      SourceHighBit = CInt(_numSourceHighBit.Value)

      _destinationBitsPerPixel = DestinationBitsPerPixel
      _destinationLowBit = DestinationLowBit
      _sourceLowBit = SourceLowBit
      _sourceHighBit = SourceHighBit
   End Sub

   Private Sub _cmbDestBPP_SelectedIndexChanged(sender As Object, e As EventArgs) Handles _cmbDestBPP.SelectedIndexChanged
      _numDestLowBit.Maximum = Integer.Parse(_cmbDestBPP.Text) - 2
   End Sub

End Class

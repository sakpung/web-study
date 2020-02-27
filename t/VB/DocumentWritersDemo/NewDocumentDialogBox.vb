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
Imports System

Namespace DocumentWritersDemo
   Partial Public Class NewDocumentDialogBox
      Inherits Form
      ' The document width in inches
      Private _documentWidth As Single
      ' The document height in inches
      Private _documentHeight As Single
      ' The document resolution in DPI
      Private _documentResolution As Integer

      Public Sub New(width As Single, height As Single, resolution As Integer)
         InitializeComponent()

         ' Set the initial variables
         _documentWidth = width

         If _documentWidth <= 0 Then
            _documentWidth = 1
         End If

         _documentHeight = height
         If _documentHeight <= 0 Then
            _documentHeight = 1
         End If

         _documentResolution = resolution

         _widthNumericUpDown.Value = CDec(_documentWidth)
         _heightNumericUpDown.Value = CDec(_documentHeight)

         ' Find the resolution
         _resolutionComboBox.SelectedItem = _documentResolution.ToString()
         If _resolutionComboBox.SelectedIndex = -1 Then
            _resolutionComboBox.SelectedItem = "300"
         End If

         _documentResolution = Integer.Parse(_resolutionComboBox.SelectedItem.ToString())

         UpdatePhysicalSize()
      End Sub

      Public ReadOnly Property DocumentWidth() As Single
         Get
            Return _documentWidth
         End Get
      End Property

      Public ReadOnly Property DocumentHeight() As Single
         Get
            Return _documentHeight
         End Get
      End Property

      Public ReadOnly Property DocumentResolution() As Integer
         Get
            Return _documentResolution
         End Get
      End Property

      Private Sub UpdatePhysicalSize()
         If _resolutionComboBox.SelectedIndex <> -1 Then
            Dim width As Single = CSng(_widthNumericUpDown.Value)
            Dim height As Single = CSng(_heightNumericUpDown.Value)
            Dim resolution As Integer = Integer.Parse(_resolutionComboBox.SelectedItem.ToString())

            Dim widthInPixels As Integer = CInt(Math.Truncate(width * resolution))
            Dim heightInPixels As Integer = CInt(Math.Truncate(height * resolution))

            _physicalSizeValueLabel.Text = String.Format("{0} by {1}", widthInPixels, heightInPixels)
         End If
      End Sub

      Private Sub _resolutionComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles _resolutionComboBox.SelectedIndexChanged
         UpdatePhysicalSize()
      End Sub

      Private Sub _numericUpDown_ValueChanged(sender As Object, e As EventArgs) Handles _heightNumericUpDown.ValueChanged, _widthNumericUpDown.ValueChanged
         UpdatePhysicalSize()
      End Sub

      Private Sub _defaultButton_Click(sender As Object, e As EventArgs) Handles _defaultButton.Click
         _widthNumericUpDown.Value = CDec(8.5F)
         _heightNumericUpDown.Value = 11
         _resolutionComboBox.SelectedItem = "300"
      End Sub

      Private Sub _okButton_Click(sender As Object, e As EventArgs) Handles _okButton.Click
         _documentWidth = CSng(_widthNumericUpDown.Value)
         _documentHeight = CSng(_heightNumericUpDown.Value)
         _documentResolution = Integer.Parse(_resolutionComboBox.SelectedItem.ToString())
      End Sub
   End Class
End Namespace

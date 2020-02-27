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

Imports Leadtools.Ocr
Imports System

Namespace OcrDemo
   Partial Public Class SaveRecognizedXmlDialog
      Inherits Form
      Private _outputOptions As OcrXmlOutputOptions = OcrXmlOutputOptions.None
      Private _fileName As String = Nothing

      Private Structure MyMode
         Public Name As String
         Public Options As OcrXmlOutputOptions

         Public Sub New(n As String, o As OcrXmlOutputOptions)
            Name = n
            Options = o
         End Sub

         Public Overrides Function ToString() As String
            Return Name
         End Function
      End Structure

      Public Sub New()
         InitializeComponent()
      End Sub

      Protected Overrides Sub OnLoad(e As EventArgs)
         If Not DesignMode Then
            Dim modes As MyMode() = {New MyMode("Save words", OcrXmlOutputOptions.None), New MyMode("Save characters", OcrXmlOutputOptions.Characters), New MyMode("Save characters with attributes", OcrXmlOutputOptions.Characters Or OcrXmlOutputOptions.CharacterAttributes)}

            For Each mode As MyMode In modes
               _modeComboBox.Items.Add(mode)
            Next

            _modeComboBox.SelectedIndex = 0

            UpdateMyControls()
         End If

         MyBase.OnLoad(e)
      End Sub

      Public ReadOnly Property FileName() As String
         Get
            Return _fileName
         End Get
      End Property

      Public ReadOnly Property OutputOptions() As OcrXmlOutputOptions
         Get
            Return _outputOptions
         End Get
      End Property

      Private Sub UpdateMyControls()
         _okButton.Enabled = Not String.IsNullOrEmpty(_fileNameTextBox.Text.Trim())
      End Sub

      Private Sub _fileNameTextBox_TextChanged(sender As Object, e As EventArgs) Handles _fileNameTextBox.TextChanged
         UpdateMyControls()
      End Sub

      Private Sub _fileNameButton_Click(sender As Object, e As EventArgs) Handles _fileNameButton.Click
         Using dlg As New SaveFileDialog()
            dlg.Filter = "XML Files|*.xml|All Files|*.*"
            dlg.DefaultExt = "xml"
            If dlg.ShowDialog(Me) = DialogResult.OK Then
               _fileNameTextBox.Text = dlg.FileName
            End If
         End Using
      End Sub

      Private Sub _okButton_Click(sender As Object, e As EventArgs) Handles _okButton.Click
         _outputOptions = CType(_modeComboBox.SelectedItem, MyMode).Options
         _fileName = _fileNameTextBox.Text
      End Sub
   End Class
End Namespace

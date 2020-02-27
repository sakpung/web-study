' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Drawing
Imports System.Data
Imports System.Linq
Imports System.Text
Imports System.Windows.Forms

Namespace Ocr2SharePointDemo
   Partial Public Class SelectImageDocumentControl : Inherits UserControl
      Public Sub New()
         InitializeComponent()
      End Sub

      Private _imageDocumentFileName As String
      <DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
      Public ReadOnly Property ImageDocumentFileName() As String
         Get
            Return _imageDocumentFileName
         End Get
      End Property

      Private _mainForm As MainForm
      Public Sub SetOwner(ByVal mainForm As MainForm, ByVal imageDocumentFileName_Renamed As String)
         _mainForm = mainForm
         _imageDocumentFileName = imageDocumentFileName_Renamed
         _fileNameTextBox.Text = _imageDocumentFileName

         Dim items As MyDocumentFormatItem() = MyDocumentFormatItem.DefaultItems
         For Each item As MyDocumentFormatItem In items
            _formatComboBox.Items.Add(item)
         Next item

         _formatComboBox.SelectedIndex = 0
      End Sub

      Private Sub _browseButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _browseButton.Click
         Using dlg As OpenFileDialog = New OpenFileDialog()
            dlg.Filter = "Common Images Files|*.tif;*.tiff;*.jpg;*.jpeg;*.png;*.pdf|All Files|*.*"
            If dlg.ShowDialog(Me) = DialogResult.OK Then
               _fileNameTextBox.Text = dlg.FileName
            End If
         End Using
      End Sub

      Private Sub _fileNameTextBox_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _fileNameTextBox.TextChanged
         _imageDocumentFileName = _fileNameTextBox.Text
         _mainForm.UpdateUIState()
      End Sub

      Public Function GetSelectedDocumentFormat() As MyDocumentFormat
         Dim item As MyDocumentFormatItem = CType(_formatComboBox.SelectedItem, MyDocumentFormatItem)
         Return item.FormatType
      End Function
   End Class
End Namespace

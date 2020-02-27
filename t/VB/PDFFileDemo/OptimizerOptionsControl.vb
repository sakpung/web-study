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

Imports Leadtools
Imports Leadtools.Pdf

Namespace PDFFileDemo
   Partial Public Class OptimizerOptionsControl : Inherits UserControl
      Public Sub New()
         InitializeComponent()
      End Sub

      Public Sub SetOptimizerOptions(ByVal optimizerOptions As PDFOptimizerOptions)
         ' PDF optimizer options
         _autoOptimizerModeComboBox.Items.Clear()
         Dim a As Array = System.Enum.GetValues(GetType(PDFAutoOptimizerMode))
         For Each i As PDFAutoOptimizerMode In a
            _autoOptimizerModeComboBox.Items.Add(i)
         Next i
         _autoOptimizerModeComboBox.SelectedItem = optimizerOptions.AutoOptimizerMode

         _colorImagesDownsamplingModeComboBox.Items.Clear()
         _grayscaleImagesDownsamplingModeComboBox.Items.Clear()
         _monoImagesDownsamplingModeComboBox.Items.Clear()
         a = System.Enum.GetValues(GetType(PDFDownsamplingMode))
         For Each i As PDFDownsamplingMode In a
            _colorImagesDownsamplingModeComboBox.Items.Add(i)
            _grayscaleImagesDownsamplingModeComboBox.Items.Add(i)
            _monoImagesDownsamplingModeComboBox.Items.Add(i)
         Next i

         _colorImagesDownsamplingModeComboBox.SelectedItem = optimizerOptions.ColorImageDownsamplingMode
         _grayscaleImagesDownsamplingModeComboBox.SelectedItem = optimizerOptions.GrayImageDownsamplingMode
         _monoImagesDownsamplingModeComboBox.SelectedItem = optimizerOptions.MonoImageDownsamplingMode

         _colorImagesCompressionComboBox.Items.Clear()
         Dim supportedColorImageFormats As RasterImageFormat() = PDFOptimizerOptions.SupportedColorImageFormats
         For Each i As RasterImageFormat In supportedColorImageFormats
            _colorImagesCompressionComboBox.Items.Add(i)
         Next i
         _colorImagesCompressionComboBox.SelectedItem = optimizerOptions.ColorImageCompression

         _grayscaleImagesCompressionComboBox.Items.Clear()
         Dim supportedGrayImageFormats As RasterImageFormat() = PDFOptimizerOptions.SupportedGrayImageFormats
         For Each i As RasterImageFormat In supportedGrayImageFormats
            _grayscaleImagesCompressionComboBox.Items.Add(i)
         Next i
         _grayscaleImagesCompressionComboBox.SelectedItem = optimizerOptions.GrayImageCompression

         _monoImagesCompressionComboBox.Items.Clear()
         Dim supportedMonoImageFormats As RasterImageFormat() = PDFOptimizerOptions.SupportedMonoImageFormats
         For Each i As RasterImageFormat In supportedMonoImageFormats
            _monoImagesCompressionComboBox.Items.Add(i)
         Next i
         _monoImagesCompressionComboBox.SelectedItem = optimizerOptions.MonoImageCompression

         _colorImagesDownsamplingFactorNumericUpDown.Value = CDec(optimizerOptions.ColorImageDownsampleFactor)
         _grayscaleImagesDownsamplingFactorNumericUpDown.Value = CDec(optimizerOptions.GrayImageDownsampleFactor)
         _monoImagesDownsamplingFactorNumericUpDown.Value = CDec(optimizerOptions.MonoImageDownsampleFactor)

         _colorImagesDpiTextBox.Text = optimizerOptions.ColorImageDPI.ToString()
         _grayscaleImagesDpiTextBox.Text = optimizerOptions.GrayImageDPI.ToString()
         _monoImagesDpiTextBox.Text = optimizerOptions.MonoImageDPI.ToString()

         _embedAllFontsCheckBox.Checked = optimizerOptions.EmbedAllFonts
         _subsetAllEmbeddedFontsCheckBox.Checked = optimizerOptions.SubsetFonts
      End Sub

      Public Sub UpdateOptimizerOptions(ByVal optimizerOptions As PDFOptimizerOptions)
         optimizerOptions.AutoOptimizerMode = CType(_autoOptimizerModeComboBox.SelectedItem, PDFAutoOptimizerMode)
         If optimizerOptions.AutoOptimizerMode <> PDFAutoOptimizerMode.Customized Then
            Return
         End If

         optimizerOptions.ColorImageDownsamplingMode = CType(_colorImagesDownsamplingModeComboBox.SelectedItem, PDFDownsamplingMode)
         optimizerOptions.GrayImageDownsamplingMode = CType(_grayscaleImagesDownsamplingModeComboBox.SelectedItem, PDFDownsamplingMode)
         optimizerOptions.MonoImageDownsamplingMode = CType(_monoImagesDownsamplingModeComboBox.SelectedItem, PDFDownsamplingMode)

         optimizerOptions.ColorImageDownsampleFactor = CDbl(_colorImagesDownsamplingFactorNumericUpDown.Value)
         optimizerOptions.GrayImageDownsampleFactor = CDbl(_grayscaleImagesDownsamplingFactorNumericUpDown.Value)
         optimizerOptions.MonoImageDownsampleFactor = CDbl(_monoImagesDownsamplingFactorNumericUpDown.Value)

         Dim value As Integer
         If Integer.TryParse(_colorImagesDpiTextBox.Text, value) Then
            optimizerOptions.ColorImageDPI = value
         End If

         If Integer.TryParse(_grayscaleImagesDpiTextBox.Text, value) Then
            optimizerOptions.GrayImageDPI = value
         End If

         If Integer.TryParse(_monoImagesDpiTextBox.Text, value) Then
            optimizerOptions.MonoImageDPI = value
         End If

         optimizerOptions.ColorImageCompression = CType(_colorImagesCompressionComboBox.SelectedItem, RasterImageFormat)
         optimizerOptions.GrayImageCompression = CType(_grayscaleImagesCompressionComboBox.SelectedItem, RasterImageFormat)
         optimizerOptions.MonoImageCompression = CType(_monoImagesCompressionComboBox.SelectedItem, RasterImageFormat)

         optimizerOptions.EmbedAllFonts = _embedAllFontsCheckBox.Checked
         optimizerOptions.SubsetFonts = _subsetAllEmbeddedFontsCheckBox.Checked
      End Sub

      Private Sub UpdateUIState()
         Dim autoOptimizerMode As PDFAutoOptimizerMode = CType(_autoOptimizerModeComboBox.SelectedItem, PDFAutoOptimizerMode)
         _imageSettingsGroupBox.Enabled = (autoOptimizerMode = PDFAutoOptimizerMode.Customized)
         _fontsGroupBox.Enabled = (autoOptimizerMode = PDFAutoOptimizerMode.Customized)
      End Sub

      Private Sub _autoOptimizerModeComboBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _autoOptimizerModeComboBox.SelectedIndexChanged
         UpdateUIState()
      End Sub
   End Class
End Namespace

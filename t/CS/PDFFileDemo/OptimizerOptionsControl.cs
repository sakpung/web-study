// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Leadtools;
using Leadtools.Pdf;

namespace PDFFileDemo
{
   public partial class OptimizerOptionsControl : UserControl
   {
      public OptimizerOptionsControl()
      {
         InitializeComponent();
      }

#if LEADTOOLS_V19_OR_LATER
      public void SetOptimizerOptions(PDFOptimizerOptions optimizerOptions)
      {
         // PDF optimizer options
         _autoOptimizerModeComboBox.Items.Clear();
         Array a = Enum.GetValues(typeof(PDFAutoOptimizerMode));
         foreach (PDFAutoOptimizerMode i in a)
            _autoOptimizerModeComboBox.Items.Add(i);
         _autoOptimizerModeComboBox.SelectedItem = optimizerOptions.AutoOptimizerMode;

         _colorImagesDownsamplingModeComboBox.Items.Clear();
         _grayscaleImagesDownsamplingModeComboBox.Items.Clear();
         _monoImagesDownsamplingModeComboBox.Items.Clear();
         a = Enum.GetValues(typeof(PDFDownsamplingMode));
         foreach (PDFDownsamplingMode i in a)
         {
            _colorImagesDownsamplingModeComboBox.Items.Add(i);
            _grayscaleImagesDownsamplingModeComboBox.Items.Add(i);
            _monoImagesDownsamplingModeComboBox.Items.Add(i);
         }

         _colorImagesDownsamplingModeComboBox.SelectedItem = optimizerOptions.ColorImageDownsamplingMode;
         _grayscaleImagesDownsamplingModeComboBox.SelectedItem = optimizerOptions.GrayImageDownsamplingMode;
         _monoImagesDownsamplingModeComboBox.SelectedItem = optimizerOptions.MonoImageDownsamplingMode;

         _colorImagesCompressionComboBox.Items.Clear();
         RasterImageFormat[] supportedColorImageFormats = PDFOptimizerOptions.SupportedColorImageFormats;
         foreach (RasterImageFormat i in supportedColorImageFormats)
            _colorImagesCompressionComboBox.Items.Add(i);
         _colorImagesCompressionComboBox.SelectedItem = optimizerOptions.ColorImageCompression;

         _grayscaleImagesCompressionComboBox.Items.Clear();
         RasterImageFormat[] supportedGrayImageFormats = PDFOptimizerOptions.SupportedGrayImageFormats;
         foreach (RasterImageFormat i in supportedGrayImageFormats)
            _grayscaleImagesCompressionComboBox.Items.Add(i);
         _grayscaleImagesCompressionComboBox.SelectedItem = optimizerOptions.GrayImageCompression;

         _monoImagesCompressionComboBox.Items.Clear();
         RasterImageFormat[] supportedMonoImageFormats = PDFOptimizerOptions.SupportedMonoImageFormats;
         foreach (RasterImageFormat i in supportedMonoImageFormats)
            _monoImagesCompressionComboBox.Items.Add(i);
         _monoImagesCompressionComboBox.SelectedItem = optimizerOptions.MonoImageCompression;

         _colorImagesDownsamplingFactorNumericUpDown.Value = (decimal)optimizerOptions.ColorImageDownsampleFactor;
         _grayscaleImagesDownsamplingFactorNumericUpDown.Value = (decimal)optimizerOptions.GrayImageDownsampleFactor;
         _monoImagesDownsamplingFactorNumericUpDown.Value = (decimal)optimizerOptions.MonoImageDownsampleFactor;

         _colorImagesDpiTextBox.Text = optimizerOptions.ColorImageDPI.ToString();
         _grayscaleImagesDpiTextBox.Text = optimizerOptions.GrayImageDPI.ToString();
         _monoImagesDpiTextBox.Text = optimizerOptions.MonoImageDPI.ToString();

         _embedAllFontsCheckBox.Checked = optimizerOptions.EmbedAllFonts;
         _subsetAllEmbeddedFontsCheckBox.Checked = optimizerOptions.SubsetFonts;
      }

      public void UpdateOptimizerOptions(PDFOptimizerOptions optimizerOptions)
      {
         optimizerOptions.AutoOptimizerMode = (PDFAutoOptimizerMode)_autoOptimizerModeComboBox.SelectedItem;
         if (optimizerOptions.AutoOptimizerMode != PDFAutoOptimizerMode.Customized)
            return;

         optimizerOptions.ColorImageDownsamplingMode = (PDFDownsamplingMode)_colorImagesDownsamplingModeComboBox.SelectedItem;
         optimizerOptions.GrayImageDownsamplingMode = (PDFDownsamplingMode)_grayscaleImagesDownsamplingModeComboBox.SelectedItem;
         optimizerOptions.MonoImageDownsamplingMode = (PDFDownsamplingMode)_monoImagesDownsamplingModeComboBox.SelectedItem;

         optimizerOptions.ColorImageDownsampleFactor = (double)_colorImagesDownsamplingFactorNumericUpDown.Value;
         optimizerOptions.GrayImageDownsampleFactor = (double)_grayscaleImagesDownsamplingFactorNumericUpDown.Value;
         optimizerOptions.MonoImageDownsampleFactor = (double)_monoImagesDownsamplingFactorNumericUpDown.Value;

         int value;
         if (int.TryParse(_colorImagesDpiTextBox.Text, out value))
            optimizerOptions.ColorImageDPI = value;

         if (int.TryParse(_grayscaleImagesDpiTextBox.Text, out value))
            optimizerOptions.GrayImageDPI = value;

         if (int.TryParse(_monoImagesDpiTextBox.Text, out value))
            optimizerOptions.MonoImageDPI = value;

         optimizerOptions.ColorImageCompression = (RasterImageFormat)_colorImagesCompressionComboBox.SelectedItem;
         optimizerOptions.GrayImageCompression = (RasterImageFormat)_grayscaleImagesCompressionComboBox.SelectedItem;
         optimizerOptions.MonoImageCompression = (RasterImageFormat)_monoImagesCompressionComboBox.SelectedItem;

         optimizerOptions.EmbedAllFonts = _embedAllFontsCheckBox.Checked;
         optimizerOptions.SubsetFonts = _subsetAllEmbeddedFontsCheckBox.Checked;
      }

      void UpdateUIState()
      {
         PDFAutoOptimizerMode autoOptimizerMode = (PDFAutoOptimizerMode)_autoOptimizerModeComboBox.SelectedItem;
         _imageSettingsGroupBox.Enabled = (autoOptimizerMode == PDFAutoOptimizerMode.Customized);
         _fontsGroupBox.Enabled = (autoOptimizerMode == PDFAutoOptimizerMode.Customized);
      }
#endif // #if LEADTOOLS_V19_OR_LATER

      private void _autoOptimizerModeComboBox_SelectedIndexChanged(object sender, EventArgs e)
      {
#if LEADTOOLS_V19_OR_LATER
         UpdateUIState();
#endif // #if LEADTOOLS_V19_OR_LATER
      }
   }
}

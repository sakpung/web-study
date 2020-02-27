// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using Leadtools;
using Leadtools.Codecs;

namespace RasterizeDocumentDemo.UserControls
{
   public partial class PdfOptionsControl : UserControl, IOptionsUserControl
   {
      public PdfOptionsControl()
      {
         InitializeComponent();
      }

      /// <summary>
      /// Called by the owner to initialize
      /// </summary>
      public void SetData(RasterCodecs rasterCodecsInstance)
      {
         // First fill the controls with possible values

         _displayDepthComboBox.Items.Add(new Tools.ValueNameItem<int>(1, "1 bits per pixel"));
         _displayDepthComboBox.Items.Add(new Tools.ValueNameItem<int>(4, "4 bits per pixel"));
         _displayDepthComboBox.Items.Add(new Tools.ValueNameItem<int>(8, "8 bits per pixel"));
         _displayDepthComboBox.Items.Add(new Tools.ValueNameItem<int>(24, "24 bits per pixel"));

         _textAlphaComboBox.Items.Add(new Tools.ValueNameItem<int>(1, "Do not use font anti-aliasing"));
         _textAlphaComboBox.Items.Add(new Tools.ValueNameItem<int>(2, "Use 2-bit font anti-aliasing"));
         _textAlphaComboBox.Items.Add(new Tools.ValueNameItem<int>(4, "Use 4-bit font anti-aliasing"));

         _graphicsAlphaComboBox.Items.Add(new Tools.ValueNameItem<int>(1, "Do not use graphics anti-aliasing"));
         _graphicsAlphaComboBox.Items.Add(new Tools.ValueNameItem<int>(2, "Use 2-bit graphics anti-aliasing"));
         _graphicsAlphaComboBox.Items.Add(new Tools.ValueNameItem<int>(4, "Use 4-bit graphics anti-aliasing"));

         // Now set the state of the controls

         CodecsPdfLoadOptions pdfLoadOptions = rasterCodecsInstance.Options.Pdf.Load;

         _useLibFontsCheckBox.Checked = pdfLoadOptions.UseLibFonts;
         _displayDepthComboBox.SelectedItem = Tools.ValueNameItem<int>.SelectItem(pdfLoadOptions.DisplayDepth, _displayDepthComboBox.Items);
         _textAlphaComboBox.SelectedItem = Tools.ValueNameItem<int>.SelectItem(pdfLoadOptions.TextAlpha, _textAlphaComboBox.Items);
         _graphicsAlphaComboBox.SelectedItem = Tools.ValueNameItem<int>.SelectItem(pdfLoadOptions.GraphicsAlpha, _graphicsAlphaComboBox.Items);
         _disableCroppingCheckBox.Checked = pdfLoadOptions.DisableCropping;
         _displayCieColorsCheckBox.Checked = pdfLoadOptions.DisableCieColors;
         _passwordTextBox.Text = pdfLoadOptions.Password;
      }

      /// <summary>
      /// Called by the owner to get the data
      /// </summary>
      public bool GetData(RasterCodecs rasterCodecsInstance)
      {
         CodecsPdfLoadOptions pdfLoadOptions = rasterCodecsInstance.Options.Pdf.Load;

         // Get the PDF load settings
         pdfLoadOptions.UseLibFonts = _useLibFontsCheckBox.Checked;
         if (_displayDepthComboBox.SelectedItem != null)
            pdfLoadOptions.DisplayDepth = Tools.ValueNameItem<int>.GetSelectedItem(_displayDepthComboBox.SelectedItem);

         if (_textAlphaComboBox.SelectedItem != null)
            pdfLoadOptions.TextAlpha = Tools.ValueNameItem<int>.GetSelectedItem(_textAlphaComboBox.SelectedItem);

         if (_graphicsAlphaComboBox.SelectedItem != null)
            pdfLoadOptions.GraphicsAlpha = Tools.ValueNameItem<int>.GetSelectedItem(_graphicsAlphaComboBox.SelectedItem);
         pdfLoadOptions.DisableCropping = _disableCroppingCheckBox.Checked;
         pdfLoadOptions.DisableCieColors = _displayCieColorsCheckBox.Checked;
         pdfLoadOptions.Password = _passwordTextBox.Text;

         return true;
      }

      private void _resetToDefaultsButton_Click(object sender, EventArgs e)
      {
         // Reset all to default values
         _useLibFontsCheckBox.Checked = true;
         _displayDepthComboBox.SelectedItem = Tools.ValueNameItem<int>.SelectItem(24, _displayDepthComboBox.Items);
         _textAlphaComboBox.SelectedItem = Tools.ValueNameItem<int>.SelectItem(4, _textAlphaComboBox.Items);
         _graphicsAlphaComboBox.SelectedItem = Tools.ValueNameItem<int>.SelectItem(1, _graphicsAlphaComboBox.Items);
         _disableCroppingCheckBox.Checked = false;
         _displayCieColorsCheckBox.Checked = false;
         _passwordTextBox.Text = string.Empty;
      }
   }
}

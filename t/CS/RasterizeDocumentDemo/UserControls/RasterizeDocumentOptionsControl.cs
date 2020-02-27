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

using Leadtools.Demos;
using Leadtools;
using Leadtools.Codecs;

namespace RasterizeDocumentDemo.UserControls
{
   public partial class RasterizeDocumentOptionsControl : UserControl, IOptionsUserControl
   {
      public RasterizeDocumentOptionsControl()
      {
         InitializeComponent();
      }

      // The temporary CodecsRasterizeDocumentLoadOptions options to use
      public double _pageWidth;
      public double _pageHeight;
      private double _leftMargin;
      private double _topMargin;
      private double _rightMargin;
      private double _bottomMargin;
      private CodecsRasterizeDocumentUnit _unit;
      private int _resolution;
      private CodecsRasterizeDocumentSizeMode _sizeMode;

      /// <summary>
      /// Called by the owner to initialize
      /// </summary>
      public void SetData(RasterCodecs rasterCodecsInstance)
      {
         // Set the state of the controls

         // Event hooks
         _pageWidthTextBox.PreviewKeyDown += new PreviewKeyDownEventHandler(_textBox_PreviewKeyDown);
         _pageWidthTextBox.LostFocus += new EventHandler(_textBox_LostFocus);

         _pageHeightTextBox.PreviewKeyDown += new PreviewKeyDownEventHandler(_textBox_PreviewKeyDown);
         _pageHeightTextBox.LostFocus += new EventHandler(_textBox_LostFocus);

         _leftMarginTextBox.PreviewKeyDown += new PreviewKeyDownEventHandler(_textBox_PreviewKeyDown);
         _leftMarginTextBox.LostFocus += new EventHandler(_textBox_LostFocus);

         _topMarginTextBox.PreviewKeyDown += new PreviewKeyDownEventHandler(_textBox_PreviewKeyDown);
         _topMarginTextBox.LostFocus += new EventHandler(_textBox_LostFocus);

         _rightMarginTextBox.PreviewKeyDown += new PreviewKeyDownEventHandler(_textBox_PreviewKeyDown);
         _rightMarginTextBox.LostFocus += new EventHandler(_textBox_LostFocus);

         _bottomMarginTextBox.PreviewKeyDown += new PreviewKeyDownEventHandler(_textBox_PreviewKeyDown);
         _bottomMarginTextBox.LostFocus += new EventHandler(_textBox_LostFocus);

         _resolutionComboBox.PreviewKeyDown += new PreviewKeyDownEventHandler(_textBox_PreviewKeyDown);
         _resolutionComboBox.LostFocus += new EventHandler(_resolutionComboBox_LostFocus);

         // Initialize the units
         _unitComboBox.Items.Add(new Tools.ValueNameItem<CodecsRasterizeDocumentUnit>(CodecsRasterizeDocumentUnit.Pixel, "Pixel"));
         _unitComboBox.Items.Add(new Tools.ValueNameItem<CodecsRasterizeDocumentUnit>(CodecsRasterizeDocumentUnit.Inch, "Inch"));
         _unitComboBox.Items.Add(new Tools.ValueNameItem<CodecsRasterizeDocumentUnit>(CodecsRasterizeDocumentUnit.Millimeter, "Millimeter"));

         _sizeModeComboBox.Items.Add(new Tools.ValueNameItem<CodecsRasterizeDocumentSizeMode>(CodecsRasterizeDocumentSizeMode.None, "None"));
         _sizeModeComboBox.Items.Add(new Tools.ValueNameItem<CodecsRasterizeDocumentSizeMode>(CodecsRasterizeDocumentSizeMode.Fit, "Fit"));
         _sizeModeComboBox.Items.Add(new Tools.ValueNameItem<CodecsRasterizeDocumentSizeMode>(CodecsRasterizeDocumentSizeMode.FitAlways, "Fit always"));
         _sizeModeComboBox.Items.Add(new Tools.ValueNameItem<CodecsRasterizeDocumentSizeMode>(CodecsRasterizeDocumentSizeMode.FitWidth, "Fit width"));
         _sizeModeComboBox.Items.Add(new Tools.ValueNameItem<CodecsRasterizeDocumentSizeMode>(CodecsRasterizeDocumentSizeMode.Stretch, "Stretch"));

         CodecsRasterizeDocumentLoadOptions rasterizeDocumentLoadOptions = rasterCodecsInstance.Options.RasterizeDocument.Load;

         // Get the temporary values
         _pageWidth = rasterizeDocumentLoadOptions.PageWidth;
         _pageHeight = rasterizeDocumentLoadOptions.PageHeight;
         _leftMargin = rasterizeDocumentLoadOptions.LeftMargin;
         _topMargin = rasterizeDocumentLoadOptions.TopMargin;
         _rightMargin = rasterizeDocumentLoadOptions.RightMargin;
         _bottomMargin = rasterizeDocumentLoadOptions.BottomMargin;
         _unit = rasterizeDocumentLoadOptions.Unit;
         _resolution = rasterizeDocumentLoadOptions.XResolution;
         _sizeMode = rasterizeDocumentLoadOptions.SizeMode;

         // Now set the current values

         UpdateControlsFromValues();

         UpdateUIState();
      }

      /// <summary>
      /// Called by the owner to get the data
      /// </summary>
      public bool GetData(RasterCodecs rasterCodecsInstance)
      {
         bool ret = true;

         CodecsRasterizeDocumentLoadOptions rasterizeDocumentLoadOptions = rasterCodecsInstance.Options.RasterizeDocument.Load;

         // Get the rasterize document load settings

         if(ret)
         {
            ret = GetResolution();
         }

         if(ret)
         {
            TextBox[] valuesTextBox =
            {
               _pageWidthTextBox,
               _pageHeightTextBox,
               _leftMarginTextBox,
               _topMarginTextBox,
               _rightMarginTextBox,
               _bottomMarginTextBox
            };

            for(int i = 0; i < valuesTextBox.Length && ret; i++)
            {
               ret = GetTextBoxValue(valuesTextBox[i]);
            }
         }

         if(ret)
         {
            // Everything is ok, update the options
            rasterizeDocumentLoadOptions.PageWidth = _pageWidth;
            rasterizeDocumentLoadOptions.PageHeight = _pageHeight;
            rasterizeDocumentLoadOptions.LeftMargin = _leftMargin;
            rasterizeDocumentLoadOptions.TopMargin = _topMargin;
            rasterizeDocumentLoadOptions.RightMargin = _rightMargin;
            rasterizeDocumentLoadOptions.BottomMargin = _bottomMargin;
            rasterizeDocumentLoadOptions.Unit = _unit;
            rasterizeDocumentLoadOptions.XResolution = _resolution;
            rasterizeDocumentLoadOptions.YResolution = _resolution;
            rasterizeDocumentLoadOptions.SizeMode = _sizeMode;
         }

         return ret;
      }

      private void _textBox_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
      {
         if(e.KeyCode == Keys.Enter && e.Modifiers == Keys.None)
         {
            e.IsInputKey = true;
         }
      }

      private void _resolutionComboBox_LostFocus(object sender, EventArgs e)
      {
         _resolutionComboBox.Text = _resolution.ToString();
      }

      private void _resolutionComboBox_SelectedIndexChanged(object sender, EventArgs e)
      {
         GetResolution();
      }

      private void _resolutionComboBox_KeyPress(object sender, KeyPressEventArgs e)
      {
         if(e.KeyChar == (char)Keys.Return)
         {
            // User has pressed enter, get the new resolution

            if(GetResolution())
            {
               GetNextControl(sender as Control, true).Focus();
            }
         }
      }

      private bool GetResolution()
      {
         // Check the new value
         int resolution;

         const int minResolution = 10;
         const int maxResolution = 4800;

         string errorMessage = string.Format("Resolution must be a value between {0} and {1}", minResolution, maxResolution);

         if(!int.TryParse(_resolutionComboBox.Text, out resolution))
         {
            Messager.ShowWarning(this, errorMessage);
            _resolutionComboBox.Focus();
            return false;
         }

         // A value of 0 is valid, means screen resolution
         if(resolution != 0 && (resolution < minResolution || resolution > maxResolution))
         {
            Messager.ShowWarning(this, errorMessage);
            _resolutionComboBox.Focus();
            return false;
         }

         _resolution = resolution;
         return true;
      }

      private void _textBox_LostFocus(object sender, EventArgs e)
      {
         if(sender == _pageWidthTextBox)
         {
            _pageWidthTextBox.Text = _pageWidth.ToString("0.00");
         }
         else if(sender == _pageHeightTextBox)
         {
            _pageHeightTextBox.Text = _pageHeight.ToString("0.00");
         }
         else if(sender == _leftMarginTextBox)
         {
            _leftMarginTextBox.Text = _leftMargin.ToString("0.00");
         }
         else if(sender == _topMarginTextBox)
         {
            _topMarginTextBox.Text = _topMargin.ToString("0.00");
         }
         else if(sender == _rightMarginTextBox)
         {
            _rightMarginTextBox.Text = _rightMargin.ToString("0.00");
         }
         else if(sender == _bottomMarginTextBox)
         {
            _bottomMarginTextBox.Text = _bottomMargin.ToString("0.00");
         }
      }

      private void _textBox_KeyPress(object sender, KeyPressEventArgs e)
      {
         if(e.KeyChar == (char)Keys.Return)
         {
            // User has pressed enter, get the new width

            if(GetTextBoxValue(sender as TextBox))
            {
               GetNextControl(sender as Control, true).Focus();
            }
         }
      }

      private bool GetTextBoxValue(TextBox tb)
      {
         // Check the new value
         float value;

         string errorMessage;
         bool isLength;

         if(tb == _pageWidthTextBox || tb == _pageHeightTextBox)
         {
            errorMessage = "Page width or height must be value greater than zero";
            isLength = true;
         }
         else
         {
            errorMessage = "Margin must be value greater than or equal to zero";
            isLength = false;
         }

         if(!float.TryParse(tb.Text, out value))
         {
            Messager.ShowWarning(this, errorMessage);
            tb.Focus();
            return false;
         }

         if((isLength && value <= 0) || (!isLength && value < 0))
         {
            Messager.ShowWarning(this, errorMessage);
            tb.Focus();
            return false;
         }

         if(tb == _pageWidthTextBox)
         {
            _pageWidth = value;
         }
         else if(tb == _pageHeightTextBox)
         {
            _pageHeight = value;
         }
         else if(tb == _leftMarginTextBox)
         {
            _leftMargin = value;
         }
         else if(tb == _topMarginTextBox)
         {
            _topMargin = value;
         }
         else if(tb == _rightMarginTextBox)
         {
            _rightMargin = value;
         }
         else if(tb == _bottomMarginTextBox)
         {
            _bottomMargin = value;
         }

         return true;
      }

      private void _unitComboBox_SelectedIndexChanged(object sender, EventArgs e)
      {
         // Save the old unit so we can do the converstion
         CodecsRasterizeDocumentUnit newUnit = Tools.ValueNameItem<CodecsRasterizeDocumentUnit>.GetSelectedItem(_unitComboBox.SelectedItem);

         int resolution = _resolution;

         if(resolution == 0)
         {
            resolution = Tools.Units.ScreenResolution;
         }

         // Re-calculate the width and height and margins with new units

         _pageWidth = Tools.Units.Convert(_pageWidth, _unit, resolution, newUnit);
         _pageHeight = Tools.Units.Convert(_pageHeight, _unit, resolution, newUnit);
         _leftMargin = Tools.Units.Convert(_leftMargin, _unit, resolution, newUnit);
         _topMargin = Tools.Units.Convert(_topMargin, _unit, resolution, newUnit);
         _rightMargin = Tools.Units.Convert(_rightMargin, _unit, resolution, newUnit);
         _bottomMargin = Tools.Units.Convert(_bottomMargin, _unit, resolution, newUnit);

         // Set the new unit and size
         _unit = newUnit;
         _pageWidthTextBox.Text = _pageWidth.ToString("0.00");
         _pageHeightTextBox.Text = _pageHeight.ToString("0.00");
         _leftMarginTextBox.Text = _leftMargin.ToString("0.00");
         _topMarginTextBox.Text = _topMargin.ToString("0.00");
         _rightMarginTextBox.Text = _rightMargin.ToString("0.00");
         _bottomMarginTextBox.Text = _bottomMargin.ToString("0.00");
      }

      private static string[] _sizeModeDescription =
      {
         "Width and height are not used, the image will be loaded using its original size at the specified resolution.",
         "Fit the image into the 'width' and 'height' while maintaining the aspect ratio.\n\nIf the original image dimension is smaller than 'width' and 'height', no resizing is done.\n\nThe result image dimension will be 'width' or 'height' or smaller.",
         "Always fit the image into the 'width' and 'height' while maintaining the aspect ratio even if the original image dimension is smaller.\n\nThe result image dimension will always be 'width' or 'height'.",
         "Fit the image width to be 'width' while maintaining the aspect ratio.\n\n'height' is not used.",
         "Fit the image to be exactly 'width' and 'height'.\n\nAspect ratio might not be maintained."
      };

      private void _sizeModeComboBox_SelectedIndexChanged(object sender, EventArgs e)
      {
         _sizeMode = Tools.ValueNameItem<CodecsRasterizeDocumentSizeMode>.GetSelectedItem(_sizeModeComboBox.SelectedItem);

         // Update the help
         _sizeModeHelp.Text = _sizeModeDescription[(int)_sizeMode];

         UpdateUIState();
      }

      private void _resetToDefaultsButton_Click(object sender, EventArgs e)
      {
         _pageWidth = 8.5;
         _pageHeight = 11;
         _leftMargin = 1.25;
         _topMargin = 1;
         _rightMargin = 1.25;
         _bottomMargin = 1;
         _unit = CodecsRasterizeDocumentUnit.Inch;
         _resolution = 0;
         _sizeMode = CodecsRasterizeDocumentSizeMode.None;

         UpdateControlsFromValues();
         UpdateUIState();
      }

      private void UpdateUIState()
      {
         CodecsRasterizeDocumentSizeMode sizeMode = Tools.ValueNameItem<CodecsRasterizeDocumentSizeMode>.GetSelectedItem(_sizeModeComboBox.SelectedItem);
         _pageWidthTextBox.Enabled = (sizeMode != CodecsRasterizeDocumentSizeMode.None);
         _pageHeightTextBox.Enabled = (sizeMode != CodecsRasterizeDocumentSizeMode.None) && (sizeMode != CodecsRasterizeDocumentSizeMode.FitWidth);
         _leftMarginTextBox.Enabled = (sizeMode != CodecsRasterizeDocumentSizeMode.None);
         _topMarginTextBox.Enabled = (sizeMode != CodecsRasterizeDocumentSizeMode.None);
         _rightMarginTextBox.Enabled = (sizeMode != CodecsRasterizeDocumentSizeMode.None);
         _bottomMarginTextBox.Enabled = (sizeMode != CodecsRasterizeDocumentSizeMode.None);
         _unitComboBox.Enabled = (sizeMode != CodecsRasterizeDocumentSizeMode.None);
      }

      private void UpdateControlsFromValues()
      {
         _pageWidthTextBox.Text = _pageWidth.ToString("0.00");
         _pageHeightTextBox.Text = _pageHeight.ToString("0.00");
         _leftMarginTextBox.Text = _leftMargin.ToString("0.00");
         _topMarginTextBox.Text = _topMargin.ToString("0.00");
         _rightMarginTextBox.Text = _rightMargin.ToString("0.00");
         _bottomMarginTextBox.Text = _bottomMargin.ToString("0.00");

         _resolutionComboBox.Text = _resolution.ToString();

         _unitComboBox.SelectedItem = Tools.ValueNameItem<CodecsRasterizeDocumentUnit>.SelectItem(_unit, _unitComboBox.Items);
         _sizeModeComboBox.SelectedItem = Tools.ValueNameItem<CodecsRasterizeDocumentSizeMode>.SelectItem(_sizeMode, _sizeModeComboBox.Items);
      }
   }
}

// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Leadtools;
using Leadtools.ImageProcessing;
using Leadtools.ImageProcessing.Core;

namespace DocumentCleanupDemo
{
   public partial class ColorResolutionDialog : Form
   {
      // The ColorResolutionCommand Class is part of LEAD Image Processing functions. This class will convert an image from any bits-per-pixel to any bits-per-pixel.
      // This dialog will update the following members of this class: 
      // ColorResolutionCommand.BitsPerPixel, this member will set the number of bits per pixel for the conversion
      // ColorResolutionCommand.DitheringMethod, this member will set the dithering options used when converted the image.
      // ColorResolutionCommand.Order, this member will set the desired color byte order of the image data for the conversion
      // ColorResolutionCommand.PaletteFlags, this member will set the Palette options used when converted the image

      ColorResolutionCommand _ColorResolutionCommand = null;
      private int _bPP = 1;

      public ColorResolutionDialog()
      {
         InitializeComponent();
         _ColorResolutionCommand = new ColorResolutionCommand();
         InitializeUI();
      }
      public ColorResolutionDialog(ColorResolutionCommand ColorResolutionCommand, int BPP)
      {
         InitializeComponent();
         _ColorResolutionCommand = ColorResolutionCommand;
         _bPP = BPP;
         InitializeUI();
      }
      public ColorResolutionCommand ColorResolutionCommand
      {
         get
         {
            UpdateCommand();
            return _ColorResolutionCommand;
         }
         set
         {
            _ColorResolutionCommand = value;
            InitializeUI();
         }
      }
      private void _btnOk_Click(object sender, EventArgs e)
      {
         UpdateCommand();
         this.DialogResult = DialogResult.OK;
         this.Close();
      }

      private void _btnCancel_Click(object sender, EventArgs e)
      {
         this.DialogResult = DialogResult.Cancel;
      }
      private void InitializeUI()
      {
         // Initialize the ColorResolutionCommand Dialog with default values and fill the combo boxes
         _cmbBitsPerPixel.Items.Add(1);
         _cmbBitsPerPixel.Items.Add(2);
         _cmbBitsPerPixel.Items.Add(3);
         _cmbBitsPerPixel.Items.Add(4);
         _cmbBitsPerPixel.Items.Add(5);
         _cmbBitsPerPixel.Items.Add(6);
         _cmbBitsPerPixel.Items.Add(7);
         _cmbBitsPerPixel.Items.Add(8);
         _cmbBitsPerPixel.Items.Add(12);
         _cmbBitsPerPixel.Items.Add(16);
         _cmbBitsPerPixel.Items.Add(24);
         _cmbBitsPerPixel.Items.Add(32);
         _cmbBitsPerPixel.Items.Add(48);
         _cmbBitsPerPixel.Items.Add(64);


         _cmbBitsPerPixel.SelectedIndexChanged += new EventHandler(_cmbBitsPerPixel_SelectedIndexChanged);
         _cmbBitsPerPixel.SelectedIndex = _cmbBitsPerPixel.Items.IndexOf(_ColorResolutionCommand.BitsPerPixel);


         string[] names;
         names = Enum.GetNames(typeof(RasterDitheringMethod));
         foreach (string name in names)
         {
            _cmbDitherMethod.Items.Add(name);
         }
         _cmbDitherMethod.SelectedIndex = _cmbDitherMethod.Items.IndexOf(_ColorResolutionCommand.DitheringMethod.ToString());

         names = Enum.GetNames(typeof(ColorResolutionCommandPaletteFlags));
         foreach (string name in names)
         {
            if (name == "Fixed")
               _cmbPalette.Items.Add(name);

            if (name == "Optimized")
               _cmbPalette.Items.Add(name);
         }
         _cmbPalette.SelectedIndex = _cmbPalette.Items.IndexOf(_ColorResolutionCommand.PaletteFlags.ToString());

         _cmbColorOrder.Items.Add("Blue-Green-Red (BGR)");
         _cmbColorOrder.Items.Add("Red-Green-Blue (RGB)");
         _cmbColorOrder.SelectedIndex = 0;

         foreach (object i in _cmbBitsPerPixel.Items)
         {
            if (i.ToString() == _bPP.ToString())
            {
               _cmbBitsPerPixel.SelectedItem = i;
               break;
            }
         }
      }
      private void UpdateCommand()
      {
         // Set the value for the BitsPerPixel property
         if (_cmbBitsPerPixel.Text != "")
            _ColorResolutionCommand.BitsPerPixel = Convert.ToInt32(_cmbBitsPerPixel.Text);
         else
            _ColorResolutionCommand.BitsPerPixel = _bPP;
         // Set the value for the DitheringMethod options
         if (_cmbDitherMethod.Text != "")
            _ColorResolutionCommand.DitheringMethod = (RasterDitheringMethod)Enum.Parse(typeof(RasterDitheringMethod), _cmbDitherMethod.Text);
         // Select the color byte order of the image data
         _ColorResolutionCommand.Order = TranslateOrder();
         // Set the Palette options that will be used in the conversion
         if (_cmbPalette.Text != "")
            _ColorResolutionCommand.PaletteFlags = (ColorResolutionCommandPaletteFlags)Enum.Parse(typeof(ColorResolutionCommandPaletteFlags), _cmbPalette.Text);
      }
      void _cmbBitsPerPixel_SelectedIndexChanged(object sender, EventArgs e)
      {
         if (_cmbBitsPerPixel.SelectedIndex < 8)
         {
            _cmbDitherMethod.Enabled = true;
            _cmbPalette.Enabled = true;
            _cmbColorOrder.Enabled = false;
            _cmbPalette.Items.Remove("Netscape");

            if (_cmbBitsPerPixel.SelectedIndex == 7)
               _cmbPalette.Items.Add("Netscape");

            _cmbPalette.SelectedIndex = 1;
         }
         else if (_cmbBitsPerPixel.SelectedIndex == 8)
         {
            _cmbDitherMethod.Enabled = false;
            _cmbPalette.Enabled = false;
            _cmbColorOrder.Enabled = false;
         }
         else
         {
            _cmbDitherMethod.Enabled = false;
            _cmbPalette.Enabled = false;
            _cmbColorOrder.Enabled = true;
            _cmbColorOrder.Items.Remove("Grayscale");
            if (_cmbBitsPerPixel.SelectedIndex == 9)
            {
               _cmbColorOrder.Items.Add("Grayscale");
            }
         }
      }
      public RasterByteOrder TranslateOrder()
      {
         // Set the value of the RasterByteOrder used for the ColorResolutionCommand.Order property
         switch (_cmbColorOrder.SelectedIndex)
         {
            case 0:
               return RasterByteOrder.Bgr;

            case 1:
               return RasterByteOrder.Rgb;

            case 2:
               return RasterByteOrder.Gray;

            default:
               return RasterByteOrder.Bgr;
         }
      }
   }
}

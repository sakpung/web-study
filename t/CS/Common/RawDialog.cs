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

namespace Leadtools.Demos
{
   public partial class RawDialog : Form
   {
      // Create an instance of the Raw Data Structure to be used in this dialog for loading Raw Data
      public RawData CurrentRawData;
      private int _nBitsPerPixelOriginal = 0;
      private bool _initializaing;
      private bool _forLoad;

      private struct FormatItem
      {
         public RasterImageFormat Format;
         public string Name;

         public FormatItem(RasterImageFormat f, string n)
         {
            Format = f;
            Name = n;
         }

         public override string ToString()
         {
            return Name;
         }
      }

      private static readonly FormatItem[] _LoadFormats =
      {
          new FormatItem(RasterImageFormat.Raw, "RAW"),
          new FormatItem(RasterImageFormat.FaxG31DimNoEol, "Group 3-1D [No EOL] Fax"),
          new FormatItem(RasterImageFormat.FaxG31Dim, "Group 3-1D Fax"),
          new FormatItem(RasterImageFormat.FaxG32Dim, "Group 3-2D Fax"),
          new FormatItem(RasterImageFormat.FaxG4, "Group 4 Fax"),
          new FormatItem(RasterImageFormat.Abic, "ABIC Raw")
      };

      private static readonly FormatItem[] _SaveFormats =
      {
         new FormatItem(RasterImageFormat.Raw, "RAW"),
         new FormatItem(RasterImageFormat.FaxG31Dim, "Group 3-1D Fax"),
         new FormatItem(RasterImageFormat.FaxG32Dim, "Group 3-2D Fax"),
         new FormatItem(RasterImageFormat.FaxG4, "Group 4 Fax"),
         new FormatItem(RasterImageFormat.Abic, "ABIC Raw")
      };

      private struct PaletteItem
      {
         public bool Fixed;
         public string Name;

         public PaletteItem(bool f, string n)
         {
            Fixed = f;
            Name = n;
         }

         public override string ToString()
         {
            return Name;
         }
      }

      private PaletteItem[] _palettes;

      public RawDialog(bool forLoad)
      {
         InitializeComponent();
         _palettes = new PaletteItem[]
          {
             new PaletteItem(true, DemosGlobalization.GetResxString(GetType(), "Resx_FixedPalette")),
             new PaletteItem(false, DemosGlobalization.GetResxString(GetType(), "Resx_GrayScale"))
          };
         _forLoad = forLoad;
         // Set the BitsPerPixel to 24
         _nBitsPerPixelOriginal = CurrentRawData.BitsPerPixel;
      }

      private void RawDialog_Load(object sender, System.EventArgs e)
      {
         _initializaing = true;

         UpdateControlsLoadSave();

         // Hide this one or save
         _cbWhiteOnBlack.Visible = _forLoad;

         if (_forLoad)
             this.Text = DemosGlobalization.GetResxString(GetType(), "Resx_RawFileOpenDialog");
         else
             this.Text = DemosGlobalization.GetResxString(GetType(), "Resx_RawFileSaveDialog");
         // Fill values of the RasterByteOrder inside the Color Order combo box to be selected 
         Array a = Enum.GetValues(typeof(RasterByteOrder));
         foreach (RasterByteOrder i in a)
         {
            _cmbColorOrder.Items.Add(i);
            if (i == CurrentRawData.Order)
               _cmbColorOrder.SelectedItem = i;
         }

         if (_forLoad)
         {
            // Fill values of the Raw Formats inside the Format combo box to be selected when loading
            foreach (FormatItem i in _LoadFormats)
            {
               _cmbFormat.Items.Add(i);
               if (i.Format == CurrentRawData.Format)
                  _cmbFormat.SelectedItem = i;
            }
         }
         else
         {
            // Fill values of the Raw Formats inside the Format combo box to be selected when saving
            foreach (FormatItem i in _SaveFormats)
            {
               _cmbFormat.Items.Add(i);
               if (i.Format == CurrentRawData.Format)
                  _cmbFormat.SelectedItem = i;
            }
         }
         // Fill the Palette type (0 for grayscale palette and 1 for Leadtools fixed palette) in the Palettes combo box
         foreach (PaletteItem i in _palettes)
         {
            _cmbPalette.Items.Add(i);
            if (i.Fixed == CurrentRawData.FixedPalette)
               _cmbPalette.SelectedItem = i;
         }
         // Fill the values of RasterViewPerspective inside the raw data View Perspective combo box.
         a = Enum.GetValues(typeof(RasterViewPerspective));
         foreach (RasterViewPerspective i in a)
         {
            bool add = true;
            for (int j = 0; j < _cmbViewPerspective.Items.Count && add; j++)
            {
               if ((int)_cmbViewPerspective.Items[j] == (int)i)
                  add = false;
            }

            if (add)
            {
               _cmbViewPerspective.Items.Add(i);
               if (i == CurrentRawData.ViewPerspective)
                  _cmbViewPerspective.SelectedItem = i;
            }
         }
         // Set the default values for the Raw Dialog according to the Raw Data Structure.
         _cbPadLine4Bytes.Checked = CurrentRawData.Padding;

         _tbWidth.Text = CurrentRawData.Width.ToString();
         _tbHeight.Text = CurrentRawData.Height.ToString();
         _tbHorizontal.Text = CurrentRawData.XResolution.ToString();
         _tbVertical.Text = CurrentRawData.YResolution.ToString();
         _tbOffst.Text = CurrentRawData.Offset.ToString();

         _cbLSBFirst.Checked = CurrentRawData.ReverseBits;

         UpdateControls();

         _initializaing = false;

         bool bRaw = ((FormatItem)_cmbFormat.SelectedItem).Format == RasterImageFormat.Raw;
         bool bAbic = ((FormatItem)_cmbFormat.SelectedItem).Format == RasterImageFormat.Abic;

         if (bAbic)
            _cmbPalette.SelectedIndex = 1;
         else if (bRaw)
            _cmbPalette.SelectedIndex = 0;
      }

      private void _btnOk_Click(object sender, System.EventArgs e)
      {
         // Create a new instance of the RawData structure
         RawData raw = new RawData();
         // Select the Format
         raw.Format = ((FormatItem)_cmbFormat.SelectedItem).Format;

         if (!DialogUtilities.ParseInteger(_tbWidth, DemosGlobalization.GetResxString(GetType(), "Resx_Width"), 1, true, 0, false, true, out raw.Width))
            return;

         if (!DialogUtilities.ParseInteger(_tbHeight, DemosGlobalization.GetResxString(GetType(), "Resx_Height"), 1, true, 0, false, true, out raw.Height))
            return;

         if (!DialogUtilities.ParseInteger(_tbOffst, DemosGlobalization.GetResxString(GetType(), "Resx_Offset"), 0, true, 0, false, true, out raw.Offset))
            return;

         if (!DialogUtilities.ParseInteger(_tbHorizontal, DemosGlobalization.GetResxString(GetType(), "Resx_HorizontalResolution"), 1, true, 0, false, true, out raw.XResolution))
            return;

         if (!DialogUtilities.ParseInteger(_tbVertical, DemosGlobalization.GetResxString(GetType(), "Resx_VerticalResolution"), 1, true, 0, false, true, out raw.YResolution))
            return;
         // Set the BitsPerPixel
         raw.BitsPerPixel = (int)_cbBitsPerPixel.SelectedItem;
         // Set the ViewPerspective
         raw.ViewPerspective = (RasterViewPerspective)_cmbViewPerspective.SelectedItem;
         // Set the Type of Palette
         raw.Order = (RasterByteOrder)_cmbColorOrder.SelectedItem;
         raw.FixedPalette = ((PaletteItem)_cmbPalette.SelectedItem).Fixed;
         raw.PaletteEnabled = _cmbPalette.Enabled;
         raw.Padding = _cbPadLine4Bytes.Checked;
         raw.ReverseBits = _cbLSBFirst.Checked;
         raw.WhiteOnBlack = _cbWhiteOnBlack.Checked;
         // Update the CurrentRawData instance with the new values
         CurrentRawData = raw;
      }

      private void UpdateControlsLoadSave()
      {
         bool bAbic = false;

         if (_cmbFormat.SelectedIndex != -1)
         {
            bAbic = ((FormatItem)_cmbFormat.SelectedItem).Format == RasterImageFormat.Abic;
         }
         else
         {
            bAbic = false;
         }
         _tbWidth.ReadOnly = !_forLoad;
         _tbHeight.ReadOnly = !_forLoad;
         _tbHorizontal.ReadOnly = !_forLoad;
         _tbVertical.ReadOnly = !_forLoad;
         _cbBitsPerPixel.Enabled = _forLoad || bAbic;
         _cmbViewPerspective.Enabled = _forLoad;
         _cmbColorOrder.Enabled = _forLoad;
         _cmbPalette.Enabled = _forLoad;
      }

      private void UpdateBitsPerPixel()
      {
         bool bRaw = ((FormatItem)_cmbFormat.SelectedItem).Format == RasterImageFormat.Raw;
         bool bAbic = ((FormatItem)_cmbFormat.SelectedItem).Format == RasterImageFormat.Abic;
         int nIndex = -1;
         int nBPP;

         if (bRaw || bAbic)
            nBPP = _nBitsPerPixelOriginal;
         else
            nBPP = 1;

         //nIndex = _cbBitsPerPixel.FindStringExact(nBPP.ToString());
         //nBPP = 24;

         string test;
         test = nBPP.ToString();
         nIndex = _cbBitsPerPixel.FindStringExact(test);
         if (nIndex != -1)
         {
            int nBPPTemp = _nBitsPerPixelOriginal;
            _cbBitsPerPixel.SelectedIndex = nIndex;
            _nBitsPerPixelOriginal = nBPPTemp;
         }
      }

      private void UpdateControls()
      {
         UpdateBitsPerPixel();

         bool bRaw = ((FormatItem)_cmbFormat.SelectedItem).Format == RasterImageFormat.Raw;
         bool bAbic = ((FormatItem)_cmbFormat.SelectedItem).Format == RasterImageFormat.Abic;
         _cbPadLine4Bytes.Enabled = bRaw || bAbic;

         if (_forLoad == false)
         {
            // saving
            UpdateControlsLoadSave();
            return;
         }

         // loading
         _cbBitsPerPixel.Enabled = bRaw || bAbic;
         _cmbViewPerspective.Enabled = true;
         _cmbColorOrder.Enabled = bRaw || bAbic;
         _cmbPalette.Enabled = bRaw || bAbic;
         _cbLSBFirst.Enabled = true;
         _cbPadLine4Bytes.Enabled = bRaw || bAbic;
         _cbWhiteOnBlack.Enabled = !bRaw && !bAbic;

         if (!bRaw)
         {
            _cmbPalette.SelectedIndex = 0;
            _cmbColorOrder.SelectedItem = RasterByteOrder.Bgr;
         }
         else
         {
            _cbBitsPerPixel.Enabled = true;

            if ((int)_cbBitsPerPixel.SelectedItem > 8)
            {
               _cmbPalette.Enabled = true;
               _cmbPalette.SelectedIndex = 1;
               _cmbPalette.Enabled = false;
            }
            else
            {
               if (!_cmbPalette.Enabled)
                  _cmbPalette.Enabled = true;
            }
         }
      }

      private void _cmbFormat_SelectedIndexChanged(object sender, System.EventArgs e)
      {
         bool bRaw = ((FormatItem)_cmbFormat.SelectedItem).Format == RasterImageFormat.Raw;
         bool bAbic = ((FormatItem)_cmbFormat.SelectedItem).Format == RasterImageFormat.Abic;

         if (!_initializaing)
            UpdateControls();

         if (bAbic)
         {
            int[] bitsPerPixels1 = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 12, 16, 24, 32, 48, 64 };

            foreach (int i in bitsPerPixels1)
            {
               _cbBitsPerPixel.Items.Remove(i);
            }

            int[] bitsPerPixels2 = new int[] { 1, 4 };
            foreach (int i in bitsPerPixels2)
            {
               _cbBitsPerPixel.Items.Add(i);

            }
            _cbBitsPerPixel.SelectedIndex = 0;
         }
         else
            if (bRaw)
            {
               int[] bitsPerPixels1 = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 12, 16, 24, 32, 48, 64 };

               foreach (int i in bitsPerPixels1)
               {
                  _cbBitsPerPixel.Items.Remove(i);
               }

               int[] bitsPerPixels2 = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 12, 16, 24, 32, 48, 64 };
               foreach (int i in bitsPerPixels2)
               {
                  _cbBitsPerPixel.Items.Add(i);
               }

               _cbBitsPerPixel.SelectedIndex = 10;
            }

         if (_cmbPalette.Items.Count > 0)
         {
            if (bAbic)
               _cmbPalette.SelectedIndex = 1;
            else if (bRaw)
               _cmbPalette.SelectedIndex = 0;
         }

         if (_cbBitsPerPixel.Items.Count == 0)
         {
            int[] bitsPerPixels = new int[] { 1 };
            foreach (int i in bitsPerPixels)
            {
               _cbBitsPerPixel.Items.Add(i);
            }
            _cbBitsPerPixel.SelectedIndex = 0;
         }
      }

      private void _cbBitsPerPixel_SelectedIndexChanged(object sender, System.EventArgs e)
      {
         _nBitsPerPixelOriginal = (int)_cbBitsPerPixel.SelectedItem;
         if (!_initializaing)
            UpdateControls();
      }

   }
}

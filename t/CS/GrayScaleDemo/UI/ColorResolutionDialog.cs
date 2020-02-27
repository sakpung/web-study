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
using Leadtools.ImageProcessing.Color;
using Leadtools.Demos;
using Leadtools.Drawing;


namespace GrayScaleDemo
{
   public partial class ColorResolutionDialog : Form
   {
      private static int _initialBitsPerPixel = 24;
      private static RasterByteOrder _initialOrder = RasterByteOrder.Bgr;
      private static ColorResolutionCommandPaletteFlags _initialPaletteFlags = ColorResolutionCommandPaletteFlags.Optimized;
      private static RasterDitheringMethod _initialDitheringMethod = RasterDitheringMethod.None;
      private ImagePreviewCtrl _beforeViewer;
      private ImagePreviewCtrl _afterViewer;
      private RasterImage _originalImage;
      private RasterImage _afterImage;

      public int BitsPerPixel = -1;
      public RasterByteOrder Order;
      public ColorResolutionCommandPaletteFlags PaletteFlags;
      public RasterDitheringMethod DitheringMethod;
      public int _tempBitsPerPixel = -1;
      public RasterByteOrder _tempOrder;
      public ColorResolutionCommandPaletteFlags _tempPaletteFlags;
      public RasterDitheringMethod _tempDitheringMethod;


      private enum MyPaletteType
      {
         Fixed = ColorResolutionCommandPaletteFlags.Fixed,
         Optimized = ColorResolutionCommandPaletteFlags.Optimized,
         Netscape = ColorResolutionCommandPaletteFlags.Netscape
      }

      public ColorResolutionDialog(RasterImage image, RasterPaintProperties paintProperties)
      {
         InitializeComponent();

         if (image != null)
         {
            CloneCommand clone = new CloneCommand();

            clone.Run(image);

            _originalImage = image;
            _afterImage = clone.DestinationImage;

            _beforeViewer = new ImagePreviewCtrl(_originalImage, paintProperties, _lblBefore.Location, _lblBefore.Size);
            _afterViewer = new ImagePreviewCtrl(_afterImage, paintProperties, _lblAfter.Location, _lblAfter.Size);

            Controls.Add(_beforeViewer);
            Controls.Add(_afterViewer);
            _beforeViewer.BringToFront();
            _afterViewer.BringToFront();

            _beforeViewer.PanImage += new EventHandler<PanImageEvent>(_beforeViewer_PanImage);
            _afterViewer.PanImage += new EventHandler<PanImageEvent>(_afterViewer_PanImage);
         }
         else
         {
            _tsZoomLevel.Visible = false;
         }
      }

      void _beforeViewer_PanImage(object sender, PanImageEvent e)
      {
         _afterViewer.OffsetImage(e.Offset);
      }

      void _afterViewer_PanImage(object sender, PanImageEvent e)
      {
         _beforeViewer.OffsetImage(e.Offset);
      }

      private void ColorResolutionDialog_Load(object sender, System.EventArgs e)
      {
         if (_beforeViewer != null)
         {
            _tsbtnFit.Checked = false;
            _tsbtnNormal.Checked = true;

            _afterViewer.FitView = false;
            _beforeViewer.FitView = false;
         }

         if (BitsPerPixel == -1)
            BitsPerPixel = _initialBitsPerPixel;

         Order = _initialOrder;
         PaletteFlags = _initialPaletteFlags;
         DitheringMethod = _initialDitheringMethod;

         int[] bitsPerPixel = { 1, 2, 3, 4, 5, 6, 7, 8, 12, 16, 24, 32, 48, 64 };
         foreach (int i in bitsPerPixel)
         {
            _cbBitsPerPixel.Items.Add(i);
            if (BitsPerPixel == i)
               _cbBitsPerPixel.SelectedItem = i;
         }

         Array a = Enum.GetValues(typeof(MyPaletteType));
         foreach (MyPaletteType i in a)
         {
            _cbPalette.Items.Add(i);
            if ((int)PaletteFlags == (int)i)
               _cbPalette.SelectedItem = i;
         }

         if (_cbPalette.SelectedItem == null)
            _cbPalette.SelectedIndex = 0;

         Tools.FillComboBoxWithEnum(_cbDither, typeof(RasterDitheringMethod), DitheringMethod);

         GetUpdateValues();
         UpdateMyControls();
      }

      private void _tsbtnNormal_Click(object sender, EventArgs e)
      {
         if (_beforeViewer.Image != null)
         {
            _tsbtnFit.Checked = false;
            _tsbtnNormal.Checked = true;

            _beforeViewer.FitView = false;
            _afterViewer.FitView = false;
         }
      }

      private void _tsbtnFit_Click(object sender, EventArgs e)
      {
         if (_beforeViewer.Image != null)
         {
            _tsbtnFit.Checked = true;
            _tsbtnNormal.Checked = false;

            _beforeViewer.FitView = true;
            _afterViewer.FitView = true;
         }
      }

      private void UpdateMyControls()
      {
         int bitsPerPixel = (int)_cbBitsPerPixel.SelectedItem;
         _cbPalette.Enabled = bitsPerPixel <= 8;
         _cbDither.Enabled = bitsPerPixel <= 8;

         if (bitsPerPixel <= 8)
         {
            _cbOrder.Items.Clear();
            _cbOrder.Items.Add(Constants.GetNameFromValue(typeof(RasterByteOrder), RasterByteOrder.Rgb));
            _cbOrder.Enabled = false;

            if (_cbPalette.Enabled)
            {
               MyPaletteType selectedPalette;
               if (_cbPalette.SelectedItem != null)
                  selectedPalette = (MyPaletteType)_cbPalette.SelectedItem;
               else
                  selectedPalette = MyPaletteType.Fixed;

               _cbPalette.Items.Clear();

               Array a = Enum.GetValues(typeof(MyPaletteType));
               foreach (MyPaletteType i in a)
               {
                  if (bitsPerPixel == 8 || i != MyPaletteType.Netscape)
                  {
                     _cbPalette.Items.Add(i);
                     if (i == selectedPalette)
                        _cbPalette.SelectedItem = i;
                  }
               }

               if (_cbPalette.SelectedItem == null)
                  _cbPalette.SelectedIndex = 0;
            }

            _cbOrder.SelectedIndex = 0;
         }
         else if (bitsPerPixel == 12)
         {
            _cbOrder.Items.Clear();
            _cbOrder.Items.Add(Constants.GetNameFromValue(typeof(RasterByteOrder), RasterByteOrder.Gray));
            _cbOrder.SelectedIndex = 0;
            _cbOrder.Enabled = false;
         }
         else if (bitsPerPixel == 16)
         {
            _cbOrder.Items.Clear();
            Tools.FillComboBoxWithEnum(_cbOrder, typeof(RasterByteOrder), Order, new object[] { RasterByteOrder.Romm });
            if (_cbOrder.SelectedItem == null)
               _cbOrder.SelectedItem = RasterByteOrder.Bgr;
            _cbOrder.Enabled = true;
         }
         else
         {
            _cbOrder.Items.Clear();
            Tools.FillComboBoxWithEnum(_cbOrder, typeof(RasterByteOrder), Order, new object[] { RasterByteOrder.Gray, RasterByteOrder.Romm, RasterByteOrder.Rgb565 });
            if (_cbOrder.SelectedItem == null)
               _cbOrder.SelectedItem = RasterByteOrder.Bgr;
            _cbOrder.Enabled = true;
         }

         UpdateValues();
      }

      private void _cbBitsPerPixel_SelectedIndexChanged(object sender, System.EventArgs e)
      {
         UpdateMyControls();
      }

      void SelectedIndexChanged(object sender, System.EventArgs e)
      {
         GetUpdateValues();
         UpdateValues();
      }

      private void _btnOk_Click(object sender, System.EventArgs e)
      {
         BitsPerPixel = (int)_cbBitsPerPixel.SelectedItem;
         Order = (RasterByteOrder)Constants.GetValueFromName(
            typeof(RasterByteOrder),
            (string)_cbOrder.SelectedItem,
            _initialOrder);
         PaletteFlags = ColorResolutionCommandPaletteFlags.None;
         MyPaletteType myPalette = (MyPaletteType)_cbPalette.SelectedItem;
         switch (myPalette)
         {
            case MyPaletteType.Fixed:
               PaletteFlags |= ColorResolutionCommandPaletteFlags.Fixed;
               break;
            case MyPaletteType.Optimized:
               PaletteFlags |= ColorResolutionCommandPaletteFlags.Optimized;
               break;
            case MyPaletteType.Netscape:
               PaletteFlags |= ColorResolutionCommandPaletteFlags.Netscape;
               break;
         }

         DitheringMethod = (RasterDitheringMethod)Constants.GetValueFromName(
            typeof(RasterDitheringMethod),
            (string)_cbDither.SelectedItem,
            _initialDitheringMethod);

         _initialBitsPerPixel = BitsPerPixel;
         _initialOrder = Order;
         _initialPaletteFlags = PaletteFlags;
         _initialDitheringMethod = DitheringMethod;
      }

      protected void UpdateValues()
      {
         try
         {
            RasterImage tempImage;
            CloneCommand clone = new CloneCommand();

            clone.Run(_originalImage);

            tempImage = clone.DestinationImage;

            if (DoEffect(ref tempImage))
            {
               if (_afterImage != null)
               {
                  _afterImage.Dispose();

                  _afterImage = null;
               }

               _afterImage = tempImage;

               _afterViewer.Image = _afterImage;

               _afterViewer.OffsetImage(_beforeViewer.Offset);

               _afterViewer.Invalidate();
            }
         }
         catch (Exception ex)
         {
            throw ex;
         }
      }

      protected virtual bool DoEffect(ref RasterImage effectedImage)
      {
         try
         {
            ColorResolutionCommand command = new ColorResolutionCommand(ColorResolutionCommandMode.InPlace, _tempBitsPerPixel, _tempOrder, _tempDitheringMethod, _tempPaletteFlags, null);

            command.Progress += new EventHandler<RasterCommandProgressEventArgs>(command_Progress);

            command.Run(effectedImage);

            _pbProgress.Value = 0;
         }
         catch (Exception ex)
         {
            throw ex;
         }
         return true;
      }

      void command_Progress(object sender, RasterCommandProgressEventArgs e)
      {
         _pbProgress.Value = e.Percent;
      }

      private void GetUpdateValues()
      {
         _tempBitsPerPixel = -1;

         if (_cbBitsPerPixel.SelectedItem != null)
         {
            _tempBitsPerPixel = (int)_cbBitsPerPixel.SelectedItem;
         }

         _tempOrder = RasterByteOrder.Bgr;

         if (_cbOrder.SelectedItem != null)
         {
            _tempOrder = (RasterByteOrder)Constants.GetValueFromName(
                                          typeof(RasterByteOrder),
                                          (string)_cbOrder.SelectedItem,
                                          _initialOrder);
         }


         _tempPaletteFlags = ColorResolutionCommandPaletteFlags.None;

         if (_cbPalette.SelectedItem != null)
         {
            MyPaletteType myPalette = (MyPaletteType)_cbPalette.SelectedItem;
            switch (myPalette)
            {
               case MyPaletteType.Fixed:
                  _tempPaletteFlags |= ColorResolutionCommandPaletteFlags.Fixed;
                  break;
               case MyPaletteType.Optimized:
                  _tempPaletteFlags |= ColorResolutionCommandPaletteFlags.Optimized;
                  break;
               case MyPaletteType.Netscape:
                  _tempPaletteFlags |= ColorResolutionCommandPaletteFlags.Netscape;
                  break;
            }
         }

         _tempDitheringMethod = RasterDitheringMethod.None;

         if (_cbDither.SelectedItem != null)
         {
            _tempDitheringMethod = (RasterDitheringMethod)Constants.GetValueFromName(
                                    typeof(RasterDitheringMethod),
                                    (string)_cbDither.SelectedItem,
                                    _initialDitheringMethod);
         }
      }

   }
}

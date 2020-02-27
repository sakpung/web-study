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
using Leadtools.Demos;
using Leadtools.Codecs;
using Leadtools.Controls;
using Leadtools.Drawing;
using Leadtools.ImageProcessing.Core;

namespace DocumentCleanupDemo
{
   public enum MouseButton
   {
      None = 0,
      Rigth = 1,
      Left = 2,
   }

   public partial class ViewerForm : Form
   {
      public ViewerForm()
      {
         InitializeComponent();

         InitClass();
      }
      // Create an instance of the RasterImageViewer
      private ImageViewer _viewer;
      private string _name;
      private int _xLastPos, _yLastPos, _windowLevelWidth, _windowLevelCenter;
      private MouseButton _buttonPressed;
      private RasterColor[] _currentPalette = null;
      private ToolTip _toolTip;
      private RasterPaletteWindowLevelFlags _flags;
      private bool _isWLImage, _isMagGlass;
      private int _LUTSize, _scale = 1, _maxWidth, _minWidth, _maxLevel, _minLevel, _minValue, _maxValue, _highBit;

      public int WindowLevelCenter
      {
         get { return _windowLevelCenter; }
         set { _windowLevelCenter = value; }
      }

      public int WindowLevelWidth
      {
         get { return _windowLevelWidth; }
         set { _windowLevelWidth = value; }
      }

      public int WindowLevelScale
      {
         get { return _scale; }
         set { _scale = value; }
      }

      public bool IsMagGlass
      {
         get { return _isMagGlass; }
         set { _isMagGlass = value; }
      }

      private void InitClass()
      {
         // Initialize the _viewer and add handlers to the DragEnter/DragDrop and KeyDown events
         _viewer = new ImageViewer();
         _viewer.BorderStyle = BorderStyle.None;
         _viewer.DragEnter += new DragEventHandler(_viewer_DragEnter);
         _viewer.DragDrop += new DragEventHandler(_viewer_DragDrop);
         _viewer.KeyDown += new KeyEventHandler(_viewer_KeyDown);
         _viewer.MouseDown += new MouseEventHandler(_viewer_MouseDown);
         _viewer.MouseMove += new MouseEventHandler(_viewer_MouseMove);
         _viewer.MouseUp += new MouseEventHandler(_viewer_MouseUp);

         _toolTip = new ToolTip();

         _flags = RasterPaletteWindowLevelFlags.Logarithmic |
                        RasterPaletteWindowLevelFlags.DicomStyle | RasterPaletteWindowLevelFlags.Outside;

         Controls.Add(_viewer);
         _viewer.BringToFront();
         _viewer.AllowDrop = true;
         // Set a default RasterPaintProperties and Paint engine to use when displaying images on the viewer
         RasterPaintProperties Prop = new RasterPaintProperties();
         Prop = RasterPaintProperties.Default;
         Prop.PaintDisplayMode = RasterPaintDisplayModeFlags.FavorBlack;
         Prop.PaintEngine = RasterPaintEngine.GdiPlus;
         _viewer.PaintProperties = Prop;
      }
      public void Initialize(ImageInformation info, RasterPaintProperties paintProperties, bool animateRegions, bool snap, bool useDpi)
      {
         _viewer.BeginUpdate();
         UpdateAnimateRegions(animateRegions);
         UpdatePaintProperties(paintProperties);
         _viewer.Image = info.Image;
         _viewer.UseDpi = useDpi;
         if (_viewer.Image != null)
            _viewer.Image.Changed += new EventHandler<RasterImageChangedEventArgs>(Image_Changed);
         _name = info.Name;
         if (snap)
            Snap();
         UpdateCaption();
         _viewer.EndUpdate();

         _isWLImage = false;
         _isMagGlass = false;

         if (_viewer.Image.GrayscaleMode != RasterGrayscaleMode.None)
         {
            switch (_viewer.Image.BitsPerPixel)
            {
               case 8:
                  if (_viewer.Image.GrayscaleMode == RasterGrayscaleMode.NotOrdered)
                  {
                     Leadtools.ImageProcessing.GrayscaleCommand cmd = new Leadtools.ImageProcessing.GrayscaleCommand(8);
                     cmd.Run(_viewer.Image);
                  }
                  _currentPalette = _viewer.Image.GetPalette();
                  _LUTSize = 256;
                  _minValue = 0;
                  _maxValue = 255;
                  _isWLImage = true;
                  break;
               case 12:
               case 16:
                  _viewer.Image.UseLookupTable = true;
                  _currentPalette = _viewer.Image.GetLookupTable();
                  _highBit = _viewer.Image.HighBit;
                  if (_highBit == -1)
                     _highBit = _viewer.Image.BitsPerPixel - 1;
                  if (_currentPalette == null)
                  {
                     _LUTSize = (int)Math.Pow(2, _highBit + 1);
                     _maxValue = (_viewer.Image.Signed) ? _LUTSize / 2 - 1 : _LUTSize - 1;
                     _minValue = (_viewer.Image.Signed) ? -_LUTSize / 2 : 0;
                     createPalette();
                  }
                  else
                  {
                     _LUTSize = _currentPalette.Length;
                     MinMaxValuesCommand minMaxValueCmd = new MinMaxValuesCommand();
                     minMaxValueCmd.Run(_viewer.Image);
                     _maxValue = minMaxValueCmd.MaximumValue;
                     _minValue = minMaxValueCmd.MinimumValue;
                  }
                  _isWLImage = true;
                  break;
            }
            _scale = ((_maxValue - _minValue) / 1000 > 0) ? (_maxValue - _minValue) / 1000 : 1;
            _maxWidth = (int)Math.Pow(2, _viewer.Image.BitsPerPixel) - 1;
            _minWidth = 1;
            _maxLevel = (int)Math.Pow(2, _viewer.Image.BitsPerPixel) - 1;
            _minLevel = (int)Math.Pow(2, _viewer.Image.BitsPerPixel) * -1 + 1;

            if (_viewer.Image.Signed)
            {
               _flags |= RasterPaletteWindowLevelFlags.Signed;
               getWindowLevelForSigned(_currentPalette);
            }
            else
               getWindowLevelForUnSigned(_currentPalette);

         }
      }

      public void UpdatePaintProperties(RasterPaintProperties paintProperties)
      {
         _viewer.PaintProperties = paintProperties;
      }

      public void UpdateAnimateRegions(bool animateRegions)
      {
         if (animateRegions)
         {
            _viewer.ImageRegionRenderMode = ControlRegionRenderMode.Animated;
            _viewer.FloaterRegionRenderMode = ControlRegionRenderMode.Animated;
         }
         else
         {
            _viewer.ImageRegionRenderMode = ControlRegionRenderMode.Fixed;
            _viewer.FloaterRegionRenderMode = ControlRegionRenderMode.Fixed;
         }
      }

      private void UpdateCaption()
      {
         Text = string.Format("{0} - Page {1}:{2}", _name, _viewer.Image.Page, _viewer.Image.PageCount);
      }

      public RasterImage Image
      {
         get
         {
            return _viewer.Image;
         }
      }

      public ImageViewer Viewer
      {
         get
         {
            return _viewer;
         }
      }

      private void Image_Changed(object sender, RasterImageChangedEventArgs e)
      {
         UpdateCaption();
      }

      public void Snap()
      {
         _viewer.ClientSize = _viewer.ClientRectangle.Size;
         ClientSize = _viewer.ClientSize;
      }

      private void _viewer_DragEnter(object sender, DragEventArgs e)
      {
         if (Tools.CanDrop(e.Data))
            e.Effect = DragDropEffects.Copy;
      }

      private void _viewer_DragDrop(object sender, DragEventArgs e)
      {
         if (Tools.CanDrop(e.Data))
         {
            string[] files = Tools.GetDropFiles(e.Data);
            if (files != null)
               ((MainForm)MdiParent).LoadDropFiles(this, files);
         }
      }

      private void _viewer_KeyDown(object sender, KeyEventArgs e)
      {
         if (!e.Handled)
         {
            if (e.KeyCode == Keys.Add || e.KeyCode == Keys.Oemplus || e.KeyCode == Keys.Subtract || e.KeyCode == Keys.OemMinus)
            {
               e.Handled = true;
            }
         }
      }

      private void _viewer_MouseDown(object sender, MouseEventArgs e)
      {
         int x, y;
         LeadPointD pt = _viewer.ConvertPoint(null, ImageViewerCoordinateType.Control, ImageViewerCoordinateType.Image, new LeadPointD(e.X, e.Y));
         x = Convert.ToInt32(pt.X);
         y = Convert.ToInt32(pt.Y);

         switch (e.Button)
         {
            case MouseButtons.Right:
               _buttonPressed = MouseButton.Rigth;
               _xLastPos = x;
               _yLastPos = y;
               break;

            case MouseButtons.Left:
               _buttonPressed = MouseButton.Left;
               GetCursorData(x, y, e.X, e.Y);
               _xLastPos = x;
               _yLastPos = y;
               break;

            default:
               _buttonPressed = MouseButton.None;
               break;
         }
      }

      void GetCursorData(int x, int y, int CurX, int CurY)
      {
         try
         {
            string paletteValue, RGB;
            if (x < _viewer.Image.Width && y < _viewer.Image.Height && x >= 0 && y >= 0 && _isWLImage && _viewer.Image.BitsPerPixel != 12)
            {
               byte[] Data;
               int originalValue = 0, originalValueT = 0;
               _viewer.Image.Access();
               Data = _viewer.Image.GetPixelData(y, x);
               _viewer.Image.Release();
               switch (_viewer.Image.BitsPerPixel)
               {
                  case 16:
                  case 12:
                     int high = (_viewer.Image.HighBit != -1) ? _viewer.Image.HighBit : _viewer.Image.BitsPerPixel;
                     int signedBit = _viewer.Image.HighBit;
                     int checkValue = (int)Math.Pow(2, signedBit);
                     originalValue = Data[1] * 256 + Data[0];
                     if (originalValue >= checkValue && _viewer.Image.Signed)
                     {
                        originalValue = Data[1] * 256 + Data[0];
                        originalValueT = -1 * (((Convert.ToInt32(Math.Pow(2, signedBit - 7) - 1) - Data[1]) * 256 + 255 - Data[0]) + 1);
                     }
                     else
                        originalValueT = originalValue = Data[1] * 256 + Data[0];
                     break;
                  case 8:
                     originalValueT = originalValue = Data[0];
                     break;
               }

               paletteValue = "Palette map value = " + _currentPalette[originalValue].B;
               RGB = "RGB in the original image = " + originalValueT;
            }
            else
            {
               RasterColor tmpColor = _viewer.Image.GetPixelColor(y, x);
               RGB = string.Format("RGB = ({0},{1},{2})", tmpColor.R, tmpColor.G, tmpColor.B);
               paletteValue = "Palette map value =" + " 0 ";
            }

            if (_buttonPressed == MouseButton.Left)
            {
               string tipMessage = string.Format("X = {1} , Y = {2} {0}{3} {0}{4}",
                     Environment.NewLine, x, y, paletteValue, RGB);

               _toolTip.RemoveAll();
               ImageViewerAddRegionInteractiveMode regionInteractiveMode = new ImageViewerAddRegionInteractiveMode();
               if (!_isMagGlass && !_viewer.InteractiveModes.Contains(regionInteractiveMode))
                  _toolTip.Show(tipMessage, _viewer, CurX + 20, CurY + 20);
            }
         }
         catch (Exception ex)
         {
         }
      }

      private void _viewer_MouseMove(object sender, MouseEventArgs e)
      {
         int x, y;
         LeadPointD pt = _viewer.ConvertPoint(null, ImageViewerCoordinateType.Control, ImageViewerCoordinateType.Image, new LeadPointD(e.X, e.Y));
         x = Convert.ToInt32(pt.X);
         y = Convert.ToInt32(pt.Y);

         if (_buttonPressed == MouseButton.Rigth && _isWLImage)
         {
            if (_xLastPos < x)
               _windowLevelWidth = _windowLevelWidth + (x - _xLastPos) * _scale;
            else if (_xLastPos > x)
               _windowLevelWidth = _windowLevelWidth - (_xLastPos - x) * _scale;

            _xLastPos = x;

            CheckValue(ref _windowLevelWidth, _maxWidth, _minWidth);

            if (_yLastPos < y)
               _windowLevelCenter = _windowLevelCenter + (y - _yLastPos) * _scale;
            else if (_yLastPos > y)
               _windowLevelCenter = _windowLevelCenter - (_yLastPos - y) * _scale;

            _yLastPos = y;

            CheckValue(ref _windowLevelCenter, _maxLevel, _minLevel);

            ChangeThePalette();
         }
         else if (_buttonPressed == MouseButton.Left && !_isMagGlass)
         {
            if (!(_xLastPos == x && _yLastPos == y))
            {
               GetCursorData(x, y, e.X, e.Y);
               _xLastPos = x;
               _yLastPos = y;
            }
         }
      }

      private void _viewer_MouseUp(object sender, MouseEventArgs e)
      {
         _buttonPressed = MouseButton.None;
         _toolTip.Hide(_viewer);
      }

      private void CheckValue(ref int value, int max, int min)
      {
         if (value > max)
            value = max;
         if (value < min)
            value = min;
      }

      private void ChangeThePalette()
      {
         if (_viewer.Image.BitsPerPixel == 1)
            return;
         try
         {
            int low = (int)(_windowLevelCenter - _windowLevelWidth / 2.0);
            int high = (int)(_windowLevelCenter + _windowLevelWidth / 2.0);

            _currentPalette = new RasterColor[_LUTSize];

            RasterPalette.WindowLevelFillLookupTable(
              _currentPalette,
              new RasterColor(0, 0, 0),
              new RasterColor(255, 255, 255),
              low,
              high,
              _viewer.Image.LowBit,
              _highBit,
              _minValue,
              _maxValue,
              0,
              _flags);

            if (_viewer.Image.BitsPerPixel == 8)
            {
               _viewer.Image.SetPalette(_currentPalette, 0, _currentPalette.Length);
            }
            else
            {
               _viewer.Image.WindowLevel(
                  _viewer.Image.LowBit,
                  _highBit,
                  _currentPalette,
                  RasterWindowLevelMode.PaintAndProcessing);
            }
         }
         catch (Exception /*ex*/ )
         {
         }
      }

      public void Histogram()
      {
         HistogramDlg dlg = new HistogramDlg(_viewer.Image, _isWLImage);
         dlg.ShowDialog();
      }

      public void StartMagGlass()
      {
         ImageViewerMagnifyGlassInteractiveMode magnifyGlassInteractiveMode = new ImageViewerMagnifyGlassInteractiveMode();

         _viewer.InteractiveModes.BeginUpdate();
         _viewer.InteractiveModes.Clear();
         _viewer.InteractiveModes.Add(magnifyGlassInteractiveMode);
         _viewer.InteractiveModes.EndUpdate();

         _isMagGlass = true;
      }

      public void StopMagGlass()
      {
         ImageViewerNoneInteractiveMode noneInteractiveMode = new ImageViewerNoneInteractiveMode();

         _viewer.InteractiveModes.BeginUpdate();
         _viewer.InteractiveModes.Clear();
         _viewer.InteractiveModes.Add(noneInteractiveMode);
         _viewer.InteractiveModes.EndUpdate();

         _isMagGlass = false;
      }

      void getWindowLevelForUnSigned(RasterColor[] palette)
      {
         if (_viewer.Image.BitsPerPixel == 1) return;
         try
         {
            int lowValue = 0, highValue = 0;
            int max = _maxValue;
            int min = _minValue;
            int i = min;
            switch (palette[0].R)
            {
               case 0:
                  {
                     while (palette[i].R == 0)
                        if (i < _maxValue)
                           i++;
                        else
                           break;

                     if (i == _maxValue)
                     {
                        lowValue = _maxValue;
                        highValue = lowValue + 2;
                     }
                     else
                     {
                        lowValue = i;
                        while (palette[i].R != 255)
                           if (i < _maxValue)
                              i++;
                           else
                              break;

                        if (i == _maxValue)
                        {
                           max = _maxValue;
                           highValue = (int)(max + (max - lowValue) * (255.0 - palette[max].R) / palette[max].R);
                        }
                        if (i < _maxValue)
                           highValue = i;
                     }
                     break;
                  }
               case 255:
                  {
                     i = 0;
                     while (palette[i].R == 255)
                        if (i < _maxValue)
                           i++;
                        else
                           break;

                     if (i == _maxValue)
                     {
                        lowValue = -2;
                        highValue = 0;
                     }
                     else
                     {
                        lowValue = i;
                        while (palette[i].R != 0)
                           if (i < _maxValue)
                              i++;
                           else
                           {
                              highValue = (int)(max + (max - lowValue) * palette[max].R / (255.0 - palette[max].R));
                              break;
                           }
                        if (i < _maxValue)
                           highValue = i;
                     }
                     break;
                  }
               default:
                  {
                     i = 0;
                     while (palette[i].R != 0 && palette[i].R != 255)
                        if (i < _maxValue)
                           i++;
                        else
                           break;

                     if (i == _maxValue)
                     {
                        lowValue = (int)(min - max * (255.0 - palette[min].R) / (palette[min].R - palette[max].R));
                        highValue = max + (int)((max - min) * palette[max].R / (palette[min].R - palette[max].R));
                     }
                     else
                     {
                        lowValue = min - (int)((((highValue - min) * palette[min].R) / (255.0 - palette[min].R))); ;
                     }
                     break;
                  }
            }

            _windowLevelWidth = highValue - lowValue;
            _windowLevelCenter = (highValue + lowValue) / 2;
            CheckValue(ref _windowLevelWidth, (int)Math.Pow(2, _viewer.Image.BitsPerPixel) - 1, 1);
            CheckValue(ref _windowLevelCenter, (int)Math.Pow(2, _viewer.Image.BitsPerPixel),
                   (int)Math.Pow(2, _viewer.Image.BitsPerPixel) * -1 + 1);
            ChangeThePalette();
         }
         catch (Exception /*ex*/)
         {
         }
      }

      void getWindowLevelForSigned(RasterColor[] palette)
      {
         int i = 0;
         int lowValue = 0, highValue = 0;
         try
         {
            switch (palette[0].R)
            {
               case 0:
                  {
                     while (palette[i].R == 0 || palette[i].R == 255)
                        if (i < palette.Length - 1)
                           i = (i == _maxValue) ? _minValue + palette.Length : ++i;
                        else
                           break;

                     if (i == palette.Length - 1)
                     {
                        lowValue = _maxValue + 2;
                        highValue = lowValue + 2;
                     }
                     else
                     {
                        lowValue = (i > _maxValue) ? i - palette.Length : i;
                        if (lowValue > 0)
                        {
                           while (palette[i].R != 255)
                              if (i < _maxValue)
                                 i++;
                              else
                              {
                                 int max = _maxValue;
                                 int low = lowValue;
                                 highValue = (int)(_maxValue + ((max - low) * (255.0 - palette[max].R)) / palette[max].R);
                                 break;
                              }
                           if (i < _maxValue)
                              highValue = i;
                        }
                        else
                        {
                           while (palette[i].R != 0)
                              if (i < palette.Length - 1)
                                 i++;

                           highValue = i - palette.Length; ;
                           lowValue = lowValue - (int)(((highValue - lowValue) * (255.0 - palette[lowValue + palette.Length].R)) / (palette[lowValue + palette.Length].R));
                        }
                     }
                     break;
                  }
               case 255:
                  {
                     i = 0;
                     while (palette[i].R == 255 || palette[i].R == 0)
                        if (i < palette.Length - 1)
                           i = (i == _maxValue) ? _minValue + palette.Length : ++i;
                        else
                           break;

                     if (i == palette.Length - 1)
                     {
                        lowValue = _minValue - 2;
                        highValue = lowValue + 2;
                     }
                     else
                     {
                        lowValue = (i > _maxValue) ? i - palette.Length : i;
                        if (lowValue > 0)
                        {
                           while (palette[i].R != 0)
                              if (i < _maxValue)
                                 i++;
                              else
                              {
                                 int max = _maxValue;
                                 int low = lowValue;
                                 highValue = (int)(_maxValue + ((max - low) * palette[max].R) / (255.0 - palette[max].R));
                                 break;
                              }
                           if (i < _maxValue)
                              highValue = i;
                        }
                        else
                        {
                           while (palette[i].R != 255)
                              if (i < palette.Length - 1)
                                 i++;

                           highValue = i - palette.Length; ;
                           lowValue = lowValue - (int)(((highValue - lowValue) * palette[lowValue + palette.Length].R) / (255.0 - palette[lowValue + palette.Length].R));
                        }
                     }
                     break;
                  }
               default:
                  {
                     i = 0;
                     while (palette[i].R != 0 && palette[i].R != 255)
                        if (i < _maxValue)
                           i++;
                        else
                           break;

                     if (i == _maxValue)
                     {
                        i = palette.Length - Math.Abs(_minValue);
                        while (palette[i].R == 0 || palette[i].R == 255)
                           if (i < palette.Length - 1)
                              i++;
                           else
                              break;

                        if (i == palette.Length - Math.Abs(_minValue))
                        {
                           int max = _maxValue;
                           int min = _minValue;

                           if (palette[min + palette.Length].R > palette[max].R)
                           {
                              lowValue = (int)((max - min) * (255.0 - palette[max].R) / (palette[max].R - palette[min + palette.Length].R) + max);
                              highValue = (int)(min - (max - min) * palette[min + palette.Length].R / (palette[max].R - palette[min + palette.Length].R));
                           }
                           else
                           {
                              highValue = (int)((max - min) * (255.0 - palette[max].R) / (palette[max].R - palette[min + palette.Length].R) + max);
                              lowValue = (int)(min - (max - min) * palette[min + palette.Length].R / (palette[max].R - palette[min + palette.Length].R));
                           }
                        }
                        else
                        {
                           int max = _maxValue;
                           int min = _minValue;
                           lowValue = i - palette.Length;

                           if (palette[i].R > palette[_maxValue].R)
                           {
                              highValue = (int)(max + ((max - lowValue) * palette[max].R) / (255.0 - palette[max].R));
                           }
                           else
                           {
                              highValue = (int)(max + ((max - lowValue) * (255.0 - palette[max].R)) / palette[max].R);
                           }
                        }
                     }
                     else
                     {
                        highValue = i;

                        while (palette[i].R == 0 || palette[i].R == 255)
                           if (i < palette.Length - 1)
                              i++;
                           else
                              break;

                        if (i < palette.Length - 1)
                        {
                           lowValue = i - palette.Length;
                        }

                        if (lowValue < _minValue)
                        {
                           lowValue = _minValue;
                           lowValue = lowValue - (int)(((highValue - lowValue) * palette[i].R) / (255.0 - palette[i].R));
                        }
                     }
                     break;
                  }
            }

            _windowLevelWidth = highValue - lowValue;
            _windowLevelCenter = (highValue + lowValue) / 2;
            CheckValue(ref _windowLevelWidth, (int)Math.Pow(2, _viewer.Image.BitsPerPixel) - 1, 1);
            CheckValue(ref _windowLevelCenter, (int)Math.Pow(2, _viewer.Image.BitsPerPixel),
                   (int)Math.Pow(2, _viewer.Image.BitsPerPixel) * -1 + 1);
            ChangeThePalette();
         }
         catch (Exception /*ex*/)
         {
         }
      }

      void createPalette()
      {
         if (_viewer.Image.BitsPerPixel == 1) return;
         _currentPalette = new RasterColor[_LUTSize];
         _windowLevelWidth = _maxValue - _minValue;
         _windowLevelCenter = (_maxValue + _minValue) / 2;

         if (_viewer.Image.BitsPerPixel == 8)
            _viewer.Image.SetPalette(_currentPalette, 0, _currentPalette.Length);
         else
            _viewer.Image.SetLookupTable(_currentPalette);

         ChangeThePalette();
      }

      public void UpdateDataAfterCommand()
      {
         if (_viewer.Image.GrayscaleMode != RasterGrayscaleMode.None)
         {
            switch (_viewer.Image.BitsPerPixel)
            {
               case 8:
                  _currentPalette = _viewer.Image.GetPalette();
                  _LUTSize = 256;
                  _minValue = 0;
                  _maxValue = 255;
                  _isWLImage = true;
                  break;
               case 12:
               case 16:
                  _viewer.Image.UseLookupTable = true;
                  _currentPalette = _viewer.Image.GetLookupTable();
                  _highBit = _viewer.Image.HighBit;
                  if (_highBit == -1)
                     _highBit = _viewer.Image.BitsPerPixel - 1;
                  if (_currentPalette == null)
                  {
                     _LUTSize = (int)Math.Pow(2, _highBit + 1);
                     _maxValue = (_viewer.Image.Signed) ? _LUTSize / 2 - 1 : _LUTSize - 1;
                     _minValue = (_viewer.Image.Signed) ? -_LUTSize / 2 : 0;
                     createPalette();
                  }
                  else
                  {
                     _LUTSize = _currentPalette.Length;
                     MinMaxValuesCommand minMaxValueCmd = new MinMaxValuesCommand();
                     minMaxValueCmd.Run(_viewer.Image);
                     _maxValue = minMaxValueCmd.MaximumValue;
                     _minValue = minMaxValueCmd.MinimumValue;
                  }
                  _isWLImage = true;
                  break;
            }
            _scale = ((_maxValue - _minValue) / 1000 > 0) ? (_maxValue - _minValue) / 1000 : 1;
            _maxWidth = (int)Math.Pow(2, _viewer.Image.BitsPerPixel) - 1;
            _minWidth = 1;
            _maxLevel = (int)Math.Pow(2, _viewer.Image.BitsPerPixel) - 1;
            _minLevel = (int)Math.Pow(2, _viewer.Image.BitsPerPixel) * -1 + 1;

            if (_viewer.Image.Signed)
            {
               _flags |= RasterPaletteWindowLevelFlags.Signed;
               getWindowLevelForSigned(_currentPalette);
            }
            else
               getWindowLevelForUnSigned(_currentPalette);

         }
      }
   }
}

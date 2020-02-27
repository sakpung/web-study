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
using Leadtools.Controls;
using Leadtools.Drawing;
using Leadtools.ImageProcessing.Core;

namespace InteractiveHist
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

      private ImageViewer _viewer;
      private string _name;
      private UndoRedo _undoList;
      private int _xLastPos, _yLastPos, _windowLevelWidth, _windowLevelCenter;
      private MouseButton _buttonPressed;
      private RasterColor[] _currentPalette = null;
      private ToolTip _toolTip;
      private RasterPaletteWindowLevelFlags _flags;
      private bool _isWLImage, _isMagGlass;
      private int _LUTSize, _scale = 1, _maxWidth, _minWidth, _maxLevel, _minLevel, _minValue, _maxValue, _highBit;

      public bool IsMagGlass
      {
         get { return _isMagGlass; }
         set { _isMagGlass = value; }
      }

      private void InitClass()
      {
         _viewer = new ImageViewer();
         _viewer.BorderStyle = BorderStyle.None;
         _viewer.DragEnter += new DragEventHandler(_viewer_DragEnter);
         _viewer.DragDrop += new DragEventHandler(_viewer_DragDrop);
         _viewer.MouseDown += new MouseEventHandler(_viewer_MouseDown);
         _viewer.MouseMove += new MouseEventHandler(_viewer_MouseMove);
         _viewer.MouseUp += new MouseEventHandler(_viewer_MouseUp);

         _toolTip = new ToolTip();

         _flags = RasterPaletteWindowLevelFlags.Logarithmic |
                        RasterPaletteWindowLevelFlags.DicomStyle | RasterPaletteWindowLevelFlags.Outside;

         Controls.Add(_viewer);
         _viewer.BringToFront();
         _viewer.AllowDrop = true;
         _undoList = new UndoRedo();
      }

      public void Initialize(ImageInformation info, RasterPaintProperties paintProperties, bool snap)
      {
         _viewer.BeginUpdate();
         UpdatePaintProperties(paintProperties);
         _viewer.Image = info.Image;
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
            _windowLevelCenter = (_maxValue + _minValue) / 2;
            _windowLevelWidth = _maxValue - _minValue;
            if (_viewer.Image.Signed)
               _flags |= RasterPaletteWindowLevelFlags.Signed;
            ChangeThePalette();
         }
      }

      public void UpdatePaintProperties(RasterPaintProperties paintProperties)
      {
         _viewer.PaintProperties = paintProperties;
      }

      private void UpdateCaption()
      {
         Text = string.Format("{0} - Page {1}:{2}", _name, _viewer.Image.Page, _viewer.Image.PageCount);
      }

      public UndoRedo UndoList
      {
         get
         {
            return _undoList;
         }
      }

      public RasterImage Image
      {
         get
         {
            return _viewer.Image;
         }

         set
         {
            _viewer.Image = value;
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
         if (MdiParent != null)
            ((MainForm)MdiParent).UpdateControls();
      }


      private void _viewer_SizeModeChanged(object sender, EventArgs e)
      {
         ((MainForm)MdiParent).UpdateControls();
      }

      public void Snap()
      {
         _viewer.ClientSize = _viewer.ClientSize;
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
               Data = _viewer.Image.GetPixelData(y, x);
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
                  _toolTip.Show(tipMessage, _viewer, CurX + 25, CurY + 25);
            }
         }
         catch (Exception /*ex*/)
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
         else if (_buttonPressed == MouseButton.Left)
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
            int minValue, maxVale;

            _currentPalette = new RasterColor[_LUTSize];

            MinMaxValuesCommand cmd = new MinMaxValuesCommand();
            cmd.Run(_viewer.Image);
            minValue = cmd.MinimumValue;
            maxVale = cmd.MaximumValue;

            RasterPalette.WindowLevelFillLookupTable(
              _currentPalette,
              new RasterColor(0, 0, 0),
              new RasterColor(255, 255, 255),
              low,
              high,
              _viewer.Image.LowBit,
              _highBit,
              minValue,
              maxVale,
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
   }
}

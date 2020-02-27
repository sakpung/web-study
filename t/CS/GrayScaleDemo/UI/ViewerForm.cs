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
using System.IO;

using Leadtools;
using Leadtools.Codecs;
using Leadtools.Controls;
using Leadtools.Demos;
using Leadtools.ImageProcessing.Core;
using Leadtools.ImageProcessing.Effects;
using Leadtools.ImageProcessing.Color;
using Leadtools.ImageProcessing;
using Leadtools.Dicom;
using Leadtools.Drawing;
using System.Threading;


namespace GrayScaleDemo
{
   public partial class ViewerForm : Form
   {
      private MainForm _parent;
      public ViewerForm(MainForm pointer)
      {
         InitializeComponent();
         _parent = pointer;
      }

      private ImageViewer _viewer;
      private RasterCodecs _codecs;
      private int id;
      private ToolTip _toolTip;
      public double ViewerScale
      {
         get { return _viewer.ScaleFactor; }
      }
      public int Id
      {
         get { return id; }
         set { id = value; }
      }
      private PressedButton _pressed;
      private int _xLast;
      private int _yLast;
      private int _width;
      private int _level;
      private int _scale = 1;
      private RasterColor[] _currentPalette = null;
      private RasterColor16[] _currentPalette16 = null;
      private bool _isRegion, _isFloater, _isPerspective;
      private long[] _histogramValues = null;
      private RasterPaletteWindowLevelFlags _flags;
      private RasterColor _startColor;
      private RasterColor16 _startColor16;
      RasterColor _endColor;
      RasterColor16 _endColor16;
      private int _maxWidth, _minWidth, _maxLevel, _minLevel;
      private int _LUTSize, _LUTSize16, _highBit, _lowBit, _maxValue, _minValue, _freeHandIndex;
      private RegionType _regionType;
      LeadRect _regionRect;
      private Point _regionStart;
      private int _lowerTolerance;
      Rectangle _trackingRectangle;
      private LeadPoint[] _actualPoints;
      private Point[] _freeHandPoints;
      SeparationType _sepType;
      ImageCategory _imageCategory;
      private bool _isGray;
      public List<RasterImage> imageslist;
      private int _imageIndex;
      public List<RasterImage> floaterImageslist;
      private int _floaterImageIndex;
      private int _currentPageIndex;
      private ImageViewerNoneInteractiveMode _noneInteractiveMode;
      private ImageViewerFloaterInteractiveMode _floaterInteractiveMode;
      private ImageViewerMagnifyGlassInteractiveMode _magnifyGlassInteractiveMode;
      private ImageViewerPanZoomInteractiveMode _panInteractiveMode;
      private ImageViewerAddRegionInteractiveMode _regionInteractiveMode;

      public ImageViewerMagnifyGlassInteractiveMode MagnifyGlassInteractiveMode
      {
         get { return _magnifyGlassInteractiveMode; }
         set { _magnifyGlassInteractiveMode = value; }
      }

      public ImageViewerPanZoomInteractiveMode PanInteractiveMode
      {
         get { return _panInteractiveMode; }
         set { _panInteractiveMode = value; }
      }

      public ImageViewerNoneInteractiveMode NoneInteractiveMode
      {
         get { return _noneInteractiveMode; }
         set { _noneInteractiveMode = value; }
      }

      public ImageViewerFloaterInteractiveMode FloaterInteractiveMode
      {
         get { return _floaterInteractiveMode; }
         set { _floaterInteractiveMode = value; }
      }

      public ImageViewerAddRegionInteractiveMode RegionInteractiveMode
      {
         get { return _regionInteractiveMode; }
         set { _regionInteractiveMode = value; }
      }

      public int FloaterImageIndex
      {
         get { return _floaterImageIndex; }
         set { _floaterImageIndex = value; }
      }

      LineHistogramDialog lineHistgramDlg;
      int _lowerToleranceLevel, _upperToleranceLevel;
      private bool _invertByCommand;

      public bool InvertByCommand
      {
         get { return _invertByCommand; }
         set { _invertByCommand = value; }
      }

      public int ImageIndex
      {
         get { return _imageIndex; }
      }

      public ImageCategory ImageCategory
      {
         get { return _imageCategory; }
         set { _imageCategory = value; }
      }

      public SeparationType SepType
      {
         get { return _sepType; }
         set { _sepType = value; }
      }

      public RegionType RegionType
      {
         get { return _regionType; }
         set { _regionType = value; }
      }

      public bool IsPerspective
      {
         get { return _isPerspective; }
         set { _isPerspective = value; }
      }

      public long[] HistogramValues
      {
         get { return _histogramValues; }
      }

      public bool IsFloater
      {
         get { return _isFloater; }
         set { _isFloater = value; }
      }

      public bool IsRegion
      {
         get { return _isRegion; }
         set { _isRegion = value; }
      }

      public ImageViewer Viewer
      {
         get { return _viewer; }
      }

      public RasterImage Image
      {
         get
         {
            return _viewer.Image;
         }
      }

       public int WindowLevelCenter
       {
           get { return _level; }
           set { _level = value; }
       }

       public int WindowLevelWidth
       {
           get { return _width; }
           set { _width = value; }
       }

      void RegionInteractiveMode_WorkCompleted(object sender, EventArgs e)
      {
         if (_viewer.Image.GetRegionBounds(null).Width > 0)
         {
            _viewer.ActiveItem.ImageRegionToFloater();
            _viewer.WorkingInteractiveMode.IsEnabled = false;
            _viewer.Image.MakeRegionEmpty();
            _regionType = RegionType.NONE;

            FloaterInteractiveMode.IsEnabled = false;
            FloaterInteractiveMode.AutoItemMode = ImageViewerAutoItemMode.AutoSetActive;
            FloaterInteractiveMode.MouseButtons = System.Windows.Forms.MouseButtons.Left;
            FloaterInteractiveMode.FloaterOpacity = 0.5;
            FloaterInteractiveMode.FloaterRegionRenderMode = ControlRegionRenderMode.Animated;
            FloaterInteractiveMode.Item = _viewer.ActiveItem;
            _viewer.InteractiveModes.EnableById(FloaterInteractiveMode.Id);

         }

         //((MainForm)MdiParent).UpdateControls();
      }      


      public void Initialize()
      {
         _viewer = new ImageViewer();
         _viewer.Dock = DockStyle.Fill;
         _viewer.BackColor = Color.DarkGray;
         Controls.Add(_viewer);
         _viewer.BringToFront();
         _viewer.FloaterOpacity = 1;
         _codecs = new RasterCodecs();

         _viewer.InteractiveModes.BeginUpdate();

         RegionInteractiveMode = new ImageViewerAddRegionInteractiveMode();
         RegionInteractiveMode.Shape = ImageViewerRubberBandShape.Rectangle;
         RegionInteractiveMode.AutoRegionToFloater = true;
         RegionInteractiveMode.WorkOnBounds = true;
         RegionInteractiveMode.WorkCompleted += new EventHandler(RegionInteractiveMode_WorkCompleted);
         RegionInteractiveMode.MouseButtons = System.Windows.Forms.MouseButtons.Left;
         _viewer.InteractiveModes.Add(RegionInteractiveMode);

         //None
         NoneInteractiveMode = new ImageViewerNoneInteractiveMode();
         NoneInteractiveMode.IsEnabled = true;
         _viewer.InteractiveModes.EnableById(NoneInteractiveMode.Id);
         _viewer.InteractiveModes.Add(NoneInteractiveMode);
         //Floater
         FloaterInteractiveMode = new ImageViewerFloaterInteractiveMode();
         FloaterInteractiveMode.EnablePan = true;
         FloaterInteractiveMode.EnableZoom = false;
         FloaterInteractiveMode.EnablePinchZoom = false;
         FloaterInteractiveMode.WorkOnBounds = true;
         FloaterInteractiveMode.FloaterRegionRenderMode = ControlRegionRenderMode.Animated;
         _viewer.InteractiveModes.Add(FloaterInteractiveMode);

         MagnifyGlassInteractiveMode = new ImageViewerMagnifyGlassInteractiveMode();
         _viewer.InteractiveModes.Add(MagnifyGlassInteractiveMode);

         PanInteractiveMode = new ImageViewerPanZoomInteractiveMode();
         PanInteractiveMode.MouseButtons = System.Windows.Forms.MouseButtons.Left;
         _viewer.InteractiveModes.Add(PanInteractiveMode);

         _viewer.InteractiveModes.EndUpdate();

         DisableInteractiveModes(_viewer);

         _viewer.InteractiveModes.EnableById(NoneInteractiveMode.Id);

         this._viewer.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Viewer_MouseUp);
         this._viewer.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Viewer_MouseDown);
         this._viewer.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Viewer_MouseMove);
         this._viewer.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.Viewer_MouseWheel);
         _viewer.Paint += new PaintEventHandler(_viewer_Paint);
         _isFloater = _isRegion = false;
         _flags = RasterPaletteWindowLevelFlags.Linear |
                     RasterPaletteWindowLevelFlags.DicomStyle | RasterPaletteWindowLevelFlags.Outside;
         _startColor = new RasterColor(0, 0, 0);
         _startColor16 = new RasterColor16(0, 0, 0);

         _endColor = new RasterColor(RasterColor.MaximumComponent, RasterColor.MaximumComponent, RasterColor.MaximumComponent);
         _endColor16 = new RasterColor16(RasterColor16.MaximumComponent, RasterColor16.MaximumComponent, RasterColor16.MaximumComponent);

         _regionRect = new LeadRect();
         _regionStart = new Point();
         _trackingRectangle = new Rectangle();
         _toolTip = new ToolTip();
         _pressed = PressedButton.None;
         imageslist = new List<RasterImage>();
         floaterImageslist = new List<RasterImage>();
      }

      public void DisableInteractiveModes(ImageViewer Viewer)
      {
         Viewer.InteractiveModes.BeginUpdate();
         foreach (ImageViewerInteractiveMode mode in Viewer.InteractiveModes)
            mode.IsEnabled = false;
         Viewer.InteractiveModes.EndUpdate();
      }

      public void Viewer_MouseDown(object sender, MouseEventArgs e)
      {
         try
         {
            int x, y;
            LeadPoint pt = _viewer.ConvertPoint(null, ImageViewerCoordinateType.Control, ImageViewerCoordinateType.Image, LeadPoint.Create(e.X, e.Y));
            x = pt.X;
            y = pt.Y;
            _lowerToleranceLevel = 127;
            _upperToleranceLevel = 128;
            switch (e.Button)
            {
               case MouseButtons.Right:
                  _pressed = PressedButton.RigthBotton;
                  _xLast = x;
                  _yLast = y;
                  break;

               case MouseButtons.Left:
                  _regionStart.X = x;
                  _regionStart.Y = y;

                  Rectangle rect = new Rectangle(0, 0, 0, 0);
                  if (_viewer.Floater != null && FloaterInteractiveMode.IsEnabled)
                  {
                     Point fPt = new Point((int)_viewer.FloaterTransform.OffsetX, (int)_viewer.FloaterTransform.OffsetY);
                     LeadRect rt = _viewer.Floater.GetRegionBounds(null);
                     rect = new Rectangle(rt.X + fPt.X, rt.Y + fPt.Y, rt.Width, rt.Height);

                     bool inRegion = false;
                     int maxClipSegments = _viewer.Floater.CalculateRegionMaximumClipSegments();
                     LeadRect rgnBounds = _viewer.Floater.GetRegionBounds(null);
                     int[] segmentBuffer = new int[maxClipSegments];

                     int yInFloater = y - (int)_viewer.FloaterTransform.OffsetY;

                     _viewer.Floater.GetRegionClipSegments(yInFloater, segmentBuffer, 0);

                     int xInFloater = x - (int)_viewer.FloaterTransform.OffsetX;

                     for (int i = 0; i < maxClipSegments; i = i + 2)
                        if (xInFloater > segmentBuffer[i] && xInFloater < segmentBuffer[i + 1])
                        {
                           inRegion = true;
                           break;
                        }

                     if (!inRegion)
                     {
                        CombineFloater();
                        freeHand();
                     }

                     _freeHandIndex = 0;
                  }
                  else
                  {
                     _regionStart.X = x;
                     _regionStart.Y = y;
                  }
                  _trackingRectangle = Rectangle.FromLTRB(0, 0, 0, 0);
                  if (_regionType == RegionType.FREE_HAND && _viewer.Floater == null)
                  {
                     _freeHandPoints[_freeHandIndex++] = new Point(x, y);
                  }

                  _pressed = PressedButton.LeftBotton;
                  cursorData(e.X, e.Y, e.X, e.Y);

                  break;
            }
         }
         catch (Exception /*ex*/)
         {
         }
      }

      public void Viewer_MouseWheel(object sender, MouseEventArgs e)
      {
         double scale = _viewer.ScaleFactor + -1 * e.Delta / 1200.0;

         //if (scale >= .0001 && scale <= 20)
         //   _viewer.Zoom(_viewer.SizeMode, scale, _viewer.DefaultZoomOrigin);

         //_viewer.Zoom(ControlSizeMode.None, _viewer.ScaleFactor, _viewer.DefaultZoomOrigin);
         //_parent.UpdateMyControls();
      }

      bool isInRect(Point pt, Rectangle rect)
      {
         return (pt.X >= rect.Left && pt.X <= rect.Right && pt.Y >= rect.Top && pt.Y <= rect.Bottom);
      }

      public void Viewer_MouseUp(object sender, MouseEventArgs e)
      {
         try
         {
            switch (e.Button)
            {
               case MouseButtons.Left:
                  _pressed = PressedButton.None;
                  RasterRegionXForm xform = new RasterRegionXForm();
                  xform.ViewPerspective = RasterViewPerspective.TopLeft;
                  xform.XOffset = 0;
                  xform.YOffset = 0;
                  xform.XScalarDenominator = 1;
                  xform.XScalarNumerator = 1;
                  xform.YScalarDenominator = 1;
                  xform.YScalarNumerator = 1;

                  int x, y;
                  LeadPoint pt = _viewer.ConvertPoint(null, ImageViewerCoordinateType.Control, ImageViewerCoordinateType.Image, LeadPoint.Create(e.X, e.Y));
                  x = pt.X;
                  y = pt.Y;

                  _trackingRectangle = Rectangle.FromLTRB(0, 0, 0, 0);
                  _viewer.Invalidate();
                  if (_viewer.Floater == null)
                  {
                     //_viewer.Image.MakeRegionEmpty();
                     switch (_regionType)
                     {
                        case RegionType.NONE:
                           _toolTip.Hide(_viewer);
                           return;
                        //case RegionType.RECTANGLE:
                        //   if (!updateRegionRectLocation(new Point(_regionStart.X, _regionStart.Y), new Point(x, y)))
                        //      return;
                        //   _viewer.Image.AddRectangleToRegion(xform, _regionRect, RasterRegionCombineMode.Set);
                        //   break;
                        //case RegionType.ELLIPSE:
                        //   if (!updateRegionRectLocation(new Point(_regionStart.X, _regionStart.Y), new Point(x, y)))
                        //      return;
                        //   _viewer.Image.AddEllipseToRegion(xform, _regionRect, RasterRegionCombineMode.Set);
                        //   break;
                        //case RegionType.ROUND_RECTANGLE:
                        //   if (!updateRegionRectLocation(new Point(_regionStart.X, _regionStart.Y), new Point(x, y)))
                        //      return;
                        //   LeadSize sz = new LeadSize(_regionRect.Width / 4, _regionRect.Height / 4);
                        //   _viewer.Image.AddRoundRectangleToRegion(xform, _regionRect, sz, RasterRegionCombineMode.Set);
                        //   break;
                        //case RegionType.FREE_HAND:
                        //   _freeHandPoints = new Point[5000];
                        //   _freeHandIndex = 0;
                        //   _viewer.Image.AddPolygonToRegion(xform, _actualPoints, LeadFillMode.Alternate, RasterRegionCombineMode.Set);
                        //   break;
                        case RegionType.AUTO_SEGMENT:
                           if (!updateRegionRectLocation(new Point(_regionStart.X, _regionStart.Y), new Point(x, y)))
                              return;
                           AutoSegmentCommand cmd = new AutoSegmentCommand(_regionRect);
                           cmd.Run(_viewer.Image);
                           break;
                        case RegionType.FAST_MAGIC_WAND:
                           FastMagicWandCommand cmdFast = new FastMagicWandCommand();
                           if (x > _viewer.Image.Width || y > _viewer.Image.Height || x < 0 || y < 0)
                              return;
                           cmdFast.X = x;
                           cmdFast.Y = y;

                           cmdFast.Tolerance = _lowerTolerance;
                           cmdFast.SourceImage = _viewer.Image;

                           cmdFast.StartEngine();
                           cmdFast.Run(_viewer.Image);
                           cmdFast.EndEngine();
                           RasterRegionCombineMode regionCombineMode = RasterRegionCombineMode.Set;
                           for (int row = cmdFast.ObjectRectangle.Top; row < cmdFast.ObjectRectangle.Bottom; row++)
                           {
                              for (int col = cmdFast.ObjectRectangle.Left; col < cmdFast.ObjectRectangle.Right; col++)
                                 if (cmdFast.ObjectData[col - cmdFast.ObjectRectangle.Left][row - cmdFast.ObjectRectangle.Top] == 1)
                                 {
                                    int start = col;
                                    while ((cmdFast.ObjectData[col++ - cmdFast.ObjectRectangle.Left][row - cmdFast.ObjectRectangle.Top] == 1) && col < cmdFast.ObjectRectangle.Right) ;

                                    updateRegionRectLocation(new Point(start, row), new Point(col, row + 1));
                                    _viewer.Image.AddRectangleToRegion(xform, _regionRect, regionCombineMode);
                                    regionCombineMode = RasterRegionCombineMode.Or;
                                 }
                           }
                           break;
                     }
                     convertRegionToFloater();
                     _parent.UpdateMyControls();
                  }
                  _toolTip.Hide(_viewer);
                  break;
               case MouseButtons.Right:
                  _pressed = PressedButton.None;
                  break;
            }
         }
         catch (Exception /*ex*/)
         {
         }
      }

      private bool updateRegionRectLocation(Point startPoint, Point endPoint)
      {
         _regionRect.X = Math.Min(startPoint.X, endPoint.X);
         _regionRect.Y = Math.Min(startPoint.Y, endPoint.Y);
         _regionRect.Width = Math.Abs(endPoint.X - startPoint.X);
         _regionRect.Height = Math.Abs(endPoint.Y - startPoint.Y);

         if (_regionRect.X + _regionRect.Width >= _viewer.Image.Width)
            _regionRect.Width = _viewer.Image.Width - 1 - _regionRect.X;
         if (_regionRect.Y + _regionRect.Height >= _viewer.Image.Height)
            _regionRect.Height = _viewer.Image.Height - 1 - _regionRect.Y;
         if (_regionRect.X < 0)
         {
            _regionRect.Width += _regionRect.X;
            _regionRect.X = 0;
         }
         if (_regionRect.Y < 0)
         {
            _regionRect.Height += _regionRect.Y;
            _regionRect.Y = 0;
         }

         if (_regionRect.Width == 0 || _regionRect.Height == 0)
            return false;
         return true;
      }

      public void Viewer_MouseMove(object sender, MouseEventArgs e)
      {
         int x, y;
         LeadPoint pt = _viewer.ConvertPoint(null, ImageViewerCoordinateType.Control, ImageViewerCoordinateType.Image, LeadPoint.Create(e.X, e.Y));
         x = pt.X;
         y = pt.Y;

         if (_pressed == PressedButton.RigthBotton && _viewer.Floater == null)
         {
            if (_xLast < x)
               _width = _width + (x - _xLast) * _scale;
            else if (_xLast > x)
               _width = _width - (_xLast - x) * _scale;

            _xLast = x;

            CheckValue(ref _width, _maxWidth, _minWidth);

            if (_yLast < y)
               _level = _level + (y - _yLast) * _scale;
            else if (_yLast > y)
               _level = _level - (_yLast - y) * _scale;

            _yLast = y;

            CheckValue(ref _level, _maxLevel, _minLevel);

            if (_isGray)
               ChangeThePalette();
         }

         if (_pressed == PressedButton.LeftBotton && (_viewer.Floater == null) && _regionType != RegionType.NONE)
         {
            _trackingRectangle = Rectangle.FromLTRB(_trackingRectangle.Left, _trackingRectangle.Top, e.X, e.Y);

            switch (_regionType)
            {
               case RegionType.ROUND_RECTANGLE:
               case RegionType.RECTANGLE:
               case RegionType.ELLIPSE:
               case RegionType.AUTO_SEGMENT:
                  _trackingRectangle.X = Math.Min(_regionStart.X, x);
                  _trackingRectangle.Y = Math.Min(_regionStart.Y, y);
                  _trackingRectangle.Width = Math.Abs(x - _regionStart.X);
                  _trackingRectangle.Height = Math.Abs(y - _regionStart.Y);
                  break;
               case RegionType.FREE_HAND:
                  _freeHandPoints[_freeHandIndex++] = new Point(x, y);
                  break;
               case RegionType.MAGIC_WAND:
               case RegionType.ADD_BORDER_TO_REGION:

                  RasterColor cr = _viewer.Image.GetPixelColor(_regionStart.Y, _regionStart.X);
                  int delta = (y - _regionStart.Y) / 20;

                  _lowerToleranceLevel = CheckColorValue(_lowerTolerance - delta);
                  _upperToleranceLevel = CheckColorValue(_upperToleranceLevel + delta);

                  if (x < 0 || x > _viewer.Image.Width - 1 || y < 0 || y > _viewer.Image.Height - 1)
                     return;
                  _viewer.Image.MakeRegionEmpty();

                  if (_regionType == RegionType.MAGIC_WAND)
                     _viewer.Image.AddMagicWandToRegion(x, y, new RasterColor(_lowerToleranceLevel, _lowerToleranceLevel, _lowerToleranceLevel),
                           new RasterColor(_upperToleranceLevel, _upperToleranceLevel, _upperToleranceLevel), RasterRegionCombineMode.Set);
                  else if (_regionType == RegionType.ADD_BORDER_TO_REGION)
                     _viewer.Image.AddBorderToRegion(x, y, cr,
                        new RasterColor(_lowerToleranceLevel, _lowerToleranceLevel, _lowerToleranceLevel), new RasterColor(_upperToleranceLevel, _upperToleranceLevel, _upperToleranceLevel), RasterRegionCombineMode.Set);

                  break;
            }
            _viewer.Invalidate();
         }
         cursorData(x, y, e.X, e.Y);
      }

      private int CheckColorValue(int level)
      {
         if (level < 0)
            return 0;

         if (level > 255)
            return 255;

         return level;
      }

      private void ChangeThePalette()
      {
         if (_isGray == false ) return;

         try
         {
            bool inverted = false ;
            if (_viewer.Image.GrayscaleMode == RasterGrayscaleMode.OrderedInverse)
            {
                inverted = true;
            }
             
            int low = (int)(_level - _width / 2.0);
            int high = (int)(_level + _width / 2.0);

            if (_viewer.Image.BitsPerPixel == 8)
            {
               _currentPalette = new RasterColor[_LUTSize];
               RasterPalette.WindowLevelFillLookupTable( _currentPalette,
                                                          inverted ? _endColor : _startColor, inverted ? _startColor : _endColor,
                                                          low, high,
                                                          _viewer.Image.LowBit, _highBit,
                                                          _minValue, _maxValue,
                                                          0, _flags);

               _viewer.Image.SetPalette(_currentPalette, 0, _currentPalette.Length);
            }
            else
            {
               _currentPalette16 = new RasterColor16[_LUTSize16];
               RasterPalette.WindowLevelFillLookupTableExt( _currentPalette16,
                                                             inverted ? _endColor16 : _startColor16, inverted ? _startColor16 : _endColor16,
                                                             low, high,
                                                             _viewer.Image.LowBit, _highBit,
                                                             _minValue, _maxValue,
                                                             0, _flags );

               _viewer.Image.WindowLevelExt( _viewer.Image.LowBit, _highBit, _currentPalette16,  RasterWindowLevelMode.PaintAndProcessing);
            }

            _lblWidth.Text = " W = " + _width.ToString();
            _lblLevel.Text = " L = " + _level.ToString();
         }
         catch { }
      }

      public void UpdateAfterCommandExecution()
      {
         try
         {
            RasterImage tmpImg = (_viewer.Floater != null) ? _viewer.Floater : _viewer.Image;
            if (tmpImg.GrayscaleMode != RasterGrayscaleMode.None)
            {
               switch (tmpImg.BitsPerPixel)
               {
                  case 1:
                     _imageCategory = ImageCategory.OneBitImage;
                     _isGray = false;
                     break;
                  case 8:
                     _currentPalette = _viewer.Image.GetPalette();
                     _LUTSize = 256;
                     _minValue = 0;
                     _maxValue = 255;
                     _imageCategory = ImageCategory.GrayScale_8_12_16_BPP;
                     _isGray = true;
                     _highBit = _viewer.Image.HighBit;

                     _flags = RasterPaletteWindowLevelFlags.None;
                     _flags = RasterPaletteWindowLevelFlags.Linear | RasterPaletteWindowLevelFlags.DicomStyle | RasterPaletteWindowLevelFlags.Outside ;
                     if (_viewer.Image.Signed)
                        _flags |= RasterPaletteWindowLevelFlags.Signed;
                     break;
                  case 12:
                  case 16:
                        _highBit = _viewer.Image.HighBit;
                     if (_highBit == -1) _highBit = _viewer.Image.BitsPerPixel - 1;
                     _LUTSize   = 1 << (_highBit - _viewer.Image.LowBit + 1) ;
                     _LUTSize16 = 1 << (_highBit - _viewer.Image.LowBit + 1) ;

                     _maxValue = (_viewer.Image.Signed) ? ((_LUTSize+1)/2 - 1) : (_LUTSize - 1) ;
                     _minValue = (_viewer.Image.Signed) ? (-(_LUTSize+1)/2) : 0 ;

                        _flags = RasterPaletteWindowLevelFlags.None;
                     _flags = RasterPaletteWindowLevelFlags.Linear | RasterPaletteWindowLevelFlags.DicomStyle | RasterPaletteWindowLevelFlags.Outside ;
                     if (_viewer.Image.Signed) _flags |= RasterPaletteWindowLevelFlags.Signed;

                     _imageCategory = ImageCategory.GrayScale_8_12_16_BPP;
                     _isGray = true;
                     break;
                  default:
                     _imageCategory = ImageCategory.GrayScale_32_48_BPP;
                     break;
               }

               _scale = ((_maxValue - _minValue) / 10000 > 0) ? (_maxValue - _minValue) / 10000 : 1;
               _minWidth = 1 ;
               _maxWidth = (int)Math.Pow(2, _viewer.Image.BitsPerPixel) - 1;
               _minLevel = (int)Math.Pow(2, _viewer.Image.BitsPerPixel) * -1 + 1 ;
               _maxLevel = (int)Math.Pow(2, _viewer.Image.BitsPerPixel) - 1;

               getWindowLevel();

               _lblWidth.Text = " W = " + _width.ToString();
               _lblLevel.Text = " L = " + _level.ToString();
            }
            else
            {
               _imageCategory = ImageCategory.ColoredImage;
               _isGray = false;
            }

            _lblBPP.Text = " BPP = " + _viewer.Image.BitsPerPixel;
            _lblImageSize.Text = _viewer.Image.Width + "X" + _viewer.Image.Height;
            _lblSigned.Text = (_viewer.Image.Signed) ? "Signed Image" : "UnSigned Image";
         }
         catch (Exception)
         {
         }
      }

      private void CheckValue(ref int value, int max, int min)
      {
         if (value > max)
            value = max;
         if (value < min)
            value = min;
      }

      public void invert(bool useLUT)
      {
         try
         {
            InvertCommand inv = new InvertCommand();
            if (_viewer.Floater != null)
            {
               inv.Run(_viewer.Floater);
            }
            else
            {
               _viewer.Image.UseLookupTable = useLUT;
               inv.Run(_viewer.Image);
               _viewer.Image.UseLookupTable = true;
            }

            if (_invertByCommand)
               addToImageList();

            _invertByCommand = false;
         }
         catch (Exception ex)
         {
            MessageBox.Show(ex.Message);
         }
      }

      public void rotate(int angle)
      {
         RotateCommand command = new RotateCommand();
         if (angle == -1)
         {
            RotateDialog dlg = new RotateDialog(_isGray);
            if (dlg.ShowDialog(this) == DialogResult.OK)
            {
               if (_isGray)
                  command.FillColor = new RasterColor(dlg.FillColorLevel, dlg.FillColorLevel, dlg.FillColorLevel);
               else
                  command.FillColor = Converters.FromGdiPlusColor(dlg.FillColor);
               command.Flags = dlg.Flags;
               command.Angle = dlg.Angle;
               if (_viewer.Floater == null)
                  command.Run(_viewer.Image);
               else
                  command.Run(_viewer.Floater);

               addToImageList();

            }
         }
         else
         {
            command.Angle = angle * 100;
            if (_viewer.Floater == null)
               command.Run(_viewer.Image);
            else
               command.Run(_viewer.Floater);

            addToImageList();
         }
      }

      public void flip(bool isHorizontal)
      {
         FlipCommand cmd = new FlipCommand();
         cmd.Horizontal = isHorizontal;
         if (_viewer.Floater == null)
            cmd.Run(_viewer.Image);
         else
            cmd.Run(_viewer.Floater);

         addToImageList();
      }

      public string GetWindowTitle(string title)
      {
         if (_parent.MdiChildren.Length == 0)
            return title;

         for (int x = 0; x < _parent.MdiChildren.Length; x++)
         {
            if (title == _parent.MdiChildren[x].Text)
            return title + "*";
         }

         return title;
      }

      public void load(RasterImage image, string title)
      {
         _viewer.Image = image;

         _imageIndex = 0;
         imageslist.Add(new RasterImage(_viewer.Image));

         this.Width = 600;
         this.Height = 600;

         if (image.GrayscaleMode != RasterGrayscaleMode.None)
         {
            switch (_viewer.Image.BitsPerPixel)
            {
               case 8:
                  _currentPalette = _viewer.Image.GetPalette();
                  _LUTSize = 256;
                  _minValue = 0;
                  _maxValue = 255;
                  _isGray    = true ;
                  _LUTSize16 = 0 ;

                  _highBit = _viewer.Image.HighBit;
                  if (_highBit == -1) _highBit = _viewer.Image.BitsPerPixel - 1;

                  _lowBit = _viewer.Image.LowBit;
                  if (_lowBit == -1) _lowBit = _viewer.Image.BitsPerPixel - 1;

                  _imageCategory = ImageCategory.GrayScale_8_12_16_BPP;

                  _lblPaletteValue.Visible = false;
                  _lblWidth.Visible = false;
                  _lblLevel.Visible = false;

                  break;
               case 12:
               case 16:
                  _viewer.Image.UseLookupTable = true;
                  _currentPalette = _viewer.Image.GetLookupTable();
                  _currentPalette16 = _viewer.Image.GetLookupTable16();
                  _highBit = _viewer.Image.HighBit;
                  if (_highBit == -1) _highBit = _viewer.Image.BitsPerPixel - 1;

                  _lowBit = _viewer.Image.LowBit;
                  if (_lowBit == -1) _lowBit = _viewer.Image.BitsPerPixel - 1;

                  if (_currentPalette != null)
                      _LUTSize = _currentPalette.Length;
                  else
                     _LUTSize = (int)Math.Pow(2, _highBit + 1);

                  if (_currentPalette16 != null)
                      _LUTSize16 = _currentPalette16.Length;
                  else
                      _LUTSize16 = (int)Math.Pow(2, _highBit + 1);

                  if (_currentPalette != null || _currentPalette16 != null)
                  {
                     MinMaxValuesCommand minMaxValueCmd = new MinMaxValuesCommand();
                     minMaxValueCmd.Run(_viewer.Image);
                     _maxValue = minMaxValueCmd.MaximumValue;
                     _minValue = minMaxValueCmd.MinimumValue;
                  }
                  else
                  {
                      _maxValue = (_viewer.Image.Signed) ? _LUTSize / 2 - 1 : _LUTSize - 1;
                      _minValue = (_viewer.Image.Signed) ? -_LUTSize / 2 : 0;
                  }

                  _imageCategory = ImageCategory.GrayScale_8_12_16_BPP;
                  _isGray = true;
                  break;
               case 1:
                  _imageCategory = ImageCategory.OneBitImage;
                  _isGray = false;
                  _lblPaletteValue.Visible = false;
                  _lblWidth.Visible = false;
                  _lblLevel.Visible = false;
                  break;
            }
         }
         else
         {
            _imageCategory = ImageCategory.ColoredImage;
            _isGray = false;
            _lblPaletteValue.Visible = false;
            _lblWidth.Visible = false;
            _lblLevel.Visible = false;
         }
         if (_viewer.Image.Signed)
            _flags |= RasterPaletteWindowLevelFlags.Signed;

         _maxWidth = (int)Math.Pow(2, _viewer.Image.BitsPerPixel);
         _minWidth = 1;
         _maxLevel = (int)Math.Pow(2, _viewer.Image.BitsPerPixel) - 1;
         _minLevel = (int)Math.Pow(2, _viewer.Image.BitsPerPixel) * -1 + 1;
         _scale = ((_maxValue - _minValue) / 10000 > 0) ? (_maxValue - _minValue) / 10000 : 1;

          getWindowLevel();

         _lblBPP.Text = " BPP = " + _viewer.Image.BitsPerPixel;
         _lblImageSize.Text = _viewer.Image.Width + "X" + _viewer.Image.Height;
         _lblSigned.Text = (_viewer.Image.Signed) ? "Signed Image" : "UnSigned Image";
         this.Text = GetWindowTitle(title);
      }

      public void save()
      {
         ImageFileSaver saver = new ImageFileSaver();
         try
         {
            saver.Save(this, _codecs, _viewer.Image);
         }
         catch (Exception ex)
         {
            MessageBox.Show(ex.Message);
         }
      }

      public void CombineFloater()
      {
         if ((_viewer.FloaterOpacity == 1) && _viewer.Floater != null)
         {
            DisableInteractiveModes(_viewer);
            _viewer.InteractiveModes.EnableById(NoneInteractiveMode.Id);
            _viewer.CombineFloater(true);
            _viewer.Floater = null;
            addToImageList();
         }
         floaterImageslist.Clear();
         _floaterImageIndex = 0;
         UpdateAfterCommandExecution();
         _parent.UpdateMyControls();
      }

      void cursorData(int x, int y, int CurX, int CurY)
      {
         try
         {
            if (x < _viewer.Image.Width && y < _viewer.Image.Height && _isGray && _viewer.Image.BitsPerPixel != 12)
            {
               x = (x >= 0) ? x : 0;
               y = (y >= 0) ? y : 0;
               byte[] Data;
               int originalValue = 0, originalValueT = 0;

               _viewer.Image.Access();
               Data = _viewer.Image.GetPixelData(y, x);
               _viewer.Image.Release();

               switch (_viewer.Image.BitsPerPixel)
               {
                  case 16:
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

               _lblRGB.Text = "RGB in the original image = " + originalValueT;
               if (_currentPalette != null)
                _lblPaletteValue.Text = "Palette map value = " + _currentPalette[originalValue].B;
               
            }
            else
            {
               RasterColor tmpColor = _viewer.Image.GetPixelColor(y, x);
               _lblRGB.Text = string.Format("RGB = ({0},{1},{2})", tmpColor.R, tmpColor.G, tmpColor.B);
               _lblPaletteValue.Text = "Palette map value = " + " 0";
            }

            if (_pressed == PressedButton.LeftBotton && NoneInteractiveMode.IsEnabled &&
               _regionType == RegionType.NONE && _viewer.Floater == null && !_parent.IsSegmentation)
            {
               string tipMessage = string.Format("X = {1} , Y = {2} {0}{3} {0}{4}",
                     Environment.NewLine, x, y, _lblPaletteValue.Text, _lblRGB.Text);
               _toolTip.Show(tipMessage, _viewer, CurX + 25, CurY + 25);
            }

            _lblX.Text = " X = " + x;
            _lblY.Text = " Y = " + y;
         }
         catch { }
      }

      void getWindowLevel()
      {
          if (_isGray == false || _viewer.Image.BitsPerPixel == 0) return ;

         try
         {
            int lowValue = 0, highValue = 0;
            int max = _maxValue;
            int min = _minValue;

            if (_viewer.Image.BitsPerPixel != 8)
            {
                RasterColor[] palette = _viewer.Image.GetLookupTable();
                if (palette != null && palette.Length != 0)
                {
                    GetLinearVoiLookupTableCommand cmd = new GetLinearVoiLookupTableCommand();
                    cmd.Run(_viewer.Image);
                    highValue = (int)(cmd.Center + cmd.Width / 2);
                    lowValue  = (int)(cmd.Center - cmd.Width / 2);
                }
                        else
                {
                    MinMaxValuesCommand cmd = new MinMaxValuesCommand();
                    cmd.Run(_viewer.Image);
                    highValue = cmd.MaximumValue ;
                    lowValue  = cmd.MinimumValue ;
                }
                     }
                     else
                     {
                RasterColor[] palette = _viewer.Image.GetPalette();

                if (palette != null && palette.Length == 256)
                {
                    int value1 = palette[0].R;
                    int value2 = palette[0xff].R;
                    int i;
                    int nFrom = 0;
                    int nTo = 255;

                    for (i = 1; i < 256; i++)
                    {
                        if (palette[i].R != value1)
                        {
                            nFrom = i - 1;
                              break;
                        }
                    }

                    for (i = 254; i > 0; i--)
                    {
                        if (palette[i].R != value2)
                        {
                            nTo = i + 1;
                     break;
                  }
                    }

                    highValue = nTo ;
                    lowValue = nFrom ;
                  }
            }

            _width = highValue - lowValue + 1;
            _level = (highValue + lowValue) / 2;
            CheckValue(ref _width, (int)Math.Pow(2, _viewer.Image.BitsPerPixel), 1);
            CheckValue(ref _level, (int)Math.Pow(2, _viewer.Image.BitsPerPixel) - 1, (int)Math.Pow(2, _viewer.Image.BitsPerPixel) * -1 + 1);

            ChangeThePalette();
         }
         catch (Exception /*ex*/)
         {
         }
      }

      public void histogram()
      {
         RasterImage tmpImage = (_viewer.Floater == null) ? _viewer.Image : _viewer.Floater;
         HistogramDlg dlg = new HistogramDlg(tmpImage, _isGray);
         dlg.ShowDialog();
      }

      public void fillCommand()
      {
         FillCommand command;
         FillDialog dlg = new FillDialog(_isGray, FillDialog.TypeConstants.Fill);
         if (dlg.ShowDialog(this) == DialogResult.OK)
         {
            command = new FillCommand();
            if (_isGray)
               command.Color = new RasterColor(dlg.Level, dlg.Level, dlg.Level);
            else
               command.Color = Converters.FromGdiPlusColor(dlg.FillColor);
            if (_viewer.Floater == null)
               command.Run(_viewer.Image);
            else
               command.Run(_viewer.Floater);

            addToImageList();
         }
      }

      public void fastMagicWandCommand()
      {
         ValueDialog dlg = new ValueDialog(ValueDialog.TypeConstants.FastMagicWand);
         if (dlg.ShowDialog(this) == DialogResult.OK)
         {
            _lowerTolerance = dlg.Value;
         }
      }

      public void setPixelColor()
      {
         SetPixelColorDialog dlg = new SetPixelColorDialog(_imageCategory, _viewer.Image.BitsPerPixel);
         dlg.MaxX = _viewer.Image.Width - 1;
         dlg.MaxY = _viewer.Image.Height - 1;
         if (_isGray)
            dlg.MaxLevel = Convert.ToInt32(Math.Pow(2.0, _viewer.Image.BitsPerPixel) - 1);

         if (dlg.ShowDialog(this) == DialogResult.OK)
         {
            byte[] Data = null;

            _viewer.Image.GetPixelData(dlg.PtY, dlg.PtX);
            string binary = Convert.ToString(dlg.Level, 2);
            string green, blue, red;
            switch (_viewer.Image.BitsPerPixel)
            {
               case 1:
                  _viewer.Image.SetPixelColor(dlg.PtY, dlg.PtX, new RasterColor(dlg.Level, dlg.Level, dlg.Level));
                  break;

               case 12:
               case 16:
                  Data = _viewer.Image.GetPixelData(dlg.PtY, dlg.PtX);
                  binary = binary.PadLeft(16, '0');
                  Data[1] = byte.Parse(Convert.ToInt32(binary.Substring(0, 8), 2).ToString());
                  Data[0] = byte.Parse(Convert.ToInt32(binary.Substring(8, 8), 2).ToString());
                  _viewer.Image.SetPixelData(dlg.PtY, dlg.PtX, Data);
                  break;
               case 8:
                  Data = _viewer.Image.GetPixelData(dlg.PtY, dlg.PtX);
                  binary = binary.PadLeft(8, '0');
                  Data[0] = byte.Parse(Convert.ToInt32(binary.Substring(0, 8), 2).ToString());
                  _viewer.Image.SetPixelData(dlg.PtY, dlg.PtX, Data);
                  break;
               case 24:
                  Data = _viewer.Image.GetPixelData(dlg.PtY, dlg.PtX);
                  binary = binary.PadLeft(24, '0');
                  Data[2] = dlg.R;
                  Data[1] = dlg.G;
                  Data[0] = dlg.B;
                  _viewer.Image.SetPixelData(dlg.PtY, dlg.PtX, Data);
                  break;
               case 32:
                  Data = _viewer.Image.GetPixelData(dlg.PtY, dlg.PtX);
                  binary = binary.PadLeft(32, '0');
                  Data[3] = 0;
                  Data[2] = dlg.R;
                  Data[1] = dlg.G;
                  Data[0] = dlg.B;
                  _viewer.Image.SetPixelData(dlg.PtY, dlg.PtX, Data);
                  break;
               case 46:
                  Data = _viewer.Image.GetPixelData(dlg.PtY, dlg.PtX);
                  red = Convert.ToString(dlg.R * 255, 2);
                  green = Convert.ToString(dlg.G * 255, 2);
                  blue = Convert.ToString(dlg.B * 255, 2);
                  red = red.PadLeft(16, '0');
                  green = green.PadLeft(16, '0');
                  blue = blue.PadLeft(16, '0');
                  Data[5] = byte.Parse(Convert.ToInt32(red.Substring(0, 8), 2).ToString());
                  Data[4] = byte.Parse(Convert.ToInt32(red.Substring(8, 8), 2).ToString());
                  Data[3] = byte.Parse(Convert.ToInt32(green.Substring(0, 8), 2).ToString());
                  Data[2] = byte.Parse(Convert.ToInt32(green.Substring(8, 8), 2).ToString());
                  Data[1] = byte.Parse(Convert.ToInt32(blue.Substring(0, 8), 2).ToString());
                  Data[0] = byte.Parse(Convert.ToInt32(blue.Substring(8, 8), 2).ToString());
                  _viewer.Image.SetPixelData(dlg.PtY, dlg.PtX, Data);
                  break;
               case 64:
                  Data = _viewer.Image.GetPixelData(dlg.PtY, dlg.PtX);
                  Data[7] = 0;
                  Data[6] = 0;
                  red = Convert.ToString(dlg.R * 255, 2);
                  green = Convert.ToString(dlg.G * 255, 2);
                  blue = Convert.ToString(dlg.B * 255, 2);
                  red = red.PadLeft(16, '0');
                  green = green.PadLeft(16, '0');
                  blue = blue.PadLeft(16, '0');
                  Data[5] = byte.Parse(Convert.ToInt32(red.Substring(0, 8), 2).ToString());
                  Data[4] = byte.Parse(Convert.ToInt32(red.Substring(8, 8), 2).ToString());
                  Data[3] = byte.Parse(Convert.ToInt32(green.Substring(0, 8), 2).ToString());
                  Data[2] = byte.Parse(Convert.ToInt32(green.Substring(8, 8), 2).ToString());
                  Data[1] = byte.Parse(Convert.ToInt32(blue.Substring(0, 8), 2).ToString());
                  Data[0] = byte.Parse(Convert.ToInt32(blue.Substring(8, 8), 2).ToString());
                  _viewer.Image.SetPixelData(dlg.PtY, dlg.PtX, Data);
                  break;
            }
            if (_isGray)
            {
               MinMaxValuesCommand cmd = new MinMaxValuesCommand();
               cmd.Run(_viewer.Image);
               _maxValue = cmd.MaximumValue;
               _minValue = cmd.MinimumValue;
            }
         }
      }

      public void page()
      {
         UpdateAfterCommandExecution();
      }

      public void average()
      {
         ValueDialog dlg = new ValueDialog(ValueDialog.TypeConstants.Average);
         if (dlg.ShowDialog(this) == DialogResult.OK)
         {
            AverageCommand command = new AverageCommand(dlg.Value);
            if (_viewer.Floater == null)
               command.Run(_viewer.Image);
            else
               command.Run(_viewer.Floater);

            addToImageList();
         }
      }

      public void noiseMax()
      {
         ValueDialog dlg = new ValueDialog(ValueDialog.TypeConstants.Maximum);
         if (dlg.ShowDialog(this) == DialogResult.OK)
         {
            MaximumCommand command = new MaximumCommand(dlg.Value);
            if (_viewer.Floater == null)
               command.Run(_viewer.Image);
            else
               command.Run(_viewer.Floater);

            addToImageList();
         }
      }

      public void noiseMin()
      {
         ValueDialog dlg = new ValueDialog(ValueDialog.TypeConstants.Minimum);
         if (dlg.ShowDialog(this) == DialogResult.OK)
         {
            MinimumCommand command = new MinimumCommand(dlg.Value);
            if (_viewer.Floater == null)
               command.Run(_viewer.Image);
            else
               command.Run(_viewer.Floater);

            addToImageList();
         }
      }

      public void noiseMedian()
      {
         ValueDialog dlg = new ValueDialog(ValueDialog.TypeConstants.Median);
         if (dlg.ShowDialog(this) == DialogResult.OK)
         {
            MedianCommand command = new MedianCommand(dlg.Value);
            if (_viewer.Floater == null)
               command.Run(_viewer.Image);
            else
               command.Run(_viewer.Floater);

            addToImageList();
         }
      }

      public void sharpen()
      {
         ValueDialog dlg = new ValueDialog(ValueDialog.TypeConstants.Sharpen);
         if (dlg.ShowDialog(this) == DialogResult.OK)
         {
            SharpenCommand command = new SharpenCommand(dlg.Value * 10);
            if (_viewer.Floater == null)
               command.Run(_viewer.Image);
            else
               command.Run(_viewer.Floater);

            addToImageList();
         }
      }

      public void unSharpen()
      {
         UnSharpenDailog dlg = new UnSharpenDailog(_viewer.Image.BitsPerPixel);
         if (dlg.ShowDialog(this) == DialogResult.OK)
         {
            UnsharpMaskCommand command = new UnsharpMaskCommand(dlg.Amount, dlg.Radius, dlg.Threshold, dlg.ColorSpace);
            if (_viewer.Floater == null)
               command.Run(_viewer.Image);
            else
               command.Run(_viewer.Floater);

            addToImageList();
         }
      }

      public void edgeDetection()
      {
         EdgeDetectorDialog dlg = new EdgeDetectorDialog(_minValue, _maxValue, _isGray);
         if (dlg.ShowDialog(this) == DialogResult.OK)
         {
            EdgeDetectorCommand command = new EdgeDetectorCommand(dlg.Threshold, dlg.Filter);
            if (_viewer.Floater == null)
               command.Run(_viewer.Image);
            else
               command.Run(_viewer.Floater);

            addToImageList();
         }
      }

      public void edgeContour()
      {
         ContourDialog dlg = new ContourDialog();
         if (dlg.ShowDialog(this) == DialogResult.OK)
         {
            ContourFilterCommand command = new ContourFilterCommand(dlg.Threshold, dlg.DeltaDirection, dlg.MaximumError, dlg.Type);
            if (_viewer.Floater == null)
               command.Run(_viewer.Image);
            else
               command.Run(_viewer.Floater);

            addToImageList();
         }
      }

      public void gauissian()
      {
         ValueDialog dlg = new ValueDialog(ValueDialog.TypeConstants.Gaussian);
         if (dlg.ShowDialog(this) == DialogResult.OK)
         {
            GaussianCommand command = new GaussianCommand(dlg.Value);
            if (_viewer.Floater == null)
               command.Run(_viewer.Image);
            else
               command.Run(_viewer.Floater);

            addToImageList();

         }
      }

      public void contrast()
      {
         ValueDialog dlg = new ValueDialog(ValueDialog.TypeConstants.Contrast);
         if (dlg.ShowDialog(this) == DialogResult.OK)
         {
            ChangeContrastCommand command = new ChangeContrastCommand(dlg.Value);
            if (_viewer.Floater == null)
               command.Run(_viewer.Image);
            else
               command.Run(_viewer.Floater);

            addToImageList();
         }
      }

      public void brightness()
      {
         ValueDialog dlg = new ValueDialog(ValueDialog.TypeConstants.Brightness);
         if (dlg.ShowDialog(this) == DialogResult.OK)
         {
            ChangeIntensityCommand command = new ChangeIntensityCommand(dlg.Value);
            if (_viewer.Floater == null)
               command.Run(_viewer.Image);
            else
               command.Run(_viewer.Floater);

            addToImageList();
         }
      }

      public void saturation()
      {
         ValueDialog dlg = new ValueDialog(ValueDialog.TypeConstants.Saturation);
         if (dlg.ShowDialog(this) == DialogResult.OK)
         {
            ChangeSaturationCommand command = new ChangeSaturationCommand(dlg.Value);
            if (_viewer.Floater == null)
               command.Run(_viewer.Image);
            else
               command.Run(_viewer.Floater);

            addToImageList();
         }
      }

      public void histogramEqualizer()
      {
         EqualizerDialog dlg = new EqualizerDialog();
         if (dlg.ShowDialog(this) == DialogResult.OK)
         {
            HistogramEqualizeCommand command = new HistogramEqualizeCommand(dlg.ColorSpace);
            if (_viewer.Floater == null)
               command.Run(_viewer.Image);
            else
               command.Run(_viewer.Floater);

            addToImageList();
         }
      }

      public void histogramAdaptiveContrast()
      {
         AdaptiveContrastDialog dlg = new AdaptiveContrastDialog();
         if (dlg.ShowDialog(this) == DialogResult.OK)
         {
            AdaptiveContrastCommand command = new AdaptiveContrastCommand();
            command.Amount = dlg.Amount;
            command.Dimension = dlg.Dimentions;
            command.Type = dlg.AdaptiveContrastType;
            if (_viewer.Floater == null)
               command.Run(_viewer.Image);
            else
               command.Run(_viewer.Floater);

            addToImageList();
         }
      }

      public void histogramLocalEqualizer()
      {
         LocalEqualizerDialog dlg = new LocalEqualizerDialog(_viewer.Image.Width, _viewer.Image.Height);
         if (dlg.ShowDialog(this) == DialogResult.OK)
         {
            LocalHistogramEqualizeCommand command = new LocalHistogramEqualizeCommand();
            command.Width = dlg.nWidth;
            command.Height = dlg.nHeight;
            command.WidthExtension = dlg.nWidthExt;
            command.HeightExtension = dlg.nHeightExt;
            command.Smooth = dlg.nSmooth;
            command.Type = dlg.EqualizeType;
            if (_viewer.Floater == null)
               command.Run(_viewer.Image);
            else
               command.Run(_viewer.Floater);

            addToImageList();
         }
      }

      public void autoLevel()
      {
         AutoColorLevelCommand command = new AutoColorLevelCommand();
         command.Type = AutoColorLevelCommandType.Level;
         if (_viewer.Floater == null)
            command.Run(_viewer.Image);
         else
            command.Run(_viewer.Floater);

         addToImageList();
      }

      public void autoContrast()
      {
         AutoColorLevelCommand command = new AutoColorLevelCommand();
         command.Type = AutoColorLevelCommandType.Contrast;
         if (_viewer.Floater == null)
            command.Run(_viewer.Image);
         else
            command.Run(_viewer.Floater);

         addToImageList();
      }

      public void autoIntensity()
      {
         AutoColorLevelCommand command = new AutoColorLevelCommand();
         command.Type = AutoColorLevelCommandType.Intensity;
         if (_viewer.Floater == null)
            command.Run(_viewer.Image);
         else
            command.Run(_viewer.Floater);

         addToImageList();
      }

      public void Sensitivity()
      {
         SensitivityDialog dlg = new SensitivityDialog(_scale);
         if (dlg.ShowDialog(this) == DialogResult.OK)
         {
            _scale = dlg.SenValue;
         }
      }

      public void deskew()
      {
         DeskewDailog dlg = new DeskewDailog(_isGray);
         if (dlg.ShowDialog(this) == DialogResult.OK)
         {
            DeskewCommand command = new DeskewCommand(dlg.FillColor, dlg.Flags);
            command.Flags = DeskewCommandFlags.ReturnAngleOnly | DeskewCommandFlags.UseNormalDetection;

            if (_viewer.Floater == null)
               command.Run(_viewer.Image);
            else
               command.Run(_viewer.Floater);

            addToImageList();
         }
      }

      public void blankPageDetection()
      {
         BlankPageDetectorCommand command = new BlankPageDetectorCommand(BlankPageDetectorCommandFlags.UseAdvanced | BlankPageDetectorCommandFlags.DetectNoisyPage | BlankPageDetectorCommandFlags.UseBleedThrough, 0, 0, 0, 0);
         if (_viewer.Floater == null)
            command.Run(_viewer.Image);
         else
            command.Run(_viewer.Floater);
         MessageBox.Show(" Is Blank   : " + command.IsBlank + "\n Accuracy : " + (command.Accuracy * 1.0 / 100) + "%", "Blank Page Detection Results");
      }

      public void shear()
      {
         ShearDialog dlg = new ShearDialog(_isGray);
         if (dlg.ShowDialog(this) == DialogResult.OK)
         {
            ShearCommand cmd = new ShearCommand();
            cmd.Angle = dlg.Angle;
            cmd.Horizontal = dlg.Horizontal;
            if (_isGray)
               cmd.FillColor = new RasterColor(dlg.FillColorLevel, dlg.FillColorLevel, dlg.FillColorLevel);
            else
               cmd.FillColor = Converters.FromGdiPlusColor(dlg.FillColor);
            if (_viewer.Floater == null)
               cmd.Run(_viewer.Image);
            else
               cmd.Run(_viewer.Floater);

            addToImageList();
         }
      }

      public void autoBinarize()
      {
         AutoBinarizeCommand command = new AutoBinarizeCommand();
         if (_viewer.Floater == null)
            command.Run(_viewer.Image);
         else
            command.Run(_viewer.Floater);

         addToImageList();
      }

      public void intensityDetect()
      {
         IntensityDetectDailog dlg = new IntensityDetectDailog(_isGray);
         if (dlg.ShowDialog(this) == DialogResult.OK)
         {
            IntensityDetectCommand command = new IntensityDetectCommand(dlg.Low, dlg.High, dlg.InColor, dlg.OutColor, dlg.Channel);
            _currentPalette = _viewer.Image.GetPalette();
            if (_viewer.Floater == null)
               command.Run(_viewer.Image);
            else
               command.Run(_viewer.Floater);

            addToImageList();
            _currentPalette = _viewer.Image.GetPalette();
         }
      }

      public void KMeans()
      {
         KMeansDialog dlg = new KMeansDialog();
         if (dlg.ShowDialog() == DialogResult.OK)
         {
            KMeansCommand command = new KMeansCommand(dlg.Clusters, dlg.Type, null);
            command.Run(_viewer.Image);
         addToImageList();
         }
      }

      public void Otsu(MainForm mainPt)
      {
         OtsuThresholdDialog dlg = new OtsuThresholdDialog(mainPt);
         if (dlg.ShowDialog() == DialogResult.OK)
         {
            OtsuThresholdCommand command = new OtsuThresholdCommand(dlg.Clusters);
            command.Run(_viewer.Image);
         }
      }

      public void Lambda()
      {
         LambdaConnectednessDialog dlg = new LambdaConnectednessDialog();
         if (dlg.ShowDialog() == DialogResult.OK)
         {
            LambdaConnectednessCommand command = new LambdaConnectednessCommand(dlg.Lambda);
            command.Run(_viewer.Image);
         addToImageList();
         }
      }

      public void LevelSet()
      {
         LevelsetCommand command = new LevelsetCommand();
         command.Run(_viewer.Image);

         _viewer.ActiveItem.ImageRegionToFloater();
         _viewer.Image.SetRegion(null, null, RasterRegionCombineMode.Set);
         DisableInteractiveModes(_viewer);
         _viewer.InteractiveModes.EnableById(FloaterInteractiveMode.Id);

         _viewer.FloaterOpacity = 1;
      }

      public void ShrinkTool()
      {

      }

      public void TDAFilter()
      {
         TDAFilterDialog dlg = new TDAFilterDialog();
         if (dlg.ShowDialog(this) == DialogResult.OK)
         {
            TADAnisotropicDiffusionCommand command = new TADAnisotropicDiffusionCommand(dlg.Iterations, dlg.Lambda, dlg.Kappa, dlg.Flux);
            command.Run(_viewer.Image);
         addToImageList();
         }
      }

      public void SRADFilter()
      {
         SRADFilterDialog dlg = new SRADFilterDialog();
         if (dlg.ShowDialog() == DialogResult.OK)
         {
            SRADAnisotropicDiffusionCommand command = new SRADAnisotropicDiffusionCommand(dlg.Iterations, dlg.Lambda, new LeadRect(10, 10, _viewer.Image.Width - 20, _viewer.Image.Height - 20));
            command.Run(_viewer.Image);
         addToImageList();
         }
      }

      public void AutoCrop()
      {
         ValueDialog dlg = new ValueDialog(ValueDialog.TypeConstants.AutoCrop);
         if (dlg.ShowDialog() == DialogResult.OK)
         {
            AutoCropCommand cmd = new AutoCropCommand(dlg.Value);
            if (_viewer.Floater == null)
               cmd.Run(_viewer.Image);
            else
               cmd.Run(_viewer.Floater);

            addToImageList();
         }
      }

      public void Despeckle()
      {
         DespeckleCommand command = new DespeckleCommand();
         if (_viewer.Floater == null)
            command.Run(_viewer.Image);
         else
            command.Run(_viewer.Floater);

         addToImageList();
      }

      public void Dilate()
      {
         BinaryFilterCommand command = new BinaryFilterCommand(BinaryFilterCommandPredefined.DilationOmniDirectional);
         if (_viewer.Floater == null)
            command.Run(_viewer.Image);
         else
            command.Run(_viewer.Floater);

         addToImageList();
      }

      public void Erode()
      {
         BinaryFilterCommand command = new BinaryFilterCommand(BinaryFilterCommandPredefined.ErosionOmniDirectional);
         if (_viewer.Floater == null)
            command.Run(_viewer.Image);
         else
            command.Run(_viewer.Floater);

         addToImageList();
      }

      public void UnditherText()
      {
         MedianCommand cmdMedian = new MedianCommand(3);
         MinimumCommand cmdMin = new MinimumCommand(2);
         if (_viewer.Floater == null)
         {
            cmdMedian.Run(_viewer.Image);
            cmdMin.Run(_viewer.Image);
         }
         else
         {
            cmdMedian.Run(_viewer.Floater);
            cmdMin.Run(_viewer.Floater);
         }

         addToImageList();
      }

      public void FixBrokenLetters()
      {
         MinimumCommand cmdMin = new MinimumCommand(2);
         if (_viewer.Floater == null)
            cmdMin.Run(_viewer.Image);
         else
            cmdMin.Run(_viewer.Floater);

         addToImageList();
      }

      public void LineRemove()
      {
         LineRemoveCommand horizontalRemoveCommand = new LineRemoveCommand();
         horizontalRemoveCommand.Type = LineRemoveCommandType.Horizontal;

         LineRemoveCommand verticalRemoveCommand = new LineRemoveCommand();
         verticalRemoveCommand.Type = LineRemoveCommandType.Vertical;

         if (_viewer.Floater == null)
         {
            horizontalRemoveCommand.Run(_viewer.Image);
            verticalRemoveCommand.Run(_viewer.Image);
         }
         else
         {
            horizontalRemoveCommand.Run(_viewer.Floater);
            verticalRemoveCommand.Run(_viewer.Floater);
         }

         addToImageList();
      }

      public void invPerspective(MainForm mainPt)
      {
         PerspectiveDialog dlg = new PerspectiveDialog(mainPt, this);
         dlg.TopMost = true;
         dlg.Show();
         dlg.FormClosed += new FormClosedEventHandler(dlg_FormClosed);
      }

       public void BackgroundRemoval(MainForm mainPt)
       {
           BackgroundRemovalDialog dlg = new BackgroundRemovalDialog(mainPt, this, false);
           if (dlg.ShowDialog() == DialogResult.OK)
           {
               addToImageList();
           }
       }

      public void shrinkTool(MainForm mainPt)
      {
         ShrinkWrapDialog dlg = new ShrinkWrapDialog(mainPt, this);
         dlg.TopMost = true;
         dlg.Show();
      }

      void dlg_FormClosed(object sender, FormClosedEventArgs e)
      {
         addToImageList();
      }

      public void gWireTool(MainForm mainPt)
      {
         GWireDialog dlg = new GWireDialog(this, mainPt);
         dlg.TopMost = true;
         dlg.Show();

      }

      public void AnisotropicDiffusion()
      {
         AnisotropicDiffusionDialog dlg = new AnisotropicDiffusionDialog();
         if (dlg.ShowDialog() == DialogResult.OK)
         {
            using (WaitCursor wait = new WaitCursor())
            {
               AnisotropicDiffusionCommand cmd = new AnisotropicDiffusionCommand();
               cmd.Iterations = dlg.Iterations; // 20
               cmd.Smoothing = dlg.Smoothing;// 1
               cmd.TimeStep = dlg.TimeStep; // 40.0
               cmd.MaxVariation = dlg.MaxVariation; // 90.0
               cmd.MinVariation = dlg.MinVariation; //50.0
               cmd.Update = dlg.nUpdate; // 10
               cmd.EdgeHeight = dlg.EdgeHeight; // 5.0

               if (_viewer.Floater == null)
                  cmd.Run(_viewer.Image);
               else
                  cmd.Run(_viewer.Floater);

               addToImageList();
            }
         }
      }

      public void DigitalSubtract()
      {
         List<ViewerImages> images = new List<ViewerImages>();

         for (int i = 0; i < this.MdiParent.MdiChildren.Length; i++)
         {
            //images.Add(new ViewerImages(Path.GetFileNameWithoutExtension(this.MdiParent.MdiChildren[i].Text),
            images.Add(new ViewerImages(this.MdiParent.MdiChildren[i].Text,
               ((ViewerForm)this.MdiParent.MdiChildren[i]).Id, ((ViewerForm)this.MdiParent.MdiChildren[i]).Image));
         }

         DigitalSubtractDialog dlg = new DigitalSubtractDialog(images, _viewer.Image);
         if (dlg.ShowDialog() == DialogResult.OK)
         {
            if (((ViewerForm)this.MdiParent.MdiChildren[dlg.ImageID]).Viewer.Floater != null)
            {
               ((ViewerForm)this.MdiParent.MdiChildren[dlg.ImageID]).Viewer.CombineFloater(true);
               ((ViewerForm)this.MdiParent.MdiChildren[dlg.ImageID]).Viewer.Floater = null;
               DisableInteractiveModes(_viewer);
               ((ViewerForm)this.MdiParent.MdiChildren[dlg.ImageID]).Viewer.InteractiveModes.EnableById(NoneInteractiveMode.Id);
            }

            DigitalSubtractCommand cmd = new DigitalSubtractCommand();
            cmd.MaskImage = ((ViewerForm)this.MdiParent.MdiChildren[dlg.ImageID]).Viewer.Image;
            cmd.Flags = dlg.Flags;

            if (_viewer.Floater != null)
               CombineFloater();

            cmd.Run(_viewer.Image);

            addToImageList();
         }
      }

      public void MeanShift()
      {
         MeanShiftDialog dlg = new MeanShiftDialog();
         if (dlg.ShowDialog() == DialogResult.OK)
         {
            using (WaitCursor wait = new WaitCursor())
            {
               MeanShiftCommand cmd = new MeanShiftCommand();
               cmd.Radius = dlg.Radius;
               cmd.ColorDistance = dlg.ColorDistance;

               if (_viewer.Floater == null)
                  cmd.Run(_viewer.Image);
               else
                  cmd.Run(_viewer.Floater);

               addToImageList();
            }
         }
      }

      public void MultiscaleEnhancement(MainForm mainPt)
      {
          MultiscaleEnhancementDialog dlg = new MultiscaleEnhancementDialog(mainPt, this);
          if (dlg.ShowDialog() == DialogResult.OK)
          {
              addToImageList();
          }
      }

      public void SelectData()
      {
         SelectDataDialog dlg = new SelectDataDialog();
         if (dlg.ShowDialog() == DialogResult.OK)
         {
            SelectDataCommand cmd = new SelectDataCommand();
            cmd.Threshold = dlg.Threshold;
            cmd.Color = Converters.FromGdiPlusColor(dlg.dlgColor);
            cmd.Combine = dlg.Combine;
            cmd.SourceHighBit = dlg.SourceHighBit;
            cmd.SourceLowBit = dlg.SourceLowBit;

            cmd.Run(_viewer.Image);
            _viewer.Image.ReplacePage(_viewer.Image.Page, cmd.DestinationImage);

            addToImageList();
         }
      }

      public void ShiftData()
      {
         ShiftDataDialog dlg = new ShiftDataDialog(_viewer.Image.BitsPerPixel, _viewer.Image.Signed);
         if (dlg.ShowDialog() == DialogResult.OK)
         {
            ShiftDataCommand cmd = new ShiftDataCommand();
            cmd.SourceHighBit = dlg.SourceHighBit;
            cmd.SourceLowBit = dlg.SourceLowBit;
            cmd.DestinationBitsPerPixel = dlg.DestinationBitsPerPixel;
            cmd.DestinationLowBit = dlg.DestinationLowBit;

            cmd.Run(_viewer.Image);
            _viewer.Image.ReplacePage(_viewer.Image.Page, cmd.DestinationImage);

            addToImageList();
         }
      }

      public void Sigma()
      {
         SigmaDialog dlg = new SigmaDialog();
         if (dlg.ShowDialog() == DialogResult.OK)
         {
            SigmaCommand cmd = new SigmaCommand();
            cmd.Dimension = dlg.Dimension;
            cmd.Outline = dlg.Outline;
            cmd.Sigma = dlg.Sigma;
            cmd.Threshold = dlg.Threshold;

            _viewer.Image.MakeRegionEmpty();
            if (_viewer.Floater == null)
               cmd.Run(_viewer.Image);
            else
               cmd.Run(_viewer.Floater);
            addToImageList();
         }
      }

      public void TissueEqualize()
      {
         TissueEqualizeDialog dlg = new TissueEqualizeDialog();
         if (dlg.ShowDialog() == DialogResult.OK)
         {
            TissueEqualizeCommand cmd = new TissueEqualizeCommand(dlg.Flags);
            if (_viewer.Floater == null)
               cmd.Run(_viewer.Image);
            else
               cmd.Run(_viewer.Floater);

            addToImageList();
         }
      }

      public void Skeleton()
      {
         SkeletonCommand cmd = new SkeletonCommand();
         int maxThreshold;
         MinMaxValuesCommand cmdMinMax = new MinMaxValuesCommand(); ;

         if (_isGray)
         {
            cmdMinMax.Run(_viewer.Image);
            maxThreshold = cmdMinMax.MaximumValue;
         }
         else
            maxThreshold = 255;

         SkeletonDialog dlg = new SkeletonDialog(maxThreshold);
         if (dlg.ShowDialog() == DialogResult.OK)
         {
            cmd.Threshold = dlg.Threshold;
            if (_viewer.Floater == null)
               cmd.Run(_viewer.Image);
            else
               cmd.Run(_viewer.Floater);

            UpdateAfterCommandExecution();
            ChangeThePalette();
            addToImageList();
         }
      }

      void convertRegionToFloater()
      {
         _viewer.ActiveItem.ImageRegionToFloater();
         _viewer.FloaterOpacity = 1;
         DisableInteractiveModes(_viewer);
         _viewer.InteractiveModes.EnableById(FloaterInteractiveMode.Id);
         _viewer.Image.MakeRegionEmpty();
         floaterImageslist.Add(new RasterImage(_viewer.Floater));
         _floaterImageIndex = 0;
      }

      public void WLManually()
      {
         WindowLevelDialog dlg = new WindowLevelDialog(_level, _width, _minWidth, _maxWidth, _minLevel, _maxLevel);
         if (dlg.ShowDialog() == DialogResult.OK)
         {
            _width = dlg.WL_Width;
            _level = dlg.WL_Level;
            ChangeThePalette();
            _lblWidth.Text = " W = " + _width.ToString();
            _lblLevel.Text = " L = " + _level.ToString();
         }
      }

      public void _viewer_Paint(object sender, PaintEventArgs e)
      {
         LeadRect trackingRectangle = _viewer.ConvertRect(null, ImageViewerCoordinateType.Image, ImageViewerCoordinateType.Control, LeadRect.Create(_trackingRectangle.X, _trackingRectangle.Y, _trackingRectangle.Width, _trackingRectangle.Height));
         _trackingRectangle = new Rectangle(trackingRectangle.X, trackingRectangle.Y, trackingRectangle.Width, trackingRectangle.Height);
         float[] dashValuesWhite = { 4, 4, 4, 4 };
         Pen penBlack = new Pen(Color.Black, 1);
         Pen penWhite = new Pen(Color.White, 1);
         penWhite.DashPattern = dashValuesWhite;
         switch (_regionType)
         {
            case RegionType.RECTANGLE:
            case RegionType.AUTO_SEGMENT:
               e.Graphics.DrawRectangle(penBlack, _trackingRectangle);
               e.Graphics.DrawRectangle(penWhite, _trackingRectangle);
               break;
            case RegionType.ELLIPSE:
               e.Graphics.DrawEllipse(penBlack, _trackingRectangle);
               e.Graphics.DrawEllipse(penWhite, _trackingRectangle);
               break;
            case RegionType.ROUND_RECTANGLE:
               drawRoundRect(e, penBlack, penWhite);
               break;
            case RegionType.FREE_HAND:
               if (_freeHandIndex <= 1 || _viewer.Floater != null)
                  return;
               Point[] drawPoints = new Point[_freeHandIndex];
               _actualPoints = new LeadPoint[_freeHandIndex];
               for (int i = 0; i < _actualPoints.Length; i++)
               {
                  LeadPoint leadPoint = _viewer.ConvertPoint(null, ImageViewerCoordinateType.Image, ImageViewerCoordinateType.Control, new LeadPoint(_freeHandPoints[i].X, _freeHandPoints[i].Y));
                  drawPoints[i] = new Point(leadPoint.X, leadPoint.Y);
                  _actualPoints[i].X = _freeHandPoints[i].X;
                  _actualPoints[i].Y = _freeHandPoints[i].Y;
               }
               e.Graphics.DrawLines(penBlack, drawPoints);
               e.Graphics.DrawLines(penWhite, drawPoints);
               break;
         }
      }

      void drawRoundRect(PaintEventArgs e, Pen penBlack, Pen penWhite)
      {
         int left = _trackingRectangle.Left;
         int right = _trackingRectangle.Right;
         int top = _trackingRectangle.Top;
         int bottom = _trackingRectangle.Bottom;
         int width = _trackingRectangle.Width;
         int height = _trackingRectangle.Height;
         e.Graphics.DrawLine(penBlack, new Point(left + Convert.ToInt32(0.125 * width), top), new Point(right - Convert.ToInt32(0.125 * width), top));
         e.Graphics.DrawLine(penBlack, new Point(left + Convert.ToInt32(0.125 * width), bottom), new Point(right - Convert.ToInt32(0.125 * width), bottom));
         e.Graphics.DrawLine(penBlack, new Point(left, top + Convert.ToInt32(0.125 * height)), new Point(left, bottom - Convert.ToInt32(0.125 * height)));
         e.Graphics.DrawLine(penBlack, new Point(right, top + Convert.ToInt32(0.125 * height)), new Point(right, bottom - Convert.ToInt32(0.125 * height)));
         e.Graphics.DrawLine(penWhite, new Point(left + Convert.ToInt32(0.125 * width), top), new Point(right - Convert.ToInt32(0.125 * width), top));
         e.Graphics.DrawLine(penWhite, new Point(left + Convert.ToInt32(0.125 * width), bottom), new Point(right - Convert.ToInt32(0.125 * width), bottom));
         e.Graphics.DrawLine(penWhite, new Point(left, top + Convert.ToInt32(0.125 * height)), new Point(left, bottom - Convert.ToInt32(0.125 * height)));
         e.Graphics.DrawLine(penWhite, new Point(right, top + Convert.ToInt32(0.125 * height)), new Point(right, bottom - Convert.ToInt32(0.125 * height)));
         Rectangle rect = new Rectangle(left, top, Convert.ToInt32(width * 0.25) == 0 ? 1 : Convert.ToInt32(width * 0.25)
             , Convert.ToInt32(height * 0.25) == 0 ? 1 : Convert.ToInt32(height * 0.25));
         e.Graphics.DrawArc(penBlack, rect, 180.0F, 90.0F);
         e.Graphics.DrawArc(penWhite, rect, 180.0F, 90.0F);
         rect = new Rectangle(right - Convert.ToInt32(width * 0.25), top, Convert.ToInt32(width * 0.25) == 0 ? 1 : Convert.ToInt32(width * 0.25)
             , Convert.ToInt32(height * 0.25) == 0 ? 1 : Convert.ToInt32(height * 0.25));
         e.Graphics.DrawArc(penBlack, rect, 270.0F, 90.0F);
         e.Graphics.DrawArc(penWhite, rect, 270.0F, 90.0F);
         rect = new Rectangle(left, bottom - Convert.ToInt32(height * 0.25), Convert.ToInt32(width * 0.25) == 0 ? 1 : Convert.ToInt32(width * 0.25)
             , Convert.ToInt32(height * 0.25) == 0 ? 1 : Convert.ToInt32(height * 0.25));
         e.Graphics.DrawArc(penBlack, rect, 90.0F, 90.0F);
         e.Graphics.DrawArc(penWhite, rect, 90.0F, 90.0F);
         rect = new Rectangle(right - Convert.ToInt32(width * 0.25), bottom - Convert.ToInt32(height * 0.25),
             Convert.ToInt32(width * 0.25) == 0 ? 1 : Convert.ToInt32(width * 0.25), Convert.ToInt32(height * 0.25) == 0 ? 1 : Convert.ToInt32(height * 0.25));
         e.Graphics.DrawArc(penBlack, rect, 0, 90.0F);
         e.Graphics.DrawArc(penWhite, rect, 0, 90.0F);
      }

      public void freeHand()
      {
         _freeHandIndex = 0;
         _freeHandPoints = new Point[5000];
         _actualPoints = new LeadPoint[1000];
      }

      public void MagnifyGlass()
      {
         MagnifyGlassDialog dlg = new MagnifyGlassDialog(MagnifyGlassInteractiveMode);
         dlg.ShowDialog();
      }

      public void CombineImage()
      {
         List<ViewerImages> images = new List<ViewerImages>();

         for (int i = 0; i < this.MdiParent.MdiChildren.Length; i++)
         {
            //images.Add(new ViewerImages(Path.GetFileNameWithoutExtension(this.MdiParent.MdiChildren[i].Text),
            images.Add(new ViewerImages(this.MdiParent.MdiChildren[i].Text,
               ((ViewerForm)this.MdiParent.MdiChildren[i]).Id, ((ViewerForm)this.MdiParent.MdiChildren[i]).Image));
         }

         CombineImageDialog dlg = new CombineImageDialog(images, _viewer.Image);
         if (dlg.ShowDialog() == DialogResult.OK)
         {
            CombineFastCommand cmd = new CombineFastCommand();
            cmd.DestinationImage = _viewer.Image;
            cmd.Flags = dlg.Flag;
            cmd.DestinationRectangle = dlg.DestRect;
            cmd.SourcePoint = dlg.SourcePoint;

            cmd.Run(((ViewerForm)this.MdiParent.MdiChildren[dlg.ImageID]).Viewer.Image);

            addToImageList();
         }
      }

      public void CopyImage()
      {
          List<ViewerImages> images = new List<ViewerImages>();

          //ViewerImages viewer = new ViewerImages(Path.GetFileNameWithoutExtension(Text), Id, Image);
          ViewerImages viewer = new ViewerImages(Text, Id, Image);

          for (int i = 0; i < this.MdiParent.MdiChildren.Length; i++)
          {
             //images.Add(new ViewerImages(Path.GetFileNameWithoutExtension(this.MdiParent.MdiChildren[i].Text), ((ViewerForm)this.MdiParent.MdiChildren[i]).Id, ((ViewerForm)this.MdiParent.MdiChildren[i]).Image));
             images.Add(new ViewerImages(this.MdiParent.MdiChildren[i].Text, ((ViewerForm)this.MdiParent.MdiChildren[i]).Id, ((ViewerForm)this.MdiParent.MdiChildren[i]).Image));
          }

          CopyImageDialog dlg = new CopyImageDialog(viewer, images, _viewer.Image);
          if (dlg.ShowDialog() == DialogResult.OK)
          {
              RasterImage sourceImage = _viewer.Image.Clone();
              RasterImage destImage = ((ViewerForm)this.MdiParent.MdiChildren[dlg.ImageID]).Viewer.Image;

              if (destImage.BitsPerPixel != sourceImage.BitsPerPixel)
              {
                 ColorResolutionCommand colorRes = new ColorResolutionCommand(ColorResolutionCommandMode.InPlace, sourceImage.BitsPerPixel, sourceImage.Order, sourceImage.DitheringMethod, ColorResolutionCommandPaletteFlags.Optimized, null);
                 colorRes.Run(sourceImage);
              }

              if (sourceImage.Width == destImage.Width &&
                  sourceImage.Height == destImage.Height &&
                  sourceImage.BitsPerPixel == destImage.BitsPerPixel)
              {
                  CopyDataCommand cmd = new CopyDataCommand();
                  cmd.DestinationImage = destImage;
                  cmd.Run(sourceImage);
              }
              else
              {
                  sourceImage.Access();
                  destImage.Access();

                  int bytes = Math.Min(sourceImage.BytesPerLine, destImage.BytesPerLine);
                  int rows = Math.Min(sourceImage.Height, destImage.Height);
                  byte[] data = new byte[bytes];
                  for (int row = 0; row < rows; row++)
                  {
                      sourceImage.GetRow(row, data, 0, bytes);
                      destImage.SetRow(row, data, 0, bytes);
                  }

                  sourceImage.Release();
                  destImage.Release();
              }

              sourceImage.Dispose();
              addToImageList();
          }
      }

      public void StatisticsInformation()
      {
         RasterImage tmpImage = (_viewer.Floater == null) ? _viewer.Image : _viewer.Floater;
         ImageInformationDialog dlg = new ImageInformationDialog(tmpImage);
         dlg.ShowDialog();
      }

      public void LineHistogram()
      {
         this._viewer.MouseUp -= new System.Windows.Forms.MouseEventHandler(this.Viewer_MouseUp);
         this._viewer.MouseDown -= new System.Windows.Forms.MouseEventHandler(this.Viewer_MouseDown);
         this._viewer.MouseMove -= new System.Windows.Forms.MouseEventHandler(this.Viewer_MouseMove);
         this._viewer.MouseWheel -= new System.Windows.Forms.MouseEventHandler(this.Viewer_MouseWheel);
         _viewer.Paint -= new PaintEventHandler(_viewer_Paint);

         lineHistgramDlg = new LineHistogramDialog(this, _viewer, _isGray);
         lineHistgramDlg.Show();
         lineHistgramDlg.TopMost = true;
      }

      public void Separation()
      {
         try
         {
            ColorSeparateCommand command = new ColorSeparateCommand();
            CombineFloater();

            switch (_sepType)
            {
               case SeparationType.RGB:
                  command.Type = ColorSeparateCommandType.Rgb;
                  command.Run(_viewer.Image);

                  command.DestinationImage.Page = 1;
                  CreateColorPlaneWindow(command.DestinationImage.Clone(), "Blue Plane");

                  command.DestinationImage.Page = 2;
                  CreateColorPlaneWindow(command.DestinationImage.Clone(), "Green Plane");

                  command.DestinationImage.Page = 3;
                  CreateColorPlaneWindow(command.DestinationImage.Clone(), "Red Plane");
                  break;
               case SeparationType.HSV:
                  command.Type = ColorSeparateCommandType.Hsv;
                  command.Run(_viewer.Image);

                  command.DestinationImage.Page = 1;
                  CreateColorPlaneWindow(command.DestinationImage.Clone(), "Hue Plane");

                  command.DestinationImage.Page = 2;
                  CreateColorPlaneWindow(command.DestinationImage.Clone(), "Saturation Plane");

                  command.DestinationImage.Page = 3;
                  CreateColorPlaneWindow(command.DestinationImage.Clone(), "Value Plane");
                  break;
               case SeparationType.HLS:
                  command.Type = ColorSeparateCommandType.Hls;
                  command.Run(_viewer.Image);

                  command.DestinationImage.Page = 1;
                  CreateColorPlaneWindow(command.DestinationImage.Clone(), "Hue Plane");

                  command.DestinationImage.Page = 2;
                  CreateColorPlaneWindow(command.DestinationImage.Clone(), "Lightness Plane");

                  command.DestinationImage.Page = 3;
                  CreateColorPlaneWindow(command.DestinationImage.Clone(), "Saturation Plane");
                  break;
               case SeparationType.CMYK:
                  command.Type = ColorSeparateCommandType.Cmyk;
                  command.Run(_viewer.Image);

                  command.DestinationImage.Page = 1;
                  CreateColorPlaneWindow(command.DestinationImage.Clone(), "Cyan Plane");

                  command.DestinationImage.Page = 2;
                  CreateColorPlaneWindow(command.DestinationImage.Clone(), "Magenta Plane");

                  command.DestinationImage.Page = 3;
                  CreateColorPlaneWindow(command.DestinationImage.Clone(), "Yellow Plane");

                  command.DestinationImage.Page = 4;
                  CreateColorPlaneWindow(command.DestinationImage.Clone(), "Black Plane");
                  break;
               case SeparationType.CMY:
                  command.Type = ColorSeparateCommandType.Cmy;
                  command.Run(_viewer.Image);

                  command.DestinationImage.Page = 1;
                  CreateColorPlaneWindow(command.DestinationImage.Clone(), "Cyan Plane");

                  command.DestinationImage.Page = 2;
                  CreateColorPlaneWindow(command.DestinationImage.Clone(), "Magenta Plane");

                  command.DestinationImage.Page = 3;
                  CreateColorPlaneWindow(command.DestinationImage.Clone(), "Yellow Plane");
                  break;
               case SeparationType.ALPHA:
                  CreateColorPlaneWindow(_viewer.Image.CreateAlphaImage(), "Alpha Plane");
                  break;
               case SeparationType.YUV:
                  command.Type = ColorSeparateCommandType.Yuv;
                  command.Run(_viewer.Image);


                  command.DestinationImage.Page = 1;
                  CreateColorPlaneWindow(command.DestinationImage.Clone(), "Y Plane");

                  command.DestinationImage.Page = 2;
                  CreateColorPlaneWindow(command.DestinationImage.Clone(), "U Plane");

                  command.DestinationImage.Page = 3;
                  CreateColorPlaneWindow(command.DestinationImage.Clone(), "V Plane");
                  break;
               case SeparationType.XYZ:
                  command.Type = ColorSeparateCommandType.Xyz;
                  command.Run(_viewer.Image);


                  command.DestinationImage.Page = 1;
                  CreateColorPlaneWindow(command.DestinationImage.Clone(), "X Plane");

                  command.DestinationImage.Page = 2;
                  CreateColorPlaneWindow(command.DestinationImage.Clone(), "Y Plane");

                  command.DestinationImage.Page = 3;
                  CreateColorPlaneWindow(command.DestinationImage.Clone(), "Z Plane");
                  break;
               case SeparationType.LAB:
                  command.Type = ColorSeparateCommandType.Lab;
                  command.Run(_viewer.Image);


                  command.DestinationImage.Page = 1;
                  CreateColorPlaneWindow(command.DestinationImage.Clone(), "L Plane");

                  command.DestinationImage.Page = 2;
                  CreateColorPlaneWindow(command.DestinationImage.Clone(), "A Plane");

                  command.DestinationImage.Page = 3;
                  CreateColorPlaneWindow(command.DestinationImage.Clone(), "B Plane");
                  break;
               case SeparationType.YCRCB:
                  command.Type = ColorSeparateCommandType.Ycrcb;
                  command.Run(_viewer.Image);

                  command.DestinationImage.Page = 1;
                  CreateColorPlaneWindow(command.DestinationImage.Clone(), "Y Plane");

                  command.DestinationImage.Page = 2;
                  CreateColorPlaneWindow(command.DestinationImage.Clone(), "Cr Plane");

                  command.DestinationImage.Page = 3;
                  CreateColorPlaneWindow(command.DestinationImage.Clone(), "Cb Plane");
                  break;
               case SeparationType.SCT:
                  command.Type = ColorSeparateCommandType.Sct;
                  command.Run(_viewer.Image);


                  command.DestinationImage.Page = 1;
                  CreateColorPlaneWindow(command.DestinationImage.Clone(), "S Plane");

                  command.DestinationImage.Page = 2;
                  CreateColorPlaneWindow(command.DestinationImage.Clone(), "C Plane");

                  command.DestinationImage.Page = 3;
                  CreateColorPlaneWindow(command.DestinationImage.Clone(), "T Plane");
                  break;
            }
         }
         catch (Exception ex)
         {
            Messager.ShowError(this, ex);
         }
      }

      public void CreateColorPlaneWindow(RasterImage image, string title)
      {
         ViewerForm child = new ViewerForm(_parent);
         child.MdiParent = _parent;
         child.WindowState = FormWindowState.Normal;
         child.Initialize();
         child.load(image, title);
         child.Show();
      }

      public void Merge()
      {
         List<ViewerImages> images = new List<ViewerImages>();

         for (int i = 0; i < this.MdiParent.MdiChildren.Length; i++)
         {
            //images.Add(new ViewerImages(Path.GetFileNameWithoutExtension(this.MdiParent.MdiChildren[i].Text),
            images.Add(new ViewerImages(this.MdiParent.MdiChildren[i].Text,
               ((ViewerForm)this.MdiParent.MdiChildren[i]).Id, ((ViewerForm)this.MdiParent.MdiChildren[i]).Image));
         }

         MergeDialog dlg = new MergeDialog(images);
         if (dlg.ShowDialog() == DialogResult.OK)
         {
            ColorMergeCommand command = new ColorMergeCommand();
            command.Type = dlg.MergeType;
            command.Run(dlg.MergeImage);
            CreateColorPlaneWindow(command.DestinationImage, "Merge Image");

            addToImageList();
         }
      }

      public void Undo()
      {
         if (_viewer.Floater != null)
         {
            _floaterImageIndex--;
            _viewer.Floater.Dispose();
            _viewer.Floater = new RasterImage(floaterImageslist[_floaterImageIndex]);
            return;
         }

         _imageIndex--;
         _viewer.Image.Dispose();
         _viewer.Image = new RasterImage(imageslist[_imageIndex]);

         _viewer.Image.Page = _currentPageIndex;
      }

      public void Redo()
      {
         if (_viewer.Floater != null)
         {
            _floaterImageIndex++;
            _viewer.Floater.Dispose();
            _viewer.Floater = new RasterImage(floaterImageslist[_floaterImageIndex]);
            return;
         }

         _imageIndex++;
         _viewer.Image.Dispose();
         _viewer.Image = new RasterImage(imageslist[_imageIndex]);

         _viewer.Image.Page = _currentPageIndex;
      }

      public void addToImageList()
      {
         if (_viewer.Floater != null)
         {
            for (int i = _floaterImageIndex + 1; floaterImageslist.Count > _floaterImageIndex + 1; )
               floaterImageslist.RemoveAt(i);

            floaterImageslist.Add(new RasterImage(_viewer.Floater));
            _floaterImageIndex++;
            return;
         }

         for (int i = _imageIndex + 1; imageslist.Count > _imageIndex + 1; )
            imageslist.RemoveAt(i);

         imageslist.Add(new RasterImage(_viewer.Image));
         _imageIndex++;

         _currentPageIndex = _viewer.Image.Page;
      }

      public void CLAHE()
      {
         CLAHEDialog dlg = new CLAHEDialog();
         if (dlg.ShowDialog() == DialogResult.OK)
         {
            CLAHECommand cmd = new CLAHECommand();
            cmd.Flags = dlg.Flags;
            cmd.AlphaFactor = dlg.AlphaFactor;
            cmd.BinNumber = dlg.BinNumber;
            cmd.TilesNumber = dlg.TilesNumber;
            cmd.TileHistClipLimit = dlg.TileHistClipLimit;

            if (_viewer.Floater == null)
               cmd.Run(_viewer.Image);
            else
               cmd.Run(_viewer.Floater);

            addToImageList();
         }
      }

      private void ViewerForm_FormClosing(object sender, FormClosingEventArgs e)
      {
         if (lineHistgramDlg != null)
            lineHistgramDlg.Close();
      }

      RasterColor getPixelColor(int x, int y)
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
                  originalValue = Data[1] * 256 + Data[0];
               else
                  originalValueT = originalValue = Data[1] * 256 + Data[0];
               break;
            case 8:
               originalValueT = originalValue = Data[0];
               break;
         }

         return _currentPalette[originalValue];
      }

      public void Watershed(MainForm mainPt)
      {
         WatershedDialog dlg = new WatershedDialog(mainPt, this);
         dlg.TopMost = true;
         dlg.Show();
      }

      public void Auto3DDeskew()
      {
         PerspectiveDeskewCommand command = new PerspectiveDeskewCommand();
         command.Run(_viewer.Image);
         addToImageList();
      }

      private void ViewerForm_SizeChanged(object sender, EventArgs e)
      {
			if(_viewer != null)
         _viewer.Invalidate();
      }		  

      public void Grayscale(int BitsPerPixel)
      {
         GrayscaleCommand command = new GrayscaleCommand(BitsPerPixel);
         command.Run(_viewer.Image);
         addToImageList();
      }

      public void ColorResolution(int BitsPerPixel, RasterByteOrder Order, RasterDitheringMethod DitheringMethod, ColorResolutionCommandPaletteFlags PaletteFlags)
      {
         ColorResolutionCommand command = new ColorResolutionCommand(ColorResolutionCommandMode.InPlace, BitsPerPixel, Order, DitheringMethod, PaletteFlags, null);
         command.Run(_viewer.Image);
         addToImageList();
      }

   }
}

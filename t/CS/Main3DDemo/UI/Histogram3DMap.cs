// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.IO;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Resources;
using Leadtools;
using Leadtools.Medical3D;
using Leadtools.MedicalViewer;
using Leadtools.ImageProcessing.Effects;
using Leadtools.ImageProcessing.Color;


using Leadtools.Codecs;

namespace Main3DDemo
{
   public partial class Histogram3DDialog : Form
   {
#if (LEADTOOLS_V18_OR_LATER)
      private Medical3DHistogram _obj3DHist = null;
      private int _currentSelectedIndex;
#endif

      int[] lookupTable;

      ColorMapItem channelHistogram = null;

      List<ColorMapItem> _histogramList = null;

      private int _customIndex;


      private Medical3DControl _cell;
      private CellData _cellData;
      private MainForm _mainForm;
      private int _lookUpScale = 8192;
      private int _from = 0;
      private int _to = -1;
      private Cursor _zoomInCursor;
      private Cursor _zoomOutCursor;
      private bool _mouseDown;
      private HistogramPoint _currentPoint;
      private bool _edgePoint;
      private HistogramPoint _beforePoint;
      private HistogramPoint _afterPoint;

      private int _moveDiffX;
      private int _moveDiffY;


      private bool _onCurve;
      private bool _custom;
      //private int _currentSelectedPage = 0;
      private Medical3DObject _object;

      void SortHistogram()
      {
         ColorMapItem currentHistogram = _histogramList[_cmbPalette.SelectedIndex];

         List<HistogramPoint> points = currentHistogram.Points;

         points.Sort(delegate(HistogramPoint p1, HistogramPoint p2)
         {
            if (p1.X < p2.X)
            {
               return -1;
            }
            else if (p1.X > p2.X)
            {
               return 1;
            }
            else
               return 0;
         }
         );
      }


      private void MapTo1024(int[] dstLookupTable, int[] originalLookupTable)
      {
         int index = 0;

         for (; index < 1024; index++)
         {
            int mappedIndex = index * _lookUpScale / 1024;

            dstLookupTable[index] = originalLookupTable[mappedIndex];
         }

      }

      void UpdateRGBMap(ColorMapItem currentHistogram, List<HistogramPoint> points)
      {
         HistogramPoint[] userPoints = new HistogramPoint[2 + points.Count];
         userPoints[0] = new HistogramPoint(0, 0, Color.Black);

         int userPointsCount = points.Count;
         for (int index = 0; index < userPointsCount; index++)
         {
            userPoints[index + 1] = new HistogramPoint(Math.Min(_lookUpScale - 1, Math.Max(1, points[index].X)), points[index].Y, points[index].PointColor);
         }

         userPoints[userPoints.Length - 1] = new HistogramPoint(_lookUpScale, 0xffff, Color.White);

         int count = userPoints.Length - 1;
         int R1, R2, G1, G2, B1, B2;
         int from, to;

         int[] R = currentHistogram.RedChannel;
         int[] G = currentHistogram.GreenChannel;
         int[] B = currentHistogram.BlueChannel;

         for (int index = 0; index < count; index++)
         {
            R1 = userPoints[index].PointColor.R;
            G1 = userPoints[index].PointColor.G;
            B1 = userPoints[index].PointColor.B;
            from = userPoints[index].X;

            R2 = userPoints[index + 1].PointColor.R;
            G2 = userPoints[index + 1].PointColor.G;
            B2 = userPoints[index + 1].PointColor.B;
            to = userPoints[index + 1].X;


            int total = (to - from);
            long ratioFirst = (to - from);
            long ratioSecond = 0;
            for (int counter = from; counter < to; counter++)
            {
               R[counter] = (int)(((R1 * ratioFirst) + (R2 * ratioSecond)) * 255 / total);
               G[counter] = (int)(((G1 * ratioFirst) + (G2 * ratioSecond)) * 255 / total);
               B[counter] = (int)(((B1 * ratioFirst) + (B2 * ratioSecond)) * 255 / total);

               ratioFirst--;
               ratioSecond++;
            }
         }
      }

      void UpdateChannel()
      {
         ColorMapItem currentHistogram = _histogramList[_currentSelectedIndex];

         List<HistogramPoint> points = currentHistogram.Points;

         if ((points == null) || (points.Count == 0))
         {
            currentHistogram.Points = GetDefaultPersetPoint(currentHistogram.PaletteType, _lookUpScale);
            points = currentHistogram.Points;
         }

         int userPointsCount = points.Count;
         lookupTable = channelHistogram.LookupTable;
          
         LeadPoint[] userPoints = new LeadPoint[points.Count];
         userPoints[0] = new LeadPoint(0, 0);

         for (int index = 0; index < userPointsCount; index++)
         {
            userPoints[index] = new LeadPoint(Math.Min(_lookUpScale - 1, Math.Max(0, points[index].X)), points[index].Y);
         }

         //userPoints[userPoints.Length - 1] = new LeadPoint(_lookUpScale, 0xffff);

         Leadtools.ImageProcessing.Effects.EffectsUtilities.GetUserLookupTable(channelHistogram.LookupTable, userPoints);

         UpdateRGBMap(channelHistogram, points);


         //MapTo1024(channelHistogram[currentSelectedPage].LookupTable, lookupTable);

      }


      void UpdateHistogram()
      {
          UpdateChannel();

#if (LEADTOOLS_V19_OR_LATER)
          Medical3DColorMapping Colorsvalue = new Medical3DColorMapping();


          int[] r = new int[_lookUpScale];
          int[] g = new int[_lookUpScale];
          int[] b = new int[_lookUpScale];
          int[] o = new int[_lookUpScale];

          int index = 0;

          for (index = 0; index < _lookUpScale; index++)
          {
              r[index] = channelHistogram.RedChannel[index];
          }


          for (index = 0; index < _lookUpScale; index++)
          {
              g[index] = channelHistogram.BlueChannel[index];
          }

          for (index = 0; index < _lookUpScale; index++)
          {
              b[index] = channelHistogram.GreenChannel[index];
          }

          for (index = 0; index < _lookUpScale; index++)
          {
              o[index] = channelHistogram.LookupTable[index];
          }


          Colorsvalue.RedChannel = r;
          Colorsvalue.GreenChannel = g;
          Colorsvalue.BlueChannel = b;
          Colorsvalue.OpacChannel = o;
          _object.ColorMap = Colorsvalue;

          _cellData.ColorMap = Colorsvalue;


          RefreshUI();
          _histogramMap.Update();
          _graident.Update();
#endif // LEADTOOLS_V18_OR_LATER
      }


      int FindMaximumHistogramValue()
      {
         if (_obj3DHist == null) return 0;

         int max = -1;
#if (LEADTOOLS_V18_OR_LATER)
         for (int index = 100; index < _obj3DHist.BinsNumber; index++)
         {
            if (max < _obj3DHist.HistogramData[index])
               max = (int)_obj3DHist.HistogramData[index];
         }

#endif //(LEADTOOLS_V18_OR_LATER)
         return max;

      }

      private void initComboBox()
      {
         Array Values = Enum.GetValues(typeof(MedicalViewerPaletteType));
         foreach (object value in Values)
            _cmbPalette.Items.Add(value.ToString());

         _cmbPalette.Items.Add("Custom");
         _customIndex = _cmbPalette.Items.Count - 1;
      }

      private void initHistogramList()
      {
         _histogramList = new List<ColorMapItem>();

         for (int i = 0; i < _cmbPalette.Items.Count; i++)
         {
            _histogramList.Add(new ColorMapItem() );
         }

         if (_cellData.ColorMapList != null)
         {
            for (int i = _cmbPalette.Items.Count; i < _cellData.ColorMapList.Count; i++)
            {
               _histogramList.Add(new ColorMapItem());
            }
         }
      }

      private void initializeData()
      {
         if (_cellData.ColorMapIndex == -1)
            return;

         ColorMapItem currentHistogram;
         ColorMapItem colorMapHistogram;
         int length = _cellData.ColorMapList.Count;
         for (int i = 0; i < _cellData.ColorMapList.Count; i++)
         {
            currentHistogram = _histogramList[i];
            colorMapHistogram = _cellData.ColorMapList[i];

            for (int index = 0; index < 4; index++)
            {
               currentHistogram.Points = colorMapHistogram.Points;
            }

            if (i >= _cmbPalette.Items.Count)
            {
               _cmbPalette.Items.Add(colorMapHistogram.Name);
               currentHistogram.PaletteType = colorMapHistogram.PaletteType;
            }
         }

      }

      private void updateData()
      {
         if (_obj3DHist == null) return;

         channelHistogram = new ColorMapItem();

         Pen[] pens = { Pens.Red, Pens.Green, Pens.Blue, Pens.Gray };

         channelHistogram.HistogramMaxValue = FindMaximumHistogramValue();

         channelHistogram.HistogramMin = _obj3DHist.Minimumval;
         channelHistogram.HistogramMax = _obj3DHist.Minimumval + _obj3DHist.BinsNumber;
         channelHistogram.RedChannel   = new int[0x10000];
         channelHistogram.GreenChannel = new int[0x10000];
         channelHistogram.BlueChannel  = new int[0x10000];
         channelHistogram.LookupTable  = new int[0x10000];
         UpdateChannel();

         _minValue.Text = "0";
         _maxValue.Text = (0x10000).ToString();// channelHistogram.HistogramMaxValue.ToString();

         _minHistogram.Text = channelHistogram.HistogramMin.ToString();
         _maxHistogram.Text = channelHistogram.HistogramMax.ToString();
      }

      private void InitClass()
      {
#if (LEADTOOLS_V19_OR_LATER)
         _obj3DHist = _object.Histogram;
         if (_obj3DHist == null) return;

         _lookUpScale = _obj3DHist.BinsNumber;

         _from = 0;
         _to = _lookUpScale;
         _zoomInCursor = new Cursor(new System.IO.MemoryStream(Properties.Resources.Zoom));
         _zoomOutCursor = new Cursor(new System.IO.MemoryStream(Properties.Resources.ZoomOut));


         initComboBox();

         initHistogramList();


         initializeData();

         _currentSelectedIndex = (_cellData.ColorMapIndex == -1) ? _cmbPalette.Items.Count - 1 : _cellData.ColorMapIndex;

         updateData();

         _cmbPalette.SelectedIndex = _currentSelectedIndex;
         _radMove.Checked = true;

         UpdateButton();

#endif //(LEADTOOLS_V18_OR_LATER)

      }



      public Histogram3DDialog(Medical3DControl cell, Medical3DObject myObject, MainForm mainForm)
      {
         _object = myObject;
         _cell = cell;
         _cellData = (CellData)cell.Tag;
         _mainForm = mainForm;

         InitializeComponent();

         InitClass();

         UpdateHistogram();
      }

      private MedicalViewerMPRCell FindFirstMPRCell(MedicalViewer viewer)
      {
         foreach (Control control in viewer.Cells)
         {
            if (control is MedicalViewerMPRCell)
               return (MedicalViewerMPRCell)control;
         }

         return null;
      }

      private MedicalViewerMultiCell FindFirstMultiCell(MedicalViewer viewer)
      {
         foreach (Control control in viewer.Cells)
         {
            if (control is MedicalViewerMultiCell)
               return (MedicalViewerMultiCell)control;
         }

         return null;
      }

      private void _btnOK_Click(object sender, EventArgs e)
      {

      }

      private void _btnReset_Click(object sender, EventArgs e)
      {
         int removeCount = _histogramList.Count - (_customIndex + 1);
         _histogramList.RemoveRange(_customIndex + 1, removeCount);

         _cmbPalette.SelectedIndex = Math.Min(_cmbPalette.SelectedIndex, _customIndex);

         for (int index = 0; index < removeCount; index++)
            _cmbPalette.Items.RemoveAt(_customIndex + 1);

         ColorMapItem channelHistogram;
         int histogramIndex = 0;

         for (histogramIndex = 0; histogramIndex < _histogramList.Count; histogramIndex++)
         {
            channelHistogram = _histogramList[histogramIndex];

            if (channelHistogram.Points != null)
               channelHistogram.Points.Clear();
         }

         channelHistogram = _histogramList[_cmbPalette.SelectedIndex];

         UpdateChannel();

         UpdateButton();

         UpdateHistogram();
      }

      private void _btnApply_Click(object sender, EventArgs e)
      {
         _btnOK_Click(sender, e);
      }

      private void DrawHistogram(Graphics graphics)
      {

      }

      private Color[] GetColorPoints(int[] R, int[] G, int[] B)
      {
         int index = 0;
         int length = _graident.Width;
         int mappedIndex;
         int height = _graident.Height;

         Color[] colorPoints = new Color[length];

         for (index = 0; index < length; index++)
         {
            mappedIndex = (index * (_to - _from) / length) + _from;
            //realValue = Math.Max(3, Math.Min((height - 1) - (lookupTable[mappedIndex] * height / 0xffff), _histogramMap.Height - 3));

            colorPoints[index] = Color.FromArgb(R[mappedIndex] >> 8, G[mappedIndex] >> 8, B[mappedIndex] >> 8);
         }

         return colorPoints;
      }




      private Point[] GetLutPoints(int[] lookupTable)
      {
         int index = 0;
         int length = _histogramMap.Width;
         int mappedIndex;
         int height = _histogramMap.Height;

         int realValue;
         Point[] lutPoints = new Point[length];

         for (index = 0; index < length; index++)
         {
            mappedIndex = (index * (_to - _from) / length) + _from;
            realValue = Math.Max(3, Math.Min((height - 1) - (lookupTable[mappedIndex] * height / 0xffff), _histogramMap.Height - 3));

            lutPoints[index] = new Point(index + 1, realValue - 1);
         }

         return lutPoints;
      }

      private void _histogramMap_Paint(object sender, PaintEventArgs e)
      {
#if (LEADTOOLS_V18_OR_LATER)

         if (_obj3DHist == null) return;

         ColorMapItem currentHistogram = _histogramList[_cmbPalette.SelectedIndex];

         if (lookupTable == null)
            return;

         List<HistogramPoint> points = currentHistogram.Points;
         int histogramMaxValue =  channelHistogram.HistogramMaxValue;

         int index = 0;
         int length = _histogramMap.Width;
         int mappedIndex;
         int height = _histogramMap.Height;

         int realValue;
         Point[] lutPoints = null;// new Point[length];

         // replace the commented
         // you must first set the lookup table value.
         int[] histogram = _obj3DHist.HistogramData;
         int histogramWidth = Math.Min((_to - _from), _obj3DHist.BinsNumber);

         for (index = 0; index < _histogramMap.Width; index++)
         {
            mappedIndex = index * histogramWidth / _histogramMap.Width + _from;
            realValue = (int)(histogram[mappedIndex] * _histogramMap.Height / (histogramMaxValue));
            e.Graphics.DrawLine(channelHistogram.HistogramPen, new Point(index + 1, _histogramMap.Height), new Point(index + 1, _histogramMap.Height - realValue));
         }

         if (_cmbPalette.SelectedIndex == 0)
            return;


         lutPoints = GetLutPoints(lookupTable);



         e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

         e.Graphics.DrawLines(new Pen(Color.Black, 1), lutPoints);


         if (points != null)
         {
            for (index = 0; index < points.Count; index++)
            {
               int X = (points[index].X - _from) * _histogramMap.Width / (_to - _from);
               int Y = (0xffff - points[index].Y) * _histogramMap.Height / 0xffff;

               Rectangle rect = new Rectangle(X - 1, Y - 1, 1, 1);
               rect.Inflate(new Size(4, 4));

               e.Graphics.FillEllipse(new SolidBrush(points[index].PointColor), rect);
               e.Graphics.DrawEllipse(new Pen(Color.Black, 1), rect);
            }
         }

#endif //(LEADTOOLS_V18_OR_LATER)
      }


      private void UpdatePositionText(MouseEventArgs e)
      {
         int minimumHistogram = channelHistogram.HistogramMin;

         _txtXPos.Text = (e.X * (_to - _from) / _histogramMap.Width + (_from + minimumHistogram)).ToString();
         _txtYPos.Text = (((_histogramMap.Height - 1) - (e.Y + 1)) * 0x10000 / _histogramMap.Height).ToString();
      }

      private void _histogramMap_MouseMove(object sender, MouseEventArgs e)
      {

         UpdatePositionText(e);
         if (!_mouseDown)
            return;

         if (_radMoveHist.Checked)
         {
            int min = 0;
            int max = _obj3DHist.BinsNumber;

            _from = Math.Min(max, Math.Max(min, _oldFrom - (e.X - _oldX)));
            _to = Math.Min(max, Math.Max(min, _from + _oldWidth));
            _from = _to - _oldWidth;

            UpdateMinMaxHistogramText();


            RefreshUI();
            _histogramMap.Update();
            _graident.Update();
            return;
         }

         if ((!_onCurve) && (_currentPoint == null))
            return;


         ColorMapItem currentHistogram = _histogramList[_cmbPalette.SelectedIndex];
         List<HistogramPoint> points = currentHistogram.Points;

         int minValue = 3;
         if (_previousIndex > -1)
         {
            minValue = (points[_previousIndex].X - _from) * _histogramMap.Width / (_to - _from) + 3 - _moveDiffX;//points[_previousIndex].X + 3;
         }

         int maxValue = _histogramMap.Width - 3;
         if ((_nextIndex < points.Count) && (_nextIndex > -1))
         {
            maxValue = (points[_nextIndex].X - _from) * _histogramMap.Width / (_to - _from) - 3 - _moveDiffX;//points[_nextIndex].X - 3;
         }


         //int X = (points[index].X - _from) * _histogramMap.Width / (_to - _from);

         //           int histogramWidth = Math.Min((_to - _from), _obj3DHist.BinsNumber);
         //mappedIndex = index * histogramWidth / _histogramMap.Width + _from;




         int x = Math.Max(minValue, Math.Min(e.X, maxValue));
         int y = Math.Max(3, Math.Min(e.Y, _histogramMap.Height - 3));

         if (_onCurve)
         {
            if ((_beforePoint == null) ||
                 (_afterPoint == null))
               return;

            if (x - _minimumBefore < 3)
            {
               x -= (x - _minimumBefore - 3);
            }


            if (_beforePoint != null)
            {
               x = Math.Max(minValue + _minimumBefore, Math.Min(e.X, maxValue - _minimumBefore));
               _beforePoint.X = ((x - _minimumBefore) * (_to - _from) / _histogramMap.Width) + _from;
            }

            if (_afterPoint != null)
            {
               x = Math.Max(minValue - _minimumAfter, Math.Min(e.X, maxValue + _minimumAfter));
               _afterPoint.X = ((x - _minimumAfter) * (_to - _from) / _histogramMap.Width) + _from;
            }
         }
         else if (_currentPoint != null)
         {
            if (!_edgePoint)
               _currentPoint.X = ((x + _moveDiffX) * (_to - _from) / _histogramMap.Width) + _from;
            _currentPoint.Y = (_histogramMap.Height - (y + _moveDiffY)) * 0xffff / _histogramMap.Height;
         }

         SortHistogram();

         UpdateHistogram();
      }

      private void _histogramMap_MouseUp(object sender, MouseEventArgs e)
      {
         _mouseDown = false;
         _onCurve = false;

      }

      int _minimumBefore;
      int _minimumAfter;
      private HistogramPoint CloserPoint(int x, int pointX, HistogramPoint point, bool before)
      {
         if (before)
         {
            int distance = (x - pointX);
            if ((distance > 0) && (distance < _minimumBefore))
            {
               _minimumBefore = distance;
               return point;
            }
            return _beforePoint;

         }
         else
         {
            int distance = (x - pointX);
            if ((distance < 0) && (distance > _minimumAfter))
            {
               _minimumAfter = distance;
               return point;
            }
            return _afterPoint;
         }
      }

      private void HitTestHistogram(int x, int y)
      {
         Rectangle rect = new Rectangle();

         int left;
         int top;

         ColorMapItem currentHistogram = _histogramList[_cmbPalette.SelectedIndex];

         if (currentHistogram.Points == null)
            currentHistogram.Points = new List<HistogramPoint>();

         List<HistogramPoint> points = currentHistogram.Points;

         for (int index = 0; index < points.Count; index++)
         {
            left = (points[index].X - _from) * _histogramMap.Width / (_to - _from);
            top = (0xffff - points[index].Y) * _histogramMap.Height / 0xffff;

            rect = new Rectangle(left, top, 1, 1);
            rect.Inflate(new Size(7, 7));

            _beforePoint = CloserPoint(x, left, points[index], true);
            _afterPoint = CloserPoint(x, left, points[index], false);


            if (rect.Contains(new Point(x, y)))
            {
               _currentPoint = points[index];

               _edgePoint = ((index == 0) || (index == points.Count - 1));


               _previousIndex = index - 1;
               _nextIndex = index + 1;

               _moveDiffX = left - x;
               _moveDiffY = top - y;

               break;
            }
         }
      }

      private List<HistogramPoint> GetDefaultPersetPoint(MedicalViewerPaletteType palette, int lookupTableLength)
      {
         List<HistogramPoint> pointList = new List<HistogramPoint>();
         List<Color> colorList = new List<Color>();
         int index = 0;


         switch (palette)
         {
            case MedicalViewerPaletteType.None:
               pointList.Add(new HistogramPoint(0, 0, Color.Black));
               pointList.Add(new HistogramPoint(lookupTableLength - 1, 0x10000, Color.White));
               break;

            case MedicalViewerPaletteType.Cool:
               colorList.Add(Color.FromArgb(0, 128, 128));
               colorList.Add(Color.FromArgb(0, 0, 255));
               colorList.Add(Color.FromArgb(255, 0, 255));
               colorList.Add(Color.FromArgb(255, 128, 0));

               pointList.Add(new HistogramPoint(0, 0, Color.Black));
               for (index = 1; index < 5; index++)
               {
                  pointList.Add( new HistogramPoint(lookupTableLength * index / 5, 0x10000 * index / 5, colorList[index - 1]) );
               }
               pointList.Add(new HistogramPoint(lookupTableLength - 1, 0x10000, Color.White));
               break;

            case MedicalViewerPaletteType.CyanHot:
               colorList.Add(Color.FromArgb(0, 0, 128));
               colorList.Add(Color.FromArgb(0, 128, 255));
               colorList.Add(Color.FromArgb(128, 255, 255));

               pointList.Add(new HistogramPoint(0, 0, Color.Black));
               for (index = 1; index < 4; index++)
               {
                  pointList.Add( new HistogramPoint(lookupTableLength * index / 4, 0x10000 * index / 4, colorList[index - 1]) );
               }
               pointList.Add(new HistogramPoint(lookupTableLength - 1, 0x10000, Color.White));
               break;

            case MedicalViewerPaletteType.Fire:
               colorList.Add(Color.FromArgb(0, 0, 255));
               colorList.Add(Color.FromArgb(255, 0, 255));
               colorList.Add(Color.FromArgb(255, 0, 0));
               colorList.Add(Color.FromArgb(255, 128, 0));
               colorList.Add(Color.FromArgb(255, 255, 0));

               pointList.Add(new HistogramPoint(0, 0, Color.Black));
               for (index = 1; index < 6; index++)
               {
                  pointList.Add( new HistogramPoint(lookupTableLength * index / 6, 0x10000 * index / 6, colorList[index - 1]) );
               }
               pointList.Add(new HistogramPoint(lookupTableLength - 1, 0x10000, Color.White));
               break;

            case MedicalViewerPaletteType.ICA2:
               colorList.Add(Color.FromArgb(0, 255, 0));
               colorList.Add(Color.FromArgb(0, 255, 0));
               colorList.Add(Color.FromArgb(0, 0, 0));
               colorList.Add(Color.FromArgb(255, 128, 0));

               pointList.Add(new HistogramPoint(0, 0, Color.FromArgb(255, 255, 0)));
               pointList.Add(new HistogramPoint(lookupTableLength  / 4, 0x10000  / 4, colorList[0]) );
               pointList.Add(new HistogramPoint(lookupTableLength * 7 / 16, 0x10000 * 7 / 16, colorList[1]) );
               pointList.Add(new HistogramPoint(lookupTableLength * 9 / 16, 0x10000 * 9 / 16, colorList[2]));
               pointList.Add(new HistogramPoint(lookupTableLength * 3 / 4, 0x10000 * 3 / 4, colorList[3]));
               pointList.Add(new HistogramPoint(lookupTableLength - 1, 0x10000, Color.White));
               break;

            case MedicalViewerPaletteType.Ice:
               colorList.Add(Color.FromArgb(0, 128, 128));
               colorList.Add(Color.FromArgb(0, 255, 255));
               colorList.Add(Color.FromArgb(255, 128, 192));
               colorList.Add(Color.FromArgb(255, 0, 128));

               pointList.Add(new HistogramPoint(0, 0, Color.FromArgb(128, 128, 0)));
               for (index = 1; index < 5; index++)
               {
                  pointList.Add( new HistogramPoint(lookupTableLength * index / 5, 0x10000 * index / 5, colorList[index - 1]) );
               }
               pointList.Add(new HistogramPoint(lookupTableLength - 1, 0x10000, Color.FromArgb(255, 0, 0)));
               break;

            case MedicalViewerPaletteType.OrangeHot:
               colorList.Add(Color.FromArgb(255, 0, 0));
               colorList.Add(Color.FromArgb(255, 128, 0));
               colorList.Add(Color.FromArgb(255, 255, 0));

               pointList.Add(new HistogramPoint(0, 0, Color.Black));
               for (index = 1; index < 4; index++)
               {
                  pointList.Add( new HistogramPoint(lookupTableLength * index / 4, 0x10000 * index / 4, colorList[index - 1]) );
               }
               pointList.Add(new HistogramPoint(lookupTableLength - 1, 0x10000, Color.White));
               break;

            case MedicalViewerPaletteType.RainbowRGB:
               colorList.Add(Color.FromArgb(0, 0, 255));
               colorList.Add(Color.FromArgb(0, 255, 0));
               colorList.Add(Color.FromArgb(255, 0, 0));

               pointList.Add(new HistogramPoint(0, 0, Color.Black));

               pointList.Add( new HistogramPoint(lookupTableLength / 6, 0x10000 / 6, colorList[0]) );
               pointList.Add( new HistogramPoint(lookupTableLength / 2, 0x10000 / 2, colorList[1]) );
               pointList.Add( new HistogramPoint(lookupTableLength * 5 / 6, 0x10000  * 5 / 6, colorList[2]) );

               pointList.Add(new HistogramPoint(lookupTableLength - 1, 0x10000, Color.FromArgb(128, 128, 128)) );
               break;

            case MedicalViewerPaletteType.RedHot:
               colorList.Add(Color.FromArgb(255, 0, 0));
               colorList.Add(Color.FromArgb(255, 255, 0));

               pointList.Add(new HistogramPoint(0, 0, Color.Black));
               for (index = 1; index < 3; index++)
               {
                  pointList.Add( new HistogramPoint(lookupTableLength * index / 3, 0x10000 * index / 3, colorList[index - 1]) );
               }
               pointList.Add(new HistogramPoint(lookupTableLength - 1, 0x10000, Color.White));
               break;

            case MedicalViewerPaletteType.Spectrum:
               colorList.Add(Color.FromArgb(255, 255, 0));
               colorList.Add(Color.FromArgb(0, 255, 0));
               colorList.Add(Color.FromArgb(0, 255, 255));
               colorList.Add(Color.FromArgb(0, 0, 255));
               colorList.Add(Color.FromArgb(255, 0, 255));

               pointList.Add(new HistogramPoint(0, 0, Color.FromArgb(255, 0, 0)));
               for (index = 1; index < 6; index++)
               {
                  pointList.Add( new HistogramPoint(lookupTableLength * index / 6, 0x10000 * index / 6, colorList[index - 1]) );
               }
               pointList.Add( new HistogramPoint(lookupTableLength - 1, 0x10000, Color.FromArgb(255, 0, 0)) );
               break;
         }


         return pointList;
      }



      private int _oldFrom;
      private int _oldWidth;
      private int _oldX;
      private int _previousIndex;
      private int _nextIndex;

      private void _histogramMap_MouseDown(object sender, MouseEventArgs e)
      {
         _previousIndex = -2;
         _nextIndex = -2;

         if (_radZoom.Checked)
         {
            if ((Control.ModifierKeys & Keys.Control) != 0)
               ZoomOut(e.X, e.Y);
            else
               ZoomIn(e.X, e.Y);
            return;
         }
         else if (_radMoveHist.Checked)
         {
            _oldFrom = _from;
            _oldWidth = _to - _from;
            _oldX = e.X;
            _mouseDown = true;
            return;
         }
         else
         {
            _currentPoint = null;
            _edgePoint = false;
            HitTestHistogram(e.X, e.Y);
            if (_currentPoint != null)
            {
               if (e.Button == System.Windows.Forms.MouseButtons.Right)
               {
                  _rightClickMenu.Show((Control)sender, new Point(e.X, e.Y));
                  return;
               }
            }
         }



         if (_cmbPalette.SelectedIndex == 0)
            return;

         ColorMapItem currentHistogram = _histogramList[_cmbPalette.SelectedIndex];

         if (currentHistogram.Points == null)
            currentHistogram.Points = GetDefaultPersetPoint(currentHistogram.PaletteType, currentHistogram.HistogramMax - currentHistogram.HistogramMin);

         List<HistogramPoint> points = currentHistogram.Points;

         _mouseDown = true;

         HistogramPoint point = new HistogramPoint(0, 0);

         int x = Math.Max(3, Math.Min(e.X, _histogramMap.Width - 3));
         int y = Math.Max(3, Math.Min(e.Y, _histogramMap.Height - 3));

         point.X = x * (_to - _from) / _histogramMap.Width + _from;
         point.Y = (_histogramMap.Height - y) * 0xffff / _histogramMap.Height;


         _minimumAfter = -_histogramMap.Width;
         _minimumBefore = _histogramMap.Width;
         _beforePoint = null;
         _afterPoint = null;

         _currentPoint = null;


         HitTestHistogram(e.X, e.Y);


         if (e.Button == MouseButtons.Right)
         {
            if (_beforePoint != null)
               _previousIndex = points.IndexOf(_beforePoint) - 1;
            if (_afterPoint != null)
               _nextIndex = points.IndexOf(_afterPoint) + 1;
            if (_currentPoint != null)
            {
               points.Remove(_currentPoint);
               _currentPoint = null;
               UpdateHistogram();
            }
            else
            {
               Point[] lutPoints = GetLutPoints(lookupTable);
               int distance;
               _onCurve = false;
               for (int index = 0; index < lutPoints.Length; index++)
               {
                  distance = e.X - lutPoints[index].X;
                  if ((distance >= 3) || (distance < 3))
                  {
                     _onCurve = true;
                     break;
                  }
               }

               //if (!_onCurve)
            }
         }
         else
         {
            if (_currentPoint == null)
            {
               int color = point.Y / 255;

               point.PointColor = Color.FromArgb(color, color, color);

               points.Add(point);

               _currentPoint = point;

               SortHistogram();
               UpdateHistogram();

               int index = points.IndexOf(_currentPoint);
               _previousIndex = index - 1;
               _nextIndex = index + 1;

            }
         }
      }

      private void _cmbPalette_SelectedIndexChanged(object sender, EventArgs e)
      {
         if (_cmbPalette.SelectedIndex == 0)
            _histogramMap.Cursor = Cursors.Arrow;
         else
            _histogramMap.Cursor = Cursors.SizeAll;

         _custom = (_cmbPalette.SelectedIndex >= _customIndex);

         _currentSelectedIndex = _cmbPalette.SelectedIndex;

#if (LEADTOOLS_V18_OR_LATER)
         //if (!_custom)
         //{
            //_object.VRTColoringMode = _cmbPalette.SelectedIndex == 0 ? VRTColoringModeFlages.Gray : VRTColoringModeFlages.Predefined;

         //   if (_cmbPalette.SelectedIndex != 0)
         //      _object.Palette = MedicalViewerCell.GetPalette((MedicalViewerPaletteType)_cmbPalette.SelectedIndex);
         //   else
         //      _object.Palette = null;
         //}
         //else
         //{
         //   if (_histogramList[_cmbPalette.SelectedIndex].PaletteType != MedicalViewerPaletteType.None)
         //      _object.Palette = MedicalViewerCell.GetPalette(_histogramList[_cmbPalette.SelectedIndex].PaletteType);
         //   else
         //      _object.Palette = null;
         //}


         ColorMapItem currentHistogram = _histogramList[_currentSelectedIndex];

         if (!_custom)
            currentHistogram.PaletteType = (MedicalViewerPaletteType)_cmbPalette.SelectedIndex;

         _cellData.Palette = _object.Palette;

         UpdateChannel();

         UpdateHistogram();


         _save.Enabled = (_cmbPalette.SelectedIndex != 0) && (_cmbPalette.SelectedIndex <= _customIndex);

#endif //LEADTOOLS_V18_OR_LATER

         RefreshUI();
      }


      private void RefreshUI()
      {
         _histogramMap.Invalidate();
         _graident.Invalidate();
      }


      private void Histogram3DDialog_FormClosed(object sender, FormClosedEventArgs e)
      {
         _zoomInCursor.Dispose();
         _zoomOutCursor.Dispose();


         //if (_cellData.ColorMapList == null)
         {
            ColorMapItem currentHistogram;

            _cellData.ColorMapList = new List<ColorMapItem>();

            for (int i = 0; i < _cmbPalette.Items.Count; i++)
            {
               currentHistogram = _histogramList[i];
               _cellData.ColorMapList.Add(new ColorMapItem());

               _cellData.ColorMapList[i].Points = currentHistogram.Points;

               _cellData.ColorMapList[i].Name = _cmbPalette.Items[i].ToString();
               _cellData.ColorMapList[i].PaletteType = currentHistogram.PaletteType;
            }
         }


         /*int index = 0;
         int length = channelHistogram.Length;

         for ( index = 0; index < length; index++)
         {
             _cellData.ColorMapPoint[index] = channelHistogram[index].Points;
         }*/

         _cellData.ColorMapIndex = _cmbPalette.SelectedIndex;
      }

      private void _radZoom_CheckedChanged(object sender, EventArgs e)
      {
         UpdateHistogramCursor();
      }

      private void UpdateHistogramCursor()
      {
         if (_radZoom.Checked)
         {
            if (zoomOut)
               _histogramMap.Cursor = _zoomOutCursor;
            else
               _histogramMap.Cursor = _zoomInCursor;
         }
      }

      bool zoomOut = false;

      protected override void OnKeyDown(KeyEventArgs e)
      {
         base.OnKeyDown(e);
         zoomOut = e.Control;
         UpdateHistogramCursor();
      }

      protected override void OnKeyUp(KeyEventArgs e)
      {
         base.OnKeyUp(e);
         zoomOut = e.Control;
         UpdateHistogramCursor();
      }


      private void UpdateMinMaxHistogramText()
      {
         int minimumHistogram = channelHistogram.HistogramMin;

         _minHistogram.Text = (_from + minimumHistogram).ToString();
         _maxHistogram.Text = (_to + minimumHistogram).ToString();
      }

      private void ZoomIn(int x, int y)
      {
         if ((_to - _from) <= (_histogramMap.Width / 2))
            return;

         int currentWidth = (_to - _from);
         double ratio = (_to - _from) * 0.9 / _lookUpScale;

         int newWidth = (int)(_lookUpScale * ratio + 0.5);

         _from = _from + (int)((currentWidth - newWidth) * (x * 1.0 / _histogramMap.Width) + 0.5);
         _to = newWidth + _from;

         UpdateMinMaxHistogramText();

         RefreshUI();
         _histogramMap.Update();
         _graident.Update();
      }

      private void ZoomOut(int x, int y)
      {
         int currentWidth = (_to - _from);
         double ratio = (_to - _from) * 1.1 / _lookUpScale;

         int newWidth = (int)(_lookUpScale * ratio + 0.5);

         _from = Math.Max(0, _from + (int)((currentWidth - newWidth) * (x * 1.0 / _histogramMap.Width) + 0.5));
         _to = Math.Min(_lookUpScale, newWidth + _from);

         UpdateMinMaxHistogramText();

         RefreshUI();
         _histogramMap.Update();
         _graident.Update();
      }


      private void button1_Click(object sender, EventArgs e)
      {
         _from = 0;
         _to = _lookUpScale;


         _minHistogram.Text = channelHistogram.HistogramMin.ToString();
         _maxHistogram.Text = channelHistogram.HistogramMax.ToString();

         RefreshUI();
      }

      private void _radMove_CheckedChanged(object sender, EventArgs e)
      {
         if (_radMove.Checked)
            _histogramMap.Cursor = Cursors.SizeAll;
      }

      private void _save_Click(object sender, EventArgs e)
      {
         //if (_cmbPalette.SelectedIndex > (_customIndex))
         {
            SaveItemialog dialog = new SaveItemialog(this, _cmbPalette.Items.Count - (_customIndex + 1), _cmbPalette);
            dialog.ShowDialog();
            int selectedIndex = 0;
            if (ItemName != "")
            {
               //if (_cmbPalette.SelectedIndex <= _customIndex)
               //{
               //   selectedIndex = _cmbPalette.SelectedIndex;
               //}
               //else
               {
                  _cmbPalette.Items.Add(ItemName);
                  selectedIndex = _cmbPalette.Items.Count - 1;
                  _histogramList.Add(new ColorMapItem());
               }

               ColorMapItem currentHistogram = _histogramList[_cmbPalette.SelectedIndex];

               ColorMapItem newHistogram = _histogramList[selectedIndex];
               List<HistogramPoint> points;

               newHistogram.Points = new List<HistogramPoint>();
               points = currentHistogram.Points;
               for (int pointCount = 0; pointCount < points.Count; pointCount++)
               {
                  newHistogram.Points.Add(new HistogramPoint(points[pointCount].X, points[pointCount].Y, points[pointCount].PointColor));
               }
               points.Clear();

               newHistogram.PaletteType = (_cmbPalette.SelectedIndex < _customIndex) ? (MedicalViewerPaletteType)_cmbPalette.SelectedIndex : MedicalViewerPaletteType.None;

               _cmbPalette.SelectedIndex = selectedIndex;


            }

            UpdateButton();
         }

      }

      private void UpdateButton()
      {
         _btnExport.Enabled = (_cmbPalette.Items.Count != _customIndex + 1);
      }


      private string _itemName;


      public String ItemName
      {

         get
         {
            return _itemName;
         }

         set
         {
            _itemName = value;
         }
      }

      private void _btnExport_Click(object sender, EventArgs e)
      {
         SaveFileDialog dialog = new SaveFileDialog();
         dialog.DefaultExt = "*.hcm";
         dialog.Filter = "Histogram Color Map (*.hcm)|*.hcm";

         if (dialog.ShowDialog() == DialogResult.OK)
         {
            WriteToFile(dialog.FileName);
         }
      }

      private void _btnImport_Click(object sender, EventArgs e)
      {
         OpenFileDialog dialog = new OpenFileDialog();

         dialog.DefaultExt = "*.hcm";
         dialog.Filter = "Histogram Color Map (*.hcm)|*.hcm";

         if (dialog.ShowDialog() == DialogResult.OK)
         {
            ReadFromFile(dialog.FileName);
         }

         UpdateButton();
      }


      private void WriteToFile(string fileName)
      {
         StreamWriter file = File.CreateText(fileName);

         int length = _cmbPalette.Items.Count;
         int pointCount;
         StringBuilder stringBuilder;

         for (int index = _customIndex + 1; index < length; index++)
         {
            ColorMapItem histogram = _histogramList[index];

            file.WriteLine(_cmbPalette.Items[index].ToString());

            file.WriteLine(histogram.PaletteType.ToString());

            stringBuilder = new StringBuilder();
            pointCount = histogram.Points.Count;
            for (int pointIndex = 0; pointIndex < pointCount; pointIndex++)
            {
               stringBuilder.Append(String.Format("{0},{1},{2},{3},{4}", histogram.Points[pointIndex].X, histogram.Points[pointIndex].Y, histogram.Points[pointIndex].PointColor.R, histogram.Points[pointIndex].PointColor.G, histogram.Points[pointIndex].PointColor.B));

               if (pointIndex != pointCount - 1)
                  stringBuilder.Append(",");
            }

            file.WriteLine(stringBuilder);
         }

         file.Close();
      }

      private MedicalViewerPaletteType GetPaletteType(string value)
      {
         MedicalViewerPaletteType output = MedicalViewerPaletteType.None;
         switch (value)
         {
            case "None":
               output = MedicalViewerPaletteType.None;
               break;
            case "Cool":
               output = MedicalViewerPaletteType.Cool;
               break;
            case "CyanHot":
               output = MedicalViewerPaletteType.CyanHot;
               break;
            case "Fire":
               output = MedicalViewerPaletteType.Fire;
               break;
            case "ICA2":
               output = MedicalViewerPaletteType.ICA2;
               break;
            case "Ice":
               output = MedicalViewerPaletteType.Ice;
               break;
            case "OrangeHot":
               output = MedicalViewerPaletteType.OrangeHot;
               break;
            case "RainbowRGB":
               output = MedicalViewerPaletteType.RainbowRGB;
               break;
            case "RedHot":
               output = MedicalViewerPaletteType.RedHot;
               break;
            case "Spectrum":
               output = MedicalViewerPaletteType.Spectrum;
               break;
         }

         return output;
      }

      private void ReadFromFile(string fileName)
      {
         StreamReader file = File.OpenText(fileName);

         int length = _cmbPalette.Items.Count;
         string line;
         string[] values;
         MedicalViewerPaletteType paletteType;


         _btnReset_Click(this, EventArgs.Empty);

         while (!file.EndOfStream)
         {
            _cmbPalette.Items.Add(file.ReadLine());

            ColorMapItem histogram = new ColorMapItem();
            _histogramList.Add(histogram);

            paletteType = GetPaletteType(file.ReadLine());
            histogram.PaletteType = paletteType;

            //for (int channelIndex = 0; channelIndex < 4; channelIndex++)
            {
               line = file.ReadLine();
               values = line.Split(',');

               if (values.Length < 2)
                  continue;

               histogram.Points = new List<HistogramPoint>();
               Color color;
               for (int stringValues = 0; stringValues < values.Length; stringValues += 5)
               {
                  color = Color.FromArgb(Convert.ToInt32(values[stringValues + 2]), Convert.ToInt32(values[stringValues + 3]), Convert.ToInt32(values[stringValues + 4]) );

                  histogram.Points.Add(new HistogramPoint(Convert.ToInt32(values[stringValues]), Convert.ToInt32(values[stringValues + 1]), color));
               }
            }
         }

         String str = file.ReadLine();
         file.Close();

      }

      private void radioButton1_CheckedChanged(object sender, EventArgs e)
      {
         if (_radMoveHist.Checked)
            _histogramMap.Cursor = Cursors.SizeWE;
      }

      private void Histogram3DDialog_MouseMove(object sender, MouseEventArgs e)
      {
         _txtXPos.Text = "";
         _txtYPos.Text = "";
      }

      private void panel1_MouseMove(object sender, MouseEventArgs e)
      {
         _txtXPos.Text = "";
         _txtYPos.Text = "";
      }

      private void _menuDeletePoint_Click(object sender, EventArgs e)
      {
         if (_currentPoint != null)
         {
            ColorMapItem currentHistogram = _histogramList[_cmbPalette.SelectedIndex];

            if (currentHistogram.Points == null)
               currentHistogram.Points = new List<HistogramPoint>();

            List<HistogramPoint> points = currentHistogram.Points;

            points.Remove(_currentPoint);
            _currentPoint = null;
            UpdateHistogram();
         }
      }

      private void _menuChangeColor_Click(object sender, EventArgs e)
      {
         if (_currentPoint == null)
            return;

         ColorDialog color = new ColorDialog();

         color.Color = _currentPoint.PointColor;
         DialogResult result = color.ShowDialog();

         if ((result == DialogResult.OK) && (_currentPoint != null))
         {
            _currentPoint.PointColor = color.Color;
            RefreshUI();
            UpdateHistogram();
         }
      }
      private void _graident_Paint(object sender, PaintEventArgs e)
      {
         Graphics graphics = e.Graphics;
         int index = 0;
         int colorComponent;

         ColorMapItem currentHistogram = _histogramList[_currentSelectedIndex];

         if (channelHistogram.RedChannel == null)
            return;
         if (channelHistogram.GreenChannel == null)
            return;
         if (channelHistogram.BlueChannel == null)
            return;


         int[] graidentLUT = new int[0x10000];

         Color[] color = GetColorPoints(channelHistogram.RedChannel, channelHistogram.GreenChannel, channelHistogram.BlueChannel);

         for (index = 0; index < _graident.Width; index++)
         {
            colorComponent = index * 255 / (_graident.Width - 1);
            graphics.DrawLine(new Pen(color[index]), index, 0, index, _graident.Height - 1);
         }

      }

   }

   public class HistogramPoint
   {
      public HistogramPoint(int x, int y) { X = x; Y = y; PointColor = Color.White; }
      public HistogramPoint(int x, int y, Color defaultColor) { X = x; Y = y; PointColor = defaultColor; }
      public int X;
      public int Y;
      public Color PointColor;
   }


   public class ColorMapItem
   {
      public string Name;
      public MedicalViewerPaletteType PaletteType;
      public int HistogramMaxValue = 0;
      public int HistogramMin = 0;
      public int HistogramMax = 0;
      public int[] LookupTable;
      public List<HistogramPoint> Points = null;
      public HistogramPoint FirstPoint;
      public HistogramPoint SecondPoint;
      public int[] RedChannel;
      public int[] GreenChannel;
      public int[] BlueChannel;
      public Pen HistogramPen = null;

      public ColorMapItem()
      {
         HistogramPen = new Pen(Color.FromArgb(128, 128, 128));
      }

   }

}

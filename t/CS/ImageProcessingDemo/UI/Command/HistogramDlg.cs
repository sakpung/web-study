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

using Leadtools.ImageProcessing.Effects;
using Leadtools;
using Leadtools.ImageProcessing;
using Leadtools.ImageProcessing.Color;
using Leadtools.ImageProcessing.Core;
using Leadtools.Demos;

namespace ImageProcessingDemo
{
   public partial class HistogramDlg : Form
   {
      private long[] _histValues = null;
      private int _rangesCount, _imageMinValue, _imageMaxValue, _median, _level, _clipping, _oldClip;
      private long _pixels;
      private long[] _value;
      private Graphics _graph;
      private double _mean;
      private bool _isFirstLoad;
      private RasterImage _image;
      private bool _isGrayScale;
      private Color _penColor;

      public HistogramDlg(RasterImage image, bool isGray)
      {
         InitializeComponent(); ;
         _value = new long[500];
         _graph = _pnlHistogram.CreateGraphics();
         _isGrayScale = isGray;

         if (_isGrayScale)
         {
            MinMaxValuesCommand cmd = new MinMaxValuesCommand();
            cmd.Run(image);
            _imageMinValue = cmd.MinimumValue;
            _imageMaxValue = cmd.MaximumValue;
         }
         _image = image;

      }

      protected override void OnPaint(PaintEventArgs e)
      {
         base.OnPaint(e);
         _pnlHistogram.Refresh();
         DrawHistogram();
         _isFirstLoad = false;
      }

      private void panel1_MouseMove(object sender, MouseEventArgs e)
      {
         try
         {
            int shift = (int)_numRangeMin.Value;
            _level = _rangesCount * e.X + shift;
            _lblLevel.Text = DemosGlobalization.GetResxString(GetType(), "Resx_Level") + " = " + _level;
            _lblCount.Text = DemosGlobalization.GetResxString(GetType(), "Resx_Count") + " = " + _value[e.X];
            _lblPercentil.Text = DemosGlobalization.GetResxString(GetType(), "Resx_Percentil") + " = " + Math.Round(getPercent() * 100, 2) + "%";
         }
         catch (Exception /*ex*/)
         {
         }
      }

      private void numericUpDown1_ValueChanged(object sender, EventArgs e)
      {
         DrawHistogram();
      }

      void DrawHistogram()
      {
         try
         {
            int max = int.Parse(_numRangeMax.Text);
            int min = int.Parse(_numRangeMin.Text) - _imageMinValue;

            checkValues();
            _rangesCount = (int)Math.Ceiling((max - int.Parse(_numRangeMin.Text)) / 500.0);

            if (_rangesCount == 0)
               _rangesCount++;

            using (Bitmap tempBmp = new Bitmap(_pnlHistogram.Width, _pnlHistogram.Height))
            {
               using (Graphics tempG = Graphics.FromImage(tempBmp))
               {
                  double scale = Math.Ceiling(arrayMax(_value) / 150.0);
                  if (scale == 0) scale++;

                  for (int i = 0; i < 500; i++)
                     tempG.DrawLine(new Pen(_pnlHistogram.BackColor), i, _pnlHistogram.Height, i, _pnlHistogram.Height - (int)(_value[i] / scale * (_oldClip + 1)));
                  _oldClip = _clipping;

                  for (int i = 0; i < 500; i++)
                     _value[i] = 0;

                  for (int i = 0; i < 500; i++)
                  {
                     for (int j = 0; j < _rangesCount; j++)
                        _value[i] += (((_rangesCount * i + j) + min) < _histValues.Length)
                            ? _histValues[(_rangesCount * i + j) + min] : 0;
                  }

                  scale = Math.Ceiling(arrayMax(_value) / 150.0);
                  if (scale == 0) scale++;

                  for (int i = 0; i < 500; i++)
                     tempG.DrawLine(new Pen(_penColor), i, _pnlHistogram.Height, i, _pnlHistogram.Height - (int)(_value[i] / scale * (_clipping + 1)));

                  Rectangle srcRect = new Rectangle(0, 0, tempBmp.Width, tempBmp.Height);
                  _graph.DrawImage(tempBmp, 0, 0, srcRect, GraphicsUnit.Pixel);
               }
            }
         }
         catch (Exception ex)
         {
            MessageBox.Show(ex.Message);
         }
      }

      long arrayMax(long[] arr)
      {
         long max = arr[0];
         for (int i = 1; i < arr.Length; i++)
            if (arr[i] > max)
               max = arr[i];

         return max;
      }

      private void _btnCancel_Click(object sender, EventArgs e)
      {
         this.Close();
      }

      private void _btnDraw_Click(object sender, EventArgs e)
      {
         DrawHistogram();
      }

      private void checkValues()
      {
         if (!_isFirstLoad)
         {
            if (int.Parse(_numRangeMax.Text) < int.Parse(_numRangeMin.Text))
               throw new Exception(" Error range : max value must be greater than min value ");

            if (int.Parse(_numRangeMax.Text) > _imageMaxValue || int.Parse(_numRangeMax.Text) < _imageMinValue)
               throw new Exception(" Error : max value must be less than or equal Max ");

            if (int.Parse(_numRangeMin.Text) > _imageMaxValue || int.Parse(_numRangeMin.Text) < _imageMinValue)
               throw new Exception(" Error : min value must be greater than or equal Min");
         }
      }

      private void _txtRange_KeyPress(object sender, KeyPressEventArgs e)
      {
         if (!(char.IsDigit(e.KeyChar) || e.KeyChar == '-'))
            e.Handled = true; ;
      }

      private double getPercent()
      {
         float sum = 0;
         int i;
         int level = _level - _imageMinValue;
         try
         {
            for (i = 0; i < level; i++)
            {
               if (i >= _histValues.Length)
                  break;
               sum += _histValues[i];
            }
            return sum / _pixels;
         }
         catch (Exception /*ex*/)
         {
            return 0;
         }
      }

      private void _numClipping_ValueChanged(object sender, EventArgs e)
      {
         _clipping = (int)_numClipping.Value;
         DrawHistogram();
      }

      private void HistogramDlg_Load(object sender, EventArgs e)
      {
         StatisticsInformationCommand command = new StatisticsInformationCommand();
         try
         {
            command.Channel = RasterColorChannel.Master;
            command.Start = 0;
            command.End = 255;
            command.Run(_image);

            if (_isGrayScale)
            {
               _numRangeMin.Maximum = _numRangeMax.Maximum = _imageMaxValue;
               _numRangeMin.Minimum = _numRangeMax.Minimum = _imageMinValue;
            }

            _penColor = Color.Black;
            _pixels = _image.Width * _image.Height;
            _mean = command.Mean;
            _numRangeMin.Text = _imageMinValue.ToString();
            _numRangeMax.Text = _imageMaxValue.ToString();
            _median = command.Median;

            _cmbChanel.SelectedIndex = 0;

            HistogramCommand commandHist = new HistogramCommand();
            commandHist.Channel = HistogramCommandFlags.Master;
            commandHist.Run(_image);
            long[] histogramValues = commandHist.Histogram;

            if (_isGrayScale)
            {
               switch (_image.BitsPerPixel)
               {
                  case 1:
                  case 8:
                     _histValues = histogramValues;
                     break;
                  case 16:
                  case 12:
                     int size = (int)Math.Ceiling(Math.Log(_imageMaxValue - _imageMinValue, 2));
                     size = (int)Math.Pow(2, size);
                     if (size == 0) size++;
                     _histValues = new long[size];

                     for (int i = _imageMinValue, j = 0; i <= _imageMaxValue; i++, j++)
                     {
                        int x = (i < 0) ? histogramValues.Length + i : i;
                        _histValues[j] = histogramValues[x];
                     }
                     break;
               }
               _cmbChanel.Enabled = false;
            }
            else
            {
               _gbGrayScaleRange.Enabled = false;
               _histValues = histogramValues;
               _lblMax.Enabled = _lblMin.Enabled = false;
            }

            _lblLevel.Text = DemosGlobalization.GetResxString(GetType(), "Resx_Level") + " = " + _level;
            _lblCount.Text = DemosGlobalization.GetResxString(GetType(), "Resx_Count") + " = " + 0;
            _lblMax.Text = DemosGlobalization.GetResxString(GetType(), "Resx_Max") + " = " + _imageMaxValue;
            _lblMin.Text = DemosGlobalization.GetResxString(GetType(), "Resx_Min") + " = " + _imageMinValue;
            _lblToltalPixels.Text = DemosGlobalization.GetResxString(GetType(), "Resx_ToltalPixels") + " = " + _pixels;
            _lblMean.Text = DemosGlobalization.GetResxString(GetType(), "Resx_Mean") + " = " + Math.Round(_mean, 2);
            _lblMedian.Text = DemosGlobalization.GetResxString(GetType(), "Resx_Median") + " = " + _median;
            _lblPercentil.Text = DemosGlobalization.GetResxString(GetType(), "Resx_Percentil") + " = " + 0 + "%";
         }
         catch (Exception ex)
         {
            MessageBox.Show(ex.Message);
         }
      }

      private void _cmbChanel_SelectedIndexChanged(object sender, EventArgs e)
      {
         HistogramCommand commandHist = new HistogramCommand();
         switch (_cmbChanel.SelectedIndex)
         {
            case 0:
               commandHist.Channel = HistogramCommandFlags.Master;
               _penColor = Color.Black;
               break;
            case 1:
               commandHist.Channel = HistogramCommandFlags.Red;
               _penColor = Color.Red;
               break;
            case 2:
               commandHist.Channel = HistogramCommandFlags.Green;
               _penColor = Color.Green;
               break;
            case 3:
               commandHist.Channel = HistogramCommandFlags.Blue;
               _penColor = Color.Blue;
               break;
         }
         commandHist.Run(_image);
         _histValues = commandHist.Histogram;
         DrawHistogram();
      }
   }
}

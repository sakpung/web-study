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
using Leadtools.ImageProcessing;
using Leadtools.ImageProcessing.Color;
using Leadtools.ImageProcessing.Effects;
using Leadtools.ImageProcessing.Core;

namespace InteractiveHist
{
   public partial class InteractiveHistogramDialog : Form
   {
      public InteractiveHistogramDialog(MainForm mainForm)
      {
         _mainForm = mainForm;

         applyImage = new RasterImage(ChildImage);

         InitializeComponent();

         InitClass();
      }

      private void InitClass()
      {
         // Create and initialize an HScrollBar and add it to the end of the Histogram Label.
         _hsRange = new HScrollBar();
         _hsRange.Dock = DockStyle.Bottom;
         _hsRange.Scroll += new ScrollEventHandler(_hsRange_Scroll);
         _lblHistogram.Controls.Add(_hsRange);

         // Set the globales selection index for the dilaog combo boxes...
         _cbChannel.SelectedIndex = 0;

         // Initialize the values of the Interactive Histogram Data Structure...
         _interactiveHistogramData = new InteractiveHistogramDialogData();

         _interactiveHistogramData.cD = new ChannelData[4];
         _interactiveHistogramData.fullView = false;
         _interactiveHistogramData.channel = RasterColorChannel.Master;

         _interactiveHistogramData.histogramLabel = new HistogramLabel();
         _interactiveHistogramData.histogramLabel.moveType = MovePoint.None;
         _interactiveHistogramData.histogramLabel.drawLength = 256;
         _interactiveHistogramData.histogramLabel.drawHistogram = new int[256];
         _interactiveHistogramData.histogramLabel.drawStartRange = 0;
         _interactiveHistogramData.histogramLabel.drawEndRange = 255;

         bool checkGray = (ChildImage.GrayscaleMode == RasterGrayscaleMode.None) && (ChildImage.GetLookupTable() == null);

         _interactiveHistogramData.histogramLabel.histogramLength = GetHistogramlength(ChildImage.BitsPerPixel, ChildImage.LowBit, ChildImage.HighBit, checkGray, ChildImage.Signed);

         SetMinMaxValues(_interactiveHistogramData.histogramLabel.histogramLength);

         _interactiveHistogramData.pushed = true;
         _interactiveHistogramData.distance = _tabOptions.Height + _grpStatisticalInformation.Height + _lblHelp.Height;
         _interactiveHistogramData.signed = ChildImage.Signed;
         _interactiveHistogramData.histogramLabel.startRange = 0;
         _interactiveHistogramData.histogramLabel.endRange = _interactiveHistogramData.histogramLabel.histogramLength - 1;
         _interactiveHistogramData.letApplyOnPallete = true;
         _interactiveHistogramData.scale = _interactiveHistogramData.histogramLabel.histogramLength / 256;

         if (_interactiveHistogramData.signed)
         {
            _interactiveHistogramData.histogramLabel.startRange -= _interactiveHistogramData.histogramLabel.histogramLength / 2;
            _interactiveHistogramData.histogramLabel.endRange -= _interactiveHistogramData.histogramLabel.histogramLength / 2;
         }

         _interactiveHistogramData.image = ChildImage.CloneAll();
         _interactiveHistogramData.originalImage = ChildImage.CloneAll();
         _interactiveHistogramData.savedImage = ChildImage.CloneAll();

         // Disable the Apply to LUT button if the image doesn't use LUT...
         if (_interactiveHistogramData.originalImage.UseLookupTable)
         {
            _interactiveHistogramData.originalLUT = ChildImage.GetLookupTable();
            EnableApplyLUT(true);
         }
         else
         {
            EnableApplyLUT(false);
         }

         // Disable the channels combo if the image is grayscale...
         _cbChannel.Enabled = (ChildImage.GrayscaleMode == RasterGrayscaleMode.None);

         // Disable the Undo button...
         _btnUndo.Enabled = false;

         _interactiveHistogramData.gradient = true;
         _interactiveHistogramData.shift = true;
         _interactiveHistogramData.shiftRight = true;
         _interactiveHistogramData.rescaleShiftAmount = 0;

         if (_interactiveHistogramData.histogramLabel.histogramLength != 256)
         {
            _hsRange.Minimum = _interactiveHistogramData.histogramLabel.startRange;
            _hsRange.Maximum = _interactiveHistogramData.histogramLabel.endRange - 256 + 9;
            _hsRange.Value = _interactiveHistogramData.histogramLabel.startRange;
         }
         else
         {
            _hsRange.Visible = false;
         }

         InitLUTArrays(_interactiveHistogramData.histogramLabel.histogramLength);

         if (ChildImage.UseLookupTable)
         {
            RasterColor[] lut = ChildImage.GetLookupTable();
            Array.Copy(lut, _interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].RGBPrevLUT, lut.Length);
         }

         // Initialize the values of the options structures...
         InitialChannelData(0, GetColorFromRasterColor(new RasterColor(96, 96, 96)), GetColorFromRasterColor(new RasterColor(160, 160, 160)), _interactiveHistogramData.histogramLabel.histogramLength);
         InitialChannelData(1, GetColorFromRasterColor(new RasterColor(128, 0, 0)), GetColorFromRasterColor(new RasterColor(255, 0, 0)), _interactiveHistogramData.histogramLabel.histogramLength);
         InitialChannelData(2, GetColorFromRasterColor(new RasterColor(0, 128, 0)), GetColorFromRasterColor(new RasterColor(0, 255, 0)), _interactiveHistogramData.histogramLabel.histogramLength);
         InitialChannelData(3, GetColorFromRasterColor(new RasterColor(0, 0, 128)), GetColorFromRasterColor(new RasterColor(0, 0, 255)), _interactiveHistogramData.histogramLabel.histogramLength);

         _interactiveHistogramData.applyInProgress = new bool[4];
         _interactiveHistogramData.applyInProgress[0] = true;
         _interactiveHistogramData.applyInProgress[1] = true;
         _interactiveHistogramData.applyInProgress[2] = true;
         _interactiveHistogramData.applyInProgress[3] = true;

         _doApply = false;
         // Segmentation options...
         // Set the range for the controls...
         int value;
         value = _interactiveHistogramData.cD[_cbChannel.SelectedIndex].segmentation.startLine.position;
         _nudSegStartPt.Minimum = _interactiveHistogramData.histogramLabel.startRange;
         _nudSegStartPt.Maximum = _interactiveHistogramData.cD[_cbChannel.SelectedIndex].segmentation.endLine.position - 1;
         _nudSegStartPt.Value = value;

         value = _interactiveHistogramData.cD[_cbChannel.SelectedIndex].segmentation.endLine.position;
         _nudSegEndPt.Minimum = _interactiveHistogramData.cD[_cbChannel.SelectedIndex].segmentation.startLine.position + 1;
         _nudSegEndPt.Maximum = _interactiveHistogramData.histogramLabel.endRange;
         _nudSegEndPt.Value = value;

         // Initial the global variables...
         _interactiveHistogramData.segmentStartColor = Leadtools.Demos.Converters.FromGdiPlusColor(Color.Black);
         _interactiveHistogramData.segmentEndColor = Leadtools.Demos.Converters.FromGdiPlusColor(Color.White);
         _rbSegGradient.Checked = true;

         // Gray Distribution.
         // Set the range for the controls...
         value = _interactiveHistogramData.cD[_cbChannel.SelectedIndex].grayDistribution.startLine.position;
         _nudGrayStartPt.Minimum = _interactiveHistogramData.histogramLabel.startRange;
         _nudGrayStartPt.Maximum = _interactiveHistogramData.cD[_cbChannel.SelectedIndex].grayDistribution.endLine.position - 1;
         _nudGrayStartPt.Value = value;

         value = _interactiveHistogramData.cD[_cbChannel.SelectedIndex].grayDistribution.endLine.position;
         _nudGrayEndPt.Minimum = _interactiveHistogramData.cD[_cbChannel.SelectedIndex].grayDistribution.startLine.position + 1;
         _nudGrayEndPt.Maximum = _interactiveHistogramData.histogramLabel.endRange;
         _nudGrayEndPt.Value = value;

         // Initial the global variables...
         _interactiveHistogramData.grayFactor = 0;
         _interactiveHistogramData.grayCenter = _interactiveHistogramData.histogramLabel.histogramLength / 2;
         _interactiveHistogramData.grayWidth = _interactiveHistogramData.histogramLabel.histogramLength - 1;
         _interactiveHistogramData.graySelectionOnly = false;
         _interactiveHistogramData.grayStartColor = Leadtools.Demos.Converters.FromGdiPlusColor(Color.Black);
         _interactiveHistogramData.grayEndColor = Leadtools.Demos.Converters.FromGdiPlusColor(Color.White);

         value = _interactiveHistogramData.grayFactor;
         _nudGrayFactor.Minimum = -1000;
         _nudGrayFactor.Maximum = 1000;
         _nudGrayFactor.Value = value;

         _txtGrayCenter.Text = _interactiveHistogramData.grayCenter.ToString();
         _txtGrayWidth.Text = _interactiveHistogramData.grayWidth.ToString();
         _cbGrayFunctionType.SelectedIndex = 2;

         // Filter (Noise).
         // Set the range for the controls...
         value = _interactiveHistogramData.cD[_cbChannel.SelectedIndex].filterNoise.startLine.position;
         _nudNoiseStartPt.Minimum = _interactiveHistogramData.histogramLabel.startRange;
         _nudNoiseStartPt.Maximum = _interactiveHistogramData.cD[_cbChannel.SelectedIndex].filterNoise.endLine.position - 1;
         _nudNoiseStartPt.Value = value;

         value = _interactiveHistogramData.cD[_cbChannel.SelectedIndex].filterNoise.endLine.position;
         _nudNoiseEndPt.Minimum = _interactiveHistogramData.cD[_cbChannel.SelectedIndex].filterNoise.startLine.position + 1;
         _nudNoiseEndPt.Maximum = _interactiveHistogramData.histogramLabel.endRange;
         _nudNoiseEndPt.Value = value;

         // Initial the global variables...
         _interactiveHistogramData.noiseReplaceType = 0;
         _cbNoiseReplaceWith.SelectedIndex = (int)_interactiveHistogramData.noiseReplaceType;
         _interactiveHistogramData.noiseReplaceColor = Leadtools.Demos.Converters.FromGdiPlusColor(Color.Black);

         // Rescaling.
         // Set the range for the controls...
         value = _interactiveHistogramData.cD[_cbChannel.SelectedIndex].rescale.startLine.position;
         _nudResStartPt.Minimum = _interactiveHistogramData.histogramLabel.startRange;
         _nudResStartPt.Maximum = _interactiveHistogramData.cD[_cbChannel.SelectedIndex].rescale.endLine.position - 1;
         _nudResStartPt.Value = value;

         value = _interactiveHistogramData.cD[_cbChannel.SelectedIndex].rescale.endLine.position;
         _nudResEndPt.Minimum = _interactiveHistogramData.cD[_cbChannel.SelectedIndex].rescale.startLine.position + 1;
         _nudResEndPt.Maximum = _interactiveHistogramData.histogramLabel.endRange;
         _nudResEndPt.Value = value;

         value = _interactiveHistogramData.cD[_cbChannel.SelectedIndex].rescale.newStartLine.position;
         _nudResNewStart.Minimum = _interactiveHistogramData.histogramLabel.startRange;
         _nudResNewStart.Maximum = _interactiveHistogramData.cD[_cbChannel.SelectedIndex].rescale.newEndLine.position - 1;
         _nudResNewStart.Value = value;

         value = _interactiveHistogramData.cD[_cbChannel.SelectedIndex].rescale.newEndLine.position;
         _nudResNewEnd.Minimum = _interactiveHistogramData.cD[_cbChannel.SelectedIndex].rescale.newStartLine.position + 1;
         _nudResNewEnd.Maximum = _interactiveHistogramData.histogramLabel.endRange;
        _nudResNewEnd.Value = value;

         _interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].rescale.prevEndHist.position = _interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].rescale.newEndLine.position;

         _nudResShiftAmount.Minimum = -2000000;
         _nudResShiftAmount.Maximum = 2000000;
         _nudResShiftAmount.Value = _interactiveHistogramData.rescaleShiftAmount;

         _lblSegStartPtOccVal.Text = (_interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].orginalHistogram[_interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].segmentation.startLine.position + ((_interactiveHistogramData.signed) ? Math.Abs(_interactiveHistogramData.histogramLabel.startRange) : 0)]).ToString();
         _lblSegEndPtOccVal.Text = (_interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].orginalHistogram[_interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].segmentation.endLine.position + ((_interactiveHistogramData.signed) ? Math.Abs(_interactiveHistogramData.histogramLabel.startRange) : 0)]).ToString();

         _lblGryStartPtOccVal.Text = (_interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].orginalHistogram[_interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].grayDistribution.startLine.position + ((_interactiveHistogramData.signed) ? Math.Abs(_interactiveHistogramData.histogramLabel.startRange) : 0)]).ToString();
         _lblGryEndPtOccVal.Text = (_interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].orginalHistogram[_interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].grayDistribution.endLine.position + ((_interactiveHistogramData.signed) ? Math.Abs(_interactiveHistogramData.histogramLabel.startRange) : 0)]).ToString();

         _lblNoiseStartPtOccVal.Text = (_interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].orginalHistogram[_interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].filterNoise.startLine.position + ((_interactiveHistogramData.signed) ? Math.Abs(_interactiveHistogramData.histogramLabel.startRange) : 0)]).ToString();
         _lblNoiseEndPtOccVal.Text = (_interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].orginalHistogram[_interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].filterNoise.endLine.position + ((_interactiveHistogramData.signed) ? Math.Abs(_interactiveHistogramData.histogramLabel.startRange) : 0)]).ToString();

         _lblResStartPtOccVal.Text = (_interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].orginalHistogram[_interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].rescale.startLine.position + ((_interactiveHistogramData.signed) ? Math.Abs(_interactiveHistogramData.histogramLabel.startRange) : 0)]).ToString();
         _lblResEndPtOccVal.Text = (_interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].orginalHistogram[_interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].rescale.endLine.position + ((_interactiveHistogramData.signed) ? Math.Abs(_interactiveHistogramData.histogramLabel.startRange) : 0)]).ToString();

         // Initial the global variables...
         _interactiveHistogramData.shift = true;
         _interactiveHistogramData.shiftRight = true;
         _interactiveHistogramData.rescaleShiftAmount = 0;
         _rbResShift.Checked = _interactiveHistogramData.shift;
         _rbResShiftRight.Checked = _interactiveHistogramData.shiftRight;

         // Apply to all channels...
         _interactiveHistogramData.histogramAvaliable = true;
         int index;
         int result;
         for (index = 1; index < 4; index++)
         {
            _interactiveHistogramData.getHistogram = true;
            _interactiveHistogramData.channel = (RasterColorChannel)index;

            result = ApplyFilter();
            DrawChanges();
         }

         ApplyInProgress(true);
         _interactiveHistogramData.predefinedPalette = new RasterColor[256];

         _interactiveHistogramData.channel = RasterColorChannel.Master;
         _interactiveHistogramData.getHistogram = true;
         result = ApplyFilter();
         DrawChanges();
         _cbSelectionType.SelectedIndex = 0;

         if (!_interactiveHistogramData.histogramAvaliable)
         {
            Messager.ShowError(this, "Error occur while initializing the hisogram. The histogram graph will not be available.");
         }

         // Initial data needed for drawing on the label...
         _interactiveHistogramData.histogramLabel.paint =
            new Rectangle(25,
                          0,
                          _lblHistogram.Width + 25 + 25,
                          _lblHistogram.Height - 25 - 10);

         _hsRange.Value = _interactiveHistogramData.histogramLabel.startRange;
         _hsRange.Enabled = false;
         _hsRange.Visible = (_interactiveHistogramData.histogramLabel.histogramLength != 256);

         _interactiveHistogramData.histogramLabel.zoomed = false;

         // Initial the controls to the enable status...
         _nudGrayFactor.Enabled = false;
         _btnNoiseReplaceColor.Enabled = false;

         // Set the colors of the color labels...
         _lblInner.BackColor = _interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].innerColor;
         _lblOuter.BackColor = _interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].outerColor;

         int color = GetRealVal(_interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].segmentation.startLine.position);
         _lblSegStartPtClr.BackColor = Color.FromArgb(color, color, color);
         color = GetRealVal(_interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].segmentation.endLine.position);
         _lblSegEndPtClr.BackColor = Color.FromArgb(color, color, color);

         color = GetRealVal(_interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].grayDistribution.startLine.position);
         _lblGrayStartPtClr.BackColor = Color.FromArgb(color, color, color);
         color = GetRealVal(_interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].grayDistribution.endLine.position);
         _lblGrayEndPtClr.BackColor = Color.FromArgb(color, color, color);

         color = GetRealVal(_interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].filterNoise.startLine.position);
         _lblNoiseStartPtClr.BackColor = Color.FromArgb(color, color, color);
         color = GetRealVal(_interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].filterNoise.endLine.position);
         _lblNoiseEndPtClr.BackColor = Color.FromArgb(color, color, color);

         color = GetRealVal(_interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].rescale.startLine.position);
         _lblResStartPtClr.BackColor = Color.FromArgb(color, color, color);
         color = GetRealVal(_interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].rescale.endLine.position);
         _lblResEndPtClr.BackColor = Color.FromArgb(color, color, color);

         _lblSegStartColor.BackColor = GetColorFromRasterColor(_interactiveHistogramData.segmentStartColor);
         _lblSegEndColor.BackColor = GetColorFromRasterColor(_interactiveHistogramData.segmentEndColor);

         _lblGrayStartColor.BackColor = GetColorFromRasterColor(_interactiveHistogramData.grayStartColor);
         _lblGrayEndColor.BackColor = GetColorFromRasterColor(_interactiveHistogramData.grayEndColor);

         _lblNoiseReplaceColor.BackColor = GetColorFromRasterColor(_interactiveHistogramData.noiseReplaceColor);

         _lblHelp.Visible = false;
         _MainProgressBar.Value = 0;

         _lblSegStartPtOccVal.Text = (_interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].orginalHistogram[GetStart() + ((_interactiveHistogramData.signed) ? Math.Abs(_interactiveHistogramData.histogramLabel.startRange) : 0)]).ToString();
         _lblSegEndPtOccVal.Text = (_interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].orginalHistogram[GetEnd() + ((_interactiveHistogramData.signed) ? Math.Abs(_interactiveHistogramData.histogramLabel.startRange) : 0)]).ToString();

         _doApply = true;
         _mainForm.Cursor = Cursors.Arrow;
      }

      private void ApplyInProgress(bool apply)
      {
         _doApply = false;
         _chkSegApplyInProgress.Checked = apply;
         _chkGrayApplyInProgress.Checked = apply;
         _chkNoiseApplyInProgress.Checked = apply;
         _chkResApplyInProgress.Checked = apply;
         _doApply = true;
      }

      private RasterImage ChildImage
      {
         get
         {
            return (_mainForm.ActiveViewerForm.Viewer.Image);
         }

         set
         {
            _mainForm.ActiveViewerForm.Viewer.Image = value;
         }
      }

      public RasterImage OriginalImage
      {
         get
         {
            return (_interactiveHistogramData.originalImage);
         }
      }

      private void ConVertToLutValue(RasterImage refImage, ref int pStart, ref int pEnd)
      {
         int nFactor;

         nFactor = refImage.HighBit - 7;
         if (refImage.Signed)
         {
            int nMiddle = (refImage.GetLookupTable()).Length / 2;
            if (pStart < 0)
               pStart += nMiddle;
            if (pEnd < 0)
               pEnd += nMiddle;
         }
         pStart >>= nFactor;
         pEnd >>= nFactor;
      }

      private void _hsRange_Scroll(object sender, ScrollEventArgs e)
      {
         int position = e.NewValue;

         _interactiveHistogramData.histogramLabel.drawStartRange = position;
         _interactiveHistogramData.histogramLabel.drawEndRange = position + 256;

         _lblHistogram.Invalidate(true);
      }

      private void SetStatisticalValue()
      {
         int start = 0;
         int end = 0;

         switch (_cbSelectionType.SelectedIndex)
         {
            case 0:
               start = _interactiveHistogramData.histogramLabel.startRange + ((_interactiveHistogramData.signed) ? Math.Abs(_interactiveHistogramData.histogramLabel.startRange) : 0);
               end = _interactiveHistogramData.histogramLabel.endRange + ((_interactiveHistogramData.signed) ? Math.Abs(_interactiveHistogramData.histogramLabel.startRange) : 0);
               break;
            case 1:
               start = GetStart() + ((_interactiveHistogramData.signed) ? Math.Abs(_interactiveHistogramData.histogramLabel.startRange) : 0);
               end = GetEnd() + ((_interactiveHistogramData.signed) ? Math.Abs(_interactiveHistogramData.histogramLabel.startRange) : 0);
               break;
            case 2:
               start = _interactiveHistogramData.histogramLabel.startRange + ((_interactiveHistogramData.signed) ? Math.Abs(_interactiveHistogramData.histogramLabel.startRange) : 0);
               end = GetStart() + ((_interactiveHistogramData.signed) ? Math.Abs(_interactiveHistogramData.histogramLabel.startRange) : 0);
               break;
            case 3:
               start = GetEnd() + ((_interactiveHistogramData.signed) ? Math.Abs(_interactiveHistogramData.histogramLabel.startRange) : 0);
               end = _interactiveHistogramData.histogramLabel.endRange + ((_interactiveHistogramData.signed) ? Math.Abs(_interactiveHistogramData.histogramLabel.startRange) : 0);
               break;
         }

         if (_interactiveHistogramData.originalImage.UseLookupTable)
            ConVertToLutValue(_interactiveHistogramData.originalImage, ref start, ref end);

         StatisticsInformationCommand cmd = new StatisticsInformationCommand();

         cmd.Channel = _interactiveHistogramData.channel;
         cmd.Start = start;
         cmd.End = end;
         cmd.Progress += new EventHandler<RasterCommandProgressEventArgs>(cmd_Progress);
         cmd.Run(_interactiveHistogramData.originalImage);

         // Set the selection statistical information...
         _lblSelCount.Text = cmd.PixelCount.ToString();
         _lblSelPercent.Text = DoubleToString(cmd.Percent, 2);
         _lblSelMean.Text = DoubleToString(cmd.Mean, 2);
         _lblSelStdDev.Text = DoubleToString(cmd.StandardDeviation, 2);
         _lblSelMedian.Text = cmd.Median.ToString();

         switch (_cbSelectionType.SelectedIndex)
         {
            case 0: _lblSelLevel.Text = string.Format("{0} to {1}", _interactiveHistogramData.histogramLabel.startRange, _interactiveHistogramData.histogramLabel.endRange); break;
            case 1: _lblSelLevel.Text = string.Format("{0} to {1}", GetStart(), GetEnd()); break;
            case 2: _lblSelLevel.Text = string.Format("{0} to {1}", 0, GetStart()); break;
            case 3: _lblSelLevel.Text = string.Format("{0} to {1}", GetEnd(), _interactiveHistogramData.histogramLabel.endRange); break;
         }

         _interactiveHistogramData.cD[_cbChannel.SelectedIndex].minHistogramValue = cmd.Minimum;
         _interactiveHistogramData.cD[_cbChannel.SelectedIndex].maxHistogramValue = cmd.Maximum;

         _MainProgressBar.Value = 0;
      }

      public string DoubleToString(double value, uint digits)
      {
         double factor = 10.0 * digits;

         return (((int)(value * factor)) / factor).ToString();
      }

      int GetRealVal(int value)
      {
         int temp;

         temp = value + ((_interactiveHistogramData.signed) ? Math.Abs(_interactiveHistogramData.histogramLabel.startRange) : 0);
         return (temp / _interactiveHistogramData.scale);
      }

      int SetRealVal(int value)
      {
         int temp;

         temp = value * _interactiveHistogramData.scale;
         return (temp - ((_interactiveHistogramData.signed) ? Math.Abs(_interactiveHistogramData.histogramLabel.startRange) : 0));
      }

      int SetRealVal_MouseMove(int value)
      {
         int temp;

         temp = value * _interactiveHistogramData.scale;

         temp -= (_interactiveHistogramData.signed) ? Math.Abs(_interactiveHistogramData.histogramLabel.startRange) : 0;

         temp = Math.Max(_interactiveHistogramData.histogramLabel.startRange, Math.Min(temp, _interactiveHistogramData.histogramLabel.endRange));
         return temp;
      }

      public int GetStart()
      {
         switch (_tabOptions.SelectedIndex)
         {
            case 0: return (_interactiveHistogramData.cD[_cbChannel.SelectedIndex].segmentation.startLine.position);
            case 1: return (_interactiveHistogramData.cD[_cbChannel.SelectedIndex].grayDistribution.startLine.position);
            case 2: return (_interactiveHistogramData.cD[_cbChannel.SelectedIndex].filterNoise.startLine.position);
            case 3: return (_interactiveHistogramData.cD[_cbChannel.SelectedIndex].rescale.startLine.position);
         }
         return 0;
      }

      public void SetStart(int startLine)
      {
         switch (_tabOptions.SelectedIndex)
         {
            case 0: _interactiveHistogramData.cD[_cbChannel.SelectedIndex].segmentation.startLine.position = startLine; break;
            case 1: _interactiveHistogramData.cD[_cbChannel.SelectedIndex].grayDistribution.startLine.position = startLine; break;
            case 2: _interactiveHistogramData.cD[_cbChannel.SelectedIndex].filterNoise.startLine.position = startLine; break;
            case 3: _interactiveHistogramData.cD[_cbChannel.SelectedIndex].rescale.startLine.position = startLine; break;
         }
      }

      public int GetEnd()
      {
         switch (_tabOptions.SelectedIndex)
         {
            case 0: return (_interactiveHistogramData.cD[_cbChannel.SelectedIndex].segmentation.endLine.position);
            case 1: return (_interactiveHistogramData.cD[_cbChannel.SelectedIndex].grayDistribution.endLine.position);
            case 2: return (_interactiveHistogramData.cD[_cbChannel.SelectedIndex].filterNoise.endLine.position);
            case 3: return (_interactiveHistogramData.cD[_cbChannel.SelectedIndex].rescale.endLine.position);
         }
         return 0;
      }

      public void SetEnd(int endLine)
      {
         switch (_tabOptions.SelectedIndex)
         {
            case 0: _interactiveHistogramData.cD[_cbChannel.SelectedIndex].segmentation.endLine.position = endLine; break;
            case 1: _interactiveHistogramData.cD[_cbChannel.SelectedIndex].grayDistribution.endLine.position = endLine; break;
            case 2: _interactiveHistogramData.cD[_cbChannel.SelectedIndex].filterNoise.endLine.position = endLine; break;
            case 3: _interactiveHistogramData.cD[_cbChannel.SelectedIndex].rescale.endLine.position = endLine; break;
         }
      }

      private void InitLUTArrays(int length)
      {
         int index;

         for (index = 0; index < 4; index++)
         {
            _interactiveHistogramData.cD[index].RGBLUTSegment = new RasterColor[length];
            _interactiveHistogramData.cD[index].RGBLUTGray = new RasterColor[length];
            _interactiveHistogramData.cD[index].RGBPrevLUT = new RasterColor[length];
            _interactiveHistogramData.cD[index].LUTSegment = new int[length];
            _interactiveHistogramData.cD[index].LUTGray = new int[length];
            _interactiveHistogramData.cD[index].LUTFilter = new int[length];
            _interactiveHistogramData.cD[index].LUTRescale = new int[length];
         }
      }

      private void Command_Progress(object sender, Leadtools.ImageProcessing.RasterCommandProgressEventArgs e)
      {
         if (e.Percent == 50)
            e.Cancel = true;
      }

      private void SetMinMaxValues(int length)
      {
         switch (ChildImage.BitsPerPixel)
         {
            case 12:
            case 16:
            case 48:
            case 64:
               MinMaxValuesCommand minMaxCommand = new MinMaxValuesCommand();

               try
               {
                  minMaxCommand.Run(ChildImage);
                  _interactiveHistogramData.minimumValue = minMaxCommand.MinimumValue;
                  _interactiveHistogramData.maximumValue = minMaxCommand.MaximumValue;
               }
               catch (Exception ex)
               {
                  ex.Message.ToString();
                  _interactiveHistogramData.minimumValue = 0;
                  _interactiveHistogramData.maximumValue = length - 1;
               }
               break;

            default:
               _interactiveHistogramData.minimumValue = 0;
               _interactiveHistogramData.maximumValue = length - 1;
               break;
         }

         if (ChildImage.Signed)
         {
            _interactiveHistogramData.minimumValue =
               -(1 << (ChildImage.HighBit - ChildImage.LowBit + 1)) / 2;
            _interactiveHistogramData.maximumValue =
               ((1 << (ChildImage.HighBit - ChildImage.LowBit + 1)) / 2) - 1;
         }
      }

      private void InitAfterApply()
      {
         _interactiveHistogramData.histogramLabel.histogramLength = GetHistogramlength(ChildImage.BitsPerPixel, ChildImage.LowBit, ChildImage.HighBit, ChildImage.GrayscaleMode == RasterGrayscaleMode.None, ChildImage.Signed);

         _interactiveHistogramData.signed = ChildImage.Signed;
         _interactiveHistogramData.histogramLabel.startRange = 0;
         _interactiveHistogramData.histogramLabel.endRange = _interactiveHistogramData.histogramLabel.histogramLength - 1;

         if (_interactiveHistogramData.signed)
         {
            _interactiveHistogramData.histogramLabel.startRange -= _interactiveHistogramData.histogramLabel.histogramLength / 2;
            _interactiveHistogramData.histogramLabel.endRange -= _interactiveHistogramData.histogramLabel.histogramLength / 2;
         }

         // Prepare channels data...
         InitialChannelData(0, _interactiveHistogramData.cD[0].innerColor, _interactiveHistogramData.cD[0].outerColor, _interactiveHistogramData.histogramLabel.histogramLength);
         InitialChannelData(1, _interactiveHistogramData.cD[1].innerColor, _interactiveHistogramData.cD[1].outerColor, _interactiveHistogramData.histogramLabel.histogramLength);
         InitialChannelData(2, _interactiveHistogramData.cD[2].innerColor, _interactiveHistogramData.cD[2].outerColor, _interactiveHistogramData.histogramLabel.histogramLength);
         InitialChannelData(3, _interactiveHistogramData.cD[3].innerColor, _interactiveHistogramData.cD[3].outerColor, _interactiveHistogramData.histogramLabel.histogramLength);

         _cbChannel.Enabled = (ChildImage.GrayscaleMode == RasterGrayscaleMode.None);

         _doApply = false;
         // Segmentation options...
         // Set the range for the controls...
         _nudSegStartPt.Minimum = _interactiveHistogramData.histogramLabel.startRange;
         _nudSegStartPt.Maximum = _interactiveHistogramData.cD[_cbChannel.SelectedIndex].segmentation.endLine.position - 1;
         _nudSegStartPt.Value = _interactiveHistogramData.cD[_cbChannel.SelectedIndex].segmentation.startLine.position;

         _nudSegEndPt.Minimum = _interactiveHistogramData.cD[_cbChannel.SelectedIndex].segmentation.startLine.position + 1;
         _nudSegEndPt.Maximum = _interactiveHistogramData.histogramLabel.endRange;
         _nudSegEndPt.Value = _interactiveHistogramData.cD[_cbChannel.SelectedIndex].segmentation.endLine.position;
         // Gray Distribution.
         // Set the range for the controls...
         _nudGrayStartPt.Minimum = _interactiveHistogramData.histogramLabel.startRange;
         _nudGrayStartPt.Maximum = _interactiveHistogramData.cD[_cbChannel.SelectedIndex].grayDistribution.endLine.position - 1;
         _nudGrayStartPt.Value = _interactiveHistogramData.cD[_cbChannel.SelectedIndex].grayDistribution.startLine.position;

         _nudGrayEndPt.Minimum = _interactiveHistogramData.cD[_cbChannel.SelectedIndex].grayDistribution.startLine.position + 1;
         _nudGrayEndPt.Maximum = _interactiveHistogramData.histogramLabel.endRange;
         _nudGrayEndPt.Value = _interactiveHistogramData.cD[_cbChannel.SelectedIndex].grayDistribution.endLine.position;
         // Filter (Noise).
         // Set the range for the controls...
         _nudNoiseStartPt.Minimum = _interactiveHistogramData.histogramLabel.startRange;
         _nudNoiseStartPt.Maximum = _interactiveHistogramData.cD[_cbChannel.SelectedIndex].filterNoise.endLine.position - 1;
         _nudNoiseStartPt.Value = _interactiveHistogramData.cD[_cbChannel.SelectedIndex].filterNoise.startLine.position;

         _nudNoiseEndPt.Minimum = _interactiveHistogramData.cD[_cbChannel.SelectedIndex].filterNoise.startLine.position + 1;
         _nudNoiseEndPt.Maximum = _interactiveHistogramData.histogramLabel.endRange;
         _nudNoiseEndPt.Value = _interactiveHistogramData.cD[_cbChannel.SelectedIndex].filterNoise.endLine.position;
         // Rescaling.
         // Set the range for the controls...
         _nudResStartPt.Minimum = _interactiveHistogramData.histogramLabel.startRange;
         _nudResStartPt.Maximum = _interactiveHistogramData.cD[_cbChannel.SelectedIndex].rescale.endLine.position - 1;
         _nudResStartPt.Value = _interactiveHistogramData.cD[_cbChannel.SelectedIndex].rescale.startLine.position;

         _nudResEndPt.Minimum = _interactiveHistogramData.cD[_cbChannel.SelectedIndex].rescale.startLine.position + 1;
         _nudResEndPt.Maximum = _interactiveHistogramData.histogramLabel.endRange;
         _nudResEndPt.Value = _interactiveHistogramData.cD[_cbChannel.SelectedIndex].rescale.endLine.position;

         _nudResNewStart.Minimum = _interactiveHistogramData.histogramLabel.startRange;
         _nudResNewStart.Maximum = _interactiveHistogramData.cD[_cbChannel.SelectedIndex].rescale.newEndLine.position - 1;
         _nudResNewStart.Value = _interactiveHistogramData.cD[_cbChannel.SelectedIndex].rescale.newStartLine.position;

         _nudResNewEnd.Minimum = _interactiveHistogramData.cD[_cbChannel.SelectedIndex].rescale.newStartLine.position + 1;
         _nudResNewEnd.Maximum = _interactiveHistogramData.histogramLabel.endRange;
         _nudResNewEnd.Value = _interactiveHistogramData.cD[_cbChannel.SelectedIndex].rescale.newEndLine.position;

         _nudResShiftAmount.Minimum = _interactiveHistogramData.histogramLabel.startRange;
         _nudResShiftAmount.Maximum = _interactiveHistogramData.histogramLabel.endRange;
         _nudResShiftAmount.Value = 0;
         _doApply = true;
      }

      private int GetHistogramlength(int nBBP, int nLowBit, int nHighBit, bool bNoGray, bool bSigned)
      {
         if (nHighBit == -1)
         {
            switch (nBBP)
            {
               case 12: nHighBit = 11; break;
               default: nHighBit = 15; break;
            }
         }

         switch (nBBP)
         {
            case 16:
               if (bNoGray && !bSigned)
                  return 256;
               else
                  return ((int)Math.Pow(2.0, (nHighBit - nLowBit + 1)));

            case 12:
               return ((int)Math.Pow(2.0, (nHighBit - nLowBit + 1)));

            case 48:
            case 64:
               return 65536;

            default:
               return 256;
         }
      }

      private RasterColorChannel GetActiveChannel(int index)
      {
         switch (index)
         {
            case 0: return RasterColorChannel.Master;
            case 1: return RasterColorChannel.Red;
            case 2: return RasterColorChannel.Green;
            case 3: return RasterColorChannel.Blue;
         }
         return RasterColorChannel.Master;
      }

      private FunctionalLookupTableFlags GetFunctionType(int index)
      {
         switch (index)
         {
            case 0: return FunctionalLookupTableFlags.Exponential;
            case 1: return FunctionalLookupTableFlags.Logarithm;
            case 2: return FunctionalLookupTableFlags.Linear;
            case 3: return FunctionalLookupTableFlags.Sigmoid;
         }
         return FunctionalLookupTableFlags.Linear;
      }

      private void InitialChannelData(int nChannel, Color InColor, Color outColor, int length)
      {
#if LEADTOOLS_V175_OR_LATER
         _interactiveHistogramData.cD[nChannel].orginalHistogram = new Int64[length];
#else
         _interactiveHistogramData.cD[nChannel].orginalHistogram = new int[length];
#endif
         _interactiveHistogramData.cD[nChannel].innerColor = InColor;
         _interactiveHistogramData.cD[nChannel].outerColor = outColor;

         // Initial the stretch structure...
         _interactiveHistogramData.cD[nChannel].segmentation = new Segmentation();
         _interactiveHistogramData.cD[nChannel].segmentation.startLine = new MovingLine(Color.Yellow);
         _interactiveHistogramData.cD[nChannel].segmentation.endLine = new MovingLine(Color.Red);
         _interactiveHistogramData.cD[nChannel].segmentation.startLine.position = (length) / 2 - (length / 8) - Math.Abs(_interactiveHistogramData.histogramLabel.startRange);
         _interactiveHistogramData.cD[nChannel].segmentation.endLine.position = (length) / 2 + (length / 8) - Math.Abs(_interactiveHistogramData.histogramLabel.startRange);

         // Initial the gray distribution structure...
         _interactiveHistogramData.cD[nChannel].grayDistribution = new GrayDistribution();
         _interactiveHistogramData.cD[nChannel].grayDistribution.startLine = new MovingLine(Color.Yellow);
         _interactiveHistogramData.cD[nChannel].grayDistribution.endLine = new MovingLine(Color.Red);
         _interactiveHistogramData.cD[nChannel].grayDistribution.startLine.position = (length) / 2 - (length / 8) - Math.Abs(_interactiveHistogramData.histogramLabel.startRange);
         _interactiveHistogramData.cD[nChannel].grayDistribution.endLine.position = (length) / 2 + (length / 8) - Math.Abs(_interactiveHistogramData.histogramLabel.startRange);

         // Initial the filter noise structure...
         _interactiveHistogramData.cD[nChannel].filterNoise = new FilterNoise();
         _interactiveHistogramData.cD[nChannel].filterNoise.startLine = new MovingLine(Color.Yellow);
         _interactiveHistogramData.cD[nChannel].filterNoise.endLine = new MovingLine(Color.Red);
         _interactiveHistogramData.cD[nChannel].filterNoise.startLine.position = (length) / 2 - (length / 8) - Math.Abs(_interactiveHistogramData.histogramLabel.startRange);
         _interactiveHistogramData.cD[nChannel].filterNoise.endLine.position = (length) / 2 + (length / 8) - Math.Abs(_interactiveHistogramData.histogramLabel.startRange);

         // Initial the rescaling structure...
         _interactiveHistogramData.cD[nChannel].rescale = new Rescaling();
         _interactiveHistogramData.cD[nChannel].rescale.startLine = new MovingLine(Color.Yellow);
         _interactiveHistogramData.cD[nChannel].rescale.endLine = new MovingLine(Color.Red);
         _interactiveHistogramData.cD[nChannel].rescale.newStartLine = new MovingLine(Color.Green);
         _interactiveHistogramData.cD[nChannel].rescale.newEndLine = new MovingLine(Color.Green);

         _interactiveHistogramData.cD[nChannel].rescale.startLine.position = (1 * length / 8) - Math.Abs(_interactiveHistogramData.histogramLabel.startRange);
         _interactiveHistogramData.cD[nChannel].rescale.endLine.position = (3 * length / 8) - Math.Abs(_interactiveHistogramData.histogramLabel.startRange);
         _interactiveHistogramData.cD[nChannel].rescale.newStartLine.position = (5 * length / 8) - Math.Abs(_interactiveHistogramData.histogramLabel.startRange);
         _interactiveHistogramData.cD[nChannel].rescale.newEndLine.position = (7 * length / 8) - Math.Abs(_interactiveHistogramData.histogramLabel.startRange);
      }

      private void PrepareCompressedHisto()
      {
         int sum;
         int index, of_8, counter;

         _interactiveHistogramData.scale = _interactiveHistogramData.histogramLabel.histogramLength / 256;

         _interactiveHistogramData.histogramLabel.drawHistogram = new int[256];

         for (index = 0, counter = 0; index < _interactiveHistogramData.histogramLabel.histogramLength; index += _interactiveHistogramData.scale)
         {
            sum = 0;
            for (of_8 = index; of_8 < index + _interactiveHistogramData.scale; of_8++)
            {
               sum += (int)_interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].orginalHistogram[of_8];
            }
            _interactiveHistogramData.histogramLabel.drawHistogram[counter] = sum;
            counter++;
         }
      }

      private void GetMaximumHistogramValue()
      {
         int index;
         int startLoop, endLoop;
         bool bExit;


         if (_interactiveHistogramData.histogramLabel.zoomed)
         {
            startLoop = _interactiveHistogramData.histogramLabel.drawStartRange;
            endLoop = _interactiveHistogramData.histogramLabel.drawEndRange;
         }
         else if (_interactiveHistogramData.histogramLabel.drawLength == 256)
         {
            startLoop = 1;
            endLoop = 256;
         }
         else
         {
            startLoop = 1;
            endLoop = _interactiveHistogramData.histogramLabel.histogramLength;
         }
         

         //Bug#8890 Fix
         if (startLoop < 0)
         {
            startLoop = _interactiveHistogramData.histogramLabel.histogramLength + startLoop;
            
            if (endLoop < 0)
               endLoop = _interactiveHistogramData.histogramLabel.histogramLength + endLoop;
         }

         if (endLoop < 0)
         {
            endLoop = _interactiveHistogramData.histogramLabel.histogramLength + endLoop;

            if (startLoop < 0)
               startLoop = _interactiveHistogramData.histogramLabel.histogramLength + startLoop;
         }
         //End of Bug#8890 Fix


         for (index = startLoop; index < (uint)endLoop; index++)
         {
            if (_interactiveHistogramData.histogramLabel.drawHistogram[index] > _interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].maxHistogramValue)
            {
               _interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].maxHistogramValue = _interactiveHistogramData.histogramLabel.drawHistogram[index];
            }

            if (_interactiveHistogramData.histogramLabel.drawHistogram[index] < _interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].minHistogramValue)
            {
               _interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].minHistogramValue = _interactiveHistogramData.histogramLabel.drawHistogram[index];
            }
         }

         bExit = false;
         for (index = 1; index < _interactiveHistogramData.histogramLabel.histogramLength && !bExit; index++)
         {
            if (_interactiveHistogramData.cD[_cbChannel.SelectedIndex].orginalHistogram[index] != 0)
            {
               _interactiveHistogramData.noiseMinIntensity = index;
               bExit = true;
            }
         }

         bExit = false;
         _interactiveHistogramData.noiseMaxIntensity = _interactiveHistogramData.histogramLabel.drawLength - 1;
         for (index = _interactiveHistogramData.histogramLabel.histogramLength - 2; index > -1 && !bExit; index--)
         {
            if (_interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].orginalHistogram[index] != 0)
            {
               _interactiveHistogramData.noiseMaxIntensity = index;
               bExit = true;
            }
         }
      }

      private void SetLabelsValues()
      {
         _interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].maxHistogramValue =
         _interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].minHistogramValue = _interactiveHistogramData.histogramLabel.drawHistogram[0];

         _interactiveHistogramData.noiseMinIntensity = _interactiveHistogramData.noiseMaxIntensity = 0;

         GetMaximumHistogramValue();
      }

      void DrawHistogram(Graphics gDraw, Pen pen, int penWidth, int divideBy, int[] pArray, int start, int nFrom, int nTo, bool bLine)
      {
         int nXViewValue;
         int nYViewValue;
         int index;
         int middle;

         if (nFrom >= nTo)
            return;

         middle = _interactiveHistogramData.histogramLabel.histogramLength / 2;

         nXViewValue = GetXPaintValueHist(start, penWidth) + penWidth;
         

         if (_interactiveHistogramData.signed && _interactiveHistogramData.fullView)
         {
            while (nFrom < nTo)
            {
               index = nFrom + middle;
               nYViewValue = (int)(((double)pArray[index] / divideBy) * _interactiveHistogramData.histogramLabel.paint.Height + (double)0.5);
               nXViewValue += penWidth;

               gDraw.DrawLine(pen, nXViewValue - (2 * penWidth), _interactiveHistogramData.histogramLabel.paint.Height,
                                   nXViewValue - (2 * penWidth), _interactiveHistogramData.histogramLabel.paint.Height - nYViewValue);
               nFrom++;
            }
         }
         else
         {
            //Bug#8890 Fix
            if (nFrom < 0)
            {
               nFrom = 512 + nFrom;

               if (nTo < 0)
                  nTo = 512 + nTo;
            }

            if (nTo < 0)
            {
               nTo = 512 + nTo;

               if (nFrom < 0)
                  nFrom = 512 + nFrom;
            }

            if (nFrom > nTo)
            {
               index = nFrom;
               nFrom = nTo;
               nTo = index;
            }
            //End of Bug#8890 Fix


            for (index = nFrom; index < (uint)nTo && bLine; index++)
            {
               nYViewValue = (int)(((double)pArray[index] / divideBy) * _interactiveHistogramData.histogramLabel.paint.Height + (double)0.5);
               nXViewValue += penWidth;

               gDraw.DrawLine(pen, nXViewValue - (2 * penWidth), _interactiveHistogramData.histogramLabel.paint.Height,
                                   nXViewValue - (2 * penWidth), _interactiveHistogramData.histogramLabel.paint.Height - nYViewValue);
            }
         }
      }

      int GetXPaintValueHist(int nXValue, int penWidth)
      {
         return ((nXValue * penWidth) + 25 - 2);
      }

      int GetXPaintValue(int nXValue, int penWidth)
      {
         return (
            ((_interactiveHistogramData.fullView) ? (nXValue * penWidth)
            : (GetRealVal(nXValue) * penWidth))
            + 25 - 2
            );
      }

      bool IsMouseOverPt(int nPointX, int nPointY, int nX, int nY)
      {
         if (nX >= nPointX - 10 &&
            nX <= nPointX + 10 &&
            nY >= nPointY &&
            nY <= nPointY + 10)
            return true;
         else
            return false;
      }

      void DrawMovingLine(Graphics gDraw, Pen linePen, Pen polyPen, int nValue, int nRectHeight, int penWidth)
      {
         Point[] ptTria = new Point[3];

         gDraw.DrawLine(linePen, GetXPaintValue(nValue, penWidth), nRectHeight + 2,
                             GetXPaintValue(nValue, penWidth), 0);


         ptTria[0].X = GetXPaintValue(nValue, penWidth);
         ptTria[0].Y = nRectHeight + 2;
         ptTria[1].X = ptTria[0].X + 5;
         ptTria[1].Y = ptTria[0].Y + 5;
         ptTria[2].X = ptTria[0].X - 5;
         ptTria[2].Y = ptTria[0].Y + 5;

         gDraw.DrawPolygon(polyPen, ptTria);
      }

      private Color GetColorFromRasterColor(RasterColor rasterColor)
      {
         Color color = Color.FromArgb(rasterColor.R, rasterColor.G, rasterColor.B);

         return color;
      }

      private void DrawMovingLine(Graphics gDraw, int value, int height, int penWidth, Pen linePen, Pen traPen)
      {
         Point[] ptTria = new Point[3];

         gDraw.DrawLine(linePen, GetXPaintValue(value, penWidth), height + 2,
                                 GetXPaintValue(value, penWidth), 0);

         ptTria[0].X = GetXPaintValue(value, penWidth);
         ptTria[0].Y = height + 2;
         ptTria[1].X = ptTria[0].X + 5;
         ptTria[1].Y = ptTria[0].Y + 5;
         ptTria[2].X = ptTria[0].X - 5;
         ptTria[2].Y = ptTria[0].Y + 5;

         gDraw.DrawPolygon(traPen, ptTria);
      }

      private void DrawAxisAndRanges(Graphics gDraw, int penWidth)
      {
         Pen axisPen, textPen, yellowPen, greenPen, redPen;

         // Create the pens to draw the selection lines...
         axisPen = new Pen(Color.FromArgb(128, 128, 128), 2); // PS_DASH
         axisPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;

         textPen = new Pen(Color.FromArgb(0, 0, 0), 1); // PS_SOLID
         textPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;

         yellowPen = new Pen(Color.FromArgb(255, 255, 0), penWidth); // PS_DASH
         yellowPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;

         greenPen = new Pen(Color.FromArgb(0, 255, 0), penWidth); // PS_DOT
         greenPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;

         redPen = new Pen(Color.FromArgb(255, 0, 0), penWidth); // PS_DASH
         redPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;

         // Draw the x-axis for the histogram graph...
         gDraw.DrawLine(axisPen, 25 - penWidth - 2, _interactiveHistogramData.histogramLabel.paint.Height + 2,
                                 25 + 256 - 4, _interactiveHistogramData.histogramLabel.paint.Height + 2);

         // Draw the intial range marks and its value...
         // Start point mark
         gDraw.DrawLine(axisPen, 25 - 2, _interactiveHistogramData.histogramLabel.paint.Height + 4,
                                 25 - 2, _interactiveHistogramData.histogramLabel.paint.Height + 7);

         // End point mark...
         gDraw.DrawLine(axisPen, 25 + 256 - 4, _interactiveHistogramData.histogramLabel.paint.Height + 4,
                                 25 + 256 - 4, _interactiveHistogramData.histogramLabel.paint.Height + 7);

         // Start point text...
         string str;
         int left, top;
         Font textFont = new Font("Arial", 7);

         left = 25;
         top = _interactiveHistogramData.histogramLabel.paint.Height + 5;

         if (_interactiveHistogramData.histogramLabel.histogramLength != 256 && _interactiveHistogramData.fullView)
            str = _hsRange.Value.ToString();
         else if (_interactiveHistogramData.histogramLabel.zoomed)
            str = (GetStart()).ToString();
         else
            str = _interactiveHistogramData.histogramLabel.startRange.ToString();

         gDraw.DrawString(str, textFont, Brushes.Black, new PointF(left, top));

         // End point text...
         // Subtract 5 from the left of the text rectangle to view text when its large...
         left = 25 + 256 - 5;
         top = _interactiveHistogramData.histogramLabel.paint.Height + 5;

         if (_interactiveHistogramData.histogramLabel.histogramLength != 256 && _interactiveHistogramData.fullView)
            str = (_hsRange.Value + 256).ToString();
         else if (_interactiveHistogramData.histogramLabel.zoomed)
            str = (GetEnd()).ToString();
         else
            str = _interactiveHistogramData.histogramLabel.endRange.ToString();

         gDraw.DrawString(str, textFont, Brushes.Black, new PointF(left, top));
         textFont.Dispose();

         if (!_interactiveHistogramData.histogramLabel.zoomed)
         {
            if (_tabOptions.SelectedIndex == 3 && !_interactiveHistogramData.shift)
            {
               // Draw the second start point line...
               DrawMovingLine(gDraw, _interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].rescale.newStartLine.position - _interactiveHistogramData.histogramLabel.drawStartRange,
                  _interactiveHistogramData.histogramLabel.paint.Height, penWidth, greenPen, textPen);

               // Draw the second end point line...
               DrawMovingLine(gDraw, _interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].rescale.newEndLine.position - _interactiveHistogramData.histogramLabel.drawStartRange,
                  _interactiveHistogramData.histogramLabel.paint.Height, penWidth, greenPen, textPen);
            }

            // Draw the start point line...
            DrawMovingLine(gDraw, GetStart() - _interactiveHistogramData.histogramLabel.drawStartRange,
               _interactiveHistogramData.histogramLabel.paint.Height, penWidth, yellowPen, textPen);

            // Draw the end point line...
            DrawMovingLine(gDraw, GetEnd() - _interactiveHistogramData.histogramLabel.drawStartRange,
               _interactiveHistogramData.histogramLabel.paint.Height, penWidth, redPen, textPen);
         }

         axisPen.Dispose();
         textPen.Dispose();
         yellowPen.Dispose();
         greenPen.Dispose();
         redPen.Dispose();
      }

      int GetGrayValue(RasterColor color)
      {
         return ((color.R * 2) + (color.G * 5) + (color.B * 1)) / 8;
      }


      private void SetColorValuesToLUT(int[] puLUT, RasterColor startColor, RasterColor endColor, int start, int end, RasterColorChannel channel)
      {
         switch (channel)
         {
            case RasterColorChannel.Master:
               puLUT[start] = SetRealVal(GetGrayValue(startColor));
               puLUT[end] = SetRealVal(GetGrayValue(endColor));
               break;
            case RasterColorChannel.Red:
               puLUT[start] = SetRealVal(startColor.R);
               puLUT[end] = SetRealVal(endColor.R);
               break;
            case RasterColorChannel.Green:
               puLUT[start] = SetRealVal(startColor.G);
               puLUT[end] = SetRealVal(endColor.G);
               break;
            case RasterColorChannel.Blue:
               puLUT[start] = SetRealVal(startColor.B);
               puLUT[end] = SetRealVal(endColor.B);
               break;
         }
      }

      private int ApplyGradMaster(int startLine, int endLine, RasterColorChannel channel)
      {
         int start;
         int end;
         int nCopySize;

         start = _interactiveHistogramData.histogramLabel.startRange;
         end = _interactiveHistogramData.histogramLabel.endRange;

         _interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].LUTSegment[start] = start;
         _interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].LUTSegment[end] = end;

         EffectsUtilities.GetFunctionalLookupTable(_interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].LUTSegment,
                                           start,
                                           end,
                                           0,
                                           FunctionalLookupTableFlags.Linear);

         start = startLine;
         end = endLine;

         SetColorValuesToLUT(_interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].LUTSegment,
                             _interactiveHistogramData.segmentStartColor, _interactiveHistogramData.segmentEndColor,
                             start, end, channel);

         nCopySize = end - start;
         if (nCopySize != 0)
         {
            EffectsUtilities.GetFunctionalLookupTable(_interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].LUTSegment,
                                              start,
                                              end,
                                              0,
                                              FunctionalLookupTableFlags.Linear);
         }
         return 1;
      }

      int ApplyThreMaster(int startLine, int endLine, RasterColorChannel channel)
      {
         int start;
         int end;
         int nCopySize;

         start = _interactiveHistogramData.histogramLabel.startRange;
         end = _interactiveHistogramData.histogramLabel.endRange;

         SetColorValuesToLUT(_interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].LUTSegment,
                             _interactiveHistogramData.segmentEndColor, _interactiveHistogramData.segmentEndColor,
                             start, end, channel);
         nCopySize = end - start;
         if (nCopySize != 0)
         {
            EffectsUtilities.GetFunctionalLookupTable(_interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].LUTSegment,
                                              start,
                                              end,
                                              0,
                                              FunctionalLookupTableFlags.Linear);
         }

         start = startLine;
         end = endLine;

         SetColorValuesToLUT(_interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].LUTSegment,
                             _interactiveHistogramData.segmentStartColor, _interactiveHistogramData.segmentStartColor,
                             start, end, channel);

         nCopySize = end - start;
         if (nCopySize > 0)
         {
            EffectsUtilities.GetFunctionalLookupTable(_interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].LUTSegment,
                                              start,
                                              end,
                                              0,
                                              FunctionalLookupTableFlags.Linear);
         }
         return 1;
      }

      private bool IsColorGray(RasterColor color)
      {
         return (color.R == color.G) && (color.G == color.B);
      }

      private bool IsValidLength(int length)
      {
         if (length == 256 || length == 4096 || length == 65536)
            return true;
         else
            return false;
      }

      private int ApplySegmentationMaster(int startLine, int endLine)
      {
         int nRet;

         // Apply to Red channel...
         if (_interactiveHistogramData.gradient)
            nRet = ApplyGradMaster(startLine, endLine, RasterColorChannel.Red);
         else
            nRet = ApplyThreMaster(startLine, endLine, RasterColorChannel.Red);

         bool useLUT = applyImage.UseLookupTable;
         applyImage.UseLookupTable = false;

         if (!applyImage.UseLookupTable && (applyImage.BitsPerPixel == 12 || applyImage.BitsPerPixel == 16))
         {
            PrepareRemapIntensity(_interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].LUTSegment, _interactiveHistogramData.histogramLabel.histogramLength, RasterColorChannel.Red);
         }
         else
         {
            RemapIntensityCommand cmd = new RemapIntensityCommand();
            cmd.LookupTable = new int[_interactiveHistogramData.histogramLabel.histogramLength];
            Array.Copy(_interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].LUTSegment, cmd.LookupTable, _interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].LUTSegment.Length);
            cmd.Flags = RemapIntensityCommandFlags.Red;
            cmd.Progress += new EventHandler<RasterCommandProgressEventArgs>(cmd_Progress);
            cmd.Run(applyImage);
         }
         applyImage.UseLookupTable = useLUT;

         // Apply to Green channel...
         if (_interactiveHistogramData.gradient)
            nRet = ApplyGradMaster(startLine, endLine, RasterColorChannel.Green);
         else
            nRet = ApplyThreMaster(startLine, endLine, RasterColorChannel.Green);

         useLUT = applyImage.UseLookupTable;
         applyImage.UseLookupTable = false;

         if (!applyImage.UseLookupTable && (applyImage.BitsPerPixel == 12 || applyImage.BitsPerPixel == 16))
         {
            PrepareRemapIntensity(_interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].LUTSegment, _interactiveHistogramData.histogramLabel.histogramLength, RasterColorChannel.Green);
         }
         else
         {
            RemapIntensityCommand cmd = new RemapIntensityCommand();
            cmd.LookupTable = new int[_interactiveHistogramData.histogramLabel.histogramLength];
            Array.Copy(_interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].LUTSegment, cmd.LookupTable, _interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].LUTSegment.Length);
            cmd.Flags = RemapIntensityCommandFlags.Green;
            cmd.Progress += new EventHandler<RasterCommandProgressEventArgs>(cmd_Progress);
            cmd.Run(applyImage);
         }
         applyImage.UseLookupTable = useLUT;

         // Apply to Blue channel...
         if (_interactiveHistogramData.gradient)
            nRet = ApplyGradMaster(startLine, endLine, RasterColorChannel.Blue);
         else
            nRet = ApplyThreMaster(startLine, endLine, RasterColorChannel.Blue);

         useLUT = applyImage.UseLookupTable;
         applyImage.UseLookupTable = false;

         if (!applyImage.UseLookupTable && (applyImage.BitsPerPixel == 12 || applyImage.BitsPerPixel == 16))
         {
            PrepareRemapIntensity(_interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].LUTSegment, _interactiveHistogramData.histogramLabel.histogramLength, RasterColorChannel.Blue);
         }
         else
         {
            RemapIntensityCommand cmd = new RemapIntensityCommand();
            cmd.LookupTable = new int[_interactiveHistogramData.histogramLabel.histogramLength];
            Array.Copy(_interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].LUTSegment, cmd.LookupTable, _interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].LUTSegment.Length);
            cmd.Flags = RemapIntensityCommandFlags.Blue;
            cmd.Progress += new EventHandler<RasterCommandProgressEventArgs>(cmd_Progress);
            cmd.Run(applyImage);
         }
         applyImage.UseLookupTable = useLUT;

         return nRet;
      }

      private int ShiftFromSigned(int value)
      {
         int number;

         number = Math.Abs(_interactiveHistogramData.histogramLabel.startRange);
         number += value;

         return number;
      }

      private void SetDataValues(ref int[] puLUT)
      {
         int index;
         int middle, histogramLength;

         middle = _interactiveHistogramData.histogramLabel.histogramLength / 2;
         histogramLength = _interactiveHistogramData.histogramLabel.histogramLength;
         if (_interactiveHistogramData.signed)
         {
            for (index = 0; index < histogramLength; index++)
            {
               if (index < middle)
                  puLUT[index] = index;
               else
                  puLUT[index] = index - _interactiveHistogramData.histogramLabel.histogramLength;
            }
         }
         else
         {
            for (index = 0; index < histogramLength; index++)
            {
               puLUT[index] = index;
            }
         }
      }

      int GetLUTSegGradient()
      {
         int start, end;
         int nCopySize;
         RasterPaletteWindowLevelFlags flags;

         if (ChildImage.UseLookupTable)
         {
            flags = RasterPaletteWindowLevelFlags.Inside | RasterPaletteWindowLevelFlags.Linear | (_interactiveHistogramData.signed ? RasterPaletteWindowLevelFlags.Signed : 0) | RasterPaletteWindowLevelFlags.DicomStyle;
            Array.Copy(_interactiveHistogramData.originalLUT, _interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].RGBLUTSegment, _interactiveHistogramData.originalLUT.Length);

            start = _interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].segmentation.startLine.position;
            end = _interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].segmentation.endLine.position;

            RasterPalette.WindowLevelFillLookupTable(_interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].RGBLUTSegment,
                                         _interactiveHistogramData.segmentStartColor,
                                         _interactiveHistogramData.segmentEndColor,
                                         start,
                                         end,
                                         ChildImage.LowBit,
                                         ChildImage.HighBit,
                                         _interactiveHistogramData.histogramLabel.startRange,
                                         _interactiveHistogramData.histogramLabel.endRange,
                                         0,
                                         flags);
         }

         SetDataValues(ref _interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].LUTSegment);

         start = _interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].segmentation.startLine.position;
         end = _interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].segmentation.endLine.position;

         if (start < 0)
            start += _interactiveHistogramData.histogramLabel.histogramLength;
         if (end < 0)
            end += _interactiveHistogramData.histogramLabel.histogramLength;
         if (ChildImage.Signed)
         {
            int value;
            value = GetGrayValue(_interactiveHistogramData.segmentStartColor);
            value = SetRealVal(value);
            _interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].LUTSegment[start] = value;
            value = GetGrayValue(_interactiveHistogramData.segmentEndColor);
            value = SetRealVal(value);
            _interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].LUTSegment[end] = value;
         }
         else
            SetColorValuesToLUT(_interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].LUTSegment,
                                _interactiveHistogramData.segmentStartColor,
                                _interactiveHistogramData.segmentEndColor,
                                start, end, _interactiveHistogramData.channel);

         nCopySize = end - start;
         if (nCopySize != 0)
         {
            FunctionalLookupTableFlags LUTflags = FunctionalLookupTableFlags.Linear;
            if (_interactiveHistogramData.signed)
               LUTflags |= FunctionalLookupTableFlags.Signed;

            EffectsUtilities.GetFunctionalLookupTable(_interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].LUTSegment,
                                                      _interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].segmentation.startLine.position,
                                                      _interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].segmentation.endLine.position,
                                                      0,
                                                      LUTflags);
         }
         return 1;
      }

      private int GetLUTSegThreshold()
      {
         int start, end;
         int nCopySize;
         RasterPaletteWindowLevelFlags flags;

         if (ChildImage.UseLookupTable)
         {
            flags = RasterPaletteWindowLevelFlags.Inside | RasterPaletteWindowLevelFlags.Linear | (_interactiveHistogramData.signed ? RasterPaletteWindowLevelFlags.Signed : 0) | RasterPaletteWindowLevelFlags.DicomStyle;

            start = _interactiveHistogramData.histogramLabel.startRange;
            end = _interactiveHistogramData.histogramLabel.endRange;

            nCopySize = end - start;
            if (nCopySize != 0)
            {
               RasterPalette.WindowLevelFillLookupTable(_interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].RGBLUTSegment,
                                            _interactiveHistogramData.segmentEndColor,
                                            _interactiveHistogramData.segmentEndColor,
                                            start,
                                            end,
                                            ChildImage.LowBit,
                                            ChildImage.HighBit,
                                            _interactiveHistogramData.histogramLabel.startRange,
                                            _interactiveHistogramData.histogramLabel.endRange,
                                            0,
                                            flags);
            }

            start = _interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].segmentation.startLine.position;
            end = _interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].segmentation.endLine.position;

            RasterColor[] lookuptable = new RasterColor[_interactiveHistogramData.histogramLabel.histogramLength];
            nCopySize = end - start;
            if (nCopySize > 0)
            {
               RasterPalette.WindowLevelFillLookupTable(_interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].RGBLUTSegment,
                                            _interactiveHistogramData.segmentStartColor,
                                            _interactiveHistogramData.segmentStartColor,
                                            start,
                                            end,
                                            ChildImage.LowBit,
                                            ChildImage.HighBit,
                                            _interactiveHistogramData.histogramLabel.startRange,
                                            _interactiveHistogramData.histogramLabel.endRange,
                                            0,
                                            flags);
            }
         }

         start = _interactiveHistogramData.histogramLabel.startRange;
         end = _interactiveHistogramData.histogramLabel.endRange;
         if (start < 0)
            start += _interactiveHistogramData.histogramLabel.histogramLength;
         if (end < 0)
            end += _interactiveHistogramData.histogramLabel.histogramLength;
         if (ChildImage.Signed)
         {
            int value;
            value = GetGrayValue(_interactiveHistogramData.segmentEndColor);
            value = SetRealVal(value);
            _interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].LUTSegment[start] = value;
            _interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].LUTSegment[end] = value;
         }
         else
            SetColorValuesToLUT(_interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].LUTSegment,
                                _interactiveHistogramData.segmentEndColor, _interactiveHistogramData.segmentEndColor,
                                start, end, _interactiveHistogramData.channel);

         nCopySize = _interactiveHistogramData.histogramLabel.endRange - _interactiveHistogramData.histogramLabel.startRange;

         FunctionalLookupTableFlags LUTflags = FunctionalLookupTableFlags.Linear;
         if (_interactiveHistogramData.signed)
            LUTflags |= FunctionalLookupTableFlags.Signed;

         if (nCopySize != 0)
         {
            EffectsUtilities.GetFunctionalLookupTable(_interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].LUTSegment,
                                                      _interactiveHistogramData.histogramLabel.startRange,
                                                      _interactiveHistogramData.histogramLabel.endRange,
                                                      0,
                                                      LUTflags);
         }

         start = _interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].segmentation.startLine.position;
         end = _interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].segmentation.endLine.position;

         if (start < 0)
            start += _interactiveHistogramData.histogramLabel.histogramLength;

         if (end < 0)
            end += _interactiveHistogramData.histogramLabel.histogramLength;
         if (ChildImage.Signed)
         {
            int value;
            value = GetGrayValue(_interactiveHistogramData.segmentStartColor);
            value = SetRealVal(value);
            _interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].LUTSegment[start] = value;
            _interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].LUTSegment[end] = value;
         }
         else
            SetColorValuesToLUT(_interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].LUTSegment,
                                 _interactiveHistogramData.segmentStartColor, _interactiveHistogramData.segmentStartColor,
                                 start, end, _interactiveHistogramData.channel);

         nCopySize = end - start;
         if (nCopySize > 0)
         {
            EffectsUtilities.GetFunctionalLookupTable(_interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].LUTSegment,
                                                      _interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].segmentation.startLine.position,
                                                      _interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].segmentation.endLine.position,
                                                      0,
                                                      LUTflags);
         }
         return 1;
      }

      private int GetLUTSegmentation()
      {
         int nRet = 0;
         FreeImage(applyImage);
         applyImage = _interactiveHistogramData.originalImage.CloneAll();

         _interactiveHistogramData.grayLUT = IsColorGray(_interactiveHistogramData.segmentStartColor) && IsColorGray(_interactiveHistogramData.segmentEndColor);

         if (_interactiveHistogramData.originalImage.UseLookupTable)
            applyImage.SetLookupTable(_interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].RGBPrevLUT);

         if ((applyImage.GrayscaleMode == RasterGrayscaleMode.None) && (applyImage.GetLookupTable() != null) &&_interactiveHistogramData.channel == RasterColorChannel.Master && !_interactiveHistogramData.signed)
         {
            if (_interactiveHistogramData.applyInProgress[_tabOptions.SelectedIndex])
               nRet = ApplySegmentationMaster(_interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].segmentation.startLine.position, _interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].segmentation.endLine.position);
         }
         else
         {
            if (_interactiveHistogramData.gradient)
               nRet = GetLUTSegGradient();
            else
               nRet = GetLUTSegThreshold();

            if (_interactiveHistogramData.applyInProgress[_tabOptions.SelectedIndex])
            {
               if (_interactiveHistogramData.originalImage.UseLookupTable)
               {
                  applyImage.WindowLevel(ChildImage.LowBit,
                                         ChildImage.HighBit,
                                         _interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].RGBLUTSegment,
                                         RasterWindowLevelMode.PaintAndProcessing);
               }
               else
               {
                  bool useLUT = applyImage.UseLookupTable;
                  applyImage.UseLookupTable = false;

                  RemapIntensityCommand cmd = new RemapIntensityCommand();
                  cmd.LookupTable = new int[_interactiveHistogramData.histogramLabel.histogramLength];
                  Array.Copy(_interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].LUTSegment, cmd.LookupTable, _interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].LUTSegment.Length);
                  cmd.Flags = (RemapIntensityCommandFlags)_interactiveHistogramData.channel | RemapIntensityCommandFlags.Normal;
                  cmd.Progress += new EventHandler<RasterCommandProgressEventArgs>(cmd_Progress);
                  cmd.Run(applyImage);

                  applyImage.UseLookupTable = useLUT;
               }
            }
         }

         FreeImage(ChildImage);
         ChildImage = applyImage.CloneAll();

         return nRet;
      }

      private void ConvertToSignedRGBLut(RasterColor[] pLUT, int LUTLength)
      {
         int i, nLUTLength2;
         int nNewIndexShift;
         int nNewRedValueShift, nNewGreenValueShift, nNewBlueValueShift;

         nLUTLength2 = LUTLength / 2;

         pLUT = new RasterColor[LUTLength];

         for (i = 0; i < LUTLength; i++)
         {
            nNewIndexShift = i - nLUTLength2;
            if (nNewIndexShift < 0)
               nNewIndexShift = LUTLength + nNewIndexShift;

            nNewBlueValueShift = pLUT[i].B - nLUTLength2;
            if (nNewBlueValueShift < 0)
               nNewBlueValueShift = LUTLength + nNewBlueValueShift;
            nNewGreenValueShift = pLUT[i].G - nLUTLength2;
            if (nNewGreenValueShift < 0)
               nNewGreenValueShift = LUTLength + nNewGreenValueShift;
            nNewRedValueShift = pLUT[i].R - nLUTLength2;
            if (nNewRedValueShift < 0)
               nNewRedValueShift = LUTLength + nNewRedValueShift;

            pLUT[nNewIndexShift].R = (byte)nNewRedValueShift;
            pLUT[nNewIndexShift].B = (byte)nNewBlueValueShift;
            pLUT[nNewIndexShift].G = (byte)nNewGreenValueShift;
            pLUT[nNewIndexShift].Reserved = 0;
         }
      }

      private int GetWinLevelLUT()
      {
         RasterColor startColor;
         RasterColor endColor;
         RasterColor[] lookuptable = new RasterColor[_interactiveHistogramData.histogramLabel.histogramLength];

         startColor = new RasterColor(0, 0, 0);
         endColor = (_interactiveHistogramData.graySelectionOnly) ? new RasterColor(0, 0, 0) : new RasterColor(255, 255, 255);

         RasterPalette.WindowLevelFillLookupTable(_interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].RGBLUTGray,
                                                  startColor,
                                                  endColor,
                                                  _interactiveHistogramData.histogramLabel.startRange,
                                                  _interactiveHistogramData.histogramLabel.endRange,
                                                  ChildImage.LowBit,
                                                  ChildImage.HighBit,
                                                  0,
                                                  _interactiveHistogramData.histogramLabel.histogramLength - 1,
                                                  0,
                                                  RasterPaletteWindowLevelFlags.Linear | RasterPaletteWindowLevelFlags.Inside | (_interactiveHistogramData.signed ? RasterPaletteWindowLevelFlags.Signed : 0) | RasterPaletteWindowLevelFlags.DicomStyle);

         RasterPalette.WindowLevelFillLookupTable(lookuptable,
                                                  _interactiveHistogramData.grayStartColor,
                                                  _interactiveHistogramData.grayEndColor,
                                                  _interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].grayDistribution.startLine.position,
                                                  _interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].grayDistribution.endLine.position,
                                                  ChildImage.LowBit,
                                                  ChildImage.HighBit,
                                                  0,
                                                  _interactiveHistogramData.histogramLabel.histogramLength - 1,
                                                  _interactiveHistogramData.grayFactor,
                                                  GetFillFunction());

         Array.Copy(lookuptable, ShiftFromSigned(GetStart()), _interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].RGBLUTGray, ShiftFromSigned(GetStart()), ShiftFromSigned(GetEnd()) - ShiftFromSigned(GetStart()));

         return 1;
      }

      private int[] GetUintArray(RasterColor[] rgbArray, int length, RasterColorChannel channel)
      {
         int index;
         int[] array = new int[length];

         for (index = 0; index < length; index++)
         {
            switch (channel)
            {
               case RasterColorChannel.Red:
                  array[index] = rgbArray[index].R;
                  break;
               case RasterColorChannel.Green:
                  array[index] = rgbArray[index].G;
                  break;
               case RasterColorChannel.Blue:
                  array[index] = rgbArray[index].B;
                  break;
            }
         }
         return array;
      }

      private int ApplyGrayMaster(int nStartHist, int nEndHist)
      {
         RasterColor startColor;
         RasterColor endColor;

         // Apply the Red Channel...
         if ((nEndHist - nStartHist + 1) != (int)_interactiveHistogramData.histogramLabel.histogramLength)
         {
            startColor = new RasterColor(0, 0, 0);
            endColor = (_interactiveHistogramData.graySelectionOnly) ? new RasterColor(0, 0, 0) : new RasterColor(255, 255, 255);

            SetColorValuesToLUT(_interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].LUTGray,
                                startColor,
                                endColor,
                                _interactiveHistogramData.histogramLabel.startRange,
                                _interactiveHistogramData.histogramLabel.endRange,
                                RasterColorChannel.Red);

            EffectsUtilities.GetFunctionalLookupTable(_interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].LUTGray,
                                                      _interactiveHistogramData.histogramLabel.startRange,
                                                      _interactiveHistogramData.histogramLabel.endRange,
                                                      0,
                                                      FunctionalLookupTableFlags.Linear);
         }

         SetColorValuesToLUT(_interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].LUTGray,
                            _interactiveHistogramData.grayStartColor,
                            _interactiveHistogramData.grayEndColor,
                            nStartHist,
                            nEndHist,
                            RasterColorChannel.Red);

         EffectsUtilities.GetFunctionalLookupTable(_interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].LUTGray,
                                                   nStartHist,
                                                   nEndHist,
                                                   _interactiveHistogramData.grayFactor,
                                                   _interactiveHistogramData.grayFunctionType);

         bool useLUT = applyImage.UseLookupTable;
         applyImage.UseLookupTable = false;

         RemapIntensityCommand cmd = new RemapIntensityCommand();
         cmd.LookupTable = new int[_interactiveHistogramData.histogramLabel.histogramLength];
         Array.Copy(_interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].LUTGray, cmd.LookupTable, _interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].LUTGray.Length);
         cmd.Flags = RemapIntensityCommandFlags.Red;
         cmd.Progress += new EventHandler<RasterCommandProgressEventArgs>(cmd_Progress);
         cmd.Run(applyImage);

         applyImage.UseLookupTable = useLUT;

         // Apply the Green Channel...
         if ((nEndHist - nStartHist + 1) != (int)_interactiveHistogramData.histogramLabel.histogramLength)
         {
            startColor = new RasterColor(0, 0, 0);
            endColor = (_interactiveHistogramData.graySelectionOnly) ? new RasterColor(0, 0, 0) : new RasterColor(255, 255, 255);

            SetColorValuesToLUT(_interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].LUTGray,
                                startColor,
                                endColor,
                                _interactiveHistogramData.histogramLabel.startRange,
                                _interactiveHistogramData.histogramLabel.endRange,
                                RasterColorChannel.Green);

            EffectsUtilities.GetFunctionalLookupTable(_interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].LUTGray,
                                              _interactiveHistogramData.histogramLabel.startRange,
                                              _interactiveHistogramData.histogramLabel.endRange,
                                              0,
                                              FunctionalLookupTableFlags.Linear);
         }

         SetColorValuesToLUT(_interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].LUTGray,
                             _interactiveHistogramData.grayStartColor,
                             _interactiveHistogramData.grayEndColor,
                             nStartHist,
                             nEndHist,
                             RasterColorChannel.Green);

         EffectsUtilities.GetFunctionalLookupTable(_interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].LUTGray,
                                                   nStartHist,
                                                   nEndHist,
                                                   _interactiveHistogramData.grayFactor,
                                                   _interactiveHistogramData.grayFunctionType);

         useLUT = applyImage.UseLookupTable;
         applyImage.UseLookupTable = false;

         cmd = new RemapIntensityCommand();
         cmd.LookupTable = new int[_interactiveHistogramData.histogramLabel.histogramLength];
         Array.Copy(_interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].LUTGray, cmd.LookupTable, _interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].LUTGray.Length);
         cmd.Flags = RemapIntensityCommandFlags.Green;
         cmd.Progress += new EventHandler<RasterCommandProgressEventArgs>(cmd_Progress);
         cmd.Run(applyImage);

         applyImage.UseLookupTable = useLUT;

         // Apply the Blue Channel...
         if ((nEndHist - nStartHist + 1) != (int)_interactiveHistogramData.histogramLabel.histogramLength)
         {
            startColor = new RasterColor(0, 0, 0);
            endColor = (_interactiveHistogramData.graySelectionOnly) ? new RasterColor(0, 0, 0) : new RasterColor(255, 255, 255);

            SetColorValuesToLUT(_interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].LUTGray,
                                startColor,
                                endColor,
                                _interactiveHistogramData.histogramLabel.startRange,
                                _interactiveHistogramData.histogramLabel.endRange,
                                RasterColorChannel.Blue);

            EffectsUtilities.GetFunctionalLookupTable(_interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].LUTGray,
                                                      _interactiveHistogramData.histogramLabel.startRange,
                                                      _interactiveHistogramData.histogramLabel.endRange,
                                                      0,
                                                      FunctionalLookupTableFlags.Linear);
         }

         SetColorValuesToLUT(_interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].LUTGray,
                            _interactiveHistogramData.grayStartColor,
                            _interactiveHistogramData.grayEndColor,
                            nStartHist,
                            nEndHist,
                            RasterColorChannel.Blue);

         EffectsUtilities.GetFunctionalLookupTable(_interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].LUTGray,
                                                   nStartHist,
                                                   nEndHist,
                                                   _interactiveHistogramData.grayFactor,
                                                   _interactiveHistogramData.grayFunctionType);

         useLUT = applyImage.UseLookupTable;
         applyImage.UseLookupTable = false;

         cmd = new RemapIntensityCommand();
         cmd.LookupTable = new int[_interactiveHistogramData.histogramLabel.histogramLength];
         Array.Copy(_interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].LUTGray, cmd.LookupTable, _interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].LUTGray.Length);
         cmd.Flags = RemapIntensityCommandFlags.Blue;
         cmd.Progress += new EventHandler<RasterCommandProgressEventArgs>(cmd_Progress);
         cmd.Run(applyImage);

         applyImage.UseLookupTable = useLUT;

         return 1;
      }

      private RasterPaletteWindowLevelFlags GetFillFunction()
      {
         RasterPaletteWindowLevelFlags flags = RasterPaletteWindowLevelFlags.Inside | (_interactiveHistogramData.signed ? RasterPaletteWindowLevelFlags.Signed : 0) | RasterPaletteWindowLevelFlags.DicomStyle;

         switch (_cbGrayFunctionType.SelectedIndex)
         {
            case 0: flags |= RasterPaletteWindowLevelFlags.Exponential; break;
            case 1: flags |= RasterPaletteWindowLevelFlags.Logarithmic; break;
            case 2: flags |= RasterPaletteWindowLevelFlags.Linear; break;
            case 3: flags |= RasterPaletteWindowLevelFlags.Sigmoid; break;
         }
         return flags;
      }


      private int GenerateLUTFromPalette(RasterColor[] RGBLUTGray, RasterColor[] RGBPallete)
      {
         int index;
         int counter;
         RasterColor startColor;
         RasterColor endColor;
         RasterPaletteWindowLevelFlags flags = RasterPaletteWindowLevelFlags.Inside | RasterPaletteWindowLevelFlags.Linear | RasterPaletteWindowLevelFlags.DicomStyle;
         int nEndRange;
         double fStep;
         int nStartStep = 0;
         int nEndStep = 0;

         nEndRange = 1 << (ChildImage.HighBit + 1);
         fStep = (double)((double)(_interactiveHistogramData.histogramLabel.histogramLength) / (_interactiveHistogramData.numberofPallet - 1));
         if (_interactiveHistogramData.numberofPallet < 2)
         {
            startColor = RGBPallete[0];
            endColor = startColor;
            nStartStep = 0;
            nEndStep = _interactiveHistogramData.histogramLabel.histogramLength - 1;
            RasterPalette.WindowLevelFillLookupTable(RGBLUTGray,
                                                     startColor,
                                                     endColor,
                                                     nStartStep,
                                                     nEndStep,
                                                     ChildImage.LowBit,
                                                     ChildImage.HighBit,
                                                     0,
                                                     nEndRange,
                                                     0,
                                                     flags);
         }

         _interactiveHistogramData.numberofPallet--;
         for (index = 0, counter = 0; index < _interactiveHistogramData.numberofPallet; index++, counter++)
         {
            startColor = RGBPallete[counter];
            endColor = RGBPallete[counter + 1];

            nStartStep = Convert.ToInt32(counter * fStep);
            nEndStep = Convert.ToInt32((counter + 1) * fStep - 1);

            RasterPalette.WindowLevelFillLookupTable(RGBLUTGray,
                                                     startColor,
                                                     endColor,
                                                     nStartStep,
                                                     nEndStep,
                                                     ChildImage.LowBit,
                                                     ChildImage.HighBit,
                                                     0,
                                                     nEndRange,
                                                     0,
                                                     flags);
         }

         if (_interactiveHistogramData.signed)
            ConvertToSignedRGBLut(RGBLUTGray, _interactiveHistogramData.histogramLabel.histogramLength);
         _interactiveHistogramData.numberofPallet = 256;
         return 1;
      }

      private int GetLUTGrayDistribution()
      {
         int nRet;
         int nSHist, nEHist;
         int nStart, nEnd;

         if (!_interactiveHistogramData.letApplyOnPallete && _interactiveHistogramData.grayPredefinedPalette)
            return 1;

         applyImage = _interactiveHistogramData.originalImage.CloneAll();

         if (ChildImage.UseLookupTable)
            applyImage.SetLookupTable(_interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].RGBPrevLUT);

         _interactiveHistogramData.grayLUT = IsColorGray(_interactiveHistogramData.grayStartColor) && IsColorGray(_interactiveHistogramData.grayEndColor);

         if ((applyImage.GrayscaleMode == RasterGrayscaleMode.None && (!applyImage.UseLookupTable)) && _interactiveHistogramData.channel == RasterColorChannel.Master && !_interactiveHistogramData.signed)
         {
            if (_interactiveHistogramData.applyInProgress[_tabOptions.SelectedIndex])
            {
               nRet = ApplyGrayMaster(_interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].grayDistribution.startLine.position, _interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].grayDistribution.endLine.position);
            }
         }
         else
         {
            nStart = nSHist = GetStart();
            nEnd = nEHist = GetEnd();

            if (_interactiveHistogramData.grayPredefinedPalette)
            {
               GenerateLUTFromPalette(_interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].RGBLUTGray, _interactiveHistogramData.predefinedPalette);
               if (_interactiveHistogramData.letApplyOnPallete)
                  _interactiveHistogramData.letApplyOnPallete = false;
            }
            else
            {
               if (ChildImage.UseLookupTable)
               {
                  if ((nEHist - nSHist + 1) != _interactiveHistogramData.histogramLabel.histogramLength)
                  {
                     if (_interactiveHistogramData.graySelectionOnly)
                        _interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].RGBLUTGray = new RasterColor[_interactiveHistogramData.histogramLabel.histogramLength];
                     // copy the original Bitmap LUT
                     else
                        Array.Copy(_interactiveHistogramData.originalLUT, _interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].RGBLUTGray, _interactiveHistogramData.histogramLabel.histogramLength);
                  }

                  RasterPalette.WindowLevelFillLookupTable(_interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].RGBLUTGray,
                                                            _interactiveHistogramData.grayStartColor,
                                                            _interactiveHistogramData.grayEndColor,
                                                            nSHist,
                                                            nEHist,
                                                            ChildImage.LowBit,
                                                            ChildImage.HighBit,
                                                            _interactiveHistogramData.histogramLabel.startRange,
                                                            _interactiveHistogramData.histogramLabel.endRange,
                                                            _interactiveHistogramData.grayFactor,
                                                            GetFillFunction());
               }

               if ((nEHist - nSHist + 1) != _interactiveHistogramData.histogramLabel.histogramLength)
               {
                  SetDataValues(ref _interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].LUTGray);
               }

               if (_interactiveHistogramData.graySelectionOnly)
               {
                  _interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].LUTGray = new int[_interactiveHistogramData.histogramLabel.histogramLength];
               }
               if (nStart < 0)
                  nStart += _interactiveHistogramData.histogramLabel.histogramLength;
               if (nEnd < 0)
                  nEnd += _interactiveHistogramData.histogramLabel.histogramLength;

               if (_interactiveHistogramData.signed)
               {
                  int nValue;
                  nValue = GetGrayValue(_interactiveHistogramData.segmentStartColor);
                  nValue = SetRealVal(nValue);
                  _interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].LUTGray[nStart] = nValue;
                  nValue = GetGrayValue(_interactiveHistogramData.segmentEndColor);
                  nValue = SetRealVal(nValue);
                  _interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].LUTGray[nEnd] = nValue;
               }
               else
                  SetColorValuesToLUT(_interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].LUTGray,
                                       _interactiveHistogramData.grayStartColor,
                                       _interactiveHistogramData.grayEndColor,
                                       nSHist,
                                       nEHist,
                                       _interactiveHistogramData.channel);

               FunctionalLookupTableFlags lutFlags = _interactiveHistogramData.grayFunctionType;
               if (_interactiveHistogramData.signed)
                  lutFlags |= FunctionalLookupTableFlags.Signed;

               EffectsUtilities.GetFunctionalLookupTable(_interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].LUTGray,
                                                         nSHist,
                                                         nEHist,
                                                         _interactiveHistogramData.grayFactor,
                                                         lutFlags);
            }

            if (_interactiveHistogramData.applyInProgress[_tabOptions.SelectedIndex])
            {
               if (ChildImage.UseLookupTable)
               {
                  applyImage.WindowLevel(ChildImage.LowBit,
                                          ChildImage.HighBit,
                                          _interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].RGBLUTGray,
                                          RasterWindowLevelMode.PaintAndProcessing);
               }
               else
               {
                  bool bUseLUT = applyImage.UseLookupTable;
                  applyImage.UseLookupTable = false;

                  RemapIntensityCommand cmd = new RemapIntensityCommand();
                  cmd.LookupTable = new int[_interactiveHistogramData.histogramLabel.histogramLength];
                  Array.Copy(_interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].LUTGray, cmd.LookupTable, _interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].LUTGray.Length);
                  cmd.Flags = (RemapIntensityCommandFlags)_interactiveHistogramData.channel;
                  cmd.Progress += new EventHandler<RasterCommandProgressEventArgs>(cmd_Progress);
                  cmd.Run(applyImage);

                  applyImage.UseLookupTable = bUseLUT;
               }
            }
         }

         FreeImage(ChildImage);
         ChildImage = applyImage.CloneAll();
         return 1;
      }

      private int ApplyFilterMaster(int nStartHist, int nEndHist)
      {
         RasterColor color = Leadtools.Demos.Converters.FromGdiPlusColor(Color.Black);
         FunctionalLookupTableFlags uFlags = FunctionalLookupTableFlags.Linear;
         if (_interactiveHistogramData.signed)
            uFlags |= FunctionalLookupTableFlags.Signed;

         // Apply to the Red Channel...
         SetColorValuesToLUT(_interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].LUTFilter,
                            new RasterColor(0, 0, 0),
                            new RasterColor(255, 255, 255),
                            _interactiveHistogramData.histogramLabel.startRange,
                            _interactiveHistogramData.histogramLabel.endRange,
                            RasterColorChannel.Red);

         EffectsUtilities.GetFunctionalLookupTable(_interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].LUTFilter,
                                           _interactiveHistogramData.histogramLabel.startRange,
                                           _interactiveHistogramData.histogramLabel.endRange,
                                           0,
                                           uFlags);

         switch (_interactiveHistogramData.noiseReplaceType)
         {
            case FilterNoiseReplaceType.StartEndPoints:
               color = GetColorFromNumber(GetRealVal(GetStart()));
               break;

            case FilterNoiseReplaceType.MinimumMaximumIntensity:
               color = GetColorFromNumber(GetRealVal(_interactiveHistogramData.minimumValue));
               break;

            case FilterNoiseReplaceType.ReplaceColor:
               color = _interactiveHistogramData.noiseReplaceColor;
               break;

            case FilterNoiseReplaceType.Zero:
               color = new RasterColor(0, 0, 0);
               break;
         }

         SetColorValuesToLUT(_interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].LUTFilter,
                            color,
                            color,
                            _interactiveHistogramData.histogramLabel.startRange,
                            nStartHist,
                            RasterColorChannel.Red);

         EffectsUtilities.GetFunctionalLookupTable(_interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].LUTFilter,
                                              _interactiveHistogramData.histogramLabel.startRange,
                                              nStartHist,
                                              0,
                                              uFlags);

         switch (_interactiveHistogramData.noiseReplaceType)
         {
            case FilterNoiseReplaceType.StartEndPoints:
               color = GetColorFromNumber(GetRealVal(GetEnd()));
               break;

            case FilterNoiseReplaceType.MinimumMaximumIntensity:
               color = GetColorFromNumber(GetRealVal(_interactiveHistogramData.maximumValue));
               break;

            case FilterNoiseReplaceType.ReplaceColor:
               color = _interactiveHistogramData.noiseReplaceColor;
               break;

            case FilterNoiseReplaceType.Zero:
               color = new RasterColor(0, 0, 0);
               break;
         }

         SetColorValuesToLUT(_interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].LUTFilter,
                            color,
                            color,
                            nEndHist,
                            _interactiveHistogramData.histogramLabel.endRange,
                            RasterColorChannel.Red);

         EffectsUtilities.GetFunctionalLookupTable(_interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].LUTFilter,
                                           nEndHist,
                                           _interactiveHistogramData.histogramLabel.endRange,
                                           0,
                                           uFlags);

         bool useLUT = applyImage.UseLookupTable;
         applyImage.UseLookupTable = false;

         if (!applyImage.UseLookupTable && (applyImage.BitsPerPixel == 12 || applyImage.BitsPerPixel == 16))
         {
            PrepareRemapIntensity(_interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].LUTFilter, _interactiveHistogramData.histogramLabel.histogramLength, RasterColorChannel.Red);
         }
         else
         {
            RemapIntensityCommand cmd = new RemapIntensityCommand();
            cmd.LookupTable = new int[_interactiveHistogramData.histogramLabel.histogramLength];
            Array.Copy(_interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].LUTFilter, cmd.LookupTable, _interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].LUTFilter.Length);
            cmd.Flags = RemapIntensityCommandFlags.Red;
            cmd.Progress += new EventHandler<RasterCommandProgressEventArgs>(cmd_Progress);
            cmd.Run(applyImage);
         }
         applyImage.UseLookupTable = useLUT;

         // Apply to the Green Channel...
         SetColorValuesToLUT(_interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].LUTFilter,
                             new RasterColor(0, 0, 0),
                             new RasterColor(255, 255, 255),
                             _interactiveHistogramData.histogramLabel.startRange,
                             _interactiveHistogramData.histogramLabel.endRange,
                             RasterColorChannel.Green);

         EffectsUtilities.GetFunctionalLookupTable(_interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].LUTFilter,
                                                   _interactiveHistogramData.histogramLabel.startRange,
                                                   _interactiveHistogramData.histogramLabel.endRange,
                                                   0,
                                                   uFlags);

         switch (_interactiveHistogramData.noiseReplaceType)
         {
            case FilterNoiseReplaceType.StartEndPoints:
               color = GetColorFromNumber(GetRealVal(GetStart()));
               break;

            case FilterNoiseReplaceType.MinimumMaximumIntensity:
               color = GetColorFromNumber(GetRealVal(_interactiveHistogramData.minimumValue));
               break;

            case FilterNoiseReplaceType.ReplaceColor:
               color = _interactiveHistogramData.noiseReplaceColor;
               break;

            case FilterNoiseReplaceType.Zero:
               color = new RasterColor(0, 0, 0);
               break;
         }

         SetColorValuesToLUT(_interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].LUTFilter,
                            color,
                            color,
                            _interactiveHistogramData.histogramLabel.startRange,
                            nStartHist,
                            RasterColorChannel.Green);

         EffectsUtilities.GetFunctionalLookupTable(_interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].LUTFilter,
                                                   _interactiveHistogramData.histogramLabel.startRange,
                                                   nStartHist,
                                                   0,
                                                   uFlags);

         switch (_interactiveHistogramData.noiseReplaceType)
         {
            case FilterNoiseReplaceType.StartEndPoints:
               color = GetColorFromNumber(GetRealVal(GetEnd()));
               break;

            case FilterNoiseReplaceType.MinimumMaximumIntensity:
               color = GetColorFromNumber(GetRealVal(_interactiveHistogramData.maximumValue));
               break;

            case FilterNoiseReplaceType.ReplaceColor:
               color = _interactiveHistogramData.noiseReplaceColor;
               break;

            case FilterNoiseReplaceType.Zero:
               color = new RasterColor(0, 0, 0);
               break;
         }

         SetColorValuesToLUT(_interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].LUTFilter,
                            color,
                            color,
                            nEndHist,
                            _interactiveHistogramData.histogramLabel.endRange,
                            RasterColorChannel.Green);

         EffectsUtilities.GetFunctionalLookupTable(_interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].LUTFilter,
                                           nEndHist,
                                           _interactiveHistogramData.histogramLabel.endRange,
                                           0,
                                           uFlags);

         useLUT = applyImage.UseLookupTable;
         applyImage.UseLookupTable = false;

         if (!applyImage.UseLookupTable && (applyImage.BitsPerPixel == 12 || applyImage.BitsPerPixel == 16))
         {
            PrepareRemapIntensity(_interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].LUTFilter, _interactiveHistogramData.histogramLabel.histogramLength, RasterColorChannel.Green);
         }
         else
         {
            RemapIntensityCommand cmd = new RemapIntensityCommand();
            cmd.LookupTable = new int[_interactiveHistogramData.histogramLabel.histogramLength];
            Array.Copy(_interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].LUTFilter, cmd.LookupTable, _interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].LUTFilter.Length);
            cmd.Flags = RemapIntensityCommandFlags.Green;
            cmd.Progress += new EventHandler<RasterCommandProgressEventArgs>(cmd_Progress);
            cmd.Run(applyImage);
         }
         applyImage.UseLookupTable = useLUT;

         // Apply to the Blue Channel...
         SetColorValuesToLUT(_interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].LUTFilter,
                            new RasterColor(0, 0, 0),
                            new RasterColor(255, 255, 255),
                            _interactiveHistogramData.histogramLabel.startRange,
                            _interactiveHistogramData.histogramLabel.endRange,
                            RasterColorChannel.Blue);

         EffectsUtilities.GetFunctionalLookupTable(_interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].LUTFilter,
                                           _interactiveHistogramData.histogramLabel.startRange,
                                           _interactiveHistogramData.histogramLabel.endRange,
                                           0,
                                           uFlags);

         switch (_interactiveHistogramData.noiseReplaceType)
         {
            case FilterNoiseReplaceType.StartEndPoints:
               color = GetColorFromNumber(GetRealVal(GetStart()));
               break;
            case FilterNoiseReplaceType.MinimumMaximumIntensity:
               color = GetColorFromNumber(GetRealVal(_interactiveHistogramData.minimumValue));
               break;

            case FilterNoiseReplaceType.ReplaceColor:
               color = _interactiveHistogramData.noiseReplaceColor;
               break;

            case FilterNoiseReplaceType.Zero:
               color = new RasterColor(0, 0, 0);
               break;
         }

         SetColorValuesToLUT(_interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].LUTFilter,
                            color,
                            color,
                            _interactiveHistogramData.histogramLabel.startRange,
                            nStartHist,
                            RasterColorChannel.Blue);

         EffectsUtilities.GetFunctionalLookupTable(_interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].LUTFilter,
                                           _interactiveHistogramData.histogramLabel.startRange,
                                           nStartHist,
                                           0,
                                           uFlags);

         switch (_interactiveHistogramData.noiseReplaceType)
         {
            case FilterNoiseReplaceType.StartEndPoints:
               color = GetColorFromNumber(GetRealVal(GetEnd()));
               break;

            case FilterNoiseReplaceType.MinimumMaximumIntensity:
               color = GetColorFromNumber(GetRealVal(_interactiveHistogramData.maximumValue));
               break;

            case FilterNoiseReplaceType.ReplaceColor:
               color = _interactiveHistogramData.noiseReplaceColor;
               break;

            case FilterNoiseReplaceType.Zero:
               color = new RasterColor(0, 0, 0);
               break;
         }

         SetColorValuesToLUT(_interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].LUTFilter,
                            color,
                            color,
                            nEndHist,
                            _interactiveHistogramData.histogramLabel.endRange,
                            RasterColorChannel.Blue);

         EffectsUtilities.GetFunctionalLookupTable(_interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].LUTFilter,
                                           nEndHist,
                                           _interactiveHistogramData.histogramLabel.endRange,
                                           0,
                                           uFlags);

         useLUT = applyImage.UseLookupTable;
         applyImage.UseLookupTable = false;

         if (!applyImage.UseLookupTable && (applyImage.BitsPerPixel == 12 || applyImage.BitsPerPixel == 16))
         {
            PrepareRemapIntensity(_interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].LUTFilter, _interactiveHistogramData.histogramLabel.histogramLength, RasterColorChannel.Blue);
         }
         else
         {
            RemapIntensityCommand cmd = new RemapIntensityCommand();
            cmd.LookupTable = new int[_interactiveHistogramData.histogramLabel.histogramLength];
            Array.Copy(_interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].LUTFilter, cmd.LookupTable, _interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].LUTFilter.Length);
            cmd.Flags = RemapIntensityCommandFlags.Blue;
            cmd.Progress += new EventHandler<RasterCommandProgressEventArgs>(cmd_Progress);
            cmd.Run(applyImage);
         }
         applyImage.UseLookupTable = useLUT;

         return 1;
      }

      private RasterColor GetColorFromNumber(int nValue)
      {
         byte byteColor = (byte)Math.Max(0, Math.Min(255, nValue));
         return (new RasterColor(byteColor, byteColor, byteColor));
      }

      private int GetLUTFilterNoise()
      {
         int nStartLoop, nEndLoop, endRange;
         int nRet;
         RasterColor color = Leadtools.Demos.Converters.FromGdiPlusColor(Color.Black);
         int nValue = 0;
         int nStart, nEnd;
         FunctionalLookupTableFlags uFlags;

         nStartLoop = GetStart() + ((_interactiveHistogramData.signed) ? Math.Abs(_interactiveHistogramData.histogramLabel.startRange) : 0);
         nEndLoop = GetEnd() + ((_interactiveHistogramData.signed) ? Math.Abs(_interactiveHistogramData.histogramLabel.startRange) : 0);
         endRange = _interactiveHistogramData.histogramLabel.endRange + ((_interactiveHistogramData.signed) ? Math.Abs(_interactiveHistogramData.histogramLabel.startRange) : 0);

         _interactiveHistogramData.grayLUT = true;
         applyImage = _interactiveHistogramData.originalImage.CloneAll();

         if (ChildImage.UseLookupTable)
            applyImage.SetLookupTable(_interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].RGBPrevLUT);

         uFlags = FunctionalLookupTableFlags.Linear;
         if (_interactiveHistogramData.signed)
            uFlags |= FunctionalLookupTableFlags.Signed;

         if ((applyImage.GrayscaleMode == RasterGrayscaleMode.None) && _interactiveHistogramData.channel == RasterColorChannel.Master && !_interactiveHistogramData.signed)
         {
            if (_interactiveHistogramData.applyInProgress[_tabOptions.SelectedIndex])
               nRet = ApplyFilterMaster(_interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].filterNoise.startLine.position, _interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].filterNoise.endLine.position);
         }
         else
         {
            SetDataValues(ref _interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].LUTFilter);

            switch (_interactiveHistogramData.noiseReplaceType)
            {
               case FilterNoiseReplaceType.StartEndPoints:
                  nValue = GetStart();
                  if (!applyImage.Signed)
                     color = GetColorFromNumber(GetRealVal(nValue));
                  else
                  {
                     if (nValue < 0)
                        nValue += _interactiveHistogramData.histogramLabel.histogramLength;
                     nValue = _interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].LUTFilter[nValue];
                  }
                  break;

               case FilterNoiseReplaceType.MinimumMaximumIntensity:
                  nValue = _interactiveHistogramData.noiseMinIntensity;
                  if (!applyImage.Signed)
                     color = GetColorFromNumber(GetRealVal(nValue));
                  else
                  {
                     if (nValue < 0)
                        nValue += _interactiveHistogramData.histogramLabel.histogramLength;
                     nValue = _interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].LUTFilter[nValue];
                  }
                  break;

               case FilterNoiseReplaceType.ReplaceColor:
                  color = _interactiveHistogramData.noiseReplaceColor;
                  if (applyImage.Signed)
                  {
                     nValue = GetGrayValue(color);
                     nValue = SetRealVal(nValue);
                  }
                  break;

               case FilterNoiseReplaceType.Zero:
                  color = GetColorFromNumber(0);
                  if (applyImage.Signed)
                  {
                     nValue = GetGrayValue(color);
                     nValue = SetRealVal(nValue);
                  }
                  break;
            }

            nStart = _interactiveHistogramData.histogramLabel.startRange;
            nEnd = _interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].filterNoise.startLine.position;
            if (nStart != nEnd)
            {
               if (nStart < 0)
                  nStart += _interactiveHistogramData.histogramLabel.histogramLength;
               if (nEnd < 0)
                  nEnd += _interactiveHistogramData.histogramLabel.histogramLength;

               if (applyImage.Signed)
               {
                  _interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].LUTFilter[nStart] = nValue;
                  _interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].LUTFilter[nEnd] = nValue;
               }
               else
                  SetColorValuesToLUT(_interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].LUTFilter,
                     color,
                     color,
                     nStart,
                     nEnd,
                     _interactiveHistogramData.channel);

               if (_interactiveHistogramData.histogramLabel.startRange != _interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].filterNoise.startLine.position)
               {
                  EffectsUtilities.GetFunctionalLookupTable(_interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].LUTFilter,
                                                            _interactiveHistogramData.histogramLabel.startRange,
                                                            _interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].filterNoise.startLine.position,
                                                            0,
                                                            uFlags);
               }
            }

            switch (_interactiveHistogramData.noiseReplaceType)
            {
               case FilterNoiseReplaceType.StartEndPoints:
                  nValue = GetEnd();
                  if (!applyImage.Signed)
                     color = GetColorFromNumber(GetRealVal(nValue));
                  else
                  {
                     if (nValue < 0)
                        nValue += _interactiveHistogramData.histogramLabel.histogramLength;
                     nValue = _interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].LUTFilter[nValue];
                  }
                  break;

               case FilterNoiseReplaceType.MinimumMaximumIntensity:
                  nValue = _interactiveHistogramData.noiseMaxIntensity;
                  if ((!applyImage.Signed))
                     color = GetColorFromNumber(GetRealVal(nValue));
                  else
                  {
                     if (nValue < 0)
                        nValue += _interactiveHistogramData.histogramLabel.histogramLength;
                     nValue = _interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].LUTFilter[nValue];
                  }
                  break;

               case FilterNoiseReplaceType.ReplaceColor:
                  color = _interactiveHistogramData.noiseReplaceColor;
                  if (applyImage.Signed)
                  {
                     nValue = GetGrayValue(color);
                     nValue = SetRealVal(nValue);
                  }
                  break;

               case FilterNoiseReplaceType.Zero:
                  color = new RasterColor(0, 0, 0);
                  if (applyImage.Signed)
                  {
                     nValue = GetGrayValue(color);
                     nValue = SetRealVal(nValue);
                  }
                  break;
            }

            nStart = _interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].filterNoise.endLine.position;
            nEnd = _interactiveHistogramData.histogramLabel.endRange;
            if (nStart != nEnd)
            {
               if (nStart < 0)
                  nStart += _interactiveHistogramData.histogramLabel.histogramLength;
               if (nEnd < 0)
                  nEnd += _interactiveHistogramData.histogramLabel.histogramLength;
               if (applyImage.Signed)
               {
                  _interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].LUTFilter[nStart] = nValue;
                  _interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].LUTFilter[nEnd] = nValue;
               }
               else
                  SetColorValuesToLUT(_interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].LUTFilter,
                                     color,
                                     color,
                                     nStart,
                                     nEnd,
                                     _interactiveHistogramData.channel);

               if (_interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].filterNoise.endLine.position != _interactiveHistogramData.histogramLabel.endRange)
                  EffectsUtilities.GetFunctionalLookupTable(_interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].LUTFilter,
                                                    _interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].filterNoise.endLine.position,
                                                    _interactiveHistogramData.histogramLabel.endRange,
                                                    0,
                                                    uFlags);
            }

            bool useLUT = applyImage.UseLookupTable;
            applyImage.UseLookupTable = false;

            if (_interactiveHistogramData.applyInProgress[_tabOptions.SelectedIndex])
            {
               RemapIntensityCommand cmd = new RemapIntensityCommand();
               cmd.LookupTable = _interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].LUTFilter;
               cmd.Flags = (RemapIntensityCommandFlags)_interactiveHistogramData.channel | RemapIntensityCommandFlags.Normal;
               cmd.Progress += new EventHandler<RasterCommandProgressEventArgs>(cmd_Progress);
               cmd.Run(applyImage);
            }

            applyImage.UseLookupTable = useLUT;
         }

         FreeImage(ChildImage);
         ChildImage = applyImage.CloneAll();
         return 1;
      }

      private int GetLUTResShift()
      {
         int nFrom, nTo, nTemp;
         FunctionalLookupTableFlags uFlags;

         uFlags = FunctionalLookupTableFlags.Linear;
         if (_interactiveHistogramData.signed)
            uFlags |= FunctionalLookupTableFlags.Signed;

         SetDataValues(ref _interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].LUTRescale);

         if (_interactiveHistogramData.shiftRight)
         {
            nTemp = _interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].rescale.startLine.position;
            nTemp += (int)_nudResShiftAmount.Value;
            if (nTemp > _interactiveHistogramData.histogramLabel.endRange)
               nTemp = _interactiveHistogramData.histogramLabel.endRange;

            nFrom = _interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].rescale.startLine.position;
            if (nFrom < 0)
               nFrom += _interactiveHistogramData.histogramLabel.histogramLength;

            _interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].LUTRescale[nFrom] = nTemp;

            nTemp = _interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].rescale.endLine.position;
            nTemp += (int)_nudResShiftAmount.Value;
            if (nTemp > _interactiveHistogramData.histogramLabel.endRange)
               nTemp = _interactiveHistogramData.histogramLabel.endRange;

            nTo = _interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].rescale.endLine.position;
            if (nTo < 0)
               nTo += _interactiveHistogramData.histogramLabel.histogramLength;

            _interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].LUTRescale[nTo] = nTemp;
         }
         else
         {
            nTemp = _interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].rescale.startLine.position;
            nTemp -= (int)_nudResShiftAmount.Value;
            if (nTemp < _interactiveHistogramData.histogramLabel.startRange)
               nTemp = _interactiveHistogramData.histogramLabel.startRange;

            nFrom = _interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].rescale.startLine.position;
            if (nFrom < 0)
               nFrom += _interactiveHistogramData.histogramLabel.histogramLength;

            _interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].LUTRescale[nFrom] = nTemp;

            nTemp = _interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].rescale.endLine.position;
            nTemp -= (int)_nudResShiftAmount.Value;
            if (nTemp < _interactiveHistogramData.histogramLabel.startRange)
               nTemp = _interactiveHistogramData.histogramLabel.startRange;

            nTo = _interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].rescale.endLine.position;
            if (nTo < 0)
               nTo += _interactiveHistogramData.histogramLabel.histogramLength;

            _interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].LUTRescale[nTo] = nTemp;
         }

         EffectsUtilities.GetFunctionalLookupTable(_interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].LUTRescale,
                                                   GetStart(),
                                                   GetEnd(),
                                                   0,
                                                   uFlags);

         return 1;
      }

      int GetLUTResNewSE()
      {
         int nStart, nEnd;
         int nNewStart, nNewEnd;
         FunctionalLookupTableFlags uFlags;

         uFlags = FunctionalLookupTableFlags.Linear;
         if (_interactiveHistogramData.signed)
            uFlags |= FunctionalLookupTableFlags.Signed;

         SetDataValues(ref _interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].LUTRescale);

         nStart = _interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].rescale.startLine.position;
         if (nStart < 0)
            nStart += _interactiveHistogramData.histogramLabel.histogramLength;

         nEnd = _interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].rescale.endLine.position;
         if (nEnd < 0)
            nEnd += _interactiveHistogramData.histogramLabel.histogramLength;

         nNewStart = _interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].rescale.newStartLine.position;
         if (nNewStart < 0)
            nNewStart += _interactiveHistogramData.histogramLabel.histogramLength;

         nNewEnd = _interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].rescale.newEndLine.position;
         if (nNewEnd < 0)
            nNewEnd += _interactiveHistogramData.histogramLabel.histogramLength;

         _interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].LUTRescale[nStart] = _interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].LUTRescale[nNewStart];
         _interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].LUTRescale[nEnd] = _interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].LUTRescale[nNewEnd];

         EffectsUtilities.GetFunctionalLookupTable(_interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].LUTRescale,
                                                   GetStart(),
                                                   GetEnd(),
                                                   0,
                                                   uFlags);
         return 1;
      }

      private int ApplyResaleMaster()
      {
         int nRet;

         if (_interactiveHistogramData.shift)
            nRet = GetLUTResShift();
         else
            nRet = GetLUTResNewSE();

         // Apply the Red Channel...
         bool useLUT = applyImage.UseLookupTable;
         applyImage.UseLookupTable = false;

         if (!applyImage.UseLookupTable && (applyImage.BitsPerPixel == 12 || applyImage.BitsPerPixel == 16))
         {
            PrepareRemapIntensity(_interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].LUTRescale, _interactiveHistogramData.histogramLabel.histogramLength, RasterColorChannel.Red);
         }
         else
         {
            RemapIntensityCommand cmd = new RemapIntensityCommand();
            cmd.LookupTable = new int[_interactiveHistogramData.histogramLabel.histogramLength];
            Array.Copy(_interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].LUTRescale, cmd.LookupTable, _interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].LUTRescale.Length);
            cmd.Flags = RemapIntensityCommandFlags.Red;
            cmd.Progress += new EventHandler<RasterCommandProgressEventArgs>(cmd_Progress);
            cmd.Run(applyImage);
         }
         applyImage.UseLookupTable = useLUT;

         // Apply the Green Channel...
         useLUT = applyImage.UseLookupTable;
         applyImage.UseLookupTable = false;

         if (!applyImage.UseLookupTable && (applyImage.BitsPerPixel == 12 || applyImage.BitsPerPixel == 16))
         {
            PrepareRemapIntensity(_interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].LUTRescale, _interactiveHistogramData.histogramLabel.histogramLength, RasterColorChannel.Green);
         }
         else
         {
            RemapIntensityCommand cmd = new RemapIntensityCommand();
            cmd.LookupTable = new int[_interactiveHistogramData.histogramLabel.histogramLength];
            Array.Copy(_interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].LUTRescale, cmd.LookupTable, _interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].LUTRescale.Length);
            cmd.Flags = RemapIntensityCommandFlags.Green;
            cmd.Progress += new EventHandler<RasterCommandProgressEventArgs>(cmd_Progress);
            cmd.Run(applyImage);
         }
         applyImage.UseLookupTable = useLUT;

         // Apply the Blue Channel...
         useLUT = applyImage.UseLookupTable;
         applyImage.UseLookupTable = false;

         if (!applyImage.UseLookupTable && (applyImage.BitsPerPixel == 12 || applyImage.BitsPerPixel == 16))
         {
            PrepareRemapIntensity(_interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].LUTRescale, _interactiveHistogramData.histogramLabel.histogramLength, RasterColorChannel.Blue);
         }
         else
         {
            RemapIntensityCommand cmd = new RemapIntensityCommand();
            cmd.LookupTable = new int[_interactiveHistogramData.histogramLabel.histogramLength];
            Array.Copy(_interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].LUTRescale, cmd.LookupTable, _interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].LUTRescale.Length);
            cmd.Flags = RemapIntensityCommandFlags.Blue;
            cmd.Progress += new EventHandler<RasterCommandProgressEventArgs>(cmd_Progress);
            cmd.Run(applyImage);
         }
         applyImage.UseLookupTable = useLUT;

         return 1;
      }

      private int GetLUTRescaling()
      {
         int nRet;

         _interactiveHistogramData.grayLUT = true;
         applyImage = _interactiveHistogramData.originalImage.CloneAll();

         if (ChildImage.UseLookupTable)
            applyImage.SetLookupTable(_interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].RGBPrevLUT);

         if ((applyImage.GrayscaleMode == RasterGrayscaleMode.None) && _interactiveHistogramData.channel == RasterColorChannel.Master && !_interactiveHistogramData.signed)
         {
            if (_interactiveHistogramData.applyInProgress[_tabOptions.SelectedIndex])
            {
               nRet = ApplyResaleMaster();
            }
         }
         else
         {
            if (_interactiveHistogramData.shift)
               nRet = GetLUTResShift();
            else
               nRet = GetLUTResNewSE();

            bool useLUT = applyImage.UseLookupTable;
            applyImage.UseLookupTable = false;

            if (_interactiveHistogramData.applyInProgress[_tabOptions.SelectedIndex])
            {
               RemapIntensityCommand cmd = new RemapIntensityCommand();
               cmd.LookupTable = new int[_interactiveHistogramData.histogramLabel.histogramLength];
               Array.Copy(_interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].LUTRescale, cmd.LookupTable, _interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].LUTRescale.Length);
               cmd.Flags = (RemapIntensityCommandFlags) _interactiveHistogramData.channel | RemapIntensityCommandFlags.Normal;
               cmd.Progress += new EventHandler<RasterCommandProgressEventArgs>(cmd_Progress);
               cmd.Run(applyImage);
            }
            applyImage.UseLookupTable = useLUT;
         }

         FreeImage(ChildImage);
         ChildImage = applyImage.CloneAll();
         return 1;
      }

      private void _lblHistogram_Paint(object sender, PaintEventArgs e)
      {
         Pen inRangePen, outRangePen;
         int divideBy;
         int startLoop, endLoop;
         int penWidth = Math.Max(1, (_lblHistogram.Width - 49) / _interactiveHistogramData.histogramLabel.drawLength);

         inRangePen = new Pen(_interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].innerColor, penWidth);
         outRangePen = new Pen(_interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].outerColor, penWidth);

         // Fill the background of the label with white brush...
         e.Graphics.FillRectangle(Brushes.White, 0, 0, _lblHistogram.Width, _lblHistogram.Height);

         // Set the values to label that holds the statistical information...
         SetLabelsValues();

         // Draw the histogram graph...
         divideBy = (_interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].maxHistogramValue == 0) ? 1 : _interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].maxHistogramValue;

         startLoop = _interactiveHistogramData.histogramLabel.drawStartRange;
         endLoop = _interactiveHistogramData.histogramLabel.drawEndRange;
         DrawHistogram(e.Graphics, outRangePen, penWidth, divideBy, _interactiveHistogramData.histogramLabel.drawHistogram, 0, startLoop, endLoop + 1, true);

         if (_tabOptions.SelectedIndex != 3)
         {
            if (_interactiveHistogramData.fullView)
            {
               startLoop = Math.Max(_interactiveHistogramData.histogramLabel.drawStartRange, GetStart());
               endLoop = Math.Min(_interactiveHistogramData.histogramLabel.drawEndRange, GetEnd());
            }
            else
            {
               startLoop = Math.Max(_interactiveHistogramData.histogramLabel.drawStartRange, GetRealVal(GetStart()));
               endLoop = Math.Min(_interactiveHistogramData.histogramLabel.drawEndRange, GetRealVal(GetEnd()));
            }
            DrawHistogram(e.Graphics, inRangePen, penWidth, divideBy, _interactiveHistogramData.histogramLabel.drawHistogram, startLoop - _interactiveHistogramData.histogramLabel.drawStartRange, startLoop, endLoop + 1, true);
         }
         else
         {
            // Draw the selected area between the start and end points...
            if (_interactiveHistogramData.fullView)
            {
               startLoop = Math.Max(_interactiveHistogramData.histogramLabel.drawStartRange, GetStart());
               endLoop = Math.Min(_interactiveHistogramData.histogramLabel.drawEndRange, GetEnd());
            }
            else
            {
               startLoop = Math.Max(_interactiveHistogramData.histogramLabel.drawStartRange, GetRealVal(GetStart()));
               endLoop = Math.Min(_interactiveHistogramData.histogramLabel.drawEndRange, GetRealVal(GetEnd()));
            }

            DrawHistogram(e.Graphics, inRangePen, penWidth, divideBy, _interactiveHistogramData.histogramLabel.drawHistogram, startLoop - _interactiveHistogramData.histogramLabel.drawStartRange, startLoop, endLoop + 1, true);

            if (!_interactiveHistogramData.shift)
            {
               // Draw the selected area between the new start and end points...
               if (_interactiveHistogramData.fullView)
               {
                  startLoop = Math.Max(_interactiveHistogramData.histogramLabel.drawStartRange, _interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].rescale.newStartLine.position);
                  endLoop = Math.Min(_interactiveHistogramData.histogramLabel.drawEndRange, _interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].rescale.newEndLine.position);
               }
               else
               {
                  startLoop = Math.Max(_interactiveHistogramData.histogramLabel.drawStartRange, GetRealVal(_interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].rescale.newStartLine.position));
                  endLoop = Math.Min(_interactiveHistogramData.histogramLabel.drawEndRange, GetRealVal(_interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].rescale.newEndLine.position));
               }
               DrawHistogram(e.Graphics, inRangePen, penWidth, divideBy, _interactiveHistogramData.histogramLabel.drawHistogram, startLoop - _interactiveHistogramData.histogramLabel.drawStartRange, startLoop, endLoop + 1, true);
            }
         }

         // Draw the X amd Y axis and draw the start and end ranges marks and texts.
         DrawAxisAndRanges(e.Graphics, penWidth);
      }

      private void DrawChanges()
      {
         _mainForm.ActiveViewerForm.Viewer.Invalidate();
         _lblHistogram.Invalidate();
      }

      private void SetEditStart(int value)
      {
         switch (_tabOptions.SelectedIndex)
         {
            case 0: _nudSegStartPt.Value   = value; break;
            case 1: _nudGrayStartPt.Value  = value; break;
            case 2: _nudNoiseStartPt.Value = value; break;
            case 3: _nudResStartPt.Value   = value; break;
         }
      }

      private void SetEditEnd(int value)
      {
         switch (_tabOptions.SelectedIndex)
         {
            case 0: _nudSegEndPt.Value   = value; break;
            case 1: _nudGrayEndPt.Value  = value; break;
            case 2: _nudNoiseEndPt.Value = value; break;
            case 3: _nudResEndPt.Value   = value; break;
         }
      }

      private int GetEditStart()
      {
         switch (_tabOptions.SelectedIndex)
         {
            case 0: return (int) _nudSegStartPt.Value  ;
            case 1: return (int) _nudGrayStartPt.Value ;
            case 2: return (int) _nudNoiseStartPt.Value;
            case 3: return (int) _nudResStartPt.Value  ;
         }
         return 0;
      }

      private int GetEditEnd()
      {
         switch (_tabOptions.SelectedIndex)
         {
            case 0: return (int) _nudSegEndPt.Value  ;
            case 1: return (int) _nudGrayEndPt.Value ;
            case 2: return (int) _nudNoiseEndPt.Value;
            case 3: return (int) _nudResEndPt.Value  ;
         }
         return 0;
      }

      private int GetNormalDrawFromSigned(int value)
      {
         return (value + ((_interactiveHistogramData.signed) ? GetRealVal(Math.Abs(_interactiveHistogramData.histogramLabel.startRange)) : 0));
      }

      private int GetNormalFromSigned(int value)
      {
         return (value + ((_interactiveHistogramData.signed) ? Math.Abs(_interactiveHistogramData.histogramLabel.startRange) : 0));
      }

      private int GetSignedFromNormal(int value)
      {
         return (value - ((_interactiveHistogramData.signed) ? Math.Abs(_interactiveHistogramData.histogramLabel.startRange) : 0));
      }

      private void ShowHideOptions()
      {
         this.Height = (_interactiveHistogramData.pushed) ? this.Height + _interactiveHistogramData.distance : this.Height - _interactiveHistogramData.distance;
         _btnOk.Top = (_interactiveHistogramData.pushed) ? _btnOk.Top + _interactiveHistogramData.distance : _btnOk.Top - _interactiveHistogramData.distance;
         _btnUndo.Top = (_interactiveHistogramData.pushed) ? _btnUndo.Top + _interactiveHistogramData.distance : _btnUndo.Top - _interactiveHistogramData.distance;
         _btnCancel.Top = (_interactiveHistogramData.pushed) ? _btnCancel.Top + _interactiveHistogramData.distance : _btnCancel.Top - _interactiveHistogramData.distance;
         _MainProgressBar.Top = (_interactiveHistogramData.pushed) ? _MainProgressBar.Top + _interactiveHistogramData.distance : _MainProgressBar.Top - _interactiveHistogramData.distance;
         _grpView.Height = (_interactiveHistogramData.pushed) ? _grpView.Height + _interactiveHistogramData.distance : _grpView.Height - _interactiveHistogramData.distance;

         _tabOptions.Visible = _interactiveHistogramData.pushed;
         _grpStatisticalInformation.Visible = _interactiveHistogramData.pushed;

         _btnShowHideOptions.Text = (_interactiveHistogramData.pushed) ? "Hide Options <<" : "Show Options >>";
      }

      private Color GetColorFromEdit(int value)
      {
         value = (int)((value * 255.0) / _interactiveHistogramData.histogramLabel.histogramLength);

         switch ((int)_interactiveHistogramData.channel)
         {
            case 0: return Color.FromArgb(value, value, value);
            case 1: return Color.FromArgb(value, 0, 0);
            case 2: return Color.FromArgb(0, value, 0);
            case 3: return Color.FromArgb(0, 0, value);
         }
         return Color.Empty;
      }

      private void SetLabelsColor()
      {
         switch (_tabOptions.SelectedIndex)
         {
            case 0:
               _lblSegStartPtClr.BackColor = GetColorFromEdit(GetStart() + ((_interactiveHistogramData.signed) ? Math.Abs(_interactiveHistogramData.histogramLabel.startRange) : 0));
               _lblSegEndPtClr.BackColor = GetColorFromEdit(GetEnd() + ((_interactiveHistogramData.signed) ? Math.Abs(_interactiveHistogramData.histogramLabel.startRange) : 0));
               break;
            case 1:
               _lblGrayStartPtClr.BackColor = GetColorFromEdit(GetStart() + ((_interactiveHistogramData.signed) ? Math.Abs(_interactiveHistogramData.histogramLabel.startRange) : 0));
               _lblGrayEndPtClr.BackColor = GetColorFromEdit(GetEnd() + ((_interactiveHistogramData.signed) ? Math.Abs(_interactiveHistogramData.histogramLabel.startRange) : 0));
               break;
            case 2:
               _lblNoiseStartPtClr.BackColor = GetColorFromEdit(GetStart() + ((_interactiveHistogramData.signed) ? Math.Abs(_interactiveHistogramData.histogramLabel.startRange) : 0));
               _lblNoiseEndPtClr.BackColor = GetColorFromEdit(GetEnd() + ((_interactiveHistogramData.signed) ? Math.Abs(_interactiveHistogramData.histogramLabel.startRange) : 0));
               break;
            case 3:
               _lblResStartPtClr.BackColor = GetColorFromEdit(GetStart() + ((_interactiveHistogramData.signed) ? Math.Abs(_interactiveHistogramData.histogramLabel.startRange) : 0));
               _lblResEndPtClr.BackColor = GetColorFromEdit(GetEnd() + ((_interactiveHistogramData.signed) ? Math.Abs(_interactiveHistogramData.histogramLabel.startRange) : 0));
               break;
         }
      }

      private void _lblHistogram_MouseMove(object sender, MouseEventArgs e)
      {
         int nTempInt;
         int nTempX, nTempY;
         int nTemp, nOrgTempX;

         if (_interactiveHistogramData.histogramLabel.zoomed)
            return;

         nTemp = _lblHistogram.Width - 25 - 25;
         nTemp /= (_interactiveHistogramData.histogramLabel.drawEndRange - _interactiveHistogramData.histogramLabel.drawStartRange);
         nTemp = Math.Max(nTemp, 1);
         nTempX = (e.X - 23);
         nTempX /= nTemp;

         nTempX += _interactiveHistogramData.histogramLabel.drawStartRange;
         nTempY = e.Y;

         nOrgTempX = nTempX;
         if (!(_interactiveHistogramData.fullView && !_interactiveHistogramData.histogramLabel.zoomed))
            nTempX = SetRealVal_MouseMove(nTempX);

         // Set the proper mouse cursor...
         this.Cursor = Cursors.Arrow;
         if (_interactiveHistogramData.histogramLabel.moveType == MovePoint.None)
         {
            if ((IsMouseOverPt(GetRealVal(GetStart()), _interactiveHistogramData.histogramLabel.paint.Height, nOrgTempX, nTempY) ||
               (IsMouseOverPt(GetRealVal(GetEnd()), _interactiveHistogramData.histogramLabel.paint.Height, nOrgTempX, nTempY))))
               this.Cursor = Cursors.SizeWE;
            else if (_tabOptions.SelectedIndex == 3 && !_interactiveHistogramData.shift)
            {
               if (IsMouseOverPt(GetRealVal(_interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].rescale.newStartLine.position), _interactiveHistogramData.histogramLabel.paint.Height, nOrgTempX, nTempY) ||
                  IsMouseOverPt(GetRealVal(_interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].rescale.newEndLine.position), _interactiveHistogramData.histogramLabel.paint.Height, nOrgTempX, nTempY))
                  this.Cursor = Cursors.SizeWE;
            }
         }
         else if (_interactiveHistogramData.histogramLabel.moveType == MovePoint.Start ||
                 _interactiveHistogramData.histogramLabel.moveType == MovePoint.End ||
                 _interactiveHistogramData.histogramLabel.moveType == MovePoint.NewStart ||
                 _interactiveHistogramData.histogramLabel.moveType == MovePoint.NewEnd)
            this.Cursor = Cursors.SizeWE;

         if (nTempX < _interactiveHistogramData.histogramLabel.startRange || nTempX > _interactiveHistogramData.histogramLabel.endRange)
            _interactiveHistogramData.histogramLabel.moveType = MovePoint.None;

         switch (_interactiveHistogramData.histogramLabel.moveType)
         {
            case MovePoint.None:
               if (nTempX >= _interactiveHistogramData.histogramLabel.startRange &&
                  nTempX <= (int)_interactiveHistogramData.histogramLabel.endRange)
               {
                  _interactiveHistogramData.histogramLabel.mousePosition = nTempX + ((_interactiveHistogramData.signed) ? Math.Abs(_interactiveHistogramData.histogramLabel.startRange) : 0); ;

                  // Set the mouse position statistical information...
                  int convert = (int)(nTempX * 10000.0 / _interactiveHistogramData.histogramLabel.histogramLength);
                  _lblMousePercent.Text = (convert / 100.0).ToString();
                  _lblMouseLevel.Text = nTempX.ToString();
                  _lblMouseCount.Text = (_interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].orginalHistogram[_interactiveHistogramData.histogramLabel.mousePosition]).ToString();
               }
               break;

            case MovePoint.Start:
               nTempInt = GetEnd();

               if (nTempX >= nTempInt)
                  SetEditStart(nTempInt - 1);
               else if (nTempX >= _interactiveHistogramData.histogramLabel.startRange && nTempX < (int)_interactiveHistogramData.histogramLabel.endRange)
                  SetEditStart(nTempX);
               else
                  SetEditStart(_interactiveHistogramData.histogramLabel.startRange);
               break;

            case MovePoint.End:
               nTempInt = GetStart();

               if (nTempX <= nTempInt)
                  SetEditEnd(nTempInt + 1);
               else if (nTempX >= _interactiveHistogramData.histogramLabel.startRange && nTempX < (int)_interactiveHistogramData.histogramLabel.endRange)
                  SetEditEnd(nTempX);
               else
                  SetEditEnd(_interactiveHistogramData.histogramLabel.endRange);
               break;

            case MovePoint.NewStart:
               if (nTempX < _interactiveHistogramData.histogramLabel.startRange)
               _nudResNewStart.Value = _interactiveHistogramData.histogramLabel.startRange;
               else if (nTempX >= _interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].rescale.newEndLine.position)
               _nudResNewStart.Value = _interactiveHistogramData.cD[(int) _interactiveHistogramData.channel].rescale.newEndLine.position - 1;
               else
               _nudResNewStart.Value = nTempX;
               break;

            case MovePoint.NewEnd:
               if ((int)nTempX <= _interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].rescale.newStartLine.position)
               _nudResNewEnd.Value = _interactiveHistogramData.cD[(int) _interactiveHistogramData.channel].rescale.newStartLine.position + 1;
               else if (nTempX >= _interactiveHistogramData.histogramLabel.endRange - 1)
               _nudResNewEnd.Value = _interactiveHistogramData.histogramLabel.endRange - 1;
               else
               _nudResNewEnd.Value = nTempX;
               break;
         }
      }

      private void _lblHistogram_MouseDown(object sender, MouseEventArgs e)
      {
         if (e.Button == MouseButtons.Left)
         {
            int nTempX, nTempY;
            int nTemp, nOrgTempX;

            _lblHistogram.Capture = true;
            if (!(!_interactiveHistogramData.fullView && !_interactiveHistogramData.histogramLabel.zoomed))
               return;

            nTemp = _lblHistogram.Width - 25 - 25;
            nTemp /= (_interactiveHistogramData.histogramLabel.drawEndRange - _interactiveHistogramData.histogramLabel.drawStartRange);
            nTemp = Math.Max(nTemp, 1);
            nTempX = (e.X - 23);
            nTempX /= nTemp;

            nTempX += _interactiveHistogramData.histogramLabel.drawStartRange;
            nTempX = Math.Max((int)GetNormalFromSigned(_interactiveHistogramData.histogramLabel.startRange),
                         Math.Min(nTempX, (int)GetNormalFromSigned(_interactiveHistogramData.histogramLabel.endRange)));
            nTempY = e.Y;

            nOrgTempX = nTempX;
            nTempX = SetRealVal(nTempX);

            _interactiveHistogramData.histogramLabel.moveType = MovePoint.None;

            // Set the proper mouse cursor...
            if (_interactiveHistogramData.histogramLabel.moveType == MovePoint.None)
            {
               if ((IsMouseOverPt(GetRealVal(GetStart()), _interactiveHistogramData.histogramLabel.paint.Height, nOrgTempX, nTempY) ||
                  (IsMouseOverPt(GetRealVal(GetEnd()), _interactiveHistogramData.histogramLabel.paint.Height, nOrgTempX, nTempY))))
                  this.Cursor = Cursors.SizeWE;
               else if (_tabOptions.SelectedIndex == 3 && !_interactiveHistogramData.shift)
               {
                  if (IsMouseOverPt(GetRealVal(_interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].rescale.newStartLine.position), _interactiveHistogramData.histogramLabel.paint.Height, nOrgTempX, nTempY) ||
                     IsMouseOverPt(GetRealVal(_interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].rescale.newEndLine.position), _interactiveHistogramData.histogramLabel.paint.Height, nOrgTempX, nTempY))
                     this.Cursor = Cursors.SizeWE;
               }
               else
                  this.Cursor = Cursors.Arrow;
            }
            else if (_interactiveHistogramData.histogramLabel.moveType == MovePoint.Start ||
                     _interactiveHistogramData.histogramLabel.moveType == MovePoint.End ||
                     _interactiveHistogramData.histogramLabel.moveType == MovePoint.NewStart ||
                     _interactiveHistogramData.histogramLabel.moveType == MovePoint.NewEnd)
               this.Cursor = Cursors.SizeWE;

            if (_tabOptions.SelectedIndex == 3 && !_interactiveHistogramData.shift)
            {
               if (IsMouseOverPt(GetRealVal(_interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].rescale.newStartLine.position), _interactiveHistogramData.histogramLabel.paint.Height, nOrgTempX, nTempY))
               {
                  _interactiveHistogramData.histogramLabel.moveType = MovePoint.NewStart;
               }
               else if (IsMouseOverPt(GetRealVal(_interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].rescale.newEndLine.position), _interactiveHistogramData.histogramLabel.paint.Height, nOrgTempX, nTempY))
               {
                  _interactiveHistogramData.histogramLabel.moveType = MovePoint.NewEnd;
               }
            }
            if (IsMouseOverPt(GetRealVal(GetStart()), _interactiveHistogramData.histogramLabel.paint.Height, nOrgTempX, nTempY))
            {
               if (GetRealVal(GetEnd()) - GetRealVal(GetStart()) > 10)
                  _interactiveHistogramData.histogramLabel.moveType = MovePoint.Start;
               else
                  _interactiveHistogramData.histogramLabel.moveType = MovePoint.End;
            }
            else if (IsMouseOverPt(GetRealVal(GetEnd()), _interactiveHistogramData.histogramLabel.paint.Height, nOrgTempX, nTempY))
               _interactiveHistogramData.histogramLabel.moveType = MovePoint.End;

            if (nTempX > _interactiveHistogramData.histogramLabel.endRange)
               SetEnd(_interactiveHistogramData.histogramLabel.endRange);
         }
      }

      private void _lblHistogram_MouseUp(object sender, MouseEventArgs e)
      {
         if (e.Button == MouseButtons.Left)
         {
            int nTempX, nTempY;
            int nTemp, nOrgTempX;

            _lblHistogram.Capture = false;

            nTemp = _lblHistogram.Width - 25 - 25;
            nTemp /= (_interactiveHistogramData.histogramLabel.drawEndRange - _interactiveHistogramData.histogramLabel.drawStartRange);
            nTemp = Math.Max(nTemp, 1);
            nTempX = (e.X - 23);
            nTempX /= nTemp;

            nTempX += _interactiveHistogramData.histogramLabel.drawStartRange;
            nTempX = Math.Max((int)_interactiveHistogramData.histogramLabel.drawStartRange, Math.Min(nTempX, (int)_interactiveHistogramData.histogramLabel.drawEndRange));
            nTempY = e.Y;

            nOrgTempX = nTempX;
            nTempX = SetRealVal(nTempX);

            if (_interactiveHistogramData.fullView && nOrgTempX >= _interactiveHistogramData.histogramLabel.drawStartRange && nOrgTempX <= _interactiveHistogramData.histogramLabel.drawEndRange)
            {
               if ((Control.ModifierKeys & Keys.Shift) == Keys.Shift)
               {
                  nTemp = GetStart();
                  if (nOrgTempX > nTemp + 1)
                     SetEditEnd(nOrgTempX);
                  else
                     SetEditEnd(nTemp + 1);
               }
               else
               {
                  nTemp = GetEnd();
                  if (nOrgTempX < nTemp - 1)
                     SetEditStart(nOrgTempX);
                  else
                     SetEditStart(nTemp - 1);
               }
            }

            _interactiveHistogramData.histogramLabel.moveType = MovePoint.None;
         }
      }

      private void EnableGrayControls()
      {
         _lblGrayFunctionType.Enabled = !_interactiveHistogramData.grayPredefinedPalette;
         _cbGrayFunctionType.Enabled = !_interactiveHistogramData.grayPredefinedPalette;
         _lblGrayCenter.Enabled = !_interactiveHistogramData.grayPredefinedPalette;
         _txtGrayCenter.Enabled = !_interactiveHistogramData.grayPredefinedPalette;
         _lblGrayWidth.Enabled = !_interactiveHistogramData.grayPredefinedPalette;
         _txtGrayWidth.Enabled = !_interactiveHistogramData.grayPredefinedPalette;
         _cbGraySelectionOnly.Enabled = !_interactiveHistogramData.grayPredefinedPalette;
         _btnGrayStartColor.Enabled = !_interactiveHistogramData.grayPredefinedPalette;
         _lblGrayStartColor.Enabled = !_interactiveHistogramData.grayPredefinedPalette;
         _btnGrayEndColor.Enabled = !_interactiveHistogramData.grayPredefinedPalette;
         _lblGrayEndColor.Enabled = !_interactiveHistogramData.grayPredefinedPalette;

         if (_cbGrayFunctionType.SelectedIndex != 2)
         {
            _lblGrayFactor.Enabled = !_interactiveHistogramData.grayPredefinedPalette;
            _nudGrayFactor.Enabled = !_interactiveHistogramData.grayPredefinedPalette;
         }
      }

      private void FitHistogram()
      {
         PrepareCompressedHisto();

         _interactiveHistogramData.histogramLabel.drawLength = 256;
         _interactiveHistogramData.histogramLabel.drawStartRange = 0;
         _interactiveHistogramData.histogramLabel.drawEndRange = 255;
         _interactiveHistogramData.fullView = false;

         _interactiveHistogramData.histogramLabel.startRange = 0;
         _interactiveHistogramData.histogramLabel.endRange = _interactiveHistogramData.histogramLabel.histogramLength - 1;

         if (_interactiveHistogramData.signed)
         {
            _interactiveHistogramData.histogramLabel.startRange -= _interactiveHistogramData.histogramLabel.histogramLength / 2;
            _interactiveHistogramData.histogramLabel.endRange -= _interactiveHistogramData.histogramLabel.histogramLength / 2;
         }

         _hsRange.Value = _interactiveHistogramData.histogramLabel.startRange;
         _hsRange.Enabled = false;
         _hsRange.Visible = (_interactiveHistogramData.histogramLabel.histogramLength != 256);

         _lblHelp.Visible = false;

         _interactiveHistogramData.histogramLabel.zoomed = false;

         _lblHistogram.Invalidate();
      }

      private void EnableRescaleOptions(bool enableShift)
      {
         // Enable New Start and End Options...
         _lblResNewStart.Enabled = !enableShift;
         _nudResNewStart.Enabled = !enableShift;

         _lblResNewEnd.Enabled = !enableShift;
         _nudResNewEnd.Enabled = !enableShift;

         // Enable Shift Options...
         _lblResShiftAmount.Enabled = enableShift;
         _nudResShiftAmount.Enabled = enableShift;
         _rbResShiftLeft.Enabled = enableShift;
         _rbResShiftRight.Enabled = enableShift;
         _interactiveHistogramData.shift = enableShift;
      }

      private void _cbChannel_SelectedIndexChanged(object sender, EventArgs e)
      {
         if ((int)_interactiveHistogramData.channel != _cbChannel.SelectedIndex)
         {
            _interactiveHistogramData.channel = (RasterColorChannel)_cbChannel.SelectedIndex;
            int length = _interactiveHistogramData.histogramLabel.histogramLength;
            switch (_tabOptions.SelectedIndex)
            {
               case 0:
                  _nudSegStartPt.Minimum = _interactiveHistogramData.histogramLabel.startRange;
                  _nudSegStartPt.Maximum = _interactiveHistogramData.histogramLabel.endRange;
                  _nudSegEndPt.Minimum = _interactiveHistogramData.histogramLabel.startRange;
                  _nudSegEndPt.Maximum = _interactiveHistogramData.histogramLabel.endRange;
                  break;

               case 1:
                  _nudGrayStartPt.Minimum = _interactiveHistogramData.histogramLabel.startRange;
                  _nudGrayStartPt.Maximum = _interactiveHistogramData.histogramLabel.endRange;
                  _nudGrayEndPt.Minimum = _interactiveHistogramData.histogramLabel.startRange;
                  _nudGrayEndPt.Maximum = _interactiveHistogramData.histogramLabel.endRange;
                  break;

               case 2:
                  _nudNoiseStartPt.Minimum = _interactiveHistogramData.histogramLabel.startRange;
                  _nudNoiseStartPt.Maximum = _interactiveHistogramData.histogramLabel.endRange;
                  _nudNoiseEndPt.Minimum = _interactiveHistogramData.histogramLabel.startRange;
                  _nudNoiseEndPt.Maximum = _interactiveHistogramData.histogramLabel.endRange;
                  break;

               case 3:
                  _nudResStartPt.Minimum = _interactiveHistogramData.histogramLabel.startRange;
                  _nudResStartPt.Maximum = _interactiveHistogramData.histogramLabel.endRange;
                  _nudResEndPt.Minimum = _interactiveHistogramData.histogramLabel.startRange;
                  _nudResEndPt.Maximum = _interactiveHistogramData.histogramLabel.endRange;
                  _nudResNewStart.Minimum = _interactiveHistogramData.histogramLabel.startRange;
                  _nudResNewStart.Maximum = _interactiveHistogramData.histogramLabel.endRange;
                  _nudResNewEnd.Minimum = _interactiveHistogramData.histogramLabel.startRange;
                  _nudResNewEnd.Maximum = _interactiveHistogramData.histogramLabel.endRange;
                  break;
            }

            SetEditStart(GetStart());
            SetEditEnd(GetEnd());
            if (_interactiveHistogramData.fullView || _interactiveHistogramData.histogramLabel.zoomed)
            {
               FitHistogram();
            }

            SetLabelsColor();

            _interactiveHistogramData.getHistogram = true;
            ApplyFilter();
            DrawChanges();
            _lblHistogram.Invalidate();
            _lblInner.BackColor = _interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].innerColor;
            _lblOuter.BackColor = _interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].outerColor;
         }
      }

      private void _btnInner_Click(object sender, EventArgs e)
      {
         ColorDialog colorDlg = new ColorDialog();

         colorDlg.Color = _interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].innerColor;
         if (colorDlg.ShowDialog() == DialogResult.OK)
         {
            _lblInner.BackColor = colorDlg.Color;
            _interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].innerColor = colorDlg.Color;
            _lblHistogram.Invalidate();
         }
      }

      private void _btnOuter_Click(object sender, EventArgs e)
      {
         ColorDialog colorDlg = new ColorDialog();

         colorDlg.Color = _interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].outerColor;
         if (colorDlg.ShowDialog() == DialogResult.OK)
         {
            _lblOuter.BackColor = colorDlg.Color;
            _interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].outerColor = colorDlg.Color;
            _lblHistogram.Invalidate();
         }
      }

      private void _cbSelectionType_SelectedIndexChanged(object sender, EventArgs e)
      {
         SetStatisticalValue();
      }

      private void _btnShowHideOptions_Click(object sender, EventArgs e)
      {
         _interactiveHistogramData.pushed = !_interactiveHistogramData.pushed;
         ShowHideOptions();
      }

      private void _nudStartPt_ValueChanged(object sender, EventArgs e)
      {
         if (!_doApply)
            return;

         int nTemp;

         nTemp = GetEditStart();
         if (nTemp != GetStart())
         {
            SetStart(nTemp);

            if (sender == _nudSegStartPt)
            {
               _lblSegStartPtOccVal.Text = (_interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].orginalHistogram[GetStart() + ((_interactiveHistogramData.signed) ? Math.Abs(_interactiveHistogramData.histogramLabel.startRange) : 0)]).ToString();
               _nudSegEndPt.Minimum = GetStart() + 1;
            }
            else if (sender == _nudGrayStartPt)
            {
               _lblGryStartPtOccVal.Text = (_interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].orginalHistogram[GetStart() + ((_interactiveHistogramData.signed) ? Math.Abs(_interactiveHistogramData.histogramLabel.startRange) : 0)]).ToString();
               _nudGrayEndPt.Minimum = GetStart() + 1;
            }
            else if (sender == _nudNoiseStartPt)
            {
               _lblNoiseStartPtOccVal.Text = (_interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].orginalHistogram[GetStart() + ((_interactiveHistogramData.signed) ? Math.Abs(_interactiveHistogramData.histogramLabel.startRange) : 0)]).ToString();
               _nudNoiseEndPt.Minimum = GetStart() + 1;
            }
            else if (sender == _nudResStartPt)
            {
               _lblResStartPtOccVal.Text = (_interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].orginalHistogram[GetStart() + ((_interactiveHistogramData.signed) ? Math.Abs(_interactiveHistogramData.histogramLabel.startRange) : 0)]).ToString();
               _nudResEndPt.Minimum = GetStart() + 1;
            }

            if (_cbSelectionType.SelectedIndex == 1 || _cbSelectionType.SelectedIndex == 2)
               SetStatisticalValue();

            if (sender == _nudGrayStartPt)
            {
               _txtGrayWidth.Text = (GetEnd() - GetStart()).ToString();
               _txtGrayCenter.Text = (((Math.Abs(GetEnd()) - Math.Abs(GetStart())) / 2) + GetStart()).ToString();
            }

            ApplyFilter();
            DrawChanges();
            SetLabelsColor();
         }
      }

      private void _nudEndPt_ValueChanged(object sender, EventArgs e)
      {
         if (!_doApply)
            return;

         int nTemp = GetEditEnd();
         if (nTemp != GetEnd())
         {
            SetEnd(nTemp);

            if (sender == _nudSegEndPt)
            {
               _lblSegEndPtOccVal.Text = (_interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].orginalHistogram[GetEnd()   + ((_interactiveHistogramData.signed) ? Math.Abs(_interactiveHistogramData.histogramLabel.startRange) : 0)]).ToString();
               _nudSegStartPt.Maximum = GetEnd() - 1;
            }
            else if (sender == _nudGrayEndPt)
            {
               _lblGryEndPtOccVal.Text = (_interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].orginalHistogram[GetEnd()   + ((_interactiveHistogramData.signed) ? Math.Abs(_interactiveHistogramData.histogramLabel.startRange) : 0)]).ToString();
               _nudGrayStartPt.Maximum = GetEnd() - 1;
            }
            else if (sender == _nudNoiseEndPt)
            {
               _lblNoiseEndPtOccVal.Text = (_interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].orginalHistogram[GetEnd() + ((_interactiveHistogramData.signed) ? Math.Abs(_interactiveHistogramData.histogramLabel.startRange) : 0)]).ToString();
               _nudNoiseStartPt.Maximum = GetEnd() - 1;
            }
            else if (sender == _nudResEndPt)
            {
               _lblResEndPtOccVal.Text = (_interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].orginalHistogram[GetEnd()   + ((_interactiveHistogramData.signed) ? Math.Abs(_interactiveHistogramData.histogramLabel.startRange) : 0)]).ToString();
               _nudResStartPt.Maximum = GetEnd() - 1;
            }

            if (_cbSelectionType.SelectedIndex == 1 || _cbSelectionType.SelectedIndex == 3)
               SetStatisticalValue();

            if (sender == _nudGrayStartPt)
            {
               _txtGrayWidth.Text = (GetEnd() - GetStart()).ToString();
               _txtGrayCenter.Text = (((Math.Abs(GetEnd()) - Math.Abs(GetStart())) / 2) + GetStart()).ToString();
            }

            ApplyFilter();
            DrawChanges();

            SetLabelsColor();
         }
      }

      private void _btnSegStartColor_Click(object sender, EventArgs e)
      {
         ColorDialog colorDlg = new ColorDialog();

         colorDlg.Color = GetColorFromRasterColor(_interactiveHistogramData.segmentStartColor);
         if (colorDlg.ShowDialog() == DialogResult.OK)
         {
            _lblSegStartColor.BackColor = colorDlg.Color;
            _interactiveHistogramData.segmentStartColor = Leadtools.Demos.Converters.FromGdiPlusColor(colorDlg.Color);
            ApplyFilter();
            DrawChanges();
         }
      }

      private void _btnSegEndColor_Click(object sender, EventArgs e)
      {
         ColorDialog colorDlg = new ColorDialog();

         colorDlg.Color = GetColorFromRasterColor(_interactiveHistogramData.segmentEndColor);
         if (colorDlg.ShowDialog() == DialogResult.OK)
         {
            _lblSegEndColor.BackColor = colorDlg.Color;
            _interactiveHistogramData.segmentEndColor = Leadtools.Demos.Converters.FromGdiPlusColor(colorDlg.Color);
            ApplyFilter();
            DrawChanges();
         }
      }

      private void _rbSegGradient_CheckedChanged(object sender, EventArgs e)
      {
         _btnSegStartColor.Text = "Start Color";
         _btnSegEndColor.Text = "End Color";
         _interactiveHistogramData.gradient = true;

         ApplyFilter();
         DrawChanges();
      }

      private void _rbSegThreshold_CheckedChanged(object sender, EventArgs e)
      {
         _btnSegStartColor.Text = "Inner Color";
         _btnSegEndColor.Text = "Outer Color";
         _interactiveHistogramData.gradient = false;

         ApplyFilter();
         DrawChanges();
      }

      private void _cbGrayFunctionType_SelectedIndexChanged(object sender, EventArgs e)
      {
         if (_interactiveHistogramData.grayFunctionType != (FunctionalLookupTableFlags)_cbGrayFunctionType.SelectedIndex)
         {
            _interactiveHistogramData.grayFunctionType = (FunctionalLookupTableFlags)_cbGrayFunctionType.SelectedIndex;

            if (_cbGrayFunctionType.SelectedIndex == 1)
               _nudGrayFactor.Minimum = 0;
            else
               _nudGrayFactor.Minimum = -1000;

            if (_cbGrayFunctionType.SelectedIndex == 2)
            {
               _nudGrayFactor.Enabled = false;
               _lblGrayFactor.Enabled = false;
            }
            else
            {
               _nudGrayFactor.Enabled = true;
               _lblGrayFactor.Enabled = true;
            }

            ApplyFilter();
            DrawChanges();
         }
      }

      private void _nudGrayFactor_ValueChanged(object sender, EventArgs e)
      {
         if (_interactiveHistogramData.grayFactor != _nudGrayFactor.Value)
         {
            _interactiveHistogramData.grayFactor = (int)_nudGrayFactor.Value;
            ApplyFilter();
            DrawChanges();
         }
      }

      private void _cbGraySelectionOnly_CheckedChanged(object sender, EventArgs e)
      {
         _interactiveHistogramData.graySelectionOnly = _cbGraySelectionOnly.Checked;
         ApplyFilter();
         DrawChanges();
      }

      private void _btnGrayStartColor_Click(object sender, EventArgs e)
      {
         ColorDialog colorDlg = new ColorDialog();

         colorDlg.Color = GetColorFromRasterColor(_interactiveHistogramData.grayStartColor);
         if (colorDlg.ShowDialog() == DialogResult.OK)
         {
            _lblGrayStartColor.BackColor = colorDlg.Color;
            _interactiveHistogramData.grayStartColor = Leadtools.Demos.Converters.FromGdiPlusColor(colorDlg.Color);
            ApplyFilter();
            DrawChanges();
         }
      }

      private void _btnGrayEndColor_Click(object sender, EventArgs e)
      {
         ColorDialog colorDlg = new ColorDialog();

         colorDlg.Color = GetColorFromRasterColor(_interactiveHistogramData.grayEndColor);
         if (colorDlg.ShowDialog() == DialogResult.OK)
         {
            _lblGrayEndColor.BackColor = colorDlg.Color;
            _interactiveHistogramData.grayEndColor = Leadtools.Demos.Converters.FromGdiPlusColor(colorDlg.Color);
            ApplyFilter();
            DrawChanges();
         }
      }

      private void _cbNoiseReplaceWith_SelectedIndexChanged(object sender, EventArgs e)
      {
         if ((int)_interactiveHistogramData.noiseReplaceType != _cbNoiseReplaceWith.SelectedIndex)
         {
            _interactiveHistogramData.noiseReplaceType = (FilterNoiseReplaceType)_cbNoiseReplaceWith.SelectedIndex;

            ApplyFilter();
            DrawChanges();

            if (_cbNoiseReplaceWith.SelectedIndex == 2)
               _btnNoiseReplaceColor.Enabled = true;
            else
               _btnNoiseReplaceColor.Enabled = false;
         }
      }

      private void _btnNoiseReplaceColor_Click(object sender, EventArgs e)
      {
         ColorDialog colorDlg = new ColorDialog();

         colorDlg.Color = GetColorFromRasterColor(_interactiveHistogramData.noiseReplaceColor);
         if (colorDlg.ShowDialog() == DialogResult.OK)
         {
            _lblNoiseReplaceColor.BackColor = colorDlg.Color;
            _interactiveHistogramData.noiseReplaceColor = Leadtools.Demos.Converters.FromGdiPlusColor(colorDlg.Color);
            ApplyFilter();
            DrawChanges();
         }
      }

      private void _rbResShift_CheckedChanged(object sender, EventArgs e)
      {
         EnableRescaleOptions(true);
         ApplyFilter();
         DrawChanges();
      }

      private void _nudResShiftAmount_ValueChanged(object sender, EventArgs e)
      {
         if (_interactiveHistogramData.rescaleShiftAmount != (int)_nudResShiftAmount.Value)
         {
            _interactiveHistogramData.rescaleShiftAmount = (int)_nudResShiftAmount.Value;
            if (_interactiveHistogramData.rescaleShiftAmount > _interactiveHistogramData.histogramLabel.endRange)
            {
               _nudResShiftAmount.Value = _interactiveHistogramData.histogramLabel.endRange;
               return;
            }
            if (_interactiveHistogramData.rescaleShiftAmount < _interactiveHistogramData.histogramLabel.startRange)
            {
               _nudResShiftAmount.Value = _interactiveHistogramData.histogramLabel.startRange;
               return;
            }

            ApplyFilter();
            DrawChanges();
         }
      }

      private void _rbResShiftRight_CheckedChanged(object sender, EventArgs e)
      {
         _interactiveHistogramData.shiftRight = true;
         ApplyFilter();
         DrawChanges();
      }

      private void _rbResShiftLeft_CheckedChanged(object sender, EventArgs e)
      {
         _interactiveHistogramData.shiftRight = false;
         ApplyFilter();
         DrawChanges();
      }

      private void _rbResNewSE_CheckedChanged(object sender, EventArgs e)
      {
         EnableRescaleOptions(false);
         ApplyFilter();
         DrawChanges();
      }

      private void _nudResNewStart_ValueChanged(object sender, EventArgs e)
      {
         if (_interactiveHistogramData.cD[(int) _interactiveHistogramData.channel].rescale.newStartLine.position != (int) _nudResNewStart.Value)
         {
            _interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].rescale.newStartLine.position = (int)_nudResNewStart.Value;

            _nudResNewEnd.Minimum = _interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].rescale.newStartLine.position + 1;

            ApplyFilter();
            DrawChanges();
         }
      }

      private void _nudResNewEnd_ValueChanged(object sender, EventArgs e)
      {
         if (_interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].rescale.newEndLine.position != (int)_nudResNewEnd.Value)
         {
            _interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].rescale.newEndLine.position = (int)_nudResNewEnd.Value;

            _nudResNewStart.Maximum = _interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].rescale.newEndLine.position - 1;

            ApplyFilter();;
            DrawChanges();
         }
      }

      private void EnableApplyLUT(bool enable)
      {
         _btnSegApplyLUT.Enabled = enable;
         _btnGrayApplyLUT.Enabled = enable;
         _btnNoiseApplyLUT.Enabled = enable;
         _btnResApplyLUT.Enabled = enable;
      }

      private void _tabOptions_SelectedIndexChanged(object sender, EventArgs e)
      {
         string str = string.Format("%d", _interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].orginalHistogram[GetStart() + ((_interactiveHistogramData.signed) ? Math.Abs(_interactiveHistogramData.histogramLabel.startRange) : 0)]);
         _lblSegStartPtOccVal.Text = str;
         _lblGryStartPtOccVal.Text = str;
         _lblNoiseStartPtOccVal.Text = str;
         _lblResStartPtOccVal.Text = str;

         str = string.Format("%d", _interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].orginalHistogram[GetEnd() + ((_interactiveHistogramData.signed) ? Math.Abs(_interactiveHistogramData.histogramLabel.startRange) : 0)]);
         _lblSegEndPtOccVal.Text = str;
         _lblGryEndPtOccVal.Text = str;
         _lblNoiseEndPtOccVal.Text = str;
         _lblResEndPtOccVal.Text = str;

         SetEditStart(GetStart());
         SetEditEnd(GetEnd());

         if (_interactiveHistogramData.fullView || _interactiveHistogramData.histogramLabel.zoomed)
            FitHistogram();

         ChildImage = _interactiveHistogramData.originalImage.CloneAll();

         EnableApplyLUT(_interactiveHistogramData.originalImage.UseLookupTable && _tabOptions.SelectedIndex < 2);

         _lblSegStartPtOccVal.Text = (_interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].orginalHistogram[_interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].segmentation.startLine.position + ((_interactiveHistogramData.signed) ? Math.Abs(_interactiveHistogramData.histogramLabel.startRange) : 0)]).ToString();
         _lblSegEndPtOccVal.Text = (_interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].orginalHistogram[_interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].segmentation.endLine.position + ((_interactiveHistogramData.signed) ? Math.Abs(_interactiveHistogramData.histogramLabel.startRange) : 0)]).ToString();

         _lblGryStartPtOccVal.Text = (_interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].orginalHistogram[_interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].grayDistribution.startLine.position + ((_interactiveHistogramData.signed) ? Math.Abs(_interactiveHistogramData.histogramLabel.startRange) : 0)]).ToString();
         _lblGryEndPtOccVal.Text = (_interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].orginalHistogram[_interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].grayDistribution.endLine.position + ((_interactiveHistogramData.signed) ? Math.Abs(_interactiveHistogramData.histogramLabel.startRange) : 0)]).ToString();

         _lblNoiseStartPtOccVal.Text = (_interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].orginalHistogram[_interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].filterNoise.startLine.position + ((_interactiveHistogramData.signed) ? Math.Abs(_interactiveHistogramData.histogramLabel.startRange) : 0)]).ToString();
         _lblNoiseEndPtOccVal.Text = (_interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].orginalHistogram[_interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].filterNoise.endLine.position + ((_interactiveHistogramData.signed) ? Math.Abs(_interactiveHistogramData.histogramLabel.startRange) : 0)]).ToString();

         _lblResStartPtOccVal.Text = (_interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].orginalHistogram[_interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].rescale.startLine.position + ((_interactiveHistogramData.signed) ? Math.Abs(_interactiveHistogramData.histogramLabel.startRange) : 0)]).ToString();
         _lblResEndPtOccVal.Text = (_interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].orginalHistogram[_interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].rescale.endLine.position + ((_interactiveHistogramData.signed) ? Math.Abs(_interactiveHistogramData.histogramLabel.startRange) : 0)]).ToString();

         _chkSegApplyInProgress.Checked = _interactiveHistogramData.applyInProgress[_tabOptions.SelectedIndex];

         SetLabelsColor();
         ApplyFilter();
         DrawChanges();
      }

      private int ApplyChanges()
      {
         if (_interactiveHistogramData.getHistogram)
         {
            HistogramCommand cmd = new HistogramCommand();
            cmd.Channel = (HistogramCommandFlags)_interactiveHistogramData.channel;
            cmd.Progress += new EventHandler<RasterCommandProgressEventArgs>(cmd_Progress);

            try
            {
               cmd.Run(ChildImage);
            }
            catch (Exception ex)
            {
               ex.Message.ToString();
               _interactiveHistogramData.histogramAvaliable = false;
            }

            _interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].orginalHistogram = cmd.Histogram;

            if (_interactiveHistogramData.signed)
            {
               int length = _interactiveHistogramData.histogramLabel.histogramLength / 2;
#if LEADTOOLS_V175_OR_LATER
               Int64[] pTemp = new Int64[length];
#else
                  int[] pTemp = new int[length];
#endif


               Array.ConstrainedCopy(_interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].orginalHistogram, 0,
                                     pTemp, 0, length);
               Array.ConstrainedCopy(_interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].orginalHistogram, length,
                                     _interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].orginalHistogram, 0, length);
               Array.ConstrainedCopy(pTemp, 0,
                                     _interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].orginalHistogram, length, length);
            }

            if (!_interactiveHistogramData.fullView)
               PrepareCompressedHisto();

            _interactiveHistogramData.getHistogram = false;
         }
         return 1;
      }

      private int ApplyChangesFromLUT(RasterColor[] RGBLUT, int[] LUT)
      {
         int nRet = 0;
         bool useLUT;

         _interactiveHistogramData.applyInProgress[_tabOptions.SelectedIndex] = false;
         ApplyInProgress(false);

         if ((ChildImage.GrayscaleMode == RasterGrayscaleMode.None && (!ChildImage.UseLookupTable)) && _interactiveHistogramData.channel == RasterColorChannel.Master && !_interactiveHistogramData.signed)
         {
            FreeImage(applyImage);
            applyImage = _interactiveHistogramData.originalImage.CloneAll();

            switch (_tabOptions.SelectedIndex)
            {
               case 0:
                  nRet = ApplySegmentationMaster(_interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].segmentation.startLine.position, _interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].segmentation.endLine.position);
                  break;
               case 1:
                  nRet = ApplyGrayMaster(_interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].grayDistribution.startLine.position, _interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].grayDistribution.endLine.position);
                  break;
               case 2:
                  nRet = ApplyFilterMaster(_interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].filterNoise.startLine.position, _interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].filterNoise.endLine.position);
                  break;
               case 3:
                  nRet = ApplyResaleMaster();
                  break;
            }
            FreeImage(ChildImage);
            ChildImage = applyImage.CloneAll();
         }
         else
         {
            FreeImage(ChildImage);
            ChildImage = _interactiveHistogramData.originalImage.CloneAll();

            useLUT = ChildImage.UseLookupTable;

            ChildImage.UseLookupTable = false;

            RemapIntensityCommand cmd = new RemapIntensityCommand();
            cmd.LookupTable = LUT;
            cmd.Flags = (RemapIntensityCommandFlags)_interactiveHistogramData.channel | RemapIntensityCommandFlags.Normal;
            cmd.Progress += new EventHandler<RasterCommandProgressEventArgs>(cmd_Progress);
            cmd.Run(ChildImage);

            ChildImage.UseLookupTable = useLUT;
         }

         return 1;
      }

      private void FreeImage(RasterImage image)
      {
         if (image != null)
            image.Dispose();
      }

      private void ConvertToGrayLUT()
      {
         int value;

         for (int index = 0; index < _interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].RGBLUTGray.Length; index++)
         {
            value = GetGrayValue(_interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].RGBLUTGray[index]);
            _interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].RGBLUTGray[index] = new RasterColor(value, value, value);
         }
      }

      private void _btnApplyToBitmap_Click(object sender, EventArgs e)
      {
         this.Cursor = Cursors.WaitCursor;
         if ((!_interactiveHistogramData.grayLUT || _interactiveHistogramData.grayPredefinedPalette) && _interactiveHistogramData.originalImage.UseLookupTable)
         {
            if (Messager.ShowQuestion(this, "Color LUT may cause data lost\n do you want to continue?", MessageBoxIcon.Warning, MessageBoxButtons.YesNo) == DialogResult.No)
               return;

            if ((_tabOptions.SelectedIndex == 1) && _interactiveHistogramData.originalImage.IsGray)
               ConvertToGrayLUT();
         }

         int nRet = 0;
         int nBPP = _interactiveHistogramData.originalImage.BitsPerPixel;
         switch (_tabOptions.SelectedIndex)
         {
            case 0: nRet = ApplyChangesFromLUT(_interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].RGBLUTSegment, _interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].LUTSegment); break;
            case 1: nRet = ApplyChangesFromLUT(_interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].RGBLUTGray, _interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].LUTGray); break;
            case 2: nRet = ApplyChangesFromLUT(null, _interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].LUTFilter); break;
            case 3: nRet = ApplyChangesFromLUT(null, _interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].LUTRescale); break;
         }

         if (nRet == 1)
         {
            FreeImage(_interactiveHistogramData.undoImage);

            _interactiveHistogramData.undoImage = _interactiveHistogramData.originalImage.CloneAll();

            _btnUndo.Enabled = true;

            FreeImage(_interactiveHistogramData.originalImage);
            _interactiveHistogramData.originalImage = ChildImage.CloneAll();

            InitAfterApply();
            _interactiveHistogramData.getHistogram = true;
            nRet = ApplyChanges();
            if (nRet == 1)
            {
               DrawChanges();
            }

            SetStatisticalValue();
            FitHistogram();
         }
         this.Cursor = Cursors.Arrow;
      }

      private void _btnApplyLUT_Click(object sender, EventArgs e)
      {
         int nRet = 1;
         RasterColor[] lookUpTable = ChildImage.GetLookupTable();
         Array.Copy(lookUpTable, _interactiveHistogramData.originalLUT, lookUpTable.Length);
         switch (_tabOptions.SelectedIndex)
         {
            case 0:
               Array.Copy(_interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].RGBLUTSegment,
                          _interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].RGBPrevLUT,
                          _interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].RGBLUTSegment.Length);
               break;

            case 1:
               Array.Copy(_interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].RGBLUTGray,
                          _interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].RGBPrevLUT,
                          _interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].RGBLUTGray.Length);
               break;
         }

         if (!_interactiveHistogramData.applyInProgress[_tabOptions.SelectedIndex])
         {
            _interactiveHistogramData.applyInProgress[_tabOptions.SelectedIndex] = true;
            nRet = ApplyFilter();
            DrawChanges();

            _interactiveHistogramData.applyInProgress[_tabOptions.SelectedIndex] = false;
         }

         if (nRet == 1)
         {
            if (_interactiveHistogramData.undoImage != null)
               FreeImage(_interactiveHistogramData.undoImage);

            _interactiveHistogramData.undoImage = _interactiveHistogramData.originalImage.CloneAll();
            _btnUndo.Enabled = true;
         }

         Array.Copy(lookUpTable, _interactiveHistogramData.originalLUT, lookUpTable.Length);
      }

      private void _btnCancel_Click(object sender, EventArgs e)
      {
         this.Close();
      }

      private void _btnOk_Click(object sender, EventArgs e)
      {
         FreeImage(ChildImage);
         ChildImage = _interactiveHistogramData.originalImage.CloneAll();

         if (_interactiveHistogramData.originalImage.UseLookupTable && (_interactiveHistogramData.originalImage.GrayscaleMode != RasterGrayscaleMode.None || _interactiveHistogramData.signed))
            ChildImage.SetLookupTable(_interactiveHistogramData.originalLUT);
      }

      private void _btnUndo_Click(object sender, EventArgs e)
      {
         int nRet;

         FreeImage(_interactiveHistogramData.originalImage);
         _interactiveHistogramData.originalImage = _interactiveHistogramData.undoImage.CloneAll();

         _btnUndo.Enabled = false;

         if (_interactiveHistogramData.originalImage.UseLookupTable)
         {
            RasterColor[] tempArray = _interactiveHistogramData.originalImage.GetLookupTable();

            Array.Copy(tempArray, _interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].RGBPrevLUT, _interactiveHistogramData.histogramLabel.histogramLength);
            Array.Copy(tempArray, _interactiveHistogramData.originalLUT, _interactiveHistogramData.histogramLabel.histogramLength);
         }
         else
            EnableApplyLUT(false);

         ChildImage = _interactiveHistogramData.originalImage.CloneAll();

         _mainForm.ActiveViewerForm.Invalidate(true);

         _interactiveHistogramData.getHistogram = true;
         nRet = ApplyFilter();
         DrawChanges();

         // Set the selection statistical Information...
         SetStatisticalValue();
         _MainProgressBar.Value = 0;
      }

      private void _lblHistogram_MouseLeave(object sender, EventArgs e)
      {
         _interactiveHistogramData.histogramLabel.moveType = MovePoint.None;
         this.Cursor = Cursors.Arrow;
      }

      private void _cmiZoomToSelection_Click(object sender, EventArgs e)
      {
         if (_interactiveHistogramData.histogramLabel.drawEndRange - _interactiveHistogramData.histogramLabel.drawStartRange <= 256)
         {
            _interactiveHistogramData.histogramLabel.drawStartRange = GetRealVal(GetStart());
            _interactiveHistogramData.histogramLabel.drawEndRange = GetRealVal(GetEnd());

            bool signed = false;
            if (_interactiveHistogramData.signed)
            {
               signed = _interactiveHistogramData.signed;
               _interactiveHistogramData.signed = false;
            }
            _interactiveHistogramData.histogramLabel.drawLength = GetRealVal(GetEnd() - GetStart());
            if (signed)
               _interactiveHistogramData.signed = true;

            _lblMousePercent.Text = "0";
            _lblMouseLevel.Text = "0";
            _lblMouseCount.Text = "0";

            _interactiveHistogramData.histogramLabel.zoomed = true;
            _interactiveHistogramData.fullView = false;
            this.Invalidate(true);
         }
         else
         {
            Messager.ShowError(this, "Difference between the Start Point and the End Point must be less than 512.");
         }
      }

      private void _cmiFitGraph_Click(object sender, EventArgs e)
      {
         FitHistogram();
         _interactiveHistogramData.fullView = false;
      }

      private void _cmiFullRangeView_Click(object sender, EventArgs e)
      {
         _interactiveHistogramData.histogramLabel.drawLength = _interactiveHistogramData.histogramLabel.histogramLength;
         _interactiveHistogramData.histogramLabel.drawHistogram = new int[_interactiveHistogramData.histogramLabel.drawLength];

         Array.Copy(_interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].orginalHistogram, _interactiveHistogramData.histogramLabel.drawHistogram, _interactiveHistogramData.histogramLabel.drawLength);

         _interactiveHistogramData.histogramLabel.drawLength = _interactiveHistogramData.histogramLabel.histogramLength;

         if (!_interactiveHistogramData.signed)
         {
            _interactiveHistogramData.histogramLabel.drawEndRange = 255;
            _interactiveHistogramData.histogramLabel.drawStartRange = 0;
         }
         else
         {
            _interactiveHistogramData.histogramLabel.drawStartRange = _interactiveHistogramData.histogramLabel.startRange;
            _interactiveHistogramData.histogramLabel.drawEndRange = _interactiveHistogramData.histogramLabel.drawStartRange + 256;
         }

         _interactiveHistogramData.fullView = true;

         SetLabelsValues();
         _hsRange.Visible = true;
         _hsRange.Enabled = true;

         _lblHelp.Visible = true;
         this.Invalidate(true);
      }

      private void _cmRightClickOptions_Opening(object sender, CancelEventArgs e)
      {
         _cmiZoomToSelection.Enabled = (GetEnd() - GetStart() >= _interactiveHistogramData.scale);
         _cmiFitGraph.Enabled = (_interactiveHistogramData.histogramLabel.zoomed || _interactiveHistogramData.histogramLabel.drawLength != 256);
         _cmiFullRangeView.Enabled = (_interactiveHistogramData.histogramLabel.drawLength == 256);

         if (_interactiveHistogramData.histogramLabel.histogramLength == 256)
         {
            _cmiFullRangeView.Enabled = false;
         }

         _interactiveHistogramData.histogramLabel.moveType = MovePoint.None;
      }

      private void CheckProgress()
      {
         _cancelRun = false;

         _MainProgressBar.Value = 0;
      }

      private void cmd_Progress(object sender, RasterCommandProgressEventArgs e)
      {
         _MainProgressBar.Value = e.Percent;

         if (_cancelRun)
            e.Cancel = true;
      }

      private void _rbRes_Click(object sender, EventArgs e)
      {
         if (sender == _rbResShift && !_rbResShift.Checked)
         {
            _rbResNewSE.Checked = false;
            _rbResShift.Checked = true;
         }
         else if (sender == _rbResNewSE && !_rbResNewSE.Checked)
         {
            _rbResShift.Checked = false;
            _rbResNewSE.Checked = true;
         }
         else if (sender == _rbResShiftRight && !_rbResShiftRight.Checked)
         {
            _rbResShiftLeft.Checked = false;
            _rbResShiftRight.Checked = true;
         }
         else if (sender == _rbResShiftLeft && !_rbResShiftLeft.Checked)
         {
            _rbResShiftRight.Checked = false;
            _rbResShiftLeft.Checked = true;
         }
      }

      private void InteractiveHistogramDialog_FormClosed(object sender, FormClosedEventArgs e)
      {
         if (this.DialogResult != DialogResult.OK)
         {
            FreeImage(_interactiveHistogramData.originalImage);
            ChildImage = _interactiveHistogramData.savedImage.CloneAll();
         }
      }

      private int[] Generate256Histogram(RasterColor[] lut, int[] originalHistogram, HistogramCommandFlags channel)
      {
         int index;
         int[] returnHistogram = new int[256];

         for (index = 0; index < originalHistogram.Length; index++)
         {
            switch (channel)
            {
               case HistogramCommandFlags.Master:
                  returnHistogram[GetGrayValue(lut[index])] += originalHistogram[index];
                  break;

               case HistogramCommandFlags.Red:
                  returnHistogram[lut[index].R] += originalHistogram[index];
                  break;

               case HistogramCommandFlags.Green:
                  returnHistogram[lut[index].G] += originalHistogram[index];
                  break;

               case HistogramCommandFlags.Blue:
                  returnHistogram[lut[index].B] += originalHistogram[index];
                  break;
            }
         }
         return returnHistogram;
      }

      private void PrepareRemapIntensity(int[] LUT, int length, RasterColorChannel channel)
      {
         int[] buffer;
         uint i, j;
         uint size = (uint)length;
         bool useLUT = false;

         if (applyImage.UseLookupTable)
         {
            applyImage.UseLookupTable = false;
            useLUT = true;
         }

         switch (applyImage.BitsPerPixel)
         {
            case 12:
               buffer = new int[4096];
               size = 4096;
               break;

            case 16:
               if ((applyImage.GrayscaleMode == RasterGrayscaleMode.None && (applyImage.GetLookupTable() == null)) && !applyImage.Signed)
               {
                  buffer = new int[length];
                  size = (uint)length;
               }
               else
               {
                  buffer = new int[65536];
                  size = 65536;
               }
               break;

            default:
               buffer = new int[length];
               size = (uint)length;
               break;
         }

         switch (applyImage.BitsPerPixel)
         {
            case 12:
               for (i = 0; i < length; i++)
               {
                  for (j = 0; j < (4096) / length; j++)
                  {
                     buffer[(i * 4096) / length + j] = (LUT[i] * 4096) / length;
                  }
               }
               break;

            case 16:
               if ((applyImage.GrayscaleMode == RasterGrayscaleMode.None && (applyImage.GetLookupTable() == null)) && !applyImage.Signed)
               {
                  Array.Copy(LUT, buffer, length);
               }
               else
               {
                  for (i = 0; i < length; i++)
                  {
                     for (j = 0; j < (65536) / length; j++)
                     {
                        buffer[(i * 65536) / length + j] = (int)((((uint)LUT[i]) * 65536) / length);
                     }
                  }
               }
               break;

            default:
               Array.Copy(LUT, buffer, length);
               break;
         }

         RemapIntensityCommand cmd = new RemapIntensityCommand();
         cmd.Flags = (RemapIntensityCommandFlags)channel;
         cmd.LookupTable = buffer;
         cmd.Progress += new EventHandler<RasterCommandProgressEventArgs>(cmd_Progress);
         cmd.Run(applyImage);

         applyImage.UseLookupTable = useLUT;
      }

      private int ApplyFilter()
      {
         int result = 1;
         try
         {
            switch (_tabOptions.SelectedIndex)
            {
               case 0: result = GetLUTSegmentation(); break;
               case 1: result = GetLUTGrayDistribution(); break;
               case 2: result = GetLUTFilterNoise(); break;
               case 3: result = GetLUTRescaling(); break;
            }

            if (_interactiveHistogramData.histogramLabel.zoomed)
            {
               _interactiveHistogramData.histogramLabel.drawStartRange = GetRealVal(GetStart());
               _interactiveHistogramData.histogramLabel.drawEndRange = GetRealVal(GetEnd());
            }

            if (_interactiveHistogramData.getHistogram)
            {
               HistogramCommand cmd = new HistogramCommand();
               cmd.Channel = (HistogramCommandFlags)_interactiveHistogramData.channel;
               if (_interactiveHistogramData.histogramLabel.histogramLength == 256)
               {
                  cmd.Channel |= HistogramCommandFlags.Force256;
               }
               cmd.Progress += new EventHandler<RasterCommandProgressEventArgs>(cmd_Progress);

               try
               {
                  cmd.Run(_interactiveHistogramData.originalImage);
               }
               catch (Exception ex)
               {
                  ex.Message.ToString();
                  _interactiveHistogramData.histogramAvaliable = false;
               }

               Array.Copy(cmd.Histogram, _interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].orginalHistogram, cmd.Histogram.Length);

               if (_interactiveHistogramData.signed)
               {
                  int nLength = Convert.ToInt32(_interactiveHistogramData.histogramLabel.histogramLength / 2.0);

#if LEADTOOLS_V175_OR_LATER
                  Int64[] pTemp = new Int64[nLength];
#else
                  int[] pTemp = new int[nLength];
#endif


                  Array.Copy(_interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].orginalHistogram, 0, pTemp, 0, nLength);
                  Array.Copy(_interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].orginalHistogram, _interactiveHistogramData.histogramLabel.histogramLength / 2, _interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].orginalHistogram, 0, nLength);
                  Array.Copy(pTemp, 0, _interactiveHistogramData.cD[(int)_interactiveHistogramData.channel].orginalHistogram, _interactiveHistogramData.histogramLabel.histogramLength / 2, nLength);
               }

               if (!_interactiveHistogramData.fullView)
                  PrepareCompressedHisto();

               _interactiveHistogramData.getHistogram = false;
            }
         }
         catch (Exception ex)
         {
            Messager.ShowError(this, ex);
         }

         _MainProgressBar.Value = 0;

         return result;
      }

      private void _chkApplyInProgress_CheckedChanged(object sender, EventArgs e)
      {
         if (!_doApply)
            return;

         _interactiveHistogramData.applyInProgress[_tabOptions.SelectedIndex] = ((CheckBox) sender).Checked;
         ApplyFilter();
         DrawChanges();
      }
   }
}

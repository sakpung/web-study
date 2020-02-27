// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Drawing;
using System.Windows.Forms;

using Leadtools;
using Leadtools.ImageProcessing.Color;

namespace MrcSegmentationDemo
{
   /// <summary>
   /// Summary description for HistogramDialog.
   /// </summary>
   public class HistogramDialog : System.Windows.Forms.Form
   {
      internal System.Windows.Forms.Label _lblChannel;
      private System.Windows.Forms.ComboBox _cbChannel;
      private System.Windows.Forms.ComboBox _cbView;
      private System.Windows.Forms.Label _lblHistogram;
      private System.Windows.Forms.GroupBox _groupBox1;
      private System.Windows.Forms.NumericUpDown _numUDClipping;
      private System.Windows.Forms.Label _lblClipping;
      private System.Windows.Forms.GroupBox _groupBox2;
      private System.Windows.Forms.Label _lblPercentileValue;
      private System.Windows.Forms.Label _lblPercentile;
      private System.Windows.Forms.Label _lblCountValue;
      private System.Windows.Forms.Label _lblCount;
      private System.Windows.Forms.Label _lblMedianValue;
      private System.Windows.Forms.Label _lblMedian;
      private System.Windows.Forms.Label _lblTotalPixelsValue;
      private System.Windows.Forms.Label _lblTotalPixels;
      private System.Windows.Forms.Label _lblLevelValue;
      private System.Windows.Forms.Label _lblLevel;
      private System.Windows.Forms.Label _lblMeanValue;
      private System.Windows.Forms.Label _lblMean;
      private System.Windows.Forms.Button _btnClose;
      internal System.Windows.Forms.Label _lblView;
      /// <summary>
      /// Required designer variable.
      /// </summary>
      private System.ComponentModel.Container components = null;

      public HistogramDialog(RasterImage image)
      {
         //
         // Required for Windows Form Designer support
         //
         InitializeComponent();
         //
         // TODO: Add any constructor code after InitializeComponent call
         //

         InitClass(image);
      }

      /// <summary>
      /// Clean up any resources being used.
      /// </summary>
      protected override void Dispose(bool disposing)
      {
         if(disposing)
         {
            if(components != null)
            {
               components.Dispose();
            }
         }
         base.Dispose(disposing);
      }

      #region Windows Form Designer generated code
      /// <summary>
      /// Required method for Designer support - do not modify
      /// the contents of this method with the code editor.
      /// </summary>
      private void InitializeComponent( )
      {
         this._lblChannel = new System.Windows.Forms.Label();
         this._cbChannel = new System.Windows.Forms.ComboBox();
         this._cbView = new System.Windows.Forms.ComboBox();
         this._lblHistogram = new System.Windows.Forms.Label();
         this._groupBox1 = new System.Windows.Forms.GroupBox();
         this._numUDClipping = new System.Windows.Forms.NumericUpDown();
         this._lblClipping = new System.Windows.Forms.Label();
         this._groupBox2 = new System.Windows.Forms.GroupBox();
         this._lblPercentileValue = new System.Windows.Forms.Label();
         this._lblPercentile = new System.Windows.Forms.Label();
         this._lblCountValue = new System.Windows.Forms.Label();
         this._lblCount = new System.Windows.Forms.Label();
         this._lblMedianValue = new System.Windows.Forms.Label();
         this._lblMedian = new System.Windows.Forms.Label();
         this._lblTotalPixelsValue = new System.Windows.Forms.Label();
         this._lblTotalPixels = new System.Windows.Forms.Label();
         this._lblLevelValue = new System.Windows.Forms.Label();
         this._lblLevel = new System.Windows.Forms.Label();
         this._lblMeanValue = new System.Windows.Forms.Label();
         this._lblMean = new System.Windows.Forms.Label();
         this._btnClose = new System.Windows.Forms.Button();
         this._lblView = new System.Windows.Forms.Label();
         this._groupBox1.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this._numUDClipping)).BeginInit();
         this._groupBox2.SuspendLayout();
         this.SuspendLayout();
         // 
         // _lblChannel
         // 
         this._lblChannel.Location = new System.Drawing.Point(8, 8);
         this._lblChannel.Name = "_lblChannel";
         this._lblChannel.Size = new System.Drawing.Size(56, 16);
         this._lblChannel.TabIndex = 0;
         this._lblChannel.Text = "C&hannel:";
         // 
         // _cbChannel
         // 
         this._cbChannel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this._cbChannel.Location = new System.Drawing.Point(61, 5);
         this._cbChannel.Name = "_cbChannel";
         this._cbChannel.Size = new System.Drawing.Size(83, 21);
         this._cbChannel.TabIndex = 1;
         this._cbChannel.SelectedIndexChanged += new System.EventHandler(this._cbChannel_SelectedIndexChanged);
         // 
         // _cbView
         // 
         this._cbView.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this._cbView.Location = new System.Drawing.Point(432, 5);
         this._cbView.Name = "_cbView";
         this._cbView.Size = new System.Drawing.Size(83, 21);
         this._cbView.TabIndex = 3;
         this._cbView.SelectedIndexChanged += new System.EventHandler(this._cbView_SelectedIndexChanged);
         // 
         // _lblHistogram
         // 
         this._lblHistogram.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
         this._lblHistogram.Location = new System.Drawing.Point(6, 34);
         this._lblHistogram.Name = "_lblHistogram";
         this._lblHistogram.Size = new System.Drawing.Size(512, 152);
         this._lblHistogram.TabIndex = 4;
         this._lblHistogram.Paint += new System.Windows.Forms.PaintEventHandler(this._lblHistogram_Paint);
         this._lblHistogram.MouseMove += new System.Windows.Forms.MouseEventHandler(this._lblHistogram_MouseMove);
         // 
         // _groupBox1
         // 
         this._groupBox1.Controls.Add(this._numUDClipping);
         this._groupBox1.Controls.Add(this._lblClipping);
         this._groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this._groupBox1.Location = new System.Drawing.Point(5, 198);
         this._groupBox1.Name = "_groupBox1";
         this._groupBox1.Size = new System.Drawing.Size(512, 43);
         this._groupBox1.TabIndex = 5;
         this._groupBox1.TabStop = false;
         // 
         // _numUDClipping
         // 
         this._numUDClipping.Location = new System.Drawing.Point(56, 15);
         this._numUDClipping.Name = "_numUDClipping";
         this._numUDClipping.Size = new System.Drawing.Size(48, 20);
         this._numUDClipping.TabIndex = 1;
         this._numUDClipping.ValueChanged += new System.EventHandler(this._numUDClipping_ValueChanged);
         // 
         // _lblClipping
         // 
         this._lblClipping.Location = new System.Drawing.Point(12, 17);
         this._lblClipping.Name = "_lblClipping";
         this._lblClipping.Size = new System.Drawing.Size(45, 16);
         this._lblClipping.TabIndex = 0;
         this._lblClipping.Text = "Cli&pping:";
         // 
         // _groupBox2
         // 
         this._groupBox2.Controls.Add(this._lblPercentileValue);
         this._groupBox2.Controls.Add(this._lblPercentile);
         this._groupBox2.Controls.Add(this._lblCountValue);
         this._groupBox2.Controls.Add(this._lblCount);
         this._groupBox2.Controls.Add(this._lblMedianValue);
         this._groupBox2.Controls.Add(this._lblMedian);
         this._groupBox2.Controls.Add(this._lblTotalPixelsValue);
         this._groupBox2.Controls.Add(this._lblTotalPixels);
         this._groupBox2.Controls.Add(this._lblLevelValue);
         this._groupBox2.Controls.Add(this._lblLevel);
         this._groupBox2.Controls.Add(this._lblMeanValue);
         this._groupBox2.Controls.Add(this._lblMean);
         this._groupBox2.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this._groupBox2.Location = new System.Drawing.Point(5, 248);
         this._groupBox2.Name = "_groupBox2";
         this._groupBox2.Size = new System.Drawing.Size(512, 72);
         this._groupBox2.TabIndex = 6;
         this._groupBox2.TabStop = false;
         // 
         // _lblPercentileValue
         // 
         this._lblPercentileValue.Location = new System.Drawing.Point(432, 48);
         this._lblPercentileValue.Name = "_lblPercentileValue";
         this._lblPercentileValue.Size = new System.Drawing.Size(64, 14);
         this._lblPercentileValue.TabIndex = 11;
         // 
         // _lblPercentile
         // 
         this._lblPercentile.Location = new System.Drawing.Point(371, 48);
         this._lblPercentile.Name = "_lblPercentile";
         this._lblPercentile.Size = new System.Drawing.Size(72, 15);
         this._lblPercentile.TabIndex = 10;
         this._lblPercentile.Text = "Percentile:";
         // 
         // _lblCountValue
         // 
         this._lblCountValue.Location = new System.Drawing.Point(240, 48);
         this._lblCountValue.Name = "_lblCountValue";
         this._lblCountValue.Size = new System.Drawing.Size(57, 15);
         this._lblCountValue.TabIndex = 9;
         // 
         // _lblCount
         // 
         this._lblCount.Location = new System.Drawing.Point(192, 48);
         this._lblCount.Name = "_lblCount";
         this._lblCount.Size = new System.Drawing.Size(35, 15);
         this._lblCount.TabIndex = 8;
         this._lblCount.Text = "Count:";
         // 
         // _lblMedianValue
         // 
         this._lblMedianValue.Location = new System.Drawing.Point(63, 48);
         this._lblMedianValue.Name = "_lblMedianValue";
         this._lblMedianValue.Size = new System.Drawing.Size(48, 14);
         this._lblMedianValue.TabIndex = 7;
         // 
         // _lblMedian
         // 
         this._lblMedian.Location = new System.Drawing.Point(9, 48);
         this._lblMedian.Name = "_lblMedian";
         this._lblMedian.Size = new System.Drawing.Size(47, 15);
         this._lblMedian.TabIndex = 6;
         this._lblMedian.Text = "Median:";
         // 
         // _lblTotalPixelsValue
         // 
         this._lblTotalPixelsValue.Location = new System.Drawing.Point(432, 16);
         this._lblTotalPixelsValue.Name = "_lblTotalPixelsValue";
         this._lblTotalPixelsValue.Size = new System.Drawing.Size(64, 14);
         this._lblTotalPixelsValue.TabIndex = 5;
         // 
         // _lblTotalPixels
         // 
         this._lblTotalPixels.Location = new System.Drawing.Point(368, 16);
         this._lblTotalPixels.Name = "_lblTotalPixels";
         this._lblTotalPixels.Size = new System.Drawing.Size(72, 15);
         this._lblTotalPixels.TabIndex = 4;
         this._lblTotalPixels.Text = "Total Pixels:";
         // 
         // _lblLevelValue
         // 
         this._lblLevelValue.Location = new System.Drawing.Point(240, 17);
         this._lblLevelValue.Name = "_lblLevelValue";
         this._lblLevelValue.Size = new System.Drawing.Size(57, 15);
         this._lblLevelValue.TabIndex = 3;
         // 
         // _lblLevel
         // 
         this._lblLevel.Location = new System.Drawing.Point(192, 16);
         this._lblLevel.Name = "_lblLevel";
         this._lblLevel.Size = new System.Drawing.Size(35, 15);
         this._lblLevel.TabIndex = 2;
         this._lblLevel.Text = "Level:";
         // 
         // _lblMeanValue
         // 
         this._lblMeanValue.Location = new System.Drawing.Point(64, 18);
         this._lblMeanValue.Name = "_lblMeanValue";
         this._lblMeanValue.Size = new System.Drawing.Size(48, 14);
         this._lblMeanValue.TabIndex = 1;
         // 
         // _lblMean
         // 
         this._lblMean.Location = new System.Drawing.Point(10, 17);
         this._lblMean.Name = "_lblMean";
         this._lblMean.Size = new System.Drawing.Size(38, 15);
         this._lblMean.TabIndex = 0;
         this._lblMean.Text = "Mean:";
         // 
         // _btnClose
         // 
         this._btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this._btnClose.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this._btnClose.Location = new System.Drawing.Point(216, 328);
         this._btnClose.Name = "_btnClose";
         this._btnClose.TabIndex = 7;
         this._btnClose.Text = "&Close";
         this._btnClose.Click += new System.EventHandler(this._btnClose_Click);
         // 
         // _lblView
         // 
         this._lblView.Location = new System.Drawing.Point(392, 8);
         this._lblView.Name = "_lblView";
         this._lblView.Size = new System.Drawing.Size(32, 16);
         this._lblView.TabIndex = 2;
         this._lblView.Text = "&View:";
         // 
         // HistogramDialog
         // 
         this.AcceptButton = this._btnClose;
         this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
         this.CancelButton = this._btnClose;
         this.ClientSize = new System.Drawing.Size(522, 359);
         this.Controls.Add(this._lblView);
         this.Controls.Add(this._btnClose);
         this.Controls.Add(this._groupBox2);
         this.Controls.Add(this._groupBox1);
         this.Controls.Add(this._lblHistogram);
         this.Controls.Add(this._cbView);
         this.Controls.Add(this._cbChannel);
         this.Controls.Add(this._lblChannel);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "HistogramDialog";
         this.ShowInTaskbar = false;
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "Histogram Dialog";
         this._groupBox1.ResumeLayout(false);
         ((System.ComponentModel.ISupportInitialize)(this._numUDClipping)).EndInit();
         this._groupBox2.ResumeLayout(false);
         this.ResumeLayout(false);

      }
      #endregion

      private HistogramCommand _histogramCommand;
      private RasterImage _image;
      private float _maximumHistogramValue;

      private void InitClass(RasterImage image)
      {
         _image = image;
         _histogramCommand = new HistogramCommand();
         _histogramCommand.Channel = (HistogramCommandFlags)0;
         _histogramCommand.Run(_image);
         SetLabelsValues();

         _cbChannel.Items.Add("Master");
         _cbChannel.Items.Add("Red");
         _cbChannel.Items.Add("Green");
         _cbChannel.Items.Add("Blue");
         _cbChannel.SelectedIndex = 0;

         _cbView.Items.Add("Area");
         _cbView.Items.Add("Line");
         _cbView.SelectedIndex = 0;
      }

      private void _btnClose_Click(object sender, System.EventArgs e)
      {
         Close();
      }

      private void GetMaximumHistogramValue(ref float maximum, ref Int64 sumMean, ref Int64 totalPixels)

      {
         Int64[] histogramValues = _histogramCommand.Histogram;


         totalPixels = sumMean = histogramValues[0];

         int index;
         for(index = 1; index < 256; index++)
         {
            totalPixels += histogramValues[index];
            sumMean += histogramValues[index] * index;
            if(histogramValues[index] > (int)maximum)
               maximum = (float)histogramValues[index];
         }
      }

      private int GetMedianValue(Int64 totalSum)

      {
         Int64[] histogramValues = _histogramCommand.Histogram;
         Int64 sumMedian = 0;

         int index;

         for(index = 1; index < 256; index++)
         {
            sumMedian += histogramValues[index];

            if(sumMedian >= (int)(totalSum / 2))
               return index;
         }
         return 0;
      }

      private void SetLabelsValues( )
      {
         _maximumHistogramValue = _histogramCommand.Histogram[0];

         Int64 sumMean = 0;
         Int64 totalPixels = 0;

         GetMaximumHistogramValue(ref _maximumHistogramValue, ref sumMean, ref totalPixels);

         _lblMedianValue.Text = (GetMedianValue(totalPixels)).ToString();
         _lblTotalPixelsValue.Text = totalPixels.ToString();
         _lblMeanValue.Text = ((float)sumMean / totalPixels).ToString();
      }

      private void _cbChannel_SelectedIndexChanged(object sender, System.EventArgs e)
      {
         _histogramCommand.Channel = (HistogramCommandFlags)_cbChannel.SelectedIndex;
         _histogramCommand.Run(_image);
         SetLabelsValues();

         _lblHistogram.Invalidate(null, true);
      }

      private void _lblHistogram_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
      {
         Int64[] histogramValues = _histogramCommand.Histogram;

         int index = e.X / 2;

         if (index >= histogramValues.Length || index < 0)
            return;

         _lblLevelValue.Text = index.ToString();
         _lblCountValue.Text = (histogramValues[index]).ToString();
         int tempI = (int)(e.X / 510.0 * 10000);
         _lblPercentileValue.Text = (((float)tempI / 100).ToString() + "%");
      }

      private void _cbView_SelectedIndexChanged(object sender, System.EventArgs e)
      {
         _lblHistogram.Invalidate(null, true);
      }

      private void _lblHistogram_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
      {
         Pen pen;

         switch(_cbChannel.SelectedIndex)
         {
            case 1:
               pen = new Pen(Color.Red, 2);
               break;
            case 2:
               pen = new Pen(Color.Green, 2);
               break;
            case 3:
               pen = new Pen(Color.Blue, 2);
               break;
            default:
               pen = new Pen(Color.Black, 2);
               break;
         }

         e.Graphics.Clear(SystemColors.Control);

         float yViewValue;
         float xViewValue;
         Int64[] histogramValues = _histogramCommand.Histogram;

         Point previousPoint = new Point(0, _lblHistogram.Height);
         int index;
         for(index = 0; index < 256; index++)
         {
            if(_numUDClipping.Value != 100)
               yViewValue = (float)Math.Min(_lblHistogram.Height, (histogramValues[index] / ((1.0 - (float)_numUDClipping.Value / 100.0) * _maximumHistogramValue)) * _lblHistogram.Height + 0.5);
            else
               yViewValue = _lblHistogram.Height;

            xViewValue = index * 2;

            if(_cbView.SelectedIndex == 0)
               e.Graphics.DrawLine(pen, xViewValue, _lblHistogram.Height, xViewValue, _lblHistogram.Height - yViewValue);
            else
            {
               Point currectPoint = new Point(0);

               currectPoint.X = (int)xViewValue;
               currectPoint.Y = (int)(_lblHistogram.Height - yViewValue);
               e.Graphics.DrawLine(pen, previousPoint, currectPoint);
               previousPoint = currectPoint;
            }
         }
      }

      private void _numUDClipping_ValueChanged(object sender, System.EventArgs e)
      {
         _lblHistogram.Invalidate(null, true);
      }
   }
}

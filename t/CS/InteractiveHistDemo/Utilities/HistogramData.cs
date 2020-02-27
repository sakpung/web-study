// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Drawing;
using System.Collections.Generic;
using System.Text;

using Leadtools;
using Leadtools.ImageProcessing;
using Leadtools.ImageProcessing.Color;
using Leadtools.ImageProcessing.Effects;

namespace InteractiveHist
{
   public enum MovePoint
   {
      None      = 0,
      Start     = 1,
      End       = 3,
      NewStart  = 4,
      NewEnd    = 5,
   }

   public enum FilterNoiseReplaceType
   {
      StartEndPoints          = 0,
      MinimumMaximumIntensity = 1,
      ReplaceColor            = 2,
      Zero                    = 4,
   }

   public struct MovingLine
   {
      public int position;
      public MovingLine(Color clr)
      {
         color = clr;
         position = 0;
      }
      private Color color;
   }

   public struct HistogramLabel
   {
      public Rectangle paint;
      public MovePoint moveType;
      public bool zoomed;
      public int penWidth;
      public int mousePosition;
      public int startRange;
      public int endRange;
      public int[] drawHistogram;
      public int drawStartRange;
      public int drawEndRange;
      public int histogramLength;
      public int drawLength;
   }

   public struct Segmentation
   {
      public MovingLine startLine;
      public MovingLine endLine;
   }

   public struct GrayDistribution
   {
      public MovingLine startLine;
      public MovingLine endLine;
   }

   public struct FilterNoise
   {
      public MovingLine startLine;
      public MovingLine endLine;
   }

   public struct Rescaling
   {
      public MovingLine startLine;
      public MovingLine endLine;
      public MovingLine newStartLine;
      public MovingLine newEndLine;
      public MovingLine prevEndHist;
   }

   public struct ChannelData
   {
#if LEADTOOLS_V175_OR_LATER
      public Int64[] orginalHistogram;
#else
      public int[] orginalHistogram;
#endif
      public Color innerColor;
      public Color outerColor;
      public Segmentation segmentation;
      public GrayDistribution grayDistribution;
      public FilterNoise filterNoise;
      public Rescaling rescale;
      public RasterColor[] RGBLUTSegment;
      public RasterColor[] RGBLUTGray;
      public RasterColor[] RGBPrevLUT;
      public int[] LUTSegment;
      public int[] LUTGray;
      public int[] LUTFilter;
      public int[] LUTRescale;
      public int minHistogramValue;
      public int maxHistogramValue;
/*
 * public int[] LUTDrawSegment;
 * public int[] LUTDrawGray;
 * public int[] LUTDrawfilter;
 * public int[] LUTDrawRescale;
 * 
 */
  }

   public struct InteractiveHistogramDialogData
   {
      public RasterImage image;
      public RasterImage originalImage;
      public RasterImage savedImage;
      public RasterImage undoImage;
      public Rectangle view;
      public RasterColorChannel channel;
      public HistogramLabel histogramLabel;
      public ChannelData[] cD;
      public int scale;
      public bool fullView;
      public int minimumValue;
      public int maximumValue;
      public bool pushed;
      public int distance;
      public bool signed;
      public RasterColor[] originalLUT;
      public bool histogramAvaliable;
      public bool gradient;
      public bool shift;
      public bool shiftRight;
      public bool getHistogram;
      public bool grayLUT;
      public bool letApplyOnPallete;

      // Segmentation variables...
      public RasterColor segmentStartColor;
      public RasterColor segmentEndColor;

      // Gray Distribution Variables...
      public FunctionalLookupTableFlags grayFunctionType;
      public int grayFactor;
      public RasterColor grayStartColor;
      public RasterColor grayEndColor;
      public int grayCenter;
      public int grayWidth;
      public bool graySelectionOnly;
      public bool grayPredefinedPalette;
      public RasterColor[] predefinedPalette;

      // Filter (Noise) Variables...
      public FilterNoiseReplaceType noiseReplaceType;
      public int noiseMinIntensity;
      public int noiseMaxIntensity;
      public RasterColor noiseReplaceColor;
      public int numberofPallet;
      public bool[] applyInProgress;

      // Rescaling Variables...
      public int rescaleShiftAmount;

   }
}

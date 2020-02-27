// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Leadtools.Dicom;
using System.Drawing;

namespace Leadtools.Medical.WebViewer.Addins
{
   /// <summary>
   /// 
   /// </summary>
   class WaveFormGroupExtractor
   {
      public static DicomWaveformGroup GetWaveForm(DicomDataSet ds)
      {
         int WaveformGroupCount = ds.WaveformGroupCount;

         if (0 == WaveformGroupCount)
         {
            return null;
         }

         return ds.GetWaveformGroup(0);
      }
   }

   class DicomWaveFormDepictor
   {
      public int CellHeight
      {
         get { return (int)((double)PageHeight / (double)NumVerPoints); }
      }
      public int CellWidth
      {
         get { return (int)((double)PageWidth / (double)NumHorzPoints); }
      }

      public int PageWidth = 640;
      public int PageHeight = 360;
      public int NumVerPoints = 50;
      public int NumHorzPoints = 50;
      public int RibbonWidth = 0;
      public int FrameWidth = 100;

      public RasterImage Depict(DicomWaveformGroup CurrentWaveformGroup)
      {
         RasterImage ri = new RasterImage(RasterMemoryFlags.Conventional, PageWidth, PageHeight, 24, RasterByteOrder.Bgr, RasterViewPerspective.BottomLeft, null, null, 0);

         using (Leadtools.Drawing.RasterImageGdiPlusGraphicsContainer GraphicsContainer = new Leadtools.Drawing.RasterImageGdiPlusGraphicsContainer(ri))
         {
            _DrawWaveformBackground(GraphicsContainer.Graphics);
            _DrawWaveform(GraphicsContainer.Graphics, CurrentWaveformGroup, PageWidth, PageHeight, FrameWidth);
         }

         return ri;
      }

      private void _DrawWaveformBackground(Graphics g)
      {
         // Draw grid
         g.FillRectangle(Brushes.Black, new RectangleF(0, 0, PageWidth, PageHeight));

         // Horizontal lines
         using (var pen = new Pen(Color.FromArgb(50, 50, 50)))
         {
            int y;
            for (int i = 0; i < NumHorzPoints; i++)
            {
               y = (i * CellHeight) + CellHeight;
               g.DrawLine(pen, new Point(0, y), new Point(PageWidth, y));
            }
            // Vertical Lines
            int x;
            for (int i = 0; i < NumVerPoints; i++)
            {
               x = (i * CellWidth) + RibbonWidth;
               g.DrawLine(pen, new Point(x, 0), new Point(x, PageHeight));
            }
         }
      }

      private void _DrawWaveform(Graphics g, DicomWaveformGroup CurrentWaveformGroup, int PageWidth, int PageHeight, int FrameWidth)
      {
         if (CurrentWaveformGroup == null)
            return;

         // Get number of channels
         int nChannelsCount = CurrentWaveformGroup.ChannelCount;
         if (nChannelsCount == 0)
         {
            return;
         }

         // How many samples do we have in a channel
         int nSamplesPerChannel = CurrentWaveformGroup.GetNumberOfSamplesPerChannel();
         if (nSamplesPerChannel == 0)
         {
            return;
         }

         int[] nAllData;
         int nSampleIndex, nChannelIndex;
         int iMaxVal, iMinVal;
         double dExtent = 0;
         double dVertStep = 0;
         RectangleF DrawTextRect;

         int nViewRectHeight = PageHeight - FrameWidth;
         int nViewRectWidth = PageWidth;

         DicomCodeSequenceItem ChannelSource;

         iMaxVal = -32768;
         iMinVal = 32767;

         // Find the minimum and maximum value for all the channels
         for (nChannelIndex = 0; nChannelIndex < nChannelsCount; nChannelIndex++)
         {
            nAllData = CurrentWaveformGroup.GetChannel(nChannelIndex).GetChannelSamples();

            for (nSampleIndex = 0; nSampleIndex < nSamplesPerChannel; nSampleIndex++)
            {
               if (nAllData[nSampleIndex] > iMaxVal)
               {
                  iMaxVal = nAllData[nSampleIndex];
               }
               else if (nAllData[nSampleIndex] < iMinVal)
               {
                  iMinVal = nAllData[nSampleIndex];
               }
            }

            dVertStep = nViewRectHeight / nChannelsCount;
            dExtent = ((iMaxVal - iMinVal) * 1.2) / dVertStep;
         }

         int nIndex = 0;
         string strText;
         DicomWaveformAnnotation ann;
         long lStartPoint;

         // Loop through the channels one by one
         for (nChannelIndex = 0; nChannelIndex < nChannelsCount; nChannelIndex++)
         {
            strText = "";
            nIndex = nChannelsCount - nChannelIndex - 1;

            //Get the data for this channel
            nAllData = CurrentWaveformGroup.GetChannel(nIndex).GetChannelSamples();
            lStartPoint = ((nViewRectHeight + (int)((double)((nChannelIndex) * -1 * (int)dVertStep) - (nAllData[0] - iMinVal) / dExtent))) + FrameWidth / 2;


            // Get the channel source
            ChannelSource = CurrentWaveformGroup.GetChannel(nIndex).GetChannelSource();

            DrawTextRect = new RectangleF(5, lStartPoint, FrameWidth - 5, (float)dVertStep);

            if ((ChannelSource != null) && (ChannelSource.CodeMeaning != null))
            {
               // Display the channel source
               strText = ChannelSource.CodeMeaning;
               if (CurrentWaveformGroup.GetChannel(nIndex).GetAnnotationCount() > 0)
               {
                  // Display the channel annotation
                  ann = CurrentWaveformGroup.GetChannel(nIndex).GetAnnotation(0);
                  if (ann != null)
                  {
                     if ((ann.UnformattedTextValue != null) && (ann.UnformattedTextValue != ""))
                     {
                        strText += " (";
                        strText += ann.UnformattedTextValue;
                        strText += ")";
                     }
                     else
                     {
                        if ((ann.CodedName != null) && ((ann.CodedName.CodeMeaning != null) && ann.CodedName.CodeMeaning != ""))
                        {
                           strText += " (";
                           strText += ann.CodedName.CodeMeaning;
                           strText += ")";
                        }
                     }
                  }
               }

               using (var font = new Font(FontFamily.GenericSansSerif, 8))
               {
                  g.DrawString(strText, font, Brushes.Red, DrawTextRect);
               }
            }

            int nDiff;
            double dRatio;
            int nOffset;

            // Draw the points/lines for this channel
            Point ptPreviousPoint, ptCurrentPoint;
            ptPreviousPoint = new Point(FrameWidth, (int)lStartPoint);

            using (var pen = new Pen(Color.FromArgb(0, 255, 0)))
            {
               for (nSampleIndex = 1; nSampleIndex < nSamplesPerChannel; nSampleIndex++)
               {
                  nDiff = nAllData[nSampleIndex] - iMinVal;
                  dRatio = (double)nDiff / dExtent;
                  nOffset = FrameWidth / 2;

                  ptCurrentPoint = new Point(
                      (nSampleIndex * nViewRectWidth / nSamplesPerChannel) + FrameWidth,
                      ((nViewRectHeight + (int)(((double)(nChannelIndex) * -1 * dVertStep) - dRatio))) + nOffset);


                  g.DrawLine(pen, ptPreviousPoint, ptCurrentPoint);


                  ptPreviousPoint = ptCurrentPoint;
               }
            }
         }
      }
   }
}

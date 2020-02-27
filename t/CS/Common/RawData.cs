// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using Leadtools;

namespace Leadtools.Demos
{
   public struct RawData
   {
      public static RawData Default
      {
         get
         {
            RawData data = new RawData();
            data.Width = 2560;
            data.Height = 3500;
            data.BitsPerPixel = 24;
            data.ViewPerspective = RasterViewPerspective.TopLeft;
            data.Order = RasterByteOrder.Bgr;
            data.XResolution = 300;
            data.YResolution = 300;
            data.Offset = 0;
            data.Padding = false;
            data.ReverseBits = true;
            data.Format = RasterImageFormat.Raw;
            data.FixedPalette = false;
            data.PaletteEnabled = false;
            data.WhiteOnBlack = false;
            return data;
         }
      }

      public int Width;                               // Width of image
      public int Height;                              // Height of image
      public int BitsPerPixel;                        // Bits per pixel of image--if palettized, a gray palette is generated
      public RasterViewPerspective ViewPerspective;   // View perspective of raw data (TopLeft, BottomLeft, etc)
      public RasterByteOrder Order;                   // Rgb or Bgr
      public int XResolution;                         // Horizontal resolution in DPI
      public int YResolution;                         // Vertical resolution in DPI
      public int Offset;                              // Offset into file where raw data begins
      public bool Padding;                            // true if each line of data is padded to four bytes
      public bool ReverseBits;                        // true if the bits of each byte are reversed 
      public RasterImageFormat Format;                // Raw Format.
      public bool FixedPalette;                       // Determine the Palette type (0 for grayscale palette and 1 for Leadtools fixed palette)
      public bool PaletteEnabled;                     // Determine if the Palette is enabled for this format.
      public bool WhiteOnBlack;                       // Color order white on black
   }
}

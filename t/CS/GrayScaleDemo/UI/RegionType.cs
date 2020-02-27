// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************


namespace GrayScaleDemo
{
    public enum RegionType
    {
        NONE = 0,
        RECTANGLE = 10,
        ROUND_RECTANGLE = 1,
        ELLIPSE =2,
        FREE_HAND =3,
        MAGIC_WAND =4,
        AUTO_SEGMENT = 5,
        ADD_BORDER_TO_REGION = 6,
        FAST_MAGIC_WAND =7
    }

    public struct ImageStatisticsInformation
    {
        public int TotalPixelCount;
        public int Minimum;
        public int Maximum;
        public double Mean;
        public double Median;
    }

    public enum SeparationType
    {
        RGB =0,
        CMYK =1,
        HSV=2,
        HLS=3,
        CMY=4,
        ALPHA=5,
        YUV =6,
        XYZ =7,
        LAB = 8,
        YCRCB = 9,
        SCT =10
    }

    public enum ImageCategory
    {
        GrayScale_8_12_16_BPP =0,
        OneBitImage =1,
        ColoredImage = 2,
        GrayScale_32_48_BPP =3
    }

    public enum MergeType
    {
        Rgb = 0,
        Cmyk = 1,
        Hsv = 2,
        Hls = 3,
        Cmy = 4,
        Yuv = 5,
        Xyz = 6,
        Lab = 7,
        YcrCb = 8,
        Sct = 9
    }

    public enum PressedButton
    {
       RigthBotton = 0,
       LeftBotton = 1,
       None =2
    }
}

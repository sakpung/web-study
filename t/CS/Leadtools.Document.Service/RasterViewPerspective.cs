// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************

using System.Runtime.Serialization;

namespace Leadtools.Document.Service
{
   [DataContract]
   public enum RasterViewPerspective
   {
      Unknown = 0,
      TopLeft = 1,
      BottomLeft180 = 2,
      TopRight = 2,
      TopLeft180 = 3,
      BottomRight = 3,
      BottomLeft = 4,
      BottomLeft90 = 5,
      LeftTop = 5,
      TopLeft90 = 6,
      RightTop = 6,
      BottomLeft270 = 7,
      RightBottom = 7,
      TopLeft270 = 8,
      LeftBottom = 8
   }
}

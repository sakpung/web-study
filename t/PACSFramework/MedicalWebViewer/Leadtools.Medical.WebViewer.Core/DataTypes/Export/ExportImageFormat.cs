// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Leadtools.Medical.WebViewer.DataContracts
{
   public class ExportImageFormat
   {
      public ExportImageFormat(string displayName, RasterImageFormat format, bool canReduceBitdepth, bool canPreserveBitdepth)
         : this(displayName, format, false, canReduceBitdepth, canPreserveBitdepth)
      { }

      public ExportImageFormat(string displayName, RasterImageFormat format, bool canCompress, bool canReduceBitdepth, bool canPreserveBitdepth)
      {
         DisplayName = displayName;
         Format = format;
         CanCompress = canCompress;

         CanReduceBitdepth = canReduceBitdepth;
         CanPreserveBitdepth = canPreserveBitdepth;
      }

      public RasterImageFormat Format { get; set; }
      public string DisplayName { get; set; }
      public bool CanCompress { get; set; }
      public bool CanReduceBitdepth { get; set; }
      public bool CanPreserveBitdepth { get; set; }

      public override bool Equals(object obj)
      {
         if (!(obj is ExportImageFormat))
         {
            return false;
         }
         else
         {
            return DisplayName == ((ExportImageFormat)obj).DisplayName;
         }
      }
      public override int GetHashCode()
      {
         if (null != DisplayName)
         {
            return DisplayName.GetHashCode();
         }
         else
         {
            return base.GetHashCode();
         }
      }
   }
}

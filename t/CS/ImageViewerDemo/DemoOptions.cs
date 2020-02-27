// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;

namespace ImageViewerDemo
{
   // Options for this demo
   // Can be serializer/deserializer to the local application data so data is re-restored between sessions
   public class DemoOptions
   {
      public DemoOptions()
      {
         this.UseVirtiualizer = true;
         this.UseSVG = true;
      }

      public DemoOptions Clone()
      {
         var result = new DemoOptions();
         result.UseVirtiualizer = this.UseVirtiualizer;
         result.UseSVG = this.UseSVG;
         return result;
      }

      // Use Virtualizer
      public bool UseVirtiualizer { get; set; }

      // Use SVG when supported
      public bool UseSVG { get; set; }
   }
}

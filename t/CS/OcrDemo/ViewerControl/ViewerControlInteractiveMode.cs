// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Text;

namespace OcrDemo.ViewerControl
{
   /// <summary>
   /// The current interactive mode (using the mouse on) of the viewer control
   /// </summary>
   public enum ViewerControlInteractiveMode
   {
      /// <summary>
      /// None
      /// </summary>
      SelectMode,
      /// <summary>
      /// Pan mode
      /// </summary>
      PanMode,
      /// <summary>
      /// Zoom to selection mode
      /// </summary>
      ZoomToSelectionMode,
      /// <summary>
      /// Draw new zone mode
      /// </summary>
      DrawZoneMode
   }
}

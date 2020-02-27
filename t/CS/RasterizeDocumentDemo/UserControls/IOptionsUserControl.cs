// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

using Leadtools;
using Leadtools.Codecs;

namespace RasterizeDocumentDemo.UserControls
{
   // Used in all the options user controls
   public interface IOptionsUserControl
   {
      void SetData(RasterCodecs rasterCodecsInstance);
      bool GetData(RasterCodecs rasterCodecsInstance);
   }
}

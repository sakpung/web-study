// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

using Leadtools;
using Leadtools.Controls;
using Leadtools.Pdf;
using Leadtools.Svg;

namespace PDFFormsDemo
{
   public class PDFPageItem : ImageViewerItem
   {
      public SvgDocument PageSVG
      {
         get;
         set;
      }

      public RasterImage PageImage
      {
         get;
         set;
      }

      public IList<FormFieldControl> FormControls
      {
         get;
         set;
      }

      public IList<PDFFormField> FormFields
      {
         get;
         set;
      }
   }
}

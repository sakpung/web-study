// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using Leadtools.Annotations.Engine;
using System.Globalization;
using System.Drawing;

namespace Leadtools.Annotations.WinForms
{
   // This class is responsible to convert AnnFont To/From System.Drawing.Font, 
   // to be edited in the property grid. The default font family and size are Arial and 12 pts.
   public class FontConverter : TypeConverter
   {
      public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
      {
         return base.CanConvertTo(context, destinationType);
      }

      public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
      {
         if (sourceType == typeof(string))
            return true;

         return base.CanConvertFrom(context, sourceType);
      }

      public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
      {
         AnnFont annFont = value as AnnFont;

         if (annFont != null)
         {
            return Leadtools.Annotations.Rendering.AnnWinFormsRenderingEngine.ToFont(annFont);
         }
         else
         {
            return Leadtools.Annotations.Rendering.AnnWinFormsRenderingEngine.ToFont(new AnnFont("Arial", 12));
         }
      }

      public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
      {
         if (destinationType == typeof(AnnFont))
            return Leadtools.Annotations.Rendering.AnnWinFormsRenderingEngine.FromFont(value as Font);

         return base.ConvertTo(context, culture, value, destinationType);
      }
   }
}

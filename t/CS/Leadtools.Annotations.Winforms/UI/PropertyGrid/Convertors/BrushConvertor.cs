// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.ComponentModel;
using Leadtools.Annotations.Engine;
using System.Drawing;
using System.Globalization;

namespace Leadtools.Annotations.WinForms
{
   //This class is responsible convert AnnSolidColorBrushConverter To/From System.Drawing.Color, 
   // to be edited in the property grid
   public class BrushConverter : TypeConverter
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
         if (value is AnnHatchBrush)
         {
            return (value as AnnHatchBrush).HatchStyle.ToString();
         }

         AnnSolidColorBrush solidBrush = value as AnnSolidColorBrush;
         if (solidBrush != null)
         {
            return ColorTranslator.FromHtml(solidBrush.Color);
         }
         else 
         {
            return Color.FromKnownColor(KnownColor.Transparent);
         }
      }

      public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
      {
         if (destinationType == typeof(AnnBrush))
         {
            AnnSolidColorBrush solidColorBrush = new AnnSolidColorBrush();
            solidColorBrush.Color = ColorTranslator.ToHtml((Color)value);
            return solidColorBrush;
         }

         return base.ConvertTo(context, culture, value, destinationType);
      }
   }
}

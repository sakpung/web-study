// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.IO;
using System.Drawing;
using Leadtools.Annotations.Engine;
using System.Globalization;

namespace Leadtools.Annotations.WinForms
{
   public class MediaConverter : TypeConverter
   {
      private AnnMedia _defaultValue;

      public MediaConverter()
      {
      }

      public MediaConverter(AnnMedia defaultValue)
      {
         _defaultValue = defaultValue;
      }

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
         AnnMedia media = null;

         AnnMedia annMedia = value as AnnMedia;
         if (annMedia != null)
         {
            media = annMedia;
         }
         else
         {
            string str = value as string;
            if (str != null)
            {
               media = new AnnMedia();
               media.Source1 = str;
            }
            else if (_defaultValue != null)
            {
               media = _defaultValue;
            }
         }

         if (media != null)
            return media.Source1;
         else
            return null;
      }

      public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
      {
         if (destinationType == typeof(AnnMedia))
         {
            AnnMedia media = new AnnMedia();
            media.Source1 = value != null ? value.ToString() : null;
            return media;
         }

         return base.ConvertTo(context, culture, value, destinationType);
      }
   }
}

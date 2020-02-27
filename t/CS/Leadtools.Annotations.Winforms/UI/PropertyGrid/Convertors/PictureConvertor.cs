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
   // This class is responsible to convert AnnPicture To/From System.Drawing.Bitmap, 
   // to be edited in the property grid.
   public class PictureConverter : TypeConverter
   {
      public PictureConverter()
      {
      }

      private AnnPicture _defaultValue;

      public PictureConverter(AnnPicture defaultValue)
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

      // Convert AnnPicture to System.Drawing.Bitmap.
      public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
      {
         AnnPicture picture = null;
         AnnPicture annPicture = value as AnnPicture;
         if (annPicture != null)
         {
            picture = annPicture;
         }
         else if (_defaultValue != null)
         {
            picture = _defaultValue;
         }

         if (picture != null)
         {
            using (MemoryStream ms = new MemoryStream(Convert.FromBase64String(picture.PictureData)))
            {
               return Bitmap.FromStream(ms);
            }
         }
         else
         {
            return null;
         }
      }

      // Convert System.Drawing.Bitmap to AnnPicture.
      public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
      {
         if (destinationType == typeof(AnnPicture))
         {
            using (MemoryStream ms = new MemoryStream())
            {
               Bitmap bitmap = value as Bitmap;
               if (bitmap != null)
               {
                  bitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                  return new AnnPicture(ms.ToArray());
               }
            }
         }

         return base.ConvertTo(context, culture, value, destinationType);
      }
   }
}

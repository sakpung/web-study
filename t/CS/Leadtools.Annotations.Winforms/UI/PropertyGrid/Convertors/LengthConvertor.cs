// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using Leadtools;
using System.Globalization;

namespace Leadtools.Annotations.WinForms
{
   // This class is responsible to convert LeadLengthD To/From double, 
   // to be edited in the property grid.
   public class LengthConverter : TypeConverter
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
         LeadLengthD length = (LeadLengthD)value;

         return length.Value;
      }

      public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
      {
         if (destinationType == typeof(LeadLengthD))
            return value;
         else
            return base.ConvertTo(context, culture, value, destinationType);
      }
   }
}

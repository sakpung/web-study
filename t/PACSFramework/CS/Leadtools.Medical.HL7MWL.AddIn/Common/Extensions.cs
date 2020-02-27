// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Data;
using Leadtools.Medical.HL7.V2x.Models;

namespace Leadtools.Medical.HL7MWL.AddIn
{
   internal static class Extensions
   {
      public static string Read(this Field field, int subfield)
      {
         if (null == field)
            return string.Empty;

         var f = field.DeepValue?.ToString();

         if(!string.IsNullOrEmpty(f))
         {
            f = f.Split('^')[0];
         }
         return f;
      }

      public static string Read(this Field field)
      {
         if (null == field)
            return string.Empty;

         return field.DeepValue?.ToString();
      }

      public static string Read(this Field[] fields)
      {
         if (null == fields)
            return string.Empty;
         if(fields.Length==0)
            return string.Empty;
         return fields[0].DeepValue?.ToString();
      }

      public static List<string> ReadAsList(this Field field)
      {
         if (null == field)
            return null;
         
         var val = field.DeepValue?.ToString();
         if (!string.IsNullOrEmpty(val))
         {
            var lst = new List<string>();
            lst.Add(val);
            return lst;
         }
         return null;
      }


      private static List<PropertyInfo> GetMatchingProperties(object source, object target)
      {
         if (source == null)
            throw new ArgumentNullException("source");

         if (target == null)
            throw new ArgumentNullException("target");

         var sourceType = source.GetType();
         var sourceProperties = sourceType.GetProperties();
         var targetType = target.GetType();
         var targetProperties = targetType.GetProperties();
         var properties = (from s in sourceProperties
                           from t in targetProperties
                           where s.Name == t.Name &&
                                 s.PropertyType == t.PropertyType
                           select s).ToList();

         return properties;
      }

      public static T EnumParse<T>(this string value)
      {
         return EnumParse<T>(value, false);
      }

      public static T EnumParse<T>(this string value, bool ignoreCase)
      {
         if (value == null)
         {
            throw new ArgumentNullException("value");
         }

         value = value.Trim();
         if (value.Length == 0)
         {
            throw new ArgumentException("Must specify valid information for parsing the string.", "value");
         }

         Type t = typeof(T);

         if (!t.IsEnum)
         {
            throw new ArgumentException("Type provided must be an Enum.", "T");
         }

         T enumType = (T)Enum.Parse(t, value, ignoreCase);

         return enumType;
      }
   }

}

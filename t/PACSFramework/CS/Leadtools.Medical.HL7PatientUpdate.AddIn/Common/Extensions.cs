using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Data;
using Leadtools.Medical.HL7.V2x.Models;

namespace Leadtools.Medical.HL7PatientUpdate.AddIn
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

      public static void CopyTo<T>(this object source, T dest)
      {
         if (source == null)
            throw new ArgumentNullException("source", "The object you are copying from cannot be null");

         if (dest == null)
            throw new ArgumentNullException("dest", "The object you are copying to cannot be null");

         // Don't copy if they are the same object
         if (!ReferenceEquals(source, dest))
         {
            List<PropertyInfo> matches = GetMatchingProperties(source, dest);

            foreach (PropertyInfo fromProperty in matches)
            {
               PropertyInfo toProperty = dest.GetType().GetProperty(fromProperty.Name);
               object value = null;

               if (source is DataRow)
               {
                  DataRow row = source as DataRow;

                  if (row[fromProperty.Name] != null)
                     value = row[fromProperty.Name];
               }
               else
               {
                  value = fromProperty.GetValue(source, null);
               }

               if (value == DBNull.Value)
                  value = null;
               toProperty.SetValue(dest, value, null);
            }
         }
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

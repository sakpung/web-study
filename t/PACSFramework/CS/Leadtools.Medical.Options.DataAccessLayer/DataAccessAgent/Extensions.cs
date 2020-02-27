// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using System.IO;
using System.Xml;
using System.ComponentModel;

#if DNXCORE50
using Leadtools.Data;
using Leadtools.Practices.EnterpriseLibrary.Data;
using Leadtools.Practices.EnterpriseLibrary.Data.Sql;
#else
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
#endif

namespace Leadtools.Medical.OptionsDataAccessLayer
{
   public static class Extensions
   {
      public static T GetColumnValue<T>(this IDataReader reader, params string[] columnNames)
      {
         bool foundValue = false;
         T value = default(T);
         IndexOutOfRangeException lastException = null;

         foreach (string columnName in columnNames)
         {
            try
            {
               int ordinal = reader.GetOrdinal(columnName);
               value = (T)reader.GetValue(ordinal);
               foundValue = true;
            }
            catch (IndexOutOfRangeException ex)
            {
               lastException = ex;
            }
         }

         if (!foundValue)
         {
            string message = string.Format("Column(s) {0} could not be not found.",
                    string.Join(", ", columnNames));

            throw new IndexOutOfRangeException(message, lastException);
         }

         return value;
      }

      internal static string ToXml(this object value, params Type[] extraTypes)
      {
         XmlSerializer s = new XmlSerializer(value.GetType(), extraTypes);

         using (StringWriter writer = new StringWriter())
         {
            s.Serialize(writer, value);
            return writer.ToString();
         }
      }

      internal static T FromXml<T>(this string value, params Type[] extraTypes)
      {
         //if the string doesn't appear as an XML value, we try the converter first
         if (!string.IsNullOrEmpty(value) && !value.TrimStart().StartsWith("<"))
         {
            try
            {
               var parsed = ChangeType<T>(value);
               return parsed;
            }
            catch { }//fall through
         }

          //
          // This method may through and XMLException,  however that is valid in this context.
          // The older version of this method only worked with serialized XML values.  However, more recent
          // version allow you to set a specific value in the options table.  Thus if the method determines that
          // the string is not valid XML it will try to change it to the specified type.
          //
          try
          {
              XmlDocument doc = new XmlDocument();
              XmlSerializer s;

              doc.LoadXml(value);
              s = new XmlSerializer(typeof (T), extraTypes);

              using (StringReader reader = new StringReader(value))
              {
                  object obj = s.Deserialize(reader);
                  return (T) obj;
              }
          }
          catch
          {              
          }

          return ChangeType<T>(value);
      }

      public static T MergeLeft<T, K, V>(this T me, params IDictionary<K, V>[] others)
         where T : IDictionary<K, V>, new()
      {
          T newMap = new T();
          foreach (IDictionary<K, V> src in
              (new List<IDictionary<K, V>> { me }).Concat(others))
          {
              // ^-- echk. Not quite there type-system.
              foreach (KeyValuePair<K, V> p in src)
              {
                  newMap[p.Key] = p.Value;
              }
          }
          return newMap;
      }

      public static T ChangeType<T>(object value)
      {
          return (T)ChangeType(typeof(T), value);
      }
      public static object ChangeType(Type t, object value)
      {
          TypeConverter tc = TypeDescriptor.GetConverter(t);

          return tc.ConvertFrom(value);
      }
      public static void RegisterTypeConverter<T, TC>() where TC : TypeConverter
      {
#if !DNXCORE50
            TypeDescriptor.AddAttributes(typeof(T), new TypeConverterAttribute(typeof(TC)));
#endif
      }
   }
}

// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Xml.Serialization;
using System.IO;

namespace Leadtools.DataAccessLayers
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

               if (reader.GetValue(ordinal) == DBNull.Value)
                   value = default(T);
               else
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
         XmlSerializer s = new XmlSerializer(typeof(T), extraTypes);

         using (StringReader reader = new StringReader(value))
         {
            object obj = s.Deserialize(reader);
            return (T)obj;
         }
      }

      // Works in C#3/VS2008:
      // Returns a new dictionary of this ... others merged leftward.
      // Keeps the type of 'this', which must be default-instantiable.
      // Example: 
      //   result = map.MergeLeft(other1, other2, ...)
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
   }   
}

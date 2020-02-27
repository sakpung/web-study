// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

#if (LEADTOOLS_V19_OR_LATER_MEDICAL_EXTERNAL_STORE) || (LEADTOOLS_V19_OR_LATER)
using System.ComponentModel;
#endif

namespace Leadtools.Medical.Winforms
{
   public static class Extensions
   {
      public static T Clone<T>(this T obj)
      {
         using (var ms = new MemoryStream())
         {
            var formatter = new BinaryFormatter();
            formatter.Serialize(ms, obj);
            ms.Position = 0;

            return (T)formatter.Deserialize(ms);
         }
      }

      public static void AddIfNotPresent<TKey, TValue>(this Dictionary<TKey, TValue> dict, TKey key, TValue value)
      {
         if (!dict.ContainsKey(key))
         {
            dict.Add(key, value);
         }
      }

#if (LEADTOOLS_V19_OR_LATER_MEDICAL_EXTERNAL_STORE) || (LEADTOOLS_V19_OR_LATER)
      public static string Description(this Enum enumValue)
      {
         var enumType = enumValue.GetType();
         var field = enumType.GetField(enumValue.ToString());
         var attributes = field.GetCustomAttributes(typeof(DescriptionAttribute), false);
         return attributes.Length == 0
             ? enumValue.ToString()
             : ((DescriptionAttribute)attributes[0]).Description;
      }
#endif

      public static string MyTrim(this string str)
      {
         if (string.IsNullOrEmpty(str))
         {
            return string.Empty;
         }

         return str.Trim();
      }
   }
}

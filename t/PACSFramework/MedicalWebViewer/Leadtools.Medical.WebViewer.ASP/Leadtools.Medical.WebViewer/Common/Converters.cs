// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;

namespace Leadtools.Medical.WebViewer.Common
{
   static class ParseTools
   {
      //handle cases when dynamic object is a token not an object
      public static T ToObject<T>(JToken token)
      {
         if (token != null)
         {
            return token.ToObject<T>();
         }

         return default(T);
      }

      public static T ToObject<T>(JObject obj)
      {
         if (obj != null)
         {
            return obj.ToObject<T>();
         }

         return default(T);
      }

      public static int Int(string val, int def)
      {
         if (!string.IsNullOrEmpty(val))
         {
            int parsed;
            if (int.TryParse(val, out parsed))
            {
               return parsed;
            }
         }

         return def;
      }

      public static float Float(string val, float def)
      {
         if (!string.IsNullOrEmpty(val))
         {
            float parsed;
            if (float.TryParse(val, out parsed))
            {
               return parsed;
            }
         }

         return def;
      }

      public static byte[] ToByteArray(Stream stream)
      {
         byte[] buffer = new byte[32768];
         using (MemoryStream ms = new MemoryStream())
         {
            while (true)
            {
               int read = stream.Read(buffer, 0, buffer.Length);
               if (read <= 0)
                  return ms.ToArray();
               ms.Write(buffer, 0, read);
            }
         }
      }

      public static int IndexOf(byte[] searchWithin, byte[] serachFor, int startIndex)
      {
         int index = 0;
         int startPos = Array.IndexOf(searchWithin, serachFor[0], startIndex);

         if (startPos != -1)
         {
            while ((startPos + index) < searchWithin.Length)
            {
               if (searchWithin[startPos + index] == serachFor[index])
               {
                  index++;
                  if (index == serachFor.Length)
                  {
                     return startPos;
                  }
               }
               else
               {
                  startPos = Array.IndexOf<byte>(searchWithin, serachFor[0], startPos + index);
                  if (startPos == -1)
                  {
                     return -1;
                  }
                  index = 0;
               }
            }
         }

         return -1;
      }

      public static string ToString(byte[] data)
      {
         return System.Text.Encoding.UTF8.GetString(data);
      }

      public static Dictionary<string, string> ToDictionary(JArray source)
      {
         var dictionary = new Dictionary<string, string>();
         foreach (var item in source)
         {
            dictionary[item.Values().First().Value<string>()] = item.Values().Last().Value<string>();
         }
         return dictionary;
      }
   }


   public class IntNullableConverter : NullableConverter
   {
      public IntNullableConverter()
         : base(typeof(int?))
      {

      }

      public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
      {
         if (value is string)
         {
            if (string.IsNullOrEmpty((value as string)))
            {
               return null;
            }
            return base.ConvertFrom(context, culture, (value as string).Trim());
         }

         return base.ConvertFrom(context, culture, value);
      }
   }
}

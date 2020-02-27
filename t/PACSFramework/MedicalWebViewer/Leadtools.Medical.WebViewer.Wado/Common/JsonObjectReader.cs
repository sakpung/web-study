// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;

namespace Leadtools.Medical.WebViewer.Wado
{
   internal class JsonObjectReader
   {
      internal static IEnumerable<Dictionary<string, string>> ReadJsonObjects(Stream stm, Dictionary<string, string> prp)
      {
         if (null == stm)
            throw new ArgumentNullException("Unexpected <null> return value");

         if (stm.CanSeek)
         {
            if (stm.Length == 0)
               throw new ArgumentException("Stream length must be greater than 0");
         }

         var lst = new List<Dictionary<string, string>>();

         using (var rdr = new StreamReader(stm))
         {
            JArray results = JArray.Parse(rdr.ReadToEnd());

            foreach (var result in results)
            {
               var dic = new Dictionary<string, string>();
               var obj = JObject.Parse(result.ToString());

               foreach (var key in prp.Keys)
               {
                  try
                  {
                     var field = obj[key];
                     if (null != field)
                     {
                        var value = field["Value"];
                        if (null != value)
                        {
                           if (prp.ContainsKey(key))
                           {
                              var token = value[0].ToString();
                              var alpha = token.Contains("Alphabetic");
                              var Ideo = token.Contains("Ideographic");

                              if (alpha & Ideo)
                              {
                                 dic[prp[key]] = value[0]["Alphabetic"].ToString() +
                                    "   ( " + value[0]["Ideographic"].ToString() + " )";
                              }
                              else if (alpha)
                              {
                                 dic[prp[key]] = value[0]["Alphabetic"].ToString();
                              }
                              else
                              {
                                 dic[prp[key]] = token;
                              }
                           }
                        }
                     }
                  }
                  catch { }
               }

               lst.Add(dic);
            }
         }

         return lst;
      }
   }
}

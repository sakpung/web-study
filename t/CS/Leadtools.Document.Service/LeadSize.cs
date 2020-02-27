// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************

using Leadtools.Document.Service.Internal;
using Newtonsoft.Json.Linq;
using System.Runtime.Serialization;

namespace Leadtools.Document.Service
{
   [DataContract]
   public class LeadSize
   {
      [DataMember(Name = "width")]
      public double Width;
      [DataMember(Name = "height")]
      public double Height;

      public override string ToString()
      {
         if (IsEmpty)
            return "Empty";

         return string.Format("{0},{1}", Width, Height);
      }

      public static LeadSize Create(double width, double height)
      {
         var result = new LeadSize();
         result.Width = width;
         result.Height = height;

         return result;
      }

      public static LeadSize Empty
      {
         get { return _empty; }
      }

      public bool IsEmpty
      {
         get { return LeadDoubleTools.IsNaN(Width); }
      }

      private static readonly LeadSize _empty = CreateEmptySize();
      private const string _emptyString = "{\"width\": \"-Infinity\", \"height\": \"-Infinity\"}";

      private static LeadSize CreateEmptySize()
      {
         var result = new LeadSize();

         result.Width = LeadDoubleTools.NaN;
         result.Height = LeadDoubleTools.NaN;
         return result;
      }

      public string ToJSON()
      {
         if (IsEmpty)
            return _emptyString;

         return string.Format("{{\"width\": {0}, \"height\": {1}}}", Width, Height);
      }

      public static LeadSize FromJSON(string value)
      {
         var width = (double)JObject.Parse(value)["width"];
         if (LeadDoubleTools.IsInfinity(width) || LeadDoubleTools.IsNaN(width))
            return _empty;

         double height = (double)JObject.Parse(value)["height"];
         var result = new LeadSize();
         result.Width = width;
         result.Height = height;
         return result;
      }
   }
}

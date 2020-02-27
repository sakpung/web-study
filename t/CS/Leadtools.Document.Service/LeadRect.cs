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
   public class LeadRect
   {
      [DataMember(Name = "x")]
      public double X;
      [DataMember(Name = "y")]
      public double Y;
      [DataMember(Name = "width")]
      public double Width;
      [DataMember(Name = "height")]
      public double Height;

      public override string ToString()
      {
         if (IsEmpty)
            return "Empty";

         return string.Format("{0},{1},{2},{3}", X, Y, Width, Height);
      }

      private static readonly LeadRect _empty = CreateEmptyRect();
      private const string _emptyString = "{\"x\": \"-Infinity\", \"y\": \"-Infinity\", \"width\": \"-Infinity\", \"height\": \"-Infinity\"}";

      public static LeadRect Create(double x, double y, double width, double height)
      {
         var result = new LeadRect();
         result.X = x;
         result.Y = y;
         result.Width = width;
         result.Height = height;
         return result;
      }

      public static LeadRect FromLTRB(double left, double top, double right, double bottom)
      {
         double x;
         double width;
         if (right >= left)
         {
            x = left;
            width = right - left;
         }
         else
         {
            x = right;
            width = left - right;
         }

         double y;
         double height;
         if (bottom >= top)
         {
            y = top;
            height = bottom - top;
         }
         else
         {
            y = bottom;
            height = top - bottom;
         }

         return Create(x, y, width, height);
      }

      public double Left
      {
         get { return X; }
      }

      public double Top
      {
         get { return Y; }
      }

      public double Right
      {
         get
         {
            if (IsEmpty)
               return -1;

            return X + Width;
         }
      }

      public double Bottom
      {
         get
         {
            if (IsEmpty)
               return -1;

            return Y + Height;
         }
      }

      public static LeadRect Empty
      {
         get { return _empty; }
      }

      public bool IsEmpty
      {
         get { return LeadDoubleTools.IsNaN(Width); }
      }

      private static LeadRect CreateEmptyRect()
      {
         var result = new LeadRect();
         result.X = LeadDoubleTools.NaN;
         result.Y = LeadDoubleTools.NaN;
         result.Width = LeadDoubleTools.NaN;
         result.Height = LeadDoubleTools.NaN;
         return result;
      }

      public string ToJSON()
      {
         if (IsEmpty)
            return _emptyString;

         return string.Format("{{\"x\": {0}, \"y\": {1}, \"width\": {2}, \"height\": {3}}}", X, Y, Width, Height);
      }

      public static LeadRect FromJSON(string value)
      {
         var x = (double)JObject.Parse(value)["x"];
         if (LeadDoubleTools.IsInfinity(x) || LeadDoubleTools.IsNaN(x))
            return _empty;

         double y = (double)JObject.Parse(value)["y"];
         double width = (double)JObject.Parse(value)["width"];
         double height = (double)JObject.Parse(value)["height"];
         var result = new LeadRect();
         result.X = x;
         result.Y = y;
         result.Width = width;
         result.Height = height;
         return result;
      }
   }
}

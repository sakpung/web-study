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
   public class LeadPoint
   {
      [DataMember(Name = "x")]
      public double X;
      [DataMember(Name = "y")]
      public double Y;

      public override string ToString()
      {
         if (IsEmpty)
            return "Empty";

         return string.Format("{0},{1}", X, Y);
      }

      public static LeadPoint Create(double x, double y)
      {
         var result = new LeadPoint();
         result.X = x;
         result.Y = y;
         return result;
      }

      private static readonly LeadPoint _empty = CreateEmptyPoint();

      public static LeadPoint Empty
      {
         get { return _empty; }
      }

      public bool IsEmpty
      {
         get { return LeadDoubleTools.IsNaN(X); }
      }

      private static LeadPoint CreateEmptyPoint()
      {
         var result = new LeadPoint();

         result.X = LeadDoubleTools.NaN;
         result.Y = LeadDoubleTools.NaN;
         return result;
      }

      private const string _emptyString = "{\"x\": \"-Infinity\", \"y\": \"-Infinity\"}";

      public string ToJSON()
      {
         if (IsEmpty)
            return _emptyString;

         return string.Format("{{\"x\": {0}, \"y\": {1}}}", X, Y);
      }

      public static LeadPoint FromJSON(string value)
      {
         var x = (double)JObject.Parse(value)["x"];
         if (LeadDoubleTools.IsInfinity(x) || LeadDoubleTools.IsNaN(x))
            return _empty;

         double y = (double)JObject.Parse(value)["y"];
         var result = new LeadPoint();
         result.X = x;
         result.Y = y;
         return result;
      }
   }
}

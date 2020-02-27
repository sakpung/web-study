using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Cloud_Services_Api.Helper
{
   [DataContract]
   public class BarcodeResultData
   {
      [DataMember]
      public string Symbology { get; set; }
      [DataMember]
      public string Value { get; set; }
      [DataMember]
      public Rectangle Bounds { get; set; }
      [DataMember]
      public int Page { get; set; }
      [DataMember]
      public int RotationAngle { get; set; }
      public BarcodeResultData(int page, string symbology, string value, Rectangle bounds, int rotationAngle)
      {
         Symbology = symbology;
         Value = value;
         Bounds = bounds;
         RotationAngle = rotationAngle;
         Page = page;
      }
   }

   [DataContract]
   public class ExtractTextData
   {
      [DataMember]
      public int PageNumber { get; set; }
      [DataMember]
      public string PageText { get; set; }
      [DataMember(IsRequired = false, EmitDefaultValue = false)]
      public object Words { get; set; }
      [DataMember(IsRequired = false, EmitDefaultValue = false)]
      public object Characters { get; set; }
   }
}
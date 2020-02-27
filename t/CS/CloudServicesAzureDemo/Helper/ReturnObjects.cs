using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Leadtools;
using Leadtools.Document.Writer;
using System.Drawing;

namespace Serverless_Cloud_Services_API
{
   public enum ApiError
   {
      Unauthorized,
      InvalidRequest,
      FileRejected,
      InternalServerError,
      LicenseNotSet
   }

   public class AuthReturn : SuccessReturnObject
   {
      public string Password { get; set; }
      public string AppId { get; set; }

      public AuthReturn() { }
      public AuthReturn(ApiError error, bool success = false) : base(error, success) { }
   }

   public class SuccessReturnObject
   {
      public bool Successful { get; set; }
      public ApiError? ErrorType { get; set; }

      public SuccessReturnObject() { }
      public SuccessReturnObject(ApiError? error, bool success = false)
      {
         this.Successful = success;
         this.ErrorType = error;
      }
   }
   public class ParseWebRequestReturn : SuccessReturnObject
   {
      public LeadWebRequest LeadWebRequest { get; set; }

      public ParseWebRequestReturn() { }
      public ParseWebRequestReturn(ApiError error, bool success = false) : base(error, success) { }
   }

   internal class ConvertToRasterParseReturn : SuccessReturnObject
   {
      public RasterImageFormat OutputFormat { get; set; }
      public ConvertToRasterParseReturn() { }
      public ConvertToRasterParseReturn(ApiError error, bool success = false) : base(error, success) { }
   }

   internal class ConvertToDocumentParseReturn : SuccessReturnObject
   {
      public DocumentFormat OutputFormat { get; set; }
      public ConvertToDocumentParseReturn() { }
      public ConvertToDocumentParseReturn(ApiError error, bool success = false) : base(error, success) { }
   }

   public class ImageDataReturn : SuccessReturnObject
   {
      public Stream Stream { get; set; }

      public ImageDataReturn() { }
      public ImageDataReturn(ApiError error, bool success = false) : base(error, success) { }
   }

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

}

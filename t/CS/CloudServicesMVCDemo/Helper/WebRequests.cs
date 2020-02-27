using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
using Leadtools;
using Leadtools.Document;
using Leadtools.Document.Writer;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Cloud_Services_Api.Helper
{
   /// <summary>
   /// Base Web Request class that all other Web Request classes inherit from. 
   /// </summary>
   [DataContract]
   public class LeadWebRequest
   {
      /// <summary>
      /// URL to the file to process
      /// </summary>
      [DataMember(Name = "fileUrl")]
      public string fileUrl { get; set; }

      /// <summary>
      /// The first page in the file to process
      /// </summary>
      [DataMember(Name = "firstPage")]
      public int FirstPage { get; set; }

      /// <summary>
      /// The last page in the file to process
      /// </summary>
      [DataMember(Name = "lastPage")]
      public int LastPage { get; set; }
   }

   /// <summary>
   /// Web Request for converting to a Raster Image Format
   /// </summary>
   [DataContract]
   public class RasterConversionWebRequest : LeadWebRequest
   {
      /// <summary>
      /// The output Raster Format. For the full list of supported Raster Image Formats, reference our documentation here: https://www.leadtools.com/help/leadtools/v20/dh/l/rasterimageformat.html
      /// </summary>
      [DataMember(Name = "format")]
      public RasterImageFormat Format { get; set; }
   }

   /// <summary>
   /// Web Request for converting to a Document File Format
   /// </summary>
   [DataContract]
   public class DocumentConversionWebRequest : LeadWebRequest
   {
      /// <summary>
      /// The output Document Format.  For the full list of supported Document Formats, reference our documentation here: https://www.leadtools.com/help/leadtools/v20/dh/ft/documentformat.html
      /// </summary>
      [DataMember(Name = "format")]
      public DocumentFormat Format { get; set; }
   }

   /// <summary>
   /// Web Request for extracting text from a file
   /// </summary>
   [DataContract]
   public class ExtractTextWebRequest : LeadWebRequest
   {
      /// <summary>
      /// Flag indicating whether or not character information should be extracted from the file as well. 
      /// </summary>
      [DataMember(Name = "extractCharacters")]
      public bool extractCharacters { get; set; }
   }

   /// <summary>
   /// Web Request for extracting Barcode information
   /// </summary>
   [DataContract]
   public class BarcodeWebRequest : LeadWebRequest
   {
      /// <summary>
      /// A comma separated string of symbologies corresponding where each entry in the string corresponds to the LEADTOOLS BarcodeSymbology Enum. For the full list of supported Barcode Symbologies, reference our documentation here: https://www.leadtools.com/help/leadtools/v20/dh/ba/barcodesymbology.html
      /// </summary>
      [DataMember(Name = "symbologies")]
      public string symbologies { get; set; }
   }
}
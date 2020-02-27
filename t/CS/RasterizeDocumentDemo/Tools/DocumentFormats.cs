// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Text;

using Leadtools;

namespace RasterizeDocumentDemo.Tools
{
   static class DocumentFormats
   {
      public static string[] Formats =
      {
         "PDF",
         "EPS",
         "XPS",
         "RTF",
         "TXT",
         "XLS",
         "DOC",
         "DOCX",
      };

      public static string[] FormatFriendlyNames =
      {
         "Adobe Portable Document Format",
         "Encapsulated PostScript",
         "Microsoft XML Paper Specification",
         "Rich Text Format",
         "Text",
         "Microsoft Excel 2003",
         "Microsoft WORD 2003",
         "Microsoft WORD 2007",
      };

      public static string[][] FormatExtensions =
      {
         new string[] { "pdf" },
         new string[] { "eps", "ps" },
         new string[] { "xps" },
         new string[] { "rtf" },
         new string[] { "txt" },
         new string[] { "xls" },
         new string[] { "doc" },
         new string[] { "docx" },
      };

      public static RasterImageFormat[] RasterFormats =
      {
         RasterImageFormat.RasPdf,
         RasterImageFormat.Postscript,
         RasterImageFormat.Xps,
         RasterImageFormat.RtfRaster,
         RasterImageFormat.Txt,
         RasterImageFormat.Xls,
         RasterImageFormat.Doc,
         RasterImageFormat.Docx,
      };

      public static int GetFormatIndex(RasterImageFormat format)
      {
         for(int i = 0; i < RasterFormats.Length; i++)
         {
            if(RasterFormats[i] == format)
            {
               return i;
            }
         }

         return -1;
      }
   }
}

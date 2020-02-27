// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Leadtools.Document.Writer;

namespace Ocr2SharePointDemo
{
   public enum MyDocumentFormat
   {
      PDF,
      PDFImageOverText,
      DOCX,
      DOC,
      TEXT
   }

   public class MyDocumentFormatItem
   {
      public string Title;
      public MyDocumentFormat FormatType;

      public MyDocumentFormatItem(string t, MyDocumentFormat f)
      {
         Title = t;
         FormatType = f;
      }

      public override string ToString()
      {
         return Title;
      }

      public static string GetExtension(MyDocumentFormat format)
      {
         switch (format)
         {
            case MyDocumentFormat.DOC:
               return "doc";

            case MyDocumentFormat.DOCX:
               return "docx";

            case MyDocumentFormat.TEXT:
               return "txt";

            case MyDocumentFormat.PDF:
            case MyDocumentFormat.PDFImageOverText:
            default:
               return "pdf";
         }
      }

      public static readonly MyDocumentFormatItem[] DefaultItems =
      {
         new MyDocumentFormatItem("Adobe Portable Format (PDF)", MyDocumentFormat.PDF),
         new MyDocumentFormatItem("Adobe Portable Format (PDF) with Image over Text", MyDocumentFormat.PDFImageOverText),
         new MyDocumentFormatItem("Microsoft Word 2007 (DOCX)", MyDocumentFormat.DOCX),
         new MyDocumentFormatItem("Microsoft Word 2003 (DOC)", MyDocumentFormat.DOC),
         new MyDocumentFormatItem("Text (TXT)", MyDocumentFormat.TEXT)
      };
   }
}

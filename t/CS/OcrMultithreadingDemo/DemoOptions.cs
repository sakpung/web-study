// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System.Windows.Forms;

using Leadtools.Ocr;
using Leadtools.Document.Writer;

namespace OcrMultiThreadingDemo
{
   [Serializable]
   public class DemoOptions
   {
      // The engine type to use
      public OcrEngineType OcrEngineType = OcrEngineType.OmniPage;
      // The source directory
      public string SourceDirectory = null;
      // Filter of source files (e.g, *.tif)
      public string SourceFilter = "*.tif";
      // Destination directory where recognized documents will be created
      public string DestinationDirectory = null;
      // Format to use
      public DocumentFormat DestinationDocumentFormat = DocumentFormat.Pdf;
      // All formats options
      public string DocumentFormatOptionsAsXml = null;
      
      // Load/Save
      private static XmlSerializer _serializer = new XmlSerializer(typeof(DemoOptions));

      private static string GetXmlFileName()
      {
         return Path.Combine(Application.CommonAppDataPath, "OcrMultiThreadingDemo.xml");
      }

      public static DemoOptions LoadDefault()
      {
         DemoOptions options = new DemoOptions();

         string xmlFileName = GetXmlFileName();
         if(File.Exists(xmlFileName))
         {
            try
            {
               using(StreamReader reader = File.OpenText(xmlFileName))
               {
                  options = _serializer.Deserialize(reader) as DemoOptions;
               }
            }
            catch
            {
            }
         }

         return options;
      }

      public void SaveDefault()
      {
         string xmlFileName = GetXmlFileName();

         try
         {
            using(TextWriter writer = new StreamWriter(xmlFileName))
            {
               _serializer.Serialize(writer, this);
            }
         }
         catch
         {
         }
      }
   }
}

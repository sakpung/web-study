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

namespace Ocr2SharePointDemo
{
   public struct DemoOptions
   {
      public SharePoint.SharePointServerSettings SharePointServerSettings;
      public string ImageDocumentFileName;
      public int DocumentFormatIndex;

      public static DemoOptions Default
      {
         get
         {
            DemoOptions obj = new DemoOptions();
            obj.SharePointServerSettings = SharePoint.SharePointServerSettings.Default;
            obj.ImageDocumentFileName = null;
            obj.DocumentFormatIndex = 0;
            return obj;
         }
      }

      private static string DataFileName
      {
         get
         {
            return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), @"Ocr2SharePoint2010Demo.xml");
         }
      }

      private static XmlSerializer _serializer = new XmlSerializer(typeof(DemoOptions), new Type[] { typeof(SharePoint.SharePointServerSettings) });

      public static DemoOptions Load()
      {
         try
         {
            if (File.Exists(DataFileName))
            {
               using (XmlTextReader reader = new XmlTextReader(DataFileName))
               {
                  return (DemoOptions)_serializer.Deserialize(reader);
               }
            }
            else
            {
               return DemoOptions.Default;
            }
         }
         catch
         {
            return DemoOptions.Default;
         }
      }

      public void Save()
      {
         try
         {
            using (XmlTextWriter writer = new XmlTextWriter(DataFileName, Encoding.Unicode))
            {
               writer.Formatting = Formatting.Indented;
               writer.Indentation = 2;
               _serializer.Serialize(writer, this);
            }
         }
         catch
         {
         }
      }
   }
}

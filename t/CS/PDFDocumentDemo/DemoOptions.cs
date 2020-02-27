// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace PDFDocumentDemo
{
   // Current demo options, we can load/save this to disk
   public struct DemoOptions
   {
      public string OpenCommonDialogFolder;

      public static DemoOptions Default
      {
         get
         {
            DemoOptions obj = new DemoOptions();
            return obj;
         }
      }

      private static string DataFileName
      {
         get
         {
            return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), @"PDFDocumentDemo.xml");
         }
      }

      private static XmlSerializer _serializer = new XmlSerializer(typeof(DemoOptions));

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

// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using System.ComponentModel;

namespace DocumentConverterDemo
{
   [Serializable]
   public class MyOptions
   {
      public MyOptions()
      {
      }

      [Description("The directory containing the input image files to convert")]
      public string InputFolder { get; set; }
      [Description("Extension to use (wildcards, for example, *.tif). Leave empty to convert all the files in the input directory")]
      public string Extension { get; set; }
      [Description("The directory where the output documents are generated")]
      public string OutputFolder { get; set; }
      [Description("Stop the conversion on first error. Otherwise, continue converting the next input file")]
      public bool StopOnFirstError { get; set; }

      public MyOptions Clone()
      {
         var result = new MyOptions();
         result.InputFolder = this.InputFolder;
         result.Extension = this.Extension;
         result.OutputFolder = this.OutputFolder;
         result.StopOnFirstError = this.StopOnFirstError;
         return result;
      }

      public static string XmlFileName;

      private static string GetOutputFileName()
      {
         if (string.IsNullOrEmpty(XmlFileName)) throw new InvalidOperationException("Set XmlFileName before calling this method");

         return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), XmlFileName + ".xml");
      }

      private static XmlSerializer _serializer = new XmlSerializer(typeof(MyOptions));

      // Load the preferences from local application data, if not found or error, returns default preferences
      public static MyOptions Load()
      {
         try
         {
            var file = GetOutputFileName();
            if (File.Exists(file))
            {
               using (var reader = new XmlTextReader(file))
                  return _serializer.Deserialize(reader) as MyOptions;
            }
         }
         catch (Exception ex)
         {
            Debug.WriteLine(ex.Message);
         }

         return new MyOptions();
      }

      // Save the preferences to local application data
      public void Save()
      {
         try
         {
            var file = GetOutputFileName();
            using (var writer = new XmlTextWriter(file, Encoding.Unicode))
            {
               writer.Formatting = Formatting.Indented;
               writer.Indentation = 2;
               _serializer.Serialize(writer, this);
            }
         }
         catch { }
      }
   }
}

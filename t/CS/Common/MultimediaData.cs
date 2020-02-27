// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml.Serialization;
using System.Xml.XPath;
using System.Xml;

namespace Leadtools.Demos
{
   public struct MultimediaData
   {
      private byte [] _conversionSettings;
      private string _sourceFile;
      private string _targetFile;
      private string _profileName;

      public MultimediaData(string sourceFile, string targetFile, byte[] conversionSettings, string profileName)
      {
         _conversionSettings = conversionSettings;
         _sourceFile = sourceFile;
         _targetFile = targetFile;
         _profileName = profileName;
      }

      public string ProfileName
      {
         get { return _profileName; }
         set { _profileName = value; }
      }

      public string SourceFile
      {
         get { return _sourceFile; }
         set { _sourceFile = value; }
      }

      public string TargetFile
      {
         get { return _targetFile; }
         set { _targetFile = value; }
      }

      public byte[] ConversionSettings
      {
         get { return _conversionSettings; }
         set { _conversionSettings = value; }
      }

      private static void AddElement(XmlDocument doc, XmlElement root, string name, string value)
      {
         XmlElement element = doc.CreateElement(name);
         XmlText valueText;

         if (value != null)
         {
            valueText = doc.CreateTextNode(value);
         }
         else
         {
            valueText = doc.CreateTextNode("");
         }

         element.AppendChild(valueText);
         root.AppendChild(element);
      }

      static public string SerializeToString(MultimediaData multimediaData)
      {
         XmlDocument doc = new XmlDocument();
         XmlElement root = doc.CreateElement("MultimediaData");
         doc.AppendChild(root);

         AddElement(doc, root, "SourceFile", multimediaData.SourceFile);
         AddElement(doc, root, "TargetFile", multimediaData.TargetFile);
         AddElement(doc, root, "ProfileName", multimediaData.ProfileName);
         AddElement(doc, root, "ConversionSettings", Convert.ToBase64String(multimediaData.ConversionSettings));

         StringBuilder sb = new StringBuilder();
         using (XmlWriter writer = XmlWriter.Create(sb))
         {
            writer.WriteProcessingInstruction("xml", "version=\"1.0\" encoding=\"UTF-16\" standalone=\"yes\"");
            doc.WriteTo(writer);
            writer.Flush();
            writer.Close();
         }

         return sb.ToString();
      }

      private static string ReadElement(XPathNavigator nav, string xPath)
      {
         XPathNavigator valueNav = nav.SelectSingleNode(xPath);
         if (valueNav != null)
         {
            return valueNav.Value;
         }
         else
         {
            return null;
         }
      }

      static public MultimediaData DeserializeFromString(string xmlString)
      {
         MultimediaData data = new MultimediaData();

         using (StringReader reader = new StringReader(xmlString))
         {
            XPathDocument doc = new XPathDocument(reader);

            XPathNavigator nav = doc.CreateNavigator();

            data.SourceFile = ReadElement(nav, @"//SourceFile");
            data.TargetFile = ReadElement(nav, @"//TargetFile");
            data.ProfileName = ReadElement(nav, @"//ProfileName");
            data.ConversionSettings = Convert.FromBase64String(ReadElement(nav, @"//ConversionSettings"));
         }

         return data;
      }
   }
}

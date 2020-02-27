// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml;
using System.Xml.XPath;

namespace Leadtools.Demos
{
   public struct OcrData
   {
      private string _imageFileName;
      private string _documentFileName;
      private string _documentFormat;

      public OcrData(string imageFileName, string documentFileName, string documentFormat)
      {
         _imageFileName = imageFileName;
         _documentFileName = documentFileName;
         _documentFormat = documentFormat;
      }

      public string ImageFileName
      {
         get { return _imageFileName; }
         set { _imageFileName = value; }
      }

      public string DocumentFileName
      {
         get { return _documentFileName; }
         set { _documentFileName = value; }
      }

      public string DocumentFormat
      {
         get { return _documentFormat; }
         set { _documentFormat = value; }
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

      public static string SerializeToString(OcrData obj)
      {
         XmlDocument doc = new XmlDocument();
         XmlElement root = doc.CreateElement("OcrData");
         doc.AppendChild(root);

         AddElement(doc, root, "ImageFileName", obj.ImageFileName);
         AddElement(doc, root, "DocumentFileName", obj.DocumentFileName);
         AddElement(doc, root, "DocumentFormat", obj.DocumentFormat);

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

      public static OcrData DeserializeFromString(string xmlString)
      {
         OcrData data = new OcrData();

         using (StringReader reader = new StringReader(xmlString))
         {
            XPathDocument doc = new XPathDocument(reader);

            XPathNavigator nav = doc.CreateNavigator();

            data.ImageFileName = ReadElement(nav, @"//ImageFileName");
            data.DocumentFileName = ReadElement(nav, @"//DocumentFileName");
            data.DocumentFormat = ReadElement(nav, @"//DocumentFormat");
         }

         return data;
      }
   }
}

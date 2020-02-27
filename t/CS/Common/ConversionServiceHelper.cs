// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Reflection;
using System.IO;

namespace ConversionServiceHelper
{
   public class Constants
   {
      public const string ConfigFile = "ConversionServiceConfig.xml";
      public const string ServiceName = "LEADTOOLSImageConversion";
      public const string ServiceDisplayName = "LEADTOOLSImageConversion";
      public const string ServiceDescription = "LEADTOOLS Image Conversion Service";
      public const int ReloadSettingsCommand = 200; //must be between 128 and 256
   }

   public class SettingsHelper
   {

      static string _pdfInputPathString = "PDFInputPath";
      static string _jpegInputPathString = "JPEGInputPath";
      static string _outputPathString = "OutputPath";
      static string _conversionFrequencyString = "ConversionFrequency";
      static string _conversionSettings = "ConversionSettings";
      static string _moveSourcePath = "MoveSourcePath";

      public struct ConversionSettings
      {
         public string PDFInputPath;
         public string JPEGInputPath;
         public string OutputPath;
         public int ConversionFrequency;
         public string MoveSourcePath;
      }

      static public ConversionSettings LoadSettings(string settingsPath)
      {
         //Load XML settings file
         XmlDocument settingsConfig = new XmlDocument();
         settingsConfig.Load(settingsPath);

         ConversionSettings conversionsSettings = new ConversionSettings();

         string jpegPath = LoadElementFromXML(settingsConfig, _jpegInputPathString);
         string pdfPath = LoadElementFromXML(settingsConfig, _pdfInputPathString);
         string outputPath = LoadElementFromXML(settingsConfig, _outputPathString);

         conversionsSettings.JPEGInputPath = String.IsNullOrEmpty(jpegPath) ? Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location), "JPEG In") : jpegPath;
         conversionsSettings.PDFInputPath = String.IsNullOrEmpty(pdfPath) ? Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location), "PDF In") : pdfPath;
         conversionsSettings.OutputPath = String.IsNullOrEmpty(outputPath) ? Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location), "Out") : outputPath;
         conversionsSettings.MoveSourcePath = LoadElementFromXML(settingsConfig, _moveSourcePath);

         int conversionFrequency = 0;
         Int32.TryParse(LoadElementFromXML(settingsConfig, _conversionFrequencyString), out conversionFrequency);
         conversionsSettings.ConversionFrequency = conversionFrequency < 5 ? 30 : conversionFrequency;

         return conversionsSettings;
      }

      static public void SaveSettings(string settingsPath, ConversionSettings conversionSettings)
      {
         XmlDocument xDoc = new XmlDocument();
         // Create declaration
         XmlDeclaration xmlDeclaration = xDoc.CreateXmlDeclaration("1.0", null, null);
         xDoc.AppendChild(xmlDeclaration);

         // Create root element
         XmlElement root = xDoc.CreateElement(_conversionSettings);
         xDoc.AppendChild(root);

         //Add PDF path
         AddElementToXML(xDoc, root, _pdfInputPathString, conversionSettings.PDFInputPath);
         //Add JPEG path
         AddElementToXML(xDoc, root, _jpegInputPathString, conversionSettings.JPEGInputPath);
         //Add Output path
         AddElementToXML(xDoc, root, _outputPathString, conversionSettings.OutputPath);
         //Add conversion frequency
         AddElementToXML(xDoc, root, _conversionFrequencyString, conversionSettings.ConversionFrequency.ToString());
         //Add MoveSourcePath
         AddElementToXML(xDoc, root, _moveSourcePath, conversionSettings.MoveSourcePath);

         xDoc.Save(settingsPath);
      }

      static public void AddElementToXML(XmlDocument xDoc, XmlElement parentElement, string nodeName, string nodeValue)
      {
         XmlElement newElement = xDoc.CreateElement(nodeName);
         newElement.InnerText = nodeValue;
         parentElement.AppendChild(newElement);
      }

      static public string LoadElementFromXML(XmlDocument xDoc, string elementName)
      {
         XmlNodeList element = xDoc.GetElementsByTagName(elementName);
         if (element.Count > 0)
            return element[0].InnerText;
         else
            return String.Empty;
      }
   }
}

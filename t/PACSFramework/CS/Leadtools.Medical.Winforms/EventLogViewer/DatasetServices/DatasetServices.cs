// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Xml ;
using System.IO ;
using Leadtools.Dicom ;

namespace Leadtools.Medical.Winforms
{
   abstract class DatasetServices
   {
      public static void ConvertToXML
      ( 
         DicomDataSet SourceDataset,
         XmlTextWriter DatasetXmlTextWriter,
         bool fWriteStartDocument
      )
      {
         try
         {
            if ( fWriteStartDocument ) 
            {
               DatasetXmlTextWriter.WriteStartDocument ( ) ;
            }
   
            FillTree ( SourceDataset, DatasetXmlTextWriter ) ;
   
            DatasetXmlTextWriter.Flush ( ) ;
         }
         catch ( Exception exception )
         {
            System.Diagnostics.Debug.Assert ( false, exception.ToString ( ) ) ;
            
            throw ;
         }
      }
      
      public static DicomDataSet ConvertFromByteArray
      ( 
         byte [] arrbytDICOMDataset 
      )
      {
         try
         {
            string strTempFileName = string.Empty ;
            
            
            strTempFileName = System.IO.Path.GetTempFileName ( ) ;
            
            try
            {
               DicomDataSet DICOMDataset ;
                     
                     
               DICOMDataset = new DicomDataSet ( ) ;
                                                          
               WriteDICOMDataSetToFile ( strTempFileName,
                                         arrbytDICOMDataset ) ;
                        
               DICOMDataset.Load ( strTempFileName, DicomDataSetLoadFlags.LoadAndClose ) ;
                                        
               return DICOMDataset ;
            }
            catch ( Exception exception )
            {
               System.Diagnostics.Debug.Assert ( false ) ;
               
               throw exception ;
            }
            finally 
            {
               File.Delete ( strTempFileName ) ;
            }
         }
         catch ( Exception exception )
         {
            System.Diagnostics.Debug.Assert ( false ) ;
                  
            throw exception ;
         }
      }
      
         public static byte[] GetDICOMDataSetStream 
         ( 
            DicomDataSet LogDataset 
         )
         {
            try
            {
               StreamReader DataSetStreamReader ;
               BinaryReader DataSetBinaryReader ;
               byte []      bytarrReturnDataSetStream ;
               string       strTempFileName = string.Empty ;
               
               
               strTempFileName = System.IO.Path.GetTempFileName ( ) ;
               
               try
               {
                  LogDataset.Save ( strTempFileName, DicomDataSetSaveFlags.None ) ;
                  DataSetStreamReader = new StreamReader ( strTempFileName ) ;
                  DataSetBinaryReader = new BinaryReader ( DataSetStreamReader.BaseStream ) ;
               
                  bytarrReturnDataSetStream = DataSetBinaryReader.ReadBytes ( ( int ) DataSetStreamReader.BaseStream.Length ) ;
               
                  DataSetStreamReader.Close ( ) ;
                  DataSetBinaryReader.Close ( ) ;  
                  
                  return bytarrReturnDataSetStream ;
               }
               catch ( Exception exception )
               {
                  throw exception ;
               }
               finally
               {
                  if ( File.Exists ( strTempFileName ) )
                  {
                     File.Delete ( strTempFileName ) ;  
                  }
               }
            }
            catch ( Exception exception )
            {
               System.Diagnostics.Debug.Assert ( false ) ;
               
               throw exception ;
            }
         }
      
      private static void FillTree
      (
         DicomDataSet SourceDataset,
         XmlTextWriter DatasetXmlTextWriter
      )
      {
         try
         {
            DatasetXmlTextWriter.WriteStartElement ( "DICOM DataSet",
                                                     null ) ;

            FillSubTree ( SourceDataset, DatasetXmlTextWriter ) ;

            DatasetXmlTextWriter.WriteEndElement ( ) ;  
         }
         catch ( Exception exception )
         {
            System.Diagnostics.Debug.Assert ( false ) ;
                  
            throw exception ;
         }
      }
            
            
      private static void FillSubTree 
      ( 
         DicomDataSet SourceDataset, 
         XmlTextWriter DatasetXmlTextWriter
      )
      {
         try
         {
            int nLevelDepth = 0 ;
                        
                        
            try
            {
               DicomElement element ;
               
               
               nLevelDepth ++ ;
               
               element = SourceDataset.GetFirstElement ( null, false, true ) ;
               
               while ( null != element )
               {
                  WriteStartXML ( DatasetXmlTextWriter, SourceDataset, element, nLevelDepth ) ;
                  
                  if ( SourceDataset.GetChildElement ( element, true ) != null )
                  {
                     BuildTree ( DatasetXmlTextWriter, SourceDataset, element, nLevelDepth ) ;
                  }
                  
                  DatasetXmlTextWriter.WriteEndElement ( ) ;
                  
                  element = SourceDataset.GetNextElement ( element, true, true ) ;
               }
            }
            catch ( Exception exp )
            {
               System.Diagnostics.Debug.Assert ( false ) ;
                                 
               throw exp ;
            }
            finally
            {
               nLevelDepth-- ;
            }
         }
         catch ( Exception exp )
         {
            System.Diagnostics.Debug.Assert ( false ) ;
                                 
            throw exp ;
         }            
      }
      
      private static void BuildTree
      (
         XmlTextWriter DatasetXmlTextWriter,
         DicomDataSet SourceDataset,
         DicomElement parentElement,
         int nLevelDepth
      )
      {
         try
         {
            DicomElement childElement ;
            
            
            
            childElement = SourceDataset.GetChildElement ( parentElement, true ) ;
            
            nLevelDepth++ ;
            
            while ( null != childElement )
            {
               WriteStartXML ( DatasetXmlTextWriter, SourceDataset, childElement, nLevelDepth ) ;
               
               if ( SourceDataset.GetChildElement ( childElement, true ) != null )
               {
                  BuildTree ( DatasetXmlTextWriter, SourceDataset, childElement, nLevelDepth ) ;
               }
               
               DatasetXmlTextWriter.WriteEndElement ( ) ;
               
               childElement = SourceDataset.GetNextElement ( childElement, true, true ) ;
            }
            
            nLevelDepth-- ;
         }
         catch ( Exception exp )
         {
            System.Diagnostics.Debug.Assert ( false ) ;
                                             
            throw exp ;
         }
      }
      
      private static void WriteStartXML 
      (
         XmlTextWriter atasetXmlTextWriter,
         DicomDataSet IODDataset,
         DicomElement element,
         int nLevelDepth
      )
      {
         try
         {
            long        nTag = -1 ;
            DicomVRType nVR  ;

            
            nTag = element.Tag ;
                  
            if ( nTag != DicomTag.Item )
            {
               DicomTag elementTag ;
               
               
               elementTag = DicomTagTable.Instance.Find ( nTag ) ;
               
               if ( null != elementTag )
               {
                  nVR = elementTag.VR ;
               }
               else
               {
                  nVR = DicomVRType.UN ;
               }
                     
               if ( DicomVRType.SQ == nVR )
               {
                  atasetXmlTextWriter.WriteStartElement ( elementTag.Name.Replace ( " ","" ).Replace ( "'", "" ).Replace ( "(", "" ).Replace ( ")", "" ).Replace ( "/", "" ) ) ;
               }
               else
               {
                  string strElementValue ;
                        
                  
                  if ( element.Tag != DicomTag.PixelData && elementTag != null )
                  {
                     strElementValue = IODDataset.GetValue<string> ( element, "" ) ;
                     strElementValue = strElementValue.Replace ( "\\", "," ) ;

                     atasetXmlTextWriter.WriteStartElement ( elementTag.Name.Replace ( " ","" ).Replace ( "'", "" ).Replace ( "(", "" ).Replace ( ")", "" ).Replace ( "/", "" ) ) ;
                           
                     atasetXmlTextWriter.WriteAttributeString ( Constants.XMLAttributeValue,
                                                                strElementValue ) ;
                  }
                  else
                  {
                     atasetXmlTextWriter.WriteStartElement ( GetFormattedDICOMTag ( element.Tag ) ) ;
                  }
               }
            }
            else
            {
               atasetXmlTextWriter.WriteStartElement ( Constants.XMLAttributeItem ) ;
            }
         }
         catch ( Exception exp )
         {
            System.Diagnostics.Debug.Assert ( false ) ;
                           
            throw exp ;
         }
      }
      
      private static void WriteDICOMDataSetToFile 
      (
         string strFilePath,
         byte[] arrbytDICOMDataset
      ) 
      {
         try
         {
            FileStream    DatasetFileStream ;
            BinaryWriter  DatasetBinaryWriter ;
            
            
            DatasetFileStream = new FileStream ( strFilePath, 
                                                 FileMode.Create ) ;

            try
            {
               DatasetBinaryWriter = new BinaryWriter ( DatasetFileStream ) ;
                     
               DatasetBinaryWriter.Write ( arrbytDICOMDataset ) ;
                     
               DatasetBinaryWriter.Flush ( ) ;
               DatasetFileStream.Flush ( ) ;
                        
               DatasetBinaryWriter.Close ( ) ;
            }
            catch ( Exception exception )
            {
               System.Diagnostics.Debug.Assert ( false ) ;
               
               throw exception ;
            }
            finally
            {
               DatasetFileStream.Close ( ) ;  
            }
         }
         catch ( Exception exception )
         {
            System.Diagnostics.Debug.Assert ( false ) ;
                  
            throw exception ;
         }
      }
      
      public static string GetFormattedDICOMTag 
      ( 
         long tag 
      )
      {
         try
         {
            string strDICOMTag ;

            strDICOMTag = String.Format ( "({0:x4},{1:x4})", 
                                          GetGroup(tag),
                                          GetElement( tag) ) ;
            
            return strDICOMTag ;
         }
         catch ( System.Exception exception )
         {
            System.Diagnostics.Debug.Assert ( false, exception.Message ) ;
             
            throw exception ;
         }
      }
      
      private static UInt16 GetGroup ( long tag )
      {
         return ((UInt16)(tag >> 16));
      }

      private static int GetElement ( long tag )
      {
         return ((UInt16)(tag & 0xFFFF));
      }

      
      private class Constants
      {
         public const string XMLAttributeValue = "Value" ;
         public const string XMLAttributeItem  = "Item" ;
      }
   }
}

// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System ;
using System.IO ;
using System.Xml ;
using Leadtools ;
using Leadtools.Dicom ;


namespace Leadtools.Medical.Winforms
{
   public class DICOMServerEventLogFormsFormatter : DICOMServerEventLogFormatter
   {
      #region Public
         
         #region Methods
         
            public override string FormatDescription ( object objDescription )
            {
               try
               {
                  if ( null == objDescription || DBNull.Value == objDescription )
                  {
                     return string.Empty ;
                  }

                  return objDescription.ToString ( ).Replace ( Constants.SpecialCharacter.Delimiter, 
                                                               Constants.SpecialCharacter.AntiDelimiter ) ;
               }
               catch ( Exception exception )
               {
                  System.Diagnostics.Debug.Assert ( false ) ;
                  
                  throw exception ;
               }
            }
            
            
            public override string FormatDataSet ( object objDataSet )
            {
               try
               {
                  if ( null != objDataSet && DBNull.Value != objDataSet ) 
                  {
                     return GetDICOMDataSet ( objDataSet ) ;
                  }
                  else
                  {
                     return string.Empty ;
                  }
               }
               catch ( Exception exception )
               {
                  System.Diagnostics.Debug.Assert ( false ) ;
                  
                  throw exception ;
               }
            }
            
         #endregion
         
         #region Properties
            
         #endregion
         
         #region Events
            
         #endregion
         
         #region Data Types Definition
            
         #endregion
         
         #region Callbacks
            
         #endregion
         
      #endregion
      
      #region Protected
         
         #region Methods
            
         #endregion
         
         #region Properties
            
         #endregion
         
         #region Events
            
         #endregion
         
         #region Data Members
            
         #endregion
         
         #region Data Types Definition
            
         #endregion
         
      #endregion
      
      #region Private
         
         #region Methods
         
            private string GetDICOMDataSet ( object objDataSet ) 
            {
               try
               {
                  DicomDataSet  EventLogDataset ;
                  MemoryStream  DatasetMemoryStream ;
                  XmlTextWriter DatasetXMLTextWriter ;
                  StreamReader  DatasetStreamReader ;
                  string        strReturnXMLDataset ;
                              
                  
                  if ( objDataSet is byte [ ] )
                  {
                     EventLogDataset = DatasetServices.ConvertFromByteArray ( ( byte[] ) objDataSet ) ;
                  }
                  else
                  {
                     EventLogDataset = objDataSet as DicomDataSet ;
                  }
                              
                  DatasetMemoryStream  = new MemoryStream ( ) ;
                  DatasetXMLTextWriter = new XmlTextWriter ( DatasetMemoryStream, 
                                                             System.Text.Encoding.UTF8 ) ;
                                                                         
                  DatasetXMLTextWriter.Formatting = Formatting.Indented ;
                              
                  DatasetServices.ConvertToXML ( EventLogDataset, 
                                                 DatasetXMLTextWriter,
                                                 false ) ;
                                                             
                  DatasetStreamReader = new StreamReader ( DatasetMemoryStream ) ;
                              
                  DatasetMemoryStream.Position = 0 ;
                                    
                  strReturnXMLDataset = DatasetStreamReader.ReadToEnd ( ) ;
                        
                  DatasetXMLTextWriter.Close ( ) ;
                                    
                  return strReturnXMLDataset ;
               }
               catch ( Exception exception )
               {
                  System.Diagnostics.Debug.Assert ( false ) ;
                              
                  throw exception ;
               }
            }
            
         #endregion
         
         #region Properties
            
         #endregion
         
         #region Events
            
         #endregion
         
         #region Data Members
            
         #endregion
         
         #region Data Types Definition
         
            private class Constants
            {
               public class SpecialCharacter
               {
                  public const string Delimiter = "^" ;
                  public const string AntiDelimiter = "\n" ;
               }
            }
            
         #endregion
         
      #endregion
      
      #region internal
         
         #region Methods
            
         #endregion
         
         #region Properties
            
         #endregion
         
         #region Events
            
         #endregion
         
         #region Data Types Definition
            
         #endregion
         
         #region Callbacks
            
         #endregion
         
      #endregion
   }
}

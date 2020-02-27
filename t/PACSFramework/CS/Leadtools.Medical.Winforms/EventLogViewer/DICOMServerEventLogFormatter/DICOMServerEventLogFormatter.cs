// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System ;
using Leadtools.Medical.Logging.DataAccessLayer ;
using Leadtools.Dicom;


namespace Leadtools.Medical.Winforms
{
   public class DICOMServerEventLogFormatter : ICustomFormatter
   {
      #region Public
         
         #region Methods
         
            public string Format
            (
               string strColumnName, 
               object FormatArg, 
               IFormatProvider formatProvider
            )
            {
               try
               {
                  if ( strColumnName == _loggingStructureDataSet.DICOMServerEventLog.EventIDColumn.ColumnName )
                  {
                     return FormatEventID ( FormatArg ) ;
                  }
                  
                  if ( strColumnName == _loggingStructureDataSet.DICOMServerEventLog.ServerAETitleColumn.ColumnName )
                  {
                     return FormatServerAETitle ( FormatArg ) ;
                  }
                  
                  if ( strColumnName == _loggingStructureDataSet.DICOMServerEventLog.ServerIPAddressColumn.ColumnName )
                  {
                     return FormatServerIPAddress ( FormatArg ) ;
                  }
                  
                  if ( strColumnName == _loggingStructureDataSet.DICOMServerEventLog.ServerPortColumn.ColumnName )
                  {
                     return FormatServerPort ( FormatArg ) ;
                  }
                  
                  if ( strColumnName == _loggingStructureDataSet.DICOMServerEventLog.ClientAETitleColumn.ColumnName )
                  {
                     return FormatClientAETitle ( FormatArg ) ;
                  }
                  
                  if ( strColumnName == _loggingStructureDataSet.DICOMServerEventLog.ClientHostAddressColumn.ColumnName )
                  {
                     return FormatClientHostAddress ( FormatArg ) ;
                  }
                  
                  if ( strColumnName == _loggingStructureDataSet.DICOMServerEventLog.ClientPortColumn.ColumnName )
                  {
                     return FormatClientPort ( FormatArg ) ;
                  }
                  
                  if ( strColumnName == _loggingStructureDataSet.DICOMServerEventLog.CommandColumn.ColumnName )
                  {
                     return FormatCommand ( FormatArg ) ;
                  }
                  
                  if ( strColumnName == _loggingStructureDataSet.DICOMServerEventLog.EventDateTimeColumn.ColumnName )
                  {
                     return FormatEventDateTime ( FormatArg ) ;
                  }
                  
                  if ( strColumnName == _loggingStructureDataSet.DICOMServerEventLog.TypeColumn.ColumnName )
                  {
                     return FormatEventType ( FormatArg ) ;
                  }
                  
                  if ( strColumnName == _loggingStructureDataSet.DICOMServerEventLog.MessageDirectionColumn.ColumnName )
                  {
                     return FormatMessageDirection ( FormatArg ) ;
                  }
                  
                  if ( strColumnName == _loggingStructureDataSet.DICOMServerEventLog.DescriptionColumn.ColumnName )
                  {
                     return FormatDescription ( FormatArg ) ;
                  }
                  
                  if ( strColumnName == _loggingStructureDataSet.DICOMServerEventLog.DatasetColumn.ColumnName )
                  {
                     return FormatDataSet ( FormatArg ) ;
                  }
                  
                  return FormatCustomInformation ( FormatArg ) ;
               }
               catch ( Exception exception )
               {
                  System.Diagnostics.Debug.Assert ( false ) ;
                  
                  throw exception ;
               }
            }
            
            
            
            public virtual string FormatEventID ( object objEventIDArg )
            {
               try
               {
                  if ( null == objEventIDArg || DBNull.Value == objEventIDArg )
                  {
                     return string.Empty ;
                  }

                  return objEventIDArg.ToString ( ) ;
               }
               catch ( Exception exception )
               {
                  System.Diagnostics.Debug.Assert ( false ) ;
                  
                  throw exception ;
               }
            }
            
            
            public virtual string FormatServerAETitle 
            ( 
               object objServerAETitle 
            ) 
            {
               try
               {
                  if ( null == objServerAETitle || DBNull.Value == objServerAETitle )
                  {
                     return string.Empty ;
                  }

                  return objServerAETitle.ToString ( ) ;
               }
               catch ( Exception exception )
               {
                  System.Diagnostics.Debug.Assert ( false ) ;
                  
                  throw exception ;
               }
            }
            
            
            public virtual string FormatServerIPAddress 
            ( 
               object objServerIPAddress
            ) 
            {
               try
               {
                  if ( null == objServerIPAddress || DBNull.Value == objServerIPAddress )
                  {
                     return string.Empty ;
                  }

                  return objServerIPAddress.ToString ( ) ;
               }
               catch ( Exception exception )
               {
                  System.Diagnostics.Debug.Assert ( false ) ;
                  
                  throw exception ;
               }
            }
            
            
            
            public virtual string FormatServerPort ( object objServerPort ) 
            {
               try
               {
                  int port ;
                  
                  if ( null == objServerPort || DBNull.Value == objServerPort )
                  {
                     return string.Empty ;
                  }

                  if ( int.TryParse ( objServerPort.ToString ( ), out port ) )
                  {
                     if ( -1 == port )
                     {
                        return string.Empty ;
                     }
                  }
                  
                  return objServerPort.ToString ( ) ;
               }
               catch ( Exception exception )
               {
                  System.Diagnostics.Debug.Assert ( false ) ;
                  
                  throw exception ;
               }
            }
            
            
            public virtual string FormatClientAETitle 
            ( 
               object objClientAETitle 
            ) 
            {
               try
               {
                  if ( null == objClientAETitle || DBNull.Value == objClientAETitle )
                  {
                     return string.Empty ;
                  }

                  return objClientAETitle.ToString ( ) ;
               }
               catch ( Exception exception )
               {
                  System.Diagnostics.Debug.Assert ( false ) ;
                  
                  throw exception ;
               }
            }
            
            
            public virtual string FormatClientHostAddress 
            ( 
               object objClientHostAddress 
            ) 
            {
               try
               {
                  if ( null == objClientHostAddress || DBNull.Value == objClientHostAddress )
                  {
                     return string.Empty ;
                  }

                  return objClientHostAddress.ToString ( ) ;      
               }
               catch ( Exception exception )
               {
                  System.Diagnostics.Debug.Assert ( false ) ;
                  
                  throw exception ;
               }
            }
            
            
            public virtual string FormatClientPort
            ( 
               object objClientPort 
            ) 
            {
               try
               {
                  int port ;
                  
                  
                  if ( null == objClientPort || DBNull.Value == objClientPort )
                  {
                     return string.Empty ;
                  }

                  if ( int.TryParse ( objClientPort.ToString ( ), out port ) )
                  {
                     if ( port == -1 )
                     {
                        return string.Empty ;
                     }
                  }
                  
                  return objClientPort.ToString ( ) ;      
               }
               catch ( Exception exception )
               {
                  System.Diagnostics.Debug.Assert ( false ) ;
                        
                  throw exception ;
               }
            }
            
            public virtual string FormatEventDateTime 
            ( 
               object objEventDateTime 
            )
            {
               try
               {
                  if ( null == objEventDateTime || DBNull.Value == objEventDateTime )
                  {
                     return string.Empty ;
                  }

                  return objEventDateTime.ToString ( ) ;      
               }
               catch ( Exception exception )
               {
                  System.Diagnostics.Debug.Assert ( false ) ;
                                    
                  throw exception ;
               }
            }
            
            public virtual string FormatCommand
            ( 
               object command
            )
            {
               try
               {
                  if ( null == command || DBNull.Value == command )
                  {
                     return string.Empty ;
                  }

                  string formatted ; 
                  
                  
                  formatted = command.ToString ( ) ;
                  
                  if ( formatted == DicomCommandType.Undefined.ToString ( ) )
                  {
                     return string.Empty ;
                  }
                  else
                  {
                     return formatted ;
                  }
               }
               catch ( Exception exception )
               {
                  System.Diagnostics.Debug.Assert ( false ) ;
                                    
                  throw exception ;
               }
            }
            
            public virtual string FormatEventType 
            ( 
               object objEventType 
            )
            {
               try
               {
                  if ( null == objEventType || DBNull.Value == objEventType )
                  {
                     return string.Empty ;
                  }

                  return objEventType.ToString ( ) ;
                        
               }
               catch ( Exception exception )
               {
                  System.Diagnostics.Debug.Assert ( false ) ;
                                    
                  throw exception ;
               }
            }
            
            
            public virtual string FormatMessageDirection 
            ( 
               object objMessageDirection 
            ) 
            {
               try
               {
                  if ( null == objMessageDirection || DBNull.Value == objMessageDirection )
                  {
                     return string.Empty ;
                  }

                  return objMessageDirection.ToString ( ) ;
               }
               catch ( Exception exception )
               {
                  System.Diagnostics.Debug.Assert ( false ) ;
                                    
                  throw exception ;
               }
            }
            
            
            public virtual string FormatDescription 
            ( 
               object objDescription 
            ) 
            {
               try
               {
                  if ( null == objDescription || DBNull.Value == objDescription )
                  {
                     return string.Empty ;
                  }

                  return objDescription.ToString ( ) ;      
               }
               catch ( Exception exception )
               {
                  System.Diagnostics.Debug.Assert ( false ) ;
                                    
                  throw exception ;
               }
            }
            
            
            public virtual string FormatDataSet 
            ( 
               object objDataSet 
            ) 
            {
               try
               {
                  if ( null == objDataSet || DBNull.Value == objDataSet )
                  {
                     return string.Empty ;
                  }

                  return objDataSet.ToString ( ) ;
               }
               catch ( Exception exception )
               {
                  System.Diagnostics.Debug.Assert ( false ) ;
                                    
                  throw exception ;
               }
            }
            
            public virtual string FormatCustomInformation
            ( 
               object objCustom
            ) 
            {
               try
               {
                  if ( null == objCustom || DBNull.Value == objCustom )
                  {
                     return string.Empty ;
                  }

                  return objCustom.ToString ( ) ;
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
            
         #endregion
         
         #region Properties
            
         #endregion
         
         #region Events
            
         #endregion
         
         #region Data Members
         
            private DicomEventLogDataSet _loggingStructureDataSet = new DicomEventLogDataSet ( ) ;
            
         #endregion
         
         #region Data Types Definition
         
            private class Constants
            {
               public class Messages
               {
                  public class Exception
                  {
                     public const string ColumnNameNotSupported = "Column name is not supported." ;
                  }
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

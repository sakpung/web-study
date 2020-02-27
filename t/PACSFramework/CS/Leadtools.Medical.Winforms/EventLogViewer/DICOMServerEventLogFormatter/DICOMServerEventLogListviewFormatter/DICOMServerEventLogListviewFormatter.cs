// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System ;
using Leadtools.Medical.Logging.DataAccessLayer ;
using Leadtools.Logging.Medical;

namespace Leadtools.Medical.Winforms
{
   class DICOMServerEventLogListviewFormatter: DICOMServerEventLogFormatter
   {
      #region Public
         
         #region Methods
         
         
            public override string FormatMessageDirection
            (
               object objMessageDirection
            )
            {
               try
               {
                  MessageDirection LogMessageDirection ;
                  
                  if ( null == objMessageDirection || DBNull.Value == objMessageDirection )
                  {
                     return string.Empty ;
                  }

                  LogMessageDirection = ( MessageDirection ) Enum.Parse ( typeof ( MessageDirection ),
                                                                                   objMessageDirection.ToString ( ) ) ;
                  
                  switch ( LogMessageDirection )
                  {
                     case MessageDirection.None:
                     {
                        return string.Empty ;
                     }
                     
                     case MessageDirection.Input:
                     {
                        return Constants.SpecialCharacters.INPUT_ARROW ;
                     }
                     
                     case MessageDirection.Output:
                     {
                        return Constants.SpecialCharacters.OUTPUT_ARROW ;
                     }
                     
                     default:
                     {
                        throw new Exception ( Constants.Messages.ExceptionMessages.LOG_DIRECTION_NOT_SUPPORTED ) ;
                     }
                  }      
               }
               catch ( Exception exception )
               {
                  System.Diagnostics.Debug.Assert ( false ) ;
                  
                  throw exception ;
               }
            }

            
            public override string FormatDescription
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

                  return ReplaceDelimiters ( objEventType.ToString ( ) ) ;
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
         
            private string ReplaceDelimiters ( string strDescription )
            {
               try
               {
                  return strDescription.Replace ( Constants.SpecialCharacters.Delimiter1, 
                                                  Constants.SpecialCharacters.AntiDelimiter1 ).Replace ( Constants.SpecialCharacters.Delimiter2, 
                                                                                                         Constants.SpecialCharacters.AntiDelimiter2 ).Replace ( Constants.SpecialCharacters.Delimiter3,
                                                                                                                                                                Constants.SpecialCharacters.AntiDelimiter3 ) ;
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
               public class Messages
               {
                  public class ExceptionMessages
                  {
                     public const string LOG_DIRECTION_NOT_SUPPORTED = "Log-Direction not supported." ;
                  }
               }
               
               public class SpecialCharacters
               {
                  public const string INPUT_ARROW  = ">>" ;
                  public const string OUTPUT_ARROW = "<<" ;
                  public const string Delimiter1 = "^" ;
                  public const string Delimiter2 = "\t" ;
                  public const string Delimiter3 = "\n" ;
                  public const string AntiDelimiter1 = " " ;
                  public const string AntiDelimiter2 = "" ;
                  public const string AntiDelimiter3 = " " ;
                  //public const 
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

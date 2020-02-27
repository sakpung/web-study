// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System ;
using System.Data ;
using System.Collections.Specialized;
using System.Xml;
using Leadtools.Medical.Worklist.DataAccessLayer;



namespace Leadtools.Medical.Winforms
{
   abstract class DataSetValidator
   {
      #region Public
         
         #region Methods
         
            public DataSetValidator ( )
            {
               try
               {
                  
               }
               catch ( Exception exception )
               {
                  System.Diagnostics.Debug.Assert ( false ) ;
                  
                  throw exception ;
               }   
            }
            
            
            public void BeginValidation ( DataSet ValidationDataSet ) 
            {
               try
               {
                  DataSet     AllowableValuesDataSet = null ;
                  XmlDocument PersonNameXMLDoc       = null ;
                  
                  
                  InitializeResources ( out AllowableValuesDataSet, out PersonNameXMLDoc ) ;
                  
                  __AllowableValuesDataSet = AllowableValuesDataSet ;
                  __PersonNameXMLDocument = PersonNameXMLDoc ;
                  
                  foreach ( DataTable ValidationDataTable in ValidationDataSet.Tables )
                  {
                     ValidationDataTable.ColumnChanging += new DataColumnChangeEventHandler ( ValidationDataTable_ColumnChanging ) ;
                     ValidationDataTable.RowChanging    += new DataRowChangeEventHandler ( ValidationDataTable_RowChanging ) ;
                  } 
               }
               catch ( Exception exception )
               {
                  System.Diagnostics.Debug.Assert ( false ) ;
                  
                  throw exception ;
               }
            }
            
            
            public void EndValidation ( DataSet ValidationDataSet )
            {
               try
               {
                  foreach (  DataTable ValidationDataTable in ValidationDataSet.Tables )
                  {
                     ValidationDataTable.ColumnChanging -= new DataColumnChangeEventHandler ( ValidationDataTable_ColumnChanging ) ;
                     ValidationDataTable.RowChanging    -= new DataRowChangeEventHandler    ( ValidationDataTable_RowChanging ) ;
                  } 
                  
                  FreeResources ( ) ;
               }
               catch ( Exception exception )
               {
                  System.Diagnostics.Debug.Assert ( false ) ;
                  
                  throw exception ;
               }   
            }
            
            
            public bool IsDataSetValid 
            ( 
               DataSet ValidationDataSet,
               ref string strValidationMessage
            ) 
            {
               try
               {
                  return PerformCuztomValidation ( ValidationDataSet, 
                                                   ref strValidationMessage ) ;
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
         
            public delegate void ValidationErrorDetectionEventHandler ( string strReasonMessage,
                                                                        DataColumnChangeEventArgs e ) ;
                                                                        
            public delegate void RowValidationErrorDetectionEventHandler ( string strReason,
                                                                           DataRowChangeEventArgs e ) ;
            
            public event ValidationErrorDetectionEventHandler    ValidationErrorDetected ;
            public event RowValidationErrorDetectionEventHandler RowValidationErrorDetection ;
            
         #endregion
         
      #endregion
      
      #region Protected
         
         #region Methods
         
            protected abstract void InitializeResources ( out DataSet AllowableValuesDataSet, 
                                                          out XmlDocument PersonNameXMLDocument ) ;
            
            protected abstract void FreeResources ( ) ;
            
            protected abstract bool PerformCuztomValidation ( DataSet ValidationDataSet,
                                                              ref string strValidationMessage ) ;
            
            //protected abstract PrimitiveStandardElement GetPrimitiveElementBasedOnTableColumnName ( string strTableName, 
            //                                                                                        string strColumnName ) ;
                                                                                                    
            protected abstract bool IsPersoNameFieldValid ( string strFieldValue ) ;
            
            protected abstract bool IsValuValidWithDICOMType ( string strTableName,
                                                               string strColumnName,
                                                               string strValue ) ;
                                                               
            protected bool IsStringValueNull ( object Value ) 
            {
               try
               {
                  try
                  {
                     if ( Object.Equals ( null, Value ) )
                     {
                        return true ;
                     }
                     
                     if ( String.Empty == Value.ToString ( ) )
                     {
                        return true ;
                     }
                     
                     return false ;
                  }
                  catch ( Exception exception )
                  {
                     System.Diagnostics.Debug.Assert ( false ) ;
                     
                     throw exception ;
                  }    
               }
               catch ( Exception exception )
               {
                  System.Diagnostics.Debug.Assert ( false ) ;
                  
                  throw exception ;
               }
            }
                                                               
                                                               

            protected bool IsPNValueEmpty ( string strValue )
            {
               try
               {
                  string [ ] arrstrPN ;
                  
                  
                  if ( IsStringValueNull ( strValue ) )
                  {
                     return true ;
                  }
                  
                  arrstrPN = strValue.Split ( Constants.SpecialCharacters.PersonName ) ;
                  
                  foreach ( string strField in arrstrPN ) 
                  {
                     if ( strField.Length != 0 )
                     {
                        return false ;
                     }
                  }
                  
                  return true ;
               }
               catch ( System.Exception exception )
               {
                  System.Diagnostics.Debug.Assert ( false, exception.Message ) ;
                   
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
            
         #endregion
         
      #endregion
      
      #region Private
         
         #region Methods
         
                  
            private void ValidateProposedValue 
            ( 
               DataColumnChangeEventArgs e
            )
            {
               try
               {
                  //PrimitiveStandardElement InformationNode ;
                  
                  
                  
                  e.Row.SetColumnError ( e.Column, 
                                         string.Empty ) ;
                                         
                  if ( ( e.Row.RowState == DataRowState.Unchanged || e.Row.RowState == DataRowState.Modified ) && 
                       ( e.Row.Table.ChildRelations.Count != 0 ) )
                  {
                     foreach ( DataColumn PKColumn in e.Column.Table.PrimaryKey )
                     {
                        if ( PKColumn.ColumnName == e.Column.ColumnName )
                        {
                           e.Row.SetColumnError ( e.Column, Constants.ValidationMessages.PK_Edit_Error ) ;
                           
                           OnValidationErrorDetection ( Constants.ValidationMessages.PK_Edit_Error,
                                                        e ) ;
                                                        
                           return ;
                        }
                     }
                  }
                  
                  //InformationNode = GetPrimitiveElementBasedOnTableColumnName ( e.Row.Table.TableName, 
                  //                                                              e.Column.ColumnName ) ;
                                                                                
                  //if ( null != InformationNode ) 
                  //{
                  //   if ( InformationNode.VR == DicomVRType.PN ) 
                  //   {
                  //      if ( ! IsPersoNameFieldValid ( e.ProposedValue.ToString ( ) ) )
                  //      {
                  //         e.Row.SetColumnError ( e.Column, Constants.ValidationMessages.VR_Error ) ;
                           
                  //         OnValidationErrorDetection ( Constants.ValidationMessages.VR_Error,
                  //                                      e ) ;
                        
                  //      }
                           
                  //      return ;
                  //   }
                     
                  //   if ( ! IsElementVRValueValid ( InformationNode, e ) )
                  //   {
                  //      e.Row.SetColumnError ( e.Column, 
                  //                             Constants.ValidationMessages.VR_Error ) ;
                        
                  //      OnValidationErrorDetection ( Constants.ValidationMessages.VR_Error,
                  //                                   e ) ;
                        
                  //      return ;
                  //   }
                     
                  //   if ( ! IsStringValueNull ( e.ProposedValue ) )
                  //   {
                  //      if ( ! IsValueWithinAllowableValues ( InformationNode, e.ProposedValue.ToString ( ) ) )
                  //      {
                  //         e.Row.SetColumnError ( e.Column, 
                  //                                Constants.ValidationMessages.NotAllowableValue_Error ) ;
                           
                  //         OnValidationErrorDetection ( Constants.ValidationMessages.NotAllowableValue_Error,
                  //                                      e ) ;
                        
                  //         return ;
                  //      }
                  //   }
                     
                  //   if ( ! IsValuValidWithDICOMType ( e.Row.Table.TableName, 
                  //                                     e.Column.ColumnName, 
                  //                                     e.ProposedValue.ToString ( ) ) )
                  //   {
                  //      e.Row.SetColumnError ( e.Column, 
                  //                             Constants.ValidationMessages.EmptyValue_Error ) ;
                        
                  //      OnValidationErrorDetection ( Constants.ValidationMessages.EmptyValue_Error,
                  //                                   e ) ;
                        
                  //      return ;
                  //   }
                  //}                                                             
               }
               catch ( Exception exception )
               {
                  System.Diagnostics.Debug.Assert ( false ) ;
                  
                  throw exception ;
               }
            }
            
            
            private void OnValidationErrorDetection 
            ( 
               string strReasonMessage,
               DataColumnChangeEventArgs e
            )
            {
               try
               {
                  if ( null != ValidationErrorDetected ) 
                  {
                     ValidationErrorDetected ( strReasonMessage, e ) ;
                  }      
               }
               catch ( Exception exception )
               {
                  System.Diagnostics.Debug.Assert ( false ) ;
                  
                  throw exception ;
               }
            }
            
            
            
            //private bool IsElementVRValueValid 
            //( 
            //   PrimitiveStandardElement InforamtionPrimitiveStandardElementNode,
            //   DataColumnChangeEventArgs e
            //) 
            //{
            //   try
            //   {
            //      if ( e.Column.DataType != typeof ( DateTime ) )
            //      {
            //         ArrayList ValueArrayList ;
                        
                     
            //         ValueArrayList = new ArrayList ( ) ;
                        
            //         ValueArrayList.Add ( e.ProposedValue.ToString ( ) ) ;
                                                                                                 
            //         InforamtionPrimitiveStandardElementNode.Value = ValueArrayList ;
                        
            //         return DatasetServices.IsElementValueValid ( InforamtionPrimitiveStandardElementNode ) ;
            //      }
            //      else
            //      {
            //         return true ;
            //      }
                  
            //   }
            //   catch ( Exception exception )
            //   {
            //      System.Diagnostics.Debug.Assert ( false ) ;
                  
            //      throw exception ;
            //   }
            //}
            
            
            //private bool IsValueWithinAllowableValues 
            //( 
            //   PrimitiveStandardElement InformationNode, 
            //   object Value 
            //)
            //{
            //   try
            //   {
            //      DicomTag tag ;
                  
                  
            //      tag = DicomTagTable.Instance.Find ( InformationNode.Tag ) ;
                  
            //      foreach ( DataRow ElementDataRow in __AllowableValuesDataSet.Tables [ 0 ].Rows ) 
            //      {
            //         if ( ElementDataRow [ Constants.AllowableValuesTableColumns.TAG ].ToString ( ) == tag.Name )
            //         {
            //            ArrayList AllowableValuesArrayList ;
                        
                        
            //            AllowableValuesArrayList = new ArrayList ( ) ;  
                        
            //            AllowableValuesArrayList.AddRange ( ElementDataRow [ Constants.AllowableValuesTableColumns.VALUES ].ToString ( ).Split ( Constants.SpecialCharacters.VALUES_SEPARATOR.ToCharArray ( ) ) ) ;
                        
            //            return AllowableValuesArrayList.Contains ( Value ) ;
            //         }
            //      }
                  
            //      return true ;
            //   }
            //   catch ( Exception exception )
            //   {
            //      System.Diagnostics.Debug.Assert ( false ) ;
                  
            //      throw exception ;
            //   }
            //}
            
            
            private void ValidateRow ( DataRowChangeEventArgs EvntArgs )
            {
               try
               {
                  if ( ( EvntArgs.Row.RowState == DataRowState.Deleted ) /*|| 
                       ( EvntArgs.Row.RowState == DataRowState.Detached )*/ )
                  {
                     return ;
                  }
                  
                  switch ( EvntArgs.Action )
                  {
                     case DataRowAction.Add:
                     case DataRowAction.Change:
                     case DataRowAction.Commit:
                     {
                        XmlElement  RootElement ;
                        XmlNodeList TableKeyNodeList ;
                        WorklistCatalog catalog ;
                        
                        
                        EvntArgs.Row.RowError = string.Empty ;
                        
                        RootElement = __PersonNameXMLDocument.DocumentElement ;
                        
                        TableKeyNodeList = RootElement.SelectNodes ( Constants.ResInfo.TablesWithRelatedPNColumns.TableNodePath ) ; 
                        catalog          = new WorklistCatalog ( ) ;
                        
                        foreach (  XmlNode TableKeyNode in TableKeyNodeList )
                        {
                           string tablekey ;
                           string tableName ;
                           
                           tablekey  = TableKeyNode.Attributes.GetNamedItem ( Constants.ResInfo.TablesWithRelatedPNColumns.TableFieldKeyName ).Value ;
                           tableName = catalog.GetEntityName ( tablekey ) ;
                           
                           //if ( tableName == EvntArgs.Row.Table.TableName ) 
                           //{
                           //   ArrayList        PersonFullNameArrayList ;
                           //   ArrayList        ValidationRowsArrayList ;
                           //   StringCollection ColumnNamesStringCollection ;
                              
                              
                           //   ValidationRowsArrayList = new ArrayList ( ) ;
                              
                           //   foreach ( XmlNode ColumnGroupXMLNode in TableKeyNode.ChildNodes )
                           //   {
                           //      ColumnNamesStringCollection = GetColumnNames ( ColumnGroupXMLNode ) ;
                                 
                           //      if ( 0 != ColumnNamesStringCollection.Count )
                           //      {
                           //         bool                     fValidationResult = false ;
                           //         PrimitiveStandardElement StandardElement ;
                           //         string                   strPNValue ;
                                    
                                    
                           //         ValidationRowsArrayList.Add ( EvntArgs.Row ) ;
                                    
                           //         PersonFullNameArrayList = DatasetServices.GetPersonNameValue ( ValidationRowsArrayList, 
                           //                                                                        ColumnNamesStringCollection ) ;
                                    
                           //         StandardElement = GetPrimitiveElementBasedOnTableColumnName ( EvntArgs.Row.Table.TableName, 
                           //                                                                       EvntArgs.Row.Table.Columns [ ColumnNamesStringCollection [ 0 ] ].ColumnName ) ;
                                    
                           //         StandardElement.Value = PersonFullNameArrayList ;
                                    
                           //         strPNValue = ( PersonFullNameArrayList.Count != 0 ) ? PersonFullNameArrayList [ 0 ].ToString ( ) : string.Empty ;
                                    
                           //         fValidationResult = DatasetServices.IsElementValueValid ( StandardElement ) ;
                                    
                           //         if ( ! fValidationResult || 
                           //            ! IsValuValidWithDICOMType ( EvntArgs.Row.Table.TableName, 
                           //                                         EvntArgs.Row.Table.Columns [ ColumnNamesStringCollection [ 0 ] ].ColumnName, 
                           //                                         strPNValue )  )
                           //         {
                           //            string           strValidationMsg = string.Empty ;
                           //            StringCollection ColumnFriendlyNames ;
                                       
                                       
                           //            ColumnFriendlyNames = GetColumnFriendlyNames ( tablekey, ColumnGroupXMLNode ) ;
                                       
                           //            if ( 0 != ColumnFriendlyNames.Count )
                           //            {
                           //               strValidationMsg = ColumnFriendlyNames [ 0 ] ;
                                          
                           //               for ( int nColumnIndex = 1; nColumnIndex < ColumnFriendlyNames.Count; nColumnIndex++ )
                           //               {
                           //                  strValidationMsg += String.Concat ( ", ", ColumnFriendlyNames [ nColumnIndex ] ) ;
                           //               }
                           //            }
                                       
                           //            strValidationMsg =  string.Format ( Constants.Messages.RowErrorMessages.PersonNameError,
                           //                                                strValidationMsg ) ;
                           //            EvntArgs.Row.RowError = strValidationMsg ;
                                                                        
                           //            OnRowValidationErrorDetection (  strValidationMsg,
                           //                                             EvntArgs ) ; 
                           //         }
                           //      }
                           //   }
                              
                           //   break ;
                           //}
                        }
                     }
                     
                     break ;
                     
                     default:
                     {
                        return ;      
                     }
                  }
               }
               catch ( Exception exception )
               {
                  System.Diagnostics.Debug.Assert ( false ) ;
                  
                  throw exception ;
               }
            }
            
            
            private StringCollection GetColumnNames ( XmlNode ColumnGroupXMLNode )
            {
               try
               {
                  StringCollection ColumnNamesStringCollection ;
                  
                  
                  ColumnNamesStringCollection = new StringCollection ( ) ;
                  
                  foreach ( XmlNode ColumnChildNode in ColumnGroupXMLNode.ChildNodes )
                  {
                     string strColumnKeyValue ;
                     
                     
                     strColumnKeyValue = ColumnChildNode.Attributes.GetNamedItem ( Constants.ResInfo.TablesWithRelatedPNColumns.ColumnFieldKeyName ).Value ;
                     
                     ColumnNamesStringCollection.Add ( strColumnKeyValue ) ;
                  }
                  
                  return ColumnNamesStringCollection ;
               }
               catch ( Exception exception )
               {
                  System.Diagnostics.Debug.Assert ( false ) ;
                  
                  throw exception ;
               }
            }
            
            
            private StringCollection GetColumnFriendlyNames
            ( 
               string tableKey, 
               XmlNode ColumnGroupXMLNode 
            )
            {
               try
               {
                  WorklistCatalog  catalog ;
                  StringCollection ColumnFriendlyNameStringCollection ;
                  
                  
                  catalog                            = new WorklistCatalog ( ) ;
                  ColumnFriendlyNameStringCollection = new StringCollection ( ) ;
                  
                  foreach ( XmlNode ColumnChildNode in ColumnGroupXMLNode.ChildNodes )
                  {
                     string strColumnKeyValue ;
                     
                     
                     strColumnKeyValue = ColumnChildNode.Attributes.GetNamedItem ( Constants.ResInfo.TablesWithRelatedPNColumns.ColumnFieldKeyName ).Value ;
                     
                     ColumnFriendlyNameStringCollection.Add ( catalog.GetEntityElementDisplayName ( tableKey, strColumnKeyValue )) ;
                  }
                  
                  return ColumnFriendlyNameStringCollection ;
               }
               catch ( Exception exception )
               {
                  System.Diagnostics.Debug.Assert ( false ) ;
                  
                  throw exception ;
               }
            }
            
            
            
            private void OnRowValidationErrorDetection 
            ( 
               string  strReason,
               DataRowChangeEventArgs e
            )
            {
               try
               {
                  if ( null != RowValidationErrorDetection ) 
                  {
                     RowValidationErrorDetection ( strReason, e ) ;
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
         
            
            private XmlDocument __PersonNameXMLDocument
            {
               get
               {
                  return m_PersonNameXMLDocument ;
               }
            
               set 
               {
                  m_PersonNameXMLDocument = value ;
               }
            }
            
            
            private DataSet __AllowableValuesDataSet
            {
               get
               {
                  return m_AllowableValuesDataSet ;
               }
               
               set
               {
                  m_AllowableValuesDataSet = value ;
               }
            }
            
         #endregion
         
         #region Events
         
            private void ValidationDataTable_ColumnChanging
            (
               object sender, 
               DataColumnChangeEventArgs e
            )
            {
               try
               {
                  ValidateProposedValue ( e ) ;
               }
               catch ( Exception exception )
               {
                  System.Diagnostics.Debug.Assert ( false ) ;
                  
                  throw exception ;
               }
            }
            
            
            private void ValidationDataTable_RowChanging
            (
               object sender, 
               DataRowChangeEventArgs e
            )
            {
               try
               {
                  ValidateRow ( e ) ;     
               }
               catch ( Exception exception )
               {
                  System.Diagnostics.Debug.Assert ( false ) ;
                  
                  throw exception ;
               }
            }
            
         #endregion
         
         #region Data Members
         
            private XmlDocument m_PersonNameXMLDocument ;
            private DataSet     m_AllowableValuesDataSet ;
            
         #endregion
         
         #region Data Types Definition
            
            private class Constants
            {
               public class ValidationMessages
               {
                  public const string VR_Error                = "Invalid DICOM VR." ;
                  public const string EmptyValue_Error        = "Empty value is not allowed." ;
                  public const string NotAllowableValue_Error = "Out of range or invalid value." ;
                  public const string PK_Edit_Error           = "Can't change primary key value." ;
               }
               
               
               public class ResInfo
               {
                  public class TablesWithRelatedPNColumns
                  {
                     public const string TableNodePath = "/TablesWithRelatedPNColumns/Table" ;
                     
                     public const string ColumnFieldKeyName = "Key" ;
                     public const string TableFieldKeyName  = "Key" ;
                  }
               }
               
               
               public class AllowableValuesTableColumns
               {
                  public const string TAG    = "Tag" ;
                  public const string VALUES = "Values" ;
               }
               
               
               public class SpecialCharacters
               {
                  public const string VALUES_SEPARATOR = "," ;
                  public const char   PersonName       = '^' ;
               }
               
               
               public class Messages
               {
                  public class RowErrorMessages
                  {
                     public const string PersonNameError = "Invalid person name value for the following column(s): {0}." ;
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


// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System ;
using System.Data ;
using System.Reflection;
using System.Xml ;
using Leadtools.Medical.Worklist.DataAccessLayer.BusinessEntity;


namespace Leadtools.Medical.Winforms
{
   class MWLDataSetValidator : DataSetValidator
   {
      #region Public
         
         #region Methods
         
            public MWLDataSetValidator ( )
            {
               try
               {
                  Init ( ) ;
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
         
            protected override void InitializeResources 
            ( 
               out DataSet AllowableValuesDataSet, 
               out XmlDocument PersonNameXMLDocument 
            ) 
            {
               try
               {
                  
                  AllowableValuesDataSet = new DataSet ( ) ;
                  
                  AllowableValuesDataSet.ReadXml ( Assembly.GetExecutingAssembly ( ).GetManifestResourceStream ( Constants.Resources.DICOM_ELEMENTS_ALLOWABLE_VALUES ) ) ;

                  PersonNameXMLDocument = InitPersonNameXMLDocument ( ) ;
               }
               catch ( System.Exception exception )
               {
                  System.Diagnostics.Debug.Assert ( false, exception.Message ) ;
                   
                  throw exception ;
               }
            }
         
         
            protected override void FreeResources ( )
            {}
            
            protected override bool PerformCuztomValidation 
            ( 
               DataSet ValidationDataSet,
               ref string strValidationMessage 
            ) 
            {
               try
               {
                  if ( ! IsStationAETitlesValid ( ValidationDataSet ) )
                  {
                     strValidationMessage = Constants.ValidationMessages.Step_AE_Relation_Error ;
                     
                     return false ;
                  }
                  else
                  {
                     strValidationMessage = Constants.ValidationMessages.Success ;
                     
                     return true ;
                  }  
               }
               catch ( System.Exception exception )
               {
                  System.Diagnostics.Debug.Assert ( false, exception.Message ) ;
                   
                  throw exception ;
               }
            }
            
            
            //protected override PrimitiveStandardElement GetPrimitiveElementBasedOnTableColumnName 
            //( 
            //   string strTableName, 
            //   string strColumnName 
            //)
            //{
            //   try
            //   {
            //      PrimitiveIODElement TempIODElement ;
                  
                  
            //      TempIODElement = GetPrimitiveElementBasedOnTableColumnName ( __ValidationIODTree, 
            //                                                                   strTableName, 
            //                                                                   strColumnName ) ;

            //      if ( null != TempIODElement ) 
            //      {
            //         return new PrimitiveStandardElement ( TempIODElement.Tag, TempIODElement.VR ) ;
            //      }                                                                               
            //      else
            //      {
            //         return null ;
            //      }
            //   }
            //   catch ( System.Exception exception )
            //   {
            //      System.Diagnostics.Debug.Assert ( false, exception.Message ) ;
                   
            //      throw exception ;
            //   }
            //}
            
            
            protected override bool IsPersoNameFieldValid ( string strFieldValue )
            {
               try
               {
                  int nNotAllowedValueIndex = -99 ;
                        
                        
                  nNotAllowedValueIndex = strFieldValue.IndexOf ( Constants.General.PersonNameNotAllowedValues ) ;
                        
                  if ( -1 != nNotAllowedValueIndex )
                  {
                     return false ;
                  }
                  else
                  {
                     return true ;
                  }
               }
               catch ( Exception exception )
               {
                  System.Diagnostics.Debug.Assert ( false ) ;
                        
                  throw exception ;
               }
            }
            
            
            protected override bool IsValuValidWithDICOMType 
            ( 
               string strTableName,
               string strColumnName,
               string strValue 
            )
            {
               try
               {
                  //PrimitiveIODElement  InformationNode ;
                  
                  
                  //InformationNode = GetPrimitiveElementBasedOnTableColumnName ( __ValidationIODTree,
                  //                                                              strTableName, 
                  //                                                              strColumnName ) ;
                  
                  //if ( InformationNode.SupportType == SupportType.Type1 )
                  //{
                  //   if ( InformationNode.VR ==  DicomVRType.PN )
                  //   {
                  //      return ( ! IsPNValueEmpty ( strValue ) ) ;
                  //   }
                  //   else
                  //   {
                  //      return ( ! IsStringValueNull ( strValue ) ) ;
                  //   }
                  //}
                  
                  return true ;
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
            
         #endregion
         
      #endregion
      
      #region Private
         
         #region Methods
         
            private void Init ( )
            {
               try
               {
                  //__ValidationIODTree = new MWLCFindIODTreesDepository ( ).GetTree ( MWLCFindIODTreesDepository.IODTreeKey.ModalityWorkListKey ) ;
               }
               catch ( Exception exception )
               {
                  System.Diagnostics.Debug.Assert ( false ) ;
                  
                  throw exception ;
               }
            }
         
            
            private XmlDocument InitPersonNameXMLDocument ( )
            {
               try
               {
                  XmlDocument PersonNameXMLDocument ;
                  
                  
                  PersonNameXMLDocument = new XmlDocument ( ) ;
                  
                  
                  PersonNameXMLDocument.Load ( Assembly.GetExecutingAssembly ( ).GetManifestResourceStream ( Constants.Resources.TablesWithRelatedPNColumns ) ) ;
                  
                  return PersonNameXMLDocument ;
               }
               catch ( Exception exception )
               {
                  System.Diagnostics.Debug.Assert ( false ) ;
                  
                  throw exception ;
               }
            }
            
                  
            //private PrimitiveIODElement GetPrimitiveElementBasedOnTableColumnName 
            //( 
            //   TreeNode ParentElement,
            //   string strTableName, 
            //   string strColumnName 
            //)
            //{
            //   try
            //   {  
            //      foreach ( TreeNode Node in ParentElement.Nodes )
            //      {
            //         if ( IsTreeNodeMatch ( Node, strTableName, strColumnName ) )
            //         {
            //            return ( PrimitiveIODElement ) Node ;
            //         }
            //         else
            //         {
            //            TreeNode ReturnedTreeNode ;
                        
                        
            //            ReturnedTreeNode = GetPrimitiveElementBasedOnTableColumnName ( Node,
            //                                                                           strTableName, 
            //                                                                           strColumnName) ;
                                                                                       
            //            if ( null != ReturnedTreeNode )
            //            {
            //               return ( PrimitiveIODElement ) ReturnedTreeNode ;
            //            }
            //         }
            //      }
                  
            //      return null ;
            //   }
            //   catch ( Exception exception )
            //   {
            //      System.Diagnostics.Debug.Assert ( false ) ;
                  
            //      throw exception ;
            //   }
            //}
            
            
            //private bool IsTreeNodeMatch 
            //( 
            //   TreeNode Node, 
            //   string strTableName, 
            //   string strColumnName 
            //)
            //{
            //   try
            //   {
            //      if ( Node is PrimitiveIODElement )
            //      {
            //         PrimitiveIODElement InformationNode ;
                     
                     
            //         InformationNode = ( PrimitiveIODElement ) Node ;
                     
            //         if ( ( InformationNode.TableName == strTableName ) &&
            //              ( InformationNode.ColumnsNames.Contains ( strColumnName ) ) )
            //         {
            //            return true ;
            //         }
            //      }
                  
            //      return false ;
            //   }
            //   catch ( Exception exception )
            //   {
            //      System.Diagnostics.Debug.Assert ( false ) ;
                  
            //      throw exception ;
            //   }
            //}
            
            
            
            
            private bool IsStationAETitlesValid ( DataSet ValidationDataSet )
            {
               try
               {
                  DataTable     ScheduledProcedureStepDataTable = null ;
                  DataRelation  StepWithAETitlesDataRelation    = null ;
                  
                  
                  ScheduledProcedureStepDataTable = ( ( MWLDataset ) ValidationDataSet ).ScheduledProcedureStep ;
                  
                  if ( null == ScheduledProcedureStepDataTable ) 
                  {
                     throw new Exception ( Constants.Messages.ExceptionMessages.STEP_TABLE_NOT_FOUND ) ;
                  }
                  
                  StepWithAETitlesDataRelation = ScheduledProcedureStepDataTable.ChildRelations [ Constants.RelationNames.SCHEDULED_STEP_WITH_STATION_AE_TITLES ] ;
                  
                  if ( null == StepWithAETitlesDataRelation ) 
                  {
                     throw new Exception ( Constants.Messages.ExceptionMessages.STEP_WITH_AE_RELATION_NOT_FOUND ) ;
                  }
                     
                  foreach ( DataRow ValidatedDataRow in  ScheduledProcedureStepDataTable.Rows )
                  {
                     if ( ( ValidatedDataRow.RowState != DataRowState.Deleted ) &&
                          ( ValidatedDataRow.RowState != DataRowState.Detached ) )
                     {
                        DataRow[] arrRelatedDataRow ;
                        
                        
                        arrRelatedDataRow = ValidatedDataRow.GetChildRows ( StepWithAETitlesDataRelation ) ;
                        
                        if ( 0 == arrRelatedDataRow.Length ) 
                        {
                           ValidatedDataRow.RowError = Constants.Messages.RowErrorMessages.StepAERelationError ;
                           
                           return false ;
                        }
                     }
                  }
                  
                  return true ;
               }
               catch ( Exception exception )
               {
                  System.Diagnostics.Debug.Assert ( false ) ;
                  
                  throw exception ;
               }
            }
            
            
         #endregion
         
         #region Properties
         

            //private RootElement __ValidationIODTree
            //{
            //   get
            //   {
            //      return m_ValidationIODTree ;
            //   }
            
            //   set 
            //   {
            //      m_ValidationIODTree = value ;
            //   }
            //}
            
            
         #endregion
         
         #region Events
         
         #endregion
         
         #region Data Members
         
            //private RootElement m_ValidationIODTree ;
            
         #endregion
         
         #region Data Types Definition
            
            private class Constants
            {
               public class ValidationMessages
               {
                  public const string Success                = "Success" ;
                  public const string Step_AE_Relation_Error = "Scheduled Procedure Step needs at least a single AE Title value." ;
               }
               
               public class General
               {
                  public const string PersonNameNotAllowedValues = "^" ;
               }
               
               public class RelationNames
               {
                  public const string SCHEDULED_STEP_WITH_STATION_AE_TITLES = "ScheduledProcedureStepScheduledStationAETitles" ; //"Scheduled Procedure Step-Scheduled Station AE Titles" ;
               }
               
               
               public class Resources
               {
                  public const string DICOM_ELEMENTS_ALLOWABLE_VALUES = "Leadtools.Medical.Winforms.WorklistDatabaseEditor.DataSetValidator.MWLDataSetValidator.DICOMElementsAllowableValues.DICOMElementsAllowableValues.xml" ;
                  public const string TablesWithRelatedPNColumns      = "Leadtools.Medical.Winforms.WorklistDatabaseEditor.DataSetValidator.MWLDataSetValidator.TablesWithRelatedPNColumns.TablesWithRelatedPNColumns.xml" ;
               }
               
               
               public class Messages
               {
                  public class RowErrorMessages
                  {
                     public const string StepAERelationError = "Scheduled Procedure Step needs at least a single AE title value." ;
                  }
                  
                  public class ExceptionMessages
                  {
                     public const string STEP_TABLE_NOT_FOUND            = "Scheduled Procedure Step table not found." ;
                     public const string STEP_WITH_AE_RELATION_NOT_FOUND = "ScheduledStationAETitles relation not found" ;
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


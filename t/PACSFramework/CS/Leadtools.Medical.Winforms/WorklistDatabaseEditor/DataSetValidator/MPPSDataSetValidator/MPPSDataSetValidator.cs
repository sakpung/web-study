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
   class MPPSDataSetValidator : DataSetValidator
   {
      #region Public
         
         #region Methods
         
            public MPPSDataSetValidator ( )
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

                  MPPSDataset MPPSValidationDataSet ;
                  
                  
                  MPPSValidationDataSet = ( MPPSDataset ) ValidationDataSet ;
                  
                  return ValidateMPPSDataSet ( MPPSValidationDataSet, ref strValidationMessage ) ;
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
                  return true ;
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
                  //   if ( InformationNode.VR == DicomVRType.PN )
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
                  //__ValidationIODTree = new MppsNCreateIODTreesDepository ( ).GetTree ( MppsNCreateIODTreesDepository.IODTreeKey.CreatePerformedProcedureStepKey ) ;
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
            //              ( InformationNode.ColumnsName == strColumnName ) )
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
            
            
            private bool ValidateMPPSDataSet 
            ( 
               MPPSDataset MPPSValidationDataSet, 
               ref string strValidationMessage 
            )
            {
               try
               {
                  MPPSDataset.PPSInformationDataTable InformationDatatable ;
                  
                  
                  InformationDatatable = MPPSValidationDataSet.PPSInformation ;
                  
                  foreach ( MPPSDataset.PPSInformationRow MPPSRow in InformationDatatable.Rows )
                  {
                     if ( MPPSRow.RowState != DataRowState.Deleted &&
                          MPPSRow.RowState != DataRowState.Detached ) 
                     {
                        if ( MPPSRow.GetPPSRelationshipRows ( ).Length == 0 )
                        {
                           strValidationMessage = Constants.ValidationMessages.Invalid_relational_Data ;
                           
                           MPPSRow.RowError = strValidationMessage ;
                  
                           return false ;   
                        }

                        if ( MPPSRow.PerformedProcedureStepStatus != Constants.StatusValues.InProgress )
                        {
                           if ( MPPSRow.IsPerformedProcedureStepEndDateNull ( ) ||
                                MPPSRow.IsPerformedProcedureStepEndTimeNull ( ) )
                           {
                              strValidationMessage = Constants.ValidationMessages.Invalid_PPS_Date ;
                              
                              MPPSRow.RowError = strValidationMessage ;
                  
                              return false ;   
                           }
                           
                           if ( MPPSRow.GetPerformedSeriesSequenceRows ( ).Length == 0 )
                           {
                              strValidationMessage = Constants.ValidationMessages.Invalid_PerformedSeriesSequence ; 
                              
                              MPPSRow.RowError = strValidationMessage ;
                  
                              return false ;   
                           }
                        }
                     }                          
                  }
               
                  strValidationMessage = Constants.ValidationMessages.Success ;
                  
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
               public class StatusValues
               {
                  public const string InProgress = "IN PROGRESS" ;
               }
               
               public class ValidationMessages
               {
                  public const string Success                         = "Success" ;
                  public const string Invalid_relational_Data         = "Invalid relational data." ;
                  public const string Invalid_PPS_Date                = "Invalid Performed Procedure end date/time." ;
                  public const string Invalid_PerformedSeriesSequence = "Performed Series Sequence data doesn't exist." ; 
               }
               
               public class Resources
               {
                  public const string DICOM_ELEMENTS_ALLOWABLE_VALUES = "Leadtools.Medical.Winforms.WorklistDatabaseEditor.DataSetValidator.MPPSDataSetValidator.DICOMElementsAllowableValues.DICOMElementsAllowableValues.xml" ;
                  public const string TablesWithRelatedPNColumns      = "Leadtools.Medical.Winforms.WorklistDatabaseEditor.DataSetValidator.MPPSDataSetValidator.TablesWithRelatedPNColumns.TablesWithRelatedPNColumns.xml" ;
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


// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System ;
using System.Collections ;
using System.Data ;
using Leadtools.Medical.Worklist.DataAccessLayer.BusinessEntity ;


namespace Leadtools.Medical.Winforms
{
   class DataSetValidatorManager
   {
      #region Public
         
         #region Methods
         
            public DataSetValidatorManager ( )
            {
               try
               {
                  Init ( ) ;
               }
               catch ( System.Exception exception )
               {
                  System.Diagnostics.Debug.Assert ( false, exception.Message ) ;
                   
                  throw exception ;
               }
            }
            
            
            public void BeginValidation ( DataSet ValidationDataSet )
            {
               try
               {
                  DataSetValidator CurrentValidator ;
                  
                  
                  CurrentValidator = GetValidator ( ValidationDataSet ) ;
                  
                  CurrentValidator.BeginValidation ( ValidationDataSet ) ;
               }
               catch ( System.Exception exception )
               {
                  System.Diagnostics.Debug.Assert ( false, exception.Message ) ;
                   
                  throw exception ;
               }
            }
            
            public void EndValidation ( DataSet ValidationDataSet )
            {
               try
               {
                  DataSetValidator CurrentValidator ;
                  
                  
                  CurrentValidator = GetValidator ( ValidationDataSet ) ;
                  
                  CurrentValidator.EndValidation ( ValidationDataSet ) ;
               }
               catch ( System.Exception exception )
               {
                  System.Diagnostics.Debug.Assert ( false, exception.Message ) ;
                   
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
                  DataSetValidator CurrentValidator ;
                  
                  
                  CurrentValidator = GetValidator ( ValidationDataSet ) ;
                  
                  return CurrentValidator.IsDataSetValid ( ValidationDataSet, 
                                                           ref strValidationMessage ) ;
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
         
            public event DataSetValidator.ValidationErrorDetectionEventHandler ValidationErrorDetected
            {
               add
               {
                  ( ( DataSetValidator ) __ValidatorTable [ ValidatorType.MWLValidator ] ).ValidationErrorDetected  += value ;
                  ( ( DataSetValidator ) __ValidatorTable [ ValidatorType.MPPSValidator ] ).ValidationErrorDetected += value ;
               }
                        
                        
               remove
               {
                  ( ( DataSetValidator ) __ValidatorTable [ ValidatorType.MWLValidator ] ).ValidationErrorDetected  -= value ;
                  ( ( DataSetValidator ) __ValidatorTable [ ValidatorType.MPPSValidator ] ).ValidationErrorDetected -= value ;
               }
            }
            
            
            public event DataSetValidator.RowValidationErrorDetectionEventHandler RowValidationErrorDetection
            {
               add
               {
                  ( ( DataSetValidator ) __ValidatorTable [ ValidatorType.MWLValidator ] ).RowValidationErrorDetection  += value ;
                  ( ( DataSetValidator ) __ValidatorTable [ ValidatorType.MPPSValidator ] ).RowValidationErrorDetection += value ;
               }
                        
                        
               remove
               {
                  ( ( DataSetValidator ) __ValidatorTable [ ValidatorType.MWLValidator ] ).RowValidationErrorDetection  -= value ;
                  ( ( DataSetValidator ) __ValidatorTable [ ValidatorType.MPPSValidator ] ).RowValidationErrorDetection -= value ;
               }
            }
            
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
         
            private void Init ( ) 
            {
               try
               {
                  __ValidatorTable = new Hashtable ( ) ;
                  
                  __ValidatorTable.Add ( ValidatorType.MWLValidator, new MWLDataSetValidator ( ) ) ;
                  __ValidatorTable.Add ( ValidatorType.MPPSValidator, new MPPSDataSetValidator ( ) ) ;
               }
               catch ( System.Exception exception )
               {
                  System.Diagnostics.Debug.Assert ( false, exception.Message ) ;
                   
                  throw exception ;
               }
            }
            
            private DataSetValidator GetValidator ( DataSet ValidationDataSet )
            {
               try
               {
                  if ( ValidationDataSet is MWLDataset )
                  {
                     return ( DataSetValidator ) __ValidatorTable [ ValidatorType.MWLValidator ] ;
                  }
                  
                  if ( ValidationDataSet is MPPSDataset ) 
                  {
                     return ( DataSetValidator ) __ValidatorTable [ ValidatorType.MPPSValidator ] ;
                  }
                  
                  throw new Exception ( "Invalid DataSet type." ) ;
               }
               catch ( System.Exception exception )
               {
                  System.Diagnostics.Debug.Assert ( false, exception.Message ) ;
                   
                  throw exception ;
               }
            }
            
            
         #endregion
         
         #region Properties
         
            private Hashtable __ValidatorTable
            {
               get
               {
                  return m_ValidatorTable ;
               }
               
               
               set
               {
                  m_ValidatorTable = value ;
               }
            }
            
         #endregion
         
         #region Events
            
         #endregion
         
         #region Data Members
         
            private Hashtable m_ValidatorTable ;
            
         #endregion
         
         #region Data Types Definition
         
            private enum ValidatorType
            {
               MWLValidator,
               MPPSValidator
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

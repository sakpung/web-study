// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System ;
using System.Collections ;
using System.ComponentModel ;
using System.Drawing ;
using System.Data ;
using System.Windows.Forms ;


namespace Leadtools.Medical.Winforms
{

   partial class RequestedProcedureQuery : UserControl
   {
      #region Public
         
         #region Methods
         
            public RequestedProcedureQuery ( )
            {
               try
               {
                  InitializeComponent ( ) ;      
               }
               catch ( Exception exception )
               {
                  System.Diagnostics.Debug.Assert ( false ) ;
                  
                  throw exception ;
               }
            }
            
            
            public void Reset ( ) 
            {
               try
               {
                  txtRequestedProcedureID.Text = string.Empty ;
                  txtStudyInstanceUID.Text     = string.Empty ;
                  
                  chkLow.Checked     = false ;
                  chkHight.Checked   = false ;
                  chkMedium.Checked  = false ;
                  chkRoutine.Checked = false ;
                  chkStat.Checked    = false ;
               }
               catch ( Exception exception )
               {
                  System.Diagnostics.Debug.Assert ( false ) ;
                  
                  throw exception ;
               }
            }
            
         #endregion
         
         #region Properties
         
            public string RequestedProcedureID
            {
               get
               {
                  return txtRequestedProcedureID.Text ;
               }
            }
            
            
            public string StudyInstanceUID
            {
               get
               {
                  return txtStudyInstanceUID.Text ;
               }
            }
            

            public string RequestedProcedurePriority
            {
               get
               {
                  string strRequestedProcedurePriority = string.Empty ;
                  
                  
                  if ( chkStat.Checked ) 
                  {
                     strRequestedProcedurePriority = chkStat.Tag.ToString ( ) ;
                     strRequestedProcedurePriority += Constants.PriorityDelimiter ;
                  }
                  
                  if ( chkHight.Checked ) 
                  {
                     strRequestedProcedurePriority += chkHight.Tag.ToString ( ) ;
                     strRequestedProcedurePriority += Constants.PriorityDelimiter ;
                  }
                  
                  if ( chkRoutine.Checked ) 
                  {
                     strRequestedProcedurePriority += chkRoutine.Tag.ToString ( ) ;
                     strRequestedProcedurePriority += Constants.PriorityDelimiter ;
                  }
                  
                  if ( chkMedium.Checked ) 
                  {
                     strRequestedProcedurePriority += chkMedium.Tag.ToString ( ) ;
                     strRequestedProcedurePriority += Constants.PriorityDelimiter ;
                  }
                  
                  if ( chkLow.Checked ) 
                  {
                     strRequestedProcedurePriority += chkLow.Tag.ToString ( ) ;
                     strRequestedProcedurePriority += Constants.PriorityDelimiter ;
                  }
                  
                  if ( strRequestedProcedurePriority != string.Empty ) 
                  {
                     strRequestedProcedurePriority = strRequestedProcedurePriority.TrimEnd ( Constants.PriorityDelimiter.ToCharArray ( ) ) ;
                  }
                  
                  return strRequestedProcedurePriority ;
               }
            }

            
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
         
         #endregion
         
         #region Data Types Definition
         
            private class Constants
            {
               public const string PriorityDelimiter = "," ; 
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

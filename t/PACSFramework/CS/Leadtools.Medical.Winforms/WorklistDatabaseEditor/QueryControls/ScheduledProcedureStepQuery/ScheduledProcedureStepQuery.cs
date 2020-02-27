// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System ;
using System.Collections ;
using System.ComponentModel ;
using System.Drawing ;
using System.Data ;
using System.Reflection ; 
using System.Windows.Forms ;
using Leadtools.Medical.Winforms.Control ;


namespace Leadtools.Medical.Winforms
{
   partial class ScheduledProcedureStepQuery : UserControl
   {
      #region Public
         
         #region Methods
         
            public ScheduledProcedureStepQuery ( )
            {
               try
               {
                  InitializeComponent ( ) ;  
                  
                  Init ( ) ;
                  
                  RegisterEvents ( ) ;
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
                  txtScheduledProcedureStepStationAETitle.Text   = string.Empty ;
                  txtScheduledProcedureStepID.Text               = string.Empty ;
                  txtScheduledPerformingPhysicianMiddleName.Text = string.Empty ;
                  txtScheduledPerformingPhysicianFirstName.Text  = string.Empty ;
                  txtScheduledPerformingPhysicianLastName.Text   = string.Empty ;
                  
                  dtpicScheduledProcedureStepStartDateTimeFrom.Checked = false ;
                  dtpicScheduledProcedureStepStartDateTimeTo.Checked   = false ;
                  
                  ctlcmbScheduledProcedureStepModality.ClearCheckedItems ( ) ;
               }
               catch ( Exception exception )
               {
                  System.Diagnostics.Debug.Assert ( false ) ;
                  
                  throw exception ;
               }
            }
            
            
         #endregion
         
         #region Properties
         
            public string ScheduledProcedureStepID
            {
               get
               {
                  return txtScheduledProcedureStepID.Text ;
               }
            }
            
            
            public string Modality
            {
               get
               {
                  try
                  {
                     return ctlcmbScheduledProcedureStepModality.Text ;
                  }
                  catch ( Exception exception )
                  {
                     System.Diagnostics.Debug.Assert ( false ) ;
                     
                     throw exception ;
                  }
               }
            }
            
            
            public string StationAETitle
            {
               get
               {
                  return txtScheduledProcedureStepStationAETitle.Text ;
               }
            }
            
            
            public string ScheduledPerformingPhysicianFirstName
            {
               get
               {
                  return txtScheduledPerformingPhysicianFirstName.Text ;
               }
            }
            
            
            public string ScheduledPerformingPhysicianMiddleName
            {
               get
               {
                  return txtScheduledPerformingPhysicianMiddleName.Text ;
               }
            }
            
            
            public string ScheduledPerformingPhysicianLastName
            {
               get
               {
                  return txtScheduledPerformingPhysicianLastName.Text ;
               }
            }
            
            
            public string ScheduledProcedureStepStartDateTimeFrom
            {
               get
               {
                  if ( dtpicScheduledProcedureStepStartDateTimeFrom.Checked ) 
                  {
                     return dtpicScheduledProcedureStepStartDateTimeFrom.Value.ToString ( ) ;
                  }
                  else
                  {
                     return ( String.Empty ) ;
                  }
               }
            }
            
            
            public string ScheduledProcedureStepStartDateTimeTo
            {
               get
               {
                  if ( dtpicScheduledProcedureStepStartDateTimeTo.Checked ) 
                  {
                     return dtpicScheduledProcedureStepStartDateTimeTo.Value.ToString ( ) ;
                  }
                  else
                  {
                     return ( String.Empty ) ;
                  }
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
         
            private void Init ( )
            {
               try
               {
                  FixDateTimeControlsMinValue ( ) ;
                  
                  CheckedComboBox.FillModalities ( ctlcmbScheduledProcedureStepModality ) ;
               }
               catch ( Exception exception )
               {
                  System.Diagnostics.Debug.Assert ( false ) ;
                  
                  throw exception ;
               }
            }
            
            
            private void RegisterEvents ( )
            {
               try
               {
                  dtpicScheduledProcedureStepStartDateTimeFrom.ValueChanged += new EventHandler ( dtpicScheduledProcedureStepStartDateTimeFrom_ValueChanged ) ;
               }
               catch ( Exception exception )
               {
                  System.Diagnostics.Debug.Assert ( false ) ;
                  
                  throw exception ;
               }   
            }
            
            
            private void FixDateTimeControlsMinValue ( ) 
            {
               try
               {
                  FixStartDateTo ( ) ;
               }
               catch ( Exception exception )
               {
                  System.Diagnostics.Debug.Assert ( false ) ;
                  
                  throw exception ;
               }
            }
            
            
            private void FixStartDateTo ( ) 
            {
               try
               {
                  dtpicScheduledProcedureStepStartDateTimeTo.MinDate = dtpicScheduledProcedureStepStartDateTimeFrom.Value ;
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
         
            
            private void dtpicScheduledProcedureStepStartDateTimeFrom_ValueChanged
            (
               object sender, 
               EventArgs e
            )
            {
               try
               {
                  FixStartDateTo ( ) ;
               }
               catch ( Exception exception )
               {
                  System.Diagnostics.Debug.Assert ( false ) ;
                  
                  throw exception ;
               }
            }
            
         #endregion
         
         #region Data Members
         
         #endregion

         #region Data Types Definition
         
            
            private class Constants
            {
               public class BindingInfo
               {
                  public class PropertyName
                  {
                     public class SystemGUI
                     {
                        public const string CHECKED = "Checked" ;
                        public const string ENABLED = "Enabled" ;
                     }
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

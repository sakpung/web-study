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
   partial class PatientQuery : UserControl
   {
      #region Public
         
         #region Methods
         
            public PatientQuery ( )
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
                  txtPatientQueryFirstName.Text  = string.Empty ;
                  txtPatientQueryID.Text         = string.Empty ;
                  txtPatientQueryIssuerOfID.Text = string.Empty ;
                  txtPatientQueryLastName.Text   = string.Empty ;
                  txtPatientQueryMiddleName.Text = string.Empty ;
                  
                  dtpicBirthDateFrom.Checked = false ;
                  dtpicBirthDateTo.Checked   = false ;
               }
               catch ( Exception exception )
               {
                  System.Diagnostics.Debug.Assert ( false ) ;
                  
                  throw exception ;
               }
            }
            
            
         #endregion
         
         #region Properties
         
            public string PatientID
            {
               get
               {
                  return txtPatientQueryID.Text ;
               }
            }
            
            
            public string IssuerOfPatientID
            {
               get
               {
                  return txtPatientQueryIssuerOfID.Text ;
               }
            }
            
            
            public string FirstName
            {
               get
               {
                  return txtPatientQueryFirstName.Text ;
               }
            }
            
            
            public string MiddleName
            {
               get
               {
                  return txtPatientQueryMiddleName.Text ;
               }
            }
            
            
            public string LastName
            {
               get
               {
                  return txtPatientQueryLastName.Text ;
               }
            }
            
            
            public string DateOfBirthFrom
            {
               get
               {
                  if ( dtpicBirthDateFrom.Checked ) 
                  {
                     return dtpicBirthDateFrom.Value.ToShortDateString ( ) ;   
                  }
                  else
                  {
                     return string.Empty ;
                  }
               }
            }
            
            
            public string DateOfBirthTo
            {
               get
               {
                  if ( dtpicBirthDateTo.Checked ) 
                  {
                     return dtpicBirthDateTo.Value.ToShortDateString ( ) ;   
                  }
                  else
                  {
                     return string.Empty ;
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
                  dtpicBirthDateFrom.ValueChanged += new EventHandler(dtpicBirthDateFrom_ValueChanged);
               }
               catch ( Exception exception )
               {
                  System.Diagnostics.Debug.Assert ( false ) ;
                  
                  throw exception ;
               }
            }
            
            
            private void FixBirthDateTo ( )
            {
               try
               {
                  dtpicBirthDateTo.MinDate = dtpicBirthDateFrom.Value ;
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
         
            private void dtpicBirthDateFrom_ValueChanged
            (
               object sender, 
               EventArgs e
            )
            {
               try
               {
                  FixBirthDateTo ( ) ;
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

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
   partial class InstanceUIDController : System.Windows.Forms.UserControl
   {
      #region Public
         
         #region Methods
         
            public InstanceUIDController ( )
            {
               try
               {
                  InitializeComponent ( ) ;   
                  
                  RegisterEvents ( ) ;
               }
               catch ( System.Exception exception )
               {
                  System.Diagnostics.Debug.Assert ( false, exception.Message ) ;
                   
                  throw exception ;
               }
            }

            
            public void Reset ( ) 
            {
               try
               {
                  lstSOPInstanceUID.Items.Clear ( ) ;
               }
               catch ( System.Exception exception )
               {
                  System.Diagnostics.Debug.Assert ( false, exception.Message ) ;
                   
                  throw exception ;
               }
            }
            
            
         #endregion
         
         #region Properties
         
            public string Caption
            {
               get
               {
                  return grpSSOPInstanceUID.Text ;
               }
               
               set
               {
                  grpSSOPInstanceUID.Text = value ;
               }
            }
         
            public string SOPInstanceUIDs
            {
               get
               {
                  if ( lstSOPInstanceUID.Items.Count != 0 ) 
                  {
                     string strSOPInstanceUIDs = string.Empty ;
                           
                           
                     foreach ( string strCurrentSOPInstanceUIDs in lstSOPInstanceUID.Items )
                     {
                        strSOPInstanceUIDs += strCurrentSOPInstanceUIDs  + "," ;
                     }
                           
                     if ( strSOPInstanceUIDs.Length != 0 )
                     {
                        strSOPInstanceUIDs = strSOPInstanceUIDs.Remove ( strSOPInstanceUIDs.LastIndexOf ( "," ), 1 ) ;
                     }
                           
                     return strSOPInstanceUIDs ;
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
         
            private void RegisterEvents ( )
            {
               try
               {
                  btnSOPInstanceUIDAdd.Click             += new EventHandler ( btnSOPInstanceUIDAdd_Click ) ;
                  btnSOPInstanceUIDRemove.Click          += new EventHandler ( btnSOPInstanceUIDRemove_Click ) ;
                  lstSOPInstanceUID.SelectedIndexChanged += new EventHandler ( lstSOPInstanceUID_SelectedIndexChanged ) ;
               }
               catch ( System.Exception exception )
               {
                  System.Diagnostics.Debug.Assert ( false, exception.Message ) ;
                   
                  throw exception ;
               }
            }
            
            
            private void InsertSOPInstanceUID ( )
            {
               try
               {
                  if ( txtSOPInstanceUID.Text.Length != 0  )
                  {
                     lstSOPInstanceUID.Items.Add ( txtSOPInstanceUID.Text ) ;
                           
                     txtSOPInstanceUID.Text = string.Empty ;
                  }
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
         
            private void btnSOPInstanceUIDAdd_Click
            (
               object sender, 
               EventArgs e
            )
            {
               try
               {
                  InsertSOPInstanceUID ( ) ;
                  
                  txtSOPInstanceUID.Focus ( ) ;                  
               }
               catch ( System.Exception exception )
               {
                  System.Diagnostics.Debug.Assert ( false, exception.Message ) ;
                   
                  throw exception ;
               }
            }
            
            
            private void btnSOPInstanceUIDRemove_Click
            (
               object sender, 
               EventArgs e
            )
            {
               try
               {
                  if ( lstSOPInstanceUID.SelectedIndices.Count != 0 )
                  {
                     int nSelectedIndex = -1 ;
                     
                     
                     nSelectedIndex = lstSOPInstanceUID.SelectedIndex ;
                     
                     lstSOPInstanceUID.Items.RemoveAt ( nSelectedIndex ) ;
                     
                     if ( nSelectedIndex < lstSOPInstanceUID.Items.Count )
                     {
                        lstSOPInstanceUID.SelectedIndex = nSelectedIndex ;
                     }
                     else
                     {
                        nSelectedIndex = nSelectedIndex - 1 ;
                        
                        if ( nSelectedIndex >= 0 )
                        {
                           lstSOPInstanceUID.SelectedIndex = nSelectedIndex ;
                        }
                     }
                     
                  }
                  
                  if ( lstSOPInstanceUID.SelectedIndices.Count == 0 )
                  {
                     btnSOPInstanceUIDRemove.Enabled = false ;
                  }
               }
               catch ( System.Exception exception )
               {
                  System.Diagnostics.Debug.Assert ( false, exception.Message ) ;
                   
                  throw exception ;
               }
            }
            
            
            private void lstSOPInstanceUID_SelectedIndexChanged
            (
               object sender, 
               EventArgs e
            )
            {
               try
               {
                  if ( lstSOPInstanceUID.SelectedIndices.Count != 0 )
                  {
                     btnSOPInstanceUIDRemove.Enabled = true ;
                  }
                  else
                  {
                     btnSOPInstanceUIDRemove.Enabled = false ;
                  }
               }
               catch ( System.Exception exception )
               {
                  System.Diagnostics.Debug.Assert ( false, exception.Message ) ;
                   
                  throw exception ;
               }
            }
            
         #endregion
         
         #region Data Members

         #endregion
         
         #region Data Types Definition
            
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

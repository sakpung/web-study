// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System ;
using System.Windows.Forms ;


namespace Leadtools.Medical.Winforms.Win32
{
   class NativeWindowSubclassingService : System.Windows.Forms.NativeWindow
   {
      #region Public
         
         #region Methods
         
            
            public NativeWindowSubclassingService ( ) { }
            
            public NativeWindowSubclassingService 
            (
               IntPtr nptrHandle, 
               bool fSubClass 
            ) 
            {
               try
               {
                  base.AssignHandle ( nptrHandle ) ;
                  
                  this.IsSubClassed = fSubClass ;  
               }
               catch ( Exception exception )
               {
                  System.Diagnostics.Debug.Assert ( false ) ;
                  
                  throw exception ;
               }
            }
            
            
         #endregion
         
         #region Properties
            
            public bool IsSubClassed
            {
               get
               {
                  return m_fIsSubClassed ;
               }
                  
               set 
               {
                  m_fIsSubClassed = value ;
               }
            }
                  
            
         #endregion
         
         #region Events
            
         #endregion
         
         #region Data Types Definition
            
         #endregion
         
         #region Callbacks
      
            public delegate void SubClassWndProcEventHandler ( ref System.Windows.Forms.Message m,
                                                               ref bool fHandled ) ;
               
            public event SubClassWndProcEventHandler SubClassedWndProc ;
            
         #endregion
         
      #endregion
      
      #region Protected
         
         #region Methods
         
            protected override void WndProc ( ref Message m )  
            {
               try
               {
                  if ( this.IsSubClassed )
                  {
                     bool fHandled  = false ;
                     
                     OnSubClassedWndProc ( ref m, ref fHandled ) ;
                     
                     if ( fHandled ) 
                     {
                        return ;
                     }
                  }
                  
                  base.WndProc ( ref m ) ;  
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
         
            private void OnSubClassedWndProc 
            ( 
               ref Message m,
               ref bool fHandled
            ) 
            {
               try
               {
                  if ( SubClassedWndProc != null )
                  {
                     this.SubClassedWndProc ( ref m, ref fHandled ) ;
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
         
         #endregion
         
         #region Events
            
         #endregion
         
         #region Data Members
         
            private bool m_fIsSubClassed = false ;
            
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

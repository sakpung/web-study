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
using System.Runtime.InteropServices ;
using Leadtools.Medical.Winforms.Win32 ;


namespace Leadtools.Medical.Winforms.Control
{
   class VirtualListViewColumn : Component
   {
      #region Public
         
         #region Methods
            
         public object GetValue ( object objRow ) 
         {
            try
            {
               if ( PropertyDescriptor == null )
               {
                  return null ;
               }
               
               try
               {
                  object objReturnValue ;
                  
                  
                  if ( ( PropertyDescriptor.ComponentType == typeof ( DataRowView ) )&&  //using PropertyDescriptor.GetValue fail sometimes for DataView, so this method will retrieve the value manually
                       ( objRow is DataRowView ) ) 
                  {
                     DataRowView drView = ( DataRowView ) objRow ;
                     
                     
                     objReturnValue = drView [ PropertyDescriptor.Name ] ;
                  }
                  else
                  {
                     objReturnValue = PropertyDescriptor.GetValue ( objRow ) ;
                  }
                  
                  if ( null != Formatter )
                  {
                     return Formatter.Format ( MappingName,
                                               objReturnValue,
                                               null ) ;
                  }
                  else
                  {
                     return objReturnValue ;
                  }
               }
               catch ( Exception exception )
               {
                  System.Diagnostics.Debug.Assert ( false, exception.Message ) ;
                        
                  return string.Empty ;
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
            
            [ DefaultValue ( Constants.DefaultEmptyValue ) ] 
            public string MappingName 
            {
               get 
               {
                  return m_strMappingName ; 
               }
                     
                     
               set 
               {
                  m_strMappingName = value ; 
               }
            }

                  
            [ Browsable ( false ) ]
            public PropertyDescriptor PropertyDescriptor
            {
               get 
               {
                  return m_PropertyDescriptor ; 
               }
                     
                     
               set 
               {
                  m_PropertyDescriptor = value ; 
               }
            }

            
            [ DefaultValue ( Constants.DefaultEmptyValue ) ]
            public string NullText 
            {
               get 
               {
                  return m_strnullText ; 
               }
                     
                     
               set 
               {
                  m_strnullText = value ; 
               }
            }
                  
                  
            [ DefaultValue ( Constants.DefaultColumnWidth ) ]
            public int Width 
            {
               get 
               {
                  return m_nWidth ; 
               }
                     
                     
               set 
               {
                  m_nWidth = value ;

                  ApplyColumnSize ( ) ;
               }
            }

            public int Index
            {
               get
               {
                  return m_Index ;
               }
                     
               set
               {
                  m_Index = value ;
               }
            }

            
            [ DefaultValue ( Constants.DefaultEmptyValue ) ]
            public string HeaderText 
            {
               get 
               {
                  return m_strHeaderText ; 
               }
               set 
               {
                  m_strHeaderText = value ; 
               }
            }
            
            
            [ DefaultValue ( null ) ]
            public object Tag 
            {
               get 
               {
                  return m_objTag ; 
               }
               set 
               {
                  m_objTag = value ; 
               }
            }
            
            
            [ Browsable ( false ) ]
            public ICustomFormatter Formatter
            {
               get
               {
                  return m_Formatter ;
               }
               
               
               set
               {
                  m_Formatter = value ;
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
         
            private void ApplyColumnSize (  )
            {
               if ( null != ParentListView ) 
               {
                  //Win32APIWrapper.LVCOLUMNW ListViewColumn ;
                  
                  
                  //ListViewColumn = new Leadtools.Medical.Winforms.Win32.Win32APIWrapper.LVCOLUMNW ( ) ;
                  
                  //ListViewColumn.mask = Win32APIWrapper.Win32Constants.ListViewColumnFilter.LVCF_WIDTH ;
                  //ListViewColumn.cx   = Width ;
                  
                  //Win32APIWrapper.SendMessage ( this.ParentListView.Handle,
                  //                              Win32APIWrapper.Win32Constants.ListViewMessages.LVM_SETCOLUMN,
                  //                              this.Index,
                  //                              ref ListViewColumn ) ;
                  
                  Win32APIWrapper.SendMessage ( this.ParentListView.Handle, 4126, this.Index, Width);
               }
            }
               
         #endregion
            
         #region Properties
               
         #endregion
            
         #region Events
               
         #endregion
            
         #region Data Members
            
         private string m_strMappingName = string.Empty ;
         private string m_strHeaderText  = string.Empty ;
         private string m_strnullText    = string.Empty ;
         private int    m_nWidth         = Constants.DefaultColumnWidth ;
         private object m_objTag         = null ;
         private int    m_Index          = -1 ;
         
         private VirtualListView    m_ParentListView ;
         private PropertyDescriptor m_PropertyDescriptor = null ; 
         private ICustomFormatter   m_Formatter ;

               
         #endregion
            
         #region Data Types Definition
         
            private class Constants
            {
               public const int    DefaultColumnWidth  = 50 ;
               
               public const string DefaultEmptyValue = "" ;
            }
               
         #endregion
            
      #endregion
      
      #region internal
         
         #region Methods
            
         internal void Bind ( ) 
         {
            CurrencyManager              listmanager ;
            PropertyDescriptorCollection PropertyDescCollection ;
                  
                  
            if ( PropertyDescriptor != null )
            {
               return ;
            }
                     
            listmanager = ParentListView.ListManager ;
                  
            if ( listmanager == null )
            {
               return ;
            }
                     
            PropertyDescCollection = listmanager.GetItemProperties ( ) ;
                  
            for ( int i = 0; i < PropertyDescCollection.Count; ++i ) 
            {
               PropertyDescriptor descriptor ;
                     
                     
               descriptor = PropertyDescCollection [ i ] ;
                     
               if ( ! ( typeof ( IList ).IsAssignableFrom ( descriptor.PropertyType ) ) && 
                  ( descriptor.Name == MappingName ) )
               {
                  this.PropertyDescriptor = descriptor ;
                        
                  return ;
               }
            }
         }


         internal void CreateColumn ( ) 
         {
            try
            {
               Win32APIWrapper.LVCOLUMNW ListViewColumn ;
                           
                           
               ListViewColumn = new Win32APIWrapper.LVCOLUMNW ( ) ;
                           
               ListViewColumn.mask = Win32APIWrapper.Win32Constants.ListViewColumnFilter.LVCF_FMT | 
                                     Win32APIWrapper.Win32Constants.ListViewColumnFilter.LVCF_WIDTH | 
                                     Win32APIWrapper.Win32Constants.ListViewColumnFilter.LVCF_TEXT | 
                                     Win32APIWrapper.Win32Constants.ListViewColumnFilter.LVCF_SUBITEM ;
                                                   
               ListViewColumn.iSubItem = this.Index ;                                                     //Index of sub-item associated with the column. 
               ListViewColumn.fmt      = Win32APIWrapper.Win32Constants.ListViewFormat.LVCFMT_LEFT ; //Alignment of the Column Text and the contents
               ListViewColumn.cx       = this.Width ;                                                         //Width in pixels
               ListViewColumn.pszText  = this.HeaderText ;
                           
               Win32APIWrapper.InsertColumn ( this.ParentListView.Handle, 
                                              Win32APIWrapper.Win32Constants.ListViewMessages.LVM_INSERTCOLUMNW, 
                                              this.Index, 
                                              ref ListViewColumn ) ;
                                              
               ApplyColumnSize ( ) ;
            }
            catch ( Exception exception )
            {
               System.Diagnostics.Debug.Assert ( false ) ;
                           
               throw exception ;
            }
         }
               
         #endregion
            
         #region Properties
         
            internal VirtualListView ParentListView
            {
               get
               {
                  return m_ParentListView ;
               }
               
               
               set
               {
                  if ( value != m_ParentListView ) 
                  {
                     m_ParentListView = value ;
                     
                     //ApplyColumnSize ( ) ;
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
   }
}

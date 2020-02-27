// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Leadtools.Wizard
{
   [DefaultEvent ( "SetActive" ) ] 
   public partial class WizardPage : UserControl
   {
      #region Public
   
         #region Methods
         
            public WizardPage ( )
            {
               try
               {
                  InitializeComponent ( ) ;

                  this.Load += new EventHandler ( WizardPage_Load ) ;
               }
               catch ( Exception exception )
               {
                  System.Diagnostics.Debug.Assert ( false, exception.Message ) ;
                                 
                  throw ;
               }
            }


            public virtual void OnSetActive(object sender, WizardCancelEventArgs e)
            {
               try
               {
                  if ( SetActive != null )
                  {
                     SetActive ( sender, e ) ;
                  }
                  
                  GetWizard ( ).SetWizardButtons ( GetWizardButtons ( ) ) ;
               }
               catch ( Exception exception )
               {
                  System.Diagnostics.Debug.Assert ( false, exception.Message ) ;
                                 
                  throw ;
               }
            }         
            
            public virtual void OnWizardNext ( object sender, WizardPageEventArgs e )
            {
               try
               {
                  if ( WizardNext != null )
                  {
                     WizardNext ( sender, e ) ;
                  }
               }
               catch ( Exception exception )
               {
                  System.Diagnostics.Debug.Assert ( false, exception.Message ) ;
                                 
                  throw ;
               }
            }
   
            public virtual void OnWizardBack ( object sender, WizardPageEventArgs e )
            {
               try
               {
                  if ( WizardBack != null )
                  {
                     WizardBack ( sender, e ) ;
                  }
               }
               catch ( Exception exception )
               {
                  System.Diagnostics.Debug.Assert ( false, exception.Message ) ;
                                 
                  throw ;
               }
            }
            
            public virtual void OnWizardFinish ( object sender, CancelEventArgs e ) 
            {
               try
               {
                  if ( null != WizardFinish )
                  {
                     WizardFinish ( sender, e ) ;
                  }
               }
               catch ( Exception exception )
               {
                  System.Diagnostics.Debug.Assert ( false, exception.Message ) ;
                                 
                  throw ;
               }
            }

            public virtual void OnWizardCancel ( object sender, CancelEventArgs e ) 
            {
               try
               {
                  if ( null != WizardCancel )
                  {
                     WizardCancel ( sender, e ) ;
                  }
               }
               catch ( Exception exception )
               {
                  System.Diagnostics.Debug.Assert ( false, exception.Message ) ;
                                 
                  throw ;
               }
            }

            public virtual void OnOptionButton1(object sender, EventArgs e)
            {
            }

            public virtual void OnReset()
            {
            }
                        
   
         #endregion
   
         #region Properties
   
         #endregion
   
         #region Events
   
         #endregion
   
         #region Data Types Definition
   
         #endregion
   
         #region Callbacks
         
            [ Category ( "Wizard" ) ]
            public event CancelEventHandler SetActive ;
            
            [ Category ( "Wizard" ) ]
            public event WizardPageEventHandler WizardNext ;
            
            [ Category ( "Wizard" ) ]
            public event WizardPageEventHandler WizardBack ;
            

            [ Category ( "Wizard" ) ]
            public event CancelEventHandler WizardFinish ;
            
            
            [ Category ( "Wizard" ) ]
            public event CancelEventHandler WizardCancel ;                        
            
   
         #endregion
   
      #endregion
   
      #region Protected
   
         #region Methods
         
            protected WizardSheet GetWizard ( )
            {
               try
               {
                  if ( null != m_parentWizard )
                  {
                     return m_parentWizard ;
                  }
                  else
                  {
                     throw new ApplicationException ( "This page is not included in a WizardSheet." ) ;
                  }
               }
               catch ( Exception exception )
               {
                  System.Diagnostics.Debug.Assert ( false, exception.Message ) ;
                                 
                  throw ;
               }
            }
            
            protected virtual void SetWizardButtons ( )
            {
               try
               {
                  if ( null != m_parentWizard )
                  {
                     GetWizard ( ).SetWizardButtons ( GetWizardButtons ( ) ) ;
                  }
               }
               catch ( Exception exception )
               {
                  System.Diagnostics.Debug.Assert ( false, exception.Message ) ;
                                 
                  throw ;
               }
            }
            
            protected virtual WizardSheet.WizardButtons GetWizardButtons ( ) 
            {
               try
               {
                  return WizardSheet.WizardButtons.Back | WizardSheet.WizardButtons.Cancel | WizardSheet.WizardButtons.Next | WizardSheet.WizardButtons.About ;
               }
               catch ( Exception exception )
               {
                  System.Diagnostics.Debug.Assert ( false, exception.Message ) ;
                                 
                  throw ;
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

            void WizardPage_Load(object sender, EventArgs e)
            {
               try
               {
                  SetWizardButtons ( ) ;
               }
               catch ( Exception exception )
               {
                  System.Diagnostics.Debug.Assert ( false, exception.Message ) ;
                                 
                  throw ;
               }
            }  
   
         #endregion
   
         #region Properties
         
         #endregion
   
         #region Events
   
         #endregion
   
         #region Data Members
         
            private WizardSheet m_parentWizard ;
            private WizardPage  m_previousPage ;
   
         #endregion
   
         #region Data Types Definition
   
         #endregion
   
      #endregion
   
      #region internal
   
         #region Methods
   
         #endregion
   
         #region Properties
         
            
            internal WizardSheet ParentWizard
            {
               get
               {
                  return m_parentWizard ;
               }
               
               set
               {
                  m_parentWizard = value ;
               }
            }
            
            internal WizardPage PreviousPage
            {
               get
               {
                  return m_previousPage ;
               }
               
               set
               {
                  m_previousPage = value ;
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

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
   public partial class InternalPage : WizardPage
   {
      #region Public
   
         #region Methods
         
            public InternalPage ( ) 
            {
               try
               {
                  InitializeComponent ( ) ;
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
   
         #region Data Types Definition
   
         #endregion
   
         #region Callbacks
   
         #endregion
   
      #endregion
   
      #region Protected
   
         #region Methods
         
            protected override WizardSheet.WizardButtons GetWizardButtons ( )
            {
               try
               {
                   WizardPage page = GetWizard().ActivePage;

                   if (page != null)
                   {
                       int index = GetWizard().Pages.IndexOf(page);

                       if(index+1 < GetWizard().Pages.Count)
                           return WizardSheet.WizardButtons.Cancel | WizardSheet.WizardButtons.Back | WizardSheet.WizardButtons.Next | WizardSheet.WizardButtons.About;
                   }
                  return WizardSheet.WizardButtons.Cancel | WizardSheet.WizardButtons.Back | WizardSheet.WizardButtons.About ;
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

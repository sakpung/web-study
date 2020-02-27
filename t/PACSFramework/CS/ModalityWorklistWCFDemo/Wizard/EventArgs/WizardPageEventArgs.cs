// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System ;
using System.Collections.Generic ;
using System.Text ;
using System.ComponentModel ;


namespace Leadtools.Wizard
{
   public delegate void WizardPageEventHandler ( object sender, WizardPageEventArgs e ) ;
   
   public class WizardPageEventArgs: CancelEventArgs
   {
      public WizardPageEventArgs ( WizardPage currentPage )
      {
         _currentPage = currentPage ;
      }
      
      WizardPage _newPage = null ;
      WizardPage _currentPage = null ;

      public WizardPage NewPage
      {
         get 
         { 
            return _newPage ; 
         }
         
         set 
         { 
            _newPage = value ; 
         }
      }
      
      public WizardPage CurrentPage
      {
         get 
         { 
            return _currentPage ; 
         }
         
      }      
   }
}

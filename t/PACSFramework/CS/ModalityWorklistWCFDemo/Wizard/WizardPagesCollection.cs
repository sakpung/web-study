// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Text;

namespace Leadtools.Wizard
{
   public class WizardPagesCollection : List <WizardPage>
   {
      WizardSheet _parent ;
      
      internal WizardPagesCollection ( WizardSheet parent ) 
      {
         _parent = parent ;
      }
      public new void Add ( WizardPage page )
      {
         page.ParentWizard = _parent ;
         
         base.Add ( page ) ;
      }
   }
}

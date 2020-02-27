// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Configuration ;
using System.Linq;
using System.Text;

namespace Leadtools.Medical.Worklist.AddIns.Configuration
{
   public class ModalityPerformedProcedureCreateDataSetValidationElement : DataSetValidationElement
   {
      private const string ValidateRelationalToIHERulesProperty  = "validateRelationalToIHERules" ;
      
      
      [ConfigurationProperty(ValidateRelationalToIHERulesProperty, IsRequired = false, DefaultValue=false)]
      public bool ValidateRelationalToIHERules
      {
         get
         {
            return bool.Parse ( base [ ValidateRelationalToIHERulesProperty ].ToString ( ) ) ;
         }
         
         set
         {
            base [ ValidateRelationalToIHERulesProperty ] = value ;
         }
      }
   }
}

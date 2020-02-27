// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Leadtools.Medical.Rules.AddIn.Common;

namespace Leadtools.Medical.Rules.AddIn.Dialogs
{
   public interface IRulesConfigurationDialog
   {
      string AETitle { get; set; }

      void SetRules(List<RuleItem> rules);      
      bool Save();

      event EventHandler<SaveRuleEventArgs> SaveRule;
      event EventHandler<GetFailuresEventArgs<StoreFailure>> GetStoreFailures;
      event EventHandler<GetFailuresEventArgs<MoveServer>> GetMoveFailures;
      event EventHandler SaveOptions;
   }
}

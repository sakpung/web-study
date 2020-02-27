// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace Leadtools.Medical.Rules.AddIn
{
    public class SaveRuleEventArgs : CancelEventArgs
    {
        private RuleItem _RuleItem;

        public RuleItem RuleItem
        {
            get { return _RuleItem; }           
        }       

        public SaveRuleEventArgs(RuleItem rule)
        {
            _RuleItem = rule;
        }
    }
}

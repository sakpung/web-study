// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Leadtools.Medical.Rules.AddIn
{
    public class RuleItem
    {
        public string FileName { get; set; }
        public ServerRule Rule { get; set; }        

        public RuleItem()
        {
           FileName = string.Empty;
        }

        public RuleItem(ServerRule rule)
        {
            Rule = rule;
        }

        public RuleItem(ServerRule rule, string filename)
            : this(rule)
        {
            FileName = filename;
        }
    }
}

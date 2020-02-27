// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using Leadtools.Wizard;

namespace Leadtools.Wizard
{
    public class WizardCancelEventArgs : CancelEventArgs
    {
        public WizardPage PreviousPage { get; set; }
    }
}

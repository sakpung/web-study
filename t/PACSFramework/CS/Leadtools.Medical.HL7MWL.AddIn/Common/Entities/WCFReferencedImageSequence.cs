// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Leadtools.Medical.Worklist.DataAccessLayer.MatchingParameters;
using System.Runtime.Serialization;
using Leadtools.Medical.DataAccessLayer.Catalog;

namespace Leadtools.Medical.HL7MWL.AddIn
{
    
    public class WCFReferencedImageSequence : ReferencedImageSequence
    {
        [EntityElementAttribute]    
        public string SeriesInstanceUID
        {
            get;
            set;
        }
    }
}

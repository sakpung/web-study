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

namespace Leadtools.Medical.HL7MWL.AddIn
{
    
    public class WCFVisit : Visit
    {
        private ReferencedPatientSequence _ReferencedPatientSequence = new ReferencedPatientSequence();

        public override string CatalogKey
        {
           get
           {
              return "Visit";
           }
        }

    
        public ReferencedPatientSequence ReferencedPatientSequence
        {
            get { return _ReferencedPatientSequence; }
            set { _ReferencedPatientSequence = value; }
        }
    }
}

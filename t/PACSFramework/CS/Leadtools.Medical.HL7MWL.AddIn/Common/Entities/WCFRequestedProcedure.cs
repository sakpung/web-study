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
    
    public class WCFRequestedProcedure : RequestedProcedure
    {
        private RequestedProcedureCodeSequence _RequestedProcedureCodeSequence;

        
        public RequestedProcedureCodeSequence RequestedProcedureCodeSequence
        {
            get { return _RequestedProcedureCodeSequence; }
            set { _RequestedProcedureCodeSequence = value; }
        }

        private List<ReferencedStudySequence> _ReferencedStudySequence = new List<ReferencedStudySequence>();

        
        public List<ReferencedStudySequence> ReferencedStudySequence
        {
            get { return _ReferencedStudySequence; }
            set { _ReferencedStudySequence = value; }
        }

        
        public WCFVisit Visit { get; set; }
    }
}

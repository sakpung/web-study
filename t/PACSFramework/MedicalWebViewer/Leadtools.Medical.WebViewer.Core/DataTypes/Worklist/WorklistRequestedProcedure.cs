// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using Leadtools.Medical.Worklist.DataAccessLayer.MatchingParameters;

namespace Leadtools.Medical.WebViewer.DataContracts
{
    [DataContract]
    public class WorklistRequestedProcedure : RequestedProcedure
    {       
        [DataMember]
        public CodeSequence RequestedProcedureCodeSequence { get; set; }

        [DataMember]
        public List<ReferencedStudySequence> ReferencedStudySequence { get; set; }
    }
}

// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using Leadtools.Medical.Worklist.DataAccessLayer.MatchingParameters;

namespace Leadtools.Medical.WebViewer.DataContracts
{
    [DataContract]
    public class WorklistQueryOptions
    {
        [DataMember]
        public WorklistPatient Patient { get; set; }

        [DataMember]
        public ImagingServiceRequest ImagingServiceRequest { get; set; }

        [DataMember]
        public WorklistScheduledProcedureStep ScheduledProcedureStep { get; set; }
    }
}

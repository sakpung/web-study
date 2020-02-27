// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Leadtools.Medical.WebViewer.DataContracts;
using Leadtools.Medical.Worklist.DataAccessLayer.MatchingParameters;

namespace Leadtools.Medical.WebViewer.ServiceContracts
{
    public interface IWorklistAddin
    {
        string AddPatient(string userName, WorklistPatient patient);
        WorklistResult[] QueryWorklist(string userName, WorklistQueryOptions options);
        void AddImagingServiceRequest(string userName, string patientID, string issuerOfPatientID, ImagingServiceRequest request);
        void AddRequestedProcedure(string userName, string accessionNumber, WorklistRequestedProcedure procedure);
        void AddScheduledProcedureStep(string userName, string accessionNumber, string requestedProcedureID, WorklistScheduledProcedureStep procedureStep);
        string AddCaptureRequest(string userName, string patientID, string issuerOfPatientID, CaptureRequest request);
    }
}

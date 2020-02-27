// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using Leadtools.Medical.DataAccessLayer;
using Leadtools.Medical.WebViewer.Addins.Common;
using Leadtools.Medical.WebViewer.DataContracts;
using Leadtools.Medical.WebViewer.ServiceContracts;
using Leadtools.Medical.Worklist.DataAccessLayer;
using Leadtools.Medical.Worklist.DataAccessLayer.BusinessEntity;
using Leadtools.Dicom.AddIn;
using Leadtools.Medical.Worklist.DataAccessLayer.MatchingParameters;
using Leadtools.Dicom.Common.Extensions;

namespace Leadtools.Medical.WebViewer.Addins
{
    public class WorklistAddin : IWorklistAddin
    {
        private IWorklistDataAccessAgent _DataAccessAgent;

        public WorklistAddin(IWorklistDataAccessAgent dataAccessAgent)
        {
            _DataAccessAgent = dataAccessAgent;
        }

        public string AddPatient(string userName, WorklistPatient patient)
        {
           MWLDataset ds = new MWLDataset();

            ds.AddPatient(patient);
            _DataAccessAgent.UpdateMWL(ds);
            return patient.PatientID;
        }

         public WorklistResult[] QueryWorklist(string userName, WorklistQueryOptions options)
         {
             List<WorklistResult> results = new List<WorklistResult>();
             MatchingParameterCollection matchingCollection = new MatchingParameterCollection();
             MatchingParameterList matchingList = new MatchingParameterList();
             MWLDataset dataset = null;


             matchingCollection.Add(matchingList);
             AddInsUtils.FillWorklistMatchingParameters(options, matchingList);
             dataset = _DataAccessAgent.QueryModalityWorklists(matchingCollection, new StringCollection());
             foreach(MWLDataset.ScheduledProcedureStepRow row in dataset.ScheduledProcedureStep.Rows)
             {
                 WorklistResult result = new WorklistResult();

                 result.ScheduledProcedureStep = new WorklistScheduledProcedureStep();
                 result.Patient = new WorklistPatient();
                 row.CopyTo(result.ScheduledProcedureStep);

                 row.RequestedProcedureRowParent.ImagingServiceRequestRow.PatientRowParent.CopyTo(result.Patient);
                 results.Add(result);

                 result.ImagingServiceRequest = new ImagingServiceRequest();
                 row.RequestedProcedureRowParent.ImagingServiceRequestRow.CopyTo(result.ImagingServiceRequest);

                 result.RequestedProcedure = new WorklistRequestedProcedure();
                 row.RequestedProcedureRowParent.CopyTo(result.RequestedProcedure);
             }

             return results.ToArray();
         }

        public string AddCaptureRequest(string userName, string patientID, string issuerOfPatientID, CaptureRequest request)
        {
            Check.ArgumentNotNull(request.ImagingServiceRequest, "ImagingServiceRequest");
            Check.ArgumentNotNull(request.RequestedProcedure, "WorklistRequestedProcedure");
            Check.ArgumentNotNull(request.ScheduledProcedureStep, "ScheduledProcedureStep");
           
            AddImagingServiceRequest(userName, patientID, issuerOfPatientID, request.ImagingServiceRequest);
            AddRequestedProcedure(userName, request.ImagingServiceRequest.AccessionNumber, request.RequestedProcedure);
            AddScheduledProcedureStep(userName, request.ImagingServiceRequest.AccessionNumber, request.RequestedProcedure.RequestedProcedureID, request.ScheduledProcedureStep);
            return string.Empty;
        }

        public void AddImagingServiceRequest(string userName, string patientID, string issuerOfPatientID, ImagingServiceRequest request)
        {
            Patient patient = new Patient() { PatientID = patientID, IssuerOfPatientID = issuerOfPatientID };

            Check.ArgumentNotNullOrEmpty(request.AccessionNumber, "AccessionNumber");
            Check.ArgumentNotNullOrEmpty(patientID, "patientID");
            Check.ArgumentNotNullOrEmpty(issuerOfPatientID, "issuerOfPatientID");

            using (MWLDataset ds = _DataAccessAgent.Find(new ImagingServiceRequest() { AccessionNumber = request.AccessionNumber }))
            {
                if (ds != null && ds.ImagingServiceRequest.Rows.Count > 0)
                {
                    throw new Exception("Primary key violation. Accession number already exists.");
                }
            }

            using (MWLDataset ds = _DataAccessAgent.Find(patient))
            {
                if (ds != null && ds.Patient.Rows.Count > 0)
                {
                    ds.AddImagingServiceRequest(patient, request);
                    _DataAccessAgent.UpdateMWL(ds);
                }
            }
        }

        public void AddRequestedProcedure(string userName, string accessionNumber, WorklistRequestedProcedure procedure)
        {
            ImagingServiceRequest imgRequest = new ImagingServiceRequest() { AccessionNumber = accessionNumber };

            Check.ArgumentNotNullOrEmpty(accessionNumber, "accessionNumber");
            Check.ArgumentNotNullOrEmpty(procedure.RequestedProcedureID, "RequestedProceureID");            
            Check.ArgumentNotNullOrEmpty(procedure.RequestedProcedureDescription, "RequestedProcedureDescription");

            if(string.IsNullOrEmpty(procedure.StudyInstanceUID))
            {
                procedure.StudyInstanceUID = DicomUtilities.GenerateDicomUniqueIdentifier();
            }

            if (procedure.RequestedProcedureCodeSequence != null)
            {
                Check.ArgumentNotNullOrEmpty(procedure.RequestedProcedureCodeSequence.CodeValue, "RequestedProcedureCodeSequence.CodeValue");
                Check.ArgumentNotNullOrEmpty(procedure.RequestedProcedureCodeSequence.CodingSchemeDesignator, "RequestedProcedureCodeSequence.CodingSchemeDesignator");
            }

            if (procedure.ReferencedStudySequence != null)
            {
                foreach (ReferencedStudySequence rs in procedure.ReferencedStudySequence)
                {
                    Check.ArgumentNotNullOrEmpty(rs.ReferencedSOPClassUID, "ReferencedStudySequence.ReferencedSOPClassUID");
                    Check.ArgumentNotNullOrEmpty(rs.ReferencedSOPInstanceUID, "ReferencedStudySequence.ReferencedSOPInstanceUID");
                }
            }

            using (MWLDataset ds = _DataAccessAgent.Find(imgRequest))
            {
                ImagingServiceRequest isr = new ImagingServiceRequest();

                imgRequest.CopyTo(isr);
                ds.AddRequestedProcedure(isr, procedure);
                _DataAccessAgent.UpdateMWL(ds);
            }
        }

        public void AddScheduledProcedureStep(string userName, string accessionNumber, string requestedProcedureID, WorklistScheduledProcedureStep procedureStep)
        {
            ImagingServiceRequest imgRequest = new ImagingServiceRequest() { AccessionNumber = accessionNumber };
            WorklistRequestedProcedure reqProcedure = new WorklistRequestedProcedure() { RequestedProcedureID = requestedProcedureID };

            Check.ArgumentNotNullOrEmpty(requestedProcedureID, "requestedProcedureID");
            Check.ArgumentNotNullOrEmpty(accessionNumber, "accessionNumber");
            Check.ArgumentNotNullOrEmpty(requestedProcedureID, "requestedProcedureID");
            Check.ArgumentNotNull(procedureStep.ScheduledProcedureStepStartDate_Time, "ScheduledProcedureStepStartDate_Time");
            Check.ArgumentNotNullOrEmpty(procedureStep.Modality, "Modality");
            Check.ArgumentNotNullOrEmpty(procedureStep.ScheduledProcedureStepDescription, "ScheduledProcedureStepDescription");

            if (procedureStep.ScheduledProtocolCodeSequence != null)
            {
                foreach (ScheduledProtocolCodeSequence cs in procedureStep.ScheduledProtocolCodeSequence)
                {
                    Check.ArgumentNotNullOrEmpty(cs.CodeValue, "ScheduledProtocolCodeSequence.CodeValue");
                    Check.ArgumentNotNullOrEmpty(cs.CodingSchemeDesignator, "ScheduledProtocolCodeSequence.CodingSchemeDesignator");
                }
            }

            using (MWLDataset ds = _DataAccessAgent.Find(imgRequest, reqProcedure))
            {
                if (ds != null && ds.RequestedProcedure.Rows.Count > 0)
                {
                    ds.AddScheduledProcedureStep(imgRequest, reqProcedure, procedureStep);
                    _DataAccessAgent.UpdateMWL(ds);
                }
            }
        }
    }
}

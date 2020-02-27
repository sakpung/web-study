// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using Leadtools.Dicom;
using Leadtools.Medical.Worklist.DataAccessLayer.BusinessEntity;
using Leadtools.Medical.Worklist.DataAccessLayer.MatchingParameters;
using System;
using System.Collections.Generic;

namespace Leadtools.Medical.HL7MWL.AddIn
{
   public class BrokerService : IBrokerService
   {
      public BrokerService()
      {

      }
      #region IBrokerService Members

      private void NullTheEmpty(WCFPatient patient)
      {
         if (patient.LastMenstrualDate.HasValue && patient.LastMenstrualDate.Value.IsEmpty)
         {
            patient.LastMenstrualDate = null;
         }
         if (patient.PatientBirthDate.HasValue && patient.PatientBirthDate.Value.IsEmpty)
         {
            patient.PatientBirthDate = null;
         }
      }

      public MWLDataset BeginTransaction()
      {
         return new MWLDataset();
      }

      public void CommitTransaction(MWLDataset ds)
      {
         try
         {
            DB.DataAccess.UpdateMWL(ds);
         }
         finally
         {
            ds.Dispose();
         }
      }

      public void RollbackTransaction(MWLDataset ds)
      {
         ds.Dispose();
      }

      public void AddPatient(WCFPatient patient, MWLDataset ds)
      {
         Guard.ArgumentNotNullOrEmpty(patient.PatientID, "PatientID");
         Guard.ArgumentNotNullOrEmpty(patient.IssuerOfPatientID, "IssuerOfPatientID");
         Guard.ArgumentNotNullOrEmpty(patient.PatientNameFamilyName + patient.PatientNameGivenName +
                                      patient.PatientNameMiddleName, "Patient Name");

         NullTheEmpty(patient);

         ds.AddPatient(patient);
      }

      public void AddPatient(WCFPatient patient)
      {
         Guard.ArgumentNotNullOrEmpty(patient.PatientID, "PatientID");
         Guard.ArgumentNotNullOrEmpty(patient.IssuerOfPatientID, "IssuerOfPatientID");
         Guard.ArgumentNotNullOrEmpty(patient.PatientNameFamilyName + patient.PatientNameGivenName +
                                      patient.PatientNameMiddleName, "Patient Name");

         NullTheEmpty(patient);

         using (MWLDataset ds = new MWLDataset())
         {
            ds.AddPatient(patient);
            DB.DataAccess.UpdateMWL(ds);
         }
      }

      public void DeletePatient(string patientId, string issuerOfPatientID)
      {
         Patient patient = new Patient() { PatientID = patientId, IssuerOfPatientID = issuerOfPatientID };

         Guard.ArgumentNotNullOrEmpty(patient.PatientID, "PatientID");
         Guard.ArgumentNotNullOrEmpty(patient.IssuerOfPatientID, "IssuerOfPatientID");
         using (MWLDataset ds = DB.DataAccess.Find(patient))
         {
            if (ds != null && ds.Patient.Rows.Count > 0)
            {
               ds.Patient.Rows[0].Delete();
               DB.DataAccess.UpdateMWL(ds);
            }
            else
            {
               throw new Exception("Patient id not found");
            }
         }
      }

      public void DeletePatientAndRelatedRecords(string patientId, string issuerOfPatientID)
      {
         Patient patient = new Patient() { PatientID = patientId, IssuerOfPatientID = issuerOfPatientID };
         Guard.ArgumentNotNullOrEmpty(patient.PatientID, "PatientID");
         Guard.ArgumentNotNullOrEmpty(patient.IssuerOfPatientID, "IssuerOfPatientID");

         using (MWLDataset ds = DB.DataAccess.Find(patient))
         {
            if (ds != null && ds.Patient.Rows.Count > 0)
            {
               ds.Patient.Rows[0].Delete();

               if (ds.Visit.Rows.Count > 0)
               {
                  ds.Visit.Rows[0].Delete();
               }

               DB.DataAccess.UpdateMWL(ds);
            }
            else
            {
               throw new Exception("Patient id not found");
            }
         }
      }           

      public void UpdatePatient(string origPatientId, string origIssuerOfPatientId, WCFPatient patient)
      {
         WCFPatient srchPatient = new WCFPatient() { PatientID = origPatientId, IssuerOfPatientID = origIssuerOfPatientId };

         Guard.ArgumentNotNullOrEmpty(patient.PatientID, "PatientID");
         Guard.ArgumentNotNullOrEmpty(patient.IssuerOfPatientID, "IssuerOfPatientID");
         Guard.ArgumentNotNullOrEmpty(patient.PatientNameFamilyName + patient.PatientNameGivenName +
                                      patient.PatientNameMiddleName, "Patient Name");

         using (MWLDataset ds = DB.DataAccess.Find(srchPatient))
         {
            if (ds != null && ds.Patient.Rows.Count > 0)
            {
               MWLDataset.PatientRow row = ds.Patient.Rows[0] as MWLDataset.PatientRow;

               row.Update(patient);
               DB.DataAccess.UpdateMWL(ds);
            }
            else
            {
               throw new Exception("Patient id not found");
            }
         }
      }

      public WCFPatient FindPatient(string patientID, string issuerOfPatientID)
      {
         WCFPatient patient = new WCFPatient() { PatientID = patientID, IssuerOfPatientID = issuerOfPatientID };
         
         Guard.ArgumentNotNullOrEmpty(patient.PatientID, "PatientID");
         Guard.ArgumentNotNullOrEmpty(patient.IssuerOfPatientID, "IssuerOfPatientID");
         using (MWLDataset ds = DB.DataAccess.Find(patient))
         {
            if (ds != null && ds.Patient.Rows.Count > 0)
            {
               return ds.ToPatient();
            }
         }

         return null;
      }

      public string[] GetPatientIDs()
      {
         return DB.DataAccess.GetPatientIDs();
      }

      public void AddImagingServiceRequest(string patientID, string issuerOfPatientID, ImagingServiceRequest request)
      {
         Patient patient = new Patient() { PatientID = patientID, IssuerOfPatientID = issuerOfPatientID };

         Guard.ArgumentNotNullOrEmpty(request.AccessionNumber, "AccessionNumber");
         Guard.ArgumentNotNullOrEmpty(patientID, "patientID");
         Guard.ArgumentNotNullOrEmpty(issuerOfPatientID, "issuerOfPatientID");

         using (MWLDataset ds = DB.DataAccess.Find(new ImagingServiceRequest() { AccessionNumber = request.AccessionNumber }))
         {
            if (ds != null && ds.ImagingServiceRequest.Rows.Count > 0)
            {
               throw new Exception("Primary key violation. Accession number already exist.");
            }
         }

         using (MWLDataset ds = DB.DataAccess.Find(patient))
         {
            if (ds != null && ds.Patient.Rows.Count > 0)
            {
               ds.AddImagingServiceRequest(patient, request);
               DB.DataAccess.UpdateMWL(ds);
            }
         }
      }

      public void AddImagingServiceRequest(string patientID, string issuerOfPatientID, ImagingServiceRequest request, MWLDataset ds)
      {
         Patient patient = new Patient() { PatientID = patientID, IssuerOfPatientID = issuerOfPatientID };

         Guard.ArgumentNotNullOrEmpty(request.AccessionNumber, "AccessionNumber");
         Guard.ArgumentNotNullOrEmpty(patientID, "patientID");
         Guard.ArgumentNotNullOrEmpty(issuerOfPatientID, "issuerOfPatientID");

         ds.AddImagingServiceRequest(patient, request);
      }

      public void DeleteImagingServiceRequest(string accessionNumber, string patientID, string issuerOfPatientID)
      {
         ImagingServiceRequest request = new ImagingServiceRequest() { AccessionNumber = accessionNumber };
         Patient patient = new Patient() { PatientID = patientID, IssuerOfPatientID = issuerOfPatientID };

         Guard.ArgumentNotNullOrEmpty(request.AccessionNumber, "AccessionNumber");
         Guard.ArgumentNotNullOrEmpty(patientID, "patientID");
         Guard.ArgumentNotNullOrEmpty(issuerOfPatientID, "issuerOfPatientID");
         using (MWLDataset ds = DB.DataAccess.Find(patient, request))
         {
            if (ds != null && ds.ImagingServiceRequest.Rows.Count > 0)
            {
               ds.ImagingServiceRequest.Rows[0].Delete();
               DB.DataAccess.UpdateMWL(ds);
            }
            else
            {
               throw new Exception("Imaging service request not found");
            }
         }
      }

      public void UpdateImagingServiceRequest(string accessionNumber, string patientID, string issuerOfPatientID, ImagingServiceRequest request)
      {
         ImagingServiceRequest srcRequest = new ImagingServiceRequest() { AccessionNumber = accessionNumber };
         Patient patient = new Patient() { PatientID = patientID, IssuerOfPatientID = issuerOfPatientID };

         Guard.ArgumentNotNullOrEmpty(request.AccessionNumber, "AccessionNumber");
         Guard.ArgumentNotNullOrEmpty(patientID, "patientID");
         Guard.ArgumentNotNullOrEmpty(issuerOfPatientID, "issuerOfPatientID");

         //
         // Check to see if the accesion number exists
         //
         if (accessionNumber.ToLower() != request.AccessionNumber.ToLower())
         {
            using (MWLDataset ds = DB.DataAccess.Find(new ImagingServiceRequest() { AccessionNumber = request.AccessionNumber }))
            {
               if (ds != null && ds.ImagingServiceRequest.Rows.Count > 0)
               {
                  throw new Exception("Primary key violation. Accession number already exist.");
               }
            }
         }

         using (MWLDataset ds = DB.DataAccess.Find(patient, srcRequest))
         {
            if (ds != null && ds.ImagingServiceRequest.Rows.Count > 0)
            {
               MWLDataset.ImagingServiceRequestRow row = ds.ImagingServiceRequest.Rows[0] as MWLDataset.ImagingServiceRequestRow;

               row.Update(request);
               DB.DataAccess.UpdateMWL(ds);
            }
            else
            {
               throw new Exception("Imaging service request not found");
            }
         }
      }

      public ImagingServiceRequest FindImagingServiceRequest(string accessionNumber, string patientID, string issuerOfPatientID)
      {
         ImagingServiceRequest request = new ImagingServiceRequest() { AccessionNumber = accessionNumber };
         Patient patient = new Patient() { PatientID = patientID, IssuerOfPatientID = issuerOfPatientID };
         
         Guard.ArgumentNotNullOrEmpty(request.AccessionNumber, "AccessionNumber");
         Guard.ArgumentNotNullOrEmpty(patientID, "patientID");
         Guard.ArgumentNotNullOrEmpty(issuerOfPatientID, "issuerOfPatientID");
         using (MWLDataset ds = DB.DataAccess.Find(patient, request))
         {
            if (ds != null && ds.ImagingServiceRequest.Rows.Count > 0)
            {
               return ds.ToImagingServiceRequest();
            }
         }
         
         return null;
      }

      public string[] GetAccessionNumbers(string patientID, string issuerOfPatientID)
      {
         return DB.DataAccess.GetAccessionNumbers(patientID, issuerOfPatientID);
      }

      public void AddRequestedProcedure(string accessionNumber, WCFRequestedProcedure procedure)
      {
         ImagingServiceRequest imgRequest = new ImagingServiceRequest() { AccessionNumber = accessionNumber };

         Guard.ArgumentNotNullOrEmpty(accessionNumber, "accessionNumber");
         Guard.ArgumentNotNullOrEmpty(procedure.RequestedProcedureID, "RequestedProcedureID");
         Guard.ArgumentNotNullOrEmpty(procedure.StudyInstanceUID, "StudyInstanceUID");
         Guard.ArgumentNotNullOrEmpty(procedure.RequestedProcedureDescription, "RequestedProcedureDescription");

         if (procedure.RequestedProcedureCodeSequence != null)
         {
            Guard.ArgumentNotNullOrEmpty(procedure.RequestedProcedureCodeSequence.CodeValue, "RequestedProcedureCodeSequence.CodeValue");
            Guard.ArgumentNotNullOrEmpty(procedure.RequestedProcedureCodeSequence.CodingSchemeDesignator, "RequestedProcedureCodeSequence.CodingSchemeDesignator");
         }

         if (procedure.ReferencedStudySequence != null)
         {
            foreach (ReferencedStudySequence rs in procedure.ReferencedStudySequence)
            {
               Guard.ArgumentNotNullOrEmpty(rs.ReferencedSOPClassUID, "ReferencedStudySequence.ReferencedSOPClassUID");
               Guard.ArgumentNotNullOrEmpty(rs.ReferencedSOPInstanceUID, "ReferencedStudySequence.ReferencedSOPInstanceUID");
            }
         }

         using (MWLDataset ds = DB.DataAccess.Find(imgRequest))
         {
            ds.AddRequestedProcedure(imgRequest, procedure);
            DB.DataAccess.UpdateMWL(ds);
         }
      }

      public void AddRequestedProcedure(string accessionNumber, WCFRequestedProcedure procedure, MWLDataset ds)
      {
         ImagingServiceRequest imgRequest = new ImagingServiceRequest() { AccessionNumber = accessionNumber };

         Guard.ArgumentNotNullOrEmpty(accessionNumber, "accessionNumber");
         Guard.ArgumentNotNullOrEmpty(procedure.RequestedProcedureID, "RequestedProcedureID");
         Guard.ArgumentNotNullOrEmpty(procedure.StudyInstanceUID, "StudyInstanceUID");
         Guard.ArgumentNotNullOrEmpty(procedure.RequestedProcedureDescription, "RequestedProcedureDescription");

         if (procedure.RequestedProcedureCodeSequence != null)
         {
            Guard.ArgumentNotNullOrEmpty(procedure.RequestedProcedureCodeSequence.CodeValue, "RequestedProcedureCodeSequence.CodeValue");
            Guard.ArgumentNotNullOrEmpty(procedure.RequestedProcedureCodeSequence.CodingSchemeDesignator, "RequestedProcedureCodeSequence.CodingSchemeDesignator");
         }

         if (procedure.ReferencedStudySequence != null)
         {
            foreach (ReferencedStudySequence rs in procedure.ReferencedStudySequence)
            {
               Guard.ArgumentNotNullOrEmpty(rs.ReferencedSOPClassUID, "ReferencedStudySequence.ReferencedSOPClassUID");
               Guard.ArgumentNotNullOrEmpty(rs.ReferencedSOPInstanceUID, "ReferencedStudySequence.ReferencedSOPInstanceUID");
            }
         }

         ds.AddRequestedProcedure(imgRequest, procedure);
      }

      public void DeleteRequestedProcedure(string accessionNumber, string requestedProcedureID)
      {
         ImagingServiceRequest imgRequest = new ImagingServiceRequest() { AccessionNumber = accessionNumber };
         WCFRequestedProcedure reqProcedure = new WCFRequestedProcedure() { RequestedProcedureID = requestedProcedureID };

         Guard.ArgumentNotNullOrEmpty(accessionNumber, "accessionNumber");
         Guard.ArgumentNotNullOrEmpty(requestedProcedureID, "RequestedProcedureID");
         using (MWLDataset ds = DB.DataAccess.Find(imgRequest, reqProcedure))
         {
            if (ds != null && ds.RequestedProcedure.Rows.Count > 0)
            {
               ds.RequestedProcedure.Rows[0].Delete();
               DB.DataAccess.UpdateMWL(ds);
            }
            else
            {
               throw new Exception("Requested procedure not found");
            }
         }
      }

      public void UpdateRequestedProcedure(string accessionNumber, string requestedProcedureID, WCFRequestedProcedure procedure)
      {
         ImagingServiceRequest imgRequest = new ImagingServiceRequest() { AccessionNumber = accessionNumber };
         WCFRequestedProcedure reqProcedure = new WCFRequestedProcedure() { RequestedProcedureID = requestedProcedureID };

         Guard.ArgumentNotNullOrEmpty(accessionNumber, "accessionNumber");
         Guard.ArgumentNotNullOrEmpty(requestedProcedureID, "RequestedProcedureID");
         Guard.ArgumentNotNullOrEmpty(procedure.RequestedProcedureID, "RequestedProcedureID");
         //Guard.ArgumentNotNullOrEmpty(procedure.StudyInstanceUID, "StudyInstanceUID");
         //Guard.ArgumentNotNullOrEmpty(procedure.RequestedProcedureDescription, "RequestedProcedureDescription");
         using (MWLDataset ds = DB.DataAccess.Find(imgRequest, reqProcedure))
         {
            if (ds != null && ds.RequestedProcedure.Rows.Count > 0)
            {
               MWLDataset.RequestedProcedureRow row = ds.RequestedProcedure.Rows[0] as MWLDataset.RequestedProcedureRow;

               row.Update(procedure);
               DB.DataAccess.UpdateMWL(ds);
            }
            else
            {
               throw new Exception("Requested procedure not found");
            }
         }
      }

      public WCFRequestedProcedure FindRequestedProcedure(string accessionNumber, string requestedProcedureID)
      {
         ImagingServiceRequest imgRequest = new ImagingServiceRequest() { AccessionNumber = accessionNumber };
         WCFRequestedProcedure reqProcedure = new WCFRequestedProcedure() { RequestedProcedureID = requestedProcedureID };

         using (MWLDataset ds = DB.DataAccess.Find(imgRequest, reqProcedure))
         {
            if (ds != null && ds.RequestedProcedure.Rows.Count > 0)
            {
               return ds.ToRequestedProcedure();
            }
         }
         return null;
      }

      public string[] GetRequestedProcedureIDs(string accessionNumber)
      {
         return DB.DataAccess.GetRequestedProcedureIDs(accessionNumber);
      }
      public void AddScheduledProcedureStep(string accessionNumber, string requestedProcedureID, WCFScheduledProcedureStep procedureStep)
      {
         ImagingServiceRequest imgRequest = new ImagingServiceRequest() { AccessionNumber = accessionNumber };
         WCFRequestedProcedure reqProcedure = new WCFRequestedProcedure() { RequestedProcedureID = requestedProcedureID };

         Guard.ArgumentNotNullOrEmpty(requestedProcedureID, "requestedProcedureID");
         Guard.ArgumentNotNullOrEmpty(accessionNumber, "accessionNumber");
         Guard.ArgumentNotNullOrEmpty(requestedProcedureID, "requestedProcedureID");
         Guard.ArgumentNotNull(procedureStep.ScheduledProcedureStepStartDate_Time, "ScheduledProcedureStepStartDate_Time");
         Guard.ArgumentNotNullOrEmpty(procedureStep.Modality, "Modality");
         Guard.ArgumentNotNullOrEmpty(procedureStep.ScheduledProcedureStepDescription, "ScheduledProcedureStepDescription");

         if (procedureStep.ScheduledProtocolCodeSequence != null)
         {
            foreach (ScheduledProtocolCodeSequence cs in procedureStep.ScheduledProtocolCodeSequence)
            {
               Guard.ArgumentNotNullOrEmpty(cs.CodeValue, "ScheduledProtocolCodeSequence.CodeValue");
               Guard.ArgumentNotNullOrEmpty(cs.CodingSchemeDesignator, "ScheduledProtocolCodeSequence.CodingSchemeDesignator");
            }
         }

         using (MWLDataset ds = DB.DataAccess.Find(imgRequest, reqProcedure))
         {
            if (ds != null && ds.RequestedProcedure.Rows.Count > 0)
            {
               ds.AddScheduledProcedureStep(imgRequest, reqProcedure, procedureStep);
               DB.DataAccess.UpdateMWL(ds);
            }
         }
      }
      public void AddScheduledProcedureStep(string accessionNumber, string requestedProcedureID, WCFScheduledProcedureStep procedureStep, MWLDataset ds)
      {
         ImagingServiceRequest imgRequest = new ImagingServiceRequest() { AccessionNumber = accessionNumber };
         WCFRequestedProcedure reqProcedure = new WCFRequestedProcedure() { RequestedProcedureID = requestedProcedureID };

         Guard.ArgumentNotNullOrEmpty(requestedProcedureID, "requestedProcedureID");
         Guard.ArgumentNotNullOrEmpty(accessionNumber, "accessionNumber");
         Guard.ArgumentNotNullOrEmpty(requestedProcedureID, "requestedProcedureID");
         Guard.ArgumentNotNull(procedureStep.ScheduledProcedureStepStartDate_Time, "ScheduledProcedureStepStartDate_Time");
         Guard.ArgumentNotNullOrEmpty(procedureStep.Modality, "Modality");
         Guard.ArgumentNotNullOrEmpty(procedureStep.ScheduledProcedureStepDescription, "ScheduledProcedureStepDescription");

         if (procedureStep.ScheduledProtocolCodeSequence != null)
         {
            foreach (ScheduledProtocolCodeSequence cs in procedureStep.ScheduledProtocolCodeSequence)
            {
               Guard.ArgumentNotNullOrEmpty(cs.CodeValue, "ScheduledProtocolCodeSequence.CodeValue");
               Guard.ArgumentNotNullOrEmpty(cs.CodingSchemeDesignator, "ScheduledProtocolCodeSequence.CodingSchemeDesignator");
            }
         }

         ds.AddScheduledProcedureStep(imgRequest, reqProcedure, procedureStep);
      }

      public void UpdateScheduledProcedureStep(string scheduledProcedureStepID, WCFScheduledProcedureStep procedureStep)
      {
         WCFScheduledProcedureStep sps = new WCFScheduledProcedureStep() { ScheduledProcedureStepID = scheduledProcedureStepID };

         Guard.ArgumentNotNullOrEmpty(scheduledProcedureStepID, "scheduledProcedureStepID");
         Guard.ArgumentNotNull(procedureStep.ScheduledProcedureStepStartDate_Time, "ScheduledProcedureStepStartDate_Time");
         Guard.ArgumentNotNullOrEmpty(procedureStep.Modality, "Modality");
         Guard.ArgumentNotNullOrEmpty(procedureStep.ScheduledProcedureStepDescription, "ScheduledProcedureStepDescription");

         if (procedureStep.ScheduledProtocolCodeSequence != null)
         {
            foreach (ScheduledProtocolCodeSequence cs in procedureStep.ScheduledProtocolCodeSequence)
            {
               Guard.ArgumentNotNullOrEmpty(cs.CodeValue, "ScheduledProtocolCodeSequence.CodeValue");
               Guard.ArgumentNotNullOrEmpty(cs.CodingSchemeDesignator, "ScheduledProtocolCodeSequence.CodingSchemeDesignator");
            }
         }

         using (MWLDataset ds = DB.DataAccess.Find(sps))
         {
            if (ds != null && ds.ScheduledProcedureStep.Rows.Count > 0)
            {
               MWLDataset.ScheduledProcedureStepRow row = ds.ScheduledProcedureStep.Rows[0] as MWLDataset.ScheduledProcedureStepRow;

               row.Update(procedureStep);
               DB.DataAccess.UpdateMWL(ds);
            }
            else
            {
               throw new Exception("Scheduled procedure step not found");
            }
         }
      }

      public void DeleteScheduledProcedureStep(string scheduledProcedureStepID)
      {
         WCFScheduledProcedureStep sps = new WCFScheduledProcedureStep() { ScheduledProcedureStepID = scheduledProcedureStepID };

         Guard.ArgumentNotNullOrEmpty(scheduledProcedureStepID, "scheduledProcedureStepID");
         using (MWLDataset ds = DB.DataAccess.Find(sps))
         {
            if (ds != null && ds.ScheduledProcedureStep.Rows.Count > 0)
            {
               ds.ScheduledProcedureStep.Rows[0].Delete();
               DB.DataAccess.UpdateMWL(ds);
            }
            else
            {
               throw new Exception("Scheduled procedure step not found");
            }
         }
      }

      public WCFScheduledProcedureStep FindScheduledProcedureStep(string scheduledProcedureStepID)
      {
         WCFScheduledProcedureStep sps = new WCFScheduledProcedureStep() { ScheduledProcedureStepID = scheduledProcedureStepID };
         
         Guard.ArgumentNotNullOrEmpty(scheduledProcedureStepID, "scheduledProcedureStepID");
         using (MWLDataset ds = DB.DataAccess.Find(sps))
         {
            if (ds != null && ds.ScheduledProcedureStep.Rows.Count > 0)
            {
               return ds.ToScheduledProcedureStep();
            }
         }
                  
         return null;
      }

      public string[] GetScheduledProcedureStepIDs(string accessionNumber, string requestedProcedureID)
      {
         return DB.DataAccess.GetScheduledProcedureStepIDs(accessionNumber, requestedProcedureID);
      }

      public void AddVisit(WCFVisit visit)
      {
         Guard.ArgumentNotNullOrEmpty(visit.AdmissionID, "AdmissionID");
         if (visit.ReferencedPatientSequence != null)
         {
            Guard.ArgumentNotNullOrEmpty(visit.ReferencedPatientSequence.ReferencedSOPClassUID, "ReferencedSOPClassUID");
            Guard.ArgumentNotNullOrEmpty(visit.ReferencedPatientSequence.ReferencedSOPInstanceUID, "ReferencedSOPInstanceUID");
         }
         
         using (MWLDataset ds = new MWLDataset())
         {
            ds.AddVisit(visit);
            DB.DataAccess.UpdateMWL(ds);
         }
      }
      public void DeleteThenAddVisit(WCFVisit visit)
      {
         Guard.ArgumentNotNullOrEmpty(visit.AdmissionID, "AdmissionID");
         if (visit.ReferencedPatientSequence != null)
         {
            Guard.ArgumentNotNullOrEmpty(visit.ReferencedPatientSequence.ReferencedSOPClassUID, "ReferencedSOPClassUID");
            Guard.ArgumentNotNullOrEmpty(visit.ReferencedPatientSequence.ReferencedSOPInstanceUID, "ReferencedSOPInstanceUID");
         }
         try
         {
            DB.DataAccess.DeleteWorklistEntity(visit);
         }
         catch { }//safe to ignore

         using (MWLDataset ds = new MWLDataset())
         {
            ds.AddVisit(visit);
            DB.DataAccess.UpdateMWL(ds);
         }
      }

      public void AddVisit(WCFVisit visit, MWLDataset ds)
      {
         Guard.ArgumentNotNullOrEmpty(visit.AdmissionID, "AdmissionID");
         if (visit.ReferencedPatientSequence != null)
         {
            Guard.ArgumentNotNullOrEmpty(visit.ReferencedPatientSequence.ReferencedSOPClassUID, "ReferencedSOPClassUID");
            Guard.ArgumentNotNullOrEmpty(visit.ReferencedPatientSequence.ReferencedSOPInstanceUID, "ReferencedSOPInstanceUID");
         }

         ds.AddVisit(visit);
      }

      public void UpdateVisit(string admissionID, WCFVisit visit)
      {
         WCFVisit visitLookup = new WCFVisit() { AdmissionID = admissionID };

         Guard.ArgumentNotNullOrEmpty(admissionID, "AdmissionID");
         Guard.ArgumentNotNullOrEmpty(visit.AdmissionID, "AdmissionID");
         if (visit.ReferencedPatientSequence != null)
         {
            Guard.ArgumentNotNullOrEmpty(visit.ReferencedPatientSequence.ReferencedSOPClassUID, "ReferencedSOPClassUID");
            Guard.ArgumentNotNullOrEmpty(visit.ReferencedPatientSequence.ReferencedSOPInstanceUID, "ReferencedSOPInstanceUID");
         }

         using (MWLDataset ds = DB.DataAccess.Find(visitLookup))
         {
            if (ds != null && ds.Visit.Rows.Count > 0)
            {
               MWLDataset.VisitRow row = ds.Visit.Rows[0] as MWLDataset.VisitRow;

               row.Update(visit);
               DB.DataAccess.UpdateMWL(ds);
            }
            else
            {
               throw new Exception("Visit not found");
            }
         }
      }

      public void DeleteVisit(string admissionID)
      {
         WCFVisit visit = new WCFVisit() { AdmissionID = admissionID };

         Guard.ArgumentNotNullOrEmpty(admissionID, "AdmissionID");
         using (MWLDataset ds = DB.DataAccess.Find(visit))
         {
            if (ds != null && ds.Visit.Rows.Count > 0)
            {
               ds.Visit.Rows[0].Delete();
               if (ds.ReferencedPatientSequence.Rows.Count > 0)
                  ds.ReferencedPatientSequence.Rows[0].Delete();
               DB.DataAccess.UpdateMWL(ds);
            }
            else
            {
               throw new Exception("Visit not found");
            }
         }
      }

      public WCFVisit FindVisit(string admissionID)
      {
         WCFVisit visit = new WCFVisit() { AdmissionID = admissionID };
         
         Guard.ArgumentNotNullOrEmpty(admissionID, "AdmissionID");
         using (MWLDataset ds = DB.DataAccess.Find(visit))
         {
            if (ds != null && ds.Visit.Rows.Count > 0)
            {
               return ds.ToVisit();
            }
         }
         
         return null;
      }

      public string[] GetAdmissionIDs()
      {
         return DB.DataAccess.GetAdmissionIDs();
      }

      public void AddMPPS(WCFPPSInformation mpps)
      {
         VerifyMpps(mpps);
         using (MPPSDataset ds = new MPPSDataset())
         {
            ds.AddMPPS(mpps);
            DB.DataAccess.UpdateMPPS(ds);
         }
      }

      public void DeleteMPPS(string mppsSOPInstanceUID)
      {
         PPSInformation mpps = new PPSInformation() { MPPSSOPInstanceUID = mppsSOPInstanceUID };

         Guard.ArgumentNotNullOrEmpty(mppsSOPInstanceUID, "mppsSOPInstanceUID");
         using (MPPSDataset ds = DB.DataAccess.FindMPPS(mpps))
         {
            if (ds.PPSInformation.Rows.Count > 0)
            {
               ds.PPSInformation.Rows[0].Delete();
               DB.DataAccess.UpdateMPPS(ds);
            }
            else
            {
               throw new Exception("Modality performed procedure step not found");
            }
         }
      }

      public void UpdateMPPS(string mppsSOPInstanceUID, WCFPPSInformation mpps)
      {
         PPSInformation srchMpps = new PPSInformation() { MPPSSOPInstanceUID = mppsSOPInstanceUID };

         Guard.ArgumentNotNullOrEmpty(mppsSOPInstanceUID, "mppsSOPInstanceUID");
         VerifyMpps(mpps);

         using (MPPSDataset ds = DB.DataAccess.FindMPPS(srchMpps))
         {
            if (ds != null && ds.PPSInformation.Rows.Count > 0)
            {
               MPPSDataset.PPSInformationRow row = ds.PPSInformation.Rows[0] as MPPSDataset.PPSInformationRow;

               row.Update(mpps);
               DB.DataAccess.UpdateMPPS(ds);
            }
            else
            {
               throw new Exception("Modality performed procedure step not found");
            }
         }
      }

      public WCFPPSInformation FindMPPS(string mppsSOPInstanceUID)
      {
         WCFPPSInformation mpps = new WCFPPSInformation() { MPPSSOPInstanceUID = mppsSOPInstanceUID };
         
         Guard.ArgumentNotNullOrEmpty(mppsSOPInstanceUID, "mppsSOPInstanceUID");
         using (MPPSDataset ds = DB.DataAccess.FindMPPS(mpps))
         {
            if (ds?.PPSInformation.Rows.Count > 0)
            {
               return ds.ToPPSInformation();
            }
         }

         return null;
      }

      public WCFPPSInformation[] QueryMPPS(MPPSQuery query)
      {
         List<WCFPPSInformation> mpps = new List<WCFPPSInformation>();
         ImagingServiceRequest sr = new ImagingServiceRequest() { AccessionNumber = query.AccessionNumber };
         WCFRequestedProcedure rp = new WCFRequestedProcedure() { RequestedProcedureID = query.RequestedProcedureId };
         WCFScheduledProcedureStep sp = new WCFScheduledProcedureStep() { ScheduledProcedureStepID = query.ScheduledProcedureId };

         using (MPPSDataset ds = DB.DataAccess.FindMPPS(query.PPSInfo, query.Patient, sr, rp, sp))
         {
            if (ds.PPSInformation.Rows.Count > 0)
            {
               ds.ToPPSInformation(mpps);
            }
         }

         return mpps.ToArray();
      }

      public void HandleUnscheduledMPPS(string mppsSOPInstanceUID, string scheduledProcedureStepID)
      {
         Guard.ArgumentNotNullOrEmpty(mppsSOPInstanceUID, "mppsSOPInstanceUID");
         Guard.ArgumentNotNullOrEmpty(scheduledProcedureStepID, "scheduledProcedureStepID");
         DB.DataAccess.ResolveUnscheduledPerformedProcedureStep(mppsSOPInstanceUID, scheduledProcedureStepID);
      }

      public string[] GetUnscheduledPerformedProcedureStepUIDs()
      {
         return DB.DataAccess.GetUnscheduledPerformedProcedureStepUIDs();
      }

      public bool PerformedProcedureStepExists(string affectedSOPInstanceUID)
      {
         Guard.ArgumentNotNullOrEmpty(affectedSOPInstanceUID, "affectedSOPInstanceUID");
         return DB.DataAccess.IsPerformedProcedureStepExist(affectedSOPInstanceUID);
      }

      #endregion

      private void VerifyMpps(WCFPPSInformation mpps)
      {
         Guard.ArgumentNotNullOrEmpty(mpps.MPPSSOPInstanceUID, "MPPSSOPInstanceUID");
         Guard.ArgumentNotNullOrEmpty(mpps.PerformedProcedureStepID, "PerformedProcedureStepID");
         Guard.ArgumentNotNullOrEmpty(mpps.PerformedStationAETitle, "PerformedStationAETitle");
         Guard.ArgumentNotNullOrEmpty(mpps.PerformedProcedureStepStartDate, "PerformedProcedureStepStartDate");
         Guard.ArgumentNotNullOrEmpty(mpps.PerformedProcedureStepStatus, "PerformedProcedureStepStatus");
         Guard.ArgumentNotNullOrEmpty(mpps.Modality, "Modality");
         Guard.ArgumentNotNullOrEmpty(mpps.StudyInstanceUID, "StudyInstanceUID");

         if (mpps.PPSDiscontinuationReasonCodeSequence != null)
         {
            foreach (PPSDiscontinuationReasonCodeSequence cs in mpps.PPSDiscontinuationReasonCodeSequence)
            {
               Guard.ArgumentNotNullOrEmpty(cs.CodeValue, "PPSDiscontinuationReasonCodeSequence.CodeValue");
               Guard.ArgumentNotNullOrEmpty(cs.CodingSchemeDesignator, "PPSDiscontinuationReasonCodeSequence.CodingSchemeDesignator");
            }
         }

         if (mpps.ProcedureCodeSequence != null)
         {
            foreach (ProcedureCodeSequence cs in mpps.ProcedureCodeSequence)
            {
               Guard.ArgumentNotNullOrEmpty(cs.CodeValue, "ProcedureCodeSequence.CodeValue");
               Guard.ArgumentNotNullOrEmpty(cs.CodingSchemeDesignator, "ProcedureCodeSequence.CodingSchemeDesignator");
            }
         }

         if (mpps.PerformedProtocolCodeSequence != null)
         {
            foreach (PerformedProtocolCodeSequence cs in mpps.PerformedProtocolCodeSequence)
            {
               Guard.ArgumentNotNullOrEmpty(cs.CodeValue, "PerformedProtocolCodeSequence.CodeValue");
               Guard.ArgumentNotNullOrEmpty(cs.CodingSchemeDesignator, "PerformedProtocolCodeSequence.CodingSchemeDesignator");
            }
         }

         if (mpps.PPSRelationShip != null)
         {
            foreach (PPSRelationship cs in mpps.PPSRelationShip)
            {
               Guard.ArgumentNotNullOrEmpty(cs.ScheduledProcedureStepID, "PPSRelationShip.ScheduledProcedureStepID");
            }
         }

         if (mpps.PerformedSeriesSequence != null)
         {
            foreach (PerformedSeriesSequence cs in mpps.PerformedSeriesSequence)
            {
               Guard.ArgumentNotNullOrEmpty(cs.ProtocolName, "PerformedSeriesSequence.ProtocolName");
               Guard.ArgumentNotNullOrEmpty(cs.SeriesInstanceUID, "PerformedSeriesSequence.SeriesInstanceUID");
            }
         }

         if (mpps.ReferencedImageSequence != null)
         {
            foreach (ReferencedImageSequence cs in mpps.ReferencedImageSequence)
            {
               Guard.ArgumentNotNullOrEmpty(cs.ReferencedSOPClassUID, "ReferencedImageSequence.ReferencedSOPClassUID");
               Guard.ArgumentNotNullOrEmpty(cs.ReferencedSOPInstanceUID, "ReferencedImageSequence.ReferencedSOPInstanceUID");
            }
         }

         if (mpps.ReferencedNonImageCompositeSequence != null)
         {
            foreach (ReferencedNonImageCompositeSequence cs in mpps.ReferencedNonImageCompositeSequence)
            {
               Guard.ArgumentNotNullOrEmpty(cs.ReferencedSOPClassUID, "ReferencedNonImageCompositeSequence.ReferencedSOPClassUID");
               Guard.ArgumentNotNullOrEmpty(cs.ReferencedSOPInstanceUID, "ReferencedNonImageCompositeSequence.ReferencedSOPInstanceUID");
            }
         }
      }
   }
}

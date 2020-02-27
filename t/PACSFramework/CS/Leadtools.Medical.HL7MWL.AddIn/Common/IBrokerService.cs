// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using Leadtools.Medical.Worklist.DataAccessLayer.MatchingParameters;

namespace Leadtools.Medical.HL7MWL.AddIn
{
   public interface IBrokerService
   {
      #region Patient Services
      void AddPatient(WCFPatient patient);
      void DeletePatient(string patientId, string issuerOfPatientID);
      void UpdatePatient(string origPatientId, string origIssuerOfPatientId, WCFPatient patient);
      WCFPatient FindPatient(string patientID, string issuerOfPatientID);
      string[] GetPatientIDs();
      #endregion

      #region ImagingServiceRequest Services
      void AddImagingServiceRequest(string patientID, string issuerOfPatientID, ImagingServiceRequest request);
      void DeleteImagingServiceRequest(string accessionNumber, string patientID, string issuerOfPatientID);
      void UpdateImagingServiceRequest(string accessionNumber, string patientID, string issuerOfPatientID, ImagingServiceRequest entity);
      ImagingServiceRequest FindImagingServiceRequest(string accessionNumber, string patientID, string issuerOfPatientID);
      string[] GetAccessionNumbers(string patientID, string issuerOfPatientID);
      #endregion

      #region RequestedProcedure Services
      void AddRequestedProcedure(string accessionNumber, WCFRequestedProcedure procedure);
      void DeleteRequestedProcedure(string accessionNumber, string requestedProcedureID);
      void UpdateRequestedProcedure(string accessionNumber, string requestedProcedureID, WCFRequestedProcedure procedure);
      WCFRequestedProcedure FindRequestedProcedure(string accessionNumber, string requestedProcedureID);
      string[] GetRequestedProcedureIDs(string accessionNumber);
      #endregion

      #region ScheduledProcedureStep Services
      void AddScheduledProcedureStep(string accessionNumber, string requestedProcedureID, WCFScheduledProcedureStep procedureStep);
      void UpdateScheduledProcedureStep(string scheduledProcedureStepID, WCFScheduledProcedureStep procedureStep);
      void DeleteScheduledProcedureStep(string scheduledProcedureStepID);
      WCFScheduledProcedureStep FindScheduledProcedureStep(string scheduledProcedureStepID);
      string[] GetScheduledProcedureStepIDs(string accessionNumber, string requestedProcedureID);
      #endregion

      #region Visit Services
      void AddVisit(WCFVisit visit);
      void UpdateVisit(string admissionID, WCFVisit visit);
      void DeleteVisit(string admissionID);
      WCFVisit FindVisit(string admissionID);
      string[] GetAdmissionIDs();
      #endregion

      #region Modality Performed Procedure Step Services
      void AddMPPS(WCFPPSInformation mpps);
      void DeleteMPPS(string mppsSOPInstanceUID);
      void UpdateMPPS(string mppsSOPInstanceUID, WCFPPSInformation mpps);
      WCFPPSInformation FindMPPS(string mppsSOPInstanceUID);
      WCFPPSInformation[] QueryMPPS(MPPSQuery query);
      #endregion

      #region Miscelleaneous
      void HandleUnscheduledMPPS(string mppsSOPInstanceUID, string scheduledProcedureStepID);
      string[] GetUnscheduledPerformedProcedureStepUIDs();
      bool PerformedProcedureStepExists(string affectedSOPInstanceUID);
      #endregion
   }
}

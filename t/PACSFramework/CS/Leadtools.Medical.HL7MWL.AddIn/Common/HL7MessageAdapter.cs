// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using Leadtools.Medical.HL7.V2x.Models;
using Leadtools.Medical.Worklist.DataAccessLayer.MatchingParameters;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

/* ADT messages usage (can be supported on demand):

A01	Admit/visit notification
A02	Transfer a patient
A03	Discharge/end visit
A04	Register a patient
A05	Pre-admit a patient
A06	Change an outpatient to an inpatient
A07	Change an inpatient to an outpatient
A08	Update patient information
A09	Patient departing - tracking
A10	Patient arriving - tracking
A11	Cancel admit/visit notification
A12	Cancel transfer
A13	Cancel discharge/end visit
A14	Pending admit
A15	Pending transfer
A16	Pending discharge
A17	Swap patients
A18	Merge patient information
A19	QRY/ADR - Patient query
A20	Bed status update
A21	Patient goes on a "leave of absence"
A22	Patient returns from a "leave of absence"
A23	Delete a patient record
A24	Link patient information
A25	Cancel pending discharge
A26	Cancel pending transfer
A27	Cancel pending admit
A28	Add person information
A29	Delete person information
A30	Merge person information
A31	Update person information
A32	Cancel patient arriving - tracking
A33	Cancel patient departing - tracking
A34	Merge patient information - patient I
A35	Merge patient information - account only
A36	Merge patient information - patient ID and account number
A37	Unlink patient information
A38	Cancel pre-admit
A39	Merge person - patient ID
A40	Merge patient - patient identifier list
A41	Merge account - patient account num
A42	Merge visit - visit number
A43	Move patient information - patient identifier list
A44	Move account information - patient account number
A45	Move visit information - visit number
A46	Change patient ID
A47	Change patient identifier list
A48	Change alternate patient ID
A49	Change patient account number
A50	Change visit number
A51	Change alternate visit ID
 */

namespace Leadtools.Medical.HL7MWL.AddIn
{
   public static class HL7MessageAdapterFactory
   {
      public static IHL7MessageAdapter Create(string name, List<Segment> segments)
      {
         //other messages should be fine, but plugin was only tested with the following
         if(name== "ORM_O01" || name == "OMI_O23" || name == "ADT_A01" || name == "ADT_A04" || name == "ADT_A03")
         {
            return new GenericHL7MessageAdapter(segments, name);
         }
         else
         {
            throw new Exception("HL7 message is not supported.");
         }
      }
   }
   
   public interface IHL7MessageAdapter
   {
      WCFPatient getPatient();
      ImagingServiceRequest getImageServiceRequest();
      WCFRequestedProcedure getProcedure();
      WCFScheduledProcedureStep getProcedureStep();
      WCFPPSInformation getPPS();
      WCFVisit getVisit();
      string getOrderControl();
   }
      

   /// <summary>
   /// 
   /// </summary>
   internal class GenericHL7MessageAdapter : IHL7MessageAdapter
   {
      private HL7SegmentsAdapter _adapter = null;

      private WCFPatient _patient = null;
      private ImagingServiceRequest _imageServiceRequest=null;
      private WCFRequestedProcedure _procedure = null;
      private WCFScheduledProcedureStep _procedureStep=null;
      private WCFPPSInformation _pps=null;
      private WCFVisit _visit = null;
      private string _name = null;

      public GenericHL7MessageAdapter(List<Segment> segments, string name)
      {
         _adapter = new HL7SegmentsAdapter(segments);
         _name = name;
      }
      
      public void Validate()
      {
      }

      public string getOrderControl()
      {
         var order = _adapter.ORC?.Order_Control?.Read();

         //special handling the ADT messages
         if(string.IsNullOrEmpty(order) && (_name == "ADT_A01" || _name == "ADT_A04"))
         {
            order = "NW";
         }
         else if (string.IsNullOrEmpty(order) && (_name == "ADT_A03"))
         {
            order = "CA";
         }

         return order;
      }
      string getImagingServiceRequestAccessionNumber()
      {
         if (!string.IsNullOrEmpty(_adapter.IPC?.Accession_Identifier.Read()))
            return _adapter.IPC?.Accession_Identifier.Read();
         if (!string.IsNullOrEmpty(_adapter.ORC?.Filler_Order_Number.Read()))
            return _adapter.ORC?.Filler_Order_Number.Read();
         if (!string.IsNullOrEmpty(_adapter.OBR?.Filler_Order_Number.Read()))
            return _adapter.OBR?.Filler_Order_Number.Read();

         if (!string.IsNullOrEmpty(_adapter.ORC?.Placer_Order_Number.Read()))
            return _adapter.ORC?.Placer_Order_Number.Read();
         if (!string.IsNullOrEmpty(_adapter.OBR?.Placer_Order_Number.Read()))
            return _adapter.OBR?.Placer_Order_Number.Read();

         if (!string.IsNullOrEmpty(_adapter.OBR?.Placer_Field_1.Read()))
            return _adapter.OBR?.Placer_Field_1.Read();

         return string.Empty;
      }
      public WCFPatient getPatient()
      {
         if (null == _patient)
         {
            _patient = new WCFPatient();

            _patient.PatientID = _adapter.PID?.Patient_Identifier_List?[0]?.IDNumber.Read();
            if(string.IsNullOrEmpty(_patient.PatientID))
            {
               _patient.PatientID = _adapter.PID?.Patient_ID?.IDNumber.Read();
            }
            if (string.IsNullOrEmpty(_patient.PatientID))
            {
               _patient.PatientID = _adapter.PID?.Set_ID_PID.Read();
            }
            _patient.IssuerOfPatientID = _adapter.PID?.Patient_Identifier_List?[0]?.AssigningAuthority.NamespaceID.Read();
            _patient.PatientNameFamilyName = _adapter.PID?.Patient_Name?[0]?.FamilyName.Surname.Read();
            _patient.PatientNameGivenName = _adapter.PID?.Patient_Name?[0]?.GivenName.Read();
            _patient.PatientNameMiddleName = _adapter.PID?.Patient_Name?[0]?.SecondAndFurtherGivenNamesOrInitialsThereof.Read();
            _patient.PatientNamePrefix = _adapter.PID?.Patient_Name?[0]?.PrefixEgDR.Read();
            _patient.PatientNameSuffix = _adapter.PID?.Patient_Name?[0]?.SuffixEgJRorIII.Read();
            _patient.PatientBirthDate = LTConvert.ToDicomDateRange(_adapter.PID?.Date_Time_of_Birth.Month, _adapter.PID?.Date_Time_of_Birth.Day, _adapter.PID?.Date_Time_of_Birth.Year);
            _patient.PatientSex = _adapter.PID?.Administrative_Sex.Read();
            if (!DicomValidation.IsValidPatientSex(_patient.PatientSex)) _patient.PatientSex = null;
            _patient.EthnicGroup = _adapter.PID?.Race.Read();
            //_adapter.PID?.Patient_Address;
            //_adapter.PID?.Patient_Account_Number;         
            _patient.PatientState = _adapter.OBR?.Danger_Code.Read();            
            _patient.MedicalAlerts = _adapter.OBR?.Relevant_Clinical_Information.ReadAsList();//may add support for plural (all OBR segements combined)
            _patient.ConfidentialityConstraintonPatientDataDescription = _adapter.PV1?.VIP_Indicator.Read();
            _patient.PregnancyStatus = _adapter.PV1?.Ambulatory_Status.Read();
            _patient.PatientWeight = _adapter.OBX?.Observation_Value.Read();
            _patient.ContrastAllergies = _adapter.AL1?.Allergen_Type_Code.ReadAsList();//may add support for plural (all AL1 segements combined)
            _patient.PatientComments = _adapter.Zxx?.Field_2.Read();
            _patient.AdditionalPatientHistory = _adapter.Zxx?.Field_3.Read();
            _patient.SpecialNeeds = _adapter.Zxx?.Field_4.Read();
            _patient.LastMenstrualDate = LTConvert.HL7DateToDicomDateRange(_adapter.Zxx?.Field_5.Read());

            DefaultValuesProvider.Visit(_patient);
         }
         return _patient;
      }
      public ImagingServiceRequest getImageServiceRequest()
      {
         if(null== _imageServiceRequest)
         {
            _imageServiceRequest = new ImagingServiceRequest();

            _imageServiceRequest.AccessionNumber = getImagingServiceRequestAccessionNumber();
            _imageServiceRequest.ImagingServiceRequestComments = _adapter.Zxx?.Field_6.Read();
            _imageServiceRequest.RequestingPhysicianFamilyName = _adapter.PV1?.Admitting_Doctor?[0]?.FamilyName.Surname.Read();
            _imageServiceRequest.RequestingPhysicianGivenName = _adapter.PV1?.Admitting_Doctor?[0]?.GivenName.Read();
            _imageServiceRequest.RequestingPhysicianMiddleName = _adapter.PV1?.Admitting_Doctor?[0]?.SecondAndFurtherGivenNamesOrInitialsThereof.Read();
            _imageServiceRequest.RequestingPhysicianPrefix = _adapter.PV1?.Admitting_Doctor?[0]?.PrefixEgDR.Read();
            _imageServiceRequest.RequestingPhysicianSuffix = _adapter.PV1?.Admitting_Doctor?[0]?.SuffixEgJRorIII.Read();
            _imageServiceRequest.ReferringPhysicianFamilyName = _adapter.PV1?.Referring_Doctor?[0]?.FamilyName.Read();
            _imageServiceRequest.ReferringPhysicianGivenName = _adapter.PV1?.Referring_Doctor?[0]?.GivenName.Read();
            _imageServiceRequest.ReferringPhysicianMiddleName = _adapter.PV1?.Referring_Doctor?[0]?.SecondAndFurtherGivenNamesOrInitialsThereof.Read();
            _imageServiceRequest.ReferringPhysicianPrefix = _adapter.PV1?.Referring_Doctor?[0]?.PrefixEgDR.Read();
            _imageServiceRequest.ReferringPhysicianSuffix = _adapter.PV1?.Referring_Doctor?[0]?.SuffixEgJRorIII.Read();
            _imageServiceRequest.RequestingService = _adapter.OBR?.Universal_Service_Identifier.Read();
            _imageServiceRequest.PlacerOrderNumber_ImagingServiceRequest = _adapter.ORC?.Placer_Order_Number.Read();
            _imageServiceRequest.FillerOrderNumber_ImagingServiceRequest = _adapter.ORC?.Filler_Order_Number.Read();

            DefaultValuesProvider.Visit(_imageServiceRequest);
         }

         return _imageServiceRequest;
      }
      public WCFRequestedProcedure getProcedure()
      {
         if(_procedure ==  null)
         {
            _procedure = new WCFRequestedProcedure();

            _procedure.RequestedProcedureID = _adapter.IPC?.Requested_Procedure_ID.Read();
            if (string.IsNullOrEmpty(_procedure.RequestedProcedureID))
            {
               _procedure.RequestedProcedureID = _adapter.OBR?.Placer_Field_2.Read();
            }
            _procedure.RequestedProcedureComments = _adapter.Zxx?.Field_7.Read();
            _procedure.StudyInstanceUID = _adapter.IPC?.Study_Instance_UID.Read();
            if (string.IsNullOrEmpty(_procedure.StudyInstanceUID))
            {
               _procedure.StudyInstanceUID = _adapter.Zxx?.Field_1.Read(0);
            }
            _procedure.RequestedProcedureDescription = _adapter.OBR?.Diagnostic_Serv_Sect_ID.Read();
            _procedure.RequestedProcedurePriority = _adapter.ORC?.Quantity_Timing.Read();
            _procedure.PatientTransportArrangements = _adapter.OBR?.Transport_Arrangement_Responsibility.Read();
            //_procedure.Visit = getVisit();

            DefaultValuesProvider.Visit(_procedure);
         }

         return _procedure;
      }
      public WCFScheduledProcedureStep getProcedureStep()
      {
         if(_procedureStep ==null)
         {
            _procedureStep = new WCFScheduledProcedureStep();

            _procedureStep.ScheduledProcedureStepID = _adapter.IPC?.Scheduled_Procedure_Step_ID.Read();
            if (string.IsNullOrEmpty(_procedureStep.ScheduledProcedureStepID))
            {
               _procedureStep.ScheduledProcedureStepID = _adapter.OBR?.Filler_Field_1.Read();
            }
            _procedureStep.ScheduledProcedureStepStartDate_Time = LTConvert.HL7DateToDateRange(_adapter.Zxx?.Field_8.Read());
            _procedureStep.Modality = _adapter.IPC?.Modality.Read();
            if (string.IsNullOrEmpty(_procedureStep.Modality))
            {
               _procedureStep.Modality = _adapter.OBR?.Diagnostic_Serv_Sect_ID.Read();
            }
            if (!DicomValidation.IsValidModality(_procedureStep.Modality)) _procedureStep.Modality = null;
            _procedureStep.ScheduledProcedureStepDescription = _adapter.Zxx?.Field_9.Read();
            _procedureStep.ScheduledStationAETitle = _adapter.IPC?.Scheduled_Station_AE_Title.ReadAsList();
            if (_procedureStep.ScheduledStationAETitle == null)
            {
               _procedureStep.ScheduledStationAETitle = _adapter.Zxx?.Field_10.ReadAsList();
            }
            _procedureStep.ScheduledProcedureStepLocation = _adapter.Zxx?.Field_11.Read();
            _procedureStep.ScheduledPerformingPhysicianNameFamilyName = _adapter.OBR?.Technician?[0]?.Name.FamilyName.Read();
            _procedureStep.ScheduledPerformingPhysicianNameGivenName = _adapter.OBR?.Technician?[0]?.Name.GivenName.Read();
            _procedureStep.ScheduledPerformingPhysicianNameMiddleName = _adapter.OBR?.Technician?[0]?.Name.SecondAndFurtherGivenNamesOrInitialsThereof.Read();
            _procedureStep.ScheduledPerformingPhysicianNamePrefix = _adapter.OBR?.Technician?[0]?.Name.PrefixEgDR.Read();
            _procedureStep.ScheduledPerformingPhysicianNameSuffix = _adapter.OBR?.Technician?[0]?.Name.SuffixEgJRorIII.Read();
            _procedureStep.Pre_Medication = _adapter.Zxx?.Field_12.Read();
            _procedureStep.RequestedContrastAgent = _adapter.Zxx?.Field_13.Read();

            DefaultValuesProvider.Visit(_procedureStep);
         }
         return _procedureStep;
      }
      public WCFPPSInformation getPPS()
      {
         if(_pps==null)
         {
            _pps = new WCFPPSInformation();
         
            _pps.PPSDiscontinuationReasonCodeSequence = new List<PPSDiscontinuationReasonCodeSequence>() { };
            _pps.ProcedureCodeSequence = new List<ProcedureCodeSequence>() { };
            _pps.PerformedProtocolCodeSequence = new List<PerformedProtocolCodeSequence>() { };
            _pps.PPSRelationShip = new List<PPSRelationship>() { };
            _pps.PerformedSeriesSequence = new List<PerformedSeriesSequence>() { };
            _pps.ReferencedImageSequence = new List<WCFReferencedImageSequence>() { };
            _pps.ReferencedNonImageCompositeSequence = new List<ReferencedNonImageCompositeSequence>() { };
            _pps.UnscheduledPatient = new PatientInfoforUnscheduledPPS();
            _pps.Patient = getPatient();
            _pps.StudyInstanceUID = _adapter.IPC?.Study_Instance_UID.Read();
            if (string.IsNullOrEmpty(_pps.StudyInstanceUID))
            {
               _pps.StudyInstanceUID = _adapter.Zxx?.Field_1.Read(0);
            }
            _pps.StudyID = _adapter.Zxx?.Field_23.Read();
            _pps.Modality = _adapter.IPC?.Modality.Read();
            if (string.IsNullOrEmpty(_pps.Modality))
            {
               _pps.Modality = _adapter.OBR?.Diagnostic_Serv_Sect_ID.Read();
            }
            if (!DicomValidation.IsValidModality(_pps.Modality)) _pps.Modality = null;
            _pps.CommentsonthePerformedProcedureStep = _adapter.Zxx?.Field_24.Read();
            _pps.PerformedProcedureTypeDescription = _adapter.Zxx?.Field_25.Read();
            _pps.PerformedProcedureStepDescription = _adapter.Zxx?.Field_26.Read();
            _pps.PerformedProcedureStepStatus = _adapter.Zxx?.Field_27.Read();
            _pps.PerformedLocation = _adapter.Zxx?.Field_28.Read();
            _pps.PerformedStationName = _adapter.Zxx?.Field_29.Read();
            _pps.PerformedStationAETitle = _adapter.Zxx?.Field_30.Read();
            _pps.PerformedProcedureStepID = _adapter.Zxx?.Field_31.Read();
            _pps.MPPSSOPInstanceUID = _adapter.Zxx?.Field_32.Read();

            DefaultValuesProvider.Visit(_pps);
         }

         return _pps;
      }
      public WCFVisit getVisit()
      {
         if(_visit == null)
         {
            _visit = new WCFVisit();

            _visit.AdmissionID = _adapter.PV1?.Visit_Number.Read();
            _visit.ReferencedPatientSequence = null;
            _visit.CurrentPatientLocation = _adapter.PV1?.Assigned_Patient_Location.Read();

            DefaultValuesProvider.Visit(_visit);
         }

         return _visit;
      }
      
   }
}

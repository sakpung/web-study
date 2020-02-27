// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using Leadtools.Medical.Worklist.DataAccessLayer.BusinessEntity;
using Leadtools.Medical.Worklist.DataAccessLayer.MatchingParameters;
using Leadtools.Medical.DataAccessLayer;
using Leadtools.Dicom;
using System.Data;
using Leadtools.Medical.Worklist.DataAccessLayer;
using Leadtools.Medical.DataAccessLayer.Catalog;
using Common = Leadtools.Dicom.Common.DataTypes;
using System.Reflection;
using Leadtools.Logging;
using Leadtools.Logging.Medical;
using Leadtools.Dicom.AddIn;

namespace Leadtools.Medical.HL7MWL.AddIn
{
   internal static class DataExtensions
   {
      public static void LogMessage(Logger logger, LogType type, string description)
      {
         try
         {
            DicomServer server = ServiceLocator.Retrieve<DicomServer>();
            string message = string.Format("[{0}] {1}", "HL7MWL", description);
            logger.Log("HL7MWL", server.AETitle, string.Empty, -1, string.Empty, string.Empty, -1, DicomCommandType.Undefined, DateTime.Now, type, MessageDirection.None, message, null, null);
         }
         catch (Exception exception)
         {
            logger.Exception("HL7MWL", exception);
         }
      }

      private static List<PropertyInfo> GetMatchingProperties(object source, object target)
      {
         if (source == null)
            throw new ArgumentNullException("source");

         if (target == null)
            throw new ArgumentNullException("target");

         var sourceType = source.GetType();
         var sourceProperties = sourceType.GetProperties();
         var targetType = target.GetType();
         var targetProperties = targetType.GetProperties();
         var properties = (from s in sourceProperties
                           from t in targetProperties
                           where s.Name == t.Name &&
                                 s.PropertyType == t.PropertyType
                           select s).ToList();

         return properties;
      }

      public static void CopyTo<T>(this object source, T dest)
      {
         if (source == null)
            throw new ArgumentNullException("source", "The object you are copying from cannot be null");

         if (dest == null)
            throw new ArgumentNullException("dest", "The object you are copying to cannot be null");

         // Don't copy if they are the same object
         if (!ReferenceEquals(source, dest))
         {
            List<PropertyInfo> matches = GetMatchingProperties(source, dest);

            foreach (PropertyInfo fromProperty in matches)
            {
               PropertyInfo toProperty = dest.GetType().GetProperty(fromProperty.Name);
               object value = null;

               if (source is DataRow)
               {
                  DataRow row = source as DataRow;

                  if (row[fromProperty.Name] != null)
                     value = row[fromProperty.Name];
               }
               else
               {
                  value = fromProperty.GetValue(source, null);
               }

               if (value == DBNull.Value)
                  value = null;
               toProperty.SetValue(dest, value, null);
            }
         }
      }

      /// <summary>
      /// Adds the patient.
      /// </summary>
      /// <param name="ds">The ds.</param>
      /// <param name="patient">The patient.</param>
      /// <returns>accession number used</returns>
      public static string AddPatientAllRecords(this MWLDataset ds, WCFPatient patient)
      {
         MWLDataset.PatientRow pr = ds.Patient.NewPatientRow();
         MWLDataset.VisitRow vr = ds.Visit.NewVisitRow();
         MWLDataset.ImagingServiceRequestRow isrr = ds.ImagingServiceRequest.NewImagingServiceRequestRow();
         MWLDataset.RequestedProcedureRow rpr = ds.RequestedProcedure.NewRequestedProcedureRow();
         MWLDataset.ScheduledProcedureStepRow spsr = ds.ScheduledProcedureStep.NewScheduledProcedureStepRow();
         MWLDataset.ScheduledStationAETitlesRow ssaetr = ds.ScheduledStationAETitles.NewScheduledStationAETitlesRow();
         Random rnd = new Random();
         string AccessionNumber = rnd.Next(100000000, 999999999).ToString() + "." + DateTime.Now.ToString("ssfff");
         string ReferDrLastName = "N/A";
         string ReferDrFirstName = "N/A";
         string modality = "IO";
         string[] Accessions = DB.DataAccess.GetAccessionNumbers(patient.PatientID, patient.IssuerOfPatientID);

         if (Accessions.Length < 1)
         {
            patient.CopyTo<MWLDataset.PatientRow>(pr);
            if (patient.LastMenstrualDate.HasValue)
               pr.LastMenstrualDate = patient.LastMenstrualDate.Value.Date1.ToDateTime();
            if (patient.PatientBirthDate.HasValue)
               pr.PatientBirthDate = patient.PatientBirthDate.Value.Date1.ToDateTime();
            if (!string.IsNullOrEmpty(patient.PregnancyStatus))
            {
               switch (patient.PregnancyStatus.ToLower())
               {
                  case "not pregnant":
                     pr.PregnancyStatus = 1;
                     break;
                  case "possibly pregnant":
                     pr.PregnancyStatus = 2;
                     break;
                  case "definitely pregnant":
                     pr.PregnancyStatus = 3;
                     break;
                  case "unknown":
                     pr.PregnancyStatus = 4;
                     break;
                  default:
                     pr.PregnancyStatus = 0;
                     break;
               }
            }
            pr.IssuerOfPatientID = patient.IssuerOfPatientID;
            ds.Patient.AddPatientRow(pr);
         }
         else
            LogMessage(Logger.Global, LogType.Information, "Patient <" + patient.PatientID + "> already exists.");

         if (patient.MedicalAlerts != null)
         {
            foreach (string ma in patient.MedicalAlerts)
            {
               MWLDataset.MedicalAlertsRow mar = ds.MedicalAlerts.NewMedicalAlertsRow();

               mar.MedicalAlert = ma;
               mar.PatientID = patient.PatientID;
               mar.IssuerOfPatientID = patient.IssuerOfPatientID;
               ds.MedicalAlerts.AddMedicalAlertsRow(mar);
            }
         }

         if (patient.ContrastAllergies != null)
         {
            foreach (string ca in patient.ContrastAllergies)
            {
               MWLDataset.ContrastAllergiesRow car = ds.ContrastAllergies.NewContrastAllergiesRow();

               car.ContrastAllergy = ca;
               car.PatientID = patient.PatientID;
               car.IssuerOfPatientID = patient.IssuerOfPatientID;
               ds.ContrastAllergies.AddContrastAllergiesRow(car);
            }
         }

         if (patient.OtherPatientIDs != null)
         {
            foreach (string id in patient.OtherPatientIDs)
            {
               MWLDataset.OtherPatientIDsRow oir = ds.OtherPatientIDs.NewOtherPatientIDsRow();

               oir.OtherPatientID = id;
               oir.PatientID = patient.PatientID;
               oir.IssuerOfPatientID = patient.IssuerOfPatientID;
               ds.OtherPatientIDs.AddOtherPatientIDsRow(oir);
            }
         }

         //Start Insert of Remaining Tables needed for MWL
         if (AccessionNumber != null)
         {
            if (Accessions.Length < 1)
            {
               //Insert Visit
               vr.AdmissionID = AccessionNumber;
               vr.CurrentPatientLocation = "MEDICAL";
               ds.Visit.AddVisitRow(vr);

               //Insert ImagingServiceRequest
               isrr.AccessionNumber = AccessionNumber;
               isrr.PatientID = patient.PatientID;
               isrr.IssuerOfPatientID = patient.IssuerOfPatientID;
               isrr.RequestingPhysicianFamilyName = ReferDrLastName;
               isrr.RequestingPhysicianGivenName = ReferDrFirstName;
               isrr.ReferringPhysicianFamilyName = ReferDrLastName;
               isrr.ReferringPhysicianGivenName = ReferDrFirstName;
               ds.ImagingServiceRequest.AddImagingServiceRequestRow(isrr);

               //Insert RequestedProcedure
               rpr.AccessionNumber = AccessionNumber;
               rpr.RequestedProcedureID = AccessionNumber;
               rpr.StudyInstanceUID = "1.2.840.114257.15.400000.2." + DateTime.Now.ToString("hhmmss") + patient.PatientID + DateTime.Now.ToString("yyyyMMdd");
               rpr.RequestedProcedureDescription = "MEDICAL";
               rpr.RequestedProcedurePriority = "MED";
               rpr.AdmissionID = AccessionNumber;
               ds.RequestedProcedure.AddRequestedProcedureRow(rpr);

               //Insert ScheduledProcedureStep
               spsr.ScheduledProcedureStepID = AccessionNumber;
               spsr.AccessionNumber = AccessionNumber;
               spsr.RequestedProcedureID = AccessionNumber;
               spsr.ScheduledProcedureStepLocation = "MEDICAL";
               spsr.ScheduledProcedureStepStartDate_Time = DateTime.Now;
               spsr.ScheduledPerformingPhysicianNameFamilyName = ReferDrLastName;
               spsr.ScheduledPerformingPhysicianNameGivenName = ReferDrFirstName;
               spsr.Modality = modality;
               spsr.ScheduledProcedureStepDescription = "MEDICAL";
               ds.ScheduledProcedureStep.AddScheduledProcedureStepRow(spsr);

               //Insert ScheduledStationAETitles
               ssaetr.ScheduledProcedureStepID = AccessionNumber;
               ssaetr.ScheduledStationAETitle = patient.ScheduledStationAE;
               ds.ScheduledStationAETitles.AddScheduledStationAETitlesRow(ssaetr);
               LogMessage(Logger.Global, LogType.Information, "Patient <" + patient.PatientID + "> was added");
            }
         }

         return AccessionNumber;
      }

      public static void AddPatient(this MWLDataset ds, WCFPatient patient)
      {
         var exists = DB.DataAccess.GetAccessionNumbers(patient.PatientID, patient.IssuerOfPatientID).Length > 0;

         if(exists)
         {
            LogMessage(Logger.Global, LogType.Information, "Patient <" + patient.PatientID + "> already exists.");
         }

         var pr = ds.Patient.NewPatientRow();

         if (!exists)
         {
            patient.CopyTo<MWLDataset.PatientRow>(pr);
            if (patient.LastMenstrualDate.HasValue)
               pr.LastMenstrualDate = patient.LastMenstrualDate.Value.Date1.ToDateTime();
            if (patient.PatientBirthDate.HasValue)
               pr.PatientBirthDate = patient.PatientBirthDate.Value.Date1.ToDateTime();
            if (!string.IsNullOrEmpty(patient.PregnancyStatus))
            {
               switch (patient.PregnancyStatus.ToLower())
               {
                  case "not pregnant":
                     pr.PregnancyStatus = 1;
                     break;
                  case "possibly pregnant":
                     pr.PregnancyStatus = 2;
                     break;
                  case "definitely pregnant":
                     pr.PregnancyStatus = 3;
                     break;
                  case "unknown":
                     pr.PregnancyStatus = 4;
                     break;
                  default:
                     pr.PregnancyStatus = 0;
                     break;
               }
            }
            pr.IssuerOfPatientID = patient.IssuerOfPatientID;
            ds.Patient.AddPatientRow(pr);
         }

         if (patient.MedicalAlerts != null)
         {
            foreach (string ma in patient.MedicalAlerts)
            {
               MWLDataset.MedicalAlertsRow mar = ds.MedicalAlerts.NewMedicalAlertsRow();

               mar.MedicalAlert = ma;
               mar.PatientID = patient.PatientID;
               mar.IssuerOfPatientID = patient.IssuerOfPatientID;
               ds.MedicalAlerts.AddMedicalAlertsRow(mar);
            }
         }

         if (patient.ContrastAllergies != null)
         {
            foreach (string ca in patient.ContrastAllergies)
            {
               MWLDataset.ContrastAllergiesRow car = ds.ContrastAllergies.NewContrastAllergiesRow();

               car.ContrastAllergy = ca;
               car.PatientID = patient.PatientID;
               car.IssuerOfPatientID = patient.IssuerOfPatientID;
               ds.ContrastAllergies.AddContrastAllergiesRow(car);
            }
         }

         if (patient.OtherPatientIDs != null)
         {
            foreach (string id in patient.OtherPatientIDs)
            {
               MWLDataset.OtherPatientIDsRow oir = ds.OtherPatientIDs.NewOtherPatientIDsRow();

               oir.OtherPatientID = id;
               oir.PatientID = patient.PatientID;
               oir.IssuerOfPatientID = patient.IssuerOfPatientID;
               ds.OtherPatientIDs.AddOtherPatientIDsRow(oir);
            }
         }

         //Start Insert of Remaining Tables needed for MWL
         LogMessage(Logger.Global, LogType.Information, "Patient <" + patient.PatientID + "> was added");
      }


      /// <summary>
      /// Adds the imaging service request.
      /// </summary>
      /// <param name="ds">The ds.</param>
      /// <param name="patient">The patient.</param>
      /// <param name="request">The request.</param>
      public static void AddImagingServiceRequest(this MWLDataset ds, Patient patient, ImagingServiceRequest request)
      {
         MWLDataset.ImagingServiceRequestRow ir = ds.ImagingServiceRequest.NewImagingServiceRequestRow();

         request.CopyTo<MWLDataset.ImagingServiceRequestRow>(ir);
         ir.PatientID = patient.PatientID;
         ir.IssuerOfPatientID = patient.IssuerOfPatientID;
         ds.ImagingServiceRequest.AddImagingServiceRequestRow(ir);
      }

      /// <summary>
      /// Toes the patient.
      /// </summary>
      /// <param name="ds">The ds.</param>
      /// <returns></returns>
      public static WCFPatient ToPatient(this MWLDataset ds)
      {
         WCFPatient patient = new WCFPatient();
         MWLDataset.PatientRow row = ds.Patient.Rows[0] as MWLDataset.PatientRow;

         row.CopyTo<WCFPatient>(patient);
         if (!row.IsPatientBirthDateNull())
            patient.PatientBirthDate = new Leadtools.Dicom.DicomDateRangeValue() { Date1 = new DicomDateValue(row.PatientBirthDate) };

         if (!row.IsLastMenstrualDateNull())
         {
            patient.LastMenstrualDate = new Leadtools.Dicom.DicomDateRangeValue() { Date1 = new DicomDateValue(row.LastMenstrualDate) };
         }

         if (!row.IsPregnancyStatusNull())
         {
            switch (row.PregnancyStatus)
            {
               case 1:
                  patient.PregnancyStatus = "not pregnant";
                  break;
               case 2:
                  patient.PregnancyStatus = "possibly pregnant";
                  break;
               case 3:
                  patient.PregnancyStatus = "definitely pregnant";
                  break;
               case 4:
                  patient.PregnancyStatus = "unknown";
                  break;
            }
         }

         patient.MedicalAlerts = new List<string>();
         foreach (MWLDataset.MedicalAlertsRow mar in ds.MedicalAlerts.Rows)
         {
            patient.MedicalAlerts.Add(mar.MedicalAlert);
         }

         patient.ContrastAllergies = new List<string>();
         foreach (MWLDataset.ContrastAllergiesRow car in ds.ContrastAllergies.Rows)
         {
            patient.ContrastAllergies.Add(car.ContrastAllergy);
         }

         patient.OtherPatientIDs = new List<string>();
         foreach (MWLDataset.OtherPatientIDsRow oir in ds.OtherPatientIDs.Rows)
         {
            patient.OtherPatientIDs.Add(oir.OtherPatientID);
         }

         return patient;
      }

      /// <summary>
      /// Updates the specified row.
      /// </summary>
      /// <param name="row">The row.</param>
      /// <param name="patient">The patient.</param>
      public static void Update(this MWLDataset.PatientRow row, WCFPatient patient)
      {
         MWLDataset ds = row.Table.DataSet as MWLDataset;

         patient.CopyTo<MWLDataset.PatientRow>(row);
         if (patient.LastMenstrualDate.HasValue)
            row.LastMenstrualDate = patient.LastMenstrualDate.Value.Date1.ToDateTime();
         if (patient.PatientBirthDate.HasValue)
            row.PatientBirthDate = patient.PatientBirthDate.Value.Date1.ToDateTime();
         if (!string.IsNullOrEmpty(patient.PregnancyStatus))
         {
            switch (patient.PregnancyStatus.ToLower())
            {
               case "not pregnant":
                  row.PregnancyStatus = 1;
                  break;
               case "possibly pregnant":
                  row.PregnancyStatus = 2;
                  break;
               case "definitely pregnant":
                  row.PregnancyStatus = 3;
                  break;
               case "unknown":
                  row.PregnancyStatus = 4;
                  break;
               default:
                  row.PregnancyStatus = 0;
                  break;
            }
         }

         foreach (MWLDataset.MedicalAlertsRow mar in ds.MedicalAlerts.Rows)
         {
            mar.Delete();
         }

         foreach (MWLDataset.ContrastAllergiesRow car in ds.ContrastAllergies.Rows)
         {
            car.Delete();
         }

         foreach (MWLDataset.OtherPatientIDsRow oir in ds.OtherPatientIDs.Rows)
         {
            oir.Delete();
         }

         if (patient.MedicalAlerts != null)
         {
            foreach (string ma in patient.MedicalAlerts)
            {
               MWLDataset.MedicalAlertsRow mar = ds.MedicalAlerts.NewMedicalAlertsRow();

               mar.MedicalAlert = ma;
               mar.PatientID = patient.PatientID;
               mar.IssuerOfPatientID = patient.IssuerOfPatientID;
               ds.MedicalAlerts.AddMedicalAlertsRow(mar);
            }
         }

         if (patient.ContrastAllergies != null)
         {
            foreach (string ca in patient.ContrastAllergies)
            {
               MWLDataset.ContrastAllergiesRow car = ds.ContrastAllergies.NewContrastAllergiesRow();

               car.ContrastAllergy = ca;
               car.PatientID = patient.PatientID;
               car.IssuerOfPatientID = patient.IssuerOfPatientID;
               ds.ContrastAllergies.AddContrastAllergiesRow(car);
            }
         }

         if (patient.OtherPatientIDs != null)
         {
            foreach (string oi in patient.OtherPatientIDs)
            {
               MWLDataset.OtherPatientIDsRow oir = ds.OtherPatientIDs.NewOtherPatientIDsRow();

               oir.OtherPatientID = oi;
               oir.PatientID = patient.PatientID;
               oir.IssuerOfPatientID = patient.IssuerOfPatientID;
               ds.OtherPatientIDs.AddOtherPatientIDsRow(oir);
            }
         }
      }

      /// <summary>
      /// Toes the imaging service request.
      /// </summary>
      /// <param name="ds">The ds.</param>
      /// <returns></returns>
      public static ImagingServiceRequest ToImagingServiceRequest(this MWLDataset ds)
      {
         ImagingServiceRequest request = new ImagingServiceRequest();
         MWLDataset.ImagingServiceRequestRow row = ds.ImagingServiceRequest.Rows[0] as MWLDataset.ImagingServiceRequestRow;

         row.CopyTo<ImagingServiceRequest>(request);
         return request;
      }

      /// <summary>
      /// Finds the specified access agent.
      /// </summary>
      /// <param name="accessAgent">The access agent.</param>
      /// <param name="queries">The queries.</param>
      /// <returns></returns>
      public static MWLDataset Find(this IWorklistDataAccessAgent2 accessAgent, params ICatalogEntity[] queries)
      {
         MatchingParameterCollection parameters = new MatchingParameterCollection();
         MatchingParameterList matchList = new MatchingParameterList();

         foreach (ICatalogEntity query in queries)
         {
            matchList.Add(query);
         }
         parameters.Add(matchList);
         return accessAgent.FindPatientInformation(parameters);
      }

      /// <summary>
      /// Finds the MPPS.
      /// </summary>
      /// <param name="accessAgent">The access agent.</param>
      /// <param name="queries">The queries.</param>
      /// <returns></returns>
      public static MPPSDataset FindMPPS(this IWorklistDataAccessAgent2 accessAgent, params ICatalogEntity[] queries)
      {
         MatchingParameterCollection parameters = new MatchingParameterCollection();
         MatchingParameterList matchList = new MatchingParameterList();

         foreach (ICatalogEntity query in queries)
         {
            if (query != null)
               matchList.Add(query);
         }
         parameters.Add(matchList);
         return accessAgent.QueryMPPS(parameters);
      }

      /// <summary>
      /// Updates the specified row.
      /// </summary>
      /// <param name="row">The row.</param>
      /// <param name="request">The request.</param>
      public static void Update(this MWLDataset.ImagingServiceRequestRow row, ImagingServiceRequest request)
      {
         request.CopyTo<MWLDataset.ImagingServiceRequestRow>(row);
      }

      public static WCFRequestedProcedure ToRequestedProcedure(this MWLDataset ds)
      {
         WCFRequestedProcedure procedure = new WCFRequestedProcedure();
         MWLDataset.RequestedProcedureRow row = ds.RequestedProcedure.Rows[0] as MWLDataset.RequestedProcedureRow;
         MWLDataset.RequestedProcedureCodeSequenceRow csRow = null;

         row.CopyTo<WCFRequestedProcedure>(procedure);
         if (ds.RequestedProcedureCodeSequence.Count > 0)
         {
            csRow = ds.RequestedProcedureCodeSequence.Single((cs) => cs.AccessionNumber == row["AccessionNumber"].ToString() && cs.RequestedProcedureID == row["RequestedProcedureID"].ToString());
            if (csRow != null)
            {
               procedure.RequestedProcedureCodeSequence = new RequestedProcedureCodeSequence();

               csRow.CopyTo<RequestedProcedureCodeSequence>(procedure.RequestedProcedureCodeSequence);
            }
         }
         if (ds.ReferencedStudySequence.Count > 0)
         {
            foreach (MWLDataset.ReferencedStudySequenceRow sq in ds.ReferencedStudySequence.Rows)
            {
               ReferencedStudySequence sequence = new ReferencedStudySequence();

               sequence.ReferencedSOPInstanceUID = sq.ReferencedSOPInstanceUID;
               sequence.ReferencedSOPClassUID = sq.ReferencedSOPClassUID;
               procedure.ReferencedStudySequence.Add(sequence);
            }
         }

         if (ds.Visit.Count > 0)
         {
            MWLDataset.VisitRow visitRow = ds.Visit.Rows[0] as MWLDataset.VisitRow;

            procedure.Visit = new WCFVisit();
            visitRow.CopyTo<WCFVisit>(procedure.Visit);

            if (ds.ReferencedPatientSequence.Count > 0)
            {
               procedure.Visit.ReferencedPatientSequence = new ReferencedPatientSequence();

               ds.ReferencedPatientSequence.Rows[0].CopyTo<ReferencedPatientSequence>(procedure.Visit.ReferencedPatientSequence);
            }
         }
         return procedure;
      }

      /// <summary>
      /// Adds the requested procedure.
      /// </summary>
      /// <param name="ds">The ds.</param>
      /// <param name="request">The request.</param>
      /// <param name="procedure">The procedure.</param>
      public static void AddRequestedProcedure(this MWLDataset ds, ImagingServiceRequest request, WCFRequestedProcedure procedure)
      {
         MWLDataset.RequestedProcedureRow rpr = ds.RequestedProcedure.NewRequestedProcedureRow();

         ds.EnforceConstraints = false;
         procedure.CopyTo<MWLDataset.RequestedProcedureRow>(rpr);
         rpr.AccessionNumber = request.AccessionNumber;
         ds.RequestedProcedure.AddRequestedProcedureRow(rpr);
         if (procedure.RequestedProcedureCodeSequence != null)
         {
            MWLDataset.RequestedProcedureCodeSequenceRow row = ds.RequestedProcedureCodeSequence.NewRequestedProcedureCodeSequenceRow();

            procedure.RequestedProcedureCodeSequence.CopyTo<MWLDataset.RequestedProcedureCodeSequenceRow>(row);
            row.AccessionNumber = request.AccessionNumber;
            row.RequestedProcedureID = procedure.RequestedProcedureID;
            ds.RequestedProcedureCodeSequence.AddRequestedProcedureCodeSequenceRow(row);
         }
         if (procedure.ReferencedStudySequence != null)
         {
            foreach (ReferencedStudySequence rs in procedure.ReferencedStudySequence)
            {
               MWLDataset.ReferencedStudySequenceRow row = ds.ReferencedStudySequence.NewReferencedStudySequenceRow();

               row.SetOrderNumberNull();
               row.ReferencedSOPClassUID = rs.ReferencedSOPClassUID;
               row.ReferencedSOPInstanceUID = rs.ReferencedSOPInstanceUID;
               row.RequestedProcedureID = procedure.RequestedProcedureID;
               row.AccessionNumber = request.AccessionNumber;
               ds.ReferencedStudySequence.AddReferencedStudySequenceRow(row);
            }
         }
      }

      /// <summary>
      /// Updates the specified row.
      /// </summary>
      /// <param name="row">The row.</param>
      /// <param name="request">The request.</param>
      public static void Update(this MWLDataset.RequestedProcedureRow row, WCFRequestedProcedure request)
      {
         MWLDataset ds = row.Table.DataSet as MWLDataset;
         string accessionNumber = row["AccessionNumber"].ToString();

         ds.EnforceConstraints = false;
         request.CopyTo<MWLDataset.RequestedProcedureRow>(row);

         foreach (DataRow r in ds.RequestedProcedureCodeSequence.Rows)
         {
            r.Delete();
         }

         if (request.RequestedProcedureCodeSequence != null)
         {
            MWLDataset.RequestedProcedureCodeSequenceRow csRow = ds.RequestedProcedureCodeSequence.NewRequestedProcedureCodeSequenceRow();

            //if (csRow == null)
            //{
            csRow = ds.RequestedProcedureCodeSequence.NewRequestedProcedureCodeSequenceRow();
            request.RequestedProcedureCodeSequence.CopyTo<MWLDataset.RequestedProcedureCodeSequenceRow>(csRow);
            csRow.AccessionNumber = accessionNumber;
            csRow.RequestedProcedureID = request.RequestedProcedureID;
            ds.RequestedProcedureCodeSequence.AddRequestedProcedureCodeSequenceRow(csRow);
            //}
            //else
            //{
            //   request.RequestedProcedureCodeSequence.CopyTo<MWLDataset.RequestedProcedureCodeSequenceRow>(csRow);
            //   row.AccessionNumber = accessionNumber;
            //   row.RequestedProcedureID = request.RequestedProcedureID;
            //}
         }

         if (ds.Visit.Count > 0)
         {
            if (request.Visit == null)
            {
               row.SetAdmissionIDNull();
               ds.Visit.Rows[0].Delete();
            }
            else
            {
               MWLDataset.VisitRow visitRow = ds.Visit.Rows[0] as MWLDataset.VisitRow;

               visitRow.AdmissionID = request.Visit.AdmissionID;
               visitRow.CurrentPatientLocation = request.Visit.CurrentPatientLocation;
               row.AdmissionID = request.Visit.AdmissionID;
            }
         }
         else
         {
            if (request.Visit != null)
            {
               MWLDataset.VisitRow visitRow = ds.Visit.NewVisitRow();

               request.Visit.CopyTo<MWLDataset.VisitRow>(visitRow);
               ds.Visit.AddVisitRow(visitRow);
               row.AdmissionID = request.Visit.AdmissionID;
            }
         }

         ds.ReferencedPatientSequence.DeleteAll();
         if (request.Visit != null && request.Visit.ReferencedPatientSequence != null)
         {
            if (!string.IsNullOrEmpty(request.Visit.ReferencedPatientSequence.ReferencedSOPClassUID) &&
                  !string.IsNullOrEmpty(request.Visit.ReferencedPatientSequence.ReferencedSOPInstanceUID))
            {
               MWLDataset.ReferencedPatientSequenceRow r = ds.ReferencedPatientSequence.NewReferencedPatientSequenceRow();

               request.Visit.ReferencedPatientSequence.CopyTo<MWLDataset.ReferencedPatientSequenceRow>(r);
               r.AdmissionID = request.Visit.AdmissionID;
               ds.ReferencedPatientSequence.Rows.Add(r);
            }
         }
         //else if (request.Visit == null || (request.Visit != null && request.Visit.ReferencedPatientSequence == null))
         //{
         //   ds.ReferencedPatientSequence.DeleteAll();
         //}

         ds.ReferencedStudySequence.DeleteAll();
         if (request.ReferencedStudySequence != null)
         {
            foreach (ReferencedStudySequence rs in request.ReferencedStudySequence)
            {
               MWLDataset.ReferencedStudySequenceRow r = ds.ReferencedStudySequence.NewReferencedStudySequenceRow();

               r.SetOrderNumberNull();
               r.ReferencedSOPClassUID = rs.ReferencedSOPClassUID;
               r.ReferencedSOPInstanceUID = rs.ReferencedSOPInstanceUID;
               r.RequestedProcedureID = request.RequestedProcedureID;
               r.AccessionNumber = accessionNumber;
               ds.ReferencedStudySequence.AddReferencedStudySequenceRow(r);
            }
         }
      }

      /// <summary>
      /// Toes the scheduled procedure step.
      /// </summary>
      /// <param name="ds">The ds.</param>
      /// <returns></returns>
      public static WCFScheduledProcedureStep ToScheduledProcedureStep(this MWLDataset ds)
      {
         WCFScheduledProcedureStep sps = new WCFScheduledProcedureStep();
         MWLDataset.ScheduledProcedureStepRow row = ds.ScheduledProcedureStep.Rows[0] as MWLDataset.ScheduledProcedureStepRow;

         row.CopyTo<WCFScheduledProcedureStep>(sps);
         sps.ScheduledProcedureStepStartDate_Time = new Common.DateRange() { StartDate = row.ScheduledProcedureStepStartDate_Time };

         sps.ScheduledProtocolCodeSequence = new List<ScheduledProtocolCodeSequence>();
         foreach (MWLDataset.ScheduledProtocolCodeSequenceRow r in ds.ScheduledProtocolCodeSequence.Rows)
         {
            ScheduledProtocolCodeSequence s = new ScheduledProtocolCodeSequence();

            s.CodeMeaning = r.CodeMeaning;
            s.CodeValue = r.CodeValue;
            s.CodingSchemeDesignator = r.CodingSchemeDesignator;
            s.CodingSchemeVersion = r.CodingSchemeVersion;
            //s.OrderNumber = !r.IsOrderNumberNull() ? r.OrderNumber.ToString() : string.Empty;
            sps.ScheduledProtocolCodeSequence.Add(s);
         }

         sps.ScheduledStationName = new List<string>();
         foreach (MWLDataset.ScheduledStationNamesRow r in ds.ScheduledStationNames.Rows)
         {
            sps.ScheduledStationName.Add(r.ScheduledStationName);
         }

         sps.ScheduledStationAETitle = new List<string>();
         foreach (MWLDataset.ScheduledStationAETitlesRow r in ds.ScheduledStationAETitles)
         {
            sps.ScheduledStationAETitle.Add(r.ScheduledStationAETitle);
         }

         return sps;
      }

      /// <summary>
      /// Adds the scheduled procedure step.
      /// </summary>
      /// <param name="ds">The ds.</param>
      /// <param name="request">The request.</param>
      /// <param name="procedure">The procedure.</param>
      /// <param name="procedureStep">The procedure step.</param>
      public static void AddScheduledProcedureStep(this MWLDataset ds, ImagingServiceRequest request, WCFRequestedProcedure procedure,
                                                   WCFScheduledProcedureStep procedureStep)
      {
         MWLDataset.ScheduledProcedureStepRow sps = ds.ScheduledProcedureStep.NewScheduledProcedureStepRow();

         procedureStep.CopyTo<MWLDataset.ScheduledProcedureStepRow>(sps);
         sps.AccessionNumber = request.AccessionNumber;
         sps.RequestedProcedureID = procedure.RequestedProcedureID;
         sps.ScheduledProcedureStepStartDate_Time = procedureStep.ScheduledProcedureStepStartDate_Time.StartDate.Value;
         ds.ScheduledProcedureStep.AddScheduledProcedureStepRow(sps);

         if (procedureStep.ScheduledStationAETitle != null && procedureStep.ScheduledStationAETitle.Count > 0)
         {
            foreach (string ae in procedureStep.ScheduledStationAETitle)
            {
               MWLDataset.ScheduledStationAETitlesRow row = ds.ScheduledStationAETitles.NewScheduledStationAETitlesRow();

               row.ScheduledStationAETitle = ae;
               row.ScheduledProcedureStepID = procedureStep.ScheduledProcedureStepID;
               ds.ScheduledStationAETitles.Rows.Add(row);
            }
         }

         if (procedureStep.ScheduledStationName != null && procedureStep.ScheduledStationName.Count > 0)
         {
            foreach (string name in procedureStep.ScheduledStationName)
            {
               MWLDataset.ScheduledStationNamesRow row = ds.ScheduledStationNames.NewScheduledStationNamesRow();

               row.ScheduledStationName = name;
               row.ScheduledProcedureStepID = procedureStep.ScheduledProcedureStepID;
               ds.ScheduledStationNames.Rows.Add(row);
            }
         }

         if (procedureStep.ScheduledProtocolCodeSequence != null)
         {
            foreach (ScheduledProtocolCodeSequence spcs in procedureStep.ScheduledProtocolCodeSequence)
            {
               MWLDataset.ScheduledProtocolCodeSequenceRow row = ds.ScheduledProtocolCodeSequence.NewScheduledProtocolCodeSequenceRow();

               row.CodeMeaning = spcs.CodeMeaning;
               row.CodeValue = spcs.CodeValue;
               row.CodingSchemeDesignator = spcs.CodingSchemeDesignator;
               row.CodingSchemeVersion = spcs.CodingSchemeVersion;
               row.SetOrderNumberNull();
               row.ScheduledProcedureStepID = procedureStep.ScheduledProcedureStepID;
               ds.ScheduledProtocolCodeSequence.AddScheduledProtocolCodeSequenceRow(row);
            }
         }
      }

      /// <summary>
      /// Updates the specified row.
      /// </summary>
      /// <param name="row">The row.</param>
      /// <param name="procedureStep">The procedure step.</param>
      public static void Update(this MWLDataset.ScheduledProcedureStepRow row, WCFScheduledProcedureStep procedureStep)
      {
         MWLDataset ds = row.Table.DataSet as MWLDataset;
         string accessionNumber = row["AccessionNumber"].ToString();
         string requestedProcedureID = row["RequestedProcedureID"].ToString();

         procedureStep.CopyTo<MWLDataset.ScheduledProcedureStepRow>(row);
         row.AccessionNumber = accessionNumber;
         row.RequestedProcedureID = requestedProcedureID;
         row.ScheduledProcedureStepStartDate_Time = procedureStep.ScheduledProcedureStepStartDate_Time.StartDate.Value;

         foreach (DataRow r in ds.ScheduledStationAETitles.Rows)
         {
            r.Delete();
         }

         if (procedureStep.ScheduledStationAETitle != null && procedureStep.ScheduledStationAETitle.Count > 0)
         {
            foreach (string ae in procedureStep.ScheduledStationAETitle)
            {
               MWLDataset.ScheduledStationAETitlesRow r = ds.ScheduledStationAETitles.NewScheduledStationAETitlesRow();

               r.ScheduledStationAETitle = ae;
               r.ScheduledProcedureStepID = procedureStep.ScheduledProcedureStepID;
               ds.ScheduledStationAETitles.Rows.Add(r);
            }
         }

         foreach (DataRow r in ds.ScheduledStationNames.Rows)
         {
            r.Delete();
         }

         if (procedureStep.ScheduledStationName != null && procedureStep.ScheduledStationName.Count > 0)
         {
            foreach (string name in procedureStep.ScheduledStationName)
            {
               MWLDataset.ScheduledStationNamesRow r = ds.ScheduledStationNames.NewScheduledStationNamesRow();

               r.ScheduledStationName = name;
               r.ScheduledProcedureStepID = procedureStep.ScheduledProcedureStepID;
               ds.ScheduledStationNames.Rows.Add(r);
            }
         }

         foreach (DataRow r in ds.ScheduledProtocolCodeSequence.Rows)
         {
            r.Delete();
         }

         if (procedureStep.ScheduledProtocolCodeSequence != null)
         {
            foreach (ScheduledProtocolCodeSequence spcs in procedureStep.ScheduledProtocolCodeSequence)
            {
               MWLDataset.ScheduledProtocolCodeSequenceRow r = ds.ScheduledProtocolCodeSequence.NewScheduledProtocolCodeSequenceRow();

               r.CodeMeaning = spcs.CodeMeaning;
               r.CodeValue = spcs.CodeValue;
               r.CodingSchemeDesignator = spcs.CodingSchemeDesignator;
               r.CodingSchemeVersion = spcs.CodingSchemeVersion;
               r.SetOrderNumberNull();
               r.ScheduledProcedureStepID = procedureStep.ScheduledProcedureStepID;
               ds.ScheduledProtocolCodeSequence.AddScheduledProtocolCodeSequenceRow(r);
            }
         }
      }

      /// <summary>
      /// Toes the visit.
      /// </summary>
      /// <param name="ds">The ds.</param>
      /// <returns></returns>
      public static WCFVisit ToVisit(this MWLDataset ds)
      {
         WCFVisit visit = new WCFVisit();
         MWLDataset.VisitRow row = ds.Visit.Rows[0] as MWLDataset.VisitRow;

         row.CopyTo<WCFVisit>(visit);
         foreach (MWLDataset.ReferencedPatientSequenceRow r in ds.ReferencedPatientSequence.Rows)
         {
            visit.ReferencedPatientSequence.ReferencedSOPClassUID = r.ReferencedSOPClassUID;
            visit.ReferencedPatientSequence.ReferencedSOPInstanceUID = r.ReferencedSOPInstanceUID;
         }

         return visit;
      }

      /// <summary>
      /// Adds the visit.
      /// </summary>
      /// <param name="ds">The ds.</param>
      /// <param name="visit">The visit.</param>
      public static void AddVisit(this MWLDataset ds, WCFVisit visit)
      {
         MWLDataset.VisitRow row = ds.Visit.NewVisitRow();

         visit.CopyTo<MWLDataset.VisitRow>(row);
         ds.Visit.AddVisitRow(row);
         if (visit.ReferencedPatientSequence != null)
         {
            MWLDataset.ReferencedPatientSequenceRow r = ds.ReferencedPatientSequence.NewReferencedPatientSequenceRow();

            r.AdmissionID = visit.AdmissionID;
            r.ReferencedSOPClassUID = visit.ReferencedPatientSequence.ReferencedSOPClassUID;
            r.ReferencedSOPInstanceUID = visit.ReferencedPatientSequence.ReferencedSOPInstanceUID;
            ds.ReferencedPatientSequence.AddReferencedPatientSequenceRow(r);
         }
      }

      public static void Update(this MWLDataset.VisitRow row, WCFVisit visit)
      {
         MWLDataset ds = row.Table.DataSet as MWLDataset;

         visit.CopyTo(row);
         foreach (MWLDataset.ReferencedPatientSequenceRow r in ds.ReferencedPatientSequence)
         {
            r.Delete();
         }
         if (visit.ReferencedPatientSequence != null)
         {
            MWLDataset.ReferencedPatientSequenceRow r = ds.ReferencedPatientSequence.NewReferencedPatientSequenceRow();

            r.AdmissionID = visit.AdmissionID;
            r.ReferencedSOPClassUID = visit.ReferencedPatientSequence.ReferencedSOPClassUID;
            r.ReferencedSOPInstanceUID = visit.ReferencedPatientSequence.ReferencedSOPInstanceUID;
            ds.ReferencedPatientSequence.AddReferencedPatientSequenceRow(r);
         }
      }

      /// <summary>
      /// Adds the MPPS.
      /// </summary>
      /// <param name="ds">The ds.</param>
      /// <param name="mpps">The MPPS.</param>
      public static void AddMPPS(this MPPSDataset ds, WCFPPSInformation mpps)
      {
         MPPSDataset.PPSInformationRow row = ds.PPSInformation.NewPPSInformationRow();
         MPPSDataset.PatientInfoforUnscheduledPPSRow prow = ds.PatientInfoforUnscheduledPPS.NewPatientInfoforUnscheduledPPSRow();

         mpps.CopyTo<MPPSDataset.PPSInformationRow>(row);
         row.PerformedProcedureStepStartDate = mpps.PerformedProcedureStepStartDate.Value.Date1.ToDateTime();
         row.PerformedProcedureStepStartTime = mpps.PerformedProcedureStepStartTime.Value.Time1.ToDateTime();
         if (mpps.PerformedProcedureStepEndDate != null)
         {
            row.PerformedProcedureStepEndDate = mpps.PerformedProcedureStepEndDate.Value.Date1.ToDateTime();
         }
         if (mpps.PerformedProcedureStepEndTime != null)
         {
            row.PerformedProcedureStepEndTime = mpps.PerformedProcedureStepEndTime.Value.Time1.ToDateTime();
         }
         ds.PPSInformation.AddPPSInformationRow(row);
         AddMPPSSequenceItems(mpps, ds);

         prow.MPPSSOPInstanceUID = mpps.MPPSSOPInstanceUID;
         if (mpps.UnscheduledPatient != null)
         {
            prow.PatientID = mpps.UnscheduledPatient.PatientID;
            prow.PatientName = mpps.UnscheduledPatient.PatientName;
            prow.PatientSex = mpps.UnscheduledPatient.PatientSex;
            if (mpps.UnscheduledPatient.PatientBirthDate.HasValue)
               prow.PatientBirthDate = mpps.UnscheduledPatient.PatientBirthDate.Value.Date1.ToDateTime();
         }
         ds.PatientInfoforUnscheduledPPS.AddPatientInfoforUnscheduledPPSRow(prow);
      }

      /// <summary>
      /// Adds the MPPS sequence items.
      /// </summary>
      /// <param name="mpps">The MPPS.</param>
      /// <param name="ds">The ds.</param>
      private static void AddMPPSSequenceItems(WCFPPSInformation mpps, MPPSDataset ds)
      {
         string filter = "MPPSSOPInstanceUID = '" + mpps.MPPSSOPInstanceUID + "'";

         ds.PPSDiscontinuationReasonCodeSequence.Delete(filter);
         if (mpps.PPSDiscontinuationReasonCodeSequence != null)
         {
            foreach (PPSDiscontinuationReasonCodeSequence s in mpps.PPSDiscontinuationReasonCodeSequence)
            {
               MPPSDataset.PPSDiscontinuationReasonCodeSequenceRow r = ds.PPSDiscontinuationReasonCodeSequence.NewPPSDiscontinuationReasonCodeSequenceRow();

               s.CopyTo<MPPSDataset.PPSDiscontinuationReasonCodeSequenceRow>(r);
               r.MPPSSOPInstanceUID = mpps.MPPSSOPInstanceUID;
               ds.PPSDiscontinuationReasonCodeSequence.AddPPSDiscontinuationReasonCodeSequenceRow(r);
            }
         }

         ds.ProcedureCodeSequence.Delete(filter);
         if (mpps.ProcedureCodeSequence != null)
         {
            foreach (ProcedureCodeSequence s in mpps.ProcedureCodeSequence)
            {
               MPPSDataset.ProcedureCodeSequenceRow r = ds.ProcedureCodeSequence.NewProcedureCodeSequenceRow();

               s.CopyTo<MPPSDataset.ProcedureCodeSequenceRow>(r);
               r.MPPSSOPInstanceUID = mpps.MPPSSOPInstanceUID;
               ds.ProcedureCodeSequence.AddProcedureCodeSequenceRow(r);
            }
         }

         ds.PerformedProtocolCodeSequence.Delete(filter);
         if (mpps.PerformedProtocolCodeSequence != null)
         {
            foreach (PerformedProtocolCodeSequence s in mpps.PerformedProtocolCodeSequence)
            {
               MPPSDataset.PerformedProtocolCodeSequenceRow r = ds.PerformedProtocolCodeSequence.NewPerformedProtocolCodeSequenceRow();

               s.CopyTo<MPPSDataset.PerformedProtocolCodeSequenceRow>(r);
               r.MPPSSOPInstanceUID = mpps.MPPSSOPInstanceUID;
               ds.PerformedProtocolCodeSequence.AddPerformedProtocolCodeSequenceRow(r);
            }
         }

         ds.PPSRelationship.Delete(filter);
         if (mpps.PPSRelationShip != null)
         {
            foreach (PPSRelationship s in mpps.PPSRelationShip)
            {
               MPPSDataset.PPSRelationshipRow r = ds.PPSRelationship.NewPPSRelationshipRow();

               s.CopyTo<MPPSDataset.PPSRelationshipRow>(r);
               r.MPPSSOPInstanceUID = mpps.MPPSSOPInstanceUID;
               ds.PPSRelationship.AddPPSRelationshipRow(r);
            }
         }

         ds.PerformedSeriesSequence.Delete(filter);
         if (mpps.PerformedSeriesSequence != null)
         {
            foreach (PerformedSeriesSequence s in mpps.PerformedSeriesSequence)
            {
               MPPSDataset.PerformedSeriesSequenceRow r = ds.PerformedSeriesSequence.NewPerformedSeriesSequenceRow();

               s.CopyTo<MPPSDataset.PerformedSeriesSequenceRow>(r);
               r.MPPSSOPInstanceUID = mpps.MPPSSOPInstanceUID;
               ds.PerformedSeriesSequence.AddPerformedSeriesSequenceRow(r);
            }
         }

         ds.ReferencedImageSequence.Delete(filter);
         if (mpps.ReferencedImageSequence != null)
         {
            foreach (ReferencedImageSequence s in mpps.ReferencedImageSequence)
            {
               MPPSDataset.ReferencedImageSequenceRow r = ds.ReferencedImageSequence.NewReferencedImageSequenceRow();

               s.CopyTo<MPPSDataset.ReferencedImageSequenceRow>(r);
               r.MPPSSOPInstanceUID = mpps.MPPSSOPInstanceUID;
               ds.ReferencedImageSequence.AddReferencedImageSequenceRow(r);
            }
         }

         ds.ReferencedNonImageCompositeSequence.Delete(filter);
         if (mpps.ReferencedNonImageCompositeSequence != null)
         {
            foreach (ReferencedNonImageCompositeSequence s in mpps.ReferencedNonImageCompositeSequence)
            {
               MPPSDataset.ReferencedNonImageCompositeSequenceRow r = ds.ReferencedNonImageCompositeSequence.NewReferencedNonImageCompositeSequenceRow();

               s.CopyTo<MPPSDataset.ReferencedNonImageCompositeSequenceRow>(r);
               r.MPPSSOPInstanceUID = mpps.MPPSSOPInstanceUID;
               ds.ReferencedNonImageCompositeSequence.AddReferencedNonImageCompositeSequenceRow(r);
            }
         }
      }

      /// <summary>
      /// Toes the PPS information.
      /// </summary>
      /// <param name="ds">The ds.</param>
      /// <returns></returns>
      public static WCFPPSInformation ToPPSInformation(this MPPSDataset ds)
      {
         WCFPPSInformation mpps = new WCFPPSInformation();
         MPPSDataset.PPSInformationRow row = ds.PPSInformation.Rows[0] as MPPSDataset.PPSInformationRow;

         row.CopyTo<PPSInformation>(mpps);
         mpps.PerformedProcedureStepStartDate = new DicomDateRangeValue();
         mpps.PerformedProcedureStepStartDate = row.PerformedProcedureStepStartDate.ToDateRange();
         mpps.PerformedProcedureStepStartTime = new DicomTimeRangeValue();
         mpps.PerformedProcedureStepStartTime = row.PerformedProcedureStepStartTime.ToTimeRange();
         if (!row.IsPerformedProcedureStepEndDateNull())
         {
            mpps.PerformedProcedureStepEndDate = row.PerformedProcedureStepEndDate.ToDateRange();
         }

         if (!row.IsPerformedProcedureStepEndTimeNull())
         {
            mpps.PerformedProcedureStepEndTime = row.PerformedProcedureStepEndTime.ToTimeRange();
         }

         if (ds.PatientInfoforUnscheduledPPS.Rows.Count > 0)
         {
            MPPSDataset.PatientInfoforUnscheduledPPSRow r = ds.PatientInfoforUnscheduledPPS.Rows[0] as MPPSDataset.PatientInfoforUnscheduledPPSRow;

            mpps.UnscheduledPatient = new PatientInfoforUnscheduledPPS();
            if (!r.IsPatientIDNull())
               mpps.UnscheduledPatient.PatientID = r.PatientID;
            if (!r.IsIssuerofPatientIDNull())
               mpps.UnscheduledPatient.IssuerofPatientID = r.IssuerofPatientID;
            if (!r.IsPatientNameNull())
               mpps.UnscheduledPatient.PatientName = r.PatientName;
            if (!r.IsPatientSexNull())
               mpps.UnscheduledPatient.PatientSex = r.PatientSex;
            if (!r.IsPatientBirthDateNull())
               mpps.UnscheduledPatient.PatientBirthDate = r.PatientBirthDate.ToDateRange();
         }

         LoadMPPSSequenceItems(mpps, ds);

         return mpps;
      }

      public static void ToPPSInformation(this MPPSDataset ds, List<WCFPPSInformation> list)
      {
         foreach (MPPSDataset.PPSInformationRow row in ds.PPSInformation.Rows)
         {
            WCFPPSInformation mpps = new WCFPPSInformation();

            row.CopyTo<PPSInformation>(mpps);
            mpps.PerformedProcedureStepStartDate = new DicomDateRangeValue();
            mpps.PerformedProcedureStepStartDate = row.PerformedProcedureStepStartDate.ToDateRange();
            mpps.PerformedProcedureStepStartTime = new DicomTimeRangeValue();
            mpps.PerformedProcedureStepStartTime = row.PerformedProcedureStepStartTime.ToTimeRange();
            if (!row.IsPerformedProcedureStepEndDateNull())
            {
               mpps.PerformedProcedureStepEndDate = row.PerformedProcedureStepEndDate.ToDateRange();
            }

            if (!row.IsPerformedProcedureStepEndTimeNull())
            {
               mpps.PerformedProcedureStepEndTime = row.PerformedProcedureStepEndTime.ToTimeRange();
            }

            if (ds.PatientInfoforUnscheduledPPS.Rows.Count > 0)
            {
               MPPSDataset.PatientInfoforUnscheduledPPSRow r = ds.PatientInfoforUnscheduledPPS.Rows[0] as MPPSDataset.PatientInfoforUnscheduledPPSRow;

               mpps.UnscheduledPatient = new PatientInfoforUnscheduledPPS();
               if (!r.IsPatientIDNull())
                  mpps.UnscheduledPatient.PatientID = r.PatientID;
               if (!r.IsIssuerofPatientIDNull())
                  mpps.UnscheduledPatient.IssuerofPatientID = r.IssuerofPatientID;
               if (!r.IsPatientNameNull())
                  mpps.UnscheduledPatient.PatientName = r.PatientName;
               if (!r.IsPatientSexNull())
                  mpps.UnscheduledPatient.PatientSex = r.PatientSex;
               if (!r.IsPatientBirthDateNull())
                  mpps.UnscheduledPatient.PatientBirthDate = r.PatientBirthDate.ToDateRange();
            }

            LoadMPPSSequenceItems(mpps, ds);
            LoadPatient(mpps);
            list.Add(mpps);
         }
      }

      private class WCFPPSRelationship : PPSRelationship
      {
         public override string CatalogKey
         {
            get
            {
               return "PPSRelationship";
            }
         }
         [EntityElement]         
         public string MPPSSOPInstanceUID { get; set; }
      }

      private static void LoadPatient(WCFPPSInformation mpps)
      {
         WCFPPSRelationship ppsRelationship = new WCFPPSRelationship() { MPPSSOPInstanceUID = mpps.MPPSSOPInstanceUID };
         MWLDataset ds = DB.DataAccess.Find(ppsRelationship);

         if (ds.Patient.Rows.Count == 1)
         {
            mpps.Patient = ds.ToPatient();
         }
         return;
      }

      /// <summary>
      /// Loads the MPPS sequence items.
      /// </summary>
      /// <param name="mpps">The MPPS.</param>
      /// <param name="ds">The ds.</param>
      private static void LoadMPPSSequenceItems(WCFPPSInformation mpps, MPPSDataset ds)
      {
         string filter = "MPPSSOPInstanceUID = '" + mpps.MPPSSOPInstanceUID + "'";

         mpps.PPSDiscontinuationReasonCodeSequence = new List<PPSDiscontinuationReasonCodeSequence>();
         foreach (MPPSDataset.PPSDiscontinuationReasonCodeSequenceRow r in ds.PPSDiscontinuationReasonCodeSequence.Select(filter))
         {
            PPSDiscontinuationReasonCodeSequence item = new PPSDiscontinuationReasonCodeSequence();

            r.CopyTo<PPSDiscontinuationReasonCodeSequence>(item);
            mpps.PPSDiscontinuationReasonCodeSequence.Add(item);
         }

         mpps.ProcedureCodeSequence = new List<ProcedureCodeSequence>();
         foreach (MPPSDataset.ProcedureCodeSequenceRow r in ds.ProcedureCodeSequence.Select(filter))
         {
            ProcedureCodeSequence item = new ProcedureCodeSequence();

            r.CopyTo<ProcedureCodeSequence>(item);
            mpps.ProcedureCodeSequence.Add(item);
         }

         mpps.PerformedProtocolCodeSequence = new List<PerformedProtocolCodeSequence>();
         foreach (MPPSDataset.PerformedProtocolCodeSequenceRow r in ds.PerformedProtocolCodeSequence.Select(filter))
         {
            PerformedProtocolCodeSequence item = new PerformedProtocolCodeSequence();

            r.CopyTo<PerformedProtocolCodeSequence>(item);
            mpps.PerformedProtocolCodeSequence.Add(item);
         }

         mpps.PPSRelationShip = new List<PPSRelationship>();
         foreach (MPPSDataset.PPSRelationshipRow r in ds.PPSRelationship.Select(filter))
         {
            PPSRelationship item = new PPSRelationship();

            r.CopyTo<PPSRelationship>(item);
            mpps.PPSRelationShip.Add(item);
         }

         mpps.PerformedSeriesSequence = new List<PerformedSeriesSequence>();
         foreach (MPPSDataset.PerformedSeriesSequenceRow r in ds.PerformedSeriesSequence.Select(filter))
         {
            PerformedSeriesSequence item = new PerformedSeriesSequence();

            r.CopyTo<PerformedSeriesSequence>(item);
            mpps.PerformedSeriesSequence.Add(item);
         }

         mpps.ReferencedImageSequence = new List<WCFReferencedImageSequence>();
         foreach (MPPSDataset.ReferencedImageSequenceRow r in ds.ReferencedImageSequence.Select(filter))
         {
            WCFReferencedImageSequence item = new WCFReferencedImageSequence();

            r.CopyTo<ReferencedImageSequence>(item);
            mpps.ReferencedImageSequence.Add(item);
         }

         mpps.ReferencedNonImageCompositeSequence = new List<ReferencedNonImageCompositeSequence>();
         foreach (MPPSDataset.ReferencedNonImageCompositeSequenceRow r in ds.ReferencedNonImageCompositeSequence.Select(filter))
         {
            ReferencedNonImageCompositeSequence item = new ReferencedNonImageCompositeSequence();

            r.CopyTo<ReferencedNonImageCompositeSequence>(item);
            mpps.ReferencedNonImageCompositeSequence.Add(item);
         }
      }

      /// <summary>
      /// Updates the specified row.
      /// </summary>
      /// <param name="row">The row.</param>
      /// <param name="mpps">The MPPS.</param>
      public static void Update(this MPPSDataset.PPSInformationRow row, WCFPPSInformation mpps)
      {
         MPPSDataset ds = row.Table.DataSet as MPPSDataset;

         mpps.CopyTo<MPPSDataset.PPSInformationRow>(row);
         row.PerformedProcedureStepStartDate = mpps.PerformedProcedureStepStartDate.Value.Date1.ToDateTime();
         row.PerformedProcedureStepStartTime = mpps.PerformedProcedureStepStartTime.Value.Time1.ToDateTime();
         if (mpps.PerformedProcedureStepEndDate != null)
         {
            row.PerformedProcedureStepEndDate = mpps.PerformedProcedureStepEndDate.Value.Date1.ToDateTime();
         }
         if (mpps.PerformedProcedureStepEndTime != null)
         {
            row.PerformedProcedureStepEndTime = mpps.PerformedProcedureStepEndTime.Value.Time1.ToDateTime();
         }
         ds.PPSDiscontinuationReasonCodeSequence.DeleteAll();
         ds.ProcedureCodeSequence.DeleteAll();
         ds.PerformedProtocolCodeSequence.DeleteAll();
         ds.PPSRelationship.DeleteAll();
         ds.PerformedSeriesSequence.DeleteAll();
         ds.ReferencedImageSequence.DeleteAll();
         ds.ReferencedNonImageCompositeSequence.DeleteAll();
         ds.PatientInfoforUnscheduledPPS.DeleteAll();
         AddMPPSSequenceItems(mpps, ds);

         MPPSDataset.PatientInfoforUnscheduledPPSRow prow = ds.PatientInfoforUnscheduledPPS.NewPatientInfoforUnscheduledPPSRow();

         prow.MPPSSOPInstanceUID = mpps.MPPSSOPInstanceUID;
         if (mpps.UnscheduledPatient != null)
         {
            prow.PatientID = mpps.UnscheduledPatient.PatientID;
            prow.PatientName = mpps.UnscheduledPatient.PatientName;
            prow.PatientSex = mpps.UnscheduledPatient.PatientSex;
            prow.IssuerofPatientID = mpps.UnscheduledPatient.IssuerofPatientID;
            if (mpps.UnscheduledPatient.PatientBirthDate.HasValue)
               prow.PatientBirthDate = mpps.UnscheduledPatient.PatientBirthDate.Value.Date1.ToDateTime();
         }
         ds.PatientInfoforUnscheduledPPS.AddPatientInfoforUnscheduledPPSRow(prow);
      }

      /// <summary>
      /// Toes the date range.
      /// </summary>
      /// <param name="dt">The dt.</param>
      /// <returns></returns>
      public static DicomDateRangeValue ToDateRange(this DateTime dt)
      {
         DicomDateRangeValue dr = new DicomDateRangeValue();

         dr.Date1 = new DicomDateValue(dt);

         return dr;
      }

      /// <summary>
      /// Converts DateTime to DicomTimeRangeValue.
      /// </summary>
      /// <param name="dt">The DateTime value to convert.</param>
      public static DicomTimeRangeValue ToTimeRange(this DateTime dt)
      {
         DicomTimeRangeValue tr = new DicomTimeRangeValue();

         tr.Time1 = new DicomTimeValue(dt);

         return tr;
      }

      /// <summary>
      /// Deletes all the rows from the table.
      /// </summary>
      /// <param name="table">The table.</param>
      public static void DeleteAll(this DataTable table)
      {
         foreach (DataRow row in table.Rows)
         {
            row.Delete();
         }
      }

      public static DataTable Delete(this DataTable table, string filter)
      {
         table.Select(filter).Delete();
         return table;
      }

      public static void Delete(this IEnumerable<DataRow> rows)
      {
         foreach (var row in rows)
            row.Delete();
      }
   }
}

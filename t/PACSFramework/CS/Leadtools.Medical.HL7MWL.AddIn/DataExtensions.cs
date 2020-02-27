// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Leadtools.Medical.Worklist.DataAccessLayer.BusinessEntity;
using System.Reflection;
using System.Data;
using Leadtools.Logging;
using Leadtools.Logging.Medical;
using Leadtools.Dicom;
using Leadtools.Dicom.AddIn;
using Leadtools.Dicom.AddIn.Interfaces;
using Leadtools.Medical.Worklist.DataAccessLayer;
using System.IO;
using Leadtools.Medical.Worklist.DataAccessLayer.MatchingParameters;

namespace Leadtools.Medical.HL7MWL.AddIn
{
   internal static class DataExtensions
   {
      public static bool IsNullOrEmpty(this string v)
      {
         return string.IsNullOrEmpty(v);
      }

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
      public static void AddPatient(this MWLDataset ds, WCFPatient patient)
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
             if (!patient.PregnancyStatus.IsNullOrEmpty())
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
      }
   }
}

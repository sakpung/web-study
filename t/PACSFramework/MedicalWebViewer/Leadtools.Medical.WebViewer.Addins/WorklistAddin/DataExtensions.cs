// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Data;
using Leadtools.Medical.Worklist.DataAccessLayer.BusinessEntity;
using Leadtools.Medical.WebViewer.DataContracts;
using Leadtools.Medical.Worklist.DataAccessLayer;
using Leadtools.Medical.DataAccessLayer;
using Leadtools.Medical.DataAccessLayer.Catalog;
using Leadtools.Medical.Worklist.DataAccessLayer.MatchingParameters;

namespace Leadtools.Medical.WebViewer.Addins
{
    internal static class DataExtensions
    {
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

                    if (toProperty.CanWrite)
                    {
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

        public static void AddPatient(this MWLDataset ds, WorklistPatient patient)
        {
            MWLDataset.PatientRow pr = ds.Patient.NewPatientRow();

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
            ds.Patient.AddPatientRow(pr);

            /*if (patient.MedicalAlerts != null)
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
            }*/
        }

        public static void AddImagingServiceRequest(this MWLDataset ds, Patient patient, ImagingServiceRequest request)
        {
            MWLDataset.ImagingServiceRequestRow ir = ds.ImagingServiceRequest.NewImagingServiceRequestRow();

            request.CopyTo<MWLDataset.ImagingServiceRequestRow>(ir);
            ir.PatientID = patient.PatientID;
            ir.IssuerOfPatientID = patient.IssuerOfPatientID;
            ds.ImagingServiceRequest.AddImagingServiceRequestRow(ir);
        }

        public static void AddRequestedProcedure(this MWLDataset ds, ImagingServiceRequest request, WorklistRequestedProcedure procedure)
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

        public static void AddScheduledProcedureStep(this MWLDataset ds, ImagingServiceRequest request, WorklistRequestedProcedure procedure,
                                                     WorklistScheduledProcedureStep procedureStep)
        {
            MWLDataset.ScheduledProcedureStepRow sps = ds.ScheduledProcedureStep.NewScheduledProcedureStepRow();

            procedureStep.CopyTo<MWLDataset.ScheduledProcedureStepRow>(sps);
            sps.AccessionNumber = request.AccessionNumber;
            sps.RequestedProcedureID = procedure.RequestedProcedureID;
            if (procedureStep.ScheduledProcedureStepStartDate_Time!=null && procedureStep.ScheduledProcedureStepStartDate_Time.StartDate.HasValue)
            {
                sps.ScheduledProcedureStepStartDate_Time = procedureStep.ScheduledProcedureStepStartDate_Time.StartDate.Value;
            }                               
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

        public static MWLDataset Find(this IWorklistDataAccessAgent accessAgent, params ICatalogEntity[] queries)
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
    }
}

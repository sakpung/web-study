// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using Leadtools.Medical.WebViewer.DataContracts;
using System.Collections.Generic;

namespace Leadtools.Medical.WebViewer.Wado
{
   internal static class WadoDataSetAdapter
   {
      internal static InstanceData ReadInstanceData(WadoDataSetModel model)
      {
         var adaptee = new InstanceData();

         //adaptee.DicomJSON  
         //adaptee.ImageURL  
         adaptee.InstanceNumber = model.InstanceNumber;
         //adaptee.MRTIImageInfo
         adaptee.NumberOfFrames = (string.IsNullOrEmpty(model.NumberOfFrames)) ? 0 : int.Parse(model.NumberOfFrames);
         //PageInfo PagesInfo 
         adaptee.PatientID = model.PatientID;
         adaptee.SeriesInstanceUID = model.SeriesInstanceUID;
         adaptee.SOPClassUID = model.SOPClassUID;
         adaptee.SOPInstanceUID = model.SOPInstanceUID;
         adaptee.StationName = model.StationName;
         adaptee.StudyInstanceUID = model.StudyInstanceUID;
         adaptee.TransferSyntax = model.TransferSyntaxUID;

         return adaptee;
      }
      internal static PatientData ReadPatientData(WadoDataSetModel model)
      {
         var adaptee = new PatientData();

         adaptee.BirthDate = model.PatientBirthDate;
         adaptee.Comments = string.Empty;
         adaptee.EthnicGroup = string.Empty;
         adaptee.ID = model.PatientID;
         adaptee.Name = model.PatientName;
         adaptee.NumberOfRelatedInstances = model.NumberOfStudyRelatedInstances;
         adaptee.NumberOfRelatedSeries = model.NumberOfStudyRelatedSeries;
         adaptee.NumberOfRelatedStudies = string.Empty;
         adaptee.Sex = model.PatientSex;

         return adaptee;
      }
      internal static StudyData ReadStudyData(WadoDataSetModel model)
      {
         var adaptee = new StudyData();

         adaptee.AccessionNumber = model.AccessionNumber;
         //adaptee.AdditionalPatientHistory 
         //adaptee.AdmittingDiagnosesDescription 
         //adaptee.Age 
         adaptee.Date = model.StudyDate;
         adaptee.Description = model.StudyDescription;
         //adaptee.Id 
         adaptee.InstanceUID = model.StudyInstanceUID;
         adaptee.ModalitiesInStudy = new string[] { model.Modality };
         //adaptee.NameOfDoctorsReading = 
         //adaptee.NumberOfRelatedInstances = 
         //adaptee.NumberOfRelatedSeries = 
         adaptee.Patient = new PatientData();
         adaptee.Patient.BirthDate = model.PatientBirthDate;
         //adaptee.Patient.Comments 
         //adaptee.Patient.EthnicGroup 
         adaptee.Patient.ID = model.PatientID;
         adaptee.Patient.Name = model.PatientName;
         adaptee.Patient.NumberOfRelatedInstances = model.NumberOfStudyRelatedInstances;
         adaptee.Patient.NumberOfRelatedSeries = model.NumberOfStudyRelatedSeries;
         //adaptee.Patient.NumberOfRelatedStudies 
         adaptee.Patient.Sex = model.PatientSex;

         //adaptee.ReferringPhysiciansName 
         //adaptee.Size =
         //adaptee.Weight = 

         return adaptee;
      }
      internal static SeriesData ReadSeriesData(WadoDataSetModel model)
      {
         var adaptee = new SeriesData();

         adaptee.CompleteMRTI = false;
         adaptee.Date = model.SeriesDate;
         adaptee.Description = model.SeriesDescription;
         adaptee.InstanceUID = model.SeriesInstanceUID;
         adaptee.Modality = model.Modality;
         adaptee.Number = model.SeriesNumber;
         adaptee.NumberOfRelatedInstances = model.NumberOfInstances;
         adaptee.Patient = new PatientData();
         adaptee.Patient.BirthDate = model.PatientBirthDate;
         //adaptee.Patient.Comments 
         //adaptee.Patient.EthnicGroup 
         adaptee.Patient.ID = model.PatientID;
         adaptee.Patient.Name = model.PatientName;
         adaptee.Patient.NumberOfRelatedInstances = model.NumberOfStudyRelatedInstances;
         adaptee.Patient.NumberOfRelatedSeries = model.NumberOfStudyRelatedSeries;
         
         //adaptee.Patient.NumberOfRelatedStudies 

         adaptee.SopInstanceUIDs = new List<string>() { model.SOPInstanceUID };
         adaptee.StudyInstanceUID = model.StudyInstanceUID;

         return adaptee;
      }

      internal static WadoDataSetModel ReadQueryOptions(QueryOptions query)
      {
         var model = new WadoDataSetModel();

         if (null != query)
         {
            if (null != query.PatientsOptions)
            {
               model.PatientBirthDate = query.PatientsOptions.BirthDate;
               //query.PatientsOptions.Comments;
               //query.PatientsOptions.EthnicGroup;
               model.PatientID = query.PatientsOptions.PatientID;
               model.PatientName = query.PatientsOptions.PatientName;
               model.PatientSex = query.PatientsOptions.Sex;
            }
            if (null != query.StudiesOptions)
            {
               model.AccessionNumber = query.StudiesOptions.AccessionNumber;
               if (null != query.StudiesOptions.ModalitiesInStudy && query.StudiesOptions.ModalitiesInStudy.Length > 0)
               {
                  model.Modality = query.StudiesOptions.ModalitiesInStudy[0];
               }
               //query.StudiesOptions.ReferDoctorName 
               //query.StudiesOptions.StudyDateEnd;
               model.StudyDate = query.StudiesOptions.StudyDateStart;
               model.StudyInstanceUID = query.StudiesOptions.StudyInstanceUID;
               //query.StudiesOptions.StudyTimeEnd
               //query.StudiesOptions.StudyTimeStart;
            }
            if (null != query.SeriesOptions)
            {
               if (string.IsNullOrEmpty(model.Modality))
                  model.Modality = query.SeriesOptions.Modality;
               //query.SeriesOptions.SeriesDateEnd
               model.SeriesDate = query.SeriesOptions.SeriesDateStart;
               model.SeriesDescription = query.SeriesOptions.SeriesDescription;
               model.SeriesInstanceUID = query.SeriesOptions.SeriesInstanceUID;
               model.SeriesNumber = query.SeriesOptions.SeriesNumber;
            }
            if (null != query.InstancesOptions)
            {
               model.InstanceNumber = query.InstancesOptions.InstanceNumber;
               model.SOPInstanceUID = query.InstancesOptions.SOPInstanceUID;
            }
         }

         return model;
      }
   }
}

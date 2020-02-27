// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Leadtools.Dicom;
using System.Data;
using Leadtools.Medical.Storage.DataAccessLayer;
using Leadtools.Medical.Storage.DataAccessLayer.Interface;
using Leadtools.Dicom.Common.Extensions;

namespace My.Medical.Storage.DataAccessLayer
{
   /// <summary>
   /// Implements the IStudyInfo interface to extract DICOM data from a System.Data.DataRow
   /// </summary>
   public  class MyStudyInfo : IStudyInfo
   {
      #region IStudyInfo Members

      public string GetElementValue(DataRow row, long dicomTag)
      {
         string ret = string.Empty;

         switch (dicomTag)
         {
            case DicomTag.StudyInstanceUID:
               ret = row["StudyStudyInstanceUID"] as string;
               break;

            case DicomTag.StudyDate:
               ret = row.GetDateString("StudyStudyDate");
               break;

            case DicomTag.AccessionNumber:
               ret = row["StudyAccessionNumber"] as string;
               break;

            case DicomTag.StudyDescription:
               ret = row["StudyStudyDescription"] as string;
               break;

            case DicomTag.ReferringPhysicianName:
               ret = row["StudyReferringPhysiciansName"] as string;
               break;

            case DicomTag.StudyID:
               ret = row["StudyStudyId"] as string;
               break;

            case DicomTag.PatientID:
               {
                  DataRow patientRow = GetPatientRow(row);
                  if (patientRow != null)
                  {
                     ret = patientRow["PatientIdentification"] as string;
                  }
               }
            break;

           case DicomTag.PatientName:
               {
                  DataRow patientRow = GetPatientRow(row);
                  if (patientRow != null)
                  {
                     ret = patientRow["PatientName"] as string;
                  }
               }
            break;

            case DicomTag.AdmittingDiagnosesDescription:
            case DicomTag.PatientAge:
            case DicomTag.PatientSize:
            case DicomTag.PatientWeight:
               ret = string.Empty;
               break;

            default:
               Console.WriteLine(string.Format("MyStudyInfo.GetElementValue: Invalid Dicom Tag: {0}", dicomTag.DicomTagToString()));
               ret = string.Empty;
               break;

            // ReceiveDate
            // RetrieveAETitle
         }
         return ret;
      }


      public DataRow GetPatientRow(DataRow studyRow)
      {
         return ((studyRow.GetParentRow(studyRow.Table.ParentRelations["FK_Study_Patient"])));
      }

      public PersonNameComponent ReferringPhysiciansName(DataRow row)
      {
         string name = row["StudyReferringPhysiciansName"] as string;
         PersonNameComponent []personName = DicomDataSetConverter.GetPersonNameComponents(name);
         return personName[0];
      }

      #endregion
   }
}

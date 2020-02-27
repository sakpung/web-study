// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Leadtools.Medical.Storage.DataAccessLayer.Interface;
using System.Data;
using Leadtools.Dicom;
using Leadtools.Medical.Storage.DataAccessLayer;
using Leadtools.Dicom.Common.Extensions;

namespace My.Medical.Storage.DataAccessLayer
{
   /// <summary>
   /// Implements the IPatientInfo interface to extract DICOM data from a System.Data.DataRow
   /// </summary>
   public  class MyPatientInfo : IPatientInfo
   {
      public string GetElementValue(DataRow row, long dicomTag)
      {
         string ret = string.Empty;

         switch (dicomTag)
         {
            case DicomTag.PatientID:
               ret = row["PatientIdentification"] as string;
               break;

            case DicomTag.PatientBirthDate:
               ret = row.GetDateString("PatientBirthday");
               break;

            case DicomTag.PatientSex:
               ret = row["PatientSex"] as string;
               break;
            case DicomTag.PatientComments:
               ret = row["PatientComments"] as string;
               break;

            default:
               Console.WriteLine(string.Format("MyPatientInfo.GetElementValue: Invalid Dicom Tag: {0}", dicomTag.DicomTagToString()));
               ret = string.Empty;
               break;

            // ReceiveDate
            // RetrieveAETitle
         }
         return ret;
      }
         

      public PersonNameComponent Name(DataRow row)
      {
         string patientName = row["PatientName"] as string;
         PersonNameComponent[] pn = DicomDataSetConverter.GetPersonNameComponents(patientName);
         return pn[0];
      }
   }
}

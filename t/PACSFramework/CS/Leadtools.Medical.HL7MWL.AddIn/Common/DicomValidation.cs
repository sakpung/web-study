// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leadtools.Medical.HL7MWL.AddIn
{
   public static class DicomValidation
   {
      public static bool IsValidPatientSex(string patientSex)
      {
         if (string.IsNullOrEmpty(patientSex))
            return false;
         patientSex = patientSex.ToUpper();
         return (patientSex == "M" || patientSex == "F" || patientSex == "O");
      }
      public static bool IsValidModality(string modality)
      {
         if (string.IsNullOrEmpty(modality))
            return false;
         modality = modality.ToUpper();
         return _modalities.Exists(m => m == modality);
      }

      private static readonly List<string> _modalities = new List<string>(){
      "AR",
      "AS",
      "AU",
      "BDUS",
      "BI",
      "BMD",
      "CD",
      "CF",
      "CP",
      "CR",
      "CS",
      "CT",
      "DD",
      "DF",
      "DG",
      "DM",
      "DOC",
      "DS",
      "DX",
      "EC",
      "ECG",
      "EPS",
      "ES",
      "FA",
      "FID",
      "FS",
      "GM",
      "HC",
      "HD",
      "IO",
      "IVUS",
      "KER",
      "KO",
      "LEN",
      "LP",
      "LS",
      "MA",
      "MG",
      "MR",
      "MS",
      "NM",
      "OAM",
      "OCT",
      "OP",
      "OPM",
      "OPR",
      "OPT",
      "OPV",
      "OT",
      "PR",
      "PT",
      "PX",
      "REG",
      "RESP",
      "RF",
      "RG",
      "RTDOSE",
      "RTIMAGE",
      "RTPLAN",
      "RTRECORD",
      "RTSTRUCT",
      "SEG",
      "SM",
      "SMR",
      "SR",
      "SRF",
      "ST",
      "TG",
      "US",
      "VA",
      "VF",
      "XA",
      "XC"};
   }
}

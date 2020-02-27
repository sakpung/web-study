// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
namespace Leadtools.Medical.WebViewer.Services.Interfaces
{

   public interface IPatientHandler
   {
      bool UpdatePatient(string authenticationCookie, PatientInfo_Json info);

      bool AddPatient(string authenticationCookie, PatientInfo_Json info, string userData);
      bool DeletePatient(string patientId);
   }
}

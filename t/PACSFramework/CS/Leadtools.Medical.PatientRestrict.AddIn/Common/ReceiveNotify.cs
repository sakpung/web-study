// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************

using Leadtools.Dicom;
using Leadtools.Dicom.AddIn;
using Leadtools.Logging;
using System.Collections.Generic;

namespace Leadtools.Medical.PatientRestrict.AddIn
{
   public class ReceiveNotify : NotifyReceiveMessageBase
   {
      public override void OnReceiveCStoreRequest(DicomClient Client, byte presentationID, int messageID, string affectedClass, string instance, DicomCommandPriorityType priority, string moveAE, int moveMessageID, DicomDataSet dataSet)
      {
         if (Module.Options.PatientRestrictEnabled)
         {
            string patientId = dataSet.GetValue<string>(DicomTag.PatientID, string.Empty);
            string aeTitle = Client.AETitle;
            string message = string.Format("OnReceiveCStoreRequest: PatientID[{0}], AeTitle[{1}]", patientId, aeTitle);
            Logger.Global.SystemMessage(LogType.Information, message);

            if (!string.IsNullOrEmpty(patientId))
            {
               List<string> rolesList = Module.PatientRightsDataAccess.GetAeRoles(aeTitle);

               foreach (string role in rolesList)
               {
                  message = string.Format("PatientID[{0}], Role[{1}]", patientId, role);
                  Logger.Global.SystemMessage(LogType.Information, message);

                  Module.PatientRightsDataAccess.GrantRoleAccess(patientId, role);
               }
            }
         }
      }
   }
}

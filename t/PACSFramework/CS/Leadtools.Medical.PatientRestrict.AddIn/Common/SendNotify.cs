// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************

using Leadtools.Dicom;
using Leadtools.Dicom.AddIn;

namespace Leadtools.Medical.PatientRestrict.AddIn
{
   public class SendNotify : NotifySendMessageBase
   {
      public override void OnSendCStoreResponse(DicomClient Client, byte presentationID, int messageID, string affectedClass, string instance, DicomCommandStatusType status)
      {
         base.OnSendCStoreResponse(Client, presentationID, messageID, affectedClass, instance, status);
      }
   }
}

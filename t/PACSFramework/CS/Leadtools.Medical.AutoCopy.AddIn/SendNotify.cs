// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Leadtools.Dicom.AddIn;
using Leadtools.Dicom;
using Leadtools.Medical.AutoCopy.AddIn.Queue;

namespace Leadtools.Medical.AutoCopy.AddIn
{
   public class SendNotify : NotifySendMessageBase
   {       
      public override void OnSendCStoreRequest(DicomClient Client, byte presentationID, int messageID, string affectedClass, string instance, DicomCommandPriorityType priority, string moveAE, int moveMessageID, DicomDataSet dataSet)
      {
         if (!Module.Options.EnableAutoCopy)
            return;
         AutoCopyEngine.AddDataset(moveAE, instance);
      }

      public override void OnSendCMoveResponse(DicomClient Client, byte presentationID, int messageID, string affectedClass, 
                                               DicomCommandStatusType status, int remaining, int completed, int failed, 
                                               int warning, DicomDataSet dataset)
      {
         if (!Module.Options.EnableAutoCopy)
            return;

         //
         // Only do auto copy if the move command was successfull
         //
         if (status == DicomCommandStatusType.Success)
         {
            string key = Client.HostAddress + Client.HostPort.ToString();

            if (AutoCopyEngine.MoveRequests.ContainsKey(key))
            {
               string ae = AutoCopyEngine.MoveRequests[key];

               AutoCopyEngine.QueueDatasets(ae);
            }
         }
      }
   }
}

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

namespace Leadtools.Medical.AutoCopy.AddIn
{
   public class ReceiveNotify : NotifyReceiveMessageBase
   {
      public override void OnReceiveCMoveRequest(DicomClient Client, byte presentationID, int messageID, string affectedClass, DicomCommandPriorityType priority, string moveAE, DicomDataSet dataSet)
      {
         if (!Module.Options.EnableAutoCopy)
            return;
         //
         // Add the move ae title to our global list
         //
         AutoCopyEngine.AddAeTitle(moveAE,Client.Server.AETitle);
         AutoCopyEngine.MoveRequests[Client.HostAddress+Client.HostPort.ToString()] = moveAE;
      }

      public override void OnReceiveCStoreResponse(DicomClient Client, byte presentationID, int messageID, string affectedClass, string instance, DicomCommandStatusType status)
      {
         if (!Module.Options.EnableAutoCopy)
            return;

         //
         // Only add to the engine if the store operation was successfull
         //
         if (status != DicomCommandStatusType.Success)
         {
            string key = Client.HostAddress + Client.HostPort.ToString();

            if (AutoCopyEngine.MoveRequests.ContainsKey(key))
            {
               string ae = AutoCopyEngine.MoveRequests[key];

               AutoCopyEngine.RemoveDataset(ae, instance);
            }
         }
      }
   }
}

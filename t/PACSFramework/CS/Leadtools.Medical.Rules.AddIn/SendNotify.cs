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
using Leadtools.Medical.Rules.AddIn;
using Leadtools.Logging;

namespace Leadtools.Medical.Rules.AddIn
{
   public class SendNotify : NotifySendMessageBase
   {
      public override void OnSendAssociateRequest(DicomClient Client, DicomAssociate associate)
      {
         Module.ScriptProcessor.RunScripts(ServerEvent.SendAssociateRequest, Client, associate);
      }
      public override void OnSendAssociateReject(DicomClient Client, DicomAssociateRejectResultType result, DicomAssociateRejectSourceType source, DicomAssociateRejectReasonType reason)
      {
         Module.ScriptProcessor.RunScripts(ServerEvent.SendAssociateReject, Client, result, source, reason);
      }

      public override void OnSendAssociateAccept(DicomClient Client, DicomAssociate associate)
      {
         Module.ScriptProcessor.RunScripts(ServerEvent.SendAssociateAccept, Client, associate);
      }

      public override void OnSendCFindResponse(DicomClient Client, byte presentationID, int messageID, string affectedClass, DicomCommandStatusType status, DicomDataSet dataset)
      {
         Module.ScriptProcessor.RunScripts(ServerEvent.SendCFindResponse, Client, presentationID, messageID, affectedClass, status, new DicomDS(dataset));
      }
      public override void OnSendCStoreResponse(DicomClient Client, byte presentationID, int messageID, string affectedClass, string instance, DicomCommandStatusType status)
      {
         Module.ScriptProcessor.RunScripts(ServerEvent.SendCStoreResponse, Client, presentationID, messageID, affectedClass, instance, status);
      }

      public override void OnSendCEchoResponse(DicomClient Client, byte presentationID, int messageID, string affectedClass, DicomCommandStatusType status)
      {
         Module.ScriptProcessor.RunScripts(ServerEvent.SendCEchoResponse, Client, presentationID, messageID, affectedClass, status);
      }

      public override void OnSendCGetResponse(DicomClient Client, byte presentationID, int messageID, string affectedClass, DicomCommandStatusType status, int remaining, int completed, int failed, int warning, DicomDataSet dataset)
      {
         Module.ScriptProcessor.RunScripts(ServerEvent.SendCGetResponse, Client, presentationID, messageID, affectedClass, status, remaining, completed, failed, warning, new DicomDS(dataset));
      }

      public override void OnSendCMoveResponse(DicomClient Client, byte presentationID, int messageID, string affectedClass, DicomCommandStatusType status, int remaining, int completed, int failed, int warning, DicomDataSet dataset)
      {
         Module.ScriptProcessor.RunScripts(ServerEvent.SendCMoveResponse, Client, presentationID, messageID, affectedClass, status, remaining, completed, failed, warning, new DicomDS(dataset));
      }

      public override void OnSendNActionResponse(DicomClient Client, byte presentationID, int messageID, string affectedClass, string instance, DicomCommandStatusType status, int action, DicomDataSet dataset)
      {
         Module.ScriptProcessor.RunScripts(ServerEvent.SendNActionResponse, Client, presentationID, messageID, affectedClass, instance, status, action, new DicomDS(dataset));
      }

      public override void OnSendNCreateResponse(DicomClient Client, byte presentationID, int messageID, string affectedClass, string instance, DicomCommandStatusType status, DicomDataSet dataset)
      {
         Module.ScriptProcessor.RunScripts(ServerEvent.SendNCreateResponse, Client, presentationID, messageID, affectedClass, instance, status, new DicomDS(dataset));
      }

      public override void OnSendNDeleteResponse(DicomClient Client, byte presentationID, int messageID, string affectedClass, string instance, DicomCommandStatusType status)
      {
         Module.ScriptProcessor.RunScripts(ServerEvent.SendNDeleteResponse, Client, presentationID, messageID, affectedClass, instance, status);
      }

      public override void OnSendNGetResponse(DicomClient Client, byte presentationID, int messageID, string affectedClass, string instance, DicomCommandStatusType status, DicomDataSet dataset)
      {
         Module.ScriptProcessor.RunScripts(ServerEvent.SendNGetResponse, Client, presentationID, messageID, affectedClass, instance, status, new DicomDS(dataset));
      }

      public override void OnSendNReportResponse(DicomClient Client, byte presentationID, int messageID, string affectedClass, string instance, DicomCommandStatusType status, int dicomEvent, DicomDataSet dataset)
      {
         Module.ScriptProcessor.RunScripts(ServerEvent.SendNReportResponse, Client, presentationID, messageID, affectedClass, instance, status, dicomEvent, new DicomDS(dataset));
      }

      public override void OnSendNSetResponse(DicomClient Client, byte presentationID, int messageID, string affectedClass, string instance, DicomCommandStatusType status, DicomDataSet dataset)
      {
          Module.ScriptProcessor.RunScripts(ServerEvent.SendNSetResponse, Client, presentationID, messageID, affectedClass, instance, status, new DicomDS(dataset));
      }

      public override void OnSendReleaseResponse(DicomClient Client)
      {
         Module.ScriptProcessor.RunScripts(ServerEvent.SendReleaseResponse, Client);
      }      

      public override void OnSendCCancelRequest(DicomClient Client, byte presentationID, int messageID)
      {
         Module.ScriptProcessor.RunScripts(ServerEvent.SendCCancelRequest, Client, presentationID, messageID);
      }

      public override void OnSendCStoreRequest(DicomClient Client, byte presentationID, int messageID, string affectedClass, string instance, DicomCommandPriorityType priority, string moveAE, int moveMessageID, DicomDataSet dataSet)
      {
         Module.ScriptProcessor.RunScripts(ServerEvent.SendCStoreRequest, presentationID, messageID, affectedClass, instance, priority, moveAE, moveMessageID, new DicomDS(dataSet));
      }

      public override void OnSendNReportRequest(DicomClient Client, byte presentationID, int messageID, string affectedClass, string instance, int dicomEvent, DicomDataSet dataSet)
      {
         Module.ScriptProcessor.RunScripts(ServerEvent.SendNReportRequest, presentationID, messageID, affectedClass, instance, dicomEvent, new DicomDS(dataSet));
      }
   }
}

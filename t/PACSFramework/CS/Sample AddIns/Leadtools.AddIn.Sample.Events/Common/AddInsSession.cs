// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using Leadtools;
using Leadtools.Dicom;
using Leadtools.Dicom.AddIn;


namespace Leadtools.Sample.Events.Addin
{
   public class SendNotify : NotifySendMessageBase
   {
      public override void OnBeforeSendAssociateAccept(DicomClient Client, DicomAssociate associateRequest, DicomAssociate associateAccept)
      {
         //The code below shows how to handle role selection
         // In this example, the SCP accepts all proposed role selections
         //
         //for (byte i = 0; i< associateRequest.PresentationContextCount; i++)
         //{
         //   byte pid = associateRequest.GetPresentationContextID(i);
         //   bool isRoleSelect = associateRequest.IsRoleSelect(pid);
         //   if (isRoleSelect)
         //   {
         //      DicomRoleSupport userRole = associateRequest.GetUserRole(pid);
         //      DicomRoleSupport providerRole = associateRequest.GetProviderRole(pid);
         //      associateAccept.SetRoleSelect(pid, true, userRole, providerRole);
         //   }
         //}
         base.OnBeforeSendAssociateAccept(Client, associateRequest, associateAccept);
      }

      // You can receive any of the events below as well
      public override void OnBeforeSend(DicomClient Client, DicomExceptionCode error, DicomPduType type, int length)
      {
         // View or change parameters
         base.OnBeforeSend(Client, error, type, length);
      }

      public override void OnBeforeSendAbort(DicomClient Client, DicomAbortSourceType source, DicomAbortReasonType reason)
      {
         // View or change parameters
         base.OnBeforeSendAbort(Client, source, reason);
      }
      public override void OnBeforeSendAssociateReject(DicomClient Client, DicomAssociateRejectResultType result, DicomAssociateRejectSourceType source, DicomAssociateRejectReasonType reason)
      {
         // View or change parameters
         base.OnBeforeSendAssociateReject(Client, result, source, reason);
      }

      public override void OnBeforeSendAssociateRequest(DicomClient Client, DicomAssociate associate)
      {
         // View or change parameters
         base.OnBeforeSendAssociateRequest(Client, associate);
      }

      public override void OnBeforeSendCCancelRequest(DicomClient Client, byte presentationID, int messageID)
      {
         // View or change parameters
         base.OnBeforeSendCCancelRequest(Client, presentationID, messageID);
      }

      public override void OnBeforeSendCEchoRequest(DicomClient Client, byte presentationID, int messageID, string affectedClass)
      {
         // View or change parameters
         base.OnBeforeSendCEchoRequest(Client, presentationID, messageID, affectedClass);
      }

      public override void OnBeforeSendCEchoResponse(DicomClient Client, byte presentationID, int messageID, string affectedClass, DicomCommandStatusType status)
      {
         // View or change parameters
         base.OnBeforeSendCEchoResponse(Client, presentationID, messageID, affectedClass, status);
      }

      public override void OnBeforeSendCFindRequest(DicomClient Client, byte presentationID, int messageID, string affectedClass, DicomCommandPriorityType priority, DicomDataSet dataSet)
      {
         // View or change parameters
         base.OnBeforeSendCFindRequest(Client, presentationID, messageID, affectedClass, priority, dataSet);
      }

      public override void OnBeforeSendCFindResponse(DicomClient Client, byte presentationID, int messageID, string affectedClass, DicomCommandStatusType status, DicomDataSet dataset)
      {
         // View or change parameters
         base.OnBeforeSendCFindResponse(Client, presentationID, messageID, affectedClass, status, dataset);
      }

      public override void OnBeforeSendCGetRequest(DicomClient Client, byte presentationID, int messageID, string affectedClass, DicomCommandPriorityType priority, DicomDataSet dataSet)
      {
         // View or change parameters
         base.OnBeforeSendCGetRequest(Client, presentationID, messageID, affectedClass, priority, dataSet);
      }

      public override void OnBeforeSendCGetResponse(DicomClient Client, byte presentationID, int messageID, string affectedClass, DicomCommandStatusType status, int remaining, int completed, int failed, int warning, DicomDataSet dataset)
      {
         // View or change parameters
         base.OnBeforeSendCGetResponse(Client, presentationID, messageID, affectedClass, status, remaining, completed, failed, warning, dataset);
      }

      public override void OnBeforeSendCMoveRequest(DicomClient Client, byte presentationID, int messageID, string affectedClass, DicomCommandPriorityType priority, string moveAE, DicomDataSet dataSet)
      {
         // View or change parameters
         base.OnBeforeSendCMoveRequest(Client, presentationID, messageID, affectedClass, priority, moveAE, dataSet);
      }

      public override void OnBeforeSendCMoveResponse(DicomClient Client, byte presentationID, int messageID, string affectedClass, DicomCommandStatusType status, int remaining, int completed, int failed, int warning, DicomDataSet dataset)
      {
         // View or change parameters
         base.OnBeforeSendCMoveResponse(Client, presentationID, messageID, affectedClass, status, remaining, completed, failed, warning, dataset);
      }

      public override void OnBeforeSendConnect(DicomClient Client, string hostAddress, int hostPort, string peerAddress, int peerPort)
      {
         // View or change parameters
         base.OnBeforeSendConnect(Client, hostAddress, hostPort, peerAddress, peerPort);
      }

      public override void OnBeforeSendCStoreRequest(DicomClient Client, byte presentationID, int messageID, string affectedClass, string instance, DicomCommandPriorityType priority, string moveAE, int moveMessageID, DicomDataSet dataSet)
      {
         // View or change parameters
         base.OnBeforeSendCStoreRequest(Client, presentationID, messageID, affectedClass, instance, priority, moveAE, moveMessageID, dataSet);
      }

      public override void OnBeforeSendCStoreResponse(DicomClient Client, byte presentationID, int messageID, string affectedClass, string instance, DicomCommandStatusType status)
      {
         // View or change parameters
         base.OnBeforeSendCStoreResponse(Client, presentationID, messageID, affectedClass, instance, status);
      }

      public override void OnBeforeSendNActionRequest(DicomClient Client, byte presentationID, int messageID, string affectedClass, string instance, int action, DicomDataSet dataSet)
      {
         // View or change parameters
         base.OnBeforeSendNActionRequest(Client, presentationID, messageID, affectedClass, instance, action, dataSet);
      }

      public override void OnBeforeSendNActionResponse(DicomClient Client, byte presentationID, int messageID, string affectedClass, string instance, DicomCommandStatusType status, int action, DicomDataSet dataset)
      {
         // View or change parameters
         base.OnBeforeSendNActionResponse(Client, presentationID, messageID, affectedClass, instance, status, action, dataset);
      }

      public override void OnBeforeSendNCreateRequest(DicomClient Client, byte presentationID, int messageID, string affectedClass, string instance, DicomDataSet dataSet)
      {
         // View or change parameters
         base.OnBeforeSendNCreateRequest(Client, presentationID, messageID, affectedClass, instance, dataSet);
      }

      public override void OnBeforeSendNCreateResponse(DicomClient Client, byte presentationID, int messageID, string affectedClass, string instance, DicomCommandStatusType status, DicomDataSet dataset)
      {
         // View or change parameters
         base.OnBeforeSendNCreateResponse(Client, presentationID, messageID, affectedClass, instance, status, dataset);
      }

      public override void OnBeforeSendNDeleteRequest(DicomClient Client, byte presentationID, int messageID, string affectedClass, string instance)
      {
         // View or change parameters
         base.OnBeforeSendNDeleteRequest(Client, presentationID, messageID, affectedClass, instance);
      }

      public override void OnBeforeSendNDeleteResponse(DicomClient Client, byte presentationID, int messageID, string affectedClass, string instance, DicomCommandStatusType status)
      {
         // View or change parameters
         base.OnBeforeSendNDeleteResponse(Client, presentationID, messageID, affectedClass, instance, status);
      }

      public override void OnBeforeSendNGetRequest(DicomClient Client, byte presentationID, int messageID, string affectedClass, string instance, long[] attributes, int count)
      {
         // View or change parameters
         base.OnBeforeSendNGetRequest(Client, presentationID, messageID, affectedClass, instance, attributes, count);
      }

      public override void OnBeforeSendNGetResponse(DicomClient Client, byte presentationID, int messageID, string affectedClass, string instance, DicomCommandStatusType status, DicomDataSet dataset)
      {
         // View or change parameters
         base.OnBeforeSendNGetResponse(Client, presentationID, messageID, affectedClass, instance, status, dataset);
      }

      public override void OnBeforeSendNReportRequest(DicomClient Client, byte presentationID, int messageID, string affectedClass, string instance, int dicomEvent, DicomDataSet dataSet)
      {
         // View or change parameters
         base.OnBeforeSendNReportRequest(Client, presentationID, messageID, affectedClass, instance, dicomEvent, dataSet);
      }

      public override void OnBeforeSendNReportResponse(DicomClient Client, byte presentationID, int messageID, string affectedClass, string instance, DicomCommandStatusType status, int Event, DicomDataSet dataset)
      {
         // View or change parameters
         base.OnBeforeSendNReportResponse(Client, presentationID, messageID, affectedClass, instance, status, Event, dataset);
      }

      public override void OnBeforeSendNSetRequest(DicomClient Client, byte presentationID, int messageID, string affectedClass, string instance, DicomDataSet dataSet)
      {
         // View or change parameters
         base.OnBeforeSendNSetRequest(Client, presentationID, messageID, affectedClass, instance, dataSet);
      }

      public override void OnBeforeSendNSetResponse(DicomClient Client, byte presentationID, int messageID, string affectedClass, string instance, DicomCommandStatusType status, DicomDataSet dataset)
      {
         // View or change parameters
         base.OnBeforeSendNSetResponse(Client, presentationID, messageID, affectedClass, instance, status, dataset);
      }

      public override void OnBeforeSendReleaseResponse(DicomClient Client)
      {
         // View or change parameters
         base.OnBeforeSendReleaseResponse(Client);
      }

   }
}

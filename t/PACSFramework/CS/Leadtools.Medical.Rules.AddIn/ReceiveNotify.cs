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
using System.Runtime.CompilerServices;
using System.Reflection;
using Leadtools.Medical.Rules.AddIn.Scripting;
using Leadtools.Logging;

namespace Leadtools.Medical.Rules.AddIn
{   
   public class ReceiveNotify : NotifyReceiveMessageBase
   {
      public override void OnReceiveAssociateAccept(DicomClient Client, DicomAssociate association)
      {
         Module.ScriptProcessor.RunScripts(ServerEvent.ReceiveAssociateAccept, Client, association);
      }

      public override void OnReceiveAssociateReject(DicomClient Client, DicomAssociateRejectResultType result, DicomAssociateRejectSourceType source, DicomAssociateRejectReasonType reason)
      {
         Module.ScriptProcessor.RunScripts(ServerEvent.ReceiveAssociateReject, Client, result, source, reason);
      }
      
      public override void OnReceiveAssociateRequest(DicomClient Client, DicomAssociate association)
      {
         Module.ScriptProcessor.RunScripts(ServerEvent.ReceiveAssociateRequest, Client, association);
      }

      public override void OnReceiveCCancelRequest(DicomClient Client, byte presentationID, int messageID)
      {
         Module.ScriptProcessor.RunScripts(ServerEvent.ReceiveCCancelRequest, Client, presentationID, messageID);
      }

      public override void OnReceiveCEchoRequest(DicomClient Client, byte presentationID, int messageID, string affectedClass)
      {
         Module.ScriptProcessor.RunScripts(ServerEvent.ReceiveCEchoRequest, Client, presentationID, messageID, affectedClass);
      }

      public override void OnReceiveCFindRequest(DicomClient Client, byte presentationID, int messageID, string affectedClass, DicomCommandPriorityType priority, DicomDataSet dataSet)
      {
         Module.ScriptProcessor.RunScripts(ServerEvent.ReceiveCFindRequest, Client, presentationID, messageID, affectedClass, priority, new DicomDS(dataSet));
      }
      
      public override void OnReceiveCStoreRequest(DicomClient Client, byte presentationID, int messageID, string affectedClass, string instance, DicomCommandPriorityType priority, string moveAE, int moveMessageID, DicomDataSet dataSet)
      {
         Module.ScriptProcessor.RunScripts(ServerEvent.ReceiveCStoreRequest, Client, presentationID, messageID, affectedClass, instance, priority, moveAE, moveMessageID, new DicomDS(dataSet));
      }

      public override void OnReceiveCGetRequest(DicomClient Client, byte presentationID, int messageID, string affectedClass, DicomCommandPriorityType priority, DicomDataSet dataSet)
      {
         Module.ScriptProcessor.RunScripts(ServerEvent.ReceiveCGetRequest, Client, presentationID, messageID, affectedClass, priority, new DicomDS(dataSet));
      }

      public override void OnReceiveCMoveRequest(DicomClient Client, byte presentationID, int messageID, string affectedClass, DicomCommandPriorityType priority, string moveAE, DicomDataSet dataSet)
      {
         Module.ScriptProcessor.RunScripts(ServerEvent.ReceiveCMoveRequest, Client, presentationID, messageID, affectedClass, priority, moveAE, new DicomDS(dataSet));
      }

      public override void OnReceiveNActionRequest(DicomClient Client, byte presentationID, int messageID, string affectedClass, string instance, int action, DicomDataSet dataSet)
      {
         Module.ScriptProcessor.RunScripts(ServerEvent.ReceiveNActionRequest, Client, presentationID, messageID, affectedClass, instance, action, new DicomDS(dataSet));
      }

      public override void OnReceiveNCreateRequest(DicomClient Client, byte presentationID, int messageID, string affectedClass, string instance, DicomDataSet dataSet)
      {
         Module.ScriptProcessor.RunScripts(ServerEvent.ReceiveNCreateRequest, Client, presentationID, messageID, affectedClass, instance, new DicomDS(dataSet));
      }

      public override void OnReceiveNDeleteRequest(DicomClient Client, byte presentationID, int messageID, string affectedClass, string instance)
      {
         Module.ScriptProcessor.RunScripts(ServerEvent.ReceiveNDeleteRequest, Client, presentationID, messageID, affectedClass, instance);
      }

      public override void OnReceiveNGetRequest(DicomClient Client, byte presentationID, int messageID, string affectedClass, string instance, long[] attributes)
      {
         Module.ScriptProcessor.RunScripts(ServerEvent.ReceiveNGetRequest, Client, presentationID, messageID, affectedClass, instance, attributes);
      }

      public override void OnReceiveNReportRequest(DicomClient Client, byte presentationID, int messageID, string affectedClass, string instance, int dicomEvent, DicomDataSet dataSet)
      { 
         Module.ScriptProcessor.RunScripts(ServerEvent.ReceiveNReportRequest, Client, presentationID, messageID, affectedClass, instance, dicomEvent, new DicomDS(dataSet));
      }

      public override void OnReceiveNSetRequest(DicomClient Client, byte presentationID, int messageID, string affectedClass, string instance, DicomDataSet dataSet)
      {
         Module.ScriptProcessor.RunScripts(ServerEvent.ReceiveNSetRequest, Client, presentationID, messageID, affectedClass, instance, new DicomDS(dataSet));
      }

      public override void OnReceiveReleaseRequest(DicomClient Client)
      {
         Module.ScriptProcessor.RunScripts(ServerEvent.ReceiveReleaseRequest, Client);
      }

      public override void OnReceiveCStoreResponse(DicomClient Client, byte presentationID, int messageID, string affectedClass, string instance, DicomCommandStatusType status)
      {
         Module.ScriptProcessor.RunScripts(ServerEvent.ReceiveCStoreResponse, Client, presentationID, messageID, affectedClass, instance, status);         
      }
   }
}

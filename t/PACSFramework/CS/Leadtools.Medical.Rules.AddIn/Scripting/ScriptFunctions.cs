// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Leadtools.Dicom.AddIn;
using System.Reflection;

namespace Leadtools.Medical.Rules.AddIn.Scripting
{
    public class ScriptFunctions
    {
       private static ThreadSafeDictionary<ServerEvent, string> _Functions = new ThreadSafeDictionary<ServerEvent, string>();
                              
       public const string ReceiveCFindRequest = "(Client as DicomClient, presentationID as Byte, messageID as Integer, affectedClass as String, priority as DicomCommandPriorityType, request as DicomDS)";
       public const string ReceiveCStoreRequest = "(Client as DicomClient, presentationID as Byte, messageID as Integer, affectedClass as String, instanceUID as String, priority as DicomCommandPriorityType, moveAE as String, moveMessageID as Integer, request as DicomDS)";       
       public const string ReceiveCStoreResponse = "(Client as DicomClient, presentationID as Byte, messageID as Integer, affectedClass as String, instanceUID as String, status as DicomCommandStatusType)";
       public const string ReceiveCEchoRequest = "(Client as DicomClient, presentationID as Byte, messageID as Integer, affectedClass as String)";
       public const string ReceiveCGetRequest = ReceiveCFindRequest;
       public const string ReceiveCMoveRequest = "(Client as DicomClient, presentationID as Byte, messageID as Integer, affectedClass as String, priority as DicomCommandPriorityType, moveAE as String, request as DicomDS)";
       public const string ReceiveNActionRequest = "(Client as DicomClient, presentationID as Byte, messageID as Integer, affectedClass as String, instanceUID as String,action as Integer, request as DicomDS)";
       public const string ReceiveNDeleteRequest = "(Client as DicomClient, presentationID as Byte, messageID as Integer, affectedClass as String, instanceUID as String)";
       public const string ReceiveNGetRequest = "(Client as DicomClient, presentationID as Byte, messageID as Integer, affectedClass as String, instanceUID as String,attributes() as Long)";
       public const string ReceiveNReportRequest = "(Client as DicomClient, presentationID as Byte, messageID as Integer, affectedClass as String, instanceUID as String, dicomEvent as Integer, request as DicomDS)";
       public const string ReceiveNReportResponse = "(Client as DicomClient, presentationID as Byte, messageID as Integer, affectedClass as String, instanceUID as String, status as DicomCommandStatusType, dicomEvent as Integer, response as DicomDS)";
       public const string ReceiveNSetRequest = "(Client as DicomClient, presentationID as Byte, messageID as Integer, affectedClass as String, instanceUID as String, request as DicomDS)";
       public const string ReceiveNCreateRequest = ReceiveNSetRequest;       
       public const string ReceiveReleaseRequest = "(Client as DicomClient)";       
       public const string ReceiveCCancelRequest = "(Client as DicomClient, presentationID as Byte, messageID as Integer)";
       public const string ReceiveAssociateRequest = "(Client as DicomClient, association as DicomAssociate)";
       public const string ReceiveAssociateAccept = ReceiveAssociateRequest;
       public const string ReceiveAssociateReject = "(Client as DicomClient, result as DicomAssociateRejectResultType, source as DicomAssociateRejectSourceType, reason as DicomAssociateRejectReasonType)";

       public const string SendAssociateRequest = "(Client as DicomClient, associate as DicomAssociate)";
       public const string SendAssociateAccept = SendAssociateRequest;
       public const string SendAssociateReject = "(Client as DicomClient, result as DicomAssociateRejectResultType, source as DicomAssociateRejectSourceType, reason as DicomAssociateRejectReasonType)";
       public const string SendCFindResponse = "(Client as DicomClient, presentationID as Byte, messageID as Integer, affectedClass as String, status as DicomCommandStatusType, response as DicomDS)";
       public const string SendCStoreResponse = "(Client as DicomClient, presentationID as Byte, messageID as Integer, affectedClass as String, instanceUID as String,status as DicomCommandStatusType)";
       public const string SendCEchoResponse = "(Client as DicomClient, presentationID as Byte, messageID as Integer, affectedClass as String, status as DicomCommandStatusType)";
       public const string SendCGetResponse = "(Client as DicomClient, presentationID as Byte, messageID as Integer, affectedClass as String, instanceUID as String, status as DicomCommandStatusType,remaining as Integer, completed as Integer, failed as Integer, warning as Integer, response as DicomDS)";
       public const string SendCMoveResponse = "(Client as DicomClient, presentationID as Byte, messageID as Integer, affectedClass as String, status as DicomCommandStatusType,remaining as Integer, completed as Integer, failed as Integer, warning as Integer, response as DicomDS)";
       public const string SendCCancelRequest = ReceiveCCancelRequest;
       public const string SendCStoreRequest = ReceiveCStoreRequest;
       public const string SendNActionResponse = "(Client as DicomClient, presentationID as Byte, messageID as Integer, affectedClass as String, instanceUID as String, status as DicomCommandStatusType, action as integer, response as DicomDS)";
       public const string SendNCreateResponse = "(Client as DicomClient, presentationID as Byte, messageID as Integer, affectedClass as String, instanceUID as String, status as DicomCommandStatusType, response as DicomDS)";
       public const string SendNDeleteResponse = SendCStoreResponse;
       public const string SendNGetResponse = SendNCreateResponse;       
       public const string SendNReportResponse = "(Client as DicomClient, presentationID as Byte, messageID as Integer, affectedClass as String, instanceUID as String, status as DicomCommandStatusType, dicomEvent as Integer, response as DicomDS)";
       public const string SendNReportRequest = ReceiveNReportRequest;
       public const string SendNSetResponse = SendNCreateResponse;
       public const string SendReleaseResponse = "(Client as DicomClient)";

       /// <summary>
       /// Gets the script for the associated event.
       /// </summary>
       /// <param name="serverEvent">The server event to get the script for.</param>
       /// <returns>The script that represents the function that will be called as the entry point to user provided script.</returns>
       /// <remarks>
       /// To make the implementation easier each script constant is named for a ServerEvent enum.  This allows us to look up the constant using
       /// the name of the server event.  If the event is found it is cached so it can be used later without a reflection performance hit.
       /// </remarks>
       public static string GetScript(ServerEvent serverEvent)
       {
          if (!_Functions.ContainsKey(serverEvent))
          {
             FieldInfo field = typeof(ScriptFunctions).GetFields().Where(f => f.Name.ToLower() == serverEvent.ToString().ToLower()).FirstOrDefault();

             if (field == null)
                return string.Empty;

             _Functions[serverEvent] = field.GetValue(null).ToString();
          }
          return _Functions[serverEvent];
       }
    }
}

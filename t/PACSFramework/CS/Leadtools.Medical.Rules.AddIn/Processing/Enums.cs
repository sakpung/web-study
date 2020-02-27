// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace Leadtools.Medical.Rules.AddIn
{
   public enum ServerEvent
   {
      None,
      [Description("RECEIVE A-ASSOCIATE-REQ")]
      ReceiveAssociateRequest,
      [Description("RECEIVE A-ASSOCIATE-REJ")]
      ReceiveAssociateReject,
      [Description("RECEIVE A-ASSOCIATE-ACC")]
      ReceiveAssociateAccept,
      [Description("RECEIVE C-CANCEL-REQ")]
      ReceiveCCancelRequest,     
      [Description("RECEIVE C-ECHO-REQ")]
      ReceiveCEchoRequest,      
      [Description("RECEIVE C-FIND-REQ")]
      ReceiveCFindRequest,      
      [Description("RECEIVE C-GET-REQ")]
      ReceiveCGetRequest,      
      [Description("RECEIVE C-MOVE-REQ")]
      ReceiveCMoveRequest,      
      [Description("RECEIVE C-STORE-REQ")]
      ReceiveCStoreRequest,
      [Description("RECEIVE C-STORE-RSP")]
      ReceiveCStoreResponse,
      [Description("RECEIVE N-ACTION-REQ")]
      ReceiveNActionRequest,      
      [Description("RECEIVE N-CREATE-REQ")]
      ReceiveNCreateRequest,      
      [Description("RECEIVE N-DELETE-REQ")]
      ReceiveNDeleteRequest,     
      [Description("RECEIVE N-GET-REQ")]
      ReceiveNGetRequest,      
      [Description("RECEIVE N-SET-REQ")]
      ReceiveNSetRequest,      
      [Description("RECEIVE A-RELEASE-REQ")]
      ReceiveReleaseRequest,
      [Description("RECEIVE N-REPORT-REQ")]
      ReceiveNReportRequest,
      [Description("RECEIVE N-REPORT-RSP")]
      ReceiveNReportResponse,     
      [Description("SEND A-ASSOCIATE-REQ")]
      SendAssociateRequest,
      [Description("SEND A-ASSOCIATE-REJ")]
      SendAssociateReject,
      [Description("SEND A-ASSOCIATE-ACC")]
      SendAssociateAccept,
      [Description("SEND C-CANCEL-REQ")]
      SendCCancelRequest,            
      [Description("SEND C-ECHO-RSP")]
      SendCEchoResponse,      
      [Description("SEND C-FIND-RSP")]
      SendCFindResponse,      
      [Description("SEND C-GET-RSP")]
      SendCGetResponse,      
      [Description("SEND C-MOVE-RSP")]
      SendCMoveResponse,
      [Description("SEND C-STORE-REQ")]
      SendCStoreRequest,
      [Description("SEND C-STORE-RSP")]
      SendCStoreResponse,      
      [Description("SEND N-ACTION-RSP")]
      SendNActionResponse,      
      [Description("SEND N-CREATE-RSP")]
      SendNCreateResponse,      
      [Description("SEND N-DELETE-RSP")]
      SendNDeleteResponse,
      [Description("SEND N-GET-REQ")]      
      SendNGetResponse,      
      [Description("SEND N-SET-RSP")]
      SendNSetResponse,
      //[Description("SEND A-RELEASE-REQ")]
      //SendReleaseRequest,
      [Description("SEND N-REPORT-REQ")]
      SendNReportRequest,
      [Description("SEND N-REPORT-RSP")]
      SendNReportResponse,
      [Description("SEND A-RELEASE-RSP")]
      SendReleaseResponse,
   }
}

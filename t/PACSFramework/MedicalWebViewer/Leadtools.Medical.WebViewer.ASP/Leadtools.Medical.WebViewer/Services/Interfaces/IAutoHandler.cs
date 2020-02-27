// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using Leadtools.Medical.WebViewer.DataContracts;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Leadtools.Medical.WebViewer.Services.Interfaces
{
   public static class CmdTaskStatus
   {
      public const string Queued = "Queued";
      public const string Pulled = "Pulled";
      public const string Succeeded = "Succeeded";
      public const string Failed = "Failed";
      public const string Unknown = "Unknown";
   }

   public interface IAutoHandler
   {
      string Automate(string authenticationCookie);

      bool IsAutomated(string token);
      
      Task<string> QueueCommand(string token, string to, string name, string param);
      Task<List<Tuple<string, string, string>>> GetAndRemoveCommands(string token, string to);

      Task ReportCommandStatus(string token, string cmdId, string status, string message);

      Task<Tuple<string, string>> GetCommandStatus(string token, string cmdId);
      
      void Logout(string token, string reason);

      JObject DecodeRequest(string token, string protocol);
      bool IsProtocolAllowed(string protocol);
      bool HasReqExpired(JObject req);
   }
}

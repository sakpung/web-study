// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using Leadtools.Medical.HL7.V2x.Listener;
using Leadtools.Medical.HL7.V26.Messages;
using Leadtools.Medical.HL7.V2x.Utilities;
using Leadtools.Medical.HL7.V2x.Models;
using Leadtools.Medical.Worklist.DataAccessLayer.BusinessEntity;
using Leadtools.Logging;
using Leadtools.Logging.Medical;
using Leadtools.Dicom;
using System.Diagnostics;
using Leadtools.Medical.Worklist.DataAccessLayer;

namespace Leadtools.Medical.HL7MWL.AddIn
{
   public class HL7MWLRequest : HL7TxtRequest
   {
      public HL7MWLRequest(TcpClient PeerSocket)
         : base(PeerSocket)
      {

      }

      public override void OnHl7Message(MessageStructure ms)
      {
         string cmdDesc = "";

         try
         {
            var segments = MessageStructureConverter.MessageStructureToSegments(ms);
            var hl7 = HL7MessageAdapterFactory.Create(segments.Item1, segments.Item2);
            var cmd = MWLCommandsFactory.MapHL7ToMWLCommand(hl7, pps: false);

            cmdDesc = cmd.Desc();

            cmd.Execute();

            Logger.Global.Log("HL7MWL", null, string.Empty, -1, string.Empty, string.Empty, -1, DicomCommandType.Undefined, DateTime.Now, LogType.Information, MessageDirection.None,
               "Command(s) executed successfully (" + cmdDesc + ")", null, null);
         }
         catch (Exception ex)
         {
            var err = ex.Message;

            if(string.IsNullOrEmpty(cmdDesc))
               err += " while executing: (" + cmdDesc + ")";

            Logger.Global.Log("HL7MWL", null, string.Empty, -1, string.Empty, string.Empty, -1, DicomCommandType.Undefined, DateTime.Now, LogType.Error, MessageDirection.None,
               err, null, null);

            throw;
         }
      }
   }
}

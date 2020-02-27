// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Net.Sockets;
using Leadtools.Medical.HL7.V2x.Listener;
using Leadtools.Medical.HL7.V2x.Models;
using Leadtools.Dicom;
using Leadtools.Logging;
using Leadtools.Logging.Medical;

namespace Leadtools.Medical.HL7PatientUpdate.AddIn
{
   class HL7PatientUpdateRequest : HL7TxtRequest
   {
      public HL7PatientUpdateRequest(TcpClient PeerSocket)
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
            var cmd = PatientUpdateCommandsFactory.MapHL7ToPatientUpdateCommand(hl7);

            cmdDesc = cmd.Desc();

            cmd.Execute();

            Logger.Global.Log("HL7PatientUpdate", null, string.Empty, -1, string.Empty, string.Empty, -1, DicomCommandType.Undefined, DateTime.Now, LogType.Information, MessageDirection.None,
               "Command(s) executed successfully (" + cmdDesc + ")", null, null);
         }
         catch (Exception ex)
         {
            var err = ex.Message;

            if (string.IsNullOrEmpty(cmdDesc))
               err += " while executing: (" + cmdDesc + ")";

            Logger.Global.Log("HL7PatientUpdate", null, string.Empty, -1, string.Empty, string.Empty, -1, DicomCommandType.Undefined, DateTime.Now, LogType.Error, MessageDirection.None,
               err, null, null);

            throw;
         }
      }
   }
}

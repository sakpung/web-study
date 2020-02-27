// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Leadtools.Medical.Forward.DataAccessLayer;
using Leadtools.Dicom.Common.DataTypes;
using Leadtools.Logging;
using System.Diagnostics;

namespace Leadtools.Medical.Forwarder.AddIn.Processes
{
   public class ResetProcess
   {
      private string _ServerAE;
      private static object resetLock = new object();

      public ResetProcess(string ae)
      {
         _ServerAE = ae;
      }

      public void Run(IForwardDataAccessAgent forwardAgent, DateRange range)
      {
         lock (resetLock)
         {
            long count = forwardAgent.GetResetCount(range);
            string message = string.Format("[Forwarder] {0} {1} found to reset forward date", count, count == 1 ? "dataset" : "datasets");

            Logger.Global.SystemMessage(LogType.Debug, message, _ServerAE);
            if (count > 0)
            {
               forwardAgent.Reset(range);
               message = string.Format("[Forwarder] {0} {1} forward date successfully reset", count, count == 1 ? "dataset" : "datasets");
               Logger.Global.SystemMessage(LogType.Debug, message, _ServerAE);
            }
         }
      }
   }
}

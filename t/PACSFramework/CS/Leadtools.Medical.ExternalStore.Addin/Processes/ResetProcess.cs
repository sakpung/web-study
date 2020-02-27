// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using Leadtools.Medical.ExternalStore.DataAccessLayer;
using Leadtools.Dicom.Common.DataTypes;
using Leadtools.Logging;
using Leadtools.Dicom.Common.Extensions;

namespace Leadtools.Medical.ExternalStore.Addin.Processes
{
   public class ResetProcess
   {
      private readonly string _serviceName;
      private static readonly object resetLock = new object();

      public ResetProcess( string serviceName)
      {
         _serviceName = serviceName;
      }

      public void Run(IExternalStoreDataAccessAgent externalStoreAgent, DateRange range)
      {
         lock (resetLock)
         {
            DicomUtilities.DebugString(DebugStringOptions.ShowCounter, "ResetProcess.Run");
            long count = externalStoreAgent.GetResetCount(range);
            string message = string.Format("{0} {1} found to reset external store date", count, "dataset(s)");

            Logger.Global.SystemMessage(LogType.Information, message, _serviceName );
            if (count > 0)
            {
               externalStoreAgent.Reset(range);
               message = string.Format("{0} {1} external store date successfully reset", count, "dataset(s)");
               Logger.Global.SystemMessage(LogType.Information, message, _serviceName );
            }
         }
      }
   }
}

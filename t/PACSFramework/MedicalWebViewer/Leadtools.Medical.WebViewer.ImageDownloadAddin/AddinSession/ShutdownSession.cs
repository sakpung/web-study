// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Leadtools.Dicom.AddIn.Interfaces;
using Leadtools.Logging;
using Leadtools.Dicom;
using Leadtools.Logging.Medical;

namespace Leadtools.Medical.WebViewer.ImageDownloadAddin
{
   public class ShutdownSession : IProcessBreak
   {
      public void Break(BreakType type)
      {
         #region LOG
         {
            string message = @"Image Download - Session Break";
            Logger.Global.Log(string.Empty, string.Empty, -1, string.Empty, string.Empty, -1, DicomCommandType.Undefined, DateTime.Now,
                             LogType.Information, MessageDirection.None, message, null, null);
         }
         #endregion

         if (type == BreakType.Shutdown)
         {
            JobsService.ShutDown();
         }
      }
   }
}

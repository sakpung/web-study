// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Leadtools.Dicom.AddIn.Interfaces;
using Leadtools.Dicom.AddIn;
using Leadtools.Dicom;
using Leadtools.Dicom.Common.Extensions;
using Leadtools.Medical.WebViewer.Jobs;
using Leadtools.Logging;
using Leadtools.Logging.Medical;

namespace Leadtools.Medical.WebViewer.ImageDownloadAddin
{
   public class DownloadAddin : IProcessNAction, IExtendedPresentationContextProvider
   {
      public DicomCommandStatusType OnNAction
      (
         DicomClient client,
         byte presentationId,
         int messageID,
         string affectedClass,
         string instance,
         int action,
         DicomDataSet request,
         DicomDataSet response
      )
      {
         try
         {
            string JobId = request.GetValue<string>(CustomTags.JobID, null);

            if (string.IsNullOrEmpty(JobId))
            {
               throw new ArgumentException();
            }

            JobsService.Instance.JobsQ.QeueJob(JobId);
            response = null;
            return DicomCommandStatusType.Success;
         }
         catch (System.ArgumentException)
         {
            #region LOG
            {
               string message = @"Image Download - DownloadAddin::OnNAction (Invalid Argument)";

               Logger.Global.Log(string.Empty, string.Empty, -1, string.Empty, string.Empty, -1, DicomCommandType.Undefined, DateTime.Now,
                                LogType.Information, MessageDirection.None, message, null, null);
            }
            #endregion
            
            return DicomCommandStatusType.InvalidArgumentValue;
         }
         catch (System.Exception e)
         {
            #region LOG
            {
               string message = @"Image Download - DownloadAddin::OnNAction: " + e.Message;

               Logger.Global.Log(string.Empty, string.Empty, -1, string.Empty, string.Empty, -1, DicomCommandType.Undefined, DateTime.Now,
                                LogType.Information, MessageDirection.None, message, null, null);
            }
            #endregion

            return DicomCommandStatusType.Failure;
         }
      }

      private DicomClient _client;

      public DicomClient Client
      {
         set { _client = value; }
      }

      public ExtendedNegotiation GetExtended(string abstractSyntax)
      {
         return ExtendedNegotiation.None;
      }

      public bool IsAbstractSyntaxSupported(string abstractSyntax)
      {
         return abstractSyntax == CustomUID.DownloadImagesClass;
      }

      public bool IsTransferSyntaxSupported(string abstractSyntax, string transferSyntax)
      {
         return abstractSyntax == CustomUID.DownloadImagesClass;
      }

      public void Break(BreakType type)
      {
         #region LOG
         {
            string message = @"Image Download - DownloadAddin::Break";

            Logger.Global.Log(string.Empty, string.Empty, -1, string.Empty, string.Empty, -1, DicomCommandType.Undefined, DateTime.Now,
                             LogType.Information, MessageDirection.None, message, null, null);
         }
         #endregion
      }
   }
}



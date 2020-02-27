// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Leadtools.Dicom.Server.Admin;
using Leadtools.Dicom.AddIn.Common;
using System.Threading;
using System.ServiceProcess;

namespace Leadtools.Medical.Storage.AddIns.Messages
{
   public class StorageAddinMessage
   {
      public const string CanAccessDatabase = "7E953C86-243E-475A-8A0C-0AB1A160AD3A";
   }

   public enum DicomServiceTesterResult
   {
      Success,
      ErrorServiceIsNull,
      ErrorServiceNotRunning,
      ErrorServiceCannotAccessDatabase,
      ErrorServiceNotResponding,
   }

   public static class DicomServiceTester
   {
      private static DicomService _serverService = null;
      private static readonly AutoResetEvent _autoResetEvent = new AutoResetEvent(false);
      private static bool _serviceMessageReturned = false;
      private static ServiceMessage _serviceMessage = null;

      public static int WaitMilliseconds = 5000;

      static void _storageServerService_Message(object sender, MessageEventArgs e)
      {
         _serviceMessageReturned = true;
         _serviceMessage = e.Message;
         _autoResetEvent.Set();
      }

      public static DicomServiceTesterResult Test(DicomService dicomService, out string errorMessage)
      {
         return SendDicomServiceMessage(dicomService, StorageAddinMessage.CanAccessDatabase, out errorMessage);
      }

      public static DicomServiceTesterResult CrashDicomServer(DicomService dicomService, out string errorMessage)
      {
         return SendDicomServiceMessage(dicomService, MessageNames.CrashDicomServer, out errorMessage);
      }

      public static DicomServiceTesterResult GarbageCollectDicomServer(DicomService dicomService, out string errorMessage)
      {
         return SendDicomServiceMessage(dicomService, MessageNames.GarbageCollectDicomServer, out errorMessage);
      }

      public static DicomServiceTesterResult SendDicomServiceMessage(DicomService dicomService, string dicomServiceMessageGuid, out string errorMessage)
      {
         DicomServiceTesterResult result = DicomServiceTesterResult.Success;
         errorMessage = string.Empty;

         _serverService = dicomService;
         if (_serverService == null)
         {
            result = DicomServiceTesterResult.ErrorServiceIsNull;
         }
         else if (_serverService.Status != ServiceControllerStatus.Running)
         {
            result = DicomServiceTesterResult.ErrorServiceNotRunning;
         }
         else
         {
            _serverService.Message -= new EventHandler<MessageEventArgs>(_storageServerService_Message);
            _serverService.Message += new EventHandler<MessageEventArgs>(_storageServerService_Message);
            _serviceMessageReturned = false;
            _autoResetEvent.Reset();

            bool exceptionError = false;
            try
            {
               _serverService.SendMessage(dicomServiceMessageGuid); // StorageAddinMessage.CrashDicomServer
            }
            catch(Exception ex)
            {
               if (string.Compare("Service must be running", ex.Message,true) == 0)
               {
                  result = DicomServiceTesterResult.ErrorServiceNotRunning;
               }
               else
               {
                  result = DicomServiceTesterResult.ErrorServiceCannotAccessDatabase;
                  errorMessage = ex.Message;
               }
               exceptionError = true;
            }

            if (exceptionError)
            {
               return result;
            }

            _autoResetEvent.WaitOne(WaitMilliseconds);
            if (_serviceMessageReturned)
            {
               if (_serviceMessage.Success)
               {
                  result = DicomServiceTesterResult.Success;
               }
               else
               {
                  errorMessage = _serviceMessage.Data[0] as string;
                  result = DicomServiceTesterResult.ErrorServiceCannotAccessDatabase;
               }
            }
            else
            {
               result = DicomServiceTesterResult.ErrorServiceNotResponding;
            }
         }
         return result;
      }
   }
}

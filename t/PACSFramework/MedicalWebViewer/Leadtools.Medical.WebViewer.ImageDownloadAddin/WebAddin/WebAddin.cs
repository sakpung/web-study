// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Leadtools.Dicom;
using Leadtools.Dicom.Scu.Common;
using Leadtools.Dicom.Scu;
using System.Net;
using Leadtools.Logging;
using Leadtools.Logging.Medical;

namespace Leadtools.Medical.WebViewer.ImageDownloadAddin
{
   //this class will be used on the web service side to send the request to the server, 
   //you should move it to the "Leadtools.Medical.WebViewer.Addins" project
   public class WebAddin : DicomConnection
   {
      private DicomCommandStatusType _status;

      public WebAddin()
      {
         _status = DicomCommandStatusType.Success;

         this.AfterConnect += new AfterConnectDelegate(WebAddin_AfterConnect);
         this.AfterAssociateRequest += new AfterAssociateRequestDelegate(WebAddin_AfterAssociateRequest);
      }

      void WebAddin_AfterConnect(object sender, AfterConnectEventArgs e)
      {
         if (e.Error != DicomExceptionCode.Success)
         {
            //get some information about the error
         }
      }

      void WebAddin_AfterAssociateRequest(object sender, AfterAssociateRequestEventArgs e)
      {
         if (e.Rejected)
         {
            //get some information about the error
         }
      }


      //override this function to include your abstract class (the custom message we created) in the association
      protected override List<PresentationContext> GetPresentationContexts()
      {
         List<PresentationContext> presentations;
         PresentationContext customPresentation;

         presentations = base.GetPresentationContexts();
         customPresentation = new PresentationContext(CustomUID.DownloadImagesClass);

         customPresentation.TransferSyntaxes.Add(DicomUidType.ExplicitVRBigEndian);
         customPresentation.TransferSyntaxes.Add(DicomUidType.ImplicitVRLittleEndian);

         presentations.Add(customPresentation);

         return presentations;
      }


      public void SendDownloadRequest(object param,
         string clientAE,
         string clientAddress,
         int clientPort, 
         string storageServerAE,
         string storageServerAddress,
         int storageServerPort)
      {
         #region LOG
         {
            string message = @"Image Download - Download Request";
            Logger.Global.Log(storageServerAE, clientAddress, clientPort,
            clientAE, storageServerAddress, storageServerPort, DicomCommandType.CMove,
            DateTime.Now, LogType.Error, MessageDirection.None, message, null, null);

            Logger.Global.Log(string.Empty, string.Empty, -1, string.Empty, string.Empty, -1, DicomCommandType.Undefined, DateTime.Now,
                             LogType.Information, MessageDirection.None, message, null, null);
         }
         #endregion

         try
         {
            AETitle = clientAE;
            HostAddress = IPAddress.Parse(clientAddress);
            HostPort = clientPort;

            DicomScp scp = new DicomScp(IPAddress.Parse(storageServerAddress), storageServerAE, storageServerPort);

            //Use this overload to do a connect and association at the same time and receive the AfterConnect/AfterAssociate events. the other Connect are the low-level which means you have to do a different procedure
            Connect(scp);

            if (null == Association)
            {
               throw new Exception("Association rejected");
            }


            SendDownloadRequest(param);

         }
         catch (Exception e)
         {
            Logger.Global.Log(string.Empty, string.Empty, -1, string.Empty, string.Empty, -1, DicomCommandType.Undefined, DateTime.Now,
                  LogType.Information, MessageDirection.None, e.Message, null, null);

            throw;
         }
         finally
         {
            if (IsConnected())
               Close();
         }
      }

      public void SendDownloadRequest(object param)
      {
         try
         {
            DicomDataSet ds = new DicomDataSet();

            //you can set what ever elements you need, PatientID, StudyInstanceUID, SeriesInstnaceUID...
            //if you need to create private tags to set custom information we have to do it like this:
            // check this link for more information about creating custom tags:
            //https://www.leadtools.com/help/leadtools/v175/dh/di/leadtools.dicom~leadtools.dicom.dicomdataset~createprivatecreatordataelement.html

            {
               DicomElement privateCreatorElement = ds.CreatePrivateCreatorDataElement(null, 0x0017, 0x0012, "DownloadService");

               DicomElement element = ds.InsertElement(null, false, CustomTags.JobID, DicomVRType.LT, false, 0);

               if (null != element)
               {
                  ds.SetStringValue(element, param.ToString(), DicomCharacterSetType.Default); //(0x11,0x0010)
               }
               else
               {
                  throw new Exception("Can't Insert Element");
               }
            }

            byte presentation = GetPresentation();

            SendNActionRequest(presentation, 1, CustomUID.DownloadImagesClass, CustomUID.DownloadImagesInstance, 1, ds);

            Wait(); //blocks until we receive the response from the server
            Release();

            if (_status != DicomCommandStatusType.Success)
            {
               throw new ApplicationException("Error adding a c-move job: " + _status.ToString());
            }
            else
            {
               //success, the server received the request and processing the message.
            }
         }
         catch (Exception e)
         {
            Logger.Global.Log(string.Empty, string.Empty, -1, string.Empty, string.Empty, -1, DicomCommandType.Undefined, DateTime.Now,
                  LogType.Information, MessageDirection.None, e.Message, null, null);

            throw;
         }
      }
      
      private byte GetPresentation()
      {
         try
         {
            byte pid;

            if (null == Association)
            {
               throw new Exception("Association rejected");
            }

            pid = Association.FindAbstract(CustomUID.DownloadImagesClass);

            if (pid == 0 || Association.GetResult(pid) != DicomAssociateAcceptResultType.Success)
            {
               throw new Exception("Abstract syntax not supported");
            }

            return pid;
         }
         catch (Exception e)
         {
            Logger.Global.Log(string.Empty, string.Empty, -1, string.Empty, string.Empty, -1, DicomCommandType.Undefined, DateTime.Now,
                  LogType.Information, MessageDirection.None, e.Message, null, null);

            throw;
         }         
      }
      
      protected override void OnReceiveNActionResponse
      (
         byte presentationID,
         int messageID,
         string affectedClass,
         string instance,
         DicomCommandStatusType status,
         int action,
         DicomDataSet dataSet
      )
      {
         try
         {
            base.OnReceiveNActionResponse(presentationID, messageID, affectedClass, instance, status, action, dataSet);

            _status = status;
         }
         catch (Exception e)
         {
            Logger.Global.Log(string.Empty, string.Empty, -1, string.Empty, string.Empty, -1, DicomCommandType.Undefined, DateTime.Now,
                  LogType.Information, MessageDirection.None, e.Message, null, null);

            throw;
         }
         finally
         {
            dicomEventResponse.Set();
         }
      }
   }
}

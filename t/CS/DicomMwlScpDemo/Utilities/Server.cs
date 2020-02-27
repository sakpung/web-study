// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.IO;
using System.Windows.Forms;
using System.Threading;
using System.Collections.Generic;


using Leadtools;
using Leadtools.Dicom;
using Leadtools.DicomDemos;
using Leadtools.DicomDemos.Scp;

namespace DicomDemo
{
    

   /// <summary>
   /// Summary description for Server.
   /// </summary>
   public class Server : Scp
   {
      private int _Port = 104;
      private int _Peers = 5;
      private string _IPAddress = "";
      private int _Timeout = 1;
      private Dictionary<string, Client> _Clients = new Dictionary<string, Client>();

      public MainForm mf;

      private AutoResetEvent _ExitEvent = new AutoResetEvent(false);

      #region Properties

      public int Port
      {
         get
         {
            return _Port;
         }
         set
         {
            _Port = value;
         }
      }

      public int Peers
      {
         get
         {
            return _Peers;
         }
         set
         {
            _Peers = value;
         }
      }

      public AutoResetEvent ExitEvent
      {
         get
         {
            return _ExitEvent;
         }
      }

      public string IPAddress
      {
         get
         {
            return _IPAddress;
         }
         set
         {
            _IPAddress = value;
         }
      }

      public int Timeout
      {
         get
         {
            return _Timeout;
         }
         set
         {
            _Timeout = value;
         }
      }

      public Dictionary<string, Client> Clients
      {
         get
         {
            return _Clients;
         }
      }


      #endregion

      public Server( )
      {
         CalledAE = "LEAD_SERVER";
         BuildExclusionList();
      }

      /*
       * Builds a UID exclusion list for the server.
       */
      private void BuildExclusionList( )
      {
          //This list has ALL of the UIDs and the ones the server SUPPORTS are commented out
            //UidExclusionList.Add(DicomUidType.VerificationClass);
            UidExclusionList.Add(DicomUidType.MediaStorageDirectory);
            UidExclusionList.Add(DicomUidType.BasicStudyNotificationClass);
            UidExclusionList.Add(DicomUidType.StorageCommitmentPushModelClass);
            UidExclusionList.Add(DicomUidType.StorageCommitmentPullModelClass);
            UidExclusionList.Add(DicomUidType.DetachedPatientClass);
            UidExclusionList.Add(DicomUidType.DetachedPatientMetaClass);
            UidExclusionList.Add(DicomUidType.DetachedVisitClass);
            UidExclusionList.Add(DicomUidType.DetachedStudyClass);
            UidExclusionList.Add(DicomUidType.StudyComponentClass);
            UidExclusionList.Add(DicomUidType.ModalityPerformedClass);
            UidExclusionList.Add(DicomUidType.ModalityPerformedRetrieveClass);
            UidExclusionList.Add(DicomUidType.ModalityPerformedNotificationClass);
            UidExclusionList.Add(DicomUidType.DetachedResultsClass);
            UidExclusionList.Add(DicomUidType.DetachedResultsMetaClass);
            UidExclusionList.Add(DicomUidType.DetachedStudyMetaClass);
            UidExclusionList.Add(DicomUidType.DetachedInterpretationClass);
            UidExclusionList.Add(DicomUidType.BasicFilmSessionClass);
            UidExclusionList.Add(DicomUidType.BasicFilmBoxClass);
            UidExclusionList.Add(DicomUidType.BasicGrayscaleImageBoxClass);
            UidExclusionList.Add(DicomUidType.BasicColorImageBoxClass);
            UidExclusionList.Add(DicomUidType.ReferencedImageBoxClassRetired);
            UidExclusionList.Add(DicomUidType.BasicGrayscalePrintMetaClass);
            UidExclusionList.Add(DicomUidType.ReferencedGrayscalePrintMetaClassRetired);
            UidExclusionList.Add(DicomUidType.PrintJobClass);
            UidExclusionList.Add(DicomUidType.BasicAnnotationBoxClass);
            UidExclusionList.Add(DicomUidType.PrinterClass);
            UidExclusionList.Add(DicomUidType.PrinterConfigurationRetrievalClass);
            UidExclusionList.Add(DicomUidType.BasicColorPrintMetaClass);
            UidExclusionList.Add(DicomUidType.ReferencedColorPrintMetaClassRetired);
            UidExclusionList.Add(DicomUidType.VoiLutBoxClassRetired);
            UidExclusionList.Add(DicomUidType.PresentationLutClass);
            UidExclusionList.Add(DicomUidType.ImageOverlayBoxClassRetired);
            UidExclusionList.Add(DicomUidType.BasicPrintImageOverlayBoxClass);
            UidExclusionList.Add(DicomUidType.PrintQueueClass);
            UidExclusionList.Add(DicomUidType.StoredPrintStorageClass);
            UidExclusionList.Add(DicomUidType.HardcopyGrayscaleImageStorageClass);
            UidExclusionList.Add(DicomUidType.HardcopyColorImageStorageClass);
            UidExclusionList.Add(DicomUidType.PullPrintRequestClass);
            UidExclusionList.Add(DicomUidType.PullStoredPrintMetaClass);
            UidExclusionList.Add(DicomUidType.CRImageStorage);
            UidExclusionList.Add(DicomUidType.DXImageStoragePresentation);
            UidExclusionList.Add(DicomUidType.DXImageStorageProcessing);
            UidExclusionList.Add(DicomUidType.DXMammographyImageStoragePresentation);
            UidExclusionList.Add(DicomUidType.DXMammographyImageStorageProcessing);
            UidExclusionList.Add(DicomUidType.DXIntraoralImageStoragePresentation);
            UidExclusionList.Add(DicomUidType.DXIntraoralImageStorageProcessing);
            UidExclusionList.Add(DicomUidType.CTImageStorage);
            UidExclusionList.Add(DicomUidType.USMultiframeImageStorageRetired);
            UidExclusionList.Add(DicomUidType.USMultiframeImageStorage);
            UidExclusionList.Add(DicomUidType.MRImageStorage);
            UidExclusionList.Add(DicomUidType.EnhancedMRImageStorage);
            UidExclusionList.Add(DicomUidType.MRSpectroscopyStorage);
            UidExclusionList.Add(DicomUidType.NMImageStorageRetired);
            UidExclusionList.Add(DicomUidType.USImageStorageRetired);
            UidExclusionList.Add(DicomUidType.USImageStorage);
            UidExclusionList.Add(DicomUidType.SCImageStorage);
            UidExclusionList.Add(DicomUidType.SCMultiFrameSingleBitImageStorage);
            UidExclusionList.Add(DicomUidType.SCMultiFrameGrayscaleByteImageStorage);
            UidExclusionList.Add(DicomUidType.SCMultiFrameGrayscaleWordImageStorage);
            UidExclusionList.Add(DicomUidType.SCMultiFrameTrueColorImageStorage);
            UidExclusionList.Add(DicomUidType.StandaloneOverlayStorage);
            UidExclusionList.Add(DicomUidType.StandaloneCurveStorage);
            UidExclusionList.Add(DicomUidType.TwleveLeadECGWaveformStorage);
            UidExclusionList.Add(DicomUidType.GeneralECGWaveformStorage);
            UidExclusionList.Add(DicomUidType.AmbulatoryECGWaveformStorage);
            UidExclusionList.Add(DicomUidType.HemodynamicWaveformStorage);
            UidExclusionList.Add(DicomUidType.CardiacElectrophysiologyWaveformStorage);
            UidExclusionList.Add(DicomUidType.BasicVoiceAudioWaveformStorage);
            UidExclusionList.Add(DicomUidType.StandaloneModalityLutStorage);
            UidExclusionList.Add(DicomUidType.StandaloneVoiLutStorage);
            UidExclusionList.Add(DicomUidType.GrayscaleSoftcopyPresentationStateStorage);
            UidExclusionList.Add(DicomUidType.XAImageStorage);
            UidExclusionList.Add(DicomUidType.XRayRadiofluoroscopicImageStorage);
            UidExclusionList.Add(DicomUidType.XABiplaneImageStorageRetired);
            UidExclusionList.Add(DicomUidType.NMImageStorage);
            UidExclusionList.Add(DicomUidType.RawDataStorage);
            UidExclusionList.Add(DicomUidType.VLImageStorageRetired);
            UidExclusionList.Add(DicomUidType.VLMultiframeImageStorageRetired);
            UidExclusionList.Add(DicomUidType.VLEndoscopicImageStorageClass);
            UidExclusionList.Add(DicomUidType.VideoEndoscopicImageStorage);
            UidExclusionList.Add(DicomUidType.VLMicroscopicImageStorageClass);
            UidExclusionList.Add(DicomUidType.VideoMicroscopicImageStorage);
            UidExclusionList.Add(DicomUidType.VLSlideCoordinatesMicroscopicImageStorageClass);
            UidExclusionList.Add(DicomUidType.VLPhotographicImageStorageClass);
            UidExclusionList.Add(DicomUidType.VideoPhotographicImageStorage);
            UidExclusionList.Add(DicomUidType.Ophthalmic8BitPhotographyImageStorage);
            UidExclusionList.Add(DicomUidType.Ophthalmic16BitPhotographyImageStorage);
            UidExclusionList.Add(DicomUidType.StereometricRelationshipStorage);
            UidExclusionList.Add(DicomUidType.BasicTextSR);
            UidExclusionList.Add(DicomUidType.EnhancedSR);
            UidExclusionList.Add(DicomUidType.ComprehensiveSR);
            UidExclusionList.Add(DicomUidType.MammographyCadSR);
            UidExclusionList.Add(DicomUidType.KeyObjectSelectionDocument);
            UidExclusionList.Add(DicomUidType.ChestCadSR);
            UidExclusionList.Add(DicomUidType.PETImageStorage);
            UidExclusionList.Add(DicomUidType.StandalonePETCurveStorage);
            UidExclusionList.Add(DicomUidType.RTImageStorage);
            UidExclusionList.Add(DicomUidType.RTDoseStorage);
            UidExclusionList.Add(DicomUidType.RTStructureStorage);
            UidExclusionList.Add(DicomUidType.RTBeamsTreatmentRecordStorageClass);
            UidExclusionList.Add(DicomUidType.RTPlanStorage);
            UidExclusionList.Add(DicomUidType.RTBrachyTreatmentRecordStorageClass);
            UidExclusionList.Add(DicomUidType.RTTreatmentSummaryRecordStorageClass);
            UidExclusionList.Add(DicomUidType.PatientRootQueryFind);
            UidExclusionList.Add(DicomUidType.PatientRootQueryMove);
            UidExclusionList.Add(DicomUidType.PatientRootQueryGet);
            UidExclusionList.Add(DicomUidType.StudyRootQueryFind);
            UidExclusionList.Add(DicomUidType.StudyRootQueryMove);
            UidExclusionList.Add(DicomUidType.StudyRootQueryGet);
            UidExclusionList.Add(DicomUidType.PatientStudyQueryFind);
            UidExclusionList.Add(DicomUidType.PatientStudyQueryMove);
            UidExclusionList.Add(DicomUidType.PatientStudyQueryGet);
            //UidExclusionList.Add(DicomUidType.ModalityWorklistFind);
            UidExclusionList.Add(DicomUidType.GeneralPurposeWorklistFind);
            UidExclusionList.Add(DicomUidType.GeneralPurposeScheduledProcedureStepSopClass);
            UidExclusionList.Add(DicomUidType.GeneralPurposePerformedProcedureStepSopClass);
            UidExclusionList.Add(DicomUidType.GeneralPurposeWorklistManagementMetaSopClass);
      }

      /*
       * Establishes a connection to listen for incoming connection requests.
       */
      public DicomExceptionCode Listen( )
      {
         DicomExceptionCode ret = DicomExceptionCode.Success;

         try
         {
            Listen(_IPAddress, _Port, _Peers);
            if(_IPAddress.Length == 0)
            {
               _IPAddress = HostAddress;
           }
         }
         catch(DicomException de)
         {
            ret = de.Code;
         }

         return ret;
      }

      /*
       * Notifies a listening connection (SCP) that it can accept pending connection requests.
       */
      protected override void OnAccept(DicomExceptionCode error)
      {
         Client client = null;
         if(error == DicomExceptionCode.Success)
         {
             client = new Client(this);

            Accept(client);

            if (!Clients.ContainsKey(client.PeerAddress))
            {
               Clients.Add(client.PeerAddress, client);
            }
            else
            {
                mf.Log("Connection attempted by " + client.PeerAddress + " was rejected because that IP is already connected\r\n");
                Clients.Remove(client.PeerAddress);
               client.Close();
               
               client.Dispose ( ) ;
               return;
            }

            if(Clients.Count > _Peers)
            {
                mf.Log("Connection attempted by " + client.PeerAddress + " was rejected because the Maximum connections has already been reached\r\n");
                Clients.Remove(client.PeerAddress);
               client.Close();
               client.Dispose ( ) ;
               return;
            }

             if (!VerifyUserIP(client.PeerAddress))
             {
                 mf.Log("Connection attempted by " + client.PeerAddress + " was rejected because the client's IP address is not valid.\r\n");
                 Clients.Remove(client.PeerAddress);
                client.Close();
                client.Dispose ( ) ;
                return;
             }

             mf.Log("***  Last client connected: ClientAddress[" + client.PeerAddress + "], ClientPort[" + client.PeerPort + "]\r\n");
         }
      }

      /*
       * Notifies a member of a connection that the connection was closed.
       */
      protected override void OnClose(DicomExceptionCode error, DicomNet net)
      {
         if(Clients.ContainsKey(net.PeerAddress))
         {
            Client client = Clients[net.PeerAddress];

            Clients.Remove(net.PeerAddress);
            
            client.Dispose ( ) ;
         }
         else
         {
            net.Dispose ( ) ;
         }
      }

      /// <summary>
      /// Forcefully close a client connection.
      /// </summary>
      /// <param name="hClient">Client network handle.</param>
      public void CloseClient(Client client)
      {
         //
         // Remove client from list
         //
         Clients.Remove(client.PeerAddress);
         client.SendAbort(DicomAbortSourceType.Provider,
                         DicomAbortReasonType.Unknown);
         client.CloseForced(true);

         if (client.Association != null)
             mf.Log("CLIENT NAME: " + client.Association.Calling + " -- Timeout");
         else
             mf.Log("CLIENT NAME: " + client.PeerAddress + " -- Timeout");
         
         client.Dispose ( ) ;
      }

      /*
       * Initializes an incoming action.
       */
      public DicomAction InitAction(string actionOp, ProcessType process, Client client, DicomDataSet ds)
      {
         DicomAction action = new DicomAction(process, this, client, ds);

         action.AETitle = client.Association.Calling;
         action.ipAddress = client.PeerAddress;
         action.ActionComplete += new DicomAction.ActionCompleteHandler(action_ActionComplete);

         return action;
      }

      private void action_ActionComplete(object sender, EventArgs e)
      {
         DicomAction action = (DicomAction)sender;
      }

      /*
       * Performs an Association request
       */
      public void DoAssociateRequest(Client client, DicomAssociate association)
      {
          mf.Log("Client Name: " + association.Calling + " -- Receiving Associate Request.\r\n");

          // Check association
          if (association == null)
          {
             client.SendAssociateReject(DicomAssociateRejectResultType.Permanent, DicomAssociateRejectSourceType.Provider1, DicomAssociateRejectReasonType.Application);
              mf.Log("Client Name: " + association.Calling + " -- Failed in accepting the connection (Associate was null)!\r\nSending associate reject!\r\n");
              return;
          }

          // Check version
          if (association.Version != 1)
          {
             client.SendAssociateReject(DicomAssociateRejectResultType.Permanent, DicomAssociateRejectSourceType.Provider1, DicomAssociateRejectReasonType.Version);
              mf.Log("Client Name: " + association.Calling + " -- Failed in accepting the connection (Version Not supported)!\r\nSending associate reject!\r\n");
              return;
          }

          // Make sure that the client is supported
          if (!VerifyUserName(association.Calling))
          {
              client.SendAssociateReject(DicomAssociateRejectResultType.Permanent, DicomAssociateRejectSourceType.User, DicomAssociateRejectReasonType.Calling);
              mf.Log("Client Name: " + association.Calling + " -- Failed in accepting the connection (Not a valid client name)!\r\nSending associate reject!\r\n");
              return;
          }

          // Check the Called AE title (SCP)
          if (association.Called != CalledAE)
          {
              client.SendAssociateReject(DicomAssociateRejectResultType.Permanent, DicomAssociateRejectSourceType.User, DicomAssociateRejectReasonType.Called);
              mf.Log("Client Name: " + association.Calling + " -- Failed in accepting the connection (Server names are not the same)!\r\n Sending associate reject!\r\n");
              return;
          }

          // Send association back
         using(DicomAssociate retAssociate = new DicomAssociate(false))
         {
            retAssociate.MaxLength = 46726;
            retAssociate.Version = 1;
            retAssociate.Called = CalledAE;
            retAssociate.Calling = (CallingAE == null) ? association.Calling : CallingAE;
            retAssociate.ApplicationContextName = (string)DicomUidType.ApplicationContextName;

            for(int i = 0; i < association.PresentationContextCount; i++)
            {
               byte id = association.GetPresentationContextID(i);
               string abstractSyntax = association.GetAbstract(id);

               retAssociate.AddPresentationContext(id, DicomAssociateAcceptResultType.Success, abstractSyntax);
               if(IsSupported(abstractSyntax))
               {
                  for(int j = 0; j < association.GetTransferCount(id); j++)
                  {
                     string transferSyntax = association.GetTransfer(id, j);

                     if(IsSupported(transferSyntax))
                     {
                        retAssociate.AddTransfer(id, transferSyntax);
                        break;
                     }
                  }

                  if(retAssociate.GetTransferCount(id) == 0)
                  {
                     // Presentation id doesn't have any abstract syntaxes therefore we will reject it.
                     retAssociate.SetResult(id, DicomAssociateAcceptResultType.AbstractSyntax);
                  }
               }
               else
               {
                  retAssociate.SetResult(id, DicomAssociateAcceptResultType.AbstractSyntax);
               }
            }

            if(association.MaxLength != 0)
            {
               retAssociate.MaxLength = association.MaxLength;
            }

            retAssociate.ImplementClass = ImplementationClass;
            retAssociate.ImplementationVersionName = ImplementationVersionName;

            client.SendAssociateAccept(retAssociate);
            mf.Log("Client Name: " + association.Calling + " -- Sending Associate Accept.\r\n");
         }
      }

      /*
       * Makes sure that the user's name attempting to associate is valid
       */
      private bool VerifyUserName(string CallingName)
      {
          bool bRet;

          if (mf.lstClients.Items.Count > 0)
          {
              bRet = false;
              for (int i = 0; i < mf.lstClients.Items.Count; i++)
              {
                  if (mf.lstClients.Items[i].SubItems[0].Text == CallingName)
                      return true;
              }
          }
          else
          {
              bRet = true;
          }

          return bRet;
      }

      /*
       * Makes sure that the user's IP attempting to connect is valid
       */
      private bool VerifyUserIP(string CallingIP)
      {
          bool bRet;

          if (mf.lstClients.Items.Count > 0)
          {
              bRet = false;
              for (int i = 0; i < mf.lstClients.Items.Count; i++)
              {
                  if (mf.lstClients.Items[i].SubItems[1].Text == CallingIP)
                      return true;
              }
          }
          else
          {
              bRet = true;
          }

          return bRet;
      }
   }
}

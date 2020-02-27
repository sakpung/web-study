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
using Leadtools.Demos.Database;

namespace DicomDemo
{

   /// <summary>
   /// Summary description for Server.
   /// </summary>
   public class Server : Scp
   {
      private int _Port = 104;
      private int _Peers = 5;
      private bool _Verify = true;
      private string _IPAddress = "";
      private DicomNetIpTypeFlags _ipType;
      public new DicomNetIpTypeFlags IpType
      {
         get { return _ipType; }
         set { _ipType = value; }
      }
      private int _Timeout = 1;
      private string _ImageDir = Application.StartupPath + @"\ImagesCS\";
      private string _LogDir = Application.StartupPath + @"\LogCS\";
      private bool _SaveCSReceived = false;
      private bool _SaveDSReceived = false;
      private bool _SaveDSSent = false;
      private bool _isSecure = false;
      private Dictionary<string, Client> _Clients = new Dictionary<string, Client>();

      private string _certificationAuthoritiesFileName = Application.StartupPath + @"\CA.pem";
      private string _serverPEM = Application.StartupPath + @"\server.pem";

      public MainForm mf;
      public UsersDB usersDB;
      public DicomDB dicomDB;

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

      public bool Verify
      {
         get
         {
            return _Verify;
         }
         set
         {
            _Verify = value;
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

      public string ImageDir
      {
         get
         {
            return _ImageDir;
         }
         set
         {
            _ImageDir = value;
         }
      }

      public bool SaveCSReceived
      {
         get
         {
            return _SaveCSReceived;
         }
         set
         {
            _SaveCSReceived = value;
         }
      }

      public bool SaveDSReceived
      {
         get
         {
            return _SaveDSReceived;
         }
         set
         {
            _SaveDSReceived = value;
         }
      }

      public bool SaveDSSent
      {
         get
         {
            return _SaveDSSent;
         }
         set
         {
            _SaveDSSent = value;
         }
      }

      public string LogDir
      {
         get
         {
            return _LogDir;
         }
         set
         {
            _LogDir = value;
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

      public Server()
      {
         CalledAE = "LEAD_SERVER";
#if (LEADTOOLS_V17_OR_LATER)
         IpType = DicomNetIpTypeFlags.Ipv4;
#endif
      }

      public override void Init()
      {
         base.Init();

         BuildExclusionList();
      }

      private void BuildExclusionList()
      {
         UidExclusionList.Add(DicomUidType.PatientRootQueryGet);
         UidExclusionList.Add(DicomUidType.StudyRootQueryGet);
         UidExclusionList.Add(DicomUidType.PatientStudyQueryFind);
         UidExclusionList.Add(DicomUidType.PatientStudyQueryMove);
         UidExclusionList.Add(DicomUidType.PatientStudyQueryGet);
         UidExclusionList.Add(DicomUidType.ModalityWorklistFind);
         UidExclusionList.Add(DicomUidType.MediaStorageDirectory);
         UidExclusionList.Add(DicomUidType.BasicStudyNotificationClass);
         UidExclusionList.Add(DicomUidType.StorageCommitmentPushModelClass);
         UidExclusionList.Add(DicomUidType.StorageCommitmentPushModelInstance);
         UidExclusionList.Add(DicomUidType.StorageCommitmentPullModelClass);
         UidExclusionList.Add(DicomUidType.StorageCommitmentPullModelInstance);
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
         UidExclusionList.Add(DicomUidType.BasicGrayscalePrintMetaClass);
         UidExclusionList.Add(DicomUidType.PrintJobClass);
         UidExclusionList.Add(DicomUidType.BasicAnnotationBoxClass);
         UidExclusionList.Add(DicomUidType.PrinterClass);
         UidExclusionList.Add(DicomUidType.PrinterInstance);
         UidExclusionList.Add(DicomUidType.BasicColorPrintMetaClass);
         UidExclusionList.Add(DicomUidType.PresentationLutClass);
         UidExclusionList.Add(DicomUidType.PrintQueueInstance);
         UidExclusionList.Add(DicomUidType.PrintQueueClass);
         UidExclusionList.Add(DicomUidType.StoredPrintStorageClass);
         UidExclusionList.Add(DicomUidType.HardcopyGrayscaleImageStorageClass);
         UidExclusionList.Add(DicomUidType.HardcopyColorImageStorageClass);
         UidExclusionList.Add(DicomUidType.PullPrintRequestClass);
         UidExclusionList.Add(DicomUidType.PullStoredPrintMetaClass);
         //UidExclusionList.Add(DicomUidType.UID_GE_MAGNETIC_RESONANCE_IMAGE_INFORMATION_OBJECT);
         //UidExclusionList.Add(DicomUidType.UID_GE_COMPUTED_TOMOGRAPHY_IMAGE_INFORMATION_OBJECT);
         UidExclusionList.Add(DicomUidType.GeDisplayImagermation);
         UidExclusionList.Add(DicomUidType.GeArmMigration);
         UidExclusionList.Add(DicomUidType.GeArmMigrationInstance);

         UidExclusionList.Add(DicomUidType.JPEGExtended3_5);
         UidExclusionList.Add(DicomUidType.JPEGSpectralNonhier6_8);
         UidExclusionList.Add(DicomUidType.JPEGSpectralNonhier7_9);
         UidExclusionList.Add(DicomUidType.JPEGFullNonhier10_12);
         UidExclusionList.Add(DicomUidType.JPEGFullNonhier11_13);
         UidExclusionList.Add(DicomUidType.JPEGLosslessNonhier15);
         UidExclusionList.Add(DicomUidType.JPEGExtendedHier16_18);
         UidExclusionList.Add(DicomUidType.JPEGExtendedHier17_19);
         UidExclusionList.Add(DicomUidType.JPEGSpectralHier20_22);
         UidExclusionList.Add(DicomUidType.JPEGSpectralHier21_23);
         UidExclusionList.Add(DicomUidType.JPEGFullHier24_26);
         UidExclusionList.Add(DicomUidType.JPEGFullHier25_27);
         UidExclusionList.Add(DicomUidType.JPEGLosslessHierProcess28);
         UidExclusionList.Add(DicomUidType.JPEGLosslessHierProcess29);
         UidExclusionList.Add(DicomUidType.JPEGLSLossless);
         UidExclusionList.Add(DicomUidType.JPEGLSLossy);
      }

      public DicomExceptionCode Listen()
      {
         DicomExceptionCode ret = DicomExceptionCode.Success;

         try
         {
#if (LEADTOOLS_V17_OR_LATER)
            Listen(_IPAddress, _Port, _Peers, _ipType);
#else
            Listen(_IPAddress, _Port, _Peers);
#endif
            if (_IPAddress.Length == 0)
            {
               _IPAddress = HostAddress;
            }
            mf.Log("Startup", "Server started");
         }
         catch (DicomException de)
         {
            mf.Log("Startup", "Error starting server: " + de.Code.ToString());
            ret = de.Code;
         }

         return ret;
      }

      public bool IsSecure
      {
         get
         {
            return _isSecure;
         }
         set
         {
            _isSecure = value;
         }
      }

      protected override void OnAccept(DicomExceptionCode error)
      {
         Client client = null;
         if (error == DicomExceptionCode.Success)
         {
            if (IsSecure)
            {
               client = new Client(this, false);
               if (client != null)
               {
                  //Require and verify a client certificate.
                  //Support SSL version 3 or TLS Version 1 for the handshake.
                  //Use trusted certificate authority file to verify the client certificate
                  //Verify the client certificate chain to a maximum depth of 2.
                  DicomOpenSslContextCreationSettings settings = new DicomOpenSslContextCreationSettings(DicomSslMethodType.SslV23,
                     _certificationAuthoritiesFileName,
                     DicomOpenSslVerificationFlags.Peer |
                     DicomOpenSslVerificationFlags.FailIfNoPeerCertificate,
                     2,
                     DicomOpenSslOptionsFlags.NoSslV2 |
                     DicomOpenSslOptionsFlags.AllBugWorkarounds);
#if !LEADTOOLS_V20_OR_LATER
                  client.Initialize(null, DicomNetSecurityeMode.Tls, settings);
#else
                  client.Initialize(null, DicomNetSecurityMode.Tls, settings);
#endif // #if !LEADTOOLS_V20_OR_LATER

                  client.SetTlsCipherSuiteByIndex(0, DicomTlsCipherSuiteType.DheRsaWithDesCbcSha);
                  client.SetTlsCipherSuiteByIndex(1, DicomTlsCipherSuiteType.DheRsaWith3DesEdeCbcSha);
                  client.SetTlsCipherSuiteByIndex(2, DicomTlsCipherSuiteType.DheRsaAes256Sha);

#if LEADTOOLS_V20_OR_LATER
                  // TLS 1.0
                  client.SetTlsCipherSuiteByIndex(3, DicomTlsCipherSuiteType.RsaWithAes128CbcSha);
                  client.SetTlsCipherSuiteByIndex(4, DicomTlsCipherSuiteType.RsaWith3DesEdeCbcSha);
                  
                  // TLS 1.2
                  client.SetTlsCipherSuiteByIndex(5, DicomTlsCipherSuiteType.DheRsaWithAes128GcmSha256);
                  client.SetTlsCipherSuiteByIndex(6, DicomTlsCipherSuiteType.EcdheRsaWithAes128GcmSha256);
                  client.SetTlsCipherSuiteByIndex(7, DicomTlsCipherSuiteType.DheRsaWithAes256GcmSha384);
                  client.SetTlsCipherSuiteByIndex(8, DicomTlsCipherSuiteType.EcdheRsaWithAes256GcmSha384);
#endif // #if LEADTOOLS_V20_OR_LATER

                  client.SetTlsClientCertificate(_serverPEM, DicomTlsCertificateType.Pem, null);
               }
            }
            else
            {
               client = new Client(this);
            }

            try
            {
               Accept(client);
            }
            catch (Exception ex)
            {
               mf.Log("Connect", string.Format("Connection rejected : {0}", ex.Message));
               client.Close();
               return;
            }

            if (!Clients.ContainsKey(client.PeerAddress + "_" + client.PeerPort))
            {
               Clients.Add(client.PeerAddress + "_" + client.PeerPort, client);
            }
            else
            {
               mf.Log("Connect", "Connection rejected.  IP already connected: " + client.PeerAddress);
               client.Close();
               return;
            }

            if (Clients.Count > _Peers)
            {
               mf.Log("Connect", "Connection rejected. Max connections reached");
               client.Close();
               return;
            }

            if (_Verify)
            {
               if (!usersDB.FindUser(client.PeerAddress))
               {
                  Clients.Remove(client.PeerAddress + "_" + client.PeerPort);
                  client.Close();
                  mf.Log("Connect", "Connection rejected.  Unknown User: " + client.PeerAddress);
                  client.Dispose();
                  return;
               }
            }

            mf.AddClient(client, DateTime.Now);
            mf.Log("Connect", "Accepted");
         }
      }

      protected override void OnClose(DicomExceptionCode error, DicomNet net)
      {
         if (Clients.ContainsKey(net.PeerAddress + "_" + net.PeerPort))
         {
            Client client = Clients[net.PeerAddress + "_" + net.PeerPort];

            mf.RemoveClient(client);
            Clients.Remove(net.PeerAddress + "_" + net.PeerPort);
            client.Terminate();
            client.Dispose();
         }
         else
         {
            net.Dispose();
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
         Clients.Remove(client.PeerAddress + "_" + client.PeerPort);
         client.SendAbort(DicomAbortSourceType.Provider,
                         DicomAbortReasonType.Unknown);
         client.CloseForced(true);

         if (client.Association != null)
            mf.Log("Timeout", "Connection closed: " + client.Association.Calling);
         else
            mf.Log("Timeout", "Connection closed: " + client.PeerAddress);

         client.Dispose();
      }

      public DicomAction InitAction(string actionOp, ProcessType process, Client client, DicomDataSet ds)
      {
         DicomAction action = new DicomAction(process, this, client, ds);

         action.AETitle = client.Association.Calling;
         action.ipAddress = client.PeerAddress;
         mf.EnableTimer(client, action.AETitle, false);
         mf.UpdateClient(client, "", actionOp);
         action.ActionComplete += new DicomAction.ActionCompleteHandler(action_ActionComplete);

         if (ds != null && SaveDSReceived && !Logger.DisableLogging)
         {
            string file;

            file = LogDS(process.ToString(), client, ds);
            mf.Log(actionOp, "Received from " + action.AETitle, file);
         }
         else
            mf.Log(actionOp, "Received from " + action.AETitle);

         return action;
      }

      private void action_ActionComplete(object sender, EventArgs e)
      {
         DicomAction action = (DicomAction)sender;

         mf.EnableTimer(action.Client, action.AETitle, true);
      }

      private string GetLogDir(string AETitle)
      {
         string dir = LogDir + AETitle + @"\";

         if (!Directory.Exists(dir))
         {
            Directory.CreateDirectory(dir);
         }
         return dir;
      }

      public void LogCS(Client client, DicomDataSet ds)
      {
         UserInfo ui;

         ui = mf.UsersData.LoadUser(client.PeerAddress, client.Association.Calling);
         if (ui != null)
         {
            string dir = GetLogDir(client.Association.Calling);
            string file;
            string command;

            //
            // File name is of the following form for command sets.
            //  cs.hNet-Command-UniqueId.dcm
            //

            command = ds.InformationCommand.ToString();
            command = command.Remove(0, command.IndexOf("_") + 1);
            command = command.Replace("_", "-");
            file = dir + "cs." + client.Association.Calling + "-" + command + "-REQ";
            file += "-" + Environment.TickCount.ToString() + ".dcm";
            ds.Save(file, DicomDataSetSaveFlags.None);
         }
      }

      public void DoAssociateRequest(Client client, DicomAssociate association)
      {
         using (DicomAssociate retAssociate = new DicomAssociate(false))
         {
            if (retAssociate == null)
            {
               client.SendAssociateReject(DicomAssociateRejectResultType.Permanent,
                                         DicomAssociateRejectSourceType.Provider1,
                                         DicomAssociateRejectReasonType.Application);
               return;
            }

            retAssociate.MaxLength = 46726;
            retAssociate.Version = 1;
            retAssociate.Called = CalledAE;
            retAssociate.Calling = (CallingAE == null) ? association.Calling : CallingAE;
            retAssociate.ApplicationContextName = (string)DicomUidType.ApplicationContextName;

            for (int i = 0; i < association.PresentationContextCount; i++)
            {
               byte id = association.GetPresentationContextID(i);
               string abstractSyntax = association.GetAbstract(id);

               retAssociate.AddPresentationContext(id, DicomAssociateAcceptResultType.Success, abstractSyntax);
               if (IsSupported(abstractSyntax))
               {
                  for (int j = 0; j < association.GetTransferCount(id); j++)
                  {
                     string transferSyntax = association.GetTransfer(id, j);

                     if (IsSupported(transferSyntax))
                     {
                        retAssociate.AddTransfer(id, transferSyntax);
                        break;
                     }
                  }

                  if (retAssociate.GetTransferCount(id) == 0)
                  {
                     //
                     // Presentation id doesn't have any abstract
                     //  syntaxes therefore we will reject it.
                     //
                     retAssociate.SetResult(id, DicomAssociateAcceptResultType.AbstractSyntax);
                  }
               }
               else
               {
                  retAssociate.SetResult(id, DicomAssociateAcceptResultType.AbstractSyntax);
               }
            }

            if (association.MaxLength != 0)
            {
               retAssociate.MaxLength = association.MaxLength;
            }

            retAssociate.ImplementClass = ImplementationClass;
            retAssociate.ImplementationVersionName = ImplementationVersionName;

            client.SendAssociateAccept(retAssociate);
         }
      }

      public string LogDS(string command, Client client, DicomDataSet ds)
      {
         UserInfo ui;
         string file = "";

         ui = mf.UsersData.LoadUser(client.PeerAddress, client.Association.Calling);
         if (ui != null)
         {
            string dir = GetLogDir(client.Association.Calling);

            //
            // File name is of the following form for command sets.
            //  ds.CallingAE-Command-UniqueId.dcm
            //				
            file = dir + "ds." + client.Association.Calling + "-" + command;
            file += "-" + Environment.TickCount.ToString() + ".dcm";
            ds.Save(file, DicomDataSetSaveFlags.None);
            ;
         }
         return file;
      }
   }
}

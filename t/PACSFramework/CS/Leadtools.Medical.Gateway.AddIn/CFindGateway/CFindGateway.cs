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
using Leadtools.Dicom.AddIn.Attributes;
using Leadtools.Dicom;
using Leadtools.Dicom.Scu;
using Leadtools.Dicom.Scu.Common;
using Leadtools.Medical.Gateway.CFindAddin.DataTypes;
using Leadtools.Dicom.AddIn.Common;
using System.Net;
using Leadtools.Logging;
using Leadtools.Logging.Medical;
using Leadtools.Dicom.Common.Extensions;

namespace Leadtools.Medical.Gateway.CFindAddin
{
   public class CFindGateway : IProcessCFind, IExtendedPresentationContextProvider
   {

      public const string SECURE_LINK_READY_CIPHERSUITE = "[Gateway] Secure link ready.^\tSecure Link Established^\tCipher Suite Sucessfully Negotiated: {0}";
      public const string SECURE_LINK_FAILED = "[Gateway] Secure link failed.^{0}";
      public CFindGateway()
      {
         if (ServiceLocator.IsRegistered<GatewayServersManager>())
         {
            __ServersManager = ServiceLocator.Retrieve<GatewayServersManager>();
         }
      }

      //[PresentationContext(DicomUidType.PatientRootQueryFind, new byte[] {1,0,1},DicomUidType.ImplicitVRLittleEndian)]
      //[PresentationContext(DicomUidType.PatientStudyQueryFind, DicomUidType.ImplicitVRLittleEndian)]
      //[PresentationContext(DicomUidType.StudyRootQueryFind, DicomUidType.ImplicitVRLittleEndian)]
      public DicomCommandStatusType OnFind
         (
            DicomClient client,
            byte presentationId,
            int messageId,
            string affectedClass,
            DicomCommandPriorityType priority,
            DicomDataSet request
         )
      {
         int countOfServersConnection;


         try
         {
            __Client = client;

            if (null == __ServersManager)
            {
               GatewaySession.Log(string.Empty, string.Empty, -1, DicomCommandType.CFind, LogType.Error, MessageDirection.None, null, "[Gateway] Gateway server not available");

               return DicomCommandStatusType.ProcessingFailure;
            }

            countOfServersConnection = 0;

            //make sure to break the loop on success or normal failure
            while (countOfServersConnection < __ServersManager.Servers.Count)
            {
               AeInfo currentRemoteServer;
               DicomScp remoteScp;
               QueryRetrieveScu cFindScu;


               countOfServersConnection++;

               currentRemoteServer = __ServersManager.GetRemoteServer();

               remoteScp = GetScp(currentRemoteServer);
               cFindScu = GetScu(__ServersManager.Gateway.Server);

               try
               {
                  RegisterEvents(cFindScu);

                  if (cFindScu.SecurityMode == DicomNetSecurityMode.Tls)
                  {
                     GatewaySession.InitializeDicomSecurity(false);
                     GatewaySession.SetCiphers(cFindScu);
                     GatewaySession.SetSecurityCertificates(cFindScu);
                  }

                  __CFindScu = cFindScu;

                  __CurrentStatus = DicomCommandStatusType.Success;

                  GatewaySession.Log(client, DicomCommandType.CFind, LogType.Information, MessageDirection.Output, request,
                                       "[Gateway] Sending C-Find request to remote server \"" + currentRemoteServer.AETitle + "\"");

                  cFindScu.Find(remoteScp, request);

                  GatewaySession.Log(client, DicomCommandType.CFind, LogType.Information, MessageDirection.None, null,
                                       "[Gateway] C-Find request sent successfully \"" + currentRemoteServer.AETitle + "\"");

                  break;
               }
               catch (ClientConnectionException exception)
               {
                  GatewaySession.Log(client, DicomCommandType.CFind, LogType.Warning, MessageDirection.None, null, "[Gateway] Connecting to server failed \"" + currentRemoteServer.AETitle + "\"\n" + exception.Message);

                  __ServersManager.SetRemoteServerConnectionFailure();

                  __CurrentStatus = DicomCommandStatusType.Failure;
               }
               catch (ClientCommunicationException exception)
               {
                  __CurrentStatus = exception.Status;

                  GatewaySession.Log(client, DicomCommandType.CFind, LogType.Error, MessageDirection.None, null, "[Gateway] Communicating with server failed \"" + currentRemoteServer.AETitle + "\"\n" + exception.Message);

                  break;
               }
               catch (DicomException exception)
               {
                  if (__CurrentStatus == DicomCommandStatusType.Success)
                  {
                     __CurrentStatus = DicomCommandStatusType.Failure;
                  }

                  GatewaySession.Log(client, DicomCommandType.CFind, LogType.Error, MessageDirection.None, null, "[Gateway] Forwarding to server failed \"" + currentRemoteServer.AETitle + "\"\n" + exception.Message);

                  break;
               }
               catch (Exception exception)
               {
                  if (__CurrentStatus == DicomCommandStatusType.Success)
                  {
                     __CurrentStatus = DicomCommandStatusType.ProcessingFailure;
                  }

                  GatewaySession.Log(client, DicomCommandType.CFind, LogType.Error, MessageDirection.None, null, "[Gateway] Forwarding to server failed \"" + currentRemoteServer.AETitle + "\"\n" + exception.Message);

                  break;
               }
               finally
               {
                  UnregisterEvents(cFindScu);

                  cFindScu.Dispose();

                  __CFindScu = null;
               }
            }

            return __CurrentStatus;
         }
         finally
         {
            request.Dispose();
         }

      }

      private void find_PrivateKeyPassword(object sender, PrivateKeyPasswordEventArgs e)
      {
         e.PrivateKeyPassword = GatewaySession.DicomSecurityAgent.Password;
      }

      private QueryRetrieveScu GetScu(AeInfo server)
      {
         QueryRetrieveScu scu = null;
         bool useSecurePort = (server.Port == 0) && (server.SecurePort != 0);
         int port = useSecurePort ? server.SecurePort : server.Port;
         if (useSecurePort)
         {
            GatewaySession.InitializeDicomSecurity(false);
            scu = new QueryRetrieveScu(string.Empty, DicomNetSecurityMode.Tls, GatewaySession._openSslOptions);
            scu.UseSecureHost = true;
            GatewaySession.SetCiphers(scu);
         }

         if (scu == null)
         {
            scu = new QueryRetrieveScu();
         }

         scu.AETitle = server.AETitle;
         scu.HostAddress = IPAddress.Parse(server.Address);
         scu.HostPort = port;

         return scu;
      }

      public void Break(BreakType type)
      {
         try
         {
            if (null != __CFindScu)
            {
               Cancelling = true;

               __CFindScu.CancelRequest();
            }
         }
         catch
         { }
      }

      private bool Cancelling { get; set; }

      public event MatchFoundDelegate MatchFound;

      private void OnMatchFound(DicomDataSet response)
      {
         try
         {
            if (null != MatchFound)
            {
               try
               {
                  GatewaySession.Log(__Client, DicomCommandType.CFind, LogType.Debug, MessageDirection.Output, null,
                                       "[Gateway] Sending C-Find response to client \"" + (__Client.IsAssociated() ? __Client.Association.Calling : string.Empty) + "\"");

                  DicomElement element = response.FindFirstElement(null, DicomTag.RetrieveAETitle, true);

                  if (null != element)
                  {
                     response.DeleteElement(element);
                  }

                  response.InsertElementAndSetValue(DicomTag.InstanceAvailability, "NEARLINE");

                  MatchFound(this, new MatchFoundEventArgs(response));

                  GatewaySession.Log(__Client, DicomCommandType.CFind, LogType.Debug, MessageDirection.Output, null,
                                       "[Gateway] C-Find response sent successfully to client \"" + (__Client.IsAssociated() ? __Client.Association.Calling : string.Empty) + "\"");
               }
               catch (Exception exception)
               {
                  GatewaySession.Log(__Client, DicomCommandType.CFind, LogType.Error, MessageDirection.Output, null,
                                       "[Gateway] Faild to send C-Find response to client \"" + (__Client.IsAssociated() ? __Client.Association.Calling : string.Empty) + "\"\n"
                                       + exception.Message);
               }
            }
         }
         finally
         {
            response.Dispose();
         }
      }

      private void find_AfterConnect(object sender, AfterConnectEventArgs e)
      {
         if (e.Error != DicomExceptionCode.Success)
         {
            throw new Leadtools.Dicom.Scu.Common.ClientConnectionException(Constants.Exception.ConnectionFailed,
                                                  e.Error);
         }
      }

      private void find_AfterCFind(object sender, AfterCFindEventArgs e)
      {
         __CurrentStatus = e.Status;

         if (e.Status != DicomCommandStatusType.Success)
         {
            throw new Leadtools.Dicom.Scu.Common.ClientCommunicationException(Constants.Exception.CFindFailed,
                                                     e.Status);
         }
      }

      private void find_AfterAssociateRequest(object sender, AfterAssociateRequestEventArgs e)
      {
         try
         {
            if (e.Rejected)
            {
               throw new Leadtools.Dicom.Scu.Common.ClientAssociationException(Constants.Exception.AssociationFailed,
                                                                                 e.Reason);
            }
         }
         catch (Exception exception)
         {
            System.Diagnostics.Debug.Assert(false, exception.Message);

            throw;
         }
      }

      private void find_MatchStudy(object sender, MatchEventArgs<Study> e)
      {
         try
         {
            if (Cancelling)
            {
               return;
            }

            OnMatchFound(e.Dataset);

         }
         catch (Exception)
         { }
      }

      private void find_MatchSeries
      (
         object sender,
         MatchEventArgs<Leadtools.Dicom.Scu.Series> e
      )
      {
         try
         {
            if (Cancelling)
            {
               return;
            }

            OnMatchFound(e.Dataset);
         }
         catch (Exception)
         { }
      }

      void find_MatchInstance
      (
         object sender,
         MatchEventArgs<CompositeObjectInstance> e
      )
      {
         try
         {
            if (Cancelling)
            {
               return;
            }

            OnMatchFound(e.Dataset);
         }
         catch (Exception)
         { }
      }

      private DicomScp GetScp(AeInfo client)
      {
         int port = (client.Port != 0) ? client.Port : client.SecurePort;
         return new DicomScp(IPAddress.Parse(client.Address), client.AETitle, port) { Timeout = GatewaySession.Timeout };
      }

      private void RegisterEvents(QueryRetrieveScu find)
      {
         try
         {
            find.AfterAssociateRequest += new AfterAssociateRequestDelegate(find_AfterAssociateRequest);
            find.AfterCFind += new AfterCFindDelegate(find_AfterCFind);
            find.AfterConnect += new AfterConnectDelegate(find_AfterConnect);
            find.MatchStudy += new MatchStudyDelegate(find_MatchStudy);
            find.MatchSeries += new MatchSeriesDelegate(find_MatchSeries);
            find.MatchInstance += new MatchInstanceDelegate(find_MatchInstance);
            find.AfterSecureLinkReady += Find_AfterSecureLinkReady;
            find.PrivateKeyPassword += find_PrivateKeyPassword;
         }
         catch (Exception exception)
         {
            System.Diagnostics.Debug.Assert(false, exception.Message);

            throw;
         }
      }

      private void Find_AfterSecureLinkReady(object sender, AfterSecureLinkReadyEventArgs e)
      {
         DicomConnection connection = sender as DicomConnection;

         if (e.Error == DicomExceptionCode.Success)
         {
            DicomTlsCipherSuiteType cipher = connection.GetTlsCipherSuite();
            GatewaySession.Log(LogType.Information, String.Format(SECURE_LINK_READY_CIPHERSUITE, cipher.GetCipherFriendlyName()));
         }
         else
         {
            GatewaySession.Log(LogType.Information, String.Format(SECURE_LINK_FAILED, e.Error));
         }
      }

      private void UnregisterEvents(QueryRetrieveScu find)
      {
         try
         {
            find.AfterAssociateRequest -= new AfterAssociateRequestDelegate(find_AfterAssociateRequest);
            find.AfterCFind -= new AfterCFindDelegate(find_AfterCFind);
            find.AfterConnect -= new AfterConnectDelegate(find_AfterConnect);
            find.MatchStudy -= new MatchStudyDelegate(find_MatchStudy);
            find.MatchSeries -= new MatchSeriesDelegate(find_MatchSeries);
            find.MatchInstance -= new MatchInstanceDelegate(find_MatchInstance);
            find.PrivateKeyPassword -= find_PrivateKeyPassword; 
            find.AfterSecureLinkReady -= Find_AfterSecureLinkReady;
         }
         catch (Exception exception)
         {
            System.Diagnostics.Debug.Assert(false, exception.Message);

            throw;
         }
      }

      GatewayServersManager __ServersManager { get; set; }
      QueryRetrieveScu __CFindScu { get; set; }
      DicomCommandStatusType __CurrentStatus { get; set; }
      DicomNet __Client { get; set; }

      private static class Constants
      {
         public static class Exception
         {
            public const string ConnectionFailed = "Failed to connect to server.";
            public const string AssociationFailed = "Failed to establish an association with the server.";
            public const string CFindFailed = "C-Find Request failed";
         }
      }

      #region IExtendedPresentationContextProvider Members

      private DicomClient _Client;

      public DicomClient Client
      {
         set
         {
            _Client = value;
         }
      }

      public ExtendedNegotiation GetExtended(string abstractSyntax)
      {
         if (abstractSyntax == DicomUidType.PatientRootQueryFind)
            return ExtendedNegotiation.RelationalQueries | ExtendedNegotiation.FuzzySemantics;
         return ExtendedNegotiation.None;
      }

      #endregion

      #region IPresentationContextProvider Members

      public bool IsAbstractSyntaxSupported(string abstractSyntax)
      {
         if (abstractSyntax == DicomUidType.PatientRootQueryFind || abstractSyntax == DicomUidType.PatientStudyQueryFind ||
            abstractSyntax == DicomUidType.StudyRootQueryFind)
         {
            if (!GatewaySession.HasGetwayLicense)
            {
               string message = "[Gateway] Valid license for gateway server not found.  Abstract syntax not accepted by gateway server";

               GatewaySession.Log(_Client, DicomCommandType.CFind, LogType.Error, MessageDirection.Input, null, message);
            }
            return GatewaySession.HasGetwayLicense;
         }
         return false;
      }

      public bool IsTransferSyntaxSupported(string abstractSyntax, string transferSyntax)
      {
         return IsAbstractSyntaxSupported(abstractSyntax);
      }

      #endregion
   }
}

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
using Leadtools.Dicom.AddIn.Attributes ;
using Leadtools.Dicom;
using Leadtools.Dicom.Scu;
using Leadtools.Dicom.Scu.Common;
using Leadtools.Medical.Gateway.CFindAddin.DataTypes;
using Leadtools.Dicom.AddIn.Common;
using System.Net;
using System.Threading;
using Leadtools.Medical.Winforms.Forwarder;
using Leadtools.Medical.DataAccessLayer;
using Leadtools.Medical.Forward.DataAccessLayer;
using Leadtools.Medical.Winforms.Forwarder.Controls;
using Leadtools.Logging;
using Leadtools.Logging.Medical;
using Leadtools.Dicom.Common.Extensions;

namespace Leadtools.Medical.Gateway.CFindAddin
{
   public class CMoveGateway : IProcessCMove, IExtendedPresentationContextProvider
   {
      public CMoveGateway ( ) 
      {
         if ( ServiceLocator.IsRegistered <GatewayServersManager> ( ) )
         {
            __ServersManager = ServiceLocator.Retrieve<GatewayServersManager> ( ) ;
         }
      }
      
      //[PresentationContext(DicomUidType.PatientRootQueryMove, new byte[] {1,0,1},DicomUidType.ImplicitVRLittleEndian)]
      //[PresentationContext(DicomUidType.PatientStudyQueryMove, DicomUidType.ImplicitVRLittleEndian)]
      //[PresentationContext(DicomUidType.StudyRootQueryMove, DicomUidType.ImplicitVRLittleEndian)]
      public DicomCommandStatusType OnMove 
      (
         DicomClient client, 
         byte presentationId, 
         int messageId, 
         string affectedClass, 
         DicomCommandPriorityType priority, 
         string moveAE, 
         DicomDataSet request
      )
      {
         try
         {
            int countOfServersConnection ; 
            
            
            __Client   =  client ;
            __ClientAE = client.AETitle ;
            
            if ( null == __ServersManager ) 
            {
               GatewaySession.Log ( string.Empty, string.Empty, -1, DicomCommandType.CMove, LogType.Error, MessageDirection.None, null, "[Gateway] Gateway server not available" ) ;
               
               return DicomCommandStatusType.ProcessingFailure ;
            }
            
            countOfServersConnection = 0 ;
            
            //make sure to break the loop on success or normal failure
            while ( countOfServersConnection < __ServersManager.Servers.Count )
            {
               AeInfo            currentRemoteServer ;
               DicomScp          remoteScp ;
               QueryRetrieveScu  cMoveScu ;
               
               
               countOfServersConnection++ ;
               
               currentRemoteServer = __ServersManager.GetRemoteServer ( ) ;
               remoteScp = GetScp ( currentRemoteServer ) ;
               
               cMoveScu  = GetScu ( __ServersManager.Gateway.Server ) ;
               
               try
               {
                  RegisterEvents ( cMoveScu ) ;

                  if (cMoveScu.SecurityMode == DicomNetSecurityMode.Tls)
                  {
                     // Set the TLS certificate
                     cMoveScu.SetTlsClientCertificate(
                        GatewaySession.DicomSecurityAgent.CertificateFileName,
                        GatewaySession.DicomSecurityAgent.CertificateType,
                        GatewaySession.DicomSecurityAgent.KeyFileName.Length > 0 ? GatewaySession.DicomSecurityAgent.KeyFileName : null);
                  }

                  __CMoveScu = cMoveScu ;
                  
                  __CurrentStatus = DicomCommandStatusType.Success ;
                  
                  __CurrentRequest     = new MoveRequestInformation ( request ) ;
                  __MovedInstances     = new List<string> ( ) ;
                  __ForwardedInstances = new List<string> ( ) ;
                  
                  ServerEventBroker.Instance.Subscribe <CStoreRequestReceivedEventArgs> ( OnReceiveCStoreRequest ) ;
                  ServerEventBroker.Instance.Subscribe <CStoreResponseSentEventArgs>    ( OnSendCStoreResponse ) ;
                  
                  try
                  {
                     GatewaySession.Log ( client, DicomCommandType.CMove, LogType.Information, MessageDirection.Output, request, 
                                          "[Gateway] Sending C-Move request to remote server \"" + currentRemoteServer.AETitle + "\"" ) ;
                     
                     cMoveScu.Move ( remoteScp, __ServersManager.Gateway.Server.AETitle, request ) ;
                     
                     GatewaySession.Log ( client, DicomCommandType.CMove, LogType.Information, MessageDirection.Output, request, 
                                          "[Gateway] C-Move request sent successfully \"" + currentRemoteServer.AETitle + "\"" ) ;
                  }
                  finally
                  {
                     ServerEventBroker.Instance.Unsubscribe <CStoreRequestReceivedEventArgs> ( OnReceiveCStoreRequest ) ;
                     ServerEventBroker.Instance.Unsubscribe <CStoreResponseSentEventArgs>    ( OnSendCStoreResponse ) ;
                  }
                  
                  break ;
               }
               catch ( ClientConnectionException exception )
               {
                  GatewaySession.Log ( client, DicomCommandType.CMove, LogType.Warning, MessageDirection.None, null, "[Gateway] Connecting to server failed \"" + currentRemoteServer.AETitle + "\"\n" + exception.Message ) ;
                  
                  __ServersManager.SetRemoteServerConnectionFailure ( ) ;
                  
                  if ( countOfServersConnection >= __ServersManager.Servers.Count ) 
                  {
                     __CurrentStatus = DicomCommandStatusType.Failure ;
                  }
               }
               catch ( ClientCommunicationException exception ) 
               {
                  //Don't update the status, just log a message here 
                  //__CurrentStatus = exception.Status ;
                  
                  GatewaySession.Log ( client, DicomCommandType.CMove, LogType.Warning, MessageDirection.None, null, "[Gateway] Problem occured moving from server \"" + currentRemoteServer.AETitle + "\"\n" + exception.Message ) ;
                  
                  break ;
               }
               catch ( DicomException exception ) 
               {
                  if ( __CurrentStatus == DicomCommandStatusType.Success )
                  {
                     __CurrentStatus = DicomCommandStatusType.Failure ;
                  }
                  
                  GatewaySession.Log ( client, DicomCommandType.CMove, LogType.Error, MessageDirection.None, null, "[Gateway] Sending to server failed \"" + currentRemoteServer.AETitle + "\"\n" + exception.Message ) ;
                  
                  break ;
               }
               catch ( Exception exception ) 
               {
                  if ( __CurrentStatus == DicomCommandStatusType.Success )
                  {
                     __CurrentStatus = DicomCommandStatusType.ProcessingFailure ;
                  }
                  
                  GatewaySession.Log ( client, DicomCommandType.CMove, LogType.Error, MessageDirection.None, null, "[Gateway] Sending to server failed \"" + currentRemoteServer.AETitle + "\"\n" + exception.Message ) ;
                  
                  break ;
               }
               finally
               {
                  UnregisterEvents ( cMoveScu ) ;
                  
                  cMoveScu.Dispose ( ) ;
                  
                  __CMoveScu = null ;
               }
            }
            
            return __CurrentStatus ;
         }
         finally
         {
            request.Dispose ( ) ;
         }
      
      }

      private void OnReceiveCStoreRequest ( object sender, CStoreRequestReceivedEventArgs request ) 
      {
         try
         {
            if ( __CurrentRequest != null && __MovedInstances != null ) 
            {
               if ( CanMoveCStoreRequest ( request ) )
               {
                  GatewaySession.Log ( __Client, DicomCommandType.CMove, LogType.Debug, MessageDirection.Output, null, 
                                       "[Gateway] Sending C-Move response to client \"" + __ClientAE + "\"" ) ;
                                       
                  lock ( _storeLock ) 
                  {
                     OnMoveDataSet ( request.RequestDataSet ) ;
                     
                     
                     GatewaySession.Log ( __Client, DicomCommandType.CMove, LogType.Debug, MessageDirection.Output, null, 
                                          "[Gateway] C-Move response sent successfully to client \"" + __ClientAE + "\"" ) ;
                  }
               }
            }
         }
         catch ( Exception ex ) 
         {
            GatewaySession.Log ( __Client, DicomCommandType.CMove, LogType.Error, MessageDirection.Output, null, 
                                 "[Gateway] Failed to send C-Move response to client \"" + __ClientAE + "\"\n"
                                 + ex.Message ) ;
         
            __CurrentStatus = DicomCommandStatusType.Failure ;
         }
      }
      
      private void OnSendCStoreResponse ( object sender,CStoreResponseSentEventArgs response ) 
      {
         try
         {
            bool process = false ;
            
            
            lock ( _instancesListLock ) 
            {
               process = ( __MovedInstances.Contains ( response.Instance ) && !__ForwardedInstances.Contains ( response.Instance ) ) ;
            }
            
            if ( process && response.Status == DicomCommandStatusType.Success ) 
            {
               if ( ServiceLocator.IsRegistered <ForwardOptions> ( ) && DataAccessServices.IsDataAccessServiceRegistered <IForwardDataAccessAgent> ( ) )
               {
                  ForwardOptions forwardOptions = ServiceLocator.Retrieve <ForwardOptions> ( ) ;
                  IForwardDataAccessAgent dataAccess = DataAccessServices.GetDataAccessService <IForwardDataAccessAgent> ( ) ;
                  
                  if ( null != forwardOptions && null != dataAccess ) 
                  {
                     DateTime? expires = null ;
                     DateTime  forwardDate = DateTime.Now ;
                     
                     
                     if ( dataAccess.IsForwarded ( response.Instance ) )
                     {
                        return ;
                     }
                     
                     if (forwardOptions.ImageHold != null && forwardOptions.ImageHold != 0)
                     {
                        switch (forwardOptions.HoldInterval)
                        {
                           case HoldInterval.Days:
                           {
                              expires = forwardDate.AddDays(forwardOptions.ImageHold.Value);
                           }
                           break ;
                           
                           case HoldInterval.Months:
                           {
                              expires = forwardDate.AddMonths(forwardOptions.ImageHold.Value);
                           }
                           break;
                           
                           default:
                           {
                              expires = forwardDate.AddYears(forwardOptions.ImageHold.Value);
                           }
                           
                           break;
                        }
                     } 
                     
                     dataAccess.SetInstanceForwarded ( response.Instance, forwardDate, expires ) ;
                  }
               }
            }
         }
         catch ( Exception ex ) 
         {
            GatewaySession.Log ( __Client, DicomCommandType.CMove, LogType.Error, MessageDirection.Output, null, "[Gateway] Failed to set instance forwarding.\n" + ex.Message ) ;
         }
      }
      
      private bool CanMoveCStoreRequest ( CStoreRequestReceivedEventArgs request )
      {
         lock ( _instancesListLock ) 
         {
            string storeSopInstanceUID = request.SopInstanceUID ;
            
            
            if ( __MovedInstances.Contains ( storeSopInstanceUID ) )
            {
               return false ;
            }
            
            if ( !String.IsNullOrEmpty ( __CurrentRequest.PatientId ) )
            {
               string patientID = request.RequestDataSet.GetValue <string> ( DicomTag.PatientID, string.Empty ) ;
               
               if ( string.Compare ( patientID, __CurrentRequest.PatientId ) != 0 ) 
               {
                  return false;
               }
            }
            
            if ( __CurrentRequest.StudyInstanceUID.Count > 0 ) 
            {
               bool found = false ;
               
               foreach ( string studyInstanceUID in __CurrentRequest.StudyInstanceUID ) 
               {
                  string storeStudyInstanceUID = request.RequestDataSet.GetValue <string> ( DicomTag.StudyInstanceUID, string.Empty ) ;
                  
                  if ( string.Compare ( storeStudyInstanceUID, studyInstanceUID ) == 0 )
                  {
                     found = true ;
                     
                     break ;
                  }
               }
               
               if ( !found ) 
               {
                  return false ;
               }
            }
            
            if ( __CurrentRequest.SeriesInstanceUID.Count > 0 ) 
            {
               bool found = false ;
               
               foreach ( string seriesInstanceUID in __CurrentRequest.SeriesInstanceUID ) 
               {
                  string storeSeriesInstanceUID = request.RequestDataSet.GetValue <string> ( DicomTag.SeriesInstanceUID, string.Empty ) ;
                  
                  if ( string.Compare ( storeSeriesInstanceUID, seriesInstanceUID ) == 0 )
                  {
                     found = true ;
                     
                     break ;
                  }
               }
               
               if ( !found ) 
               {
                  return false ;
               }
            }
            
            if ( __CurrentRequest.SopInstanceUID.Count > 0 ) 
            {
               bool found = false ;
               
               foreach ( string sopInstanceUID in __CurrentRequest.SopInstanceUID ) 
               {
                  if ( string.Compare ( storeSopInstanceUID, sopInstanceUID ) == 0 )
                  {
                     found = true ;
                     
                     break ;
                  }
               }
               
               if ( !found ) 
               {
                  return false ;
               }
            }
            
            __MovedInstances.Add ( storeSopInstanceUID ) ;
         }
         
         return true ;
      }

      private void find_PrivateKeyPassword(object sender, PrivateKeyPasswordEventArgs e)
      {
         e.PrivateKeyPassword = GatewaySession.DicomSecurityAgent.Password;
      }

      //private QueryRetrieveScu GetScu ( AeInfo server )
      //{
      //   QueryRetrieveScu scu = new QueryRetrieveScu ( );

      //   scu.AETitle          = server.AETitle ;
      //   scu.HostAddress      = IPAddress.Parse ( server.Address ) ;
      //   scu.EnableMoveToSelf = false ;

      //   return scu ;
      //}

      private QueryRetrieveScu GetScu(AeInfo server)
      {
         QueryRetrieveScu scu = null;
         bool useSecurePort = (server.Port == 0) && (server.SecurePort != 0);
         int port = useSecurePort ? server.SecurePort : server.Port;
         if (useSecurePort && GatewaySession.IsDicomSecurityAvailable())
         {
            GatewaySession.InitializeDicomSecurity(false);
            scu = new QueryRetrieveScu(string.Empty, DicomNetSecurityMode.Tls, GatewaySession._openSslOptions);
            scu.UseSecureHost = true;
            scu.SecureHostSettings = GatewaySession._openSslOptions;
            GatewaySession.SetCiphers(scu);
            GatewaySession.SetSecurityCertificates(scu);
         }

         if (scu == null)
         {
            scu = new QueryRetrieveScu();
         }

         scu.AETitle = server.AETitle;
         scu.HostAddress = IPAddress.Parse(server.Address);
         scu.EnableMoveToSelf = false;
         scu.HostPort = port;

         return scu;
      }

      public void Break ( BreakType type )
      {
         try
         {
            if ( null != __CMoveScu ) 
            {
               Cancelling = true ;
               
               __CMoveScu.CancelRequest ( ) ;
            }
         }
         catch
         {}
      }
      
      private bool Cancelling { get ; set ; }
      
      public event MoveDataSetDelegate MoveDataSet ;
      
      private void OnMoveDataSet ( DicomDataSet response ) 
      {
         if ( null != MoveDataSet )
         {
            MoveDataSet ( this, new MoveDataSetEventArgs ( response ) ) ;
         }
      }
      
      private void find_AfterConnect(object sender, AfterConnectEventArgs e)
      {
         if ( e.Error != DicomExceptionCode.Success )
         {
            throw new Leadtools.Dicom.Scu.Common.ClientConnectionException ( Constants.Exception.ConnectionFailed, 
                                                  e.Error ) ;
         }
      }

      private void find_AfterCMove ( object sender, AfterCMoveEventArgs e )
      {
         if ( ( ( e.Status != DicomCommandStatusType.Success ) &&
              ( e.Status != DicomCommandStatusType.Pending ) &&
              ( e.Status != DicomCommandStatusType.Warning ) ) )
         {
            throw new Leadtools.Dicom.Scu.Common.ClientCommunicationException ( "Move operation failed.", 
                                                                                e.Status ) ;
         }
      }

      private void find_AfterAssociateRequest(object sender, AfterAssociateRequestEventArgs e)
      {
         try
         {
            if ( e.Rejected ) 
            {
               throw new Leadtools.Dicom.Scu.Common.ClientAssociationException ( Constants.Exception.AssociationFailed, 
                                                                                 e.Reason ) ;
            }
         }
         catch ( Exception exception )
         {
            System.Diagnostics.Debug.Assert ( false, exception.Message ) ;
                           
            throw ;
         }
      }

      private DicomScp GetScp(AeInfo client)
      {
         int port = (client.Port != 0) ? client.Port : client.SecurePort;
         return new DicomScp(IPAddress.Parse(client.Address), client.AETitle, port) { Timeout = GatewaySession.Timeout };
      }

      private void RegisterEvents ( QueryRetrieveScu find ) 
      {
         try
         {
            find.AfterAssociateRequest += new AfterAssociateRequestDelegate ( find_AfterAssociateRequest ) ;
            find.AfterCMove            += new AfterCMoveDelegate   ( find_AfterCMove ) ;
            find.AfterConnect          += new AfterConnectDelegate ( find_AfterConnect ) ;
            find.PrivateKeyPassword    += find_PrivateKeyPassword;
            find.AfterSecureLinkReady  += Find_AfterSecureLinkReady;
         }
         catch ( Exception exception )
         {
            System.Diagnostics.Debug.Assert ( false, exception.Message ) ;
                           
            throw ;
         }
      }

      private void Find_AfterSecureLinkReady(object sender, AfterSecureLinkReadyEventArgs e)
      {
         DicomConnection connection = sender as DicomConnection;

         if (e.Error == DicomExceptionCode.Success)
         {
            DicomTlsCipherSuiteType cipher = connection.GetTlsCipherSuite();
            GatewaySession.Log(LogType.Information, String.Format(CFindGateway.SECURE_LINK_READY_CIPHERSUITE, cipher.GetCipherFriendlyName()));
         }
         else
         {
            GatewaySession.Log(LogType.Information, String.Format(CFindGateway.SECURE_LINK_FAILED, e.Error));
         }
      }

      private void UnregisterEvents ( QueryRetrieveScu find ) 
      {
         try
         {
            find.AfterAssociateRequest -= new AfterAssociateRequestDelegate ( find_AfterAssociateRequest ) ;
            find.AfterCMove            -= new AfterCMoveDelegate   ( find_AfterCMove ) ;
            find.AfterConnect          -= new AfterConnectDelegate ( find_AfterConnect ) ;
            find.PrivateKeyPassword    -= find_PrivateKeyPassword;
            find.AfterSecureLinkReady  -= Find_AfterSecureLinkReady;
         }
         catch ( Exception exception )
         {
            System.Diagnostics.Debug.Assert ( false, exception.Message ) ;
                           
            throw ;
         }
      }
      
      GatewayServersManager  __ServersManager     { get ;set; }
      QueryRetrieveScu       __CMoveScu           { get ;set; }
      DicomCommandStatusType __CurrentStatus      { get ; set ; } 
      MoveRequestInformation __CurrentRequest     { get ; set ; }
      List<string>           __MovedInstances     { get ; set ; }
      List<string>           __ForwardedInstances { get ; set ; }
      DicomNet               __Client { get ; set ; }
      string                 __ClientAE { get ; set ; }
      
      object _storeLock         = new object ( ) ;
      object _instancesListLock = new object ( ) ;
      
      private class MoveRequestInformation
      {
         public MoveRequestInformation ( DicomDataSet request ) 
         {
            Request    = request ;
            QueryLevel = request.GetValue <string> ( DicomTag.QueryRetrieveLevel, string.Empty ) ;
            PatientId  = request.GetValue <string> ( DicomTag.PatientID, string.Empty ) ;
            
            StudyInstanceUID  = new List<string> ( ) ;
            SeriesInstanceUID = new List<string> ( ) ;
            SopInstanceUID    = new List<string> ( ) ;
            
            string studyInstanceUID = request.GetValue <string> ( DicomTag.StudyInstanceUID, string.Empty ) ;
            
            if ( !string.IsNullOrEmpty ( studyInstanceUID ) ) 
            {
               StudyInstanceUID.AddRange ( studyInstanceUID.Split ( '\\' ) ) ;
            }
            
            string seriesInstanceUID = request.GetValue <string> ( DicomTag.SeriesInstanceUID, string.Empty ) ;
            
            if ( !string.IsNullOrEmpty ( seriesInstanceUID ) )
            {
               SeriesInstanceUID.AddRange ( seriesInstanceUID.Split ( '\\' ) ) ;
            }
            
            string sopInstanceUID = request.GetValue <string> ( DicomTag.SOPInstanceUID, string.Empty ) ;
            
            if ( !string.IsNullOrEmpty ( sopInstanceUID ) )
            {
               SopInstanceUID.AddRange ( sopInstanceUID.Split ( '\\' ) ) ;
            }
         }
         
         public DicomDataSet  Request { get ; set ; }
         public string        QueryLevel { get ; private set ; }
         public string        PatientId { get ; private set ; }
         public List <string> StudyInstanceUID { get ; private set ; }
         public List <string> SeriesInstanceUID { get ; private set ; }
         public List <string> SopInstanceUID { get ; private set ; }
      }
      
      private static class Constants
      {
         public static class Exception
         {
            public const string ConnectionFailed = "Failed to connect to server." ;
            public const string AssociationFailed = "Failed to establish an association with the server." ;
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
         if (abstractSyntax == DicomUidType.PatientRootQueryMove)
            return ExtendedNegotiation.RelationalQueries | ExtendedNegotiation.FuzzySemantics;
         return ExtendedNegotiation.None;
      }

      #endregion

      #region IPresentationContextProvider Members

      public bool IsAbstractSyntaxSupported(string abstractSyntax)
      {
         if (abstractSyntax == DicomUidType.PatientRootQueryMove || abstractSyntax == DicomUidType.PatientStudyQueryMove ||
            abstractSyntax == DicomUidType.StudyRootQueryMove)
         {
            if (!GatewaySession.HasGetwayLicense)
            {
               string message = "[Gateway] Valid license for gateway server not found.  Abstract syntax not accepted by gateway server";

               GatewaySession.Log(_Client, DicomCommandType.CMove, LogType.Error, MessageDirection.Input, null, message);
            }
            return GatewaySession.HasGetwayLicense;
         }
         return false;
      }

      public bool IsTransferSyntaxSupported(string abstractSyntax, string transferSyntax)
      {
         return IsAbstractSyntaxSupported ( abstractSyntax ) ;
      }

      #endregion
   }
}

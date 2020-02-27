// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Leadtools.Dicom.AddIn.Interfaces;
using Leadtools.Dicom;
using Leadtools.Dicom.AddIn;
using Leadtools.Dicom.Scu.Common;
using Leadtools.Dicom.AddIn.Attributes;
using Leadtools.Dicom.Scp;
using Leadtools.Dicom.Scp.Command;
using Leadtools.Dicom.Scp.Command.Configuration;
using System.Diagnostics;
using Leadtools.Medical.DataAccessLayer;
// using Leadtools.Medical.Storage.DataAccessLayer;
using Leadtools.Logging;
using Leadtools.Logging.Medical;
using Leadtools.Medical.Winforms;
using System.IO;
using Leadtools.Medical.Storage.AddIns.Configuration;
using Leadtools.Medical.Winforms.EventBrokerArgs;

#if (LEADTOOLS_V19_OR_LATER)
using Leadtools.Dicom.Common.Communication;
using Leadtools.Dicom.Common.Extensions;
#endif

namespace Leadtools.Medical.Storage.AddIns
{
   public class CStoreAddIn : IProcessCStore, IExtendedPresentationContextProvider
#if (LEADTOOLS_V20_OR_LATER)
                              , IRoleSelectionProvider
#endif
   {
      private const string OverwritePermission = "Overwrite";
      
      public CStoreAddIn  ( )
      {
         if (ServiceLocator.IsRegistered<StorageModuleConfigurationManager>())
         {
            _configurationManager = ServiceLocator.Retrieve<StorageModuleConfigurationManager>();
         }
#if (LEADTOOLS_V19_OR_LATER)
         //CStoreCommand.SaveViewPyramid = PyramidImage.Save;
         //CStoreCommand.GetPageDicomData = MedicalViewerPageInfoCache.GetPageDicomData;
         //CStoreCommand.SavePresentationInfo = MedicalViewerPageInfoCache.GetPage;

         CStoreCommand.SendMessageQueue = SendMessageQueue;
#endif
      }

#if LEADTOOLS_V19_OR_LATER
      public static bool SendMessageQueueImplementation(DicomDataSet ds, string command, string sopInstanceUid, string path)
      {
         if (ds != null)
         {
            if (ds.IsHangingProtocolDataSet())
            {
               // Filter out the hanging protocol datasets because there is no cache for these
               return true;
            }
         }
         
         bool messageQueueSuccess = true;

         {
            try
            {
               int width = 0;
               int height = 0;

               if (ds != null)
               {
                  width = ds.GetValue<int>(DicomTag.Columns, 0);
                  height = ds.GetValue<int>(DicomTag.Rows, 0);
                  if (string.IsNullOrEmpty(sopInstanceUid))
                  {
                     sopInstanceUid = ds.GetValue<string>(DicomTag.SOPInstanceUID, string.Empty);
                  }
               }
               
               MessagingQueue.Send("storageserver", "19", command, new MessagingDicomFile() { FileName = path, Width = width, Height = height, SopInstanceUID = sopInstanceUid });
            }
            catch (Exception ex)
            {
               Logger.Global.Log(string.Empty,
                                   string.Empty,
                                   0,
                                   string.Empty,
                                   string.Empty,
                                   0,
                                   DicomCommandType.Undefined,
                                   DateTime.Now,
                                   LogType.Warning,
                                   MessageDirection.None,
                                   "Message Queue Error': " + ex.Message, null, null);
               messageQueueSuccess = false;
            }
         }
         return messageQueueSuccess;
      }

      private void SendMessageQueue(DicomDataSet ds, string command, string sopInstanceUid, string path)
      {
         StorageAddInsConfiguration settings = _configurationManager.GetStorageAddInsSettings();

         if (settings.StoreAddIn.UseMessageQueue)
         {
            var messageQueueSuccess = SendMessageQueueImplementation(ds, command, sopInstanceUid, path);
            
            if (!messageQueueSuccess)
            {
               try
               {
                  const string message = "'Use Message Queue' has been disabled.  To enable, go to: Storage Settings->Options and check 'Use Message Queue'.";
                  Logger.Global.Log(string.Empty,
                                      string.Empty,
                                      0,
                                      string.Empty,
                                      string.Empty,
                                      0,
                                      DicomCommandType.Undefined,
                                      DateTime.Now,
                                      LogType.Information,
                                      MessageDirection.None,
                                      message, null, null);

                  settings.StoreAddIn.UseMessageQueue = false;
                  _configurationManager.SetStorageAddinsSettings(settings);
                  _configurationManager.Save();
               }
               catch (Exception)
               {
               }
            }
         }
      }
#endif // #if LEADTOOLS_V19_OR_LATER

      public void Start()
      {
         EventBroker.Instance.Subscribe<DicomFileImportedEventArgs>(OnDicomFileImported);
      }

      public  void Stop()
      {
         EventBroker.Instance.Unsubscribe<DicomFileImportedEventArgs>(OnDicomFileImported);
      }
      
      private void OnDicomFileImported ( object sender, DicomFileImportedEventArgs args )
      {
         if (args.Status != Leadtools.Dicom.DicomCommandStatusType.Success)
         {
            SaveFailedImportRequest(args.FilePath, args.Description);
         }
      }

      #region IProcessCStore Members

      public DicomCommandStatusType OnStore
      (
         DicomClient client, 
         byte presentationId, 
         int messageId, 
         string affectedClass, 
         string instance, 
         DicomCommandPriorityType priority, 
         string moveAE, 
         int moveMessageId, 
         DicomDataSet request
      )
      {
         try
         {
            CStoreClientSessionProxy sessionProxy ;
            DicomCommand            command  ;
            
            
            if ( request!=null && !CanStore ( client, instance ) ) 
            {
               return DicomCommandStatusType.DuplicateInstance;
            }
            
            if (!ValidateLicense(client, request))
            {
               return DicomCommandStatusType.ProcessingFailure;
            }

            _messageId      = messageId ;
            _presentationId = presentationId ;
            _clientSession  = new ClientSession ( client ) ;
            
            sessionProxy = new CStoreClientSessionProxy ( _clientSession, presentationId, messageId, affectedClass, instance, moveAE, moveMessageId ) ;
            
            if ( AddInsSession.DataAccess == null ) 
            {
               if ( null == DicomCommandFactory.GetInitializationService ( typeof ( CStoreCommand ) ) )
               {
                  DicomCommandFactory.RegisterCommandInitializationService ( typeof ( CStoreCommand ), 
                                                                             new StoreCommandInitializationService ( ) ) ;
               }
               
               command = DicomCommandFactory.GetInstance ( ).CreateCStoreCommand ( sessionProxy, request ) ;
            }
            else
            {
               StoreCommandInitializationService service ;
               
               
               service = ServiceLocator.Retrieve <StoreCommandInitializationService> ( ) ;
               command = new InstanceCStoreCommand ( sessionProxy, request, AddInsSession.DataAccess ) ;
               
               service.ConfigureCommand ( command ) ;
            }

            _clientSession.CStoreResponse += new EventHandler<CStoreResponseEventArgs> ( _clientSession_CStoreResponse ) ;
            
            byte[] value = new byte[] { 0x00, 0x01 };
            
            request.InsertElementAndSetValue ( DicomTag.FileMetaInformationVersion, value) ;
            request.InsertElementAndSetValue ( DicomTag.MediaStorageSOPClassUID, affectedClass) ;
            request.InsertElementAndSetValue ( DicomTag.MediaStorageSOPInstanceUID, instance) ;
            
            if ( request.FindFirstElement ( null, DicomTag.ImplementationClassUID, true ) == null )
            {
               request.InsertElementAndSetValue ( DicomTag.ImplementationClassUID, ( string.IsNullOrEmpty ( client.Server.ImplementationClass ) ? "1.2.840.114257.1123456" : client.Server.ImplementationClass ) ) ;
            }
            
            if ( request.FindFirstElement ( null, DicomTag.ImplementationVersionName, true ) == null )
            {
               request.InsertElementAndSetValue ( DicomTag.ImplementationVersionName, ( string.IsNullOrEmpty ( client.Server.ImplementationVersionName ) ? "LTPACSF V19" : client.Server.ImplementationVersionName ) ) ;
            }
                  
            _clientSession.ProcessCStoreRequestSync ( presentationId, messageId, affectedClass, instance, priority, moveAE, moveMessageId, command ) ;
            
            if ( _status != DicomCommandStatusType.Success ) 
            {
               SaveFailedStoreRequest ( request, _status.ToString ( ), client ) ;
            }
            
            return _status ;
         }
         catch ( Exception exception ) 
         {
            SaveFailedStoreRequest ( request, exception.Message, client ) ;
            
            throw ;
         }
         finally
         {
            if ( null != request )
            {
               request.Dispose ( ) ;
            }
         }
      }
      
      public void SaveFailedImportRequest ( string failureFile, string message )
      {
         try
         {
            StorageAddInsConfiguration settings ; 
            DirectoryInfo              failuresDirectory ;
            string                     todaysFolder ;
            string                     fileName ;
            
            settings = _configurationManager.GetStorageAddInsSettings ( ) ;
            
            if ( !settings.StoreAddIn.SaveCStoreFailures ) 
            {
               return ;
            }
            
            if ( !Directory.Exists ( settings.StoreAddIn.CStoreFailuresPath ) )
            {
               Directory.CreateDirectory ( settings.StoreAddIn.CStoreFailuresPath ) ;
            }
            
            todaysFolder = Path.Combine ( settings.StoreAddIn.CStoreFailuresPath, "ImportFailures" ) ;
            
            if ( !Directory.Exists ( todaysFolder ) )
            {
               failuresDirectory = Directory.CreateDirectory ( todaysFolder ) ;
            }
            else
            {
               failuresDirectory = new DirectoryInfo ( todaysFolder ) ;
            }
            
            fileName = Path.Combine(failuresDirectory.FullName, Path.GetFileName(failureFile));
            
            File.Copy(failureFile, fileName, true);
            
            Logger.Global.Log ( string.Empty, 
                                string.Empty, 
                                0, 
                                string.Empty, 
                                string.Empty, 
                                0, 
                                DicomCommandType.Undefined, 
                                DateTime.Now, 
                                LogType.Debug, 
                                MessageDirection.None, 
                                "DICOM File Import Failure: failed dataset copied to 'Store Failure Folder': " + fileName, null, null ) ;
         }
         catch ( Exception exception ) 
         {
            Logger.Global.Log ( string.Empty, 
                                string.Empty, 
                                0, 
                                string.Empty, 
                                string.Empty, 
                                0, 
                                DicomCommandType.Undefined, 
                                DateTime.Now, 
                                LogType.Debug, 
                                MessageDirection.None, 
                                "DICOM File Import Failure: failed dataset not copied to 'Store Failure Folder': " + exception.Message, 
                                null, 
                                null ) ;
         }
      }

      private void SaveFailedStoreRequest(DicomDataSet ds, string message, DicomClient client) 
      {
         try
         {
            StorageAddInsConfiguration settings ; 
            DirectoryInfo              failuresDirectory ;
            string                     todaysFolder ;
            string                     fileName ;
            
            settings = _configurationManager.GetStorageAddInsSettings ( ) ;
            
            if ( !settings.StoreAddIn.SaveCStoreFailures ) 
            {
               return ;
            }
            
            if ( !Directory.Exists ( settings.StoreAddIn.CStoreFailuresPath ) )
            {
               Directory.CreateDirectory ( settings.StoreAddIn.CStoreFailuresPath ) ;
            }
            
            todaysFolder = GetTodaysFolder ( ) ;
            todaysFolder = Path.Combine ( settings.StoreAddIn.CStoreFailuresPath, todaysFolder ) ;
            
            if ( !Directory.Exists ( todaysFolder ) )
            {
               failuresDirectory = Directory.CreateDirectory ( todaysFolder ) ;
            }
            else
            {
               failuresDirectory = new DirectoryInfo ( todaysFolder ) ;
            }
            
            fileName = GetNewFileName ( failuresDirectory.FullName ) ;
            
            ds.Save ( fileName, DicomDataSetSaveFlags.MetaHeaderPresent ) ;
            
            Logger.Global.Log ( ( client.Server != null ) ? client.Server.AETitle : string.Empty, 
                                ( client.Server != null ) ? client.Server.HostAddress : string.Empty, 
                                ( client.Server != null ) ? client.Server.Port : 0, 
                                ( client.IsAssociated ( ) ) ? client.AETitle : string.Empty, 
                                ( client.IsAssociated ( ) ) ? client.HostAddress : string.Empty, 
                                ( client.IsAssociated ( ) ) ? client.HostPort : 0, 
                                DicomCommandType.CStore, 
                                DateTime.Now, 
                                LogType.Debug, 
                                MessageDirection.None, 
                                "Failed C-STORE Request dataset saved to: " + fileName, null, null ) ;
         }
         catch ( Exception exception ) 
         {
            Logger.Global.Log ( ( client.Server != null ) ? client.Server.AETitle : string.Empty, 
                                ( client.Server != null ) ? client.Server.HostAddress : string.Empty, 
                                ( client.Server != null ) ? client.Server.Port : 0, 
                                ( client.IsAssociated ( ) ) ? client.AETitle : string.Empty, 
                                ( client.IsAssociated ( ) ) ? client.HostAddress : string.Empty, 
                                ( client.IsAssociated ( ) ) ? client.HostPort : 0, 
                                DicomCommandType.CStore, 
                                DateTime.Now, 
                                LogType.Debug, 
                                MessageDirection.None, 
                                "Error saving failed C-STORE Request dataset. Reason: " + exception.Message, 
                                null, 
                                null ) ;
         }
      }
      
      private string GetNewFileName ( string dir )
      {
         int    r1, r2 ;
         bool   bGenerateName = true ;
         int    counter = 0 ;
         string csSuffix = "dcm" ;
         string prefix   = "DS" ;
         string fileName = string.Empty ;

         
         while ( bGenerateName && ( counter < short.MaxValue ) )
         {
            counter++ ;
            
            r1 = _rand.Next ( ) ;
            r2 = _rand.Next ( ) ;

            fileName = prefix ;
            
            fileName += ( r2 % 0xfff ).ToString (  ) + ( r1 % 0xfff ).ToString ( ) ;
            
            fileName = Path.ChangeExtension ( fileName, csSuffix ) ;
            
            fileName = Path.Combine ( dir, fileName ) ;

            bGenerateName = File.Exists ( fileName ) ;
         }

         return fileName ;
      }
            
      private string GetTodaysFolder()
      {
         DateTime now = DateTime.Now ;
         
         return string.Format ( "{0}-{1}-{2}", now.Month, now.Day, now.Year ) ;
      }
         
      void _clientSession_CStoreResponse
      (
         object sender, 
         CStoreResponseEventArgs e
      )
      {
         _status = e.Status ;
         
         e.Handled = true ;
      }

      private bool CanStore ( DicomClient client, string sopInstanceUID )
      {
         if ( !_configurationManager.IsLoaded || _configurationManager.GetStorageAddInsSettings ( ).StoreAddIn.PreventStoringDuplicateInstance )
         {
            //try to store it, if already exists then the CStoreCommand will fail
            return true ;
         }
         else
         {
            if ( AddInsSession.DataAccess.IsCompositeInstancesExists ( sopInstanceUID ) )
            {
               if ( AddInsSession.PermissionsAgent != null )
               {
                  string[] permissions  = AddInsSession.PermissionsAgent.GetUserPermissions ( client.AETitle ) ;
                  bool     canOverwrite = permissions.Contains ( OverwritePermission ) ;

                  if ( !canOverwrite )
                  {
                     string message = string.Format ( "AE Title doesn't have overwrite permissions duplicate instance cannot be stored. SOP Value: {0}", sopInstanceUID ) ;

                     try
                     {
                        Logger.Global.Log ( client.Server.AETitle,
                                            client.Server.HostAddress,
                                            client.Server.Port,
                                            client.AETitle,
                                            client.PeerAddress,
                                            client.PeerPort,
                                            DicomCommandType.CStore,
                                            DateTime.Now,
                                            LogType.Error,
                                            MessageDirection.None,
                                            message,
                                            null,
                                            null ) ;
                     }
                     catch ( Exception )
                     {}
                  }

                  return canOverwrite ;
               }
               else
               {
                  return true ;
               }
            }
         }

         return true;
      }

      private bool ValidateLicense(DicomClient client, DicomDataSet request)
      {
         if (AddInsSession.License == null)
            return true;

         try
         {
            long count = 0;
            MatchingParameterCollection mpc = new MatchingParameterCollection() { { new MatchingParameterList() } };

            //
            // If feature not found in license, the assumption is there is no restriction.
            //
            if (!AddInsSession.License.IsFeatureValid(ServerFeatures.MaxStudiesStored))
               return true;
            else
            {
               count = AddInsSession.License.GetFeatureCount(ServerFeatures.MaxStudiesStored);               
               if (count > 0)
               {
                  string studyInstanceUID = request.GetValue<string>(DicomTag.StudyInstanceUID, string.Empty);

                  if (!string.IsNullOrEmpty(studyInstanceUID) && !AddInsSession.DataAccess.IsStudyExists(studyInstanceUID))
                  {
                     int studyCount = AddInsSession.DataAccess.FindStudiesCount(mpc);

                     if ((studyCount + 1) > count)
                     {
                        try
                        {
                           string message = string.Format("Max study limit reached, Study ({0}) not stored.  The license is restricted to storing {1} {2}.", studyInstanceUID, count, count == 1 ? "study" : "studies");

                           Logger.Global.Log(client.Server.AETitle, client.Server.HostAddress, client.Server.Port,
                                             client.AETitle, client.PeerAddress, client.PeerPort, DicomCommandType.CStore,
                                             DateTime.Now, LogType.Error, MessageDirection.None, message, null, null);
                        }
                        catch (Exception)
                        { }
                        return false;
                     }
                  }
               }
            }

            //
            // If feature not found in license, the assumption is there is no restriction.
            //
            if (!AddInsSession.License.IsFeatureValid(ServerFeatures.MaxSeriesStored))
               return true;
            else
            {
               count = AddInsSession.License.GetFeatureCount(ServerFeatures.MaxSeriesStored);
               if (count > 0)
               {
                  string seriesInstanceUID = request.GetValue<string>(DicomTag.SeriesInstanceUID, string.Empty);

                  if (!string.IsNullOrEmpty(seriesInstanceUID) && !AddInsSession.DataAccess.IsSeriesExists(seriesInstanceUID))
                  {
                     int seriesCount = AddInsSession.DataAccess.FindSeriesCount(mpc);

                     if ((seriesCount + 1) > count)
                     {
                        try
                        {
                           string message = string.Format("Max series limit reached. Series ({0}) not stored.  The license is restricted to storing {1} series.", seriesInstanceUID, count);

                           Logger.Global.Log(client.Server.AETitle, client.Server.HostAddress, client.Server.Port,
                                             client.AETitle, client.PeerAddress, client.PeerPort, DicomCommandType.CStore,
                                             DateTime.Now, LogType.Error, MessageDirection.None, message, null, null);
                        }
                        catch (Exception)
                        { }
                        return false;
                     }
                  }
               }
            }
         }
         catch (Exception e)
         {
            Logger.Global.Log(client.Server.AETitle, client.Server.HostAddress, client.Server.Port,
                              client.AETitle, client.PeerAddress, client.PeerPort, DicomCommandType.CStore,
                              DateTime.Now, LogType.Error, MessageDirection.None, e.Message, null, null);
         }
         return true;
      }

      #endregion

      #region IProcessBreak Members

      public void Break ( BreakType type )
      {
         try
         {
            if ( null != _clientSession ) 
            {
               _clientSession.ProcessCCancelRequest ( _messageId ) ;
            }
         }
         catch{}
      }

      #endregion
      
      DicomCommandStatusType _status ;
      Random _rand = new Random ( ) ;
      ClientSession _clientSession ;
      byte _presentationId = 0 ;
      int _messageId = -1 ;

      #region IPresentationContextProvider Members

      public bool IsAbstractSyntaxSupported(string abstractSyntax)
      {
         if (_configurationManager == null)
         {
            DicomServer server = ServiceLocator.Retrieve<DicomServer>();

            try
            {               
               _configurationManager = new StorageModuleConfigurationManager(true);
               _configurationManager.Load(server.ServerDirectory);
            }
            catch (Exception e)
            {
               StoreCommandInitializationService.LogEvent(e.Message, null);
            }
         }

         if (_configurationManager == null)
            return false;

         try
         {
            return _configurationManager.GetPresentationContexts().IsAbstractSyntaxSupported(abstractSyntax);
         }
         catch (Exception e)
         {
            StoreCommandInitializationService.LogEvent(e.Message + "\r\n" + e.StackTrace, null);
            return false;
         }
      }

      public bool IsTransferSyntaxSupported(string abstractSyntax, string transferSyntax)
      {
         if (_configurationManager == null)
         {
            DicomServer server = ServiceLocator.Retrieve<DicomServer>();

            try
            {               
               _configurationManager = new StorageModuleConfigurationManager(true);
               _configurationManager.Load(server.ServerDirectory);
            }
            catch (Exception e)
            {
               StoreCommandInitializationService.LogEvent(e.Message, null);
            }
         }
         if (_configurationManager == null)
            return false;

         try
         {
            return _configurationManager.GetPresentationContexts().IsTransferSyntaxSupported(abstractSyntax, transferSyntax);
         }
         catch(Exception e)
         {
            StoreCommandInitializationService.LogEvent(e.Message + "\r\n" + e.StackTrace, null);
            return false;
         }
      }

      #endregion

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
         return ExtendedNegotiation.RelationalQueries;
      }

#if (LEADTOOLS_V20_OR_LATER)
      public RoleSelectionFlags GetRoleSelection(string abstractSyntax)
      {
         // Call IsAbstractSyntaxSupported to load the _configurationManager
         if (!IsAbstractSyntaxSupported(abstractSyntax))
         {
            return RoleSelectionFlags.None;
         }

         if (_configurationManager == null)
            return RoleSelectionFlags.None;

         try
         {
            return _configurationManager.GetPresentationContexts().GetRoleSelection(abstractSyntax);
         }
         catch (Exception e)
         {
            StoreCommandInitializationService.LogEvent(e.Message + "\r\n" + e.StackTrace, null);
            return RoleSelectionFlags.None;
         }
      }
#endif // #if (LEADTOOLS_V20_OR_LATER)

      #endregion

      private StorageModuleConfigurationManager _configurationManager ;
   }
}

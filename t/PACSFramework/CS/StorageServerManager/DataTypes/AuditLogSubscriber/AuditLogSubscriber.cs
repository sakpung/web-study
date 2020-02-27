// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Leadtools.Medical.Winforms;
using Leadtools.Logging;
using Leadtools.Logging.Medical;
using Leadtools.Demos.StorageServer.UI.AdministrativeSettings.Users;
using Leadtools.Medical.Winforms.EventBrokerArgs;

namespace Leadtools.Demos.StorageServer.DataTypes
{
   class AuditLogSubscriber
   {
      public void Start ( ) 
      {
         EventBroker.Instance.Subscribe <DicomFileDeletedEventArgs>   ( OnDicomFileDeleted ) ;
         EventBroker.Instance.Subscribe <ImageFileDeletedEventArgs>   ( OnImageFileDeleted ) ;
         EventBroker.Instance.Subscribe <DicomFileImportedEventArgs>  ( OnDicomFileImported ) ;
         EventBroker.Instance.Subscribe <DeletingDicomFilesEventArgs> ( OnDeletingDicomFile ) ;
         EventBroker.Instance.Subscribe <EmptyDatabaseEventArgs>      ( OnEmptyDatabase ) ;
         EventBroker.Instance.Subscribe <CleanForwardedDatasetsEventArgs>      ( OnCleanForwardedDatasets ) ;
         EventBroker.Instance.Subscribe <MultiDicomImportEventArgs>   (OnMultiDicomImport);

#if LEADTOOLS_V20_OR_LATER
         EventBroker.Instance.Subscribe <MetadataEventArgs>   (OnGenerateMetadataEvent);
#endif
      }
      
      public void Stop ( ) 
      {
         EventBroker.Instance.Unsubscribe <DicomFileDeletedEventArgs>   ( OnDicomFileDeleted ) ;
         EventBroker.Instance.Unsubscribe <ImageFileDeletedEventArgs>   ( OnImageFileDeleted ) ;
         EventBroker.Instance.Unsubscribe <DicomFileImportedEventArgs>  ( OnDicomFileImported ) ;
         EventBroker.Instance.Unsubscribe <DeletingDicomFilesEventArgs> ( OnDeletingDicomFile ) ;
         EventBroker.Instance.Unsubscribe <EmptyDatabaseEventArgs>      ( OnEmptyDatabase ) ;
         EventBroker.Instance.Unsubscribe <CleanForwardedDatasetsEventArgs>      ( OnCleanForwardedDatasets ) ;
         EventBroker.Instance.Unsubscribe <MultiDicomImportEventArgs>   (OnMultiDicomImport);

#if LEADTOOLS_V20_OR_LATER
         EventBroker.Instance.Unsubscribe<MetadataEventArgs>(OnGenerateMetadataEvent);
#endif
      }
      
      private static void OnDicomFileDeleted ( object sender, DicomFileDeletedEventArgs args ) 
      {
         Log ( string.Format(AuditMessages.DicomFileDeleted.Message, args.FilePath) ) ;
      }
      
      private static void OnImageFileDeleted ( object sender, ImageFileDeletedEventArgs args ) 
      {
         Log ( string.Format ( AuditMessages.ImageFileDeleted.Message, args.FilePath ) ) ;
      }
      
      private static void OnDicomFileImported ( object sender, DicomFileImportedEventArgs args ) 
      {
         if (args.Status == Dicom.DicomCommandStatusType.Success)
         {
            Log(string.Format(AuditMessages.DicomFileImported.Message, args.FilePath));
         }
         else
         {
            Log(string.Format(AuditMessages.DicomFileImportedFailure.Message, args.FilePath, args.Status, args.Description), LogType.Error);
         }
      }
      
      private static void OnDeletingDicomFile ( object sender, DeletingDicomFilesEventArgs args ) 
      {
         Log ( string.Format ( AuditMessages.DeletingDicomFile.Message, UserManager.User.FriendlyName, args.Reason ) ) ;
      }
      
      private static void OnEmptyDatabase ( object sender, EmptyDatabaseEventArgs args ) 
      {
         Log ( string.Format ( AuditMessages.EmptyDatabase.Message, UserManager.User.FriendlyName, args.Reason ) ) ;
      }

      private static void OnCleanForwardedDatasets ( object sender, CleanForwardedDatasetsEventArgs args ) 
      {
         Log ( string.Format ( AuditMessages.CleanForwardedDatasets.Message, UserManager.User.FriendlyName, args.CleanCount, args.Reason ) ) ;
      }

#if LEADTOOLS_V20_OR_LATER
      private static string GetMetadataLogPrefix(MetadataEventArgs args)
      {
         string category = (args.Category == GenerateMetadataBackgroundWorker.MetadataCategory.All) ? (string.Empty) : (" " + args.Category.ToString().ToUpper());
         string prefix = args.Scope.ToString() + category;
         return prefix;
      }

      private static void LogGenerateMetadata(MetadataEventArgs args)
      {
         if (args.Command != GenerateMetadataBackgroundWorker.MetadataCommand.Generate)
            return;

         string prefix = GetMetadataLogPrefix(args);
         if (args.Finished)
         {
            if (args.Canceled)
            {
               Log(string.Format(AuditMessages.GenerateMetadataStopped.Message, prefix, args.SuccessCount, args.TotalCount));
            }
            else
            {
               Log(string.Format(AuditMessages.GenerateMetadataEnding.Message, prefix, args.SuccessCount, args.TotalCount));
            }
         }
         else
         {
            Log(string.Format(AuditMessages.GenerateMetadataStarting.Message, prefix, args.TotalCount));
         }
      }

      private static void LogDeleteMetadata(MetadataEventArgs args)
      {
         if (args.Command != GenerateMetadataBackgroundWorker.MetadataCommand.Delete)
            return;

         string prefix = string.Empty;
         if (args.Category == GenerateMetadataBackgroundWorker.MetadataCategory.Json || args.Category == GenerateMetadataBackgroundWorker.MetadataCategory.Xml)
            prefix = args.Category.ToString().ToUpper();

         Log(string.Format(AuditMessages.DeleteMetadata.Message, args.TotalCount, prefix, args.Reason));
      }

      private static void OnGenerateMetadataEvent(object sender, MetadataEventArgs args)
      {
         GenerateMetadataBackgroundWorker.MetadataCommand command = args.Command;
         switch (command)
         {
            case GenerateMetadataBackgroundWorker.MetadataCommand.Generate:
               LogGenerateMetadata(args);
               break;

            case GenerateMetadataBackgroundWorker.MetadataCommand.Delete:
               LogDeleteMetadata(args);
               break;
         }
      }
#endif // #if LEADTOOLS_V20_OR_LATER

      private static void OnMultiDicomImport ( object sender, MultiDicomImportEventArgs args )
      {
         string finalState = @"Completed";
         if (args.Cancelled)
         {
            finalState = @"Cancelled";
         }
         if (args.State == MultiDicomImportState.Starting)
         {
            Log(string.Format(AuditMessages.MultiDicomImportStarting.Message, args.TotalFileCount));
         }
         else
         {
            if (args.TotalFailed == 0)
            {
               Log(string.Format(AuditMessages.MultiDicomImportEndingSuccess.Message, finalState, args.TotalFileCount, args.TotalStored));
            }
            else
            {
               Log(string.Format(AuditMessages.MultiDicomImportEndingPartialSuccess.Message, finalState, args.TotalFileCount, args.TotalStored, args.TotalFailed));
            }
         }
      }

      private static void Log ( string message )
      {
         DicomLogEntry logEntry = new DicomLogEntry ( );

         if ( null != UserManager.User ) 
         {
            logEntry.ClientAETitle = UserManager.User.FriendlyName;
         }
         
         logEntry.LogType       = LogType.Audit;
         logEntry.Description   = message ;

         Logger.Global.Log ( logEntry ) ;
      }
      
      private static void Log ( string message, LogType logType )
      {
         DicomLogEntry logEntry = new DicomLogEntry ( );

         if ( null != UserManager.User ) 
         {
            logEntry.ClientAETitle = UserManager.User.FriendlyName;
         }
         
         logEntry.LogType       = logType;
         logEntry.Description   = message ;

         Logger.Global.Log ( logEntry ) ;
      }
   }
}

// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Leadtools.Dicom.Common.DataTypes;
using Leadtools.Dicom.Common.DataTypes.MediaCreation;
using Leadtools.Medical.DataAccessLayer;
using Leadtools.Medical.Media.DataAccessLayer;
using System.Threading;
using Leadtools.Medical.Media.AddIns.Composing;
using Leadtools.Dicom;
using Leadtools.Logging;
using Leadtools.Logging.Medical;
using System.Reflection;
using System.IO;

namespace Leadtools.Medical.Media.AddIns.Commands
{
   class CreateMediaCommand : MediaCommand, ICancelExecute
   {
      public CreateMediaCommand 
      ( 
         MediaObjectsStateService mediaService, 
         NotifyMediaCreationResult mediaCreationResultHandler 
      ) 
      : base ( mediaService ) 
      {
         __MediaCreationResultHandler = mediaCreationResultHandler ;
      }
      
      public override void Execute ( )
      {
         Canceled = false ;
         
         if ( null != MediaService && MediaService.SelectedMediaItems.Count > 0 )
         {
            IMediaCreationDataAccessAgent dataAccess ;
            Thread                        creationThread ;
            
            
            dataAccess = DataAccessServices.GetDataAccessService <IMediaCreationDataAccessAgent> ( ) ;
            
            creationThread = new Thread ( StartMediaCreation ) ;
            
            creationThread.Start ( ) ;
         }
      }
      
      public void Cancel ( ) 
      {
         Canceled = true ;
      }
      
      public bool Canceled
      {
         get ;
         private set ;
      }

      private NotifyMediaCreationResult __MediaCreationResultHandler
      {
         get ;
         set ;
      }

      private void StartMediaCreation ( )
      {
         try
         {
            IMediaCreationDataAccessAgent dataAccess ;


            //it has been canceled before execution.
            if ( Canceled ) 
            {
               Canceled = false ;
            }
            
            dataAccess  = DataAccessServices.GetDataAccessService <IMediaCreationDataAccessAgent> ( ) ;

            if ( null != dataAccess ) 
            {
               IEnumerable <MediaCreationManagement> pendingMedias ;
               
               
               pendingMedias = MediaService.SelectedMediaItems.Where   ( n=>n.ExecutionStatus.ExecutionStatus == ExecutionStatus.Pending )
                                                              .OrderBy ( n=>n.RequestInformation.Priority.Value )
                                                              .OrderByDescending ( n=>n.SopCommon.InstanceCreationDate )  ;
               
               if ( null != pendingMedias ) 
               {
                  foreach ( MediaCreationManagement mediaObject in pendingMedias.ToArray ( ) ) //.ToArray so if the collection got modified when calling the NotifyMediaObjectUpdate it won't throw an exception
                  {
                     if ( Canceled ) 
                     {
                        return ;
                     }
                     
                     mediaObject.ExecutionStatus.ExecutionStatus     = ExecutionStatus.Creating ;
                     mediaObject.ExecutionStatus.ExecutionStatusInfo = ExecutionStatusInfo.NORMAL ;
                     
                     dataAccess.UpdateMediaObjectStatus ( mediaObject.SopCommon.SOPInstanceUID, mediaObject.ExecutionStatus ) ;
                     
                     MediaService.MediaQueue.NotifyMediaObjectUpdated ( mediaObject ) ;

                     ComposeMediaObject ( mediaObject, dataAccess ) ;
                  }
               }
            }
         }
         catch ( Exception exception ) 
         {
            System.Diagnostics.Debug.Assert ( false, exception.Message ) ;
            
            Logger.Global.Log ( AddInsSession.ServerAE, 
                                AddInsSession.ServerAddress, 
                                AddInsSession.ServerPort, 
                                string.Empty, 
                                string.Empty,
                                -1,
                                DicomCommandType.Undefined,
                                DateTime.Now, 
                                LogType.Error, 
                                MessageDirection.None,
                                exception.Message,
                                null,
                                null ) ;
         }
         finally
         {
            //reset the cancel state.
            Canceled = false ;
         }
      }

      private void ComposeMediaObject
      (
         MediaCreationManagement mediaObject, 
         IMediaCreationDataAccessAgent dataAccess 
      )
      {
         try
         {
            MediaComposer                       mediaComposer ;
            GeneralPurposeCDDVDProfileProcessor processor ;
            string                              folderPath ;
            
            
            mediaComposer = new MediaComposer ( mediaObject ) ;
            processor     = new GeneralPurposeCDDVDProfileProcessor ( ) ;
            
            if ( ( null == mediaObject.IncludeDisplayApplication ||
                   mediaObject.IncludeDisplayApplication.Value == YesNo.Undefined ||
                   mediaObject.IncludeDisplayApplication.Value == YesNo.Yes ) &&
                 AddInsSession.AddInConfiguration.IncludeViewer )
            {
               processor.ViewerDirectory = AddInsSession.AddInConfiguration.ViewerDirectory ;
               processor.NonDicomFiles   = AddInsSession.AddInConfiguration.Files.ToArray ( ) ;
               processor.ViewerSize      = (int) Math.Ceiling ( AddInsSession.AddInConfiguration.ViewerSize / 0x100000 ) ;
            }
            else
            {
               string fileName ;
               
               
               fileName = AddInsSession.AddInConfiguration.RemoveViewerAutorunFile ( ) ;
               
               processor.NonDicomFiles = AddInsSession.AddInConfiguration.Files.ToArray ( ) ;
               
               if ( !string.IsNullOrEmpty ( fileName ) )
               {
                  AddInsSession.AddInConfiguration.AddViewerAutorunFile ( fileName ) ;
               }
               
               processor.ViewerSize = 0 ;
            }
            
            processor.NonDicomDirectories = AddInsSession.AddInConfiguration.Folders.ToArray ( ) ;
            processor.NonDicomObjectsSize = (int) Math.Ceiling ( AddInsSession.AddInConfiguration.FilesAndFoldersSize / 0x100000 ) ;
            
            mediaComposer.ProfileProcessors.Add ( processor ) ;
            
            folderPath = mediaComposer.ComposeMedia ( AddInsSession.AddInConfiguration.MediaFolder ) ;
            
            mediaObject.SetCreationPath ( folderPath ) ;
            
            if ( null != dataAccess )
            {
               MediaLocation mediaLocation ;
               MediaLocation[] currentMediaLocation ;
               
               mediaLocation = new MediaLocation ( ) ;
               
               mediaLocation.MediaSopInstanceUID = mediaObject.SopCommon.SOPInstanceUID ;
               mediaLocation.Location            = folderPath ;
               
               currentMediaLocation = dataAccess.FindMediaLocation ( new string[] { mediaObject.SopCommon.SOPInstanceUID } ) ;
               
               if ( null == currentMediaLocation || currentMediaLocation.Length == 0 )
               {
                  dataAccess.InsertMediaLocation ( new MediaLocation[] { mediaLocation } ) ;
               }
               else
               {
                  dataAccess.UpdateMediaLocation ( new MediaLocation[] { mediaLocation } ) ;
               }
            }
            
            NotifyResult ( mediaObject, null ) ;
         }
         catch ( Exception exception ) 
         {
            Logger.Global.Log ( AddInsSession.ServerAE, 
                                AddInsSession.ServerAddress, 
                                AddInsSession.ServerPort, 
                                string.Empty, 
                                string.Empty,
                                -1,
                                DicomCommandType.Undefined,
                                DateTime.Now, 
                                LogType.Error, 
                                MessageDirection.None,
                                exception.Message,
                                null,
                                null ) ;
                                
            if ( mediaObject.ExecutionStatus.ExecutionStatus != ExecutionStatus.Failure ) 
            {
               mediaObject.ExecutionStatus.ExecutionStatus     = ExecutionStatus.Failure ;
               mediaObject.ExecutionStatus.ExecutionStatusInfo = ExecutionStatusInfo.UNKNOWN ;
            }
            
            try
            {
               if ( null != dataAccess ) 
               {
                  dataAccess.UpdateMediaObjectStatus ( mediaObject.SopCommon.SOPInstanceUID, mediaObject.ExecutionStatus ) ;
               }
               
               MediaService.MediaQueue.NotifyMediaObjectUpdated ( mediaObject ) ;
               
               NotifyResult ( mediaObject, exception ) ;
            }
            //we don't care here if some subscriber throw an exception
            catch {}
         }
      }

      private void NotifyResult(MediaCreationManagement mediaObject, Exception error )
      {
         try
         {
            __MediaCreationResultHandler.Invoke ( mediaObject, error ) ;
         }
         catch {}
      }
   }
   
   public delegate void NotifyMediaCreationResult ( MediaCreationManagement mediaObject, Exception error ) ;
}

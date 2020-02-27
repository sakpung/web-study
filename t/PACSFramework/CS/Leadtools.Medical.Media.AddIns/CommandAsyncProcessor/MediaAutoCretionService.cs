// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Leadtools.Medical.Media.AddIns.Commands;
using Leadtools.Dicom.Scp.Media;
using Leadtools.Dicom.Common.DataTypes.MediaCreation;
using Leadtools.Dicom.Common.DataTypes;
using Leadtools.Medical.Media.AddIns.MediaBurningProcessor.Primera;
using Leadtools.Medical.Storage.DataAccessLayer;
using Leadtools.Medical.DataAccessLayer;
using Leadtools.Medical.Storage.DataAccessLayer.Configuration;
using Leadtools.Medical.Storage.DataAccessLayer.MatchingParameters;
using Leadtools.Logging;
using Leadtools.Dicom;
using Leadtools.Logging.Medical;
using Leadtools.Medical.Media.DataAccessLayer;
using Leadtools.Medical.Media.AddIns.MediaBurningProcessor;

namespace Leadtools.Medical.Media.AddIns
{
   class MediaAutoCretionService : CommandAsyncProcessor
   {
      public MediaAutoCretionService ( MediaObjectsStateService mediaStateService ) 
      {
         __MediaStateService = mediaStateService ;
         
         __MediaStateService.MediaQueue.MediaObjectUpdated += new EventHandler<MediaItemEventArgs> ( MediaQueue_MediaItemUpdated ) ;
         __MediaStateService.MediaQueue.MediaItemAdded     += new EventHandler<MediaItemEventArgs> ( MediaQueue_MediaItemUpdated ) ;
         
         Commands.Add ( new RefereshQueueCommand ( __MediaStateService, ExecutionStatus.Pending ) ) ;
         Commands.Add ( new CreateMediaCommand ( __MediaStateService, OnNotifyMediaCreationResult ) ) ;
         
         IntervalInSeconds = 900 ;
      }
      
      public IMediaBurningProcessor MediaBurningProcessor
      {
         get
         {
            return _mediaBurningProcessor ;
         }
         
         set
         {
            if ( _mediaBurningProcessor != value )
            {
               if ( null != _mediaBurningProcessor )
               {
                  _mediaBurningProcessor.MediaBurningCompleted -= new EventHandler<MediaItemEventArgs>        ( _mediaBurningProcessor_MediaBurningCompleted ) ;
                  _mediaBurningProcessor.MediaBurningFailed    -= new EventHandler<MediaItemFailureEventArgs> ( _mediaBurningProcessor_MediaBurningFailed ) ;
               }
               
               _mediaBurningProcessor = value ;
               
               if ( null != _mediaBurningProcessor )
               {
                  _mediaBurningProcessor.MediaBurningCompleted += new EventHandler<MediaItemEventArgs>        ( _mediaBurningProcessor_MediaBurningCompleted ) ;
                  _mediaBurningProcessor.MediaBurningFailed    += new EventHandler<MediaItemFailureEventArgs> ( _mediaBurningProcessor_MediaBurningFailed ) ;
               }
            }
         }
      }

      protected override void OnDisposing ( )
      {
         if ( null != MediaBurningProcessor ) 
         {
            _mediaBurningProcessor.MediaBurningCompleted -= new EventHandler<MediaItemEventArgs>        ( _mediaBurningProcessor_MediaBurningCompleted ) ;
            _mediaBurningProcessor.MediaBurningFailed    -= new EventHandler<MediaItemFailureEventArgs> ( _mediaBurningProcessor_MediaBurningFailed ) ;
            
            MediaBurningProcessor.Dispose ( ) ;
         }
         
         base.OnDisposing ( ) ;
      }
      private MediaObjectsStateService __MediaStateService
      {
         get ;
         set ;
      }
      
      private void OnNotifyMediaCreationResult 
      ( 
         MediaCreationManagement mediaObject, 
         Exception error 
      ) 
      {
         if ( null == error ) 
         {
            ExecuteProcessors ( mediaObject ) ;
         }
      }

      private void ExecuteProcessors ( MediaCreationManagement mediaObject )
      {
         try
         {
            if ( null != MediaBurningProcessor )
            {
               MediaBurningProcessor.ProcessMedia ( mediaObject, AddInsSession.MediaAutoCreationConfiguration ) ;
            }
         }
         catch ( Exception exception ) 
         {
            try
            {
               UpdateMediaObjectStatus ( mediaObject, ExecutionStatus.Failure, ExecutionStatusInfo.CHECK_MCD_OP ) ;
               
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
            catch {}
         }
      }

      private void UpdateMediaObjectStatus
      ( 
         MediaCreationManagement mediaObject, 
         ExecutionStatus status, 
         ExecutionStatusInfo statusInfo 
      )
      {
         IMediaCreationDataAccessAgent dataAccess ;
         
         
         dataAccess = DataAccessServices.GetDataAccessService <IMediaCreationDataAccessAgent> ( ) ;
         
         mediaObject.ExecutionStatus.ExecutionStatus     = status ;
         mediaObject.ExecutionStatus.ExecutionStatusInfo = statusInfo ;
         
         if ( null != dataAccess ) 
         {
            dataAccess.UpdateMediaObjectStatus ( mediaObject.SopCommon.SOPInstanceUID, mediaObject.ExecutionStatus ) ;
         }
         
         __MediaStateService.MediaQueue.NotifyMediaObjectUpdated ( mediaObject ) ;
      }
      
      void MediaQueue_MediaItemUpdated ( object sender, MediaItemEventArgs e )
      {
         if ( e.Item.ExecutionStatus.ExecutionStatus.Value == ExecutionStatus.Pending )
         {
            if ( !__MediaStateService.SelectedMediaItems.Contains ( e.Item ) )
            {
               __MediaStateService.SelectedMediaItems.Add ( e.Item ) ;
            }
         }
      }
      
      void _mediaBurningProcessor_MediaBurningCompleted ( object sender, MediaItemEventArgs e )
      {
         UpdateMediaObjectStatus ( e.Item, ExecutionStatus.Done, ExecutionStatusInfo.NORMAL ) ;
      }

      void _mediaBurningProcessor_MediaBurningFailed ( object sender, MediaItemFailureEventArgs e )
      {
         UpdateMediaObjectStatus ( e.Item, ExecutionStatus.Failure, e.ErrorInfo ) ;
      }
      
      private IMediaBurningProcessor _mediaBurningProcessor ;
   }
}

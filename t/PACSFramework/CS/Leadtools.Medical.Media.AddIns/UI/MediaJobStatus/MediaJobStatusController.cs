// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Leadtools.Dicom.Scp.Media;
using Leadtools.Medical.Media.AddIns.UI;
using Leadtools.Medical.Media.AddIns.Commands;
using System.Threading;
using Leadtools.Dicom.Common.DataTypes.MediaCreation;
using Leadtools.Dicom.Common.DataTypes;
using Leadtools.Dicom.Common.Extensions ;
using Leadtools.Dicom;
using Leadtools.Dicom.AddIn;

namespace Leadtools.Medical.Media.AddIns
{
   class MediaJobStatusController
   {
      ~MediaJobStatusController ( )
      {
         
      }
      #region Public
         
         #region Methods
         
            public MediaJobStatusController 
            ( 
               IMediaJobStatusView view, 
               MediaObjectsStateService queueService,
               SynchronizationContext syncContext
            ) 
            {
               View                = view ;
               QueueService        = queueService ;
               __SyncContext       = syncContext ;
               __CreatingMediaJobs = new List<MediaCreationManagement> ( ) ;
               __ServicesState     = ServiceLocator.Retrieve <MediaServicesState> ( ) ;
               
               
               View.Load                      += new EventHandler ( view_Load ) ;
               View.DeleteMedia               += new EventHandler ( View_DeleteMedia ) ;
               View.RefreshMediaQueue         += new EventHandler ( View_RefreshMediaQueue ) ;
               View.CreateMedia               += new EventHandler ( view_CreateMedia ) ;
               View.RecreateMedia             += new EventHandler ( view_RecreateMedia ) ;
               View.BurnActiveMedia           += new EventHandler ( View_BurnActiveMedia ) ;

               QueueService.MediaQueue.MediaItemRemoved   += new EventHandler<MediaItemEventArgs> ( MediaQueue_MediaItemRemoved ) ;
               QueueService.MediaQueue.MediaItemAdded     += new EventHandler<MediaItemEventArgs> ( MediaQueue_MediaItemAdded ) ;
               QueueService.MediaQueue.MediaObjectUpdated += new EventHandler<MediaItemEventArgs> ( MediaQueue_MediaObjectUpdated ) ;
               QueueService.MediaQueue.MediaQueueCleared  += new EventHandler                     ( MediaQueue_MediaQueueCleared ) ;
               
               QueueService.SelectedMediaItems.MediaItemRemoved   += new EventHandler<MediaItemEventArgs> ( SelectedMediaQueue_Change ) ;
               QueueService.SelectedMediaItems.MediaItemAdded     += new EventHandler<MediaItemEventArgs> ( SelectedMediaQueue_Change ) ;
               QueueService.SelectedMediaItems.MediaObjectUpdated += new EventHandler<MediaItemEventArgs> ( SelectedMediaQueue_Change ) ;
               QueueService.SelectedMediaItems.MediaQueueCleared  += new EventHandler                     ( SelectedMediaQueue_Change ) ;

               QueueService.ActiveMediaItemChanged += new EventHandler ( QueueService_ActiveMediaItemChanged ) ;

               __ServicesState.AutoCreationServiceStateChanged     += new EventHandler ( __ServicesStateChanged ) ;
               __ServicesState.MediaMaintenanceServiceStateChanged += new EventHandler ( __ServicesStateChanged ) ;
            }
            
            
            public void TearDown ( ) 
            {
               View.Load              -= new EventHandler ( view_Load ) ;
               View.DeleteMedia       -= new EventHandler ( View_DeleteMedia ) ;
               View.RefreshMediaQueue -= new EventHandler ( View_RefreshMediaQueue ) ;
               View.CreateMedia       -= new EventHandler ( view_CreateMedia ) ;
               View.RecreateMedia     -= new EventHandler ( view_RecreateMedia ) ;
               View.BurnActiveMedia   -= new EventHandler ( View_BurnActiveMedia ) ;
               
               QueueService.MediaQueue.MediaItemRemoved   -= new EventHandler<MediaItemEventArgs> ( MediaQueue_MediaItemRemoved ) ;
               QueueService.MediaQueue.MediaItemAdded     -= new EventHandler<MediaItemEventArgs> ( MediaQueue_MediaItemAdded ) ;
               QueueService.MediaQueue.MediaObjectUpdated -= new EventHandler<MediaItemEventArgs> ( MediaQueue_MediaObjectUpdated ) ;
               QueueService.MediaQueue.MediaQueueCleared  -= new EventHandler                     ( MediaQueue_MediaQueueCleared ) ;
               
               QueueService.SelectedMediaItems.MediaItemRemoved   -= new EventHandler<MediaItemEventArgs> ( SelectedMediaQueue_Change ) ;
               QueueService.SelectedMediaItems.MediaItemAdded     -= new EventHandler<MediaItemEventArgs> ( SelectedMediaQueue_Change ) ;
               QueueService.SelectedMediaItems.MediaObjectUpdated -= new EventHandler<MediaItemEventArgs> ( SelectedMediaQueue_Change ) ;
               QueueService.SelectedMediaItems.MediaQueueCleared  -= new EventHandler                     ( SelectedMediaQueue_Change ) ;

               QueueService.ActiveMediaItemChanged -= new EventHandler ( QueueService_ActiveMediaItemChanged ) ;

               __ServicesState.AutoCreationServiceStateChanged     -= new EventHandler ( __ServicesStateChanged ) ;
               __ServicesState.MediaMaintenanceServiceStateChanged -= new EventHandler ( __ServicesStateChanged ) ;
            
               View.TearDown ( ) ;
               
               View = null ;
            }

         #endregion
         
         #region Properties
         
            public IMediaJobStatusView View
            {
               get ;
               private set ;
            }
            
            public MediaObjectsStateService QueueService
            {
               get ;
               private set ;
            }
            
         #endregion
         
         #region Events
            
         #endregion
         
         #region Data Types Definition
            
         #endregion
         
         #region Callbacks
            
            public event EventHandler BurnActiveMedia ;
            
         #endregion
         
      #endregion
      
      #region Protected
         
         #region Methods
            
         #endregion
         
         #region Properties
            
         #endregion
         
         #region Events
            
         #endregion
         
         #region Data Members
            
         #endregion
         
         #region Data Types Definition
            
         #endregion
         
      #endregion
      
      #region Private
         
         #region Methods
         
            private void OnNotifyMediaCreationResult
            ( 
               MediaCreationManagement mediaObject, 
               Exception error 
            ) 
            {
               try
               {
                  __SyncContext.Send ( new SendOrPostCallback ( delegate ( object state ) 
                  {
                     try
                     { 
                        if ( __CreatingMediaJobs.Contains ( mediaObject ) )
                        {
                           __CreatingMediaJobs.Remove ( mediaObject ) ;
                        }
                        
                        if ( null != error ) 
                        {
                           View.NotifyMediaCreationError ( mediaObject, error ) ;
                        }
                        else
                        {
                           View.NotifyMediaCreationSuccess ( mediaObject ) ;
                        }
                        
                        UpdateViewUI ( ) ;
                        
                     }
                     catch ( Exception exception ) 
                     {
                        System.Diagnostics.Debug.Assert ( false, exception.Message ) ;
                     }
                  } ),  null ) ;
               }
               catch ( Exception exception ) 
               {
                  System.Diagnostics.Debug.Assert ( false, exception.Message ) ;
               }
            }
            
            private void UpdateViewUI ( )
            {
               bool canCreate ;
               bool canDelete ;
               bool canRecreate ;
               
               GetUIStatus ( out canCreate, out canDelete, out canRecreate )  ;
               
               View.CanCreateSelected   = canCreate ;
               View.CanRecreateSelected = canRecreate ;
               View.CanDeleteSelected   = canDelete ;
               View.CanBurn             = CanBurn ;
            }
            
            private void GetUIStatus ( out bool canCreate, out bool canDelete, out bool canRecreate ) 
            {
               canCreate   = true ;
               canDelete   = true ;
               canRecreate = true ;
               
               if ( QueueService.SelectedMediaItems.Count == 0 || 
                    __ServicesState.AutoCreationServiceEnabled ||
                    __ServicesState.MediaMaintenanceServiceEnabled )
               {
                  canCreate   = false ;
                  canDelete   = false ;
                  canRecreate = false ;
                  
                  return ;
               }
               else
               {
                  foreach ( MediaCreationManagement mediaObject in QueueService.SelectedMediaItems ) 
                  {
                     if ( mediaObject.ExecutionStatus.ExecutionStatus != ExecutionStatus.Pending )
                     {
                        canCreate = false ;
                     }
                     
                     if ( __CreatingMediaJobs.Contains ( mediaObject ) )
                     {
                        canDelete = false ;
                     }
                     
                     if ( !CanRecreate ( mediaObject ) )
                     {
                        canRecreate = false ;
                     }
                     
                     if ( !canRecreate && !canDelete && !canRecreate ) 
                     {
                        return ;
                     }
                  }
               }
            }
            
            private bool CanRecreate ( MediaCreationManagement mediaObject ) 
            {
               if ( mediaObject.ExecutionStatus == null ||
                    mediaObject.ExecutionStatus.ExecutionStatus == ExecutionStatus.Undefined ||
                    mediaObject.ExecutionStatus.ExecutionStatus == ExecutionStatus.Idle || 
                    mediaObject.ExecutionStatus.ExecutionStatus == ExecutionStatus.Pending ) 
               {
                  return false ;
               }
               else if ( mediaObject.ExecutionStatus.ExecutionStatus == ExecutionStatus.Creating )
               {
                  if ( !string.IsNullOrEmpty ( mediaObject.GetCreationPath ( ) ) ||
                       __CreatingMediaJobs.Contains ( mediaObject )  )
                  {
                     return false ;
                  }
               }
               else if ( mediaObject.ExecutionStatus.ExecutionStatus == ExecutionStatus.Failure )
               {
                  switch ( mediaObject.ExecutionStatus.ExecutionStatusInfo ) 
                  {
                     case ExecutionStatusInfo.DUPL_REF_INST:
                     case ExecutionStatusInfo.INST_AP_CONFLICT:
                     case ExecutionStatusInfo.INST_OVERSIZED:
                     case ExecutionStatusInfo.NO_INSTANCE:
                     case ExecutionStatusInfo.NOT_SUPPORTED:
                     {
                        return false ;
                     }
                     
                  }
               }
               
               return true ;
            }
            
            private void OnBurnActiveMedia ( ) 
            {
               if ( null != BurnActiveMedia ) 
               {
                  BurnActiveMedia ( this, EventArgs.Empty ) ;
               }
            }
            
         #endregion
         
         #region Properties
         
            private SynchronizationContext __SyncContext
            {
               get ;
               set ;
            }
            
            private List<MediaCreationManagement> __CreatingMediaJobs
            {
               get ;
               set ;
            }
            
            private bool CanBurn
            {
               get
               {
                  return ( null != QueueService.ActiveMediaItem && 
                           QueueService.ActiveMediaItem.ExecutionStatus.ExecutionStatus == ExecutionStatus.Creating &&
                           !string.IsNullOrEmpty ( QueueService.ActiveMediaItem.GetCreationPath ( ) ) &&
                           !__ServicesState.AutoCreationServiceEnabled &&
                           !__ServicesState.MediaMaintenanceServiceEnabled ) ;
               }
            }
            
            private MediaServicesState __ServicesState
            {
               get ;
               set ;
            }
            
         #endregion
         
         #region Events
         
            void view_Load ( object sender, EventArgs e )
            {
               View.LoadMedia ( QueueService ) ;
               
               UpdateViewUI ( ) ;
               
               InformServicesStateToUser ( ) ;
            }
            
            void View_DeleteMedia ( object sender, EventArgs e )
            {
               DeleteMediaCommand deleteMedia ;
               
               
               deleteMedia = new DeleteMediaCommand ( QueueService ) ;
               
               deleteMedia.Execute ( ) ;
            }
            
            void View_RefreshMediaQueue ( object sender, EventArgs e )
            {
               RefereshQueueCommand refereshCommand ;
            
               
               refereshCommand = new RefereshQueueCommand ( QueueService ) ;
               
               refereshCommand.Execute ( ) ;
            }
            
            void view_CreateMedia ( object sender, EventArgs e )
            {
               CreateMediaCommand addMediaToProcessingQueueCommand ;
               
               
               addMediaToProcessingQueueCommand = new CreateMediaCommand ( QueueService, OnNotifyMediaCreationResult ) ;
               
               addMediaToProcessingQueueCommand.Execute ( ) ;
            }
            
            void view_RecreateMedia ( object sender, EventArgs e )
            {
               foreach ( MediaCreationManagement mediaObject in QueueService.SelectedMediaItems )
               {
                  if ( CanRecreate ( mediaObject ) )
                  {
                     mediaObject.ExecutionStatus.ExecutionStatus     = ExecutionStatus.Pending ;
                     mediaObject.ExecutionStatus.ExecutionStatusInfo = ExecutionStatusInfo.QUEUED ;
                  }
               }
                  
               view_CreateMedia ( sender, e ) ;
            }
            
            void View_BurnActiveMedia(object sender, EventArgs e)
            {
               if ( CanBurn ) 
               {
                  OnBurnActiveMedia ( ) ;
               }
            }
            
            void MediaQueue_MediaQueueCleared ( object sender, EventArgs e )
            {
               try
               {
                  __SyncContext.Send ( new SendOrPostCallback ( delegate ( object state ) 
                     { 
                        try
                        {
                           __CreatingMediaJobs.Clear     ( ) ;
                           
                           View.OnMediaObjectsCleared ( ) ; 
                        }
                        catch ( Exception exception ) 
                        {
                           System.Diagnostics.Debug.Assert ( false, exception.Message ) ;
                        }
                     } 
                  ), null ) ;
               }
               catch {}
            }

            void MediaQueue_MediaObjectUpdated ( object sender, MediaItemEventArgs e )
            {
               try
               {
                  __SyncContext.Send ( new SendOrPostCallback ( delegate ( object state ) 
                     { 
                        try
                        {
                           if ( e.Item.ExecutionStatus.ExecutionStatus == ExecutionStatus.Creating &&
                                string.IsNullOrEmpty ( e.Item.GetCreationPath ( ) ) &&
                                !__CreatingMediaJobs.Contains ( e.Item ) )
                           {
                              __CreatingMediaJobs.Add ( e.Item ) ;
                           }
                           
                           View.OnMediaObjectStatusUpdated ( e.Item ) ; 
                           
                           if ( QueueService.SelectedMediaItems.Contains ( e.Item ) )
                           {
                              UpdateViewUI ( ) ;
                           }
                        }
                        catch ( Exception exception ) 
                        {
                           System.Diagnostics.Debug.Assert ( false, exception.Message ) ;
                        }
                     } 
                  ), null ) ;
               }
               catch {}
            }

            void MediaQueue_MediaItemAdded ( object sender, MediaItemEventArgs e )
            {
               try
               {
                  __SyncContext.Send ( new SendOrPostCallback ( delegate ( object state ) 
                     { 
                        try
                        {
                           View.OnMediaObjectAdded ( e.Item ) ; 
                        }
                        catch ( Exception exception ) 
                        {
                           System.Diagnostics.Debug.Assert ( false, exception.Message ) ;
                        }
                     } 
                  ), null ) ;
               }
               catch {}
            }

            void MediaQueue_MediaItemRemoved ( object sender, MediaItemEventArgs e )
            {
               try
               {
                  __SyncContext.Send ( new SendOrPostCallback ( delegate ( object state ) 
                     { 
                        try
                        {
                           if ( __CreatingMediaJobs.Contains ( e.Item ) )
                           {
                              __CreatingMediaJobs.Remove ( e.Item ) ;
                           }
                           
                           View.OnMediaObjectRemoved ( e.Item ) ; 
                        }
                        catch ( Exception exception ) 
                        {
                           System.Diagnostics.Debug.Assert ( false, exception.Message ) ;
                        }
                     } 
                  ), null ) ;
               }
               catch {}
            }
            
            
            ///////////////////////
            
            
            void SelectedMediaQueue_Change ( object sender, EventArgs e )
            {
               try
               {
                  __SyncContext.Send ( new SendOrPostCallback ( delegate ( object state ) 
                     {
                        try
                        {
                           UpdateViewUI ( ) ;
                        }
                        catch ( Exception exception ) 
                        {
                           System.Diagnostics.Debug.Assert ( false, exception.Message ) ;
                        }
                     } 
                  ), null ) ;
               }
               catch {}
            }
            
            void QueueService_ActiveMediaItemChanged(object sender, EventArgs e)
            {
               try
               {
                  DicomDataSet mediaDataSet = null ;
                  DicomDataSet oldDataSet   = null ;
                  
                  
                  if ( QueueService.ActiveMediaItem != null ) 
                  {
                     mediaDataSet = new DicomDataSet ( ) ;
                     
                     mediaDataSet.Set ( QueueService.ActiveMediaItem ) ;
                  }
                  
                  oldDataSet = View.DetailesDataSet ;
                  
                  __SyncContext.Send ( new SendOrPostCallback ( delegate 
                  { 
                     try
                     {
                        View.DetailesDataSet = mediaDataSet ; 
                        //View.SelectedMediaObject = QueueService.ActiveMediaItem ;
                     }
                     catch ( Exception exception ) 
                     {
                        System.Diagnostics.Debug.Assert ( false, exception.Message ) ;
                     }
                  } ), null ) ;
                  
                  if ( null != oldDataSet ) 
                  {
                     oldDataSet.Dispose ( ) ;
                  }
                  
                  UpdateViewUI ( ) ;
               }
               catch ( Exception exception ) 
               {
                  System.Diagnostics.Debug.Assert ( false, exception.Message ) ;
               }
            }
            
            void __ServicesStateChanged ( object sender, EventArgs e )
            {
               try
               {
                  InformServicesStateToUser ( ) ;
                  
                  UpdateViewUI ( ) ;
               }
               catch {}
            }

            private void InformServicesStateToUser ( )
            {
               if ( __ServicesState.MediaMaintenanceServiceEnabled || 
                    __ServicesState.AutoCreationServiceEnabled )
               {
                  __SyncContext.Send ( new SendOrPostCallback ( delegate ( object state ) 
                  { 
                     try
                     {
                        View.ShowUserAlert ( _serviceStateAlert ) ;
                     }
                     catch ( Exception exception ) 
                     {
                        System.Diagnostics.Debug.Assert ( false, exception.Message ) ;
                     }
                  } ), null ) ;
               }
               else if ( !__ServicesState.MediaMaintenanceServiceEnabled && 
                         !__ServicesState.AutoCreationServiceEnabled )
               {
                  __SyncContext.Send ( new SendOrPostCallback ( delegate ( object state ) 
                  { 
                     try
                     {
                        View.HideUserAlert ( ) ;
                     }
                     catch ( Exception exception ) 
                     {
                        System.Diagnostics.Debug.Assert ( false, exception.Message ) ;
                     }
                  } ), null ) ;
               }
            }

         #endregion
         
         #region Data Members
            
            private const string _serviceStateAlert = "The Delete, Create, Re-create and Burn features are disabled because either the Media Maintenance, Auto Media Creation service or both are enabled. To enable these features make sure these services are disabled and save your changes." ;
            
         #endregion
         
         #region Data Types Definition
            
         #endregion
         
      #endregion
      
      #region internal
         
         #region Methods
            
         #endregion
         
         #region Properties
            
         #endregion
         
         #region Events
            
         #endregion
         
         #region Data Types Definition
            
         #endregion
         
         #region Callbacks
            
         #endregion
         
      #endregion
   }
}

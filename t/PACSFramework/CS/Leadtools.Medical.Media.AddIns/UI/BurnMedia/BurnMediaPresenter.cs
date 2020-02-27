// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Leadtools.MediaWriter;
using Leadtools.Dicom.Common.DataTypes;
using Leadtools.Medical.Media.DataAccessLayer;
using Leadtools.Medical.DataAccessLayer;
using Leadtools.Dicom.Common.DataTypes.MediaCreation;

namespace Leadtools.Medical.Media.AddIns
{
   public class BurnMediaPresenter
   {
      #region Public
         
         #region Methods
         
            public BurnMediaPresenter 
            ( 
               IBurnMediaView view, 
               MediaObjectsStateService mediaService,
               SynchronizationContext syncContext
            )
            {
               View = view ;
               
               Status              = BurnStatus.None ;
               DriveService        = new MediaDrivesService ( ) ;
               MediaService        = mediaService ;
               __ActiveMediaObject = MediaService.ActiveMediaItem ;
               __SyncContext = syncContext ;
               
               _progressCompletedEvent = new AutoResetEvent ( false ) ;
               
               View.Load += new EventHandler ( View_Load ) ;

               View.SelectedDriveChanged += new EventHandler ( View_SelectedDriveChanged ) ;
               View.SelectedSpeedChanged += new EventHandler ( View_SelectedSpeedChanged ) ;
               View.VolumeNameChanged    += new EventHandler ( View_VolumeNameChanged ) ;
               View.Eject                += new EventHandler ( View_Eject ) ;
               View.Cancel               += new EventHandler ( View_Cancel ) ;
               View.Test                 += new EventHandler ( View_Test ) ;
               View.Burn                 += new EventHandler ( View_Burn ) ;

               DriveService.SelectedDriveChanged       += new EventHandler ( DriveService_SelectedDriveChanged ) ;
               DriveService.SelectedDriveSpeedChanged  += new EventHandler ( DriveService_SelectedDriveSpeedChanged ) ;
               DriveService.SpeedsChanged              += new EventHandler ( DriveService_SpeedsChanged ) ;
               DriveService.SelectedDriveStateChanged  += new EventHandler ( DriveService_SelectedDriveStateChanged ) ;
            }

            public void TearDown ( )
            {
               View.Load -= new EventHandler ( View_Load ) ;

               View.SelectedDriveChanged -= new EventHandler ( View_SelectedDriveChanged ) ;
               View.SelectedSpeedChanged -= new EventHandler ( View_SelectedSpeedChanged ) ;
               View.Eject                -= new EventHandler ( View_Eject ) ;
               View.Cancel               -= new EventHandler ( View_Cancel ) ;
               View.Test                 -= new EventHandler ( View_Test ) ;
               View.Burn                 -= new EventHandler ( View_Burn ) ;

               DriveService.SelectedDriveChanged       -= new EventHandler ( DriveService_SelectedDriveChanged ) ;
               DriveService.SelectedDriveSpeedChanged  -= new EventHandler ( DriveService_SelectedDriveSpeedChanged ) ;
               DriveService.SpeedsChanged              -= new EventHandler ( DriveService_SpeedsChanged ) ;
               DriveService.SelectedDriveStateChanged  -= new EventHandler ( DriveService_SelectedDriveStateChanged ) ;
               
               View.CleanUp ( ) ;
               
               View = null ;
               
               DriveService.Dispose ( ) ;
            }

         #endregion
         
         #region Properties
         
            public IBurnMediaView View
            {
               get ;
               private set ;
            }
            
            public MediaDrivesService DriveService
            {
               get ;
               private set ;
            }
            
            public MediaObjectsStateService MediaService
            {
               get ;
               private set ;
            }
            
            public BurnStatus Status
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
            
         #endregion
         
      #endregion
      
      #region Protected
         
         #region Methods
            
         #endregion
         
         #region Properties
         
            public bool IsProcessing
            {
               get ;
               private set ;
            }
            
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
         
            private void UpdateUI ( )
            {
               __SyncContext.Send ( new SendOrPostCallback ( delegate {
               
                  View.CanBurn   = CanBurn ;
                  View.CanCancel = CanCancel ;
                  View.CanEject  = CanEject ;
                  View.CanTest   = CanTest ;
               } ),null ) ;
            }
            
            private MediaWriterDisc GetMediaDisc ( )
            {
               MediaWriterDisc disc ;
               
               
               disc = DriveService.SelectedDrive.CreateDisc ( ) ;
               
               disc.SourcePathName = __ActiveMediaObject.GetCreationPath ( ) ;
               disc.VolumeName     = __ActiveMediaObject.MediaSet.FileSetID ;
               
               return disc ;
            }
            
            private void StartTesting ( object state )
            {
               using ( MediaWriterDisc disc = GetMediaDisc ( ) )
               {
                  IsProcessing = true ;
                  
                  DriveService.SelectedDrive.OnProgress += new EventHandler<MediaWriterProgressEventArgs> ( SelectedDrive_OnProgress ) ;
                  
                  try
                  {
                     DriveService.SelectedDrive.AutoEject = false ;
                     
                     __FinalState = MediaWriterProgress.OperationProgressIdle ;
                     
                     DriveService.SelectedDrive.TestBurnDisc ( disc ) ;
                     
                     UpdateUI ( ) ;
                     
                     _progressCompletedEvent.WaitOne ( ) ;
                     
                     if ( __FinalState == MediaWriterProgress.OperationProgressAborted ) 
                     {
                        OnTestAborted ( ) ;
                     }
                     else
                     {
                        OnTestCompleted ( ) ;
                     }
                  }
                  catch ( Exception exception ) 
                  {
                     OnTestFailed ( exception ) ;
                  }
                  finally
                  {
                     //TODO:remove this when they fix the media writer problem
                     Thread.Sleep ( _statusUpdateTime ) ;
                     DriveService.SelectedDrive.OnProgress -= new EventHandler<MediaWriterProgressEventArgs> ( SelectedDrive_OnProgress ) ;
                     
                     IsProcessing = false ;
                  }
               }
            }

            private void StartBurning ( object state )
            {
               
               try
               {
                  IsProcessing = true ;
                  
                  DriveService.SelectedDrive.OnProgress += new EventHandler<MediaWriterProgressEventArgs> ( SelectedDrive_OnProgress ) ;
                  
                  for ( int numberOfCopies = 1; numberOfCopies <= __ActiveMediaObject.RequestInformation.NumberOfCopies; numberOfCopies++ )
                  {
                     using ( MediaWriterDisc disc = GetMediaDisc ( ) )
                     {
                        __FinalState = MediaWriterProgress.OperationProgressIdle ;
                        
                        if ( CanTest && View.AutoTest ) 
                        {
                           DoQuickTest ( disc ) ;
                        }
                        
                        DriveService.SelectedDrive.AutoEject = View.AutoEject ;
                        
                        if ( __FinalState == MediaWriterProgress.OperationProgressAborted )
                        {
                           OnBurnAborted ( ) ;
                           
                           break ;
                        }
                        
                        DriveService.SelectedDrive.BurnDisc ( disc ) ;
                        
                        UpdateUI ( ) ;
                        
                        _progressCompletedEvent.WaitOne ( ) ;
                        
                        if ( __FinalState == MediaWriterProgress.OperationProgressAborted )
                        {
                           OnBurnAborted ( ) ;
                           
                           break ;
                        }
                        else
                        {
                           if ( numberOfCopies == __ActiveMediaObject.RequestInformation.NumberOfCopies )
                           {
                              OnBurnCompleted( ) ;
                           }
                           else
                           {
                              if( !RequestUserFofNewDisc ( ) )
                              {
                                 OnBurnAborted ( ) ;
                                 
                                 break ;
                              }
                           }
                        }
                     }
                  }
               }
               catch ( Exception exception ) 
               {
                  OnBurnFailed ( exception ) ;
               }
               finally
               {
                  //TODO:remove this when they fix the media writer problem
                  Thread.Sleep ( _statusUpdateTime ) ;
                  DriveService.SelectedDrive.OnProgress -= new EventHandler<MediaWriterProgressEventArgs> ( SelectedDrive_OnProgress ) ;
                  
                  IsProcessing = false ;
               }
            }

            private void DoQuickTest ( MediaWriterDisc disc )
            {
               DriveService.SelectedDrive.AutoEject = false ;
               
               DriveService.SelectedDrive.TestBurnDisc ( disc ) ;
               
               UpdateUI ( ) ;
               
               _progressCompletedEvent.WaitOne ( ) ;
            }

            private bool RequestUserFofNewDisc ( )
            {
               bool newDiskAvailable ;
               
               
               newDiskAvailable = false ;
               
               do
               {
                  bool requestNewDisc ;
                  
                  
                  requestNewDisc = false ;
                  
                  __SyncContext.Send ( new SendOrPostCallback ( delegate {
                     requestNewDisc = View.RequestNewDisc ( ) ;
                  } ), null ) ;
                  
                  if ( requestNewDisc )
                  {
                     if ( CanBurn )
                     {
                        newDiskAvailable = true ;
                     }
                  }
                  else
                  {
                     break ;
                  }
               }
               while ( !newDiskAvailable ) ;
            
               return newDiskAvailable ;
            }

            private void OnTestFailed ( Exception exception )
            {
               Status = BurnStatus.TestFailed ;
               
               __SyncContext.Send ( new SendOrPostCallback ( delegate {
                  View.OnTestFailed ( exception ) ;
               } ), null ) ;
               
               UpdateUI ( ) ;
            }
            
            private void OnBurnFailed ( Exception exception )
            {
               Status = BurnStatus.BurnFailed ;
               
               __SyncContext.Send ( new SendOrPostCallback ( delegate {
                  View.OnBurnFailed ( exception ) ;
               } ), null ) ;
               
               UpdateUI ( ) ;
            }

            private void OnTestCompleted ( )
            {
               Status = BurnStatus.TestCompleted ;
               
               __SyncContext.Send ( new SendOrPostCallback ( delegate {
                  View.OnTestCompleted ( ) ;
               } ), null ) ;
               
               UpdateUI ( ) ;
            }
            
            private void OnBurnCompleted ( )
            {
               Status = BurnStatus.BurnCompleted ;
               
               __SyncContext.Send ( new SendOrPostCallback ( delegate {
                  View.OnBurnCompleted ( ) ;
               } ), null ) ;
               
               CompleteMediaObjectStatus ( ) ;
               
               UpdateUI ( ) ;
            }

            private void OnTestAborted ( )
            {
               Status = BurnStatus.TestAborted ;
               
               __SyncContext.Send ( new SendOrPostCallback ( delegate {
                  View.OnTestAborted ( ) ;
               } ), null ) ;
               
               UpdateUI ( ) ;
            }

            private void OnBurnAborted ( )
            {
               Status = BurnStatus.BurnAborted ;
               
               __SyncContext.Send ( new SendOrPostCallback ( delegate {
                  View.OnBurnAborted ( ) ;
               } ), null ) ;
               
               UpdateUI ( ) ;
            }
            
            private void CompleteMediaObjectStatus ( )
            {
               __ActiveMediaObject.ExecutionStatus.ExecutionStatus     = ExecutionStatus.Done ;
               __ActiveMediaObject.ExecutionStatus.ExecutionStatusInfo = ExecutionStatusInfo.NORMAL ;
               
               IMediaCreationDataAccessAgent dataAccess ;
               
               
               dataAccess = DataAccessServices.GetDataAccessService <IMediaCreationDataAccessAgent> ( ) ;
               
               if ( null != dataAccess ) 
               {
                  dataAccess.UpdateMediaObjectStatus ( __ActiveMediaObject.SopCommon.SOPInstanceUID, __ActiveMediaObject.ExecutionStatus ) ;
               }
               
               MediaService.MediaQueue.NotifyMediaObjectUpdated ( __ActiveMediaObject ) ;
            }
            
         #endregion
         
         #region Properties
         
            private MediaCreationManagement __ActiveMediaObject
            {
               get ;
               set ;
            }
            
            private SynchronizationContext __SyncContext
            {
               get ;
               set ;
            }
            
            private bool CanBurn
            {
               get
               {
                  bool isCreating ;
                  bool hasVolumeName ;
                  bool burnable ;
                  bool isIdle ;
                  
                  
                  isCreating    = __ActiveMediaObject.ExecutionStatus.ExecutionStatus == ExecutionStatus.Creating ;
                  hasVolumeName = !string.IsNullOrEmpty ( __ActiveMediaObject.MediaSet.FileSetID ) ;
                  
                  if ( DriveService.SelectedDrive != null ) 
                  {
                     burnable = DriveService.SelectedDrive.Writeable ;
                     isIdle   = DriveService.SelectedDrive.State == MediaWriterState.StateIdle ;
                  }
                  else
                  {
                     burnable = false ;
                     isIdle   = false ;
                  }
                  
                  return isCreating && hasVolumeName && burnable && isIdle ;
               }
            }
            
            private bool CanTest
            {
               get
               {
                  bool isCreating ;
                  bool hasVolumeName ;
                  bool testable ;
                  bool isIdle ;
                  
                  
                  isCreating    = __ActiveMediaObject.ExecutionStatus.ExecutionStatus == ExecutionStatus.Creating ;
                  hasVolumeName = !string.IsNullOrEmpty ( __ActiveMediaObject.MediaSet.FileSetID ) ;
                  
                  if ( DriveService.SelectedDrive != null ) 
                  {
                     testable = DriveService.SelectedDrive.TestWriteable ;
                     isIdle   = DriveService.SelectedDrive.State == MediaWriterState.StateIdle ;
                  }
                  else
                  {
                     testable = false ;
                     isIdle   = false ;
                  }
                  
                  return isCreating && hasVolumeName && testable && isIdle ;
               }
            }
            
            private bool CanCancel
            {
               get
               {
                  if ( DriveService.SelectedDrive != null ) 
                  {
                     return DriveService.SelectedDrive.State != MediaWriterState.StateIdle ;
                  }
                  else
                  {
                     return false ;
                  }
               }
            }
            
            private bool CanEject
            {
               get
               {
                  bool ejectable ;
                  bool isIdle ;
                  
                  
                  if ( DriveService.SelectedDrive != null ) 
                  {
                     ejectable = DriveService.SelectedDrive.Ejectable ;
                     isIdle   = DriveService.SelectedDrive.State == MediaWriterState.StateIdle ;
                  }
                  else
                  {
                     ejectable = false ;
                     isIdle   = false ;
                  }
                  
                  return ejectable && isIdle ;
               }
            }
            
            private MediaWriterProgress __FinalState
            {
               get ;
               set ;
            }
            
         #endregion
         
         #region Events
         
            void View_SelectedDriveChanged ( object sender, EventArgs e )
            {
               DriveService.SelectedDrive = View.SelectedDrive ;
            }
            
            void View_SelectedSpeedChanged ( object sender, EventArgs e )
            {
               DriveService.SelectedSpeed = View.SelectedSpeed ;
            }
            
            void View_VolumeNameChanged ( object sender, EventArgs e )
            {
               UpdateUI ( ) ;
            }
            
            void View_Eject ( object sender, EventArgs e )
            {
               if( CanEject )
               {
                  DriveService.SelectedDrive.EjectDisc ( ) ;
                  
                  Thread.Sleep ( _statusUpdateTime ) ;
                  
                  UpdateUI ( ) ;
               }
            }
            
            void View_Cancel ( object sender, EventArgs e )
            {
               if( CanCancel )
               {
                  if ( View.UserWantsToCancelCurrentOperation ( ) )
                  {  
                     DriveService.SelectedDrive.Cancel ( ) ;
                     
                     Thread.Sleep ( _statusUpdateTime ) ;
                     
                     UpdateUI ( ) ;
                  }
               }
            }
            
            void View_Test ( object sender, EventArgs e )
            {
               if ( CanTest )
               {
                  ThreadPool.QueueUserWorkItem ( StartTesting, null ) ;
               }
            }

            void View_Burn ( object sender, EventArgs e )
            {
               if( CanBurn )
               {
                  ThreadPool.QueueUserWorkItem ( StartBurning ) ;
               }
            }

            void SelectedDrive_OnProgress ( object sender, MediaWriterProgressEventArgs e )
            {
               __SyncContext.Send ( new SendOrPostCallback ( delegate {
               
               View.ReportProgress ( e.Complete, e.Description ) ;
               
               } ), null ) ;
               
               if ( e.Progress == MediaWriterProgress.OperationProgressAborted || 
                    e.Progress == MediaWriterProgress.OperationProgressCompleted ||
                    e.Progress == MediaWriterProgress.OperationProgressIdle )
               {
                  __FinalState = e.Progress ;
                  
                  _progressCompletedEvent.Set ( ) ;
               }
            }

            void View_Load ( object sender, EventArgs e )
            {
               View.LoadMedia ( __ActiveMediaObject ) ;
               View.SetDrives ( DriveService .Drives.ToArray ( ) ) ;
               View.SetSpeeds ( DriveService .SelectedDriveSpeeds.ToArray ( ) ) ;
               
               View.SelectedDrive = DriveService.SelectedDrive ;
               View.SelectedSpeed = DriveService.SelectedSpeed ;
               
               View.MaxProgressValue = 10000 ;
               
               UpdateUI ( ) ;
            }
            
            void DriveService_SpeedsChanged(object sender, EventArgs e)
            {
               __SyncContext.Send ( new SendOrPostCallback ( delegate ( object state ) 
                  {
                     View.SetSpeeds ( DriveService.SelectedDriveSpeeds.ToArray ( ) ) ;
                     
                     View.SelectedSpeed = DriveService.SelectedSpeed ;
                  } ), null ) ;
            }

            void DriveService_SelectedDriveChanged ( object sender, EventArgs e )
            {
               __SyncContext.Send ( new SendOrPostCallback ( delegate ( object state ) 
                  {
                     View.SelectedDrive = DriveService.SelectedDrive ;
                     
                     UpdateUI ( ) ;
                     
                  } ) , null ) ;
            }
            
            void DriveService_SelectedDriveSpeedChanged(object sender, EventArgs e)
            {
               __SyncContext.Send ( new SendOrPostCallback ( delegate ( object state ) 
               {
                  View.SelectedSpeed = DriveService.SelectedSpeed ;
               } ), null ) ;
            }
            
            void DriveService_SelectedDriveStateChanged ( object sender, EventArgs e )
            {
               __SyncContext.Send ( new SendOrPostCallback ( delegate ( object state ) 
               {
                  View.UpdateSelectedDriveInformation ( ) ;
                  
                  UpdateUI ( ) ;
                  
               } ), null ) ;
            }
            
         #endregion
         
         #region Data Members
         
            int _statusUpdateTime = 200 ;
            AutoResetEvent _progressCompletedEvent ;
            
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
   
   public enum BurnStatus
   {
      None,
      TestCompleted,
      TestFailed,
      TestAborted,
      BurnCompleted,
      BurnFailed,
      BurnAborted
   }
}

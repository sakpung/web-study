// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Leadtools.Medical.Media.DataAccessLayer;
using Leadtools.Medical.DataAccessLayer;
using Leadtools.Dicom.Common.DataTypes.MediaCreation;
using Leadtools.Dicom.Scp.Media;
using Leadtools.Dicom.Common.DataTypes;

namespace Leadtools.Medical.Media.AddIns.Commands
{
   class CleanExpiredMediaJobsCommand : ICommand, ICancelExecute
   {
      public CleanExpiredMediaJobsCommand ( MediaObjectsStateService  mediaService ) 
      {
         MediaService = mediaService ;
      }
      
      public MediaObjectsStateService  MediaService
      {
         get ;
         private set ;
      }
      
      public void Execute ( )
      {
         try
         {
            IMediaCreationDataAccessAgent dataAccess ;
               
            
            //it has been canceled before execution.
            if ( Canceled ) 
            {
               Canceled = false ;
            }
            
            if ( !AddInsSession.MaintenanceConfiguration.Enabled ||
                 MediaService.MediaQueue.Count == 0 ) 
            {
               return ;
            }
            
            dataAccess = DataAccessServices.GetDataAccessService <IMediaCreationDataAccessAgent> ( ) ;
            
            foreach ( MediaCreationManagement mediaObject in MediaService.MediaQueue.ToArray ( ) ) 
            {
               DateTime? statusUpdateDate ;
               
               
               if ( Canceled )
               {
                  return ;
               }
               
               statusUpdateDate = mediaObject.GetStatusUpdateDate ( ) ;
               
               if (  null == statusUpdateDate ) 
               {
                  continue ;
               }
               
               switch ( mediaObject.ExecutionStatus.ExecutionStatus.Value ) 
               {
                  case ExecutionStatus.Idle:
                  {
                     if ( statusUpdateDate.Value.AddMinutes ( AddInsSession.MaintenanceConfiguration.KeepIdleDurationInMinutes ) < DateTime.Now )
                     {
                        dataAccess.DeleteMediaObject   ( mediaObject ) ;
                        MediaService.MediaQueue.Remove ( mediaObject ) ;
                     }
                  }
                  break ;
                  
                  case ExecutionStatus.Pending:
                  {
                     if ( statusUpdateDate.Value.AddMinutes ( AddInsSession.MaintenanceConfiguration.KeepPendingDurationInMinutes ) < DateTime.Now )
                     {
                        dataAccess.DeleteMediaObject   ( mediaObject ) ;
                        MediaService.MediaQueue.Remove ( mediaObject ) ;
                     }
                  }
                  break ;
                  
                  case ExecutionStatus.Creating:
                  {
                     if ( statusUpdateDate.Value.AddMinutes ( AddInsSession.MaintenanceConfiguration.KeepProcessingDurationInMinutes ) < DateTime.Now )
                     {
                        dataAccess.DeleteMediaObject   ( mediaObject ) ;
                        MediaService.MediaQueue.Remove ( mediaObject ) ;
                     }
                  }
                  break ;
                  
                  case ExecutionStatus.Failure:
                  {
                     if ( statusUpdateDate.Value.AddMinutes ( AddInsSession.MaintenanceConfiguration.KeepFailedDurationInMinutes ) < DateTime.Now )
                     {
                        dataAccess.DeleteMediaObject   ( mediaObject ) ;
                        MediaService.MediaQueue.Remove ( mediaObject ) ;
                     }
                  }
                  break ;
                  
                  case ExecutionStatus.Done:
                  {
                     if ( statusUpdateDate.Value.AddMinutes ( AddInsSession.MaintenanceConfiguration.KeepCompletedDurationInMinutes ) < DateTime.Now )
                     {
                        dataAccess.DeleteMediaObject   ( mediaObject ) ;
                        MediaService.MediaQueue.Remove ( mediaObject ) ;
                     }
                  }
                  break ;
               }
            }
         }
         finally
         {
            //reset the cancel state.
            Canceled = false ;
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
   }
}

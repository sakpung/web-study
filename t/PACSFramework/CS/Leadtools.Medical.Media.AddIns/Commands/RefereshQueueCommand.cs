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
   class RefereshQueueCommand : MediaCommand
   {
      public RefereshQueueCommand ( MediaObjectsStateService mediaService )
      : this ( mediaService, null )
      {
         
      }
      
      public RefereshQueueCommand ( MediaObjectsStateService mediaService, ExecutionStatus? status )
      : base ( mediaService ) 
      {
         MediaStatus = status ;
      }
      
      public ExecutionStatus? MediaStatus
      {
         get ;
         set ;
      }
      
      public override void Execute ( ) 
      {
         IMediaCreationDataAccessAgent dataAccess ;
         
         
         dataAccess = DataAccessServices.GetDataAccessService <IMediaCreationDataAccessAgent> ( ) ;
         
         if ( null != dataAccess ) 
         {
            List <MediaCreationManagement> mediaObjects ;
            MediaCreationQueue             queue ;
            MediaCreationManagement        queryObject ;
            
            
            mediaObjects = new List<MediaCreationManagement> ( ) ;
            queue        = MediaService.MediaQueue ;
            queryObject  = new MediaCreationManagement ( ) ;
            
            
            queryObject.ExecutionStatus.ExecutionStatus = MediaStatus ;
            
            mediaObjects.AddRange ( dataAccess.FindMediaObjects ( queryObject ) ) ;
            
            foreach ( MediaCreationManagement mediaObject in mediaObjects ) 
            {
               if ( queue.Contains ( mediaObject ) )
               {
                  if ( queue [ mediaObject.SopCommon.SOPInstanceUID ].ExecutionStatus.ExecutionStatus != mediaObject.ExecutionStatus.ExecutionStatus )
                  {
                     MediaLocation[] location ;
                     
                     
                     location = dataAccess.FindMediaLocation ( new string [] { mediaObject.SopCommon.SOPInstanceUID } ) ;
                     
                     queue [ mediaObject.SopCommon.SOPInstanceUID ].ExecutionStatus = mediaObject.ExecutionStatus ;
                     
                     if ( location != null && location.Length > 0 ) 
                     {
                        queue [ mediaObject.SopCommon.SOPInstanceUID ].SetCreationPath ( location [ 0 ].Location ) ;
                     }
                     
                     queue [ mediaObject.SopCommon.SOPInstanceUID ].SetStatusUpdateDate ( dataAccess.GetStatusUpdateDate ( mediaObject.SopCommon.SOPInstanceUID ) ) ;
                     
                     queue.NotifyMediaObjectUpdated ( mediaObject.SopCommon.SOPInstanceUID ) ;
                  }
                  else if ( mediaObject.ExecutionStatus.ExecutionStatus == ExecutionStatus.Creating )
                  {
                     MediaLocation[] location ;
                     
                     
                     location = dataAccess.FindMediaLocation ( new string [] { mediaObject.SopCommon.SOPInstanceUID } ) ;
                     
                     if ( location != null && location.Length > 0 ) 
                     {
                        mediaObject.SetCreationPath ( location [ 0 ].Location ) ;
                     }
                     
                     mediaObject.SetStatusUpdateDate ( dataAccess.GetStatusUpdateDate ( mediaObject.SopCommon.SOPInstanceUID ) ) ;
                     
                     if ( queue [ mediaObject.SopCommon.SOPInstanceUID ].GetCreationPath ( ) != mediaObject.GetCreationPath ( ) || 
                         queue [ mediaObject.SopCommon.SOPInstanceUID ].GetStatusUpdateDate ( ) != mediaObject.GetStatusUpdateDate ( ) )
                     {
                        if ( location != null && location.Length > 0 )
                        {
                           queue [ mediaObject.SopCommon.SOPInstanceUID ].SetCreationPath ( location [ 0 ].Location ) ;
                        }
                        
                        queue [ mediaObject.SopCommon.SOPInstanceUID ].SetStatusUpdateDate ( mediaObject.GetStatusUpdateDate ( ).Value ) ;
                        
                        queue.NotifyMediaObjectUpdated ( mediaObject.SopCommon.SOPInstanceUID ) ;
                     }
                  }
                  
                  //this is important to dereference the objects and allow them to be garbage collectd.
                  mediaObject.SetCreationPath ( null ) ;
                  mediaObject.SetStatusUpdateDate ( null ) ; 
               }
               else
               {
                  MediaLocation[] location ;
                  
                  
                  location = dataAccess.FindMediaLocation ( new string [] { mediaObject.SopCommon.SOPInstanceUID } ) ;
                  
                  if ( location != null && location.Length > 0 ) 
                  {
                     mediaObject.SetCreationPath ( location [ 0 ].Location ) ;
                  }
                  
                  mediaObject.SetStatusUpdateDate ( dataAccess.GetStatusUpdateDate ( mediaObject.SopCommon.SOPInstanceUID ) ) ;
                  
                  queue.Add ( mediaObject ) ;
               }
            }
            
            if ( queue.Count > mediaObjects.Count ) 
            {
               foreach ( MediaCreationManagement mediaObject in queue.ToArray ( ) )
               {
                  if ( !mediaObjects.Contains ( mediaObject ) )
                  {
                     queue.Remove ( mediaObject ) ;
                     
                     if ( queue.Count == mediaObjects.Count ) 
                     {
                        break ;
                     }
                     
                     //this is important to dereference the objects and allow them to be garbage collectd.
                     mediaObject.SetCreationPath ( null ) ;
                     mediaObject.SetStatusUpdateDate ( null ) ; 
                  }
               }
            }
         }
      }
   }
}

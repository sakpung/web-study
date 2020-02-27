// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Leadtools.Dicom.Common.DataTypes.MediaCreation;
using Leadtools.Medical.Media.DataAccessLayer;
using Leadtools.Medical.DataAccessLayer;
using Leadtools.Dicom.Scp.Media;
using System.IO;

namespace Leadtools.Medical.Media.AddIns.Commands
{
   class DeleteMediaCommand : MediaCommand
   {
      public DeleteMediaCommand ( MediaObjectsStateService mediaService ) 
      : base ( mediaService ) 
      {
         
      }
      
      
      public override void Execute ( ) 
      {
         IMediaCreationDataAccessAgent dataAccess ;
         
         
         if ( null != MediaService ) 
         {
            dataAccess = DataAccessServices.GetDataAccessService <IMediaCreationDataAccessAgent> ( ) ;
            
            if ( null != dataAccess ) 
            {
               foreach ( MediaCreationManagement mediaObject in MediaService.SelectedMediaItems.ToArray ( ) ) 
               {
                  string creationPath ;
                  
                  
                  dataAccess.DeleteMediaObject ( mediaObject ) ;
                  
                  MediaService.MediaQueue.Remove ( mediaObject ) ;
                  
                  creationPath = mediaObject.GetCreationPath ( ) ;
                  
                  try
                  {
                     if ( !string.IsNullOrEmpty ( creationPath ) )
                     {
                        Directory.Delete ( creationPath, true ) ;
                     }
                  }
                  catch {}
               }
            }
         }
      }
   }
}

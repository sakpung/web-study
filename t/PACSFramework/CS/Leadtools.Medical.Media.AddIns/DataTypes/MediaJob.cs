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

namespace Leadtools.Medical.Media.AddIns
{
   class MediaJob
   {
      public MediaJob ( MediaCreationManagement mediaCreation )
      {
         MediaObject  = mediaCreation ;
      }
      
      public string MediaFileId
      {
         get 
         {
            return MediaObject.MediaSet.FileSetID ;
         }
         
      }
      
      public ExecutionStatus Status
      {
         get 
         {
            return MediaObject.ExecutionStatus.ExecutionStatus.Value ;
         }
      }
      
      public RequestPriority Priority
      {
         get 
         {
            if ( null == MediaObject.RequestInformation.Priority ||
                 MediaObject.RequestInformation.Priority.Value == RequestPriority.Undefined )
            {
               return RequestPriority.Medium ;
            }
            else
            {
               return MediaObject.RequestInformation.Priority.Value ;
            }
         }
      }
      
      public int NumberOfCopies
      {
         get 
         {
            if ( null == MediaObject.RequestInformation.NumberOfCopies )
            {
               return 1 ;
            }
            else
            {
               return MediaObject.RequestInformation.NumberOfCopies.Value ;
            }
         }
      }
      
      public DateTime CreationTime
      {
         get 
         {
            DateTime creationDate ;
            DateTime creationTime ;
            
            
            if ( null == MediaObject.SopCommon.InstanceCreationDate )
            {
               creationDate = DateTime.MinValue ;
            }
            else
            {
               creationDate = MediaObject.SopCommon.InstanceCreationDate.Value ;
            }
            
            if ( null == MediaObject.SopCommon.InstanceCreationTime ) 
            {
               creationTime = DateTime.MinValue ;
            }
            else
            {
               creationTime = MediaObject.SopCommon.InstanceCreationTime.Value ;
            }
            
            return new DateTime ( creationDate.Year, creationDate.Month, creationDate.Day,
                                  creationTime.Hour, creationTime.Minute, creationTime.Second ) ;
         }
      }
      
      public MediaCreationManagement MediaObject
      {
         get ;
         private set ;
      }
      
      public bool Checked
      {
         get ;
         set ;
      }
      
      //public bool Creating
      //{
      //   get ;
      //   set ;
      //}
      
      public string MediaLocation
      {
         get 
         {
            return MediaObject.GetCreationPath ( ) ;
         }
      }
      
      public string Comments
      {
         get ;
         set ;
      }
   }
}

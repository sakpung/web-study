// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Leadtools.Dicom.Scp.Media;
using Leadtools.Dicom.Common.DataTypes.MediaCreation;

namespace Leadtools.Medical.Media.AddIns
{
   public class MediaObjectsStateService : IDisposable
   {
      public MediaObjectsStateService ( MediaCreationQueue mediaQueue )
      {
         MediaQueue         = mediaQueue ;
         SelectedMediaItems = new MediaCreationQueue ( ) ;

         MediaQueue.MediaItemRemoved       += new EventHandler<MediaItemEventArgs> ( MediaQueue_MediaItemRemoved ) ;
         SelectedMediaItems.MediaItemAdded += new EventHandler<MediaItemEventArgs> ( SelectedMediaItems_MediaItemAdded ) ;
      }

      void SelectedMediaItems_MediaItemAdded(object sender, MediaItemEventArgs e)
      {
         if ( !MediaQueue.Contains ( e.Item ) )
         {
            throw new InvalidOperationException ( "Selected Item doesn't belong to MediaQueue" ) ;
         }
      }

      void MediaQueue_MediaItemRemoved ( object sender, MediaItemEventArgs e )
      {
         if ( SelectedMediaItems.Contains ( e.Item ) )
         {
            SelectedMediaItems.Remove ( e.Item ) ;
         }
         
         if ( ActiveMediaItem == e.Item ) 
         {
            ActiveMediaItem = null ;
         }
      }
      
      public event EventHandler ActiveMediaItemChanged ;
      
      public MediaCreationQueue MediaQueue
      {
         get ;
         private set ;
      }
      
      public MediaCreationQueue SelectedMediaItems
      {
         get ;
         private set ;
      }
      
      public MediaCreationManagement ActiveMediaItem
      {
         get 
         {
            return _activeMediaItem ;
         }
         
         set 
         {
            if ( value != _activeMediaItem ) 
            {
               _activeMediaItem = value ;
               
               if ( null != ActiveMediaItemChanged ) 
               {
                  ActiveMediaItemChanged ( this, EventArgs.Empty ) ;
               }
            }
         }
      }
      
      private MediaCreationManagement _activeMediaItem = null ;


      #region IDisposable Members

      public void Dispose()
      {
         MediaQueue.MediaItemRemoved       -= new EventHandler<MediaItemEventArgs> ( MediaQueue_MediaItemRemoved ) ;
         SelectedMediaItems.MediaItemAdded -= new EventHandler<MediaItemEventArgs> ( SelectedMediaItems_MediaItemAdded ) ;
      }

      #endregion
   }
}

// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Leadtools.Dicom.Common.DataTypes.MediaCreation;
using System.Collections;
using Leadtools.Dicom.Scp.Media;

namespace Leadtools.Medical.Media.AddIns
{
   public class MediaCreationQueue : IList<MediaCreationManagement>
   {
      #region Public
         
         #region Methods
         
            public MediaCreationQueue ( ) 
            {
               __MediaQueue      = new List<MediaCreationManagement> ( ) ;
               __MediaDictionary = new Dictionary<string,MediaCreationManagement> ( ) ;
            }
         
            public void NotifyMediaObjectUpdated ( MediaCreationManagement mediaObject )
            {
               ValidateNull ( mediaObject ) ;
               
               NotifyMediaObjectUpdated ( mediaObject.SopCommon.SOPInstanceUID ) ;
            }
            
            public void NotifyMediaObjectUpdated ( string sopInstanceUID )
            {
               ValidateNull ( sopInstanceUID ) ;
               
               if ( Contains ( sopInstanceUID ) )
               {
                  OnMediaObjectUpdated ( this [ sopInstanceUID ] ) ;
               }
            }

            #region IList<MediaCreationManagement> Members

            public int IndexOf ( MediaCreationManagement item )
            {
               return __MediaQueue.IndexOf ( item ) ;
            }

            public void Insert ( int index, MediaCreationManagement item )
            {
               ValidateNull ( item ) ;
               
               if ( __MediaDictionary.ContainsKey ( item.SopCommon.SOPInstanceUID ) )
               {
                  throw new InvalidOperationException ( "Media with same SOP Instance UID already exists." ) ;
               }
               
               __MediaDictionary.Add ( item.SopCommon.SOPInstanceUID, item ) ;
               __MediaQueue.Insert ( 0, item ) ;
               
               OnMediaItemAdded ( item ) ;
            }
            

            public void RemoveAt ( int index )
            {
               MediaCreationManagement mediaObject ;


               ValidateIndexRange ( index ) ;
               
               mediaObject = __MediaQueue [ index ] ;
               
               __MediaQueue.RemoveAt ( index ) ;
               
               __MediaDictionary.Remove ( mediaObject.SopCommon.SOPInstanceUID ) ;
               
               OnMediaItemRemoved ( mediaObject ) ;
            }

            #endregion

            #region ICollection<MediaCreationManagement> Members

            public void Add ( MediaCreationManagement item )
            {
               ValidateNull ( item ) ;
               
               Insert ( __MediaQueue.Count, item ) ;
            }
            
            public void Clear ( )
            {
               __MediaQueue.Clear ( ) ;
               __MediaDictionary.Clear ( ) ;
               
               OnMediaQueueCleared ( ) ;
            }

            public bool Contains ( MediaCreationManagement item )
            {
               ValidateNull ( item ) ;
               
               return Contains ( item.SopCommon.SOPInstanceUID ) ;
            }
            
            public bool Contains ( string sopInstanceUID )
            {
               ValidateNull ( sopInstanceUID ) ;
               
               return __MediaDictionary.ContainsKey ( sopInstanceUID ) ;
            }

            public void CopyTo ( MediaCreationManagement[] array, int arrayIndex )
            {
               __MediaQueue.CopyTo ( array, arrayIndex ) ;
            }

            public bool Remove ( MediaCreationManagement item )
            {
               ValidateNull ( item ) ;
               
               return Remove ( item.SopCommon.SOPInstanceUID ) ;
            }

            public bool Remove ( string sopInstanceUID )
            {
               ValidateNull ( sopInstanceUID ) ;
               
               if ( __MediaDictionary.ContainsKey ( sopInstanceUID ) )
               {
                  MediaCreationManagement media ;
                  
                  
                  media = __MediaDictionary [ sopInstanceUID ] ;
                  
                  RemoveAt ( __MediaQueue.IndexOf ( media ) ) ;
                  
                  return true ;
               }
               else
               {
                  return false ;
               }
            }

            #endregion

            #region IEnumerable<MediaCreationManagement> Members

            public IEnumerator<MediaCreationManagement> GetEnumerator()
            {
               return __MediaQueue.GetEnumerator ( ) ;
            }

            #endregion

            #region IEnumerable Members

               System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
               {
                  return __MediaQueue.GetEnumerator ( ) ;
               }

            #endregion
         
         #endregion
         
         #region Properties
         
            public static MediaCreationQueue Instance
            {
               get
               {
                  return _instance ;
               }
            }
         
            public MediaCreationManagement this [ int index ]
            {
               get
               {
                  ValidateIndexRange ( index ) ;
                  
                  return __MediaQueue [ index ] ;
               }
               
               set
               {
                  ValidateIndexRange ( index ) ;
                  
                  RemoveAt ( index ) ;
                  
                  Insert ( index, value ) ;
               }
            }
            
            public MediaCreationManagement this [ string sopInstanceUID ]
            {
               get
               {
                  ValidateNull ( sopInstanceUID ) ;
                  
                  if ( __MediaDictionary.ContainsKey ( sopInstanceUID ) )
                  {
                     return __MediaDictionary [ sopInstanceUID ] ;
                  }
                  else
                  {
                     return null ;
                  }
               }
            }
            
            public int Count
            {
               get 
               { 
                  return __MediaQueue.Count ; 
               }
            }

            public bool IsReadOnly
            {
               get 
               { 
                  return false ; 
               }
            }
            
         #endregion
         
         #region Events
            
         #endregion
         
         #region Data Types Definition
            
         #endregion
         
         #region Callbacks
         
            public event EventHandler <MediaItemEventArgs> MediaItemAdded ;
            public event EventHandler <MediaItemEventArgs> MediaItemRemoved ;
            public event EventHandler <MediaItemEventArgs> MediaObjectUpdated ;
            public event EventHandler                      MediaQueueCleared ;
            
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
         
            private void ValidateIndexRange ( int index )
            {
               if ( index < 0 || index > __MediaQueue.Count - 1 )
               {
                  throw new ArgumentOutOfRangeException ( ) ;
               }
            }
            
            private static void ValidateNull ( object item )
            {
               if ( item == null )
               {
                  throw new ArgumentNullException ( ) ;
               }
            }
            
            private void OnMediaItemAdded ( MediaCreationManagement item ) 
            {
               if ( null != MediaItemAdded ) 
               {
                  MediaItemAdded ( this, new MediaItemEventArgs ( item ) ) ;
               }
            }
            
            private void OnMediaItemRemoved ( MediaCreationManagement item )
            {
               if ( null != MediaItemRemoved ) 
               {
                  MediaItemRemoved ( this, new MediaItemEventArgs ( item ) ) ;
               }
            }
            
            private void OnMediaQueueCleared ( ) 
            {
               if ( null != MediaQueueCleared ) 
               {
                  MediaQueueCleared ( this, EventArgs.Empty ) ;
               }
            }
            
            private void OnMediaObjectUpdated ( MediaCreationManagement mediaCreationManagement )
            {
               if ( null != MediaObjectUpdated ) 
               {
                  MediaObjectUpdated ( this, new MediaItemEventArgs ( mediaCreationManagement ) ) ;
               }
            }
            
         #endregion
         
         #region Properties
         
            private List <MediaCreationManagement> __MediaQueue
            {
               get
               {
                  return _mediaQueue ;
               }
               
               set 
               {
                  _mediaQueue = value ;
               }
            }
            
            private Dictionary <string, MediaCreationManagement> __MediaDictionary
            {
               get 
               {
                  return _mediaDictionary ;
               }
               set 
               {
                  _mediaDictionary = value ;
               }
            }
            
         #endregion
         
         #region Events
            
         #endregion
         
         #region Data Members
         
            private static MediaCreationQueue _instance = MediaCreationQueueFactory.Create ( ) ;
            private List <MediaCreationManagement> _mediaQueue ;
            private Dictionary <string, MediaCreationManagement> _mediaDictionary ;
            
         #endregion
         
         #region Data Types Definition
         
            private static class MediaCreationQueueFactory
            {
               public static MediaCreationQueue Create ( )
               {
                  return new MediaCreationQueue ( ) ;
               }
            }
            
            
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

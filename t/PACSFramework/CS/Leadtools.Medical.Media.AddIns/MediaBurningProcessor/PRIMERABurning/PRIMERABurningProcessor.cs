// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Leadtools.Dicom.Common.DataTypes.MediaCreation;
using System.IO;
using Leadtools.Medical.Storage.DataAccessLayer;
using Leadtools.Medical.DataAccessLayer;
using Leadtools.Medical.Storage.DataAccessLayer.MatchingParameters;
using Leadtools.Medical.Storage.DataAccessLayer.Configuration;
using Leadtools.Dicom.Scp.Media;
using Leadtools.Dicom.Common.DataTypes;
using Leadtools.Medical.DataAccessLayer.Catalog;

namespace Leadtools.Medical.Media.AddIns.MediaBurningProcessor.Primera
{
   class PRIMERABurningProcessor : IMediaBurningProcessor
   {
      #region Public
         
         #region Methods
         
            public PRIMERABurningProcessor 
            ( 
               string processingFolder,
               IMediaLabelsCreator lableCreator
            ) 
            {
               if ( !Directory.Exists ( processingFolder ) )
               {
                  Directory.CreateDirectory ( processingFolder ) ;
               }
               
               ProcessingFolder             = processingFolder ;
               LableCreator                 = lableCreator ;
               __FileMediaObject            = new Dictionary<string,MediaCreationManagement> ( ) ;
               __ProcessingDirectoryWatcher = new FileSystemWatcher ( ProcessingFolder ) ;
               
               __ProcessingDirectoryWatcher.EnableRaisingEvents = true ;
               
               __ProcessingDirectoryWatcher.Renamed += new RenamedEventHandler ( fileJobWatcher_Renamed ) ;
            }
            
            public void ProcessMedia ( MediaCreationManagement mediaObject, MediaAutoCreationConfiguration configuration ) 
            {
               string            patientName ; 
               JobFile           mediaFile ;
               string            jobFileName ;
               
               
               if ( Disposed ) 
               {
                  throw new ObjectDisposedException ( this.GetType ( ).Name ) ;
               }
               
               patientName                = GetValidFileName ( GetPatientName ( mediaObject ) ) ; 
               mediaFile                  = new JobFile ( ) ;
               mediaFile.JobID            = patientName ;
               mediaFile.ClientID         = AddInsSession.ServerAE ;
               mediaFile.Copies           = (uint) mediaObject.RequestInformation.NumberOfCopies.Value ;
               mediaFile.Importance       = (uint) mediaObject.RequestInformation.Priority.Value ;
               mediaFile.VolumeName       = ( string.IsNullOrEmpty ( mediaObject.MediaSet.FileSetID ) ) ? patientName : mediaObject.MediaSet.FileSetID ;
               mediaFile.TestRecord       = configuration.TestRecording ;
               mediaFile.ManLoadUnload    = configuration.ManualLoadUnload ;
               mediaFile.CloseDisc        = configuration.CloseDisc ;
               mediaFile.Verify           = configuration.VerifyDisc ;
               mediaFile.RejectIfNotBlank = configuration.RejectIfNotBlank ;
               
               if ( configuration.EnableLabeling ) 
               {
                  mediaFile.PrintLabel = configuration.LabelImage ;
                  
                  if ( null != LableCreator ) 
                  {
                     mediaFile.MergeFields = LableCreator.GetLabels ( configuration.Labels, mediaObject ) ;
                  }
               }
               
               mediaFile.Data.Add ( new DataEntry ( mediaObject.GetCreationPath ( ) ) ) ;
               
               jobFileName = GetJobFileNameWithoutExt ( patientName ) ;
               
               __FileMediaObject.Add ( Path.GetFileName ( jobFileName ), mediaObject ) ;
               
               mediaFile.SendJobFile ( jobFileName ) ;
               
               File.Move ( jobFileName, Path.ChangeExtension ( jobFileName, "jrq" ) ) ;
            }
            
            public void Dispose ( )
            {
               if ( !Disposed ) 
               {
                  Disposed = true ;
                  
                  if ( null != __ProcessingDirectoryWatcher ) 
                  {
                     __ProcessingDirectoryWatcher.Dispose ( ) ;
                  }
               }
            }
            
         #endregion
         
         #region Properties
         
            public string ProcessingFolder
            {
               get 
               {
                  return _processingFolder ;
               }
               
               set 
               {
                  _processingFolder = value ;
                  
                  if ( null != __ProcessingDirectoryWatcher && 
                      __ProcessingDirectoryWatcher.Path != value )
                  {
                     __ProcessingDirectoryWatcher.Path = value ;
                  }
               }
            }
            
            public IMediaLabelsCreator LableCreator
            {
               get ;
               private set ;
            }
            
            public bool Disposed 
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
         
            public event EventHandler <MediaItemEventArgs> MediaBurningCompleted ;
            public event EventHandler <MediaItemFailureEventArgs> MediaBurningFailed ;
            
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
         
            private void OnMediaBurningCompleted ( MediaCreationManagement mediaObject )
            {
               if ( null != MediaBurningCompleted )
               {
                  MediaBurningCompleted ( this, new MediaItemEventArgs ( mediaObject  ) ) ;
               }
            }

            private void OnMediaBurningFailed ( MediaCreationManagement mediaObject )
            {
               if ( null != MediaBurningFailed ) 
               {
                  MediaBurningFailed ( this, new MediaItemFailureEventArgs ( mediaObject, ExecutionStatusInfo.MCD_FAILURE  ) ) ;
               }
            }

            private string GetJobFileNameWithoutExt ( string patientName )
            {
               try
               {
                  string fileName ;
                  int    count = 0 ;

                  fileName = patientName + count.ToString ( ) ;
                  
                  while ( Directory.GetFiles ( ProcessingFolder, 
                                                fileName + ".*", 
                                               SearchOption.TopDirectoryOnly ).Length > 0 ||
                         __FileMediaObject.ContainsKey ( fileName ) )
                  {
                     count++ ;
                     
                     fileName = patientName + count.ToString ( ) ;
                  }
                  
                  return Path.Combine ( ProcessingFolder, fileName ) ;
               }
               catch ( Exception exception ) 
               {
                  System.Diagnostics.Debug.Assert ( false, exception.Message ) ;
                  
                  throw ;
               }
            }

            private static string GetValidFileName ( string patientName )
            {
               foreach (char invalidChar in Path.GetInvalidFileNameChars())
               {
                  patientName = patientName.Replace(invalidChar, ' ');
               }
               return patientName;
            }
            
            private static string GetPatientName ( MediaCreationManagement mediaObject )
            {
               string                      patientName ;
               IStorageDataAccessAgent     dataAccess ;
               MatchingParameterCollection matchingCollection ;
               MatchingParameterList       matchingList ;
               CompositeInstanceDataSet    compositeInstance ;
               
               
               patientName        = string.Empty ;
               dataAccess         = DataAccessServices.GetDataAccessService <IStorageDataAccessAgent> ( ) ;
               matchingCollection = new MatchingParameterCollection ( ) ;
               matchingList       = new MatchingParameterList ( ) ;
               // Instance matchingInstance   = new Instance ( mediaObject.ReferencedSopSequence [ 0 ].SopInstance.ReferencedSopInstanceUid ) ;
               ICatalogEntity matchingInstance = RegisteredEntities.GetInstanceEntity(mediaObject.ReferencedSopSequence [ 0 ].SopInstance.ReferencedSopInstanceUid);
               
               if ( null == dataAccess ) 
               {
                  dataAccess = DataAccessFactory.GetInstance ( new StorageDataAccessConfigurationView ( ) ).CreateDataAccessAgent <IStorageDataAccessAgent> ( ) ;
               }
               
               matchingCollection.Add ( matchingList ) ;
               matchingList.Add ( matchingInstance ) ;
               
               compositeInstance = dataAccess.QueryCompositeInstances ( matchingCollection ).ToCompositeInstanceDataSet() ;
               
               if ( !string.IsNullOrEmpty ( compositeInstance.Patient [ 0 ].FamilyName ) )
               {
                  patientName += compositeInstance.Patient [ 0 ].FamilyName ;
               }
               
               if ( !string.IsNullOrEmpty ( compositeInstance.Patient [ 0 ].GivenName ) )
               {
                  if ( !string.IsNullOrEmpty ( patientName) )
                  {
                     patientName += ", " ;
                  }
                  
                  patientName += compositeInstance.Patient [ 0 ].GivenName ;
               }
               
               return patientName ;
            }
            
         #endregion
         
         #region Properties
         
            private Dictionary <string, MediaCreationManagement> __FileMediaObject
            {
               get ;
               set ;
            }
            
            private FileSystemWatcher __ProcessingDirectoryWatcher
            {
               get ;
               set ;
            }
            
         #endregion
         
         #region Events
         
            void fileJobWatcher_Renamed ( object sender, RenamedEventArgs e )
            {
               try
               {
                  if ( e.ChangeType == WatcherChangeTypes.Renamed )
                  {
                     string fileName ;
                     
                     
                     fileName  = Path.GetFileNameWithoutExtension ( e.OldName ) ;
                     
                     
                     if ( __FileMediaObject.ContainsKey ( fileName ) )
                     {
                        string extension ;
                        
                        
                        extension = Path.GetExtension ( e.FullPath ) ;
                        
                        if ( extension == ".ERR" )
                        {
                           MediaCreationManagement mediaObject ;
                           
                           
                           mediaObject = __FileMediaObject [ fileName ] ;
                           
                           OnMediaBurningFailed ( mediaObject ) ;
                           
                           
                           __FileMediaObject.Remove ( fileName ) ;
                        }
                        else if ( extension == ".DON" )
                        {
                           MediaCreationManagement mediaObject ;
                           
                           
                           mediaObject = __FileMediaObject [ fileName ] ;
                           
                           OnMediaBurningCompleted ( mediaObject ) ;
                           
                           __FileMediaObject.Remove ( fileName ) ;
                        }
                     }
                  }
               }
               catch ( Exception )
               {
                  
               }
            }
            
         #endregion
         
         #region Data Members
            
            private string _processingFolder ;
            
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

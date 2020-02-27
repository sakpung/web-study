// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Leadtools.Dicom.Common.DataTypes.MediaCreation;
using Leadtools.Medical.Storage.DataAccessLayer;
using Leadtools.Medical.DataAccessLayer;
using Leadtools.Medical.Storage.DataAccessLayer.MatchingParameters;
using System.IO;
using Leadtools.Dicom;
using Leadtools.Dicom.Common.DataTypes;
using Leadtools.Medical.DataAccessLayer.Catalog;

namespace Leadtools.Medical.Media.AddIns.Composing
{
   public class MediaComposer
   {
      #region Public
         
         #region Methods
         
            public MediaComposer 
            ( 
               MediaCreationManagement mediaObject
            ) : this ( mediaObject, Leadtools.Medical.DataAccessLayer.DataAccessServices.GetDataAccessService <IStorageDataAccessAgent> ( ) )
            {
               
            }
         
            public MediaComposer 
            ( 
               MediaCreationManagement mediaObject,
               IStorageDataAccessAgent storageService
            ) 
            {
               MediaObject       = mediaObject ;
               StorageService    = storageService ;
               ProfileProcessors = new List<IDicomMediaProfileProcessor> ( ) ;
            }
         
            public List <IDicomMediaProfileProcessor> ProfileProcessors
            {
               get ;
               private set ;
            }
            
            public string ComposeMedia ( string directoryPath ) 
            {
               try
               {
                  Dictionary <string, string> instanceSopProfileName ;
                  CompositeInstanceDataSet    dicomInstances ;
                  IDicomMediaProfileProcessor profileProcessor ;
                  DirectoryInfo               mediaDir ;
                  
                  
                  if ( null == MediaObject ) 
                  {
                     throw new NullReferenceException ( "Null Media Object." ) ;
                  }
                  
                  if ( null == StorageService ) 
                  {
                     throw new NullReferenceException ( "Null Storage Service." ) ;
                  }
                  
                  instanceSopProfileName = new Dictionary<string,string> ( MediaObject.ReferencedSopSequence.Count ) ;
                  
                  dicomInstances = GetReferencedCompositeInstancesAndFillInstanceProfiles ( instanceSopProfileName ) ;
                  
                  if ( dicomInstances.Instance.Count != MediaObject.ReferencedSopSequence.Count )
                  {
                     MediaObject.ExecutionStatus.ExecutionStatus     = ExecutionStatus.Failure ;
                     MediaObject.ExecutionStatus.ExecutionStatusInfo = ExecutionStatusInfo.NO_INSTANCE ;
                     
                     throw new InvalidOperationException ( "Missing referenced Instances." ) ;
                  }
                  
                  if ( dicomInstances.Instance.Count > 0 )
                  {
                     profileProcessor = GetProfileProcessor ( dicomInstances.Instance, instanceSopProfileName ) ;
                  }
                  else
                  {
                     MediaObject.ExecutionStatus.ExecutionStatus     = ExecutionStatus.Failure ;
                     MediaObject.ExecutionStatus.ExecutionStatusInfo = ExecutionStatusInfo.NO_INSTANCE ;
                     
                     throw new InvalidOperationException ( "No DICOM instances found." ) ;
                  }
                  
                  mediaDir = GetMediaDirectory ( directoryPath, dicomInstances ) ;
                  
                  StartComposing ( dicomInstances, profileProcessor, mediaDir ) ;
                  
                  return mediaDir.FullName ;
               }
               catch ( Exception ) 
               {
                  if ( MediaObject.ExecutionStatus.ExecutionStatus != ExecutionStatus.Failure ) 
                  {
                     MediaObject.ExecutionStatus.ExecutionStatus     = ExecutionStatus.Failure ;
                     MediaObject.ExecutionStatus.ExecutionStatusInfo = ExecutionStatusInfo.DIR_PROC_ERR ;
                  }
                  
                  throw ;
               }
            }

         #endregion
         
         #region Properties
         
            public MediaCreationManagement MediaObject 
            {
               get ;
               private set ;
            }
            
            public IStorageDataAccessAgent StorageService
            {
               get ;
               set ;
            }
            
            public string DescriptorFile
            {
               get ;
               set ;
            }
            
            public string DescriptorFileCharacterSet
            {
               get ;
               set ;
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
         
            private CompositeInstanceDataSet GetReferencedCompositeInstancesAndFillInstanceProfiles 
            (
               Dictionary <string, string> instanceSopProfileName
            )
            {
               MatchingParameterCollection matchingCollection ;
               MatchingParameterList       matchingList ;
               
               
               matchingCollection = new MatchingParameterCollection ( ) ;
               
               foreach ( MediaCreationReferencedSop referencedSop in MediaObject.ReferencedSopSequence )
               {
                  matchingList = new MatchingParameterList ( ) ;
                  
                  matchingCollection.Add ( matchingList ) ;
                  
                  ICatalogEntity instanceEntity = RegisteredEntities.GetInstanceEntity(referencedSop.SopInstance.ReferencedSopInstanceUid);
                  matchingList.Add ( instanceEntity ) ;
                  
                  instanceSopProfileName.Add ( referencedSop.SopInstance.ReferencedSopInstanceUid, 
                                               referencedSop.RequestedMediaApplicationProfile ) ;
               }
               
               return StorageService.QueryCompositeInstances ( matchingCollection ).ToCompositeInstanceDataSet();
            }
            
            
            private DirectoryInfo GetMediaDirectory
            (
               string directoryPath,
               CompositeInstanceDataSet dicomInstances
            )
            {
               string mediaDirName ;
               
               
               mediaDirName = GetMediaFileId ( directoryPath, dicomInstances ) ;
               
               if ( !Directory.Exists ( mediaDirName ) )
               {
                  return Directory.CreateDirectory ( mediaDirName ) ;
               }
               else 
               {
                  return new DirectoryInfo ( mediaDirName ) ;
               }
            }
            
            protected virtual string GetMediaFileId
            (
               string directoryPath,
               CompositeInstanceDataSet dicomInstances
            )
            {
               string dirPath = null ;
               
               
               if ( directoryPath.Length > 247 )
               {
                  throw new InvalidOperationException ( "Media Directory path is too long." ) ;
               }
               
               if ( !string.IsNullOrEmpty ( MediaObject.MediaSet.FileSetID ) )
               {
                  dirPath = Path.Combine ( directoryPath, MediaObject.MediaSet.FileSetID ) ;
               }
               else if ( dicomInstances.Patient.Count == 1 ) 
               {
                  string fileSetID ;
                  
                  
                  fileSetID = string.Empty ;
                  
                  if ( !string.IsNullOrEmpty ( dicomInstances.Patient [ 0 ].FamilyName ) )
                  {
                     fileSetID += dicomInstances.Patient [ 0 ].FamilyName ;
                  }
                  
                  if ( !string.IsNullOrEmpty ( dicomInstances.Patient [ 0 ].GivenName ) )
                  {
                     fileSetID += dicomInstances.Patient [ 0 ].GivenName ;
                  }
                  
                  if ( string.IsNullOrEmpty ( fileSetID ) && !string.IsNullOrEmpty ( dicomInstances.Patient [ 0 ].PatientID ) )
                  {
                     fileSetID = dicomInstances.Patient [ 0 ].PatientID ;
                  }
                  
                  if ( !string.IsNullOrEmpty ( fileSetID ) )
                  {
                     dirPath = Path.Combine ( directoryPath, GetValidFileSetID ( fileSetID ) ) ;
                  }
               }
               
               if ( string.IsNullOrEmpty ( dirPath ) || Directory.Exists ( dirPath ) )
               {
                  dirPath = Path.Combine ( directoryPath, Guid.NewGuid ( ).ToString ( ) ) ;
               }
               
               if ( dirPath.Length > 247 )
               {
                  dirPath = dirPath.Substring ( 0, 247 ) ;
               }
               
               return dirPath ;
            }

            private string GetValidFileSetID ( string fileSetID )
            {
               fileSetID = fileSetID.ToUpper ( ) ;
               
               foreach ( char check in fileSetID.ToCharArray ( ) )
               {
                  if ( !IsValidFileIDChar ( check ) )
                  {
                     fileSetID = fileSetID.Replace ( check, ' ' ) ;
                  }
               }
               
               if ( fileSetID.Length > 16 )
               {
                  fileSetID = fileSetID.Remove ( 16 ) ;
               }
               
               return fileSetID ;
            }

            private bool IsValidFileIDChar ( char check ) 
            {
               
               switch ( check )
               {
                  case '\\':
                  case 'A':
                  case 'B':
                  case 'C':
                  case 'D':
                  case 'E':
                  case 'F':
                  case 'G':
                  case 'H':
                  case 'I':
                  case 'J':
                  case 'K':
                  case 'L':
                  case 'M':
                  case 'N':
                  case 'O':
                  case 'P':
                  case 'Q':
                  case 'R':
                  case 'S':
                  case 'T':
                  case 'U':
                  case 'V':
                  case 'W':
                  case 'X':
                  case 'Y':
                  case 'Z':
                  case '0':
                  case '1':
                  case '2':
                  case '3':
                  case '4':
                  case '5':
                  case '6':
                  case '7':
                  case '8':
                  case '9':
                  case '_':
                  {
                     return true ;
                  }
                     
                  default:
                  {
                     return false ;
                  }
               }
            }
            
            private void StartComposing
            (
               CompositeInstanceDataSet dicomInstances, 
               IDicomMediaProfileProcessor profileProcessor,
               DirectoryInfo mediaDirectory
               
            )
            {
               __MediaDirectory = mediaDirectory ;
               
               profileProcessor.CopyDirectory += new EventHandler<CopyEventArgs> ( profileProcessor_CopyDirectory ) ;
               profileProcessor.CopyFile      += new EventHandler<CopyEventArgs> ( profileProcessor_CopyFile ) ;
               
               try
               {
                  long size ;
                  
                  
                  size = CreateDicomDirectory ( dicomInstances, __MediaDirectory, profileProcessor ) ;
                  
                  if ( size > profileProcessor.GetProfileMediaSize ( ) || 
                       profileProcessor.CalculateRemainingDataSize ( size ) < 0 )
                  {
                     MediaObject.ExecutionStatus.ExecutionStatus     = ExecutionStatus.Failure ;
                     MediaObject.ExecutionStatus.ExecutionStatusInfo = ExecutionStatusInfo.SET_OVERSIZED ;
                     
                     throw new InvalidOperationException ( "Not enough media size to complete the request." ) ;
                  }
                  
                  if ( null == MediaObject.IncludeDisplayApplication ||
                       MediaObject.IncludeDisplayApplication.Value == YesNo.Undefined ||
                       MediaObject.IncludeDisplayApplication.Value == YesNo.Yes ) 
                  {
                     profileProcessor.IncludeDisplayApplication ( ) ;
                  }
                  
                  if ( null == MediaObject.AllowNonDicomObjects ||
                       MediaObject.AllowNonDicomObjects.Value == IncludeNonDicomObjects.Undefined )
                  {
                     profileProcessor.IncludeNonDicomObjects ( IncludeNonDicomObjects.Undefined ) ;
                  }
                  else if ( MediaObject.AllowNonDicomObjects.Value != IncludeNonDicomObjects.No )
                  {
                     profileProcessor.IncludeNonDicomObjects ( MediaObject.AllowNonDicomObjects.Value ) ;
                  }
               }
               finally
               {
                  profileProcessor.CopyDirectory -= new EventHandler<CopyEventArgs> ( profileProcessor_CopyDirectory ) ;
                  profileProcessor.CopyFile      -= new EventHandler<CopyEventArgs> ( profileProcessor_CopyFile ) ;
                  
                  __MediaDirectory = null ;
               }
            }
            
            private List<string> ProcessDicomDir
            ( 
               DirectoryInfo mediaDirectory,
               CompositeInstanceDataSet dicomInstances,
               DicomDir dicomDir,
               IDicomMediaProfileProcessor profileProcessor
            )
            {
               string        rootKey ;
               List <string> createdFiles ;
               int           patientIndex ;
               bool          allowLossyCompression ;
               
               rootKey          = "DICOM" ;
               createdFiles     = new List<string> ( dicomInstances.Instance.Count ) ;
               patientIndex     = 0 ;
               
               allowLossyCompression = ( MediaObject.AllowLossyCompression == null || 
                                         MediaObject.AllowLossyCompression.Value != YesNo.No ) ;
                                         
               foreach ( CompositeInstanceDataSet.PatientRow patient in dicomInstances.Patient )
               {
                  string patientKey ;
                  int    studyIndex ;
                  
                  
                  patientIndex++ ;
                  
                  patientKey = "PATIENT" + patientIndex.ToString ( ) ;
                  studyIndex = 0 ;
                  
                  foreach ( CompositeInstanceDataSet.StudyRow study in patient.GetStudyRows ( ) )
                  {
                     string studyKey ;
                     int    seriesIndex ;
                     
                     studyIndex++ ;
                     
                     studyKey    = "STUDY" + studyIndex.ToString ( ) ;
                     seriesIndex = 0 ;
                     
                     foreach ( CompositeInstanceDataSet.SeriesRow series in study.GetSeriesRows ( ) ) 
                     {
                        string seriesKey ;
                        int    instanceIndex ;
                        
                        seriesIndex++ ;
                        
                        seriesKey     = "SERIES" + seriesIndex.ToString ( ) ;
                        instanceIndex = 0 ;
                        
                        foreach ( CompositeInstanceDataSet.InstanceRow instance in series.GetInstanceRows ( ) )
                        {
                           string instanceKey ;
                           string instancePath ;
                           
                           instanceIndex++ ;
                           
                           instanceKey = instanceIndex.ToString ( ) ;
                           
                           instancePath = GetInstancePath ( mediaDirectory, rootKey, patientKey, studyKey, seriesKey, instanceKey ) ;
                           
                           if ( !Directory.Exists ( Path.GetDirectoryName ( instancePath ) ) )
                           {
                              Directory.CreateDirectory ( Path.GetDirectoryName ( instancePath ) ) ;
                           }
                           
                           File.Copy ( instance.ReferencedFile, instancePath, true ) ;
                           
                           profileProcessor.BeforeAddingToDicomDir ( instancePath, instance, allowLossyCompression ) ;
                           
                           dicomDir.InsertFile ( instancePath ) ;
                           
                           profileProcessor.AfterAddingToDicomDir ( instancePath, instance, dicomDir.DataSet ) ;
                           
                           createdFiles.Add ( instancePath ) ;
                        }
                     }
                  }
               }
               
               return createdFiles ;
            }

            private IDicomMediaProfileProcessor GetProfileProcessor
            ( 
               CompositeInstanceDataSet.InstanceDataTable instances,
               Dictionary <string, string> instanceSopProfileName
            )
            {
               string profileName ;
                  
                  
               profileName = instanceSopProfileName [ instances [ 0 ].SOPInstanceUID ] ;
               
               foreach ( IDicomMediaProfileProcessor processor in ProfileProcessors ) 
               {
                  if ( processor.CanProcess ( profileName ) )
                  {
                     processor.SetProfile ( profileName ) ;
                     
                     return processor ;
                  }
               }
               
               if ( __DefaultProcessor.CanProcess ( profileName ) )
               {
                  __DefaultProcessor.SetProfile ( profileName ) ;
                  
                  return __DefaultProcessor ;
               }
               else
               {
                  throw new InvalidOperationException ( "No profile processor found." ) ;
               }
            }

            private static string GetInstancePath
            (
               DirectoryInfo mediaDirectory, 
               string rootKey,
               string patientKey, 
               string studyKey, 
               string seriesKey, 
               string instanceKey
            )
            {
               return Path.Combine (  Path.Combine ( Path.Combine ( Path.Combine ( Path.Combine ( mediaDirectory.FullName, rootKey ), patientKey ), studyKey ), seriesKey ), instanceKey ) ;
            }

            private long CreateDicomDirectory
            ( 
               CompositeInstanceDataSet dicomInstances, 
               DirectoryInfo mediaDirectory,
               IDicomMediaProfileProcessor profileProcessor
            )
            {
               using ( DicomDir dicomDir = new DicomDir ( mediaDirectory.FullName ) )
               {
                  List<string> createdFiles ;
                  
                  
                  createdFiles = ProcessDicomDir ( mediaDirectory, 
                                                   dicomInstances, 
                                                   dicomDir, 
                                                   profileProcessor ) ;
                  
                  dicomDir.SetFileSetId ( mediaDirectory.Name ) ;
                  
                  if ( !string.IsNullOrEmpty ( DescriptorFile ) )
                  {
                     string descriptorFile ;
                     
                     
                     descriptorFile = CopyDescriptorFile ( mediaDirectory.FullName ) ;
                     
                     dicomDir.SetDescriptorFile ( descriptorFile, DescriptorFileCharacterSet ) ;
                     
                     createdFiles.Add ( descriptorFile ) ;
                  }
                  
                  profileProcessor.OnDicomDirCompleted ( dicomDir.DataSet ) ;
                  
                  dicomDir.Save ( ) ;
                  
                  createdFiles.Add ( Path.Combine ( mediaDirectory.FullName, "DICOMDIR" ) ) ;
                  
                  return GetFilesSize ( createdFiles ) ;
               }
            }

            private long GetFilesSize ( List<string> createdFiles )
            {
               long size ;
               
               
               size = 0 ;
               
               foreach ( string file in createdFiles ) 
               {
                  size += new FileInfo ( file ).Length ;
               }
               
               return ( size / 1000000 ) ;
            }

            private string CopyDescriptorFile ( string mediaDirectory )
            {
            
               return CopyFile ( DescriptorFile, mediaDirectory ) ;
            }
            
            private static string CopyDirectory ( string directory, string destinationBaseDir ) 
            {
               if ( Directory.Exists ( directory ) )
               {
                  string[] files ;
                  string directoryName ;
                  
                  files         = Directory.GetFiles ( directory ) ;
                  directoryName = new DirectoryInfo ( directory ).Name ;
                  directoryName = Path.Combine ( destinationBaseDir, directoryName ) ;
                  
                  if ( !Directory.Exists ( directoryName ) )
                  {
                     Directory.CreateDirectory ( directoryName ) ;
                  }
                  
                  foreach ( string file in files ) 
                  {
                     CopyFile ( file, directoryName ) ;
                  }
                  
                  foreach ( string newSourceDir in Directory.GetDirectories ( directory ) )
                  {
                     CopyDirectory ( newSourceDir, directoryName ) ;
                  }
                  
                  return directoryName ;
               }
               else
               {
                  return string.Empty ;
               }
            }

            private static string CopyFile ( string file, string destinationBaseDir )
            {
               string fileName ;
               string destFile ;
               
               fileName = Path.GetFileName ( file ) ;
               destFile = Path.Combine ( destinationBaseDir, fileName ) ;
               
               File.Copy ( file, destFile, true ) ;
               
               return destFile ;
            }
            
         #endregion
         
         #region Properties
         
            private IDicomMediaProfileProcessor __DefaultProcessor
            {
               get
               {
                  if ( null == _defaultProcessor )
                  {
                     _defaultProcessor = new GeneralPurposeCDDVDProfileProcessor ( ) ;
                  }
                  
                  return _defaultProcessor ;
               }
            }
            
            private DirectoryInfo __MediaDirectory
            {
               get ;
               set ;
            }
            
         #endregion
         
         #region Events
         
            void profileProcessor_CopyFile ( object sender, CopyEventArgs e )
            {
               CopyFile ( e.Path, __MediaDirectory.FullName ) ;
            }

            void profileProcessor_CopyDirectory ( object sender, CopyEventArgs e )
            {
               CopyDirectory ( e.Path, __MediaDirectory.FullName ) ;
            }
            
         #endregion
         
         #region Data Members
         
            private IDicomMediaProfileProcessor _defaultProcessor ;
            
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

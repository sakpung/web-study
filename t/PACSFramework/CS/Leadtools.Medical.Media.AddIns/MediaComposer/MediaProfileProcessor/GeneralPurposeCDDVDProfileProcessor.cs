// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Leadtools.Dicom;
using Leadtools.Medical.Storage.DataAccessLayer;
using Leadtools.Dicom.Common.DataTypes;
using System.IO;

namespace Leadtools.Medical.Media.AddIns.Composing
{
   
   public class GeneralPurposeCDDVDProfileProcessor : IDicomMediaProfileProcessor
   {
      #region Public
         
         #region Methods
         
            public GeneralPurposeCDDVDProfileProcessor ( ) 
            {
               CurrentProfile = MediaProfiles.GeneralPurposeCDInterchange.Name ;
               CDStoreMode1   = true ;
            }
            
            public virtual void SetProfile ( string profile ) 
            {
               CurrentProfile = profile ;
            }
               
            public virtual bool CanProcess ( string profile )
            {
               return ( profile == MediaProfiles.GeneralPurposeCDInterchange.Name ||
                        profile == MediaProfiles.GeneralPurposeDVDInterchange.Name) ;
                  
               //case "STD-GEN-DVD-RAM":
               //case "STD-GEN-SEC-CD":
               //case "STD-GEN-SEC-DVD-RAM":
            }

            public virtual void BeforeAddingToDicomDir
            (
               string referencedInstancePath, 
               CompositeInstanceDataSet.InstanceRow instance,
               bool allowLossyCompression
            )
            {
               if ( instance.TransferSyntax != DicomUidType.ExplicitVRLittleEndian )
               {
                  using ( DicomDataSet ds = new DicomDataSet ( ) ) 
                  {
                     ds.Load ( referencedInstancePath, DicomDataSetLoadFlags.None ) ;
                     
                     ds.ChangeTransferSyntax ( DicomUidType.ExplicitVRLittleEndian, 0, ChangeTransferSyntaxFlags.None ) ;
                     
                     ds.Save (  referencedInstancePath, DicomDataSetSaveFlags.None ) ;
                  }
               }
            }

            public virtual void AfterAddingToDicomDir
            (
               string referencedInstance, 
               CompositeInstanceDataSet.InstanceRow instance, 
               DicomDataSet dicomDir
            )
            {
               
            }
            
            public virtual void OnDicomDirCompleted ( DicomDataSet dicomDir ) 
            {
               
            }
            
            public virtual void IncludeDisplayApplication ( )
            {
               if ( !string.IsNullOrEmpty ( ViewerDirectory ) )
               {
                  OnCopyDirectory ( ViewerDirectory ) ;
               }
            }

            public virtual void IncludeNonDicomObjects 
            ( 
               IncludeNonDicomObjects nonDicomObjectType
            )
            {
               if ( null != NonDicomDirectories ) 
               {
                  foreach ( string directory in NonDicomDirectories ) 
                  {
                     OnCopyDirectory ( directory ) ;
                  }
               }
               
               if ( null != NonDicomFiles ) 
               {
                  foreach ( string file in NonDicomFiles ) 
                  {
                     OnCopyFile ( file ) ;
                  }
               }
            }
            
            public virtual long GetProfileMediaSize ( ) 
            {
               if ( CurrentProfile == MediaProfiles.GeneralPurposeCDInterchange.Name ) 
               {
                  if ( CDStoreMode1 ) 
                  {
                     return Constants.CSMode1Size ;
                  }
                  else
                  {
                     return Constants.CSMode2Size ;
                  }
               }
               else if ( CurrentProfile == MediaProfiles.GeneralPurposeDVDInterchange.Name )
               {
                  return Constants.DVDSIZE ;
               }
               else
               {
                  return 0 ;
               }
            }
            
            public virtual long CalculateRemainingDataSize ( long dicomObjectsSize )
            {
               return GetProfileMediaSize ( ) - ( dicomObjectsSize + ViewerSize + NonDicomObjectsSize ) ;
            }
         
         #endregion
         
         #region Properties
         
            public string ViewerDirectory
            {
               get ;
               set ;
            }
            
            public string [] NonDicomDirectories
            {
               get ;
               set ;
            }
            
            public string [] NonDicomFiles
            {
               get ;
               set ;
            }
            
            public bool CDStoreMode1
            {
               get ;
               set ;
            }
            
            public int ViewerSize 
            {
               get ;
               set ;
            }
            
            public int NonDicomObjectsSize
            {
               get ;
               set ;
            }
            
            public string CurrentProfile
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
         
            public event EventHandler <CopyEventArgs> CopyDirectory ;
            public event EventHandler <CopyEventArgs> CopyFile ;
            
         #endregion
         
      #endregion
      
      #region Protected
         
         #region Methods
         
            protected void OnCopyDirectory ( string directoryPath ) 
            {
               if ( null != CopyDirectory ) 
               {
                  CopyDirectory ( this, new CopyEventArgs ( directoryPath ) ) ;
               }
            }
            protected void OnCopyFile ( string filePath ) 
            {
               if ( null!= CopyFile ) 
               {
                  CopyFile ( this, new CopyEventArgs ( filePath ) ) ;
               }
            }
            
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
         
         #endregion
         
         #region Properties
            
         #endregion
         
         #region Events
            
         #endregion
         
         #region Data Members
            
         #endregion
         
         #region Data Types Definition
         
            private static class Constants
            {
               public const int CSMode1Size = 700 ;
               public const int CSMode2Size = 630 ;
               public const int DVDSIZE     = 4812 ;
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

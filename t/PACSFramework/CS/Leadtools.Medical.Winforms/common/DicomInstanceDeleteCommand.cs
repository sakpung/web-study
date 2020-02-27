// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Leadtools.Medical.Storage.DataAccessLayer;
using System.IO;
using System.Data;
using System.Diagnostics;
using Leadtools.Medical.Winforms.DatabaseManager;
using Leadtools.Dicom;
using Leadtools.Dicom.Scp.Command;

namespace Leadtools.Medical.Winforms.Common
{
   public class DicomInstanceDeleteCommand
   {
      public IStorageDataAccessAgent DataAccess { get ; private set ; }
      public bool DeleteFiles { get ; set ; }
      public bool BackupFilesOnDatabaseDelete { get ; set ; }
      public string BackupFilesOnDeleteFolder { get ; set ; }
      public bool ContinueOnError { get ; set ; }
      
      public DicomInstanceDeleteCommand ( IStorageDataAccessAgent dataAccess ) 
      {
         DeleteFiles = true ;
         DataAccess = dataAccess ;
      }
      
      public event EventHandler <InstanceEventArgs> InstanceDeleting ;
      public event EventHandler <InstanceEventArgs> InstanceDeleted ;
      public event EventHandler <InstanceEventArgs> InstanceDeleteError ;
      
      public event EventHandler <ReferencedImageEventArgs> ReferencedImageDeleting ;
      public event EventHandler <ReferencedImageEventArgs> ReferencedImageDeleted ;
      public event EventHandler <ReferencedImageEventArgs> ReferencedImageDeleteError ;

      public DataRow[] GetReferencedImagesRows(DataRow image)
      {
         if ((image.Table.ChildRelations["FK_Instance_ReferencedImages"] == null))
         {
            return new DataRow[0];
         }
         else
         {
            return (image.GetChildRows(image.Table.ChildRelations["FK_Instance_ReferencedImages"]));
         }
      }
      
      public virtual void  DeleteReferencedImages(DataRow image)
      {
#if (LEADTOOLS_V19_OR_LATER)
         if (image.IsHangingProtocol())
            return;
#endif
         DataRow[] referencedImages = GetReferencedImagesRows(image);

         foreach (DataRow referencedImage in referencedImages)
         {
            OnReferencedImageDeleting(referencedImage);

            string sReferencedFile = RegisteredDataRows.InstanceInfo.ReferencedFile(referencedImage);
            if (File.Exists(sReferencedFile))
            {
               try
               {
                  File.Delete(sReferencedFile);

                  OnReferencedImageDeleted(referencedImage);
               }
               catch (Exception)
               {
                  if (ContinueOnError)
                  {
                     OnReferencedImageDeleteError(referencedImage);
                  }
               }

               // Delete the .info image if it exists
               string infoFile = sReferencedFile + ".info";
               if (File.Exists(infoFile))
               {
                  try
                  {
                     File.Delete(infoFile);
                  }
                  catch (Exception)
                  {
                  }
               }
            }
         }
      }
      
      public virtual void DeleteInstance(DataRow image)
      {
         string sReferencedFile = RegisteredDataRows.InstanceInfo.ReferencedFile(image);
         string sStoreToken = string.Empty;
#if (LEADTOOLS_V19_OR_LATER_MEDICAL_EXTERNAL_STORE) || (LEADTOOLS_V19_OR_LATER)
         sStoreToken = RegisteredDataRows.InstanceInfo.StoreToken(image);
#endif

         if (!string.IsNullOrEmpty(sReferencedFile) || !string.IsNullOrEmpty(sStoreToken))
         {
            OnInstanceDeleting(image);

#if (LEADTOOLS_V19_OR_LATER_MEDICAL_EXTERNAL_STORE) || (LEADTOOLS_V19_OR_LATER)
            if (DeleteFiles && RegisteredDataRows.InstanceInfo.ExistsDicomDataSet(image))
#else
            if (DeleteFiles && File.Exists(sReferencedFile))
#endif
            {
               try
               {
                  if (DeleteFiles && BackupFilesOnDatabaseDelete && File.Exists(sReferencedFile))
                  {
                     string destFile = Path.Combine(BackupFilesOnDeleteFolder, Path.GetFileNameWithoutExtension(sReferencedFile) +
                                                    "_" + DateTime.Now.Ticks.ToString() +
                                                    Path.GetExtension(sReferencedFile));
                     File.Copy(sReferencedFile, destFile);
                  }

#if (LEADTOOLS_V19_OR_LATER_MEDICAL_EXTERNAL_STORE) || (LEADTOOLS_V19_OR_LATER)
                  RegisteredDataRows.InstanceInfo.DeleteDicomDataSet(image);

                  string sopClassUid = RegisteredDataRows.InstanceInfo.GetElementValue(image, DicomTag.SOPClassUID);
                  if (!string.IsNullOrEmpty(sopClassUid))
                  {
                     if (string.Compare(sopClassUid, DicomUidType.HangingProtocolStorage, true) != 0)
                     {
                        // Only send the Delete Message if it is not a hanging protocol file
                        var handlerSendMessageQueue = CStoreCommand.SendMessageQueue;
                        if (handlerSendMessageQueue != null)
                        {
                           string sopInstanceUid = RegisteredDataRows.InstanceInfo.GetElementValue(image, DicomTag.SOPInstanceUID);
                           handlerSendMessageQueue(null, @"delete", sopInstanceUid, sReferencedFile);
                        }
                     }
                  }


#else
                  File.Delete(sReferencedFile);
#endif

                  OnInstanceDeleted(image);
               }
               catch (Exception)
               {
                  if (ContinueOnError)
                  {
                     OnInstanceDeleteError(image);
                  }
                  else
                  {
                     throw;
                  }
               }
            }
         }
      }
      
      public virtual void DeleteInstances ( DataRow[] instances )
      {
         if (DeleteFiles && BackupFilesOnDatabaseDelete)
         {
            // make sure backup directory exists
            if (!Directory.Exists(BackupFilesOnDeleteFolder))
            {
               Directory.CreateDirectory(BackupFilesOnDeleteFolder);
            }
         }

         foreach (DataRow image in instances)
         {
#if (LEADTOOLS_V19_OR_LATER_MEDICAL_EXTERNAL_STORE) || (LEADTOOLS_V19_OR_LATER)
            DeleteInstance(image);
            DeleteReferencedImages(image);
            RegisteredDataRows.InstanceInfo.DeleteDicomDataSetDirectory(image);
#else
            string sReferencedFile = RegisteredDataRows.InstanceInfo.ReferencedFile(image);
            DeleteInstance(image);
            DeleteReferencedImages(image);
            DeleteDirectories(Path.GetDirectoryName(sReferencedFile));
#endif
         }
      }

#if !(LEADTOOLS_V19_OR_LATER_MEDICAL_EXTERNAL_STORE)
   private void DeleteDirectories(string directory)
      {
         string[] remainingFiles = Directory.GetFiles(directory);
         string[] remainingDirs = Directory.GetDirectories(directory);

         if ((remainingFiles.Length == 1) &&
              (Path.GetFileName(remainingFiles[0]) == "key") &&
              remainingDirs.Length == 0)
         {
            File.Delete(remainingFiles[0]);

            Directory.Delete(directory);

            DeleteDirectories(Directory.GetParent(directory).FullName);
         }
      }
#endif


      private void OnInstanceDeleteError(DataRow /*CompositeInstanceDataSet.InstanceRow*/ image)
      {
         if ( null != InstanceDeleteError ) 
         {
            InstanceDeleteError ( this, new InstanceEventArgs ( image ) );
         }
      }
      
      private void OnInstanceDeleting ( DataRow /*CompositeInstanceDataSet.InstanceRow*/ instance ) 
      {
         if ( null != InstanceDeleting )
         {
            InstanceDeleting ( this, new InstanceEventArgs ( instance ) );
         }
      }
      
      private void OnInstanceDeleted ( DataRow /*CompositeInstanceDataSet.InstanceRow*/ instance ) 
      {
         if ( null != InstanceDeleted )
         {
            InstanceDeleted ( this, new InstanceEventArgs ( instance ) );
         }
      }
      
      private void OnReferencedImageDeleteError(DataRow /*CompositeInstanceDataSet.ReferencedImagesRow*/ image)
      {
         if ( null != ReferencedImageDeleteError ) 
         {
            ReferencedImageDeleteError ( this, new ReferencedImageEventArgs ( image ) );
         }
      }
      
      private void OnReferencedImageDeleting ( DataRow /*CompositeInstanceDataSet.ReferencedImagesRow*/ instance ) 
      {
         if ( null != ReferencedImageDeleting )
         {
            ReferencedImageDeleting ( this, new ReferencedImageEventArgs ( instance ) );
         }
      }
      
      private void OnReferencedImageDeleted ( DataRow /*CompositeInstanceDataSet.ReferencedImagesRow*/ instance ) 
      {
         if ( null != ReferencedImageDeleted )
         {
            ReferencedImageDeleted ( this, new ReferencedImageEventArgs ( instance ) );
         }
      }
   }
   
   public class InstanceEventArgs : EventArgs
   {
      public DataRow /*CompositeInstanceDataSet.InstanceRow*/ Instance { get ; private set ; }
      
      public InstanceEventArgs ( DataRow /*CompositeInstanceDataSet.InstanceRow*/ instance )
      {
         Instance = instance ;
      }
   }
   
   public class ReferencedImageEventArgs : EventArgs
   {
      public DataRow /*CompositeInstanceDataSet.InstanceRow*/ ReferencedImage { get ; private set ; }
      
      public ReferencedImageEventArgs ( DataRow /*CompositeInstanceDataSet.InstanceRow*/ referencedImage )
      {
         ReferencedImage = referencedImage ;
      }
   }
}

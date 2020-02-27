// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Leadtools.Medical.Storage.DataAccessLayer;
using Leadtools.Medical.Workstation.DataAccessLayer;
using System.IO;
using Leadtools.Medical.Winforms.EventBrokerArgs;
using System.Windows.Forms;
using Leadtools.Medical.DataAccessLayer;
using Leadtools.Medical.Workstation.DataAccessLayer.Configuration;
using System.Threading;
using System.Data;
using Leadtools.Dicom;
using Leadtools.DicomDemos;

namespace Leadtools.Medical.Winforms.DatabaseManager
{
   public class DicomFileDeleter
   {
      private IWorkstationDataAccessAgent wsAgent;

      private bool _DeleteReferencedImagesOnImageDelete;

      public bool DeleteReferencedImagesOnImageDelete
      {
         get { return _DeleteReferencedImagesOnImageDelete; }
         set { _DeleteReferencedImagesOnImageDelete = value; }
      }

      private bool _DeleteAnnotationsOnImageDelete;

      public bool DeleteAnnotationsOnImageDelete
      {
         get { return _DeleteAnnotationsOnImageDelete; }
         set { _DeleteAnnotationsOnImageDelete = value; }
      }

      private bool _DeleteFilesOnDatabaseDelete;

      public bool DeleteFilesOnDatabaseDelete
      {
        get { return _DeleteFilesOnDatabaseDelete; }
        set { _DeleteFilesOnDatabaseDelete = value; }
      }

      private bool _BackupFilesOnDatabaseDelete;

      public bool BackupFilesOnDatabaseDelete
      {
        get { return _BackupFilesOnDatabaseDelete; }
        set { _BackupFilesOnDatabaseDelete = value; }
      }

      private string _BackupFilesOnDeleteFolder;

      public string BackupFilesOnDeleteFolder
      {
         get { return _BackupFilesOnDeleteFolder; }
         set { _BackupFilesOnDeleteFolder = value; }
      }

      public event EventHandler<DicomFileDeletedEventArgs> DicomFileDeleted;

      protected void OnDicomFileDeleted(string referencedFile)
      {
         if (DicomFileDeleted != null)
         {
            DicomFileDeleted(this, new DicomFileDeletedEventArgs(referencedFile));
         }
      }

      public event EventHandler<DicomFileDeletedEventArgs> DicomFileDeleteFailed;

      protected void OnDicomFileDeleteFailed(string referencedFile)
      {
         if (DicomFileDeleteFailed != null)
         {
            DicomFileDeleteFailed(this, new DicomFileDeletedEventArgs(referencedFile));
         }
      }

      public DicomFileDeleter()
      {
         try
         {
            if (!DataAccessServices.IsDataAccessServiceRegistered<IWorkstationDataAccessAgent>())
            {
               wsAgent = DataAccessFactory.GetInstance(new WorkstationDataAccessConfigurationView(/*DicomDemoSettingsManager.GetGlobalPacsConfiguration(), PacsProduct.ProductName, null*/  )).CreateDataAccessAgent<IWorkstationDataAccessAgent>();

               DataAccessServices.RegisterDataAccessService<IWorkstationDataAccessAgent>(wsAgent);
            }
            else
            {
               wsAgent = DataAccessServices.GetDataAccessService<IWorkstationDataAccessAgent>();
            }
         }
         catch 
         {
            wsAgent = null ;
         }
         _DeleteReferencedImagesOnImageDelete = true;
      }

      //public void Delete(Form parent, params CompositeInstanceDataSet.InstanceRow[] rows)
      public void Delete(Form parent, params DataRow[] rows)
      {
         string directory = string.Empty;

         if (DeleteFilesOnDatabaseDelete && BackupFilesOnDatabaseDelete)
         {
            // make sure backup directory exists
            if (!Directory.Exists(BackupFilesOnDeleteFolder))
            {
               Directory.CreateDirectory(BackupFilesOnDeleteFolder);
            }
         }

         foreach (DataRow row in rows)
         {
            string sReferencedFile = RegisteredDataRows.InstanceInfo.ReferencedFile(row);
            string sSOPInstanceUID = RegisteredDataRows.InstanceInfo.GetElementValue(row, DicomTag.SOPInstanceUID);
            string sSeriesInstanceUID = RegisteredDataRows.InstanceInfo.GetElementValue(row, DicomTag.SeriesInstanceUID);
            if (!string.IsNullOrEmpty(sReferencedFile))
            {
               DeleteAnnotations(sSOPInstanceUID);
               DeleteVolumes(sSeriesInstanceUID);

               if (DeleteFilesOnDatabaseDelete && File.Exists(sReferencedFile))
               {
                  try
                  {
                     if (DeleteFilesOnDatabaseDelete && BackupFilesOnDatabaseDelete)
                     {
                        string destFile = Path.Combine(BackupFilesOnDeleteFolder, Path.GetFileNameWithoutExtension(sReferencedFile) +
                                                          "_" + DateTime.Now.Ticks.ToString() +
                                                          Path.GetExtension(sReferencedFile));
                        File.Copy(sReferencedFile, destFile,true);
                     }

                     File.Delete(sReferencedFile);
                     OnDicomFileDeleted(sReferencedFile);
                     
                     //DeleteDirectories(Path.GetDirectoryName(row.ReferencedFile));

                     EventBroker.Instance.PublishEvent<DicomFileDeletedEventArgs>(this, new DicomFileDeletedEventArgs(sReferencedFile));
                  }
                  catch (Exception ex)
                  {
                     if (parent!=null)
                     {
                        StatusReport.Instance.OperationErrorStatus(string.Format("Failed to delete file: {0}.  Reason: {1}", sReferencedFile, ex.Message));

                        EnsureReportVisible(parent);
                     }
                     OnDicomFileDeleteFailed(sReferencedFile);
                  }
               }
            }

            // Add property 'DeleteReferencedImagesOnImageDelete' for ExternalStore (i.e. cloud)
            // For external store Clean, don't want to delete referenced images 
            if (DeleteReferencedImagesOnImageDelete)
            {
               DataRow[] referencedImages = RegisteredDataRows.InstanceInfo.GetReferencedImagesRows(row);

               // foreach ( CompositeInstanceDataSet.ReferencedImagesRow referencedImage in referencedImages )
               foreach (DataRow referencedImage in referencedImages)
               {
                  string sReferencedImageFile = RegisteredDataRows.ReferencedImageInfo.ReferencedFile(referencedImage);
                  if (File.Exists(sReferencedImageFile))
                  {
                     try
                     {
                        File.Delete(sReferencedImageFile);

                        EventBroker.Instance.PublishEvent<ImageFileDeletedEventArgs>(this, new ImageFileDeletedEventArgs(sReferencedImageFile));
                     }
                     catch (Exception)
                     {
                        if (parent != null)
                        {
                           StatusReport.Instance.OperationErrorStatus(string.Format("Failed to delete file: {0}", sReferencedImageFile));

                           EnsureReportVisible(parent);
                        }
                     }
                  }
               }
            }

            if (DeleteFilesOnDatabaseDelete)
            {
               DeleteDirectories(Path.GetDirectoryName(sReferencedFile));
            }
         }
      }

      private void EnsureReportVisible(Form parent)
      {
         if (StatusReport.Instance.Visible)
         {
            StatusReport.Instance.Focus();
         }
         else
         {
            if (null == StatusReport.Instance.Owner)
            {
               StatusReport.Instance.Owner = parent.FindForm();
            }

            StatusReport.Instance.Show(parent);
         }
      }

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

      private void DeleteVolumes(string seriesInstanceUID)
      {
         VolumeIdentifier[] volumes;

         if (wsAgent != null)
         {
            volumes = wsAgent.GetVolumes(seriesInstanceUID);

            foreach (VolumeIdentifier volume in volumes)
            {
               wsAgent.DeleteVolume(volume);
            }
         }
      }

      private void DeleteAnnotations(string sopInstanceUID)
      {
         try
         {
            AnnotationIdentifier[] annotations;

            if (!DeleteAnnotationsOnImageDelete || null == wsAgent )
            {
               return;
            }

            annotations = wsAgent.GetAnnotationIdentifier(sopInstanceUID);

            if (null != annotations && annotations.Length > 0)
            {
               foreach (AnnotationIdentifier annotation in annotations)
               {
                  string annotationFile;


                  annotationFile = wsAgent.GetAnnotationFile(annotation);

                  wsAgent.DeleteAnnotationObject(annotation);

                  if (File.Exists(annotationFile))
                  {
                     File.Delete(annotationFile);
                  }
               }
            }
         }
         catch (Exception)
         {
            throw;
         }
      }
   }
}

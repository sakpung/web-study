// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Leadtools.Medical.Storage.AddIns;
using Leadtools.Dicom.AddIn.Configuration;
using Leadtools.Medical.Storage.AddIns.Configuration;
using Leadtools.Dicom.Scp.Command;
using System.IO;
using System.Windows.Forms;
using Leadtools.Medical.Winforms;
using Leadtools.Dicom;
using Leadtools.Medical.Storage.DataAccessLayer;
using Leadtools.Medical.DataAccessLayer;
using Leadtools.Medical.DataAccessLayer.Configuration;
using Leadtools.Dicom.AddIn;
using Leadtools.Dicom.Common.Extensions;
using System.Threading;
using static Leadtools.Medical.Winforms.GenerateMetadataBackgroundWorker;

#if (LEADTOOLS_V19_OR_LATER)
using Leadtools.Medical.Storage.AddIns.Controls.StorageCommit;
#endif

namespace Leadtools.Medical.Storage.AddIns
{
   public class StorageSettingsPresenter
   {
      public StorageSettingsPresenter ( StorageModuleConfigurationManager configurationManager ) 
      {
         _configurationManager = configurationManager ;
      }
      
      private string _serviceName;

      private bool _stopGenerate = false;

      public string ServiceName
      {
         get 
         { 
            return _serviceName; 
         }
         set 
         { 
            _serviceName = value; 
         }
      }

      public void RunViews ( StorageOptionsView storageView, QueryOptionsView queryView )
      {
         RunViews(storageView, queryView, true);
      }

      
      public void RunViews ( StorageOptionsView storageView, QueryOptionsView queryView, bool addHandlers )
      {
         _storageView = storageView ;
         _queryView   = queryView ;

         FillServiceStatusItems();
         _queryView.InitializeServiceStatusItems();
         
         if ( _configurationManager.IsLoaded )
         {
            StorageAddInsConfiguration storageSettings = _configurationManager.GetStorageAddInsSettings(ServiceName);
            
            storageView.AddInsSettings = storageSettings ;
            queryView.AddInsSettings   = storageSettings ;
            
            storageView.Enabled = true ;
            queryView.Enabled   = true ;
            ResetView();
         }
         else
         {
            storageView.Enabled = false ;
            queryView.Enabled   = false ;
         }

         _storageView.AddImageFormat += new EventHandler(_storageView_AddImageFormat);
         _storageView.EditImageFormat += new EventHandler(_storageView_EditImageFormat);
         _storageView.DeleteImageFormat += new EventHandler(_storageView_DeleteImageFormat);

#if (LEADTOOLS_V20_OR_LATER)
         _storageView.GenerateAllJsonMetadata += _storageView_GenerateAllJsonMetadata;
         _storageView.GenerateMissingJsonMetadata += _storageView_GenerateMissingJsonMetadata;
         _storageView.DeleteJsonMetadata += _storageView_DeleteJsonMetadata;
         _storageView.StopGenerateJsonMetadata += _storageView_StopGenerateJsonMetadata;

         _storageView.GenerateAllXmlMetadata += _storageView_GenerateAllXmlMetadata;
         _storageView.GenerateMissingXmlMetadata += _storageView_GenerateMissingXmlMetadata;
         _storageView.DeleteXmlMetadata += _storageView_DeleteXmlMetadata;
         _storageView.StopGenerateXmlMetadata += _storageView_StopGenerateXmlMetadata;
#endif // #if (LEADTOOLS_V20_OR_LATER)                 
         if (addHandlers)
         {
            _storageView.SettingsChanged += new EventHandler(View_SettingsChanged);
            _queryView.SettingsChanged += new EventHandler(View_SettingsChanged);

            // Files Tab
            _storageView.StorageLocationChanged += new EventHandler(_storageView_StorageLocationChanged);
#if (LEADTOOLS_V19_OR_LATER)
            _storageView.HangingProtocolLocationChanged += new EventHandler(_storageView_HangingProtocolLocationChanged);
#endif // #if (LEADTOOLS_V19_OR_LATER)
            _storageView.FileExtensionChanged += new EventHandler(_storageView_FileExtensionChanged);
            _storageView.CreateBackupChanged += new EventHandler(_storageView_CreateBackupChanged);
            _storageView.OverwriteBackupLocationChanged += new EventHandler(_storageView_OverwriteBackupLocationChanged);
            _storageView.DeleteFilesChanged += new EventHandler(_storageView_DeleteFilesChanged);
            _storageView.BackupFilesOnDeleteChanged += new EventHandler(_storageView_BackupFilesOnDeleteChanged);
            _storageView.DeleteBackupLocationChanged += new EventHandler(_storageView_DeleteBackupLocationChanged);
            _storageView.SaveCStoreFailuresChanged += new EventHandler(_storageView_SaveCStoreFailuresChanged);
            _storageView.CStoreFailuresLocationChanged += new EventHandler(_storageView_CStoreFailuresLocationChanged);

            // Directory Structure Tab
            _storageView.CreatePatientFolderChanged += new EventHandler(_storageView_CreatePatientFolderChanged);
            _storageView.UsePatientIdChanged += new EventHandler(_storageView_UsePatientIdChanged);
            _storageView.SplitPatientIdChanged += new EventHandler(_storageView_SplitPatientIdChanged);
            _storageView.CreateStudyFolderChanged += new EventHandler(_storageView_CreateStudyFolderChanged);
            _storageView.CreateSeriesFolderChanged += new EventHandler(_storageView_CreateSeriesFolderChanged);

            // Images Tab
            _storageView.CreateThumbChanged += new EventHandler(_storageView_CreateThumbChanged);
            _storageView.ThumbWidthChanged += new EventHandler(_storageView_ThumbWidthChanged);
            _storageView.ThumbHeightChanged += new EventHandler(_storageView_ThumbHeightChanged);
            _storageView.ThumbQFactorChanged += new EventHandler(_storageView_ThumbQFactorChanged);
            _storageView.ThumbFormatChanged += new EventHandler(_storageView_ThumbFormatChanged);

            // Options Tab
            _storageView.PreventStoringDuplicatesChanged += new EventHandler(_storageView_PreventStoringDuplicatesChanged);
            _storageView.UpdateExistingPatientChanged += new EventHandler(_storageView_UpdateExistingPatientChanged);
            _storageView.UpdateExistingStudyChanged += new EventHandler(_storageView_UpdateExistingStudyChanged);
            _storageView.UpdateExistingSeriesChanged += new EventHandler(_storageView_UpdateExistingSeriesChanged);
            _storageView.UpdateExistingInstanceChanged += new EventHandler(_storageView_UpdateExistingInstanceChanged);
            _storageView.AutoTruncateDataChanged += new EventHandler(_storageView_AutoTruncateDataChanged);
            _storageView.UseMessageQueueDataChanged += new EventHandler(_storageView_UseMessageQueueChanged);

            // Query Settings
            _queryView.AllowZeroItemsChanged += new EventHandler(_queryView_AllowZeroItemsChanged);
            _queryView.AllowMultipleItemsChanged += new EventHandler(_queryView_AllowMultipleItemsChanged);
            _queryView.AllowPrivateItemsChanged += new EventHandler(_queryView_AllowPrivateItemsChanged);
            _queryView.AllowExtraItemsChanged += new EventHandler(_queryView_AllowExtraItemsChanged);
            _queryView.PatientRelatedStudiesChanged += new EventHandler(_queryView_PatientRelatedStudiesChanged);
            _queryView.PatientRelatedSeriesChanged += new EventHandler(_queryView_PatientRelatedSeriesChanged);
            _queryView.PatientRelatedInstancesChanged += new EventHandler(_queryView_PatientRelatedInstancesChanged);
            _queryView.StudyRelatedSeriesChanged += new EventHandler(_queryView_StudyRelatedSeriesChanged);
            _queryView.StudyRelatedInstancesChanged += new EventHandler(_queryView_StudyRelatedInstancesChanged);
            _queryView.SeriesRelatedInstancesChanged += new EventHandler(_queryView_SeriesRelatedInstancesChanged);
            _queryView.IodXmlPathChanged += new EventHandler(_queryView_IodXmlPathChanged);

            _queryView.LimitCFindRspChanged += new EventHandler(_queryView_LimitCFindRspChanged);
            _queryView.MaximumCountCFindRspChanged += new EventHandler(_queryView_MaximumCountCFindRspChanged);
            _queryView.ServiceStatusChanged += new EventHandler(_queryView_ServiceStatusChanged);

#if (LEADTOOLS_V20_OR_LATER)
            StorageDataAccess4.GenerateMetadataStarting += StorageDataAccess4_GenerateMetadataStarting;
            StorageDataAccess4.GenerateMetadataUpdate += StorageDataAccess4_GenerateMetadataUpdate;
            StorageDataAccess4.GenerateMetadataCompleted += StorageDataAccess4_GenerateMetadataCompleted;
#endif 
         }
      }

#if (LEADTOOLS_V20_OR_LATER)
      MetadataCategory GetMetadataCagetory(MetadataOptions options)
      {
         MetadataCategory category = MetadataCategory.None;
         if (options.StoreJson && options.StoreXml)
            category = MetadataCategory.All;
         else if (options.StoreJson)
            category = MetadataCategory.Json;
         else if (options.StoreXml)
            category = MetadataCategory.Xml;
         return category;
      }

      private void StorageDataAccess4_GenerateMetadataCompleted(object sender, GenerateMetadataArgs e)
      {
         string messageBoxDescription = "Generate Metadata";
         this.StorageView.EnableMetadataItems(true, e.Options);

         string status;
         MetadataCategory category = GetMetadataCagetory(e.Options);
        
         if (e.Cancelled)
         {
            status = string.Format("Generating {2} Metadata Stopped: Completed {0} of {1} records", e.CurrentItem+1, e.TotalCount, GetMetadataStoreString(e));
         }
         else
         {
            status = string.Format("Generating {2} Metadata Completed {0} of {1} records", e.CurrentItem+1,  e.TotalCount, GetMetadataStoreString(e));
         }
         this.StorageView.ShowMetadataStatus(status);
         EventBroker.Instance.PublishEvent<MetadataEventArgs>(this, new MetadataEventArgs(MetadataCommand.Generate, category, e.Scope, true, string.Empty, e.CurrentItem + 1, e.TotalCount, e.Cancelled));

         MessageBox.Show(status, messageBoxDescription, MessageBoxButtons.OK, MessageBoxIcon.Information);
         this.StorageView.ShowMetadataStatus(string.Empty);

         _stopGenerate = false;
      }

      private void StorageDataAccess4_GenerateMetadataUpdate(object sender, GenerateMetadataArgs e)
      {
         string status = string.Format("Generating {2} Metadata {0}/{1} ...", e.CurrentItem+1, e.TotalCount, GetMetadataStoreString(e));

         if (_stopGenerate)
         {
            e.Cancelled = true;
         }
         this.StorageView.ShowMetadataStatus(status);
      }

      string GetMetadataStoreString(GenerateMetadataArgs args)
      {
         return  args.Options.StoreJson ? "JSON" : "XML";
      }

      private void StorageDataAccess4_GenerateMetadataStarting(object sender, GenerateMetadataArgs e)
      {
         this.StorageView.EnableMetadataItems(false, e.Options);

         string status = string.Format("Start {0} Generating Metadata ...", GetMetadataStoreString(e));
         this.StorageView.ShowMetadataStatus(status);

         MetadataCategory category = GetMetadataCagetory(e.Options);
         EventBroker.Instance.PublishEvent<MetadataEventArgs>(this, new MetadataEventArgs(MetadataCommand.Generate, category, e.Scope, false, string.Empty, e.CurrentItem + 1, e.TotalCount, true));

      }
#endif // #if (LEADTOOLS_V20_OR_LATER)

      // Query Settings
      void _queryView_IodXmlPathChanged(object sender, EventArgs e)
      {
         LocalAuditLogQueue.AddAuditMessage(AuditMessages.IodXmlPathChanged.Key,
            string.Format(AuditMessages.IodXmlPathChanged.Message, _queryView.IodXmlPath));
      }

      void _queryView_SeriesRelatedInstancesChanged(object sender, EventArgs e)
      {
         LocalAuditLogQueue.AddAuditMessage(AuditMessages.SeriesRelatedInstancesChanged.Key,
            string.Format(AuditMessages.SeriesRelatedInstancesChanged.Message, _queryView.SeriesRelatedInstances));
      }

      void _queryView_StudyRelatedInstancesChanged(object sender, EventArgs e)
      {
         LocalAuditLogQueue.AddAuditMessage(AuditMessages.StudyRelatedInstancesChanged.Key,
            string.Format(AuditMessages.StudyRelatedInstancesChanged.Message, _queryView.StudyRelatedInstances));
      }

      void _queryView_StudyRelatedSeriesChanged(object sender, EventArgs e)
      {
         LocalAuditLogQueue.AddAuditMessage(AuditMessages.StudyRelatedSeriesChanged.Key,
            string.Format(AuditMessages.StudyRelatedSeriesChanged.Message, _queryView.StudyRelatedSeries));
      }

      void _queryView_PatientRelatedInstancesChanged(object sender, EventArgs e)
      {
         LocalAuditLogQueue.AddAuditMessage(AuditMessages.PatientRelatedInstancesChanged.Key,
            string.Format(AuditMessages.PatientRelatedInstancesChanged.Message, _queryView.PatientRelatedInstances));
      }

      void _queryView_PatientRelatedSeriesChanged(object sender, EventArgs e)
      {
         LocalAuditLogQueue.AddAuditMessage(AuditMessages.PatientRelatedSeriesChanged.Key,
            string.Format(AuditMessages.PatientRelatedSeriesChanged.Message, _queryView.PatientRelatedSeries));
      }

      void _queryView_PatientRelatedStudiesChanged(object sender, EventArgs e)
      {
         LocalAuditLogQueue.AddAuditMessage(AuditMessages.PatientRelatedStudiesChanged.Key,
            string.Format(AuditMessages.PatientRelatedStudiesChanged.Message, _queryView.PatientRelatedStudies));
      }

      void _queryView_AllowExtraItemsChanged(object sender, EventArgs e)
      {
         LocalAuditLogQueue.AddAuditMessage(AuditMessages.AllowExtraItemsChanged.Key,
            string.Format(AuditMessages.AllowExtraItemsChanged.Message, _queryView.AllowExtraItems));
      }

      void _queryView_AllowPrivateItemsChanged(object sender, EventArgs e)
      {
         LocalAuditLogQueue.AddAuditMessage(AuditMessages.AllowPrivateItemsChanged.Key,
            string.Format(AuditMessages.AllowPrivateItemsChanged.Message, _queryView.AllowPrivateItems));
      }

      void _queryView_AllowMultipleItemsChanged(object sender, EventArgs e)
      {
         LocalAuditLogQueue.AddAuditMessage(AuditMessages.AllowMultipleItemsChanged.Key,
            string.Format(AuditMessages.AllowMultipleItemsChanged.Message, _queryView.AllowMultipleItems));
      }

      void _queryView_AllowZeroItemsChanged(object sender, EventArgs e)
      {
         LocalAuditLogQueue.AddAuditMessage(AuditMessages.AllowZeroItemsChanged.Key,
            string.Format(AuditMessages.AllowZeroItemsChanged.Message, _queryView.AllowZeroItems));
      }

      void _queryView_LimitCFindRspChanged(object sender, EventArgs e)
      {
         LocalAuditLogQueue.AddAuditMessage(AuditMessages.LimitCFindRspChanged.Key,
            string.Format(AuditMessages.LimitCFindRspChanged.Message, _queryView.LimitCFindRsp));
      }
      
      void _queryView_MaximumCountCFindRspChanged(object sender, EventArgs e)
      {
         LocalAuditLogQueue.AddAuditMessage(AuditMessages.MaximumCountCFindRspChanged.Key,
            string.Format(AuditMessages.MaximumCountCFindRspChanged.Message, _queryView.MaximumCountCFindRsp));
      }
      
      void _queryView_ServiceStatusChanged(object sender, EventArgs e)
      {
         LocalAuditLogQueue.AddAuditMessage(AuditMessages.ServiceStatusChanged.Key,
            string.Format(AuditMessages.ServiceStatusChanged.Message, ServiceStatusItem.ToHexValue(_queryView.ServiceStatus)));
      }

      // Options Tab
      void _storageView_AutoTruncateDataChanged(object sender, EventArgs e)
      {
         LocalAuditLogQueue.AddAuditMessage(AuditMessages.AutoTruncateDataChanged.Key,
            string.Format(AuditMessages.AutoTruncateDataChanged.Message, _storageView.AutoTruncateData));
      }

      void _storageView_UseMessageQueueChanged(object sender, EventArgs e)
      {
         LocalAuditLogQueue.AddAuditMessage(AuditMessages.UseMessageQueueChanged.Key,
            string.Format(AuditMessages.UseMessageQueueChanged.Message, _storageView.UseMessageQueue));
      }

      void _storageView_UpdateExistingInstanceChanged(object sender, EventArgs e)
      {
         LocalAuditLogQueue.AddAuditMessage(AuditMessages.UpdateExistingInstanceChanged.Key,
            string.Format(AuditMessages.UpdateExistingInstanceChanged.Message, _storageView.UpdateExistingInstance));
      }

      void _storageView_UpdateExistingSeriesChanged(object sender, EventArgs e)
      {
         LocalAuditLogQueue.AddAuditMessage(AuditMessages.UpdateExistingSeriesChanged.Key,
            string.Format(AuditMessages.UpdateExistingSeriesChanged.Message, _storageView.UpdateExistingSeries));
      }

      void _storageView_UpdateExistingStudyChanged(object sender, EventArgs e)
      {
         LocalAuditLogQueue.AddAuditMessage(AuditMessages.UpdateExistingStudyChanged.Key,
            string.Format(AuditMessages.UpdateExistingStudyChanged.Message, _storageView.UpdateExistingStudy));
      }

      void _storageView_UpdateExistingPatientChanged(object sender, EventArgs e)
      {
         LocalAuditLogQueue.AddAuditMessage(AuditMessages.UpdateExistingPatientChanged.Key,
            string.Format(AuditMessages.UpdateExistingPatientChanged.Message, _storageView.UpdateExistingPatient));
      }

      void _storageView_PreventStoringDuplicatesChanged(object sender, EventArgs e)
      {
         LocalAuditLogQueue.AddAuditMessage(AuditMessages.PreventStoringDuplicatesChanged.Key,
            string.Format(AuditMessages.PreventStoringDuplicatesChanged.Message, _storageView.PreventStoringDuplicates));
      }


      // Images Tab
      void _storageView_ThumbFormatChanged(object sender, EventArgs e)
      {
         LocalAuditLogQueue.AddAuditMessage(AuditMessages.ThumbFormatChanged.Key,
            string.Format(AuditMessages.ThumbFormatChanged.Message, _storageView.ThumbnailFormat));
      }

      void _storageView_ThumbQFactorChanged(object sender, EventArgs e)
      {
         LocalAuditLogQueue.AddAuditMessage(AuditMessages.ThumbQFactorChanged.Key,
            string.Format(AuditMessages.ThumbQFactorChanged.Message, _storageView.ThumbnailQualityFactor));
      }

      void _storageView_ThumbHeightChanged(object sender, EventArgs e)
      {
         LocalAuditLogQueue.AddAuditMessage(AuditMessages.ThumbHeightChanged.Key,
            string.Format(AuditMessages.ThumbHeightChanged.Message, _storageView.ThumbnailHeight));
      }

      void _storageView_ThumbWidthChanged(object sender, EventArgs e)
      {
         LocalAuditLogQueue.AddAuditMessage(AuditMessages.ThumbWidthChanged.Key,
            string.Format(AuditMessages.ThumbWidthChanged.Message, _storageView.ThumbnailWidth));
      }

      void _storageView_CreateThumbChanged(object sender, EventArgs e)
      {
         LocalAuditLogQueue.AddAuditMessage(AuditMessages.CreateThumbChanged.Key,
            string.Format(AuditMessages.CreateThumbChanged.Message, _storageView.CreateThumbnailImage));
      }

      // Directory Structure Tab
      void _storageView_CreateSeriesFolderChanged(object sender, EventArgs e)
      {
         LocalAuditLogQueue.AddAuditMessage(AuditMessages.CreateSeriesFolderChanged.Key,
            string.Format(AuditMessages.CreateSeriesFolderChanged.Message, _storageView.CreateSeriesFolder));
      }

      void _storageView_CreateStudyFolderChanged(object sender, EventArgs e)
      {
         LocalAuditLogQueue.AddAuditMessage(AuditMessages.CreateStudyFolderChanged.Key,
            string.Format(AuditMessages.CreateStudyFolderChanged.Message, _storageView.CreateStudyFolder));
      }

      void _storageView_SplitPatientIdChanged(object sender, EventArgs e)
      {
         LocalAuditLogQueue.AddAuditMessage(AuditMessages.SplitPatientIdChanged.Key,
            string.Format(AuditMessages.SplitPatientIdChanged.Message, _storageView.UsePatientId));
      }

      void _storageView_UsePatientIdChanged(object sender, EventArgs e)
      {
         LocalAuditLogQueue.AddAuditMessage(AuditMessages.UsePatientIdChanged.Key,
            string.Format(AuditMessages.UsePatientIdChanged.Message, _storageView.UsePatientId));
      }

      void _storageView_CreatePatientFolderChanged(object sender, EventArgs e)
      {
         LocalAuditLogQueue.AddAuditMessage(AuditMessages.CreatePatientFolderChanged.Key,
            string.Format(AuditMessages.CreatePatientFolderChanged.Message, _storageView.CreatePatientFolder));
      }


      // Files Tab
      void _storageView_CStoreFailuresLocationChanged(object sender, EventArgs e)
      {
         LocalAuditLogQueue.AddAuditMessage(AuditMessages.CStoreLocationChanged.Key,
            string.Format(AuditMessages.CStoreLocationChanged.Message, _storageView.SaveCStoreLocation));
      }

      void _storageView_DeleteBackupLocationChanged(object sender, EventArgs e)
      {
         LocalAuditLogQueue.AddAuditMessage(AuditMessages.BackupLocationChanged.Key,
            string.Format(AuditMessages.BackupLocationChanged.Message, _storageView.BackupLocation));
      }

      void _storageView_OverwriteBackupLocationChanged(object sender, EventArgs e)
      {
         LocalAuditLogQueue.AddAuditMessage(AuditMessages.OverwriteLocationChanged.Key,
            string.Format(AuditMessages.OverwriteLocationChanged.Message, _storageView.OverwriteBackupLocation));
      }

      void _storageView_SaveCStoreFailuresChanged(object sender, EventArgs e)
      {
         LocalAuditLogQueue.AddAuditMessage(AuditMessages.SaveCStoreFailuresChanged.Key,
            string.Format(AuditMessages.SaveCStoreFailuresChanged.Message, _storageView.SaveCStoreFailures));
      }

      void _storageView_BackupFilesOnDeleteChanged(object sender, EventArgs e)
      {
         LocalAuditLogQueue.AddAuditMessage(AuditMessages.BackupFilesOnDeleteChanged.Key,
            string.Format(AuditMessages.BackupFilesOnDeleteChanged.Message, _storageView.BackupFilesOnDelete));
      }

      void _storageView_DeleteFilesChanged(object sender, EventArgs e)
      {
         LocalAuditLogQueue.AddAuditMessage(AuditMessages.DeleteFilesChanged.Key,
            string.Format(AuditMessages.DeleteFilesChanged.Message, _storageView.DeleteDicomFiles));
      }

      void _storageView_CreateBackupChanged(object sender, EventArgs e)
      {
         LocalAuditLogQueue.AddAuditMessage(AuditMessages.CreateBackupChanged.Key,
            string.Format(AuditMessages.CreateBackupChanged.Message, _storageView.CreateBackupBeforeOverwrite));
      }

      void _storageView_StorageLocationChanged(object sender, EventArgs e)
      {
         LocalAuditLogQueue.AddAuditMessage ( AuditMessages.StorageLocationChanged.Key,
            string.Format(AuditMessages.StorageLocationChanged.Message, _storageView.StorageLocation));
      }
#if (LEADTOOLS_V19_OR_LATER)
      void _storageView_HangingProtocolLocationChanged(object sender, EventArgs e)
      {
         LocalAuditLogQueue.AddAuditMessage ( AuditMessages.HangingProtocolLocationChanged.Key,
            string.Format(AuditMessages.HangingProtocolLocationChanged.Message, _storageView.HangingProtocolLocation));
      }
#endif // #if (LEADTOOLS_V19_OR_LATER)
      void _storageView_FileExtensionChanged(object sender, EventArgs e)
      {
         LocalAuditLogQueue.AddAuditMessage(AuditMessages.FileExtensionChanged.Key,
            string.Format(AuditMessages.FileExtensionChanged.Message, _storageView.FileExtension));
      }

      public event EventHandler SettingsChanged;

#if (LEADTOOLS_V20_OR_LATER)
      private IStorageDataAccessAgent4 _storageDataAccess4 = null;
      private IStorageDataAccessAgent4 StorageDataAccess4
      {
         get
         {
            if (_storageDataAccess4 == null)
            {
               _storageDataAccess4 = AddInsSession.DataAccess as IStorageDataAccessAgent4;
            }
            if (_storageDataAccess4 == null)
            {
               _storageDataAccess4 = DataAccessServices.GetDataAccessService<IStorageDataAccessAgent>() as IStorageDataAccessAgent4;
            }
            return _storageDataAccess4;
         }
      }
#endif // #if (LEADTOOLS_V20_OR_LATER)

      private void View_SettingsChanged(object sender, EventArgs e)
      {
         try
         {
            if (SettingsChanged != null)
            {
               SettingsChanged(sender, e);
            }
         }
         catch (Exception)
         {
            System.Diagnostics.Debug.Assert(false);
         }
      }

      void _storageView_DeleteImageFormat(object sender, EventArgs e)
      {
         DeleteImageFormat();
      }

      void _storageView_EditImageFormat(object sender, EventArgs e)
      {
         EditImageFormat();
      }

      void _storageView_AddImageFormat(object sender, EventArgs e)
      {
         AddImageFormat();
      }

#if (LEADTOOLS_V20_OR_LATER)
      private void _storageView_DeleteJsonMetadata(object sender, EventArgs e)
      {
         int countMetadata = StorageDataAccess4.GetCountMetadataJson(MetadataScope.Existing);
         if (countMetadata == 0)
         {
            MessageBox.Show("There are no JSON Metadata records to delete.", "Delete JSON Metadata", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            return;
         }

         string message = string.Format("Are you sure you want to delete all JSON Metadata ({0} records)?\n\nNote that JSON Metadata can be regenerated by clicking one of the 'Generate JSON Metadata' buttons.\n\nType the reason for deleting all JSON Metadata records.", countMetadata);

         using (ConfirmWithReasonDialog confirmDlg = new ConfirmWithReasonDialog())
         {
            confirmDlg.Text = "Confirm Delete Metadata";
            confirmDlg.Message = message;
            confirmDlg.ConfirmCheckBoxVisible = false;
            confirmDlg.SetDefaultWarningIcon();

            if (confirmDlg.ShowDialog() == DialogResult.OK)
            {
               StorageDataAccess4.DeleteAllMetadataJson();

               EventBroker.Instance.PublishEvent<MetadataEventArgs>(this, new MetadataEventArgs(MetadataCommand.Delete, MetadataCategory.Json, MetadataScope.All, false, confirmDlg.Reason, 0, countMetadata, false));

               string deleteMessage = string.Format("All JSON Metadata has been deleted ({0} records).", countMetadata);
               MessageBox.Show(deleteMessage, "Delete JSON Metadata", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
         }
      }

      private void _storageView_DeleteXmlMetadata(object sender, EventArgs e)
      {
         int countMetadata = StorageDataAccess4.GetCountMetadataXml(MetadataScope.Existing);
         if (countMetadata == 0)
         {
            MessageBox.Show("There are no XML Metadata records to delete.", "Delete XML Metadata", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            return;
         }

         string message = string.Format("Are you sure you want to delete all XML Metadata ({0} records)?\n\nNote that XML Metadata can be regenerated by clicking one of the 'Generate XML Metadata' buttons.\n\nType the reason for deleting all XML Metadata records.", countMetadata);

         using (ConfirmWithReasonDialog confirmDlg = new ConfirmWithReasonDialog())
         {
            confirmDlg.Text = "Confirm Delete Metadata";
            confirmDlg.Message = message;
            confirmDlg.ConfirmCheckBoxVisible = false;
            confirmDlg.SetDefaultWarningIcon();

            if (confirmDlg.ShowDialog() == DialogResult.OK)
            {
               StorageDataAccess4.DeleteAllMetadataXml();

               EventBroker.Instance.PublishEvent<MetadataEventArgs>(this, new MetadataEventArgs(MetadataCommand.Delete, MetadataCategory.Xml, MetadataScope.All, false, confirmDlg.Reason, 0, countMetadata, false));

               string deleteMessage = string.Format("All XML Metadata has been deleted ({0} records).", countMetadata);
               MessageBox.Show(deleteMessage, "Delete XML Metadata", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
         }
      }

      private void _storageView_StopGenerateXmlMetadata(object sender, EventArgs e)
      {
         _stopGenerate = true;
      }

      private void _storageView_StopGenerateJsonMetadata(object sender, EventArgs e)
      {
         _stopGenerate = true;
      }

      private void GenerateJsonMetadata(MetadataScope scope)
      {
         _stopGenerate = false; 
         string messageBoxDescription = string.Format("Generate {0} JSON Metadata", scope.ToString() );
         MatchingParameterCollection mpc = new MatchingParameterCollection();

         // int countInstance = StorageDataAccess4.FindCompositeInstancesCount(mpc);
         int countInstance = StorageDataAccess4.GetCountMetadataJson(scope);

         if (countInstance == 0)
         {
            string messageNone = string.Empty;
            switch(scope)
            {
               case MetadataScope.All:
                  messageNone = "There is no JSON metadata to generate because there are no DICOM instances.";
                  break;

               case MetadataScope.Missing:
                  messageNone = "All JSON metadata is up to date (there is no missing JSON metadata).";
                  break;

               case MetadataScope.Existing:
                  messageNone = "There is no existing JSON metadata.";
                  break;
            }
            MessageBox.Show(messageNone, messageBoxDescription, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            return;
         }

         string message = string.Format("Are you sure you want to generate {1} JSON Metadata ({0} records)?", countInstance, scope.ToString().ToLower());
         if (MessageBox.Show(message, messageBoxDescription, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
         {
            StorageModuleConfigurationManager configManager = ServiceLocator.Retrieve<StorageModuleConfigurationManager>();
            if (configManager.IsLoaded)
            {
               StorageAddInsConfiguration storageSettings = configManager.GetStorageAddInsSettings();

               if (storageSettings != null)
               {

                  // EventBroker.Instance.PublishEvent<MetadataEventArgs>(this, new MetadataEventArgs(MetadataCommand.Generate, MetadataCategory.Json, scope, false, string.Empty, 0, countInstance, false));

                  new Thread(() =>
                  {
                     Thread.CurrentThread.IsBackground = true;

                     // var storeConfig = storageSettings.StoreAddIn;
                     DicomDataSetSaveJsonFlags flags =
                        (_storageView.JsonTrimWhiteSpace ? DicomDataSetSaveJsonFlags.TrimWhiteSpace : DicomDataSetSaveJsonFlags.None) |
                        (_storageView.JsonWriteKeyword ? DicomDataSetSaveJsonFlags.WriteKeyword : DicomDataSetSaveJsonFlags.None) |
                        (_storageView.JsonMinify ? DicomDataSetSaveJsonFlags.Minify : DicomDataSetSaveJsonFlags.None) |
                        DicomDataSetSaveJsonFlags.IgnoreBinaryData; //(_storageView.JsonIgnoreBinaryData ? DicomDataSetSaveJsonFlags.IgnoreBinaryData : DicomDataSetSaveJsonFlags.None);


                     MetadataOptions options = new MetadataOptions();
                     options.SaveJsonFlags = flags;
                     options.StoreJson = true;
                     StorageDataAccess4.GenerateMetadataJson(flags, scope);

                  }).Start();
               }
            }
         }
      }

      private void _storageView_GenerateMissingJsonMetadata(object sender, EventArgs e)
      {
         GenerateJsonMetadata(MetadataScope.Missing);
      }

      private void _storageView_GenerateAllJsonMetadata(object sender, EventArgs e)
      {
         GenerateJsonMetadata(MetadataScope.All);
      }

      private void GenerateXmlMetadata(MetadataScope scope)
      {
         _stopGenerate = false;
         string messageBoxDescription = string.Format("Generate {0} XML Metadata", scope.ToString());
         MatchingParameterCollection mpc = new MatchingParameterCollection();

         int countInstance = StorageDataAccess4.GetCountMetadataXml(scope);

         if (countInstance == 0)
         {
            string messageNone = string.Empty;
            switch (scope)
            {
               case MetadataScope.All:
                  messageNone = "There is no XML metadata to generate because there are no DICOM instances.";
                  break;

               case MetadataScope.Missing:
                  messageNone = "All XML metadata is up to date (there is no no missing XML metadata).";
                  break;

               case MetadataScope.Existing:
                  messageNone = "There is no existing XML metadata.";
                  break;
            }
            MessageBox.Show(messageNone, messageBoxDescription, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            return;
         }

         string message = string.Format("Are you sure you want to generate {1} XML Metadata ({0} records)?", countInstance, scope.ToString().ToLower());
         if (MessageBox.Show(message, messageBoxDescription, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
         {
            StorageModuleConfigurationManager configManager = ServiceLocator.Retrieve<StorageModuleConfigurationManager>();
            if (configManager.IsLoaded)
            {
               StorageAddInsConfiguration storageSettings = configManager.GetStorageAddInsSettings();

               if (storageSettings != null)
               {

                  new Thread(() =>
                  {
                     Thread.CurrentThread.IsBackground = true;

                     // var storeConfig = storageSettings.StoreAddIn;
                     DicomDataSetSaveXmlFlags flags =
                        (_storageView.XmlTrimWhiteSpace ? DicomDataSetSaveXmlFlags.TrimWhiteSpace : DicomDataSetSaveXmlFlags.None) |
                        (_storageView.XmlFullEndStatement ? DicomDataSetSaveXmlFlags.WriteFullEndElement : DicomDataSetSaveXmlFlags.None) |
                        DicomDataSetSaveXmlFlags.IgnoreBinaryData; //(_storageView.XmlIgnoreBinaryData ? DicomDataSetSaveXmlFlags.IgnoreBinaryData : DicomDataSetSaveXmlFlags.None);


                     MetadataOptions options = new MetadataOptions();
                     options.SaveXmlFlags = flags;
                     options.StoreXml = true;
                     StorageDataAccess4.GenerateMetadataXml(flags, scope);

                  }).Start();
               }
            }
         }
      }

      private void _storageView_GenerateAllXmlMetadata(object sender, EventArgs e)
      {
         GenerateXmlMetadata(MetadataScope.All);
      }

      private void _storageView_GenerateMissingXmlMetadata(object sender, EventArgs e)
      {
         GenerateXmlMetadata(MetadataScope.Missing);
      }
#endif // #if (LEADTOOLS_V20_OR_LATER)

      private void FillGenerateImagesFormatListView()
      {
         if (null == _storageView.AddInsSettings.StoreAddIn.ImagesFormat)
         {
            _storageView.AddInsSettings.StoreAddIn.ImagesFormat = new SaveImageFormatCollection();
         }

         _storageView.GenerateImagesListView.Items.Clear();
         foreach (SaveImageFormatElement imageFormat in _storageView.AddInsSettings.StoreAddIn.ImagesFormat)
         {
            if (imageFormat.Format != RasterImageFormat.TifJ2k.ToString ())
            {
               ListViewItem imageFormatItem = ToListViewItem(imageFormat);

               imageFormatItem.Tag = imageFormat;

               _storageView.AllowedFormats.Remove(imageFormat.Format);

               _storageView.GenerateImagesListView.Items.Add(imageFormatItem);
            }
         }
      }

      private static ListViewItem ToListViewItem(SaveImageFormatElement imageFormat)
      {
         ListViewItem imageFormatItem;


         imageFormatItem = new ListViewItem();

         imageFormatItem.Text = imageFormat.Width.ToString();

         imageFormatItem.SubItems.Add(imageFormat.Height.ToString());
         imageFormatItem.SubItems.Add(imageFormat.QFactor.ToString());
         imageFormatItem.SubItems.Add(imageFormat.Format.ToString());

         return imageFormatItem;
      }

      private static void UpdateListViewItem(SaveImageFormatElement imageFormat, ListViewItem listViewItem)
      {
         listViewItem.Text = imageFormat.Width.ToString();

         listViewItem.SubItems[1].Text = imageFormat.Height.ToString();
         listViewItem.SubItems[2].Text = imageFormat.QFactor.ToString();
         listViewItem.SubItems[3].Text = imageFormat.Format.ToString();
      }

      private void FillImagesFormatFromListView()
      {
         _storageView.AddInsSettings.StoreAddIn.ImagesFormat.Clear();

         foreach (ListViewItem imageFormatItem in _storageView.GenerateImagesListView.Items)
         {
            SaveImageFormatElement imageFormat;


            imageFormat = ToImageFormatElement(imageFormatItem);

            _storageView.AddInsSettings.StoreAddIn.ImagesFormat.Add(imageFormat);
         }
      }

      private static SaveImageFormatElement ToImageFormatElement(ListViewItem imageFormatItem)
      {
         SaveImageFormatElement imageFormat;

         imageFormat = new SaveImageFormatElement();

         imageFormat.Width = int.Parse(imageFormatItem.Text);
         imageFormat.Height = int.Parse(imageFormatItem.SubItems[1].Text);
         imageFormat.QFactor = int.Parse(imageFormatItem.SubItems[2].Text);
         imageFormat.Format = string.IsNullOrEmpty(imageFormatItem.SubItems[3].Text)?null:imageFormatItem.SubItems[3].Text;

         return imageFormat;
      }

      private static string GetQFactor(ImageFormatDialog imageFormatDlg)
      {
         string qFactor;
         if (imageFormatDlg.LosslessRadioButton.Checked)
         {
            qFactor = "0";
         }
         else
         {
            qFactor = imageFormatDlg.ImageQFactorNumeric.Value.ToString();
         }
         return qFactor;
      }
      
      private void AddImageFormat()
      {
         try
         {
            ImageFormatDialog imageFormatDlg = new ImageFormatDialog ( ) ;
            SaveImageFormatElement source    = new SaveImageFormatElement ( ) ;


            imageFormatDlg.AllowedFormats = _storageView.AllowedFormats.ToArray();
            
            imageFormatDlg.DataSource = source ;
            
            if ( imageFormatDlg.ShowDialog ( ) == DialogResult.OK ) 
            {
               ListViewItem imageFormatItem = ToListViewItem ( source ) ;
               
               imageFormatItem.Tag = source ;

               _storageView.GenerateImagesListView.Items.Add(imageFormatItem);

               _storageView.AllowedFormats.Remove(source.Format);

               LocalAuditLogQueue.AddAuditMessage(AuditMessages.GenerateImageItemAdded.Key,
                  string.Format(AuditMessages.GenerateImageItemAdded.Message, source.Width, source.Height, source.QFactor, source.Format));
            }
         }
         catch ( Exception exception ) 
         {
            _storageView.ErrorMessage(exception.Message);
         }
      }
      
      public void EditImageFormat()
      {
         try
         {
            ImageFormatDialog imageFormatDlg = new ImageFormatDialog();


            if (_storageView.GenerateImagesListView.SelectedItems.Count == 0)
            {
               return;
            }

            SaveImageFormatElement imageFormatElement = (SaveImageFormatElement)_storageView.GenerateImagesListView.SelectedItems[0].Tag;

            _storageView.AllowedFormats.Add(imageFormatElement.Format);

            imageFormatDlg.AllowedFormats = _storageView.AllowedFormats.ToArray();
            imageFormatDlg.DataSource = imageFormatElement;

            if (imageFormatDlg.ShowDialog() == DialogResult.OK)
            {
               UpdateListViewItem(imageFormatElement, _storageView.GenerateImagesListView.SelectedItems[0]);
               LocalAuditLogQueue.AddAuditMessage(AuditMessages.GenerateImageItemChanged.Key,
                  string.Format(AuditMessages.GenerateImageItemChanged.Message, imageFormatElement.Width, imageFormatElement.Height, imageFormatElement.QFactor, imageFormatElement.Format));
            }

            _storageView.AllowedFormats.Remove(imageFormatElement.Format);
         }
         catch (Exception exception)
         {
            _storageView.ErrorMessage(exception.Message);
         }
      }
      
      public void DeleteImageFormat()
      {
         try
         {
            if (_storageView.GenerateImagesListView.SelectedItems.Count == 0)
            {
               return;
            }

            SaveImageFormatElement imageElement = (SaveImageFormatElement)_storageView.GenerateImagesListView.SelectedItems[0].Tag;

            _storageView.GenerateImagesListView.Items.Remove(_storageView.GenerateImagesListView.SelectedItems[0]);

            _storageView.AllowedFormats.Add(imageElement.Format);

            LocalAuditLogQueue.AddAuditMessage(AuditMessages.GenerateImageItemDeleted.Key,
               string.Format(AuditMessages.GenerateImageItemDeleted.Message, imageElement.Width, imageElement.Height, imageElement.QFactor, imageElement.Format));

         }
         catch (Exception exception)
         {
            _storageView.ErrorMessage(exception.Message);
         }
      }

      public void ResetView()
      {
         if (_storageView != null && _storageView.AddInsSettings != null)
         {
            // Files tab
            _storageView.StorageLocation                 = _storageView.AddInsSettings.StoreAddIn.StorageLocation;
#if (LEADTOOLS_V19_OR_LATER)
            _storageView.HangingProtocolLocation         = _storageView.AddInsSettings.StoreAddIn.HangingProtocolLocation;
#endif 
            _storageView.FileExtension                   = _storageView.AddInsSettings.StoreAddIn.StoreFileExtension;
            _storageView.CreateBackupBeforeOverwrite     = _storageView.AddInsSettings.StoreAddIn.CreateBackupBeforeOverwrite;
            _storageView.OverwriteBackupLocation         = _storageView.AddInsSettings.StoreAddIn.OverwriteBackupLocation;
            _storageView.DeleteDicomFiles                = _storageView.AddInsSettings.StoreAddIn.DeleteFiles;
            _storageView.BackupFilesOnDelete             = _storageView.AddInsSettings.StoreAddIn.BackupFilesOnDelete;
            _storageView.BackupLocation                  = _storageView.AddInsSettings.StoreAddIn.DeleteBackupLocation;
            _storageView.SaveCStoreFailures              = _storageView.AddInsSettings.StoreAddIn.SaveCStoreFailures;
            _storageView.SaveCStoreLocation              = _storageView.AddInsSettings.StoreAddIn.CStoreFailuresPath;

            // Directory Structure Tab
            _storageView.CreatePatientFolder             = _storageView.AddInsSettings.StoreAddIn.DirectoryStructure.CreatePatientFolder;
            _storageView.UsePatientId                    = !_storageView.AddInsSettings.StoreAddIn.DirectoryStructure.UsePatientName;
            _storageView.SplitPatientIdIntoFolders       = _storageView.AddInsSettings.StoreAddIn.DirectoryStructure.SplitPatientId;
            _storageView.CreateStudyFolder               = _storageView.AddInsSettings.StoreAddIn.DirectoryStructure.CreateStudyFolder;
            _storageView.CreateSeriesFolder              = _storageView.AddInsSettings.StoreAddIn.DirectoryStructure.CreateSeriesFolder;
         
            // Images tab
            _storageView.CreateThumbnailImage            = _storageView.AddInsSettings.StoreAddIn.CreateThumbnailImage;
            _storageView.ThumbnailWidth                  = _storageView.AddInsSettings.StoreAddIn.ThumbnailFormat.Width;
            _storageView.ThumbnailHeight                 = _storageView.AddInsSettings.StoreAddIn.ThumbnailFormat.Height;
            _storageView.ThumbnailQualityFactor          = _storageView.AddInsSettings.StoreAddIn.ThumbnailFormat.QFactor;
            _storageView.ThumbnailFormat                 = _storageView.AddInsSettings.StoreAddIn.ThumbnailFormat.Format;
            FillGenerateImagesFormatListView();

            // Options tab
            _storageView.PreventStoringDuplicates        = _storageView.AddInsSettings.StoreAddIn.PreventStoringDuplicateInstance;
            _storageView.UpdateExistingPatient           = _storageView.AddInsSettings.StoreAddIn.DatabaseOptions.UpdateExistentPatient;
            _storageView.UpdateExistingStudy             = _storageView.AddInsSettings.StoreAddIn.DatabaseOptions.UpdateExistentStudy;
            _storageView.UpdateExistingSeries            = _storageView.AddInsSettings.StoreAddIn.DatabaseOptions.UpdateExistentSeries;
            _storageView.UpdateExistingInstance          = _storageView.AddInsSettings.StoreAddIn.DatabaseOptions.UpdateExistentInstance;
            _storageView.AutoTruncateData                = _storageView.AddInsSettings.StoreAddIn.AutoTruncateData;
            _storageView.DeleteAnnotations               = _storageView.AddInsSettings.StoreAddIn.DeleteAnnotationsOnImageDelete;
            _storageView.UseMessageQueue                 = _storageView.AddInsSettings.StoreAddIn.UseMessageQueue;

#if (LEADTOOLS_V20_OR_LATER)
            // Metadata tab -- Json
            _storageView.JsonStore                       = _storageView.AddInsSettings.StoreAddIn.JsonStore;
            _storageView.JsonTrimWhiteSpace              = _storageView.AddInsSettings.StoreAddIn.JsonTrimWhiteSpace;
            _storageView.JsonWriteKeyword                = _storageView.AddInsSettings.StoreAddIn.JsonWriteKeyword;
            _storageView.JsonMinify                      = _storageView.AddInsSettings.StoreAddIn.JsonMinify;
            _storageView.JsonIgnoreBinaryData            = _storageView.AddInsSettings.StoreAddIn.JsonIgnoreBinaryData;

            // Metadata tab -- Json
            _storageView.XmlStore                        = _storageView.AddInsSettings.StoreAddIn.XmlStore;
            _storageView.XmlTrimWhiteSpace               = _storageView.AddInsSettings.StoreAddIn.XmlTrimWhiteSpace;
            _storageView.XmlFullEndStatement             = _storageView.AddInsSettings.StoreAddIn.XmlFullEndStatement;
            _storageView.XmlIgnoreBinaryData             = _storageView.AddInsSettings.StoreAddIn.XmlIgnoreBinaryData;
#endif // #if (LEADTOOLS_V20_OR_LATER)
         }
         
         if (_queryView != null && _queryView.AddInsSettings != null)
         {
            // Query Options
            _queryView.AllowZeroItems                    = _queryView.AddInsSettings.QueryAddIn.DataSetRequestValidation.AllowZeroItemsSequence;
            _queryView.AllowMultipleItems                = _queryView.AddInsSettings.QueryAddIn.DataSetRequestValidation.AllowMultipleItemsSequence;
            _queryView.AllowPrivateItems                 = _queryView.AddInsSettings.QueryAddIn.DataSetRequestValidation.AllowPrivateElements;
            _queryView.AllowExtraItems                   = _queryView.AddInsSettings.QueryAddIn.DataSetRequestValidation.AllowExtraElements;
            _queryView.PatientRelatedStudies             = _queryView.AddInsSettings.QueryAddIn.DataSetResponseOptions.IncludeNumberOfPatientStudies;
            _queryView.PatientRelatedSeries              = _queryView.AddInsSettings.QueryAddIn.DataSetResponseOptions.IncludeNumberOfPatientSeries;
            _queryView.PatientRelatedInstances           = _queryView.AddInsSettings.QueryAddIn.DataSetResponseOptions.IncludeNumberOfPatientInstances;
            _queryView.StudyRelatedSeries                = _queryView.AddInsSettings.QueryAddIn.DataSetResponseOptions.IncludeNumberOfStudySeries;
            _queryView.StudyRelatedInstances             = _queryView.AddInsSettings.QueryAddIn.DataSetResponseOptions.IncludeNumberOfStudyInstances;
            _queryView.SeriesRelatedInstances            = _queryView.AddInsSettings.QueryAddIn.DataSetResponseOptions.IncludeNumberOfSeriesInstances;
            _queryView.IodXmlPath                        = _queryView.AddInsSettings.QueryAddIn.QueryIODPath;
            
            _queryView.LimitCFindRsp                     = _queryView.AddInsSettings.QueryAddIn.LimitCFindRsp;
            _queryView.MaximumCountCFindRsp              = (_queryView.AddInsSettings.QueryAddIn.MaximumCFindRspCount == 0) ? QueryOptionsView.UpperLimitCountCFindRsp :_queryView.AddInsSettings.QueryAddIn.MaximumCFindRspCount;
            _queryView.ServiceStatus                     = _queryView.AddInsSettings.QueryAddIn.ServiceStatus;
         }
      }
      
      private string _sUserDefined = "User Defined";
      
      private void FillServiceStatusItems()
      {
         _queryView.ServiceStatusItems.Add( new ServiceStatusItem("Success", DicomCommandStatusType.Success));
         
         _queryView.ServiceStatusItems.Add( new ServiceStatusItem("Cancel", DicomCommandStatusType.Cancel));
         _queryView.ServiceStatusItems.Add( new ServiceStatusItem("Attribute List Error", DicomCommandStatusType.AttributeListError));
         _queryView.ServiceStatusItems.Add( new ServiceStatusItem("Attribute Out Of Range", DicomCommandStatusType.AttributeOutOfRange));
         _queryView.ServiceStatusItems.Add( new ServiceStatusItem("Class Not Supported", DicomCommandStatusType.ClassNotSupported));
         _queryView.ServiceStatusItems.Add( new ServiceStatusItem("Class Instance Conflict", DicomCommandStatusType.ClaseInstanceConflict));
         _queryView.ServiceStatusItems.Add( new ServiceStatusItem("Duplicate Instance", DicomCommandStatusType.DuplicateInstance));
         _queryView.ServiceStatusItems.Add( new ServiceStatusItem("Duplicate Invocation", DicomCommandStatusType.DuplicateInvocation));
         _queryView.ServiceStatusItems.Add( new ServiceStatusItem("Invalid ArgumentValue", DicomCommandStatusType.InvalidArgumentValue));
         _queryView.ServiceStatusItems.Add( new ServiceStatusItem("Invalid AttributeValue", DicomCommandStatusType.InvalidAttributeValue));
         _queryView.ServiceStatusItems.Add( new ServiceStatusItem("Invalid ObjectInstance", DicomCommandStatusType.InvalidObjectInstance));
         _queryView.ServiceStatusItems.Add( new ServiceStatusItem("Missing Attribute", DicomCommandStatusType.MissingAttribute));
         _queryView.ServiceStatusItems.Add( new ServiceStatusItem("Missing AttributeValue", DicomCommandStatusType.MissingAttributeValue));
         _queryView.ServiceStatusItems.Add( new ServiceStatusItem("Mistyped Argument", DicomCommandStatusType.MistypedArgument));
         _queryView.ServiceStatusItems.Add( new ServiceStatusItem("No Such Argument", DicomCommandStatusType.NoSuchArgument));
         _queryView.ServiceStatusItems.Add( new ServiceStatusItem("No Such Attribute", DicomCommandStatusType.NoSuchAttribute));
         _queryView.ServiceStatusItems.Add( new ServiceStatusItem("No Such EventType", DicomCommandStatusType.NoSuchEventType));
         _queryView.ServiceStatusItems.Add( new ServiceStatusItem("No Such Object Instance", DicomCommandStatusType.NoSuchObjectInstance));
         _queryView.ServiceStatusItems.Add( new ServiceStatusItem("No Such Class", DicomCommandStatusType.NoSuchClass));
         _queryView.ServiceStatusItems.Add( new ServiceStatusItem("Processing Failure", DicomCommandStatusType.ProcessingFailure));
         _queryView.ServiceStatusItems.Add( new ServiceStatusItem("Resource Limitation", DicomCommandStatusType.ResourceLimitation));
         _queryView.ServiceStatusItems.Add( new ServiceStatusItem("Unrecognized Operation", DicomCommandStatusType.UnrecognizedOperation));
         _queryView.ServiceStatusItems.Add( new ServiceStatusItem("Refused Out Of Resources", DicomCommandStatusType.RefusedOutOfResources));
         _queryView.ServiceStatusItems.Add( new ServiceStatusItem("Refused Unable To Calculate Matches", DicomCommandStatusType.RefusedUnableToCalculateMatches));
         _queryView.ServiceStatusItems.Add( new ServiceStatusItem("Refused Unable To Perform Suboperations", DicomCommandStatusType.RefusedUnableToPerformSuboperations));
         _queryView.ServiceStatusItems.Add( new ServiceStatusItem("Refused Move Destination Unknown", DicomCommandStatusType.RefusedMoveDestinationUnknown));
         _queryView.ServiceStatusItems.Add( new ServiceStatusItem("Failure", DicomCommandStatusType.Failure));
         //_queryView.ServiceStatusItems.Add( new ItemClass("Reserved2", DicomCommandStatusType.RESERVED2));
         //_queryView.ServiceStatusItems.Add( new ItemClass("Reserved3", DicomCommandStatusType.RESERVED3));
         //_queryView.ServiceStatusItems.Add( new ItemClass("Reserved4", DicomCommandStatusType.RESERVED4));
         _queryView.ServiceStatusItems.Add( new ServiceStatusItem("Warning", DicomCommandStatusType.Warning));
         _queryView.ServiceStatusItems.Add( new ServiceStatusItem("Pending", DicomCommandStatusType.Pending));
         _queryView.ServiceStatusItems.Add( new ServiceStatusItem("Pending Warning", DicomCommandStatusType.PendingWarning));
         
         _queryView.ServiceStatusItems.Add( new ServiceStatusItem(_sUserDefined, (DicomCommandStatusType)(-1)));
      }
      
      public void UpdateState()
      {
         if (  _storageView != null && _storageView.AddInsSettings != null)
         {
            // Files tab
            _storageView.AddInsSettings.StoreAddIn.StorageLocation                               = _storageView.StorageLocation                 ;
#if (LEADTOOLS_V19_OR_LATER)
            _storageView.AddInsSettings.StoreAddIn.HangingProtocolLocation                       = _storageView.HangingProtocolLocation         ;
#endif
            _storageView.AddInsSettings.StoreAddIn.StoreFileExtension                            = _storageView.FileExtension                   ;
            _storageView.AddInsSettings.StoreAddIn.CreateBackupBeforeOverwrite                   = _storageView.CreateBackupBeforeOverwrite     ;
            _storageView.AddInsSettings.StoreAddIn.OverwriteBackupLocation                       = _storageView.OverwriteBackupLocation         ;
            _storageView.AddInsSettings.StoreAddIn.DeleteFiles                                   = _storageView.DeleteDicomFiles                ;
            _storageView.AddInsSettings.StoreAddIn.BackupFilesOnDelete                           = _storageView.BackupFilesOnDelete             ;
            _storageView.AddInsSettings.StoreAddIn.DeleteBackupLocation                          = _storageView.BackupLocation                  ;
            _storageView.AddInsSettings.StoreAddIn.SaveCStoreFailures                            = _storageView.SaveCStoreFailures              ;
            _storageView.AddInsSettings.StoreAddIn.CStoreFailuresPath                            = _storageView.SaveCStoreLocation              ;
                                                                                              
             // Directory Structure Tab
            _storageView.AddInsSettings.StoreAddIn.DirectoryStructure.CreatePatientFolder        = _storageView.CreatePatientFolder             ;
            _storageView.AddInsSettings.StoreAddIn.DirectoryStructure.UsePatientName            = !_storageView.UsePatientId                    ;
            _storageView.AddInsSettings.StoreAddIn.DirectoryStructure.SplitPatientId             = _storageView.SplitPatientIdIntoFolders       ;
            _storageView.AddInsSettings.StoreAddIn.DirectoryStructure.CreateStudyFolder          = _storageView.CreateStudyFolder               ;
            _storageView.AddInsSettings.StoreAddIn.DirectoryStructure.CreateSeriesFolder         = _storageView.CreateSeriesFolder              ;
                                                                                               
            // Images tab
            _storageView.AddInsSettings.StoreAddIn.CreateThumbnailImage                          = _storageView.CreateThumbnailImage            ;
            _storageView.AddInsSettings.StoreAddIn.ThumbnailFormat.Width                         = _storageView.ThumbnailWidth                  ;
            _storageView.AddInsSettings.StoreAddIn.ThumbnailFormat.Height                        = _storageView.ThumbnailHeight                 ;
            _storageView.AddInsSettings.StoreAddIn.ThumbnailFormat.QFactor                       = _storageView.ThumbnailQualityFactor          ;
            _storageView.AddInsSettings.StoreAddIn.ThumbnailFormat.Format                        = _storageView.ThumbnailFormat                 ;
            FillImagesFormatFromListView();
                                                                                              
            // Options tab
            _storageView.AddInsSettings.StoreAddIn.PreventStoringDuplicateInstance               = _storageView.PreventStoringDuplicates        ;
            _storageView.AddInsSettings.StoreAddIn.DatabaseOptions.UpdateExistentPatient         = _storageView.UpdateExistingPatient           ;
            _storageView.AddInsSettings.StoreAddIn.DatabaseOptions.UpdateExistentStudy           = _storageView.UpdateExistingStudy             ;
            _storageView.AddInsSettings.StoreAddIn.DatabaseOptions.UpdateExistentSeries          = _storageView.UpdateExistingSeries            ;
            _storageView.AddInsSettings.StoreAddIn.DatabaseOptions.UpdateExistentInstance        = _storageView.UpdateExistingInstance          ;
            _storageView.AddInsSettings.StoreAddIn.AutoTruncateData                              = _storageView.AutoTruncateData                ;
            _storageView.AddInsSettings.StoreAddIn.UseMessageQueue                               = _storageView.UseMessageQueue                 ;
            _storageView.AddInsSettings.StoreAddIn.DeleteAnnotationsOnImageDelete                = _storageView.DeleteAnnotations               ;

#if (LEADTOOLS_V20_OR_LATER)
            // Metadata tab (JSON)
            _storageView.AddInsSettings.StoreAddIn.JsonStore                                     = _storageView.JsonStore                       ;
            _storageView.AddInsSettings.StoreAddIn.JsonTrimWhiteSpace                            = _storageView.JsonTrimWhiteSpace              ;
            _storageView.AddInsSettings.StoreAddIn.JsonWriteKeyword                               = _storageView.JsonWriteKeyword               ;
            _storageView.AddInsSettings.StoreAddIn.JsonMinify                                    = _storageView.JsonMinify                      ;
            _storageView.AddInsSettings.StoreAddIn.JsonIgnoreBinaryData                          = _storageView.JsonIgnoreBinaryData            ;

            // Metadata tab (XML)
            _storageView.AddInsSettings.StoreAddIn.XmlStore                                      = _storageView.XmlStore                        ;
            _storageView.AddInsSettings.StoreAddIn.XmlTrimWhiteSpace                             = _storageView.XmlTrimWhiteSpace               ;
            _storageView.AddInsSettings.StoreAddIn.XmlFullEndStatement                           = _storageView.XmlFullEndStatement             ;
            _storageView.AddInsSettings.StoreAddIn.XmlIgnoreBinaryData                           = _storageView.XmlIgnoreBinaryData             ;
#endif // #if (LEADTOOLS_V20_OR_LATER)
          }

         if (_queryView != null && _queryView.AddInsSettings != null)
         {
            // Query Options
            _queryView.AddInsSettings.QueryAddIn.DataSetRequestValidation.AllowZeroItemsSequence         =     _queryView.AllowZeroItems         ;
            _queryView.AddInsSettings.QueryAddIn.DataSetRequestValidation.AllowMultipleItemsSequence     =     _queryView.AllowMultipleItems     ;
            _queryView.AddInsSettings.QueryAddIn.DataSetRequestValidation.AllowPrivateElements           =     _queryView.AllowPrivateItems      ;
            _queryView.AddInsSettings.QueryAddIn.DataSetRequestValidation.AllowExtraElements             =     _queryView.AllowExtraItems        ;
            _queryView.AddInsSettings.QueryAddIn.DataSetResponseOptions.IncludeNumberOfPatientStudies    =     _queryView.PatientRelatedStudies  ;
            _queryView.AddInsSettings.QueryAddIn.DataSetResponseOptions.IncludeNumberOfPatientSeries     =     _queryView.PatientRelatedSeries   ;
            _queryView.AddInsSettings.QueryAddIn.DataSetResponseOptions.IncludeNumberOfPatientInstances  =     _queryView.PatientRelatedInstances;
            _queryView.AddInsSettings.QueryAddIn.DataSetResponseOptions.IncludeNumberOfStudySeries       =     _queryView.StudyRelatedSeries     ;
            _queryView.AddInsSettings.QueryAddIn.DataSetResponseOptions.IncludeNumberOfStudyInstances    =     _queryView.StudyRelatedInstances  ;
            _queryView.AddInsSettings.QueryAddIn.DataSetResponseOptions.IncludeNumberOfSeriesInstances   =     _queryView.SeriesRelatedInstances ;
            _queryView.AddInsSettings.QueryAddIn.QueryIODPath                                            =     _queryView.IodXmlPath             ;
            
            _queryView.AddInsSettings.QueryAddIn.LimitCFindRsp                                           =     _queryView.LimitCFindRsp          ;
            _queryView.AddInsSettings.QueryAddIn.MaximumCFindRspCount                                    =     _queryView.MaximumCountCFindRsp   ;
            _queryView.AddInsSettings.QueryAddIn.ServiceStatus                                           =     _queryView.ServiceStatus          ;
         }
      }

      public bool IsDirty
      {
         get
         {
            return _storageView.IsDirty || _queryView.IsDirty;
         }
      }

      public void SaveSettings()
      {
         if (_configurationManager.IsLoaded)
         {
            _configurationManager.SetStorageAddinsSettings(Settings);

            _configurationManager.Save();

            _storageView.IsDirty = false;
            _queryView.IsDirty = false;
         }
      }
      
      
      public void ReConfigureViews ( )
      {
         RunViews ( _storageView, _queryView, false) ;
      }
      
      public StorageAddInsConfiguration Settings
      {
         get
         {
            if ( null != _storageView )
            {
               return _storageView.AddInsSettings ;
            }
            else
            {
               return null ;
            }
         }
      }

      StorageOptionsView _storageView;

      public StorageOptionsView StorageView
      {
         get { return _storageView; }
         set { _storageView = value; }
      }
      QueryOptionsView _queryView;

      public QueryOptionsView QueryView
      {
         get { return _queryView; }
         set { _queryView = value; }
      }

#if (LEADTOOLS_V19_OR_LATER)
      StorageCommitView _storageCommitView;
      public StorageCommitView StorageCommitView
      {
         get { return _storageCommitView; }
         set { _storageCommitView = value; }
      }
#endif 

      StorageModuleConfigurationManager _configurationManager ;
   }
}

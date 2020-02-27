// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Leadtools.Medical.Storage.AddIns.Configuration;
using System.Xml.Schema;
using Leadtools.Dicom.Scp.Command;
using System.Xml;
using Leadtools.Demos;
using System.IO;
using Leadtools.Medical.Storage.DataAccessLayer;

namespace Leadtools.Medical.Storage.AddIns
{
   public partial class StorageOptionsView : UserControl
   {
      public StorageOptionsView()
      {
         InitializeComponent();

         // Files
          this.BrowseStorageLocationButton.Click          += new EventHandler      ( this.BrowseStorageLocationButton_Click ) ;
#if (LEADTOOLS_V19_OR_LATER)
         this.BrowseHangingProtocolLocationButton.Click  += new EventHandler      ( this.BrowseHangingProtocolLocationButton_Click);
#endif
         this.BrowseCStoreFailuresButton.Click           += new EventHandler      ( this.BrowseCStoreFailuresButton_Click ) ;
         this.BrowseBackupLocationButton.Click           += new EventHandler      ( this.BrowseBackupLocationButton_Click);
         this.BrowseDeleteFileBackupLocationButton.Click += new EventHandler      ( this.BrowseDeleteFileBackupLocationButton_Click);
         CreateBackupCheckBox.CheckedChanged             += new System.EventHandler(this.UpdateUI_Changed);
         DeleteFilesCheckBox.CheckedChanged              += new System.EventHandler(this.UpdateUI_Changed);
         BackupFilesOnDeleteCheckBox.CheckedChanged      += new System.EventHandler(this.UpdateUI_Changed);
         SaveCStoreFailuresCheckBox.CheckedChanged       += new System.EventHandler(this.UpdateUI_Changed);

         StorageLocationTextBox.Validated                += new EventHandler(FolderLocationTextBox_Validated);
         StorageLocationTextBox.Validating               += new CancelEventHandler(FolderLocationTextBox_Validating);
#if (LEADTOOLS_V19_OR_LATER)
         HangingProtocolLocationTextBox.Validated        += new EventHandler(FolderLocationTextBox_Validated);
         HangingProtocolLocationTextBox.Validating       += new CancelEventHandler(FolderLocationTextBox_Validating);
#endif 

         OverwriteBackupLocationTextBox.Validated        += new EventHandler(FolderLocationTextBox_Validated);
         OverwriteBackupLocationTextBox.Validating       += new CancelEventHandler(FolderLocationTextBox_Validating);

         DeleteBackupLocationTextBox.Validated           += new EventHandler(FolderLocationTextBox_Validated);
         DeleteBackupLocationTextBox.Validating          += new CancelEventHandler(FolderLocationTextBox_Validating);

         CStoreFailuresTextBox.Validated                 += new EventHandler(FolderLocationTextBox_Validated);
         CStoreFailuresTextBox.Validating                += new CancelEventHandler(FolderLocationTextBox_Validating);

         // Directory Structure
         CreatepatientFolderCheckBox.CheckedChanged      += new System.EventHandler(this.UpdateUI_Changed);
         CreateStudyFolderCheckBox.CheckedChanged        += new System.EventHandler(this.UpdateUI_Changed);
         CreateSeriesFolderCheckBox.CheckedChanged       += new System.EventHandler(this.UpdateUI_Changed);
         UsePatientIdRadioButton.CheckedChanged          += new System.EventHandler(this.UpdateUI_Changed);

         // Images
         ThumbFormatComboBox.Items.Add ( RasterImageFormat.Jpeg.ToString ( ) ) ;
         ThumbFormatComboBox.Items.Add ( RasterImageFormat.J2k.ToString ( ) ) ;
         ThumbFormatComboBox.Items.Add ( RasterImageFormat.Bmp.ToString ( ) ) ;
         
         AllowedFormats = new List<string> ( ) ;
         
         AllowedFormats.Add ( RasterImageFormat.Jpeg.ToString () ) ;
         AllowedFormats.Add ( RasterImageFormat.J2k.ToString ()) ;
         AllowedFormats.Add ( RasterImageFormat.Tif.ToString () ) ;
         AllowedFormats.Add ( RasterImageFormat.TifJpeg.ToString () ) ;
         // AllowedFormats.Add ( RasterImageFormat.TifJ2k.ToString () ) ;         
         
         this.generateImagesListView.MouseDoubleClick    += new MouseEventHandler ( this.GenerateImagesListView_MouseDoubleClick ) ;
         this.AddImageToolStripButton.Click              += new EventHandler      ( this.AddImageToolStripButton_Click ) ;
         this.EditToolStripButton.Click                  += new EventHandler      ( this.EditToolStripButton_Click ) ;
         this.DeleteToolStripButton.Click                += new EventHandler      ( this.DeleteToolStripButton_Click ) ;

         // Options

         // Metadata
         this.checkBoxJsonStore.CheckedChanged           += new EventHandler(this.UpdateUI_Changed);
         this.checkBoxXmlStore.CheckedChanged            += new EventHandler(this.UpdateUI_Changed);

         this.buttonJsonDeleteAll.Click += ButtonJsonDeleteAll_Click;
         this.buttonJsonGenerateMissing.Click += ButtonJsonGenerateMissing_Click;
         this.buttonJsonGenerateAll.Click += ButtonJsonGenerateAll_Click;
         this.buttonJsonStopGenerate.Click += ButtonJsonStopGenerate_Click;

         this.buttonXmlDeleteAll.Click += ButtonXmlDeleteXmlMetadata_Click;
         this.buttonXmlGenerateMissing.Click += ButtonXmlGenerateMissing_Click;
         this.buttonXmlGenerateAll.Click += ButtonXmlGenerateAll_Click;
         this.buttonXmlStopGenerate.Click += ButtonXmlStopGenerate_Click;
         
         
         Application.Idle += new EventHandler(Application_Idle);
         AddIsDirtyHandlers();

         EnableMetadataItems(true, new MetadataOptions());
      }

      // JSON

      private void ButtonJsonDeleteAll_Click(object sender, EventArgs e)
      {
         if (DeleteJsonMetadata != null)
         {
            DeleteJsonMetadata(sender, e);
         }
      }

      private void ButtonJsonGenerateAll_Click(object sender, EventArgs e)
      {
         if (GenerateAllJsonMetadata != null)
         {
            GenerateAllJsonMetadata(sender, e);
         }
      }

      private void ButtonJsonGenerateMissing_Click(object sender, EventArgs e)
      {
         if (GenerateMissingJsonMetadata != null)
         {
            GenerateMissingJsonMetadata(sender, e);
         }
      }

      private void ButtonJsonStopGenerate_Click(object sender, EventArgs e)
      {
         if (StopGenerateJsonMetadata != null)
         {
            StopGenerateJsonMetadata(sender, e);
         }
      }

      // XML

      private void ButtonXmlDeleteXmlMetadata_Click(object sender, EventArgs e)
      {
         if (DeleteXmlMetadata != null)
         {
            DeleteXmlMetadata(sender, e);
         }
      }

      private void ButtonXmlGenerateAll_Click(object sender, EventArgs e)
      {
         if (GenerateAllXmlMetadata != null)
         {
            GenerateAllXmlMetadata(sender, e);
         }
      }

      private void ButtonXmlGenerateMissing_Click(object sender, EventArgs e)
      {
         if (GenerateMissingXmlMetadata != null)
         {
            GenerateMissingXmlMetadata(sender, e);
         }
      }

      private void ButtonXmlStopGenerate_Click(object sender, EventArgs e)
      {
         if (StopGenerateXmlMetadata != null)
         {
            StopGenerateXmlMetadata(sender, e);
         }
      }


      // Files tab
      public string StorageLocation
      {
         get
         {
            return StorageLocationTextBox.Text;
         }
         set
         {
            StorageLocationTextBox.Text = value;
         }
      }

#if (LEADTOOLS_V19_OR_LATER)
      public string HangingProtocolLocation
      {
         get
         {
            return HangingProtocolLocationTextBox.Text;
         }
         set
         {
            HangingProtocolLocationTextBox.Text = value;
         }
      }
#endif // #if (LEADTOOLS_V19_OR_LATER)
      
      public string FileExtension
      {
         get
         {
            return FileExtTextBox.Text;
         }
         set
         {
            FileExtTextBox.Text = value;
         }
      }
      
      public bool CreateBackupBeforeOverwrite
      {
         get
         {
            return CreateBackupCheckBox.Checked;
         }
         set
         {
            CreateBackupCheckBox.Checked = value;
         }
      }
      
      public string OverwriteBackupLocation
      {
         get
         {
            return OverwriteBackupLocationTextBox.Text;
         }
         set
         {
            OverwriteBackupLocationTextBox.Text = value;
         }
      }
      
      public bool DeleteDicomFiles
      {
         get
         {
            return DeleteFilesCheckBox.Checked;
         }
         set
         {
            DeleteFilesCheckBox.Checked = value;
         }
      }
      
      public bool BackupFilesOnDelete
      {
         get
         {
            return BackupFilesOnDeleteCheckBox.Checked;
         }
         set
         {
            BackupFilesOnDeleteCheckBox.Checked = value;
         }
      }

      public string BackupLocation
      {
         get
         {
            return DeleteBackupLocationTextBox.Text;
         }
         set
         {
            DeleteBackupLocationTextBox.Text = value;
         }
      }
      
      public bool SaveCStoreFailures
      {
         get
         {
            return SaveCStoreFailuresCheckBox.Checked;
         }
         set
         {
            SaveCStoreFailuresCheckBox.Checked = value;
         }
      }
      
      public string SaveCStoreLocation
      {
         get
         {
            return CStoreFailuresTextBox.Text;
         }
         set
         {
            CStoreFailuresTextBox.Text = value;
         }
      }
      
      // Directory Structure Tab
      public bool CreatePatientFolder
      {
         get
         {
            return CreatepatientFolderCheckBox.Checked;
         }
         set
         {
            CreatepatientFolderCheckBox.Checked = value;
         }
      }
      
      public bool UsePatientId
      {
         get
         {
            return UsePatientIdRadioButton.Checked;
         }
         set
         {
            UsePatientIdRadioButton.Checked = value;
            UsePatientNameRadioButton.Checked = !value;
         }
      }
      
      public bool SplitPatientIdIntoFolders
      {
         get
         {
            return SplitPatientIdCheckBox.Checked;
         }
         set
         {
            SplitPatientIdCheckBox.Checked = value;
         }
      }
      
      public bool CreateStudyFolder
      {
         get
         {
            return CreateStudyFolderCheckBox.Checked;
         }
         set
         {
            CreateStudyFolderCheckBox.Checked = value;
         }
      }
      
      public bool CreateSeriesFolder
      {
         get
         {
            return CreateSeriesFolderCheckBox.Checked;
         }
         set
         {
            CreateSeriesFolderCheckBox.Checked = value;
         }
      }
      
      // Images Tab
      public bool CreateThumbnailImage
      {
         get
         {
            return CreateThumbCheckBox.Checked;
         }
         set
         {
            CreateThumbCheckBox.Checked = value;
         }
      }

      public int ThumbnailWidth
      {
         get
         {
            return (int)ThumbWidthNumeric.Value;
         }
         set
         {
            ThumbWidthNumeric.Value = (decimal)value;
         }
      }

      public int ThumbnailHeight
      {
         get
         {
            return (int)ThumbHeightNumeric.Value;
         }
         set
         {
            ThumbHeightNumeric.Value = (decimal)value;
         }
      }

      public int ThumbnailQualityFactor
      {
         get
         {
            return (int)ThumbQFactorNumeric.Value;
         }
         set
         {
            ThumbQFactorNumeric.Value = (decimal)value;
         }
      }
      
      public string ThumbnailFormat
      {
         get
         {
            return ThumbFormatComboBox.SelectedItem.ToString();;
         }
         set
         {
            ThumbFormatComboBox.SelectedItem = value;
         }
      }
      
      public ListView GenerateImagesListView
      {
         get
         {
            return this.generateImagesListView ;
         }
      }
      
      
      // Options tab
      
      public bool PreventStoringDuplicates
      {
         get
         {
            return PreventDuplicateSOPCheckBox.Checked;
         }
         set
         {
            PreventDuplicateSOPCheckBox.Checked = value;
         }
      }
      
      public bool UpdateExistingPatient
      {
         get
         {
            return UpdatePatientCheckBox.Checked;
         }
         set
         {
            UpdatePatientCheckBox.Checked = value;
         }
      }
      
      public bool UpdateExistingStudy
      {
         get
         {
            return UpdateStudyCheckBox.Checked;
         }
         set
         {
            UpdateStudyCheckBox.Checked = value;
         }
      }
      
      public bool UpdateExistingSeries
      {
         get
         {
            return UpdateSeriesCheckBox.Checked;
         }
         set
         {
            UpdateSeriesCheckBox.Checked = value;
         }
      }
      
      public bool UpdateExistingInstance
      {
         get
         {
            return UpdateInstanceCheckBox.Checked;
         }
         set
         {
            UpdateInstanceCheckBox.Checked = value;
         }
      }
      
      public bool AutoTruncateData
      {
         get
         {
            return AutoTruncateDataCheckBox.Checked;
         }
         set
         {
            AutoTruncateDataCheckBox.Checked = value;
         }
      }

      public bool UseMessageQueue
      {
         get
         {
            return UseMessageQueueCheckBox.Checked;
         }
         set
         {
            UseMessageQueueCheckBox.Checked = value;
         }
      }
      
      public bool DeleteAnnotations
      {
         get
         {
            return DeleteAnnotationCheckBox.Checked;
         }
         set
         {
            DeleteAnnotationCheckBox.Checked = value;
         }
      }

#if (LEADTOOLS_V20_OR_LATER)
      // Metadata tab -- Json
      public bool JsonStore
      {
         get
         {
            return checkBoxJsonStore.Checked;
         }
         set
         {
            checkBoxJsonStore.Checked = value;
         }
      }

      public bool JsonTrimWhiteSpace
      {
         get
         {
            return checkBoxJsonTrimWhiteSpace.Checked;
         }
         set
         {
            checkBoxJsonTrimWhiteSpace.Checked = value;
         }
      }

      public bool JsonWriteKeyword
      {
         get
         {
            return this.checkBoxJsonWriteKeyword.Checked;
         }
         set
         {
            checkBoxJsonWriteKeyword.Checked = value;
         }
      }

      public bool JsonMinify
      {
         get
         {
            return this.checkBoxJsonMinify.Checked;
         }
         set
         {
            checkBoxJsonMinify.Checked = value;
         }
      }

      public bool JsonIgnoreBinaryData
      {
         get
         {
            return this.checkBoxJsonIgnoreBinaryData.Checked;
         }
         set
         {
            checkBoxJsonIgnoreBinaryData.Checked = value;
         }
      }

      // Metadata tab -- Xml
      public bool XmlStore
      {
         get
         {
            return checkBoxXmlStore.Checked;
         }
         set
         {
            checkBoxXmlStore.Checked = value;
         }
      }

      public bool XmlTrimWhiteSpace
      {
         get
         {
            return checkBoxXmlTrimWhiteSpace.Checked;
         }
         set
         {
            checkBoxXmlTrimWhiteSpace.Checked = value;
         }
      }

      public bool XmlFullEndStatement
      {
         get
         {
            return checkBoxXmlFullEndStatement.Checked;
         }
         set
         {
            checkBoxXmlFullEndStatement.Checked = value;
         }
      }

      public bool XmlIgnoreBinaryData
      {
         get
         {
            return checkBoxXmlIgnoreBinaryData.Checked;
         }
         set
         {
            checkBoxXmlIgnoreBinaryData.Checked = value;
         }
      }
#endif // #if (LEADTOOLS_V20_OR_LATER)

      private bool _dirtyHandlersAdded = false;
      
      // Event Handlers
      public event EventHandler StorageLocationChanged = null;
#if LEADTOOLS_V19_OR_LATER
      public event EventHandler HangingProtocolLocationChanged = null;
#endif
      public event EventHandler FileExtensionChanged = null;
      public event EventHandler CreateBackupChanged = null;
      public event EventHandler OverwriteBackupLocationChanged = null;
      public event EventHandler DeleteFilesChanged = null;
      public event EventHandler BackupFilesOnDeleteChanged = null;
      public event EventHandler DeleteBackupLocationChanged = null;
      public event EventHandler SaveCStoreFailuresChanged = null;
      public event EventHandler CStoreFailuresLocationChanged = null;
      public event EventHandler CreatePatientFolderChanged = null;
      public event EventHandler UsePatientIdChanged = null;
      public event EventHandler SplitPatientIdChanged = null;
      public event EventHandler UsePatientNameChanged = null;
      public event EventHandler CreateStudyFolderChanged = null;
      public event EventHandler CreateSeriesFolderChanged = null;
      public event EventHandler CreateThumbChanged = null;
      public event EventHandler ThumbWidthChanged = null;
      public event EventHandler ThumbHeightChanged = null;
      public event EventHandler ThumbQFactorChanged = null;
      public event EventHandler ThumbFormatChanged = null;
      public event EventHandler AddImageChanged = null;
      public event EventHandler EditImageChanged = null;
      public event EventHandler DeleteImageChanged = null;
      public event EventHandler PreventStoringDuplicatesChanged = null;
      public event EventHandler UpdateExistingPatientChanged = null;
      public event EventHandler UpdateExistingStudyChanged = null;
      public event EventHandler UpdateExistingSeriesChanged = null;
      public event EventHandler UpdateExistingInstanceChanged = null;
      public event EventHandler AutoTruncateDataChanged = null;
      public event EventHandler DeleteAnnotationChanged = null;
      public event EventHandler UseMessageQueueDataChanged = null;

#if (LEADTOOLS_V20_OR_LATER)
      // Metadata Tab JSON
      public event EventHandler JsonStoreChanged =null;
      public event EventHandler JsonTrimWhiteSpaceChanged = null;
      public event EventHandler  JsonWriteKeywordChanged = null;
      public event EventHandler  JsonMinifyChanged = null;
      public event EventHandler JsonIgnoreBinaryDataChanged = null;

      // Metadata Tab XML
      public event EventHandler XmlStoreChanged = null;
      public event EventHandler XmlTrimWhiteSpaceChanged = null;
      public event EventHandler XmlFullEndStatementChanged = null;
      public event EventHandler XmlIgnoreBinaryDataChanged = null;
#endif // #if (LEADTOOLS_V20_OR_LATER)         
      private void AddIsDirtyHandlers()
      {
         if (_dirtyHandlersAdded == false)
         {
            _dirtyHandlersAdded = true;
            
            // Files Tab
            StorageLocationTextBox.TextChanged              += new EventHandler(OnSetIsDirty);
            HangingProtocolLocationTextBox.TextChanged      += new EventHandler(OnSetIsDirty);
            FileExtTextBox.TextChanged                      += new EventHandler(OnSetIsDirty);
            CreateBackupCheckBox.CheckedChanged             += new EventHandler(OnSetIsDirty);
            OverwriteBackupLocationTextBox.TextChanged      += new EventHandler(OnSetIsDirty);
            DeleteFilesCheckBox.CheckedChanged              += new EventHandler(OnSetIsDirty);
            BackupFilesOnDeleteCheckBox.CheckedChanged      += new EventHandler(OnSetIsDirty);
            DeleteBackupLocationTextBox.TextChanged         += new EventHandler(OnSetIsDirty);
            SaveCStoreFailuresCheckBox.CheckedChanged       += new EventHandler(OnSetIsDirty);
            CStoreFailuresTextBox.TextChanged               += new EventHandler(OnSetIsDirty);
            
            // Directory Structure Tab
            CreatepatientFolderCheckBox.CheckedChanged      += new EventHandler(OnSetIsDirty);
            UsePatientIdRadioButton.CheckedChanged          += new EventHandler(OnSetIsDirty);
            SplitPatientIdCheckBox.CheckedChanged           += new EventHandler(OnSetIsDirty);
            UsePatientNameRadioButton.CheckedChanged        += new EventHandler(OnSetIsDirty);
            CreateStudyFolderCheckBox.CheckedChanged        += new EventHandler(OnSetIsDirty);
            CreateSeriesFolderCheckBox.CheckedChanged       += new EventHandler(OnSetIsDirty);

            // Images Tab
            CreateThumbCheckBox.CheckedChanged              += new EventHandler(OnSetIsDirty);
            ThumbWidthNumeric.ValueChanged                  += new EventHandler(OnSetIsDirty);
            ThumbHeightNumeric.ValueChanged                 += new EventHandler(OnSetIsDirty);
            ThumbQFactorNumeric.ValueChanged                += new EventHandler(OnSetIsDirty);
            ThumbFormatComboBox.ValueMemberChanged          += new EventHandler(OnSetIsDirty);

            ThumbFormatComboBox.SelectionChangeCommitted    += new EventHandler(OnSetIsDirty);
            AddImageToolStripButton.Click                   += new EventHandler(OnSetIsDirty);
            EditToolStripButton.Click                       += new EventHandler(OnSetIsDirty);
            DeleteToolStripButton.Click                     += new EventHandler(OnSetIsDirty);

            // Options tab
            PreventDuplicateSOPCheckBox.CheckedChanged      += new EventHandler(OnSetIsDirty);
            UpdatePatientCheckBox.CheckedChanged            += new EventHandler(OnSetIsDirty);
            UpdateStudyCheckBox.CheckedChanged              += new EventHandler(OnSetIsDirty);
            UpdateSeriesCheckBox.CheckedChanged             += new EventHandler(OnSetIsDirty);
            UpdateInstanceCheckBox.CheckedChanged           += new EventHandler(OnSetIsDirty);
            AutoTruncateDataCheckBox.CheckedChanged         += new EventHandler(OnSetIsDirty);
            DeleteAnnotationCheckBox.CheckedChanged         += new EventHandler(OnSetIsDirty);
            UseMessageQueueCheckBox.CheckedChanged          += new EventHandler(OnSetIsDirty);

#if (LEADTOOLS_V20_OR_LATER)
            // Metadata tab (JSON)
            checkBoxJsonStore.CheckedChanged                += new EventHandler(OnSetIsDirty);
            checkBoxJsonTrimWhiteSpace.CheckedChanged       += new EventHandler(OnSetIsDirty);
            checkBoxJsonWriteKeyword.CheckedChanged         += new EventHandler(OnSetIsDirty);
            checkBoxJsonMinify.CheckedChanged               += new EventHandler(OnSetIsDirty);
            checkBoxJsonIgnoreBinaryData.CheckedChanged     += new EventHandler(OnSetIsDirty);

            // Metadata tab (XML)
            checkBoxXmlStore.CheckedChanged                 += new EventHandler(OnSetIsDirty);
            checkBoxXmlTrimWhiteSpace.CheckedChanged        += new EventHandler(OnSetIsDirty);
            checkBoxXmlFullEndStatement.CheckedChanged      += new EventHandler(OnSetIsDirty);
            checkBoxXmlIgnoreBinaryData.CheckedChanged      += new EventHandler(OnSetIsDirty);
#endif // #if (LEADTOOLS_V20_OR_LATER)
         }
      }

      
      bool IsDirectoryValid(string directory)
      {
         bool bOk = false;
         try
         {
            new System.IO.FileInfo(directory);
            bOk = true;
         }
         catch (ArgumentException)
         {
         }
         catch (System.IO.PathTooLongException)
         {
         }
         catch (NotSupportedException)
         {
         }
         return bOk;
      }

      void FolderLocationTextBox_Validating(object sender, CancelEventArgs e)
      {
         TextBox tb = sender as TextBox;
         if (tb != null)
         {
            if (!IsDirectoryValid(tb.Text))
            {
               e.Cancel = true;
               tb.Select(0, tb.Text.Length);

               errorProvider.SetError(tb, "Invalid Folder Location");
            }
         }
      }

      void FolderLocationTextBox_Validated(object sender, EventArgs e)
      {
         TextBox tb = sender as TextBox;
         if (tb != null)
         {
            errorProvider.SetError(tb, string.Empty);
         }
      }

      StorageAddInsConfiguration _settings ;
      
      public StorageAddInsConfiguration AddInsSettings
      {
         get
         {
            return _settings ;
         }
         
         set
         {
            if ( value != _settings ) 
            {
               _settings  = value ;
               
               if ( null != _settings ) 
               {
                  if ( _settings.StoreAddIn.ThumbnailFormat.QFactor < 2 )
                  {
                     _settings.StoreAddIn.ThumbnailFormat.QFactor = 2 ;
                  }
                  
                  if ( _settings.StoreAddIn.ThumbnailFormat.QFactor > 255 )
                  {
                     _settings.StoreAddIn.ThumbnailFormat.QFactor = 255 ;
                  }

                  if (string.IsNullOrEmpty(AddInsSettings.StoreAddIn.ThumbnailFormat.Format))
                  {
                     ThumbFormatComboBox.SelectedIndex = 0;
                  }

                  UsePatientNameRadioButton.CheckedChanged += new EventHandler(UsePatientNameRadioButton_CheckedChanged);

               }
            }
         }
      }
      
      public bool ShowDeleteAnnotationOption
      {
         get
         {
            return DeleteAnnotationCheckBox.Visible ;
         }
         
         set
         {
            DeleteAnnotationCheckBox.Visible = value ;
         }
      }

      void Application_Idle(object sender, EventArgs e)
      {
         AddImageToolStripButton.Enabled = AllowedFormats.Count > 0 ;
         EditToolStripButton.Enabled = DeleteToolStripButton.Enabled   = generateImagesListView.SelectedItems.Count > 0 ;
      }
      
      public List <string> AllowedFormats
      {
         get ;
         set ;
      }
     
      
      void UsePatientNameRadioButton_CheckedChanged(object sender, EventArgs e)
      {
         AddInsSettings.StoreAddIn.DirectoryStructure.UsePatientName = UsePatientNameRadioButton.Checked ;
      }
      
      private void BrowseStorageLocationButton_Click(object sender, EventArgs e)
      {
         StorageLocationBrowserDialog.SelectedPath = StorageLocationTextBox.Text ;
         
         if ( StorageLocationBrowserDialog.ShowDialog ( ) == DialogResult.OK )
         {
            StorageLocationTextBox.Text = StorageLocationBrowserDialog.SelectedPath ;
            
            AddInsSettings.StoreAddIn.StorageLocation = StorageLocationBrowserDialog.SelectedPath ;
         }
      }
#if (LEADTOOLS_V19_OR_LATER)
      void BrowseHangingProtocolLocationButton_Click(object sender, EventArgs e)
      {
         StorageLocationBrowserDialog.SelectedPath = HangingProtocolLocationTextBox.Text ;
         
         if ( StorageLocationBrowserDialog.ShowDialog ( ) == DialogResult.OK )
         {
            HangingProtocolLocationTextBox.Text = StorageLocationBrowserDialog.SelectedPath ;
            
            AddInsSettings.StoreAddIn.HangingProtocolLocation = StorageLocationBrowserDialog.SelectedPath ;
         }
      }
#endif // #if (LEADTOOLS_V19_OR_LATER)
      
      void BrowseCStoreFailuresButton_Click(object sender, EventArgs e)
      {
         StorageLocationBrowserDialog.SelectedPath = CStoreFailuresTextBox.Text ;
         
         if ( StorageLocationBrowserDialog.ShowDialog ( ) == DialogResult.OK ) 
         {
            CStoreFailuresTextBox.Text = StorageLocationBrowserDialog.SelectedPath ;
            
            AddInsSettings.StoreAddIn.CStoreFailuresPath = StorageLocationBrowserDialog.SelectedPath ;
         }
      }

      void BrowseDeleteFileBackupLocationButton_Click(object sender, EventArgs e)
      {
         StorageLocationBrowserDialog.SelectedPath = DeleteBackupLocationTextBox.Text;

         if (StorageLocationBrowserDialog.ShowDialog() == DialogResult.OK)
         {
            DeleteBackupLocationTextBox.Text = StorageLocationBrowserDialog.SelectedPath;

            AddInsSettings.StoreAddIn.DeleteBackupLocation = StorageLocationBrowserDialog.SelectedPath;
         }
      }

      void BrowseBackupLocationButton_Click(object sender, EventArgs e)
      {
         StorageLocationBrowserDialog.SelectedPath = OverwriteBackupLocationTextBox.Text;

         if (StorageLocationBrowserDialog.ShowDialog() == DialogResult.OK)
         {
            OverwriteBackupLocationTextBox.Text = StorageLocationBrowserDialog.SelectedPath;

            AddInsSettings.StoreAddIn.OverwriteBackupLocation = StorageLocationBrowserDialog.SelectedPath;
         }
      }

      private void AddImageToolStripButton_Click(object sender, EventArgs e)
      {
         OnAddImageFormat(sender, e);
      }



      private void EditToolStripButton_Click(object sender, EventArgs e)
      {
         // fire event to 
         OnEditImageFormat(sender, e);
      }

      private void DeleteToolStripButton_Click(object sender, EventArgs e)
      {
         // fire event to 
         OnDeleteImageFormat( sender, e);
      }

      private void GenerateImagesListView_MouseDoubleClick(object sender, MouseEventArgs e)
      {
         EditToolStripButton_Click ( sender, e ) ;
      }

#if (LEADTOOLS_V20_OR_LATER)
     private void EnableJsonOptions(bool enable)
      {
         checkBoxJsonTrimWhiteSpace.Enabled = enable;
         checkBoxJsonWriteKeyword.Enabled = enable;
         checkBoxJsonMinify.Enabled =enable;
         checkBoxJsonIgnoreBinaryData.Enabled = enable;
         buttonJsonDeleteAll.Enabled = enable;
         buttonJsonGenerateAll.Enabled = enable;
         buttonJsonGenerateMissing.Enabled = enable;
      }

      private void EnableXmlOptions(bool enable)
      {
         checkBoxXmlTrimWhiteSpace.Enabled = enable;
         checkBoxXmlFullEndStatement.Enabled = enable;
         checkBoxXmlIgnoreBinaryData.Enabled = enable;
         buttonXmlDeleteAll.Enabled = enable;
         buttonXmlGenerateAll.Enabled = enable;
         buttonXmlGenerateMissing.Enabled = enable;
      }
#endif // #if (LEADTOOLS_V20_OR_LATER)

      private void UpdateUI()
      {
         UsePatientIdRadioButton.Enabled = CreatepatientFolderCheckBox.Checked;
         UsePatientNameRadioButton.Enabled = CreatepatientFolderCheckBox.Checked;
         SplitPatientIdCheckBox.Enabled = UsePatientIdRadioButton.Enabled && 
                                          UsePatientIdRadioButton.Checked && 
                                          CreatepatientFolderCheckBox.Checked;


         // Overwrite backup location
         BackupLocationLabel.Enabled = CreateBackupCheckBox.Checked;
         OverwriteBackupLocationTextBox.Enabled = CreateBackupCheckBox.Checked;
         BrowseBackupLocationButton.Enabled = CreateBackupCheckBox.Checked;
         
         // Delete backup location
         BackupFilesOnDeleteCheckBox.Enabled = DeleteFilesCheckBox.Checked;
         DeleteBackupLocationTextBox.Enabled = DeleteFilesCheckBox.Checked && BackupFilesOnDeleteCheckBox.Checked;
         BrowseDeleteFileBackupLocationButton.Enabled = DeleteFilesCheckBox.Checked && BackupFilesOnDeleteCheckBox.Checked;
         DeleteBackupLocationLabel.Enabled = DeleteFilesCheckBox.Checked && BackupFilesOnDeleteCheckBox.Checked;

         // Save CStore Failure location
         StoreFailureLabel.Enabled = SaveCStoreFailuresCheckBox.Checked;
         CStoreFailuresTextBox.Enabled = SaveCStoreFailuresCheckBox.Checked;
         BrowseCStoreFailuresButton.Enabled = SaveCStoreFailuresCheckBox.Checked;

#if (LEADTOOLS_V20_OR_LATER)
         EnableJsonOptions(this.checkBoxJsonStore.Checked);
         EnableXmlOptions(this.checkBoxXmlStore.Checked);
#endif
      }

      private void UpdateUI_Changed(object sender, EventArgs e)
      {
         try
         {
            UpdateUI();
         }
         catch(Exception)
         {
         }
      }

      private void StorageOptionsView_VisibleChanged(object sender, EventArgs e)
      {
         UpdateUI();
      }

      private void OnSetIsDirty(object sender, EventArgs e)
      {
         try
         {
            IsDirty = true;
            OnSettingsChanged(sender, e);
            if (sender == StorageLocationTextBox)
            {
               if (StorageLocationChanged != null)
                  StorageLocationChanged(sender, e);
            }
#if (LEADTOOLS_V19_OR_LATER)
            else if (sender == HangingProtocolLocationTextBox)
            {
               if (HangingProtocolLocationChanged != null)
                  HangingProtocolLocationChanged(sender, e);
            }
#endif
            else if (sender == FileExtTextBox)
            {
               if (FileExtensionChanged != null)
                  FileExtensionChanged(sender, e);
            }
            else if (sender == CreateBackupCheckBox)
            {
               if (CreateBackupChanged != null)
                  CreateBackupChanged(sender, e);
            }
            else if (sender == OverwriteBackupLocationTextBox)
            {
               if (OverwriteBackupLocationChanged != null)
                  OverwriteBackupLocationChanged(sender, e);
            }
            else if (sender == DeleteFilesCheckBox)
            {
               if (DeleteFilesChanged != null)
                  DeleteFilesChanged(sender, e);
            }
            else if (sender == BackupFilesOnDeleteCheckBox)
            {
               if (BackupFilesOnDeleteChanged != null)
                  BackupFilesOnDeleteChanged(sender, e);
            }
            else if (sender == DeleteBackupLocationTextBox)
            {
               if (DeleteBackupLocationChanged != null)
                  DeleteBackupLocationChanged(sender, e);
            }
            else if (sender == SaveCStoreFailuresCheckBox)
            {
               if (SaveCStoreFailuresChanged != null)
                  SaveCStoreFailuresChanged(sender, e);
            }
            else if (sender == CStoreFailuresTextBox)
            {
               if (CStoreFailuresLocationChanged != null)
                  CStoreFailuresLocationChanged(sender, e);
            }

            // Directory Structure Tab
            else if (sender == CreatepatientFolderCheckBox)
            {
               if (CreatePatientFolderChanged != null)
                  CreatePatientFolderChanged(sender, e);
            }
            else if (sender == UsePatientIdRadioButton)
            {
               if (UsePatientIdChanged != null)
                  UsePatientIdChanged(sender, e);
            }
            else if (sender == SplitPatientIdCheckBox)
            {
               if (SplitPatientIdChanged != null)
                  SplitPatientIdChanged(sender, e);
            }
            else if (sender == UsePatientNameRadioButton)
            {
               if (UsePatientNameChanged != null)
                  UsePatientNameChanged(sender, e);
            }
            else if (sender == CreateStudyFolderCheckBox)
            {
               if (CreateStudyFolderChanged != null)
                  CreateStudyFolderChanged(sender, e);
            }
            else if (sender == CreateSeriesFolderCheckBox)
            {
               if (CreateSeriesFolderChanged != null)
                  CreateSeriesFolderChanged(sender, e);
            }

            // Images Tab
            else if (sender == CreateThumbCheckBox)
            {
               if (CreateThumbChanged != null)
                  CreateThumbChanged(sender, e);
            }
            else if (sender == ThumbWidthNumeric)
            {
               if (ThumbWidthChanged != null)
                  ThumbWidthChanged(sender, e);
            }
            else if (sender == ThumbHeightNumeric)
            {
               if (ThumbHeightChanged != null)
                  ThumbHeightChanged(sender, e);
            }
            else if (sender == ThumbQFactorNumeric)
            {
               if (ThumbQFactorChanged != null)
                  ThumbQFactorChanged(sender, e);
            }
            else if (sender == ThumbFormatComboBox)
            {
               if (ThumbFormatChanged != null)
                  ThumbFormatChanged(sender, e);
            }

            else if (sender == AddImageToolStripButton)
            {
               if (AddImageChanged != null)
                  AddImageChanged(sender, e);
            }
            else if (sender == EditToolStripButton)
            {
               if (EditImageChanged != null)
                  EditImageChanged(sender, e);
            }
            else if (sender == DeleteToolStripButton)
            {
               if (DeleteImageChanged != null)
                  DeleteImageChanged(sender, e);
            }

            // Options tab
            else if (sender == PreventDuplicateSOPCheckBox)
            {
               if (PreventStoringDuplicatesChanged != null)
                  PreventStoringDuplicatesChanged(sender, e);
            }
            else if (sender == UpdatePatientCheckBox)
            {
               if (UpdateExistingPatientChanged != null)
                  UpdateExistingPatientChanged(sender, e);
            }
            else if (sender == UpdateStudyCheckBox)
            {
               if (UpdateExistingStudyChanged != null)
                  UpdateExistingStudyChanged(sender, e);
            }
            else if (sender == UpdateSeriesCheckBox)
            {
               if (UpdateExistingSeriesChanged != null)
                  UpdateExistingSeriesChanged(sender, e);
            }
            else if (sender == UpdateInstanceCheckBox)
            {
               if (UpdateExistingInstanceChanged != null)
                  UpdateExistingInstanceChanged(sender, e);
            }
            else if (sender == AutoTruncateDataCheckBox)
            {
               if (AutoTruncateDataChanged != null)
                  AutoTruncateDataChanged(sender, e);
            }

            else if (sender == UseMessageQueueCheckBox)
            {
               if (UseMessageQueueDataChanged != null)
                  UseMessageQueueDataChanged(sender, e);
            }

            else if (sender == DeleteAnnotationCheckBox)
            {
               if (DeleteAnnotationChanged != null)
                  DeleteAnnotationChanged(sender, e);
            }

#if (LEADTOOLS_V20_OR_LATER)
            // Metadata Tab JSON
            else if (sender == checkBoxJsonStore)
            {
               if (JsonStoreChanged != null)
                  JsonStoreChanged(sender, e);
            }

            else if (sender == checkBoxJsonTrimWhiteSpace)
            {
               if (JsonTrimWhiteSpaceChanged != null)
                  JsonTrimWhiteSpaceChanged(sender, e);
            }

            else if (sender == checkBoxJsonTrimWhiteSpace)
            {
               if (JsonTrimWhiteSpaceChanged != null)
                  JsonTrimWhiteSpaceChanged(sender, e);
            }

            else if (sender == checkBoxJsonWriteKeyword)
            {
               if (JsonWriteKeywordChanged != null)
                  JsonWriteKeywordChanged(sender, e);
            }

            else if (sender == checkBoxJsonMinify)
            {
               if (JsonMinifyChanged != null)
                  JsonMinifyChanged(sender, e);
            }

            else if (sender == checkBoxJsonIgnoreBinaryData)
            {
               if (JsonIgnoreBinaryDataChanged != null)
                  JsonIgnoreBinaryDataChanged(sender, e);
            }

            // Metadata Tab XML
            else if (sender == checkBoxXmlStore)
            {
               if (XmlStoreChanged != null)
                  XmlStoreChanged(sender, e);
            }

            else if (sender == checkBoxXmlTrimWhiteSpace)
            {
               if (XmlTrimWhiteSpaceChanged != null)
                  XmlTrimWhiteSpaceChanged(sender, e);
            }

            else if (sender == checkBoxXmlFullEndStatement)
            {
               if (XmlFullEndStatementChanged != null)
                  XmlFullEndStatementChanged(sender, e);
            }

            else if (sender == checkBoxXmlIgnoreBinaryData)
            {
               if (XmlIgnoreBinaryDataChanged != null)
                  XmlIgnoreBinaryDataChanged(sender, e);
            }
#endif // #if (LEADTOOLS_V20_OR_LATER)
         }
         catch (Exception)
         {
            System.Diagnostics.Debug.Assert(false);
         }
      }

      private bool _isDirty = false;

      public bool IsDirty
      {
         get
         {
            return _isDirty;
         }
         /*private*/  internal set
         {
            _isDirty = value;
         }
      }
      
      public void ErrorMessage(string s)
      {
         MessageBox.Show(this, s, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }

      public event EventHandler SettingsChanged;
      public event EventHandler AddImageFormat;
      public event EventHandler EditImageFormat;
      public event EventHandler DeleteImageFormat;

#if (LEADTOOLS_V20_OR_LATER)
      public event EventHandler GenerateAllXmlMetadata;
      public event EventHandler GenerateMissingXmlMetadata;
      public event EventHandler DeleteXmlMetadata;
      public event EventHandler StopGenerateXmlMetadata;

      public event EventHandler GenerateAllJsonMetadata;
      public event EventHandler GenerateMissingJsonMetadata;
      public event EventHandler DeleteJsonMetadata;
      public event EventHandler StopGenerateJsonMetadata;

      public void ShowMetadataStatus(string status)
      {
         if (this.InvokeRequired)
         {
            this.BeginInvoke((MethodInvoker)delegate
              {
                 ShowMetadataStatus(status);
              });
            return;
         }

         labelStatus.Enabled = (!string.IsNullOrEmpty(status));
         labelStatus.Visible = labelStatus.Enabled;
         labelStatus.Text = status; 
      }

      public void ClearMetadataStatus()
      {
         ShowMetadataStatus(string.Empty);
      }

      public void EnableMetadataItems(bool enable, MetadataOptions options)
      {
         if (this.InvokeRequired)
         {
            this.BeginInvoke((MethodInvoker)delegate
              {
                 EnableMetadataItems(enable, options);
              });
            return;
         }

         // Json
         checkBoxJsonStore.Enabled = enable;
         checkBoxJsonTrimWhiteSpace.Enabled = enable;
         checkBoxJsonWriteKeyword.Enabled = enable;
         checkBoxJsonMinify.Enabled = enable;
         checkBoxJsonIgnoreBinaryData.Enabled = enable;

         buttonJsonDeleteAll.Enabled = enable;
         buttonJsonGenerateAll.Enabled = enable;
         buttonJsonGenerateMissing.Enabled = enable;
         buttonJsonStopGenerate.Visible = !enable && options.StoreJson;

         // xml
         checkBoxXmlStore.Enabled = enable;
         checkBoxXmlTrimWhiteSpace.Enabled = enable;
         checkBoxXmlFullEndStatement.Enabled = enable;
         checkBoxXmlIgnoreBinaryData.Enabled = enable;

         buttonXmlDeleteAll.Enabled = enable;
         buttonXmlGenerateAll.Enabled = enable;
         buttonXmlGenerateMissing.Enabled = enable;
         buttonXmlStopGenerate.Visible = !enable && options.StoreXml;

         ClearMetadataStatus();
      }
#endif // #if (LEADTOOLS_V20_OR_LATER)

      private void OnSettingsChanged(object sender, EventArgs e)
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

      private void OnAddImageFormat(object sender, EventArgs e)
      {
         if (AddImageFormat != null)
         {
            AddImageFormat(sender, e);
         }
      }

      private void OnEditImageFormat(object sender, EventArgs e)
      {
         if (EditImageFormat != null)
         {
            EditImageFormat(sender, e);
         }
      }

      private void OnDeleteImageFormat(object sender, EventArgs e)
      {
         if (DeleteImageFormat != null)
         {
            DeleteImageFormat(sender, e);
         }
      }

   }
}

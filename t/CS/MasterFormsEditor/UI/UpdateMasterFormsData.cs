// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using Leadtools;
using Leadtools.Barcode;
using Leadtools.Codecs;
using Leadtools.Demos;
using Leadtools.Forms.Auto;
using Leadtools.Ocr;
using Leadtools.Forms.Processing;
using Leadtools.Forms.Recognition;
#if FOR_DOTNET4
using Leadtools.Forms.Recognition.Search;
#endif

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace CSMasterFormsEditor.UI
{
   public partial class UpdateMasterFormsData : Form
   {
      public UpdateMasterFormsData()
      {
         InitializeComponent();
      }

      private bool _isRunning;
      private RasterCodecs _codecs;
      public IOcrEngine ocrEngine;
      public BarcodeEngine barcodeEngine;
      public FormRecognitionEngine recognitionEngine;
      Thread UpdateMasterFormsThread;

      private void UpdateMasterFormsData_Load(object sender, EventArgs e)
      {
         Messager.Caption = "Update Master Forms Data Utility";
         Text = Messager.Caption;
         _isRunning = false;
         _codecs = new RasterCodecs();

         if (!String.IsNullOrEmpty(Properties.Settings.Default.SourceFolder))
            _txtSrcFolder.Text = Properties.Settings.Default.SourceFolder;

         UpdateControls();

#if !FOR_DOTNET4
         _cbUseFullTextSearch.Visible = false;
#endif
      }

      private void UpdateControls()
      {
         if (_isRunning)
            _btnCancel.Enabled = true;
         else
            _btnCancel.Enabled = false;

         if (String.IsNullOrEmpty(_txtSrcFolder.Text))
            _btnConvert.Enabled = false;
         else
            _btnConvert.Enabled = true;
      }

      private void _btnBrowseSrcFolder_Click(object sender, EventArgs e)
      {
         using (FolderBrowserDialogEx dlg = new FolderBrowserDialogEx())
         {
            dlg.Description = "Select Source Folder";
            dlg.ShowNewFolderButton = false;
            dlg.ShowEditBox = true;
            dlg.ShowFullPathInEditBox = true;
            if (Directory.Exists(_txtSrcFolder.Text))
               dlg.SelectedPath = _txtSrcFolder.Text;
            if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
               _txtSrcFolder.Text = dlg.SelectedPath;
            }
         }
         UpdateControls();
      }

      private void _txtSrcFolder_TextChanged(object sender, EventArgs e)
      {
         UpdateControls();
      }

      private void _btnConvert_Click(object sender, EventArgs e)
      {
         _isRunning = true;
         UpdateControls();

         UpdateMasterFormsThread = new Thread(new ThreadStart(UpdateData));
         UpdateMasterFormsThread.Start();
      }

      private void UpdateData()
      {
         var recognitionEngineVersion = FormRecognitionEngine.Version;
#if FOR_DOTNET4
         var originalFullTextSearchManager = recognitionEngine.FullTextSearchManager;
#endif

         try
         {
            if (!Directory.Exists(_txtSrcFolder.Text))
            {
               Invoke((MethodInvoker)delegate { Messager.Show(this, "Please select valid folder", MessageBoxIcon.Error, MessageBoxButtons.OK); });
               return;
            }

            // Set the data version to latest, we want to update the data to use the latest
            FormRecognitionEngine.Version = FormRecognitionEngine.LatestVersion;

            // Set the full text search engine
            DiskMasterFormsRepository workingRepository = new DiskMasterFormsRepository(_codecs, _txtSrcFolder.Text);

#if FOR_DOTNET4
            if (_cbUseFullTextSearch.Checked)
            {
               DiskFullTextSearchManager fullTextSearchManager = new DiskFullTextSearchManager();
               fullTextSearchManager.IndexDirectory = Path.Combine(workingRepository.Path, "index");
               recognitionEngine.FullTextSearchManager = fullTextSearchManager;
            }
#endif
            IMasterFormsCategory parentCategory = workingRepository.RootCategory;
            Invoke((MethodInvoker)delegate { _prgbar.Maximum = parentCategory.MasterForms.Count; });

            for (int i = 0; i < _prgbar.Maximum; i++)
            {
               if (!_isRunning)
                  return;

               Invoke((MethodInvoker)delegate { _prgbar.Value++; });

               //Get the Original Attributes
               DiskMasterForm originalMasterForm = parentCategory.MasterForms[i] as DiskMasterForm;
               FormRecognitionAttributes originalAttributes = originalMasterForm.ReadAttributes();
               recognitionEngine.OpenMasterForm(originalAttributes);
               recognitionEngine.CloseMasterForm(originalAttributes);

               FormRecognitionOptions options = new FormRecognitionOptions();
               FormRecognitionAttributes attributes = recognitionEngine.CreateMasterForm(parentCategory.MasterForms[i].Name, new Guid(), options);
               recognitionEngine.CloseMasterForm(attributes);

               IMasterForm newForm = parentCategory.AddMasterForm(attributes, null, (RasterImage)null);

               DiskMasterForm currentMasterForm = parentCategory.MasterForms[i] as DiskMasterForm;
               attributes = currentMasterForm.ReadAttributes();
               FormPages formPages = currentMasterForm.ReadFields();
               RasterImage formImage = currentMasterForm.ReadForm();

               for (int j = 0; j < formImage.PageCount; j++)
               {
                  //Get the Page Recognition Options for the original Attributes
                  PageRecognitionOptions pageOptions = GetPageOptions(j, originalAttributes);

                  //Add each new page to the masterform by creating attributes for each page
                  formImage.Page = j + 1;
                  recognitionEngine.OpenMasterForm(attributes);
                  recognitionEngine.DeleteMasterFormPage(attributes, j + 1);
                  recognitionEngine.InsertMasterFormPage(j+1, attributes, formImage.Clone(), pageOptions, null);
#if FOR_DOTNET4
                  if (_cbUseFullTextSearch.Checked)
                     recognitionEngine.UpsertMasterFormToFullTextSearch(attributes, "index", null, null, null, null);
#endif
                  
                  recognitionEngine.CloseMasterForm(attributes);
               }

               FormProcessingEngine tempProcessingEngine = new FormProcessingEngine();
               tempProcessingEngine.OcrEngine = ocrEngine;
               tempProcessingEngine.BarcodeEngine = barcodeEngine;

               for (int j = 0; j < recognitionEngine.GetFormProperties(attributes).Pages; j++)
                  tempProcessingEngine.Pages.Add(new FormPage(j + 1, formImage.XResolution, formImage.YResolution));

               formPages = tempProcessingEngine.Pages;
               currentMasterForm.WriteAttributes(attributes);

               currentMasterForm.WriteFields(parentCategory.MasterForms[i].ReadFields());
            }
#if FOR_DOTNET4
            if (recognitionEngine.FullTextSearchManager != null)
               recognitionEngine.FullTextSearchManager.Index();
#endif
            System.Diagnostics.Process.Start(_txtSrcFolder.Text);
         }
         catch (Exception ex)
         {
            Invoke((MethodInvoker)delegate { Messager.Show(this, ex, MessageBoxIcon.Error); });
         }
         finally
         {
            // Restore the original version
            FormRecognitionEngine.Version = recognitionEngineVersion;
#if FOR_DOTNET4
            recognitionEngine.FullTextSearchManager = originalFullTextSearchManager;
#endif
            _isRunning = false;
            Invoke((MethodInvoker)delegate
            {
               _prgbar.Value = 0;
               UpdateControls();
            });
         }
      }

      private PageRecognitionOptions GetPageOptions(int pageIndex, FormRecognitionAttributes attributes)
      {
         PageRecognitionOptions options = null;
         recognitionEngine.OpenMasterForm(attributes);
         options = recognitionEngine.GetPageOptions(attributes, pageIndex);
         recognitionEngine.CloseMasterForm(attributes);

         return options;
      }

      private void _btnCancel_Click(object sender, EventArgs e)
      {
         _isRunning = false;
         UpdateControls();
      }

      private void UpdateMasterFormsData_FormClosing(object sender, FormClosingEventArgs e)
      {
         if (!String.IsNullOrEmpty(_txtSrcFolder.Text))
            Properties.Settings.Default.SourceFolder = _txtSrcFolder.Text;

         Properties.Settings.Default.Save();

         if (UpdateMasterFormsThread != null && UpdateMasterFormsThread.ThreadState == ThreadState.Running)
            UpdateMasterFormsThread.Abort();

         _codecs.Dispose();
      }
   }
}

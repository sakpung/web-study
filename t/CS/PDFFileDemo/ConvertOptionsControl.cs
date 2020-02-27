// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using Leadtools.Pdf;
using Leadtools;

namespace PDFFileDemo
{
   public partial class ConvertOptionsControl : UserControl
   {
      private bool _showSecurityOptions;
      private bool _showOptimizationOptions;
      private bool _showInitialViewOptions;
      private TabPage _securityTabPage;
#if LEADTOOLS_V19_OR_LATER
      private TabPage _optimizationTabPage;
      private TabPage _initialViewTabPage;
#endif // #if LEADTOOLS_V19_OR_LATER

      public ConvertOptionsControl()
      {
         InitializeComponent();

         foreach(PDFCompatibilityLevel level in Enum.GetValues(typeof(PDFCompatibilityLevel)))
         {
            _compatibilityLevelComboBox.Items.Add(level);
         }

         _securityTabPage = _securityTab;
#if LEADTOOLS_V19_OR_LATER
         _optimizationTabPage = _optimizationTab;
         _initialViewTabPage = _initialViewTab;
#endif // #if LEADTOOLS_V19_OR_LATER
      }

      public void SetDocument(PDFFile document, bool showCompatibilityLevel, bool showSecurityOptions, bool showOptimizationOptions, bool showInitialViewOptions, int firstPageNumber, int lastPageNumber)
      {
         _showSecurityOptions = showSecurityOptions;
         _showOptimizationOptions = showOptimizationOptions;
         _showInitialViewOptions = showInitialViewOptions;

         _compatibilityLevelComboBox.Visible = showCompatibilityLevel;
         _compatibilityLevelLabel.Visible = showCompatibilityLevel;
         _compatibilityLevelComboBox.SelectedItem = document.CompatibilityLevel;

         if (document.DocumentProperties != null)
         {
            _documentPropertiesControl.SetDocumentProperties(document.DocumentProperties, false);
         }
         else
         {
            PDFDocumentProperties documentProps = new PDFDocumentProperties();
            documentProps.Created = DateTime.Now;
            documentProps.Modified = DateTime.Now;

            _documentPropertiesControl.SetDocumentProperties(documentProps, false);
         }

         if (showSecurityOptions)
         {
            _updateSecurityOptionsCheckBox.Checked = document.SecurityOptions != null;

            if (document.SecurityOptions != null)
               _securityOptionsControl.SetSecurityOptions(document.SecurityOptions);
            else
            {
               PDFSecurityOptions securityOptions = new PDFSecurityOptions();
               securityOptions.PrintEnabled = true;
               securityOptions.HighQualityPrintEnabled = true;
               securityOptions.CopyEnabled = true;
               securityOptions.EditEnabled = true;
               securityOptions.AnnotationsEnabled = true;
               securityOptions.AssemblyEnabled = true;
               securityOptions.EncryptionMode = PDFEncryptionMode.RC40Bit;
               _securityOptionsControl.SetSecurityOptions(securityOptions);
            }
            _securityOptionsControl.SetCompatibilityLevel(document.CompatibilityLevel);
         }

#if LEADTOOLS_V19_OR_LATER
         if (showOptimizationOptions)
         {
            _updateOptimizationOptionsCheckBox.Checked = document.OptimizerOptions != null;

            if (document.OptimizerOptions != null)
               _optimizerOptionsControl.SetOptimizerOptions(document.OptimizerOptions);
            else
            {
               PDFOptimizerOptions optimizerOptions = new PDFOptimizerOptions();
               optimizerOptions.AutoOptimizerMode = PDFAutoOptimizerMode.Customized;
               optimizerOptions.ColorImageDownsamplingMode = PDFDownsamplingMode.Average;
               optimizerOptions.ColorImageDownsampleFactor = 1.5;
               optimizerOptions.ColorImageDPI = 150;
               optimizerOptions.ColorImageCompression = RasterImageFormat.Jpeg;

               optimizerOptions.GrayImageDownsamplingMode = PDFDownsamplingMode.Average;
               optimizerOptions.GrayImageDownsampleFactor = 1.5;
               optimizerOptions.GrayImageDPI = 150;
               optimizerOptions.GrayImageCompression = RasterImageFormat.RawFlate;

               optimizerOptions.MonoImageDownsamplingMode = PDFDownsamplingMode.Average;
               optimizerOptions.MonoImageDownsampleFactor = 1.5;
               optimizerOptions.MonoImageDPI = 150;
               optimizerOptions.MonoImageCompression = RasterImageFormat.FaxG4;

               _optimizerOptionsControl.SetOptimizerOptions(optimizerOptions);
            }
         }

         if (showInitialViewOptions)
         {
            _updateInitialViewOptionsCheckBox.Checked = document.InitialViewOptions != null;

            int totalPages = (lastPageNumber == -1) ? document.Pages.Count - firstPageNumber + 1 : lastPageNumber - firstPageNumber + 1;
            if (document.InitialViewOptions != null)
               _initialViewOptionsControl.SetInitialViewOptions(document.InitialViewOptions, totalPages);
            else
            {
               PDFInitialViewOptions initialViewOptions = new PDFInitialViewOptions();
               initialViewOptions.AutoPrint = false;
               initialViewOptions.CenterWindow = false;
               initialViewOptions.DisplayDocTitle = false;
               initialViewOptions.FitWindow = false;
               initialViewOptions.HideMenubar = false;
               initialViewOptions.HideToolbar = false;
               initialViewOptions.HideWindowUI = false;
               initialViewOptions.PageFitType = PDFPageFitType.Default;
               initialViewOptions.PageLayoutType = PDFPageLayoutType.OneColumnDisplay;
               initialViewOptions.PageModeType = PDFPageModeType.PageOnly;
               initialViewOptions.PageNumber = 1;
               initialViewOptions.Position = new PDFPoint(0, 0);
               initialViewOptions.ZoomPercent = 0;

               _initialViewOptionsControl.SetInitialViewOptions(initialViewOptions, totalPages);
            }
         }
#endif // #if LEADTOOLS_V19_OR_LATER

         UpdateUIState(showSecurityOptions, showOptimizationOptions, showInitialViewOptions);
      }

      public void UpdateDocument(PDFFile document)
      {
         if(_compatibilityLevelComboBox.Visible)
         {
            document.CompatibilityLevel = (PDFCompatibilityLevel)_compatibilityLevelComboBox.SelectedItem;
         }

         if (_updateDocumentPropertiesCheckBox.Checked)
         {
            document.DocumentProperties = new PDFDocumentProperties();
            _documentPropertiesControl.UpdateDocumentProperties(document.DocumentProperties);
         }
         else
         {
            document.DocumentProperties = null;
         }

         if (_showSecurityOptions)
         {
            if (_updateSecurityOptionsCheckBox.Checked)
            {
               document.SecurityOptions = new PDFSecurityOptions();
               _securityOptionsControl.UpdateSecurityOptions(document.SecurityOptions);
               _securityOptionsControl.SetCompatibilityLevel(document.CompatibilityLevel);
            }
            else
            {
               document.SecurityOptions = null;
            }
         }

#if LEADTOOLS_V19_OR_LATER
         if (_showOptimizationOptions)
         {
            if (_updateOptimizationOptionsCheckBox.Checked)
            {
               document.OptimizerOptions = new PDFOptimizerOptions();
               document.OptimizerOptions.AutoOptimizerMode = PDFAutoOptimizerMode.Customized;
               document.OptimizerOptions.ColorImageDownsamplingMode = PDFDownsamplingMode.Average;
               document.OptimizerOptions.ColorImageDownsampleFactor = 1.5;
               document.OptimizerOptions.ColorImageDPI = 150;
               document.OptimizerOptions.ColorImageCompression = RasterImageFormat.Jpeg;

               document.OptimizerOptions.GrayImageDownsamplingMode = PDFDownsamplingMode.Average;
               document.OptimizerOptions.GrayImageDownsampleFactor = 1.5;
               document.OptimizerOptions.GrayImageDPI = 150;
               document.OptimizerOptions.GrayImageCompression = RasterImageFormat.RawFlate;

               document.OptimizerOptions.MonoImageDownsamplingMode = PDFDownsamplingMode.Average;
               document.OptimizerOptions.MonoImageDownsampleFactor = 1.5;
               document.OptimizerOptions.MonoImageDPI = 150;
               document.OptimizerOptions.MonoImageCompression = RasterImageFormat.FaxG4;
               _optimizerOptionsControl.UpdateOptimizerOptions(document.OptimizerOptions);
            }
            else
            {
               document.OptimizerOptions = null;
            }
         }

         if (_showInitialViewOptions)
         {
            if (_updateInitialViewOptionsCheckBox.Checked)
            {
               document.InitialViewOptions = new PDFInitialViewOptions();
               _initialViewOptionsControl.UpdateInitialViewOptions(document.InitialViewOptions);
            }
            else
            {
               document.InitialViewOptions = null;
            }
         }
#endif // #if LEADTOOLS_V19_OR_LATER
      }

      private void UpdateUIState(bool showSecurityOptions, bool showOptimizationOptions, bool showInitialViewOptions)
      {
         _documentPropertiesControl.Enabled = _updateDocumentPropertiesCheckBox.Checked;
         _securityOptionsControl.Enabled = _updateSecurityOptionsCheckBox.Checked;
#if LEADTOOLS_V19_OR_LATER
         _optimizerOptionsControl.Enabled = _updateOptimizationOptionsCheckBox.Checked;
         _initialViewOptionsControl.Enabled = _updateInitialViewOptionsCheckBox.Checked;
#endif // #if LEADTOOLS_V19_OR_LATER

         // Show/Hide unwanted tab pages
         TabPage securityTabPage = _tabControl.TabPages["_securityTab"];
         if (!showSecurityOptions)
         {
            _updateSecurityOptionsCheckBox.Checked = false;
            if (securityTabPage != null)
               _tabControl.TabPages.Remove(securityTabPage);
         }
         else
         {
            if (securityTabPage == null) // Tab page does not exist
               _tabControl.TabPages.Insert(1, _securityTabPage);
         }

         TabPage optimizationTabPage = _tabControl.TabPages["_optimizationTab"];
#if !LEADTOOLS_V19_OR_LATER
         if (optimizationTabPage != null)
            _tabControl.TabPages.Remove(optimizationTabPage);

         optimizationTabPage = _tabControl.TabPages["_initialViewTab"];
         if (optimizationTabPage != null)
            _tabControl.TabPages.Remove(optimizationTabPage);
#else
         if (!showOptimizationOptions)
         {
            if (optimizationTabPage != null)
               _tabControl.TabPages.Remove(optimizationTabPage);
         }
         else
         {
            if (optimizationTabPage == null) // Tab page does not exist
               _tabControl.TabPages.Insert((_tabControl.TabPages.Count >= 2) ? 2 : _tabControl.TabPages.Count, _optimizationTabPage);
         }

         TabPage initialViewTabPage = _tabControl.TabPages["_initialViewTab"];
         if (!showInitialViewOptions)
         {
            if (initialViewTabPage != null)
               _tabControl.TabPages.Remove(initialViewTabPage);
         }
         else
         {
            if (initialViewTabPage == null) // Tab page does not exist
               _tabControl.TabPages.Insert((_tabControl.TabPages.Count >= 3) ? 3 : _tabControl.TabPages.Count, _initialViewTabPage);
         }
#endif // #if !LEADTOOLS_V19_OR_LATER
      }

      private void UpdateOptionsUIState()
      {
         if (PDFCompatibilityLevel.PDFA == (PDFCompatibilityLevel)_compatibilityLevelComboBox.SelectedItem)
            UpdateUIState(false, _showOptimizationOptions, _showInitialViewOptions);
         else
            UpdateUIState(_showSecurityOptions, _showOptimizationOptions, _showInitialViewOptions);
      }

      private void _compatibilityLevelComboBox_SelectedIndexChanged(object sender, EventArgs e)
      {
         UpdateOptionsUIState();
      }

      private void _updateDocumentPropertiesCheckBox_CheckedChanged(object sender, EventArgs e)
      {
         UpdateUIState(_showSecurityOptions, _showOptimizationOptions, _showInitialViewOptions);
      }

      private void _updateSecurityOptionsCheckBox_CheckedChanged(object sender, EventArgs e)
      {
         UpdateUIState(_showSecurityOptions, _showOptimizationOptions, _showInitialViewOptions);
      }

      private void _updateOptimizationOptionsCheckBox_CheckedChanged(object sender, EventArgs e)
      {
         UpdateUIState(_showSecurityOptions, _showOptimizationOptions, _showInitialViewOptions);
      }

      private void _updateInitialViewOptionsCheckBox_CheckedChanged(object sender, EventArgs e)
      {
         UpdateUIState(_showSecurityOptions, _showOptimizationOptions, _showInitialViewOptions);
      }
   }
}

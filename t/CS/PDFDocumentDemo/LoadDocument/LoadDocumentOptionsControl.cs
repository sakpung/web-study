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

using Leadtools;
using Leadtools.Demos;
using Leadtools.Pdf;

namespace PDFDocumentDemo.LoadDocument
{
   public partial class LoadDocumentOptionsControl : UserControl
   {
      private PDFDocument _document;

      private static int _lastResolution = 150;
      private static PDFParseDocumentStructureOptions _lastParseDocumentStructOptions = PDFParseDocumentStructureOptions.All;
      private static PDFParsePagesOptions _lastParsePagesOptions = (PDFParsePagesOptions.AllIgnoreWhiteSpaces) & ~PDFParsePagesOptions.Signatures;
      private static bool _lastParseChunks = true;

      private int _resolution;
      public int Resolution
      {
         get { return _resolution; }
      }

      private PDFParseDocumentStructureOptions _parseDocumentStructOptions;
      public PDFParseDocumentStructureOptions ReadDocumentStructOptions
      {
         get { return _parseDocumentStructOptions; }
      }

      private PDFParsePagesOptions _parsePagesOptions;
      public PDFParsePagesOptions ParsePagesOptions
      {
         get { return _parsePagesOptions; }
      }

      private bool _parseChunks;
      public bool ParseChunks
      {
         get { return _parseChunks; }
      }

      public LoadDocumentOptionsControl()
      {
         InitializeComponent();
      }

      struct ResolutionItem
      {
         public string Name;
         public int Value;

         public ResolutionItem(string name, int value)
         {
            Name = name;
            Value = value;
         }

         public override string ToString()
         {
            return Name;
         }
      }

      protected override void OnLoad(EventArgs e)
      {
         if (!DesignMode)
         {
            int[] resolutions = { 72, 96, 150, 200, 300, 600 };
            foreach (int resolution in resolutions)
            {
               ResolutionItem item = new ResolutionItem(string.Format("{0} {1}/{2}", resolution, DemosGlobalization.GetResxString(GetType(), "resx_pixels"), DemosGlobalization.GetResxString(GetType(), "resx_inch")), resolution);
               _resolutionComboBox.Items.Add(item);
            }
         }
         base.OnLoad(e);
      }

      public void SetDocument(PDFDocument document)
      {
         _document = document;

         // Update resolution
         foreach (ResolutionItem item in _resolutionComboBox.Items)
         {
            if (item.Value == _lastResolution)
            {
               _resolutionComboBox.SelectedItem = item;
               break;
            }
         }

         if (_resolutionComboBox.SelectedIndex == -1)
         {
            _resolutionComboBox.SelectedIndex = 2;
         }

         // Update pages
         int pageCount = _document.Pages.Count;
         _pagesInfoLabel.Text = _pagesInfoLabel.Text.Replace("###", pageCount.ToString());

         _readBookmarksCheckBox.Checked = (_lastParseDocumentStructOptions & PDFParseDocumentStructureOptions.Bookmarks) == PDFParseDocumentStructureOptions.Bookmarks;
         _readFontsCheckBox.Checked = (_lastParseDocumentStructOptions & PDFParseDocumentStructureOptions.Fonts) == PDFParseDocumentStructureOptions.Fonts;
         _readInternalLinksCheckBox.Checked = (_lastParseDocumentStructOptions & PDFParseDocumentStructureOptions.InternalLinks) == PDFParseDocumentStructureOptions.InternalLinks;
         _parseObjectsCheckBox.Checked = (_lastParsePagesOptions != PDFParsePagesOptions.None);
         _parseDigitalSignaturesCheckBox.Checked = (_lastParsePagesOptions & PDFParsePagesOptions.Signatures) == PDFParsePagesOptions.Signatures;
         _parseChunksCheckBox.Checked = _lastParseChunks;

         if (pageCount <= 50)
         {
            _parseObjectsInfoLabel.Text = DemosGlobalization.GetResxString(GetType(), "resx_UnneededOption");
            _parseChunksCheckBox.Checked = false;
            _parseChunksCheckBox.Enabled = false;
         }
      }

      public void Apply()
      {
         // Get read object options
         // Get resolution
         ResolutionItem resolutionItem = (ResolutionItem)_resolutionComboBox.SelectedItem;
         _resolution = resolutionItem.Value;

         _parseDocumentStructOptions = PDFParseDocumentStructureOptions.None;

         if (_readBookmarksCheckBox.Checked) _parseDocumentStructOptions |= PDFParseDocumentStructureOptions.Bookmarks;
         if (_readFontsCheckBox.Checked) _parseDocumentStructOptions |= PDFParseDocumentStructureOptions.Fonts;
         if (_readInternalLinksCheckBox.Checked) _parseDocumentStructOptions |= PDFParseDocumentStructureOptions.InternalLinks;

         _parsePagesOptions = PDFParsePagesOptions.None;
         if (_parseObjectsCheckBox.Checked) _parsePagesOptions = PDFParsePagesOptions.AllIgnoreWhiteSpaces;
         if (!_parseDigitalSignaturesCheckBox.Checked) _parsePagesOptions &= ~PDFParsePagesOptions.Signatures;

         _parseChunks = _parseChunksCheckBox.Checked;

         _lastResolution = _resolution;
         _lastParseDocumentStructOptions = _parseDocumentStructOptions;
         _lastParsePagesOptions = _parsePagesOptions;
         _lastParseChunks = _parseChunks;
      }

      private void _parseDigitalSignaturesCheckBox_CheckedChanged(object sender, EventArgs e)
      {
         if (_parseDigitalSignaturesCheckBox.Checked)
         {
            if (!HasDigitalSignatureSupport(this))
               _parseDigitalSignaturesCheckBox.Checked = false;
         }
      }

      private static bool HasDigitalSignatureSupport(IWin32Window owner)
      {
         // If the user selected to parse digital signature then verify the status
         RasterExceptionCode digitalSignatureSupportStatus = PDFDocument.GetDigitalSignatureSupportStatus();
         if (digitalSignatureSupportStatus == RasterExceptionCode.OpenSSLDllMissing)
         {
            // We have PDF digital signature support but Open SSL library is missing.
            string message = "To use this feature, download the latest version of the 1.1.0 OpenSSL libraries and copy libcrypto-1_1[-x64].dll and libssl-1_1[-x64].dll to the location of the LEADTOOLS binaries folder." + Environment.NewLine + Environment.NewLine +
               "LEAD Precompiled and Signed OpenSSL binaries:" + Environment.NewLine +
               "https://www.leadtools.com/openssl/binaries" + Environment.NewLine + Environment.NewLine +
               "OpenSSL source code:" + Environment.NewLine +
               "https://www.openssl.org";
            string caption = "Download OpenSSL";

            MessageBox.Show(owner, message, caption, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
         }
         else
         {
            // Nothing for us to do, will either work or not supported in this platform
            return true;
         }
      }
   }
}

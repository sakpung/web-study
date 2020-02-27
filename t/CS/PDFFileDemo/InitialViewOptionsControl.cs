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

using Leadtools.Pdf;

namespace PDFFileDemo
{
   public partial class InitialViewOptionsControl : UserControl
   {
      public InitialViewOptionsControl()
      {
         InitializeComponent();
      }

#if LEADTOOLS_V19_OR_LATER
      public void SetInitialViewOptions(PDFInitialViewOptions initialViewOptions, int totalPages)
      {
         // Initial View Options
         _pageModeComboBox.Items.Clear();
         Array a = Enum.GetValues(typeof(PDFPageModeType));
         foreach (PDFPageModeType i in a)
            _pageModeComboBox.Items.Add(i);
         _pageModeComboBox.SelectedItem = initialViewOptions.PageModeType;

         _pageLayoutComboBox.Items.Clear();
         a = Enum.GetValues(typeof(PDFPageLayoutType));
         foreach (PDFPageLayoutType i in a)
            _pageLayoutComboBox.Items.Add(i);
         _pageLayoutComboBox.SelectedItem = initialViewOptions.PageLayoutType;

         _pageFitTypeComboBox.Items.Clear();
         a = Enum.GetValues(typeof(PDFPageFitType));
         foreach (PDFPageFitType i in a)
            _pageFitTypeComboBox.Items.Add(i);

         int[] predefinedZoomValues = { 25, 50, 75, 100, 125, 150, 200, 400, 800, 1600, 2400, 3200, 6400 };
         foreach (int i in predefinedZoomValues)
            _pageFitTypeComboBox.Items.Add(string.Format("{0}%", i));
         if (initialViewOptions.ZoomPercent == 0)
            _pageFitTypeComboBox.SelectedItem = initialViewOptions.PageFitType;
         else
         {
            for (int i = Enum.GetValues(typeof(PDFPageFitType)).Length; i < _pageFitTypeComboBox.Items.Count; i++)
            {
               string pageFitType = _pageFitTypeComboBox.Items[i] as string;
               if (!string.IsNullOrEmpty(pageFitType))
               {
                  double value;
                  if (double.TryParse(new string(pageFitType.Trim().TakeWhile(c => char.IsDigit(c) || c == '.').ToArray()), out value))
                  {
                     if (value == initialViewOptions.ZoomPercent)
                     {
                        _pageFitTypeComboBox.SelectedIndex = i;
                        break;
                     }
                  }
               }
            }
         }

         if (_pageFitTypeComboBox.SelectedItem == null)
         {
            if (initialViewOptions.ZoomPercent == 0)
               _pageFitTypeComboBox.SelectedIndex = 0;
            else
               _pageFitTypeComboBox.Text = string.Format("{0}%", initialViewOptions.ZoomPercent);
         }

         _initialPageNumberEditBox.Text = initialViewOptions.PageNumber.ToString();
         _numberOfPagesLabel.Text = string.Format("of {0}", totalPages);
         _resizeWindowCheckBox.Checked = initialViewOptions.FitWindow;
         _centerWindowCheckBox.Checked = initialViewOptions.CenterWindow;

         _showDocumentTitleComboBox.Items.Clear();
         _showDocumentTitleComboBox.Items.Add("File Name");
         _showDocumentTitleComboBox.Items.Add("Document Title");
         _showDocumentTitleComboBox.SelectedIndex = (initialViewOptions.DisplayDocTitle) ? 1 : 0;
         _hideMenuBarCheckBox.Checked = initialViewOptions.HideMenubar;
         _hideToolBarCheckBox.Checked = initialViewOptions.HideToolbar;
         _hideWindowControlsCheckBox.Checked = initialViewOptions.HideWindowUI;
      }

      public void UpdateInitialViewOptions(PDFInitialViewOptions initialViewOptions)
      {
         initialViewOptions.PageModeType = (PDFPageModeType)_pageModeComboBox.SelectedItem;
         initialViewOptions.PageLayoutType = (PDFPageLayoutType)_pageLayoutComboBox.SelectedItem;
         if (_pageFitTypeComboBox.SelectedIndex >= 0 && _pageFitTypeComboBox.SelectedIndex < Enum.GetValues(typeof(PDFPageFitType)).Length)
         {
            // Selected item is one of the original enum members, so just use it
            initialViewOptions.PageFitType = (PDFPageFitType)_pageFitTypeComboBox.SelectedItem;
            initialViewOptions.ZoomPercent = 0;
         }
         else
         {
            string pageFitType = _pageFitTypeComboBox.Text;
            double value;
            if (double.TryParse(new string(pageFitType.Trim().TakeWhile(c => char.IsDigit(c) || c == '.').ToArray()), out value))
               initialViewOptions.ZoomPercent = value;
         }

         int val;
         if (int.TryParse(_initialPageNumberEditBox.Text, out val))
            initialViewOptions.PageNumber = val;
         else
            initialViewOptions.PageNumber = 1;

         initialViewOptions.FitWindow = _resizeWindowCheckBox.Checked;
         initialViewOptions.CenterWindow = _centerWindowCheckBox.Checked;
         initialViewOptions.DisplayDocTitle = (_showDocumentTitleComboBox.SelectedIndex == 1) ? true : false;
         initialViewOptions.HideMenubar = _hideMenuBarCheckBox.Checked;
         initialViewOptions.HideToolbar = _hideToolBarCheckBox.Checked;
         initialViewOptions.HideWindowUI = _hideWindowControlsCheckBox.Checked;
      }

      private void _hideMenuBarCheckBox_CheckedChanged(object sender, EventArgs e)
      {
         // Hide Window Controls and Hide Menubar doesn't work together even on Adobe Acrobat side, so we will uncheck the other one if one of them is checked
         if (_hideWindowControlsCheckBox.Checked)
         {
            _hideWindowControlsCheckBox.CheckedChanged -= new System.EventHandler(_hideWindowControlsCheckBox_CheckedChanged);
            _hideWindowControlsCheckBox.Checked = false;
            _hideWindowControlsCheckBox.CheckedChanged += new System.EventHandler(_hideWindowControlsCheckBox_CheckedChanged);
         }
      }

      private void _hideWindowControlsCheckBox_CheckedChanged(object sender, EventArgs e)
      {
         // Hide Window Controls and Hide Menubar doesn't work together even on Adobe Acrobat side, so we will uncheck the other one if one of them is checked
         if (_hideMenuBarCheckBox.Checked)
         {
            _hideMenuBarCheckBox.CheckedChanged -= new System.EventHandler(_hideMenuBarCheckBox_CheckedChanged);
            _hideMenuBarCheckBox.Checked = false;
            _hideMenuBarCheckBox.CheckedChanged += new System.EventHandler(_hideMenuBarCheckBox_CheckedChanged);
         }
      }
#endif // #if LEADTOOLS_V19_OR_LATER
   }
}

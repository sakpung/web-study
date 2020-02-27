// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Leadtools.Demos;

#if LEADTOOLS_V19_OR_LATER
using Leadtools.Demos.Dialogs;
#endif

namespace Ocr2SharePointDemo
{
   public partial class MainForm : Form
   {
      private DemoOptions _demoOptions = DemoOptions.Default;
      private bool _isRunningOperation;
      private SharePoint.SPListInfo[] _sharePointLists;

      public MainForm()
      {
         InitializeComponent();
      }

      protected override void OnLoad(EventArgs e)
      {
         if (!DesignMode)
         {
            Messager.Caption = "OCR 2 SharePoint 2010 C# Demo";
            Text = Messager.Caption;

            this.Text = Messager.Caption;

            _demoOptions = DemoOptions.Load();

            _sharePointServerSettingsControl.SetOwner(this);
            _selectImageDocumentFileControl.SetOwner(this, _demoOptions.ImageDocumentFileName);
            _sharePointBrowserControl.SetOwner(this);
            _recognizeAndUploadControl.SetOwner(this);

            _sharePointServerSettingsControl.SetServerSettings(_demoOptions.SharePointServerSettings);

            UpdateUIState();
         }

         base.OnLoad(e);
      }

      protected override void OnFormClosing(FormClosingEventArgs e)
      {
         e.Cancel = _isRunningOperation;

         base.OnFormClosing(e);
      }

      protected override void OnFormClosed(FormClosedEventArgs e)
      {
         _demoOptions.Save();

         base.OnFormClosed(e);
      }

      public void UpdateUIState()
      {
         if (_isRunningOperation)
         {
            _mainWizardControl.Enabled = false;
            _operationPanel.Visible = true;

            _aboutButton.Enabled = false;
            _exitButton.Enabled = false;
            _previousButton.Enabled = false;
            _nextButton.Enabled = false;
         }
         else
         {
            _mainWizardControl.Enabled = true;
            _operationPanel.Visible = false;
            _aboutButton.Enabled = true;
            _exitButton.Enabled = true;

            if (_mainWizardControl.SelectedTab == _serverPropertiesTabPage)
            {
               ServerPropertiesUpdateUIState();
            }
            else if (_mainWizardControl.SelectedTab == _sharePointBrowserTabPage)
            {
               SharePointBrowserUpadateUIState();
            }
            else if (_mainWizardControl.SelectedTab == _selectImageDocumentFileTabPage)
            {
               SelectImageDocumentFileUpdateUIState();
            }
            else if (_mainWizardControl.SelectedTab == _recognizeAndUploadTabPage)
            {
               RecognizeAndUploadUpdateUIState();
            }
         }
      }

      public void BeginOperation(MethodInvoker method)
      {
         _isRunningOperation = true;
         _operationLabel.Text = string.Empty;
         UpdateUIState();

         method.BeginInvoke(null, null);
      }

      public void SetOperationText(string text)
      {
         BeginInvoke((MethodInvoker) delegate
         {
            _operationLabel.Text = text;
         });
      }

      public void EndOperation(Exception error)
      {
         BeginInvoke(new EndOperationDelegate(DoEndOperation), new object[] { error });
      }

      private delegate void EndOperationDelegate(Exception error);
      private void DoEndOperation(Exception error)
      {
         _isRunningOperation = false;
         UpdateUIState();

         if (error == null)
         {
            if (_mainWizardControl.SelectedTab == _serverPropertiesTabPage)
            {
               _demoOptions.SharePointServerSettings = _sharePointServerSettingsControl.ServerSettings;
               _sharePointLists = _sharePointServerSettingsControl.SharePointLists;
               _sharePointBrowserControl.SetSharePointSettings(_demoOptions.SharePointServerSettings, _sharePointLists);
               _nextButton.PerformClick();
            }
         }
         else
         {
            Messager.ShowError(this, error);
         }
      }

      private void ServerPropertiesUpdateUIState()
      {
         _previousButton.Enabled = false;
         _nextButton.Enabled = _sharePointServerSettingsControl.SharePointLists != null;
         _nextButton.Text = "&Next";
      }

      private void SelectImageDocumentFileUpdateUIState()
      {
         _previousButton.Enabled = true;
         _nextButton.Enabled = !string.IsNullOrEmpty(_selectImageDocumentFileControl.ImageDocumentFileName);
         _nextButton.Text = "&Next";
      }

      private void SharePointBrowserUpadateUIState()
      {
         _previousButton.Enabled = true;
         _nextButton.Enabled = !string.IsNullOrEmpty(_sharePointBrowserControl.GetCurrentFolderPath(false));
         _nextButton.Text = "&Next";
      }

      private void RecognizeAndUploadUpdateUIState()
      {
         _previousButton.Enabled = true;
         _nextButton.Enabled = true;
         _nextButton.Text = "&Next";
      }

      private void _aboutButton_Click(object sender, EventArgs e)
      {
#if LEADTOOLS_V19_OR_LATER
         using (AboutDialog aboutDialog = new AboutDialog("OCR 2 SharePoint 2010", ProgrammingInterface.CS))
            aboutDialog.ShowDialog(this);
#else
         using (AboutDialog aboutDialog = new AboutDialog("OCR 2 SharePoint 2010"))
            aboutDialog.ShowDialog(this);
#endif
      }

      private void _exitButton_Click(object sender, EventArgs e)
      {
         Close();
      }

      private void _nextButton_Click(object sender, EventArgs e)
      {
         if (_mainWizardControl.SelectedTab == _serverPropertiesTabPage)
         {
            _mainWizardControl.SelectedTab = _sharePointBrowserTabPage;
            _sharePointBrowserControl.RefreshCurrentFolder();
            UpdateUIState();
         }
         else if (_mainWizardControl.SelectedTab == _sharePointBrowserTabPage)
         {
            _mainWizardControl.SelectedTab = _selectImageDocumentFileTabPage;
            UpdateUIState();
         }
         else if (_mainWizardControl.SelectedTab == _selectImageDocumentFileTabPage)
         {
            _demoOptions.ImageDocumentFileName = _selectImageDocumentFileControl.ImageDocumentFileName;
            MyDocumentFormat format = _selectImageDocumentFileControl.GetSelectedDocumentFormat();
            _demoOptions.DocumentFormatIndex = (int)format;

            // Create the URL for the output document
            string outputDocumentPathAndFileName = BuildOutputDocumentPathAndFileName();

            _recognizeAndUploadControl.SetProperties(
               _demoOptions.SharePointServerSettings,
               _demoOptions.ImageDocumentFileName,
               outputDocumentPathAndFileName,
               (MyDocumentFormat)_demoOptions.DocumentFormatIndex);

            _mainWizardControl.SelectedTab = _recognizeAndUploadTabPage;
            UpdateUIState();

            Application.DoEvents();
            _recognizeAndUploadControl.Run();
         }
         else if (_mainWizardControl.SelectedTab == _recognizeAndUploadTabPage)
         {
            _mainWizardControl.SelectedTab = _sharePointBrowserTabPage;
            _sharePointBrowserControl.RefreshCurrentFolder();
            _sharePointBrowserControl.SelectItem(_recognizeAndUploadControl.LastUplodedDocumentUri);
            UpdateUIState();
         }
      }

      private void _previousButton_Click(object sender, EventArgs e)
      {
         if (_mainWizardControl.SelectedTab == _sharePointBrowserTabPage)
         {
            _mainWizardControl.SelectedTab = _serverPropertiesTabPage;
            UpdateUIState();
         }
         else if (_mainWizardControl.SelectedTab == _selectImageDocumentFileTabPage)
         {
            _mainWizardControl.SelectedTab = _sharePointBrowserTabPage;
            _sharePointBrowserControl.RefreshCurrentFolder();
            UpdateUIState();
         }
         else if (_mainWizardControl.SelectedTab == _recognizeAndUploadTabPage)
         {
            _mainWizardControl.SelectedTab = _selectImageDocumentFileTabPage;
            UpdateUIState();
         }
      }

      private string BuildOutputDocumentPathAndFileName()
      {
         // Get the server folder URI
         string folderPath = _sharePointBrowserControl.GetCurrentFolderPath(false);

         MyDocumentFormat format = (MyDocumentFormat)_demoOptions.DocumentFormatIndex;
         string extension = MyDocumentFormatItem.GetExtension(format);
         string name = System.IO.Path.GetFileNameWithoutExtension(_demoOptions.ImageDocumentFileName);

         string outputDocumentPathAndFileName = System.IO.Path.Combine(folderPath, name);
         outputDocumentPathAndFileName = System.IO.Path.ChangeExtension(outputDocumentPathAndFileName, extension);
         return outputDocumentPathAndFileName;
      }
   }
}

// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ModalityWorklistWCFDemo.UI.Pages;
using Leadtools.Demos;
using ModalityWorklistWCFDemo.Broker;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using System.IO;
using Leadtools.DicomDemos;

namespace ModalityWorklistWCFDemo.UI
{
   public partial class MainForm : Form
   {
      [DllImport("shfolder.dll", CharSet = CharSet.Auto)]
      private static extern int SHGetFolderPath(IntPtr hwndOwner, int nFolder, IntPtr hToken, int dwFlags, StringBuilder lpszPath);

      private const int CommonDocumentsFolder = 0x2e;
      private string _ConfigFile = string.Empty;

      public static string GetFolderPath()
      {
         StringBuilder lpszPath = new StringBuilder(260);
         // CommonDocuments is the folder than any Vista user (including 'guest') has read/write access
         SHGetFolderPath(IntPtr.Zero, (int)CommonDocumentsFolder, IntPtr.Zero, 0, lpszPath);
         string path = lpszPath.ToString();
         new FileIOPermission(FileIOPermissionAccess.PathDiscovery, path).Demand();
         return path;
      }

      public MainForm()
      {
         InitializeComponent();
      }

      IntroductionPage _introductionPage = null;
      PatientPage _patientPage = null;
      ImagingServiceRequestPage _imagingServiceRequestPage = null;
      RequestedProcedurePage _requestedProcedurePage = null;
      ScheduledProcedureStepPage _scheduledProcedureStepPage = null;

      public IntroductionPage MyIntroductionPage
      {
         get { return _introductionPage; }
      }

      public PatientPage MyPatientPage
      {
         get { return _patientPage; }
      }

      public ImagingServiceRequestPage MyImagingServiceRequestPage
      {
         get { return _imagingServiceRequestPage; }
      }

      public RequestedProcedurePage MyRequestedProcedurePage
      {
         get { return _requestedProcedurePage; }
      }

      public ScheduledProcedureStepPage MyScheduledProcedureStepPage
      {
         get { return _scheduledProcedureStepPage; }
      }

      private void MainForm_Load(object sender, EventArgs e)
      {
         Messager.Caption = "C# Modality Worklist WCF Demo";
         Text = Messager.Caption;

         try
         {
            _ConfigFile = DicomDemoSettingsManager.GetSettingsFilename("WCFClient");
            if (!File.Exists(_ConfigFile))
            {
               DicomDemoSettingsManager.RunPacsConfigDemo();
               if (!File.Exists(_ConfigFile))
               {
                  Messager.Show(this, "No configuration file.\nApplication cannot continue without configuration", MessageBoxIcon.Warning, MessageBoxButtons.OK);
                  Close();
               }
            }
            SetServiceClient();

            _introductionPage = new IntroductionPage();
            _patientPage = new PatientPage();
            _imagingServiceRequestPage = new ImagingServiceRequestPage();
            _requestedProcedurePage = new RequestedProcedurePage();
            _scheduledProcedureStepPage = new ScheduledProcedureStepPage();

            wizardSheet.Pages.Add(_introductionPage);
            wizardSheet.Pages.Add(_patientPage);
            wizardSheet.Pages.Add(_imagingServiceRequestPage);
            wizardSheet.Pages.Add(_requestedProcedurePage);
            wizardSheet.Pages.Add(_scheduledProcedureStepPage);
            wizardSheet.SetActivePage(0);
         }
         catch (Exception ex)
         {
            Messager.ShowError(this, ex.Message + "\r\n\r\nApplication will exit.");
            Application.Exit();
         }
      }

      public void Channel_Faulted(object sender, EventArgs e)
      {
         CustomBrokerClient client = wizardSheet.Tag as CustomBrokerClient;

         client.InnerChannel.Faulted -= Channel_Faulted;
         client.Abort();
         SetServiceClient();
      }

      private void SetServiceClient()
      {
         CustomBrokerClient client = new CustomBrokerClient(_ConfigFile);

         client.InnerChannel.Faulted += new EventHandler(Channel_Faulted);
         wizardSheet.Tag = client;
      }

      private void wizardSheet_About(object sender, EventArgs e)
      {
         AboutDialog dlgAbout = new AboutDialog("Modality Worklist WCF");

         dlgAbout.ShowDialog(this);
      }

      private void wizardSheet_WizardFinished(object sender, CancelEventArgs e)
      {
         DialogResult result = Messager.Show(this, "The wizard has completed adding modality work list information.  " +
                                             "Would you like to keep adding modality work list information?  Clicking No " +
                                             "will exit the application.",
                                             MessageBoxIcon.Information, MessageBoxButtons.YesNo);

         if (result == DialogResult.Yes)
         {
            e.Cancel = true;
            wizardSheet.SetActivePage(1);
            wizardSheet.Reset();
            return;
         }
      }
   }

   public class CustomBrokerClient : BrokerServiceClient
   {
      private string _ConfigFile;

      public CustomBrokerClient(string configFile) : base("WSHttpBinding_IBrokerService")
      {
         _ConfigFile = configFile;
      }

      protected override IBrokerService CreateChannel()
      {
         CustomChannelFactory<IBrokerService> factory = new CustomChannelFactory<IBrokerService>("WSHttpBinding_IBrokerService", _ConfigFile);

         return factory.CreateChannel();
      }
   }
}

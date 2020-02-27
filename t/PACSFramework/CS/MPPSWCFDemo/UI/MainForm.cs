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
using MPPSWCFDemo.UI.Pages;
using Leadtools.Demos;
using MPPSWCFDemo.Broker;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using System.IO;
using Leadtools.DicomDemos;

namespace MPPSWCFDemo.UI
{
   public partial class MainForm : Form
   {
      private static WCFPPSInformation _Mpps;
      private string _ConfigFile = string.Empty;

      public static WCFPPSInformation Mpps
      {
         get { return _Mpps; }
         set { _Mpps = value; }
      }

      [DllImport("shfolder.dll", CharSet = CharSet.Auto)]
      private static extern int SHGetFolderPath(IntPtr hwndOwner, int nFolder, IntPtr hToken, int dwFlags, StringBuilder lpszPath);

      private const int CommonDocumentsFolder = 0x2e;

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

      private void MainForm_Load(object sender, EventArgs e)
      {
         Messager.Caption = "C# MPPS WCF Demo";
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
            wizardSheet.Pages.Add(new IntroductionPage());
            wizardSheet.Pages.Add(new MPPSInstancePage());
            wizardSheet.Pages.Add(new SequencesPage());
            wizardSheet.Pages.Add(new UnscheduledPatientPage());
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
         BrokerServiceClient client = wizardSheet.Tag as BrokerServiceClient;

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
         AboutDialog dlgAbout = new AboutDialog("MPPS WCF");

         dlgAbout.ShowDialog(this);
      }

      private void wizardSheet_WizardFinished(object sender, CancelEventArgs e)
      {
         DialogResult result = Messager.Show(this, "The wizard has completed editing the modality performed procedure step.  " +
                                             "Would you like edit another modality performed procedure step?  Clicking No " +
                                             "will exit the application.",
                                             MessageBoxIcon.Information, MessageBoxButtons.YesNo);

         if (result == DialogResult.Yes)
         {
            e.Cancel = true;
            wizardSheet.Reset();
            wizardSheet.SetActivePage(1);            
            return;
         }
      }
   }

   public class CustomBrokerClient : BrokerServiceClient
   {
      private string _ConfigFile;

      public CustomBrokerClient(string configFile)
         : base("WSHttpBinding_IBrokerService")
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

// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Threading;
using System.Management;
using Leadtools;
using Leadtools.Dicom;
using Leadtools.Dicom.Scu.Common;
using Leadtools.DicomDemos;
using Leadtools.Demos;
using Leadtools.Dicom.Scu;
using System.Diagnostics;
using Leadtools.Dicom.Common.Extensions;

#if LEADTOOLS_V19_OR_LATER
using Leadtools.Dicom.Common.DataTypes;
#endif

namespace DicomDemo
{
   public partial class MainForm : Form
   {
      private class MyStoreScu : StoreScu
      {
         private MainForm _form;

#if LEADTOOLS_V20_OR_LATER
         public MyStoreScu(MainForm form, string TemporaryDirectory, DicomNetSecurityMode SecurityMode, DicomOpenSslContextCreationSettings openSslContextCreationSettings)
            : base(TemporaryDirectory, SecurityMode, openSslContextCreationSettings)
         {
            _form = form;
         }
#else
         public MyStoreScu(MainForm form, string TemporaryDirectory, DicomNetSecurityeMode SecurityMode, DicomOpenSslContextCreationSettings openSslContextCreationSettings)
            : base(TemporaryDirectory, SecurityMode, openSslContextCreationSettings)
         {
            _form = form;
         }
#endif // #if LEADTOOLS_V20_OR_LATER

         public MyStoreScu(MainForm form) : base()
         {
            _form = form;
         }

         protected override void OnClose(DicomExceptionCode error, DicomNet net)
         {
            _form.LogText("Server Closed Connection", string.Empty);
            base.OnClose(error, net);


            if (_form != null)
            {
               _form.EnableCancel(false);
            }
         }

         protected override void OnReceiveCStoreResponse(byte presentationID, int messageID, string affectedClass, string instance, DicomCommandStatusType status)
         {
            if ((_form != null) && (_form._mySettings.LogLowLevel))
            {
               string sMsg =
                  _sNewlineTab + "presentationID:\t" + presentationID.ToString() +
                  _sNewlineTab + "messageID:\t" + messageID.ToString() +
                  _sNewlineTab + "affectedClass:\t" + affectedClass +
                  _sNewlineTab + "instance:\t" + instance +
                  _sNewlineTab + "status:\t" + status.ToString();

               _form.LogText("OnReceiveCStoreResponse", sMsg, Color.Green);
            }
            base.OnReceiveCStoreResponse(presentationID, messageID, affectedClass, instance, status);
         }

         protected override void OnReceiveReleaseResponse()
         {
            if ((_form != null) && (_form._mySettings.LogLowLevel))
            {
               _form.LogText("OnReceiveReleaseResponse", string.Empty, System.Drawing.Color.Green);
            }
            base.OnReceiveReleaseResponse();
         }

         protected override void OnReceiveAssociateAccept(DicomAssociate association)
         {
            if ((_form != null) && (_form._mySettings.LogLowLevel))
            {
               _form.LogText("OnReceiveAssociateAccept", string.Empty, System.Drawing.Color.Green);
            }
            base.OnReceiveAssociateAccept(association);
         }

         protected override void OnReceiveNActionResponse(byte presentationID, int messageID, string affectedClass, string instance, DicomCommandStatusType status, int action, DicomDataSet dataSet)
         {
            if ((_form != null) && (_form._mySettings.LogLowLevel))
            {
               string sMsg =
                  _sNewlineTab + "presentationID:\t" + presentationID.ToString() +
                  _sNewlineTab + "messageID:\t" + messageID.ToString() +
                  _sNewlineTab + "affectedClass:\t" + affectedClass +
                  _sNewlineTab + "instance:\t" + instance +
                  _sNewlineTab + "status:\t" + status.ToString() +
                  _sNewlineTab + "action:\t" + action.ToString();

               _form.LogText("OnReceiveNActionResponse", sMsg, Color.Green);
            }
            base.OnReceiveNActionResponse(presentationID, messageID, affectedClass, instance, status, action, dataSet);
         }

         protected override void OnReceiveNReportRequest(byte presentationID, int messageID, string affectedClass, string instance, int dicomEvent, DicomDataSet dataSet)
         {
            if ((_form != null) && (_form._mySettings.LogLowLevel))
            {
               string sMsg =
                  _sNewlineTab + "presentationID:\t" + presentationID.ToString() +
                  _sNewlineTab + "messageID:\t" + messageID.ToString() +
                  _sNewlineTab + "affectedClass:\t" + affectedClass +
                  _sNewlineTab + "instance:\t" + instance +
                  _sNewlineTab + "dicomEvent:\t" + dicomEvent.ToString();

               _form.LogText("OnReceiveNReportRequest", sMsg, Color.Green);
            }
            base.OnReceiveNReportRequest(presentationID, messageID, affectedClass, instance, dicomEvent, dataSet);
         }

      }

      // CStore highlevel object
      private MyStoreScu _cstore;
      private DicomScp _server = new DicomScp();
      private const string _sConfigurationImplementationClass = "1.2.840.114257.1123456";
      private const string _sConfigurationImplementationVersionName = "1";
      private const string _sConfigurationProtocolVersion = "1";

      // Settings
      public DicomDemoSettings _mySettings = new DicomDemoSettings();
      public string _demoName = Path.GetFileName(Application.ExecutablePath);

      // Logging
      private const string _sTab = "\t";
      private const string _sNewlineTab = "\r\n\t";
      private const string _sNewlineTabTab = "\r\n\t\t";

      public delegate void AddLog(string action, string logText, Color sActionColor);
      bool _cancel = false;
      private TextBoxTraceListener _tracer = null;
      private bool _closing = false;

      const string sHelpInstructions =
         "Command Line Options:" + _sNewlineTab +
         "/? or /help\t\tDisplays this help" + _sNewlineTab +
         "/configure\t\tConfigures the client (use one or more options below)" + _sNewlineTab +
         "/server_aetitle={aetitle}\tServer AE title" + _sNewlineTab +
         "/server_ip={ip address}\tServer IP" + _sNewlineTab +
         "/server_port={port}\tServer Port" + _sNewlineTab +
         "/client_aetitle={aetitle}\tClient AE title" + _sNewlineTab +
         "/client_port={port}\t\tClient Port" + _sNewlineTab +
         "/defaults\t\t\tSets defaults for other options";

      // Help
      bool _firstTime = true;


      static class Program
      {
         /// <summary>
         /// The main entry point for the application.
         /// </summary>
         [STAThread]
         static void Main(string[] args)
         {
            bool bConfigure = ReadCommandLine(args);
            if (bConfigure)
               return;

#if LEADTOOLS_V19_OR_LATER
            if (!Support.SetLicense())
               return;
#else
            Support.SetLicense();
            if (RasterSupport.KernelExpired)
               return;
#endif

#if LEADTOOLS_V175_OR_LATER
            if (RasterSupport.IsLocked(RasterSupportType.DicomCommunication))
            {
               MessageBox.Show(String.Format("{0} Support is locked!", RasterSupportType.DicomCommunication.ToString()), "Warning");
               return;
            }
#else
         if ( RasterSupport.IsLocked ( RasterSupportType.MedicalNet ) )
         {
            MessageBox.Show(String.Format("{0} Support is locked!", RasterSupportType.MedicalNet.ToString()), "Warning");
            return;
         }
#endif // #if LEADTOOLS_V175_OR_LATER

#if (LEADTOOLS_V20_OR_LATER)
            if (DemosGlobal.IsDotNet45OrLaterInstalled() == false)
            {
               MessageBox.Show("To run this application, you must first install Microsoft .NET Framework 4.5 or later.",
                  "Microsoft .NET Framework 4.5 or later Required",
                  MessageBoxButtons.OK,
                  MessageBoxIcon.Exclamation);
               return;
            }
#endif
            Utils.EngineStartup();
            Utils.DicomNetStartup();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            try
            {
               Application.Run(new MainForm());
            }
            catch (Exception)
            {
            }
            finally
            {
               DicomEngine.Shutdown();
               DicomNet.Shutdown();
            }
         }
      }

      static string GetDefaultIp()
      {
         ManagementObjectSearcher query = new ManagementObjectSearcher("SELECT * FROM Win32_NetworkAdapterConfiguration WHERE IPEnabled = 'TRUE'");
         ManagementObjectCollection queryCollection = query.Get();

         foreach (ManagementObject mo in queryCollection)
         {
            if (queryCollection.Count > 0)
            {
               string[] addresses = (string[])mo["IPAddress"];

               foreach (string ip in addresses)
               {
                  if (!ip.Contains(":") && (ip != "0.0.0.0"))
                     return ip;
               }
            }
         }
         return string.Empty;
      }

      // Here are two sample command lines:
      //       /configure /server_aetitle=STORAGE_SCU /server_ip=10.1.1.167 /server_port=104 /defaults
      //       /configure /server_aetitle=test_server_ae /server_ip=10.1.1.123 /server_port=123 /client_aetitle=test_client_ae /client_ip=test_client_ip /client_port=456 /defaults
      static bool ReadCommandLine(string[] args)
      {
         return false;
      }


      public MainForm()
      {
         InitializeComponent();
         if (!DicomDemoSettingsManager.Is64Process())
            Text = Text + " (32 bit)";
         else
            Text = Text + "(64 bit)";
      }

      private void MainForm_Load(object sender, EventArgs e)
      {
#if !LEADTOOLS_V19_OR_LATER
         _buttonStorageCommit.Visible = false;
#endif
         SizeColumns();
         EnableCancel(false);
         StatusText(string.Empty);
      }

      private const string defaultServerAE = "LEAD_SERVER";
      private const string defaultServerIP = "127.0.0.1";
      private const int defaultServerPort = 104;
      private const int defaultServerTimeout = 30;
      private const bool defaultServerUseTls = false;
      private const int defaultCompression = 2;

      private const string defaultClientAE = "LEAD_CLIENT";
      private const int defaultClientPort = 1000;

      private static void SetOtherDefaults(DicomDemoSettings settings)
      {
         settings.ClientCertificate = DicomDemoSettingsManager.GetClientCertificateFullPath();
         settings.ClientPrivateKey = DicomDemoSettingsManager.GetClientCertificateFullPath();
         settings.ClientPrivateKeyPassword = DicomDemoSettingsManager.GetClientCertificatePassword();

         settings.LogLowLevel = true;
         settings.ShowHelpOnStart = true;

         string sDefaultIP = string.Empty;
         try
         {
            sDefaultIP = GetDefaultIp();
         }
         catch (Exception)
         {
         }
      }

      private DicomDemoSettings DefaultSettings()
      {
         DicomDemoSettings settings = new DicomDemoSettings();
         settings.ClientAe.AE = defaultClientAE;
         settings.ClientAe.Port = defaultServerPort;
         DicomAE serverAE = new DicomAE();
         serverAE.AE = defaultServerAE;
         serverAE.IPAddress = defaultServerIP;
         serverAE.Port = defaultServerPort;
         serverAE.Timeout = defaultServerTimeout;
         serverAE.UseTls = defaultServerUseTls;
         settings.ServerList.Add(serverAE);
         SetOtherDefaults(settings);
         return settings;
      }

      private void LoadSettings()
      {
         _mySettings = null;
         try
         {
            _mySettings = DicomDemoSettingsManager.LoadSettings(_demoName);
            if (_mySettings == null)
            {
               DicomDemoSettingsManager.RunPacsConfigDemo();
               _mySettings = DicomDemoSettingsManager.LoadSettings(_demoName);
            }
         }
         catch (Exception)
         {
         }
         if (_mySettings == null)
         {
            _mySettings = DefaultSettings();
         }
         else
         {
            // found settings -- set any necessary defaults 
            if ((_mySettings.FirstRun && _mySettings.IsPreconfigured))
            {
               SetOtherDefaults(_mySettings);
            }
         }

         SetDefaultStoreServer();

         if (_mySettings.FileList == null)
            _mySettings.FileList = new List<string>();

         if (_mySettings.FileList.Count == 0 && _mySettings.FirstRun)
         {
            string sDir = DemosGlobal.ImagesFolder;
            string[] sFileList = { @"image1.dcm", @"image2.dcm", @"image3.dcm" };
            foreach (string sName in sFileList)
            {
               string sFile = sDir + "\\" + sName;
               if (File.Exists(sFile))
                  _mySettings.FileList.Add(sFile);
               DicomDemoSettingsManager.SaveSettings(_demoName, _mySettings);
            }
         }

         if (_mySettings.FileList.Count > 0)
         {
            DialogResult result = DialogResult.Yes;

            //if (_mySettings.FirstRun == false)
            //   result = MessageBox.Show(@"Do you want to add the DICOM files that were used previously?", @"Load DICOM files", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
               EnableCancel(true);

               // Get the count
               string sMsg = string.Empty;
               int totalCount = _mySettings.FileList.Count;
               int count = 0;
               int nMod = 1;

               LogText(@"Loading...", string.Empty);
               foreach (string sFile in _mySettings.FileList)
               {
                  if (LoadDicomFile(sFile))
                     count++;

                  if (totalCount > 20)
                     nMod = 10;

                  if (count % nMod == 0)
                  {
                     sMsg = string.Format(@"Loaded {0} of {1} files...", count.ToString(), totalCount.ToString());
                     LogText(string.Empty, _sTab + sMsg);
                     StatusText(sMsg);
                  }
                  Application.DoEvents();
               }
               sMsg = string.Format(@"Loaded {0} of {1} total files", count.ToString(), totalCount.ToString());
               LogText(string.Empty, _sTab + sMsg);
               StatusText(sMsg);
               EnableCancel(false);
            }
         }
         SizeColumns();
      }

      private void SaveSettings()
      {
         _mySettings.FileList.Clear();
         foreach (ListViewItem item in _listViewImages.Items)
         {
            try
            {
               _mySettings.FileList.Add(item.SubItems[5].Text);
            }
            catch (Exception ex)
            {
               Messager.ShowWarning(this, ex.Message);
            }
         }

         DicomDemoSettingsManager.SaveSettings(_demoName, _mySettings);
      }

      private void SetDefaultStoreServer()
      {
         DicomAE defaultAE = _mySettings.GetServer(_mySettings.DefaultStore);

         if (_comboBoxService.SelectedIndex >= 0)
            defaultAE = _mySettings.ServerList[_comboBoxService.SelectedIndex];

         if (null != defaultAE)
         {
            _server.AETitle = defaultAE.AE;
            _server.Port = (int)defaultAE.Port;
            _server.PeerAddress = IPAddress.Parse(defaultAE.IPAddress);
            _server.Timeout = defaultAE.Timeout;

            _textBoxServerIp.Text = _server.PeerAddress.ToString();
            _textBoxServerPort.Text = _server.Port.ToString();
         }
      }

      void UpdateDefaultServerAE()
      {
         if (_comboBoxService.Items.Count > 0)
         {
            _mySettings.DefaultStore = _comboBoxService.GetSelectedAETitle();

            DicomDemoSettingsManager.SaveSettings(_demoName, _mySettings);

            SetDefaultStoreServer();
         }
      }

      void SelectDefaultServerAE()
      {
         if (_comboBoxService.Items.Count > 0)
         {
            _comboBoxService.SetSelectedItem(_mySettings.DefaultStore);

            if (-1 == _comboBoxService.SelectedIndex && _comboBoxService.Items.Count > 0)
            {
               _comboBoxService.SelectedIndex = 0;
            }

            if (_comboBoxService.Items.Count > 0)
            {
               _mySettings.DefaultStore = _comboBoxService.GetSelectedAETitle();
            }
            else
            {
               _mySettings.DefaultStore = string.Empty;
            }
         }

         _comboBoxService.Enabled = (_comboBoxService.Items.Count > 0);
      }

      void UpdateComboBoxService()
      {
         _comboBoxService.Items.Clear();

         foreach (DicomAE myServer in _mySettings.ServerList)
         {
            _comboBoxService.Items.Add(myServer);
         }

         SelectDefaultServerAE();
      }

      bool GetDefaultUseTls()
      {
         bool useTls = false;
         DicomAE defaultAE = _mySettings.GetServer(_mySettings.DefaultStore);
         if (_comboBoxService.SelectedIndex >= 0)
            defaultAE = _mySettings.ServerList[_comboBoxService.SelectedIndex];

         if (defaultAE != null)
            useTls = defaultAE.UseTls;
         return useTls;
      }

      void CreateCStoreObject()
      {
         if (_cstore != null)
         {
            _cstore.Dispose();
         }
         bool useTls = GetDefaultUseTls();
         if (useTls)
         {
#if LEADTOOLS_V20_OR_LATER
            const DicomNetSecurityMode securityMode = DicomNetSecurityMode.Tls;
#else
            const DicomNetSecurityeMode securityMode = DicomNetSecurityeMode.Tls;
#endif

            _cstore = new MyStoreScu(this, string.Empty, securityMode, null);
         }
         else
         {
            _cstore = new MyStoreScu(this);
         }

         _cstore.MaxLength = 46726;
         _cstore.Compression = (Leadtools.Dicom.Scu.Common.Compression)_mySettings.Compression;
         _cstore.ImplementationClass = _sConfigurationImplementationClass;
         _cstore.ImplementationVersionName = _sConfigurationImplementationVersionName;
         _cstore.ProtocolVersion = _sConfigurationProtocolVersion;
         //_cstore.EnableDebugLog = false;
#if LEADTOOLS_V19_OR_LATER
         _cstore.Flags = DicomNetFlags.None;
         if (_mySettings.GroupLengthDataElements)
         {
            _cstore.Flags |= DicomNetFlags.SendDataWithGroupLengthStandardDataElements;
         }
#endif

         // Subscribe to events for logging
         _cstore.BeforeConnect += new Leadtools.Dicom.Scu.Common.BeforeConnectDelegate(_cstore_BeforeConnect);
         _cstore.AfterConnect += new Leadtools.Dicom.Scu.Common.AfterConnectDelegate(_cstore_AfterConnect);
         _cstore.AfterSecureLinkReady += new Leadtools.Dicom.Scu.Common.AfterSecureLinkReadyDelegate(_cstore_AfterSecureLinkReady);
         _cstore.BeforeAssociateRequest += new Leadtools.Dicom.Scu.Common.BeforeAssociationRequestDelegate(_cstore_BeforeAssociateRequest);
         _cstore.AfterAssociateRequest += new Leadtools.Dicom.Scu.Common.AfterAssociateRequestDelegate(_cstore_AfterAssociateRequest);
         _cstore.BeforeReleaseRequest += new EventHandler(_cstore_BeforeAssociateRelease);
         _cstore.AfterReleaseRequest += new EventHandler(_cstore_AfterAssociateRelease);
         _cstore.BeforeClose += new EventHandler(_cstore_BeforeClose);
         _cstore.AfterClose += new EventHandler(_cstore_AfterClose);
         _cstore.BeforeCStore += new Leadtools.Dicom.Scu.Common.BeforeCStoreDelegate(_cstore_BeforeCStore);
         _cstore.AfterCStore += new Leadtools.Dicom.Scu.Common.AfterCStoreDelegate(_cstore_AfterCStore);
         _cstore.PrivateKeyPassword += new Leadtools.Dicom.Scu.Common.PrivateKeyPasswordDelegate(_cstore_PrivateKeyPassword);

#if LEADTOOLS_V19_OR_LATER
         _cstore.BeforeNAction += new EventHandler<Leadtools.Dicom.Scu.Common.BeforeNActionEventArgs>(_cstore_BeforeNAction);
         _cstore.AfterNAction += new EventHandler<Leadtools.Dicom.Scu.Common.AfterNActionEventArgs>(_cstore_AfterNAction);
         _cstore.StorageCommitmentResult += new EventHandler<Leadtools.Dicom.Scu.Common.StorageCommitmentResultEventArgs>(_cstore_StorageCommitmentResult);
         _cstore.StorageCommitmentWait += new EventHandler<StorageCommitmentWaitEventArgs>(_cstore_StorageCommitmentWait);
#endif

         if (useTls)
         {
            try
            {
               SetCipherSuites(_cstore);
               _cstore.SetTlsClientCertificate(
                  _mySettings.ClientCertificate,
                  DicomTlsCertificateType.Pem,
                  _mySettings.ClientPrivateKey.Length > 0 ? _mySettings.ClientPrivateKey : null);
            }
            catch (Exception ex)
            {
               LogError(ex.Message);
            }
         }

         if (_mySettings.LogLowLevel && !_mySettings.DisableLogging)
         {
            if (_tracer == null)
            {
               _tracer = new TextBoxTraceListener(_richTextBoxLog);
               Trace.Listeners.Add(_tracer);
            }
         }
         else
         {
            if (_tracer != null)
            {
               Trace.Listeners.Remove(_tracer);
               _tracer = null;
            }
         }

         _cstore.DebugLogFilename = string.Empty;
         if (_mySettings.DisableLogging)
         {
            _cstore.EnableDebugLog = true;
         }
         else
         {
            _cstore.EnableDebugLog = false;
         }

         SetDefaultStoreServer();
      }

      void _cstore_PrivateKeyPassword(object sender, Leadtools.Dicom.Scu.Common.PrivateKeyPasswordEventArgs e)
      {
         e.PrivateKeyPassword = _mySettings.ClientPrivateKeyPassword;
      }

      private void MainForm_Closing(object sender, FormClosingEventArgs e)
      {
#if LEADTOOLS_V19_OR_LATER
         _cstore.StopListener();
#endif
         _closing = true;
         if (_cstore != null && _cstore.IsConnected())
         {
            _cstore.CloseForced(true);
         }
         SaveSettings();
      }

      void _cstore_BeforeConnect(object sender, Leadtools.Dicom.Scu.Common.BeforeConnectEventArgs e)
      {
         LogText(@"Before Connect", e.Scp.ToString());
         e.PrivateKeyPassword = _mySettings.ClientPrivateKeyPassword;
      }

      void _cstore_AfterConnect(object sender, Leadtools.Dicom.Scu.Common.AfterConnectEventArgs e)
      {
         string message;
         if (e.Error == DicomExceptionCode.Success)
         {
            message = _sNewlineTab + @"Connection Successful";
         }
         else
         {
            message =
               _sNewlineTab + @"Connection Failed" +
               _sNewlineTab + "Error:\t" + e.Error.ToString();
         }

         LogText(@"After Connect", message);
      }

      void _cstore_AfterSecureLinkReady(object sender, Leadtools.Dicom.Scu.Common.AfterSecureLinkReadyEventArgs e)
      {
         DicomNet net = (DicomNet)sender;
         if (net != null)
         {
            DicomTlsCipherSuiteType cipher = net.GetTlsCipherSuite();
            string message;
            if (e.Error == DicomExceptionCode.Success)
            {
               message = _sNewlineTab + "Secure Link Ready" + _sNewlineTab + "Cipher Suite: " + cipher.GetCipherFriendlyName();
            }
            else
            {
               message =
                  _sNewlineTab + "Secure Link Failed" +
                  _sNewlineTab + "Error:\t" + e.Error.ToString();
            }

            LogText("After Secure Link Ready", message);
         }
      }

      void _cstore_BeforeAssociateRequest(object sender, Leadtools.Dicom.Scu.Common.BeforeAssociateRequestEventArgs e)
      {
         LogText(@"Before Associate Request", e.Associate.ToString());
      }

      void _cstore_AfterAssociateRequest(object sender, Leadtools.Dicom.Scu.Common.AfterAssociateRequestEventArgs e)
      {
         string message;
         if (e.Rejected)
         {
            message =
               _sNewlineTab + @"Association Rejected" +
               _sNewlineTab + @"Result: " + e.Result.ToString() +
               _sNewlineTab + @"Reason: " + e.Reason.ToString() +
               _sNewlineTab + @"Source: " + e.Source.ToString();
         }
         else
         {
            if (e.Associate != null)
               message = _sNewlineTab + @"Association Accepted" + e.Associate.ToString();
            else
               message = _sNewlineTab + @"Association Accepted";
         }
         LogText(@"After Associate Request", message);
      }

      void _cstore_BeforeAssociateRelease(object sender, EventArgs e)
      {
         LogText(@"Before Associate Release", string.Empty);
      }

      void _cstore_AfterAssociateRelease(object sender, EventArgs e)
      {
         LogText(@"After Associate Release", string.Empty);
      }

      void _cstore_BeforeClose(object sender, EventArgs e)
      {
         LogText(@"Before Close", string.Empty);
      }

      void _cstore_AfterClose(object sender, EventArgs e)
      {
         LogText(@"After Close", string.Empty);
      }

      void _cstore_BeforeCStore(object sender, Leadtools.Dicom.Scu.Common.BeforeCStoreEventArgs e)
      {
         string message = _sNewlineTab +
         @"Filename: " + e.FileInfo.FullName + _sNewlineTab +
         @"Message ID: " + e.MessageId + _sNewlineTab +
         @"Presentation ID: " + e.PresentationID + _sNewlineTab +
         @"Affected Class: " + e.AffectedClass + _sNewlineTab +
         @"Priority:" + e.Priority.ToString();

         LogText(@"Before CStore", message);
      }

      void _cstore_AfterCStore(object sender, Leadtools.Dicom.Scu.Common.AfterCStoreEventArgs e)
      {
         string message;
         if (e.Status == DicomCommandStatusType.Success)
         {
            message =
               _sNewlineTab + @"Success" +
               _sNewlineTab + @"Filename: " + e.FileInfo.FullName;
         }
         else
         {
            message =
               _sNewlineTab + @"CStore Failed" +
               _sNewlineTab + @"Status: " + e.Status.ToString();
         }
         LogText(@"After CStore", message);
      }

#if LEADTOOLS_V19_OR_LATER
      void _cstore_BeforeNAction(object sender, Leadtools.Dicom.Scu.Common.BeforeNActionEventArgs e)
      {
         string message = _sNewlineTab +
         @"Message ID: " + e.MessageID + _sNewlineTab +
         @"Presentation ID: " + e.PresentationID + _sNewlineTab +
         @"Affected Class: " + e.AffectedClass + _sNewlineTab +
         @"Instance: " + e.Instance + _sNewlineTab +
         @"Action Type:" + e.ActionType.ToString();

         LogText(@"Before NAction", message);
      }

      void _cstore_AfterNAction(object sender, Leadtools.Dicom.Scu.Common.AfterNActionEventArgs e)
      {
         string message;
         if (e.Status == DicomCommandStatusType.Success)
         {
            message =
               _sNewlineTab + @"Success" +
               "";
            //"_sNewlineTab + @"Filename: " + e.FileInfo.FullName;
         }
         else
         {
            message =
               _sNewlineTab + @"NAction Failed" +
               _sNewlineTab + @"Status: " + e.Status.ToString();
         }
         LogText(@"After NAction", message);
      }

      static string AppendNewlineString(string original, string name, string result, int tabcount)
      {
         if (string.IsNullOrEmpty(result))
         {
            return original;
         }

         string ret = original + Environment.NewLine;
         for (int i = 0; i < tabcount; i++)
         {
            ret += _sTab;
         }
         ret += (name + result);
         return ret;
      }

      static string GetPatientInfo(Dictionary<string, PatientInformation> sopPatientList, string sopInstanceUid)
      {
         string result = string.Empty;
         PatientInformation p;
         if (sopPatientList.TryGetValue(sopInstanceUid, out p))
         {
            result = string.Format(@"{0} ({1}) {2}", p.PatientName, p.PatientId, Path.GetFileName(p.FileName));
         }
         return result;
      }

      void _cstore_StorageCommitmentWait(object sender, StorageCommitmentWaitEventArgs e)
      {
         MyStoreScu scu = sender as MyStoreScu;
         if (scu != null && scu.ActiveScp != null && scu.ActiveScp.Association != null)
         {
            string implementationVersionName = scu.ActiveScp.Association.ImplementationVersionName;
            if (string.Compare(implementationVersionName, @"LT_PACS_DEMO", true) == 0)
            {
               e.Options = StoreScu.StorageCommitOptions.WaitForResultsThenClose;
            }
         }
      }

      public delegate void _cstore_StorageCommitmentResultDelegate(object sender, Leadtools.Dicom.Scu.Common.StorageCommitmentResultEventArgs e);

      void _cstore_StorageCommitmentResult(object sender, Leadtools.Dicom.Scu.Common.StorageCommitmentResultEventArgs e)
      {
         if (InvokeRequired)
         {
            Invoke(new _cstore_StorageCommitmentResultDelegate(_cstore_StorageCommitmentResult), sender, e);
            return;
         }
         Dictionary<string, PatientInformation> sopPatientList = new Dictionary<string, PatientInformation>();
         foreach (ListViewItem item in _listViewImages.CheckedItems)
         {
            string patientName = item.SubItems[0].Text;
            string patientId = item.SubItems[1].Text;
            string imagePath = item.SubItems[5].Text;
            string sopInstanceUid = item.SubItems[6].Text;
            sopPatientList.Add(sopInstanceUid, new PatientInformation(patientName, patientId, imagePath));
         }


         string message = _sNewlineTab + @"TransactionUID: " + e.Result.TransactionUID;
         message = AppendNewlineString(message, @"RetrieveAETitle: ", e.Result.RetrieveAETitle, 1);
         message = AppendNewlineString(message, @"StorageMediaFileSetID: ", e.Result.StorageMediaFileSetID, 1);
         message = AppendNewlineString(message, @"StorageMediaFileSetUID: ", e.Result.StorageMediaFileSetUID, 1);

         int successes = (e.Result.ReferencedSOPSequence != null) ? e.Result.ReferencedSOPSequence.Count : 0;
         int failures = (e.Result.FailedSOPSequence != null) ? e.Result.FailedSOPSequence.Count : 0;
         int total = successes + failures;

         if (successes > 0 && e.Result.ReferencedSOPSequence != null)
         {
            message += string.Format(@"{0}Successes ({1} of {2}):{{Green}}", _sNewlineTab, successes, total);
            int count = 0;
            foreach (SCSOPInstanceReference sop in e.Result.ReferencedSOPSequence)
            {
               count++;
               message += _sNewlineTabTab + count;
               message = AppendNewlineString(message, string.Empty, GetPatientInfo(sopPatientList, sop.ReferencedSopInstanceUid), 3);
               message = AppendNewlineString(message, @"RetrieveAETitle: ", sop.RetrieveAETitle, 3);
               //message = AppendNewlineString(message, @"StorageMediaFileSetID: ", sop.StorageMediaFileSetID, 3);
               //message = AppendNewlineString(message, @"StorageMediaFileSetUID: ", sop.StorageMediaFileSetUID, 3);
               //message = AppendNewlineString(message, @"ReferencedSopClassUid: ", sop.ReferencedSopClassUid, 3);
               message = AppendNewlineString(message, @"ReferencedSopInstanceUid: ", sop.ReferencedSopInstanceUid, 3);
            }
         }

         if (failures > 0 && e.Result.FailedSOPSequence != null)
         {
            message += string.Format(@"{0}Failures ({1} of {2}):{{Red}}", _sNewlineTab, failures, total);
            int count = 0;
            foreach (SCFailedSOPInstanceReference sop in e.Result.FailedSOPSequence)
            {
               count++;
               message += _sNewlineTabTab + count;
               message = AppendNewlineString(message, string.Empty, GetPatientInfo(sopPatientList, sop.ReferencedSopInstanceUid), 3);
               //message = AppendNewlineString(message, @"ReferencedSopClassUid: ", sop.ReferencedSopClassUid, 3);
               message = AppendNewlineString(message, @"ReferencedSopInstanceUid: ", sop.ReferencedSopInstanceUid, 3);
            }
         }

         LogText(@"Storage Commitment Result", message);

         EnableCancel(false);
      }
#endif // #if LEADTOOLS_V19_OR_LATER


      // Logging
      private void AppendTextColor(string text, Color color)
      {
         Color oldColor = _richTextBoxLog.SelectionColor;

         _richTextBoxLog.SelectionLength = text.Length;
         _richTextBoxLog.SelectionStart = _richTextBoxLog.Text.Length;
         _richTextBoxLog.SelectionColor = color;
         _richTextBoxLog.SelectionFont = new Font(_richTextBoxLog.SelectionFont, FontStyle.Bold);
         _richTextBoxLog.AppendText(text);
         _richTextBoxLog.SelectionColor = oldColor;
         _richTextBoxLog.ScrollToCaret();
      }

      private void AddAction(string sAction, Color color)
      {
         if (sAction.Length > 0)
         {
            sAction = Environment.NewLine + sAction;
            Color oldColor = _richTextBoxLog.SelectionColor;
            _richTextBoxLog.SelectionLength = sAction.Length;
            _richTextBoxLog.SelectionStart = _richTextBoxLog.Text.Length;
            _richTextBoxLog.SelectionColor = color;
            _richTextBoxLog.SelectionFont = new Font(_richTextBoxLog.SelectionFont, FontStyle.Bold);
            _richTextBoxLog.AppendText(sAction + ": ");
            _richTextBoxLog.SelectionColor = oldColor;
            _richTextBoxLog.ScrollToCaret();
         }
      }

      public string RemoveColorToken(string s, out Color color)
      {
         color = Color.Empty;
         string line = s;
         Color[] colors = new[] { Color.Red, Color.Green };

         foreach (Color colorToCheck in colors)
         {
            string colorFormat = string.Format("{{{0}}}", colorToCheck.Name);
            if (line.EndsWith(colorFormat))
            {
               line = line.Remove(line.Length - colorFormat.Length);
               color = colorToCheck;
            }
         }
         return Environment.NewLine + line;
      }

      public void LogText(string sAction, string sLogText, Color sActionColor)
      {
         if (_mySettings.DisableLogging)
            return;

         if (_closing)
            return;

         try
         {
            if (this.InvokeRequired)
            {
               this.Invoke(new AddLog(LogText), new object[] { sAction, sLogText, sActionColor });
            }
            else
            {
               AddAction(sAction, sActionColor);
               if (sActionColor == Color.Green)
               {
                  AppendTextColor(sLogText, sActionColor);
               }
               else
               {
                  char[] splitChars = new[] { '\n', '\r' };
                  string[] lines = sLogText.Split(splitChars, StringSplitOptions.RemoveEmptyEntries);
                  foreach (string line in lines)
                  {
                     Color color;
                     string lineNew = RemoveColorToken(line, out color);
                     AppendTextColor(lineNew, color);
                  }
               }
               TextBoxTraceListener.SendMessage(_richTextBoxLog.Handle, TextBoxTraceListener.WM_VSCROLL, TextBoxTraceListener.SB_BOTTOM, 0);
            }
         }
         catch (Exception)
         {
         }
         finally
         {
         }
      }

      public void LogText(string sAction, string sLogText)
      {
         if (_mySettings.DisableLogging)
            return;

         LogText(sAction, sLogText, Color.Blue);
         Application.DoEvents();
      }

      public void LogError(string sLogText)
      {
         if (_mySettings.DisableLogging)
            return;

         // If cancelling, do not log any errors that might result from the cancel
         if (_cancel)
            return;
         LogText(@"*** ERROR *** ", _sNewlineTab + sLogText, Color.Red);
      }

      private void _listViewImages_DragDrop(object sender, DragEventArgs e)
      {
         if (e.Data.GetDataPresent(DataFormats.FileDrop))
         {
            string[] myFiles = (string[])e.Data.GetData(DataFormats.FileDrop);
            Cursor = Cursors.WaitCursor;
            EnableCancel(true);
            foreach (string sFile in myFiles)
            {
               LoadDicomFile(sFile);
               Application.DoEvents();
            }
            EnableCancel(false);
            Cursor = Cursors.Default;
         }
         SizeColumns();
      }

      private void _listViewImages_DragEnter(object sender, DragEventArgs e)
      {

         if (e.Data.GetDataPresent(DataFormats.FileDrop))
            e.Effect = DragDropEffects.Copy;
         else
            e.Effect = DragDropEffects.None;
      }


      bool LoadDicomFile(string filename)
      {
         if (_cancel)
            return false;

         bool succeeded = true;

         using (DicomDataSet ds = new DicomDataSet())
         {
            ListViewItem item = null;
            string strTransferSyntax = string.Empty;

            try
            {
               this.Cursor = Cursors.WaitCursor;
               ds.Load(filename, DicomDataSetLoadFlags.None);
               item = _listViewImages.Items.Add(ds.GetValue<string>(DicomTag.PatientName, string.Empty));
               item.SubItems.Add(ds.GetValue<string>(DicomTag.PatientID, string.Empty));
               item.SubItems.Add(ds.GetValue<string>(DicomTag.StudyID, string.Empty));
               item.SubItems.Add(ds.GetValue<string>(DicomTag.Modality, string.Empty));

               strTransferSyntax = @"Implicit VR - Little Endian";

               DicomElement element = ds.FindFirstElement(null, DicomTag.TransferSyntaxUID, false);
               if (element != null && ds.GetElementValueCount(element) > 0)
               {
                  string uidString = ds.GetValue<string>(element, string.Empty);
                  DicomUid uid = DicomUidTable.Instance.Find(uidString);
                  if (uid != null)
                  {
                     strTransferSyntax = uid.Name;
                  }
               }
            }
            catch (DicomException de)
            {
               LogText(@"Dicom error: " + de.Code.ToString(), filename);
               succeeded = false;
            }

            if (succeeded)
            {
               // Mark item read if we have a basic directory
               if (ds.InformationClass == DicomClassType.BasicDirectory)
               {
                  item.Font = new Font(_listViewImages.Font, FontStyle.Bold);
               }

               item.SubItems.Add(strTransferSyntax);
               item.SubItems.Add(filename);
               item.SubItems.Add(ds.GetValue<string>(DicomTag.SOPInstanceUID, string.Empty));

               item.Checked = true;
            }
         }
         this.Cursor = Cursors.Default;
         return succeeded;
      }

      private void LoadDicomDir(string filename)
      {
         if (_cancel)
            return;

         DicomDataSet ds = new DicomDataSet();
         string refFilename = string.Empty;
         DicomElement element = null;
         int count = 0;
         int totalCount = 0;
         int nMod = 10;
         string sMsg = string.Empty;


         if (!filename.ToUpper().Contains("DICOMDIR"))
            return;

         string pathname = Path.GetDirectoryName(filename) + "\\";
         try
         {
            this.Cursor = Cursors.WaitCursor;
            ds.Load(filename, DicomDataSetLoadFlags.None);

            // Get the total count
            element = ds.FindFirstElement(null, DicomTag.ReferencedFileID, false);
            while (element != null)
            {
               totalCount++;
               element = ds.FindNextElement(element, false);
            }

            if (totalCount > 20)
               nMod = 10;

            // now get the datasets
            element = ds.FindFirstElement(null, DicomTag.ReferencedFileID, false);
            if (element != null && ds.GetElementValueCount(element) > 0)
            {
               if (!_cancel)
               {
                  LogText(@"Loading DICOMDIR", string.Empty);
                  refFilename = ds.GetConvertValue(element);
                  if (LoadDicomFile(pathname + refFilename))
                     count++;
                  Application.DoEvents();
               }
            }

            while ((refFilename.Length > 0) && (!_cancel))
            {
               element = ds.FindNextElement(element, false);
               if (element != null && ds.GetElementValueCount(element) > 0)
               {
                  refFilename = ds.GetConvertValue(element);
                  if (LoadDicomFile(pathname + refFilename))
                     count++;
                  Application.DoEvents();
               }
               else
                  refFilename = string.Empty;
               if (count % nMod == 0)
               {
                  sMsg = string.Format(@"Loaded {0} of {1} files...", count.ToString(), totalCount.ToString());
                  LogText(string.Empty, _sTab + sMsg);
                  StatusText(sMsg);
               }
            }
         }
         catch (DicomException de)
         {
            LogText(@"Dicom error: " + de.Code.ToString(), filename);
         }
         sMsg = string.Format(@"Loaded {0} of {1} total files", count.ToString(), totalCount.ToString());
         LogText(string.Empty, _sTab + sMsg);
         StatusText(sMsg);
         this.Cursor = Cursors.Default;
      }


      private void addDICOMDIRToolStripMenuItem_Click(object sender, EventArgs e)
      {
         _openFileDialog.Multiselect = true;
         _openFileDialog.Title = @"Add DICOM Dir";
         _openFileDialog.Filter = @"All Files|*.*";
         _openFileDialog.FileName = @"DICOMDIR";
         if (_openFileDialog.ShowDialog() == DialogResult.OK)
         {
            EnableCancel(true);
            foreach (string file in _openFileDialog.FileNames)
            {
               LoadDicomDir(file);
            }
            EnableCancel(false);
         }
         SizeColumns();
      }

      private void SizeColumns()
      {
         if (_listViewImages.Items.Count > 0)
         {
            // Size to content
            foreach (ColumnHeader header in _listViewImages.Columns)
            {
               if (header.Text.Contains(@"Modality"))
                  header.AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
               else if (header.Text.Contains(@"Transfer Syntax"))
                  header.AutoResize(ColumnHeaderAutoResizeStyle.None);
               else
                  header.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
            }
         }
         else
         {
            // size to header
            foreach (ColumnHeader header in _listViewImages.Columns)
               header.AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
         }
      }

      private void splitContainer1_Panel2_Resize(object sender, EventArgs e)
      {
      }

      private void _listViewImages_Resize(object sender, EventArgs e)
      {
      }

      DialogResult DoOptions()
      {
         OptionsDialog options = new OptionsDialog();
         options.ServerList = _mySettings.ServerList;


         options.ClientAE = _mySettings.ClientAe.AE;
         options.ClientPort = _mySettings.ClientAe.Port;
         options.Compression = (Leadtools.Dicom.Scu.Common.Compression)_mySettings.Compression;
         options.ClientCertificate = _mySettings.ClientCertificate;
         options.PrivateKey = _mySettings.ClientPrivateKey;
         options.PrivateKeyPassword = _mySettings.ClientPrivateKeyPassword;
         options.LogLowLevel = _mySettings.LogLowLevel;
         options.GroupLengthDataElements = _mySettings.GroupLengthDataElements;
         options.DisableLogging = _mySettings.DisableLogging;
         options.StorageCommitResultsOnSameAssociation = _mySettings.StorageCommitResultsOnSameAssociation;
         options.CipherSuites = _mySettings.CipherSuites;

         DialogResult dr = options.ShowDialog(this);
         if (dr == DialogResult.OK)
         {
            _mySettings.ServerList = options.ServerList;
            _mySettings.ClientAe.AE = options.ClientAE;
            _mySettings.ClientAe.Port = Convert.ToInt32(options.ClientPort);
            _mySettings.Compression = (int)options.Compression;
            _mySettings.ClientCertificate = options.ClientCertificate;
            _mySettings.ClientPrivateKey = options.PrivateKey;
            _mySettings.ClientPrivateKeyPassword = options.PrivateKeyPassword;
            _mySettings.LogLowLevel = options.LogLowLevel;
            _mySettings.GroupLengthDataElements = options.GroupLengthDataElements;
            _mySettings.DisableLogging = options.DisableLogging;
            _mySettings.StorageCommitResultsOnSameAssociation = options.StorageCommitResultsOnSameAssociation;
            _mySettings.CipherSuites = options.CipherSuites;

            DicomDemoSettingsManager.SaveSettings(_demoName, _mySettings);
            UpdateComboBoxService();
            EnableCancel(false);
         }
         return dr;
      }

      private void StatusText(string s)
      {
         _labelStatus.Text = s;
         Application.DoEvents();
      }

      private void DoStore()
      {
         DicomAE defaultServer = DefaultServer();
         if (string.IsNullOrEmpty(defaultServer.AE))
            return;

         EnableCancel(true);

         _server.AETitle = defaultServer.AE;
         _server.PeerAddress = IPAddress.Parse(defaultServer.IPAddress);
         _server.Port = defaultServer.Port;
         _server.Timeout = defaultServer.Timeout;

         // Get total count
         int count = 0;
         string sMsg = string.Empty;

         StatusText(@"Getting Total Count of images to store...");
         int totalCount = _listViewImages.CheckedItems.Count;

         sMsg = string.Format(@"Total images to store: {0}", totalCount);
         StatusText(sMsg);

         bool bShowImportantMessage = false;
         foreach (ListViewItem item in _listViewImages.CheckedItems)
         {
            if (!_cancel)
            {
               _cstore.AETitle = _mySettings.ClientAe.AE;
               _cstore.HostPort = _mySettings.ClientAe.Port;
               count++;

               sMsg = string.Format(@"Storing {0} of {1} files", count, totalCount);
               StatusText(sMsg);

               Thread t = new Thread(delegate ()
               {
                  try
                  {
                     _cstore.Store(_server, item.SubItems[5].Text);
                  }
                  catch (Exception ex)
                  {
                     LogError(ex.Message);
                     if (string.Compare(ex.Message, @"The attempt to connect was forcefully rejected", true) == 0)
                     {
                        if (_mySettings.IsPreconfigured)
                        {
                           bShowImportantMessage = true;
                        }
                     }
                  }
               });

               t.Start();
               while (t.IsAlive)
               {
                  Application.DoEvents();
                  if (_closing)
                  {
                     t.Abort();
                     break;
                  }
               }

               StatusText(sMsg);
            }
         }
         //string 
         if (bShowImportantMessage)
         {
            ShowImportantMessage();
         }
         EnableCancel(false);
      }

      delegate void EnableCancelDelegate(bool bEnable);

      private void EnableCancel(bool bEnable)
      {
         if (this.InvokeRequired)
         {
            EnableCancelDelegate d = new EnableCancelDelegate(EnableCancel);
            this.Invoke(d, new object[] { bEnable });
            return;
         }
         addDICOMToolStripMenuItem.Enabled = !bEnable;
         addDICOMDIRToolStripMenuItem.Enabled = !bEnable;
         removeSelectedToolStripMenuItem.Enabled = !bEnable;
         removeAllToolStripMenuItem.Enabled = !bEnable;
         optionsToolStripMenuItem.Enabled = !bEnable;
         clearLogToolStripMenuItem.Enabled = !bEnable;
         storeToolStripMenuItem.Enabled = !bEnable;
         exitToolStripMenuItem.Enabled = !bEnable;
         aboutToolStripMenuItem.Enabled = !bEnable;
         _buttonOptions.Enabled = !bEnable;
         _buttonStore.Enabled = !bEnable && (_mySettings.ServerList != null) && (_mySettings.ServerList.Count > 0);
         _buttonStorageCommit.Enabled = !bEnable && (_mySettings.ServerList != null) && (_mySettings.ServerList.Count > 0);
         //_buttonExit.Enabled = !bEnable;
         _listViewImages.Enabled = !bEnable;

         cancelToolStripMenuItem.Enabled = bEnable;
         _buttonCancel.Enabled = bEnable;

         if (bEnable == false)
         {
            if (_cancel)
            {
               LogText(@"Cancelled", "");
               _cancel = false;
            }
         }
      }

      private void DoCancel()
      {
         _cancel = true;
         Thread.Sleep(1000);
         if (_cstore != null)
         {
            _cstore.Dispose();
            _cstore = null;
         }
         CreateCStoreObject();
         EnableCancel(true);

      }


      private void MainForm_Shown(object sender, EventArgs e)
      {
         LoadSettings();
         CreateCStoreObject();
         UpdateComboBoxService();

         if (_firstTime && _mySettings.ShowHelpOnStart)
         {
            _firstTime = false;
            HelpDialog dlg = new HelpDialog(DefaultServer().AE, _mySettings.ShowHelpOnStart);
            dlg.ShowDialog(this);
            if (dlg.CheckBoxNoShowAgainResult)
            {
               _mySettings.ShowHelpOnStart = false;
               DicomDemoSettingsManager.SaveSettings(_demoName, _mySettings);
            }
         }

         _mySettings.FirstRun = false;
         DicomDemoSettingsManager.SaveSettings(_demoName, _mySettings);
      }

      private void RemoveAll()
      {
         foreach (ListViewItem item in _listViewImages.Items)
         {
            item.Remove();
         }
      }

      private void RemoveSelected()
      {
         foreach (ListViewItem item in _listViewImages.Items)
         {
            if (item.Selected)
               item.Remove();
         }
      }

      private void addDICOMToolStripMenuItem_Click(object sender, EventArgs e)
      {
         _openFileDialog.Multiselect = true;
         _openFileDialog.Title = @"Add DICOM File";
         _openFileDialog.Filter = @"DICOM Files (*.dcm;*.dic)|*.dcm;*.dic|All files (*.*)|*.*";
         _openFileDialog.FileName = string.Empty;
         int count = 0;
         int totalCount = 0;
         int nMod = 1;
         string sMsg = string.Empty;
         if (_openFileDialog.ShowDialog() == DialogResult.OK)
         {
            EnableCancel(true);
            totalCount = _openFileDialog.FileNames.Length;
            if (totalCount > 20)
               nMod = 10;
            LogText(@"Loading...", string.Empty);
            foreach (string file in _openFileDialog.FileNames)
            {
               if (LoadDicomFile(file))
               {
                  count++;
                  if (count % nMod == 0)
                  {
                     sMsg = string.Format(@"Loaded {0} of {1} files...", count.ToString(), totalCount.ToString());
                     LogText(string.Empty, _sTab + sMsg);
                     StatusText(sMsg);
                  }
               }
               Application.DoEvents();
            }
            EnableCancel(false);
            sMsg = string.Format(@"Loaded {0} of {1} files", count.ToString(), totalCount.ToString());
            LogText(string.Empty, _sTab + sMsg);
            StatusText(sMsg);
         }
         SizeColumns();
      }

      private void clearLogToolStripMenuItem_Click(object sender, EventArgs e)
      {
         _richTextBoxLog.Clear();
      }

      private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
      {
         AboutDialog dlg = new AboutDialog("DICOM High Level Store");
         dlg.ShowDialog(this);
      }

      private void clearLogToolStripMenuItem1_Click(object sender, EventArgs e)
      {
         _richTextBoxLog.Clear();
      }

      private void removeSelectedToolStripMenuItem_Click(object sender, EventArgs e)
      {
         RemoveSelected();
      }

      private void _toolStripMenuItemRemoveSelected_Click(object sender, EventArgs e)
      {
         RemoveSelected();
      }

      private void removeAllToolStripMenuItem_Click(object sender, EventArgs e)
      {
         RemoveAll();
      }
      private void _toolStripMenuItemRemoveAll_Click(object sender, EventArgs e)
      {
         RemoveAll();
      }

      private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
      {
         // Check if the options have changed
         if (DialogResult.OK == DoOptions())
            CreateCStoreObject();
      }

      private void _buttonOptions_Click(object sender, EventArgs e)
      {
         // Check if the options have changed
         if (DialogResult.OK == DoOptions())
            CreateCStoreObject();
      }

      private void storeToolStripMenuItem_Click(object sender, EventArgs e)
      {
         DoStore();
      }

      private void _buttonStore_Click(object sender, EventArgs e)
      {
         DoStore();
      }

      private void cancelToolStripMenuItem_Click(object sender, EventArgs e)
      {
         DoCancel();
      }

      private void _buttonCancel_Click(object sender, EventArgs e)
      {
         DoCancel();
      }

      private void _buttonExit_Click(object sender, EventArgs e)
      {
         Application.Exit();
      }

      private DicomAE DefaultServer()
      {
         DicomAE ret = _mySettings.GetServer(_mySettings.DefaultStore);
         if (null == ret)
            ret = new DicomAE();
         return ret;
      }

      private void showHelpToolStripMenuItem_Click(object sender, EventArgs e)
      {
         HelpDialog dlg = new HelpDialog(DefaultServer().AE, false);
         dlg.ShowDialog(this);
      }

      private void _comboBoxService_SelectionChangeCommitted(object sender, EventArgs e)
      {
         UpdateDefaultServerAE();
         CreateCStoreObject();
      }

      private void exitToolStripMenuItem_Click(object sender, EventArgs e)
      {
         Application.Exit();
      }

      private void SetCipherSuites(DicomNet scu)
      {
         // Zero out the CipherSuite list
         scu.SetTlsCipherSuiteByIndex(0, DicomTlsCipherSuiteType.None);

         // Add the new CipherSuites in order of priority
         int cipherCount = 0;
         foreach (CipherSuiteItem cipherSuiteItem in _mySettings.CipherSuites.ItemList)
         {
            if (cipherSuiteItem.IsChecked)
            {
               scu.SetTlsCipherSuiteByIndex(cipherCount, cipherSuiteItem.Cipher);
               cipherCount++;
            }
         }
      }

#if LEADTOOLS_V19_OR_LATER
      private void StorageCommit()
      {
         DicomAE defaultServer = DefaultServer();
         if (string.IsNullOrEmpty(defaultServer.AE))
            return;

         _server.AETitle = defaultServer.AE;
         _server.PeerAddress = IPAddress.Parse(defaultServer.IPAddress);
         _server.Port = defaultServer.Port;
         _server.Timeout = defaultServer.Timeout;

         // Get total count
         StatusText(@"Getting Total Count of Storage Commit instances...");
         List<string> storageCommitList = (from ListViewItem item in _listViewImages.CheckedItems select item.SubItems[5].Text).ToList();
         int totalCount = storageCommitList.Count;
         string sMsg = string.Format(@"Total Storage Commit Instances: {0}", totalCount);
         StatusText(sMsg);

         if (totalCount <= 0)
            return;

         bool bShowImportantMessage = false;

         if (!_cancel)
         {
            _cstore.AETitle = _mySettings.ClientAe.AE;
            _cstore.HostPort = _mySettings.ClientAe.Port;

            Thread t = new Thread(delegate ()
            {
               try
               {
                  StoreScu.StorageCommitOptions options = StoreScu.StorageCommitOptions.None;

                  if (_mySettings.StorageCommitResultsOnSameAssociation)
                  {
                     options = StoreScu.StorageCommitOptions.WaitForResultsThenClose;
                  }
                  else
                  {
                     options = StoreScu.StorageCommitOptions.NoWaitForResults;
                  }
                  _cstore.StorageCommit(_server, storageCommitList, string.Empty, options);

                  Console.WriteLine(@"Finished");

               }
               catch (Exception ex)
               {
                  LogError(ex.Message);
                  if (string.Compare(ex.Message, @"The attempt to connect was forcefully rejected", true) == 0)
                  {
                     if (_mySettings.IsPreconfigured)
                     {
                        bShowImportantMessage = true;
                     }
                  }
               }
            });

            t.Start();
            while (t.IsAlive)
            {
               Application.DoEvents();
               if (_closing)
               {
                  t.Abort();
                  break;
               }
            }

            StatusText(sMsg);
         }


         if (bShowImportantMessage)
         {
            ShowImportantMessage();
         }
      }

      private void DoStorageCommit()
      {
         EnableCancel(true);
         try
         {
            StorageCommit();
         }
         finally
         {
            EnableCancel(false);
         }
      }
#endif // #if LEADTOOLS_V19_OR_LATER

      public void ShowImportantMessage()
      {
         string serverManagerDemo = "CSLeadtools.Dicom.Server.Manager.exe";
         string sImportant = string.Format("\n\tThis demo is preconfigured to communicate with {0} DICOM Service.\n\tTo start the service:\n\t* Run {1}\n\t* Select the {0} service\n\t* Click the 'Start Server' button (blue triangle) to start the DICOM service.", _server.AETitle, serverManagerDemo);

         if (_server.AETitle.Equals(this._mySettings.HighLevelStorageServer))
         {
            serverManagerDemo = "CSStorageServerManagerDemo_Original.exe";
            sImportant = string.Format("\n\tThis demo is preconfigured to communicate with {0} DICOM Service.\n\tTo start the service:\n\t* Run {1}\n\t* Click the 'Start Storage Service' button (blue triangle) to start the DICOM service.", _server.AETitle, serverManagerDemo);
         }
         else if (_server.AETitle.Equals(this._mySettings.WorkstationServer))
         {
            serverManagerDemo = "CSMedicalWorkstationMainDemo_Original.exe";
            sImportant = string.Format("\n\tThis demo is preconfigured to communicate with {0} DICOM Service.\n\tTo start the service:\n\t* Run {1}\n\t* Click the 'Service Manager' button (in toolbar at bottom) \n\t* Click the 'Start Server' button (blue triangle) to start the DICOM service.", _server.AETitle, serverManagerDemo);
         }

         LogText("*** IMPORTANT ***", sImportant, Color.Red);
      }

      private void _buttonStorageCommit_Click(object sender, EventArgs e)
      {
#if LEADTOOLS_V19_OR_LATER
         DoStorageCommit();
#endif
      }
   }

   public static class MyExtensions
   {
      public static string GetSelectedAETitle(this ComboBox comboBoxService)
      {
         string aeTitle = string.Empty;

         DicomAE dicomAe = comboBoxService.SelectedItem as DicomAE;
         if (dicomAe != null)
         {
            aeTitle = dicomAe.AE;
         }
         return aeTitle;
      }

      public static void SetSelectedItem(this ComboBox comboBoxService, string aeTitle)
      {
         foreach (object item in comboBoxService.Items)
         {
            DicomAE dicomAe = item as DicomAE;
            if (dicomAe.AE == aeTitle)
            {
               comboBoxService.SelectedItem = item;
               break;
            }
         }
      }

   }

   class PatientInformation
   {
      private string _patientName;
      private string _patientId;
      private string _fileName;

      public PatientInformation(string patientName, string patientId, string fileName)
      {
         _patientName = patientName;
         _patientId = patientId;
         _fileName = fileName;
      }

      public string PatientName
      {
         get { return _patientName; }
         set { _patientName = value; }
      }

      public string PatientId
      {
         get { return _patientId; }
         set { _patientId = value; }
      }

      public string FileName
      {
         get { return _fileName; }
         set { _fileName = value; }
      }
   }

}

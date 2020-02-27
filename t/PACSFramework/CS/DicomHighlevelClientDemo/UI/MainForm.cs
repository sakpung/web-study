// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Net;
using System.Threading;
using System.Management;
using System.IO;
using Leadtools;
using Leadtools.Dicom;
using Leadtools.MedicalViewer;
using Leadtools.Dicom.Scu;
using Leadtools.Dicom.Scu.Common;
using Leadtools.DicomDemos;
using Leadtools.Demos;
using System.Diagnostics;
using System.Collections;
using System.Text.RegularExpressions;
using DicomDemo.UI;
using Leadtools.Dicom.Common.Extensions;

namespace DicomDemo
{
   public partial class MainForm : Form
   {
      private DicomScp _server = new DicomScp();
      private Leadtools.MedicalViewer.MedicalViewer _medicalViewer;

      private const string _sNewline = "\r\n";
      private const string _sNewlineTab = "\r\n\t";
      private const string _sNewlineTabTab = "\r\n\t\t";
      private const string _sConfigurationImplementationClass = "1.2.840.114257.1123456";
      private const string _sConfigurationImplementationVersionName = "1";
      private const string _sConfigurationProtocolversion = "1";

      private MyQueryRetrieveScu _find;
      private bool _canCancel = false;
      private int _retrieveCount = 0;
      private int _totalRetrieveCount = 0;
      private FindQuery _findQuery = new FindQuery();
       private TextBoxTraceListener _tracer = null;
       private bool _closing = false;

      // Settings
       public DicomDemoSettings _mySettings = new DicomDemoSettings();
      public string _demoName = Path.GetFileName(Application.ExecutablePath);

      // Logging
      public delegate void AddLog(string action, string logText, Color sActionColor);      

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
#if LEADTOOLS_V19_OR_LATER
            if(!Support.SetLicense())
               return;
#else
            Support.SetLicense();
            if (RasterSupport.KernelExpired)
               return;
#endif

            bool bConfigure = ReadCommandLine(args);
            if (bConfigure)
               return;

#if LEADTOOLS_V175_OR_LATER
            if (RasterSupport.IsLocked(RasterSupportType.DicomCommunication))
            {
               MessageBox.Show(String.Format("{0} Support is locked!", RasterSupportType.DicomCommunication.ToString()), "Warning");
               return;
            }
#else
            if (RasterSupport.IsLocked(RasterSupportType.MedicalNet))
            {
               MessageBox.Show(String.Format("{0} Support is locked!", RasterSupportType.MedicalNet.ToString()), "Warning");
               return;
            }
#endif

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

      static MyServer ParseOneServer(string serverString)
      {
         //   /servers=ae1,ip1,port1,timeout1,secure1

         MyServer server = null;
         string[] fields = serverString.Split(',');
         if (fields.Length == 5)
         {
            server = new MyServer();
            server._sAE = fields[0].Trim();
            server._sIP = fields[1].Trim();
            server._port = Convert.ToInt32(fields[2].Trim());
            server._timeout = Convert.ToInt32(fields[3].Trim());
            server._useTls = Convert.ToBoolean(fields[4].Trim());
         }
         return server;
      }

      static MyServer[] ParseServerList(string serversString)
      {
         //   /servers=ae1,ip1,port1,timeout1,secure1;ae1,ip1,port1,timeout1,secure1
         serversString.Trim();
         if (serversString.EndsWith(";"))
            serversString = serversString.Substring(0, serversString.Length - 1);
         string[] servers = serversString.Split(';');

         ArrayList list = new ArrayList();
         foreach (string s in servers)
         {
            MyServer server = ParseOneServer(s);
            list.Add(server);
         }

         MyServer[] items = new MyServer[servers.Length];
         list.CopyTo(items);
         return items;
      }

      // Here are two sample command lines:
      //       /configure /server_aetitle=STORAGE_SCU /server_ip=10.1.1.167 /server_port=104 /defaults
      //       /configure /server_aetitle=test_server_ae /server_ip=10.1.1.123 /server_port=123 /client_aetitle=test_client_ae /client_ip=test_client_ip /client_port=456 /defaults
      //
      // Here is how to configure more than one server
      //       /configure /defaults /servers=AE_1,1.1.1.1,101,31,false;AE_2,2.2.2.2,102,32,true

      static bool ReadCommandLine(string[] args)
      {
         return false;
      }

      public MainForm()
      {
         InitializeComponent();

         // 
         // _medicalViewer
         // 
         this._medicalViewer = new Leadtools.MedicalViewer.MedicalViewer();
         this._medicalViewer.AllowMultipleSelection = false;
         this._medicalViewer.AutoScroll = true;
         this._medicalViewer.CellMaintenance = false;
         this._medicalViewer.Columns = 1;
         this._medicalViewer.CustomSplitterColor = false;
         this._medicalViewer.Dock = System.Windows.Forms.DockStyle.Fill;
         this._medicalViewer.Location = new System.Drawing.Point(0, 23);
         this._medicalViewer.Name = "_medicalViewer";
         this._medicalViewer.ResizeBoth = System.Windows.Forms.Cursors.SizeAll;
         this._medicalViewer.ResizeHorizontalCursor = System.Windows.Forms.Cursors.SizeWE;
         this._medicalViewer.ResizeVerticalCursor = System.Windows.Forms.Cursors.SizeNS;
         this._medicalViewer.Rows = 1;
         this._medicalViewer.Size = new System.Drawing.Size(636, 243);
         this._medicalViewer.SplitterColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
         this._medicalViewer.SplitterStyle = Leadtools.MedicalViewer.MedicalViewerSplitterStyle.Thick;
         this._medicalViewer.TabIndex = 3;
         this._medicalViewer.Text = "_medicalViewer";
         this._medicalViewer.UseExtraSplitters = false;
         this._medicalViewer.VisibleRow = 0;

         this._splitContainer5.Panel1.Controls.Add(this._medicalViewer);


         if (!DicomDemoSettingsManager.Is64Process())
            Text = Text + " (32 bit)";
         else
            Text = Text + "(64 bit)";
      }

      private void SizeColumns(ListView lv)
      {
         foreach (ColumnHeader header in lv.Columns)
         {
            header.Width = lv.Width / lv.Columns.Count;
         }
      }

      private void _splitContainer2_Panel2_Resize(object sender, EventArgs e)
      {
      }

      private void _listViewStudies_Resize(object sender, EventArgs e)
      {
         SizeColumns(_listViewStudies);
      }

      private void _listViewSeries_Resize(object sender, EventArgs e)
      {
         SizeColumns(_listViewSeries);
      }

      DialogResult DoOptions()
      {
         OptionsDialog options = new OptionsDialog();
         options.ServerList = _mySettings.ServerList;

         List<String> storageListCopy = new List<String>(_mySettings.StorageClassList);
         options.StorageClassList = storageListCopy;
         options.ImageRetrieveMethod = _mySettings.DicomImageRetrieveMethod;

         // Certificate Authority
         options.CertificateAuthority = _mySettings.CertificateAuthority;

         // Client Settings
         options.ClientAE = _mySettings.ClientAe.AE;
         options.ClientPort = _mySettings.ClientAe.Port;
         options.ClientCertificate = _mySettings.ClientCertificate;
         options.PrivateKey = _mySettings.ClientPrivateKey;
         options.PrivateKeyPassword = _mySettings.ClientPrivateKeyPassword;
         options.ClientPortSecurityUsage = _mySettings.ClientPortSecurityUsage;

         // Miscellaneous Settings
         options.LogLowLevel = _mySettings.LogLowLevel;
         options.GroupLengthDataElements = _mySettings.GroupLengthDataElements;
         options.CipherSuites = _mySettings.CipherSuites;

         DialogResult dr = options.ShowDialog(this);
         if (dr == DialogResult.OK)
         {
            _mySettings.ServerList = options.ServerList;

            // Certificate Authority
            _mySettings.CertificateAuthority = options.CertificateAuthority;

            // Client Settings
            _mySettings.ClientAe.AE = options.ClientAE;
            _mySettings.ClientAe.Port = Convert.ToInt32(options.ClientPort);
            _mySettings.ClientCertificate = options.ClientCertificate;
            _mySettings.ClientPrivateKey = options.PrivateKey;
            _mySettings.ClientPrivateKeyPassword = options.PrivateKeyPassword;
            _mySettings.ClientPortSecurityUsage = options.ClientPortSecurityUsage;

            // Miscellaneous Settings
            _mySettings.LogLowLevel = options.LogLowLevel;
            _mySettings.GroupLengthDataElements = options.GroupLengthDataElements;
            _mySettings.StorageClassList = options.StorageClassList;
            _mySettings.DicomImageRetrieveMethod = options.ImageRetrieveMethod;
            _mySettings.CipherSuites = options.CipherSuites;

            DicomDemoSettingsManager.SaveSettings(_demoName, _mySettings);
            
            UpdateComboBoxService ( ) ;
            
            EnableItems(true);
         }
         return dr;
      }

      private const string defaultServerAE = "LEAD_SERVER";
      private const string defaultServerIP = "127.0.0.1";
      private const int defaultServerPort = 104;
      private const int defaultServerTimeout = 30;
      private const bool defaultServerUseTls = false;

      private const string defaultClientAE = "LEAD_CLIENT";
      private const int defaultClientPort = 1000;
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
         SetStorageClassListDefaults(settings);
         return settings;
      }

      private void SetStorageClassListDefaults(DicomDemoSettings settings)
      {
         settings.StorageClassList.Clear();
         DicomUid uid = DicomUidTable.Instance.GetFirst();
         while (uid != null)
         {
            if (uid.Type == DicomUIDCategory.Class && uid.Code.StartsWith("1.2.840.10008.5.1.4.1.1"))
            {
               settings.StorageClassList.Add(uid.Code);
            }
            uid = DicomUidTable.Instance.GetNext(uid);
         }
      }

      private void SetOtherDefaults(DicomDemoSettings settings)
      {
         settings.CertificateAuthority = DicomDemoSettingsManager.GetCertificateAuthorityFullPath();
         settings.ClientCertificate = DicomDemoSettingsManager.GetClientCertificateFullPath();
         settings.ClientPrivateKey = DicomDemoSettingsManager.GetClientCertificateFullPath();
         settings.ClientPrivateKeyPassword = DicomDemoSettingsManager.GetClientCertificatePassword();

         settings.LogLowLevel = true;
         settings.GroupLengthDataElements = false;
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

      private void LoadSettings()
      {
         try
         {
            // Settings are stored at:
            // %USERPROFILE%\Local Settings\Application Data\<Company Name>\<appdomainname>_<eid>_<hash>\<verison>\user.config

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
                  SetStorageClassListDefaults(_mySettings);
               }
            }

            SetDefaultQueryServer ( ) ;
            _mySettings.FirstRun = false;
            DicomDemoSettingsManager.SaveSettings(_demoName, _mySettings);
         }
         catch (Exception ex)
         {
            System.Diagnostics.Debug.Assert(false, ex.Message);
         }
      }

      private void SetDefaultQueryServer ( )
      {
         DicomAE defaultAE = _mySettings.GetServer ( _mySettings.DefaultImageQuery ) ;
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
             _mySettings.DefaultImageQuery= _comboBoxService.GetSelectedAETitle();
             
             DicomDemoSettingsManager.SaveSettings(_demoName, _mySettings);
             
             SetDefaultQueryServer ( ) ;
          }
      }

      void SelectDefaultServerAE()
      {
         if (_comboBoxService.Items.Count > 0)
         {
            _comboBoxService.SetSelectedItem(_mySettings.DefaultImageQuery);
            
            if ( -1 == _comboBoxService.SelectedIndex && _comboBoxService.Items.Count > 0 )
            {
               _comboBoxService.SelectedIndex = 0 ;
            }
            
            if (_comboBoxService.Items.Count > 0)
            {
               _mySettings.DefaultImageQuery = _comboBoxService.GetSelectedAETitle();
            }
            else
            {
               _mySettings.DefaultImageQuery = string.Empty;
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
         DicomAE defaultAE = _mySettings.GetServer(_mySettings.DefaultImageQuery);
         if (_comboBoxService.SelectedIndex >= 0)
            defaultAE = _mySettings.ServerList[_comboBoxService.SelectedIndex];

         if (defaultAE != null)
            useTls = defaultAE.UseTls;
         return useTls;
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

      void CreateCFindObject()
      {
         
         if (_find != null)
         {
            _find.Dispose();
         }


         bool useTls = GetDefaultUseTls();
         if (useTls)
         {
#if LEADTOOLS_V20_OR_LATER
            const DicomNetSecurityMode securityMode = DicomNetSecurityMode.Tls;
#else
            const DicomNetSecurityeMode securityMode = DicomNetSecurityeMode.Tls;
#endif

            DicomOpenSslContextCreationSettings s =
              new DicomOpenSslContextCreationSettings(
                 DicomSslMethodType.SslV2, 
                  _mySettings.CertificateAuthority,
                 DicomOpenSslVerificationFlags.All, 
                 9, 
                 DicomOpenSslOptionsFlags.AllBugWorkarounds);
            _find = new MyQueryRetrieveScu(this, string.Empty, securityMode, s);
            // _find = new MyQueryRetrieveScu(this, string.Empty, securityMode, null);
         }
         else
         {
            _find = new MyQueryRetrieveScu(this);
         }

         switch (_mySettings.ClientPortSecurityUsage)
         {
            case ClientPortUsageType.Unsecure:
               _find.UseSecureHost = false;
               break;
            case ClientPortUsageType.SameAsServer:
               _find.UseSecureHost = useTls;
               break;
            case ClientPortUsageType.Secure:
               _find.UseSecureHost = true;
               break;
         }

         _find.HostReady += _find_HostReady;

         _find.MaxLength = 46726;
         _find.ImplementationClass = _sConfigurationImplementationClass;
         _find.ProtocolVersion = _sConfigurationProtocolversion;
         _find.ImplementationVersionName = _sConfigurationImplementationVersionName;
         _find.AETitle = _mySettings.ClientAe.AE;
         _find.HostPort = _mySettings.ClientAe.Port;

#if LEADTOOLS_V19_OR_LATER
         _find.Flags = DicomNetFlags.None;
         if (_mySettings.GroupLengthDataElements)
         {
            _find.Flags |= DicomNetFlags.SendDataWithGroupLengthStandardDataElements;
         }
#endif

         _find.BeforeConnect += new Leadtools.Dicom.Scu.Common.BeforeConnectDelegate(_find_BeforeConnect);
         _find.AfterConnect += new Leadtools.Dicom.Scu.Common.AfterConnectDelegate(_find_AfterConnect);
         _find.AfterSecureLinkReady += new AfterSecureLinkReadyDelegate(_find_AfterSecureLinkReady);
         _find.BeforeAssociateRequest += new Leadtools.Dicom.Scu.Common.BeforeAssociationRequestDelegate(_find_BeforeAssociateRequest);
         _find.AfterAssociateRequest += new Leadtools.Dicom.Scu.Common.AfterAssociateRequestDelegate(_find_AfterAssociateRequest);
         _find.BeforeReleaseRequest += new EventHandler(_find_BeforeAssociateRelease);
         _find.AfterReleaseRequest += new EventHandler(_find_AfterAssociateRelease);
         _find.BeforeClose += new EventHandler(_find_BeforeClose);
         _find.AfterClose += new EventHandler(_find_AfterClose);
         _find.MatchStudy += new Leadtools.Dicom.Scu.Common.MatchStudyDelegate(_find_MatchStudy);
         _find.MatchSeries += new Leadtools.Dicom.Scu.Common.MatchSeriesDelegate(_find_MatchSeries);
         _find.BeforeCFind += new Leadtools.Dicom.Scu.Common.BeforeCFindDelegate(_find_BeforeCFind);
         _find.AfterCFind += new Leadtools.Dicom.Scu.Common.AfterCFindDelegate(_find_AfterCFind);

         _find.BeforeCMove += new BeforeCMoveDelegate(_find_BeforeCMove);
         _find.Moved += new Leadtools.Dicom.Scu.Common.MovedDelegate(_find_Moved);
         _find.AfterCMove += new AfterCMoveDelegate(_find_AfterCMove);

#if LEADTOOLS_V18_OR_LATER
         _find.BeforeCGet += new BeforeCGetDelegate(_find_BeforeCGet);
         _find.ReceivedStoreRequest += new ReceivedStoreRequestDelegate(_find_ReceivedStoreRequest);
         _find.AfterCGet += new AfterCGetDelegate(_find_AfterCGet);
#endif

         _find.BeforeAssociateAccept += _find_BeforeAssociateAccept;

         _find.PrivateKeyPassword += new PrivateKeyPasswordDelegate(_find_PrivateKeyPassword);

         if (useTls)
         {
            try
            {
               SetCipherSuites(_find);
               _find.SetTlsClientCertificate(
                  _mySettings.ClientCertificate,
                  DicomTlsCertificateType.Pem,
                  _mySettings.ClientPrivateKey.Length > 0 ? _mySettings.ClientPrivateKey: null);
            }
            catch (Exception ex)
            {
               LogError(ex.Message);
            }
         }

          if(_mySettings.LogLowLevel)
          {
              if(_tracer == null)
              {
                  _tracer = new TextBoxTraceListener(_richTextBoxLog);
                  Trace.Listeners.Add(_tracer);
              }
          }
          else
          {
              if(_tracer!=null)
              {
                  Trace.Listeners.Remove(_tracer);
                  _tracer = null;
              }
          }
          _find.DebugLogFilename = string.Empty;
          _find.EnableDebugLog = true;
          
          SetDefaultQueryServer ( ) ;
      }

      private void _find_HostReady(object sender, HostReadyEventArgs e)
      {
         DicomConnection host = e.ScpHost;
         if (host.SecurityMode  == DicomNetSecurityMode.Tls)
         {
            host.PrivateKeyPassword += Host_PrivateKeyPassword;
            host.SetTlsClientCertificate(_mySettings.ClientCertificate, DicomTlsCertificateType.Pem, _mySettings.ClientCertificate);
            host.PrivateKeyPassword -= Host_PrivateKeyPassword;

            host.SetTlsCipherSuiteByIndex(0,0);

            host.SetTlsCipherSuiteByIndex(0, DicomTlsCipherSuiteType.DheRsaWithDesCbcSha);
            host.SetTlsCipherSuiteByIndex(1, DicomTlsCipherSuiteType.DheRsaWith3DesEdeCbcSha);
            host.SetTlsCipherSuiteByIndex(2, DicomTlsCipherSuiteType.DheRsaAes256Sha);
            host.SetTlsCipherSuiteByIndex(3, DicomTlsCipherSuiteType.RsaWithAes128CbcSha);
            host.SetTlsCipherSuiteByIndex(4, DicomTlsCipherSuiteType.RsaWith3DesEdeCbcSha);
            host.SetTlsCipherSuiteByIndex(5, DicomTlsCipherSuiteType.DheRsaWithAes128GcmSha256);
            host.SetTlsCipherSuiteByIndex(6, DicomTlsCipherSuiteType.EcdheRsaWithAes128GcmSha256);
            host.SetTlsCipherSuiteByIndex(7, DicomTlsCipherSuiteType.DheRsaWithAes256GcmSha384);
            host.SetTlsCipherSuiteByIndex(8, DicomTlsCipherSuiteType.EcdheRsaWithAes256GcmSha384);
         }
      }

      private void Host_PrivateKeyPassword(object sender, PrivateKeyPasswordEventArgs e)
      {
         e.PrivateKeyPassword = _mySettings.ClientPrivateKeyPassword;
      }

      private void _find_BeforeAssociateAccept(object sender, BeforeAssociateAcceptEventArgs e)
      {
         // Uncomment the lines below to see how to modify the DICOM Association before sending the DICOM Associate Accept
         // e.Associate.SetRoleSelect(1, true, DicomRoleSupport.Supported, DicomRoleSupport.Supported);
         // e.Associate.SetRoleSelect(3, true, DicomRoleSupport.Unsupported, DicomRoleSupport.Supported);
      }

#if LEADTOOLS_V18_OR_LATER
      void _find_BeforeCGet(object sender, BeforeCGetEventArgs e)
      {
         string message = _sNewlineTab + "Priority:\t" + e.Priority + e.Scp.ToString();
         LogText("Before CGet", message);
         EnableCancel(true);
         _retrieveCount = 0;
      }

      void _find_ReceivedStoreRequest(object sender, ReceivedStoreRequestEventArgs e)
      {
         ReceiveCStore(e);

         string sMsg = string.Format("Retrieved {0} of {1} instances", _retrieveCount, _totalRetrieveCount);
         StatusText(sMsg);
      }

      void _find_AfterCGet(object sender, AfterCGetEventArgs e)
      {
         string message;
         if (e.Status == DicomCommandStatusType.Success || e.Status == DicomCommandStatusType.Pending || e.Status == DicomCommandStatusType.Warning)
         {
            message =
               _sNewlineTab + "Status:\t" + e.Status.ToString() +
               _sNewlineTab + "Completed:\t" + e.Completed.ToString() +
               _sNewlineTab + "Warning:\t" + e.Warning.ToString() +
               _sNewlineTab + "Failed:\t" + e.Failed.ToString();
         }
         else
         {
            message = _sNewlineTab + " CGet failed\r\n\tStatus: " + e.Status.ToString();
         }
         LogText("After CGet", message);
         if (e.Status != DicomCommandStatusType.Pending)
            EnableCancel(false);
      }
#endif

      void _find_AfterSecureLinkReady(object sender, AfterSecureLinkReadyEventArgs e)
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

      void _find_PrivateKeyPassword(object sender, PrivateKeyPasswordEventArgs e)
      {
         e.PrivateKeyPassword = _mySettings.ClientPrivateKeyPassword;
      }

      void UpdateUI()
      {
         _radioButtonCMove.Checked = (_mySettings.DicomImageRetrieveMethod == DicomRetrieveMode.CMove);
         _radioButtonCGet.Checked = (_mySettings.DicomImageRetrieveMethod == DicomRetrieveMode.CGet);
         buttonCGetStorageClasses.Visible = _radioButtonCGet.Checked;
      }

      private void MainForm_Load(object sender, EventArgs e)
      {
         StatusText(string.Empty);
         SizeColumns(_listViewStudies);
         SizeColumns(_listViewSeries);
         LoadSettings();

         DicomDemoSettingsManager.SaveSettings(_demoName, _mySettings);

         UpdateUI();
         this._radioButtonCMove.Checked = (_mySettings.DicomImageRetrieveMethod == DicomRetrieveMode.CMove);
         this._radioButtonCGet.Checked = (_mySettings.DicomImageRetrieveMethod == DicomRetrieveMode.CGet);

         UpdateComboBoxService();
         EnableItems(true);
         CreateCFindObject();

         _propertyGrid.SelectedObject = _findQuery;

         this._find._mainForm = this;
      }

      private static void InitializeMedicalViewerCell ( MedicalViewerMultiCell cell ) 
      {
         cell.AddAction(MedicalViewerActionType.WindowLevel);
         cell.AddAction(MedicalViewerActionType.Stack);
         cell.SetAction(MedicalViewerActionType.WindowLevel, MedicalViewerMouseButtons.Right, MedicalViewerActionFlags.Active);
         cell.SetAction(MedicalViewerActionType.Stack, MedicalViewerMouseButtons.Wheel, MedicalViewerActionFlags.Active);
         
         // Set the relative sensitivity to true to raise the sensitivity on the images with large lookup table
         using ( MedicalViewerWindowLevel windowLevelActionProperties = (MedicalViewerWindowLevel)cell.GetActionProperties(MedicalViewerActionType.WindowLevel, 0) )
         {
            windowLevelActionProperties.RelativeSensitivity = true;
            cell.SetActionProperties(MedicalViewerActionType.WindowLevel, windowLevelActionProperties, 0);
         }
         
         cell.OverlayTextSize = 12;
      }

      private void AppendTextColor(string text, Color color)
      {
         Color oldColor = _richTextBoxLog.SelectionColor;

         _richTextBoxLog.SelectionLength = text.Length;
         _richTextBoxLog.SelectionStart = _richTextBoxLog.Text.Length;
         _richTextBoxLog.SelectionColor = color;
         _richTextBoxLog.SelectionFont = new Font(_richTextBoxLog.SelectionFont, FontStyle.Bold);
         _richTextBoxLog.AppendText(text);
         _richTextBoxLog.SelectionColor = oldColor;
      }

      private void AddAction(string sAction, Color color)
      {
         System.Drawing.Color oldColor = _richTextBoxLog.SelectionColor;

         _richTextBoxLog.SelectionLength = sAction.Length;
         _richTextBoxLog.SelectionStart = _richTextBoxLog.Text.Length;
         _richTextBoxLog.SelectionColor = color;
         _richTextBoxLog.SelectionFont = new Font(_richTextBoxLog.SelectionFont, FontStyle.Bold);
         _richTextBoxLog.AppendText(sAction + ": ");
         _richTextBoxLog.SelectionColor = oldColor;
      }

      public void LogText(string sAction, string sLogText, Color sActionColor)
      {
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
                  _richTextBoxLog.AppendText(sLogText);
               }
               _richTextBoxLog.AppendText(_sNewline);
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
         LogText(sAction, sLogText, Color.Blue);
      }

      public void LogWarning(string sAction, string sLogText)
      {
         LogText(sAction, sLogText, Color.Red);
      }

      public void LogError(string sLogText)
      {
         LogText("*** ERROR *** ", _sNewlineTab + sLogText, Color.Red);
      }

      void _find_BeforeConnect(object sender, Leadtools.Dicom.Scu.Common.BeforeConnectEventArgs e)
      {
         LogText("Before Connect", e.Scp.ToString());

      }
      void _find_AfterConnect(object sender, Leadtools.Dicom.Scu.Common.AfterConnectEventArgs e)
      {
         string message;
         if (e.Error == DicomExceptionCode.Success)
         {
            message = _sNewlineTab + "Connection Successful";
         }
         else
         {
            message =  
               _sNewlineTab + "Connection failed" + 
               _sNewlineTab + "Error:\t" + e.Error.ToString();
         }
         
         LogText("After Connect", message);
      }

      void _find_BeforeAssociateRequest(object sender, Leadtools.Dicom.Scu.Common.BeforeAssociateRequestEventArgs e)
      {
         LogText("Before Associate Request", e.Associate.ToString());
      }

      void _find_AfterAssociateRequest(object sender, Leadtools.Dicom.Scu.Common.AfterAssociateRequestEventArgs e)
      {
         string message;
         if (e.Rejected)
         {
            message = 
               _sNewlineTab + "Association Rejected" +
               _sNewlineTab + "Result: " + e.Result.ToString() +
               _sNewlineTab + "Reason: " + e.Reason.ToString() +
               _sNewlineTab + "Source: " + e.Source.ToString();
         }
         else
         {
            message = _sNewlineTab + "Association Accepted";
            if (e.Associate != null)
               message = message + e.Associate.ToString();
         }
         LogText("After Associate Request", message);
      }

      void _find_BeforeAssociateRelease(object sender, EventArgs e)
      {
         LogText("Before Associate Release", string.Empty);
      }

      void _find_AfterAssociateRelease(object sender, EventArgs e)
      {
         LogText("After Associate Release", string.Empty);
      }

      void _find_BeforeClose(object sender, EventArgs e)
      {
         LogText("Before Close", string.Empty);
      }

      void _find_AfterClose(object sender, EventArgs e)
      {
         LogText("After Close", string.Empty);
      }

      void _find_BeforeCFind(object sender, Leadtools.Dicom.Scu.Common.BeforeCFindEventArgs e)
      {
         string message = 
            _sNewlineTab + "QueryLevel:\t" + e.QueryLevel.ToString() +
            _sNewlineTab + "Priority:\t" + e.Priority.ToString();

         LogText("Before CFind", message);

         EnableCancel(true);
      }

      void _find_AfterCFind(object sender, Leadtools.Dicom.Scu.Common.AfterCFindEventArgs e)
      {
         string message;
         if (e.Status == DicomCommandStatusType.Success)
         {
            message =
               _sNewlineTab + "MatchCount:\t" + e.MatchCount.ToString() +
               _sNewlineTab + "Status:\t" + e.Status.ToString();
         }
         else
         {
            message = 
               _sNewlineTab + " CFind failed" + 
               _sNewlineTab + "Status: " + e.Status.ToString();
         }
         LogText("After CFind", message);
         EnableCancel(false);
      }

      void _find_MatchStudy(object sender, Leadtools.Dicom.Scu.Common.MatchEventArgs<Study> e)
      {
         string message = 
            _sNewlineTab + "QueryLevel: " + e.QueryLevel.ToString() +
            _sNewlineTab + "Availability:\t" + e.Availability.ToString() +
            _sNewlineTab + "Info:\t" + e.Info.ToString() +
            _sNewlineTab + "RetrieveAETitle:\t" + e.RetrieveAETitle.ToString();
         LogText("Study Match Found", message);
         AddStudyItem(e);
      }

      void _find_MatchSeries(object sender, Leadtools.Dicom.Scu.Common.MatchEventArgs<Series> e)
      {
         string message = 
            _sNewlineTab + "QueryLevel: " + e.QueryLevel.ToString() +
            _sNewlineTab + "Availability:\t" + e.Availability.ToString() +
            _sNewlineTab + "Info:\t" + e.Info.ToString() +
            _sNewlineTab + "RetrieveAETitle:\t" + e.RetrieveAETitle.ToString();
         LogText("Series Match Found", message);
         AddSeriesItem(e);
      }

      void _find_BeforeCMove(object sender, BeforeCMoveEventArgs e)
      {
         string message = 
            _sNewlineTab + "Priority:\t" + e.Priority + e.Scp.ToString() +
            _sNewlineTab + "Desination AE:\t" + e.DestinationAETitle;
         LogText("Before CMove", message);
         EnableCancel(true);
         _retrieveCount = 0;
      }

      void _find_AfterCMove(object sender, AfterCMoveEventArgs e)
      {
         string message;
         if (e.Status == DicomCommandStatusType.Success || e.Status==DicomCommandStatusType.Pending || e.Status == DicomCommandStatusType.Warning)
         {
            message =
               _sNewlineTab + "Status:\t" + e.Status.ToString() +
               _sNewlineTab + "Completed:\t" + e.Completed.ToString() +
               _sNewlineTab + "Warning:\t" + e.Warning.ToString() +
               _sNewlineTab + "Failed:\t" + e.Failed.ToString();
         }
         else
         {
            message = _sNewlineTab + " CMove failed\r\n\tStatus: " + e.Status.ToString();
         }
         LogText("After CMove", message);
         if (e.Status != DicomCommandStatusType.Pending)
            EnableCancel(false);
      }

      private class CStoreReceivedArgs
      {
         public Patient Patient;
         public Study Study;
         public Series Series;
         public CompositeObjectInstance Instance;

         public CStoreReceivedArgs(MovedEventArgs e)
         {
            Patient = e.Patient;
            Study = e.Study;
            Series = e.Series;
            Instance = e.Instance;
         }

         public CStoreReceivedArgs(ReceivedStoreRequestEventArgs e)
         {
            Patient = e.Patient;
            Study = e.Study;
            Series = e.Series;
            Instance = e.Instance;
         }
      }

      public delegate void ReceiveFindMovedDelegate(Leadtools.Dicom.Scu.Common.MovedEventArgs e);

      void ReceiveFindMoved(Leadtools.Dicom.Scu.Common.MovedEventArgs e)
      {
         if (InvokeRequired)
         {
            Invoke(new ReceiveFindMovedDelegate(ReceiveFindMoved), e);
         }
         else
         {
            CStoreReceivedArgs args = new CStoreReceivedArgs(e);
            ReceiveDataFromCStore(args);
         }
      }

      public delegate void ReceiveGetStoredDelegate(Leadtools.Dicom.Scu.Common.ReceivedStoreRequestEventArgs e);
      void ReceiveCStore(Leadtools.Dicom.Scu.Common.ReceivedStoreRequestEventArgs e)
      {
         if (InvokeRequired)
         {
            Invoke(new ReceiveGetStoredDelegate(ReceiveCStore), e);
         }
         else
         {
            CStoreReceivedArgs args = new CStoreReceivedArgs(e);
            ReceiveDataFromCStore(args);
         }
      }

      void AddImageToViewer(CStoreReceivedArgs e)
      {
            ImageInstance instance = e.Instance as ImageInstance;
            int cols = 1;
            int rows = 1;
            if (instance != null && instance.Images != null)
            {
               int pageCount = instance.Images.PageCount;
               if (pageCount > 1)
               {
                  // Display at most 6 x 6 (36) frames
                  if (pageCount >= 36)
                  {
                     cols = 6;
                     rows = 6;
                  }
                  else
                  {
                     cols = (int)Math.Floor(Math.Sqrt(pageCount));
                     rows = (int)Math.Ceiling((double)pageCount / cols);
                  }
               }

               MedicalViewerMultiCell m = GetCell();

               m.Rows = rows;
               m.Columns = cols;

               if (m.Image != null)
               {
                  for (int pageIndex = 0; pageIndex < instance.Images.PageCount; pageIndex++)
                  {
                     instance.Images.Page = pageIndex + 1;

                     try
                     {
                        m.Image.AddPage(instance.Images);
                     }
                     catch (Exception ex)
                     {
                        Console.WriteLine(ex.Message);
                     }
                  }
               }
               else
               {
                  m.Image = instance.Images;
               }

               if (pageCount > 1)
               {
                  m.SetTag(0, MedicalViewerTagAlignment.TopLeft, MedicalViewerTagType.Frame);
                  m.ShowTags = true;
               }
               m.SetTag(1, MedicalViewerTagAlignment.BottomLeft, MedicalViewerTagType.WindowLevelData);

               // Give the medical viewer cell the focus
               if (_medicalViewer.Cells.Count > 0 &&
                     _medicalViewer.Cells[0] is MedicalViewerBaseCell)
               {
                  (_medicalViewer.Cells[0] as MedicalViewerBaseCell).Selected = true;
               }

               m.SetScaleMode(MedicalViewerScaleMode.Fit);
            }
      }

      void ReceiveDataFromCStore(CStoreReceivedArgs e)
      {
         string message =
            _sNewlineTab + "PatientId:\t" + e.Patient.Id +
            _sNewlineTab + "StudyInstanceUID:\t" + e.Study.InstanceUID +
            _sNewlineTab + "SeriesInstanceUID:\t" + e.Series.InstanceUID +
            _sNewlineTab + "SOPInstanceUID:\t" + e.Instance.SOPInstanceUID;

         if (_mySettings.DicomImageRetrieveMethod == DicomRetrieveMode.CMove)
         {
            LogText("Moved", message);
         }
         else
         {
            LogText("Stored", message);
         }
         _retrieveCount++;

         if (e.Instance.InstanceType == InstanceLevel.Image)
         {
            AddImageToViewer(e);
         }
      }

      private MedicalViewerMultiCell GetCell()
      {
         if (_medicalViewer.Cells.Count > 0)
         {
            return _medicalViewer.Cells[0] as MedicalViewerMultiCell;
         }
         else
         {
            MedicalViewerMultiCell m = new MedicalViewerMultiCell();

            InitializeMedicalViewerCell(m);
            m.FitImageToCell = false;
            m.DisplayRulers = MedicalViewerRulers.None;

            //m.SetScaleMode(MedicalViewerScaleMode.Fit);

            _medicalViewer.Cells.Add(m);

            return m;
         } 
      }

      void _find_Moved(object sender, Leadtools.Dicom.Scu.Common.MovedEventArgs e)
      {
         ReceiveFindMoved(e);

         string sMsg = string.Format("Retrieved {0} of {1} instances", _retrieveCount, _totalRetrieveCount);
         StatusText(sMsg);
      }

      public delegate void StartUpdateDelegate(ListView lv);
      private void StartUpdate(ListView lv)
      {
         if (InvokeRequired)
         {
            Invoke(new StartUpdateDelegate(StartUpdate), lv);
         }
         else
         {
            lv.Items.Clear();
            lv.BeginUpdate();
         }
      }

      public delegate void EndUpdateDelegate(ListView lv);
      private void EndUpdate(ListView lv)
      {
         if (InvokeRequired)
         {
            Invoke(new EndUpdateDelegate(EndUpdate), lv);
         }
         else
         {
            lv.EndUpdate();
         }
      }


      public delegate void AddStudyItemDelegate(MatchEventArgs<Study> ds);
      private void AddStudyItem(MatchEventArgs<Study> e)
      {
         ListViewItem item;

         if (InvokeRequired)
         {
            Invoke(new AddStudyItemDelegate(AddStudyItem), e);
         }
         else
         {
            item = _listViewStudies.Items.Add(e.Info.Patient.Name.Full);
            item.SubItems.Add(e.Info.Patient.Id);
            item.SubItems.Add(e.Info.AccessionNumber);
            item.SubItems.Add(e.Info.Date.HasValue ? e.Info.Date.Value.ToString("d") : string.Empty);
            item.SubItems.Add(e.Info.Time.HasValue ? e.Info.Time.ToString() : string.Empty);
            item.SubItems.Add(e.Info.ReferringPhysiciansName.Full);
            item.SubItems.Add(e.Info.Description);

            item.Tag = e.Info;
         }
      }

      public delegate void AddSeriesItemDelegate(MatchEventArgs<Series> e);
      private void AddSeriesItem(MatchEventArgs<Series> e)
      {
         ListViewItem item;

         if (InvokeRequired)
         {
            Invoke(new AddSeriesItemDelegate(AddSeriesItem), e);
         }
         else
         {

            item = _listViewSeries.Items.Add(e.Info.Date.HasValue ? e.Info.Date.Value.ToString("d") : string.Empty);
            item.SubItems.Add(e.Info.Number.ToString());
            item.SubItems.Add(e.Info.Description);
            item.SubItems.Add(e.Info.Modality);
            item.SubItems.Add(e.Info.NumberOfRelatedInstances.ToString());

            MySeries mySeries = new MySeries(e.Info);
            item.Tag = mySeries;
         }
      }

      public delegate void EnableCancelDelegate(bool enable);
      public void EnableCancel(bool enable)
      {
         if (InvokeRequired)
         {
            Invoke(new EnableCancelDelegate(EnableCancel), enable);
         }
         else
         {
            _canCancel = enable;
            _buttonCancel.Enabled = _canCancel;
         }
      }


      public delegate void EnableItemsDelegate(bool enable);
      public void EnableItems(bool enable)
      {
         if (InvokeRequired)
         {
            Invoke(new EnableItemsDelegate(EnableItems), enable);
         }
         else
         {
            _comboBoxService.Enabled = enable;
            _textBoxServerIp.Enabled = enable;
            _textBoxServerPort.Enabled = enable;
            _menuStrip.Enabled = enable;
            _listViewStudies.Enabled = enable;
            _listViewSeries.Enabled = enable;
            _buttonSearch.Enabled = enable && (_mySettings.ServerList.Count > 0);
            _buttonOptions.Enabled = enable;
            _buttonCancel.Enabled = !enable && _canCancel;

            _radioButtonCMove.Enabled = enable && (_listViewSeries.Items.Count > 0);
            _radioButtonCGet.Enabled = enable && (_listViewSeries.Items.Count > 0);
            buttonCGetStorageClasses.Enabled = _radioButtonCGet.Enabled && (_listViewSeries.SelectedItems.Count > 0);
         }
      }

      private void DoSearch()
      {
         //Cursor = Cursors.WaitCursor;
         ClearCells ( ) ;

         _listViewSeries.Items.Clear();

         EnableItems(false);
         StartUpdate(_listViewStudies);
         _find.AETitle = _mySettings.ClientAe.AE;
         _find.HostPort = _mySettings.ClientAe.Port;

         Thread t = new Thread(delegate()
            {
               try
               {
                  _find.Find(_server, _findQuery);
               }
               catch (Exception ex)
               {
                  LogError(ex.Message);

                  if (string.Compare(ex.Message, "The attempt to connect was forcefully rejected", true) == 0)
                  {
                     if (_mySettings.IsPreconfigured)
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

         EnableItems(true);
         EndUpdate(_listViewStudies);
         StatusText(string.Empty);
         //Cursor = Cursors.Default;
      }

      //private void ClearCells()
      //{
      //   this._medicalViewer.Cells.Clear();
      //   if (_medicalViewer.Cells != 0 && _medicalViewer.Cells.Count > 0)
      //   {
      //      MedicalViewerMultiCell mc = _medicalViewer.Cells[0] as MedicalViewerMultiCell;
      //      if (mc != null)
      //      {
      //         mc.Image.Del
      //      }
      //   }
      //}

      private void ClearCells()
      {
         if (_medicalViewer != null)
            this._medicalViewer.Cells.Clear();

         return;

         //List<MedicalViewerBaseCell> cells;

         //cells = new List<MedicalViewerBaseCell>();

         //cells.AddRange(this._medicalViewer.Cells);

         //foreach (MedicalViewerBaseCell cell in cells)
         //{
         //   MedicalViewerMultiCell mc = cell as MedicalViewerMultiCell;
            
         //   if (mc != null)
         //   {
         //      if (mc.Image != null)
         //      {
         //         RasterImage image ;
                  
         //         image = mc.Image ;
                  
         //         mc.Image = null ; //this causes problem
                  
         //         image = null;
         //      }
         //   }
         //   cell.Dispose();

         //   this._medicalViewer.Cells.Remove(cell);
         //}

         //cells.Clear();
      }

      private void DoCancel()
      {
         if (_find.IsAssociated())
         {
            _find.AETitle = _mySettings.ClientAe.AE;
            _find.HostPort = _mySettings.ClientAe.Port;
            _find.CancelRequest();
            LogText("Cancelled", _sNewlineTab + "Sent C-Cancel");
            StatusText("Cancelled");
         }
      }

      private void _listViewStudies_SelectedIndexChanged(object sender, EventArgs e)
      {
         if (_listViewStudies.SelectedItems.Count == 0)
            return;

         Study study = _listViewStudies.SelectedItems[0].Tag as Study;
         ClearCells();

         if (study.InstanceUID.Length > 0)
         {
             FindQuery query = new FindQuery();

            Cursor = Cursors.WaitCursor;
            StartUpdate(_listViewSeries);
            EnableItems(false);

            query.QueryLevel = QueryLevel.Series;
            query.PatientId = study.Patient.Id;
            query.StudyInstanceUID = study.InstanceUID;

            Thread t = new Thread(delegate()
            {
               try
               {
                  _find.Find(_server, query);
               }
               catch (Exception ex)
               {
                  MessageBox.Show(ex.Message);
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
            EnableItems(true);
            EndUpdate(_listViewSeries);
            Cursor = Cursors.Default;
         }
      }


      private void _listViewSeries_DoubleClick(object sender, EventArgs e)
      {
         if (_listViewStudies.SelectedItems.Count == 0)
            return;

         Study study = _listViewStudies.SelectedItems[0].Tag as Study;
         if (study == null)
            return;

         MySeries mySeries = _listViewSeries.SelectedItems[0].Tag as MySeries;
         if (mySeries == null)
            return;

         ClearCells();

         //Cursor = Cursors.WaitCursor;
         EnableItems(false);

         try
         {
             _totalRetrieveCount = mySeries.Series.NumberOfRelatedInstances;

             Thread t = new Thread(delegate()
             {
                try
                {
                   if (this._radioButtonCMove.Checked)
                   {
                      string destAE = _mySettings.ClientAe.AE;
                      _find.Move(_server, destAE, study.InstanceUID, mySeries.Series.InstanceUID);
                   }
 #if LEADTOOLS_V18_OR_LATER  
                   else
                   {
                      mySeries.SetDefaultAdditionalPresentationContexts();

                      try
                      {
                         _find.Get(_server, study.InstanceUID, mySeries.Series.InstanceUID, mySeries.AdditionalPresentationContexts);
                      }
                      catch (Exception ex)
                      {
                        string error = ex.Message.ToLower();
                        const string errorUnsupported = "Abstract Syntax Not Supported";
                        if (error.Contains(errorUnsupported.ToLower()) && error.Contains(DicomUidType.StudyRootQueryGet))
                        {
                           string message = string.Format("{1}{0} does not support C-GET{1}Do one of the following{1}* Click the 'Options' button and change the 'Image Retrieve Method' to C-MOVE or{1}* Select a server that supports C-GET",
                              _server.AETitle, _sNewlineTab);

                              foreach (DicomAE dicomAE in _mySettings.ServerList)
                              {
                                 MatchCollection mc = Regex.Matches(dicomAE.AE, "L[0-9][0-9]_SERVER");
                                 if (mc.Count > 0)
                                 {
                                    message = message + string.Format("(i.e. {0})", mc[0].Value);
                                 }
                                 break;
                              }

                           LogWarning("Could not Retrieve Image", message);
                        }
                        else
                        {
                           throw ex;
                        }
                      }
                   }
#endif
                }
                catch (Exception ex)
                {
                   LogError(ex.Message);
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
         }
         catch (Exception ex)
         {
            LogError(ex.Message);
         }

         EnableItems(true);
         //Cursor = Cursors.Default;
      }

      private void clearLogToolStripMenuItem_Click(object sender, EventArgs e)
      {
        _richTextBoxLog.Clear();
      }

      private void exitToolStripMenuItem_Click(object sender, EventArgs e)
      {
         Application.Exit();
      }

      private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
      {
         AboutDialog dlg = new AboutDialog("DICOM High Level Client");

         dlg.ShowDialog(this);
      }

      private void _toolStripMenuItem1_Click(object sender, EventArgs e)
      {
         _richTextBoxLog.Clear();
      }

      private void Options_Click(object sender, EventArgs e)
      {
         // Check if the options have changed
         if(DialogResult.OK == DoOptions())
            CreateCFindObject();
      }

      private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
      {
         // Check if the options have changed
         if(DialogResult.OK == DoOptions())
            CreateCFindObject();
      }

      private void StatusText(string s)
      {
         _labelStatus.Text = s;
         Application.DoEvents();
      }

      private void _buttonSearch_Click(object sender, EventArgs e)
      {
         DoSearch();
      }

      private void searchToolStripMenuItem_Click(object sender, EventArgs e)
      {
         DoSearch();
      }

      private void _buttonCancel_Click(object sender, EventArgs e)
      {
         DoCancel();
      }

      private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
      {
         _closing = true;
         if (_find != null)
         {
            if (_find.IsConnected())
            {
               (_find as QueryRetrieveScu).CloseForced(true);
            }
         }
      }

      private void showHelpToolStripMenuItem_Click(object sender, EventArgs e)
      {
         HelpDialog dlg = new HelpDialog(_mySettings.DefaultImageQuery, false);
         dlg.ShowDialog(this);
      }

      private void MainForm_Activated(object sender, EventArgs e)
      {
         base.Activate();
         if(_firstTime && _mySettings.ShowHelpOnStart)
         {
            _firstTime = false;
            HelpDialog dlg = new HelpDialog(_mySettings.DefaultImageQuery, _mySettings.ShowHelpOnStart);
            dlg.ShowDialog(this);
            if (dlg.CheckBoxNoShowAgainResult)
            {
               _mySettings.ShowHelpOnStart = false;
               DicomDemoSettingsManager.SaveSettings(_demoName, _mySettings);
            }
         }
      }

      private void _comboBoxService_SelectionChangeCommitted(object sender, EventArgs e)
      {
         UpdateDefaultServerAE();
         CreateCFindObject();
      }

      private void buttonCGetStorageClasses_Click(object sender, EventArgs e)
      {
         if (_listViewSeries.SelectedItems.Count > 0)
         {
            MySeries mySeries = _listViewSeries.SelectedItems[0].Tag as MySeries;

            if (mySeries !=null)
            {
               StorageClassesDialog dlg = new StorageClassesDialog();

               if (!mySeries.IsDirtyPresentationContextList)
               {
                  mySeries.SetDefaultAdditionalPresentationContexts(); 
               }
               dlg.PresentationContextList = mySeries.AdditionalPresentationContexts;
               if (DialogResult.OK == dlg.ShowDialog())
               {
                  mySeries.AdditionalPresentationContexts = dlg.PresentationContextList;
               }
            }
         }

      }

      private void _radioButtonCMove_CheckedChanged(object sender, EventArgs e)
      {
         if (this._radioButtonCMove.Checked)
         {
            _mySettings.DicomImageRetrieveMethod = DicomRetrieveMode.CMove;
            DicomDemoSettingsManager.SaveSettings(_demoName, _mySettings);
            UpdateUI();
         }
      }

      private void _radioButtonCGet_CheckedChanged(object sender, EventArgs e)
      {
         if (this._radioButtonCGet.Checked)
         {
            _mySettings.DicomImageRetrieveMethod = DicomRetrieveMode.CGet;
            DicomDemoSettingsManager.SaveSettings(_demoName, _mySettings);
            UpdateUI();
         }
      }

      private void _listViewSeries_SelectedIndexChanged(object sender, EventArgs e)
      {
         EnableItems(true);
      }

   }

   [Serializable()]

   public class MyServer
   {      
      public string _sAE;
      public string _sIP;      
      public int _port;      
      public int _timeout;      
      public bool _useTls;

      public MyServer()
      {
         _sAE = string.Empty;
         _sIP = string.Empty;
         _port = 0;
         _timeout = 0;
         _useTls = false;
      }

      public MyServer(string sAE, string sIP, int port, int timeout, bool useTls)
      {
         _sAE = sAE;
         _sIP = sIP;
         _port = port;
         _timeout = timeout;
         _useTls = useTls;
      }
   }

   public class MySeries
   {
      public MySeries(Series series)
      {
         _series = series;
         _additionalPresentationContexts = new List<PresentationContext>();
         _isDirtyPresentationContextList = false;
      }

      public Series Series
      {
         get
         {
            return _series;
         }
      }

      public static PresentationContext CreatePresentationContext(string uidType)
      {
         PresentationContext pc = new PresentationContext(uidType);
         pc.TransferSyntaxes.Add(DicomUidType.ImplicitVRLittleEndian);
         pc.TransferSyntaxes.Add(DicomUidType.ExplicitVRLittleEndian);
         pc.TransferSyntaxes.Add(DicomUidType.JPEGBaseline1);
         pc.TransferSyntaxes.Add(DicomUidType.JPEGExtended2_4);
         pc.TransferSyntaxes.Add(DicomUidType.JPEGExtended3_5);
         return pc;
      }

      private void AddPresentationContext(string uidType)
      {
         PresentationContext pc = CreatePresentationContext(uidType);
         _additionalPresentationContexts.Add(pc);
      }

      public List<PresentationContext> AdditionalPresentationContexts
      {
         get
         {
            return _additionalPresentationContexts;
         }

         set
         {
            _additionalPresentationContexts = value;
            _isDirtyPresentationContextList = true;
         }
      }

      public bool IsDirtyPresentationContextList
      {
         get
         {
            return _isDirtyPresentationContextList;
         }
      }

      public void SetDefaultAdditionalPresentationContexts()
      {
         if (IsDirtyPresentationContextList)
            return;

         switch(Series.Modality)
         {
            case "AR": // Autorefraction
               AddPresentationContext(DicomUidType.AutorefractionMeasurementsStorage);
               break;

            case "ASMT": // Content Assessment Results
               AddPresentationContext(DicomUidType.DicomContentMappingResource);
               break;

            case "AU": // Audio
               AddPresentationContext(DicomUidType.BasicVoiceAudioWaveformStorage);
               AddPresentationContext(DicomUidType.GeneralAudioWaveformStorage);
               AddPresentationContext(DicomUidType.AudioSRStorageTrialRetired);
               break;

            case "BDUS": // Bone Densitometry (ultrasound)
               AddPresentationContext(DicomUidType.USImageStorage);
               AddPresentationContext(DicomUidType.USImageStorageRetired);
               AddPresentationContext(DicomUidType.USMultiframeImageStorage);
               AddPresentationContext(DicomUidType.USMultiframeImageStorageRetired);
               AddPresentationContext(DicomUidType.EnhancedUSVolumeStorage);
               break;

            case "BI": // Biomagnetic imaging
               break;

            case "BMD": // Bone Densitometry (X-Ray)
               break;

            case "CR": // Computed Radiography
               AddPresentationContext(DicomUidType.CRImageStorage);
               break;

            case "CT": // Computed Tomography
               AddPresentationContext(DicomUidType.CTImageStorage);
               AddPresentationContext(DicomUidType.EnhancedCTImageStorage);
               break;

            case "CTPROTOCOL": // CT Protocol (Performed)
               AddPresentationContext(DicomUidType.CTImageStorage);
               AddPresentationContext(DicomUidType.EnhancedCTImageStorage);
               break;

            case "DG": // Diaphanography
               break;

            case "DOC": // Document
               break;

            case "DX": // Digital Radiography
               AddPresentationContext(DicomUidType.DXImageStoragePresentation);
               AddPresentationContext(DicomUidType.DXImageStorageProcessing);
               AddPresentationContext(DicomUidType.DXIntraoralImageStoragePresentation);
               AddPresentationContext(DicomUidType.DXIntraoralImageStorageProcessing);
               AddPresentationContext(DicomUidType.DXMammographyImageStoragePresentation);
               AddPresentationContext(DicomUidType.DXMammographyImageStorageProcessing);
               break;

            case "ECG": // Electrocardiography
               AddPresentationContext(DicomUidType.TwelveLeadECGWaveformStorage);
               AddPresentationContext(DicomUidType.GeneralECGWaveformStorage);
               AddPresentationContext(DicomUidType.AmbulatoryECGWaveformStorage);
               break;

            case "EPS": // Cardiac Electrophysiology
               AddPresentationContext(DicomUidType.CardiacElectrophysiologyWaveformStorage);
               break;

            case "ES": // Endoscopy
               AddPresentationContext(DicomUidType.VideoEndoscopicImageStorage);
               AddPresentationContext(DicomUidType.VLEndoscopicImageStorageClass);
               break;

            case "FID": // Fiducials
               AddPresentationContext(DicomUidType.SpatialFiducialsStorage);
               break;

            case "GM": // General Microscopy
               AddPresentationContext(DicomUidType.VideoMicroscopicImageStorage);
               AddPresentationContext(DicomUidType.VLMicroscopicImageStorageClass);
               AddPresentationContext(DicomUidType.VLSlideCoordinatesMicroscopicImageStorageClass);
               AddPresentationContext(DicomUidType.VLWholeSlideMicroscopyImageStorage);
               break;

            case "HC": // Hard Copy
               AddPresentationContext(DicomUidType.HardcopyColorImageStorageClass);
               AddPresentationContext(DicomUidType.HardcopyGrayscaleImageStorageClass);
               break;

            case "HD": // Hemodynamic Waveform
               AddPresentationContext(DicomUidType.HemodynamicWaveformStorage);
               break;

            case "IO": // Intra-Oral Radiography
               AddPresentationContext(DicomUidType.DXIntraoralImageStoragePresentation);
               AddPresentationContext(DicomUidType.DXIntraoralImageStorageProcessing);
               break;

            case "IOL": // Intraocular Lens Data
               AddPresentationContext(DicomUidType.IntraocularLensCalculationsStorage);
               AddPresentationContext(DicomUidType.LensometryMeasurementsStorage);
               break;

            case "IVOCT": // Intravascular Optical Coherence Tomography
               AddPresentationContext(DicomUidType.IntravascularOctImageStoragePresentation);
               AddPresentationContext(DicomUidType.IntravascularOctImageStorageProcessing);
               break;

            case "IVUS": // Intravascular Ultrasound
               AddPresentationContext(DicomUidType.USImageStorage);
               AddPresentationContext(DicomUidType.USImageStorageRetired);
               AddPresentationContext(DicomUidType.USMultiframeImageStorage);
               AddPresentationContext(DicomUidType.USMultiframeImageStorageRetired);
               AddPresentationContext(DicomUidType.EnhancedUSVolumeStorage);
               break;

            case "KER": // Keratometry
               AddPresentationContext(DicomUidType.KeratometryMeasurementsStorage);
               break;

            case "KO": // Key Object Selection
               AddPresentationContext(DicomUidType.KeyObjectSelectionDocument);
               break;

            case "LEN": // Lensometry
               AddPresentationContext(DicomUidType.LensometryMeasurementsStorage);
               AddPresentationContext(DicomUidType.IntraocularLensCalculationsStorage);
               break;

            case "LS": // Laser surface scan
               AddPresentationContext(DicomUidType.SurfaceScanMeshStorage);
               AddPresentationContext(DicomUidType.SurfaceScanPointCloudStorage);
               AddPresentationContext(DicomUidType.SurfaceSegmentationStorage);
               break;

            case "MG": // Mammography
               AddPresentationContext(DicomUidType.MammographyCadSR);
               AddPresentationContext(DicomUidType.DXMammographyImageStoragePresentation);
               AddPresentationContext(DicomUidType.DXMammographyImageStorageProcessing);
               break;

            case "MR": // Magnetic Resonance
               AddPresentationContext(DicomUidType.MRImageStorage);
               AddPresentationContext(DicomUidType.MRSpectroscopyStorage);
               AddPresentationContext(DicomUidType.EnhancedMRColorImageStorage);
               AddPresentationContext(DicomUidType.EnhancedMRImageStorage);
               AddPresentationContext(DicomUidType.LegacyConvertedEnhancedMRImageStorage);
               break;

            case "NM": // Nuclear Medicine
               AddPresentationContext(DicomUidType.NMImageStorageRetired);
               AddPresentationContext(DicomUidType.NMImageStorage);
               break;

            case "OAM": // Ophthalmic Axial Measurements
               AddPresentationContext(DicomUidType.OphthalmicAxialMeasurementsStorage);

               break;
            case "OCT": // Optical Coherence Tomography (non-Ophthalmic)
               AddPresentationContext(DicomUidType.OphthalmicTomographyImageStorage);
               break;

            case "OP": // Ophthalmic Photography
               AddPresentationContext(DicomUidType.Ophthalmic16BitPhotographyImageStorage);
               AddPresentationContext(DicomUidType.Ophthalmic8BitPhotographyImageStorage);
               AddPresentationContext(DicomUidType.WideFieldOphthalmicPhotography3dCoordinatesImageStorage);
               AddPresentationContext(DicomUidType.WideFieldOphthalmicPhotographyStereographicProjectionImageStorage);
               break;

            case "OPM": // Ophthalmic Mapping
               AddPresentationContext(DicomUidType.OphthalmicThicknessMapStorage);
               break;

            case "OPT": // Ophthalmic Tomography
               AddPresentationContext(DicomUidType.OphthalmicTomographyImageStorage);
               break;

            case "OPV": // Ophthalmic Visual Field
               AddPresentationContext(DicomUidType.OphthalmicVisualFieldStaticPerimetryMeasurementsStorage);
               break;

            case "OSS": // Optical Surface Scan
               AddPresentationContext(DicomUidType.SurfaceScanMeshStorage);
               AddPresentationContext(DicomUidType.SurfaceScanPointCloudStorage);
               break;

            case "OT": // Other
               AddPresentationContext(DicomUidType.SCImageStorage);
               AddPresentationContext(DicomUidType.SCMultiFrameGrayscaleByteImageStorage);
               AddPresentationContext(DicomUidType.SCMultiFrameGrayscaleWordImageStorage);
               AddPresentationContext(DicomUidType.SCMultiFrameSingleBitImageStorage);
               AddPresentationContext(DicomUidType.SCMultiFrameTrueColorImageStorage);
               AddPresentationContext(DicomUidType.CRImageStorage);
               break;

            case "PLAN": // Plan
               AddPresentationContext(DicomUidType.ImplantationPlanSRDocumentStorage);
               AddPresentationContext(DicomUidType.RTIonPlanStorage);
               AddPresentationContext(DicomUidType.RTPlanStorage);
               break;

            case "PR": // Presentation State
               AddPresentationContext(DicomUidType.BasicStructuredDisplayStorage);
                              AddPresentationContext(DicomUidType.BlendingSoftcopyPresentationStateStorage);
               AddPresentationContext(DicomUidType.ColorSoftcopyPresentationStateStorage);
               AddPresentationContext(DicomUidType.GrayscaleSoftcopyPresentationStateStorage);
               AddPresentationContext(DicomUidType.PseudoColorSoftcopyPresentationStateStorage);
               AddPresentationContext(DicomUidType.XAXrfGrayscaleSoftcopyPresentationStateStorage);
               break;

            case "PT": // Positron emission tomography (PET)
               AddPresentationContext(DicomUidType.PETImageStorage);
               AddPresentationContext(DicomUidType.EnhancedPETImageStorage);
               AddPresentationContext(DicomUidType.LegacyConvertedEnhancedPETImageStorage);
               break;

            case "PX": // Panoramic X-Ray
               AddPresentationContext(DicomUidType.DXIntraoralImageStoragePresentation);
               AddPresentationContext(DicomUidType.DXIntraoralImageStorageProcessing);
               AddPresentationContext(DicomUidType.DXImageStoragePresentation);
               AddPresentationContext(DicomUidType.DXImageStorageProcessing);
               break;

            case "REG": // Registration
               AddPresentationContext(DicomUidType.DeformableSpatialRegistrationStorage);
               AddPresentationContext(DicomUidType.SpatialRegistrationStorage);
               break;

            case "RESP": // Respiratory Waveform
               AddPresentationContext(DicomUidType.RespiratoryWaveformStorage);
               break;

            case "RF": // Radio Fluoroscopy
               AddPresentationContext(DicomUidType.XRayRadiofluoroscopicImageStorage);
               break;

            case "RG": // Radiographic imaging (conventional film/screen)
               break;

            case "RTDOSE": // Radiotherapy Dose
               AddPresentationContext(DicomUidType.RTDoseStorage);
               break;

            case "RTIMAGE": // Radiotherapy Image
               AddPresentationContext(DicomUidType.RTImageStorage);
               break;

            case "RTPLAN": // Radiotherapy Plan
               AddPresentationContext(DicomUidType.RTPlanStorage);
               break;

            case "RTRECORD": // RT Treatment Record
               AddPresentationContext(DicomUidType.RTTreatmentSummaryRecordStorageClass);
               break;

            case "RTSTRUCT": // Radiotherapy Structure Set
               AddPresentationContext(DicomUidType.RTStructureStorage);
               break;

            case "RWV": // Real World Value Map
               AddPresentationContext(DicomUidType.RealWorldValueMappingStorage);
               break;

            case "SEG": // Segmentation
               AddPresentationContext(DicomUidType.SegmentationStorage);
               AddPresentationContext(DicomUidType.SurfaceSegmentationStorage);
               break;

            case "SM": // Slide Microscopy
               AddPresentationContext(DicomUidType.VLWholeSlideMicroscopyImageStorage);
               AddPresentationContext(DicomUidType.VLSlideCoordinatesMicroscopicImageStorageClass);
               break;

            case "SMR": // Stereometric Relationship
               AddPresentationContext(DicomUidType.StereometricRelationshipStorage);
               break;

            case "SR": // SR Document
               AddPresentationContext(DicomUidType.ImplantationPlanSRDocumentStorage);
               AddPresentationContext(DicomUidType.BasicTextSR);
               AddPresentationContext(DicomUidType.ChestCadSR);
               AddPresentationContext(DicomUidType.ColonCadSRStorage);
               AddPresentationContext(DicomUidType.Comprehensive3dSRStorage);
               break;

            case "SRF": // Subjective Refraction
               AddPresentationContext(DicomUidType.SubjectiveRefractionMeasurementsStorage);
               break;

            case "STAIN": // Automated Slide Stainer
               AddPresentationContext(DicomUidType.VLWholeSlideMicroscopyImageStorage);
               AddPresentationContext(DicomUidType.VLSlideCoordinatesMicroscopicImageStorageClass);
               break;

            case "TG": // Thermography
               break;

            case "US": // Ultrasound
               AddPresentationContext(DicomUidType.USImageStorage);
               AddPresentationContext(DicomUidType.USImageStorageRetired);
               AddPresentationContext(DicomUidType.USMultiframeImageStorage);
               AddPresentationContext(DicomUidType.USMultiframeImageStorageRetired);
               AddPresentationContext(DicomUidType.EnhancedUSVolumeStorage);
               break;

            case "VA": // Visual Acuity
               AddPresentationContext(DicomUidType.VisualAcuityMeasurementsStorage);
               break;

            case "XA": // X-Ray Angiography
               AddPresentationContext(DicomUidType.XRay3dAngiographicImageStorage);
               AddPresentationContext(DicomUidType.XRay3dCraniofacialImageStorage);
               AddPresentationContext(DicomUidType.XRayRadiationDoseSRStorage);
               AddPresentationContext(DicomUidType.XRayRadiofluoroscopicImageStorage);
               AddPresentationContext(DicomUidType.XAImageStorage);
               break;

            case "XC": // External-camera Photography
               AddPresentationContext(DicomUidType.VideoPhotographicImageStorage);
               AddPresentationContext(DicomUidType.VLPhotographicImageStorageClass);
               break;

            // Retired Defined Terms:
            case "AS": // Angioscopy
               AddPresentationContext(DicomUidType.XRay3dAngiographicImageStorage);
               break;

            case "CD": // Color flow Doppler
               break;

            case "CF": // Cinefluorography
               break;

            case "CP": // Culposcopy
               break;

            case "CS": // Cystoscopy
               break;

            case "DD": // Duplex Doppler
               break;

            case "DF": // Digital fluoroscopy
               break;

            case "DM": // Digital microscopy
               AddPresentationContext(DicomUidType.VideoMicroscopicImageStorage);
               AddPresentationContext(DicomUidType.VLMicroscopicImageStorageClass);
               AddPresentationContext(DicomUidType.VLSlideCoordinatesMicroscopicImageStorageClass);
               AddPresentationContext(DicomUidType.VLWholeSlideMicroscopyImageStorage);
               break;

            case "DS": // Digital Subtraction Angiography
               AddPresentationContext(DicomUidType.XRay3dAngiographicImageStorage);
               AddPresentationContext(DicomUidType.XAImageStorage);
               break;

            case "EC": // Echocardiography
               AddPresentationContext(DicomUidType.CardiacElectrophysiologyWaveformStorage);
               break;

            case "FA": // Fluorescein angiography
               AddPresentationContext(DicomUidType.XRay3dAngiographicImageStorage);
               AddPresentationContext(DicomUidType.XAImageStorage);
               break;

            case "FS": // Fundoscopy
               break;

            case "LP": // Laparoscopy
               break;

            case "MA": // Magnetic resonance angiography
               AddPresentationContext(DicomUidType.MRImageStorage);
               AddPresentationContext(DicomUidType.MRSpectroscopyStorage);
               AddPresentationContext(DicomUidType.EnhancedMRColorImageStorage);
               AddPresentationContext(DicomUidType.EnhancedMRImageStorage);
               break;

            case "MS": // Magnetic resonance spectroscopy
               AddPresentationContext(DicomUidType.MRImageStorage);
               AddPresentationContext(DicomUidType.MRSpectroscopyStorage);
               AddPresentationContext(DicomUidType.EnhancedMRColorImageStorage);
               AddPresentationContext(DicomUidType.EnhancedMRImageStorage);
               break;

            case "OPR": // Ophthalmic Refraction
               AddPresentationContext(DicomUidType.OphthalmicTomographyImageStorage);
               AddPresentationContext(DicomUidType.SubjectiveRefractionMeasurementsStorage);
               break;

            case "ST": // Single-photon emission computed tomography (SPECT)
               AddPresentationContext(DicomUidType.CTImageStorage);
               break;

            case "VF": // Videofluorography
               AddPresentationContext(DicomUidType.VideoEndoscopicImageStorage);
               AddPresentationContext(DicomUidType.VideoMicroscopicImageStorage);
               AddPresentationContext(DicomUidType.VideoPhotographicImageStorage);
               break;
         }
         _isDirtyPresentationContextList = true;
      }

      private bool _isDirtyPresentationContextList;
      private readonly Series _series;
      private List<PresentationContext> _additionalPresentationContexts;
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
}

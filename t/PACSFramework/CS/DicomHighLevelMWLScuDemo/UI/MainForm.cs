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
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Threading;
using System.Management;
using System.Xml.Serialization;
using System.IO;
using System.Security.Permissions;
using System.Net;

using Leadtools;
using Leadtools.Dicom;
using Leadtools.Dicom.Scu;
using Leadtools.Dicom.Scu.Common;
using Leadtools.DicomDemos;
using Leadtools.Demos;
using System.Diagnostics;
using Leadtools.Dicom.Scu.Queries;
using DicomDemo.Properties;
using DicomDemo.Queries;
using Leadtools.Dicom.Common.DataTypes;
using Leadtools.Dicom.Common.DataTypes.Modality;
using Leadtools.Dicom.Common.Extensions;
using Leadtools.Dicom.Common.Editing;
using Leadtools.ImageProcessing;
using Leadtools.ImageProcessing.Core;
using Leadtools.WinForms.CommonDialogs.File;
using Leadtools.Codecs;

namespace DicomDemo
{
    public partial class MainForm : Form
    {
        private const string _sNewline = "\r\n";
        private const string _sNewlineTab = "\r\n\t";
        private const string _sNewlineTabTab = "\r\n\t\t";
        private const string _sConfigurationImplementationClass = "1.2.840.114257.1123456";
        private const string _sConfigurationImplementationVersionName = "1";
        private const string _sConfigurationProtocolversion = "1";

        private QueryRetrieveScu _find;
        private DicomDataSet _MwlFind = null;
        private StoreScu _store;
        private bool _canCancel = false;
        private FindQuery _findQuery = new FindQuery();
        private StudyRootQueryStudy _studyRoot = new StudyRootQueryStudy();
        private TextBoxTraceListener _tracer = null;
        private ToolStripButton patientQuery;
        private ModalityWorklistQuery _query = new ModalityWorklistQuery();
        private PatientBasedQuery _pbQuery = new PatientBasedQuery();
        private BroadBasedQuery _bbQuery = new BroadBasedQuery();
        private MyPerformedProcedureStepScu _modalityPPS = null;
        private List<long> _AllowedSet = new List<long>();
        private bool _CancelStore = false;
        private SaveFileDialog _saveFiledlg;
        // 
        public Scp _mwlServer = new Scp();
        public Scp _mppsServer = new Scp();
        public Scp _storageServer = new Scp();

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

        [Serializable]
        public class ProcedureStep
        {
            private MPPSNCreate _Mpps;

            public MPPSNCreate Mpps
            {
                get { return _Mpps; }
                set { _Mpps = value; }
            }

            private ModalityWorklistResult _Result;

            public ModalityWorklistResult Result
            {
                get { return _Result; }
                set { _Result = value; }
            }

            public ProcedureStep()
            {
            }

            public ProcedureStep(MPPSNCreate mpps, ModalityWorklistResult result)
            {
                _Mpps = mpps;
                _Result = result;
            }
        }


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
#if  !LEADTOOLS_V17_OR_LATER
            RasterCodecs.Startup();
#endif
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new MainForm());
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

        private List<RasterImage> LoadImage()
        {
            List<RasterImage> images = new List<RasterImage>();
            RasterCodecs codecs = null;
            ImageFileLoader loader = null;

            try
            {
                loader = new ImageFileLoader();
                codecs = new RasterCodecs();
                loader.MultiSelect = true;
                loader.ShowLoadPagesDialog = true;
                loader.Images.Clear();
                int filesCount = loader.Load(this, codecs, true);
                if (filesCount > 0)
                {
                    for (int fileNum = 0; fileNum < filesCount; fileNum++)
                    {
                        RasterImage img = loader.Images[fileNum].Image;
                        for (int pageNum = 1; pageNum <= img.PageCount; pageNum++)
                        {
                            img.Page = pageNum;
                            images.Add(img.Clone());
                        }
                        img.Dispose();
                    }
                }
            }
            catch (Exception ex)
            {
                Messager.ShowFileOpenError(this, loader.FileName, ex);
            }

            if (codecs != null)
                codecs.Dispose();

            return images;
        }

        public MainForm()
        {
            InitializeComponent();
            if (!DicomDemoSettingsManager.Is64Process())
                Text = Text + " (32 bit)";
            else
                Text = Text + "(64 bit)";
            InitializeAllowList();

            _saveFiledlg = new SaveFileDialog();
            _saveFiledlg.Filter = "Dicom Files (*.dcm)|*.dcm";
            _saveFiledlg.DefaultExt = "dcm";
        }

        private void InitializeAllowList()
        {
            _AllowedSet.Add(DicomTag.ServiceEpisodeID);
            _AllowedSet.Add(DicomTag.IssuerOfServiceEpisodeID);
            _AllowedSet.Add(DicomTag.ServiceEpisodeDescription);
            _AllowedSet.Add(DicomTag.PerformedProcedureStepDescription);
            _AllowedSet.Add(DicomTag.PerformedProcedureTypeDescription);
            _AllowedSet.Add(DicomTag.PerformedProcedureCodeSequence);
            _AllowedSet.Add(DicomTag.PerformedProcedureStepEndDate);
            _AllowedSet.Add(DicomTag.PerformedProcedureStepEndTime);
            _AllowedSet.Add(DicomTag.CommentsOnThePerformedProcedureStep);
            _AllowedSet.Add(DicomTag.PerformedProcedureStepDiscontinuationReasonCodeSequence);
            _AllowedSet.Add(DicomTag.PerformedProtocolCodeSequence);
            _AllowedSet.Add(DicomTag.PerformedSeriesSequence);
            _AllowedSet.Add(DicomTag.PerformingPhysicianName);
            _AllowedSet.Add(DicomTag.ProtocolName);
            _AllowedSet.Add(DicomTag.OperatorName);
            _AllowedSet.Add(DicomTag.SeriesInstanceUID);
            _AllowedSet.Add(DicomTag.SeriesDescription);
            _AllowedSet.Add(DicomTag.RetrieveAETitle);
            _AllowedSet.Add(DicomTag.ArchiveRequested);
        }

        private void SizeColumns(ListView lv)
        {
            foreach (ColumnHeader header in lv.Columns)
            {
                header.Width = lv.Width / lv.Columns.Count;
            }
        }

        private void _listViewWorkItems_Resize(object sender, EventArgs e)
        {
            SizeColumns(_listViewWorkItems);
        }

        DialogResult DoOptions()
        {
            OptionsDialog options = new OptionsDialog();
            options.ServerList = _mySettings.ServerList;

            options.ClientAE = _mySettings.ClientAe.AE;
            options.ClientCertificate = _mySettings.ClientCertificate;
            options.PrivateKey = _mySettings.ClientPrivateKey;
            options.PrivateKeyPassword = _mySettings.ClientPrivateKeyPassword;
            options.LogLowLevel = _mySettings.LogLowLevel;
            options.GroupLengthDataElements = _mySettings.GroupLengthDataElements;
            options.Mwl = _mySettings.DefaultMwlQuery;
            options.Mpps = _mySettings.DefaultMpps;
            options.Storage = _mySettings.DefaultStore;
            options.CipherSuites = _mySettings.CipherSuites;

            DialogResult dr = options.ShowDialog(this);
            if (dr == DialogResult.OK)
            {
                _mySettings.ServerList = options.ServerList;
                _mySettings.ClientAe.AE = options.ClientAE;
                _mySettings.ClientCertificate = options.ClientCertificate;
                _mySettings.ClientPrivateKey = options.PrivateKey;
                _mySettings.ClientPrivateKeyPassword = options.PrivateKeyPassword;
                _mySettings.LogLowLevel = options.LogLowLevel;
                _mySettings.GroupLengthDataElements = options.GroupLengthDataElements;
                _mySettings.DefaultMwlQuery = options.Mwl;
                _mySettings.DefaultMpps = options.Mpps;
                _mySettings.DefaultStore = options.Storage;

                _mySettings.CipherSuites = options.CipherSuites;
                UpdateComboBoxServices();
                MySaveSettings();
            }
            return dr;
        }

        private const string defaultServerAE = "LEAD_SERVER";
        private const string defaultServerIP = "127.0.0.1";
        private const int defaultServerPort = 104;
        private const int defaultServerTimeout = 30;
        private const bool defaultServerUseTls = false;
        private const int defaultCompression = 2;

        private const string defaultClientAE = "LEAD_CLIENT";
        private const int defaultClientPort = 1000;

        private void SetOtherDefaults(DicomDemoSettings settings)
        {
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

            settings.DefaultMwlQuery = serverAE.AE;
            settings.DefaultMpps = serverAE.AE;
            settings.DefaultStore = serverAE.AE;
            SetOtherDefaults(settings);
            return settings;
        }

        private void SetDefaultServer(Scp scp, string serverAe)
        {
            DicomAE defaultAE = _mySettings.GetServer(serverAe);

            if (null != defaultAE)
            {
                scp.AETitle = defaultAE.AE;
                scp.Port = (int)defaultAE.Port;
                scp.PeerAddress = IPAddress.Parse(defaultAE.IPAddress);
                scp.Timeout = defaultAE.Timeout;
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
                    }
                }

                SetDefaultServer(_storageServer, _mySettings.DefaultStore);
                SetDefaultServer(_mwlServer, _mySettings.DefaultMwlQuery);
                SetDefaultServer(_mppsServer, _mySettings.DefaultMpps);
                patientQuery.Checked = !_mySettings.BroadQuery;
                _mySettings.FirstRun = false;
                MySaveSettings();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Assert(false, ex.Message);
            }
        }

      bool GetDefaultUseTls(string ae)
      {
         bool useTls = false;
         DicomAE defaultAE = _mySettings.GetServer(ae);
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

            bool useTls = GetDefaultUseTls(_mySettings.DefaultMwlQuery);
            if (useTls)
            {
#if LEADTOOLS_V20_OR_LATER
            const DicomNetSecurityMode securityMode = DicomNetSecurityMode.Tls;
#else
               const DicomNetSecurityeMode securityMode = DicomNetSecurityeMode.Tls;
#endif
                _find = new QueryRetrieveScu(string.Empty, securityMode, null);
            }
            else
            {
                _find = new QueryRetrieveScu();
            }

            _find.MaxLength = 46726;
            _find.ImplementationClass = _sConfigurationImplementationClass;
            _find.ProtocolVersion = _sConfigurationProtocolversion;
            _find.ImplementationVersionName = _sConfigurationImplementationVersionName;
            _find.AETitle = _mySettings.ClientAe.AE;
#if LEADTOOLS_V19_OR_LATER
         _find.Flags = DicomNetFlags.None;
         if (_mySettings.GroupLengthDataElements)
         {
            _find.Flags |= DicomNetFlags.SendDataWithGroupLengthStandardDataElements;
         }
#endif

            _find.BeforeConnect += new Leadtools.Dicom.Scu.Common.BeforeConnectDelegate(BeforeConnect);
            _find.AfterConnect += new Leadtools.Dicom.Scu.Common.AfterConnectDelegate(AfterConnect);
            _find.BeforeAssociateRequest += new Leadtools.Dicom.Scu.Common.BeforeAssociationRequestDelegate(BeforeAssociateRequest);
            _find.AfterAssociateRequest += new Leadtools.Dicom.Scu.Common.AfterAssociateRequestDelegate(AfterAssociateRequest);
            _find.BeforeCFind += new Leadtools.Dicom.Scu.Common.BeforeCFindDelegate(_find_BeforeCFind);
            _find.AfterCFind += new Leadtools.Dicom.Scu.Common.AfterCFindDelegate(_find_AfterCFind);

            _find.AfterSecureLinkReady += new AfterSecureLinkReadyDelegate(AfterSecureLinkReady);
            _find.PrivateKeyPassword += new PrivateKeyPasswordDelegate(PrivateKeyPassword);

            if (useTls)
            {
                try
                {
                    SetCipherSuites(_find);
                    _find.SetTlsClientCertificate(_mySettings.ClientCertificate, DicomTlsCertificateType.Pem,
                                                  _mySettings.ClientPrivateKey.Length > 0 ? _mySettings.ClientPrivateKey : null);
                }
                catch (Exception ex)
                {
                    LogError(ex.Message);
                }
            }

            if (_mySettings.LogLowLevel)
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
            _find.DebugLogFilename = string.Empty;
            _find.EnableDebugLog = true;
            SetDefaultServer(this._mwlServer, _mySettings.DefaultMwlQuery);
            SetLabelInfo(toolStripStatusLabelMWL, toolStripComboBoxMWLScp.ComboBox);
        }

        private void CreateModalityPPSObject()
        {
            if (_modalityPPS != null)
            {
                _modalityPPS.Dispose();
            }

            bool useTls = GetDefaultUseTls(_mySettings.DefaultMpps);
            if (useTls)
            {
#if LEADTOOLS_V20_OR_LATER
            const DicomNetSecurityMode securityMode = DicomNetSecurityMode.Tls;
#else
            const DicomNetSecurityeMode securityMode = DicomNetSecurityeMode.Tls;
#endif
                _modalityPPS = new MyPerformedProcedureStepScu(this, string.Empty, securityMode, null);
            }
            else
            {
                _modalityPPS = new MyPerformedProcedureStepScu(this);
            }

            _modalityPPS.ImplementationClass = _sConfigurationImplementationClass;
            _modalityPPS.ProtocolVersion = _sConfigurationProtocolversion;
            _modalityPPS.ImplementationVersionName = _sConfigurationImplementationVersionName;
            _modalityPPS.AETitle = _mySettings.ClientAe.AE;

            _modalityPPS.BeforeConnect += new BeforeConnectDelegate(BeforeConnect);
            _modalityPPS.AfterConnect += new AfterConnectDelegate(AfterConnect);
            _modalityPPS.BeforeAssociateRequest += new BeforeAssociationRequestDelegate(BeforeAssociateRequest);
            _modalityPPS.AfterAssociateRequest += new AfterAssociateRequestDelegate(AfterAssociateRequest);
            _modalityPPS.AfterSecureLinkReady += new AfterSecureLinkReadyDelegate(AfterSecureLinkReady);
            _modalityPPS.PrivateKeyPassword += new PrivateKeyPasswordDelegate(PrivateKeyPassword);

            _modalityPPS.AfterNCreate += new EventHandler<StatusCommonEventArgs>(_modalityPPS_AfterNCreate);
            _modalityPPS.AfterNSet += new EventHandler<StatusCommonEventArgs>(_modalityPPS_AfterNSet);

            if (useTls)
            {
                try
                {
                    SetCipherSuites(_modalityPPS);
                    _modalityPPS.SetTlsClientCertificate(_mySettings.ClientCertificate, DicomTlsCertificateType.Pem,
                                                  _mySettings.ClientPrivateKey.Length > 0 ? _mySettings.ClientPrivateKey : null);
                }
                catch (Exception ex)
                {
                    LogError(ex.Message);
                }
            }

            _modalityPPS.DebugLogFilename = string.Empty;
            _modalityPPS.EnableDebugLog = true;
            SetDefaultServer(this._mppsServer, _mySettings.DefaultMpps);
            SetLabelInfo(toolStripStatusLabelMPPS, toolStripComboBoxMPPSScp.ComboBox);
        }

        void _modalityPPS_AfterNSet(object sender, StatusCommonEventArgs e)
        {
            if (_mySettings.LogLowLevel)
            {
                string sMsg =
                   _sNewlineTab + "presentationID:\t" + e.PresentationID.ToString() +
                   _sNewlineTab + "messageID:\t" + e.MessageID.ToString() +
                   _sNewlineTab + "affectedClass:\t" + e.AffectedClass +
                   _sNewlineTab + "instance:\t" + e.Instance +
                   _sNewlineTab + "status:\t" + e.Status.ToString();

                LogText("AfterNSet", sMsg, System.Drawing.Color.Green);
            }
        }

        void _modalityPPS_AfterNCreate(object sender, StatusCommonEventArgs e)
        {
            if (_mySettings.LogLowLevel)
            {
                string sMsg =
                   _sNewlineTab + "presentationID:\t" + e.PresentationID.ToString() +
                   _sNewlineTab + "messageID:\t" + e.MessageID.ToString() +
                   _sNewlineTab + "affectedClass:\t" + e.AffectedClass +
                   _sNewlineTab + "instance:\t" + e.Instance +
                   _sNewlineTab + "status:\t" + e.Status.ToString();

                LogText("AfterNCreate", sMsg, System.Drawing.Color.Green);
            }
        }


        private void CreateCStoreObject()
        {
            if (_store != null)
            {
                _store.Dispose();
            }
            bool useTls = GetDefaultUseTls(_mySettings.DefaultStore);
            if (useTls)
            {
#if LEADTOOLS_V20_OR_LATER
            const DicomNetSecurityMode securityMode = DicomNetSecurityMode.Tls;
#else
            const DicomNetSecurityeMode securityMode = DicomNetSecurityeMode.Tls;
#endif
                _store = new StoreScu(string.Empty, securityMode, null);
            }
            else
            {
                _store = new StoreScu();
            }

            _store.MaxLength = 46726;
            _store.ImplementationClass = _sConfigurationImplementationClass;
            _store.ImplementationVersionName = _sConfigurationImplementationVersionName;
            _store.ProtocolVersion = _sConfigurationProtocolversion;
            _store.AETitle = _mySettings.ClientAe.AE;

            _store.BeforeConnect += new BeforeConnectDelegate(BeforeConnect);
            _store.AfterConnect += new AfterConnectDelegate(AfterConnect);
            _store.BeforeAssociateRequest += new BeforeAssociationRequestDelegate(BeforeAssociateRequest);
            _store.AfterAssociateRequest += new AfterAssociateRequestDelegate(AfterAssociateRequest);
            _store.AfterSecureLinkReady += new AfterSecureLinkReadyDelegate(AfterSecureLinkReady);
            _store.PrivateKeyPassword += new PrivateKeyPasswordDelegate(PrivateKeyPassword);

            _store.BeforeCStore += new BeforeCStoreDelegate(_store_BeforeCStore);
            _store.AfterCStore += new AfterCStoreDelegate(_store_AfterCStore);

            if (useTls)
            {
                try
                {
                     SetCipherSuites(_store);
                    _store.SetTlsClientCertificate(_mySettings.ClientCertificate, DicomTlsCertificateType.Pem,
                                                   _mySettings.ClientPrivateKey.Length > 0 ? _mySettings.ClientPrivateKey : null);
                }
                catch (Exception ex)
                {
                    LogError(ex.Message);
                }
            }

            _store.DebugLogFilename = string.Empty;
            _store.EnableDebugLog = true;
            SetDefaultServer(this._storageServer, _mySettings.DefaultStore);
            SetLabelInfo(toolStripStatusLabelStore, toolStripComboBoxStoreScp.ComboBox);
        }

        void _store_AfterCStore(object sender, AfterCStoreEventArgs e)
        {
            string message;

            if (e.Status == DicomCommandStatusType.Success)
            {
                message = _sNewlineTab + "Success";
                if (e.FileInfo != null)
                    message += _sNewlineTab + "Filename: " + e.FileInfo.FullName;
            }
            else
            {
                message =
                   _sNewlineTab + "CStore Failed" +
                   _sNewlineTab + "Status: " + e.Status.ToString();
            }
            LogText("After CStore", message);
        }

        void _store_BeforeCStore(object sender, BeforeCStoreEventArgs e)
        {
            string fileinfo = string.Empty;

            if (e.FileInfo != null)
                fileinfo = _sNewlineTab + "Filename: " + e.FileInfo.FullName;
            LogText("Before CStore", fileinfo);
        }

      void AfterSecureLinkReady(object sender, AfterSecureLinkReadyEventArgs e)
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

      void PrivateKeyPassword(object sender, PrivateKeyPasswordEventArgs e)
        {
            e.PrivateKeyPassword = _mySettings.ClientPrivateKeyPassword;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Application.ApplicationExit += new EventHandler(Application_ApplicationExit);

            StatusText(string.Empty);
            SizeColumns(_listViewWorkItems);
            AddPropertyGridButtons();
            LoadSettings();
            UpdateComboBoxServices();
            EnableItems(true);

            patientQuery_CheckedChanged(null, EventArgs.Empty);
            LoadProcedureStep();
        }

        private void AddPropertyGridButtons()
        {
            ToolStrip toolStrip = null;

            foreach (Control control in _propertyGrid.Controls)
            {
                if (control is ToolStrip)
                {
                    toolStrip = control as ToolStrip;
                    break;
                }
            }

            if (toolStrip != null)
            {
                toolStrip.Items.Add(new ToolStripSeparator());
                patientQuery = new ToolStripButton("Patient", Resources.Patient);
                patientQuery.DisplayStyle = ToolStripItemDisplayStyle.Image;
                patientQuery.CheckOnClick = true;
                patientQuery.CheckedChanged += new EventHandler(patientQuery_CheckedChanged);
                toolStrip.Items.Add(patientQuery);
            }
        }

        void patientQuery_CheckedChanged(object sender, EventArgs e)
        {
            if (patientQuery.Checked)
            {
                _propertyGrid.SelectedObject = _pbQuery;
            }
            else
            {
                _propertyGrid.SelectedObject = _bbQuery;
            }

            //
            // Save Query Option
            //
            _mySettings.BroadQuery = !patientQuery.Checked;
            MySaveSettings();
        }

        void Application_ApplicationExit(object sender, EventArgs e)
        {
#if  !LEADTOOLS_V17_OR_LATER
            RasterCodecs.Shutdown();
#endif
            Utils.EngineShutdown();
            Utils.DicomNetShutdown();
        }

        private void AddAction(string sAction)
        {
            AddAction(sAction, Color.Blue);
        }

        private void AddAction(string sAction, Color color)
        {
            System.Drawing.Color oldColor = _richTextBoxLog.SelectionColor;

            _richTextBoxLog.SelectionLength = 0;
            _richTextBoxLog.SelectionStart = _richTextBoxLog.Text.Length;
            _richTextBoxLog.SelectionColor = color;
            _richTextBoxLog.SelectionFont = new Font(_richTextBoxLog.SelectionFont, FontStyle.Bold);
            _richTextBoxLog.AppendText(sAction + ": ");
            _richTextBoxLog.SelectionColor = oldColor;
        }

        public void LogText(string sAction, string sLogText, Color sActionColor)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new AddLog(LogText), new object[] { sAction, sLogText, sActionColor });
            }
            else
            {
                AddAction(sAction, sActionColor);
                _richTextBoxLog.AppendText(sLogText);
                _richTextBoxLog.AppendText(_sNewline);
                TextBoxTraceListener.SendMessage(_richTextBoxLog.Handle, TextBoxTraceListener.WM_VSCROLL, TextBoxTraceListener.SB_BOTTOM, 0);
            }
        }

        public void LogText(string sAction, string sLogText)
        {
            LogText(sAction, sLogText, Color.Blue);
        }

        public void LogError(string sLogText)
        {
            LogText("*** ERROR *** ", _sNewlineTab + sLogText, Color.Red);
        }


        void BeforeConnect(object sender, Leadtools.Dicom.Scu.Common.BeforeConnectEventArgs e)
        {
            LogText("Before Connect", e.Scp.ToString());

        }
        void AfterConnect(object sender, Leadtools.Dicom.Scu.Common.AfterConnectEventArgs e)
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

        void BeforeAssociateRequest(object sender, Leadtools.Dicom.Scu.Common.BeforeAssociateRequestEventArgs e)
        {
            LogText("Before Associate Request", e.Associate.ToString());
        }

        void AfterAssociateRequest(object sender, Leadtools.Dicom.Scu.Common.AfterAssociateRequestEventArgs e)
        {
            string message = string.Empty;

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
                if (e.Associate != null)
                    message = _sNewlineTab + "Association Accepted" + e.Associate.ToString();
            }
            LogText("After Associate Request", message);
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

        public delegate void StartUpdateDelegate(ListView lv);
        private void StartUpdate(ListView lv)
        {
            if (InvokeRequired)
            {
                Invoke(new StartUpdateDelegate(StartUpdate), lv);
            }
            else
            {
                foreach (ListViewItem item in lv.Items)
                {
                    ModalityWorklistResult result = item.Tag as ModalityWorklistResult;

                    if (result != null)
                        (result.Tag as DicomDataSet).Dispose();
                }
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


        public delegate void AddResultItemDelegate(ModalityWorklistResult result);
        private void AddResultItem(ModalityWorklistResult result)
        {
            ListViewItem item;

            if (InvokeRequired)
            {
                Invoke(new AddResultItemDelegate(AddResultItem), result);
            }
            else
            {
                item = _listViewWorkItems.Items.Add(result.AccessionNumber);
                item.SubItems.Add(result.PatientId);
                item.SubItems.Add(result.PatientName.Full);
                item.SubItems.Add(result.PatientBirthDate.HasValue ? result.PatientBirthDate.Value.ToShortDateString() : string.Empty);
                item.SubItems.Add(result.PatientSex);
                if (result.ScheduledProcedureStepSequence != null && result.ScheduledProcedureStepSequence.Count > 0)
                {
                    if (result.ScheduledProcedureStepSequence[0].ScheduledProcedureStepStartDate.HasValue)
                        item.SubItems.Add(result.ScheduledProcedureStepSequence[0].ScheduledProcedureStepStartDate.Value.ToShortDateString());
                    else
                        item.SubItems.Add(string.Empty);
                    item.SubItems.Add(result.ScheduledProcedureStepSequence[0].Modality);
                    item.SubItems.Add(result.ScheduledProcedureStepSequence[0].ScheduledStationAeTitle);
                    item.SubItems.Add(result.ScheduledProcedureStepSequence[0].ScheduledProcedureStepDescription);
                }

                item.Tag = result;
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
                buttonCancel.Enabled = _canCancel;
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
                _menuStrip.Enabled = enable;

                _listViewWorkItems.Enabled = enable;
                buttonSearch.Enabled = enable;
                buttonCancel.Enabled = !enable && _canCancel;
                listViewInProgress.Enabled = enable;
                buttonCreateMPPS.Enabled = enable && _listViewWorkItems.SelectedItems.Count == 1;
                saveAsDicomFileToolStripMenuItem.Enabled = _listViewWorkItems.SelectedItems.Count > 0;
            }
        }

        private bool OnBeforeAdd(LinkedList<long> parent, object data, long tag)
        {
            return _mySettings.ExcludeList.Contains(tag);
        }

        private ModalityWorklistQuery GetQueryParams()
        {
            ModalityWorklistQuery query = new ModalityWorklistQuery();

            if (patientQuery.Checked)
            {
                query.PatientName = _pbQuery.PatientName;
                query.PatientId = _pbQuery.PatientId;
                query.RequestedProcedureId = _pbQuery.RequestedProcedureId;
                query.AccessionNumber = _pbQuery.AccessionNumber;
            }
            else
            {
               BroadQuery bq = new BroadQuery();

#if (LEADTOOLS_V19_OR_LATER)
               bq.ScheduledProcedureStepStartDate = _bbQuery.ScheduledProcedureStepStartDate;
#else
               if (_bbQuery.ScheduledProcedureStepStartDate.StartDate != DateTime.MinValue)
                  bq.ScheduledProcedureStepStartDate = _bbQuery.ScheduledProcedureStepStartDate.StartDate;
               else
                  bq.ScheduledProcedureStepStartDate = null;
#endif

                bq.Modality = _bbQuery.Modality;
                bq.ScheduledStationAeTitle = _bbQuery.ScheduledStationAeTitle;
                query.Broad.Add(bq);
            }
            return query;
        }

        private void ShowProgress(bool show)
        {
            if (show)
            {
                toolStripProgressBar.MarqueeAnimationSpeed = 30;
                toolStripProgressBar.Visible = true;
            }
            else
            {
                toolStripProgressBar.Visible = false;
                toolStripProgressBar.MarqueeAnimationSpeed = 0;
            }
        }

        private void FoundMatch(ModalityWorklistResult result, DicomDataSet ds)
        {
            string message =
            _sNewlineTab + "Accession #:\t\t " + result.AccessionNumber +
            _sNewlineTab + "Patient Name:\t\t" + result.PatientName.Full;
            
            if ((result.ScheduledProcedureStepSequence.Count > 0) &&  result.ScheduledProcedureStepSequence[0].ScheduledProcedureStepStartDate.HasValue)
            {
               message +=_sNewlineTab + "Scheduled Start Date:\t" + result.ScheduledProcedureStepSequence[0].ScheduledProcedureStepStartDate.Value.ToShortDateString();
            }
            LogText("Worklist Item Found", message);

            if (ds != null)
            {
                DicomDataSet data = new DicomDataSet();

                data.Copy(ds, null, null);
                result.Tag = data;
            }
            AddResultItem(result);
        }

        private void SearchThread(object q)
        {
            ModalityWorklistQuery query = q as ModalityWorklistQuery;

            try
            {
                _find.Find<ModalityWorklistQuery, ModalityWorklistResult>(_mwlServer, query,
                                                                          new DicomMatchDelegate<ModalityWorklistResult>(FoundMatch),
                                                                          _MwlFind);
            }
            catch (Exception ex)
            {
                LogError(ex.Message);

                if (string.Compare(ex.Message, "The attempt to connect was forcefully rejected", true) == 0)
                {
                    if (_mySettings.IsPreconfigured)
                    {
                        //string 
                        string sImportant = string.Format("\n\tThis demo is preconfigured to communicate with {0} DICOM Service.\n\tTo start the service:\n\t* Run CSLeadtools.Dicom.Server.Manager.exe\n\t* Select the {0} service\n\t* Click the 'Start Server' button (blue triangle) to start the DICOM service.", _mySettings.GetServerAe(_mySettings.DefaultMwlQuery));
                        LogText("*** IMPORTANT ***", sImportant, Color.Red);
                    }
                }
            }
        }

        private void DoSearch()
        {
            ModalityWorklistQuery query = GetQueryParams();

            if (_find == null)
                CreateCFindObject();
            if (_modalityPPS == null)
                CreateModalityPPSObject();

            EnableItems(false);
            StartUpdate(_listViewWorkItems);
            _find.AETitle = _mySettings.ClientAe.AE;

            ShowProgress(true);
            Thread t = new Thread(new ParameterizedThreadStart(SearchThread));
            t.Start(query);
            while (t.IsAlive)
            {
                Application.DoEvents();
            }
            ShowProgress(false);
            EnableItems(true);
            if (_listViewWorkItems.Items.Count > 0)
            {
                _listViewWorkItems.Items[0].Selected = true;
                _listViewWorkItems.Focus();
            }
            EndUpdate(_listViewWorkItems);
            StatusText(string.Empty);
        }

        private void DoMPPSCreate(MPPSNCreate mpps)
        {
            EnableItems(false);
            ShowProgress(true);
            Thread t = new Thread(delegate()
            {
                try
                {
                    _modalityPPS.AETitle = _mySettings.ClientAe.AE;
                    _modalityPPS.Status = DicomCommandStatusType.Failure;
                    _modalityPPS.Create<MPPSNCreate>(_mppsServer, mpps, true, new BeforeAddTagDelegate(OnBeforeAdd));
                }
                catch (Exception ex)
                {
                    LogError(ex.Message);

                    if (string.Compare(ex.Message, "The attempt to connect was forcefully rejected", true) == 0)
                    {
                        if (_mySettings.IsPreconfigured)
                        {
                            //string 
                            string sImportant = string.Format("\n\tThis demo is preconfigured to communicate with {0} DICOM Service.\n\tTo start the service:\n\t* Run CSLeadtools.Dicom.Server.Manager.exe\n\t* Select the {0} service\n\t* Click the 'Start Server' button (blue triangle) to start the DICOM service.", _mySettings.GetServerAe(_mySettings.DefaultMpps));
                            LogText("*** IMPORTANT ***", sImportant, Color.Red);
                        }
                    }
                }

            });
            t.Start();
            while (t.IsAlive)
            {
                Application.DoEvents();
                Thread.Sleep(0);
            }
            ShowProgress(false);
            if (_modalityPPS.Status == DicomCommandStatusType.Success)
            {
                ListViewItem item = AddProcedureStep(mpps);

                item.Selected = true;
                listViewInProgress.EnsureVisible(item.Index);
            }
            EnableItems(true);
            StatusText(string.Empty);
        }

        private void DoCancel()
        {
            bool cancelled = false;

            if (_find.IsAssociated())
            {
                _find.CancelRequest();
                cancelled = true;
            }

            if (_modalityPPS.IsAssociated())
            {
                _modalityPPS.CancelRequest();
                cancelled = true;
            }

            if (_store.IsAssociated())
            {
                _store.CancelRequest();
                _CancelStore = true;
            }

            if (cancelled)
            {
                LogText("Cancelled", _sNewlineTab + "Sent C-Cancel");
                StatusText("Cancelled");
            }
        }

        private void _listViewWorkItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            buttonCreateMPPS.Enabled = _listViewWorkItems.SelectedItems.Count > 0;
            saveAsDicomFileToolStripMenuItem.Enabled = _listViewWorkItems.SelectedItems.Count > 0;
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
            AboutDialog dlg = new AboutDialog("DICOM High Level Modality Worklist Client");

            dlg.ShowDialog(this);
        }

        private void _toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            _richTextBoxLog.Clear();
        }

        private void Options_Click(object sender, EventArgs e)
        {
            // Check if the options have changed
            if (DialogResult.OK == DoOptions())
            {
                //CreateCFindObject();
                //CreateModalityPPSObject();
                //CreateCStoreObject();
            }
        }

        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Options_Click(sender, e);
        }

        private void StatusText(string s)
        {
            Application.DoEvents();
        }

        private void _buttonSearch_Click(object sender, EventArgs e)
        {
            if (_MwlFind == null)
            {
                using (MemoryStream stream = new MemoryStream(ASCIIEncoding.ASCII.GetBytes(Templates.MWLFind)))
                {
                    stream.Position = 0;
                    _MwlFind = new DicomDataSet();
                    _MwlFind.LoadXml(stream, DicomDataSetLoadXmlFlags.None);
                }
            }
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
            SaveProcedureStep();
            Utils.EngineShutdown();
            Utils.DicomNetShutdown();
        }

        private void showHelpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HelpDialog dlg = new HelpDialog(_mySettings.GetServerAe(_mySettings.DefaultMwlQuery), false);
            dlg.ShowDialog(this);
        }

        private object fileLock = new object();

        private void MySaveSettings()
        {
         lock(fileLock)
         {
            try
            {
            DicomDemoSettingsManager.SaveSettings(_demoName, _mySettings);
            }
            catch(Exception)
            {
            }
         }
        }

        private void MainForm_Activated(object sender, EventArgs e)
        {
            base.Activate();
            if (_firstTime && _mySettings.ShowHelpOnStart)
            {
                _firstTime = false;
                HelpDialog dlg = new HelpDialog(_mySettings.GetServerAe(_mySettings.DefaultMwlQuery), _mySettings.ShowHelpOnStart);
                dlg.ShowDialog(this);
                if (dlg.CheckBoxNoShowAgainResult)
                {
                   _mySettings.ShowHelpOnStart = false;
                   MySaveSettings();
                }
            }
        }

        private void _listViewWorkItems_DoubleClick(object sender, EventArgs e)
        {
            if (_listViewWorkItems.SelectedItems.Count == 1)
            {
                ModalityWorklistResult result = _listViewWorkItems.SelectedItems[0].Tag as ModalityWorklistResult;
                DicomViewer viewer = new DicomViewer(result.Tag as DicomDataSet);

                viewer.ShowDialog(this);
            }
        }

        private void buttonCreateMPPS_Click(object sender, EventArgs e)
        {
            ModalityWorklistResult result = _listViewWorkItems.SelectedItems[0].Tag as ModalityWorklistResult;
            MPPSNCreate mpps = MPPSNCreate.FromWorklistItem(result);
            DicomEditor editor = null;

            mpps.PerformedStationAeTitle = Environment.MachineName;
            mpps.PerformedStationName = Environment.MachineName;
            mpps.PerformedProcedureStepStartDate = DateTime.Now;
            mpps.PerformedProcedureStepStartTime = DateTime.Now;
            mpps.PerformedSeriesSequence = new List<PerformedSeries>();
            mpps.PerformedSeriesSequence.Add(new PerformedSeries());
            mpps.PerformedSeriesSequence[0].ProtocolName = MPPSNCreate.RandomId(16);
            mpps.PerformedSeriesSequence[0].SeriesInstanceUID = Utils.GenerateDicomUniqueIdentifier();
            mpps.SOPInstance.SOPInstanceUid = Utils.GenerateDicomUniqueIdentifier();

            editor = new DicomEditor(_mySettings.ExcludeList);

            if (editor.Edit<MPPSNCreate>(this, ref mpps, new Action<BeforeAddElementEventArgs>(OnCheckProperty)) == DialogResult.OK)
            {
                DoMPPSCreate(mpps);
            }
        }

        private void buttonEditMPPSDataset_Click(object sender, EventArgs e)
        {
            MPPSDatasetEditor editor = new MPPSDatasetEditor();

            editor.ExcludeList.AddRange(_mySettings.ExcludeList);
            if (editor.ShowDialog(this) == DialogResult.OK)
            {
                _mySettings.ExcludeList.Clear();
                _mySettings.ExcludeList.AddRange(editor.ExcludeList);
                MySaveSettings();
            }
        }

        private ListViewItem AddProcedureStep(MPPSNCreate mpps)
        {
            ListViewItem item = listViewInProgress.Items.Add(mpps.ScheduledStepAttributeSequence[0].AccessionNumber);
            ModalityWorklistResult result = _listViewWorkItems.SelectedItems[0].Tag as ModalityWorklistResult;

            item.SubItems.Add(mpps.PatientId);
            item.SubItems.Add(mpps.Modality);
            item.SubItems.Add(mpps.PerformedProcedureStepStartDate.Value.ToShortDateString());
            item.SubItems.Add(mpps.PerformedProcedureStepStartTime.Value.ToShortTimeString());
            item.SubItems.Add(mpps.PerformedProcedureStepId);
            item.SubItems.Add(mpps.PerformedStationAeTitle);
            item.SubItems.Add(mpps.PerformedStationName);
            item.Tag = new ProcedureStep(mpps, result);
            return item;
        }

        private ListViewItem AddProcedureStep(ProcedureStep ps)
        {
            ListViewItem item = listViewInProgress.Items.Add(ps.Mpps.ScheduledStepAttributeSequence[0].AccessionNumber);

            item.SubItems.Add(ps.Mpps.PatientId);
            item.SubItems.Add(ps.Mpps.Modality);
            item.SubItems.Add(ps.Mpps.PerformedProcedureStepStartDate.Value.ToShortDateString());
            item.SubItems.Add(ps.Mpps.PerformedProcedureStepStartTime.Value.ToShortTimeString());
            item.SubItems.Add(ps.Mpps.PerformedProcedureStepId);
            item.SubItems.Add(ps.Mpps.PerformedStationAeTitle);
            item.SubItems.Add(ps.Mpps.PerformedStationName);
            item.Tag = ps;
            return item;
        }

        private void listViewInProgress_SelectedIndexChanged(object sender, EventArgs e)
        {
            buttonSetMPPS.Enabled = listViewInProgress.SelectedItems.Count > 0;
            buttonAddImage.Enabled = buttonSetMPPS.Enabled;
            buttonCancelMPPS.Enabled = buttonSetMPPS.Enabled;
            buttonCompleteMPPS.Enabled = buttonSetMPPS.Enabled;
        }

        private void OnCheckProperty(BeforeAddElementEventArgs e)
        {
            if (!_AllowedSet.Contains(e.Element.DicomElement.Tag))
                e.Element.Attributes.Add(new ReadOnlyAttribute(true));
        }

        private void toolStripButtonAddImage_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                ProcedureStep ps = listViewInProgress.SelectedItems[0].Tag as ProcedureStep;

                _CancelStore = false;
                try
                {
                    EnableItems(false);
                    ShowProgress(true);
                    DoStore(openFileDialog.FileNames, ps);
                }
                finally
                {
                    EnableItems(true);
                    ShowProgress(false);
                }
            }
        }

        private void DoStore(string[] filenames, ProcedureStep ps)
        {
            bool bShowImportantMessage = false;

            foreach (string file in filenames)
            {
                if (_CancelStore)
                    break;

                Application.DoEvents();
                try
                {
                    using (DicomDataSet ds = new DicomDataSet())
                    {
                        SopInstanceReference instance;

                        ds.Load(file, DicomDataSetLoadFlags.None);
                        UpdateDataset(ds, ps);

                        if (_mySettings.ViewerBeforeSend)
                        {
                            DicomViewer dcmViewer = new DicomViewer(ds);

                            dcmViewer.Text = "DICOM Dataset Viewer (Dataset to store for MPPS)";
                            dcmViewer.ModuleView = true;
                            dcmViewer.ShowDialog(this);
                        }
                        _store.Store(_storageServer, ds);
                        instance = SopInstanceReference.Import(ds);

                        if (!string.IsNullOrEmpty(instance.ReferencedSopInstanceUid) &&
                            !string.IsNullOrEmpty(instance.ReferencedSopClassUid))
                        {
                            PerformedSeries series = ps.Mpps.PerformedSeriesSequence[0];

                            if (series.ReferencedImageSequence == null)
                                series.ReferencedImageSequence = new List<SopInstanceReference>();

                            series.ReferencedImageSequence.Add(instance);
                        }
                    }
                }
                catch (Exception e)
                {
                    LogError(e.Message);
                    if (string.Compare(e.Message, "The attempt to connect was forcefully rejected", true) == 0)
                    {
                        if (_mySettings.IsPreconfigured)
                        {
                            bShowImportantMessage = true;
                        }
                    }
                }
            }

            if (bShowImportantMessage)
            {
                string sImportant = string.Format("\n\tThis demo is preconfigured to communicate with {0} DICOM Service.\n\tTo start the service:\n\t* Run CSLeadtools.Dicom.Server.Manager.exe\n\t* For each of the following services\n\t* Click the 'Start Server' button (blue triangle) to start the DICOM service\n\t{0}\n\t{1}\n\t{2}.", _mySettings.DefaultMwlQuery, _mySettings.DefaultMpps, _mySettings.DefaultStore);
                LogText("*** IMPORTANT ***", sImportant, Color.Red);
            }
        }

        //
        // Updates the dataset with MPPS info.  This normally happens on an image that has been captured from a modality.  We
        // are simulating it here by loading an image and forwarding it.
        //
        public void UpdateDataset(DicomDataSet ds, ProcedureStep ps)
        {
            MppsIodInfo info = new MppsIodInfo();

            info.StudyInstanceUID = ps.Mpps.ScheduledStepAttributeSequence[0].StudyInstanceUid;
            info.ReferencedStudySequence = ps.Mpps.ScheduledStepAttributeSequence[0].ReferencedStudySequence;
            info.AccessionNumber = ps.Mpps.ScheduledStepAttributeSequence[0].AccessionNumber;

            info.RequestAttributesSequence = new List<RequestAttributes>();
            info.RequestAttributesSequence.Add(new RequestAttributes());
            info.RequestAttributesSequence[0].RequestedProcedureID = ps.Mpps.ScheduledStepAttributeSequence[0].RequestedProcedureId;
            info.RequestAttributesSequence[0].RequestedProcedureDescription = ps.Mpps.ScheduledStepAttributeSequence[0].RequestedProcedureDescription;
            info.RequestAttributesSequence[0].ScheduledProcedureStepID = ps.Mpps.ScheduledStepAttributeSequence[0].ScheduledProcedureStepId;
            //info.RequestAttributesSequence[0].ScheduledProcedureStepDescription = ps.Mpps.ScheduledStepAttributeSequence[0].ScheduledProcedureStepDescription;
            info.RequestAttributesSequence[0].ScheduledProtocolCodeSequence = ps.Mpps.ScheduledStepAttributeSequence[0].ScheduledProtocolCodeSequence;

            info.StudyID = ps.Mpps.ScheduledStepAttributeSequence[0].RequestedProcedureId;
            info.PerformedProcedureStepID = ps.Mpps.PerformedProcedureStepId;
            info.PerformedProcedureStepStartDate = ps.Mpps.PerformedProcedureStepStartDate;
            info.PerformedProcedureStepStartTime = ps.Mpps.PerformedProcedureStepStartTime;
            info.ProcedureCodeSequence = ps.Mpps.ScheduledStepAttributeSequence[0].RequestedProcedureCodeSequence;
            info.ProtocolName = ps.Mpps.PerformedSeriesSequence[0].ProtocolName;

            info.ReferencedPerformedProcedureStepSequence = new List<SopInstanceReference>();
            info.ReferencedPerformedProcedureStepSequence.Add(new SopInstanceReference());
            info.ReferencedPerformedProcedureStepSequence[0].ReferencedSopClassUid = DicomUidType.ModalityPerformedClass;
            info.ReferencedPerformedProcedureStepSequence[0].ReferencedSopInstanceUid = ps.Mpps.SOPInstance.SOPInstanceUid;

            ds.InsertElementAndSetValue(DicomTag.PatientName, ps.Result.PatientName);
            ds.InsertElementAndSetValue(DicomTag.PatientID, ps.Result.PatientId);
            ds.InsertElementAndSetValue(DicomTag.PatientSex, ps.Result.PatientSex);
            ds.InsertElementAndSetValue(DicomTag.PatientComments, ps.Result.PatientComments);
            ds.InsertElementAndSetValue(DicomTag.SeriesInstanceUID, Utils.GenerateDicomUniqueIdentifier());
            ds.InsertElementAndSetValue(DicomTag.SOPInstanceUID, Utils.GenerateDicomUniqueIdentifier());
            ds.InsertElementAndSetValue(DicomTag.Modality, ps.Mpps.Modality);
            ds.InsertElementAndSetValue(DicomTag.ScheduledProcedureStepDescription, ps.Mpps.ScheduledStepAttributeSequence[0].ScheduledProcedureStepDescription);
            ds.Set(info);
        }

        public string GetProcedureStepFilename()
        {
            string commonFolder = DicomDemoSettingsManager.GetFolderPath();
            string settingsFilename = commonFolder + @"\procedurestep.xml";

            return settingsFilename;
        }

        public void SaveProcedureStep()
        {
            string filename = GetProcedureStepFilename();
            XmlSerializer xs = new XmlSerializer(typeof(List<ProcedureStep>));
            TextWriter xmlTextWriter = new StreamWriter(filename);
            List<ProcedureStep> list = new List<ProcedureStep>();

            foreach (ListViewItem item in listViewInProgress.Items)
            {
                ProcedureStep ps = item.Tag as ProcedureStep;

                list.Add(ps);
            }

            xs.Serialize(xmlTextWriter, list);
            xmlTextWriter.Close();
        }

        public void LoadProcedureStep()
        {
            XmlSerializer SerializerObj = new XmlSerializer(typeof(List<ProcedureStep>));
            string filename = GetProcedureStepFilename();

            if (File.Exists(filename))
            {
                try
                {
                    List<ProcedureStep> list;
                    FileStream ReadFileStream = new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.Read);

                    list = (List<ProcedureStep>)SerializerObj.Deserialize(ReadFileStream);
                    foreach (ProcedureStep ps in list)
                    {
                        AddProcedureStep(ps);
                    }
                    ReadFileStream.Close();
                }
                catch (Exception)
                {
                }
            }
        }

        private void SetDefaultServer(ComboBox comboBox, Scp scp, string mySettingsDefaultAeTitle)
        {
            DicomAE defaultAE = _mySettings.GetServer(mySettingsDefaultAeTitle);
            if (null != defaultAE)
            {
                scp.AETitle = defaultAE.AE;
                scp.Port = (int)defaultAE.Port;
                scp.PeerAddress = IPAddress.Parse(defaultAE.IPAddress);
                scp.Timeout = defaultAE.Timeout;
            }
        }


        void UpdateDefaultServerAE(ComboBox comboBox, Scp scp)
        {
            if (comboBox.Items.Count > 0)
            {
                if (comboBox == toolStripComboBoxMWLScp.ComboBox)
                    _mySettings.DefaultMwlQuery = comboBox.Text;
                else if (comboBox == toolStripComboBoxMPPSScp.ComboBox)
                    _mySettings.DefaultMpps = comboBox.Text;
                else if (comboBox == toolStripComboBoxStoreScp.ComboBox)
                    _mySettings.DefaultStore = comboBox.Text;

                MySaveSettings();

                SetDefaultServer(comboBox, scp, comboBox.Text);
            }
        }

        private void _comboBoxMwl_SelectionChangeCommitted(object sender, EventArgs e)
        {
            UpdateDefaultServerAE(toolStripComboBoxMWLScp.ComboBox, _mwlServer);
            CreateCFindObject();
        }

        private void _comboBoxMpps_SelectionChangeCommitted(object sender, EventArgs e)
        {
            UpdateDefaultServerAE(toolStripComboBoxMPPSScp.ComboBox, _mppsServer);
            CreateModalityPPSObject();
        }

        private void _comboBoxStore_SelectionChangeCommitted(object sender, EventArgs e)
        {
            UpdateDefaultServerAE(toolStripComboBoxStoreScp.ComboBox, _storageServer);
            CreateCStoreObject();
        }

        string SelectDefaultServerAE(ComboBox comboBox, string defaultAeTitle)
        {
            string ret = string.Empty;
            if (comboBox.Items.Count > 0)
            {
                comboBox.SelectedItem = defaultAeTitle;

                if (-1 == comboBox.SelectedIndex && comboBox.Items.Count > 0)
                {
                    comboBox.SelectedIndex = 0;
                }

                if (comboBox.Items.Count > 0)
                {
                    ret = comboBox.SelectedItem.ToString();
                }
            }

            comboBox.Enabled = (comboBox.Items.Count > 0);
            return ret;
        }

        string UpdateComboBoxService(ComboBox comboBox, string defaultAeTitle)
        {
            comboBox.Items.Clear();

            foreach (DicomAE myServer in _mySettings.ServerList)
            {
                comboBox.Items.Add(myServer.AE);
            }

            return SelectDefaultServerAE(comboBox, defaultAeTitle);
        }

        void UpdateComboBoxServices()
        {
            _mySettings.DefaultMwlQuery = UpdateComboBoxService(toolStripComboBoxMWLScp.ComboBox, _mySettings.DefaultMwlQuery);
            _mySettings.DefaultMpps = UpdateComboBoxService(toolStripComboBoxMPPSScp.ComboBox, _mySettings.DefaultMpps);
            _mySettings.DefaultStore = UpdateComboBoxService(toolStripComboBoxStoreScp.ComboBox, _mySettings.DefaultStore);
        }

        void SetLabelInfo(ToolStripStatusLabel label, ComboBox combo)
        {
            label.Text = combo.Text;
        }

        private void toolStripButtonSet_Click(object sender, EventArgs e)
        {
            ProcedureStep ps = listViewInProgress.SelectedItems[0].Tag as ProcedureStep;
            DicomEditor editor = null;
            MPPSNCreate mpps = ps.Mpps;
            MPPSNSet mppsNSet = new MPPSNSet();

            mpps.CopyTo(mppsNSet);
            editor = new DicomEditor(_mySettings.ExcludeList);
            editor.Text = "Edit Modality Peformed Procedure Step";
            editor.DefaultTag = DicomTag.PerformedProcedureStepStatus;
            if (editor.Edit<MPPSNSet>(this, ref mppsNSet, new Action<BeforeAddElementEventArgs>(OnCheckProperty)) == DialogResult.OK)
            {
                try
                {
                    // 
                    // Copy changes back to the mpps
                    //
                    mppsNSet.CopyTo(mpps);
                    ps.Mpps = mpps;
                    _modalityPPS.Status = DicomCommandStatusType.Failure;
                    ShowProgress(true);
                    _modalityPPS.Set<MPPSNSet>(_mppsServer, true, mppsNSet);
                    if (_modalityPPS.Status == DicomCommandStatusType.Success)
                    {
                        listViewInProgress.SelectedItems[0].Tag = ps;
                    }
                    else if (_modalityPPS.Status == DicomCommandStatusType.NoSuchObjectInstance)
                    {
                        listViewInProgress.Items.Remove(listViewInProgress.SelectedItems[0]);
                    }
                }
                catch { }
                finally
                {
                    ShowProgress(false);
                }
            }
        }

        private void buttonCancelMPPS_Click(object sender, EventArgs e)
        {
            ProcedureStep ps = listViewInProgress.SelectedItems[0].Tag as ProcedureStep;
            DicomEditor editor = null;
            MPPSNCreate mpps = ps.Mpps;
            MPPSNSet mppsNSet = new MPPSNSet();

            mpps.CopyTo(mppsNSet);
            mppsNSet.PerformedProcedureStepStatus = "DISCONTINUED";
            if (mppsNSet.PerformedProcedureStepEndDate == null)
            {
                mppsNSet.PerformedProcedureStepEndDate = DateTime.Now;
                mppsNSet.PerformedProcedureStepEndTime = mppsNSet.PerformedProcedureStepEndDate;
            }
            editor = new DicomEditor(_mySettings.ExcludeList);
            editor.Text = "Discontinue Modality Peformed Procedure Step";
            editor.DefaultTag = DicomTag.PerformedProcedureStepStatus;
            if (editor.Edit<MPPSNSet>(this, ref mppsNSet, new Action<BeforeAddElementEventArgs>(OnCheckProperty)) == DialogResult.OK)
            {
                try
                {                   
                    _modalityPPS.Status = DicomCommandStatusType.Failure;
                    ShowProgress(true);
                    _modalityPPS.Set<MPPSNSet>(_mppsServer, true, mppsNSet);
                    if (_modalityPPS.Status == DicomCommandStatusType.Success)
                    {
                        mppsNSet.CopyTo(mpps);
                        ps.Mpps = mpps;
                        listViewInProgress.Items.Remove(listViewInProgress.SelectedItems[0]);
                    }
                    else if (_modalityPPS.Status == DicomCommandStatusType.NoSuchObjectInstance)
                    {
                        listViewInProgress.Items.Remove(listViewInProgress.SelectedItems[0]);
                    }
                }
                catch { }
                finally
                {
                    ShowProgress(false);
                }
            }
        }

        private void buttonCompleteMPPS_Click(object sender, EventArgs e)
        {
            ProcedureStep ps = listViewInProgress.SelectedItems[0].Tag as ProcedureStep;
            DicomEditor editor = null;
            MPPSNCreate mpps = ps.Mpps;
            MPPSNSet mppsNSet = new MPPSNSet();

            mpps.CopyTo(mppsNSet);
            mppsNSet.PerformedProcedureStepStatus = "COMPLETED";
            if (mppsNSet.PerformedProcedureStepEndDate == null)
            {
                mppsNSet.PerformedProcedureStepEndDate = DateTime.Now;
                mppsNSet.PerformedProcedureStepEndTime = mppsNSet.PerformedProcedureStepEndDate;
            }
            editor = new DicomEditor(_mySettings.ExcludeList);
            editor.Text = "Complete Modality Peformed Procedure Step";
            editor.DefaultTag = DicomTag.PerformedProcedureStepStatus;
            if (editor.Edit<MPPSNSet>(this, ref mppsNSet, new Action<BeforeAddElementEventArgs>(OnCheckProperty)) == DialogResult.OK)
            {
                try
                {
                    mppsNSet.CopyTo(mpps);
                    ps.Mpps = mpps;
                    _modalityPPS.Status = DicomCommandStatusType.Failure;
                    ShowProgress(true);
                    _modalityPPS.Set<MPPSNSet>(_mppsServer, true, mppsNSet);
                    if (_modalityPPS.Status == DicomCommandStatusType.Success || _modalityPPS.Status == DicomCommandStatusType.NoSuchObjectInstance)
                    {
                        listViewInProgress.Items.Remove(listViewInProgress.SelectedItems[0]);
                    }
                }
                catch { }
                finally
                {
                    ShowProgress(false);
                }
            }
        }

        private void contextMenuStripMPPS_Opening(object sender, CancelEventArgs e)
        {
            InitializeContextMenu(contextMenuStripMPPS, toolStripComboBoxMPPSScp.ComboBox);
        }

        private void contextMenuStripMWL_Opening(object sender, CancelEventArgs e)
        {
            InitializeContextMenu(contextMenuStripMWL, toolStripComboBoxMWLScp.ComboBox);
        }

        private void contextMenuStripStore_Opening(object sender, CancelEventArgs e)
        {
            ToolStripMenuItem item = new ToolStripMenuItem("View Store DataSet");

            InitializeContextMenu(contextMenuStripStore, toolStripComboBoxStoreScp.ComboBox);
            contextMenuStripStore.Items.Insert(0, new ToolStripSeparator());
            item.Checked = _mySettings.ViewerBeforeSend;
            item.CheckOnClick = true;
            item.CheckedChanged += new EventHandler(ViewOnStore_Checked);
            contextMenuStripStore.Items.Insert(0, item);
        }

        void ViewOnStore_Checked(object sender, EventArgs e)
        {
            ToolStripMenuItem item = sender as ToolStripMenuItem;

            _mySettings.ViewerBeforeSend = item.Checked;
        }

        private void InitializeContextMenu(ContextMenuStrip menu, ComboBox combo)
        {
            menu.Items.Clear();
            foreach (string ae in combo.Items)
            {
                ToolStripMenuItem item = new ToolStripMenuItem(ae);

                item.Tag = combo;
                item.CheckOnClick = false;
                if (combo.Text == ae)
                    item.Checked = true;
                menu.Items.Add(item);
                item.Click += new EventHandler(item_Click);
            }
        }

        void item_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = sender as ToolStripMenuItem;

            if (!item.Checked)
            {
                ComboBox combo = item.Tag as ComboBox;

                combo.SelectedIndex = combo.Items.IndexOf(item.Text);
            }
        }

        private void listViewInProgress_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete && listViewInProgress.SelectedItems.Count > 0)
            {
                listViewInProgress.Items.RemoveAt(listViewInProgress.SelectedIndices[0]);
            }
        }

        private void AddImagesToDataSet(DicomDataSet ds, List<RasterImage> images)
        {
            if (images.Count == 0)
                return;

            RasterImage image1 = null;

            int width = images[0].Width;
            int height = images[0].Height;

            foreach (RasterImage img in images)
            {
                SizeCommand sizeCmd = new SizeCommand(width, height, RasterSizeFlags.None);
                sizeCmd.Run(img);
            }

            for (int i = 0; i < images.Count; i++)
            {
                if (i == 0)
                    image1 = images[i].Clone();
                else
                    image1.AddPage(images[i]);
            }

            ColorResolutionCommand resolCmd = new ColorResolutionCommand(ColorResolutionCommandMode.AllPages, image1.BitsPerPixel, image1.Order, RasterDitheringMethod.None, ColorResolutionCommandPaletteFlags.None, image1.GetPalette());
            resolCmd.Run(image1);

            DicomElement dPixel = ds.FindFirstElement(null, DicomTag.PixelData, true);
            if (dPixel == null)
            {
                dPixel = ds.InsertElement(null, false, DicomTag.PixelData, DicomVRType.OW, false, 0);
            }
            else
            {
                ds.DeleteElement(dPixel);
                dPixel = ds.InsertElement(null, false, DicomTag.PixelData, DicomVRType.OW, false, 0);
            }


            ds.SetImages(dPixel, image1, DicomImageCompressionType.None, DicomImagePhotometricInterpretationType.Rgb, 0, 2, DicomSetImageFlags.None);
            image1.Dispose();

        }

        private void saveAsDicomFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                ModalityWorklistResult result = _listViewWorkItems.SelectedItems[0].Tag as ModalityWorklistResult;
                DicomDataSet ds = result.Tag as DicomDataSet;
                List<RasterImage> images = null;

                //if (MessageBox.Show("Do you want Add Image to Dicom File", "Info", MessageBoxButtons.YesNo) == DialogResult.Yes)
                //{
                //   images = LoadImage();              
                //}

                if (_saveFiledlg.ShowDialog() == DialogResult.OK)
                {
                    DicomDataSet modifiedDataSet = null;
                    modifiedDataSet = new DicomDataSet();
                    modifiedDataSet.Copy(ds, null, null);
                    if (images != null)
                    {
                        AddImagesToDataSet(modifiedDataSet, images);
                        foreach (RasterImage img in images)
                            img.Dispose();
                    }
                    modifiedDataSet.Save(_saveFiledlg.FileName, DicomDataSetSaveFlags.None);
                    modifiedDataSet.Dispose();
                }

            }
            catch (Exception ex)
            {
                Messager.ShowError(this, ex);
            }
        }
    }

    internal static class Extensions
    {
        public static void CopyTo<T>(this object source, T dest)
        {
            if (source == null)
                throw new ArgumentNullException("source", "The object you are copying from cannot be null");

            if (dest == null)
                throw new ArgumentNullException("dest", "The object you are copying to cannot be null");

            // Don't copy if they are the same object
            if (!ReferenceEquals(source, dest))
            {
                List<PropertyInfo> matches = GetMatchingProperties(source, dest);

                foreach (PropertyInfo fromProperty in matches)
                {
                    PropertyInfo toProperty = dest.GetType().GetProperty(fromProperty.Name);

                    if (toProperty.CanWrite)
                    {
                        object value = null;

                        if (source is DataRow)
                        {
                            DataRow row = source as DataRow;

                            if (row[fromProperty.Name] != null)
                                value = row[fromProperty.Name];
                        }
                        else
                        {
                            value = fromProperty.GetValue(source, null);
                        }

                        if (value == DBNull.Value)
                            value = null;
                        toProperty.SetValue(dest, value, null);
                    }
                }
            }
        }

        private static List<PropertyInfo> GetMatchingProperties(object source, object target)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            if (target == null)
                throw new ArgumentNullException("target");

            var sourceType = source.GetType();
            var sourceProperties = sourceType.GetProperties();
            var targetType = target.GetType();
            var targetProperties = targetType.GetProperties();
            var properties = (from s in sourceProperties
                              from t in targetProperties
                              where s.Name == t.Name &&
                                    s.PropertyType == t.PropertyType
                              select s).ToList();

            return properties;
        }
    }
}

// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using System.IO;
using Leadtools;
using Leadtools.Demos;
using Leadtools.Printer;
using Leadtools.Document.Writer;
using Leadtools.Codecs;
using Leadtools.Dicom;
using System.Net;
using System.Threading;
using Leadtools.Dicom.Common.Extensions;
using Leadtools.Dicom.Common.Editing;
using PrintToPACS.Utilities;
using Leadtools.Dicom.Scu.Common;
using PrinterDemo;
using Leadtools.Dicom.Scu;
using System.Diagnostics;
using PrintToPACSDemo.Queries;
using Leadtools.Dicom.Common.DataTypes.Modality;
using Leadtools.Dicom.Scu.Queries;
using PrintToPACSDemo.UI;
using Leadtools.DicomDemos;
using System.Collections.Generic;
using System.Collections;
using System.Management;
using Leadtools.WinForms.CommonDialogs.File;
using System.Reflection;
using System.Runtime.InteropServices;
using Leadtools.Dicom.Common.Editing.Converters;
using Leadtools.ImageProcessing;
using Leadtools.Drawing;
using Leadtools.ImageProcessing.Effects;

namespace PrintToPACSDemo
{
   public partial class FrmMain : Form
   {

      #region Main...
      /// <summary>
      /// The main entry point for the application.
      /// </summary>

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

      static bool ReadCommandLine(string[] args)
      {
         return false;
         //const string sHelp = "/help";
         //const string sQuestion = "/?";
         //const string sConfigure = "/configure";
         //const string sServerAeTitle = "/server_aetitle=";
         //const string sServerPort = "/server_port=";
         //const string sServerIp = "/server_ip=";
         //const string sClientAeTitle = "/client_aetitle=";
         //const string sClientPort = "/client_port=";
         //const string sDefaults = "/defaults";
         //const string sServers = "/servers=";
         //bool bConfigure = false;
         //MySettings mySettings = new MySettings();
         //mySettings.Load();

         //foreach (string s in args)
         //{
         //   string sVal = string.Empty;

         //   if ((string.Compare(sHelp, s, true) == 0) || (string.Compare(sQuestion, s, true) == 0))
         //   {
         //      MessageBox.Show(sHelpInstructions, "Help", MessageBoxButtons.OK, MessageBoxIcon.Information);
         //      return true;
         //   }
         //   else if (s.StartsWith(sConfigure))
         //   {
         //      bConfigure = true;
         //   }
         //   else if (s.StartsWith(sServers))
         //   {
         //      //   /servers=ae1,ip1,port1,timeout1,secure1;ae2,ip2,port2,timeout2,secure2
         //      string sTemp = s.Substring(sServers.Length);
         //      MyServer[] serverList = ParseServerList(sTemp);
         //      mySettings._settings.queryMWLServers.serverList = serverList;
         //      mySettings._settings.querySCPServers.serverList = serverList;
         //      mySettings._settings.storeServers.serverList = serverList;
         //   }
         //   else if (s.StartsWith(sDefaults))
         //   {
         //      //mySettings._settings.serverList = new MyServer(AE, IPAddress, port, 20, false);
         //      mySettings._settings.clientCertificate = Application.StartupPath + "\\client.pem";
         //      mySettings._settings.privateKey = Application.StartupPath + "\\client.pem";
         //      mySettings._settings.privateKeyPassword = "test";
         //      mySettings._settings.logLowLevel = true;
         //      mySettings._settings.showHelpOnStart = true;

         //      string sDefaultIP = string.Empty;
         //      try
         //      {
         //         sDefaultIP = GetDefaultIp();
         //      }
         //      catch (Exception)
         //      {
         //      }

         //      //mySettings._settings.serverIP = sDefaultIP;
         //   }
         //   else if (s.StartsWith(sServerAeTitle, true, null))
         //   {
         //      sVal = s.Substring(sServerAeTitle.Length);
         //      mySettings._settings.queryMWLServers.serverList[0]._sAE = sVal;
         //      mySettings._settings.querySCPServers.serverList[0]._sAE = sVal;
         //      mySettings._settings.storeServers.serverList[0]._sAE = sVal;
         //   }
         //   else if (s.StartsWith(sServerPort, true, null))
         //   {
         //      sVal = s.Substring(sServerPort.Length);
         //      mySettings._settings.queryMWLServers.serverList[0]._port = 104;
         //      mySettings._settings.querySCPServers.serverList[0]._port = 104;
         //      mySettings._settings.storeServers.serverList[0]._port = 104;
         //      try
         //      {
         //         mySettings._settings.queryMWLServers.serverList[0]._port = Convert.ToInt32(sVal);
         //         mySettings._settings.querySCPServers.serverList[0]._port = Convert.ToInt32(sVal);
         //         mySettings._settings.storeServers.serverList[0]._port = Convert.ToInt32(sVal);
         //      }
         //      catch (Exception)
         //      {
         //      }
         //   }
         //   else if (s.StartsWith(sServerIp, true, null))
         //   {
         //      sVal = s.Substring(sServerIp.Length);
         //      mySettings._settings.queryMWLServers.serverList[0]._sIP = sVal;
         //      mySettings._settings.querySCPServers.serverList[0]._sIP = sVal;
         //      mySettings._settings.storeServers.serverList[0]._sIP = sVal;
         //   }

         //   else if (s.StartsWith(sClientAeTitle, true, null))
         //   {
         //      sVal = s.Substring(sClientAeTitle.Length);
         //      mySettings._settings.clientAE = sVal;
         //   }
         //   else if (s.StartsWith(sClientPort, true, null))
         //   {
         //      sVal = s.Substring(sClientPort.Length);
         //      mySettings._settings.clientPort = 1000;
         //      try
         //      {
         //         mySettings._settings.clientPort = Convert.ToInt32(sVal);
         //      }
         //      catch (Exception)
         //      {
         //      }
         //   }

         //   if (bConfigure)
         //   {
         //      mySettings.SavePreconfigure();
         //   }
         //}
         //return bConfigure;
      }
      [STAThread]
      static void Main(string[] args)
      {
         try
         {
            bool bConfigure = ReadCommandLine(args);
            if (bConfigure)
               return;
         }
         catch { }

         if (!Support.SetLicense())
            return;

         if (args.Length > 0)
         {
            FrmMain.StartedPrinter = args[0];
            MySettings mySettings = new MySettings();
            mySettings.Load();
            if (FrmMain.StartedPrinter != mySettings._settings.printerName)
               return;
         }

         Utils.EngineStartup();
         Utils.DicomNetStartup();
         Application.EnableVisualStyles();
         Application.SetCompatibleTextRenderingDefault(false);
         Application.Run(new FrmMain());
      }
      #endregion

      #region Constructor...
      public FrmMain()
      {
         try
         {
            InitClass();
            InitializeComponent();

            if (StartedPrinter != "")
            {
               _printer = new Printer(StartedPrinter);
               _printer.JobEvent += new EventHandler<JobEventArgs>(_printer_JobEvent);
               _printer.EmfEvent += new EventHandler<EmfEventArgs>(_printer_EmfEvent);
            }
            LoadSettings();
            _mySettings.CopyGlobalSettings();
         }
         catch (Exception Ex)
         {
            MessageBox.Show(Ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            Close();
         }
      }
      #endregion

      #region Fields...

      public delegate void AddLog(string action, string logText);
      public delegate void AddLogColor(string action, string logText, Color sActionColor);
      public delegate void EnableMenu(bool enable, string strCaption, string strBtnCaption);

      private const string _sNewline = "\r\n";
      private const string _sNewlineTab = "\r\n\t";
      private const string _sNewlineTabTab = "\r\n\t\t";
      private FrmProgress _frmProgress;
      private FrmOperation _frmOperation;
      private ListImageBox.ImageCollection imgCollection = null;
      private int _pageNo = 0;
      private int _jobId = 0;
      static string StartedPrinter = string.Empty;
      bool bFinishedPrinting = false;
      int iOldY = -1, iOldX = -1, _iOldIndex = -1;
      private RasterCodecs _codec;

      private Printer _printer;

      private bool bCancelOperation = false;


      public const string _sConfigurationImplementationClass = "1.2.840.114257.1123456";
      public const string _sConfigurationImplementationVersionName = "1";
      public const string _sConfigurationProtocolversion = "1";

      private TextBoxTraceListener _tracer = null;

      private DicomFindQuery _findQuery = new DicomFindQuery();
      private PatientBasedQuery _pbQuery = new PatientBasedQuery();
      private BroadBasedQuery _bbQuery = new BroadBasedQuery();

      private MyQueryRetrieveScu _find;
      private StoreScu _cstore;
      private bool bStored = false;
      public MySettings _mySettings = new MySettings();
      List<DataGridViewRow> OldRowSelection = new List<DataGridViewRow>();
      List<DataGridViewCell> OldCellSelection = new List<DataGridViewCell>();
      LogWindow logWindow;
      ListView _lstSelected;
      List<long> DICOMPatientInfo = new List<long>()
      {
         DicomTag.PatientName,
         DicomTag.PatientID,
         DicomTag.PatientSex,
         DicomTag.PatientBirthDate
         
      };

      List<long> DICOMStudyInfo = new List<long>()
      {
         DicomTag.StudyID,
         DicomTag.ReferringPhysicianName,
         DicomTag.AccessionNumber,
         DicomTag.StudyDate,
         DicomTag.StudyTime
      };

      List<DicomClassType> ClassTypes = new List<DicomClassType>(){
         DicomClassType.SCImageStorage,
         DicomClassType.SCMultiFrameGrayscaleByteImageStorage,
         DicomClassType.SCMultiFrameTrueColorImageStorage,
         DicomClassType.EncapsulatedPdfStorage
      };

      private const long ELEMENT_LENGTH_MAX = (long)0xFFFFFFFFUL;
      private List<long> _ExcludedTags = new List<long>();

      string strLastLocation = "";
      #endregion

      #region Forms Events...

      /*TEMP*/
      private Leadtools.Dicom.Common.Editing.Controls.DicomPropertyGrid _pgDicomInfo;
      private Leadtools.Dicom.Common.Editing.DicomEditableObject DicomEditableObject;
      private Leadtools.WinForms.RasterImageViewer _pictureBox = new Leadtools.WinForms.RasterImageViewer();

      private void FrmMain_Load(object sender, EventArgs e)
      {
         //
         // Add Excluded Tags
         //
         _ExcludedTags.Add(DicomTag.SOPClassUID);
         _ExcludedTags.Add(DicomTag.SOPInstanceUID);
         _ExcludedTags.Add(DicomTag.StudyInstanceUID);
         _ExcludedTags.Add(DicomTag.SeriesInstanceUID);
         _ExcludedTags.Add(DicomTag.MediaStorageSOPClassUID);
         _ExcludedTags.Add(DicomTag.FrameIncrementPointer);
         _ExcludedTags.Add(DicomTag.MIMETypeOfEncapsulatedDocument);
         _ExcludedTags.Add(DicomTag.PageNumberVector);

         try
         {
            if (StartedPrinter == "")
            {
               bFinishedPrinting = true;
               InitializePrinter();
            }

            InitializeForm();
            InitializeTwain();
            InitializeWia();
            SetServersComboBox(true);
            InitializeScreenCapture();
            DateTime tmStart = DateTime.Now;

            while (!bFinishedPrinting && (DateTime.Now - tmStart).TotalSeconds < 20)
               Application.DoEvents();

            Deserialize(_mySettings._settings.DataPath);

            //Initialize Store and Query Options
            CreateCFindObject(new MyServer());
            CreateCStoreObject(new MyServer());
            UpdateToolBarState();

            _captureType = CaptureType.None;
            CheckFirstRun();
            ShowHelp();
            _mySettings._settings.FirstRun = false;
            _mySettings.Save();
         }
         catch (Exception Ex)
         {
            MessageBox.Show(Ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            this.Close();
         }
      }

      void _pgDicomInfo_BeforeAddElement(object sender, BeforeAddElementEventArgs e)
      {
         //
         // Excluded items and Volatile Elements will not be displayed in the editor
         //
         e.Cancel = _ExcludedTags.Contains(e.Element.DicomElement.Tag) || e.Element.DataSet.IsVolatileElement(e.Element.DicomElement);
         if (!e.Cancel)
         {
            if (e.Element.DicomElement.Tag == DicomTag.ConversionType)
            {
               e.Element.Choices.Add("DV");
               e.Element.Choices.Add("DI");
               e.Element.Choices.Add("DF");
               e.Element.Choices.Add("WSD");
               e.Element.Choices.Add("SD");
               e.Element.Choices.Add("SI");
               e.Element.Choices.Add("DRW");
               e.Element.Choices.Add("SYN");
               e.Element.Attributes.Add(new TypeConverterAttribute(typeof(DicomPropertyChoiceConverter)));
            }
            else if (e.Element.DicomElement.Tag == DicomTag.Modality)
            {
               e.Element.Choices.Add("CR");
               e.Element.Choices.Add("CT");
               e.Element.Choices.Add("MR");
               e.Element.Choices.Add("NM");
               e.Element.Choices.Add("US");
               e.Element.Choices.Add("OT");
               e.Element.Choices.Add("BI");
               e.Element.Choices.Add("DG");
               e.Element.Choices.Add("ES");
               e.Element.Choices.Add("LS");
               e.Element.Choices.Add("PT");
               e.Element.Choices.Add("RG");
               e.Element.Choices.Add("TG");
               e.Element.Choices.Add("XA");
               e.Element.Choices.Add("RF");
               e.Element.Choices.Add("RTIMAGE");
               e.Element.Choices.Add("RTDOSE");
               e.Element.Choices.Add("RTSTRUCT");
               e.Element.Choices.Add("RTPLAN");
               e.Element.Choices.Add("RTRECORD");
               e.Element.Choices.Add("HC");
               e.Element.Choices.Add("DX");
               e.Element.Choices.Add("MG");
               e.Element.Choices.Add("IO");
               e.Element.Choices.Add("PX");
               e.Element.Choices.Add("GM");
               e.Element.Choices.Add("SM");
               e.Element.Choices.Add("XC");
               e.Element.Choices.Add("PR");
               e.Element.Choices.Add("AU");
               e.Element.Choices.Add("ECG");
               e.Element.Choices.Add("EPS");
               e.Element.Choices.Add("HD");
               e.Element.Choices.Add("SR");
               e.Element.Choices.Add("IVUS");
               e.Element.Choices.Add("OP");
               e.Element.Choices.Add("SMR");
               e.Element.Choices.Add("AR");
               e.Element.Choices.Add("KER");
               e.Element.Choices.Add("VA");
               e.Element.Choices.Add("SRF");
               e.Element.Choices.Add("OCT");
               e.Element.Choices.Add("LEN");
               e.Element.Choices.Add("OPV");
               e.Element.Choices.Add("OPM");
               e.Element.Choices.Add("OAM");
               e.Element.Choices.Add("RESP");
               e.Element.Choices.Add("KO");
               e.Element.Choices.Add("SEG");
               e.Element.Choices.Add("REG");
               e.Element.Choices.Add("OPT");
               e.Element.Choices.Add("BDUS");
               e.Element.Choices.Add("BMD");
               e.Element.Choices.Add("DOC");
               e.Element.Choices.Add("FID");
               e.Element.Choices.Add("DS");
               e.Element.Choices.Add("CF");
               e.Element.Choices.Add("DF");
               e.Element.Choices.Add("VF");
               e.Element.Choices.Add("AS");
               e.Element.Choices.Add("CS");
               e.Element.Choices.Add("EC");
               e.Element.Choices.Add("LP");
               e.Element.Choices.Add("FA");
               e.Element.Choices.Add("CP");
               e.Element.Choices.Add("DM");
               e.Element.Choices.Add("FS");
               e.Element.Choices.Add("MA");
               e.Element.Choices.Add("MS");
               e.Element.Choices.Add("CD");
               e.Element.Choices.Add("DD");
               e.Element.Choices.Add("ST");
               e.Element.Choices.Add("OPR");
               e.Element.Attributes.Add(new TypeConverterAttribute(typeof(DicomPropertyChoiceConverter)));
            }
         }
      }

      private void _miResample_Click(object sender, EventArgs e)
      {
         RasterPaintProperties prop = _pictureBox.PaintProperties;
         _mySettings._settings.UseResample = prop.PaintDisplayMode == RasterPaintDisplayModeFlags.Resample;
         if (_mySettings._settings.UseResample)
            prop.PaintDisplayMode = RasterPaintDisplayModeFlags.None;
         else
            prop.PaintDisplayMode = RasterPaintDisplayModeFlags.Resample;
         _mySettings._settings.UseResample = !_mySettings._settings.UseResample;
         _mySettings.Save();
         _pictureBox.PaintProperties = prop;
      }

      void _frmOperation_Cancel(object sender, EventArgs e)
      {
         bCancelOperation = true;
      }

      void _pictureBox_MouseMove(object sender, MouseEventArgs e)
      {
         int iDelteY = e.Y - iOldY;
         int iDelteX = e.X - iOldX;
         if (e.Button == MouseButtons.Middle && _pictureBox.Image != null)
         {
            if (iDelteY < 0)
               ZoomPicture(0.03f);
            if (iDelteY > 0)
               ZoomPicture(-0.03f);
         }
         if (e.Button == MouseButtons.Right && _pictureBox.Image != null)
         {
            _pictureBox.ScrollPosition = new Point(_pictureBox.ScrollPosition.X - iDelteX, _pictureBox.ScrollPosition.Y - iDelteY);
         }
         iOldY = e.Y;
         iOldX = e.X;
      }

      private void _lstBoxPages_ListStateChanged(object sender, EventArgs e)
      {
         UpdateToolBarState();
      }

      private void _cmListBox_Opening(object sender, CancelEventArgs e)
      {
         _cmiExpanded.Checked = _lstBoxPages.ViewMode == ThumbMode.Expanded;
         _cmiCondensed.Checked = _lstBoxPages.ViewMode == ThumbMode.Condensed;

         _cmiDeleteAll.Enabled = _lstBoxPages.Items.Count > 0;
         _cmiDeleteSelected.Enabled = _lstBoxPages.SelectedItems.Count > 0;

      }

      private void _cmiExpanded_Click(object sender, EventArgs e)
      {
         _lstBoxPages.ViewMode = ThumbMode.Expanded;
      }

      private void _miDeleteSelectedDataSet_Click(object sender, EventArgs e)
      {
         if (_lstDSPatient.SelectedItems != null && _lstDSPatient.SelectedItems.Count > 0)
         {
            (_lstDSPatient.SelectedItems[0].Tag as DicomDataSet).Dispose();
            _lstDSPatient.Items.Remove(_lstDSPatient.SelectedItems[0]);
         }
      }

      private void _lstDSPatient_KeyDown(object sender, KeyEventArgs e)
      {
         if (e.KeyCode == Keys.Delete)
         {
            _miDeleteSelectedDataSet_Click(null, null);
         }
      }

      private void _lstSCPStudies_SelectedIndexChanged(object sender, EventArgs e)
      {
         _btnTransferSCPStudies.Enabled = _lstSCPStudies.SelectedItems.Count > 0;
      }

      private void _lstMWLItems_SelectedIndexChanged(object sender, EventArgs e)
      {
         _btnTransferMWL.Enabled = _lstMWLItems.SelectedItems.Count > 0;
      }

      private void _cmiCondensed_Click(object sender, EventArgs e)
      {
         _lstBoxPages.ViewMode = ThumbMode.Condensed;
      }

      private void _miOpen_Click(object sender, EventArgs e)
      {
         RasterOpenDialog dlgOpen = new RasterOpenDialog(_codec);
         dlgOpen.ShowPreview = true;
         dlgOpen.PreviewWindowVisible = true;
         dlgOpen.FilterIndex = 1;
         dlgOpen.ShowFileInformation = true;
         if (strLastLocation != "")
            dlgOpen.InitialDirectory = Path.GetDirectoryName(strLastLocation);

         bool bTopMost = logWindow.TopMost;
         logWindow.TopMost = false;
         DialogResult dlgRes = dlgOpen.ShowDialog(this);
         if (dlgRes == DialogResult.Cancel)
         {
            dlgOpen.Dispose();
            logWindow.TopMost = bTopMost;
            return;
         }
         LoadRasterImage(dlgOpen.FileName);

         if (dlgOpen != null)
            dlgOpen.Dispose();
      }

      private void _miPaste_Click(object sender, EventArgs e)
      {
         try
         {
            Bitmap img = (Bitmap)Clipboard.GetImage();
            RasterImage rImg = Leadtools.Drawing.RasterImageConverter.ChangeFromHBitmap(img.GetHbitmap(), IntPtr.Zero);
            CreateImageCollection("Pasted Image", rImg);
         }
         catch { }
      }

      private void CopySpecificCharacterSetElement(DicomDataSet imageDataSet, DicomDataSet infoDataSet)
      {
         DicomElement element = infoDataSet.FindFirstElement(null, DicomTag.SpecificCharacterSet, true);
         if (element != null)
         {
            byte[] ba = infoDataSet.GetBinaryValue(element, (int)element.Length);
            imageDataSet.InsertElementAndSetValue(DicomTag.SpecificCharacterSet, ba);
         }
      }

      private void _btnTransferLoadedPatient_Click(object sender, EventArgs e)
      {
         if (_lstDSPatient.SelectedItems.Count == 0)
            return;
         DicomDataSet sourceDataSet = null;
         sourceDataSet = _lstDSPatient.SelectedItems[0].Tag as DicomDataSet;

         CopySpecificCharacterSetElement(_pgDicomInfo.DataSet, sourceDataSet);

         DicomModule module = sourceDataSet.FindModule(DicomModuleType.Patient);
         if (module == null)
            return;
         SetElements(_pgDicomInfo.DataSet, module.Elements, sourceDataSet);

         ResetModule(DicomModuleType.GeneralStudy, _pgDicomInfo.DataSet, true);

         GenerateDefaultElements();
         InsertNewStudyModule();
         InsertNewSeries();
      }

      private void _btnTransferLoadedStudies_Click(object sender, EventArgs e)
      {
         if (_lstDSStudies.SelectedItems.Count == 0)
            return;

         DicomDataSet sourceDataSet = null;
         sourceDataSet = _lstDSStudies.SelectedItems[0].Tag as DicomDataSet;
         DicomModule module = sourceDataSet.FindModule(DicomModuleType.GeneralStudy);

         List<DicomElement> lstElements = new List<DicomElement>();
         lstElements.AddRange(module.Elements);
         DicomElement dElement = null;
         dElement = sourceDataSet.FindFirstElement(null, DicomTag.StudyDescription, true);
         if (dElement != null)
            lstElements.Add(dElement);

         if (module != null)
            SetElements(_pgDicomInfo.DataSet, module.Elements, sourceDataSet);

         module = sourceDataSet.FindModule(DicomModuleType.Patient);
         if (module != null)
            SetElements(_pgDicomInfo.DataSet, module.Elements, sourceDataSet);

         ResetModule(DicomModuleType.GeneralSeries, _pgDicomInfo.DataSet, true);
         GenerateDefaultElements();
         InsertNewSeries();

      }

      private void _lstView_SelectedIndexChanged(object sender, EventArgs e)
      {
         try
         {
            if (_lstDSPatient == sender as ListView)
            {
               _btnTransferLoadedPatient.Enabled = (sender as ListView).SelectedItems.Count > 0;
               _lstDSStudies.Items.Clear();
               ListViewItem item = null;
               DicomElement dElement = null;
               string val = "";
               DicomDataSet dicom = (DicomDataSet)_lstDSPatient.SelectedItems[0].Tag;
               if (dicom == null)
                  return;

               foreach (long dTag in DICOMStudyInfo)
               {
                  dElement = dicom.FindFirstElement(null, dTag, true);
                  val = "";
                  if (dElement != null)
                     val = dicom.GetValue<string>(dElement, null);

                  if (item == null)
                     item = _lstDSStudies.Items.Add(val);
                  else
                     item.SubItems.Add(val);
               }
               item.Tag = dicom;
               item.Selected = true;
            }

            if (_lstDSStudies == sender as ListView)
            {
               _btnTransferLoadedStudies.Enabled = (sender as ListView).SelectedItems.Count > 0;
            }

         }
         catch
         {
            _lstDSStudies.Items.Clear();
            _btnTransferLoadedPatient.Enabled = _btnTransferLoadedStudies.Enabled = false;
         }

      }

      private void _toolBtnTwain_Click(object sender, EventArgs e)
      {
         _miTwainAcquire_Click(null, null);
      }

      private void _toolBtnWia_Click(object sender, EventArgs e)
      {
         _miWiaAcquire_Click(null, null);
      }

      private void _btnTransferSCPStudies_Click(object sender, EventArgs e)
      {
         if (_lstSCPStudies.SelectedItems.Count == 0)
            return;

         Study study = _lstSCPStudies.SelectedItems[0].Tag as Study;
         DicomDataSet ds = _pgDicomInfo.DataSet;
         ResetModule(DicomModuleType.Patient, _pgDicomInfo.DataSet, true);
         ResetModule(DicomModuleType.GeneralStudy, _pgDicomInfo.DataSet, true);

         Patient patient = study.Patient;
         if (patient == null)
            return;

         InsertPatientInfo(ds, patient);
         InsertNewStudyModule();
         InsertStudyInfo(ds, study);
         _pgDicomInfo.DataSet = _pgDicomInfo.DataSet;
         GenerateDefaultElements();
         InsertNewSeries();
      }

      private void _btnTransferSCPPatient_Click(object sender, EventArgs e)
      {
         if (_lstSCPPatient.SelectedItems.Count == 0)
            return;

         Study study = (_lstSCPPatient.SelectedItems[0].Tag as List<Study>)[0];

         DicomDataSet ds = _pgDicomInfo.DataSet;
         ResetModule(DicomModuleType.Patient, _pgDicomInfo.DataSet, true);
         ResetModule(DicomModuleType.GeneralStudy, _pgDicomInfo.DataSet, true);

         Patient patient = study.Patient;
         if (patient == null)
            return;

         InsertPatientInfo(ds, patient);
         _pgDicomInfo.DataSet = _pgDicomInfo.DataSet;
         GenerateDefaultElements();
         InsertNewStudyModule();
         InsertNewSeries();
      }

      private void _btnMWLTransfer_Click(object sender, EventArgs e)
      {
         if (_lstMWLItems.SelectedItems.Count == 0)
            return;

         ResetModule(DicomModuleType.GeneralSeries, _pgDicomInfo.DataSet, true);
         GenerateDefaultElements();
         InsertNewSeries();

         DicomDataSet ds = _pgDicomInfo.DataSet;
         ModalityWorklistResult result = null;
         result = (_lstMWLItems.SelectedItems[0].Tag as ModalityWorklistResult);

         //Study
         DicomElement dElement;
         if (result.AccessionNumber != null)
         {
            dElement = ds.FindFirstElement(null, DicomTag.AccessionNumber, true);
            if (dElement == null)
               dElement = ds.InsertElement(null, false, DicomTag.AccessionNumber, DicomVRType.UN, false, 0);
            ds.SetValue(dElement, result.AccessionNumber);
         }

         if (result.ReferringPysician != null)
         {
            dElement = ds.FindFirstElement(null, DicomTag.ReferringPhysicianName, true);
            if (dElement == null)
               dElement = ds.InsertElement(null, false, DicomTag.ReferringPhysicianName, DicomVRType.UN, false, 0);
            ds.SetValue(dElement, result.ReferringPysician.FullDicomEncoded);
         }

         //Patient
         if (result.PatientName != null)
         {
            dElement = ds.FindFirstElement(null, DicomTag.PatientName, true);
            if (dElement == null)
               dElement = ds.InsertElement(null, false, DicomTag.PatientName, DicomVRType.UN, false, 0);
            ds.SetValue(dElement, result.PatientName.FullDicomEncoded);
         }

         if (result.PatientId != null)
         {
            dElement = ds.FindFirstElement(null, DicomTag.PatientID, true);
            if (dElement == null)
               dElement = ds.InsertElement(null, false, DicomTag.PatientID, DicomVRType.UN, false, 0);
            ds.SetValue(dElement, result.PatientId);
         }

         if (result.PatientSex != null)
         {
            dElement = ds.FindFirstElement(null, DicomTag.PatientSex, true);
            if (dElement == null)
               dElement = ds.InsertElement(null, false, DicomTag.PatientSex, DicomVRType.UN, false, 0);
            ds.SetValue(dElement, result.PatientSex);
         }

         if (result.PatientBirthDate != null)
         {
            dElement = ds.FindFirstElement(null, DicomTag.PatientBirthDate, true);
            if (dElement == null)
               dElement = ds.InsertElement(null, false, DicomTag.PatientBirthDate, DicomVRType.UN, false, 0);
            ds.SetDateValue(dElement, new DateTime[] { (DateTime)result.PatientBirthDate });
         }

         if (result.RequestedProcedureId != null)
         {
            dElement = ds.FindFirstElement(null, DicomTag.StudyID, true);
            if (dElement == null)
               dElement = ds.InsertElement(null, false, DicomTag.StudyID, DicomVRType.UN, false, 0);
            ds.SetValue(dElement, result.RequestedProcedureId);
         }

         if (result.StudyInstanceUid != null)
         {
            dElement = ds.FindFirstElement(null, DicomTag.StudyInstanceUID, true);
            if (dElement == null)
               dElement = ds.InsertElement(null, false, DicomTag.StudyInstanceUID, DicomVRType.UN, false, 0);
            ds.SetValue(dElement, result.StudyInstanceUid);
         }

         _pgDicomInfo.DataSet = ds;
      }

      private void _lstSCPPatient_SelectedIndexChanged(object sender, EventArgs e)
      {
         _btnTransferSCPPatient.Enabled = _lstSCPPatient.SelectedItems.Count > 0;
         _btnTransferSCPStudies.Enabled = false;
         if (_lstSCPPatient.SelectedItems.Count == 0 || _lstSCPPatient.SelectedItems[0] == null)
         {
            _lstSCPStudies.Items.Clear();
            return;
         }

         _lstSCPStudies.Items.Clear();

         foreach (Study study in (_lstSCPPatient.SelectedItems[0].Tag as List<Study>))
         {
            ListViewItem item;
            item = _lstSCPStudies.Items.Add(study.Id);
            if (study.ReferringPhysiciansName != null)
               item.SubItems.Add(study.ReferringPhysiciansName.FullDicomEncoded);
            else
               item.SubItems.Add("");
            item.SubItems.Add(study.AccessionNumber);
            item.SubItems.Add(study.Date.HasValue ? study.Date.ToString() : string.Empty);
            item.SubItems.Add(study.Time.HasValue ? study.Time.ToString() : string.Empty);

            item.Tag = study;
         }

         if (_lstSCPStudies.Items.Count > 0)
            _lstSCPStudies.Items[0].Selected = true;
      }

      private void _miRotate90_Click(object sender, EventArgs e)
      {
         if (_pictureBox.Image == null)
            return;

         try
         {
            _pictureBox.Image.RotateViewPerspective(90);
            _lstBoxPages.SelectedItem.RasterImage.RotateViewPerspective(90);
            string strFileLoc = (_lstBoxPages.SelectedItem.ImageItem.Tag as IPrintToPACSFile).FileLocation();

            if (_lstBoxPages.SelectedItem.ImageItem.Tag.GetType() == typeof(PrintPage))
               _codec.Save(_lstBoxPages.SelectedItem.RasterImage, strFileLoc, RasterImageFormat.Emf, 0);
            else
               _codec.Save(_lstBoxPages.SelectedItem.RasterImage, strFileLoc, RasterImageFormat.Tif, 0);
         }
         catch { }
      }

      private void _toolBtnRotate_Click(object sender, EventArgs e)
      {
         _miRotate90_Click(null, null);
      }

      private void _lstBoxPages_ItemDeSlect(object sender, EventArgs e)
      {
         if (_pictureBox.Image != null)
         {
            _pictureBox.Image.Dispose();
            _pictureBox.Image = null;
         }
         _btnNext.Enabled = false;
         _btnPrev.Enabled = false;
         _lblPageInfo.Text = "";
         UpdateToolBarState();
      }

      private void _miShowHelp_Click(object sender, System.EventArgs e)
      {
         HelpDialog dlg = new HelpDialog(null, false, false);
         bool bTopMost = logWindow.TopMost;
         logWindow.TopMost = false;
         dlg.ShowDialog(this);
         logWindow.TopMost = bTopMost;

      }

      private void _pictureBox_MouseWheel(object sender, MouseEventArgs e)
      {
         if ((Control.ModifierKeys & Keys.Control) != 0)
         {
            if (e.Delta > 0)
               _miZoomIn_Click(null, null);
            else
               _miZoomOut_Click(null, null);
         }
         else
         {
            int iSelectedPage = 0;
            if (_lstBoxPages.ViewMode == ThumbMode.Condensed)
               iSelectedPage = _lstBoxPages.SelectedItemGroupIndex;
            else
               iSelectedPage = _lstBoxPages.SelectedIndex;

            if (e.Delta > 0)
            {

               if (iSelectedPage < _lstBoxPages.GetGroupImageItems().Count - 1)
               {
                  _btnNext_Click(null, null);
               }
            }
            else
            {
               if (iSelectedPage > 0)
               {
                  _btnPrev_Click(null, null);
               }
            }
         }
      }

      private void FrmMain_Resize(object sender, EventArgs e)
      {
         try
         {
            _pictureBox.Invalidate();
            _lstBoxPages.Invalidate();
         }
         catch { }
      }

      private void _miClearPrintedList_Click(object sender, EventArgs e)
      {
         try
         {
            ClearList();
            EnableNextPrevious();
            UpdateToolBarState();
            _lblPageInfo.Text = "";
         }
         catch (Exception Ex)
         {
            MessageBox.Show(Ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
         }
      }

      private void _miAbout_Click(object sender, EventArgs e)
      {
         bool bTopMost = logWindow.TopMost;
         logWindow.TopMost = false;
         try
         {
            AboutDialog aboutDialog = new AboutDialog("PrintToPACS");
            aboutDialog.ShowDialog();
         }
         catch (Exception Ex)
         {
            MessageBox.Show(Ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
         }
         logWindow.TopMost = bTopMost;
      }

      private void _miExit_Click(object sender, EventArgs e)
      {
         try
         {
            this.Close();
         }
         catch (Exception Ex)
         {
            MessageBox.Show(Ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
         }
      }

      private void _lstBoxPages_SelectedIndexChanged(object sender, EventArgs e)
      {
         ScalePicture(_lstBoxPages.SelectedItem.ImageItem);
         EnableNextPrevious();
         UpdateToolBarState();
         _iOldIndex = _lstBoxPages.SelectedIndex;
         _mySettings._settings.LastSelectedIndex = _lstBoxPages.SelectedIndex;
         _mySettings.Save();
      }

      private void _miFile_DropDownOpening(object sender, EventArgs e)
      {
         try
         {
            _miSaveAsDICOM.Enabled = (_lstBoxPages.CheckedItems.Count > 0);
            _miStoreToPACS.Enabled = (_lstBoxPages.CheckedItems.Count > 0);
         }
         catch (Exception Ex)
         {
            MessageBox.Show(Ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
         }
      }

      private void _lstBoxPages_KeyDown(object sender, KeyEventArgs e)
      {
         try
         {
            if (e.KeyCode == Keys.Delete && _lstBoxPages.SelectedItem != null)
               _miDeleteSelected_Click(null, null);

            if (e.KeyCode == Keys.V && Control.ModifierKeys == Keys.Control)
               _miPaste_Click(null, null);

            else if (e.KeyCode == Keys.Add)
            {
               _miZoomIn_Click(_miZoomIn, new EventArgs());
            }
            else if (e.KeyCode == Keys.Subtract)
            {
               _miZoomOut_Click(_miZoomOut, new EventArgs());
            }
         }
         catch (ArgumentOutOfRangeException)
         {
         }
         catch (Exception Ex)
         {
            MessageBox.Show(Ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
         }
      }

      private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
      {
         try
         {
            Serialize(_mySettings._settings.DataPath);

            if (_codec != null)
               _codec.Dispose();
            Utils.EngineShutdown();
            Utils.DicomNetShutdown();

            FinilizeScreenCapture();
            FinilizeTwain();
            FinilizeWia();
            _engine.StopCapture();
         }
         catch (Exception)
         {
            //MessageBox.Show("Closing Form " + Ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
         }
      }

      private void _miNormal_Click(object sender, EventArgs e)
      {
         try
         {
            _pictureBox.SizeMode = RasterPaintSizeMode.Normal;
            _pictureBox.ScaleFactor = 1;
         }
         catch (Exception exp)
         {
            Messager.ShowError(this, exp);
         }
      }

      private void _miFit_Click(object sender, EventArgs e)
      {
         try
         {
            _pictureBox.SizeMode = RasterPaintSizeMode.FitAlways;
            _pictureBox.ScaleFactor = 1;
         }
         catch (Exception exp)
         {
            Messager.ShowError(this, exp);
         }
      }

      private void _miClearResult_Click(object sender, EventArgs e)
      {
         if (_lstSelected == _lstDSPatient || _lstSelected == _lstDSStudies)
         {
            foreach (ListViewItem lvi in _lstDSPatient.Items)
            {
               (lvi.Tag as DicomDataSet).Dispose();
            }
            _btnTransferLoadedPatient.Enabled = false;
            _btnTransferLoadedStudies.Enabled = false;

            _lstDSPatient.Items.Clear();
            _lstDSStudies.Items.Clear();
         }
         if (_lstSelected == _lstSCPPatient)
         {
            _btnTransferSCPStudies.Enabled = false;
            _btnTransferSCPPatient.Enabled = false;

            _lstSCPStudies.Items.Clear();
            _lstSCPPatient.Items.Clear();
         }
         if (_lstSelected == _lstMWLItems)
         {
            _btnTransferMWL.Enabled = false;

            _lstMWLItems.Items.Clear();
         }
      }

      private void _lstView_MouseDown(object sender, MouseEventArgs e)
      {
         if (e.Button == MouseButtons.Right)
         {
            _lstSelected = null;
            ListView lv = sender as ListView;
            if (lv.Items.Count > 0)
               _lstSelected = lv;
         }
      }

      private void _cmResultQuery_Opening(object sender, CancelEventArgs e)
      {
         if (_lstSelected == null || _lstSelected.Items.Count == 0 || _lstSelected == _lstSCPStudies)
         {
            e.Cancel = true;
         }
         toolStripSeparator22.Visible = _miDeleteSelectedDataSet.Visible = _lstSelected == _lstDSPatient;
         _miDeleteSelectedDataSet.Enabled = _lstDSPatient.SelectedItems.Count >= 1;
      }

      private void _miZoomIn_Click(object sender, EventArgs e)
      {
         try
         {
            ZoomPicture(0.1f);
         }
         catch (Exception exp)
         {
            Messager.ShowError(this, exp);
         }
      }

      private void _miZoomOut_Click(object sender, EventArgs e)
      {
         try
         {
            if (_pictureBox.ScaleFactor > 0.1f)
            {
               ZoomPicture(-0.1f);
            }
         }
         catch (Exception exp)
         {
            Messager.ShowError(this, exp);
         }
      }

      private void _pictureBox_KeyDown(object sender, KeyEventArgs e)
      {
         try
         {
            if (e.KeyCode == Keys.Add)
            {
               _miZoomIn_Click(_miZoomIn, new EventArgs());
            }
            else if (e.KeyCode == Keys.Subtract)
            {
               _miZoomOut_Click(_miZoomOut, new EventArgs());
            }
         }
         catch (Exception Ex)
         {
            MessageBox.Show(Ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
         }
      }

      private void _btnNext_Click(object sender, EventArgs e)
      {
         if (_lstBoxPages.ViewMode == ThumbMode.Expanded)
         {
            if (_lstBoxPages.SelectedIndex < _lstBoxPages.Items.Count - 1)
               _lstBoxPages.SelectedIndex = _lstBoxPages.SelectedIndex + 1;
         }
         else
         {
            if (_lstBoxPages.SelectedItemGroupIndex < _lstBoxPages.GetGroupImageItems().Count - 1)
               _lstBoxPages.SelectedIndex = _lstBoxPages.SelectedIndex + 1;
         }
      }

      private void _btnPrev_Click(object sender, EventArgs e)
      {
         if (_lstBoxPages.ViewMode == ThumbMode.Expanded)
         {
            if (_lstBoxPages.SelectedIndex > 0)
               _lstBoxPages.SelectedIndex = _lstBoxPages.SelectedIndex - 1;
         }
         else
         {
            if (_lstBoxPages.SelectedItemGroupIndex > 0)
               _lstBoxPages.SelectedIndex = _lstBoxPages.SelectedIndex - 1;
         }
      }

      private void _miSCPOptions_Click(object sender, EventArgs e)
      {
         if (DoOptions(0) != DialogResult.Cancel)
            SetServersComboBox(false);
         UpdateComboBoxes();
      }

      private void _btnSCPQuery_Click(object sender, EventArgs e)
      {
         if (DoSearch())
         {
            int iMatchCount = 0;
            if (_tbDicomInfo.SelectedTab == _pageSCPQuery)
               iMatchCount = _lstSCPPatient.Items.Count;
            else
               iMatchCount = _lstMWLItems.Items.Count;

            EnableItems(true, "", "");
            if (iMatchCount == 0)
            {
               bool bTopMost = logWindow.TopMost;
               logWindow.TopMost = false;
               MessageBox.Show(this, "No studies found", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
               logWindow.TopMost = bTopMost;
            }
            else
            {
               if (_tbDicomInfo.SelectedTab == _pageSCPQuery)
               {
                  _lstSCPPatient.Items[0].Selected = true;
                  _lstSCPPatient.Focus();
               }
               else
               {
                  _lstMWLItems.Items[0].Selected = true;
                  _lstMWLItems.Focus();
               }
            }
         }
      }

      private void _miSaveAsDICOM_Click(object sender, EventArgs e)
      {
         DicomDataSet dicom = (_pgDicomInfo.SelectedObject as DicomEditableObject).DataSet;
         if (!CheckRequiredTags(dicom))
            return;

         SaveFileDialog dlgSave = new SaveFileDialog();
         dlgSave.Filter = "DICOM Files|*.dcm|DICOM DataSet Files|*.dic";
         if (strLastLocation != "")
            dlgSave.InitialDirectory = Path.GetDirectoryName(strLastLocation);

         bool bTopMost = logWindow.TopMost;
         logWindow.TopMost = false;
         DialogResult dlgRes = dlgSave.ShowDialog();

         if (dlgRes == DialogResult.Cancel)
         {
            logWindow.TopMost = bTopMost;
            return;
         }
         try
         {
            List<string> lstSaved = new List<string>();
            string strSaveLocation = dlgSave.FileName;
            strLastLocation = strSaveLocation;
            bool bSuccess = false;
            EnableItems(false, "Saving Files To HardDisk Please Wait...", "Cancel");
            string strMessage = DoSave(dicom, ref lstSaved, strSaveLocation, ref bSuccess);

            MessageBoxIcon icon = MessageBoxIcon.Information;
            if (bSuccess)
               icon = MessageBoxIcon.Information;
            else
               icon = MessageBoxIcon.Error;

            EnableItems(true, "", "");
            if (bSuccess)
            {
               DialogResult dlgClear = MessageBox.Show(this, strMessage + "\nDo you want to clear the DICOM information?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
               if (dlgClear == DialogResult.Yes)
               {
                  _miClearPG_Click(null, null);
               }
            }
            else
            {
               MessageBox.Show(this, "DICOM file was not saved successfully", this.Text, MessageBoxButtons.OK, icon);
            }
         }
         catch { }
         logWindow.TopMost = bTopMost;
      }

      private bool CheckRequiredTags(DicomDataSet dicom)
      {
         string strMessage = "";
         List<string> lstRequired = new List<string>();
         GetRequiredTags(dicom, lstRequired);

         DicomElement dElement = dicom.FindFirstElement(null, DicomTag.PatientName, true);
         string val = dicom.GetValue<string>(dElement, "");
         if (val == string.Empty)
            lstRequired.Add("Patient Name");

         dElement = dicom.FindFirstElement(null, DicomTag.PatientID, true);
         val = dicom.GetValue<string>(dElement, "");
         if (val == string.Empty)
            lstRequired.Add("Patient ID");

         if (lstRequired.Count > 0)
         {
            strMessage = "The Following Tags Are Required:\n";
            foreach (string strName in lstRequired)
            {
               strMessage += "--> " + strName + "\n";
            }
         }

         if (_lstBoxPages.CheckedItems.Count == 0 && strMessage == "")
         {
            strMessage = "One or more Print job/pages needs to be checked";
         }
         if (strMessage != "")
         {
            bool bTopMost = logWindow.TopMost;
            logWindow.TopMost = false;
            MessageBox.Show(this, strMessage, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            logWindow.TopMost = bTopMost;
            return false;
         }
         else
            return true;
      }

      private void _miStoreToPACS_Click(object sender, EventArgs e)
      {
         if (_mySettings._settings.StoreServers.serverList.Length == 0)
            return;

         MyServer server = _mySettings._settings.StoreServers.serverList[_cbStoreServers.SelectedIndex];
         string strTemp, strMessage = string.Empty;
         strTemp = Path.GetTempFileName();

         DicomDataSet dicom = (_pgDicomInfo.SelectedObject as DicomEditableObject).DataSet;
         List<string> lstSaved = new List<string>();
         bool bSuccess = false;

         if (!CheckRequiredTags(dicom))
            return;

         EnableItems(false, "Saving Temporary Files To HardDisk Please Wait...", "Cancel");
         bool bTopMost = logWindow.TopMost;
         logWindow.TopMost = false;
         strMessage = DoSave(dicom, ref lstSaved, strTemp, ref bSuccess);
         EnableItems(true, "", "");

         if (bSuccess && !bCancelOperation)
         {
            EnableItems(false, "Storing To PACS Please Wait...", "Cancel");
            try
            {
               strMessage = "\nStoring to PACS:\n";
               foreach (string strFile in lstSaved)
               {
                  try
                  {
                     DoStore(strFile, server);
                  }
                  catch (Exception ex)
                  {
                     logWindow.TopMost = false;
                     EnableItems(true, "", "");
                     MessageBox.Show("Error Occurred: \n" + ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                  }
                  Application.DoEvents();
                  if (bCancelOperation)
                     break;
               }
               bSuccess = true;
               strMessage += "\nFile Stored Successfully";
            }
            catch (System.Exception ex)
            {
               bSuccess = false;
               strMessage += "Error Occurred:\n" + ex.Message;
            }
         }
         File.Delete(strTemp);

         EnableItems(true, "", "");

         if (bSuccess && bStored && !bCancelOperation)
         {
            if (_mySettings._settings.autodelete)
               DeleteCheckedItems();
            logWindow.TopMost = false;
            DialogResult dlgClear = MessageBox.Show(this, strMessage + "\nDo you want to clear the DICOM information?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dlgClear == DialogResult.Yes)
            {
               _miClearPG_Click(null, null);
            }
         }
         else
         {
            logWindow.TopMost = false;
            if (bCancelOperation)
               MessageBox.Show(this, "Operation Cancelled", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
               if (bSuccess)
                  MessageBox.Show(this, "File Was Not Stored Successfully", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
               else
                  MessageBox.Show(this, strMessage, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
         }
         logWindow.TopMost = bTopMost;
      }

      private void _miClearPG_Click(object sender, EventArgs e)
      {
         DicomDataSet ds = _pgDicomInfo.DataSet;
         ds.Dispose();
         _pgDicomInfo.DataSet = null;
         _cmbSopClasses_SelectedIndexChanged(null, null);
      }

      private void _miClearSearch_Click(object sender, EventArgs e)
      {
         if (_tbDicomInfo.SelectedTab == _pageMWLQuery)
         {
            if (!_toolBtnPatient.Checked)
            {
               _bbQuery = new BroadBasedQuery();
               _pgSearchMWL.SelectedObject = _bbQuery;
            }
            else
            {
               _pbQuery = new PatientBasedQuery();
               _pgSearchMWL.SelectedObject = _pbQuery;
            }
         }

         if (_tbDicomInfo.SelectedTab == _pageSCPQuery)
         {
            _findQuery = new DicomFindQuery();
            _pgSearchSCP.SelectedObject = _findQuery;
         }
      }

      private void _lstBoxPages_ItemAdded(object sender, System.EventArgs e)
      {
         try
         {
            if (_lstBoxPages.ViewMode == ThumbMode.Expanded)
            {
               UpdateLabel(_lstBoxPages.SelectedIndex + 1);
            }
            else
            { UpdateLabel(_lstBoxPages.SelectedItemGroupIndex + 1); }
         }
         catch { UpdateLabel(1); }
      }

      private void _lstView_Resize(object sender, EventArgs e)
      {
         SizeColumns(sender as ListView);
      }

      private void _cmbSopClasses_SelectedIndexChanged(object sender, EventArgs e)
      {
         if (_cmbSopClasses.SelectedIndex >= 0)
         {
            DicomDataSet tempDataSet = new DicomDataSet(), sourceDataSet = _pgDicomInfo.DataSet;
            DicomModule module = null;
            //Clone the dataset
            if (sourceDataSet != null)
            {
               tempDataSet.Initialize(_pgDicomInfo.DataSet.InformationClass, DicomDataSetInitializeFlags.AddMandatoryElementsOnly |
               DicomDataSetInitializeFlags.AddMandatoryModulesOnly);

               module = sourceDataSet.FindModule(DicomModuleType.GeneralStudy);
               if (module != null)
                  SetElements(tempDataSet, module.Elements, sourceDataSet);

               module = sourceDataSet.FindModule(DicomModuleType.Patient);
               if (module != null)
                  SetElements(tempDataSet, module.Elements, sourceDataSet);
            }

            InitializeDataSet(ClassTypes[_cmbSopClasses.SelectedIndex]);

            //Restore the dataset
            if (sourceDataSet != null)
            {
               sourceDataSet = tempDataSet;

               module = sourceDataSet.FindModule(DicomModuleType.GeneralStudy);
               if (module != null)
                  SetElements(_pgDicomInfo.DataSet, module.Elements, sourceDataSet);

               module = sourceDataSet.FindModule(DicomModuleType.Patient);
               if (module != null)
                  SetElements(_pgDicomInfo.DataSet, module.Elements, sourceDataSet);

               //ResetModule(DicomModuleType.GeneralSeries, _pgDicomInfo.DataSet);
               GenerateDefaultElements();
            }
            else
            {
               GenerateDefaultElements();
               InsertNewStudyModule();
            }

         }
      }

      private void GenerateDefaultElements()
      {
         GenerateUidTag(_pgDicomInfo.DataSet, DicomTag.SeriesInstanceUID);
         GenerateUidTag(_pgDicomInfo.DataSet, DicomTag.SOPInstanceUID);

         DicomElement dElement = _pgDicomInfo.DataSet.FindFirstElement(null, DicomTag.InstanceNumber, false);
         if (dElement != null)
            _pgDicomInfo.DataSet.SetValue(dElement, "1");

         dElement = _pgDicomInfo.DataSet.FindFirstElement(null, DicomTag.ConversionType, false);
         if (dElement != null)
            _pgDicomInfo.DataSet.SetValue(dElement, "DI");

         dElement = _pgDicomInfo.DataSet.FindFirstElement(null, DicomTag.SeriesNumber, false);
         if (dElement != null)
            _pgDicomInfo.DataSet.SetValue(dElement, "1");

         dElement = _pgDicomInfo.DataSet.FindFirstElement(null, DicomTag.FrameIncrementPointer, false);
         if (dElement != null)
            _pgDicomInfo.DataSet.SetValue(dElement, 0x182001); //HEX 2C6F1H

         dElement = _pgDicomInfo.DataSet.FindFirstElement(null, DicomTag.MIMETypeOfEncapsulatedDocument, false);
         if (dElement != null)
            _pgDicomInfo.DataSet.SetValue(dElement, "PDF");

         if (_pgDicomInfo.DataSet.InformationClass == DicomClassType.SCMultiFrameGrayscaleByteImageStorage ||
            _pgDicomInfo.DataSet.InformationClass == DicomClassType.SCMultiFrameTrueColorImageStorage)
         {
            dElement = _pgDicomInfo.DataSet.FindFirstElement(null, DicomTag.PageNumberVector, true);
            if (dElement == null)
               dElement = _pgDicomInfo.DataSet.InsertElement(null, false, DicomTag.PageNumberVector, DicomVRType.IS, false, 0);
         }

         _pgDicomInfo.DataSet = _pgDicomInfo.DataSet;
      }

      private void InsertNewSeries()
      {
         DicomDataSet ds = _pgDicomInfo.DataSet;
         DicomElement dElement = ds.FindFirstElement(null, DicomTag.Modality, true);
         if (dElement == null)
            ds.InsertElement(null, false, dElement.Tag, dElement.VR, false, 0);
         if (ds.InformationClass == DicomClassType.EncapsulatedPdfStorage)
            ds.SetValue(dElement, "DOC");
         else
            ds.SetValue(dElement, "OT");
         _pgDicomInfo.DataSet = ds;
      }

      private void InsertNewStudyModule()
      {
         DicomElement dElement;
         GenerateUidTag(_pgDicomInfo.DataSet, DicomTag.StudyInstanceUID);

         dElement = _pgDicomInfo.DataSet.FindFirstElement(null, DicomTag.StudyDate, false);
         if (dElement != null)
            _pgDicomInfo.DataSet.SetDateValue(dElement, new DateTime[] { DateTime.Now.Date });

         dElement = _pgDicomInfo.DataSet.FindFirstElement(null, DicomTag.StudyTime, false);
         if (dElement != null)
            _pgDicomInfo.DataSet.SetTimeValue(dElement, new DateTime[] { new DateTime(DateTime.Now.Year, 1, 1, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second) });

         dElement = _pgDicomInfo.DataSet.FindFirstElement(null, DicomTag.StudyID, false);
         if (dElement != null)
            _pgDicomInfo.DataSet.SetValue(dElement, "1");
         _pgDicomInfo.DataSet = _pgDicomInfo.DataSet;
      }

      private void _miEdit_DropDownOpening(object sender, EventArgs e)
      {
         _miRotate90.Enabled = _miDeleteSelected.Enabled = (_lstBoxPages.SelectedItems.Count > 0);
         _miDeleteAll.Enabled = (_lstBoxPages.Items.Count > 0);
         _miPaste.Enabled = Clipboard.ContainsImage();
      }

      private void _miDeleteSelected_Click(object sender, EventArgs e)
      {
         DeleteSelectedItems();

         if (_pictureBox.Image != null)
         {
            _pictureBox.Image.Dispose();
            _pictureBox.Image = null;
         }

         EnableNextPrevious();
         UpdateToolBarState();
         _lblPageInfo.Text = "";
      }

      private void _miResetInfo_Click(object sender, EventArgs e)
      {
         _miClearPG_Click(null, null);
      }

      private void _toolBtnStoreToPacs_Click(object sender, EventArgs e)
      {
         _miStoreToPACS_Click(null, null);
      }

      private void _toolBtnSaveDicom_Click(object sender, EventArgs e)
      {
         _miSaveAsDICOM_Click(null, null);
      }

      private void _toolBtnCLearInfo_Click(object sender, EventArgs e)
      {
         _miClearPG_Click(null, null);
      }

      private void _toolBtnDeleteAll_Click(object sender, EventArgs e)
      {
         _miClearPrintedList_Click(null, null);
      }

      private void _toolBtnDeleteSelected_Click(object sender, EventArgs e)
      {
         _miDeleteSelected_Click(null, null);
      }

      private void _toolBtnViewLog_Click(object sender, EventArgs e)
      {
         _miViewLog_Click(null, null);
      }

      private void _miViewLog_Click(object sender, EventArgs e)
      {
         logWindow.Visible = !logWindow.Visible;
         UpdateToolBarState();
      }

      private void _toolBtnHelp_Click(object sender, EventArgs e)
      {
         _miShowHelp_Click(null, null);
      }

      private void _toolBtnOpenRaster_Click(object sender, EventArgs e)
      {
         _miOpen_Click(null, null);
      }

      private void _toolBtnSettings_Click(object sender, EventArgs e)
      {
         if (DoOptions(0) != DialogResult.Cancel)
            SetServersComboBox(false);
         UpdateComboBoxes();
      }

      private void _btnPACSSettings_Click(object sender, EventArgs e)
      {
         if (DoOptions(1) != DialogResult.Cancel)
            SetServersComboBox(false);
         UpdateComboBoxes();
      }

      private void _miView_DropDownOpening(object sender, EventArgs e)
      {
         _miResample.Enabled = _miFit.Enabled = _miNormal.Enabled = _miZoomIn.Enabled = _miZoomOut.Enabled = (_pictureBox.Image != null);
         RasterPaintProperties prop = _pictureBox.PaintProperties;
         _miResample.Checked = (prop.PaintDisplayMode == RasterPaintDisplayModeFlags.Resample);
         _miNormal.Checked = _pictureBox.SizeMode == RasterPaintSizeMode.Normal;
         _miFit.Checked = _pictureBox.SizeMode == RasterPaintSizeMode.FitAlways;
         _miViewLog.Checked = logWindow.Visible;
         double oldScaleFactor = _pictureBox.ScaleFactor, dZoomFactor = 0.1;
         oldScaleFactor = _pictureBox.ScaleFactor + dZoomFactor;
         _miZoomIn.Enabled = _pictureBox.Image != null && !(oldScaleFactor > 3 && dZoomFactor > 0);
         oldScaleFactor = _pictureBox.ScaleFactor - dZoomFactor;
         _miZoomOut.Enabled = _pictureBox.Image != null && !(oldScaleFactor < .06 && -dZoomFactor < 0);
      }

      private void _cbSevers_SelectedIndexChanged(object sender, EventArgs e)
      {
         MyServer server = (_cbStoreServers.SelectedItem as MyServer);
      }

      private void _toolBtnScreenCapture_Click(object sender, EventArgs e)
      {
         _engine.StopCapture();
         bool bTemp = _isHotKeyEnabled;
         _isHotKeyEnabled = false;
         Leadtools.ScreenCapture.ScreenCaptureOptions opt = _engine.CaptureOptions;
         Keys oldKey = opt.Hotkey;
         opt.Hotkey = Keys.None;
         _engine.CaptureOptions = opt;
         DoCapture(_mySettings._settings.capturetype);
         _isHotKeyEnabled = bTemp;
         opt.Hotkey = oldKey;
         _engine.CaptureOptions = opt;
      }

      void _pictureBox_DoubleClick(object sender, EventArgs e)
      {
         if (_pictureBox.Image != null)
         {
            _pictureBox.SizeMode = RasterPaintSizeMode.FitAlways;
            _pictureBox.ScaleFactor = 1;
         }
      }

      private void _btnPushToPACS_Click(object sender, EventArgs e)
      {
         _toolBtnStoreToPacs_Click(null, null);
      }

      private void _toolBtnPatient_Click(object sender, EventArgs e)
      {
         _toolBtnPatient.Checked = !_toolBtnPatient.Checked;
         if (_toolBtnPatient.Checked)
         {
            _pageMWLQuery.Controls.Add(_tbQueryMWList);
            _pgSearchMWL.SelectedObject = _pbQuery;
            _toolLblMWLType.Text = "Patient Based Search";
         }
         else
         {
            _pageMWLQuery.Controls.Add(_tbQueryMWList);
            _pgSearchMWL.SelectedObject = _bbQuery;
            _toolLblMWLType.Text = "Broad Based Search";
         }
      }

      private void _btnOpenImage_Click(object sender, EventArgs e)
      {
         _toolBtnOpenRaster_Click(null, null);
      }

      private void _btnScreenCapture_Click(object sender, EventArgs e)
      {
         _toolBtnScreenCapture_Click(null, null);
      }

      private void _btnTwainAquire_Click(object sender, EventArgs e)
      {
         _toolBtnTwain_Click(null, null);
      }

      private void _btnWIAAquire_Click(object sender, EventArgs e)
      {
         _toolBtnWia_Click(null, null);
      }

      private void _miHowToUse_Click(object sender, EventArgs e)
      {
         FrmUsage usage = new FrmUsage();
         usage.ShowDialog(this);
      }

      private void _btnBrowseDataSet_Click(object sender, EventArgs e)
      {
         OpenFileDialog dlgOpen = new OpenFileDialog();
         DialogResult dlgRes;
         dlgOpen.Filter = "Dicom Files|*.dcm|Dicom DataSet Files|*.dic|Dicom XML DataSet Files|*.xml";
         dlgOpen.Multiselect = false;
         bool bTopMost = logWindow.TopMost;
         logWindow.TopMost = false;
         dlgRes = dlgOpen.ShowDialog();
         if (dlgRes == DialogResult.Cancel)
         {
            logWindow.TopMost = bTopMost;
            return;
         }

         _txtDataSet.Text = dlgOpen.FileName;
         logWindow.TopMost = bTopMost;

         LoadDataSet(_txtDataSet.Text);
      }
      #endregion

      #region Print Events...

      public void _printer_EmfEvent(object sender, EmfEventArgs e)
      {
         PrintPage printpage = new PrintPage(_jobId);
         this.Enabled = false;
         string tempFile = Path.GetTempFileName();
         printpage.FilePath = tempFile;

         File.WriteAllBytes(tempFile, e.Stream.ToArray());

         Metafile metaFile = new Metafile(e.Stream);
         _pageNo++;

         Image emfImage = metaFile.GetThumbnailImage(150, 110, null, IntPtr.Zero);
         printpage.MetaFile = metaFile.GetHenhmetafile();
         metaFile.Dispose();

         imgCollection.Images.Add(new ListImageBox.ImageItem(_codec.Load(printpage.FilePath), imgCollection, printpage));
         if (_frmProgress.Visible)
         {
            _frmProgress.SetProgressState(_pageNo, _jobId);
         }
         e.Stream.Close();

      }

      public void _printer_JobEvent(object sender, JobEventArgs e)
      {
         if (e.JobEventState == EventState.JobStart)
         {
            this.Enabled = true;
            this.BringToFront();
            this.Focus();
            _pageNo = 0;
            _jobId = e.JobID;
            imgCollection = new ListImageBox.ImageCollection("Print JobID " + _jobId);
            if (!_frmProgress.Visible)
            {
               _frmProgress = new FrmProgress(e.PrinterName, _printer);
               _frmProgress.Show();
            }
         }
         else if (e.JobEventState == EventState.JobEnd)
         {
            _frmProgress.Close();
            _lstBoxPages.AddImageCollection(imgCollection);
            this.Enabled = true;
            this.BringToFront();
            this.Focus();
            //EnableNextPrevious();
            _lstBoxPages.SelectedIndex = 0;
            _lstBoxPages_SelectedIndexChanged(null, null);
            bFinishedPrinting = true;
         }
      }

      #endregion

      #region Methods...

      private void InitializeForm()
      {
         _frmProgress = new FrmProgress();

         _pgDicomInfo = new Leadtools.Dicom.Common.Editing.Controls.DicomPropertyGrid();
         DicomEditableObject = new Leadtools.Dicom.Common.Editing.DicomEditableObject();
         _pictureBox = new Leadtools.WinForms.RasterImageViewer();
         /*TEMP*/
         //this._tbTableLayout.Controls.Add(this._pictureBox, 0, 3);
         // 
         // _pictureBox
         // 
         _pictureBox.BackColor = System.Drawing.SystemColors.ButtonFace;
         _pictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
         _pictureBox.EnableScrollingInterface = true;
         _pictureBox.Location = new System.Drawing.Point(3, 43);
         _pictureBox.Name = "_pictureBox";
         _pictureBox.Size = new System.Drawing.Size(394, 394);
         _pictureBox.TabIndex = 5;
         // 
         // _pgDicomInfo
         // 
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
         _pgDicomInfo.ContextMenuStrip = _cnmnuClearDicom;
         _pgDicomInfo.DataSet = null;
         _pgDicomInfo.DefaultTag = ((long)(-1));
         _pgDicomInfo.Dock = System.Windows.Forms.DockStyle.Fill;
         _pgDicomInfo.Location = new System.Drawing.Point(3, 33);
         _pgDicomInfo.Name = "_pgDicomInfo";
         _pgDicomInfo.SelectedObject = DicomEditableObject;
         _pgDicomInfo.ShowCommands = true;
         _pgDicomInfo.ShowTagInfo = true;
         _pgDicomInfo.ShowUsageImages = true;
         _pgDicomInfo.Size = new System.Drawing.Size(388, 213);
         _pgDicomInfo.TabIndex = 0;
         _tbTableLayout.Controls.Add(_panelImageList, 0, 2);
         _tbTableLayout.SetColumnSpan(_panelImageList, 3);
         _pgDicomInfo.ToolbarVisible = false;
         _pgDicomInfo.BeforeAddElement += new EventHandler<BeforeAddElementEventArgs>(_pgDicomInfo_BeforeAddElement);

         _tbPropertyGrid.Controls.Add(_pgDicomInfo, 0, 1);
         _panelImageList.Controls.Add(_lstBoxPages);
         _lstBoxPages.ViewMode = ThumbMode.Condensed;
         _lstBoxPages.ContextMenuStrip = _cmListBox;
         _lstBoxPages.ListStateChanged += new EventHandler(_lstBoxPages_ListStateChanged);
         _pictureBox.MouseWheel += new MouseEventHandler(_pictureBox_MouseWheel);
         _pictureBox.BorderPadding.Bottom = 10;
         _pictureBox.BorderPadding.Top = 10;
         _pictureBox.BorderPadding.Left = 10;
         _pictureBox.BorderPadding.Right = 10;
         _pictureBox.HorizontalAlignMode = RasterPaintAlignMode.Center;
         _pictureBox.VerticalAlignMode = RasterPaintAlignMode.Center;
         _pictureBox.BackColor = Color.DarkGray;
         _pictureBox.EnableScrollingInterface = true;
         _pictureBox.KeyDown += new KeyEventHandler(_pictureBox_KeyDown);
         _lstBoxPages.ItemDeSlect += new EventHandler(_lstBoxPages_ItemDeSlect);
         _pictureBox.InteractiveMode = Leadtools.WinForms.RasterViewerInteractiveMode.ZoomTo;
         _pictureBox.MouseMove += new MouseEventHandler(_pictureBox_MouseMove);
         _pgSearchSCP.SelectedObject = _findQuery;
         _tbPicture.Controls.Add(_pictureBox, 0, 5);
         _tbPicture.SetColumnSpan(_pictureBox, 4);
         _pgDicomInfo.ShowTagInfo = false;
         _pgDicomInfo.ShowCommands = false;
         _pgDicomInfo.CommandsVisibleIfAvailable = false;
         _pgDicomInfo.HelpVisible = false;
         _pictureBox.DoubleClick += new EventHandler(_pictureBox_DoubleClick);

         string fileClientCertificate = Application.StartupPath + "\\client.pem";
         if (File.Exists(fileClientCertificate))
         {
            if (_mySettings._settings.clientCertificate == string.Empty)
               _mySettings._settings.clientCertificate = Application.StartupPath + "\\client.pem";
            if (_mySettings._settings.privateKey == string.Empty)
               _mySettings._settings.privateKey = Application.StartupPath + "\\client.pem";
            if (_mySettings._settings.privateKeyPassword == string.Empty)
               _mySettings._settings.privateKeyPassword = "test";
         }

         RasterPaintProperties prop = _pictureBox.PaintProperties;
         if (!_mySettings._settings.UseResample)
            prop.PaintDisplayMode = RasterPaintDisplayModeFlags.None;
         else
            prop.PaintDisplayMode = RasterPaintDisplayModeFlags.Resample;
         _pictureBox.PaintProperties = prop;
         Text = "LEADTOOLS C# Print to PACS";
         _codec = new RasterCodecs();
         _cmbSopClasses.SelectedIndex = ClassTypes.IndexOf(_mySettings._settings.selectedtype);

         logWindow = new LogWindow(this);
         logWindow.Visible = false;

         _pageMWLQuery.Controls.Add(_tbQueryMWList);
         _pgSearchMWL.SelectedObject = _bbQuery;

         _txtPrinterName.Text = _printer.PrinterName;
      }

      private void ZoomPicture(double dZoomFactor)
      {
         try
         {
            double oldScaleFactor = _pictureBox.ScaleFactor;
            if (_pictureBox.SizeMode == RasterPaintSizeMode.FitAlways)
            {
               double dWidthFraction = (double)(_pictureBox.Width - 30) / (double)_pictureBox.Image.Width;
               double dHeightFraction = (double)(_pictureBox.Height - 30) / (double)_pictureBox.Image.Height;
               double dScale = dWidthFraction;
               if (dHeightFraction < dWidthFraction)
               {
                  dScale = dHeightFraction;
               }
               _pictureBox.SizeMode = RasterPaintSizeMode.Normal;
               oldScaleFactor = dScale;
            }


            oldScaleFactor = oldScaleFactor + dZoomFactor;
            if (oldScaleFactor > 3 && dZoomFactor > 0)
               return;
            if (oldScaleFactor < .06 && dZoomFactor < 0)
               return;
            _pictureBox.SizeMode = RasterPaintSizeMode.Normal;
            _pictureBox.ScaleFactor = oldScaleFactor;
         }
         catch { }
      }

      private void CreateImageCollection(string strTittle, RasterImage rasterImage)
      {
         ListImageBox.ImageCollection imagecollection = new ListImageBox.ImageCollection(strTittle);
         Page page = new Page();
         string strTemp = null;
         strTemp = Path.GetTempFileName();
         _codec.Save(rasterImage, strTemp, RasterImageFormat.Tif, 0);
         page.FilePath = strTemp;
         page.DeleteOnDispose = true;
         imagecollection.Images.Add(new ListImageBox.ImageItem(_codec.Load(strTemp), imagecollection, page));
         rasterImage.Dispose();

         _lstBoxPages.AddImageCollection(imagecollection);
      }

      private void DeleteCheckedItems()
      {
         for (int i = _lstBoxPages.Items.Count - 1; i >= 0; i--)
         {
            ListImageBox.ListItem item = _lstBoxPages.Items[i];
            if (item.ImageItem.Checked)
            {
               _lstBoxPages.RemoveItem(i);
            }
         }

         try
         {
            _lstBoxPages_SelectedIndexChanged(null, null);
         }
         catch
         {

            if (_pictureBox.Image != null)
            {
               _pictureBox.Image.Dispose();
               _pictureBox.Image = null;
            }

            EnableNextPrevious();
            _lblPageInfo.Text = "";
         }
      }

      private void DeleteSelectedItems()
      {
         for (int i = _lstBoxPages.Items.Count - 1; i >= 0; i--)
         {
            ListImageBox.ListItem item = _lstBoxPages.Items[i];
            if (item.Selected)
            {
               _lstBoxPages.RemoveItem(i);
            }
         }
      }

      public void UpdateToolBarState()
      {
         _toolBtnDeleteAll.Enabled = _lstBoxPages.Items.Count > 0;
         _toolBtnRotate.Enabled = _toolBtnDeleteSelected.Enabled = _lstBoxPages.SelectedItems.Count > 0;
         _toolBtnSaveDicom.Enabled = _lstBoxPages.CheckedItems.Count > 0;
         _btnPushToPACS.Enabled = _toolBtnStoreToPacs.Enabled = _lstBoxPages.CheckedItems.Count > 0 && _mySettings._settings.StoreServers.serverList.Length > 0;
         _btnWIAAquire.Enabled = _toolBtnWia.Enabled = _wiaAvailable && _wiaSourceSelected && !_wiaAcquiring;
         _btnTwainAquire.Enabled = _toolBtnTwain.Enabled = _twainAvailable;
         _btnScreenCapture.Enabled = _toolBtnScreenCapture.Enabled = !(_mySettings._settings.capturetype == CaptureType.None);
         _toolBtnViewLog.Checked = logWindow.Visible;
      }

      private void InitializePrinter()
      {
         bool installPrinter = false;
         if (!PrintingUtilities.IsPrinterExist(_mySettings._settings.printerName))
         {
            installPrinter = true;
            InstallPACSPrinter(_mySettings._settings.printerName);
         }
         if (!PrintingUtilities.IsPrinterExist(_mySettings._settings.printerName))
         {
            if (DemosGlobal.IsAdmin())
               throw new Exception("Error in installing printer, Please Make sure LEADTOOLS Virtual Printer Driver installed\nApplication will close now");
            else
               throw new Exception("Error in installing printer run the demo again with administrative rights\nApplication will close now");
         }
         else
         {
            if(installPrinter)
               MessageBox.Show("Installation " + _mySettings._settings.printerName + " Printer Completed Successfully", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
         }

         _printer = new Printer(_mySettings._settings.printerName);
         _printer.EmfEvent += new EventHandler<EmfEventArgs>(_printer_EmfEvent);
         _printer.JobEvent += new EventHandler<JobEventArgs>(_printer_JobEvent);
      }

      private void InitializeDataSet(DicomClassType dClass)
      {
         DicomDataSet ds = new DicomDataSet();
         try
         {
            if (dClass == DicomClassType.SCImageStorage)
               if (File.Exists(_mySettings._settings.secondaryCapturePath))
                  DicomExtensions.LoadXml(ds, _mySettings._settings.secondaryCapturePath, DicomDataSetLoadXmlFlags.None, null, null);

            if (dClass == DicomClassType.SCMultiFrameTrueColorImageStorage)
               if (File.Exists(_mySettings._settings.secondaryCaptureColorPath))
                  DicomExtensions.LoadXml(ds, _mySettings._settings.secondaryCaptureColorPath, DicomDataSetLoadXmlFlags.None, null, null);

            if (dClass == DicomClassType.SCMultiFrameGrayscaleByteImageStorage)
               if (File.Exists(_mySettings._settings.secondaryCaptureGrayPath))
                  DicomExtensions.LoadXml(ds, _mySettings._settings.secondaryCaptureGrayPath, DicomDataSetLoadXmlFlags.None, null, null);

            if (dClass == DicomClassType.EncapsulatedPdfStorage)
               if (File.Exists(_mySettings._settings.PdfPath))
                  DicomExtensions.LoadXml(ds, _mySettings._settings.PdfPath, DicomDataSetLoadXmlFlags.None, null, null);
         }
         catch { }

         if (ds == null || ds.InformationClass != dClass)
            ds.Initialize(dClass, DicomDataSetInitializeFlags.AddMandatoryElementsOnly |
               DicomDataSetInitializeFlags.AddMandatoryModulesOnly);

         ClearTag(ds, DicomTag.PixelData);
         ClearTag(ds, DicomTag.EncapsulatedDocument);

         DicomElement dElement = ds.FindFirstElement(null, DicomTag.Modality, true);
         if (dElement == null)
            ds.InsertElement(null, false, dElement.Tag, dElement.VR, false, 0);
         if (ds.InformationClass == DicomClassType.EncapsulatedPdfStorage)
            ds.SetValue(dElement, "DOC");
         else
            ds.SetValue(dElement, "OT");

         _pgDicomInfo.DataSet = ds;
      }

      private static void ClearListView(ListView lv)
      {
         foreach (ListViewItem item in lv.Items)
         {
            if (item.Tag != null)
               (item.Tag as DicomDataSet).Dispose();
         }
         lv.Items.Clear();
      }

      private void SizeColumns(ListView lv)
      {
         foreach (ColumnHeader header in lv.Columns)
         {
            header.Width = lv.Width / lv.Columns.Count;
         }
      }

      private void Serialize(String filelocation)
      {
         System.Runtime.Serialization.Formatters.Binary.BinaryFormatter binFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
         FileStream fStream = File.Create(filelocation);
         foreach (ListImageBox.ListItem item in _lstBoxPages.Items)
         {
            item.RasterImage.Dispose();
            item.RasterImage = null;
            item._Controls = null;
            item.ImageItem.Image = null;
            Application.DoEvents();
         }
         binFormatter.Serialize(fStream, _lstBoxPages.ImageCollections);
         fStream.Close();
      }

      private void Deserialize(String filelocation)
      {
         EnableItems(false, "Opening Previous Files Please Wait...", "");
         Thread t = new Thread(delegate()
         {
            try
            {
               System.Runtime.Serialization.Formatters.Binary.BinaryFormatter binFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
               FileStream fStream = File.Open(filelocation, FileMode.Open);
               List<ListImageBox.ImageCollection> lstLoaded = (List<ListImageBox.ImageCollection>)binFormatter.Deserialize(fStream);

               for (int iCol = lstLoaded.Count - 1; iCol >= 0; iCol--)
               {
                  ListImageBox.ImageCollection imgCol = lstLoaded[iCol];
                  for (int iImg = imgCol.Images.Count - 1; iImg >= 0; iImg--)
                  {
                     ListImageBox.ImageItem item = imgCol.Images[iImg];
                     if (item.Tag.GetType() == typeof(PrintPage))
                     {
                        PrintPage printpage = (item.Tag as PrintPage);

                        if (File.Exists(printpage.FilePath))
                        {
                           Image img = Image.FromFile(printpage.FilePath);
                           Metafile mt = img as Metafile;
                           printpage.MetaFile = mt.GetHenhmetafile();
                           mt.Dispose();
                           item.Image = _codec.Load(printpage.FilePath);
                        }
                     }
                     if (item.Tag.GetType() == typeof(Page))
                     {
                        Page page = item.Tag as Page;

                        if (File.Exists(page.FilePath))
                           item.Image = _codec.Load(page.FilePath);
                     }

                     if (item.Image == null)
                        imgCol.Images.Remove(item);

                     Application.DoEvents();
                     if (bCancelOperation)
                        break;
                  }
                  if (imgCol.Images.Count == 0)
                     lstLoaded.Remove(imgCol);
               }
               fStream.Close();

               foreach (ListImageBox.ImageCollection collection in lstLoaded)
               {
                  AddImageCollectionThreaded(collection);
                  Application.DoEvents();
               }
            }
            catch { }
            EnableItems(true, "", "");
         });
         t.Start();
         while (t.IsAlive)
         {
            Application.DoEvents();
         }

      }

      private delegate void AddImageCollectionThreadedDelegate(ListImageBox.ImageCollection collection);
      private void AddImageCollectionThreaded(ListImageBox.ImageCollection collection)
      {
         if (InvokeRequired)
         {
            Invoke(new AddImageCollectionThreadedDelegate(AddImageCollectionThreaded), collection);
         }
         else
         {
            _lstBoxPages.AddImageCollection(collection);
         }
      }

      private void CheckFirstRun()
      {
         if (_mySettings._settings.FirstRun)
         {
            try
            {
               string strFirstImage = DemosGlobal.ImagesFolder + "\\image1.cmp";
               LoadRasterImage(strFirstImage);
               _txtDataSet.Text = DemosGlobal.ImagesFolder + "\\image2.dcm";
               LoadDataSet(_txtDataSet.Text);
               _btnTransferLoadedStudies_Click(null, null);
               _lstBoxPages.SelectedIndex = 0;
               _lstBoxPages.Items[0].ImageItem.Checked = true;
               _lstBoxPages.Items[0].CheckState = CheckState.Checked;
               _btnPushToPACS.Enabled = true;
               FrmUsage usage = new FrmUsage();
               usage.ShowDialog(this);
            }
            catch { }
         }
         else
         {
            try
            {
               _lstBoxPages.SelectedIndex = _mySettings._settings.LastSelectedIndex;
            }
            catch { }
         }
      }

      private void ShowHelp()
      {
         base.Activate();
         if (_mySettings._settings.showHelpOnStart)
         {
            HelpDialog dlg = new HelpDialog(null, true, _mySettings._settings.FirstRun);
            dlg.ShowDialog(this);
            if (dlg.CheckBoxNoShowAgainResult)
            {
               _mySettings._settings.showHelpOnStart = false;
               _mySettings.Save();
            }
         }
      }

      private void UpdateComboBoxes()
      {
         int iSCPIndex = _cbSCPServers.SelectedIndex, iMWLIndex = _cbMWLServers.SelectedIndex, iStoreIndex = _cbStoreServers.SelectedIndex;
         if (_cbSCPServers.Items.Count != 0)
            if (_cbSCPServers.Items.Count > iSCPIndex && iSCPIndex >= 0)
               _cbSCPServers.SelectedIndex = iSCPIndex;
            else
               if (_cbSCPServers.Items.Count > _mySettings._settings.DefaultSCPServer)
                  _cbSCPServers.SelectedIndex = _mySettings._settings.DefaultSCPServer;
               else
                  _cbSCPServers.SelectedIndex = 0;

         if (_cbMWLServers.Items.Count != 0)
            if (_cbMWLServers.Items.Count > iMWLIndex && iMWLIndex >= 0)
               _cbMWLServers.SelectedIndex = iMWLIndex;
            else
               if (_cbMWLServers.Items.Count > _mySettings._settings.DefaultMWLServer)
                  _cbMWLServers.SelectedIndex = _mySettings._settings.DefaultMWLServer;
               else
                  _cbMWLServers.SelectedIndex = 0;

         if (_cbStoreServers.Items.Count != 0)
            if (_cbStoreServers.Items.Count > iStoreIndex && iStoreIndex >= 0)
               _cbStoreServers.SelectedIndex = iStoreIndex;
            else
               if (_cbStoreServers.Items.Count > _mySettings._settings.DefaultStoreServer)
                  _cbStoreServers.SelectedIndex = _mySettings._settings.DefaultStoreServer;
               else
                  _cbStoreServers.SelectedIndex = 0;
      }

      DialogResult DoOptions(int iSelectedTab)
      {
         OptionsDialog options = new OptionsDialog();
         options.serverlistSCP = (MyServerList)_mySettings._settings.QuerySCPServers.Clone();
         options.serverlistMWL = (MyServerList)_mySettings._settings.QueryMWLServers.Clone();
         options.serverlistStore = (MyServerList)_mySettings._settings.StoreServers.Clone();
         options.SelectedTab = iSelectedTab;

         options.ClientAE = _mySettings._settings.clientAE;
         options.ClientCertificate = _mySettings._settings.clientCertificate;
         options.PrivateKey = _mySettings._settings.privateKey;
         options.PrivateKeyPassword = _mySettings._settings.privateKeyPassword;
         options.LogLowLevel = _mySettings._settings.logLowLevel;

         options.AutoDelete = _mySettings._settings.autodelete;

         options.TempDirectory = _mySettings._settings.TempDir;
         options.Selectedtype = _mySettings._settings.selectedtype;

         options.SCCompression = _mySettings._settings.secondaryCaptureCompression;
         options.SCColorCompression = _mySettings._settings.secondaryCaptureColorCompression;
         options.SCGrayCompression = _mySettings._settings.secondaryCaptureGrayCompression;

         options.SCGrayPath = _mySettings._settings.secondaryCaptureGrayPath;
         options.SCColorPath = _mySettings._settings.secondaryCaptureColorPath;
         options.SCPath = _mySettings._settings.secondaryCapturePath;
         options.PdfPath = _mySettings._settings.PdfPath;

         options.PrinterName = _mySettings._settings.printerName;

         options.DefaultSCPServer = _mySettings._settings.DefaultSCPServer;
         options.DefaultMWLServer = _mySettings._settings.DefaultMWLServer;
         options.DefaultStoreServer = _mySettings._settings.DefaultStoreServer;
         bool bTopMost = logWindow.TopMost;
         logWindow.TopMost = false;
         DialogResult dr = options.ShowDialog(this);
         if (dr == DialogResult.OK)
         {
            _mySettings._settings.clientAE = options.ClientAE;
            _mySettings._settings.clientCertificate = options.ClientCertificate;
            _mySettings._settings.privateKey = options.PrivateKey;
            _mySettings._settings.privateKeyPassword = options.PrivateKeyPassword;
            _mySettings._settings.logLowLevel = options.LogLowLevel;

            _mySettings._settings.querySCPServers = options.serverlistSCP;
            _mySettings._settings.queryMWLServers = options.serverlistMWL;
            _mySettings._settings.storeServers = options.serverlistStore;

            _mySettings._settings.autodelete = options.AutoDelete;

            _mySettings._settings.TempDir = options.TempDirectory;
            _mySettings._settings.selectedtype = options.Selectedtype;

            _mySettings._settings.secondaryCaptureCompression = options.SCCompression;
            _mySettings._settings.secondaryCaptureColorCompression = options.SCColorCompression;
            _mySettings._settings.secondaryCaptureGrayCompression = options.SCGrayCompression;

            _mySettings._settings.secondaryCaptureGrayPath = options.SCGrayPath;
            _mySettings._settings.secondaryCaptureColorPath = options.SCColorPath;
            _mySettings._settings.secondaryCapturePath = options.SCPath;
            _mySettings._settings.PdfPath = options.PdfPath;

            _mySettings._settings.DefaultSCPServer = options.DefaultSCPServer;
            _mySettings._settings.DefaultMWLServer = options.DefaultMWLServer;
            _mySettings._settings.DefaultStoreServer = options.DefaultStoreServer;

            if (_mySettings._settings.printerName != options.PrinterName)
            {
               try
               {
                  PrinterInfo printerInfo = new PrinterInfo();
                  printerInfo.PrinterName = _mySettings._settings.printerName;

                  if (!InstallPACSPrinter(options.PrinterName))
                  {
                     MessageBox.Show("Error in renaming printer\nExit the demo and run it with administrative rights", "Print to PACS demo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                  }
                  else
                  {
                     _mySettings._settings.printerName = options.PrinterName;
                     MessageBox.Show("Printer renamed to " + _mySettings._settings.printerName + " completed successfully", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                     _printer = new Printer(options.PrinterName);
                     _printer.EmfEvent += new EventHandler<EmfEventArgs>(_printer_EmfEvent);
                     _printer.JobEvent += new EventHandler<JobEventArgs>(_printer_JobEvent);
                     Printer.UnInstall(printerInfo);
                  }
               }
               catch { }
            }
            _mySettings.Save();
         }
         _txtPrinterName.Text = _printer.PrinterName;
         logWindow.TopMost = bTopMost;
         return dr;
      }

      public void EnableItems(bool enable, string strCaption, string strBtnCaption)
      {
         if (this.InvokeRequired)
         {
            Invoke(new EnableMenu(EnableItems), new object[] { enable, strCaption, strBtnCaption });
         }
         else
         {
            if (enable)
               Cursor.Current = Cursors.Arrow;
            else
               Cursor.Current = Cursors.WaitCursor;

            _mmMain.Enabled = enable;
            _lstBoxPages.Enabled = enable;
            _tbDicomInfo.Enabled = enable;
            _cmbSopClasses.Enabled = enable;
            _cbStoreServers.Enabled = enable;
            _btnPushToPACS.Enabled = enable;
            _toolbarMain.Enabled = enable;
            _pgDicomInfo.Enabled = enable;
            _btnScreenCapture.Enabled = enable;
            _btnPACSSettings.Enabled = enable;
            _btnOpenImage.Enabled = enable;
            _btnWIAAquire.Enabled = enable;
            _btnTwainAquire.Enabled = enable;
            if (enable)
            {
               UpdateToolBarState();
               if (_frmOperation != null)
                  _frmOperation.Close();
            }
            else
            {
               if (!(strCaption == "" && strBtnCaption == ""))
                  if (_frmOperation == null || !_frmOperation.Visible)
                  {
                     _frmOperation = new FrmOperation(strCaption, strBtnCaption);
                     bCancelOperation = false;
                     if (strBtnCaption != "")
                        _frmOperation.Cancel += new EventHandler(_frmOperation_Cancel);
                     _frmOperation.Show();
                  }
            }
         }
      }

      private Rectangle GetFitRect(Rectangle rect, int width, int height)
      {
         int newWidth = 0;
         int newHeight = 0;

         newHeight = rect.Height;
         newWidth = newHeight * width / height;

         if (newWidth > rect.Width)
         {
            newWidth = rect.Width;
            newHeight = newWidth * height / width;
         }

         return new Rectangle(rect.Left, rect.Top, newWidth, newHeight);
      }

      private bool InstallPACSPrinter(string printername)
      {
         bool bRet = false;
         bool bExsists = PrintingUtilities.IsPrinterExist(printername);

         if (!bExsists)
         {
            bRet = PrintingUtilities.InstallNewPrinter(printername, "");
         }
         return bRet || bExsists;
      }

      private void EnableNextPrevious()
      {
         _btnNext.Enabled = true;
         _btnPrev.Enabled = true;

         if (_lstBoxPages.Items.Count == 0)
         {
            _btnPrev.Enabled = false;
            _btnNext.Enabled = false;
            return;
         }

         if (_lstBoxPages.ViewMode == ThumbMode.Condensed)
         {
            if (_lstBoxPages.SelectedItemGroupIndex < 0)
            {
               _btnPrev.Enabled = false;
               _btnNext.Enabled = false;
               return;
            }
            if (_lstBoxPages.SelectedItemGroupIndex <= 0)
               _btnPrev.Enabled = false;

            if (_lstBoxPages.SelectedItemGroupIndex == _lstBoxPages.GetSelectedImageCollection().Images.Count - 1)
               _btnNext.Enabled = false;
         }
         else
         {
            if (_lstBoxPages.SelectedIndex <= 0)
               _btnPrev.Enabled = false;

            if (_lstBoxPages.SelectedIndex == _lstBoxPages.Items.Count - 1)
               _btnNext.Enabled = false;

         }
      }

      private void ScalePicture(PrintToPACSDemo.UI.ListImageBox.ImageItem item)
      {
         if (_pictureBox.Image != null)
         {
            _pictureBox.Image.Dispose();
            _pictureBox.Image = null;
         }
         _pictureBox.Image = item.Image.Clone();

         _pictureBox_DoubleClick(null, null);

         if (_lstBoxPages.ViewMode == ThumbMode.Condensed)
            UpdateLabel(_lstBoxPages.SelectedItemGroupIndex + 1);
         else
            UpdateLabel(_lstBoxPages.SelectedIndex + 1);
      }

      private void UpdateLabel(int iSelectedindex)
      {
         try
         {
            _lblPageInfo.Text = "Page " + (iSelectedindex).ToString() + " / " + (_lstBoxPages.GetGroupImageItems().Count).ToString();
         }
         catch { _lblPageInfo.Text = ""; }
      }

      private void InitClass()
      {
         if (RasterSupport.IsLocked(RasterSupportType.PrintDriver) && RasterSupport.IsLocked(RasterSupportType.PrintDriverServer))
         {
            throw new Exception("Printer driver capability is required.");
         }
      }

      private void ClearList()
      {
         try
         {
            DeleteTempFiles();
            _lstBoxPages.ClearList();
            if (_pictureBox.Image != null)
            {
               _pictureBox.Image.Dispose();
               _pictureBox.Image = null;
            }
         }
         catch (Exception Ex)
         {
            MessageBox.Show(Ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
         }
      }

      private void DeleteTempFiles()
      {
         foreach (ListImageBox.ListItem item in _lstBoxPages.Items)
         {
            try
            {
               item.Dispose();
            }
            catch
            {
            }
         }
      }

      public void LogError(string sLogText)
      {
         LogText("*** ERROR *** ", _sNewlineTab + sLogText, Color.Red);
      }

      public void LogText(string action, string logText)
      {
         if (this.InvokeRequired)
         {
            this.Invoke(new AddLog(LogText),
               new object[] { action, logText });
         }
         else
         {
            AddAction(action);
            logWindow.RichTextBox.AppendText(logText);
            logWindow.RichTextBox.AppendText("\r\n");
            logWindow.RichTextBox.ScrollToCaret();
         }
      }

      public void LogText(string sAction, string sLogText, Color sActionColor)
      {
         if (this.InvokeRequired)
         {
            this.Invoke(new AddLogColor(LogText), new object[] { sAction, sLogText, sActionColor });
         }
         else
         {
            AddAction(sAction, sActionColor);
            logWindow.RichTextBox.AppendText(sLogText);
            logWindow.RichTextBox.AppendText(_sNewline);
            TextBoxTraceListener.SendMessage(logWindow.RichTextBox.Handle, TextBoxTraceListener.WM_VSCROLL, TextBoxTraceListener.SB_BOTTOM, 0);
         }
      }

      private void AddAction(string sAction, Color color)
      {
         System.Drawing.Color oldColor = logWindow.RichTextBox.SelectionColor;

         logWindow.RichTextBox.SelectionLength = 0;
         logWindow.RichTextBox.SelectionStart = logWindow.RichTextBox.Text.Length;
         logWindow.RichTextBox.SelectionColor = color;
         logWindow.RichTextBox.SelectionFont = new Font(logWindow.RichTextBox.SelectionFont, FontStyle.Bold);
         logWindow.RichTextBox.AppendText(sAction + ": ");
         logWindow.RichTextBox.SelectionColor = oldColor;
      }

      private void AddAction(string action)
      {
         System.Drawing.Color oldColor = logWindow.RichTextBox.SelectionColor;
         if (action == "")
         {
            return;
         }
         logWindow.RichTextBox.SelectionLength = 0;
         logWindow.RichTextBox.SelectionStart = logWindow.RichTextBox.Text.Length;
         logWindow.RichTextBox.SelectionColor = Color.Blue;
         logWindow.RichTextBox.SelectionFont = new Font(logWindow.RichTextBox.SelectionFont, FontStyle.Bold);
         logWindow.RichTextBox.AppendText(action + ": ");

         logWindow.RichTextBox.SelectionColor = oldColor;
      }

      public delegate void StartUpdateDelegate(DataGridView lv);
      private void StartUpdate(DataGridView dg)
      {
         if (InvokeRequired)
         {
            Invoke(new StartUpdateDelegate(StartUpdate), dg);
         }
         else
         {
            dg.Rows.Clear();
         }
      }

      private void SetServersComboBox(bool bSelectDefault)
      {
         _cbSCPServers.Items.Clear();
         _cbMWLServers.Items.Clear();
         _cbStoreServers.Items.Clear();

         MyServer[] list;
         int defaultserver = 0;

         list = _mySettings._settings.QuerySCPServers.serverList;
         defaultserver = _mySettings._settings.DefaultSCPServer;

         if (list.Length == 0)
         {
            _tbQuerySCPList.Enabled = false;
         }
         else
         {
            _tbQuerySCPList.Enabled = true;
            foreach (MyServer server in list)
            {
               _cbSCPServers.Items.Add(server);
            }
            if (bSelectDefault)
               if (defaultserver < list.Length)
                  _cbSCPServers.SelectedIndex = defaultserver;
               else
                  _cbSCPServers.SelectedIndex = 0;
         }

         list = _mySettings._settings.StoreServers.serverList;
         defaultserver = _mySettings._settings.DefaultStoreServer;

         if (list.Length == 0)
         {
            _toolBtnStoreToPacs.Enabled = _miStoreToPACS.Enabled = _grpStoreServers.Enabled = false;

         }
         else
         {
            _miStoreToPACS.Enabled = _grpStoreServers.Enabled = true;
            UpdateToolBarState();
            foreach (MyServer server in list)
            {
               _cbStoreServers.Items.Add(server);
            }
            if (bSelectDefault)
               if (defaultserver < list.Length)
                  _cbStoreServers.SelectedIndex = defaultserver;
               else
                  _cbStoreServers.SelectedIndex = 0;
         }


         list = _mySettings._settings.QueryMWLServers.serverList;
         defaultserver = _mySettings._settings.DefaultMWLServer;

         if (list.Length == 0)
         {
            _tbQueryMWList.Enabled = false;
         }
         else
         {
            _tbQueryMWList.Enabled = true;
            foreach (MyServer server in list)
            {
               _cbMWLServers.Items.Add(server);
            }
            if (bSelectDefault)
               if (defaultserver < list.Length)
                  _cbMWLServers.SelectedIndex = defaultserver;
               else
                  _cbMWLServers.SelectedIndex = 0;
         }
      }

      private void LoadSettings()
      {
         try
         {
            // Settings are stored at:
            // %USERPROFILE%\Local Settings\Application Data\<Company Name>\<appdomainname>_<eid>_<hash>\<verison>\user.config
            _mySettings.Load();
         }
         catch (Exception ex)
         {
            System.Diagnostics.Debug.Assert(false, ex.Message);
         }
      }

      private void LoadRasterImage(string strFileName)
      {
         bool bTopMost = logWindow.TopMost;
         RasterImage rImg = null;
         try
         {
            EnableItems(false, "Opening Image Files Please Wait...", "Cancel");
            string strFile = strFileName;
            strLastLocation = strFile;
            rImg = _codec.Load(strFile);

            GrayscaleCommand command = new GrayscaleCommand(8);
            if (rImg.IsGray && rImg.BitsPerPixel != 8)
               command.Run(rImg);

            ListImageBox.ImageCollection imagecollection = new ListImageBox.ImageCollection(Path.GetFileName(strFile));
            Page page = new Page();
            for (int i = 1; i <= rImg.PageCount; i++)
            {
               string strTemp = null;
               rImg.Page = i;

               page = new Page();
               strTemp = Path.GetTempFileName();
               int iBPP = rImg.BitsPerPixel;
               if (iBPP < 8)
                  iBPP = 8;
               RasterImage rTempRaster = rImg.Clone();
               _codec.Save(rTempRaster, strTemp, RasterImageFormat.Tif, iBPP);
               rTempRaster.Dispose();
               page.FilePath = strTemp;
               page.DeleteOnDispose = true;
               imagecollection.Images.Add(new ListImageBox.ImageItem(_codec.Load(strTemp), imagecollection, page));
               Application.DoEvents();
               if (bCancelOperation)
                  break;
            }
            rImg.Dispose();
            _lstBoxPages.AddImageCollection(imagecollection);
         }
         catch (System.Exception ex)
         {
            if (rImg != null)
               rImg.Dispose();

            ShowErrorMessage(ex);
         }
         EnableItems(true, "", "");
         logWindow.TopMost = bTopMost;
      }

      #endregion

      #region Dicom Methods

      private void LoadDataSet(string strFileName)
      {
         bool bTopMost = logWindow.TopMost;
         logWindow.TopMost = false;
         if (!File.Exists(strFileName))
         {
            MessageBox.Show("The selected file does not exist", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
         }
         try
         {
            _btnTransferLoadedPatient.Enabled = _btnTransferLoadedStudies.Enabled = false;

            DicomDataSet dicom = new DicomDataSet();

            if (Path.GetExtension(strFileName) == ".xml")
               DicomExtensions.LoadXml(dicom, strFileName, DicomDataSetLoadXmlFlags.None, null, null);
            else
               dicom.Load(strFileName, DicomDataSetLoadFlags.None);

            ClearTag(dicom, DicomTag.PixelData);
            ClearTag(dicom, DicomTag.EncapsulatedDocument);

            DicomElement dElement;
            ListViewItem item = null;

            string val = "";

            foreach (long dTag in DICOMPatientInfo)
            {
               dElement = dicom.FindFirstElement(null, dTag, true);
               val = "";
               if (dElement != null)
                  val = dicom.GetValue<string>(dElement, null);

               if (item == null)
                  item = _lstDSPatient.Items.Add(val);
               else
                  item.SubItems.Add(val);
            }
            item.Tag = dicom;
            item.Selected = true;
            //Series
         }
         catch { MessageBox.Show("The selected file is not a valid dicom file", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error); }
         logWindow.TopMost = bTopMost;
      }

      private void SetElements(DicomDataSet dicomDestination, DicomElement[] elements, DicomDataSet dicomSource)
      {
         foreach (DicomElement item in elements)
         {
            if (item.Length == 0)
               continue;

            DicomElement element;
            element = dicomDestination.FindFirstElement(null, item.Tag, true);
            if (element == null)
               element = dicomDestination.InsertElement(null, false, item.Tag, item.VR, false, 0);
            switch (item.VR)
            {
               case DicomVRType.DA:
                  dicomDestination.SetDateValue(element, dicomSource.GetDateValue(item, 0, 1));
                  break;
               case DicomVRType.TM:
                  dicomDestination.SetTimeValue(element, dicomSource.GetTimeValue(item, 0, 1));
                  break;
               default:
                  {
                     byte[] ba = dicomSource.GetBinaryValue(item, (int)item.Length);
                     dicomDestination.FreeElementValue(element);
                     bool ret = dicomDestination.SetBinaryValue(element, ba, (int)ba.Length);
                  }
                  break;
            }
         }
         _pgDicomInfo.DataSet = dicomDestination;
      }

      private List<string> SaveDicom(DicomDataSet dicom, string strSaveFile)
      {
         try
         {
            byte[] value = new byte[] { 0x00, 0x01 };
            dicom.InsertElementAndSetValue ( DicomTag.FileMetaInformationVersion, value) ;
            dicom.InsertElementAndSetValue ( DicomTag.MediaStorageSOPClassUID, dicom.GetValue<string> ( DicomTag.SOPClassUID, string.Empty) ) ;
            dicom.InsertElementAndSetValue ( DicomTag.MediaStorageSOPInstanceUID, dicom.GetValue<string> ( DicomTag.SOPInstanceUID, string.Empty)) ;
            dicom.InsertElementAndSetValue ( DicomTag.ImplementationClassUID, "1.2.840.114257.1123456" ) ;
            dicom.InsertElementAndSetValue ( DicomTag.ImplementationVersionName, "LEADPRINTTOPACS" ) ;
            
            List<string> saved = new List<string>();
            
            int bit = 0;
            if (ClassTypes[_cmbSopClasses.SelectedIndex] == DicomClassType.EncapsulatedPdfStorage)
            {
               DocumentFormat documentFormat = DocumentFormat.User;
               DocumentOptions documentOptions = null;
               PdfDocumentOptions PdfdocumentOptions = new PdfDocumentOptions();
               string fileName;
               fileName = Path.GetTempFileName();
               documentFormat = DocumentFormat.Pdf;
               documentOptions = new PdfDocumentOptions();
               (documentOptions as PdfDocumentOptions).DocumentType = PdfDocumentType.Pdf;
               (documentOptions as PdfDocumentOptions).FontEmbedMode = DocumentFontEmbedMode.Auto;
               documentOptions.PageRestriction = DocumentPageRestriction.Relaxed;
               DocumentWriter documentWriter = new DocumentWriter();
               documentWriter.SetOptions(documentFormat, documentOptions);
               documentWriter.BeginDocument(fileName, documentFormat);

               foreach (ListImageBox.ListItem item in _lstBoxPages.CheckedItems)
               {
                  DocumentWriterEmfPage documentPage = new DocumentWriterEmfPage();
                  if (item.ImageItem.Tag.GetType() == typeof(PrintPage))
                     documentPage.EmfHandle = (item.ImageItem.Tag as PrintPage).MetaFile;
                  else
                  {
                     RasterImage rI = _codec.Load((item.ImageItem.Tag as IPrintToPACSFile).FileLocation());
                     documentPage.EmfHandle = Leadtools.Drawing.RasterImageConverter.ChangeToEmf(rI);
                     rI.Dispose();
                  }

                  documentWriter.AddPage(documentPage);
                  Application.DoEvents();
                  if (bCancelOperation)
                     break;
               }

               documentWriter.EndDocument();
               SetIncapsualtedDoc(dicom, fileName);
               File.Delete(fileName);
               saved.Add(strSaveFile);
               dicom.Save(strSaveFile, DicomDataSetSaveFlags.ExplicitVR | DicomDataSetSaveFlags.MetaHeaderPresent);

               //Delete Element
               ClearTag(dicom, DicomTag.EncapsulatedDocument);
               ClearTag(dicom, DicomTag.HL7InstanceIdentifier);
               ClearTag(dicom, DicomTag.ListOfMIMETypes);
               ClearTag(dicom, DicomTag.VerificationFlag);

               DicomElement dElement = _pgDicomInfo.DataSet.FindFirstElement(null, DicomTag.MIMETypeOfEncapsulatedDocument, false);
               if (dElement != null)
                  _pgDicomInfo.DataSet.SetValue(dElement, "PDF");
            }

            if (ClassTypes[_cmbSopClasses.SelectedIndex] == DicomClassType.SCImageStorage)
            {
               //Pixel Data
               int i = 0;
               foreach (ListImageBox.ListItem item in _lstBoxPages.CheckedItems)
               {
                  i++;

                  DicomElement dInstance = dicom.FindFirstElement(null, DicomTag.InstanceNumber, true);
                  if (dInstance == null)
                     dInstance = dicom.InsertElement(null, false, DicomTag.InstanceNumber, DicomVRType.OW, false, 0);
                  dicom.SetValue(dInstance, i);

                  DicomElement dPixel = dicom.FindFirstElement(null, DicomTag.PixelData, true);
                  if (dPixel == null)
                  {
                     dPixel = dicom.InsertElement(null, false, DicomTag.PixelData, DicomVRType.OW, false, 0);
                  }
                  else
                  {
                     dicom.DeleteElement(dPixel);
                     dPixel = dicom.InsertElement(null, false, DicomTag.PixelData, DicomVRType.OW, false, 0);
                  }

                  RasterImage rI = null;
                  if (rI == null)
                     rI = _codec.Load((item.ImageItem.Tag as IPrintToPACSFile).FileLocation());

                  DicomImagePhotometricInterpretationType imagePhotoMetric = DicomImagePhotometricInterpretationType.Rgb;
                  if (rI.IsGray)
                  {
                     bit = 8;
                     imagePhotoMetric = DicomImagePhotometricInterpretationType.Monochrome2;
                     if (rI.BitsPerPixel == 12 || rI.BitsPerPixel == 16)
                     {
                        GrayscaleCommand grayCommand = new GrayscaleCommand(bit);
                        grayCommand.Run(rI);
                     }
                  }
                  else
                  {
                     bit = 24;
                     ColorResolutionCommand colorRes = new ColorResolutionCommand();
                     colorRes.BitsPerPixel = bit;
                     colorRes.Order = RasterByteOrder.Rgb;
                     colorRes.Mode = ColorResolutionCommandMode.InPlace;
                     colorRes.Run(rI);
                  }

                  dicom.SetImage(dPixel,
                                    rI,
                                    _mySettings._settings.secondaryCaptureCompression,
                                    imagePhotoMetric,
                                    bit,
                                    2,
                                    DicomSetImageFlags.AutoSetVoiLut);
                  rI.Dispose();

                  GenerateUidTag(dicom, DicomTag.SOPInstanceUID);

                  string strFile = Path.GetDirectoryName(strSaveFile) + "\\" + Path.GetFileNameWithoutExtension(strSaveFile) + "_" + i + Path.GetExtension(strSaveFile);
                  saved.Add(strFile);
                  dicom.Save(strFile, DicomDataSetSaveFlags.ExplicitVR | DicomDataSetSaveFlags.MetaHeaderPresent);
                  Application.DoEvents();
                  if (bCancelOperation)
                     break;
               }
               ClearTag(dicom, DicomTag.PixelData);
               ClearTag(dicom, DicomTag.WindowCenter);
               ClearTag(dicom, DicomTag.WindowWidth);
               DicomElement dInstElement = dicom.FindFirstElement(null, DicomTag.InstanceNumber, true);
               if (dInstElement == null)
                  dInstElement = dicom.InsertElement(null, false, DicomTag.InstanceNumber, DicomVRType.OW, false, 0);
               dicom.SetValue(dInstElement, "1");

            }

            if (ClassTypes[_cmbSopClasses.SelectedIndex] == DicomClassType.SCMultiFrameTrueColorImageStorage ||
               ClassTypes[_cmbSopClasses.SelectedIndex] == DicomClassType.SCMultiFrameGrayscaleByteImageStorage)
            {

               //Pixel Data
               DicomElement dPixel = dicom.FindFirstElement(null, DicomTag.PixelData, true);
               if (dPixel == null)
                  dPixel = dicom.InsertElement(null, false, DicomTag.PixelData, DicomVRType.OW, false, 0);

               DicomElement dPageVector = dicom.FindFirstElement(null, DicomTag.PageNumberVector, true);

               RasterImage rI = null;

               int i = 1;
               List<int> intArray = new List<int>();

               DicomImageCompressionType compression = DicomImageCompressionType.None;
               DicomImagePhotometricInterpretationType imagephotemetric = DicomImagePhotometricInterpretationType.Rgb;
               ColorResolutionCommand colorRes = new ColorResolutionCommand();
               if (ClassTypes[_cmbSopClasses.SelectedIndex] == DicomClassType.SCMultiFrameTrueColorImageStorage)
               {
                  compression = _mySettings._settings.secondaryCaptureColorCompression;
                  imagephotemetric = DicomImagePhotometricInterpretationType.Rgb;
                  bit = 24;
                  colorRes.BitsPerPixel = bit;
                  colorRes.Order = RasterByteOrder.Bgr;
                  colorRes.Mode = ColorResolutionCommandMode.InPlace;
               }
               else
               {
                  compression = _mySettings._settings.secondaryCaptureGrayCompression;
                  imagephotemetric = DicomImagePhotometricInterpretationType.Monochrome2;
                  bit = 8;
                  colorRes.BitsPerPixel = bit;
                  colorRes.Order = RasterByteOrder.Gray;
                  colorRes.Mode = ColorResolutionCommandMode.InPlace;
               }
               foreach (ListImageBox.ListItem item in _lstBoxPages.CheckedItems)
               {
                  intArray.Add(i);
                  i++;
                  if (rI == null)
                  {
                     rI = _codec.Load((item.ImageItem.Tag as IPrintToPACSFile).FileLocation());
                     colorRes.Run(rI);
                     continue;
                  }
                  RasterImage rasterimage = _codec.Load((item.ImageItem.Tag as IPrintToPACSFile).FileLocation());
                  colorRes.Run(rasterimage);
                  rI.AddPage(rasterimage);
                  Application.DoEvents();
                  if (bCancelOperation)
                     break;
               }

               RasterImage rImg = null;
               rI.Page = 1;
               int iMaxWidth = rI.Width, iMaxHeight = rI.Height;
               int iPage;
               for (iPage = 1; iPage <= rI.PageCount; iPage++)
               {
                  rI.Page = iPage;
                  rImg = rI;
                  if (rImg.Width > iMaxWidth)
                  {
                     iMaxWidth = rImg.Width;
                  }

                  if (rImg.Height > iMaxHeight)
                  {
                     iMaxHeight = rImg.Height;
                  }
               }

               RasterImage rImgNew = null;
               List<RasterImage> lstRaster = new List<RasterImage>();
               for (iPage = 1; iPage <= rI.PageCount; iPage++)
               {
                  rI.Page = iPage;
                  rImg = rI;
                  if (rImg.ImageSize.Width < iMaxWidth || rImg.ImageSize.Height < iMaxHeight)
                  {
                     rImgNew = new RasterImage(RasterMemoryFlags.Conventional, iMaxWidth, iMaxHeight, bit, RasterByteOrder.Bgr, rImg.ViewPerspective, rImg.GetPalette(), IntPtr.Zero, 0);
                     FillCommand fillCommand = new FillCommand();
                     fillCommand.Color = RasterColorConverter.FromColor(Color.White);
                     fillCommand.Run(rImgNew);
                     CombineCommand combine = new CombineCommand();
                     int xStart, yStart;
                     xStart = Math.Abs(rImgNew.Width - rImg.Width) / 2;
                     yStart = Math.Abs(rImgNew.Height - rImg.Height) / 2;
                     combine.DestinationRectangle = new LeadRect(xStart, yStart, rImg.Width, rImg.Height);
                     combine.SourcePoint = new LeadPoint(0, 0);
                     combine.SourceImage = rImg;
                     combine.Flags = CombineCommandFlags.OperationAdd | CombineCommandFlags.Destination0;
                     combine.Run(rImgNew);
                     lstRaster.Add(rImgNew.Clone());
                  }
                  else
                  {
                     lstRaster.Add(rImg.Clone());
                  }
               }
               rI.Dispose();
               rI = null;
               foreach (RasterImage rasterimage in lstRaster)
               {
                  if (rI == null)
                     rI = rasterimage;
                  else
                     rI.InsertPage(rI.PageCount + 1, rasterimage);
               }

               saved.Add(strSaveFile);
               dicom.SetIntValue(dPageVector, intArray.ToArray(), intArray.Count);
               dicom.SetImages(dPixel,
                     rI,
                     compression,
                     imagephotemetric,
                     bit,
                     2,
                     DicomSetImageFlags.AutoSetVoiLut);
               dicom.Save(strSaveFile, DicomDataSetSaveFlags.ExplicitVR | DicomDataSetSaveFlags.MetaHeaderPresent);
               rI.Dispose();
               //Delete Element
               ClearTag(dicom, DicomTag.PixelData);
               ClearTag(dicom, DicomTag.WindowCenter);
               ClearTag(dicom, DicomTag.WindowWidth);
               ClearTag(dicom, DicomTag.RescaleIntercept);
               ClearTag(dicom, DicomTag.RescaleSlope);
               ClearTag(dicom, DicomTag.RescaleType);
               ClearTag(dicom, DicomTag.PageNumberVector);
            }
            GenerateUidTag(dicom, DicomTag.SeriesInstanceUID);
            GenerateUidTag(dicom, DicomTag.SOPInstanceUID);
            _pgDicomInfo.DataSet = dicom;
            return saved;
         }
         finally
         {
            ClearTag ( dicom, DicomTag.FileMetaInformationVersion) ;
            ClearTag ( dicom, DicomTag.MediaStorageSOPClassUID) ;
            ClearTag ( dicom, DicomTag.MediaStorageSOPInstanceUID) ;
            ClearTag ( dicom, DicomTag.ImplementationClassUID) ;
            ClearTag ( dicom, DicomTag.ImplementationVersionName) ;
         }
      }

      private void ClearTag(DicomDataSet dicom, long tag)
      {
         DicomElement dElement = dicom.FindFirstElement(null, tag, true);
         if (dElement != null)
            dicom.DeleteElement(dElement);
      }

      void SetIncapsualtedDoc(DicomDataSet ds, string sFileDocumentIn)
      {
         DicomElement dElement;
         string strDocumentTitle = "", strBurnedInAnnotation = "", strVerificationFlag = "", strInstanceNumber = "",
                strCodeSchemeDesignator = "", strCodeValue = "", strCodeMeaning = "";
         DicomTimeValue contentTime = new DicomTimeValue();
         DicomDateValue contentDate = new DicomDateValue();
         DicomDateTimeValue acquistationTime = new DicomDateTimeValue();

         dElement = ds.FindFirstElement(null, DicomTag.InstanceNumber, true);
         if (dElement != null && dElement.Length != 0)
            strInstanceNumber = ds.GetValue<string>(dElement, "");

         dElement = ds.FindFirstElement(null, DicomTag.AcquisitionDateTime, true);
         if (dElement != null && dElement.Length != 0)
            acquistationTime = ds.GetDateTimeValue(dElement, 0, 1)[0];

         dElement = ds.FindFirstElement(null, DicomTag.DocumentTitle, true);
         if (dElement != null && dElement.Length != 0)
            strDocumentTitle = ds.GetStringValue(dElement, 0);

         dElement = ds.FindFirstElement(null, DicomTag.ContentTime, true);
         if (dElement != null && dElement.Length != 0)
            contentTime = ds.GetTimeValue(dElement, 0, 1)[0];

         dElement = ds.FindFirstElement(null, DicomTag.ContentDate, true);
         if (dElement != null && dElement.Length != 0)
            contentDate = ds.GetDateValue(dElement, 0, 1)[0];

         dElement = ds.FindFirstElement(null, DicomTag.BurnedInAnnotation, true);
         if (dElement != null && dElement.Length != 0)
            strBurnedInAnnotation = ds.GetStringValue(dElement, 0);

         dElement = ds.FindFirstElement(null, DicomTag.VerificationFlag, true);
         if (dElement != null && dElement.Length != 0)
            strVerificationFlag = ds.GetStringValue(dElement, 0);

         DicomElement dElementCNS = ds.FindFirstElement(null, DicomTag.ConceptNameCodeSequence, true);
         if (dElementCNS != null && dElementCNS.Length != 0)
            strCodeMeaning = ds.GetStringValue(dElement, 0);

         dElement = ds.FindFirstElement(dElementCNS, DicomTag.CodeMeaning, false);
         if (dElement != null && dElement.Length != 0)
            strCodeMeaning = ds.GetStringValue(dElement, 0);

         dElement = ds.FindFirstElement(dElementCNS, DicomTag.CodeValue, false);
         if (dElement != null && dElement.Length != 0)
            strCodeValue = ds.GetValue<string>(dElement, "");

         dElement = ds.FindFirstElement(dElementCNS, DicomTag.CodingSchemeDesignator, false);
         if (dElement != null && dElement.Length != 0)
            strCodeSchemeDesignator = ds.GetStringValue(dElement, 0);

         dElement = ds.FindFirstElement(null, DicomTag.EncapsulatedDocument, true);
         if (dElement == null)
            dElement = ds.InsertElement(null, false, DicomTag.EncapsulatedDocument, DicomVRType.UN, false, 0);

         bool child = false;
         DicomEncapsulatedDocument encapsulatedDocument = new DicomEncapsulatedDocument();
         encapsulatedDocument.Type = DicomEncapsulatedDocumentType.Pdf;
         encapsulatedDocument.InstanceNumber = int.Parse(strInstanceNumber);
         encapsulatedDocument.ContentDate = contentDate;

         encapsulatedDocument.ContentTime = contentTime;

         encapsulatedDocument.AcquisitionDateTime = acquistationTime;

         encapsulatedDocument.BurnedInAnnotation = strBurnedInAnnotation;
         encapsulatedDocument.DocumentTitle = strDocumentTitle;
         encapsulatedDocument.VerificationFlag = strVerificationFlag;
         encapsulatedDocument.HL7InstanceIdentifier = string.Empty;


         string[] sListOfMimeTypes = new string[] { "image/jpeg", "application/pdf" };
         encapsulatedDocument.SetListOfMimeTypes(sListOfMimeTypes);

         DicomCodeSequenceItem conceptNameCodeSequence = new DicomCodeSequenceItem();
         conceptNameCodeSequence.CodingSchemeDesignator = strCodeSchemeDesignator;
         conceptNameCodeSequence.CodeValue = strCodeValue;
         conceptNameCodeSequence.CodeMeaning = strCodeMeaning;

         ds.SetEncapsulatedDocument(dElement, child, sFileDocumentIn, encapsulatedDocument, conceptNameCodeSequence);
      }

      private void ResetModule(DicomModuleType moduleType, DicomDataSet dataset, bool bKeepOriginalElements)
      {
         if (bKeepOriginalElements)
         {
            DicomModule module = dataset.FindModule(moduleType);
            if (module == null)
               return;

            byte[] b = new byte[1]{0};
            foreach (DicomElement item in module.Elements)
            {
               if (item.Length == 0)
                  continue;

               DicomElement element = dataset.FindFirstElement(null, item.Tag, true);
               if (element != null)
               {
                  dataset.SetBinaryValue(element, b, 0);
               }
            }
         }
         else
         {
            dataset.DeleteModule(moduleType);
            dataset.InsertModule(moduleType, false);
         }
      }

      private void InsertPatientInfo(DicomDataSet ds, Patient patient)
      {
         DicomElement dElement;
         if (patient.Name != null)
         {
            dElement = ds.FindFirstElement(null, DicomTag.PatientName, true);
            if (dElement == null)
               dElement = ds.InsertElement(null, false, DicomTag.PatientName, DicomVRType.UN, false, 0);
            ds.SetValue(dElement, patient.Name.FullDicomEncoded);
         }

         if (patient.Id != null)
         {
            dElement = ds.FindFirstElement(null, DicomTag.PatientID, true);
            if (dElement == null)
               dElement = ds.InsertElement(null, false, DicomTag.PatientID, DicomVRType.UN, false, 0);
            ds.SetValue(dElement, patient.Id);
         }

         if (patient.Sex != null)
         {
            dElement = ds.FindFirstElement(null, DicomTag.PatientSex, true);
            if (dElement == null)
               dElement = ds.InsertElement(null, false, DicomTag.PatientSex, DicomVRType.UN, false, 0);
            ds.SetValue(dElement, patient.Sex);
         }

         if (patient.BirthDate != null)
         {
            dElement = ds.FindFirstElement(null, DicomTag.PatientBirthDate, true);
            if (dElement == null)
               dElement = ds.InsertElement(null, false, DicomTag.PatientBirthDate, DicomVRType.UN, false, 0);
            ds.SetDateValue(dElement, new DateTime[] { (DateTime)patient.BirthDate });
         }
      }

      private void InsertStudyInfo(DicomDataSet ds, Study study)
      {
         DicomElement dElement;
         if (study.Id != null)
         {
            dElement = ds.FindFirstElement(null, DicomTag.StudyID, true);
            if (dElement == null)
               dElement = ds.InsertElement(null, false, DicomTag.StudyID, DicomVRType.UN, false, 0);
            ds.SetValue(dElement, study.Id);
         }

         if (study.AccessionNumber != null)
         {
            dElement = ds.FindFirstElement(null, DicomTag.AccessionNumber, true);
            if (dElement == null)
               dElement = ds.InsertElement(null, false, DicomTag.AccessionNumber, DicomVRType.UN, false, 0);
            ds.SetValue(dElement, study.AccessionNumber);
         }

         if (study.ReferringPhysiciansName != null)
         {
            dElement = ds.FindFirstElement(null, DicomTag.ReferringPhysicianName, true);
            if (dElement == null)
               dElement = ds.InsertElement(null, false, DicomTag.ReferringPhysicianName, DicomVRType.UN, false, 0);
            ds.SetValue(dElement, study.ReferringPhysiciansName.FullDicomEncoded);
         }

         if (study.Date != null)
         {
            dElement = ds.FindFirstElement(null, DicomTag.StudyDate, true);
            if (dElement == null)
               dElement = ds.InsertElement(null, false, DicomTag.StudyDate, DicomVRType.UN, false, 0);
            ds.SetDateValue(dElement, new DateTime[] { (DateTime)study.Date });
         }

         if (study.Description != null)
         {
            dElement = ds.FindFirstElement(null, DicomTag.StudyDescription, true);
            if (dElement == null)
               dElement = ds.InsertElement(null, false, DicomTag.StudyDescription, DicomVRType.UN, false, 0);
            ds.SetValue(dElement, study.Description);
         }

         if (study.Time != null)
         {
            dElement = ds.FindFirstElement(null, DicomTag.StudyTime, true);
            if (dElement == null)
               dElement = ds.InsertElement(null, false, DicomTag.StudyTime, DicomVRType.UN, false, 0);
            ds.SetTimeValue(dElement, new DateTime[] { (DateTime)study.Time });
         }

         if (study.InstanceUID != null)
         {
            dElement = ds.FindFirstElement(null, DicomTag.StudyInstanceUID, true);
            if (dElement == null)
               dElement = ds.InsertElement(null, false, DicomTag.StudyInstanceUID, DicomVRType.UN, false, 0);
            ds.SetValue(dElement, study.InstanceUID);
         }
      }

      private string DoSave(DicomDataSet dicom, ref List<string> lstSaved, string strSaveLocation, ref bool bSuccess)
      {
         string strMessage = "";
         if (strMessage == "")
            try
            {
               lstSaved = SaveDicom(dicom, strSaveLocation);
               strMessage = "DICOM file was saved successfully\n";
               bSuccess = lstSaved.Count > 0;
               if (lstSaved.Count > 0)
               {
                  foreach (string str in lstSaved)
                  {
                     strMessage += "--> " + str + "\n";
                  }
               }
            }
            catch (Exception ex)
            {
               strMessage = "DICOM file was not saved successfully, Reason:\n" + ex.Message;
            }
         return strMessage;
      }

      private void GetRequiredTags(DicomDataSet dicom, List<string> lstRequired)
      {
         DicomIod iod;
         DicomIodTable iodTable = DicomIodTable.Instance;
         DicomEditableObject editable = (DicomEditableObject)_pgDicomInfo.SelectedObject;
         DicomModule module;
         DicomIod IODClass = DicomIodTable.Instance.FindClass(dicom.InformationClass);
         for (int i = 0; i < dicom.ModuleCount; i++)
         {
            module = dicom.FindModuleByIndex(i);
            for (int j = 0; j < module.Elements.Length; j++)
            {
               DicomElement dElement = module.Elements[j];
               if (dElement.Length > 0)
                  continue;

               iod = DicomIodTable.Instance.Find(IODClass, dElement.Tag, DicomIodType.Element, false);
               if (!((iod != null) && (iod.Usage == DicomIodUsageType.Type1MandatoryElement) && (dElement.Length == 0) && (dElement.Length != ELEMENT_LENGTH_MAX)))
                  continue;

               if (!lstRequired.Contains(iod.Name))
                  lstRequired.Add(iod.Name);

            }
         }
      }

      private void GenerateUidTag(DicomDataSet dicom, long UidTag)
      {
         DicomElement element;
         element = dicom.FindFirstElement(null, UidTag, true);
         if (element != null)
            dicom.SetValue(element, Utils.GenerateDicomUniqueIdentifier());

         _pgDicomInfo.DataSet = dicom;
      }

      #endregion

      #region FindQuery

      private DicomScp GetQueryServer()
      {
         DicomScp server;
         server = new DicomScp();
         MyServer s = null;

         if (_tbDicomInfo.SelectedTab == _pageSCPQuery)
            s = (MyServer)(_cbSCPServers.SelectedItem);
         else
            s = (MyServer)(_cbMWLServers.SelectedItem);

         server.AETitle = s._sAE;
         server.PeerAddress = IPAddress.Parse(s._sIP);
         server.Port = s._port;
         server.Timeout = s._timeout;
         return server;
      }

      private DicomDataSet LoadDatasetResource(string name, out IntPtr handle)
      {
         DicomDataSet ds = new DicomDataSet();
         Assembly assembly = Assembly.GetExecutingAssembly();
         string[] resourceNames = assembly.GetManifestResourceNames();

         handle = IntPtr.Zero;
         foreach (string n in resourceNames)
         {
            if (n.ToLower().Contains(name.ToLower()))
            {
               Stream stream = assembly.GetManifestResourceStream(n);
               byte[] data = new byte[stream.Length];
               handle = Marshal.AllocHGlobal(Convert.ToInt32(stream.Length));

               stream.Read(data, 0, Convert.ToInt32(stream.Length));
               Marshal.Copy(data, 0, handle, Convert.ToInt32(stream.Length));
               ds.Load(handle, stream.Length, DicomDataSetFlags.None);
               continue;
            }
         }

         return ds;
      }

      private bool DoSearch()
      {
         bool bRet = false;
         ModalityWorklistQuery query = GetQueryParams();
         DicomScp server = GetQueryServer();

         MyServer s = null;
         if (_tbDicomInfo.SelectedTab == _pageSCPQuery)
            s = (MyServer)(_cbSCPServers.SelectedItem);
         else
            s = (MyServer)(_cbMWLServers.SelectedItem);

         bool bSCPQueryEmpty;
         bool bSWLQueryEmpty;
         bool bPWLQueryEmpty;
         IsQueryEmpty(out bSCPQueryEmpty, out bSWLQueryEmpty, out bPWLQueryEmpty);

         if ((bSCPQueryEmpty && _tbDicomInfo.SelectedTab == _pageSCPQuery) ||
             (bPWLQueryEmpty && _tbDicomInfo.SelectedTab == _pageMWLQuery && _toolBtnPatient.Checked) ||
             (bSWLQueryEmpty && _tbDicomInfo.SelectedTab == _pageMWLQuery && !_toolBtnPatient.Checked)
             )
         {
            bool bTopMost = logWindow.TopMost;
            logWindow.TopMost = false;
            DialogResult dlgRes = MessageBox.Show(this, "The query parameters are empty the query will take long time.\nAre you sure you want to continue?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            logWindow.TopMost = bTopMost;
            if (dlgRes == DialogResult.No)
            {
               return false;
            }
         }
         EnableItems(false, "Query PACS Please Wait...", "");
         CreateCFindObject(s);
         _find.MatchStudy += new MatchStudyDelegate(_find_MatchPatient);

         _find.AETitle = _mySettings._settings.clientAE;
         _find.HostPort = _mySettings._settings.clientPort;
         bool bScp = _tbDicomInfo.SelectedTab == _pageSCPQuery;

         if (bScp)
         {
            _btnTransferSCPPatient.Enabled = _btnTransferSCPStudies.Enabled = false;
            _lstSCPPatient.Items.Clear();
            _lstSCPStudies.Items.Clear();
         }
         else
         {
            _lstMWLItems.Items.Clear();
            _btnTransferMWL.Enabled = false;
         }
         Thread t = new Thread(delegate()
         {
            IntPtr handle = IntPtr.Zero;
            try
            {
               if (bScp)
               {
                  FindQuery fQuery = _findQuery;
                  fQuery.Modalities.Clear();
                  if (_findQuery.Modalities == "All")
                  {
                     fQuery.Modalities.Add("");
                  }
                  else
                  {
                     if (_findQuery.Modalities.Contains(","))
                     {
                        string[] arrValue = _findQuery.Modalities.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                        fQuery.Modalities.AddRange(arrValue);
                     }
                     else
                        fQuery.Modalities.Add(_findQuery.Modalities);
                  }

                  using (DicomDataSet template = LoadDatasetResource("StudyRoot_Study_Level_IHE_C-Find.dcm", out handle))
                  {
                     _find.Find(server, fQuery, false, template);
                     if (handle != IntPtr.Zero)
                        Marshal.FreeHGlobal(handle);
                  }
               }
               else
               {
                  using (DicomDataSet template = LoadDatasetResource("MwlIheCFindScu.dcm", out handle))
                  {
                     _find.Find<ModalityWorklistQuery, ModalityWorklistResult>(server, query,
                                                                             new DicomMatchDelegate<ModalityWorklistResult>(FoundMatch));
                     if (handle != IntPtr.Zero)
                        Marshal.FreeHGlobal(handle);
                  }
               }
            }
            catch (Exception ex)
            {
               LogError(ex.Message);
               ShowErrorMessage(ex);
               bRet = false;
            }

         });
         t.Start();
         while (t.IsAlive)
         {
            Application.DoEvents();
         }
         bRet = true;
         return bRet;
      }

      private void IsQueryEmpty(out bool bSCPQueryEmpty, out bool bSWLQueryEmpty, out bool bPWLQueryEmpty)
      {
         DicomFindQuery newFindQ = new DicomFindQuery();
         bSCPQueryEmpty = (_findQuery.InstanceNumber == newFindQ.InstanceNumber) &
             (_findQuery.Modalities == newFindQ.Modalities) &
             (_findQuery.Modality == newFindQ.Modality) &
             (_findQuery.PatientId == newFindQ.PatientId) &
             (_findQuery.PatientName == newFindQ.PatientName) &
             (_findQuery.PerfProcStepStartDate == newFindQ.PerfProcStepStartDate) &
             (_findQuery.PerfProcStepStartTime.ToString() == newFindQ.PerfProcStepStartTime.ToString()) &
             (_findQuery.AccessionNumber == newFindQ.AccessionNumber) &
             (_findQuery.QueryLevel == newFindQ.QueryLevel) &
             (_findQuery.ReferringPhysiciansName == newFindQ.ReferringPhysiciansName) &
             (_findQuery.RequestedProcId == newFindQ.RequestedProcId) &
             (_findQuery.SchedProcStepId == newFindQ.SchedProcStepId) &
             (_findQuery.SeriesInstanceUID == newFindQ.SeriesInstanceUID) &
             (_findQuery.SeriesNumber == newFindQ.SeriesNumber) &
             (_findQuery.SOPInstanceUID == newFindQ.SOPInstanceUID) &
             (_findQuery.StudyDate.ToString() == newFindQ.StudyDate.ToString()) &
             (_findQuery.StudyId == newFindQ.StudyId) &
             (_findQuery.StudyInstanceUID == newFindQ.StudyInstanceUID) &
             (_findQuery.StudyTime.ToString() == newFindQ.StudyTime.ToString());
         BroadBasedQuery newBroadQuery = new BroadBasedQuery();
         bSWLQueryEmpty = (_bbQuery.Modality == newBroadQuery.Modality) &
             (_bbQuery.ScheduledProcedureStepStartDate == newBroadQuery.ScheduledProcedureStepStartDate) &
             (_bbQuery.ScheduledStationAeTitle == newBroadQuery.ScheduledStationAeTitle);

         PatientBasedQuery newPatientQuery = new PatientBasedQuery();
         bPWLQueryEmpty = (_pbQuery.PatientId == newPatientQuery.PatientId) &
             (_pbQuery.PatientName.ToString() == newPatientQuery.PatientName.ToString()) &
             (_pbQuery.AccessionNumber == newPatientQuery.AccessionNumber) &
             (_pbQuery.RequestedProcedureId == newPatientQuery.RequestedProcedureId);
      }

      public delegate void CreateCFind(MyServer server);
      void CreateCFindObject(MyServer server)
      {
         if (this.InvokeRequired)
         {
            Invoke(new CreateCFind(CreateCFindObject), new object[] { server });
         }
         else
         {
            if (_find != null)
            {
               _find.Dispose();
            }
            if (server._useTls)
            {
#if !LEADTOOLS_V20_OR_LATER
               _find = new MyQueryRetrieveScu(this, _mySettings._settings.TempDir, DicomNetSecurityeMode.Tls, null);
#else
               _find = new MyQueryRetrieveScu(this, _mySettings._settings.TempDir, DicomNetSecurityMode.Tls, null);
#endif // #if !LEADTOOLS_V20_OR_LATER
            }
            else
            {
               _find = new MyQueryRetrieveScu(this);
            }

            _find.ImplementationClass = _sConfigurationImplementationClass;
            _find.ProtocolVersion = _sConfigurationProtocolversion;
            _find.ImplementationVersionName = _sConfigurationImplementationVersionName;
            _find.AETitle = _mySettings._settings.clientAE;
            _find.HostPort = 1000;

            _find.BeforeConnect += new Leadtools.Dicom.Scu.Common.BeforeConnectDelegate(_find_BeforeConnect);
            _find.AfterConnect += new Leadtools.Dicom.Scu.Common.AfterConnectDelegate(_find_AfterConnect);
            _find.AfterSecureLinkReady += new AfterSecureLinkReadyDelegate(_find_AfterSecureLinkReady);
            _find.BeforeAssociateRequest += new Leadtools.Dicom.Scu.Common.BeforeAssociationRequestDelegate(_find_BeforeAssociateRequest);
            _find.AfterAssociateRequest += new Leadtools.Dicom.Scu.Common.AfterAssociateRequestDelegate(_find_AfterAssociateRequest);
            _find.BeforeCFind += new Leadtools.Dicom.Scu.Common.BeforeCFindDelegate(_find_BeforeCFind);
            _find.AfterCFind += new Leadtools.Dicom.Scu.Common.AfterCFindDelegate(_find_AfterCFind);

            _find.BeforeCMove += new BeforeCMoveDelegate(_find_BeforeCMove);
            _find.AfterCMove += new AfterCMoveDelegate(_find_AfterCMove);

            _find.PrivateKeyPassword += new PrivateKeyPasswordDelegate(_find_PrivateKeyPassword);

            if (server._useTls)
            {
               try
               {
                  _find.SetTlsCipherSuiteByIndex(0, DicomTlsCipherSuiteType.DheRsaWith3DesEdeCbcSha);
                  _find.SetTlsClientCertificate(
                     _mySettings._settings.clientCertificate,
                     DicomTlsCertificateType.Pem,
                     _mySettings._settings.privateKey.Length > 0 ? _mySettings._settings.privateKey : null);
               }
               catch (Exception ex)
               {
                  LogError(ex.Message);
               }
               _find._mainForm = this;
            }

            if (_mySettings._settings.logLowLevel)
            {
               if (_tracer == null)
               {
                  _tracer = new TextBoxTraceListener(logWindow.RichTextBox);
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
         }
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

         //EnableCancel(true);
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
         LogText("After CFind", message + _sNewlineTab + "****************************" + _sNewlineTab);
         //EnableCancel(false);
      }

      void _find_MatchStudy(object sender, Leadtools.Dicom.Scu.Common.MatchEventArgs<Study> e)
      {
         string message =
            _sNewlineTab + "QueryLevel: " + e.QueryLevel.ToString() +
            _sNewlineTab + "Availability:\t" + e.Availability.ToString() +
            _sNewlineTab + "Patient:\t" + e.Info.Patient.ToString() +
            _sNewlineTab + "RetrieveAETitle:\t" + e.RetrieveAETitle.ToString();
         LogText("Study Patient Found Found", message);
         try
         {
            AddStudyItem(e);
         }
         catch { }
      }

      void _find_MatchPatient(object sender, Leadtools.Dicom.Scu.Common.MatchEventArgs<Study> e)
      {
         string message =
            _sNewlineTab + "QueryLevel: " + e.QueryLevel.ToString() +
            _sNewlineTab + "Availability:\t" + e.Availability.ToString() +
            _sNewlineTab + "Patient:\t" + e.Info.Patient.ToString() +
            _sNewlineTab + "RetrieveAETitle:\t" + e.RetrieveAETitle.ToString();
         LogText("Study Patient Found Found", message);
         try
         {
            AddPatientItem(e);
         }
         catch { }
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

            item = _lstSCPStudies.Items.Add(e.Info.Id);
            if (e.Info.ReferringPhysiciansName != null)
               item.SubItems.Add(e.Info.ReferringPhysiciansName.FullDicomEncoded);
            else
               item.SubItems.Add("");
            item.SubItems.Add(e.Info.AccessionNumber);
            item.SubItems.Add(e.Info.Date.HasValue ? e.Info.Date.ToString() : string.Empty);
            item.SubItems.Add(e.Info.Time.HasValue ? e.Info.Time.ToString() : string.Empty);

            item.Tag = e.Info;
         }
      }

      public delegate void AddPatientItemDelegate(MatchEventArgs<Study> ds);
      private void AddPatientItem(MatchEventArgs<Study> e)
      {
         ListViewItem item = null;

         if (InvokeRequired)
         {
            Invoke(new AddStudyItemDelegate(AddPatientItem), e);
         }
         else
         {
            if (e.Info.Patient == null)
               return;

            // Check if the Patient already exist in _lstSCPPatient
            foreach (ListViewItem lvi in _lstSCPPatient.Items)
            {
               if (lvi.SubItems[0].Text == e.Info.Patient.Name.FullDicomEncoded || lvi.SubItems[1].Text == e.Info.Patient.Id)
               {
                  item = lvi;
                  break;
               }
            }

            if (item == null)
            {
               item = _lstSCPPatient.Items.Add(e.Info.Patient.Name.FullDicomEncoded);
               item.SubItems.Add(e.Info.Patient.Id);
               item.SubItems.Add(e.Info.Patient.Sex);
               item.SubItems.Add(e.Info.Patient.BirthDate.HasValue ? e.Info.Patient.BirthDate.ToString() : string.Empty);
               item.Tag = new List<Study>();
            }

            (item.Tag as List<Study>).Add(e.Info);
         }
      }

      void _find_BeforeCMove(object sender, BeforeCMoveEventArgs e)
      {
         string message =
            _sNewlineTab + "Priority:\t" + e.Priority + e.Scp.ToString() +
            _sNewlineTab + "Desination AE:\t" + e.DestinationAETitle;
         LogText("Before CMove", message);
         //EnableCancel(true);
         //         _moveCount = 0;
      }

      void _find_AfterCMove(object sender, AfterCMoveEventArgs e)
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
            message = _sNewlineTab + " CMove failed\r\n\tStatus: " + e.Status.ToString();
         }
         LogText("After CMove", message);
         //if (e.Status != DicomCommandStatusType.Pending)
         //EnableCancel(false);
      }

      void _find_AfterSecureLinkReady(object sender, AfterSecureLinkReadyEventArgs e)
      {
         string message;
         if (e.Error == DicomExceptionCode.Success)
         {
            message = _sNewlineTab + "Secure Link Ready";
         }
         else
         {
            message =
               _sNewlineTab + "Secure Link Failed" +
               _sNewlineTab + "Error:\t" + e.Error.ToString();
         }

         LogText("After Secure Link Ready", message);
      }

      void _find_PrivateKeyPassword(object sender, PrivateKeyPasswordEventArgs e)
      {
         e.PrivateKeyPassword = _mySettings._settings.privateKeyPassword;
      }

      private ModalityWorklistQuery GetQueryParams()
      {
         ModalityWorklistQuery query = new ModalityWorklistQuery();

         if (_tbDicomInfo.SelectedTab == _pageMWLQuery && _toolBtnPatient.Checked)
         {
            query.PatientName = _pbQuery.PatientName;
            query.PatientId = _pbQuery.PatientId;
            query.RequestedProcedureId = _pbQuery.RequestedProcedureId;
            query.AccessionNumber = _pbQuery.AccessionNumber;
         }
         else
         {
            BroadQuery bq = new BroadQuery();

#if LTV18_CONFIG
            bq.ScheduledProcedureStepStartDate = _bbQuery.ScheduledProcedureStepStartDate.StartDate;
#else
            bq.ScheduledProcedureStepStartDate = _bbQuery.ScheduledProcedureStepStartDate;
#endif

            bq.Modality = _bbQuery.Modality;
            bq.ScheduledStationAeTitle = _bbQuery.ScheduledStationAeTitle;
            query.Broad.Add(bq);
         }
         return query;
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
            item = _lstMWLItems.Items.Add(result.AccessionNumber);
            item.SubItems.Add(result.PatientId);
            item.SubItems.Add(result.PatientName.FullDicomEncoded);
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
            item.SubItems.Add(result.RequestedProcedureId);

            item.Tag = result;
         }
      }

      private void FoundMatch(ModalityWorklistResult result, DicomDataSet ds)
      {
         string message =
             _sNewlineTab + "Accession #:\t\t " + result.AccessionNumber +
             _sNewlineTab + "Patient Name:\t\t" + result.PatientName.FullDicomEncoded +
             _sNewlineTab + "Scheduled Start Date:\t" + result.ScheduledProcedureStepSequence[0].ScheduledProcedureStepStartDate.Value.ToShortDateString();
         LogText("Worklist Item Found", message);

         if (ds != null)
         {
            DicomDataSet data = new DicomDataSet();

            data.Copy(ds, null, null);
            result.Tag = data;
         }
         AddResultItem(result);
      }

      #endregion

      #region StoreScu

      private void DoStore(string dsFile, MyServer storeserver)
      {
         string sMsg = string.Empty;
         DicomScp server = new DicomScp();
         server.AETitle = storeserver._sAE;
         server.PeerAddress = IPAddress.Parse(storeserver._sIP);
         server.Port = storeserver._port;
         server.Timeout = storeserver._timeout;
         MyServer s = null;
         s = (MyServer)(_cbStoreServers.SelectedItem);
         bStored = false;

         CreateCStoreObject(s);
         _cstore.AETitle = _mySettings._settings.clientAE;
         _cstore.HostPort = _mySettings._settings.clientPort;

         Thread t = new Thread(delegate()
         {
            try
            {
               _cstore.Store(server, dsFile);
            }
            catch (Exception ex)
            {
               LogError(ex.Message);
               ShowErrorMessage(ex);
            }
         });

         t.Start();
         while (t.IsAlive)
         {
            Application.DoEvents();
         }
      }

      public delegate void ShowErrorMessageDelegate(Exception ex);
      private void ShowErrorMessage(Exception ex)
      {
         if (InvokeRequired)
         {
            Invoke(new ShowErrorMessageDelegate(ShowErrorMessage), ex);
         }
         else
         {
            EnableItems(true, "", "");
            bool bTopMost = logWindow.TopMost;
            logWindow.TopMost = false;
            MessageBox.Show(this, "Error Occurred: \n" + ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            logWindow.TopMost = bTopMost;
         }

      }

      void _cstore_BeforeConnect(object sender, Leadtools.Dicom.Scu.Common.BeforeConnectEventArgs e)
      {
         LogText("Before Connect", e.Scp.ToString());
         e.PrivateKeyPassword = _mySettings._settings.privateKeyPassword;
      }

      void _cstore_AfterConnect(object sender, Leadtools.Dicom.Scu.Common.AfterConnectEventArgs e)
      {
         string message;
         if (e.Error == DicomExceptionCode.Success)
         {
            message = _sNewlineTab + "Connection Successful";
         }
         else
         {
            message =
               _sNewlineTab + "Connection Failed" +
               _sNewlineTab + "Error:\t" + e.Error.ToString();
         }

         LogText("After Connect", message);
      }

      void _cstore_AfterSecureLinkReady(object sender, Leadtools.Dicom.Scu.Common.AfterSecureLinkReadyEventArgs e)
      {
         string message;
         if (e.Error == DicomExceptionCode.Success)
         {
            message = _sNewlineTab + "Secure Link Ready";
         }
         else
         {
            message =
               _sNewlineTab + "Secure Link Failed" +
               _sNewlineTab + "Error:\t" + e.Error.ToString();
         }

         LogText("After Secure Link Ready", message);
      }

      void _cstore_BeforeAssociateRequest(object sender, Leadtools.Dicom.Scu.Common.BeforeAssociateRequestEventArgs e)
      {
         LogText("Before Associate Request", e.Associate.ToString());
      }

      void _cstore_AfterAssociateRequest(object sender, Leadtools.Dicom.Scu.Common.AfterAssociateRequestEventArgs e)
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
            message = _sNewlineTab + "Association Accepted" + e.Associate.ToString();
         }
         LogText("After Associate Request", message);
      }

      void _cstore_BeforeCStore(object sender, Leadtools.Dicom.Scu.Common.BeforeCStoreEventArgs e)
      {
         LogText("Before CStore", _sNewlineTab + "Current DataSet");
      }

      void _cstore_AfterCStore(object sender, Leadtools.Dicom.Scu.Common.AfterCStoreEventArgs e)
      {
         string message;
         if (e.Status == DicomCommandStatusType.Success)
         {
            message =
               _sNewlineTab + "Success" +
               _sNewlineTab + "Current DataSet";
            bStored = true;
         }
         else
         {
            message =
               _sNewlineTab + "CStore Failed" +
               _sNewlineTab + "Status: " + e.Status.ToString();
         }
         LogText("After CStore", message);
      }

      void CreateCStoreObject(MyServer server)
      {
         if (_cstore != null)
         {
            _cstore.Dispose();
         }

         if (server._useTls)
         {
#if !LEADTOOLS_V20_OR_LATER
            _cstore = new StoreScu(string.Empty, DicomNetSecurityeMode.Tls, null);
#else
            _cstore = new StoreScu(string.Empty, DicomNetSecurityMode.Tls, null);
#endif // #if !LEADTOOLS_V20_OR_LATER
         }
         else
         {
            _cstore = new StoreScu();
         }

         _cstore.ImplementationClass = _sConfigurationImplementationClass;
         _cstore.ImplementationVersionName = _sConfigurationImplementationVersionName;
         _cstore.ProtocolVersion = _sConfigurationProtocolversion;

         // Subscribe to events for logging
         _cstore.BeforeConnect += new Leadtools.Dicom.Scu.Common.BeforeConnectDelegate(_cstore_BeforeConnect);
         _cstore.AfterConnect += new Leadtools.Dicom.Scu.Common.AfterConnectDelegate(_cstore_AfterConnect);
         _cstore.AfterSecureLinkReady += new Leadtools.Dicom.Scu.Common.AfterSecureLinkReadyDelegate(_cstore_AfterSecureLinkReady);
         _cstore.BeforeAssociateRequest += new Leadtools.Dicom.Scu.Common.BeforeAssociationRequestDelegate(_cstore_BeforeAssociateRequest);
         _cstore.AfterAssociateRequest += new Leadtools.Dicom.Scu.Common.AfterAssociateRequestDelegate(_cstore_AfterAssociateRequest);
         _cstore.BeforeCStore += new Leadtools.Dicom.Scu.Common.BeforeCStoreDelegate(_cstore_BeforeCStore);
         _cstore.AfterCStore += new Leadtools.Dicom.Scu.Common.AfterCStoreDelegate(_cstore_AfterCStore);

         _cstore.PrivateKeyPassword += new PrivateKeyPasswordDelegate(_cstore_PrivateKeyPassword);
         if (server._useTls)
         {
            try
            {
               _cstore.SetTlsCipherSuiteByIndex(0, DicomTlsCipherSuiteType.DheRsaWith3DesEdeCbcSha);
               _cstore.SetTlsClientCertificate(
                  _mySettings._settings.clientCertificate,
                  DicomTlsCertificateType.Pem,
                  _mySettings._settings.privateKey.Length > 0 ? _mySettings._settings.privateKey : null);
            }
            catch (Exception ex)
            {
               LogError(ex.Message);
            }

         }

         if (_mySettings._settings.logLowLevel)
         {
            if (_tracer == null)
            {
               _tracer = new TextBoxTraceListener(logWindow.RichTextBox);
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
         _cstore.EnableDebugLog = true;
      }

      void _cstore_PrivateKeyPassword(object sender, PrivateKeyPasswordEventArgs e)
      {
         e.PrivateKeyPassword = _mySettings._settings.privateKeyPassword;
      }

      #endregion
   }

   [Serializable]
   class PrintPage : IDisposable, IPrintToPACSFile
   {
      bool bSelected = false;
      public bool Selected
      {
         get { return bSelected; }
         set { bSelected = value; }
      }

      private int _jobId;
      public int JobId
      {
         get { return _jobId; }
      }

      private string _strRecognizedFilePath = "";
      public string RecognizedFilePath
      {
         get { return _strRecognizedFilePath; }
         set { _strRecognizedFilePath = value; }
      }

      IntPtr _metaFile;
      public IntPtr MetaFile
      {
         get { return _metaFile; }
         set { _metaFile = value; }
      }

      string file = string.Empty;
      public string FilePath
      {
         get { return file; }
         set { file = value; }
      }

      public PrintPage(int jobId)
      {
         _jobId = jobId;
      }

      ~PrintPage()
      {
         //if (File.Exists(tempFile))
         //   File.Delete(tempFile);


         //if (File.Exists(RecognizedFilePath))
         //   File.Delete(RecognizedFilePath);
         //MetaFile.Dispose();
      }

      #region IDisposable Members

      public void Dispose()
      {
         try
         {
            if (File.Exists(file))
               File.Delete(file);

            if (File.Exists(RecognizedFilePath))
               File.Delete(RecognizedFilePath);
         }
         catch { }
         //MetaFile.Dispose();
      }
      #endregion

      public string FileLocation()
      {
         return file;
      }
   }

   [Serializable]
   class Page : IDisposable, IPrintToPACSFile
   {
      bool bDeleteOnDispose = false;
      public bool DeleteOnDispose
      {
         get { return bDeleteOnDispose; }
         set { bDeleteOnDispose = value; }
      }

      string file = string.Empty;
      public string FilePath
      {
         get { return file; }
         set { file = value; }
      }

      #region IDisposable Members

      public void Dispose()
      {
         try
         {
            if (bDeleteOnDispose)
               if (System.IO.File.Exists(file))
                  System.IO.File.Delete(file);
         }
         catch { }
      }

      #endregion

      public string FileLocation()
      {
         return file;
      }
   }

   interface IPrintToPACSFile
   {
      string FileLocation();
   }
}

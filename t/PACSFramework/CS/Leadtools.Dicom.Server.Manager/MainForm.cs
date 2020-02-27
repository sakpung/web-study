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
using System.IO;
using System.Management;
using System.Diagnostics;
using System.Threading;
using System.ServiceProcess;
using Leadtools.Dicom.Server.Manager.Dialogs;
using Leadtools.Dicom.AddIn.Common;
using Leadtools.Dicom.AddIn;
using Leadtools.Dicom.AddIn.Interfaces;
using Leadtools.Dicom.Server.Manager.Properties;
using Leadtools.Dicom.Server.Admin;
using System.Runtime.Remoting.Lifetime;
using System.Runtime.Remoting;
using Leadtools.Demos;
using System.Configuration;
using Leadtools.Medical.Logging.DataAccessLayer.Configuration;
using Leadtools.Medical.DataAccessLayer.Configuration;
using System.Collections;
using System.Net.NetworkInformation;
using System.Net;
using System.Net.Sockets;
using Leadtools.DicomDemos;
using Leadtools.Demos.StorageServer.DataTypes;
using System.Reflection;

namespace Leadtools.Dicom.Server.Manager
{
   public partial class MainForm : Form
   {
      private string ApplicationDirectory = string.Empty;
      private System.Threading.Timer serviceTimer = null;
      private AeInfo oldAeInfo = null;
      private ServiceAdministrator administrator = null;
      private DicomService ActiveService = null;
      private ServiceControllerStatus oldStatus = ServiceControllerStatus.Stopped;
      private EventLogDialog eventLog = null;

      private const string ConnectionName = "LeadDicomLogging";
      //private bool showHelp = false;

      public bool bShowedBadFormatException = false;

      public DicomNetIpTypeFlags _ipType = DicomNetIpTypeFlags.Ipv4OrIpv6;
      
      // Settings
      public DicomDemoSettings _mySettings = new DicomDemoSettings();
      public string _demoName = Path.GetFileName(Application.ExecutablePath);
      private bool _runningPacsConfigDemo = false;

      private void InitializeServiceAdministrator()
      {
         if (administrator != null)
         {
            administrator.Error -= new EventHandler<Leadtools.Dicom.Server.Admin.ErrorEventArgs>(administrator_Error);
            administrator.ServiceRemoved -= new EventHandler<ServiceRemovedEventArgs>(administrator_ServiceRemoved);
            administrator.ServiceAdded -= new EventHandler<ServiceAddedEventArgs>(administrator_ServiceAdded);
            administrator.Dispose();
         }


         administrator = new ServiceAdministrator(ApplicationDirectory, false);
         administrator.Error += new EventHandler<Leadtools.Dicom.Server.Admin.ErrorEventArgs>(administrator_Error);
         administrator.ServiceRemoved += new EventHandler<ServiceRemovedEventArgs>(administrator_ServiceRemoved);
         administrator.ServiceAdded += new EventHandler<ServiceAddedEventArgs>(administrator_ServiceAdded);
#if LEADTOOLS_V175_OR_LATER
         administrator.Initialize();
#else
         administrator.Unlock(Support.MedicalServerKey);
#endif
      }

      public MainForm()
      {
         InitializeComponent();
         ApplicationDirectory = Application.StartupPath + @"\";

         labelIpAddress.Text = string.Empty;
         labelPort.Text = string.Empty;
         InitializeStrings();
         Icon = Resources.ApplicationIcon;

         InitializeServiceAdministrator();

         if (System.Net.Sockets.Socket.OSSupportsIPv6 == false)
            _ipType = DicomNetIpTypeFlags.Ipv4;

         // Leadtools.Configuration.Logging.dll is shipped (and compiled) in the PACAddins Folder
         // When a service is created, it is copied to the {ServiceName}/Configuration folder
         // But it also needs to be in the root, because the demo server references it directly 
         // So copy it to the root if it is not already there
         // Note that fully qualified paths must be used so this works properly if run from a shortcut
         string pathExe = AppDomain.CurrentDomain.BaseDirectory;

         string loggingConfigurationAssemblyName = @"Leadtools.Configuration.Logging.dll";
         string loggingConfigurationAssemblyName_Path = Path.Combine(pathExe, loggingConfigurationAssemblyName);
         if (!File.Exists(loggingConfigurationAssemblyName_Path))
         {
            string shippedLoggingConfiguration = Path.Combine( @"PACSAddIns", loggingConfigurationAssemblyName);
            string shippedLoggingConfiguration_Path = Path.Combine(pathExe, shippedLoggingConfiguration);
            if (File.Exists(shippedLoggingConfiguration_Path))
            {
               File.Copy(shippedLoggingConfiguration_Path, loggingConfigurationAssemblyName_Path);
               // Load the assembly -- For 64-bit version, assembly is not found after copy
               Assembly.Load(string.Format("{0}, Version=1.0.0.0, Culture=neutral", Path.GetFileNameWithoutExtension(loggingConfigurationAssemblyName)));
            }
         }
         eventLog = new EventLogDialog(null);
      }

      void administrator_ServiceAdded(object sender, ServiceAddedEventArgs e)
      {
         if (_runningPacsConfigDemo)
            return;
         AsyncHelper.SynchronizedInvoke(this, delegate() { AddService(e.Service, true); });
      }

      void administrator_ServiceRemoved(object sender, ServiceRemovedEventArgs e)
      {
         if (_runningPacsConfigDemo)
            return;

         ComboItemImage removedItem = null;

         foreach (ComboItemImage item in comboBoxService.Items)
         {
            DicomService service = item.Item as DicomService;

            if (service.Settings.AETitle == e.AETitle)
            {               
               removedItem = item;
               break;
            }
         }

         AsyncHelper.SynchronizedInvoke(this, delegate()
         {
            if (removedItem != null)
            {
               if (comboBoxService.SelectedItem == removedItem)
               {
                  listViewOptions.Items.Clear();
               }

               comboBoxService.Items.Remove(removedItem);
               labelIpAddress.Text = string.Empty;
               labelPort.Text = string.Empty;

               if (comboBoxService.Items.Count > 0)
               {
                  comboBoxService.SelectedIndex = 0;
               }

               comboBoxService.Enabled = comboBoxService.Items.Count > 1;
               listViewAeTitles.Items.Clear();
               listViewClients.Items.Clear();
               (removedItem.Item as DicomService).Dispose();
               if (comboBoxService.SelectedIndex == -1)
               {
                  ActiveService = null;
               }
            }
         });
      }

      void administrator_Error(object sender, Leadtools.Dicom.Server.Admin.ErrorEventArgs e)
      {
         if ((e.Error is BadImageFormatException) && (!bShowedBadFormatException))
         {
            bShowedBadFormatException = true;
            string msg =
             "Error loading [{0}].\n\n" +
             "This {1}-bit LEADTOOLS DICOM Server Manager process cannot load {2}-bit AddIn dlls, so the AddIn options can not be displayed.  " +
             "Please use the {3}-bit version of LEADTOOLS DICOM Server Manager to view the AddIn options.\n\n" +
             "Note:\n" +
             "If you prefer to use the {4}-bit dlls instead of the {5}-bit dlls:\n" +
             "* Delete any existing {6}-bit DICOM services using the LEADTOOLS DICOM Server manager\n" +
             "* Start the {7}-bit version of the LEADTOOLS DICOM server manager\n" +
             "* Add one or more new {8}-bit DICOM services\n" +
             "* Copy the {9}-bit AddIn dlls from the PACSAddins folder to the corresponding service AddIns folders";
            string sCurrent = "32";
            string sOther = "64";

            string message = string.Empty;

            if (Is64())
            {
               sCurrent = "32";
               sOther = "64";
            }
            else
            {
               sCurrent = "64";
               sOther = "32";
            }
            message = string.Format(msg, (e.Error as BadImageFormatException).FileName, sOther, sCurrent, sCurrent, sOther, sCurrent, sCurrent, sOther, sOther, sOther, sOther);
            MessageBox.Show(message, "Error Loading AddIn Options", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
         }
      }

      private void InitializeStrings()
      {
         Text = Resources.ApplicationTitle;
         if (!DicomDemoSettingsManager.Is64Process())
            Text = Text + " (32 bit)";
         else
            Text = Text + "(64 bit)";
         labelServerIp.Text = Resources.ServerIpLabel;
         labelServerPort.Text = Resources.ServerPortLabel;
         labelServer.Text = Resources.ServerLabel;
         tabPageAeTitles.Text = Resources.AeTitleTabLabel;
         tabPageClients.Text = Resources.ClientsTabLabel;
         columnIpAddress.Text = Resources.IPAddressColumnLabel;
         columnAeTitle.Text = Resources.AeTitleLabel;
         columnConnectTime.Text = Resources.ConnectTimeColumnLabel;
         columnLastAction.Text = Resources.LastActionColumnLabel;

         columnHeaderAeTitle.Text = Resources.AeTitleLabel;
         columnHeaderHostname.Text = Resources.HostNamePortColumnLabel;
         columnHeaderPort.Text = Resources.PortLabel;
         columnHeaderSecurePort.Text = Resources.SecurePortColumnLabel;
      }

      /// <summary>
      /// Obtains a lifetime service object to control the lifetime policy for this instance. Returning null makes this a singleton object that doesn't
      /// expire.
      /// </summary>
      /// <returns>
      /// An object of type <see cref="T:System.Runtime.Remoting.Lifetime.ILease"/> used to control the lifetime policy for this instance.
      /// This is the current lifetime service object for this instance if one exists; otherwise, a new lifetime service object initialized to 
      /// the value of the <see cref="P:System.Runtime.Remoting.Lifetime.LifetimeServices.LeaseManagerPollTime"/> property.
      /// </returns>
      /// <exception cref="T:System.Security.SecurityException">The immediate caller does not have infrastructure permission. </exception>
      /// <PermissionSet>
      /// 	<IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="RemotingConfiguration, Infrastructure"/>
      /// </PermissionSet>
      public override object InitializeLifetimeService()
      {
         return null;
      }

      private bool IsEval()
      {
         bool isEval = true;
#if LEADTOOLS_V175_OR_LATER
         isEval = (RasterSupport.KernelType == RasterKernelType.Evaluation && !RasterSupport.KernelExpired);
#else
         isEval = RasterSupport.KernelType == RasterKernelType.Nag  || (RasterSupport.KernelType == RasterKernelType.Evaluation && !RasterSupport.KernelExpired);
#endif
         if (isEval)
         {
            return true;
         }
         return false;
      }

      private string[] GetDemoServerAddins(string baseDir)
      {
         string addinsDir = baseDir + @"\PACSAddIns\";

         List<string> addins = new List<string>();
         addins.Add(addinsDir + "Leadtools.AddIn.Find.dll");
         addins.Add(addinsDir + "Leadtools.AddIn.Move.dll");
         addins.Add(addinsDir + "Leadtools.AddIn.Security.dll");
         addins.Add(addinsDir + "Leadtools.AddIn.StorageCommit.dll");
         addins.Add(addinsDir + "Leadtools.AddIn.Store.dll");

         // Note this is not in the PACSAddins folder
         addins.Add(Path.Combine(baseDir, "Leadtools.Medical.Worklist.AddIns.dll"));
         return addins.ToArray();
      }
      
      private string[] GetDemoServerConfigurationAddins(string baseDir)
      {
         string addinsDir = baseDir + @"\PACSAddIns\";
         List<string> addins = new List<string>();
         
         // Note this is not in the PACSAddins folder
         addins.Add(Path.Combine(addinsDir, "Leadtools.Configuration.Logging.dll"));
         return addins.ToArray();
      }

      static public void CopyAddIns(string[] addins, DicomService service, string addinsFolderName)
      {
         if (addins == null)
            return;

         string destDir = Path.Combine(service.ServiceDirectory, addinsFolderName);
         if (!Directory.Exists(destDir))
         {
            Directory.CreateDirectory(destDir);
         }

         foreach (string addin in addins)
         {
            FileInfo f = new FileInfo(addin);
            string newFile = Path.Combine(destDir, f.Name);

            try
            {
               File.Copy(addin, newFile, true);
            }
            catch (IOException e)
            {
               //
               // If the addin is being used by another process we will not report and
               // error.
               //
               if (!e.Message.Contains("being used by another process"))
               {
                  throw e;
               }
            }
         }
      }

      private void buttonServiceAdd_Click(object sender, EventArgs e)
      {
         EditServiceDialog dialog = new EditServiceDialog(null, GetSettings());
         dialog.IpType = _ipType;

         if (dialog.ShowDialog(this) == DialogResult.OK)
         {
            try
            {
               DicomService service = administrator.InstallService(dialog.Settings);

               AddService(service, true);
               
               CopyAddIns(GetDemoServerAddins(Program.BaseDir),               ActiveService, "Addins");
               CopyAddIns(GetDemoServerConfigurationAddins(Program.BaseDir),  ActiveService, "Configuration");
            }
            catch (Exception ex)
            {
               MessageBox.Show(ex.Message, "Error Installing Service", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
         }
      }

      private List<ServerSettings> GetSettings()
      {
         List<ServerSettings> settings = new List<ServerSettings>();

         foreach (ComboItemImage item in comboBoxService.Items)
         {
            DicomService service = item.Item as DicomService;

            settings.Add(service.Settings);
         }

         return settings;
      }

      private static bool ExcludeIpv6(IPAddress ip)
      {
         string sIp = ip.ToString();
         if (sIp.Contains("."))
            return true;

         if (sIp.Contains("fe80::1"))
            return true;

         return false;
      }

      public static void GetIpListsXp(DicomNetIpTypeFlags ipType, out ArrayList ipListIpv4, out ArrayList ipListIpv6)
      {
         ipListIpv4 = new ArrayList();
         ipListIpv6 = new ArrayList();

         // Obtain a reference to all network interfaces in the machine
         NetworkInterface[] adapters = NetworkInterface.GetAllNetworkInterfaces();
         foreach (NetworkInterface adapter in adapters)
         {
            if (adapter.OperationalStatus == OperationalStatus.Up)
            {
               IPInterfaceProperties properties = adapter.GetIPProperties();
               foreach (IPAddressInformation uniCast in properties.UnicastAddresses)
               {
                  IPAddress ip = uniCast.Address;
                  bool bLoopback = IPAddress.IsLoopback(ip);
                  if (!IPAddress.IsLoopback(ip))
                  {
                     if ((ipType & DicomNetIpTypeFlags.Ipv4) == DicomNetIpTypeFlags.Ipv4)
                     {
                        if (uniCast.Address.AddressFamily == AddressFamily.InterNetwork)
                           ipListIpv4.Add(uniCast.Address.ToString());
                     }

                     if ((ipType & DicomNetIpTypeFlags.Ipv6) == DicomNetIpTypeFlags.Ipv6)
                     {
                        if (uniCast.Address.AddressFamily == AddressFamily.InterNetworkV6)
                        {
                           if (!ExcludeIpv6(ip))
                              ipListIpv6.Add(uniCast.Address.ToString());
                        }
                     }
                  }
               }
            }
         }
      }

      public static void GetIpListsVistaOrHigher(DicomNetIpTypeFlags ipType, out ArrayList ipListIpv4, out ArrayList ipListIpv6)
      {
         ipListIpv4 = new ArrayList();
         ipListIpv6 = new ArrayList();

         ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * From Win32_NetworkAdapterConfiguration WHERE IPEnabled = 1");
         if (searcher != null)
         {
            ManagementObjectCollection adapters = searcher.Get();

            foreach (ManagementObject adapter in adapters)
            {
               string ipAddressIpv4 = string.Empty;
               string ipAddressIpv6 = string.Empty;
               string[] ipArray = (string[])adapter["IPAddress"];

               if (ipArray != null)
               {
                  if (ipArray.Length >= 1)
                     ipAddressIpv4 = ipArray[0];
                  if (ipArray.Length >= 2)
                     ipAddressIpv6 = ipArray[1];

               }
               if ((ipType & DicomNetIpTypeFlags.Ipv4) == DicomNetIpTypeFlags.Ipv4)
               {
                  if (!string.IsNullOrEmpty(ipAddressIpv4))
                     ipListIpv4.Add(ipAddressIpv4);
               }
               if ((ipType & DicomNetIpTypeFlags.Ipv6) == DicomNetIpTypeFlags.Ipv6)
               {
                  if (!string.IsNullOrEmpty(ipAddressIpv6))
                     ipListIpv6.Add(ipAddressIpv6);
               }
            }
         }
      }

      private ArrayList GetIpList(DicomNetIpTypeFlags ipType)
      {
         ArrayList ipListIpv4 = null;
         ArrayList ipListIpv6 = null;

         if (DemosGlobal.IsOnVistaOrLater)
            MainForm.GetIpListsVistaOrHigher(ipType, out ipListIpv4, out ipListIpv6);
         else
            MainForm.GetIpListsXp(ipType, out ipListIpv4, out ipListIpv6);

         ipListIpv4.AddRange(ipListIpv6);
         return ipListIpv4;
      }

      private void SetIpAddressLabel(string ip, DicomNetIpTypeFlags ipType)
      {
         labelIpAddress.Text = ip == "*" ? "All (hover for details)" : ip;
         if (ip == "*")
         {
            ArrayList ipList = GetIpList(ipType);
            string sTip = string.Empty;
            foreach (string s in ipList)
            {
               sTip = sTip + s + "\n";
            }

            // Remove the trailing '\n'
            sTip = sTip.Substring(0, sTip.Length - 1);
            toolTip.SetToolTip(labelIpAddress, sTip);
         }
         else
         {
            toolTip.SetToolTip(labelIpAddress, "");
         }
      }

      private void buttonServiceEdit_Click(object sender, EventArgs e)
      {
         EditServiceDialog dialog = new EditServiceDialog(AddInUtils.Clone<ServerSettings>(ActiveService.Settings), GetSettings());
         dialog.IpType = _ipType;

         if (dialog.ShowDialog(this) == DialogResult.OK)
         {
            ActiveService.Settings = dialog.Settings;
            //labelIpAddress.Text = ActiveService.Settings.IpAddress;
            SetIpAddressLabel(ActiveService.Settings.IpAddress, ActiveService.Settings.IpType);
            labelPort.Text = ActiveService.Settings.Port.ToString();
         }
      }

      // returns true if a new settings file was created
      // false if the settings file already exists
      private bool LoadSettings()
      {
         bool newSettings = false;
         try
         {
            _mySettings = null;

            try
            {
               _mySettings = DicomDemoSettingsManager.LoadSettings(_demoName);
            }
            catch (Exception)
            {
            }

            if (_mySettings == null)
            {
               _mySettings = new DicomDemoSettings();
               DicomDemoSettingsManager.SaveSettings(_demoName, _mySettings);
               newSettings = true;
            }

         }
         catch (Exception)
         {
         }
         return newSettings;
      }

      private void MainForm_Load(object sender, EventArgs e)
      {
          try
          {
              CheckLoggingConfiguration();
              if(eventLog!=null)
                eventLog.FormClosing += new FormClosingEventHandler(eventLog_FormClosing);

             bool newSettings = LoadSettings();
             int serviceCount = administrator.Services.Count;

             if (newSettings && serviceCount == 0)
             {
                _runningPacsConfigDemo = true;
                DicomDemoSettingsManager.RunPacsConfigDemo();
                _runningPacsConfigDemo = false;
             }


              if (administrator.IsLocked)
              {
                  if (administrator.IsLocked)
                  {
                      foreach (Control c in Controls)
                      {
                          c.Enabled = false;
                      }
                  }
                  labelError.Visible = true;
                  labelError.Text = "Error: Support is locked!";
                  labelError.Enabled = true;
              }
              else
              {
                  LoadServices();
                  comboBoxService.Enabled = comboBoxService.Items.Count > 0;
                  toolStripButtonEditServer.Enabled = comboBoxService.Enabled;
                  toolStripButtonDeleteServer.Enabled = comboBoxService.Enabled;
                  serviceTimer = new System.Threading.Timer(new TimerCallback(CheckServiceStatus));
                  serviceTimer.Change(500, 500);
              }
          }
          catch (Exception ex)
          {
              MessageBox.Show(ex.Message, "Error Occurred", MessageBoxButtons.OK, MessageBoxIcon.Error);
          }         
      }
      
      private void CheckLoggingConfiguration()
      {
         toolStripButtonEventLog.Enabled = true;
         eventLog = new EventLogDialog(ActiveService);
      }


      void eventLog_FormClosing(object sender, FormClosingEventArgs e)
      {
          toolStripButtonEventLog.Checked = false;          
      }

      /// <summary>
      /// Checks the service status.
      /// </summary>
      /// <param name="state">The state.</param>
      private void CheckServiceStatus(object state)
      {
         serviceTimer.Change(Timeout.Infinite, Timeout.Infinite);
         try
         {
            AsyncHelper.SynchronizedInvoke(this, delegate()
            {
               comboBoxService.Enabled = comboBoxService.Items.Count > 0;
               toolStripButtonEditServer.Enabled = comboBoxService.Enabled;
               toolStripButtonDeleteServer.Enabled = comboBoxService.Enabled;
            });
            if (ActiveService != null)
            {
               AsyncHelper.SynchronizedInvoke(this, delegate()
               {
                  ComboItemImage item = comboBoxService.SelectedItem as ComboItemImage;

                  if (item != null)
                  {
                     Image old = item.Image;
                     bool running = ActiveService.Status == ServiceControllerStatus.Running;
                     bool paused = ActiveService.Status == ServiceControllerStatus.Paused;

                     toolStripButtonStart.Enabled = !running || paused;
                     toolStripButtonStop.Enabled = running || paused;
                     toolStripButtonPause.Enabled = running;
                     if (oldStatus != ActiveService.Status)
                     {
                        item.Image = GetStatusImage(ActiveService.Status);
                        oldStatus = ActiveService.Status;
                        comboBoxService.Refresh();
                     }
                  }

                  //
                  // Check to see if we need to update our options
                  //
                  if (ActiveService != null)
                  {
                     if (ActiveService.AddInOptions.Count != listViewOptions.Items.Count)
                     {
                        LoadOptions();
                     }
                  }
               });
            }
            else
            {
               AsyncHelper.SynchronizedInvoke(this, delegate()
               {
                  toolStripButtonStart.Enabled = false;
                  toolStripButtonStop.Enabled = false;
                  toolStripButtonPause.Enabled = false;
               });
            }
         }
         finally
         {

            AsyncHelper.SynchronizedInvoke(this, delegate()
            {
               UpdateUI();
            });
            serviceTimer.Change(100, 100);
         }
      }
      
      public string GetLogDatabaseFullPath()
      {
         if (ActiveService == null)
            return string.Empty;
            
         Debug.Assert(!string.IsNullOrEmpty(ActiveService.ServiceDirectory));
         string startPath = ActiveService.ServiceDirectory;
         string LogDatabaseFullPath = Path.Combine(startPath, EventLogDialog.LogDatabaseName);
         return LogDatabaseFullPath;
      }

      public bool LogDatabaseExists()
      {
         string logDatabaseFullPath = GetLogDatabaseFullPath();
         bool enableLog = File.Exists(logDatabaseFullPath);
         return enableLog;
      }

      /// <summary>
      /// Updates the UI.
      /// </summary>
      private void UpdateUI()
      {
         if (ActiveService == null)
            return;

         toolStripButtonAddAeTitle.Enabled = ActiveService.IsAdminAvailable;
         toolStripButtonEditAeTitle.Enabled = ActiveService.IsAdminAvailable && listViewAeTitles.SelectedItems.Count > 0;
         toolStripButtonDeleteAeTitle.Enabled = ActiveService.IsAdminAvailable && listViewAeTitles.SelectedItems.Count > 0;
         toolStripButtonViewAssociation.Enabled = listViewClients.SelectedItems.Count == 1;
         toolStripButtonDisconnectClient.Enabled = toolStripButtonViewAssociation.Enabled;
         
         bool bLoadDatabaseExists = LogDatabaseExists();
            toolStripButtonEventLog.Enabled = bLoadDatabaseExists;
            if (!bLoadDatabaseExists)
            {
               if (eventLog != null)
                  eventLog.Hide();
            }
         }

      private bool IsServicesValid()
      {
         bool isValid = true;
         foreach (KeyValuePair<string, DicomService> service in administrator.Services)
         {
            if (service.Value.Settings == null)
            {
               isValid = false;
            }
         }
         return isValid;
      }

      private void LoadServices()
      {

         bool isValid = IsServicesValid();
         if (!isValid)
         {
            InitializeServiceAdministrator();
         }

         foreach (KeyValuePair<string, DicomService> service in administrator.Services)
         {
            if (service.Value.Settings == null)
            {
               // This shouldn't happen
            }
            AddService(service.Value, false);
         }

         if (comboBoxService.Items.Count > 0 && comboBoxService.SelectedIndex == -1)
         {
            comboBoxService.SelectedIndex = 0;
         }
      }

      private bool IsServiceAdded(DicomService service)
      {
         foreach (ComboItemImage item in comboBoxService.Items)
         {
            DicomService s = item.Item as DicomService;

            if (service == s)
               return true;
         }
         return false;
      }

      /// <summary>
      /// Gets the status image corresponding to the server status.
      /// </summary>
      /// <param name="status">The service status.</param>
      /// <returns></returns>
      private Image GetStatusImage(ServiceControllerStatus status)
      {
         switch (status)
         {
            case ServiceControllerStatus.Running:
               return Properties.Resources.StartService_Image;
            case ServiceControllerStatus.Stopped:
               return Properties.Resources.StopService_Image;
            case ServiceControllerStatus.Paused:
               return Properties.Resources.PauseService_Image;
         }
         return null;
      }
      
      private bool IsServerManagerService(DicomService service)
      {
         bool bAddToList = true;
         foreach (IAddInOptions addin in service.AddInOptions)
         {
            if (addin.Text.Contains("Media") || addin.Text.Contains("Patient Updater"))
               bAddToList = false;
         }

         try
         {
            if (bAddToList)
            {
               // Check to see if it is a gateway
               string gatewayPath = Path.Combine(service.ServiceDirectory, @"Addins\Leadtools.Medical.Gateway.AddIn.dll");
               bAddToList = !File.Exists(gatewayPath);
            }
         }
         catch (Exception)
         {
         }

         return bAddToList;
      }

      private void AddService(DicomService service, bool select)
      {
         if (IsServerManagerService(service) == false)
            return;


         if (IsServiceAdded(service))
            return;

         // Add only if the service has not already been added
         ComboItemImage item = new ComboItemImage(service);
         int index = comboBoxService.Items.Add(item);

         item.Image = GetStatusImage(service.Status);
         comboBoxService.Enabled = comboBoxService.Items.Count > 1;
         if (select)
            comboBoxService.SelectedIndex = index;

         service.StatusChange += new EventHandler(service_StatusChange);
         service.Message += new EventHandler<MessageEventArgs>(service_Message);
      }

      private int GetBaseIndex()
      {
         int baseIndex;
#if LEADTOOLS_V19_OR_LATER
         baseIndex = 1;
#else
         clientInfoIndex = 0;
#endif
         return baseIndex;
      }

      void service_Message(object sender, MessageEventArgs e)
      {
         //
         // If message isn't for current service return
         //
         if (ActiveService != (sender as DicomService))
            return;

         ServiceMessage m = AddInUtils.Clone<ServiceMessage>(e.Message);

         switch (m.Message)
         {
            case MessageNames.AddAeTitle:
               AsyncHelper.SynchronizedInvoke(this, delegate()
               {
                  if (m.Success)
                     AddAe(m.Data[0] as AeInfo);
                  else
                     ShowError("Error Adding AE Title", m.Error);
               });
               break;
            case MessageNames.GetAeTitles:
               AsyncHelper.SynchronizedInvoke(this, delegate()
               {
                  if (m.Success)
                     LoadAes(m.Data[0] as List<AeInfo>);
                  else
                     ShowError("Error Getting AE Titles", m.Error);
               });
               break;
            case MessageNames.UpdateAeTitle:
               AsyncHelper.SynchronizedInvoke(this, delegate()
               {
                  if (!m.Success)
                  {
                     ShowError("Error Updating AE Title", m.Error);
                     UpdateAe(m.Data[0] as string, m.Data[1] as AeInfo, true);
                  }
                  else
                     UpdateAe(m.Data[0] as string, m.Data[1] as AeInfo, false);
               });
               break;
            case MessageNames.RemoveAeTitle:
               AsyncHelper.SynchronizedInvoke(this, delegate()
               {
                  if (!m.Success)
                     ShowError("Error Removing AE Title", m.Error);
                  else
                     RemoveAe(m.Data[0] as string);
               });
               break;
            case MessageNames.ClientConnected:
               AsyncHelper.SynchronizedInvoke(this, delegate()
               {
                  int baseIndex = GetBaseIndex();
                  AddClient(m.Data[baseIndex] as ClientInfo);
               });
               break;
            case MessageNames.ClientDisconnected:
               AsyncHelper.SynchronizedInvoke(this, delegate()
               {
                  int baseIndex = GetBaseIndex();
                  RemoveClient(m.Data[baseIndex] as ClientInfo);
               });
               break;
            case MessageNames.ClientAssociated:
               AsyncHelper.SynchronizedInvoke(this, delegate()
               {
                  int baseIndex = GetBaseIndex();
                  UpdateClient(m.Data[baseIndex] as ClientInfo);
               });
               break;
            case MessageNames.ClientAction:
               AsyncHelper.SynchronizedInvoke(this, delegate()
               {
                  int baseIndex = GetBaseIndex();

                  string action = m.Data[baseIndex] as string;
                  string aetitle = m.Data[baseIndex + 1] as string;

                  SetLastAction(action, aetitle);
               });
               break;
         }
      }

      void service_StatusChange(object sender, EventArgs e)
      {
         if (ActiveService == (sender as DicomService) && ActiveService.Status == ServiceControllerStatus.Running)
         {
            AsyncHelper.SynchronizedInvoke(this, delegate() { InitializeService(); });
         }
      }

      private bool Is64()
      {
         int bits = IntPtr.Size * 8;

         return bits == 64;
      }

      private void comboBoxService_SelectedIndexChanged(object sender, EventArgs e)
      {
         ComboItemImage item = comboBoxService.SelectedItem as ComboItemImage;
         ActiveService = item.Item as DicomService;

         listViewAeTitles.Items.Clear();
         item.Image = GetStatusImage(ActiveService.Status);
         toolStripButtonEditServer.Enabled = true;
         toolStripButtonDeleteServer.Enabled = true;

         //labelIpAddress.Text = ActiveService.Settings.IpAddress;
         SetIpAddressLabel(ActiveService.Settings.IpAddress, ActiveService.Settings.IpType);
         labelPort.Text = ActiveService.Settings.Port.ToString();
         
         // Log
         if (eventLog != null)
         {
            eventLog.ActiveService = ActiveService;
            eventLog.Clear();
            eventLog.UpdateService();
         }

         //
         // Load Options
         //
         LoadOptions();

         oldStatus = ActiveService.Status;
         if (ActiveService.Status == ServiceControllerStatus.Running)
         {
            InitializeService();
         }
      }

      private void LoadOptions()
      {
         listViewOptions.Items.Clear();
         imageListOptions.Images.Clear();
         try
         {
            //
            // Make a copy of the list because it could change while
            // we are enumerating.
            //
            List<IAddInOptions> list = new List<IAddInOptions>(ActiveService.AddInOptions);

            foreach (IAddInOptions option in list)
            {
                if (!IsOptionLoaded(option))
                {
                    AddOption(option);
                }
            }
         }
         catch { }
      }

      private void AddOption(IAddInOptions option)
      {
         int imageIndex = 0;
         ListViewItem item = null;

         if (option.Image != null)
         {
            imageListOptions.Images.Add(option.Image.ToImage());
            imageIndex = imageListOptions.Images.Count - 1;
         }

         item = new ListViewItem(option.Text, imageIndex);
         item.Tag = option;
         item.ToolTipText = "Double-click for options";
         listViewOptions.Items.Add(item);
      }

      private bool IsOptionLoaded(IAddInOptions option)
      {
          foreach (ListViewItem item in listViewOptions.Items)
          {
              IAddInOptions o = item.Tag as IAddInOptions;

              if (o.Text == option.Text)
                  return true;
          }
          return false;
      }

      private bool IsMedicalWorkstationAddinException(Exception ex)
      {
         if (ex.Message.Contains("LEADTOOLS Medical Workstation AddIn"))
            return true;
         else if (ex.InnerException != null)
            return IsMedicalWorkstationAddinException(ex.InnerException);
         else return false;
      }

      private void listViewOptions_DoubleClick(object sender, EventArgs e)
      {
         if (listViewOptions.SelectedItems.Count == 1)
         {
            IAddInOptions option = listViewOptions.SelectedItems[0].Tag as IAddInOptions;

            try
            {
               option.Configure(this, ActiveService.Settings, ActiveService.ServiceDirectory);
            }
            catch (Exception ex)
            {
               if (IsMedicalWorkstationAddinException(ex))
               {
                  MessageBox.Show("This service is used by the Medical Workstation demos. You must run one of the Medical Workstation demos to access this addin.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
               }
               else
                  MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
         }
      }

      /// <summary>
      /// Shows the error.
      /// </summary>
      /// <param name="Caption">The caption.</param>
      /// <param name="Message">The message.</param>
      private void ShowError(string Caption, string Message)
      {
         MessageBox.Show(Message, Caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
      }

      private void InitializeService()
      {
         listViewAeTitles.Items.Clear();

         //
         // Request server ae titles
         //    
         try
         {
            ActiveService.SendMessage(MessageNames.GetAeTitles);
         }
         catch (Exception )
         {
            // MessageBox.Show(ex.Message, "Error sending message", MessageBoxButtons.OK, MessageBoxIcon.Error);
         }
      }

      private void LoadAes(List<AeInfo> aes)
      {
         foreach (AeInfo ae in aes)
         {
            AddAe(ae);
         }
      }

      /// <summary>
      /// Adds the ae.
      /// </summary>
      /// <param name="info">The ae info.</param>
      private void AddAe(AeInfo info)
      {
         ListViewItem item = listViewAeTitles.Items.Add(info.AETitle);

         item.SubItems.Add(info.Address);
         item.SubItems.Add(info.Port.ToString());
         item.SubItems.Add(info.SecurePort.ToString());
         item.Tag = info;
      }

      /// <summary>
      /// Removes the ae.
      /// </summary>
      /// <param name="deleteAE">The delete AE.</param>
      private void RemoveAe(string deleteAE)
      {
         foreach (ListViewItem item in listViewAeTitles.Items)
         {
            AeInfo ae = item.Tag as AeInfo;

            if (ae.AETitle == deleteAE)
            {
               listViewAeTitles.Items.Remove(item);
               break;
            }
         }
      }

      /// <summary>
      /// Updates the ae.
      /// </summary>
      /// <param name="oldAe">The old ae.</param>
      /// <param name="info">The new ae info.</param>
      private void UpdateAe(string oldAe, AeInfo info, bool failed)
      {
         foreach (ListViewItem item in listViewAeTitles.Items)
         {
            AeInfo old = item.Tag as AeInfo;

            if (old.AETitle == oldAe)
            {
               //
               // If the update didn't fail we will update the display
               //
               if (!failed)
               {
                  item.Text = info.AETitle;
                  item.SubItems[1].Text = info.Address;
                  item.SubItems[2].Text = info.Port.ToString();
                  item.SubItems[3].Text = info.SecurePort.ToString();
                  item.Tag = info;
               }
               else
                  item.Tag = oldAeInfo;
               break;
            }
         }
      }

      /// <summary>
      /// Adds the client.
      /// </summary>
      /// <param name="client">The client.</param>
      private void AddClient(ClientInfo client)
      {
         if (client != null)
         {
            ListViewItem item = listViewClients.Items.Add(client.IpAddress);

            item.Tag = client;
            item.SubItems.Add(client.AETitle);
            item.SubItems.Add(client.ConnectTime.ToString());
            item.SubItems.Add(string.Empty);
         }
      }

      /// <summary>
      /// Removes the client.
      /// </summary>
      /// <param name="client">The client.</param>
      private void RemoveClient(ClientInfo client)
      {
         if (client != null)
         {
            foreach (ListViewItem item in listViewClients.Items)
            {
               ClientInfo lvc = item.Tag as ClientInfo;

               if (lvc.Id == client.Id)
               {
                  listViewClients.Items.Remove(item);
                  break;
               }
            }
         }
      }

      /// <summary>
      /// Updates the client.
      /// </summary>
      /// <param name="client">The client.</param>
      private void UpdateClient(ClientInfo client)
      {
         if (client != null)
         {
            foreach (ListViewItem item in listViewClients.Items)
            {
               ClientInfo lvc = item.Tag as ClientInfo;

               if (lvc.Id == client.Id)
               {
                  item.Tag = client;
               }
            }
         }
      }

      /// <summary>
      /// Sets the last action.
      /// </summary>
      /// <param name="action">The action.</param>
      /// <param name="aetitle">The aetitle.</param>
      private void SetLastAction(string action, string aetitle)
      {
         foreach (ListViewItem item in listViewClients.Items)
         {
            ClientInfo c = item.Tag as ClientInfo;

            if (c.AETitle == aetitle)
            {
               item.SubItems[3].Text = action;
               break;
            }
         }
      }

      private void buttonStart_Click(object sender, EventArgs e)
      {
         try
         {
            ActiveService.Start();
         }
         catch (Exception ex)
         {
            MessageBox.Show(this, ex.Message, "Error Starting Service", MessageBoxButtons.OK, MessageBoxIcon.Error);
         }
      }

      private void buttonPause_Click(object sender, EventArgs e)
      {
         ActiveService.Pause();
      }

      private void buttonStop_Click(object sender, EventArgs e)
      {
         ActiveService.Stop();
         listViewAeTitles.Items.Clear();
         listViewClients.Items.Clear();
      }

      private void toolStripButtonAddAeTitle_Click(object sender, EventArgs e)
      {
         EditAeTitleDialog dialog = new EditAeTitleDialog(null);

         if (dialog.ShowDialog(this) == DialogResult.OK)
         {
            try
            {
               ActiveService.SendMessage(MessageNames.AddAeTitle, dialog.AeInfo);
            }
            catch (Exception ex)
            {
               MessageBox.Show(ex.Message, "Error sending message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
         }
      }

      private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
      {
      }

      private void toolStripButtonEditAeTitle_Click(object sender, EventArgs e)
      {
         EditAeTitleDialog dialog = new EditAeTitleDialog(listViewAeTitles.SelectedItems[0].Tag as AeInfo);
         string oldAe = dialog.AeInfo.AETitle;

         oldAeInfo = AddInUtils.Clone<AeInfo>(dialog.AeInfo);
         if (dialog.ShowDialog(this) == DialogResult.OK)
         {
            try
            {
               ActiveService.SendMessage(MessageNames.UpdateAeTitle, oldAe, dialog.AeInfo);
            }
            catch (Exception ex)
            {
               MessageBox.Show(ex.Message, "Error sending message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
         }
      }

      private void toolStripButtonDeleteAeTitle_Click(object sender, EventArgs e)
      {
         AeInfo info = listViewAeTitles.SelectedItems[0].Tag as AeInfo;

         try
         {
            ActiveService.SendMessage(MessageNames.RemoveAeTitle, info.AETitle);
         }
         catch (Exception ex)
         {
            MessageBox.Show(ex.Message, "Error sending message", MessageBoxButtons.OK, MessageBoxIcon.Error);
         }
      }

      private void notifyIcon_DoubleClick(object sender, EventArgs e)
      {
         ShowFromTaskBar();
      }

      /// <summary>
      /// Shows from the task bar.
      /// </summary>
      public void ShowFromTaskBar()
      {
         WindowState = FormWindowState.Normal;
         ShowInTaskbar = true;
         notifyIcon.Visible = false;
      }

      private void exitToolStripMenuItem_Click(object sender, EventArgs e)
      {
         Close();
      }

      private void toolStripButtonDeleteServer_Click(object sender, EventArgs e)
      {
         ComboItemImage item = comboBoxService.SelectedItem as ComboItemImage;
         DialogResult result = DialogResult.Yes;

         //
         // Disable the ui checking until done
         //
         serviceTimer.Change(Timeout.Infinite, Timeout.Infinite);

         if (ActiveService.Status == ServiceControllerStatus.Running)
         {
            result = MessageBox.Show("Service is currently running\r\nDo you want to stop and delete?", "Service Running",
                                     MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (result == DialogResult.Yes)
            {
               ActiveService.Stop();
               while (ActiveService.Status != ServiceControllerStatus.Stopped)
               {
                  Application.DoEvents();
               }
            }
         }

         if (result == DialogResult.Yes)
         {
            try
            {
               administrator.UnInstallService(ActiveService);
               comboBoxService.Items.Remove(item);
               labelIpAddress.Text = string.Empty;
               labelPort.Text = string.Empty;

               if (comboBoxService.Items.Count > 0)
               {
                  comboBoxService.SelectedIndex = 0;
               }

               comboBoxService.Enabled = comboBoxService.Items.Count > 1;
               listViewAeTitles.Items.Clear();
               listViewClients.Items.Clear();
               MessageBox.Show("Service successfully uninstalled", "Service Uninstalled", MessageBoxButtons.OK, MessageBoxIcon.Information);
               if (comboBoxService.SelectedIndex == -1)
               {
                  ActiveService = null;
               }
            }
            catch (Exception ex)
            {
               MessageBox.Show(ex.Message, "Error Uninstalling Service", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
         }
         serviceTimer.Change(500, 500);
      }

      private void toolStripButtonViewAssociation_Click(object sender, EventArgs e)
      {
         ClientInfo client = listViewClients.SelectedItems[0].Tag as ClientInfo;
         AssociationDialog dialog = new AssociationDialog(client);

         dialog.ShowDialog(this);
      }

      private void toolStripButtonDisconnectClient_Click(object sender, EventArgs e)
      {
         ClientInfo client = listViewClients.SelectedItems[0].Tag as ClientInfo;

         try
         {
            ActiveService.SendMessage(MessageNames.DisconnectClient, client);
         }
         catch (Exception ex)
         {
            MessageBox.Show(ex.Message, "Error sending message", MessageBoxButtons.OK, MessageBoxIcon.Error);
         }
      }

      private void MainForm_SizeChanged(object sender, EventArgs e)
      {
         if (WindowState == FormWindowState.Minimized)
         {
            ShowInTaskbar = false;
            notifyIcon.Visible = true;
         }
      }

      private void comboBoxService_DropDown(object sender, EventArgs e)
      {
         foreach (ComboItemImage item in comboBoxService.Items)
         {
            if (item != comboBoxService.SelectedItem)
            {
               DicomService service = item.Item as DicomService;

               item.Image = GetStatusImage(service.Status);
            }
         }
      }

      private void listViewAeTitles_DoubleClick(object sender, EventArgs e)
      {
         if (toolStripButtonEditAeTitle.Enabled)
         {
            toolStripButtonEditAeTitle_Click(this, EventArgs.Empty);
         }
      }

      private void toolStripButtonStartAll_Click(object sender, EventArgs e)
      {
         foreach (KeyValuePair<string, DicomService> service in administrator.Services)
         {
            if (IsServerManagerService(service.Value))
            {
               try
               {
                  if (service.Value.Status == ServiceControllerStatus.Paused || service.Value.Status == ServiceControllerStatus.Stopped)
                  {
                     service.Value.Start();
                  }
               }
               catch (Exception ex)
               {
                  MessageBox.Show(ex.Message, "Error Starting: " + service.Value.Settings.DisplayName, MessageBoxButtons.OK, MessageBoxIcon.Error);
               }
            }
         }
      }

      private void toolStripButtonStopAll_Click(object sender, EventArgs e)
      {
         foreach (KeyValuePair<string, DicomService> service in administrator.Services)
         {
            if (IsServerManagerService(service.Value))
            {
               try
               {
                  if (service.Value.Status == ServiceControllerStatus.Paused || service.Value.Status == ServiceControllerStatus.Running)
                  {
                     service.Value.Stop();
                  }
               }
               catch (Exception ex)
               {
                  MessageBox.Show(ex.Message, "Error Stopping: " + service.Value.Settings.DisplayName, MessageBoxButtons.OK, MessageBoxIcon.Error);
               }
            }
         }
      }

      private void tabControl1_Selecting(object sender, TabControlCancelEventArgs e)
      {
         e.Cancel = e.TabPage == tabPageClients && (ActiveService == null || ActiveService.Status == ServiceControllerStatus.Stopped);
      }

      private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
      {
         if (serviceTimer != null)
            serviceTimer.Change(Timeout.Infinite, Timeout.Infinite);

         if (eventLog != null)
         {
             eventLog.Close();
             eventLog = null;             
         }
      }

      private void toolStripButtonHelp_Click(object sender, EventArgs e)
      {
          HelpDialog dlg = new HelpDialog();
          
          dlg.ShowDialog(this);
      }

      private void toolStripButtonEventLog_Click(object sender, EventArgs e)
      {
         if (toolStripButtonEventLog.Checked)
         {
            if (eventLog == null || eventLog.IsDisposed)
            {
               eventLog = new EventLogDialog(ActiveService);
            }
            
            eventLog.ActiveService = ActiveService;
            eventLog.StartPosition = FormStartPosition.CenterParent;
            eventLog.Show(this);
         }
         else
         {
            eventLog.Hide();
         }
      }

      private void MainForm_Shown(object sender, EventArgs e)
      {
          if (Settings.Default.ShowHelpAgain)
          {
              HelpDialog dlg = new HelpDialog();

              dlg.ShowHelpCheckBox = true;
              dlg.ShowDialog(this);
              if (dlg.CheckBoxNoShowAgainResult == true)
              {
                  Settings.Default.ShowHelpAgain = false;
                  Settings.Default.Save();
              }
          }
      }
   }
}

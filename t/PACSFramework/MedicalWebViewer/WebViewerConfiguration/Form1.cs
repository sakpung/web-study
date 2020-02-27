// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Configuration;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using IISAdmin = Microsoft.Web.Administration;

using Leadtools.Demos;
using Leadtools.DicomDemos;
using Leadtools.Medical.DataAccessLayer;
using Leadtools.Medical.OptionsDataAccessLayer;
using Leadtools.Medical.OptionsDataAccessLayer.Configuration;
using Leadtools.Medical.Winforms;
using Leadtools.Dicom.Server.Admin;
using Leadtools.Demos.StorageServer.DataTypes;


namespace WebViewerConfiguration
{
   public partial class Form1 : Form
   {
      public Form1()
      {
         InitializeComponent();
      }

      protected override void OnShown(EventArgs e)
      {
          base.OnShown(e);
      }

      protected override void OnLoad(EventArgs e)
      {
         base.OnLoad(e);

         try
         {
            if ( !Init ( ) )
            {
               Application.Exit () ;
            }
         }
         catch ( Exception ex ) 
         {
             Show();
             Messager.ShowError(this, ex);
            Application.Exit();
         }

          optionsToolStripMenuItem.Visible = false;

#if LEADTOOLS_V20_OR_LATER
         optionsToolStripMenuItem.Visible = !PathHelper.UseNugetPath() || PathHelper.UseNugetPathAndAspServiceIncluded();
         ConfigWebClient.SetViewerDirectory(_viewerDirectory);
         _serviceType = ConfigWebClient.GetServiceType();

         if (PathHelper.UseNugetPath())
         {
            create3DServiceInstallerToolStripMenuItem.Visible = false;
            configure3DServiceToolStripMenuItem.Visible = false;
            toolStripSeparator2.Visible = false;
         }
         UpdateServiceUI(_serviceType);
#endif

         WebServiceInstaller.Configure3DServiceToolStripMenuItemText = this.configure3DServiceToolStripMenuItem.Text;

         this.buttonOK.Visible = false;
         if (PathHelper.UseExternalWebServicePath())
         {
            btnFix.Text = "Install Web Service";
            btnFix.Width = 120;

            btnRun.Visible = false;
            radioButtonMedical.Visible = false;
            radioButtonDental.Visible = false;
            optionsToolStripMenuItem.Visible = false;
            fileToolStripMenuItem.Visible = false;
            buttonOK.Visible = true;
            buttonOK.Click += ButtonOK_Click;
         }

         if (PathHelper.UseMedicorPath())
         {
            useASPNETServiceToolStripMenuItem.Visible = false;
            useWCFServiceToolStripMenuItem.Visible = false;
            toolStripSeparator1.Visible = false;
         }

         silentRegisterToolStripMenuItem.Checked = silentRegister;

         ShowExtraOptions(false);
      }

      private void ShowExtraOptions(bool show)
      {
         toolStripSeparatorExtraOptions.Visible = show;
         toolStripSeparatorExtraOptions2.Visible = show;
         toolStripSeparatorExtraOptions3.Visible = show;
         silentRegisterToolStripMenuItem.Visible = show;
         registerLeadtoolsMedical3DProxyexeToolStripMenuItem.Visible = show;
         startLeadtoolsMedical3DProxyexeToolStripMenuItem.Visible = show;
         stopLeadtoolsMedical3DProxyexeToolStripMenuItem.Visible = show;
         deleteLeadtoolsMedical3DProxyexeToolStripMenuItem.Visible = show;
         installLeadtoolsMedical3DProxyexeToolStripMenuItem.Visible = show;

         if (PathHelper.UseMedicorPath())
         {
            useASPNETServiceToolStripMenuItem.Visible = show;
            useWCFServiceToolStripMenuItem.Visible = show;
            toolStripSeparator1.Visible = show;
         }
      }

      private void ButtonOK_Click(object sender, EventArgs e)
      {
         Close();
         DialogResult = DialogResult.OK;
      }

      void InitializeTroubleShooting()
      {
         dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
         dataGridView1.RowHeadersVisible = false;

         dataGridView1.AllowDrop = false;
         dataGridView1.AllowUserToAddRows = false;
         dataGridView1.AllowUserToDeleteRows = false;
         dataGridView1.AllowUserToOrderColumns = false;
         dataGridView1.AllowUserToResizeColumns = false;

         dataGridView1.DefaultCellStyle.SelectionBackColor = Color.White;
         dataGridView1.DefaultCellStyle.SelectionForeColor = Color.Black;
         dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
         dataGridView1.Columns[0].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
         dataGridView1.CellContentClick += DataGridView1_CellContentClick;

         

         dataGridView1.Rows.Add(@"Requirements", "https://www.leadtools.com/support/guides/MedicalWebViewer-requirements.pdf");
         dataGridView1.Rows.Add(@"Could not load type 'System.ServiceModel.Activation.HttpModule'", "http://support.microsoft.com/kb/2015129");
         dataGridView1.Rows.Add(@"Login failed for user 'NT AUTHORITY\SYSTEM'. Cannot open database requested by the login.", "https://www.leadtools.com/support/guides/medicalwebviewer-troubleshooting-guide.pdf");
         dataGridView1.Rows.Add(@"Medical Viewer icons are blank.", "https://www.leadtools.com/support/guides/medicalwebviewer-troubleshooting-guide.pdf");
         dataGridView1.Rows.Add(@"Internet Information Services (IIS) Issues.", "https://www.leadtools.com/support/guides/MedicalWebViewer-IIS-Requirements.pdf");
         dataGridView1.Rows.Add(@"WCF Service Issues", "https://www.leadtools.com/support/guides/leadtoolsserviceshostmanagertroubleshooting.html");
         dataGridView1.Rows.Add(@"Login failed. The login is from an untrusted domain and cannot be used with Windows authentication.", "https://www.leadtools.com/support/guides/externalwebservices-troubleshooting-guide.pdf");
         dataGridView1.Rows.Add(@"A network-related or instance-specific error occurred while establishing a connection to SQL Server. The server was not found or was not accessible. Verify that the instance name is correct and that SQL Server is configured to allow remote connections.", "https://www.leadtools.com/support/guides/externalwebservices-troubleshooting-guide.pdf");

      }

      private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
      {
         if (dataGridView1.Columns[e.ColumnIndex] is DataGridViewLinkColumn)
         {
            Process.Start(this.dataGridView1[e.ColumnIndex, e.RowIndex].Value.ToString());
         }
      }

      /// <summary>
      /// The init function will check the status of all configuration and set the UI
      /// </summary>
      /// <returns></returns>
      private bool Init()
      {
         PacsProduct.ProductName = DicomDemoSettingsManager.ProductNameStorageServer;

         btnFix.Enabled = false ;

         Logger.ListViewLog = listViewStatus;

         //lstStatus.DrawMode = DrawMode.OwnerDrawFixed ;
         //lstStatus.DrawItem += new DrawItemEventHandler(lstStatus_DrawItem);

#if LEADTOOLS_V20_OR_LATER
         _viewerDirectory = ConfigurationManager.AppSettings [ "ViewerDirectory20" ] ;
         _wcfServiceDirectory = ConfigurationManager.AppSettings [ "ServiceDirectory20" ] ;
         _aspServiceDirectory = ConfigurationManager.AppSettings["AspServiceDirectory20"];
         if (PathHelper.UseMedicorPath())
         {
            _dicomWebServiceDirectory = ConfigurationManager.AppSettings["DICOMwebServiceDirectory20"];
         }

         _serviceUri2D = ConfigurationManager.AppSettings["ServiceUri2D"];
         if (!bool.TryParse(ConfigurationManager.AppSettings["UseLocalService2D"], out _useLocalService2D))
         {
            //default is local
            _useLocalService2D = true;
         }

         _serviceUri3D = ConfigurationManager.AppSettings["ServiceUri3D"];
         if (!bool.TryParse(ConfigurationManager.AppSettings["UseLocalService3D"], out _useLocalService3D))
         {
            //default is local
            _useLocalService3D = true;
         }

         radioButtonMedical.Visible = true;
         radioButtonDental.Visible = true;
#elif LEADTOOLS_V19_OR_LATER
         _viewerDirectory = ConfigurationManager.AppSettings [ "ViewerDirectory19" ] ;
         _wcfServiceDirectory = ConfigurationManager.AppSettings [ "ServiceDirectory19" ] ;

         radioButtonMedical.Visible = true;
         radioButtonDental.Visible = true;
#else
         _viewerDirectory = ConfigurationManager.AppSettings [ "ViewerDirectory" ] ;
         _wcfServiceDirectory = ConfigurationManager.AppSettings [ "ServiceDirectory" ] ;
         radioButtonMedical.Visible = false;
         radioButtonDental.Visible = false;
#endif
         SetUI_Defaults();
         IISTools.Initialize ( ) ;

         InitializeTroubleShooting();


         if ( ConfigureStorageServerInfo ( ) ) 
         {
            CheckWebViewerConnectionConfiguration ( ) ;
            CheckWebViewerServerConfiguration ( ) ;
            try
            {
                CheckIISStatus();
            }
            catch (Exception ex)
            {
                String details = "An error has occurred. It seems there is one or more missing components that are necessary to start the configuration window. Please click on \" View Configuration Guide \" for more information. \n\r Error Details: " + ex.Message;
                MissingComponents missingComponentsDialog = new MissingComponents(details);
                Show();
                missingComponentsDialog.ShowDialog();
                Application.Exit();
            }

            UpdateUIState ( ) ;

            return true ;
         }
         else
         {
            return false;
         }
         
      }

      private static void RegisterOptionsDataAccess ( )
      {
         IOptionsDataAccessAgent optionsAgent ;

         System.Configuration.Configuration configuration = DicomDemoSettingsManager.GetGlobalPacsConfiguration();

         optionsAgent = DataAccessFactory.GetInstance(new OptionsDataAccessConfigurationView(configuration, DicomDemoSettingsManager.ProductNameStorageServer, null)).CreateDataAccessAgent<IOptionsDataAccessAgent>();

         DataAccessServices.RegisterDataAccessService<IOptionsDataAccessAgent>(optionsAgent);
      }

      protected int FilterMissingWebapps(List<string> webapps)
      {
         using (var serverManager = new IISAdmin.ServerManager())
         {
            foreach (var site in serverManager.Sites)
            {
               foreach (var app in site.Applications)
               {
                  var path = app.Path.Trim('/');
                  webapps.Remove(path);

                  if (webapps.Count == 0)
                     break;
               }

               if (webapps.Count == 0)
                  break;
            }
         }
         return webapps.Count;
      }

      protected string FindWebappDiskPath(string webapp)
      {
         using (var serverManager = new IISAdmin.ServerManager())
         {
            foreach (var site in serverManager.Sites)
            {
               foreach (var app in site.Applications)
               {
                  if (app.IsLocallyStored)
                  {
                     var path = app.Path.Trim('/');
                     if(webapp==path)
                     {
                        var diskPath = app.VirtualDirectories["/"].PhysicalPath;
                        return diskPath;
                     }
                  }
               }
            }
         }
         return string.Empty;
      }

      protected List<string> BuildWebappUri(IISAdmin.Site site, IISAdmin.Application app)
      {
         var urls = new List<string>();

         foreach (var binding in site.Bindings)
         {
            var sb = new StringBuilder();
            sb.Append(binding.Protocol);
            sb.Append("://");
            if (!string.IsNullOrWhiteSpace(binding.Host))
            {
               sb.Append(binding.Host);
            }
            else
            {
               if (Equals(binding.EndPoint?.Address, IPAddress.Any))
               {
                  sb.Append("localhost");
               }
               else
               {
                  sb.Append(binding.EndPoint?.Address);
               }
            }

            if (binding.EndPoint?.Port != 80)
            {
               sb.Append(":");
               sb.Append(binding.EndPoint?.Port);
            }

            sb.Append(app.Path);
            urls.Add(sb.ToString());
         }

         return urls;
      }
      protected string FindFirstWebappUri(string webapp)
      {
         using (var serverManager = new IISAdmin.ServerManager())
         {
            foreach (var site in serverManager.Sites)
            {
               foreach (var app in site.Applications)
               {
                  var path = app.Path.Trim('/');
                  if (webapp == path)
                  {
                     var uris = BuildWebappUri(site, app);
                     if(uris.Count>0)
                        return uris.FirstOrDefault();
                  }
               }
            }
         }
         return string.Empty;
      }

      /// <summary>
      /// Checks if the virtual directories are created and points to the right folders
      /// TODO: needs to also verify if the config is right (.NET version and arch. x64 or win32)
      /// </summary>
      protected virtual void CheckIISStatus()
      {
         if ( IISTools.IsIISAvailable )
         {
            var apps = new List<string>() { _viewerDirectory, _wcfServiceDirectory, _aspServiceDirectory, _dicomWebServiceDirectory };
            var notfound = FilterMissingWebapps(apps);
            
            string wcfDefaultPath = Path.GetDirectoryName(PathHelper.GetWcfServiceConfigPath());
            string aspDefaultPath = Path.GetDirectoryName(PathHelper.GetAspServiceConfigPath());

            bool isViewerConfigured = !apps.Contains(_viewerDirectory) || PathHelper.UseExternalWebServicePath();
            bool isWcfServiceConfigured = !apps.Contains(_wcfServiceDirectory);
            bool isAspServiceConfigured = !apps.Contains(_aspServiceDirectory);
            bool isDICOMwebServiceConfigured = string.IsNullOrEmpty(_dicomWebServiceDirectory) ? !apps.Contains(_dicomWebServiceDirectory) : true;

            bool iisNotConfigured = (
               !isViewerConfigured ||
               !isWcfServiceConfigured ||
               !IsPathEqual(FindWebappDiskPath(_wcfServiceDirectory), wcfDefaultPath)
               );

            if (!PathHelper.UseNugetPath() || PathHelper.UseNugetPathAndAspServiceIncluded())
            {
               iisNotConfigured =
                  iisNotConfigured ||
                  !isAspServiceConfigured ||
                  !IsPathEqual(FindWebappDiskPath(_aspServiceDirectory), aspDefaultPath) ||
                  isDICOMwebServiceConfigured;
            }

            if (iisNotConfigured)
            {
               SetIIsNotConfigured();
            }
            else
            {
               SetIIsConfigured();
            }
         }
         else
         {
            SetIIsNotConfigured ( ) ;
         }
      }

      protected bool IsPathEqual(string path1, string path2)
      {
         return (0 == String.Compare( Path.GetFullPath(path1).TrimEnd('\\'),
                                 Path.GetFullPath(path2).TrimEnd('\\'), 
                                 StringComparison.InvariantCultureIgnoreCase) ) ;
      }

      protected virtual string MaskPassword(string s)
      {         
         // do nothing for the LEAD version
         return s;
      }

      /// <summary>
      /// checks the storage server configuration
      /// </summary>
      /// <returns></returns>
      private bool ConfigureStorageServerInfo ( ) 
      {
         if ( StorageServerHelper.IsDatabaseConfigured ( ) && StorageServerHelper.IsDatabaseUpToDate ( ) )
         {
            if ( StorageServerHelper.IsSqlCe ( ) )
            {
               Messager.ShowError ( this, "ASP.NET can't run with SQL Server Compact 3.5 database. The Medical Web Viewer can't be configured.\n\rYou need to configure the PACS Framework with SQL Server" ) ;
               
               return false ;
            }


            RegisterOptionsDataAccess( ) ;

            //get connection string for the storage server database
            _connection = StorageServerHelper.GetConnectionSettings ( ) ;
            //get the storage server info
            _serverInfo =  StorageServerHelper.GetServerInformation ( ) ;
            
            lblConnection.Text = MaskPassword(_connection.ConnectionString);

            if (  ( null != _serverInfo )  || PathHelper.UseMedicorPath()   )
            {

               if (null != _serverInfo)
               {
                  lblServerName.Text = "Server AE: " + _serverInfo.DicomServer.AE;
                  lblIPAddress.Text = "IP Address: " + _serverInfo.DicomServer.IPAddress;
                  lblPort.Text = "Port: " + _serverInfo.DicomServer.Port.ToString();
               }


               //checks if the storage server database is upgraded with the web viewer tables
               if ( StorageServerHelper.IsDatabaseUpgraded ( ) )
               {
                  _upgraded = true ;

                  SetDatabaseUpgraded ( ) ;
               }
               else
               {
                  _upgraded = false ;

                  SetDatabaseNotUpgraded ( ) ;
               }
            }
            //The storage server is not configured. User needs to configure it first
            else
            {
               //if used LEAD Path then we run the PACS config demo otherwise the user is responsible to create the storage server
               if ( PathHelper.UseLeadPath () || PathHelper.UseNugetPath())
               {
                  DicomDemoSettingsManager.RunPacsConfigDemo ( ) ;
               }
               else
               {
                  Messager.ShowWarning ( this, "Storage Server is not created. Create the Storage Server then run this tool again." ) ;
               }

               //check one more time if server is created and configured after the warning messages and running the PACS Config
               _serverInfo =  StorageServerHelper.GetServerInformation ( ) ;

               //if it is not created yet we need to returns false and exist 
               if ( null == _serverInfo ) 
               {
                  Messager.ShowError ( this, "Storage Server is not created." ) ;

                  return false ;
               }
               else
               {
                  return ConfigureStorageServerInfo ( ) ;
               }
            }
         }
         else
         {
            //check if the database is configured, if not then run the database config
            if ( !StorageServerHelper.IsDatabaseConfigured ( ) )
            {
               if ( !RequestUserToConfigureDbSucess ( this ) ) 
               {
                  return false ;
               }
            }
            else
            {
               //check if database is upgraded and if not then ask user to upgrade
               if ( !RequestUserToUpgradeDbSucess ( this ) )
               {
                  return false ;
               }
            }

            //run the function again 
            return ConfigureStorageServerInfo ( ) ;
         }

         SetClientInfo ( ) ;

         return true ;
      }

      /// <summary>
      /// Check whether the connection infomration for the web viewer is set and update the status accordingely
      /// </summary>
      private void CheckWebViewerConnectionConfiguration ( ) 
      {
         bool isConfigured = StorageServerHelper.IsWebViewerConnectionConfigured  ( ) ;

         if ( !isConfigured ) 
         {
            SetWebViewerConnectionNotConfigured ( ) ;
         }
         else
         {
            SetWebViewerConnectionConfigured ( ) ;
         }
      }

      //private string GetMedical3dChacheFolder()
      //{
      //   string windowsTempFolder = Environment.ExpandEnvironmentVariables(@"%SystemRoot%\Temp");
      //   return Path.Combine(windowsTempFolder, "Medical3DCache" );
      //}

      /// <summary>
      /// Reads the information from the global PACS config and compare it with the configuration of the WCF service
      /// </summary>
      private bool CheckWebViewerServerConfiguration (string serviceConfigPath)
      {
         ExeConfigurationFileMap configMap = new ExeConfigurationFileMap();
         configMap.ExeConfigFilename = serviceConfigPath;

         Configuration config = ConfigurationManager.OpenMappedExeConfiguration(configMap, ConfigurationUserLevel.None);

         Configuration globalPacsConfig = DicomDemoSettingsManager.GetGlobalPacsConfiguration();
         string medical3dRendererPath = Path.GetDirectoryName(globalPacsConfig.FilePath);
         // string medical3dCache = GetMedical3dChacheFolder();
         bool isConfigured = false;
         string serverPath = GetServerServiceDirectory();

         isConfigured = config.AppSettings.Settings.KeyValueExists("ClientAe", _clientInfo.AE) &&
                         config.AppSettings.Settings.KeyValueExists("ClientIP", _clientInfo.IPAddress) &&
                         config.AppSettings.Settings.KeyValueExists("ClientPort", _clientInfo.Port.ToString()) &&
                         config.AppSettings.Settings.KeyValueExists("globalConfigPath", globalPacsConfig.FilePath) &&
                         config.AppSettings.Settings.KeyValueExists("Medical3D.RendererPath", medical3dRendererPath)
                         //&& config.AppSettings.Settings.KeyValueExists ( "Medical3DCache", medical3dCache)
                         ;
         if (_serverInfo != null)
         {
            isConfigured = isConfigured &&
                          config.AppSettings.Settings.KeyValueExists("ServerAe", _serverInfo.DicomServer.AE) &&
                           config.AppSettings.Settings.KeyValueExists("ServerIP", _serverInfo.DicomServer.IPAddress) &&
                           config.AppSettings.Settings.KeyValueExists("ServerPort", _serverInfo.DicomServer.Port.ToString());
         }



         if (PathHelper.UseExternalWebServicePath() == false)
         {
            isConfigured = isConfigured && config.AppSettings.Settings.KeyValueExists("storageServerServicePath", serverPath);
         }

         return isConfigured;
      }

      private void CheckWebViewerServerConfiguration()
      {
         string wcfPath = PathHelper.GetWcfServiceConfigPath();
         bool isConfigured = CheckWebViewerServerConfiguration(wcfPath);
         if (isConfigured && (!PathHelper.UseNugetPath() || PathHelper.UseNugetPathAndAspServiceIncluded()))
         {
            string aspPath = PathHelper.GetAspServiceConfigPath();
            isConfigured = CheckWebViewerServerConfiguration(aspPath);
         }
         if (isConfigured)
         {
            string webconfig = PathHelper.GetDICOMwebServiceConfigPath();
            if (!string.IsNullOrEmpty(webconfig) && File.Exists(webconfig))
            {
               isConfigured = CheckWebViewerServerConfiguration(webconfig);
            }
         }
         if (!isConfigured)
         {
            SetWebViewerNotConfigured();
         }
         else
         {
            SetWebViewerConfigured();
         }
      }

      /// <summary>
      /// Runs the database config (PACSDatabaseConfig) to create/configure the database
      /// </summary>
      /// <param name="owner"></param>
      /// <returns></returns>
      private static bool RequestUserToConfigureDbSucess ( IWin32Window owner ) 
      {
         
         string message;
         DialogResult result;
         string pacsDatabaseConfigurationDemoName = "PACS Database Configuration Wizard" ;
         string pacsDatabaseConfigDemoFileName ;
         
         
         if (PathHelper.UseNugetPath() || PathHelper.UseLeadPath() || PathHelper.UseExternalWebServicePath())
         {
            pacsDatabaseConfigDemoFileName = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "CSPacsDatabaseConfigurationDemo.exe");
            if (!File.Exists(pacsDatabaseConfigDemoFileName))
            {
               pacsDatabaseConfigDemoFileName = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "CSPacsDatabaseConfigurationDemo_Original.exe");
         }
         }
         else
         {
            string appSettingsPacsDatabaseConfigDemoFileName = ConfigurationManager.AppSettings["DbConfigExeName"];
            pacsDatabaseConfigDemoFileName = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), appSettingsPacsDatabaseConfigDemoFileName);
         }

         if (PathHelper.UseExternalWebServicePath())
         {
            // Do not prompt
            // Just run the pacsDatabaseConfigurationDemoName to connect to an existing database
            result = DialogResult.Yes;
         }
         else
         {
            message = 
               "The Storage Server Database is not configured:\n\nRun the " +
               pacsDatabaseConfigurationDemoName + " to configure the missing databases.\n\n" +
               "Do you want to run the " + pacsDatabaseConfigurationDemoName + " now?";

            result = Messager.ShowQuestion(owner,
                                 message,
                                 MessageBoxIcon.Warning,
                                 MessageBoxButtons.YesNo);
         }




         if (DialogResult.Yes == result)
         {

            if (File.Exists(pacsDatabaseConfigDemoFileName))
            {
               Process dbConfigProcess;


               dbConfigProcess = new Process();
               dbConfigProcess.StartInfo.FileName = pacsDatabaseConfigDemoFileName;

               dbConfigProcess.Start();

               dbConfigProcess.WaitForExit();

               //check if the user successfully configured the required database
               string[] productsToCheck = new string[] { DicomDemoSettingsManager.ProductNameStorageServer };

               bool isDbConfigured = StorageServerHelper.IsDatabaseConfigured ( ) ;

               if (!isDbConfigured)
               {
                  Messager.ShowError ( owner,
                                       "Database is not configured." );


                  return false;

               }
            }
            else
            {
               Messager.ShowError ( owner, "Could not find the " + pacsDatabaseConfigurationDemoName );

               return false;
            }
         }
         else
         {
            return false;
         }
         
         return true ;
      }
      
      /// <summary>
      /// ask the user to upgrade the database
      /// </summary>
      /// <param name="owner"></param>
      /// <returns></returns>
      private static bool RequestUserToUpgradeDbSucess ( IWin32Window owner ) 
      {
         string message;
         DialogResult result;
         string Caption = "Warning";

         message = "The Storage Server database needs to be upgraded.\n\n" + 
                   "Do you want to upgrade the database now?";

         result = MessageBox.Show ( owner,
                                    message,
                                    Caption,
                                    MessageBoxButtons.YesNo,
                                    MessageBoxIcon.Warning);

         if (DialogResult.Yes == result)
         {
            GlobalPacsUpdater.UpgradeProductDatabase ( DicomDemoSettingsManager.ProductNameStorageServer ) ;
            
            if ( GlobalPacsUpdater.IsProductDatabaseUpTodate(DicomDemoSettingsManager.ProductNameStorageServer) )
            {
               MessageBox.Show("Database upgraded successfully",
                                Caption,
                                MessageBoxButtons.OK,
                                 MessageBoxIcon.Information);
                              
               return true ;
            }
         }

         return false;
      }

      protected virtual void ConfigureWebViewer ( )
      {
         StorageServerHelper.ConfigureWebViewerDatabase ( ) ;
      }

      /// <summary>
      /// Runs the Service Manager Host tool to create the web viewer virtual directories
      /// </summary>
      private void RunIISConfig ( )
      {
         string exeName = "LeadtoolsServicesHostManager.exe" ;
         string origExeName = "LeadtoolsServicesHostManager_Original.exe" ;
         string path = Path.Combine ( Application.StartupPath, exeName ) ;

         if ( !File.Exists ( path ) )
         {
            path = Path.Combine ( Application.StartupPath, origExeName) ;

            if ( !File.Exists ( path ) )
            {
               Messager.ShowWarning ( this, "Couldn't find LEADTOOLS Service Host Manager utility. Virtual directories couldn't be configured." ) ;

               return ;
            }
         }

         //pass the .NET framework version numeber to the tool to limit the user option.
         //a requirment that needs to be added here is to pass the processor arch. x64 or win32
         string runtime = ( Environment.Version.Major == 4 ) ? "v4.0" : "v2.0" ;
#if LEADTOOLS_V19_OR_LATER
         ProcessStartInfo processInfo = new ProcessStartInfo(path, string.Format("/group:\"LEADTOOLS HTML5 Medical Web Viewer Framework (Version 19)\" /dotnetRuntimeVersion:\"{0}\"", runtime));
#else
            ProcessStartInfo processInfo = new ProcessStartInfo ( path, string.Format ( "/group:\"LEADTOOLS Web Viewer Framework\" /dotnetRuntimeVersion:\"{0}\"", runtime ) ) ;
#endif

         Process process = Process.Start(processInfo);

         process.WaitForExit();
      }

      /// <summary>
      /// Writes the configuration into the WCF service web.config from the server information
      /// </summary>
      private void ConfigureWebViewerServerInfo(string serviceConfigPath)
      {         
         ExeConfigurationFileMap configMap = new ExeConfigurationFileMap();
         configMap.ExeConfigFilename = serviceConfigPath;

         Configuration config = ConfigurationManager.OpenMappedExeConfiguration(configMap, ConfigurationUserLevel.None);
         Configuration globalPacsConfig = DicomDemoSettingsManager.GetGlobalPacsConfiguration();

         string serviceDir = GetServerServiceDirectory();
         string medical3dRendererPath = Path.GetDirectoryName(globalPacsConfig.FilePath);
         // string medical3dCache = GetMedical3dChacheFolder();

         //remove any includes
         config.AppSettings.File = null;

         config.AppSettings.Settings.Replace("ClientAe", _clientInfo.AE);
         config.AppSettings.Settings.Replace("ClientIP", _clientInfo.IPAddress);
         config.AppSettings.Settings.Replace("ClientPort", _clientInfo.Port.ToString());

         if (_serverInfo != null)
         {
            config.AppSettings.Settings.Replace("ServerAe", _serverInfo.DicomServer.AE);
            config.AppSettings.Settings.Replace("ServerIP", _serverInfo.DicomServer.IPAddress);
            config.AppSettings.Settings.Replace("ServerPort", _serverInfo.DicomServer.Port.ToString());
         }

         config.AppSettings.Settings.Replace("globalConfigPath", globalPacsConfig.FilePath);
         if (serviceDir != null)
         {
            config.AppSettings.Settings.Replace("storageServerServicePath", serviceDir);
         }

         config.AppSettings.Settings.Replace("Medical3D.RendererPath", medical3dRendererPath);
         // config.AppSettings.Settings.Replace("Medical3DCache", medical3dCache);
         config.Save(ConfigurationSaveMode.Minimal);

         if (!string.IsNullOrEmpty(serviceDir))
         {
            CopyAddins(serviceDir);
         }
      }

      private void ConfigureWebViewerServerInfo()
      {
         ConfigureWebViewerServerInfo(PathHelper.GetWcfServiceConfigPath());
         if (!PathHelper.UseNugetPath() || PathHelper.UseNugetPathAndAspServiceIncluded())
         {
            ConfigureWebViewerServerInfo(PathHelper.GetAspServiceConfigPath());
         }

         var webconfig = PathHelper.GetDICOMwebServiceConfigPath();
         if (!string.IsNullOrEmpty(webconfig) && File.Exists(webconfig))
         {
            ConfigureWebViewerServerInfo(webconfig);
         }
      }

      protected virtual void SetAdditionalAppSettings()
      {
         // do nothing for the LEAD version
      }

      /// <summary>
      /// returns the path to the storage server service directory. used to read config info
      /// </summary>
      /// <returns></returns>
      protected string GetServerServiceDirectory()
      {
         string serviceDir = string.Empty;
         if (_serverInfo != null)
         {
            using (ServiceAdministrator serviceAdmin = new ServiceAdministrator("", false))
            {
               List<string> services = new List<string>();
               services.Add(_serverInfo.ServiceName);

               serviceAdmin.LoadServices(services);

               if (serviceAdmin.Services.Count > 0)
               {
                  using (DicomService service = serviceAdmin.Services[_serverInfo.ServiceName])
                  {
                     serviceDir = service.ServiceDirectory;
                  }
               }
            }

         }

         return serviceDir;
      }

      protected static int GetVersion(string serviceBinDir)
      {
          int version = 0;

          try
          {
              string kernelPath = Path.Combine(serviceBinDir, "Leadtools.dll");
              FileVersionInfo fileVersionInfo = FileVersionInfo.GetVersionInfo(kernelPath);
              if (fileVersionInfo != null)
              {
                  version = fileVersionInfo.ProductMajorPart;
              }
          }
          catch (Exception)
          {
          }
          return version;
      }

      /// <summary>
      /// Copy required web viewer addins into the storage server
      /// </summary>
      /// <param name="serviceDir"></param>
      protected virtual void CopyAddins(string serviceDir)
      {
          string serverBinDir = Directory.GetParent(serviceDir).Parent.FullName;
          string addinDir = Path.Combine(serviceDir, "AddIns");
          string downloadAddinName = "Leadtools.Medical.WebViewer.ImageDownloadAddin.dll";
          string jobCleanupAddinName = "Leadtools.Medical.WebViewer.JobsCleanupAddin.dll";
          string downloadAddinDest = Path.Combine(addinDir, downloadAddinName);
          string jobCleanupDest = Path.Combine(addinDir, jobCleanupAddinName);

          string sourcePath = Application.StartupPath;
          int version = GetVersion(serverBinDir);
          switch (version)
          {
              case 18:
                  sourcePath = Path.Combine(Application.StartupPath, "v18");
                  break;

              default:
              case 19:
                  sourcePath = Application.StartupPath;
                  break;
          }

          if (!File.Exists(downloadAddinDest))
          {
              string src = Path.Combine(sourcePath, downloadAddinName);

              File.Copy(src, downloadAddinDest);
          }

          if (!File.Exists(jobCleanupDest))
          {
              string src = Path.Combine(sourcePath, jobCleanupAddinName);

              File.Copy(src, jobCleanupDest);
          }
      }

      /// <summary>
      /// reads the default LEAD client information
      /// </summary>
      private void SetClientInfo()
      {
          string clientDemo = "CSDicomHighlevelClientDemo_Original.exe";

          DicomDemoSettings settings = null;
          settings = DicomDemoSettingsManager.LoadSettings(clientDemo);

          if (null == settings)
          {
              _clientInfo = new DicomAE();

              _clientInfo.AE = "L175_CLIENT32";
              _clientInfo.IPAddress = GetDefaultIp();
              _clientInfo.Port = 1000;
          }
          else
          {
              _clientInfo = settings.ClientAe;
          }
      }

      private static void AddErrorStatus(params string[] list)
      {
          Logger.LogError(list);
      }

      private static void AddInfoStatus(params string[] list)
      {
          Logger.LogMessage(list);
      }

      protected void SetIIsConfigured()
      {
          _iisConfiugred = true;

          AddInfoStatus("IIS Virtual Directories configured.");
      }

      protected void SetIIsNotConfigured()
      {
          _iisConfiugred = false;

          AddErrorStatus("IIS Virtual Directories are not configured.");
      }

      private void SetDatabaseUpgraded()
      {
          _upgraded = true;

          AddInfoStatus("Storage Server database is upgraded.");
      }

      private void SetDatabaseNotUpgraded()
      {
          _upgraded = false;

          AddErrorStatus("Storage Server database needs to be upgraded with web viewer tables.");
      }

      private void SetWebViewerConnectionConfigured()
      {
          _connectionConfiugred = true;

          AddInfoStatus("Medical Web Viewer Database Connection is properly configured.");
      }

      private void SetWebViewerConnectionNotConfigured()
      {
          _connectionConfiugred = false;

          AddErrorStatus("Medical Web Viewer Database Connection is not configured.");
      }

      private void SetWebViewerConfigured()
      {
          _serverConfiugred = true;

          AddInfoStatus("Medical Web Viewer back-end PACS Server Information is properly configured.");
      }

      private void SetWebViewerNotConfigured()
      {
          _serverConfiugred = false;

          AddErrorStatus("Medical Web Viewer is not configured with server information.");
      }

      void Register_LeadtoolsMedical3DProxy()
      {
         string exeFolder = PathHelper.GetExePath();
         string comObjectPath = Path.Combine(exeFolder, "Leadtools.Medical3DProxy.exe");
         string message = string.Empty;
         string errorString = string.Empty;

         string args = string.Empty;
         if (silentRegister)
         {
            args = "/Silent /RegServer";
         }
         else
         {
            args = "/RegServer";
         }

         int exitCode = MyWindowsServiceController.Register(comObjectPath, args, out errorString);

         if (!silentRegister)
         {
            bool success = string.IsNullOrEmpty(errorString) && (exitCode == 0);
            if (success)
            {
               message = string.Format("Successfully registered '{0}'", comObjectPath);
               Logger.LogMessage(message);
            }
            else
            {
               message = string.Format("Failed to register '{0}': {1}", comObjectPath, errorString);
               Logger.LogError(message);
            }
         }

      }

      const string _serviceName = "LEAD Medical 3D Engine Proxy Service";

      void Stop_LeadtoolsMedical3DProxy()
      {
         string errorString = string.Empty;
         MyWindowsServiceController.Stop(_serviceName, out errorString);
         if (!string.IsNullOrEmpty(errorString))
         {
            Logger.LogError(errorString);
         }
      }

      void Delete_LeadtoolsMedical3DProxy()
      {
         string errorString = string.Empty;
         MyWindowsServiceController.Delete(_serviceName, out errorString);
         if (!string.IsNullOrEmpty(errorString))
         {
            Logger.LogError(errorString);
         }
      }

      void Start_LeadtoolsMedical3DProxy()
      {
         string errorString = string.Empty;
         MyWindowsServiceController.Start(_serviceName, out errorString);
         if (!string.IsNullOrEmpty(errorString))
         {
            Logger.LogError(errorString);
         }
      }

      void Stop_Delete_Register_Start_LeadtoolsMedical3DProxy()
      {
         // Stop_LeadtoolsMedical3DProxy();
         // Delete_LeadtoolsMedical3DProxy();
         Register_LeadtoolsMedical3DProxy();
         // Start_LeadtoolsMedical3DProxy();
      }

      /// <summary>
      /// Main method that checks what needs to be configured and fix it!
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      void btnFix_Click(object sender, EventArgs e)
      {
          Logger.Clear();
          IISTools.Initialize();

         if (PathHelper.UseExternalWebServicePath() || PathHelper.UseNugetPath())
         {
            Stop_Delete_Register_Start_LeadtoolsMedical3DProxy();
         }

         if (!_upgraded)
          {
              try
              {
                  StorageServerHelper.UpgradeDatabase();

                  SetDatabaseUpgraded();
              }
              catch (Exception ex)
              {
                  AddErrorStatus("Failed to upgrade database. " + ex.Message);
                  SetDatabaseNotUpgraded();
              }
          }
          else
          {
              SetDatabaseUpgraded();
          }

          if (!_connectionConfiugred)
          {
              try
              {
                  ConfigureWebViewer();

                  SetWebViewerConnectionConfigured();
              }
              catch (Exception ex)
              {
                  AddErrorStatus("Failed to configure Web Viewer. " + ex.Message);
                  _connectionConfiugred = false;
              }
          }
          else
          {
              SetWebViewerConnectionConfigured();
          }

         {
            if (!_serverConfiugred)
            {
               try
               {
                  ConfigureWebViewerServerInfo();
                  SetWebViewerConfigured();
               }
               catch (Exception ex)
               {
                  AddErrorStatus("Failed to configure Web Viewer. " + ex.Message);
                  SetWebViewerNotConfigured();
               }
            }
            else
            {
               SetWebViewerConfigured();
            }
         }
          

          if (!_iisConfiugred)
          {
              RunIISConfig();
          }

          CheckIISStatus();

          SetAdditionalAppSettings();

         _serviceType = ConfigWebClient.GetServiceType();
         UpdateServiceUI(_serviceType);

         UpdateUIState();
      }

      private void UpdateUIState()
      {
         btnFix.Enabled = !_upgraded || !_connectionConfiugred || !_serverConfiugred || !_iisConfiugred;
         btnRun.Enabled = (!btnFix.Enabled || _enableRunViewer) && !PathHelper.UseExternalWebServicePath();

         if (PathHelper.UseExternalWebServicePath())
         {
            optionsToolStripMenuItem.Visible = false;
         }
         else
         {
#if LEADTOOLS_V20_OR_LATER
            optionsToolStripMenuItem.Enabled = btnRun.Enabled;
#endif

#if LEADTOOLS_V19_OR_LATER
            radioButtonMedical.Enabled = btnRun.Enabled;
            radioButtonDental.Enabled = btnRun.Enabled;
#endif
         }
      }

#if LEADTOOLS_V19_OR_LATER
      private void ChangeOptions(Dictionary <string,string> options, string name)
      {
         try
         {
            Cursor = Cursors.WaitCursor;
            WebViewerDataAccess.OptionsAgent.SaveDefaultOptions(options);
         }
         catch (Exception ex)
         {
            Logger.LogError(string.Format("Setting {0} Options: Failure", name));
            Logger.LogMessage(ex.Message);
         }
         finally
         {
            Cursor = Cursors.Default;
            Logger.LogMessage(string.Format("Setting {0} Options: Success", name));

            foreach(KeyValuePair<string,string> kvp in options)
            {
               Logger.LogMessage(string.Empty, kvp.Key, kvp.Value);
            }
         }
      }
#endif // #if LEADTOOLS_V19_OR_LATER

      private void SetConfigValue(string setting, bool value)
      {
         System.Configuration.Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

         if (null == config.AppSettings.Settings[setting])
         {
            config.AppSettings.Settings.Add(setting, value.ToString());
         }

         if (null != config.AppSettings.Settings[setting])
         {
            config.AppSettings.Settings[setting].Value = value.ToString();
         }
         config.Save(ConfigurationSaveMode.Modified);
      }

      private bool GetConfigValue(string setting)
      {
         System.Configuration.Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
         string value = "False";
         
         if (config.AppSettings.Settings[setting] !=null)
            value = config.AppSettings.Settings[setting].Value;

         bool boolValue = false;

         if (bool.TryParse(value, out boolValue))
         {
            return boolValue;
         }
         else
         {
            return true;
         }
      }

      public bool DoNotShowDownloadImagesDialog
      {
         get
         {
            return GetConfigValue("DoNotShowDownloadDialog");
         }
         set
         {
            SetConfigValue("DoNotShowDownloadDialog", value);
         }
      }


      private void DisplayDownloadImagesDialog(bool alwaysDisplay)
      {
         bool oldValue_DoNotShowDownloadImagesDialog = DoNotShowDownloadImagesDialog;

         if (!oldValue_DoNotShowDownloadImagesDialog || alwaysDisplay)
         {
            using (ImagesDownloadDialog dialog = new ImagesDownloadDialog("Download 3D Images"))
            {
               dialog.TopMost = true;
               dialog.DoNotShowAgainCheckBox = oldValue_DoNotShowDownloadImagesDialog;
               dialog.VisibleCheckBox = !alwaysDisplay;
               dialog.ShowDialog();

               if (oldValue_DoNotShowDownloadImagesDialog != dialog.DoNotShowAgainCheckBox)
               {
                  DoNotShowDownloadImagesDialog = dialog.DoNotShowAgainCheckBox;
               }
            }
         }
      }

      private void btnRun_Click(object sender, EventArgs e)
      {
         //CheckIISStatus ( ) ;

         Logger.Clear();

         DisplayDownloadImagesDialog(false);

#if LEADTOOLS_V19_OR_LATER
         if (radioButtonMedical.Checked)
         {
            ChangeOptions(WebViewerDataAccess.MedicalOptions, "Medical");
         }
         else
         {
            ChangeOptions(WebViewerDataAccess.DentalOptions, "Dental");
         }
#endif //#if LEADTOOLS_V19_OR_LATER
         var uri = FindFirstWebappUri(_viewerDirectory);
         if (string.IsNullOrEmpty(uri))
         {
            MessageBox.Show(this, "Unexpected error trying to resolve application's uri", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
         }
         else
         {
            Process.Start(uri);
         }
      }

      static public string GetDefaultIp()
      {
         IPAddress[] addresses = Dns.GetHostAddresses ( System.Net.Dns.GetHostName ( ) ) ;
         
         if ( null != addresses )
         {
            foreach ( IPAddress address in addresses )
            {
               if ( address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork )
               {
                  return address.ToString ( ) ;
               }
            }
         }
         
         return "172.0.0.1" ;
      }

      StorageServerInformation _serverInfo ;
      DicomAE                  _clientInfo ;
      ConnectionStringSettings _connection ;

      public static string _viewerDirectory ;
      public static string _wcfServiceDirectory;
      public static string _aspServiceDirectory;
      public static string _dicomWebServiceDirectory;
      bool _upgraded = false ;
      bool _connectionConfiugred = false ;
      bool _serverConfiugred = false ;
      bool _iisConfiugred = false ;

      public static string _serviceUri2D;
      public static bool _useLocalService2D;

      public static string _serviceUri3D;
      public static bool _useLocalService3D;

      class ListItemInfo
      {
         public ListItemInfo ( string message, bool error )
         {
            Message = message ;
            Error = error ;
         }

         public string Message ;
         public bool Error ;
      }

      private void btnTroubleShooting_Click(object sender, EventArgs e)
      {
          MissingComponents.ShowTroubleShootingGuide("LeadtoolsServicesHostManagerTroubleshooting.html");
      }

      private void clearStatusToolStripMenuItem_Click(object sender, EventArgs e)
      {
         Logger.Clear();
      }


      protected void CheckButtonMedical()
      {
#if LEADTOOLS_V19_OR_LATER
         radioButtonMedical.Checked = true;
#endif
      }

      protected void CheckButtonDental()
      {
#if LEADTOOLS_V19_OR_LATER
         radioButtonDental.Checked = true;
#endif
      }


      protected virtual void SetUI_Defaults()
      {
         CheckButtonMedical();
      }

      private void upgradeDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
      {
         Logger.Clear();
         IISTools.Initialize();
         try
         {
            StorageServerHelper.UpgradeDatabase();
         }
         catch (Exception ex)
         {
            AddErrorStatus("Failed to upgrade database. " + ex.Message);
            SetDatabaseNotUpgraded();
         }
         Init();
      }

#if LEADTOOLS_V20_OR_LATER

      private void ChangeServiceType(ServiceType newServiceType)
      {
         ChangeServiceType(newServiceType, true);
      }
      private void ChangeServiceType(ServiceType newServiceType, bool showMessageBox)
      {
         if (_serviceType == newServiceType)
            return;

         _serviceType = newServiceType;

         ConfigWebClient._useLocalService3D = _useLocalService3D;
         ConfigWebClient._serviceUri3D = _serviceUri3D;

         string formatString = string.Empty;
         string message = string.Empty;

         if (ConfigWebClient.Config(newServiceType))
         {
            if (showMessageBox)
            {
               formatString = @"" +
                  "Web service changed successfully to {1}.{0}{0}" +
                  "Note that you must refresh the browser (F5) to activate the new web service.";
               message = string.Format(formatString, Environment.NewLine, newServiceType.MyToString());

               MessageBox.Show(message, @"Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

            UpdateServiceUI(newServiceType);

            if (showMessageBox)
            {
               Logger.Clear();
               Logger.LogMessageWithNewlines(message);
            }
         }
         else
         {
            if (showMessageBox)
            {
               formatString = @"Web service NOT changed to {0}";
               message = string.Format(formatString, newServiceType.MyToString());
               Logger.LogError(message);

               formatString = @"" +
                  "Web service NOT changed to {1}.{0}" +
                  "See the log window for more information.";

               message = string.Format(formatString, Environment.NewLine, newServiceType.MyToString());
               MessageBox.Show(message, @"Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
         }
      }

      private void UpdateServiceLocations()
      {
         ConfigWebClient._useLocalService3D = _useLocalService3D;
         ConfigWebClient._serviceUri3D = _serviceUri3D;

         ConfigWebClient._useLocalService2D = _useLocalService2D;
         ConfigWebClient._serviceUri2D = _serviceUri2D;

         string formatString = string.Empty;
         string message = string.Empty;
         if (ConfigWebClient.Config(_serviceType))
         {
            formatString = @"" +
               "Web Service locations successfully updated:{0}{0}" +
               "2D Service: {1}{0}" +
               "3D Service: {2}{0}{0}" +
               "Note that you must refresh the browser (F5) to activate the new web service";

            message = string.Format(formatString,
              Environment.NewLine,
              (_useLocalService2D ? "(local)" : _serviceUri2D),
              (_useLocalService3D ? "(local)" : _serviceUri3D));

            MessageBox.Show(message, @"Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Logger.Clear();
            Logger.LogMessageWithNewlines(message);
         }
         else
         {
            Logger.LogError("Web Service locations NOT updated");
            formatString = @"" +
               "Web Service locations NOT updated{0}" +
               "See the log window for more information.";
            message = string.Format(formatString, Environment.NewLine);
            MessageBox.Show(message, @"Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
         }
      }

      private void UpdateServiceUI(ServiceType serviceType)
      {
         switch(serviceType)
         {
            default:
            case ServiceType.None:
               useWCFServiceToolStripMenuItem.Checked = false;
               useASPNETServiceToolStripMenuItem.Checked = false;
               break;

            case ServiceType.Wcf:
               useWCFServiceToolStripMenuItem.Checked = true;
               useASPNETServiceToolStripMenuItem.Checked = false;
               break;

            case ServiceType.AspNet:
               useWCFServiceToolStripMenuItem.Checked = false;
               useASPNETServiceToolStripMenuItem.Checked = true;
               break;
         }
      }
#endif // #if LEADTOOLS_V20_OR_LATER
      private void useWCFServiceToolStripMenuItem_Click(object sender, EventArgs e)
      {
#if LEADTOOLS_V20_OR_LATER
        ChangeServiceType(ServiceType.Wcf);
#endif
      }

      private void useASPNETServiceToolStripMenuItem_Click(object sender, EventArgs e)
      {
#if LEADTOOLS_V20_OR_LATER
         ChangeServiceType(ServiceType.AspNet);
#endif
      }

      ServiceType _serviceType = ServiceType.None;

      bool _enableRunViewer = false;

      private void enableRunViewerToolStripMenuItem_Click(object sender, EventArgs e)
      {
         if (_enableRunViewer)
         {
            enableRunViewerToolStripMenuItem.Text = "Enable 'Run Viewer'";
            _enableRunViewer = false;
         }
         else
         {
            enableRunViewerToolStripMenuItem.Text = "Disable 'Run Viewer'";
            _enableRunViewer = true;
         }
         UpdateUIState();
      }

      private void changeServiceLocationToolStripMenuItem_Click(object sender, EventArgs e)
      {
         try
         {
               WebServiceLocationDialog config = new WebServiceLocationDialog();

            config.UseLocal2D = _useLocalService2D;
            config.RemoteService2D = _serviceUri2D;

            config.UseLocal3D = _useLocalService3D;
            config.RemoteService3D = _serviceUri3D;

            if (config.ShowDialog() == DialogResult.OK)
            {
               _useLocalService2D = config.UseLocal2D;
               _serviceUri2D = config.RemoteService2D;

               _useLocalService3D = config.UseLocal3D;
               _serviceUri3D = config.RemoteService3D;

               UpdateServiceLocations();
            }
         }
         catch(Exception ex)
         {
            MessageBox.Show(this, ex.Message, "Error", MessageBoxButtons.OK,MessageBoxIcon.Error);
         }
      }

      private void SaveSetting(KeyValueConfigurationCollection settings, string settingName, string settingValue)
      {
         if (settings[settingName] == null)
         {
            settings.Add(settingName, settingValue);
         }
         else
         {
            settings[settingName].Value = settingValue;
         }
      }

      private void Form1_FormClosing(object sender, FormClosingEventArgs e)
      {
         try
         {
            var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            var settings = configFile.AppSettings.Settings;

            SaveSetting(settings, "ServiceUri2D", _serviceUri2D);
            SaveSetting(settings, "UseLocalService2D", _useLocalService2D.ToString());

            SaveSetting(settings, "ServiceUri3D", _serviceUri3D);
            SaveSetting(settings, "UseLocalService3D", _useLocalService3D.ToString());

            configFile.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection(configFile.AppSettings.SectionInformation.Name);
         }
         catch
         {
         }
      }

      string _zipPath = Path.Combine(WebServiceInstaller.RootPath, WebServiceInstaller.DefaultZipName);
      public string ZipPath
      {
         get
         {
            return _zipPath;
         }
         set
         {
            _zipPath = value;
         }
      }

      private void create3DServiceInstallerToolStripMenuItem_Click(object sender, EventArgs e)
      {
         WebServiceInstallerDialog dialog = new WebServiceInstallerDialog();
         dialog.ZipPath = ZipPath;
         if (DialogResult.OK == dialog.ShowDialog())
         {
            ZipPath = dialog.ZipPath;
            WebServiceInstaller.CreateInstaller(dialog.ZipPath);

            WebServiceInstallerResultDialog dialogNotify = new WebServiceInstallerResultDialog();
            dialogNotify.Configure3DServiceToolStripMenuItemText = this.configure3DServiceToolStripMenuItem.Text;
            dialogNotify.InstallerLocation = ZipPath;
            dialogNotify.ShowDialog();
         }
      }

      int mouseClickCounter = 0;
      private void Form1_MouseClick(object sender, MouseEventArgs e)
      {
         mouseClickCounter++;
         if (mouseClickCounter > 10)
         {
            fileToolStripMenuItem.Visible = true;
            optionsToolStripMenuItem.Visible = true;

            ShowExtraOptions(true);

            fileToolStripMenuItem.Enabled = true;
            optionsToolStripMenuItem.Enabled = true;
         }
      }

      private void download3DImagesToolStripMenuItem_Click(object sender, EventArgs e)
      {
         DisplayDownloadImagesDialog(true);
      }

      bool silentRegister = true;
      private void silentRegisterToolStripMenuItem_Click(object sender, EventArgs e)
      {
         silentRegister = !silentRegister;
         silentRegisterToolStripMenuItem.Checked = silentRegister;
      }

      private void registerLeadtoolsMedical3DProxyexeToolStripMenuItem_Click(object sender, EventArgs e)
      {
         Register_LeadtoolsMedical3DProxy();
         Logger.LogMessage();
      }

      private void startLeadtoolsMedical3DProxyexeToolStripMenuItem_Click(object sender, EventArgs e)
      {
         Start_LeadtoolsMedical3DProxy();
         Logger.LogMessage("Start Leadtools.Medical3DProxy.exe");
      }

      private void stopLeadtoolsMedical3DProxyexeToolStripMenuItem_Click(object sender, EventArgs e)
      {
         Stop_LeadtoolsMedical3DProxy();
         Logger.LogMessage("Stop Leadtools.Medical3DProxy.exe");
      }

      private void deleteLeadtoolsMedical3DProxyexeToolStripMenuItem_Click(object sender, EventArgs e)
      {
         Delete_LeadtoolsMedical3DProxy();
         Logger.LogMessage("Delete Leadtools.Medical3DProxy.exe");
      }

      private void installLeadtoolsMedical3DProxyexeToolStripMenuItem_Click(object sender, EventArgs e)
      {
         Stop_Delete_Register_Start_LeadtoolsMedical3DProxy();
         Logger.LogMessage("Install Leadtools.Medical3DProxy.exe");
      }
   }

   public enum ServiceType
   {
      None,
      Wcf,
      AspNet
   }

   static class ConfigurationExtensions
   {
      public static void Replace ( this KeyValueConfigurationCollection settings, string key, string value )
      {
         if ( settings [ key ] != null ) 
         {
            settings.Remove ( key ) ;
         }

         settings.Add ( key, value ) ;
      }
      public static bool KeyValueExists ( this KeyValueConfigurationCollection settings, string key, string value )
      {
         if ( settings [ key ] != null ) 
         {
            return string.Compare ( settings [ key  ].Value, value, true ) == 0 ;
         }

         return false ;
      }

      public static string MyToString(this ServiceType serviceType)
      {
         string result;
         switch(serviceType)
         {
            default:
            case ServiceType.None:
               result = @"None";
               break;
            case ServiceType.Wcf:
               result = @"WCF";
               break;
            case ServiceType.AspNet:
               result = @"ASP.NET";
               break;
         }
         return result;
      }

      public static bool Contains(this string source, string toCheck, StringComparison comp)
      {
         return source.IndexOf(toCheck, comp) >= 0;
      }
   }

   public static class Logger
   {
    public enum StatusType
      {
         Check = 0,
         Warning = 1,
         Error = 2,
         Nothing = 3
      }

      public static ListView ListViewLog { get; set; }

      public static void AddItemWithIcon(StatusType status, params string[]list)
      {
         if (list.Length == 0)
            return;

         Color color = Color.Blue;
         switch (status)
         {
            case StatusType.Nothing:
            case StatusType.Check:
               color = Color.Blue;
               break;
            case StatusType.Warning:
               color = Color.Blue;
               break;
            case StatusType.Error:
               color = Color.Red;
               break;
         }
         ListViewItem li = new ListViewItem(list[0].Trim(), (int)status);
         ListViewLog.Items.Add(li);
         li.ForeColor = color;

         for (int i = 1; i<list.Length; i++)
         {
            string s = list[i].Trim();
            li.SubItems.Add(s);
         }
         ListViewLog.Items[ListViewLog.Items.Count - 1].EnsureVisible();
         ListViewLog.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
      }

      private static void Log(StatusType statusType, params string[] list)
      {
         try
         {
            AddItemWithIcon(statusType, list);
            Application.DoEvents();
         }
         catch (Exception)
         {
         }
      }

      public static void LogError(params string[] list)
      {
         Log(StatusType.Error, list);
      }

      public static void LogWarning(params string[] list)
      {
         Log(StatusType.Warning, list);
      }

      public static void LogMessage(params string[] list)
      {
         Log(StatusType.Nothing, list);
      }

      public static void LogMessageWithNewlines(string message)
      {
         string []messages = message.Split(new string[] { Environment.NewLine}, StringSplitOptions.None);
         foreach(string s in messages)
         {
            LogMessage(s);
         }
      }

      public static void LogWarningWithNewlines(string message)
      {
         string[] messages = message.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
         foreach (string s in messages)
         {
            LogWarning(s);
         }
      }

      public static void Clear()
      {
         if (ListViewLog != null)
         {
            ListViewLog.Items.Clear();
         }
      }
   }

#if LEADTOOLS_V20_OR_LATER
   static class ConfigWebClient
   {
      public static string config_ts_wcf
      {
         get
         {
            if (PathHelper.UseMedicorPath())
            {
               return string.Format(_config_ts_wcf, "/MiMedicalViewerServiceWcf/", "Medicor Imaging", "Medicor Medical Web Viewer", GetServiceLocation(ServiceCategory.Service3D, ServiceType.Wcf), GetServiceLocation(ServiceCategory.Service2D, ServiceType.Wcf));
            }
            else
            {
               // LEAD or NUGET
               return string.Format(_config_ts_wcf, "/MedicalViewerServiceWcf20/", "LEAD Technologies, Inc.", "LEADTOOLS Medical Web Viewer", GetServiceLocation(ServiceCategory.Service3D, ServiceType.Wcf), GetServiceLocation(ServiceCategory.Service2D, ServiceType.Wcf));
            }
         }
      }

      public static string config_js_wcf
      {
         get
         {
            if (PathHelper.UseMedicorPath())
            {
               return string.Format(_config_js_wcf, "/MiMedicalViewerServiceWcf/", "Medicor Imaging", "Medicor Medical Web Viewer", GetServiceLocation(ServiceCategory.Service3D, ServiceType.Wcf), GetServiceLocation(ServiceCategory.Service2D, ServiceType.Wcf));
            }
            else
            {
               // LEAD or NUGET
               return string.Format(_config_js_wcf, "/MedicalViewerServiceWcf20/", "LEAD Technologies, Inc.", "LEADTOOLS Medical Web Viewer", GetServiceLocation(ServiceCategory.Service3D, ServiceType.Wcf), GetServiceLocation(ServiceCategory.Service2D, ServiceType.Wcf));
            }
         }
      }

      public static string configTsAsp
      {
         get
         {
            if (PathHelper.UseMedicorPath())
            {
               return string.Format(_config_ts_asp, "/MiMedicalViewerServiceAsp/", "Medicor Imaging", "Medicor Medical Web Viewer", GetServiceLocation(ServiceCategory.Service3D, ServiceType.AspNet), GetServiceLocation(ServiceCategory.Service2D, ServiceType.AspNet));
            }
            else
            {
               // LEAD or NUGET
               return string.Format(_config_ts_asp, "/MedicalViewerServiceAsp20/", "LEAD Technologies, Inc.", "LEADTOOLS Medical Web Viewer", GetServiceLocation(ServiceCategory.Service3D, ServiceType.AspNet), GetServiceLocation(ServiceCategory.Service2D, ServiceType.AspNet));
            }
         }
      }

      public static string configJsAsp
      {
         get
         {
            if (PathHelper.UseMedicorPath())
            {
               return string.Format(_config_js_asp, "/MiMedicalViewerServiceAsp/api/", "Medicor Imaging", "Medicor Medical Web Viewer", GetServiceLocation(ServiceCategory.Service3D, ServiceType.AspNet), GetServiceLocation(ServiceCategory.Service2D, ServiceType.AspNet), GetServiceLocation(ServiceCategory.ServiceIdP, ServiceType.AspNet), "true"); 
            }
            else
            {
               // LEAD or NUGET
               return string.Format(_config_js_asp, "/MedicalViewerServiceAsp20/api/", "LEAD Technologies, Inc.", "LEADTOOLS Medical Web Viewer", GetServiceLocation(ServiceCategory.Service3D, ServiceType.AspNet), GetServiceLocation(ServiceCategory.Service2D, ServiceType.AspNet), GetServiceLocation(ServiceCategory.ServiceIdP, ServiceType.AspNet), "true");
            }
         }
      }

      public enum ServiceCategory
      {
         Service2D,
         Service3D,
         ServiceIdP,
      }

      private static string GetServiceLocation(ServiceCategory serviceCategory, ServiceType serviceType )
      {
         string location = string.Empty;

         bool useLocalService = true;
         string serviceUri = string.Empty;

         switch(serviceCategory)
         {
            case ServiceCategory.Service2D:
               useLocalService = _useLocalService2D;
               serviceUri = _serviceUri2D;
               break;
            
            case ServiceCategory.Service3D:
               useLocalService = _useLocalService3D;
               serviceUri = _serviceUri3D;
               break;

            case ServiceCategory.ServiceIdP:
               useLocalService = true;
               serviceUri = "";
               break;
         }

         string url = string.Empty;
         if (!useLocalService && !string.IsNullOrEmpty(serviceUri))
         {
            if (serviceType == ServiceType.AspNet)
            {
               if (PathHelper.UseMedicorPath())
               {
                  url = serviceUri + "/MiMedicalViewerServiceAsp/api/";
               }
               else
               {
                  // LEAD or NUGET
                  url = serviceUri + "/MedicalViewerServiceAsp20/api/";
               }
            }
            else
            {
               if (PathHelper.UseMedicorPath())
               {
                  url = serviceUri + "/MiMedicalViewerServiceWcf/";
               }
               else
               {
                  // LEAD or NUGET
                  url = serviceUri + "/MedicalViewerServiceWcf20/";
               }
            }
            // Embed string in quotes
            url =  string.Format("\"{0}\"", url);
         }
         else
         {
            string localRoot = "document.location.protocol + \"//\" + document.location.host + ";
            if (serviceType == ServiceType.AspNet)
            {
               if (serviceCategory == ServiceCategory.ServiceIdP)
               {
                  if (PathHelper.UseMedicorPath())
                  {
                     url = string.Format("{0}\"{1}\"", localRoot, "/MiMedicalViewerIdP/");
                  }
                  else
                  {
                     // LEAD or NUGET
                     url = string.Format("{0}\"{1}\"", localRoot, "/MedicalViewerIdPLink/");
                  }
               }
               else
               {
                  if (PathHelper.UseMedicorPath())
                  {
                     url = string.Format("{0}\"{1}\"", localRoot, "/MiMedicalViewerServiceAsp/api/");
                  }
                  else
                  {
                     // LEAD or NUGET
                     url = string.Format("{0}\"{1}\"", localRoot, "/MedicalViewerServiceAsp20/api/");
                  }
               }
            }
            else
            {
               if (PathHelper.UseMedicorPath())
               {
                  url = string.Format("{0}\"{1}\"", localRoot, "/MiMedicalViewerServiceWcf/");
               }
               else
               {
                  // LEAD or NUGET
                  url = string.Format("{0}\"{1}\"", localRoot, "/MedicalViewerServiceWcf20/");
               }
            }
         }

         return url;
      }

      public static bool _useLocalService2D = true;
      public static string _serviceUri2D = string.Empty;

      public static bool _useLocalService3D = true;
      public static string _serviceUri3D = string.Empty;

      const string _config_ts_wcf = @"/// <reference path=""../lib/angular/angular.d.ts"" />

app.constant(""app.config"", {{
    urls: {{
        serviceUrl: {4},
        threeDserviceUrl: {3},
        authenticationServiceName: ""AuthenticationService.svc"",
        queryLocalServiceName: ""ObjectQueryService.svc"",
        queryPacsServiceName: ""PacsQueryService.svc"",
        optionsServiceName: ""OptionsService.svc"",
        objectRetrieveLocalServiceName: ""ObjectRetrieveService.svc"",
        pacsRetrieveServiceName: ""PACSRetrieveService.svc"",
        objectStoreLocalServiceName: ""StoreService.svc"",
        monitorCalibrationServiceName: ""MonitorCalibrationService.svc"",
        exportServiceName: ""ExportService.svc"",
        auditLogServiceName: ""AuditLogService.svc"",
        patientServiceName: ""PatientService.svc"",
        patientAccessRightsServiceName: ""PatientAccessRightsService.svc"",
        templateServiceName: ""TemplateService.svc"",
        threeDServiceName: ""ThreeDService.svc""
    }},
    copyright: ""Copyright "" + new Date().getFullYear() + "" - {1}"",
    title: ""{2}""
}});
";

      const string _config_js_wcf = @"/// <reference path=""../lib/angular/angular.d.ts"" />
app.constant(""app.config"", {{
    urls: {{
        serviceUrl: {4},
        threeDserviceUrl: {3},
        authenticationServiceName: ""AuthenticationService.svc"",
        queryLocalServiceName: ""ObjectQueryService.svc"",
        queryPacsServiceName: ""PacsQueryService.svc"",
        optionsServiceName: ""OptionsService.svc"",
        objectRetrieveLocalServiceName: ""ObjectRetrieveService.svc"",
        pacsRetrieveServiceName: ""PACSRetrieveService.svc"",
        objectStoreLocalServiceName: ""StoreService.svc"",
        monitorCalibrationServiceName: ""MonitorCalibrationService.svc"",
        exportServiceName: ""ExportService.svc"",
        auditLogServiceName: ""AuditLogService.svc"",
        patientServiceName: ""PatientService.svc"",
        patientAccessRightsServiceName: ""PatientAccessRightsService.svc"",
        templateServiceName: ""TemplateService.svc"",
        threeDServiceName: ""ThreeDService.svc""
    }},
    copyright: ""Copyright "" + new Date().getFullYear() + "" - {1}"",
    title: ""{2}"",
    defaultUserName: """",
    defaultPassword: """",
    runAsEval: true
}});
//# sourceMappingURL=config.js.map
";

      const string _config_ts_asp = @"/// <reference path=""../lib/angular/angular.d.ts"" />

app.constant(""app.config"", {{
    urls: {{
        serviceUrl: {4},
        threeDserviceUrl: {3},
        authenticationServiceName: ""auth"",
        queryLocalServiceName: ""query"",
        queryPacsServiceName: ""pacsquery"",
        optionsServiceName: ""options"",
        objectRetrieveLocalServiceName: ""retrieve"",
        pacsRetrieveServiceName: ""pacsretrieve"",
        objectStoreLocalServiceName: ""store"",
        monitorCalibrationServiceName: ""monitorcalibration"",
        exportServiceName: ""export"",
        auditLogServiceName: ""audit"",
        patientServiceName: ""patient"",
        patientAccessRightsServiceName: ""patientaccessrights"",
        templateServiceName: ""template"",
        autoServiceName: ""auto"",
        threeDServiceName: ""threed""
    }},
    copyright: ""Copyright "" + new Date().getFullYear() + "" - {1}"",
    title: ""{2}""
}});
";

      const string _config_js_asp = @"/// <reference path=""../lib/angular/angular.d.ts"" />
app.constant(""app.config"", {{
    urls: {{
        serviceUrl: {4},
        threeDserviceUrl: {3},
        idpServiceUrl: {5},
        authenticationServiceName: ""auth"",
        queryLocalServiceName: ""query"",
        queryPacsServiceName: ""pacsquery"",
        optionsServiceName: ""options"",
        objectRetrieveLocalServiceName: ""retrieve"",
        pacsRetrieveServiceName: ""pacsretrieve"",
        objectStoreLocalServiceName: ""store"",
        monitorCalibrationServiceName: ""monitorcalibration"",
        exportServiceName: ""export"",
        auditLogServiceName: ""audit"",
        patientServiceName: ""patient"",
        patientAccessRightsServiceName: ""patientaccessrights"",
        templateServiceName: ""template"",
        autoServiceName: ""auto"",
        threeDServiceName: ""threed""
    }},
    copyright: ""Copyright "" + new Date().getFullYear() + "" - {1}"",
    title: ""{2}"",
    defaultUserName: """",
    defaultPassword: """",
    runAsEval: {6}
}});
//# sourceMappingURL=config.js.map
";

      private static string _viewerDirectory;

      public static bool RemoveReadOnlyIfFileExists(string path)
      {
         bool success = true;

         try
         {
            if (File.Exists(path))
            {
               var attr = File.GetAttributes(path);
               if ((attr & FileAttributes.ReadOnly) == FileAttributes.ReadOnly)
               {
                  // unset read-only
                  attr = attr & ~FileAttributes.ReadOnly;
                  File.SetAttributes(path, attr);
               }
            }
            return true;
         }
         catch (Exception)
         {
            success = false;
         }
         return success;
      }

      public static bool Config(ServiceType serviceType)
      {
         bool success = true;
         try
         {
            string viewerConfigPath = GetViewerConfigPath();
            FileInfo fileInfo = new System.IO.FileInfo(viewerConfigPath);
            fileInfo.IsReadOnly = false;

            RemoveReadOnlyIfFileExists(Path.ChangeExtension(viewerConfigPath, "ts"));
            RemoveReadOnlyIfFileExists(Path.ChangeExtension(viewerConfigPath, "js"));

            if (serviceType == ServiceType.AspNet)
            {
               if (!PathHelper.UseMedicorPath())
               {
                  File.WriteAllText(Path.ChangeExtension(viewerConfigPath, "ts"), configTsAsp);
               }
               File.WriteAllText(Path.ChangeExtension(viewerConfigPath, "js"), configJsAsp);
            }
            else
            {
               if (!PathHelper.UseMedicorPath())
               {
                  File.WriteAllText(Path.ChangeExtension(viewerConfigPath, "ts"), config_ts_wcf);
               }
               File.WriteAllText(Path.ChangeExtension(viewerConfigPath, "js"), config_js_wcf);
            }
         }
         catch (Exception ex)
         {
            Logger.LogError(ex.Message);
            success = false;
         }
         return success;
      }
      public static ServiceType GetServiceType()
      {
         string viewerConfigPath = GetViewerConfigPath(); 
         if (File.Exists(viewerConfigPath))
         {
            if (File.ReadAllText(Path.ChangeExtension(viewerConfigPath, "js")).Contains("MedicalViewerServiceAsp"))
               return ServiceType.AspNet;
         }
         return ServiceType.Wcf;
      }

      public static string GetViewerConfigPath()
      {
         string returnPath = @"";

         if (PathHelper.UseNugetPath())
         {
            string exePath = PathHelper.GetExePath();
            string nugetPath = Path.Combine(exePath, @"..\MedicalWebViewer\JS\MedicalWebViewerDemo\scripts\config.js");
            if (!File.Exists(nugetPath))
            {
               nugetPath = Path.Combine(exePath, @"..\..\MedicalWebViewer\JS\MedicalWebViewerDemo\scripts\config.js");
            }
            if (File.Exists(nugetPath))
            {
               return nugetPath;
            }
         }

         IISTools.VirtualDirectory viewerVirtualDir = IISTools.VirtualDirectory.Find(Environment.MachineName, _viewerDirectory);
         if (viewerVirtualDir != null)
         {
            returnPath = Path.Combine(viewerVirtualDir.Path, @"scripts", @"config.js");
         }
         return returnPath;
      }

      public static void SetViewerDirectory(string viewerDirectory)
      {
         _viewerDirectory = viewerDirectory;
      }
   }
#endif // #if LEADTOOLS_V20_OR_LATER
}

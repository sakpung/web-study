// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Diagnostics;
using System.Xml;
using System.Xml.XPath;
using System.Runtime.InteropServices;
using Leadtools.Demos;
using System.Data.SqlClient;
using JobProcessorServerConfigDemo.Properties;
using System.Configuration;
using System.Management;
using System.Security.AccessControl;
using System.Security.Principal;
using Leadtools.Common.JobProcessor;

namespace JobProcessorServerConfigDemo
{
   // This code shows how to create an application pool and a virtual directory from a C# application
   // It is not required by the LEADTOOLS JobProcessor services. It is only used by our demos to make the
   // the LEADTOOLS installation simpler
   public partial class MainForm : Form
   {
      private Prerequisites _prerequisites;
      private string _connectionString;

      public MainForm()
      {
         InitializeComponent();
      }

      protected override void OnLoad(EventArgs e)
      {
         Text = Globals.Title;

         // Setup the UI variables
         _machineTextBox.Text = Globals.Machine;
         _iisVersionTextBox.Text = Globals.IISVersion;

         if(Globals.IISMajorVersionNumber >= 6)
            _appPoolNameTextBox.Text = Globals.AppPoolName;
         else
            _appPoolNameTextBox.Text = "Not supported in this version of IIS";

         _virtualDirNameTextBox.Text = Globals.VirtualDirName;
         _virtualDirPathTextBox.Text = Globals.VirtualDirPath;
         _sourceCodeTextBox.Text = Globals.SourceCodeDir;

         try
         {
            // Read the XML file to get the data required for the setup
            _prerequisites = new Prerequisites();

            // If this is an XP 64-bit machine, we cannot use the x86 assemblies
            // This is due to the lack of the [enable32BitAppOnWin64] flag. You can
            // run the following script manually to achieve this:
            // CScript %SYSTEMDRIVE%\WINDOWS\system32\iisext.vbs /EnFile "%SYSTEMDRIVE%\WINDOWS\Microsoft.NET\Framework\v2.0.50727\aspnet_isapi.dll"

            bool isXP64 = CheckXP64Machine();

            if(!isXP64)
            {
               _x86RadioButton.Enabled = Globals.X86Ok;
               _x64RadioButton.Enabled = Globals.X64Ok && Globals.Is64BitOS;

               if(_x86RadioButton.Enabled)
                  _x86RadioButton.Checked = true;
               else
                  _x64RadioButton.Checked = true;
            }
            else
            {
               if(!Globals.X64Ok)
                  throw new Exception("Could not find the LEADTOOLS x64 assemblies. This program cannot setup the LEADTOOLS JobProcessor Components on a Windows XP 64-bit machine using the x86 assemblies only.");

               _x86RadioButton.Enabled = false;
               _x64RadioButton.Checked = true;
            }

            if(Globals.IISMajorVersionNumber < 7 || !Globals.IsDotNet4Installed)
            {
               _useDotNet4AssembliesCheckBox.Checked = false;
               _useDotNet4AssembliesCheckBox.Enabled = false;
               _useDotNet4AssembliesCheckBox.Text = _useDotNet4AssembliesCheckBox.Text + " - Available only if .NET 4 and IIS 7 are installed";
            }

            if(!Globals.IsDotNet35Installed)
            {
               // If .NET 3.5 is not installed, we must use .NET 4
               _useDotNet4AssembliesCheckBox.Checked = true;
               _useDotNet4AssembliesCheckBox.Enabled = false;
               _useDotNet4AssembliesCheckBox.Text = _useDotNet4AssembliesCheckBox.Text + " - Available only if .NET 3.5 and .NET 4 are both installed";
            }

#if LEADTOOLS_V18_OR_LATER
            if (Globals.IsDotNet4Installed)
            {
               _useDotNet4AssembliesCheckBox.Checked = true;
            }
#endif // #if LEADTOOLS_V18_OR_LATER

            // Add the services to the rich text box
            ShowServicesStatus();

            _connectionString = FindConnectionString();
            if(!String.IsNullOrEmpty(_connectionString))
            {
               try
               {
                  if(SqlUtilities.IsDatabaseExist(_connectionString))
                  {
                     SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder(_connectionString);

                     _lstvwDatabases.Items.Clear();
                     _lstvwDatabases.Items.Add(new ListViewItem(new string[] { "Server", sqlConnectionStringBuilder.DataSource }));
                     _lstvwDatabases.Items.Add(new ListViewItem(new string[] { "Database", sqlConnectionStringBuilder.InitialCatalog }));
                     if(!sqlConnectionStringBuilder.IntegratedSecurity)
                        _lstvwDatabases.Items.Add(new ListViewItem(new string[] { "User Id", sqlConnectionStringBuilder.UserID }));
                     else
                        _lstvwDatabases.Items.Add(new ListViewItem(new string[] { "User Id", "Trusted Connection" }));
                  }
               }
               catch(Exception ex)
               {
                  ShowErrorMessage(ex);
               }
            }
            _connectionString = FindConnectionString();
            if (!String.IsNullOrEmpty(_connectionString))
            {
               if (SqlUtilities.IsDatabaseExist(_connectionString))
               {
                  SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder(_connectionString);

                  _lstvwDatabases.Items.Clear();
                  _lstvwDatabases.Items.Add(new ListViewItem(new string[] { "Server", sqlConnectionStringBuilder.DataSource }));
                  _lstvwDatabases.Items.Add(new ListViewItem(new string[] { "Database", sqlConnectionStringBuilder.InitialCatalog }));
                  if (!sqlConnectionStringBuilder.IntegratedSecurity)
                     _lstvwDatabases.Items.Add(new ListViewItem(new string[] { "User Id", sqlConnectionStringBuilder.UserID }));
                  else
                     _lstvwDatabases.Items.Add(new ListViewItem(new string[] { "User Id", "Trusted Connection" }));
               }
            }
         }
         catch(Exception ex)
         {
            ShowErrorMessage(ex);
            Globals.ShowTroubleShootingFile();
         }

         base.OnLoad(e);
      }

      private void ShowServicesStatus()
      {
         _JobProcessorComponentsRichTextBox.Clear();

         foreach(LeadtoolsService ls in _prerequisites.Services)
         {
            AddText("Service: ", Color.Black, false);
            AddText(ls.Title + Environment.NewLine, Color.Blue, false);
            string url = ls.GetUrl();
            AddText("URL: ", Color.Black, false);
            AddText(url + Environment.NewLine, Color.Black, false);
            AddText("Status: ", Color.Black, false);

            if(ls.Tested)
            {
               if(ls.Error != null)
                  AddText("Error: " + ls.Error, Color.Red, true);
               else
                  AddText("Success", Color.Blue, true);
            }
            else
               AddText("Not tested yet", Color.Blue, false);

            AddText(Environment.NewLine, Color.Black, false);
            AddText(Environment.NewLine, Color.Black, false);
         }
      }

      private static bool CheckXPMachine()
      {
         OperatingSystem os = Environment.OSVersion;
         if (os.Platform == PlatformID.Win32NT &&   // NT
            os.Version.Major == 5 &&               // 2000/XP/2003
            os.Version.Minor == 1)               // XP
         {
            return true;
         }
         else
            return false;
      }

      private static bool CheckXP64Machine()
      {
         OperatingSystem os = Environment.OSVersion;
         if(os.Platform == PlatformID.Win32NT &&   // NT
            os.Version.Major == 5 &&               // 2000/XP/2003
            os.Version.Minor == 1 &&               // XP
            Globals.Is64BitOS)                     // 64-bit
         {
            return true;
         }
         else
            return false;
      }

      private void _testButton_Click(object sender, EventArgs e)
      {
         this.Cursor = Cursors.WaitCursor;

         try
         {
            // Test a connection to all the URLs
            foreach(LeadtoolsService ls in _prerequisites.Services)
            {
               ls.Tested = true;
               string url = ls.GetUrl();

               if(String.Compare("Service", ls.Type, false) == 0)
                  url = ls.GetUrl() + "?wsdl";

               HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
               request.Timeout = 180000;

               try
               {
                  TestService(ls.Name, ls.GetUrl());
                  ls.Error = null;
               }
               catch(Exception ex)
               {
                  ls.Error = ex.Message;
               }
            }


         }
         finally
         {
            ShowServicesStatus();
            this.Cursor = Cursors.Default;
         }
      }

      private static void TestService(string name, string url)
      {
         // Check if we can access it through the URL
         CanReachThroughHttp(url);

         // Now check if it is a service
         if(name.Contains(".svc"))
            CheckJobProcessorService(name, url);
      }

      private static void CanReachThroughHttp(string url)
      {
         // First check if it is reachable through HTTP
         HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
         request.Timeout = 180000;

         using(HttpWebResponse response = request.GetResponse() as HttpWebResponse)
         {
            using(StreamReader reader = new StreamReader(response.GetResponseStream()))
            {
               string str = reader.ReadToEnd();
            }
         }
      }

      private static void CheckJobProcessorService(string name, string url)
      {
         // First check if it is reachable through HTTP
         HttpWebRequest request = WebRequest.Create(url + "?wsdl") as HttpWebRequest;
         request.Timeout = 180000;

         using(HttpWebResponse response = request.GetResponse() as HttpWebResponse)
         {
            string errorMessage = "SVC handler not installed in IIS. Register ASP.NET for IIS and try again.";

            using(StreamReader reader = new StreamReader(response.GetResponseStream()))
            {
               try
               {
                  XPathDocument doc = new XPathDocument(reader);
                  XPathNavigator nav = doc.CreateNavigator();
                  if(nav == null)
                     throw new Exception(errorMessage);

                  XmlNamespaceManager manager = new XmlNamespaceManager(nav.NameTable);
                  manager.AddNamespace("wsdl", "http://schemas.xmlsoap.org/wsdl/");

                  XPathNavigator wsdlNav = nav.SelectSingleNode("//wsdl:definitions", manager);
                  if(wsdlNav == null)
                     throw new Exception(errorMessage);

                  string svcName = wsdlNav.GetAttribute("name", string.Empty);
                  if(svcName == null || string.Compare(svcName + ".svc", name, StringComparison.InvariantCultureIgnoreCase) != 0)
                     throw new Exception(errorMessage);
               }
               catch(Exception)
               {
                  throw new Exception(errorMessage);
               }
            }
         }
      }

      private void _deleteButton_Click(object sender, EventArgs e)
      {
         this.Cursor = Cursors.WaitCursor;

         try
         {
            DeleteAppPoolAndVirtualDir();
         }
         catch(Exception ex)
         {
            ShowErrorMessage(ex);
         }
         finally
         {
            // Set all services back to not tested
            foreach(LeadtoolsService ls in _prerequisites.Services)
            {
               ls.Tested = false;
               ls.Error = null;
            }

            ShowServicesStatus();
            this.Cursor = Cursors.Default;
         }
      }

      public static void DeleteAppPoolAndVirtualDir()
      {
         // Check if the virtual directory exists
         string[] vDirs = Tools.VirtualDirectory.GetVirtualDirectories(
            Globals.Machine,
            Globals.UserName,
            Globals.Password);

         foreach(string vDir in vDirs)
         {
            if(vDir == Globals.VirtualDirName ||
               vDir.Contains(Globals.OcrJobProcessorClientDemoName) ||
               vDir.Contains(Globals.MultimediaJobProcessorClientDemoName) ||
               vDir == Globals.JobProcessorFiles)
            {
               Tools.VirtualDirectory.DeleteVirtualDirectory(
                  Globals.Machine,
                  Globals.UserName,
                  Globals.Password, vDir);
            }
         }

         // Check if the application pool exists
         if(IsAppPoolExist())
         {
            Tools.ApplicationPool.DeleteApplicationPool(
               Globals.Machine,
               Globals.UserName,
               Globals.Password,
               Globals.AppPoolName);
         }

         System.Threading.Thread.Sleep(1000);

         // Finally, delete all DLL's from the virtual directory path
         string binDirectory = Path.Combine(Globals.VirtualDirPath, "Bin");

         if(Directory.Exists(binDirectory))
         {
            Directory.Delete(binDirectory, true);
         }
      }


      private static bool IsAppPoolExist()
      {
         // Check if the application pool exists
         if(Globals.IISMajorVersionNumber >= 6)
         {
            string[] appPools = Tools.ApplicationPool.GetApplicationPools(
               Globals.Machine,
               Globals.UserName,
               Globals.Password);

            foreach(string appPool in appPools)
            {
               if(appPool == Globals.AppPoolName)
               {
                  return true;
               }
            }
         }

         return false;
      }

      private void _createButton_Click(object sender, EventArgs e)
      {
         this.Cursor = Cursors.WaitCursor;

         try
         {
#if LEADTOOLS_V18_OR_LATER
            if(!_useDotNet4AssembliesCheckBox.Checked)
               MessageBox.Show(this, "In order to run the OCR and Multimedia JobProcessor demos using .Net Version 2.0, you must build the following projects:\n\r- OcrJobProcessorClientDemo_AnyCPU_2008.csproj\n\r- MultimediaJobProcessorClientDemo_AnyCPU_2008.csproj", Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
#endif // #if LEADTOOLS_V18_OR_LATER
            // First, delete the app pool and virtual directory
            DeleteAppPoolAndVirtualDir();

            // Now re-create it
            CreateAppPoolAndVirtualDir();

            _mainTabControl.SelectedTab = _testTabPage;
            Application.DoEvents();
            _testButton.PerformClick();
         }
         catch(Exception ex)
         {
            ShowErrorMessage(ex);
         }
         finally
         {
            this.Cursor = Cursors.Default;
         }
      }

      private void SetLicInConfigFile(string licFile, string keyFile)
      {
         string developerKey = string.Empty;
         if(!string.IsNullOrEmpty(keyFile))
            developerKey = File.ReadAllText(keyFile);

         ExeConfigurationFileMap fileMap = new ExeConfigurationFileMap() { ExeConfigFilename = Globals.WebConfigPath };
         Configuration wcfConfig = ConfigurationManager.OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None);
         if (wcfConfig != null)
         {
            AppSettingsSection section = wcfConfig.GetSection("appSettings") as AppSettingsSection;
            if (section != null)
            {
               section.Settings["LicenseFile"].Value = licFile;
               section.Settings["DeveloperKey"].Value = developerKey;
               wcfConfig.Save();
            }
         }
      }

      private void CreateAppPoolAndVirtualDir()
      {
         bool useX86Assemblies = _x86RadioButton.Checked;

         string dotnetRuntimeVersion = "v2.0";
         bool useDotNet4Assemblies = _useDotNet4AssembliesCheckBox.Checked;
         if(useDotNet4Assemblies)
         {
            dotnetRuntimeVersion = "v4.0";
         }

         string assemblyPath;
         if(useX86Assemblies)
            assemblyPath = Globals.AssembliesPathX86;
         else
            assemblyPath = Globals.AssembliesPathX64;

         if(useDotNet4Assemblies)
            assemblyPath = assemblyPath.Replace("##VER##", "4");
         else
            assemblyPath = assemblyPath.Replace("##VER##", "");

         // First, update the service config files
         //foreach(string serviceConfigFile in _prerequisites.ServiceConfigFiles)
         //{
         //   string fullPath = Path.Combine(Globals.VirtualDirPath, Path.Combine(@"Bin", serviceConfigFile));

         //   XmlDocument doc = new XmlDocument();
         //   doc.Load(fullPath);

         //   // Find the setting with name "RasterPdfInitialPath"
         //   // First, find the applicationSettings
         //   XmlNode applicationSettingsNode = doc.SelectSingleNode(@"configuration/applicationSettings");
         //   XmlNode settingsNode = applicationSettingsNode != null ? applicationSettingsNode.FirstChild : null;
         //   if(settingsNode == null)
         //   {
         //   }

         //   // See if we already have the setting we need
         //   XmlNode valueNode = settingsNode.SelectSingleNode(@"setting[@name='RasterPdfInitialPath']/value");
         //   if(valueNode == null)
         //   {
         //      // Create it
         //      XmlElement settingElement = doc.CreateElement("setting");

         //      XmlAttribute attr = doc.CreateAttribute("name");
         //      attr.Value = "RasterPdfInitialPath";
         //      settingElement.Attributes.Append(attr);

         //      attr = doc.CreateAttribute("serializeAs");
         //      attr.Value = "String";
         //      settingElement.Attributes.Append(attr);

         //      XmlElement valueElement = doc.CreateElement("value");
         //      settingElement.AppendChild(valueElement);

         //      settingsNode.AppendChild(settingElement);
         //      valueNode = valueElement;
         //   }

         //   // Set its new value
         //   valueNode.InnerText = assemblyPath;

         //   doc.Save(fullPath);
         //}

         // Next, create the Application pool

         bool enable32BitAppOnWin64 = false;

         // We need to set the enable32BitAppOnWin64 flag if this machine is 64-bit and we are using the x86 assemblies
         if(useX86Assemblies && Globals.Is64BitOS)
            enable32BitAppOnWin64 = true;

         // Now create the app pool
         if(Globals.IISMajorVersionNumber >= 6)
         {
            Tools.ApplicationPool.CreateApplicationPool(
               Globals.Machine,
               Globals.UserName,
               Globals.Password,
               Globals.AppPoolName,
               enable32BitAppOnWin64,
               dotnetRuntimeVersion);
         }

         // Create the virtual directory
         Tools.VirtualDirectory.CreateVirtualDirectory(
            Globals.Machine,
            Globals.UserName,
            Globals.Password,
            Globals.VirtualDirName,
            Globals.VirtualDirPath,
            Globals.IISMajorVersionNumber >= 6 ? Globals.AppPoolName : null);

         // Finally copy the assemblies to the virtual dir path
         IList<string> sourceAssemblies;

         if(useX86Assemblies)
            sourceAssemblies = _prerequisites.X86Assemblies;
         else
            sourceAssemblies = _prerequisites.X64Assemblies;

         List<string> assemblies = new List<string>();
         foreach(string sourceAssembly in sourceAssemblies)
         {
            string path = sourceAssembly;

            if(useDotNet4Assemblies)
               path = path.Replace("##VER##", "4");
            else
               path = path.Replace("##VER##", "");

            assemblies.Add(path);
         }

         if (useDotNet4Assemblies)
         {
            // Add manifest to the assemblies
#if LEADTOOLS_V20_OR_LATER
            string[] manfiestFiles = new string[]
            {
               "mfc140u.dll",
               "msvcp140.dll",
               "vcruntime140.dll"
            };
#else
            string[] manfiestFiles = new string[]
            {
               "atl100.dll",
               "mfc100.dll",
               "mfc100u.dll",
               "mfcm100.dll",
               "mfcm100u.dll",
               "msvcp100.dll",
               "msvcr100.dll"
            };
#endif // #if LEADTOOLS_V20_OR_LATER

            foreach (string manifestFileName in manfiestFiles)
            {
               string path = Path.Combine(assemblyPath, manifestFileName);
               assemblies.Add(path);
            }
         }

         StringBuilder sb = new StringBuilder();
         bool allExists = true;

         foreach(string path in assemblies)
         {
            if(!File.Exists(path))
            {
               sb.AppendLine(path);
               allExists = false;
            }
         }

         if(!allExists)
         {
            throw new Exception("The following assemblies could not be found on your system:\n\n" + sb.ToString());
         }

         string destDir = Path.Combine(Globals.VirtualDirPath, "Bin");

         if(!Directory.Exists(destDir))
         {
            Directory.CreateDirectory(destDir);
         }

         foreach(string assemblyFile in assemblies)
         {
            string name = Path.GetFileName(assemblyFile);
            string destFileName = Path.Combine(destDir, name);
            File.Copy(assemblyFile, destFileName, true);
         }

#if LEADTOOLS_V19_OR_LATER
         // copy the EVAL LIC file
         string sourceKeyFile = Path.Combine(assemblyPath, "LEADTOOLS.LIC.KEY");
         string destKeyFile = string.Empty;
         if (File.Exists(sourceKeyFile))
         {
            destKeyFile = Path.Combine(destDir, "LEADTOOLS.LIC.KEY");
            File.Copy(sourceKeyFile, destKeyFile, true);
         }
         string sourceLicFile = Path.Combine(assemblyPath, "LEADTOOLS.LIC");
         if (File.Exists(sourceLicFile))
         {
            string destLicFile = Path.Combine(destDir, "LEADTOOLS.LIC");
            File.Copy(sourceLicFile, destLicFile, true);

            string webConfig = Globals.WebConfigPath;
            if (File.Exists(webConfig))
            {
               SetLicInConfigFile(destLicFile, destKeyFile);
            }
         }
#endif // #if LEADTOOLS_V19_OR_LATER

         CreateDemosVirtualDir();

         System.Threading.Thread.Sleep(1000);
      }

      private void _troubleShootButton_Click(object sender, EventArgs e)
      {
         Globals.ShowTroubleShootingFile();
      }

      private void _troubleShootHelpButton_Click(object sender, EventArgs e)
      {
         Globals.ShowTroubleShootingFile();
      }

      public void AddText(string text, Color color, bool bold)
      {
         int oldSelectionStart = _JobProcessorComponentsRichTextBox.SelectionStart;

         _JobProcessorComponentsRichTextBox.AppendText(text);

         int newSelectionStart = _JobProcessorComponentsRichTextBox.SelectionStart;
         _JobProcessorComponentsRichTextBox.SelectionStart = oldSelectionStart;
         _JobProcessorComponentsRichTextBox.SelectionLength = newSelectionStart - oldSelectionStart;

         _JobProcessorComponentsRichTextBox.SelectionColor = color;
         FontStyle style = bold ? FontStyle.Bold : FontStyle.Regular;
         using(Font font = new Font(Font.FontFamily, Font.Size, style))
            _JobProcessorComponentsRichTextBox.SelectionFont = font;

         _JobProcessorComponentsRichTextBox.SelectionStart = newSelectionStart;

         _JobProcessorComponentsRichTextBox.ScrollToCaret();
      }

      private void _JobProcessorComponentsRichTextBox_LinkClicked(object sender, LinkClickedEventArgs e)
      {
         try
         {
            Process.Start(e.LinkText);
         }
         catch(Exception ex)
         {
            string message = string.Format("The following error occurred while trying to browse to '{0}'{1}{1}{2}", e.LinkText, Environment.NewLine, ex.Message);
            MessageBox.Show(this, message, Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
         }
      }

      private void ShowErrorMessage(Exception ex)
      {
         COMException comException = ex as COMException;

         if(comException != null && (uint)comException.ErrorCode == 0x80005000)
         {
            string message = "Could not navigate the virtual directories of IIS on this machine.\n\n" +
               "If this is a Vista machine, then please check if the \"IIS Metabase and IIS 6 configuration compatibility\" feature of the Web Management Tools of Internet Information Services is enabled.\n\n" +
               "Instructions on how to enable this feature on a Vista machine is included in the trouble shooting HTML that ships with this demo.\n\n" +
               "Do you want to view the LEADTOOLS Job Processor Server Config Demo Troubleshooting Guide now?";

            if(MessageBox.Show(this, message, Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
               Globals.ShowTroubleShootingFile();
         }
         else
            MessageBox.Show(this, ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
      }

      private void buttonDatabaseConfigure_Click(object sender, EventArgs e)
      {
         string webConfigPath = Globals.WebConfigPath;

         if(File.Exists(webConfigPath))
         {
            string connectionString = DoDatabaseConfiguration();
            if(String.IsNullOrEmpty(connectionString))
            {
               Messager.Caption = "JobProcessor Server Configuration Demo";
               Messager.ShowInformation(this, "The configuration was not completed successfully.");
            }
            else
            {
               SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder(connectionString);

               _lstvwDatabases.Items.Clear();
               _lstvwDatabases.Items.Add(new ListViewItem(new string[] { "Server", sqlConnectionStringBuilder.DataSource }));
               _lstvwDatabases.Items.Add(new ListViewItem(new string[] { "Database", sqlConnectionStringBuilder.InitialCatalog }));
               if(!sqlConnectionStringBuilder.IntegratedSecurity)
                  _lstvwDatabases.Items.Add(new ListViewItem(new string[] { "User Id", sqlConnectionStringBuilder.UserID }));
               else
                  _lstvwDatabases.Items.Add(new ListViewItem(new string[] { "User Id", "Trusted Connection" }));

               UpdateConnectionStrings(webConfigPath, connectionString);
            }
         }
      }

      void UpdateConnectionStrings(string configFilePath, string connectionString)
      {
         ExeConfigurationFileMap exeConfigurationFileMap = new ExeConfigurationFileMap();
         exeConfigurationFileMap.ExeConfigFilename = configFilePath;

         Configuration configuration = ConfigurationManager.OpenMappedExeConfiguration(exeConfigurationFileMap, ConfigurationUserLevel.None);
         ConnectionStringSettings settings = configuration.ConnectionStrings.ConnectionStrings["LEADTOOLSJobProcessorDB"];

         if (settings != null)
         {
            settings.ConnectionString = connectionString;
            configuration.Save();
         }
      }

      private string DoDatabaseConfiguration()
      {
         string connectionString = String.Empty;

         using(WaitCursor waitCursor = new WaitCursor())
         {
            using(DatabaseConfigurationDialog configDialog = new DatabaseConfigurationDialog())
            {
               configDialog.ConnectionString = _connectionString;
               if(configDialog.ShowDialog(this) == DialogResult.OK)
               {
                  try
                  {
                     bool dbExist = SqlUtilities.IsDatabaseExist(configDialog.ConnectionString);
                     connectionString = configDialog.ConnectionString;
                     SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder(connectionString);

                     string script = string.Empty;
                     string databaseName = sqlConnectionStringBuilder.InitialCatalog;

                     if ((dbExist && configDialog.Overwrite) || !dbExist)
                     {
                        script = Resources.ASPNetSqlReg;
                        RunScript(connectionString, script);
                     }

                     if (!sqlConnectionStringBuilder.IntegratedSecurity)
                     {
                        script = Resources.CreateDatabaseUser.Replace("@LoginName@", sqlConnectionStringBuilder.UserID);
                        script = script.Replace("@LoginPassword@", sqlConnectionStringBuilder.Password);
                        RunScript(connectionString, script);
                     }
                     else
                     {
                        if (CheckXPMachine())
                        {
                           script = Resources.CreateASPNETDatabaseUser.Replace("@MachineName@", Environment.MachineName);

                           RunScript(connectionString, script);
                        }
                     }


                     connectionString = sqlConnectionStringBuilder.ConnectionString;


                     // Check the SQL version
                     string connectionErrorMessage = "";
                     string version = "";
                     if (SqlUtilities.TestSQLConnectionString(connectionString, out connectionErrorMessage, out version))
                        if (SqlUtilities.IsSqlServer2012OrLater(version) && sqlConnectionStringBuilder.IntegratedSecurity)
                           MessageBox.Show("It is recommended to select the 'Use SQL Server Authentication' option.\n\n" +
                              "You are connecting to a version of SQL Server 2012 or later, where  NT_AUTHORITY\\System is no longer installed by default.  This can cause problems with the JobProcessor Components",
                              "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                  }
                  catch(Exception ex)
                  {
                     ShowErrorMessage(ex);
                  }
               }
            }
         }

         return connectionString;
      }

      private void RunScript(string connectionString, string script)
      {
         SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(connectionString);
         script = script.Replace("@DatabaseName@", builder.InitialCatalog);

         builder.InitialCatalog = string.Empty;

         using(SqlConnection connection = new SqlConnection(builder.ConnectionString))
         {
            try
            {
               string[] commands = script.Split(new string[] { "GO\r\n", "GO ", "GO\t" }, StringSplitOptions.RemoveEmptyEntries);

               connection.Open();
               foreach (string c in commands)
               {
                  using (SqlCommand command = new SqlCommand(c, connection))
                  {
                     command.ExecuteNonQuery();
                  }
               }
            }
            finally
            {
               connection.Close();
            }
         }
      }

#region Workers Page

      void UpdateButtons()
      {
         bool validSelection = _tvWorkers.SelectedNode != null && _tvWorkers.SelectedNode.Tag != null;
         _gbWorker.Enabled = validSelection && _tvWorkers.SelectedNode.Tag.GetType() == typeof(WorkerData);
         _gbJobType.Enabled = validSelection && _tvWorkers.SelectedNode.Tag.GetType() == typeof(JobType);
         _btnAddWorker.Enabled = _tvWorkers.Nodes.Count > 0;
         _btnAddJobType.Enabled = _gbWorker.Enabled || _gbJobType.Enabled;
         _numJobTypeCPUThreshold.Enabled = _chkJobTypeUseCpuThreshold.Checked;
         _numJobTypeMaxNumberOfJobs.Enabled = !_chkJobTypeUseCpuThreshold.Checked;
         _btnApply.Enabled = validSelection;
         //         _menuItemSaveWorkerSettings.Enabled = _tvWorkers.Nodes.Count > 0 && _tvWorkers.Nodes[0].Nodes.Count > 0;
      }

      public void LoadWorkers(string filename)
      {
         try
         {
            List<WorkerData> workerDataList = WorkerHelper.LoadWorkerData(filename);
            LoadTree(workerDataList);

            UpdateButtons();
         }
         catch(Exception ex)
         {
            ShowErrorMessage(ex);
         }
      }

      void LoadTree(List<WorkerData> workerDataList)
      {
         _tvWorkers.Nodes.Clear();
         TreeNode rootNode = _tvWorkers.Nodes.Add("Workers");

         //Load worker data into tree view
         foreach(WorkerData workerData in workerDataList)
         {
            TreeNode workerNode = rootNode.Nodes.Add(workerData.Name);
            workerNode.Tag = workerData;
            foreach(JobType jobType in workerData.JobTypes)
            {
               TreeNode jobTypeNode = workerNode.Nodes.Add(jobType.Name);
               jobTypeNode.Tag = jobType;
            }
         }
      }

      void UpdateFields(TreeNode workerNode, TreeNode jobTypeNode)
      {
         WorkerData workerData = (WorkerData)workerNode.Tag;
         _txtWorkerName.Text = workerData.Name;
         _numWorkerNewJobCheckPeriod.Value = workerData.NewJobCheckPeriod;
         if (jobTypeNode != null)
         {
            JobType jobType = (JobType)jobTypeNode.Tag;
            _numJobTypeAssumeHangAfter.Value = jobType.AssumeHangAfter;
            _numJobTypeAttempts.Value = jobType.Attempts;
            _numJobTypeCPUThreshold.Value = jobType.CPUThreshold;
            _numJobTypeMaxNumberOfJobs.Value = jobType.MaxNumberOfJobs;
            _numJobTypeProgressRate.Value = jobType.ProgressRate;
            _chkJobTypeUseCpuThreshold.Checked = jobType.UseCpuThreshold;
            _txtJobTypeName.Text = jobType.Name;
         }
         else
         {
            //No job type selected
            _txtJobTypeName.Text = String.Empty;
         }
      }

      private void _tvWorkers_AfterSelect(object sender, TreeViewEventArgs e)
      {
         try
         {
            bool validSelection = _tvWorkers.SelectedNode != null && _tvWorkers.SelectedNode.Tag != null;
            if(validSelection)
            {
               if(_tvWorkers.SelectedNode.Tag.GetType() == typeof(WorkerData))
               {
                  //Worker selected
                  UpdateFields(_tvWorkers.SelectedNode, null);
               }
               else if(_tvWorkers.SelectedNode.Tag.GetType() == typeof(JobType))
               {
                  //Job Type selected
                  UpdateFields(_tvWorkers.SelectedNode.Parent, _tvWorkers.SelectedNode);
               }
            }
         }
         catch(Exception ex)
         {
            ShowErrorMessage(ex);
         }

         UpdateButtons();
      }

      public void SaveWorkers(string fileName)
      {
         try
         {
            List<WorkerData> workerDataList = new List<WorkerData>();
            foreach(TreeNode workerNode in _tvWorkers.Nodes[0].Nodes)
            {
               WorkerData workerData = (WorkerData)workerNode.Tag;
               if(workerData.JobTypes == null)
                  workerData.JobTypes = new List<JobType>();
               else
                  workerData.JobTypes.Clear();

               foreach(TreeNode jobTypeNode in workerNode.Nodes)
                  workerData.JobTypes.Add((JobType)jobTypeNode.Tag);

               workerDataList.Add(workerData);
            }

            if(workerDataList.Count == 0)
            {
               MessageBox.Show(this, "No workers have been defined", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
               return;
            }

            WorkerHelper.SaveWorkerData(fileName, workerDataList);
            MessageBox.Show(this, "Configuration Saved Successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
         }
         catch(Exception ex)
         {
            ShowErrorMessage(ex);
         }
      }


      private void _btnApply_Click(object sender, EventArgs e)
      {
         try
         {
            string workersXMLPath = Path.Combine(Globals.VirtualDirPath, @"App_Data\Workers.xml");

            if (_tvWorkers.SelectedNode.Tag.GetType() == typeof(WorkerData))
            {
               //Worker selected. Validate name first
               bool valid = true;
               if (String.IsNullOrEmpty(_txtWorkerName.Text))
               {
                  MessageBox.Show(this, "You must enter a valid worker name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                  valid = false;
               }
               else if (NodeNameAlreadyExist(_tvWorkers.SelectedNode.Parent, _txtWorkerName.Text, true))
               {
                  MessageBox.Show(this, "The worker name you have entered already exists.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                  valid = false;
               }

               if (!valid)
               {
                  _txtWorkerName.Text = _tvWorkers.SelectedNode.Text;
                  _txtWorkerName.Focus();
                  return;
               }

               UpdateTree(_tvWorkers.SelectedNode, null);
               SaveWorkers(workersXMLPath);
            }
            else if (_tvWorkers.SelectedNode.Tag.GetType() == typeof(JobType))
            {
               //Job Type selected. Validate name first
               bool nameValid = true;
               if (String.IsNullOrEmpty(_txtJobTypeName.Text))
               {
                  MessageBox.Show(this, "You must enter a valid job type.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                  nameValid = false;
               }
               else if (NodeNameAlreadyExist(_tvWorkers.SelectedNode.Parent, _txtJobTypeName.Text, true))
               {
                  MessageBox.Show(this, "The job type name you have entered already exists.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                  nameValid = false;
               }

               if (!nameValid)
               {
                  _txtJobTypeName.Text = _tvWorkers.SelectedNode.Text;
                  _txtJobTypeName.Focus();
                  return;
               }

               if (_numJobTypeAssumeHangAfter.Value <= _numJobTypeProgressRate.Value)
               {
                  MessageBox.Show(this, "The 'Assume Hang After' value should be greater than the 'Progress Rate' value to prevent the service from mistakenly considering jobs 'hung'.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                  _numJobTypeAssumeHangAfter.Focus();
                  return;
               }

               UpdateTree(null, _tvWorkers.SelectedNode);
               SaveWorkers(workersXMLPath);
            }
         }
         catch (Exception ex)
         {
            ShowErrorMessage(ex);
         }
         finally
         {
            UpdateButtons();
         }
      }

      void UpdateTree(TreeNode workerNode, TreeNode jobTypeNode)
      {
         if(workerNode != null)
         {
            WorkerData workerData = new WorkerData();
            workerData.Name = _txtWorkerName.Text;
            workerData.NewJobCheckPeriod = (int)_numWorkerNewJobCheckPeriod.Value;

            //Update node with new data
            workerNode.Text = workerData.Name;
            workerNode.Tag = workerData;
         }
         else if(jobTypeNode != null)
         {
            JobType jobType = new JobType();
            jobType.AssumeHangAfter = (int)_numJobTypeAssumeHangAfter.Value;
            jobType.Attempts = (int)_numJobTypeAttempts.Value;
            jobType.CPUThreshold = (int)_numJobTypeCPUThreshold.Value;
            jobType.MaxNumberOfJobs = (int)_numJobTypeMaxNumberOfJobs.Value;
            jobType.ProgressRate = (int)_numJobTypeProgressRate.Value;
            jobType.UseCpuThreshold = _chkJobTypeUseCpuThreshold.Checked;
            jobType.Name = _txtJobTypeName.Text;

            //Update node with new data
            jobTypeNode.Text = jobType.Name;
            jobTypeNode.Tag = jobType;
         }
      }

      private void _menuItemExit_Click(object sender, EventArgs e)
      {
         this.Close();
      }

      private void _btnRemoveWorker_Click(object sender, EventArgs e)
      {
         try
         {
            _tvWorkers.SelectedNode.Remove();
         }
         catch(Exception ex)
         {
            ShowErrorMessage(ex);
         }

         UpdateButtons();
      }

      private void _btnRemoveJobType_Click(object sender, EventArgs e)
      {
         try
         {
            _tvWorkers.SelectedNode.Remove();
         }
         catch(Exception ex)
         {
            ShowErrorMessage(ex);
         }

         UpdateButtons();
      }

      private void _chkJobTypeUseCpuThreshold_CheckedChanged(object sender, EventArgs e)
      {
         UpdateButtons();
      }

      string CreateWorkerName()
      {
         //Create a worker name not yet used
         int count = 1;
         while(true)
         {
            string workerName = String.Format("Worker{0}", count);
            if(!NodeNameAlreadyExist(_tvWorkers.Nodes[0], workerName, false))
               return workerName;
            count++;
         }
      }

      string CreateJobTypeName(TreeNode parentWorkerNode)
      {
         //Create a job type name not yet used
         int count = 1;
         while(true)
         {
            string jobTypeName = String.Format("JobType{0}", count);
            if(!NodeNameAlreadyExist(parentWorkerNode, jobTypeName, false))
               return jobTypeName;
            count++;
         }
      }

      bool NodeNameAlreadyExist(TreeNode parentNode, string nodeName, bool excludeSelectedFromSearch)
      {
         foreach(TreeNode childNode in parentNode.Nodes)
         {
            if(excludeSelectedFromSearch && childNode.IsSelected)
               continue;

            //Check to see if name exists
            if(String.Compare(nodeName, childNode.Text, true) == 0)
               return true; //Name already exists
         }

         return false;
      }

      private void _btnAddWorker_Click(object sender, EventArgs e)
      {
         try
         {
            //Add new worker
            WorkerData newWorker = new WorkerData();
            newWorker.Name = CreateWorkerName();
            newWorker.NewJobCheckPeriod = 5;

            TreeNode newWorkerNode = _tvWorkers.Nodes[0].Nodes.Add(newWorker.Name);
            newWorkerNode.Tag = newWorker;
            _tvWorkers.SelectedNode = newWorkerNode;
         }
         catch(Exception ex)
         {
            ShowErrorMessage(ex);
         }

         UpdateButtons();
      }

      private void _btnAddJobType_Click(object sender, EventArgs e)
      {
         try
         {
            //Add job type
            //We need to get the worker node first
            TreeNode workerNode = _tvWorkers.SelectedNode.Tag.GetType() == typeof(WorkerData) ? _tvWorkers.SelectedNode : _tvWorkers.SelectedNode.Parent;

            //Create new JobType with some default settings
            JobType newjobType = new JobType();
            newjobType.Name = CreateJobTypeName(workerNode);
            newjobType.AssumeHangAfter = 60;
            newjobType.Attempts = 3;
            newjobType.CPUThreshold = 80;
            newjobType.MaxNumberOfJobs = 1;
            newjobType.ProgressRate = 10;
            newjobType.UseCpuThreshold = false;

            TreeNode newJobTypeNode = workerNode.Nodes.Add(newjobType.Name);
            newJobTypeNode.Tag = newjobType;
            _tvWorkers.SelectedNode = newJobTypeNode;
         }
         catch(Exception ex)
         {
            ShowErrorMessage(ex);
         }

         UpdateButtons();
      }


#endregion  // Workers Page

      private void _workersTabPage_Enter(object sender, EventArgs e)
      {
         LoadWorkers(Path.Combine(Globals.VirtualDirPath, @"App_Data\Workers.xml"));
         UpdateButtons();
      }

      private string FindConnectionString()
      {
         ExeConfigurationFileMap exeConfigurationFileMap = new ExeConfigurationFileMap();
         exeConfigurationFileMap.ExeConfigFilename = Globals.WebConfigPath;

         Configuration configuration = ConfigurationManager.OpenMappedExeConfiguration(exeConfigurationFileMap, ConfigurationUserLevel.None);
         ConnectionStringSettings settings = configuration.ConnectionStrings.ConnectionStrings["LEADTOOLSJobProcessorDB"];

         return settings.ConnectionString;
      }

      private void CreateDemosVirtualDir()
      {
         // Create the virtual directory
         Tools.VirtualDirectory.CreateVirtualDirectory(
            Globals.Machine,
            Globals.UserName,
            Globals.Password,
            "CS" + Globals.OcrJobProcessorClientDemoName,
            Globals.CSOcrClientDemoVirtualDirPath,
            Globals.IISMajorVersionNumber >= 6 ? Globals.AppPoolName : null);

         Tools.VirtualDirectory.CreateVirtualDirectory(
            Globals.Machine,
            Globals.UserName,
            Globals.Password,
            "CS" + Globals.MultimediaJobProcessorClientDemoName,
            Globals.CSMultimediaClientDemoVirtualDirPath,
            Globals.IISMajorVersionNumber >= 6 ? Globals.AppPoolName : null);

         Tools.VirtualDirectory.CreateVirtualDirectory(
            Globals.Machine,
            Globals.UserName,
            Globals.Password,
            Globals.JobProcessorFiles,
            Globals.JobProcessorFilesPath,
            Globals.IISMajorVersionNumber >= 6 ? Globals.AppPoolName : null);

         string warning = String.Format("All job related files will be stored on the server in '{0}'. In order to process these files, all workers " +
               "will require read/write access to this location. Would you like this demo to create the shared folder for you? The share will be configured " +
               "with full access granted to everyone. If you select No, you will need to configure the 'InputFilesUrl' and 'OutputFilesUrl' settings in the " +
               "client demos web.config manually.", Globals.JobProcessorFilesPath);
         if(MessageBox.Show(warning, Text, MessageBoxButtons.YesNo) == DialogResult.Yes)
         {
            string inputDir = Path.Combine(Globals.JobProcessorFilesPath, "Input");
            string outputDir = Path.Combine(Globals.JobProcessorFilesPath, "Output");

            if(!Directory.Exists(Globals.JobProcessorFilesPath))
            {
               Directory.CreateDirectory(Globals.JobProcessorFilesPath);
               Directory.CreateDirectory(inputDir);
            }

            if(!Directory.Exists(outputDir))
               Directory.CreateDirectory(outputDir);

            Share(Globals.JobProcessorFilesPath);
            FullAccess(Globals.JobProcessorFilesPath);

            string csOcrConfig = Path.Combine(Globals.CSOcrClientDemoVirtualDirPath, "Web.config");

            string newAddress = string.Format("{0}{1}{2}", Path.DirectorySeparatorChar, Path.DirectorySeparatorChar, Path.Combine(Environment.MachineName, Path.GetFileName(Globals.JobProcessorFilesPath)));
            string newInputPath = Path.Combine(newAddress, Path.GetFileName(inputDir));
            string newOutputPath = Path.Combine(newAddress, Path.GetFileName(outputDir));
            string newMMProfilePath = Path.Combine(newAddress, "MMProfiles");

            UpdateWebConfigPaths(csOcrConfig, newInputPath, newOutputPath, string.Empty);

            string csMultimediaConfig = Path.Combine(Globals.CSMultimediaClientDemoVirtualDirPath, "Web.config");
            UpdateWebConfigPaths(csMultimediaConfig, newInputPath, newOutputPath, newMMProfilePath);
         }
      }

      private bool IsShared(string directory)
      {
         bool shared = false;
         ManagementObjectSearcher searcher = new ManagementObjectSearcher("select * from win32_share");
         ManagementClass mc = new ManagementClass("Win32_Share");

         foreach(ManagementObject share in searcher.Get())
         {
            string shareName = share["Path"].ToString();
            if (String.IsNullOrEmpty(shareName))
               continue;

            if (String.Compare(Path.GetFileName(directory), Path.GetFileName(share["Path"].ToString()), true) == 0)
               shared = true;
         }

         return shared;
      }

      bool StopSharing(string directory)
      {
         string shareName = Path.GetFileName(directory);
         ManagementObject share = new ManagementObject("Win32_Share.Name='" + shareName + "'" );
         share.Delete();

         return false;
      }

      void Share(string directory)
      {
         DirectoryInfo dInfo = new DirectoryInfo(directory);
         DirectorySecurity dSecurity = dInfo.GetAccessControl();
         dSecurity.AddAccessRule(new FileSystemAccessRule("everyone", FileSystemRights.FullControl, InheritanceFlags.ObjectInherit | InheritanceFlags.ContainerInherit, PropagationFlags.InheritOnly, AccessControlType.Allow));
         dInfo.SetAccessControl(dSecurity);

         if(IsShared(directory))
            StopSharing(directory);

         ManagementClass managementClass = new ManagementClass("Win32_Share");
         // Create ManagementBaseObjects for in and out parameters

         ManagementBaseObject inParams = managementClass.GetMethodParameters("Create");
         ManagementBaseObject outParams;

         // Set the input parameters
         inParams["Description"] = "Workers";
         inParams["Name"] = Path.GetFileName(directory);
         inParams["Path"] = directory;
         inParams["Type"] = 0x0; // Disk Drive
         outParams = managementClass.InvokeMethod("Create", inParams, null);

         // Check to see if the method invocation was successful
         if((uint)(outParams.Properties["ReturnValue"].Value) != 0)
         {
            throw new Exception("Unable to share directory.");
         }
      }

      void FullAccess(string directory)
      {
         //user selection
         NTAccount ntAccount = new NTAccount("Everyone");

         //SID
         SecurityIdentifier userSID = (SecurityIdentifier)ntAccount.Translate(typeof(SecurityIdentifier));
         byte[] utenteSIDArray = new byte[userSID.BinaryLength];
         userSID.GetBinaryForm(utenteSIDArray, 0);

         //Trustee
         ManagementObject userTrustee = new ManagementClass(new ManagementPath("Win32_Trustee"), null);
         userTrustee["Name"] = "Everyone";
         userTrustee["SID"] = utenteSIDArray;

         //ACE
         ManagementObject userACE = new ManagementClass(new ManagementPath("Win32_Ace"), null);
         userACE["AccessMask"] = 2032127;                                 //Full access
         userACE["AceFlags"] = AceFlags.ObjectInherit | AceFlags.ContainerInherit;
         userACE["AceType"] = AceType.AccessAllowed;
         userACE["Trustee"] = userTrustee;

         ManagementObject userSecurityDescriptor = new ManagementClass(new ManagementPath("Win32_SecurityDescriptor"), null);
         userSecurityDescriptor["ControlFlags"] = 4; //SE_DACL_PRESENT 
         userSecurityDescriptor["DACL"] = new object[] { userACE };

         ManagementClass mc = new ManagementClass("Win32_Share");
         ManagementObject share = new ManagementObject(mc.Path + ".Name='" + Path.GetFileName(directory) + "'");
         share.InvokeMethod("SetShareInfo", new object[] { Int32.MaxValue, Path.GetFileName(directory), userSecurityDescriptor });
      }

      void UpdateWebConfigPaths(string configPath, string newInputPath, string newOutputPath, string profilePath)
      {
         //Load the web.config file

         XmlDocument configDocument = new XmlDocument();
         configDocument.Load(configPath);

         //Get the 'InputFilesUrl' node
         XmlNode inputURLNode = configDocument.SelectSingleNode("//setting[@name='InputFilesUrl']/value");

         if(inputURLNode == null)
            throw new Exception("InputFilesUrl setting not found");
         //Update the 'InputFilesUrl' value

         inputURLNode.InnerText = newInputPath;
         //Get the 'OutputFilesUrl' node

         XmlNode outputURLNode = configDocument.SelectSingleNode("//setting[@name='OutputFilesUrl']/value");
         if(outputURLNode == null)
            throw new Exception("OutputFilesUrl setting not found");

         if (!String.IsNullOrEmpty(profilePath))
         {
            XmlNode profilesUrlNode = configDocument.SelectSingleNode("//setting[@name='ProfilesUrl']/value");
            if (profilesUrlNode != null)
            {
               profilesUrlNode.InnerText = profilePath;
            }
         }

         //Update the 'OutputFilesUrl' value
         outputURLNode.InnerText = newOutputPath;

         //Save the web.config file
         configDocument.Save(configPath);
      }
   }
}

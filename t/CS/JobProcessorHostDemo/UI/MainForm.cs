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
using System.Net;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Leadtools.Demos;
using System.Security.Principal;
using System.Diagnostics;
using Microsoft.Win32;
using System.Data.SqlClient;
using System.IO;
using System.Configuration;
using JobProcessorHostDemo.Properties;
using Leadtools.Common.JobProcessor;

namespace JobProcessorHostDemo
{
   public partial class MainForm : Form
   {
      [DllImport("user32.dll")]
      public static extern IntPtr GetSystemMenu(IntPtr hWnd, bool bRevert);

      [DllImport("user32.dll")]
      public static extern bool InsertMenu(IntPtr hMenu, Int32 wPosition, Int32 wFlags, Int32 wIDNewItem, string lpNewItem);

      public const Int32 WM_SYSCOMMAND = 0x112;
      public const Int32 MF_BYPOSITION = 0x400;

      public const Int32 _miAboutDialog = 1001;

      LeadtoolsWcfHost _host = new LeadtoolsWcfHost();
      public static bool IsDotNet35Installed;
      bool _startService = false;
      public MainForm(bool startService)
      {
         InitializeComponent();

         Properties.Settings settings = new Properties.Settings();
         //_txtBaseAddress.Text = settings["Address"] as string;
         _startService = startService;
      }

      protected override void OnLoad(EventArgs e)
      {
         base.OnLoad(e);
         if (_startService)
         {
            Start(true);
         }
      }
      /// <summary>
      /// The main entry point for the application.
      /// </summary>
      [STAThread]
      static void Main(string [] args)
      {
         if (!Support.SetLicense())
            return;

         if (!CheckAdminRights())
            return;

         if (Environment.Version.Major < 4)
         {
            // Check if .NET 3.5 is installed
            RegistryKey rk = OpenSoftwareKey(@"\Microsoft\NET Framework Setup\NDP\v3.5");
            if (rk != null)
            {
               IsDotNet35Installed = true;
               rk.Close();
            }
            else
               IsDotNet35Installed = false;

            if (!IsDotNet35Installed)
            {
               MessageBox.Show(null, ".NET Framework 3.5 could not be found on this machine.\n\nPlease install the .NET Framework 3.5 runtime and try again. This program will now exit.", "LEADTOOLS JobProcessor Self Host", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
               return;
            }
         }

         Application.EnableVisualStyles();
         Application.DoEvents();

         bool startService = false;
         if (args != null && args.Length > 0)
         {
            if (string.Compare(args[0], "Start", true) == 0)
               startService = true;
         }

         Application.Run(new MainForm(startService));
      }

      public static RegistryKey OpenSoftwareKey(string keyName)
      {
         RegistryKey key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Wow6432Node\" + keyName);
         if (key == null)
         {
            key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\" + keyName);
            if (key == null)
               key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\" + keyName);
         }

         return key;
      }

      private void Start(bool silent)
      {
         if (_host != null)
         {
            _host.Shutdown();
            _host = null;
         }

         _host = new LeadtoolsWcfHost();

         _lstReport.Items.Clear();

         _host.Address = _txtAddress.Text;
         _host.Port = _txtPort.Text;
         _host.Alias = _txtAlias.Text;

         _host.Opening += new LeadtoolsWcfHost.OpeningEventHandler(_host_Opening);
         _host.Opened += new LeadtoolsWcfHost.OpenedEventHandler(_host_Opened);
         _host.Closing += new LeadtoolsWcfHost.ClosingEventHandler(_host_Closing);
         _host.Closed += new LeadtoolsWcfHost.ClosedEventHandler(_host_Closed);

         _host.Start(silent);
      }

      private void _btnStartup_Click(object sender, EventArgs e)
      {
         Start(false);
      }

      void _host_Closed(string serviceName, string address)
      {
         _lstReport.Items.Add(serviceName + " at " + address + " has closed");
         _btnShutDown.Enabled = false;
         _btnStartup.Enabled = true;

         _txtPort.Enabled = _btnStartup.Enabled;
         _txtAlias.Enabled = _btnStartup.Enabled;
      }

      void _host_Closing(string serviceName, string address)
      {
         _lstReport.Items.Add("Closing " + serviceName + " at " + address);
      }

      void _host_Opened(string serviceName, string address)
      {
         _lstReport.Items.Add(serviceName + " at " + address + " has opened");
         _btnShutDown.Enabled = true;
         _btnStartup.Enabled = false;

         _txtPort.Enabled = _btnStartup.Enabled;
         _txtAlias.Enabled = _btnStartup.Enabled;
      }

      void _host_Opening(string serviceName, string address)
      {
         _lstReport.Items.Add("Opening " + serviceName + " at " + address);
      }

      private void _btnShutDown_Click(object sender, EventArgs e)
      {
         if (_host != null)
         {
            _lstReport.Items.Clear();
            _host.Shutdown();
            _host = null;
         }
      }

      private void _btnClose_Click(object sender, EventArgs e)
      {
         _btnShutDown.PerformClick();
         Close();
      }

      private void _txtPort_KeyPress(object sender, KeyPressEventArgs e)
      {
         if (!e.Handled)
         {
            if (!Char.IsControl(e.KeyChar) && !Char.IsDigit(e.KeyChar))
               e.Handled = true;
         }
      }

      private void MainForm_Load(object sender, EventArgs e)
      {
         _txtAddress.Text = GetMachineIP();
         _txtAddress.Enabled = false;

         if (ConfigurationManager.ConnectionStrings["LEADTOOLSJobProcessorDB"] != null)
         {
            SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder(ConfigurationManager.ConnectionStrings["LEADTOOLSJobProcessorDB"].ConnectionString);
            if (SqlUtilities.IsDatabaseExist(sqlConnectionStringBuilder.ConnectionString))
            {
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


      private static bool CheckAdminRights()
      {
         bool elevate = false;

         bool needUAC = false;

         // Check if we need UAC to elevate the rights
         OperatingSystem os = Environment.OSVersion;
         if (os.Platform == PlatformID.Win32NT && os.Version.Major >= 6)
            needUAC = true;
         else
            needUAC = false;

         if (needUAC)
         {
            // Check if we are not running in admin mode
            WindowsIdentity wi = WindowsIdentity.GetCurrent();
            WindowsPrincipal wp = new WindowsPrincipal(wi);

            if (!wp.IsInRole(WindowsBuiltInRole.Administrator))
               elevate = true;
         }

         if (elevate)
         {
            // We must restart this application elevated as admin
            ProcessStartInfo startInfo = new ProcessStartInfo();

            startInfo.UseShellExecute = true;
            startInfo.WorkingDirectory = Environment.CurrentDirectory;
            startInfo.FileName = Application.ExecutablePath;
            startInfo.Verb = "runas";

            try
            {
               Process p = Process.Start(startInfo);
            }
            catch (Win32Exception)
            {
            }
         }

         return !elevate;
      }

      static string GetMachineIP()
      {
         string address = string.Empty;
         IPHostEntry hostEntry = null;
         hostEntry = Dns.GetHostEntry(Dns.GetHostName());

         IPAddress[] Addresses = hostEntry.AddressList;

         for (int i = 0; i < Addresses.Length; ++i)
         {
            if (Addresses[i].AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
            {
               address = Addresses[i].ToString();
            }
         }

         return address;
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

      private string DoDatabaseConfiguration(string connectionString)
      {
         using (WaitCursor waitCursor = new WaitCursor())
         {

            using (DatabaseConfigurationDialog configDialog = new DatabaseConfigurationDialog())
            {
               configDialog.ConnectionString = connectionString;
               if (configDialog.ShowDialog(this) == DialogResult.OK)
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
                  catch (Exception ex)
                  {
                     MessageBox.Show(ex.Message);
                  }
               }
            }
         }

         return connectionString;
      }


      private void buttonDatabaseConfigure_Click(object sender, EventArgs e)
      {
         string connectionString = string.Empty;
         if (ConfigurationManager.ConnectionStrings["LEADTOOLSJobProcessorDB"] != null)
         {
            connectionString = ConfigurationManager.ConnectionStrings["LEADTOOLSJobProcessorDB"].ConnectionString;
         }

         connectionString = DoDatabaseConfiguration(connectionString);
         if (String.IsNullOrEmpty(connectionString))
         {
            Messager.Caption = "JobProcessor Self Host Demo";
            Messager.ShowInformation(this, "The configuration was not completed successfully.");
         }
         else
         {
            SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder(connectionString);

            _lstvwDatabases.Items.Clear();
            _lstvwDatabases.Items.Add(new ListViewItem(new string[] { "Server", sqlConnectionStringBuilder.DataSource }));
            _lstvwDatabases.Items.Add(new ListViewItem(new string[] { "Database", sqlConnectionStringBuilder.InitialCatalog }));
            if (!sqlConnectionStringBuilder.IntegratedSecurity)
               _lstvwDatabases.Items.Add(new ListViewItem(new string[] { "User Id", sqlConnectionStringBuilder.UserID }));
            else
               _lstvwDatabases.Items.Add(new ListViewItem(new string[] { "User Id", "Trusted Connection" }));

            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            ConnectionStringsSection section = config.GetSection("connectionStrings") as ConnectionStringsSection;
            if (section != null)
            {
               section.ConnectionStrings["LEADTOOLSJobProcessorDB"].ConnectionString = connectionString;
               config.Save();

               Application.Exit();

               // We must restart this application elevated as admin
               ProcessStartInfo startInfo = new ProcessStartInfo();

               startInfo.Arguments = "Start";
               startInfo.UseShellExecute = true;
               startInfo.WorkingDirectory = Environment.CurrentDirectory;
               startInfo.FileName = Application.ExecutablePath;
               startInfo.Verb = "runas";

               try
               {
                  Process p = Process.Start(startInfo);
               }
               catch (Win32Exception)
               {
               }
            }
         }
      }

      private void RunScript(string connectionString, string script)
      {
         SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(connectionString);
         script = script.Replace("@DatabaseName@", builder.InitialCatalog);

         builder.InitialCatalog = string.Empty;

         using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
         {

            string[] commands = script.Split(new string[] { "GO\r\n", "GO ", "GO\t" }, StringSplitOptions.RemoveEmptyEntries);

            connection.Open();
            foreach (string c in commands)
            {
               SqlCommand command = new SqlCommand(c, connection);

               command.ExecuteNonQuery();
            }
         }
      }
   }
}

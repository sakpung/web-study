// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Windows.Forms;
using Leadtools.Ccow;
using Leadtools.Ccow.Services;
using Leadtools.Demos;
using Leadtools.Demos.Dialogs;
using Leadtools.Wcf;

namespace CcowWebParticipantServiceHost
{
   public partial class MainForm : Form
   {
      /// <summary>
      /// The main entry point for the application.
      /// </summary>
      [STAThread]
      static void Main()
      {
         if (DemoUtils.IsAlreadyRunning())
            return;

         if (Environment.Version.Major < 4)
         {
            // Check if .NET 3.5 is installed
            if (!DemoUtils.IsDotNet35Installed())
            {
               MessageBox.Show(null, ".NET Framework 3.5 could not be found on this machine.\n\nPlease install the .NET Framework 3.5 runtime and try again. This program will now exit.", "LEADTOOLS Ccow Participant Service Host", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
               return;
            }
         }

         string[] args = Environment.GetCommandLineArgs();
         if (args != null && args.Length > 0)
         {
            foreach (string command in args)
            {
               if (command.CompareTo("install") == 0)
               {
                  Utils.RegisterAppUrl("CSCcowWebParticipantServiceHost");
                  return;
               }
               else if (command.CompareTo("uninstall") == 0)
               {
                  Utils.UnregisterAppUrl("CSCcowWebParticipantServiceHost");
                  return;
               }
            }
         }

         Application.EnableVisualStyles();
         Application.DoEvents();

         Application.Run(new MainForm());
      }

      private NotifyIcon _trayIcon;
      private ContextMenu _trayMenu;

      private ServiceHost _host;
      private CcowParticipantService _service;
      private int _clientsCount;

      // Disable Close button
      protected override CreateParams CreateParams
      {
         get
         {
            const int CP_NOCLOSE_BUTTON = 0x200;
            CreateParams myCp = base.CreateParams;
            myCp.ClassStyle = myCp.ClassStyle | CP_NOCLOSE_BUTTON;
            return myCp;
         }
      }

      public MainForm()
      {
         InitializeComponent();

         Properties.Settings settings = new Properties.Settings();

         // Set license
         if (!Support.SetLicense())
            return;

         // Init try icon and menu
         InitTrayIcon();
         // Hide main form
         HideForm();
      }

      private void InitTrayIcon()
      {
         this._trayMenu = new ContextMenu();
         this._trayMenu.MenuItems.Add("About", TrayMenu_OnAbout);
         this._trayMenu.MenuItems.Add("Exit", TrayMenu_OnExit);
         this._trayIcon = new NotifyIcon();
         this._trayIcon.Text = this.Text;
         this._trayIcon.Icon = this.Icon;
         this._trayIcon.ContextMenu = _trayMenu;
         // Show Main window on double click
         this._trayIcon.DoubleClick += new EventHandler(TrayIcon_DoubleClick);
      }

      private void TrayMenu_OnAbout(object sender, EventArgs e)
      {
         AboutDialog aboutDialog = new AboutDialog(this.Text, ProgrammingInterface.CS);
         aboutDialog.ShowDialog(this);
      }

      private void TrayMenu_OnExit(object sender, EventArgs e)
      {
         Application.Exit();
      }

      private void TrayIcon_DoubleClick(object sender, EventArgs e)
      {
         this.ShowForm();
      }

      private void ShowForm()
      {
         // Show the Main window and hide the try icon
         this.Show();
         this.WindowState = FormWindowState.Normal;
         this.BringToFront();
         this._trayIcon.Visible = false;
      }

      private void HideForm()
      {
         // Mimize the Main window and show the try icon
         this.WindowState = FormWindowState.Minimized;
         this.ShowInTaskbar = false;
         this._trayIcon.Visible = true;
      }


      private void MainForm_Resize(object sender, EventArgs e)
      {
         // If minize, then hide the form
         if (this.WindowState == FormWindowState.Minimized)
            this.HideForm();
      }

      private void StartService()
      {
         if (this._host != null)
         {
            this._host.Close();
            this._host = null;
         }

         // Init the address
         Uri localAddress = new Uri(this._txtAddress.Text);
         WebHttpBinding binding = new WebHttpBinding();

         this._clientsCount = 0;
         // Init the service
         this._service = new CcowParticipantService();
         this._service.ClientConnected += new EventHandler<ClientConnectionEventArgs>(Service_ClientConnected);
         this._service.ClientDisconnected += new EventHandler<ClientConnectionEventArgs>(Service_ClientDisconnected);

         this._host = new ServiceHost(_service, localAddress);
#if !DOTNET_2
         binding.CrossDomainScriptAccessEnabled = true;
#endif // DOTNET_2
         ServiceEndpoint endpoint = _host.AddServiceEndpoint(typeof(ICcowParticipantService), binding, localAddress);
         // Add cors support (for Cross Domain)
         endpoint.Behaviors.Add(new CorsSupportBehavior());
         // Add CcowWebHttpBehavior for parameters conversion
         endpoint.Behaviors.Add(new CcowWebHttpBehavior());
         this._host.Open();
      }

      private void Service_ClientConnected(object sender, ClientConnectionEventArgs e)
      {
         this._clientsCount++;
      }

      private void Service_ClientDisconnected(object sender, ClientConnectionEventArgs e)
      {
         this._clientsCount--;
         // Close the application if the counts is zero
         if (this._clientsCount == 0)
            this.Invoke(new MethodInvoker(delegate
            {
               Close();
            }));
      }

      private void BtnClose_Click(object sender, EventArgs e)
      {
         Close();
      }

      private void MainForm_Load(object sender, EventArgs e)
      {
         // Set the base address
         this._txtAddress.Text = "http://localhost:80/LEADTOOLSContextParticipant";

         // Start the participant service
         StartService();
      }

      private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
      {
         // Close the host
         if (_host != null)
         {
            _host.Close();
            _host = null;
            _service = null;
         }
         this._trayIcon.Visible = false;
      }
   }
}

// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Threading;
using System.Windows.Forms;
using Leadtools.Ccow.Dialogs;
using Leadtools.Ccow.Server;
using Leadtools.Ccow.Services;
using Leadtools.Demos;
using Leadtools.Demos.Dialogs;

namespace CSCcowServerDemo
{
   public partial class MainForm : Form
   {
      /// <summary>
      /// The main entry point for the application.
      /// </summary>
      [STAThread]
      static void Main(string[] args)
      {
         if (Environment.Version.Major < 4)
         {
            // Check if .NET 3.5 is installed
            if (!DemoUtils.IsDotNet35Installed())
            {
               MessageBox.Show(null, ".NET Framework 3.5 could not be found on this machine.\n\nPlease install the .NET Framework 3.5 runtime and try again. This program will now exit.", "LEADTOOLS Ccow Participant Service Host", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
               return;
            }
         }

         if (!Support.SetLicense())
            return;

         foreach (string arg in args)
         {
            if (string.IsNullOrEmpty(arg))
               continue;

            string strippedArg = arg.Substring(1);
            bool close = false;
            // Register CCOW COM components
            if (string.Compare(strippedArg, "register", true) == 0)
            {
               CcowServer.Register();
               close = true;
            }
            // Unregister CCOW COM components
            else if (string.Compare(strippedArg, "unregister", true) == 0)
            {
               CcowServer.Unregister();
               close = true;
            }

            if (close)
               return;
         }

         Application.EnableVisualStyles();
         Application.DoEvents();

         MainForm frm = new MainForm();

         // Start the CCOW server
         CcowServer.Start();

         Application.Run(frm);

         // Stop the CCOW server
         CcowServer.Stop();

         return;
      }

      private NotifyIcon _trayIcon;
      private ContextMenu _trayMenu;
      private ConfigurationDialog _ConfigDialog;
      private ParticipantDialog _ParticipantDialog;

      // CCOW context management registry (ContextManagementRegistry Web Interface)
      //      Responsible for hosting and locating CCOW components services
      private ContextManagementRegistryService _ccowService;

      private string _address;
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

         // Start the web service
         if (DemoUtils.CheckAdminRights())
            this._address = string.Format("{0}/Leadtools", Environment.MachineName);

         // Init Dialogs
         InitDialogs();
         // Init try icon and menu
         InitTrayIcon();
         // Hide main form
         HideForm();
      }

      private MenuItem _trayMenu_Configuration;
      private MenuItem _trayMenu_Participants;

      private void InitDialogs()
      {
         _ConfigDialog = new ConfigurationDialog(this._address);
         _ParticipantDialog = new ParticipantDialog();
      }

      private void InitTrayIcon()
      {
         _trayMenu = new ContextMenu();
         _trayMenu.Popup += new EventHandler(TrayMenu_Popup);
         _trayMenu_Configuration = _trayMenu.MenuItems.Add("Configuration...", TrayMenu_OnConfiguration);
         _trayMenu_Participants = _trayMenu.MenuItems.Add("Participants...", TrayMenu_OnParticipants);
         _trayMenu_Participants = _trayMenu.MenuItems.Add("-");
         _trayMenu.MenuItems.Add("About", TrayMenu_OnAbout);
         _trayMenu.MenuItems.Add("Exit", TrayMenu_OnExit);
         _trayIcon = new NotifyIcon();
         _trayIcon.Text = this.Text;
         _trayIcon.Icon = this.Icon;

         _trayIcon.ContextMenu = _trayMenu;
      }

      private void TrayMenu_Popup(object sender, EventArgs e)
      {
         _trayMenu_Configuration.Enabled = !_ConfigDialog.Visible;
         _trayMenu_Participants.Enabled = !_ParticipantDialog.Visible;
      }

      private void TrayMenu_OnConfiguration(object sender, EventArgs e)
      {
         try
         {
            // Login as admin
            if (Login())
            {
               // Show the CCOW server configuration dialog
               ShowDialog(_ConfigDialog);
            }
         }
         catch (Exception exception)
         {
            MessageBox.Show(exception.Message, "Error During Configuration", MessageBoxButtons.OK, MessageBoxIcon.Error);
         }
      }

      private void TrayMenu_OnParticipants(object sender, EventArgs e)
      {
         // Show the CCOW participants dialog
         ShowDialog(_ParticipantDialog);
      }

      private void ShowDialog(Form dialog)
      {
         if (!dialog.Visible)
            dialog.Show();
         else
            dialog.Activate();
      }

      private void TrayMenu_OnAbout(object sender, EventArgs e)
      {
         AboutDialog aboutDialog = new AboutDialog(this.Text, ProgrammingInterface.CS);
         aboutDialog.ShowDialog(this);
      }

      private void TrayMenu_OnExit(object sender, EventArgs e)
      {
         if (_ConfigDialog.Visible || _ParticipantDialog.Visible)
         {
            MessageBox.Show("Must close all dialogs before existing", "Close Config Dialog", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            if (_ConfigDialog.Visible)
               ShowDialog(_ConfigDialog);
            else
               ShowDialog(_ParticipantDialog);
         }
         else
            Application.Exit();
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
         // Start the CCOW web services
         try
         {
            // Set the base address
            _ccowService = new ContextManagementRegistryService("LEADTOOLS", this._address, Guid.NewGuid().ToString("N"));
            _ccowService.Start();
         }
         catch (Exception ex)
         {
            MessageBox.Show(ex.Message);
         }
      }

      private void BtnClose_Click(object sender, EventArgs e)
      {
         Close();
      }

      private void MainForm_Load(object sender, EventArgs e)
      {
         // Start the CCOW web services
         if (DemoUtils.CheckAdminRights())
            StartService();
      }

      private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
      {
         // Close the host
         if (_ccowService != null)
         {
            _ccowService.Stop();
         }

         this._trayIcon.Visible = false;
      }

      private bool Login()
      {
         using (CredentialsDialog dlgLogin = new CredentialsDialog())
         {
            dlgLogin.User = Config.Get<string>("LastUser", string.Empty);
            dlgLogin.Caption = "CCOW Server";
            dlgLogin.Message = "Please provide an administrative user to access configuration settings.";
            while (true)
            {
               if (dlgLogin.ShowDialog() == DialogResult.OK)
               {
                  IntPtr token = IntPtr.Zero;

                  if (AuthenticationUtils.Login(dlgLogin.Domain, dlgLogin.User, dlgLogin.PasswordToString(), out token))
                  {
                     WindowsPrincipal principal = Thread.CurrentPrincipal as WindowsPrincipal;

                     if (AuthenticationUtils.IsAdmin(principal) || AuthenticationUtils.IsDomainAdmin(principal))
                     {
                        string saveUser = dlgLogin.User;

                        if (!string.IsNullOrEmpty(dlgLogin.Domain))
                           saveUser = dlgLogin.Domain + "\\" + dlgLogin.User;

                        Config.Set<string>("LastUser", saveUser);
                        return true;
                     }
                     else
                     {
                        MessageBox.Show(this, "User is not a member of Administrators group.", "Invalid User",
                                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                     }
                  }
                  else
                  {
                     Win32Exception e = new Win32Exception(Marshal.GetLastWin32Error());

                     MessageBox.Show(this, e.Message, "Authentication Error",
                                     MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                  }
               }
               else
                  break;
            }
         }
         return false;
      }
   }
}

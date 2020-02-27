// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Windows.Forms;
using Microsoft.Win32;
using Leadtools.Demos;
using System.DirectoryServices.AccountManagement;
using System.Runtime.InteropServices;

namespace Leadtools.AuthenticateAction.Agent.UI
{
    public partial class LoginDialog : Form
    {
        [DllImport("User32.dll")]
        public static extern Int32 SetForegroundWindow(int hWnd);        

        private string _Logon = string.Empty;
        private ActiveScenario _ActiveScenario = null;

        public string Logon
        {
            get
            {
                return _Logon;
            }
        }

        private string _FullName = string.Empty;

        public string FullName
        {
            get
            {
                return _FullName;
            }
        }

        public string InstallLocation
        {
            get
            {
                string regKey = string.Empty;
                string location = string.Empty;

                regKey = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\{5ADEDEED-1ED0-40F7-88A7-C6D485CDBDBD}";
                if (regKey.Length != 0)
                {
                    RegistryKey key = Registry.LocalMachine.OpenSubKey(regKey);

                    if (key != null)
                    {
                        object value = key.GetValue("InstallLocation");

                        key.Close();
                        if (value != null)
                            location = value.ToString();
                    }
                }

                if (location == string.Empty)
                {
                    location = System.Windows.Forms.Application.StartupPath;
                }
                return location;
            }
        }

        public LoginDialog()
        {
            InitializeComponent();
        }

        private void LoginDialog_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult == DialogResult.OK)
            {
                string fullName = string.Empty;

                if (Authenticate(out fullName))
                {
                    _Logon = comboBoxUsername.Text;
                    _FullName = fullName;
                }
                else
                {
                    MessageBox.Show("Invalid user name or password.", "Authorization Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    e.Cancel = true;
                    textBoxPassword.Focus();
                }
            }
        }

        private void LoginDialog_Load(object sender, EventArgs e)
        {
            _ActiveScenario = ActiveScenario.Load();
            LoadMasterUsers();
            Application.Idle += new EventHandler(Application_Idle);
        }

        void Application_Idle(object sender, EventArgs e)
        {
            buttonOK.Enabled = comboBoxUsername.Text.Length > 0 && !comboBoxUsername.DroppedDown;
        }

        private void LoadMasterUsers()
        {
            foreach (MasterUser user in _ActiveScenario.Scenario.MasterUserIndex)
            {
                comboBoxUsername.Items.Add(user);
            }
        }

        private bool Authenticate(out string fullName)
        {            
            fullName = string.Empty;
            if (_ActiveScenario.Scenario != null)
            {
                MasterUser mu = null;

                foreach (MasterUser user in _ActiveScenario.Scenario.MasterUserIndex)
                {
                    if (user.Username == textBoxPassword.Text)
                    {
                        mu = user;
                        break;
                    }
                }

               if (mu != null)
               {
                  fullName = mu.Name;
                  if (mu.DomainLogin)
                  {
                     //
                     // Domain Login is selected for the user.
                     //
                     using (PrincipalContext context = new PrincipalContext(ContextType.Domain, mu.Domain))
                     {
                        bool valid = context.ValidateCredentials(mu.Username, textBoxPassword.Text);

                        return valid;
                     }
                  }
                  else
                  {
                     if (mu.Password == textBoxPassword.Text)
                        return true;
                  }
               }
            }            
            return false;
        }

        private void LoginDialog_Shown(object sender, EventArgs e)
        {
            comboBoxUsername.Focus();
        }

        private void comboBoxUsername_SelectedIndexChanged(object sender, EventArgs e)
        {
           MasterUser mu = comboBoxUsername.SelectedItem as MasterUser;

           if (mu != null)
              if (!mu.DomainLogin)
              {
                 textBoxPassword.ReadOnly = true;
                 textBoxPassword.Text = mu.Password;
              }
              else
              {
                 textBoxPassword.ReadOnly = false;
                 textBoxPassword.Text = string.Empty;
              }
        }
    }
}

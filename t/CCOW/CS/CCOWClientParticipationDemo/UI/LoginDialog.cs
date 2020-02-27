// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Windows.Forms;
using Leadtools.Demos;

namespace CCOWClientParticipationDemo.UI
{
    public partial class LoginDialog : Form
    {
        private CCOWApplication _CCOWApplication;

        public bool EnableUser
        {
            get
            {
                return comboBoxUsername.Enabled;
            }
            set
            {
                comboBoxUsername.Enabled = value;
            }
        }

        private string _Username = string.Empty;

        public string Username
        {
            get
            {
                return comboBoxUsername.Text;
            }
            set
            {
                _Username = value;
            }
        }

        public string Password
        {
            get
            {
                return textBoxPassword.Text;
            }
            set
            {
                textBoxPassword.Text = value;
            }
        }

        public bool FirstLogin
        {
            get
            {
                return labelFirstLogin.Visible;
            }
            set
            {
                labelFirstLogin.Visible = value;
            }
        }

        public LoginDialog(CCOWApplication application)
        {
            InitializeComponent();
            _CCOWApplication = application;
        }

        private void LoginDialog_Load(object sender, EventArgs e)
        {           
            LoadUsers();
        }

        private void LoadUsers()
        {
            foreach (User user in _CCOWApplication.Users)
            {
                int index = comboBoxUsername.Items.Add(user);

                if (user.Username == _Username)
                {
                    comboBoxUsername.SelectedIndex = index;
                }
            }
        }

        private void LoginDialog_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult == DialogResult.OK)
            {
                e.Cancel = !Authenticate();
                if (e.Cancel)
                {
                    MessageBox.Show("Invalid password for user.", "Authorization Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private bool Authenticate()
        {
            foreach(User user in _CCOWApplication.Users)
            {
                if (user.Username == comboBoxUsername.Text && user.Password == textBoxPassword.Text)
                    return true;
            }
            return false;
        }

        private void comboBoxUsername_SelectedIndexChanged(object sender, EventArgs e)
        {
           User user = comboBoxUsername.SelectedItem as User;

           if (user != null)
              if (!user.DomainLogin)
              {
                 textBoxPassword.ReadOnly = true;
                 textBoxPassword.Text = user.Password;
              }
              else
              {
                 textBoxPassword.ReadOnly = false;
                 textBoxPassword.Text = string.Empty;
              }
        }
    }
}

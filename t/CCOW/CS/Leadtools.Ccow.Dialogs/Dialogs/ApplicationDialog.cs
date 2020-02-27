// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Windows.Forms;
using Leadtools.Ccow.Server.Data;

namespace Leadtools.Ccow.Dialogs
{
    public partial class ApplicationDialog : Form
    {
        private CCOWApplication _App;

        public CCOWApplication App
        {
            get { return _App; }
            set { _App = value; }
        }

        public ApplicationDialog()
        {
            InitializeComponent();
            Active.Checked = true;
        }

        public ApplicationDialog(CCOWApplication application)
            : this()
        {
            _App = application;
            AppName.Text = _App.Name;
            Passcode.Text = _App.Passcode;
            Active.Checked = _App.Allowed.Value;
            Suffix.Text = _App.Suffix;
            Text = "Edit Application";
        }

        private void AddApplicationDialog_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult == DialogResult.OK)
            {
                if (_App == null)
                {
                    _App = new CCOWApplication();
                    _App.Id = Guid.NewGuid();
                }

                _App.Name = AppName.Text;
                _App.Passcode = Passcode.Text;
                _App.Allowed = Active.Checked;
                _App.Suffix = Suffix.Text;
            }
        }

        private void ApplicationDialog_Load(object sender, EventArgs e)
        {            
        }
    }
}

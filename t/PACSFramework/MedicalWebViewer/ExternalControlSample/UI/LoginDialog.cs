// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Leadtools.Medical.WebViewer.ExternalControl;

namespace ExternalControlSample
{
   public partial class LoginDialog : Form
   {
      public LoginDialog()
      {
         InitializeComponent();
         this.radioButtonInteretExplorer.Checked = true;
      }

      private MedicalWebViewerExternalController _controller;
      private int _timeout;
      private int _port;
      private string _userName;     
      private string _password;

      public int Port
      {
         get { return _port; }
         set { _port = value; }
      }

      public int Timeout
      {
         get { return _timeout; }
         set { _timeout = value; }
      }

      public string UserName
      {
         get { return _userName; }
         set 
         { 
            _userName = value;
            textBoxUser.Text = _userName;
         }
      }


      public string Password
      {
         get { return _password; }
         set 
         { 
            _password = value;
            textBoxPassword.Text = _password;
         }
      }

      public MedicalWebViewerExternalController Controller
      {
         get { return _controller; }
         set { _controller = value; }
      }

      ControllerReturnCode Start()
      {
         var applicationName = string.Empty;
         var version = string.Empty;

         _controller.Timeout = _timeout;

         if (_controller.IsStarted)
         {
            _controller.Shutdown();
         }

         ControllerReturnCode ret = _controller.InitApplication(out applicationName, out version, _port);
         Logger.LogControllerResult("InitApplication", ret);

         if (ret == ControllerReturnCode.Success)
         {
            Logger.LogMessage(
               string.Empty,
               string.Format("ApplicationName: {0}", applicationName),
               string.Format("Version: {0} ", version),
               string.Format("Timeout: {0} ", _timeout.ToString()),
               string.Format("Port: {0} ", _port.ToString())
               );
         }

         return ret;
      }

      ControllerReturnCode Login()
      {
         string username = textBoxUser.Text.Trim();
         string password = textBoxPassword.Text.Trim();
         ControllerReturnCode ret = _controller.UserLogin(textBoxUser.Text, textBoxPassword.Text);
         Logger.LogControllerResult("UserLogin", ret);
         if (ret == ControllerReturnCode.Success)
         {
            Logger.LogMessage(
                              string.Empty,
                              string.Format("UserName: {0}", username),
                              string.Format("Password: {0} ", password));
         }
         return ret;
      }

      public MedicalWebViewerBrowser SelectedBrowser
      {
         get
         {
            MedicalWebViewerBrowser selectedBrowser = MedicalWebViewerBrowser.Default;
            if (radioButtonInteretExplorer.Checked)
               selectedBrowser = MedicalWebViewerBrowser.InternetExplorer;
            else if (radioButtonEdge.Checked)
               selectedBrowser = MedicalWebViewerBrowser.Edge;
            else if (radioButtonChrome.Checked)
               selectedBrowser = MedicalWebViewerBrowser.GoogleChrome;
            else if (radioButtonFireFox.Checked)
               selectedBrowser = MedicalWebViewerBrowser.Firefox;
            return selectedBrowser;
         }
         set
         {
            switch (value)
            {
               case MedicalWebViewerBrowser.Firefox:
                  radioButtonFireFox.Checked = true;
                  break;

               case MedicalWebViewerBrowser.GoogleChrome:
                  radioButtonChrome.Checked = true;
                  break;

               case MedicalWebViewerBrowser.Edge:
                  radioButtonEdge.Checked = true;
                  break;

               case MedicalWebViewerBrowser.InternetExplorer:
                  radioButtonInteretExplorer.Checked = true;
                  break;

               default:
                  radioButtonInteretExplorer.Checked = true;
                  break;
            }
         }
      }

      private void buttonLogin_Click(object sender, EventArgs e)
      {
         _controller.SelectedBrowser = SelectedBrowser;
         ControllerReturnCode ret = Start();
         if (ret == ControllerReturnCode.Success)
         {
            ret = Login();
         }
         if (ret == ControllerReturnCode.Success)
         {
            this.DialogResult = DialogResult.OK;
            _userName = textBoxUser.Text.Trim();
            _password = textBoxPassword.Text.Trim();
            Close();
         }
      }

      private void LoginDialog_Shown(object sender, EventArgs e)
      {
          textBoxUser.Focus();
      } 
   }
}

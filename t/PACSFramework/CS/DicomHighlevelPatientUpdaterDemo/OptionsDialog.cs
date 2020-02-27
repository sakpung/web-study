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
using System.IO;
using Leadtools.Dicom.Scu;
using System.Net;
using System.Text.RegularExpressions;
using DicomDemo.Utils;
using System.Runtime.InteropServices;
using Microsoft.WindowsAPICodePack.Dialogs;
using DicomDemo.Dicom;

namespace DicomDemo
{
    public partial class OptionsDialog : Form
    {                        
        private string _ServerAE;

        public string ServerAE
        {
            get { return _ServerAE; }
            set { _ServerAE = value; }
        }

        private string _ServerIP;

        public string ServerIP
        {
            get { return _ServerIP; }
            set { _ServerIP = value; }
        }

        private int _ServerPort = 104;

        public int ServerPort
        {
            get { return _ServerPort; }
            set { _ServerPort = value; }
        }

        private string _ClientAE;

        public string ClientAE
        {
            get { return _ClientAE; }
            set { _ClientAE = value; }
        }

        private int _Timeout = 30;

        public int Timeout
        {
            get { return _Timeout; }
            set { _Timeout = value; }
        }

        public OptionsDialog()
        {
            InitializeComponent();
        }        

        private bool CheckInteger(TextBox tb, Label lb, bool showError)
        {
            try
            {
                Convert.ToInt32(tb.Text);
                return true;
            }
            catch (Exception)
            {
                if (showError)
                {
                    if (tb.Text.Trim() == string.Empty)
                        MessageBox.Show("Invalid " + lb.Text, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    tb.SelectAll();
                    tb.Focus();
                    DialogResult = DialogResult.None;
                }
                return false;
            }
        }        

        private bool CheckIP(TextBox tb, Label lb, bool showError)
        {
            try
            {
               if(tb.Text.Contains(','))
                  System.Net.IPAddress.Parse(tb.Text);
                return true;
            }
            catch (Exception)
            {
                if (showError)
                {
                    if (tb.Text.Trim() == string.Empty)
                        MessageBox.Show("Invalid " + lb.Text, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    tb.SelectAll();
                    tb.Focus();
                    DialogResult = DialogResult.None;
                }
                return false;
            }
        }

        public bool IsValidIP(string addr)
        {
            //create our match pattern
            string pattern = @"^([1-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5])(\.([0-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5])){3}$";
            //create our Regular Expression object
            Regex check = new Regex(pattern);

            if (!addr.Contains('.'))
               return true;

            //boolean variable to hold the status
            bool valid = false;
            //check to make sure an ip address was provided
            if (addr == "")
            {
                //no address provided so return false
                valid = false;
            }
            else
            {
                //address provided so use the IsMatch Method
                //of the Regular Expression object
                valid = check.IsMatch(addr, 0);
            }
            //return the results
            return valid;
        }                               
       
        private void OptionsDialog_Load(object sender, EventArgs e)
        {
            _textBoxServerAE.Text = ServerAE;
            _textBoxServerIP.Text = ServerIP;
            _textBoxServerPort.Text = ServerPort.ToString();
            _textBoxClientAE.Text = ClientAE;            
            _textBoxTimeout.Text = Timeout.ToString();               

            Application.Idle += new EventHandler(Application_Idle);
        }

        void Application_Idle(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(_textBoxServerIP.Text) || string.IsNullOrEmpty(_textBoxServerAE.Text) ||
               string.IsNullOrEmpty(_textBoxServerPort.Text))
            {
                VerifyButton.Enabled = false;
            }
            else
            {
                VerifyButton.Enabled = IsValidIP(_textBoxServerIP.Text) && CheckInteger(_textBoxServerPort,null,false);                                       
            }
        }

        private void _textBoxServerIP_KeyPress(object sender, KeyPressEventArgs e)
        {
            //bool bValid = Char.IsNumber(e.KeyChar) || (e.KeyChar == '.') || Char.IsControl(e.KeyChar);

            //e.Handled = !bValid;
        }

        private void _textBoxServerPort_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsDigit(e.KeyChar) || Char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
        }

        private void VerifyButton_Click(object sender, EventArgs e)
        {
            DicomScp scp = new DicomScp();
            PatientUpdaterConnection scu = new PatientUpdaterConnection();

            scp.AETitle = _textBoxServerAE.Text;
            scp.PeerAddress = ResolveIPAddress(_textBoxServerIP.Text);
            scp.Port = Convert.ToInt32(_textBoxServerPort.Text);
            scu.AETitle = _textBoxClientAE.Text;            
            try
            {
                bool ret = scu.Verify(scp);
                string scpInfo = scp.PeerAddress.ToString() + " (" + scp.Port.ToString() + ")";

                if (!scu.Rejected)
                {
                    if (ret)
                    {
                        TaskDialogHelper.ShowMessageBox(this, "Successful Verification", "Verified " + scp.AETitle, string.Empty,
                                                        scpInfo, TaskDialogStandardButtons.Ok, TaskDialogStandardIcon.Information, null);
                    }
                    else
                    {
                        TaskDialogHelper.ShowMessageBox(this, "Failed Verification", "Unable to verify " + scp.AETitle, string.Empty,
                                                        scpInfo, TaskDialogStandardButtons.Ok, TaskDialogStandardIcon.Error, null);
                    }
                }
                else
                {                    
                    TaskDialogHelper.ShowMessageBox(this, "Failed Verification", "Unable to verify " + scp.AETitle, scu.Reason,
                                                          scpInfo, TaskDialogStandardButtons.Ok, TaskDialogStandardIcon.Error, null);
                }
            }
            catch (Exception ex)
            {
                ApplicationUtils.ShowException(this, ex);
            }
        }

        public static System.Net.IPAddress ResolveIPAddress(string hostNameOrAddress)
        {
           IPAddress[] addresses;
           addresses = Dns.GetHostAddresses(hostNameOrAddress.Trim());
           if (addresses == null || addresses.Length == 0)
           {
              throw new ArgumentException("Invalid hostNameOrAddress parameter.");
           }
           else
           {
              IPAddress address = (from a in addresses.OfType<IPAddress>()
                                   where a.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork
                                   select a).FirstOrDefault();

              if (address == null)
              {
                 address = (from a in addresses.OfType<IPAddress>()
                            where a.AddressFamily == System.Net.Sockets.AddressFamily.InterNetworkV6
                            select a).FirstOrDefault();
              }

              if (address != null)
                 return address;

              throw new ArgumentException("Could not resolve a valid host Address. Address must conform to IPv4 or IPv6.");
           }
        }

        private void OptionsDialog_FormClosing(object sender, FormClosingEventArgs e)
        {
           if (DialogResult == DialogResult.OK)
           {
              if (!CheckIP(_textBoxServerIP, _labelServerIP, true))
              {
                 e.Cancel = true;
                 return;
              }

              if (!CheckInteger(_textBoxServerPort, _labelServerPort, true))
              {
                 e.Cancel = true;
                 return;
              }

              if (!CheckInteger(_textBoxTimeout, _labelTimeout, true))
              {
                 e.Cancel = true;
                 return;
              }

              ServerAE = _textBoxServerAE.Text;
              ServerIP = _textBoxServerIP.Text;
              ServerPort = Convert.ToInt32(_textBoxServerPort.Text);
              ClientAE = _textBoxClientAE.Text;
              Timeout = Convert.ToInt32(_textBoxTimeout.Text);
           }
        }

        private void OptionsDialog_Shown(object sender, EventArgs e)
        {
           _textBoxServerAE.Focus();
        }                
    }
}

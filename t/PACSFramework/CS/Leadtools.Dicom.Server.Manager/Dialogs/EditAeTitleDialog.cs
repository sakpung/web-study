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
using System.Windows.Forms;
using System.Text.RegularExpressions;
using Leadtools.Dicom.AddIn.Common;
using Leadtools.Dicom.Server.Manager.Properties;
using System.Net;

namespace Leadtools.Dicom.Server.Manager.Dialogs
{
    public partial class EditAeTitleDialog : Form
    {
        private AeInfo _AeInfo = null;

        public AeInfo AeInfo
        {
            get
            {
                return _AeInfo;
            }
        }

        public EditAeTitleDialog(AeInfo info)
        {
            InitializeComponent();
            _AeInfo = info;
            if (_AeInfo == null)
                Text = Resources.AddAeTitle;
            else
                Text = Resources.EditAeTitle;

            InitializeStrings();
            Icon = Resources.ApplicationIcon;
        }

        private void InitializeStrings()
        {
            labelAeTitle.Text = Resources.AeTitleLabel + ":";
            radioButtonHost.Text = Resources.HostnameLabel;
            radioButtonIp.Text = Resources.IPAddressLabel;
            labelPort.Text = Resources.PortLabel + ":";
            labelSecurePort.Text = Resources.SecurePortColumnLabel + ":";

            buttonOk.Text = Resources.OkText;
            buttonCancel.Text = Resources.CancelText;
        }

        private void EditAeTitleDialog_Load(object sender, EventArgs e)
        {
            if (_AeInfo == null)
            {
                radioButtonHost.Checked = false;                
                Hostname.Enabled = false;
                radioButtonIp.Checked = true;
            }
            else
            {
                System.Net.IPAddress ip = System.Net.IPAddress.None;

                AETitle.Text = _AeInfo.AETitle;
                if (!System.Net.IPAddress.TryParse(_AeInfo.Address, out ip))
                {
                    radioButtonIp.Checked = false;                    
                    radioButtonHost.Checked = true;
                    textboxIPAddress.Enabled = false;
                    Hostname.Text = _AeInfo.Address;
                }
                else
                {
                    radioButtonHost.Checked = false;                    
                    radioButtonIp.Checked = true;
                    Hostname.Enabled = false;
                    textboxIPAddress.Text = _AeInfo.Address;
                }                

                Port.Value = Convert.ToDecimal(_AeInfo.Port);
                SecurePort.Value = Convert.ToDecimal(_AeInfo.SecurePort);
            }
            AETitle_TextChanged(null, EventArgs.Empty);
            buttonOk.Enabled = IsValidData();
        }

        private bool IsAlphaNumeric(string check)
        {
            Regex objAlphaNumericPattern = new Regex("[^a-zA-Z0-9]");

            return !objAlphaNumericPattern.IsMatch(check);  
        }

        private void EditAeTitleDialog_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult == DialogResult.OK)
            {
                if (_AeInfo == null)
                {
                    _AeInfo = new AeInfo();
                }

                _AeInfo.AETitle = AETitle.Text;
                if (radioButtonHost.Checked)
                {
                    _AeInfo.Address = Hostname.Text;                    
                }
                else
                {
                    _AeInfo.Address = textboxIPAddress.Text;                   
                }
                _AeInfo.Port = Convert.ToInt32(Port.Value);
                _AeInfo.SecurePort = Convert.ToInt32(SecurePort.Value);                
            }
        }

        private void radioButtonHost_CheckedChanged(object sender, EventArgs e)
        {
            radioButtonIp.Checked = !radioButtonHost.Checked;
            Hostname.Enabled = radioButtonHost.Checked;
            buttonOk.Enabled = IsValidData();
        }

        private void radioButtonIp_CheckedChanged(object sender, EventArgs e)
        {
            radioButtonHost.Checked = !radioButtonIp.Checked;
            textboxIPAddress.Enabled = radioButtonIp.Checked;
            buttonOk.Enabled = IsValidData();
        }

        private bool IsHex(char c)
        {
           return Char.IsLetterOrDigit(c) && Char.ToLower(c) <= 'f';
        }

       private void IPAddress_KeyPress(object sender, KeyPressEventArgs e)
       {
          bool bValid = IsHex(e.KeyChar) || (e.KeyChar == '.') || (e.KeyChar == ':') || Char.IsControl(e.KeyChar);
          e.Handled = !bValid;
       }

       private bool IsValidData()
       {
          bool bValid = false;
          bValid = AETitle.Text.Trim() != string.Empty;
          if (bValid)
          {
             if (radioButtonHost.Checked)
                bValid = (Hostname.Text.Trim() != string.Empty);
          }
          if (bValid)
          {
             if (radioButtonIp.Checked)
             {
                IPAddress address ;
                bValid = IPAddress.TryParse(textboxIPAddress.Text, out address);
             }
          }
          return bValid;
       }

       private void AETitle_TextChanged(object sender, EventArgs e)
       {
          buttonOk.Enabled = IsValidData();
       }

       private void Hostname_TextChanged(object sender, EventArgs e)
       {
          buttonOk.Enabled = IsValidData();
       }

       private void IPAddress_TextChanged(object sender, EventArgs e)
       {
          buttonOk.Enabled = IsValidData();
       }
    }
}

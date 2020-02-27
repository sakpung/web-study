// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Net;
using System.Text;
using System.Windows.Forms;

using Leadtools.Dicom;
using Leadtools.DicomDemos;
using Leadtools.DicomDemos.Scu.CEcho;

namespace DicomDemo
{
    public partial class Page1 : UserControl
    {
        private Globals _globals;
        private CEcho _cecho;

        const string CONFIGURATION_IMPLEMENTATIONCLASS = "1.2.840.114257.1123456";
        const string CONFIGURATION_IMPLEMENTATIONVERSIONNAME = "1";
        const string CONFIGURATION_PROTOCOLVERSION = "1";

        public Page1(ref Globals pGlobals)
        {
            InitializeComponent();

            // Set up globals
            _globals = pGlobals;

            _globals.bMWLServerValid = false;
        }

        /*
         * Disables the next button since server settings were changed and we don't know if the
         *   client/server information is valid.
         */
        private void settingsChanged()
        {
           _globals.bMWLServerValid = false;
           ((MainForm)ParentForm).btnNext.Enabled = _globals.bMWLServerValid;
        }

        /*
         * Sends a CEcho request to the server to verify that the client/server info is valid
         */
        private void btnVerify_Click(object sender, EventArgs e)
        {
            try
            {
                txtLog.Text = "";

                // update changed settings
                _globals.m_MWLServer.AETitle = txtServerAE.Text;
                _globals.m_MWLServer.Address = IPAddress.Parse(txtServerIP.Text);
                _globals.m_MWLServer.Port = Convert.ToInt32(txtServerPort.Text);
                _globals.m_strMWLClientAE = txtClientAE.Text;

                // Send a CEcho to check the settings
                EnableControls(false);
                
                CEcho cecho = new CEcho();

                cecho.ImplementationClass = CONFIGURATION_IMPLEMENTATIONCLASS;
                cecho.ImplementationVersionName = CONFIGURATION_IMPLEMENTATIONVERSIONNAME;
                cecho.ProtocolVersion = CONFIGURATION_PROTOCOLVERSION;
                cecho.Status += new StatusEventHandler(cecho_Status);
                _cecho = cecho ;
                cecho.Echo(_globals.m_MWLServer, _globals.m_strMWLClientAE);
            }
            catch (FormatException ex)
            {
                if (ex.Message ==  "An invalid IP address was specified.")
                    MessageBox.Show("The specified IP address is invalid.");
                else
                    MessageBox.Show("Error:\r\n" + ex.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:\r\n" + ex.ToString());
            }
        }

        private void Page1_Load(object sender, EventArgs e)
        {
            try
            {
                // Initialize text boxes
                txtServerAE.Text = _globals.m_MWLServer.AETitle;
                txtServerIP.Text = _globals.m_MWLServer.Address.ToString();
                txtServerPort.Text = _globals.m_MWLServer.Port.ToString();
                txtClientAE.Text = _globals.m_strMWLClientAE;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void txtServerAE_TextChanged(object sender, EventArgs e)
        {
            settingsChanged();
        }

        private void txtServerIP_TextChanged(object sender, EventArgs e)
        {
            settingsChanged();
        }

        private void txtServerPort_TextChanged(object sender, EventArgs e)
        {
            settingsChanged();
        }

        private void txtClientAE_TextChanged(object sender, EventArgs e)
        {
            settingsChanged();
        }

        /*
         * Provides feedback regarding the CEcho request
         */
        private void cecho_Status(object sender, StatusEventArgs e)
        {
           try
           {
              string message = "";
              bool done = false;

              if (e.Type == StatusType.Error)
              {
                 message = "DICOM error. The process will be terminated! -- Error code is: " + e.Error.ToString();
              }
              else
              {
                 switch (e.Type)
                 {
                    case StatusType.ConnectFailed:
                       message = "Connect operation failed.\r\n";
                       message += "\tError: " + e.Error.ToString();
                       done = true;
                       break;
                    case StatusType.ConnectSucceeded:
                       message = "Connected successfully.\r\n";
                       message += "\tPeer Address:\t" + e.PeerIP.ToString() + "\r\n";
                       message += "\tPeer Port:\t\t" + e.PeerPort.ToString();
                       break;
                    case StatusType.SendAssociateRequest:
                       message = "Sending association request...";
                       break;
                    case StatusType.ReceiveAssociateAccept:
                       message = "Received Associate Accept.\r\n";
                       message += "\tCalling AE:\t" + e.CallingAE + "\r\n";
                       message += "\tCalled AE:\t" + e.CalledAE;
                       break;
                    case StatusType.ReceiveAssociateReject:
                       message = "Received Associate Reject! \r\n";
                       message += "\tResult: " + e.Result.ToString() + "\r\n";
                       message += "\tReason: " + e.Reason.ToString() + "\r\n";
                       message += "\tSource: " + e.Source.ToString();
                       break;
                    case StatusType.AbstractSyntaxNotSupported:
                       message = "Abstract Syntax NOT supported!";
                       break;
                    case StatusType.ConnectionClosed:
                       message = "Network Connection closed!";
                       done = true;
                       break;
                    case StatusType.ProcessTerminated:
                       message = "Process has been terminated!";
                       done = true;
                       break;
                    case StatusType.SendCEchoRequest:
                       message = "Sending CEcho request...";
                       break;
                    case StatusType.ReceiveCEchoResponse:
                       message = "Received CEcho response.\r\n";
                       message += "\tPresentation ID: " + e.PresentationID.ToString() + "\r\n";
                       message += "\tMessage ID: " + e.MessageID.ToString() + "\r\n";
                       message += "\tAffected Class: " + e.AffectedClass.ToString();
                       if (e._Error == DicomExceptionCode.Success)
                          _globals.bMWLServerValid = true;
                       break;
                    case StatusType.SendReleaseRequest:
                       message = "Sending release request...";
                       break;
                    case StatusType.ReceiveReleaseResponse:
                       message = "Receiving release response";
                       done = true;
                       break;
                    case StatusType.Timeout:
                       message = "Communication timeout. Process will be terminated.";
                       done = true;
                       break;
                 }
              }
              LogText(message);
              if (done)
              {
                 EnableControls(true);

                    if ( null != _cecho && _cecho.IsConnected())
                    {
                        _cecho.Close();
                        _cecho.Dispose ( ) ;
                        _cecho = null ;
                     }
              }
           }
           catch (Exception ex)
           {
              MessageBox.Show(ex.ToString());
           }
        }

        public delegate void LogTextDelegate(string sentence);        
        public void LogText(string logText)
        {
           if (Globals._closing == true || this.Disposing || this.IsDisposed)
              return;

           if (InvokeRequired)
           {
              try
              {
                 Invoke(new LogTextDelegate(LogText), new object[] { logText });
              }
              catch (Exception ex)
              {
                 if (Globals._closing == false)
                    throw ex;
              }
           }
           else
           {
              try
              {
                 if (txtLog.Disposing == false)
                 {
                    txtLog.Text = txtLog.Text + logText + "\r\n";
                    txtLog.SelectionStart = txtLog.Text.Length;
                    txtLog.ScrollToCaret();
                 }
              }
              catch (Exception ex)
              {
                 if (Globals._closing == false)
                    MessageBox.Show(ex.ToString());
              }
           }
        }

        /*
         * Enables or disables controls
         */
        public delegate void EnableControlsDelegate(bool enable);
        private void EnableControls(bool enable)
        {
           if (Globals._closing == true || this.Disposing || this.IsDisposed)
              return;
            if (this.InvokeRequired)
            {
                Invoke(new EnableControlsDelegate(EnableControls), new object[] { enable });
            }
            else
            {
                try
                {
                    txtServerAE.Enabled = enable;
                    txtServerIP.Enabled = enable;
                    txtServerPort.Enabled = enable;
                    txtClientAE.Enabled = enable;
                    btnVerify.Enabled = enable;

                    ((MainForm)Parent.Parent).btnNext.Enabled = _globals.bMWLServerValid;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }
    }
}

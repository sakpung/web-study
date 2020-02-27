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
using Leadtools.DicomDemos.Scu.CStore;

namespace DicomDemo
{
    public partial class Page6 : UserControl
    {
        private Globals _globals;
        private CStore cstore;
        private string m_strTemporaryDicomFileName = Environment.GetEnvironmentVariable("TEMP") + "\\temp.dcm";

        const string CONFIGURATION_IMPLEMENTATIONCLASS = "1.2.840.114257.1123456";
        const string CONFIGURATION_IMPLEMENTATIONVERSIONNAME = "1";
        const string CONFIGURATION_PROTOCOLVERSION = "1";

        public Page6(ref Globals pGlobals)
        {
            InitializeComponent();

            _globals = pGlobals;


            cstore = new CStore();

            cstore.ImplementationClass = CONFIGURATION_IMPLEMENTATIONCLASS;
            cstore.ImplementationVersionName = CONFIGURATION_IMPLEMENTATIONVERSIONNAME;
            cstore.ProtocolVersion = CONFIGURATION_PROTOCOLVERSION;
            cstore.Status += new StatusEventHandler(cstore_Status);
        }

        private void radServer_CheckedChanged(object sender, EventArgs e)
        {
            ToggleControls();
        }

        private void radLocal_CheckedChanged(object sender, EventArgs e)
        {
            ToggleControls();
        }

        /*
         * Toggles the text boxes' Enabled property based on whether the user is storing 
         *   on a server or locally.
         */
        private void ToggleControls()
        {
            try
            {
                _globals.m_bStoreOnServer = radServer.Checked;
                txtServerAE.Enabled = _globals.m_bStoreOnServer;
                txtServerIP.Enabled = _globals.m_bStoreOnServer;
                txtServerPort.Enabled = _globals.m_bStoreOnServer;
                txtClientAE.Enabled = _globals.m_bStoreOnServer;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.ToString());
            }
        }

        /*
         * Enables or disables all of the controls
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
                    radServer.Enabled = enable;
                    radLocal.Enabled = enable;
                    txtServerAE.Enabled = enable;
                    txtServerIP.Enabled = enable;
                    txtServerPort.Enabled = enable;
                    txtClientAE.Enabled = enable;

                    ((MainForm)Parent.Parent).btnNext.Enabled = enable;
                }
                catch (Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show(ex.ToString());
                }
            }
        }

        private void Page6_Load(object sender, EventArgs e)
        {
            try
            {
                if (_globals.m_bStoreOnServer)
                    radServer.Checked = true;
                else
                    radLocal.Checked = true;

                // Initialize text boxes
                txtServerAE.Text = _globals.m_StorageServer.AETitle;
                txtServerIP.Text = _globals.m_StorageServer.Address.ToString();
                txtServerPort.Text = _globals.m_StorageServer.Port.ToString();
                txtClientAE.Text = _globals.m_strStorageClientAE;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.ToString());
            }
        }

        /*
         * Stores the dataset locally or on a server
         */
        private void btnStore_Click(object sender, EventArgs e)
        {
            txtLog.Text = "";
            if (_globals.m_bStoreOnServer) // Send to storage server
            {
                try
                {
                    EnableControls(false);

                    // Update changed settings
                    _globals.m_StorageServer.AETitle = txtServerAE.Text;
                    _globals.m_StorageServer.Address = IPAddress.Parse(txtServerIP.Text);
                    _globals.m_StorageServer.Port = Convert.ToInt32(txtServerPort.Text);
                    _globals.m_strStorageClientAE = txtClientAE.Text;

                    // Temporarily save the dataset to disk for the CStore process
                    _globals.m_DS.Save(m_strTemporaryDicomFileName, DicomDataSetSaveFlags.LittleEndian | DicomDataSetSaveFlags.ExplicitVR | DicomDataSetSaveFlags.GroupLengths);
                    cstore.Files.Add(m_strTemporaryDicomFileName);
                    cstore.Store(_globals.m_StorageServer, _globals.m_strStorageClientAE);
                }
                catch (FormatException ex)
                {
                    if (ex.Message == "An invalid IP address was specified.")
                        MessageBox.Show("The specified IP address is invalid.");
                    else
                        MessageBox.Show(ex.ToString());
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            else // Store locally
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "DCM (*.dcm)|*.dcm|DICOM (*.dic)|*.dic|All Files (*.*)|*.*||";
                sfd.FilterIndex = 0;
                sfd.FileName = "mwl.dcm";
                if (sfd.ShowDialog(this) == DialogResult.OK)
                {
                    try
                    {
                        _globals.m_DS.Save(sfd.FileName, DicomDataSetSaveFlags.LittleEndian | DicomDataSetSaveFlags.ExplicitVR | DicomDataSetSaveFlags.GroupLengths);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error saving file: \r\n\r\n" + ex.ToString());
                    }
                }
            }
        }

        /*
         * Provides feedback on the status of the CStore process
         */
        private void cstore_Status(object sender, StatusEventArgs e)
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
                            message = "Connect operation failed.";
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
                            message = "Received Associate Reject!";
                            message += "\tResult: " + e.Result.ToString();
                            message += "\tReason: " + e.Reason.ToString();
                            message += "\tSource: " + e.Source.ToString();
                            break;
                        case StatusType.AbstractSyntaxNotSupported:
                            message = "Abstract Syntax NOT supported!";
                            break;
                        case StatusType.SendCStoreRequest:
                            message = "Sending C-STORE Request...";
                            break;
                        case StatusType.ReceiveCStoreResponse:
                            if (e.Error == DicomExceptionCode.Success)
                            {
                                message = "**** Storage completed successfully ****";
                            }
                            else
                            {
                                message = "**** Storage failed with status: " + e.Status.ToString();
                            }
                            break;
                        case StatusType.ConnectionClosed:
                            message = "Network Connection closed!";
                            done = true;
                            break;
                        case StatusType.ProcessTerminated:
                            message = "Process has been terminated!";
                            done = true;
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
                    //enable buttons
                    EnableControls(true);

                    //remove file name from CStore object and remove temporary file from disk
                    cstore.Files.Clear();
                    System.IO.File.Delete(m_strTemporaryDicomFileName);

                    if (cstore.IsConnected())
                        cstore.Close();
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.ToString());
            }
        }

        public delegate void LogTextDelegate(string sentence);
        public void LogText(string logText)
        {
           if (Globals._closing == true || this.Disposing || this.IsDisposed)
              return;
            if (InvokeRequired)
                Invoke(new LogTextDelegate(LogText), new object[] { logText });
            else
            {
                try
                {
                    txtLog.Text = txtLog.Text + logText + "\r\n";
                    txtLog.SelectionStart = txtLog.Text.Length;
                    txtLog.ScrollToCaret();
                }
                catch (Exception ex)
                {
                   if (Globals._closing == false)
                      System.Windows.Forms.MessageBox.Show(ex.ToString());
                }
            }
        }

    }
}

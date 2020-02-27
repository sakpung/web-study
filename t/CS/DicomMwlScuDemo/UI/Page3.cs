// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using Leadtools.Codecs;
using Leadtools.Dicom;
using Leadtools.DicomDemos;
using Leadtools.DicomDemos.Scu;
using Leadtools.DicomDemos.Scu.CFind;
using Leadtools.WinForms.CommonDialogs.File;

namespace DicomDemo
{
    public partial class Page3 : UserControl
    {
        private Globals _globals;

        private CFind cfind = new CFind();
        private CFindQuery dcmQuery;
        private bool m_bQuerySucceeded;

        public delegate void AddLog(string action, string logText);

        public Page3(ref Globals pGlobals)
        {
            InitializeComponent();

            _globals = pGlobals;
        }

        private void Page3_Load(object sender, EventArgs e)
        {
            m_bQuerySucceeded = false;

            // Assign events for the CFind query
            cfind.Status += new StatusEventHandler(cfind_Status);
            cfind.FindComplete +=new FindCompleteEventHandler(cfind_FindComplete);
        }

        /*
         * When an element tree node is selected, update the text box with the element data
         */
        void m_TreeResult_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                if (((MyTreeNode)e.Node).Parent == null) // root parent node
                {
                    btnSaveDS.Enabled = true;
                }
                else // child element node
                {
                    btnSaveDS.Enabled = false;

                    if (((MyTreeNode)e.Node).m_Element != null)
                    {
                       txtEditValue.Text = ((MyTreeNode)e.Node).m_DS.GetConvertValue(((MyTreeNode)e.Node).m_Element);
                    }
                    else
                    {
                        txtEditValue.Text = "";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        /*
         * When this page is made active, add the global MWL tree view and add or remove the AfterSelect
         *   event
         */
        private void Page3_VisibleChanged(object sender, EventArgs e)
        {
            try
            {
                if (Visible)
                {
                    EnableControls(true);

                    // Display the global results tree view
                    panelTreeView.Controls.Add(_globals.m_TreeResult);

                    // Add needed events from the tree
                    _globals.m_TreeResult.AfterSelect += new TreeViewEventHandler(m_TreeResult_AfterSelect);

                    // Build the query based on user data from Page 2
                    txtQuery.Text = "";
                    dcmQuery = new CFindQuery();
                    if (_globals.m_nQueryType == 1) // Broad
                    {
                        txtQuery.Text += "Broad Modality Work List Query\r\n";
                        if (_globals.m_bCheckScheduledDate)
                        {
                            dcmQuery.ScheduledDate = _globals.m_ScheduledDate;
                            txtQuery.Text += "\tScheduled Procedure Step Start Date: " + _globals.m_ScheduledDate + "\r\n";
                        }
                        else
                        {
                            txtQuery.Text += "\tScheduled Procedure Step Start Date:\r\n";
                        }

                        if (_globals.m_bCheckModality)
                        {
                            dcmQuery.Modality = _globals.m_strModality;
                            txtQuery.Text += "\tModality: " + _globals.m_strModality;
                        }
                        else
                        {
                            txtQuery.Text += "\tModality:";
                        }
                    }
                    else // Patient
                    {
                        txtQuery.Text += "Patient Based Query\r\n";
                        txtQuery.Text += "\tPatient Name: " + _globals.m_strPatientName + "\r\n";
                        dcmQuery.PatientName = _globals.m_strPatientName;
                        txtQuery.Text += "\tPatient ID: " + _globals.m_strPatientID + "\r\n";
                        dcmQuery.PatientID = _globals.m_strPatientID;
                        txtQuery.Text += "\tAccession Number: " + _globals.m_strAccessionNumber + "\r\n";
                        dcmQuery.AccessionNo = _globals.m_strAccessionNumber;
                        txtQuery.Text += "\tRequested Procedure ID: " + _globals.m_strRequestedProcedureID;
                        dcmQuery.RequestedProcedureID = _globals.m_strRequestedProcedureID;
                    }
                }
                else
                {
                    // Remove events from the tree since we're not using this page anymore
                    _globals.m_TreeResult.AfterSelect -= m_TreeResult_AfterSelect;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        /*
         * Save the MWL ds to disk
         */
        private void btnSaveDS_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "DCM (*.dcm)|*.dcm|DICOM (*.dic)|*.dic|All Files (*.*)|*.*||";
            sfd.FilterIndex = 0;
            sfd.FileName = "mwl.dcm";
            if (sfd.ShowDialog(this) == DialogResult.OK)
            {
                try
                {
                    ((MyTreeNode)_globals.m_TreeResult.SelectedNode).m_DS.Save(sfd.FileName, DicomDataSetSaveFlags.MetaHeaderPresent | DicomDataSetSaveFlags.LittleEndian | DicomDataSetSaveFlags.ExplicitVR | DicomDataSetSaveFlags.GroupLengths);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error saving file: \r\n\r\n" + ex.ToString());
                }
            }
        }

        /*
         * Send a CFind query to the MWL server
         */
        private void btnQueryServer_Click(object sender, EventArgs e)
        {
            try
            {
                m_bQuerySucceeded = false;
                StartUpdate(_globals.m_TreeResult);
                txtLog.Text = "";

                if (_globals.m_nQueryType == 1) // broad
                {
                    cfind.Find(_globals.m_MWLServer, FindType.MWLBroad, dcmQuery, _globals.m_strMWLClientAE);
                }
                else // patient
                {
                    cfind.Find(_globals.m_MWLServer, FindType.MWLPatient, dcmQuery, _globals.m_strMWLClientAE);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public void LogText(string action, string logText)
        {
           if (Globals._closing == true || this.Disposing || this.IsDisposed)
              return;
            if (this.InvokeRequired)
            {
                this.Invoke(new AddLog(LogText),
                   new object[] { action, logText });
            }
            else
            {
                try
                {
                    AddAction(action);
                    txtLog.AppendText(logText);
                    txtLog.AppendText("\r\n");
                }
                catch (Exception ex)
                {
                   if (Globals._closing == false)
                      MessageBox.Show(ex.ToString());
                }
            }
        }

        /*
         * Adds the action (CFind, CStore, etc.) to the beginning of the log text
         */
        private void AddAction(string action)
        {
            try
            {
                txtLog.SelectionLength = 0;
                txtLog.SelectionStart = txtLog.Text.Length;
                txtLog.AppendText(action + ": ");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        /*
         * Provides feedback regarding the CFind query.
         */
        private void cfind_Status(object sender, StatusEventArgs e)
        {
            try
            {
                string message = "Unknown Error";
                String action = "";
                bool done = false;

                if (e.Type == StatusType.Error)
                {
                    action = "Error";
                    message = "Error occurred.\r\n";
                    message += "\tError code is:\t" + e.Error.ToString();
                }
                else
                {
                    switch (e.Type)
                    {
                        case StatusType.ConnectFailed:
                            action = "Connect";
                            message = "Operation failed.";
                            done = true;
                            break;
                        case StatusType.ConnectSucceeded:
                            action = "Connect";
                            message = "Operation succeeded.\r\n";
                            message += "\tPeer Address:\t" + e.PeerIP.ToString() + "\r\n";
                            message += "\tPeer Port:\t\t" + e.PeerPort.ToString();
                            break;
                        case StatusType.SendAssociateRequest:
                            action = "Associate Request";
                            message = "Request sent.";
                            break;
                        case StatusType.ReceiveAssociateAccept:
                            action = "Associcated Accept";
                            message = "Received.\r\n";
                            message += "\tCalling AE:\t" + e.CallingAE + "\r\n";
                            message += "\tCalled AE:\t" + e.CalledAE;
                            break;
                        case StatusType.ReceiveAssociateRequest:
                            action = "Associcated Request";
                            message = "Received.\r\n";
                            message += "\tCalling AE:\t" + e.CallingAE + "\r\n";
                            message += "\tCalled AE:\t" + e.CalledAE;
                            break;
                        case StatusType.ReceiveAssociateReject:
                            action = "Associate Reject";
                            message = "Received Associate Reject!";
                            done = true;
                            break;
                        case StatusType.AbstractSyntaxNotSupported:
                            action = "Error";
                            message = "Abstract Syntax NOT supported!";
                            done = true;
                            break;
                        case StatusType.SendCFindRequest:
                            action = "C-FIND";
                            message = "Sending request";
                            break;
                         case StatusType.ReceiveCFindResponse:
                            action = "C-FIND Response";
                            if (e.Error == DicomExceptionCode.Success)
                            {
                               message = "Operation completed successfully.";
                            }
                            else
                            {
                               if (e.Status == DicomCommandStatusType.Pending || e.Status == DicomCommandStatusType.PendingWarning)
                               {
                                  message = string.Format("Status: {0}", e.Status);
                               }
                               else
                               {
                                  message = "Error in response Status code is: " + e.Status.ToString();
                               }
                            }
                            break;
                         case StatusType.ConnectionClosed:
                            action = "Connect";
                            message = "Network Connection closed!";
                            done = true;
                            break;
                        case StatusType.ProcessTerminated:
                            action = "";
                            message = "Process has been terminated!";
                            done = true;
                            break;
                        case StatusType.SendReleaseRequest:
                            action = "Release Request";
                            message = "Request sent.";
                            break;
                        case StatusType.ReceiveReleaseResponse:
                            action = "Release Response";
                            message = "Response received.";
                            done = true;
                            break;
                        case StatusType.SendCMoveRequest:
                            action = "C-MOVE";
                            message = "Sending request";
                            break;
                        case StatusType.ReceiveCMoveResponse:
                            action = "C-MOVE";
                            message = "Received response\r\n";
                            message += "\tStatus: " + e.Status.ToString() + "\r\n";
                            message += "\tNumber Completed: " + e.NumberCompleted.ToString() + "\r\n";
                            message += "\tNumber Remaining: " + e.NumberRemaining.ToString();
                            break;
                        case StatusType.SendCStoreResponse:
                            action = "C-STORE";
                            message = "Sending response";
                            break;
                        case StatusType.ReceiveCStoreRequest:
                            action = "C-STORE";
                            message = "Received request";
                            break;
                        case StatusType.Timeout:
                            message = "Communication timeout. Process will be terminated.";
                            done = true;
                            break;
                    }

                    LogText(action, message);
                    if (done && (e.Type != StatusType.ReceiveReleaseResponse))
                    {
                        // an error occured so we should end the update to the tree control,
                        // otherwise FindComplete will take care of calling EndUpdate
                        EndUpdate(_globals.m_TreeResult);
                    }
                }
            }
            catch (Exception ex)
            {
               if (Globals._closing == false)
                  MessageBox.Show(ex.ToString());
            }
        }

        /*
         * Fired when all matching datasets are found and will add each dataset into the tree
         */
        private void cfind_FindComplete(object sender, FindCompleteEventArgs e)
        {
            try
            {
                if (e.Datasets.Count > 0)
                {
                    LogText("C-FIND Complete", "Parsing " + e.Datasets.Count + " datasets and building TreeView...");
                    int count = 0;
                    foreach (DicomDataSet ds in e.Datasets)
                    {
                       Application.DoEvents();
                        _globals.m_TreeResult.BuildTreeFromDataset(ds, true);
                       string s = string.Format("...processing dataset {0} of {1}", count++, e.Datasets.Count);
                       LogText(s, "Building TreeView");
                    }
                    LogText("C-FIND Complete", "Done building TreeView");
                    m_bQuerySucceeded = true;
                }
                else
                {
                    MessageBox.Show("No items match the query.  Press the " + (char)34 + "Back" + (char)34+ " button to change your query.");
                    m_bQuerySucceeded = false;
                }
                EndUpdate(_globals.m_TreeResult);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        /*
         * Begins updating the tree and disables other controls during the process.
         */
        public delegate void StartUpdateDelegate(TreeView tv);
        private void StartUpdate(TreeView tv)
        {
           if (Globals._closing == true || this.Disposing || this.IsDisposed)
              return;
            if (InvokeRequired)
            {
                Invoke(new StartUpdateDelegate(StartUpdate), tv);
            }
            else
            {
                try
                {
                    btnSaveDS.Enabled = false;
                    EnableControls(false);
                    tv.Nodes.Clear();
                    tv.Refresh();
                    tv.BeginUpdate();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        /*
         * Ends the updating of the tree and re-enables controls
         */
        public delegate void EndUpdateDelegate(TreeView tv);
        private void EndUpdate(TreeView tv)
        {
           if (Globals._closing == true || this.Disposing || this.IsDisposed)
              return;
            if (InvokeRequired)
            {
                Invoke(new EndUpdateDelegate(EndUpdate), tv);
            }
            else
            {
                try
                {
                    EnableControls(true);
                    tv.EndUpdate();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        /*
         * Enables or disables controls
         */
        private delegate void EnableControlsDelegate(bool enable);
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
                    btnQueryServer.Enabled = enable;
                    ((MainForm)Parent.Parent).btnNext.Enabled = m_bQuerySucceeded;
                    ((MainForm)Parent.Parent).btnBack.Enabled = enable;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }
    }
}

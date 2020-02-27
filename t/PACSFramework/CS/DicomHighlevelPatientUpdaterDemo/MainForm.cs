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
using System.Resources;
using Leadtools.Dicom.Scu.Common;
using Leadtools.Dicom.Scu;
using System.IO;
using Leadtools.Dicom;
using System.Threading;
using System.Net;
using Leadtools.Dicom.Scu.Queries;
using DicomDemo.Utils;
using System.Diagnostics;
using DicomDemo.Dicom;
using System.Runtime.InteropServices;
using Microsoft.WindowsAPICodePack.Dialogs;
using System.Globalization;
using Leadtools.Demos;
using DicomDemo.Authentication;
using Leadtools.DicomDemos;

namespace DicomDemo
{
    public partial class MainForm : Form
    {
        private PatientRootQueryPatient _query = new PatientRootQueryPatient();
        private PatientUpdateQuery _find = null;
        
        // Settings
        public DicomDemoSettings _mySettings = new DicomDemoSettings();
        public string _demoName = Path.GetFileName(Application.ExecutablePath);

        private ListViewColumnSorter _patientSorter = new ListViewColumnSorter();
        private ListViewColumnSorter _seriesSorter = new ListViewColumnSorter();
        private Patient _CurrentPatient = null;
        private NActionScu _naction = null;
        private DicomScp _server = new DicomScp();
        private bool _patientSearch = false;

        private const string defaultServerAE = "LEAD_SERVER";
        private const string defaultServerIP = "127.0.0.1";
        private const int defaultServerPort = 104;
        private const int defaultServerTimeout = 30;
        private const bool defaultServerUseTls = false;

        private const string defaultClientAE = "LEAD_CLIENT";
        private const int defaultClientPort = 1000;
        private DicomDemoSettings DefaultSettings()
        {
           DicomDemoSettings settings = new DicomDemoSettings();
           settings.ClientAe.AE = defaultClientAE;
           settings.ClientAe.Port = defaultServerPort;
           DicomAE serverAE = new DicomAE();
           serverAE.AE = defaultServerAE;
           serverAE.IPAddress = defaultServerIP;
           serverAE.Port = defaultServerPort;
           serverAE.Timeout = defaultServerTimeout;
           serverAE.UseTls = defaultServerUseTls;
           settings.ServerList.Add(serverAE);
           SetOtherDefaults(settings);
           return settings;
        }

        class CustomSelectListView : NoFlashListView
        {
           protected override void WndProc(ref Message m)
           {
              if (m.Msg == 0x201 || m.Msg == 0x203)
              {  // Trap WM_LBUTTONDOWN + double click
                 var pos = new Point(m.LParam.ToInt32() & 0xffff, m.LParam.ToInt32() >> 16);
                 var loc = this.HitTest(pos);
                 switch (loc.Location)
                 {
                    case ListViewHitTestLocations.None:
                    case ListViewHitTestLocations.AboveClientArea:
                    case ListViewHitTestLocations.BelowClientArea:
                    case ListViewHitTestLocations.LeftOfClientArea:
                    case ListViewHitTestLocations.RightOfClientArea:
                       return;  // Don't let the native control see it
                 }
              }
              base.WndProc(ref m);
           }
        }


        public MainForm()
        {
            InitializeComponent();            
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        partial void CreateFind();
        partial void CreateNAction();        

        void _find_BeforeConnect(object sender, BeforeConnectEventArgs e)
        {         
        }

        void _find_AfterConnect(object sender, AfterConnectEventArgs e)
        {         
        }
        

        void _find_BeforeAssociateRequest(object sender, BeforeAssociateRequestEventArgs e)
        {         
        }

        void _find_AfterAssociateRequest(object sender, AfterAssociateRequestEventArgs e)
        {         
        }       

        void _find_BeforeCFind(object sender, BeforeCFindEventArgs e)            
        {
            if (_patientSearch)
            {
                e.Dataset.InsertElementAndSetValue(DicomTag.OtherPatientIDs, string.Empty);
                _patientSearch = false;
            }
        }

        void _find_AfterCFind(object sender, AfterCFindEventArgs e)
        {            
        }        

        private void SynchronizedInvoke(MethodInvoker del)
        {
            if (InvokeRequired)
                Invoke(del, null);
            else
                del();
        }

        private string GetPatientNameSearch()
        {
            string last = string.Empty;

            if (textBoxPatientName.Text.Length == 0)
                return string.Empty;

            last = textBoxPatientName.Text.Substring(textBoxPatientName.Text.Length - 1);
            if (last != "*")
                return textBoxPatientName.Text.Replace(',', '^') + "*";

            return textBoxPatientName.Text.Replace(',', '^');
        }        

        private void DoSearch()
        {
            ProgressDialog progress = new ProgressDialog();

            _query.PatientQuery.PatientId = textBoxPatientId.Text;
            _query.PatientQuery.PatientName = GetPatientNameSearch();            
            listViewSeries.BeginUpdate();
            listViewSeries.Items.Clear();
            listViewSeries.EndUpdate();
            //listViewPatients.BeginUpdate();
            listViewPatients.Items.Clear();
            _CurrentPatient = null;
            EditPatientButton.Enabled = false;
            DeletePatientButton.Enabled = false;
            EditSeriesButton.Enabled = false;
            DeleteSeriesButton.Enabled = false;

            DicomAE scp = GetScp();
            if (scp == null)
               return;           

            _server.AETitle = scp.AE;
            _server.PeerAddress = OptionsDialog.ResolveIPAddress(scp.IPAddress);
            _server.Port = scp.Port;
            _server.Timeout = scp.Timeout;

            Program.OtherPID.Clear();

            Thread thread = new Thread(delegate()
                {
                    try
                    {
                        _patientSearch = true;
                        _find.Find<PatientRootQueryPatient, Patient>(_server, _query, (p,ds) =>
                            {
                                string id = ds.GetValue<string>(DicomTag.OtherPatientIDs,string.Empty);

                                if (!string.IsNullOrEmpty(id))
                                {
                                  Program.OtherPID[p.Id] = id;
                                }

                                SynchronizedInvoke(() => AddPatient(p)); 
                            });
                        if (_find.Rejected)
                        {
                            SynchronizedInvoke(() =>
                                {
                                    TaskDialogHelper.ShowMessageBox(this, "No Records Found", "Association Failed", _find.Reason,
                                                          "Modify options and try again.", TaskDialogStandardButtons.Ok, TaskDialogStandardIcon.Error, TaskDialogStandardIcon.Information);
                                });
                        }
                    }
                    catch (Exception e)
                    {                        
                        ApplicationUtils.ShowException(this, e);
                    }
                    SynchronizedInvoke(() => listViewPatients.Sort()); 
                });

            progress.Cancel = () =>
                {
                    if (_find.IsAssociated())
                    {
                        _find.AbortRequest(DicomAbortSourceType.User, DicomAbortReasonType.Unexpected);                        
                    }                    
                };
            progress.ActionThread = thread;
            progress.Title = "Finding Patients";
            progress.ProgressInfo = "Performing a patient search.";
            progress.ShowDialog(this);           
            //listViewPatients.EndUpdate();
        }

        private void GetPatientSeries(Patient p)
        {
            StudyRootQueryStudy query = new StudyRootQueryStudy();
            ProgressDialog progress = new ProgressDialog();

            query.Patient.PatientId = p.Id;
            //listViewSeries.BeginUpdate();
            listViewSeries.Items.Clear();            
            Thread thread = new Thread(delegate()
            {
                try
                {
                    List<Study> studies = new List<Study>();
                    StudyRootQuerySeries seriesQuery = new StudyRootQuerySeries();

                    _find.Find<StudyRootQueryStudy, Study>(_server, query, (study, ds) =>
                    {
                        studies.Add(study);
                    });

                    //
                    // Retrieve the series
                    //
                    foreach (Study study in studies)
                    {
                        seriesQuery.Patient.PatientId = p.Id;
                        seriesQuery.Study.StudyInstanceUID = study.InstanceUID;
                        _find.Find<StudyRootQuerySeries, PatientUpdaterSeries>(_server, seriesQuery, (s, ds) =>
                        {
                            s.Study = study;
                            SynchronizedInvoke(() => AddSeries(s, study.InstanceUID)); 
                        });
                    }
                }
                catch (Exception e)
                {
                    ApplicationUtils.ShowException(this, e);
                }
                SynchronizedInvoke(() => listViewSeries.Sort());
            });

            progress.Cancel = () =>
                {
                    if (_find.IsAssociated())
                    {
                        _find.AbortRequest(DicomAbortSourceType.User, DicomAbortReasonType.Unexpected);
                    }
                };
            progress.ActionThread = thread;
            progress.Title = "Retrieving Patient Series";
            progress.ProgressInfo = "Performing a series search.";
            progress.ShowDialog(this);
            //listViewSeries.EndUpdate();
        }

        private ListViewItem AddPatient(Patient p)
        {
            ListViewItem item = new ListViewItem(p.Name.Full);

            item.SubItems.Add(p.Id);
            item.SubItems.Add(p.Sex);
            item.SubItems.Add(Program.DateString(p.BirthDate));
            item.Tag = p;
            listViewPatients.Items.Add(item);
            return item;
        }

        private ListViewItem AddSeries(PatientUpdaterSeries s, string studyInstanceUID)
        {
            ListViewItem item = new ListViewItem(s.Description);

            item.SubItems.Add(Program.DateString(s.Date));
            item.SubItems.Add(s.Time.HasValue ? s.Time.Value.ToString("h:mm:ss.ff") : string.Empty);
            item.SubItems.Add(s.Modality);
            item.SubItems.Add(studyInstanceUID);            
            item.Tag = s;
            listViewSeries.Items.Add(item);
            return item;
        }

        private void SetOtherDefaults(DicomDemoSettings settings)
        {
           settings.ClientCertificate = DicomDemoSettingsManager.GetClientCertificateFullPath();
           settings.ClientPrivateKey = DicomDemoSettingsManager.GetClientCertificateFullPath();
           settings.ClientPrivateKeyPassword = DicomDemoSettingsManager.GetClientCertificatePassword();

           settings.LogLowLevel = true;
           settings.ShowHelpOnStart = true;          
        }       

        private void MainForm_Load(object sender, EventArgs e)
        {
            textBoxPatientId.Text = "*";
            
            LoadSettings();

            listViewPatients.ListViewItemSorter = _patientSorter;
            listViewSeries.ListViewItemSorter = _seriesSorter;
            Initialize();
            optionsToolStripMenuItem.Enabled = UserManager.User.IsAdmin();            
        }        

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
        }

        partial void DoOptions();

        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {          
           DoOptions();
        }        

        private void SearchButton_Click(object sender, EventArgs e)
        {
            DoSearch();
        }

        private void listViewPatients_SelectedIndexChanged(object sender, EventArgs e)
        {
           EditPatientButton.Enabled = listViewPatients.SelectedItems.Count > 0 && UserManager.User.CanEdit();
           DeletePatientButton.Enabled = listViewPatients.SelectedItems.Count > 0 && UserManager.User.CanDelete();
            listViewSeries.SelectedItems.Clear();
            DeleteSeriesButton.Enabled = false;
            EditSeriesButton.Enabled = false;
            if (listViewPatients.SelectedItems.Count > 0)
            {
                Patient p = listViewPatients.SelectedItems[0].Tag as Patient;

                if (_CurrentPatient != p)
                {
                    GetPatientSeries(p);
                    _CurrentPatient = p;
                }
            }
        }

        private void listViewSeries_SelectedIndexChanged(object sender, EventArgs e)
        {
            DeleteSeriesButton.Enabled = listViewSeries.SelectedItems.Count > 0 && UserManager.User.CanDelete();
            EditSeriesButton.Enabled = listViewSeries.SelectedItems.Count > 0 && UserManager.User.CanEdit();
            if (listViewSeries.SelectedItems.Count > 0)
            {
                EditPatientButton.Enabled = false;
                DeletePatientButton.Enabled = false;
            }
        }

        private void EditPatientButton_Click(object sender, EventArgs e)
        {
            Patient p = listViewPatients.SelectedItems[0].Tag as Patient;
            EditPatientDialog dlgPatient = new EditPatientDialog(_naction, _find, _server, p) { Icon = Icon };

            if (dlgPatient.ShowDialog(this) == DialogResult.OK)
            {
                //
                // If there was a change action we need to update the current patient information
                //
                if (dlgPatient.Action == ActionType.Change)
                {
                    ListViewItem item = listViewPatients.SelectedItems[0];

                    item.Tag = dlgPatient.Patient;
                    item.Text = dlgPatient.Patient.Name.Full;
                    item.SubItems[1].Text = dlgPatient.Patient.Id;
                    item.SubItems[2].Text = dlgPatient.Patient.Sex;
                    item.SubItems[3].Text = Program.DateString(dlgPatient.Patient.BirthDate);                    
                }
                else if (dlgPatient.Action == ActionType.Merge)
                {
                    DeletePatient(listViewPatients.SelectedItems[0]);
                }                
            }
        }

        private void Sort(ListView listview, ListViewColumnSorter sorter,ColumnClickEventArgs e)
        {
            sorter.ShowHeaderIcon(listview, sorter.SortColumn, SortOrder.None);
            if (e.Column == sorter.SortColumn)
            {
                // Reverse the current sort direction for this column.
                if (sorter.Order == SortOrder.Ascending)
                {
                    sorter.Order = SortOrder.Descending;
                }
                else
                {
                    sorter.Order = SortOrder.Ascending;
                }
            }
            else
            {
                // Set the column number that is to be sorted; default to ascending.
                sorter.SortColumn = e.Column;
                sorter.Order = SortOrder.Ascending;
            }
            listview.Sort();
            sorter.ShowHeaderIcon(listview, e.Column, sorter.Order);
        }        

        private void listViewPatients_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            Sort(sender as ListView, _patientSorter, e);
        }

        private void listViewSeries_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            Sort(sender as ListView, _seriesSorter, e);
        }

        private void listViewPatients_Enter(object sender, EventArgs e)
        {
            listViewPatients_SelectedIndexChanged(sender, EventArgs.Empty);
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            textBoxPatientId.Focus();
            Search_Changed(SearchButton, EventArgs.Empty);
        }

        private void EditSeriesButton_Click(object sender, EventArgs e)
        {
            PatientUpdaterSeries series = listViewSeries.SelectedItems[0].Tag as PatientUpdaterSeries;
            Patient patient = listViewPatients.SelectedItems[0].Tag as Patient;
            string studyinstance = listViewSeries.SelectedItems[0].SubItems[listViewSeries.SelectedItems[0].SubItems.Count - 1].Text;
            EditSeriesDialog dlgSeries = new EditSeriesDialog(_naction, _find, _server, studyinstance, series, patient) { Icon = Icon };

            if (dlgSeries.ShowDialog(this) == DialogResult.OK)
            {
                if (dlgSeries.Action == ActionType.Change)
                {
                    ListViewItem item = listViewSeries.SelectedItems[0];

                    item.Tag = dlgSeries.Series;
                    item.Text = dlgSeries.Series.Description;
                    item.SubItems[1].Text = Program.DateString(dlgSeries.Series.Date);
                    item.SubItems[2].Text = dlgSeries.Series.Time.HasValue ? dlgSeries.Series.Time.Value.ToString("h:mm:ss.ff") : string.Empty;
                    item.SubItems[3].Text = dlgSeries.Series.Modality;
                }
                else if (dlgSeries.Action == ActionType.Merge)
                {
                    DeleteSeries(listViewSeries.SelectedItems[0]);
                }
                else if (dlgSeries.Action != ActionType.CopyStudy)
                {
                    ListViewItem item = null;

                    DeleteSeries(listViewSeries.SelectedItems[0]);
                    item = AddPatient(dlgSeries.Patient);
                    item.Selected = true;
                    listViewPatients.Sort();
                    listViewPatients.EnsureVisible(item.Index);
                    listViewSeries.BeginUpdate();
                    listViewSeries.Items.Clear();
                    item = AddSeries(dlgSeries.Series, dlgSeries.StudyInstanceUID);
                    item.Selected = true;
                    listViewSeries.EndUpdate();
                }
            }
        }

        private void DeletePatient(ListViewItem item)
        {
            listViewPatients.Items.Remove(item);
            listViewSeries.BeginUpdate();
            listViewSeries.Items.Clear();
            listViewSeries.EndUpdate();
        }

        private void DeleteSeries(ListViewItem item)
        {
            listViewSeries.Items.Remove(item);
            if (listViewSeries.Items.Count == 0)
                DeletePatient(listViewPatients.SelectedItems[0]);
        }

        private void DeletePatientButton_Click(object sender, EventArgs e)
        {
           ReasonDialog dlgReason = new ReasonDialog("Input Reason For Deleting Patient") { Icon = Icon };

            if (dlgReason.ShowDialog(this) == DialogResult.OK)
            {
                ProgressDialog progress = new ProgressDialog();
                Patient patient = listViewPatients.SelectedItems[0].Tag as Patient;
                DeletePatient delPatient = new DeletePatient();
                DicomCommandStatusType status = DicomCommandStatusType.Success;

                delPatient.Reason = dlgReason.Reason;
               delPatient.Operator = Environment.UserName!=string.Empty?Environment.UserName:Environment.MachineName;
                delPatient.Station = Environment.MachineName;
                delPatient.PatientId = patient.Id;                
                delPatient.Description = "Patient Delete";
                Thread thread = new Thread(() =>
                {
                    try
                    {
                       status = _naction.SendNActionRequest<DeletePatient>(_server, delPatient, NActionScu.DeletePatient,
                                                                            NActionScu.PatientUpdateInstance);
                    }
                    catch (Exception ex)
                    {
                        ApplicationUtils.ShowException(this, ex);
                    }
                });

                progress.ActionThread = thread;
                progress.Title = "Deleting Patient: " + patient.Name.Full;
                progress.ProgressInfo = "Performing patient delete.";                
                progress.ShowDialog(this);
                if (status == DicomCommandStatusType.Success)
                {
                    //
                    // Remove the deleted patient from the list
                    //
                    DeletePatient(listViewPatients.SelectedItems[0]);
                }
                else
                {
                    if (status == DicomCommandStatusType.UnrecognizedOperation)
                    {
                        TaskDialogHelper.ShowMessageBox(this, "Error Deleting Patient", "Check Server Permissions", "There was an error deleting the patient. " +
                                                        "This is usually caused by invalid AE permissions.", string.Empty, TaskDialogStandardButtons.Ok, TaskDialogStandardIcon.Error, null);
                    }
                    else
                    {
                        TaskDialogHelper.ShowMessageBox(this, "Error Deleting Patient", "Check Server Log", "There was an error deleting the patient. " +
                                                       string.Format("The server return the following error: {0}.", _naction.GetErrorMessage()), string.Empty, TaskDialogStandardButtons.Ok, TaskDialogStandardIcon.Error, null);
                    }
                }
            }
        }

        private void DeleteSeriesButton_Click(object sender, EventArgs e)
        {
           ReasonDialog dlgReason = new ReasonDialog("Input Reason For Deleting Series") { Icon = Icon };

            if (dlgReason.ShowDialog(this) == DialogResult.OK)
            {
                Series series = listViewSeries.SelectedItems[0].Tag as Series;
                DeleteSeries delSeries = new DeleteSeries();
                DicomCommandStatusType status = DicomCommandStatusType.Success;

                delSeries.Reason = dlgReason.Reason;
                delSeries.Operator = Environment.UserName != string.Empty ? Environment.UserName : Environment.MachineName;
                delSeries.Description = "Series Delete";
                delSeries.StudyInstanceUID = listViewSeries.SelectedItems[0].SubItems[listViewSeries.SelectedItems[0].SubItems.Count - 1].Text;
                delSeries.SeriesInstanceUID = series.InstanceUID;

                status = _naction.SendNActionRequest<DeleteSeries>(_server, delSeries, NActionScu.DeleteSeries,
                                                                   NActionScu.PatientUpdateInstance);
                if (status == DicomCommandStatusType.Success)
                {
                    DeleteSeries(listViewSeries.SelectedItems[0]);
                }
                else
                {
                    if (status == DicomCommandStatusType.UnrecognizedOperation)
                    {
                        TaskDialogHelper.ShowMessageBox(this, "Error Deleting Series", "Check Server Permissions", "There was an error deleting the series. " +
                                                        "This is usually caused by invalid AE permissions.", string.Empty, TaskDialogStandardButtons.Ok, TaskDialogStandardIcon.Error, null);
                    }
                    else
                    {
                        TaskDialogHelper.ShowMessageBox(this, "Error Deleting Series", "Check Server Log", "There was an error deleting the series. " +
                                                       string.Format("The server return the following error: {0}.", _naction.GetErrorMessage()), string.Empty, TaskDialogStandardButtons.Ok, TaskDialogStandardIcon.Error, null);
                    }
                }
            }
        }
        
        private void Search_Changed(object sender, EventArgs e)
        {
            SearchButton.Enabled = (textBoxPatientId.Text.Length > 0 || textBoxPatientName.Text.Length > 0) && _mySettings!=null;
        }

        private void Search_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (SearchButton.Enabled)
                {
                    e.Handled = true;
                    SearchButton_Click(SearchButton, EventArgs.Empty);
                }
            }
        }

        private void textBoxPatientName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar))
                e.KeyChar = char.ToUpper(e.KeyChar);
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
           About();
        }       
    }
}

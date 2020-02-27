// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Leadtools.Wizard.Pages;
using Leadtools.Wizard;
using ModalityWorklistWCFDemo.Broker;
using Leadtools.Demos;
using System.ServiceModel;
using Leadtools.Dicom;

namespace ModalityWorklistWCFDemo.UI.Pages
{
    public partial class PatientPage : InternalTemplatePage
    {
        private bool _Update = false;
        private string _OriginalPatientId = string.Empty;
        private string _OriginalIssuerOfPatientId = string.Empty;
        private List<PatientKey> _PatientKeys;        

        private WCFPatient _Patient = new WCFPatient();

        public WCFPatient Patient
        {
            get { return _Patient; }
        }

        public PatientPage()
        {
            InitializeComponent();
            errorProvider.SetIconAlignment(comboBoxPatientId, ErrorIconAlignment.TopLeft);            
        }

#if(LTV20_CONFIG)
        string _worklistServer = "L20_MWL_SCP32";
#elif(LTV19_CONFIG)
        string _worklistServer = "L19_MWL_SCP32";
#elif(LTV18_CONFIG)
      string _worklistServer = "L18_MWL_SCP32";
#elif(LTV175_CONFIG)
      string _worklistServer = "L175_MWL_SCP32";
#else
      string _worklistServer = "L17_MWL_SCP32";
#endif

        public override void OnSetActive(object sender, WizardCancelEventArgs e)
        {
            base.OnSetActive(sender, e);
            GetWizard().Option1Caption = "Clear";
            if (_PatientKeys == null)
            {
                ProgressDialog dlgProgresss = new ProgressDialog();
                CustomBrokerClient client = GetWizard().Tag as CustomBrokerClient;
                List<string> ids = null;                              

                dlgProgresss.Title = "Find";
                dlgProgresss.Description = "Getting list of patient ids";
                dlgProgresss.Action = () =>
                {
                    ids = client.GetPatientIDs();
                };
                
                if (dlgProgresss.ShowDialog(this) == DialogResult.OK)
                {
                   _PatientKeys = new List<PatientKey>();
                    foreach (string id in ids)
                    {
                        string[] info = id.Split(';');
                        PatientKey key = new PatientKey() { PatientId = info[0], IssurerOfPatientId = info[1] };

                        _PatientKeys.Add(key);
                        comboBoxPatientId.Items.Add(key);
                    }
                }
                if (dlgProgresss.Exception != null)
                {
                   string errorMessage = dlgProgresss.Exception.Message;
                   if (errorMessage.Contains("There was no endpoint listening at"))
                   {
                      string append = string.Format("\n\nThis can happen if the '{0}' listening service is not running.  To start '{0}' listening service:\n* Run 'CSLeadtools.Dicom.Server.Manager_Original.exe'\n* Click the double-green arrow (Start All Servers)", _worklistServer);
                      errorMessage += append;
                   }
                   Messager.ShowError(this, errorMessage);
                } 
            }
        }

        protected override WizardSheet.WizardButtons GetWizardButtons()
        {
            WizardSheet.WizardButtons buttons =  base.GetWizardButtons();

            buttons |= WizardSheet.WizardButtons.Option1;
            return buttons;
        }

        public override void OnOptionButton1(object sender, EventArgs e)
        {
            comboBoxPatientId.Text = string.Empty;
            textBoxIssuerOfPatientId.Text = string.Empty;
            textBoxPrefix.Text = string.Empty;
            textBoxFamily.Text = string.Empty;
            textBoxGiven.Text = string.Empty;
            textBoxSuffix.Text = string.Empty;
            dateTimePickerBirth.Value = DateTime.Now;
            dateTimePickerBirth.Checked = false;
            comboBoxSex.SelectedIndex = -1;
            textBoxSpecialNeeds.Text = string.Empty;
            textBoxComments.Text = string.Empty;
            _Update = false;
            errorProvider.Clear();
        }

        public override void OnWizardNext(object sender, WizardPageEventArgs e)
        {
            if (!IsValid())
            {
                e.Cancel = true;
                return;
            }
            else
            {
                ProgressDialog dlgProgresss = new ProgressDialog();
                CustomBrokerClient client = GetWizard().Tag as CustomBrokerClient;

                //
                // See if the user wants to update are add.  The user will only be asked if the originally did a search but
                // changed one of the patient ids.
                //
                if (_Update && (comboBoxPatientId.Text != _OriginalPatientId ))
                {
                    DialogResult r = Messager.ShowQuestion(this, "You searched for a patient but have changed some of the identifying information.  " +
                                                                 "Would you like to update this patient with the new information? \r\n\r\nClicking No will add a new patient.",
                                                                 MessageBoxButtons.YesNo);
                    _Update = r == DialogResult.Yes;
                }

                UpdatePatient();
                dlgProgresss.Title = _Update ? "Update patient" : "Add Patient";
                dlgProgresss.Description = _Update ? "Updating..." : "Adding...";
                dlgProgresss.Action = () =>
                {
                    if (_Update)
                    {
                        client.UpdatePatient(_OriginalPatientId, _OriginalIssuerOfPatientId, _Patient);                                               
                    }
                    else
                    {
                        client.AddPatient(_Patient);
                    }
                };

                if (dlgProgresss.ShowDialog(this) == DialogResult.Cancel)
                {
                    if (dlgProgresss.Exception != null)
                    {
                        e.Cancel = true;
                        Messager.ShowError(this, dlgProgresss.Exception);
                    }
                }
                else
                {
                   if (_Update)
                   {
                      UpdatePatient(_OriginalPatientId, _OriginalIssuerOfPatientId, _Patient.PatientID, _Patient.IssuerOfPatientID);                                            
                   }
                   else                      
                      comboBoxPatientId.Items.Add(new PatientKey() { PatientId = _Patient.PatientID, IssurerOfPatientId = _Patient.IssuerOfPatientID });

                   comboBoxPatientId.Text = _Patient.PatientID;
                   if (_Patient != null)
                   {
                      _OriginalPatientId = _Patient.PatientID;
                      _OriginalIssuerOfPatientId = _Patient.IssuerOfPatientID;
                   }
                   else
                   {
                      e.Cancel = true;
                      ParentWizard.Reset();
                   }
                }
            }

            base.OnWizardNext(sender, e);
        }

        private void UpdatePatient(string pid, string ipid,string p, string i)
        {
            foreach (PatientKey key in _PatientKeys)
            {
                if (key.PatientId == pid && key.IssurerOfPatientId == ipid)
                {
                    int index = comboBoxPatientId.Items.IndexOf(key);

                    _PatientKeys.ElementAt(index).PatientId = p;
                    _PatientKeys.ElementAt(index).IssurerOfPatientId = i;
                    break;
                }
            }
        }

        public bool IsValid()
        {
            bool valid = true;

            if (comboBoxPatientId.Text.Length == 0)
            {
                valid = false;
                errorProvider.SetError(comboBoxPatientId, "Must provide patient id");
                comboBoxPatientId.Focus();
            }
            else
                errorProvider.SetError(comboBoxPatientId, string.Empty);

            if (textBoxIssuerOfPatientId.Text.Length == 0)
            {
                if (valid)
                {
                    valid = false;
                    textBoxIssuerOfPatientId.Focus();
                }
                errorProvider.SetError(textBoxIssuerOfPatientId, "Must provide issuer of patient id");
            }
            else
                errorProvider.SetError(textBoxIssuerOfPatientId, string.Empty);

            if (textBoxGiven.Text.Length == 0 && textBoxFamily.Text.Length == 0)
            {
                if (valid)
                {
                    valid = false;
                    textBoxGiven.Focus();
                }
                errorProvider.SetError(groupBoxName, "Must provide value for Given or Family portion of name");
            }
            else
                errorProvider.SetError(groupBoxName, string.Empty);

            if (comboBoxSex.SelectedItem == null)
            {
               if (valid)
               {
                  valid = false;
                  comboBoxSex.Focus();
               }
               errorProvider.SetError(comboBoxSex, "Must provide a value for sex");
            }
            else
               errorProvider.SetError(comboBoxSex, string.Empty);

            return valid;
        }

        private void UpdateUI()
        {
            textBoxPrefix.Text = _Patient.PatientNamePrefix;
            textBoxFamily.Text = _Patient.PatientNameFamilyName;
            textBoxGiven.Text = _Patient.PatientNameGivenName;
            textBoxSuffix.Text = _Patient.PatientNameSuffix;

            if (_Patient.PatientBirthDate.HasValue)
            {
                dateTimePickerBirth.Value = _Patient.PatientBirthDate.Value.Date1.ToDateTime();
            }

            if (!string.IsNullOrEmpty(_Patient.PatientSex))
            {
                int index = comboBoxSex.FindStringExact(_Patient.PatientSex);

                comboBoxSex.SelectedIndex = index;
            }
            else
                comboBoxSex.Text = "";

            textBoxSpecialNeeds.Text = _Patient.SpecialNeeds;
            textBoxComments.Text = _Patient.PatientComments;
        }

        private void UpdatePatient()
        {
           if (_Patient == null)
              _Patient = new WCFPatient();
            _Patient.PatientID = comboBoxPatientId.Text;
            _Patient.IssuerOfPatientID = textBoxIssuerOfPatientId.Text;
            _Patient.PatientNamePrefix = textBoxPrefix.Text;
            _Patient.PatientNameFamilyName = textBoxFamily.Text;
            _Patient.PatientNameGivenName = textBoxGiven.Text;
            _Patient.PatientNameSuffix = textBoxSuffix.Text;

            if (dateTimePickerBirth.Checked)
                _Patient.PatientBirthDate = new DicomDateRangeValue() { Date1 =  new DicomDateValue(dateTimePickerBirth.Value)};

            _Patient.PatientSex = comboBoxSex.Text;
            _Patient.SpecialNeeds = textBoxSpecialNeeds.Text;
            _Patient.PatientComments = textBoxComments.Text;
        }

        public override void OnReset()
        {
            OnOptionButton1(this, EventArgs.Empty);
        }
        
        private void GetPatientInformation()
        {
            ProgressDialog dlgProgresss = new ProgressDialog();            
            BrokerServiceClient client = GetWizard().Tag as BrokerServiceClient;
            string pid = comboBoxPatientId.Text;
            string ipid = textBoxIssuerOfPatientId.Text;

            dlgProgresss.Title = "Querying";
            dlgProgresss.Description = "Getting patient information";
            dlgProgresss.Action = () =>
                {
                    _Patient = client.FindPatient(pid, ipid);                    
                };

            _Update = false;
            _OriginalPatientId = string.Empty;
            _OriginalIssuerOfPatientId = string.Empty;
            if (dlgProgresss.ShowDialog(this) == DialogResult.OK)
            {
                if (_Patient != null)
                {
                    _Update = true;
                    UpdateUI();
                    _OriginalPatientId = _Patient.PatientID;
                    _OriginalIssuerOfPatientId = _Patient.IssuerOfPatientID;
                    errorProvider.Clear();
                }
                else
                {
                    Messager.ShowError(this, "Patient not found.");
                }
            }
            else
            {                
                if (dlgProgresss.Exception != null)
                {
                    Messager.ShowError(this, dlgProgresss.Exception);
                }
            }
        }

        private void PatientPage_Paint(object sender, PaintEventArgs e)
        {
            PaintUtils.HighlightRequiredFields(this, e.Graphics, true, Color.Red);
        }

        private class PatientKey
        {
            public string PatientId { get; set; }
            public string IssurerOfPatientId { get; set; }

            public override string ToString()
            {
                return PatientId;
            }
        }

        private void comboBoxPatientId_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxPatientId.SelectedIndex != -1)
            {
                PatientKey key = comboBoxPatientId.SelectedItem as PatientKey;

                textBoxIssuerOfPatientId.Text = key.IssurerOfPatientId;
                GetPatientInformation();
            }
        }
    }
}

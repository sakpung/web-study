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

namespace ModalityWorklistWCFDemo.UI.Pages
{
    public partial class ImagingServiceRequestPage : InternalTemplatePage
    {
        private Patient _Patient = null;        
        private string _OriginalAccessionNumber = string.Empty;
        private bool _Update = false;

        private ImagingServiceRequest _ImagingServiceRequest = new ImagingServiceRequest();

        public ImagingServiceRequest ImagingServiceRequest
        {
            get { return _ImagingServiceRequest; }            
        }

        public ImagingServiceRequestPage()
        {
            InitializeComponent();            
        }
        
        protected override WizardSheet.WizardButtons GetWizardButtons()
        {
            WizardSheet.WizardButtons buttons = base.GetWizardButtons();

            buttons |= WizardSheet.WizardButtons.Option1;
            return buttons;
        }

        public override void OnSetActive(object sender, WizardCancelEventArgs e)
        {
            base.OnSetActive(sender, e);

            if (e.PreviousPage != null && e.PreviousPage.GetType() == typeof(PatientPage))
            {
                PatientPage p = e.PreviousPage as PatientPage;
                Patient previous = _Patient;                

                _Patient = p.Patient;
                 comboBoxAccessionNumber.Items.Clear(); // ***
                if (
                        (previous==null)                                            || 
                        (previous.IssuerOfPatientID != p.Patient.IssuerOfPatientID  ||
                        previous.PatientID != p.Patient.PatientID)                  ||
                        string.IsNullOrEmpty(Program.MyMainForm.MyImagingServiceRequestPage.comboBoxAccessionNumber.Text))
                {
                    ProgressDialog dlgProgresss = new ProgressDialog();
                    CustomBrokerClient client = GetWizard().Tag as CustomBrokerClient;
                    List<string> accessionNumbers = null;
                                      
                    dlgProgresss.Title = "Find";
                    dlgProgresss.Description = "Getting list of accession numbers";
                    dlgProgresss.Action = () =>
                    {
                        accessionNumbers = client.GetAccessionNumbers(_Patient.PatientID, _Patient.IssuerOfPatientID);
                    };

                    UpdateUI(true);
                    comboBoxAccessionNumber.Items.Clear();
                    if (dlgProgresss.ShowDialog(this) == DialogResult.OK)
                    {
                        foreach (string accessionNumber in accessionNumbers)
                        {
                            comboBoxAccessionNumber.Items.Add(accessionNumber);
                        }
                    }
                    if (dlgProgresss.Exception != null)
                    {
                        Messager.ShowError(this, dlgProgresss.Exception);
                    }
                }
            }
            errorProvider.SetIconAlignment(comboBoxAccessionNumber, ErrorIconAlignment.TopLeft);
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
                if (_Update && (comboBoxAccessionNumber.Text != _OriginalAccessionNumber))
                {
                    DialogResult r = Messager.ShowQuestion(this, "You searched for an imaging service request but have changed the accession number.  " +
                                                                 "Would you like to update this imaging service request with the accession number?  " +
                                                                 "\r\n\r\nClicking No will add a new imaging service request.",MessageBoxButtons.YesNo);
                    _Update = r == DialogResult.Yes;
                }

                UpdateImagingServiceRequest();
                dlgProgresss.Title = _Update ? "Update Imaging Service Request" : "Add Imaging Service Request";
                dlgProgresss.Description = _Update ? "Updating..." : "Adding...";
                dlgProgresss.Action = () =>
                {
                    if (_Update)
                        client.UpdateImagingServiceRequest(_OriginalAccessionNumber,_Patient.PatientID,_Patient.IssuerOfPatientID, _ImagingServiceRequest);
                    else
                        client.AddImagingServiceRequest(_Patient.PatientID,_Patient.IssuerOfPatientID, _ImagingServiceRequest);
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
                        int index = comboBoxAccessionNumber.Items.IndexOf(_OriginalAccessionNumber);

                        if (index != -1)
                            comboBoxAccessionNumber.Items.Remove(_OriginalAccessionNumber);
                    }
                    comboBoxAccessionNumber.Items.Add(_ImagingServiceRequest.AccessionNumber);
                    comboBoxAccessionNumber.Text = _ImagingServiceRequest.AccessionNumber;
                    _OriginalAccessionNumber = _ImagingServiceRequest.AccessionNumber;
                }
            }
            base.OnWizardNext(sender, e);
        }

        public override void OnOptionButton1(object sender, EventArgs e)
        {
            UpdateUI(true);
        }

        public bool IsValid()
        {
            if (comboBoxAccessionNumber.Text.Length == 0)
            {
                errorProvider.SetError(comboBoxAccessionNumber, "Must provide a value for accession number");
                comboBoxAccessionNumber.Focus();
                return false;
            }
            else
                errorProvider.SetError(comboBoxAccessionNumber, string.Empty);
            return true;
        }

        private void UpdateUI(bool clear)
        {
            if (!clear)
            {
                textBoxRequestingService.Text = _ImagingServiceRequest.RequestingService;
                textBoxPrefix.Text = _ImagingServiceRequest.RequestingPhysicianPrefix;
                textBoxGiven.Text = _ImagingServiceRequest.RequestingPhysicianGivenName;
                textBoxFamily.Text = _ImagingServiceRequest.RequestingPhysicianFamilyName;
                textBoxSuffix.Text = _ImagingServiceRequest.RequestingPhysicianSuffix;
                textBoxRPPrefix.Text = _ImagingServiceRequest.ReferringPhysicianPrefix;
                textBoxRPGiven.Text = _ImagingServiceRequest.ReferringPhysicianGivenName;
                textBoxRPFamily.Text = _ImagingServiceRequest.ReferringPhysicianFamilyName;
                textBoxRPSuffix.Text = _ImagingServiceRequest.ReferringPhysicianSuffix;
                textBoxPlaceOrderNumber.Text = _ImagingServiceRequest.PlacerOrderNumber_ImagingServiceRequest;
                textBoxFillOrderNumber.Text = _ImagingServiceRequest.FillerOrderNumber_ImagingServiceRequest;
            }
            else
            {
                comboBoxAccessionNumber.Text = string.Empty;
                textBoxRequestingService.Text = string.Empty;
                textBoxPrefix.Text = string.Empty;
                textBoxGiven.Text = string.Empty;
                textBoxFamily.Text = string.Empty;
                textBoxSuffix.Text = string.Empty;
                textBoxRPPrefix.Text = string.Empty;
                textBoxRPGiven.Text = string.Empty;
                textBoxRPFamily.Text = string.Empty;
                textBoxRPSuffix.Text = string.Empty;
                textBoxPlaceOrderNumber.Text = string.Empty;
                textBoxFillOrderNumber.Text = string.Empty;
                _Update = false;
                errorProvider.Clear();
            }
        }

        private void UpdateImagingServiceRequest()
        {
            _ImagingServiceRequest.AccessionNumber = comboBoxAccessionNumber.Text;
            _ImagingServiceRequest.RequestingService = textBoxRequestingService.Text;
            _ImagingServiceRequest.RequestingPhysicianPrefix = textBoxPrefix.Text;
            _ImagingServiceRequest.RequestingPhysicianGivenName = textBoxGiven.Text;
            _ImagingServiceRequest.RequestingPhysicianFamilyName = textBoxFamily.Text;
            _ImagingServiceRequest.RequestingPhysicianSuffix = textBoxSuffix.Text;
            _ImagingServiceRequest.ReferringPhysicianPrefix = textBoxRPPrefix.Text;
            _ImagingServiceRequest.ReferringPhysicianGivenName = textBoxRPGiven.Text;
            _ImagingServiceRequest.ReferringPhysicianFamilyName = textBoxRPFamily.Text;
            _ImagingServiceRequest.ReferringPhysicianSuffix = textBoxRPSuffix.Text;
            _ImagingServiceRequest.PlacerOrderNumber_ImagingServiceRequest = textBoxPlaceOrderNumber.Text;
            _ImagingServiceRequest.FillerOrderNumber_ImagingServiceRequest = textBoxFillOrderNumber.Text;
        }

        public override void OnReset()
        {
            UpdateUI(true);
        }

        private void GetImagingServiceRequestInfo()
        {
            ProgressDialog dlgProgresss = new ProgressDialog();
            CustomBrokerClient client = GetWizard().Tag as CustomBrokerClient;
            string accessionNumber = comboBoxAccessionNumber.Text;

            dlgProgresss.Title = "Search";
            dlgProgresss.Description = "Searching for imaging service request";
            dlgProgresss.Action = () =>
            {
                _ImagingServiceRequest = client.FindImagingServiceRequest(accessionNumber,_Patient.PatientID, 
                                                                          _Patient.IssuerOfPatientID);
            };

            _Update = false;
            _OriginalAccessionNumber = string.Empty;            
            if (dlgProgresss.ShowDialog(this) == DialogResult.OK)
            {
                if (_ImagingServiceRequest != null)
                {
                    _Update = true;
                    UpdateUI(false);
                    _OriginalAccessionNumber = _ImagingServiceRequest.AccessionNumber;
                    errorProvider.Clear();
                }
                else
                {
                    Messager.ShowError(this, "Imaging service request not found.");
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

        private void ImagingServiceRequestPage_Paint(object sender, PaintEventArgs e)
        {
            PaintUtils.HighlightRequiredFields(this, e.Graphics, true, Color.Red);
        }

        private void comboBoxAccessionNumber_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxAccessionNumber.SelectedIndex != -1)
            {
                GetImagingServiceRequestInfo();             
            }
        }
    }
}

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
using ModalityWorklistWCFDemo.Broker;
using Leadtools.Wizard;
using Leadtools.Demos;
using Leadtools.Dicom.Common.DataTypes;

namespace ModalityWorklistWCFDemo.UI.Pages
{
    public partial class ScheduledProcedureStepPage : InternalTemplatePage
    {
        private RequestedProcedure _RequestedProcedure;
        private ImagingServiceRequest _ImagingServiceRequest;
        private WCFScheduledProcedureStep _ScheduledProcedureStep = new WCFScheduledProcedureStep()
        {
            ScheduledProtocolCodeSequence = new List<ScheduledProtocolCodeSequence>(),
            ScheduledStationAETitle = new List<string>()
        };
        private string _OriginalScheduledProcedureId = string.Empty;
        private bool _Update = false;

        public ScheduledProcedureStepPage()
        {
            InitializeComponent();
            errorProvider.SetIconAlignment(comboBoxId, ErrorIconAlignment.TopLeft);
            errorProvider.SetIconAlignment(textBoxDescription, ErrorIconAlignment.TopLeft);
            LoadModalities();
            Application.Idle += new EventHandler(Application_Idle);
        }

        private void LoadModalities()
        {
            IEnumerator<KeyValuePair<ModalityType, string>> modalities = ModalityDescriptor.GetEnumerator();

            while(modalities.MoveNext())
            {
                comboBoxModality.Items.Add(modalities.Current.Key);
            }
        }

        void Application_Idle(object sender, EventArgs e)
        {           
            buttonEditSP.Enabled = listViewSPCS.SelectedItems.Count == 1;
            buttonDeleteSP.Enabled = buttonEditSP.Enabled;
        }

        protected override WizardSheet.WizardButtons GetWizardButtons()
        {
            WizardSheet.WizardButtons buttons = base.GetWizardButtons();

            buttons |= WizardSheet.WizardButtons.Option1 & ~WizardSheet.WizardButtons.Next | WizardSheet.WizardButtons.Finish;
            return buttons;
        }

        public override void OnOptionButton1(object sender, EventArgs e)
        {
            UpdateUI(true);
        }

        public override void OnSetActive(object sender, WizardCancelEventArgs e)
        {
            base.OnSetActive(sender, e);
            if (e.PreviousPage != null && e.PreviousPage.GetType() == typeof(RequestedProcedurePage))
            {
                RequestedProcedurePage p = e.PreviousPage as RequestedProcedurePage;
                RequestedProcedure or = _RequestedProcedure;
                ImagingServiceRequest oi = _ImagingServiceRequest;


                _RequestedProcedure = p.RequestedProcedure;
                _ImagingServiceRequest = p.ImagingServiceRequest;
                comboBoxId.Items.Clear(); // ***
                if (
                     (or == null )                                                                 ||
                     (or.RequestedProcedureID != _RequestedProcedure.RequestedProcedureID)         ||
                     (oi == null )                                                                 || 
                     (oi.AccessionNumber != _ImagingServiceRequest.AccessionNumber)                ||
                     string.IsNullOrEmpty(comboBoxId.Text)
                   )
                {
                    ProgressDialog dlgProgresss = new ProgressDialog();
                    BrokerServiceClient client = GetWizard().Tag as BrokerServiceClient;
                    List<string> ids = null;

                    UpdateUI(true);
                    comboBoxId.Items.Clear();
                    dlgProgresss.Title = "Find";
                    dlgProgresss.Description = "Getting list of scheduled procedure step ids";
                    dlgProgresss.Action = () =>
                    {
                        ids = client.GetScheduledProcedureStepIDs(_ImagingServiceRequest.AccessionNumber, _RequestedProcedure.RequestedProcedureID);
                    };

                    if (dlgProgresss.ShowDialog(this) == DialogResult.OK)
                    {
                        foreach (string id in ids)
                        {
                            comboBoxId.Items.Add(id);
                        }
                    }
                    if (dlgProgresss.Exception != null)
                    {
                        Messager.ShowError(this, dlgProgresss.Exception);
                    }
                }
            }
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see cref="T:Leadtools.Wizard.WizardPageEventArgs">WizardPageEventArgs</see> that contains the event data.</param>
        /// <remarks></remarks>
        public override void OnWizardFinish(object sender, CancelEventArgs e)
        {
            if (!IsValid())
            {
                e.Cancel = true;
                return;
            }
            else
            {
                ProgressDialog dlgProgresss = new ProgressDialog();
                BrokerServiceClient client = GetWizard().Tag as BrokerServiceClient;

                if (_Update && comboBoxId.Text != _OriginalScheduledProcedureId)
                {
                    DialogResult r = Messager.ShowQuestion(this, "You searched for a scheduled procedure but have changed te scheduled procedure UID.  " +
                                                                 "Would you like to update this scheduled procedure with the new UID?\r\n\r\n Clicking No will add a new scheduled procedure.",
                                                                 MessageBoxButtons.YesNo);
                    _Update = r == DialogResult.Yes;
                }

                UpdateScheduledProcedureStep();
                dlgProgresss.Title = _Update ? "Update Scheduled Procedure" : "Add Scheduled Procedure";
                dlgProgresss.Description = _Update ? "Updating..." : "Adding...";
                dlgProgresss.Action = () =>
                {
                    if (_Update)
                        client.UpdateScheduledProcedureStep(_OriginalScheduledProcedureId, _ScheduledProcedureStep);
                    else
                        client.AddScheduledProcedureStep(_ImagingServiceRequest.AccessionNumber,_RequestedProcedure.RequestedProcedureID,_ScheduledProcedureStep);
                };

                if (dlgProgresss.ShowDialog(this) == DialogResult.Cancel)
                {
                    if (dlgProgresss.Exception != null)
                    {
                        e.Cancel = true;
                        Messager.ShowError(this, dlgProgresss.Exception);
                        return;
                    }
                }
                else
                {
                    if (_Update)
                    {
                        int index = comboBoxId.Items.IndexOf(_OriginalScheduledProcedureId);

                        if (index != -1)
                            comboBoxId.Items.Remove(_OriginalScheduledProcedureId);
                    }
                    comboBoxId.Items.Add(_ScheduledProcedureStep.ScheduledProcedureStepID);
                    comboBoxId.Text = _ScheduledProcedureStep.ScheduledProcedureStepID;
                    _OriginalScheduledProcedureId = _ScheduledProcedureStep.ScheduledProcedureStepID;
                }
            }

            base.OnWizardFinish(sender, e);
        }

        public bool IsValid()
        {
            bool valid = true;

            if (string.IsNullOrEmpty(comboBoxId.Text))
            {
                valid = false;
                errorProvider.SetError(comboBoxId, "Must provide scheduled procedure step id");
            }
            else
                errorProvider.SetError(comboBoxId, string.Empty);            

            if (string.IsNullOrEmpty(comboBoxModality.Text))
            {
                valid = false;
                errorProvider.SetError(comboBoxModality, "Must provide a value for modality");
            }
            else
                errorProvider.SetError(comboBoxModality, string.Empty);

            if (string.IsNullOrEmpty(textBoxDescription.Text))
            {
                valid = false;
                errorProvider.SetError(textBoxDescription, "Must provide a value for description");
            }
            else
                errorProvider.SetError(textBoxDescription, string.Empty);

            if (string.IsNullOrEmpty(textBoxScheduledStationAE.Text))
            {
               valid = false;
               errorProvider.SetError(textBoxScheduledStationAE, "Must provide a value for scheduled station ae title");
            }
            else
               errorProvider.SetError(textBoxScheduledStationAE, string.Empty);

            return valid;
        }


        /// <summary>
        /// Updates the UI.
        /// </summary>
        /// <remarks></remarks>
        private void UpdateUI(bool clear)
        {
            if (!clear)
            {
                string aes = string.Empty;

                textBoxLocation.Text = _ScheduledProcedureStep.ScheduledProcedureStepLocation;
                if (_ScheduledProcedureStep.ScheduledProcedureStepStartDate_Time.StartDate.HasValue)
                   dateTimePickerStartDate.Value = _ScheduledProcedureStep.ScheduledProcedureStepStartDate_Time.StartDate.Value;
                else
                   dateTimePickerStartDate.Value = DateTime.Now;
                comboBoxModality.Text = _ScheduledProcedureStep.Modality;
                textBoxPrefix.Text = _ScheduledProcedureStep.ScheduledPerformingPhysicianNamePrefix;
                textBoxGiven.Text = _ScheduledProcedureStep.ScheduledPerformingPhysicianNameGivenName;
                textBoxFamily.Text = _ScheduledProcedureStep.ScheduledPerformingPhysicianNameFamilyName;
                textBoxSuffix.Text = _ScheduledProcedureStep.ScheduledPerformingPhysicianNameSuffix;
                textBoxDescription.Text = _ScheduledProcedureStep.ScheduledProcedureStepDescription;
                foreach (string ae in _ScheduledProcedureStep.ScheduledStationAETitle)
                {
                    if (aes.Length > 0)
                        aes += ",";
                    aes += ae;
                }
                textBoxScheduledStationAE.Text = aes;

                listViewSPCS.Items.Clear();
                foreach (ScheduledProtocolCodeSequence spcs in _ScheduledProcedureStep.ScheduledProtocolCodeSequence)
                {
                    AddScheduledProtocolCodeSequence(spcs);
                }
            }
            else
            {
                comboBoxId.Text = string.Empty;
                textBoxLocation.Text = string.Empty;
                dateTimePickerStartDate.Value = DateTime.Now;
                comboBoxModality.Text = string.Empty;
                textBoxPrefix.Text = string.Empty;
                textBoxGiven.Text = string.Empty;
                textBoxFamily.Text = string.Empty;
                textBoxSuffix.Text = string.Empty;
                textBoxDescription.Text = string.Empty;
                textBoxScheduledStationAE.Text = string.Empty;
                listViewSPCS.Items.Clear();
                _Update = false;
                errorProvider.Clear();
            }            
        }

        private void UpdateScheduledProcedureStep()
        {
            _ScheduledProcedureStep.ScheduledProcedureStepID = comboBoxId.Text;
            _ScheduledProcedureStep.ScheduledProcedureStepLocation = textBoxLocation.Text;
            _ScheduledProcedureStep.Modality = comboBoxModality.Text;
            _ScheduledProcedureStep.ScheduledPerformingPhysicianNamePrefix = textBoxPrefix.Text;
            _ScheduledProcedureStep.ScheduledPerformingPhysicianNameGivenName = textBoxGiven.Text;
            _ScheduledProcedureStep.ScheduledPerformingPhysicianNameFamilyName = textBoxFamily.Text;
            _ScheduledProcedureStep.ScheduledPerformingPhysicianNameSuffix = textBoxSuffix.Text;
            _ScheduledProcedureStep.ScheduledProcedureStepDescription = textBoxDescription.Text;
            _ScheduledProcedureStep.ScheduledProcedureStepStartDate_Time = new DateRange() { StartDate = dateTimePickerStartDate.Value };
            
            _ScheduledProcedureStep.ScheduledStationAETitle.Clear();
            if (textBoxScheduledStationAE.Text.Length > 0)
            {
                string[] aes = textBoxScheduledStationAE.Text.Split(',', '\r', '\n', ';');

                foreach (string ae in aes)
                {                    
                    _ScheduledProcedureStep.ScheduledStationAETitle.Add(ae.Trim());
                }
            }

            _ScheduledProcedureStep.ScheduledProtocolCodeSequence.Clear();
            foreach (ListViewItem item in listViewSPCS.Items)
            {
                _ScheduledProcedureStep.ScheduledProtocolCodeSequence.Add(item.Tag as ScheduledProtocolCodeSequence);
            }
        }

        private void AddScheduledProtocolCodeSequence(ScheduledProtocolCodeSequence sequence)
        {
            ListViewItem item = listViewSPCS.Items.Add(sequence.CodeValue);

            item.SubItems.Add(sequence.CodingSchemeDesignator);
            item.SubItems.Add(sequence.CodeMeaning);
            item.SubItems.Add(sequence.CodingSchemeVersion);            
            item.Tag = sequence;
        }

        public override void OnReset()
        {
            UpdateUI(true);
        }

        /// <summary>
        /// Gets the scheduled procedure step info.
        /// </summary>
        private void GetScheduledProcedureStepInfo()
        {
            ProgressDialog dlgProgresss = new ProgressDialog();
            BrokerServiceClient client = GetWizard().Tag as BrokerServiceClient;
            string id = comboBoxId.Text;

            dlgProgresss.Title = "Search";
            dlgProgresss.Description = "Searching for scheduled procedure step";
            dlgProgresss.Action = () =>
            {
                _ScheduledProcedureStep = client.FindScheduledProcedureStep(id);
            };

            _Update = false;
            _OriginalScheduledProcedureId = string.Empty;
            if (dlgProgresss.ShowDialog(this) == DialogResult.OK)
            {
                if (_ScheduledProcedureStep != null)
                {                    
                    _Update = true;
                    UpdateUI(false);
                    _OriginalScheduledProcedureId = _ScheduledProcedureStep.ScheduledProcedureStepID;
                    errorProvider.Clear();
                }
                else
                {
                    Messager.ShowError(this, "Schedule procedure step not found.");
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

        private void buttonAddSP_Click(object sender, EventArgs e)
        {
            ObjectEditor<ScheduledProtocolCodeSequence> editor = new ObjectEditor<ScheduledProtocolCodeSequence>(null, "Scheduled Protocol Sequence");

            if (editor.ShowDialog(this) == DialogResult.OK)
            {
                AddScheduledProtocolCodeSequence(editor.EditObject);
            }
        }

        private void buttonEditSP_Click(object sender, EventArgs e)
        {
            ListViewItem item = listViewSPCS.SelectedItems[0];
            ScheduledProtocolCodeSequence sequence = item.Tag as ScheduledProtocolCodeSequence;
            ObjectEditor<ScheduledProtocolCodeSequence> editor = new ObjectEditor<ScheduledProtocolCodeSequence>(sequence, "Scheduled Protocol Sequence");

            if (editor.ShowDialog(this) == DialogResult.OK)
            {
                item.Text = editor.EditObject.CodeValue;
                item.SubItems[1].Text = editor.EditObject.CodingSchemeDesignator;
                item.SubItems[2].Text = editor.EditObject.CodeMeaning;
                item.SubItems[3].Text = editor.EditObject.CodingSchemeVersion;                
                item.Tag = editor.EditObject;
            }
        }

        private void buttonDeleteSP_Click(object sender, EventArgs e)
        {
            ListViewItem item = listViewSPCS.SelectedItems[0];

            listViewSPCS.Items.Remove(item);
        }

        private void ScheduledProcedureStepPage_Paint(object sender, PaintEventArgs e)
        {
            PaintUtils.HighlightRequiredFields(this, e.Graphics, true, Color.Red);
        }

        private void comboBoxId_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxId.SelectedIndex != -1)
            {
                GetScheduledProcedureStepInfo();
            }
        }        
    }
}

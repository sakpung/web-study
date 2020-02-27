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
using MPPSWCFDemo.Broker;
using Leadtools.Demos;
using System.ServiceModel;
using Leadtools.Dicom;

namespace MPPSWCFDemo.UI.Pages
{
    public partial class UnscheduledPatientPage : InternalTemplatePage
    {       
        public UnscheduledPatientPage()
        {
            InitializeComponent();                     
        }        

        public override void OnSetActive(object sender, WizardCancelEventArgs e)
        {
            base.OnSetActive(sender, e);
            labelUnscheduled.Visible = MainForm.Mpps.Patient != null;
            if (!labelUnscheduled.Visible)
            {
               UpdateUI(false);
            }
            SetControlsState();
        }

        private void SetControlsState()
        {
           foreach (Control control in Controls)
           {
              if (control != labelUnscheduled)
              {
                 control.Enabled = !labelUnscheduled.Visible;
              }
           }
        }

        protected override WizardSheet.WizardButtons GetWizardButtons()
        {
            WizardSheet.WizardButtons buttons =  base.GetWizardButtons();

            buttons |= WizardSheet.WizardButtons.Option1 & ~WizardSheet.WizardButtons.Next | WizardSheet.WizardButtons.Finish;
            return buttons;
        }

        public override void OnOptionButton1(object sender, EventArgs e)
        {
            textBoxId.Text = string.Empty;
            textBoxIssuerOfPatientId.Text = string.Empty;           
            dateTimePickerBirth.Value = DateTime.Now;
            dateTimePickerBirth.Checked = false;
            comboBoxSex.SelectedIndex = -1;
            textBoxName.Text = string.Empty;                       
        }

        public override void OnWizardFinish(object sender, CancelEventArgs e)
        {
           if (MainForm.Mpps.Patient == null)
           {
              ProgressDialog dlgProgresss = new ProgressDialog();
              BrokerServiceClient client = GetWizard().Tag as BrokerServiceClient;

              UpdatePatient();
              dlgProgresss.Title = "Update patient information";
              dlgProgresss.Description = "Updating...";
              dlgProgresss.Action = () =>
              {
                 client.UpdateMPPS(MainForm.Mpps.MPPSSOPInstanceUID, MainForm.Mpps);
              };

              if (dlgProgresss.ShowDialog(this) == DialogResult.Cancel)
              {
                 if (dlgProgresss.Exception != null)
                 {
                    e.Cancel = true;
                    Messager.ShowError(this, dlgProgresss.Exception);
                 }
              }
           }

            base.OnWizardFinish(sender, e);
        }                     

        private void UpdateUI(bool clear)
        {
           if (!clear)
           {
              if (MainForm.Mpps.Patient == null)
                 MainForm.Mpps.UnscheduledPatient = new PatientInfoforUnscheduledPPS();

              textBoxId.Text = MainForm.Mpps.UnscheduledPatient.PatientID;
              textBoxIssuerOfPatientId.Text = MainForm.Mpps.UnscheduledPatient.IssuerofPatientID;
              textBoxName.Text = MainForm.Mpps.UnscheduledPatient.PatientName;

              if (MainForm.Mpps.Patient.PatientBirthDate.HasValue)
              {
                 dateTimePickerBirth.Value = MainForm.Mpps.Patient.PatientBirthDate.Value.Date1.ToDateTime();
              }

              if (!string.IsNullOrEmpty(MainForm.Mpps.Patient.PatientSex))
              {
                 int index = comboBoxSex.FindStringExact(MainForm.Mpps.Patient.PatientSex);

                 comboBoxSex.SelectedIndex = index;
              }
              else
                 comboBoxSex.Text = "";
           }
           else
           {
              textBoxId.Text = string.Empty;
              textBoxIssuerOfPatientId.Text = string.Empty;
              textBoxName.Text = string.Empty;
              dateTimePickerBirth.Value = DateTime.Now;
              comboBoxSex.SelectedIndex = -1;
           }
        }

        private void UpdatePatient()
        {
           MainForm.Mpps.UnscheduledPatient.PatientID = textBoxId.Text;
           MainForm.Mpps.UnscheduledPatient.IssuerofPatientID = textBoxIssuerOfPatientId.Text;
           MainForm.Mpps.UnscheduledPatient.PatientName = textBoxName.Text;
           MainForm.Mpps.UnscheduledPatient.PatientSex = comboBoxSex.Text;

            if (dateTimePickerBirth.Checked)
               MainForm.Mpps.UnscheduledPatient.PatientBirthDate = new DicomDateRangeValue() { Date1 = new DicomDateValue(dateTimePickerBirth.Value) };
        }

        public override void OnReset()
        {
           UpdateUI(true);
        }                         
    }
}

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
using MPPSWCFDemo.Broker;
using Leadtools.Dicom;

namespace MPPSWCFDemo.UI
{
   public partial class PatientForm : Form
   {
      private WCFPPSInformation _Mpps;

      public PatientForm(WCFPPSInformation mpps)
      {
         InitializeComponent();
         _Mpps = mpps;
      }

      private void PatientForm_Load(object sender, EventArgs e)
      {
         if (_Mpps.Patient != null)
         {
            Text = "Edit Patient [" + _Mpps.Patient.PatientID + "]";
            textBoxPatientId.Enabled = false;
            textBoxIssuerOfPatientId.Enabled = false;
            UpdateUI();
         }
         else
         {
            Text = "Add New Patient";            
         }
      }

      public bool IsValid()
      {
         bool valid = true;

         if (textBoxPatientId.Text.Length == 0)
         {
            valid = false;
            errorProvider.SetError(textBoxPatientId, "Must provide patient id");
            textBoxPatientId.Focus();
         }
         else
            errorProvider.SetError(textBoxPatientId, string.Empty);

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
         textBoxPrefix.Text = _Mpps.Patient.PatientNamePrefix;
         textBoxFamily.Text = _Mpps.Patient.PatientNameFamilyName;
         textBoxGiven.Text = _Mpps.Patient.PatientNameGivenName;
         textBoxSuffix.Text = _Mpps.Patient.PatientNameSuffix;
         textBoxPatientId.Text = _Mpps.Patient.PatientID;
         textBoxIssuerOfPatientId.Text = _Mpps.Patient.IssuerOfPatientID;

         if (_Mpps.Patient.PatientBirthDate.HasValue)
         {
            dateTimePickerBirth.Value = _Mpps.Patient.PatientBirthDate.Value.Date1.ToDateTime();
         }

         if (!string.IsNullOrEmpty(_Mpps.Patient.PatientSex))
         {
            int index = comboBoxSex.FindStringExact(_Mpps.Patient.PatientSex);

            comboBoxSex.SelectedIndex = index;
         }
         else
            comboBoxSex.Text = "";

         textBoxSpecialNeeds.Text = _Mpps.Patient.SpecialNeeds;
         textBoxComments.Text = _Mpps.Patient.PatientComments;
      }

      private void UpdatePatient()
      {
         _Mpps.Patient.PatientID = textBoxPatientId.Text;
         _Mpps.Patient.IssuerOfPatientID = textBoxIssuerOfPatientId.Text;
         _Mpps.Patient.PatientNamePrefix = textBoxPrefix.Text;
         _Mpps.Patient.PatientNameFamilyName = textBoxFamily.Text;
         _Mpps.Patient.PatientNameGivenName = textBoxGiven.Text;
         _Mpps.Patient.PatientNameSuffix = textBoxSuffix.Text;

         if (dateTimePickerBirth.Checked)
            _Mpps.Patient.PatientBirthDate = new DicomDateRangeValue() { Date1 = new DicomDateValue(dateTimePickerBirth.Value) };

         _Mpps.Patient.PatientSex = comboBoxSex.Text;
         _Mpps.Patient.SpecialNeeds = textBoxSpecialNeeds.Text;
         _Mpps.Patient.PatientComments = textBoxComments.Text;
      }

      private void PatientForm_FormClosing(object sender, FormClosingEventArgs e)
      {
         if (DialogResult == DialogResult.OK)
         {
            e.Cancel = !IsValid();
            if (!e.Cancel)
            {
               if (_Mpps.Patient == null)
                  _Mpps.Patient = new WCFPatient();
               UpdatePatient();
            }
         }
      }
     
      private void PatientForm_Paint(object sender, PaintEventArgs e)
      {
         PaintUtils.HighlightRequiredFields(this, e.Graphics, true, Color.Red);
      }
   }
}

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
using Leadtools.Dicom;
using Leadtools.Dicom.Common.DataTypes;

namespace MPPSWCFDemo.UI.Pages
{
   public partial class MPPSInstancePage : InternalTemplatePage
   {
      private string _OriginalMppsInstance = string.Empty;
      //private bool _Update = false;
      //private bool _GotUIDList = false;

      public MPPSInstancePage()
      {
         InitializeComponent();
         LoadModalities();
      }

      private void LoadModalities()
      {
         IEnumerator<KeyValuePair<ModalityType, string>> modalities = ModalityDescriptor.GetEnumerator();

         while (modalities.MoveNext())
         {
            comboBoxModality.Items.Add(modalities.Current.Key);
         }
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

         if (e.PreviousPage.GetType() == typeof(IntroductionPage))
         {
            buttonQuery_Click(buttonQuery, EventArgs.Empty);
         }
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
            BrokerServiceClient client = GetWizard().Tag as BrokerServiceClient;            

            UpdateMpps();
            dlgProgresss.Title = "Update MPPS";
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

            dlgProgresss.Title = "Update Patient";
            dlgProgresss.Description = "Updating...";
            dlgProgresss.Action = () =>
            {
               client.UpdatePatient(MainForm.Mpps.Patient.PatientID, MainForm.Mpps.Patient.IssuerOfPatientID, MainForm.Mpps.Patient);
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
         base.OnWizardNext(sender, e);
      }

      public override void OnOptionButton1(object sender, EventArgs e)
      {
         UpdateUI(true);
      }

      public bool IsValid()
      {
         bool valid = true;
         
         Validate(textBoxPPSId, "Must provide a value for performed procedure step id", ref valid);
         Validate(textBoxStationAE, "Must provide a value for performed station ae title", ref valid);
         Validate(comboBoxStatus, "Must provide a value for performed procedure step status", ref valid);
         Validate(comboBoxModality, "Must provide a value for modality", ref valid);
         Validate(textBoxStudyInstance, "Must provide a value for study instance uid", ref valid);

         return valid;
      }


      private void Validate(Control control, string error, ref bool valid)
      {
         if (control.Text.Length == 0)
         {
            errorProvider.SetError(control, error);
            valid = false;
         }
         else
            errorProvider.SetError(control, string.Empty);
      }

      private void UpdateUI(bool clear)
      {
         if (!clear)
         {            
            textBoxMPPSInstance.Text = MainForm.Mpps.MPPSSOPInstanceUID;          
            textBoxPPSId.Text = MainForm.Mpps.PerformedProcedureStepID;
            textBoxStationAE.Text = MainForm.Mpps.PerformedStationAETitle;
            textBoxStationName.Text = MainForm.Mpps.PerformedStationName;
            textBoxLocation.Text = MainForm.Mpps.PerformedLocation;
            comboBoxStatus.Text = MainForm.Mpps.PerformedProcedureStepStatus;
            dateTimePickerStartDate.Value = MainForm.Mpps.PerformedProcedureStepStartDate.Value.Date1.ToDateTime();
            dateTimePickerStartTime.Value = MainForm.Mpps.PerformedProcedureStepStartTime.Value.Time1.ToDateTime();
            if (MainForm.Mpps.PerformedProcedureStepEndDate.HasValue)
            {
               dateTimePickerEndDate.Value = MainForm.Mpps.PerformedProcedureStepEndDate.Value.Date1.ToDateTime();
               dateTimePickerEndDate.Checked = true;
            }
            else
               dateTimePickerEndDate.Checked = false;
            if (MainForm.Mpps.PerformedProcedureStepEndTime.HasValue)
            {
               dateTimePickerEndTime.Value = MainForm.Mpps.PerformedProcedureStepEndTime.Value.Time1.ToDateTime();
               dateTimePickerEndTime.Checked = true;
            }
            else
               dateTimePickerEndTime.Checked = false;
            comboBoxModality.Text = MainForm.Mpps.Modality;
            textBoxStudyInstance.Text = MainForm.Mpps.StudyInstanceUID;
            textBoxDescription.Text = MainForm.Mpps.PerformedProcedureStepDescription;
            textBoxComments.Text = MainForm.Mpps.CommentsonthePerformedProcedureStep;
            SetPatientInfo();            
         }
         else
         {
            textBoxMPPSInstance.Text = string.Empty;
            textBoxPPSId.Text = string.Empty;
            textBoxStationAE.Text = string.Empty;
            textBoxStationName.Text = string.Empty;
            textBoxLocation.Text = string.Empty;
            comboBoxStatus.SelectedIndex = -1;
            dateTimePickerStartDate.Value = DateTime.Now;
            dateTimePickerStartTime.Value = DateTime.Now;
            dateTimePickerEndDate.Value = DateTime.Now;
            dateTimePickerEndDate.Checked = false;
            dateTimePickerEndTime.Value = DateTime.Now;
            dateTimePickerEndTime.Checked = false;
            comboBoxModality.SelectedIndex = -1;
            textBoxStudyInstance.Text = string.Empty;
            textBoxDescription.Text = string.Empty;
            textBoxComments.Text = string.Empty;
            labelPatient.Text = string.Empty;
            errorProvider.Clear();
         }
      }

      private void UpdateMpps()
      {
         if (MainForm.Mpps == null)
         {
            MainForm.Mpps = new WCFPPSInformation();
            MainForm.Mpps.PPSDiscontinuationReasonCodeSequence = new List<PPSDiscontinuationReasonCodeSequence>();
            MainForm.Mpps.ProcedureCodeSequence = new List<ProcedureCodeSequence>();
            MainForm.Mpps.PerformedProtocolCodeSequence = new List<PerformedProtocolCodeSequence>();
            MainForm.Mpps.PPSRelationShip = new List<PPSRelationship>();
            MainForm.Mpps.PerformedSeriesSequence = new List<PerformedSeriesSequence>();
            MainForm.Mpps.ReferencedImageSequence = new List<WCFReferencedImageSequence>();
            MainForm.Mpps.ReferencedNonImageCompositeSequence = new List<ReferencedNonImageCompositeSequence>();
            MainForm.Mpps.UnscheduledPatient = new PatientInfoforUnscheduledPPS();
         }

         MainForm.Mpps.MPPSSOPInstanceUID = textBoxMPPSInstance.Text;
         MainForm.Mpps.PerformedProcedureStepID = textBoxPPSId.Text;
         MainForm.Mpps.PerformedStationAETitle = textBoxStationAE.Text;
         MainForm.Mpps.PerformedStationName = textBoxStationName.Text;
         MainForm.Mpps.PerformedLocation = textBoxLocation.Text;
         MainForm.Mpps.PerformedProcedureStepStatus = comboBoxStatus.Text;
         MainForm.Mpps.PerformedProcedureStepStartDate = new DicomDateRangeValue() { Date1 = new DicomDateValue(dateTimePickerStartDate.Value) };
         MainForm.Mpps.PerformedProcedureStepStartTime = new DicomTimeRangeValue() { Time1 = new DicomTimeValue(dateTimePickerStartTime.Value) };
         if (dateTimePickerEndDate.Checked)
         {
            MainForm.Mpps.PerformedProcedureStepEndDate = new DicomDateRangeValue() { Date1 = new DicomDateValue(dateTimePickerEndDate.Value) };
            MainForm.Mpps.PerformedProcedureStepEndTime = new DicomTimeRangeValue() { Time1 = new DicomTimeValue(dateTimePickerEndTime.Value) };
         }
         MainForm.Mpps.Modality = comboBoxModality.Text;
         MainForm.Mpps.StudyInstanceUID = textBoxStudyInstance.Text;
         MainForm.Mpps.PerformedProcedureStepDescription = textBoxDescription.Text;
         MainForm.Mpps.CommentsonthePerformedProcedureStep = textBoxComments.Text;
      }

      public override void OnReset()
      {
         UpdateUI(true);
      }

      private void SetPatientInfo()
      {
         if (MainForm.Mpps.Patient != null)
         {
            WCFPatient p = MainForm.Mpps.Patient;

            labelPatient.Text = string.Format("[{0}] {1} {2}", p.PatientID, p.PatientNameGivenName, p.PatientNameFamilyName);
         }
         else
            labelPatient.Text = "Not Associated With A Patient";
      }
      
      private void MPPSInstancePage_Paint(object sender, PaintEventArgs e)
      {
         PaintUtils.HighlightRequiredFields(this, e.Graphics, true, Color.Red);
      }      

      private void MPPSInstancePage_Load(object sender, EventArgs e)
      {
         GetWizard().Option1Caption = "Clear";

         Application.Idle += new EventHandler(Application_Idle);
      }

      void Application_Idle(object sender, EventArgs e)
      {
         buttonDelete.Enabled = textBoxMPPSInstance.Text.Length > 0;
         if(GetWizard().ActivePage == this)
            GetWizard().NextButton.Enabled = MainForm.Mpps != null;
         linkLabelPatient.Enabled = MainForm.Mpps != null;
      }

      private void dateTimePickerEndDate_MouseDown(object sender, MouseEventArgs e)
      {
         dateTimePickerEndTime.Checked = dateTimePickerEndDate.Checked;
      }

      private void dateTimePickerEndTime_MouseDown(object sender, MouseEventArgs e)
      {
         dateTimePickerEndDate.Checked = dateTimePickerEndTime.Checked;
      }

      private void dateTimePickerEndDate_KeyDown(object sender, KeyEventArgs e)
      {
         if (e.KeyCode == Keys.Space)
         {
            dateTimePickerEndTime.Checked = !dateTimePickerEndDate.Checked;
         }
      }

      private void dateTimePickerEndTime_KeyDown(object sender, KeyEventArgs e)
      {
         if (e.KeyCode == Keys.Space)
         {
            dateTimePickerEndDate.Checked = !dateTimePickerEndTime.Checked;
         }
      }
     
      private void buttonQuery_Click(object sender, EventArgs e)
      {
         QueryForm queryForm = new QueryForm(GetWizard().Tag as BrokerServiceClient);

         if (queryForm.ShowDialog(this) == DialogResult.OK)
         {
            MainForm.Mpps = queryForm.PPSInfo;
            UpdateUI(false);
            errorProvider.Clear();            
         }
      }

      private void buttonDelete_Click(object sender, EventArgs e)
      {
         ProgressDialog dlgProgresss = new ProgressDialog();
         BrokerServiceClient client = GetWizard().Tag as BrokerServiceClient;
        
         dlgProgresss.Title = "Deleting MPPS";
         dlgProgresss.Description = "Deleting...";
         dlgProgresss.Action = () =>
         {
            client.DeleteMPPS(MainForm.Mpps.MPPSSOPInstanceUID);
         };

         if (dlgProgresss.ShowDialog(this) == DialogResult.Cancel)
         {
            if (dlgProgresss.Exception != null)
            {
               Messager.ShowError(this, dlgProgresss.Exception);
            }
         }
         else
         {
            OnReset();
            buttonQuery_Click(buttonQuery, EventArgs.Empty);
         }
      }

      private void linkLabelPatient_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
      {
         PatientForm patientForm = new PatientForm(MainForm.Mpps);

         if (patientForm.ShowDialog(this) == DialogResult.OK)
         {
            SetPatientInfo();
         }
      }
   }
}

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
using Leadtools.Demos;
using Leadtools.Dicom.Common.DataTypes;
using Leadtools.Dicom;

namespace MPPSWCFDemo.UI
{
   public partial class QueryForm : Form
   {
      private BrokerServiceClient _Client;

      public WCFPPSInformation PPSInfo
      {
         get
         {
            if (SearchResults.SelectedItems.Count == 1)
            {
               return SearchResults.SelectedItems[0].Tag as WCFPPSInformation;
            }
            return null;
         }
      }

      public QueryForm(BrokerServiceClient client)
      {
         InitializeComponent();
         _Client = client;
         LoadModalities();
      }

      private void LoadModalities()
      {
         IEnumerator<KeyValuePair<ModalityType, string>> modalities = ModalityDescriptor.GetEnumerator();

         while (modalities.MoveNext())
         {
            Modality.Items.Add(modalities.Current.Key);
         }
      }

      private delegate DicomDateRangeValue? GetDateDelegate(DateTimePicker start, DateTimePicker end);

      private DicomDateRangeValue? GetDate(DateTimePicker start, DateTimePicker end)
      {
         if (InvokeRequired)
         {
            return (DicomDateRangeValue?)Invoke(new GetDateDelegate(GetDate), start, end);
         }
         else
         {
            if (start.Checked || end.Checked)
            {
               DicomDateRangeValue range = new DicomDateRangeValue();

               if (start.Checked)
                  range.Date1 = new DicomDateValue(start.Value);
               if (end.Checked)
                  range.Date2 = new DicomDateValue(end.Value);
               return range;
            }
            return null;
         }        
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

      private void buttonQuery_Click(object sender, EventArgs e)
      {
         ProgressDialog dlgProgresss = new ProgressDialog();
         List<WCFPPSInformation> mppsInfo = null;
         string modality = Modality.Text;
         string status = Status.Text;

         SearchResults.Items.Clear();
         dlgProgresss.Title = "Query";
         dlgProgresss.Description = "Getting list of unscheduled mpps";
         dlgProgresss.Action = () =>
         {
            MPPSQuery query = new MPPSQuery() { AccessionNumber = AccessionNumber.Text, RequestedProcedureId = RequestedProcedureId.Text, ScheduledProcedureId = ScheduledProcedureId.Text };

            query.Patient = new WCFPatient() { PatientID = PatientId.Text, PatientNameGivenName = Firstname.Text, PatientNameFamilyName = Lastname.Text };
            query.PPSInfo = new WCFPPSInformation() { PerformedStationAETitle = PerformedStationAe.Text, Modality = modality, PerformedProcedureStepStatus = status };
            query.PPSInfo.PerformedProcedureStepStartDate = GetDate(StartDateBegin, StartDateEnd);
            query.PPSInfo.PerformedProcedureStepEndDate = GetDate(EndDateBegin, EndDateEnd);
            mppsInfo = _Client.QueryMPPS(query);
         };
         
         if (dlgProgresss.ShowDialog(this) == DialogResult.OK)
         {
            foreach (WCFPPSInformation info in mppsInfo)
            {
               string patientid = info.Patient!=null?info.Patient.PatientID:string.Empty;
               ListViewItem item = SearchResults.Items.Add(patientid);

               if (info.Patient != null)
               {
                  item.SubItems.Add(info.Patient.PatientNameGivenName + " " + info.Patient.PatientNameFamilyName);
               }
               else
                  item.SubItems.Add(string.Empty);

               item.SubItems.Add(info.PerformedProcedureStepStatus);
               item.SubItems.Add(info.Modality);
               item.SubItems.Add(info.PerformedProcedureStepID);
               item.SubItems.Add(info.PerformedStationAETitle);
               item.SubItems.Add(info.PerformedProcedureStepStartDate.HasValue ? info.PerformedProcedureStepStartDate.Value.Date1.ToString() : string.Empty);
               item.SubItems.Add(info.PerformedProcedureStepEndDate.HasValue ? info.PerformedProcedureStepEndDate.Value.Date1.ToString() : string.Empty);
               item.Tag = info;
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

      private void buttonClear_Click(object sender, EventArgs e)
      {
         PatientId.Text = string.Empty;
         Firstname.Text = string.Empty;         
         AccessionNumber.Text = string.Empty;
         Modality.SelectedIndex = -1;
         RequestedProcedureId.Text = string.Empty;
         ScheduledProcedureId.Text = string.Empty;
         PerformedStationAe.Text = string.Empty;
         StartDateBegin.Checked = false;
         StartDateEnd.Checked = false;
         EndDateBegin.Checked = false;
         EndDateEnd.Checked = false;
         Status.SelectedIndex = -1;
      }

      private void SearchResults_DoubleClick(object sender, EventArgs e)
      {
         DialogResult = DialogResult.OK;
      }

      private void QueryForm_Load(object sender, EventArgs e)
      {
         Application.Idle += new EventHandler(Application_Idle);
      }

      void Application_Idle(object sender, EventArgs e)
      {
         buttonOK.Enabled = SearchResults.SelectedItems.Count == 1;
      }
   }
}

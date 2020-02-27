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
using MPPSWCFDemo.Broker;
using Leadtools.Wizard;
using Leadtools.Demos;
using Leadtools.Dicom.Common.DataTypes;

namespace MPPSWCFDemo.UI.Pages
{
    public partial class SequencesPage : InternalTemplatePage
    {              
        public SequencesPage()
        {
            InitializeComponent();            
            Application.Idle += new EventHandler(Application_Idle);
        }        

        void Application_Idle(object sender, EventArgs e)
        {                       
            EnableEditButtons(listViewReasonCode, buttonEditReasonCode, buttonDeleteReasonCode);
            EnableEditButtons(listViewCodeSequence, buttonEditCodeSequence, buttonDeleteCodeSequence);
            EnableEditButtons(listViewProtocol, buttonEditProtocol, buttonDeleteProtocol);
        }

        private void EnableEditButtons(ListView listView, Button edit, Button delete)
        {
            edit.Enabled = listView.SelectedItems.Count == 1;
            delete.Enabled = edit.Enabled;
        }

        protected override WizardSheet.WizardButtons GetWizardButtons()
        {
            WizardSheet.WizardButtons buttons = base.GetWizardButtons();

            buttons |= WizardSheet.WizardButtons.Option1;
            return buttons;
        }

        public override void OnOptionButton1(object sender, EventArgs e)
        {
            UpdateUI(true);
        }

        public override void OnSetActive(object sender, WizardCancelEventArgs e)
        {
            base.OnSetActive(sender, e);
            LoadSequences();
        }

        public override void OnWizardNext(object sender, WizardPageEventArgs e)
        {
            ProgressDialog dlgProgresss = new ProgressDialog();
            BrokerServiceClient client = GetWizard().Tag as BrokerServiceClient;

            base.OnWizardNext(sender, e);
            UpdateMPPS();

            dlgProgresss.Title = "Update MPPS";
            dlgProgresss.Description = "Updating..." ;
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

        private void UpdateMPPS()
        {
            MainForm.Mpps.PPSDiscontinuationReasonCodeSequence.Clear();
            foreach(ListViewItem item in listViewReasonCode.Items)
            {
                PPSDiscontinuationReasonCodeSequence s = item.Tag as PPSDiscontinuationReasonCodeSequence;

                MainForm.Mpps.PPSDiscontinuationReasonCodeSequence.Add(s);
            }

            MainForm.Mpps.ProcedureCodeSequence.Clear();
            foreach (ListViewItem item in listViewCodeSequence.Items)
            {
                ProcedureCodeSequence s = item.Tag as ProcedureCodeSequence;

                MainForm.Mpps.ProcedureCodeSequence.Add(s);
            }

            MainForm.Mpps.PerformedProtocolCodeSequence.Clear();
            foreach (ListViewItem item in listViewProtocol.Items)
            {
                PerformedProtocolCodeSequence s = item.Tag as PerformedProtocolCodeSequence;

                MainForm.Mpps.PerformedProtocolCodeSequence.Add(s);
            }
        }


        /// <summary>
        /// Updates the UI.
        /// </summary>
        /// <remarks></remarks>
        private void UpdateUI(bool clear)
        {
            if (!clear)
            {
                LoadSequences();
            }
            else
            {
                ClearSequences();
            }            
        }

        private void LoadSequences()
        {
            ClearSequences();
            foreach (PPSDiscontinuationReasonCodeSequence s in MainForm.Mpps.PPSDiscontinuationReasonCodeSequence)
            {
                AddPPSDiscontinuationReasonCodeSequence(s);
            }

            foreach (ProcedureCodeSequence s in MainForm.Mpps.ProcedureCodeSequence)
            {
                AddProcedureCodeSequence(s);
            }

            foreach (PerformedProtocolCodeSequence s in MainForm.Mpps.PerformedProtocolCodeSequence)
            {
                AddPerformedProtocolCodeSequence(s);
            }
        }

        public void ClearSequences()
        {
            listViewReasonCode.Items.Clear();
            listViewCodeSequence.Items.Clear();
            listViewProtocol.Items.Clear();
        }

        private void AddPPSDiscontinuationReasonCodeSequence(PPSDiscontinuationReasonCodeSequence sequence)
        {
            ListViewItem item = listViewReasonCode.Items.Add(sequence.CodeValue);

            item.SubItems.Add(sequence.CodingSchemeDesignator);
            item.SubItems.Add(sequence.CodeMeaning);
            item.SubItems.Add(sequence.CodingSchemeVersion);
            item.SubItems.Add(sequence.OrderNumber);
            item.Tag = sequence;
        }

        private void AddProcedureCodeSequence(ProcedureCodeSequence sequence)
        {
            ListViewItem item = listViewCodeSequence.Items.Add(sequence.CodeValue);

            item.SubItems.Add(sequence.CodingSchemeDesignator);
            item.SubItems.Add(sequence.CodeMeaning);
            item.SubItems.Add(sequence.CodingSchemeVersion);
            item.SubItems.Add(sequence.OrderNumber);
            item.Tag = sequence;
        }

        private void AddPerformedProtocolCodeSequence(PerformedProtocolCodeSequence sequence)
        {
            ListViewItem item = listViewProtocol.Items.Add(sequence.CodeValue);

            item.SubItems.Add(sequence.CodingSchemeDesignator);
            item.SubItems.Add(sequence.CodeMeaning);
            item.SubItems.Add(sequence.CodingSchemeVersion);
            item.SubItems.Add(sequence.OrderNumber);
            item.Tag = sequence;
        }

        public override void OnReset()
        {
            UpdateUI(true);
        }

        private void EditSequence<T>(ListView listView, string description) where T: class
        {
            ListViewItem item = listView.SelectedItems[0];
            T sequence = item.Tag as T;
            ObjectEditor<T> editor = new ObjectEditor<T>(sequence, description);

            if (editor.ShowDialog(this) == DialogResult.OK)
            {
                Type t = typeof(T);

                item.Text = t.GetProperty("CodeValue").GetValue(editor.EditObject,null) as string;
                item.SubItems[1].Text = t.GetProperty("CodingSchemeDesignator").GetValue(editor.EditObject, null) as string;
                item.SubItems[2].Text = t.GetProperty("CodeMeaning").GetValue(editor.EditObject, null) as string;
                item.SubItems[3].Text = t.GetProperty("CodingSchemeVersion").GetValue(editor.EditObject, null) as string;
                item.SubItems[4].Text = t.GetProperty("OrderNumber").GetValue(editor.EditObject, null) as string;
                item.Tag = editor.EditObject;
            }
        }

        private void RemoveSelectedItem(ListView listview)
        {
            ListViewItem item = listview.SelectedItems[0];

            listview.Items.Remove(item);
        }

        private void buttonAddReasonCode_Click(object sender, EventArgs e)
        {
            ObjectEditor<PPSDiscontinuationReasonCodeSequence> editor = new ObjectEditor<PPSDiscontinuationReasonCodeSequence>(null, "PPS Discontinuation Reason Code Sequence");

            if (editor.ShowDialog(this) == DialogResult.OK)
            {
               PPSDiscontinuationReasonCodeSequence sequence = editor.EditObject as PPSDiscontinuationReasonCodeSequence;

               if (string.IsNullOrEmpty(sequence.CodeValue) || string.IsNullOrEmpty(sequence.CodingSchemeDesignator))
               {
                  Messager.ShowError(this, "Must provide a value for CodeValue and CodingSchemeDesignator.  Item not added to sequence.");
               }
               else
               {
                  AddPPSDiscontinuationReasonCodeSequence(editor.EditObject);
               }
            }
        }

        private void buttonEditReasonCode_Click(object sender, EventArgs e)
        {            
            EditSequence<PPSDiscontinuationReasonCodeSequence>(listViewReasonCode, "PPS Discontinuation Reason Code Sequence");
        }

        private void buttonDeleteReasonCode_Click(object sender, EventArgs e)
        {
            RemoveSelectedItem(listViewReasonCode);
        }

        private void buttonAddCodeSequence_Click(object sender, EventArgs e)
        {
            ObjectEditor<ProcedureCodeSequence> editor = new ObjectEditor<ProcedureCodeSequence>(null, "Procedure Code Sequence");

            if (editor.ShowDialog(this) == DialogResult.OK)
            {
               ProcedureCodeSequence sequence = editor.EditObject as ProcedureCodeSequence;

               if (string.IsNullOrEmpty(sequence.CodeValue) || string.IsNullOrEmpty(sequence.CodingSchemeDesignator))
               {
                  Messager.ShowError(this, "Must provide a value for CodeValue and CodingSchemeDesignator.  Item not added to sequence.");
               }
               else
               {
                  AddProcedureCodeSequence(editor.EditObject);
               }
            }
        }

        private void buttonEditCodeSequence_Click(object sender, EventArgs e)
        {            
            EditSequence<ProcedureCodeSequence>(listViewCodeSequence, "Procedure Code Sequence");
        }

        private void buttonDeleteCodeSequence_Click(object sender, EventArgs e)
        {
            RemoveSelectedItem(listViewCodeSequence);
        }

        private void buttonAddProtocol_Click(object sender, EventArgs e)
        {
            ObjectEditor<PerformedProtocolCodeSequence> editor = new ObjectEditor<PerformedProtocolCodeSequence>(null, "Performed Protocol Sequence");

            if (editor.ShowDialog(this) == DialogResult.OK)
            {
               PerformedProtocolCodeSequence sequence = editor.EditObject as PerformedProtocolCodeSequence;

               if (string.IsNullOrEmpty(sequence.CodeValue) || string.IsNullOrEmpty(sequence.CodingSchemeDesignator))
               {
                  Messager.ShowError(this, "Must provide a value for CodeValue and CodingSchemeDesignator.  Item not added to sequence.");
               }
               else
               {
                  AddPerformedProtocolCodeSequence(editor.EditObject);
               }
            }
        }        

        private void buttonEditProtocol_Click(object sender, EventArgs e)
        {            
            EditSequence<PerformedProtocolCodeSequence>(listViewProtocol, "Performed Protocol Code Sequence");
        }       

        private void buttonDeleteProtocol_Click(object sender, EventArgs e)
        {
            RemoveSelectedItem(listViewProtocol);
        }                 
    }
}

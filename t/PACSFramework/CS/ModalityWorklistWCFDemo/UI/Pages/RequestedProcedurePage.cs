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
using Leadtools.DicomDemos;

namespace ModalityWorklistWCFDemo.UI.Pages
{
    public partial class RequestedProcedurePage : InternalTemplatePage
    {       
        private bool _Update = false;
        private string _OriginalRequestedProcedureId;        

        private ImagingServiceRequest _ImagingServiceRequest;

        public ImagingServiceRequest ImagingServiceRequest
        {
            get { return _ImagingServiceRequest; }           
        }

        private WCFRequestedProcedure _RequestedProcedure = new WCFRequestedProcedure() { ReferencedStudySequence = new List<ReferencedStudySequence>()};

        public WCFRequestedProcedure RequestedProcedure
        {
            get { return _RequestedProcedure; }
        }

        public RequestedProcedurePage()
        {
            InitializeComponent();
            errorProvider.SetIconAlignment(comboBoxRequestedId, ErrorIconAlignment.TopLeft);
            Application.Idle += new EventHandler(Application_Idle);
        }

        void Application_Idle(object sender, EventArgs e)
        {            
            buttonAddRPCS.Enabled = propertyGridRequestedProcedure.SelectedObject == null;
            buttonDeleteRPCS.Enabled = !buttonAddRPCS.Enabled;
            buttonDeleteRS.Enabled = listViewReferencedStudy.SelectedItems.Count == 1;
            buttonEditRS.Enabled = buttonDeleteRS.Enabled;
            buttonEditVisit.Enabled = textBoxAdmissionId.Text.Length > 0;
            buttonDeleteVisit.Enabled = buttonEditVisit.Enabled;
            buttonAddVisit.Enabled = textBoxAdmissionId.Text.Length == 0;
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
            if (e.PreviousPage != null && e.PreviousPage.GetType() == typeof(ImagingServiceRequestPage))
            {
                ImagingServiceRequestPage p = e.PreviousPage as ImagingServiceRequestPage;
                ImagingServiceRequest o = _ImagingServiceRequest;

                _ImagingServiceRequest = p.ImagingServiceRequest;
                comboBoxRequestedId.Items.Clear(); // ***
                if (
                       (o==null)                                                       || 
                       (o.AccessionNumber != _ImagingServiceRequest.AccessionNumber)   ||
                       (string.IsNullOrEmpty(comboBoxRequestedId.Text))
                       )
                {
                    ProgressDialog dlgProgresss = new ProgressDialog();
                    BrokerServiceClient client = GetWizard().Tag as BrokerServiceClient;
                    List<string> ids = null;

                    ids = new List<string>();
                    dlgProgresss.Title = "Find";
                    dlgProgresss.Description = "Getting list of requested procedure ids";
                    dlgProgresss.Action = () =>
                    {
                        ids = client.GetRequestedProcedureIDs(_ImagingServiceRequest.AccessionNumber);
                    };

                    UpdateUI(true);
                    comboBoxRequestedId.Items.Clear();
                    if (dlgProgresss.ShowDialog(this) == DialogResult.OK)
                    {
                        foreach (string id in ids)
                        {
                            comboBoxRequestedId.Items.Add(id);
                        }
                    }

                    if (dlgProgresss.Exception != null)
                    {
                        Messager.ShowError(this, dlgProgresss.Exception);
                    }                                        

                    if (dlgProgresss.Exception != null)
                    {
                        Messager.ShowError(this, dlgProgresss.Exception);
                    }  
                }
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

                if (_Update && comboBoxRequestedId.Text != _OriginalRequestedProcedureId)
                {
                    DialogResult r = Messager.ShowQuestion(this, "You searched for a requested procedure but have changed some of the identifying information.  " +
                                                                 "Would you like to update this requested procedure with the new information?\r\n\r\nClicking No will add a new requested procedure.",
                                                                 MessageBoxButtons.YesNo);
                    _Update = r == DialogResult.Yes;
                }

                UpdateRequestedProcedure();
                dlgProgresss.Title = _Update ? "Update Requested Procedure" : "Add Requested Procedure";
                dlgProgresss.Description = _Update ? "Updating..." : "Adding...";
                dlgProgresss.Action = () =>
                {
                    if (_Update)
                        client.UpdateRequestedProcedure(_ImagingServiceRequest.AccessionNumber, _OriginalRequestedProcedureId, RequestedProcedure);

                    else
                        client.AddRequestedProcedure(_ImagingServiceRequest.AccessionNumber, RequestedProcedure);
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
                        int index = comboBoxRequestedId.Items.IndexOf(_OriginalRequestedProcedureId);

                        if (index != -1)
                            comboBoxRequestedId.Items.Remove(_OriginalRequestedProcedureId);
                    }
                    comboBoxRequestedId.Items.Add(RequestedProcedure.RequestedProcedureID);
                    comboBoxRequestedId.Text = RequestedProcedure.RequestedProcedureID;
                    _OriginalRequestedProcedureId = RequestedProcedure.RequestedProcedureID;
                }
            }

            base.OnWizardNext(sender, e);
        }

        private bool IsValid()
        {
            bool valid = true;

            if (string.IsNullOrEmpty(comboBoxRequestedId.Text))
            {
                valid = false;
                errorProvider.SetError(comboBoxRequestedId, "Must provide a value requested procedure id.");
            }
            else
                errorProvider.SetError(comboBoxRequestedId, string.Empty);

            if (string.IsNullOrEmpty(textBoxStudyInstanceUID.Text))
            {
                valid = false;
                errorProvider.SetError(textBoxStudyInstanceUID, "Must provide a value for study instance uid.");
            }
            else
                errorProvider.SetError(textBoxStudyInstanceUID, string.Empty);

            if (string.IsNullOrEmpty(textBoxDescription.Text))
            {
                valid = false;
                errorProvider.SetError(textBoxDescription, "Must provide a value for requested procedure description.");
            }
            else
                errorProvider.SetError(textBoxDescription, string.Empty);

            return valid;
        }

        private void UpdateUI(bool clear)
        {
            if (!clear)
            {
                textBoxStudyInstanceUID.Text = _RequestedProcedure.StudyInstanceUID;
                textBoxComments.Text = _RequestedProcedure.RequestedProcedureComments;
                textBoxDescription.Text = _RequestedProcedure.RequestedProcedureDescription;
                if (_RequestedProcedure.Visit != null)
                {
                   textBoxAdmissionId.Text = _RequestedProcedure.Visit.AdmissionID;
                   textBoxAdmissionId.Tag = _RequestedProcedure.Visit;
                }
                else
                {
                   textBoxAdmissionId.Tag = null;
                   textBoxAdmissionId.Text = string.Empty;
                }

                if (!string.IsNullOrEmpty(_RequestedProcedure.RequestedProcedurePriority))
                {
                    int index = comboBoxPriority.FindStringExact(_RequestedProcedure.RequestedProcedurePriority.ToUpper());

                    comboBoxPriority.SelectedIndex = index;
                }

                propertyGridRequestedProcedure.SelectedObject = _RequestedProcedure.RequestedProcedureCodeSequence;

                listViewReferencedStudy.Items.Clear();
                foreach (ReferencedStudySequence rs in _RequestedProcedure.ReferencedStudySequence)
                {
                    AddReferencedStudy(rs);
                }
            }
            else
            {
                comboBoxRequestedId.Text = string.Empty;
                textBoxStudyInstanceUID.Text = string.Empty;
                textBoxComments.Text = string.Empty;
                textBoxDescription.Text = string.Empty;
                textBoxAdmissionId.Text = string.Empty;
                comboBoxPriority.SelectedIndex = -1;
                propertyGridRequestedProcedure.SelectedObject = null;
                listViewReferencedStudy.Items.Clear();
                _Update = false;
                errorProvider.Clear();
            }
        }

        private void UpdateRequestedProcedure()
        {
            _RequestedProcedure.RequestedProcedureID = comboBoxRequestedId.Text;
            _RequestedProcedure.StudyInstanceUID = textBoxStudyInstanceUID.Text;
            _RequestedProcedure.RequestedProcedureComments = textBoxComments.Text;
            _RequestedProcedure.RequestedProcedureDescription = textBoxDescription.Text;            
            _RequestedProcedure.RequestedProcedureCodeSequence = propertyGridRequestedProcedure.SelectedObject as RequestedProcedureCodeSequence;
            _RequestedProcedure.RequestedProcedurePriority = comboBoxPriority.Text;

            _RequestedProcedure.ReferencedStudySequence.Clear();
            foreach (ListViewItem item in listViewReferencedStudy.Items)
            {
                _RequestedProcedure.ReferencedStudySequence.Add(item.Tag as ReferencedStudySequence);
            }
        }

        private void AddReferencedStudy(ReferencedStudySequence rs)
        {
            ListViewItem item = listViewReferencedStudy.Items.Add(rs.ReferencedSOPClassUID);

            item.SubItems.Add(rs.ReferencedSOPInstanceUID);            
            item.Tag = rs;
        }

        public override void OnReset()
        {
            UpdateUI(true);
        }

        private void GetRequestedProcedureInfo()
        {
            ProgressDialog dlgProgresss = new ProgressDialog();
            BrokerServiceClient client = GetWizard().Tag as BrokerServiceClient;
            string id = comboBoxRequestedId.Text;

            dlgProgresss.Title = "Search";
            dlgProgresss.Description = "Searching for requested procedure";
            dlgProgresss.Action = () =>
            {
                _RequestedProcedure = client.FindRequestedProcedure(_ImagingServiceRequest.AccessionNumber, id);
            };

            _Update = false;
            _OriginalRequestedProcedureId = string.Empty;
            if (dlgProgresss.ShowDialog(this) == DialogResult.OK)
            {
                if (_RequestedProcedure != null)
                {
                    _Update = true;
                    UpdateUI(false);
                    _OriginalRequestedProcedureId = _RequestedProcedure.RequestedProcedureID;
                    errorProvider.Clear();
                }
                else
                {
                    Messager.ShowError(this, "Requested procedure not found.");
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

        private void buttonAddRPCS_Click(object sender, EventArgs e)
        {
            propertyGridRequestedProcedure.SelectedObject = new RequestedProcedureCodeSequence();
        }

        private void buttonDeleteRPCS_Click(object sender, EventArgs e)
        {
            propertyGridRequestedProcedure.SelectedObject = null;
        }

        private void buttonAddRS_Click(object sender, EventArgs e)
        {
            ObjectEditor<ReferencedStudySequence> editor = new ObjectEditor<ReferencedStudySequence>(null, "Referenced Study Sequence");

            if (editor.ShowDialog(this) == DialogResult.OK)
            {
                AddReferencedStudy(editor.EditObject);
            }
        }

        private void buttonEditRS_Click(object sender, EventArgs e)
        {
            ListViewItem item = listViewReferencedStudy.SelectedItems[0];
            ReferencedStudySequence rs = item.Tag as ReferencedStudySequence;
            ObjectEditor<ReferencedStudySequence> editor = new ObjectEditor<ReferencedStudySequence>(rs, "Referenced Study Sequence");

            if (editor.ShowDialog(this) == DialogResult.OK)
            {
                item.Text = editor.EditObject.ReferencedSOPClassUID;
                item.SubItems[1].Text = editor.EditObject.ReferencedSOPInstanceUID;                
                item.Tag = editor.EditObject;
            }
        }

        private void buttonDeleteRS_Click(object sender, EventArgs e)
        {
            ListViewItem item = listViewReferencedStudy.SelectedItems[0];

            listViewReferencedStudy.Items.Remove(item);
        }

        private void buttonEditVisit_Click(object sender, EventArgs e)
        {
           VisitEditor editor = new VisitEditor(_RequestedProcedure.Visit);

           if (editor.ShowDialog(this) == DialogResult.OK)
           {
              textBoxAdmissionId.Text = editor.Visit.AdmissionID;
           }           
        }

        private void buttonAddVisit_Click(object sender, EventArgs e)
        {
            VisitEditor editor = new VisitEditor(null);

            if (editor.ShowDialog(this) == DialogResult.OK)
            {
               _RequestedProcedure.Visit = editor.Visit;
               textBoxAdmissionId.Text = editor.Visit.AdmissionID;                              
            }
        }

        private void buttonDeleteVisit_Click(object sender, EventArgs e)
        {
           _RequestedProcedure.Visit = null;
           textBoxAdmissionId.Text = string.Empty;                       
        }

        private void RequestedProcedurePage_Paint(object sender, PaintEventArgs e)
        {
            PaintUtils.HighlightRequiredFields(this, e.Graphics, true, Color.Red);
        }

        private void comboBoxRequestedId_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxRequestedId.SelectedIndex != -1)
            {
                GetRequestedProcedureInfo();
            }
        }

        private void buttonNewUID_Click(object sender, EventArgs e)
        {
           textBoxStudyInstanceUID.Text = Utils.GenerateDicomUniqueIdentifier();
        }
    }
}

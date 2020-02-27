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

namespace MPPSWCFDemo.UI
{
    public partial class VisitEditor : Form
    {
        private WCFVisit _Visit;

        public WCFVisit Visit
        {
            get { return _Visit; }           
        }

        private string _OriginalAdmissionId = string.Empty;

        public string OriginalAdmissionId
        {
            get { return _OriginalAdmissionId; }            
        }

        public VisitEditor(WCFVisit visit)
        {
            InitializeComponent();
            if (visit == null)
            {
                _Visit = new WCFVisit();
                Text = "Add Visit";
            }
            else
            {
                _Visit = visit;
                Text = "Edit Visit";
                textBoxAdmissionId.Text = _Visit.AdmissionID;
                textBoxLocation.Text = _Visit.CurrentPatientLocation;
                propertyGridReferencedPatient.SelectedObject = _Visit.ReferencedPatientSequence;
                _OriginalAdmissionId = visit.AdmissionID;
            }
        }

        private void VisitEditor_Load(object sender, EventArgs e)
        {
            Application.Idle += new EventHandler(Application_Idle);
        }

        void Application_Idle(object sender, EventArgs e)
        {
            buttonAdd.Enabled = propertyGridReferencedPatient.SelectedObject == null;
            buttonDelete.Enabled = !buttonAdd.Enabled;
            buttonOK.Enabled = textBoxAdmissionId.Text.Length > 0;
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            _Visit.ReferencedPatientSequence = new ReferencedPatientSequence();
            propertyGridReferencedPatient.SelectedObject = _Visit.ReferencedPatientSequence;
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            propertyGridReferencedPatient.SelectedObject = null;
            _Visit.ReferencedPatientSequence = null;
        }

        private void VisitEditor_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult == DialogResult.OK)
            {
                _Visit.AdmissionID = textBoxAdmissionId.Text;
                _Visit.CurrentPatientLocation = textBoxLocation.Text;
                _Visit.ReferencedPatientSequence = propertyGridReferencedPatient.SelectedObject as ReferencedPatientSequence;
            }
        }
    }
}

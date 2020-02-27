// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace DicomDemo
{
    public partial class Page2 : UserControl
    {
        private Globals _globals;

        public Page2(ref Globals pGlobals)
        {
            InitializeComponent();

            _globals = pGlobals;
        }

        private void radBroad_CheckedChanged(object sender, EventArgs e)
        {
            grpBroad.Enabled = radBroad.Checked;
        }

        private void radPatient_CheckedChanged(object sender, EventArgs e)
        {
            grpPatient.Enabled = radPatient.Checked;
        }

        private void Page2_Load(object sender, EventArgs e)
        {
            try
            {
                PopulateModalityComboBox();

                // Set control values from global values
                if (_globals.m_nQueryType == 1)
                    radBroad.Checked = true;
                else
                    radPatient.Checked = true;

                chkScheduledDate.Checked = _globals.m_bCheckScheduledDate;
                dtpScheduledDate.Value = _globals.m_ScheduledDate;
                chkModality.Checked = _globals.m_bCheckModality;
                //find and select the Modality or the first if it cannot be found
                for (int i = 0; i < _globals.m_ModalityTable.Length; i++)
                {
                    if (_globals.m_strModality == _globals.m_ModalityTable[i].m_strValue)
                    {
                        cboModality.SelectedIndex = i;
                        break;
                    }
                }

                txtAccessionNumber.Text = _globals.m_strAccessionNumber;
                txtPatientID.Text = _globals.m_strPatientID;
                txtPatientName.Text = _globals.m_strPatientName;
                txtRequestedProcedureID.Text = _globals.m_strRequestedProcedureID;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        /*
         * Populates the combo box with the modality table
         */
        private void PopulateModalityComboBox()
        {
            try
            {
                for (int i = 0; i < _globals.m_ModalityTable.Length; i++)
                {
                    cboModality.Items.Add(_globals.m_ModalityTable[i].ToString());
                }
                cboModality.Sorted = true;
                cboModality.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void chkScheduledDate_CheckedChanged(object sender, EventArgs e)
        {
            dtpScheduledDate.Enabled = chkScheduledDate.Checked;
        }

        private void chkModality_CheckedChanged(object sender, EventArgs e)
        {
            cboModality.Enabled = chkModality.Checked;
        }
    }
}

// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Leadtools.DicomDemos;

namespace DicomDemo
{
    public partial class MwlItemDialog : Form
    {
        // Private properties
        private bool m_bIsNew;
        private string m_strItemID;

        // Public properties
        public string m_strSqlQuery;
        public string[] m_strItemValues;
        
        public MwlItemDialog(bool bIsNew)
        {
            InitializeComponent();

            m_bIsNew = bIsNew;
            m_strItemID = "";
            m_strSqlQuery = "";
        }

        /*
         * Populates the forms controls
         */
        private void PopulateFormControls()
        {
            try
            {
                // Combo Boxes
                // Sex
                cboSex.Items.Add("M");
                cboSex.Items.Add("F");
                cboSex.Items.Add("O");

                // Procedure Priority
                cboProcedurePriority.Items.Add("STAT");
                cboProcedurePriority.Items.Add("HIGH");
                cboProcedurePriority.Items.Add("ROUTINE");
                cboProcedurePriority.Items.Add("MEDIUM");
                cboProcedurePriority.Items.Add("LOW");

                // If we are editing an item, update the form with current information
                if (!m_bIsNew)
                {
                    ListViewItem.ListViewSubItemCollection items = ((MainForm)Owner).lstDatabase.SelectedItems[0].SubItems;
                    txtAccessionNumber.Text = items[0].Text;
                    txtModality.Text = items[1].Text;
                    txtInstitutionName.Text = items[2].Text;
                    txtReferringPhysicianName.Text = items[3].Text;
                    txtPatientName.Text = items[4].Text;
                    txtPatientID.Text = items[5].Text;
                    txtPatientBirthDate.Text = FormatDateTime(items[6].Text, true, true);
                    cboSex.Text = items[7].Text;
                    txtWeight.Text = items[8].Text;
                    txtStudyInstanceUID.Text = items[9].Text;
                    txtRequestingPhysician.Text = items[10].Text;
                    txtRequestedProcedureDescription.Text = items[11].Text;
                    txtAdmissionID.Text = items[12].Text;
                    txtStartDate.Text = FormatDateTime(items[14].Text, true, true);
                    txtStartTime.Text = FormatDateTime(items[15].Text, false, true);
                    txtPhysicianName.Text = items[16].Text;
                    txtDescription.Text = items[17].Text;
                    txtID.Text = items[18].Text;
                    txtLocation.Text = items[19].Text;
                    txtStationAETitle.Text = items[13].Text;
                    txtRequestedProcedureID.Text = items[20].Text;
                    txtReasonForProcedure.Text = items[21].Text;
                    cboProcedurePriority.Text = items[22].Text;

                    // Item ID is invisible
                    m_strItemID = items[23].Text;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error populating controls:\r\n\r\n" + ex.ToString());
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            m_strItemValues = new string[24] {
                txtAccessionNumber.Text,
                txtModality.Text,
                txtInstitutionName.Text,
                txtReferringPhysicianName.Text,
                txtPatientName.Text,
                txtPatientID.Text,
                FormatDateTime(txtPatientBirthDate.Text, true, false),
                cboSex.Text,
                txtWeight.Text,
                txtStudyInstanceUID.Text,
                txtRequestingPhysician.Text,
                txtRequestedProcedureDescription.Text,
                txtAdmissionID.Text,
                txtStationAETitle.Text,
                FormatDateTime(txtStartDate.Text, true, false),
                FormatDateTime(txtStartTime.Text, false, false),
                txtPhysicianName.Text,
                txtDescription.Text,
                txtID.Text,
                txtLocation.Text,
                txtRequestedProcedureID.Text,
                txtReasonForProcedure.Text,
                cboProcedurePriority.Text,
                m_strItemID
            };
            if (m_bIsNew)
            {
                // Set up SQL Query to add a new record
                m_strSqlQuery = "INSERT INTO MwlSCPTbl VALUES(NULL, " +
                                "'" + txtAccessionNumber.Text.PrepareDatabaseQueryString() + "'," +
                                "'" + txtModality.Text.PrepareDatabaseQueryString() + "'," +
                                "'" + txtInstitutionName.Text.PrepareDatabaseQueryString() + "'," +
                                "'" + txtReferringPhysicianName.Text.PrepareDatabaseQueryString() + "'," +
                                "'" + txtPatientName.Text.PrepareDatabaseQueryString() + "'," +
                                "'" + txtPatientID.Text.PrepareDatabaseQueryString() + "'," +
                                "'" + FormatDateTime(txtPatientBirthDate.Text, true, false) + "'," +
                                "'" + cboSex.Text.PrepareDatabaseQueryString() + "'," +
                                "'" + txtWeight.Text.PrepareDatabaseQueryString() + "'," +
                                "'" + txtStudyInstanceUID.Text.PrepareDatabaseQueryString() + "'," +
                                "'" + txtRequestingPhysician.Text.PrepareDatabaseQueryString() + "'," +
                                "'" + txtRequestedProcedureDescription.Text.PrepareDatabaseQueryString() + "'," +
                                "'" + txtAdmissionID.Text.PrepareDatabaseQueryString() + "'," +
                                "'" + txtStationAETitle.Text.PrepareDatabaseQueryString() + "'," +
                                "'" + FormatDateTime(txtStartDate.Text, true, false) + "'," +
                                "'" + FormatDateTime(txtStartTime.Text, false, false) + "'," +
                                "'" + txtPhysicianName.Text.PrepareDatabaseQueryString() + "'," +
                                "'" + txtDescription.Text.PrepareDatabaseQueryString() + "'," +
                                "'" + txtID.Text.PrepareDatabaseQueryString() + "'," +
                                "'" + txtLocation.Text.PrepareDatabaseQueryString() + "'," +
                                "'" + txtRequestedProcedureID.Text.PrepareDatabaseQueryString() + "'," +
                                "'" + txtReasonForProcedure.Text.PrepareDatabaseQueryString() + "'," +
                                "'" + cboProcedurePriority.Text.PrepareDatabaseQueryString() + "')";
            }
            else
            {
                // Set up SQL Query to add a new record
                m_strSqlQuery = "UPDATE MwlSCPTbl SET "                          +
                                "TAG_ACCESSION_NUMBER = '"                       + txtAccessionNumber.Text.PrepareDatabaseQueryString() + "'," +
                                "TAG_MODALITY = '"                               + txtModality.Text.PrepareDatabaseQueryString() + "'," +
                                "TAG_INSTITUTION_NAME = '"                       + txtInstitutionName.Text.PrepareDatabaseQueryString() + "'," +
                                "TAG_REFERRING_PHYSICIAN_NAME = '"               + txtReferringPhysicianName.Text.PrepareDatabaseQueryString() + "'," +
                                "TAG_PATIENT_NAME = '"                           + txtPatientName.Text.PrepareDatabaseQueryString() + "'," +
                                "TAG_PATIENT_ID = '"                             + txtPatientID.Text.PrepareDatabaseQueryString() + "'," +
                                "TAG_PATIENT_BIRTH_DATE = '"                     + FormatDateTime(txtPatientBirthDate.Text, true, false) + "'," +
                                "TAG_PATIENT_SEX = '"                            + cboSex.Text.PrepareDatabaseQueryString() + "'," +
                                "TAG_PATIENT_WEIGHT = '"                         + txtWeight.Text.PrepareDatabaseQueryString() + "'," +
                                "TAG_STUDY_INSTANCE_UID = '"                     + txtStudyInstanceUID.Text.PrepareDatabaseQueryString() + "'," +
                                "TAG_REQUESTING_PHYSICIAN = '"                   + txtRequestingPhysician.Text.PrepareDatabaseQueryString() + "'," +
                                "TAG_REQUESTED_PROCEDURE_DESCRIPTION = '"        + txtRequestedProcedureDescription.Text.PrepareDatabaseQueryString() + "'," +
                                "TAG_ADMISSION_ID = '"                           + txtAdmissionID.Text.PrepareDatabaseQueryString() + "'," +
                                "TAG_SCHEDULED_STATION_AE_TITLE = '"             + txtStationAETitle.Text.PrepareDatabaseQueryString() + "'," +
                                "TAG_SCHEDULED_PROCEDURE_STEP_START_DATE = '"    + FormatDateTime(txtStartDate.Text, true, false) + "'," +
                                "TAG_SCHEDULED_PROCEDURE_STEP_START_TIME = '"    + FormatDateTime(txtStartTime.Text, false, false) + "'," +
                                "TAG_SCHEDULED_PERFORMING_PHYSICIAN_NAME = '"    + txtPhysicianName.Text.PrepareDatabaseQueryString() + "'," +
                                "TAG_SCHEDULED_PROCEDURE_STEP_DESCRIPTION = '"   + txtDescription.Text.PrepareDatabaseQueryString() + "'," +
                                "TAG_SCHEDULED_PROCEDURE_STEP_ID = '"            + txtID.Text.PrepareDatabaseQueryString() + "'," +
                                "TAG_SCHEDULED_PROCEDURE_STEP_LOCATION = '"      + txtLocation.Text.PrepareDatabaseQueryString() + "'," +
                                "TAG_REQUESTED_PROCEDURE_ID = '"                 + txtRequestedProcedureID.Text.PrepareDatabaseQueryString() + "'," +
                                "TAG_REASON_FOR_THE_REQUESTED_PROCEDURE = '"     + txtReasonForProcedure.Text.PrepareDatabaseQueryString() + "'," +
                                "TAG_REQUESTED_PROCEDURE_PRIORITY = '"           + cboProcedurePriority.Text.PrepareDatabaseQueryString() + "'" + 
                                " WHERE Item_ID = "                              + m_strItemID;
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private void MwlItemDialog_Load(object sender, EventArgs e)
        {
            PopulateFormControls();
        }

        /*
         * Formats a string representing a DateTime, Date, or Time into the proper string
         */
        private string FormatDateTime(string strDateTime, bool bIsDate, bool bIsLoading)
        {
            char[] splitter = new char[1] { ' ' };
            string strRet = "";
            if (bIsDate) // Date
            {
                if (bIsLoading) // coming from database to form, format as "yyyy/mm/dd"
                {
                    strRet = strDateTime.Split(splitter, StringSplitOptions.None)[0];
                }
                else // coming from form to database, format as "yyyy/mm/dd HH:MM:SS"
                {
                    strRet = strDateTime + " 00:00:00";
                }
            }
            else // Time
            {
                if (bIsLoading) // coming from database to form, format as "HH:MM:SS"
                {
                    strRet = strDateTime.Split(splitter, StringSplitOptions.None)[1];
                }
                else // coming from form to database, format as "yyyy/mm/dd HH:MM:SS"
                {
                    strRet = "1899/12/30 " + strDateTime;
                }
            }

            return strRet;
        }
    }

    public static class Extensions
    {
       public static string PrepareDatabaseQueryString(this string s)
       {
          if (s.Contains("\'"))
          {
             s = s.Replace("'", "''");
          }
          return s;
       }
    }
}

#if !FOR_DOTNET4
namespace System.Runtime.CompilerServices
{
  [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
  public class ExtensionAttribute : Attribute
  {
  }
}
#endif

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
using Leadtools.Medical.WebViewer.ExternalControl;
using ExternalControlSample;
using Leadtools.Dicom.Common.DataTypes;

namespace ExternalControlSample
{
   public partial class PatientListControl : UserControl
   {
      public PatientListControl()
      {
         InitializeComponent();
         _listViewPatients = listViewPatientInfo;
      }

      private ListView _listViewPatients;

      public ListView ListViewPatients
      {
         get { return _listViewPatients; }
         set { _listViewPatients = value; }
      }

      public void Populate(PatientInfo[] patients)
      {
         listViewPatientInfo.Items.Clear();

         foreach (PatientInfo p in patients)
         {
            ListViewItem lvi = listViewPatientInfo.Items.Add(p.PatientId);
            PersonName pn = new PersonName(p.Name);

            // Name
            lvi.SubItems.Add(pn.Family);
            lvi.SubItems.Add(pn.Given);
            lvi.SubItems.Add(pn.Middle);
            lvi.SubItems.Add(pn.Prefix);
            lvi.SubItems.Add(pn.Suffix);

            lvi.SubItems.Add(p.BirthDate);
            lvi.SubItems.Add(p.Sex);
            lvi.SubItems.Add(p.EthnicGroup);
            lvi.SubItems.Add(p.Comments);
         }
         listViewPatientInfo.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
         listViewPatientInfo.Items[0].Selected = true;
      }

      private void listViewPatientInfo_SelectedIndexChanged(object sender, EventArgs e)
      {

      // MessageBox.Show("Changed");

      }



   }
}

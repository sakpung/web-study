// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************


using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Leadtools.Medical.PatientRestrict.AddIn.Common;
using Leadtools.Medical.WebViewer.PatientAccessRights;

namespace Leadtools.Medical.PatientRestrict.AddIn.Dialogs
{
   public partial class InsertModifyAeRoleControl : UserControl
   {
      public InsertModifyAeRoleControl()
      {
         InitializeComponent();
         comboBoxRole.Visible = true;
         labelRoleCombo.Visible = true;
      }

      public InsertModifyAeRoleControlType ControlType
      {
         get;
         set;
      }

      public AeAccessKey aeRole
      {
         get;
         set;
      }

      public List<AeAccessKey> aeRoleList
      {
         get;
         set;
      }

      public List<string> aeList
      {
         get;
         set;
      }

      public List<string> roleList
      {
         get;
         set;
      }

      public void ValidateAeTitle(string error)
      {
         errorProvider.SetError(this.comboBoxAeTitle, error);
      }

      public void ValidateRole(string error)
      {
         errorProvider.SetError(this.comboBoxRole, error);
      }

      
      private void InsertModifyAeRoleControl_Load(object sender, EventArgs e)
      {
         // Set up autocomplete for AE comboBoxAeTitle
         comboBoxAeTitle.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
         comboBoxAeTitle.AutoCompleteSource = AutoCompleteSource.CustomSource;

         if (aeRoleList != null)
         {
            List<string> aeTitleList = aeRoleList.MyGetAeList();
            aeTitleList.AddRange(aeList);
            string[] aeTitleArray = aeTitleList.Distinct().ToArray();

            comboBoxAeTitle.AutoCompleteCustomSource.AddRange(aeTitleArray);
            comboBoxAeTitle.Items.AddRange(aeTitleArray);
         }

         // Set up autocomplete for AE comboBoxAeTitle
         comboBoxRole.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
         comboBoxRole.AutoCompleteSource = AutoCompleteSource.CustomSource;
         if (aeRoleList != null)
         {
            List<string> rolesList = aeRoleList.MyGetRoleList();
            rolesList.AddRange(roleList);
            string[] rolesArray = rolesList.Distinct().ToArray();

            comboBoxRole.AutoCompleteCustomSource.AddRange(rolesArray);
            comboBoxRole.Items.AddRange(rolesArray);
         }


         // Hook up events
         comboBoxAeTitle.Validated += textBoxAeTitle_Validated;
         comboBoxRole.Validated += comboBoxRole_Validated;

         if (ControlType == InsertModifyAeRoleControlType.Insert)
         {
            comboBoxAeTitle.Text = aeRole.AeTitle;
            comboBoxRole.Text = aeRole.AccessKey;
         }
         else
         {
            comboBoxAeTitle.Text = aeRole.AeTitle;
            comboBoxRole.Text = aeRole.AccessKey;
         }
      }


      // Validated events
      private void textBoxAeTitle_Validated(object sender, EventArgs e)
      {
         aeRole.AeTitle = comboBoxAeTitle.Text.MyTrim();
      }

      private void comboBoxRole_Validated(object sender, EventArgs e)
      {
         aeRole.AccessKey = comboBoxRole.Text.MyTrim();
      }

   }

   public enum InsertModifyAeRoleControlType
   {
      Insert = 0,
      Modify = 1,
   }
}

// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Leadtools.Medical.WebViewer.PatientAccessRights;
using Leadtools.Medical.Winforms;

namespace Leadtools.Medical.PatientRestrict.AddIn.Dialogs
{
   public partial class InsertModifyAeRoleDialog : Form
   {
      public delegate void ValidateClientInformation(object sender, ClientInformationEventArgs e);

      public InsertModifyAeRoleDialog()
      {
         InitializeComponent();
      }

      public event EventHandler<AeRoleEventArgs> ValidateAeRoleData;

      protected virtual void OnValidateAeRole(AeRoleEventArgs e)
      {
         if (ValidateAeRoleData != null)
            ValidateAeRoleData(this, e);
      }

      public AeAccessKey aeRole
      {
         get 
         { 
            return insertModifyAeRoleControl.aeRole; 
         }
         
         set 
         {
            insertModifyAeRoleControl.aeRole = value;
         }
      }

      public List<AeAccessKey> aeRoleList
      {
         get
         {
            return insertModifyAeRoleControl.aeRoleList;
         }
         set
         {
            insertModifyAeRoleControl.aeRoleList = value;
         }
      }

      public List<string> aeList
      {
         get
         {
            return insertModifyAeRoleControl.aeList;
         }
         set
         {
            insertModifyAeRoleControl.aeList = value;
         }
      }

      public List<string> roleList
      {
         get
         {
            return insertModifyAeRoleControl.roleList;
         }
         set
         {
            insertModifyAeRoleControl.roleList = value;
         }
      }


      private string _originalAeTitle;

      public InsertModifyAeRoleControlType DialogType
      {
         get { return this.insertModifyAeRoleControl.ControlType; }
         set { insertModifyAeRoleControl.ControlType = value; }
      }

      public void ValidateAeTitle(string error)
      {
         insertModifyAeRoleControl.ValidateAeTitle(error);
      }

      public void ValidateRole(string error)
      {
         insertModifyAeRoleControl.ValidateRole(error);
      }
      

      private void buttonOK_Click(object sender, EventArgs e)
      {
         AeRoleEventArgs eventArgs = new AeRoleEventArgs();
         eventArgs.IsInsert = DialogType == InsertModifyAeRoleControlType.Insert;
         eventArgs.IsValid = true;
         eventArgs.AeRole = aeRole;

         string newAeTitle = aeRole.AeTitle.Trim();
         eventArgs.IsNewAeTitle = string.Compare(newAeTitle, _originalAeTitle, true) != 0;
         OnValidateAeRole(eventArgs);
         if (eventArgs.IsValid)
         {
            DialogResult = DialogResult.OK;
            Close();
         }
      }

      private void buttonCancel_Click(object sender, EventArgs e)
      {
            DialogResult = DialogResult.Cancel;
            Close();
      }

      private void InsertModifyClientDialog_Load(object sender, EventArgs e)
      {
         if (aeRole != null && !string.IsNullOrEmpty(aeRole.AeTitle))
            _originalAeTitle = aeRole.AeTitle.Trim();

         if (DialogType == InsertModifyAeRoleControlType.Insert)
         {
            Text = "Add AE Role";
         }
         else
         {
            Text = "Modify AE Role";
         }
      }

     
   }

   public class AeRoleEventArgs : EventArgs
   {
      public AeAccessKey AeRole;
      public bool IsInsert;
      public bool IsValid;
      public bool IsNewAeTitle;
   }

}

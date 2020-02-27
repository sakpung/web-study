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
using Leadtools.Dicom.AddIn.Common;
using Leadtools.Medical.PermissionsManagement.DataAccessLayer;
using Leadtools.Medical.AeManagement.DataAccessLayer;

namespace Leadtools.Medical.Winforms
{
   public partial class InsertModifyClientDialog : Form
   {
      public delegate void ValidateClientInformation(object sender, ClientInformationEventArgs e);

      public InsertModifyClientDialog()
      {
         InitializeComponent();
      }

      public event EventHandler<ClientInformationEventArgs> ValidateClientData;

      protected virtual void OnValidateClientData(ClientInformationEventArgs e)
      {
         if (ValidateClientData != null)
            ValidateClientData(this, e);
      }

      public bool ServerSecure
      {
         get
         {
            return insertModifyClientControl.ServerSecure;
         }
         set
         {
            insertModifyClientControl.ServerSecure = value;
         }
      }

      public Permission[] Permissions
      {
         get
         {
            return insertModifyClientControl.Permissions;
         }
         set
         {
            insertModifyClientControl.Permissions = value;
         }
      }

      public ClientInformation ClientInformation
      {
         get 
         { 
            return insertModifyClientControl.ClientInformation; 
         }
         
         set 
         {
            insertModifyClientControl.ClientInformation = value;
         }
      }

      private string _originalAeTitle;

      public InsertModifyClientControlType DialogType
      {
         get { return this.insertModifyClientControl.ControlType; }
         set { insertModifyClientControl.ControlType = value; }
      }

      public void ValidateAeTitle(string error)
      {
         insertModifyClientControl.ValidateAeTitle(error);
      }

      public void ValidateAddress(string error)
      {
         insertModifyClientControl.ValidateAddress(error);
      }

      public void ValidateMask(string error)
      {
         insertModifyClientControl.ValidateMask(error);
      }

      public void ValidatePort(string error)
      {
         insertModifyClientControl.ValidatePort(error);
      }

      public void ValidateSecurePort(string error)
      {
         insertModifyClientControl.ValidateSecurePort(error);
      }

      private void buttonOK_Click(object sender, EventArgs e)
      {
         ClientInformationEventArgs eventArgs = new ClientInformationEventArgs();
         eventArgs.IsInsert = DialogType == InsertModifyClientControlType.Insert;
         eventArgs.IsValid = true;
         eventArgs.ClientInformation = this.ClientInformation;
         this.ClientInformation.Client.LastAccessDate = DateTime.Now;

         string newAeTitle = ClientInformation.Client.AETitle.Trim();
         eventArgs.IsNewAeTitle = string.Compare(newAeTitle, _originalAeTitle, true) != 0;
         OnValidateClientData(eventArgs);
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
         if (ClientInformation != null && ClientInformation.Client != null && !string.IsNullOrEmpty(ClientInformation.Client.AETitle))
            _originalAeTitle = ClientInformation.Client.AETitle.Trim();

         if (this.DialogType == InsertModifyClientControlType.Insert)
         {
            Text = "Add Client";
         }
         else
         {
            Text = "Modify Client";
         }
      }

     
   }

   public class ClientInformationEventArgs : EventArgs
   {
      public ClientInformation ClientInformation;
      public bool IsInsert;
      public bool IsValid;
      public bool IsNewAeTitle;
   }

}

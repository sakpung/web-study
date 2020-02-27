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
using Leadtools.Dicom.AddIn.Common;
using Leadtools.Medical.PermissionsManagement.DataAccessLayer;
using Leadtools.Medical.AeManagement.DataAccessLayer;
using Leadtools.Demos;
using System.Net.NetworkInformation;
using Leadtools.DicomDemos;
using Leadtools.Dicom;

namespace Leadtools.Medical.Winforms
{
   public partial class InsertModifyClientControl : UserControl
   {
      public InsertModifyClientControl()
      {
         InitializeComponent();
         textBoxFriendlyName.Visible = false;
         labelFriendlyName.Visible = false;
#if (LEADTOOLS_V19_OR_LATER_MEDICAL_CLIENT_FRIENDLY_NAME) || (LEADTOOLS_V19_OR_LATER)
         textBoxFriendlyName.Visible = true;
         labelFriendlyName.Visible = true;
#endif
      }

      public InsertModifyClientControlType ControlType
      {
         get;
         set;
      }

      public bool ServerSecure
      {
         get;
         set;
      }

      public ClientInformation ClientInformation
      {
         get;
         set;
      }

      public Permission[] Permissions
      {
         get;
         set;
      }

      public void ValidateAeTitle(string error)
      {
         errorProvider.SetError(this.textBoxAeTitle, error);
      }

      public void ValidateAddress(string error)
      {
         errorProvider.SetError(this.textBoxAddress, error);
      }

      public void ValidateMask(string error)
      {
         errorProvider.SetError(this.textBoxMask, error);
      }

      public void ValidatePort(string error)
      {
         errorProvider.SetError(this.numericUpDownPort, error);
      }

      public void ValidateSecurePort(string error)
      {
         errorProvider.SetError(this.numericUpDownSecurePort, error);
      }

      private void AddListViewItem(string text, bool check)
      {
         ListViewItem item = listViewPermissions.Items.Add(text);
         item.Checked = check;
         item.Name = text;
      }


      private void InsertModifyClientControl_Load(object sender, EventArgs e)
      {
         if (ClientInformation == null)
            ClientInformation = new ClientInformation();

         if (Permissions != null)
         {
            foreach (Permission permission in Permissions)
            {
               bool isChecked = (ClientInformation.Permissions.Contains(permission.Name));
               AddListViewItem(permission.Name, isChecked);
            }
         }

         numericUpDownPort.Minimum = 0;
         numericUpDownPort.Maximum = 65535;
         numericUpDownSecurePort.Minimum = 0;
         numericUpDownSecurePort.Maximum = 65535;

         if (ClientInformation != null && ClientInformation.Client != null)
         {
            textBoxAeTitle.Text = ClientInformation.Client.AETitle;
#if (LEADTOOLS_V19_OR_LATER_MEDICAL_CLIENT_FRIENDLY_NAME) || (LEADTOOLS_V19_OR_LATER)
            textBoxFriendlyName.Text = ClientInformation.Client.FriendlyName;
#endif
            textBoxAddress.Text = ClientInformation.Client.Address;
            checkBoxVerifyAddress.Checked = ClientInformation.Client.VerifyAddress;
            textBoxMask.Text = ClientInformation.Client.Mask;
            checkBoxMask.Checked = ClientInformation.Client.VerifyMask;

            if (ControlType == InsertModifyClientControlType.Insert)
            {
               ClientInformation.Client.Port = 1000;
               ClientInformation.Client.SecurePort = 2762;
               ClientInformation.Client.ClientPortUsage = ClientPortUsageType.Unsecure;
            }

            numericUpDownPort.Value = ClientInformation.Client.Port;
            numericUpDownSecurePort.Value = ClientInformation.Client.SecurePort;

            comboBoxClientPortSelection.Items.Add(ClientPortUsageType.Unsecure);
            comboBoxClientPortSelection.Items.Add(ClientPortUsageType.Secure);
            comboBoxClientPortSelection.Items.Add(ClientPortUsageType.SameAsServer);
            comboBoxClientPortSelection.SelectedItem = ClientInformation.Client.ClientPortUsage;

            comboBoxClientPortSelection.SelectedIndexChanged += ComboBoxClientPortSelection_SelectedIndexChanged;

            UpdateClientPortIcons();

            // Todo
            //listViewPermissions.Items["Query"].Checked = _clientInformation.CanQuery;
            //listViewPermissions.Items["Retrieve"].Checked = _clientInformation.CanRetrieve;
            //listViewPermissions.Items["Create"].Checked = _clientInformation.CanCreate;
            //listViewPermissions.Items["Overwrite"].Checked = _clientInformation.CanOverwrite;
            //listViewPermissions.Items["Update"].Checked = _clientInformation.CanUpdate;
            //listViewPermissions.Items["Delete"].Checked = _clientInformation.CanDelete;
         }

         // textBoxAddress.Enabled = checkBoxVerifyAddress.Checked;
         textBoxMask.Enabled = checkBoxMask.Checked;
      }

      void UpdateClientPortIcons()
      {
         if (comboBoxClientPortSelection.SelectedItem is ClientPortUsageType)
         {
            ClientPortUsageType portUsage = (ClientPortUsageType)comboBoxClientPortSelection.SelectedItem;
            switch (portUsage)
            {
               case ClientPortUsageType.Unsecure:
                  pictureBoxUnsecurePort.Visible = true;
                  pictureBoxSecurePort.Visible = false;
                  break;
               case ClientPortUsageType.Secure:
                  pictureBoxUnsecurePort.Visible = false;
                  pictureBoxSecurePort.Visible = true;
                  break;
               case ClientPortUsageType.SameAsServer:
                  pictureBoxUnsecurePort.Visible = !this.ServerSecure;
                  pictureBoxSecurePort.Visible = this.ServerSecure;
                  break;
            }
         }
      }

      private void ComboBoxClientPortSelection_SelectedIndexChanged(object sender, EventArgs e)
      {
         ClientPortUsageType portUsage = (ClientPortUsageType)comboBoxClientPortSelection.SelectedItem;
         if (portUsage == ClientPortUsageType.Secure || portUsage == ClientPortUsageType.SameAsServer)
         {
            if (Utils.VerifyOpensslVersion(this.ParentForm) == false)
            {
               comboBoxClientPortSelection.SelectedIndex = 0;
               return;
            }
         } 
         UpdateClientPortIcons();
      }

      // Validated events
      private void textBoxAeTitle_Validated(object sender, EventArgs e)
      {
         ClientInformation.Client.AETitle = textBoxAeTitle.Text.MyTrim();
      }

      private void textBoxFriendlyName_Validated(object sender, EventArgs e)
      {
#if (LEADTOOLS_V19_OR_LATER_MEDICAL_CLIENT_FRIENDLY_NAME) || (LEADTOOLS_V19_OR_LATER)
         ClientInformation.Client.FriendlyName = textBoxFriendlyName.Text.MyTrim();
#endif
      }

      private void checkBoxVerifyAddress_Validated(object sender, EventArgs e)
      {
         ClientInformation.Client.VerifyAddress = checkBoxVerifyAddress.Checked;
      }

      private void textBoxAddress_Validated(object sender, EventArgs e)
      {
         ClientInformation.Client.Address = textBoxAddress.Text.MyTrim();
      }

      private void textBoxMask_Validated(object sender, EventArgs e)
      {
         ClientInformation.Client.Mask = textBoxMask.Text.MyTrim();
      }

      private void checkBoxMask_Validated(object sender, EventArgs e)
      {
         ClientInformation.Client.VerifyMask = checkBoxMask.Checked;
      }

      private void numericUpDownPort_Validated(object sender, EventArgs e)
      {
         ClientInformation.Client.Port = (int)numericUpDownPort.Value;
      }

      private void numericUpDownSecurePort_Validated(object sender, EventArgs e)
      {
         ClientInformation.Client.SecurePort = (int)numericUpDownSecurePort.Value;
      }

      private void listViewPermissions_Validated(object sender, EventArgs e)
      {
         foreach (ListViewItem item in listViewPermissions.Items)
         {
            string permission = item.Name;
            if (item.Checked)
            {
               if (!ClientInformation.Permissions.Contains(permission))
               {
                  ClientInformation.Permissions.Add(permission);
               }
            }
            else // not checked
            {
               if (ClientInformation.Permissions.Contains(permission))
               {
                  ClientInformation.Permissions.Remove(permission);
               }
            }
         }
      }

      private void comboBoxClientPortSelection_Validated(object sender, EventArgs e)
      {
         if (comboBoxClientPortSelection.SelectedItem is ClientPortUsageType)
         {
            ClientPortUsageType portUsage = (ClientPortUsageType)comboBoxClientPortSelection.SelectedItem;
            ClientInformation.Client.ClientPortUsage = portUsage;
         }
      }

      private void checkBoxVerifyAddress_CheckedChanged(object sender, EventArgs e)
      {         
         if (!checkBoxVerifyAddress.Checked)
         {
            //
            // If address is not being used, clear at the mask fields
            //
            textBoxMask.Enabled = false;            
            checkBoxMask.Checked = false;
            checkBoxMask.Enabled = false;
         }
         else
         {
            checkBoxMask.Enabled = true;
         }
      }

      private void checkBoxMask_CheckedChanged(object sender, EventArgs e)
      {
         textBoxMask.Enabled = checkBoxMask.Checked;  
      }

      private void buttonPing_Click(object sender, EventArgs e)
      {
         Application.UseWaitCursor = true;
         try
         {
            Ping ping = new Ping();
            PingReply reply = ping.Send(textBoxAddress.Text);

            if (reply.Status == IPStatus.Success)
            {
               MessageBox.Show(this, "Hostname/IP Address verified successfully.","Verification", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
         }
         catch (PingException pe)
         {
            Exception error = pe.InnerException != null ? pe.InnerException : pe;

            Messager.ShowError(this, error);
         }
         catch (Exception ex)
         {
            Exception error = ex.InnerException != null ? ex.InnerException : ex;

            Messager.ShowError(this, error);
         }
         finally
         {
            Application.UseWaitCursor = false;
         }
      }

      private void textBoxAddress_TextChanged(object sender, EventArgs e)
      {
         buttonPing.Enabled = textBoxAddress.Text.Length > 0;
      }

   }

   public enum InsertModifyClientControlType
   {
      Insert = 0,
      Modify = 1,
   }
}

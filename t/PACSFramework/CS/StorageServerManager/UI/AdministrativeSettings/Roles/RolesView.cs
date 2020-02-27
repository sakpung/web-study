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
using Leadtools.Medical.PermissionsManagement.DataAccessLayer;
using Leadtools.Demos.StorageServer.UI.AdministrativeSettings.Users;
using Microsoft.VisualBasic;

namespace Leadtools.Demos.StorageServer.UI
{
   public partial class RolesView : UserControl
   {
      private Dictionary<string, List<string>> _RolePermissions = new Dictionary<string, List<string>>();

      public Dictionary<string, List<string>> RolePermissions
      {
         get
         {
            return _RolePermissions;
         }
      }

      private List<string> _RolesToDelete = new List<string>();

      public List<string> RolesToDelete
      {
         get
         {
            return _RolesToDelete;
         }
      }

      private Dictionary<string, Role> _RolesToAdd = new Dictionary<string, Role>();

      public Dictionary<string, Role> RolesToAdd
      {
         get
         {
            return _RolesToAdd;
         }
      }

      public event EventHandler SettingsChanged;

      private void OnSettingsChanged()
      {
         if (SettingsChanged != null)
            SettingsChanged(this, EventArgs.Empty);
      }

      public RolesView()
      {
         InitializeComponent();
         listViewPermissions.Columns[0].Width = listViewPermissions.ClientRectangle.Width-2;
      }

      public void SetRoles(Role[] roles)
      {
         foreach (Role role in roles)
         {
            AddRole(role);
         }

         if (comboBoxRoles.Items.Count > 0)
         {
            comboBoxRoles.SelectedIndex = 0;
            comboBoxRoles_SelectionChangeCommitted(comboBoxRoles, EventArgs.Empty);
         }
      }

      private void AddRole(Role role)
      {
         comboBoxRoles.Items.Add(role);
         _RolePermissions[role.Name] = new List<string>();
         _RolePermissions[role.Name].AddRange(role.AssignedPermissions);
      }

      public void SetPermissions(Permission[] permissions)
      {
         listViewPermissions.ItemChecked -= listViewPermissions_ItemChecked;
         foreach (Permission permission in permissions)
         {
            ListViewItem item = listViewPermissions.Items.Add(permission.Name);

            item.Tag = permission;
         }
         listViewPermissions.ItemChecked += listViewPermissions_ItemChecked;
      }

      private ListViewItem FindPermission(string name)
      {
         foreach (ListViewItem item in listViewPermissions.Items)
         {
            Permission permission = item.Tag as Permission;

            if (permission.Name == name)
               return item;
         }
         return null;
      }

      private void comboBoxRoles_SelectionChangeCommitted(object sender, EventArgs e)
      {
         Role role = comboBoxRoles.SelectedItem as Role;

         if (role != null)
         {                           
            CheckRolePermissions(role);
            listViewPermissions.Enabled = !RoleManager.BuiltInRoles.Contains(role);
            buttonDelete.Enabled = listViewPermissions.Enabled;
         }
      }

      private void CheckRolePermissions(Role role)
      {
         listViewPermissions.ItemChecked -= listViewPermissions_ItemChecked;
         listViewPermissions.UncheckAll();

         if (role.Name == "Administrators")
         {
            listViewPermissions.CheckAll();
         }
         else
         {
            foreach (string permission in _RolePermissions[role.Name].AsReadOnly())
            {
               ListViewItem item = FindPermission(permission);

               if (item != null)
                  item.Checked = true; 
            }
         }
         listViewPermissions.ItemChecked += listViewPermissions_ItemChecked;
      }

      private void listViewPermissions_ItemChecked(object sender, ItemCheckedEventArgs e)
      {
         Role role = comboBoxRoles.SelectedItem as Role;

         if (role != null)
         {            
            Permission permission = e.Item.Tag as Permission;

            if (e.Item.Checked)
               _RolePermissions[role.Name].Add(permission.Name);
            else
               _RolePermissions[role.Name].Remove(permission.Name);
            OnSettingsChanged();
         }
      }

      private void buttonDelete_Click(object sender, EventArgs e)
      {
         Role role = comboBoxRoles.SelectedItem as Role;
         int selectedIndex = comboBoxRoles.SelectedIndex;
         
         comboBoxRoles.Items.RemoveAt(selectedIndex);
         if (selectedIndex >= 1)
         {
            comboBoxRoles.SelectedIndex = selectedIndex - 1;
            comboBoxRoles_SelectionChangeCommitted(comboBoxRoles, EventArgs.Empty);
         }
         if (_RolesToAdd.ContainsKey(role.Name.ToLower()))         
            _RolesToAdd.Remove(role.Name.ToLower());                     
         else
            _RolesToDelete.Add(role.Name);
         
         OnSettingsChanged();
      }

      private void buttonAdd_Click(object sender, EventArgs e)
      {
         string role = string.Empty;
         bool input = true;

         while (input)
         {
            if (DialogUtilities.InputBox("Add Role", "Role Name: ", ref role) == DialogResult.OK)
            {               
               if (!RoleExists(role))
               {
                  Role r = new Role(role, string.Empty);

                  r.AssignedPermissions = new List<string>().ToArray();
                  AddRole(r);
                  _RolesToAdd.Add(r.Name.ToLower(), r);
                  comboBoxRoles.SelectedItem = r;
                  comboBoxRoles_SelectionChangeCommitted(comboBoxRoles, EventArgs.Empty);
                  OnSettingsChanged();
                  input = false;
               }
               else
                  Messager.Show(this, string.Format("Role {0} already exists. Please choose another name.", role), MessageBoxIcon.Error, MessageBoxButtons.OK);
            }
            else
               input = false;
         }
      }

      private bool RoleExists(string roleName)
      {
         Role role = (from r in comboBoxRoles.Items.Cast<Role>()
                      where r.Name.ToLower() == roleName
                      select r).FirstOrDefault();

         return role != null;
      }
   }
}

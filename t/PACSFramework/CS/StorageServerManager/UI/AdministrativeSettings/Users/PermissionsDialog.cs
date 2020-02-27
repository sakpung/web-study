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
using Leadtools.Medical.UserManagementDataAccessLayer;
using Leadtools.Medical.PermissionsManagement.DataAccessLayer;
using System.Diagnostics;

namespace Leadtools.Demos.StorageServer.UI.AdministrativeSettings.Users
{
   public partial class PermissionsDialog : Form
   {
      private List<string> _UserPermissions = new List<string>();

      private List<string> _MergedPermissions = new List<string>();

      private string _Username = string.Empty;

      public string Username
      {
         get { return _Username; }
         set { _Username = value; }
      }

      private List<string> _SelectedPermissions = new List<string>();

      public List<string> SelectedPermissions
      {
         get { return _SelectedPermissions; }
      }

      public List<Role> Roles
      {
         get
         {
            return (from item in listViewRoles.Items.Cast<ListViewItem>()
                   where item.Checked == true
                   select item.Tag as Role).ToList();
         }
      }

      public PermissionsDialog()
      {
         InitializeComponent();
      }

      public void SetPermissions(Permission[] availablePermissions, List<string> userPermission)
      {
         listViewPermissions.Items.Clear();
         foreach (Permission permission in availablePermissions)
         {
            ListViewItem item = new ListViewItem(permission.Name);

            item.SubItems.Add(permission.Description);
            item.Tag = permission;
            item.Checked = userPermission.Contains(permission.Name);
            listViewPermissions.Items.Add(item);
         }
         _UserPermissions.AddRange(userPermission);
      }

      public void SetRoles(Role[] roles, Role[] userRoles)
      {
         foreach (Role role in roles)
         {
            ListViewItem item = listViewRoles.Items.Add(role.Name);

            item.Tag = role;
            item.Checked = HasRole(userRoles, role.Name);
         }
         UpdateMergedPermissions();
      }

      void listViewRoles_ItemChecked(object sender, ItemCheckedEventArgs e)
      {
         UpdateMergedPermissions();
      }

      private bool HasAdminRole()
      {
         return (from item in listViewRoles.CheckedItems.Cast<ListViewItem>()
                 where (item.Tag as Role).Name == "Administrators"
                 select item.Tag as Role).FirstOrDefault() != null;
      }

      private void UpdateMergedPermissions()
      {
         bool adminRole = HasAdminRole();

         _MergedPermissions.Clear();
         foreach (ListViewItem item in listViewRoles.CheckedItems)
         {
            Role role = item.Tag as Role;            

            _MergedPermissions = _MergedPermissions.Union(role.AssignedPermissions).ToList();
         }

         try
         {
            listViewPermissions.ItemChecked -= listViewPermissions_ItemChecked;
            listViewPermissions.Freeze();
            listViewPermissions.UncheckAll();
            listViewPermissions.SetForeColor(SystemColors.WindowText);

            //
            // Check permission that do not belong to a role
            //
            foreach (string permission in _UserPermissions)
            {
               ListViewItem found = FindListViewPermission(permission);

               if (found != null)
               {
                  found.Checked = true;
               }
            }

            if (adminRole)
            {
               foreach (ListViewItem item in listViewPermissions.Items)
               {
                  item.Checked = true;
                  item.ForeColor = SystemColors.InactiveCaptionText;
               }
            }
            else
            {               
               foreach (string permission in _MergedPermissions)
               {
                  ListViewItem found = FindListViewPermission(permission);

                  if (found != null)
                  {
                     found.Checked = true;
                     found.ForeColor = SystemColors.InactiveCaptionText;
                  }
               }               
            }
         }
         finally
         {
            listViewPermissions.UnFreeze();
            listViewPermissions.ItemChecked += listViewPermissions_ItemChecked;
         }
      }

      private ListViewItem FindListViewPermission(string permission)
      {
         ListViewItem found = (from item in listViewPermissions.Items.Cast<ListViewItem>()
                               where (item.Tag as Permission).Name == permission
                               select item).FirstOrDefault();

         return found;
      }

      private bool HasRole(Role[] roles, string role)
      {
         List<Role> r = new List<Role>(roles);

         return (from rl in r
                 where rl.Name == role
                 select rl).FirstOrDefault() != null;
      }

      private void PermissionsDialog_Load(object sender, EventArgs e)
      {
         SizeColumns();
         listViewRoles.ItemChecked += new ItemCheckedEventHandler(listViewRoles_ItemChecked);
      }

      private void SizeColumns()
      {
         int width = listViewPermissions.ClientRectangle.Width;

         foreach (ColumnHeader column in listViewPermissions.Columns)
         {
            column.Width = width / listViewPermissions.Columns.Count;
         }
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

      private void PermissionsDialog_FormClosing(object sender, FormClosingEventArgs e)
      {
         if (DialogResult == DialogResult.OK)
         {
            List<string> permissions = new List<string>();

            foreach (ListViewItem item in listViewPermissions.CheckedItems)
            {
               Permission permission = item.Tag as Permission;
               
               permissions.Add(permission.Name);
            }

            _SelectedPermissions = permissions.Except(_MergedPermissions).ToList();
         }
      }

      private void listViewPermissions_ItemCheck(object sender, ItemCheckEventArgs e)
      {
         if (e.NewValue == CheckState.Unchecked)
         {
            Permission permission = listViewPermissions.Items[e.Index].Tag as Permission;

            if (_MergedPermissions.Contains(permission.Name) || HasAdminRole())
               e.NewValue = CheckState.Checked;
         }
      }

      private void listViewPermissions_ItemChecked(object sender, ItemCheckedEventArgs e)
      {
         Permission permission = e.Item.Tag as Permission;

         if (permission != null)
         {
            if (_UserPermissions.Contains(permission.Name))
               _UserPermissions.Remove(permission.Name);
            else
               _UserPermissions.Add(permission.Name);
         }
      }
   }
}

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

namespace ExternalControlSample.UI
{
   public partial class UsersControl : UserControl
   {
      public UsersControl()
      {
         InitializeComponent();

         // Align
         comboBoxUserName.Left = textBoxUsername.Left;
         comboBoxUserName.Top = textBoxUsername.Top;
         comboBoxUserName.Width = textBoxUsername.Width;
         comboBoxUserName.Height = textBoxUsername.Height;

         // Align
         checkBoxUserPassword.Left = labelUserPassword.Left;
         checkBoxUserPassword.Top = labelUserPassword.Top;
      }

      UsersControlType _controlType = UsersControlType.Add;
      
      public string UserName
      {
         get
         {
            string username = textBoxUsername.Text;
            if (_controlType == UsersControlType.Update)
            {
               username = comboBoxUserName.Text;
            }
            return username;
         }
      }

      public string Password
      {
         get
         {
            return textBoxUserPassword.Text;
         }
      }

      public bool UpdatePassword
      {
         get
         {
            return checkBoxUserPassword.Checked;
         }
      }

      public List<string> Roles
      {
         get
         {
            return GetCheckedItems(checkedListBoxRoles);
         }

         set
         {
            UpdateCheckedListBox(checkedListBoxRoles, value);
         }
      }

      public List<string> Permissions
      {
         get
         {
            return GetCheckedItems(checkedListBoxPermissions);
         }

         set
         {
            UpdateCheckedListBox(checkedListBoxPermissions, value);
         }
      }

      public ComboBox ComboBoxUserName
      {
         get
         {
            return this.comboBoxUserName;
         }
      }

      public void InitializeDefaults(List<Permission> permissionList, List<Role> roleList)
      {
         checkedListBoxPermissions.Items.Clear();
         foreach (Permission p in permissionList)
         {
            checkedListBoxPermissions.Items.Add(p.Name);
         }

         checkedListBoxRoles.Items.Clear();
         foreach (Role r in roleList)
         {
            checkedListBoxRoles.Items.Add(r.Name);
         }
      }


      public void UpdateUI()
      {
         switch (_controlType)
         {
            case UsersControlType.Add:
               textBoxUsername.Visible = true;
               labelUserPassword.Visible = true;

               comboBoxUserName.Visible = false;
               checkBoxUserPassword.Visible = false;
               break;

            case UsersControlType.Update:
               textBoxUsername.Visible = false;
               labelUserPassword.Visible = false;

               checkBoxUserPassword.Visible = true;
               comboBoxUserName.Visible = true;

               textBoxUserPassword.Enabled = checkBoxUserPassword.Checked;
               break;
         }
      }

      public void UpdateUserList(List<string>userList)
      {
         comboBoxUserName.Items.Clear();

         foreach (string s in userList)
         {
            comboBoxUserName.Items.Add(s);
         }

      }


      [Description("Add or Update"),Category("Behavior")] 
      public UsersControlType ControlType
      {
         get
         {
            return _controlType;
         }
         set
         {
            _controlType = value;
            UpdateUI();
         }
      }
      

      public void AddUser()
      {
         //string[] permissions = new string[] { };
         //string[] roles = new string[] { };
         //ControllerReturnCode ret = _controller.CreateUser(
         //                                 textBoxUsernameManageUsers.Text,
         //                                 textBoxUserPasswordManageUsers.Text,
         //                                 _currentUserName,
         //                                 _currentPassword,
         //                                 true,

         //                                 permissions,
         //                                 roles,
         //                                 CreateUserOptions.CreateUser);
         //Logger.LogControllerResult("CreateUser", ret);
      }

      private void UpdateCheckedListBox(CheckedListBox cb, List<string> stringList)
      {
         // Uncheck all items
         foreach (int i in cb.CheckedIndices)
         {
            cb.SetItemCheckState(i, CheckState.Unchecked);
         }

         string[] destination = new string[cb.Items.Count];
         cb.Items.CopyTo(destination, 0);

         // Check items in stringList
         foreach(string s in stringList)
         {
            int index = cb.FindStringExact(s);
            if (index !=  ListBox.NoMatches)
            {
               cb.SetItemCheckState(index, CheckState.Checked);
            }
         }
      }

      private List<string> GetCheckedItems(CheckedListBox cb)
      {
         List<string> s = new List<string>();
         foreach (int i in cb.CheckedIndices)
         {
            s.Add(cb.Items[i].ToString());
         }
         return s;
      }

      private void CheckAllItems(CheckedListBox cb, bool bChecked)
      {
         for (int i = 0; i < cb.Items.Count; i++)
         {
            cb.SetItemChecked(i, bChecked);
         }
      }

      private void checkBoxUserPassword_CheckedChanged(object sender, EventArgs e)
      {
         if (ControlType == UsersControlType.Update)
         {
            textBoxUserPassword.Enabled = checkBoxUserPassword.Checked;
         }
      }

      private void comboBoxUserName_VisibleChanged(object sender, EventArgs e)
      {
         Console.WriteLine(comboBoxUserName.Visible);
      }

      private void ContextMenu_CheckAllItems(object sender, bool bChecked)
      {
         CheckedListBox cb = null;
         ToolStripItem menuItem = sender as ToolStripItem;
         if (menuItem != null)
         {
            ContextMenuStrip owner = menuItem.Owner as ContextMenuStrip;
            if (owner != null)
            {

               // Get the control that is displaying this context menu
               cb = (CheckedListBox)owner.SourceControl;
            }
         }

         if (cb != null)
         {
            CheckAllItems(cb, bChecked);
         }
      }

      private void toolStripMenuItemCheckAll_Click(object sender, EventArgs e)
      {
         ContextMenu_CheckAllItems(sender, true);
      }



      private void toolStripMenuItemUncheckAll_Click(object sender, EventArgs e)
      {
         ContextMenu_CheckAllItems(sender, false);
      }

      //public void UpdateListBoxPermissions(List<string> permissions)
      //{
      //   UpdateCheckedListBox(checkedListBoxPermissions, permissions);
      //}

      //public void UpdateListBoxRoles(List<string> roles)
      //{
      //   UpdateCheckedListBox(checkedListBoxRoles, roles);
      //}
   }


   public enum UsersControlType
   {
      Add,
      Update
   }

}

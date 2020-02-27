// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Leadtools.Demos.StorageServer.DataTypes;
using Leadtools.Demos.StorageServer.UI.AdministrativeSettings.Users;
using Leadtools.Medical.UserManagementDataAccessLayer;
using Leadtools.Medical.UserManagementDataAccessLayer.Configuration;
using Leadtools.Medical.DataAccessLayer;
using System.Windows.Forms;
using Leadtools.Medical.OptionsDataAccessLayer;
using Leadtools.Medical.OptionsDataAccessLayer.Configuration;
using System.Data;
using Leadtools.Medical.PermissionsManagement.DataAccessLayer;
using Leadtools.Medical.PermissionsManagement.DataAccessLayer.Configuration;
using Leadtools.Medical.Winforms;
using Leadtools.DicomDemos;

namespace Leadtools.Demos.StorageServer.UI
{
   public class UserViewPresenter
   {
      public UserView View { get; private set; }

      public void RunView(UserView view)
      {
         EventBroker.Instance.Subscribe<ApplyServerSettingsEventArgs>(OnUpdateServerSettings);
         EventBroker.Instance.Subscribe<CancelServerSettingsEventArgs>(OnCancelServerSettings);

         View = view;
         ThemesManager.ApplyTheme(view);
         View.UsersAccounts.VisibleChanged += new EventHandler(UsersAccounts_VisibleChanged);
         View.UsersAccounts.PasswordRequest += new EventHandler<PasswordRequestEventArgs>(UsersAccounts_PasswordRequest);
         View.UsersAccounts.EditUserPermissions += new EventHandler<EditUserPermissionsEventArgs>(UsersAccounts_EditUserPermissions);
         View.SettingsChanged += new EventHandler(View_SettingsChanged);
      }

      public event EventHandler SettingsChanged;

      private void View_SettingsChanged(object sender, EventArgs e)
      {
         try
         {
            if (SettingsChanged != null)
            {
               SettingsChanged(sender, e);
            }
         }
         catch (Exception)
         {
            System.Diagnostics.Debug.Assert(false);
         }
      }

      void UsersAccounts_EditUserPermissions(object sender, EditUserPermissionsEventArgs e)
      {
         PermissionsDialog permissionDialog = new PermissionsDialog();
         IPermissionManagementDataAccessAgent agent = DataAccessFactory.GetInstance(new PermissionManagementDataAccessConfigurationView(DicomDemoSettingsManager.GetGlobalPacsConfiguration(), DicomDemoSettingsManager.ProductNameStorageServer, null) ).CreateDataAccessAgent<IPermissionManagementDataAccessAgent>();
         Permission[] permissions = agent.GetPermissions();

         permissionDialog.Username = e.Username;
         permissionDialog.SetPermissions(permissions, e.Permissions);
         permissionDialog.SetRoles(RoleManager.GetAllRoles(), RoleManager.GetUserRoles(e.Username));
         if (permissionDialog.ShowDialog() == DialogResult.OK)
         {
            View.UsersAccounts.SetUserPermissions(permissionDialog.SelectedPermissions);
            RoleManager.SetUserRoles(e.Username, permissionDialog.Roles);
            View_SettingsChanged(sender, e);
         }
      }     

      void UsersAccounts_PasswordRequest(object sender, PasswordRequestEventArgs e)
      {
         PasswordDialog dlgPassword = new PasswordDialog();

         dlgPassword.ValidatePassword += new EventHandler<ValidatePasswordEventArgs>(dlgPassword_ValidatePassword);
         e.Cancel = dlgPassword.ShowDialog() == DialogResult.Cancel;
         if (!e.Cancel)
         {
            IOptionsDataAccessAgent agent;
            PasswordOptions options;

            agent = DataAccessFactory.GetInstance(new OptionsDataAccessConfigurationView(DicomDemoSettingsManager.GetGlobalPacsConfiguration(), DicomDemoSettingsManager.ProductNameStorageServer, null) ).CreateDataAccessAgent<IOptionsDataAccessAgent>();
            options = agent.Get<PasswordOptions>(PasswordOptionsPresenter.PasswordOptions, new PasswordOptions());
            e.Password = dlgPassword.Password;
            if (options.DaysToExpire > 0)
            {               
               e.Expires = DateTime.Now.AddDays(options.DaysToExpire);
            }
            View_SettingsChanged(sender, e);
         }
      }

      void dlgPassword_ValidatePassword(object sender, ValidatePasswordEventArgs e)
      {
         IOptionsDataAccessAgent agent;
         PasswordOptions options;
         string message;

         agent = DataAccessFactory.GetInstance(new OptionsDataAccessConfigurationView(DicomDemoSettingsManager.GetGlobalPacsConfiguration(), DicomDemoSettingsManager.ProductNameStorageServer, null) ).CreateDataAccessAgent<IOptionsDataAccessAgent>();
         options = agent.Get<PasswordOptions>(PasswordOptionsPresenter.PasswordOptions, new PasswordOptions());
         if (!PasswordValidator.Validate(e.Password, e.ConfirmPassword, options, out message))
         {
            e.Valid = false;
            Messager.ShowError(null, message);
         }
         else
         {
            e.Valid = true;
            if (UserManager.IsPreviousPassword(View.UsersAccounts.SelectedUser, e.Password.ToSecureString()))
            {
               e.Valid = false;
               Messager.ShowError(sender as Form, "The password chosen has already been used.  Please choose a new password.");
            }
         }
      }

      void UsersAccounts_VisibleChanged(object sender, EventArgs e)
      {
         if (View.UsersAccounts.Visible)
         {
            Leadtools.Demos.StorageServer.UI.AdministrativeSettings.Users.UsersSource users = UserManager.LoadUsers(false);

            View.UsersAccounts.LoadUsers(users);
            View.UsersAccounts.LoginType = LoginType.UsernamePassword;
         }
      }

      private void OnUpdateServerSettings(object sender, EventArgs e)
      {
         if (View.UsersAccounts.HasChanges())
         {
            UserManager.UpdateUsers(View.UsersAccounts.Source);
         }
      }
      
      private void OnCancelServerSettings(object sender, EventArgs e)
      {
         DataGridView dataGridView = View.UsersAccounts.UsersDataGridViewControl;
                while (dataGridView.CurrentRow != null)
            {
                dataGridView.Rows.Remove(dataGridView.CurrentRow);
            }
      }      
   }
}

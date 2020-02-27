// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Leadtools.Demos.StorageServer.UI.AdministrativeSettings.Users;
using Leadtools.Medical.PermissionsManagement.DataAccessLayer;
using Leadtools.Medical.DataAccessLayer;
using Leadtools.Medical.PermissionsManagement.DataAccessLayer.Configuration;
using Leadtools.DicomDemos;
using Leadtools.Medical.Winforms;
using Leadtools.Demos.StorageServer.DataTypes;

namespace Leadtools.Demos.StorageServer.UI
{
   class RolesViewPresenter
   {
      private RolesView _RolesView;

      public RolesView View
      {
         get { return _RolesView; }
         set { _RolesView = value; }
      }
      private bool _Initialized = false;

      public void RunView(RolesView view)
      {
         EventBroker.Instance.Subscribe<ApplyServerSettingsEventArgs>(OnUpdateServerSettings);

         _RolesView = view;
         _RolesView.Load += new EventHandler(_RolesView_Load);
         _RolesView.SettingsChanged += new EventHandler(_RolesView_SettingsChanged);         
      }     

      void _RolesView_SettingsChanged(object sender, EventArgs e)
      {
         View_SettingsChanged(this, EventArgs.Empty);
      }

      void _RolesView_Load(object sender, EventArgs e)
      {
         try
         {
            if (!_Initialized)
            {
               SetPermissions();
               SetRoles();
               _Initialized = true;
            }
         }
         catch(Exception exception)
         {
            Messager.ShowError(_RolesView, exception);
         }
      }

      private void SetPermissions()
      {         
         IPermissionManagementDataAccessAgent agent = DataAccessFactory.GetInstance(new PermissionManagementDataAccessConfigurationView(DicomDemoSettingsManager.GetGlobalPacsConfiguration(), DicomDemoSettingsManager.ProductNameStorageServer, null)).CreateDataAccessAgent<IPermissionManagementDataAccessAgent>();

         _RolesView.SetPermissions(agent.GetPermissions());
      }

      private void SetRoles()
      {
         _RolesView.SetRoles(RoleManager.GetAllRoles());
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

      private void OnUpdateServerSettings(object sender, EventArgs e)
      {
         List<Role> roles = new List<Role>(RoleManager.GetAllRoles());
         List<string> rolesAdded = new List<string>();

         foreach (string delete in _RolesView.RolesToDelete)
            RoleManager.DeleteRole(delete);

         foreach (KeyValuePair<string, Role> role in _RolesView.RolesToAdd)
         {
            List<string> permissions = (from rp in _RolesView.RolePermissions
                                        where rp.Key.ToLower() == role.Key.ToLower()
                                        select rp.Value).FirstOrDefault();

            role.Value.AssignedPermissions = permissions != null ? permissions.ToArray() : new List<string>().ToArray();
            RoleManager.AddRole(role.Value);
            rolesAdded.Add(role.Key);
         }

         foreach (string role in rolesAdded)
            _RolesView.RolesToAdd.Remove(role);

         foreach (KeyValuePair<string,List<string>> roleEdit in _RolesView.RolePermissions)
         {
            Role role = (from r in roles
                         where r.Name == roleEdit.Key
                         select r).FirstOrDefault();

            if (role != null)
            {
               List<string> permissions = role.AssignedPermissions.ToList();
               List<string> deletes = permissions.Except(roleEdit.Value).ToList();
               List<string> adds = roleEdit.Value.Except(permissions).ToList();

               if (deletes.Count > 0 || adds.Count > 0)
               {
                  foreach (string delete in deletes)
                     permissions.Remove(delete);

                  foreach (string add in adds)
                     permissions.Add(add);

                  role.AssignedPermissions = permissions.ToArray();
                  RoleManager.UpdateRole(role);
               }
            }            
         }
      }
   }
}

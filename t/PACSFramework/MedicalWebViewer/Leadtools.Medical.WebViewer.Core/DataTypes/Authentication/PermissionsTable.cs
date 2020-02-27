// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

namespace Leadtools.Medical.WebViewer.DataContracts
{
    [DataContract]
    public class PermissionsTable
    {
        const string _prefix = "MWV.";

        static PermissionsTable _instance = new PermissionsTable();
        public static PermissionsTable Instance { get { return _instance; } }

        [DataMember]
        public readonly Permission CanDownloadImages = new Permission() { Name = _prefix + "CanDownloadImages", FriendlyName = "Can Download Images", Description = "Allow users to Move images from remote PACS." };
        [DataMember]
        public readonly Permission CanDeleteImages = new Permission() { Name = "CanDeleteFromDatabase", FriendlyName = "Can Delete From Database", Description = "Allow users to delete from storage database." };
        [DataMember]
        public readonly Permission CanDeleteDownloadInfo = new Permission() { Name = _prefix + "CanDeleteDownloadInfo", FriendlyName = "Can Delete Download Info", Description = "Allow users to delete jobs in download queue." };
        [DataMember]
        public readonly Permission CanRetrieve = new Permission() { Name = _prefix + "CanRetrieve", FriendlyName = "Can Retrieve", Description = "Allow users to request DICOM DataSet through the web interface." };
        [DataMember]
        public readonly Permission CanQueryPACS = new Permission() { Name = _prefix + "CanQueryPACS", FriendlyName = "Can Query PACS", Description = "Allow users to query remote PACS through the web interface." };
        [DataMember]
        public readonly Permission CanQuery = new Permission() { Name = _prefix + "CanQuery", FriendlyName = "Can Query", Description = "Allow users to query local images through the web interface." };
        [DataMember]
        public readonly Permission CanManageUsers = new Permission() { Name = _prefix + "CanManageUsers", FriendlyName = "Can Manage Users", Description = "Allow users to manage other users through the web interface." };
        [DataMember]
        public readonly Permission CanManageRoles = new Permission() { Name = _prefix + "CanManageRoles", FriendlyName = "Can Manage Roles", Description = "Allow users to manage roles through the web interface." };
        [DataMember]
        public readonly Permission CanManageAccessRight = new Permission() { Name = _prefix + "CanManageAccessRight", FriendlyName = "Can Manage Access Right", Description = "Allow users to grant or deny access to patient information through the web interface." };
        [DataMember]
        public readonly Permission CanStore = new Permission() { Name = _prefix + "CanStore", FriendlyName = "Can Store", Description = "Allow users to store to server." };
        [DataMember]
        public readonly Permission CanViewAnnotations = new Permission() { Name = _prefix + "CanViewAnnotations", FriendlyName = "Can View Annotations", Description = "Allow users to load annotations." };
        [DataMember]
        public readonly Permission CanStoreAnnotations = new Permission() { Name = _prefix + "CanStoreAnnotations", FriendlyName = "Can Store Annotations", Description = "Allow users to save annotations." };
        [DataMember]
        public readonly Permission CanDeleteAnnotations = new Permission() { Name = _prefix + "CanDeleteAnnotations", FriendlyName = "Can Delete Annotations", Description = "Allow users to save annotations." };
        [DataMember]
        public readonly Permission CanExport = new Permission() { Name = _prefix + "CanExport", FriendlyName = "Can Export Dicom Files", Description = "Allow users to export DICOM files." };
        [DataMember]
        public readonly Permission CanManageRemotePACS = new Permission() { Name = _prefix + "CanManageRemotePACS", FriendlyName = "Can manage remote PACS", Description = "Allow users to manage remote PACS." };
        [DataMember]
        public readonly Permission CanCalibrateMonitor = new Permission() { Name = _prefix + "CanCalibrateMonitor", FriendlyName = "Can calibrate monitor", Description = "Allow users to calibrate monitor." };
        [DataMember]
        public readonly Permission CanEditTemplates = new Permission() { Name = _prefix + "CanEditTemplates", FriendlyName = "Can edit templates", Description = "Allow users to edit templates." };
        [DataMember]
        public readonly Permission CanDeleteTemplates = new Permission() { Name = _prefix + "CanDeleteTemplates", FriendlyName = "Can delete templates", Description = "Allow users to delete templates." };
        [DataMember]
        public readonly Permission CanModifyBuiltInTemplates = new Permission() { Name = _prefix + "CanModifyBuiltInTemplates", FriendlyName = "Can modify built in templates", Description = "Allow users to modify built in templates." };
        [DataMember]
        public readonly Permission CanAddTemplates = new Permission() { Name = _prefix + "CanAddTemplates", FriendlyName = "Can add templates", Description = "Allow users to add templates." };
        [DataMember]
        public readonly Permission CanViewTemplates = new Permission() { Name = _prefix + "CanViewTemplates", FriendlyName = "Can view templates", Description = "Allow users to view templates." };
        [DataMember]
        public readonly Permission CanImportTemplates = new Permission() { Name = _prefix + "CanImportTemplates", FriendlyName = "Can import templates", Description = "Allow users to import templates." };
        [DataMember]
        public readonly Permission CanExportTemplates = new Permission() { Name = _prefix + "CanExportTemplates", FriendlyName = "Can export templates", Description = "Allow users to export templates." };
        [DataMember]
        public readonly Permission CanSaveSeriesLayout = new Permission() { Name = _prefix + "CanSaveSeriesLayout", FriendlyName = "Can save series layout", Description = "Allow users to save series layout." };
        [DataMember]
        public readonly Permission CanSaveHangingProtocol = new Permission() { Name = _prefix + "CanSaveHangingProtocol", FriendlyName = "Can save hanging protocols", Description = "Allow users to create and save hanging protocols." };
        [DataMember]
        public readonly Permission CanDeleteCache = new Permission() { Name = _prefix + "CanDeleteCache", FriendlyName = "Can delete cached images", Description = "Allow users to delete cached images." };
      
        [DataMember]
        public List<Permission> Permissions { get; private set; }

        public List<string> PermissionsNames
        {
            get
            {
                List<string> permissionsNames = new List<string>();
                foreach (Permission permission in Permissions)
                {
                    permissionsNames.Add(permission.Name);
                }
                return permissionsNames;
            }
        }

        public PermissionsTable()
        {
            Permissions = new List<Permission>();

            Permissions.Add(CanDownloadImages);
            Permissions.Add(CanDeleteImages);
            Permissions.Add(CanDeleteDownloadInfo);
            Permissions.Add(CanRetrieve);
            Permissions.Add(CanQueryPACS);
            Permissions.Add(CanQuery);
            Permissions.Add(CanManageUsers);
            Permissions.Add(CanManageRoles);
            Permissions.Add(CanManageAccessRight);
            Permissions.Add(CanStore);
            Permissions.Add(CanViewAnnotations);
            Permissions.Add(CanStoreAnnotations);
            Permissions.Add(CanDeleteAnnotations);
            Permissions.Add(CanExport);
            Permissions.Add(CanManageRemotePACS);
            Permissions.Add(CanCalibrateMonitor);
            Permissions.Add(CanEditTemplates);
            Permissions.Add(CanDeleteTemplates);
            Permissions.Add(CanModifyBuiltInTemplates);
            Permissions.Add(CanAddTemplates);
            Permissions.Add(CanViewTemplates);
            Permissions.Add(CanImportTemplates);
            Permissions.Add(CanExportTemplates);
            Permissions.Add(CanSaveSeriesLayout);
            Permissions.Add(CanSaveHangingProtocol);
            Permissions.Add(CanDeleteCache);
        }

        public Permission Find(string name)
        {
            Permission result = Permissions.Find(delegate(Permission permission) { return permission.Name == name; });
            return result;
        }

        public Permission[] Find(string[] names)
        {
            List<Permission> result = new List<Permission>();
            foreach (string p in names)
            {
                result.Add(Find(p));
            }
            return result.ToArray();
        }

        public UInt64 ToToken64(Permission[] permissions)
        {
           if(Permissions.Count>=64)
           {
              throw new Exception("Too many permissions.");
           }

           UInt64 perm = 0;
           foreach (var p in permissions)
           {
              var i = Permissions.FindIndex((o) => o == p);
              if (i >= 0)
              {
                 i++; //we want a flag and zero doesn't count as one
                 perm |= ((UInt64)1 << i);
              }
           }

           return perm;
        }

        public UInt32 ToToken(Permission[] permissions)
        {
           if(Permissions.Count>=32)
           {
              throw new Exception("Too many permissions, use 64bit token instead.");
           }

           UInt32 perm = 0;
           foreach (var p in permissions)
           {
              var i = Permissions.FindIndex((o) => o == p);
              if (i >= 0)
              {
                 i++; //we want a flag and zero doesn't count as one
                 perm |= ((UInt32)1 << i);
              }
           }

           return perm;
        }

        public List<Permission> FromToken(UInt32 perm)
        {
           List<Permission> result = new List<Permission>();
           for (int index = 0; index < Permissions.Count; index++)
           {
              if ((perm & ((UInt32)1 << (index + 1))) != 0)
              {
                 result.Add(Permissions[index]);
              }
           }

           return result;
        }

        public List<Permission> FromToken(UInt64 perm)
        {
           List<Permission> result = new List<Permission>();
           for (int index = 0; index < Permissions.Count; index++)
           {
              if ((perm & ((UInt64)1 << (index + 1))) != 0)
              {
                 result.Add(Permissions[index]);
              }
           }

           return result;
        }

        public bool Contains(UInt32 perm, string permission)
        {
           return FromToken(perm).Contains(new Permission() { Name = permission });
        }

        public bool Contains(UInt32 perm, Permission permission)
        {
           return FromToken(perm).Contains(permission);
        }

        public bool Contains(UInt64 perm, string permission)
        {
           return FromToken(perm).Contains(new Permission() { Name = permission });
        }

        public bool Contains(UInt64 perm, Permission permission)
        {
           return FromToken(perm).Contains(permission);
        }
    }
}

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
   public class RolesBuiltInTable
   {
      static RolesBuiltInTable _instance = new RolesBuiltInTable();
      public static RolesBuiltInTable Instance { get { return _instance; } }

      [DataMember]
      public readonly Role Admin = new Role() { Name = "Administrators", Description = "Web viewer administrator, full permissions.", AssignedPermissions = new List<string>(PermissionsTable.Instance.PermissionsNames.ToArray()) };

      [DataMember]
      public List<Role> Roles { get; private set; }

      public RolesBuiltInTable()
      {
         Roles = new List<Role>();

         Roles.Add(Admin);
      }
      
      public Role Find(string name)
      {
         Role result = Roles.Find(delegate(Role Role) { return Role.Name == name; });
         return result;
      }

      public Role[] Find(string[] names)
      {
         List<Role> result = new List<Role>();
         foreach (string p in names)
         {
            result.Add(Find(p));
         }
         return result.ToArray();
      }
   }
}

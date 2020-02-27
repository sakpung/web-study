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
   /// <summary>
   /// Role
   /// </summary>
   [DataContract]
   public class Role
   {
      [DataMember]
      public string Name { get; set; }
      [DataMember]
      public List<string> AssignedPermissions { get; set; }
      [DataMember]
      public string Description { get; set; }      
   }

   public class RoleComparer : IEqualityComparer<Role>
   {
      public bool Equals(Role r1, Role r2)
      {
         return r1.Name == r2.Name;
      }

      public int GetHashCode(Role r)
      {
         return r.Name.GetHashCode();
      }
   }
}

// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;
using System.Collections;

namespace Leadtools.Medical.WebViewer.DataContracts
{
   /// <summary>
   /// Permission
   /// </summary>
   [DataContract]
   public class Permission : IEquatable<Permission>
   {
      [DataMember]
      public string Name { get; set; }
      [DataMember]
      public string FriendlyName { get; set; }
      [DataMember]
      public string Description { get; set; }

      public bool Equals(Permission other)
      {
         if (other == null)
            return false;

         return String.Equals(Name, other.Name, StringComparison.OrdinalIgnoreCase);
      }
   }

   public class PermissionComparer : IEqualityComparer<Permission>
   {
      public bool Equals(Permission p1, Permission p2)
      {
         return p1.Name == p2.Name;
      }

      public int GetHashCode(Permission p)
      {
         return p.Name.GetHashCode();
      }
   }
}

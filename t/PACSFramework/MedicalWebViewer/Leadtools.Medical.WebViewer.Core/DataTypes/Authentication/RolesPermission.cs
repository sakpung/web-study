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
   /// Roles permission
   /// </summary>
   [DataContract]
   public class RolePermissions
   {
      [DataMember]
      public string Role { get; set; }
      [DataMember]
      public string PatientId { get; set; }
   }
}

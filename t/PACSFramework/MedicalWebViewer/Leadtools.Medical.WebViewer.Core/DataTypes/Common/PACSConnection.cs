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
   public class RemoteConnection
   {
      [DataMember]
      public string type { get; set; }
      [DataMember]
      public string id { get; set; }
      [DataMember]
      public bool isDefault { get; set; }
      [DataMember]
      public string name { get; set; }
   }
   // Data for connecting to PACS server
   [DataContract]
   public class PACSConnection : RemoteConnection
   {
      // PACS IP Address
      [DataMember]
      public string IPAddress { get; set; }

      // PACS port
      [DataMember]
      public int Port { get; set; }

      // PACS AE title
      [DataMember]
      public string AETitle { get; set; }

      // Extra options
      [DataMember]
      public ExtraOptions ExtraOptions { get; set; }
   }
}

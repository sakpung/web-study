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
   // Optional data for client connection
   [DataContract]
   public class ClientConnection
   {
      // Client AE title
      [DataMember]
      public string AETitle { get; set; }

      // Extra options
      [DataMember]
      public ExtraOptions ExtraOptions { get; set; }
   }
}

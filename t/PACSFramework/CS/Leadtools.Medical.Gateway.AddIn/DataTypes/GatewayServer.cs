// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Leadtools.Dicom.AddIn.Common;
using Leadtools.Dicom;

namespace Leadtools.Medical.Gateway.CFindAddin.DataTypes
{
   [Serializable]
   public class GatewayServer
   {
      public GatewayServer ( ) 
      {
         RemoteServers = new List<AeInfo> ( ) ;
      }
      
      public int NumberOfTimesToUseSecondaryServer { get ; set ; }
      public string ServiceName { get ; set ; }
      public AeInfo Server { get ; set ; }
      public List<AeInfo> RemoteServers { get ; set ; }
   }
}

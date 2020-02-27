// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Runtime.Serialization;

namespace Leadtools.Document.Service.Models.Test
{
   [DataContract]
   public class HeartbeatResponse : Response
   {
      /// <summary>
      /// The current time, so the user may tell if it was cached.
      /// </summary>
      [DataMember(Name = "time")]
      public DateTime Time;
   }
}

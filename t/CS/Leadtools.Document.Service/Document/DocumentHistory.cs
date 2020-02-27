// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************

using System.Runtime.Serialization;

namespace Leadtools.Document.Service.Document
{
   [DataContract]
   public class DocumentHistory
   {
      [DataMember(Name = "autoUpdateHistory")]
      public bool AutoUpdateHistory;
   }
}

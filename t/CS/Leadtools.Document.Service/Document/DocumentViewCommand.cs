// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************

using System.Runtime.Serialization;

namespace Leadtools.Document.Service.Document
{
   [DataContract]
   public class DocumentViewCommand
   {
      [DataMember(Name = "command")]
      public string Command;

      [DataMember(Name = "parameters")]
      public string Parameters;
   }
}

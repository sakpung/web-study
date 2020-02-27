// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************

using Leadtools.Document.Service.Document;
using System.Runtime.Serialization;

namespace Leadtools.Document.Service.Models.Factory
{
   [DataContract]
   public class SaveToCacheRequest : Request
   {
      /// <summary>
      /// The data to use when creating or saving this document - a serialized instance of Leadtools.Document.DocumentDescriptor.
      /// </summary>
      [DataMember(Name = "descriptor")]
      public DocumentDescriptor Descriptor;
   }
}

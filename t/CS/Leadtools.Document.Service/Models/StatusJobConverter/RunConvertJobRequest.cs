// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************

using Leadtools.Document.Service.Document.Converter;
using System.Runtime.Serialization;

namespace Leadtools.Document.Service.Models.StatusJobConverter
{
   [DataContract]
   public class RunConvertJobRequest : Request
   {
      /// <summary>
      /// The ID of the document to convert.
      /// </summary>
      [DataMember(Name = "documentId")]
      public string DocumentId;

      /// <summary>
      /// The relevant job data that will be used to understand the conversion needed.
      /// </summary>
      [DataMember(Name = "jobData")]
      public JobData JobData;
   }
}

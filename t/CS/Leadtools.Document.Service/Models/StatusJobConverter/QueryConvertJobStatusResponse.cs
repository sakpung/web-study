// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************

using Leadtools.Document.Service.Document.Converter;
using System.Runtime.Serialization;

namespace Leadtools.Document.Service.Models.StatusJobConverter
{
   [DataContract]
   public class QueryConvertJobStatusResponse : Response
   {
      /// <summary>
      /// All data depicting the status of the job.
      /// </summary>
      [DataMember(Name = "jobData")]
      public StatusJobData jobData;
   }
}

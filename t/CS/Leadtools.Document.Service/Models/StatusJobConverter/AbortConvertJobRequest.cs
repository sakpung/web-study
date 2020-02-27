// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************

using System.Runtime.Serialization;

namespace Leadtools.Document.Service.Models.StatusJobConverter
{
   [DataContract]
   public class AbortConvertJobRequest : Request
   {
      /// <summary>
      /// The user token (region) for the job.
      /// </summary>
      [DataMember(Name = "userToken")]
      public string UserToken;

      /// <summary>
      /// The job token (key) for the job.
      /// </summary>
      [DataMember(Name = "jobToken")]
      public string JobToken;
   }
}

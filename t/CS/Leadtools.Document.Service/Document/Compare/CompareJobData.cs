using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Leadtools.Document.Service.Document.Compare
{
   [DataContract]
   public class CompareJobData
   {
      [DataMember(Name = "jobToken")]
      public string JobToken { get; set; }

      [DataMember(Name = "userToken")]
      public string UserToken { get; set; }

      [DataMember(Name = "reportOptions")]
      public ReportOptions ReportOptions { get; set; }

      [DataMember(Name = "outputDocumentId")]
      public string OutputDocumentId { get; set; }

      [DataMember(Name = "outputMimetype")]
      public string OutputMimetype { get; set; }

      [DataMember(Name = "outputDocumentName")]
      public string OutputDocumentName { get; set; }

      [DataMember(Name = "outputUri")]
      public Uri OutputUri { get; set; }

      [DataMember(Name = "compareResults")]
      public object CompareResults { get; set; }

      [DataMember(Name = "jobStartedTimestamp")]
      public string JobStartedTimestamp { get; set; }

      [DataMember(Name = "jobCompletedTimestamp")]
      public string JobCompletedTimestamp { get; set; }

      [DataMember(Name = "jobStatusChangedTimestamp")]
      public string JobStatusChangedTimestamp { get; set; }

      [DataMember(Name = "jobStatus")]
      public CompareStatus JobStatus { get; set; }

      [DataMember(Name = "isCompleted")]
      public bool IsCompleted { get; set; }

      [DataMember(Name = "abort")]
      public bool Abort { get; set; }

      [DataMember(Name = "errors")]
      public IList<string> Errors { get; set; }
   }
}

using Leadtools.Document.Service.Document.Compare;
using System.Runtime.Serialization;

namespace Leadtools.Document.Service.Models.Compare
{
   [DataContract]
   public class QueryCompareJobResponse : Response
   {
      [DataMember(Name = "jobData")]
      public CompareJobData jobData;
   }
}

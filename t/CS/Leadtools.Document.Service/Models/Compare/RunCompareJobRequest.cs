using Leadtools.Document.Service.Document.Compare;
using System.Runtime.Serialization;

namespace Leadtools.Document.Service.Models.Compare
{
   [DataContract]
   public class RunCompareJobRequest : Request
   {
      [DataMember(Name = "jobData")]
      public CompareBaseData JobData;
   }
}

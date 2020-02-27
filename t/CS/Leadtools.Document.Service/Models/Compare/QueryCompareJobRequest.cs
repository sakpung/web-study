using System.Runtime.Serialization;

namespace Leadtools.Document.Service.Models.Compare
{
   [DataContract]
   public class QueryCompareJobRequest : Request
   {
      [DataMember(Name = "userToken")]
      public string UserToken;

      [DataMember(Name = "jobToken")]
      public string JobToken;
   }
}

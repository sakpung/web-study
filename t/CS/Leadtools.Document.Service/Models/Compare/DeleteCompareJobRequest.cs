using System.Runtime.Serialization;

namespace Leadtools.Document.Service.Models.Compare
{
   [DataContract]
   public class DeleteCompareJobRequest : Request
   {
      [DataMember(Name = "userToken")]
      public string UserToken;

      [DataMember(Name = "jobToken")]
      public string JobToken;
   }
}

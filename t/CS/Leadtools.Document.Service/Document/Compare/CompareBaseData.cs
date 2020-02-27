using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Leadtools.Document.Service.Document.Compare
{
   [DataContract]
   public class CompareBaseData
   {
      [DataMember(Name = "documentIds")]
      public IList<string> DocumentIds;

      [DataMember(Name = "outputDocumentId")]
      public string OutputDocumentId;

      [DataMember(Name = "outputMimetype")]
      public string OutputMimetype;
   }
}

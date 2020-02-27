using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Leadtools.Document.Service.Document.Compare
{
   [DataContract]
   public class ReportOptions
   {
      [DataMember(Name = "documentNames")]
      public IList<string> DocumentNames;

      [DataMember(Name = "reportHeaders")]
      public IList<string> ReportHeaders;

      [DataMember(Name = "reportFooters")]
      public IList<string> ReportFooters;

      [DataMember(Name = "insertionColor")]
      public string InsertionColor;

      [DataMember(Name = "deletionColor")]
      public string DeletionColor;

      [DataMember(Name = "baseColor")]
      public string BaseColor;

      [DataMember(Name = "underlineColor")]
      public string UnderlineColor;

      [DataMember(Name = "strikethroughColor")]
      public string StrikethroughColor;
   }
}

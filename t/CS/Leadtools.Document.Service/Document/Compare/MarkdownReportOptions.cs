using System.Collections.Generic;
using System.Runtime.Serialization;


namespace Leadtools.Document.Service.Document.Compare
{
   [DataContract]
   public class MarkdownReportOptions : ReportOptions
   {
      [DataMember(Name = "insertionCSSClass")]
      public string InsertionCSSClass;

      [DataMember(Name = "deletionCSSClass")]
      public string DeletionCSSClass;

      [DataMember(Name = "baseCSSClass")]
      public string BaseCSSClass;

      [DataMember(Name = "underlineCSSClass")]
      public string UnderlineCSSClass;

      [DataMember(Name = "strikethroughCSSClass")]
      public string StrikethroughCSSClass;
   }
}

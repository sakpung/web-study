using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Serverless_Cloud_Services_API
{
   /// <summary>
   /// Base Web Request class that all other Web Request classes inherit from. 
   /// </summary>
   [DataContract]
   public class LeadWebRequest
   {
      /// <summary>
      /// URL to the file to process
      /// </summary>
      [DataMember(Name = "fileUrl")]
      public string fileUrl { get; set; }

      /// <summary>
      /// The first page in the file to process
      /// </summary>
      [DataMember(Name = "firstPage")]
      public int FirstPage { get; set; }

      /// <summary>
      /// The last page in the file to process
      /// </summary>
      [DataMember(Name = "lastPage")]
      public int LastPage { get; set; }
   }
}

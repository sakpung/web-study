using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Leadtools.Document.Service.Models
{
   [DataContract]
   public class ServiceError
   {
      /* Always safe to show to an end-user.
       * Will hold the "SafeErrorMessage" attribute of a method
       * or the Exception.Message of an explicit ServiceException.
       */
      [DataMember]
      public string Message;

      [DataMember]
      public HttpStatusCode StatusCode;

      /* Sometimes null. Not end-user safe.
       * Often contains the actual Exception.Message from an 
       * Exception that wasn't thrown as a ServiceException.
       */
      [DataMember]
      public string Detail;

      [DataMember]
      public int Code;

      [DataMember]
      public string Link;

      [DataMember]
      public string ExceptionType;

      [DataMember]
      public string MethodName;

      [DataMember]
      public string UserData;
   }
}

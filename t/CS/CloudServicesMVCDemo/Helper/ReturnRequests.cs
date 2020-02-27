using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace Cloud_Services_Api.Helper
{

   /// <summary>
   /// Request object to be returned when an exception is caught by an API controller.
   /// </summary>
   public class InvalidRequest
   {
      /// <summary>
      /// The status code corresponding to the exception
      /// </summary>
      public HttpStatusCode Status { get; set; }
      /// <summary>
      /// The exception message that was generated
      /// </summary>
      public string ErrorMessage { get; set; }
   }
}
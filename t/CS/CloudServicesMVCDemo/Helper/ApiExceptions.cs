using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cloud_Services_Api.Helper
{
   /// <summary>
   /// Exception that to be thrown when a request that is made to the API is malformed, or if the parameters that are passed are not correct. 
   /// </summary>
   [Serializable]
   public class MalformedRequestException : Exception
   {
      public MalformedRequestException()
      {
      }

      public MalformedRequestException(string message)
        : base(message)
      {
      }

      public MalformedRequestException(string message, Exception inner)
        : base(message, inner)
      {
      }
   }

   /// <summary>
   /// Exception that to be thrown if a file fails the verification step
   /// </summary>
   [Serializable]
   public class RejectedFileException : Exception
   {
      public RejectedFileException()
      {
      }

      public RejectedFileException(string message)
        : base(message)
      {
      }

      public RejectedFileException(string message, Exception inner)
        : base(message, inner)
      {
      }
   }

   /// <summary>
   /// Exception that to be thrown if a file fails to load.
   /// </summary>
   [Serializable]
   public class FormatNotSupportedException : Exception
   {
      public FormatNotSupportedException()
      {
      }

      public FormatNotSupportedException(string message)
        : base(message)
      {
      }

      public FormatNotSupportedException(string message, Exception inner)
        : base(message, inner)
      {
      }
   }
}
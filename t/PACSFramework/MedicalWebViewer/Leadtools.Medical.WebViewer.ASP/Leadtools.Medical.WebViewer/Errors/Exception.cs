// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace Leadtools.Medical.WebViewer.Errors
{
   public class ServiceException : Exception
   {
      public ServiceException(string message, HttpStatusCode errorCode = HttpStatusCode.NotImplemented) :
         base(message)
      {
         Status = errorCode;
      }

      public HttpStatusCode Status
      {
         get;
         private set;
      }
   }

   public class ServiceAuthenticationException : ServiceException
   {
      public ServiceAuthenticationException(string message) :
      base(message, HttpStatusCode.Unauthorized)
      {

      }
   }

   public class ServiceAuthorizationException : ServiceException
   {
      public ServiceAuthorizationException(string message) :
      base(message, HttpStatusCode.Forbidden)
      {

      }
   }

   public class ServiceSetupException : ServiceException
   {
      public ServiceSetupException(string msg) :
         base(msg, HttpStatusCode.InternalServerError)
      {
      }
   }

   public class ServiceNotFoundException : ServiceException
   {
      public ServiceNotFoundException() :
         base("Requested resource was not found", HttpStatusCode.NotFound)
      {
      }
   }
   public class ServiceMissingParamException : ServiceException
   {
      public ServiceMissingParamException(string param) :
         base(string.Format("Missing mandatory parameter: " + param), HttpStatusCode.BadRequest)
      {
      }
   }

   public class ServiceInvalidParamException : ServiceException
   {
      ///http://www.ihe.net/Technical_Framework/upload/IHE_RAD-TF_Suppl_XDSI_TI_2005-08-15.pdf
      ///4.55.4.1.3 Expected Actions
      public ServiceInvalidParamException(string param) :
         base(string.Format("Invalid parameter: " + param), HttpStatusCode.BadRequest)
      {
      }
   }

   public class ServiceUnsupportedMimeException : ServiceException
   {
      ///http://www.ihe.net/Technical_Framework/upload/IHE_RAD-TF_Suppl_XDSI_TI_2005-08-15.pdf
      ///4.55.4.1.3 Expected Actions
      public ServiceUnsupportedMimeException(string mime) :
         base(string.Format("Mime type not supported: " + mime), HttpStatusCode.NotAcceptable)
      {
      }
   }

   public class ServiceInvalidInstanceException : ServiceException
   {
      ///http://www.ihe.net/Technical_Framework/upload/IHE_RAD-TF_Suppl_XDSI_TI_2005-08-15.pdf
      ///4.55.4.1.3 Expected Actions
      public ServiceInvalidInstanceException(string uid) :
         base(string.Format("cannot locate the requested DICOM SOP Instance or cannot recognize the UID values: " + uid), HttpStatusCode.NotFound)
      {
      }
   }

   public class ServiceInternalErrorException : ServiceException
   {
      public ServiceInternalErrorException(string message) :
         base(string.Format("Internal error has occurred: " + message), HttpStatusCode.InternalServerError)
      {
      }
   }

   public class ServiceNotImplException : ServiceException
   {
      public ServiceNotImplException(string message) :
         base(string.Format("Feature not implemented: " + message), HttpStatusCode.InternalServerError)
      {
      }
   }
}

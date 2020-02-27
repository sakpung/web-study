// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel.Dispatcher;
using System.ServiceModel.Channels;
using System.ServiceModel;
using System.Runtime.Serialization.Json;
using System.Net;
using Leadtools.Medical.WebViewer.Wcf.Helper;

namespace Leadtools.Dicom.Services.ErrorHandler
{
   /// <summary>
   /// This error handler is defined in the web.config to handle all errors returned by the service. 
   /// The handler will convert exceptions into JSON format so they can be easily read from JS
   /// </summary>
   public class JsonErrorHandler: IErrorHandler  
   {  
     #region Public Method(s)  
     #region IErrorHandler Members  

     public bool HandleError(Exception error)  
     {  
       return true;  
     }  
  
     /// <summary>
     /// Creates a JSON formatted fault message from the excpetion
     /// </summary>
     /// <param name="error"></param>
     /// <param name="version"></param>
     /// <param name="fault"></param>
     public void ProvideFault(Exception error, MessageVersion version,  
       ref Message fault)  
     {  
       
       HttpStatusCode status  = HttpStatusCode.BadRequest ;

       if ( error is ServiceException ) 
       {
         status = ( ( ServiceException ) error ).Status ;
       }

       fault = this.GetJsonFaultMessage(version, error);  
       
       this.ApplyJsonSettings(ref fault);  
       this.ApplyHttpResponseSettings(ref fault, status, error.Message);  
     }  
     #endregion  
     #endregion   
 
     #region Protected Method(s)  
     ///  
     /// Apply Json settings to the message  
     ///  
     protected virtual void ApplyJsonSettings(ref Message fault)  
     {  
       // Use JSON encoding  
       var jsonFormatting =  new WebBodyFormatMessageProperty(WebContentFormat.Json);  
       
       fault.Properties.Add(WebBodyFormatMessageProperty.Name, jsonFormatting);  
     }  
  
     ///  
     /// Get the HttpResponseMessageProperty  
     ///  
     protected virtual void ApplyHttpResponseSettings(  
       ref Message fault, System.Net.HttpStatusCode statusCode,  
       string statusDescription)  
     {  
       var httpResponse = new HttpResponseMessageProperty()  
       {  
         StatusCode = statusCode,  
         StatusDescription = statusDescription
       };  

       fault.Properties.Add(HttpResponseMessageProperty.Name, httpResponse);  
     }  
  
     ///  
     /// Get the json fault message from the provided error  
     ///  
     protected virtual Message GetJsonFaultMessage(  
       MessageVersion version, Exception error)  
     {  
       //BaseFault detail = null;  
       var knownTypes = new List<Type>();  
       string faultType = error.GetType().Name; //default  
  
       //if ((error is FaultException) &&  
       //    (error.GetType().GetProperty("Detail") != null))  
       //{  
       //  detail =  
       //    (error.GetType().GetProperty("Detail").GetGetMethod().Invoke(  
       //     error, null) as BaseFault);  
       //  knownTypes.Add(detail.GetType());  
       //  faultType = detail.GetType().Name;  
       //}  
  
       JsonFault jsonFault = new JsonFault  
       {
          Message = error.Message + ((error.InnerException!=null)?error.InnerException.Message:""),  
         //Detail = detail,  
         FaultType = faultType  
       };  
  
       var faultMessage = Message.CreateMessage(version, "", jsonFault,  
         new DataContractJsonSerializer(jsonFault.GetType(), knownTypes));  
  
       return faultMessage;  
     }  
     #endregion  
   }  
}

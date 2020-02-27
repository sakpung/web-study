// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel.Description;

namespace Leadtools.Dicom.Services.ErrorHandler
{
   public class JsonErrorWebHttpBehavior: WebHttpBehavior  
   {  
     #region Protected Method(s)  
     ///  
     /// Add the json error handler to channel error handlers  
     ///  
     protected override void AddServerErrorHandlers(ServiceEndpoint endpoint,  
       System.ServiceModel.Dispatcher.EndpointDispatcher endpointDispatcher)  
     {  
       // clear default error handlers.  
       endpointDispatcher.ChannelDispatcher.ErrorHandlers.Clear();  
  
       // add the Json error handler.  
       endpointDispatcher.ChannelDispatcher.ErrorHandlers.Add(  
         new JsonErrorHandler());  
     }  
     #endregion  
   }
}

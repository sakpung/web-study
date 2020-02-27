// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel.Configuration;

namespace Leadtools.Dicom.Services.ErrorHandler
{
   public class JsonErrorWebHttpBehaviorElement : BehaviorExtensionElement  
   {  
     ///  
     /// Get the type of behavior to attach to the endpoint  
     ///  
     public override Type BehaviorType  
     {  
       get  
       {  
         return typeof(JsonErrorWebHttpBehavior);  
       }  
     }  
  
     ///  
     /// Create the custom behavior  
     ///  
     protected override object CreateBehavior()  
     {  
       return new JsonErrorWebHttpBehavior();  
     }  
   } 
}

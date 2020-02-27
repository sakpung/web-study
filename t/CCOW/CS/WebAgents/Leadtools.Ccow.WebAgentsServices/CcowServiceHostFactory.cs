// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Description;
using Leadtools.Ccow.Services;

namespace Leadtools.Ccow.WebAgentsServices
{
   public class CcowServiceHostFactory : ServiceHostFactory
   {
      protected override ServiceHost CreateServiceHost(Type serviceType, Uri[] baseAddresses)
      {
         ServiceHost host = new ServiceHost(serviceType, baseAddresses);

         foreach (Uri address in baseAddresses)
         {
            WebHttpBinding b = new WebHttpBinding();

            b.Name = serviceType.Name;

            ServiceEndpoint endPoint = host.AddServiceEndpoint(serviceType.GetInterfaces()[0], b, address);
            endPoint.Behaviors.Add(new CcowWebHttpBehavior());
         }
         return host;
      }
   }
}

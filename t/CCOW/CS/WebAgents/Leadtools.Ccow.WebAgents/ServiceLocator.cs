// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System.IO;
using System.Net;
using System.Text;
using Leadtools.Ccow.Web;

namespace Leadtools.Ccow.WebAgents
{
   class ServiceLocator : ICcowServiceLocator
   {
#if LTV19_CONFIG
      private const string _serviceHostName = "CcowWebAgentsServices19";
#endif // LTV19_CONFIG

#if LTV20_CONFIG
      private const string _serviceHostName = "CcowWebAgentsServices20";
#endif // LTV19_CONFIG

      private string _urlFormat = string.Empty;
      public ServiceLocator(string serviceName)
      {
         _urlFormat = string.Format("http://localhost/{0}/{1}.svc/?", _serviceHostName, serviceName);
         _urlFormat += "{0}";
      }

      public string Send(string data)
      {
         string responseString = string.Empty;
         WebRequest request = WebRequest.Create(string.Format(_urlFormat, data));
         using (WebResponse response = request.GetResponse())
         using (Stream stream = response.GetResponseStream())
         {
            StreamReader reader = new StreamReader(stream, Encoding.UTF8);
            responseString = reader.ReadToEnd();
         }

         return responseString;
      }
   }
}
